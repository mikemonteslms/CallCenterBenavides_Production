using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPfizer.LMS.eCard
{
    public partial class ComoGanarPuntos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Acceso.aspx", true);
            }
            if (!IsPostBack)
            {
                ImageButton boton = (ImageButton)Master.FindControl("btnInicio");
                boton.ImageUrl = "~/Imagenes_Benavides/menu/inicio-btn-over.png";
            }

        }

        protected void lnkregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}