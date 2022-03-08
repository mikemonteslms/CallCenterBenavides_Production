using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallcenterNUevo.WsReglasNegocio;

namespace CallcenterNUevo.Perfil
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Master.MenuMain = "Clientes";
                //Master.Submenu = "Perfil de cliente";
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["ID"] != null || Session["strTarjeta"] != null)
                    {
                        if (Request.QueryString["ID"] != null)
                            Session["strTarjeta"] = WebUtility.HtmlDecode(Request.QueryString["ID"].ToString());
                        WsReglasNegocio.WsReglasNegocioSoapClient obj = new WsReglasNegocio.WsReglasNegocioSoapClient();
                        obj.ValidaTarjeta("1", "998877", Session["strTarjeta"].ToString(), "1", HttpContext.Current.User.Identity.Name, 90, 1);
                        //Response.Write(Session["strTarjeta"].ToString());
                        LlenarInfoPerfil(Session["strTarjeta"].ToString());
                    }
                    else
                        Response.Redirect("~/Callcenter/BusquedaCliente.aspx", true);
                }
            }
            catch (Exception ex)
            {
                Mensajes("Ocurrio un error al consultar la tarjeta: ");
                //Master.MuestraMensaje("Ocurrio un error al consultar la tarjeta: " + ex.Message);
            }
        }
        private void LlenarInfoPerfil(string Tarjeta)
        {
            DataSet dtsInfoPerfil = Clientes.getPerfilInfo(Tarjeta);

            if (dtsInfoPerfil.Tables.Count > 0)
            {

                if (dtsInfoPerfil.Tables[0].Rows.Count > 0)
                {
                    if (Session["TarjetaStatus"] != null)
                    {
                        lnkModRecibPromo.Visible = (Session["TarjetaStatus"].ToString() == "1") ? true : false;
                    }
                    lblRecibePromo.Text = (Convert.ToInt32(dtsInfoPerfil.Tables[0].Rows[0][0]) == 1) ? "Si" : "No";
                }

                #region Padecimientos
                if (dtsInfoPerfil.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow fila in dtsInfoPerfil.Tables[1].Rows)
                    {
                        chkPadecimientos.SelectedValue = fila["Padecimiento_intID"].ToString();
                    }
                }
                #endregion

                #region Tarjetas
                if (dtsInfoPerfil.Tables[2].Rows.Count > 0)
                {
                    string lstTarjetas = "";
                    lstTarjetas = "<ul>";
                    foreach (DataRow fila in dtsInfoPerfil.Tables[2].Rows)
                    {
                        lstTarjetas += "<li>" + fila["Tarjeta_strNumero"].ToString() + "</li>";
                    }
                    lstTarjetas += "<ul>";

                    ltlTarjeta.Text = lstTarjetas;
                }
                #endregion

                #region Beneficios Especiales
                if (dtsInfoPerfil.Tables[3].Rows.Count > 0)
                {
                    string lstBeneficios = "";

                    lstBeneficios = "<ul>";

                    foreach (DataRow fila in dtsInfoPerfil.Tables[3].Rows)
                    {
                        lstBeneficios += "<li>" + fila["TipoCumple_strDescripcion"].ToString() + "</li>";
                    }

                    lstBeneficios += "<ul>";

                    ltlEspeciales.Text = lstBeneficios;
                }
                else
                {
                    ltlEspeciales.Text = "<ul><li>Sin Beneficios</li></ul>";
                }
                #endregion

                #region Promociones
                WsReglasNegocio.WsReglasNegocioSoapClient wsRGAcumulacion = new WsReglasNegocio.WsReglasNegocioSoapClient();
                WsReglasNegocio.ConsultaAcumulacionPendienteResult resultado = wsRGAcumulacion.ConsultaAcumulacionPendiente("1", "998877", Session["strTarjeta"].ToString(), "99", HttpContext.Current.User.Identity.Name.ToString());


                //DataSet dtsDatos = Clientes.ConsultaAcumulacion(Session["strTarjeta"].ToString(), "");
                string lstPromos = "";
                lstPromos = "<ul>";

                if (resultado.Data.Length > 0)
                {
                    foreach (dataConsultaAcumulacion item in resultado.Data)
                    {
                        if (item.NombreProducto == "0")
                            lstPromos += "<li>Sin promociones</li>";
                        else
                            lstPromos += "<li>" + item.NombreProducto + " - " + item.NombreLab + "</li>";
                    }
                }
                else
                    lstPromos += "<li>Sin promociones</li>";

                //if (dtsDatos.Tables.Count > 0)
                //{
                //    if (dtsDatos.Tables[0].Rows.Count > 0)
                //    {
                //        foreach (DataRow fila in dtsDatos.Tables[0].Rows)
                //        {
                //            if (fila["NombreProducto"].ToString() == "0")
                //                lstPromos += "<li>Sin promociones</li>";
                //            else
                //                lstPromos += "<li>" + fila["NombreProducto"].ToString() + " - " + fila["Laboratorio"].ToString() + "</li>";
                //        }
                //    }
                //    else
                //        lstPromos += "<li>Sin promociones</li>";
                //}
                //else
                //    lstPromos += "<li>Sin promociones</li>";

                lstPromos += "</ul>";
                ltlPromos.Text = lstPromos;
                #endregion

                #region Traspasos
                if (dtsInfoPerfil.Tables[4].Rows.Count > 0)
                {
                    string Vigencia = "";
                    if (dtsInfoPerfil.Tables[4].Rows[0]["RegistroTraspaso_strTarjetaOrigen"].ToString().Substring(0, 2) == "15" || dtsInfoPerfil.Tables[4].Rows[0]["RegistroTraspaso_strTarjetaOrigen"].ToString().Substring(0, 3) == "131")
                        Vigencia = "";
                    else
                        Vigencia = " <br /> Vigencia T. Origen: " + ((dtsInfoPerfil.Tables[4].Rows[0]["VigenciaOrigen"] != DBNull.Value) ? Convert.ToDateTime(dtsInfoPerfil.Tables[4].Rows[0]["VigenciaOrigen"]).ToShortDateString() : "");
                    lblTraspaso.Text = "<ul><li>Si, Fecha: " + Convert.ToDateTime(dtsInfoPerfil.Tables[4].Rows[0]["RegistroTraspaso_dateFecha"]).ToShortDateString() +
                        ",<br /> Tarjeta O: " + dtsInfoPerfil.Tables[4].Rows[0]["RegistroTraspaso_strTarjetaOrigen"].ToString() + Vigencia + ",  <br />Tarjeta D:" + dtsInfoPerfil.Tables[4].Rows[0]["RegistroTraspaso_strTarjetaDestino"].ToString() + "</li></ul>";
                }
                else
                {
                    lblTraspaso.Text = "<ul><li>Tarjeta sin traspaso</li><ul>";
                }
            }
                #endregion
        }
        private void Mensajes(string valorMensaje)
                {
                    string outputstring = valorMensaje;
                    ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
                }
     }
}
    
