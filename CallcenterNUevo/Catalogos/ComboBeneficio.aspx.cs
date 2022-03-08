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

namespace CallcenterNUevo.Cat
{
    public partial class ComboBeneficio : System.Web.UI.Page
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
                this.lblCategoriaMecanica.Text = infoSesion.CategoriaMecanica;
                this.lblNombre.Text = infoSesion.Nombre;
                this.lblDescripción.Text = infoSesion.Descripcion;
            }
        }


        [ScriptMethod]
        [System.Web.Services.WebMethod]
        public static string GuardarProductosBeneficio(ProductoSeleccionadoLista[] objSeleccion)
        {
            string Resultado = string.Empty;
            JavaScriptSerializer serializer;
            serializer = new JavaScriptSerializer();
            Resultado = serializer.Serialize("ok");
            MecanicaConfiguracionConsulta objMecanica = ObtenerInfoSesionWebMethod();
            objMecanica.BeneficioLista = new List<ProductoSeleccionadoLista>();
            objMecanica.BeneficioLista.AddRange(objSeleccion);
            GuardarInfoSesionWebMethod(objMecanica);
            BLMecanica.AltaMecanica_Combo(objMecanica);
            return Resultado;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Catalogos/NuevaPromo.aspx");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}