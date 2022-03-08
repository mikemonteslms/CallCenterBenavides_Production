using Negocio;
using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using CallcenterNUevo.Utilerias;
using System.Text;

namespace CallcenterNUevo.AdminC
{
    public partial class Asignacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(btnContinuaAsignacion);

            txtBuscar.Attributes.Add("placeholder", "Buscador:");

            rdcFInicioCanje.MinDate = DateTime.Now;
            rdcFInicioCanje.MaxDate = new DateTime(DateTime.Now.AddYears(1).Year, 12, 31);
            rdcFFinCanje.MinDate = DateTime.Now.AddDays(1);
            rdcFFinCanje.MaxDate = new DateTime(DateTime.Now.AddYears(1).Year, 12, 31);

            if (!Page.IsPostBack)
            {
                pnlResultados.Visible = false;
                pnlSinInfo.Visible = false;
                pnlDatos.Visible = false;
                pnlAsignacion.Visible = false;
                trTarjeta.Visible = false;
                trArchivo.Visible = false;
            }

            //Crea archivo excel en caso de que al intentar asignar N tarjetas a un cupón estas se encuentren ya asociadas
            //a dicho cupón, con la finalidad de que el usuario tenga el listado de las tarjetas ya asociadas y sean eliminadas de su listado de carga
            if (Session["lstResultado"] != null)
            {
                string CuponAsociado = Session["CuponAsociado"].ToString();
                List<ModTarjetasResult> lstTarjetasAsociadasCupon = new List<ModTarjetasResult>();
                lstTarjetasAsociadasCupon = (List<ModTarjetasResult>)Session["lstResultado"];
                DataTable dt = new DataTable();
                dt = ProcesarInformacion(lstTarjetasAsociadasCupon);
                ExportarExcel Crear = new ExportarExcel();
                string procesoExportacion = Crear.ExportarCVS(dt);
                string filename = "TarjetasAsignadasACupon_" + CuponAsociado;

                Session.Contents.Remove("lstResultado");
                Session.Remove("lstResultado");
                Session.Contents.Remove("CuponAsociado");
                Session.Remove("CuponAsociado");

                IniciarDescarga(procesoExportacion, "TarjetasAsignadasACupon_" + CuponAsociado);
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Asignacion", "btnBuscar_Click", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
            rgResultado.DataSource = Negocio.Cupones.BuscarCupon(txtBuscar.Text);
            rgResultado.DataBind();
            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Asignacion", "btnBuscar_Click", "Fin de Consulta", this.User.Identity.Name.ToString(), null);


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
                    //lblDMensaje.Text = tblDatos.Rows[0]["Mensaje"].ToString();
                    txtDMensaje.Text = tblDatos.Rows[0]["Mensaje"].ToString();
                    lblDNumAsignacion.Text = tblDatos.Rows[0]["NumAsignaciones"].ToString();
                    lblDEstatus.Text = (tblDatos.Rows[0]["Estatus"].ToString() == "1") ? "Asignado" : "Activo sin asignar";
                    //lblDSucursal.Text = (tblDatos.Rows[0]["Sucursal"].ToString() == "0") ? "Todas" : "";
                    lblDSucursal.Text = tblDatos.Rows[0]["Sucursal"].ToString();
                    lblDUso.Text = (tblDatos.Rows[0]["UsoUnico"].ToString().ToLower() == "false") ? "Ilimitada" : "De un solo uso";
                    //lblDEstatus.Text = tblDatos.Rows[0]["Estatus"].ToString();
                    //lblDSucursal.Text = tblDatos.Rows[0]["Sucursal"].ToString();
                    //lblDUso.Text = tblDatos.Rows[0]["UsoUnico"].ToString();
                    lblFechaSolicitud.Text = Convert.ToDateTime(tblDatos.Rows[0]["FechaSolicitud"]).ToShortDateString();
                    lblDFechaFin.Text = Convert.ToDateTime(tblDatos.Rows[0]["FechaFin"]).ToShortDateString();
                    lblPromoTipoTrigger.Text = tblDatos.Rows[0]["MensajePOS"].ToString();

                    if (string.IsNullOrWhiteSpace(tblDatos.Rows[0]["Identificador"].ToString()))
                    {
                        hFldIdentificador.Value = "C9FED9CC-999A-99AA-AAA9-B999AC999999";
                    }
                    else {
                        hFldIdentificador.Value = tblDatos.Rows[0]["Identificador"].ToString();
                    }
                   

                    if (tblDatos.Rows[0]["Id_Tipocupon"].ToString() == "1")
                    {
                        lblTipoCupon.Text = tblDatos.Rows[0]["TipoCupon"].ToString();
                        lblEtiquetaDescuento.Visible = false;
                        lblDescuento.Visible = false;
                        lblsignoPorc.Visible = false;
                        lbletiquetacodint.Visible = false;
                        lblcodigointerno.Visible = false;
                    }
                    if (tblDatos.Rows[0]["Id_Tipocupon"].ToString() == "2")
                    {
                        lblTipoCupon.Text = tblDatos.Rows[0]["TipoCupon"].ToString();
                        lblEtiquetaDescuento.Visible = true;
                        lblDescuento.Text = tblDatos.Rows[0]["Descuento"].ToString();
                        lblDescuento.Visible = true;
                        lblsignoPorc.Visible = true;
                        lbletiquetacodint.Visible = true;
                        lblcodigointerno.Text = tblDatos.Rows[0]["codigointerno"].ToString();
                        lblcodigointerno.Visible = true;
                    }
                    if (tblDatos.Rows[0]["Id_Tipocupon"].ToString() == "3")
                    {
                        lblTipoCupon.Text = tblDatos.Rows[0]["TipoCupon"].ToString();
                        lblTipoPromoTrigger.Visible = true;
                        lblPromoTipoTrigger.Text = tblDatos.Rows[0]["MensajePOS"].ToString();
                        lblPromoTipoTrigger.Visible = true;
                    }
                    btnAutoriza.Visible = true;
                    btnCanelar.Visible = true;
                }
                pnlBusqueda.Visible = false;
                pnlDatos.Visible = true;
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
                //RegularExpressionValidator1.Enabled = true;
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
                //RegularExpressionValidator1.Enabled = false; 
            }
        }

        protected void btnContinuaAsignacion_Click1(object sender, EventArgs e)
        {
            //string entro = "";
            if (rdcFInicioCanje.SelectedDate > Convert.ToDateTime(lblDFechaFin.Text) || rdcFFinCanje.SelectedDate > Convert.ToDateTime(lblDFechaFin.Text))
            {
                lblErrorFecha.Text = "Seleccione una fecha de inicio o fin del canje menor a la fecha fin del cupón";
                lblErrorFecha.Visible = true;
                return;
            }
            else
            {
                if (rblTipo.SelectedValue != "1")
                {
                    try
                    {
                        if (RadAsyncUpload1.UploadedFiles.Count == 0)
                        {
                            RadAsyncUpload1.Focus();
                            ScriptManager.RegisterStartupScript(pnlAsignacion, pnlAsignacion.GetType(), "alert", "alert('Debé seleccionar archivo de excel.')", true);
                            return;
                        }

                        RadAsyncUpload1.UploadedFiles[0].SaveAs(Server.MapPath("~/UploadedFiles/Procesados/" + RadAsyncUpload1.UploadedFiles[0].FileName), true);
                        string ruta = "";
                        ruta = Server.MapPath("~/UploadedFiles/Procesados/" + System.IO.Path.GetFileName(RadAsyncUpload1.UploadedFiles[0].FileName));
                        Session["Ruta"] = ruta;
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + ruta + "');", true);
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Debe seleccionar un archivo')", true);
                    }
                }
                lblErrorFecha.Text = "";
                lblErrorFecha.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "$(\"#openModal\").fadeIn('slow');", true);
            }

        }

        protected void btnCancela_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "$(\"#openModal\").fadeOut('slow');", true);
            //pnlResultados.Visible = true;
            //pnlDatos.Visible = false;
            //pnlBusqueda.Visible = true;
            //pnlAsignacion.Visible = false;
            //pnlSinInfo.Visible = false;
        }

        protected void btnConfirmaContinua_Click(object sender, EventArgs e)
        {
            Entidades.Result resultado = new Entidades.Result();
            List<ModCuponCargaTarjetasMasivasResult> lstResultado = new List<ModCuponCargaTarjetasMasivasResult>();

            try
            {
                //Por Tarjeta
                if (rblTipo.SelectedValue == "1")
                {
                    if (txtTarjeta.Text.Length < 11)
                    {
                        txtTarjeta.Text = "";
                        txtTarjeta.Focus();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El número de tarjeta proporcionada no es valida, asegurese de ingresar los 11 digitos de su tarjeta.');", true);
                        return;
                    }

                    resultado = Cupones.AsignarCupon(txtTarjeta.Text, hdnId.Value, rdcFInicioCanje.SelectedDate, rdcFFinCanje.SelectedDate, lblDSucursal.Text, lblDUso.Text, Convert.ToInt32(lblDNumAsignacion.Text), hFldIdentificador.Value, HttpContext.Current.User.Identity.Name);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resultado.Error + "');", true);
                    if (resultado.ErrorCode == "ACP002")
                    {
                        Response.AddHeader("REFRESH", "2;URL=Asignacion.aspx");
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resultado.Error + "');", true);
                        return;
                    }
                }//Carga Masiva por archivo Excel
                else if (rblTipo.SelectedValue == "2")
                {
                    if (Session["Ruta"] != null)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Ruta con datos')", true);
                        OleDbConnection Connexion = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Session["Ruta"].ToString() + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text'");
                        //Connexion.Open();
                        OleDbCommand comando = new OleDbCommand("Select * from [" + GetExcelSheetNames(Session["Ruta"].ToString())[0] + "]", Connexion);
                        try
                        {
                            ////OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                            ////OleDbCommand oledbcmd = new OleDbCommand("Select * from [Cupones$]", Connexion);
                            System.Data.DataTable tblDatos = new System.Data.DataTable();
                            var da = new OleDbDataAdapter();
                            var ds = new DataSet();
                            Connexion.Open();
                            comando.CommandTimeout = Convert.ToInt32(240);
                            da.SelectCommand = comando;
                            da.Fill(ds);

                            SqlBulkCopy bulkcopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                            bulkcopy.DestinationTableName = "tblTempTarjetasCupones";

                            bulkcopy.WriteToServer(ds.Tables[0]);
                            Connexion.Close();
                            lstResultado = Cupones.CargaCuponesM(hdnId.Value, rdcFInicioCanje.SelectedDate, rdcFFinCanje.SelectedDate, lblDSucursal.Text, lblDUso.Text, hFldIdentificador.Value, HttpContext.Current.User.Identity.Name);

                            if (lstResultado.Count > 1)
                            {
                                //Crea variable sde session para que al hacer postback se cuente con la información generada y 
                                //se genere el archivo de excel con el listado de tarjetas ya asociadas al cupón 
                                Session.Add("lstResultado", lstResultado);
                                Session.Add("CuponAsociado", lblCupon2.Text);
                            }

                            lblTot.Text = lstResultado[0].TotalTarjetas.ToString();
                            lblTotAsig.Text = lstResultado[0].TotalTarjetasAsignadas.ToString();
                            lblTotconCupon.Text = lstResultado[0].TotalTarjetasYaCuentanconCupon.ToString();

                            tblMsgRespuesta.Visible = true;
                            mpeMsgRespuesta.Show();
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + strHTML + "');", true);
                            //Response.AddHeader("REFRESH", "2;URL=Asignacion.aspx");

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
                            ScriptManager.RegisterStartupScript(pnlAsignacion, pnlAsignacion.GetType(), "alert", "alert('Ocurrio un error interno en la asignacion de cupones, contacte al Administrador.')", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(pnlAsignacion, pnlAsignacion.GetType(), "alert", "alert('Seleccione una opción para continuar.')", true);
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminC.Asignacion", "btnConfirmaContinuaClick", "AsignaCupon()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                ScriptManager.RegisterStartupScript(pnlAsignacion, pnlAsignacion.GetType(), "alert", "alert('Ocurrio un error interno al intentar Asignar cupón, contacte al administrador.')", true);
            }
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

        private void IniciarDescarga(string secuencia, string filename)
        {
            try
            {
                filename = filename.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u");
                string nombreDocumento = string.Format("{0}_{1}{2}{3}.{4}", filename, DateTime.Now.Day.ToString("00"), DateTime.Now.Month.ToString("00"), DateTime.Now.Year.ToString(), "xls");

                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel"; Response.Charset = "UTF-8";
                //this.EnableViewState = false;
                Response.AddHeader("Content-Disposition", "attachment;filename=" + nombreDocumento);
                Response.Charset = "UTF-8";
                Response.ContentEncoding = Encoding.Default;
                Response.Write(secuencia.ToString());
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Error: " + ex.Message + ");", true);
            }
        }
        private DataTable EstructuraDT()
        {
            DataTable medidaTabla = new DataTable();

            medidaTabla.Columns.Add("Tarjeta", typeof(string));


            return medidaTabla;
        }
        private DataTable ProcesarInformacion(List<ModTarjetasResult> lstResultado)
        {
            //Construcción de archivo con listado de tarjetas
            DataTable dt = new DataTable();
            DataRow dr;

            dt = EstructuraDT();
            foreach (ModTarjetasResult campos in lstResultado)
            {
                dr = dt.NewRow();
                dr[0] = campos.Tarjeta;

                dt.Rows.Add(dr);
            }

            return dt;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Asignacion.aspx");
        }
    }
}