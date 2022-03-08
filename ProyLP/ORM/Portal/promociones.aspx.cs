using System;
using System.Web.Security;

namespace Portal
{
    public partial class promociones : System.Web.UI.Page
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
                CargaNoticias(Session["participante_id"].ToString());
                Master.GuardaAcceso("Promociones");
            }
        }
        private void CargaNoticias(string participante_id)
        {
            csParticipanteComplemento p = new csParticipanteComplemento();
            p.ID = participante_id;
            p.DatosParticipante();

            if (p.TipoParticipante.Equals("GERENTE DE SERVICIOS FINANCIEROS"))
            {
                mvNoticias.SetActiveView(vGSF);
            }
            else
            {
                mvNoticias.SetActiveView(vVendedores);
            }
        }
    }
}