using CNegocio;
using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CallcenterNUevo.AdminMecanicas
{
    public partial class Copiar : System.Web.UI.Page
    {
        private MecanicaConfiguracionConsulta ObtenerInfoSesion()
        {
            return (MecanicaConfiguracionConsulta)this.Session["Mecanica"];
        }

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
                    CargaCatalogos();
                    SetInfoMecanica(obj);
                    ObtenerInfoSesion().Id_MecanicaConfiguracion = Convert.ToInt32(v);
                }
            }
        }

        private void SetInfoMecanica(MecanicaConfiguracionConsulta obj)
        {
            int i = 0;
            this.txtBeneficioFin.Text = obj.BeneficioFin.ToString();
            this.txtBeneficioIni.Text = obj.BeneficioIni.ToString();
            //this.txtClub.Text = obj.DescClub.ToString();

            foreach (ListItem lstI in cboClub.Items)
            {
                if (lstI.Text == obj.DescClub.ToString())
                {
                    this.cboClub.SelectedIndex = i;
                }
                i++;
            }

            this.txtCompraFin.Text = obj.CompraFin.ToString();
            this.txtCompraIni.Text = obj.CompraIni.ToString();
            this.txtDescripcion.Text = obj.Descripcion.ToString();
            this.txtEdadFin.Text = obj.EdadFin.ToString();
            this.txtEdadIni.Text = obj.EdadIni.ToString();
            this.txtFechaFin.Text = ((DateTime)obj.FechaFin).ToString("dd/MM/yyyy");
            this.txtFechaIni.Text = ((DateTime)obj.FechaIni).ToString("dd/MM/yyyy");
            this.txtLimite.Text = obj.Limite.ToString();
            this.txtNombre.Text = obj.Nombre.ToString();
            i = 0;
            //this.txtPeriodo.Text = obj.Perido.ToString();
            foreach (ListItem lstI in cboPeriodo.Items)
            {
                if (lstI.Text == obj.Perido.ToString())
                {
                    this.cboPeriodo.SelectedIndex = i;
                }
                i++;
            }

            i = 0;
            //this.txtNivel.Text = obj.DescNivel.ToString();
            foreach (ListItem lstI in chkNivel.Items)
            {
                if (lstI.Text == obj.DescNivel.ToString())
                {
                    this.chkNivel.Items[i].Selected = true;
                }
                i++;
            }

            this.txtCategoria.Text = obj.CategoriaMecanica;

            i = 0;
            //this.txtEstatus.Text = obj.Status;
            foreach (ListItem lstI in cboEstatus.Items)
            {
                if (lstI.Text == obj.Status.ToString())
                {
                    this.cboEstatus.SelectedIndex = i;
                }
                i++;
            }
            this.rptPiezas.DataSource = obj.PiezasLista;
            this.rptPiezas.DataBind();

            this.rptBeneficio.DataSource = obj.BeneficioLista;
            this.rptBeneficio.DataBind();
        }


        private void CargaCatalogos()
        {
            /*Club*/
            cboClub.DataSource = BLClub.ObtenerLista();
            cboClub.DataTextField = "descripcion";
            cboClub.DataValueField = "id_club";
            cboClub.DataBind();

            /*Nivel*/


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
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminMecanicas/ConsultaPromo.aspx");
        }

        private bool Guardar()
        {


            MecanicaConfiguracionConsulta objMecanica = new MecanicaConfiguracionConsulta();


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
            if (!string.IsNullOrWhiteSpace(this.txtLimite.Text))
            {
                objMecanica.Limite = int.Parse(this.txtLimite.Text);

            }
            else
            {
                objMecanica.Limite = -1;

            }

            objMecanica.Id_Periodo = int.Parse(cboPeriodo.SelectedValue);
            objMecanica.id_status = int.Parse(cboEstatus.SelectedValue);
            objMecanica.Id_Club = int.Parse(cboClub.SelectedValue);
            objMecanica.Nombre = this.txtNombre.Text;
            objMecanica.Descripcion = this.txtDescripcion.Text;

            objMecanica.Niveles = new List<Nivel>();

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

            objMecanica.id_categoriaMecanica = ObtenerInfoSesion().id_categoriaMecanica;
            objMecanica.Id_MecanicaConfiguracion = ObtenerInfoSesion().Id_MecanicaConfiguracion;

            return BLMecanica.CopiarMecanica(objMecanica);

        }

        protected void btnGuardar0_Click(object sender, EventArgs e)
        {
            if (Guardar())
            {
                Response.Redirect("~/Catalogos/ConsultaPromo.aspx");
            }
        }

    }
}