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
    public partial class MuestraDatosAutDesAut : System.Web.UI.Page
    {
        public List<ModMecanica> lstRespuesta = new List<ModMecanica>();
        ModContenedorMecanicas Estructuras = new ModContenedorMecanicas();
        Clientes prmEjecuta = new Clientes();
        public static string CnnPruebas = "ConnectionStringTest";
        public static string CnnProductivo = "ConnectionStringProd";
        public int CuentaRegVacios = 0;
        DataTable dt = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaCombos();
                CargarInformacion();
            }
            ValidarAccion();
            foreach (GridViewRow cell in grvProd.Rows)
            {
                if (rcbTipoPromocion.Text == "A+A")
                {
                    //Iguala el código interno vs el código entrega
                    TextBox txtcod = (cell.Cells[0].FindControl("txtcod") as TextBox);
                    TextBox txtcodentrega = (cell.Cells[0].FindControl("txtcodEntrega") as TextBox);
                    //Al presionar tecla Enter, iguala el valor de codigo interno a Codigo entrega
                    txtcodentrega.Text = txtcod.Text;
                    txtcod.Attributes.Add("onkeypress", "cambiaFoco('txtcantcompra')");
                    txtcantcompra.Focus();
                }
                else
                {
                    //no igualara
                    TextBox txtcod = (cell.Cells[0].FindControl("txtcod") as TextBox);
                    //Al presionar tecla Enter, iguala el valor de codigo interno a Codigo entrega
                    txtcod.Attributes.Add("onkeypress", "cambiaFoco('txtcantcompra')");
                    txtcantcompra.Focus();
                }
            }

        }
        protected void rdpFechaPaseProd_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFechaPaseProd.SelectedDate.Value != null)
            {
                if (rdpFechaPaseProd.SelectedDate >= rdpFIni.SelectedDate)
                {
                    Mensajes("La fecha de autorización debe ser menor a la fecha inicio.");
                    rdpFechaPaseProd.Clear();
                    rdpFechaPaseProd.Focus();
                }
            }
        }
        protected void grvProd_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            RadComboBoxItem elemento;
            AdministraPromocion Ejecuta = new AdministraPromocion();
            RadComboBox cmbCat = new RadComboBox();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.DataItem != null)
                {
                    try
                    {
                        RadComboBox cmb = (e.Row.FindControl("cmbLab") as RadComboBox);
                        Label lbl = (e.Row.FindControl("lblIdLab") as Label);
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
                                    cmb.SelectedValue = lbl.Text; //se posiciona en el elemento registrado en db
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatos", "grvProd_RowDataBound", "Ejecuta.ObtenLaboratorios()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                        Mensajes("Ocurrio un error al intentar cargar Laboratorios, contacte al administrador");
                    }
                }
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
                    TextBox txtCat = (TextBox)row.FindControl("lblIdCat");

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
        protected void grvProd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvProd.PageIndex = e.NewPageIndex;
            CargarInformacion();
        }
        protected void txtcod_TextChanged(object sender, EventArgs e)
        {
            ModDatosGrid Resultados;
            AdministraPromocion Ejecuta = new AdministraPromocion();
            TextBox codInt = new TextBox();
            TextBox codIntEntrega = new TextBox();
            TextBox nomProd = new TextBox();
            TextBox cat = new TextBox();
            Label lblIdLab = new Label();
            RadComboBox cmbLab = new RadComboBox();

            codInt.Text = "";
            codIntEntrega.Text = "";

            try
            {
                foreach (GridViewRow row in this.grvProd.Rows)
                {
                    codInt = (row.Cells[0].FindControl("txtcod") as TextBox);
                    nomProd = (row.Cells[0].FindControl("txtNomProd") as TextBox);
                    nomProd.Enabled = false;
                    cat = (row.Cells[0].FindControl("lblIdCat") as TextBox);
                    cat.Enabled = false;
                    cmbLab = (row.Cells[0].FindControl("cmbLab") as RadComboBox);
                    if (string.IsNullOrWhiteSpace(cmbLab.Text))
                    {
                        cmbLab.Text = "---Seleccione un laboratorio---";
                        cmbLab.Enabled = true;
                    }
                    else
                    {
                        cmbLab.Enabled = true;
                    }

                    codIntEntrega = (row.Cells[0].FindControl("txtcodEntrega") as TextBox);
                    codIntEntrega.Enabled = false;
                    if (!string.IsNullOrWhiteSpace(codInt.Text))
                    {
                        //Consulta en ambiente productivo
                        Resultados = Ejecuta.ValidaExistenciaCodInterno(CnnPruebas, codInt.Text);
                        //Valida la existencia del codigo interno
                        if (Resultados != null)
                        {
                            if (string.IsNullOrWhiteSpace(Resultados.codigointerno))
                            {
                                Mensajes("Producto no existente.");
                                codInt.Text = "";
                                codInt.Focus();
                                return;
                            }
                            else
                            {
                                codIntEntrega = (row.Cells[0].FindControl("txtcodEntrega") as TextBox);
                                if (rcbTipoPromocion.Text == "A+A" || rcbTipoPromocion.Text == "M&M")
                                {
                                    codIntEntrega.Text = codInt.Text;
                                    btnAgregar.Enabled = true;
                                    btnAgregar.Visible = true;
                                    lblNomProdMM.Visible = true;
                                    txtNomProdMM.Visible = true;
                                    grvProd.Columns[5].Visible = true;

                                    //recorre grid para bloquear controles

                                }
                                else if (rcbTipoPromocion.Text == "A+B")
                                {
                                    codIntEntrega.Enabled = true;
                                }
                                else
                                {
                                    codIntEntrega.Text = codInt.Text;
                                    cat.Text = Resultados.Categoria_strID;
                                    codIntEntrega.Text = codIntEntrega.Text;
                                }

                                nomProd = (row.Cells[0].FindControl("txtNomProd") as TextBox);
                                nomProd.Text = Resultados.nombreProducto;
                                cat = (row.Cells[0].FindControl("lblIdCat") as TextBox);
                                cat.Text = Resultados.Categoria_strID.ToString();
                                lblIdLab = (row.Cells[0].FindControl("lblIdLab") as Label);
                                lblIdLab.Text = Resultados.id_laboratorio.ToString();
                                cmbLab = (row.Cells[0].FindControl("cmbLab") as RadComboBox);
                                cmbLab.SelectedValue = lblIdLab.Text;
                            }
                        }
                        else
                        {
                            Mensajes("Producto no existente: " + codInt.Text);
                            codInt.Text = "";
                            codInt.Focus();
                            return;
                        }
                    }
                    else
                    {
                        Mensajes("Es necesario proporcione un código interno.");
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
        protected void txtCantentrega_TextChanged(object sender, EventArgs e)
        {
            ValidaBeneficioDE();
        }
        protected void rcbSegmento_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
        protected void rcbTipoPromocion_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            MantenerSoloRegistro();
            ActivaControles(0);
            ValidaBeneficioDE();
        }
        protected void rcbCantCompra_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
        protected void rcbCantEntrega_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
        protected void rdpFIni_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFIni.SelectedDate.Value != null)
            {
                if (rdpFIni.SelectedDate <= DateTime.Now.Date)
                {
                    Mensajes("No es posible que sea menor e igual al fecha inicio a la fecha actual.");
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
                    Mensajes("No es posible que sea menor e igual la fecha fin a la fecha inicio.");
                    rdpFFin.Clear();
                    rdpFFin.Focus();
                }

                if (rdpFFin.SelectedDate != null)
                {
                    if (rdpFFin.SelectedDate.Value.Year > (DateTime.Now.Year + 2))
                    {
                        Mensajes("No es posible que sea mayor a dos años posteriores.");
                        rdpFFin.Clear();
                        rdpFFin.Focus();
                    }
                }

                //Verifica que no exista la mecanica dentro de la fechafin proporcionada
                int IdMecanica = 0;
                string codInterno = "";
                string strRespuesta = "";

                //IdMecanica = Convert.ToInt32(Request.QueryString["Idmec"]);

                foreach (GridViewRow reg in grvProd.Rows)
                {
                    TextBox codInt = (reg.Cells[0].FindControl("txtcod") as TextBox);
                    codInterno = codInt.Text;
                }

                AdministraPromocion ejecuta = new AdministraPromocion();
                IdMecanica = Convert.ToInt32(Request.QueryString["Idmec"]);
                string Ambiente = "Pruebas";

                strRespuesta = ejecuta.ValidarCodigoInterno(Ambiente, IdMecanica, codInterno, (DateTime)rdpFIni.SelectedDate, (DateTime)rdpFFin.SelectedDate);

                if (!string.IsNullOrWhiteSpace(strRespuesta))
                {
                    Mensajes(strRespuesta);
                    chkVerWS.Checked = true;
                    rdpFFin.Clear();
                    rdpFFin.Focus();
                    return;
                }
            }
        }
        protected void rdpFConteo_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFConteo.SelectedDate > rdpFIni.SelectedDate)
            {
                Mensajes("No es posible que la fecha conteo sea mayor a la fecha inicio.");
                rdpFConteo.Clear();
                rdpFConteo.Focus();
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
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Nuevoregistro("A");
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (btnModificar.Text == "Modificar")
            {
                ActivaControles(0);
                lblTitulo.Text = "Modificación de la Promoción";
                btnModificar.Text = "Guardar";
            }
            else
            {
                int intDuplicados = 0;

                //Valida productos duplicados en grid
                intDuplicados = ValidarDuplicados();
                if (intDuplicados == 0)
                {
                    if (Validaciones()) //Regla de Negocio
                    {
                        if (Modificar())
                        {
                            Mensajes("Los cambios fueron registrados correctamente.");
                            BloqueaControles();
                            lblTitulo.Text = "Información de la Promoción";
                            btnModificar.Text = "Modificar";
                        }
                        else
                        {
                            Mensajes("No fue posible registrar sus cambios, contacte al administrador del sistema.");
                            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "RegresarPagina();", true);
                        }
                    }
                }
                else
                {
                    Mensajes("Imposible continuar, existen " + intDuplicados + " producto(s) duplicado(s).");
                }
            }
        }
        protected void btnCanela_Click(object sender, EventArgs e)
        {
            btnCancelar_Click(null, null);
        }
        protected void btnAutDesAut_Click(object sender, EventArgs e)
        {
            if (lblEstatus.Text == "Por Aprobar")
            {
                btnAutDesAut.Text = "Autorizar";
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
                    BloqueaControles();
                    btnAutDesAut.Text = "Autorizar";
                    btnAutDesAut.Width = 100;
                }
                else
                {
                    Mensajes("No fue posible realizar sus cambios, contacte al administrador del sistema...");
                    BloqueaControles();
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
                                    lblEstatus.Text = DSResultados.Tables[0].Rows[0][7].ToString();
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
                        BloqueaControles();
                        //lblTitulo.Text = "Información de la Promoción";
                        btnAutDesAut.Text = "Autorizar";
                        btnAutDesAut.Width = 100;
                    }
                }
                else
                {
                    Mensajes("No fue posible realizar sus cambios, contacte al administrador del sistema...");
                    BloqueaControles();
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
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaPromPendxAutDesAut.aspx");
        }

        private void CargarInformacion()
        {
            int IdMecanica = 0;
            int TipoAcumulacion = 0;
            Label lbl = new Label();
            RadComboBox cmbLab;
            TextBox codentrega = new TextBox();
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

                AdministraPromocion Ejecuta = new AdministraPromocion();
                Estructuras = Ejecuta.CargaDetalleMecanica(CnnPruebas, IdMecanica, TipoAcumulacion);
                lstRespuesta = Estructuras.lstMecanica;

                if (lstRespuesta.Count > 0)
                {
                    //Alimenta tabla 
                    foreach (ModMecanica campos in lstRespuesta)
                    {
                        DataRow dr;
                        dt = EstructuraProductos();

                        dr = dt.NewRow();
                        dr[0] = lstRespuesta[0].CodigoInterno;
                        dr[1] = lstRespuesta[0].NomProducto;
                        dr[2] = lstRespuesta[0].Categoria;
                        dr[3] = lstRespuesta[0].Laboratorio;
                        dr[4] = lstRespuesta[0].CodigoInternoEntrega;
                        dr[5] = lstRespuesta[0].Idlaboratorio;
                        dr[6] = lstRespuesta[0].Categoria;
                        dt.Rows.Add(dr);
                        ViewState["DataTemp"] = dt;
                    }

                    grvProd.DataSource = lstRespuesta;
                    grvProd.DataBind();
                    //Setear campos
                    foreach (ModMecanica campos in lstRespuesta)
                    {
                        rcbSegmento.SelectedValue = campos.IdSegmento.ToString();
                        rcbTipoPromocion.SelectedValue = campos.IdtipoPromocion.ToString();

                        if (rcbTipoPromocion.Text == "M&M")
                        {
                            txtNomProdMM.Text = campos.NombreMecanica;
                        }

                        if (campos.FechaIni.ToString() != "01/01/0001 12:00:00 a. m.")
                        {
                            rdpFIni.SelectedDate = campos.FechaIni;
                        }
                        if (campos.FechaFin.ToString() != "01/01/0001 12:00:00 a. m.")
                        {
                            rdpFFin.SelectedDate = campos.FechaFin;
                        }
                        if (campos.FechaConteo.ToString() != "01/01/0001 12:00:00 a. m.")
                        {
                            rdpFConteo.SelectedDate = campos.FechaConteo;
                        }
                        if (campos.falgFechaExt == 1)
                        {
                            chkAplicaExt.Checked = true;
                            lblFext.Visible = true;
                            rdpFExt.SelectedDate = campos.FechaExtencion;
                            pnlExtencion.Visible = true;
                        }
                        else
                        {
                            chkAplicaExt.Visible = true;
                            chkAplicaExt.Enabled = false;
                            lblFext.Visible = false;
                            rdpFExt.Clear();
                            rdpFExt.Visible = false;
                            pnlExtencion.Visible = true;
                        }

                        if (campos.EstatusPaseProd == 2)
                        {
                            lblPase.Visible = true;
                            lblFechaPase.Text = campos.FechaPaseProduccion.Substring(0, 10);
                            lblFechaPase.Visible = true;
                        }
                        else
                        {
                            lblPase.Visible = false;
                            lblFechaPase.Visible = false;
                        }
                        rcbLimPeriodo.SelectedValue = campos.IdPreiodoLimite.ToString();
                        txtcantcompra.Text = campos.CantidadCompra.ToString();
                        txtCantentrega.Text = campos.CantidadEntrega.ToString();
                        txtlimcantidad.Text = campos.Limite.ToString();
                        chkVerWS.Checked = campos.VerenReporte;
                        if (campos.CierreCiclosSugeridos == 0)
                        {
                            rdbEntregaSugeridosCierre.Checked = true;
                            rdbEntregaSugeridos.Checked = false;
                        }
                        else
                        {
                            rdbEntregaSugeridos.Checked = true;
                            rdbEntregaSugeridosCierre.Checked = false;

                        }
                    }
                    grvComentarios.DataSource = Estructuras.DTComentarios;
                    grvComentarios.DataBind();
                }
                else
                {
                    Mensajes("No se encontrarón resultados.");
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatos", "CargaInformacion()", "Ejecuta.CargaDetalleMecanica(" + IdMecanica + "," + TipoAcumulacion + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar información, contacte al administrador");
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
                TipoAcum = Convert.ToInt32(Request.QueryString["TipoAc"]);

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
                Mensajes("Ocurrio un error al intentar cargar TipoPromocion, contacte al administrador");
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
        private DataTable EstructuraProductos()
        {
            DataTable medidaTabla = new DataTable();
            medidaTabla.Columns.Add("CodigoInterno", typeof(string));
            medidaTabla.Columns.Add("NomProducto", typeof(string));
            medidaTabla.Columns.Add("Categoria", typeof(string));
            medidaTabla.Columns.Add("Laboratorio", typeof(string));
            medidaTabla.Columns.Add("CodigoInternoEntrega", typeof(string));
            medidaTabla.Columns.Add("IdLaboratorio", typeof(string));
            medidaTabla.Columns.Add("IdCat", typeof(string));
            return medidaTabla;
        }
        private void Nuevoregistro(string tipo)
        {
            DataRow dr;
            dt = EstructuraProductos();

            if (CuentaRegVacios == 0)
            {

                foreach (GridViewRow row in this.grvProd.Rows)
                {
                    TextBox txtcodigo = (TextBox)row.FindControl("txtcod");
                    TextBox txtProd = (TextBox)row.FindControl("txtNomProd");
                    TextBox txtcodEnt = (TextBox)row.FindControl("txtcodEntrega");

                    TextBox lblIdCat = (TextBox)row.FindControl("lblIdCat");
                    Label lblIdLab = (Label)row.FindControl("lblIdLab");

                    RadComboBox cmbLab = (RadComboBox)row.FindControl("cmbLab");

                    dr = dt.NewRow();
                    dr[0] = txtcodigo.Text.ToString();
                    dr[1] = txtProd.Text.ToString();
                    dr[2] = lblIdCat.Text;
                    dr[3] = cmbLab.SelectedValue;
                    dr[4] = txtcodEnt.Text.ToString();
                    dr[5] = cmbLab.SelectedValue;
                    dr[6] = lblIdCat.Text;

                    dt.Rows.Add(dr);
                    ViewState["DataTemp"] = dt;

                    if (string.IsNullOrWhiteSpace(txtcodigo.Text.ToString()) ||
                    string.IsNullOrWhiteSpace(txtProd.Text.ToString()) ||
                        //string.IsNullOrWhiteSpace(cmbLab.SelectedValue) ||
                    string.IsNullOrWhiteSpace(txtcodEnt.Text.ToString())) //||
                    //string.IsNullOrWhiteSpace(cmbLab.SelectedValue))
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
            ActivaControles(1);
        }
        private void ValidarAccion()
        {
            if (lblEstatus.Text == "Aprobado")
            {
                btnAutDesAut.Text = "Cancela autorización";
                btnAutDesAut.Width = 200;
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
        private bool Modificar()
        {
            bool blnRespuesta = false;
            string strFechaIni = "";
            string strFechaExt = "";
            string strFechaFin = "";
            string strFechaConteo = "";
            string strCodInt = "";

            //Promociones Iniciadas diferentes a M&M
            if (Request.QueryString["Est"] == "Iniciada" && rcbTipoPromocion.Text != "M&M")
            {
                ModPromociones Campos = new ModPromociones();
                try
                {
                    Campos.IdMecanica = Convert.ToInt32(Request.QueryString["Idmec"]);
                    foreach (GridViewRow reg in grvProd.Rows)
                    {
                        TextBox codInt = (reg.Cells[0].FindControl("txtcod") as TextBox);
                        TextBox nomProd = (reg.Cells[1].FindControl("txtNomProd") as TextBox);
                        Campos.CodigoInterno = codInt.Text;
                        Campos.NombrePromocion = nomProd.Text;
                    }

                    Campos.IdPeriodo = Convert.ToInt32(rcbLimPeriodo.SelectedValue);
                    Campos.Limite = (string.IsNullOrWhiteSpace(txtlimcantidad.Text) ? 0 : Convert.ToInt32(txtlimcantidad.Text));
                    strFechaFin = rdpFFin.SelectedDate.ToString();
                    strFechaFin = strFechaFin.Substring(0, 10) + " 23:59:59";

                    Campos.FechaFin = strFechaFin;


                    if (chkAplicaExt.Checked)
                    {
                        strFechaExt = rdpFExt.SelectedDate.ToString();
                        strFechaExt = strFechaExt.Substring(0, 10) + " 23:59:59";
                        Campos.FechaExtencion = strFechaExt;
                        Campos.flagExtencion = 1;
                    }
                    else
                    {
                        Campos.FechaExtencion = null; //se pasa esta fecha aunque no sera considerada
                        Campos.flagExtencion = 0;
                    }

                    if (chkVerWS.Checked)
                    {
                        Campos.VerEnReporte = 1;
                    }
                    else
                    {
                        Campos.VerEnReporte = 0;
                    }

                    Campos.Comentarios = txtComentario.Text;
                    if (rdbEntregaSugeridosCierre.Checked)
                    {
                        //Entregar sugeridos y permitir cerrar los ciclos que se encuentren abiertos
                        Campos.CierreCiclosSugeridos = 0;
                    }
                    else if (rdbEntregaSugeridos.Checked)
                    {
                        //Entregar sólo sugeridos 
                        Campos.CierreCiclosSugeridos = 1;
                    }


                    Campos.Usuario = HttpContext.Current.User.Identity.Name;

                    AdministraPromocion Ejecuta = new AdministraPromocion();
                    //*******************************************************************************************************
                    //Realiza el guardado general
                    blnRespuesta = Ejecuta.ModificaPromociones(CnnPruebas, Campos);
                    //*******************************************************************************************************

                    //Realiza el guardado solo de los elementos del grid para asociar los laboratorios 
                    List<ModGuardaDatosGrid> lstGrid = new List<ModGuardaDatosGrid>();
                    foreach (GridViewRow itm in grvProd.Rows)
                    {
                        TextBox txtcodInt = (itm.Cells[0].FindControl("txtcod") as TextBox);
                        RadComboBox cmbLab = (itm.Cells[3].FindControl("cmbLab") as RadComboBox);

                        ModGuardaDatosGrid registros = new ModGuardaDatosGrid();
                        registros.id_mecanica = Convert.ToInt32(Request.QueryString["Idmec"]);
                        registros.codigointerno = txtcodInt.Text;
                        registros.id_tipoAcumulacion = Convert.ToInt32(Request.QueryString["TipoAc"]);
                        registros.id_laboratorio = cmbLab.SelectedValue;
                        registros.comentarios = txtComentario.Text;
                        registros.usuario = Campos.Usuario;

                        blnRespuesta = Ejecuta.ModificaListaPromociones(CnnPruebas, registros);
                    }
                    //*******************************************************************************************************
                    //Campos.CodigoInterno=  //Implementar busqueda de equivalencias
                    //blnRespuesta = Ejecuta.ModificaPromociones(CnnPruebas, Campos);
                    //*******************************************************************************************************
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatos", "Modificar()", "Ejecuta.ModificaPromociones(" + Campos + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error al intentar guardar promociones iniciadas diferentes a M&M, contacte al administrador");
                }
            }
            else if (Request.QueryString["Est"] != "Iniciada" && rcbTipoPromocion.Text != "M&M")
            {
                //Promociones No Iniciadas diferentes a M&M
                int tipoAc = 0;
                ModPromocionesNoIniciadas Campos = new ModPromocionesNoIniciadas();
                AdministraPromocion Ejec = new AdministraPromocion();
                try
                {
                    Campos.IdMecanica = Convert.ToInt32(Request.QueryString["Idmec"]);
                    tipoAc = Convert.ToInt32(Request.QueryString["TipoAc"]);
                    Estructuras = Ejec.CargaDetalleMecanica(CnnPruebas, Campos.IdMecanica, tipoAc);
                    lstRespuesta = Estructuras.lstMecanica;

                    foreach (GridViewRow reg in grvProd.Rows)
                    {
                        TextBox codInt = (reg.Cells[0].FindControl("txtcod") as TextBox);
                        TextBox nomProd = (reg.Cells[1].FindControl("txtNomProd") as TextBox);
                        TextBox codIntEnt = (reg.Cells[4].FindControl("txtcodEntrega") as TextBox);

                        foreach (ModMecanica campos in lstRespuesta)
                        {
                            //Asigna IdSegmento segun la db
                            rcbSegmento.SelectedValue = campos.IdSegmento.ToString();
                        }

                        //Compara si cambio de codigo interno
                        if (lstRespuesta.Where(w => w.CodigoInterno == codInt.Text).Count() == 0)
                        {
                            //Cambio y se iguala ambos codigos
                            Campos.CodigoInterno = codInt.Text;
                            Campos.CodigoInternoEntrega = codInt.Text;
                            Campos.IdTipoPromocion = Convert.ToInt32(rcbTipoPromocion.SelectedValue);
                        }//Compara si cambio de codigo internoentrega
                        else if (lstRespuesta.Where(w => w.CodigoInternoEntrega == codIntEnt.Text).Count() == 0)
                        {
                            //Cambio y tipopromocion cambia por A+B
                            Campos.CodigoInterno = codInt.Text;
                            Campos.CodigoInternoEntrega = codIntEnt.Text;
                            Campos.IdTipoPromocion = 2; //Mecaniza A+B
                        }
                        else
                        {//Mantiene los valores de la dbase
                            Campos.CodigoInterno = codInt.Text;
                            Campos.CodigoInternoEntrega = codIntEnt.Text;
                            Campos.IdTipoPromocion = Convert.ToInt32(rcbTipoPromocion.SelectedValue);
                        }
                        Campos.NombrePromocion = txtcantcompra.Text + "+" + txtCantentrega.Text + " " + nomProd.Text;
                    }
                    Campos.IdTipoAcumulacion = Convert.ToInt32(Request.QueryString["TipoAC"]);
                    Campos.IdSegmento = Convert.ToInt32(rcbSegmento.SelectedValue);
                    Campos.IdPeriodo = Convert.ToInt32(rcbLimPeriodo.SelectedValue);
                    Campos.Limite = (string.IsNullOrWhiteSpace(txtlimcantidad.Text) ? 0 : Convert.ToInt32(txtlimcantidad.Text));

                    strFechaIni = rdpFIni.SelectedDate.ToString();
                    strFechaIni = strFechaIni.Substring(0, 10) + " 00:00:00";
                    strFechaConteo = rdpFConteo.SelectedDate.ToString();
                    strFechaConteo = strFechaConteo.Substring(0, 10) + " 00:00:00";

                    Campos.FechaInicio = strFechaIni;
                    strFechaFin = rdpFFin.SelectedDate.ToString();
                    strFechaFin = strFechaFin.Substring(0, 10) + " 23:59:59";
                    //FechaFin = Convert.ToDateTime(strFechaFin);

                    Campos.FechaFin = strFechaFin;
                    Campos.FechaConteo = strFechaConteo;
                    Campos.Comentarios = txtComentario.Text;
                    Campos.Usuario = HttpContext.Current.User.Identity.Name;
                    Campos.CantidadCompra = (string.IsNullOrWhiteSpace(txtcantcompra.Text) ? 0 : Convert.ToInt32(txtcantcompra.Text));
                    Campos.CantidadEntrega = (string.IsNullOrWhiteSpace(txtCantentrega.Text) ? 0 : Convert.ToInt32(txtCantentrega.Text));

                    if (chkVerWS.Checked)
                    {
                        Campos.VerEnReporte = 1;
                    }
                    else
                    {
                        Campos.VerEnReporte = 0;
                    }

                    if (chkAplicaExt.Checked)
                    {
                        strFechaExt = rdpFExt.SelectedDate.ToString();
                        strFechaExt = strFechaExt.Substring(0, 10) + " 23:59:59";
                        Campos.FechaExtension = strFechaExt;
                        Campos.flagExtension = 1;
                    }
                    else
                    {
                        strFechaExt = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + " 00:00:00";
                        Campos.FechaExtension = strFechaExt; //se pasa esta fecha aunque no sera considerada
                        Campos.flagExtension = 0;
                    }


                    if (rdbEntregaSugeridosCierre.Checked)
                    {
                        //Entregar sugeridos y permitir cerrar los ciclos que se encuentren abiertos
                        Campos.CierreCiclosSugeridos = 0;
                    }
                    else if (rdbEntregaSugeridos.Checked)
                    {
                        //Entregar sólo sugeridos 
                        Campos.CierreCiclosSugeridos = 1;
                    }

                    grvComentarios.DataSource = Estructuras.DTComentarios;
                    grvComentarios.DataBind();


                    AdministraPromocion Ejecuta = new AdministraPromocion();
                    //====================================================================================================================================
                    //Si se trata de un tipo de promoción tipo A+B valida el codigo interno que entrega.
                    int intResultado = 0;
                    if (rcbTipoPromocion.Text == "A+B")
                    {
                        ModValidaPromocion camp = new ModValidaPromocion();
                        camp.CodigoInterno = Campos.CodigoInternoEntrega;
                        camp.FechaInicio = Campos.FechaInicio;
                        camp.FechaFin = Campos.FechaFin;
                        camp.IdTipoacumulacion = Campos.IdTipoAcumulacion;

                        //Valida que la mecanica no exista en ambiente de productivo (código que entrega)
                        intResultado = Ejecuta.ValidaPromocion(CnnProductivo, camp);
                        if (intResultado == 0)
                        {
                            Mensajes("Imposible continuar,  porque ya existe alguna mecánica ligada en ambiente productivo, entregando el mismo producto. (" + Campos.CodigoInternoEntrega + ")");
                            grvProd.Focus();
                            return false;
                        }

                        //Valida que la mecanica no exista en ambiente de pruebas (código que entrega)
                        intResultado = Ejecuta.ValidaPromocion(CnnPruebas, camp);
                        if (intResultado == 0)
                        {
                            Mensajes("Imposible continuar,  porque ya existe alguna mecánica ligada en ambiente de pruebas, entregando el mismo producto. (" + Campos.CodigoInternoEntrega + ")");
                            grvProd.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        //A+A 
                        ModValidaPromocion camp = new ModValidaPromocion();
                        camp.CodigoInterno = Campos.CodigoInterno;
                        camp.FechaInicio = Campos.FechaInicio;
                        camp.FechaFin = Campos.FechaFin;
                        camp.IdTipoacumulacion = Campos.IdTipoAcumulacion;

                        //Valida que la mecanica no exista en ambiente de productivo (código que entrega)
                        intResultado = Ejecuta.ValidaPromocion(CnnProductivo, camp);
                        if (intResultado == 0)
                        {
                            Mensajes("Imposible continuar,  porque ya existe alguna mecánica ligada en ambiente productivo.");
                            grvProd.Focus();
                            return false;
                        }

                        //Valida que la mecanica no exista en ambiente de pruebas (código que entrega)
                        intResultado = Ejecuta.ValidaPromocion(CnnPruebas, camp);
                        if (intResultado == 0)
                        {
                            Mensajes("Imposible continuar,  porque ya existe alguna mecánica ligada en ambiente de pruebas.");
                            grvProd.Focus();
                            return false;
                        }
                    }
                    //====================================================================================================================================


                    //Realiza el guardado general
                    blnRespuesta = Ejecuta.ModificaPromocionesNoIniciadas(CnnPruebas, Campos, "sp_Promocion_ProduccionAcumulacion_NoIniciada_Update_pruebas");

                    //Realiza el guardado solo de los elementos del grid para asociar los laboratorios 
                    List<ModGuardaDatosGrid> lstGrid = new List<ModGuardaDatosGrid>();
                    foreach (GridViewRow itm in grvProd.Rows)
                    {
                        TextBox txtcodInt = (itm.Cells[0].FindControl("txtcod") as TextBox);
                        RadComboBox cmbLab = (itm.Cells[3].FindControl("cmbLab") as RadComboBox);

                        ModGuardaDatosGrid registros = new ModGuardaDatosGrid();
                        registros.id_mecanica = Convert.ToInt32(Request.QueryString["Idmec"]);
                        registros.codigointerno = txtcodInt.Text;
                        registros.id_tipoAcumulacion = Convert.ToInt32(Request.QueryString["TipoAc"]);
                        registros.id_laboratorio = cmbLab.SelectedValue;
                        registros.comentarios = txtComentario.Text;
                        registros.usuario = Campos.Usuario;

                        blnRespuesta = Ejecuta.ModificaListaPromociones(CnnPruebas, registros);
                    }
                    //*******************************************************************************************************
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatos", "Modificar()", "Ejecuta.ModificaPromocionesNoIniciadas(" + Campos + ", sp_Promocion_ProduccionAcumulacion_NoIniciada_Update_pruebas)", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error al intentar guardar promociones no iniciadas diferentes a M&M, contacte al administrador");
                }
            }
            else if (Request.QueryString["Est"] != "Iniciada" && rcbTipoPromocion.Text == "M&M" || Request.QueryString["Est"] == "Iniciada" && rcbTipoPromocion.Text == "M&M")
            {
                //Promociones No Iniciadas Mix & Match
                ModPromocionesNoIniciadas Campos = new ModPromocionesNoIniciadas();
                try
                {

                    foreach (GridViewRow reg in grvProd.Rows)
                    {
                        TextBox txtcodInt = (reg.Cells[0].FindControl("txtcod") as TextBox);
                        RadComboBox cmbLab = (reg.Cells[3].FindControl("cmbLab") as RadComboBox);

                        //*****************************************************************************
                        //Se arma cadena de codigos internos
                        TextBox codInt = (reg.Cells[0].FindControl("txtcod") as TextBox);
                        //Se concatenan Codigos Internos delimitados por ","
                        if (strCodInt == "")
                        {
                            strCodInt = codInt.Text;
                        }
                        else
                        {
                            if (strCodInt.IndexOf(codInt.Text + ",") == -1)
                            {
                                strCodInt = strCodInt + "," + codInt.Text;
                            }
                        }
                    }
                    Campos.CodigoInterno = strCodInt;
                    Campos.NombrePromocion = txtNomProdMM.Text;
                    Campos.IdMecanica = Convert.ToInt32(Request.QueryString["Idmec"]);
                    Campos.IdTipoAcumulacion = Convert.ToInt32(Request.QueryString["TipoAC"]);
                    Campos.IdSegmento = Convert.ToInt32(rcbSegmento.SelectedValue);
                    Campos.IdTipoPromocion = Convert.ToInt32(rcbTipoPromocion.SelectedValue);
                    Campos.IdPeriodo = Convert.ToInt32(rcbLimPeriodo.SelectedValue);
                    Campos.Limite = (string.IsNullOrWhiteSpace(txtlimcantidad.Text) ? 0 : Convert.ToInt32(txtlimcantidad.Text));

                    strFechaIni = rdpFIni.SelectedDate.ToString();
                    strFechaIni = strFechaIni.Substring(0, 10) + " 00:00:00";
                    strFechaConteo = rdpFConteo.SelectedDate.ToString();
                    strFechaConteo = strFechaConteo.Substring(0, 10) + " 00:00:00";

                    Campos.FechaInicio = strFechaIni;
                    strFechaFin = rdpFFin.SelectedDate.ToString();
                    strFechaFin = strFechaFin.Substring(0, 10) + " 23:59:59";
                    //FechaFin = Convert.ToDateTime(strFechaFin);

                    Campos.FechaFin = strFechaFin;
                    Campos.FechaConteo = strFechaConteo;
                    Campos.Comentarios = txtComentario.Text;
                    Campos.Usuario = HttpContext.Current.User.Identity.Name;
                    Campos.CantidadCompra = (string.IsNullOrWhiteSpace(txtcantcompra.Text) ? 0 : Convert.ToInt32(txtcantcompra.Text));
                    Campos.CantidadEntrega = (string.IsNullOrWhiteSpace(txtCantentrega.Text) ? 0 : Convert.ToInt32(txtCantentrega.Text));
                    if (chkAplicaExt.Checked)
                    {
                        strFechaExt = rdpFExt.SelectedDate.ToString();
                        strFechaExt = strFechaExt.Substring(0, 10) + " 23:59:59";
                        Campos.FechaExtension = strFechaExt;
                        Campos.flagExtension = 1;
                    }
                    else
                    {
                        strFechaExt = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + " 00:00:00";
                        Campos.FechaExtension = strFechaExt; //se pasa esta fecha aunque no sera considerada
                        Campos.flagExtension = 0;
                    }


                    if (rdbEntregaSugeridosCierre.Checked)
                    {
                        //Entregar sugeridos y permitir cerrar los ciclos que se encuentren abiertos
                        Campos.CierreCiclosSugeridos = 0;
                    }
                    else if (rdbEntregaSugeridos.Checked)
                    {
                        //Entregar sólo sugeridos 
                        Campos.CierreCiclosSugeridos = 1;
                    }


                    AdministraPromocion Ejecuta = new AdministraPromocion();

                    //Realiza el guardado general
                    blnRespuesta = Ejecuta.ModificaPromocionesNoIniciadas(CnnPruebas, Campos, "sp_Promocion_ProduccionAcumulacionListas_NoIniciada_Update");
                    //=========================================================================================================================================
                    //Realiza el guardado solo de los elementos del grid para asociar los laboratorios 
                    //antes de realizar el guardado general
                    List<ModGuardaDatosGrid> lstGrid = new List<ModGuardaDatosGrid>();
                    foreach (GridViewRow itm in grvProd.Rows)
                    {
                        TextBox txtcodInt = (itm.Cells[0].FindControl("txtcod") as TextBox);
                        RadComboBox cmbLab = (itm.Cells[3].FindControl("cmbLab") as RadComboBox);

                        //*****************************************************************************
                        //Se arma cadena de codigos internos
                        TextBox codInt = (itm.Cells[0].FindControl("txtcod") as TextBox);
                        //TextBox nomProd = (itm.Cells[0].FindControl("txtNomProd") as TextBox);
                        //Se concatenan Codigos Internos delimitados por ","
                        if (strCodInt == "")
                        {
                            strCodInt = codInt.Text;
                        }
                        else
                        {
                            if (strCodInt.IndexOf(codInt.Text + ",") == -1)
                            {
                                strCodInt = strCodInt + "," + codInt.Text;
                            }
                        }
                        Campos.CodigoInterno = strCodInt;
                        Campos.NombrePromocion = txtNomProdMM.Text; //Nombre descriptivo solo M&M
                        //*****************************************************************************

                        ModGuardaDatosGrid registros = new ModGuardaDatosGrid();
                        registros.id_mecanica = Convert.ToInt32(Request.QueryString["Idmec"]);
                        registros.codigointerno = txtcodInt.Text;
                        registros.id_tipoAcumulacion = Convert.ToInt32(Request.QueryString["TipoAc"]);
                        registros.id_laboratorio = cmbLab.SelectedValue;
                        registros.comentarios = txtComentario.Text;
                        registros.usuario = Campos.Usuario;



                        blnRespuesta = Ejecuta.ModificaListaPromociones(CnnPruebas, registros);
                    }
                    //=========================================================================================================================================
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatos", "Modificar()", "Ejecuta.ModificaPromocionesNoIniciadas(" + Campos + ", sp_Promocion_ProduccionAcumulacionListas_NoIniciada_Update)", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error al intentar guardar promociones no iniciadas Mix & Match, contacte al administrador");
                }
            }

            return blnRespuesta;
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
        private void ActivaControles(int nvoitm)
        {
            BloqueaControles();
            rdpFechaPaseProd.Enabled = true;
            //Activa todo
            rcbSegmento.Enabled = true;
            rcbTipoPromocion.Enabled = true;
            txtcantcompra.Enabled = true;
            txtCantentrega.Enabled = true;
            rdpFIni.Enabled = true;
            rdpFFin.Enabled = true;
            rdpFConteo.Enabled = true;
            rcbLimPeriodo.Enabled = true;
            txtlimcantidad.Enabled = true;
            txtComentario.Enabled = true;

            chkAplicaExt.Visible = true;
            chkAplicaExt.Enabled = true;
            rdpFExt.Enabled = true;
            grvProd.Enabled = true;
            chkVerWS.Enabled = true;
            rdbEntregaSugeridosCierre.Enabled = true;
            rdbEntregaSugeridos.Enabled = true;

            if (rcbTipoPromocion.Text == "M&M")
            {
                btnAgregar.Enabled = true;
                btnAgregar.Visible = true;
                lblNomProdMM.Visible = true;
                txtNomProdMM.Visible = true;
                grvProd.Columns[5].Visible = true;

                //recorre grid para bloquear controles
                foreach (GridViewRow cell in grvProd.Rows)
                {
                    TextBox txtProd = (cell.Cells[0].FindControl("txtNomProd") as TextBox);
                    txtProd.Enabled = false;
                    TextBox txtcat = (cell.Cells[0].FindControl("lblIdCat") as TextBox);
                    txtcat.Enabled = false;
                    RadComboBox cmbLab = (cell.Cells[0].FindControl("cmbLab") as RadComboBox);
                    if (string.IsNullOrWhiteSpace(cmbLab.Text))
                    {
                        cmbLab.Text = "---Seleccione un laboratorio---";
                        cmbLab.Enabled = true;
                    }
                    else
                    {
                        cmbLab.Enabled = true;
                    }

                    TextBox txtcodEntrega = (cell.Cells[0].FindControl("txtcodEntrega") as TextBox);
                    txtcodEntrega.Enabled = false;
                }
                txtNomProdMM.Focus();
                return;
            }
            else if (rcbTipoPromocion.Text == "A+$")
            {
                txtNomProdMM.Text = "";
                //recorre grid para bloquear controles
                foreach (GridViewRow cell in grvProd.Rows)
                {

                    TextBox txtProd = (cell.Cells[0].FindControl("txtNomProd") as TextBox);
                    txtProd.Enabled = false;
                    TextBox txtcat = (cell.Cells[0].FindControl("lblIdCat") as TextBox);
                    txtcat.Enabled = false;
                    RadComboBox cmbLab = (cell.Cells[0].FindControl("cmbLab") as RadComboBox);
                    if (string.IsNullOrWhiteSpace(cmbLab.Text))
                    {
                        cmbLab.Text = "---Seleccione un laboratorio---";
                        cmbLab.Enabled = true;
                    }
                    else
                    {
                        cmbLab.Enabled = false;
                    }
                    TextBox txtcodEntrega = (cell.Cells[0].FindControl("txtcodEntrega") as TextBox);
                    txtcodEntrega.Enabled = false;
                }
                return;
            }
            else if (rcbTipoPromocion.Text != "A+$")
            {
                txtNomProdMM.Text = "";
                //recorre grid para bloquear controles
                foreach (GridViewRow cell in grvProd.Rows)
                {

                    TextBox txtProd = (cell.Cells[0].FindControl("txtNomProd") as TextBox);
                    txtProd.Enabled = false;
                    TextBox txtcat = (cell.Cells[0].FindControl("lblIdCat") as TextBox);
                    txtcat.Enabled = false;
                    TextBox txtcodEntrega = (cell.Cells[0].FindControl("txtcodEntrega") as TextBox);
                    RadComboBox cmbLab = (cell.Cells[0].FindControl("cmbLab") as RadComboBox);
                    if (rcbTipoPromocion.Text == "A+B")
                    {
                        txtcodEntrega.Enabled = true;
                        cmbLab.Text = "---Seleccione un laboratorio---";
                        cmbLab.Enabled = true;
                    }
                    else
                    {
                        txtcodEntrega.Enabled = false;
                    }
                }
                return;
            }
            else
            {
                txtNomProdMM.Text = "";
                btnAgregar.Enabled = false;
                btnAgregar.Visible = false;
            }
        }
        private void BloqueaControles()
        {
            rdpFechaPaseProd.Enabled = false;

            rcbSegmento.Enabled = false;
            rcbTipoPromocion.Enabled = false;
            txtcantcompra.Enabled = false;
            txtCantentrega.Enabled = false;
            rdpFIni.Enabled = false;
            rdpFFin.Enabled = false;
            rdpFConteo.Enabled = false;
            rcbLimPeriodo.Enabled = false;
            txtlimcantidad.Enabled = false;
            txtComentario.Enabled = false;
            //rdpFExt.Enabled = false;
            grvProd.Enabled = false;
            btnAgregar.Enabled = false;
            btnAgregar.Visible = false;
            lblNomProdMM.Visible = false;
            txtNomProdMM.Visible = false;
            grvProd.Columns[5].Visible = false;
            chkVerWS.Enabled = false;
        }
        private bool Validaciones()
        {
            bool blnRespuesta = true;
            ModDatosGrid Resultados; ;

            if (Request.QueryString["Est"] != "Iniciada")
            {

                if (rdpFIni.SelectedDate == null)
                {
                    Mensajes("Es necesario proporcione una fecha inicio.");
                    rdpFIni.Clear();
                    rdpFIni.Focus();
                }

                if (rdpFIni.SelectedDate != null)
                {
                    if (rdpFIni.SelectedDate <= DateTime.Now.Date)
                    {
                        Mensajes("No es posible que sea menor e igual a la fecha actual.");
                        rdpFIni.Clear();
                        rdpFIni.Focus();
                        return false;
                    }
                }

                if (rdpFFin.SelectedDate == null)
                {
                    Mensajes("Es necesario proporcione una fecha fin.");
                    rdpFFin.Clear();
                    rdpFFin.Focus();
                }

                if (rdpFFin.SelectedDate != null)
                {
                    if (rdpFFin.SelectedDate <= rdpFIni.SelectedDate)
                    {
                        Mensajes("No es posible que la fecha fin sea menor e igual a la fecha inicio.");
                        rdpFFin.Clear();
                        rdpFFin.Focus();
                        return false;
                    }
                }

                if (rdpFFin.SelectedDate != null)
                {
                    if (rdpFFin.SelectedDate.Value.Year > (DateTime.Now.Year + 2))
                    {
                        Mensajes("No es posible que la fecha fin sea mayor a dos años posteriores.");
                        rdpFFin.Clear();
                        rdpFFin.Focus();
                        return false;
                    }
                }

                if (rdpFConteo.SelectedDate == null)
                {
                    Mensajes("Es necesario proporcione una fecha conteo.");
                    rdpFConteo.Clear();
                    rdpFConteo.Focus();
                    return false;
                }

            }
            else
            {
                if (rdpFIni.SelectedDate == null)
                {
                    Mensajes("Es necesario proporcione una fecha inicio.");
                    rdpFIni.Clear();
                    rdpFIni.Focus();
                }

                if (rdpFFin.SelectedDate == null)
                {
                    Mensajes("Es necesario proporcione una fecha fin.");
                    rdpFFin.Clear();
                    rdpFFin.Focus();
                }

                if (rdpFConteo.SelectedDate == null)
                {
                    Mensajes("Es necesario proporcione una fecha conteo.");
                    rdpFConteo.Clear();
                    rdpFConteo.Focus();
                    return false;
                }

                if (rdpFFin.SelectedDate != null)
                {
                    if (rdpFFin.SelectedDate <= rdpFIni.SelectedDate)
                    {
                        Mensajes("No es posible que la fecha fin sea menor e igual a la fecha inicio.");
                        rdpFFin.Clear();
                        rdpFFin.Focus();
                        return false;
                    }
                }
            }


            if (string.IsNullOrWhiteSpace(txtComentario.Text))
            {
                Mensajes("El campo comentario general es obligatorio, registre un comentario.");
                txtComentario.Focus();
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

            foreach (GridViewRow cell in grvProd.Rows)
            {
                TextBox txtcod = (cell.Cells[0].FindControl("txtcod") as TextBox);
                RadComboBox cmbLab = (cell.Cells[3].FindControl("cmbLab") as RadComboBox);
                TextBox txtcodEntrega = (cell.Cells[4].FindControl("txtcodEntrega") as TextBox);

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
                    cmbLab.Text = "---Seleccione un laboratorio---";
                    cmbLab.Focus();
                    return false;
                }

                if (idLab < 1000)
                {
                    Mensajes("Imposible continuar, seleccione un laboratorio existente de la lista.");
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

                if (rcbTipoPromocion.Text == "M&M")
                {
                    if (string.IsNullOrWhiteSpace(txtNomProdMM.Text))
                    {
                        Mensajes("Imposible continuar, es necesario proporcione un nombre de promoción M&M.");
                        txtNomProdMM.Focus();
                        return false;
                    }
                }

                if (cmbLab.Text == "---Seleccione un laboratorio---" || string.IsNullOrWhiteSpace(cmbLab.Text))
                {
                    Mensajes("Imposible continuar, debé asociar cada producto de la lista a un laboratorio.");
                    cmbLab.Focus();
                    return false;
                }


                if (rcbTipoPromocion.Text == "A+B")
                {
                    if (txtcod.Text == txtcodEntrega.Text)
                    {
                        Mensajes("Imposible continuar, el código que entrega no puede ser igual al código interno.");
                        txtcodEntrega.Text = "";
                        txtcodEntrega.Focus();
                        return false;
                    }

                    //Consulta en ambiente productivo
                    AdministraPromocion Ejecuta = new AdministraPromocion();
                    Resultados = Ejecuta.ValidaExistenciaCodInterno(CnnPruebas, txtcodEntrega.Text);

                    //Valida la existencia del codigo interno
                    if (Resultados == null)
                    {
                        Mensajes("Imposible continuar, código que entrega: " + txtcodEntrega.Text + " no existente.");
                        txtcodEntrega.Text = "";
                        txtcodEntrega.Focus();
                        return false;
                    }
                }

            }

            return blnRespuesta;
        }
        private bool ValidaFechaAutoriza()
        {

            bool blnResultado = true;
            if (rdpFechaPaseProd.SelectedDate != null)
            {
                if (rdpFechaPaseProd.SelectedDate >= rdpFIni.SelectedDate)
                {
                    Mensajes("La fecha de autorización debe ser menor a la fecha inicio.");
                    rdpFechaPaseProd.Clear();
                    rdpFechaPaseProd.Focus();
                    blnResultado = false;
                    return blnResultado;
                }
                //if (rdpFechaPaseProd.SelectedDate < DateTime.Now.Date)
                //{
                //    Mensajes("La fecha debe ser mayor ó igual al día actual.");
                //    rdpFechaPaseProd.Clear();
                //    rdpFechaPaseProd.Focus();
                //    blnResultado = false;
                //    return blnResultado;
                //}
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
                    TextBox txtCat = (TextBox)row.FindControl("lblIdCat");

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
            }
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
                    TextBox txtCat = (TextBox)row.FindControl("lblIdCat");

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
    }
}