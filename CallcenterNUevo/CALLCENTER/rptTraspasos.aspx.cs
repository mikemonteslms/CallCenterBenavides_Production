using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using CallcenterNUevo.WsReglasNegocio;


namespace WebPfizer.LMS.eCard
{
    public partial class rptTraspasos : System.Web.UI.Page
    {
        WsReglasNegocioSoapClient objWS;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            

            if (this.Request.Params["__EVENTTARGET"] == "activarT")
            {
                RadWindow1.VisibleOnPageLoad = true;
            }
            //else
            //    rdpFechaNacA.SelectedDate = DateTime.Now;
            pnlConsulta.Visible = false;
            pnlNuevoTraspaso.Visible = true;
            if (!Page.IsPostBack)
            {
                RadWindow1.VisibleOnPageLoad = false;
                RadDatePicker1.SelectedDate = DateTime.Now;
                RadDatePicker2.SelectedDate = DateTime.Now;

                //Sucursales obj = new Sucursales();
                //ddlSucursales.DataSource = obj.ObtenerCatalogoDeSucursalSap();
                //ddlSucursales.DataValueField = "Sucursal_intCiaSuc";
                //ddlSucursales.DataTextField = "Sucursal_strNombreSap";
                //ddlSucursales.DataBind();
                //ddlSucursales.Items.Insert(0, new RadComboBoxItem("Selecciona", "0"));
            }
            Master.MenuMain = "Operaciones";
            Master.Submenu = "Traspasos";
        }

        protected void btnGeneraReporte_Click(object sender, EventArgs e)
        {
            //rgResultado.DataSource = Tarjetas.ConsultarTraspasos(RadDatePicker1.SelectedDate, RadDatePicker2.SelectedDate, txtTOrigen.Text,txtTDestino.Text);
            //rgResultado.DataBind();
            //btnExportar.Enabled = true;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlNuevoTraspaso.Visible = true;
            pnlConsulta.Visible = false;
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            rgResultado.ExportSettings.Excel.Format = GridExcelExportFormat.Xlsx;
            rgResultado.ExportSettings.IgnorePaging = true;//--CheckBox1.Checked;
            rgResultado.ExportSettings.ExportOnlyData = true;
            rgResultado.ExportSettings.FileName = "rptTraspasos_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
            rgResultado.MasterTableView.ExportToExcel();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("rptTraspasos.aspx");
        }

        protected void btnConultar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dtsTarjetas = new DataSet();
                dtsTarjetas = Tarjetas.ConsultarInfoTraspaso(txtOrigenC.Text, txtDestinoC.Text);

