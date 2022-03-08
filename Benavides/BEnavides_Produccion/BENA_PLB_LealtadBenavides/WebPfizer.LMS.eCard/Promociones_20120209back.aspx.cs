using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;
using Datos;
using System.Text;
using System.Globalization;

namespace WebPfizer.LMS.eCard
{
    public partial class Promociones : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Catalogos objConsultaDatos = new Catalogos();
        Clientes cliente = new Clientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Acceso.aspx", true);
                }

                if (!IsPostBack)
                {
                    CargarCatalogo(ddlPromociones);
                    if (Request.QueryString["ID"] != null)
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                        {
                            ddlPromociones.SelectedValue = Request.QueryString["ID"];
                            
                        }
                    }
                    LlenarPromociones();
                    //ddlPromociones_SelectedIndexChanged(ddlPromociones, new EventArgs());
                }               
            }
            catch
            { 
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void CargarCatalogo(DropDownList ControlCombo)
        {
            try
            {
                if (Session["Usuario"] != null)
                    objDataset = objConsultaDatos.DatosCatalogoPromociones(Session["Usuario"].ToString());
                else
                    objDataset = objConsultaDatos.DatosCatalogoPromociones();
                ControlCombo.Items.Clear();
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    ControlCombo.Items.Add(new ListItem("-- Todas --", "00"));
                    for (int i = 0; i <= objDataset.Tables[0].Rows.Count - 1; i++)
                    {
                        ListItem Item = new ListItem();
                        Item.Value = objDataset.Tables[0].Rows[i]["Especialistas_intID"].ToString();
                        Item.Text = objDataset.Tables[0].Rows[i]["Especialistas_strDescripcion"].ToString();
                        ControlCombo.Items.Add(Item);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }
        public void LlenarPromociones()
        {
            DataSet ds = new DataSet();
            string Tarjeta = "";
            if (Session["Usuario"] != null)
                Tarjeta = Session["Usuario"].ToString();
            if(Request.QueryString["PromoId"] != null)
                ds = cliente.ImagenesPromociones(ddlPromociones.SelectedValue,Request.QueryString["PromoId"],Tarjeta);
            else
                ds = cliente.ImagenesPromociones(ddlPromociones.SelectedValue,"",Tarjeta);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                grdImagenes.DataSource = ds.Tables[0];
                grdImagenes.DataBind();
                grdImagenes.Visible = true;
                //grdImagenes. = grdImagenes.Rows.Count - 1;
            }
            else
            {
                grdImagenes.DataSource = null;
                grdImagenes.Visible = false;
                Mensajes("No hay promociones para la categoría seleccionada");
                Response.AddHeader("REFRESH", "0;URL=Promociones.aspx");
            }
            
        }
        protected void ddlPromociones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("Promociones.aspx?ID=" + ddlPromociones.SelectedValue);           
        }
    }
}