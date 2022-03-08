using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallcenterNUevo.Perfil
{
    public partial class BeneficiosEsp : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();
        EntActualizarCliente ent = new EntActualizarCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.MenuMain = "Clientes";
            Master.Submenu = "Beneficios Especiales";
            if (!Page.IsPostBack)
            {
                if (Session["strTarjeta"] != null)
                {
                    //Session["strTarjeta"] = WebUtility.HtmlDecode(Request.QueryString["ID"].ToString());
                    //Response.Write(Session["strTarjeta"].ToString());
                    //ObtenerComunicacionEnviada(Session["strTarjeta"].ToString());
                    ObtenerBeneficiosEsp(Session["strTarjeta"].ToString());
                }
            }
        }
        private void ObtenerBeneficiosEsp(string Tarjeta)
        {
            objDataset = cliente.ObtenerbenficiosEsp(Tarjeta);

            if (objDataset.Tables[0].Rows.Count > 0)
            {
                RadGrid1.DataSource = objDataset;
                RadGrid1.DataBind();
            }
            else
            {
                RadGrid1.DataSource = null;
                RadGrid1.DataBind();
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            //DataTable dataSetRegistos = ).Tables[0];
            IniciarDescarga(ExportarCVS(cliente.ObtenerbenficiosEsp(Session["strTarjeta"].ToString()).Tables[0]));
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
                string nombreDocumento = string.Format("{0}_{1}{2}{3}.{4}", "BeneficiosEspeciales", DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), "xls");

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
    }
}