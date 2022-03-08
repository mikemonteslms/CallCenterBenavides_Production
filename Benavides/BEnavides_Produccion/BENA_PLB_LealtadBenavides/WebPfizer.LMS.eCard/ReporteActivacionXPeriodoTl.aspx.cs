using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Datos;
using Telerik.Web.UI;

namespace WebPfizer.LMS.eCard
{
    public partial class ReporteActivacionXPeriodoTl : System.Web.UI.Page
    {
        #region DECLARATIONS

        Reportes reportes = new Reportes();

        #endregion DECLARATIONS

        #region EVENTS

        #region btnCancelar_Click

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        #endregion btnCancelar_Click

        #region btnCerrarSesion_Click

        protected void btnCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            Session["UsuarioCC"] = null;
            Response.Redirect("AccesoCallCenter.aspx");
        }

        #endregion btnCerrarSesion_Click

        #region btnExportaReporte_Click

        protected void btnExportaReporte_Click(object sender, EventArgs e)
        {
            if (hdfMes.Value != string.Empty && hdfAnio.Value != string.Empty)
                ExportarReporteExcel();
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('No hay reporte generado');", true);
        }

        #endregion btnExportaReporte_Click

        #region btnGeneraReporte_Click

        protected void btnGeneraReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dPeriodo = new DateTime(Convert.ToInt32(ddlAnio.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue), 1);

                if (dPeriodo > DateTime.Now)
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Periodo no valido, fecha posterior al día actual.');", true);
                else
                {
                    hdfMes.Value = ddlMes.SelectedValue.ToString();
                    hdfAnio.Value = ddlAnio.SelectedValue.ToString();
                    CargarReporteSeleccionado();
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Error al consultar reporte de Activaciones por periodo.');", true);
            }
        }

        #endregion btnGeneraReporte_Click

        #region ddlAnio_SelectedIndexChanged

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarGrid();
        }

        #endregion ddlAnio_SelectedIndexChanged

        #region ddlMes_SelectedIndexChanged

        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarGrid();
        }

        #endregion ddlMes_SelectedIndexChanged

        #region rGrdActivaciones_PageIndexChanged

        protected void rGrdActivaciones_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            CargarReporte();
        }
        
        #endregion rGrdActivaciones_PageIndexChanged

        #region rGrdActivaciones_PageSizeChanged

        protected void rGrdActivaciones_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            CargarReporte();
        }

        #endregion rGrdActivaciones_PageSizeChanged

        #region rGrdActivaciones_SortCommand

        protected void rGrdActivaciones_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            CargarReporte();
        }

        #endregion rGrdActivaciones_SortCommand

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

                //ddlAnio.Items.Insert(0, new ListItem("2014", "2014"));
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

        #region CargarReporte

        private void CargarReporte()
        {
            DataSet dataSetRegistros = null;

            try
            {
                dataSetRegistros = reportes.ReporteActivacionXPeriodoTl("01/" + hdfMes.Value + "/" + hdfAnio.Value);
                rGrdActivaciones.DataSource = dataSetRegistros.Tables[0];
                rGrdActivaciones.DataBind();
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Error al consultar reporte.');", true);
            }
        }

        #endregion CargarReporte

        #region CargarReporteSeleccionado

        private void CargarReporteSeleccionado()
        {
            DataSet dataSetRegistros = null;

            try
            {
                lblRegistrosEncontrados.Text = "";

                dataSetRegistros = reportes.ReporteActivacionXPeriodoTl("01/" + hdfMes.Value + "/" + hdfAnio.Value);
                rGrdActivaciones.DataSource = dataSetRegistros.Tables[0];
                rGrdActivaciones.DataBind();

                lblRegistrosEncontrados.Text = string.Format("Sucurales encontradas: {0:N0}", dataSetRegistros.Tables[0].Rows.Count);

                DataTable dtCifrasControl = dataSetRegistros.Tables[1];
                lblActivas.Text = string.Format("Activas: {0:N0}", dataSetRegistros.Tables[1].Rows[0]["SucuralesActivas"]);
                lblInactivas.Text = string.Format("Inactivas: {0:N0}", dataSetRegistros.Tables[1].Rows[0]["SucuralesInactivas"]);
                lblTotalActivaciones.Text = string.Format("Total de activaciones: {0:N0}", dataSetRegistros.Tables[1].Rows[0]["TotalActivacion"]);
                lblAzulActivaciones.Text = string.Format("BI Azul: {0:N0}", dataSetRegistros.Tables[1].Rows[0]["AzulActivacion"]);
                lblPlatinoActivaciones.Text = string.Format("BI Platino : {0:N0}", dataSetRegistros.Tables[1].Rows[0]["PlatinoActivacion"]);

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

            secuencia.Replace("Día 1", "Total día 1");
            secuencia.Replace("Día 2", "Total día 2");
            secuencia.Replace("Día 3", "Total día 3");
            secuencia.Replace("Día 4", "Total día 4");
            secuencia.Replace("Día 5", "Total día 5");
            secuencia.Replace("Día 6", "Total día 6");
            secuencia.Replace("Día 7", "Total día 7");
            secuencia.Replace("Día 8", "Total día 8");
            secuencia.Replace("Día 9", "Total día 9");
            secuencia.Replace("Día 10", "Total día 10");
            secuencia.Replace("Día 11", "Total día 11");
            secuencia.Replace("Día 12", "Total día 12");
            secuencia.Replace("Día 13", "Total día 13");
            secuencia.Replace("Día 14", "Total día 14");
            secuencia.Replace("Día 15", "Total día 15");
            secuencia.Replace("Día 16", "Total día 16");
            secuencia.Replace("Día 17", "Total día 17");
            secuencia.Replace("Día 18", "Total día 18");
            secuencia.Replace("Día 19", "Total día 19");
            secuencia.Replace("Día 20", "Total día 20");
            secuencia.Replace("Día 21", "Total día 21");
            secuencia.Replace("Día 22", "Total día 22");
            secuencia.Replace("Día 23", "Total día 23");
            secuencia.Replace("Día 24", "Total día 24");
            secuencia.Replace("Día 25", "Total día 25");
            secuencia.Replace("Día 26", "Total día 26");
            secuencia.Replace("Día 27", "Total día 27");
            secuencia.Replace("Día 28", "Total día 28");
            secuencia.Replace("Día 29", "Total día 29");
            secuencia.Replace("Día 30", "Total día 30");
            secuencia.Replace("Día 31", "Total día 31");

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
                dataSetRegistros = reportes.ReporteActivacionXPeriodoTl("01/" + hdfMes.Value + "/" + hdfAnio.Value);
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
            try
            {
                string nombreDocumento = string.Format("{0}_{1}_{2}.{3}", "ActivacionesPorPeriodo", hdfMes.Value + hdfAnio.Value, DateTime.Now.ToString("ddMMyyyyhhmmss"), "xls");

                Response.Buffer = true;

                Response.ContentType = "application/vnd.ms-excel"; Response.Charset = "";
                this.EnableViewState = false;
                Response.AddHeader("Content-Disposition", "attachment;filename=" + nombreDocumento);
                Response.Charset = "UTF-8";
                Response.ContentEncoding = Encoding.Default;
                Response.Write(secuencia.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Error: " + ex.Message + ");", true);
            }
        }

        #endregion IniciarDescarga

        #region LimpiarGrid

        private void LimpiarGrid()
        {
            rGrdActivaciones.DataSource = new string[] { };
            rGrdActivaciones.DataBind();
            hdfMes.Value = string.Empty;
            hdfAnio.Value = string.Empty;
        }

        #endregion LimpiarGrid

        #endregion METHODS
    }
}