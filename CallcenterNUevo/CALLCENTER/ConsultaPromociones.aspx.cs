using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;
using Telerik.Web.UI;
using xi = Telerik.Web.UI.ExportInfrastructure;
using Telerik.Web.UI.GridExcelBuilder;
using System.Text;
using CallcenterNUevo.Utilerias;
using System.Web.Security;
using Bitacora.Modelo;
using Bitacora;

namespace CallcenterNUevo.CALLCENTER
{
    public partial class ConsultaPromosiones : System.Web.UI.Page
    {
        public static DataTable dtExportarDI;
        public static DataTable dtExportarVARIOSVENC;
        public static DataTable dtExportarPG;
        public static DataTable dtExportarACDE;
        public static DataTable dtExportarDE;
        public static DataTable dtExportarCUPON;
        public static DataTable dtExportarIMG;
        public static DataTable dtExportarMixMatch;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Asigna fecha actual a objetos
            //rdpFIni.SelectedDate = DateTime.Now.Date;
            //rdpFFin.SelectedDate = DateTime.Now.Date;
            //rdpDel.SelectedDate = DateTime.Now.Date;
            //rdpAl.SelectedDate = DateTime.Now.Date;
            //Realiza validaciones varias
            Validaciones();
        }

        protected void txtNumCupon_Textchange(object souce, EventArgs e)
        {
            if (txtNumCupon.Text != "")
            {
                rdpFIni.SelectedDate = null;
                rdpFFin.SelectedDate = null;
            }
            else
            {
                rdpFIni.SelectedDate = null;
                rdpFFin.SelectedDate = null;
            }
        }

        protected void txtIdLaboratorio_TextChanged(object sender, EventArgs e)
        {
            txtIdLaboratorio.DisplayText = "";
            if (txtNomProveedor.Text != "")
            {
                txtNomProveedor.Text = "";
            }
        }

        protected void txtNomProveedor_TextChanged(object sender, EventArgs e)
        {
            txtNomProveedor.DisplayText = "";
            if (txtIdLaboratorio.Text != "")
            {
                txtIdLaboratorio.Text = "";
            }
        }

        protected void chkAv_Changed(object souce, EventArgs e)
        {
            if (!chkAv.Checked)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", "javascript:OcultaDivDatosCupon();", true);
            }

