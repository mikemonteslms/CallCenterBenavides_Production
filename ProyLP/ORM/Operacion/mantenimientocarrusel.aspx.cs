using EntitiesModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ORMOperacion
{
    public partial class mantenimientocarrusel : System.Web.UI.Page
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
                Master.Submenu = "Carrusel";
            }
        }

        protected void rgCarrusel_InsertCommand(object sender, GridCommandEventArgs e)
        {
            var editableItem = ((GridEditableItem)e.Item);
            Session["programa_id_rcb"] = long.Parse(((RadComboBox)editableItem.FindControl("rcbPrograma")).SelectedValue);
        }

        protected void OACarrusel_Inserting(object sender, Telerik.OpenAccess.Web.OpenAccessLinqDataSourceInsertEventArgs e)
        {
            programa_carrusel carrusel = e.NewObject as programa_carrusel;
            carrusel.programa_id = (long)Session["programa_id_rcb"];
        }

        //protected void rgCarrusel_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        //{
        //    if ((e.Item is GridEditableItem) && (e.Item.IsInEditMode))
        //    {

        //        GridEditableItem editForm = (GridEditableItem)e.Item;
        //        editForm["programa_id"].Controls[0].Visible = false;
        //        RadComboBox combo = new RadComboBox();
        //        combo.ID = "rcbMenu";
        //        combo.DataTextField = "descripcion_larga";
        //        combo.DataValueField = "id";

        //        if (e.Item.ToString().Contains("Insert"))
        //        {
        //            string connectionString = WebConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;
        //            SqlDataSource sql = new SqlDataSource();
        //            sql.ID = "dsPrograma";
        //            sql.ConnectionString = connectionString;
        //            sql.SelectCommand = "select id, descripcion_larga from programa";

        //            DataView dv = (DataView)sql.Select(DataSourceSelectArguments.Empty);
        //            DataTable dt = new DataTable();
        //            combo.DataSource = dv;

        //            //DataView dv = CNegocio.csMenuNegocio.ConsultarMenu(0, Membership.GetUser().ProviderUserKey.ToString()).DefaultView;
        //            //dv.RowFilter = "fecha_baja is null";
        //            //combo.DataSource = dv;
        //        }
        //        else
        //        {
        //            combo.DataSource = CNegocio.csMenuNegocio.ConsultarMenu(0, Membership.GetUser().ProviderUserKey.ToString());
        //        }
        //        editForm["programa_id"].Controls.Add(combo);
        //    }
        //}

        //protected void OACarrusel_Inserting(object sender, Telerik.OpenAccess.Web.OpenAccessLinqDataSourceInsertEventArgs e)
        //{
        //    programa_carrusel programa_carrusel = e.NewObject as programa_carrusel;
        //    string id = programa_carrusel.programa_id.ToString();
        //}

        //protected void OACarrusel_Inserting(object sender, Telerik.OpenAccess.Web.OpenAccessLinqDataSourceInsertEventArgs e)
        //{
        //    using (EntitiesModel.EntitiesModel context = new EntitiesModel.EntitiesModel())
        //    {
        //        MembershipUser u = Membership.GetUser();
        //        programa_carrusel programa_carrusel = e.NewObject as programa_carrusel;
        //        if (programa_carrusel != null)
        //        {
        //            //pregunta.nombre = ((TextBox)DetailsViewPregunta.FindControl("nombrePregunta")).Text.ToString();
        //            //pregunta.orden = Convert.ToInt32(((TextBox)DetailsViewPregunta.FindControl("preguntaOrden")).Text.ToString());
        //            programa_carrusel.programa_id
        //            programa_carrusel.usuario_alta_id = (Guid)u.ProviderUserKey;
        //            //programa.status_id = 1;
        //            //programa.fecha_status = DateTime.Now;
        //            programa_carrusel.fecha_alta = DateTime.Now;
        //            context.SaveChanges();
        //        }
        //    }
        //}
    }
}