                if (dtsTarjetas.Tables.Count > 0)
                {
                    if (dtsTarjetas.Tables[2].Rows[0]["Tarjeta_strEstatus"].ToString() == "0")
                    {
                        Master.MuestraMensaje("No se puede realizar la operación Tarjeta Origen: Nueva");
                        return;
                    }
                    if (dtsTarjetas.Tables[2].Rows[0]["CodigoError_strCodigo"].ToString() == "0" && dtsTarjetas.Tables[3].Rows[0]["CodigoError_strCodigo"].ToString() == "0")
                    {

                        if (dtsTarjetas.Tables[0].Rows.Count < 1 || dtsTarjetas.Tables[1].Rows.Count < 1)
                        {
                            lblBoomerangsO.Text = "";
                            lblEstatusO.Text = "";
                            lblFechaO.Text = "";
                            lblNivelO.Text = "";
                            lblNombreO.Text = "";
                            lblSaldoO.Text = "";
                            lblBoomerangsD.Text = "";
                            lblEstatusD.Text = "";
                            lblFechaD.Text = "";
                            lblNivelD.Text = "";
                            lblNombreD.Text = "";
                            lblSaldoD.Text = "";
                            lblBoomerangsT.Text = "";
                            lblEstatusT.Text = "";
                            lblFechaT.Text = "";
                            lblNivelT.Text = "";
                            lblNombreT.Text = "";
                            lblSaldoT.Text = "";
                            btnConfirmar.Enabled = false;
                        }
                        else
                        {
                            if (dtsTarjetas.Tables[0].Rows.Count > 0)
                            {
                                lblTarjetaO.Text = txtOrigenC.Text;
                                lblBoomerangsO.Text = dtsTarjetas.Tables[0].Rows[0]["Boomerangs"].ToString();
                                lblEstatusO.Text = dtsTarjetas.Tables[0].Rows[0]["Estatus"].ToString();
                                lblFechaO.Text = Convert.ToDateTime(dtsTarjetas.Tables[0].Rows[0]["Fecha"].ToString()).ToShortDateString();
                                lblNivelO.Text = dtsTarjetas.Tables[0].Rows[0]["Nivel"].ToString();
                                lblNombreO.Text = dtsTarjetas.Tables[0].Rows[0]["Nombre"].ToString();
                                lblSaldoO.Text = dtsTarjetas.Tables[0].Rows[0]["Saldo"].ToString();
                                if (dtsTarjetas.Tables[0].Rows[0]["FechaVigencia"] != DBNull.Value)
                                {
                                    lblVigenciaO.Text = Convert.ToDateTime(dtsTarjetas.Tables[0].Rows[0]["FechaVigencia"]).ToShortDateString();
                                }
                                else
                                { lblVigenciaO.Text = ""; }

                                if (dtsTarjetas.Tables[1].Rows.Count > 0)
                                {
                                    if (dtsTarjetas.Tables[0].Rows[0]["Estatus"].ToString().ToLower() == "inactiva")
                                    {
                                        lblBoomerangsO.Text = "";
                                        lblEstatusO.Text = "";
                                        lblFechaO.Text = "";
                                        lblNivelO.Text = "";
                                        lblNombreO.Text = "";
                                        lblSaldoO.Text = "";
                                        lblBoomerangsD.Text = "";
                                        lblEstatusD.Text = "";
                                        lblFechaD.Text = "";
                                        lblNivelD.Text = "";
                                        lblNombreD.Text = "";
                                        lblSaldoD.Text = "";
                                        lblBoomerangsT.Text = "";
                                        lblEstatusT.Text = "";
                                        lblFechaT.Text = "";
                                        lblNivelT.Text = "";
                                        lblNombreT.Text = "";
                                        lblSaldoT.Text = "";
                                        btnConfirmar.Enabled = false;
                                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No se puede realizar la operación con una tarjeta origen inactiva');", true);
                                        Master.MuestraMensaje("No se puede realizar la operación con una tarjeta origen inactiva");
                                        return;
                                    }
                                    if (dtsTarjetas.Tables[3].Rows[0]["Tarjeta_strEstatus"].ToString() == "0")
                                    {
                                        lblBoomerangsD.Text = "";
                                        lblEstatusD.Text = "";
                                        lblFechaD.Text = "";
                                        lblNivelD.Text = "";
                                        lblNombreD.Text = "";
                                        lblSaldoD.Text = "";
                                        txtMotivo.Text = "";

                                        txtApMaternoA.Text = dtsTarjetas.Tables[0].Rows[0]["Cliente_strApellidoMaterno"].ToString();
                                        txtApPaternoA.Text = dtsTarjetas.Tables[0].Rows[0]["Cliente_strApellidoPaterno"].ToString();
                                        txtEmailA.Text = dtsTarjetas.Tables[0].Rows[0]["Cliente_strCorreoElectronico"].ToString();
                                        txtNombreA.Text = dtsTarjetas.Tables[0].Rows[0]["Cliente_strPrimerNombre"].ToString();
                                        txtTelefonoMA.Text = dtsTarjetas.Tables[0].Rows[0]["Cliente_strTelefonoCelular"].ToString();
                                        DateTime fechaNac = Convert.ToDateTime(dtsTarjetas.Tables[0].Rows[0]["Cliente_dateFechaNacimiento"]);
                                        rdpFechaNacA.SelectedDate = fechaNac;
                                        rdpSexoA.SelectedValue = dtsTarjetas.Tables[0].Rows[0]["Cliente_intSexo"].ToString();
                                        RadWindowManager1.RadConfirm("La tarjeta destino no esta activa, ¿Quieres activarla?", "callbackfnAlert", 300, 200, null, "Activación de tarjeta");
                                        rdpFechaNacA.Enabled = false;
                                        RadWindowManager1.Modal = true;
                                        RadWindowManager1.VisibleOnPageLoad = true;
                                    }
                                    else
                                    {
                                        lblTarjetaD.Text = txtDestinoC.Text;
                                        lblBoomerangsD.Text = dtsTarjetas.Tables[1].Rows[0]["Boomerangs"].ToString();
                                        lblEstatusD.Text = dtsTarjetas.Tables[1].Rows[0]["Estatus"].ToString();
                                        lblFechaD.Text = Convert.ToDateTime(dtsTarjetas.Tables[1].Rows[0]["Fecha"].ToString()).ToShortDateString();
                                        lblNivelD.Text = dtsTarjetas.Tables[1].Rows[0]["Nivel"].ToString();
                                        lblNombreD.Text = dtsTarjetas.Tables[1].Rows[0]["Nombre"].ToString();
                                        lblSaldoD.Text = dtsTarjetas.Tables[1].Rows[0]["Saldo"].ToString();
                                        if (dtsTarjetas.Tables[1].Rows[0]["FechaVigencia"] != DBNull.Value)
                                            lblVigenciaD.Text = Convert.ToDateTime(dtsTarjetas.Tables[1].Rows[0]["FechaVigencia"]).ToShortDateString();
                                        else
                                            lblVigenciaD.Text = "";
                                        btnConfirmar.Enabled = true;
                                    }
                                }


                                lblBoomerangsT.Visible = false;
                                lblEstatusT.Visible = false;
                                lblFechaT.Visible = false;
                                lblNivelT.Visible = false;
                                lblNombreT.Visible = false;
                                lblSaldoT.Visible = false;
                            }
                            else
                            {
                                lblBoomerangsO.Text = "";
                                lblEstatusO.Text = "";
                                lblFechaO.Text = "";
                                lblNivelO.Text = "";
                                lblNombreO.Text = "";
                                lblSaldoO.Text = "";
                                lblBoomerangsD.Text = "";
                                lblEstatusD.Text = "";
                                lblFechaD.Text = "";
                                lblNivelD.Text = "";
                                lblNombreD.Text = "";
                                lblSaldoD.Text = "";
                                lblBoomerangsT.Text = "";
                                lblEstatusT.Text = "";
                                lblFechaT.Text = "";
                                lblNivelT.Text = "";
                                lblNombreT.Text = "";
                                lblSaldoT.Text = "";
                                btnConfirmar.Enabled = false;
                                string MensajeError = (dtsTarjetas.Tables[2].Rows[0]["CodigoError_strCodigo"].ToString() != "0") ? "Tarjeta Origen: " + dtsTarjetas.Tables[2].Rows[0]["CodigoRespuesta_strDescripcion"].ToString() : " ";
                                MensajeError += (dtsTarjetas.Tables[3].Rows[0]["CodigoError_strCodigo"].ToString() != "0") ? ", Tarjeta Destino: " + dtsTarjetas.Tables[3].Rows[0]["CodigoRespuesta_strDescripcion"].ToString() : " ";
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No se puede realizar la operación, " + MensajeError + "');", true);
                                Master.MuestraMensaje(MensajeError);
                                return;
                            }
                        }

                        DataSet dsResultados = Tarjetas.ValidarTarjetaMensaje(txtOrigenC.Text, txtDestinoC.Text);
                        if (dsResultados != null)
                        {
                            if (dsResultados.Tables[0].Rows[0][0].ToString() != "0")
                            {
                                string MensajeAviso = dsResultados.Tables[0].Rows[0][1].ToString();
                                Master.MuestraMensaje(MensajeAviso);
                            }
                        }
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + MensajeAviso + "');", true);
                        txtMotivo.Text = "";
                        pnlDatos.Visible = true;
                    }
                    else
                    {
                        string MensajeError = (dtsTarjetas.Tables[2].Rows[0]["CodigoError_strCodigo"].ToString() != "0") ? "Tarjeta Origen: " + dtsTarjetas.Tables[2].Rows[0]["CodigoRespuesta_strDescripcion"].ToString() : " ";
                        MensajeError += (dtsTarjetas.Tables[3].Rows[0]["CodigoError_strCodigo"].ToString() != "0") ? ", Tarjeta Destino: " + dtsTarjetas.Tables[3].Rows[0]["CodigoRespuesta_strDescripcion"].ToString() : " ";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No se puede realizar la operación, " + MensajeError + "');", true);
                        Master.MuestraMensaje(MensajeError);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (lblEstatusD.Text.ToLower() == "inactiva" || lblEstatusO.Text.ToLower() == "inactiva")
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No se puede realizar el traspaso ya que una de las tarjetas esta inactiva');", true);
                Master.MuestraMensaje("No se puede realizar el traspaso ya que una de las tarjetas esta inactiva");
                return;
            }
            else
            {
                objWS=new  WsReglasNegocioSoapClient ();
                TraspasaPuntosResult[] resultadoWS = new TraspasaPuntosResult[1];
                //Bitacora.TraceError("FrontEnd", "CallCenterNUevo.rptTraspasos", "btnConfirmar_Click", "Usuario: " + Context.User.Identity.Name.ToString() + " | Inicia Traspaso");
                resultadoWS = objWS.TraspasaPuntos( "1", "998877", "90", "1", txtOrigenC.Text, txtDestinoC.Text, txtMotivo.Text, HttpContext.Current.User.Identity.Name);
                
                //DataSet dtsResult = Tarjetas.RealizarTraspaso(txtDestinoC.Text, txtOrigenC.Text, HttpContext.Current.User.Identity.Name, txtMotivo.Text, "90");
                int index;
                try
                {
                    string descripcion = resultadoWS[0].CodigoRespuesta_strDescripcion.ToString();
                    //string descripcion = dtsResult.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString();
                    index = 0;
                }
                catch(Exception)
                {
                    index = 4;
                }
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + dtsResult.Tables[index].Rows[0]["CodigoRespuesta_strDescripcion"].ToString() + "')", true);
                
