using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Negocio;

namespace CallcenterNUevo.AdminPromociones
{
    public partial class MuestraDatosACBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
        protected void grvDatos_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            AdministraPromocion Ejecutar = new AdministraPromocion();
            List<ModPromocionesACBase> lstProm = new List<ModPromocionesACBase>();
            lstProm = (List<ModPromocionesACBase>)Session["lstResultado"];
            int intIdPABase = 0;

            intIdPABase = Convert.ToInt32(e.CommandArgument);
            Session.Add("intIdPABase", intIdPABase);

            lstProm = lstProm.Where(w => w.IdPABase == intIdPABase).ToList();

            txtNombrePromocion.Text = lstProm[0].NombrePromocion;
            txtCantidadAC.Text = lstProm[0].Cantidad.ToString();
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

            if (lstProm[0].SurtirConsultorio == 1)
            {
                chkSurtir.Checked = true;
            }
            else
            {
                chkSurtir.Checked = false;
            }
            //===========================================================================================================================
            //obtener Productos
            List<ModProductosPromoACBase> lstResProd = new List<ModProductosPromoACBase>();

            lstResProd = Ejecutar.ObtenProductosACBase(intIdPABase);
            grvProductos.DataSource = lstResProd;
            grvProductos.DataBind();
            Session.Add("lstResProdSource", lstResProd);
            Session.Add("lstResProd", lstResProd);

            //obtener Sucursales
            List<ModSucursalesPromoACBase> lstResSuc = new List<ModSucursalesPromoACBase>();

            lstResSuc = Ejecutar.ObtenSucursalACBase(intIdPABase);
            grvSucursales.DataSource = lstResSuc;
            grvSucursales.DataBind();
            Session.Add("lstResSucSource", lstResSuc);
            Session.Add("lstResSuc", lstResSuc);
            //===========================================================================================================================
            //Obtener Dias
            List<ModDiasPromoACBAse> lstResDias = new List<ModDiasPromoACBAse>();

            lstResDias = Ejecutar.ObtenDiasACBase(intIdPABase);

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

            //Muestra formulario
            mvProductrosSuc.SetActiveView(vEditaPromocionACBase);
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                AdministraPromocion Ejecutar = new AdministraPromocion();
                List<ModPromocionesACBase> lstResultado = new List<ModPromocionesACBase>();

                lstResultado = Ejecutar.ObtenPromoACBase(txtNomPromACBase.Text);
                grvDatos.DataSource = lstResultado;
                grvDatos.DataBind();

