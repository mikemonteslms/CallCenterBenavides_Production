using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Telerik.Web.UI;
using System.Globalization;

namespace ORMOperacion
{
    public partial class contenido : System.Web.UI.MasterPage
    {
        private string menu;

        public string Menu
        {
            get { return menu; }
            set { menu = value; }
        }
        private string submenu;

        public string Submenu
        {
            get { return submenu; }
            set { submenu = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Membership.GetUser() != null)
                {
                    hidUserId.Value = Membership.GetUser().ProviderUserKey.ToString();
                    csParticipanteComplemento p = new csParticipanteComplemento();
                    DataTable dtParticipante = p.consultaDatosPrograma(ConfigurationManager.AppSettings["programa"]);
                    if (dtParticipante.Rows.Count > 0)
                    {
                        DataRow drP = dtParticipante.Rows[0];
                        string value = drP["descripcion"].ToString().ToLower();
                        programa_clave.InnerText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
                    }
                }
                if (Request.QueryString["buscar"] != null)
                {
                    //txtBuscar.Text = Request.QueryString["buscar"].ToString();
                }
            }
            menuLbl.Text = menu;
            subMenuLbl.Text = submenu;
            string strAgent = Request.UserAgent;
            HttpBrowserCapabilities myBrowserCapabilities = Request.Browser;
            Int32 majorVersion = myBrowserCapabilities.MajorVersion;
            if (strAgent.Contains("like Gecko") && strAgent.Contains("Trident") && majorVersion == 0)
            {
                Page.ClientTarget = "uplevel";
            }
            //throw new ApplicationException("I am an exception!");
        }

        protected void RadMenu1_ItemDataBound(object sender, RadMenuEventArgs e)
        {
            DataRowView dataRow = e.Item.DataItem as DataRowView;
            if (dataRow != null)
            {
                e.Item.ToolTip = dataRow["alt"].ToString(); // TooTip                
                e.Item.NavigateUrl = dataRow["url"].ToString(); // Agrega la url
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //BuscaParticipante();
            //Response.Redirect("~/busqueda.aspx?buscar=" + txtBuscar.Text.Trim(), false);
        }



        protected void cargaCountry()
        {
            csCountry country = new csCountry();
            //ddlCountry.DataSource = country.CargaCountry().DefaultView;
            //ddlCountry.DataValueField = "id";
            //ddlCountry.DataTextField = "descripcion";
            //ddlCountry.DataBind();
            //ddlCountry.Items.Insert(0, "-Todos-");
            //ddlDistribuidora.Items.Insert(0, "-Todos-");

        }

        protected void cargaDistribuidora()
        {
            //if (ddlCountry.SelectedValue != "-Todos-")
            //{
            //    csDistributor distributor = new csDistributor();
            //    ddlDistribuidora.DataSource = distributor.CargaDistributor(Convert.ToInt16(ddlCountry.SelectedValue)).DefaultView;
            //    ddlDistribuidora.DataValueField = "id";
            //    ddlDistribuidora.DataTextField = "descripcion";
            //    ddlDistribuidora.DataBind();
            //    ddlDistribuidora.Items.Insert(0, "-Todos-");
            //}
            //else
            //{
            //    ddlDistribuidora.Items.Clear();
            //    ddlDistribuidora.Items.Insert(0, "-Todos-");
            //}
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaDistribuidora();
        }

        public void MuestraMensaje(string mensaje)
        {
            lblMensajePopup.Text = mensaje;
            popMensaje.Show();
        }
        public void AgregaEvento(string evento)
        {
            imgCerrarMensaje.OnClientClick = evento;
        }

        /** Para deshabilitar la validación de busqueda por el botonenviar de canje **/
        public void CriterioBuqueda(Boolean requerido)
        {
            //rfvCriterioBuqueda.Enabled = requerido;
        }

        protected void btnRegistraParticipante_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/registrar/RegistrarParticipante.aspx", false);
        }

    }
}