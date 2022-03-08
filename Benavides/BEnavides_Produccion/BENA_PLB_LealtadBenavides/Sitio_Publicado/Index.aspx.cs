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

    public partial class Index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Acceso.aspx", true);
                }
                if (!IsPostBack)
                {
                    //btnPuntos.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/botones/masinf-btn.png'");
                    //btnPuntos.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/botones/masinf-btn-over.png'");

                    ImageButton boton = (ImageButton)Master.FindControl("btnInicio");
                    boton.ImageUrl = "~/Imagenes_Benavides/menu/inicio-btn-over.png";
                    //Label tituloPagina = (Label)Master.FindControl("lblTituloPagina");
                    //tituloPagina.Text = "Inicio";

                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[1] { new DataColumn("ImageUrl") });

                    //dt.Rows.Add("Imagenes_Benavides/banners/banner-contador.jpg");
                    //dt.Rows.Add("Imagenes_Benavides/banners/banner-promociones.jpg");
                    //dt.Rows.Add("Imagenes_Benavides/banners/banner-formula.jpg");                
                    //dt.Rows.Add("Imagenes_Benavides/banners/banner-serviciodomicilio.jpg");                
                    //dt.Rows.Add("Imagenes_Benavides/banners/banner-umeb.jpg");                
                    dt.Rows.Add("Imagenes_Benavides/banners/Banner-principal-BI.jpg");

                    rptImages.DataSource = dt;
                    rptImages.DataBind();

                    //Se comenta línea que se había puesto para pruebas de la campaña de doble acumulación
                    //Response.Redirect("RegistroCliente_EncuestaInicial.aspx");
                }
            }
            catch (Exception msg)
            {
                Mensajes(msg.Message);
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void btnBeneficios_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("BeneficioInteligenteBenavides.aspx");
            }
            catch (Exception msg)
            {
                Mensajes(msg.Message);
            }
        }




    }

}
