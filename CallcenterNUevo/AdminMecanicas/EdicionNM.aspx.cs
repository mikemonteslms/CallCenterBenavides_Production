using CNegocio;
using Entidades;
using ORMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallcenterNUevo.AdminMecanicas
{
    public partial class EdicionNM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string v = Request.QueryString["id"];
                string nv = Request.QueryString["nv"];
                long id = 0;
                int idNivel = 0;


                if (long.TryParse(v, out id) && int.TryParse(nv, out idNivel))
                {
                    MecanicaConfiguracionConsulta obj = BLMecanica.ObtenerDetalle(id, idNivel);
                    SetInfoMecanica(obj);
                }
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


            this.rptPiezas.DataSource = obj.PiezasLista;
            this.rptPiezas.DataBind();

            this.rptBeneficio.DataSource = obj.BeneficioLista;
            this.rptBeneficio.DataBind();

            this.Session["Edicion"] = obj;
        }


        private MecanicaConfiguracionConsulta GetInfoMecanica()
        {
            //obj.BeneficioFin = int.Parse(this.txtBeneficioFin.Text);
            //obj.BeneficioIni = int.Parse(this.txtBeneficioIni.Text);

            //obj.CompraFin = int.Parse(this.txtCompraFin.Text);
            //obj.CompraIni = int.Parse(this.txtCompraIni.Text);

            //obj.EdadFin = int.Parse(this.txtEdadFin.Text);
            //obj.EdadIni = int.Parse(this.txtEdadIni.Text);

            //obj.FechaFin = DateTime.ParseExact(this.txtFechaFin.Text,"dd/MM/yyyy",null);
            //obj.FechaIni = DateTime.ParseExact(this.txtFechaIni.Text, "dd/MM/yyyy", null);

            //obj.Limite = int.Parse(this.txtLimite.Text);

            MecanicaConfiguracionConsulta objSession = (MecanicaConfiguracionConsulta)this.Session["Edicion"];


            objSession.Nombre = this.txtNombre.Text;
            objSession.Descripcion = this.txtDescripcion.Text;
            int CantPiezas = 0;
            int CantBeneficio = 0;
            int.TryParse(this.hdnCantidadPiezas.Value, out CantPiezas);
            int.TryParse(this.hdnCantidadBeneficio.Value, out CantBeneficio);

            foreach (ProductoSeleccionadoLista prod in objSession.PiezasLista)
            {
                prod.Cantidad = CantPiezas.ToString();
            }

            foreach (ProductoSeleccionadoLista prod in objSession.BeneficioLista)
            {
                prod.Cantidad = CantBeneficio.ToString();
            }
            return objSession;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            MecanicaConfiguracionConsulta obj = GetInfoMecanica();
            BLMecanica.EdicionMecanica_LM(obj);
            Response.Redirect("~/Catalogos/ConsultaPromo.aspx?Nombre=" + this.txtNombre.Text);

        }
    }
}