using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Negocio;

namespace Portal_Benavides
{

    public partial class ActivaAcumulacion : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();
        ValidaAcceso valida = new ValidaAcceso();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                guardaUID();
                ActivaCuponID();
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        private void guardaUID()
        {
            try
            {
                string id = "pruebas";
                string href = HttpContext.Current.Request.Url.AbsoluteUri.ToString();

                objDataset = valida.AgregaUIDValidaCorreo(id, href);
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        private void ActivaCuponID()
        {
            try
            {
                string cuponID;
                string mensaje;

                if (Request.QueryString["UID"] == null)
                {
                    cuponID = "00000000-0000-0000-0000-000000000000";
                }
                else
                {
                    cuponID = Request.QueryString["UID"].ToString();
                }

                if (Request.QueryString["text"] == null)
                {
                    mensaje = "";
                }
                else
                {
                    mensaje = Request.QueryString["text"].ToString();
                }

                objDataset = valida.ActivaCuponIDValidaCorreo(cuponID);

                if (objDataset.Tables.Count > 0)
                {
                    string PrefijoTarjeta = "";
                    string CodigoError = "";
                    string MensajeError = "";
                    if (objDataset.Tables.Count > 1)
                    {
                        PrefijoTarjeta = objDataset.Tables[1].Rows[0]["Tarjeta_strNumero"].ToString().Substring(0, 3);
                        CodigoError = objDataset.Tables[1].Rows[0]["CodigoRespuesta_StrCodigo"].ToString();
                        MensajeError = objDataset.Tables[1].Rows[0]["CodigoRespuesta_strDescripcion"].ToString();
                    }
                    else if (objDataset.Tables.Count == 1)
                    {
                        PrefijoTarjeta = objDataset.Tables[0].Rows[0]["Tarjeta_strNumero"].ToString().Substring(0, 3);
                        CodigoError = objDataset.Tables[0].Rows[0]["CodigoRespuesta_StrCodigo"].ToString();
                        MensajeError = objDataset.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString();
                    }



                    switch (PrefijoTarjeta)
                    {
                        case "160":
                        case "133":
                            pnl160.Visible = true;
                            pnl150.Visible = false;
                            pnlGenerico.Visible = false;
                            lblMensajePlatino.Text = CodigoError + " - " + MensajeError;
                            break;
                        case "150":
                            pnl150.Visible = true;
                            pnl160.Visible = false;
                            pnlGenerico.Visible = false;
                            lblMensajeAzul.Text = CodigoError + " - " + MensajeError;
                            break;
                        default:
                            pnl150.Visible = false;
                            pnl160.Visible = false;
                            pnlGenerico.Visible = true;
                            lblMensaje.Text = CodigoError + " - " + MensajeError;
                            break;
                    }

                }
                else
                {
                    string CodigoError = "";
                    string MensajeError = "Error No identificado";
                    lblMensaje.Text = CodigoError + " - " + MensajeError;
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }
    }
}
