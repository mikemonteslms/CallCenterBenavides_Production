using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Bitacora;
using Datos;
using Telerik.Web.UI;
using xi = Telerik.Web.UI.ExportInfrastructure;
using Telerik.Web.UI.GridExcelBuilder;

namespace CallcenterNUevo.AdminPromociones.AdmonCatalogos
{
    public partial class AdmonCatalogos : System.Web.UI.Page
    {
        public List<ModProductos> lstResultado = new List<ModProductos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                IniciaTabs();
            }
        }
        private void IniciaTabs()
        {
            mvCatLab.SetActiveView(vBusquedaLab);
            CargaLaboratorios();
            mvCatSegmento.SetActiveView(vBusquedaSegmentos);
            CargaSegmentos();
            mvCatTipoProm.SetActiveView(vBusquedaTipoPromo);
            CargaPromos();
            CargaLaboratoriosPopup();
            mvCatLimites.SetActiveView(vBusquedaLimites);
            CargaLimites();
        }

        #region Laboratorios
            protected void btnGuardar_Click(object sender, EventArgs e)
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
                    if (strRespuesta == "El laboratorio que deseá agregar es posible que ya exista.")
                    {
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
                        btnForzarAlta.Visible = true;
                        btnCancelarForzado.Visible = true;
                        txtNomLaboratorio.Text = "";
                        txtNomLaboratorio.Focus();
                        mvCatLab.SetActiveView(vBusquedaLab);
                        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                    }
                    else
                    {
                        btnForzarAlta.Visible = false;
                        btnCancelarForzado.Visible = false;
                        txtNomLaboratorio.Text = "";
                        txtNomLaboratorio.Focus();
                        CargaLaboratorios("");
                    }
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnGuardar_Click", "Ejecuta.RegistraNvoLaboratorio(" + txtNomLaboratorio.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error interno, contacte al administrador.");
                }
            }

            protected void btnCancelar_Click(object sender, EventArgs e)
            {
                CargaLaboratorios();
                mvCatLab.SetActiveView(vBusquedaLab);
            }
            private void Mensajes(string valorMensaje)
            {
                string outputstring = valorMensaje;
                ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
            }

            protected void grvLaboratorios_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
            {
                GridDataItem item;
                if (e.CommandName == "EditaLab")
                {
                    item = (GridDataItem)e.Item;

                    IdLab.Value = e.CommandArgument.ToString();
                    mvCatLab.SetActiveView(vEditaLab);
                    txtEditLab.Text = item.Cells[4].Text;
                }
            }

            protected void grvLaboratorios_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
            {
                List<ModLaboratorio> lstLab = new List<ModLaboratorio>();
                if (Session["lstAltaLab"] != null)
                {
                    lstLab = (List<ModLaboratorio>)Session["lstAltaLab"];
                    if (lstLab.Count > 0)
                    {
                        grvLaboratorios.DataSource = (List<ModLaboratorio>)Session["lstAltaLab"];
                        grvLaboratorios.DataBind();
                    }
                }
                else
                {
                    CargaLaboratorios();
                }
            }

            private void CargaLaboratorios()
            {
                AdministraPromocion Ejecuta = new AdministraPromocion();
                List<ModLaboratorio> lstResultadosLab = new List<ModLaboratorio>();
                lstResultadosLab = Ejecuta.ObtenLaboratorios("ConnectionString");

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

            protected void btnSi_Click(object sender, EventArgs e)
            {
                int Idlaboratorio = 0;
                int IdSegmento = 0;
                int IdTipoPromo = 0;
                int IdPeriodo = 0;
                string strRespuesta = "";
                AdministraPromocion Ejecuta = new AdministraPromocion();

                try
                {
                    switch (Session["EliminarA"].ToString())
                    {
                        case "Lab":
                                if (!string.IsNullOrWhiteSpace(IdLab.Value))
                                {
                                    Idlaboratorio = Convert.ToInt32(IdLab.Value);
                                }
                                strRespuesta = Ejecuta.EliminarLaboratorio(Idlaboratorio);
                                Mensajes(strRespuesta);
                                CargaLaboratorios();
                                Session.Contents.Remove("EliminarA");
                            break;
                        case "Seg":
                            if (!string.IsNullOrWhiteSpace(IdSeg.Value))
                            {
                                IdSegmento = Convert.ToInt32(IdSeg.Value);
                            }
                            strRespuesta = Ejecuta.EliminarSegmento(IdSegmento);
                            Mensajes(strRespuesta);
                            CargaSegmentos();
                            Session.Contents.Remove("EliminarA");
                            break;
                        case "TPromo":
                            if (!string.IsNullOrWhiteSpace(IdTPromo.Value))
                            {
                                IdTipoPromo = Convert.ToInt32(IdTPromo.Value);
                            }
                            strRespuesta = Ejecuta.EliminarTPromo(IdTipoPromo);
                            Mensajes(strRespuesta);
                            CargaPromos();
                            Session.Contents.Remove("EliminarA");
                            break;
                        case "Periodo":

                            if (!string.IsNullOrWhiteSpace(IdPeriodohide.Value))
                            {
                                IdPeriodo = Convert.ToInt32(IdPeriodohide.Value);
                            }
                            strRespuesta = Ejecuta.EliminarPeriodo(IdPeriodo);
                            Mensajes(strRespuesta);
                            CargaLimites();
                            Session.Contents.Remove("EliminarA");
                            break;
                    }
                   
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnSi_Click", "Ejecuta.EliminarLaboratorio(" + Idlaboratorio + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error interno, contacte al administrador.");
                }

            }

            protected void btnModificar_Click(object sender, EventArgs e)
            {
                int intIdlab = 0;
                string strRespuesta = "";
                try
                {
                    if (string.IsNullOrWhiteSpace(txtEditLab.Text))
                    {
                        Mensajes("Debe proporcionar un nombre de laboratorio...");
                        txtEditLab.Focus();
                        return;
                    }

                    intIdlab = Convert.ToInt32(IdLab.Value);
                    AdministraPromocion Ejecuta = new AdministraPromocion();
                    txtEditLab.Text = Limpiastring(txtEditLab.Text);
                    strRespuesta = Ejecuta.ModificarLaboratorio(intIdlab, txtEditLab.Text);
                    CargaLaboratorios("");
                    Mensajes(strRespuesta);
                    txtEditLab.Text = "";
                    mvCatLab.SetActiveView(vBusquedaLab);
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnGuardar_Click", "Ejecuta.RegistraNvoLaboratorio(" + txtNomLaboratorio.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error interno, contacte al administrador.");
                }
            }

            protected void btnEditCancelar_Click(object sender, EventArgs e)
            {
                CargaLaboratorios();
                mvCatLab.SetActiveView(vBusquedaLab);
            }

            protected void btnAddNuevolab_Click(object sender, EventArgs e)
            {
                mvCatLab.SetActiveView(vAltaLab);
            }
            protected void btnForzarAlta_Click(object sender, EventArgs e)
            {
                string strRespuesta = "";
                AdministraPromocion Ejecuta = new AdministraPromocion();
                strRespuesta = Ejecuta.RegistraNvoLaboratorioForzar(txtLabForzar.Value);
                Mensajes(strRespuesta);
                CargaLaboratorios("");
                Session.Contents.Remove("lstAltaLab");
                Session.Remove("lstAltaLab");
            }

            protected void btnCancelarForzado_Click(object sender, EventArgs e)
            {
                Session.Contents.Remove("lstAltaLab");
                Session.Remove("lstAltaLab");
                this.btnForzarAlta.Visible = false;
                this.btnCancelarForzado.Visible = false;
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
        #endregion

        #region Segmentos
            protected void btnNuevoSegmento_Click(object sender, EventArgs e)
            {
                mvCatSegmento.SetActiveView(vAltaSegmentos);
            }

            protected void btnGuardaSegmento_Click(object sender, EventArgs e)
            {
                string strRespuesta = "";
                try
                {
                    if (string.IsNullOrWhiteSpace(txtSegmento.Text))
                    {
                        Mensajes("Debe proporcionar un nobre de segmento.");
                        txtSegmento.Focus();
                        return;
                    }

                        AdministraPromocion Ejecuta = new AdministraPromocion();
                        strRespuesta = Ejecuta.RegistraNvoSegmento(txtSegmento.Text);
                        Mensajes(strRespuesta);
                        txtSegmento.Text = "";
                        txtSegmento.Focus();
                        CargaSegmentos();
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnGuardaSegmento_Click", "Ejecuta.RegistraNvoLaboratorio(" + txtNomLaboratorio.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error interno, contacte al administrador.");
                }
            }

            protected void btnCancelarSegmento_Click(object sender, EventArgs e)
            {
                mvCatSegmento.SetActiveView(vBusquedaSegmentos);
            }

            protected void grvSegmentos_ItemCommand(object sender, GridCommandEventArgs e)
            {
                GridDataItem item;
                switch (e.CommandName)
                {
                    case "EliminaSegmento":
                        IdSeg.Value = e.CommandArgument.ToString();
                        Session["EliminarA"] = "Seg";
                        lblmsgdelete.Text = "El Segmento se eliminara";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                        break;
                    case "EditaSegmento":
                        item = (GridDataItem)e.Item;

                        IdSeg.Value = e.CommandArgument.ToString();
                        mvCatSegmento.SetActiveView(vEditaSegmentos);
                        txtEditaSegmento.Text = item.Cells[5].Text;
                        break;
                }
            }

            protected void grvSegmentos_PageIndexChanged(object sender, GridPageChangedEventArgs e)
            {
                CargaSegmentos();
            }
            
            protected void btnEditSegmento_Click(object sender, EventArgs e)
            {
                int intIdseg = 0;
                string strRespuesta = "";
                try
                {
                    if (string.IsNullOrWhiteSpace(txtEditaSegmento.Text))
                    {
                        Mensajes("Debe proporcionar un nombre de segmento...");
                        txtEditLab.Focus();
                        return;
                    }

                    intIdseg = Convert.ToInt32(IdSeg.Value);
                    AdministraPromocion Ejecuta = new AdministraPromocion();
                    strRespuesta = Ejecuta.ModificarSegmento(intIdseg , txtEditaSegmento.Text);
                    Mensajes(strRespuesta);
                    CargaSegmentos();
                    txtEditaSegmento.Text = "";
                    mvCatSegmento.SetActiveView(vBusquedaSegmentos);
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnEditSegmento_Click", "Ejecuta.ModificarSegmento(" + intIdseg + "," + txtEditaSegmento.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error interno, contacte al administrador.");
                }
            }

            protected void btnCancelarEditSegmento_Click(object sender, EventArgs e)
            {
                mvCatSegmento.SetActiveView(vBusquedaSegmentos);
            }

            private void CargaSegmentos()
            {
                AdministraPromocion ejecuta = new AdministraPromocion();
                List<ModSegmento> lstResultados = new List<ModSegmento>();
                lstResultados = ejecuta.ObtenSegmentos("ConnectionString");

                if (lstResultados.Count > 0)
                {
                    grvSegmentos.DataSource = lstResultados;
                    grvSegmentos.DataBind();
                }
                else
                {
                    grvSegmentos.DataSource = null;
                    grvSegmentos.DataBind();
                }
            }
        #endregion

        #region Tipopromocion
            protected void btnNvoTipoPromo_Click(object sender, EventArgs e)
            {
                mvCatTipoProm.SetActiveView(vAltaTipoPromo);
            }

            protected void grvTipoPromo_ItemCommand(object sender, GridCommandEventArgs e)
            {
                GridDataItem item;
                switch (e.CommandName)
                {
                    case "EliminaPromocion":
                        IdTPromo.Value = e.CommandArgument.ToString();
                        Session["EliminarA"] = "TPromo";
                        lblmsgdelete.Text = "El Tipo de Promoción se eliminara";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                        break;
                    case "EditaPromocion":
                        item = (GridDataItem)e.Item;

                        IdTPromo.Value = e.CommandArgument.ToString();
                        mvCatTipoProm.SetActiveView(vEditaTipoPromo);
                        txtEditTPromo.Text = item.Cells[5].Text;
                        break;
                }
            }

            protected void grvTipoPromo_PageIndexChanged(object sender, GridPageChangedEventArgs e)
            {
                CargaPromos();
            }

            protected void btnGuardarTPromo_Click(object sender, EventArgs e)
            {
                string strRespuesta = "";
                try
                {
                    if (string.IsNullOrWhiteSpace(txtTipoPromo.Text))
                    {
                        Mensajes("Debe proporcionar un nombre de tipo de promoción.");
                        txtTipoPromo.Focus();
                        return;
                    }

                   
                    int intIdTipoPromo = 0;
                    bool blnEsValido = false;
                    blnEsValido = int.TryParse(txtIdTipoAcum.Text, out intIdTipoPromo);

                    if (!blnEsValido)
                    {
                        Mensajes("Es requerido el tipo de acumulación.");
                        txtIdTipoAcum.Focus();
                        return;
                    }

                    if (intIdTipoPromo > 2 || intIdTipoPromo < 1)
                    {
                        Mensajes("El valor esperado es 1 ó 2, Intente de nuevo.");
                        txtIdTipoAcum.Text = "";
                        txtIdTipoAcum.Focus();
                        return;
                    }

                    AdministraPromocion Ejecuta = new AdministraPromocion();
                    strRespuesta = Ejecuta.RegistraNvoTPromo(txtTipoPromo.Text, intIdTipoPromo);
                    Mensajes(strRespuesta);
                    txtTipoPromo.Text = "";
                    txtIdTipoAcum.Text = "";
                    txtTipoPromo.Focus();
                    CargaPromos();
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnGuardaSegmento_Click", "Ejecuta.RegistraNvoLaboratorio(" + txtNomLaboratorio.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error interno, contacte al administrador.");
                }

            }

            protected void btnCancelarTPromo_Click(object sender, EventArgs e)
            {
                mvCatTipoProm.SetActiveView(vBusquedaTipoPromo);
            }

            protected void btnEditaTpromo_Click(object sender, EventArgs e)
            {
                int intIdTipoPromocion = 0;
                string strRespuesta = "";
                try
                {
                    if (string.IsNullOrWhiteSpace(txtEditTPromo.Text))
                    {
                        Mensajes("Debe proporcionar un nombre de tipo de promoción.");
                        txtEditTPromo.Focus();
                        return;
                    }

                    intIdTipoPromocion = Convert.ToInt32(IdTPromo.Value);
                    AdministraPromocion Ejecuta = new AdministraPromocion();
                    strRespuesta = Ejecuta.ModificarTPromo(intIdTipoPromocion, txtEditTPromo.Text);
                    Mensajes(strRespuesta);
                    CargaPromos();
                    txtEditTPromo.Text = "";
                    mvCatTipoProm.SetActiveView(vBusquedaTipoPromo);
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnEditaTpromo_Click", "Ejecuta.ModificarTPromo(" + intIdTipoPromocion + "," + txtEditaSegmento.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error interno, contacte al administrador.");
                }

            }

            protected void btnCancelaTPromo_Click(object sender, EventArgs e)
            {
                mvCatTipoProm.SetActiveView(vBusquedaTipoPromo);
            }

            private void CargaPromos() 
            {
                AdministraPromocion Ejecuta = new AdministraPromocion();
                List<ModTipoPromocion> lstResultadosTP = new List<ModTipoPromocion>();
                List<ModTipoPromocion> lstResultadosTP2 = new List<ModTipoPromocion>();
                lstResultadosTP = Ejecuta.ObtenTipoPromocion("ConnectionString", 1);
                lstResultadosTP2 = Ejecuta.ObtenTipoPromocion("ConnectionString", 2);

                foreach( ModTipoPromocion campos in  lstResultadosTP2)
                {
                    ModTipoPromocion reg = new ModTipoPromocion();
                    reg.Id  = campos.Id;
                    reg.TipoPromocion = campos.TipoPromocion;

                    lstResultadosTP.Add(reg);
                }

                if (lstResultadosTP.Count > 0)
                {
                    grvTipoPromo.DataSource = lstResultadosTP;
                    grvTipoPromo.DataBind();
                }
                else 
                {
                    grvTipoPromo.DataSource = null;
                    grvTipoPromo.DataBind();
                }
            }
           
            private void CargaLaboratoriosPopup() 
            {
                AdministraPromocion Ejecuta = new AdministraPromocion();
                List<ModLaboratorio> lstResultadosLab = new List<ModLaboratorio>();
                lstResultadosLab = Ejecuta.ObtenLaboratoriosPopup("ConnectionString");

                if (lstResultadosLab.Count > 0)
                {
                    rcbLaboratorios.DataSource = lstResultadosLab;
                    rcbLaboratorios.DataTextField = "Laboratorio";
                    rcbLaboratorios.DataValueField = "IdCategoria";
                    rcbLaboratorios.DataBind();
                }
            }
        #endregion

        #region Productos
            protected void grvProductos_ItemCommand(object sender, GridCommandEventArgs e)
            {
                selIdProd.Value = e.CommandArgument.ToString();
                switch(e.CommandName)
                {
                    case "AsignaLab":
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowRegAsigLab();</script>", false);
                        break;
                }
            }

            protected void grvProductos_PageIndexChanged(object sender, GridPageChangedEventArgs e)
            {
                ObtenProductos();
            }

            protected void btnBuscarProd_Click(object sender, EventArgs e)
            {
                ObtenProductos();
            }
            protected void btnAsignarTodos_Click(object sender, EventArgs e)
            {
                string strProductos = "";
                string strResultado = "";
                int intCategoria = 0;

                if (rcbLaboratorios.SelectedValue == "")
                {
                    Mensajes("Imposible continuar, es necesario seleccionar un laboratorio.");
                    rcbLaboratorios.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowRegAsigLab();</script>", false);
                    return;
                }
                intCategoria = Convert.ToInt32(rcbLaboratorios.SelectedValue);

                if (string.IsNullOrWhiteSpace(selIdProd.Value))
                {
                    Mensajes("Debe seleccionar un elemnto de la lista.");
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowRegAsigLab();</script>", false);
                    return;
                }

                //Se alimenta lista con variable de session
                lstResultado = (List<ModProductos>)Session["lstProductos"];
                //Se elimina variable de sesión
                Session.Contents.Remove("lstProductos");

                foreach (ModProductos regProd in lstResultado)
                {
                    if (string.IsNullOrWhiteSpace(strProductos))
                    {
                        strProductos = regProd.Id.ToString();
                    }
                    else
                    {
                        strProductos = strProductos + "," + regProd.Id.ToString();
                    }
                }


                try 
                {
                    AdministraPromocion Ejecutar = new AdministraPromocion();
                    strResultado = Ejecutar.GuardaAsigancionLaboratorio(intCategoria, strProductos);
                    rcbLaboratorios.SelectedValue = null;
                    rcbLaboratorios.Text = "---seleccione un laboratorio---";
                    ObtenProductos();
                    Mensajes(strResultado);
                }
                catch(Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnAsignarTodos_Click", "Ejecuta.GuardaAsigancionLaboratorio(" + intCategoria + "," + strProductos + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error interno, contacte al administrador.");
                }
                
            }

            protected void btnAsignarSolouno_Click(object sender, EventArgs e)
            {
                string strResultado = "";
                int intCategoria = 0;

                if (rcbLaboratorios.SelectedValue == "")
                {
                    Mensajes("Imposible continuar, es necesario seleccionar un laboratorio.");
                    rcbLaboratorios.Focus();
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowRegAsigLab();</script>", false);
                    return;
                }
                intCategoria = Convert.ToInt32(rcbLaboratorios.SelectedValue);

                if (string.IsNullOrWhiteSpace(selIdProd.Value))
                {
                    Mensajes("Debe seleccionar un elemnto de la lista.");
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowRegAsigLab();</script>", false);
                    return;
                }

                try 
                {
                    AdministraPromocion Ejecutar = new AdministraPromocion();
                    strResultado = Ejecutar.GuardaAsigancionLaboratorio(intCategoria, selIdProd.Value);
                    rcbLaboratorios.SelectedValue = null;
                    rcbLaboratorios.Text = "---seleccione un laboratorio---";
                    ObtenProductos();
                    Mensajes(strResultado);
                }
                catch (Exception ex)
                {
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnAsignarSoloUno_Click", "Ejecuta.GuardaAsigancionLaboratorio(" + intCategoria + "," + selIdProd.Value + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                    Mensajes("Ocurrio un error interno, contacte al administrador.");
                }
            }

            private void ObtenProductos() 
            {
                if (string.IsNullOrWhiteSpace(txtProducto.Text))
                {
                    Mensajes("Es necesario que proporcione un nombre de producto.");
                    txtProducto.Focus();
                    return;
                }

                AdministraPromocion Ejecuta = new AdministraPromocion();
                
                lstResultado = Ejecuta.ObtenProductos(txtProducto.Text);

                if (lstResultado.Count > 0)
                {
                    //Asigna la lista a una variable de sesión
                    //para reutilizarkla mas adelante
                    Session["lstProductos"] = lstResultado;
                    grvProductos.DataSource = lstResultado;
                    grvProductos.DataBind();
                }
                else
                {
                    grvProductos.DataSource = null;
                    grvProductos.DataBind();
                }
            }
        #endregion

        #region "Limites"

                protected void btnNuevoLimite_Click(object sender, EventArgs e)
                {
                    mvCatLimites.SetActiveView(vAltaLimites);
                }

                protected void btnGuardarLimites_Click(object sender, EventArgs e)
                {
                    int intCantDias = 0;
                    string strRespuesta = "";
                    AdministraPromocion ejecuta = new AdministraPromocion();
                    try
                    {
                        if (string.IsNullOrWhiteSpace(txtLimite.Text))
                        {
                            Mensajes("Debé proporcionar un nombre descriptivo del periodo.");
                            txtLimite.Focus();
                            return;
                        }

                        if (!string.IsNullOrWhiteSpace(txtDias.Text))
                        {
                            intCantDias = Convert.ToInt32(txtDias.Text);
                        }
                        else
                        {
                            Mensajes("Debé proporcionar el número de días.");
                            txtDias.Focus();
                            return;
                        }
                        strRespuesta = ejecuta.GuardaNvoPeriodo(txtLimite.Text, intCantDias);
                        Mensajes(strRespuesta);
                        txtLimite.Text = "";
                        txtDias.Text = "";
                        txtLimite.Focus();
                    }
                    catch (Exception ex)
                    {
                        Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnGuardarLimites_Click", "Ejecuta.GuardaNvoPeriodo(" + txtLimite.Text + "," + intCantDias + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                        Mensajes("Ocurrio un error interno, contacte al administrador.");
                    }
                }

                protected void btnCancelarLimtes_Click(object sender, EventArgs e)
                {
                    mvCatLimites.SetActiveView(vBusquedaLimites);
                }

                protected void btnModLimiteGuarda_Click(object sender, EventArgs e)
                {
                    int intIdPeriodo = 0;
                    string strRespuesta = "";
                    AdministraPromocion ejecuta = new AdministraPromocion();

                    try
                    {
                        if (string.IsNullOrWhiteSpace(txtModLimite.Text))
                        {
                            Mensajes("Debé proporcionar un nombre descriptivo del periodo.");
                            txtLimite.Focus();
                            return;
                        }
                        if (!string.IsNullOrWhiteSpace(IdPeriodohide.Value))
                        {
                            intIdPeriodo = Convert.ToInt32(IdPeriodohide.Value);
                        }

                        strRespuesta = ejecuta.GuardaEditPeriodo(txtModLimite.Text, intIdPeriodo);
                        Mensajes(strRespuesta);
                        CargaLimites();
                        txtModLimite.Text = "";
                        txtModLimite.Focus();

                    }
                    catch (Exception ex)
                    {
                        Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos", "btnModLimiteGuarda_Click", "Ejecuta.GuardaEditPeriodo(" + txtLimite.Text + "," + intIdPeriodo + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                        Mensajes("Ocurrio un error interno, contacte al administrador.");
                    }
                }

                protected void btnModLimiteCancela_Click(object sender, EventArgs e)
                {
                    mvCatLimites.SetActiveView(vBusquedaLimites);
                }

                protected void grvLimites_ItemCommand(object sender, GridCommandEventArgs e)
                {
                    GridDataItem item;
                    switch (e.CommandName)
                    {
                        case "EliminaLimite":
                            IdPeriodohide.Value = e.CommandArgument.ToString();
                            Session["EliminarA"] = "Periodo";
                            lblmsgdelete.Text = "El Periodo se eliminara";
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                            break;
                        case "EditaLimite":
                            item = (GridDataItem)e.Item;

                            IdPeriodohide.Value = e.CommandArgument.ToString();
                            mvCatLimites.SetActiveView(vEditaLimite);
                            txtModLimite.Text = item.Cells[5].Text;
                            break;
                    }
                }

                protected void grvLimites_PageIndexChanged(object sender, GridPageChangedEventArgs e)
                {
                    CargaLimites();
                }

                private void CargaLimites()
                {
                    AdministraPromocion ejecuta = new AdministraPromocion();
                    List<ModLimitePeriodo> lstResultadoslimPer = new List<ModLimitePeriodo>();
                    lstResultadoslimPer = ejecuta.ObtenLimitePeriodo("ConnectionString");

                    if (lstResultadoslimPer != null)
                    {
                        if (lstResultadoslimPer.Count > 0)
                        {
                            grvLimites.DataSource = lstResultadoslimPer;
                            grvLimites.DataBind();
                        }
                        else
                        {
                            grvLimites.DataSource = null;
                            grvLimites.DataBind();
                        }
                    }
                }
            
            #endregion
    }
}