using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebPfizer.LMS.eCard
{
    public partial class MisBeneficios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Acceso.aspx", true);
                }

               
                ImageButton btnInicio = (ImageButton)Master.FindControl("btnInicio");
                ImageButton btnMisDatos = (ImageButton)Master.FindControl("btnMisDatos");
                //ImageButton btnMisBeneficios = (ImageButton)Master.FindControl("btnMisBeneficios");
                ImageButton btnMisCompras = (ImageButton)Master.FindControl("btnMisCompras");
                ImageButton btnContacto = (ImageButton)Master.FindControl("btnContacto");
                HtmlTable tblMisBeneficios = (HtmlTable)Master.FindControl("beneficiosFondo");                
                
                btnOrientacion.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-9-hover.png'");
                btnOrientacion.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-9.png'");

                btnServicio.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-8-hover.png'");
                btnServicio.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-8.png'");

                btnSeguro.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-7-hover.png'");
                btnSeguro.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-7.png'");

                btnClub.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-5-hover.png'");
                btnClub.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-5.png'");

                btnClubAzul.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6-hover.png'");
                btnClubAzul.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6.png'");

                btnMedicGratis.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-5-hover.png'");
                btnMedicGratis.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-5.png'");

                btnMedicGPlatino.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-6-hover.png'");
                btnMedicGPlatino.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-6.png'");

                btnDescuentos.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-10-hover.png'");
                btnDescuentos.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-10.png'");
                
                //btnMisBeneficios.ImageUrl = "ImagenesVerBoom/Master/menu/menu_04-hover.png";

                btnInicio.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_01-hover.png'");
                btnMisDatos.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_02-hover.png'");
                //btnMisBeneficios.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_04-hover.png'");
                
                btnMisCompras.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_03-hover.png'");
                btnContacto.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_06-hover.png'");

                btnInicio.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_01.png'");
                btnMisDatos.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_02.png'");
                //btnMisBeneficios.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_04.png'");
                btnMisCompras.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_03.png'");
                btnContacto.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_06.png'");


                tblMisBeneficios.BgColor = "#D7D7D7";

                string tarjeta = Session["Usuario"].ToString();
                string prefijo2 = tarjeta.Substring(0, 3);
                string prefijo = tarjeta.Substring(0, 2);

                if (prefijo2 == "133")
                {
                    divPlatino.Visible = true;
                }
                if (prefijo2 == "131")
                {
                    divAzul.Visible = true;
                }
                if (prefijo == "15")
                {
                    divAzul.Visible = true;
                }
                if (prefijo == "16")
                {
                    divPlatino.Visible = true;
                }
            }
            catch
            {
 
            }
        }

        protected void btnOrientacion_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("OrientacionTel.aspx");
        }

        protected void btnServicio_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ServicioAmbulancia.aspx");
        }

        protected void btnSeguro_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SeguroVida.aspx");
        }

        protected void btnClub_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ClubPequesPromos.aspx");
        }

        protected void btnClubAzul_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ClubPequesPromos.aspx");
        }

        protected void btnMedicGratis_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CatalogoLaboratorios.aspx");
        }

        protected void btnMedicGPlatino_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CatalogoLaboratorios.aspx");
        }

        protected void btnDescuentos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("DescuentosLaboratorios.aspx");
        }
    }
}