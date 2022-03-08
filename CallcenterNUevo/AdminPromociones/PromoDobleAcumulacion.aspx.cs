using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Datos;
using Telerik.Web.UI;
using xi = Telerik.Web.UI.ExportInfrastructure;
using Telerik.Web.UI.GridExcelBuilder;

namespace CallcenterNUevo.AdminPromociones
{
    public partial class PromoDobleAcumulacion : System.Web.UI.Page
    {
        //Este módulo registra su información en Dbase  Productivo
        public static string CnnProductivo = "ConnectionString";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EliminarVariablesSession();
                CargalstPromoVigentes();
            }
        }
        protected void grvPromDobleAcumulacion_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            Session.Add("Id", e.CommandArgument);
            GridDataItem item;
            if (e.CommandName == "EditarPromDobleAcumula")
            {
                int intId = Convert.ToInt32(e.CommandArgument);
                List<ModPromoDobleAcumulacion> lstPromos = new List<ModPromoDobleAcumulacion>();
                item = (GridDataItem)e.Item;


                Session.Add("Desc", item.Cells[2].Text);
                Session.Add("FechaI", item.Cells[3].Text);
                Session.Add("FechaF", item.Cells[4].Text);


                lstPromos = (List<ModPromoDobleAcumulacion>)Session["lstPromosVig"];
                lstPromos = lstPromos.Where(w => w.Id == intId).ToList();

                foreach (ModPromoDobleAcumulacion reg in lstPromos)
                {
                    Session.Add("flgDescuento", reg.flgDescuento);
                    Session.Add("EnabledDescuento", reg.EnabledDescuento);
                    Session.Add("flgApertura", "0");
                    Session.Add("EnabledAcumulacion", reg.EnabledAcumulacion);
                    break;
                }

                Session.Contents.Remove("Alta");
                Session.Remove("Alta");

                Session.Add("Modificacion", "true");
                Response.Redirect("AltaPromoDobleAcumulacion.aspx");
            }
            else if (e.CommandName == "EliminarPromDobleAcumula")
            {
                mpeDelete.Show();
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
            }

        }
        protected void grvPromDobleAcumulacion_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }
        protected void grvPromDobleAcumulacion_SortCommand(object sender, Telerik.Web.UI.GridSortCommandEventArgs e)
        {

        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            EliminarVariablesSession();
            Session.Contents.Remove("Modificacion");
            Session.Remove("Modificacion");
            Session.Add("ALTA", "true");
            Response.Redirect("AltaPromoDobleAcumulacion.aspx");
        }
        protected void btnSi_Click(object sender, EventArgs e)
        {
            int IDPromo = 0;
            AdministraPromocion Ejecuta = new AdministraPromocion();
            bool blnRespuesta = false;

            try
            {
                IDPromo = Convert.ToInt32(Session["Id"].ToString());

                blnRespuesta = Ejecuta.EliminarPromocionDobleAcumulacion(CnnProductivo, IDPromo);
                if (blnRespuesta)
                {
                    Mensajes("La promoción fue eliminada correctamente.");
                    EliminarVariablesSession();
                    CargalstPromoVigentes();
                }
                else
                {
                    Mensajes("No fue posible eliminar la promoción.");
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.PromoDobleAcumulacion", "btnSi_Click", "Ejecuta.EliminarPromocionDobleAcumulacion(" + CnnProductivo + " ," + IDPromo + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error inesperado, contacte al administrador.");
            }
        }

        private void CargalstPromoVigentes()
        {
            try
            {
                List<ModPromoDobleAcumulacion> lstRespuesta = new List<ModPromoDobleAcumulacion>();
                AdministraPromocion Ejecuta = new AdministraPromocion();

                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.PromoDobleAcumulacion", "CargalstPromoVigentes", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
                lstRespuesta = Ejecuta.ObtenPromoDobleAcumulacionVigentes(CnnProductivo);
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.PromoDobleAcumulacion", "CargalstPromoVigentes", "Fin de Consulta", this.User.Identity.Name.ToString(), null);

                Session.Add("lstPromosVig", lstRespuesta);
                grvPromDobleAcumulacion.DataSource = null;
                grvPromDobleAcumulacion.DataBind();

                grvPromDobleAcumulacion.DataSource = lstRespuesta;
                grvPromDobleAcumulacion.DataBind();

            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.PromoDobleAcumulacion", "CargalstPromoVigentes", "Ejecuta.ObtenPromoDobleAcumulacionVigentes()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar Obtener promociones vigentes, contacte al administrador.");
            }
        }
        private void EliminarVariablesSession()
        {
            Session.Contents.Remove("Id");
            Session.Remove("Id");
            Session.Contents.Remove("Desc");
            Session.Remove("Desc");
            Session.Contents.Remove("Suc");
            Session.Remove("Suc");
            Session.Contents.Remove("FechaI");
            Session.Remove("FechaI");
            Session.Contents.Remove("FechaF");
            Session.Remove("FechaF");
            Session.Contents.Remove("lstSucursales");
            Session.Remove("lstSucursales");
            Session.Contents.Remove("selSucursal");
            Session.Remove("selSucursal");
            Session.Contents.Remove("FechaIniPop");
            Session.Remove("FechaIniPop");
            Session.Contents.Remove("FechaFinPop");
            Session.Remove("FechaFinPop");
            Session.Contents.Remove("FechaFinDescPop");
            Session.Remove("FechaFinDescPop");
            Session.Contents.Remove("flgDescuento");
            Session.Remove("flgDescuento");
            Session.Contents.Remove("flgDescuento");
            Session.Contents.Remove("EnabledDescuento");
            Session.Remove("EnabledDescuento");
            Session.Remove("flgApertura");
            Session.Contents.Remove("flgApertura");
            Session.Contents.Remove("EnabledAcumulacion");
            Session.Remove("EnabledAcumulacion");
            Session.Contents.Remove("TipoProm");
            Session.Remove("TipoProm");
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
    }
}