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
    public partial class ReportesBenavidesUltimaCompra : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        ReportesNeg negocio = new ReportesNeg();

        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();
        DataTable objDT = new DataTable();

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

        protected void CargaReporte()
        {
            try
            {                
                //objDT = cliente.DatosDataDable("sp_ReporteUltimaCompra");
                objDT = negocio.CargarDataTable("sp_ReporteUltimaCompra");        
                
                if (objDT.Rows.Count > 0)
                {
                    dgCasosInusuales.DataSource = objDT;
                    dgCasosInusuales.DataBind();
                    dgCasosInusuales.Visible = true;
                }
                else
                {
                    dgCasosInusuales.DataSource = null;
                    dgCasosInusuales.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //objDT = cliente.DatosDataDable("sp_ReporteUltimaCompra");
                objDataset = negocio.DatosReporte("sp_ReporteUltimaCompra");

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    grvCasosInusuales.DataSource = objDataset;
                    grvCasosInusuales.DataBind();
                    grvCasosInusuales.Visible = true;
                    lblMensaje.Visible = true;
                }
                else
                {
                    grvCasosInusuales.DataSource = null;
                    grvCasosInusuales.DataBind();
                    lblMensaje.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }

        protected void bntExportar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CargaReporte();
                string strNombreReporte = "ReporteUltimaCompra";
                dgCasosInusuales.Visible = true;

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + strNombreReporte + ".xls");
                Response.Charset = "";

                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/ms-excel";

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

                dgCasosInusuales.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
                dgCasosInusuales.Visible = false;
                CargaReporte();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensajeError", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("HomeRep.aspx");
            Response.Redirect("IndexRep.aspx");
        }

    }

}
