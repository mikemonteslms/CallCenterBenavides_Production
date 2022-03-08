using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CNegocio;
using System.Data;
using Telerik.Web.UI;

namespace ORMOperacion.Reportes
{
    public partial class ReportePasivos : System.Web.UI.Page
    {
        private string nombreReporte = "reportepasivos";

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
                Master.Submenu = "Pasivos";
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


            //ucFiltros.RutaMenu = "Reportes >> Pasivos";
            ucFiltros.BotonExportar.Visible = false;

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
                    DataSet result = csReporteNegocio.EjecutarProcedimiento(ucFiltros.FechaInicial.ToString("dd/MM/yyyy"), ucFiltros.FechaFinal.ToString("dd/MM/yyyy"), int.Parse(ucFiltros.Combo1.SelectedValue), int.Parse(ucFiltros.Combo2.SelectedValue), int.Parse(ucFiltros.Combo3.SelectedValue), int.Parse(ucFiltros.Combo4.SelectedValue), nombreReporte, Membership.GetUser().ProviderUserKey.ToString());
                    gridResultado.DataSource = result;
                    GenerarGrafica(result.Tables[0]);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Llena el grid con los resultados que coincidan de acuerdo a los filtros seleccionados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ucFiltros_BuscarClicked(object sender, EventArgs e)
        {
            DataSet result = csReporteNegocio.EjecutarProcedimiento(ucFiltros.FechaInicial.ToString("dd/MM/yyyy"), ucFiltros.FechaFinal.ToString("dd/MM/yyyy"), int.Parse(ucFiltros.Combo1.SelectedValue), int.Parse(ucFiltros.Combo2.SelectedValue), int.Parse(ucFiltros.Combo3.SelectedValue), int.Parse(ucFiltros.Combo4.SelectedValue), nombreReporte, Membership.GetUser().ProviderUserKey.ToString());
            

            GenerarGrafica(result.Tables[0]);
            
        }

        private void GenerarGrafica(DataTable datos)
        {
            PlaceHolder1.Controls.Clear();

            //Por cada agrupado se debe de realizar una grafica
            var x = (from r in datos.AsEnumerable()
                     select r["tipo_saldo"]).Distinct().ToList();



            foreach (string valor in x)
            {
                PieSeries chartData = new PieSeries();
                RadHtmlChart grafico = new RadHtmlChart();
               grafico.Width = Unit.Pixel(320);
                grafico.Height = Unit.Pixel(350);
                grafico.Transitions = true;
                grafico.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Bottom;           
                grafico.ChartTitle.Text = valor;
                grafico.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center;
                grafico.Skin = "Web20";
                chartData.StartAngle = 90;
                chartData.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.Center;
                chartData.LabelsAppearance.DataFormatString = "{0}%";
                
                //Por cada agrupado se debe de realizar una grafica
                var y = (from r in datos.AsEnumerable()
                         where r["tipo_saldo"].ToString() == valor
                         select r).ToList();

                var total = y.AsEnumerable().Sum((b) => { return b.Field<int>("puntos"); });

                foreach (DataRow res in y)
                {                    
                            SeriesItem item1 = new SeriesItem();
                            item1.Name = res["categoria_transaccion"].ToString();
                            item1.YValue = decimal.Round((Convert.ToDecimal(res["puntos"].ToString()) / total) * 100, 2);                    
                            chartData.Items.Add(item1);
                       
                }

                grafico.PlotArea.Series.Add(chartData);

                PlaceHolder1.Controls.Add(grafico);
            }

            
        }

        protected void gridResultado_PreRender(object sender, EventArgs e)
        {
            double totalpuntos = 0;
            double totalimporte = 0;
           foreach (GridDataItem item in gridResultado.Items)
            {
                string value1 = "";
               //Buscar el valor correcto por cabecera
                foreach (GridItem item1 in gridResultado.MasterTableView.GetItems(GridItemType.GroupHeader))
                {
                    if (((Label)item1.FindControl("lblTipoSaldo")).Text == ((Label)item.FindControl("lblTSaldo")).Text)
                    {
                        value1 = ((Label)item1.FindControl("lblPuntos")).Text;
                    }
                }

              
                double footervalue2 = Convert.ToDouble(value1);//to get the value only.

                string qitem = item["puntos"].Text;
                double qitem1 = double.Parse(qitem);
                double per = (qitem1 / footervalue2)  * 100;
                string v2 = decimal.Round(Convert.ToDecimal(per),2) + "%";
                item["porcentaje"].Text = v2;

                
            }

           foreach (GridItem item1 in gridResultado.MasterTableView.GetItems(GridItemType.GroupHeader))
           {
               totalpuntos = totalpuntos == 0 ? double.Parse(((Label)item1.FindControl("lblPuntos")).Text) : totalpuntos - double.Parse(((Label)item1.FindControl("lblPuntos")).Text);
               totalimporte = totalimporte == 0 ? double.Parse(((Label)item1.FindControl("lblImporte")).Text.Replace("$", "")) : totalimporte - double.Parse(((Label)item1.FindControl("lblImporte")).Text.Replace("$", ""));
           }

           if (gridResultado.MasterTableView.GetItems(GridItemType.Footer).Length != 0)
           {
               GridFooterItem footer1 = (GridFooterItem)gridResultado.MasterTableView.GetItems(GridItemType.Footer)[0];
               footer1["puntos"].Text = string.Format("{0:N}", Convert.ToInt32(totalpuntos.ToString()));
               footer1["importe"].Text = string.Format("{0:C}", Convert.ToInt32(totalimporte.ToString()));
           }
        }

        protected void gridResultado_ItemDataBound(object sender, GridItemEventArgs e)
        {

           

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