using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using CallcenterNUevo.Herramientas;
using Microsoft.VisualBasic;
using Negocio;



namespace CallcenterNUevo.Herramientas
{
    public partial class ConsultaLogsAppBenavides : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (rdcTipoLog.Items.Count == 0)
            {
                CargaComboTipoLog();
            }
        }

        /// <summary>
        /// Author: RIGM
        /// Fecha Creación: 30/06/2017
        /// Descripción: Metodo que se encargara de cargar historico
        /// de logs
        /// </summary>
        private DataSet CargarLogs(int idlog)
        {
            DataSet dtsLog = new DataSet();
            try
            {
                dtsLog = HerramientasApp.ObtenerLogs("Sp_ConsultaLogs", idlog);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return dtsLog;
        }

        private DataSet CargaTipoLogs() {
            
            DataSet dtsLog = new DataSet();
            try
            {
                dtsLog = HerramientasApp.ObtenerTiposLogs("Sp_ObtenerTiposLogs");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return dtsLog;
        }

        protected void exportbutton_Click(object sender, EventArgs e)
        {

        }

        protected void btnCargaLogs_Click(object sender, EventArgs e)
        {
            string FechaInicio = "";
            string FechaFin = "";
            string de_las = "";
            string a_las = "";
            DataSet dsResultados = new DataSet();

            if (rdpFIni.SelectedDate == null && rdpFFin.SelectedDate == null && rdcDe.SelectedIndex == 0 && rdcAl.SelectedIndex == 0 && rdcTipoLog.SelectedIndex == 0)
            {
                CargaGridLogs();
            }
            else 
            {
                if (rdcDe.SelectedValue.ToString() == "0") { de_las = null; } else { de_las = rdcDe.SelectedValue.ToString(); }
                if (rdcAl.SelectedValue.ToString() == "0") { a_las = null; } else { a_las = rdcAl.SelectedValue.ToString(); }

                if (rdpFIni.SelectedDate != null) { FechaInicio = rdpFIni.SelectedDate.Value.Year.ToString() + rdpFIni.SelectedDate.Value.Month.ToString("00") + rdpFIni.SelectedDate.Value.Day.ToString("00") + " 00:00:00"; }
                if (rdpFFin.SelectedDate != null) { FechaFin = rdpFFin.SelectedDate.Value.Year.ToString() + rdpFFin.SelectedDate.Value.Month.ToString("00") + rdpFFin.SelectedDate.Value.Day.ToString("00") + " 23:59:59"; }
               

                if (String.IsNullOrWhiteSpace(FechaInicio) && String.IsNullOrWhiteSpace(FechaFin) && de_las == null && a_las == null)
                {
                    FechaInicio = null;
                    FechaFin = null;
                }
                else if (rdpFIni.SelectedDate == null && rdpFFin.SelectedDate == null && de_las == null && a_las == null)
                {
                    FechaInicio = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + " 00:00:00";
                    FechaFin = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + " 23:59:59";
                }
                else if (rdpFIni.SelectedDate == null && rdpFFin.SelectedDate == null && de_las != null && a_las != null)
                {
                    FechaInicio = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + " " + de_las + ":00";
                    FechaFin = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + " " + a_las.Replace("00","59").ToString() + ":59";
                    de_las = null;
                    a_las = null;
                }
                else if (rdpFIni.SelectedDate != null && rdpFFin.SelectedDate != null && de_las != null && a_las != null )
                {
                    FechaInicio = rdpFIni.SelectedDate.Value.Year.ToString() + rdpFIni.SelectedDate.Value.Month.ToString("00") + rdpFIni.SelectedDate.Value.Day.ToString("00") + " " + de_las + ":00";
                    FechaFin = rdpFFin.SelectedDate.Value.Year.ToString() + rdpFFin.SelectedDate.Value.Month.ToString("00") + rdpFFin.SelectedDate.Value.Day.ToString("00") + " " + a_las.Replace("00", "59").ToString() + ":59";
                    de_las = null;
                    a_las = null;
                }

                dsResultados = ConsultaLogs(FechaInicio, FechaFin, de_las, a_las, rdcTipoLog.Text);
                if (dsResultados != null)
                {
                    if (dsResultados.Tables.Count > 0)
                    {
                        gvResultadosLogs.DataSource = dsResultados.Tables[0];
                        gvResultadosLogs.DataBind();
                    }
                }

            }
            
        }

        protected void gvResultadosLogs_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            Datapager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        }

        protected void rdcDe_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void rdcAl_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void rdcTipoLog_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void rdpFIni_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {

        }

        protected void rdpFFin_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {

        }

        private void CargaGridLogs(){
            DataSet dsLogs = new DataSet();
            DataSet dsTiposLogs = new DataSet();
            dsLogs = CargarLogs(0);
            if (dsLogs != null)
            {
                if (dsLogs.Tables.Count > 0)
                {
                    gvResultadosLogs.DataSource = dsLogs.Tables[0];
                    gvResultadosLogs.DataBind();
                }
            }
        }

        private void CargaComboTipoLog()
        {
            DataSet dsTipoLogs = new DataSet();
            dsTipoLogs = CargaTipoLogs();
            if (dsTipoLogs != null)
            {
                if (dsTipoLogs.Tables.Count > 0)
                {
                    rdcTipoLog.DataSource = dsTipoLogs;
                    rdcTipoLog.DataTextField = "TipoLog";
                    rdcTipoLog.DataValueField = "IdTipoLog";
                    rdcTipoLog.DataBind();
                }
            }


            

        }

        private DataSet ConsultaLogs(string FIni,string FFin, string Delas, string Alas, string TipoLog) 
        {
            DataSet dsResultados = new DataSet();
            try
            {
                dsResultados = HerramientasApp.ObtenerLogsFill("Sp_ConsultaLogsPrm",FIni,FFin,Delas,Alas,TipoLog);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dsResultados;
        }

        protected void gvResultadosLogs_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            DataSet ds = new DataSet();
            string index = null;
            index = e.CommandArgument.ToString();

            switch (e.CommandName)
            {
                case "Verdetalle":
                    ds = CargarLogs(Convert.ToInt32(index));
                    if (!string.IsNullOrWhiteSpace(ds.Tables[0].Rows[0].ItemArray[0].ToString()))
                    {
                        txtDetalle.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString().Trim();
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ctrlMensajes", "alert('No existen detalles que mostrar..." + "');", true);
                    }
                    break;
            }
        }
    }
}