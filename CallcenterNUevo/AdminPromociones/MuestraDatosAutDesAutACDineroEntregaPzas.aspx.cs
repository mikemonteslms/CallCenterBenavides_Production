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
    public partial class MuestraDatosAutDesAutACDineroEntregaPzas : System.Web.UI.Page
    {
        public List<ModMecanica> lstRespuesta = new List<ModMecanica>();
        public List<ModMecanica> lstBeneficios = new List<ModMecanica>();

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
                //no igualara
                TextBox txtcod = (cell.Cells[0].FindControl("txtcod") as TextBox);
                //Al presionar tecla Enter, iguala el valor de codigo interno a Codigo entrega
                txtcod.Attributes.Add("onkeypress", "cambiaFoco('txtreglanegocio')");
                txtcantcompra.Focus();
            }

            foreach (GridViewRow cell in grvProd2.Rows)
            {
                //no igualara
                TextBox txtcod = (cell.Cells[0].FindControl("txtcod2") as TextBox);
                //Al presionar tecla Enter, iguala el valor de codigo interno a Codigo entrega
                txtcod.Attributes.Add("onkeypress", "cambiaFoco('txtreglanegocio')");
                txtcantcompra.Focus();
            }

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


        protected void grvProd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Productos ACUMULACIÓN
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
                        Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAutDesAutACDineroEntregaPzas", "grvProd_RowDataBound", "Ejecuta.ObtenLaboratorios()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
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
                    //TextBox txtcodEnt = (TextBox)row.FindControl("txtcodEntrega");
                    Label lblIdLab = (Label)row.FindControl("lblIdLab");
                    TextBox txtCat = (TextBox)row.FindControl("lblIdCat");

                    RadComboBox cmbLab = (RadComboBox)row.FindControl("cmbLab");
                    dr = dt1.NewRow();
                    dr[0] = txtcodigo.Text.ToString();
                    dr[1] = txtProd.Text.ToString();
                    dr[2] = txtCat.Text;
                    dr[3] = cmbLab.SelectedValue;
                    dr[4] = cmbLab.SelectedValue;
                    dr[5] = txtCat.Text;

                    dt1.Rows.Add(dr);
                    ViewState["DataTemp"] = dt1;
                }
                //Elimina registro de datatable
                dt1.Rows.RemoveAt(e.RowIndex);

                //Asigna valor de datatable al viewState
                ViewState["DataTemp"] = dt1;
                Session.Add("DTElementosMemoria", dt1);

                grvProd.DataSource = ViewState["DataTemp"];
                grvProd.DataBind();
                //Ejecuta evento change del txtcode para obtener el laboratorio
                txtcod_TextChanged(sender, null);
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
            TextBox nomProd = new TextBox();
            TextBox categoria = new TextBox();
            RadComboBox cmblab = new RadComboBox();
            int i = 0;

            codInt.Text = "";

            try
            {
                foreach (GridViewRow row in this.grvProd.Rows)
                {
                    //Obtiene controles embebidos en el grid
                    codInt = (row.FindControl("txtcod") as TextBox);
                    categoria = (row.FindControl("lblIdCat") as TextBox);
                    nomProd = (row.FindControl("txtNomProd") as TextBox);
                    cmblab = (row.FindControl("cmbLab") as RadComboBox);
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
                            if (Session["DTElementosMemoria"] != null)
                            {
                                DataTable DT = new DataTable();
                                DT = (DataTable)Session["DTElementosMemoria"];

                                if ((DT.Rows.Count - 1) >= i)
                                {
                                    cmblab.SelectedValue = DT.Rows[i][4].ToString();
                                    cmblab.Text = DT.Rows[i][3].ToString();
                                }
                                else
                                {
                                    Session.Contents.Remove("DTElementosMemoria");
                                    Session.Remove("DTElementosMemoria");
                                }
                            }
                            else
                            {
                                cmblab.Text = "---Seleccione un laboratorio---";
                            }
                        }
                    }
                    else
                    {
                        Mensajes("Producto no existente.");
                        codInt.Text = "";
                        codInt.Focus();
                        return;
                    }
                    i += 1;
                }


                //=====================================================================================
                //Valida duplicados
                if (ValidarDuplicados(grvProd) > 0)
                {
                    Mensajes("Imposible agregar el código interno: " + codInt.Text + ", ya existe dentro de la lista.");
                    codInt.Text = "";
                    nomProd.Text = "";
                    categoria.Text = "";
                    cmblab.SelectedValue = null;
                    cmblab.Text = "---Seleccione un laboratorio---";
                    codInt.Focus();
                    return;
                }


                //=====================================================================================
                //Valida que el código interno  de beneficio no exista dentro del listado de acumulados
                TextBox codIntB = new TextBox();
                bool blnExiste = false;

                foreach (GridViewRow rowAC in this.grvProd2.Rows)
                {
                    //Obtiene controles embebidos en el grid
                    codIntB = (rowAC.FindControl("txtcod2") as TextBox);
                    break;
                }

                if (!string.IsNullOrWhiteSpace(codIntB.Text))
                {
                    foreach (GridViewRow rowAC in this.grvProd.Rows)
                    {
                        //Obtiene controles embebidos en el grid
                        codInt = (rowAC.FindControl("txtcod") as TextBox);

                        if (codIntB.Text == codInt.Text)
                        {
                            blnExiste = true;
                            break;
                        }
                    }

                    if (blnExiste)
                    {
                        Mensajes("No puede agregar o modificar a código: " + codInt.Text + ",  ya que existe como beneficio.");
                        codInt.Text = "";
                        codInt.Focus();
                    }
                }
                //=====================================================================================

            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAutDesAutACDineroEntregaPzas", "txtcod_TextChange", "Ejecuta.ValidaExistenciaCodInterno(" + CnnPruebas + "," + codInt.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error interno, contacte al administrador");
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
                intDuplicados = ValidarDuplicados(grvProd);
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
                    DSResultados = Ejecuta.ObtenerPromcumulaDineroxAutDesAut(CnnPruebas, Session["CodInt"].ToString());
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
                    Response.Redirect("ConsultaPromACDineroEntregaPzas.aspx");
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
                        lblEstatus.Text = "Aprobado";
                        CargarInformacion();
                        Mensajes("La autorización fue registrada correctamente.");
                        btnAutDesAut.Text = "Cancela autorización";
                        btnAutDesAut.Width = 200;
                        rdpFechaPaseProd.Clear();
                        AdministraPromocion Ejecuta = new AdministraPromocion();

                        TextBox codInt = new TextBox();
                        foreach (GridViewRow rowAC in this.grvProd.Rows)
                        {
                            //Obtiene controles embebidos en el grid
                            codInt = (rowAC.FindControl("txtcod") as TextBox);
                            break;
                        }

                        DSResultados = Ejecuta.ObtenerPromcumulaDineroxAutDesAut(CnnPruebas, codInt.Text);
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
                        lblEstatus.Text = "Por Aprobar";
                        lblPase.Visible = false;
                        lblFechaPase.Visible = false;
                        Mensajes("La cancelación fue registrada correctamente.");
                        rdpFechaPaseProd.Clear();
                        AdministraPromocion Ejecuta = new AdministraPromocion();
                        DSResultados = Ejecuta.ObtenerPromcumulaDineroxAutDesAut(CnnPruebas, Session["CodInt"].ToString());
                        if (DSResultados != null)
                        {
                            if (DSResultados.Tables.Count > 0)
                            {
                                if (DSResultados.Tables[0].Rows.Count > 0)
                                {
                                    lblEstatus.Text = DSResultados.Tables[0].Rows[0][6].ToString();
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
            Response.Redirect("ConsultaPromACDineroEntregaPzas.aspx");
        }

        #region "AcumulacionDineroEntregaPzaz"
        protected void grvProd2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Productos BENEFICIO
            if (grvProd2.Rows.Count > 1)
            {
                DataTable dt1 = new DataTable();
                dt1 = EstructuraProductos();
                DataRow dr;
                //Recorre el contenido del grid y lo guarda en datatable
                foreach (GridViewRow row in this.grvProd2.Rows)
                {
                    TextBox txtcodigo = (TextBox)row.FindControl("txtcod2");
                    TextBox txtProd = (TextBox)row.FindControl("txtNomProd");
                    Label lblIdLab = (Label)row.FindControl("lblIdLab");
                    TextBox txtCat = (TextBox)row.FindControl("txtCat");

                    RadComboBox cmbLab = (RadComboBox)row.FindControl("cmbLab");
                    dr = dt1.NewRow();
                    dr[0] = txtcodigo.Text.ToString();
                    dr[1] = txtCat.Text;
                    dr[2] = txtProd.Text.ToString();
                    dr[3] = cmbLab.SelectedValue;
                    dr[4] = cmbLab.SelectedValue;
                    dr[5] = txtCat.Text;

                    dt1.Rows.Add(dr);
                }
                //Elimina registro de datatable
                dt1.Rows.RemoveAt(e.RowIndex);
                //Asigna valor de datatable al viewState
                ViewState["DataTemp"] = dt1;
                Session.Add("DTElementosMemoria2", dt1);

                grvProd2.DataSource = ViewState["DataTemp"];
                grvProd2.DataBind();
                //Ejecuta evento change del txtcode para obtener el laboratorio
                txtcod2_TextChanged(sender, null);
            }
            else
            {
                Mensajes("imposible eliminar esta fila.");
            }
        }
        protected void grvProd2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Productos BENEFICIO
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
        protected void btnAgregar2_Click(object sender, EventArgs e)
        {
            Nuevoregistro2("A");
            SeteaLaboratoriosExistentes2();
            //Session.Contents.Remove("DTElementosMemoria2");
            //Session.Remove("DTElementosMemoria2");
        }
        protected void txtcod2_TextChanged(object sender, EventArgs e)
        {
            AdministraPromocion Ejecuta = new AdministraPromocion();
            ModDatosGrid Resultado = new ModDatosGrid();
            TextBox codInt = new TextBox();
            TextBox nomProd = new TextBox();
            TextBox categoria = new TextBox();
            RadComboBox cmblab = new RadComboBox();
            int i = 0;

            codInt.Text = "";

            try
            {
                foreach (GridViewRow row in this.grvProd2.Rows)
                {
                    //Obtiene controles embebidos en el grid
                    codInt = (row.FindControl("txtcod2") as TextBox);
                    categoria = (row.FindControl("txtCat") as TextBox);
                    nomProd = (row.FindControl("txtNomProd") as TextBox);
                    cmblab = (row.FindControl("cmbLab") as RadComboBox);
                    cmblab.Enabled = true;
                    //////////////////////////////////////////////////////////////

                    //Consulta en ambiente pruebas 
                    Resultado = Ejecuta.ValidaExistenciaCodInterno(CnnPruebas, codInt.Text);

                    //Valida la existencia y setea campos del codigo interno
                    if (Resultado != null)
                    {

                        //=====================================================================================
                        //Valida que el código interno  de beneficio no exista dentro del listado de acumulados
                        TextBox codIntAC = new TextBox();
                        foreach (GridViewRow rowAC in this.grvProd.Rows)
                        {
                            //Obtiene controles embebidos en el grid
                            codIntAC = (rowAC.FindControl("txtcod") as TextBox);

                            if (codIntAC.Text == codInt.Text)
                            {
                                break;
                            }
                        }

                        if (codIntAC.Text == codInt.Text)
                        {
                            Mensajes("No puede agregar el código: " + codInt.Text + ", como beneficio si este ya existe en productos de acumulación.");
                            codInt.Text = "";
                            codInt.Focus();
                            break;
                        }
                        //=====================================================================================


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
                            if (Session["DTElementosMemoria2"] != null)
                            {
                                DataTable DT = new DataTable();
                                DT = (DataTable)Session["DTElementosMemoria2"];

                                if ((DT.Rows.Count - 1) >= i)
                                {
                                    cmblab.SelectedValue = DT.Rows[i][4].ToString();
                                    cmblab.Text = DT.Rows[i][3].ToString();
                                }
                                else
                                {
                                    Session.Contents.Remove("DTElementosMemoria2");
                                    Session.Remove("DTElementosMemoria2");
                                }
                            }
                            else
                            {
                                cmblab.Text = "---Seleccione un laboratorio---";
                            }
                        }
                    }
                    else
                    {
                        Mensajes("Producto no existente.");
                        codInt.Text = "";
                        codInt.Focus();
                        return;
                    }
                    i += 1;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromocion", "txtcod_TextChange", "Ejecuta.ValidaExistenciaCodInterno(" + CnnPruebas + "," + codInt.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al validar la existencia del codigo interno, contacte al administrador");
            }
        }
        private void MantenerSoloRegistro2()
        {
            ActivaControles(0);
        }
        private void Nuevoregistro2(string tipo)
        {
            TextBox txtcodigo;
            TextBox txtProd;
            TextBox txtCat;
            Label lblIdLab;
            RadComboBox cmbLab;
            DataTable dt = null;
            dt = EstructuraProductos();
            DataRow dr;

            foreach (GridViewRow row in this.grvProd2.Rows)
            {
                txtcodigo = (TextBox)row.FindControl("txtcod2");
                txtProd = (TextBox)row.FindControl("txtNomProd");
                txtCat = (TextBox)row.FindControl("txtCat");
                lblIdLab = (Label)row.FindControl("lblIdLab");
                cmbLab = (RadComboBox)row.FindControl("cmbLab");

                dr = dt.NewRow();
                dr[0] = txtcodigo.Text.ToString();
                dr[1] = txtCat.Text;
                dr[2] = txtProd.Text.ToString();
                dr[3] = cmbLab.Text;
                dr[4] = cmbLab.SelectedValue;
                dr[5] = txtCat.Text;

                dt.Rows.Add(dr);
                ViewState["DataTemp"] = dt;

                if (
                string.IsNullOrWhiteSpace(txtcodigo.Text.ToString()) ||
                string.IsNullOrWhiteSpace(txtProd.Text.ToString()) ||
                string.IsNullOrWhiteSpace(cmbLab.SelectedValue) ||
                string.IsNullOrWhiteSpace(cmbLab.SelectedValue))
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
                dt.Rows.Add(dr);
            }
            else
            {   //En caso de detectar campos vacios dentro de una fila
                Mensajes("No debe dejar filas y/o celdas vacias.");
            }

            ViewState["DataTemp"] = dt;
            this.grvProd2.DataSource = ViewState["DataTemp"];
            this.grvProd2.DataBind();
        }
        private void SeteaLaboratoriosExistentes2()
        {
            foreach (GridViewRow cell in grvProd2.Rows)
            {
                RadComboBox cmblab = (cell.Cells[3].FindControl("cmbLab") as RadComboBox);
                Label lblIdLab = (cell.Cells[4].FindControl("lblIdLab") as Label);

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
        private void ElimionarVariablesSession()
        {
            Session.Contents.Remove("DTElementosMemoria");
            Session.Remove("DTElementosMemoria");
            Session.Contents.Remove("DTElementosMemoria2");
            Session.Remove("DTElementosMemoria2");
        }
        #endregion

        private void CargarInformacion()
        {
            int IdMecanica = 0;
            int TipoAcumulacion = 0;
            Label lbl = new Label();
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
                Estructuras = Ejecuta.CargaDetalleMecanicaACDinero(CnnPruebas, IdMecanica, TipoAcumulacion);
                lstRespuesta = Estructuras.lstMecanica;
                lstBeneficios = Estructuras.lstBeneficios;

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
                        dr[4] = lstRespuesta[0].Idlaboratorio;
                        dr[5] = lstRespuesta[0].Categoria;
                        dt.Rows.Add(dr);
                        ViewState["DataTemp"] = dt;
                    }

                    //Carga productos de compra
                    grvProd.DataSource = lstRespuesta;
                    grvProd.DataBind();

                    //Carga productos beneficio
                    grvProd2.DataSource = lstBeneficios;
                    grvProd2.DataBind();
                    //Setear campos
                    foreach (ModMecanica campos in lstRespuesta)
                    {
                        rcbSegmento.SelectedValue = campos.IdSegmento.ToString();
                        rcbTipoPromocion.SelectedValue = campos.IdtipoPromocion.ToString();
                        //strCodigoBarras.Value = campos.CodigoBarras;

                        if (rcbTipoPromocion.Text == "Acumula  $ A(lista) + B pieza")
                        {
                            txtNomProdACDinero.Text = campos.NombreMecanica;
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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAutDesAutACDineroEntregaPzas", "CargaInformacion()", "Ejecuta.CargaDetalleMecanica(" + IdMecanica + "," + TipoAcumulacion + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAutDesAutACDineroEntregaPzas", "CargaCombos()", "ejecuta.ObtenSegmentos()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAutDesAutACDineroEntregaPzas", "CargaCombos()", "ejecuta.ObtenTipoPromocion(" + TipoAcum + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAutDesAutACDineroEntregaPzas", "CargaCombos()", "ejecuta.ObtenLimitePeriodo()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar Límite Periodo, contacte al administrador");
            }
        }
        private DataTable EstructuraProductos()
        {
            DataTable medidaTabla = new DataTable();

            medidaTabla.Columns.Add("CodigoInterno", typeof(string));
            medidaTabla.Columns.Add("Categoria", typeof(string));
            medidaTabla.Columns.Add("NomProducto", typeof(string));
            medidaTabla.Columns.Add("Laboratorio", typeof(string));
            //medidaTabla.Columns.Add("CodigoInternoEntrega", typeof(string));
            medidaTabla.Columns.Add("IdLaboratorio", typeof(string));
            medidaTabla.Columns.Add("IdCat", typeof(string));
            return medidaTabla;
        }
        private void Nuevoregistro(string tipo)
        {
            TextBox txtcodigo;
            TextBox txtProd;
            TextBox txtCat;
            Label lblIdLab;
            RadComboBox cmbLab;
            DataTable dt = null;
            dt = EstructuraProductos();
            DataRow dr;

            foreach (GridViewRow row in this.grvProd.Rows)
            {
                txtcodigo = (TextBox)row.FindControl("txtcod");
                txtProd = (TextBox)row.FindControl("txtNomProd");
                txtCat = (TextBox)row.FindControl("lblIdCat");
                lblIdLab = (Label)row.FindControl("lblIdLab");
                cmbLab = (RadComboBox)row.FindControl("cmbLab");

                dr = dt.NewRow();
                dr[0] = txtcodigo.Text.ToString();
                dr[1] = txtCat.Text;
                dr[2] = txtProd.Text.ToString();
                dr[3] = cmbLab.Text;
                dr[4] = cmbLab.SelectedValue;
                dr[5] = txtCat.Text;

                dt.Rows.Add(dr);
                ViewState["DataTemp"] = dt;

                if (
                string.IsNullOrWhiteSpace(txtcodigo.Text.ToString()) ||
                string.IsNullOrWhiteSpace(txtProd.Text.ToString()) ||
                string.IsNullOrWhiteSpace(cmbLab.SelectedValue) ||
                string.IsNullOrWhiteSpace(cmbLab.SelectedValue))
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
                dt.Rows.Add(dr);
            }
            else
            {   //En caso de detectar campos vacios dentro de una fila
                Mensajes("No debe dejar filas y/o celdas vacias.");
            }

            ViewState["DataTemp"] = dt;
            this.grvProd.DataSource = ViewState["DataTemp"];
            this.grvProd.DataBind();
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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAutDesAutACDineroEntregaPzas", "Modificar()", "Ejecuta.AutorizaPromocion(" + campos + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
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
            string strCodIntEnt = "";


            //if (Request.QueryString["Est"] != "Iniciada" && rcbTipoPromocion.Text == "Acumula  $ A(lista) + B pieza" || Request.QueryString["Est"] == "Iniciada" && rcbTipoPromocion.Text == "Acumula  $ A(lista) + B pieza")
            //{
            //Promociones No Iniciadas (Acumula  $ A(lista) + B pieza)
            ModPromocionesNoIniciadas Campos = new ModPromocionesNoIniciadas();
            try
            {
                foreach (GridViewRow reg in grvProd.Rows)
                {
                    //*****************************************************************************
                    //Se arma cadena de codigos internos de compra
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
                    //*****************************************************************************
                    Campos.Lider = codInt.Text;
                }

                foreach (GridViewRow reg in grvProd2.Rows)
                {
                    //*****************************************************************************
                    //Se arma cadena de codigos internos entrega
                    TextBox codIntEnt = (reg.Cells[0].FindControl("txtcod2") as TextBox);
                    //Se concatenan Codigos Internos delimitados por ","
                    if (strCodIntEnt == "")
                    {
                        strCodIntEnt = codIntEnt.Text;
                    }
                    else
                    {
                        if (strCodInt.IndexOf(codIntEnt.Text + ",") == -1)
                        {
                            strCodIntEnt = strCodIntEnt + "," + codIntEnt.Text;
                        }
                    }
                    //*****************************************************************************
                }

                Campos.CodigoInterno = strCodInt;
                Campos.CodigoInternoEntrega = strCodIntEnt;
                Campos.NombrePromocion = txtNomProdACDinero.Text;
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

                //Realiza el guardado de datos generales
                blnRespuesta = Ejecuta.ModificaPromocionesAcumulacionDineroNoIniciadas(CnnPruebas, Campos, "spU_PromocionAcumulacionDineroListas_NoIniciada_Update");
                //=========================================================================================================================================
                //Realiza el guardado solo de los elementos del grid Compras para asociar los laboratorios 
                //despues de realizar el guardado general
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
                //=========================================================================================================================================

                //=========================================================================================================================================
                //Realiza el guardado solo de los elementos del grid BENEFICIOS para asociar los laboratorios 
                //despues de realizar el guardado general
                List<ModGuardaDatosGrid> lstGridB = new List<ModGuardaDatosGrid>();
                foreach (GridViewRow itmB in grvProd2.Rows)
                {
                    TextBox txtcodInt = (itmB.Cells[0].FindControl("txtcod2") as TextBox);
                    RadComboBox cmbLab = (itmB.Cells[3].FindControl("cmbLab") as RadComboBox);


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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAutDesAutACDineroEntregaPzas", "Modificar()", "Ejecuta.ModificaPromocionesNoIniciadas(" + Campos + ", sp_Promocion_ProduccionAcumulacionListas_NoIniciada_Update)", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar guardar promociones no iniciadas Acumulación dinero y entrega de piezas, contacte al administrador");
            }
            //}

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

            //Activa todo
            txtNomProdACDinero.Enabled = true;
            rcbSegmento.Enabled = true;
            rcbTipoPromocion.Enabled = true;
            txtcantcompra.Enabled = true;
            txtCantentrega.Enabled = true;
            rdpFechaPaseProd.Enabled = true;
            rdpFIni.Enabled = true;
            rdpFFin.Enabled = true;
            rdpFConteo.Enabled = true;
            rcbLimPeriodo.Enabled = true;
            txtlimcantidad.Enabled = true;
            txtComentario.Enabled = true;
            chkAplicaExt.Visible = true;
            chkAplicaExt.Enabled = true;
            rdpFExt.Enabled = true;
            chkVerWS.Enabled = true;
            rdbEntregaSugeridosCierre.Enabled = true;
            rdbEntregaSugeridos.Enabled = true;
            btnAgregar.Enabled = true;
            btnAgregar.Visible = true;
            lblNomProdMM.Visible = true;
            txtNomProdACDinero.Visible = true;
            grvProd.Enabled = true;
            grvProd.Columns[4].Visible = true;
            grvProd2.Enabled = true;
            grvProd2.Columns[4].Visible = false;
            btnAgregar2.Enabled = false;
            btnAgregar2.Visible = false;

            //recorre grid compras para bloquear controles
            foreach (GridViewRow cell in grvProd.Rows)
            {
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
            }

            //recorre grid beneficios para bloquear controles
            foreach (GridViewRow cell in grvProd2.Rows)
            {
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
            }
            txtNomProdACDinero.Focus();
            return;

        }
        private void BloqueaControles()
        {
            txtNomProdACDinero.Enabled = false;
            rcbSegmento.Enabled = false;
            rcbTipoPromocion.Enabled = false;
            txtcantcompra.Enabled = false;
            txtCantentrega.Enabled = false;
            rdpFechaPaseProd.Enabled = false;
            rdpFIni.Enabled = false;
            rdpFFin.Enabled = false;
            rdpFConteo.Enabled = false;
            rcbLimPeriodo.Enabled = false;
            txtlimcantidad.Enabled = false;
            txtComentario.Enabled = false;
            rdbEntregaSugeridosCierre.Enabled = false;
            rdbEntregaSugeridos.Enabled = false;
            btnAgregar.Enabled = false;
            btnAgregar.Visible = false;
            lblNomProdMM.Visible = false;
            txtNomProdACDinero.Visible = false;
            grvProd.Enabled = false;
            grvProd.Columns[4].Visible = false;
            grvProd2.Enabled = false;
            grvProd2.Columns[4].Visible = false;
            btnAgregar2.Enabled = false;
            btnAgregar2.Visible = false;
            chkAplicaExt.Visible = false;
            chkAplicaExt.Enabled = false;
            chkVerWS.Enabled = false;
            rdpFExt.Enabled = false;
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
                //TextBox txtcodEntrega = (cell.Cells[4].FindControl("txtcodEntrega") as TextBox);

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

                //if (string.IsNullOrWhiteSpace(txtcodEntrega.Text))
                //{
                //    Mensajes("Imposible continuar, es necesario proporcione un código de entrega.");
                //    txtcodEntrega.Focus();
                //    return false;
                //}

                if (rcbTipoPromocion.Text == "Acumula  $ A(lista) + B pieza")
                {
                    if (string.IsNullOrWhiteSpace(txtNomProdACDinero.Text))
                    {
                        Mensajes("Imposible continuar, es necesario proporcione un nombre de promoción acumulación dinero.");
                        txtNomProdACDinero.Focus();
                        return false;
                    }
                }

                if (cmbLab.Text == "---Seleccione un laboratorio---" || string.IsNullOrWhiteSpace(cmbLab.Text))
                {
                    Mensajes("Imposible continuar, debé asociar cada producto de la lista a un laboratorio.");
                    cmbLab.Focus();
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
        private void MantenerSoloRegistro()
        {
            ActivaControles(0);
        }
        private int ValidarDuplicados(GridView grvProd)
        {
            int intDuplicados = 0;
            DataTable DTRespDuplicados = new DataTable();

            if (grvProd.Rows.Count > 1 && rcbTipoPromocion.Text == "Acumula  $ A(lista) + B pieza")
            {
                DataTable dt1 = new DataTable();
                dt1 = EstructuraProductos();
                DataRow dr;
                //Recorre el contenido del grid y lo guarda en datatable
                foreach (GridViewRow row in this.grvProd.Rows)
                {
                    TextBox txtcodigo = (TextBox)row.FindControl("txtcod");
                    TextBox txtProd = (TextBox)row.FindControl("txtNomProd");
                    Label lblIdLab = (Label)row.FindControl("lblIdLab");
                    //TextBox txtCat = (TextBox)row.FindControl("IdCat");

                    RadComboBox cmbLab = (RadComboBox)row.FindControl("cmbLab");
                    dr = dt1.NewRow();
                    dr[0] = txtcodigo.Text.ToString();
                    dr[1] = txtProd.Text.ToString();
                    dr[2] = lblIdLab.Text;
                    dr[3] = cmbLab.Text;
                    dr[4] = cmbLab.SelectedValue;
                    dr[5] = lblIdLab.Text;


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

            string[] sColumnas = { "CodigoInterno" };
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