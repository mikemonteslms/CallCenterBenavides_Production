using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class listacontratos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["distribuidor_id"] != null)
            {
                ConsultaChasisesPendientes(Convert.ToInt32(Session["distribuidor_id"]));
            }
        }
        protected void ConsultaChasisesPendientes(int distribuidor_id)
        {
            csDistribuidor d = new csDistribuidor();
            gvContratos.DataSource = d.ConsultaChasisesPendientesPorAsignar(distribuidor_id);
            gvContratos.DataBind();
        }
    }
}