using System;
using System.Configuration;
using System.Data;
using System.Web.Security;

namespace Portal
{
    public partial class _default : System.Web.UI.Page
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
                Master.GuardaAcceso("Inicio");

                csParticipanteComplemento p = new csParticipanteComplemento();
                DataTable blog = p.ConsultaBlog(ConfigurationManager.AppSettings["programa"], "ACTIVO");
                DataRow drInicial = blog.NewRow();
                drInicial[0] = 0;
                drInicial[1] = "Loyalty World";
                drInicial[2] = "Bienvenido al Programa Loyalty World de Volkswagen Servicios Financieros, recuerda que tus ventas de productos financieros te generan Kilómetros… ¡Participa!";
                drInicial[3] = new DateTime(2014,04,01);
                drInicial[4] = "ACTIVO";
                blog.Rows.Add(drInicial);
                rptBlog.DataSource = blog;
                rptBlog.DataBind();
                
            }
        }
        protected void btnEnviarComent_Click(object sender, EventArgs e)
        {
            EnviarComentario();
        }

        public void EnviarComentario()
        {
            csParticipanteComplemento p = new csParticipanteComplemento();
            if (frm_mensaje.Text == "")
            {
                Master.MuestraMensaje("Escribe tu comentario por favor.");
                return;
            }
            p.InsertaCometarioBlog(Convert.ToInt32(Session["participante_id"].ToString()), frm_mensaje.Text.Trim());
            rptBlog.DataSource = p.ConsultaBlog(ConfigurationManager.AppSettings["programa"], "ACTIVO");
            rptBlog.DataBind();
            frm_mensaje.Text = "";
            Master.MuestraMensaje("Tu opinion ha sido agregada.");
        }
    }
}