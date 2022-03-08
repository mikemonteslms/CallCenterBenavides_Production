using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;
using Datos;
using System.Text;

namespace WebPfizer.LMS.eCard
{
    public partial class RegistroCliente_EncuestaInicial : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Catalogos objConsultaDatos = new Catalogos();
        Clientes cliente = new Clientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ImageButton boton1 = (ImageButton)Master.FindControl("imgBtnContacto");
                //boton1.ImageUrl = "~/Imagenes_Benavides/menu/contacto-btn.png";

                //CargarCataloSexo();
                CargarCatalogo("estado", ddlEstado, "", "");

                CargarCatalogoAno(DateTime.Today.Year, 1900, ddlAno);
                CargarCatalogoMes(1, 12, ddlMes);
                ddlDia.Items.Add(new ListItem("DIA", "00"));

                LlenarMisDatos();
                CargarCatalogosCuestionarioInicial();
            }
        }

        protected void CargarCatalogoAno(int final, int inicial, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                ControlCombo.Items.Add(new ListItem("AÑO", "1900"));

                for (int i = final; i >= inicial; i--)
                {
                    ListItem Item = new ListItem();
                    Item.Value = i.ToString();
                    Item.Text = i.ToString();
                    ControlCombo.Items.Add(Item);
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void CargarCatalogoDia(int inicial, int final, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                ControlCombo.Items.Add(new ListItem("DIA", "00"));


                for (int i = inicial; i <= final; i++)
                {
                    ListItem Item = new ListItem();

                    if (i.ToString().Length == 1)
                    {
                        Item.Value = "0" + i.ToString();
                        Item.Text = "0" + i.ToString();
                    }
                    else
                    {
                        Item.Value = i.ToString();
                        Item.Text = i.ToString();
                    }
                    ControlCombo.Items.Add(Item);
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void CargarCatalogoMes(int inicial, int final, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                ControlCombo.Items.Add(new ListItem("MES", "00"));

                ListItem Item1 = new ListItem();
                ListItem Item2 = new ListItem();
                ListItem Item3 = new ListItem();
                ListItem Item4 = new ListItem();
                ListItem Item5 = new ListItem();
                ListItem Item6 = new ListItem();
                ListItem Item7 = new ListItem();
                ListItem Item8 = new ListItem();
                ListItem Item9 = new ListItem();
                ListItem Item10 = new ListItem();
                ListItem Item11 = new ListItem();
                ListItem Item12 = new ListItem();

                Item1.Value = "01";
                Item1.Text = "ENERO";
                ControlCombo.Items.Add(Item1);
                Item2.Value = "02";
                Item2.Text = "FEBRERO";
                ControlCombo.Items.Add(Item2);
                Item3.Value = "03";
                Item3.Text = "MARZO";
                ControlCombo.Items.Add(Item3);
                Item4.Value = "04";
                Item4.Text = "ABRIL";
                ControlCombo.Items.Add(Item4);
                Item5.Value = "05";
                Item5.Text = "MAYO";
                ControlCombo.Items.Add(Item5);
                Item6.Value = "06";
                Item6.Text = "JUNIO";
                ControlCombo.Items.Add(Item6);
                Item7.Value = "07";
                Item7.Text = "JULIO";
                ControlCombo.Items.Add(Item7);
                Item8.Value = "08";
                Item8.Text = "AGOSTO";
                ControlCombo.Items.Add(Item8);
                Item9.Value = "09";
                Item9.Text = "SEPTIEMBRE";
                ControlCombo.Items.Add(Item9);
                Item10.Value = "10";
                Item10.Text = "OCTUBRE";
                ControlCombo.Items.Add(Item10);
                Item11.Value = "11";
                Item11.Text = "NOVIEMBRE";
                ControlCombo.Items.Add(Item11);
                Item12.Value = "12";
                Item12.Text = "DICIEMBRE";
                ControlCombo.Items.Add(Item12);
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void ddlAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAno.SelectedValue == "00")
            {
                ddlMes.Items.Clear();
                ddlMes.Items.Add(new ListItem("Selecciona", "00"));
                ddlMes.Enabled = false;
                ddlDia.Items.Clear();
                ddlDia.Items.Add(new ListItem("Selecciona", "00"));
                ddlDia.Enabled = false;
            }
            else
            {
                CargarCatalogoMes(1, 12, ddlMes);
                ddlMes.Enabled = true;
                ddlDia.Items.Clear();
                ddlDia.Items.Add(new ListItem("Selecciona", "00"));
                ddlDia.Enabled = false;
            }
        }

        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMes.SelectedValue == "00")
            {
                ddlDia.Items.Clear();
                ddlDia.Items.Add(new ListItem("Selecciona", "00"));
                ddlDia.Enabled = false;
            }
            else
            {
                ddlDia.Enabled = true;

                int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAno.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue));

                CargarCatalogoDia(1, diasxmes, ddlDia);
            }
        }
        
        protected void CargarCatalogo(string @Catalogo, DropDownList ControlCombo, string filtro1, string filtro2)
        {
            try
            {
                objDataset = objConsultaDatos.DatosCatalogoSepoMex(@Catalogo, filtro1, filtro2);
                ControlCombo.Items.Clear();
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));
                    for (int i = 0; i <= objDataset.Tables[0].Rows.Count - 1; i++)
                    {
                        ListItem Item = new ListItem();
                        Item.Value = objDataset.Tables[0].Rows[i][0].ToString();
                        Item.Text = objDataset.Tables[0].Rows[i][1].ToString();
                        ControlCombo.Items.Add(Item);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void CargarCatalogoCPEstado(string @Catalogo, DropDownList ControlCombo, string filtro1, string filtro2)
        {
            try
            {
                objDataset = objConsultaDatos.DatosCatalogoSepoMex(@Catalogo, filtro1, filtro2);
                ControlCombo.Items.Clear();
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));
                    for (int i = 0; i <= objDataset.Tables[0].Rows.Count - 1; i++)
                    {
                        ListItem Item = new ListItem();
                        Item.Value = objDataset.Tables[0].Rows[i]["IDEstado"].ToString();
                        Item.Text = objDataset.Tables[0].Rows[i]["Estado_strNombre"].ToString();
                        ControlCombo.Items.Add(Item);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void CargarCatalogoCPMunicipio(string @Catalogo, DropDownList ControlCombo, string filtro1, string filtro2)
        {
            try
            {
                objDataset = objConsultaDatos.DatosCatalogoSepoMex(@Catalogo, filtro1, filtro2);
                ControlCombo.Items.Clear();
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));
                    for (int i = 0; i <= objDataset.Tables[0].Rows.Count - 1; i++)
                    {
                        ListItem Item = new ListItem();
                        Item.Value = objDataset.Tables[0].Rows[i]["IDMunicipio"].ToString();
                        Item.Text = objDataset.Tables[0].Rows[i]["Municipio_strNombre"].ToString();
                        ControlCombo.Items.Add(Item);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void CargarCatalogoCPColonia(string @Catalogo, DropDownList ControlCombo, string filtro1, string filtro2)
        {
            try
            {
                objDataset = objConsultaDatos.DatosCatalogoSepoMex(@Catalogo, filtro1, filtro2);
                ControlCombo.Items.Clear();
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));
                    for (int i = 0; i <= objDataset.Tables[0].Rows.Count - 1; i++)
                    {
                        ListItem Item = new ListItem();
                        Item.Value = objDataset.Tables[0].Rows[i]["IDColonia"].ToString();
                        Item.Text = objDataset.Tables[0].Rows[i]["Descripcion"].ToString();
                        ControlCombo.Items.Add(Item);
                    }
                }
                ddlEstadoOculto.SelectedValue = objDataset.Tables[0].Rows[0]["IDEstado"].ToString();
                CargarCatalogo("Municipio", ddlMunicipioOculto, ddlEstadoOculto.SelectedValue.ToString(), "");
                ddlMunicipioOculto.SelectedValue = objDataset.Tables[0].Rows[0]["IDMunicipio"].ToString();
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }
        //protected void CargarCataloSexo()
        //{
        //    EntActualizarCliente eac = new EntActualizarCliente();

        //    ddlActSexo.DataTextField = "Sexo";
        //    ddlActSexo.DataValueField = "idSexo";
        //    ddlActSexo.DataSource = cliente.ListaCatalogoSexo(eac);
        //    ddlActSexo.DataBind();
        //}

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstado.SelectedValue == "00")
            {
                ddlMunicipio.Items.Clear();
                ddlColonia.Items.Clear();
                ddlMunicipio.Enabled = false;
                ddlColonia.Enabled = false;
                txtCP.Text = string.Empty;
            }
            else
            {
                ddlMunicipio.Enabled = true;
                ddlColonia.Items.Clear();
                ddlColonia.Enabled = false;
                txtCP.Text = string.Empty;
                CargarCatalogo("Municipio", ddlMunicipio, ddlEstado.SelectedValue.ToString(), "");
            }
        }

        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMunicipio.SelectedValue == "00")
            {
                txtCP.Text = string.Empty;
                ddlColonia.Items.Clear();
                ddlColonia.Enabled = false;
            }
            else
            {
                ddlColonia.Enabled = true;
                CargarCatalogo("Colonia", ddlColonia, ddlEstado.SelectedValue.ToString(), ddlMunicipio.SelectedValue.ToString());
            }
        }

        protected void ddlColonia_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddlColonia.SelectedValue == "00")
            {
                txtCP.Text = string.Empty;
            }
            else
            {
                CargarCodigoP("Colonia", ddlColonia, ddlEstado.SelectedValue.ToString(), ddlMunicipio.SelectedValue.ToString());
            }
        }

        protected void CargarCodigoP(string @Catalogo, DropDownList ControlCombo, string filtro1, string filtro2)
        {
            try
            {
                objDataset = objConsultaDatos.DatosCatalogoSepoMex(@Catalogo, filtro1, filtro2);
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));
                    for (int i = 0; i <= objDataset.Tables[0].Rows.Count - 1; i++)
                    {
                        if (objDataset.Tables[0].Rows[i]["IDColonia"].ToString() == ddlColonia.SelectedValue.ToString())
                        {
                            txtCP.Text = objDataset.Tables[0].Rows[i]["CP"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        //MUESTRA MENSAJE DE ERROR
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        //LLENA DATOS ENCONTRADOS EN BD
        protected void LlenarMisDatos()
        {
            try
            {
                EntActualizarCliente ent = new EntActualizarCliente();
                DataSet datos = new DataSet();

                ent.IdCliente = Session["Usuario"].ToString();
                datos = cliente.MisDatosCliente(ent);

                //txtActTelefono.Text = datos.Tables[0].Rows[0]["Cliente_strTelefonoCasa"].ToString();
                //txtCelular.Text = datos.Tables[0].Rows[0]["Cliente_strTelefonoCelular"].ToString();
                //txtMail.Text = datos.Tables[0].Rows[0]["Cliente_strCorreoElectronico"].ToString();
                txtActCalle.Text = datos.Tables[0].Rows[0]["Cliente_strCalle"].ToString();
                txtInterior.Text = datos.Tables[0].Rows[0]["Cliente_strNumeroInterior"].ToString();
                txtExterior.Text = datos.Tables[0].Rows[0]["Cliente_strNumeroExterior"].ToString();
                txtCP.Text = datos.Tables[0].Rows[0]["Cliente_strCodigoPostal"].ToString();

                if (datos.Tables[0].Rows[0]["Cliente_intSexo"].ToString() != string.Empty)
                {
                    if (datos.Tables[0].Rows[0]["Cliente_intSexo"].ToString() == "1" || datos.Tables[0].Rows[0]["Cliente_intSexo"].ToString() == "2")
                    {
                        rdoGenero.SelectedValue = datos.Tables[0].Rows[0]["Cliente_intSexo"].ToString();
                    }
                    else
                    {
                        rdoGenero.SelectedValue = "";
                    }
                }
                ddlEstado.SelectedValue = datos.Tables[0].Rows[0]["Cliente_intEstado"].ToString();
                CargarCatalogo("Municipio", ddlMunicipio, ddlEstado.SelectedValue.ToString(), "");

                ddlMunicipio.SelectedValue = datos.Tables[0].Rows[0]["Cliente_intDelegMunicipio"].ToString();
                CargarCatalogo("Colonia", ddlColonia, ddlEstado.SelectedValue.ToString(), ddlMunicipio.SelectedValue.ToString());

                ddlColonia.SelectedValue = datos.Tables[0].Rows[0]["Cliente_intColonia"].ToString();
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        //LLENADO DE OPCIONES DE CATALOGOS
        protected void CargarCatalogosCuestionarioInicial()
        {
            try
            {
                EntCuestionarioInicial entPadecimiento = new EntCuestionarioInicial();
                entPadecimiento.cuestionario = 2;
                entPadecimiento.pregunta = 11;
                chkPadecimientos.DataValueField = "IDRespuesta";
                chkPadecimientos.DataTextField = "Respuesta";
                chkPadecimientos.DataSource = cliente.ListaCatalogosCuestionarioInicial(entPadecimiento);
                chkPadecimientos.DataBind();

                EntCuestionarioInicial entCategorias = new EntCuestionarioInicial();
                entCategorias.cuestionario = 2;
                entCategorias.pregunta = 12;
                chkCategorias.DataValueField = "IDRespuesta";
                chkCategorias.DataTextField = "Respuesta";
                chkCategorias.DataSource = cliente.ListaCatalogosCuestionarioInicial(entCategorias);
                chkCategorias.DataBind();

                EntCuestionarioInicial entEstadoCivil = new EntCuestionarioInicial();
                entEstadoCivil.cuestionario = 2;
                entEstadoCivil.pregunta = 13;
                ddlEstadoCivil.DataValueField = "IDRespuesta";
                ddlEstadoCivil.DataTextField = "Respuesta";
                ddlEstadoCivil.DataSource = cliente.ListaCatalogosCuestionarioInicial(entEstadoCivil);
                ddlEstadoCivil.DataBind();

                EntCuestionarioInicial entMedio = new EntCuestionarioInicial();
                entPadecimiento.cuestionario = 2;
                entPadecimiento.pregunta = 14;
                chkMedio.DataValueField = "IDRespuesta";
                chkMedio.DataTextField = "Respuesta";
                chkMedio.DataSource = cliente.ListaCatalogosCuestionarioInicial(entPadecimiento);
                chkMedio.DataBind();
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        //BOTON DE CANCELAR
        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //Response.Redirect("MisDatos.aspx");
                Response.Redirect("Index.aspx");
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void chkPadecimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem otro in chkPadecimientos.Items)
            {
                if (otro.Selected == true)
                {
                    if (otro.Value == "9")
                    {
                        lblOtroPadecimiento.Visible = true;
                        txtOtroPadecimiento.Visible = true;
                    }
                    else
                    {
                        lblOtroPadecimiento.Visible = false;
                        txtOtroPadecimiento.Text = "";
                        txtOtroPadecimiento.Visible = false;
                    }
                }
            }
        }

        //protected void chkMedio_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    foreach (ListItem domicilio in chkMedio.Items)
        //    {
        //        if (domicilio.Selected == true)
        //        {
        //            if (domicilio.Value == "1")
        //            {
        //                pnlDomicilio.Visible = true;
        //            }
        //            else
        //            {
        //                pnlDomicilio.Visible = false;
        //            }
        //        }
        //    }
        //}

        //REGISTRA DATOS

        protected void btnRegistrar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (rdoGenero.SelectedValue == string.Empty)
                {
                    throw new ApplicationException("Selecciona Género");
                }
                if (ddlEstadoCivil.SelectedValue == "-1")
                {
                    throw new ApplicationException("Selecciona estado civil");
                }
                if (ddlAno.SelectedValue == "1900" || ddlMes.SelectedValue == "00" || ddlDia.SelectedValue == "00")
                {
                    throw new ApplicationException("Selecciona Fecha de Nacimiento correcta");
                }
                int fechaAño = Convert.ToInt32(ddlAno.SelectedValue);
                if (fechaAño < 1915 || fechaAño > 2001)
                {
                    throw new ApplicationException("Captura un año de Nacimiento valido, este debe ser menor a 2001 y mayor a 1915");
                }
                if (txtMail.Text == string.Empty && txtDominio.Text == string.Empty && txtCelular.Text == string.Empty)
                {
                    throw new ApplicationException("Captura correo electrónico o celular");
                }
                if (chkMedio.SelectedValue == string.Empty)
                {
                    throw new ApplicationException("Selecciona por lo menos un medio para recibir información de Farmacias Benavides");
                }
                else
                {
                    foreach (ListItem domicilio in chkMedio.Items)
                    {
                        if (domicilio.Selected == true)
                        {
                            if (domicilio.Value == "1")
                            {
                                if (ddlEstado.SelectedValue == string.Empty || ddlMunicipio.SelectedValue == string.Empty || ddlColonia.SelectedValue == string.Empty || txtCP.Text == string.Empty)
                                {
                                    throw new ApplicationException("Captura la dirección completa");
                                }
                            }
                            else
                            {
                                //if (ddlEstadoOculto.SelectedValue == string.Empty || txtCPVisible.Text == String.Empty)
                                //{
                                //    throw new ApplicationException("Captura CP y selecciona Colonia donde vives");
                                //}
                                //if (txtCPVisible.Text.Length != 5)
                                //{
                                //    throw new ApplicationException("Captura el CP a 5 posiciones");
                                //}
                            }
                        }
                    }
                }

                if (txtCuantos.Text == string.Empty)
                {
                    throw new ApplicationException("Captura cuantas personas viven en tu casa");
                }

                if (chkPadecimientos.SelectedValue != string.Empty)
                {

                    foreach (ListItem otro in chkPadecimientos.Items)
                    {
                        if (otro.Selected == true)
                        {
                            if (otro.Value == "9" && txtOtroPadecimiento.Text == string.Empty)
                            {
                                throw new ApplicationException("Captura el Otro Padecimiento");
                            }
                        }
                    }
                }

                else
                {
                    throw new ApplicationException("Selecciona por lo menos un tipo de Padecimiento");
                }

                if (chkCategorias.SelectedValue == string.Empty)
                {
                    throw new ApplicationException("Selecciona por lo menos una categoría por la que visitas Farmacias Benavides");
                }
                else
                {
                    EntCuestionarioInicial ent = new EntCuestionarioInicial();

                    if (Session["UsuarioCC"].ToString() == "WEB")
                    {
                        ent.usuario = "WEB";
                        ent.tarjeta = Session["Usuario"].ToString();
                    }
                    else
                    {
                        ent.usuario = Session["UsuarioCC"].ToString();
                        ent.tarjeta = Session["Tarjeta"].ToString(); ;
                    }

                    ent.tieneHijos = Convert.ToInt32(rdoHijos.SelectedValue);
                    ent.NoPersonas = Convert.ToInt32(txtCuantos.Text);
                    //ent.NoHijos = Convert.ToInt32(txtNoHijos.Text);
                    //ent.tienePadecimientoCronico = Convert.ToInt32(ddlPadecimiento.SelectedValue);

                    StringBuilder strCadena = new StringBuilder();

                    strCadena.Append("<RespXML>");

                    foreach (ListItem pad in chkPadecimientos.Items)
                    {
                        if (pad.Selected == true)
                        {
                            if (pad.Value == "9")
                            {
                                strCadena.Append("<id>");
                                strCadena.Append("<Preg>");
                                strCadena.Append("11");
                                strCadena.Append("</Preg>");
                                strCadena.Append("<Resp>");
                                strCadena.Append(pad.Value);
                                strCadena.Append("</Resp>");
                                strCadena.Append("<Otro>");
                                strCadena.Append(txtOtroPadecimiento.Text);
                                strCadena.Append("</Otro>");
                                strCadena.Append("</id>");
                            }
                            else
                            {
                                strCadena.Append("<id>");
                                strCadena.Append("<Preg>");
                                strCadena.Append("11");
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

                    foreach (ListItem cat in chkCategorias.Items)
                    {
                        if (cat.Selected == true)
                        {
                            strCadena.Append("<id>");
                            strCadena.Append("<Preg>");
                            strCadena.Append("12");
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

                    strCadena.Append("<id>");
                    strCadena.Append("<Preg>");
                    strCadena.Append("13");
                    strCadena.Append("</Preg>");
                    strCadena.Append("<Resp>");
                    strCadena.Append(ddlEstadoCivil.SelectedValue);
                    strCadena.Append("</Resp>");
                    strCadena.Append("<Otro>");
                    strCadena.Append("");
                    strCadena.Append("</Otro>");
                    strCadena.Append("</id>");

                    foreach (ListItem medio in chkMedio.Items)
                    {
                        if (medio.Selected == true)
                        {
                            strCadena.Append("<id>");
                            strCadena.Append("<Preg>");
                            strCadena.Append("14");
                            strCadena.Append("</Preg>");
                            strCadena.Append("<Resp>");
                            strCadena.Append(medio.Value);
                            strCadena.Append("</Resp>");
                            strCadena.Append("<Otro>");
                            strCadena.Append("");
                            strCadena.Append("</Otro>");
                            strCadena.Append("</id>");
                        }
                    }

                    strCadena.Append("</RespXML>");

                    ent.xmlDetalle = strCadena.ToString();

                    DataSet dsRegresaEncuesta = cliente.RegistroPrimeraVezV2(ent);

                    EntActualizarCliente entA = new EntActualizarCliente();

                    entA.IdCliente = Session["Usuario"].ToString();
                    entA.TelefonoCelular = txtCelular.Text;
                    entA.idSexo = Convert.ToInt32(rdoGenero.SelectedValue);
                    entA.CorreoElectronico = txtMail.Text.Trim() + '@' + txtDominio.Text.Trim();
                    entA.fechaNacimiento = ddlAno.SelectedValue + ddlMes.SelectedValue + ddlDia.SelectedValue;

                    foreach (ListItem domicilio in chkMedio.Items)
                    {
                        if (domicilio.Selected == true)
                        {
                            if (domicilio.Value == "1")
                            {
                                entA.Calle = txtActCalle.Text;
                                entA.NoExterior = txtExterior.Text;
                                entA.NoInterior = txtInterior.Text;
                                entA.idEstado = ddlEstado.SelectedValue;
                                entA.idMunicipio = ddlMunicipio.SelectedValue;
                                entA.idColonia = ddlColonia.SelectedValue;
                                entA.CP = txtCP.Text;
                            }
                            else
                            {
                                if (txtCPVisible.Text == string.Empty || ddlColonia.SelectedValue == string.Empty)
                                {
                                    entA.Calle = "";
                                    entA.NoExterior = "";
                                    entA.NoInterior = "";
                                    entA.idEstado = "0";
                                    entA.idMunicipio = "0";
                                    entA.idColonia = "0";
                                    entA.CP = "";
                                }
                                else
                                {
                                    entA.Calle = txtCalleOculto.Text;
                                    entA.NoExterior = txtExtOculto.Text;
                                    entA.NoInterior = txtIntOculto.Text;
                                    entA.idEstado = ddlEstadoOculto.SelectedValue;
                                    entA.idMunicipio = ddlMunicipioOculto.SelectedValue;
                                    entA.idColonia = ddlColoniaVisible.SelectedValue;
                                    entA.CP = txtCPVisible.Text;
                                }
                            }
                        }
                    }

                    DataSet dsRegresa = cliente.ActualizandoClienteEncuesta(entA);

                    if (dsRegresa.Tables[0].Rows.Count > 0 && dsRegresaEncuesta.Tables[0].Rows.Count > 0)
                    {
                        string respuesta = dsRegresa.Tables[0].Rows[0]["CodigoRespuesta_StrCodigo"].ToString();
                        if (respuesta == "AW9901")
                        {
                            string Mensaje = "Se han actualizado los datos de manera exitosa.";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "');window.location.href='MisDatos.aspx'", true);
                        }
                        else
                        {
                            string mensaje = dsRegresa.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString();
                            if (respuesta == "AW2005")
                            {
                                string Mensaje = mensaje;
                                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "');window.location.href='MisDatos.aspx'", true);
                            }
                            else
                            {
                                string Mensaje = mensaje;
                                //Mensajes(mensaje);
                                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "');window.location.href='MisDatos.aspx'", true);
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

        protected void txtCPVisible_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarCatalogo("estado", ddlEstadoOculto, "", "");
                CargarCatalogoCPColonia("CPEncuesta", ddlColoniaVisible, txtCPVisible.Text, "");
                ddlColoniaVisible.Enabled = true;
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void chkMedio_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListItem domicilio in chkMedio.Items)
            {
                if (domicilio.Selected == true)
                {
                    if (domicilio.Value == "1")
                    {
                        pnlDomicilio.Visible = true;
                        pnlVisible.Visible = false;
                    }
                    else
                    {
                        pnlDomicilio.Visible = false;
                        pnlVisible.Visible = true;
                    }
                }
            }
        }





    }
}