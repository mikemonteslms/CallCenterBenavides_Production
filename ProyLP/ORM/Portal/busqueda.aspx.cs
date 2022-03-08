using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class busqueda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                radBusqueda.DataSource = String.Empty;
            }
        }
        public DataView GetDataTable()
        {
            string buscar = txtBusqueda.Text.Trim().Length > 0 ? txtBusqueda.Text.Trim() : String.Empty;

            DataTable dtBuscar = new DataTable();
            EnumerableRowCollection<DataRow> query;
            MembershipUser u = Membership.GetUser();
            csParticipanteComplemento participante = new csParticipanteComplemento();
            dtBuscar = participante.BuscaParticipantesGeneral(buscar, u.ProviderUserKey.ToString());
            query = from mibusqueda in dtBuscar.AsEnumerable()
                    where mibusqueda.Field<string>("clave_programa") == ConfigurationManager.AppSettings["programa"]
                    select mibusqueda;
            return query.AsDataView();
        }

        protected void lnkSeleccionar_Command(object sender, CommandEventArgs e)
        {
            string participante_id = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "seleccionar":
                    csParticipanteComplemento p = new csParticipanteComplemento();
                    p.ID = participante_id;
                    p.DatosParticipante();
                    Session["participante_id"] = participante_id;
                    Session["distribuidor_id"] = null;
                    Master.CargaDistribuidor();
                    break;
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            foreach (Telerik.Web.UI.GridColumn column in radBusqueda.MasterTableView.Columns)
            {
                column.CurrentFilterFunction = Telerik.Web.UI.GridKnownFunction.NoFilter;
                column.CurrentFilterValue = string.Empty;
            }
            radBusqueda.MasterTableView.FilterExpression = string.Empty;
            radBusqueda.DataSource = GetDataTable();
            radBusqueda.DataBind();
        }
        protected void radBusqueda_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            radBusqueda.DataSource = GetDataTable();
        }
    }
}