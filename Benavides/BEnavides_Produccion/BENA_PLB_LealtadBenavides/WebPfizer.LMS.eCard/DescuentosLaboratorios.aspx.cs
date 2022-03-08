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
    public partial class DescuentosLaboratorios : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Catalogos objConsultaDatos = new Catalogos();
        Clientes cliente = new Clientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Acceso.aspx", true);
            }

            try
            {
                if (!IsPostBack)
                {
                    DataSet ds = new DataSet();
                    CargarCatalogo("estado", ddEstado, "", "");
                }

            }
            catch
            {
 
            }
        }

        protected void CargarCatalogo(string @Catalogo, DropDownList ControlCombo, string filtro1, string filtro2)
        {
            try
            {
                objDataset = objConsultaDatos.DatosCatalogoDescuentoLab(@Catalogo, filtro1, filtro2);
                ControlCombo.Items.Clear();
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));
                    for (int i = 0; i <= objDataset.Tables[0].Rows.Count - 1; i++)
                    {
                        ListItem Item = new ListItem();
                        Item.Value = objDataset.Tables[0].Rows[i][0].ToString();
                        Item.Text = objDataset.Tables[0].Rows[i][1].ToString();
                        ControlCombo.Items.Add(Item);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void CargarDatosGrid(string @Catalogo, DropDownList ControlCombo, string filtro1, string filtro2, string filtro3 = "")
        {
            try
            {
                objDataset = objConsultaDatos.DatosCatalogoDescuentoLab(@Catalogo, filtro1, filtro2, filtro3);

                if (objDataset.Tables.Count > 0)
                {
                    grdPromociones.DataSource = objDataset.Tables[0];
                    grdPromociones.DataBind();
                    grdPromociones.Visible = true;
                }
                else
                {
                    grdPromociones.DataSource = null;
                    grdPromociones.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void ddEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddEstado.SelectedValue == "00")
                {
                    ddCiudad.Enabled = false;
                    ddCiudad.SelectedIndex = 0;
                    ddLaboratorio.SelectedIndex = 0;
                    ddLaboratorio.Enabled = false;
                    grdPromociones.DataSource = null;
                    grdPromociones.Visible = false;
                }
                else
                {
                    CargarCatalogo("Municipio", ddCiudad, ddEstado.SelectedItem.Text.ToString(), "");
                    ddCiudad.Enabled = true;
                    ddLaboratorio.SelectedIndex = 0;
                    ddLaboratorio.Enabled = false;
                    grdPromociones.DataSource = null;
                    grdPromociones.Visible = false;
                }
            }
            catch
            { }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void ddCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddCiudad.SelectedValue == "00")
                {
                    ddLaboratorio.Enabled = false;
                    ddLaboratorio.SelectedIndex = 0;
                    grdPromociones.DataSource = null;
                    grdPromociones.Visible = false;
                }
                else
                {
                    CargarCatalogo("Laboratorio", ddLaboratorio, ddEstado.SelectedValue.ToString(), ddCiudad.SelectedValue.ToString());                    
                    ddLaboratorio.Enabled = true;
                    grdPromociones.DataSource = null;
                    grdPromociones.Visible = false;
                }
            }
            catch
            { }
        }

        protected void ddLaboratorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddLaboratorio.SelectedValue == "00")
                {
                    grdPromociones.DataSource = null;
                    grdPromociones.Visible = false;

                }
                else
                {
                    CargarDatosGrid("Descuentos", ddLaboratorio, ddEstado.SelectedValue.ToString(), ddCiudad.SelectedValue.ToString(),ddLaboratorio.SelectedValue);                    
                }
            }
            catch
            { 
            }
        }
    }
}