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

namespace WebPfizer.LMS.eCard
{
    public partial class CentroMensajes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx", true);
            }

            if (!IsPostBack)
            {
                Label tituloPagina = (Label)Master.FindControl("lblTituloPagina");
                tituloPagina.Text = "Centro de Mensajes";
                if (Request.QueryString["Msg1"] != null )
                    Label1.Text = Request.QueryString["Msg1"].ToString();
                if (Request.QueryString["Msg2"] != null)
                    Label2.Text = Request.QueryString["Msg2"].ToString();
                if (Request.QueryString["Msg3"] != null)
                    Label3.Text = Request.QueryString["Msg3"].ToString();

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}
