using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace ORMOperacion.registrar
{
    public partial class registrarParticipante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Clave");
                dt.Columns.Add("Sexo");
                Session["dt"] = dt;
            }
        }

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGrid1.DataSource = (DataTable)Session["dt"];
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                DropDownList ddlSexo = item.FindControl("ddlSexo") as DropDownList;
                DataTable DT1 = new DataTable();
                DT1.Columns.Add("ID", typeof(int));
                DT1.Columns.Add("sexo");
                DT1.Rows.Add(1, "Masculino");
                DT1.Rows.Add(2, "Femenino");
                ddlSexo.DataTextField = "sexo";
                ddlSexo.DataValueField = "ID";
                ddlSexo.DataSource = DT1;
                ddlSexo.DataBind();
            }
        }

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {

            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                DataTable dt = (DataTable)Session["dt"];
                dt.Rows.Add("", true);
                RadGrid1.MasterTableView.IsItemInserted = false;
                e.Canceled = true;
                RadGrid1.Rebind();
            }
        }
        
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            string Clave = string.Empty;
            string Sexo = string.Empty;
            foreach (GridDataItem di in RadGrid1.Items)
            {
                TextBox txtClave = (TextBox)(di.FindControl("txtClave"));
                DropDownList ddlSexo = (DropDownList)(di.FindControl("ddlSexo"));
                Clave += txtClave.Text + ",";
                Sexo += ddlSexo.SelectedItem.Value + ",";
            }
            Response.Write("Column Value : " + Clave);
            Response.Write("<br/>");
            Response.Write("Column Value : " + Sexo);
        }
    }
}