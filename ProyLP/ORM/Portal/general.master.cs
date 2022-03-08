using System;

namespace Portal
{
    public partial class general : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void MuestraMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;
            popMensaje.Show();
        }
        public void AgregaEvento(string evento)
        {
            btnCerrar.OnClientClick = evento;
        }
    }
}