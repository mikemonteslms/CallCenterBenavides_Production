using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;

namespace ORMOperacion.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //throw new InvalidCastException("I am an exception!");            
        }

        protected void LoginUser_LoggedIn(object sender, AuthenticateEventArgs e)
        {
            if (Membership.ValidateUser(LoginUser.UserName, LoginUser.Password))
            {
                MembershipUser currentUser = Membership.GetUser(LoginUser.UserName);
                string UserId = string.Empty;
                if (currentUser != null)
                {
                    csUsuario u = new csUsuario();
                    u.UserID = currentUser.ProviderUserKey.ToString();
                    if (u.UserID != null)
                    {
                        e.Authenticated = true;
                        UserId = currentUser.ProviderUserKey.ToString();
                        Session["part_id"] = u.Participante_ID;
                    }
                    else
                        e.Authenticated = false;
                }
            }
        }

        protected void LoginUser_Error(object sender, EventArgs e)
        {
            MembershipUser currentUser = Membership.GetUser(LoginUser.UserName);
            if (currentUser == null)
            {
                //The GetUser method could not find a user with the given name. 
                //This indicates that the username entered does not exist.
                LoginUser.FailureText = "Nombre de usuario o contraseña incorrectos. Por favor intenta nuevamente.";
            }
            else
            {
                //Check to see if the error occurred because they are not approved.
                if (!currentUser.IsApproved)
                {
                    LoginUser.FailureText = "Tu cuenta aún no ha sido aprobada. Verifica con tu distribuidor.";
                }
                //Check to see if they are currently locked out.
                else if (currentUser.IsLockedOut)
                {
                    LoginUser.FailureText = "Tu cuenta ha sido bloqueada, Por favor intente nuevamente en 10 minutos.";
                }
                //If none of these conditions have been met, the password is incorrect.
                else
                {
                    LoginUser.FailureText = "Nombre de usuario o contraseña incorrectos. Por favor intenta nuevamente.";
                }
            }
        }
    }
}