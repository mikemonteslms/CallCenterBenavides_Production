using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPfizer.LMS.eCard
{
    public partial class Prueba_HomeRep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioCC"] == null)
            {
                Response.Redirect("AccesoRep.aspx");
            }
        }

        protected void btnCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            Session["UsuarioCC"] = null;
            Response.Redirect("AccesoRep.aspx");
        }

        protected void ReportesBenavides_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ReportesBenavidesCubo.aspx");
        }

        protected void RepFechaActivacion_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ReportesBenavidesActivacion.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }


    }
}