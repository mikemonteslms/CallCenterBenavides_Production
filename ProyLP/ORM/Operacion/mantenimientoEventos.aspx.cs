using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ORMOperacion
{
    public partial class mantenimientoEventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.Menu = "Parametros";
                Master.Submenu = "Eventos";
            }
        }
    }
}