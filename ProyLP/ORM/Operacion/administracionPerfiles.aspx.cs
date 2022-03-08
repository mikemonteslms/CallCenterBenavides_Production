using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Telerik.Web.UI;
using System.Collections;
using System.Data;

namespace ORMOperacion
{
    public partial class administracionPerfiles : System.Web.UI.Page
    {
        private Hashtable rolNombre = new Hashtable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                Master.Menu = "Control de acceso";
                Master.Submenu = "Roles";
            }
        }


        protected void gridRoles_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            ///Insertar el rol a la tabla de roles
            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            //Verificar que el nombre del rol no exista. El membsership solamente permite ingresar roles que tengan descripción diferente
            if (!Roles.RoleExists(values["rol"].ToString()))
            {
                
                Roles.CreateRole(values["rol"].ToString());
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('El rol fue creado correctamente.');</script>");
                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('El rol ya existe.');</script>");
            }

        }

        protected void gridRoles_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "delete")
            {
                //Validar que el rol exista. Como se trabaja con el membership se trabaja con nombres no con IDs
                if (Roles.RoleExists(e.Item.Cells[4].Text))
                {
                    try
                    {
                        //Eliminar los usuarios que tengan asignado el rol a eliminar
                        string[] usuarios = Roles.GetUsersInRole(e.Item.Cells[4].Text);
                        if (usuarios.Count() > 0)
                        {
                            Roles.RemoveUsersFromRole(usuarios, e.Item.Cells[4].Text);
                        }
                        //Eliminar el rol
                        Roles.DeleteRole(e.Item.Cells[4].Text);
                        ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('El rol fue eliminado correctamente.');</script>");                        
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('Ocurrió un error al eliminar el rol: "+ex.Message+"');</script>");
                        
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('El rol no existe.');</script>");
                }
            }
        }

        
        protected void gridRoles_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            List<string> roles = new List<string>();
            //Este método solamente obtiene los nombres de los roles. El membership no trabaja con el id. 
            string[] _roles = Roles.GetAllRoles();

            foreach (string r in _roles)
            {
                roles.Add(r);
            }
            gridRoles.DataSource = roles;

        }

        protected void gridRoles_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                var editableItem = ((GridEditableItem)e.Item);
                Hashtable values = new Hashtable();
                Hashtable valuesOld = new Hashtable();
                editableItem.ExtractValues(values);

                //Con el membership no se puede hacer actualización del nombre del rol 
                //ya que las relaciones que trabaja internamente lo hace con el nombre y no con el ID
                //Para poder realizar la edición se deben se seguir los siguientes pasos:

                //Verificar que el rol no exista, porque no tiene sentido hacer todo el proceso por algo que no se está cambiando
                if (!Roles.RoleExists(values["rol"].ToString()))
                {
                    //Obtener todos los usuarios que están asignados al nombre anterior del rol
                    string[] users = Roles.GetUsersInRole(editableItem.SavedOldValues["rol"].ToString());
                    //Crear el nuevo rol con el nombre que se está dando
                    Roles.CreateRole(values["rol"].ToString());
                    //Si hay usuarios asociados al rol de debe de mover al nuevo rol
                    if (users.Length > 0)
                    {
                        Roles.AddUsersToRole(users, values["rol"].ToString());
                        //Eliminar los usuarios asociados al nombre anterior del rol
                        Roles.RemoveUsersFromRole(users, editableItem.SavedOldValues["rol"].ToString());
                    }
                    //Eliminar el rol que tiene el nombre anterior
                    Roles.DeleteRole(editableItem.SavedOldValues["rol"].ToString());

                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('Error al actualizar la función');</script>");
            }
        }


        protected void gridRoles_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                //Para asociar las funciones a un rol la funcionalidad del Link se trabajará con el tooltip de Telerik
                HyperLink hlAddMenu = (HyperLink)e.Item.FindControl("hlAddMenu");
                if (!Object.Equals(hlAddMenu, null))
                {
                    if (!Object.Equals(this.RadToolTipManager1, null))
                    {
                        this.RadToolTipManager1.TargetControls.Add(hlAddMenu.ClientID, true);

                        //Guardar en un arreglo los nombres de los roles para poder identificar cual información se debe de cargar
                        if (!this.rolNombre.ContainsKey(hlAddMenu.ClientID))
                            this.rolNombre.Add(hlAddMenu.ClientID, e.Item.Cells[4].Text);
                        
                    }
                }
            }

            if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
            {
                GridEditFormItem editform = (GridEditFormItem)e.Item;
                //editform["AddMenu"].Parent.Visible = false;
            }
        }


        protected void RadToolTipManager1_AjaxUpdate(object sender, ToolTipUpdateEventArgs e)
        {
            //Funcionalidad para abrir el contenido del tootil cuando se haga clic sobre agregar funciones
            AgregarFuncionesRol ctrlAddRoles = (AgregarFuncionesRol)Page.LoadControl("AgregarFuncionesRol.ascx");
            Hashtable sessionSupplierIDs = (Hashtable)Session["rolNombre"];
            //El nombre del control de usuario debe ser único ya que el ascx no reconoce cuando se hace un postback y cuando no
            ctrlAddRoles.ID = "UcAddRoles" + sessionSupplierIDs[e.TargetControlID].ToString();
            ctrlAddRoles.Rol = sessionSupplierIDs[e.TargetControlID].ToString();
            e.UpdatePanel.ContentTemplateContainer.Controls.Add(ctrlAddRoles);
            RadToolTipManager1.Title = "Menú " + ctrlAddRoles.Rol;
        }

        
        protected void gridRoles_DataBound(object sender, EventArgs e)
        {
            Session["rolNombre"] = this.rolNombre;

            
        }
       
    }
}
