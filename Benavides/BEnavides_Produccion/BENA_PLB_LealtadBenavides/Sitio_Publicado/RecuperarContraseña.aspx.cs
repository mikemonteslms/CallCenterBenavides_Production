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
            if (!IsPostBack)
            {
                btnEnviar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/botones/enviar-btn-over.png'");
                btnEnviar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/botones/enviar-btn.png'");

                btnCancelar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/botones/cancelar-btn-over.png'");
                btnCancelar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/botones/cancelar-btn.png'");

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
                ent.Tipo = "1";
                ent.IdCliente = txtTarjeta.Text;
                ent.tarjeta = txtTarjeta.Text;
                ent.CorreoElectronico = txtCorreoElectronico.Text;

                DataSet dsRegresa = cliente.RecuperaContraseña(ent);

                if (dsRegresa.Tables[0].Rows.Count > 0)
                {
                    string Mensaje = dsRegresa.Tables[0].Rows[0]["CodigoError_strDescripcion"].ToString();
                        //ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "');window.location.href='Acceso.aspx'", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "');window.location.href='HomeRep.aspx'", true);
                }
                else
                {
                    Mensajes("Error al ejecutar el proceso de Recuperación de contraseña");
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("Acceso.aspx");
            Response.Redirect("HomeRep.aspx");
        }


    }
}
