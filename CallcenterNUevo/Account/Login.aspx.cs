//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
//using MnuMain.Models;
using System.Web.Security;

namespace MnuMain.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn(object sender, EventArgs e)
        {
            //quita del campo UserName.Text, todos los caracteres de espacio en blanco iniciales y finales
            UserName.Text = UserName.Text.Trim();

            if (Membership.ValidateUser(UserName.Text, Password.Text))
            {
                Session["UsuarioCC"] = UserName.Text.ToString();
                FormsAuthentication.SetAuthCookie(UserName.Text, true);
                if (Request.QueryString["ReturnUrl"] != null)
                    Response.Redirect(Request.QueryString["ReturnUrl"]);
                else
                    Response.Redirect("~/Default.aspx");
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                lblmsg.Text = "El usuario y/o contraseña son incorrectos. Intente de nuevo";
                lblmsg.Visible = true;
                UserName.Text = "";
                Password.Text = "";
                UserName.Focus();
            }
        }
    }
}