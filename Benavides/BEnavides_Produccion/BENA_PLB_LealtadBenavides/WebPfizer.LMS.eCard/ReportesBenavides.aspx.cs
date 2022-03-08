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

namespace Portal_Benavides
{
    public partial class ReportesBenavides : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        DataTable objDataTable = new DataTable();
        
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioCC"] == null)
            {
                Response.Redirect("AccesoCallCenter.aspx", true);
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void CargaTransaccionesReportes(string tarjeta, int parametro)
        {
            try
            {
                objDataset = cliente.DatosTransaccionesReportes(tarjeta, parametro);

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
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }

        protected void CargaDatosCliente(string idcliente)
        {
            try
            {
                objDataset = cliente.DatosCLiente(idcliente);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    lblNombreTarjeta.Text = objDataset.Tables[0].Rows[0]["Nombre"].ToString();
                    //lblFechaNacimientoTarjeta.Text = objDataset.Tables[0].Rows[0]["FechaNacimiento"].ToString();

                    lblNivelTarjeta.Text = objDataset.Tables[0].Rows[0]["Nivel"].ToString();
                    lblSaldoMovTarjeta.Text = objDataset.Tables[0].Rows[0]["Saldo"].ToString();

                    lblEstatusTarjeta.Text = objDataset.Tables[0].Rows[0]["EstatusTarjeta"].ToString();
                    lblFechaWEB.Text = objDataset.Tables[0].Rows[0]["AltaWEB"].ToString();

                    lblSaldoMovTelefono.Text = objDataset.Tables[0].Rows[0]["Telefono"].ToString();
                    lblSaldoCelular.Text = objDataset.Tables[0].Rows[0]["Celular"].ToString();
                    lblSaldoCorreo.Text = objDataset.Tables[0].Rows[0]["Correo"].ToString();
                    lblSaldoDireccion.Text = objDataset.Tables[0].Rows[0]["Direccion"].ToString();

                }
                else
                {
                    lblNivelTarjeta.Text = "Sin información";
                    lblSaldoMovTarjeta.Text = "Sin información";

                    lblEstatusTarjeta.Text = "Sin información";
                    lblFechaWEB.Text = "Sin información";

                    lblSaldoMovTelefono.Text = "Sin información";
                    lblSaldoCelular.Text = "Sin información";
                    lblSaldoCorreo.Text = "Sin información";
                    lblSaldoDireccion.Text = "Sin información";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }

        protected void SaldoMovRegresar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void btnReporteTransacciones_Click(object sender, ImageClickEventArgs e)
        {
            string tarjeta = txtTarjeta.Text;

            lblTituloGrid.Text = "Movimientos de la Tarjeta: ";
            CargaTransaccionesReportes(tarjeta, 1);
            CargaDatosCliente(tarjeta);
        }

        protected void Exportar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                Page page = new Page();
                HtmlForm form = new HtmlForm();

                grvDatos.EnableViewState = false;

                page.EnableEventValidation = false;
                page.DesignerInitialize();
                page.Controls.Add(form);
                form.Controls.Add(grvDatos);
                page.RenderControl(htw);

                Response.Clear();
                //Response.Buffer = true;

                Response.AddHeader("Content-Disposition", "attachment;filename=" + lblTituloGrid.Text + ".xls");
                Response.Charset = "UTF-8";
                //Response.Charset = "";

                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Default;

                Response.Write(sw.ToString());
                Response.End();

                //grvReportesBenavides.AllowPaging = true;
                //grvReportesBenavides.DataBind();
            }
            catch (Exception exp)
            {
                //en c# web lo mensajes en pantalla hay que realizarlos con javascript, en c# windform son por defecto asi            
                string script = @"<script language = ""JavaScript"">alert('Filtre más la informacion por que se sobrepaso de los 65.536 registros del excel');</script>";
                ClientScript.RegisterStartupScript(typeof(Page), "Alerta", script);
                return;
            }
        }

        protected void btnReporteClientes_Click(object sender, ImageClickEventArgs e)
        {
            string tarjeta = txtTarjeta.Text;

            lblTituloGrid.Text = "Datos del cliente: ";

            CargaDatosCliente(tarjeta);

            objDataset = cliente.DatosCLiente(tarjeta);
            grvDatos.DataSource = objDataset;
            grvDatos.DataBind();
        }

        protected void imgTopCompras_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                lblTituloGrid.Text = "Top 20 Ticket por mes: ";

                objDataTable = cliente.DatosDataDable("sp_ReportesTicketAlto");

                if (objDataTable.Rows.Count > 0)
                {
                    grvDatos.DataSource = objDataTable;
                    grvDatos.DataBind();
                }
                else
                {
                    grvDatos.DataSource = null;
                    grvDatos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }




    }

}
