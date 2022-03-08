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

namespace WebPfizer.LMS.eCard
{

    public partial class ReporteBase : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();

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

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //string nombreSP1 = Session["nombreSP1"].ToString();
                //string nombreSP1 = Request.QueryString["nombreSP1"];

                string nombreSP1 = "sp_ReporteTop20Segmento";

                objDataset = cliente.DatosLlenaConsultaSP(nombreSP1);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    grvDatos.DataSource = objDataset;
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
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void CargaDatosDG()
        {
            try
            {
                //string nombreSP2 = Session["nombreSP2"].ToString();
                string nombreSP2 = "sp_ReporteTop20Segmento";

                objDataset = cliente.DatosLlenaConsultaSP(nombreSP2);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    dgDatos.DataSource = objDataset;
                    dgDatos.DataBind();
                    dgDatos.Visible = true;
                }
                else
                {
                    dgDatos.DataSource = null;
                    dgDatos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void imgBtnExportar_Click1(object sender, ImageClickEventArgs e)
        {
            try
            {
                //METODO NUEVO
                CargaDatosDG();
                string strNombreReporte = "Detalle de Reporte";
                dgDatos.Visible = true;
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=" + strNombreReporte + ".xls");
                Response.Charset = "";

                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/ms-excel";

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

                dgDatos.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
                dgDatos.Visible = false;
                CargaDatosDG();
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }




    }

}
