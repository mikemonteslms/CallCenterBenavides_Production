using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;
using System.IO;
using System.Text;

namespace ORMOperacion
{
    public partial class mantenimientoDatosGeneralesParticipantes : System.Web.UI.Page
    {
        private static Random _random = new Random((int)DateTime.Now.Ticks);
        protected void Page_PreRender(object sender, EventArgs e)
        {
            cmpFechaNacimiento.MinimumValue = DateTime.Now.AddYears(-110).ToString("dd/MM/yyyy");
            cmpFechaNacimiento.MaximumValue = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy");
            rngFechaAlta.MinimumValue = DateTime.Now.AddYears(-110).ToString("dd/MM/yyyy");
            rngFechaAlta.MaximumValue = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                if (Session["participante_id"] != null && Session["participante"] != null)
                {
                    Master.Menu = "Participantes";
                    Master.Submenu = "Datos Generales";
                    CargaCatalogos((Session["participante"] as csParticipanteComplemento).Programa);
                    CargaDatosParticipante(Session["participante_id"].ToString());
                    // No muestra el botón Generico si no tiene correo
                    if (txtEmail1.Text.Trim() == "")
                    {
                        btnGenerico.Visible = false;
                    }
                    else
                    {
                        btnGenerico.Visible = true;
                    }
                }
                else
                {
                    Response.Redirect("default.aspx", false);
                }
            }
            else
            {
                /* Direccion */
            }
        }

        protected void CargaCatalogos(String country_code)
        {
            csCatalogo cat = new csCatalogo();
            cat.Catalogo = "distribuidor";
        }

