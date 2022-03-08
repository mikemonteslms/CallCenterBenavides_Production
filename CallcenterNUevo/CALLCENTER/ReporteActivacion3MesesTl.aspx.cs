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
using Telerik.Web.UI;
using Negocio;
using Datos;
using Entidades;

namespace WebPfizer.LMS.eCard
{
    public partial class ReporteActivacion3MesesTl : System.Web.UI.Page
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
            if (hdfMes.Value != string.Empty && hdfAnio.Value != string.Empty
                && (hdfRegion.Value != string.Empty || hdfZona.Value != string.Empty || hdfSucursal.Value != string.Empty))
            {
                DataTable dataSetRegistos = (reportes.ReporteActivacion3MesesTl("01/" + hdfMes.Value + "/" + hdfAnio.Value, hdfRegion.Value, hdfZona.Value, hdfSucursal.Value)).Tables[0];
                IniciarDescarga(ExportarCVS(dataSetRegistos));
            }
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
                    if (rCbxRegion.SelectedValue.ToString() == string.Empty && rCbxZona.SelectedValue.ToString() == string.Empty
                        && rcbScucursales.SelectedValue.ToString() == string.Empty)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Favor de seleccionar un criterio de búsqueda.');", true);
                    }
                    else
                    {
                        if (rCbxRegion.SelectedValue.ToString() != string.Empty)
                        {
                            lblTitulo.Text = "Región: " + rCbxRegion.SelectedItem.Text;
                            hdfTitulo.Value = rCbxRegion.SelectedItem.Text.Replace(",", "").Replace(".", "");
                        }
                        else
                        {
                            if (rCbxZona.SelectedValue.ToString() != string.Empty)
                            {
                                lblTitulo.Text = "Zona: " + rCbxZona.SelectedItem.Text;
                                hdfTitulo.Value = rCbxZona.SelectedItem.Text.Replace(",", "").Replace(".", "");
                            }
                            else
                            {
                                if (rcbScucursales.SelectedValue.ToString() != string.Empty)
                                {
                                    lblTitulo.Text = "Sucursal: " + rcbScucursales.SelectedItem.Text;
                                    hdfTitulo.Value = rcbScucursales.SelectedItem.Text.Replace(",", "").Replace(".", "");
                                }
                            }
                        }

                        hdfRegion.Value = rCbxRegion.SelectedValue.ToString();
                        hdfZona.Value = rCbxZona.SelectedValue.ToString();
                        hdfSucursal.Value = rcbScucursales.SelectedValue.ToString();
                        hdfMes.Value = ddlMes.SelectedValue.ToString();
                        hdfAnio.Value = ddlAnio.SelectedValue.ToString();
                        CargarReporteSeleccionado(hdfMes.Value, hdfAnio.Value, hdfRegion.Value, hdfZona.Value, hdfSucursal.Value);
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Error al consultar reporte de Activaciones por periodo.');", true);
            }
        }

        #endregion btnGeneraReporte_Click

        #region Button_Click

        protected void Button_Click(object sender, EventArgs e)
        {
            RadButton clickedButton = (RadButton)sender;
            switch (clickedButton.ID)
            {
                case "rRbtRegion":
                    rCbxRegion.Enabled = true;
                    rCbxZona.ClearSelection();
                    rCbxZona.DataBind();
                    rCbxZona.Enabled = false;
                    rcbScucursales.ClearSelection();
                    rcbScucursales.DataBind();
                    rcbScucursales.Enabled = false;
                    break;
                case "rRbtZona":
                    rCbxRegion.ClearSelection();
                    rCbxRegion.DataBind();
                    rCbxRegion.Enabled = false;
                    rCbxZona.Enabled = true;
                    rcbScucursales.ClearSelection();
                    rcbScucursales.DataBind();
                    rcbScucursales.Enabled = false;
                    break;
                case "rRbtSucursal":
                    rCbxRegion.ClearSelection();
                    rCbxRegion.DataBind();
                    rCbxRegion.Enabled = false;
                    rCbxZona.ClearSelection();
                    rCbxZona.DataBind();
                    rCbxZona.Enabled = false;
                    rcbScucursales.Enabled = true;
                    break;
            }
        }

        #endregion Button_Click

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

                ddlAnio.Items.Insert(0, new ListItem("2015", "2015"));
                ddlAnio.Items.Insert(0, new ListItem("2016", "2016"));

                DateTime dtNow = DateTime.Now;

                int iAnio = dtNow.Year;
                int iMes = dtNow.Month;

                ddlMes.SelectedValue = iMes.ToString("00");
                ddlAnio.SelectedValue = iAnio.ToString();

                Negocio.Sucursales objSucursales = new Negocio.Sucursales();

                rCbxRegion.DataSource = objSucursales.ObtenerCatalogoDeRegiones();
                rCbxRegion.DataTextField = "Region_strRegion";
                rCbxRegion.DataValueField = "Region_strID";
                rCbxRegion.DataBind();
                rCbxRegion.Enabled = true;

                rCbxZona.DataSource = objSucursales.ObtenerCatalogoDeZonas();
                rCbxZona.DataTextField = "Zona_strZona";
                rCbxZona.DataValueField = "Zona_strID";
                rCbxZona.DataBind();

                rcbScucursales.DataSource = objSucursales.ObtenerCatalogoDeSucursalSap();
                rcbScucursales.DataTextField = "Sucursal_strNombreSap";
                rcbScucursales.DataValueField = "Sucursal_intCiaSuc";
                rcbScucursales.DataBind();

                objSucursales = null;

                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Dias";
                sortExpr.SortOrder = GridSortOrder.Ascending;

                rGrdActivaciones.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
            }
        }

        #endregion Page_Load

        #region rcbScucursales_SelectedIndexChanged

        protected void rcbScucursales_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LimpiarGrid();
        }

        #endregion rcbScucursales_SelectedIndexChanged

        #region rCbxRegion_SelectedIndexChanged

        protected void rCbxRegion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LimpiarGrid();
        }

        #endregion rCbxRegion_SelectedIndexChanged

        #region rCbxZona_SelectedIndexChanged

        protected void rCbxZona_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LimpiarGrid();
        }

        #endregion rCbxZona_SelectedIndexChanged

        #region rGrdActivaciones_SortCommand

        protected void rGrdActivaciones_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            CargarReporteSeleccionado(hdfMes.Value, hdfAnio.Value, hdfRegion.Value, hdfZona.Value, hdfSucursal.Value);
        }

        #endregion rGrdActivaciones_SortCommand

        #endregion EVENTS

        #region METHODS

        #region CargarReporteSeleccionado

        private void CargarReporteSeleccionado(string pMes, string pAnio, string pRegionId, string pZonaId, string pSucursalId)
        {
            try
            {
                string sMes = string.Empty;

                for (int i = 2; i >= 0; i--)
                {
                    int iMes = Convert.ToInt32(pMes);

                    if (iMes - i <= 0)
                        iMes = iMes - i + 12;
                    else
                        iMes = iMes - i;

                    switch (iMes)
                    {
                        case 1:
                            sMes = "Enero";
                            break;
                        case 2:
                            sMes = "Febrero";
                            break;
                        case 3:
                            sMes = "Marzo";
                            break;
                        case 4:
                            sMes = "Abril";
                            break;
                        case 5:
                            sMes = "Mayo";
                            break;
                        case 6:
                            sMes = "Junio";
                            break;
                        case 7:
                            sMes = "Julio";
                            break;
                        case 8:
                            sMes = "Agosto";
                            break;
                        case 9:
                            sMes = "Septiembre";
                            break;
                        case 10:
                            sMes = "Octubre";
                            break;
                        case 11:
                            sMes = "Noviembre";
                            break;
                        case 12:
                            sMes = "Diciembre";
                            break;
                        default:
                            sMes = string.Empty;
                            break;
                    }

                    rGrdActivaciones.Columns[3 - i].HeaderText = sMes;
                    rGrdActivaciones.Columns[6 - i].HeaderText = sMes;
                    rGrdActivaciones.Columns[9 - i].HeaderText = sMes;

                    switch (i)
                    {
                        case 0:
                            hdfLeyendaMes3.Value = sMes;
                            break;
                        case 1:
                            hdfLeyendaMes2.Value = sMes;
                            break;
                        case 2:
                            hdfLeyendaMes1.Value = sMes;
                            break;
                    }
                }

                //rGrdActivaciones.DataSource = reportes.ReporteActivacionXSucursal3MesesTl(pSucursalId, "01/" + pMes + "/" + pAnio);
                rGrdActivaciones.DataSource = reportes.ReporteActivacion3MesesTl("01/" + pMes + "/" + pAnio, pRegionId, pZonaId, pSucursalId);
                rGrdActivaciones.DataBind();

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Error al consultar reporte.');", true);
            }
        }

        #endregion CargarReporteSeleccionado

        #region ExportarCVS
        /// <summary>
        /// Genera una secuencia de caracteres con el formato CVS apartir de un listado de objetos genericos.
        /// </summary>
        /// <param name="dataTable">Conjunto obtenido de los reportes</param>
        /// <returns>Secuencia de caracteres</returns>
        private string ExportarCVS(DataTable dataTable)
        {
            StringBuilder secuencia = new StringBuilder();
            secuencia.Append("<table border='1px'>");
            // Cabecera
            secuencia.Append("<tr style=\"font-weight: bold;\">");
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                secuencia.Append("<td>" + dataTable.Columns[i].ColumnName + "</td>");
            }
            secuencia.Append("</tr>");
            // Filas
            foreach (DataRow dr in dataTable.Rows)
            {
                secuencia.Append("<tr>");
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    secuencia.Append("<td>" + dr[j].ToString() + "</td>");
                }
                secuencia.Append("</tr>");
            }
            secuencia.Append("</table>");
            secuencia.Replace("Dias", "DIAS");
            secuencia.Replace("AZUL_MES_1", "AZUL " + hdfLeyendaMes1.Value + " " + hdfAnio.Value);
            secuencia.Replace("AZUL_MES_2", "AZUL " + hdfLeyendaMes2.Value + " " + hdfAnio.Value);
            secuencia.Replace("AZUL_MES_ACTUAL", "AZUL " + hdfLeyendaMes3.Value + " " + hdfAnio.Value);
            secuencia.Replace("PLATINO_MES_1", "PLATINO " + hdfLeyendaMes1.Value + " " + hdfAnio.Value);
            secuencia.Replace("PLATINO_MES_2", "PLATINO " + hdfLeyendaMes2.Value + " " + hdfAnio.Value);
            secuencia.Replace("PLATINO_MES_ACTUAL", "PLATINO " + hdfLeyendaMes3.Value + " " + hdfAnio.Value);
            secuencia.Replace("TOTAL_MES_1", "TOTAL " + hdfLeyendaMes1.Value + " " + hdfAnio.Value);
            secuencia.Replace("TOTAL_MES_2", "TOTAL " + hdfLeyendaMes2.Value + " " + hdfAnio.Value);
            secuencia.Replace("TOTAL_MES_ACTUAL", "TOTAL " + hdfLeyendaMes3.Value + " " + hdfAnio.Value);
            return secuencia.ToString();
        }

        #endregion ExportarCVS

        #region IniciarDescarga
        /// <summary>
        /// Inicia la descarga con enviando la secuencia de comandos al cliente.
        /// </summary>
        /// <param name="secuencia"></param>
        private void IniciarDescarga(string secuencia)
        {
            try
            {
                string nombreDocumento = string.Format("{0}_{1}_{2}_{3}.{4}", "ActX", hdfTitulo.Value.Trim(), hdfMes.Value + hdfAnio.Value, DateTime.Now.ToString("ddMMyyyyhhmmss"), "xls");

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
            lblTitulo.Text = string.Empty;
            hdfTitulo.Value = string.Empty;
            hdfSucursal.Value = string.Empty;
            hdfMes.Value = string.Empty;
            hdfAnio.Value = string.Empty;
        }

        #endregion LimpiarGrid

        #endregion METHODS
    }
}