            tabBusquedaAv.SelectedIndex = 0;
            LimpiaControles();
        }

        protected void grvDatosCupon_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Cupón";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarCupones_Click(null, null);
            }
            else
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Cupón";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Descending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarCupones_Click(null, null);
            }
        }

        protected void grvDatos_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarDI_Click(null, null);
            }
            else
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Descending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarDI_Click(null, null);
            }
        }

        protected void grvPzasGratis_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarProd_Click(null, null);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Popup", "AbrirPopup();", true);
            }
            else
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Descending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarProd_Click(null, null);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Popup", "AbrirPopup();", true);
            }
        }

        protected void grvVariosVenc_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            if (lblTituloPromocionVenc.Text == "Piezas Gratis (TM)")
            {
                if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
                {
                    GridSortExpression sortExpr = new GridSortExpression();
                    sortExpr.FieldName = "Segmento";
                    sortExpr.FieldName = e.SortExpression;
                    sortExpr.SortOrder = GridSortOrder.Ascending;
                    e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                    rbtnBuscarTipoMec_Click(null, null);
                }
                else
                {
                    GridSortExpression sortExpr = new GridSortExpression();
                    sortExpr.FieldName = "Segmento";
                    sortExpr.FieldName = e.SortExpression;
                    sortExpr.SortOrder = GridSortOrder.Descending;
                    e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                    rbtnBuscarTipoMec_Click(null, null);
                }
            }
            else if (lblTituloPromocionVenc.Text == "Piezas Gratis (Lab)")
            {
                if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
                {
                    GridSortExpression sortExpr = new GridSortExpression();
                    sortExpr.FieldName = "Segmento";
                    sortExpr.FieldName = e.SortExpression;
                    sortExpr.SortOrder = GridSortOrder.Ascending;
                    e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                    rbtnBuscarLab_Click(null, null);
                }
                else
                {
                    GridSortExpression sortExpr = new GridSortExpression();
                    sortExpr.FieldName = "Segmento";
                    sortExpr.FieldName = e.SortExpression;
                    sortExpr.SortOrder = GridSortOrder.Descending;
                    e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                    rbtnBuscarLab_Click(null, null);
                }
            }
            else
            {
                if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
                {
                    GridSortExpression sortExpr = new GridSortExpression();
                    sortExpr.FieldName = "Segmento";
                    sortExpr.FieldName = e.SortExpression;
                    sortExpr.SortOrder = GridSortOrder.Ascending;
                    e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                    rbtnBuscarVenc_Click(null, null);
                }
                else
                {
                    GridSortExpression sortExpr = new GridSortExpression();
                    sortExpr.FieldName = "Segmento";
                    sortExpr.FieldName = e.SortExpression;
                    sortExpr.SortOrder = GridSortOrder.Descending;
                    e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                    rbtnBuscarVenc_Click(null, null);
                }
            }
        }

        protected void grvCuponVenc_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

            //int TipoPromocion = Convert.ToInt32(rdcTipoPromVenc.SelectedValue);
            //DateTime FechaActual = new DateTime();
            //FechaActual = DateTime.Now;
            //int Mes = FechaActual.Month;
            //int hexLength = Mes.ToString("X").Length + 1;
            //string ResMes = Mes.ToString("X" + hexLength.ToString());
            //int NumRegxPag = Convert.ToInt32(rcbitemsxpagVenc.SelectedValue);

            //DateTime FechaInicio = Convert.ToDateTime("01/" + Mes + "/" + FechaActual.Year);
            //DateTime FechaFin = FechaActual;

            //BuscarPromocionesVencidas(TipoPromocion, FechaInicio, FechaFin, 0, NumRegxPag);
            rbtnBuscarVenc_Click(null, null);

        }

        protected void grvCuponVenc_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarVenc_Click(null, null);
            }
            else
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Descending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarVenc_Click(null, null);
            }
        }

        protected void rcbPorVencer_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdpDel.SelectedDate = null;
            rdpAl.SelectedDate = null;
            rdbVenciadas.Checked = false;
            rdbVencidasMes.Checked = false;
        }

        protected void rdcTipoPromo_Changed(object sender, EventArgs e)
        {

            if (rdcTipoPromo.SelectedIndex == 2)
            {
                grvDatos.Visible = false;
                txtCodIntDI.Visible = true;
                rdcEstatus.SelectedIndex = 1;
                txtCodIntDI.Focus();
            }
            else
            {
                rdcEstatus.SelectedIndex = 0;
                grvDatos.Visible = false;
                txtCodIntDI.Text = "";
                txtCodIntDI.Visible = false;
            }


            rdcSegmento.SelectedIndex = 0;
            rdcEstatus.SelectedIndex = 0;
            rdcItemsxPagina.SelectedIndex = 0;
            grvDatos.DataSource = null;
            grvDatos.DataBind();
            grvDatosCupon.DataSource = null;
            grvDatosCupon.DataBind();
        }

        protected void rdcTipoPromoCupon_Changed(object sender, EventArgs e)
        {

            //rbtnExportarExcel.Visible = false;
            txtNumCupon.Text = "";
            rdpFIni.SelectedDate = null;
            rdpFFin.SelectedDate = null;
            grvDatos.DataSource = null;
            rdcItemsxPaginaCupon.SelectedIndex = 0;
            grvDatos.DataBind();
            grvDatosCupon.DataSource = null;
            grvDatosCupon.DataBind();
            txtCodIntDI.Text = "";
            txtCodIntDI.Visible = false;

            rdcTipoPromo.SelectedIndex = rcbTipoPromCupones.SelectedIndex;
            rcbTipoPromCupones.SelectedIndex = 0;
        }

        protected void rdcTipoPromVenc_Changed(object sender, EventArgs e)
        {

        }

        protected void rbtnBuscarDI_Click(object sender, EventArgs e)
        {
            bool Respuesta = false;
            if (rdcTipoPromo.SelectedIndex == 2 && txtCodIntDI.Text == "" && rdcEstatus.SelectedIndex != 1)//Dinero Electrónico
            {
                string Mensaje = "Es necesario proporcione el No. de código interno para poder realizar su consulta de Dinero electónico";
                ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", "alert('" + Mensaje + "');", true);
                grvDatos.Visible = false;
                txtCodIntDI.Visible = true;
                txtCodIntDI.DisplayText = "";
                txtCodIntDI.Focus();
                return;
            }
            int TipoPromocion = Convert.ToInt32(rdcTipoPromo.SelectedValue);
            int Segmento = Convert.ToInt32(rdcSegmento.SelectedValue);
            int Estatus = Convert.ToInt32(rdcEstatus.SelectedValue);
            int NumRegxPag = Convert.ToInt32(rdcItemsxPagina.SelectedValue);
            string CodigoInterno = txtCodIntDI.Text;// Solo para las consultas de Dinero Electrónico
            string NumCupon = "";
            DateTime? FIni, FFin;
            FIni = rdpFIni.SelectedDate;
            FFin = rdpFFin.SelectedDate;
            txtCodIntDI.DisplayText = "";

            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarDI_Click", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
            Respuesta = BuscaPromociones(TipoPromocion, Segmento, Estatus, NumRegxPag, NumCupon, FIni, FFin, "", CodigoInterno);
            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarDI_Click", "Fin de Consulta", this.User.Identity.Name.ToString(), null);

            if (Respuesta)
            {
                grvDatos.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "IconoEspera", "OcultaImagenEspera('DI')", true);
            }
            else
            {
                var Mensaje = "No se encontrarón resultados";
                ScriptManager.RegisterStartupScript(this, GetType(), "IconoEspera", "OcultaImagenEspera('DI');alert('" + Mensaje + "');", true);
            }
        }

        protected void rbtnBuscarCupones_Click(object sender, EventArgs e)
        {
            bool Resultado = false;
            if (txtNumCupon.Text == "" && rdpFIni.SelectedDate == null)
            {
                var Mensaje = "Es necesario especifique almenos un filtro, Intente de nuevo..";
                ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "OcultaDivDatosCupon();alert('" + Mensaje + "');", true);
            }
            else
            {
                int TipoPromocion = Convert.ToInt32(rcbTipoPromCupones.SelectedValue);
                int Segmento = 0;
                int Estatus = 0;
                int NumRegxPag = Convert.ToInt32(rdcItemsxPaginaCupon.SelectedValue);
                string NumCupon = txtNumCupon.Text.Trim();
                txtNumCupon.Text = "";
                DateTime? FIni, FFin;
                FIni = rdpFIni.SelectedDate;
                FFin = rdpFFin.SelectedDate;

                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarCupones_Click", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
                Resultado = BuscaPromociones(TipoPromocion, Segmento, Estatus, NumRegxPag, NumCupon, FIni, FFin, "Cupon", "");
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarCupones_Click", "Fin de Consulta", this.User.Identity.Name.ToString(), null);


                if (Resultado)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "IconoEspera", "OcultaImagenEspera('DICup')", true);
                }
                else
                {
                    var Mensaje = "No se encontrarón resultados";
                    ScriptManager.RegisterStartupScript(this, GetType(), "IconoEspera", "OcultaImagenEspera('DICup');alert('" + Mensaje + "');", true);
                }
            }
        }

        protected void rbtnBuscarProd_Click(object sender, EventArgs e)
        {
            if (txtNumIntCodBar.Text == "" && Session["txtNumIntCodBar"] == null)
            {
                var Mensaje = "Es necesario especifique un valor de busqueda, Intente de nuevo..";
                ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "OcultaDivDatosCupon();alert('" + Mensaje + "');", true);
                return;
            }


            if (Session["txtNumIntCodBar"] == null)
            {
                Session.Add("txtNumIntCodBar", txtNumIntCodBar.Text);
            }

            txtNumIntCodBar.Text = "";
            string CodigoIntSKU = Session["txtNumIntCodBar"].ToString();
            int NumRegxPag = Convert.ToInt32(rdcitemsxPagProd.SelectedValue);

            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarProd_Click", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
            BuscarPromocionesXCodIntSKU(CodigoIntSKU, NumRegxPag);
            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarProd_Click", "Fin de Consulta", this.User.Identity.Name.ToString(), null);

            rdbPG.Checked = false;
            rdbAcumDE.Checked = false;
            rdbMixMatch.Checked = false;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Popup", "OcultaImagenEspera('AVxProd');AbrirPopup();", true);
        }

        protected void rbtnBuscarVenc_Click(object sender, EventArgs e)
        {
            if (!rdbVenciadas.Checked && !rdbVencidasMes.Checked && rdpDel.SelectedDate == null && rdpAl.SelectedDate == null && rcbPorVencer.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Mensaje", "ctrlMensajes('Es necesario seleccionar uno de los diferentes filtros...');", true);
                return;
            }

            lbldivDatCuponVenc.Text = "";
            int TipoPromocion = Convert.ToInt32(rdcTipoPromVenc.SelectedValue);
            int NumRegxPag = Convert.ToInt32(rcbitemsxpagVenc.SelectedValue);
            lblTituloPromocionVenc.Text = rdcTipoPromVenc.Text;

            if (rdbVenciadas.Checked && rpvVencimiento.Selected)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarVenc_Click/Vencidas", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
                BuscarPromocionesVencidas(TipoPromocion, null, null, 0, NumRegxPag);
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarVenc_Click/Vencidas", "Fin de Consulta", this.User.Identity.Name.ToString(), null);
            }
            else if (rdbVencidasMes.Checked && rpvVencimiento.Selected)
            {
                DateTime DiaActual;
                DateTime UltimoDia;

                DiaActual = new System.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 1);
                UltimoDia = DiaActual.AddMonths(1).AddDays(-1); //Obtengo último día del mes actual

                string FechaInicio = DiaActual.Year.ToString() + DiaActual.Month.ToString("00") + DiaActual.Day.ToString("00") + " 00:00:00";
                string FechaFin = UltimoDia.Year.ToString() + UltimoDia.Month.ToString("00") + UltimoDia.Day.ToString() + " 23:59:59";

                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarVenc_Click/VencidasMes", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
                BuscarPromocionesVencidas(TipoPromocion, FechaInicio, FechaFin, 0, NumRegxPag);
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarVenc_Click/VencidasMes", "Fin de Consulta", this.User.Identity.Name.ToString(), null);

            }
            else if (rdpDel.SelectedDate != null && rdpAl.SelectedDate != null && rpvVencimiento.Selected)
            {
                string FIni, FFin;
                FIni = rdpDel.SelectedDate.Value.Year.ToString() + rdpDel.SelectedDate.Value.Month.ToString("00") + rdpDel.SelectedDate.Value.Day.ToString("00") + " 00:00:00"; ;
                FFin = rdpAl.SelectedDate.Value.Year.ToString() + rdpAl.SelectedDate.Value.Month.ToString("00") + rdpAl.SelectedDate.Value.Day.ToString("00") + " 23:59:59";

                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarVenc_Click/RangosFec", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
                BuscarPromocionesVencidas(TipoPromocion, FIni, FFin, 0, NumRegxPag);
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarVenc_Click/RangosFec", "Fin de Consulta", this.User.Identity.Name.ToString(), null);

            }
            else if (rcbPorVencer.SelectedValue != "0" && rpvVencimiento.Selected)
            {
                int DiasPorVencer = Convert.ToInt32(rcbPorVencer.SelectedValue);
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarVenc_Click/DiasxVencer", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
                BuscarPromocionesVencidas(TipoPromocion, null, null, DiasPorVencer, NumRegxPag);
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarVenc_Click/DiasxVencer", "Fin de Consulta", this.User.Identity.Name.ToString(), null);
            }

            if (TipoPromocion < 4 || TipoPromocion == 6)
            {
                grvVariosVenc.Visible = true;
                grvMixMatchLab.Visible = false;
                grvAcDELab.Visible = false;
                grvCuponVenc.Visible = false;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Popup", "OcultaImagenEspera('AVVenc');AbrirPopupVenc(0);", true);
            }
            else
            {
                grvAcDELab.Visible = false;
                grvMixMatchLab.Visible = false;
                grvVariosVenc.Visible = false;
                grvCuponVenc.Visible = true;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Popup", "AbrirPopupVenc(1);", true);
            }
        }

        protected void rbtnBuscarTipoMec_Click(object sender, EventArgs e)
        {
            int TipoMecanica = Convert.ToInt32(rcbTipoMec.SelectedValue);
            int Estatus = Convert.ToInt32(rcmbEstatusTipoMec.SelectedValue);
            int NumRegxPag = Convert.ToInt32(rcbitemsxPagTipoMec.SelectedValue);
            lblTituloPromocionVenc.Text = "Piezas Gratis (TM)";

            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarTipoMec_Click", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
            BuscarxTipoMecanica(TipoMecanica, Estatus, NumRegxPag);
            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarTipoMec_Click", "Fin de Consulta", this.User.Identity.Name.ToString(), null);

            grvVariosVenc.Visible = true;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Popup", "OcultaImagenEspera('AVTM');AbrirPopupVenc(0);", true);
        }

        protected void rbtnBuscarLab_Click(object sender, EventArgs e)
        {
            if (txtIdLaboratorio.Text == "" && txtNomProveedor.Text == "" && Session["IdLaboratorio"] == null && Session["NomProveedor"] == null)
            {
                var Mensaje = "Es necesario ingrese almenos un filtro para realizar la busqueda...";
                ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');", true);
                return;
            }

            int IdLaboreatorio = 0;
            string NomProveedor = null;
            int NumRegxPag = Convert.ToInt32(rcbitemsxPagLab.SelectedValue);

            if (txtIdLaboratorio.Text != "")
            {
                Session.Add("IdLaboratorio", txtIdLaboratorio.Text);
                txtIdLaboratorio.Text = "";
                IdLaboreatorio = Convert.ToInt32(Session["IdLaboratorio"].ToString());
            }
            if (txtNomProveedor.Text != "")
            {
                Session.Add("NomProveedor", txtNomProveedor.Text);
                txtNomProveedor.Text = "";
                NomProveedor = Session["NomProveedor"].ToString();
            }

            if (Session["NomProveedor"] != null)
            {
                NomProveedor = Session["NomProveedor"].ToString();
            }

            if (Session["IdLaboratorio"] != null)
            {
                IdLaboreatorio = Convert.ToInt32(Session["IdLaboratorio"].ToString());
            }

            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarLab_Click", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
            int encontroResultados = BuscarxLabxProv(IdLaboreatorio, NomProveedor, NumRegxPag);
            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.ConsultaPromociones", "rbtnBuscarLab_Click", "Fin de Consulta", this.User.Identity.Name.ToString(), null);


            txtIdLaboratorio.Text = null;
            txtNomProveedor.Text = null;
            rdbtnPGLab.Checked = false;
            rdbtnACDELab.Checked = false;
            if (encontroResultados > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Popup", "OcultaImagenEspera('AVLAB');AbrirPopupLab();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('No se encontrarón resultados..." + "');", true);
            }

        }

        protected void rbtnExportarExcel_Click(object sender, ImageClickEventArgs e)
        {
            ExportarExcel Crear = new ExportarExcel();

            if (grvDatosCupon.Items.Count == 0 && grvDatos.Items.Count == 0 && grvImagenes.Items.Count == 0)
            {
                var Mensaje = "No existen resultados que exportar...";
                ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');", true);
                return;
            }

            if (rdcTipoPromo.SelectedItem.Text == "Cupones" || rcbTipoPromCupones.SelectedItem.Text == "Cupones")
            {

                if (dtExportarCUPON != null)
                {
                    if (dtExportarCUPON.Rows.Count > 0)
                    {
                        IniciarDescarga(Crear.ExportarCVS(dtExportarCUPON), "ConsultaPromociones_" + rcbTipoPromCupones.Text.Trim().Replace(" ", ""));
                        dtExportarCUPON = null;
                    }
                    else
                    {
                        var Mensaje = "No existen resultados que exportar...";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');", true);
                        return;
                    }
                }
                else
                {
                    var Mensaje = "No existen resultados que exportar...";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');", true);
                    return;
                }
            }
            else
            {
                switch (rdcTipoPromo.SelectedValue)
                {
                    case ("1"):
                        IniciarDescarga(Crear.ExportarCVS(dtExportarPG), "ConsultaPromociones_" + rdcTipoPromo.Text.Trim().Replace(" ", ""));
                        dtExportarPG = null;
                        break;
                    case ("2"):
                        IniciarDescarga(Crear.ExportarCVS(dtExportarACDE), "ConsultaPromociones_" + rdcTipoPromo.Text.Trim().Replace(" ", ""));
                        dtExportarACDE = null;
                        break;
                    case ("3"):
                        IniciarDescarga(Crear.ExportarCVS(dtExportarDE), "ConsultaPromociones_" + rdcTipoPromo.Text.Trim().Replace(" ", ""));
                        dtExportarDE = null;
                        break;
                    case ("5"):
                        IniciarDescarga(Crear.ExportarCVS(dtExportarIMG), "ConsultaPromociones_" + rdcTipoPromo.Text.Trim().Replace(" ", ""));
                        dtExportarIMG = null;
                        break;
                    case ("6"):
                        //Mix&Match se reutiliza grid de piezas gratis
                        IniciarDescarga(Crear.ExportarCVS(dtExportarMixMatch), "ConsultaPromociones_" + rdcTipoPromo.Text.Trim().Replace(" ", ""));
                        dtExportarMixMatch = null;
                        break;
                }
            }
        }

        protected void grvDatosCupon_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            int TipoPromocion = Convert.ToInt32(rcbTipoPromCupones.SelectedValue);
            int Segmento = 0;
            int Estatus = 0;
            int NumRegxPag = Convert.ToInt32(rdcItemsxPaginaCupon.SelectedValue);
            string NumCupon = txtNumCupon.Text;
            DateTime? FIni, FFin;
            FIni = rdpFIni.SelectedDate;
            FFin = rdpFFin.SelectedDate;

            BuscaPromociones(TipoPromocion, Segmento, Estatus, NumRegxPag, NumCupon, FIni, FFin, "Cupon", "");
        }

        protected void grvDatos_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            rbtnBuscarDI_Click(null, null);
        }

        protected void grvPzasGratis_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            rbtnBuscarProd_Click(null, null);
        }

        protected void grvVariosVenc_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            //if (lblTituloPromocionVenc.Text == "Piezas Gratis (TM)")
            //{
            //    int TipoMecanica = Convert.ToInt32(rcbTipoMec.SelectedValue);
            //    int Estatus = Convert.ToInt32(rcmbEstatusTipoMec.SelectedValue);
            //    int NumRegxPag = Convert.ToInt32(rcbitemsxPagTipoMec.SelectedValue);
            //    lblTituloPromocionVenc.Text = "Piezas Gratis (TM)";

            //    BuscarxTipoMecanica(TipoMecanica, Estatus, NumRegxPag);
            //}
            //else if (lblTituloPromocionVenc.Text == "Piezas Gratis (Lab)")
            //{
            //    int TipoMecanica = Convert.ToInt32(rcbTipoMec.SelectedValue);
            //    int IdLaboreatorio = Convert.ToInt32(txtIdLaboratorio.Text);
            //    string NomProveedor = txtNomProveedor.Text;
            //    int NumRegxPag = Convert.ToInt32(rcbitemsxPagLab.SelectedValue);

            //    BuscarxLabxProv(IdLaboreatorio, NomProveedor, NumRegxPag);
            //}
            //else 
            //{
            //    int TipoPromocion = Convert.ToInt32(rdcTipoPromVenc.SelectedValue);
            //    DateTime FechaActual = new DateTime();
            //    FechaActual = DateTime.Now;
            //    int Mes = FechaActual.Month;
            //    int hexLength = Mes.ToString("X").Length + 1;
            //    string ResMes = Mes.ToString("X" + hexLength.ToString());
            //    int NumRegxPag = Convert.ToInt32(rcbitemsxpagVenc.SelectedValue);

            //    DateTime FechaInicio = Convert.ToDateTime("01/" + Mes + "/" + FechaActual.Year);
            //    DateTime FechaFin = FechaActual;

            //    BuscarPromocionesVencidas(TipoPromocion, FechaInicio, FechaFin, 0, NumRegxPag);
            //    if (TipoPromocion < 4)
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(Page), "Popup", "AbrirPopupVenc(0);", true);
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(Page), "Popup", "AbrirPopupVenc(1);", true);
            //    }
            //}
            if (rpvVencimiento.Selected)
            {
                rbtnBuscarVenc_Click(null, null);
            }
            else if (rpvTipoMecanica.Selected)
            {
                rbtnBuscarTipoMec_Click(null, null);
            }
            else if (rpvLaboratorio.Selected)
            {
                rbtnBuscarLab_Click(null, null);
            }

        }

        protected void grvAcumDE_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            rbtnBuscarProd_Click(null, null);
        }

        protected void grvDE_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            rbtnBuscarProd_Click(null, null);
        }

        protected void grvAcumDE_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarProd_Click(null, null);
            }
            else
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Descending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarProd_Click(null, null);
            }
        }

        protected void grvDE_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarProd_Click(null, null);
            }
            else
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Descending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarProd_Click(null, null);
            }
        }

        protected void grvImagenes_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            int TipoPromocion = Convert.ToInt32(rdcTipoPromo.SelectedValue);
            int Segmento = Convert.ToInt32(rdcSegmento.SelectedValue);
            int Estatus = Convert.ToInt32(rdcEstatus.SelectedValue);
            int NumRegxPag = Convert.ToInt32(rdcItemsxPagina.SelectedValue);
            string NumCupon = "";
            DateTime? FIni, FFin;
            FIni = rdpFIni.SelectedDate;
            FFin = rdpFFin.SelectedDate;

            BuscaPromociones(TipoPromocion, Segmento, Estatus, NumRegxPag, NumCupon, FIni, FFin, "", "");
        }

        protected void grvImagenes_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "IdPromo";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarDI_Click(null, null);
            }
            else
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "IdPromo";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Descending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarDI_Click(null, null);
            }
        }

        protected void grvAcDELab_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            //int TipoMecanica = Convert.ToInt32(rcbTipoMec.SelectedValue);
            //int IdLaboreatorio = Convert.ToInt32(txtIdLaboratorio.Text);
            //string NomProveedor = txtNomProveedor.Text;
            //int NumRegxPag = Convert.ToInt32(rcbitemsxPagLab.SelectedValue);

            //BuscarxLabxProv(IdLaboreatorio, NomProveedor, NumRegxPag);
            rbtnBuscarLab_Click(null, null);
        }

        protected void grvAcDELab_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarLab_Click(null, null);
            }
            else
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Descending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarLab_Click(null, null);
            }
        }

        protected void rdpFIni_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFIni.SelectedDate.Value != null)
            {
                txtNumCupon.Text = "";
            }
        }

        protected void rdpFFin_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFFin.SelectedDate.Value != null)
            {
                txtNumCupon.Text = "";
            }
        }

        protected void rdpDel_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpDel.SelectedDate.Value != null)
            {
                rdbVenciadas.Checked = false;
                rdbVencidasMes.Checked = false;
            }
        }

        protected void rdpAl_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpAl.SelectedDate.Value != null)
            {
                rdbVenciadas.Checked = false;
                rdbVencidasMes.Checked = false;
            }
        }

        protected bool BuscaPromociones(int TipoPromocion, int Segmento, int Estatus, int NumRegxPag, string NumCupon, DateTime? FIni, DateTime? FFin, string TipoProm, string CodigoInterno)
        {
            bool ExistenResultados = false;
            try
            {
                DataSet dtsPromociones = new DataSet();
                dtsPromociones = null;
                dtsPromociones = Promociones.ObtenerPromos(TipoPromocion, Segmento, Estatus, NumCupon, "SP_ConsultaPromocionesDI", FIni, FFin, CodigoInterno);

                if (dtsPromociones != null)
                {
                    if (dtsPromociones.Tables.Count > 0 && dtsPromociones.Tables[0].Rows.Count > 0)
                    {
                        ExistenResultados = true;
                        if (TipoProm == "Cupon")
                        {
                            dtExportarCUPON = new DataTable();
                            dtExportarCUPON = dtsPromociones.Tables[0];
                            grvDatosCupon.DataSource = dtsPromociones.Tables[0];
                            if (NumRegxPag > 0)
                            {
                                grvDatosCupon.PageSize = NumRegxPag;
                            }
                            else
                            {
                                if (dtsPromociones.Tables[0].Rows.Count > 0)
                                {
                                    grvDatosCupon.PageSize = dtsPromociones.Tables[0].Rows.Count;
                                }
                            }

                            grvDatosCupon.CurrentPageIndex = 0;
                            GridSortExpression sortExpr = new GridSortExpression();
                            sortExpr.FieldName = "Cupón";
                            sortExpr.SortOrder = GridSortOrder.Ascending;
                            grvDatosCupon.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
                            grvDatosCupon.DataBind();
                            grvDatosCupon.Rebind();
                        }
                        else if (TipoProm == "" && TipoPromocion < 5 || TipoProm == "" && TipoPromocion == 6)
                        {
                            if (TipoPromocion == 1)
                            {
                                dtExportarPG = new DataTable();
                                dtExportarPG = dtsPromociones.Tables[0];
                            }
                            else if (TipoPromocion == 2)
                            {
                                dtExportarACDE = new DataTable();
                                dtExportarACDE = dtsPromociones.Tables[0];
                            }
                            else if (TipoPromocion == 3)
                            {
                                dtExportarDE = new DataTable();
                                dtExportarDE = dtsPromociones.Tables[0];
                            }
                            else if (TipoPromocion == 6)
                            {
                                dtExportarMixMatch = new DataTable();
                                dtExportarMixMatch = dtsPromociones.Tables[0];
                            }


                            grvDatos.DataSource = dtsPromociones.Tables[0];
                            if (NumRegxPag > 0)
                            {
                                grvDatos.PageSize = NumRegxPag;
                            }
                            else
                            {
                                if (dtsPromociones.Tables[0].Rows.Count > 0)
                                {
                                    grvDatos.PageSize = dtsPromociones.Tables[0].Rows.Count;
                                }
                            }

                            grvDatos.CurrentPageIndex = 0;
                            GridSortExpression sortExpr = new GridSortExpression();
                            sortExpr.FieldName = "Segmento";
                            sortExpr.SortOrder = GridSortOrder.Ascending;
                            grvDatos.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
                            grvDatos.DataBind();
                            grvDatos.Rebind();
                        }
                        else if (TipoPromocion == 5)//Imagenes
                        {
                            dtExportarIMG = new DataTable();
                            dtExportarIMG = dtsPromociones.Tables[0];
                            grvImagenes.DataSource = dtsPromociones.Tables[0];
                            if (NumRegxPag > 0)
                            {
                                grvImagenes.PageSize = NumRegxPag;
                            }
                            else
                            {
                                if (dtsPromociones.Tables[0].Rows.Count > 0)
                                {
                                    grvImagenes.PageSize = dtsPromociones.Tables[0].Rows.Count;
                                }
                            }

                            grvImagenes.CurrentPageIndex = 0;
                            GridSortExpression sortExpr = new GridSortExpression();
                            sortExpr.FieldName = "IdPromo";
                            sortExpr.SortOrder = GridSortOrder.Ascending;
                            grvImagenes.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
                            grvImagenes.DataBind();
                            grvImagenes.Rebind();
                        }
                        ScriptManager.RegisterStartupScript(this, GetType(), "ActivaExportarExcel", "MuestraExportar();", true);
                    }
                    else
                    {
                        if (TipoProm == "Cupon")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", "OcultaDivDatosCupon()", true);
                            rdcTipoPromo.SelectedIndex = 0;
                            rcbTipoPromCupones.SelectedIndex = 3;
                            grvDatosCupon.DataSource = null;
                            grvDatosCupon.DataBind();
                        }
                        else
                        {
                            grvDatos.DataSource = null;
                            grvDatos.DataBind();
                        }
                    }
                }
                else
                {
                    grvDatos.DataSource = null;
                    grvDatos.DataBind();
                    grvDatosCupon.DataSource = null;
                    grvDatosCupon.DataBind();
                    rbtnExportarExcel.Visible = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "OcultaDivDatosCupon();MuestraExportar();", true);
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.ConsultaPromociones", "BuscarPromociones", "dtsPromociones = Promociones.ObtenerPromos(" + TipoPromocion.ToString() + "," + Segmento.ToString() + "," + Estatus.ToString() + "," + NumCupon.ToString() + ", SP_ConsultaPromocionesDI" + "," + FIni.ToString() + "," + FFin.ToString() + "," + CodigoInterno.ToString() + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('Ocurrio un error interno contacte al Administrador del sistema..." + "');", true);
            }
            return ExistenResultados;
        }

        protected void BuscarPromocionesXCodIntSKU(string CodigoIntSKU, int NumRegxPag)
        {
            int i = 0;
            try
            {
                for (i = 1; i <= 4; ++i)
                {
                    DataSet dtsPromociones = new DataSet();
                    if (i <= 3)
                    {
                        dtsPromociones = Promociones.ObtenerPromos(i, CodigoIntSKU, "SP_ConsultaPromocionesXProducto");
                    }
                    else if (i == 4)
                    {
                        //MixMatch
                        dtsPromociones = Promociones.ObtenerPromos(6, CodigoIntSKU, "SP_ConsultaPromocionesXProducto");
                    }


                    if (dtsPromociones != null)
                    {
                        if (dtsPromociones.Tables.Count > 0)
                        {
                            GridSortExpression sortExpr = new GridSortExpression();
                            switch (i)
                            {
                                case (1):
                                    dtExportarPG = new DataTable();
                                    dtExportarPG = dtsPromociones.Tables[0];
                                    grvPzasGratis.DataSource = dtsPromociones.Tables[0];
                                    if (NumRegxPag > 0)
                                    {
                                        grvPzasGratis.PageSize = NumRegxPag;
                                    }
                                    else
                                    {
                                        if (dtsPromociones.Tables[0].Rows.Count > 0)
                                        {
                                            grvPzasGratis.PageSize = dtsPromociones.Tables[0].Rows.Count;
                                        }
                                    }

                                    sortExpr.FieldName = "Segmento";
                                    sortExpr.SortOrder = GridSortOrder.Ascending;
                                    grvPzasGratis.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
                                    grvPzasGratis.CurrentPageIndex = 0;
                                    grvPzasGratis.DataBind();
                                    break;
                                case (2):
                                    dtExportarACDE = new DataTable();
                                    dtExportarACDE = dtsPromociones.Tables[0];
                                    grvAcumDE.DataSource = dtsPromociones.Tables[0];
                                    if (NumRegxPag > 0)
                                    {
                                        grvAcumDE.PageSize = NumRegxPag;
                                    }
                                    else
                                    {
                                        if (dtsPromociones.Tables[0].Rows.Count > 0)
                                        {
                                            grvAcumDE.PageSize = dtsPromociones.Tables[0].Rows.Count;
                                        }
                                    }

                                    sortExpr.FieldName = "Segmento";
                                    sortExpr.SortOrder = GridSortOrder.Ascending;
                                    grvAcumDE.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
                                    grvAcumDE.CurrentPageIndex = 0;
                                    grvAcumDE.DataBind();
                                    break;
                                case (3):
                                    dtExportarDE = new DataTable();
                                    dtExportarDE = dtsPromociones.Tables[0];
                                    grvDE.DataSource = dtsPromociones.Tables[0];
                                    if (NumRegxPag > 0)
                                    {
                                        grvDE.PageSize = NumRegxPag;
                                    }
                                    else
                                    {
                                        if (dtsPromociones.Tables[0].Rows.Count > 0)
                                        {
                                            grvDE.PageSize = dtsPromociones.Tables[0].Rows.Count;
                                        }
                                    }

                                    sortExpr.FieldName = "Segmento";
                                    sortExpr.SortOrder = GridSortOrder.Ascending;
                                    grvDE.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
                                    grvDE.CurrentPageIndex = 0;
                                    grvDE.DataBind();
                                    break;

                                case (4):
                                    dtExportarMixMatch = new DataTable();
                                    dtExportarMixMatch = dtsPromociones.Tables[0];
                                    grvMixMatch.DataSource = dtsPromociones.Tables[0];
                                    if (NumRegxPag > 0)
                                    {
                                        grvMixMatch.PageSize = NumRegxPag;
                                    }
                                    else
                                    {
                                        if (dtsPromociones.Tables[0].Rows.Count > 0)
                                        {
                                            grvMixMatch.PageSize = dtsPromociones.Tables[0].Rows.Count;
                                        }
                                    }

                                    sortExpr.FieldName = "Segmento";
                                    sortExpr.SortOrder = GridSortOrder.Ascending;
                                    grvMixMatch.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
                                    grvMixMatch.CurrentPageIndex = 0;
                                    grvMixMatch.DataBind();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case (1):
                                grvPzasGratis.DataSource = null;
                                grvPzasGratis.DataBind();
                                break;
                            case (2):
                                grvAcumDE.DataSource = null;
                                grvAcumDE.DataBind();
                                break;
                            case (3):
                                grvDE.DataSource = null;
                                grvDE.DataBind();
                                break;
                            case (4)://Mix&Match
                                grvMixMatch.DataSource = null;
                                grvMixMatch.DataBind();
                                break;
                        }
                        chkAv.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.ConsultaPromociones", "BuscarPromocionesXCodintSKU", "dtsPromociones = Promociones.ObtenerPromos(" + i.ToString() + "," + CodigoIntSKU.ToString() + ", SP_ConsultaPromocionesXProducto" + ")", "Ocurrio un error", this.User.Identity.Name.ToString(), ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('Ocurrio un error interno contacte al Adminstrador del sistema " + "');", true);
            }
        }

        protected void BuscarPromocionesVencidas(int TipoPromocion, string Fecini, string FecFin, int DiasPorVencer, int NumRegxPag)
        {
            try
            {
                DataSet dtsPromociones = new DataSet();
                dtsPromociones = Promociones.ObtenerPromos(TipoPromocion, Fecini, FecFin, DiasPorVencer, "SP_ConsultaPromocionesXVencimiento");

                if (dtsPromociones != null)
                {
                    if (dtsPromociones.Tables.Count > 0)
                    {
                        GridSortExpression sortExpr = new GridSortExpression();
                        if (TipoPromocion < 4 || TipoPromocion == 6)
                        {
                            dtExportarVARIOSVENC = new DataTable();
                            dtExportarVARIOSVENC = dtsPromociones.Tables[0];
                            lblTituloPromocionVenc.Text = rdcTipoPromVenc.Text + " (Vencimiento)";
                            lbldivDatMixMatchVenc.Text = "";
                            grvCuponVenc.DataSource = null;
                            grvCuponVenc.DataBind();
                            grvVariosVenc.DataSource = dtsPromociones.Tables[0];
                            if (NumRegxPag > 0)
                            {
                                grvVariosVenc.PageSize = NumRegxPag;
                            }
                            else
                            {
                                if (dtsPromociones.Tables[0].Rows.Count > 0)
                                {
                                    grvVariosVenc.PageSize = dtsPromociones.Tables[0].Rows.Count;
                                }
                            }

                            sortExpr.FieldName = "Segmento";
                            sortExpr.SortOrder = GridSortOrder.Ascending;
                            grvVariosVenc.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
                            grvVariosVenc.CurrentPageIndex = 0;
                            grvVariosVenc.DataBind();
                        }
                        else
                        {
                            dtExportarCUPON = new DataTable();
                            dtExportarCUPON = dtsPromociones.Tables[0];
                            lbldivDatCuponVenc.Text = rdcTipoPromVenc.Text + " (Vencimiento)";
                            grvVariosVenc.DataSource = null;
                            grvVariosVenc.DataBind();
                            grvCuponVenc.DataSource = dtsPromociones.Tables[0];
                            if (NumRegxPag > 0)
                            {
                                grvCuponVenc.PageSize = NumRegxPag;
                            }
                            else
                            {
                                if (dtsPromociones.Tables[0].Rows.Count > 0)
                                {
                                    grvCuponVenc.PageSize = dtsPromociones.Tables[0].Rows.Count;
                                }
                            }

                            sortExpr.FieldName = "Cupón";
                            sortExpr.SortOrder = GridSortOrder.Ascending;
                            grvCuponVenc.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
                            grvCuponVenc.CurrentPageIndex = 0;
                            grvCuponVenc.DataBind();
                        }
                    }
                }
                else
                {
                    grvVariosVenc.DataSource = null;
                    grvVariosVenc.DataBind();
                    grvCuponVenc.DataSource = null;
                    grvCuponVenc.DataBind();

                }
                chkAv.Visible = true;
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.ConsultaPromociones", "BuscarPromocionesVencidas", "dtsPromociones = Promociones.ObtenerPromos(" + TipoPromocion.ToString() + "," + Fecini.ToString() + "," + FecFin.ToString() + "," + DiasPorVencer.ToString() + ", SP_ConsultaPromocionesXVencimiento )", "Ocurrio un error", this.User.Identity.Name.ToString(), ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('Ocurrio un error interno: " + ex.Message.ToString() + "');", true);
            }
        }

        protected void BuscarxTipoMecanica(int TipoMecanica, int Status, int NumRegxPag)
        {
            try
            {
                DataSet dtsPromociones = new DataSet();
                dtsPromociones = Promociones.ObtenerPromos(TipoMecanica, Status, "SP_ConsultaTipoMecanicas");

                if (dtsPromociones != null)
                {
                    if (dtsPromociones.Tables.Count > 0)
                    {
                        dtExportarPG = new DataTable();
                        dtExportarPG = dtsPromociones.Tables[0];
                        GridSortExpression sortExpr = new GridSortExpression();
                        lblTituloPromocionVenc.Text = "Piezas Gratis (TM)";
                        lbldivDatCuponVenc.Text = "";
                        lbldivDatMixMatchVenc.Text = "";
                        grvVariosVenc.DataSource = null;
                        grvVariosVenc.DataBind();
                        grvVariosVenc.DataSource = dtsPromociones.Tables[0];
                        if (NumRegxPag > 0)
                        {
                            grvVariosVenc.PageSize = NumRegxPag;
                        }
                        else
                        {
                            if (dtsPromociones.Tables[0].Rows.Count > 0)
                            {
                                grvVariosVenc.PageSize = dtsPromociones.Tables[0].Rows.Count;
                            }
                        }

                        sortExpr.FieldName = "Segmento";
                        sortExpr.SortOrder = GridSortOrder.Ascending;
                        grvVariosVenc.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
                        grvVariosVenc.CurrentPageIndex = 0;
                        grvVariosVenc.DataBind();
                    }
                }
                else
                {
                    grvVariosVenc.DataSource = null;
                    grvVariosVenc.DataBind();
                }
                chkAv.Visible = true;
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.ConsultaPromociones", "BuscarxTipoMecanica", "dtsPromociones = Promociones.ObtenerPromos(" + TipoMecanica.ToString() + "," + Status.ToString() + ", SP_ConsultaTipoMecanicas)", "Ocurrio un error", this.User.Identity.Name.ToString(), ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('Ocurrio un error interno contacte al Administrador del sistema..." + "');", true);
            }
        }

        protected int BuscarxLabxProv(int IdLaboratorio, string NomProveedor, int NumRegxPag)
        {
            int EncontroResultados = 0;
            int i = 0;
            try
            {
                for (i = 1; i <= 3; ++i)
                {
                    DataSet dtsPromociones = new DataSet();
                    dtsPromociones = Promociones.ObtenerPromos(i, IdLaboratorio, NomProveedor, "SP_ConsultaxLaboratorio");
                    GridSortExpression sortExpr = new GridSortExpression();
                    if (dtsPromociones != null)
                    {
                        if (dtsPromociones.Tables.Count > 0 && dtsPromociones.Tables[0].Rows.Count > 0)
                        {
                            EncontroResultados = 1;
                            switch (i)
                            {
                                case (1):
                                    dtExportarPG = new DataTable();
                                    dtExportarPG = dtsPromociones.Tables[0];
                                    lblTituloPromocionVenc.Text = "Piezas Gratis (Lab)";
                                    grvVariosVenc.DataSource = dtsPromociones.Tables[0];
                                    if (NumRegxPag > 0)
                                    {
                                        grvVariosVenc.PageSize = NumRegxPag;
                                    }
                                    else
                                    {
                                        grvVariosVenc.PageSize = dtsPromociones.Tables[0].Rows.Count;
                                    }

                                    sortExpr.FieldName = "Segmento";
                                    sortExpr.SortOrder = GridSortOrder.Ascending;
                                    grvVariosVenc.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
                                    grvVariosVenc.CurrentPageIndex = 0;
                                    grvVariosVenc.DataBind();
                                    break;

                                case (2):
                                    dtExportarACDE = new DataTable();
                                    dtExportarACDE = dtsPromociones.Tables[0];
                                    lbldivDatCuponVenc.Text = "Acumulación DE (Lab)";
                                    grvCuponVenc.Visible = false;
                                    grvAcDELab.Visible = true;
                                    grvAcDELab.DataSource = dtsPromociones.Tables[0];
                                    if (NumRegxPag > 0)
                                    {
                                        grvAcDELab.PageSize = NumRegxPag;
                                    }
                                    else
                                    {
                                        if (dtsPromociones.Tables[0].Rows.Count > 0)
                                        {
                                            grvAcDELab.PageSize = dtsPromociones.Tables[0].Rows.Count;
                                        }
                                    }

                                    sortExpr.FieldName = "Segmento";
                                    sortExpr.SortOrder = GridSortOrder.Ascending;
                                    grvAcDELab.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
                                    grvAcDELab.CurrentPageIndex = 0;
                                    grvAcDELab.DataBind();
                                    break;

                                case (3):
                                    dtExportarMixMatch = new DataTable();
                                    dtExportarMixMatch = dtsPromociones.Tables[0];
                                    lbldivDatMixMatchVenc.Text = "Mix & Match (Lab)";
                                    grvMixMatchLab.Visible = true;
                                    grvMixMatchLab.DataSource = dtsPromociones.Tables[0];
                                    if (NumRegxPag > 0)
                                    {
                                        grvMixMatchLab.PageSize = NumRegxPag;
                                    }
                                    else
                                    {
                                        if (dtsPromociones.Tables[0].Rows.Count > 0)
                                        {
                                            grvMixMatchLab.PageSize = dtsPromociones.Tables[0].Rows.Count;
                                        }
                                    }

                                    sortExpr.FieldName = "Segmento";
                                    sortExpr.SortOrder = GridSortOrder.Ascending;
                                    grvMixMatchLab.MasterTableView.SortExpressions.AddSortExpression(sortExpr);
                                    grvMixMatchLab.CurrentPageIndex = 0;
                                    grvMixMatchLab.DataBind();
                                    break;
                            }
                        }
                        else
                        {
                            switch (i)
                            {
                                case (1):
                                    dtExportarPG = new DataTable();
                                    dtExportarPG = dtsPromociones.Tables[0];
                                    lblTituloPromocionVenc.Text = "Piezas Gratis (Lab)";
                                    grvVariosVenc.DataSource = dtExportarPG;
                                    grvVariosVenc.DataBind();
                                    break;

                                case (2):
                                    dtExportarACDE = new DataTable();
                                    dtExportarACDE = dtsPromociones.Tables[0];
                                    lbldivDatCuponVenc.Text = "Acumulación DE (Lab)";
                                    grvAcDELab.DataSource = dtExportarACDE;
                                    grvAcDELab.DataBind();
                                    grvAcDELab.Visible = true;
                                    grvCuponVenc.Visible = false;
                                    break;

                                case (3):
                                    dtExportarMixMatch = new DataTable();
                                    dtExportarMixMatch = dtsPromociones.Tables[0];
                                    grvMixMatchLab.DataSource = dtExportarMixMatch;
                                    grvMixMatchLab.DataBind();
                                    grvCuponVenc.Visible = false;
                                    grvAcDELab.Visible = true;
                                    grvMixMatchLab.Visible = true;
                                    lbldivDatMixMatchVenc.Text = "Mix & Match (Lab)";
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case (1):
                                grvVariosVenc.DataSource = null;
                                grvVariosVenc.DataBind();
                                break;
                            case (2):
                                grvCuponVenc.DataSource = null;
                                grvCuponVenc.DataBind();
                                grvAcDELab.DataSource = null;
                                grvAcDELab.DataBind();
                                break;
                            case (3):
                                grvMixMatchLab.DataSource = null;
                                grvMixMatchLab.DataBind();
                                break;
                        }
                        chkAv.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.ConsultaPromociones", "BuscarxLabxProv", "dtsPromociones = Promociones.ObtenerPromos(" + i.ToString() + "," + IdLaboratorio.ToString() + "," + NomProveedor.ToString() + ", SP_ConsultaxLaboratorio)", "Ocurrio un error", this.User.Identity.Name.ToString(), ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('Ocurrio un error interno contacte al Administrador del sistema..." + "');", true);
            }
            return EncontroResultados;
        }

        protected void imgbtnExpAllExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (grvPzasGratis.Items.Count == 0 && grvAcumDE.Items.Count == 0 && grvDE.Items.Count == 0 && grvMixMatch.Items.Count == 0)
            {
                var Mensaje = "No existen resultados que exportar...";
                ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');OpcionesExporExcel;", true);
                return;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "OpcionesExporExcel();", true);
        }

        protected void rbtnExportar_Click(object sender, EventArgs e)
        {
            bool siSelecciono = false;
            ExportarExcel Crear = new ExportarExcel();
            if (rdbPG.Checked && !rpvLaboratorio.Selected)
            {
                if (grvPzasGratis.Items.Count > 0)
                {
                    siSelecciono = true;
                    //grvPzasGratis.ExportSettings.ExportOnlyData = true;
                    //grvPzasGratis.ExportSettings.IgnorePaging = true;
                    //grvPzasGratis.ExportSettings.OpenInNewWindow = true;
                    //grvPzasGratis.ExportSettings.FileName = "ConsultaPromociones_PiezasGratis" + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.Second.ToString();
                    //grvPzasGratis.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Xlsx;
                    //grvPzasGratis.ExportToExcel();
                    IniciarDescarga(Crear.ExportarCVS(dtExportarPG), "ConsultaPromociones_PiezasGratis");
                }
                else
                {
                    var Mensaje = "No existen resultados que exportar...";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');OpcionesExporExcel();", true);
                    return;
                }
            }
            if (rdbAcumDE.Checked && !rpvLaboratorio.Selected)
            {

                if (grvAcumDE.Items.Count > 0)
                {
                    siSelecciono = true;
                    //grvAcumDE.ExportSettings.ExportOnlyData = true;
                    //grvAcumDE.ExportSettings.IgnorePaging = true;
                    //grvAcumDE.ExportSettings.OpenInNewWindow = true;
                    //grvAcumDE.ExportSettings.FileName = "ConsultaPromociones_AcumulacionDE" + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.Second.ToString();
                    //grvAcumDE.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Xlsx;
                    //grvAcumDE.ExportToExcel();
                    IniciarDescarga(Crear.ExportarCVS(dtExportarACDE), "ConsultaPromociones_AcumulacionDE");
                }
                else
                {
                    var Mensaje = "No existen resultados que exportar...";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');OpcionesExporExcel();", true);
                    return;
                }
            }

            if (rdbDE.Checked && !rpvLaboratorio.Selected)
            {
                if (grvDE.Items.Count > 0)
                {
                    siSelecciono = true;
                    //grvDE.ExportSettings.ExportOnlyData = true;
                    //grvDE.ExportSettings.IgnorePaging = true;
                    //grvDE.ExportSettings.OpenInNewWindow = true;
                    //grvDE.ExportSettings.FileName = "ConsultaPromociones_DineroElectronico" + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.Second.ToString();
                    //grvDE.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Xlsx;
                    //grvDE.ExportToExcel();
                    IniciarDescarga(Crear.ExportarCVS(dtExportarDE), "ConsultaPromociones_DineroElectronico");
                }
                else
                {
                    var Mensaje = "No existen resultados que exportar...";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');OpcionesExporExcel();", true);
                    return;
                }
            }

            if (rdbMixMatch.Checked && !rpvLaboratorio.Selected)
            {
                if (grvMixMatch.Items.Count > 0)
                {
                    siSelecciono = true;
                    IniciarDescarga(Crear.ExportarCVS(dtExportarMixMatch), "ConsultaPromociones_Mix&Match");
                }
                else
                {
                    var Mensaje = "No existen resultados que exportar...";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');OpcionesExporExcel();", true);
                    return;
                }
            }
            //===============================================================================================================================================================================//
            //if (rdbPG.Checked && rpvLaboratorio.Selected)
            //{


            //    if (grvVariosVenc.Items.Count > 0)
            //    {
            //        siSelecciono = true;
            //        //grvVariosVenc.ExportSettings.ExportOnlyData = true;
            //        //grvVariosVenc.ExportSettings.IgnorePaging = true;
            //        //grvVariosVenc.ExportSettings.OpenInNewWindow = true;
            //        //grvVariosVenc.ExportSettings.FileName = "ConsultaPromociones_PiezasGratis" + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.Second.ToString();
            //        //grvVariosVenc.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Xlsx;
            //        //grvVariosVenc.ExportToExcel();
            //        IniciarDescarga(Crear.ExportarCVS(dtExportarPG), "ConsultaPromociones_PiezasGratis(Lab)");
            //    }
            //    else
            //    {
            //        var Mensaje = "No existen resultados que exportar...";
            //        ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');OpcionesExporExcel();", true);
            //        return;
            //    }
            //}
            //if (rdbAcumDE.Checked && rpvLaboratorio.Selected)
            //{

            //    if (grvAcDELab.Items.Count > 0)
            //    {
            //        siSelecciono = true;
            //        //grvCuponVenc.ExportSettings.ExportOnlyData = true;
            //        //grvCuponVenc.ExportSettings.IgnorePaging = true;
            //        //grvCuponVenc.ExportSettings.OpenInNewWindow = true;
            //        //grvCuponVenc.ExportSettings.FileName = "ConsultaPromociones_AcumulacionDE" + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.Second.ToString();
            //        //grvCuponVenc.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Xlsx;
            //        //grvCuponVenc.ExportToExcel();
            //        IniciarDescarga(Crear.ExportarCVS(dtExportarACDE), "ConsultaPromociones_AcumulacionDE(Lab)");
            //    }
            //    else
            //    {
            //        var Mensaje = "No existen resultados que exportar...";
            //        ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');OpcionesExporExcel();", true);
            //        return;
            //    }
            //}

            //if (rdbDE.Checked && rpvLaboratorio.Selected)
            //{
            //    var Mensaje = "No existen resultados que exportar...";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "AbrirPopupLab('" + Mensaje + "');OpcionesExporExcel();", true);
            //    return;
            //}

            if (!siSelecciono)
            {
                var msg = "Debe seleccionar el resultado a exportar...";
                if (rpvLaboratorio.Selected)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + msg + "');AbrirPopupLab();", true);
                    return;
                }
                else if (rpvProducto.Selected)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + msg + "');AbrirPopup();", true);
                    return;
                }


            }
            siSelecciono = false;
        }

        protected void rbtnCerrar_Click(object sender, EventArgs e)
        {

            //grvPzasGratis = new RadGrid();
            //grvAcumDE = new RadGrid();
            //grvDE = new RadGrid();
            //rdbPG.Checked = false;
            //rdbAcumDE.Checked = false;
            //rdbDE.Checked = false;

            //Session.Clear();
            //Session.Abandon();
            //LimpiaControles();
            ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "CerrarOpcionesExporExcel();", true);
        }

        protected void imgbtnExpVenc_Click(object sender, ImageClickEventArgs e)
        {
            ExportarExcel Crear = new ExportarExcel();
            int TipoPromocion = Convert.ToInt32(rdcTipoPromVenc.SelectedValue);

            if ((rpvVencimiento.Selected && TipoPromocion < 4) || (rpvVencimiento.Selected && TipoPromocion == 6))
            {
                if (dtExportarVARIOSVENC != null)
                {
                    if (dtExportarVARIOSVENC.Rows.Count > 0)
                    {
                        IniciarDescarga(Crear.ExportarCVS(dtExportarVARIOSVENC), "ConsultaPromociones_" + rdcTipoPromVenc.Text.Trim().Replace(" ", ""));
                    }
                    else
                    {
                        Session.Clear();
                        Session.Abandon();
                        LimpiaControles();
                        var msg = "No existen datos para exportar...";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + msg + "');ocultarVentanaVenc();", true);
                        return;
                    }
                }


            }
            else if (rpvVencimiento.Selected && TipoPromocion == 4)
            {
                //grvCuponVenc.ExportSettings.ExportOnlyData = true;
                //grvCuponVenc.ExportSettings.IgnorePaging = true;
                //grvCuponVenc.ExportSettings.OpenInNewWindow = true;
                //grvCuponVenc.ExportSettings.FileName = "ConsultaPromociones" + rdcTipoPromVenc.Text + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.Second.ToString();
                //grvCuponVenc.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Xlsx;
                //grvCuponVenc.ExportToExcel();
                IniciarDescarga(Crear.ExportarCVS(dtExportarCUPON), "ConsultaPromociones_" + rdcTipoPromVenc.Text.Trim().Replace(" ", ""));

            }
            else if (rpvTipoMecanica.Selected)
            {
                //grvVariosVenc.ExportSettings.ExportOnlyData = true;
                //grvVariosVenc.ExportSettings.IgnorePaging = true;
                //grvVariosVenc.ExportSettings.OpenInNewWindow = true;
                //grvVariosVenc.ExportSettings.FileName = "ConsultaPromociones_TM" + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.Second.ToString();
                //grvVariosVenc.ExportSettings.Excel.Format = Telerik.Web.UI.GridExcelExportFormat.Xlsx;
                //grvVariosVenc.ExportToExcel();

                IniciarDescarga(Crear.ExportarCVS(dtExportarPG), "ConsultaPromociones_TM");

            }

        }

        protected void imgbtnExpLab_Click(object sender, ImageClickEventArgs e)
        {
            if (grvVariosVenc.Items.Count == 0 && grvAcumDE.Items.Count == 0 && grvMixMatchLab.Items.Count == 0)
            {
                var Mensaje = "No existen resultados que exportar...";
                ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');", true);
                return;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "OpcionesExporExcelLab();", true);
        }

        private void IniciarDescarga(string secuencia, string filename)
        {
            try
            {
                filename = filename.Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u");
                string nombreDocumento = string.Format("{0}_{1}{2}{3}.{4}", filename, DateTime.Now.Day.ToString("00"), DateTime.Now.Month.ToString("00"), DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString(), "xls");

                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel"; Response.Charset = "UTF-8";
                this.EnableViewState = false;
                Response.AddHeader("Content-Disposition", "attachment;filename=" + nombreDocumento);
                Response.Charset = "UTF-8";
                Response.ContentEncoding = Encoding.Default;
                Response.Write(secuencia.ToString());
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Error: " + ex.Message + ");", true);
            }
        }

        private void LimpiaControles()
        {
            rdcTipoPromo.SelectedIndex = 0;
            rdcSegmento.SelectedIndex = 0;
            rdcEstatus.SelectedIndex = 0;
            rdcItemsxPagina.SelectedIndex = 0;
            rcbTipoMec.SelectedIndex = 0;

            rcbTipoPromCupones.SelectedIndex = 0;
            txtNumCupon.Text = "";
            rdpFIni.SelectedDate = null;
            rdpFFin.SelectedDate = null;
            grvDatos.DataSource = null;
            rdcItemsxPaginaCupon.SelectedIndex = 0;
            grvDatos.DataBind();
            grvDatosCupon.DataSource = null;
            grvDatosCupon.DataBind();
            lbldivDatCuponVenc.Text = "";

            txtNumIntCodBar.Text = "";
            rdbVenciadas.Checked = false;
            rdbVencidasMes.Checked = false;
            rdpDel.SelectedDate = null;
            rdpAl.SelectedDate = null;
            rcbPorVencer.SelectedIndex = 0;

            txtIdLaboratorio.Text = "";
            txtNomProveedor.Text = "";

            grvPzasGratis.DataSource = null;
            grvPzasGratis.DataBind();
            grvAcumDE.DataSource = null;
            grvAcumDE.DataBind();
            grvDE.DataSource = null;
            grvDE.DataBind();
            grvMixMatch.DataSource = null;
            grvMixMatch.DataBind();
            grvMixMatchLab.DataSource = null;
            grvMixMatchLab.DataBind();

            grvDatos.DataSource = null;
            grvDatos.DataBind();
            grvDatosCupon.DataSource = null;
            grvDatosCupon.DataBind();
            rbtnExportarExcel.Visible = true;

            dtExportarDI = null;
            dtExportarVARIOSVENC = null;
            dtExportarPG = null;
            dtExportarACDE = null;
            dtExportarDE = null;
            dtExportarCUPON = null;
            dtExportarIMG = null;
            dtExportarMixMatch = null;

            rdcitemsxPagProd.SelectedIndex = 0;
            rcbitemsxPagLab.SelectedIndex = 0;
            rcbitemsxPagTipoMec.SelectedIndex = 0;
            rcbitemsxpagVenc.SelectedIndex = 0;

        }

        protected void Validaciones()
        {
            if (chkAv.Checked)
            {
                rdcTipoPromo.SelectedIndex = 0;
                rcbTipoPromCupones.SelectedIndex = 0;
                rdcEstatus.SelectedIndex = 0;
                txtCodIntDI.Text = "";
                txtCodIntDI.Visible = false;
                if (rdcTipoPromo.SelectedValue != "3")
                {
                    txtCodIntDI.Visible = false;
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", "javascript:BusquedaAvanzada();", true);
            }
            else if (rdcTipoPromo.SelectedIndex == 3 || rcbTipoPromCupones.SelectedIndex == 3)//Cupones
            {
                rdcTipoPromo.SelectedIndex = 0;
                rcbTipoPromCupones.SelectedIndex = 3;
                if (rdcTipoPromo.SelectedValue != "3")
                {
                    txtCodIntDI.Visible = false;
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", "javascript:SecBusqueda('Cupones');", true);
            }
            else if (rdcTipoPromo.SelectedIndex == 4 || rcbTipoPromCupones.SelectedIndex == 4) //Imagenes
            {
                rdcTipoPromo.SelectedIndex = 4;
                if (rdcTipoPromo.SelectedValue != "3")
                {
                    txtCodIntDI.Visible = false;
                }
                //rcbTipoPromCupones.SelectedIndex = 0;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", "javascript:SecBusqueda('Imagenes');", true);
            }
            else
            {
                txtNumCupon.Text = "";
                grvDatos.Visible = false;
                txtCodIntDI.DisplayText = "";
                if (rdcTipoPromo.SelectedIndex != 2)
                {
                    txtCodIntDI.Text = "";
                    txtCodIntDI.DisplayText = "Ingrese código interno";
                    txtCodIntDI.Visible = false;
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "", "javascript:OcultarBusquedaAvanzada();SecBusquedaOcultar('');", true);
            }
        }

        protected void imgbtnCerrar_Click(object sender, ImageClickEventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            LimpiaControles();
            ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "ocultarVentana();", true);
        }

        protected void imbtnCerrarVenc_Click(object sender, ImageClickEventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            LimpiaControles();
            ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "ocultarVentanaVenc();", true);
        }

        protected void txtNumIntCodBar_TextChanged(object sender, EventArgs e)
        {
            if (txtNumIntCodBar.Text != "")
            {
                txtNumIntCodBar.DisplayText = "";
            }
        }

        protected void btnExpOpcLab_Click(object sender, EventArgs e)
        {
            bool siSelecciono = false;
            ExportarExcel Crear = new ExportarExcel();

            if (rdbtnPGLab.Checked && rpvLaboratorio.Selected)
            {
                if (grvVariosVenc.Items.Count > 0)
                {
                    siSelecciono = true;
                    IniciarDescarga(Crear.ExportarCVS(dtExportarPG), "ConsultaPromociones_PiezasGratis(Lab)");
                }
                else
                {
                    var Mensaje = "No existen resultados que exportar...";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');OpcionesExporExcelLab();", true);
                    return;
                }
            }
            if (rdbtnACDELab.Checked && rpvLaboratorio.Selected)
            {

                if (grvAcDELab.Items.Count > 0)
                {
                    siSelecciono = true;
                    IniciarDescarga(Crear.ExportarCVS(dtExportarACDE), "ConsultaPromociones_AcumulacionDE(Lab)");
                }
                else
                {
                    var Mensaje = "No existen resultados que exportar...";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');OpcionesExporExcelLab();", true);
                    return;
                }
            }

            if (rdbtnMixMatchLab.Checked && rpvLaboratorio.Selected)
            {
                if (grvMixMatchLab.Items.Count > 0)
                {
                    siSelecciono = true;
                    IniciarDescarga(Crear.ExportarCVS(dtExportarMixMatch), "ConsultaPromociones_MixMatch(Lab)");
                }
                else
                {
                    var Mensaje = "No existen resultados que exportar...";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + Mensaje + "');OpcionesExporExcelLab();", true);
                    return;
                }
            }


            if (!siSelecciono)
            {
                var msg = "Debe seleccionar el resultado a exportar...";
                ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('" + msg + "');AbrirPopupLab();", true);
                return;
            }
            siSelecciono = false;
        }

        protected void btnCerrarOpcLab_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "CerrarOpcionesExporExcelLab();", true);
        }

        protected void txtCodIntDI_TextChanged(object sender, EventArgs e)
        {
            if (txtCodIntDI.Text != "")
            {
                txtCodIntDI.DisplayText = "";
            }
        }

        protected void rdcEstatus_TextChanged(object sender, EventArgs e)
        {
            if (rdcEstatus.SelectedIndex == 1 && rdcTipoPromo.SelectedIndex == 2)
            {
                txtCodIntDI.Text = "";
                txtCodIntDI.Visible = false;
            }
            else if ((rdcEstatus.SelectedIndex == 0 && rdcTipoPromo.SelectedIndex == 2) || (rdcEstatus.SelectedIndex == 2 && rdcTipoPromo.SelectedIndex == 2))
            {
                txtCodIntDI.Text = "";
                txtCodIntDI.Visible = true;
                txtCodIntDI.Focus();
            }
        }

        protected void grvMixMatch_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            rbtnBuscarProd_Click(null, null);
        }

        protected void grvMixMatch_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarProd_Click(null, null);
            }
            else
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Descending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarProd_Click(null, null);
            }
        }

        protected void grvMixMatchLab_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            //int TipoMecanica = Convert.ToInt32(rcbTipoMec.SelectedValue);
            //int IdLaboreatorio = Convert.ToInt32(txtIdLaboratorio.Text);
            //string NomProveedor = txtNomProveedor.Text;
            //int NumRegxPag = Convert.ToInt32(rcbitemsxPagLab.SelectedValue);

            //BuscarxLabxProv(IdLaboreatorio, NomProveedor, NumRegxPag);
            rbtnBuscarLab_Click(null, null);
        }

        protected void grvMixMatchLab_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarLab_Click(null, null);
            }
            else
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Descending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                rbtnBuscarLab_Click(null, null);
            }
        }

    }
}
