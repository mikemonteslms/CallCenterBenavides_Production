using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class contenido : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["participante_id"] == null)
            {
                CierraSesion();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                CargaMenu(Session["participante_id"].ToString());
                //menuLoad();
                CargaDatosParticipante(Session["participante_id"].ToString());
                if (Session["distribuidor_id"] == null)
                {
                    CargaDistribuidor();
                }
                if (Roles.IsUserInRole("Administrador"))
                {
                    lnkBusqueda.Visible = true;
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["participante_id"] != null)
            {
                csParticipanteComplemento p = new csParticipanteComplemento();
                p.ID = Session["participante_id"].ToString();
                p.DatosParticipante();

                if (!(p.TipoParticipante.Equals("GERENTE DE SERVICIOS FINANCIEROS")))
                {
                    scriptMenu.Attributes.Add("href", "css/menuVendedor.css");
                }
            }
        }

        protected void logStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            CierraSesion();
            FormsAuthentication.RedirectToLoginPage();
        }
        private void CargaMenu(string participante_id)
        {
            csParticipanteComplemento p = new csParticipanteComplemento();
            p.ID = participante_id;
            p.DatosParticipante();

            if (!(p.TipoParticipante.Equals("GERENTE DE SERVICIOS FINANCIEROS")))
            {
                rad_menu.Items.FindItemByValue("asignacionventas").Visible = false;
                rad_menu.Items.FindItemByValue("divisor_asignacionventas").Visible = false;
            }
        }
        private void CargaDatosParticipante(string participante_id)
        {
            csParticipanteComplemento p = new csParticipanteComplemento();
            p.ID = participante_id;
            p.DatosParticipante();
            lblNombre.Text = p.NombreCompleto;
            lblSaldo.Text = int.Parse(p.Saldo).ToString("N0");
        }
        public void MuestraMensaje(string mensaje)
        {
            Master.MuestraMensaje(mensaje);
        }
        public void AgregaEvento(string evento)
        {
            Master.AgregaEvento(evento);
        }
             
        public void GuardaAcceso(string pagina)
        {
            cs_controlaccesos control = new cs_controlaccesos();
            control.InsertaAccesoWeb(Membership.GetUser().ProviderUserKey.ToString(), pagina);
        }
        public void CargaDistribuidor()
        {
            csParticipante p = new csParticipante();
            p.ID = Session["participante_id"].ToString();
            List<csDistribuidor> distri = p.ConsultaDistribuidores();
            if (distri.Count > 1)
            {
                rptDistribuidores.DataSource = distri;
                rptDistribuidores.DataBind();
                popDistribuidores.Show();
            }
            else
            {
                csDistribuidor d = distri[0];
                string host = HttpContext.Current.Request.Url.AbsoluteUri;
                if (host.Contains(d.Programa) || host.Contains("localhost"))
                {
                    Session["distribuidor_id"] = d.ID;
                }
                else
                {
                    if (d.Descripcion == "LOYALTY")
                    {
                        Session["distribuidor_id"] = d.ID;
                    }
                    else
                    {
                        CierraSesion();
                        Response.Redirect(d.Programa);
                    }
                }
            }
        }
        private void CierraSesion()
        {
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
        }
        protected void btnCerrarDistribuidores_Click(object sender, EventArgs e)
        {
            CierraSesion();
            FormsAuthentication.RedirectToLoginPage();
        }
        protected void SeleccionaDistribuidor_Command(object sender, CommandEventArgs e)
        {
            string host = HttpContext.Current.Request.Url.AbsoluteUri;
            string programa = e.CommandArgument.ToString();
            if (host.Contains(programa) || host.Contains("localhost"))
            {
                Session["distribuidor_id"] = e.CommandName;
            }
            else
            {
                CierraSesion();
                Response.Redirect(programa);
            }
        }
    }
}
