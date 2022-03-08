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
    public partial class ValidaCodigoTarjeta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioCC"] == null)
            {
                Response.Redirect("AccesoCallCenter.aspx", true);
            }
            if (!IsPostBack)
            {
                txtTarjeta.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
                txtCodigo.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTarjeta.Text.Trim() == string.Empty)
                {
                    Mensajes("Capture el número de tarjeta");
                }
                else
                {
                    DataSet ds = new DataSet();
                    Clientes cs = new Clientes();
                    string user = Session["UsuarioCC"].ToString();

                    ds = cs.ValidaTarjetaCodigoSMS(txtTarjeta.Text.Trim(), user);

                    if (ds != null)
                    {
                        string mensaje = ds.Tables[0].Rows[0]["strTextoRespuesta"].ToString();
                        if (ds.Tables[0].Rows[0]["strCodigoRespuesta"].ToString() == "0")
                        {
                            divCodigo.Visible = true;
                            txtTarjeta.Enabled = false;
                            btnEnviar.Enabled = false;
                            Mensajes(mensaje);
                        }
                        else
                        {
                            //mpeCuestionarioCC.Show();
                            //dvCuestionarioCC.Visible = true;

                            Mensajes(mensaje);
                            txtTarjeta.Text = string.Empty;
                        }
                    }
                    else
                    {
                        Mensajes("Error al ejecutar el proceso");
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void btnCodigo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text.Trim() == string.Empty)
                {
                    Mensajes("Capture el codigo indicado.");
                }
                else
                {
                    DataSet ds = new DataSet();
                    Clientes cs = new Clientes();

                    ds = cs.ValidaCodigoSMS(txtTarjeta.Text.Trim(), txtCodigo.Text.Trim());

                    if (ds != null)
                    {
                        string mensaje_respuesta = ds.Tables[0].Rows[0]["strTextoRespuesta"].ToString();
                        if (ds.Tables[0].Rows[0]["strCodigoRespuesta"].ToString() == "0")
                        {
                            //divCodigo.Visible = false;
                            txtTarjeta.Enabled = true;
                            txtTarjeta.Text = string.Empty;
                            btnEnviar.Enabled = true;
                            txtCodigo.Text = string.Empty;
                            Mensajes(mensaje_respuesta);
                        }
                        else
                        {
                            Mensajes(mensaje_respuesta);
                            txtCodigo.Text = string.Empty;
                        }
                    }
                    else
                    {
                        Mensajes("Error al ejecutar el proceso");
                    }

                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("Home.aspx");
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                mpeCuestionarioCC.Show();
                dvCuestionarioCC.Visible = false;
                dvCelular.Visible = true;
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ValidaCodigoTarjeta.aspx");
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtCelular.Text.Trim() == string.Empty)
                {
                    Mensajes("Capture el celular");
                }
                else
                {
                    DataSet ds = new DataSet();
                    Clientes cs = new Clientes();

                    string usuario = Session["UsuarioCC"].ToString();
                    
                    ds = cs.ValidaCelular(txtTarjeta.Text.Trim(), txtCelular.Text.Trim(), usuario);

                    if (ds != null)
                    {
                        string mensaje_respuesta = ds.Tables[0].Rows[0]["strTextoRespuesta"].ToString();
                        if (ds.Tables[0].Rows[0]["strCodigoRespuesta"].ToString() == "0")
                        {
                            dvCelular.Visible = false;
                            txtCodigo.Text = string.Empty;
                            Mensajes(mensaje_respuesta);
                            divCodigo.Visible = true;
                        }
                        else
                        {
                            Mensajes(mensaje_respuesta);
                            txtCelular.Text = string.Empty;
                        }
                    }
                    else
                    {
                        Mensajes("Error al ejecutar el proceso");
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

    }


}