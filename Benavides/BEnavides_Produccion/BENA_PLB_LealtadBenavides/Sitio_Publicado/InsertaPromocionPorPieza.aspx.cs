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

namespace WebPfizer.LMS.eCard
{
    public partial class InsertaPromocionPorPieza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioRep"] == null)
            {
                Response.Redirect("AccesoRep.aspx", true);
            }
            if(! IsPostBack)
            {
                txtPiezasCompra.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
                txtPiezasObsequio.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
                txtIdPromo.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
                txtCuponDescuento.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
                string usuario = Session["UsuarioRep"].ToString();
                txtUsuario.Text = usuario;   
            }
        }

        protected void btnEnviar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {               
                if (txtSkuProducto.Text == string.Empty || txtSkuObsequio.Text == string.Empty || txtFechaInicio.Text == string.Empty || txtFechaFin.Text == string.Empty || txtIdPromo.Text == string.Empty || txtCuponDescuento.Text == string.Empty || txtPiezasCompra.Text == string.Empty || txtPiezasObsequio.Text == string.Empty || txtUsuario.Text == string.Empty)
                {
                    Mensajes("Capture todos los valores para continuar");
                }
                else
                {
                    if (IsDate(txtFechaInicio.Text) && IsDate(txtFechaFin.Text))
                    {
                        if (lblProducto.Text == "Producto Invalido" || lblObsequio.Text == "Producto Invalido")
                        {
                            Mensajes("El sku del producto es invalido. Favor de verificar");
                        }
                        else
                        {
                            DataSet ds = new DataSet();
                            Clientes cs = new Clientes();
                            ds = cs.InsertaPromocionPorPieza("1", "998877", txtSkuProducto.Text, txtSkuObsequio.Text, txtFechaInicio.Text, txtFechaFin.Text, txtIdPromo.Text, txtCuponDescuento.Text, txtPiezasCompra.Text, txtPiezasObsequio.Text, txtUsuario.Text);                     
                           
                            if (ds != null)
                            {
                                string resultado = ds.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString();
                                string codigo = ds.Tables[0].Rows[0]["CodigoRespuesta_StrCodigo"].ToString();
                                if (codigo == "IP3007")
                                {
                                    Mensajes("Se inserto correctamente la promocion. " + resultado);
                                }
                                else
                                {
                                    Mensajes("No se inserto la Promoción, valide los datos. " + resultado);
                                }

                            }
                            else
                            {
                                Mensajes("Error al insertar la promocion");
                            }
                        }
                    }
                    else
                    {
                        Mensajes("El formato de fecha es incorrecto, favor de verificar.");
                    }
                }
            }
            catch
            { }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void txtSkuProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSkuProducto.Text == string.Empty)
                {
                    lblProducto.Visible = false;
                    lblProducto.Text = "";
                }
                else
                {
                    DataSet ds = new DataSet();
                    Clientes cs = new Clientes();
                    ds = cs.Valida_SkuProducto(txtSkuProducto.Text.Trim());
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows[0]["Resultado"].ToString() == "1")
                        {
                            lblProducto.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                            lblProducto.Visible = true;
                            lblProducto.ForeColor = System.Drawing.Color.Blue;
                        }
                        else
                        {
                            lblProducto.Text = "Producto Invalido";
                            lblProducto.Visible = true;
                            lblProducto.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch
            { }
        }

        protected void txtSkuObsequio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSkuObsequio.Text == string.Empty)
                {
                    lblObsequio.Visible = false;
                    lblObsequio.Text = "";
                }
                else
                {
                    DataSet ds = new DataSet();
                    Clientes cs = new Clientes();
                    ds = cs.Valida_SkuProducto(txtSkuObsequio.Text.Trim());
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows[0]["Resultado"].ToString() == "1")
                        {
                            lblObsequio.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                            lblObsequio.Visible = true;
                            lblObsequio.ForeColor = System.Drawing.Color.Blue;
                            
                        }
                        else
                        {
                            lblObsequio.Text = "Producto Invalido";
                            lblObsequio.Visible = true;
                            lblObsequio.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch
            { }
        }

        public static bool IsDate(string inputDate)
        {
            bool isDate = true;
            try
            {
                DateTime dateValue;
                dateValue = DateTime.ParseExact(inputDate, "yyyyMMdd", null);
            }
            catch
            {
                isDate = false;
            }
            return isDate;
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AccesoRep.aspx");
        }
    }
}