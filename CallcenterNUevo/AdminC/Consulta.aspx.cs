using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallcenterNUevo.AdminC
{
    public partial class Consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtBuscar.Attributes.Add("placeholder", "Cupón a Buscar:");
            if (!Page.IsPostBack)
            {
                pnlResultados.Visible = false;
                pnlSinInfo.Visible = false;
                //pnlEdicion.Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Consulta", "btnBuscar_Click", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
            rgResultado.DataSource = Negocio.Cupones.BusquedaCupon(txtBuscar.Text);
            rgResultado.DataBind();
            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Consulta", "btnBuscar_Click", "Fin de Consulta", this.User.Identity.Name.ToString(), null);

            if (rgResultado.MasterTableView.Items.Count > 0)
            {
                pnlResultados.Visible = true;
                pnlSinInfo.Visible = false;
            }
            else
            {
                pnlResultados.Visible = false;
                pnlSinInfo.Visible = true;
            }
        }

        protected void rgResultado_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            rgResultado.DataSource = Negocio.Cupones.BusquedaCupon(txtBuscar.Text);
            rgResultado.Rebind();
        }
    }
}