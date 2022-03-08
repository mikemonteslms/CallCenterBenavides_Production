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
    public partial class RegistroLlamada : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        DataSet objDatasetLlamada = new DataSet();
        Catalogos objConsultaDatos = new Catalogos();
        Tarjetas objGuardaTarjetaCliente = new Tarjetas();
        int strReferencia = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx", true);
            }

            if (!IsPostBack)
            {
                Label tituloPagina = (Label)Master.FindControl("lblTituloPagina");
                tituloPagina.Text = "Registro Llamada";
                CargarCatalogo("QuienLlama", cmbQuienLlama, "");
                CargarCatalogo("TipoLlamada", cmbTipoLlamada, "");
                CargarCatalogo("Cadena", cmbCadena, "");
                CargarCatalogo("SubTipoLlamada", cmbSubTipoLlamada, "");
                CargarCatalogo("TipoComentario", cmbTipoComentario, "");
                
                try   //proteger de valores incorrectos en la referencia
                {
                    strReferencia = int.Parse(Request["Referencia"]);
                }
                catch
                {
                    strReferencia = 0;
                }
                if (strReferencia > 0)
                {
                    CargarHistoricoComentario(strReferencia.ToString() , txtComentarioHistorico);
                    txtReferencia.Text = strReferencia.ToString() ;
                }
                CargarCatalogo("TipoComentario", cmbTipoComentario, strReferencia.ToString() );
                SetFocus(txtTarjeta);

 //               this.txtTarjeta.Attributes.Add("onkeypress", "if(window.event.keyCode==13){document.getElementById('" + btnActivar.ClientID.ToString() + "').click();return false;}");
            }
        }
        
        protected void GuardarTarjetaCliente()
        {
           StringBuilder strCadena = new StringBuilder();
           string strMensajes;
            //Armar las cadenas XML para el SP
            //Tarjeta y datos para el cliente

            strCadena.Append("<LlamadaXML>");
            strCadena.Append("<Reg>");

            strCadena.Append("<TipoLlamada_intId>");
            strCadena.Append(cmbTipoLlamada.SelectedValue.ToString()   );
            strCadena.Append("</TipoLlamada_intId>");

            strCadena.Append("<SubTipoLlamada_intId>");
            strCadena.Append(cmbSubTipoLlamada.SelectedValue.ToString());
            strCadena.Append("</SubTipoLlamada_intId>");

            strCadena.Append("<CatOrigenLlamada_intID>");
            strCadena.Append(cmbQuienLlama.SelectedValue.ToString());
            strCadena.Append("</CatOrigenLlamada_intID>");

            strCadena.Append("<Cadena_intID>");
            strCadena.Append(cmbCadena.SelectedValue.ToString());
            strCadena.Append("</Cadena_intID>");

            strCadena.Append("<Sucursal_intID>");
            strCadena.Append(cmbSucursal.SelectedValue.ToString());
            strCadena.Append("</Sucursal_intID>");

            strCadena.Append("<Tarjeta_strNumero>");
            strCadena.Append(txtTarjeta.Text  );
            strCadena.Append("</Tarjeta_strNumero>");

            strCadena.Append("<Llamada_strQuienLlama>");
            strCadena.Append(txtNombre.Text  );
            strCadena.Append("</Llamada_strQuienLlama>");

            strCadena.Append("<Llamada_TelefonoContacto>");
            strCadena.Append(txtTelefono.Text  );
            strCadena.Append("</Llamada_TelefonoContacto>");

            strCadena.Append("<Llamada_strComentarioCausa>");
            strCadena.Append(txtComentario.Text  );
            strCadena.Append("</Llamada_strComentarioCausa>");

            strCadena.Append("<Llamada_intReferencia>");
            strCadena.Append(txtReferencia.Text  );
            strCadena.Append("</Llamada_intReferencia>");

            strCadena.Append("<TipoCierreLlamada_intID>");
            strCadena.Append(cmbTipoComentario.SelectedValue.ToString());
            strCadena.Append("</TipoCierreLlamada_intID>");

            strCadena.Append("<Llamada_strEstatus>");
            if (chkStatusSolución.Checked)
            {
                strCadena.Append("1");
            }
            else
            {
                strCadena.Append("0");
            }
            strCadena.Append("</Llamada_strEstatus>");

            strCadena.Append("</Reg>");
            strCadena.Append("</LlamadaXML>");

            objDataset = objGuardaTarjetaCliente.GuardarLlamada(strCadena.ToString(), Session["Usuario"].ToString());
            lblResultado.Text = objDataset.Tables[0].Rows[0]["Mensaje"].ToString() ;
            if (objDataset.Tables[0].Rows[0]["Error"].ToString() == "0")
            {
                strMensajes = "CentroMensajes.aspx?Msg1=" + objDataset.Tables[0].Rows[0]["Mensaje"].ToString()
                    + "&Msg2=" + objDataset.Tables[0].Rows[0]["Folio"].ToString() 
                    + "&Msg3=";
                    
                Response.Redirect(strMensajes);
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void CargarHistoricoComentario(string IDLlamada, TextBox ControlText)
        {
            try
            {
                objDatasetLlamada = objConsultaDatos.DatosLlamada(IDLlamada);
                if (objDatasetLlamada.Tables[0].Rows.Count > 0)
                {
                    txtTarjeta.Text = objDatasetLlamada.Tables[0].Rows[0]["Tarjeta_strNumero"].ToString();
                    cmbQuienLlama.SelectedValue = objDatasetLlamada.Tables[0].Rows[0]["CatOrigenLlamada_intID"].ToString();
                    cmbTipoLlamada.SelectedValue = objDatasetLlamada.Tables[0].Rows[0]["TipoLlamada_intId"].ToString();
                    cmbSubTipoLlamada.SelectedValue = objDatasetLlamada.Tables[0].Rows[0]["SubTipoLlamada_intId"].ToString();
                    txtNombre.Text = objDatasetLlamada.Tables[0].Rows[0]["Llamada_strQuienLlama"].ToString();
                    txtTelefono.Text = objDatasetLlamada.Tables[0].Rows[0]["Llamada_TelefonoContacto"].ToString();
                    txtReferencia.Text = objDatasetLlamada.Tables[0].Rows[0]["Llamada_intReferencia"].ToString();
                    cmbCadena.SelectedValue = objDatasetLlamada.Tables[0].Rows[0]["Cadena_intID"].ToString();
                    CargarCatalogo("Sucursal", cmbSucursal, cmbCadena.Text);
                    cmbSucursal.SelectedValue = objDatasetLlamada.Tables[0].Rows[0]["Sucursal_intID"].ToString();
                    if (objDatasetLlamada.Tables[0].Rows[0]["Llamada_strEstatus"].ToString() == "1")
                    {
                        chkStatusSolución.Checked = true;
                        chkStatusSolución.Enabled = false;
                        btnRegistrar.Enabled = false;
                        txtComentario.ReadOnly  =true ; 
                    }
                    else
                    {
                        chkStatusSolución.Checked = false;
                        chkStatusSolución.Enabled = true;
                        btnRegistrar.Enabled = true;
                        txtComentario.ReadOnly = false;
                    }

                    txtTarjeta.ReadOnly = true;
                    cmbQuienLlama.Enabled = false;
                    cmbTipoLlamada.Enabled = false;
                    cmbSubTipoLlamada.Enabled = false;
                    txtNombre.ReadOnly = true;
                    txtTelefono.ReadOnly = true;
                    cmbCadena.Enabled = false;
                    cmbSucursal.Enabled = false;
                    
                    ControlText.Text += "Histórico:";
                    ControlText.Text += Environment.NewLine;
                    dgLLamada.DataSource = objDatasetLlamada;
                    dgLLamada.DataBind(); 
                    for (int i = 0; i <= objDatasetLlamada.Tables[0].Rows.Count - 1; i++)
                    {
                        ControlText.Text += "[" + objDatasetLlamada.Tables[0].Rows[i]["LlamadaComentario_strUsuarioAlta"].ToString() + "]";
                        ControlText.Text += "[" + objDatasetLlamada.Tables[0].Rows[i]["TipoCierreLlamada_strDescripcion"].ToString() + "] ";
                        ControlText.Text += objDatasetLlamada.Tables[0].Rows[i]["LlamadaComentario_dateFechaAlta"].ToString() + " - ";
                        ControlText.Text += objDatasetLlamada.Tables[0].Rows[i]["strDescripcion"].ToString();
                        ControlText.Text += Environment.NewLine; 
                    }
                }
            }
            catch (Exception  ex)
            {
                Mensajes ( ex.Message.ToString() ); 
            }
        }

        protected void CargarCatalogo(string @Catalogo, DropDownList ControlCombo, string cadena)
        {
            try
            {
                objDataset = objConsultaDatos.DatosCatalogo(@Catalogo, cadena);
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
            CargarCatalogo("SubTipoLlamada", cmbSubTipoLlamada, cmbTipoLlamada.SelectedValue );
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Session["PuedeGuardar"].ToString() == "0")
            {
                Mensajes("El nivel de seguridad no Permite Guardar Información");
                btnRegistrar.Enabled = false;
                return;
            }
            if (cmbQuienLlama.SelectedValue  == "00")
            {
                Mensajes("Selecciona quien llama");
                return; 
            }
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
            if (cmbTipoComentario.SelectedValue == "00")
            {
                Mensajes("Selecciona Subtipo de Comentario de Registro");
                return;
            }
            if ((cmbQuienLlama.SelectedValue != "00") && (cmbTipoLlamada.SelectedValue != "00") && (cmbSubTipoLlamada.SelectedValue != "00"))
            {
                GuardarTarjetaCliente();
            }
        }

        protected void cmbCadena_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCatalogo("Sucursal", cmbSucursal, cmbCadena.Text);
        }

        protected void cmbTipoComentario_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Se cierra el caso si se comunica la llamada o se redirecciona la misma.
            if (cmbTipoComentario.SelectedValue == "5")
            {
                chkStatusSolución.Checked = true;
            }
            else
            {
                chkStatusSolución.Checked = false ;
            }
            if (cmbTipoComentario.SelectedValue == "6")
            {
                chkStatusSolución.Checked = true;
                reqtxtTelefono.Enabled = false;
                reqtxtNombre.Enabled = false;
            }
            else
            {
                chkStatusSolución.Checked = false;
                reqtxtTelefono.Enabled = true;
                reqtxtNombre.Enabled = true;
            }

        }

    }
}
