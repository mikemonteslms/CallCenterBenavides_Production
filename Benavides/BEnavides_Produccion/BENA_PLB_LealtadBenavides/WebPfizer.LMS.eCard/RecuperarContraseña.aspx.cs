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

namespace Portal_Benavides
{
    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        ValidaAcceso valida = new ValidaAcceso();
        DatActualizarCliente datos = new DatActualizarCliente();
        Clientes cliente = new Clientes();
        EntActualizarCliente ent = new EntActualizarCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtTarjeta.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");

            if (!IsPostBack)
            {
                btnEnviar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-enviar-hover.jpg'");
                btnEnviar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-enviar.jpg'");

                btnCancelar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-regresar-hover.jpg'");
                btnCancelar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-regresar.jpg'");

                SetFocus(txtTarjeta);
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void btnEnviar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtTarjeta.Text == string.Empty || txtCorreoElectronico.Text == string.Empty)
                {
                    Mensajes("Capture tarjeta y correo electrónico");
                }
                else
                {
                    ent.Tipo = "1";
                    ent.IdCliente = txtTarjeta.Text;
                    ent.tarjeta = txtTarjeta.Text;
                    ent.CorreoElectronico = txtCorreoElectronico.Text;

                    DataSet dsRegresa = cliente.RecuperaContraseña(ent);

                    if (dsRegresa != null && dsRegresa.Tables.Count > 0 )
                    {
                        if (dsRegresa.Tables[0].Rows.Count > 0)
                        {
                            string Mensaje = dsRegresa.Tables[0].Rows[0]["CodigoError_strDescripcion"].ToString();
                            //ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "');window.location.href='Acceso.aspx'", true);
                            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "');window.location.href='Acceso.aspx'", true);
                        }
                        else
                        {
                            Mensajes("Error al ejecutar el proceso de Recuperación de contraseña");
                        }
                    }
                    else
                    {
                        Mensajes("Datos proporcionados incorrectos");
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
            Response.Redirect("Acceso.aspx");          
        }


    }
}
