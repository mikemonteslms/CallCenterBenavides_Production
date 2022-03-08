using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;

namespace ORMOperacion
{
    public partial class comentarios : System.Web.UI.Page
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
                Master.Menu = "Llamadas";
                Master.Submenu = "Administrar Blog";

                cargaPrograma();
            }
        }

        private void cargaPrograma()
        {
            csCatalogo cat = new csCatalogo();
            cat.Catalogo = "programa";
            ddlPrograma.DataSource = cat.Consulta().DefaultView;
            ddlPrograma.DataBind();
            ddlPrograma.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        private void cargaStatus()
        {
            csCatalogo cat = new csCatalogo();
            cat.Catalogo = "status";
            cat.Country_code = ddlPrograma.SelectedItem.Value;
            ddlStatus.DataSource = cat.Consulta().DefaultView;
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("TODOS", "0"));
        }

        protected void ddlPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaStatus();
            if (ddlPrograma.SelectedIndex > 0)
            {
                gvComentarios.Visible = true;
                cargaGridView();
            }
            else
            {
                gvComentarios.DataSource = null;
                gvComentarios.DataBind();
                ddlStatus.DataSource = null;
                ddlStatus.DataBind();
                ddlStatus.Items.Clear();
            }
        }

        protected void lnkActualiza_Command(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            csDataBase query = new csDataBase();
            query.Query = "sp_actualiza_blog";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@id", id));
            query.EsStoreProcedure = true;
            query.Parametros = param;
            query.acutualizaDatos();
            cargaGridView();
        }

        protected void cargaGridView()
        {
            csDataBase query = new csDataBase();
            query.Query = "sp_consulta_blog";
            query.EsStoreProcedure = true;
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@programa", ddlPrograma.SelectedItem.Value));
            param.Add(new SqlParameter("@statusblog", ddlStatus.SelectedItem.Text));
            query.Parametros = param;
            DataTable dtDatos = query.dtConsulta();
            gvComentarios.DataSource = dtDatos;
            gvComentarios.DataBind();
            if (gvComentarios.Items.Count == 0)
            {
                Master.MuestraMensaje("No se encontraron comentarios.");
                gvComentarios.DataSource = new[]
                {
                new{
                    ID = string.Empty,
                    nombre_completo = string.Empty,
                    mensaje = string.Empty,
                    fecha_alta=string.Empty,
                    descripcion =string.Empty
                    }
                };
                gvComentarios.DataBind();
            }
        }

        //protected void gvComentarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvComentarios.PageIndex = e.NewPageIndex;
        //    cargaGridView();
        //}

        //protected void gvComentarios_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.Header)
        //        {
        //            // Obtiene el participante del programa
        //            csDataBase query = new csDataBase();
        //            query.Query = "Obtiene_Participante_Programa";
        //            query.EsStoreProcedure = true;
        //            List<SqlParameter> param = new List<SqlParameter>();
        //            param.Add(new SqlParameter("@ClavePrograma", ddlPrograma.SelectedItem.Value));
        //            query.Parametros = param;
        //            DataTable dtRazonSocial = query.dtConsulta();
        //            if (dtRazonSocial != null)
        //            {
        //                if (dtRazonSocial.Rows.Count > 0)
        //                {
        //                    Label lblNombre2 = (Label)e.Row.FindControl("lblNombre2");
        //                    HiddenField hidParticipante_id = (HiddenField)e.Row.FindControl("hidParticipante_id");
        //                    hidParticipante_id.Value = dtRazonSocial.Rows[0].ItemArray[0].ToString();
        //                    lblNombre2.Text = dtRazonSocial.Rows[0].ItemArray[2].ToString();
        //                    ((LinkButton)e.Row.FindControl("lnkAgregar")).CommandArgument = hidParticipante_id.Value;
        //                }
        //            }
        //        }
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            Label lblID = (Label)e.Row.FindControl("lblID");
        //            LinkButton lnkActualiza = (LinkButton)e.Row.FindControl("lnkActualiza");
        //            if (lblID.Text == "")
        //                lnkActualiza.Visible = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //protected void gvComentarios_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName.Equals("Agregar"))
        //    {
        //        try
        //        {
        //            //String participante_id = ((HiddenField)gvComentarios.HeaderRow.FindControl("hidParticipante_id")).Value;
        //            string participante_id = e.CommandArgument.ToString();
        //            string mensaje = "";
        //            foreach (GridHeaderItem headerItem in gvComentarios.MasterTableView.GetItems(GridItemType.Header))
        //            {
        //                mensaje = ((TextBox)headerItem["txtMensajeNuevo"].Controls[0]).Text; // Get the header checkbox
        //            }

        //            //String mensaje = ((TextBox)gvComentarios.HeaderRow.FindControl("txtMensajeNuevo")).Text;
        //            csDataBase query = new csDataBase();
        //            query.Query = "sp_agrega_blog";
        //            List<SqlParameter> param = new List<SqlParameter>();
        //            param.Add(new SqlParameter("@participante_id", participante_id));
        //            param.Add(new SqlParameter("@mensaje", mensaje));
        //            query.EsStoreProcedure = true;
        //            query.Parametros = param;
        //            query.acutualizaDatos();
        //            cargaGridView();
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //}

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaGridView();
        }

        protected void gvComentarios_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Agregar"))
            {
                try
                {
                    //String participante_id = ((HiddenField)gvComentarios.HeaderRow.FindControl("hidParticipante_id")).Value;
                    string participante_id = e.CommandArgument.ToString();
                    string mensaje = "";
                    foreach (GridHeaderItem headerItem in gvComentarios.MasterTableView.GetItems(GridItemType.Header))
                    {
                        mensaje = ((TextBox)headerItem.FindControl("txtMensajeNuevo")).Text; // Get the header checkbox
                    }

                    //String mensaje = ((TextBox)gvComentarios.HeaderRow.FindControl("txtMensajeNuevo")).Text;
                    csDataBase query = new csDataBase();
                    query.Query = "sp_agrega_blog";
                    List<SqlParameter> param = new List<SqlParameter>();
                    param.Add(new SqlParameter("@participante_id", participante_id));
                    param.Add(new SqlParameter("@mensaje", mensaje));
                    query.EsStoreProcedure = true;
                    query.Parametros = param;
                    query.acutualizaDatos();
                    cargaGridView();
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void gvComentarios_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Header)
                {
                    // Obtiene el participante del programa
                    csDataBase query = new csDataBase();
                    query.Query = "Obtiene_Participante_Programa";
                    query.EsStoreProcedure = true;
                    List<SqlParameter> param = new List<SqlParameter>();
                    param.Add(new SqlParameter("@ClavePrograma", ddlPrograma.SelectedItem.Value));
                    query.Parametros = param;
                    DataTable dtRazonSocial = query.dtConsulta();
                    if (dtRazonSocial != null)
                    {
                        if (dtRazonSocial.Rows.Count > 0)
                        {
                            Label lblNombre2 = (Label)e.Item.FindControl("lblNombre2");
                            HiddenField hidParticipante_id = (HiddenField)e.Item.FindControl("hidParticipante_id");
                            hidParticipante_id.Value = dtRazonSocial.Rows[0].ItemArray[0].ToString();
                            lblNombre2.Text = dtRazonSocial.Rows[0].ItemArray[2].ToString();
                            ((LinkButton)e.Item.FindControl("lnkAgregar")).CommandArgument = hidParticipante_id.Value;
                        }
                    }
                }
                if (e.Item.ItemType == GridItemType.Item)
                {
                    Label lblID = (Label)e.Item.FindControl("lblID");
                    LinkButton lnkActualiza = (LinkButton)e.Item.FindControl("lnkActualiza");
                    if (lblID.Text == "")
                        lnkActualiza.Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void gvComentarios_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            csDataBase query = new csDataBase();
            query.Query = "sp_consulta_blog";
            query.EsStoreProcedure = true;
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@programa", ddlPrograma.SelectedItem.Value));
            param.Add(new SqlParameter("@statusblog", ddlStatus.SelectedItem.Text));
            query.Parametros = param;
            DataTable dtDatos = query.dtConsulta();
            gvComentarios.DataSource = dtDatos;
            //gvComentarios.DataBind();
            if (gvComentarios.Items.Count == 0)
            {
                Master.MuestraMensaje("No se encontraron comentarios.");
                gvComentarios.DataSource = new[]
                {
                new{
                    ID = string.Empty,
                    nombre_completo = string.Empty,
                    mensaje = string.Empty,
                    fecha_alta=string.Empty,
                    descripcion =string.Empty
                    }
                };
                //gvComentarios.DataBind();
            }
        }
    }
}