using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Configuration;

namespace ORMOperacion
{
    public partial class consultaTransacciones : System.Web.UI.Page
    {
        csParticipante participante;
        String countryCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                if (Session["participante_id"] != null)
                {
                    Master.Menu = "Participantes";
                    Master.Submenu = "Consulta Transacciones";

                    imgCancelar.ImageUrl = "style/images/cancel.png";
                    ObtienePrograma(Session["participante_id"].ToString());
                    ObtieneDatosParticipante(Session["participante_id"].ToString());
                    //ObtieneTransacciones(Session["participante_id"].ToString());
                }
                else
                    Response.Redirect("Default.aspx", false);
            }
        }

        protected void ObtienePrograma(string participante_id)
        {
            csCountry country = new csCountry();
            country.ObtienePrograma_Participante(Session["participante_id"].ToString());
            countryCode = country.CountryCode2;
        }

        protected void ObtieneDatosParticipante(string participante_id)
        {
            string saldo = "0";
            countryCode = "mx";
            switch (countryCode.ToLower())
            {
                case "mx":
                    participante = new csParticipanteComplementoMX();
                    break;
            }

            participante.ID = participante_id;
            participante.DatosParticipante();

            lblNombreParticipante.Text = participante.RazoSocial.ToUpper();
            lblClaveParticipante.Text = participante.Clave.ToUpper();
            saldo = participante.Saldo;
            if (saldo == "0")
                lblSaldo.Text = saldo;
            else
                lblSaldo.Text = Convert.ToInt32(saldo).ToString("N0");
        }

        protected void ObtieneTransacciones(string participante_id)
        {
            ObtienePrograma(participante_id);
            participante = new csParticipanteComplemento();
            participante.ID = participante_id;
            participante.OrigenID = "0";
            participante.DatosParticipante();
            DataTable dtTransacciones = new DataTable();
            dtTransacciones = participante.Transacciones();
            lblRegistros.Text = dtTransacciones.Rows.Count + " transaccion(es) encontrada(s).";
            gvTransacciones.DataSource = dtTransacciones.DefaultView;
            gvTransacciones.DataBind();
        }


        protected void ObtieneTransaccionDetalle(String transaccion_id)
        {
            try
            {
                csDataBase query = new csDataBase();
                query.Query = "sp_consulta_transacciones_detalle";
                query.EsStoreProcedure = true;
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@transaccion_id", transaccion_id));
                query.Parametros = param;
                DataTable dtTransaccion = query.dtConsulta();
                gvDetalleTransaccion.DataSource = dtTransaccion;
                gvDetalleTransaccion.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void gvTransacciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            System.Data.DataRowView drv;
            drv = (System.Data.DataRowView)e.Row.DataItem;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (drv != null)
                {
                    int puntos = Convert.ToInt32(drv.Row.ItemArray[4]);
                    if (puntos == 0)
                        e.Row.Cells[2].Text = "0";
                }
            }
        }

        protected void gvTransacciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gvTransacciones.PageIndex = e.NewPageIndex;
            ObtieneTransacciones(Session["participante_id"].ToString());
        }

        public void ConsultaObjetivos_CO()
        {
            participante = new csParticipante();
            participante.ID = Session["participante_id"].ToString();
            DataTable dt = new DataTable();
            dt = participante.ConsultaObjetivos_co();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    mvObjetivos.SetActiveView(vObjetivos);
                    lblTitulo.Visible = true;
                    FormatearGrid(dt);
                }
            }
        }

        public void FormatearGrid(DataTable dt)
        {
            // FormatearValores(dt);
            int i = 0;
            gvObjetivos.Columns.Clear();
            foreach (DataColumn columna in dt.Columns)
            {
                BoundField objBound = new BoundField();
                objBound.HeaderText = columna.ColumnName;
                objBound.DataField = columna.ColumnName;
                if (i > 0)
                    objBound.DataFormatString = "{0:N}";
                gvObjetivos.Columns.Add(objBound);
                i++;
            }
            gvObjetivos.DataSource = dt;
            gvObjetivos.DataBind();
        }

        protected void gvObjetivos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvObjetivos.PageIndex = e.NewPageIndex;
            ConsultaObjetivos_CO();
        }

        protected void gvObjetivos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[0].Width = Unit.Pixel(80);
                gvObjetivos.Width = Unit.Pixel(80 + 110 * (e.Row.Cells.Count - 1));
            }
        }

        //protected void gvTransacciones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    Session["transaccion_id"] = gvTransacciones.DataKeys[e.RowIndex].Values["id"].ToString();
        //    ObtieneTransaccionDetalle(Session["transaccion_id"].ToString());
        //    popDetalleTransaccion.Show();
        //}

        //protected void gvDetalleTransaccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvDetalleTransaccion.PageIndex = e.NewPageIndex;
        //    ObtieneTransaccionDetalle(Session["transaccion_id"].ToString());
        //    popDetalleTransaccion.Show();
        //}

        protected void lnkbVerDetalle_Click(object sender, EventArgs e)
        {            
            ObtieneTransaccionDetalle(((LinkButton)sender).CommandArgument);
            popDetalleTransaccion.Show();
        }

        protected void gvTransacciones_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (Session["participante_id"] != null)
            {
                ObtienePrograma(Session["participante_id"].ToString());
                participante = new csParticipanteComplemento();
                participante.ID = Session["participante_id"].ToString();
                participante.OrigenID = "0";
                participante.DatosParticipante();
                DataTable dtTransacciones = new DataTable();
                dtTransacciones = participante.Transacciones();
                lblRegistros.Text = dtTransacciones.Rows.Count + " transaccion(es) encontrada(s).";
                gvTransacciones.DataSource = dtTransacciones.DefaultView;
            }
        }
    }
}