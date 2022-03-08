using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Negocio;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace Portal_Benavides
{
    public partial class ReportesBenavidesRep : System.Web.UI.Page
    {
        ReportesNeg negocio = new ReportesNeg();

        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();

        DataTable objDT = new DataTable();
        NegReportes ngRep = new NegReportes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioCC"] == null)
            {
                Response.Redirect("AccesoRep.aspx", true);
            }

            if (!IsPostBack)
            {
                string fechIni = "01/04/2013";
                txtFechaInicio.Text = fechIni;
                //ceFehaInicio.SelectedDate = Convert.ToDateTime(fechIni);

                DateTime fechAct = DateTime.Now;
                txtFechaFin.Text = fechAct.ToString("dd/MM/yyyy");
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        //protected void CargaActivacionesxSucursal()
        //{
        //    try
        //    {
        //        if (txtFechaInicio.Text == "" || txtFechaFin.Text == "")
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), "mensajeError", "alert('Debes capturar una fecha en ambas cajas de texto');", true);
        //        }
        //        else
        //        {
        //            string FechaIni = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtFechaInicio.Text));
        //            string FechaFin = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtFechaFin.Text));


        //            objDataset = cliente.DatosActivacionesxSucursal(FechaIni, FechaFin);

        //            if (objDataset.Tables[0].Rows.Count > 0)
        //            {
        //                dgExporta.DataSource = objDataset;
        //                dgExporta.DataBind();
        //                dgExporta.Visible = true;

        //            }
        //            else
        //            {
        //                dgExporta.DataSource = null;
        //                dgExporta.DataBind();
        //                dgExporta.Visible = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
        //    }
        //}

        protected void btnReporteTransacciones_Click(object sender, ImageClickEventArgs e)
        {
            if (txtFechaInicio.Text == "" || txtFechaFin.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensajeError", "alert('Debes capturar una fecha en ambas cajas de texto');", true);
            }
            else
            {
                string FechaIni = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtFechaInicio.Text));
                string FechaFin = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtFechaFin.Text));
                
                //objDataset = cliente.DatosActivacionesxSucursal(FechaIni, FechaFin);
                objDataset = negocio.DatosReporte("SP_ReportesActivacionesTransacciones",FechaIni, FechaFin);                                    

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    grvDatos.DataSource = objDataset;
                    grvDatos.DataBind();
                }
                else
                {
                    grvDatos.DataSource = null;
                    grvDatos.DataBind();
                }
            }
        }

        //Forma Tabla que se exportara de DataTable
        public void ExportarExcelDataTable(DataTable dt, string nombreArchivo)
        {
            try
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + nombreArchivo);

                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/csv";
                //Response.ContentType = "application/ms-excel";

                System.IO.StringWriter sw = new System.IO.StringWriter();

                int iColCount = dt.Columns.Count;

                // Escribiendo las Columnas del DataTable.
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dt.Columns[i]);
                    if (i < iColCount - 1)
                    {
                        sw.Write(",");
                    }
                }

                sw.Write(sw.NewLine);

                // Escribiendo todas las Filas del DataTable.
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }

                        if (i < iColCount - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();

                //System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);
                Response.Write(sw.ToString());
                Response.Flush();
                //Response.TransmitFile(@"localhost\xx.ods"); //revisar linea
                Response.End();
                Response.Close();
            }
            catch (Exception error)
            {
                throw new ApplicationException(error.Message);
            }
        }

        //Exporta DataTable a csv        
        protected void Exportar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtFechaInicio.Text == "" || txtFechaFin.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensajeError", "alert('Debes capturar una fecha en ambas cajas de texto');", true);
                }
                else
                {
                    string FechaIni = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtFechaInicio.Text));
                    string FechaFin = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtFechaFin.Text));

                    //objDT = ngRep.CargarDataTable("SP_ReportesActivacionesTransaccionesDescarga", FechaIni, FechaFin);
                    objDT = negocio.CargarDataTable("SP_ReportesActivacionesTransaccionesDescarga", FechaIni, FechaFin);

                    ExportarExcelDataTable(objDT, "Reporte Activaciones, Ventas y Redenciones por Sucursal.csv");
                }
            }
            catch (Exception error)
            {
                Mensajes(error.Message);
            }
        }
              
        protected void SaldoMovRegresar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("IndexRep.aspx");
        }

        protected void grvActivacionesxSucursal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.PageIndex = e.NewPageIndex;

            string FechaIni = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtFechaInicio.Text));
            string FechaFin = String.Format("{0:yyyyMMdd}", Convert.ToDateTime(txtFechaFin.Text));

            objDataset = cliente.DatosActivacionesxSucursal(FechaIni, FechaFin);

            if (objDataset.Tables[0].Rows.Count > 0)
            {
                grvDatos.DataSource = objDataset;
                grvDatos.DataBind();
            }
            else
            {
                grvDatos.DataSource = null;
                grvDatos.DataBind();
            }
        }

    }

}
