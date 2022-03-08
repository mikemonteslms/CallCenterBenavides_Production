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
    public partial class Llamadas : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Master.MenuMain = "Clientes";
                Master.Submenu = "Llamadas";
                if (Session["strTarjeta"] != null)
                {
                    txtTarjeta.Text = Session["strTarjeta"].ToString();
                    btnBuscar_Click(btnBuscar, new EventArgs());
                }
            }
        }

        protected void Limpiar_Click(object sender, EventArgs e)
        {
            txtTarjeta.Text = "";
            Session["strTarjeta"] = null;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Session["strTarjeta"] = txtTarjeta.Text;
            CargaListaLlamadas(txtTarjeta.Text);
        }
        protected void CargaListaLlamadas(string tarjeta)
        {
            try
            {
                objDataset = cliente.DatosListaLlamadas(tarjeta);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    grvListaLlamadasCC.DataSource = objDataset;
                    grvListaLlamadasCC.DataBind();
                }
                else
                {
                    grvListaLlamadasCC.DataSource = null;
                    grvListaLlamadasCC.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            IniciarDescarga(ExportarCVS(cliente.DatosListaLlamadas(Session["strTarjeta"].ToString()).Tables[0]));
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
                string nombreDocumento = string.Format("{0}_{1}{2}{3}.{4}", "Llamadas", DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), "xls");

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