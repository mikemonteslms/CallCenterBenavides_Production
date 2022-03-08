using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace CNegocio
{
    public static class csReporteNegocio
    {

        public static void FormatearExcel(RadGrid gridResultado)
        {
            gridResultado.AllowFilteringByColumn = false;
            gridResultado.ShowGroupPanel = false;
            int posColumna = 0;
            foreach (GridColumn col in gridResultado.MasterTableView.Columns)
            {

                //  col.HeaderStyle.Width = Unit.Pixel(col.HeaderText.Length + 150);
                //     col.HeaderStyle.Font.Bold = true;
                col.HeaderStyle.BorderStyle = BorderStyle.Solid;
                col.HeaderStyle.BackColor = System.Drawing.Color.LightGray;
                col.ItemStyle.BorderStyle = BorderStyle.Solid;


            }

            //  return gridResultado;

        }

        public static DataSet EjecutarProcedimiento(string fechaInicio, string fechaFin, int programa, int tipoParticipante, int estatus, int distribuidor, string reporte, string usuario)
        {
            string nombresp = "";
            switch (reporte.ToLower())
            {
                case "reporteparticipantes":
                    nombresp = "sp_reporte_participantes";
                    break;
                case "reportepuntosparticipantes":
                    nombresp = "sp_reporte_puntos_participantes";
                    break;
                case "reportedetallellamadas":
                    nombresp = "sp_reporte_detalle_llamadas";
                    break;
                case "reportedetallecanjes":
                    nombresp = "sp_reporte_detalle_canjes";
                    break;
                case "reporteperfiles":
                    nombresp = "sp_reporte_perfiles";
                    break;
                case "reportepasivos":
                    nombresp = "sp_reporte_pasivos";
                    break;
                case "reportemarcas":
                    nombresp = "sp_reporte_puntos_marcas";
                    break;
            }

            return CallCenterDB.csReporte.ObtieneReporteOperacion(fechaInicio, fechaFin, programa, tipoParticipante, estatus, distribuidor, nombresp, usuario);
        }
        public static DataSet EjecutarProcedimientoAsignaciones(string fecha, int programa, int tipoReporte, string reporte)
        {

            return CallCenterDB.csReporte.ObtieneReporteAsignacion(fecha, programa, tipoReporte, "sp_reporte_asignaciones", "");
        }

        public static DataSet EjecutarProcedimientoCubo(string usuario, string cuboNombre)
        {
            string nombresp = "";
            switch (cuboNombre.ToLower())
            {
                case "cuboparticipantes":
                    nombresp = "sp_cubo_participantes";
                    break;
                case "cuboactividad":
                    nombresp = "sp_cubo_actividad";
                    break;
                case "cubopuntos":
                    nombresp = "sp_cubo_puntos";
                    break;
            }

            return CallCenterDB.csReporte.ObtieneCubo(usuario, nombresp);
        }


        #region Métodos para exportar a excel

        public static void AddStylesToDataCells(PivotGridBaseModelCell modelDataCell, PivotGridCellExportingArgs e)
        {
            if (modelDataCell.Data != null && modelDataCell.Data.GetType() == typeof(decimal))
            {
                decimal value = Convert.ToDecimal(modelDataCell.Data);
                if (value > 100000)
                {
                    e.ExportedCell.Style.BackColor = Color.FromArgb(51, 204, 204);
                    AddBorders(e);
                }

                e.ExportedCell.Format = "$0.0";
            }
        }

        public static void AddStylesToColumnHeaderCells(PivotGridBaseModelCell modelDataCell, PivotGridCellExportingArgs e)
        {
            if (e.ExportedCell.Table.Columns[e.ExportedCell.ColIndex].Width == 0)
            {
                e.ExportedCell.Table.Columns[e.ExportedCell.ColIndex].Width = 20D;
            }

            if (modelDataCell.IsTotalCell)
            {
                e.ExportedCell.Style.BackColor = Color.FromArgb(107, 141, 194);
                e.ExportedCell.Style.Font.Bold = true;
            }
            else
            {
                e.ExportedCell.Style.BackColor = Color.FromArgb(145, 178, 221);
            }
            AddBorders(e);
        }

        public static void AddStylesToRowHeaderCells(PivotGridBaseModelCell modelDataCell, PivotGridCellExportingArgs e)
        {
            if (e.ExportedCell.Table.Columns[e.ExportedCell.ColIndex].Width == 0)
            {
                e.ExportedCell.Table.Columns[e.ExportedCell.ColIndex].Width = 11D;
            }
            if (modelDataCell.IsTotalCell)
            {
                e.ExportedCell.Style.BackColor = Color.FromArgb(107, 141, 194);
                e.ExportedCell.Style.Font.Bold = true;
            }
            else
            {
                e.ExportedCell.Style.BackColor = Color.FromArgb(145, 178, 221);
            }

            AddBorders(e);
        }

        public static void AddBorders(PivotGridCellExportingArgs e)
        {
            e.ExportedCell.Style.BorderBottomColor = Color.FromArgb(128, 128, 128);
            e.ExportedCell.Style.BorderBottomWidth = new Unit(1);
            e.ExportedCell.Style.BorderBottomStyle = BorderStyle.Solid;

            e.ExportedCell.Style.BorderRightColor = Color.FromArgb(128, 128, 128);
            e.ExportedCell.Style.BorderRightWidth = new Unit(1);
            e.ExportedCell.Style.BorderRightStyle = BorderStyle.Solid;

            e.ExportedCell.Style.BorderLeftColor = Color.FromArgb(128, 128, 128);
            e.ExportedCell.Style.BorderLeftWidth = new Unit(1);
            e.ExportedCell.Style.BorderLeftStyle = BorderStyle.Solid;

            e.ExportedCell.Style.BorderTopColor = Color.FromArgb(128, 128, 128);
            e.ExportedCell.Style.BorderTopWidth = new Unit(1);
            e.ExportedCell.Style.BorderTopStyle = BorderStyle.Solid;
        }

        public static bool IsTotalDataCell(PivotGridBaseModelCell modelDataCell)
        {
            return modelDataCell.TableCellType == PivotGridTableCellType.DataCell &&
               (modelDataCell.CellType == PivotGridDataCellType.ColumnTotalDataCell ||
                 modelDataCell.CellType == PivotGridDataCellType.RowTotalDataCell ||
                 modelDataCell.CellType == PivotGridDataCellType.RowAndColumnTotal);
        }

        public static bool IsGrandTotalDataCell(PivotGridBaseModelCell modelDataCell)
        {
            return modelDataCell.TableCellType == PivotGridTableCellType.DataCell &&
                (modelDataCell.CellType == PivotGridDataCellType.ColumnGrandTotalDataCell ||
                    modelDataCell.CellType == PivotGridDataCellType.ColumnGrandTotalRowTotal ||
                    modelDataCell.CellType == PivotGridDataCellType.RowGrandTotalColumnTotal ||
                    modelDataCell.CellType == PivotGridDataCellType.RowGrandTotalDataCell ||
                    modelDataCell.CellType == PivotGridDataCellType.RowAndColumnGrandTotal);
        }
        #endregion

        public static string ObtieneNombreMes(object obj)
        {
            string mes = "";
            switch (obj.ToString())
            {
                case "01":
                    mes = "Enero";
                    break;
                case "02":
                    mes = "Febrero";
                    break;
                case "03":
                    mes = "Marzo";
                    break;
                case "04":
                    mes = "Abril";
                    break;
                case "05":
                    mes = "Mayo";
                    break;
                case "06":
                    mes = "Junio";
                    break;
                case "07":
                    mes = "Julio";
                    break;
                case "08":
                    mes = "Agosto";
                    break;
                case "09":
                    mes = "Septiembre";
                    break;
                case "10":
                    mes = "Octubre";
                    break;
                case "11":
                    mes = "Noviembre";
                    break;
                case "12":
                    mes = "Diciembre";
                    break;
            }
            return mes;
        }
    }
}
