using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Telerik.Web.UI;
using System.Data;

namespace CallcenterNUevo.CALLCENTER
{
    public partial class rptDesBloqueos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlConsulta.Visible = false;
            pnlNuevoBloqueo.Visible = true;
            if (!Page.IsPostBack)
            {
                
                RadDatePicker1.SelectedDate = DateTime.Now;
                RadDatePicker2.SelectedDate = DateTime.Now;
            }
            Master.MenuMain = "Operaciones";
            Master.Submenu = "Desbloqueos";
        }

        protected void btnGeneraReporte_Click(object sender, EventArgs e)
        {
            rgResultado.DataSource = Tarjetas.ConsultaBloqueos(RadDatePicker1.SelectedDate, RadDatePicker2.SelectedDate, TextBox1.Text);
            rgResultado.DataBind();
        }

        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            pnlConsulta.Visible = true;
            pnlDatos.Visible = false;
            pnlNuevoBloqueo.Visible = false;
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            rgResultado.ExportSettings.Excel.Format = GridExcelExportFormat.Xlsx;
            rgResultado.ExportSettings.IgnorePaging = true;//--CheckBox1.Checked;
            rgResultado.ExportSettings.ExportOnlyData = true;
            rgResultado.ExportSettings.FileName = "rptDesbloqueos_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
            rgResultado.MasterTableView.ExportToExcel();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTarjeta.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Es necesario proporcione una trajeta.');", true);
                return;
            }

            DataTable tblDatos = Tarjetas.ConsultaBloqueos(txtTarjeta.Text);
            if (tblDatos.Rows.Count > 0)
            {
                txtFecha.Text = Convert.ToDateTime(tblDatos.Rows[0]["FechaActivacion"]).ToShortDateString();
                txtBoomerangs.Text = tblDatos.Rows[0]["Boomerangs"].ToString();
                txtEstatus.Text = tblDatos.Rows[0]["Estatus"].ToString();
                txtNivel.Text = tblDatos.Rows[0]["Nivel"].ToString();
                txtNombre.Text = tblDatos.Rows[0]["Nombre"].ToString();
                txtSaldo.Text = tblDatos.Rows[0]["Saldo"].ToString();
                txtEstatusB.Text = tblDatos.Rows[0]["EstatusB"].ToString();
                HiddenField1.Value = tblDatos.Rows[0]["IDEstatus"].ToString();
                txtFechaBloque.Text = tblDatos.Rows[0]["FechaBloque"].ToString();
                txtMotivo.Text = tblDatos.Rows[0]["Tarjeta_strObservaciones"].ToString();
            }
            pnlDatos.Visible = true;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlNuevoBloqueo.Visible = true;
            pnlConsulta.Visible = false;
        }

        protected void btnConfirma_Click(object sender, EventArgs e)
        {
            if (RadDropDownList1.SelectedValue == HiddenField1.Value)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No se puede realizar la operación, ya que la tarjeta se encuentra desbloqueada.');", true);
                return;
            }
            else
            {
                string Result = Tarjetas.RealizarBloqueos(txtTarjeta.Text, RadDropDownList1.SelectedValue, txtMotivo.Text, HttpContext.Current.User.Identity.Name);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Result + "');", true);
                Response.AddHeader("REFRESH", "2;URL=rptDesBloqueos.aspx");
            }
        }
    }
}