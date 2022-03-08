using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebPfizer.LMS.eCard
{
    public partial class MisBeneficiosPlatino : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnOrientacion.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-9-hover.png'");
            btnOrientacion.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-9.png'");

            btnServicio.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-8-hover.png'");
            btnServicio.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-8.png'");

            btnSeguro.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-7-hover.png'");
            btnSeguro.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-7.png'");

            btnClub.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-5-hover.png'");
            btnClub.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-5.png'");

            btnMedicGPlatino.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-6-hover.png'");
            btnMedicGPlatino.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-6.png'");

            btnDescuentos.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-10-hover.png'");
            btnDescuentos.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-10.png'");

            HtmlTable tblMisBeneficios = (HtmlTable)Master.FindControl("beneficiosFondo");

            tblMisBeneficios.BgColor = "#D7D7D7";
        }

        protected void btnSeguro_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SeguroVida.aspx");
        }

        protected void btnServicio_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ServicioAmbulancia.aspx");
        }

        protected void btnOrientacion_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("OrientacionTel.aspx");
        }

        protected void btnClub_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ClubPequesPromos.aspx");
        }

        protected void btnMedicGPlatino_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CatalogoLaboratoriosP.aspx");
        }

        protected void btnDescuentos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DescuentosLaboratorios.aspx");
        }

       
    }
}