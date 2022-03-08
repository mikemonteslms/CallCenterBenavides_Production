using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;

namespace WebPfizer.LMS.eCard
{
    public partial class ReportePromociones : System.Web.UI.Page
    {
        Clientes cliente = new Clientes();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaldoMovBuscar_Click(object sender, ImageClickEventArgs e)
        {
            DataSet objDataset = new DataSet();

            objDataset = cliente.GetPromoRepAcumulado(txtTarjeta.Text);

            if (objDataset.Tables[0].Rows.Count > 0)
            {
                gvwResultado.DataSource = objDataset;
                gvwResultado.DataBind();
            }
            else
            {
                gvwResultado.DataSource = null;
                gvwResultado.DataBind();
            }
        }
    }
}