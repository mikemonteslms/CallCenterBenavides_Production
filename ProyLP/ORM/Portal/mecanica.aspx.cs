using System;
using System.Web.Security;

namespace Portal
{
    public partial class mecanica : System.Web.UI.Page
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
                Master.GuardaAcceso("Mecanica");
                if (Session["participante_id"] != null)
                {
                    CargaDatosParticipante(Session["participante_id"].ToString());
                }
            }
        }
        protected void CargaDatosParticipante(string participante_id)
        {
            csParticipanteComplemento p = new csParticipanteComplemento();
            p.ID = Session["participante_id"].ToString();
            p.DatosParticipante();
            if (p.TipoParticipante.ToUpper() == "GERENTE DE SERVICIOS FINANCIEROS")
            {
                mvMecanica.SetActiveView(vGSF);
            }
            else
            {
                mvMecanica.SetActiveView(vGerentesVendedores);
            }
        }
    }
}