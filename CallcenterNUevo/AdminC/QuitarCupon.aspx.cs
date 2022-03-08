using Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallcenterNUevo.AdminC
{
    public partial class QuitarCupon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtBuscar.Attributes.Add("placeholder", "Buscador:");
            if (!Page.IsPostBack)
            {
                pnlResultados.Visible = false;
                pnlSinInfo.Visible = false;
                pnlDatos.Visible = false;
                pnlAsignacion.Visible = false;
                trTarjeta.Visible = false;
                trArchivo.Visible = false;
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.QuitarCupon", "btnBuscar_Click", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
            rgResultado.DataSource = Negocio.Cupones.BuscarCupon(txtBuscar.Text);
            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.QuitarCupon", "btnBuscar_Click", "Fin de Consulta", this.User.Identity.Name.ToString(), null);

            rgResultado.DataBind();

            if (rgResultado.MasterTableView.Items.Count > 0)
            {
                pnlResultados.Visible = true;
                pnlSinInfo.Visible = false;
            }
            else
            {
                pnlResultados.Visible = false;
                pnlSinInfo.Visible = true;
            }
        }
        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            pnlDatos.Visible = false;
            pnlBusqueda.Visible = true;
        }
        protected void btnAutoriza_Click(object sender, EventArgs e)
        {
            pnlAsignacion.Visible = true;
            pnlBusqueda.Visible = false;
            pnlDatos.Visible = false;
            pnlResultados.Visible = false;
            pnlSinInfo.Visible = false;
        }
        protected void btnContinuaQuitar_Click1(object sender, EventArgs e)
        {
            Entidades.Result resultado = new Entidades.Result();
            //Quitar cupón por tarjeta
            if (rblTipo.SelectedValue == "1")
            {
                try
                {
                    if (txtTarjeta.Text.Length < 11)
                    {
                        txtTarjeta.Text = "";
                        txtTarjeta.Focus();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El número de tarjeta proporcionada no es valida, asegurese de ingresar los 11 digitos de su tarjeta.');", true);
                        return;
                    }

                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.QuitarCupon", "btnContinuaQuitar ", "Inica QuitarCupon", this.User.Identity.Name.ToString(), null);
                    resultado = Cupones.QuitarCupon(lblCupon2.Text, txtTarjeta.Text, HttpContext.Current.User.Identity.Name);
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.QuitarCupon", "btnContinuaQuitar ", "Fin QuitarCupon", this.User.Identity.Name.ToString(), null);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resultado.Error + "');", true);
                    if (resultado.ErrorCode == "QCP002")
                    {
                        Response.AddHeader("REFRESH", "2;URL=QuitarCupon.aspx");
                        return;
                    }
                    else
                    {
                        txtTarjeta.Text = "";
                        txtTarjeta.Focus();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resultado.Error + "');", true);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.QuitarCupon", "btnContinuaQuitar ", "Ocurrio un error: Cupones.QuitarCupon", this.User.Identity.Name.ToString(), ex);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Ocurrio un error interno, contacte al administrador');", true);
                }
            }//Quitar cupón en forma masiva (archivo Excel)
            else if (rblTipo.SelectedValue == "2")
            {
                if (RadAsyncUpload1.UploadedFiles.Count == 0)
                {
                    RadAsyncUpload1.Focus();
                    ScriptManager.RegisterStartupScript(pnlAsignacion, pnlAsignacion.GetType(), "alert", "alert('Debé seleccionar archivo excel.')", true);
                    return;
                }

                RadAsyncUpload1.UploadedFiles[0].SaveAs(Server.MapPath("~/UploadedFiles/Procesados/" + RadAsyncUpload1.UploadedFiles[0].FileName), true);
                string ruta = "";
                ruta = Server.MapPath("~/UploadedFiles/Procesados/" + System.IO.Path.GetFileName(RadAsyncUpload1.UploadedFiles[0].FileName));

                if (ruta != null)
                {
                    OleDbConnection Connexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text'");
                    OleDbCommand comando = new OleDbCommand("Select * from [" + GetExcelSheetNames(ruta.ToString())[0] + "]", Connexion);
                    try
                    {
                        try
                        {
                            System.Data.DataTable tblDatos = new System.Data.DataTable();
                            var da = new OleDbDataAdapter();
                            var ds = new DataSet();
                            Connexion.Open();
                            comando.CommandTimeout = Convert.ToInt32(240);
                            da.SelectCommand = comando;
                            da.Fill(ds);

                            SqlBulkCopy bulkcopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                            bulkcopy.DestinationTableName = "tblTempTarjetasQuitarCupones";

                            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.QuitarCupon", "btnContinuaQuitar ", "Inica Bulkcopy: " + ds.Tables[0].Rows.Count.ToString() + " registros.", this.User.Identity.Name.ToString(), null);
                            bulkcopy.WriteToServer(ds.Tables[0]);
                            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.QuitarCupon", "btnContinuaQuitar ", "Fin Bulkcopy: " + ds.Tables[0].Rows.Count.ToString() + " registros.", this.User.Identity.Name.ToString(), null);

                            Connexion.Close();
                        }
                        catch (Exception ex)
                        {
                            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.QuitarCupon", "btnContinuaQuitar ", "Ocurrio un error: bulkcopy.WriteToServer", this.User.Identity.Name.ToString(), ex);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Ocurrio un error interno, contacte al administrador');", true);
                        }

                        try
                        {
                            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.QuitarCupon", "btnContinuaQuitar ", "Inica QuitarCuponMasivamente", this.User.Identity.Name.ToString(), null);
                            resultado = Cupones.QuitarCuponMasivamente(lblCupon2.Text, HttpContext.Current.User.Identity.Name);
                            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.QuitarCupon", "btnContinuaQuitar ", "Fin QuitarCuponMasivamente", this.User.Identity.Name.ToString(), null);
                        }
                        catch (Exception ex)
                        {
                            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.QuitarCupon", "btnContinuaQuitar ", "Ocurrio un error: Cupones.QuitarCuponMasivamente", this.User.Identity.Name.ToString(), ex);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Ocurrio un error interno, contacte al administrador');", true);
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resultado.Error + "');", true);

                        if (resultado.ErrorCode == "QCP002")
                            Response.AddHeader("REFRESH", "2;URL=QuitarCupon.aspx");
                    }
                    catch (Exception ex)
                    {
                        if (Connexion.State == System.Data.ConnectionState.Open)
                        {
                            Connexion.Close();
                            comando.Dispose();
                        }
                        if (rblTipo.SelectedValue == "2")
                        {
                            trTarjeta.Attributes.Clear();
                            trTarjeta.Attributes.Add("display", "none");

                            trArchivo.Attributes.Clear();
                            trArchivo.Attributes.Add("display", "");

                            trArchivo.Visible = true;
                            trTarjeta.Visible = false;
                        }
                        string MensajeE = ex.Message.Replace("'", "");
                        ScriptManager.RegisterStartupScript(pnlAsignacion, pnlAsignacion.GetType(), "alert", "alert('No se pudo cargar el archivo, verifica el formato.')", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(pnlAsignacion, pnlAsignacion.GetType(), "alert", "alert('Seleccione una opción para continuar.')", true);
            }
        }
        protected void btnCancela_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "$(\"#openModal\").fadeOut('slow');", true);
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "$(\"#openModal\").fadeOut('slow');", true);
            pnlBusqueda.Visible = true;
            pnlResultados.Visible = true;
            pnlSinInfo.Visible = false;
            pnlAsignacion.Visible = false;
            pnlDatos.Visible = false;
        }
        protected void rgResultado_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == "ASIGNAR")
            {
                using (System.Data.DataTable tblDatos = Cupones.ConsultarInfo(Convert.ToInt32(e.CommandArgument)))
                {
                    hdnId.Value = e.CommandArgument.ToString();
                    lblCupon.Text = tblDatos.Rows[0]["Cupon"].ToString();
                    lblCupon2.Text = tblDatos.Rows[0]["Cupon"].ToString();
                    lblDCupon.Text = tblDatos.Rows[0]["Cupon"].ToString();
                    lblDIdPromo.Text = tblDatos.Rows[0]["IdPromo"].ToString();
                    lblDNombrePromo.Text = tblDatos.Rows[0]["NombrePromocion"].ToString();
                    txtDMensaje.Text = tblDatos.Rows[0]["Mensaje"].ToString();
                    lblDNumAsignacion.Text = tblDatos.Rows[0]["NumAsignaciones"].ToString();
                    lblDEstatus.Text = (tblDatos.Rows[0]["Estatus"].ToString() == "1") ? "Asignado" : "Activo sin asignar";
                    lblDSucursal.Text = tblDatos.Rows[0]["Sucursal"].ToString();
                    lblDUso.Text = (tblDatos.Rows[0]["UsoUnico"].ToString().ToLower() == "false") ? "Ilimitada" : "De un solo uso";
                    lblFechaSolicitud.Text = Convert.ToDateTime(tblDatos.Rows[0]["FechaSolicitud"]).ToShortDateString();
                    lblDFechaFin.Text = Convert.ToDateTime(tblDatos.Rows[0]["FechaFin"]).ToShortDateString();
                    if (tblDatos.Rows[0]["Id_Tipocupon"].ToString() == "1")
                    {
                        lblTipoCupon.Text = "Normal";
                        lblEtiquetaDescuento.Visible = false;
                        lblDescuento.Visible = false;
                        lbletiquetacodint.Visible = false;
                        lblcodigointerno.Visible = false;
                    }
                    if (tblDatos.Rows[0]["Id_Tipocupon"].ToString() == "2")
                    {
                        lblTipoCupon.Text = "Descuento";
                        lblEtiquetaDescuento.Visible = true;
                        lblDescuento.Text = tblDatos.Rows[0]["Descuento"].ToString() + " %";
                        lblDescuento.Visible = true;
                        lbletiquetacodint.Visible = true;
                        lblcodigointerno.Text = tblDatos.Rows[0]["codigointerno"].ToString();
                        lblcodigointerno.Visible = true;
                    }


                    btnAutoriza.Visible = true;
                    btnCanelar.Visible = true;
                }
                pnlBusqueda.Visible = false;
                pnlDatos.Visible = true;
            }
        }
        protected void rblTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((RadioButtonList)sender).SelectedValue == "1")
            {
                trTarjeta.Attributes.Clear();
                trTarjeta.Attributes.Add("display", "");

                trArchivo.Attributes.Clear();
                trArchivo.Attributes.Add("display", "none");

                trArchivo.Visible = false;
                trTarjeta.Visible = true;
                //rqfvArchivo.Enabled = false;
                rqfvTarjeta.Enabled = true;
            }
            else
            {
                trTarjeta.Attributes.Clear();
                trTarjeta.Attributes.Add("display", "none");

                trArchivo.Attributes.Clear();
                trArchivo.Attributes.Add("display", "");

                trArchivo.Visible = true;
                trTarjeta.Visible = false;

                //rqfvArchivo.Enabled = true;
                rqfvTarjeta.Enabled = false;
            }
        }
        protected void rgResultado_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            rgResultado.DataSource = Negocio.Cupones.BuscarCupon(txtBuscar.Text);
            rgResultado.Rebind();

            if (rgResultado.MasterTableView.Items.Count > 0)
            {
                pnlResultados.Visible = true;
                pnlSinInfo.Visible = false;
            }
            else
            {
                pnlResultados.Visible = false;
                pnlSinInfo.Visible = true;
            }
        }
        private String[] GetExcelSheetNames(string excelFile)
        {
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;

            try
            {
                // Connection String. Change the excel file to the file you
                // will search.
                String connString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                    "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
                // Create connection object by using the preceding connection string.
                objConn = new OleDbConnection(connString);
                // Open connection with the database.
                objConn.Open();
                // Get the data table containg the schema guid.
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null)
                {
                    return null;
                }

                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }

                // Loop through all of the sheets if you want too...
                for (int j = 0; j < excelSheets.Length; j++)
                {
                    // Query each excel sheet.
                }

                return excelSheets;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
            finally
            {
                // Clean up.
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }
    }
}