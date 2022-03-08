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
    public partial class CatPromociones : System.Web.UI.Page
    {
        private MecanicaConfiguracionConsulta ObtenerInfoSesion()
        {
            MecanicaConfiguracionConsulta obj = new MecanicaConfiguracionConsulta();
            obj.id_categoriaMecanica = 1;
            obj.CategoriaMecanica = "N+M";
            return obj;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            MecanicaConfiguracionConsulta obj = new MecanicaConfiguracionConsulta();
            obj.id_categoriaMecanica = 1;
            obj.CategoriaMecanica = "N+M";

            this.Session.Add("Mecanica", obj);

            string v = Request.QueryString["Nombre"];


            if (!this.IsPostBack)
            {
                this.lblCategoriaMecanica.Text = ObtenerInfoSesion().CategoriaMecanica;
                CargaCatalogos();

                if (v != null && v != "")
                {
                    this.txtNombre.Text = v;
                    Consulta();
                }
            }
        }

        private void CargaCatalogos()
        {
            /*Club*/
            cboClub.DataSource = BLClub.ObtenerLista(true);
            cboClub.DataTextField = "descripcion";
            cboClub.DataValueField = "id_club";
            cboClub.DataBind();

            /*Nivel*/


            /*Periodo*/
            cboPeriodo.DataSource = BLPeriodo.ObtenerLista(true);
            cboPeriodo.DataTextField = "Perido";
            cboPeriodo.DataValueField = "Id_Periodo";
            cboPeriodo.DataBind();

            /*Estatus*/

            cboEstatus.DataSource = BLStatus.ObtenerLista(true);
            cboEstatus.DataTextField = "Descripcion";
            cboEstatus.DataValueField = "Id_status";
            cboEstatus.DataBind();


            /*Nivel*/
            chkNivel.DataSource = BLNivel.ObtenerLista(true);
            chkNivel.DataTextField = "Descripcion";
            chkNivel.DataValueField = "IdNivel";
            chkNivel.DataBind();
        }



        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MecanicaConfiguracionConsulta objMecanica = ObtenerInfoSesion();

            MecanicaConfiguracionConsulta objFiltros = new MecanicaConfiguracionConsulta();
            /*Obtener Filtros*/
            //objFiltros.Id_Nivel =
            objFiltros.id_categoriaMecanica = objMecanica.id_categoriaMecanica;

            /*Fechas*/
            if (!string.IsNullOrWhiteSpace(this.txtFechaIni.Text)
                && !string.IsNullOrWhiteSpace(this.txtFechaFin.Text))
            {
                objFiltros.FechaIni = DateTime.Parse(this.txtFechaIni.Text);
                objFiltros.FechaFin = DateTime.Parse(this.txtFechaFin.Text);
            }

            if (!string.IsNullOrWhiteSpace(this.txtBeneficioIni.Text)
                && !string.IsNullOrWhiteSpace(this.txtBeneficioFin.Text))
            {
                objFiltros.BeneficioIni = int.Parse(this.txtBeneficioIni.Text);
                objFiltros.BeneficioFin = int.Parse(this.txtBeneficioFin.Text);
            }
            else
            {
                objFiltros.BeneficioIni = -1;
                objFiltros.BeneficioFin = -1;
            }

            if (!string.IsNullOrWhiteSpace(this.txtEdadIni.Text)
                && !string.IsNullOrWhiteSpace(this.txtEdadFin.Text))
            {
                objFiltros.EdadIni = int.Parse(this.txtEdadIni.Text);
                objFiltros.EdadFin = int.Parse(this.txtEdadFin.Text);
            }
            else
            {
                objFiltros.EdadIni = -1;
                objFiltros.EdadFin = -1;
            }

            if (!string.IsNullOrWhiteSpace(this.txtCompraIni.Text)
                && !string.IsNullOrWhiteSpace(this.txtCompraFin.Text))
            {
                objFiltros.CompraIni = int.Parse(this.txtCompraIni.Text);
                objFiltros.CompraFin = int.Parse(this.txtCompraFin.Text);
            }
            else
            {
                objFiltros.CompraIni = -1;
                objFiltros.CompraFin = -1;
            }


            objFiltros.Niveles = new List<Nivel>();

            /*Agrega los  niveles*/
            for (int i = 0; i < chkNivel.Items.Count; i++)
            {

                if (chkNivel.Items[i].Selected)
                {
                    // si  trae la opcion de todos es la  unica que pone
                    if (chkNivel.Items[i].Value == "-1")
                    {
                        objFiltros.Niveles = new List<Nivel>();
                        objFiltros.Niveles.Add(new Nivel() { Descripcion = chkNivel.Items[i].Text, IdNivel = -1 });
                        break;
                    }
                    else
                    {
                        objFiltros.Niveles.Add(new Nivel() { Descripcion = chkNivel.Items[i].Value, IdNivel = Convert.ToInt32(chkNivel.Items[i].Value) });
                    }

                }

            }

            objFiltros.Id_Periodo = int.Parse(cboPeriodo.SelectedValue);
            objFiltros.id_status = int.Parse(cboEstatus.SelectedValue);
            objFiltros.Id_Club = int.Parse(cboClub.SelectedValue);
            objFiltros.Nombre = this.txtNombre.Text;
            objFiltros.Descripcion = this.txtDescripcion.Text;


            this.rptConsulta.DataSource = BLMecanica.ObtenerLista(objFiltros);
            this.rptConsulta.DataBind();
        }

        protected void btnNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminMecanicas/RegistroGeneral.aspx");
        }

        protected void Consulta()
        {
            MecanicaConfiguracionConsulta objMecanica = ObtenerInfoSesion();

            MecanicaConfiguracionConsulta objFiltros = new MecanicaConfiguracionConsulta();
            /*Obtener Filtros*/
            //objFiltros.Id_Nivel =
            objFiltros.id_categoriaMecanica = objMecanica.id_categoriaMecanica;

            /*Fechas*/
            if (!string.IsNullOrWhiteSpace(this.txtFechaIni.Text)
                && !string.IsNullOrWhiteSpace(this.txtFechaFin.Text))
            {
                objFiltros.FechaIni = DateTime.Parse(this.txtFechaIni.Text);
                objFiltros.FechaFin = DateTime.Parse(this.txtFechaFin.Text);
            }

            if (!string.IsNullOrWhiteSpace(this.txtBeneficioIni.Text)
                && !string.IsNullOrWhiteSpace(this.txtBeneficioFin.Text))
            {
                objFiltros.BeneficioIni = int.Parse(this.txtBeneficioIni.Text);
                objFiltros.BeneficioFin = int.Parse(this.txtBeneficioFin.Text);
            }
            else
            {
                objFiltros.BeneficioIni = -1;
                objFiltros.BeneficioFin = -1;
            }

            if (!string.IsNullOrWhiteSpace(this.txtEdadIni.Text)
                && !string.IsNullOrWhiteSpace(this.txtEdadFin.Text))
            {
                objFiltros.EdadIni = int.Parse(this.txtEdadIni.Text);
                objFiltros.EdadFin = int.Parse(this.txtEdadFin.Text);
            }
            else
            {
                objFiltros.EdadIni = -1;
                objFiltros.EdadFin = -1;
            }

            if (!string.IsNullOrWhiteSpace(this.txtCompraIni.Text)
                && !string.IsNullOrWhiteSpace(this.txtCompraFin.Text))
            {
                objFiltros.CompraIni = int.Parse(this.txtCompraIni.Text);
                objFiltros.CompraFin = int.Parse(this.txtCompraFin.Text);
            }
            else
            {
                objFiltros.CompraIni = -1;
                objFiltros.CompraFin = -1;
            }


            objFiltros.Niveles = new List<Nivel>();

            /*Agrega los  niveles*/
            for (int i = 0; i < chkNivel.Items.Count; i++)
            {

                if (chkNivel.Items[i].Selected)
                {
                    // si  trae la opcion de todos es la  unica que pone
                    if (chkNivel.Items[i].Value == "-1")
                    {
                        objFiltros.Niveles = new List<Nivel>();
                        objFiltros.Niveles.Add(new Nivel() { Descripcion = chkNivel.Items[i].Text, IdNivel = -1 });
                        break;
                    }
                    else
                    {
                        objFiltros.Niveles.Add(new Nivel() { Descripcion = chkNivel.Items[i].Value, IdNivel = Convert.ToInt32(chkNivel.Items[i].Value) });
                    }

                }

            }

            objFiltros.Id_Periodo = int.Parse(cboPeriodo.SelectedValue);
            objFiltros.id_status = int.Parse(cboEstatus.SelectedValue);
            objFiltros.Id_Club = int.Parse(cboClub.SelectedValue);
            objFiltros.Nombre = this.txtNombre.Text;
            objFiltros.Descripcion = this.txtDescripcion.Text;


            this.rptConsulta.DataSource = BLMecanica.ObtenerLista(objFiltros);
            this.rptConsulta.DataBind();

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            long idMecanicaNivel;
            string strNombre;

            idMecanicaNivel = long.Parse(this.hdnIdMecanicaNivel.Value);
            strNombre = this.hdnNombre.Value.ToString();

            bool blnResponse = BLMecanica.CancelarMecanica(idMecanicaNivel);
            this.txtNombre.Text = strNombre;
            Consulta();
        }

        protected void txtTarjeta_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTarjeta.Text))
            {
                LlenarFiltrosPorTarjeta(txtTarjeta.Text);
                btnConsultar_Click(btnConsultar, new EventArgs());
            }
            else
            {
                txtEdadFin.Text = "";
                txtEdadIni.Text = "";
                CargaCatalogos();
            }
        }

        private void LlenarFiltrosPorTarjeta(string Tarjeta)
        {
            cboClub.DataSource = Negocio.Tarjetas.ObtenerClubs(Tarjeta);
            cboClub.DataValueField = "id_club";
            cboClub.DataTextField = "club";
            cboClub.DataBind();

            chkNivel.DataSource = Negocio.Tarjetas.ObtenerNivel(Tarjeta);
            chkNivel.DataValueField = "TarjetaNivel_intNivel";
            chkNivel.DataTextField = "nivel";
            chkNivel.DataBind();

            txtEdadFin.Text =
            txtEdadIni.Text = Negocio.Clientes.ObtenerEdad(Tarjeta); ;

            cboClub.SelectedIndex = 0;
            foreach (ListItem item in chkNivel.Items)
            {
                item.Selected = true;
            }
        }
    }
}