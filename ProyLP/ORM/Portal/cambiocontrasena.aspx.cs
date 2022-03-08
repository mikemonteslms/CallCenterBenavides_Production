using System;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class cambiocontrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Master.GuardaAcceso("Cambia contraseña");
                Master.MenuActivo("contraseña");
            }
        }
        protected void ChangeUserPassword_SendingMail(object sender, MailMessageEventArgs e)
        {
            e.Cancel = true;
        }

    }
}