using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.IO;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;

namespace ORMOperacion
{
    public partial class usuarios : System.Web.UI.Page
    {
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
                Master.Menu = "Control de acceso";
                Master.Submenu = "Usuarios";
                gvUsuarios.Visible = false;
            }
            //throw new InvalidCastException("I am an exception!");               
        }

        protected void btnBusquedaUsuarios_Click(object sender, EventArgs e)
        {
            ViewState.Remove("usuario");
            BuscaUsuarios(txtBusqueda.Text);
            mvUsuarios.SetActiveView(vBusqueda);
        }

        protected void BuscaUsuarios(string busqueda)
        {
            MembershipUserCollection users;
            if (busqueda.Length > 0)
            {
                users = Membership.FindUsersByName(txtBusqueda.Text);
            }
            else
            {
                users = Membership.GetAllUsers();
            }
            gvUsuarios.Visible = true;
            gvUsuarios.DataSource = users;
            gvUsuarios.DataBind();
        }

        protected void lnkNuevo_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "usuario":
                    txtNuevoUsuario.Text = "";
                    txtNuevoContrasena.Text = "";
                    txtNuevoConfirmarContrasena.Text = "";
                    txtNuevoEmail.Text = "";
                    chkNuevoActivo.Checked = true;
                    txtNuevoPregunta.Text = "";
                    txtNuevoRespuesta.Text = "";
                    chkRolesListNuevo.DataSource = Roles.GetAllRoles();
                    chkRolesListNuevo.DataBind();
                    mvUsuarios.SetActiveView(vNuevoUsuario);
                    break;
                case "participante":
                    //CargaCatalogos();
                    CargaPais();
                    mvUsuarios.SetActiveView(vNuevoParticipante);
                    break;

            }
        }

        protected void User_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ver":
                    ViewState["usuario"] = e.CommandArgument.ToString();
                    MembershipUser uver = Membership.GetUser(e.CommandArgument.ToString());
                    txtvIDUsuario.Text = uver.UserName;
                    txtvCorreoElectronico.Text = uver.Email;
                    lblFechaAlta.Text = uver.CreationDate.ToString("dd/MM/yyyy hh:mm tt");
                    lblUltimoAcceso.Text = uver.LastLoginDate.ToString("dd/MM/yyyy hh:mm tt");
                    mvUsuarios.SetActiveView(vVer);
                    break;
                case "editar":
                    ViewState["usuario"] = e.CommandArgument.ToString();
                    chkRolesListEditar.Items.Clear();
                    rbStatus.SelectedIndex = -1;

                    MembershipUser u = Membership.GetUser(e.CommandArgument.ToString());
                    txtIDUsuario.Text = u.UserName;
                    txtCorreoElectronico.Text = u.Email;
                    txtComentarios.Text = u.Comment;
                    // Obtener el id del participante para obtener el status
                    // Si no está es que es interno o no es un participante, entonces solo checar
                    // si esta IsApproved para considerarlo como activo, sino está como inactivo
                    csUsuario usr = new csUsuario();
                    usr.UserID = u.ProviderUserKey.ToString();
                    usr.ParticipanteUsuario();
                    if (usr.Participante_ID != null)
                    {
                        csParticipanteComplemento p = new csParticipanteComplemento();
                        p.ID = usr.Participante_ID;
                        p.DatosParticipante();
                        if (u.IsLockedOut && p.Status.ToUpper() != "BAJA")
                        {
                            rbStatus.SelectedValue = "I";
                        }
                        else if (!u.IsApproved && p.Status.ToUpper() == "BAJA")
                        {
                            rbStatus.SelectedValue = "B";
                        }
                        else if (u.IsApproved && p.Status.ToUpper() == "ACTIVO")
                        {
                            rbStatus.SelectedValue = "A";
                        }
                        else
                        {
                            rbStatus.SelectedValue = "I";
                        }
                    }

                    string[] _roles_usuario = Roles.GetRolesForUser(u.UserName);
                    string[] _roles = Roles.GetAllRoles();
                    foreach (string r in _roles)
                    {
                        ListItem l = new ListItem(r);
                        if (Roles.IsUserInRole(u.UserName, r))
                        {
                            l.Selected = true;
                        }
                        chkRolesListEditar.Items.Add(l);
                    }
                    // Checar si tiene rol Distribuidora                    
                    foreach (ListItem li in chkRolesListEditar.Items)
                    {
                        if (li.Selected && li.Value == "Distribuidor")
                        {
                            tbDistribuidorEditar.Visible = true;
                            CargaProgramasEditar();
                            CargaDistribuidoraEditar();
                            break;
                        }
                    }
                    //
                    mvUsuarios.SetActiveView(vEditar);
                    break;
                case "eliminar":
                    try
                    {
                        // Elimina en la tabla participante_aspnet_User
                        csDataBase elimina = new csDataBase();
                        elimina.Query = "participante_aspnet_User_Delete";
                        List<SqlParameter> parametros = new List<SqlParameter>();
                        parametros.Add(new SqlParameter("@aspnet_UserId", Membership.GetUser(e.CommandArgument.ToString()).ProviderUserKey));
                        elimina.EsStoreProcedure = true;
                        elimina.Parametros = parametros;
                        elimina.acutualizaDatos();
                        // elimina de la tabla distribuidor_aspnet_user
                        elimina = new csDataBase();
                        elimina.Query = "sp_elimina_Distribuidora_aspnet_User";
                        elimina.EsStoreProcedure = true;
                        parametros = new List<SqlParameter>();
                        parametros.Add(new SqlParameter("@UserId", Membership.GetUser(e.CommandArgument.ToString()).ProviderUserKey));
                        elimina.Parametros = parametros;
                        elimina.acutualizaDatos();
                        // elimina de la tabla bitacora_accesos
                        elimina = new csDataBase();
                        elimina.Query = "bitacora_accesos_usuario_id_Delete";
                        elimina.EsStoreProcedure = true;
                        parametros = new List<SqlParameter>();
                        parametros.Add(new SqlParameter("@usuario_id", Membership.GetUser(e.CommandArgument.ToString()).ProviderUserKey));
                        elimina.Parametros = parametros;
                        elimina.acutualizaDatos();
                        if (Membership.DeleteUser(e.CommandArgument.ToString(), true))
                        {
                            BuscaUsuarios(txtBusqueda.Text);
                            Master.MuestraMensaje("Usuario eliminado correctamente");
                        }
                        else
                        {
                            Master.MuestraMensaje("Ocurrió un error al eliminar el usuario.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Master.MuestraMensaje("<p><b>Ocurrió un error al eliminar el usuario:</b></p>" + ex.Message);
                    }
                    break;
                case "password":
                    ViewState["usuario"] = e.CommandArgument.ToString();
                    mvUsuarios.SetActiveView(vPassword);
                    break;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (rbStatus.SelectedItem.Value == "I")
            {
                Master.MuestraMensaje("No se puede actualizar el status a Inactivo");
                return;
            }
            try
            {
                MembershipUser u = Membership.GetUser(ViewState["usuario"].ToString());
                u.Email = txtCorreoElectronico.Text;
                u.Comment = txtComentarios.Text;
                Membership.UpdateUser(u);
                if (rbStatus.SelectedItem.Value == "A")
                {
                    Boolean blockuser = u.UnlockUser();
                    u.IsApproved = true;
                }
                else
                {
                    u.IsApproved = false;
                }
                Membership.UpdateUser(u);

                csUsuario usr = new csUsuario();
                usr.UserID = u.ProviderUserKey.ToString();
                usr.ParticipanteUsuario();
                usr.ActualizaStatus(rbStatus.SelectedItem.Text);

                foreach (ListItem l in chkRolesListEditar.Items)
                {
                    if (l.Selected)
                    {
                        if (!Roles.IsUserInRole(u.UserName, l.Text))
                        {
                            Roles.AddUserToRole(u.UserName, l.Text);
                        }
                    }
                    else
                    {
                        if (Roles.IsUserInRole(u.UserName, l.Text))
                        {
                            Roles.RemoveUserFromRole(u.UserName, l.Text);
                        }
                    }
                }
                // 1ro elimina antes de insertar Distribuidor
                csDataBase eliminaDistribuidor = new csDataBase();
                eliminaDistribuidor.Query = "sp_elimina_Distribuidora_aspnet_User";
                eliminaDistribuidor.EsStoreProcedure = true;
                List<SqlParameter> paramElimina = new List<SqlParameter>();
                paramElimina.Add(new SqlParameter("@UserId", u.ProviderUserKey.ToString()));
                eliminaDistribuidor.Parametros = paramElimina;
                eliminaDistribuidor.acutualizaDatos();
                //                    
                // Si es Rol Distribuidor agrega las distribuidoras
                if (tbDistribuidorEditar.Visible == true)
                {
                    foreach (RadListBoxItem l in rlbDistribuidorEditarDestino.Items)
                    {
                        String distribuidor_id = l.Value;
                        String user_id = u.ProviderUserKey.ToString();
                        csDataBase inserta = new csDataBase();
                        inserta.Query = "sp_inserta_distribuidor_aspnet_User";
                        inserta.EsStoreProcedure = true;
                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@distribuidor_id", distribuidor_id));
                        param.Add(new SqlParameter("@UserId", user_id));
                        inserta.Parametros = param;
                        inserta.acutualizaDatos();
                    }
                }
                mvUsuarios.SetActiveView(vBusqueda);
                Master.MuestraMensaje("Usuario actualizado correctamente.");
            }
            catch (Exception ex)
            {
                Master.MuestraMensaje("<p><b>Ocurrió un error al actualizar el usuario:</b></p>" + ex.Message);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                MembershipCreateStatus status;
                MembershipUser usr = Membership.CreateUser(txtNuevoUsuario.Text, txtNuevoContrasena.Text, txtNuevoEmail.Text, "pregunta1", "respuesta1", chkNuevoActivo.Checked, out status);
                if (usr == null)
                {
                    Master.MuestraMensaje(GetErrorMessage(status));
                }
                else
                {
                    foreach (ListItem l in chkRolesListNuevo.Items)
                    {
                        if (l.Selected)
                        {
                            Roles.AddUserToRole(usr.UserName, l.Text);
                        }
                    }
                    // Si es Rol Distribuidor agrega las distribuidoras
                    if (tbDistribuidorNuevo.Visible == true)
                    {
                        foreach (RadListBoxItem l in rlbDistribuidorNuevoDestino.Items)
                        {
                            String distribuidor_id = l.Value;
                            String user_id = usr.ProviderUserKey.ToString();
                            csDataBase inserta = new csDataBase();
                            inserta.Query = "sp_inserta_distribuidor_aspnet_User";
                            inserta.EsStoreProcedure = true;
                            List<SqlParameter> param = new List<SqlParameter>();
                            param.Add(new SqlParameter("@distribuidor_id", distribuidor_id));
                            param.Add(new SqlParameter("@UserId", user_id));
                            inserta.Parametros = param;
                            inserta.acutualizaDatos();
                        }
                    }
                    Master.MuestraMensaje("Usuario agregado correctamente.");
                }
            }
            catch (Exception ex)
            {
                Master.MuestraMensaje("Ocurrio un error al agregar usuario.");
            }
        }

        protected void btnAgregarParticipante_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    csDistributor d = new csDistributor();
            //    d.ID = int.Parse(ddlDistribuidor.SelectedItem.Value);


            //    csParticipante p = new csParticipante();
            //    p.Clave = txtParticipanteClave.Text.Trim();
            //    p.Nombre = txtParticipanteNombre.Text.Trim();
            //    p.ApellidoPaterno = txtParticipanteApellidoPaterno.Text.Trim();
            //    p.ApellidoMaterno = txtParticipanteApellidoMaterno.Text.Trim();
            //    p.Sexo_ID = chkGenero.SelectedItem.Value;
            //    p.TipoParticipante_ID = ddlPuesto.SelectedItem.Value;
            //    p.CorreoElectronico = txtParticipanteEmail.Text.Trim();
            //    p.EstadoCivil_ID = ddlEstadoCivil.SelectedItem.Value;
            //    p.FechaNacimiento = txtFechaNacimiento.Text;
            //    p.Distribuidora_ID = ddlDistribuidor.SelectedItem.Value;
            //    p.Status = "P_ar";
            //    p.Inserta();



            //    Master.MuestraMensaje("Participante agregado correctamente.");
            //}
            //catch (Exception ex)
            //{
            //    Master.MuestraMensaje("<p><b>Ocurrió un error al insertar el participante:</b></p>" + ex.Message);
            //}
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            BuscaUsuarios(txtBusqueda.Text);
            mvUsuarios.SetActiveView(vBusqueda);
        }

        protected void CargaPais()
        {
            /* Pais */
            //csCountry country = new csCountry();
            //ddlPais.DataSource = country.CargaCountry();
            //ddlPais.DataBind();
            //ddlPais.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        protected void CargaCatalogos()
        {
            //csCatalogo cat = new csCatalogo();
            //cat.Country_code = ddlPais.SelectedValue;
            //cat.Catalogo = "estado_civil";
            //ddlEstadoCivil.DataSource = cat.Consulta().DefaultView;
            //ddlEstadoCivil.DataBind();
            //cat.Catalogo = "sexo";
            //chkGenero.DataSource = cat.Consulta().DefaultView;
            //chkGenero.DataBind();
            //cat.Catalogo = "tipo_participante";
            //cat.Country_code = null;
            //ddlPuesto.DataSource = cat.Consulta();
            //ddlPuesto.DataBind();
            //foreach (ListItem l in ddlPuesto.Items)
            //{
            //    if (l.Text.ToLower().Contains("vtas"))
            //    {
            //        l.Selected = true;
            //        break;
            //    }
            //}

            /* Distribuidor */
            //ddlDistribuidor.Items.Clear();
            //csDistributor d = new csDistributor(ddlPais.SelectedValue);
            //ddlDistribuidor.DataSource = d.Consulta();
            //ddlDistribuidor.DataBind();
            //ddlDistribuidor.Items.Insert(0, new ListItem("Seleccione", "0"));
            //ddlGerente.Items.Clear();
            //ddlSupervisor.Items.Clear();
        }


        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaCatalogos();
        }

        public string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "El nombre de usuario ya existe. Por favor introduzca otro.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Ya existe un usuario asociado a ese e-mail. Por favor introduzca otro e-mail";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "El e-mail introducido es incorrecto.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }


        protected void ddlDistribuidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlGerente.Items.Clear();
            //csDistributor d = new csDistributor();
            //ddlGerente.DataSource = d.ConsultaGerentes(decimal.Parse(ddlDistribuidor.SelectedItem.Value));
            //ddlGerente.DataBind();
            //ddlGerente.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        protected void ddlGerente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlSupervisor.Items.Clear();
            //csDistributor d = new csDistributor();
            //ddlSupervisor.DataSource = d.ConsultaSupervisores(decimal.Parse(ddlGerente.SelectedItem.Value));
            //ddlSupervisor.DataBind();
            //ddlSupervisor.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        protected void btnResetear_Click(object sender, EventArgs e)
        {
        }

        protected void btnGenerico_Click(object sender, EventArgs e)
        {
            CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();

            List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
            try
            {
                MembershipUser usuario = Membership.GetUser(txtvIDUsuario.Text);
                string usr = usuario.ProviderUserKey.ToString();
                csUsuario u = new csUsuario();
                u.UserID = usr;
                Boolean bactualiza = u.ActualizaPasswordGenerico();
                if (bactualiza == true)
                {
                    string plantilla;
                    u.ObtieneCountry_UserID();
                    switch (u.Country_Code)
                    {
                        case "BR":
                            plantilla = Server.MapPath("plantillas/registro_generico_br.html");
                            break;
                        default:
                            plantilla = Server.MapPath("plantillas/registro_generico_cc.html");
                            break;
                    }
                    string html = "";
                    using (StreamReader sr = new StreamReader(plantilla))
                    {
                        html = sr.ReadToEnd();
                    }
                    html = html.Replace("@ESTILO", ConfigurationManager.AppSettings["estilos"]);
                    html = html.Replace("@DOMINIO", ConfigurationManager.AppSettings["dominio"]);
                    html = html.Replace("@USERNAME", usuario.UserName);
                    if (u.Nombre != null)
                        html = html.Replace("@NOMBRECOMPLETO", u.Nombre.Trim().Length > 0 ? u.Nombre : usuario.UserName);
                    else
                        html = html.Replace("@NOMBRECOMPLETO", usuario.UserName); // para el caso del usuario administrador
                    if (u.CPF != null)
                        html = html.Replace("@CPF", u.CPF);
                    else
                        html = html.Replace("@CPF", usuario.UserName); // para el caso del usuario administrador

                    CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));

                    mail.ToMail = txtvCorreoElectronico.Text.Trim();
                    if (u.Nombre != null)
                        mail.ToName = u.Nombre.Trim().Length > 0 ? u.Nombre : usuario.UserName;
                    else
                        mail.ToName = usuario.UserName; // para el caso del usuario administrador
                    cliente.Add(mail);
                    string Subject = "Datos de acceso Triangulo Premia";
                    string Body = html;
                    CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, Body);
                    if (r.Codigo == "OK")
                        Master.MuestraMensaje("Se ha enviado un mensaje a su correo registrado con los datos de acceso.");
                    else
                        Master.MuestraMensaje("<p>Ocurrió un error al enviar mensaje de confirmación.</p><p>Por favor utilice la función recuperar contraseña en el login.</p>");
                }
            }
            catch (Exception ex)
            {
                CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
                mail.ToMail = "vsilvac@lms.com.mx";
                mail.ToName = "Victor Silva Cabrera";
                cliente.Add(mail);

                Funciones oFunciones = new Funciones();
                string errMail = "Error en la aplicacion " + Membership.ApplicationName +
                        "<br/><br/>Fecha: " + DateTime.Now.ToString() +
                        "<br/><br/>Pagina:<br/>" + Request.Url.ToString() +
                        "<br/><br/>Usuario:<br/>" + Membership.GetUser().UserName +
                        "<br/><br/>Mensaje de error:<br/>" + ex.Message +
                        "<br/><br/>Mas detalle del error:<br/>" +
                        (ex.InnerException != null ? ex.InnerException.Message : "") +
                        "<br/><br/>Stack Trace:<br/>" + ex.StackTrace.ToString() +
                        "<br/><br/>Error Completo:<br/>" + ex.ToString();
                string Subject = "Loyalty World - Error en: " + Membership.ApplicationName;
                string Body = errMail;
                CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, errMail);
                Master.MuestraMensaje("<p>Ocurrió un error al resetear la contraseña generica</p>");
            }
        }

        protected void chkRolesListNuevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bDistribuidor = false;
            foreach (ListItem li in chkRolesListNuevo.Items)
            {
                if (li.Selected && li.Value == "Distribuidor")
                {
                    tbDistribuidorNuevo.Visible = true;
                    CargaProgramas();
                  //  CargaDistribuidoraNuevo();
                    bDistribuidor = true;
                    break;
                }
            }
            if (bDistribuidor == false)
            {
                rlbDistribuidorNuevoOrigen.Items.Clear();
                rlbDistribuidorNuevoDestino.Items.Clear();
                tbDistribuidorNuevo.Visible = false;
            }
        }

        protected void chkRolesListEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boolean bDistribuidor = false;
            foreach (ListItem li in chkRolesListEditar.Items)
            {
                if (li.Selected && li.Value == "Distribuidor")
                {
                    tbDistribuidorEditar.Visible = true;
                    CargaDistribuidoraEditar();
                    CargaProgramasEditar();
                    bDistribuidor = true;
                    break;
                }
            }
            if (bDistribuidor == false)
            {
                rlbDistribuidorNuevoOrigen.Items.Clear();
                rlbDistribuidorNuevoDestino.Items.Clear();
                tbDistribuidorNuevo.Visible = false;
            }
        }

        private void CargaProgramas()
        {

            MembershipUser u = Membership.GetUser(Context.User.Identity.Name);
            csDataBase Distribuidora = new csDataBase();
            Distribuidora.Query = "SELECT p.id, p.descripcion FROM programa_aspnet_User pau, programa p WHERE pau.programa_id = p.id and UserId = '" + u.ProviderUserKey.ToString() + "'";
            Distribuidora.EsStoreProcedure = false  ;
         
            rcbPrograma.DataSource = Distribuidora.dtConsulta().DefaultView;
            rcbPrograma.DataTextField = "DESCRIPCION";
            rcbPrograma.DataValueField = "ID";
            rcbPrograma.DataBind();
        }



        private void CargaProgramasEditar()
        {

            MembershipUser u = Membership.GetUser(ViewState["usuario"].ToString());
            csDataBase Distribuidora = new csDataBase();
            Distribuidora.Query = "SELECT p.id, p.descripcion FROM programa_aspnet_User pau, programa p WHERE pau.programa_id = p.id and UserId = '" + u.ProviderUserKey.ToString() + "'";
            Distribuidora.EsStoreProcedure = false;

            rcbProgramaEditar.DataSource = Distribuidora.dtConsulta().DefaultView;
            rcbProgramaEditar.DataTextField = "DESCRIPCION";
            rcbProgramaEditar.DataValueField = "ID";
            rcbProgramaEditar.DataBind();


            csDataBase programa = new csDataBase();
            programa.Query = "SELECT DISTINCT d.programa_id [ID] FROM distribuidor_aspnet_User dau INNER JOIN distribuidor d ON dau.distribuidor_id = d.id WHERE UserId = '" + u.ProviderUserKey.ToString() + "'";
            programa.EsStoreProcedure = false;

            foreach (DataRow dr in programa.dtConsulta().Rows)
            {
                rcbProgramaEditar.FindItemByValue(dr["ID"].ToString()).Checked = true;
                
            }
        }

        private void CargaDistribuidoraNuevo()
        {
            string programas = "";
            foreach (RadComboBoxItem item in rcbPrograma.CheckedItems)
            {
                programas += item.Value + ", "; 
            }

            programas = programas.Substring(0, programas.Length - 2);

            MembershipUser u = Membership.GetUser(Context.User.Identity.Name);
            csDataBase Distribuidora = new csDataBase();
            Distribuidora.Query = "SELECT d.id, p.descripcion + ' - ' + d.descripcion [DESCRIPCION] FROM distribuidor d, programa p where d.programa_id = p.id and p.fecha_baja is null and p.id in (" + programas + ")";
            Distribuidora.EsStoreProcedure = false;

            rlbDistribuidorNuevoOrigen.DataSource = Distribuidora.dtConsulta().DefaultView;
            rlbDistribuidorNuevoOrigen.DataTextField = "DESCRIPCION";
            rlbDistribuidorNuevoOrigen.DataValueField = "ID";
            rlbDistribuidorNuevoOrigen.DataBind();
        }

        private void CargaDistribuidoraEditar()
        {
            MembershipUser u = Membership.GetUser(ViewState["usuario"].ToString());
            csDataBase Distribuidora = new csDataBase();
            Distribuidora.Query = "ObtieneDistribuidor_aspnet_User_origen";
            Distribuidora.EsStoreProcedure = true;
            List<SqlParameter> paramOrigen = new List<SqlParameter>();
            paramOrigen.Add(new SqlParameter("@UserId", u.ProviderUserKey.ToString()));
            Distribuidora.Parametros = paramOrigen;
            rlbDistribuidorEditarOrigen.DataSource = Distribuidora.dtConsulta().DefaultView;
            rlbDistribuidorEditarOrigen.DataTextField = "DESCRIPCION";
            rlbDistribuidorEditarOrigen.DataValueField = "ID";
            rlbDistribuidorEditarOrigen.DataBind();

            Distribuidora.Query = "ObtieneDistribuidor_aspnet_User_destino";
            Distribuidora.EsStoreProcedure = true;
            List<SqlParameter> paramDestino = new List<SqlParameter>();
            paramDestino.Add(new SqlParameter("@UserId", u.ProviderUserKey.ToString()));
            Distribuidora.Parametros = paramDestino;
            rlbDistribuidorEditarDestino.DataSource = Distribuidora.dtConsulta().DefaultView;
            rlbDistribuidorEditarDestino.DataTextField = "DESCRIPCION";
            rlbDistribuidorEditarDestino.DataValueField = "ID";
            rlbDistribuidorEditarDestino.DataBind();
        }

        protected void rlbDistribuidorNuevoOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = "";
            foreach (RadListBoxItem item in rlbDistribuidorNuevoDestino.Items)
            {
                item.Selected = true;
            }
        }

        protected void rlbDistribuidorNuevoOrigen_Inserted(object sender, RadListBoxEventArgs e)
        {
            string valor = "";
            foreach (RadListBoxItem item in rlbDistribuidorNuevoDestino.Items)
            {
                item.Selected = true;
            }
        }

        protected void rlbDistribuidorNuevoOrigen_TemplateNeeded(object sender, RadListBoxItemEventArgs e)
        {
            string valor = "";
            if (rlbDistribuidorNuevoDestino.Items.Count > 0)
            {
                foreach (RadListBoxItem item in rlbDistribuidorNuevoDestino.Items)
                {
                    item.Selected = true;
                }
            }
        }
        protected void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            try
            {
                MembershipUser uPass = Membership.GetUser(ViewState["usuario"].ToString());
                string old = uPass.ResetPassword();
                uPass.ChangePassword(old, txtNuevoPassword.Text);
                Master.MuestraMensaje("Se estableció su contraseña.");
            }
            catch (Exception ex)
            {
                Master.MuestraMensaje("<p><b>Ocurrió un error al cambiar el password:</b></p>" + ex.Message);
            }

        }

        protected void btnAddDP_Click(object sender, EventArgs e)
        {
            CargaDistribuidoraNuevo();
        }

        protected void gvUsuarios_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            MembershipUserCollection users;
            if (txtBusqueda.Text.Length > 0)
            {
                users = Membership.FindUsersByName(txtBusqueda.Text);
            }
            else
            {
                users = Membership.GetAllUsers();
            }
            gvUsuarios.DataSource = users;
        }
    }
}