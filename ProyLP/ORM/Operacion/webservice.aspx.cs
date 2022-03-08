using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ORMOperacion
{
    public partial class webservice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            net.solsersistem.servicios.loyalty_vwsp ws = new net.solsersistem.servicios.loyalty_vwsp();
            DataSet ds = ws.services_loyaltyvwsp();
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();
            GridViewExportUtil.Export("webservice.xls", gv);
        }
    }
}