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
    public partial class ReportesBenavidesCasosInusuales : System.Web.UI.Page
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

        protected void CargaReporte(int TipoCaso)
        {
            try
            {
                objDataset = cliente.DatosCasosInusuales(TipoCaso);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    dgCasosInusuales.DataSource = objDataset;
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
                if (ddlTipoCaso.SelectedValue == "0")
                {
                    Mensajes("Selecciona el tipo de caso que deseas visualizar");
                }
                else
                {
                    int TipoCaso = 0;
                    TipoCaso = Convert.ToInt32(ddlTipoCaso.SelectedValue);

                    objDataset = cliente.DatosCasosInusuales(TipoCaso);

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
                if (ddlTipoCaso.SelectedValue == "0")
                {
                    Mensajes("Selecciona el tipo de caso que deseas exportar");
                }
                else
                {
                    int TipoCaso = 0;
                    TipoCaso = Convert.ToInt32(ddlTipoCaso.SelectedValue);
                    CargaReporte(TipoCaso);
                    string strNombreReporte = "ReporteCasosInusuales";
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
                    CargaReporte(TipoCaso);
                }
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

        protected void ddlTipoCaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoCaso.SelectedValue == "1" || ddlTipoCaso.SelectedValue == "2")
            {
                lblMensaje.Visible = true;

                if (ddlTipoCaso.SelectedValue == "1")
                {
                    lblMensaje.Text = "Las tarjetas han realizado una compra por más de 35 unidades SU ESTATUS PERMANECE SIN RESTRICCIONES";
                }
                if (ddlTipoCaso.SelectedValue == "2")
                {
                    lblMensaje.Text = "Las tarjetas han realizado mas de una compra al día con más de 4 tickets SE HA ACTUALIZADO SU ESTATUS Y NO PUEDE REDIMIR PUNTOS";
                }
            }
            else
            {
                lblMensaje.Visible = false;
            }
        }

    }

}
