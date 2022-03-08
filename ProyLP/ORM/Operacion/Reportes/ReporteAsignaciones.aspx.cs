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
    public partial class ReporteAsignaciones : System.Web.UI.Page
    {

        private string nombreReporte = "reporteasignaciones";

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
                //Llenar combos para filtrar el grid
                Master.Menu = "Reportes";
                Master.Submenu = "Asignaciones";
                Configuracion_Filtros();               
            }
        }

        /// <summary>
        /// Establecer que campos son los que se van a utilizar como filtros
        /// </summary>
        private void Configuracion_Filtros()
        {
            rdpFecha.SelectedDate = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);


            rcbPrograma.DataTextField = "Descripcion";
            rcbPrograma.DataValueField = "Id";

            Telerik.OpenAccess.Web.OpenAccessLinqDataSource ds = new Telerik.OpenAccess.Web.OpenAccessLinqDataSource();
            ds.ContextTypeName = "EntitiesModel.EntitiesModel";
            ds.ResourceSetName = "programas";
            ds.Where = "usuario_baja_id == null";
            ds.EntityTypeName = "";
            ds.ID = "OAprogramas";

            rcbPrograma.DataSource = ds;
            rcbPrograma.DataBind();
            rcbPrograma.SelectedIndex = 0;
            
          
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
                if (IsPostBack)
                {
                    gridResultado.DataSource = csReporteNegocio.EjecutarProcedimientoAsignaciones(Convert.ToDateTime(rdpFecha.SelectedDate).ToString("yyyyMM"), int.Parse(rcbPrograma.SelectedValue), int.Parse(rblTipoReporte.SelectedValue), nombreReporte); // Membership.GetUser().ProviderUserKey.ToString()
                    gridResultado.ShowGroupPanel = true;
                }
            }
            catch
            { 
            }
           

        }

       
        protected void gridResultado_ExcelExportCellFormatting(object sender, ExcelExportCellFormattingEventArgs e)
        {
            if (e.FormattedColumn.UniqueName == "clave")
            {
                e.Cell.Style["mso-number-format"] = @"\@";
            }
        }

        /// <summary>
        /// Llena el grid con los resultados que coincidan de acuerdo a los filtros seleccionados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnBuscar_Click(object sender, EventArgs e)
        {
            gridResultado.DataBind();
        }


        /// <summary>
        /// Exporta a excel los resultados que se están visualizando en el grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnExportar_Click(object sender, EventArgs e)
        {
            csReporteNegocio.FormatearExcel(gridResultado);
            gridResultado.MasterTableView.ExportToExcel();
        }

      
    }
}