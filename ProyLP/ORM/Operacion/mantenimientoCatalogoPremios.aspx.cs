using EntitiesModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ORMOperacion
{
    public partial class mantenimientoCatalogoPremios : System.Web.UI.Page
    {
        #region Variables Estáticas
        /// <summary>
        /// variable donde se almacenaran las relaciones que una tabla tiene con otras
        /// </summary>
        private static List<catalogos_relaciones> lstRelaciones = null;
        private static List<proveedor_premios> lstProveedorPremio = new List<proveedor_premios>();
        private static List<marca_premio> lstMarcaPremio = new List<marca_premio>();
        private static List<categoria_premio> lstCategoriaPremio = new List<categoria_premio>();
        private static List<bodega> lstBodega = new List<bodega>();
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

            if (!IsPostBack)
            {
                Master.Menu = "Parametros";
                Master.Submenu = "Premios";

                lstRelaciones = null;
                //De acuerdo al nombre del catalogo se debe de filtrar las tablas hacia las cuales tiene relaciones
                using (EntitiesModel.EntitiesModel dbContext = new EntitiesModel.EntitiesModel())
                {
                    var relaciones = from r in dbContext.catalogos_relaciones
                                     where r.clave == "premio"
                                     select r;

                    if (relaciones != null)
                    {
                        lstRelaciones = relaciones.ToList<catalogos_relaciones>();
                    }
                }
            }
        }

        /// <summary>
        /// Asociar la fuente de datos con la tabla que se debe de presentar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridPremios_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                OAFuenteTablas.ContextTypeName = "EntitiesModel.EntitiesModel";
                //La fuente de datos deberá de adicionarse una "s" al final cuando la palabra no termina en s por la pluralización de los objetos
                OAFuenteTablas.ResourceSetName = "premios";
                OAFuenteTablas.EntityTypeName = "";
                OAFuenteTablas.Where = "fecha_baja == null";
                OAFuenteTablas.EnableUpdate = true;
                OAFuenteTablas.EnableInsert = true;
                OAFuenteTablas.DataBind();
                gridPremios.DataSource = OAFuenteTablas;
                gridPremios.AutoGenerateEditColumn = true;
                string[] keys = new string[1];
                //Como condición todas las tablas que se quieran tener con esta funcionalidad el campo de llave primaria se debe de llamar id
                keys[0] = "id";
                gridPremios.MasterTableView.DataKeyNames = keys;

                // gridMenu.DataSource = OAFuenteTablas;
                //gridMenu.DataBind();

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
        protected void gridPremios_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                valoresTablas = new Hashtable();
                //Establecerle la fecha actual al campo de fecha_alta ya que el usuario no lo va a ingresar.
                GridDateTimeColumnEditor editor = (e.Item as GridEditFormInsertItem).EditManager.GetColumnEditor("fecha_alta") as GridDateTimeColumnEditor;
                editor.Text = DateTime.Today.ToShortDateString();
                GridTextColumnEditor usuarioEditor = (e.Item as GridEditFormInsertItem).EditManager.GetColumnEditor("usuario_alta_id") as GridTextColumnEditor;
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

                HtmlInputFile inputFileSmall = (System.Web.UI.HtmlControls.HtmlInputFile)e.Item.FindControl("uploadFileSmall");
                HtmlInputFile inputFileLarge = (System.Web.UI.HtmlControls.HtmlInputFile)e.Item.FindControl("uploadFileLarge");

                string pathToSave = getPathPremios();
                if (inputFileSmall.PostedFile.ContentLength > 0)
                {
                    string fileExt = System.IO.Path.GetExtension(inputFileSmall.Value);
                    string ImagePathSmall = "/images/premios/small/";
                    inputFileSmall.PostedFile.SaveAs(pathToSave + ImagePathSmall + inputFileSmall.Value);
                    valoresTablas.Add("url_imagen_small", "images\\premios\\small\\" + ((System.Web.UI.HtmlControls.HtmlInputFile)e.Item.FindControl("uploadFileSmall")).Value);
                }

                if (inputFileLarge.PostedFile.ContentLength > 0)
                {
                    string fileExt = System.IO.Path.GetExtension(inputFileLarge.Value);
                    string ImagePathLarge = "/images/premios/large/";
                    inputFileLarge.PostedFile.SaveAs(pathToSave + ImagePathLarge + inputFileLarge.Value);
                    valoresTablas.Add("url_imagen_large", "images\\premios\\large\\" + ((System.Web.UI.HtmlControls.HtmlInputFile)e.Item.FindControl("uploadFileLarge")).Value);
                }

                //valoresTablas.Add("precio", ((RadNumericTextBox)e.Item.FindControl("txtPrecio")).Value);
                //valoresTablas.Add("valor_envio", ((RadNumericTextBox)e.Item.FindControl("txtEnvio")).Value);
                //valoresTablas.Add("valor_seguro", ((RadNumericTextBox)e.Item.FindControl("txtSeguro")).Value);
                //valoresTablas.Add("valor_affa", ((RadNumericTextBox)e.Item.FindControl("txtAFFA")).Value);
                //valoresTablas.Add("costo", ((RadNumericTextBox)e.Item.FindControl("txtCosto")).Value);

                //Se rellena el grid para que dispare el evento de inserción del OpenAccessLinq
                HttpPostedFile filePosted = Request.Files["uploadFile"];
                gridPremios.DataSource = null;
                gridPremios.Rebind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('Error al insertar: " + Server.HtmlEncode(ex.Message) + " ');", true);
            }
        }

        /// <summary>
        /// Este evento se ejecuta cuando se está bindeando los datos de la tabla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridPremios_ItemDataBound(object sender, GridItemEventArgs e)
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
                    GridEditableItem editForm = (GridEditableItem)e.Item;
                    if (lstRelaciones != null)
                    {
                        foreach (catalogos_relaciones relacion in lstRelaciones)
                        {
                            string valor = DataBinder.Eval(editForm.DataItem, relacion.descripcion).ToString();
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
                        ((ImageButton)itemForm.Cells[2].Controls[0]).Visible = false;
                        ((ImageButton)itemForm.Cells[3].Controls[0]).Visible = false;
                    }

                    Image IMG = (Image)itemForm.FindControl("imagenSmall");
                    string imagen = DataBinder.Eval(itemForm.DataItem, "url_imagen_small").ToString();
                    IMG.ImageUrl = ConfigurationManager.AppSettings["estilos"] + "/" + imagen;

                    HyperLink HL = (HyperLink)itemForm.FindControl("hlName");
                    string link = DataBinder.Eval(itemForm.DataItem, "url_imagen_large").ToString();
                    HL.NavigateUrl = ConfigurationManager.AppSettings["estilos"] + "/" + link;
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
        protected void gridPremios_ItemCommand(object sender, GridCommandEventArgs e)
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

                    HtmlInputFile inputFileSmall = (System.Web.UI.HtmlControls.HtmlInputFile)e.Item.FindControl("uploadFileSmallEdit");
                    HtmlInputFile inputFileLarge = (System.Web.UI.HtmlControls.HtmlInputFile)e.Item.FindControl("uploadFileLargeEdit");
                    string pathToSave = getPathPremios();
                    if (inputFileSmall.PostedFile.ContentLength > 0)
                    {
                        string fileExt = System.IO.Path.GetExtension(inputFileSmall.Value);
                        string ImagePathSmall = "images\\Portal\\catalogo\\premios\\";
                        inputFileSmall.PostedFile.SaveAs(pathToSave + ImagePathSmall + inputFileSmall.Value);
                        valoresTablas.Add("url_imagen_small", ImagePathSmall + ((System.Web.UI.HtmlControls.HtmlInputFile)e.Item.FindControl("uploadFileSmallEdit")).Value);
                    }
                    else
                    {
                        Label lblImagenSmall = (Label)e.Item.FindControl("lblImagenSmall");
                        if (lblImagenSmall != null)
                        {
                            valoresTablas.Add("url_imagen_small", lblImagenSmall.Text);
                        }

                    }

                    if (inputFileLarge.PostedFile.ContentLength > 0)
                    {
                        string fileExt = System.IO.Path.GetExtension(inputFileLarge.Value);
                        string ImagePathLarge = "images\\Portal\\catalogo\\premios\\";
                        inputFileLarge.PostedFile.SaveAs(pathToSave + ImagePathLarge + inputFileLarge.Value);
                        valoresTablas.Add("url_imagen_large", ImagePathLarge + ((System.Web.UI.HtmlControls.HtmlInputFile)e.Item.FindControl("uploadFileLargeEdit")).Value);
                    }
                    else
                    {
                        Label lblImagenLarge = (Label)e.Item.FindControl("lblImagenLarge");
                        if (lblImagenLarge != null)
                        {
                            valoresTablas.Add("url_imagen_large", lblImagenLarge.Text);
                        }

                    }

                    //Se rebindea el grid para que dispare el evento de actualización del OpenAccessLinq
                    gridPremios.Rebind();
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
                                    "UPDATE premio SET usuario_baja_id = @usuario, fecha_baja=getdate() WHERE id = @ID";

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
        protected void gridPremios_ItemCreated(object sender, GridItemEventArgs e)
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
                        case "System.Double":
                            aux = Convert.ToDouble(tabla[prop.Name].ToString());
                            break;
                        case "System.Decimal":
                            aux = Convert.ToDecimal(tabla[prop.Name].ToString());
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
                                    case "System.Double":
                                        aux = Convert.ToDouble(tabla[prop.Name].ToString());
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

        public string getPathPremios()
        {
            string path = Server.MapPath("");
            string Imagepath = path.Replace("OperacionTest", "");
            Console.WriteLine(Imagepath);
            return Imagepath;
        }

        public string getPathPremiosLarge()
        {
            string path = Server.MapPath("").Replace("ORM", "Styles");
            string Imagepath = path.Replace("Operacion", "images");
            return Imagepath + "\\Portal\\catalogo\\premios-large";
        }
        #endregion

        protected void btnImportarPremios_Click(object sender, EventArgs e)
        {
            fileExcel.PostedFile.SaveAs(Server.MapPath(fileExcel.PostedFile.FileName));
            DataSet ds = new DataSet();

            ds = fImport(Server.MapPath(fileExcel.PostedFile.FileName), System.IO.Path.GetExtension(fileExcel.Value));
            string resultado = ValidarExcel(ds);
            if (resultado == "OK")
            {
                //Proceder con la carga
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    premio premio = new premio();
                    premio.clave = dr["No"].ToString();
                    premio.programa = dr["programa"].ToString();
                    premio.sku = dr["SKU"].ToString();
                    premio.descripcion = dr["Nombre Premio"].ToString();
                    premio.descripcion_larga = dr["Descripción"].ToString();
                    premio.precio = Convert.ToDouble(dr["Precio Compra"]);
                    premio.valor_envio = Convert.ToDouble(dr["Envío"]);
                    //El calculo del valor del seguro es precio*0.0125
                    premio.valor_seguro = premio.precio * 0.0125;//Convert.ToDouble(dr["Seguro"]);
                    premio.valor_affa = Convert.ToDouble(dr["A FF A"]);
                    //El calculo del valor del costo es la suma de todos los valores anteriores
                    premio.costo = premio.precio + premio.valor_envio + premio.valor_seguro + premio.valor_affa; //Convert.ToDouble(dr["Total Costo"]);
                    premio.porcentaje_utilidad = Convert.ToDouble(dr["% Utilidad"]);
                    //El calculo del valor de la utilidad es el total del costo por el porentaje de utilidad 
                    premio.valor_utilidad = premio.costo * premio.porcentaje_utilidad; //Convert.ToDouble(dr["Utilidad"]);
                    //El calculo del precio de ventas es suma de utilidad con costo total 
                    premio.precio_venta = premio.costo + premio.valor_utilidad; //Convert.ToDouble(dr["Precio Venta"]);
                    //El calculo del iva es el precio de venta * 0.16 
                    premio.iva = premio.precio_venta * 0.16;//Convert.ToDouble(dr["IVA"]);
                    //El calculo del iva es el precio de venta + iva
                    premio.precio_total = premio.iva + premio.precio_venta;//Convert.ToDouble(dr["Total"]);
                    premio.puntos = Convert.ToInt32(dr["Puntos"]);
                    premio.url_imagen_small = dr["Ruta Imagen Small"].ToString();
                    premio.url_imagen_large = dr["Ruta Imgen Large"].ToString();
                    premio.comentario = dr["Comentario"].ToString();
                    premio.dias_de_entrega = Convert.ToDouble(dr["Días de Entrega"]);
                    premio.fecha_inicio_vigencia = Convert.ToDateTime(dr["Fecha Inicio de Vigencia"]);
                    premio.fecha_fin_vigencia = Convert.ToDateTime(dr["Fecha Fin de Vigencia"]);
                    premio.notificar_canje = dr["Comentario"].ToString();
                    premio.fecha_alta = DateTime.Now;
                    premio.usuario_alta_id = new Guid(Membership.GetUser().ProviderUserKey.ToString());
                    premio.proveedor_premios_id = lstProveedorPremio.Find(item => item.descripcion.ToLower() == dr["proveedor"].ToString().ToLower()).id;
                    premio.marca_premios_id = lstMarcaPremio.Find(item => item.descripcion.ToLower() == dr["marca"].ToString().ToLower()).id;
                    premio.categoria_premio_id = lstCategoriaPremio.Find(item => item.descripcion.ToLower() == dr["categoría"].ToString().ToLower()).id;
                    premio.bodega_id = lstBodega.Find(item => item.descripcion.ToLower() == dr["bodega"].ToString().ToLower()).id;


                    using (EntitiesModel.EntitiesModel dbContext = new EntitiesModel.EntitiesModel())
                    {

                        dbContext.ContextOptions.EnableDataSynchronization = true;
                        dbContext.Add(premio);
                        dbContext.SaveChanges();
                    }

                }

                gridPremios.Rebind();
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('Se insertaron correctamente los premios.');</script>");

            }
            else
            {
                //Informar que información no es correcta
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('" + resultado + "');</script>");
            }
            //
        }

        /// <summary>
        /// Método para importar el archivo de excel a un dataset
        /// </summary>
        /// <param name="sPath"></param>
        /// <param name="sExt"></param>
        /// <returns></returns>
        public static DataSet fImport(string sPath, string sExt)
        {
            string sCn = "";
            if (sExt == ".xls")
            {
                sCn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='{0}';" +
                    "Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"", sPath);
            }
            else if (sExt == ".xlsx")
            {
                sCn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}';" +
                    "Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"", sPath);
            }

            //Obtener nombre de la hoja de Excel
            System.Data.OleDb.OleDbConnection objExcel = new System.Data.OleDb.OleDbConnection(sCn);
            objExcel.Open();

            DataTable dt = objExcel.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            string sSheetName = dt.Rows[0]["Table_Name"].ToString();
            objExcel.Close();

            //llenar el dataset
            DataSet ds = new DataSet();

            string strQuery = "SELECT * FROM [" + sSheetName + "]";
            System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(strQuery, sCn);
            da.Fill(ds);//llenar dataset con datos de Excel
            return ds;
        }

        /// <summary>
        /// Método para revisar que la información de los catálogos del excel están en los catálogos de la base de datos    
        /// </summary>
        /// <param name="dsInformacion"></param>
        /// <returns></returns>
        public static string ValidarExcel(DataSet dsInformacion)
        {


            using (EntitiesModel.EntitiesModel dbContext = new EntitiesModel.EntitiesModel())
            {
                var relaciones = from r in dbContext.proveedor_premios
                                 where r.fecha_baja == null
                                 select r;

                if (relaciones != null)
                {
                    lstProveedorPremio = relaciones.ToList<proveedor_premios>();
                }

                var relaciones1 = from r in dbContext.marca_premios
                                  where r.fecha_baja == null
                                  select r;

                if (relaciones1 != null)
                {
                    lstMarcaPremio = relaciones1.ToList<marca_premio>();
                }

                var relaciones2 = from r in dbContext.categoria_premios
                                  where r.fecha_baja == null
                                  select r;

                if (relaciones2 != null)
                {
                    lstCategoriaPremio = relaciones2.ToList<categoria_premio>();
                }

                var relaciones3 = from r in dbContext.bodegas
                                  where r.fecha_baja == null
                                  select r;

                if (relaciones3 != null)
                {
                    lstBodega = relaciones3.ToList<bodega>();
                }

            }

            string mensaje = "OK";
            string proveedores = "";
            string marcas = "";
            string categoria = "";
            string bodega = "";

            foreach (DataRow dr in dsInformacion.Tables[0].Rows)
            {

                //Validar que el proveedor exista
                if (!proveedores.Contains(dr["proveedor"].ToString() + ","))
                {
                    if (lstProveedorPremio.Find(item => item.descripcion.ToLower() == dr["proveedor"].ToString().ToLower()) == null)
                    {
                        proveedores += dr["proveedor"].ToString() + ",";
                    }
                }

                //Validar que la marca exista
                if (!marcas.Contains(dr["marca"].ToString() + ","))
                {
                    if (lstMarcaPremio.Find(item => item.descripcion.ToLower() == dr["marca"].ToString().ToLower()) == null)
                    {
                        marcas += dr["marca"].ToString() + ",";
                    }
                }

                //Validar que la categoria exista
                if (!categoria.Contains(dr["categoría"].ToString() + ","))
                {
                    if (lstCategoriaPremio.Find(item => item.descripcion.ToLower() == dr["categoría"].ToString().ToLower()) == null)
                    {
                        categoria += dr["categoría"].ToString() + ",";
                    }
                }

                //Validar que la bodega exista
                if (!bodega.Contains(dr["bodega"].ToString() + ","))
                {
                    if (lstBodega.Find(item => item.descripcion.ToLower() == dr["bodega"].ToString().ToLower()) == null)
                    {
                        bodega += dr["bodega"].ToString() + ",";

                    }
                }

            }

            if (proveedores != string.Empty)
            {
                mensaje = "";
                proveedores = "-Lo(s) siguiente(s) proveedore(s) no están dados de alta: " + proveedores;
                mensaje += proveedores;
            }
            if (marcas != string.Empty)
            {
                mensaje = mensaje.Replace("OK", ""); ;
                marcas = @"\r\n-La(s) siguiente(s) marca(s) no están dados de alta: " + marcas;
                mensaje += marcas;
            }
            if (categoria != string.Empty)
            {
                mensaje = mensaje.Replace("OK", ""); ;
                categoria = @"\r\n-La(s) siguiente(s) categoría(s) no están dados de alta: " + categoria;
                mensaje += categoria;
            }
            if (bodega != string.Empty)
            {
                mensaje = mensaje.Replace("OK", ""); ;
                bodega = @"\r\n-La(s) siguiente(s) bodega(s) no están dados de alta: " + bodega;
                mensaje += bodega;
            }

            return mensaje;
        }
    }
}