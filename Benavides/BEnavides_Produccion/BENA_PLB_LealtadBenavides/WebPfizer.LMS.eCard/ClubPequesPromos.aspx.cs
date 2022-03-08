using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebPfizer.LMS.eCard
{
    public partial class ClubPequesPromos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Acceso.aspx", true);
                }
                HtmlTable tblMisBeneficios = (HtmlTable)Master.FindControl("pequesfondo");

                tblMisBeneficios.BgColor = "#D7D7D7";

                string tarjeta = Session["Usuario"].ToString();

                string peques = Session["Peques"].ToString();
                string prefijo2 = tarjeta.Substring(0, 3);

                if (peques == "1")
                {
                    btnInscribir.Visible = false;
                }
                if (prefijo2 == "131")
                {
                    btnInscribir.Visible = false;
                }
            }
            catch
            { }
        }

        protected void btnInscribir_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("ClubPequesRegistro.aspx");
            }
            catch
            { }
        }
    }
}