using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Collections;
using System.Reflection;
using System.Data;
using System.Dynamic;
using Telerik.OpenAccess;
using System.Data.Common;
using Telerik.OpenAccess.Data.Common;
using EntitiesModel;
using System.Web.Security;

namespace ORMOperacion
{
    public partial class mantenimientoCatalogos : System.Web.UI.Page
    {
        #region Variables Estáticas
        /// <summary>
        /// variable donde se almacenaran las relaciones que una tabla tiene con otras
        /// </summary>
        private static List<catalogos_relaciones> lstRelaciones = null;
        /// <summary>
        /// Variable donde se almacenarán los datos que se van a insertar o actualizar.
        /// </summary>
        private static Hashtable valoresTablas = null;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
        }

        #region Eventos del Grid
        /// <summary>
        /// Asociar la fuente de datos con la tabla que se debe de presentar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridResultados_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (rcbCatalogosLealtad.SelectedValue != "")
                {
                    MembershipUser u = Membership.GetUser(Context.User.Identity.Name);
                    csDataBase programa = new csDataBase();
                    string programasids = "";
                    programa.Query = "SELECT DISTINCT d.programa_id [ID] FROM distribuidor_aspnet_User dau INNER JOIN distribuidor d ON dau.distribuidor_id = d.id WHERE UserId = '" +  u.ProviderUserKey.ToString() + "'";
                    programa.EsStoreProcedure = false;

                    foreach (DataRow dr in programa.dtConsulta().Rows)
                    {
                        programasids += "programa_id = " + dr["id"].ToString() + " || ";
                    }

                    programasids = programasids.Substring(0, programasids.Length - 4);

                    OAFuenteTablas.ContextTypeName = "EntitiesModel.EntitiesModel";
                    //La fuente de datos deberá de adicionarse una "s" al final cuando la palabra no termina en s por la pluralización de los objetos
                    OAFuenteTablas.ResourceSetName = rcbCatalogosLealtad.SelectedValue.Substring(rcbCatalogosLealtad.SelectedValue.Length - 1, 1).ToLower() == "s" ? rcbCatalogosLealtad.SelectedValue : rcbCatalogosLealtad.SelectedValue + "s"; ;
                    //OAFuenteTablas.Select = "Select * from " + rcbCatalogosLealtad.SelectedValue.Substring(rcbCatalogosLealtad.SelectedValue.Length - 1, 1).ToLower() == "s" ? rcbCatalogosLealtad.SelectedValue : rcbCatalogosLealtad.SelectedValue + "s";
                    OAFuenteTablas.EntityTypeName = "";
                    OAFuenteTablas.EnableUpdate = true;
                    OAFuenteTablas.EnableInsert = true;
                    OAFuenteTablas.Where = programasids;
                    OAFuenteTablas.DataBind();
                    gridResultados.DataSource = OAFuenteTablas;
                    gridResultados.AutoGenerateEditColumn = true;
                    string[] keys = new string[1];
                    //Como condición todas las tablas que se quieran tener con esta funcionalidad el campo de llave primaria se debe de llamar id
                    keys[0] = "id";
                    gridResultados.MasterTableView.DataKeyNames = keys;
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('Error al cargar los datos');</script>");
            }
        }

        /// <summary>
        /// Este evento se ejecuta una vez el usuario ingresó los datos a insertar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridResultados_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                valoresTablas = new Hashtable();
                //Establecerle la fecha actual al campo de fecha_alta ya que el usuario no lo va a ingresar.
                GridDateTimeColumnEditor editor = (e.Item as GridEditFormInsertItem).EditManager.GetColumnEditor("Fecha_alta") as GridDateTimeColumnEditor;
                editor.Text = DateTime.Today.ToShortDateString();
                GridTextColumnEditor usuarioEditor = (e.Item as GridEditFormInsertItem).EditManager.GetColumnEditor("Usuario_alta_id") as GridTextColumnEditor;
                //El valor "00000000-0000-0000-0000-000000000000" se debe de cambiar por el id del usuario que está logueado en la aplicación.
                usuarioEditor.Text = Membership.GetUser().ProviderUserKey.ToString(); //"00000000-0000-0000-0000-000000000000";
                if (lstRelaciones != null)
                {
                    //Por cada una de las relaciones que la tabla tenga hacia las otras tablas se debe de tomar el id seleccionado del combo y asignarselo a la columna que le corresponde
                    foreach (catalogos_relaciones relacion in lstRelaciones)
                    {
                        GridNumericColumnEditor objeto = (e.Item as GridEditFormInsertItem).EditManager.GetColumnEditor(relacion.descripcion) as GridNumericColumnEditor;
                        objeto.Text = ((RadComboBox)e.Item.FindControl("rcb" + relacion.descripcion_larga)).SelectedValue;
                    }
                }
                //Obtener los datos que se van a insertar porque cuando se haga el rebindeo del grid se perderán dichos datos
                e.Item.OwnerTableView.ExtractValuesFromItem(valoresTablas, (e.Item as GridEditFormInsertItem));
                //Se rebidea el grid para que dispare el evento de inserción del OpenAccessLinq
                gridResultados.Rebind();
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('Error al insertar el registro');</script>");
            }
        }

        /// <summary>
        /// Este evento se ejecuta cuando se está bindeando los datos de la tabla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridResultados_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                //  Cuando se oprima el botón de editar se deben de ocultar los campos que no se requieren el usuario los cambie directamente
                if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
                {
                    GridEditFormItem editform = (GridEditFormItem)e.Item;
                    editform["fecha_alta"].Parent.Visible = false;
                    editform["fecha_baja"].Parent.Visible = false;
                    editform["fecha_cambio"].Parent.Visible = false;
                    editform["usuario_cambio_id"].Parent.Visible = false;
                    editform["usuario_baja_id"].Parent.Visible = false;
                    editform["usuario_alta_id"].Parent.Visible = false;
                    editform["id"].Parent.Visible = false;                    
                }

                //Cuando se carguen los campos para editar la información, aquellos que son combos deberán dejar seleccionado el valor que trae el registro.
                if ((e.Item is GridEditableItem) && (e.Item.IsInEditMode))
                {
                    if (lstRelaciones != null)
                    {
                        foreach (catalogos_relaciones relacion in lstRelaciones)
                        {
                            GridEditableItem editForm = (GridEditableItem)e.Item;
                            string valor = DataBinder.Eval(editForm.DataItem, relacion.descripcion).ToString();
                            
                            //Si el campo de relación es programa llenar el combo solo con los valores del programa
                            if (relacion.descripcion_larga.ToLower() == "programa")
                            {
                                MembershipUser u = Membership.GetUser(Context.User.Identity.Name);
                                csDataBase Distribuidora = new csDataBase();
                                Distribuidora.Query = "SELECT p.id, p.descripcion FROM programa_aspnet_User pau, programa p WHERE pau.programa_id = p.id and UserId = '" + u.ProviderUserKey.ToString() + "'";
                                Distribuidora.EsStoreProcedure = false;
                                

                                ((RadComboBox)editForm[relacion.descripcion].FindControl("rcb" + relacion.descripcion_larga)).DataSource = Distribuidora.dtConsulta().DefaultView;
                                ((RadComboBox)editForm[relacion.descripcion].FindControl("rcb" + relacion.descripcion_larga)).DataTextField = "DESCRIPCION";
                                ((RadComboBox)editForm[relacion.descripcion].FindControl("rcb" + relacion.descripcion_larga)).DataValueField = "ID";
                                ((RadComboBox)editForm[relacion.descripcion].FindControl("rcb" + relacion.descripcion_larga)).DataBind();
                            }

                            ((RadComboBox)editForm[relacion.descripcion].FindControl("rcb" + relacion.descripcion_larga)).SelectedIndex = ((RadComboBox)editForm[relacion.descripcion].FindControl("rcb" + relacion.descripcion_larga)).FindItemIndexByValue(valor);


                        }
                    }
                }

                if (e.Item is GridDataItem)
                {
                    //Para los campos que son relaciones a otras tablas deberá de mostrar la descripción y no el ID. Para que esto funcione en el EntitiesModel debe de estar creada la asoación entre tablas
                    //por lo general es automática esta asociasión pero si no la hace se deberán de agregar a mano.
                    GridDataItem itemForm = (GridDataItem)e.Item;
                    if (lstRelaciones != null)
                    {
                        foreach (catalogos_relaciones relacion in lstRelaciones)
                        {
                            itemForm[relacion.descripcion].Text = DataBinder.Eval(itemForm.DataItem, relacion.descripcion_larga + ".descripcion").ToString();
                        }
                    }

                    //Cuando los registros ya estén dados de baja se deben de ocultar los botones de editar y eliminar.
                    if (itemForm["fecha_baja"].Text != "&nbsp;")
                    {
                        itemForm.ForeColor = System.Drawing.Color.Red;
                        itemForm.FindControl("AutoGeneratedDeleteButton").Visible = false;
                        itemForm.FindControl("AutoGeneratedEditButton").Visible = false;
                    }
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('Se presentó un error');</script>");
            }
        }

        /// <summary>
        /// Este evento se ejecuta una vez el usuario modificó los datos de un registro ya existente u oprimió el botón de eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridResultados_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                valoresTablas = new Hashtable();
                if (e.CommandName.ToLower() == "update")
                {
                    //Establecer en el grid cuando y quien está realizando el cambio
                    GridDateTimeColumnEditor fechaEditor = (e.Item as GridEditFormItem).EditManager.GetColumnEditor("Fecha_cambio") as GridDateTimeColumnEditor;
                    fechaEditor.Text = DateTime.Today.ToShortDateString();
                    GridTextColumnEditor usuarioEditor = (e.Item as GridEditFormItem).EditManager.GetColumnEditor("Usuario_cambio_id") as GridTextColumnEditor;
                    //El valor "00000000-0000-0000-0000-000000000000" se debe de cambiar por el id del usuario que está logueado en la aplicación.
                    usuarioEditor.Text = Membership.GetUser().ProviderUserKey.ToString(); //"00000000-0000-0000-0000-000000000000";

                    //También se deben de recorrer los combos para obtener el id ya que el bindeo es dinámico y el tipo de columna que genera es NumericColumn y no DropDownColumn
                    foreach (catalogos_relaciones relacion in lstRelaciones)
                    {
                        GridNumericColumnEditor objeto = (e.Item as GridEditFormItem).EditManager.GetColumnEditor(relacion.descripcion) as GridNumericColumnEditor;
                        objeto.Text = ((RadComboBox)e.Item.FindControl("rcb" + relacion.descripcion_larga)).SelectedValue;
                    }
                    //Obtener los datos que se van a actualizar porque cuando se haga el rebindeo del grid se perderán dichos datos
                    e.Item.OwnerTableView.ExtractValuesFromItem(valoresTablas, (e.Item as GridEditFormItem));

                    //Se rebindea el grid para que dispare el evento de actualización del OpenAccessLinq
                    gridResultados.Rebind();
                }
                if (e.CommandName.ToLower() == "delete")
                {
                    // 1. Crear una nueva instancia del OpenAccessContext generado
                    using (EntitiesModel.EntitiesModel dbContext = new EntitiesModel.EntitiesModel())
                    {
                        using (IDbConnection connection = dbContext.Connection)
                        {
                            // 2. Con la conexión crear un nuevo command
                            using (IDbCommand command = connection.CreateCommand())
                            {
                                // 3. Generar la sentencia de actualización.
                                command.CommandText =
                                    "UPDATE " + rcbCatalogosLealtad.SelectedItem.Text + " SET usuario_baja_id = @usuario, fecha_baja=getdate() WHERE id = @ID";

                                // 4. Asociarle los parametros de usuario y fecha.
                                IDbDataParameter categoryName = command.CreateParameter();
                                categoryName.ParameterName = "@usuario";
                                //El valor "00000000-0000-0000-0000-000000000000" deberá ser reemplazado por la variable de usuario
                                categoryName.Value = Membership.GetUser().ProviderUserKey.ToString(); //"00000000-0000-0000-0000-000000000000";
                                command.Parameters.Add(categoryName);

                                IDbDataParameter categoryIdParam = command.CreateParameter();
                                categoryIdParam.ParameterName = "@ID";
                                categoryIdParam.Value = (e.Item as GridDataItem).GetDataKeyValue("id").ToString();
                                command.Parameters.Add(categoryIdParam);

                                // 5. Ejecutar la sentencia de actualización.
                                int rowsAffected = command.ExecuteNonQuery();

                                // 6. Realizar el commit de la información.
                                dbContext.SaveChanges();
                            }
                        }
                    }
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('Error al actualizar los datos');</script>");
            }
        }

        /// <summary>
        /// Este evento se ejecuta cuando se están asociando los registros al grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridResultados_ItemCreated(object sender, GridItemEventArgs e)
        {
            if ((e.Item is GridEditableItem) && (e.Item.IsInEditMode))
            {
                if (lstRelaciones != null)
                {
                    //Por cada uno de los registros que se tengan se deberá generar la relación a la tabla correspondiente
                    //Insertar un combo por cada una de las realciones
                    foreach (catalogos_relaciones relacion in lstRelaciones)
                    {
                        GridEditableItem editForm = (GridEditableItem)e.Item;
                        editForm[relacion.descripcion].Controls[0].Visible = false;
                        RadComboBox combo = new RadComboBox();
                        combo.ID = "rcb" + relacion.descripcion_larga;
                        combo.DataTextField = "Descripcion";
                        combo.DataValueField = "Id";

                        Telerik.OpenAccess.Web.OpenAccessLinqDataSource ds = new Telerik.OpenAccess.Web.OpenAccessLinqDataSource();
                        ds.ContextTypeName = "EntitiesModel.EntitiesModel";
                        ds.ResourceSetName = relacion.descripcion_larga.Substring(relacion.descripcion_larga.Length - 1, 1).ToLower() == "s" ? relacion.descripcion_larga : relacion.descripcion_larga + "s";
                        if (e.Item.GetType().FullName.Contains("GridEditFormInsertItem"))
                            ds.Where = "usuario_baja_id == null";
                        ds.EntityTypeName = "";
                        ds.ID = "ds" + relacion.descripcion_larga;
                        combo.DataSource = ds;

                        editForm[relacion.descripcion].Controls.Add(combo);
                    }
                }
            }
        }
        #endregion

        #region Eventos del OpenAccessLINQ
        /// <summary>
        /// Este evento se ejecuta cuando se está actualizando la información de un registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OAFuenteTablas_Updating(object sender, Telerik.OpenAccess.Web.OpenAccessLinqDataSourceUpdateEventArgs e)
        {
            //Asociar al objeto que se va a actualizar los valores correctos
            LlenarObjeto(e.NewObject, valoresTablas);
        }

        /// <summary>
        /// Este evento se ejecuta cuando se está insertando un nuevo registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OAFuenteTablas_Inserting(object sender, Telerik.OpenAccess.Web.OpenAccessLinqDataSourceInsertEventArgs e)
        {
            //Asociar al objeto que se va a insertar los valores correctos
            LlenarObjeto(e.NewObject, valoresTablas);
        }
        #endregion

        #region Eventos del combo
        /// <summary>
        /// Cuando se cambie la opción se deberá filtrar que relaciones se tienen para ese catalogo y cargar el grid con la tabla seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rcbCatalogosLealtad_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            lstRelaciones = null;
            //De acuerdo al nombre del catalogo se debe de filtrar las tablas hacia las cuales tiene relaciones
            using (EntitiesModel.EntitiesModel dbContext = new EntitiesModel.EntitiesModel())
            {
                var relaciones = from r in dbContext.catalogos_relaciones
                                 where r.clave == rcbCatalogosLealtad.SelectedItem.Text
                                 select r;

                if (relaciones != null)
                {
                    lstRelaciones = relaciones.ToList<catalogos_relaciones>();
                }
            }
            //Recargar el grid con los datos de la tabla ahora seleccionada
            gridResultados.Rebind();
        }
        #endregion

        #region Métodos privados
        /// <summary>
        /// Método para asignarle al objeto que está relacionado con la base de datos los valores que se van a insertar o actualizar.
        /// </summary>
        /// <param name="objeto">Que estructura se va a insertar o actualizar</param>
        /// <param name="tabla">Valores que deberá de tomar</param>
        private void LlenarObjeto(object objeto, Hashtable tabla)
        {
            Type tipo = objeto.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();
            foreach (PropertyInfo prop in propiedades)
            {
                object aux;
                aux = null;
                if (tabla[prop.Name] != null)
                {
                    switch (prop.PropertyType.FullName)
                    {
                        case "System.Guid":
                            aux = new Guid(tabla[prop.Name].ToString());
                            break;
                        case "System.Int32":
                            aux = Convert.ToInt32(tabla[prop.Name].ToString());
                            break;
                        case "System.Int64":
                            aux = Convert.ToInt64(tabla[prop.Name].ToString());
                            break;
                        case "System.DateTime":
                            aux = Convert.ToDateTime(tabla[prop.Name].ToString());
                            break;
                        case "System.String":
                            aux = tabla[prop.Name].ToString().ToUpper();
                            break;
                        default:
                            if (prop.PropertyType.FullName.Contains("System.Nullable"))
                            {
                                switch (Nullable.GetUnderlyingType(prop.PropertyType).FullName)
                                {
                                    case "System.Guid":
                                        aux = new Guid(tabla[prop.Name].ToString());
                                        break;
                                    case "System.Int32":
                                        aux = Convert.ToInt32(tabla[prop.Name].ToString());
                                        break;
                                    case "System.Int64":
                                        aux = Convert.ToInt64(tabla[prop.Name].ToString());
                                        break;
                                    case "System.DateTime":
                                        aux = Convert.ToDateTime(tabla[prop.Name].ToString());
                                        break;
                                    case "System.String":
                                        aux = tabla[prop.Name].ToString().ToUpper();
                                        break;
                                }
                            }
                            break;
                    }
                }
                //Excluir todas aquellas propiedades que trabajan como relación de otras tablas.
                if (!prop.PropertyType.FullName.Contains("System.Collections.Generic.IList"))
                    prop.SetValue(objeto, aux, null);
            }
        }
        #endregion

    }
}