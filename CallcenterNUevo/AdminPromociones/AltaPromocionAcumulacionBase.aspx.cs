using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Negocio;
using SpreadsheetLight;
using DocumentFormat.OpenXml;

namespace CallcenterNUevo.AdminPromociones
{
    public partial class AltaPromocionAcumulacionBase : System.Web.UI.Page
    {
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
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int intIdRegistro = 0;
            try
            {
                if (Validaciones())
                {
                    //Registra la promoción
                    intIdRegistro = GuardarNuevaPromoACBase();

                    //Registra los dias de la promoción
                    if (GuardarDias(intIdRegistro))
                    {
                        //Registra Productos de la promoción
                        if (GuardarProductosPromocionesACBase(intIdRegistro))
                        {
                            //Registra las sucursales de la promoción
                            if (GuardarSucursalesPromocionesACBase(intIdRegistro))
                            {
                                Mensajes("Se ha registrado correctamente la promoción de acumulación Base.");
                                LimpiarCampos();
                                EliminaVariablesSesion();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromocionAcumulacionBase", "btnGuardar_Click", "Metodos de guardado", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar guardar la promoción de acumulación base., contacte al administrador");
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }
        private int GuardarNuevaPromoACBase()
        {
            int intResultado = 0;

            try
            {
                AdministraPromocion Ejecutar = new AdministraPromocion();
                ModPromocionesACBase campos = new ModPromocionesACBase();

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

                intResultado = Ejecutar.GuardarPromocionesACBase(campos);


                return intResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool GuardarDias(int IdPABase)
        {
            bool blnRespuesta = false;

            AdministraPromocion Ejecutar = new AdministraPromocion();
            List<ModDiasPromoACBAse> lstDias = new List<ModDiasPromoACBAse>();
            try
            {

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

                blnRespuesta = Ejecutar.GuardarDiasPromoACBase(lstDias);

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool GuardarProductosPromocionesACBase(int IdPABase)
        {
            bool blnRespuesta = false;
            try
            {

                AdministraPromocion Ejecutar = new AdministraPromocion();

                //Obtiene lista de productos depurada
                List<ModProductosPromoACBase> lstProd = new List<ModProductosPromoACBase>();
                lstProd = (List<ModProductosPromoACBase>)Session["lstProdACBase"];


                foreach (ModProductosPromoACBase reg in lstProd)
                {
                    ModProductosPromoACBase campos = new ModProductosPromoACBase();
                    campos.IdPABase = IdPABase;
                    campos.CodigoInterno = reg.CodigoInterno;
                    campos.IdStatus = 1;

                    blnRespuesta = Ejecutar.GuardarProductosPromoACBase(campos);
                }

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool GuardarSucursalesPromocionesACBase(int IdPABase)
        {
            try
            {
                AdministraPromocion Ejecutar = new AdministraPromocion();
                bool blnRespuesta = false;

                //Obtiene lista de productos depurada
                List<ModSucursalesPromoACBase> lstSuc = new List<ModSucursalesPromoACBase>();
                lstSuc = (List<ModSucursalesPromoACBase>)Session["lstSucACBase"];


                foreach (ModSucursalesPromoACBase reg in lstSuc)
                {
                    ModSucursalesPromoACBase campos = new ModSucursalesPromoACBase();
                    campos.IdPABase = IdPABase;
                    campos.Sucursal = reg.Sucursal;
                    campos.IdStatus = 1;

                    blnRespuesta = Ejecutar.GuardarSucursalesPromoACBase(campos);
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

            if (string.IsNullOrWhiteSpace(txtCantidadAC.Text))
            {
                Mensajes("Debe proporcionar una cantidad de acumulación.");
                txtCantidadAC.Focus();
                return false;
            }

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

            if (rdpFechaIni.SelectedDate > rdpFechaFin.SelectedDate)
            {
                Mensajes("La Fecha Fin no puede ser menor a la Fecha Inicio.");
                rdpFechaFin.Focus();
                return false;
            }


            if (rdpFechaIni.SelectedDate < DateTime.Now.Date)
            {
                Mensajes("No es posible que la fecha inicio sea menor a la fecha actual.");
                rdpFechaIni.Clear();
                rdpFechaIni.Focus();
                return false;
            }


            if (chkLunes.Checked == false && chkMartes.Checked == false && chkMiercoles.Checked == false && chkJueves.Checked == false && chkViernes.Checked == false && chkSabado.Checked == false && chkDomingo.Checked == false)
            {
                Mensajes("Debe seleccionar un día de la semana por lo menos.");
                return false;
            }

            //if(chkServicioDom.Checked == false && chkSurtir.Checked == false)
            //{
            //    Mensajes("Debe seleccionar alguna de las opciones;  Servicio a Domicilio y/o Surtir en Consultorio");
            //    chkServicioDom.Focus();
            //   return  false;
            //}


            //=========================================================================================================================================
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
                fldUpProductos.Focus();
                return false;
            }
            else
            {
                Session.Add("fldUpProductos", fldUpProductos);
            }



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
                // fldUpProductos.Focus();
                return false;
            }
            else
            {
                //Guarda lista depurada en variable de sesión
                Session.Add("lstProdACBase", lstProdACBase);
            }

            //Excluye Duplicados a la lista de sucursales
            List<ModSucursalesPromoACBase> lstSucACBase = new List<ModSucursalesPromoACBase>();
            lstSucACBase = DepuraListaSucursalesACBase(fldUpSucursales);
            if (lstSucACBase.Count == 0)
            {
                Mensajes("El archivo para la carga de sucursales no cuenta con el layout esperado, ¡Verifique e intente de nuevo!");
                Session.Contents.Remove("fldUpSucursales");
                Session.Remove("fldUpSucursales");
                fldUpSucursales = new FileUpload();
                //fldUpSucursales.Focus();
                return false;
            }
            else
            {
                //Guarda lista depurada en variable de sesión
                Session.Add("lstSucACBase", lstSucACBase);
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
                    Session.Contents.Remove("fldUpProductos");
                    Session.Remove("fldUpProductos");
                    Session.Contents.Remove("lstProdACBase");
                    Session.Remove("lstProdACBase");

                    return blnResultado;
                }
            }


            //Valida que la sucursal sea valida
            bool blnResultadoSuc = false;
            string valorErrorSucu = "";

            foreach (ModSucursalesPromoACBase campos in lstSucACBase)
            {
                blnResultadoSuc = Ejecutar.ValidaExistenciaSucursalACBase(campos.Sucursal);
                if (!blnResultadoSuc)
                {
                    valorErrorSucu = Session["SucursalInexistente"].ToString();
                    Session.Contents.Remove("SucursalInexistente");
                    Session.Remove("SucursalInexistente");

                    Mensajes("La sucursal: " + valorErrorSucu + ", no es valida, ¡Verifique su información e intente de nuevo.!");
                    Session.Contents.Remove("fldUpSucursales");
                    Session.Remove("fldUpSucursales");
                    Session.Contents.Remove("lstSucACBase");
                    Session.Remove("lstSucACBase");

                    return blnResultadoSuc;
                }
            }
            //====================================================================================================================================



            //REVIZAR
            //====================================================================================================================================
            //Valida si la promoción a registrar existe en dbase

            AdministraPromocion ejecutar = new AdministraPromocion();
            bool blnRespuesta = false;
            int i = 0;

            List<ModSucursalesPromoACBase> lstSucursales = new List<ModSucursalesPromoACBase>();
            lstSucursales = DepuraListaSucursalesACBase(fldUpSucursales);

            foreach (ModProductosPromoACBase reg in lstProdACBase)
            {

                ModPromoACBaseValidaciones campos = new ModPromoACBaseValidaciones();
                campos.CodigoInterno = reg.CodigoInterno;
                campos.FechaIni = Convert.ToDateTime(rdpFechaIni.SelectedDate);
                campos.FechaFin = Convert.ToDateTime(rdpFechaFin.SelectedDate);

                //recorre cada una de las sucursales para realizar la validación
                foreach (ModSucursalesPromoACBase suc in lstSucursales)
                {
                    campos.Sucursal = suc.Sucursal.ToString();

                    blnRespuesta = ejecutar.ValidaPromocionACBase(campos);
                    if (blnRespuesta)
                    {
                        Mensajes("Imposible continuar, la Promoción de acumulación base con Código Interno: " + campos.CodigoInterno + ", con vigencia del: " + campos.FechaIni.ToShortDateString() + " al " + campos.FechaFin.ToShortDateString() + " y sucursal: " + campos.Sucursal + ", ya existe ligada en alguna promoción. ¡Verifique su vigencia e intente de nuevo!");
                        return false;
                    }
                }
                i += 1;
            }
            //====================================================================================================================================

            return true;
        }
        private void LimpiarCampos()
        {
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
                if (sl.GetCellValueAsString(1, 1) != "CodigoInterno")
                {
                    sl.Dispose();
                    return lstDepurada;
                }

                //Productos
                int rowIndex = 2;

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
                if (sl.GetCellValueAsString(1, 1) != "Sucursales")
                {
                    sl.Dispose();
                    return lstDepurada;
                }

                //Productos
                int rowIndex = 2;
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
        private int ObtenEquivalenciaSucursal(string Sucursal)
        {
            int intRespuesta = 0;

            AdministraPromocion Ejecutar = new AdministraPromocion();
            intRespuesta = Ejecutar.RegresaIdSucursal(Sucursal);

            return intRespuesta;
        }
    }
}