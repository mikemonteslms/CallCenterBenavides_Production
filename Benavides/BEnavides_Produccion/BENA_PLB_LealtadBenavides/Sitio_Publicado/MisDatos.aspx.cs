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
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();
        EntActualizarCliente ent = new EntActualizarCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            imgBtnCambiarContraseña.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/botones/cambiarcontrasena-btn.png'");
            imgBtnCambiarContraseña.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/botones/cambiarcontrasena-btn-over.png'");

            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Acceso.aspx", true);
                }
                ImageButton boton = (ImageButton)Master.FindControl("btnMisDatos");
                boton.ImageUrl = "~/Imagenes_Benavides/menu/mis_datos-btn-over.png";

                string idcliente = Session["Usuario"].ToString();
                CargaDatosCliente(idcliente);
                CargaTransaccionesCliente(idcliente);
            }
        }

        private void Mensajes(string valorMensaje)
        {
            DivCambiarContraseña.Visible = false;
            string mensaje = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + mensaje + "');", true);
        }

        protected void CargaDatosCliente(string idcliente)
        {
            try
            {
                DivCambiarContraseña.Visible = false;

                objDataset = cliente.DatosCLiente(idcliente);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    string fechaNacimiento = objDataset.Tables[0].Rows[0]["FechaNacimiento"].ToString();
                    string anoFN = fechaNacimiento.Substring(0, 4);
                    string mesFN = objDataset.Tables[0].Rows[0]["FNmes"].ToString();
                    string diaFN = fechaNacimiento.Substring(6, 2);

                    lblFechaNacimiento.Text = diaFN + "/" + mesFN + "/" + anoFN;
                    lblGenero.Text = objDataset.Tables[0].Rows[0]["Genero"].ToString();
                    lblTelefono.Text = objDataset.Tables[0].Rows[0]["Telefono"].ToString();
                    lblCelular.Text = objDataset.Tables[0].Rows[0]["Celular"].ToString();
                    lblCorreo.Text = objDataset.Tables[0].Rows[0]["Correo"].ToString();
                    lblDireccion.Text = objDataset.Tables[0].Rows[0]["Direccion"].ToString();
                }
                else
                {
                    lblFechaNacimiento.Text = "Sin informacion";
                    lblGenero.Text = "Sin informacion";
                    lblTelefono.Text = "Sin informacion";
                    lblCelular.Text = "Sin informacion";
                    lblCorreo.Text = "Sin informacion";
                    lblDireccion.Text = "Sin informacion";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }

        protected void CargaTransaccionesCliente(string idcliente)
        {
            try
            {
                DivCambiarContraseña.Visible = false;

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

        protected void lnkActualizarMiInformacion_Click(object sender, EventArgs e)
        {
            DivCambiarContraseña.Visible = false;

            try
            {
                DatActualizarCliente datos = new DatActualizarCliente();

                string tarjeta = Session["Usuario"].ToString();
                    
                int PrimeraaVez = datos.ValidaRegistro1aVezV2(tarjeta);
                if (PrimeraaVez != 1)
                {
                    Response.Redirect("RegistroCliente_EncuestaInicial.aspx");
                }
                else
                {
                    Response.Redirect("ActualizarMisDatos.aspx");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void imgBtnCambiarContraseña_Click(object sender, ImageClickEventArgs e)
        {
            mpeCambiarContraseña.Show();
            DivCambiarContraseña.Visible = true;
        }

        protected void imgBtnCancelarContraseña_Click(object sender, ImageClickEventArgs e)
        {
            DivCambiarContraseña.Visible = false;

            Response.Redirect("MisDatos.aspx");
        }

        protected void imgBtnEnviarContraseña_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtContraseñaActual.Text == "" || txtNuevaContraseña.Text == "" || txtConfirmaContraseña.Text == "")
                {
                    lblMensajeCambiarContraseña.Text = "Captura todos los datos marcados (*)";
                    mpeCambiarContraseña.Show();
                    DivCambiarContraseña.Visible = true;
                }
                else
                {
                    ent.tarjeta = Session["Usuario"].ToString();
                    ent.contraseñaActual = txtContraseñaActual.Text.Trim();
                    ent.nuevaContraseña = txtNuevaContraseña.Text.Trim();
                    ent.confirmaContraseña = txtConfirmaContraseña.Text.Trim();

                    DataSet dsRegresa = cliente.CambiarContraseña(ent);

                    if (dsRegresa.Tables[0].Rows.Count > 0)
                    {
                        string respuesta = dsRegresa.Tables[0].Rows[0]["CodigoError_strCodigo"].ToString();
                        if (respuesta == "CON001")
                        {
                            string Mensaje = dsRegresa.Tables[0].Rows[0]["CodigoError_strDescripcion"].ToString();
                            DivCambiarContraseña.Visible = false;
                            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "');window.location.href='MisDatos.aspx'", true);
                        }
                        else
                        {
                            string Mensaje = dsRegresa.Tables[0].Rows[0]["CodigoError_strDescripcion"].ToString();
                            lblMensajeCambiarContraseña.Text = Mensaje;
                            mpeCambiarContraseña.Show();
                            DivCambiarContraseña.Visible = true;
                        }
                    }
                    else
                    {
                        Mensajes("Error al ejecutar el proceso de Cambio de Contraseña");
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void lnkAceptaDatoContacto_Click(object sender, EventArgs e)
        {
            Session["UsuarioCC"] = "WEB";
            Response.Redirect("CancelaContacto.aspx");
        }


    }
}
