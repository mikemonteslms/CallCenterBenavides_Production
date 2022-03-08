using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace MnuMain
{
    public partial class SiteMaster : MasterPage
    {
        private string menumain;

        public string MenuMain
        {
            get { return menumain; }
            set { menumain = value; }
        }
        private string submenu;

        public string Submenu
        {
            get { return submenu; }
            set { submenu = value; }
        }

        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // El código siguiente ayuda a proteger frente a ataques XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Utilizar el token Anti-XSRF de la cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
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
                // Establecer token Anti-XSRF
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validar el token Anti-XSRF
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
                }
            }
             
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Membership.GetUser() != null)
                {
                    hidUserId.Value = Membership.GetUser().ProviderUserKey.ToString();
                }
            }
            menuLbl.Text = menumain;
            subMenuLbl.Text = submenu;
            if(string.IsNullOrEmpty(menumain))
            {
                 menuLbl.Text = "Principal";
                lblMayor.Visible = false;
            }
            else
                lblMayor.Visible = true;
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();//Context.GetOwinContext().Authentication.SignOut();
        }
        protected void RadMenu1_ItemDataBound(object sender, RadMenuEventArgs e)
        {
            DataRowView dataRow = e.Item.DataItem as DataRowView;
            if (dataRow != null)
            {
                e.Item.ToolTip = dataRow["alt"].ToString(); // TooTip                
                e.Item.NavigateUrl = dataRow["url"].ToString(); // Agrega la url
            }
        }
        public void MuestraMensaje(string mensaje)
        {
            //lblMensajePopup.Text = mensaje;
            //popMensaje.Show();
        }
    }
}