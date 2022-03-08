using EntitiesModel;
using System;
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
    public partial class mantenimientoBeneficios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                Master.Menu = "Parametros";
                Master.Submenu = "Beneficios";
            }
        }

        protected void OABeneficios_Inserting(object sender, Telerik.OpenAccess.Web.OpenAccessLinqDataSourceInsertEventArgs e)
        {
            using (EntitiesModel.EntitiesModel context = new EntitiesModel.EntitiesModel())
            {
                MembershipUser u = Membership.GetUser();
                beneficio beneficio = e.NewObject as beneficio;
                beneficio.fecha_alta = DateTime.Now;
                beneficio.usuario_alta_id = (Guid)u.ProviderUserKey;
                beneficio.programa_id = Int64.Parse(Session["programa_id"].ToString());
                if (Session["producto_id"] != null)
                {
                    beneficio.producto_id = Int64.Parse(Session["producto_id"].ToString());
                }
                else if (Session["premio_id"] != null)
                {
                    beneficio.premio_id = Int64.Parse(Session["premio_id"].ToString());
                }
                context.SaveChanges();
                Session["premio_id"] = null;
                Session["producto_id"] = null;
                Session["programa_id"] = null;
            }
        }

        protected void rdTipo_ItemSelected(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            if (e.Value.Equals("prod"))
            {
                RadDropDownList comboProductos = (RadDropDownList)(((GridEditFormItem)((RadDropDownList)sender).NamingContainer)).EditFormCell.FindControl("productoList");
                comboProductos.Visible = true;
                RadDropDownList comboPremios = (RadDropDownList)(((GridEditFormItem)((RadDropDownList)sender).NamingContainer)).EditFormCell.FindControl("premioList");
                comboPremios.Visible = false;
            }
            else if (e.Value.Equals("prem"))
            {
                RadDropDownList comboPremios = (RadDropDownList)(((GridEditFormItem)((RadDropDownList)sender).NamingContainer)).EditFormCell.FindControl("premioList");
                comboPremios.Visible = true;
                RadDropDownList comboProductos = (RadDropDownList)(((GridEditFormItem)((RadDropDownList)sender).NamingContainer)).EditFormCell.FindControl("productoList");
                comboProductos.Visible = false;
            }

        }

        protected void rgBeneficios_InsertCommand(object sender, GridCommandEventArgs e)
        {
            System.Collections.Specialized.ListDictionary newValues = new System.Collections.Specialized.ListDictionary();

            GridEditableItem editItem = (GridEditableItem)e.Item;
            newValues["clave"] = (editItem["clave"].Controls[0] as TextBox).Text;
            newValues["descripcion"] = (editItem["descripcion"].Controls[0] as TextBox).Text;
            newValues["descripcion_larga"] = (editItem["descripcion_larga"].Controls[0] as TextBox).Text;
            Session["programa_id"] = ((RadDropDownList)editItem.FindControl("programaList")).SelectedValue;

            string tipoBeneficio = ((RadDropDownList)editItem.FindControl("rdTipo")).SelectedValue;

            if (tipoBeneficio.Equals("prod"))
            {
                Session["producto_id"] = ((RadDropDownList)editItem.FindControl("productoList")).SelectedValue;
            }
            if (tipoBeneficio.Equals("prem"))
            {
                Session["premio_id"] = ((RadDropDownList)editItem.FindControl("premioList")).SelectedValue;
            }
            e.Item.OwnerTableView.InsertItem(newValues);
            //newValues["CompanyName"] = " default company name";

            //set default value for the dropdown list inside the EditItemTemplate
            //newValues["Country"] = "Germany";

            //set default checked state for the checkbox inside the EditItemTemplate
            //newValues["Bool"] = false;

            //Insert the item and rebind

            //using (EntitiesModel.EntitiesModel context = new EntitiesModel.EntitiesModel())
            //{

            //    e.Item.
            //    MembershipUser u = Membership.GetUser();
            //    GridEditFormInsertItem inserteditem = (GridEditFormInsertItem)e.Item.OwnerTableView.GetInsertItem();
            //    beneficio beneficio = inserteditem.DataItem as beneficio;

            //    //if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            //    //{
            //    //    GridEditableItem editItem = (GridEditableItem)e.Item;
            //    //    RadDropDownList comboTipo = (RadDropDownList)editItem.FindControl("rdTipo");
            //    //    if (comboTipo.SelectedValue.Equals("prod"))
            //    //    {
            //    //        RadDropDownList comboProducto = (RadDropDownList)editItem.FindControl("productoList");
            //    //        beneficio.producto_id = Int64.Parse(comboProducto.SelectedValue);
            //    //    }
            //    //    if (comboTipo.SelectedValue.Equals("prem"))
            //    //    {
            //    //        RadDropDownList comboPremio = (RadDropDownList)editItem.FindControl("premioList");
            //    //        beneficio.premio_id = Int64.Parse(comboPremio.SelectedValue);
            //    //    }
            //    //    // txt.Visible = true;
            //    //}


            //    //e.Item.OwnerTableView.ins
            //    //RadDropDownList comboTipo = (RadDropDownList)(((RadGrid)(sender)).Items..EditFormCell.FindControl("rdTipo");
            //    //if (comboTipo.SelectedValue.Equals("prod"))
            //    //{
            //    //    RadDropDownList comboProductos = (RadDropDownList)(((GridEditFormItem)((RadDropDownList)sender).NamingContainer)).EditFormCell.FindControl("productoList");
            //    //    beneficio.producto_id = Int64.Parse(comboProductos.SelectedValue);
            //    //}
            //    //else if (comboTipo.SelectedValue.Equals("prem"))
            //    //{
            //    //    RadDropDownList comboPremios = (RadDropDownList)(((GridEditFormItem)((RadDropDownList)sender).NamingContainer)).EditFormCell.FindControl("premioList");
            //    //    beneficio.premio_id = Int64.Parse(comboPremios.SelectedValue);
            //    //}
            //}

        }

        //protected void rgBeneficios_ItemCommand(object sender, GridCommandEventArgs e)
        //{
        //    foreach (GridColumn col in rgBeneficios.Columns)
        //    {
        //        if (col.ColumnType == "GridBoundColumn" && (col.UniqueName == "programaHide" || col.UniqueName == "premioHide"))
        //        {
        //            if (e.CommandName == RadGrid.InitInsertCommandName)
        //            {
        //                col.Visible = false;
        //            }
        //            else if (e.CommandName == RadGrid.EditCommandName)
        //            {
        //                col.Visible = false;
        //            }
        //        }
        //    }
        //}


    }
}