                //Master.MuestraMensaje(dtsResult.Tables[index].Rows[0]["CodigoRespuesta_strDescripcion"].ToString());
                Master.MuestraMensaje(resultadoWS[0].CodigoRespuesta_strDescripcion.ToString());
                //if (resultadoWS[0].CodigoRespuesta_StrCodigo.ToString().ToString() == "0")
                if (resultadoWS[0].CodigoError_strCodigo == "0")
                {
                    DataSet dtsResult = Tarjetas.ObtenerTarjeta(txtOrigenC.Text);
                    if (dtsResult.Tables.Count > 0)
                    {
                        lblEstatusO.Text = dtsResult.Tables[0].Rows[0]["Tarjeta_strEstatusT"].ToString();
                    }
                    dtsResult = Tarjetas.ConsultaTraspasoExitoso(txtDestinoC.Text);
                    if (dtsResult.Tables.Count > 0)
                    {
                        lblBoomerangsT.Visible = true;
                        lblEstatusT.Visible = true;
                        lblFechaT.Visible = true;
                        lblNivelT.Visible = true;
                        lblNombreT.Visible = true;
                        lblSaldoT.Visible = true;


                        lblBoomerangsT.Text = dtsResult.Tables[0].Rows[0]["Boomerangs"].ToString();
                        lblEstatusT.Text = dtsResult.Tables[0].Rows[0]["Estatus"].ToString();
                        lblFechaT.Text = Convert.ToDateTime(dtsResult.Tables[0].Rows[0]["Fecha"].ToString()).ToShortDateString();
                        lblNivelT.Text = dtsResult.Tables[0].Rows[0]["Nivel"].ToString();
                        lblNombreT.Text = dtsResult.Tables[0].Rows[0]["Nombre"].ToString();
                        lblSaldoT.Text = dtsResult.Tables[0].Rows[0]["Saldo"].ToString();
                        if (dtsResult.Tables[0].Rows[0]["FechaVigencia"] != DBNull.Value)
                            lblVigenciaT.Text = Convert.ToDateTime(dtsResult.Tables[0].Rows[0]["FechaVigencia"]).ToShortDateString();
                        else
                            lblVigenciaT.Text = "";
                        btnConfirmar.Enabled = true;
                    }

                    txtDestinoC.Text = "";
                    txtOrigenC.Text = "";
                    btnConfirmar.Enabled = false;
                    //Response.AddHeader("REFRESH", "2;URL=rptTraspasos.aspx");
                }
            }
            //Bitacora.TraceError("FrontEnd", "CallCenterNUevo.rptTraspasos", "btnConfirmar_Click", "Usuario: " + Context.User.Identity.Name.ToString() + " | Finaliza Traspaso");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            RadWindow1.VisibleOnPageLoad = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Tarjetas obj = new Tarjetas();
            DataSet dtsInfo = Tarjetas.ActivarTarjeta(txtDestinoC.Text, txtApPaternoA.Text, txtApMaternoA.Text, txtNombreA.Text, rdpFechaNacA.SelectedDate, txtEmailA.Text,
                                                     txtTelefonoA.Text, txtTelefonoMA.Text, rdpSexoA.SelectedValue, HttpContext.Current.User.Identity.Name);
            if (dtsInfo.Tables[0].Rows[0]["CodigoError_strCodigo"].ToString() == "0")
            {
                RadWindow1.VisibleOnPageLoad = false;
                btnConultar_Click(btnConultar, new EventArgs());
            }
            else
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + dtsInfo.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString() + "');", true);
                Master.MuestraMensaje(dtsInfo.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString());
            }
        }
    }
}