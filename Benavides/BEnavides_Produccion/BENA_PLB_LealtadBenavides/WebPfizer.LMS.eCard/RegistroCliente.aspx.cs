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

    public partial class RegistroCliente : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnCancelar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/botones/cancelar-btn-over.png'");
                btnCancelar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/botones/cancelar-btn.png'");

                btnRegistrar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/botones/registrar-btn-over.png'");
                btnRegistrar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/botones/registrar-btn.png'");

                CargarCatalogoGenero(ddlGenero);
                CargarCatalogo("estado", ddlEstado, "", "");
                
                CargarCatalogoAno(DateTime.Today.Year, 1900, ddlAno);
                CargarCatalogoMes(1, 12, ddlMes);
                ddlDia.Items.Add(new ListItem("--Selecciona--", "00"));
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
                ControlCombo.SelectedValue = "3";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }

        protected void CargarCatalogoFechas(string Catalogo, DropDownList ControlCombo)
        {
            try
            {
                objDataset = objConsultaDatos.CargaComboFecha(Catalogo);
                ControlCombo.Items.Clear();
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));
                    for (int i = 0; i <= objDataset.Tables[0].Rows.Count - 1; i++)
                    {
                        ListItem Item = new ListItem();
                        int a = objDataset.Tables[0].Rows[0][0].ToString().Length;
                        if (objDataset.Tables[0].Rows[i][0].ToString().Length == 1)
                        {
                            Item.Value = objDataset.Tables[0].Rows[i][0].ToString();
                            Item.Text = "0" + objDataset.Tables[0].Rows[i][0].ToString();
                        }
                        else
                        {
                            Item.Value = objDataset.Tables[0].Rows[i][0].ToString();
                            Item.Text = objDataset.Tables[0].Rows[i][0].ToString();
                        }
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

        protected void btnRegistrar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (lblClicValida.Text != "ClicOK")
                {
                    Mensajes("Da clic en Validar Tarjeta  para poder iniciar el Registro");
                }
                else
                {
                    if (txtTarjeta.Text.Trim() == string.Empty || txtNombre.Text.Trim() == string.Empty || txtAP.Text.Trim() == string.Empty || txtAM.Text.Trim() == string.Empty || ddlDia.SelectedValue == "00" || ddlMes.SelectedValue == "00" || ddlAno.SelectedValue == "00" || ddlGenero.SelectedValue == "3" || txtContraseña.Text == String.Empty || txtCorreo.Text.Trim() == string.Empty)
                    {
                        if (txtTarjeta.Text.Trim() == string.Empty)
                        {
                            lblValidaTarjeta.Visible = true;
                            Mensajes("Captura número de Tarjeta");
                        }
                        else
                        {
                            lblValidaTarjeta.Visible = false;
                        }

                        if (txtNombre.Text.Trim() == string.Empty || txtAP.Text.Trim() == string.Empty || txtAM.Text.Trim() == string.Empty)
                        {
                            lblValidaAP.Visible = true;
                            lblValidaAM.Visible = true;
                            lblValidaNombre.Visible = true;
                            Mensajes("Captura Nombre y Apellidos");
                        }
                        else
                        {
                            lblValidaAP.Visible = false;
                            lblValidaAM.Visible = false;
                            lblValidaNombre.Visible = false;
                        }

                        if (txtContraseña.Text.Trim() == String.Empty && txtConfirmaContra.Text.Trim() == String.Empty)
                        {
                            lblValidaContraseña.Visible = true;
                            lblValidaConfirmaContraseña.Visible = true;
                            Mensajes("Captura Contraseña y confirmación de contraseña");
                        }
                        else
                        {
                            lblValidaContraseña.Visible = true;
                            lblValidaConfirmaContraseña.Visible = true;
                        }

                        if (ddlAno.SelectedValue == "00" || ddlMes.SelectedValue == "00" || ddlDia.SelectedValue == "00")
                        {
                            Mensajes("Selecciona la fecha completa");
                            lblValidaFecha.Visible = true;
                        }
                        else
                        {
                            lblValidaFecha.Visible = false;
                        }

                        if (ddlGenero.SelectedValue == "3")
                        {
                            Mensajes("Selecciona Genero");
                            lblValidaGenero.Visible = true;
                        }
                        else
                        {
                            lblValidaGenero.Visible = false;
                        }

                        //DATOS DE CONTACTO
                        //if (txtCelular.Text == String.Empty || txtConfirmaCorreo.Text == String.Empty)
                        if (txtConfirmaCorreo.Text == String.Empty)
                        {
                            //lblValidaCelular.Visible = true;
                            lblValidaCorreo.Visible = true;
                            //Mensajes("Captura los datos de contacto (Celular y Correo electrónico)");
                            Mensajes("Captura los datos de contacto Correo electrónico");
                        }
                        else
                        {
                            //lblValidaCelular.Visible = false;
                            lblValidaCorreo.Visible = false;
                        }

                        //DIRECCION                        
                        //if (txtCalle.Text.Trim() == String.Empty || txtNumExterior.Text.Trim() == String.Empty || ddlEstado.SelectedValue == "00" || ddlMunicipio.SelectedValue == "00" || ddlColonia.SelectedValue == "00")
                        //{
                        //    lblValidaCalle.Visible = true;
                        //    lblValidaExterior.Visible = true;
                        //    lblValidaEstado.Visible = true;
                        //    lblValidaMunicipio.Visible = true;
                        //    lblValidaColonia.Visible = true;
                        //    Mensajes("Captura dirección completa");               
                        //}
                        //else
                        //{
                        //    lblValidaCalle.Visible = false;
                        //    lblValidaExterior.Visible = false;
                        //    lblValidaEstado.Visible = false;
                        //    lblValidaMunicipio.Visible = false;
                        //    lblValidaColonia.Visible = false;
                        //}
                    }
                    else
                    {
                        //if (txtCelular.Text.Trim() == string.Empty && txtCorreo.Text.Trim() == string.Empty)
                        //{
                        //lblValidaCelular.Visible = true;
                        //lblValidaCorreo.Visible = true;
                        //Mensajes("Debes captura al menos un dato de contacto (Celular o Correo electrónico)");
                        //}
                        //else
                        //{
                        //lblValidaCelular.Visible = false;
                        //lblValidaCorreo.Visible = false;
                        //}

                        if (txtContraseña.Text == txtConfirmaContra.Text)
                        {
                            string fecha_formato = ddlAno.SelectedItem.Text + ddlMes.SelectedValue.ToString() + ddlDia.SelectedItem.Text;

                            int estado, municipio, colonia;

                            if (ddlEstado.SelectedValue == "00" || ddlMunicipio.SelectedValue == "00" || ddlColonia.SelectedValue == "00")
                            {
                                estado = 0;
                                municipio = 0;
                                colonia = 0;
                            }
                            else
                            {
                                estado = Convert.ToInt32(ddlEstado.SelectedValue);
                                municipio = Convert.ToInt32(ddlMunicipio.SelectedValue);
                                colonia = Convert.ToInt32(ddlColonia.SelectedValue);
                            }

                            objDataset = cliente.RegistraCliente("Admin", txtNombre.Text, txtAP.Text, txtAM.Text, fecha_formato, txtCorreo.Text, txtTelefono.Text, txtCelular.Text, Convert.ToInt32(ddlGenero.SelectedValue), txtCalle.Text, txtNumExterior.Text, txtNumInterior.Text, colonia, municipio, estado, txtCP.Text, txtTarjeta.Text, txtContraseña.Text, "","","","","","");
                            if (objDataset.Tables[0].Rows.Count > 0)
                            {
                                string respuesta = objDataset.Tables[0].Rows[0]["CodigoRespuesta_StrCodigo"].ToString();
                                if (respuesta == "AW9901")
                                {
                                    String Script = String.Format(@"alert('El registro se realizo de manera exitosa. Se te ha enviado un correo con Usuario y Contraseña para acceder al portal. Favor de verificar tu correo');
                                window.location.href='Acceso.aspx'", false);

                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", Script, true);
                                }
                                else
                                {
                                    string mensaje = objDataset.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString();
                                    if (respuesta == "AW2005")
                                    {
                                        String Script = String.Format(@"alert('" + mensaje + "');window.location.href='Acceso.aspx'", false);

                                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", Script, true);
                                    }
                                    else
                                    {
                                        Mensajes(mensaje);
                                    }
                                }
                            }
                            else
                            {
                                Mensajes("Error al ejecutar el proceso de Registro");
                            }
                        }
                        else
                        {
                            Mensajes("La contraseña y la confirmación de contraseña no coinciden");
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

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Acceso.aspx");
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

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                lblClicValida.Text = "ClicOK";

                if (txtTarjeta.Text != string.Empty)
                {
                    DataSet objvalida = new DataSet();
                    objvalida = cliente.ValidaTarjeta(txtTarjeta.Text);

                    if (objvalida.Tables[0].Rows[0]["Error"].ToString() == "1")
                    {
                        Mensajes("Tarjeta inexistente");
                        txtAP.Enabled = false;
                        txtAM.Enabled = false;
                        txtNombre.Enabled = false;
                        ddlAno.Enabled = false;
                        ddlGenero.Enabled = false;
                        txtTelefono.Enabled = false;
                        txtCelular.Enabled = false;
                        txtCorreo.Enabled = false;
                        txtCalle.Enabled = false;
                        txtNumExterior.Enabled = false;
                        txtNumInterior.Enabled = false;
                        ddlEstado.Enabled = false;
                        txtCP.Enabled = false;
                        txtContraseña.Enabled = false;
                        txtConfirmaContra.Enabled = false;
                        btnRegistrar.Enabled = false;
                    }
                    else if (objvalida.Tables[0].Rows[0]["Error"].ToString() == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('“La tarjeta  ya se encuentra registrada \\n Favor de ingresar la contraseña correspondiente en la página de inicio”'); window.location='Acceso.aspx';", true);
                    }
                    else if (objvalida.Tables[0].Rows[0]["Error"].ToString() == "2")
                    {
                        Mensajes("Tarjeta sin registro previo, favor de capturar datos");
                        if (objvalida.Tables[0].Rows[0]["Cliente_strApellidoPaterno"].ToString() == "")
                        {
                            txtAP.Enabled = true;
                            txtAP.Text = "";
                        }
                        else
                        {
                            txtAP.Enabled = false;
                            txtAP.Text = objvalida.Tables[0].Rows[0]["Cliente_strApellidoPaterno"].ToString();
                        }

                        if (objvalida.Tables[0].Rows[0]["Cliente_strApellidoMaterno"].ToString() == "")
                        {
                            txtAM.Enabled = true;
                            txtAM.Text = "";
                        }
                        else
                        {
                            txtAM.Enabled = false;
                            txtAM.Text = objvalida.Tables[0].Rows[0]["Cliente_strApellidoMaterno"].ToString();
                        }

                        if (objvalida.Tables[0].Rows[0]["Cliente_strPrimerNombre"].ToString() == "")
                        {
                            txtNombre.Enabled = true;
                            txtNombre.Text = "";
                        }
                        else
                        {
                            txtNombre.Enabled = false;
                            txtNombre.Text = objvalida.Tables[0].Rows[0]["Cliente_strPrimerNombre"].ToString();
                        }

                        //string fecha_nacimiento = objvalida.Tables[0].Rows[0]["Fecha_Nacimiento"].ToString();
                        //string año = fecha_nacimiento.Substring(0, 4);
                        //string mes = fecha_nacimiento.Substring(4, 2);
                        //string dia = fecha_nacimiento.Substring(6, 2);
                        
                        ddlAno.Enabled = true;
                        //ddlAno.SelectedValue =  año;
                        ddlMes.Enabled = true;
                        //ddlMes.SelectedItem.Text = mes;
                        ddlDia.Enabled = true;
                        //ddlDia.SelectedItem.Text = dia;

                        ddlGenero.Enabled = true;
                        txtTelefono.Enabled = true;
                        txtCelular.Enabled = true;
                        txtCorreo.Enabled = true;
                        txtCalle.Enabled = true;
                        txtNumExterior.Enabled = true;
                        txtNumInterior.Enabled = true;
                        ddlEstado.Enabled = true;
                        txtCP.Enabled = true;
                        txtContraseña.Enabled = true;
                        txtConfirmaContra.Enabled = true;
                        btnRegistrar.Enabled = true;
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

        protected void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            if (txtCorreo.Text != "")
            {
                ValidatorMail.Enabled = true;
                txtConfirmaCorreo.Enabled = true;
                ValidatorComparaMail.Enabled = true;
            }
            else
            {
                ValidatorMail.Enabled = false;
                txtConfirmaCorreo.Enabled = false;
                ValidatorComparaMail.Enabled = false;
            }
        }


    }
}
