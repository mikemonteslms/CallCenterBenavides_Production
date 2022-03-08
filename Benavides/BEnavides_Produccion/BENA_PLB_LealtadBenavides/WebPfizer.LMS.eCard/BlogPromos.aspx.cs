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
    public partial class BlogPromos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable tblDatos = new DataTable();
            if (Session["Usuario"] != null)
            {
                if (Request.QueryString["ID"] != null)
                    tblDatos = Clientes.GetPromociones(Convert.ToInt32(Request.QueryString["ID"]), Session["Usuario"].ToString());
                else
                    tblDatos = Clientes.GetPromociones(0, Session["Usuario"].ToString());                
            }

            if (tblDatos.Rows.Count > 0)
            {
                foreach (DataRow row in tblDatos.Rows)
                {
                    TableRow fila = new TableRow();
                    TableCell celda = new TableCell();
                    UserControls.DetallePromo detalle = (UserControls.DetallePromo)Page.LoadControl("~/UserControls/DetallePromo.ascx");
                    detalle.IDPromo = row["ID"].ToString();
                    detalle.TipoImage = row["NotificacionImagenMini"].ToString();
                    detalle.Titulo = row["DescripcionPromo"].ToString();
                    detalle.Contenido = row["PromocionHTML"].ToString();
                    celda.Controls.Add(detalle);
                    fila.Cells.Add(celda);
                    tblProducts.Rows.Add(fila);
                }
            }

        }
    }
}