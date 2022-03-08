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

namespace Portal_Benavides
{
    public partial class CancelaContacto : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Catalogos objConsultaDatos = new Catalogos();
        Clientes cliente = new Clientes();

        string usuario;
        string tarjeta;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnEnviar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/botones/enviar-btn.png'");
                btnEnviar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/botones/enviar-btn-over.png'");

                btnCancelar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/botones/cancelar-btn.png'");
                btnCancelar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/botones/cancelar-btn-over.png'");

                SetFocus(txtTarjeta);

                if (Session["UsuarioCC"] != null)
                {
                    if (Session["UsuarioCC"].ToString() == "WEB")
                    {
                        usuario = "WEB";
                        tarjeta = Session["Usuario"].ToString();
                        txtTarjeta.Text = tarjeta;
                        txtTarjeta.Enabled = false;

                        LlenaCombos();
                        btnEnviar.Enabled = true;
                    }
                    else
                    {
                        usuario = Session["UsuarioCC"].ToString();
                        tarjeta = txtTarjeta.Text;
                        btnValidar.Visible = true;
                    }
                }
                else
                {
                    usuario = "MAIL";
                    tarjeta = txtTarjeta.Text;
                    btnValidar.Visible = true;
                }
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["UsuarioCC"] != null)
            {
                if (Session["UsuarioCC"].ToString() == "WEB")
                {
                    Response.Redirect("MisDatos.aspx");
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
            }
            else
            {
                Response.Redirect("Home.aspx");
                //Response.Redirect("HomeRep.aspx");
            }
        }

        protected void btnEnviar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (rdoCorreoE.SelectedValue == null || rdoCelular.SelectedValue == null || rdoTelPart.SelectedValue == null || rdoCorreoP.SelectedValue == null)
                {
                    Mensajes("Selecciona el tipo de contacto que deseas tener con nosotros");
                }
                else
                {
                    if (Session["UsuarioCC"] != null)
                    {
                        if (Session["UsuarioCC"].ToString() == "WEB")
                        {
                            usuario = "WEB";
                            tarjeta = Session["Usuario"].ToString();
                            txtTarjeta.Text = tarjeta;
                            txtTarjeta.Enabled = false;
                        }
                        else
                        {
                            usuario = Session["UsuarioCC"].ToString();
                            tarjeta = txtTarjeta.Text;
                        }

                    }
                    else
                    {
                        usuario = "MAIL";
                        tarjeta = txtTarjeta.Text;
                    }

                    string correoE = rdoCorreoE.SelectedValue;
                    string celular = rdoCelular.SelectedValue;
                    string particular = rdoTelPart.SelectedValue;
                    string correoP = rdoCorreoP.SelectedValue;
                    //string clubPeques = rdoClubPeques.SelectedValue;
                    string motivo = txtMotivo.Text;


                    DataSet dsRegresa = cliente.DatosAcualizaDatoContacto(tarjeta, correoE, celular, particular, correoP, motivo, usuario);

                    if (dsRegresa.Tables[0].Rows.Count > 0)
                    {
                        string respuesta = dsRegresa.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString();
                        if (usuario == "WEB")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + respuesta + "');window.location.href='MisDatos.aspx'", true);
                        }
                        else
                        {
                            if (usuario == "MAIL")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + respuesta + "');window.location.href='Acceso.aspx'", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + respuesta + "');window.location.href='Home.aspx'", true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTarjeta.Text != String.Empty)
                {
                    LlenaCombos();
                    btnEnviar.Enabled = true;
                }
                else
                {
                    Mensajes("Captura el numero de tarjeta");
                }

            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        public void LlenaCombos()
        {
            try
            {
                DataSet objvalida = new DataSet();
                objvalida = cliente.ValidaTarjetaDC(txtTarjeta.Text);

                if (objvalida.Tables[0].Rows[0]["DescripcionError"].ToString() == "")
                {
                    if (objvalida.Tables[0].Rows[0]["Cliente_bAceptaContactoPorInformacion"].ToString() == "False")
                    {
                        rdoCorreoE.SelectedValue = "0";
                    }
                    else
                    {
                        rdoCorreoE.SelectedValue = "1";
                    }

                    if (objvalida.Tables[0].Rows[0]["Cliente_bAceptaContactoCelular"].ToString() == "False")
                    {
                        rdoCelular.SelectedValue = "0";
                    }
                    else
                    {
                        rdoCelular.SelectedValue = "1";
                    }

                    if (objvalida.Tables[0].Rows[0]["Cliente_bAceptaContactoTelefonoParticular"].ToString() == "False")
                    {
                        rdoTelPart.SelectedValue = "0";
                    }
                    else
                    {
                        rdoTelPart.SelectedValue = "1";
                    }

                    if (objvalida.Tables[0].Rows[0]["Cliente_bAceptaContactoCorreoPostal"].ToString() == "False")
                    {
                        rdoCorreoP.SelectedValue = "0";
                    }
                    else
                    {
                        rdoCorreoP.SelectedValue = "1";
                    }
                    
                }
                else
                {
                    string respuesta = objvalida.Tables[0].Rows[0]["DescripcionError"].ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + respuesta + "');window.location.href='CancelaContacto.aspx'", true);
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }
    }
}
