using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;

namespace ORMOperacion
{
    public partial class CalendarioMundial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación autenticación de la página
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }

            if (!IsPostBack)
            {
                Master.Menu = "Campañas";
                Master.Submenu = "Quiniela";

                LlenarGrid();
            }
        }

        protected void CargaGrupo(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            csDataBase query = new csDataBase();
            query.Query = "SELECT DISTINCT grupo FROM grupo ORDER BY grupo";
            query.EsStoreProcedure = false;
            DropDownList ddlGrupo = e.Item.FindControl("ddlGrupo") as DropDownList;
            ddlGrupo.DataSource = query.dtConsulta();
            ddlGrupo.DataBind();
            ddlGrupo.Items.Insert(0, new ListItem("", ""));
        }

        protected void CargaHorario(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            csDataBase query = new csDataBase();
            query.Query = "SELECT DISTINCT horario FROM horario ORDER BY horario";
            query.EsStoreProcedure = false;
            DropDownList ddlHorario = e.Item.FindControl("ddlHorario") as DropDownList;
            ddlHorario.DataSource = query.dtConsulta();
            ddlHorario.DataBind();
            ddlHorario.Items.Insert(0, new ListItem("", ""));
        }

        protected void CargaLocal(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            csDataBase query = new csDataBase();
            query.Query = "SELECT DISTINCT pais as [local] FROM pais ORDER BY pais";
            query.EsStoreProcedure = false;
            DropDownList ddlLocal = e.Item.FindControl("ddlLocal") as DropDownList;
            ddlLocal.DataSource = query.dtConsulta();
            ddlLocal.DataBind();
            ddlLocal.Items.Insert(0, new ListItem("Seleccione", ""));
        }

        protected void CargaVisitante(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            csDataBase query = new csDataBase();
            query.Query = "SELECT DISTINCT pais as [visitante] FROM pais ORDER BY pais";
            query.EsStoreProcedure = false;
            DropDownList ddlVisitante = e.Item.FindControl("ddlVisitante") as DropDownList;
            ddlVisitante.DataSource = query.dtConsulta();
            ddlVisitante.DataBind();
            ddlVisitante.Items.Insert(0, new ListItem("Seleccione", ""));
        }

        protected void CargaSede(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            csDataBase query = new csDataBase();
            query.Query = "SELECT DISTINCT sede FROM sede ORDER BY sede";
            query.EsStoreProcedure = false;
            DropDownList ddlSede = e.Item.FindControl("ddlSede") as DropDownList;
            ddlSede.DataSource = query.dtConsulta();
            ddlSede.DataBind();
            ddlSede.Items.Insert(0, new ListItem("Seleccione", ""));
        }

        protected void LlenarGrid()
        {
            gridMarcadoresPartidos.DataSource = CNegocio.csQuiniela.ObtenerPartidosMarcador(0);
            gridMarcadoresPartidos.DataBind();
        }

        protected void lnkActualizar_Click(object sender, EventArgs e)
        {
            foreach (Telerik.Web.UI.GridItem item in gridMarcadoresPartidos.MasterTableView.Items)
            {
                if (((LinkButton)sender).CommandArgument.ToString() == item.OwnerTableView.DataKeyValues[item.ItemIndex]["id"].ToString())
                {
                    CNegocio.csQuiniela.ActualizaMarcador(item);
                    break;
                }
            }
        }

        protected void gridMarcadoresPartidos_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                CargaGrupo(sender, e);
                CargaHorario(sender, e);
                CargaLocal(sender, e);
                CargaVisitante(sender, e);
                CargaSede(sender, e);
            }
        }

        protected void lnkAgregar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                foreach (GridHeaderItem headerItem in gridMarcadoresPartidos.MasterTableView.GetItems(GridItemType.Header))
                {
                    DropDownList ddlGrupo = (DropDownList)headerItem["grupo"].Controls[3];
                    RadDatePicker rdpFecha = (RadDatePicker)headerItem["fecha"].Controls[3];
                    DropDownList ddlHorario = (DropDownList)headerItem["horario"].Controls[3];
                    DropDownList ddlLocal = (DropDownList)headerItem["local"].Controls[3];
                    DropDownList ddlVisitante = (DropDownList)headerItem["visitante"].Controls[3];
                    DropDownList ddlSede = (DropDownList)headerItem["sede"].Controls[3];
                    TextBox txtMarcadorLocal = (TextBox)headerItem["marcadorLocal"].Controls[3];
                    TextBox txtMarcadorVisitante = (TextBox)headerItem["marcadorVisitante"].Controls[3];
                    string grupo = ddlGrupo.SelectedItem.Value;
                    string fecha = rdpFecha.SelectedDate.Value.ToString().Trim().Substring(0, 10);
                    string horario = ddlHorario.SelectedItem.Value;
                    string local = ddlLocal.SelectedItem.Value;
                    string visitante = ddlVisitante.SelectedItem.Value;
                    string sede = ddlSede.SelectedItem.Value;
                    int marcador_local = Convert.ToInt32(txtMarcadorLocal.Text);
                    int marcador_visitante = Convert.ToInt32(txtMarcadorVisitante.Text);
                    CNegocio.csQuiniela.InsertaPartido(grupo, fecha, horario, local, visitante, sede, marcador_local, marcador_visitante);
                    LlenarGrid();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void gridMarcadoresPartidos_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            gridMarcadoresPartidos.DataSource = CNegocio.csQuiniela.ObtenerPartidosMarcador(0);
        }
    }
}