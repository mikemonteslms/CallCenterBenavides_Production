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
using System.Web.UI.HtmlControls;

namespace WebPfizer.LMS.eCard
{
    public partial class ClubPequesRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Acceso.aspx", true);
                }
                HtmlTable tblMisBeneficios = (HtmlTable)Master.FindControl("pequesfondo");

                tblMisBeneficios.BgColor = "#D7D7D7";

                if (!IsPostBack)
                {

                    CargarCatalogoAno(DateTime.Now.AddYears(3).Year, DateTime.Now.Year, ddlAnoPeque);
                    ddlMesPeque.Items.Add(new ListItem("Mes", "00"));
                    //CargarCatalogoMes(1, 12, ddlMesPeque);
                    ddlDiaPeque.Items.Add(new ListItem("Día", "00"));

                    CargarCatalogoAno(DateTime.Today.Year, DateTime.Now.AddYears(-5).Year, ddlAnoFNP1);
                    //CargarCatalogoMes(1, 12, ddlMesFNP1);
                    ddlMesFNP1.Items.Add(new ListItem("Mes", "00"));
                    ddlDiaFNP1.Items.Add(new ListItem("Día", "00"));

                    CargarCatalogoAno(DateTime.Today.Year, DateTime.Now.AddYears(-5).Year, ddlAnoFNP2);
                    //CargarCatalogoMes(1, 12, ddlMesFNP2);
                    ddlMesFNP2.Items.Add(new ListItem("Mes", "00"));
                    ddlDiaFNP2.Items.Add(new ListItem("Día", "00"));

                    CargarCatalogoAno(DateTime.Today.Year, DateTime.Now.AddYears(-5).Year, ddlAnoFNP3);
                    //CargarCatalogoMes(1, 12, ddlMesFNP3);
                    ddlMesFNP3.Items.Add(new ListItem("Mes", "00"));
                    ddlDiaFNP3.Items.Add(new ListItem("Día", "00"));

                    CargarCatalogoAno(DateTime.Today.Year, DateTime.Now.AddYears(-5).Year, ddlAnoFNP4);
                    //CargarCatalogoMes(1, 12, ddlMesFNP4);
                    ddlMesFNP4.Items.Add(new ListItem("Mes", "00"));
                    ddlDiaFNP4.Items.Add(new ListItem("Día", "00"));
                    CargarDatos(Session["Usuario"].ToString());
                }                                
            }
            catch
            { }
        }

        private void CargarDatos(string Tarjeta)
        {
            Clientes objCliente = new Clientes();

            bool recibeInfo = objCliente.GetRecibeInfo(Tarjeta);
            DataSet dtsDatos = objCliente.GetDatosEncuestaPeques(Tarjeta);

            if (dtsDatos.Tables.Count > 0)
            {
                if (dtsDatos.Tables[0].Rows.Count > 0)
                {
                    rblTienesHijos.SelectedValue = dtsDatos.Tables[0].Rows[0]["PequesB_intTienesHijos"].ToString();
                    rblEmbarazo.SelectedValue = dtsDatos.Tables[0].Rows[0]["PequesB_intCuidado"].ToString();

                    rblTienesHijos_SelectedIndexChanged(rblTienesHijos, new EventArgs());

                    ddlCuantosHijos.SelectedValue = dtsDatos.Tables[0].Rows[0]["PequesB_intCuantosHijos"].ToString();

                    if (Convert.ToDateTime(dtsDatos.Tables[0].Rows[0]["PequesB_dateNacimeintoBebe"]) < DateTime.Now)
                    {
                        ddlAnoPeque.SelectedIndex = 0;
                        ddlMesPeque.SelectedIndex = 0;
                        ddlDiaPeque.SelectedIndex = 0;
                    }
                    else
                    {

                        ddlAnoPeque.SelectedValue = Convert.ToDateTime(dtsDatos.Tables[0].Rows[0]["PequesB_dateNacimeintoBebe"]).Year.ToString();
                        ddlAnoPeque_SelectedIndexChanged(ddlAnoPeque, new EventArgs());

                        ddlMesPeque.SelectedValue = (Convert.ToDateTime(dtsDatos.Tables[0].Rows[0]["PequesB_dateNacimeintoBebe"]).Month.ToString().Length == 1) ? "0" + Convert.ToDateTime(dtsDatos.Tables[0].Rows[0]["PequesB_dateNacimeintoBebe"]).Month.ToString() : Convert.ToDateTime(dtsDatos.Tables[0].Rows[0]["PequesB_dateNacimeintoBebe"]).Month.ToString();
                        ddlMesPeque_SelectedIndexChanged(ddlMesPeque, new EventArgs());

                        ddlDiaPeque.SelectedValue = (Convert.ToDateTime(dtsDatos.Tables[0].Rows[0]["PequesB_dateNacimeintoBebe"]).Day.ToString().Length == 1) ? "0" + Convert.ToDateTime(dtsDatos.Tables[0].Rows[0]["PequesB_dateNacimeintoBebe"]).Day.ToString() : Convert.ToDateTime(dtsDatos.Tables[0].Rows[0]["PequesB_dateNacimeintoBebe"]).Day.ToString();
                    }

                    ddlCuantosHijos_SelectedIndexChanged(ddlCuantosHijos, new EventArgs());

                    chkRecibirInfo.Checked = recibeInfo;
                    if (dtsDatos.Tables[1].Rows.Count > 0)
                    {
                        int i = 1;
                        foreach (DataRow fila in dtsDatos.Tables[1].Rows)
                        {                            
                            LlenarDatosHijos(fila, i);
                            i++;
                        }
                    }
                }
            }            
        }

        private void LlenarDatosHijos(DataRow fila, int Numero)
        {
            ((TextBox)tablaH.FindControl("txtNomH" + Numero.ToString())).Text = fila["PequesBDetalle_strNombreHijo"].ToString();
            ((DropDownList)tablaH.FindControl("ddlAnoFNP" + Numero.ToString())).SelectedValue = Convert.ToDateTime(fila["PequesBDetalle_dateFechaNacimeinto"]).Year.ToString();
            switch (Numero)
            {
                case 1:
                    ddlAnoFNP1_SelectedIndexChanged(ddlAnoFNP1, new EventArgs());
                    break;
                case 2:
                    ddlAnoFNP2_SelectedIndexChanged(ddlAnoFNP2, new EventArgs());
                    break;
                case 3:
                    ddlAnoFNP3_SelectedIndexChanged(ddlAnoFNP3, new EventArgs());
                    break;
                case 4:
                    ddlAnoFNP4_SelectedIndexChanged(ddlAnoFNP4, new EventArgs());
                    break;
            }
            ((DropDownList)tablaH.FindControl("ddlMesFNP" + Numero.ToString())).SelectedValue = (Convert.ToDateTime(fila["PequesBDetalle_dateFechaNacimeinto"]).Month.ToString().Length == 1) ? "0" + Convert.ToDateTime(fila["PequesBDetalle_dateFechaNacimeinto"]).Month.ToString() : Convert.ToDateTime(fila["PequesBDetalle_dateFechaNacimeinto"]).Month.ToString();
            switch (Numero)
            {
                case 1:
                    ddlMesFNP1_SelectedIndexChanged(ddlMesFNP1, new EventArgs());
                    break;
                case 2:
                    ddlMesFNP2_SelectedIndexChanged(ddlMesFNP2, new EventArgs());
                    break;
                case 3:
                    ddlMesFNP3_SelectedIndexChanged(ddlMesFNP3, new EventArgs());
                    break;
                case 4:
                    ddlMesFNP4_SelectedIndexChanged(ddlMesFNP4, new EventArgs());
                    break;
            }
            ((DropDownList)tablaH.FindControl("ddlDiaFNP" + Numero.ToString())).SelectedValue = (Convert.ToDateTime(fila["PequesBDetalle_dateFechaNacimeinto"]).Day.ToString().Length == 1) ? "0" + Convert.ToDateTime(fila["PequesBDetalle_dateFechaNacimeinto"]).Day.ToString() : Convert.ToDateTime(fila["PequesBDetalle_dateFechaNacimeinto"]).Day.ToString();

            ((RadioButtonList)tablaH.FindControl("rdoGeneroP" + Numero.ToString())).SelectedValue = fila["PequesBDetalle_intSexo"].ToString();
            ((HiddenField)tablaH.FindControl("hdnHijo" + Numero.ToString())).Value = fila["PequesBDetalle_intCvo"].ToString();
        }
        

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("Index.aspx");
            }
            catch
            {
 
            }
        }

        protected void CargarCatalogoAno(int final, int inicial, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                ControlCombo.Items.Add(new ListItem("Año", "1900"));

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

        protected void CargarCatalogoDia(int inicial, int final, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                ControlCombo.Items.Add(new ListItem("Día", "00"));


                for (int i = inicial; i <= final; i++)
                {
                    ListItem Item = new ListItem();

                    if (i.ToString().Length == 1)
                    {
                        Item.Value = "0" + i.ToString();
                        Item.Text = "0" + i.ToString();
                    }
                    else
                    {
                        Item.Value = i.ToString();
                        Item.Text = i.ToString();
                    }
                    ControlCombo.Items.Add(Item);
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
        protected void CargarCatalogoMes(int inicial, int final, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                ControlCombo.Items.Add(new ListItem("Mes", "00"));

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
                Item1.Text = "Enero";
                ControlCombo.Items.Add(Item1);
                Item2.Value = "02";
                Item2.Text = "Febrero";
                ControlCombo.Items.Add(Item2);
                Item3.Value = "03";
                Item3.Text = "Marzo";
                ControlCombo.Items.Add(Item3);
                Item4.Value = "04";
                Item4.Text = "Abril";
                ControlCombo.Items.Add(Item4);
                Item5.Value = "05";
                Item5.Text = "Mayo";
                ControlCombo.Items.Add(Item5);
                Item6.Value = "06";
                Item6.Text = "Junio";
                ControlCombo.Items.Add(Item6);
                Item7.Value = "07";
                Item7.Text = "Julio";
                ControlCombo.Items.Add(Item7);
                Item8.Value = "08";
                Item8.Text = "Agosto";
                ControlCombo.Items.Add(Item8);
                Item9.Value = "09";
                Item9.Text = "Septiembre";
                ControlCombo.Items.Add(Item9);
                Item10.Value = "10";
                Item10.Text = "Octubre";
                ControlCombo.Items.Add(Item10);
                Item11.Value = "11";
                Item11.Text = "Noviembre";
                ControlCombo.Items.Add(Item11);
                Item12.Value = "12";
                Item12.Text = "Diciembre";
                ControlCombo.Items.Add(Item12);
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void ddlCuantosHijos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCuantosHijos.SelectedValue == "0")
                {
                    tablaH.Visible = false;
                    txtNomH1.Visible = false;
                    ddlDiaFNP1.Visible = false;
                    ddlMesFNP1.Visible = false;
                    ddlAnoFNP1.Visible = false;
                    rdoGeneroP1.Visible = false;

                    txtNomH2.Visible = false;
                    ddlDiaFNP2.Visible = false;
                    ddlMesFNP2.Visible = false;
                    ddlAnoFNP2.Visible = false;
                    rdoGeneroP2.Visible = false;

                    txtNomH3.Visible = false;
                    ddlDiaFNP3.Visible = false;
                    ddlMesFNP3.Visible = false;
                    ddlAnoFNP3.Visible = false;
                    rdoGeneroP3.Visible = false;

                    txtNomH4.Visible = false;
                    ddlDiaFNP4.Visible = false;
                    ddlMesFNP4.Visible = false;
                    ddlAnoFNP4.Visible = false;
                    rdoGeneroP4.Visible = false;


                }
                else
                {
                    if (ddlCuantosHijos.SelectedValue == "1")
                    {
                        tablaH.Visible = true;
                        txtNomH1.Visible = true;
                        ddlDiaFNP1.Visible = true;
                        ddlMesFNP1.Visible = true;
                        ddlAnoFNP1.Visible = true;
                        rdoGeneroP1.Visible = true;

                        txtNomH2.Visible = false;                        
                        ddlDiaFNP2.Visible = false;                        
                        ddlMesFNP2.Visible = false;                        
                        ddlAnoFNP2.Visible = false;                        
                        rdoGeneroP2.Visible = false;
                        txtNomH2.Text = "";
                        ddlDiaFNP2.SelectedIndex = 0;
                        ddlMesFNP2.SelectedIndex = 0;
                        ddlAnoFNP2.SelectedIndex = 0;

                        txtNomH3.Visible = false;
                        ddlDiaFNP3.Visible = false;
                        ddlMesFNP3.Visible = false;
                        ddlAnoFNP3.Visible = false;
                        rdoGeneroP3.Visible = false;
                        txtNomH3.Text = "";
                        ddlDiaFNP3.SelectedIndex = 0;
                        ddlMesFNP3.SelectedIndex = 0;
                        ddlAnoFNP3.SelectedIndex = 0;

                        txtNomH4.Visible = false;
                        ddlDiaFNP4.Visible = false;
                        ddlMesFNP4.Visible = false;
                        ddlAnoFNP4.Visible = false;
                        rdoGeneroP4.Visible = false;
                        txtNomH4.Text = "";
                        ddlDiaFNP4.SelectedIndex = 0;
                        ddlMesFNP4.SelectedIndex = 0;
                        ddlAnoFNP4.SelectedIndex = 0;


                    }
                    else
                    {
                        if (ddlCuantosHijos.SelectedValue == "2")
                        {
                            tablaH.Visible = true;
                            txtNomH1.Visible = true;
                            ddlDiaFNP1.Visible = true;
                            ddlMesFNP1.Visible = true;
                            ddlAnoFNP1.Visible = true;
                            rdoGeneroP1.Visible = true;

                            txtNomH2.Visible = true;
                            ddlDiaFNP2.Visible = true;
                            ddlMesFNP2.Visible = true;
                            ddlAnoFNP2.Visible = true;
                            rdoGeneroP2.Visible = true;

                            txtNomH3.Visible = false;
                            ddlDiaFNP3.Visible = false;
                            ddlMesFNP3.Visible = false;
                            ddlAnoFNP3.Visible = false;
                            rdoGeneroP3.Visible = false;
                            txtNomH3.Text = "";
                            ddlDiaFNP3.SelectedIndex = 0;
                            ddlMesFNP3.SelectedIndex = 0;
                            ddlAnoFNP3.SelectedIndex = 0;

                            txtNomH4.Visible = false;
                            ddlDiaFNP4.Visible = false;
                            ddlMesFNP4.Visible = false;
                            ddlAnoFNP4.Visible = false;
                            rdoGeneroP4.Visible = false;
                            txtNomH4.Text = "";
                            ddlDiaFNP4.SelectedIndex = 0;
                            ddlMesFNP4.SelectedIndex = 0;
                            ddlAnoFNP4.SelectedIndex = 0;
                        }
                        else
                        {
                            if (ddlCuantosHijos.SelectedValue == "3")
                            {
                                tablaH.Visible = true;
                                txtNomH1.Visible = true;
                                ddlDiaFNP1.Visible = true;
                                ddlMesFNP1.Visible = true;
                                ddlAnoFNP1.Visible = true;
                                rdoGeneroP1.Visible = true;

                                txtNomH2.Visible = true;
                                ddlDiaFNP2.Visible = true;
                                ddlMesFNP2.Visible = true;
                                ddlAnoFNP2.Visible = true;
                                rdoGeneroP2.Visible = true;

                                txtNomH3.Visible = true;
                                ddlDiaFNP3.Visible = true;
                                ddlMesFNP3.Visible = true;
                                ddlAnoFNP3.Visible = true;
                                rdoGeneroP3.Visible = true;

                                txtNomH4.Visible = false;
                                ddlDiaFNP4.Visible = false;
                                ddlMesFNP4.Visible = false;
                                ddlAnoFNP4.Visible = false;
                                rdoGeneroP4.Visible = false;
                                txtNomH4.Text = "";
                                ddlDiaFNP4.SelectedIndex = 0;
                                ddlMesFNP4.SelectedIndex = 0;
                                ddlAnoFNP4.SelectedIndex = 0;
                            }
                            else
                            {
                                if (ddlCuantosHijos.SelectedValue == "4")
                                {
                                    tablaH.Visible = true;
                                    txtNomH1.Visible = true;
                                    ddlDiaFNP1.Visible = true;
                                    ddlMesFNP1.Visible = true;
                                    ddlAnoFNP1.Visible = true;
                                    rdoGeneroP1.Visible = true;

                                    txtNomH2.Visible = true;
                                    ddlDiaFNP2.Visible = true;
                                    ddlMesFNP2.Visible = true;
                                    ddlAnoFNP2.Visible = true;
                                    rdoGeneroP2.Visible = true;

                                    txtNomH3.Visible = true;
                                    ddlDiaFNP3.Visible = true;
                                    ddlMesFNP3.Visible = true;
                                    ddlAnoFNP3.Visible = true;
                                    rdoGeneroP3.Visible = true;

                                    txtNomH4.Visible = true;
                                    ddlDiaFNP4.Visible = true;
                                    ddlMesFNP4.Visible = true;
                                    ddlAnoFNP4.Visible = true;
                                    rdoGeneroP4.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        protected void ddlMesPeque_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMesPeque.SelectedValue == "00")
                {
                    ddlDiaPeque.Items.Clear();
                    ddlDiaPeque.Items.Add(new ListItem("Día", "00"));
                    ddlDiaPeque.Enabled = false;
                }
                else
                {
                    ddlDiaPeque.Enabled = true;

                    int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAnoPeque.SelectedValue), Convert.ToInt32(ddlMesPeque.SelectedValue));

                    if(ddlAnoPeque.SelectedValue == DateTime.Now.Year.ToString() && ddlMesPeque.SelectedValue == DateTime.Now.Month.ToString())                        
                        CargarCatalogoDia(DateTime.Now.Day, diasxmes, ddlDiaPeque);
                    else
                        CargarCatalogoDia(1, diasxmes, ddlDiaPeque);
                }
                ddlDiaPeque.SelectedValue = "01";
            }
            catch
            {

            }
        }

        protected void ddlMesFNP1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMesFNP1.SelectedValue == "00")
                {
                    ddlDiaFNP1.Items.Clear();
                    ddlDiaFNP1.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP1.Enabled = false;
                }
                else
                {
                    ddlDiaFNP1.Enabled = true;

                    int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAnoFNP1.SelectedValue), Convert.ToInt32(ddlMesFNP1.SelectedValue));

                    if (ddlAnoFNP1.SelectedValue == DateTime.Now.Year.ToString() && ddlMesFNP1.SelectedValue == DateTime.Now.Month.ToString())
                        CargarCatalogoDia(1, DateTime.Now.Day, ddlDiaFNP1);
                    else
                        CargarCatalogoDia(1, diasxmes, ddlDiaFNP1);                        
                }
            }
            catch
            {

            }
        }

         public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        public string CapitalizeFirstLetter(string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        protected void CargarCatalogoMesFechaActual(int inicial, int final, DropDownList ControlCombo)
        {
            try
            {
                ControlCombo.Items.Clear();
                ControlCombo.Items.Add(new ListItem("Mes", "00"));

                for (int i = inicial; i <= final; i++)
                {
                    string mes = MonthName(i);
                    mes = CapitalizeFirstLetter(mes);
                    ListItem Item = new ListItem();
                    if (i < 10)
                    {
                        Item.Value = "0" + i.ToString();
                    }
                    else
                    {
                        Item.Value = i.ToString();
                    }
                    Item.Text = mes.ToString();
                    ControlCombo.Items.Add(Item);
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }    

        protected void ddlAnoPeque_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAnoPeque.SelectedValue == "00")
                {
                    ddlMesPeque.Items.Clear();
                    ddlMesPeque.Items.Add(new ListItem("Mes", "00"));
                    ddlMesPeque.Enabled = false;
                    ddlDiaPeque.Items.Clear();
                    ddlDiaPeque.Items.Add(new ListItem("Día", "00"));
                    ddlDiaPeque.Enabled = false;
                }
                else
                {
                    ddlMesPeque.Enabled = true;
                    DateTime moment;
                    moment = DateTime.Now;
                    string year = Convert.ToString(moment.Year);
                    int month = moment.Month;

                    if (ddlAnoPeque.SelectedValue == year)
                    {
                        CargarCatalogoMesFechaActual(month, 12, ddlMesPeque);
                        ddlMesPeque.Enabled = true;
                        ddlDiaPeque.Items.Clear();
                        ddlDiaPeque.Items.Add(new ListItem("Día", "00"));
                        ddlDiaPeque.Enabled = false;
                    }
                    else
                    {
                        CargarCatalogoMesFechaActual(1, 12, ddlMesPeque);
                        ddlMesPeque.Enabled = true;
                        ddlDiaPeque.Items.Clear();
                        ddlDiaPeque.Items.Add(new ListItem("Día", "00"));
                        ddlDiaPeque.Enabled = false;
                    }
                }
            }
            catch
            { }
        }

        protected void ddlAnoFNP1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAnoFNP1.SelectedValue == "00")
                {
                    ddlMesFNP1.Items.Clear();
                    ddlMesFNP1.Items.Add(new ListItem("Selecciona", "00"));
                    ddlMesFNP1.Enabled = false;
                    ddlDiaFNP1.Items.Clear();
                    ddlDiaFNP1.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP1.Enabled = false;
                }
                else
                {
                    CargarCatalogoMes(1, 12, ddlMesFNP1);
                    ddlMesFNP1.Enabled = true;
                    ddlDiaFNP1.Items.Clear();
                    ddlDiaFNP1.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP1.Enabled = false;
                }
            }
            catch
            { }
        }

        protected void ddlAnoFNP2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAnoFNP2.SelectedValue == "00")
                {
                    ddlMesFNP2.Items.Clear();
                    ddlMesFNP2.Items.Add(new ListItem("Selecciona", "00"));
                    ddlMesFNP2.Enabled = false;
                    ddlDiaFNP2.Items.Clear();
                    ddlDiaFNP2.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP2.Enabled = false;
                }
                else
                {
                    CargarCatalogoMes(1, 12, ddlMesFNP2);
                    ddlMesFNP2.Enabled = true;
                    ddlDiaFNP2.Items.Clear();
                    ddlDiaFNP2.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP2.Enabled = false;
                }
            }
            catch
            { }
        }

        protected void ddlAnoFNP3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAnoFNP3.SelectedValue == "00")
                {
                    ddlMesFNP3.Items.Clear();
                    ddlMesFNP3.Items.Add(new ListItem("Selecciona", "00"));
                    ddlMesFNP3.Enabled = false;
                    ddlDiaFNP3.Items.Clear();
                    ddlDiaFNP3.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP3.Enabled = false;
                }
                else
                {
                    CargarCatalogoMes(1, 12, ddlMesFNP3);
                    ddlMesFNP3.Enabled = true;
                    ddlDiaFNP3.Items.Clear();
                    ddlDiaFNP3.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP3.Enabled = false;
                }
            }
            catch
            { }
        }

        protected void ddlAnoFNP4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlAnoFNP4.SelectedValue == "00")
                {
                    ddlMesFNP4.Items.Clear();
                    ddlMesFNP4.Items.Add(new ListItem("Selecciona", "00"));
                    ddlMesFNP4.Enabled = false;
                    ddlDiaFNP4.Items.Clear();
                    ddlDiaFNP4.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP4.Enabled = false;
                }
                else
                {
                    CargarCatalogoMes(1, 12, ddlMesFNP4);
                    ddlMesFNP4.Enabled = true;
                    ddlDiaFNP4.Items.Clear();
                    ddlDiaFNP4.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP4.Enabled = false;
                }
            }
            catch
            { }
        }

        protected void ddlMesFNP2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMesFNP2.SelectedValue == "00")
                {
                    ddlDiaFNP2.Items.Clear();
                    ddlDiaFNP2.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP2.Enabled = false;
                }
                else
                {
                    ddlDiaFNP2.Enabled = true;

                    int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAnoFNP2.SelectedValue), Convert.ToInt32(ddlMesFNP2.SelectedValue));

                    if (ddlAnoFNP2.SelectedValue == DateTime.Now.Year.ToString() && ddlMesFNP2.SelectedValue == DateTime.Now.Month.ToString())
                        CargarCatalogoDia(1, DateTime.Now.Day, ddlDiaFNP2);
                    else
                        CargarCatalogoDia(1, diasxmes, ddlDiaFNP2);
                }
            }
            catch
            {

            }
        }

        protected void ddlMesFNP3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMesFNP3.SelectedValue == "00")
                {
                    ddlDiaFNP3.Items.Clear();
                    ddlDiaFNP3.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP3.Enabled = false;
                }
                else
                {
                    ddlDiaFNP3.Enabled = true;

                    int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAnoFNP3.SelectedValue), Convert.ToInt32(ddlMesFNP3.SelectedValue));

                    if (ddlAnoFNP3.SelectedValue == DateTime.Now.Year.ToString() && ddlMesFNP3.SelectedValue == DateTime.Now.Month.ToString())
                        CargarCatalogoDia(1, DateTime.Now.Day, ddlDiaFNP3);
                    else
                        CargarCatalogoDia(1, diasxmes, ddlDiaFNP3);
                }
            }
            catch
            {

            }
        }

        protected void ddlMesFNP4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlMesFNP4.SelectedValue == "00")
                {
                    ddlDiaFNP4.Items.Clear();
                    ddlDiaFNP4.Items.Add(new ListItem("Selecciona", "00"));
                    ddlDiaFNP4.Enabled = false;
                }
                else
                {
                    ddlDiaFNP4.Enabled = true;

                    int diasxmes = DateTime.DaysInMonth(Convert.ToInt32(ddlAnoFNP4.SelectedValue), Convert.ToInt32(ddlMesFNP4.SelectedValue));

                    if (ddlAnoFNP4.SelectedValue == DateTime.Now.Year.ToString() && ddlMesFNP4.SelectedValue == DateTime.Now.Month.ToString())
                        CargarCatalogoDia(1, DateTime.Now.Day, ddlDiaFNP4);
                    else
                        CargarCatalogoDia(1, diasxmes, ddlDiaFNP4);
                }
            }
            catch
            {

            }
        }

        protected void btnRegistrar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string peque = Session["Peques"].ToString();

                //if (peque=="1")
                //{
                //    Mensajes("La tarjeta ya se registró en el club peques");
                //}
                //else
                //{

                if (chkTerminos.Checked == false)
                {
                    Mensajes("Debe aceptar Terminos y condiciones para continuar");
                }
                else
                {
                    if (rblEmbarazo.SelectedValue == "-1" || rblEmbarazo.SelectedValue == "")
                    {
                        throw new ApplicationException("Selecciona ¿Estas Embarazada?");
                    }
                    if (rblTienesHijos.SelectedValue == "-1" || rblTienesHijos.SelectedValue == "")
                    {
                        throw new ApplicationException("Selecciona ¿Tienes hijos menores a 3 años?");
                    }
                    if (rblEmbarazo.SelectedValue == "1")
                    {
                        if (ddlAnoPeque.SelectedValue == "1900" || ddlMesPeque.SelectedValue == "00" || ddlDiaPeque.SelectedValue == "00")
                        {
                            throw new ApplicationException("Selecciona fecha correcta en la que nacerá tu bebé.");
                        }
                    }
                    if (ddlCuantosHijos.SelectedValue == "0" && rblTienesHijos.SelectedValue == "1")
                    {
                        throw new ApplicationException("Selecciona ¿Cuántos hijos menores a 3 años tienes?");
                    }
                    else
                    {
                        string fechaCuando = "19000101";
                        string fechaNHijo1 = "19000101";
                        string fechaNHijo2 = "19000101";
                        string fechaNHijo3 = "19000101";
                        string fechaNHijo4 = "19000101";

                        if (ddlCuantosHijos.SelectedValue == "1")
                        {
                            fechaNHijo1 = ddlAnoFNP1.SelectedValue.ToString() + ddlMesFNP1.SelectedValue.ToString() + ddlDiaFNP1.SelectedValue.ToString();
                            fechaNHijo2 = "19000101";
                            fechaNHijo3 = "19000101";
                            fechaNHijo4 = "19000101";
                        }
                        if (ddlCuantosHijos.SelectedValue == "2")
                        {
                            fechaNHijo1 = ddlAnoFNP1.SelectedValue.ToString() + ddlMesFNP1.SelectedValue.ToString() + ddlDiaFNP1.SelectedValue.ToString();
                            fechaNHijo2 = ddlAnoFNP2.SelectedValue.ToString() + ddlMesFNP2.SelectedValue.ToString() + ddlDiaFNP2.SelectedValue.ToString();
                            fechaNHijo3 = "19000101";
                            fechaNHijo4 = "19000101";
                        }
                        if (ddlCuantosHijos.SelectedValue == "3")
                        {
                            fechaNHijo1 = ddlAnoFNP1.SelectedValue.ToString() + ddlMesFNP1.SelectedValue.ToString() + ddlDiaFNP1.SelectedValue.ToString();
                            fechaNHijo2 = ddlAnoFNP2.SelectedValue.ToString() + ddlMesFNP2.SelectedValue.ToString() + ddlDiaFNP2.SelectedValue.ToString();
                            fechaNHijo3 = ddlAnoFNP3.SelectedValue.ToString() + ddlMesFNP3.SelectedValue.ToString() + ddlDiaFNP3.SelectedValue.ToString();
                            fechaNHijo4 = "19000101";
                        }
                        if (ddlCuantosHijos.SelectedValue == "4")
                        {
                            fechaNHijo1 = ddlAnoFNP1.SelectedValue.ToString() + ddlMesFNP1.SelectedValue.ToString() + ddlDiaFNP1.SelectedValue.ToString();
                            fechaNHijo2 = ddlAnoFNP2.SelectedValue.ToString() + ddlMesFNP2.SelectedValue.ToString() + ddlDiaFNP2.SelectedValue.ToString();
                            fechaNHijo3 = ddlAnoFNP3.SelectedValue.ToString() + ddlMesFNP3.SelectedValue.ToString() + ddlDiaFNP3.SelectedValue.ToString();
                            fechaNHijo4 = ddlAnoFNP4.SelectedValue.ToString() + ddlMesFNP4.SelectedValue.ToString() + ddlDiaFNP4.SelectedValue.ToString();
                        }

                        if (ddlAnoPeque.SelectedValue == "1900" || ddlMesPeque.SelectedValue == "00" || ddlDiaPeque.SelectedValue == "00")
                        {
                            fechaCuando = "19000101";
                        }
                        else
                        {
                            fechaCuando = ddlAnoPeque.SelectedValue.ToString() + ddlMesPeque.SelectedValue.ToString() + ddlDiaPeque.SelectedValue.ToString();
                        }
                        if (ddlAnoFNP1.SelectedValue == "1900" || ddlMesFNP1.SelectedValue == "00" || ddlDiaFNP1.SelectedValue == "00")
                        {
                            fechaNHijo1 = "19000101";
                        }
                        if (ddlAnoFNP2.SelectedValue == "1900" || ddlMesFNP2.SelectedValue == "00" || ddlDiaFNP2.SelectedValue == "00")
                        {
                            fechaNHijo2 = "19000101";
                        }
                        if (ddlAnoFNP3.SelectedValue == "1900" || ddlMesFNP3.SelectedValue == "00" || ddlDiaFNP3.SelectedValue == "00")
                        {
                            fechaNHijo3 = "19000101";
                        }
                        if (ddlAnoFNP4.SelectedValue == "1900" || ddlMesFNP4.SelectedValue == "00" || ddlDiaFNP4.SelectedValue == "00")
                        {
                            fechaNHijo4 = "19000101";
                        }

                        Clientes cliente = new Clientes();
                        DataSet dsPeque = new DataSet();
                        string tarjeta = Session["Usuario"].ToString();
                        if (hdnHijo1.Value == "0")
                            cliente.RegistraEncuestaPeque(tarjeta, rblEmbarazo.SelectedValue.ToString(), rblTienesHijos.SelectedValue.ToString(), fechaCuando, ddlCuantosHijos.SelectedValue.ToString(), txtNomH1.Text, fechaNHijo1, rdoGeneroP1.SelectedValue.ToString(), txtNomH2.Text, fechaNHijo2, rdoGeneroP2.SelectedValue.ToString(), txtNomH3.Text, fechaNHijo3, rdoGeneroP3.SelectedValue.ToString(), txtNomH4.Text, fechaNHijo4, rdoGeneroP4.SelectedValue.ToString());
                        else
                            cliente.RegistraEncuestaPeque(tarjeta, rblEmbarazo.SelectedValue.ToString(), rblTienesHijos.SelectedValue.ToString(), fechaCuando, ddlCuantosHijos.SelectedValue.ToString(), txtNomH1.Text, fechaNHijo1, rdoGeneroP1.SelectedValue.ToString(), txtNomH2.Text, fechaNHijo2, rdoGeneroP2.SelectedValue.ToString(), txtNomH3.Text, fechaNHijo3, rdoGeneroP3.SelectedValue.ToString(), txtNomH4.Text, fechaNHijo4, rdoGeneroP4.SelectedValue.ToString(), Convert.ToInt32(hdnHijo1.Value), Convert.ToInt32(hdnHijo2.Value), Convert.ToInt32(hdnHijo3.Value), Convert.ToInt32(hdnHijo4.Value));

                        cliente.ActualizaRecibirInfo(tarjeta, chkRecibirInfo.Checked);
                        
                        string mensaje = "Registro exitoso.";
                        ClientScript.RegisterStartupScript(GetType(), "mostrarmensaje", "diHola('" + mensaje + "', '" + "ClubPequesPromos.aspx" + "');", true);
                    }
                }
                //}
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        protected void rblTienesHijos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblTienesHijos.SelectedValue == "1")
                {
                    //tablaH.Visible = true;
                    ddlCuantosHijos.Enabled = true;
                    ddlCuantosHijos.Enabled = true;
                }
                else
                {
                    ddlCuantosHijos.SelectedValue = "0";
                    txtNomH1.Text = string.Empty;
                    txtNomH2.Text = string.Empty;
                    txtNomH3.Text = string.Empty;
                    txtNomH4.Text = string.Empty;

                    ddlAnoFNP1.SelectedValue = "1900";
                    ddlAnoFNP2.SelectedValue = "1900";
                    ddlAnoFNP3.SelectedValue = "1900";
                    ddlAnoFNP4.SelectedValue = "1900";

                    ddlMesFNP1.SelectedValue = "00";
                    ddlMesFNP2.SelectedValue = "00";
                    ddlMesFNP3.SelectedValue = "00";
                    ddlMesFNP4.SelectedValue = "00";

                    ddlDiaFNP1.SelectedValue = "00";
                    ddlDiaFNP2.SelectedValue = "00";
                    ddlDiaFNP3.SelectedValue = "00";
                    ddlDiaFNP4.SelectedValue = "00";


                    tablaH.Visible = false;
                    ddlCuantosHijos.Enabled = false;
                    ddlCuantosHijos.Enabled = false;
                }
            }
            catch
            { }
        }

        protected void rblEmbarazo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblEmbarazo.SelectedValue == "1")
            {
                lblNacera.Visible = true;         
                ddlAnoPeque.Enabled = true;
                ddlMesPeque.Enabled = true;
                ddlDiaPeque.Enabled = true;
                ddlAnoPeque.SelectedValue = "1900";
                ddlMesPeque.SelectedValue = "00";
                ddlDiaPeque.SelectedValue = "00";
            }
            else
            {
                lblNacera.Visible = false;
                ddlAnoPeque.Enabled = false;
                ddlMesPeque.Enabled = false;
                ddlDiaPeque.Enabled = false;
                ddlAnoPeque.SelectedValue = "1900";
                ddlMesPeque.SelectedValue = "00";
                ddlDiaPeque.SelectedValue = "00";
            }
        }

        

       

      


        //public void limpiaCampos()
        //{
        //    ddlAnoPeque.SelectedValue = "00";
        //    ddlMesPeque.SelectedValue = "00";
        //    ddlDiaPeque.SelectedValue = "00";
        //    ddlCuantosHijos.SelectedValue = "0";
        //    txtNomH1.Text = string.Empty;
        //    txtNomH2.Text = string.Empty;
        //    txtNomH3.Text = string.Empty;
        //    txtNomH4.Text = string.Empty;
        //    ddlAnoFNP1.SelectedValue = "00";
        //    ddlAnoFNP2.SelectedValue = "00";
        //    ddlAnoFNP3.SelectedValue = "00";
        //    ddlAnoFNP4.SelectedValue = "00";
        //    ddlMesFNP1.SelectedValue = "00";
        //    ddlMesFNP2.SelectedValue = "00";
        //    ddlMesFNP3.SelectedValue = "00";
        //    ddlMesFNP4.SelectedValue = "00";
        //    ddlDiaFNP1.SelectedValue = "00";
        //    ddlDiaFNP2.SelectedValue = "00";
        //    ddlDiaFNP3.SelectedValue = "00";
        //    ddlDiaFNP4.SelectedValue = "00";
        //}


    }
}