        protected void CargaDatosParticipante(string participante_id)
        {
            csParticipanteComplemento p = new csParticipanteComplemento();
            p.ID = participante_id;
            p.DatosParticipante();
            lblPrograma.Text = p.Programa;
            lblDistribuidor.Text = p.Distribuidora;
            lblClave.Text = p.Clave;
            lblRazonSocial.Text = p.RazoSocial;
            txtNombre.Text = p.Nombre;
            txtApellidoPaterno.Text = p.ApellidoPaterno;
            txtApellidoMaterno.Text = p.ApellidoMaterno;
            txtFechaNacimiento.Text = p.FechaNacimiento;

            txtDNI.Text = p.DocumentoIdentidad;
            txtEmail1.Text = p.CorreoElectronico;
            chkEmail.Checked = Convert.ToBoolean(int.Parse(p.InformacionEmail));

            ///*Direccion Distribuidor*/
            //csDistribuidor distri = new csDistribuidor();
            //distri.ID = int.Parse(p.Distribuidora_ID);
            //distri.ConsultaDireccion();
            //lblCalle.Text = distri.Direccion.Calle;
            //lblNumExterior.Text = distri.Direccion.NumeroExterior;
            ////lblEstado.Text = distri.Direccion.Estado;
            ////lblMunicipio.Text = distri.Direccion.Municipio;
            ////lblColonia.Text = distri.Direccion.Colonia;
            //lblCodigoPostal.Text = distri.Direccion.CodigoPostal;

            csDireccion dir = new csDireccion();
            dir.Participante = participante_id;
            dir.TipoDireccion = "1";
            dir.Consulta();

            lblCalle.Text = dir.Calle;
            lblNumInterior.Text = dir.NumeroInterior;
            lblNumExterior.Text = dir.NumeroExterior;
            //lblEntreCalle.Text = dir.EntreCalle;
            //lblYcalle.Text = dir.YCalle;
            //lblColonia.Text = dir.Colonia;
            //lblAsentamiento.Text = dir.Asentamiento;
            lblCodigoPostal.Text = dir.CodigoPostal;
            if (dir.CodigoPostal != null)
            {
                dir.BuscaDireccionXCP();
                rcbColonia.DataSource = dir.CargaAsentamientosXID();
                rcbColonia.DataBind();
                rcbDelegacion.DataSource = dir.CargaDelegacionMunicipioXCP();
                rcbDelegacion.DataBind();
                rcbEstado.DataSource = dir.CargaEstadosXID();
                rcbEstado.DataBind();
            }

            /* Teléfonos */
            DataTable dtTel = p.ConsultaTelefono();
            foreach (DataRow drTel in dtTel.Rows)
            {
                switch (drTel["tipotelefono"].ToString().ToLower())
                {
                    case "casa":
                        hidTelCasaID.Value = drTel["telefono_id"].ToString();
                        txtTelCasa.Text = drTel["telefono"].ToString();
                        break;
                    case "trabajo":
                        hidTelTrabajoID.Value = drTel["telefono_id"].ToString();
                        txtTelTrabajo.Text = drTel["telefono"].ToString();
                        break;
                    case "celular":
                        hidTelCelularID.Value = drTel["telefono_id"].ToString();
                        txtTelCelular.Text = drTel["telefono"].ToString();
                        break;
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                csParticipanteComplemento part = Session["participante"] as csParticipanteComplemento;
                MembershipUser usr = Membership.GetUser();
                csParticipante p = new csParticipante();

                p.ID = Session["participante_id"].ToString();
                p.Clave = part.Clave;
                p.Nombre = txtNombre.Text;
                p.ApellidoPaterno = txtApellidoPaterno.Text;
                p.ApellidoMaterno = txtApellidoMaterno.Text;
                p.FechaNacimiento = txtFechaNacimiento.Text;
                p.Clave = lblClave.Text;
                p.RazoSocial = lblRazonSocial.Text;
                p.FechaNacimiento = txtFechaNacimiento.Text;

                p.CorreoElectronico = txtEmail1.Text;
                p.DocumentoIdentidad = txtDNI.Text.Trim();
                p.InformacionEmail = chkEmail.Checked == true ? "1" : "0";


                p.Distribuidora_ID = part.Distribuidora_ID;
                p.TipoParticipante_ID = part.TipoParticipante_ID;
                p.Aspnet_UserId = usr.ProviderUserKey.ToString();
                p.Status_ID = part.Status_ID;

                p.Actualiza();

                /* Actualiza membership */
                csUsuario usuario = new csUsuario();
                usuario.Participante_ID = Session["participante_id"].ToString();
                usuario.ParticipanteUsuario();
                MembershipUser u = Membership.GetUser(new Guid(usuario.UserID));
                u.Email = txtEmail1.Text.Trim();
                Membership.UpdateUser(u);

                /* Actualiza membership */

                csCatalogo cat = new csCatalogo();
                cat.Catalogo = "tipo_telefono";
                DataTable dtTel = cat.Consulta();
                string casa_id = "", celular_id = "", trabajo_id = "";
                foreach (DataRow drTel in dtTel.Rows)
                {
                    switch (drTel["descripcion"].ToString().ToLower())
                    {
                        case "casa":
                            casa_id = drTel["id"].ToString();
                            break;
                        case "trabajo":
                            trabajo_id = drTel["id"].ToString();
                            break;
                        case "celular":
                            celular_id = drTel["id"].ToString();
                            break;
                    }
                }

                if (txtTelCelular.Text.Trim().Length > 0)
                {
                    if (hidTelCelularID.Value.Length > 0)
                    {
                        p.ActualizaTelefono(hidTelCelularID.Value, "", txtTelCelular.Text, "", celular_id, null);
                    }
                    else
                    {
                        p.InsertaTelefono(celular_id, "", txtTelCelular.Text, "", null);
                    }
                }
                if (txtTelCasa.Text.Trim().Length > 0)
                {
                    if (hidTelCasaID.Value.Length > 0)
                    {
                        p.ActualizaTelefono(hidTelCasaID.Value, "", txtTelCasa.Text, "", casa_id, "");
                    }
                    else
                    {
                        p.InsertaTelefono(casa_id, "", txtTelCasa.Text, "", "");
                    }
                }
                if (txtTelTrabajo.Text.Trim().Length > 0)
                {
                    if (hidTelTrabajoID.Value.Length > 0)
                    {
                        p.ActualizaTelefono(hidTelTrabajoID.Value, "", txtTelTrabajo.Text, "", trabajo_id, "");
                    }
                    else
                    {
                        p.InsertaTelefono(trabajo_id, "", txtTelTrabajo.Text, "", "");
                    }
                }
                /* control direccion */
                /* control direccion */

                Master.MuestraMensaje("Sus datos se actualizaron correctamente.");
            }
            catch (Exception ex)
            {
                Master.MuestraMensaje("Ocurrió un error al actualizar sus datos. Por favor intente nuevamente.");
            }
        }

        protected void btnGenerico_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtiene el username
                csUsuario usr = new csUsuario();
                usr.Participante_ID = Session["participante_id"].ToString();
                usr.ParticipanteUsuario();
                MembershipUser u = Membership.GetUser(new Guid(usr.UserID));

                // Cambia temporalmente el password porque contiene muchos caracteres especiales
                string tmp_password = u.ResetPassword();
                string nuevo_password = RandomString(5);
                u.ChangePassword(tmp_password, nuevo_password);

                string plantilla = "";
                switch ((Session["participante"] as csParticipanteComplemento).Programa.ToUpper())
                {
                    case "AUDI":
                        plantilla = Server.MapPath("plantillas/datosacceso_generico_audi.html");
                        break;
                    case "PORSCHE":
                        plantilla = Server.MapPath("plantillas/datosacceso_generico_porsche.html");
                        break;
                    case "SEAT":
                        plantilla = Server.MapPath("plantillas/datosacceso_generico_seat.html");
                        break;
                    case "VW":
                        plantilla = Server.MapPath("plantillas/datosacceso_generico_vw.html");
                        break;
                }
                string html = "";
                using (StreamReader sr = new StreamReader(plantilla))
                {
                    html = sr.ReadToEnd();
                }
                csParticipanteComplemento part = Session["participante"] as csParticipanteComplemento;
                html = html.Replace("@NOMBRE", part.NombreCompleto);
                html = html.Replace("@USUARIO", u.UserName);
                html = html.Replace("@CONTRASENA", nuevo_password);

                CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));

                CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();
                mail.ToMail = txtEmail1.Text.Trim();
                mail.ToName = part.NombreCompleto;
                List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                cliente.Add(mail);
                CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, "Datos de acceso", html);
                if (r.Codigo == "OK")
                {
                    Master.MuestraMensaje("Se ha enviado un mensaje a su correo registrado con los datos de acceso.");
                }
                else
                {
                    Master.MuestraMensaje("<p>Ocurrió un error al enviar mensaje de confirmación.</p><p>Por favor utilice la función recuperar contraseña en el login.</p><p>" + r.Mensaje + "</p>");
                }
            }
            catch (Exception ex)
            {
                Master.MuestraMensaje("Ocurrió un error al enviar la contraseña<br/>" + ex.Message);
            }
        }
        public string RandomString(int length)
        {
            string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder builder = new StringBuilder(length);

            for (int i = 0; i < length; ++i)
                builder.Append(chars[_random.Next(chars.Length)]);

            return builder.ToString();
        }

        protected void btnDireccion_Click(object sender, EventArgs e)
        {
            csDireccion d = new csDireccion();
            d.Participante = Session["participante_id"].ToString();
            d.Usuario = Membership.GetUser().ProviderUserKey.ToString();
            d.TipoDireccion = "1";

            d.Calle = lblCalle.Text;
            d.NumeroExterior = lblNumExterior.Text;
            d.NumeroInterior = lblNumInterior.Text;
            //d.EntreCalle = lblEntreCalle.Text;
            //d.YCalle = lblYcalle.Text;
            d.CodigoPostal = lblCodigoPostal.Text;
            d.AsentamientoID = rcbColonia.SelectedValue;

            try
            {
                DataTable direcciones = d.ConsultaDireccion();
                if (direcciones.Rows.Count > 0)
                {
                    d.Actualiza();
                }
                else
                {
                    d.Inserta();
                }
                Master.MuestraMensaje("Dirección actualizada correctamente");
            }
            catch (Exception ex)
            {
                Master.MuestraMensaje("Ocurrio un errror al actualizar");
            }
        }

        protected void btnCP_Click(object sender, EventArgs e)
        {
            csDireccion dir = new csDireccion();
            dir.CodigoPostal = lblCodigoPostal.Text;
            dir.BuscaDireccionXCP();
            rcbColonia.DataSource = dir.CargaAsentamientosCP();
            rcbColonia.DataBind();
            rcbDelegacion.DataSource = dir.CargaDelegacionMunicipioXCP();
            rcbDelegacion.DataBind();
            rcbEstado.DataSource = dir.CargaEstadosXID();
            rcbEstado.DataBind();

            //dirAccordion.Attributes["class"] += " acc_active";
            //genAccordion.Attributes["class"] = genAccordion.Attributes["class"].Replace("acc_active", "");
        }
    }
}