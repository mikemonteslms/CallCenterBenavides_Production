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
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
               
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            string strAgent = Request.UserAgent;
            HttpBrowserCapabilities myBrowserCapabilities = Request.Browser;
            Int32 majorVersion = myBrowserCapabilities.MajorVersion;
            if (strAgent.Contains("like Gecko") && strAgent.Contains("Trident") && majorVersion == 0)
            {
                Page.ClientTarget = "uplevel";
            }

            //throw new InvalidOperationException("I am an exception!");         

            HyperLink hl = (System.Web.UI.WebControls.HyperLink)LoginView1.FindControl("hlCambi");
            Image img = (System.Web.UI.WebControls.Image)LoginView1.FindControl("imgLogo");
            if (hl != null)
            {
                this.RadToolTipManager1.TargetControls.Add(hl.ClientID, true);
            }

        }


        protected void RadToolTipManager1_AjaxUpdate(object sender, ToolTipUpdateEventArgs e)
        {
            //Funcionalidad para abrir el contenido del tootil cuando se haga clic sobre agregar funciones
            cambiarPassword ctrlAddRoles = (cambiarPassword)Page.LoadControl("~/cambiarPassword.ascx");
             e.UpdatePanel.ContentTemplateContainer.Controls.Add(ctrlAddRoles);
        }


       
    }
}