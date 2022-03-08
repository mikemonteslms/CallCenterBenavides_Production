using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ORMOperacion
{
    public partial class consultaEventosParticipantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                if (Session["participante_id"] != null && Session["participante"] != null)
                {
                    Master.Menu = "Participantes";
                    Master.Submenu = "Eventos";
                }
                else
                {
                    Response.Redirect("default.aspx", false);
                }
            }
        }
    }
}