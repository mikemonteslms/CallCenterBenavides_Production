using System;
using System.Web.Security;

namespace Portal
{
    public partial class guias : System.Web.UI.Page
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
                CargaGuias(Session["participante_id"].ToString());
                Master.GuardaAcceso("Guia y tips");
            }
        }
        private void CargaGuias(string participante_id)
        {
            csParticipanteComplemento p = new csParticipanteComplemento();
            p.ID = participante_id;
            p.DatosParticipante();

            if (p.TipoParticipante.Equals("GERENTE DE SERVICIOS FINANCIEROS"))
            {
                pnlGSF.Visible = true;
            }
        }
    }
}