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
    public partial class CambiarContra : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();
        EntActualizarCliente ent = new EntActualizarCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Acceso.aspx", true);
            }

            btnGuardar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/13-cambiar_contrasena/btn-guardar-hover.jpg'");
            btnGuardar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/13-cambiar_contrasena/btn-guardar.jpg'");

            btnRegresar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-regresar-hover.jpg'");
            btnRegresar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-regresar.jpg'");
        }

        protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MisDatos.aspx");
        }

        private void Mensajes(string valorMensaje)
        {
            //DivCambiarContraseña.Visible = false;
            string mensaje = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + mensaje + "');", true);
        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtContraseñaActual.Text == "" || txtNuevaContraseña.Text == "" || txtConfirmaContraseña.Text == "")
                {
                    Mensajes("Captura todos los datos marcados (*)");                  
                }
                else
                {                    
                    string tarjeta = Session["Usuario"].ToString();
                    string contraseñaActual = txtContraseñaActual.Text.Trim();
                    string nuevaContraseña = txtNuevaContraseña.Text.Trim();
                    string confirmaContraseña = txtConfirmaContraseña.Text.Trim();

                    DataSet dsRegresa = cliente.CambiarContraseñaNuevo(tarjeta, contraseñaActual, nuevaContraseña, confirmaContraseña);

                    if (dsRegresa.Tables[0].Rows.Count > 0)
                    {
                        string respuesta = dsRegresa.Tables[0].Rows[0]["CodigoError_strCodigo"].ToString();
                        if (respuesta == "CON001")
                        {
                            string Mensaje = dsRegresa.Tables[0].Rows[0]["CodigoError_strDescripcion"].ToString();                           
                            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "');window.location.href='MisDatos.aspx'", true);                            
                        }
                        else
                        {
                            string Mensaje = dsRegresa.Tables[0].Rows[0]["CodigoError_strDescripcion"].ToString();
                            Mensajes(Mensaje);
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
    }
}