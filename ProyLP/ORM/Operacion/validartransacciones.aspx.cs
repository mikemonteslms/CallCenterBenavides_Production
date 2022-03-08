using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using AjaxControlToolkit;

namespace ORMOperacion
{
    public partial class validartransacciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void radTransacciones_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            List<CNegocio.Transaccion> transacciones = CNegocio.csValidarTransaccion.Consulta();
            radTransacciones.DataSource = transacciones;
        }

        protected void radTransacciones_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            IGridColumnEditor editImporte = editableItem.EditManager.GetColumnEditor("Importe") as IGridColumnEditor;
            double importe = (double)((editImporte.ContainerControl.Controls[0] as Telerik.Web.UI.RadNumericTextBox).Value);
            var transaccion = (int)editableItem.GetDataKeyValue("ID");
            CNegocio.csValidarTransaccion.Modifica(transaccion, importe);
        }

        protected void btnAutorizar_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "autorizar":
                    bool autorizado = CNegocio.csValidarTransaccion.Autoriza(Convert.ToInt32(e.CommandArgument), new Guid(Membership.GetUser().ProviderUserKey.ToString()));
                    if (autorizado)
                    {
                        radTransacciones.Rebind();
                        Master.MuestraMensaje("Operación autorizada.");
                    }
                    else
                    {
                        Master.MuestraMensaje("Ocurrió un error en la autorización. Por favor intente nuevamente.");
                    }
                    break;
            }
        }
        protected void radTransacciones_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                ImageButton btn = (e.Item as GridDataItem)["TemplateColumn"].FindControl("btnAutorizar") as ImageButton;
                AjaxControlToolkit.ToolkitScriptManager tool = (AjaxControlToolkit.ToolkitScriptManager)Page.Master.Master.FindControl("ToolkitScriptManager1");
                tool.RegisterPostBackControl(btn);

            }
        }
    }
}