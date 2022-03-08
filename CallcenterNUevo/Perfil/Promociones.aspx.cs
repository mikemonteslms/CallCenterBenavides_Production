using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using CallcenterNUevo.WsReglasNegocio;
using System.Text;

namespace CallcenterNUevo.Perfil
{
    public partial class Promociones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Master.MenuMain = "Clientes";
                Master.Submenu = "Promociones y Descuentos";
                if (Session["strTarjeta"] != null)
                {
                    // txtTarjeta.Text = Session["strTarjeta"].ToString();
                    // btnGeneraReporte_Click(btnGeneraReporte, new EventArgs());
                    //rdcPromos.DataSource = ConsultarPromos(Session["strTarjeta"].ToString());
                    //rdcPromos.DataBind();
                    CargarConsultaLaboratorios(Session["strTarjeta"].ToString());
                    CargaDescuentos(Session["strTarjeta"].ToString());
                    //if (Request.QueryString["Opcion"] != null)
                    //{
                    //    if (Request.QueryString["Opcion"] == "1")
                    //    {
                    //        pnlPromos.Visible = true;
                    //        pnlDescuentos.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        pnlPromos.Visible = true;
                    //        pnlDescuentos.Visible = false;
                    //    }
                    //}
                    //else
                    //{
                    //    pnlPromos.Visible = true;
                    //    pnlDescuentos.Visible = false;
                    //}
                }
                else
                    Response.Redirect("~/callcenter/BusquedaCliente.aspx");
            }
        }

        private void CargarConsultaLaboratorios(string Tarjeta)
        {
            WsReglasNegocio.WsReglasNegocioSoapClient wsRGAcumulacion = new WsReglasNegocio.WsReglasNegocioSoapClient();
           WsReglasNegocio.ConsultaAcumulacionPendienteResult resultado = wsRGAcumulacion.ConsultaAcumulacionPendiente("1", "998877", Session["strTarjeta"].ToString(), "99", HttpContext.Current.User.Identity.Name.ToString());
                
            //DataSet dtsDatos = Clientes.ConsultaAcumulacion(Session["strTarjeta"].ToString(), rdcPromos.SelectedValue);

            rdcPromos.DataSource = resultado.Data;
            rdcPromos.DataValueField = "Sku";
            rdcPromos.DataTextField = "NombreProducto";
            rdcPromos.DataBind();
            
            rdcPromos.Items.Insert(0,new Telerik.Web.UI.RadComboBoxItem("TODOS",""));

            rdcPromos_SelectedIndexChanged(rdcPromos, new Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs("","","",""));
            //RadGrid1.DataSource = obj.Data;
            //RadGrid1.DataBind();
        }

        private void CargaDescuentos(string Tarjeta)
        {
            RadGrid2.DataSource = Clientes.HistoricoDescuentoTarjet(Tarjeta);
            RadGrid2.DataBind();
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            RadGrid1.ExportSettings.ExportOnlyData = true;
            RadGrid1.ExportSettings.IgnorePaging = false;
            RadGrid1.ExportSettings.UseItemStyles = false;
            RadGrid1.ExportSettings.FileName = "Promociones_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            RadGrid1.ExportSettings.OpenInNewWindow = true;
            RadGrid1.ExportToExcel();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RadGrid2.ExportSettings.ExportOnlyData = true;
            RadGrid2.ExportSettings.IgnorePaging = false;
            RadGrid2.ExportSettings.UseItemStyles = false;
            RadGrid2.ExportSettings.FileName = "Descuentos_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            RadGrid2.ExportSettings.OpenInNewWindow = true;
            RadGrid2.ExportToExcel();
        }

        protected void rdcPromos_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            WsReglasNegocio.WsReglasNegocioSoapClient wsRGAcumulacion = new WsReglasNegocio.WsReglasNegocioSoapClient();
            WsReglasNegocio.ConsultaAcumulacionPendienteResult resultado = wsRGAcumulacion.ConsultaAcumulacionPendiente("1", "998877", Session["strTarjeta"].ToString(), "99", HttpContext.Current.User.Identity.Name.ToString());

            if (rdcPromos.SelectedIndex > 0)
            {
                List<dataConsultaAcumulacion> lstAcumulacion = new List<dataConsultaAcumulacion>();
                foreach (dataConsultaAcumulacion item in resultado.Data)
                {
                    if (item.Sku == rdcPromos.SelectedValue)
                        lstAcumulacion.Add(item);
                }
                RadGrid1.DataSource = lstAcumulacion;
            }
            else
                RadGrid1.DataSource = resultado.Data;
            RadGrid1.DataBind();
        }

        protected void RadGrid2_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            RadGrid2.DataSource = Clientes.HistoricoDescuentoTarjet(Session["strTarjeta"].ToString());
            RadGrid2.Rebind();
        }

        protected void RadGrid1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            WsReglasNegocio.WsReglasNegocioSoapClient wsRGAcumulacion = new WsReglasNegocio.WsReglasNegocioSoapClient();
            WsReglasNegocio.ConsultaAcumulacionPendienteResult resultado = wsRGAcumulacion.ConsultaAcumulacionPendiente("1", "998877", Session["strTarjeta"].ToString(), "99", HttpContext.Current.User.Identity.Name.ToString());

            if (rdcPromos.SelectedIndex > 0)
            {
                List<dataConsultaAcumulacion> lstAcumulacion = new List<dataConsultaAcumulacion>();
                foreach (dataConsultaAcumulacion item in resultado.Data)
                {
                    if (item.Sku == rdcPromos.SelectedValue)
                        lstAcumulacion.Add(item);
                }
                RadGrid1.DataSource = lstAcumulacion;
            }
            else
                RadGrid1.DataSource = resultado.Data;
            RadGrid1.Rebind();
            //RadGrid1.DataSource = Clientes.ConsultaAcumulacion(Session["strTarjeta"].ToString(), rdcPromos.SelectedValue);
            //RadGrid1.Rebind();
        }
    }
}