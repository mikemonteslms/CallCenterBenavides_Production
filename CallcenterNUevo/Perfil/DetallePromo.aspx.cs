using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallcenterNUevo.WsReglasNegocio;
using System.Data;
using Negocio;

namespace CallcenterNUevo.Perfil
{
    public partial class DetallePromo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.MenuMain = "Clientes";
            Master.Submenu = "Detalle Promociones";
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["PromoID"] != null && Session["strTarjeta"] != null)
                {
                    //wsLealtadBenavidesV7.WsReglasNegocio obj = new WsReglasNegocio();
                    //ConsultaMovimientosResult objeto = obj.ConsultaMovimientos(Session["strTarjeta"].ToString(), Convert.ToInt32(Request.QueryString["PromoID"]), "", 20);
                    DataSet dtsDatos = Clientes.ObtenerMovimientosDetalle(Session["strTarjeta"].ToString(), Request.QueryString["PromoID"].ToString());
                    rgvDetalle.DataSource = dtsDatos.Tables[0];
                    rgvDetalle.DataBind();
                }
                else
                    Response.Redirect("~/callcenter/BusquedaCliente.aspx");
            }
        }
        protected void btnExportar_Click(object sender, EventArgs e)
        {
            rgvDetalle.ExportSettings.ExportOnlyData = true;
            rgvDetalle.ExportSettings.IgnorePaging = true;
            rgvDetalle.ExportSettings.UseItemStyles = false;
            rgvDetalle.ExportSettings.FileName = "DetallePromocion_SKU_" + Request.QueryString["PromoID"] + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            rgvDetalle.ExportSettings.OpenInNewWindow = true;
            rgvDetalle.ExportToExcel();
        }

        protected void rgvDetalle_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            DataSet dtsDatos = Clientes.ObtenerMovimientosDetalle(Session["strTarjeta"].ToString(), Request.QueryString["PromoID"].ToString());
            rgvDetalle.DataSource = dtsDatos.Tables[0];
            rgvDetalle.Rebind();
        }

    }
}