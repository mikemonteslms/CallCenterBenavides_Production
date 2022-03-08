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
    public partial class Combo : System.Web.UI.Page
    {
       private static MecanicaConfiguracionConsulta ObtenerInfoSesionWebMethod()
        {
            return (MecanicaConfiguracionConsulta)HttpContext.Current.Session["Mecanica"];
        }

        private static void GuardarInfoSesionWebMethod(MecanicaConfiguracionConsulta info)
        {
            HttpContext.Current.Session["Mecanica"] = info;
        }
        private MecanicaConfiguracionConsulta ObtenerInfoSesion()
        {
            return (MecanicaConfiguracionConsulta)this.Session["Mecanica"];
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Catalogos/ConsultaPromo.aspx");
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminMecanicas/ComboBeneficio.aspx");
        }


        [ScriptMethod]
        [System.Web.Services.WebMethod]
        public static string GuardarProductos(ProductoSeleccionadoLista[] objSeleccion)
        {
            string Resultado = string.Empty;
            JavaScriptSerializer serializer;
            serializer = new JavaScriptSerializer();
            Resultado = serializer.Serialize("ok");
            MecanicaConfiguracionConsulta objMecanica = ObtenerInfoSesionWebMethod();
            objMecanica.PiezasLista = new List<ProductoSeleccionadoLista>();
            objMecanica.PiezasLista.AddRange(objSeleccion);
            GuardarInfoSesionWebMethod(objMecanica);
            return Resultado;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}