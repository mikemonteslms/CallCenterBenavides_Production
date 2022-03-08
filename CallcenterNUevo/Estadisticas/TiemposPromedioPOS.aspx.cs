using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using Datos;
using Negocio;
using Telerik.Web.UI;
using Telerik.Charting;
using Telerik.Web;
using Telerik.Web.UI.HtmlChart;
using Telerik.Web.UI.HtmlChart.Enums;
using System.Data;

namespace CallcenterNUevo.Estadisticas
{
    public partial class TiemposPromedioPOS : System.Web.UI.Page
    {
        string cnnDbase = "ConnectionStringProd";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaCombos();
                ProcesarDatos();
            }
        }
        protected void rdcAnio_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            List<ModAñosMeses> lstRespuesta = new List<ModAñosMeses>();
            EstadisticasCC Ejecutar = new EstadisticasCC();

            try
            {
                lstRespuesta = Ejecutar.ObtenerAñosMeses(cnnDbase, rdcAnio.Text);

                if (lstRespuesta != null)
                {
                    if (lstRespuesta.Count > 0)
                    {
                        rdcMes.Items.Clear();
                        rdcMes.DataSource = lstRespuesta;
                        rdcMes.DataTextField = "Mes";
                        rdcMes.DataValueField = "MesNum";
                        rdcMes.DataBind();
                        if (rdcAnio.Text == "Todos")
                        {
                            lblMeses.Visible = false;
                            rdcMes.Visible = false;
                        }
                        else
                        {
                            lblMeses.Visible = true;
                            rdcMes.Visible = true;
                        }
                        ProcesarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.Estadisticas.TiempoPromedioPOS", "rdcAnio_SelectedIndexChanged", "Ejecutar.ObtenerAñosMeses(" + cnnDbase + "," + rdcAnio.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al seleccionar el año, contacte al administrador.");
            }
        }
        protected void rdcMes_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ProcesarDatos();
        }


        private void CargaCombos()
        {
            List<ModAñosMeses> lstRespuesta = new List<ModAñosMeses>();
            EstadisticasCC Ejecutar = new EstadisticasCC();

            try
            {
                lstRespuesta = Ejecutar.ObtenerAñosMeses(cnnDbase, "");

                if (lstRespuesta != null)
                {
                    if (lstRespuesta.Count > 0)
                    {
                        rdcAnio.Items.Clear();
                        rdcAnio.DataSource = lstRespuesta;
                        rdcAnio.DataTextField = "Año";
                        rdcAnio.DataValueField = "AniosNum";
                        rdcAnio.DataBind();

                        rdcAnio.SelectedValue = "0";
                        rdcMes.SelectedValue = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.Estadisticas.TiempoPromedioPOS", "CargaCombos", "ejecutar.ObtenerTiemposPromedioPOS(" + cnnDbase + ",'')", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar los años, contacte al administrador.");
            }

        }
        private void ProcesarDatos()
        {
            try
            {
                ModContenedorEstadisticas contenedor = new ModContenedorEstadisticas();
                EstadisticasCC ejecutar = new EstadisticasCC();

                contenedor = ejecutar.ObtenerTiemposPromedioPOS(cnnDbase, rdcAnio.Text, rdcMes.SelectedValue);
                if (contenedor.lstMetodos.Count == 0)
                {
                    LimpiarGrafica();
                    Mensajes("No se encontrarón resultados.");
                }
                else
                {
                    LimpiarGrafica();
                    ConstruyeGraficaLineal(contenedor);
                }
                //ConstruyeGraficaLineal2(contenedor);
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.Estadisticas.TiempoPromedioPOS", "ProcesarDatos", "ejecutar.ObtenerTiemposPromedioPOS(" + cnnDbase + "," + rdcAnio.Text + "," + rdcMes.SelectedValue + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                LimpiarGrafica();
                Mensajes("Ocurrio un error al intentar procesar los datos, contacte al administrador.");
            }
        }
        private void ConstruyeGraficaLineal(ModContenedorEstadisticas contenedor)
        {
            try
            {
                //Valores X
                grpTiemposPromedio.PlotArea.XAxis.AxisCrossingValue = 0;
                grpTiemposPromedio.PlotArea.XAxis.Color = System.Drawing.Color.White;
                grpTiemposPromedio.PlotArea.XAxis.MajorTickType = TickType.Outside;
                grpTiemposPromedio.PlotArea.XAxis.MinorTickType = TickType.Outside;
                grpTiemposPromedio.PlotArea.XAxis.MajorGridLines.Visible = false;
                grpTiemposPromedio.PlotArea.XAxis.MinorGridLines.Visible = false;
                grpTiemposPromedio.PlotArea.XAxis.Reversed = false;
                grpTiemposPromedio.PlotArea.XAxis.TitleAppearance.Text = "Días";
                grpTiemposPromedio.PlotArea.XAxis.TitleAppearance.Visible = true;


                //Cargara los dias  en eje  XAxis.items
                foreach (ModDiasX campos in contenedor.lstDias)
                {
                    AxisItem itm = new AxisItem();

                    itm.LabelText = campos.Fecha.ToShortDateString();
                    if (contenedor.lstDias.Count > 31)
                    {
                        grpTiemposPromedio.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = System.Web.UI.WebControls.Unit.Point(6);
                        grpTiemposPromedio.PlotArea.XAxis.LabelsAppearance.TextStyle.Color = System.Drawing.Color.White;
                        grpTiemposPromedio.PlotArea.XAxis.LabelsAppearance.RotationAngle = 90;
                    }
                    else
                    {
                        grpTiemposPromedio.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = System.Web.UI.WebControls.Unit.Point(8);
                        grpTiemposPromedio.PlotArea.XAxis.LabelsAppearance.TextStyle.Color = System.Drawing.Color.White;
                        grpTiemposPromedio.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                    }

                    grpTiemposPromedio.PlotArea.XAxis.Items.Add(itm);
                }

                grpTiemposPromedio.PlotArea.YAxis.AxisCrossingValue = 0;
                grpTiemposPromedio.PlotArea.YAxis.Color = System.Drawing.Color.White;
                grpTiemposPromedio.PlotArea.YAxis.MajorTickSize = 1;
                grpTiemposPromedio.PlotArea.YAxis.MajorTickType = TickType.Outside;
                grpTiemposPromedio.PlotArea.YAxis.MaxValue = contenedor.YAxisMaxValue;
                grpTiemposPromedio.PlotArea.YAxis.MinorTickSize = 1;
                grpTiemposPromedio.PlotArea.YAxis.MinorTickType = TickType.Outside;
                grpTiemposPromedio.PlotArea.YAxis.MinValue = 0;
                grpTiemposPromedio.PlotArea.YAxis.MajorGridLines.Visible = false;
                grpTiemposPromedio.PlotArea.YAxis.MinorGridLines.Visible = false;
                grpTiemposPromedio.PlotArea.YAxis.Reversed = false;
                // grpTiemposPromedio.PlotArea.YAxis.Step = 25;


                grpTiemposPromedio.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0}";
                grpTiemposPromedio.PlotArea.YAxis.LabelsAppearance.RotationAngle = 0;
                //grpTiemposPromedio.PlotArea.YAxis.LabelsAppearance.Skip = 0;
                //grpTiemposPromedio.PlotArea.YAxis.LabelsAppearance.Step = 0;

                grpTiemposPromedio.PlotArea.YAxis.TitleAppearance.Position = AxisTitlePosition.Center;
                grpTiemposPromedio.PlotArea.YAxis.TitleAppearance.RotationAngle = 0;
                grpTiemposPromedio.PlotArea.YAxis.TitleAppearance.Text = "Tiempos Promedio";
                grpTiemposPromedio.PlotArea.YAxis.TitleAppearance.Visible = true;

                // set the plot area gradient background fill
                grpTiemposPromedio.PlotArea.Appearance.FillStyle.BackgroundColor = System.Drawing.Color.Black;
                grpTiemposPromedio.Legend.Appearance.TextStyle.Color = System.Drawing.Color.White;

                //Construcción de la grafica
                foreach (ModMetodos campos in contenedor.lstMetodos)
                {
                    LineSeries ln = new LineSeries();
                    ln.Name = campos.Metodo;

                    List<ModTiemposPromedioPOS> lstTiempoProm = new List<ModTiemposPromedioPOS>();
                    lstTiempoProm = contenedor.lstTiempoPromedio.Where(w => w.Metodo == campos.Metodo).ToList();

                    foreach (ModTiemposPromedioPOS camptp in lstTiempoProm)
                    {
                        // Agrega CategorySeriesItem
                        int point = camptp.TiempoPromedio;
                        CategorySeriesItem catSeriesitm = new CategorySeriesItem();
                        catSeriesitm.Y = point;

                        // Agrega a seriesitms las CategorySeriesItem
                        ln.SeriesItems.Add(catSeriesitm);
                    }
                    //Estilo de lineas
                    ln = AplicaFormatoLineSeries(ln, campos.Metodo);
                    grpTiemposPromedio.PlotArea.Series.Add(ln);
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.Estadisticas.TiempoPromedioPOS", "ConstruyeGraficaLineal", "al construir la grafica provoca un error)", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar construir la grafica, contacte al administrador.");
            }
        }
        private LineSeries AplicaFormatoLineSeries(LineSeries ln, string Metodos)
        {
            try
            {

                //Estilo de lineas
                switch (Metodos)
                {
                    case "ActivarTarjeta":
                        ln.Appearance.FillStyle.BackgroundColor = System.Drawing.Color.Green;
                        ln.LabelsAppearance.DataFormatString = "{0}";
                        ln.LabelsAppearance.Position = LineAndScatterLabelsPosition.Above;
                        ln.LabelsAppearance.Visible = false;
                        ln.LineAppearance.Width = 1;
                        //ln.MarkersAppearance.MarkersType = Telerik.Web.UI.HtmlChart.MarkersType.Triangle;
                        ln.MarkersAppearance.BackgroundColor = System.Drawing.Color.Black;
                        ln.MarkersAppearance.Size = 1;
                        ln.MarkersAppearance.BorderColor = System.Drawing.Color.Green;
                        ln.MarkersAppearance.BorderWidth = 1;
                        ln.TooltipsAppearance.Color = System.Drawing.Color.White;
                        break;
                    case "CerrarCompra":
                        ln.Appearance.FillStyle.BackgroundColor = System.Drawing.Color.Red;
                        ln.LabelsAppearance.DataFormatString = "{0}";
                        ln.LabelsAppearance.Position = LineAndScatterLabelsPosition.Above;
                        ln.LabelsAppearance.Visible = false;
                        ln.LineAppearance.Width = 1;
                        //ln.MarkersAppearance.MarkersType = Telerik.Web.UI.HtmlChart.MarkersType.Triangle;
                        ln.MarkersAppearance.BackgroundColor = System.Drawing.Color.Black;
                        ln.MarkersAppearance.Size = 1;
                        ln.MarkersAppearance.BorderColor = System.Drawing.Color.Red;
                        ln.MarkersAppearance.BorderWidth = 1;
                        ln.TooltipsAppearance.Color = System.Drawing.Color.White;
                        break;
                    case "ProcesarCompra":
                        ln.Appearance.FillStyle.BackgroundColor = System.Drawing.Color.Brown;
                        ln.LabelsAppearance.DataFormatString = "{0}";
                        ln.LabelsAppearance.Position = LineAndScatterLabelsPosition.Above;
                        ln.LabelsAppearance.Visible = false;
                        ln.LineAppearance.Width = 1;
                        //ln.MarkersAppearance.MarkersType = Telerik.Web.UI.HtmlChart.MarkersType.Triangle;
                        ln.MarkersAppearance.BackgroundColor = System.Drawing.Color.Black;
                        ln.MarkersAppearance.Size = 1;
                        ln.MarkersAppearance.BorderColor = System.Drawing.Color.Brown;
                        ln.MarkersAppearance.BorderWidth = 1;
                        ln.TooltipsAppearance.Color = System.Drawing.Color.White;
                        break;
                    case "ValidaTarjeta":
                        ln.Appearance.FillStyle.BackgroundColor = System.Drawing.Color.Yellow;
                        ln.LabelsAppearance.DataFormatString = "{0}";
                        ln.LabelsAppearance.Position = LineAndScatterLabelsPosition.Above;
                        ln.LabelsAppearance.Visible = false;
                        ln.LineAppearance.Width = 1;
                        //ln.MarkersAppearance.MarkersType = Telerik.Web.UI.HtmlChart.MarkersType.Triangle;
                        ln.MarkersAppearance.BackgroundColor = System.Drawing.Color.Black;
                        ln.MarkersAppearance.Size = 1;
                        ln.MarkersAppearance.BorderColor = System.Drawing.Color.Yellow;
                        ln.MarkersAppearance.BorderWidth = 1;
                        ln.TooltipsAppearance.Color = System.Drawing.Color.Black;
                        break;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.Estadisticas.TiempoPromedioPOS", "AplicaFormatoLineSeries", "Al intentar asignar fomato a las lineas de la grafica provoca un error)", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar asignar formato a lineas del grafico, contacte al administrador.");
            }
            return ln;
        }
        private void LimpiarGrafica()
        {
            grpTiemposPromedio.PlotArea.Series.Clear();
            grpTiemposPromedio.PlotArea.XAxis.Items.Clear();
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }


        private void ConstruyeGraficaLineal2(ModContenedorEstadisticas contenedor)
        {
            List<ModTiemposPromedioPOS> lsttiempoProm = new List<ModTiemposPromedioPOS>();
            int contar = 0;
            RadChart radChart = new RadChart();
            // Define chart and titleRadChart radChart = new RadChart();
            radChart.ChartTitle.TextBlock.Text = "Tiempos Promedio POS";
            radChart.ChartTitle.TextBlock.Appearance.Position.AlignedPosition = Telerik.Charting.Styles.AlignedPositions.Center;
            radChart.ChartTitle.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.DarkBlue;
            radChart.Height = 600;
            radChart.Width = 1000;

            // set the plot area gradient background fill
            radChart.PlotArea.Appearance.FillStyle.FillType = Telerik.Charting.Styles.FillType.Gradient;
            radChart.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.White;
            radChart.PlotArea.Appearance.FillStyle.SecondColor = System.Drawing.Color.White; // set the plot area gradient background fill

            // Set text and line for X axis
            radChart.PlotArea.XAxis.AxisLabel.TextBlock.Text = "Fechas";
            radChart.PlotArea.XAxis.AxisLabel.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.Red;
            radChart.PlotArea.XAxis.Appearance.Width = 3;
            radChart.PlotArea.XAxis.Appearance.Color = System.Drawing.Color.Red;
            radChart.PlotArea.XAxis.AxisLabel.Visible = true;


            // Set text and line for Y axis
            radChart.PlotArea.YAxis.AxisLabel.TextBlock.Text = "Tiempo Promedio";
            radChart.PlotArea.YAxis.AxisLabel.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.Red;
            radChart.PlotArea.YAxis.Appearance.Width = 3;
            radChart.PlotArea.YAxis.Appearance.Color = System.Drawing.Color.Red;
            radChart.PlotArea.YAxis.AxisLabel.Visible = true;


            radChart.PlotArea.XAxis.Items.Clear();
            string[] arrXSeries = new string[contenedor.lstDias.Count];
            string strCadena = "";

            foreach (ModDiasX campdias in contenedor.lstDias)
            {
                ChartAxisItem itms = new ChartAxisItem();
                AxisLabel lbl = new AxisLabel();

                lbl.TextBlock.Text = campdias.Fecha.ToShortDateString();

                itms.Add(lbl);

                radChart.PlotArea.XAxis.Items.Add(itms);
            }


            //Metodos a graficar
            foreach (ModMetodos campos in contenedor.lstMetodos)
            {
                List<ModTiemposPromedioPOS> lstTiempoProm = new List<ModTiemposPromedioPOS>();
                // Define chart series construccion de la leyenda
                ChartSeries chartSeries = new ChartSeries();

                chartSeries.Appearance.LabelAppearance.Visible = false;
                chartSeries.Name = campos.Metodo;
                chartSeries.Type = ChartSeriesType.Line;


                lstTiempoProm = contenedor.lstTiempoPromedio.Where(w => w.Metodo == campos.Metodo).ToList();
                foreach (ModTiemposPromedioPOS camptp in lstTiempoProm)
                {
                    // visually enhance the datapoints
                    int point = camptp.TiempoPromedio;

                    switch (campos.Metodo)
                    {
                        case "ActivarTarjeta":
                            chartSeries.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Green;
                            chartSeries.AddItem(point);
                            chartSeries.Appearance.PointMark.Dimensions.AutoSize = false;
                            chartSeries.Appearance.PointMark.Dimensions.Width = 8;
                            chartSeries.Appearance.PointMark.Dimensions.Height = 8;
                            chartSeries.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Green;
                            chartSeries.Appearance.PointMark.Visible = true;
                            break;
                        case "CerrarCompra":
                            chartSeries.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Red;
                            chartSeries.AddItem(point);
                            chartSeries.Appearance.PointMark.Dimensions.AutoSize = false;
                            chartSeries.Appearance.PointMark.Dimensions.Width = 8;
                            chartSeries.Appearance.PointMark.Dimensions.Height = 8;
                            chartSeries.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Red;
                            chartSeries.Appearance.PointMark.Visible = true;
                            break;
                        case "ProcesarCompra":
                            chartSeries.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Brown;
                            chartSeries.AddItem(point);
                            chartSeries.Appearance.PointMark.Dimensions.AutoSize = false;
                            chartSeries.Appearance.PointMark.Dimensions.Width = 8;
                            chartSeries.Appearance.PointMark.Dimensions.Height = 8;
                            chartSeries.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Brown;
                            chartSeries.Appearance.PointMark.Visible = true;
                            break;
                        case "ValidaTarjeta":
                            chartSeries.Appearance.LineSeriesAppearance.Color = System.Drawing.Color.Yellow;
                            chartSeries.AddItem(point);
                            chartSeries.Appearance.PointMark.Dimensions.AutoSize = false;
                            chartSeries.Appearance.PointMark.Dimensions.Width = 8;
                            chartSeries.Appearance.PointMark.Dimensions.Height = 8;
                            chartSeries.Appearance.PointMark.FillStyle.MainColor = System.Drawing.Color.Yellow;
                            chartSeries.Appearance.PointMark.Visible = true;
                            break;
                    }
                }
                contar += 1;
                radChart.Series.Add(chartSeries);
            }
            this.Master.Page.Controls.Add(radChart);
        }
    }
}