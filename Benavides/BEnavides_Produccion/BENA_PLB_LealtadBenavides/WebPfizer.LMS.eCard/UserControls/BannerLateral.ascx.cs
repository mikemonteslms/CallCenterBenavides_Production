using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WebPfizer.LMS.eCard.UserControls
{
    public partial class BannerLateral : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string Tarjeta = "";
            if (Session["Usuario"] != null)
                Tarjeta = Session["Usuario"].ToString();
            if (Request.QueryString["ID"] != null)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                    CrearGaleria(Banner.GetListBanners(Convert.ToInt32(Request.QueryString["ID"].ToString()), Tarjeta));
                else
                    CrearGaleria(Banner.GetListBanners(0,Tarjeta));
            }
            else
            {
                CrearGaleria(Banner.GetListBanners(0, Tarjeta));
            }
        }

        private void CrearGaleria(List<Banner> listBaners)
        {           
            string htmlGaleria = "";            
            foreach (Banner bnr in listBaners)
            {
                //Pruebas
               //htmlGaleria += "<div><a href=\"Promociones.aspx?ID=" + bnr.Categoria.ToString() + "&Seccion=" + bnr.Seccion + "&PromoId=" + bnr.PromoID + "\"><img src=\""+ bnr.URLImage + "\" alt=\"\" border='0'></a></div>";
                //Produccion
                htmlGaleria += "<div><a href=\"Promociones.aspx?ID=" + bnr.Categoria.ToString() + "&PromoId=" + bnr.PromoID + "\"><img src=\"" + bnr.URLImage + "\" alt=\"\" border='0'></a></div>";
            }
            ltlBanners.Text = htmlGaleria;
        }
    }
}