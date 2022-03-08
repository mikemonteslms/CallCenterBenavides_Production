using CNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallcenterNUevo.Cat
{
    public partial class NuevaPromo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.rdCategoriaMecanica.DataSource = BLCategoriaMecanica.ObtenerLista();
                this.rdCategoriaMecanica.DataTextField = "Descripcion";
                this.rdCategoriaMecanica.DataValueField = "id_categoriaMecanica";
                this.rdCategoriaMecanica.DataBind();
            }
        }
        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            string valor = this.rdCategoriaMecanica.SelectedValue;  

            MecanicaConfiguracionConsulta objMecanica = new MecanicaConfiguracionConsulta();
            objMecanica.id_categoriaMecanica = int.Parse(valor);
            objMecanica.CategoriaMecanica = rdCategoriaMecanica.SelectedItem.Text;

            this.Session.Add("Mecanica", objMecanica);
            Response.Redirect("ConsultaPromo.aspx");
        }
    }
}