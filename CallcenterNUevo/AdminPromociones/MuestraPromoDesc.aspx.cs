using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Datos;
using Negocio;

namespace CallcenterNUevo.AdminPromociones
{
    public partial class MuestraPromoDesc : System.Web.UI.Page
    {
        public static string Cnn = "ConnectionString";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaCombo();
                CargarChksBIN();
                EliminaVariablesSesion();
            }
        }
        protected void txtNomProd_TextChanged(object sender, EventArgs e)
        {
            SeteaRegistrosProd();
        }
        protected void txtSucursal_TextChanged(object sender, EventArgs e)
        {
            SeteaRegistrosSuc();

            //List<ModSucursalesPromoACBase> lstSuc = new List<ModSucursalesPromoACBase>();
            //lstSuc = (List<ModSucursalesPromoACBase>)Session["lstResSuc"];
            //AdministraPromocion Ejecutar = new AdministraPromocion();
            //int i = 0;
            //int intCiaSuc = 0;
            //for (i = 0; i < grvSucursales.Rows.Count; i++)
            //{
            //    GridViewRow dtgItem = grvSucursales.Rows[i];
            //    TextBox txtNomSuc = ((TextBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("txtSucursal"));
            //    TextBox txtCiaSuc = ((TextBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("txtCiaSuc"));

            //     intCiaSuc  = ObtenEquivalenciaSucursal(txtNomSuc.Text);
            //     if (intCiaSuc == 99999)
            //     {
            //         Mensajes("La sucursal: " + txtNomSuc.Text + ", no es valida, ¡Verifique su información e intente de nuevo.!");
            //         if (lstSuc != null)
            //         {
            //             txtNomSuc.Text = lstSuc[i].NomSucursal;
            //             txtNomSuc.Focus();
            //             break;
            //         }
            //         else {
            //             txtNomSuc.Text = "";
            //             txtNomSuc.Focus();
            //             break;
            //         }

            //     }
            //     else {
            //         txtCiaSuc.Text = intCiaSuc.ToString();
            //         break;
            //     }
            //}
        }
        protected void txtLimite_TextChanged(object sender, EventArgs e)
        {

        }
        protected void chkNivNac_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkNivNac.Checked)
            {
                AdministraPromocion Ejecutar = new AdministraPromocion();
                List<ModSucursalesPromoACBase> lstSuc = new List<ModSucursalesPromoACBase>();
                lstSuc = (List<ModSucursalesPromoACBase>)Session["lstResSuc"];
                if (lstSuc == null)
                {
                    NuevoregistroSucursales();
                }
                else
                {
                    //int IdPDescuento = 0;
                    //IdPDescuento = (int)Session["intIdPABase"];


                    //if (Ejecutar.ObtenSucursalDescuento(IdPDescuento)[0].Sucursal != 0)
                    //{
                    //    lstSuc = Ejecutar.ObtenSucursalDescuento(IdPDescuento);
                    //}

                    //Si previamente contenia Sucursales a nivel nacional
                    //Instancia la variable de lista para que ese valor no sea agregado 
                    //en el gridSucursales
                    if (lstSuc[0].Sucursal == 0)
                    {
                        lstSuc = new List<ModSucursalesPromoACBase>();
                    }


                    //Session.Add("lstResSucSource", lstSuc);
                    //Session.Add("lstResSuc", lstSuc);

                    grvSucursales.DataSource = lstSuc;
                    grvSucursales.DataBind();
                    grvSucursales.Enabled = true;
                    btnAgregarSuc.Visible = true;
                }
            }
            else
            {
                grvSucursales.Enabled = false;
                btnAgregarSuc.Visible = false;
                grvSucursales.DataSource = null;
                grvSucursales.DataBind();
            }
        }
        protected void grvDatos_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            List<ModPromocionDescuentos> lstProm = new List<ModPromocionDescuentos>();
            lstProm = (List<ModPromocionDescuentos>)Session["lstResultado"];
            int IdPDescuento = 0;

            IdPDescuento = Convert.ToInt32(e.CommandArgument);
            Session.Add("intIdPABase", IdPDescuento);
            CargaInformacion(IdPDescuento, lstProm);

            //Muestra formulario
            mvProductrosSuc.SetActiveView(vEditaPromocionDescuento);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                AdministraPromocion Ejecutar = new AdministraPromocion();
                List<ModPromocionDescuentos> lstResultado = new List<ModPromocionDescuentos>();

                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.MuestraProDesc", "btnBuscar_Click", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
                lstResultado = Ejecutar.ObtenPromoDescuento(txtNomPromACBase.Text);
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.MuestraProDesc", "btnBuscar_Click", "Fin de Consulta", this.User.Identity.Name.ToString(), null);

                grvDatos.DataSource = lstResultado;
                grvDatos.DataBind();

                Session.Add("lstResultado", lstResultado);
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraPromoDesc", "btnBuscar_Click", "Ejecutar.ObtenPromoDescuento(" + txtNomPromACBase.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al buscar promoción de descuento, contacte al administrador");
            }

        }
        protected void btnAgregarProd_Click(object sender, EventArgs e)
        {
            NuevoregistroProductos();
        }
        protected void btnAgregarSuc_Click(object sender, EventArgs e)
        {
            NuevoregistroSucursales();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdPDescuento = 0;
                IdPDescuento = (int)Session["intIdPABase"];

                if (IdPDescuento > 0)
                {
                    if (Validaciones())
                    {
                        Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.MuestraProDesc", "btnGuardar_Click", "Inicio de Guardado", this.User.Identity.Name.ToString(), null);
                        //Actualiza la promoción
                        ModificaPromoDescuento(IdPDescuento);

                        //Actualiza los dias de la promoción
                        if (ModificarDias(IdPDescuento))
                        {
                            //Actualiza los bins de la promoción
                            if (ModificarBins(IdPDescuento))
                            {
                                //Actualiza Productos de la promoción
                                if (ModificarProductosPromocionesDescuento(IdPDescuento))
                                {
                                    //Actualiza las sucursales de la promoción
                                    if (ModificarSucursalesPromocionesDescuento(IdPDescuento))
                                    {
                                        EliminaVariablesSesion();
                                        LimpiarCampos();
                                        Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.MuestraProDesc", "btnGuardar_Click", "Fin de Guardado", this.User.Identity.Name.ToString(), null);
                                        Mensajes("Se ha modificado la promoción de acumulación base correctamente.");
                                        //Muestra módulo de consulta
                                        mvProductrosSuc.SetActiveView(vConsultaPromocionesDescuento);
                                        btnBuscar_Click(null, null);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    // Mensajes("Imposible realizar esta acción, consulte la promoción nuevamente e intente modificar.");
                    //Muestra módulo de consulta
                    mvProductrosSuc.SetActiveView(vConsultaPromocionesDescuento);
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraPromoDesc", "btnGuardar_Click", "Metodos de guardado", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar modificar la promoción de descuento, contacte al administrador");
            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            EliminaVariablesSesion();
            LimpiarCampos();
            mvProductrosSuc.SetActiveView(vConsultaPromocionesDescuento);
            btnBuscar_Click(null, null);
        }


        private void CargaCombo()
        {
            try
            {
                AdministraPromocion ejecuta = new AdministraPromocion();
                List<ModLimitePeriodo> lstResultadoslimPer = new List<ModLimitePeriodo>();
                lstResultadoslimPer = ejecuta.ObtenLimitePeriodo(Cnn);

                if (lstResultadoslimPer != null)
                {
                    if (lstResultadoslimPer.Count > 0)
                    {
                        rcbLimPeriodo.Items.Clear();
                        rcbLimPeriodo.DataSource = lstResultadoslimPer;
                        rcbLimPeriodo.DataTextField = "Periodo";
                        rcbLimPeriodo.DataValueField = "IdPeriodo";
                        rcbLimPeriodo.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromociónDescuentos", "CargaCombo()", "ejecuta.ObtenLimitePeriodo()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar Límite Periodo, contacte al administrador");
            }
        }
        private void CargarChksBIN()
        {
            AdministraPromocion Ejecuta = new AdministraPromocion();
            List<ModBin> lstResultadosBin = new List<ModBin>();
            lstResultadosBin = Ejecuta.ObtenBins(Cnn);

            if (lstResultadosBin != null)
            {
                if (lstResultadosBin.Count > 0)
                {
                    ListItem i;
                    foreach (ModBin reg in lstResultadosBin)
                    {
                        i = new ListItem(reg.DescClub, reg.IdClub.ToString());
                        chkBIN.Items.Add(i);
                    }
                }
            }
        }
        private void CargaInformacion(int IdPDescuento, List<ModPromocionDescuentos> lstProm)
        {
            AdministraPromocion Ejecutar = new AdministraPromocion();

            lstProm = lstProm.Where(w => w.IdPDescuento == IdPDescuento).ToList();

            txtNombrePromocion.Text = lstProm[0].NombrePromocion;
            txtCantidadAC.Text = lstProm[0].Cantidad.ToString();
            rcbLimPeriodo.SelectedValue = lstProm[0].IdPeriodo.ToString();
            txtLimite.Text = lstProm[0].Limite.ToString();

            rdpFechaIni.SelectedDate = lstProm[0].FechaInicio;
            rdpFechaFin.SelectedDate = lstProm[0].FechaFin;
            if (lstProm[0].ServicioDomicilio == 1)
            {
                chkServicioDom.Checked = true;
            }
            else
            {
                chkServicioDom.Checked = false;
            }

            if (lstProm[0].Inapam == 1)
            {
                chkINAPAM.Checked = true;
            }
            else
            {
                chkINAPAM.Checked = false;
            }

            if (lstProm[0].AcumulacionBase == 1)
            {
                chkACBase.Checked = true;
            }
            else
            {
                chkACBase.Checked = false;
            }

            if (lstProm[0].AcumulacionPiezas == 1)
            {
                chkACPiezas.Checked = true;
            }
            else
            {
                chkACPiezas.Checked = false;
            }
            //===========================================================================================================================
            //obtener Productos
            List<ModProductosPromoACBase> lstResProd = new List<ModProductosPromoACBase>();

            lstResProd = Ejecutar.ObtenProductosDescuento(IdPDescuento);
            grvProductos.DataSource = lstResProd;
            grvProductos.DataBind();
            Session.Add("lstResProdSource", lstResProd);
            Session.Add("lstResProd", lstResProd);

            //obtener Sucursales
            List<ModSucursalesPromoACBase> lstResSuc = new List<ModSucursalesPromoACBase>();

            lstResSuc = Ejecutar.ObtenSucursalDescuento(IdPDescuento);
            if (lstResSuc.Count >= 1 && lstResSuc[0].Sucursal != 0)
            {
                grvSucursales.DataSource = lstResSuc;
                grvSucursales.DataBind();
                Session.Add("lstResSucSource", lstResSuc);
                Session.Add("lstResSuc", lstResSuc);
            }
            else if (lstResSuc.Count == 1 && lstResSuc[0].Sucursal == 0)
            {
                chkNivNac.Checked = true;
                grvSucursales.Enabled = false;
                btnAgregarSuc.Visible = false;
            }
            //===========================================================================================================================
            //Obtener Dias
            List<ModDiasPromoACBAse> lstResDias = new List<ModDiasPromoACBAse>();

            lstResDias = Ejecutar.ObtenDiasDescuento(IdPDescuento);

            //Implementar seteo de Dias
            foreach (ModDiasPromoACBAse campos in lstResDias)
            {
                switch (campos.Dia)
                {
                    case 1:
                        chkLunes.Checked = true;
                        break;
                    case 2:
                        chkMartes.Checked = true;
                        break;
                    case 3:
                        chkMiercoles.Checked = true;
                        break;
                    case 4:
                        chkJueves.Checked = true;
                        break;
                    case 5:
                        chkViernes.Checked = true;
                        break;
                    case 6:
                        chkSabado.Checked = true;
                        break;
                    case 7:
                        chkDomingo.Checked = true;
                        break;
                }
            }
            //===========================================================================================================================
            //Obtener Bin's
            List<ModBin> lstBins = new List<ModBin>();
            lstBins = Ejecutar.ConsultaBins(Cnn, IdPDescuento);

            //Recorre checkboxList 
            int i = 0;
            for (i = 0; i <= (chkBIN.Items.Count - 1); i++)
            {
                foreach (ModBin reg in lstBins)
                {
                    //if (reg.IdClub == 3 || reg.IdClub == 12)
                    //{
                    //    chkBIN.Items[0].Selected = true;
                    //}
                    //else if (reg.IdClub == Convert.ToInt32(chkBIN.Items[i].Value))
                    //{
                        chkBIN.Items[i].Selected = true;
                    //}
                }
            }
        }
        private bool Validaciones()
        {

            if (string.IsNullOrWhiteSpace(txtNombrePromocion.Text))
            {
                Mensajes("Debe proporcionar un Nombre de Promoción.");
                txtNombrePromocion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidadAC.Text))
            {
                Mensajes("Debe proporcionar una cantidad de acumulación.");
                txtCantidadAC.Focus();
                return false;
            }

            //=========================================================================================================================================
            //Valida gridview Productos
            int countreg = 0;
            int i = 0;
            bool blnExistenProdActivos = false;

            countreg = grvProductos.Rows.Count; //Contador total de registros en el GridView

            // PREPARA EL CICLO PARA REVISAR EL ESTADO DEL CHECK DE LOS SERVICIOS UNO A UNO...
            for (i = 0; i < grvProductos.Rows.Count; i++)
            {
                GridViewRow dtgItem = grvProductos.Rows[i];
                CheckBox Sel = ((CheckBox)grvProductos.Rows[dtgItem.RowIndex].FindControl("chkProducto"));
                bool valor = Sel.Checked;

                if (valor)
                {
                    blnExistenProdActivos = true;
                    break;
                }
            }

            if (!blnExistenProdActivos)
            {
                Mensajes("Imposible continuar, debe existir almenos un producto activo.");
                grvProductos.Focus();
                return false;
            }
            //=========================================================================================================================================

            //Valida Sucursales
            countreg = 0;
            blnExistenProdActivos = false;

            countreg = grvSucursales.Rows.Count; //Contador total de registros en el GridView

            // PREPARA EL CICLO PARA REVISAR EL ESTADO DEL CHECK DE LOS SERVICIOS UNO A UNO...
            if (!chkNivNac.Checked)
            {
                for (i = 0; i < grvSucursales.Rows.Count; i++)
                {
                    GridViewRow dtgItem = grvSucursales.Rows[i];
                    CheckBox Sel = ((CheckBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("chkSucursal"));
                    bool valor = Sel.Checked;

                    if (valor)
                    {
                        blnExistenProdActivos = true;
                        break;
                    }
                }
                if (!blnExistenProdActivos)
                {
                    Mensajes("Imposible continuar, debe existir almenos una sucursal activa.");
                    grvSucursales.Focus();
                    return false;
                }
            }

            //=========================================================================================================================================




            decimal intCantidad = 0;
            intCantidad = Convert.ToDecimal(txtCantidadAC.Text);

            if (intCantidad > 100)
            {
                Mensajes("La cantidad de acumulación no puede ser mayor a 100");
                txtCantidadAC.Text = "";
                txtCantidadAC.Focus();
                return false;
            }
            //====================================================================================================================================

            if (rdpFechaIni.SelectedDate == null)
            {
                Mensajes("Debe seleccionar una Fecha Inicio.");
                rdpFechaIni.Focus();
                return false;
            }

            if (rdpFechaFin.SelectedDate == null)
            {
                Mensajes("Debe seleccionar una Fecha Fin.");
                rdpFechaFin.Focus();
                return false;
            }

            if (rdpFechaIni.SelectedDate.Value != null)
            {
                if (rdpFechaIni.SelectedDate < DateTime.Now.Date)
                {
                    Mensajes("No es posible que la fecha inicio sea menor a la fecha actual.");
                    rdpFechaIni.Clear();
                    rdpFechaIni.Focus();
                    return false;
                }
            }

            if (rdpFechaIni.SelectedDate > rdpFechaFin.SelectedDate)
            {
                Mensajes("La Fecha Fin no puede ser menor a la Fecha Inicio.");
                rdpFechaFin.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(rcbLimPeriodo.SelectedValue))
            {
                rcbLimPeriodo.Focus();
                Mensajes("Imposible continuar, debe proporcionar el limite de periodo.");
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtLimite.Text))
            {
                txtLimite.Focus();
                Mensajes("Imposible continuar, debe proporcionar el Límite.");
                return false;
            }

            if (chkLunes.Checked == false && chkMartes.Checked == false && chkMiercoles.Checked == false && chkJueves.Checked == false && chkViernes.Checked == false && chkSabado.Checked == false && chkDomingo.Checked == false)
            {
                Mensajes("Debe seleccionar un día de la semana por lo menos.");
                return false;
            }

            //Bin´s
            i = 0;
            bool blnSeleccionbin = false;
            for (i = 0; i <= chkBIN.Items.Count; i++)
            {
                if (chkBIN.Items[i].Selected)
                {
                    //Una vez detectado tan solo un check saldra de la iteración
                    blnSeleccionbin = true;
                    break;
                }
            }

            if (!blnSeleccionbin)
            {
                Mensajes("Debe seleccionar un Bin de la lista.");
                chkBIN.Focus();
                return false;
            }

            i = 0;
            //====================================================================================================================================
            //Valida que el producto sea valido
            AdministraPromocion Ejecutar = new AdministraPromocion();
            bool blnResultado = false;

            for (i = 0; i < grvProductos.Rows.Count; i++)
            {
                //GridViewRow dtgItem = grvProductos.Rows[i];
                TextBox txtCodInt = ((TextBox)grvProductos.Rows[i].FindControl("txtNomProd"));

                blnResultado = Ejecutar.ValidaExistenciaCodInternoACBase(txtCodInt.Text);
                if (!blnResultado)
                {
                    if (!string.IsNullOrWhiteSpace(txtCodInt.Text))//Se realiza esta validación para cuando se ha agregado un nuevo producto y este no es valido
                    {
                        Mensajes("El código interno: " + txtCodInt.Text + ", no es valido, ¡Verifique su información e intente de nuevo.!");

                        return blnResultado;
                    }
                }
            }


            //Valida que la sucursal sea valida
            bool blnResultadoSuc = false;
            string valorErrorSucu = "";

            if (grvSucursales.Rows.Count > 0)
            {
                for (i = 0; i < grvSucursales.Rows.Count; i++)
                {
                    //GridViewRow dtgItem = grvSucursales.Rows[i];
                    TextBox txtNomSucursal = ((TextBox)grvSucursales.Rows[i].FindControl("txtSucursal"));
                    TextBox txtSucursal = ((TextBox)grvSucursales.Rows[i].FindControl("txtCiaSuc"));

                    blnResultadoSuc = Ejecutar.ValidaExistenciaSucursalACBase(Convert.ToInt32(txtSucursal.Text));
                    if (!blnResultadoSuc)
                    {
                        Mensajes("La sucursal: " + txtNomSucursal.Text + ", no es valida, ¡Verifique su información e intente de nuevo.!");

                        return blnResultadoSuc;
                    }
                }
            }

            //====================================================================================================================================
            //Valida que lista de productos no contenga registros en blanco
            int intExisteNuevoRegistro = 0;
            List<ModProductosPromoACBase> lstProd = new List<ModProductosPromoACBase>();
            lstProd = (List<ModProductosPromoACBase>)Session["lstResProd"];

            intExisteNuevoRegistro = lstProd.Where(w => w.IdPABase == 0 && w.CodigoInterno == "").Count();
            if (intExisteNuevoRegistro > 0)
            {
                Mensajes("No debe dejar celdas de productos vacios.");
                lstProd.RemoveAll(x => x.IdPABase == 0 && x.CodigoInterno == "");
                grvProductos.DataSource = lstProd;
                grvProductos.DataBind();
                return false;
            }


            //Valida que lista de sucursales no contenga registros en blanco
            intExisteNuevoRegistro = 0;
            List<ModSucursalesPromoACBase> lstSuc = new List<ModSucursalesPromoACBase>();
            lstSuc = (List<ModSucursalesPromoACBase>)Session["lstResSuc"];

            if (lstSuc != null)
            {
                intExisteNuevoRegistro = lstSuc.Where(w => w.IdPABase == 0 && w.Sucursal == 0).Count();
                if (intExisteNuevoRegistro > 0)
                {
                    Mensajes("No debe dejar celdas de sucursales vacias.");
                    lstSuc.RemoveAll(x => x.IdPABase == 0 && x.Sucursal == 0);
                    grvSucursales.DataSource = lstSuc;
                    grvSucursales.DataBind();
                    return false;
                }
            }

            //====================================================================================================================================
            //Valida si la promoción a registrar existe en dbase

            //AdministraPromocion ejecutar = new AdministraPromocion();
            //bool blnRespuesta = false;
            //int i = 0;
            //foreach (ModProductosPromoACBase reg in lstProd)
            //{

            //    ModPromoACBaseValidaciones campos = new ModPromoACBaseValidaciones();
            //    campos.CodigoInterno = reg.CodigoInterno;
            //    campos.Sucursal = lstSuc[i].Sucursal;
            //    campos.FechaIni = Convert.ToDateTime(rdpFechaIni.SelectedDate);
            //    campos.FechaFin = Convert.ToDateTime(rdpFechaFin.SelectedDate);

            //    blnRespuesta = ejecutar.ValidaPromocionDescuento(campos);
            //    if (blnRespuesta)
            //    {
            //        Mensajes("Imposible continuar, la Promoción de descuento con Código Interno: " + campos.CodigoInterno + ", con vigencia del: " + campos.FechaIni.ToShortDateString() + " al " + campos.FechaFin.ToShortDateString() + " y sucursal: " + campos.Sucursal + ", ya existe ligada en alguna promoción. ¡Verifique su vigencia e intente de nuevo!");
            //        return false;
            //        break;
            //    }

            //    i += 1;
            //}
            //====================================================================================================================================

            return true;
        }
        private void NuevoregistroProductos()
        {
            int intExisteNuevoRegistro = 0;
            List<ModProductosPromoACBase> lstProd = new List<ModProductosPromoACBase>();
            lstProd = (List<ModProductosPromoACBase>)Session["lstResProd"];

            intExisteNuevoRegistro = lstProd.Where(w => w.IdPABase == 0 && w.CodigoInterno == "").Count();
            if (intExisteNuevoRegistro == 0)
            {
                ModProductosPromoACBase campos = new ModProductosPromoACBase();
                campos.IdPABase = 0;
                campos.CodigoInterno = "";
                campos.CodigoInternoNvo = "";
                campos.IdStatus = 2;

                lstProd.Add(campos);

                grvProductos.DataSource = lstProd;
                grvProductos.DataBind();
                Session.Add("lstResProd", lstProd);
            }
            else
            {
                Mensajes("No debe dejar celdas de productos vacios.");
                lstProd.RemoveAll(x => x.IdPABase == 0 && x.CodigoInterno == "");
                grvProductos.DataSource = lstProd;
                grvProductos.DataBind();
            }
        }
        private void NuevoregistroSucursales()
        {
            int intExisteNuevoRegistro = 0;
            List<ModSucursalesPromoACBase> lstSuc = new List<ModSucursalesPromoACBase>();

            if (!chkNivNac.Checked)
            {
                lstSuc = (List<ModSucursalesPromoACBase>)Session["lstResSuc"];
                if (lstSuc == null)
                {
                    //lIMPIA GridSucursales
                    lstSuc = new List<ModSucursalesPromoACBase>();

                    intExisteNuevoRegistro = lstSuc.Where(w => w.IdPABase == 0 && w.Sucursal == 0).Count();
                    if (intExisteNuevoRegistro == 0)
                    {
                        ModSucursalesPromoACBase campos = new ModSucursalesPromoACBase();
                        campos.IdPABase = 0;
                        campos.Sucursal = 0;
                        campos.SucursalNva = 0;
                        campos.NomSucursal = "";
                        campos.IdStatus = 2;

                        lstSuc.Add(campos);

                        grvSucursales.DataSource = lstSuc;
                        grvSucursales.DataBind();
                        grvSucursales.Enabled = true;
                        btnAgregarSuc.Visible = true;

                        Session.Add("lstResSucSource", lstSuc);
                        Session.Add("lstResSuc", lstSuc);
                    }
                    else
                    {
                        Mensajes("No debe dejar celdas de sucursal vacias.");
                        lstSuc.RemoveAll(x => x.IdPABase == 0 && x.Sucursal == 0);
                        grvSucursales.DataSource = lstSuc;
                        grvSucursales.DataBind();
                    }
                }
                else
                {
                    //AdministraPromocion Ejecutar = new AdministraPromocion();
                    ////lstSuc = new List<ModSucursalesPromoACBase>();
                    //int IdPDescuento = 0;
                    //IdPDescuento = (int)Session["intIdPABase"];

                    ////obtener Sucursales
                    //if (Ejecutar.ObtenSucursalDescuento(IdPDescuento)[0].Sucursal != 0)
                    //{
                    //    lstSuc = Ejecutar.ObtenSucursalDescuento(IdPDescuento);
                    //}

                    //Si previamente contenia Sucursales a nivel nacional
                    //Instancia la variable de lista para que ese valor no sea agregado 
                    //en el gridSucursales
                    if (lstSuc[0].Sucursal == 0)
                    {
                        lstSuc = new List<ModSucursalesPromoACBase>();
                    }

                    intExisteNuevoRegistro = lstSuc.Where(w => w.IdPABase == 0 && w.Sucursal == 0).Count();
                    if (intExisteNuevoRegistro == 0)
                    {
                        //Agrega nueva fila
                        ModSucursalesPromoACBase campos = new ModSucursalesPromoACBase();
                        campos.IdPABase = 0;
                        campos.Sucursal = 0;
                        campos.SucursalNva = 0;
                        campos.NomSucursal = "";
                        campos.IdStatus = 2;

                        lstSuc.Add(campos);

                        grvSucursales.DataSource = lstSuc;
                        grvSucursales.DataBind();
                        grvSucursales.Enabled = true;
                        btnAgregarSuc.Visible = true;
                        Session.Add("lstResSucSource", lstSuc);
                        Session.Add("lstResSuc", lstSuc);
                    }
                    else
                    {
                        Mensajes("No debe dejar celdas de sucursal vacias.");
                        lstSuc.RemoveAll(x => x.IdPABase == 0 && x.Sucursal == 0);
                        grvSucursales.DataSource = lstSuc;
                        grvSucursales.DataBind();
                    }
                }
            }
        }
        private void SeteaRegistrosProd()
        {
            List<ModProductosPromoACBase> lstProdSource = new List<ModProductosPromoACBase>();
            lstProdSource = (List<ModProductosPromoACBase>)Session["lstResProdSource"];
            List<ModProductosPromoACBase> lstProd = new List<ModProductosPromoACBase>();
            lstProd = (List<ModProductosPromoACBase>)Session["lstResProd"];



            AdministraPromocion Ejecutar = new AdministraPromocion();
            TextBox txtCodInt = new TextBox();
            CheckBox chkProd = new CheckBox();
            bool blnResultado = false;
            int i = 0;
            int intExisteenLista = 0;

            foreach (ModProductosPromoACBase reg in lstProd)
            {
                GridViewRow dtgItem = grvProductos.Rows[i];
                txtCodInt = ((TextBox)grvProductos.Rows[dtgItem.RowIndex].FindControl("txtNomProd"));
                chkProd = ((CheckBox)grvProductos.Rows[dtgItem.RowIndex].FindControl("chkProducto"));
                bool valor = chkProd.Checked;


                //intExisteenLista = lstProd.Where(w => w.IdPABase != 0 && w.CodigoInterno == txtCodInt.Text).Count();
                //if (intExisteenLista > 0)
                //{
                //    Mensajes("El código Interno: " + txtCodInt.Text + ", ya existe en el listado.");
                //    lstProd.RemoveAll(x => x.IdPABase == 0 && x.CodigoInterno == "");
                //    grvProductos.DataSource = lstProd;
                //    grvProductos.DataBind();
                //    break;
                //}

                blnResultado = Ejecutar.ValidaExistenciaCodInternoACBase(txtCodInt.Text);
                if (blnResultado)
                {
                    lstProd[i].IdPABase = reg.IdPABase;
                    lstProd[i].CodigoInternoAnt = lstProdSource[i].CodigoInternoAnt;
                    lstProd[i].CodigoInterno = txtCodInt.Text;
                    lstProd[i].CodigoInternoNvo = txtCodInt.Text;

                    if (reg.IdPABase == 0)
                    {
                        lstProd[i].CodigoInterno = txtCodInt.Text;
                        chkProd.Checked = true;
                    }
                    else
                    {
                        if (valor)
                        {
                            lstProd[i].IdStatus = 1;
                            chkProd.Checked = true;
                        }
                        else
                        {
                            lstProd[i].IdStatus = 2;
                            chkProd.Checked = false;
                        }
                    }
                }
                else
                {
                    Mensajes("El código interno: " + txtCodInt.Text + ", no es valido.");
                    txtCodInt.Text = lstProd[i].CodigoInterno;
                    txtCodInt.Focus();
                    break;
                }
                i += 1;
            }//Fin Foreach


            //===========================================================================
            if (ValidarDuplicados(grvProductos) > 0)
            {
                Mensajes("Imposible agregar el código interno: " + txtCodInt.Text + ", ya existe dentro de la lista.");
                txtCodInt.Text = "";
                chkProd.Checked = false;
                txtCodInt.Focus();
                return;
            }
            //===========================================================================

        }
        private void SeteaRegistrosSuc()
        {
            List<ModSucursalesPromoACBase> lstSucSource = new List<ModSucursalesPromoACBase>();
            lstSucSource = (List<ModSucursalesPromoACBase>)Session["lstResSucSource"];
            List<ModSucursalesPromoACBase> lstSuc = new List<ModSucursalesPromoACBase>();
            lstSuc = (List<ModSucursalesPromoACBase>)Session["lstResSuc"];
            AdministraPromocion Ejecutar = new AdministraPromocion();
            TextBox txtCiaSuc = new TextBox();
            TextBox txtNomSuc = new TextBox();
            CheckBox chkSucursal = new CheckBox();
            bool blnResultado = false;
            int i = 0;
            int intCiaSuc = 0;

            foreach (ModSucursalesPromoACBase reg in lstSuc)
            {
                GridViewRow dtgItem = grvSucursales.Rows[i];
                txtNomSuc = ((TextBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("txtSucursal"));
                txtCiaSuc = ((TextBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("txtCiaSuc"));
                chkSucursal = ((CheckBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("chkSucursal"));
                bool valor = chkSucursal.Checked;
                txtNomSuc.Text = txtNomSuc.Text.ToUpper();

                intCiaSuc = ObtenEquivalenciaSucursal(txtNomSuc.Text);

                if (intCiaSuc != 99999)
                {
                    txtCiaSuc.Text = intCiaSuc.ToString();
                    lstSuc[i].IdPABase = reg.IdPABase;
                    lstSuc[i].NomSucursal = txtNomSuc.Text;
                    if (lstSuc[i].IdPABase == 0)
                    {
                        lstSuc[i].SucursalAnt = Convert.ToInt32(txtCiaSuc.Text);
                    }
                    else
                    {
                        lstSuc[i].SucursalAnt = lstSucSource[i].SucursalAnt;
                    }
                    lstSuc[i].Sucursal = Convert.ToInt32(txtCiaSuc.Text);
                    lstSuc[i].SucursalNva = Convert.ToInt32(txtCiaSuc.Text);
                    if (reg.IdPABase == 0)
                    {
                        lstSuc[i].NomSucursal = txtNomSuc.Text;
                        lstSuc[i].Sucursal = Convert.ToInt32(txtCiaSuc.Text);
                        lstSuc[i].SucursalNva = Convert.ToInt32(txtCiaSuc.Text);
                        lstSuc[i].IdStatus = 1;
                        chkSucursal.Checked = true;
                    }
                    else
                    {
                        if (valor)
                        {
                            lstSuc[i].IdStatus = 1;
                            chkSucursal.Checked = true;
                        }
                        else
                        {
                            lstSuc[i].IdStatus = 2;
                            chkSucursal.Checked = false;
                        }
                    }
                }
                else
                {
                    Mensajes("La sucursal: " + txtNomSuc.Text + ", no es valida, ¡Verifique e intente de nuevo.!");
                    txtNomSuc.Text = lstSuc[i].NomSucursal;
                    txtNomSuc.Focus();
                    break;
                }
                i += 1;
            }//Fin foreach

            //===========================================================================
            if (ValidarDuplicadosSuc(grvSucursales) > 0)
            {
                Mensajes("Imposible agregarla sucursal: " + txtNomSuc.Text + ", ya existe dentro de la lista.");
                txtCiaSuc.Text = "";
                txtNomSuc.Text = "";
                chkSucursal.Checked = false;
                txtNomSuc.Focus();
                return;
            }
            //===========================================================================
        }


        private bool ModificaPromoDescuento(int IdPDescuento)
        {
            bool blnResultado = false;

            try
            {
                AdministraPromocion Ejecutar = new AdministraPromocion();
                ModPromocionDescuentos campos = new ModPromocionDescuentos();

                campos.IdPDescuento = IdPDescuento;
                campos.NombrePromocion = txtNombrePromocion.Text;
                campos.Cantidad = Convert.ToDecimal(txtCantidadAC.Text);
                campos.IdPeriodo = Convert.ToInt32(rcbLimPeriodo.SelectedValue);
                campos.Limite = Convert.ToInt32(txtLimite.Text);

                campos.FechaInicio = Convert.ToDateTime(rdpFechaIni.SelectedDate);
                campos.FechaFin = Convert.ToDateTime(rdpFechaFin.SelectedDate);
                if (chkServicioDom.Checked)
                {
                    campos.ServicioDomicilio = 1;
                }
                else
                {
                    campos.ServicioDomicilio = 0;
                }

                if (chkINAPAM.Checked)
                {
                    campos.Inapam = 1;
                }
                else
                {
                    campos.Inapam = 0;
                }

                if (chkACBase.Checked)
                {
                    campos.AcumulacionBase = 1;
                }
                else
                {
                    campos.AcumulacionBase = 0;
                }

                if (chkACPiezas.Checked)
                {
                    campos.AcumulacionPiezas = 1;
                }
                else
                {
                    campos.AcumulacionPiezas = 0;
                }
                
                campos.UsuarioRegistra = this.User.Identity.Name.ToString();

                blnResultado = Ejecutar.ModificarPromoDescuento(campos);


                return blnResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ModificarDias(int IdPDescuento)
        {
            bool blnRespuesta = false;

            try
            {


                AdministraPromocion Ejecutar = new AdministraPromocion();
                List<ModDiasPromoACBAse> lstDias = new List<ModDiasPromoACBAse>();


                if (chkLunes.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 1;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 1;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }
                if (chkMartes.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 2;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 2;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }
                if (chkMiercoles.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 3;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 3;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }
                if (chkJueves.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 4;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 4;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }
                if (chkViernes.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 5;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 5;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }
                if (chkSabado.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 6;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 6;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }
                if (chkDomingo.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 7;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPDescuento;
                    campos.Dia = 7;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }



                blnRespuesta = Ejecutar.ModificarDiasPromoDescuento(lstDias);

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ModificarBins(int IdPDescuento)
        {
            bool blnRespuesta = false;

            try
            {
                AdministraPromocion Ejecutar = new AdministraPromocion();
                List<ModBin> lstDias = new List<ModBin>();
                blnRespuesta = Ejecutar.DesactivarBinsPromoDescuento(IdPDescuento);

                if (blnRespuesta)
                {
                    //Recorre checkboxList 
                    blnRespuesta = false;
                    int i = 0;
                    for (i = 0; i <= (chkBIN.Items.Count - 1); i++)
                    {
                        if (chkBIN.Items[i].Selected)
                        {
                            ModBin campos = new ModBin();

                            //if (Convert.ToInt32(chkBIN.Items[i].Value) == 3)
                            //{
                            //    //Bin 150
                            //    campos = new ModBin();
                            //    campos.IdPDescuento = IdPDescuento;
                            //    campos.IdClub = 3;

                            //    blnRespuesta = Ejecutar.ModificarBinsPromoDescuento(campos);

                            //    //Bin 151
                            //    campos = new ModBin();
                            //    campos.IdPDescuento = IdPDescuento;
                            //    campos.IdClub = 12;

                            //    blnRespuesta = Ejecutar.ModificarBinsPromoDescuento(campos);
                            //}
                            //else 
                            //{
                            campos = new ModBin();
                            campos.IdPDescuento = IdPDescuento;
                            campos.IdClub = Convert.ToInt32(chkBIN.Items[i].Value);

                            blnRespuesta = Ejecutar.ModificarBinsPromoDescuento(campos);
                            //}
                        }
                    }
                }

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ModificarProductosPromocionesDescuento(int IdPDescuento)
        {
            bool blnRespuesta = false;
            int i = 0;

            try
            {


                AdministraPromocion Ejecutar = new AdministraPromocion();

                //Obtiene lista de productos depurada    
                List<ModProductosPromoACBase> lstProd = new List<ModProductosPromoACBase>();
                lstProd = (List<ModProductosPromoACBase>)Session["lstResProd"];


                for (i = 0; i < grvProductos.Rows.Count; i++)
                {
                    GridViewRow dtgItem = grvProductos.Rows[i];
                    TextBox txtCodInt = ((TextBox)grvProductos.Rows[dtgItem.RowIndex].FindControl("txtNomProd"));
                    CheckBox Sel = ((CheckBox)grvProductos.Rows[dtgItem.RowIndex].FindControl("chkProducto"));
                    bool valor = Sel.Checked;

                    ModProductosPromoACBase campos = new ModProductosPromoACBase();
                    campos.IdPABase = IdPDescuento;
                    if (lstProd[i].CodigoInternoAnt == null)
                    {
                        campos.CodigoInterno = txtCodInt.Text;
                    }
                    else
                    {
                        campos.CodigoInterno = lstProd[i].CodigoInternoAnt;
                    }
                    campos.CodigoInternoNvo = txtCodInt.Text;
                    if (valor)
                    {
                        campos.IdStatus = 1;
                    }
                    else
                    {
                        campos.IdStatus = 2;
                    }

                    blnRespuesta = Ejecutar.ModificarProductosPromoDescuento(campos);

                }

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ModificarSucursalesPromocionesDescuento(int IdPDescuento)
        {
            bool blnRespuesta = false;
            int i = 0;
            try
            {


                AdministraPromocion Ejecutar = new AdministraPromocion();

                //Obtiene lista de productos depurada    
                List<ModSucursalesPromoACBase> lstSuc = new List<ModSucursalesPromoACBase>();
                lstSuc = (List<ModSucursalesPromoACBase>)Session["lstResSuc"];

                //Elimina todas la sucursales que se encuentren relacionadas al IdPDescuento
                //Ejecutar.DesactivarSucursalesPromoDescuento(IdPDescuento);

                //Si fue activada la casilla a Nivel Nacional registrara todas las sucursales 
                if (chkNivNac.Checked)
                {
                    ModSucursalesPromoACBase campos = new ModSucursalesPromoACBase();
                    campos.IdPABase = IdPDescuento;
                    campos.strSucursal = "0";
                    campos.IdStatus = 1;

                    blnRespuesta = Ejecutar.ModificarSucursalesPromoDescuento(campos);
                }
                else
                {   //Solo registrara las sucursales activas en el listado
                    string strSucursal = "";
                    ModSucursalesPromoACBase campos = new ModSucursalesPromoACBase();
                    campos.IdPABase = IdPDescuento;
                    campos.IdStatus = 1;

                    for (i = 0; i < grvSucursales.Rows.Count; i++)
                    {
                        GridViewRow dtgItem = grvSucursales.Rows[i];
                        TextBox txtSuc = ((TextBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("txtCiaSuc"));
                        CheckBox Sel = ((CheckBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("chkSucursal"));
                        bool valor = Sel.Checked;
                        Int64 contador = 0;


                        if (valor)
                        {
                            if (string.IsNullOrWhiteSpace(strSucursal))
                            {
                                strSucursal = txtSuc.Text;
                            }
                            else
                            {
                                strSucursal = strSucursal + "," + txtSuc.Text;
                            }
                            contador += 1;
                        }
                    }
                    campos.strSucursal = strSucursal;
                    blnRespuesta = Ejecutar.ModificarSucursalesPromoDescuento(campos);
                }


                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LimpiarCampos()
        {
            List<ModProductosPromoACBase> lstProd = new List<ModProductosPromoACBase>();
            List<ModSucursalesPromoACBase> lstsuc = new List<ModSucursalesPromoACBase>();
            txtNombrePromocion.Text = "";
            rdpFechaIni.SelectedDate = null;
            rdpFechaFin.SelectedDate = null;
            rcbLimPeriodo.ClearSelection();
            txtCantidadAC.Text = "";
            txtLimite.Text = "";
            chkLunes.Checked = false;
            chkMartes.Checked = false;
            chkMiercoles.Checked = false;
            chkJueves.Checked = false;
            chkViernes.Checked = false;
            chkSabado.Checked = false;
            chkDomingo.Checked = false;
            chkServicioDom.Checked = false;
            chkINAPAM.Checked = false;
            chkACBase.Checked = false;
            chkACPiezas.Checked = false;
            grvProductos.DataSource = lstProd;
            grvProductos.DataBind();
            grvSucursales.DataSource = lstsuc;
            grvSucursales.DataBind();

            //Recorre checkboxList 
            int i = 0;
            for (i = 0; i <= (chkBIN.Items.Count - 1); i++)
            {
                chkBIN.Items[i].Selected = false;
            }

        }
        private void EliminaVariablesSesion()
        {
            Session.Contents.Remove("intIdPABase");
            Session.Remove("intIdPABase");
            Session.Contents.Remove("lstResProdSource");
            Session.Remove("lstResProdSource");
            Session.Contents.Remove("lstResProd");
            Session.Remove("lstResProd");
            Session.Contents.Remove("lstResSuc");
            Session.Remove("lstResSuc");
            Session.Contents.Remove("lstResultado");
            Session.Remove("lstResultado");
        }
        private int ObtenEquivalenciaSucursal(string Sucursal)
        {
            int intRespuesta = 0;

            AdministraPromocion Ejecutar = new AdministraPromocion();
            intRespuesta = Ejecutar.RegresaIdSucursal(Sucursal);

            return intRespuesta;
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }


        private DataTable EstructuraProductos()
        {
            DataTable medidaTabla = new DataTable();

            medidaTabla.Columns.Add("CodigoInterno", typeof(string));
            medidaTabla.Columns.Add("IdStatus", typeof(string));
            return medidaTabla;
        }
        private DataTable EstructuraSucursales()
        {
            DataTable medidaTabla = new DataTable();

            medidaTabla.Columns.Add("NomSucursal", typeof(string));
            medidaTabla.Columns.Add("Sucursal", typeof(string));
            medidaTabla.Columns.Add("IdStatus", typeof(Int32));
            return medidaTabla;
        }

        private int ValidarDuplicados(GridView grvProd)
        {
            int intDuplicados = 0;
            DataTable DTRespDuplicados = new DataTable();


            DataTable dt1 = new DataTable();
            dt1 = EstructuraProductos();
            DataRow dr;
            //Recorre el contenido del grid y lo guarda en datatable
            foreach (GridViewRow row in this.grvProductos.Rows)
            {
                TextBox txtcodigo = (TextBox)row.FindControl("txtNomProd");
                CheckBox chkProd = (CheckBox)row.FindControl("chkProducto");

                dr = dt1.NewRow();
                dr[0] = txtcodigo.Text.ToString();
                dr[1] = chkProd.Checked;



                dt1.Rows.Add(dr);
                ViewState["DataTemp"] = dt1;

            }


            //Valida si existen registros duplicados y devolvera un datatable con los registros unicos 
            DTRespDuplicados = ExistenDuplicados(dt1);
            //Se realiza una resta entre ambas tablas y el remanente es el numero de registros duplicados
            //dt1.Rows.Count ===> Todos los registros
            //DTRespDuplicados.Rows.Count ===> Registros unicos excluyendo duplicados
            intDuplicados = (dt1.Rows.Count - DTRespDuplicados.Rows.Count);

            return intDuplicados;
        }
        private int ValidarDuplicadosSuc(GridView grvSucursales)
        {
            int intDuplicados = 0;
            DataTable DTRespDuplicados = new DataTable();


            DataTable dt1 = new DataTable();
            dt1 = EstructuraSucursales();
            DataRow dr;
            //Recorre el contenido del grid y lo guarda en datatable
            foreach (GridViewRow row in this.grvSucursales.Rows)
            {
                TextBox txtNomSuc = (TextBox)row.FindControl("txtSucursal");
                TextBox tstCia = (TextBox)row.FindControl("txtCiaSuc");
                CheckBox chkSuc = (CheckBox)row.FindControl("chkSucursal");

                dr = dt1.NewRow();
                dr[0] = txtNomSuc.Text.ToString();
                dr[1] = tstCia.Text.ToString();
                dr[2] = chkSuc.Checked;

                dt1.Rows.Add(dr);
                ViewState["DataTemp"] = dt1;
            }


            //Valida si existen registros duplicados y devolvera un datatable con los registros unicos 
            DTRespDuplicados = ExistenDuplicadosSuc(dt1);
            //Se realiza una resta entre ambas tablas y el remanente es el numero de registros duplicados
            //dt1.Rows.Count ===> Todos los registros
            //DTRespDuplicados.Rows.Count ===> Registros unicos excluyendo duplicados
            intDuplicados = (dt1.Rows.Count - DTRespDuplicados.Rows.Count);

            return intDuplicados;
        }

        private DataTable ExistenDuplicados(DataTable DT)
        {
            DataTable dtDistinct = new DataTable();



            //string[] sColumnas = { "CodigoInterno", "Categoria", "NomProducto", "Laboratorio" };
            string[] sColumnas = { "CodigoInterno" };
            //Devuelve registros unicos
            dtDistinct = DT.DefaultView.ToTable(true, sColumnas);
            //dtDistinct.Merge(DT, true);//Realiza unión entre dos tablas

            return dtDistinct;
        }
        private DataTable ExistenDuplicadosSuc(DataTable DT)
        {
            DataTable dtDistinct = new DataTable();



            //string[] sColumnas = { "CodigoInterno", "Categoria", "NomProducto", "Laboratorio" };
            string[] sColumnas = { "Sucursal" };
            //Devuelve registros unicos
            dtDistinct = DT.DefaultView.ToTable(true, sColumnas);
            //dtDistinct.Merge(DT, true);//Realiza unión entre dos tablas

            return dtDistinct;
        }

        protected void rcbLimPeriodo_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcbLimPeriodo.Text == "indefinido")
            {
                txtLimite.Text = "9999";
                txtLimite.Enabled = false;
            }
            else
            {
                txtLimite.Text = "";
                txtLimite.Enabled = true;
                txtLimite.Focus();
            }
        }


    }
}