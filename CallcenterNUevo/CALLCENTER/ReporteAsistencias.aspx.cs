using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using System.Web.Security;

namespace WebPfizer.LMS.eCard
{
    public partial class ReporteAsistencias : System.Web.UI.Page
    {
        DataSet objDataset;
        Clientes cliente = new Clientes();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UsuarioCC"] == null)
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!Page.IsPostBack)
            {
                if (ddlAnioF.Items.Count > 0 && ddlAnioI.Items.Count > 0)
                {
                    ddlAnioF.Items.Clear();
                    ddlAnioI.Items.Clear();
                }
                int x = 0;
                for (int i = 2010; i <= DateTime.Now.Year; i++)
                {
                    ddlAnioI.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    ddlAnioF.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
            Master.MenuMain = "Reportes";
            Master.Submenu = "Reporte de Visitas";
        }

        protected void btnSaldoMovBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(ddlAnioI.SelectedValue) > Convert.ToInt32(ddlAnioF.SelectedValue))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('El año de la fecha Inicial no puede ser mayo al año de la fecha final');", true);
                    return;
                }
                
                DateTime FechaI = new DateTime(Convert.ToInt32(ddlAnioI.SelectedValue), Convert.ToInt32(ddlMesI.SelectedValue),01);
                DateTime FechaF = new DateTime(Convert.ToInt32(ddlAnioF.SelectedValue), Convert.ToInt32(ddlMesF.SelectedValue),30);
                objDataset = cliente.ListadoVisitaPortal(txtTarjeta.Text,FechaI, FechaF );

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    gvwResultado.DataSource = objDataset;
                    gvwResultado.DataBind();
                }
                else
                {
                    gvwResultado.DataSource = null;
                    gvwResultado.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }

        protected void gvwResultado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwResultado.PageIndex = e.NewPageIndex;
             DateTime FechaI = new DateTime(Convert.ToInt32(ddlAnioI.SelectedValue), Convert.ToInt32(ddlMesI.SelectedValue),01);
                DateTime FechaF = new DateTime(Convert.ToInt32(ddlAnioF.SelectedValue), Convert.ToInt32(ddlMesF.SelectedValue),30);
            objDataset = cliente.ListadoVisitaPortal(txtTarjeta.Text, FechaI,FechaF);

            if (objDataset.Tables[0].Rows.Count > 0)
            {
                gvwResultado.DataSource = objDataset;
                gvwResultado.DataBind();
            }            
        }
    }
}