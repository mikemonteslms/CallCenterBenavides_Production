using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using CNegocio;
using System.Web.Security;

namespace ORMOperacion.Reportes
{
    public partial class ReportePerfiles : System.Web.UI.Page
    {

        private string nombreReporte = "reporteperfiles";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación autenticación de la página
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }

            if (!IsPostBack)
            {
                Master.Menu = "Reportes";
                Master.Submenu = "Perfiles";
                //Llenar combos para filtrar el grid
                Configuracion_Filtros();               
            }
        }

        /// <summary>
        /// Establecer que campos son los que se van a utilizar como filtros
        /// </summary>
        private void Configuracion_Filtros()
        {
            MembershipUser u = Membership.GetUser(Context.User.Identity.Name);

            ucFiltros.FechaInicial = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            ucFiltros.FechaFinal = DateTime.Now;

            ucFiltros.ConfigurarCombo(ucFiltros.Combo1, "Descripcion", "Id", "programas", "Listado1", "Programa: ", "table1", "", "", u.ProviderUserKey.ToString());
            ucFiltros.BotonExportar.Visible = false;

            //ucFiltros.RutaMenu = "Reportes >> Perfiles";
                        
        }

        private void Consulta(DateTime fechaInicio, DateTime fechaFin, int paisID)
        {
            try
            {
                DataSet dsResultados = csReporteNegocio.EjecutarProcedimiento(ucFiltros.FechaInicial.ToString("dd/MM/yyyy"), ucFiltros.FechaFinal.ToString("dd/MM/yyyy"), int.Parse(ucFiltros.Combo1.SelectedValue), -1, -1, -1, nombreReporte, Membership.GetUser().ProviderUserKey.ToString());

                if (dsResultados != null)
                {
                    if (dsResultados.Tables.Count > 0)
                    {
                        gridPoblacion.DataSource = dsResultados.Tables[1];
                        gridPoblacion.DataBind();

                        rgGenero.DataSource = dsResultados.Tables[2];
                        rgGenero.DataBind();
                        EstiloGrid(rgGenero);
                        GenerarGrafica(dsResultados.Tables[2], rhcGenero);

                        rgEdad.DataSource = dsResultados.Tables[3];
                        rgEdad.DataBind();
                        EstiloGrid(rgEdad);
                        GenerarGrafica(dsResultados.Tables[3], rhcEdad);

                        rgNSE.DataSource = dsResultados.Tables[4];
                        rgNSE.DataBind();
                        EstiloGrid(rgNSE);
                        GenerarGrafica(dsResultados.Tables[4], rhcNSE);

                        rhDiasTransacciones.DataSource = dsResultados.Tables[5];
                        rhDiasTransacciones.DataBind();
                        EstiloGrid(rhDiasTransacciones);
                        GenerarGrafica(dsResultados.Tables[5], rhcDiasTransacciones);

                        rgDiasPrograma.DataSource = dsResultados.Tables[6];
                        rgDiasPrograma.DataBind();
                        EstiloGrid(rgDiasPrograma);
                        GenerarGrafica(dsResultados.Tables[6], rhcDiasPrograma);

                        rgConEmail.DataSource = dsResultados.Tables[7];
                        rgConEmail.DataBind();
                        EstiloGrid(rgConEmail);
                        GenerarGrafica(dsResultados.Tables[7], rhcConEmail);

                       

                        tblResultados.Style.Add("Display", "");
                        tblNoRegistros.Style.Add("Display", "none");
                        lblPais.Text = " " + ucFiltros.Combo1.SelectedItem.Text;
                    }
                    else
                    {
                        tblResultados.Style.Add("Display", "none");
                        tblNoRegistros.Style.Add("Display", "");
                    }


                }
                else
                {
                    tblResultados.Style.Add("Display", "none");
                    tblNoRegistros.Style.Add("Display", "");
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "redirectMe", "setTimeout(function () {alert('Ocurrio un error. Contacte al administrador.');}, 600);", true);
            }
        }

        private void EstiloGrid(RadGrid grid)
        {
            try
            {
                for (int rowIndex = grid.Items.Count - 2; rowIndex >= 0; rowIndex--)
                {
                    GridDataItem row = grid.Items[rowIndex];
                    GridDataItem previousRow = grid.Items[rowIndex + 1];

                    row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : previousRow.Cells[2].RowSpan + 1;
                    row.Cells[2].VerticalAlign = VerticalAlign.Middle;
                    row.Cells[2].BackColor = System.Drawing.Color.LightBlue;
                    previousRow.Cells[2].Visible = false;

                    for (int i = 3; i < row.Cells.Count; i++)
                    {
                        try
                        {
                            grid.Items[1].Cells[i].Text = decimal.Round(Convert.ToDecimal(grid.Items[1].Cells[i].Text), 2) + "%";
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "redirectMe", "setTimeout(function () {alert('Ocurrio un error. Contacte al administrador.');}, 600);", true);
            }
        }

        private void GenerarGrafica(DataTable datos, RadHtmlChart grafico)
        {
            PieSeries chartData = new PieSeries();
            chartData.StartAngle = 90;
            chartData.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.Center;
            chartData.LabelsAppearance.DataFormatString = "{0:0.00}%";



            foreach (DataColumn columna in datos.Columns)
            {
                if (datos.Rows[1][columna.ColumnName].ToString().Trim() != string.Empty)
                {
                    try
                    {
                        SeriesItem item1 = new SeriesItem();
                        item1.Name = columna.ColumnName;
                        item1.YValue = decimal.Parse(datos.Rows[1][columna.ColumnName].ToString());
                        chartData.Items.Add(item1);
                    }
                    catch
                    {

                    }
                }
            }

            grafico.PlotArea.Series.Add(chartData);
        }
      
       
       
        /// <summary>
        /// Llena el grid con los resultados que coincidan de acuerdo a los filtros seleccionados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ucFiltros_BuscarClicked(object sender, EventArgs e) 
        {

            Consulta(Convert.ToDateTime(ucFiltros.FechaInicial), Convert.ToDateTime(ucFiltros.FechaFinal).AddDays(1), int.Parse(ucFiltros.Combo1.SelectedValue));
        }
        protected void rgGenero_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataBoundItem = e.Item as GridDataItem;

                if (((GridDataItem)e.Item).RowIndex == 4)
                {

                    dataBoundItem["Hombres"].Text = decimal.Round(Convert.ToDecimal(dataBoundItem["Hombres"].Text), 2) + "%";
                    dataBoundItem["Mujeres"].Text = decimal.Round(Convert.ToDecimal(dataBoundItem["Mujeres"].Text), 2) + "%";
                    dataBoundItem["NP"].Text = decimal.Round(Convert.ToDecimal(dataBoundItem["NP"].Text), 2) + "%";

                }


            }

        }
        
      
    }
}