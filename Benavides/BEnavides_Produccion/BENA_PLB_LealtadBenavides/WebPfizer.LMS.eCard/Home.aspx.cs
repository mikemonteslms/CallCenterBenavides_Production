using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPfizer.LMS.eCard
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UsuarioCC"] == null)
                {
                    Response.Redirect("AccesoCallCenter.aspx");
                }
                string UsuarioCC = Convert.ToString(Session["UsuarioCC"]);
                if (UsuarioCC == "mapieck" || UsuarioCC == "Mapieck" || UsuarioCC == "MAPIECK" || UsuarioCC == "cibanez" || UsuarioCC == "cfrias")
                {
                    trReportes.Attributes.Clear();
                    trReportes.Attributes.Add("display", "");
                    aRepP.Attributes.Remove("display");
                    aRepP.Attributes.Add("display", "");
                    Label13.Visible = true;
                }
            }            
        }

        protected void btnRegCliente_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RegistroClienteCallCenter.aspx");
        }

        protected void btnRegLlamada_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RegistroLLamadas.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            Session["UsuarioCC"] = null;
            Response.Redirect("AccesoCallCenter.aspx");
        }

        protected void imgSaldoCliente_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SaldoMovClienteCallCenter.aspx");
        }

        protected void ReportesBenavides_Click(object sender, ImageClickEventArgs e)
        {
            string UsuarioCC = Convert.ToString(Session["UsuarioCC"]);
            if (UsuarioCC == "mapieck" || UsuarioCC == "Mapieck" || UsuarioCC == "MAPIECK" || UsuarioCC == "cibanez")
            {
                Response.Redirect("ReportesBenavides.aspx");
            }
            else
            {
                //String Script = String.Format(@"alert('Acceso denegado');window.location.href='Acceso.aspx'", false);
                String Script = "Acceso denegado";
                ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", "alert('" + Script + "');", true);
            }
        }

        protected void btnRecContraseña_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RecuperarContraseñaCallCenter.aspx");
        }

        protected void imgCancelaContacto_Click(object sender, ImageClickEventArgs e)
        {
            string UsuarioCC = Convert.ToString(Session["UsuarioCC"]);
            //Response.Redirect("CancelaContacto.aspx");
            Response.Redirect("CancelaContactoXPadecimiento.aspx");
        }

        protected void btnEnviaCodigo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ValidaCodigoTarjeta.aspx");
        }
        


    }
}