using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Security;
using System.Web.Security;

namespace CallcenterNUevo.segundoplano
{
    public partial class rptTraspasos : System.Web.UI.Page
    {
        private Thread vHilo;
        static string usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                usuario = HttpContext.Current.User.Identity.Name; 
            }
            Master.MenuMain = "Operaciones";
            Master.Submenu = "Archivo Traspasos";
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {

            vHilo = new Thread(new ThreadStart(Proceso));
            vHilo.Start();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Procesando el reporte, cuando quede generado te enviaremos un correo electrónico.');", true);
        }
        public static void Proceso()
        {
            //string usuario = (Session["username"] != null) ? Session["username"].ToString() : "juancarlos.vasquez@mx.lms-la.com";
            MembershipUser users = Membership.GetUser(usuario);

            Reportes ReportesHilo = new Reportes();
            ReportesHilo.GeneraReportesFTP(11,users.Email);
        }
    }
}