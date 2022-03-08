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

namespace WebPfizer.LMS.eCard
{
    public partial class ActualizarMisDatos : System.Web.UI.Page
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

                CargarCatalogo("estado", ddlActEstado, "", "");
                lblAntNoTarjeta.Text = Session["Usuario"].ToString();
                CargarCataloSexo();

                CargarCatalogoAno(DateTime.Today.Year, 1900, ddlActAno);
                CargarCatalogoMes(1, 12, ddlActMes);

                LlenarMisDatos();
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

        protected void CargarCataloSexo()
        {
            EntActualizarCliente eac = new EntActualizarCliente();

            ddlActSexo.DataTextField = "Sexo";
            ddlActSexo.DataValueField = "idSexo";
            ddlActSexo.DataSource = cliente.ListaCatalogoSexo(eac);
            ddlActSexo.DataBind();
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlActEstado.SelectedValue == "00")
            {
                ddlActMunicipio.Items.Clear();
                ddlActColonia.Items.Clear();
                ddlActMunicipio.Enabled = false;
                ddlActColonia.Enabled = false;
                txtActCP.Text = string.Empty;
            }
            else
            {
                ddlActMunicipio.Enabled = true;
                ddlActColonia.Items.Clear();
                ddlActColonia.Enabled = false;
                txtActCP.Text = string.Empty;
                CargarCatalogo("Municipio", ddlActMunicipio, ddlActEstado.SelectedValue.ToString(), "");
            }
        }

        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlActMunicipio.SelectedValue == "00")
            {
                txtActCP.Text = string.Empty;
                ddlActColonia.Items.Clear();
                ddlActColonia.Enabled = false;
            }
            else
            {
                ddlActColonia.Enabled = true;
                CargarCatalogo("Colonia", ddlActColonia, ddlActEstado.SelectedValue.ToString(), ddlActMunicipio.SelectedValue.ToString());
            }
        }

        protected void ddlColonia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlActColonia.SelectedValue == "00")
            {
                txtActCP.Text = string.Empty;
            }
            else
            {
                CargarCodigoP("Colonia", ddlActColonia, ddlActEstado.SelectedValue.ToString(), ddlActMunicipio.SelectedValue.ToString());
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
                        if (objDataset.Tables[0].Rows[i]["IDColonia"].ToString() == ddlActColonia.SelectedValue.ToString())
                        {
                            txtActCP.Text = objDataset.Tables[0].Rows[i]["CP"].ToString();
                        }
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

        protected void lnkActualizarMisDatos_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlActSexo.SelectedValue == "3")
                {
                    throw new ApplicationException("Selecciona Género");
                }
                if (ddlActAno.SelectedValue == "1900" || ddlActMes.SelectedValue == "00" || ddlActDia.SelectedValue == "00")
                {
                    throw new ApplicationException("Selecciona Fecha de Nacimiento correcta");
                }

                int fechaAño = Convert.ToInt32(ddlActAno.SelectedValue);
                if (fechaAño < 1915 || fechaAño > 2001)
                {
                    throw new ApplicationException("Captura un año de Nacimiento valido, este debe ser menor a 2001 y mayor a 1915");
                }

                EntActualizarCliente ent = new EntActualizarCliente();

                ent.IdCliente = Session["Usuario"].ToString();
                ent.Telefono = txtActTelefono.Text;
                ent.TelefonoCelular = txtActCelular.Text;
                ent.Calle = txtActCalle.Text;
                ent.NoExterior = txtActNumExterior.Text;
                ent.NoInterior = txtActNumInterior.Text;
                ent.idEstado = ddlActEstado.SelectedValue;
                ent.idMunicipio = ddlActMunicipio.SelectedValue;
                ent.idColonia = ddlActColonia.SelectedValue;
                ent.CP = txtActCP.Text;
                ent.idSexo = Convert.ToInt32(ddlActSexo.SelectedValue);
                ent.CorreoElectronico = txtActCorreoElectronico.Text;
                ent.fechaNacimiento = ddlActAno.SelectedItem.Text + ddlActMes.SelectedValue.ToString() + ddlActDia.SelectedItem.Text;

                DataSet dsRegresa = cliente.ActualizandoCliente(ent);

                if (dsRegresa.Tables[0].Rows.Count > 0)
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
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void lnkCancelarMisDatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisDatos.aspx");
        }

        protected void LlenarMisDatos()
        {
            try
            {
                EntActualizarCliente ent = new EntActualizarCliente();
                DataSet datos = new DataSet();

                ent.IdCliente = Session["Usuario"].ToString();
                datos = cliente.MisDatosCliente(ent);

                txtActTelefono.Text = datos.Tables[0].Rows[0]["Cliente_strTelefonoCasa"].ToString();
                txtActCelular.Text = datos.Tables[0].Rows[0]["Cliente_strTelefonoCelular"].ToString();
                txtActCorreoElectronico.Text = datos.Tables[0].Rows[0]["Cliente_strCorreoElectronico"].ToString();
                txtActCalle.Text = datos.Tables[0].Rows[0]["Cliente_strCalle"].ToString();
                txtActNumInterior.Text = datos.Tables[0].Rows[0]["Cliente_strNumeroInterior"].ToString();
                txtActNumExterior.Text = datos.Tables[0].Rows[0]["Cliente_strNumeroExterior"].ToString();
                txtActCP.Text = datos.Tables[0].Rows[0]["Cliente_strCodigoPostal"].ToString();

                if (datos.Tables[0].Rows[0]["Cliente_intSexo"].ToString() != string.Empty)
                {
                    if (datos.Tables[0].Rows[0]["Cliente_intSexo"].ToString() == "0")
                    {
                        ddlActSexo.SelectedValue = "3";
                    }
                    else
                    {
                        ddlActSexo.SelectedValue = datos.Tables[0].Rows[0]["Cliente_intSexo"].ToString();
                    }
                }

                string fechaNacimiento = datos.Tables[0].Rows[0]["FechaNacimiento"].ToString();
                string anoFN = fechaNacimiento.Substring(0, 4);
                string mesFN = fechaNacimiento.Substring(4, 2);
                string diaFN = fechaNacimiento.Substring(6, 2);

                if (datos.Tables[0].Rows[0]["FNano"].ToString() == string.Empty)
                {
                    ddlActAno.SelectedValue = "1900";
                }
                else
                {
                    ddlActAno.SelectedValue = anoFN;
                }

                if (datos.Tables[0].Rows[0]["FNmes"].ToString() == string.Empty)
                {
                    ddlActMes.SelectedValue = "01";
                }
                else
                {
                    ddlActMes.SelectedValue = mesFN;
                }

                int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlActAno.SelectedValue), Convert.ToInt32(ddlActMes.SelectedValue));
                CargarCatalogoDia(1, diasxmes, ddlActDia);

                if (datos.Tables[0].Rows[0]["FNdia"].ToString() == string.Empty)
                {
                    ddlActDia.SelectedValue = "01";
                }
                else
                {
                    ddlActDia.SelectedValue = diaFN;
                }

                ddlActEstado.SelectedValue = datos.Tables[0].Rows[0]["Cliente_intEstado"].ToString();
                CargarCatalogo("Municipio", ddlActMunicipio, ddlActEstado.SelectedValue.ToString(), "");

                ddlActMunicipio.SelectedValue = datos.Tables[0].Rows[0]["Cliente_intDelegMunicipio"].ToString();
                CargarCatalogo("Colonia", ddlActColonia, ddlActEstado.SelectedValue.ToString(), ddlActMunicipio.SelectedValue.ToString());

                ddlActColonia.SelectedValue = datos.Tables[0].Rows[0]["Cliente_intColonia"].ToString();
            }
            catch (Exception msg)
            {
                Mensajes(msg.Message);
            }
        }

        protected void lnkurl_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisDatos.aspx");
        }

        //Los siguientes metodos llenan combos de fecha
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

        protected void ddlActAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlActAno.SelectedValue == "00")
            {
                ddlActMes.Items.Clear();
                ddlActMes.Items.Add(new ListItem("Selecciona", "00"));
                ddlActMes.Enabled = false;
                ddlActDia.Items.Clear();
                ddlActDia.Items.Add(new ListItem("Selecciona", "00"));
                ddlActDia.Enabled = false;
            }
            else
            {
                CargarCatalogoMes(1, 12, ddlActMes);
                ddlActMes.Enabled = true;
                ddlActDia.Items.Clear();
                ddlActDia.Items.Add(new ListItem("Selecciona", "00"));
                ddlActDia.Enabled = false;
            }
        }

        protected void ddlActMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlActMes.SelectedValue == "00")
            {
                ddlActDia.Items.Clear();
                ddlActDia.Items.Add(new ListItem("Selecciona", "00"));
                ddlActDia.Enabled = false;
            }
            else
            {
                ddlActDia.Enabled = true;

                int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlActAno.SelectedValue), Convert.ToInt32(ddlActMes.SelectedValue));

                CargarCatalogoDia(1, diasxmes, ddlActDia);
            }
        }


    }
}