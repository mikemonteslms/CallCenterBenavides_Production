using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Datos;

namespace CallcenterNUevo.AdminPromociones
{
    public partial class MuestraPromoEscalonada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            }
        }
        protected void grvDatos_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            List<ModPromoEscalonada> lstPromEsc = new List<ModPromoEscalonada>();
            lstPromEsc = (List<ModPromoEscalonada>)Session["lstPromoEsc"];
            string Identificador = "";

            Identificador = e.CommandArgument.ToString();

            //Se forza a limpiar Variable de session para asegurar que nos e quede con valores previos
            Session.Contents.Remove("Identificador");
            Session.Remove("Identificador");

            //Se crea la variable de session
            Session.Add("Identificador", Identificador);

            switch (e.CommandName.ToString())
            {
                case "VerDetalle":
                    CargaInformacion(Identificador);

                    //Muestra formulario
                    mvPromEsc.SetActiveView(vEditaPromocionEscalonada);
                    break;

                case "Eliminar":
                    mpeDelete.Show();
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                    break;
            }
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


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            AdministraPromocion Ejecutar = new AdministraPromocion();
            List<ModPromoEscalonada> lstPromoEsc = new List<ModPromoEscalonada>();
            try
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.MuestraPromoEscalonada", "btnBuscar_Click", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
                lstPromoEsc = Ejecutar.ObtenerPromocionesEscalonadas(txtNomPromEscalonada.Text.Trim());
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.MuestraPromoEscalonada", "btnBuscar_Click", "Fin de Consulta", this.User.Identity.Name.ToString(), null);

                if (lstPromoEsc.Count > 0)
                {
                    //Eliminamos variable para evitar se quede con rersultados previos
                    Session.Contents.Remove("lstPromoEsc");
                    Session.Remove("lstPromoEsc");

                    //Se crea la variable de session
                    Session.Add("lstPromoEsc", lstPromoEsc);

                    grvDatos.DataSource = lstPromoEsc;
                    grvDatos.DataBind();
                }
                else
                {
                    grvDatos.DataSource = lstPromoEsc;
                    grvDatos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraPromoEscalonada", "btnBuscar_Click", "Ejecutar.ObtenerPromocionesEscalonadas(" + txtNomPromEscalonada.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al realizar la busqueda, contacte al administrador.");
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validaciones(Session["Identificador"].ToString()))
                {
                    if (ModificarPromoEscalonada())
                    {
                        Mensajes("La promoción fue modificada correctamente.");
                        LimpiarCampos();
                        mvPromEsc.SetActiveView(vConsultaModificaPromoEscalonada);
                    }
                    else
                    {
                        Mensajes("Ocurrio un error al intentar modificar la promoción Valide su información e intente de nuevo.");
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraPromoEscalonada", "btnGuardar_Click", "ModificarPromoEscalonada()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar modificar la promoción, contacte al administrador.");
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("Identificador");
            Session.Remove("Identificador");
            Session.Contents.Remove("memFechaInicio");
            Session.Remove("memFechaInicio");
            Session.Contents.Remove("memFechaFin");
            Session.Remove("memFechaFin");

            txtNomPromEscalonada.Text = "";
            grvDatos.DataSource = null;
            grvDatos.DataBind();
            txtNomPromEscalonada.Focus();
            mvPromEsc.SetActiveView(vConsultaModificaPromoEscalonada);
        }
        protected void btnAgregarElementos_Click(object sender, EventArgs e)
        {
            NuevoregistroCupones();
        }
        protected void btnSi_Click(object sender, EventArgs e)
        {
            AdministraPromocion Ejecuta = new AdministraPromocion();
            bool blnRespuesta = false;

            try
            {
                blnRespuesta = Ejecuta.EliminarPromocionEscalonada(Session["Identificador"].ToString());
                if (blnRespuesta)
                {
                    Mensajes("La promoción fue eliminada correctamente.");
                    btnBuscar_Click(null, null);
                }
                else
                {
                    Mensajes("No fue posible eliminar la promoción.");
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraPromoEscalonada", "btnSi_Click", "Ejecuta.EliminarPromocionEscalonada(" + Session["Identificador"].ToString() + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar eliminar la promoción, contacte al administrador.");
            }
        }


        private void CargaInformacion(string Identificador)
        {
            AdministraPromocion Ejecutar = new AdministraPromocion();
            List<ModPromoEscalonada> lstRespuesta = new List<ModPromoEscalonada>();
            lstRespuesta = Ejecutar.ObtenerPromocionesEscalonadasDetalle(Identificador);

            rdpFechaInicio.SelectedDate = lstRespuesta[0].FechaIni;
            rdpFechaFin.SelectedDate = lstRespuesta[0].FechaFin;
            if (lstRespuesta[0].RetrocederEscalon == 0)
            {
                rdbNo.Checked = true;
                lblUso.Visible = false;
                rcmbUso.SelectedIndex = -1;
                rcmbUso.SelectedText = "";
                rcmbUso.Visible = false;
                rdbSi.Checked = false;
            }

            if (lstRespuesta[0].RetrocederEscalon == 1)
            {
                rdbNo.Checked = false;
                rdbSi.Checked = true;
                if (!string.IsNullOrWhiteSpace(lstRespuesta[0].RetornoIlimitado.ToString()))
                {
                    lblUso.Visible = true;
                    rcmbUso.SelectedValue = lstRespuesta[0].RetornoIlimitado.ToString();
                    rcmbUso.Visible = true;
                }



                if (lstRespuesta[0].RetornoInicio == 1)
                {
                    lblRetornoInicial.Visible = true;
                    rdbRetornoIni.Visible = true;
                    rdbRetornoAnterior.Visible = true;

                    rdbRetornoAnterior.Checked = false;
                    rdbRetornoIni.Checked = true;

                }

                if (lstRespuesta[0].RetornoInicio == 0)
                {
                    lblRetornoInicial.Visible = true;
                    rdbRetornoIni.Visible = true;
                    rdbRetornoAnterior.Visible = true;


                    rdbRetornoIni.Checked = false;
                    rdbRetornoAnterior.Checked = true;
                }


            }





            if (lstRespuesta[0].DuracionCupon == 0)
            {
                chkDuracion.Checked = false;
                txtDuracionCupon.Text = "";
                txtDuracionCupon.Visible = false;
            }
            else
            {
                chkDuracion.Checked = true;
                txtDuracionCupon.Text = lstRespuesta[0].DuracionCupon.ToString();
                txtDuracionCupon.Visible = true;
            }


            if (lstRespuesta[0].EsPromoTrigger == 1)
            {
                chkEsPromoTrigger.Checked = true;
                lblMontoTrigger.Visible = true;
                rdbMontoTrigger.Visible = true;
                lblCodInt.Visible = true;
                rdbcodInt.Visible = true;

                if (lstRespuesta[0].MontoTrigger != 0.00)
                {
                    rdbMontoTrigger.Checked = true;
                    txtMontoTrigger.Text = lstRespuesta[0].MontoTrigger.ToString();
                    txtMontoTrigger.Visible = true;
                }

                if (!string.IsNullOrWhiteSpace(lstRespuesta[0].CodigoInterno))
                {
                    rdbcodInt.Checked = true;
                    txtCodigoInterno.Text = lstRespuesta[0].CodigoInterno.ToString();
                    txtCodigoInterno.Visible = true;
                }
            }
            else
            {
                chkEsPromoTrigger.Checked = false;
                lblMontoTrigger.Visible = false;
                txtMontoTrigger.Text = "";
                txtMontoTrigger.Visible = false;
            }


            Session.Add("memFechaInicio", rdpFechaInicio.SelectedDate);
            Session.Add("memFechaFin", rdpFechaFin.SelectedDate);

            grvCupones.DataSource = lstRespuesta;
            grvCupones.DataBind();
            rdpFechaInicio.Focus();
        }
        private bool Validaciones(string Identificador)
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


            //if (rdpFechaInicio.SelectedDate != null)
            //{
            //    if (rdpFechaInicio.SelectedDate < DateTime.Now.Date)
            //    {
            //        Mensajes("No es posible que la fecha inicio sea menor a la fecha actual.");
            //        rdpFechaInicio.Clear();
            //        rdpFechaInicio.Focus();
            //        return false;
            //    }
            //}


            if (rdpFechaFin.SelectedDate != null)
            {
                if (rdpFechaFin.SelectedDate < rdpFechaInicio.SelectedDate)
                {
                    Mensajes("No es posible que la fecha fin sea menor  a la fecha inicio.");
                    rdpFechaFin.Clear();
                    rdpFechaFin.Focus();
                    return false;
                }
            }


            if (rdpFechaFin.SelectedDate != null)
            {
                if (rdpFechaFin.SelectedDate.Value.Year > (DateTime.Now.Year + 2))
                {
                    Mensajes("No es posible que la fecha fin sea mayor a dos años posteriores.");
                    rdpFechaFin.Clear();
                    rdpFechaFin.Focus();
                    return false;
                }
            }


            if (rdbSi.Checked)
            {
                if (rcmbUso.SelectedValue == "-1")
                {
                    Mensajes("Imposible continuar, debe seleccionar un tipo de uso.");
                    rcmbUso.Focus();
                    return false;
                }
            }

            //Valida que cuente con información
            foreach (GridViewRow cell in grvCupones.Rows)
            {
                txtCupon = (cell.Cells[0].FindControl("txtCupon") as TextBox);
                txtIdPromo = (cell.Cells[0].FindControl("txtIdPromocion") as TextBox);
                txtIdPromoDispara = (cell.Cells[0].FindControl("txtIdPromoDispara") as TextBox);
                txtMensajePOS = (cell.Cells[0].FindControl("txtMensajePOS") as TextBox);

                if (string.IsNullOrWhiteSpace(txtCupon.Text) && string.IsNullOrWhiteSpace(txtIdPromo.Text) && string.IsNullOrWhiteSpace(txtIdPromoDispara.Text) && string.IsNullOrWhiteSpace(txtMensajePOS.Text) ||
                    string.IsNullOrWhiteSpace(txtCupon.Text) || string.IsNullOrWhiteSpace(txtIdPromo.Text) || string.IsNullOrWhiteSpace(txtIdPromoDispara.Text) || string.IsNullOrWhiteSpace(txtMensajePOS.Text))
                {   //Si no se encontro información 
                    blnRespuesta = false;
                    Mensajes("Es necesario ingrese un Cupón , Idpromocion, IdpromocionDispara y el mensajePOS.");
                    txtCupon.Focus();
                    return blnRespuesta;
                }
            }
            //========================================================================================

            //Valida Promoción vigencia
            DateTime memFechaIni;
            DateTime memFechaFin;

            memFechaIni = (DateTime)Session["memFechaInicio"];
            memFechaFin = (DateTime)Session["memFechaFin"];


            int intIdPromo = 0;
            int intIdPromoDispara = 0;
            DateTime FIni;
            DateTime FFin;
            FIni = (DateTime)rdpFechaInicio.SelectedDate;
            FFin = (DateTime)rdpFechaFin.SelectedDate;

            foreach (GridViewRow cell in grvCupones.Rows)
            {
                TextBox txtId = (cell.Cells[0].FindControl("txtId") as TextBox);
                txtCupon = (cell.Cells[0].FindControl("txtCupon") as TextBox);
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

                //if (memFechaIni != rdpFechaInicio.SelectedDate && memFechaFin != rdpFechaFin.SelectedDate ||
                //memFechaIni != rdpFechaInicio.SelectedDate || memFechaFin != rdpFechaFin.SelectedDate)

                if (txtId.Text == "0")//Cuando es un nuevo registro validara
                {
                    blnRespuesta = Ejecutar.ValidaExistenciaPromoEscVigencia(txtCupon.Text, intIdPromo, FIni, FFin);
                    if (blnRespuesta)
                    {   //Si existe retorna falso 
                        blnRespuesta = false;
                        Mensajes("Imposible continuar,  porque la promoción: " + txtIdPromo.Text + " con cupón: " + txtCupon.Text + " ya existe o se encuentra dentro del rango de vigencia.");
                        txtIdPromo.Focus();
                        return blnRespuesta;
                    }
                    else
                    {
                        blnRespuesta = true;
                    }
                }
            }
            ////========================================================================================

            return blnRespuesta;
        }
        private DataTable EstructuraCupones()
        {
            DataTable medidaTabla = new DataTable();

            medidaTabla.Columns.Add("Id", typeof(int));
            medidaTabla.Columns.Add("Cupon", typeof(string));
            medidaTabla.Columns.Add("IdPromocion", typeof(string));
            medidaTabla.Columns.Add("IdPromocionDispara", typeof(string));
            medidaTabla.Columns.Add("MensajePOS", typeof(string));
            medidaTabla.Columns.Add("IdStatus", typeof(string));

            return medidaTabla;
        }
        private void NuevoregistroCupones()
        {
            int CuentaRegVacios = 0;
            TextBox txtCupon;
            TextBox txtIdPromocion;
            TextBox txtIdPromocionDispara;
            TextBox txtMensajePOS;
            TextBox txtId;
            CheckBox chkCupones;

            DataTable dt = null;
            dt = EstructuraCupones();
            DataRow dr;

            foreach (GridViewRow row in this.grvCupones.Rows)
            {
                txtCupon = (TextBox)row.FindControl("txtCupon");
                txtIdPromocion = (TextBox)row.FindControl("txtIdPromocion");
                txtIdPromocionDispara = (TextBox)row.FindControl("txtIdPromoDispara");
                txtMensajePOS = (TextBox)row.FindControl("txtMensajePOS");
                txtId = (TextBox)row.FindControl("txtId");
                chkCupones = (CheckBox)row.FindControl("chkCupon");


                dr = dt.NewRow();
                dr[0] = txtId.Text;
                dr[1] = txtCupon.Text;
                dr[2] = txtIdPromocion.Text;
                dr[3] = txtIdPromocionDispara.Text;
                dr[4] = txtMensajePOS.Text;
                if (chkCupones.Checked)
                {
                    dr[5] = "1";
                }
                else
                {
                    dr[5] = "2";
                }


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
                dr[0] = "0";
                dr[1] = "";
                dr[2] = "";
                dr[3] = "";
                dr[4] = "";
                dr[5] = "1";

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
        private bool ModificarPromoEscalonada()
        {
            bool blnRespuesta = false;
            AdministraPromocion Ejecutar = new AdministraPromocion();

            int contar = 0;

            try
            {
                foreach (GridViewRow cell in grvCupones.Rows)
                {
                    ModPromoEscalonada campos = new ModPromoEscalonada();
                    TextBox txtCupon = (cell.Cells[0].FindControl("txtCupon") as TextBox);
                    TextBox txtIdPromocion = (cell.Cells[0].FindControl("txtIdPromocion") as TextBox);
                    TextBox txtIdPromocionDispara = (cell.Cells[0].FindControl("txtIdPromoDispara") as TextBox);
                    TextBox txtMensajePOS = (cell.Cells[0].FindControl("txtMensajePOS") as TextBox);
                    TextBox txtId = (cell.Cells[0].FindControl("txtId") as TextBox);
                    CheckBox chkCupones = (cell.Cells[0].FindControl("chkCupon") as CheckBox);

                    campos.Cupon = txtCupon.Text;
                    campos.IdPromocion = Convert.ToInt32(txtIdPromocion.Text);
                    campos.IdPromocionDispara = Convert.ToInt32(txtIdPromocionDispara.Text);
                    campos.FechaIni = (DateTime)rdpFechaInicio.SelectedDate;
                    campos.FechaFin = (DateTime)rdpFechaFin.SelectedDate;
                    campos.MensajePOS = txtMensajePOS.Text;
                    campos.Identificador = Session["Identificador"].ToString();

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



                    //Si no asignan valor este sera default 0
                    if (string.IsNullOrWhiteSpace(txtDuracionCupon.Text))
                    {
                        txtDuracionCupon.Text = "0";
                    }
                    campos.DuracionCupon = Convert.ToInt32(txtDuracionCupon.Text);

                    if (chkCupones.Checked)
                    {
                        campos.IdStatus = "1";
                        contar += 1;
                        campos.Orden = contar;
                    }
                    else
                    {
                        campos.IdStatus = "2";
                        campos.Orden = 0;
                    }

                    campos.Id = Convert.ToInt32(txtId.Text);


                    blnRespuesta = Ejecutar.ModificarPromoEscalonada(campos);

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
            Session.Contents.Remove("memFechaInicio");
            Session.Remove("memFechaInicio");
            Session.Contents.Remove("memFechaFin");
            Session.Remove("memFechaFin");
            Session.Contents.Remove("Identificador");
            Session.Remove("Identificador");

            rdpFechaInicio.SelectedDate = null;
            rdpFechaFin.SelectedDate = null;
            lblUso.Visible = false;
            rcmbUso.Visible = false;
            rcmbUso.SelectedIndex = -1;
            rcmbUso.SelectedText = "";
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
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
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

        protected void grvDatos_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            btnBuscar_Click(null, null);
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
    }
}