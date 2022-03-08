using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ORMOperacion.controles
{
    public partial class ucDireccion_CO : System.Web.UI.UserControl
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
            ddlEstado.DataSource = direccion.CargaEstados("CO").DefaultView;
            ddlEstado.DataBind();
        }
        public void CargaDireccion()
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
            LimpiaDireccion();
            CargaEstado();
            direccion.Participante = participante_id;
            direccion.TipoDireccion = tipo_direccion_id;
            direccion.Consulta("CO");
            txtCalle.Text = direccion.Calle;
            txtBarrio.Text = direccion.Colonia;
            if (direccion.EstadoID != null)
            {
                ddlEstado.SelectedValue = direccion.EstadoID;
                ddlMunicipio.DataSource = direccion.CargaDelegacionMunicipio("CO");
                ddlMunicipio.DataBind();
                if (direccion.DelegacionMunicipioID != null)
                {
                    ddlMunicipio.SelectedValue = direccion.AsentamientoID;
                }
            }
        }
        protected void LimpiaDireccion()
        {
            ddlEstado.SelectedIndex = -1;
            inicializaDDL(ddlMunicipio);
            txtCalle.Text = "";
            txtBarrio.Text = "";
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
            ddlMunicipio.DataSource = direccion.CargaDelegacionMunicipio("CO");
            ddlMunicipio.DataBind();
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
            direccion.DelegacionMunicipioID = ddlMunicipio.SelectedItem.Value;
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
            direccion.Colonia = txtBarrio.Text;
            direccion.EstadoID = ddlEstado.SelectedItem.Value;
            direccion.DelegacionMunicipioID = ddlMunicipio.SelectedItem.Value;
            direccion.AsentamientoID = ddlMunicipio.SelectedItem.Value;
            direccion.Usuario = usuario_id;
            if (!direccion.ExisteDireccion())
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