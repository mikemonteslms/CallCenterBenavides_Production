using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Negocio;
using Entidades;
using CallcenterNUevo.WsReglasNegocio;



namespace CallcenterNUevo.CALLCENTER
{
    public partial class rptHistorico : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();
        EntActualizarCliente ent = new EntActualizarCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.MenuMain = "Operacion";
            Master.Submenu = "Movimientos";
            if (!Page.IsPostBack)
            {
                if (Session["strTarjeta"] != null)
                {
                    CargaTransaccionesCliente(Session["strTarjeta"].ToString());
                    CargarPiezasGratisCliente(Session["strTarjeta"].ToString());
                    CargarConsultaLaboratorios(Session["strTarjeta"].ToString());
                }
            }
        }

        protected void btnCOnsultar_Click(object sender, EventArgs e)
        {
            //CargaTransaccionesCliente(txtTDestino.Text);
            //CargarPiezasGratisCliente(txtTDestino.Text);
            //CargarConsultaLaboratorios(txtTDestino.Text);
        }

        private void CargarConsultaLaboratorios(string Tarjeta)
        {
            WsReglasNegocio.WsReglasNegocioSoapClient objServicio = new WsReglasNegocio.WsReglasNegocioSoapClient();
            ConsultaMovimientosResult obj = objServicio.ConsultaMovimientos(Tarjeta, 0, "", 20);
            Movimiento[] objMov = obj.Data;
            grvLabs.DataSource = objMov;
            grvLabs.DataBind();
        }
        private void CargarPiezasGratisCliente(string idcliente)
        {
            try
            {
                objDataset = cliente.ObtenerHistoricoPiezasGratis(idcliente);
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    grvPiezasGratis.DataSource = objDataset.Tables[0];
                    grvPiezasGratis.DataBind();
                }
                else
                    grvPiezasGratis.DataSource = null;
            }
            catch (Exception ex)
            { }
        }
        protected void CargaTransaccionesCliente(string idcliente)
        {
            try
            {

                objDataset = cliente.DatosTransaccionesCliente(idcliente);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    grvTransacciones.DataSource = objDataset;
                    grvTransacciones.DataBind();
                }
                else
                {
                    grvTransacciones.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }
    }
}