using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using xi = Telerik.Web.UI.ExportInfrastructure;
using Telerik.Web.UI.GridExcelBuilder;

namespace CallcenterNUevo.CALLCENTER
{
    public partial class BusquedaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.MenuMain = "Clientes";
            Master.Submenu = "Busqueda de cliente";
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            DataSet dtsDatos = new DataSet();
            Clientes objcliente = new Clientes();
            dtsDatos = objcliente.BusquedaCliente(txtTarjeta.Text, txtEmail.Text, txtCelular.Text, txtNombre.Text, txtAPaterno.Text, txtAMaterno.Text);   //Tarjetas.ObtenerTarjeta(txtTarjeta.Text);
            rdgResultado.DataSource = dtsDatos.Tables[0];
            rdgResultado.DataBind();
        }

        protected void rdgResultado_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string[] strDatos;
            strDatos = e.CommandArgument.ToString().Split('|');

            if (e.CommandName.ToString().ToLower() == "select")
            {
                Session.Add("TarjetaStatus", strDatos[1]);
                Response.Redirect("~/Perfil/Perfil.aspx?ID=" + WebUtility.HtmlEncode(strDatos[0]), true);
            }
        }

        protected void rdgResultado_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            DataSet dtsDatos = new DataSet();
            Clientes objcliente = new Clientes();
            dtsDatos = objcliente.BusquedaCliente(txtTarjeta.Text, txtEmail.Text, txtCelular.Text, txtNombre.Text, txtAPaterno.Text, txtAMaterno.Text);   //Tarjetas.ObtenerTarjeta(txtTarjeta.Text);
            rdgResultado.DataSource = dtsDatos.Tables[0];
            rdgResultado.Rebind();
        }

        protected void rdgResultado_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            //if (e.Item is Telerik.Web.UI.GridDataItem)
            //{
            //    Telerik.Web.UI.GridDataItem item = e.Item as Telerik.Web.UI.GridDataItem;
            //    HiddenField hdnEstatus = (HiddenField)item.FindControl("hdnEstatus");
            //    if (hdnEstatus.Value != "1")
            //        ((Button)item.FindControl("btnSelect")).Visible = false;
            //}
        }
    }
}