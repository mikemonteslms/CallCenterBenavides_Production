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

    public partial class AltaPromocion : System.Web.UI.Page
    {
        Clientes prmEjecuta = new Clientes();
        public static string CnnPruebas = "ConnectionStringTest";
        public static string CnnProductivo = "ConnectionStringProd";
        public int CuentaRegVacios = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargaCombos();
                Nuevoregistro("A");
                rdpFSolicitud.SelectedDate = DateTime.Now.Date;
            }

            if (Session["MensajeForzarAltaLab"] != null)
            {
                Mensajes(Session["MensajeForzarAltaLab"].ToString());
                Session.Contents.Remove("MensajeForzarAltaLab");
                Session.Remove("MensajeForzarAltaLab");
            }

            foreach (GridViewRow cell in grvProd.Rows)
            {
                if (rcbTipoPromocion.Text == "A+A")
                {
                    //Iguala el código interno vs el código entrega
                    TextBox txtcod = (cell.Cells[0].FindControl("txtcod") as TextBox);
                    TextBox txtcodentrega = (cell.Cells[0].FindControl("txtcodEntrega") as TextBox);
                    //Al presionar tecla Enter, iguala el valor de codigo interno a Codigo entrega
                    txtcodentrega.Text = txtcod.Text;
                    txtcod.Attributes.Add("onkeypress", "cambiaFoco('txtreglanegocio')");
                    txtCantcompra.Focus();
                }
                else
                {
                    //no igualara
                    TextBox txtcod = (cell.Cells[0].FindControl("txtcod") as TextBox);
                    //Al presionar tecla Enter, iguala el valor de codigo interno a Codigo entrega
                    txtcod.Attributes.Add("onkeypress", "cambiaFoco('txtreglanegocio')");
                    txtCantcompra.Focus();
                }
            }
        }
        protected void grvProd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                RadComboBoxItem elemento;
                RadComboBox cmb = (e.Row.FindControl("cmbLab") as RadComboBox);
                Label lbl = (e.Row.FindControl("lblIdLab") as Label);

                //Evita que realice la consulta si no encontro los objetos
                //embebidos en el gridview
                if (cmb != null && lbl != null)
                {
                    AdministraPromocion Ejecuta = new AdministraPromocion();
                    List<ModLaboratorio> lstResultadosLab = new List<ModLaboratorio>();
                    lstResultadosLab = Ejecuta.ObtenLaboratorios(CnnPruebas);

                    if (lstResultadosLab != null)
                    {
                        if (lstResultadosLab.Count > 0)
                        {
                            foreach (ModLaboratorio itmlab in lstResultadosLab)
                            {
                                //carga dropdownlist por cada registro
                                elemento = new RadComboBoxItem(itmlab.Laboratorio, itmlab.IdLaboratorio.ToString());

                                cmb.Items.Add(elemento);
                                cmb.SelectedValue = itmlab.IdLaboratorio.ToString(); //asigna id del laboratorio al SelectValue
                            }
                        }
                    }
                    cmb.SelectedIndex = -1;
                    cmb.Text = "---Seleccione un laboratorio---";
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatos", "grvProd_RowDataBound", "Ejecuta.ObtenLaboratorios()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                //Mensajes("Ocurrio un error al intentar cargar Laboratorios, contacte al administrador");
            }
        }
        protected void grvProd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (grvProd.Rows.Count > 1)
            {
                DataTable dt1 = new DataTable();
                dt1 = EstructuraProductos();
                DataRow dr;
                //Recorre el contenido del grid y lo guarda en datatable
                foreach (GridViewRow row in this.grvProd.Rows)
                {
                    TextBox txtcodigo = (TextBox)row.FindControl("txtcod");
                    TextBox txtProd = (TextBox)row.FindControl("txtNomProd");
                    TextBox txtcodEnt = (TextBox)row.FindControl("txtcodEntrega");
                    Label lblIdLab = (Label)row.FindControl("lblIdLab");
                    TextBox txtCat = (TextBox)row.FindControl("txtCat");

                    RadComboBox cmbLab = (RadComboBox)row.FindControl("cmbLab");
                    dr = dt1.NewRow();
                    dr[0] = txtcodigo.Text.ToString();
                    dr[1] = txtCat.Text;
                    dr[2] = txtProd.Text.ToString();
                    dr[3] = cmbLab.SelectedValue;
                    dr[4] = txtcodEnt.Text.ToString();
                    dr[5] = cmbLab.SelectedValue;
                    dr[6] = txtCat.Text;

                    dt1.Rows.Add(dr);
                    ViewState["DataTemp"] = dt1;
                }
                //Elimina registro de datatable
                dt1.Rows.RemoveAt(e.RowIndex);

                //Asigna origen de datos al grid
                grvProd.DataSource = dt1;
                grvProd.DataBind();
            }
            else
            {
                Mensajes("imposible eliminar esta fila.");
            }

        }
        protected void txtcod_TextChanged(object sender, EventArgs e)
        {
            AdministraPromocion Ejecuta = new AdministraPromocion();
            ModDatosGrid Resultado = new ModDatosGrid();
            TextBox codInt = new TextBox();
            TextBox codIntEntrega = new TextBox();
            TextBox nomProd = new TextBox();
            TextBox categoria = new TextBox();
            RadComboBox cmblab = new RadComboBox();

            codInt.Text = "";
            codIntEntrega.Text = "";

            try
            {



                foreach (GridViewRow row in this.grvProd.Rows)
                {

                    //Obtiene controles embebidos en el grid
                    codInt = (row.FindControl("txtcod") as TextBox);
                    categoria = (row.FindControl("txtCat") as TextBox);
                    nomProd = (row.FindControl("txtNomProd") as TextBox);
                    cmblab = (row.FindControl("cmbLab") as RadComboBox);
                    codIntEntrega = (row.FindControl("txtcodEntrega") as TextBox);

                    //Limpia valores seleccionados previamente a control combo laboratorios
                    //cmblab.SelectedIndex = -1;
                    //cmblab.Text = "";
                    //cmblab.Text = "---Seleccione un laboratorio---";
                    cmblab.Enabled = true;
                    //////////////////////////////////////////////////////////////

                    //Consulta en ambiente pruebas 
                    Resultado = Ejecuta.ValidaExistenciaCodInterno(CnnPruebas, codInt.Text);

                    //Valida la existencia y setea campos del codigo interno
                    if (Resultado != null)
                    {
                        //setea resultados a controles
                        codInt.Text = Resultado.codigointerno;
                        nomProd.Text = Resultado.nombreProducto;

                        categoria.Text = Resultado.Categoria_strID;
                        if (Resultado.id_laboratorio != "46")
                        {
                            cmblab.SelectedValue = Resultado.id_laboratorio;
                        }
                        else
                        {
                            cmblab.SelectedIndex = -1;
                            cmblab.Text = "---Seleccione un laboratorio---";
                        }


                        if (rcbTipoPromocion.Text == "A+A" || rcbTipoPromocion.Text == "A+$")
                        {
                            codIntEntrega.Text = codInt.Text;
                        }
                        else
                        {
                            codIntEntrega.Focus();
                        }
                    }
                    else
                    {
                        Mensajes("Producto no existente.");
                        codInt.Text = "";
                        codInt.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromocion", "txtcod_TextChange", "Ejecuta.ValidaExistenciaCodInterno(" + CnnPruebas + "," + codInt.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al validar la existencia del codigo interno, contacte al administrador");
            }
        }
        protected void txtlimcantidad_TextChanged(object sender, EventArgs e)
        {
            int Valormin = 0;
            int Valormax = 0;

            if (!string.IsNullOrWhiteSpace(txtlimcantidad.Text))
            {
                Parametros prmRespuesta = new Parametros();

                prmRespuesta = prmEjecuta.ObtenerParametros("LimiteMin");
                Valormin = Convert.ToInt32(prmRespuesta.ValorPrm);
                prmRespuesta = prmEjecuta.ObtenerParametros("LimiteMax");
                Valormax = Convert.ToInt32(prmRespuesta.ValorPrm);

                if (Convert.ToInt32(txtlimcantidad.Text) > Valormax || Convert.ToInt32(txtlimcantidad.Text) < Valormin)
                {
                    Mensajes("El Límite proporcionado no es valido, el valor mínimo permitido es de: " + Valormin + ", y el valor máximo permitido es de: " + Valormax);
                    txtlimcantidad.Text = "";
                    txtlimcantidad.Focus();
                }
            }
        }
        protected void txtCantentrega_TextChanged(object sender, EventArgs e)
        {
            ValidaBeneficioDE();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Nuevoregistro("A");
            SeteaLaboratoriosExistentes();
        }
        protected void rcbSegmento_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
        protected void rcbTipoPromocion_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            MantenerSoloRegistro();
            ValidaBeneficioDE();
            LimpiarControlesSel();
        }
        protected void rcbLimPeriodo_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcbLimPeriodo.Text == "indefinido")
            {
                txtlimcantidad.Text = "9999";
                txtlimcantidad.Enabled = false;
            }
            else
            {
                txtlimcantidad.Text = "";
                txtlimcantidad.Enabled = true;
                txtlimcantidad.Focus();
            }
        }
        protected void rdpFIni_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFIni.SelectedDate.Value != null)
            {
                if (rdpFIni.SelectedDate <= DateTime.Now.Date)
                {
                    Mensajes("No es posible que la fecha inicio sea menor e igual a la fecha actual.");
                    rdpFIni.Clear();
                    rdpFIni.Focus();
                }
            }
        }
        protected void rdpFFin_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFFin.SelectedDate.Value != null)
            {
                if (rdpFFin.SelectedDate <= rdpFIni.SelectedDate)
                {
                    Mensajes("No es posible que la fecha fin sea menor e igual a la Fecha Inicio.");
                    rdpFFin.Clear();
                    rdpFFin.Focus();
                    chkAplicaExt.Visible = false;
                    return;
                }

                if (rdpFFin.SelectedDate != null)
                {
                    if (rdpFFin.SelectedDate.Value.Year > (DateTime.Now.Year + 2))
                    {
                        Mensajes("No es posible que la fecha fin sea mayor a dos años posteriores.");
                        rdpFFin.Clear();
                        rdpFFin.Focus();
                        chkAplicaExt.Visible = false;

                        return;
                    }
                }

                //Verifica que no exista la mecanica dentro de la fechafin proporcionada
                AdministraPromocion ejecuta = new AdministraPromocion();
                List<ModPromoMecanicas> lstRespuestaPruebas = new List<ModPromoMecanicas>();
                int IdMecanica = 0;
                string codInterno = "";
                string strRespuesta = "";

                foreach (GridViewRow reg in grvProd.Rows)
                {
                    TextBox codInt = (reg.Cells[0].FindControl("txtcod") as TextBox);
                    codInterno = codInt.Text;
                }

                string Ambiente = "Pruebas";
                strRespuesta = ejecuta.ValidarCodigoInterno(Ambiente, IdMecanica, codInterno, (DateTime)rdpFIni.SelectedDate, (DateTime)rdpFFin.SelectedDate);
                if (!string.IsNullOrWhiteSpace(strRespuesta))
                {
                    Mensajes(strRespuesta);
                    rdpFFin.Clear();
                    rdpFFin.Focus();

                    return;
                }



                chkAplicaExt.Visible = true;
            }
        }
        protected void rdpFConteo_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFConteo.SelectedDate > rdpFIni.SelectedDate)
            {
                Mensajes("No es posible que la fecha conteo sea mayor a la Fecha Inicio.");
                rdpFConteo.Clear();
                rdpFConteo.Focus();
            }
        }
        protected void rdpFSolicitud_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFSolicitud.SelectedDate < DateTime.Now.Date)
            {
                Mensajes("La fecha solicitud no puede ser menor al día actual.");
                rdpFSolicitud.Clear();
                rdpFSolicitud.Focus();
            }
        }
        protected void rdpFExt_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFFin.SelectedDate.Value != null)
            {
                if (rdpFExt.SelectedDate <= rdpFFin.SelectedDate)
                {
                    Mensajes("No es posible que sea menor e igual a la fecha fin.");
                    rdpFExt.Clear();
                    rdpFExt.Focus();
                }
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (GuardarNvaPromocion(CnnPruebas))
                {
                    Mensajes("La nueva promocíón fue registrada correctamente.");
                    LimpiarControles();
                }
                else
                {
                    Mensajes("No fue posible registrar la nueva promoción, verifique la información que sea correcta.");
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromocion", "btnGuardar_Click", "GuardarNvaPromocion(" + CnnPruebas + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar dar de alta la nueva promoción, contacte al administrador");
            }
        }
        protected void chkAplicaExt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAplicaExt.Checked)
            {
                rdbEntregaSugeridosCierre.Enabled = true;
                rdbEntregaSugeridos.Enabled = true;
                lblFext.Visible = true;
                rdpFExt.Visible = true;
            }
            else
            {
                rdbEntregaSugeridosCierre.Enabled = false;
                rdbEntregaSugeridos.Enabled = false;
                lblFext.Visible = false;
                rdpFExt.Clear();
                rdpFExt.Visible = false;
            }
        }


        private DataTable EstructuraProductos()
        {
            DataTable medidaTabla = new DataTable();

            medidaTabla.Columns.Add("CodigoInterno", typeof(string));
            medidaTabla.Columns.Add("Categoria", typeof(string));
            medidaTabla.Columns.Add("NomProducto", typeof(string));
            medidaTabla.Columns.Add("Laboratorio", typeof(string));
            medidaTabla.Columns.Add("CodigoInternoEntrega", typeof(string));
            medidaTabla.Columns.Add("IdLaboratorio", typeof(string));
            medidaTabla.Columns.Add("IdCat", typeof(string));
            return medidaTabla;
        }
        private void Nuevoregistro(string tipo)
        {

            TextBox txtcodigo;
            TextBox txtProd;
            TextBox txtcodEnt;
            TextBox txtCat;
            Label lblIdLab;
            RadComboBox cmbLab;
            DataTable dt = null;
            dt = EstructuraProductos();
            DataRow dr;

            if (CuentaRegVacios == 0)
            {
                if (ViewState["DataTemp"] == null)
                {
                    dr = dt.NewRow();
                    dr[0] = "";
                    dr[1] = "";
                    dr[2] = "";
                    dr[3] = "";
                    dr[4] = "";
                    dr[5] = "";
                    dr[6] = "";
                    dt.Rows.Add(dr);
                    ViewState["DataTemp"] = dt;
                }
                else
                {
                    foreach (GridViewRow row in this.grvProd.Rows)
                    {
                        txtcodigo = (TextBox)row.FindControl("txtcod");
                        txtProd = (TextBox)row.FindControl("txtNomProd");
                        txtcodEnt = (TextBox)row.FindControl("txtcodEntrega");
                        txtCat = (TextBox)row.FindControl("txtCat");
                        lblIdLab = (Label)row.FindControl("lblIdLab");
                        cmbLab = (RadComboBox)row.FindControl("cmbLab");

                        dr = dt.NewRow();
                        dr[0] = txtcodigo.Text.ToString();
                        dr[1] = txtCat.Text;
                        dr[2] = txtProd.Text.ToString();
                        dr[3] = cmbLab.Text;
                        dr[4] = txtcodEnt.Text.ToString();
                        dr[5] = cmbLab.SelectedValue;
                        dr[6] = txtCat.Text;

                        dt.Rows.Add(dr);
                        ViewState["DataTemp"] = dt;

                        if (rcbTipoPromocion.Text == "A+A" || rcbTipoPromocion.Text == "A+$")
                        {
                            txtcodEnt.Enabled = false;
                        }
                        else
                        {
                            txtcodEnt.Enabled = true;
                        }

                        if (//string.IsNullOrWhiteSpace(cmbCat.SelectedValue) ||
                        string.IsNullOrWhiteSpace(txtcodigo.Text.ToString()) ||
                        string.IsNullOrWhiteSpace(txtProd.Text.ToString()) ||
                        string.IsNullOrWhiteSpace(cmbLab.SelectedValue) ||
                        string.IsNullOrWhiteSpace(txtcodEnt.Text.ToString()) ||
                        string.IsNullOrWhiteSpace(cmbLab.SelectedValue))
                        //|| string.IsNullOrWhiteSpace(cmbCat.SelectedValue))
                        {
                            CuentaRegVacios += 1;
                        }
                        else
                        {
                            CuentaRegVacios += 0;
                        }
                    }
                    if (tipo == "A" && CuentaRegVacios == 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = "";
                        dr[1] = "";
                        dr[2] = "";
                        dr[3] = "";
                        dr[4] = "";
                        dr[5] = "";
                        dr[6] = "";
                        dt.Rows.Add(dr);

                    }
                    else
                    {   //En caso de detectar campos vacios dentro de una fila
                        Mensajes("No debe dejar filas y/o celdas vacias.");
                    }
                    ViewState["DataTemp"] = dt;
                }

                this.grvProd.DataSource = ViewState["DataTemp"];
                this.grvProd.DataBind();
            }

        }
        protected void CargaCombos()
        {
            AdministraPromocion ejecuta = new AdministraPromocion();
            int TipoAcum = 0;
            try
            {

                List<ModSegmento> lstResultados = new List<ModSegmento>();
                lstResultados = ejecuta.ObtenSegmentos(CnnPruebas);

                if (lstResultados != null)
                {
                    if (lstResultados.Count > 0)
                    {
                        rcbSegmento.Items.Clear();
                        rcbSegmento.DataSource = lstResultados;
                        rcbSegmento.DataTextField = "Segmento";
                        rcbSegmento.DataValueField = "IdSegmento";
                        rcbSegmento.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones", "CargaCombos()", "ejecuta.ObtenSegmentos()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar segmentos, contacte al administrador");
            }

            try
            {
                TipoAcum = 1;

                List<ModTipoPromocion> lstResultadosTP = new List<ModTipoPromocion>();
                lstResultadosTP = ejecuta.ObtenTipoPromocion(CnnPruebas, TipoAcum);

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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones", "CargaCombos()", "ejecuta.ObtenTipoPromocion(" + TipoAcum + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar tipopromocion, contacte al administrador");
            }


            try
            {
                List<ModLimitePeriodo> lstResultadoslimPer = new List<ModLimitePeriodo>();
                lstResultadoslimPer = ejecuta.ObtenLimitePeriodo(CnnPruebas);

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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones", "CargaCombos()", "ejecuta.ObtenLimitePeriodo()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar Límite Periodo, contacte al administrador");
            }
        }
        private bool GuardarNvaPromocion(string cnn)
        {
            bool blnRespuesta = true;
            int intDuplicados = 0;
            TextBox txtcodInt = new TextBox();
            TextBox txtcat = new TextBox();
            TextBox txtcodEnt = new TextBox();
            TextBox txtNomProd = new TextBox();
            RadComboBox cmbLab = new RadComboBox();
            string strFechaIni = "";
            string strFechaFin = "";
            string strFechaConteo = "";
            string strFechaExt = "";
            string strCodInt = "";
            string strCodEnt = "";

            intDuplicados = ValidarDuplicados();

            if (intDuplicados == 0)
            {
                if (Validaciones())
                {
                    ModPromocionesNoIniciadas campos = new ModPromocionesNoIniciadas();
                    AdministraPromocion Ejecuta = new AdministraPromocion();

                    foreach (GridViewRow cell in grvProd.Rows)
                    {
                        txtcodInt = (cell.Cells[0].FindControl("txtcod") as TextBox);
                        txtcat = (cell.Cells[1].FindControl("txtCat") as TextBox);
                        txtNomProd = (cell.Cells[2].FindControl("txtNomProd") as TextBox);
                        cmbLab = (cell.Cells[3].FindControl("cmbLab") as RadComboBox);
                        txtcodEnt = (cell.Cells[4].FindControl("txtcodEntrega") as TextBox);

                        if (strCodInt == "")
                        {
                            strCodInt = txtcodInt.Text;
                        }
                        else
                        {
                            if (strCodInt.IndexOf(txtcodInt.Text) == -1)
                            {
                                strCodInt = strCodInt + "," + txtcodInt.Text;
                            }
                        }

                        if (strCodEnt == "")
                        {
                            strCodEnt = txtcodEnt.Text;
                        }
                        else
                        {
                            if (strCodEnt.IndexOf(txtcodEnt.Text) == -1)
                            {
                                strCodEnt = strCodEnt + "," + txtcodEnt.Text;
                            }
                        }
                    }
                    //Nombre promoción según el tipo de promoción seleccionada
                    if (rcbTipoPromocion.Text == "A+A" || rcbTipoPromocion.Text == "A+B")
                    {
                        campos.NombrePromocion = txtCantcompra.Text + "+" + txtCantentrega.Text + " " + txtNomProd.Text;
                    }
                    else if (rcbTipoPromocion.Text == "A+$")
                    {
                        campos.NombrePromocion = txtNomProdADE.Text;
                    }
                    else if (rcbTipoPromocion.Text == "M&M")
                    {
                        campos.NombrePromocion = txtNomProdMM.Text;
                    }
                    campos.IdTipoAcumulacion = 1;
                    campos.IdSegmento = Convert.ToInt32(rcbSegmento.SelectedValue);
                    campos.IdTipoPromocion = Convert.ToInt32(rcbTipoPromocion.SelectedValue);
                    campos.CodigoInterno = strCodInt;
                    campos.CodigoInternoEntrega = strCodEnt;
                    campos.IdPeriodo = Convert.ToInt32(rcbLimPeriodo.SelectedValue);
                    campos.Limite = Convert.ToInt32(txtlimcantidad.Text);
                    strFechaIni = rdpFIni.SelectedDate.ToString().Substring(0, 10);
                    strFechaIni = strFechaIni + " 00:00:00";
                    campos.FechaInicio = strFechaIni;
                    strFechaFin = rdpFFin.SelectedDate.ToString().Substring(0, 10);
                    strFechaFin = strFechaFin + " 23:59:59";
                    campos.FechaFin = strFechaFin;
                    strFechaConteo = rdpFConteo.SelectedDate.ToString().Substring(0, 10);
                    strFechaConteo = strFechaConteo + " 00:00:00";
                    campos.FechaConteo = strFechaConteo;
                    campos.Comentarios = txtComentario.Text;
                    campos.Usuario = HttpContext.Current.User.Identity.Name;
                    campos.CantidadCompra = (string.IsNullOrWhiteSpace(txtCantcompra.Text) ? 0 : Convert.ToInt32(txtCantcompra.Text));
                    campos.CantidadEntrega = (string.IsNullOrWhiteSpace(txtCantentrega.Text) ? 0 : Convert.ToInt32(txtCantentrega.Text));
                    campos.Lider = txtcodInt.Text;
                    if (chkVerWS.Checked)
                    {
                        campos.VerEnReporte = 1;
                    }
                    else
                    {
                        campos.VerEnReporte = 0;
                    }

                    if (chkAplicaExt.Checked)
                    {
                        campos.flagExtension = 1;
                        strFechaExt = rdpFExt.SelectedDate.ToString().Substring(0, 10);
                        strFechaExt = strFechaExt + " 23:59:59";
                        campos.FechaExtension = strFechaExt;
                    }
                    else
                    {
                        campos.flagExtension = 0;
                        strFechaExt = strFechaExt = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + " 00:00:00";
                        campos.FechaExtension = strFechaExt;
                    }

                    if (rdbEntregaSugeridosCierre.Checked)
                    {
                        campos.CierreCiclosSugeridos = 0;
                    }
                    else if (rdbEntregaSugeridos.Checked)
                    {
                        campos.CierreCiclosSugeridos = 1;
                    }

                    //Valida si existen otras promociones con el mismo código interno y  se modifica la fechafin por getdate() 
                    //para que la nueva promoción pueda ser sometida a pruebas.
                    Ejecuta.EliminarPromocionesPreviasxCodigoInterno(CnnPruebas, campos.CodigoInterno);

                    //Se registra nueva promoción
                    blnRespuesta = Ejecuta.GuardarPromociones(cnn, campos);

                    //Setea Laboratorios
                    foreach (GridViewRow cell in grvProd.Rows)
                    {
                        txtcodInt = (cell.Cells[0].FindControl("txtcod") as TextBox);
                        cmbLab = (cell.Cells[3].FindControl("cmbLab") as RadComboBox);


                        //Setear laboratorio
                        ModsetNvasPromLaboratorio cmpLab = new ModsetNvasPromLaboratorio();
                        cmpLab.CodigoInterno = txtcodInt.Text;
                        cmpLab.IdLaboratorio = Convert.ToInt32(cmbLab.SelectedValue);

                        //Se asocia laboratorio seleccionado a código interno
                        Ejecuta.GuardarnvoLaboratorio(CnnPruebas, cmpLab);
                    }
                }
                else
                {
                    blnRespuesta = false;
                }
            }
            else
            {
                Mensajes("Imposible continuar, existen " + intDuplicados + " producto(s) duplicado(s).");
                blnRespuesta = false;
            }
            return blnRespuesta;
        }
        private void ActivarControles()
        {
            if (rcbTipoPromocion.Text == "M&M")
            {
                lblNomProdMM.Visible = true;
                txtNomProdMM.Visible = true;
                grvProd.Columns[5].Visible = true;
                btnAgregar.Visible = true;
            }
            else
            {
                lblNomProdMM.Visible = false;
                txtNomProdMM.Text = "";
                txtNomProdMM.Visible = false;
                grvProd.Columns[5].Visible = false;
                btnAgregar.Visible = false;
            }
        }
        private void BloquearCOntroles()
        {
            //Controles Mix & Match
            grvProd.Columns[5].Visible = false;
            btnAgregar.Visible = false;
        }
        private void MantenerSoloRegistro()
        {
            if (grvProd.Rows.Count > 1 && rcbTipoPromocion.Text != "M&M")
            {
                DataTable dt1 = new DataTable();
                dt1 = EstructuraProductos();
                DataRow dr;
                //Recorre el contenido del grid y lo guarda en datatable
                foreach (GridViewRow row in this.grvProd.Rows)
                {
                    TextBox txtcodigo = (TextBox)row.FindControl("txtcod");
                    TextBox txtProd = (TextBox)row.FindControl("txtNomProd");
                    TextBox txtcodEnt = (TextBox)row.FindControl("txtcodEntrega");
                    Label lblIdLab = (Label)row.FindControl("lblIdLab");
                    TextBox txtCat = (TextBox)row.FindControl("txtCat");

                    RadComboBox cmbLab = (RadComboBox)row.FindControl("cmbLab");
                    dr = dt1.NewRow();
                    dr[0] = txtcodigo.Text.ToString();
                    dr[1] = txtProd.Text.ToString();
                    dr[2] = txtCat.Text;
                    dr[3] = cmbLab.SelectedValue;
                    dr[4] = txtcodEnt.Text.ToString();
                    dr[5] = cmbLab.SelectedValue;
                    dr[6] = txtCat.Text;

                    dt1.Rows.Add(dr);
                    ViewState["DataTemp"] = dt1;
                }

                int NoReg = 0;
                NoReg = (grvProd.Rows.Count - 2);//Descuenta 2 considerando el indice 0 y 1 el cual no debe eliminarse

                for (int i = 0; i <= NoReg; i++)
                {
                    //Elimina registro de datatable
                    dt1.Rows.RemoveAt(1);
                }

                //Asigna origen de datos al grid
                grvProd.DataSource = dt1;
                grvProd.DataBind();
                BloquearCOntroles();
            }
            else
            {
                ActivarControles();
            }
        }
        private bool Validaciones()
        {
            bool blnRespuesta = true;
            AdministraPromocion Ejecuta = new AdministraPromocion();
            ModValidaPromocion campos = new ModValidaPromocion();
            TextBox txtcodEntrega = new TextBox();

            txtcodEntrega.Text = "";

            if (rcbSegmento.SelectedValue == "")
            {
                Mensajes("Imposible continuar, es necesario seleccione un segmento.");
                rcbSegmento.Focus();
                return false;
            }

            if (rcbTipoPromocion.SelectedValue == "")
            {
                Mensajes("Imposible continuar, es necesario seleccione un tipo de promoción.");
                rcbTipoPromocion.Focus();
                return false;
            }

            if (rcbTipoPromocion.Text == "A+$")
            {
                if (string.IsNullOrWhiteSpace(txtNomProdADE.Text))
                {
                    Mensajes("Imposible continuar, es necesario proporcione un nombre de promoción A+$.");
                    txtNomProdADE.Focus();
                    return false;
                }
            }

            if (rcbTipoPromocion.Text == "M&M")
            {
                if (string.IsNullOrWhiteSpace(txtNomProdMM.Text))
                {
                    Mensajes("Imposible continuar, es necesario proporcione un nombre de promoción M&M.");
                    txtNomProdMM.Focus();
                    return false;
                }
            }

            foreach (GridViewRow cell in grvProd.Rows)
            {
                TextBox txtcod = (cell.Cells[0].FindControl("txtcod") as TextBox);
                RadComboBox cmbLab = (cell.Cells[3].FindControl("cmbLab") as RadComboBox);
                txtcodEntrega = (cell.Cells[4].FindControl("txtcodEntrega") as TextBox);

                if (string.IsNullOrWhiteSpace(txtcod.Text))
                {
                    Mensajes("Imposible continuar, es necesario proporcione un código interno.");
                    txtcod.Focus();
                    return false;
                }

                //Valida Laboratorio
                ////////////////////////////////////////////////////////////////////////////////////////////////
                int idLab = 0;
                if (string.IsNullOrWhiteSpace(cmbLab.Text) || cmbLab.Text == "---Seleccione un laboratorio---")
                {
                    Mensajes("Imposible continuar, debé asociar cada producto de la lista a un laboratorio.");
                    //cmbLab.SelectedIndex = - 1;
                    cmbLab.Text = "---Seleccione un laboratorio---";
                    cmbLab.Focus();
                    return false;
                }

                if (!string.IsNullOrWhiteSpace(cmbLab.SelectedValue))
                {
                    idLab = Convert.ToInt32(cmbLab.SelectedValue);
                }
                else
                {
                    Mensajes("Imposible continuar, seleccione un laboratorio existente de la lista.");
                    //cmbLab.SelectedIndex = -1;
                    cmbLab.Text = "---Seleccione un laboratorio---";
                    cmbLab.Focus();
                    return false;
                }

                if (idLab < 1000)
                {
                    Mensajes("Imposible continuar, seleccione un laboratorio existente de la lista.");
                    //cmbLab.SelectedIndex = -1;
                    cmbLab.Text = "---Seleccione un laboratorio---";
                    cmbLab.Focus();
                    return false;
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////

                if (string.IsNullOrWhiteSpace(txtcodEntrega.Text))
                {
                    Mensajes("Imposible continuar, es necesario proporcione un código de entrega.");
                    txtcodEntrega.Focus();
                    return false;
                }

                //A+B
                if (rcbTipoPromocion.Text == "A+B")
                {
                    if (txtcod.Text == txtcodEntrega.Text)
                    {
                        Mensajes("Imposible continuar, el código que entrega no puede ser igual al Código interno.");
                        txtcodEntrega.Text = "";
                        txtcodEntrega.Focus();
                        return false;
                    }


                    //Consulta en ambiente pruebas La existencia del codigo interno que entrega
                    ModDatosGrid Resultados = new ModDatosGrid();
                    Resultados = Ejecuta.ValidaExistenciaCodInterno(CnnPruebas, txtcodEntrega.Text);

                    //Valida la existencia del codigo interno
                    if (Resultados == null)
                    {
                        Mensajes("Imposible continuar, código que entrega: " + txtcodEntrega.Text + " no existente.");
                        txtcodEntrega.Text = "";
                        txtcodEntrega.Focus();
                        return false;
                    }
                }//FIN A+B
            }//fin foreach



            if (string.IsNullOrWhiteSpace(txtCantcompra.Text))
            {
                Mensajes("Imposible continuar, es necesario proporcione la cantidad de compra.");
                txtCantcompra.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantentrega.Text))
            {
                Mensajes("Imposible continuar, es necesario proporcione la cantidad de entrega.");
                txtCantentrega.Focus();
                return false;
            }

            if (rcbLimPeriodo.SelectedValue == "")
            {
                Mensajes("Imposible continuar, es necesario seleccione un periodo.");
                rcbLimPeriodo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtlimcantidad.Text))
            {
                Mensajes("Imposible continuar, es necesario proporcione el límite de cantidad.");
                txtlimcantidad.Focus();
                return false;
            }

            if (rdpFSolicitud.SelectedDate == null)
            {
                Mensajes("Imposible continuar, es necesario proporcione la fecha solicitud.");
                rdpFSolicitud.Focus();
                return false;
            }

            if (rdpFIni.SelectedDate == null)
            {
                Mensajes("Imposible continuar, es necesario proporcione la fecha inicio.");
                rdpFIni.Focus();
                return false;
            }

            if (rdpFFin.SelectedDate == null)
            {
                Mensajes("Imposible continuar, es necesario proporcione la fecha fin.");
                rdpFFin.Focus();
                return false;
            }

            if (rdpFConteo.SelectedDate == null)
            {
                Mensajes("Imposible continuar, es necesario proporcione la fecha conteo.");
                rdpFConteo.Focus();
                return false;
            }

            //Fecha de extensión
            if (chkAplicaExt.Checked)
            {
                if (rdpFExt.SelectedDate == null)
                {
                    Mensajes("Imposible continuar, Selecciono activar extensión, es necesario proporcione la fecha extensión.");
                    rdpFExt.Focus();
                    return false;
                }
                DateTime fechaext;

                if (!DateTime.TryParse(rdpFExt.SelectedDate.ToString(), out fechaext))
                {
                    Mensajes("Imposible continuar, No es una fecha de extensión valida.");
                    rdpFExt.Clear();
                    rdpFExt.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtComentario.Text))
            {
                Mensajes("Imposible continuar, es necesario proporcione un comentario.");
                txtComentario.Focus();
                return false;
            }

            //===================================================================================================================
            int intResultado = 0;
            string strCodInt = "";
            string strFechaIni = "";
            string strFechaFin = "";
            TextBox txtcodInt = new TextBox();


            foreach (GridViewRow cell in grvProd.Rows)
            {
                txtcodInt = (cell.Cells[0].FindControl("txtcod") as TextBox);

                if (strCodInt == "")
                {
                    strCodInt = txtcodInt.Text;
                }
                else
                {
                    if (strCodInt.IndexOf(txtcodInt.Text) == -1)
                    {
                        strCodInt = strCodInt + "," + txtcodInt.Text;
                    }
                }
            }

            //Codigo de compra
            campos.CodigoInterno = strCodInt;
            strFechaIni = rdpFIni.SelectedDate.ToString().Substring(0, 10);
            strFechaIni = strFechaIni + " 00:00:00";
            campos.FechaInicio = strFechaIni;
            strFechaFin = rdpFFin.SelectedDate.ToString().Substring(0, 10);
            strFechaFin = strFechaFin + " 23:59:59";
            campos.FechaFin = strFechaFin;
            campos.IdTipoacumulacion = 1;

            //Valida que la mecanica no exista en ambiente de productivo (código de compra)
            intResultado = Ejecuta.ValidaPromocion(CnnProductivo, campos);
            if (intResultado == 0)
            {
                Mensajes("Imposible continuar,  porque ya existe alguna mecánica ligada en ambiente productivo.");
                grvProd.Focus();
                return false;
            }

            //Valida que la mecanica no exista en ambiente de pruebas (código de compra)
            intResultado = Ejecuta.ValidaPromocion(CnnPruebas, campos);
            if (intResultado == 0)
            {
                Mensajes("Imposible continuar,  porque ya existe alguna mecánica ligada en ambiente de pruebas.");
                grvProd.Focus();
                return false;
            }

            //====================================================================================================================================
            //Si se trata de un tipo de promoción tipo A+B valida el codigo interno que entrega.
            if (rcbTipoPromocion.Text == "A+B")
            {
                campos.CodigoInterno = txtcodEntrega.Text;
            }


            //Valida que la mecanica no exista en ambiente de productivo (código que entrega)
            intResultado = Ejecuta.ValidaPromocion(CnnProductivo, campos);
            if (intResultado == 0)
            {
                Mensajes("Imposible continuar,  porque ya existe alguna mecánica ligada en ambiente productivo, entregando el mismo producto.");
                grvProd.Focus();
                return false;
            }

            //Valida que la mecanica no exista en ambiente de pruebas (código que entrega)
            intResultado = Ejecuta.ValidaPromocion(CnnPruebas, campos);
            if (intResultado == 0)
            {
                Mensajes("Imposible continuar,  porque ya existe alguna mecánica ligada en ambiente de pruebas, entregando el mismo producto.");
                grvProd.Focus();
                return false;
            }
            //====================================================================================================================================

            return blnRespuesta;
        }
        private int ValidarDuplicados()
        {
            int intDuplicados = 0;
            DataTable DTRespDuplicados = new DataTable();

            if (grvProd.Rows.Count > 1 && rcbTipoPromocion.Text == "M&M")
            {
                DataTable dt1 = new DataTable();
                dt1 = EstructuraProductos();
                DataRow dr;
                //Recorre el contenido del grid y lo guarda en datatable
                foreach (GridViewRow row in this.grvProd.Rows)
                {
                    TextBox txtcodigo = (TextBox)row.FindControl("txtcod");
                    TextBox txtProd = (TextBox)row.FindControl("txtNomProd");
                    TextBox txtcodEnt = (TextBox)row.FindControl("txtcodEntrega");
                    Label lblIdLab = (Label)row.FindControl("lblIdLab");
                    TextBox txtCat = (TextBox)row.FindControl("txtCat");

                    RadComboBox cmbLab = (RadComboBox)row.FindControl("cmbLab");
                    dr = dt1.NewRow();
                    dr[0] = txtcodigo.Text.ToString();
                    dr[1] = txtProd.Text.ToString();
                    dr[2] = txtCat.Text;
                    dr[3] = cmbLab.SelectedValue;
                    dr[4] = txtcodEnt.Text.ToString();
                    dr[5] = cmbLab.SelectedValue;
                    dr[6] = txtCat.Text;

                    dt1.Rows.Add(dr);
                    ViewState["DataTemp"] = dt1;
                }

                //Valida si existen registros duplicados y devolvera un datatable con los registros unicos 
                DTRespDuplicados = ExistenDuplicados(dt1);
                //Se realiza una resta entre ambas tablas y el remanente es el numero de registros duplicados
                //dt1.Rows.Count ===> Todos los registros
                //DTRespDuplicados.Rows.Count ===> Registros unicos excluyendo duplicados
                intDuplicados = (dt1.Rows.Count - DTRespDuplicados.Rows.Count);
            }
            return intDuplicados;
        }
        private DataTable ExistenDuplicados(DataTable DT)
        {
            DataTable dtDistinct = new DataTable();

            string[] sColumnas = { "CodigoInterno", "Categoria", "NomProducto", "Laboratorio", "CodigoInternoEntrega" };
            //Devuelve registros unicos
            dtDistinct = DT.DefaultView.ToTable(true, sColumnas);
            //dtDistinct.Merge(DT, true);//Realiza unión entre dos tablas

            return dtDistinct;
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
        private void ValidaBeneficioDE()
        {
            if (rcbTipoPromocion.Text == "A+$" && !string.IsNullOrWhiteSpace(txtCantentrega.Text))
            {
                int DEmin = 0;
                int DEmax = 0;
                int intCantidadEntrega = 0;


                intCantidadEntrega = Convert.ToInt32(txtCantentrega.Text);
                Parametros prmRespuesta = new Parametros();

                prmRespuesta = prmEjecuta.ObtenerParametros("DEMin");
                DEmin = Convert.ToInt32(prmRespuesta.ValorPrm);
                prmRespuesta = prmEjecuta.ObtenerParametros("DEMax");
                DEmax = Convert.ToInt32(prmRespuesta.ValorPrm);

                if (intCantidadEntrega > DEmax || intCantidadEntrega < DEmin)
                {
                    Mensajes("El beneficio de dinero electrónico proporcionado no es valido, el valor mínimo permitido es de: " + DEmin + ", y el valor máximo permitido es de: " + DEmax);
                    txtCantentrega.Text = "";
                    txtCantentrega.Focus();
                }
            }
        }
        private void LimpiarControles()
        {
            DataTable DT = new DataTable();
            rcbSegmento.ClearSelection();
            rcbTipoPromocion.ClearSelection();

            DT = ResetGrid();
            ViewState["DataTemp"] = DT;
            grvProd.DataSource = ViewState["DataTemp"];
            grvProd.DataBind();
            txtCantcompra.Text = "";
            txtCantentrega.Text = "";
            rcbLimPeriodo.ClearSelection();
            txtlimcantidad.Text = "";
            rdpFSolicitud.SelectedDate = DateTime.Now.Date;
            rdpFIni.SelectedDate = null;
            rdpFFin.SelectedDate = null;
            rdpFConteo.SelectedDate = null;
            txtComentario.Text = "";
            lblNomProdADE.Visible = false;
            txtNomProdADE.Text = "";
            txtNomProdADE.Visible = false;
            lblNomProdMM.Visible = false;
            txtNomProdMM.Text = "";
            txtNomProdMM.Visible = false;
            btnAgregar.Visible = false;
            grvProd.Columns[5].Visible = false;
            chkVerWS.Checked = true;
        }
        private void LimpiarControlesSel()
        {
            DataTable DT = new DataTable();

            DT = ResetGrid();
            ViewState["DataTemp"] = DT;
            grvProd.DataSource = ViewState["DataTemp"];
            grvProd.DataBind();
            grvProd.Columns[5].Visible = false;

            foreach (GridViewRow row in this.grvProd.Rows)
            {
                TextBox txtCat = (TextBox)row.FindControl("txtCat");
                TextBox txtProd = (TextBox)row.FindControl("txtNomProd");
                TextBox txtcodEnt = (TextBox)row.FindControl("txtcodEntrega");

                if (rcbTipoPromocion.Text == "A+A" || rcbTipoPromocion.Text == "A+$")
                {
                    txtcodEnt.Enabled = false;
                }
                else
                {
                    txtcodEnt.Enabled = true;
                }
            }

            txtCantcompra.Text = "";
            txtCantentrega.Text = "";
            rcbLimPeriodo.ClearSelection();
            txtlimcantidad.Text = "";
            rdpFSolicitud.SelectedDate = DateTime.Now.Date;
            rdpFIni.SelectedDate = null;
            rdpFFin.SelectedDate = null;
            rdpFConteo.SelectedDate = null;
            txtComentario.Text = "";
            chkVerWS.Checked = true;
            chkAplicaExt.Checked = false;
            lblFext.Visible = false;
            rdpFExt.Clear();
            rdpFExt.Visible = false;

            if (rcbTipoPromocion.Text == "A+$")
            {
                lblNomProdADE.Visible = true;
                txtNomProdADE.Text = "";
                txtNomProdADE.Visible = true;
                lblNomProdMM.Visible = false;
                txtNomProdMM.Text = "";
                txtNomProdMM.Visible = false;
            }
            else if (rcbTipoPromocion.Text == "M&M")
            {
                lblNomProdMM.Visible = true;
                txtNomProdMM.Visible = true;
                txtNomProdMM.Text = "";
                lblNomProdADE.Visible = false;
                txtNomProdADE.Text = "";
                txtNomProdADE.Visible = false;
                grvProd.Columns[5].Visible = true;
            }
            else
            {
                lblNomProdADE.Visible = false;
                txtNomProdADE.Text = "";
                txtNomProdADE.Visible = false;
                lblNomProdMM.Visible = false;
                txtNomProdMM.Text = "";
                txtNomProdMM.Visible = false;
                btnAgregar.Visible = false;
                grvProd.Columns[5].Visible = false;
            }
        }
        private DataTable ResetGrid()
        {
            DataTable dt = null;
            dt = EstructuraProductos();
            DataRow dr;
            dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "";
            dr[2] = "";
            dr[3] = "";
            dr[4] = "";
            dr[5] = "";
            dr[6] = "";
            dt.Rows.Add(dr);

            return dt;
        }

        #region Admon de Laboratorios (Altas,consulta, modificación y eliminación)
        //=====================================================================================
        //INICIA 
        protected void btnAddLab_Click(object sender, EventArgs e)
        {
            CargaLaboratorios("");
            mvCatLab.SetActiveView(vAltaLab);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
        }

        protected void btnCancelarnvoLab_Click(object sender, EventArgs e)
        {
            //mvCatLab.SetActiveView(vBusquedaLab);
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
        }

        protected void btnGuardarnvoLab_Click(object sender, EventArgs e)
        {
            string strRespuesta = "";
            string strLaboratorio = "";
            List<ModLaboratorio> lstRespuesta = new List<ModLaboratorio>();
            try
            {
                if (string.IsNullOrWhiteSpace(txtNomLaboratorio.Text))
                {
                    Mensajes("Debe proporcionar un nombre de laboratorio...");
                    txtNomLaboratorio.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                    return;
                }

                AdministraPromocion Ejecuta = new AdministraPromocion();
                txtNomLaboratorio.Text = Limpiastring(txtNomLaboratorio.Text);
                strLaboratorio = PreparaStringValidaExistencia(txtNomLaboratorio.Text);
                lstRespuesta = Ejecuta.RegistraNvoLaboratorio(txtNomLaboratorio.Text, strLaboratorio);
                Session.Add("lstAltaLab", lstRespuesta);
                foreach (ModLaboratorio campo in lstRespuesta)
                {
                    strRespuesta = campo.mensaje;
                    break;
                }
                Mensajes(strRespuesta);
                ActualizaCombosLabGrig();


                if (strRespuesta == "El laboratorio que deseá agregar es posible que ya exista.")
                {
                    htitle.InnerText = "Coincidencias encontradas.";
                    txtLabForzar.Value = txtNomLaboratorio.Text;
                    if (lstRespuesta.Count > 0)
                    {
                        grvLaboratorios.DataSource = lstRespuesta;
                        grvLaboratorios.DataBind();
                    }
                    else
                    {
                        grvLaboratorios.DataSource = null;
                        grvLaboratorios.DataBind();
                    }

                    lblmsgForzar.Visible = true;
                    btnForzarAlta.Visible = true;
                    btnCancelarForzado.Visible = true;
                    mvCatLab.SetActiveView(vBusquedaLab);
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                }
                else
                {
                    lblmsgForzar.Visible = false;
                    btnForzarAlta.Visible = false;
                    btnCancelarForzado.Visible = false;

                    CargaLaboratorios("");
                    ActualizaCombosLabGrig();
                }


                txtNomLaboratorio.Text = "";
                txtNomLaboratorio.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnGuardar_Click", "Ejecuta.RegistraNvoLaboratorio(" + txtNomLaboratorio.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error interno, contacte al administrador.");
            }
        }

        protected void btnModificarLab_Click(object sender, EventArgs e)
        {
            int intIdlab = 0;
            string strRespuesta = "";
            try
            {
                if (string.IsNullOrWhiteSpace(txtEditLab.Text))
                {
                    Mensajes("Debe proporcionar un nombre de laboratorio...");
                    txtEditLab.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                    return;
                }

                intIdlab = Convert.ToInt32(IdLab.Value);
                AdministraPromocion Ejecuta = new AdministraPromocion();
                strRespuesta = Ejecuta.ModificarLaboratorio(intIdlab, txtEditLab.Text);
                CargaLaboratorios("");
                Mensajes(strRespuesta);
                txtEditLab.Text = "";
                txtEditLab.Focus();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnGuardar_Click", "Ejecuta.RegistraNvoLaboratorio(" + txtNomLaboratorio.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error interno, contacte al administrador.");
            }
        }

        protected void btnEditCancelar_Click(object sender, EventArgs e)
        {
            mvCatLab.SetActiveView(vBusquedaLab);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
        }

        protected void grvLaboratorios_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            CargaLaboratorios("");
            //List<ModLaboratorio> lstLab =  new List<ModLaboratorio>();
            //if (Session["lstAltaLab"] != null)
            //{
            //    lstLab = (List<ModLaboratorio>)Session["lstAltaLab"];
            //    if (lstLab.Count > 0)
            //    {
            //        grvLaboratorios.DataSource = (List<ModLaboratorio>)Session["lstAltaLab"];
            //        grvLaboratorios.DataBind();
            //    }
            //}
            //else {
            //    CargaLaboratorios("");
            //}
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
        }

        protected void grvLaboratorios_ItemCommand(object sender, GridCommandEventArgs e)
        {
            RadComboBox cmblab = new RadComboBox();
            GridDataItem item;
            switch (e.CommandName)
            {
                //case "EliminaLab":
                //    IdLab.Value = e.CommandArgument.ToString();
                //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowRegDelete();</script>", false);
                //    break;
                case "SelLab":
                    item = (GridDataItem)e.Item;

                    IdLab.Value = e.CommandArgument.ToString();
                    foreach (GridViewRow row in this.grvProd.Rows)
                    {
                        cmblab = (row.Cells[4].FindControl("cmbLab") as RadComboBox);
                    }
                    cmblab.SelectedValue = IdLab.Value;
                    //mvCatLab.SetActiveView(vEditaLab);
                    //txtEditLab.Text = item.Cells[4].Text;
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                    break;
            }
        }

        private void CargaLaboratorios(string strLaboratorio)
        {
            AdministraPromocion Ejecuta = new AdministraPromocion();
            List<ModLaboratorio> lstResultadosLab = new List<ModLaboratorio>();
            lstResultadosLab = Ejecuta.ReloadLaboratorios("ConnectionStringTest", strLaboratorio);

            if (lstResultadosLab.Count > 0)
            {
                grvLaboratorios.DataSource = lstResultadosLab;
                grvLaboratorios.DataBind();
            }
            else
            {
                grvLaboratorios.DataSource = null;
                grvLaboratorios.DataBind();
            }
        }

        private void ReloadLabFront()
        {
            Response.Redirect("AltaPromocion.aspx");
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Session["lstAltaLab"] != null)
            {
                Session.Contents.Remove("lstAltaLab");
                Session.Remove("lstAltaLab");
            }
            ReloadLabFront();
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            int Idlaboratorio = 0;
            string strRespuesta = "";

            try
            {
                AdministraPromocion Ejecuta = new AdministraPromocion();
                if (!string.IsNullOrWhiteSpace(IdLab.Value))
                {
                    Idlaboratorio = Convert.ToInt32(IdLab.Value);
                }
                strRespuesta = Ejecuta.EliminarLaboratorio(Idlaboratorio);
                Mensajes(strRespuesta);
                CargaLaboratorios("");
                mvCatLab.SetActiveView(vBusquedaLab);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnSi_Click", "Ejecuta.EliminarLaboratorio(" + Idlaboratorio + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error interno, contacte al administrador.");
            }
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            mvCatLab.SetActiveView(vBusquedaLab);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
        }

        private string Limpiastring(string strvalor)
        {
            string strResultado = "";
            string strCaracter1 = "";

            for (int i = 0; i <= (strvalor.Length - 1); i++)
            {
                switch (strvalor.Substring(i, 1))
                {
                    case "'":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case ",":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case ".":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "\\":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "@":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "|":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "#":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "?":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "&":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "<":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case ">":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case ";":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "*":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "=":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "{":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "}":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "!":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "¿":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "¡":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case ":":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "[":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "]":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "//":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "°":
                        strCaracter1 = strCaracter1 + "";
                        break;
                    case "á":
                        strCaracter1 = strCaracter1 + "a";
                        break;
                    case "é":
                        strCaracter1 = strCaracter1 + "e";
                        break;
                    case "í":
                        strCaracter1 = strCaracter1 + "i";
                        break;
                    case "ó":
                        strCaracter1 = strCaracter1 + "o";
                        break;
                    case "ú":
                        strCaracter1 = strCaracter1 + "u";
                        break;
                    case "Á":
                        strCaracter1 = strCaracter1 + "A";
                        break;
                    case "É":
                        strCaracter1 = strCaracter1 + "E";
                        break;
                    case "Í":
                        strCaracter1 = strCaracter1 + "I";
                        break;
                    case "Ó":
                        strCaracter1 = strCaracter1 + "O";
                        break;
                    case "Ú":
                        strCaracter1 = strCaracter1 + "U";
                        break;
                    default:
                        strCaracter1 = strCaracter1 + strvalor.Substring(i, 1).ToString();
                        break;
                }
            }
            strResultado = strCaracter1;

            return strResultado;
        }

        private string PreparaStringValidaExistencia(string strvalor)
        {
            string strRespuesta = "";
            string strCaracter1 = "";
            strvalor = strvalor.ToUpper();

            if (strvalor.IndexOf(" ") == -1)
            {
                return strvalor;
            }
            //Limpia cadena y reemplaza espacios por comas para delimitar cada palabra
            switch (strvalor.Substring(0, strvalor.IndexOf(" ")))
            {
                case "EL":
                    strCaracter1 = strvalor.Substring(3, strvalor.Length - 3);
                    strCaracter1 = strCaracter1.Replace(' ', ',');
                    strCaracter1 = strCaracter1.Replace(".", "");
                    strCaracter1 = strCaracter1.Trim();
                    break;
                case "LA":
                    strCaracter1 = strvalor.Substring(3, strvalor.Length - 3);
                    strCaracter1 = strCaracter1.Replace(' ', ',');
                    strCaracter1 = strCaracter1.Replace(".", "");
                    strCaracter1 = strCaracter1.Trim();
                    break;
                case "LOS":
                    strCaracter1 = strvalor.Substring(4, strvalor.Length - 4);
                    strCaracter1 = strCaracter1.Replace(' ', ',');
                    strCaracter1 = strCaracter1.Replace(".", "");
                    strCaracter1 = strCaracter1.Trim();
                    break;
                case "LAS":
                    strCaracter1 = strvalor.Substring(4, strvalor.Length - 4);
                    strCaracter1 = strCaracter1.Replace(' ', ',');
                    strCaracter1 = strCaracter1.Replace(".", "");
                    strCaracter1 = strCaracter1.Trim();
                    break;
                default:
                    strCaracter1 = strvalor.Replace(' ', ',');
                    strCaracter1 = strCaracter1.Replace(".", "");
                    strCaracter1 = strCaracter1.Trim();
                    break;
            }

            string[] strArrayLaboratorio;
            strArrayLaboratorio = strCaracter1.Split(',');
            strCaracter1 = "";
            //recorre el arreglo excuyendo palabras con una longitud menor e igual a 2 caracteres
            //y concatena las palabras a buscar delimitadas por una coma(,)
            foreach (string valores in strArrayLaboratorio)
            {
                if (string.IsNullOrWhiteSpace(strCaracter1))
                {
                    if (valores.Length > 2)
                    {
                        strCaracter1 = strCaracter1 + valores;
                    }
                }
                else
                {
                    if (valores.Length > 2)
                    {
                        strCaracter1 = strCaracter1 + "," + valores;
                    }
                }
            }
            strRespuesta = strCaracter1;

            return strRespuesta;
        }

        protected void btnForzarAlta_Click(object sender, EventArgs e)
        {
            string strRespuesta = "";
            AdministraPromocion Ejecuta = new AdministraPromocion();
            strRespuesta = Ejecuta.RegistraNvoLaboratorioForzar(txtLabForzar.Value);
            Session.Add("MensajeForzarAltaLab", strRespuesta);
            //Mensajes(strRespuesta);
            CargaLaboratorios("");
            Session.Contents.Remove("lstAltaLab");
            Session.Remove("lstAltaLab");
            btnCerrar_Click(null, null);
        }

        protected void btnCancelarForzado_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("lstAltaLab");
            Session.Remove("lstAltaLab");
            btnCerrar_Click(null, null);
        }

        private void ActualizaCombosLabGrig()
        {
            try
            {
                RadComboBoxItem elemento;
                foreach (GridViewRow cell in grvProd.Rows)
                {
                    RadComboBox cmb = (cell.Cells[0].FindControl("cmbLab") as RadComboBox);
                    Label lbl = (cell.Cells[0].FindControl("lblIdLab") as Label);

                    //Evita que realice la consulta si no encontro los objetos
                    //embebidos en el gridview
                    if (cmb != null && lbl != null)
                    {
                        AdministraPromocion Ejecuta = new AdministraPromocion();
                        List<ModLaboratorio> lstResultadosLab = new List<ModLaboratorio>();
                        lstResultadosLab = Ejecuta.ObtenLaboratorios(CnnPruebas);

                        if (lstResultadosLab != null)
                        {
                            if (lstResultadosLab.Count > 0)
                            {
                                foreach (ModLaboratorio itmlab in lstResultadosLab)
                                {
                                    //carga dropdownlist por cada registro
                                    elemento = new RadComboBoxItem(itmlab.Laboratorio, itmlab.IdLaboratorio.ToString());

                                    cmb.Items.Add(elemento);
                                    cmb.SelectedValue = itmlab.IdLaboratorio.ToString(); //asigna id del laboratorio al SelectValue
                                }
                                if (!string.IsNullOrWhiteSpace(lbl.Text))
                                {
                                    cmb.SelectedValue = lbl.Text;
                                }
                                else
                                {
                                    cmb.SelectedIndex = cmb.Items.Count;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatos", "grvProd_RowDataBound", "Ejecuta.ObtenLaboratorios()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
            }
        }

        private void SeteaLaboratoriosExistentes()
        {
            foreach (GridViewRow cell in grvProd.Rows)
            {
                RadComboBox cmblab = (cell.Cells[3].FindControl("cmbLab") as RadComboBox);
                Label lblIdLab = (cell.Cells[5].FindControl("lblIdLab") as Label);

                if (!string.IsNullOrWhiteSpace(lblIdLab.Text))
                {
                    cmblab.SelectedValue = lblIdLab.Text;
                    cmblab.Text = cmblab.Text;
                }
                else
                {
                    cmblab.SelectedIndex = -1;
                    cmblab.Text = "---Seleccione un laboratorio---";
                }

            }
        }

        //FIN
        //=====================================================================================
        #endregion
    }
}