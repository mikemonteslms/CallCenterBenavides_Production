using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class premios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "" || Session["participante_id"] == null)
            {
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                ConsultaDetalleCanjes(ConfigurationManager.AppSettings["programa"], Session["participante_id"].ToString());
                Master.GuardaAcceso("Premios");
                Master.MenuActivo("premios");
            }
        }
        public void ConsultaDetalleCanjes(string programa, string Participante_id)
        {
            csRMS canjes = new csRMS();
            List<DetalleCanjesParticipante> listaCanjes = new List<DetalleCanjesParticipante>();
            listaCanjes = canjes.ConsultaFoliosParticipanteRMS(programa, Participante_id);
            lvDetalleEntregaPremios.DataSource = listaCanjes;
            lvDetalleEntregaPremios.DataBind();
        }
    }
}