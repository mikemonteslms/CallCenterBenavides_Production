using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MnuMain.CALLCENTER
{
    public partial class ReporteActivacionXPeriodo : System.Web.UI.Page
    {
        #region DECLARATIONS

        Reportes reportes = new Reportes();

        private bool ReporteCargado
        {
            get { return ViewState["ReporteCargado"] == null ? false : Convert.ToBoolean(ViewState["ReporteCargado"]); }
            set { ViewState["ReporteCargado"] = value; }
        }

        #endregion DECLARATIONS

        #region EVENTS

        #region btnCancelar_Click

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        #endregion btnCancelar_Click

        #region btnExportaReporte_Click

        protected void btnExportaReporte_Click(object sender, EventArgs e)
        {
            if (ReporteCargado)
                ExportarReporteExcel();
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('No hay reporte generado');", true);
        }

        #endregion btnExportaReporte_Click

        #region btnGeneraReporte_Click

        protected void btnGeneraReporte_Click(object sender, EventArgs e)
        {
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            try
            {
                CargarReporteSeleccionado();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Error al consultar reporte de Activaciones por periodo.');", true);
            }

            //stopWatch.Stop();
            //TimeSpan ts = stopWatch.Elapsed;
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);
            //lblTime.Text = "Tiempo del reporte " + elapsedTime;
        }

        #endregion btnGeneraReporte_Click

        #region GridViewRegistros_PageIndexChanging

        protected void GridViewRegistros_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewRegistros.PageIndex = e.NewPageIndex;
            CargarReporteSeleccionado();
        }

        #endregion GridViewRegistros_PageIndexChanging

        #region GridViewRegistros_Sorting

        protected void GridViewRegistros_Sorting(object sender, GridViewSortEventArgs e)
        {
            CargarReporteSeleccionado();
            DataTable data = GridViewRegistros.DataSource as DataTable;

            if (data != null)
            {
                DataView dataView = new DataView(data);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                GridViewRegistros.DataSource = dataView;
                GridViewRegistros.DataBind();
            }
        }

        #endregion GridViewRegistros_Sorting

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnExportaReporte);

            if (!IsPostBack)
            {
                ddlMes.Items.Insert(0, new ListItem("Diciembre", "12"));
                ddlMes.Items.Insert(0, new ListItem("Noviembre", "11"));
                ddlMes.Items.Insert(0, new ListItem("Octubre", "10"));
                ddlMes.Items.Insert(0, new ListItem("Septiembre", "09"));
                ddlMes.Items.Insert(0, new ListItem("Agosto", "08"));
                ddlMes.Items.Insert(0, new ListItem("Julio", "07"));
                ddlMes.Items.Insert(0, new ListItem("Junio", "06"));
                ddlMes.Items.Insert(0, new ListItem("Mayo", "05"));
                ddlMes.Items.Insert(0, new ListItem("Abril", "04"));
                ddlMes.Items.Insert(0, new ListItem("Marzo", "03"));
                ddlMes.Items.Insert(0, new ListItem("Febrero", "02"));
                ddlMes.Items.Insert(0, new ListItem("Enero", "01"));

                ddlAnio.Items.Insert(0, new ListItem("2014", "2014"));
                ddlAnio.Items.Insert(0, new ListItem("2015", "2015"));
                ddlAnio.Items.Insert(0, new ListItem("2016", "2016"));

                DateTime dtNow = DateTime.Now;

                int iAnio = dtNow.Year;
                int iMes = dtNow.Month;

                ddlMes.SelectedValue = iMes.ToString("00");
                ddlAnio.SelectedValue = iAnio.ToString();
            }
        }

        #endregion Page_Load

        #endregion EVENTS

        #region METHODS

        #region CargarReporteSeleccionado

        private void CargarReporteSeleccionado()
        {
            DataSet dataSetRegistros = null;

            try
            {
                lblRegistrosEncontrados.Text = "";

                dataSetRegistros = reportes.ReporteActivacionXPeriodo("01/" + ddlMes.SelectedValue.ToString() + "/" + ddlAnio.SelectedValue.ToString());
                GridViewRegistros.DataSource = dataSetRegistros.Tables[0];
                GridViewRegistros.DataBind();

                lblRegistrosEncontrados.Text = string.Format("Sucurales encontradas: {0:N0}", dataSetRegistros.Tables[0].Rows.Count);

                DataTable dtCifrasControl = dataSetRegistros.Tables[1];
                lblActivas.Text = string.Format("Activas: {0:N0}", dataSetRegistros.Tables[1].Rows[0]["SucuralesActivas"]);
                lblInactivas.Text = string.Format("Inactivas: {0:N0}", dataSetRegistros.Tables[1].Rows[0]["SucuralesInactivas"]);
                lblTotalActivaciones.Text = string.Format("Total de activaciones: {0:N0}", dataSetRegistros.Tables[1].Rows[0]["TotalActivacion"]);
                lblAzulActivaciones.Text = string.Format("BI Azul: {0:N0}", dataSetRegistros.Tables[1].Rows[0]["AzulActivacion"]);
                lblPlatinoActivaciones.Text = string.Format("BI Platino : {0:N0}", dataSetRegistros.Tables[1].Rows[0]["PlatinoActivacion"]);

                ReporteCargado = true;
                dataSetRegistros.Dispose();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Error al consultar reporte.');", true);
            }
        }

        #endregion CargarReporteSeleccionado

        #region ConvertSortDirectionToSql

        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }

        #endregion ConvertSortDirectionToSql

        #region ExportarCVS

        private string ExportarCVS(DataSet dataset)
        {
            StringBuilder secuencia = new StringBuilder();

            secuencia.Append("<table border='1px'>");
            secuencia.Append("<tr>");
            for (int i = 0; i < dataset.Tables[0].Columns.Count; i++)
            {
                secuencia.Append("<td>" + dataset.Tables[0].Columns[i].ColumnName + "</td>");
            }
            secuencia.Append("</tr>");
            foreach (DataRow dr in dataset.Tables[0].Rows)
            {
                secuencia.Append("<tr>");
                for (int j = 0; j < dataset.Tables[0].Columns.Count; j++)
                {

                    secuencia.Append("<td>" + dr[j].ToString() + "</td>");
                }
                secuencia.Append("</tr>");
            }
            secuencia.Append("</table>");

            return secuencia.ToString();
        }

        #endregion ExportarCVS

        #region ExportarReporteExcel

        private void ExportarReporteExcel()
        {
            String secuencia = "";
            DataSet dataSetRegistros = null;

            try
            {
                dataSetRegistros = reportes.ReporteActivacionXPeriodo("01/" + ddlMes.SelectedValue.ToString() + "/" + ddlAnio.SelectedValue.ToString());
                secuencia = ExportarCVS(dataSetRegistros);
                IniciarDescarga(secuencia);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Error al exportar reporte.');", true);
            }
        }

        #endregion ExportarReporteExcel

        #region IniciarDescarga

        private void IniciarDescarga(string secuencia)
        {
            string nombreDocumento = string.Format("{0}_{1}_{2}.{3}", "ActivacionesPorPeriodo", ddlMes.SelectedItem.Text + ddlAnio.SelectedItem.Text, DateTime.Now.ToString("ddMMyyyyhhmmss"), "xls");

            Response.Buffer = true;

            Response.ContentType = "application/vnd.ms-excel"; Response.Charset = "";
            this.EnableViewState = false;
            Response.AddHeader("Content-Disposition", "attachment;filename=" + nombreDocumento);
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(secuencia.ToString());
            Response.End();
        }

        #endregion IniciarDescarga

        #endregion METHODS
    }
}