using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnuMain.CALLCENTER
{
    public partial class RegistroCliente_PrimeraVez : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["UsuarioCC"].ToString();
                btnCancelar.Attributes.Add("onmouseover", "this.src='../Imagenes_Benavides/botones/cancelar-btn-over.png'");
                btnCancelar.Attributes.Add("onmouseout", "this.src='../Imagenes_Benavides/botones/cancelar-btn.png'");

                btnRegistrar.Attributes.Add("onmouseover", "this.src='../Imagenes_Benavides/botones/registrar-btn-over.png'");
                btnRegistrar.Attributes.Add("onmouseout", "this.src='../Imagenes_Benavides/botones/registrar-btn.png'");
                CargarCatalogosCuestionarioInicial();
            }
        }

        protected void btnRegistrar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ddlHijos.SelectedValue == "1")
                {

                    if (txtNoHijos.Text.Trim() == string.Empty || chkQueEdad.SelectedValue == string.Empty || chkQueEdad.SelectedValue == "0")
                    {
                        throw new ApplicationException("Debes indicar número de Hijos y sus edades");
                    }

                    int contando = 0;
                    foreach (ListItem selec in chkQueEdad.Items)
                    {
                        if (selec.Selected)
                        {
                            contando++;
                            if (contando > Convert.ToInt32(txtNoHijos.Text))
                            {
                                throw new ApplicationException("Captura correctamente las edades de los Hijos");
                            }
                        }
                    }
                }

                if (ddlHijos.SelectedValue == "0")
                {
                    txtNoHijos.Text = "0";
                }
                if (ddlPadecimiento.SelectedValue == "1" && lstTipoPadecimiento.SelectedValue == string.Empty)
                {
                    throw new ApplicationException("Selecciona Tipo Padecimiento");
                }
                if (ddlPadecimiento.SelectedValue == "1" && lstTipoPadecimiento.SelectedValue != string.Empty)
                {
                    foreach (ListItem otro in lstTipoPadecimiento.Items)
                    {
                        if (otro.Selected == true)
                        {
                            if (otro.Value == "15" && txtPadecimiento.Text == string.Empty)
                            {
                                throw new ApplicationException("Captura el Otro Padecimiento");
                            }
                        }
                    }
                }

                if (chkCategorias.SelectedValue == string.Empty)
                {
                    throw new ApplicationException("Selecciona por lo menos una categoría por la que visitas Farmacias Benavides");
                }
                if (chkPromociones.SelectedValue == string.Empty)
                {
                    throw new ApplicationException("Selecciona que promociones deseas recibir");
                }
                else
                {
                    EntCuestionarioInicial ent = new EntCuestionarioInicial();

                    if (HttpContext.Current.User.Identity.Name == "WEB")
                    {
                        ent.usuario = "WEB";
                        ent.tarjeta = HttpContext.Current.User.Identity.Name;//Session["Usuario"].ToString();
                    }
                    else
                    {
                        ent.usuario = HttpContext.Current.User.Identity.Name;
                        ent.tarjeta = Session["Tarjeta"].ToString();//HttpContext.Current.User.Identity.Name;// ;
                    }

                    ent.tieneHijos = Convert.ToInt32(ddlHijos.SelectedValue);
                    ent.NoHijos = Convert.ToInt32(txtNoHijos.Text);
                    ent.tienePadecimientoCronico = Convert.ToInt32(ddlPadecimiento.SelectedValue);

                    StringBuilder strCadena = new StringBuilder();

                    strCadena.Append("<RespXML>");

                    foreach (ListItem queEdad in chkQueEdad.Items)
                    {
                        if (queEdad.Selected == true)
                        {
                            strCadena.Append("<id>");
                            strCadena.Append("<Preg>");
                            strCadena.Append("1");
                            strCadena.Append("</Preg>");
                            strCadena.Append("<Resp>");
                            strCadena.Append(queEdad.Value);
                            strCadena.Append("</Resp>");
                            strCadena.Append("<Otro>");
                            strCadena.Append("");
                            strCadena.Append("</Otro>");
                            strCadena.Append("</id>");
                        }
                    }

                    foreach (ListItem cat in chkCategorias.Items)
                    {
                        if (cat.Selected == true)
                        {
                            strCadena.Append("<id>");
                            strCadena.Append("<Preg>");
                            strCadena.Append("2");
                            strCadena.Append("</Preg>");
                            strCadena.Append("<Resp>");
                            strCadena.Append(cat.Value);
                            strCadena.Append("</Resp>");
                            strCadena.Append("<Otro>");
                            strCadena.Append("");
                            strCadena.Append("</Otro>");
                            strCadena.Append("</id>");
                        }
                    }

                    foreach (ListItem prom in chkPromociones.Items)
                    {
                        if (prom.Selected == true)
                        {
                            strCadena.Append("<id>");
                            strCadena.Append("<Preg>");
                            strCadena.Append("3");
                            strCadena.Append("</Preg>");
                            strCadena.Append("<Resp>");
                            strCadena.Append(prom.Value);
                            strCadena.Append("</Resp>");
                            strCadena.Append("<Otro>");
                            strCadena.Append("");
                            strCadena.Append("</Otro>");
                            strCadena.Append("</id>");
                        }
                    }

                    strCadena.Append("<id>");
                    strCadena.Append("<Preg>");
                    strCadena.Append("4");
                    strCadena.Append("</Preg>");
                    strCadena.Append("<Resp>");
                    strCadena.Append(ddlEstadoCivil.SelectedValue);
                    strCadena.Append("</Resp>");
                    strCadena.Append("<Otro>");
                    strCadena.Append("");
                    strCadena.Append("</Otro>");
                    strCadena.Append("</id>");

                    foreach (ListItem pad in lstTipoPadecimiento.Items)
                    {
                        if (pad.Selected == true)
                        {
                            if (pad.Value == "15")
                            {
                                strCadena.Append("<id>");
                                strCadena.Append("<Preg>");
                                strCadena.Append("5");
                                strCadena.Append("</Preg>");
                                strCadena.Append("<Resp>");
                                strCadena.Append(pad.Value);
                                strCadena.Append("</Resp>");
                                strCadena.Append("<Otro>");
                                strCadena.Append(txtPadecimiento.Text);
                                strCadena.Append("</Otro>");
                                strCadena.Append("</id>");
                            }
                            else
                            {
                                strCadena.Append("<id>");
                                strCadena.Append("<Preg>");
                                strCadena.Append("5");
                                strCadena.Append("</Preg>");
                                strCadena.Append("<Resp>");
                                strCadena.Append(pad.Value);
                                strCadena.Append("</Resp>");
                                strCadena.Append("<Otro>");
                                strCadena.Append("");
                                strCadena.Append("</Otro>");
                                strCadena.Append("</id>");
                            }
                        }
                    }
                    strCadena.Append("</RespXML>");

                    ent.xmlDetalle = strCadena.ToString();

                    DataSet dsRegresa = cliente.RegistroPrimeraVez(ent);

                    if (dsRegresa.Tables[0].Rows.Count > 0)
                    {
                        string respuesta = dsRegresa.Tables[0].Rows[0]["CodigoRespuesta_StrCodigo"].ToString();
                        if (respuesta == "AW9901")
                        {
                            if (HttpContext.Current.User.Identity.Name == "WEB")
                            {
                                String Script = String.Format(@"alert('Se han actualizado los datos de manera exitosa.');
                                window.location.href='../Default.aspx';", false);

                                ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", Script, true);
                            }
                            else
                            {
                                String Script = String.Format(@"alert('Se han actualizado los datos de manera exitosa.');
                                window.location.href='../Default.aspx';", false);

                                ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", Script, true);
                            }
                        }
                        else
                        {
                            string mensaje = dsRegresa.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString();

                            if (HttpContext.Current.User.Identity.Name == "WEB")
                            {
                                String Script = String.Format(@"alert('" + mensaje + "');window.location.href='../Default.aspx';", false);
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", Script, true);
                            }
                            else
                            {
                                String Script = String.Format(@"alert('" + mensaje + "');window.location.href='../Default.aspx';", false);

                                ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", Script, true);
                            }
                        }
                    }
                    else
                    {
                        Mensajes("Error al ejecutar el proceso de Registro");
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            if (HttpContext.Current.User.Identity.Name == "WEB")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                String Script = String.Format(@"alert('Se han actualizado con éxito solo los datos actualizados');window.location.href='../Default.aspx';", false);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", Script, true);
            }
        }

        protected void CargarCatalogosCuestionarioInicial()
        {
            try
            {
                EntCuestionarioInicial entEstadoCivil = new EntCuestionarioInicial();
                entEstadoCivil.cuestionario = 1;
                entEstadoCivil.pregunta = 4;
                ddlEstadoCivil.DataValueField = "IDRespuesta";
                ddlEstadoCivil.DataTextField = "Respuesta";
                ddlEstadoCivil.DataSource = cliente.ListaCatalogosCuestionarioInicial(entEstadoCivil);
                ddlEstadoCivil.DataBind();

                EntCuestionarioInicial entQueEdad1 = new EntCuestionarioInicial();
                entQueEdad1.cuestionario = 1;
                entQueEdad1.pregunta = 1;
                chkQueEdad.DataValueField = "IDRespuesta";
                chkQueEdad.DataTextField = "Respuesta";
                chkQueEdad.DataSource = cliente.ListaCatalogosCuestionarioInicial(entQueEdad1);
                chkQueEdad.DataBind();

                EntCuestionarioInicial entCategorias = new EntCuestionarioInicial();
                entCategorias.cuestionario = 1;
                entCategorias.pregunta = 2;
                chkCategorias.DataValueField = "IDRespuesta";
                chkCategorias.DataTextField = "Respuesta";
                chkCategorias.DataSource = cliente.ListaCatalogosCuestionarioInicial(entCategorias);
                chkCategorias.DataBind();

                EntCuestionarioInicial entPromociones = new EntCuestionarioInicial();
                entPromociones.cuestionario = 1;
                entPromociones.pregunta = 3;
                chkPromociones.DataValueField = "IDRespuesta";
                chkPromociones.DataTextField = "Respuesta";
                chkPromociones.DataSource = cliente.ListaCatalogosCuestionarioInicial(entPromociones);
                chkPromociones.DataBind();

                EntCuestionarioInicial entPadecimiento = new EntCuestionarioInicial();
                entPadecimiento.cuestionario = 1;
                entPadecimiento.pregunta = 5;
                lstTipoPadecimiento.DataValueField = "IDRespuesta";
                lstTipoPadecimiento.DataTextField = "Respuesta";
                lstTipoPadecimiento.DataSource = cliente.ListaCatalogosCuestionarioInicial(entPadecimiento);
                lstTipoPadecimiento.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }

        protected void ddlHijos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHijos.SelectedValue == "1")
            {
                lblCuantos.Visible = true;
                txtNoHijos.Visible = true;

                pnlchkEdad.Visible = true;
                lblQueEdad.Visible = true;
                chkQueEdad.Visible = true;
            }
            else
            {
                lblCuantos.Visible = false;
                txtNoHijos.Text = "";
                txtNoHijos.Visible = false;

                pnlchkEdad.Visible = false;
                lblQueEdad.Visible = false;
                chkQueEdad.ClearSelection();
                chkQueEdad.Visible = false;
            }
        }

        protected void ddlPadecimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPadecimiento.SelectedValue == "1")
            {
                lblTipoPadecimiento.Visible = true;
                pnlPadecimiento.Visible = true;
                lstTipoPadecimiento.Visible = true;
            }
            else
            {
                lblTipoPadecimiento.Visible = false;
                pnlPadecimiento.Visible = false;
                lstTipoPadecimiento.ClearSelection();
                lstTipoPadecimiento.Visible = false;

                lblCualPadecimiento.Visible = false;
                txtPadecimiento.Text = "";
                txtPadecimiento.Visible = false;
            }
        }

        protected void lstTipoPadecimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem otro in lstTipoPadecimiento.Items)
            {
                if (otro.Selected == true)
                {
                    if (otro.Value == "15")
                    {
                        lblCualPadecimiento.Visible = true;
                        txtPadecimiento.Visible = true;
                    }
                    else
                    {
                        lblCualPadecimiento.Visible = false;
                        txtPadecimiento.Text = "";
                        txtPadecimiento.Visible = false;
                    }
                }
            }
        }
    }
}