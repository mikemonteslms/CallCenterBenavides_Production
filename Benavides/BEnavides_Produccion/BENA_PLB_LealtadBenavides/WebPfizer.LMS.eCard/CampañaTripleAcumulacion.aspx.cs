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

    public partial class CampañaTripleAcumulacion : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("PreguntasEA.aspx?Id_Usuario=" + idusuario + "&Pais=" + pais, false);
            //int id = (Convert.ToInt32(Request.QueryString["Id_Usuario"].ToString()));

            //Catalogo = Request.QueryString.ToString();

            //if (Request.HttpMethod != "POST")
            //{
            //    rs = new ManejaDB();
            //    rs.CargaComboCampos(Request.QueryString.ToString(), cmbCampos);
            //    rs.close();
                
            //}
        
            if (!IsPostBack)
            {
                lblNombre.Text = "Jaime Enriquez";
                lblFechaInicio.Text = "26/Junio/2015";
                lblFechaFin.Text = "26/Julio/2015";
            }
        }

        //        protected void btnRegistrar_Click(object sender, ImageClickEventArgs e)
        //        {
        //            try
        //            {
        //                if (lblClicValida.Text != "ClicOK")
        //                {
        //                    Mensajes("Da clic en Validar Tarjeta  para poder iniciar el Registro");
        //                }
        //                else
        //                {
        //                    if (txtTarjeta.Text.Trim() == string.Empty || txtNombre.Text.Trim() == string.Empty || txtAP.Text.Trim() == string.Empty || txtAM.Text.Trim() == string.Empty || ddlDia.SelectedValue == "00" || ddlMes.SelectedValue == "00" || ddlAno.SelectedValue == "00" || ddlGenero.SelectedValue == "3" || txtContraseña.Text == String.Empty || txtCorreo.Text.Trim() == string.Empty)
        //                    {
        //                        if (txtTarjeta.Text.Trim() == string.Empty)
        //                        {
        //                            lblValidaTarjeta.Visible = true;
        //                            Mensajes("Captura número de Tarjeta");
        //                        }
        //                        else
        //                        {
        //                            lblValidaTarjeta.Visible = false;
        //                        }

        //                        if (txtNombre.Text.Trim() == string.Empty || txtAP.Text.Trim() == string.Empty || txtAM.Text.Trim() == string.Empty)
        //                        {
        //                            lblValidaAP.Visible = true;
        //                            lblValidaAM.Visible = true;
        //                            lblValidaNombre.Visible = true;
        //                            Mensajes("Captura Nombre y Apellidos");
        //                        }
        //                        else
        //                        {
        //                            lblValidaAP.Visible = false;
        //                            lblValidaAM.Visible = false;
        //                            lblValidaNombre.Visible = false;
        //                        }

        //                        if (txtContraseña.Text.Trim() == String.Empty && txtConfirmaContra.Text.Trim() == String.Empty)
        //                        {
        //                            lblValidaContraseña.Visible = true;
        //                            lblValidaConfirmaContraseña.Visible = true;
        //                            Mensajes("Captura Contraseña y confirmación de contraseña");
        //                        }
        //                        else
        //                        {
        //                            lblValidaContraseña.Visible = true;
        //                            lblValidaConfirmaContraseña.Visible = true;
        //                        }

        //                        if (ddlAno.SelectedValue == "00" || ddlMes.SelectedValue == "00" || ddlDia.SelectedValue == "00")
        //                        {
        //                            Mensajes("Selecciona la fecha completa");
        //                            lblValidaFecha.Visible = true;
        //                        }
        //                        else
        //                        {
        //                            lblValidaFecha.Visible = false;
        //                        }

        //                        if (ddlGenero.SelectedValue == "3")
        //                        {
        //                            Mensajes("Selecciona Genero");
        //                            lblValidaGenero.Visible = true;
        //                        }
        //                        else
        //                        {
        //                            lblValidaGenero.Visible = false;
        //                        }

        //                        //DATOS DE CONTACTO
        //                        //if (txtCelular.Text == String.Empty || txtConfirmaCorreo.Text == String.Empty)
        //                        if (txtConfirmaCorreo.Text == String.Empty)
        //                        {
        //                            //lblValidaCelular.Visible = true;
        //                            lblValidaCorreo.Visible = true;
        //                            //Mensajes("Captura los datos de contacto (Celular y Correo electrónico)");
        //                            Mensajes("Captura los datos de contacto Correo electrónico");
        //                        }
        //                        else
        //                        {
        //                            //lblValidaCelular.Visible = false;
        //                            lblValidaCorreo.Visible = false;
        //                        }

        //                        //DIRECCION                        
        //                        //if (txtCalle.Text.Trim() == String.Empty || txtNumExterior.Text.Trim() == String.Empty || ddlEstado.SelectedValue == "00" || ddlMunicipio.SelectedValue == "00" || ddlColonia.SelectedValue == "00")
        //                        //{
        //                        //    lblValidaCalle.Visible = true;
        //                        //    lblValidaExterior.Visible = true;
        //                        //    lblValidaEstado.Visible = true;
        //                        //    lblValidaMunicipio.Visible = true;
        //                        //    lblValidaColonia.Visible = true;
        //                        //    Mensajes("Captura dirección completa");               
        //                        //}
        //                        //else
        //                        //{
        //                        //    lblValidaCalle.Visible = false;
        //                        //    lblValidaExterior.Visible = false;
        //                        //    lblValidaEstado.Visible = false;
        //                        //    lblValidaMunicipio.Visible = false;
        //                        //    lblValidaColonia.Visible = false;
        //                        //}
        //                    }
        //                    else
        //                    {
        //                        //if (txtCelular.Text.Trim() == string.Empty && txtCorreo.Text.Trim() == string.Empty)
        //                        //{
        //                        //lblValidaCelular.Visible = true;
        //                        //lblValidaCorreo.Visible = true;
        //                        //Mensajes("Debes captura al menos un dato de contacto (Celular o Correo electrónico)");
        //                        //}
        //                        //else
        //                        //{
        //                        //lblValidaCelular.Visible = false;
        //                        //lblValidaCorreo.Visible = false;
        //                        //}

        //                        if (txtContraseña.Text == txtConfirmaContra.Text)
        //                        {
        //                            string fecha_formato = ddlAno.SelectedItem.Text + ddlMes.SelectedValue.ToString() + ddlDia.SelectedItem.Text;

        //                            int estado, municipio, colonia;

        //                            if (ddlEstado.SelectedValue == "00" || ddlMunicipio.SelectedValue == "00" || ddlColonia.SelectedValue == "00")
        //                            {
        //                                estado = 0;
        //                                municipio = 0;
        //                                colonia = 0;
        //                            }
        //                            else
        //                            {
        //                                estado = Convert.ToInt32(ddlEstado.SelectedValue);
        //                                municipio = Convert.ToInt32(ddlMunicipio.SelectedValue);
        //                                colonia = Convert.ToInt32(ddlColonia.SelectedValue);
        //                            }

        //                            objDataset = cliente.RegistraCliente("Admin", txtNombre.Text, txtAP.Text, txtAM.Text, fecha_formato, txtCorreo.Text, txtTelefono.Text, txtCelular.Text, Convert.ToInt32(ddlGenero.SelectedValue), txtCalle.Text, txtNumExterior.Text, txtNumInterior.Text, colonia, municipio, estado, txtCP.Text, txtTarjeta.Text, txtContraseña.Text);
        //                            if (objDataset.Tables[0].Rows.Count > 0)
        //                            {
        //                                string respuesta = objDataset.Tables[0].Rows[0]["CodigoRespuesta_StrCodigo"].ToString();
        //                                if (respuesta == "AW9901")
        //                                {
        //                                    String Script = String.Format(@"alert('El registro se realizo de manera exitosa. Se te ha enviado un correo con Usuario y Contraseña para acceder al portal. Favor de verificar tu correo');
        //                                window.location.href='Acceso.aspx'", false);

        //                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", Script, true);
        //                                }
        //                                else
        //                                {
        //                                    string mensaje = objDataset.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString();
        //                                    if (respuesta == "AW2005")
        //                                    {
        //                                        String Script = String.Format(@"alert('" + mensaje + "');window.location.href='Acceso.aspx'", false);

        //                                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", Script, true);
        //                                    }
        //                                    else
        //                                    {
        //                                        Mensajes(mensaje);
        //                                    }
        //                                }
        //                            }
        //                            else
        //                            {
        //                                Mensajes("Error al ejecutar el proceso de Registro");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            Mensajes("La contraseña y la confirmación de contraseña no coinciden");
        //                        }
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Mensajes(ex.Message);
        //            }
        //        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

    }
}
