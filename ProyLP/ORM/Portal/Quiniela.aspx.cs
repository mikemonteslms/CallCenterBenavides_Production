using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class Quiniela : System.Web.UI.Page
    {
        private static int participanteID = 0;
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
            else
            {
                participanteID = int.Parse(Session["participante_id"].ToString());
            }
            if (!IsPostBack)            {
                
                //diaQuniela.Value = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy");
                diaQuniela.Value = DateTime.Now.ToString("dd/MM/yyyy");
                CargarPartidos(diaQuniela.Value);
            }
        }

        private void CargarPartidos(string Fecha)
        {
            lblFecha.Text = ("PARTIDOS DEL " + Convert.ToDateTime(diaQuniela.Value).ToString("dddd  d DE MMMM")).ToUpper();
            rlvPartidos.DataSource = CNegocio.csQuiniela.ObtenerPartidosQuniela(Fecha, participanteID);
            rlvPartidos.DataBind();

            if (Convert.ToDateTime(diaQuniela.Value) <= DateTime.Now)
            {
                ibtnGuardar.Enabled = false;
            }
            else
            {
                ibtnGuardar.Enabled = true;
            }

            if (diaQuniela.Value == "13/07/2014")
            {

                ibtnSiguiente.Enabled = false;
                ibtnAnterior.Enabled = true;
            }
            else if (diaQuniela.Value == "12/06/2014")
            {
                ibtnAnterior.Enabled = false;
                ibtnSiguiente.Enabled = true;
            }
            else
            {
                ibtnSiguiente.Enabled = true;
                ibtnAnterior.Enabled = true;
            }
        }

        protected void ibtnSiguiente_Click(object sender, ImageClickEventArgs e)
        {
            diaQuniela.Value = Convert.ToDateTime(diaQuniela.Value).AddDays(1).ToString("dd/MM/yyyy");
            CargarPartidos(diaQuniela.Value);

           
        }

        protected void ibtnAnterior_Click(object sender, ImageClickEventArgs e)
        {
            diaQuniela.Value = Convert.ToDateTime(diaQuniela.Value).AddDays(-1).ToString("dd/MM/yyyy");
            CargarPartidos(diaQuniela.Value);

        }

        protected void ibtnGuardar_Click(object sender, ImageClickEventArgs e)
        {
            CNegocio.csQuiniela.InsertaQuniela(rlvPartidos, participanteID);
        }

        protected void ibtnHistorico_Click(object sender, ImageClickEventArgs e)
        {
            divHistorico.Style.Add("Display", "");
            divQuiniela.Style.Add("Display", "none");


            gridHistorico.DataSource = CNegocio.csQuiniela.ObtenerPartidosQuniela("", participanteID);
            gridHistorico.DataBind();
        }

        protected void gridHistorico_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if ((IsPostBack) && (divHistorico.Style["Display"].ToString() == ""))
            {
                gridHistorico.DataSource = CNegocio.csQuiniela.ObtenerPartidosQuniela("", participanteID);
            }
        }

        protected void ibtnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            divHistorico.Style.Add("Display", "none");
            divQuiniela.Style.Add("Display", "");
        }

    }
}