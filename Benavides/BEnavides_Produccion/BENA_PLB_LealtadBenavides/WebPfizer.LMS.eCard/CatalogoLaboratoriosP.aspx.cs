using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Negocio;

namespace WebPfizer.LMS.eCard
{

    public partial class CatalogoLaboratoriosP : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Acceso.aspx", true);
            }

            try
            {

                btnCloseImagenDetalle.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/btn-cerrar-hover.jpg'");
                btnCloseImagenDetalle.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/btn-cerrar.jpg'");

                DataTable ds = new DataTable();
          
                Clientes cs = new Clientes();

                ds = cs.ImagenesLaboratorios();             

                gvLaboratorios.DataSource = ds;              
                gvLaboratorios.DataBind();
            }
            catch
            {

            }

        }

        protected void gvLaboratorios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var col1 = e.Row.FindControl("imgCol1") as Image;
                var col2 = e.Row.FindControl("imgCol2") as Image;
                var col3 = e.Row.FindControl("imgCol3") as Image;
                var col4 = e.Row.FindControl("imgCol4") as Image;
                var col5 = e.Row.FindControl("imgCol5") as Image;

                var lbl1 = e.Row.FindControl("lblIDLabC1") as Label;
                var lbl2 = e.Row.FindControl("lblIDLabC2") as Label;
                var lbl3 = e.Row.FindControl("lblIDLabC3") as Label;
                var lbl4 = e.Row.FindControl("lblIDLabC4") as Label;
                var lbl5 = e.Row.FindControl("lblIDLabC5") as Label;

                DataTable ds = new DataTable();
               
                Clientes cs = new Clientes();

                ds = cs.ImagenesLaboratorios();

                col1.ImageUrl = ds.Rows[e.Row.RowIndex]["ImageUrlCol1"].ToString();
                col2.ImageUrl = ds.Rows[e.Row.RowIndex]["ImageUrlCol2"].ToString();
                col3.ImageUrl = ds.Rows[e.Row.RowIndex]["ImageUrlCol3"].ToString();
                col4.ImageUrl = ds.Rows[e.Row.RowIndex]["ImageUrlCol4"].ToString();
                col5.ImageUrl = ds.Rows[e.Row.RowIndex]["ImageUrlCol5"].ToString();

                lbl1.Text = ds.Rows[e.Row.RowIndex]["Cvo_Col1"].ToString();
                lbl2.Text = ds.Rows[e.Row.RowIndex]["Cvo_Col2"].ToString();
                lbl3.Text = ds.Rows[e.Row.RowIndex]["Cvo_Col3"].ToString();
                lbl4.Text = ds.Rows[e.Row.RowIndex]["Cvo_Col4"].ToString();
                lbl5.Text = ds.Rows[e.Row.RowIndex]["Cvo_Col5"].ToString();

                GridViewRow gvr = e.Row;
                LinkButton lb = gvr.FindControl("lnkSeleccion0") as LinkButton;
                lb.TabIndex = Convert.ToInt16(e.Row.RowIndex);
                lb = gvr.FindControl("lnkSeleccion1") as LinkButton;
                lb.TabIndex = Convert.ToInt16(e.Row.RowIndex);
                lb = gvr.FindControl("lnkSeleccion2") as LinkButton;
                lb.TabIndex = Convert.ToInt16(e.Row.RowIndex);
                lb = gvr.FindControl("lnkSeleccion3") as LinkButton;
                lb.TabIndex = Convert.ToInt16(e.Row.RowIndex);
                lb = gvr.FindControl("lnkSeleccion4") as LinkButton;
                lb.TabIndex = Convert.ToInt16(e.Row.RowIndex);                                                                    
            }
        }

        protected void gvLaboratorios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row = -1;
        
                if (e.CommandName == "Seleccion0")
                {                   

                    LinkButton Ib = (LinkButton)e.CommandSource;
                    row = Convert.ToInt32(Ib.TabIndex);
                    GridViewRow gvr = gvLaboratorios.Rows[row];
                    Label lblLaboratorio = gvr.FindControl("lblIDLabC1") as Label;
                    lblMensaje.Text = lblLaboratorio.Text;

                    DataSet ds = new DataSet();
                    Clientes cs = new Clientes();

                    ds = cs.ObtenerInfoLab(Convert.ToInt32(lblLaboratorio.Text));

                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        imgLab.ImageUrl = ds.Tables[0].Rows[0]["Laboratorio_ImagenURL"].ToString();
                        lblMensaje.Text = ds.Tables[0].Rows[0]["Laboratorio_strInfo"].ToString();
                        grdPromociones.DataSource = ds.Tables[1];
                        grdPromociones.DataBind();
                    }
                    else
                    {
                        //sin informacion
                    }

                    popImagenDetalle.Show();
                }
                if (e.CommandName == "Seleccion1")
                {
                    LinkButton Ib = (LinkButton)e.CommandSource;
                    row = Convert.ToInt32(Ib.TabIndex);
                    GridViewRow gvr = gvLaboratorios.Rows[row];
                    Label lblLaboratorio = gvr.FindControl("lblIDLabC2") as Label;
                    lblMensaje.Text = lblLaboratorio.Text;

                    DataSet ds = new DataSet();
                    Clientes cs = new Clientes();

                    ds = cs.ObtenerInfoLab(Convert.ToInt32(lblLaboratorio.Text));

                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        imgLab.ImageUrl = ds.Tables[0].Rows[0]["Laboratorio_ImagenURL"].ToString();
                        lblMensaje.Text = ds.Tables[0].Rows[0]["Laboratorio_strInfo"].ToString();
                        grdPromociones.DataSource = ds.Tables[1];
                        grdPromociones.DataBind();
                    }
                    else
                    {
                        //sin informacion
                    }

                    popImagenDetalle.Show();
                }
                if (e.CommandName == "Seleccion2")
                {
                    LinkButton Ib = (LinkButton)e.CommandSource;
                    row = Convert.ToInt32(Ib.TabIndex);
                    GridViewRow gvr = gvLaboratorios.Rows[row];
                    Label lblLaboratorio = gvr.FindControl("lblIDLabC3") as Label;
                    lblMensaje.Text = lblLaboratorio.Text;

                    DataSet ds = new DataSet();
                    Clientes cs = new Clientes();

                    ds = cs.ObtenerInfoLab(Convert.ToInt32(lblLaboratorio.Text));

                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        imgLab.ImageUrl = ds.Tables[0].Rows[0]["Laboratorio_ImagenURL"].ToString();
                        lblMensaje.Text = ds.Tables[0].Rows[0]["Laboratorio_strInfo"].ToString();
                        grdPromociones.DataSource = ds.Tables[1];
                        grdPromociones.DataBind();
                    }
                    else
                    {
                        //sin informacion
                    }

                    popImagenDetalle.Show();
                }
                if (e.CommandName == "Seleccion3")
                {
                    LinkButton Ib = (LinkButton)e.CommandSource;
                    row = Convert.ToInt32(Ib.TabIndex);
                    GridViewRow gvr = gvLaboratorios.Rows[row];
                    Label lblLaboratorio = gvr.FindControl("lblIDLabC4") as Label;
                    lblMensaje.Text = lblLaboratorio.Text;

                    DataSet ds = new DataSet();
                    Clientes cs = new Clientes();

                    ds = cs.ObtenerInfoLab(Convert.ToInt32(lblLaboratorio.Text));

                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        imgLab.ImageUrl = ds.Tables[0].Rows[0]["Laboratorio_ImagenURL"].ToString();
                        lblMensaje.Text = ds.Tables[0].Rows[0]["Laboratorio_strInfo"].ToString();
                        grdPromociones.DataSource = ds.Tables[1];
                        grdPromociones.DataBind();
                    }
                    else
                    {
                        //sin informacion
                    }

                    popImagenDetalle.Show();
                }
                if (e.CommandName == "Seleccion4")
                {
                    LinkButton Ib = (LinkButton)e.CommandSource;
                    row = Convert.ToInt32(Ib.TabIndex);
                    GridViewRow gvr = gvLaboratorios.Rows[row];
                    Label lblLaboratorio = gvr.FindControl("lblIDLabC5") as Label;
                    lblMensaje.Text = lblLaboratorio.Text;

                    DataSet ds = new DataSet();
                    Clientes cs = new Clientes();

                    ds = cs.ObtenerInfoLab(Convert.ToInt32(lblLaboratorio.Text));

                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        imgLab.ImageUrl = ds.Tables[0].Rows[0]["Laboratorio_ImagenURL"].ToString();
                        lblMensaje.Text = ds.Tables[0].Rows[0]["Laboratorio_strInfo"].ToString();
                        grdPromociones.DataSource = ds.Tables[1];
                        grdPromociones.DataBind();
                    }
                    else
                    {
                        //sin informacion
                    }

                    popImagenDetalle.Show();
                }
            }
            catch
            {
 
            }
        }

        protected void btnMens_Click(object sender, EventArgs e)
        {
            string prueba = "Prueba de pop up sin que se cierre";
            lblMensaje.Text = prueba;
            Mensajes("Resultado");
            popImagenDetalle.Show();
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void btnCloseImagenDetalle_Click(object sender, ImageClickEventArgs e)
        {
            popImagenDetalle.Hide();
        }

        protected void btnCerrarExitoso_Click(object sender, ImageClickEventArgs e)
        {
            popImagenDetalle.Hide();
        }

        
    }
}