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
    public partial class ReportesBenavidesSegmentos : System.Web.UI.Page
    {
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
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        //Exporta DataTable a csv        
        protected void Exportar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                objDT = ngRep.CargarDataTable("sp_ReporteTop20Segmento");

                ExportarExcelDataTable(objDT, "Reporte Top20 Segmento.csv");
                //ExportarExcelDataTable(objDT, "Reporte Top20 Segmento.xls");
            }
            catch (Exception error)
            {
                Mensajes(error.Message);
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

        //Regresa a pantalla de Men�        
        protected void SaldoMovRegresar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("IndexRep.aspx");
        }

        //Carga de informaci�n de Gridview        
        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CargarDatos("sp_ReporteTop20Segmento");
            }
            catch (Exception error)
            {
                Mensajes(error.Message);
            }
        }
        protected void CargarDatos(string nombreSP)
        {
            try
            {
                objDT = ngRep.CargarDataTable(nombreSP);

                if (objDT.Rows.Count > 0)
                {
                    grvDatos.DataSource = objDT;
                    grvDatos.DataBind();
                    grvDatos.Visible = true;
                    lblMensajeTOP.Visible = false;
                }
                else
                {
                    grvDatos.DataSource = null;
                    grvDatos.DataBind();
                    lblMensajeTOP.Visible = false;
                }

            }
            catch (Exception error)
            {
                throw new ApplicationException(error.Message);
            }
        }
        protected void grvDatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView gv = (GridView)sender;
                gv.PageIndex = e.NewPageIndex;

                CargarDatos("sp_ReporteTop20Segmento");
            }
            catch (Exception error)
            {
                Mensajes(error.Message);
            }
        }


    }

}
