using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;

namespace WebPfizer.LMS.eCard
{
    public partial class ActivaPromocion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string text="", cel_num="",time_stamp="",ide="",mensajeEnvio = "",idMensaje="", uid = "";

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["cel_num"] != null)
                    cel_num = Request.QueryString["cel_num"].ToString();
                if (Request.QueryString["text"] != null)
                    text = Request.QueryString["text"].ToString();
                if (Request.QueryString["time_stamp"] != null)
                    time_stamp = Request.QueryString["text"].ToString();
                if (Request.QueryString["ide"] != null)
                    ide = Request.QueryString["ide"].ToString();
                if (Request.QueryString["mensajeEnvio"] != null)
                    mensajeEnvio = Request.QueryString["mensajeEnvio"].ToString();
                if (Request.QueryString["idMensaje"] != null)
                    idMensaje = Request.QueryString["idMensaje"].ToString();
                if (Request.QueryString["UID"] != null)
                    uid = Request.QueryString["UID"].ToString();
                DataTable Mensaje = activarcuponPromo(cel_num, text, time_stamp, ide, mensajeEnvio, idMensaje,uid);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Mensaje.Rows[0][3].ToString() + "');", true);
            }
        }

        private DataTable activarcuponPromo(string cel_num, string text, string time_stamp, string ide, string mensajeEnvio, string idMensaje, string uid)
        {
            return Clientes.ActivaCuponPromo(cel_num, text, time_stamp, ide, mensajeEnvio, idMensaje,uid);     
        }
    }
}