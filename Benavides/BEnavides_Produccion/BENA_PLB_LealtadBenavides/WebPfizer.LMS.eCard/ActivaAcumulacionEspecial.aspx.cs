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

    public partial class ActivaAcumulacionEspecial : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();
        ValidaAcceso valida = new ValidaAcceso();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("PreguntasEA.aspx?Id_Usuario=" + idusuario + "&Pais=" + pais, false);
            //int id = (Convert.ToInt32(Request.QueryString["Id_Usuario"].ToString()));

            //Catalogo = Request.QueryString.ToString();

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
            string id = "pruebas";
            string href = HttpContext.Current.Request.Url.AbsoluteUri.ToString();

            objDataset = valida.AgregaUID(id, href);
        }

        private void ActivaCuponID()
        {
            string cuponID;
            string celular;
            string mensaje;

            if (Request.QueryString["UID"] == null)
            {
                cuponID = "00000000-0000-0000-0000-000000000000";
            }
            else
            {
                cuponID = Request.QueryString["UID"].ToString();
            }

            if (Request.QueryString["cel_num"] == null)
            {
                celular = "";
            }
            else
            {
                celular = Request.QueryString["cel_num"].ToString();
            }

            if (Request.QueryString["text"] == null)
            {
                mensaje = "";
            }
            else
            {
                mensaje = Request.QueryString["text"].ToString();
            }
            //string href = HttpContext.Current.Request.Url.AbsoluteUri.ToString();
            //string text = Request.QueryString["text"].ToString();
            //string fecha = Request.QueryString["time_stamp"].ToString();
            //string ide = Request.QueryString["ide"].ToString();
            //string mensajeEnvio = Request.QueryString["mensajeEnvio"].ToString();            

            objDataset = valida.ActivaCuponID(cuponID, celular, mensaje);
        }



    }
}