                Session.Add("lstResultado", lstResultado);
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosACBase", "btnBuscar_Click", "Ejecutar.ObtenPromoACBase(" + txtNomPromACBase.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar buscar la promoción de acumulación base, contacte al administrador");
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
                if (Session["intIdPABase"] != null)
                {
                    int IdPABase = 0;

                    IdPABase = (int)Session["intIdPABase"];

                    if (Validaciones())
                    {
                        //Actualiza la promoción
                        ModificaPromoACBase(IdPABase);

                        //Registra los dias de la promoción
                        if (ModificarDias(IdPABase))
                        {
                            //Registra Productos de la promoción
                            if (ModificarProductosPromocionesACBase(IdPABase))
                            {
                                //Registra las sucursales de la promoción
                                if (ModificarSucursalesPromocionesACBase(IdPABase))
                                {
                                    Mensajes("Se ha modificado la promoción de acumulación base correctamente.");
                                    EliminaVariablesSesion();
                                    LimpiarCampos();
                                    //Muestra módulo de consulta
                                    mvProductrosSuc.SetActiveView(vConsultaPromocionesACBAse);
                                    btnBuscar_Click(null, null);
                                }
                            }
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                    Mensajes("Imposible realizar esta acción, consulte la promoción nuevamente e intente modificar.");
                    //Muestra módulo de consulta
                    mvProductrosSuc.SetActiveView(vConsultaPromocionesACBAse);
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosACBase", "btnGuardar_Click", "Metodos de guardado", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar modificar la promoción de acumulación base, contacte al administrador");
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            mvProductrosSuc.SetActiveView(vConsultaPromocionesACBAse);
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
            //=========================================================================================================================================


            int intCantidad = 0;
            intCantidad = Convert.ToInt32(txtCantidadAC.Text);

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

            if (chkLunes.Checked == false && chkMartes.Checked == false && chkMiercoles.Checked == false && chkJueves.Checked == false && chkViernes.Checked == false && chkSabado.Checked == false && chkDomingo.Checked == false)
            {
                Mensajes("Debe seleccionar un día de la semana por lo menos.");
                return false;
            }

            //if (chkServicioDom.Checked == false && chkSurtir.Checked == false)
            //{
            //    Mensajes("Debe seleccionar alguna de las opciones;  Servicio a Domicilio y/o Surtir en Consultorio");
            //    chkServicioDom.Focus();
            //    return false;
            //}



            //====================================================================================================================================
            //Valida que el producto sea valido
            AdministraPromocion Ejecutar = new AdministraPromocion();
            bool blnResultado = false;

            for (i = 0; i < grvProductos.Rows.Count; i++)
            {
                GridViewRow dtgItem = grvProductos.Rows[i];
                TextBox txtCodInt = ((TextBox)grvProductos.Rows[dtgItem.RowIndex].FindControl("txtNomProd"));

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


            for (i = 0; i < grvSucursales.Rows.Count; i++)
            {
                GridViewRow dtgItem = grvSucursales.Rows[i];
                TextBox txtNomSucursal = ((TextBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("txtSucursal"));
                TextBox txtSucursal = ((TextBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("txtCiaSuc"));

                blnResultadoSuc = Ejecutar.ValidaExistenciaSucursalACBase(Convert.ToInt32(txtSucursal.Text));
                if (!blnResultadoSuc)
                {
                    Mensajes("La sucursal: " + txtNomSucursal.Text + ", no es valida, ¡Verifique su información e intente de nuevo.!");

                    return blnResultadoSuc;
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

            intExisteNuevoRegistro = lstSuc.Where(w => w.IdPABase == 0 && w.Sucursal == 0).Count();
            if (intExisteNuevoRegistro > 0)
            {
                Mensajes("No debe dejar celdas de sucursales vacias.");
                lstSuc.RemoveAll(x => x.IdPABase == 0 && x.Sucursal == 0);
                grvSucursales.DataSource = lstSuc;
                grvSucursales.DataBind();
                return false;
            }
            //====================================================================================================================================
            //Valida si la promoción a registrar existe en dbase

            //AdministraPromocion ejecutar = new AdministraPromocion();
            //bool blnRespuesta = false;
            //int i = 0;
            //foreach (ModProductosPromoACBase reg in lstProdACBase)
            //{

            //    ModPromoACBaseValidaciones campos = new ModPromoACBaseValidaciones();
            //    campos.CodigoInterno = reg.CodigoInterno;
            //    campos.Sucursal = lstSucACBase[i].Sucursal;
            //    campos.FechaIni = Convert.ToDateTime(rdpFechaIni.SelectedDate);
            //    campos.FechaFin = Convert.ToDateTime(rdpFechaFin.SelectedDate);

            //    blnRespuesta = ejecutar.ValidaPromocionACBase(campos);
            //    if (blnRespuesta)
            //    {
            //        Mensajes("Imposible continuar, la Promoción de ACBase con Código Interno: " + campos.CodigoInterno + ", con vigencia del: " + campos.FechaIni.ToShortDateString() + " al " + campos.FechaFin.ToShortDateString() + " y sucursal: " + campos.Sucursal + ", ya existe ligada en alguna promoción. ¡Verifique su vigencia e intente de nuevo!");
            //        fldUpProductos.Focus();
            //        return false;
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
            lstSuc = (List<ModSucursalesPromoACBase>)Session["lstResSuc"];

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
        private void SeteaRegistrosProd()
        {
            List<ModProductosPromoACBase> lstProdSource = new List<ModProductosPromoACBase>();
            lstProdSource = (List<ModProductosPromoACBase>)Session["lstResProdSource"];
            List<ModProductosPromoACBase> lstProd = new List<ModProductosPromoACBase>();
            lstProd = (List<ModProductosPromoACBase>)Session["lstResProd"];



            AdministraPromocion Ejecutar = new AdministraPromocion();
            bool blnResultado = false;
            int i = 0;
            int intExisteenLista = 0;

            foreach (ModProductosPromoACBase reg in lstProd)
            {
                GridViewRow dtgItem = grvProductos.Rows[i];
                TextBox txtCodInt = ((TextBox)grvProductos.Rows[dtgItem.RowIndex].FindControl("txtNomProd"));
                CheckBox chkProd = ((CheckBox)grvProductos.Rows[dtgItem.RowIndex].FindControl("chkProducto"));
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

            // var lstProdDep = lstProd.Select(s => s.CodigoInterno).Distinct().ToList();
        }
        private void SeteaRegistrosSuc()
        {
            List<ModSucursalesPromoACBase> lstSucSource = new List<ModSucursalesPromoACBase>();
            lstSucSource = (List<ModSucursalesPromoACBase>)Session["lstResSucSource"];
            List<ModSucursalesPromoACBase> lstSuc = new List<ModSucursalesPromoACBase>();
            lstSuc = (List<ModSucursalesPromoACBase>)Session["lstResSuc"];
            AdministraPromocion Ejecutar = new AdministraPromocion();
            bool blnResultado = false;
            int i = 0;
            int intCiaSuc = 0;

            foreach (ModSucursalesPromoACBase reg in lstSuc)
            {
                GridViewRow dtgItem = grvSucursales.Rows[i];
                TextBox txtNomSuc = ((TextBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("txtSucursal"));
                TextBox txtCiaSuc = ((TextBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("txtCiaSuc"));
                CheckBox chkSucursal = ((CheckBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("chkSucursal"));
                bool valor = chkSucursal.Checked;

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
        }


        private bool ModificaPromoACBase(int IdPABase)
        {
            bool blnResultado = false;

            try
            {
                AdministraPromocion Ejecutar = new AdministraPromocion();
                ModPromocionesACBase campos = new ModPromocionesACBase();

                campos.IdPABase = IdPABase;
                campos.NombrePromocion = txtNombrePromocion.Text;
                campos.Cantidad = Convert.ToInt32(txtCantidadAC.Text);
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

                if (chkSurtir.Checked)
                {
                    campos.SurtirConsultorio = 1;
                }
                else
                {
                    campos.SurtirConsultorio = 0;
                }

                blnResultado = Ejecutar.ModificarPromoACBase(campos);


                return blnResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ModificarDias(int IdPABase)
        {
            bool blnRespuesta = false;

            try
            {


                AdministraPromocion Ejecutar = new AdministraPromocion();
                List<ModDiasPromoACBAse> lstDias = new List<ModDiasPromoACBAse>();


                if (chkLunes.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 1;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 1;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }
                if (chkMartes.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 2;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 2;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }
                if (chkMiercoles.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 3;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 3;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }
                if (chkJueves.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 4;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 4;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }
                if (chkViernes.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 5;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 5;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }
                if (chkSabado.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 6;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 6;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }
                if (chkDomingo.Checked)
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 7;
                    campos.IdStatus = 1;
                    lstDias.Add(campos);
                }
                else
                {
                    ModDiasPromoACBAse campos = new ModDiasPromoACBAse();
                    campos.IdPABase = IdPABase;
                    campos.Dia = 7;
                    campos.IdStatus = 2;
                    lstDias.Add(campos);
                }



                blnRespuesta = Ejecutar.ModificarDiasPromoACBase(lstDias);

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ModificarProductosPromocionesACBase(int IdPABase)
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
                    campos.IdPABase = IdPABase;
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

                    blnRespuesta = Ejecutar.ModificarProductosPromoACBase(campos);

                }

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ModificarSucursalesPromocionesACBase(int IdPABase)
        {
            bool blnRespuesta = false;
            int i = 0;
            try
            {
                AdministraPromocion Ejecutar = new AdministraPromocion();

                //Obtiene lista de productos depurada    
                List<ModSucursalesPromoACBase> lstSuc = new List<ModSucursalesPromoACBase>();
                lstSuc = (List<ModSucursalesPromoACBase>)Session["lstResSuc"];


                for (i = 0; i < grvSucursales.Rows.Count; i++)
                {
                    GridViewRow dtgItem = grvSucursales.Rows[i];
                    TextBox txtSuc = ((TextBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("txtCiaSuc"));
                    CheckBox Sel = ((CheckBox)grvSucursales.Rows[dtgItem.RowIndex].FindControl("chkSucursal"));
                    bool valor = Sel.Checked;

                    ModSucursalesPromoACBase campos = new ModSucursalesPromoACBase();
                    campos.IdPABase = IdPABase;
                    if (lstSuc[i].SucursalAnt == null)
                    {
                        campos.Sucursal = Convert.ToInt32(txtSuc.Text);
                    }
                    else
                    {
                        campos.Sucursal = lstSuc[i].SucursalAnt;
                    }
                    campos.SucursalNva = Convert.ToInt32(txtSuc.Text);
                    if (valor)
                    {
                        campos.IdStatus = 1;
                    }
                    else
                    {
                        campos.IdStatus = 2;
                    }

                    blnRespuesta = Ejecutar.ModificarSucursalesPromoACBase(campos);

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
            txtCantidadAC.Text = "";
            chkLunes.Checked = false;
            chkMartes.Checked = false;
            chkMiercoles.Checked = false;
            chkJueves.Checked = false;
            chkViernes.Checked = false;
            chkSabado.Checked = false;
            chkDomingo.Checked = false;
            chkServicioDom.Checked = false;
            chkSurtir.Checked = false;
            grvProductos.DataSource = lstProd;
            grvProductos.DataBind();
            grvSucursales.DataSource = lstsuc;
            grvSucursales.DataBind();
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

    }
}