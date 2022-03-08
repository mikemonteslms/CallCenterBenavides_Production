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
    public partial class PromocionesM : System.Web.UI.Page
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
                    //Pruebas
                    //int CategoriaID = 0;
                    //int Seccion = 1;
                    //int Visita = 0;
                    ////if (Request.QueryString["Visita"] != null)
                    //    //Visita = Convert.ToInt32(Request.QueryString["Visita"]);
                    //if (Request.QueryString["ID"] != null)
                    //{
                    //    CategoriaID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    //    ddlPromociones.SelectedValue = Request.QueryString["ID"].ToString();
                    //}
                    //if (Request.QueryString["Seccion"] != null)
                    //    Seccion = Convert.ToInt32(Request.QueryString["Seccion"]);
                
                    //CargarCatalogo(ddlPromociones,Seccion, CategoriaID);
                    //if (ddlPromociones.Items.Contains(new ListItem("Seleccionar", "0")) && Visita == 0)
                    //    ddlPromociones.SelectedIndex = 0;
                    //else if (ddlPromociones.Items.Contains(new ListItem("Especiales para ti", "6")) && Visita == 0)
                    //    ddlPromociones.SelectedValue = "6";
                    //else
                    //    ddlPromociones.SelectedValue = CategoriaID.ToString();
                   

                    //LlenarPromociones();                    

                    //Produccion
                    CargarCatalogo(ddlPromociones);
                    if (Request.QueryString["ID"] != null)
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                        {
                            ddlPromociones.SelectedValue = Request.QueryString["ID"];
                        }
                    }
                    LlenarPromociones();
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
        //Pruebas
        protected void CargarCatalogo(DropDownList ControlCombo, int Seccion, int IdCategoria)
        {
            try
            {     
                //Pruebas
                //objDataset = objConsultaDatos.DatosCatalogoPromociones(Session["Usuario"].ToString(), Session["Peques"].ToString(),Seccion, IdCategoria);
                //Produccion
                objDataset = objConsultaDatos.DatosCatalogoPromociones(Session["Usuario"].ToString(), Session["Peques"].ToString(), IdCategoria);
                ControlCombo.Items.Clear();
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    //ControlCombo.Items.Add(new ListItem("-- Todas --", "00"));
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
        //Produccion
        protected void CargarCatalogo(DropDownList ControlCombo)
        {
            try
            {
                int CategoriaID = 0;
                if (!string.IsNullOrEmpty(ControlCombo.SelectedValue))
                    CategoriaID = Convert.ToInt32(ControlCombo.SelectedValue);
                if (Request.QueryString["ID"] != null)
                    CategoriaID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                objDataset = objConsultaDatos.DatosCatalogoPromociones(Session["Usuario"].ToString(), Session["Peques"].ToString(), CategoriaID);
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
                if (Request.QueryString["ID"] != null)
                {
                    if (Request.QueryString["ID"] == "0")
                        ddlPromociones.Items[0].Value = "0";
                }
                else
                {
                    if (Session["Cat"] != null)
                    {
                        ddlPromociones.Items[0].Value = "100";
                    }
                    else
                    {
                        if (Request.QueryString["ID"] != "100")
                        {
                            Session["Cat"] = null;
                            ddlPromociones.Items[0].Value = "00";
                        }
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
            if (Request.QueryString["PromoId"] != null)
                ds = cliente.ImagenesPromociones(ddlPromociones.SelectedValue, Session["Peques"].ToString(), Request.QueryString["PromoId"], Session["Usuario"].ToString());
            else
            {
                if (Request.QueryString["ID"] != null)
                {
                    if (Convert.ToInt32(Request.QueryString["ID"]) == 100)
                    {
                        ddlPromociones.Items[0].Value = "100";
                        ds = cliente.ImagenesPromociones("100", Session["Peques"].ToString(), "", Session["Usuario"].ToString());
                    }
                    else
                        ds = cliente.ImagenesPromociones(ddlPromociones.SelectedValue, Session["Peques"].ToString(), "", Session["Usuario"].ToString());
                }
                else
                    ds = cliente.ImagenesPromociones(ddlPromociones.SelectedValue, Session["Peques"].ToString(), "", Session["Usuario"].ToString());
            }           
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
            //Pruebas
            //Response.Redirect("Promociones.aspx?ID=" + ddlPromociones.SelectedValue + "&Seccion=" + Request.QueryString["Seccion"].ToString() + "&Visita=2")
            //Produccion
            Response.Redirect("Promociones.aspx?ID=" + ddlPromociones.SelectedValue);
        }        
    }
}