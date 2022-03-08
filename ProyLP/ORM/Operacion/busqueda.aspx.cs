using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using Telerik.Web.UI;

namespace ORMOperacion
{
    public partial class busqueda : System.Web.UI.Page
    {
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
            }
        }

        public DataTable GetDataTable()
        {
            string buscar = Request.QueryString.Get("buscar");
            DataTable dtBuscar = new DataTable();
            if (buscar != null)
            {
                MembershipUser u = Membership.GetUser();
                csParticipanteComplemento participante = new csParticipanteComplemento();
                dtBuscar = participante.BuscaParticipantesGeneral(buscar, u.ProviderUserKey.ToString());//(txtBuscar.Text);
            }
            return dtBuscar;
        }

        protected void radBusqueda_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            (sender as Telerik.Web.UI.RadGrid).DataSource = GetDataTable();
        }

        protected void radBusqueda_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)// to access a row 
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    bool bloqueado = Convert.ToBoolean(item.GetDataKeyValue("islockedout"));
                    string status = item.GetDataKeyValue("status_participante").ToString().ToUpper();
                    if (bloqueado == true && status != "BAJA")
                    {
                        item.Cells[8].Text = "INACTIVO";
                    }
                }
            }
            catch
            {

            }
        } 
        protected void lnkSeleccionar_Command(object sender, CommandEventArgs e)
        {
            string participante_id = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "seleccionar":
                    Session.Remove("carrito");
                    csParticipanteComplemento p = new csParticipanteComplemento();
                    p.ID = participante_id;
                    p.DatosParticipante();
                    Session["participante_id"] = participante_id;
                    Session["participante"] = p;
                    Boolean bllamada = false;
                    csLlamada llamada = new csLlamada();
                    llamada.IDParticipante = participante_id;
                    DataTable dtLlamada = llamada.SeguimientoLlamadas();
                    if (dtLlamada.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtLlamada.Rows.Count; i++)
                        {
                            DataRow drLlamada = dtLlamada.Rows[i];
                            if (drLlamada["clave_status_seguimiento"].ToString() != "C") // Hay llamadas pendientes
                            {
                                bllamada = true;
                                break;
                            }
                        }
                    }
                    if (bllamada == true)
                    {
                        Master.MuestraMensaje("Este participante tiene casos de llamadas pendientes");
                        Master.AgregaEvento("location.href='SeguimientoLlamadas.aspx'");
                    }
                    else
                    {
                        Response.Redirect("mantenimientoDatosGeneralesParticipantes.aspx");
                    }
                    break;
            }
        }
    }
}