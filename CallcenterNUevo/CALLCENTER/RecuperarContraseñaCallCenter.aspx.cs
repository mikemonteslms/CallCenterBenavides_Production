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
using Datos;
using Entidades;

namespace Portal_Benavides
{
    public partial class RecuperarContraseñaCallCenter : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();
        DatActualizarCliente datos = new DatActualizarCliente();
        EntActualizarCliente ent = new EntActualizarCliente();


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UsuarioCC"] == null)
            //{
            //    FormsAuthentication.SignOut();
            //    FormsAuthentication.RedirectToLoginPage();
            //    return;
            //}
            if (!IsPostBack)
            {
                btnCancelar.Attributes.Add("onmouseover", "this.src='../Imagenes_Benavides/botones/cancelar-btn-over.png'");
                btnCancelar.Attributes.Add("onmouseout", "this.src='../Imagenes_Benavides/botones/cancelar-btn.png'");

                btnEnviar.Attributes.Add("onmouseover", "this.src='../Imagenes_Benavides/botones/enviar-btn-over.png'");
                btnEnviar.Attributes.Add("onmouseout", "this.src='../Imagenes_Benavides/botones/enviar-btn.png'");

                CargarCatalogoGenero(ddlGenero);
                CargarCatalogo("estado", ddlEstado, "", "");
                CargarCatalogoAno(DateTime.Today.Year, 1900, ddlAno);
                CargarCatalogoMes(1, 12, ddlMes);
                ddlDia.Items.Add(new ListItem("Selecciona", "00"));
                dvConfirma.Visible = false;
            }
            else
            {
                dvConfirma.Visible = true;
                mpeConfirma.Show();
            }
            Master.MenuMain = "Clientes";
            Master.Submenu = "Recuperar Contraseña";
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
            catch
            {

            }
        }

        protected void CargarCatalogoGenero(DropDownList ControlCombo)
        {
            try
            {
                objDataset = objConsultaDatos.CargaComboGenero();
                ControlCombo.Items.Clear();
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    //ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));
                    for (int i = 0; i <= objDataset.Tables[0].Rows.Count - 1; i++)
                    {
                        ListItem Item = new ListItem();
                        Item.Value = objDataset.Tables[0].Rows[i]["Clave"].ToString();
                        Item.Text = objDataset.Tables[0].Rows[i]["Genero"].ToString();
                        ControlCombo.Items.Add(Item);
                    }
                }
            }
            catch
            {

            }
        }

        protected void CargarCatalogoAno(int final, int inicial, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));

                for (int i = final; i >= inicial; i--)
                {
                    ListItem Item = new ListItem();
                    Item.Value = i.ToString();
                    Item.Text = i.ToString();
                    ControlCombo.Items.Add(Item);
                }

            }
            catch
            {

            }
        }

        protected void CargarCatalogoDia(int inicial, int final, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));


                for (int i = inicial; i <= final; i++)
                {
                    ListItem Item = new ListItem();

                    Item.Value = i.ToString();
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
            catch
            {

            }
        }

        protected void CargarCatalogoMes(int inicial, int final, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));


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
            catch
            {

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
            catch
            {

            }
        }

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

        protected void ddlColonia_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void ddlAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAno.SelectedValue == "00")
            {
                ddlMes.Items.Clear();
                ddlMes.Items.Add(new ListItem("Seleccione", "00"));
                ddlMes.Enabled = false;
                ddlDia.Items.Clear();
                ddlDia.Items.Add(new ListItem("Seleccione", "00"));
                ddlDia.Enabled = false;
            }
            else
            {
                CargarCatalogoMes(1, 12, ddlMes);
                ddlMes.Enabled = true;
                ddlDia.Items.Clear();
                ddlDia.Items.Add(new ListItem("Seleccione", "00"));
                ddlDia.Enabled = false;
            }
        }

        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMes.SelectedValue == "00")
            {
                ddlDia.Items.Clear();
                ddlDia.Items.Add(new ListItem("--Selecciona--", "00"));
                ddlDia.Enabled = false;
            }
            else
            {
                ddlDia.Enabled = true;

                int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAno.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue));

                CargarCatalogoDia(1, diasxmes, ddlDia);

            }
        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            dvConfirma.Visible = false;
            try
            {
                if (txtTarjeta.Text != string.Empty)
                {
                    if (txtTarjeta.Text.Length > 11) //if (txtTarjeta.Text.Length != 11)                    
                    {
                        throw new ApplicationException("Número de Tarjeta inválido");
                    }
                    else
                    {
                        lblTarjetaEnvio.Text = txtTarjeta.Text;
                        DataSet objvalida = new DataSet();
                        objvalida = cliente.ValidaTarjeta(txtTarjeta.Text);
                        //if (objvalida.Tables[0].Rows.Count > 0)
                        if (objvalida.Tables[0].Rows[0]["Error"].ToString() == "0")
                        {
                            txtAP.Text = objvalida.Tables[0].Rows[0]["Cliente_strApellidoPaterno"].ToString();
                            txtAM.Text = objvalida.Tables[0].Rows[0]["Cliente_strApellidoMaterno"].ToString();
                            txtNombre.Text = objvalida.Tables[0].Rows[0]["Cliente_strPrimerNombre"].ToString();
                            txtTelefono.Text = objvalida.Tables[0].Rows[0]["Cliente_strTelefonoCasa"].ToString();
                            txtCelular.Text = objvalida.Tables[0].Rows[0]["Cliente_strTelefonoCelular"].ToString();
                            txtCorreo.Text = objvalida.Tables[0].Rows[0]["Cliente_strCorreoElectronico"].ToString();
                            lblCorreoEnvio.Text = objvalida.Tables[0].Rows[0]["Cliente_strCorreoElectronico"].ToString();
                            txtCalle.Text = objvalida.Tables[0].Rows[0]["Cliente_strCalle"].ToString();
                            txtNumInterior.Text = objvalida.Tables[0].Rows[0]["Cliente_strNumeroInterior"].ToString();
                            txtNumExterior.Text = objvalida.Tables[0].Rows[0]["Cliente_strNumeroExterior"].ToString();
                            txtCP.Text = objvalida.Tables[0].Rows[0]["Cliente_strCodigoPostal"].ToString();
                            string fecha_nacimiento = objvalida.Tables[0].Rows[0]["Fecha_Nacimiento"].ToString();
                            string dia = fecha_nacimiento.Substring(0, 2);
                            string mes = fecha_nacimiento.Substring(3, 2);
                            string año = fecha_nacimiento.Substring(6, 4);

                            if (objvalida.Tables[0].Rows[0]["Cliente_intSexo"].ToString() != string.Empty)
                            {
                                string genero = objvalida.Tables[0].Rows[0]["Cliente_intSexo"].ToString();
                                if (genero == "0")
                                {
                                    ddlGenero.SelectedValue = "3";
                                }
                                else
                                {
                                    ddlGenero.SelectedValue = genero;
                                }
                            }
                            if (objvalida.Tables[0].Rows[0]["Cliente_intEstado"].ToString() != string.Empty)
                            {
                                ddlEstado.SelectedValue = objvalida.Tables[0].Rows[0]["Cliente_intEstado"].ToString();
                                CargarCatalogo("Municipio", ddlMunicipio, ddlEstado.SelectedValue.ToString(), "");
                            }
                            if (objvalida.Tables[0].Rows[0]["Cliente_intDelegMunicipio"].ToString() != string.Empty)
                            {
                                ddlMunicipio.SelectedValue = objvalida.Tables[0].Rows[0]["Cliente_intDelegMunicipio"].ToString();
                                CargarCatalogo("Colonia", ddlColonia, ddlEstado.SelectedValue.ToString(), ddlMunicipio.SelectedValue.ToString());
                            }
                            if (objvalida.Tables[0].Rows[0]["Cliente_intColonia"].ToString() != string.Empty)
                            {
                                ddlColonia.SelectedValue = (objvalida.Tables[0].Rows[0]["Cliente_intColonia"].ToString() == "0") ? "00" : objvalida.Tables[0].Rows[0]["Cliente_intColonia"].ToString();
                                CargarCodigoP("Colonia", ddlColonia, ddlEstado.SelectedValue.ToString(), ddlMunicipio.SelectedValue.ToString());
                            }
                            if (Convert.ToInt32(año) < 1900 || Convert.ToInt32(año) > 2013)
                            {
                                ddlAno.SelectedValue = "1900";
                            }
                            else
                            {
                                ddlAno.SelectedValue = año;
                            }

                            ddlMes.SelectedValue = mes;

                            int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAno.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue));
                            CargarCatalogoDia(1, diasxmes, ddlDia);

                            ddlDia.SelectedValue = dia;

                            btnEnviar.Enabled = true;
                        }
                        else
                        {
                            //Mensajes("Tarjera sin registro previo, favor de capturar datos");
                            Mensajes(objvalida.Tables[0].Rows[0]["DescripcionError"].ToString());
                        }
                    }
                }
                else
                {
                    Mensajes("Captura el valor de la tarjeta");
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        private void Mensajes(string valorMensaje)
        {
            dvConfirma.Visible = false;
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            dvConfirma.Visible = false;
            Response.Redirect("~/Default.aspx");
        }

        protected void btnEnviar_Click(object sender, ImageClickEventArgs e)
        {
            mpeConfirma.Show();
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ent.Tipo = "1";
                ent.IdCliente = HttpContext.Current.User.Identity.Name;//Session["UsuarioCC"].ToString();
                ent.tarjeta = txtTarjeta.Text;
                ent.CorreoElectronico = txtCorreo.Text;

                DataSet dsRegresa = cliente.RecuperaContraseña(ent);

                if (dsRegresa.Tables[0].Rows.Count > 0)
                {
                    string Mensaje = dsRegresa.Tables[0].Rows[0]["CodigoError_strDescripcion"].ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "');window.location.href='../Default.aspx';", true);
                    dvConfirma.Visible = false;
                }
                else
                {
                    Mensajes("Error al ejecutar el proceso de Recuperación de contraseña");
                    dvConfirma.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            dvConfirma.Visible = false;
            Response.Redirect("RecuperarContraseñaCallCenter.aspx");
        }



    }
}
