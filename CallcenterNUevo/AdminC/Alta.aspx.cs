using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using Datos;
using System.IO;

namespace CallcenterNUevo.AdminC
{
    public partial class Alta : System.Web.UI.Page
    {
        public int intSucursal = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtCupon.Attributes.Add("onkeypress", "return soloNumeros(event);");
            //txtIDPromo.Attributes.Add("onkeypress", "return soloNumeros(event);");

            Page.Form.Attributes.Add("enctype", "multipart/form-data");



            rdpFechaS.SelectedDate = DateTime.Now;
            rdcFechaFin.MinDate = DateTime.Now;
            rdcFechaFin.MaxDate = new DateTime(DateTime.Now.AddYears(1).Year, 12, 31);

            if (!Page.IsPostBack)
            {
                CargaTipoCupon();
                CarganumAsignacion();
                CargaPromosTipoTrigger();
                rdcFechaFin.SelectedDate = DateTime.Now.AddDays(1);
            }
        }

        protected void btnAutoriza_Click(object sender, EventArgs e)
        {
            int IdTipoCupon = 0;
            string strError = "";


            try
            {



                if (rcbTipoCupon.SelectedValue == "2")
                {
                    if (string.IsNullOrWhiteSpace(txtDescuento.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Es necesario proporcione el valor del descuento.');", true);
                        txtDescuento.Focus();
                        return;
                    }

                    if (txtDescuento.Text == "0" || txtDescuento.Text == "00")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Valor invalido, proporcione un valor del 1 - 99.');", true);
                        txtDescuento.Text = "";
                        txtDescuento.Focus();
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtCodigointerno.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Es necesario proporcione un código interno.');", true);
                        txtCodigointerno.Focus();
                        return;
                    }
                }

                if (rdcFechaFin.SelectedDate <= DateTime.Now)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('La fecha de fin no puede ser menor o igual a la de hoy');", true);
                    return;
                }

                IdTipoCupon = Convert.ToInt32(rcbTipoCupon.SelectedValue);

                string Identificador = "C9FED9CC-999A-99AA-AAA9-B999AC999999";
                if (rcbTipoCupon.SelectedValue == "3")
                {
                    int intId = 0;

                    List<ModPromosTipoTrigger> lstRespuesta = new List<ModPromosTipoTrigger>();

                    intId = Convert.ToInt32(rcbPromoTipoTrigger.SelectedValue);

                    lstRespuesta = (List<ModPromosTipoTrigger>)Session["lstPromosTipotrigger"];

                    Identificador = lstRespuesta.Where(w => w.Id == intId).Select(s => s.Identificador).FirstOrDefault();
                }

                //========================================================================
                //Nueva funcionalidad 14022022
                //poder agregar imagenes y descripción larga
                string strFile = "";
                string strURL = "";
                string extension = "";

                strFile = fupEcommerce.FileName.ToString();

                //directorios
                string savePath = @"C:\Sitios\LealtadBenavides\InsertaPromociones\imagenPromo\";
                //valida existencia de directorio
                if (!Directory.Exists(savePath))
                {//crea directorio
                    Directory.CreateDirectory(savePath);
                }

                if (!string.IsNullOrWhiteSpace(strFile))    //Si seleccionaron un archivo
                {
                    extension = Path.GetExtension(strFile);
                    if (extension != ".jpg" && extension != ".png")
                    {
                        Mensajes("Imposible continuar, archivo invalido.");
                        return;
                    }
                }
                else    //En caso contrario se asigna una imagen default
                {
                    strFile = "promos_44441.png";
                }

                //ruta y nombre de archivo
                savePath += strFile;

                //valida existencia de archivo
                if (!File.Exists(savePath))
                {
                    //Elimina archivo existente
                    //File.Delete(savePath);

                    if (strFile != "promos_44441.png")
                    {
                        //guarda archivo en ruta
                        fupEcommerce.SaveAs(savePath);
                    }
                }

                strURL = "https://www.beneficiointeligente.com.mx/PLB/Promos/imagenPromo/" + strFile;
                //======================================================================================


                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Alta", "btnAutoriza_Click", "Inicio Registro", this.User.Identity.Name.ToString(), null);
                Result obj = Cupones.InsertaCupon(txtCupon.Text, txtIDPromo.Text, txtNombrePromo.Text, txtMensaje.Text,
                                                    Convert.ToInt32(rcmbSucursal.SelectedValue), Convert.ToInt32(rcmbEstatus.SelectedValue),
                                                    Convert.ToInt32(rcmbUso.SelectedValue), Convert.ToInt32(rcmbAsignacion.SelectedValue), DateTime.Now,
                                                    rdcFechaFin.SelectedDate, HttpContext.Current.User.Identity.Name, DateTime.Now, IdTipoCupon, Identificador, Convert.ToInt32(txtCuponesDisponibles.Text), txtEcommerce.Text.Trim(), strURL);
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Alta", "btnAutoriza_Click", "Fin Registro", this.User.Identity.Name.ToString(), null);


                if (obj.Error.IndexOf("-") > -1)
                {
                    if (IdTipoCupon == 2)
                    {
                        int IdCupon = 0;
                        int IdCodigointerno = 0;
                        int Descuento = 0;

                        IdCodigointerno = Convert.ToInt32(txtCodigointerno.Text);
                        IdCupon = Convert.ToInt32(obj.Error.Substring(obj.Error.IndexOf("-") + 1, obj.Error.Length - (obj.Error.IndexOf("-") + 1)));
                        Descuento = Convert.ToInt32(txtDescuento.Text);

                        Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Alta", "btnAutoriza_Click", "Inicio Registro_CuponProdDescuento", this.User.Identity.Name.ToString(), null);
                        Cupones.InsertaCuponProdDescuento(IdCupon, IdCodigointerno, Descuento);
                        Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Alta", "btnAutoriza_Click", "Fin Registro_CuponProdDescuento", this.User.Identity.Name.ToString(), null);
                    }

                    strError = obj.Error.Substring(0, obj.Error.IndexOf("-"));
                }
                else
                {
                    strError = obj.Error.ToString();
                }


                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + strError + "')", true);

