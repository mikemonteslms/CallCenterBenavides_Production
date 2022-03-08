using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallcenterNUevo.Controles
{
    public partial class HeaderCliente : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["strTarjeta"] != null)
                {
                    if (Session["strTarjeta"].ToString().Substring(0, 3) == "133" || Session["strTarjeta"].ToString().Substring(0, 3) == "160")
                    {
                        btnModificar.Visible = true;
                    }
                    else
                    {
                        btnModificar.Visible = false;
                    }
                    DataSet dtsDatos = new DataSet();
                    WsReglasNegocio.WsReglasNegocioSoapClient obj = new WsReglasNegocio.WsReglasNegocioSoapClient();
                    WsReglasNegocio.ValidaTarjetaResult[] Vtarjeta = obj.ValidaTarjeta("1", "998877", Session["strTarjeta"].ToString(), "1", HttpContext.Current.User.Identity.Name, 90, 0);
                    LlenarCampos(Vtarjeta);
                }
                else
                    Response.Redirect("~/callcenter/BusquedaCliente.aspx");
            }
        }

        private void LlenarCampos(WsReglasNegocio.ValidaTarjetaResult[] dtDatos)
        {
            if (dtDatos.Length > 0)
            {
                //string FechaNac = dtDatos[0].FechaNacimiento.ToString();
                int AnnioNac = 1900, MesNac = 1, DiaNac = 1, AnnioVig = 1800, MesVig = 1, DiaVig = 1;
                string fechaNac = dtDatos[0].FechaNacimiento;
                if (!string.IsNullOrEmpty(fechaNac))
                {
                    AnnioNac = Convert.ToInt32(fechaNac.Substring(0, 4));
                    MesNac = Convert.ToInt32(fechaNac.Substring(4, 2));
                    DiaNac = Convert.ToInt32(fechaNac.Substring(6, 2));
                }

                lblCelular.Text = dtDatos[0].Celular.ToString();//dtDatos.Rows[0]["Celular"].ToString();
                lblCumpleaños.Text = new DateTime(AnnioNac, MesNac, DiaNac).ToShortDateString();
                lblEmail.Text = dtDatos[0].CorreoE.ToString();//dtDatos.Rows[0]["CorreoE"].ToString();
                lblEstatus.Text = (dtDatos[0].Tarjeta_strEstatus == "1") ? "Activa" : "Inactiva";//dtDatos.Rows[0]["Tarjeta_strEstatusT"].ToString();
                lblNombre.Text = dtDatos[0].Cliente_strNombre + " " + dtDatos[0].Cliente_strAPaterno + " " + dtDatos[0].Cliente_strAMaterno;
                lblTarjeta.Text = dtDatos[0].Tarjeta_strNumero;//dtDatos.Rows[0]["Tarjeta_strNumero"].ToString();
                //ValidaAcceso objAcceso = new ValidaAcceso();
                DataTable tblDatosBooms = new DataTable();//objAcceso.ObtenerInformacionTarjeta(lblTarjeta.Text).Tables[0];
                lblBoomerang.Text = dtDatos[0].BoomerangsAcumulados;//tblDatosBooms.Rows[0]["BoomerangsAcumulados"].ToString();
                lblNivel.Text = dtDatos[0].Tarjeta_strNivel;//tblDatosBooms.Rows[0]["NivelActual"].ToString();
                lblSaldo.Text = "$ " + dtDatos[0].Tarjeta_intMontoAcumulados;//tblDatosBooms.Rows[0]["SaldoActual"].ToString();

                tblDatosBooms = Clientes.DatosComplementarios(lblTarjeta.Text);
                string fechaVig = dtDatos[0].FechaVigencia;
                if (!string.IsNullOrEmpty(fechaVig))
                {
                    AnnioVig = Convert.ToInt32(fechaVig.Substring(0, 4));
                    MesVig = Convert.ToInt32(fechaVig.Substring(4, 2));
                    DiaVig = Convert.ToInt32(fechaVig.Substring(6, 2));
                }
                DateTime vig = new DateTime(AnnioVig, MesVig, DiaVig);
                lblVigencia.Text = (vig < new DateTime(1900, 1, 1)) ? "" : vig.ToShortDateString();//Convert.ToDateTime(dtDatos[0].FechaVigencia).ToShortDateString();//Convert.ToDateTime(tblDatosBooms.Rows[0]["Vigencia"]).ToShortDateString();
                lblCelConf.Text = ((bool)tblDatosBooms.Rows[0]["CelConfirmado"]) ? "Si, " + Convert.ToDateTime(tblDatosBooms.Rows[0]["FechaCelConf"]).ToShortDateString() : "No";

                lblCorreoconf.Text = ((bool)tblDatosBooms.Rows[0]["MailConfirmado"]) ? "Si, " + Convert.ToDateTime(tblDatosBooms.Rows[0]["FechaMailConf"]).ToShortDateString() : "No";
                lblPadecimientos.Text = ((int)tblDatosBooms.Rows[0]["Padecimientos"] == 0) ? "No" : "Si";
                lblConfirmaPortal.Text = ((int)tblDatosBooms.Rows[0]["ConfirmaPortal"] == 0) ? "No" : "Si, " + Convert.ToDateTime(tblDatosBooms.Rows[0]["FechaConfPortal"]).ToShortDateString();
                if(tblDatosBooms.Rows[0]["FechaIniMem"] != DBNull.Value)
                {
                    lblInicioM.Text = Convert.ToDateTime(tblDatosBooms.Rows[0]["FechaIniMem"]).ToShortDateString();
                }
                lblTelefonocasa.Text = dtDatos[0].Telefono;
                if (tblDatosBooms.Rows[0]["UltimoMov"] != DBNull.Value)
                    lblFechaUcompra.Text = Convert.ToDateTime(tblDatosBooms.Rows[0]["UltimoMov"]).ToShortDateString();
                lblAceptaPromo.Text = ((int)tblDatosBooms.Rows[0]["AceptaPromo"] == 0) ? "No" : "Si";

                btnModificar.Visible = (dtDatos[0].Tarjeta_strEstatus == "1") ? true : false;
                Session["TarjetaStatus"] = dtDatos[0].Tarjeta_strEstatus;

                //================================================================================================
                //TarjetastuSalud
                int intTarjeta = 0;
                intTarjeta = Convert.ToInt32(dtDatos[0].Tarjeta_strNumero.Substring(0, 3));
                if (intTarjeta > 170)
                {
                    lblUrl.Text = tblDatosBooms.Rows[0]["Url"].ToString();
                }
            }
        }

        protected void ibtnGuardarVig_Click(object sender, ImageClickEventArgs e)
        {
            DateTime FVigencia = Convert.ToDateTime(txtfecha.Text);
            if (FVigencia.Year == DateTime.Now.Year || FVigencia.Year == DateTime.Now.AddYears(1).Year)
            {
                DataTable result = Clientes.CambiarVigencia(Session["strTarjeta"].ToString(), txtfecha.Text, HttpContext.Current.User.Identity.Name);
                //Master.MuestraMensaje(result.Rows[0][1].ToString());
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('" + result.Rows[0][1].ToString() + "');", true);
                Response.AddHeader("REFRESH", "2;URL=Perfil.aspx");

            }
            else
            {
                //Master.MuestraMensaje("La vigencia no puede ser mayor a 1 año");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('La vigencia no puede ser mayor a 1 año');", true);
                txtfecha.Text = DateTime.Now.ToShortDateString();
                return;
            }
        }
    }
}