using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Datos;
using Telerik.Web.UI;
using xi = Telerik.Web.UI.ExportInfrastructure;
using Telerik.Web.UI.GridExcelBuilder;
using SpreadsheetLight;

namespace CallcenterNUevo.AdminPromociones
{
    public partial class AltaPromoDobleAcumulacion : System.Web.UI.Page
    {
        //Este módulo registra su información en Dbase  Productivo
        public static string CnnProductivo = "ConnectionString";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Alta"] != null)
                {
                    EliminarVariablesSession();
                }

                CargaComboSucursales();
                CargaComboCupones();
                InicializaControles();
            }
        }
        protected void rdpFFin_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            DateTime FI;
            DateTime FF;
            lblalertaFechaFin.Text = "";

            if (rdpFFin.SelectedDate.Value != null)
            {
                if (rdpFFin.SelectedDate < DateTime.Now.Date)
                {
                    Mensajes("No es posible que la fecha fin sea menor a la fecha actual.");
                    rdpFFin.Clear();
                    rdpFFin.Focus();
                    btnAgregarSucursal.Enabled = false;
                    return;
                }

                if (rdpFFin.SelectedDate < rdpFIni.SelectedDate)
                {
                    Mensajes("No es posible que la fecha fin sea menor a la fecha inicio.");
                    rdpFFin.Clear();
                    rdpFFin.Focus();
                    btnAgregarSucursal.Enabled = false;
                    return;
                }

                FI = Convert.ToDateTime(rdpFIni.SelectedDate);
                FF = Convert.ToDateTime(rdpFFin.SelectedDate);

                if (FI == FF)
                {
                    lblalertaFechaFin.Text = "La promoción finalizara el día de hoy a las 23h 59m 59s";
                }

                if (Session["Modificacion"] == null)
                {
                    if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                    {
                        rdpFFin.Clear();
                        txtDescripcion.Focus();
                        Mensajes("Es necesario proporcione un nombre descriptivo a la nueva promoción.");
                        btnAgregarSucursal.Enabled = false;
                        return;
                    }

                    if (rdpFIni.SelectedDate == null)
                    {
                        rdpFFin.Clear();
                        rdpFIni.Focus();
                        Mensajes("Es necesario proporcione una fecha inicio a la promoción.");
                        btnAgregarSucursal.Enabled = false;
                        return;
                    }
                }
            }
        }
        protected void rdpFIni_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFIni.SelectedDate.Value != null)
            {
                if (rdpFIni.SelectedDate < DateTime.Now.Date)
                {
                    Mensajes("No es posible que la fecha inicio sea menor a la fecha actual.");
                    rdpFIni.Clear();
                    rdpFIni.Focus();
                }
            }
        }
        protected void rdpFechaInicio_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {


        }
        protected void rdpFechaFin_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {

        }
        protected void rdpFechaFinDesc_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {

        }
        protected void rcbSucursales_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
        protected void grvPromDobleAcumulacion_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            DateTime fechacompara;
            string strSucursal = "";
            switch (e.CommandName)
            {
                case "EditarPromDobleAcumulaSuc":

                    CargaComboSucursales();
                    Session.Add("Idreg", e.Item.Cells[3].Text);
                    if (e.Item.Cells[5].Text.Length > 5)
                    {
                        strSucursal = e.Item.Cells[5].Text.Substring(0, e.Item.Cells[5].Text.IndexOf(" -"));
                    }

                    rdbCargaEspecifica.Visible = false;
                    rdbCargaMasiva.Visible = false;
                    rcbSucursales.Enabled = false;
                    rcbSucursales.SelectedValue = strSucursal;
                    lblCargaEspecifica.Visible = true;
                    rcbSucursales.Visible = true;
                    rdpFechaInicio.Enabled = false;
                    rdpFechaInicio.SelectedDate = Convert.ToDateTime(e.Item.Cells[6].Text);
                    rdpFechaFin.SelectedDate = Convert.ToDateTime(e.Item.Cells[7].Text);

                    if (rdpFechaInicio.SelectedDate == rdpFechaFin.SelectedDate)
                    {
                        rdpFechaFin.Enabled = false;
                    }
                    else
                    {
                        rdpFechaFin.Enabled = true;
                    }

                    if (chkDescINAPAM.Checked)
                    {
                        if (string.IsNullOrWhiteSpace(txtDescInampam.Text))
                        {
                            txtDescInampam.Focus();
                            Mensajes("Debe proporcionar el valor del porcentaje.");
                            return;
                        }

                        if (grvPromDobleAcumulacion.Columns.Count == 8)
                        {
                            if (e.Item.Cells[8].Text != "&nbsp;" && DateTime.TryParse(e.Item.Cells[8].Text, out fechacompara) && e.Item.Cells[8].Text != "01/01/0001 12:00:00 a. m.")
                            {
                                rdpFechaFinDesc.SelectedDate = Convert.ToDateTime(e.Item.Cells[8].Text);
                            }

                            Session.Add("TipoProm", "DESC");
                            lblFechaFinDesc.Visible = true;
                            rdpFechaFinDesc.Visible = true;
                            rdpFechaFinDesc.Focus();
                        }
                    }
                    else
                    {
                        Session.Contents.Remove("TipoProm");
                        Session.Remove("TipoProm");
                        lblFechaFinDesc.Visible = false;
                        rdpFechaFinDesc.Visible = false;
                    }

                    btnGuardarconfSuc.Visible = false;
                    btnModificarPop.Visible = true;
                    rcbSucursales.Enabled = false;

                    mpe.Show();
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                    break;

                case "EliminarPromDobleAcumulaSuc":

                    Session.Add("Idreg", e.Item.Cells[3].Text);
                    Session.Add("IndexEliminar", e.Item.ItemIndex.ToString());

                    mpeDelete.Show();
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowRegDelete();</script>", false);
                    break;
            }
        }
        protected void grvPromDobleAcumulacion_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            if (Session["Modificacion"] != null)
            {
                CargalstPromoVigentes();
            }
            else
            {
                OrigenListado();
            }
        }
        protected void grvPromDobleAcumulacion_SortCommand(object sender, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            if (Session["Modificacion"] != null)
            {
                if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
                {
                    GridSortExpression sortExpr = new GridSortExpression();
                    sortExpr.FieldName = "Id";
                    sortExpr.FieldName = e.SortExpression;
                    sortExpr.SortOrder = GridSortOrder.Ascending;
                    e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                    CargalstPromoVigentes();
                }
                else
                {
                    GridSortExpression sortExpr = new GridSortExpression();
                    sortExpr.FieldName = "Id";
                    sortExpr.FieldName = e.SortExpression;
                    sortExpr.SortOrder = GridSortOrder.Descending;
                    e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                    CargalstPromoVigentes();
                }
            }
        }
        protected void grvPromDobleAcumulacion_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (Session["Modificacion"] != null)
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;

                    Button btn = (item.FindControl("btnEditar") as Button);
                    btn.Visible = true;

                    Button btnDelete = (item.FindControl("btnEliminar") as Button);
                    btnDelete.Visible = true;
                }
            }

            if (Session["Alta"] != null)
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;

                    Button btnDelete = (item.FindControl("btnEliminar") as Button);
                    btnDelete.Visible = true;
                }
            }
        }
        protected void rcbCupones_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            if (Validaciones())
            {
                if (ValidaPromocionExistente())//Si no existe permitira agregar sucursales
                {
                    limpiarCamposPopup();
                }
                else
                {
                    Mensajes("Imposible continuar ya existe una promoción vigente con este cupón: " + rcbCupones.Text.Substring(0, rcbCupones.Text.IndexOf("-") - 1));
                    rdpFIni.SelectedDate = null;
                    rdpFFin.SelectedDate = null;
                    rcbCupones.ClearSelection();
                    limpiarCamposPopup();
                }
            }
            else
            {
                rcbCupones.ClearSelection();
            }
        }
        protected void chkCupon_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCupon.Checked)
            {
                rcbCupones.Visible = true;
                chkApertura.Enabled = false;
                chkDescINAPAM.Enabled = true;
                chkApertura.Checked = false;
                chkDescINAPAM.Checked = false;

                limpiarCamposPopup();
                btnAgregarSucursal.Enabled = true;
            }
            else
            {
                chkDescINAPAM.Checked = false;
                rcbCupones.ClearSelection();
                rcbCupones.Visible = false;

                limpiarCamposPopup();
                btnAgregarSucursal.Enabled = false;
            }
        }
        protected void chkDescINAPAM_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDescINAPAM.Checked)
            {
                rcbCupones.ClearSelection();
                rcbCupones.Visible = false;
                chkCupon.Enabled = true;
                chkCupon.Checked = false;
                chkApertura.Checked = false;
                chkApertura.Enabled = false;

                btnAgregarSucursal.Enabled = true;
            }
            else
            {
                chkCupon.Checked = false;
                btnAgregarSucursal.Enabled = false;
            }


            if (Validaciones())
            {
                if (ValidaPromocionExistente())//Si no existe permitira agregar sucursales
                {
                    limpiarCamposPopup();
                }
                else
                {
                    rdpFIni.SelectedDate = null;
                    rdpFFin.SelectedDate = null;
                    chkDescINAPAM.Checked = false;
                    Mensajes("Imposible continuar ya existe una promoción vigente.");
                    limpiarCamposPopup();
                }
            }
            else
            {
                chkDescINAPAM.Checked = false;
            }
        }
        protected void chkApertura_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApertura.Checked)
            {
                rcbCupones.ClearSelection();
                rcbCupones.Visible = false;
                chkCupon.Enabled = true;
                chkCupon.Checked = false;
                chkDescINAPAM.Checked = false;
                chkDescINAPAM.Enabled = true;
            }
        }
        protected void rdbCargaMasiva_CheckedChanged(object sender, EventArgs e)
        {
            lblCargaEspecifica.Visible = false;
            rcbSucursales.Visible = false;
            lblCargaMasiva.Visible = true;
            FileUplSuc.Visible = true;
            mpe.Show();
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
        }
        protected void rdbCargaEspecifica_CheckedChanged(object sender, EventArgs e)
        {
            lblCargaMasiva.Visible = false;
            FileUplSuc.Visible = false;
            lblCargaEspecifica.Visible = true;
            rcbSucursales.Visible = true;
            mpe.Show();
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
        }
        protected void btnAgregarSucursal_Click(object sender, EventArgs e)
        {
            CargaComboSucursales();
            if (ActivarControlesPopup())
            {
                mpe.Show();
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                if (Session["Modificacion"] == null)
                {
                    if (grvPromDobleAcumulacion.Items.Count == 0)
                    {
                        Mensajes("Es necesario agregar al grid una sucursal a la promoción.");
                        btnAgregarSucursal_Click(null, null);

                        return;
                    }

                    //Alta de promociones
                    GuardarNvaPromocion();
                }
                else
                {
                    //Editar promoción existente
                    ModificarPromocion();
                }
            }
        }
        protected void btnGuardarconfSuc_Click(object sender, EventArgs e)
        {
            if (ValidacionesPopup())
            {
                if (rdbCargaEspecifica.Checked)
                {
                    AgregarElementosSucursales();
                }
                else if (rdbCargaMasiva.Checked)
                {

                    List<ModSucursales> lstRespSuc = new List<ModSucursales>();
                    AgregarMasivamenteElementosSucursales(FileUplSuc);
                }
            }
            else
            {
                mpe.Show();
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
            }
        }
        protected void btnCancelarconfSuc_Click(object sender, EventArgs e)
        {
            limpiarCamposPopup();
        }
        protected void btnCancelar_Click1(object sender, EventArgs e)
        {
            EliminarVariablesSession();
            Response.Redirect("PromoDobleAcumulacion.aspx");
        }
        protected void btnModificarPop_Click(object sender, EventArgs e)
        {
            if (ValidacionesFechas())
            {
                if (ActivarControlesPopup())
                {
                    if (!ValidacionesPopup())
                    {
                        mpe.Show();
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                        return;
                    }
                    else
                    {
                        List<ModPromoDobleAcumulacion> lstPromoDobleAcum = new List<ModPromoDobleAcumulacion>();
                        lstPromoDobleAcum = (List<ModPromoDobleAcumulacion>)Session["lstSucursales"];
                        int intId = Convert.ToInt32(Session["Id"].ToString());
                        int intIdreg = Convert.ToInt32(Session["Idreg"].ToString());
                        List<ModPromoDobleAcumulacion> lstEdit = new List<ModPromoDobleAcumulacion>();

                        if (Convert.ToInt32(rcbSucursales.SelectedValue) > 0)
                        {
                            lstEdit = lstPromoDobleAcum.Where(w => w.IdPromo == intId && w.Id == intIdreg && w.Sucursal == rcbSucursales.SelectedValue || w.IdPromo == intId && w.Id == intIdreg && w.Sucursal.ToUpper() == rcbSucursales.Text).ToList();
                        }
                        else
                        {
                            lstEdit = lstPromoDobleAcum.Where(w => w.IdPromo == intId && w.Id == intIdreg && w.Sucursal == "0 -Todas" || w.IdPromo == intId && w.Id == intIdreg && w.Sucursal.ToUpper() == rcbSucursales.Text).ToList();
                        }


                        //foreach (ModPromoDobleAcumulacion campos in lstPromoDobleAcum)//recorria todas las sucursales y seteaba la fehca para todas
                        foreach (ModPromoDobleAcumulacion campos in lstEdit)//Solo modifica la sucursal seleccionada
                        {
                            string strFF = "";
                            DateTime FF = Convert.ToDateTime(rdpFechaFin.SelectedDate);
                            strFF = FF.ToShortDateString() + " 23:59:59";
                            campos.FechaFin = Convert.ToDateTime(strFF);

                            if (rdpFechaFinDesc.SelectedDate != null)
                            {
                                FF = Convert.ToDateTime(rdpFechaFinDesc.SelectedDate);
                                strFF = FF.ToShortDateString() + " 23:59:59";
                                campos.FechaFinDesctxt = strFF;
                                campos.FechaFinDesc = Convert.ToDateTime(strFF);
                                campos.Porcentaje = Convert.ToInt32(txtDescInampam.Text);
                                grvPromDobleAcumulacion.Columns[6].Visible = true;
                            }
                            else
                            {
                                //FF = Convert.ToDateTime(rdpFechaFin.SelectedDate);///No se tomara encuenta dicha fecha
                                //strFF = FF.ToShortDateString() + " 23:59:59";
                                //campos.FechaFinDesc = Convert.ToDateTime(strFF);
                                campos.FechaFinDesctxt = "No asignada";
                                campos.Porcentaje = 0;
                                //grvPromDobleAcumulacion.Columns[6].Visible = false;
                            }

                            campos.blnMarca = true;
                            if (Session["FechaIniPop"] == null)
                            {
                                Session.Add("FechaIniPop", campos.FechaIni);
                                Session.Add("FechaFinPop", campos.FechaFin);
                                Session.Add("FechaFinDescPop", campos.FechaFinDesc);
                            }
                        }


                        Session.Add("lstSucursales", lstPromoDobleAcum);

                        grvPromDobleAcumulacion.DataSource = lstPromoDobleAcum;
                        grvPromDobleAcumulacion.PageSize = 8;
                        grvPromDobleAcumulacion.DataBind();
                        btnModificarPop.Visible = false;
                        rcbSucursales.Enabled = true;
                        rdpFechaInicio.Enabled = true;
                        btnGuardarconfSuc.Visible = true;
                        limpiarCamposPopup();
                    }
                }
            }
        }
        protected void btnSi_Click(object sender, EventArgs e)
        {
            List<ModPromoDobleAcumulacion> lst = (List<ModPromoDobleAcumulacion>)Session["lstSucursales"];

            int IdReg = 0;
            int Index = 0;
            IdReg = Convert.ToInt32(Session["Idreg"]);
            Index = Convert.ToInt32(Session["IndexEliminar"]);

            string FechaFin = "";
            int contar = 0;
            foreach (ModPromoDobleAcumulacion campos in lst)
            {
                if (Session["Modificacion"] != null)
                {
                    if (chkCupon.Checked)
                    {
                        if (IdReg == 0)
                        {
                            lst.RemoveAt(Index);
                            break;
                        }
                        else if (campos.Id == IdReg)
                        {
                            campos.FechaFin = DateTime.Now;
                            FechaFin = campos.FechaFin.ToShortDateString() + " " + DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
                            campos.FechaFin = Convert.ToDateTime(FechaFin);

                            lst[contar].FechaFin = campos.FechaFin;
                            lst[contar].blnMarca = true;
                            break;
                        }
                    }

                    if (chkDescINAPAM.Checked)
                    {
                        if (IdReg == 0)
                        {
                            lst.RemoveAt(Index);
                            break;
                        }
                        else if (campos.Id == IdReg)
                        {
                            campos.FechaFinDesc = DateTime.Now;
                            FechaFin = campos.FechaFinDesc.ToShortDateString() + " " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                            campos.FechaFinDesc = Convert.ToDateTime(FechaFin);

                            lst[contar].FechaFinDesc = campos.FechaFinDesc;
                            lst[contar].FechaFinDesctxt = campos.FechaFinDesc.ToString();
                            lst[contar].blnMarca = true;
                            break;
                        }
                    }
                    contar += 1;
                }

                if (Session["Alta"] != null)
                {
                    lst.RemoveAt(Index);
                    break;
                }
            }

            Session.Add("SeEliminoReg", "true");
            Session.Add("lstSucursales", lst);
            lblregistros.Text = "Total registros: " + lst.Count.ToString();
            grvPromDobleAcumulacion.DataSource = lst;
            grvPromDobleAcumulacion.PageSize = 8;
            grvPromDobleAcumulacion.DataBind();

            if (Session["Alta"] != null)
            {
                Mensajes("Se elimino la sucursal correctamente.");
            }
            else
            {
                Mensajes("Se vencio la vigencia de la sucursal correctamente.");
            }
        }

        private void InicializaControles()
        {
            //Alta de nvas promociones
            if (Session["Modificacion"] == null)
            {
                lblTitulo.Text = "Agrega promociones de apertura...";
                chkCupon.Checked = false;
                chkApertura.Checked = false;
                chkDescINAPAM.Checked = false;
                LimpiarCampos();
                limpiarCamposPopup();
            }
            //Moficaciones de promociones
            else if (Session["Modificacion"] != null)
            {
                lblTitulo.Text = "Editando promociones de apertura...";
                btnAgregarSucursal.Enabled = true;

                //rdpFIni.Enabled = false;
                txtDescripcion.Text = Session["Desc"].ToString();
                rdpFIni.SelectedDate = Convert.ToDateTime(Session["FechaI"]);
                rdpFFin.SelectedDate = Convert.ToDateTime(Session["FechaF"]);

                ModCupones RespuestaCuponPromoACD = new ModCupones();
                AdministraPromocion Ejecutar = new AdministraPromocion();
                RespuestaCuponPromoACD = Ejecutar.ObtenCuponPromoDAC(Convert.ToInt32(Session["Id"]));

                if (RespuestaCuponPromoACD.IdCupon != 0)
                {
                    chkCupon.Checked = true;
                    rcbCupones.SelectedValue = RespuestaCuponPromoACD.IdCupon.ToString();
                    rcbCupones.Visible = true;
                    rcbCupones.Enabled = false;
                }
                CargalstPromoVigentes();

                limpiarCamposPopup();
            }
        }
        private void AgregarElementosSucursales()
        {
            string FechaInicio = "";
            string FechaFin = "";
            string FechaFinDesc = "";
            List<ModPromoDobleAcumulacion> lstSucursales = new List<ModPromoDobleAcumulacion>();
            AdministraPromocion ejecuta = new AdministraPromocion();
            ModPromoDobleAcumulacion campos = new ModPromoDobleAcumulacion();

            if (Session["Id"] == null)
            {
                //IdPromo nuevo Insert
                campos.IdPromo = 0;
            }
            else
            {
                //IdPromo existente Update
                campos.IdPromo = Convert.ToInt32(Session["Id"]);
            }

            if (Session["lstSucursales"] != null)
            {
                //setea el contenido de la variable de session al objeto lista
                lstSucursales = (List<ModPromoDobleAcumulacion>)Session["lstSucursales"];
            }

            int ExisteSucursalenGrid = 0;

            ExisteSucursalenGrid = lstSucursales.Where(w => w.Sucursal.ToUpper() == rcbSucursales.Text).Count();
            if (ExisteSucursalenGrid > 0)
            {
                Mensajes("No es posible agregar la sucursal: " + rcbSucursales.Text + " ya existe");
                rcbSucursales.Focus();

                mpe.Show();
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                return;
            }

            Session.Add("selSucursal", rcbSucursales.SelectedValue);

            if (Convert.ToInt32(Session["selSucursal"]) > 0)
            {
                campos.Nombre = txtDescripcion.Text;
                campos.FechaIni = Convert.ToDateTime(rdpFechaInicio.SelectedDate);
                campos.FechaIni = Convert.ToDateTime(campos.FechaIni.ToShortDateString() + " 00:00:00");

                //if (chkApertura.Checked)
                if (rdpFechaFin.SelectedDate != null)
                {
                    campos.FechaFin = Convert.ToDateTime(rdpFechaFin.SelectedDate);
                    campos.FechaFin = Convert.ToDateTime(campos.FechaFin.ToShortDateString() + " 23:59:59");
                }
                else
                {
                    campos.FechaFin = campos.FechaIni;
                }


                if (chkDescINAPAM.Checked)
                {
                    DateTime ffdesc;
                    ffdesc = Convert.ToDateTime(rdpFechaFinDesc.SelectedDate);
                    campos.FechaFinDesctxt = ffdesc.ToShortDateString() + " 23:59:59";
                    campos.FechaFinDesc = Convert.ToDateTime(rdpFechaFinDesc.SelectedDate);
                    campos.FechaFinDesc = Convert.ToDateTime(campos.FechaFinDesc.ToShortDateString() + " 23:59:59");
                    campos.Porcentaje = Convert.ToInt32(txtDescInampam.Text);
                }
                else
                {
                    campos.FechaFinDesctxt = "No asignada";
                    campos.FechaFinDesc = Convert.ToDateTime(rdpFechaFin.SelectedDate);//No se tomara en cuenta esta fecha
                    campos.FechaFinDesc = Convert.ToDateTime(campos.FechaFinDesc.ToShortDateString() + " 23:59:59");
                    campos.Porcentaje = 0;
                }


                campos.Sucursal = rcbSucursales.SelectedValue;
                //===============================================================================================================================
                //Catalogo de sucursales para obtener IdAlmacen
                List<ModSucursales> lstCatSuc = new List<ModSucursales>();
                lstCatSuc = (List<ModSucursales>)Session["lstCatSucursales"];
                int IdSucursal = 0;

                IdSucursal = Convert.ToInt32(campos.Sucursal);
                campos.CveSucursal = lstCatSuc.Where(w => w.IdSucursal == IdSucursal).Select(s => s.CveSucursal).FirstOrDefault();
                //===============================================================================================================================
                campos.Id = 0;
                campos.blnMarca = true;

                List<ModPromoDobleAcumulacion> lstitms = new List<ModPromoDobleAcumulacion>();
                lstitms = (List<ModPromoDobleAcumulacion>)Session["lstSucursales"];
                if (lstitms != null)
                {
                    if (lstitms.Count > 0)
                    {
                        int intExisteDup;
                        //Realiza validación sobre la lista de elementos antes de ser agregados al objeto grid
                        intExisteDup = lstitms.Where(w => w.Sucursal == rcbSucursales.Text && w.FechaIni == campos.FechaIni && w.FechaFin == campos.FechaFin || (w.Sucursal == rcbSucursales.Text && w.FechaFin >= campos.FechaIni && w.FechaFin <= campos.FechaFin) || w.Sucursal == campos.Sucursal && w.FechaIni == campos.FechaIni && w.FechaFin == campos.FechaFin || (w.Sucursal == campos.Sucursal && w.FechaFin >= campos.FechaIni && w.FechaFin <= campos.FechaFin) || (w.Sucursal == campos.Sucursal)).Count();
                        if (intExisteDup > 0)
                        {
                            Mensajes("Imposible agregar la sucursal selecionada ya existe una configuración dentro del rango especificado.");
                            limpiarCamposPopup();
                        }
                        else
                        {
                            lstSucursales.Add(campos);
                            Session.Add("lstSucursales", lstSucursales);
                        }
                    }
                }
                else
                {
                    lstSucursales.Add(campos);
                    Session.Add("lstSucursales", lstSucursales);
                }
            }
            else
            {

                if (rcbSucursales.SelectedValue == "0")
                {
                    //Todas la sucursales
                    if (Session["lstSucursales"] != null)
                    {
                        //setea el contenido de la variable de session al objeto lista
                        lstSucursales = (List<ModPromoDobleAcumulacion>)Session["lstSucursales"];
                    }

                    campos = new ModPromoDobleAcumulacion();
                    campos.Nombre = txtDescripcion.Text;
                    campos.FechaIni = Convert.ToDateTime(rdpFechaInicio.SelectedDate);
                    FechaInicio = campos.FechaIni.ToShortDateString() + " 00:00:00";
                    campos.FechaIni = Convert.ToDateTime(FechaInicio);

                    if (rdpFechaFin.SelectedDate != null)
                    {
                        campos.FechaFin = Convert.ToDateTime(rdpFechaFin.SelectedDate);
                        FechaFin = campos.FechaFin.ToShortDateString() + " 23:59:59";
                        campos.FechaFin = Convert.ToDateTime(FechaFin);
                    }
                    else
                    {
                        //Iguala a la fecha inicio aunque esta no se considera
                        campos.FechaFin = campos.FechaIni;
                    }

                    if (rdpFechaFinDesc.SelectedDate != null)
                    {
                        campos.FechaFinDesc = Convert.ToDateTime(rdpFechaFinDesc.SelectedDate);
                        FechaFinDesc = campos.FechaFinDesc.ToShortDateString() + " 23:59:59";
                        campos.FechaFinDesctxt = FechaFinDesc;
                        campos.Porcentaje = Convert.ToInt32(txtDescInampam.Text);
                        grvPromDobleAcumulacion.Columns[6].Visible = true;
                    }
                    else
                    {
                        campos.FechaFinDesc = Convert.ToDateTime(rdpFechaFin.SelectedDate);//No se tomara en cuenta esta fecha
                        FechaFinDesc = campos.FechaFinDesc.ToShortDateString() + " 23:59:59";
                        campos.Porcentaje = 0;
                        grvPromDobleAcumulacion.Columns[6].Visible = false;
                    }

                    if (Session["FechaIniPop"] == null)
                    {
                        Session.Add("FechaIniPop", campos.FechaIni);
                        Session.Add("FechaFinPop", campos.FechaFin);
                        Session.Add("FechaFinDescPop", campos.FechaFinDesc);
                    }

                    campos.Sucursal = "0";
                    campos.Id = 0;
                    campos.blnMarca = true;

                    lstSucursales.Add(campos);
                    Session.Add("lstSucursales", lstSucursales);

                }
                else
                {
                    foreach (RadComboBoxItem itmSuc in rcbSucursales.Items.ToList())
                    {
                        if (itmSuc.Value != "0")
                        {
                            if (Session["lstSucursales"] != null)
                            {
                                //setea el contenido de la variable de session al objeto lista
                                lstSucursales = (List<ModPromoDobleAcumulacion>)Session["lstSucursales"];
                            }

                            campos = new ModPromoDobleAcumulacion();
                            campos.Nombre = txtDescripcion.Text;
                            campos.FechaIni = Convert.ToDateTime(rdpFechaInicio.SelectedDate);
                            campos.FechaFin = Convert.ToDateTime(rdpFechaFin.SelectedDate);
                            if (rdpFechaFinDesc.SelectedDate != null)
                            {
                                campos.FechaFinDesc = Convert.ToDateTime(rdpFechaFinDesc.SelectedDate);
                                FechaFinDesc = campos.FechaFinDesc.ToShortDateString() + " 23:59:59";
                                campos.FechaFinDesctxt = FechaFinDesc;
                                campos.Porcentaje = Convert.ToInt32(txtDescInampam.Text);
                                grvPromDobleAcumulacion.Columns[6].Visible = true;
                            }
                            else
                            {
                                campos.FechaFinDesc = Convert.ToDateTime(rdpFechaFin.SelectedDate);//No se tomara en cuenta esta fecha
                                FechaFinDesc = campos.FechaFinDesc.ToShortDateString() + " 23:59:59";
                                campos.Porcentaje = 0;
                                grvPromDobleAcumulacion.Columns[6].Visible = false;
                            }

                            FechaInicio = campos.FechaIni.ToShortDateString() + " 00:00:00";
                            FechaFin = campos.FechaFin.ToShortDateString() + " 23:59:59";

                            campos.FechaIni = Convert.ToDateTime(FechaInicio);
                            campos.FechaFin = Convert.ToDateTime(FechaFin);
                            if (Session["FechaIniPop"] == null)
                            {
                                Session.Add("FechaIniPop", campos.FechaIni);
                                Session.Add("FechaFinPop", campos.FechaFin);
                                Session.Add("FechaFinDescPop", campos.FechaFinDesc);
                            }

                            campos.Sucursal = itmSuc.Value;
                            campos.Id = 0;
                            campos.blnMarca = true;

                            lstSucursales.Add(campos);
                            Session.Add("lstSucursales", lstSucursales);
                        }
                    }
                }
            }

            Session.Add("lstSucursales", lstSucursales);
            lblregistros.Text = "Total registros: " + lstSucursales.Count.ToString();
            grvPromDobleAcumulacion.DataSource = lstSucursales;
            grvPromDobleAcumulacion.PageSize = 8;
            grvPromDobleAcumulacion.DataBind();
            limpiarCamposPopup();
        }
        //private void AgregarMasivamenteElementosSucursales(RadAsyncUpload fuSucursales)
        //{

        //    List<ModSucursales> lstDepurada = new List<ModSucursales>();
        //    List<ModSucursales> lstSuc = new List<ModSucursales>();
        //    string file = "";

        //    //====================================================================================================================
        //    string savePath = "~/UploadedFiles/Procesados/";
        //    savePath += fuSucursales.UploadedFiles[0].FileName;
        //    file = Server.MapPath(savePath);

        //    //valida existencia de archivo
        //    if (File.Exists(Server.MapPath(savePath)))
        //    {
        //        //Elimina archivo existente
        //        File.Delete(Server.MapPath(savePath));
        //    }

        //    //guarda archivo en ruta
        //    fuSucursales.UploadedFiles[0].SaveAs(Server.MapPath(savePath), false);


        //    //usamos el objeto FileStream para recuperar el archivo
        //    SLDocument sl;
        //    using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        //    {
        //        //Creamos el obejto SLDocument para cargar el archivo Excel
        //        sl = new SLDocument(fs);
        //        fs.Close();
        //        fs.Dispose();
        //        File.Delete(Server.MapPath(savePath));

        //        int rowIndex = 1;
        //        int intSucursal = 0;


        //        while (!string.IsNullOrEmpty(sl.GetCellValueAsString(rowIndex, 1)))
        //        {
        //            ModSucursales campos = new ModSucursales();
        //            intSucursal = ObtenEquivalenciaSucursal(sl.GetCellValueAsString(rowIndex, 1).ToString());

        //            //Cuando el valor de intSucursal sea  99999 este sera excluido debido aque corresponde a una sucutsal no existente

        //            if (intSucursal != 99999)
        //            {
        //                campos.CveSucursal = sl.GetCellValueAsString(rowIndex, 1).ToString();
        //                campos.IdSucursal = intSucursal;

        //                lstSuc.Add(campos);
        //            }
        //            rowIndex += 1;
        //        }
        //    }
        //    //====================================================================================================================

        //    //Excluye Duplicados
        //    var lstSucDepurada = lstSuc.Select(s => s.IdSucursal).Distinct().ToList();

        //    string cveSucursal = "";

        //    foreach (int reg in lstSucDepurada)
        //    {
        //        ModSucursales campos = new ModSucursales();
        //        campos.IdSucursal = reg;
        //        //Obtiene la cve de la sucursal
        //        cveSucursal = lstSuc.Where(w => w.IdSucursal == reg).Select(s => s.CveSucursal).FirstOrDefault().ToString();
        //        campos.CveSucursal = cveSucursal;

        //        lstDepurada.Add(campos);
        //    }


        //    //===============================================================================================================
        //    //Construcción de lista para alimentar el grid de sucursales
        //    string FechaFinDesc = "";
        //    string FechaInicio = "";
        //    string FechaFin = "";
        //    List<ModPromoDobleAcumulacion> lstSucursales = new List<ModPromoDobleAcumulacion>();
        //    AdministraPromocion ejecuta = new AdministraPromocion();


        //    foreach (ModSucursales itmSuc in lstDepurada)
        //    {
        //        ModPromoDobleAcumulacion campos = new ModPromoDobleAcumulacion();
        //        if (itmSuc.IdSucursal != 0)
        //        {

        //            campos = new ModPromoDobleAcumulacion();
        //            campos.Nombre = txtDescripcion.Text;
        //            campos.FechaIni = Convert.ToDateTime(rdpFechaInicio.SelectedDate);


        //            if (rdpFechaFinDesc.SelectedDate != null)
        //            {
        //                campos.FechaFinDesc = Convert.ToDateTime(rdpFechaFinDesc.SelectedDate);
        //                FechaFinDesc = campos.FechaFinDesc.ToShortDateString() + " 23:59:59";
        //                campos.FechaFinDesctxt = FechaFinDesc;
        //                campos.Porcentaje = Convert.ToInt32(txtDescInampam.Text);
        //                grvPromDobleAcumulacion.Columns[6].Visible = true;
        //            }
        //            else
        //            {
        //                campos.FechaFinDesctxt = "No asignada";
        //                campos.FechaFinDesc = Convert.ToDateTime(rdpFechaFin.SelectedDate);//No se tomara en cuenta esta fecha
        //                campos.FechaFinDesc = Convert.ToDateTime(campos.FechaFinDesc.ToShortDateString() + " 23:59:59");
        //                campos.Porcentaje = 0;
        //            }

        //            FechaInicio = campos.FechaIni.ToShortDateString() + " 00:00:00";
        //            campos.FechaIni = Convert.ToDateTime(FechaInicio);
        //            if (chkCupon.Checked)
        //            {
        //                campos.FechaFin = Convert.ToDateTime(rdpFechaFin.SelectedDate);
        //                FechaFin = campos.FechaFin.ToShortDateString() + " 23:59:59";
        //                campos.FechaFin = Convert.ToDateTime(FechaFin);
        //            }
        //            else
        //            {
        //                campos.FechaFin = campos.FechaIni;
        //            }


        //            if (Session["FechaIniPop"] == null)
        //            {
        //                Session.Add("FechaIniPop", campos.FechaIni);
        //                Session.Add("FechaFinPop", campos.FechaFin);
        //                Session.Add("FechaFinDescPop", campos.FechaFinDesc);
        //            }
        //            campos.Sucursal = itmSuc.IdSucursal.ToString();
        //            campos.CveSucursal = itmSuc.CveSucursal.ToString();
        //            campos.Id = 0;
        //            campos.blnMarca = true;

        //            lstSucursales.Add(campos);
        //            Session.Add("lstSucursales", lstSucursales);
        //        }
        //    }

        //    Session.Add("CargaMasiva", lstSucursales);
        //    lblregistros.Text = "Total registros: " + lstSucursales.Count.ToString();
        //    grvPromDobleAcumulacion.DataSource = lstSucursales;
        //    grvPromDobleAcumulacion.PageSize = 8;
        //    grvPromDobleAcumulacion.DataBind();
        //    limpiarCamposPopup();
        //}

        private void AgregarMasivamenteElementosSucursales(RadAsyncUpload fuSucursales)
        {

            List<ModSucursales> lstDepurada = new List<ModSucursales>();
            List<ModSucursales> lstSuc = new List<ModSucursales>();
            string file = "";

            //====================================================================================================================
            string savePath = "~/UploadedFiles/Procesados/";
            savePath += fuSucursales.UploadedFiles[0].FileName;
            file = Server.MapPath(savePath);

            //valida existencia de archivo
            if (File.Exists(Server.MapPath(savePath)))
            {
                //Elimina archivo existente
                File.Delete(Server.MapPath(savePath));
            }

            //guarda archivo en ruta
            fuSucursales.UploadedFiles[0].SaveAs(Server.MapPath(savePath), false);


            //usamos el objeto FileStream para recuperar el archivo
            SLDocument sl;
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //Creamos el obejto SLDocument para cargar el archivo Excel
                sl = new SLDocument(fs);
                fs.Close();
                fs.Dispose();
                File.Delete(Server.MapPath(savePath));

                int rowIndex = 1;
                int intSucursal = 0;


                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(rowIndex, 1)))
                {
                    ModSucursales campos = new ModSucursales();
                    intSucursal = ObtenEquivalenciaSucursal(sl.GetCellValueAsString(rowIndex, 1).ToString());

                    //Cuando el valor de intSucursal sea  99999 este sera excluido debido aque corresponde a una sucutsal no existente

                    if (intSucursal != 99999)
                    {
                        campos.CveSucursal = sl.GetCellValueAsString(rowIndex, 1).ToString();
                        campos.IdSucursal = intSucursal;

                        lstSuc.Add(campos);
                    }
                    rowIndex += 1;
                }
            }
            //====================================================================================================================

            //Excluye Duplicados
            var lstSucDepurada = lstSuc.Select(s => s.IdSucursal).Distinct().ToList();

            string cveSucursal = "";

            foreach (int reg in lstSucDepurada)
            {
                ModSucursales campos = new ModSucursales();
                campos.IdSucursal = reg;
                //Obtiene la cve de la sucursal
                cveSucursal = lstSuc.Where(w => w.IdSucursal == reg).Select(s => s.CveSucursal).FirstOrDefault().ToString();
                campos.CveSucursal = cveSucursal;

                lstDepurada.Add(campos);
            }


            //===============================================================================================================
            //Construcción de lista para alimentar el grid de sucursales
            string FechaFinDesc = "";
            string FechaInicio = "";
            string FechaFin = "";
            List<ModPromoDobleAcumulacion> lstSucursales = new List<ModPromoDobleAcumulacion>();
            AdministraPromocion ejecuta = new AdministraPromocion();


            foreach (ModSucursales itmSuc in lstDepurada)
            {
                ModPromoDobleAcumulacion campos = new ModPromoDobleAcumulacion();
                if (itmSuc.IdSucursal != 0)
                {

                    campos = new ModPromoDobleAcumulacion();
                    campos.Nombre = txtDescripcion.Text;
                    campos.FechaIni = Convert.ToDateTime(rdpFechaInicio.SelectedDate);


                    if (rdpFechaFinDesc.SelectedDate != null)
                    {
                        campos.FechaFinDesc = Convert.ToDateTime(rdpFechaFinDesc.SelectedDate);
                        FechaFinDesc = campos.FechaFinDesc.ToShortDateString() + " 23:59:59";
                        campos.FechaFinDesctxt = FechaFinDesc;
                        campos.Porcentaje = Convert.ToInt32(txtDescInampam.Text);
                        grvPromDobleAcumulacion.Columns[6].Visible = true;
                    }
                    else
                    {
                        campos.FechaFinDesctxt = "No asignada";
                        campos.FechaFinDesc = Convert.ToDateTime(rdpFechaFin.SelectedDate);//No se tomara en cuenta esta fecha
                        campos.FechaFinDesc = Convert.ToDateTime(campos.FechaFinDesc.ToShortDateString() + " 23:59:59");
                        campos.Porcentaje = 0;
                    }

                    FechaInicio = campos.FechaIni.ToShortDateString() + " 00:00:00";
                    campos.FechaIni = Convert.ToDateTime(FechaInicio);
                    if (chkCupon.Checked)
                    {
                        campos.FechaFin = Convert.ToDateTime(rdpFechaFin.SelectedDate);
                        FechaFin = campos.FechaFin.ToShortDateString() + " 23:59:59";
                        campos.FechaFin = Convert.ToDateTime(FechaFin);
                    }
                    else
                    {
                        campos.FechaFin = campos.FechaIni;
                    }


                    if (Session["FechaIniPop"] == null)
                    {
                        Session.Add("FechaIniPop", campos.FechaIni);
                        Session.Add("FechaFinPop", campos.FechaFin);
                        Session.Add("FechaFinDescPop", campos.FechaFinDesc);
                    }
                    campos.Sucursal = itmSuc.IdSucursal.ToString();
                    campos.CveSucursal = itmSuc.CveSucursal.ToString();
                    campos.Id = 0;
                    campos.blnMarca = true;

                    lstSucursales.Add(campos);
                    Session.Add("lstSucursales", lstSucursales);
                }
            }

            Session.Add("CargaMasiva", lstSucursales);
            lblregistros.Text = "Total registros: " + lstSucursales.Count.ToString();
            grvPromDobleAcumulacion.DataSource = lstSucursales;
            grvPromDobleAcumulacion.PageSize = 8;
            grvPromDobleAcumulacion.DataBind();
            limpiarCamposPopup();
        }
        private void CargalstPromoVigentes()
        {
            try
            {
                if (Session["lstSucursales"] == null)
                {
                    DateTime FechaActual;
                    List<ModPromoDobleAcumulacion> lstRespuesta = new List<ModPromoDobleAcumulacion>();
                    List<ModSucursales> lstAlmacenIdSucursales = new List<ModSucursales>();
                    AdministraPromocion Ejecuta = new AdministraPromocion();

                    lstAlmacenIdSucursales = Ejecuta.ObtenSucursales(CnnProductivo);
                    lstRespuesta = Ejecuta.ObtenPromoDobleAcumulacionSuc(CnnProductivo, Convert.ToInt32(Session["Id"]), lstAlmacenIdSucursales);

                    grvPromDobleAcumulacion.DataSource = null;
                    grvPromDobleAcumulacion.DataBind();
                    FechaActual = DateTime.Now;

                    if (lstRespuesta.Count > 0)
                    {
                        Session.Add("lstSucursales", lstRespuesta);
                        lblregistros.Text = "Total registros: " + lstRespuesta.Count.ToString();
                        grvPromDobleAcumulacion.DataSource = lstRespuesta;
                        grvPromDobleAcumulacion.PageSize = 8;
                        grvPromDobleAcumulacion.DataBind();

                        if (lstRespuesta[0].FechaFinDesc.ToString() != "01/01/0001 12:00:00 a. m.")
                        {//Si la fecha Fin descuento es diferente del valor default del control corresponde a un a promo de descuento INAPAM
                            chkDescINAPAM.Checked = true;
                            chkDescINAPAM.Enabled = false;
                            chkApertura.Checked = false;
                            chkApertura.Enabled = false;
                            chkCupon.Checked = false;
                            chkCupon.Enabled = false;
                        }

                        if (lstRespuesta[0].Cupon != "0")
                        {//Si la contiene un cupón asignado a la promoción corresponde a una promo que se rije por un cupón
                            chkCupon.Checked = true;
                            chkCupon.Enabled = false;
                            rcbCupones.SelectedValue = lstRespuesta[0].Cupon;
                            rcbCupones.Visible = true;
                            rcbCupones.Enabled = false;
                            chkApertura.Checked = false;
                            chkApertura.Enabled = false;
                            chkDescINAPAM.Checked = false;
                            chkDescINAPAM.Enabled = false;
                        }

                        if (lstRespuesta[0].SoloActivaciones == 1)
                        {
                            rdbSoloAct.Checked = true;
                            rdbTodas.Checked = false;
                        }
                        else
                        {
                            rdbSoloAct.Checked = false;
                            rdbTodas.Checked = true;
                        }
                    }
                    else
                    {
                        chkCupon.Checked = false;
                        chkCupon.Enabled = true;
                        chkApertura.Checked = false;
                        chkApertura.Enabled = false;
                        chkDescINAPAM.Checked = false;
                        chkDescINAPAM.Enabled = true;
                    }
                }
                else
                {
                    List<ModPromoDobleAcumulacion> lst = (List<ModPromoDobleAcumulacion>)Session["lstSucursales"];
                    lblregistros.Text = "Total registros: " + lst.Count.ToString();
                    grvPromDobleAcumulacion.DataSource = lst;
                    grvPromDobleAcumulacion.PageSize = 8;
                    grvPromDobleAcumulacion.DataBind();
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromoDobleAcumulacion", "CargalstPromoVigentes", "Ejecuta.ObtenPromoDobleAcumulacionSuc()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar Obtener promociones vigentes, contacte al administrador.");
            }
        }
        private void CargaComboSucursales()
        {
            AdministraPromocion ejecuta = new AdministraPromocion();
            try
            {
                List<ModSucursales> lstResultados = new List<ModSucursales>();
                lstResultados = ejecuta.ObtenSucursales(CnnProductivo);
                Session.Add("lstCatSucursales", lstResultados);


                if (lstResultados != null)
                {
                    if (lstResultados.Count > 0)
                    {
                        rcbSucursales.Items.Clear();
                        rcbSucursales.DataSource = lstResultados;
                        rcbSucursales.DataTextField = "Sucursal";
                        rcbSucursales.DataValueField = "IdSucursal";
                        rcbSucursales.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromoDobleAcumulacion", "CargaComboSucursales()", "ejecuta.ObtenSucursales(" + CnnProductivo + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar sucursales, contacte al administrador");
            }

        }
        private void CargaComboCupones()
        {
            AdministraPromocion ejecuta = new AdministraPromocion();
            try
            {
                List<ModCupones> lstResultados = new List<ModCupones>();
                if (Session["Alta"] != null)
                {//Alta
                    lstResultados = ejecuta.ObtenCupones(1);
                }
                else
                {//Modificación
                    lstResultados = ejecuta.ObtenCupones(2);
                }

                if (lstResultados != null)
                {
                    if (lstResultados.Count > 0)
                    {
                        rcbCupones.Items.Clear();
                        rcbCupones.DataSource = lstResultados;
                        rcbCupones.DataTextField = "Cupones";
                        rcbCupones.DataValueField = "IdCupon";


                        rcbCupones.SelectedValue = "-1";
                        rcbCupones.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromoDobleAcumulacion", "CargaComboSucursales()", "ejecuta.ObtenSucursales(" + CnnProductivo + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar sucursales, contacte al administrador");
            }
        }
        private void OrigenListado()
        {
            List<ModPromoDobleAcumulacion> lstSucursales = new List<ModPromoDobleAcumulacion>();

            if (Session["lstSucursales"] != null)
            {
                //setea el contenido de la variable de session al objeto lista
                lstSucursales = (List<ModPromoDobleAcumulacion>)Session["lstSucursales"];
            }

            grvPromDobleAcumulacion.DataSource = lstSucursales;
            grvPromDobleAcumulacion.PageSize = 8;
            grvPromDobleAcumulacion.DataBind();
        }
        private int ObtenEquivalenciaSucursal(string Sucursal)
        {
            int intRespuesta = 0;

            AdministraPromocion Ejecutar = new AdministraPromocion();
            intRespuesta = Ejecutar.RegresaIdSucursal(Sucursal);

            return intRespuesta;
        }
        private void GuardarNvaPromocion()
        {
            int intIdPromo;

            try
            {
                if (ValidacionesFechas())
                {
                    AdministraPromocion ejecuta = new AdministraPromocion();
                    ModPromoDobleAcumulacion campos = new ModPromoDobleAcumulacion();

                    campos.Nombre = txtDescripcion.Text;
                    DateTime @FechaIni = Convert.ToDateTime(rdpFIni.SelectedDate);
                    campos.FechaIni = Convert.ToDateTime(rdpFIni.SelectedDate);
                    DateTime @FechaFin = Convert.ToDateTime(rdpFFin.SelectedDate);
                    campos.FechaFin = Convert.ToDateTime(rdpFFin.SelectedDate);

                    if (chkApertura.Checked)
                    {
                        campos.Cantidad = 2;
                    }
                    else
                    {
                        campos.Cantidad = 1;
                    }

                    if (rdbSoloAct.Checked)
                    {
                        campos.SoloActivaciones = 1;
                    }
                    else
                    {
                        campos.SoloActivaciones = 0;
                    }


                    if (Session["Modificacion"] == null) //(ALTA)
                    {
                        intIdPromo = ejecuta.GuardarPromoDobleAcumulacionHeader(CnnProductivo, campos);
                        //====================================================

                        if (Convert.ToInt32(Session["selSucursal"]) > 0)
                        {
                            int contador = 0;
                            foreach (ModPromoDobleAcumulacion reg in (List<ModPromoDobleAcumulacion>)Session["lstSucursales"])
                            {
                                campos.IdPromo = intIdPromo;
                                campos.FechaIni = reg.FechaIni; // Convert.ToDateTime(rdpFechaInicio.SelectedDate);
                                campos.FechaFin = reg.FechaFin;  //Convert.ToDateTime(rdpF.SelectedDate);
                                campos.Sucursal = reg.Sucursal;
                                campos.FechaFinDesc = reg.FechaFinDesc;
                                campos.Porcentaje = reg.Porcentaje;
                                campos.Cupon = rcbCupones.Text;



                                //Valida la existencia de la promoción en dbase, el valor de campo IdPromo siempre sera 0 para la validacion unicamnete ya que es un nuevo registro apesar de que se cuente con el IDPROMO
                                int intRespuesta = ejecuta.ValidarExistenciaPromociones(CnnProductivo, 0, campos.Cupon, campos.Sucursal, campos.FechaIni.ToString(), campos.FechaFin.ToString());
                                if (intRespuesta == 0)
                                {
                                    //RegistrarLog
                                    ejecuta.RegistrarLog(CnnProductivo, campos.Id, campos.IdPromo, campos.Nombre, @FechaIni, @FechaFin, campos.FechaIni, campos.FechaFin, campos.FechaFinDesc, campos.Porcentaje, campos.Sucursal, 1, HttpContext.Current.User.Identity.Name, "A");
                                    //Guarda cada una de las promociones por sucursal
                                    ejecuta.GuardarPromoDobleAcumulacionDetalle(CnnProductivo, campos);



                                    //Nva Funcionalidad (guarda Idpromo y el id del cupón seleccionado)
                                    //la variable contador se utiliza para controlar la unica vez que debe de insertar los valores
                                    //ya que se encuentra dentro de una iteración y solo debe ser insertado 1 vez
                                    if (rcbCupones.SelectedValue != "-1" && contador == 0)
                                    {
                                        ModPromoCupon campoPromCupon = new ModPromoCupon();

                                        campoPromCupon.IdPromoCategoria = intIdPromo;
                                        campoPromCupon.IdCupon = Convert.ToInt32(rcbCupones.SelectedValue);
                                        campoPromCupon.IdStatus = 1;

                                        ejecuta.GuardarPromoCupon(campoPromCupon);
                                    }

                                }
                                else
                                {
                                    if (rcbSucursales.SelectedValue != "0")
                                    {
                                        Mensajes("La sucursal " + campos.Sucursal + ", que desea asociar a la promoción ya existe.");
                                    }
                                    else
                                    {
                                        Mensajes("Imposible asociar todas las sucursales, Ya existen para esta promoción.");
                                    }

                                }
                                contador += 1;
                            }
                        }
                        else if (Session["CargaMasiva"] != null)
                        {
                            // GuardarNvaPromocion TODAS las sucursales
                            List<ModPromoDobleAcumulacion> lstSucursales = new List<ModPromoDobleAcumulacion>();
                            lstSucursales = (List<ModPromoDobleAcumulacion>)Session["CargaMasiva"];

                            foreach (ModPromoDobleAcumulacion reg in lstSucursales)
                            {
                                campos.IdPromo = intIdPromo;
                                campos.FechaIni = Convert.ToDateTime(Session["FechaIniPop"]);
                                campos.FechaFin = Convert.ToDateTime(Session["FechaFinPop"]);
                                campos.FechaFinDesc = Convert.ToDateTime(Session["FechaFinDescPop"]);
                                campos.Sucursal = reg.Sucursal;
                                campos.Cupon = rcbCupones.Text;

                                if (chkDescINAPAM.Checked)
                                {
                                    campos.Porcentaje = Convert.ToInt32(txtDescInampam.Text);
                                }
                                else
                                {
                                    campos.Porcentaje = 0;
                                }

                                //Valida la existencia de la promoción en dbase, el valor de campo IdPromo siempre sera 0 para la validacion unicamnete ya que es un nuevo registro apesar de que se cuente con el IDPROMO
                                int intRespuesta = ejecuta.ValidarExistenciaPromociones(CnnProductivo, 0, campos.Cupon, campos.Sucursal, campos.FechaIni.ToString(), campos.FechaFin.ToString());
                                if (intRespuesta == 0)
                                {
                                    //RegistrarLog
                                    //ejecuta.RegistrarLog(CnnProductivo, campos.Id, campos.IdPromo, campos.Nombre, @FechaIni, @FechaFin, campos.FechaIni, campos.FechaFin, "0", 1, HttpContext.Current.User.Identity.Name, "A");
                                    ejecuta.RegistrarLog(CnnProductivo, campos.Id, campos.IdPromo, campos.Nombre, @FechaIni, @FechaFin, campos.FechaIni, campos.FechaFin, campos.FechaFinDesc, campos.Porcentaje, "0", 1, HttpContext.Current.User.Identity.Name, "A");
                                    //Guarda todas las sucursales asociadas a una promoción
                                    ejecuta.GuardarPromoDobleAcumulacionDetalle(CnnProductivo, campos);
                                }
                                else
                                {
                                    Mensajes("Imposible continuar ya existe una promoción vigente con todas las sucursales.");
                                    return;
                                }
                            }

                            //Nva Funcionalidad (guarda Idpromo y el id del cupón seleccionado)
                            if (rcbCupones.SelectedValue != "-1")
                            {
                                ModPromoCupon campoPromCupon = new ModPromoCupon();

                                campoPromCupon.IdPromoCategoria = intIdPromo;
                                campoPromCupon.IdCupon = Convert.ToInt32(rcbCupones.SelectedValue);
                                campoPromCupon.IdStatus = 1;

                                ejecuta.GuardarPromoCupon(campoPromCupon);
                            }

                            limpiarCamposPopup();

                        }
                        else if (Convert.ToInt32(Session["selSucursal"]) > -1)
                        {
                            // GuardarNvaPromocion TODAS las sucursales
                            campos.IdPromo = intIdPromo;
                            campos.FechaIni = Convert.ToDateTime(Session["FechaIniPop"]);
                            campos.FechaFin = Convert.ToDateTime(Session["FechaFinPop"]);
                            campos.FechaFinDesc = Convert.ToDateTime(Session["FechaFinDescPop"]);
                            campos.Sucursal = "0";
                            campos.Cupon = rcbCupones.Text;
                            if (chkDescINAPAM.Checked)
                            {
                                campos.Porcentaje = Convert.ToInt32(txtDescInampam.Text);
                            }
                            else
                            {
                                campos.Porcentaje = 0;
                            }


                            if (campos.FechaIni.ToString() == campos.FechaFin.ToString())
                            {//Se asigna la fecha Fin descuento ya que se trata de una promocion de descuento
                                campos.FechaFin = campos.FechaFinDesc;
                            }

                            //Valida la existencia de la promoción en dbase, el valor de campo IdPromo siempre sera 0 para la validacion unicamnete ya que es un nuevo registro apesar de que se cuente con el IDPROMO
                            int intRespuesta = ejecuta.ValidarExistenciaPromociones(CnnProductivo, 0, campos.Cupon, campos.Sucursal, campos.FechaIni.ToString(), campos.FechaFin.ToString());
                            if (intRespuesta == 0)
                            {
                                //RegistrarLog
                                //ejecuta.RegistrarLog(CnnProductivo, campos.Id, campos.IdPromo, campos.Nombre, @FechaIni, @FechaFin, campos.FechaIni, campos.FechaFin, "0", 1, HttpContext.Current.User.Identity.Name, "A");
                                ejecuta.RegistrarLog(CnnProductivo, campos.Id, campos.IdPromo, campos.Nombre, @FechaIni, @FechaFin, campos.FechaIni, campos.FechaFin, campos.FechaFinDesc, campos.Porcentaje, "0", 1, HttpContext.Current.User.Identity.Name, "A");
                                //Guarda todas las sucursales asociadas a una promoción
                                ejecuta.GuardarPromoDobleAcumulacionDetalle(CnnProductivo, campos);
                            }
                            else
                            {
                                Mensajes("Imposible continuar ya existe una promoción vigente con todas las sucursales.");
                                return;
                            }


                            //Nva Funcionalidad (guarda Idpromo y el id del cupón seleccionado)
                            if (rcbCupones.SelectedValue != "-1")
                            {
                                ModPromoCupon campoPromCupon = new ModPromoCupon();

                                campoPromCupon.IdPromoCategoria = intIdPromo;
                                campoPromCupon.IdCupon = Convert.ToInt32(rcbCupones.SelectedValue);
                                campoPromCupon.IdStatus = 1;

                                ejecuta.GuardarPromoCupon(campoPromCupon);
                            }

                            limpiarCamposPopup();
                        }

                        LimpiarCampos();
                        grvPromDobleAcumulacion.Visible = false;
                        Session.Contents.Remove("Alta");
                        Session.Remove("Alta");
                        EliminarVariablesSession();
                        Mensajes_Redirect("La promoción de apertura fue registrada correctamente.");

                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromoDobleAcumulacion", "GuardarNvaPromocion", "Ejecuta.GuardarPromoDobleAcumulacionHeader()/Ejecuta.GuardarPromoDobleAcumulacionDetalle()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar Guardar una nueva promoción, contacte al administrador.");
            }
        }
        private void ModificarPromocion()
        {
            bool blnFinalizoAlgunaPromo = false;
            string TipoMov = "";
            int intRespuestaValidacion = 0;
            bool blnRespuesta = false;
            AdministraPromocion ejecuta = new AdministraPromocion();
            ModPromoDobleAcumulacion campos = new ModPromoDobleAcumulacion();

            //Verifica si procede a finalizar promociones 2x y/o de descuento
            blnFinalizoAlgunaPromo = FinalizarPromociones();


            try
            {
                TipoMov = "M"; //Modificación
                int @ID_promoXCategoria = Convert.ToInt32(Session["Id"]);
                campos.IdPromo = Convert.ToInt32(Session["Id"]);
                string @NombrePromo = txtDescripcion.Text;
                campos.Nombre = txtDescripcion.Text;
                DateTime @FechaIniPromo = Convert.ToDateTime(rdpFIni.SelectedDate);
                campos.FechaIni = Convert.ToDateTime(rdpFIni.SelectedDate);
                DateTime @FechaFinPromo = Convert.ToDateTime(rdpFFin.SelectedDate);
                campos.FechaFin = Convert.ToDateTime(rdpFFin.SelectedDate);
                campos.Estatus = 1;

                string strFI = @FechaIniPromo.ToShortDateString();
                string strFF = @FechaFinPromo.ToShortDateString();
                if (strFI == strFF)
                {
                    //campos.Estatus = 2;
                    TipoMov = "E"; //Eliminación
                }

                //Nva funcionalidad
                ModPromoCupon campoPromCupon = new ModPromoCupon();

                if (rcbCupones.SelectedValue != "-1")
                {
                    campoPromCupon.IdPromoCategoria = Convert.ToInt32(Session["Id"]);
                    campoPromCupon.IdStatus = 1;
                    campoPromCupon.IdCupon = Convert.ToInt32(rcbCupones.SelectedValue);
                }
                else
                {
                    campoPromCupon.IdPromoCategoria = Convert.ToInt32(Session["Id"]);
                    campoPromCupon.IdStatus = 2;
                    campoPromCupon.IdCupon = 0;
                }
                ejecuta.ModificarPromoCupon(campoPromCupon);

                if (chkApertura.Checked)
                {
                    campos.Cantidad = 2;
                }
                else
                {
                    campos.Cantidad = 1;
                }

                if (rdbSoloAct.Checked)
                {
                    campos.SoloActivaciones = 1;
                }
                else
                {
                    campos.SoloActivaciones = 0;
                }


                blnRespuesta = ejecuta.ModificarPromoDobleAcumulacionHeader(CnnProductivo, campos);
                if (blnRespuesta)
                {
                    List<ModPromoDobleAcumulacion> lstPromSucursales = new List<ModPromoDobleAcumulacion>();
                    lstPromSucursales = (List<ModPromoDobleAcumulacion>)Session["lstSucursales"];
                    lstPromSucursales = lstPromSucursales.Where(w => w.blnMarca == true).ToList();

                    if (lstPromSucursales.Count > 0)
                    {
                        foreach (ModPromoDobleAcumulacion reg in lstPromSucursales)
                        {
                            campos.Id = reg.Id;
                            campos.IdPromo = campos.IdPromo;
                            campos.FechaIni = reg.FechaIni;
                            campos.FechaFin = reg.FechaFin;
                            campos.FechaFinDesc = reg.FechaFinDesc;
                            campos.Porcentaje = reg.Porcentaje;
                            campos.Cupon = rcbCupones.Text;

                            if (reg.Sucursal.Length > 5)
                            {
                                reg.Sucursal = reg.Sucursal.Substring(0, reg.Sucursal.IndexOf(" -"));
                            }
                            campos.Sucursal = reg.Sucursal;

                            if (campos.Id != 0)
                            {
                                //RegistrarLog
                                ejecuta.RegistrarLog(CnnProductivo, campos.Id, campos.IdPromo, @NombrePromo, @FechaIniPromo, @FechaFinPromo, campos.FechaIni, campos.FechaFin, campos.FechaFinDesc, campos.Porcentaje, campos.Sucursal, campos.Estatus, HttpContext.Current.User.Identity.Name, TipoMov);
                            }
                            else if (campos.Id == 0)//Alta de promocion asociada a una sucursal
                            {
                                //Realiza validación de existencia de promociones para nuevos registros
                                intRespuestaValidacion = ejecuta.ValidarExistenciaPromociones(CnnProductivo, campos.IdPromo, campos.Cupon, campos.Sucursal, campos.FechaIni.ToString(), campos.FechaFin.ToString());
                            }

                            if (intRespuestaValidacion == 0)//Puede registrar promoción asociada ala sucursal asignada
                            {
                                //Realiza modificaciones y alta de nuevos registrso para sucursales
                                if (Session["SeEliminoReg"] != null)
                                {
                                    blnRespuesta = ejecuta.ModificarPromoDobleAcumulacionSuc(CnnProductivo, campos, true, chkCupon.Checked, chkDescINAPAM.Checked);
                                }
                                else
                                {
                                    blnRespuesta = ejecuta.ModificarPromoDobleAcumulacionSuc(CnnProductivo, campos, false, chkCupon.Checked, chkDescINAPAM.Checked);
                                }
                            }
                            else if (intRespuestaValidacion > 0)
                            {
                                Mensajes_Redirect("No fue posible asociar la sucursal: " + campos.Sucursal + " a la promoción, debido a que ya existe dentro del rangos de vigencia.");
                            }
                        }
                    }
                    else
                    {
                        if (blnFinalizoAlgunaPromo)
                        {
                            LimpiarCampos();
                            grvPromDobleAcumulacion.Visible = false;
                            Session.Contents.Remove("Alta");
                            Session.Remove("Alta");
                            Session.Contents.Remove("Modificacion");
                            Session.Remove("Modificacion");
                            EliminarVariablesSession();
                            //Implementar consulta para mostrar los nvos reg en el grid
                            Mensajes_Redirect("La promoción de apertura fue modificada correctamente.");
                            return;
                        }
                    }

                    if (blnRespuesta)
                    {
                        LimpiarCampos();
                        grvPromDobleAcumulacion.Visible = false;
                        EliminarVariablesSession();
                        //Implementar consulta para mostrar los nvos reg en el grid
                        Mensajes_Redirect("La promoción de apertura fue modificada correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromoDobleAcumulacion", "ModificarPromocion", "Ejecuta.ModificarPromoDobleAcumulacionSuc()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes_Redirect("Ocurrio un error al intentar Modificar una nueva promoción, contacte al administrador.");
            }
        }
        private bool ValidacionesFechas()
        {
            bool blnRespuesta = true;

            //sin editar Promoción existente
            //if (Session["Modificacion"] == null)
            //{
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                txtDescripcion.Focus();
                Mensajes("Es necesario proporcione un nombre descriptivo a la nueva promoción.");
                blnRespuesta = false;
                return blnRespuesta;
            }

            if (rdpFIni.SelectedDate == null)
            {
                rdpFIni.Focus();
                Mensajes("Es necesario proporcione una fecha inicio a la promoción.");
                blnRespuesta = false;
                return blnRespuesta;
            }

            if (rdpFFin.SelectedDate == null)
            {
                rdpFFin.Focus();
                Mensajes("Es necesario proporcione una fecha fin a la promoción.");
                blnRespuesta = false;
                return blnRespuesta;
            }



            if (Session["lstSucursales"] == null)
            {
                Mensajes("Es necesario asignar una sucursal a la promoción.");
                btnAgregarSucursal_Click(null, null);
                blnRespuesta = false;
                return blnRespuesta;
            }
            //}

            return blnRespuesta;
        }
        private bool ValidacionesPopup()
        {
            bool blnRespuesta = true;

            if (!rdbCargaEspecifica.Checked && !rdbCargaMasiva.Checked)
            {
                Mensajes("Es necesario seleccionar el tipo de carga de sucursales.");
                blnRespuesta = false;
                return blnRespuesta;
            }

            if (rdbCargaMasiva.Checked && FileUplSuc.UploadedFiles.Count == 0)
            {
                Mensajes("Debé seleccionar archivo de excel.");
                blnRespuesta = false;
                return blnRespuesta;
            }

            if (rdbCargaEspecifica.Checked && string.IsNullOrWhiteSpace(rcbSucursales.SelectedValue))
            {
                Mensajes("Es necesario asignar una sucursal a la promoción.");
                rcbSucursales.Focus();
                blnRespuesta = false;
                return blnRespuesta;
            }

            if (rdpFechaInicio.SelectedDate == null)
            {
                Mensajes("Es necesario seleccione una fecha Inicio.");
                rdpFechaInicio.Focus();
                blnRespuesta = false;
                return blnRespuesta;
            }

            if (Session["Alta"] != null)//Si es una alta de promoción valida este escenario
            {
                if (rdpFechaInicio.SelectedDate < DateTime.Now.Date)
                {
                    Mensajes("No es posible que la fecha inicio sea menor a la fecha actual.");
                    rdpFechaInicio.Enabled = false;
                    rdpFechaInicio.Focus();
                    blnRespuesta = false;
                    return blnRespuesta;
                }
            }


            //Promocion de apertura por CUPON
            if (chkCupon.Checked)
            {
                if (rdpFechaFin.SelectedDate == null)
                {
                    Mensajes("Es necesario seleccione una fecha Fin.");
                    rdpFechaFin.Focus();
                    blnRespuesta = false;
                    return blnRespuesta;
                }

                if (rdpFechaFin.SelectedDate < rdpFechaInicio.SelectedDate)
                {
                    Mensajes("No es posible que la fecha fin sea menor a la fecha inicio.");
                    rdpFechaFin.Clear();
                    rdpFechaFin.Focus();
                    blnRespuesta = false;
                    return blnRespuesta;
                }

                if (rdpFechaFin.SelectedDate > rdpFFin.SelectedDate)
                {
                    Mensajes("No es posible que la fecha fin de sucursal sea mayor a la fecha fin de la promoción.");
                    rdpFechaFin.Clear();
                    rdpFechaFin.Focus();
                    blnRespuesta = false;
                    return blnRespuesta;
                }
            }

            //Descuento INAPAM
            if (chkDescINAPAM.Checked)
            {
                if (rdpFechaInicio.SelectedDate == null)
                {
                    Mensajes("Es necesario seleccione una fecha Inicio.");
                    rdpFechaInicio.Focus();
                    blnRespuesta = false;
                    return blnRespuesta;
                }

                if (rdpFechaFinDesc.SelectedDate == null)
                {
                    Mensajes("Es necesario proporcione una fecha fin descuento a la promoción.");
                    rdpFechaFinDesc.Focus();
                    blnRespuesta = false;
                    return blnRespuesta;
                }

                if (rdpFechaFinDesc.SelectedDate < rdpFechaInicio.SelectedDate)
                {
                    Mensajes("No es posible que la fecha fin descuento sea menor a la fecha inicio.");
                    rdpFechaFinDesc.Clear();
                    rdpFechaFinDesc.Focus();
                    blnRespuesta = false;
                    return blnRespuesta;
                }

                if (rdpFechaFinDesc.SelectedDate > rdpFFin.SelectedDate)
                {
                    Mensajes("No es posible que la fecha fin descuento sea mayor a la fecha inicio.");
                    rdpFechaFinDesc.Clear();
                    rdpFechaFinDesc.Focus();
                    blnRespuesta = false;
                    return blnRespuesta;
                }
            }

            return blnRespuesta;
        }
        //public int ValidaPromocionExistente(int IdPromo, string Sucursal, string FechaIni, string FechaFin)
        //{
        //    int intRespuesta = 0;
        //     AdministraPromocion ejecuta = new AdministraPromocion();

        //        intRespuesta = ejecuta.ValidarExistenciaPromociones(CnnProductivo, IdPromo,"", Sucursal, FechaIni, FechaFin);

        //    return intRespuesta;
        //}
        private void LimpiarCampos()
        {
            txtDescripcion.Text = "";
            rdpFIni.SelectedDate = null;
            rdpFFin.SelectedDate = null;
            lblalertaFechaFin.Text = "";
            rcbCupones.ClearSelection();
        }
        private void limpiarCamposPopup()
        {
            rdbCargaMasiva.Checked = false;
            rdbCargaEspecifica.Checked = false;
            FileUplSuc.UploadedFiles.Clear();
            FileUplSuc = new RadAsyncUpload();
            rcbSucursales.Text = "";
            rcbSucursales.ClearSelection();
            rdpFechaInicio.SelectedDate = null;
            rdpFechaFin.SelectedDate = null;
            rdpFechaFinDesc.SelectedDate = null;
        }
        private void EliminarVariablesSession()
        {
            Session.Contents.Remove("Id");
            Session.Remove("Id");
            Session.Contents.Remove("Desc");
            Session.Remove("Desc");
            Session.Contents.Remove("Suc");
            Session.Remove("Suc");
            Session.Contents.Remove("FechaI");
            Session.Remove("FechaI");
            Session.Contents.Remove("FechaF");
            Session.Remove("FechaF");
            Session.Contents.Remove("lstSucursales");
            Session.Remove("lstSucursales");
            Session.Contents.Remove("selSucursal");
            Session.Remove("selSucursal");
            Session.Contents.Remove("FechaIniPop");
            Session.Remove("FechaIniPop");
            Session.Contents.Remove("FechaFinPop");
            Session.Remove("FechaFinPop");
            Session.Contents.Remove("FechaFinDescPop");
            Session.Remove("FechaFinDescPop");
            Session.Contents.Remove("flgDescuento");
            Session.Remove("flgDescuento");
            Session.Contents.Remove("flgDescuento");
            Session.Contents.Remove("EnabledDescuento");
            Session.Remove("EnabledDescuento");
            Session.Remove("flgApertura");
            Session.Contents.Remove("flgApertura");
            Session.Contents.Remove("EnabledAcumulacion");
            Session.Remove("EnabledAcumulacion");
            Session.Contents.Remove("TipoProm");
            Session.Remove("TipoProm");
            Session.Contents.Remove("CargaMasiva");
            Session.Remove("CargaMasiva");
            Session.Contents.Remove("SeEliminoReg");
            Session.Remove("SeEliminoReg");
            Session.Contents.Remove("lstCatSucursales");
            Session.Remove("lstCatSucursales");


        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "Mensajes", "alert('" + outputstring + "');", true);
        }
        private void Mensajes_Redirect(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');window.location = 'PromoDobleAcumulacion.aspx';", true);
        }
        private bool FinalizaPromoDobleAcumulacion()
        {
            bool blnRespuesta = false;
            AdministraPromocion ejecuta = new AdministraPromocion();
            ModPromoDobleAcumulacion campos = new ModPromoDobleAcumulacion();

            List<ModPromoDobleAcumulacion> lstPromSucursales = new List<ModPromoDobleAcumulacion>();
            lstPromSucursales = (List<ModPromoDobleAcumulacion>)Session["lstSucursales"];

            if (lstPromSucursales.Count > 0)
            {
                foreach (ModPromoDobleAcumulacion reg in lstPromSucursales)
                {
                    campos.Id = reg.IdPromo;
                    campos.UsuarioModifica = HttpContext.Current.User.Identity.Name;
                    break;
                }
            }

            blnRespuesta = ejecuta.ModificarPromoDobleAcumulacionSucFechaFin(CnnProductivo, campos);


            return blnRespuesta;

        }
        private bool FinalizaDescuentoINAPAM()
        {
            bool blnRespuesta = false;
            AdministraPromocion ejecuta = new AdministraPromocion();
            ModPromoDobleAcumulacion campos = new ModPromoDobleAcumulacion();

            List<ModPromoDobleAcumulacion> lstPromSucursales = new List<ModPromoDobleAcumulacion>();
            lstPromSucursales = (List<ModPromoDobleAcumulacion>)Session["lstSucursales"];

            if (lstPromSucursales.Count > 0)
            {
                foreach (ModPromoDobleAcumulacion reg in lstPromSucursales)
                {
                    if (lstPromSucursales.Count > 1000)
                    {
                        campos.Id = reg.IdPromo;
                        break;
                    }
                    else
                    {
                        if (reg.FechaFinDesc > DateTime.Now)
                        {
                            string[] suc;
                            suc = reg.Sucursal.Split('-');
                            //afectara solo a las fechas descuento mayores a fechaActual(getdate())
                            campos.Id = reg.IdPromo;
                            campos.UsuarioModifica = HttpContext.Current.User.Identity.Name;
                            campos.Sucursal = suc[0].ToString();
                            blnRespuesta = ejecuta.ModificarPromoDescuento(CnnProductivo, campos);
                        }
                    }
                }
            }

            return blnRespuesta;
        }
        private bool ValidaPromocionExistente()
        {
            bool blnRespuesta = true;

            try
            {
                AdministraPromocion ejecuta = new AdministraPromocion();
                ModPromoDobleAcumulacion campos = new ModPromoDobleAcumulacion();
                int TipoPromo = 0;
                int IdCupon = 0;


                campos.FechaIni = Convert.ToDateTime(rdpFIni.SelectedDate);
                campos.FechaFin = Convert.ToDateTime(rdpFFin.SelectedDate);
                campos.Sucursal = "";
                campos.FechaFinDesc = Convert.ToDateTime(rdpFFin.SelectedDate);


                if (chkDescINAPAM.Checked)
                {
                    TipoPromo = 1;
                }
                if (chkCupon.Checked)
                {
                    TipoPromo = 2;
                    if (rcbCupones.SelectedValue != "-1")
                    {
                        IdCupon = Convert.ToInt32(rcbCupones.SelectedValue);
                    }
                }


                //Valida la existencia de la promoción en dbase
                int intRespuesta = ejecuta.ValidaExistenciaSucursalPromo(CnnProductivo, campos.Sucursal, campos.FechaIni.ToString(), campos.FechaFin.ToString(), campos.FechaFinDesc.ToString(), TipoPromo, IdCupon);

                if (intRespuesta > 0)
                {
                    Session.Contents.Remove("lstSucursales");
                    Session.Remove("lstSucursales");
                    grvPromDobleAcumulacion.DataSource = null;
                    grvPromDobleAcumulacion.DataBind();
                    blnRespuesta = false;
                    blnRespuesta = false;  //Ya existe(n) la(s) sucursal(es)


                    //List<ModPromoDobleAcumulacion> lstElementos = new List<ModPromoDobleAcumulacion>();
                    //lstElementos = (List<ModPromoDobleAcumulacion>)Session["lstSucursales"];
                    //lstElementos = lstElementos.Where(w => w.Sucursal != campos.Sucursal && w.FechaIni != campos.FechaIni && w.FechaFin != campos.FechaFin && w.FechaFinDesc != campos.FechaFinDesc).ToList();


                    //if (lstElementos.Count == 0)
                    //{
                    //    Session.Contents.Remove("lstSucursales");
                    //    Session.Remove("lstSucursales");
                    //    grvPromDobleAcumulacion.DataSource = null;
                    //    grvPromDobleAcumulacion.DataBind();
                    //    blnRespuesta = false;
                    //}
                    //else
                    //{
                    //    grvPromDobleAcumulacion.DataSource = null;
                    //    grvPromDobleAcumulacion.DataBind();

                    //    Session.Contents.Remove("lstSucursales");
                    //    Session.Remove("lstSucursales");
                    //    Session.Add("lstSucursales", lstElementos);
                    //    grvPromDobleAcumulacion.DataSource = lstElementos;
                    //    grvPromDobleAcumulacion.DataBind();
                    //    blnRespuesta = true;
                    //}
                    return blnRespuesta;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromoDobleAcumulacion", "GuardarNvaPromocion", "Ejecuta.GuardarPromoDobleAcumulacionHeader()/Ejecuta.GuardarPromoDobleAcumulacionDetalle()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al validar la existencia de la nueva promoción, contacte al administrador.");
            }
            //===========================================================================================

            return blnRespuesta;
        }
        private bool FinalizarPromociones()
        {
            bool blnRespuesta = false;
            //==================================================================================================================
            //Finalizando Promoción doble acumulación
            if (!chkApertura.Checked && Session["flgApertura"].ToString() == "1" && !chkDescINAPAM.Checked && Session["flgDescuento"].ToString() == "0")
            {
                blnRespuesta = FinalizaPromoDobleAcumulacion();
            }

            if (!chkApertura.Checked && Session["flgApertura"].ToString() == "1" && chkDescINAPAM.Checked && Session["flgDescuento"].ToString() == "1")
            {
                blnRespuesta = FinalizaPromoDobleAcumulacion();
            }

            //Finalizando Promoción Inapam
            if (!chkDescINAPAM.Checked && Session["flgDescuento"].ToString() == "1" && !chkApertura.Checked && Session["flgApertura"].ToString() == "0")
            {
                blnRespuesta = FinalizaDescuentoINAPAM();
            }

            if (!chkDescINAPAM.Checked && Session["flgDescuento"].ToString() == "1" && chkApertura.Checked && Session["flgApertura"].ToString() == "1")
            {
                blnRespuesta = FinalizaDescuentoINAPAM();
            }

            //Finalizando ambos tipos de poromoción
            if (!chkDescINAPAM.Checked && Session["flgDescuento"].ToString() == "1" && !chkApertura.Checked && Session["flgApertura"].ToString() == "1")
            {
                blnRespuesta = FinalizaPromoDobleAcumulacion();
                blnRespuesta = FinalizaDescuentoINAPAM();
            }

            return blnRespuesta;
            //==================================================================================================================
        }
        private bool ActivarControlesPopup()
        {
            bool blnRespuesta = true;

            if (Session["Modificacion"] != null)
            {
                //rdbCargaEspecifica.Checked = true;
                //rdbCargaEspecifica.Visible = false;
                //rdbCargaMasiva.Checked = false;
                //rdbCargaMasiva.Visible = false;
                //rcbSucursales.Enabled = true;
                //rcbSucursales.Visible = true;
                //lblCargaEspecifica.Visible = true;
                //rcbCupones.Visible = true;
                //rcbCupones.Enabled = false;


                rdbCargaEspecifica.Checked = true;
                rdbCargaMasiva.Checked = false;
                rdbCargaEspecifica.Visible = false;
                rdbCargaMasiva.Visible = false;
                FileUplSuc.UploadedFiles.Clear();
                //FileUplSuc = new RadAsyncUpload();
                FileUplSuc.Visible = false;
                lblCargaMasiva.Visible = false;
                lblCargaEspecifica.Visible = true;
                rcbSucursales.Enabled = true;
                rcbSucursales.Visible = true;
            }

            if (Session["Alta"] != null)
            {
                //if (grvPromDobleAcumulacion.Items.Count > 0)
                //{
                //    rdbCargaEspecifica.Checked = true;
                //    rdbCargaMasiva.Checked = false;
                //    rdbCargaEspecifica.Visible = false;
                //    rdbCargaMasiva.Visible = false;
                //    FileUplSuc.UploadedFiles.Clear();
                //    //FileUplSuc = new RadAsyncUpload();
                //    FileUplSuc.Visible = false;
                //    lblCargaMasiva.Visible = false;
                //    lblCargaEspecifica.Visible = true;
                //    rcbSucursales.Visible = true;
                //}
                //else
                //{
                rdbCargaEspecifica.Checked = false;
                rdbCargaMasiva.Checked = false;
                rdbCargaEspecifica.Visible = true;
                rdbCargaMasiva.Visible = true;
                FileUplSuc.UploadedFiles.Clear();
                FileUplSuc = new RadAsyncUpload();
                FileUplSuc.Visible = false;
                lblCargaEspecifica.Visible = false;
                rcbSucursales.Visible = false;
                //}
            }

            blnRespuesta = Validaciones();

            if (chkCupon.Checked)
            {
                Session.Contents.Remove("TipoProm");
                Session.Remove("TipoProm");
                rdpFechaFin.Enabled = true;
                lblFechaFinDesc.Visible = false;
                rdpFechaFinDesc.Visible = false;

                rdpFechaInicio.SelectedDate = rdpFIni.SelectedDate;
                rdpFechaInicio.Enabled = false;
                rcbSucursales.Focus();
            }
            else
            {
                rdpFechaInicio.SelectedDate = null;
                rdpFechaInicio.Enabled = true;
            }

            if (chkDescINAPAM.Checked)
            {
                rdpFechaFin.SelectedDate = null;
                rdpFechaFin.Enabled = false;
                Session.Add("TipoProm", "DESC");
                lblFechaFinDesc.Visible = true;
                rdpFechaFinDesc.Visible = true;
            }

            return blnRespuesta;
        }
        private bool Validaciones()
        {
            bool blnRespuesta = true;

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                Mensajes("Debe Proporcionar un nombre a la promoción.");
                txtDescripcion.Focus();

                blnRespuesta = false;
                return blnRespuesta;
            }

            if (rdpFIni.SelectedDate == null)
            {
                Mensajes("Debe seleccionar una fecha inicio.");
                rdpFIni.Focus();

                blnRespuesta = false;
                return blnRespuesta;
            }

            if (rdpFFin.SelectedDate == null)
            {
                Mensajes("Debe seleccionar una fecha fin.");
                rdpFFin.Focus();

                blnRespuesta = false;
                return blnRespuesta;
            }

            if (chkCupon.Checked && rcbCupones.SelectedValue == "-1")
            {
                Mensajes("Debe seleccionar un cupón.");
                rcbCupones.Focus();

                blnRespuesta = false;
                return blnRespuesta;
            }

            return blnRespuesta;
        }
    }
}