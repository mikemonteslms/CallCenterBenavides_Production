using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Datos;

namespace CallcenterNUevo.AdminPromociones
{
    public partial class AltaPromocionEscalonada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (grvCupones.Rows.Count == 0)
                {
                    NuevoregistroCupones();
                }
            }
        }
        protected void rdpFechaInicio_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFechaInicio.SelectedDate.Value != null)
            {
                if (rdpFechaInicio.SelectedDate < DateTime.Now.Date)
                {
                    Mensajes("No es posible que la fecha inicio sea menor a la fecha actual.");
                    rdpFechaInicio.Clear();
                    rdpFechaInicio.Focus();
                }
                else
                {
                    rdpFechaFin.Focus();
                }
            }
        }
        protected void rdpFechaFin_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (rdpFechaFin.SelectedDate.Value != null)
            {
                if (rdpFechaFin.SelectedDate < rdpFechaInicio.SelectedDate)
                {
                    Mensajes("No es posible que la fecha fin sea menor a la fecha inicio.");
                    rdpFechaFin.Clear();
                    rdpFechaFin.Focus();
                }
                else
                {
                    chkDuracion.Focus();
                }
            }
        }

        protected void txtDuracionCupon_TextChanged(object sender, EventArgs e)
        {

        }
        protected void chkDuracion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDuracion.Checked)
            {
                txtDuracionCupon.Visible = true;
                txtDuracionCupon.Focus();
            }
            else
            {
                txtDuracionCupon.Text = "";
                txtDuracionCupon.Visible = false;
                txtDuracionCupon.Focus();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validaciones())
                {
                    if (GuardarNuevaPromoEscalonada())
                    {
                        Mensajes("La promoción escalonada se registro correctamente.");
                        LimpiarCampos();
                    }
                    else
                    {
                        Mensajes("No fue posible guardar la promoción valide su información e intente de nuevo.");
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AltaPromocionEscalonada", "btnGuardar_Click", "GuardarNuevaPromoEscalonada()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar guardar la promoción, contacte al administrador.");
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MuestraPromoEscalonada.aspx");
        }
        protected void btnAgregarElementos_Click(object sender, EventArgs e)
        {
            NuevoregistroCupones();
        }


        private bool Validaciones()
        {
            bool blnRespuesta = true;
            AdministraPromocion Ejecutar = new AdministraPromocion();
            TextBox txtCupon = new TextBox();
            TextBox txtIdPromo = new TextBox();
            TextBox txtIdPromoDispara = new TextBox();
            TextBox txtMensajePOS = new TextBox();


            if (rdpFechaInicio.SelectedDate == null)
            {
                Mensajes("Imposible continuar, es necesario proporcione la fecha inicio.");
                rdpFechaInicio.Focus();
                return false;
            }

            if (rdpFechaFin.SelectedDate == null)
            {
                Mensajes("Imposible continuar, es necesario proporcione la fecha fin.");
                rdpFechaFin.Focus();
                return false;
            }

            if (rdbSi.Checked)
            {
                if (rcmbUso.SelectedValue == "-1")
                {
                    Mensajes("Imposible continuar, es necesario seleccione un tipo de uso.");
                    rcmbUso.Focus();
                    return false;
                }
            }


            //Valida que cuente con información
            int intContador = 0;
            foreach (GridViewRow cell in grvCupones.Rows)
            {
                txtCupon = (cell.Cells[0].FindControl("txtCupon") as TextBox);
                txtIdPromo = (cell.Cells[0].FindControl("txtIdPromocion") as TextBox);
                txtIdPromoDispara = (cell.Cells[0].FindControl("txtIdPromoDispara") as TextBox);
                txtMensajePOS = (cell.Cells[0].FindControl("txtMensajePOS") as TextBox);

                if (string.IsNullOrWhiteSpace(txtCupon.Text) && string.IsNullOrWhiteSpace(txtIdPromo.Text) && string.IsNullOrWhiteSpace(txtIdPromoDispara.Text) && string.IsNullOrWhiteSpace(txtMensajePOS.Text) ||
                    string.IsNullOrWhiteSpace(txtCupon.Text) || string.IsNullOrWhiteSpace(txtIdPromo.Text) || string.IsNullOrWhiteSpace(txtIdPromoDispara.Text) || string.IsNullOrWhiteSpace(txtMensajePOS.Text))
                {   //Si no se encontro información 
                    if (intContador == 0)
                    {
                        blnRespuesta = false;
                        Mensajes("Es necesario ingrese un Cupón , Idpromocion, IdpromoDispara y el mensajePOS.");
                        txtCupon.Focus();
                        return blnRespuesta;
                    }
                }
                intContador += 1;
            }
            //========================================================================================


            //Valida  Promoción vigencia
            int intIdPromo = 0;
            int intIdPromoDispara = 0;
            DateTime FIni;
            DateTime FFin;
            FIni = (DateTime)rdpFechaInicio.SelectedDate;
            FFin = (DateTime)rdpFechaFin.SelectedDate;

            foreach (GridViewRow cell in grvCupones.Rows)
            {
                txtCupon = (cell.Cells[0].FindControl("txtcupon") as TextBox);
                txtIdPromo = (cell.Cells[0].FindControl("txtIdPromocion") as TextBox);
                txtIdPromoDispara = (cell.Cells[0].FindControl("txtIdPromoDispara") as TextBox);

                if (!string.IsNullOrWhiteSpace(txtIdPromo.Text))
                {
                    intIdPromo = Convert.ToInt32(txtIdPromo.Text);
                }

                if (!string.IsNullOrWhiteSpace(txtIdPromoDispara.Text))
                {
                    intIdPromoDispara = Convert.ToInt32(txtIdPromoDispara.Text);
                }

                if (!string.IsNullOrWhiteSpace(txtCupon.Text) && !string.IsNullOrWhiteSpace(txtIdPromo.Text) && !string.IsNullOrWhiteSpace(txtMensajePOS.Text))
                {
                    blnRespuesta = Ejecutar.ValidaExistenciaPromoEscVigencia(txtCupon.Text, intIdPromo, FIni, FFin);
                    if (blnRespuesta)
                    {   //Si existe retorna falso 
                        blnRespuesta = false;
                        Mensajes("Imposible continuar,  porque la promoción: " + txtIdPromo.Text + " ya existe o se encuentra dentro del rango de vigencia.");
                        txtIdPromo.Focus();
                        return blnRespuesta;
                    }
                    else
                    {
                        blnRespuesta = true;
                    }
                }
            }
            //========================================================================================

            if (chkEsPromoTrigger.Checked)
            {
                if (!rdbMontoTrigger.Checked && !rdbcodInt.Checked)
                {
                    blnRespuesta = false;
                    Mensajes("Es necesario seleccione una opción.");
                    rdbMontoTrigger.Focus();
                    return blnRespuesta;
                }

                if (rdbMontoTrigger.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtMontoTrigger.Text))
                    {
                        blnRespuesta = false;
                        Mensajes("Es necesario proporcionar un monto trigger.");
                        txtMontoTrigger.Focus();
                        return blnRespuesta;
                    }
                }

                if (rdbcodInt.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtCodigoInterno.Text))
                    {
                        blnRespuesta = false;
                        Mensajes("Es necesario proporcionar un código interno.");
                        txtCodigoInterno.Focus();
                        return blnRespuesta;
                    }
                }
            }

            return blnRespuesta;
        }
        private DataTable EstructuraPromos()
        {
            DataTable medidaTabla = new DataTable();

            medidaTabla.Columns.Add("Cupon", typeof(string));
            medidaTabla.Columns.Add("IdPromocion", typeof(string));
            medidaTabla.Columns.Add("IdPromocionDispara", typeof(string));
            medidaTabla.Columns.Add("MensajePOS", typeof(string));

            return medidaTabla;
        }
        private void NuevoregistroCupones()
        {
            int CuentaRegVacios = 0;
            TextBox txtCupon;
            TextBox txtIdPromocion;
            TextBox txtIdPromocionDispara;
            TextBox txtMensajePOS;

            DataTable dt = null;
            dt = EstructuraPromos();
            DataRow dr;

            foreach (GridViewRow row in this.grvCupones.Rows)
            {
                txtCupon = (TextBox)row.FindControl("txtCupon");
                txtIdPromocion = (TextBox)row.FindControl("txtIdPromocion");
                txtIdPromocionDispara = (TextBox)row.FindControl("txtIdPromoDispara");
                txtMensajePOS = (TextBox)row.FindControl("txtMensajePOS");

                dr = dt.NewRow();
                dr[0] = txtCupon.Text;
                dr[1] = txtIdPromocion.Text;
                dr[2] = txtIdPromocionDispara.Text;
                dr[3] = txtMensajePOS.Text;

                dt.Rows.Add(dr);
                ViewState["DataTemp"] = dt;

                if (
                string.IsNullOrWhiteSpace(txtCupon.Text.ToString()) ||
                string.IsNullOrWhiteSpace(txtIdPromocion.Text.ToString()) ||
                string.IsNullOrWhiteSpace(txtMensajePOS.Text) ||
                string.IsNullOrWhiteSpace(txtIdPromocionDispara.Text))
                {
                    CuentaRegVacios += 1;
                }
                else
                {
                    CuentaRegVacios += 0;
                }
            }
            if (CuentaRegVacios == 0)
            {
                dr = dt.NewRow();
                dr[0] = "";
                dr[1] = "";
                dr[2] = "";
                dr[3] = "";

                dt.Rows.Add(dr);
            }
            else
            {   //En caso de detectar campos vacios dentro de una fila
                Mensajes("No debe dejar filas y/o celdas vacias.");
            }

            ViewState["DataTemp"] = dt;
            this.grvCupones.DataSource = ViewState["DataTemp"];
            this.grvCupones.DataBind();
        }
        private bool GuardarNuevaPromoEscalonada()
        {
            bool blnRespuesta = false;
            string Identificador = "";

            AdministraPromocion Ejecutar = new AdministraPromocion();
            ModPromoEscalonada campos = new ModPromoEscalonada();
            int contar = 1;

            try
            {
                foreach (GridViewRow cell in grvCupones.Rows)
                {

                    TextBox txtCupon = (cell.Cells[0].FindControl("txtCupon") as TextBox);
                    TextBox txtIdPromo = (cell.Cells[0].FindControl("txtIdPromocion") as TextBox);
                    TextBox txtIdPromoDispara = (cell.Cells[0].FindControl("txtIdPromoDispara") as TextBox);
                    TextBox txtMensajePOS = (cell.Cells[0].FindControl("txtMensajePOS") as TextBox);

                    if (!string.IsNullOrWhiteSpace(txtCupon.Text) && !string.IsNullOrWhiteSpace(txtIdPromo.Text) && !string.IsNullOrWhiteSpace(txtMensajePOS.Text))
                    {
                        campos.Cupon = txtCupon.Text;
                        campos.IdPromocion = Convert.ToInt32(txtIdPromo.Text);
                        campos.IdPromocionDispara = Convert.ToInt32(txtIdPromoDispara.Text);
                        campos.FechaIni = (DateTime)rdpFechaInicio.SelectedDate;
                        campos.FechaFin = (DateTime)rdpFechaFin.SelectedDate;
                        campos.MensajePOS = txtMensajePOS.Text;
                        campos.Orden = contar;
                        campos.Identificador = Identificador;
                        //Si no fue asignado ningun valor por default será 0
                        if (string.IsNullOrWhiteSpace(txtDuracionCupon.Text))
                        {
                            txtDuracionCupon.Text = "0";
                        }
                        campos.DuracionCupon = Convert.ToInt32(txtDuracionCupon.Text);
                        if (rdbNo.Checked)
                        {
                            campos.RetrocederEscalon = 0;
                            campos.RetornoIlimitado = 0;
                        }

                        if (rdbSi.Checked)
                        {
                            campos.RetrocederEscalon = 1;
                            campos.RetornoIlimitado = Convert.ToInt32(rcmbUso.SelectedValue);
                        }


                        if (rdbRetornoAnterior.Checked)
                        {
                            campos.RetornoInicio = 0;
                        }

                        if (rdbRetornoIni.Checked)
                        {
                            campos.RetornoInicio = 1;
                        }


                        //**************************************************************************
                        if (chkEsPromoTrigger.Checked)
                        {
                            campos.EsPromoTrigger = 1;
                            if (rdbMontoTrigger.Checked)
                            {
                                campos.CodigoInterno = ""; //Esto se convierte en null en el SP
                                campos.MontoTrigger = float.Parse(txtMontoTrigger.Text);
                            }
                            if (rdbcodInt.Checked)
                            {
                                campos.MontoTrigger = float.Parse("0");
                                campos.CodigoInterno = txtCodigoInterno.Text;
                            }
                        }
                        else if (!chkEsPromoTrigger.Checked)
                        {
                            campos.EsPromoTrigger = 0;
                            campos.CodigoInterno = ""; //Esto se convierte en null en el SP
                            campos.MontoTrigger = float.Parse("0");
                        }
                        //**************************************************************************

                        Identificador = Ejecutar.GuardarNuevaPromoEscalonada(campos);
                        if (!string.IsNullOrWhiteSpace(Identificador))
                        {
                            blnRespuesta = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                    contar += 1;
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
            rdpFechaInicio.SelectedDate = null;
            rdpFechaFin.SelectedDate = null;
            lblUso.Visible = false;
            rcmbUso.Visible = false;
            rcmbUso.SelectedIndex = -1;
            rcmbUso.SelectedText = "";
            chkDuracion.Checked = false;
            txtDuracionCupon.Text = "";
            txtDuracionCupon.Visible = false;
            grvCupones.DataSource = null;
            grvCupones.DataBind();
            NuevoregistroCupones();
            rdpFechaInicio.Focus();
            rdbNo.Checked = true;
            rdbSi.Checked = false;
            rdbRetornoIni.Checked = false;
            rdbRetornoAnterior.Checked = true;
            lblRetornoInicial.Visible = false;
            rdbRetornoAnterior.Visible = false;
            rdbRetornoIni.Visible = false;
            chkEsPromoTrigger.Checked = false;
            lblMontoTrigger.Visible = false;
            txtMontoTrigger.Text = "";
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        //protected void rdbSi_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdbSi.Checked)
        //    {
        //        lblUso.Visible = true;
        //        rcmbUso.Visible = true;
        //    }
        //    else
        //    {
        //        lblUso.Visible = false;
        //        rcmbUso.Visible = false;
        //        rcmbUso.SelectedIndex = -1;
        //        rcmbUso.SelectedText = "";
        //    }
        //}

        protected void rdbNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNo.Checked)
            {
                lblUso.Visible = false;
                rcmbUso.Visible = false;
                rcmbUso.SelectedIndex = -1;
                rcmbUso.SelectedText = "";

                rdbRetornoIni.Checked = false;
                rdbRetornoAnterior.Checked = true;

                lblRetornoInicial.Visible = false;
                rdbRetornoIni.Visible = false;
                rdbRetornoAnterior.Visible = false;
            }
        }

        protected void rdbSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSi.Checked)
            {
                lblUso.Visible = true;
                rcmbUso.Visible = true;

                rdbRetornoIni.Checked = false;
                rdbRetornoAnterior.Checked = true;

                lblRetornoInicial.Visible = true;
                rdbRetornoIni.Visible = true;
                rdbRetornoAnterior.Visible = true;
            }
            else
            {
                lblUso.Visible = false;
                rcmbUso.Visible = false;
                rcmbUso.SelectedIndex = -1;
                rcmbUso.SelectedText = "";

                lblRetornoInicial.Visible = false;
                rdbRetornoIni.Visible = false;
                rdbRetornoAnterior.Visible = false;

                rdbRetornoIni.Checked = false;
                rdbRetornoAnterior.Checked = true;
            }
        }

        protected void chkEsPromoTrigger_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEsPromoTrigger.Checked)
            {
                lblMontoTrigger.Visible = true;
                rdbMontoTrigger.Visible = true;
                lblCodInt.Visible = true;
                rdbcodInt.Visible = true;
            }
            else
            {
                lblMontoTrigger.Visible = false;
                rdbMontoTrigger.Checked = false;
                rdbMontoTrigger.Visible = false;
                lblCodInt.Visible = false;
                rdbcodInt.Checked = false;
                rdbcodInt.Visible = false;
                txtMontoTrigger.Text = "";
                txtMontoTrigger.Visible = false;
                txtCodigoInterno.Visible = false;
                txtCodigoInterno.Text = "";
            }
        }

        protected void rdbMontoTrigger_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMontoTrigger.Checked)
            {
                txtCodigoInterno.Visible = false;
                txtCodigoInterno.Text = "";
                txtMontoTrigger.Text = "";
                txtMontoTrigger.Visible = true;
                txtMontoTrigger.Focus();
            }
        }

        protected void rdbcodInt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbcodInt.Checked)
            {
                txtMontoTrigger.Text = "";
                txtMontoTrigger.Visible = false;
                txtCodigoInterno.Visible = true;
                txtCodigoInterno.Text = "";
                txtCodigoInterno.Focus();

            }
        }



        //protected void rdbNo_CheckedChanged1(object sender, EventArgs e)
        //{
        //    if (rdbNo.Checked)
        //    {
        //        lblUso.Visible = false;
        //        rcmbUso.Visible = false;
        //        rcmbUso.SelectedValue = "-1";
        //        rcmbUso.SelectedText = "";
        //    }
        //}

    }
}