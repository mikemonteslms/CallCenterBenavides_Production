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
using System.Globalization;

namespace WebPfizer.LMS.eCard
{
    public partial class RegistroCliente_EncuestaInicial : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Catalogos objConsultaDatos = new Catalogos();
        Clientes cliente = new Clientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtContra.Attributes.Add("value", txtContra.Text);
            txtConfirmaContra.Attributes.Add("value", txtConfirmaContra.Text);
            txtCelular.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
            //txtLADA.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
            txtCPVisible.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
            txtTarjeta.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");

            if (!IsPostBack)
            {
                //ImageButton boton1 = (ImageButton)Master.FindControl("imgBtnContacto");
                //boton1.ImageUrl = "~/Imagenes_Benavides/menu/contacto-btn.png";

                //CargarCataloSexo();

                

                btnCancelar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-regresar-hover.jpg'");
                btnCancelar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-regresar.jpg'");

                btnRegistrar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/8-registro/btn-aceptar-hover.jpg'");
                btnRegistrar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/8-registro/btn-aceptar.jpg'");

                CargarCatalogo("estado", ddlEstado, "", "");

                CargarCatalogoAno(DateTime.Today.Year, 1900, ddlAno);
                CargarCatalogoMes(1, 12, ddlMes);
                ddlDia.Items.Add(new ListItem("Día", "00"));               

                CargarCatalogoDominios(ddlDominios);

                CargarCatalogosCuestionarioInicial();
            }
        }

        protected void CargarCatalogoDominios(DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                ControlCombo.Items.Add(new ListItem("Selecciona", "0"));

                DataSet ds = new DataSet();
                ds = cliente.RegresaDominios();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem Item = new ListItem();
                    Item.Value = ds.Tables[0].Rows[i]["DominioCorreo_intID"].ToString();
                    Item.Text = ds.Tables[0].Rows[i]["DominioCorreo_strDominio"].ToString();
                    ControlCombo.Items.Add(Item);
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }
        protected void CargarCatalogoAno(int final, int inicial, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                ControlCombo.Items.Add(new ListItem("Año", "1900"));

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
                ControlCombo.Items.Add(new ListItem("Día", "00"));


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
                ControlCombo.Items.Add(new ListItem("Mes", "00"));

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
                Item1.Text = "Enero";
                ControlCombo.Items.Add(Item1);
                Item2.Value = "02";
                Item2.Text = "Febrero";
                ControlCombo.Items.Add(Item2);
                Item3.Value = "03";
                Item3.Text = "Marzo";
                ControlCombo.Items.Add(Item3);
                Item4.Value = "04";
                Item4.Text = "Abril";
                ControlCombo.Items.Add(Item4);
                Item5.Value = "05";
                Item5.Text = "Mayo";
                ControlCombo.Items.Add(Item5);
                Item6.Value = "06";
                Item6.Text = "Junio";
                ControlCombo.Items.Add(Item6);
                Item7.Value = "07";
                Item7.Text = "Julio";
                ControlCombo.Items.Add(Item7);
                Item8.Value = "08";
                Item8.Text = "Agosto";
                ControlCombo.Items.Add(Item8);
                Item9.Value = "09";
                Item9.Text = "Septiembre";
                ControlCombo.Items.Add(Item9);
                Item10.Value = "10";
                Item10.Text = "Octubre";
                ControlCombo.Items.Add(Item10);
                Item11.Value = "11";
                Item11.Text = "Noviembre";
                ControlCombo.Items.Add(Item11);
                Item12.Value = "12";
                Item12.Text = "Diciembre";
                ControlCombo.Items.Add(Item12);
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void CargarCatalogoMesFechaActual(int inicial, int final, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                ControlCombo.Items.Add(new ListItem("Mes", "00"));

                for (int i = inicial; i <= final; i++)
                {
                    string mes = MonthName(i);
                    mes = CapitalizeFirstLetter(mes);
                    ListItem Item = new ListItem();
                    if (i < 10)
                    {
                        Item.Value = "0" + i.ToString();
                    }
                    else
                    {
                        Item.Value = i.ToString();
                    }
                    Item.Text = mes.ToString();
                    ControlCombo.Items.Add(Item);
                }
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
                //ddlEstadoOculto.SelectedValue = objDataset.Tables[0].Rows[0]["IDEstado"].ToString();
                //CargarCatalogo("Municipio", ddlMunicipioOculto, ddlEstadoOculto.SelectedValue.ToString(), "");
                //ddlMunicipioOculto.SelectedValue = objDataset.Tables[0].Rows[0]["IDMunicipio"].ToString();
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
            try
            {
                CargarCatalogo("Municipio", ddlCiudad, ddlEstado.SelectedValue.ToString(), "");                
                ddlCiudad.Enabled = true;
            }
            catch
            { }
        }

        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlColonia_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
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
                        //if (objDataset.Tables[0].Rows[i]["IDColonia"].ToString() == ddlColonia.SelectedValue.ToString())
                        //{
                        //    txtCP.Text = objDataset.Tables[0].Rows[i]["CP"].ToString();
                        //}
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

                //ent.IdCliente = Session["Usuario"].ToString();
                datos = cliente.MisDatosCliente(ent);

                //txtActTelefono.Text = datos.Tables[0].Rows[0]["Cliente_strTelefonoCasa"].ToString();
                //txtCelular.Text = datos.Tables[0].Rows[0]["Cliente_strTelefonoCelular"].ToString();
                //txtMail.Text = datos.Tables[0].Rows[0]["Cliente_strCorreoElectronico"].ToString();
                //txtActCalle.Text = datos.Tables[0].Rows[0]["Cliente_strCalle"].ToString();
                //txtInterior.Text = datos.Tables[0].Rows[0]["Cliente_strNumeroInterior"].ToString();
                //txtExterior.Text = datos.Tables[0].Rows[0]["Cliente_strNumeroExterior"].ToString();
                //txtCP.Text = datos.Tables[0].Rows[0]["Cliente_strCodigoPostal"].ToString();

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
                //CargarCatalogo("Municipio", ddlMunicipio, ddlEstado.SelectedValue.ToString(), "");

                //ddlMunicipio.SelectedValue = datos.Tables[0].Rows[0]["Cliente_intDelegMunicipio"].ToString();
                //CargarCatalogo("Colonia", ddlColonia, ddlEstado.SelectedValue.ToString(), ddlMunicipio.SelectedValue.ToString());

                //ddlColonia.SelectedValue = datos.Tables[0].Rows[0]["Cliente_intColonia"].ToString();
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
                //EntCuestionarioInicial entPadecimiento = new EntCuestionarioInicial();
                //entPadecimiento.cuestionario = 2;
                //entPadecimiento.pregunta = 11;
                //chkPadecimientos.DataValueField = "IDRespuesta";
                //chkPadecimientos.DataTextField = "Respuesta";
                //chkPadecimientos.DataSource = cliente.ListaCatalogosCuestionarioInicial(entPadecimiento);
                //chkPadecimientos.DataBind();
                
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
                //ddlEstadoCivil.DataValueField = "IDRespuesta";
                //ddlEstadoCivil.DataTextField = "Respuesta";
                //ddlEstadoCivil.DataSource = cliente.ListaCatalogosCuestionarioInicial(entEstadoCivil);
                //ddlEstadoCivil.DataBind();

                //EntCuestionarioInicial entMedio = new EntCuestionarioInicial();
                //entPadecimiento.cuestionario = 2;
                //entPadecimiento.pregunta = 14;
                //chkMedio.DataValueField = "IDRespuesta";
                //chkMedio.DataTextField = "Respuesta";
                //chkMedio.DataSource = cliente.ListaCatalogosCuestionarioInicial(entPadecimiento);
                //chkMedio.DataBind();
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

       
        //REGISTRA DATOS

        protected void btnRegistrar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                if (txtTarjeta.Text.Trim() == string.Empty)
                {
                    throw new ApplicationException("Captura Tarjeta");
                }
                if (txtContra.Text.Trim() == string.Empty)
                {
                    throw new ApplicationException("Captura Contraseña");
                }
                if (txtConfirmaContra.Text.Trim() == string.Empty)
                {
                    throw new ApplicationException("Captura Confirmar contraseña");
                }
                if (txtNombre.Text.Trim() == string.Empty)
                {
                    throw new ApplicationException("Captura Nombre");
                }
                if (txtPaterno.Text.Trim() == string.Empty)
                {
                    throw new ApplicationException("Captura Apellido Paterno");
                }
                if (txtMaterno.Text.Trim() == string.Empty)
                {
                    throw new ApplicationException("Captura Apellido Materno");
                }
                if (txtMail.Text.Trim() == string.Empty)
                {
                    throw new ApplicationException("Captura correo electrónico");
                }
                if (ddlDominios.SelectedValue == "7" && txtDominio.Text == string.Empty)
                {
                    throw new ApplicationException("Captura dominio de correo electrónico");
                }
                if (ddlDominios.SelectedValue == "0")
                {
                    throw new ApplicationException("Seleccione dominio de correo electrónico");
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
                if (rblPeques.SelectedValue == "-1" || (rblPeques.SelectedValue == ""))
                {
                    throw new ApplicationException("Indicar Pertencer al club Peques");
                }
                if (rdoGenero.SelectedValue == "-1" || rdoGenero.SelectedValue == "")
                {
                    throw new ApplicationException("Indicar Género");
                }
                if (rdoHijos.SelectedValue == "-1" || rdoHijos.SelectedValue == "")
                {
                    throw new ApplicationException("Indicar tienes hijos");
                }
                else
                {
                    if (chkTerminos.Checked == false)
                    {
                        Mensajes("Debe aceptar Terminos y condiciones para continuar");
                    }
                    else
                    {
                        if (txtContra.Text == txtConfirmaContra.Text)
                        {
                            string estado = "0";
                            string ciudad = "0";
                            int dirValido = 0;
                            if (txtCPVisible.Text == string.Empty)
                            {
                                dirValido = 1;
                            }
                            else
                            {
                                DataSet dsCP = new DataSet();
                                dsCP = objConsultaDatos.DatosCatalogoSepoMex("CPEncuesta", txtCPVisible.Text, "");

                                if (dsCP != null && dsCP.Tables.Count > 0 && dsCP.Tables[0].Rows.Count > 0)
                                {
                                    if (dsCP.Tables[0].Rows[0]["IDEstado"].ToString() == ddlEstado.SelectedValue.ToString() && dsCP.Tables[0].Rows[0]["IDMunicipio"].ToString() == ddlCiudad.SelectedValue.ToString())
                                    {
                                        estado = ddlEstado.SelectedValue;
                                        ciudad = ddlCiudad.SelectedValue;
                                        dirValido = 1;
                                    }
                                    else
                                    {
                                        dirValido = 0;
                                    }

                                }
                                else
                                {
                                    dirValido = 0;
                                }

                            }

                            if (dirValido == 1)
                            {
                                string farmacia = "";
                                string SnacksBebidas = "";
                                string CuidadoPersonal = "";
                                string Bebes = "";
                                string Belleza = "";
                                string dominio = "";

                                if (ddlDominios.SelectedValue == "7")
                                {
                                    dominio = txtDominio.Text;
                                }
                                else
                                {
                                    dominio = ddlDominios.SelectedItem.Text.ToString();
                                }

                                foreach (ListItem cat in chkCategorias.Items)
                                {
                                    if (cat.Selected == true)
                                    {
                                        string caseSwitch = cat.Value;
                                        switch (caseSwitch)
                                        {
                                            case "1":
                                                farmacia = "1";
                                                break;
                                            case "2":
                                                SnacksBebidas = "1";
                                                break;
                                            case "3":
                                                CuidadoPersonal = "1";
                                                break;
                                            case "4":
                                                Bebes = "1";
                                                break;
                                            case "5":
                                                Belleza = "1";
                                                break;
                                            default:
                                                Console.WriteLine("Default case");
                                                break;
                                        }
                                    }
                                }

                                if (rblPeques.SelectedValue == "1")
                                {
                                    if (rblEmbarazo.SelectedValue == "-1" || rblEmbarazo.SelectedValue == "")
                                    {
                                        throw new ApplicationException("Selecciona ¿Estas Embarazada?");
                                    }
                                    if (rblTienesHijos.SelectedValue == "-1" || rblTienesHijos.SelectedValue == "")
                                    {
                                        throw new ApplicationException("Selecciona ¿Tienes hijos menores a 3 años?");
                                    }
                                    if (rblEmbarazo.SelectedValue == "1")
                                    {
                                        if (ddlAnoPeque.SelectedValue == "1900" || ddlMesPeque.SelectedValue == "00" || ddlDiaPeque.SelectedValue == "00")
                                        {
                                            throw new ApplicationException("Selecciona Fecha de Nacimiento correcta");
                                        }
                                    }
                                    if (ddlCuantosHijos.SelectedValue == "0" && rblTienesHijos.SelectedValue == "1")
                                    {
                                        throw new ApplicationException("Selecciona ¿Cuántos hijos menores a 3 años tienes?");
                                    }
                                    else
                                    {
                                        string fechaCuando = "19000101";
                                        string fechaNHijo1 = "19000101";
                                        string fechaNHijo2 = "19000101";
                                        string fechaNHijo3 = "19000101";
                                        string fechaNHijo4 = "19000101";

                                        if (ddlCuantosHijos.SelectedValue == "1")
                                        {
                                            fechaNHijo1 = ddlAnoFNP1.SelectedValue.ToString() + ddlMesFNP1.SelectedValue.ToString() + ddlDiaFNP1.SelectedValue.ToString();
                                            fechaNHijo2 = "19000101";
                                            fechaNHijo3 = "19000101";
                                            fechaNHijo4 = "19000101";
                                        }
                                        if (ddlCuantosHijos.SelectedValue == "2")
                                        {
                                            fechaNHijo1 = ddlAnoFNP1.SelectedValue.ToString() + ddlMesFNP1.SelectedValue.ToString() + ddlDiaFNP1.SelectedValue.ToString();
                                            fechaNHijo2 = ddlAnoFNP2.SelectedValue.ToString() + ddlMesFNP2.SelectedValue.ToString() + ddlDiaFNP2.SelectedValue.ToString();
                                            fechaNHijo3 = "19000101";
                                            fechaNHijo4 = "19000101";
                                        }
                                        if (ddlCuantosHijos.SelectedValue == "3")
                                        {
                                            fechaNHijo1 = ddlAnoFNP1.SelectedValue.ToString() + ddlMesFNP1.SelectedValue.ToString() + ddlDiaFNP1.SelectedValue.ToString();
                                            fechaNHijo2 = ddlAnoFNP2.SelectedValue.ToString() + ddlMesFNP2.SelectedValue.ToString() + ddlDiaFNP2.SelectedValue.ToString();
                                            fechaNHijo3 = ddlAnoFNP3.SelectedValue.ToString() + ddlMesFNP3.SelectedValue.ToString() + ddlDiaFNP3.SelectedValue.ToString();
                                            fechaNHijo4 = "19000101";
                                        }
                                        if (ddlCuantosHijos.SelectedValue == "4")
                                        {
                                            fechaNHijo1 = ddlAnoFNP1.SelectedValue.ToString() + ddlMesFNP1.SelectedValue.ToString() + ddlDiaFNP1.SelectedValue.ToString();
                                            fechaNHijo2 = ddlAnoFNP2.SelectedValue.ToString() + ddlMesFNP2.SelectedValue.ToString() + ddlDiaFNP2.SelectedValue.ToString();
                                            fechaNHijo3 = ddlAnoFNP3.SelectedValue.ToString() + ddlMesFNP3.SelectedValue.ToString() + ddlDiaFNP3.SelectedValue.ToString();
                                            fechaNHijo4 = ddlAnoFNP4.SelectedValue.ToString() + ddlMesFNP4.SelectedValue.ToString() + ddlDiaFNP4.SelectedValue.ToString();
                                        }

                                        if (ddlAnoPeque.SelectedValue == "1900" || ddlMesPeque.SelectedValue == "00" || ddlDiaPeque.SelectedValue == "00")
                                        {
                                            fechaCuando = "19000101";
                                        }
                                        else
                                        {
                                            fechaCuando = ddlAnoPeque.SelectedValue.ToString() + ddlMesPeque.SelectedValue.ToString() + ddlDiaPeque.SelectedValue.ToString();
                                        }
                                        if (ddlAnoFNP1.SelectedValue == "1900" || ddlMesFNP1.SelectedValue == "00" || ddlDiaFNP1.SelectedValue == "00")
                                        {
                                            fechaNHijo1 = "19000101";
                                        }
                                        if (ddlAnoFNP2.SelectedValue == "1900" || ddlMesFNP2.SelectedValue == "00" || ddlDiaFNP2.SelectedValue == "00")
                                        {
                                            fechaNHijo2 = "19000101";
                                        }
                                        if (ddlAnoFNP3.SelectedValue == "1900" || ddlMesFNP3.SelectedValue == "00" || ddlDiaFNP3.SelectedValue == "00")
                                        {
                                            fechaNHijo3 = "19000101";
                                        }
                                        if (ddlAnoFNP4.SelectedValue == "1900" || ddlMesFNP4.SelectedValue == "00" || ddlDiaFNP4.SelectedValue == "00")
                                        {
                                            fechaNHijo4 = "19000101";
                                        }

                                        DataSet ds = new DataSet();
                                        
                                        ds = cliente.RegistraCliente(txtTarjeta.Text, txtNombre.Text, txtPaterno.Text, txtMaterno.Text, ddlAno.SelectedValue.ToString() + ddlMes.SelectedValue.ToString() + ddlDia.SelectedValue.ToString(), txtMail.Text + "@" + dominio, " ", txtCelular.Text, Convert.ToInt32(rdoGenero.SelectedValue.ToString()), " ", " ", " ", 0, Convert.ToInt32(ciudad), Convert.ToInt32(estado), txtCPVisible.Text, txtTarjeta.Text, txtContra.Text, farmacia, SnacksBebidas, CuidadoPersonal, Bebes, Belleza, rdoHijos.SelectedValue);                                        

                                        DataSet dsPeque = new DataSet();
                                        cliente.RegistraEncuestaPeque(txtTarjeta.Text, rblEmbarazo.SelectedValue.ToString(), rblTienesHijos.SelectedValue.ToString(), fechaCuando, ddlCuantosHijos.SelectedValue.ToString(), txtNomH1.Text, fechaNHijo1, rdoGeneroP1.SelectedValue.ToString(), txtNomH2.Text, fechaNHijo2, rdoGeneroP2.SelectedValue.ToString(), txtNomH3.Text, fechaNHijo3, rdoGeneroP3.SelectedValue.ToString(), txtNomH4.Text, fechaNHijo4, rdoGeneroP4.SelectedValue.ToString());

                                        cliente.ActualizaRecibirInfo(txtTarjeta.Text, chkRecibirInfo.Checked);

                                        if (ds.Tables[0].Rows[0]["CodigoError_strCodigo"].ToString() == "0")
                                        {
                                            divExitoso.Visible = true;
                                            mdpExitoso.Show();
                                        }
                                        else
                                        {
                                            divExitoso.Visible = false;
                                            mdpExitoso.Hide();
                                            Mensajes(ds.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString());
                                        }

                                    }


                                }
                                else
                                {
                                    DataSet ds = new DataSet();
                                    ds = cliente.RegistraCliente(txtTarjeta.Text, txtNombre.Text, txtPaterno.Text, txtMaterno.Text, ddlAno.SelectedValue.ToString() + ddlMes.SelectedValue.ToString() + ddlDia.SelectedValue.ToString(), txtMail.Text + "@" + dominio, " ", txtCelular.Text, Convert.ToInt32(rdoGenero.SelectedValue.ToString()), " ", " ", " ", 0, Convert.ToInt32(ciudad), Convert.ToInt32(estado), txtCPVisible.Text, txtTarjeta.Text, txtContra.Text, farmacia, SnacksBebidas, CuidadoPersonal, Bebes, Belleza,rdoHijos.SelectedValue);

                                    if (ds.Tables[0].Rows[0]["CodigoError_strCodigo"].ToString() == "0")
                                    {
                                        divExitoso.Visible = true;
                                        mdpExitoso.Show();
                                        //Response.Redirect("Acceso.aspx");
                                    }
                                    else
                                    {
                                        divExitoso.Visible = false;
                                        mdpExitoso.Hide();
                                        Mensajes(ds.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString());
                                    }
                                }

                                //aqui termina
                            }
                            else
                            {
                                Mensajes("El estado y ciudad no corresponden al código postal indicado. Favor de validar código postal");
                            }
                        }
                        else
                        {
                            Mensajes("La contraseña no coincide con Confirma Contraseña");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }       
        

        protected void btnValidar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtTarjeta.Text == string.Empty)
                {
                    Mensajes("Captura campo Tarjeta");
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = cliente.RegresaDatosCliente(txtTarjeta.Text.Trim());

                    if (ds != null && ds.Tables.Count>0)
                    {
                        if (ds.Tables[0].Rows[0]["Existe"].ToString() == "0")
                        {
                            Mensajes(ds.Tables[0].Rows[0]["Mensaje"].ToString());
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[0]["PermiteActivar"].ToString() != "1")
                            {
                                
                                //Mensajes(ds.Tables[0].Rows[0]["Mensaje"].ToString());
                                lblMensaje.Text=ds.Tables[0].Rows[0]["Mensaje"].ToString();
                                divPop.Visible = true;
                                mpePop.Show();
                            }
                            else
                            {
                                activaCampos(ds.Tables[0].Rows[0]["PermiteActivar"].ToString());

                                if (ds.Tables[0].Rows[0]["intDominio"].ToString() == "7")
                                {
                                    txtDominio.Visible = true;
                                    lblEscribaDominio.Visible = true;
                                    txtMail.Text = ds.Tables[0].Rows[0]["strEmail"].ToString();
                                    txtDominio.Text = ds.Tables[0].Rows[0]["strDominio"].ToString();
                                    ddlDominios.SelectedValue = ds.Tables[0].Rows[0]["intDominio"].ToString();
                                }
                                else
                                {
                                    txtDominio.Visible = false;
                                    lblEscribaDominio.Visible = false;
                                    txtMail.Text = ds.Tables[0].Rows[0]["strEmail"].ToString();
                                    ddlDominios.SelectedValue = ds.Tables[0].Rows[0]["intDominio"].ToString();
                                }
                                txtNombre.Text = ds.Tables[0].Rows[0]["strNombre"].ToString();
                                txtPaterno.Text = ds.Tables[0].Rows[0]["strAPaterno"].ToString();
                                txtMaterno.Text = ds.Tables[0].Rows[0]["strAMaterno"].ToString();
                                txtCelular.Text = ds.Tables[0].Rows[0]["strCelular"].ToString();
                                ddlAno.SelectedValue = ds.Tables[0].Rows[0]["strAño"].ToString();
                                ddlMes.SelectedValue = ds.Tables[0].Rows[0]["strMes"].ToString();
                                int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAno.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue));
                                CargarCatalogoDia(1, diasxmes, ddlDia);
                                ddlDia.SelectedValue = ds.Tables[0].Rows[0]["strDia"].ToString();
                                rdoGenero.SelectedValue = ds.Tables[0].Rows[0]["intGenero"].ToString();
                                txtCPVisible.Text = ds.Tables[0].Rows[0]["strCP"].ToString();
                                if(!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["strIdEstado"].ToString()))
                                {
                                    ddlEstado.SelectedValue = ds.Tables[0].Rows[0]["strIdEstado"].ToString();
                                    CargarCatalogo("Municipio", ddlCiudad, ddlEstado.SelectedValue.ToString(), "");
                                    ddlCiudad.SelectedValue = ds.Tables[0].Rows[0]["intIdCiudad"].ToString();
                                }
                                ddlCiudad.Enabled = true;

                            }
                        }
                        
                    }
                    
                    else
                    {
                        Mensajes("Tarjeta inexistente favor de verificar");
                    }
                }
            }
            catch
            {
                
            }
        }

        protected void ddlDominios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlDominios.SelectedValue == "7")
                {
                    lblEscribaDominio.Visible = true;
                    txtDominio.Visible = true;
                    txtDominio.Enabled = true;
                }
                else
                {
                    lblEscribaDominio.Visible = false;
                    txtDominio.Visible = false;
                    txtDominio.Enabled = false;
                }
            }
            catch
            {
 
            }
        }

        protected void rblPeques_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblPeques.SelectedValue == "1")
                {
                    //divPeques.Visible = true;
                    //mpePeques.Show();
                    trEspacio.Style.Remove("display");
                    trPeques.Style.Remove("display");
                    trEspacio.Style.Add("display", "");
                    trPeques.Style.Add("display", "");
                    panelInscripcion.Visible = true;

                    CargarCatalogoAno(DateTime.Now.AddYears(3).Year, DateTime.Now.Year, ddlAnoPeque);
                    //CargarCatalogoMes(1, 12, ddlMesPeque);
                    ddlMesPeque.Items.Add(new ListItem("Mes", "00"));
                    ddlDiaPeque.Items.Add(new ListItem("Día", "00"));

                    CargarCatalogoAno(DateTime.Today.Year, DateTime.Now.AddYears(-3).Year, ddlAnoFNP1);
                    ddlMesFNP1.Items.Add(new ListItem("Mes", "00"));
                    //CargarCatalogoMes(1, 12, ddlMesFNP1);
                    ddlDiaFNP1.Items.Add(new ListItem("Día", "00"));

                    CargarCatalogoAno(DateTime.Today.Year, DateTime.Now.AddYears(-3).Year, ddlAnoFNP2);
                    ddlMesFNP2.Items.Add(new ListItem("Mes", "00"));
                    //CargarCatalogoMes(1, 12, ddlMesFNP2);
                    ddlDiaFNP2.Items.Add(new ListItem("Día", "00"));

                    CargarCatalogoAno(DateTime.Today.Year, DateTime.Now.AddYears(-3).Year, ddlAnoFNP3);
                    ddlMesFNP3.Items.Add(new ListItem("Mes", "00"));
                    //CargarCatalogoMes(1, 12, ddlMesFNP3);
                    ddlDiaFNP3.Items.Add(new ListItem("Día", "00"));

                    CargarCatalogoAno(DateTime.Today.Year, DateTime.Now.AddYears(-3).Year, ddlAnoFNP4);
                    ddlMesFNP4.Items.Add(new ListItem("Mes", "00"));
                    //CargarCatalogoMes(1, 12, ddlMesFNP4);
                    ddlDiaFNP4.Items.Add(new ListItem("Día", "00"));
                }
                else
                {
                    //divPeques.Visible = false;
                    //mpePeques.Hide();
                    panelInscripcion.Visible = false;
                }
            }
            catch
            { }
        }

        protected void btnCerrarPnl_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                trEspacio.Style.Remove("display");
                trPeques.Style.Remove("display");
                trEspacio.Style.Add("display", "none");
                trPeques.Style.Add("display", "none");
                divPeques.Visible = false;
                mpePeques.Hide();
            }
            catch
            {
            }
        }

        protected void btnValidarCP_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                try
                {
                    DataSet dsCP = new DataSet();
                    Catalogos cat = new Catalogos();

                    dsCP = cat.DatosCatalogoSepoMex("CPEncuesta", txtCPVisible.Text.Trim(), "");

                    if (dsCP != null)
                    {
                        if (dsCP.Tables[0].Rows.Count > 0)
                        {
                            ddlEstado.SelectedValue = dsCP.Tables[0].Rows[0]["IDEstado"].ToString();
                            CargarCatalogo("Municipio", ddlCiudad, ddlEstado.SelectedValue.ToString(), "");
                            ddlCiudad.SelectedValue = dsCP.Tables[0].Rows[0]["IDMunicipio"].ToString();
                            ddlCiudad.Enabled = true;
                        }
                        else
                        {
                            Mensajes("El código postal indicado no existe, indica tu Estado y Ciudad");
                            ddlEstado.SelectedValue = "00";
                            ddlCiudad.SelectedValue = "00";
                            txtCPVisible.Text = string.Empty;
                        }
                    }
                   
                }
                catch (Exception ex)
                {
                    Mensajes(ex.Message);
                }
            }
            catch
            {

            }
        }

        protected void ddlCuantosHijos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCuantosHijos.SelectedValue == "0")
                {
                    tablaH.Visible = false;
                    txtNomH1.Visible = false;
                    ddlDiaFNP1.Visible = false;
                    ddlMesFNP1.Visible = false;
                    ddlAnoFNP1.Visible = false;
                    rdoGeneroP1.Visible = false;

                    txtNomH2.Visible = false;
                    ddlDiaFNP2.Visible = false;
                    ddlMesFNP2.Visible = false;
                    ddlAnoFNP2.Visible = false;
                    rdoGeneroP2.Visible = false;

                    txtNomH3.Visible = false;
                    ddlDiaFNP3.Visible = false;
                    ddlMesFNP3.Visible = false;
                    ddlAnoFNP3.Visible = false;
                    rdoGeneroP3.Visible = false;

                    txtNomH4.Visible = false;
                    ddlDiaFNP4.Visible = false;
                    ddlMesFNP4.Visible = false;
                    ddlAnoFNP4.Visible = false;
                    rdoGeneroP4.Visible = false;


                }
                else
                {
                    if (ddlCuantosHijos.SelectedValue == "1")
                    {
                        tablaH.Visible = true;
                        txtNomH1.Visible = true;
                        ddlDiaFNP1.Visible = true;
                        ddlMesFNP1.Visible = true;
                        ddlAnoFNP1.Visible = true;
                        rdoGeneroP1.Visible = true;

                        txtNomH2.Visible = false;
                        ddlDiaFNP2.Visible = false;
                        ddlMesFNP2.Visible = false;
                        ddlAnoFNP2.Visible = false;
                        rdoGeneroP2.Visible = false;

                        txtNomH3.Visible = false;
                        ddlDiaFNP3.Visible = false;
                        ddlMesFNP3.Visible = false;
                        ddlAnoFNP3.Visible = false;
                        rdoGeneroP3.Visible = false;

                        txtNomH4.Visible = false;
                        ddlDiaFNP4.Visible = false;
                        ddlMesFNP4.Visible = false;
                        ddlAnoFNP4.Visible = false;
                        rdoGeneroP4.Visible = false;


                    }
                    else
                    {
                        if (ddlCuantosHijos.SelectedValue == "2")
                        {
                            tablaH.Visible = true;
                            txtNomH1.Visible = true;
                            ddlDiaFNP1.Visible = true;
                            ddlMesFNP1.Visible = true;
                            ddlAnoFNP1.Visible = true;
                            rdoGeneroP1.Visible = true;

                            txtNomH2.Visible = true;
                            ddlDiaFNP2.Visible = true;
                            ddlMesFNP2.Visible = true;
                            ddlAnoFNP2.Visible = true;
                            rdoGeneroP2.Visible = true;

                            txtNomH3.Visible = false;
                            ddlDiaFNP3.Visible = false;
                            ddlMesFNP3.Visible = false;
                            ddlAnoFNP3.Visible = false;
                            rdoGeneroP3.Visible = false;

                            txtNomH4.Visible = false;
                            ddlDiaFNP4.Visible = false;
                            ddlMesFNP4.Visible = false;
                            ddlAnoFNP4.Visible = false;
                            rdoGeneroP4.Visible = false;
                        }
                        else
                        {
                            if (ddlCuantosHijos.SelectedValue == "3")
                            {
                                tablaH.Visible = true;
                                txtNomH1.Visible = true;
                                ddlDiaFNP1.Visible = true;
                                ddlMesFNP1.Visible = true;
                                ddlAnoFNP1.Visible = true;
                                rdoGeneroP1.Visible = true;

                                txtNomH2.Visible = true;
                                ddlDiaFNP2.Visible = true;
                                ddlMesFNP2.Visible = true;
                                ddlAnoFNP2.Visible = true;
                                rdoGeneroP2.Visible = true;

                                txtNomH3.Visible = true;
                                ddlDiaFNP3.Visible = true;
                                ddlMesFNP3.Visible = true;
                                ddlAnoFNP3.Visible = true;
                                rdoGeneroP3.Visible = true;

                                txtNomH4.Visible = false;
                                ddlDiaFNP4.Visible = false;
                                ddlMesFNP4.Visible = false;
                                ddlAnoFNP4.Visible = false;
                                rdoGeneroP4.Visible = false;
                            }
                            else
                            {
                                if (ddlCuantosHijos.SelectedValue == "4")
                                {
                                    tablaH.Visible = true;
                                    txtNomH1.Visible = true;
                                    ddlDiaFNP1.Visible = true;
                                    ddlMesFNP1.Visible = true;
                                    ddlAnoFNP1.Visible = true;
                                    rdoGeneroP1.Visible = true;

                                    txtNomH2.Visible = true;
                                    ddlDiaFNP2.Visible = true;
                                    ddlMesFNP2.Visible = true;
                                    ddlAnoFNP2.Visible = true;
                                    rdoGeneroP2.Visible = true;

                                    txtNomH3.Visible = true;
                                    ddlDiaFNP3.Visible = true;
                                    ddlMesFNP3.Visible = true;
                                    ddlAnoFNP3.Visible = true;
                                    rdoGeneroP3.Visible = true;

                                    txtNomH4.Visible = true;
                                    ddlDiaFNP4.Visible = true;
                                    ddlMesFNP4.Visible = true;
                                    ddlAnoFNP4.Visible = true;
                                    rdoGeneroP4.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
 
            }
        }

        protected void ddlMesPeque_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMesPeque.SelectedValue == "00")
                {
                    ddlDiaPeque.Items.Clear();
                    ddlDiaPeque.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaPeque.Enabled = false;
                }
                else
                {
                    ddlDiaPeque.Enabled = true;

                    int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAnoPeque.SelectedValue), Convert.ToInt32(ddlMesPeque.SelectedValue));

                    CargarCatalogoDia(1, diasxmes, ddlDiaPeque);
                }
                ddlDiaPeque.SelectedValue = "01";
            }
            catch
            {
 
            }
        }

        protected void ddlMesFNP1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMesFNP1.SelectedValue == "00")
                {
                    ddlDiaFNP1.Items.Clear();
                    ddlDiaFNP1.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP1.Enabled = false;
                }
                else
                {
                    ddlDiaFNP1.Enabled = true;

                    int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAnoFNP1.SelectedValue), Convert.ToInt32(ddlMesFNP1.SelectedValue));

                    CargarCatalogoDia(1, diasxmes, ddlDiaFNP1);
                }
            }
            catch
            {

            }
        }

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        public string CapitalizeFirstLetter(string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        protected void ddlAnoPeque_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAnoPeque.SelectedValue == "00")
                {
                    ddlMesPeque.Items.Clear();
                    ddlMesPeque.Items.Add(new ListItem("Selecciona", "00"));
                    ddlMesPeque.Enabled = false;
                    ddlDiaPeque.Items.Clear();
                    ddlDiaPeque.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaPeque.Enabled = false;
                }
                else
                {
                    ddlMesPeque.Enabled = true;
                    DateTime moment;
                    moment = DateTime.Now; 
                    string year = Convert.ToString(moment.Year);
                    int month = moment.Month;                    

                    if (ddlAnoPeque.SelectedValue == year)
                    {                                          
                        CargarCatalogoMesFechaActual(month, 12, ddlMesPeque);
                        ddlMesPeque.Enabled = true;
                        ddlDiaPeque.Items.Clear();
                        ddlDiaPeque.Items.Add(new ListItem("Selecciona", "00"));
                        ddlDiaPeque.Enabled = false;
                    }
                    else
                    {
                        CargarCatalogoMesFechaActual(1, 12, ddlMesPeque);
                        ddlMesPeque.Enabled = true;
                        ddlDiaPeque.Items.Clear();
                        ddlDiaPeque.Items.Add(new ListItem("Selecciona", "00"));
                        ddlDiaPeque.Enabled = false;
                    }
                }
            }
            catch
            { }
        }

        protected void ddlAnoFNP1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAnoFNP1.SelectedValue == "00")
                {
                    ddlMesFNP1.Items.Clear();
                    ddlMesFNP1.Items.Add(new ListItem("Selecciona", "00"));
                    ddlMesFNP1.Enabled = false;
                    ddlDiaFNP1.Items.Clear();
                    ddlDiaFNP1.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP1.Enabled = false;
                }
                else
                {
                    CargarCatalogoMes(1, 12, ddlMesFNP1);
                    ddlMesFNP1.Enabled = true;
                    ddlDiaFNP1.Items.Clear();
                    ddlDiaFNP1.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP1.Enabled = false;
                }
            }
            catch
            { }
        }

        protected void ddlAnoFNP2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAnoFNP2.SelectedValue == "00")
                {
                    ddlMesFNP2.Items.Clear();
                    ddlMesFNP2.Items.Add(new ListItem("Selecciona", "00"));
                    ddlMesFNP2.Enabled = false;
                    ddlDiaFNP2.Items.Clear();
                    ddlDiaFNP2.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP2.Enabled = false;
                }
                else
                {
                    CargarCatalogoMes(1, 12, ddlMesFNP2);
                    ddlMesFNP2.Enabled = true;
                    ddlDiaFNP2.Items.Clear();
                    ddlDiaFNP2.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP2.Enabled = false;
                }
            }
            catch
            { }
        }

        protected void ddlAnoFNP3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAnoFNP3.SelectedValue == "00")
                {
                    ddlMesFNP3.Items.Clear();
                    ddlMesFNP3.Items.Add(new ListItem("Selecciona", "00"));
                    ddlMesFNP3.Enabled = false;
                    ddlDiaFNP3.Items.Clear();
                    ddlDiaFNP3.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP3.Enabled = false;
                }
                else
                {
                    CargarCatalogoMes(1, 12, ddlMesFNP3);
                    ddlMesFNP3.Enabled = true;
                    ddlDiaFNP3.Items.Clear();
                    ddlDiaFNP3.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP3.Enabled = false;
                }
            }
            catch
            { }
        }

        protected void ddlAnoFNP4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAnoFNP4.SelectedValue == "00")
                {
                    ddlMesFNP4.Items.Clear();
                    ddlMesFNP4.Items.Add(new ListItem("Selecciona", "00"));
                    ddlMesFNP4.Enabled = false;
                    ddlDiaFNP4.Items.Clear();
                    ddlDiaFNP4.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP4.Enabled = false;
                }
                else
                {
                    CargarCatalogoMes(1, 12, ddlMesFNP4);
                    ddlMesFNP4.Enabled = true;
                    ddlDiaFNP4.Items.Clear();
                    ddlDiaFNP4.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP4.Enabled = false;
                }
            }
            catch
            { }
        }

        protected void ddlMesFNP2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMesFNP2.SelectedValue == "00")
                {
                    ddlDiaFNP2.Items.Clear();
                    ddlDiaFNP2.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP2.Enabled = false;
                }
                else
                {
                    ddlDiaFNP2.Enabled = true;

                    int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAnoFNP2.SelectedValue), Convert.ToInt32(ddlMesFNP2.SelectedValue));

                    CargarCatalogoDia(1, diasxmes, ddlDiaFNP2);
                }
            }
            catch
            {

            }
        }

        protected void ddlMesFNP3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMesFNP3.SelectedValue == "00")
                {
                    ddlDiaFNP3.Items.Clear();
                    ddlDiaFNP3.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP3.Enabled = false;
                }
                else
                {
                    ddlDiaFNP3.Enabled = true;

                    int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAnoFNP3.SelectedValue), Convert.ToInt32(ddlMesFNP3.SelectedValue));

                    CargarCatalogoDia(1, diasxmes, ddlDiaFNP3);
                }
            }
            catch
            {

            }
        }

        protected void ddlMesFNP4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMesFNP4.SelectedValue == "00")
                {
                    ddlDiaFNP4.Items.Clear();
                    ddlDiaFNP4.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP4.Enabled = false;
                }
                else
                {
                    ddlDiaFNP4.Enabled = true;

                    int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAnoFNP4.SelectedValue), Convert.ToInt32(ddlMesFNP4.SelectedValue));

                    CargarCatalogoDia(1, diasxmes, ddlDiaFNP4);
                }
            }
            catch
            {

            }
        }

        protected void rblTienesHijos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblTienesHijos.SelectedValue == "1")
                {
                    //tablaH.Visible = true;
                    ddlCuantosHijos.Enabled = true;
                    ddlCuantosHijos.Enabled = true;
                }
                else
                {
                    ddlCuantosHijos.SelectedValue = "0";
                    txtNomH1.Text = string.Empty;
                    txtNomH2.Text = string.Empty;
                    txtNomH3.Text = string.Empty;
                    txtNomH4.Text = string.Empty;

                    ddlAnoFNP1.SelectedValue = "1900";
                    ddlAnoFNP2.SelectedValue = "1900";
                    ddlAnoFNP3.SelectedValue = "1900";
                    ddlAnoFNP4.SelectedValue = "1900";

                    ddlMesFNP1.SelectedValue = "00";
                    ddlMesFNP2.SelectedValue = "00";
                    ddlMesFNP3.SelectedValue = "00";
                    ddlMesFNP4.SelectedValue = "00";

                    ddlDiaFNP1.SelectedValue = "00";
                    ddlDiaFNP2.SelectedValue = "00";
                    ddlDiaFNP3.SelectedValue = "00";
                    ddlDiaFNP4.SelectedValue = "00";
                    

                    tablaH.Visible = false;
                    ddlCuantosHijos.Enabled = false;
                    ddlCuantosHijos.Enabled = false;
                }
            }
            catch
            { }
        }

        protected void btnCerrarMasInfo_Click(object sender, ImageClickEventArgs e)
        {
            divInfo.Visible = false;
            mpeInfo.Hide();
        }

        protected void btnMasInfo_Click(object sender, ImageClickEventArgs e)
        {
            divInfo.Visible = true;
            mpeInfo.Show();
        }
        public void activaCampos(string valor)
        {
            if (valor == "1")
            {
                txtContra.Enabled = true;
                txtConfirmaContra.Enabled = true;
                txtNombre.Enabled = true;
                txtPaterno.Enabled = true;
                txtMaterno.Enabled = true;
                txtMail.Enabled = true;
                ddlDominios.Enabled = true;
                txtDominio.Enabled = true;
                //txtLADA.Enabled = true;
                txtCelular.Enabled = true;
                ddlAno.Enabled = true;
                ddlMes.Enabled = true;
                ddlDia.Enabled = true;
                rdoGenero.Enabled = true;
                rdoHijos.Enabled = true;
                txtCPVisible.Enabled = true;
                btnValidarCP.Enabled = true;
                ddlEstado.Enabled = true;
                chkCategorias.Enabled = true;
                rblPeques.Enabled = true;
                btnRegistrar.Enabled = true;
                chkRecibirInfo.Enabled = true;
                chkTerminos.Enabled = true;
                txtTarjeta.Enabled = false;
                btnValidar.Enabled = false;
            }                       
        }

        protected void btnCerrarPop_Click(object sender, ImageClickEventArgs e)
        {
            divPop.Visible = false;
            mpePop.Hide();
            Response.Redirect("Index.aspx");
        }

        protected void rblEmbarazo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblEmbarazo.SelectedValue == "1")
            {
                lblNacera.Visible = true;              
                ddlAnoPeque.Enabled = true;
                ddlMesPeque.Enabled = true;
                ddlDiaPeque.Enabled = true;
                ddlAnoPeque.SelectedValue = "1900";
                ddlMesPeque.SelectedValue = "00";
                ddlDiaPeque.SelectedValue = "00";
            }
            else
            {
                lblNacera.Visible = false;
                ddlAnoPeque.Enabled = false;
                ddlMesPeque.Enabled = false;
                ddlDiaPeque.Enabled = false;
                ddlAnoPeque.SelectedValue = "1900";
                ddlMesPeque.SelectedValue = "00";
                ddlDiaPeque.SelectedValue = "00";
            }
        }

        protected void btnCerrarExitoso_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Acceso.aspx");
        }

        protected void lnkValidarT_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTarjeta.Text == string.Empty)
                {
                    Mensajes("Captura campo Tarjeta");
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = cliente.RegresaDatosCliente(txtTarjeta.Text.Trim());

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Existe"].ToString() == "0")
                        {
                            Mensajes(ds.Tables[0].Rows[0]["Mensaje"].ToString());
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[0]["PermiteActivar"].ToString() != "1")
                            {

                                //Mensajes(ds.Tables[0].Rows[0]["Mensaje"].ToString());
                                lblMensaje.Text = ds.Tables[0].Rows[0]["Mensaje"].ToString();
                                divPop.Visible = true;
                                mpePop.Show();
                            }
                            else
                            {
                                activaCampos(ds.Tables[0].Rows[0]["PermiteActivar"].ToString());

                                if (ds.Tables[0].Rows[0]["intDominio"].ToString() == "7")
                                {
                                    txtDominio.Visible = true;
                                    lblEscribaDominio.Visible = true;
                                    txtMail.Text = ds.Tables[0].Rows[0]["strEmail"].ToString();
                                    txtDominio.Text = ds.Tables[0].Rows[0]["strDominio"].ToString();
                                    ddlDominios.SelectedValue = ds.Tables[0].Rows[0]["intDominio"].ToString();
                                }
                                else
                                {
                                    txtDominio.Visible = false;
                                    lblEscribaDominio.Visible = false;
                                    txtMail.Text = ds.Tables[0].Rows[0]["strEmail"].ToString();
                                    ddlDominios.SelectedValue = ds.Tables[0].Rows[0]["intDominio"].ToString();
                                }
                                txtNombre.Text = ds.Tables[0].Rows[0]["strNombre"].ToString();
                                txtPaterno.Text = ds.Tables[0].Rows[0]["strAPaterno"].ToString();
                                txtMaterno.Text = ds.Tables[0].Rows[0]["strAMaterno"].ToString();
                                txtCelular.Text = ds.Tables[0].Rows[0]["strCelular"].ToString();
                                ddlAno.SelectedValue = ds.Tables[0].Rows[0]["strAño"].ToString();
                                ddlMes.SelectedValue = ds.Tables[0].Rows[0]["strMes"].ToString();
                                int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAno.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue));
                                CargarCatalogoDia(1, diasxmes, ddlDia);
                                ddlDia.SelectedValue = ds.Tables[0].Rows[0]["strDia"].ToString();
                                rdoGenero.SelectedValue = ds.Tables[0].Rows[0]["intGenero"].ToString();
                                txtCPVisible.Text = ds.Tables[0].Rows[0]["strCP"].ToString();
                                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["strIdEstado"].ToString()))
                                {
                                    ddlEstado.SelectedValue = ds.Tables[0].Rows[0]["strIdEstado"].ToString();
                                    CargarCatalogo("Municipio", ddlCiudad, ddlEstado.SelectedValue.ToString(), "");
                                    ddlCiudad.SelectedValue = ds.Tables[0].Rows[0]["intIdCiudad"].ToString();
                                }
                                ddlCiudad.Enabled = true;

                            }
                        }

                    }

                    else
                    {
                        Mensajes("Tarjeta inexistente favor de verificar");
                    }
                }
            }
            catch
            {

            }
        }

        protected void LnkVaidaCP_Click(object sender, EventArgs e)
        {            
                try
                {
                    DataSet dsCP = new DataSet();
                    Catalogos cat = new Catalogos();

                    dsCP = cat.DatosCatalogoSepoMex("CPEncuesta", txtCPVisible.Text.Trim(), "");

                    if (dsCP != null)
                    {
                        if (dsCP.Tables[0].Rows.Count > 0)
                        {
                            ddlEstado.SelectedValue = dsCP.Tables[0].Rows[0]["IDEstado"].ToString();
                            CargarCatalogo("Municipio", ddlCiudad, ddlEstado.SelectedValue.ToString(), "");
                            ddlCiudad.SelectedValue = dsCP.Tables[0].Rows[0]["IDMunicipio"].ToString();
                            ddlCiudad.Enabled = true;
                        }
                        else
                        {
                            Mensajes("El código postal indicado no existe, indica tu Estado y Ciudad");
                            ddlEstado.SelectedValue = "00";
                            ddlCiudad.SelectedValue = "00";
                            txtCPVisible.Text = string.Empty;
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