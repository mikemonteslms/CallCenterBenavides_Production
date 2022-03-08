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
    public partial class MisCompras : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();
        EntActualizarCliente ent = new EntActualizarCliente();

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
                ImageButton btnMisBeneficios = (ImageButton)Master.FindControl("btnMisBeneficios");
                ImageButton btnMisCompras = (ImageButton)Master.FindControl("btnMisCompras");
                //ImageButton btnContacto = (ImageButton)Master.FindControl("btnContacto");

                btnMisCompras.ImageUrl = "ImagenesVerBoom/Master/menu/menu_03-hover.png";

                btnInicio.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_01-hover.png'");
                btnMisDatos.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_02-hover.png'");
                //btnMisBeneficios.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_04-hover.png'");
                //btnMisCompras.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_03-hover.png'");
                //btnContacto.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_06-hover.png'");

                btnInicio.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_01.png'");
                btnMisDatos.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_02.png'");
                //btnMisBeneficios.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_04.png'");
                //btnMisCompras.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_03.png'");
                //btnContacto.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_06.png'");

                if (!IsPostBack)
                {
                    try
                    {
                        //ImageButton boton = (ImageButton)Master.FindControl("btnMisDatos");
                        //boton.ImageUrl = "~/Imagenes_Benavides/menu/mis_datos-btn-over.png";

                        string idcliente = Session["Usuario"].ToString();
                        CargaTransaccionesCliente(idcliente);
                        CargarPiezasGratisCliente(idcliente);
                    }
                    catch
                    { }
                }
            }
            catch
            { }
        }

        private void CargarPiezasGratisCliente(string idcliente)
        {
            try
            {
                objDataset = cliente.ObtenerHistoricoPiezasGratis(idcliente);
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    grvPiezasGratis.DataSource = objDataset.Tables[0];
                    grvPiezasGratis.DataBind();
                }
                else
                {
                    grvPiezasGratis.DataSource = null;
                    grvPiezasGratis.DataBind();
                }
            }
            catch (Exception ex)
            { }
        }
        protected void CargaTransaccionesCliente(string idcliente)
        {
            try
            {          

                objDataset = cliente.DatosTransaccionesCliente(idcliente);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    grvTransacciones.DataSource = objDataset;
                    grvTransacciones.DataBind();
                }
                else
                {         
                    grvTransacciones.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }
    }
}