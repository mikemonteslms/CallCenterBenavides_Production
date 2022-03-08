using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Drawing.Text;
using Negocio;

namespace WebPfizer.LMS.eCard
{
    public partial class RegistroLLamadas : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        DataSet objDatasetLlamada = new DataSet();
        Catalogos objConsultaDatos = new Catalogos();
        Tarjetas objGuardaTarjetaCliente = new Tarjetas();
        //int strReferencia = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioCC"] == null)
            {
                Response.Redirect("AccesoCallCenter.aspx", true);
            }
            if (!IsPostBack)
            {
                CargarCatalogo("QuienLlama", cmbQuienLlama, "");
                CargarCatalogo("TipoLlamada", cmbTipoLlamada, "");                
                CargarCatalogo("SubTipoLlamada", cmbSubTipoLlamada, "");
                CargarCatalogo("TipoComentario", cmbTipoComentario, "");
                CargarCatalogo("CatSucursal", cmbSucursal, "");
            }
        }

        protected void CargarCatalogo(string @Catalogo, DropDownList ControlCombo, string cadena)
        {
            try
            {
                objDataset = objConsultaDatos.DatosCatalogoPreguntas(@Catalogo, cadena);
                ControlCombo.Items.Clear();
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));
                    for (int i = 0; i <= objDataset.Tables[0].Rows.Count - 1; i++)
                    {
                        ListItem Item = new ListItem();
                        Item.Value = objDataset.Tables[0].Rows[i]["intID"].ToString();
                        Item.Text = objDataset.Tables[0].Rows[i]["strDescripcion"].ToString();
                        ControlCombo.Items.Add(Item);
                    }
                }
            }
            catch
            {

            }
        }
        
        protected void cmbTipoLlamada_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCatalogo("SubTipoLlamada", cmbSubTipoLlamada, cmbTipoLlamada.SelectedValue);
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');window.location.href='Home.aspx'", true);
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnRegistrar_Click(object sender, ImageClickEventArgs e)
        {            
            if (cmbTipoLlamada.SelectedValue == "00")
            {
                Mensajes("Selecciona Tipo de Llamada");
                return;
            }
            if (cmbSubTipoLlamada.SelectedValue == "00")
            {
                Mensajes("Selecciona Subtipo de Llamada");
                return;
            }            
            if ((cmbTipoLlamada.SelectedValue != "00") && (cmbSubTipoLlamada.SelectedValue != "00"))
            {
                GuardarTarjetaCliente();
            }
        }

        protected void GuardarTarjetaCliente()
        {
            StringBuilder strCadena = new StringBuilder();
            //string strMensajes;
            //Armar las cadenas XML para el SP
            //Tarjeta y datos para el cliente

            strCadena.Append("<LlamadaXML>");
            strCadena.Append("<Reg>");

            strCadena.Append("<TipoLlamada_intId>");
            strCadena.Append(cmbTipoLlamada.SelectedValue.ToString());
            strCadena.Append("</TipoLlamada_intId>");

            strCadena.Append("<SubTipoLlamada_intId>");
            strCadena.Append(cmbSubTipoLlamada.SelectedValue.ToString());
            strCadena.Append("</SubTipoLlamada_intId>");

            strCadena.Append("<CatOrigenLlamada_intID>");
            strCadena.Append(cmbQuienLlama.SelectedValue.ToString());
            strCadena.Append("</CatOrigenLlamada_intID>");

            strCadena.Append("<Cadena_intID>");
            strCadena.Append("");
            strCadena.Append("</Cadena_intID>");

            strCadena.Append("<Sucursal_intID>");
            strCadena.Append(cmbSucursal.SelectedValue.ToString());
            strCadena.Append("</Sucursal_intID>");

            strCadena.Append("<Tarjeta_strNumero>");
            strCadena.Append(txtTarjeta.Text);
            strCadena.Append("</Tarjeta_strNumero>");

            strCadena.Append("<Llamada_strQuienLlama>");
            strCadena.Append(txtNombre.Text);
            strCadena.Append("</Llamada_strQuienLlama>");

            strCadena.Append("<Llamada_TelefonoContacto>");
            strCadena.Append(txtTelefono.Text);
            strCadena.Append("</Llamada_TelefonoContacto>");

            strCadena.Append("<Llamada_strComentarioCausa>");
            strCadena.Append(txtComentario.Text);
            strCadena.Append("</Llamada_strComentarioCausa>");

            strCadena.Append("<Llamada_intReferencia>");
            strCadena.Append("");
            strCadena.Append("</Llamada_intReferencia>");

            strCadena.Append("<TipoCierreLlamada_intID>");
            strCadena.Append(cmbTipoComentario.SelectedValue.ToString());
            strCadena.Append("</TipoCierreLlamada_intID>");

            strCadena.Append("<Llamada_strEstatus>");
            strCadena.Append("");
            strCadena.Append("</Llamada_strEstatus>");

            strCadena.Append("</Reg>");
            strCadena.Append("</LlamadaXML>");

            objDataset = objGuardaTarjetaCliente.GuardarLlamada(strCadena.ToString(), Session["UsuarioCC"].ToString());
            Mensajes(objDataset.Tables[0].Rows[0]["Mensaje"].ToString());
            if (objDataset.Tables[0].Rows[0]["Error"].ToString() == "0")
            {
                Mensajes("Error al registrar la llamada");
            }
        }

        protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
                
    }
}