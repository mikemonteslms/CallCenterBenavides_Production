using CNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallcenterNUevo.AdminMecanicas
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string v = Request.QueryString["id"];
            string nv = Request.QueryString["nv"];
            long id = 0;
            int idNivel = 0;
            btnCancelar.Attributes.Add("onclick", "history.back(); return false;");

            if (long.TryParse(v, out id) && int.TryParse(nv, out idNivel))
            {
                MecanicaConfiguracionConsulta obj = BLMecanica.ObtenerDetalle(id, idNivel);
                SetInfoMecanica(obj);
            }
        }

        private void SetInfoMecanica(MecanicaConfiguracionConsulta obj)
        {
            this.txtBeneficioFin.Text = obj.BeneficioFin.ToString();
            this.txtBeneficioIni.Text = obj.BeneficioIni.ToString();
            this.txtClub.Text = obj.DescClub.ToString();
            this.txtCompraFin.Text = obj.CompraFin.ToString();
            this.txtCompraIni.Text = obj.CompraIni.ToString();
            this.txtDescripcion.Text = obj.Descripcion.ToString();
            this.txtEdadFin.Text = obj.EdadFin.ToString();
            this.txtEdadIni.Text = obj.EdadIni.ToString();
            this.txtFechaFin.Text = ((DateTime)obj.FechaFin).ToString("dd/MM/yyyy");
            this.txtFechaIni.Text = ((DateTime)obj.FechaIni).ToString("dd/MM/yyyy");
            this.txtLimite.Text = obj.Limite.ToString();
            this.txtNombre.Text = obj.Nombre.ToString();
            this.txtPeriodo.Text = obj.Perido.ToString();
            this.txtNivel.Text = obj.DescNivel.ToString();
            this.txtCategoria.Text = obj.CategoriaMecanica;
            this.txtEstatus.Text = obj.Status;
            this.txtTipoPrecio.Text = obj.DescTipoPrecio;

            this.rptPiezas.DataSource = obj.PiezasLista;
            this.rptPiezas.DataBind();

            this.rptBeneficio.DataSource = obj.BeneficioLista;
            this.rptBeneficio.DataBind();
        }

        /*protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminMecanicas/ConsultaPromo.aspx");
        }*/
    }
}