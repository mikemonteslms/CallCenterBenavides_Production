using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebPfizer.LMS.eCard
{
    public partial class MisBeneficiosBlue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnClubAzul.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6-hover.png'");
            btnClubAzul.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6.png'");

            btnMedicGratis.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-5-hover.png'");
            btnMedicGratis.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-5.png'");
            
            HtmlTable tblMisBeneficios = (HtmlTable)Master.FindControl("beneficiosFondo");

            tblMisBeneficios.BgColor = "#D7D7D7";
        }

        protected void btnClubAzul_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ClubPequesPromos.aspx");
        }

        protected void btnMedicGratis_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CatalogoLaboratorios.aspx");
        }
    }
}