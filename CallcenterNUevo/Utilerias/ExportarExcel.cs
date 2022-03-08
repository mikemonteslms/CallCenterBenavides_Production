using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Text;
using System.Data;

namespace CallcenterNUevo.Utilerias
{
    public class ExportarExcel
    {
        public string NomCol = "";
        public string ExportarCVS(DataTable dataTable)
        {
            NomCol = dataTable.Columns[0].ColumnName;
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
                    if (j == 0 && NomCol == "Cupón")
                    {
                        secuencia.Append("<td>'" + dr[j].ToString() + "'</td>");
                    }
                    else
                    {
                        secuencia.Append("<td>" + dr[j].ToString() + "</td>");
                    }
                }
                secuencia.Append("</tr>");
            }
            secuencia.Append("</table>");
            NomCol = "";
            return secuencia.ToString();
        }
    }
}