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
            string sPeriodo = string.Empty;

            try
            {
                dataSetRegistros = reportes.ReporteActivacionXPeriodoTl("01/" + hdfMes.Value + "/" + hdfAnio.Value);
                rGrdActivaciones.DataSource = dataSetRegistros.Tables[0];
                sPeriodo = GeneraCadenaPeriodo(hdfMes.Value, hdfAnio.Value);
                rGrdActivaciones.MasterTableView.ColumnGroups.FindGroupByName("Total").HeaderText = sPeriodo + " - TOTAL";
                rGrdActivaciones.MasterTableView.ColumnGroups.FindGroupByName("Azul").HeaderText = sPeriodo + " - BI AZUL";
                rGrdActivaciones.MasterTableView.ColumnGroups.FindGroupByName("Platino").HeaderText = sPeriodo + " - BI PLATINO";
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
            string sPeriodo = string.Empty;

            try
            {
                lblRegistrosEncontrados.Text = "";

                dataSetRegistros = reportes.ReporteActivacionXPeriodoTl("01/" + hdfMes.Value + "/" + hdfAnio.Value);
                rGrdActivaciones.DataSource = dataSetRegistros.Tables[0];
                sPeriodo = GeneraCadenaPeriodo(hdfMes.Value, hdfAnio.Value);
                rGrdActivaciones.MasterTableView.ColumnGroups.FindGroupByName("Total").HeaderText = sPeriodo + " - TOTAL";
                rGrdActivaciones.MasterTableView.ColumnGroups.FindGroupByName("Azul").HeaderText = sPeriodo + " - BI AZUL";
                rGrdActivaciones.MasterTableView.ColumnGroups.FindGroupByName("Platino").HeaderText = sPeriodo + " - BI PLATINO";
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

            string sMes = string.Empty;

            switch (hdfMes.Value)
            {
                case "01":
                    sMes = "Enero ";
                    break;
                case "02":
                    sMes = "Febrero ";
                    break;
                case "03":
                    sMes = "Marzo ";
                    break;
                case "04":
                    sMes = "Abril ";
                    break;
                case "05":
                    sMes = "Mayo ";
                    break;
                case "06":
                    sMes = "Junio ";
                    break;
                case "07":
                    sMes = "Julio ";
                    break;
                case "08":
                    sMes = "Agosto ";
                    break;
                case "09":
                    sMes = "Septiembre ";
                    break;
                case "10":
                    sMes = "Octubre ";
                    break;
                case "11":
                    sMes = "Noviembre ";
                    break;
                case "12":
                    sMes = "Diciembre ";
                    break;
                default:
                    sMes = string.Empty;
                    break;
            }

            secuencia.Replace("Día 10", "Total " + sMes + "10 " + hdfAnio.Value);
            secuencia.Replace("Día 11", "Total " + sMes + "11 " + hdfAnio.Value);
            secuencia.Replace("Día 12", "Total " + sMes + "12 " + hdfAnio.Value);
            secuencia.Replace("Día 13", "Total " + sMes + "13 " + hdfAnio.Value);
            secuencia.Replace("Día 14", "Total " + sMes + "14 " + hdfAnio.Value);
            secuencia.Replace("Día 15", "Total " + sMes + "15 " + hdfAnio.Value);
            secuencia.Replace("Día 16", "Total " + sMes + "16 " + hdfAnio.Value);
            secuencia.Replace("Día 17", "Total " + sMes + "17 " + hdfAnio.Value);
            secuencia.Replace("Día 18", "Total " + sMes + "18 " + hdfAnio.Value);
            secuencia.Replace("Día 19", "Total " + sMes + "19 " + hdfAnio.Value);
            secuencia.Replace("Día 20", "Total " + sMes + "20 " + hdfAnio.Value);
            secuencia.Replace("Día 21", "Total " + sMes + "21 " + hdfAnio.Value);
            secuencia.Replace("Día 22", "Total " + sMes + "22 " + hdfAnio.Value);
            secuencia.Replace("Día 23", "Total " + sMes + "23 " + hdfAnio.Value);
            secuencia.Replace("Día 24", "Total " + sMes + "24 " + hdfAnio.Value);
            secuencia.Replace("Día 25", "Total " + sMes + "25 " + hdfAnio.Value);
            secuencia.Replace("Día 26", "Total " + sMes + "26 " + hdfAnio.Value);
            secuencia.Replace("Día 27", "Total " + sMes + "27 " + hdfAnio.Value);
            secuencia.Replace("Día 28", "Total " + sMes + "28 " + hdfAnio.Value);
            secuencia.Replace("Día 29", "Total " + sMes + "29 " + hdfAnio.Value);
            secuencia.Replace("Día 30", "Total " + sMes + "30 " + hdfAnio.Value);
            secuencia.Replace("Día 31", "Total " + sMes + "31 " + hdfAnio.Value);
            secuencia.Replace("Día 1", "Total " + sMes + "1 " + hdfAnio.Value);
            secuencia.Replace("Día 2", "Total " + sMes + "2 " + hdfAnio.Value);
            secuencia.Replace("Día 3", "Total " + sMes + "3 " + hdfAnio.Value);
            secuencia.Replace("Día 4", "Total " + sMes + "4 " + hdfAnio.Value);
            secuencia.Replace("Día 5", "Total " + sMes + "5 " + hdfAnio.Value);
            secuencia.Replace("Día 6", "Total " + sMes + "6 " + hdfAnio.Value);
            secuencia.Replace("Día 7", "Total " + sMes + "7 " + hdfAnio.Value);
            secuencia.Replace("Día 8", "Total " + sMes + "8 " + hdfAnio.Value);
            secuencia.Replace("Día 9", "Total " + sMes + "9 " + hdfAnio.Value);
            secuencia.Replace("día 10", sMes + "10 " + hdfAnio.Value);
            secuencia.Replace("día 11", sMes + "11 " + hdfAnio.Value);
            secuencia.Replace("día 12", sMes + "12 " + hdfAnio.Value);
            secuencia.Replace("día 13", sMes + "13 " + hdfAnio.Value);
            secuencia.Replace("día 14", sMes + "14 " + hdfAnio.Value);
            secuencia.Replace("día 15", sMes + "15 " + hdfAnio.Value);
            secuencia.Replace("día 16", sMes + "16 " + hdfAnio.Value);
            secuencia.Replace("día 17", sMes + "17 " + hdfAnio.Value);
            secuencia.Replace("día 18", sMes + "18 " + hdfAnio.Value);
            secuencia.Replace("día 19", sMes + "19 " + hdfAnio.Value);
            secuencia.Replace("día 20", sMes + "20 " + hdfAnio.Value);
            secuencia.Replace("día 21", sMes + "21 " + hdfAnio.Value);
            secuencia.Replace("día 22", sMes + "22 " + hdfAnio.Value);
            secuencia.Replace("día 23", sMes + "23 " + hdfAnio.Value);
            secuencia.Replace("día 24", sMes + "24 " + hdfAnio.Value);
            secuencia.Replace("día 25", sMes + "25 " + hdfAnio.Value);
            secuencia.Replace("día 26", sMes + "26 " + hdfAnio.Value);
            secuencia.Replace("día 27", sMes + "27 " + hdfAnio.Value);
            secuencia.Replace("día 28", sMes + "28 " + hdfAnio.Value);
            secuencia.Replace("día 29", sMes + "29 " + hdfAnio.Value);
            secuencia.Replace("día 30", sMes + "30 " + hdfAnio.Value);
            secuencia.Replace("día 31", sMes + "31 " + hdfAnio.Value);
            secuencia.Replace("día 1", sMes + "1 " + hdfAnio.Value);
            secuencia.Replace("día 2", sMes + "2 " + hdfAnio.Value);
            secuencia.Replace("día 3", sMes + "3 " + hdfAnio.Value);
            secuencia.Replace("día 4", sMes + "4 " + hdfAnio.Value);
            secuencia.Replace("día 5", sMes + "5 " + hdfAnio.Value);
            secuencia.Replace("día 6", sMes + "6 " + hdfAnio.Value);
            secuencia.Replace("día 7", sMes + "7 " + hdfAnio.Value);
            secuencia.Replace("día 8", sMes + "8 " + hdfAnio.Value);
            secuencia.Replace("día 9", sMes + "9 " + hdfAnio.Value);

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

        #region GeneraCadenaPeriodo

        private string GeneraCadenaPeriodo(string pMes, string pAnio)
        {
            string sPeriodo = string.Empty;
            try
            {
                switch (pMes)
                {
                    case "01":
                        sPeriodo = "ENERO ";
                        break;
                    case "02":
                        sPeriodo = "FEBRERO ";
                        break;
                    case "03":
                        sPeriodo = "MARZO ";
                        break;
                    case "04":
                        sPeriodo = "ABRIL ";
                        break;
                    case "05":
                        sPeriodo = "MAYO ";
                        break;
                    case "06":
                        sPeriodo = "JUNIO ";
                        break;
                    case "07":
                        sPeriodo = "JULIO ";
                        break;
                    case "08":
                        sPeriodo = "AGOSTO ";
                        break;
                    case "09":
                        sPeriodo = "SEPTIEMBRE ";
                        break;
                    case "10":
                        sPeriodo = "OCTUBRE ";
                        break;
                    case "11":
                        sPeriodo = "NOVIEMBRE ";
                        break;
                    case "12":
                        sPeriodo = "DICIEMBRE ";
                        break;
                    default:
                        sPeriodo = string.Empty;
                        break;
                }

                return sPeriodo + pAnio;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion GeneraCadenaPeriodo

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