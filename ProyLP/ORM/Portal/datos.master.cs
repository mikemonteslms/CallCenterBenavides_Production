using System;
using System.Data;
using System.Linq;
using System.Web.Security;

namespace Portal
{
    public partial class datos : System.Web.UI.MasterPage
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
                CargaDatosParticipante(Session["participante_id"].ToString());
            }
        }
        public void MuestraMensaje(string mensaje)
        {
            Master.MuestraMensaje(mensaje);
        }
        public void GuardaAcceso(string pagina)
        {
            Master.GuardaAcceso(pagina);
        }
        public void MenuActivo(string menu)
        {
            switch(menu)
            {
                case "contraseña":
                    lnkContrasena.CssClass = "submenu_activo";
                    break;
                case "micuenta":
                    lnkEstadoCuenta.CssClass = "submenu_activo";
                    break;
                case "canjes":
                    lnkCanjes.CssClass = "submenu_activo";
                    break;
                case "carrito":
                    lnkCarrito.CssClass = "submenu_activo";
                    break;
                case "premios":
                    lnkPremios.CssClass = "submenu_activo";
                    break;
            }
        }
        private void CargaDatosParticipante(string participante_id)
        {
            csParticipanteComplemento p = new csParticipanteComplemento();
            p.ID = participante_id;
            p.DatosParticipante();
            lblNombre.Text = p.Nombre;
            lblApellidoPaterno.Text = p.ApellidoPaterno;
            lblApellidoMaterno.Text = p.ApellidoMaterno;

            string fecha_nacimiento = "-";
            string fecha_alta = "-";
            try
            {
                DateTime fechanac = Convert.ToDateTime(p.FechaNacimiento);
                if (fechanac.Year > 1900)
                {
                    fecha_nacimiento = fechanac.ToString("dd/MM/yyyy");
                }
            }
            catch
            { }
            try
            {
                DateTime fechaalta = Convert.ToDateTime(p.FechaStatus);
                if (fechaalta.Year > 1900)
                {
                    fecha_alta = fechaalta.ToString("dd/MM/yyyy");
                }
            }
            catch
            { }
            lblFechaNacimiento.Text = fecha_nacimiento;
            lblFechaAlta.Text = fecha_alta;

            lblTipoParticipante.Text = p.TipoParticipante;
            lblDistribuidor.Text = p.Distribuidora;
            lblEmail.Text = p.CorreoElectronico.ToLower();
            DataTable dtTel = p.ConsultaTelefono();

            var celular = (from tel in dtTel.AsEnumerable()
                           where tel.Field<string>("tipotelefono").ToLower().Equals("celular")
                           select new { Numero = tel.Field<string>("telefono") }).SingleOrDefault();
            lblCelular.Text = celular != null ? celular.Numero : "-";

        }
    }
}