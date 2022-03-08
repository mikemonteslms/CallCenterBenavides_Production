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
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace Portal_Benavides
{
    public partial class ReportesBenavidesBuscaTarjeta : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();

        ReportesNeg negocio = new ReportesNeg();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioCC"] == null)
            {
                Response.Redirect("AccesoRep.aspx", true);
            }
            if (!IsPostBack)
            {
                CargarCatalogoAno(DateTime.Today.Year, 2014, ddlAño);
                CargarCatalogoMes(01, 12, ddlMes);
                ddlAño.SelectedValue = "2015";
                ddlMes.SelectedValue = "01";
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        //CARGA AÑO
        protected void CargarCatalogoAno(int final, int inicial, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                //ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));

                for (int i = final; i >= inicial; i--)
                {
                    ListItem Item = new ListItem();
                    Item.Value = i.ToString();
                    Item.Text = i.ToString();
                    ControlCombo.Items.Add(Item);
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }
        //CARGA MES
        protected void CargarCatalogoMes(int inicial, int final, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                //ControlCombo.Items.Add(new ListItem("--Selecciona--", "00"));

                ListItem Item1 = new ListItem();
                ListItem Item2 = new ListItem();
                ListItem Item3 = new ListItem();
                ListItem Item4 = new ListItem();
                ListItem Item5 = new ListItem();
                ListItem Item6 = new ListItem();
                ListItem Item7 = new ListItem();
                ListItem Item8 = new ListItem();
                ListItem Item9 = new ListItem();
                ListItem Item10 = new ListItem();
                ListItem Item11 = new ListItem();
                ListItem Item12 = new ListItem();

                Item1.Value = "01";
                Item1.Text = "ENERO";
                ControlCombo.Items.Add(Item1);
                Item2.Value = "02";
                Item2.Text = "FEBRERO";
                ControlCombo.Items.Add(Item2);
                Item3.Value = "03";
                Item3.Text = "MARZO";
                ControlCombo.Items.Add(Item3);
                Item4.Value = "04";
                Item4.Text = "ABRIL";
                ControlCombo.Items.Add(Item4);
                Item5.Value = "05";
                Item5.Text = "MAYO";
                ControlCombo.Items.Add(Item5);
                Item6.Value = "06";
                Item6.Text = "JUNIO";
                ControlCombo.Items.Add(Item6);
                Item7.Value = "07";
                Item7.Text = "JULIO";
                ControlCombo.Items.Add(Item7);
                Item8.Value = "08";
                Item8.Text = "AGOSTO";
                ControlCombo.Items.Add(Item8);
                Item9.Value = "09";
                Item9.Text = "SEPTIEMBRE";
                ControlCombo.Items.Add(Item9);
                Item10.Value = "10";
                Item10.Text = "OCTUBRE";
                ControlCombo.Items.Add(Item10);
                Item11.Value = "11";
                Item11.Text = "NOVIEMBRE";
                ControlCombo.Items.Add(Item11);
                Item12.Value = "12";
                Item12.Text = "DICIEMBRE";
                ControlCombo.Items.Add(Item12);
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        //BOTON REGRESAR
        protected void SaldoMovRegresar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("IndexRep.aspx");
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        //BOTON BUSCAR
        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string tarjeta = txtTarjeta.Text.Trim();
                string sucursal = txtSucursal.Text.Trim();
                string fecha = ddlAño.SelectedValue.ToString() + ddlMes.SelectedValue.ToString();

                if (tarjeta == "" || sucursal == "")
                {
                    Mensajes("Debes capturar los últimos 4 dígitos de la Tarjeta y el número de Sucursal");
                }
                else
                {
                    lblTituloGrid.Text = "Coincidencias de Tarjeta: ";

                    CargaDatosGrid(tarjeta, sucursal, fecha);
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        //CARGAR DATOS GRIDVIEW
        protected void CargaDatosGrid(string tarjeta, string parametro1, string parametro2)
        {
            try
            {
                //objDataset = cliente.DatosTransaccionesReportes(tarjeta, parametro1, parametro2);
                objDataset = negocio.DatosReporte("sp_ObtieneTarjeta", tarjeta, parametro1, parametro2);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    grvDatos.DataSource = objDataset;
                    grvDatos.DataBind();
                }
                else
                {
                    grvDatos.DataSource = null;
                    grvDatos.DataBind();
                    lblTituloGrid.Text = "No se encontraron coincidencias";
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }






    }

}
