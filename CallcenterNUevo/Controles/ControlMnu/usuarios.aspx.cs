using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Datos;
using System.Configuration;
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;


namespace CallcenterNUevo.Controles.ControlMnu
{
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaCombo();
            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool blnRespuesta = true;
            //MembershipCreateStatus createStatus;

            try
            {
                if (Validaciones(1))
                {
                    Usuariosapp Ejecuta = new Usuariosapp();

                    MembershipUser user;

                    //user = Membership.CreateUser(txtUsuario.Text, "nuevousuario1!", txtmail.Text, "prueba", "nuevousuario1!", true, out createStatus);
                    //Asigna nuevo password 
                    bool blnRegistro = false;
                    Usuariosapp Ejecutar = new Usuariosapp();
                    string pwd = Ejecutar.SecurityAccess(txtUsuario.Text.Trim());

                    ModUsuarioapp campos = new ModUsuarioapp();
                    campos.Usuario = txtUsuario.Text.Trim();
                    campos.NombreUsuario = txtUsuario.Text.Trim();
                    campos.Password = pwd;
                    campos.eMail = txtmail.Text.Trim();

                    if (Ejecutar.RegistrarUsuarioapp(campos))
                    {
                        blnRegistro = true;
                    }

                    switch (blnRegistro)
                    {
                        case true:
                            //This Case Occured whenver User Created Successfully in database  

                            //recorre checkboxlist para asignar roles a usuario
                            foreach (ListItem elemento in chklstRoles.Items)
                            {
                                if (elemento.Selected)
                                {
                                    //rgistra roles a usuario
                                    blnRespuesta = Ejecuta.RegistrarRolesUser(txtUsuario.Text.Trim(), elemento.Value.ToUpper());
                                }
                            }

                            //string pwd = Membership.Provider.ResetPassword(txtUsuario.Text, "benavides");
                            //Enviar mail a usuario con nuevo password
                            //Usuariosapp ejecutar = new Usuariosapp();
                            //ejecutar.EnvioMailUsuarioaCC(txtUsuario.Text.Trim(), txtmail.Text, pwd);

                            Mensajes("El nuevo usuario fue registrado correctamente.");

                            break;
                        //// This Case Occured whenver we send duplicate UserName  
                        //case MembershipCreateStatus.DuplicateUserName:
                        //    Mensajes("El usuario que se dispone a dar de alta ya existe.");
                        //    LimpiarCampos(1);
                        //    break;
                        ////This Case Occured whenver we give duplicate mail id  
                        //case MembershipCreateStatus.DuplicateEmail:
                        //    Mensajes("El correo electronico que se dispone a dar de alta ya existe.");
                        //    LimpiarCampos(1);
                        //    break;
                        ////This Case Occured whenver we send invalid mail format  
                        //case MembershipCreateStatus.InvalidEmail:
                        //    Mensajes("El correo electronico que se dispone a dar de alta no cuenta con un formato valido.");
                        //    LimpiarCampos(1);
                        //    break;
                        ////This Case Occured whenver we send empty data or Invalid Data  
                        //case MembershipCreateStatus.InvalidAnswer:
                        //    Mensajes("Datos invalidos verifique su información e intente de nuevo.");
                        //    LimpiarCampos(1);
                        //    break;
                        //// This Case Occured whenver we supplied weak password  
                        //case MembershipCreateStatus.InvalidPassword:
                        //    Mensajes("El password debe contar con una longitud de 7 caracteres y almenos un caracter especial.");
                        //    LimpiarCampos(1);
                        //    break;
                        default:
                            Mensajes("Ocurrio un error al intentar dar de alta el usuario.");
                            LimpiarCampos(1);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.Controles.ControlMnu.usuarios", "btnRegistrar_Click", "Membership.CreateUser(" + txtUsuario.Text + ",'nuevousuario'," + txtmail.Text + ", 'nuevousuario','nuevousuario', true , out createStatus )", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar dar de alta a un usuario, contacte al administrador");
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mvUsuarios.SetActiveView(vBusqueda);
            LimpiarCampos(1);
            LimpiarCampos(2);
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarUsuarios();
        }
        protected void btnCancelaBusca_Click(object sender, EventArgs e)
        {
            LimpiarCampos(1);
            LimpiarCampos(2);
            Response.Redirect("../../Default.aspx");
        }
        protected void imgbtnAltaUsuario_Click(object sender, ImageClickEventArgs e)
        {
            mvUsuarios.SetActiveView(vAltaUsuario);
        }
        protected void btnSi_Click(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.User.Identity.Name == selUsuario.Value)
                {
                    Mensajes("Imposible eliminar al usuario " + selUsuario.Value + ", se encuentra en sesión activa.");
                    txtBuscaUsuario.Text = "";
                    selUsuario.Value = "";
                    return;
                }

                if (EliminaUsuario(selUsuario.Value))
                {
                    Mensajes("El usuario: " + selUsuario.Value + ", ha sido eliminado correctamente.");
                    txtBuscaUsuario.Text = "";
                    selUsuario.Value = "";
                    BuscarUsuarios();
                }
                else
                {
                    Mensajes("No fue posible eliminar al usuario: " + selUsuario.Value + ", Intente de nuevo.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnNo_Click(object sender, EventArgs e)
        {

        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (Validaciones(2))
            {
                if (ModificarUsuario(selUsuario.Value))
                {
                    Mensajes("Se actualizo correctamente el usuario.");
                }
            }
        }
        protected void btnCanclearM_Click(object sender, EventArgs e)
        {
            LimpiarCampos(1);
            LimpiarCampos(2);
            mvUsuarios.SetActiveView(vBusqueda);
        }
        protected void grvDatosUsuarios_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string Usuario = e.CommandArgument.ToString();
            try
            {
                switch (e.CommandName.ToString())
                {
                    case "EliminaUsuario":
                        selUsuario.Value = Usuario;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                        break;
                    case "EditaUsuario":
                        selUsuario.Value = Usuario;
                        CargaInfoUsuario(selUsuario.Value);
                        mvUsuarios.SetActiveView(VEditaUsuario);
                        break;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.Controles.ControlMnu.usuarios", "EliminaUsuario", "Ejecuta.EliminarUsuarioapp(" + Usuario + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar eliminar al usuario: " + Usuario + ", contacte al administrador");
            }
        }
        protected void grvDatosUsuarios_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            BuscarUsuarios();
        }

        private void CargaCombo()
        {
            try
            {
                Usuariosapp Ejecuta = new Usuariosapp();
                List<ModRoles> lstRespuesta = new List<ModRoles>();
                lstRespuesta = Ejecuta.ObtenRoles();

                if (lstRespuesta != null)
                {
                    if (lstRespuesta.Count > 0)
                    {
                        chklstRoles.Items.Clear();
                        chklstRoles.DataSource = lstRespuesta;
                        chklstRoles.DataTextField = "RoleName";
                        chklstRoles.DataValueField = "roleid";
                        chklstRoles.DataBind();

                        chklstRolesM.Items.Clear();
                        chklstRolesM.DataSource = lstRespuesta;
                        chklstRolesM.DataTextField = "RoleName";
                        chklstRolesM.DataValueField = "roleid";
                        chklstRolesM.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.Controles.ControlMnu.usuarios", "CargaCombo()", "Ejecuta.ObtenRoles()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar Roles, contacte al administrador");
            }

        }
        private void BuscarUsuarios()
        {
            List<ModUsuarioapp> lstResultados = new List<ModUsuarioapp>();
            Usuariosapp Ejecuta = new Usuariosapp();
            lstResultados = Ejecuta.ObtenUsuariosapp(txtBuscaUsuario.Text);

            grvDatosUsuarios.DataSource = lstResultados;
            grvDatosUsuarios.DataBind();
        }
        private void CargaInfoUsuario(string Usuario)
        {
            ModContenedorUsuarios Resultado = new ModContenedorUsuarios();
            Usuariosapp Ejecuta = new Usuariosapp();
            string PasswordDesencriptado = "";

            Resultado = Ejecuta.ObtenUsuarioModifica(Usuario);

            txtUsuarioM.Text = Resultado.Usuarios.Usuario;
            txteMailM.Text = Resultado.Usuarios.eMail;
            //txtNombreM.Text = Resultado.Usuarios.NombreUsuario;
            txtPasswordEdit.Text = Resultado.Usuarios.Password;

            if (Resultado.Usuarios.Activa == 0)
            {
                //Activa
                chkActivo.Text = "Activo";
                chkActivo.Checked = true;
            }
            else
            {
                //Bloquea
                chkActivo.Text = "Bloqueado";
                chkActivo.Checked = false;
            }

            foreach (ModRoles reg in Resultado.lstRoles.ToList())
            {
                foreach (ListItem elemento in chklstRolesM.Items)
                {
                    if (elemento.Value == reg.RoleId)
                    {
                        elemento.Selected = true;
                    }
                }
            }
        }
        private bool ModificarUsuario(string usuario)
        {
            bool blnRespuesta = true;
            ModUsuarioapp campos = new ModUsuarioapp();
            Usuariosapp Ejecuta = new Usuariosapp();

            campos.Usuario = txtUsuarioM.Text;
            //campos.NombreUsuario = txtNombreM.Text;
            campos.eMail = txteMailM.Text;
            campos.Password = txtPasswordEdit.Text;
            if (chkActivo.Checked)
            {
                //Activa
                campos.Activa = 0;
            }
            else
            {
                //Bloquea
                campos.Activa = 1;
            }

            //Registra usuario
            blnRespuesta = Ejecuta.ModificarUsuarioapp(campos);
            //LimpiaRoles
            Ejecuta.EliminarRolesUser(campos);

            if (blnRespuesta)
            {
                //recorre checkboxlist para asignar roles a usuario
                foreach (ListItem elemento in chklstRolesM.Items)
                {
                    if (elemento.Selected)
                    {
                        //rgistra roles a usuario
                        blnRespuesta = Ejecuta.RegistrarRolesUser(txtUsuarioM.Text, elemento.Value);
                    }
                }

                if (blnRespuesta)
                {
                    Mensajes("Se actualizo el usuario correctamente.");
                    //LimpiarCampos(2);
                }
            }
            else
            {
                Mensajes("No fue posible actualizar el usuario, verifique su información.");
                txtUsuarioM.Focus();
            }

            return blnRespuesta;
        }
        private bool EliminaUsuario(string Usuario)
        {
            bool blnRespuesta = false;
            try
            {
                Usuariosapp Ejecuta = new Usuariosapp();
                blnRespuesta = Ejecuta.EliminarUsuarioapp(Usuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return blnRespuesta;
        }
        private bool Validaciones(int Transaccion)
        {
            bool blnRespuesta = true;

            switch (Transaccion)
            {
                case 1://Altas
                    if (string.IsNullOrWhiteSpace(txtUsuario.Text))
                    {
                        Mensajes("Es necesario proporcione un usuario.");
                        txtUsuario.Focus();
                        blnRespuesta = false;
                    }

                    if (string.IsNullOrWhiteSpace(txtmail.Text))
                    {
                        Mensajes("Es necesario proporcione un email.");
                        txtmail.Focus();
                        blnRespuesta = false;
                    }

                    int totalRoles = chklstRoles.Items.Count;
                    int cuentaRoles = 0;
                    foreach (ListItem elemento in chklstRoles.Items)
                    {
                        if (!elemento.Selected)
                        {
                            cuentaRoles += 1;
                        }
                    }

                    if (cuentaRoles == totalRoles)
                    {
                        Mensajes("Es necesario seleccionar almenos un elemento del catálogo de roles.");
                        chklstRoles.Focus();
                        blnRespuesta = false;
                    }
                    break;
                case 2://Modificaciones
                    if (string.IsNullOrWhiteSpace(txtUsuarioM.Text))
                    {
                        Mensajes("Es necesario proporcione un usuario.");
                        txtUsuarioM.Focus();
                        blnRespuesta = false;
                    }

                    if (string.IsNullOrWhiteSpace(txteMailM.Text))
                    {
                        Mensajes("Es necesario proporcione un email.");
                        txteMailM.Focus();
                        blnRespuesta = false;
                    }

                    int totalRolesM = chklstRolesM.Items.Count;
                    int cuentaRolesM = 0;
                    foreach (ListItem elemento in chklstRolesM.Items)
                    {
                        if (!elemento.Selected)
                        {
                            cuentaRolesM += 1;
                        }
                    }

                    if (cuentaRolesM == totalRolesM)
                    {
                        Mensajes("Es necesario seleccionar almenos un elemento del catálogo de roles.");
                        chklstRolesM.Focus();
                        blnRespuesta = false;
                    }
                    break;
            }

            return blnRespuesta;
        }

        private void LimpiarCampos(int Transaccion)
        {
            switch (Transaccion)
            {
                case 1:
                    txtUsuario.Text = "";
                    txtmail.Text = "";
                    chklstRoles.ClearSelection();
                    txtUsuario.Focus();
                    break;
                case 2:
                    txtUsuarioM.Text = "";
                    txteMailM.Text = "";
                    chklstRolesM.ClearSelection();
                    txtUsuarioM.Focus();
                    break;
            }

        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void btnResetPwd_Click(object sender, EventArgs e)
        {
            bool blnRespuesta = false;
            try
            {
                if (!chkActivo.Checked)
                {
                    Mensajes("La cuenta se encuentra bloqueada por lo tanto no es posible ejecutar este proceso.");
                    return;
                }
                ModUsuarioapp campos = new ModUsuarioapp();
                Usuariosapp Ejecutar = new Usuariosapp();
                txtPasswordEdit.Text = Ejecutar.SecurityAccess(txtUsuarioM.Text.Trim());
                //txtPasswordEdit.Text = Membership.Provider.ResetPassword(txtUsuarioM.Text, "benavides1!");

                campos.Usuario = txtUsuarioM.Text;
                campos.eMail = txteMailM.Text;
                campos.Password = txtPasswordEdit.Text;

                //Modifica usuario y reestablese nuevo password
                blnRespuesta = Ejecutar.ModificarUsuarioapp(campos);
                //Enviar mail a usuario con nuevo password
                Usuariosapp ejecutar = new Usuariosapp();
                ejecutar.EnvioMailUsuarioaCC(txtUsuarioM.Text, txteMailM.Text, txtPasswordEdit.Text);

                if (blnRespuesta)
                {
                    Mensajes("La cuenta ha sido reestablecida correctamente.");
                }
                else
                {
                    Mensajes("No fue posible enviar credenciales al usuario.");
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.Controles.ControlMnu.usuarios", "btnResetPwd_Click", " Membership.Provider.ResetPassword(" + txtUsuarioM.Text + ",benavides1!)", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar restaurar contraseña. contacte al administrador");
            }
        }
    }
}