                if (obj.ErrorCode == "ATC003")
                    Response.AddHeader("REFRESH", "2;URL=Alta.aspx");

            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminC.Alta", "btnAutoriza_Click", "InsertaCupon() / InsertaCuponProdDescuento()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Ocurrio un error al intentar registrar el nuevo cupón.')", true);
            }
        }

        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Consulta.aspx");
        }

        private void CarganumAsignacion()
        {
            List<ModNumeroAsignacionesCupon> lstRespuesta = new List<ModNumeroAsignacionesCupon>();
            //Para alimentar combo ejecutar en SQLserver el sp_CrearnumAsignacionesCupones
            lstRespuesta = Cupones.ObtenNumAsignaciones();

            if (lstRespuesta.Count > 0)
            {
                rcmbAsignacion.DataSource = lstRespuesta;
                rcmbAsignacion.DataValueField = "IdNumAsignacion";
                rcmbAsignacion.DataTextField = "NumAsignacion";
                rcmbAsignacion.DataBind();
            }
            else
            {
                rcmbAsignacion.DataSource = null;
                rcmbAsignacion.DataBind();
            }

        }
        private void CargaTipoCupon()
        {
            List<ModTipoCupon> lstRespuesta = new List<ModTipoCupon>();
            //Para alimentar combo ejecutar en SQLserver el sp_CrearnumAsignacionesCupones
            lstRespuesta = Cupones.ObtenTipoCupon();

            if (lstRespuesta.Count > 0)
            {
                rcbTipoCupon.DataSource = lstRespuesta;
                rcbTipoCupon.DataValueField = "IdTipoCupon";
                rcbTipoCupon.DataTextField = "Descripcion";
                rcbTipoCupon.SelectedValue = "1";
                rcbTipoCupon.DataBind();
            }
            else
            {
                rcbTipoCupon.DataSource = null;
                rcbTipoCupon.DataBind();
            }

        }
        private void CargaPromosTipoTrigger()
        {
            List<ModPromosTipoTrigger> lstRespuesta = new List<ModPromosTipoTrigger>();
            //Para alimentar combo ejecutar en SQLserver el sp_CrearnumAsignacionesCupones
            lstRespuesta = Cupones.ObtenPromoTipoTrigger();

            if (lstRespuesta.Count > 0)
            {
                rcbPromoTipoTrigger.DataSource = lstRespuesta;
                rcbPromoTipoTrigger.DataValueField = "Id";
                rcbPromoTipoTrigger.DataTextField = "MensajePos";
                // rcbPromoTipoTrigger.SelectedValue = "1";
                rcbPromoTipoTrigger.DataBind();
                Session.Add("lstPromosTipotrigger", lstRespuesta);
            }
            else
            {
                rcbPromoTipoTrigger.DataSource = null;
                rcbPromoTipoTrigger.DataBind();
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<ModSucursales> lstSuc = new List<ModSucursales>();
            lstSuc = Cupones.BuscarSucursales(txtSucursal.Text);
            rcmbSucursal.Items.Clear();
            rcmbSucursal.DataSource = null;
            rcmbSucursal.DataBind();
            rcmbSucursal.Text = "";
            rcmbSucursal.SelectedIndex = 0;

            if (lstSuc.Count > 0)
            {

                rcmbSucursal.DataValueField = "IdSucursal";
                rcmbSucursal.DataTextField = "Sucursal";
                rcmbSucursal.DataSource = lstSuc;
                rcmbSucursal.DataBind();
                txtSucursal.Text = "";
                if (lstSuc.Count == 1 && lstSuc[0].Sucursal.IndexOf("Todas") > -1)
                {
                    rcmbSucursal.Enabled = false;
                }
                else
                {
                    rcmbSucursal.Enabled = true;
                }
            }
            else
            {
                lstSuc = Cupones.BuscarSucursales("Todas");
                rcmbSucursal.DataSource = lstSuc;
                rcmbSucursal.DataBind();
                txtSucursal.Text = "";
                rcmbSucursal.Enabled = false;
            }
        }

        protected void btnSucursales_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {

        }

        protected void rcbTipoCupon_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcbTipoCupon.SelectedValue == "2")//Descuento
            {
                lblcodint.Visible = true;
                txtDescuento.Visible = true;
                lblsignoPorc.Visible = true;
                txtCodigointerno.Visible = true;
                lblTipoPromoTrigger.Visible = false;
                rcbPromoTipoTrigger.Visible = false;
            }
            else if (rcbTipoCupon.SelectedValue == "3")//Trigger
            {
                lblTipoPromoTrigger.Visible = true;
                rcbPromoTipoTrigger.Visible = true;
                lblcodint.Visible = false;
                txtDescuento.Visible = false;
                lblsignoPorc.Visible = false;
                txtCodigointerno.Visible = false;
            }
            else
            {
                lblcodint.Visible = false;
                txtDescuento.Visible = false;
                lblsignoPorc.Visible = false;
                txtCodigointerno.Visible = false;
                lblTipoPromoTrigger.Visible = false;
                rcbPromoTipoTrigger.Visible = false;
                rcbPromoTipoTrigger.Text = "";
            }
        }

        protected void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (txtDescuento.Text == "0" || txtDescuento.Text == "00")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Proporcione valores de 1 - 99')", true);
                txtDescuento.Text = "";
                txtDescuento.Focus();
            }
        }

        protected void rdbSinLimite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSinLimite.Checked)
            {
                txtCuponesDisponibles.Text = "1000000";
                txtCuponesDisponibles.Enabled = false;
            }
        }

        protected void rdbConLimite_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbConLimite.Checked)
            {
                txtCuponesDisponibles.Text = "";
                txtCuponesDisponibles.Enabled = true;
            }
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
    }
}