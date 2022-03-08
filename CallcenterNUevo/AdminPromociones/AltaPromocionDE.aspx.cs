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
    public partial class AltaPromocionDE : System.Web.UI.Page
    {
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
        }
        protected void grvProd_RowDataBound(object sender, GridViewRowEventArgs e)
        {

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
                    TextBox txtcat = (TextBox)row.FindControl("txtCat");
                    dr = dt1.NewRow();
                    dr[0] = txtcat.Text;
                    dr[1] = txtcodigo.Text.ToString();
                    dr[2] = txtProd.Text.ToString();
                    dr[3] = txtcat.Text;

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
            ModDatosGrid Resultados = new ModDatosGrid();
            TextBox codInt = new TextBox();
            TextBox categoria = new TextBox();
            TextBox nomProd = new TextBox();
            
            codInt.Text = "";

            try {
                foreach (GridViewRow row in this.grvProd.Rows)
                {
                    codInt = (row.Cells[0].FindControl("txtcod") as TextBox);

                    //Consulta en ambiente productivo
                    Resultados = Ejecuta.ValidaExistenciaCodInterno(CnnPruebas, codInt.Text);

                    //Valida la existencia del codigo interno
                    if (Resultados != null)
                    {
                        codInt = (row.Cells[0].FindControl("txtcod") as TextBox);
                        nomProd = (row.Cells[0].FindControl("txtNomProd") as TextBox);

                        codInt.Text = Resultados.codigointerno;
                        nomProd.Text = Resultados.nombreProducto;
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
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromocionDE", "txtcod_TextChange", "Ejecuta.ValidaExistenciaCodInterno(" + CnnPruebas + "," + codInt.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al validar la existencia del codigo interno, contacte al administrador");
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Nuevoregistro("A");
        }
        protected void rcbTipoPromocion_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LimpiarControles(1);
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
                }

                if (rdpFFin.SelectedDate != null)
                {
                    if (rdpFFin.SelectedDate.Value.Year > (DateTime.Now.Year + 2))
                    {
                        Mensajes("No es posible que la fecha fin sea mayor a dos años posteriores.");
                        rdpFFin.Clear();
                        rdpFFin.Focus();
                    }
                }
            }
        }
        protected void rdpFSolicitud_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {

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
                    Mensajes("La nueva promoción fue registrada correctamente.");
                    LimpiarControles(0);
                }
                else
                {
                    Mensajes("No fue posible registrar la alta de la nueva promoción.");
                }
            }
            catch(Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromocionDE", "btnGuardar_Click", "GuardarNvaPromocion(" + CnnPruebas + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar dar de alta la nueva promoción de dinero electrónico, contacte al administrador");
            }
        }



        protected void CargaCombos()
        {
            AdministraPromocion ejecuta = new AdministraPromocion();
            int TipoAcum = 0;

            try
            {
                //$ y %
                TipoAcum = 2;

                List<ModTipoPromocion> lstResultadosTP = new List<ModTipoPromocion>();
                lstResultadosTP = ejecuta.ObtenTipoPromocion(CnnPruebas,TipoAcum);

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
        }
        private bool GuardarNvaPromocion(string cnn) 
        {
            bool blnRespuesta = true;
            string strFechaIni = "";
            string strFechaFin = "";

            try
            {
                if (Validaciones())
                {
                    ModPromocionesDENoIniciadas campos = new ModPromocionesDENoIniciadas();
                    AdministraPromocion ejecuta = new AdministraPromocion();
                    TextBox txtcodInt = new TextBox();
                    TextBox txtnomProd = new TextBox();

                    foreach (GridViewRow cell in grvProd.Rows)
                    {
                        txtcodInt = (cell.Cells[0].FindControl("txtcod") as TextBox);
                        txtnomProd = (cell.Cells[0].FindControl("txtNomProd") as TextBox);
                    }

                    campos.IdTipoPromocion = Convert.ToInt32(rcbTipoPromocion.SelectedValue);
                    campos.CodigoInterno = txtcodInt.Text;
                    campos.Cantidad = (string.IsNullOrWhiteSpace(txtCantidad.Text) ? 0 : float.Parse(txtCantidad.Text));
                    campos.NombreMecanica = txtnomProd.Text;
                    strFechaIni = rdpFIni.SelectedDate.ToString();
                    strFechaIni = strFechaIni.Substring(0, 10) + " 00:00:00";
                    campos.FechaInicio = strFechaIni;
                    strFechaFin = rdpFFin.SelectedDate.ToString();
                    strFechaFin = strFechaFin.Substring(0, 10) + " 23:59:59";
                    campos.FechaFin = strFechaFin;
                    campos.Comentarios = txtComentario.Text;
                    campos.Usuario = HttpContext.Current.User.Identity.Name;
                    if (chkVerWS.Checked)
                    {
                        campos.VerEnReporte = 1;
                    }
                    else {
                        campos.VerEnReporte = 0;
                    }
                    blnRespuesta = ejecuta.GuardarPromocionesDEPorc(cnn, campos);
                }
                else 
                {
                    blnRespuesta = false;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromocionDE", "btnGuardar_Click()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar guardar la promoción, contacte al administrador");
                blnRespuesta = false;
            }
            return blnRespuesta;
        }
        private DataTable EstructuraProductos()
        {
            DataTable medidaTabla = new DataTable();
            medidaTabla.Columns.Add("CodigoInterno", typeof(string));
            medidaTabla.Columns.Add("NomProducto", typeof(string));
            return medidaTabla;
        }
        private void Nuevoregistro(string tipo)
        {

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
                    dt.Rows.Add(dr);
                    ViewState["DataTemp"] = dt;
                }
                else
                {
                    foreach (GridViewRow row in this.grvProd.Rows)
                    {
                        TextBox txtcodigo = (TextBox)row.FindControl("txtcod");
                        TextBox txtProd = (TextBox)row.FindControl("txtNomProd");
                        Label lblIdCat = (Label)row.FindControl("lblIdCat");
                        TextBox txtcat = (TextBox)row.FindControl("txtCat");

                        dr = dt.NewRow();
                        dr[0] = txtcodigo.Text.ToString();
                        dr[1] = txtProd.Text.ToString();

                        dt.Rows.Add(dr);
                        ViewState["DataTemp"] = dt;

                        if (string.IsNullOrWhiteSpace(txtcodigo.Text.ToString()) ||
                        string.IsNullOrWhiteSpace(txtProd.Text.ToString()) )
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
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
        private bool Validaciones()
        {
            bool blnRespuesta = true;

           

            if (rcbTipoPromocion.SelectedValue == "")
            {
                Mensajes("Imposible continuar, es necesario seleccione un tipo de promoción.");
                rcbTipoPromocion.Focus();
                return false;
            }

            foreach (GridViewRow cell in grvProd.Rows)
            {
                TextBox txtcod = (cell.Cells[0].FindControl("txtcod") as TextBox);

                if (string.IsNullOrWhiteSpace(txtcod.Text))
                {
                    Mensajes("Imposible continuar, es necesario proporcione un código interno.");
                    txtcod.Focus();
                    return false;
                }
            }//fin foreach

            if(string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                Mensajes("Imposible continuar, es necesario proporcione una cantidad.");
                txtCantidad.Focus();
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
            ModValidaPromocion campos = new ModValidaPromocion();
            AdministraPromocion Ejecuta = new AdministraPromocion();

            foreach (GridViewRow cell in grvProd.Rows)
            {
                txtcodInt = (cell.Cells[0].FindControl("txtcod") as TextBox);
            }

            campos.CodigoInterno = txtcodInt.Text;
            strFechaIni = rdpFIni.SelectedDate.ToString().Substring(0, 10);
            strFechaIni = strFechaIni + " 00:00:00";
            campos.FechaInicio = strFechaIni;
            strFechaFin = rdpFFin.SelectedDate.ToString().Substring(0, 10);
            strFechaFin = strFechaFin + " 23:59:59";
            campos.FechaFin = strFechaFin;
            campos.IdTipoacumulacion = 2;

            intResultado = Ejecuta.ValidaPromocion(CnnProductivo, campos);
            if (intResultado == 0)
            {
                Mensajes("Imposible continuar,  porque ya existe alguna mecánica ligada en ambiente productivo.");
                grvProd.Focus();
                return false;
            }
            intResultado = Ejecuta.ValidaPromocion(CnnPruebas, campos);
            if (intResultado == 0)
            {
                Mensajes("Imposible continuar,  porque ya existe alguna mecánica ligada en ambiente de pruebas.");
                grvProd.Focus();
                return false;
            }
            //===================================================================================================================

            return blnRespuesta;
        }
        private void LimpiarControles(int selTipoProm)
        {
            DataTable DT = new DataTable();

            if (selTipoProm != 1)
            {
                rcbTipoPromocion.ClearSelection();
            }
            
            DT = ResetGrid();
            ViewState["DataTemp"] = DT;
            grvProd.DataSource = ViewState["DataTemp"];
            grvProd.DataBind();

            foreach (GridViewRow cell in grvProd.Rows) 
            {
                TextBox txtcod = (cell.Cells[0].FindControl("txtcod") as TextBox);
                TextBox txtNomProd = (cell.Cells[0].FindControl("txtNomProd") as TextBox);

                txtcod.Text = "";
                txtNomProd.Enabled = false;
            }

            rdpFSolicitud.SelectedDate = DateTime.Now.Date;
            rdpFIni.SelectedDate = null;
            rdpFFin.SelectedDate = null;
            txtCantidad.Text = "";
            txtComentario.Text = "";
            chkVerWS.Checked = true;
        }
        private DataTable ResetGrid()
        {
            DataTable dt = null;
            dt = EstructuraProductos();
            DataRow dr;
            dr = dt.NewRow();
            dr[0] = "";
            dr[1] = "";
            dt.Rows.Add(dr);

            return dt;
        }
    }
}