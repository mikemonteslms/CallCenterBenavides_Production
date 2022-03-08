using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Portal.controles
{
    public partial class ucDireccionDistribuidor_MX : System.Web.UI.UserControl
    {

        private csDataBase database;
        private SqlConnection conn;
        private SqlTransaction tran;
        private List<SqlParameter> parametros;
        private string distribuidora_id;
        private string participante_id;
        public string Distribuidora_ID
        {
            set
            {
                distribuidora_id = value;
            }
        }

        public string Participante_ID
        {
            set
            {
                participante_id = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargaDireccion();
        }

        public void CargaDireccion()
        {
            LimpiaDireccion();
            //cargaDireccionDistribuidora();
            cargaDireccionParticipante();
        }

        protected void LimpiaDireccion()
        {
            lblRazonSocial.Text = "";
            lblTelefono.Text = "";
            lblCalle.Text = "";
            lblNumeroExterior.Text = "";
            lblEntre_Calle.Text = "";
            lblYCalle.Text = "";
            lblColonia.Text = "";
            lblDelegacion.Text = "";
            lblEstado.Text = "";
            lblCP.Text = "";
        }

        protected void cargaDireccionDistribuidora()
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@distribuidor_id", distribuidora_id));
            database = new csDataBase();
            database.Query = "ObtieneDireccionDistribuidora";
            database.Parametros = parametros;
            database.EsStoreProcedure = true;
            DataTable dtDirDis = database.dtConsulta();
            if (dtDirDis.Rows.Count > 0)
            {
                DataRow drDirDis = dtDirDis.Rows[0];
                lblRazonSocial.Text = drDirDis["razon_social"].ToString();
                lblTelefono.Text = drDirDis["telefono"].ToString();
                lblCalle.Text = drDirDis["calle"].ToString();
                lblNumeroExterior.Text = drDirDis["numero"].ToString();
                lblEntre_Calle.Text = drDirDis["entre_calle"].ToString();
                lblYCalle.Text = drDirDis["y_calle"].ToString();
                lblColonia.Text = drDirDis["colonia"].ToString();
                lblDelegacion.Text = drDirDis["municipio"].ToString();
                lblEstado.Text = drDirDis["estado"].ToString();
                lblCP.Text = drDirDis["codigo_postal"].ToString();
            }
        }

        protected void cargaDireccionParticipante()
        {            
            tdRazon_Social_Telefono1.Visible = false;
            tdRazon_Social_Telefono2.Visible = false;
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@participante_id", participante_id));
            database = new csDataBase();
            database.Query = "sp_consulta_participante_direccion_aux";
            database.Parametros = parametros;
            database.EsStoreProcedure = true;
            DataTable dtDirParticipante = database.dtConsulta();
            if (dtDirParticipante.Rows.Count > 0)
            {
                DataRow drDirParticipante = dtDirParticipante.Rows[0];
                //lblRazonSocial.Text = drDirParticipante["razon_social"].ToString();
                //lblTelefono.Text = drDirParticipante["telefono"].ToString();
                lblCalle.Text = drDirParticipante["calle"].ToString();
                lblNumeroExterior.Text = drDirParticipante["numero_exterior"].ToString();
                lblEntre_Calle.Text = drDirParticipante["entrecalle_1"].ToString();
                lblYCalle.Text = drDirParticipante["entrecalle_2"].ToString();
                lblColonia.Text = drDirParticipante["colonia"].ToString();
                lblDelegacion.Text = drDirParticipante["ciudad"].ToString();
                lblEstado.Text = drDirParticipante["estado"].ToString();
                lblCP.Text = drDirParticipante["codigo_postal"].ToString();
            }        
        }
    }
}