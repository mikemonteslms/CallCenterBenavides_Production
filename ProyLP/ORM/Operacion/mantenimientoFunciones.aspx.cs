using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ORMOperacion
{
    public partial class mantenimientoFunciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación autenticación de la página
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                Master.Menu = "Control de acceso";
                Master.Submenu = "Funciones";
                rcbMenu.DataSource = CNegocio.csMenuNegocio.ConsultarMenu(0, Membership.GetUser().ProviderUserKey.ToString());
                rcbMenu.DataBind();
                rcbMenu.Items.Insert(0, new RadComboBoxItem("TODOS", "0"));

            }
        }

        protected void gridFunciones_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                var editableItem = ((GridEditableItem)e.Item);

                Hashtable values = new Hashtable();
                editableItem.ExtractValues(values);

                CNegocio.csMenuNegocio.InsertaFunciones(int.Parse(((RadComboBox)editableItem.FindControl("rcbMenu")).SelectedValue), values["nombre"].ToString(), values["url"].ToString(),  values["imagen"] == null ? "" : values["imagen"].ToString(), values["alt"] == null ? "" : values["alt"].ToString(), int.Parse(values["orden"].ToString()), Membership.GetUser().ProviderUserKey.ToString());
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('Error al insertar la función');</script>");
            }
        }

        protected void gridFunciones_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "delete")
            {
                try
                {
                    CNegocio.csMenuNegocio.ModificaFunciones("B", int.Parse((e.Item as GridDataItem).GetDataKeyValue("id").ToString()), 0, "", "", "", "", 0, Membership.GetUser().ProviderUserKey.ToString());
                }
                catch
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('Error al eliminar la función');</script>");
                }

            }
        }

        protected void gridFunciones_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                //  Cuando se oprima el botón de editar se deben de ocultar los campos que no se requieren el usuario los cambie directamente
                if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
                {
                    GridEditFormItem editform = (GridEditFormItem)e.Item;
                    editform["id"].Parent.Visible = false;
                    editform["menu_id"].Parent.Visible = false;
                    editform["fecha_alta"].Parent.Visible = false;
                    editform["fecha_baja"].Parent.Visible = false;
                    editform["fecha_cambio"].Parent.Visible = false;
                    editform["usuario_cambio_id"].Parent.Visible = false;
                    editform["usuario_baja_id"].Parent.Visible = false;
                    editform["usuario_alta_id"].Parent.Visible = false;
                }

                if (e.Item is GridDataItem)
                {
                    GridDataItem itemForm = (GridDataItem)e.Item;

                    
                    //Cuando los registros ya estén dados de baja se deben de ocultar los botones de editar y eliminar.
                    if (itemForm["fecha_baja"].Text != "&nbsp;")
                    {
                        itemForm.ForeColor = System.Drawing.Color.Red;
                        ((ImageButton)itemForm.Cells[2].Controls[0]).Visible = false;
                        ((ImageButton)itemForm.Cells[3].Controls[0]).Visible = false;
                    }
                }

                // Llenar los combos de la cabecera del filtro

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('Error al cargar los datos');</script>");
            }
        }

        protected void FilterCombo_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string filterExpression = "";
            string columna = "";

            switch (((RadComboBox)o).ID)
            {
                case "rcbMenu":
                    columna = "menu";
                    break;
                default:
                    break;
            }

            filterExpression = "([" + columna + "] = '" + e.Value + "')";

            if (e.Value != "0")
            {
                gridFunciones.MasterTableView.FilterExpression = filterExpression;
                gridFunciones.MasterTableView.GetColumn(columna).CurrentFilterValue = e.Value;
            }
            else
            {
                gridFunciones.MasterTableView.FilterExpression = string.Empty;
                gridFunciones.MasterTableView.GetColumn(columna).CurrentFilterValue = string.Empty;
            }

            gridFunciones.MasterTableView.Rebind();
        }

        protected void gridFunciones_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (Membership.GetUser() != null)
                gridFunciones.DataSource = CNegocio.csMenuNegocio.ConsultarFunciones(0, 0, Membership.GetUser().ProviderUserKey.ToString());
        }

        protected void gridFunciones_UpdateCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                var editableItem = ((GridEditableItem)e.Item);

                Hashtable values = new Hashtable();
                editableItem.ExtractValues(values);

                CNegocio.csMenuNegocio.ModificaFunciones("M", int.Parse(values["id"].ToString()), int.Parse(((RadComboBox)editableItem.FindControl("rcbMenu")).SelectedValue), values["nombre"] == null ? "" : values["nombre"].ToString(), values["url"] == null ? "" : values["url"].ToString(), values["imagen"] == null ? "" : values["imagen"].ToString(), values["alt"] == null ? "" : values["alt"].ToString(), int.Parse(values["orden"].ToString()), Membership.GetUser().ProviderUserKey.ToString());
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alerta", "<script>alert('Error al actualizar la función');</script>");
            }

        }

        protected void gridFunciones_ItemCreated(object sender, GridItemEventArgs e)
        {
            if ((e.Item is GridEditableItem) && (e.Item.IsInEditMode))
            {

                GridEditableItem editForm = (GridEditableItem)e.Item;
                editForm["menu"].Controls[0].Visible = false;
                RadComboBox combo = new RadComboBox();
                combo.ID = "rcbMenu";
                combo.DataTextField = "Nombre";
                combo.DataValueField = "Id";

                if (e.Item.ToString().Contains("Insert"))
                {
                    DataView dv = CNegocio.csMenuNegocio.ConsultarMenu(0, Membership.GetUser().ProviderUserKey.ToString()).DefaultView;
                    dv.RowFilter = "fecha_baja is null";
                    combo.DataSource = dv;
                }
                else
                    combo.DataSource = CNegocio.csMenuNegocio.ConsultarMenu(0, Membership.GetUser().ProviderUserKey.ToString());

                editForm["menu"].Controls.Add(combo);


            }
        }
    }
}