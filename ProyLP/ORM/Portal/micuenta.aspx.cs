using System;
using System.Web.Security;

namespace Portal
{
    public partial class micuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["participante_id"] == null)
            {
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                Master.GuardaAcceso("Mi cuenta");
                Master.MenuActivo("micuenta");
                ConsultDatosParticipante(Session["participante_id"].ToString());
            }
        }
        private void ConsultDatosParticipante(string participante_id)
        {
            csParticipante p = new csParticipante();
            p.ID = participante_id;

            lblSaldo.Text = int.Parse(p.Saldo).ToString("N0");

            lvTransacciones.DataSource = p.Transacciones();
            lvTransacciones.DataBind();
        }
    }
}