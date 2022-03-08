using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace CallcenterNUevo.CALLCENTER
{
    public partial class rptConsultaTraspasos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnExportar.Enabled = false;
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
                ddlMes.Items.Insert(0, new ListItem("Selecciona", "0"));

                ddlAnio.Items.Insert(0, new ListItem("2015", "2015"));
                ddlAnio.Items.Insert(0, new ListItem("2016", "2016"));
                ddlAnio.Items.Insert(0, new ListItem("Selecciona", "0"));

                Sucursales obj = new Sucursales();
                ddlSucursales.DataSource = obj.ObtenerCatalogoDeSucursalSap();
                ddlSucursales.DataValueField = "Sucursal_intCiaSuc";
                ddlSucursales.DataTextField = "Sucursal_strNombreSap";
                ddlSucursales.DataBind();
                ddlSucursales.Items.Insert(0, new RadComboBoxItem("Todas", "0"));
            }
            Master.MenuMain = "Operaciones";
            Master.Submenu = "Traspasos";
        }

        protected void btnGeneraReporte_Click(object sender, EventArgs e)
        {
            if (ddlAnio.SelectedIndex == 0 && ddlMes.SelectedIndex == 0 && string.IsNullOrEmpty(txtTarjeta.Text) && (ddlSucursales.SelectedIndex == 0 || ddlSucursales.SelectedIndex == -1))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Debes seleccionar un parametro de busqueda');", true);
                return;
            }
            rgResultado.DataSource = Tarjetas.ConsultarTraspasos(ddlAnio.SelectedValue,ddlMes.SelectedValue, txtTarjeta.Text,ddlSucursales.SelectedValue);
            rgResultado.DataBind();
            if (rgResultado.MasterTableView.Items.Count > 0)
                btnExportar.Enabled = true;
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            //DataTable dataSetRegistos = ).Tables[0];
            IniciarDescarga(ExportarCVS(Tarjetas.ConsultarTraspasos(ddlAnio.SelectedValue,ddlMes.SelectedValue, txtTarjeta.Text,ddlSucursales.SelectedValue)));
            //rgResultado.ExportSettings.Excel.Format = GridExcelExportFormat.Xlsx;
            //rgResultado.ExportSettings.IgnorePaging = true;//--CheckBox1.Checked;
            //rgResultado.ExportSettings.ExportOnlyData = true;
            //rgResultado.ExportSettings.FileName = "rptTraspasos_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
            //rgResultado.MasterTableView.ExportToExcel();
        }

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
            //secuencia.Replace("Dias", "DIAS");
            //secuencia.Replace("AZUL_MES_1", "AZUL " + hdfLeyendaMes1.Value + " " + hdfAnio.Value);
            //secuencia.Replace("AZUL_MES_2", "AZUL " + hdfLeyendaMes2.Value + " " + hdfAnio.Value);
            //secuencia.Replace("AZUL_MES_ACTUAL", "AZUL " + hdfLeyendaMes3.Value + " " + hdfAnio.Value);
            //secuencia.Replace("PLATINO_MES_1", "PLATINO " + hdfLeyendaMes1.Value + " " + hdfAnio.Value);
            //secuencia.Replace("PLATINO_MES_2", "PLATINO " + hdfLeyendaMes2.Value + " " + hdfAnio.Value);
            //secuencia.Replace("PLATINO_MES_ACTUAL", "PLATINO " + hdfLeyendaMes3.Value + " " + hdfAnio.Value);
            //secuencia.Replace("TOTAL_MES_1", "TOTAL " + hdfLeyendaMes1.Value + " " + hdfAnio.Value);
            //secuencia.Replace("TOTAL_MES_2", "TOTAL " + hdfLeyendaMes2.Value + " " + hdfAnio.Value);
            //secuencia.Replace("TOTAL_MES_ACTUAL", "TOTAL " + hdfLeyendaMes3.Value + " " + hdfAnio.Value);
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
                string nombreDocumento = string.Format("{0}_{1}{2}{3}.{4}", "rptTraspasos", DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString() , DateTime.Now.Year.ToString(), "xls");

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

        protected void rgResultado_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            rgResultado.DataSource = Tarjetas.ConsultarTraspasos(ddlAnio.SelectedValue, ddlMes.SelectedValue, txtTarjeta.Text, ddlSucursales.SelectedValue);
            rgResultado.Rebind();
        }
    }
}