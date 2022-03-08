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
    public partial class MuestraDatosAcumulacionDinero : System.Web.UI.Page
    {
        public List<ModMecanica> lstRespuesta = new List<ModMecanica>();
        List<ModMecanica> lstBeneficios = new List<ModMecanica>();
        public ModContenedorMecanicas Estructura = new ModContenedorMecanicas();
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
                        lstResultadosLab = Ejecuta.ObtenLaboratorios(CnnProductivo);

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
                        Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAcumulacionDinero", "grvProd_RowDataBound", "Ejecuta.ObtenLaboratorios()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                        Mensajes("Ocurrio un error al intentar cargar Laboratorios, contacte al administrador");
                    }
                }
            }
        }
        protected void grvProd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvProd.PageIndex = e.NewPageIndex;
            CargarInformacion();
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
                    Resultado = Ejecuta.ValidaExistenciaCodInterno(CnnProductivo, codInt.Text);

                    //Valida la existencia y setea campos del codigo interno
                    if (Resultado != null)
                    {
                        //setea resultados a controles
                        codInt.Text = Resultado.codigointerno;
                        nomProd.Text = Resultado.nombreProducto;
                        strCodigoBarras.Value = Resultado.CodigoBarras;
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

                btnAgregar.Enabled = true;
                btnAgregar.Visible = true;
                lblNomProdMM.Visible = true;
                txtNomProdACDinero.Visible = true;
                grvProd.Columns[4].Visible = true;

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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAcumulacionDinero", "txtcod_TextChange", "Ejecuta.ValidaExistenciaCodInterno(" + CnnPruebas + "," + codInt.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
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
            ValidaBeneficioDE();
            Activacontroles();
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
                if (rdpFIni.SelectedDate <= DateTime.Now)
                {
                    Mensajes("No es posible que sea menor e igual a la fecha actual.");
                    rdpFIni.Clear();
                    rdpFIni.Focus();
                }
            }
        }
        protected void rdpFFin_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFFin.SelectedDate != null)
            {
                //if (rdpFFin.SelectedDate <= rdpFIni.SelectedDate)
                //{
                //    Mensajes("No es posible que sea menor e igual a la fecha inicio.");
                //    rdpFFin.Clear();
                //    rdpFFin.Focus();
                //}
                if (rdpFFin.SelectedDate.Value < DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null))
                {
                    Mensajes("La fecha fin no puede ser menor a la fecha actual...");
                    lblMensajeCancelacion.Text = "";
                    txtComentario.Text = "";
                    chkVerWS.Checked = true;
                    rdpFFin.SelectedDate = null;
                    rdpFFin.Focus();
                    return;
                }

                if (rdpFFin.SelectedDate.Value == DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null))
                {
                    lblMensajeCancelacion.Text = "Al asignar la fecha actual como fecha fin cancelara dicha promoción.";
                    txtComentario.Text = "Cancelación de la promoción.";
                    chkVerWS.Checked = false;
                    return;
                }
                else
                {
                    lblMensajeCancelacion.Text = "";
                    txtComentario.Text = "";
                    chkVerWS.Checked = true;
                }


                if (rdpFFin.SelectedDate != null)
                {
                    if (rdpFFin.SelectedDate.Value.Year > (DateTime.Now.Year + 2))
                    {
                        Mensajes("No es posible que sea mayor a dos años posteriores.");
                        lblMensajeCancelacion.Text = "";
                        txtComentario.Text = "";
                        chkVerWS.Checked = true;
                        rdpFFin.Clear();
                        rdpFFin.Focus();
                        return;
                    }
                }

                //Verifica que no exista la mecanica dentro de la fechafin proporcionada
                AdministraPromocion ejecuta = new AdministraPromocion();
                int IdMecanica = 0;
                string codInterno = "";
                string strRespuesta = "";

                IdMecanica = Convert.ToInt32(Request.QueryString["Idmec"]);

                foreach (GridViewRow reg in grvProd.Rows)
                {
                    TextBox codInt = (reg.Cells[0].FindControl("txtcod") as TextBox);
                    codInterno = codInt.Text;
                }

                string Ambiente = "Productivo";
                strRespuesta = ejecuta.ValidarCodigoInterno(Ambiente, IdMecanica, codInterno, (DateTime)rdpFIni.SelectedDate, (DateTime)rdpFFin.SelectedDate);

                if (!string.IsNullOrWhiteSpace(strRespuesta))
                {
                    Mensajes(strRespuesta);
                    lblMensajeCancelacion.Text = "";
                    txtComentario.Text = "";
                    chkVerWS.Checked = true;
                    rdpFFin.Clear();
                    rdpFFin.Focus();
                    return;
                }
            }
        }
        protected void rdpFConteo_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFConteo.SelectedDate.Value != null)
            {
                if (rdpFConteo.SelectedDate > rdpFIni.SelectedDate)
                {
                    Mensajes("No es posible que la fecha conteo sea mayor a la fecha inicio.");
                    rdpFConteo.Clear();
                    rdpFConteo.Focus();
                }
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
            else if (rcbLimPeriodo.Text != "indefinido")
            {
                txtlimcantidad.Text = "";
                txtlimcantidad.Enabled = true;
                txtlimcantidad.Focus();
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AjustePromocion.aspx");
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (btnModificar.Text == "Modificar")
            {
                Activacontroles();
                lblTitulo.Text = "Modificación de la Promoción";
                btnModificar.Text = "Guardar";
            }
            else
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
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Nuevoregistro("A");
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
                    Resultado = Ejecuta.ValidaExistenciaCodInterno(CnnProductivo, codInt.Text);

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
                        strCodigoBarras.Value = Resultado.CodigoBarras;
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
            TextBox txtcodint = new TextBox();
            TextBox txtcodEntrega = new TextBox();
            TextBox txtNomProd = new TextBox();
            TextBox txtcat = new TextBox();
            Label lbl = new Label();
            RadComboBox cmbLab;

            try
            {
                IdMecanica = Convert.ToInt32(Request.QueryString["Idmec"]);
                TipoAcumulacion = Convert.ToInt32(Request.QueryString["TipoAc"]);

                AdministraPromocion Ejecuta = new AdministraPromocion();
                Estructura = Ejecuta.CargaDetalleMecanicaACDinero(CnnProductivo, IdMecanica, TipoAcumulacion);
                lstRespuesta = Estructura.lstMecanica;
                lstBeneficios = Estructura.lstBeneficios;

                grvProd.DataSource = lstRespuesta;
                grvProd.DataBind();

                grvProd2.DataSource = lstBeneficios;
                grvProd2.DataBind();


                foreach (GridViewRow reg in grvProd.Rows)
                {
                    txtcodint = (reg.Cells[0].FindControl("txtcod") as TextBox);
                    txtNomProd = (reg.Cells[0].FindControl("txtNomProd") as TextBox);
                    txtcat = (reg.Cells[0].FindControl("lblIdCat") as TextBox);
                    //txtcodEntrega = (reg.Cells[0].FindControl("txtcodEntrega") as TextBox);
                    cmbLab = (reg.Cells[0].FindControl("cmbLab") as RadComboBox);
                    lbl = (reg.Cells[0].FindControl("lblIdLab") as Label);

                    txtcodint.Enabled = false;
                    txtNomProd.Enabled = false;
                    txtcat.Enabled = false;
                    txtcodEntrega.Enabled = false;
                    cmbLab.Enabled = false;
                }

                //Setear campos
                foreach (ModMecanica campos in lstRespuesta)
                {
                    rcbSegmento.SelectedValue = campos.IdSegmento.ToString();
                    rcbTipoPromocion.SelectedValue = campos.IdtipoPromocion.ToString();
                    txtNomProdACDinero.Text = campos.NombreMecanica;

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
                        rdpFExt.Visible = true;
                        rdpFExt.SelectedDate = campos.FechaExtencion;
                        pnlExtencion.Visible = true;
                    }
                    else
                    {
                        chkAplicaExt.Checked = false;
                        rdpFExt.Clear();
                        lblFext.Visible = false;
                        lblFext.Visible = false;
                        rdpFExt.Visible = false;
                        pnlExtencion.Visible = true;
                    }

                    if (campos.CierreCiclosSugeridos == 0)
                    {
                        rdbEntregaSugeridosCierre.Checked = true;
                    }
                    else if (campos.CierreCiclosSugeridos == 1)
                    {
                        rdbEntregaSugeridos.Checked = true;
                    }

                    strCodigoBarras.Value = campos.CodigoBarras;
                    rcbLimPeriodo.SelectedValue = campos.IdPreiodoLimite.ToString();
                    txtcantcompra.Text = campos.CantidadCompra.ToString();
                    txtCantentrega.Text = campos.CantidadEntrega.ToString();
                    txtlimcantidad.Text = campos.Limite.ToString();
                    txtComentario.Text = campos.Comentarios;
                    lbl.Text = campos.Idlaboratorio.ToString();
                    chkVerWS.Checked = campos.VerenReporte;
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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAcumulacionDinero", "CargaInformacion()", "Ejecuta.CargaDetalleMecanica(" + IdMecanica + "," + TipoAcumulacion + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar Información, contacte al administrador");
            }
        }
        protected void CargaCombos()
        {
            AdministraPromocion ejecuta = new AdministraPromocion();
            int TipoAcum = 0;
            try
            {

                List<ModSegmento> lstResultados = new List<ModSegmento>();
                lstResultados = ejecuta.ObtenSegmentos(CnnProductivo);

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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAcumulacionDinero", "CargaCombos()", "ejecuta.ObtenSegmentos()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar segmentos, contacte al administrador");
            }

            try
            {
                TipoAcum = Convert.ToInt32(Request.QueryString["TipoAc"]);

                List<ModTipoPromocion> lstResultadosTP = new List<ModTipoPromocion>();
                lstResultadosTP = ejecuta.ObtenTipoPromocion(CnnProductivo, TipoAcum);

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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAcumulacionDinero", "CargaCombos()", "ejecuta.ObtenTipoPromocion(" + TipoAcum + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar TipoPromocion, contacte al administrador");
            }


            try
            {
                List<ModLimitePeriodo> lstResultadoslimPer = new List<ModLimitePeriodo>();
                lstResultadoslimPer = ejecuta.ObtenLimitePeriodo(CnnProductivo);

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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAcumulacionDinero", "CargaCombos()", "ejecuta.ObtenLimitePeriodo()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
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
        private void MantenerSoloRegistro()
        {
            ActivaControles(0);
        }
        private bool Modificar()
        {
            AdministraPromocion Ejecuta = new AdministraPromocion();
            bool blnRespuesta = false;
            string strFechaFin = "";
            string strFechaExt = "";
            //Promociones Iniciadas diferentes a M&M
            if (Request.QueryString["Est"] == "Iniciada")
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

                        Campos.IdPeriodo = Convert.ToInt32(rcbLimPeriodo.SelectedValue);
                        Campos.Limite = (string.IsNullOrWhiteSpace(txtlimcantidad.Text) ? 0 : Convert.ToInt32(txtlimcantidad.Text));
                        strFechaFin = rdpFFin.SelectedDate.ToString().Substring(0, 10) + " 23:59:59";
                        Campos.FechaFin = strFechaFin;

                        //Campos.FechaExtencion = "20190101 23:59:59"; //se pasa esta fecha aunque no sera considerada
                        //Campos.flagExtencion = 0;
                        if (chkAplicaExt.Checked)
                        {
                            strFechaExt = rdpFExt.SelectedDate.ToString().Substring(0, 10) + " 23:59:59";
                            Campos.FechaExtencion = strFechaExt;
                            Campos.flagExtencion = 1;
                        }
                        else
                        {
                            strFechaExt = "20190101 23:59:59";
                            Campos.FechaExtencion = strFechaExt; //se pasa esta fecha aunque no sera considerada
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
                        Campos.Usuario = HttpContext.Current.User.Identity.Name;
                        if (rdbEntregaSugeridosCierre.Checked)
                        {
                            Campos.CierreCiclosSugeridos = 0;
                        }
                        else if (rdbEntregaSugeridos.Checked)
                        {
                            Campos.CierreCiclosSugeridos = 1;
                        }

                        //Modifica en ambiente  Productivo
                        blnRespuesta = Ejecuta.ModificaPromocionesACDinero(CnnProductivo, Campos);
                        Campos.IdMecanica = Ejecuta.ObtenerEquivalenciamecanica(Campos.IdMecanica);
                        //Replicando cambios de ambiente productivo a pruebas
                        Ejecuta.ModificaPromocionesACDinero(CnnPruebas, Campos);
                    }
                    //Setea Laboratorios
                    foreach (GridViewRow cell in grvProd2.Rows)
                    {
                        TextBox txtcodIntEnt = (cell.Cells[0].FindControl("txtcod2") as TextBox);
                        RadComboBox cmbLab = (cell.Cells[3].FindControl("cmbLab") as RadComboBox);

                        //Setear laboratorio
                        ModsetNvasPromLaboratorio cmpLab = new ModsetNvasPromLaboratorio();
                        cmpLab.CodigoInterno = txtcodIntEnt.Text;
                        cmpLab.IdLaboratorio = Convert.ToInt32(cmbLab.SelectedValue);

                        //Se asocia laboratorio seleccionado a código interno
                        Ejecuta.GuardarnvoLaboratorio(CnnProductivo, cmpLab);
                    }
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAcumulacionDinero", "Modificar()", "Ejecuta.ModificaPromociones(" + Campos + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error al intentar guardar Promociones Iniciadas diferentes a Promoción  acumulación, contacte al administrador");
                }
            }
            else if (Request.QueryString["Est"] != "Iniciada" && rcbTipoPromocion.Text == "Acumula  $ A(lista) + B pieza")
            {
                //Promociones No Iniciadas Mix & Match
                ModPromocionesNoIniciadas Campos = new ModPromocionesNoIniciadas();
                string strCodInt = "";
                string strFechaIni = "";
                string strFechaConteo = "";
                string strCodIntEnt = "";


                try
                {
                    Campos.IdMecanica = Convert.ToInt32(Request.QueryString["Idmec"]);
                    foreach (GridViewRow reg in grvProd.Rows)
                    {
                        TextBox codInt = (reg.Cells[0].FindControl("txtcod") as TextBox);
                        TextBox nomProd = (reg.Cells[1].FindControl("txtNomProd") as TextBox);
                        //Se concatenan Codigos Internos delimitados por ","
                        if (strCodInt == "")
                        {
                            strCodInt = codInt.Text;
                        }
                        else
                        {
                            if (strCodInt.IndexOf(codInt.Text) == -1)
                            {
                                strCodInt = strCodInt + "," + codInt.Text;
                            }
                        }
                    }
                    string[] strcodigos = strCodInt.Split(',');


                    //Obtiene códigos Internos de beneficios
                    foreach (GridViewRow reg in grvProd2.Rows)
                    {
                        TextBox codIntEnt = (reg.Cells[0].FindControl("txtcod2") as TextBox);
                        //Se concatenan Codigos Internos delimitados por ","
                        if (strCodIntEnt == "")
                        {
                            strCodIntEnt = codIntEnt.Text;
                        }
                        else
                        {
                            if (strCodIntEnt.IndexOf(codIntEnt.Text) == -1)
                            {
                                strCodIntEnt = strCodIntEnt + "," + codIntEnt.Text;
                            }
                        }
                    }

                    Campos.CodigoInterno = strCodInt;
                    Campos.CodigoInternoEntrega = strCodIntEnt;
                    Campos.Lider = strcodigos[0].ToString();
                    Campos.NombrePromocion = txtNomProdACDinero.Text;
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

                    if (chkVerWS.Checked)
                    {
                        Campos.VerEnReporte = 1;
                    }
                    else
                    {
                        Campos.VerEnReporte = 0;
                    }

                    Campos.FechaFin = strFechaFin;
                    Campos.FechaConteo = strFechaConteo;
                    Campos.Comentarios = txtComentario.Text;
                    Campos.Usuario = HttpContext.Current.User.Identity.Name;
                    Campos.CantidadCompra = (string.IsNullOrWhiteSpace(txtcantcompra.Text) ? 0 : Convert.ToInt32(txtcantcompra.Text));
                    Campos.CantidadEntrega = (string.IsNullOrWhiteSpace(txtCantentrega.Text) ? 0 : Convert.ToInt32(txtCantentrega.Text));
                    Campos.CodigoBarras = strCodigoBarras.Value;

                    if (rdpFExt.SelectedDate == null)
                    {
                        Campos.flagExtension = 0;
                        Campos.FechaExtension = DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Month.ToString("00") + DateTime.Now.Date.Day.ToString("00") + " 00:00:00";
                    }
                    else
                    {
                        Campos.flagExtension = 1;
                        DateTime FEx = (DateTime)rdpFExt.SelectedDate;
                        Campos.FechaExtension = FEx.Year.ToString() + FEx.Month.ToString("00") + FEx.Day.ToString("00") + " 23:59:59";
                    }


                    blnRespuesta = Ejecuta.ModificaPromocionesACDineroNoIniciadas(CnnProductivo, Campos, "spU_PromocionProductivoAcumulacionDineroListas_NoIniciada_Update");
                    ////Replicando los cambios realizados en productivo a Pruebas
                    Ejecuta.ModificaPromocionesACDineroNoIniciadas(CnnPruebas, Campos, "spU_PromocionProductivoAcumulacionDineroListas_NoIniciada_Update");

                    //Setea Laboratorios
                    foreach (GridViewRow cell in grvProd.Rows)
                    {
                        TextBox txtcodInt = (cell.Cells[0].FindControl("txtcod") as TextBox);
                        RadComboBox cmbLab = (cell.Cells[3].FindControl("cmbLab") as RadComboBox);

                        //Setear laboratorio
                        ModsetNvasPromLaboratorio cmpLab = new ModsetNvasPromLaboratorio();
                        cmpLab.CodigoInterno = txtcodInt.Text;
                        cmpLab.IdLaboratorio = Convert.ToInt32(cmbLab.SelectedValue);

                        //Se asocia laboratorio seleccionado a código interno
                        Ejecuta.GuardarnvoLaboratorio(CnnProductivo, cmpLab);
                    }

                    foreach (GridViewRow cell in grvProd2.Rows)
                    {
                        TextBox txtcodIntEnt = (cell.Cells[0].FindControl("txtcod2") as TextBox);
                        RadComboBox cmbLab = (cell.Cells[3].FindControl("cmbLab") as RadComboBox);

                        //Setear laboratorio
                        ModsetNvasPromLaboratorio cmpLab = new ModsetNvasPromLaboratorio();
                        cmpLab.CodigoInterno = txtcodIntEnt.Text;
                        cmpLab.IdLaboratorio = Convert.ToInt32(cmbLab.SelectedValue);

                        //Se asocia laboratorio seleccionado a código interno
                        Ejecuta.GuardarnvoLaboratorio(CnnProductivo, cmpLab);
                    }
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatosAcumulacionDinero", "Modificar()", "Ejecuta.ModificaPromocionesNoIniciadas(" + Campos + ", sp_Promocion_ProduccionAcumulacionListas_NoIniciada_Update)", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error al intentar guardar promociones no iniciadas acumulación dinero, contacte al administrador");
                }
            }

            return blnRespuesta;
        }
        private void Activacontroles()
        {
            if (Request.QueryString["Est"] == "Iniciada")
            {   //Solo activa algunos controles
                rdpFFin.Enabled = true;
                rcbLimPeriodo.Enabled = true;
                txtlimcantidad.Enabled = true;
                txtComentario.Enabled = true;
                //pnlExtencion.Visible = true;
                chkVerWS.Enabled = true;
                chkAplicaExt.Enabled = true;
            }
            else if (Request.QueryString["Est"] != "Iniciada" && rcbTipoPromocion.Text == "Acumula  $ A(lista) + B pieza")
            {   //Activa todo
                txtNomProdACDinero.Enabled = true;
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
                chkAplicaExt.Enabled = true;
                if (!chkAplicaExt.Checked)
                {
                    lblFext.Visible = false;
                    rdpFExt.Visible = false;
                    rdpFExt.Enabled = false;
                }
                else
                {
                    lblFext.Visible = true;
                    rdpFExt.Visible = true;
                    rdpFExt.Enabled = true;
                }


                rdbEntregaSugeridosCierre.Enabled = true;
                rdbEntregaSugeridos.Enabled = true;



                chkVerWS.Enabled = true;


                lblNomProdMM.Visible = true;
                txtNomProdACDinero.Visible = true;
                txtNomProdACDinero.Enabled = true;
                grvProd.Enabled = true;
                grvProd.Columns[4].Visible = true;
                btnAgregar.Visible = true;

                grvProd2.Enabled = true;
                grvProd2.Columns[4].Visible = false;
                btnAgregar2.Visible = false;


                foreach (GridViewRow cell in grvProd.Rows)
                {
                    TextBox txtcodInt = (cell.Cells[0].FindControl("txtcod") as TextBox);
                    RadComboBox cmblab = (cell.Cells[0].FindControl("cmbLab") as RadComboBox);
                    TextBox txtcat = (cell.Cells[0].FindControl("lblIdCat") as TextBox);
                    txtcodInt.Enabled = true;
                    cmblab.Enabled = true;
                    txtcat.Enabled = false;
                }

                foreach (GridViewRow cell in grvProd2.Rows)
                {
                    TextBox txtcodIntEntrega = (cell.Cells[0].FindControl("txtcod2") as TextBox);
                    RadComboBox cmblab = (cell.Cells[0].FindControl("cmbLab") as RadComboBox);
                    TextBox txtcat = (cell.Cells[0].FindControl("lblIdCat") as TextBox);
                    txtcodIntEntrega.Enabled = true;
                    cmblab.Enabled = true;
                    //txtcat.Enabled = false;
                }
            }
        }

        private bool Validaciones()
        {
            bool blnRespuesta = true;

            if (Request.QueryString["Est"] != "Iniciada")
            {//Si aun no esta iniciada
                if (rdpFIni.SelectedDate == null)
                {
                    Mensajes("Es necesario proporcione una fecha inicio.");
                    rdpFIni.Clear();
                    rdpFIni.Focus();
                    return false;
                }

                if (rdpFIni.SelectedDate != null)
                {
                    if (rdpFIni.SelectedDate <= DateTime.Now)
                    {
                        Mensajes("No es posible que la fecha inicio sea menor e igual a la fecha actual.");
                        rdpFIni.Clear();
                        rdpFIni.Focus();
                        return false;
                    }

                    if (rdpFIni.SelectedDate > rdpFFin.SelectedDate)
                    {
                        Mensajes("No es posible que la fecha inicio sea mayor a la fecha fin.");
                        rdpFIni.Clear();
                        rdpFIni.Focus();
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

                if (rdpFConteo.SelectedDate != null)
                {
                    if (rdpFConteo.SelectedDate > rdpFIni.SelectedDate)
                    {
                        Mensajes("No es posible que la fecha conteo sea mayor a la fecha inicio.");
                        rdpFConteo.Clear();
                        rdpFConteo.Focus();
                        return false;
                    }
                }

                if (rdpFFin.SelectedDate.Value < DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null))
                {
                    Mensajes("La fecha fin no puede ser menor a la fecha actual...");
                    lblMensajeCancelacion.Text = "";
                    txtComentario.Text = "";
                    rdpFFin.SelectedDate = null;
                    rdpFFin.Focus();
                    return false;
                }


                if (rdpFFin.SelectedDate != null)
                {
                    if (rdpFFin.SelectedDate.Value.Year > (DateTime.Now.Year + 2))
                    {
                        Mensajes("No es posible que sea mayor a dos años posteriores.");
                        lblMensajeCancelacion.Text = "";
                        txtComentario.Text = "";
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
                        lblMensajeCancelacion.Text = "";
                        txtComentario.Text = "";
                        rdpFFin.Clear();
                        rdpFFin.Focus();
                        return false;
                    }
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
            }
            else
            {
                //Si ya se encuentra iniciada
                if (rdpFFin.SelectedDate.Value < DateTime.ParseExact(DateTime.Now.ToShortDateString(), "dd/MM/yyyy", null))
                {
                    Mensajes("La fecha fin no puede ser menor a la fecha actual...");
                    lblMensajeCancelacion.Text = "";
                    txtComentario.Text = "";
                    rdpFFin.SelectedDate = null;
                    rdpFFin.Focus();
                    return false;
                }


                if (rdpFFin.SelectedDate != null)
                {
                    if (rdpFFin.SelectedDate.Value.Year > (DateTime.Now.Year + 2))
                    {
                        Mensajes("No es posible que sea mayor a dos años posteriores.");
                        lblMensajeCancelacion.Text = "";
                        txtComentario.Text = "";
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
                        lblMensajeCancelacion.Text = "";
                        txtComentario.Text = "";
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

            if (rcbTipoPromocion.Text == "M&M")
            {
                if (string.IsNullOrWhiteSpace(txtNomProdACDinero.Text))
                {
                    Mensajes("Es necesario especifique un nombre para la promoción M&M.");
                    txtNomProdACDinero.Focus();
                    return false;
                }
            }

            foreach (GridViewRow cell in grvProd.Rows)
            {
                RadComboBox cmbLab = (cell.Cells[3].FindControl("cmbLab") as RadComboBox);
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
            }

            return blnRespuesta;
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



            //string[] sColumnas = { "CodigoInterno", "Categoria", "NomProducto", "Laboratorio" };
            string[] sColumnas = { "CodigoInterno" };
            //Devuelve registros unicos
            dtDistinct = DT.DefaultView.ToTable(true, sColumnas);
            //dtDistinct.Merge(DT, true);//Realiza unión entre dos tablas

            return dtDistinct;
        }
        private void ActivaControles(int nvoitm)
        {
            BloqueaControles();

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
        protected void chkAplicaExt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAplicaExt.Checked)
            {
                rdbEntregaSugeridosCierre.Enabled = true;
                rdbEntregaSugeridos.Enabled = true;
                lblFext.Visible = true;
                rdpFExt.Visible = true;
                rdpFExt.Enabled = true;
            }
            else
            {
                rdbEntregaSugeridosCierre.Enabled = false;
                rdbEntregaSugeridos.Enabled = false;
                lblFext.Visible = false;
                rdpFExt.Clear();
                rdpFExt.Visible = false;
                rdpFExt.Enabled = false;
            }
        }
    }
}