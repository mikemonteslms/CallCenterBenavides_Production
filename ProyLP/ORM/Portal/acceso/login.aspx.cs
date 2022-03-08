using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace Portal.acceso
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
                        u.ParticipanteUsuario();
                        if (u.Participante_ID != null)
                        {
                            if (u.Country_Code == "LOY")
                            {
                                Session["participante_id"] = u.Participante_ID;
                            }
                            else
                            {
                                csParticipante p = new csParticipante();
                                p.ID = u.Participante_ID;
                                List<csDistribuidor> distri = p.ConsultaDistribuidores();
                                bool programa = false;
                                foreach (csDistribuidor d in distri)
                                {
                                    if (d.ClavePrograma == System.Configuration.ConfigurationManager.AppSettings["programa"])
                                    {
                                        Session["participante_id"] = u.Participante_ID;
                                        programa = true;
                                        break;
                                    }
                                }
                                if (programa == false)
                                {
                                    e.Authenticated = false;
                                }
                            }
                        }
                        else
                        {
                            e.Authenticated = false;
                        }
                    }
                    else
                    {
                        e.Authenticated = false;
                    }
                }
            }
        }

        protected void LoginUser_Error(object sender, EventArgs e)
        {
            MembershipUser currentUser = Membership.GetUser(LoginUser.UserName);
            string mensaje = "";
            if (currentUser == null)
            {
                //The GetUser method could not find a user with the given name. 
                //This indicates that the username entered does not exist.
                mensaje = "Nombre de usuario o contraseña incorrectos. Por favor intenta nuevamente.";
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
                    mensaje = "Nombre de usuario o contraseña incorrectos. Por favor intenta nuevamente.";
                }
            }
            Master.MuestraMensaje(mensaje);
        }
    }
}