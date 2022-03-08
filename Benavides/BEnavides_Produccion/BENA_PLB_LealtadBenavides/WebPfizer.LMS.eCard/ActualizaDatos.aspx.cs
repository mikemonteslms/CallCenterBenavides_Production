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

namespace WebPfizer.LMS.eCard
{
    public partial class ActualizaDatos : System.Web.UI.Page
    {
        DataSet objDataset;
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();
        EntActualizarCliente ent = new EntActualizarCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Acceso.aspx", true);
                }

                txtCelular.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
                //txtLADA.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
                txtCP.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");

                btnGuardar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/13-cambiar_contrasena/btn-guardar-hover.jpg'");
                btnGuardar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/13-cambiar_contrasena/btn-guardar.jpg'");

                btnCancelar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-regresar-hover.jpg'");
                btnCancelar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-regresar.jpg'");

                if (!IsPostBack)
                {
                    CargarCatalogo("estado", ddlEstado, "", "");

                    CargarCatalogoAno(DateTime.Today.Year, 1900, ddlAno);
                    CargarCatalogoMes(1, 12, ddlMes);
                    ddlDia.Items.Add(new ListItem("Día", "00"));

                    CargarCatalogoDominios(ddlDominios);

                    CargarCatalogosCuestionarioInicial();

                    string tarjeta = Session["Usuario"].ToString();
                    CargaCatalogosEstadoYCiudad();
                    CargaDatosCliente(tarjeta);

                }


            }
            catch
            {

            }
        }

        private void Mensajes(string valorMensaje)
        {
            //DivCambiarContraseña.Visible = false;
            string mensaje = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + mensaje + "');", true);
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

        protected void CargaDatosCliente(string idcliente)
        {
            try
            {
                //DivCambiarContraseña.Visible = false;
                objDataset = new DataSet();
                objDataset = cliente.DatosCLiente(idcliente);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    string fechaNacimiento = objDataset.Tables[0].Rows[0]["FechaNacimiento"].ToString();
                    string anoFN = fechaNacimiento.Substring(0, 4);
                    string mesFN = fechaNacimiento.Substring(4, 2);
                    string diaFN = fechaNacimiento.Substring(6, 2);

                    if (objDataset.Tables[0].Rows[0]["intDominio"].ToString() == "7")
                    {
                        txtDominio.Visible = true;
                        lblEscribaDominio.Visible = true;
                        txtMail.Text = objDataset.Tables[0].Rows[0]["strEmail"].ToString();
                        txtDominio.Text = objDataset.Tables[0].Rows[0]["strDominio"].ToString();
                        ddlDominios.SelectedValue = objDataset.Tables[0].Rows[0]["intDominio"].ToString();
                    }
                    else
                    {
                        txtDominio.Visible = false;
                        lblEscribaDominio.Visible = false;
                        txtMail.Text = objDataset.Tables[0].Rows[0]["strEmail"].ToString();
                        ddlDominios.SelectedValue = objDataset.Tables[0].Rows[0]["intDominio"].ToString();
                    }

                    txtNombre.Text = objDataset.Tables[0].Rows[0]["NombreSolo"].ToString();
                    txtAP.Text = objDataset.Tables[0].Rows[0]["AP"].ToString();
                    txtAM.Text = objDataset.Tables[0].Rows[0]["AM"].ToString();
                    txtCelular.Text = objDataset.Tables[0].Rows[0]["Celular"].ToString();
                    ddlAno.SelectedValue = anoFN;
                    ddlMes.SelectedValue = mesFN;
                    ddlDia.SelectedValue = diaFN;
                    int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAno.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue));
                    CargarCatalogoDia(1, diasxmes, ddlDia);
                    ddlDia.SelectedValue = diaFN;
                    rdoGenero.SelectedValue = objDataset.Tables[0].Rows[0]["GeneroBit"].ToString();
                    rdoHijos.SelectedValue = objDataset.Tables[0].Rows[0]["Hijos"].ToString();
                    txtCP.Text = objDataset.Tables[0].Rows[0]["CP"].ToString();
                    //txtCP_TextChanged(txtCP, new EventArgs());
                    ddlEstado.SelectedValue = objDataset.Tables[0].Rows[0]["IDEstado"].ToString();
                    if (ddlEstado.SelectedValue != "00")
                    {
                        ddlEstado_SelectedIndexChanged(ddlEstado, new EventArgs());
                        ddlCiudad.SelectedValue = objDataset.Tables[0].Rows[0]["IDMunicipio"].ToString();
                    }
                }
                else
                {
                    //lblFechaNacimiento.Text = "Sin informacion";
                    //lblGenero.Text = "Sin informacion";
                    //lblTelefono.Text = "Sin informacion";
                    //lblCelular.Text = "Sin informacion";
                    //lblCorreo.Text = "Sin informacion";
                    //lblDireccion.Text = "Sin informacion";
                }

                if (objDataset.Tables[0].Rows[0]["Farmacia"].ToString() == "1")
                {
                    chkCategorias.Items[0].Selected = true;
                }
                if (objDataset.Tables[0].Rows[0]["Snacks"].ToString() == "1")
                {
                    chkCategorias.Items[1].Selected = true;
                }
                if (objDataset.Tables[0].Rows[0]["Cuidado"].ToString() == "1")
                {
                    chkCategorias.Items[2].Selected = true;
                }
                if (objDataset.Tables[0].Rows[0]["Bebes"].ToString() == "1")
                {
                    chkCategorias.Items[3].Selected = true;
                }
                if (objDataset.Tables[0].Rows[0]["Belleza"].ToString() == "1")
                {
                    chkCategorias.Items[4].Selected = true;
                }

                Session["CatCategorias"] = objDataset;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }

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

        protected void imgBtnEnviarContraseña_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //if (txtContraseñaActual.Text == "" || txtNuevaContraseña.Text == "" || txtConfirmaContraseña.Text == "")
                //{
                //    lblMensajeCambiarContraseña.Text = "Captura todos los datos marcados (*)";
                //    mpeCambiarContraseña.Show();
                //    DivCambiarContraseña.Visible = true;
                //}
                //else
                //{
                //    ent.tarjeta = Session["Usuario"].ToString();
                //    ent.contraseñaActual = txtContraseñaActual.Text.Trim();
                //    ent.nuevaContraseña = txtNuevaContraseña.Text.Trim();
                //    ent.confirmaContraseña = txtConfirmaContraseña.Text.Trim();

                //    DataSet dsRegresa = cliente.CambiarContraseña(ent);

                //    if (dsRegresa.Tables[0].Rows.Count > 0)
                //    {
                //        string respuesta = dsRegresa.Tables[0].Rows[0]["CodigoError_strCodigo"].ToString();
                //        if (respuesta == "CON001")
                //        {
                //            string Mensaje = dsRegresa.Tables[0].Rows[0]["CodigoError_strDescripcion"].ToString();
                //            DivCambiarContraseña.Visible = false;
                //            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "');window.location.href='MisDatos.aspx'", true);
                //        }
                //        else
                //        {
                //            string Mensaje = dsRegresa.Tables[0].Rows[0]["CodigoError_strDescripcion"].ToString();
                //            lblMensajeCambiarContraseña.Text = Mensaje;
                //            mpeCambiarContraseña.Show();
                //            DivCambiarContraseña.Visible = true;
                //        }
                //    }
                //    else
                //    {
                //        Mensajes("Error al ejecutar el proceso de Cambio de Contraseña");
                //    }
                //}
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void lnkAceptaDatoContacto_Click(object sender, EventArgs e)
        {
            Session["UsuarioCC"] = "WEB";
            Response.Redirect("CancelaContacto.aspx");
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

        private void CargaCatalogosEstadoYCiudad()
        {
            DataSet dsCP = new DataSet();
            Catalogos cat = new Catalogos();

            dsCP = cat.DatosCatalogoSepoMex("CPEncuesta", txtCP.Text.Trim(), "");

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
                    //Mensajes("El código postal indicado no existe, indica tu Estado y Ciudad");
                    ddlEstado.SelectedValue = "00";
                    ddlCiudad.SelectedValue = "00";
                    txtCP.Text = string.Empty;
                }
            }
        }

        protected void CargarCatalogo(string @Catalogo, DropDownList ControlCombo, string filtro1, string filtro2)
        {
            try
            {
                DataSet objdataset1 = new DataSet();
                objdataset1 = objConsultaDatos.DatosCatalogoSepoMex(@Catalogo, filtro1, filtro2);
                ControlCombo.Items.Clear();
                if (objdataset1.Tables[0].Rows.Count > 0)
                {
                    ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));
                    for (int i = 0; i <= objdataset1.Tables[0].Rows.Count - 1; i++)
                    {
                        ListItem Item = new ListItem();
                        Item.Value = objdataset1.Tables[0].Rows[i][0].ToString();
                        Item.Text = objdataset1.Tables[0].Rows[i][1].ToString();
                        ControlCombo.Items.Add(Item);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

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

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MisDatos.aspx");
        }

        protected void btnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtNombre.Text.Trim() == string.Empty)
                {
                    throw new ApplicationException("Captura Nombre");
                }
                if (txtAP.Text.Trim() == string.Empty)
                {
                    throw new ApplicationException("Captura Apellido Paterno");
                }
                if (txtAM.Text.Trim() == string.Empty)
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
                if (rdoGenero.SelectedValue == "-1" || rdoGenero.SelectedValue == "")
                {
                    throw new ApplicationException("Indicar Género");
                }
                if (rdoHijos.SelectedValue == "-1" || rdoHijos.SelectedValue == "")
                {
                    throw new ApplicationException("Indicar tienes hijos");
                }

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

                int dirValido = 0;
                if (txtCP.Text == string.Empty)
                {
                    dirValido = 1;
                }
                else
                {
                    DataSet dsCP = new DataSet();
                    dsCP = objConsultaDatos.DatosCatalogoSepoMex("CPEncuesta", txtCP.Text, "");

                    if (dsCP != null && dsCP.Tables.Count > 0 && dsCP.Tables[0].Rows.Count > 0)
                    {
                        if (dsCP.Tables[0].Rows[0]["IDEstado"].ToString() == ddlEstado.SelectedValue.ToString() && dsCP.Tables[0].Rows[0]["IDMunicipio"].ToString() == ddlCiudad.SelectedValue.ToString())
                        {
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
                    DataSet ds = new DataSet();
                    string tarjeta = Session["Usuario"].ToString();
                    if (Session["CatCategorias"] != null)
                    {
                        DataSet dtsTemp = new DataSet();
                        dtsTemp = (DataSet)Session["CatCategorias"];
                        string farmaciaant, snacksant, cuidadoperant, bebesant, bellezaant;
                        farmaciaant = dtsTemp.Tables[0].Rows[0]["Farmacia"].ToString();
                        snacksant = dtsTemp.Tables[0].Rows[0]["Snacks"].ToString();
                        cuidadoperant = dtsTemp.Tables[0].Rows[0]["Cuidado"].ToString();
                        bebesant = dtsTemp.Tables[0].Rows[0]["Bebes"].ToString();
                        bellezaant = dtsTemp.Tables[0].Rows[0]["Belleza"].ToString();
                        #region Validacion cambio
                        //        if (objDataset.Tables[0].Rows[0]["Farmacia"].ToString() == "1")
                        //{
                        //    chkCategorias.Items[0].Selected = true;
                        //}
                        //if (objDataset.Tables[0].Rows[0]["Snacks"].ToString() == "1")
                        //{
                        //    chkCategorias.Items[1].Selected = true;
                        //}
                        //if (objDataset.Tables[0].Rows[0]["Cuidado"].ToString() == "1")
                        //{
                        //    chkCategorias.Items[2].Selected = true;
                        //}
                        //if (objDataset.Tables[0].Rows[0]["Bebes"].ToString() == "1")
                        //{
                        //    chkCategorias.Items[3].Selected = true;
                        //}
                        //if (objDataset.Tables[0].Rows[0]["Belleza"].ToString() == "1")
                        //{
                        //    chkCategorias.Items[4].Selected = true;
                        //}

                        //        bool existeCambio = false;
                        //        if(Convert.ToBoolean(farmaciaant) == chkCategorias.Items[0].Selected)
                        //            existeCambio = (existeCambio && true);
                        //        if(
                        #endregion
                        cliente.RegistrarHistoricoCatInteres(farmaciaant, snacksant, cuidadoperant, bebesant, bellezaant, tarjeta);
                    }

                    ds = cliente.ActualizarDatosCliente(txtNombre.Text, txtAP.Text, txtAM.Text, txtMail.Text + "@" + dominio, txtCelular.Text, ddlAno.SelectedValue.ToString() + ddlMes.SelectedValue.ToString() + ddlDia.SelectedValue.ToString(), rdoGenero.SelectedValue, rdoHijos.SelectedValue, txtCP.Text, ddlEstado.SelectedValue, ddlCiudad.SelectedValue, farmacia, SnacksBebidas, CuidadoPersonal, Bebes, Belleza, tarjeta);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string respuesta = ds.Tables[0].Rows[0]["CodigoRespuesta_StrCodigo"].ToString();
                        if (respuesta == "AW9901")
                        {
                            string Mensaje = "Se han actualizado los datos de manera exitosa.";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "');window.location.href='MisDatos.aspx'", true);
                        }
                        else
                        {
                            string mensaje = ds.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString();
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
                else
                {
                    Mensajes("El estado y ciudad no corresponden al código postal indicado. Favor de validar código postal");
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

        protected void btnValidarCP_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                try
                {
                    DataSet dsCP = new DataSet();
                    Catalogos cat = new Catalogos();

                    dsCP = cat.DatosCatalogoSepoMex("CPEncuesta", txtCP.Text.Trim(), "");

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
                            txtCP.Text = string.Empty;
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

        protected void txtCP_TextChanged(object sender, EventArgs e)
        {
            btnValidarCP_Click(btnValidarCP, new ImageClickEventArgs(0, 0));
        }

        protected void lnkValidaCP_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsCP = new DataSet();
                Catalogos cat = new Catalogos();

                dsCP = cat.DatosCatalogoSepoMex("CPEncuesta", txtCP.Text.Trim(), "");

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
                        txtCP.Text = string.Empty;
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
