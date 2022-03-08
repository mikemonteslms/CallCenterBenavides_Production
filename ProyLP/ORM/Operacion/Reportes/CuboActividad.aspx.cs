using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Drawing;
using eis = Telerik.Web.UI.ExportInfrastructure;
using CNegocio;
using System.Web.Security;

namespace ORMOperacion.Reportes
{
    public partial class CuboActividad : System.Web.UI.Page
    {
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
                Master.Submenu = "Cubo Actividades";
                InicializarFiltros();
            }
        }

        /// <summary>
        /// Indicar que campos se muestran y cuales van ocultos de los filtros
        /// </summary>
        private void InicializarFiltros()
        {
            ucFiltros.BotonExportar.Visible = true;
            ucFiltros.BotonBuscar = false;
            ucFiltros.TablaFechas = "none";
            //ucFiltros.RutaMenu = "Reportes >> Cubo Actividad";

        }

        /// <summary>
        /// Exporta a excel los resultados que se están visualizando en el cubo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ucFiltros_ExportarClicked(object sender, EventArgs e)
        {

            cubo.ExportSettings.IgnorePaging = true;
            cubo.ExportToExcel();
        }

        /// <summary>
        /// Asociación del DataSource con el cubo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cubo_NeedDataSource(object sender, Telerik.Web.UI.PivotGridNeedDataSourceEventArgs e)
        {
            if (Membership.GetUser() != null)
            {
                cubo.DataSource = csReporteNegocio.EjecutarProcedimientoCubo(Membership.GetUser().ProviderUserKey.ToString(), "cuboactividad");
            }
        }

        /// <summary>
        /// Cuando se exposta a excel establecer el estilo para el color de las celdas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cubo_CellDataBound(object sender, Telerik.Web.UI.PivotGridCellDataBoundEventArgs e)
        {
            PivotGridDataCell cell = e.Cell as PivotGridDataCell;
            if (cell != null && cell.DataItem != null && cell.DataItem.GetType() == typeof(decimal) && cell.CellType == PivotGridDataCellType.DataCell)
            {
                decimal value = Convert.ToDecimal(e.Cell.DataItem);
                if (value > 100000)
                {
                    e.Cell.BackColor = Color.FromArgb(203, 239, 246);
                }
            }
        }

        /// <summary>
        /// Establecer estilos en el excel para exportar el cubo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cubo_PivotGridCellExporting(object sender, Telerik.Web.UI.PivotGridCellExportingArgs e)
        {
            PivotGridBaseModelCell modelDataCell = e.PivotGridModelCell as PivotGridBaseModelCell;
            if (modelDataCell != null)
            {
                csReporteNegocio.AddStylesToDataCells(modelDataCell, e);
            }

            if (modelDataCell.TableCellType == PivotGridTableCellType.RowHeaderCell)
            {
                csReporteNegocio.AddStylesToRowHeaderCells(modelDataCell, e);
            }

            if (modelDataCell.TableCellType == PivotGridTableCellType.ColumnHeaderCell)
            {
                csReporteNegocio.AddStylesToColumnHeaderCells(modelDataCell, e);
            }

            if (modelDataCell.IsGrandTotalCell)
            {
                e.ExportedCell.Style.BackColor = Color.FromArgb(107, 141, 194);
                e.ExportedCell.Style.Font.Bold = true;
            }

            if (csReporteNegocio.IsTotalDataCell(modelDataCell))
            {
                e.ExportedCell.Style.BackColor = Color.FromArgb(176, 208, 189);
                e.ExportedCell.Style.Font.Bold = true;
                csReporteNegocio.AddBorders(e);
            }

            if (csReporteNegocio.IsGrandTotalDataCell(modelDataCell))
            {
                e.ExportedCell.Style.BackColor = Color.FromArgb(176, 208, 189);
                e.ExportedCell.Style.Font.Bold = true;
                csReporteNegocio.AddBorders(e);
            }
        }

        public string GetMonthName(object obj)
        {
            return csReporteNegocio.ObtieneNombreMes(obj);
        }
    }
}