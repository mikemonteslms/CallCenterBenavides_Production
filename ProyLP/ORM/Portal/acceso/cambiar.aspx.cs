using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Portal.cambiar
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
        protected void ChangeUserPassword_ChangingPassword(Object sender, LoginCancelEventArgs e)
        {
            if (Request.QueryString["data"] != null)
            {
                try
                {
                    CryptoUtil c = new CryptoUtil();
                    string decusr = Request.QueryString["data"].ToString();
                    string data = c.htmlDecodeTripleDES(decusr);
                    string[] usr = data.Split('|');
                    csUsuario u = new csUsuario();
                    u.UserID = usr[0];
                    DateTime fecha = new DateTime(int.Parse(usr[2].Substring(4, 4)),
                                                  int.Parse(usr[2].Substring(2, 2)),
                                                  int.Parse(usr[2].Substring(0, 2)),
                                                  int.Parse(usr[2].Substring(8, 2)),
                                                  int.Parse(usr[2].Substring(10, 2)),
                                                  int.Parse(usr[2].Substring(12, 2)),
                                                  int.Parse(usr[2].Substring(14, 3)));
                    u.Hash = usr[3];
                    u.RecuperaRecovery();
                    if (u.UserID.ToUpper() == usr[0].ToUpper() &&
                            (u.Fecha_Recovery.Year == fecha.Year &&
                             u.Fecha_Recovery.Month == fecha.Month &&
                             u.Fecha_Recovery.Day == fecha.Day &&
                             u.Fecha_Recovery.Hour == fecha.Hour &&
                             u.Fecha_Recovery.Minute == fecha.Minute &&
                             u.Fecha_Recovery.Second == fecha.Second) &&
                        u.Hash.ToUpper() == usr[3].ToUpper() &&
                        u.Fecha_Recovery.AddDays(3) >= DateTime.Now)
                    {
                        Membership.GetUser(new Guid(usr[0])).ChangePassword(usr[1], ChangeUserPassword.NewPassword);
                        e.Cancel = true;
                        Master.MuestraMensaje("Su cuentraseña fue actualizada correctamente.");
                    }
                    else
                    {
                        e.Cancel = true;
                        ChangeUserPassword.ChangePasswordFailureText = "Ocurrió un error al actualizar su contraseña.<br/>Por favor intente nuevamente";
                    }
                }
                catch (Exception ex)
                {
                    MembershipUser u = Membership.GetUser();
                    string errMail = "Error en la aplicacion " + Membership.ApplicationName +
                            "<br/><br/>Fecha: " + DateTime.Now.ToString() +
                            "<br/><br/>Pagina:<br/>" + Request.Url.ToString() +
                            "<br/><br/>Usuario:<br/>" + u != null ? u.UserName : "Anonimo" +
                            "<br/><br/>Mensaje de error:<br/>" + ex.Message +
                            "<br/><br/>Mas detalle del error:<br/>" +
                            (ex.InnerException != null ? ex.InnerException.Message : "") +
                            "<br/><br/>Stack Trace:<br/>" + ex.StackTrace.ToString() +
                            "<br/><br/>Error Completo:<br/>" + ex.ToString();

                    CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(ConfigurationManager.AppSettings["programa"]);
                    CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();

                    mail.ToMail = "vsilvac@lms.com.mx";
                    mail.ToName = "Victor Silva Cabrera";

                    List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                    cliente.Add(mail);

                    string Subject = "Loyalty World - Error en: " + Membership.ApplicationName;
                    CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, errMail);

                    ChangeUserPassword.ChangePasswordFailureText = "Ocurrió un error al actualizar su contraseña.<br/>Por favor intente nuevamente";
                }
            }
            else
            {
                ChangeUserPassword.ChangePasswordFailureText = "Ocurrió un error al actualizar su contraseña.<br/>Por favor intente nuevamente";
            }
        }
    }
}