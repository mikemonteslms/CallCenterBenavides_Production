using CNegocio;
using Entidades;
using ORMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallcenterNUevo.AdminMecanicas
{
    public partial class NM_Piezas : System.Web.UI.Page
    {
        private MecanicaConfiguracionConsulta ObtenerInfoSesion()
        {
            return (MecanicaConfiguracionConsulta)this.Session["Mecanica"];
        }

        private static MecanicaConfiguracionConsulta ObtenerInfoSesionWebMethod()
        {
            return (MecanicaConfiguracionConsulta)HttpContext.Current.Session["Mecanica"];
        }

        private static void GuardarInfoSesionWebMethod(MecanicaConfiguracionConsulta info)
        {
            HttpContext.Current.Session["Mecanica"] = info;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                MecanicaConfiguracionConsulta infoSesion = ObtenerInfoSesion();
                this.lblCategoriaMecanica.Text = "Registro: " + infoSesion.CategoriaMecanica;
                this.lblNombre.Text = infoSesion.Nombre;
                this.lblDescripción.Text = infoSesion.Descripcion;

            }
        }

        [ScriptMethod]
        [System.Web.Services.WebMethod]
        public static string GetCategorias(string strBusqueda)
        {
            string Resultado = string.Empty;
            JavaScriptSerializer serializer;
            serializer = new JavaScriptSerializer();
            Resultado = serializer.Serialize(BLMecanica.ObtenerListaProductoCategoria(strBusqueda));
            return Resultado;
        }

        [ScriptMethod]
        [System.Web.Services.WebMethod]
        public static string GetProductos(string strBusqueda)
        {
            string Resultado = string.Empty;
            JavaScriptSerializer serializer;
            serializer = new JavaScriptSerializer();
            int Categoria = 0;
            List<ProductoM> lstProducto = new List<ProductoM>();
            if (int.TryParse(strBusqueda, out Categoria))
            {
                lstProducto = BLMecanica.ObtenerListaProducto(Categoria);
            }
            Resultado = serializer.Serialize(lstProducto);
            return Resultado;
        }

        [ScriptMethod]
        [System.Web.Services.WebMethod]
        public static string GuardarProductos(ProductoSeleccionado[] objSeleccion)
        {

            MecanicaConfiguracionConsulta objMecanica = ObtenerInfoSesionWebMethod();
            objMecanica.PiezasLM = new List<ProductoSeleccionado>();
            objMecanica.PiezasLM.AddRange(objSeleccion);
            GuardarInfoSesionWebMethod(objMecanica);

            BLMecanica.AltaMecanica_LM(objMecanica);

            string Resultado = string.Empty;
            JavaScriptSerializer serializer;
            serializer = new JavaScriptSerializer();
            Resultado = serializer.Serialize("ok");
            return Resultado;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Catalogos/SeleccionPromocion.aspx");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

    }
}