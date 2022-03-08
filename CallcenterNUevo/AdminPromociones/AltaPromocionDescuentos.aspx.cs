using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpreadsheetLight;
using DocumentFormat.OpenXml;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Datos;
using Negocio;


namespace CallcenterNUevo.AdminPromociones
{
    public partial class AltaPromocionDescuentos : System.Web.UI.Page
    {
        public static string Cnn = "ConnectionString";

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(btnGuardar);

            if (IsPostBack)
            {
                if (Session["fldUpProductos"] != null)
                {
                    fldUpProductos = (FileUpload)Session["fldUpProductos"];
                }

                if (Session["fldUpSucursales"] != null)
                {
                    fldUpSucursales = (FileUpload)Session["fldUpSucursales"];
                }
            }
            else
            {
                CargaCombo();
                CargarChksBIN();
            }
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
        protected void txtLimite_TextChanged(object sender, EventArgs e)
        {
            int Valormin = 0;
            int Valormax = 0;
            Clientes prmEjecuta = new Clientes();

            if (!string.IsNullOrWhiteSpace(txtLimite.Text))
            {
                Parametros prmRespuesta = new Parametros();

                prmRespuesta = prmEjecuta.ObtenerParametros("LimiteMin");
                Valormin = Convert.ToInt32(prmRespuesta.ValorPrm);
                prmRespuesta = prmEjecuta.ObtenerParametros("LimiteMax");
                Valormax = Convert.ToInt32(prmRespuesta.ValorPrm);

                if (Convert.ToInt32(txtLimite.Text) > Valormax || Convert.ToInt32(txtLimite.Text) < Valormin)
                {
                    Mensajes("El Límite proporcionado no es valido, el valor mínimo permitido es de: " + Valormin + ", y el valor máximo permitido es de: " + Valormax);
                    txtLimite.Text = "";
                    txtLimite.Focus();
                }
            }
        }
        protected void chkNivNac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNivNac.Checked)
            {
                fldUpSucursales.Enabled = false;
            }
            else
            {
                fldUpSucursales.Enabled = true;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int intIdRegistro = 0;
                if (Validaciones())
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.AltaPromocionDescuentos", "btnGuardar_Click", "Inicio de Guardado", this.User.Identity.Name.ToString(), null);
                    //Registra la promoción
                    intIdRegistro = GuardarNuevaPromoDescuento();

                    //Registra los dias de la promoción
                    if (GuardarDias(intIdRegistro))
                    {
                        //Registra los Bin's que jugaran en dicha promoción
                        if (GuardarBins(intIdRegistro))
                        {
                            //Registra Productos de la promoción
                            if (GuardarProductosPromocionesDescuento(intIdRegistro))
                            {
                                //Registra las sucursales de la promoción
                                if (GuardarSucursalesPromocionesDescuento(intIdRegistro))
                                {
                                    Mensajes("Se ha registrado correctamente la promoción de descuento.");
                                    LimpiarCampos();
                                    EliminaVariablesSesion();
                                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.AltaPromocionDescuentos", "btnGuardar_Click", "Fin de Guardado", this.User.Identity.Name.ToString(), null);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromocionDescuentos", "btnGuardar_Click", "Metodos de guardado", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar dar de alta la nueva promoción de descuento, contacte al administrador");
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
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
        private int ObtenEquivalenciaSucursal(string Sucursal)
        {
            int intRespuesta = 0;

            AdministraPromocion Ejecutar = new AdministraPromocion();
            intRespuesta = Ejecutar.RegresaIdSucursal(Sucursal);

            return intRespuesta;
        }
        private int GuardarNuevaPromoDescuento()
        {
            int intResultado = 0;

            AdministraPromocion Ejecutar = new AdministraPromocion();
            ModPromocionDescuentos campos = new ModPromocionDescuentos();

            try
            {
                campos.NombrePromocion = txtNombrePromocion.Text;
                campos.Cantidad = Convert.ToDecimal(txtCantidadDescuento.Text);
                campos.FechaInicio = Convert.ToDateTime(rdpFIni.SelectedDate);
                campos.FechaFin = Convert.ToDateTime(rdpFFin.SelectedDate);
                campos.IdPeriodo = Convert.ToInt32(rcbLimPeriodo.SelectedValue);
                campos.Limite = Convert.ToInt32(txtLimite.Text);


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

                intResultado = Ejecutar.GuardarPromocionesDescuento(campos);


                return intResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool GuardarDias(int IdPDescuento)
        {
            bool blnRespuesta = false;

            AdministraPromocion Ejecutar = new AdministraPromocion();
            List<ModDiasPromoACBAse> lstDias = new List<ModDiasPromoACBAse>();

            try
            {
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

                blnRespuesta = Ejecutar.GuardarDiasPromoDescuento(lstDias);

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool GuardarBins(int IdPDescuento)
        {
            bool blnRespuesta = false;
            AdministraPromocion Ejecutar = new AdministraPromocion();

            //Recorre checkboxList 
            int i = 0;
            try
            {

                for (i = 0; i <= (chkBIN.Items.Count - 1); i++)
                {
                    if (chkBIN.Items[i].Selected)
                    {
                        ModBin campos = new ModBin();

                        //if (chkBIN.Items[i].Value.Equals("3"))
                        //{
                        //Insertara ambos Bin's 150 
                        //campos.IdPDescuento = IdPDescuento;
                        //campos.IdClub = 3;

                        //blnRespuesta = Ejecutar.GuardarBinsPromoDescuento(campos);

                        //Insertara ambos Bin's 151
                        //campos.IdPDescuento = IdPDescuento;
                        //campos.IdClub = 12;
                        //blnRespuesta = Ejecutar.GuardarBinsPromoDescuento(campos);
                        //}
                        //else
                        //{
                        campos.IdPDescuento = IdPDescuento;
                        campos.IdClub = Convert.ToInt32(chkBIN.Items[i].Value);

                        blnRespuesta = Ejecutar.GuardarBinsPromoDescuento(campos);
                        //}
                    }
                }

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool GuardarProductosPromocionesDescuento(int IdPABase)
        {
            bool blnRespuesta = false;
            AdministraPromocion Ejecutar = new AdministraPromocion();

            try
            {
                //Obtiene lista de productos depurada
                List<ModProductosPromoACBase> lstProd = new List<ModProductosPromoACBase>();
                lstProd = (List<ModProductosPromoACBase>)Session["lstProdACBase"];


                foreach (ModProductosPromoACBase reg in lstProd)
                {
                    ModProductosPromoACBase campos = new ModProductosPromoACBase();
                    campos.IdPABase = IdPABase;
                    campos.CodigoInterno = reg.CodigoInterno;
                    campos.IdStatus = 1;

                    blnRespuesta = Ejecutar.GuardarProductosPromoDescuento(campos);
                }

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool GuardarSucursalesPromocionesDescuento(int IdPABase)
        {
            AdministraPromocion Ejecutar = new AdministraPromocion();
            bool blnRespuesta = false;

            try
            {
                //Obtiene lista de productos depurada
                List<ModSucursalesPromoACBase> lstSuc = new List<ModSucursalesPromoACBase>();
                lstSuc = (List<ModSucursalesPromoACBase>)Session["lstSucACBase"];

                if (chkNivNac.Checked)
                {
                    ModSucursalesPromoACBase campos = new ModSucursalesPromoACBase();
                    campos.IdPABase = IdPABase;
                    campos.strSucursal = "0";
                    campos.IdStatus = 1;

                    blnRespuesta = Ejecutar.GuardarSucursalesPromoDescuento(campos);
                }
                else
                {
                    string strSucursal = "";
                    ModSucursalesPromoACBase campos = new ModSucursalesPromoACBase();
                    campos.IdPABase = IdPABase;
                    campos.IdStatus = 1;
                    foreach (ModSucursalesPromoACBase reg in lstSuc)
                    {
                        if (string.IsNullOrWhiteSpace(strSucursal))
                        {
                            strSucursal = reg.Sucursal.ToString();
                        }
                        else
                        {
                            strSucursal = strSucursal + "," + reg.Sucursal.ToString();
                        }
                    }
                    campos.strSucursal = strSucursal;
                    blnRespuesta = Ejecutar.GuardarSucursalesPromoDescuento(campos);
                }

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Validaciones()
        {
            string extension = "";

            if (string.IsNullOrWhiteSpace(txtNombrePromocion.Text))
            {
                Mensajes("Debe proporcionar un Nombre de Promoción.");
                txtNombrePromocion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidadDescuento.Text))
            {
                Mensajes("Debe proporcionar una cantidad de descuento.");
                txtCantidadDescuento.Focus();
                return false;
            }

            decimal intCantidad = 0;
            intCantidad = Convert.ToDecimal(txtCantidadDescuento.Text);

            if (intCantidad > 100)
            {
                Mensajes("La cantidad de acumulación no puede ser mayor a 100");
                txtCantidadDescuento.Text = "";
                txtCantidadDescuento.Focus();
                return false;
            }
            //====================================================================================================================================

            if (rdpFIni.SelectedDate == null)
            {
                Mensajes("Debe seleccionar una Fecha Inicio.");
                rdpFIni.Focus();
                return false;
            }

            if (rdpFFin.SelectedDate == null)
            {
                Mensajes("Debe seleccionar una Fecha Fin.");
                rdpFFin.Focus();
                return false;
            }

            if (rdpFIni.SelectedDate > rdpFFin.SelectedDate)
            {
                Mensajes("La Fecha Fin no puede ser menor a la Fecha Inicio.");
                rdpFFin.Focus();
                return false;
            }


            if (rdpFIni.SelectedDate < DateTime.Now.Date)
            {
                Mensajes("No es posible que la fecha inicio sea menor a la fecha actual.");
                rdpFIni.Clear();
                rdpFIni.Focus();
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
            int i = 0;
            bool blnSeleccionbin = false;
            for (i = 0; i <= (chkBIN.Items.Count - 1); i++)
            {
                if (chkBIN.Items[i].Selected)
                {
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

            //=========================================================================================================================================
            //Sucursales
            if (!chkNivNac.Checked)
            {
                if (!fldUpSucursales.HasFile)
                {
                    Mensajes("Debe seleccionar un layout de sucursales.");
                    fldUpSucursales.Focus();
                    return false;
                }

                extension = Path.GetExtension(fldUpSucursales.FileName.ToString());
                if (extension != ".xlsx")
                {
                    Mensajes("Imposible continuar, tipo de archivo Sucursales invalido.");
                    fldUpSucursales.Focus();
                    return false;
                }
                else
                {
                    Session.Add("fldUpSucursales", fldUpSucursales);
                }
            }


            //Productos
            if (!fldUpProductos.HasFile)
            {
                Mensajes("Debe seleccionar un layout de productos.");
                fldUpProductos.Focus();
                return false;
            }

            extension = Path.GetExtension(fldUpProductos.FileName.ToString());
            if (extension != ".xlsx")
            {
                Mensajes("Imposible continuar, tipo de archivo Productos invalido.");
                Session.Contents.Remove("fldUpProductos");
                Session.Remove("fldUpProductos");
                fldUpProductos.Focus();
                return false;
            }
            else
            {
                Session.Contents.Remove("fldUpProductos");
                Session.Remove("fldUpProductos");
                Session.Add("fldUpProductos", fldUpProductos);
            }


            //=========================================================================================================================================
            //Excluye Duplicados a la lista de productos
            List<ModProductosPromoACBase> lstProdACBase = new List<ModProductosPromoACBase>();
            lstProdACBase = DepuraListaProdACBase(fldUpProductos);
            if (lstProdACBase.Count == 0)
            {
                Mensajes("El archivo para la carga de productos no cuenta con el layout esperado, ¡Verifique e intente de nuevo!");
                Session.Contents.Remove("fldUpProductos");
                Session.Remove("fldUpProductos");
                fldUpProductos = new FileUpload();
                return false;
            }
            else
            {
                //Guarda lista depurada en variable de sesión
                Session.Add("lstProdACBase", lstProdACBase);
            }

            if (!chkNivNac.Checked)
            {
                //Excluye Duplicados a la lista de sucursales
                List<ModSucursalesPromoACBase> lstSucACBase = new List<ModSucursalesPromoACBase>();
                lstSucACBase = DepuraListaSucursalesACBase(fldUpSucursales);
                if (lstSucACBase.Count == 0)
                {
                    Mensajes("El archivo para la carga de sucursales no cuenta con el layout esperado, ¡Verifique e intente de nuevo!");
                    fldUpSucursales = new FileUpload();
                    Session.Contents.Remove("fldUpSucursales");
                    Session.Remove("fldUpSucursales");

                    return false;
                }
                else
                {
                    //Guarda lista depurada en variable de sesión
                    Session.Add("lstSucACBase", lstSucACBase);
                }
            }

            //=========================================================================================================================================

            //====================================================================================================================================
            //Valida que el producto sea valido
            AdministraPromocion Ejecutar = new AdministraPromocion();
            bool blnResultado = false;

            foreach (ModProductosPromoACBase campos in lstProdACBase)
            {
                blnResultado = Ejecutar.ValidaExistenciaCodInternoACBase(campos.CodigoInterno);
                if (!blnResultado)
                {
                    Mensajes("El código interno: " + campos.CodigoInterno + ", no es valido, ¡Verifique su información e intente de nuevo.!");
                    fldUpProductos = new FileUpload();
                    Session.Contents.Remove("fldUpProductos");
                    Session.Remove("fldUpProductos");
                    Session.Contents.Remove("lstProdACBase");
                    Session.Remove("lstProdACBase");

                    return blnResultado;
                }
            }


            if (!chkNivNac.Checked)
            {
                //Valida que la sucursal sea valida
                bool blnResultadoSuc = false;
                string valorErrorSucu = "";

                List<ModSucursalesPromoACBase> lstSucACBase = new List<ModSucursalesPromoACBase>();
                lstSucACBase = DepuraListaSucursalesACBase(fldUpSucursales);
                Session.Add("lstSucDescuento", lstSucACBase);

                foreach (ModSucursalesPromoACBase campos in lstSucACBase)
                {
                    blnResultadoSuc = Ejecutar.ValidaExistenciaSucursalACBase(campos.Sucursal);
                    if (!blnResultadoSuc)
                    {
                        valorErrorSucu = Session["SucursalInexistente"].ToString();
                        Session.Contents.Remove("SucursalInexistente");
                        Session.Remove("SucursalInexistente");

                        Mensajes("La sucursal: " + valorErrorSucu + ", no es valida, ¡Verifique su información e intente de nuevo.!");
                        fldUpSucursales = new FileUpload();
                        Session.Contents.Remove("fldUpSucursales");
                        Session.Remove("fldUpSucursales");
                        Session.Contents.Remove("lstSucACBase");
                        Session.Remove("lstSucACBase");

                        return blnResultadoSuc;
                    }
                }
            }

            //====================================================================================================================================


            //====================================================================================================================================
            //Valida si la promoción a registrar existe en dbase
            if (!chkNivNac.Checked)
            {
                AdministraPromocion ejecutar = new AdministraPromocion();
                bool blnRespuesta = false;

                List<ModSucursalesPromoACBase> lstSucursales = new List<ModSucursalesPromoACBase>();
                lstSucursales = DepuraListaSucursalesACBase(fldUpSucursales);

                foreach (ModProductosPromoACBase reg in lstProdACBase)
                {
                    //recorre los productos
                    ModPromoACBaseValidaciones campos = new ModPromoACBaseValidaciones();
                    campos.CodigoInterno = reg.CodigoInterno;
                    campos.FechaIni = Convert.ToDateTime(rdpFIni.SelectedDate);
                    campos.FechaFin = Convert.ToDateTime(rdpFFin.SelectedDate);

                    //recorre cada una de las sucursales agregadas para realizar la validación
                    foreach (ModSucursalesPromoACBase suc in lstSucursales)
                    {
                        campos.Sucursal = suc.Sucursal.ToString();

                        blnRespuesta = ejecutar.ValidaPromocionDescuento(campos);
                        if (blnRespuesta)
                        {
                            //Mensajes("Imposible continuar, la Promoción de descuento con Código Interno: " + campos.CodigoInterno + ", con vigencia del: " + campos.FechaIni.ToShortDateString() + " al " + campos.FechaFin.ToShortDateString() + " y sucursal: " + campos.Sucursal + ", ya existe ligada en alguna promoción. ¡Verifique su vigencia e intente de nuevo!");
                            Mensajes("Imposible continuar, uno de los códigos, ya cuenta con promoción asignada en un rango de fechas que coinside parcialmente con: " + campos.FechaIni.ToShortDateString() + " al " + campos.FechaFin.ToShortDateString() + " ¡Verifique su vigencia e intente de nuevo!");
                            fldUpProductos = new FileUpload();
                            Session.Contents.Remove("fldUpProductos");
                            Session.Remove("fldUpProductos");
                            Session.Contents.Remove("lstProdACBase");
                            Session.Remove("lstProdACBase");
                            return false;
                        }
                    }
                }
            }
            else
            {
                AdministraPromocion ejecutar = new AdministraPromocion();
                bool blnRespuesta = false;

                List<ModSucursales> lstSucursales = new List<ModSucursales>();
                lstSucursales = ejecutar.ObtenerAllSucursales(Cnn);

                foreach (ModProductosPromoACBase reg in lstProdACBase)
                {
                    ModPromoACBaseValidaciones campos = new ModPromoACBaseValidaciones();
                    campos.CodigoInterno = reg.CodigoInterno;
                    campos.FechaIni = Convert.ToDateTime(rdpFIni.SelectedDate);
                    campos.FechaFin = Convert.ToDateTime(rdpFFin.SelectedDate);
                    campos.Sucursal = "0";//Todas las sucursales

                    blnRespuesta = ejecutar.ValidaPromocionDescuento(campos);
                    if (blnRespuesta)
                    {
                        //Mensajes("Imposible continuar, la Promoción de descuento con Código Interno: " + campos.CodigoInterno + ", con vigencia del: " + campos.FechaIni.ToShortDateString() + " al " + campos.FechaFin.ToShortDateString() + " y sucursales a nivel nacional, ya existe ligada en alguna promoción. ¡Verifique su vigencia e intente de nuevo!");
                        Mensajes("Imposible continuar, uno de los códigos, ya cuenta con promoción asignada en un rango de fechas que coinside parcialmente con: " + campos.FechaIni.ToShortDateString() + " al " + campos.FechaFin.ToShortDateString() + " ¡Verifique su vigencia e intente de nuevo!");
                        return false;
                    }
                }
            }
            //====================================================================================================================================

            //====================================================================================================================================

            return true;
        }
        private void LimpiarCampos()
        {
            txtNombrePromocion.Text = "";
            rdpFIni.SelectedDate = null;
            rdpFFin.SelectedDate = null;
            rcbLimPeriodo.ClearSelection();
            txtLimite.Text = "";
            txtCantidadDescuento.Text = "";
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
            chkNivNac.Checked = false;
            //Recorre checkboxList 
            int i = 0;
            for (i = 0; i <= (chkBIN.Items.Count - 1); i++)
            {
                if (chkBIN.Items[i].Selected)
                {
                    chkBIN.Items[i].Selected = false;
                }
            }

        }
        private void EliminaVariablesSesion()
        {
            Session.Contents.Remove("fldUpProductos");
            Session.Remove("fldUpProductos");
            Session.Contents.Remove("fldUpSucursales");
            Session.Remove("fldUpSucursales");
            Session.Contents.Remove("lstProdACBase");
            Session.Remove("lstProdACBase");
            Session.Contents.Remove("lstSucACBase");
            Session.Remove("lstSucACBase");
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
        private List<ModProductosPromoACBase> DepuraListaProdACBase(FileUpload Productos)
        {

            List<ModProductosPromoACBase> lstDepurada = new List<ModProductosPromoACBase>();
            List<ModProductosPromoACBase> lstProd = new List<ModProductosPromoACBase>();
            string file = "";

            //====================================================================================================================
            //directorios
            string savePath = @"c:\temp\uploads\";
            //valida existencia de directorio
            if (!Directory.Exists(savePath))
            {//crea directorio
                Directory.CreateDirectory(savePath);
            }
            //ruta y nombre de archivo
            //FileUpload fuProd = (FileUpload)Session["fldUpProductos"];
            //savePath += fuProd.FileName;
            savePath += Productos.FileName;
            file = savePath;

            //valida existencia de archivo
            if (File.Exists(savePath))
            {
                //Elimina archivo existente
                File.Delete(savePath);
            }

            //fuProd.SaveAs(savePath);
            //guarda archivo en ruta
            Productos.SaveAs(savePath);


            //usamos el objeto FileStream para recuperar el archivo
            SLDocument sl;
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //Creamos el obejto SLDocument para cargar el archivo Excel
                sl = new SLDocument(fs);
                fs.Close();
                fs.Dispose();
                File.Delete(savePath);

                //Verifica que el archivo sea el correcto (Productos)
                //if (sl.GetCellValueAsString(1, 1) != "CodigoInterno")
                //{
                //    sl.Dispose();
                //    return lstDepurada;
                //}

                //Productos
                //int rowIndex = 2;
                int rowIndex = 1;

                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(rowIndex, 1)))
                {
                    ModProductosPromoACBase campos = new ModProductosPromoACBase();
                    campos.CodigoInterno = sl.GetCellValueAsString(rowIndex, 1).ToString();

                    lstProd.Add(campos);

                    rowIndex += 1;
                }
            }
            //====================================================================================================================

            //Excluye Duplicados
            var lstProdDepurada = lstProd.Select(s => s.CodigoInterno).Distinct().ToList();


            foreach (string reg in lstProdDepurada)
            {
                ModProductosPromoACBase campos = new ModProductosPromoACBase();
                campos.CodigoInterno = reg;
                lstDepurada.Add(campos);
            }

            return lstDepurada;

        }
        private List<ModSucursalesPromoACBase> DepuraListaSucursalesACBase(FileUpload fuSucursales)
        {

            List<ModSucursalesPromoACBase> lstDepurada = new List<ModSucursalesPromoACBase>();
            List<ModSucursalesPromoACBase> lstSuc = new List<ModSucursalesPromoACBase>();
            string file = "";

            //====================================================================================================================
            //directorios
            string savePath = @"c:\temp\uploads\";
            //valida existencia de directorio
            if (!Directory.Exists(savePath))
            {//crea directorio
                Directory.CreateDirectory(savePath);
            }
            //ruta y nombre de archivo
            //FileUpload fuSucursal = (FileUpload)Session["fldUpSucursales"];
            //savePath += fuSucursal.FileName;
            savePath += fuSucursales.FileName;
            file = savePath;

            //valida existencia de archivo
            if (File.Exists(savePath))
            {
                //Elimina archivo existente
                File.Delete(savePath);
            }

            //guarda archivo en ruta
            fuSucursales.SaveAs(savePath);


            //usamos el objeto FileStream para recuperar el archivo
            SLDocument sl;
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //Creamos el obejto SLDocument para cargar el archivo Excel
                sl = new SLDocument(fs);
                fs.Close();
                fs.Dispose();
                File.Delete(savePath);


                //Verifica que el archivo sea el correcto (Sucursales)
                //if (sl.GetCellValueAsString(1, 1) != "Sucursales")
                //{
                //    sl.Dispose();
                //    return lstDepurada;
                //}

                //Productos
                //int rowIndex = 2;
                int rowIndex = 1;
                int intSucursal = 0;

                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(rowIndex, 1)))
                {
                    ModSucursalesPromoACBase campos = new ModSucursalesPromoACBase();
                    intSucursal = ObtenEquivalenciaSucursal(sl.GetCellValueAsString(rowIndex, 1).ToString());

                    campos.Sucursal = intSucursal;
                    //Si alguna de las sucursales no existe devuelve valor 99999 
                    //se crea una variable de session para especificar en mensaje de error que sucursal fue la incorrecta.
                    if (intSucursal == 99999)
                    {
                        Session.Add("SucursalInexistente", sl.GetCellValueAsString(rowIndex, 1).ToString());
                    }

                    lstSuc.Add(campos);

                    rowIndex += 1;
                }
            }
            //====================================================================================================================

            //Excluye Duplicados
            var lstSucDepurada = lstSuc.Select(s => s.Sucursal).Distinct().ToList();

            foreach (int reg in lstSucDepurada)
            {
                ModSucursalesPromoACBase campos = new ModSucursalesPromoACBase();
                campos.Sucursal = reg;
                lstDepurada.Add(campos);
            }

            return lstDepurada;

        }

        protected void imgbtnHelpSuc_Click(object sender, ImageClickEventArgs e)
        {
            lblpop.Text = "El archivo de Excel debe contener las sucursales listadas apartir de la columna(A) Fila(1). Ejemplo:";
            imgPop.ImageUrl = "../../Images/imgSucursales.png";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
        }

        protected void imgbtnHelpProd_Click(object sender, ImageClickEventArgs e)
        {
            lblpop.Text = "El archivo de Excel debe contener los códigos internos listados apartir de la columna(A) Fila(1). Ejemplo:";
            imgPop.ImageUrl = "../../Images/imgProductos.png";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
        }



    }
}