using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web.Security;

namespace Portal.recupera
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
                Session.Clear();
            }
        }
        protected void LoginUser_Error(MembershipUser currentUser)
        {
            string mensaje = "";
            if (currentUser == null)
            {
                //The GetUser method could not find a user with the given name. 
                //This indicates that the username entered does not exist.
                mensaje = "Nombre de usuario o correo electrónico incorrectos. Por favor intenta nuevamente.";
            }
            else
            {
                //Check to see if the error occurred because they are not approved.
                if (!currentUser.IsApproved)
                {
                    mensaje = "Tu cuenta aún no ha sido aprobada. Verifica con tu distribuidor.";
                }
                //Check to see if they are currently locked out.
                else if (currentUser.IsLockedOut)
                {
                    mensaje = "Tu cuenta ha sido bloqueada, Por favor intente nuevamente en 10 minutos.";
                }
                //If none of these conditions have been met, the password is incorrect.
                else
                {
                    mensaje = "Nombre de usuario o correo electrónico incorrectos. Por favor intenta nuevamente.";
                }
            }
            Master.MuestraMensaje(mensaje);
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            MembershipUser currentUser = Membership.GetUser(txtUsuario.Text);
            if (currentUser != null)
            {
                if(txtEmail.Text == currentUser.Email)
                {
                    recupera(currentUser);
                }
                else
                {
                    Master.MuestraMensaje("Nombre de usuario o correo electrónico incorrectos. Por favor intenta nuevamente.");
                }
            }
            else
            {
                LoginUser_Error(currentUser);
            }
            txtUsuario.Text = "";
            txtEmail.Text = "";
        }
        private void recupera(MembershipUser user)
        {
            Funciones f = new Funciones();
            CryptoUtil c = new CryptoUtil();
            string usr = user.ProviderUserKey.ToString();
            string pwd = user.ResetPassword();
            pwd = pwd.Replace("|", "_");
            DateTime fecha = DateTime.Now;
            string hash = f.passwordConHash(pwd, f.generaCadenaAleatoria());

            csUsuario u = new csUsuario();
            u.UserID = usr;
            u.Fecha_Recovery = fecha;
            u.Hash = hash;
            if (u.InsertaRecovery())
            {
                string cr = c.htmlEncodeTripleDES(usr + "|" + pwd + "|" + fecha.ToString("ddMMyyyyHHmmssffff") + "|" + hash);
                string plantilla = Server.MapPath("../mailing/recuperar_contrasena.html");
                string html = "";
                using (StreamReader sr = new StreamReader(plantilla))
                {
                    html = sr.ReadToEnd();
                }
                html = html.Replace("@DATOS", cr);
                //e.Message.Body = html;

                CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(ConfigurationManager.AppSettings["programa"]);
                CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();

                mail.ToMail = user.Email;
                mail.ToName = user.Email;
                
                List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                cliente.Add(mail);
                
                string Subject = "Recupera tu contraseña";
                CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, html);
                if (r.Codigo == "OK")
                {
                    Master.MuestraMensaje("Se ha enviado un correo a su cuenta registrada.");
                }
                else
                {
                    Master.MuestraMensaje("Ocurrió un error al recuperar el password. Intente nuevamente");
                }
            }
            else
            {
                Master.MuestraMensaje("Ocurrió un error al recuperar el password. Intente nuevamente");
            }
        }
    }
}