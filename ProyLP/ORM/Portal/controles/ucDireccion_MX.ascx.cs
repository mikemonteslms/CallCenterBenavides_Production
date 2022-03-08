using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Portal.controles
{
    public partial class ucDireccion_MX : System.Web.UI.UserControl
    {
        private SqlConnection conn;
        private SqlTransaction tran;

        private string usuario_id;
        private string participante_id;
        private string tipo_direccion_id;

        csDireccion direccion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaEstado();
            }
        }
        public string Usuario_ID
        {
            set
            {
                usuario_id = value;
            }
        }
        public string Participante_ID
        {
            set
            {
                participante_id = value;
            }
        }
        public string TipoDireccion_ID
        {
            set
            {
                tipo_direccion_id = value;
            }
        }
        public SqlConnection Conexion
        {
            set { this.conn = value; }
        }
        public SqlTransaction Transaccion
        {
            set { this.tran = value; }
        }
        protected void inicializaDDL(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("Seleccione", "0"));
        }
        private void CargaEstado()
        {
            if (this.conn == null && this.tran == null)
            {
                direccion = new csDireccion();
            }
            else if (this.conn != null && this.tran == null)
            {
                direccion = new csDireccion(conn);
            }
            else if (this.conn != null && this.tran != null)
            {
                direccion = new csDireccion(conn, tran);
            }
            inicializaDDL(ddlEstado);
            ddlEstado.DataSource = direccion.CargaEstados("MX").DefaultView;
            ddlEstado.DataBind();
        }
        public bool CargaDireccion()
        {
            bool resultado = false;

            if (this.conn == null && this.tran == null)
            {
                direccion = new csDireccion();
            }
            else if (this.conn != null && this.tran == null)
            {
                direccion = new csDireccion(conn);
            }
            else if (this.conn != null && this.tran != null)
            {
                direccion = new csDireccion(conn, tran);
            }
           

            LimpiaDireccion();
            CargaEstado();
            direccion.Participante = participante_id;
            direccion.TipoDireccion = tipo_direccion_id;
            if (direccion.ExisteDireccion("MX"))
            {
                resultado = true;
            }
            direccion.Consulta("MX");
            txtCalle.Text = direccion.Calle;
            txtNumeroExterior.Text = direccion.NumeroExterior;
            txtNumeroInterior.Text = direccion.NumeroInterior;
            //txtEntreCalle.Text = direccion.EntreCalle;
            //txtYCalle.Text = direccion.YCalle;
            //txtReferencias.Text = direccion.Referencias;
            if (direccion.EstadoID != null)
            {
                ddlEstado.SelectedValue = direccion.EstadoID;
                ddlMunicipio.DataSource = direccion.CargaDelegacionMunicipio("MX");
                ddlMunicipio.DataBind();
                if (direccion.DelegacionMunicipioID != null)
                {
                    ddlMunicipio.SelectedValue = direccion.DelegacionMunicipioID;
                    ddlAsentamiento.DataSource = direccion.CargaAsentamientos("MX");
                    ddlAsentamiento.DataBind();
                    if (direccion.AsentamientoID != null)
                    {
                        ddlAsentamiento.SelectedValue = direccion.AsentamientoID;
                        mvColonia.SetActiveView(vColonia);
                    }
                    else
                    {
                        txtOtraColonia.Text = direccion.Colonia;
                        mvColonia.SetActiveView(vOtraColonia);
                    }
                    if (direccion.Ciudad != null)
                    {
                        //txtCiudad.Text = direccion.Ciudad;
                    }
                    if (direccion.CodigoPostal != null)
                    {
                        txtCodigoPostal.Text = direccion.CodigoPostal;
                    }
                }
            }

            return resultado;
        }
        protected void LimpiaDireccion()
        {
            ddlEstado.SelectedIndex = -1;
            inicializaDDL(ddlMunicipio);
            inicializaDDL(ddlAsentamiento);
            txtOtraColonia.Text = "";
            //txtCiudad.Text = "";
            txtCodigoPostal.Text = "";
            txtCalle.Text = "";
            txtNumeroExterior.Text = "";
            txtNumeroInterior.Text = "";
            // txtEntreCalle.Text = "";
            //txtYCalle.Text = "";
            //txtReferencias.Text = "";
        }
        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.conn == null && this.tran == null)
            {
                direccion = new csDireccion();
            }
            else if (this.conn != null && this.tran == null)
            {
                direccion = new csDireccion(conn);
            }
            else if (this.conn != null && this.tran != null)
            {
                direccion = new csDireccion(conn, tran);
            }
            inicializaDDL(ddlMunicipio);
            direccion.EstadoID = ddlEstado.SelectedItem.Value;
            ddlMunicipio.DataSource = direccion.CargaDelegacionMunicipio("MX");
            ddlMunicipio.DataBind();
            ddlAsentamiento.Items.Clear();
            txtCodigoPostal.Text = "";
        }
        protected void ddlMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.conn == null && this.tran == null)
            {
                direccion = new csDireccion();
            }
            else if (this.conn != null && this.tran == null)
            {
                direccion = new csDireccion(conn);
            }
            else if (this.conn != null && this.tran != null)
            {
                direccion = new csDireccion(conn, tran);
            }
            inicializaDDL(ddlAsentamiento);
            direccion.DelegacionMunicipioID = ddlMunicipio.SelectedItem.Value;
            ddlAsentamiento.DataSource = direccion.CargaAsentamientos("MX");
            ddlAsentamiento.DataBind();
            txtCodigoPostal.Text = "";
        }
        protected void ddlAsentamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.conn == null && this.tran == null)
            {
                direccion = new csDireccion();
            }
            else if (this.conn != null && this.tran == null)
            {
                direccion = new csDireccion(conn);
            }
            else if (this.conn != null && this.tran != null)
            {
                direccion = new csDireccion(conn, tran);
            }
            direccion.AsentamientoID = ddlAsentamiento.SelectedItem.Value;
            direccion.CargaCodigoPostalCiudad("MX");
            //txtCiudad.Text = direccion.Ciudad;
            txtCodigoPostal.Text = direccion.CodigoPostal;
        }
        protected void btnBuscaXPC_Click(object sender, EventArgs e)
        {
            if (this.conn == null && this.tran == null)
            {
                direccion = new csDireccion();
            }
            else if (this.conn != null && this.tran == null)
            {
                direccion = new csDireccion(conn);
            }
            else if (this.conn != null && this.tran != null)
            {
                direccion = new csDireccion(conn, tran);
            }
            inicializaDDL(ddlMunicipio);
            inicializaDDL(ddlAsentamiento);

            direccion.CodigoPostal = txtCodigoPostal.Text;
            direccion.BuscaDireccionXCP("MX");
            if (direccion.EstadoID != null && direccion.DelegacionMunicipioID != null && direccion.Ciudad != null)
            {
                ddlEstado.SelectedValue = direccion.EstadoID;
                ddlMunicipio.DataSource = direccion.CargaDelegacionMunicipio("MX");
                ddlMunicipio.DataBind();
                ddlMunicipio.SelectedValue = direccion.DelegacionMunicipioID;
                ddlAsentamiento.DataSource = direccion.CargaAsentamientosCP("MX");
                ddlAsentamiento.DataBind();
                mvColonia.SetActiveView(vColonia);
            }
            else
            {
                ddlEstado.SelectedIndex = -1;
                txtOtraColonia.Text = "";
            }
        }
        protected void btnOtraColonia_Click(object sender, EventArgs e)
        {
            mvColonia.SetActiveView(vOtraColonia);
        }
        protected void btnRegresarColonia_Click(object sender, EventArgs e)
        {
            mvColonia.SetActiveView(vColonia);
        }
        public void Modifica()
        {
            if (this.conn == null && this.tran == null)
            {
                direccion = new csDireccion();
            }
            else if (this.conn != null && this.tran == null)
            {
                direccion = new csDireccion(conn);
            }
            else if (this.conn != null && this.tran != null)
            {
                direccion = new csDireccion(conn, tran);
            }
            direccion.Participante = participante_id;
            direccion.TipoDireccion = tipo_direccion_id;
            direccion.Calle = txtCalle.Text;
            direccion.NumeroExterior = txtNumeroExterior.Text;
            direccion.NumeroInterior = txtNumeroInterior.Text;
            // direccion.EntreCalle = txtEntreCalle.Text;
            //direccion.YCalle = txtYCalle.Text;
            //direccion.Referencias = txtReferencias.Text;
            if (mvColonia.ActiveViewIndex == 0)
            {
                direccion.Colonia = ddlAsentamiento.SelectedItem.Text;
                direccion.AsentamientoID = ddlAsentamiento.SelectedItem.Value;
            }
            else if (mvColonia.ActiveViewIndex == 1)
            {
                direccion.Colonia = txtOtraColonia.Text;
                direccion.AsentamientoID = null;
            }
            direccion.CodigoPostal = txtCodigoPostal.Text;
            direccion.Usuario = usuario_id;
            if (!direccion.ExisteDireccion("MX"))
            {
                direccion.Inserta();
            }
            else
            {
                direccion.Actualiza();
            }
        }
    }
}