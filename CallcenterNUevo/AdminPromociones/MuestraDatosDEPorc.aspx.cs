using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using xi = Telerik.Web.UI.ExportInfrastructure;
using Telerik.Web.UI.GridExcelBuilder;
using System.Data;
using Negocio;
using Datos;

namespace CallcenterNUevo.AdminPromociones
{
    public partial class MuestraDatosDEPorc : System.Web.UI.Page
    {
        public static string CnnPruebas = "ConnectionStringTest";
        public static string CnnProductivo = "ConnectionStringProd";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["amb"] == "Prod")
                {
                    btnAutDesAut.Visible = false;
                }
                CargaCombos();
                CargarInformacion();
            }
            ValidarAccion();
        }
        protected void rcbTipoPromocion_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
        protected void rdpFIni_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFIni.SelectedDate.Value != null)
            {
                if (rdpFIni.SelectedDate <= DateTime.Now)
                {
                    Mensajes("No es posible que la fecha inicio sea menor e igual a la fecha actual.");
                    rdpFIni.Clear();
                    rdpFIni.Focus();
                }
            }
        }
        protected void rdpFFin_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (Request.QueryString["amb"] == "Test")
            {
                if (rdpFFin.SelectedDate != null)
                {
                    if (rdpFFin.SelectedDate <= rdpFIni.SelectedDate)
                    {
                        Mensajes("No es posible que sea menor e igual la fecha fin a la fecha inicio.");
                        rdpFFin.Clear();
                        rdpFFin.Focus();
                    }
                }
            }
            else if (Request.QueryString["amb"] == "Prod")
            {
                if (rdpFFin.SelectedDate.Value < DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null))
                {
                    Mensajes("La fecha fin no puede ser menor a la fecha actual...");
                    lblMensajeCancelacion.Text = "";
                    txtComentarios.Text = "";
                    chkVerWS.Checked = true;
                    rdpFFin.SelectedDate = null;
                    rdpFFin.Focus();
                    return;
                }

                if (rdpFFin.SelectedDate.Value == DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null))
                {
                    lblMensajeCancelacion.Text = "Al asignar la fecha actual como fecha fin cancelara dicha promoción.";
                    txtComentarios.Text = "Cancelación de la promoción.";
                    chkVerWS.Checked = false;
                    return;
                }
                else
                {
                    lblMensajeCancelacion.Text = "";
                    txtComentarios.Text = "";
                    chkVerWS.Checked = true;
                }
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["amb"] == "Test")
            {
                Response.Redirect("ConsultaPromPendxAutDesAut.aspx");
            }
            else
            {
                Response.Redirect("AjustePromocion.aspx");
            }

        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (btnModificar.Text == "Modificar")
            {
                Activacontroles();
                lblTitulo.Text = "Modificación de la Promoción ($, %)";
                btnModificar.Text = "Guardar";
            }
            else
            {
                if (Validaciones()) //Regla de Negocio, validaciones de campos de fecha antes de realizar el guardado
                {
                    if (Modificar())
                    {
                        Mensajes("Los cambios fueron registrados correctamente.");
                        Bloqueacontroles();
                        lblTitulo.Text = "Información de la Promoción ($, %)";
                        btnModificar.Text = "Modificar";
                    }
                    else
                    {
                        Mensajes("No fue posible registrar sus cambios, contacte al administrador del sistema...");
                        ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "RegresarPagina();", true);
                    }

                }
            }
        }
        protected void btnCanela_Click(object sender, EventArgs e)
        {
            btnCancelar_Click(null, null);
        }
        protected void rdpFechaPaseProd_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFechaPaseProd.SelectedDate.Value != null)
            {
                if (rdpFechaPaseProd.SelectedDate < System.DateTime.Now.Date)
                {
                    Mensajes("La fecha debe ser mayor ó gual al día actual.");
                    rdpFechaPaseProd.Clear();
                    rdpFechaPaseProd.Focus();
                }
            }
        }
        protected void btnAutDesAut_Click(object sender, EventArgs e)
        {
            if (lblEstatus.Text == "Por Aprobar")
            {
                btnAutorizar.Text = "Autorizar";
                btnAutorizar.Width = 110;
                rdpFechaPaseProd.Enabled = true;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);

            }
            else if (lblEstatus.Text == "Aprobado")
            {
                DataSet DSResultados = new DataSet();
                btnAutDesAut.Text = "Cancela autorización";
                btnAutDesAut.Width = 200;

                rdpFechaPaseProd.SelectedDate = DateTime.Now.Date;//se pasa una fecha la cual no sera tomadav en cuenta
                if (AutorizaDesAutoriza(1))
                {
                    CargarInformacion();
                    Mensajes("La cancelación fue registrada correctamente.");
                    lblPase.Visible = false;
                    lblFechaPase.Text = "";
                    lblFechaPase.Visible = false;
                    rdpFechaPaseProd.Clear();
                    AdministraPromocion Ejecuta = new AdministraPromocion();
                    DSResultados = Ejecuta.ObtenerPromxAutDesAut(CnnPruebas, Session["CodInt"].ToString());
                    if (DSResultados != null)
                    {
                        if (DSResultados.Tables.Count > 0)
                        {
                            if (DSResultados.Tables[0].Rows.Count > 0)
                            {
                                lblEstatus.Text = DSResultados.Tables[0].Rows[0][7].ToString();
                            }
                        }
                    }
                    Bloqueacontroles();
                    btnAutDesAut.Text = "Autorizar";
                    btnAutDesAut.Width = 100;
                }
                else
                {
                    Mensajes("No fue posible realizar sus cambios, contacte al administrador del sistema...");
                    Bloqueacontroles();
                    lblTitulo.Text = "Información de la Promoción";
                    btnAutDesAut.Text = "Autorizar";
                    btnAutDesAut.Width = 100;
                    Response.Redirect("ConsultaPromPendxAutDesAut.aspx");
                }







                //btnAutorizar.Text = "Cancela Autorización";
                //btnAutorizar.Width = 200;
                //rdpFechaPaseProd.Enabled = true;
            }
        }
        protected void btnAutorizar_Click(object sender, EventArgs e)
        {
            DataSet DSResultados = new DataSet();
            int Index = 0;

            if (ValidaFechaAutoriza())
            {
                int AccionARealizar = 0;
                if (lblEstatus.Text == "Por Aprobar")
                {
                    AccionARealizar = 2;
                }
                else if (lblEstatus.Text == "Aprobado")
                {
                    AccionARealizar = 1;
                }

                if (AutorizaDesAutoriza(AccionARealizar))
                {
                    if (AccionARealizar == 2)
                    {
                        CargarInformacion();
                        Mensajes("La autorización fue registrada correctamente.");
                        btnAutDesAut.Text = "Cancela autorización";
                        btnAutDesAut.Width = 200;
                        rdpFechaPaseProd.Clear();
                        AdministraPromocion Ejecuta = new AdministraPromocion();
                        DSResultados = Ejecuta.ObtenerPromxAutDesAut(CnnPruebas, Session["CodInt"].ToString());
                        if (DSResultados != null)
                        {
                            if (DSResultados.Tables.Count > 0)
                            {
                                if (DSResultados.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow registros in DSResultados.Tables[0].Rows)
                                    {
                                        if (Request.QueryString["IdMec"].ToString() == DSResultados.Tables[0].Rows[Index][0].ToString())
                                        {
                                            lblEstatus.Text = DSResultados.Tables[0].Rows[Index][7].ToString();
                                        }
                                        Index += 1;
                                    }

                                }
                            }
                        }
                    }
                    else if (AccionARealizar == 1)
                    {
                        lblPase.Visible = false;
                        lblFechaPase.Visible = false;
                        Mensajes("La cancelación fue registrada correctamente.");
                        rdpFechaPaseProd.Clear();
                        AdministraPromocion Ejecuta = new AdministraPromocion();
                        DSResultados = Ejecuta.ObtenerPromxAutDesAut(CnnPruebas, Session["CodInt"].ToString());
                        if (DSResultados != null)
                        {
                            if (DSResultados.Tables.Count > 0)
                            {
                                if (DSResultados.Tables[0].Rows.Count > 0)
                                {
                                    lblEstatus.Text = DSResultados.Tables[0].Rows[0][7].ToString();
                                }
                            }
                        }
                        Bloqueacontroles();
                        //lblTitulo.Text = "Información de la Promoción";
                        btnAutDesAut.Text = "Autorizar";
                        btnAutDesAut.Width = 100;
                    }
                }
                else
                {
                    Mensajes("No fue posible realizar sus cambios, contacte al administrador del sistema...");
                    Bloqueacontroles();
                    lblTitulo.Text = "Información de la Promoción";
                    btnAutDesAut.Text = "Autorizar";
                    btnAutDesAut.Width = 100;
                    Response.Redirect("ConsultaPromPendxAutDesAut.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
            }
        }

        private bool AutorizaDesAutoriza(int Accion)
        {
            bool blnRespuesta = false;
            ModAutorizarPromociones campos = new ModAutorizarPromociones();
            AdministraPromocion Ejecuta = new AdministraPromocion();
            try
            {
                campos.IdMecanica = Convert.ToInt32(Request.QueryString["IdMec"]);
                campos.IdTipoAcumulacion = Convert.ToInt32(Request.QueryString["TipoAc"]);
                if (lblEstatus.Text == "Por Aprobar")
                {
                    campos.IdStatusPaseProduccion = 2; //Aprobado
                }
                else
                {
                    campos.IdStatusPaseProduccion = 1; //Por Aprobar
                }
                campos.FechaPaseProduccion = (DateTime)rdpFechaPaseProd.SelectedDate;
                blnRespuesta = Ejecuta.AutorizaPromocion(CnnPruebas, campos);
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAutDesAut", "Modificar()", "Ejecuta.AutorizaPromocion(" + campos + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar guardar (Autorizar/DesAutorizar), contacte al administrador");
            }
            return blnRespuesta;
        }
        private void CargaCombos()
        {
            int TipoAcum = 0;
            AdministraPromocion Ejecuta = new AdministraPromocion();
            try
            {
                TipoAcum = Convert.ToInt32(Request.QueryString["TipoAc"]);

                List<ModTipoPromocion> lstResultadosTP = new List<ModTipoPromocion>();

                lstResultadosTP = Ejecuta.ObtenTipoPromocion(CnnPruebas, TipoAcum);

                if (lstResultadosTP != null)
                {
                    if (lstResultadosTP.Count > 0)
                    {
                        rcbTipoPromocion.Items.Clear();
                        rcbTipoPromocion.DataSource = lstResultadosTP;
                        rcbTipoPromocion.DataTextField = "TipoPromocion";
                        rcbTipoPromocion.DataValueField = "Id";
                        rcbTipoPromocion.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosDEPorc", "CargaCombos()", "Ejecuta.ObtenTipoPromocion(" + TipoAcum + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar TipoPromoción, contacte al administrador");
            }
        }
        private void CargarInformacion()
        {
            int IdMecanica = 0;
            int TipoAcumulacion = 0;
            AdministraPromocion Ejecuta = new AdministraPromocion();
            ModContenedorMecanicas Estructura = new ModContenedorMecanicas();

            try
            {
                IdMecanica = Convert.ToInt32(Request.QueryString["Idmec"]);
                TipoAcumulacion = Convert.ToInt32(Request.QueryString["TipoAc"]);
                if (Request.QueryString["EstPase"].ToString() == "1")
                {
                    lblEstatus.Text = "Por Aprobar";
                }
                else
                {
                    lblEstatus.Text = "Aprobado";
                }

                List<ModMecanicaDEPorc> lstRespuesta = new List<ModMecanicaDEPorc>();

                if (Request.QueryString["amb"] == "Test") //Ambiente Pruebas
                {
                    Estructura = Ejecuta.CargaDetalleMecanicaDEPorc(CnnPruebas, IdMecanica, TipoAcumulacion);
                }
                else
                {//Ambiente Productivo
                    Estructura = Ejecuta.CargaDetalleMecanicaDEPorc(CnnProductivo, IdMecanica, TipoAcumulacion);
                }

                lstRespuesta = Estructura.lstMecanicaDEPorc;

                //Setear campos
                foreach (ModMecanicaDEPorc campos in lstRespuesta)
                {
                    rcbTipoPromocion.SelectedValue = campos.idTipoPromocion.ToString();
                    txtCodigo.Text = campos.CodigoInterno;
                    txtNomProducto.Text = campos.Promocion;// Carga el nombre de la promoción
                    txtCantidad.Text = campos.Cantidad.ToString();

                    if (campos.FechaIni.ToString() != "01/01/0001 12:00:00 a. m.")
                    {
                        rdpFIni.SelectedDate = campos.FechaIni;
                    }
                    if (campos.FechaFin.ToString() != "01/01/0001 12:00:00 a. m.")
                    {
                        rdpFFin.SelectedDate = campos.FechaFin;
                    }
                    if (campos.EstatusPaseProd == 2)
                    {
                        lblPase.Visible = true;
                        lblFechaPase.Text = campos.FechaPaseProd.Substring(0, 10);
                        lblFechaPase.Visible = true;
                    }
                    else
                    {
                        lblPase.Visible = false;
                        lblFechaPase.Text = "";
                        lblFechaPase.Visible = false;
                    }
                    chkVerWS.Checked = campos.VerEnReporte;
                }

                if (Estructura.DTComentarios.Rows.Count > 0)
                {
                    divgrid.Visible = true;
                    grvComentarios.DataSource = Estructura.DTComentarios;
                    grvComentarios.DataBind();
                }
                else
                {
                    divgrid.Visible = false;
                }

            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosDEPorc", "CargaInformacion()", "Ejecuta.CargaDetalleMecanicaDEPorc(" + IdMecanica + "," + TipoAcumulacion + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar Información, contacte al administrador");
            }
        }
        private bool Modificar()
        {
            bool blnRespuesta = false;
            string strFechaIni = "";
            string strFechaFin = "";
            DateTime FechaFin;


            if (Request.QueryString["amb"] == "Test") //AMBIENTE PRUEBAS
            {
                ModPromocionesDENoIniciadas Campos = new ModPromocionesDENoIniciadas();
                try
                {
                    Campos.Idmecanica = Convert.ToInt32(Request.QueryString["Idmec"]);
                    Campos.IdTipoPromocion = Convert.ToInt32(rcbTipoPromocion.SelectedValue);
                    Campos.CodigoInterno = txtCodigo.Text;
                    Campos.Cantidad = (string.IsNullOrWhiteSpace(txtCantidad.Text) ? 0 : float.Parse(txtCantidad.Text));
                    Campos.NombreMecanica = txtNomProducto.Text;
                    strFechaIni = rdpFIni.SelectedDate.ToString();
                    strFechaIni = strFechaIni.Substring(0, 10) + " 00:00:00";
                    Campos.FechaInicio = strFechaIni;
                    strFechaFin = rdpFFin.SelectedDate.ToString();
                    strFechaFin = strFechaFin.Substring(0, 10) + " 23:59:59";

                    if (chkVerWS.Checked)
                    {
                        Campos.VerEnReporte = 1;
                    }
                    else
                    {
                        Campos.VerEnReporte = 0;
                    }

                    Campos.FechaFin = strFechaFin;
                    Campos.Comentarios = txtComentarios.Text;
                    Campos.Usuario = HttpContext.Current.User.Identity.Name;

                    AdministraPromocion Ejecuta = new AdministraPromocion();
                    blnRespuesta = Ejecuta.ModificaPromocionesDENoIniciadas(CnnPruebas, Campos);

                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosDEPorc", "Modificar()", "Ejecuta.ModificaPromocionesDENoIniciadas(" + Campos + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error al intentar guardar promociones de ($ y/o %) ambiente pruebas, contacte al administrador");
                }
            }
            else if (Request.QueryString["amb"] == "Prod") //AMBIENTE PRODUCTIVO
            {
                ModPromocionesDEIniciadas Campos = new ModPromocionesDEIniciadas();
                try
                {
                    Campos.Idmecanica = Convert.ToInt32(Request.QueryString["Idmec"]);
                    Campos.CodigoInterno = txtCodigo.Text;
                    strFechaFin = rdpFFin.SelectedDate.ToString();
                    strFechaFin = strFechaFin.Substring(0, 10) + " 23:59:59";

                    if (chkVerWS.Checked)
                    {
                        Campos.VerEnReporte = 1;
                    }
                    else
                    {
                        Campos.VerEnReporte = 0;
                    }

                    Campos.FechaFin = strFechaFin;
                    Campos.Comentarios = txtComentarios.Text;
                    Campos.Usuario = HttpContext.Current.User.Identity.Name;

                    AdministraPromocion Ejecuta = new AdministraPromocion();
                    blnRespuesta = Ejecuta.ModificaPromocionesDEIniciadas(CnnProductivo, Campos);

                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosDEPorc", "Modificar()", "Ejecuta.ModificaPromocionesDEIniciadas(" + Campos + ")", "Ocurrio un error (ambiente productivo): " + ex.Message.ToString(), this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error al intentar guardar promociones de ($ y/o %) ambiente productivo, contacte al administrador");
                }
            }
            Bloqueacontroles();
            return blnRespuesta;
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
        private void Activacontroles()
        {
            if (Request.QueryString["amb"] == "Test")
            {
                rcbTipoPromocion.Enabled = true;
                txtCodigo.Enabled = true;
                txtNomProducto.Enabled = true;
                txtCantidad.Enabled = true;
                rdpFIni.Enabled = true;
                rdpFFin.Enabled = true;
                txtComentarios.Enabled = true;
                chkVerWS.Enabled = true;
            }
            else if (Request.QueryString["amb"] == "Prod")
            {
                rdpFFin.Enabled = true;
                txtComentarios.Enabled = true;
                chkVerWS.Enabled = true;
            }
        }
        private void Bloqueacontroles()
        {
            rcbTipoPromocion.Enabled = false;
            txtCodigo.Enabled = false;
            txtNomProducto.Enabled = false;
            txtCantidad.Enabled = false;
            rdpFIni.Enabled = false;
            rdpFFin.Enabled = false;
            txtComentarios.Enabled = false;
            chkVerWS.Enabled = false;
        }
        private bool Validaciones()
        {
            bool blnRespuesta = true;

            if (rdpFFin.SelectedDate == null)
            {
                Mensajes("Es necesario proporcione una fecha fin.");
                rdpFFin.Clear();
                rdpFFin.Focus();
                return false;
            }

            if (Request.QueryString["amb"] == "Test")
            {
                if (rdpFFin.SelectedDate != null)
                {
                    if (rdpFFin.SelectedDate <= rdpFIni.SelectedDate)
                    {
                        Mensajes("No es posible que sea menor e igual a la fecha inicio.");
                        rdpFFin.Clear();
                        rdpFFin.Focus();
                        return false;
                    }
                }

                if (string.IsNullOrWhiteSpace(txtComentarios.Text))
                {
                    Mensajes("Este campo es obligatorio, registre un comentario.");
                    txtComentarios.Focus();
                    return false;
                }
            }
            else if (Request.QueryString["amb"] == "Prod")
            {
                if (rdpFFin.SelectedDate.Value < DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null))
                {
                    Mensajes("La fecha fin no puede ser menor a la fecha actual...");
                    lblMensajeCancelacion.Text = "";
                    txtComentarios.Text = "";
                    chkVerWS.Checked = true;
                    rdpFFin.SelectedDate = null;
                    rdpFFin.Focus();
                    return false;
                }
            }

            return blnRespuesta;
        }
        private bool ValidaFechaAutoriza()
        {

            bool blnResultado = true;
            if (rdpFechaPaseProd.SelectedDate != null)
            {
                if (rdpFechaPaseProd.SelectedDate < DateTime.Now.Date)
                {
                    Mensajes("La fecha debe ser mayor ó igual al día actual.");
                    rdpFechaPaseProd.Clear();
                    rdpFechaPaseProd.Focus();
                    blnResultado = false;
                    return blnResultado;
                }
            }
            else
            {
                Mensajes("Es necesario proporcione una fecha.");
                rdpFechaPaseProd.Focus();
                blnResultado = false;
                return blnResultado;
            }

            return blnResultado;
        }
        private void ValidarAccion()
        {
            if (lblEstatus.Text == "Aprobado")
            {
                btnAutDesAut.Text = "Cancela autorización";
                btnAutDesAut.Width = 200;
            }
        }
        protected void btnCancelar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaPromPendxAutDesAut.aspx");
        }
    }
}