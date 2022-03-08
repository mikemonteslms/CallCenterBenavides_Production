using CNegocio;
using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallcenterNUevo.Cat
{
    public partial class RegistroGeneral : System.Web.UI.Page
    {
        private MecanicaConfiguracionConsulta ObtenerInfoSesion()
        {
            return (MecanicaConfiguracionConsulta)this.Session["Mecanica"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.lblCategoriaMecanica.Text = ObtenerInfoSesion().CategoriaMecanica;
                CargaCatalogos();
            }
        }


        private void CargaCatalogos()
        {
            /*Club*/
            cboClub.DataSource = BLClub.ObtenerLista();
            cboClub.DataTextField = "descripcion";
            cboClub.DataValueField = "id_club";
            cboClub.DataBind();

            /*Periodo*/
            cboPeriodo.DataSource = BLPeriodo.ObtenerLista();
            cboPeriodo.DataTextField = "Perido";
            cboPeriodo.DataValueField = "Id_Periodo";
            cboPeriodo.DataBind();

            /*Estatus*/
            cboEstatus.DataSource = BLStatus.ObtenerLista();
            cboEstatus.DataTextField = "Descripcion";
            cboEstatus.DataValueField = "Id_status";
            cboEstatus.DataBind();

            /*Nivel*/
            chkNivel.DataSource = BLNivel.ObtenerLista();
            chkNivel.DataTextField = "Descripcion";
            chkNivel.DataValueField = "IdNivel";
            chkNivel.DataBind();

            /*Tipo Precio*/
            cboTipoPrecio.DataSource = BLTipoPrecio.ObtenerLista();
            cboTipoPrecio.DataTextField = "Descripcion";
            cboTipoPrecio.DataValueField = "id_Tipoprecio";
            cboTipoPrecio.DataBind();
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {

            MecanicaConfiguracionConsulta objMecanica = (MecanicaConfiguracionConsulta)this.Session["Mecanica"];

            /*Fechas*/
            if (!string.IsNullOrWhiteSpace(this.txtFechaIni.Text)
                && !string.IsNullOrWhiteSpace(this.txtFechaFin.Text))
            {
                objMecanica.FechaIni = DateTime.Parse(this.txtFechaIni.Text);
                objMecanica.FechaFin = DateTime.Parse(this.txtFechaFin.Text);
            }

            if (!string.IsNullOrWhiteSpace(this.txtBeneficioIni.Text)
                && !string.IsNullOrWhiteSpace(this.txtBeneficioFin.Text))
            {
                objMecanica.BeneficioIni = int.Parse(this.txtBeneficioIni.Text);
                objMecanica.BeneficioFin = int.Parse(this.txtBeneficioFin.Text);
            }
            else
            {
                objMecanica.BeneficioIni = -1;
                objMecanica.BeneficioFin = -1;
            }

            if (!string.IsNullOrWhiteSpace(this.txtCompraIni.Text)
               && !string.IsNullOrWhiteSpace(this.txtCompraFin.Text))
            {
                objMecanica.CompraIni = int.Parse(this.txtCompraIni.Text);
                objMecanica.CompraFin = int.Parse(this.txtCompraFin.Text);
            }
            else
            {
                objMecanica.CompraIni = -1;
                objMecanica.CompraFin = -1;
            }


            if (!string.IsNullOrWhiteSpace(this.txtEdadIni.Text)
                && !string.IsNullOrWhiteSpace(this.txtEdadFin.Text))
            {
                objMecanica.EdadIni = int.Parse(this.txtEdadIni.Text);
                objMecanica.EdadFin = int.Parse(this.txtEdadFin.Text);
            }
            else
            {
                objMecanica.EdadIni = -1;
                objMecanica.EdadFin = -1;
            }

            objMecanica.Id_Periodo = int.Parse(cboPeriodo.SelectedValue);
            objMecanica.id_status = int.Parse(cboEstatus.SelectedValue);
            objMecanica.Id_Club = int.Parse(cboClub.SelectedValue);
            objMecanica.Nombre = this.txtNombre.Text;
            objMecanica.Descripcion = this.txtDescripcion.Text;
            objMecanica.Limite = int.Parse(this.txtLimite.Text);

            objMecanica.Niveles = new List<Nivel>();

            objMecanica.IdTipoPrecio = int.Parse(cboTipoPrecio.SelectedValue);

            /*Agrega los  niveles*/
            for (int i = 0; i < chkNivel.Items.Count; i++)
            {

                if (chkNivel.Items[i].Selected)
                {
                    // si  trae la opcion de todos es la  unica que pone
                    if (chkNivel.Items[i].Value == "-1")
                    {
                        objMecanica.Niveles = new List<Nivel>();
                        objMecanica.Niveles.Add(new Nivel() { Descripcion = chkNivel.Items[i].Text, IdNivel = -1 });
                        break;
                    }
                    else
                    {
                        objMecanica.Niveles.Add(new Nivel() { Descripcion = chkNivel.Items[i].Value, IdNivel = Convert.ToInt32(chkNivel.Items[i].Value) });
                    }

                }

            }


            this.Session.Add("Mecanica", objMecanica);
            string Pagina = string.Empty;
            switch (objMecanica.id_categoriaMecanica)
            {
                case 1:
                    Pagina = "~/AdminMecanicas/NM_Piezas.aspx";
                    break;
                case 2:
                    Pagina = "~/AdminMecanicas/Lista.aspx";
                    break;
                case 3:
                    Pagina = "~/AdminMecanicas/Combo.aspx";
                    break;
                case 4:
                    Pagina = "~/AdminMecanicas/ComboLN_LM.aspx";
                    break;
                default:
                    Pagina = "~/AdminMecanicas/NM_Piezas.aspx";
                    break;
            }
            Response.Redirect(Pagina);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            Response.Redirect("ConsultaPromo.aspx");
        }
    }
}