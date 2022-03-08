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
            if (Membership.ValidateUser(UserName.Text, Password.Text))
            {
                Session["UsuarioCC"] = UserName.Text.ToString();
                FormsAuthentication.SetAuthCookie(UserName.Text, true);
                Response.Redirect(Request.QueryString["ReturnUrl"]);
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
           
        }
    }
}