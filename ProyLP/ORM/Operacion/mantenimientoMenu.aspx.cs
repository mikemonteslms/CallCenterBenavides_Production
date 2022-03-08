using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ORMOperacion
{
    public partial class mantenimientoMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación autenticación de la página
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                Master.Menu = "Control de acceso";
                Master.Submenu = "Menu";
            }

        }

        protected void gridMenu_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if( Membership.GetUser() != null)
                gridMenu.DataSource = CNegocio.csMenuNegocio.ConsultarMenu(0, Membership.GetUser().ProviderUserKey.ToString());
        }

        protected void gridMenu_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);

            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            CNegocio.csMenuNegocio.InsertaMenu(values["nombre"].ToString(), int.Parse(values["orden"].ToString()), Membership.GetUser().ProviderUserKey.ToString());
        }

        protected void gridMenu_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                //  Cuando se oprima el botón de editar se deben de ocultar los campos que no se requieren el usuario los cambie directamente
                if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
                {
                    GridEditFormItem editform = (GridEditFormItem)e.Item;
                    editform["id"].Parent.Visible = false;
                    editform["fecha_alta"].Parent.Visible = false;
                    editform["fecha_baja"].Parent.Visible = false;
                    editform["fecha_cambio"].Parent.Visible = false;
                    editform["usuario_cambio_id"].Parent.Visible = false;
                    editform["usuario_baja_id"].Parent.Visible = false;
                    editform["usuario_alta_id"].Parent.Visible = false;
                }

                if (e.Item is GridDataItem)
                {
                    GridDataItem itemForm = (GridDataItem)e.Item;
                    
                    //Cuando los registros ya estén dados de baja se deben de ocultar los botones de editar y eliminar.
                    if (itemForm["fecha_baja"].Text != "&nbsp;")
                    {
                        itemForm.ForeColor = System.Drawing.Color.Red;
                        ((ImageButton)itemForm.Cells[2].Controls[0]).Visible = false;
                        ((ImageButton)itemForm.Cells[3].Controls[0]).Visible = false;
                    }
                }


            }
            catch
            { 
            
            }
        }

      

        protected void gridMenu_UpdateCommand(object sender, GridCommandEventArgs e)
        {
           var editableItem = ((GridEditableItem)e.Item);

            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            CNegocio.csMenuNegocio.ModificaMenu("M", int.Parse(values["id"].ToString()), values["nombre"].ToString(), int.Parse(values["orden"].ToString()), Membership.GetUser().ProviderUserKey.ToString());
            
          
           
        }

        protected void gridMenu_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "delete")
            {
                CNegocio.csMenuNegocio.ModificaMenu("B", int.Parse((e.Item as GridDataItem).GetDataKeyValue("id").ToString()),"",0,  Membership.GetUser().ProviderUserKey.ToString());
               
            }
        }

       
    }
}