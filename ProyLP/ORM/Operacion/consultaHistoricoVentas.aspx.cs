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
    public partial class consultaHistoricoVentas : System.Web.UI.Page
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
                if (Session["participante_id"] != null && Session["pais"] != null)
                {
                    //imgCancelar.ImageUrl = ConfigurationManager.AppSettings["estilos"] + "/images/cancel.png";
                    ObtienePrograma(Session["participante_id"].ToString());
                    ObtieneDatosParticipante(Session["participante_id"].ToString());
                    ObtieneTransacciones(Session["participante_id"].ToString(),false);
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
            switch (countryCode.ToLower())
            {
                case "mx":
                    participante = new csParticipanteComplementoMX();
                    break;
            }

            participante.ID = participante_id;
            participante.DatosParticipante();
            lblNombreParticipante.Text = participante.NombreCompleto.ToUpper();
            lblClaveParticipante.Text = participante.Clave.ToUpper();
            saldo = participante.Saldo;
            if (saldo == "0")
                lblSaldo.Text = saldo;
            else
                lblSaldo.Text = Convert.ToInt32(saldo).ToString("N0");
        }

        protected void ObtieneTransacciones(string participante_id,bool Excel)
        {
            ObtienePrograma(participante_id);
            participante = new csParticipanteComplemento();
            participante.ID = participante_id;
            participante.OrigenID = "0";
            participante.DatosParticipante();
            DataTable dtTransacciones = new DataTable();
            dtTransacciones = participante.HistoricoVentas();
            if (!Excel)
            {
                lblRegistros.Text = dtTransacciones.Rows.Count + " transaccion(es) encontrada(s).";
                gvTransacciones.DataSource = dtTransacciones.DefaultView;
                gvTransacciones.DataBind();
            }
            else {
                gvExcel.DataSource = dtTransacciones.DefaultView;
                gvExcel.DataBind();
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
                    int puntos = Convert.ToInt32(drv.Row.ItemArray[7]);
                    if (puntos == 0)
                        e.Row.Cells[7].Text = "0";
                }
            }
        }

        protected void gvTransacciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTransacciones.PageIndex = e.NewPageIndex;
            ObtieneTransacciones(Session["participante_id"].ToString(),false);
        }

        protected void gvTransacciones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["transaccion_id"] = gvTransacciones.DataKeys[e.RowIndex].Values["id"].ToString();
           // ObtieneTransaccionDetalle(Session["transaccion_id"].ToString());
            //popDetalleTransaccion.Show();
        }

        protected void btnExcelr_Click(object sender, EventArgs e)
        {
            ObtieneTransacciones(Session["participante_id"].ToString(), true);
            GridViewExportUtil.Export("HistoricoVentas.xls", gvExcel);
        }


    }
}