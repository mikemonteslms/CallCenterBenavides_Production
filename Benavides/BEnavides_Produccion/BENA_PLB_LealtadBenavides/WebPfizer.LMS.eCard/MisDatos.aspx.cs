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
using Entidades;
using Datos;

namespace WebPfizer.LMS.eCard
{
    public partial class MisDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ImageButton btnInicio = (ImageButton)Master.FindControl("btnInicio");
                ImageButton btnMisDatos = (ImageButton)Master.FindControl("btnMisDatos");
                ImageButton btnMisBeneficios = (ImageButton)Master.FindControl("btnMisBeneficios");
                ImageButton btnMisCompras = (ImageButton)Master.FindControl("btnMisCompras");
                //ImageButton btnContacto = (ImageButton)Master.FindControl("btnContacto");

                btnMisDatos.ImageUrl = "ImagenesVerBoom/Master/menu/menu_02-hover.png";

                btnInicio.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_01-hover.png'");
                //btnMisDatos.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_02-hover.png'");
                //btnMisBeneficios.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_04-hover.png'");
                btnMisCompras.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_03-hover.png'");
               // btnContacto.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_06-hover.png'");

                btnInicio.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_01.png'");
                //btnMisDatos.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_02.png'");
                //btnMisBeneficios.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_04.png'");
                btnMisCompras.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_03.png'");
                //btnContacto.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_06.png'");

                btnActualizar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/2-mis_datos/btn-actualizar-datos-hover.jpg'");
                btnActualizar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/2-mis_datos/btn-actualizar-datos.jpg'");

                btnCambiar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/2-mis_datos/btn-cambiar-contasena-hover.jpg'");
                btnCambiar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/2-mis_datos/btn-cambiar-contasena.jpg'");

                DataSet ds = new DataSet();
                Clientes cs = new Clientes();
                string tarjeta = Session["Usuario"].ToString();

                ds = cs.DatosCLiente(tarjeta);

                if (ds != null)
                {
                    lblNombre.Text = ds.Tables[0].Rows[0]["NombreSolo"].ToString();
                    lblTarjeta.Text = tarjeta;
                    lblAP.Text = ds.Tables[0].Rows[0]["AP"].ToString();
                    lblAM.Text= ds.Tables[0].Rows[0]["AM"].ToString();
                    lblGenero.Text = ds.Tables[0].Rows[0]["Genero"].ToString();
                    lblCorreo.Text = ds.Tables[0].Rows[0]["Correo"].ToString();
                    if (ds.Tables[0].Rows[0]["Hijos"].ToString() == "1")
                    {
                        lblHijos.Text = "Si";
                    }
                    else
                    {
                        lblHijos.Text = "No";
                    }                    
                    lblCelular.Text = ds.Tables[0].Rows[0]["Celular"].ToString();
                    lblCP.Text = ds.Tables[0].Rows[0]["CP"].ToString();
                    lblFechaN.Text = ds.Tables[0].Rows[0]["FechaDDMMAA"].ToString();
                    lblCiudad.Text = ds.Tables[0].Rows[0]["Ciudad"].ToString();
                }
                if (Session["ConfirmoMail"].ToString().ToLower() == "base")
                {
                    trConfirma.Attributes.Clear();
                    trConfirma.Attributes.Add("display", "");
                }
            }
            catch (Exception ex)
            { 

            }
        }

        protected void btnActualizar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ActualizaDatos.aspx");
        }

        protected void btnCambiar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("CambiarContra.aspx");
        }
        protected void lnkConfirma_Click(object sender, EventArgs e)
        {
            string CorreoA = lblCorreo.Text;
            if (!string.IsNullOrEmpty(CorreoA))
            {
                DataSet dtsResult = Clientes.ReenviarMailBienvenida(Session["Usuario"].ToString(), CorreoA);
                if (dtsResult.Tables.Count > 0)
                {
                    if (dtsResult.Tables[0].Rows.Count > 0)
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El correo de bienvenida fue reenviado a " + CorreoA + "');", true);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El correo de bienvenida no pudo ser reenviado');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El correo de bienvenida no pudo ser reenviado');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El correo de bienvenida no pudo ser enviado, ya que no tiene un correo electrónico registrado.');", true);
        }
    }
}