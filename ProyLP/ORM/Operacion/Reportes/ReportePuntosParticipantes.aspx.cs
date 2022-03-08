using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using CNegocio;
using System.Web.Security;

namespace ORMOperacion.Reportes
{
    public partial class ReportePuntosParticipantes : System.Web.UI.Page
    {
        private string nombreReporte = "reportepuntosparticipantes";

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
                Master.Menu = "Reportes";
                Master.Submenu = "Puntos";
                //Llenar combos para filtrar el grid
                Configuracion_Filtros();               
            }
        }

        /// <summary>
        /// Establecer que campos son los que se van a utilizar como filtros
        /// </summary>
        private void Configuracion_Filtros()
        {
            MembershipUser u = Membership.GetUser(Context.User.Identity.Name);
            ucFiltros.FechaInicial = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            ucFiltros.FechaFinal = DateTime.Now;

            ucFiltros.ConfigurarCombo(ucFiltros.Combo1, "Descripcion", "Id", "programas", "Listado1", "Programa: ", "table1", "", "", u.ProviderUserKey.ToString());
            ucFiltros.ConfigurarCombo(ucFiltros.Combo2, "Descripcion", "Id", "tipo_participantes", "Listado2", "Tipo Participante: ", "table2", "", "programa_id = " + ucFiltros.Combo1.SelectedValue.ToString(), u.ProviderUserKey.ToString());
            ucFiltros.ConfigurarCombo(ucFiltros.Combo4, "Descripcion", "Id", "status_participantes", "Listado4", "Estatus: ", "table4", "", "programa_id = " + ucFiltros.Combo1.SelectedValue.ToString(), u.ProviderUserKey.ToString());
            ucFiltros.ConfigurarCombo(ucFiltros.Combo3, "Descripcion", "Id", "distribuidors", "Listado3", "Distribuidor: ", "table3", "", "programa_id = " + ucFiltros.Combo1.SelectedValue.ToString(), u.ProviderUserKey.ToString());



            //ucFiltros.RutaMenu = "Reportes >> Kilómetros";           
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="control">Nombre del combo a llenar</param>
        /// <param name="id">Valor que va a tomar el combobox</param>
        /// <param name="texto">Texto que va a tomar el combobox</param>
        /// <param name="tablaBD">Nombre de la entiedad a mapear con el OpenAccess</param>
        /// <param name="columna">Nombre de columna del grid donde está el combo</param>
        private void CargarComboFiltro(GridItem item, string control, string id, string texto, string tablaBD, string columna, string usuario)
        {
            RadComboBox combo = (RadComboBox)item.FindControl(control);
            combo = ucFiltros.CrearCombo(combo, id, texto, tablaBD, "", usuario);
            //Dejar seleccionado el valor que previamente se había seleccionado
            combo.SelectedIndex = combo.FindItemIndexByValue(gridResultado.MasterTableView.GetColumn(columna).CurrentFilterValue);
        }
       
        /// <summary>
        /// Llena el grid con los resultados que coincidan de acuerdo a los filtros seleccionados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ucFiltros_BuscarClicked(object sender, EventArgs e) 
        {
         //   gridResultado.DataSource = csReporteNegocio.EjecutarProcedimiento(ucFiltros.FechaInicial.ToString("dd/MM/yyyy"), ucFiltros.FechaFinal.ToString("dd/MM/yyyy"), int.Parse(ucFiltros.Combo1.SelectedValue), int.Parse(ucFiltros.Combo2.SelectedValue), int.Parse(ucFiltros.Combo3.SelectedValue), int.Parse(ucFiltros.Combo4.SelectedValue), nombreReporte, Membership.GetUser().ProviderUserKey.ToString());
         //   gridResultado.DataBind();
        }

        /// <summary>
        /// Exporta a excel los resultados que se están visualizando en el grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ucFiltros_ExportarClicked(object sender, EventArgs e)
        {
            
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(ucFiltros.BotonExportar);
           csReporteNegocio.FormatearExcel(gridResultado);
            gridResultado.MasterTableView.ExportToExcel();
        }

        /// <summary>
        /// Evento para bindear el grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridResultado_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                if ((IsPostBack) && (!Page.Request.Params["__EVENTTARGET"].ToString().Contains("$rcbListado1")))
                {
                    gridResultado.DataSource = csReporteNegocio.EjecutarProcedimiento(ucFiltros.FechaInicial.ToString("dd/MM/yyyy"), ucFiltros.FechaFinal.ToString("dd/MM/yyyy"), int.Parse(ucFiltros.Combo1.SelectedValue), int.Parse(ucFiltros.Combo2.SelectedValue), int.Parse(ucFiltros.Combo3.SelectedValue), int.Parse(ucFiltros.Combo4.SelectedValue), nombreReporte, Membership.GetUser().ProviderUserKey.ToString());
                    gridResultado.ShowGroupPanel = true;
                }
            }
            catch
            { 
            }
           

        }


        protected void gridResultado_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.ExportToExcelCommandName)
            {
               
                //Establecer el estilo del grid
                csReporteNegocio.FormatearExcel(gridResultado);
            }
        }

        protected void gridResultado_ExcelExportCellFormatting(object sender, ExcelExportCellFormattingEventArgs e)
        {
            if (e.FormattedColumn.UniqueName == "clave")
            {
                e.Cell.Style["mso-number-format"] = @"\@";
            }
        }

        protected void ucFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            MembershipUser u = Membership.GetUser(Context.User.Identity.Name);

            ucFiltros.ConfigurarCombo(ucFiltros.Combo2, "Descripcion", "Id", "tipo_participantes", "Listado2", "Tipo Participante: ", "table2", "", "programa_id = " + ucFiltros.Combo1.SelectedValue.ToString(), u.ProviderUserKey.ToString());
            ucFiltros.ConfigurarCombo(ucFiltros.Combo4, "Descripcion", "Id", "status_participantes", "Listado4", "Estatus: ", "table4", "", "programa_id = " + ucFiltros.Combo1.SelectedValue.ToString(), u.ProviderUserKey.ToString());
            ucFiltros.ConfigurarCombo(ucFiltros.Combo3, "Descripcion", "Id", "distribuidors", "Listado3", "Distribuidor: ", "table3", "", "programa_id = " + ucFiltros.Combo1.SelectedValue.ToString(), u.ProviderUserKey.ToString());
        }

    }
}