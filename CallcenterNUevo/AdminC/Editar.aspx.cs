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
    public partial class Editar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(btnAutoriza);
            Page.Form.Attributes.Add("enctype", "multipart/form-data");

            if (fupEcommerce.HasFile)
            {
                Session.Add("fupEcommerce", fupEcommerce);
                //Application["FileBytes"] = flImage.FileBytes;

                //Application["FileContent"] = flImage.FileContent;

                //Application["FileName"] = flImage.FileName;

                //Application["PostedFile"] = flImage.PostedFile;

            }

            txtBuscar.Attributes.Add("placeholder", "Buscador:");
            //txtCupon.Attributes.Add("onkeypress", "return soloNumeros(event);");
            //txtIDPromo.Attributes.Add("onkeypress", "return soloNumeros(event);");
            //txtBuscar.Attributes.Add("onkeypress", "return soloNumeros(event);");
            rdpFechaS.SelectedDate = DateTime.Now;

            if (!Page.IsPostBack)
            {
                CargaTipoCupon();
                CarganumAsignacion();
                CargaPromosTipoTrigger();
                pnlResultados.Visible = false;
                pnlSinInfo.Visible = false;
                pnlEdicion.Visible = false;
            }


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Editar", "btnBuscar_Click", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
            rgResultado.DataSource = Negocio.Cupones.BuscarCupon(txtBuscar.Text);
            rgResultado.DataBind();
            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Editar", "btnBuscar_Click", "Fin de Consulta", this.User.Identity.Name.ToString(), null);

            if (rgResultado.MasterTableView.Items.Count > 0)
            {
                pnlResultados.Visible = true;
                pnlSinInfo.Visible = false;
            }
            else
            {
                pnlResultados.Visible = false;
                pnlSinInfo.Visible = true;
            }
        }

        protected void rgResultado_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == "EDITAR")
            {
                using (System.Data.DataTable tblDatos = Cupones.ConsultarInfo(Convert.ToInt32(e.CommandArgument)))
                {
                    hdnId.Value = e.CommandArgument.ToString();
                    lblCupon.Text = tblDatos.Rows[0]["Cupon"].ToString();
                    txtCupon.Text = tblDatos.Rows[0]["Cupon"].ToString();
                    txtIDPromo.Text = tblDatos.Rows[0]["IdPromo"].ToString();
                    txtNombrePromo.Text = tblDatos.Rows[0]["NombrePromocion"].ToString();
                    txtMensaje.Text = tblDatos.Rows[0]["Mensaje"].ToString();
                    rcmbAsignacion.SelectedValue = tblDatos.Rows[0]["NumAsignaciones"].ToString();
                    Session["Estatus"] = rcmbEstatus.SelectedValue = tblDatos.Rows[0]["Estatus"].ToString();
                    rcmbSucursal.SelectedValue = tblDatos.Rows[0]["Sucursal"].ToString();
                    rcmbUso.SelectedValue = Convert.ToInt32(tblDatos.Rows[0]["UsoUnico"]).ToString();
                    rdcFechaFin.SelectedDate = Convert.ToDateTime(tblDatos.Rows[0]["FechaFin"]);
                    rcbTipoCupon.SelectedValue = tblDatos.Rows[0]["Id_Tipocupon"].ToString();
                    txtCuponesDisponibles.Text = tblDatos.Rows[0]["CuponesDisponibles"].ToString();
                    txtEcommerce.Text = tblDatos.Rows[0]["DescEcommerce"].ToString();
                    imgEcommerce.ImageUrl = tblDatos.Rows[0]["urlImagen"].ToString();
                    if (Convert.ToInt32(txtCuponesDisponibles.Text) < 1000000)
                    {
                        rdbConLimite.Checked = true;
                    }
                    else if (Convert.ToInt32(txtCuponesDisponibles.Text) >= 1000000)
                    {
                        rdbSinLimite.Checked = true;
                    }
                    if (Convert.ToInt32(rcbTipoCupon.SelectedValue) == 2)//Tipo Descuento
                    {
                        lblcodint.Visible = true;
                        txtDescuento.Visible = true;
                        txtDescuento.Text = tblDatos.Rows[0]["Descuento"].ToString();
                        lblsignoPorc.Visible = true;
                        txtCodigointerno.Text = tblDatos.Rows[0]["codigointerno"].ToString();
                        txtCodigointerno.Visible = true;
                    }
                    else
                    {
                        lblcodint.Visible = false;
                        txtDescuento.Visible = false;
                        lblsignoPorc.Visible = false;
                        txtCodigointerno.Visible = false;
                    }


                    if (!string.IsNullOrWhiteSpace(tblDatos.Rows[0]["Identificador"].ToString()))
                    {
                        int intId = 0;
                        List<ModPromosTipoTrigger> lstRespuesta = new List<ModPromosTipoTrigger>();
                        lstRespuesta = (List<ModPromosTipoTrigger>)Session["lstPromosTipotrigger"];

                        if (lstRespuesta != null)
                        {
                            if (lstRespuesta.Count > 0)
                            {
                                intId = lstRespuesta.Where(w => w.Identificador == tblDatos.Rows[0]["Identificador"].ToString()).Select(s => s.Id).FirstOrDefault();
                                rcbPromoTipoTrigger.SelectedValue = intId.ToString();

                                lblTipoPromoTrigger.Visible = true;
                                rcbPromoTipoTrigger.Visible = true;
                            }
                        }
                    }

                }
                pnlBusqueda.Visible = false;
                pnlEdicion.Visible = true;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            txtMensaje.Enabled = true;
            txtNombrePromo.Enabled = true;
            rdcFechaFin.Enabled = true;
            imgEcommerce.Visible = false;
            txtEcommerce.Enabled = true;
            fupEcommerce.Visible = true;
            fupEcommerce.Enabled = true;


            //rcmbSucursal.Enabled = true;
            if (rcbTipoCupon.SelectedValue == "2")
            {
                lblcodint.Enabled = true;
                txtDescuento.Enabled = true;
                lblsignoPorc.Visible = true;
                rcbTipoCupon.Enabled = true;
                txtCodigointerno.Enabled = true;
            }
            else if (rcbTipoCupon.SelectedValue == "3")
            {
                rcbPromoTipoTrigger.Enabled = true;
            }
            else
            {
                rcbTipoCupon.Enabled = true;
                txtDescuento.Enabled = false;
                lblsignoPorc.Visible = false;
                lblcodint.Enabled = false;
                txtCodigointerno.Enabled = false;
            }
            rcmbAsignacion.Enabled = true;
            rcmbUso.Enabled = true;
            rdcFechaFin.Enabled = true;
            btnAutoriza.Visible = true;
            btnCanelar.Visible = true;
            btnEdit.Visible = false;
            if (Session["Estatus"] != null)
            {
                if (Session["Estatus"].ToString() == "0")
                    txtIDPromo.Enabled = true;
                else
                {
                    txtIDPromo.Enabled = false;
                    //txtMensaje.Enabled = false;
                    //rdcFechaFin.Enabled = false;
                    txtCupon.Enabled = false;
                }
            }

            if (Convert.ToInt32(txtCuponesDisponibles.Text) < 1000000)
            {
                txtCuponesDisponibles.Enabled = true;
            }
            else if (Convert.ToInt32(txtCuponesDisponibles.Text) >= 1000000)
            {
                txtCuponesDisponibles.Enabled = false;
            }
        }

        protected void btnAutoriza_Click(object sender, EventArgs e)
        {
            //Result resultado = Cupones.ActualizaCupon(hdnId.Value, txtMensaje.Text, txtNombrePromo.Text, rcmbSucursal.SelectedValue, rdcFechaFin.SelectedDate,Convert.ToInt32(rcmbUso.SelectedValue), rcmbAsignacion.SelectedValue, HttpContext.Current.User.Identity.Name);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resultado.Error + "')", true);
            //Response.AddHeader("REFRESH", "2;URL=Editar.aspx");
            if (rdcFechaFin.SelectedDate <= DateTime.Now)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('La fecha de fin no puede ser menor o igual a la fecha de solicitud');", true);
                return;
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "$(\"#openModal\").fadeIn('slow');", true);
        }

        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            txtMensaje.Enabled = false;
            txtNombrePromo.Enabled = false;
            rcmbSucursal.Enabled = false;
            rcmbAsignacion.Enabled = false;
            rcmbUso.Enabled = false;
            txtIDPromo.Enabled = false;
            rdcFechaFin.Enabled = false;
            btnAutoriza.Visible = false;
            btnCanelar.Visible = false;

            pnlResultados.Visible = true;
            pnlEdicion.Visible = false;
            pnlBusqueda.Visible = true;
            pnlSinInfo.Visible = false;
            btnEdit.Visible = true;
        }

        protected void btnConfirmaContinua_Click(object sender, EventArgs e)
        {
            int IdTipoCupon = 0;

            IdTipoCupon = Convert.ToInt32(rcbTipoCupon.SelectedValue);

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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Proporcione valores de 1 - 99')", true);
                    txtDescuento.Text = "";
                    txtDescuento.Focus();
                }

                if (string.IsNullOrWhiteSpace(txtCodigointerno.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Es necesario proporcione un código interno.');", true);
                    txtCodigointerno.Focus();
                    return;
                }
            }

            string strIdentificador = "C9FED9CC-999A-99AA-AAA9-B999AC999999";
            if (rcbTipoCupon.SelectedValue == "3")
            {
                int intId = 0;
                List<ModPromosTipoTrigger> lstRespuesta = new List<ModPromosTipoTrigger>();
                lstRespuesta = (List<ModPromosTipoTrigger>)Session["lstPromosTipotrigger"];
                intId = Convert.ToInt32(rcbPromoTipoTrigger.SelectedValue);

                strIdentificador = lstRespuesta.Where(w => w.Id == intId).Select(s => s.Identificador).FirstOrDefault();
            }

            //========================================================================
            //Nueva funcionalidad 14022022
            //poder agregar imagenes y descripción larga
            string strFile = "";
            string strURL = "";
            string extension = "";


            if (Session["fupEcommerce"] != null)
            {
                fupEcommerce = (FileUpload)Session["fupEcommerce"];
            }
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





            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Editar", "btnConfirmaContinua_Click", "Inicio de Actualizacion", this.User.Identity.Name.ToString(), null);
            Result resultado = Cupones.ActualizaCupon(hdnId.Value, txtMensaje.Text, txtNombrePromo.Text, rcmbSucursal.SelectedValue, rdcFechaFin.SelectedDate, Convert.ToInt32(rcmbUso.SelectedValue), rcmbAsignacion.SelectedValue, HttpContext.Current.User.Identity.Name, IdTipoCupon, strIdentificador, Convert.ToInt32(txtCuponesDisponibles.Text), txtEcommerce.Text.Trim(), strURL);
            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Editar", "btnConfirmaContinua_Click", "Fin de Actualizacion", this.User.Identity.Name.ToString(), null);


            if (IdTipoCupon == 2)
            {
                int IdCupon = 0;
                int intCodigointerno = 0;
                int intDescuento = 0;

                IdCupon = Convert.ToInt32(hdnId.Value);
                intCodigointerno = Convert.ToInt32(txtCodigointerno.Text);
                intDescuento = Convert.ToInt32(txtDescuento.Text);

                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Editar", "btnConfirmaContinua_Click", "Inicio de Actualizacion_TipoDescuento", this.User.Identity.Name.ToString(), null);
                Cupones.ActualizaCuponProdDescuento(IdCupon, intCodigointerno, intDescuento);
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminC.Editar", "btnConfirmaContinua_Click", "Fin de Actualizacion_TipoDescuento", this.User.Identity.Name.ToString(), null);
            }

            Session.Contents.Remove("fupEcommerce");
            Session.Remove("fupEcommerce");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resultado.Error + "')", true);
            Response.AddHeader("REFRESH", "2;URL=Editar.aspx");
        }

        protected void btnCancela_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "$(\"#openModal\").fadeOut('slow');", true);
        }

        protected void rgResultado_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            rgResultado.DataSource = Negocio.Cupones.BuscarCupon(txtBuscar.Text);
            rgResultado.Rebind();
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

        protected void rcbTipoCupon_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (rcbTipoCupon.SelectedValue == "2")//Descuento
            {
                lblcodint.Visible = true;
                txtDescuento.Visible = true;
                txtDescuento.Enabled = true;
                lblsignoPorc.Visible = true;
                txtCodigointerno.Enabled = true;
                txtCodigointerno.Visible = true;
                lblTipoPromoTrigger.Visible = false;
                rcbPromoTipoTrigger.Visible = false;
                rcbPromoTipoTrigger.Enabled = false;
                rcbPromoTipoTrigger.Text = "";
                txtCodigointerno.Focus();
            }
            else if (rcbTipoCupon.SelectedValue == "3")//Trigger
            {
                lblTipoPromoTrigger.Visible = true;
                rcbPromoTipoTrigger.Visible = true;
                rcbPromoTipoTrigger.Enabled = true;
                lblcodint.Visible = false;
                txtDescuento.Visible = false;
                lblsignoPorc.Visible = false;
                txtCodigointerno.Visible = false;
            }
            else
            {
                lblcodint.Visible = false;
                txtDescuento.Visible = false;
                txtDescuento.Enabled = false;
                lblsignoPorc.Visible = false;
                txtCodigointerno.Enabled = false;
                txtCodigointerno.Visible = false;
                lblTipoPromoTrigger.Visible = false;
                rcbPromoTipoTrigger.Visible = false;
                rcbPromoTipoTrigger.Enabled = false;
                rcbPromoTipoTrigger.Text = "";
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