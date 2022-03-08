using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using xi = Telerik.Web.UI.ExportInfrastructure;
using Telerik.Web.UI.GridExcelBuilder;
using System.Data;
using Negocio;
using Datos;


namespace CallcenterNUevo.AdminPromociones
{
    public partial class ConsultaPromACDineroEntregaPzas : System.Web.UI.Page
    {
        public static string CnnPruebas = "ConnectionStringTest";
        public static string CnnProductivo = "ConnectionStringProd";
        public float IdMecanica = 0;
        public int TipoAcum = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DataSet DSResultados = new DataSet();
            try
            {
                AdministraPromocion Ejecuta = new AdministraPromocion();
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.ConsultaPromPendxAutDesAut", "btnBuscar_Click", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
                DSResultados = Ejecuta.ObtenerPromACDineroEntregaPzas(CnnPruebas, txtCodInterno.Text);
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.ConsultaPromPendxAutDesAut", "btnBuscar_Click", "Fin de Consulta", this.User.Identity.Name.ToString(), null);

                if (DSResultados != null)
                {
                    if (DSResultados.Tables.Count > 0)
                    {
                        if (DSResultados.Tables[0].Rows.Count > 0)
                        {
                            grvDatos.DataSource = DSResultados.Tables[0];
                            grvDatos.DataBind();
                        }
                        else
                        {
                            Mensajes("No se encontrarón resultados.");
                            grvDatos.DataSource = null;
                            grvDatos.DataBind();
                        }
                    }
                    else
                    {
                        Mensajes("No se encontrarón resultados.");
                        grvDatos.DataSource = null;
                        grvDatos.DataBind();
                    }
                }
                else
                {
                    Mensajes("No se encontrarón resultados.");
                    grvDatos.DataSource = null;
                    grvDatos.DataBind();
                }
                //}
                //else
                //{
                //    Mensajes("Proporcione un código interno es necesario.");
                //    txtCodInterno.Focus();
                //}
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.ConsultaPromACDineroEntregaPzas", "btnBuscar_Click", "Ejecuta.ObtenerPromociones(" + txtCodInterno.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error inesperado, contacte al administrador.");
            }
        }
        protected void btnSi_Click(object sender, EventArgs e)
        {
            AdministraPromocion Ejecuta = new AdministraPromocion();
            bool blnRespuesta = false;
            int IdMecanica = 0;
            int TipoAcum = 0;
            try
            {
                IdMecanica = Convert.ToInt32(selIdMecanica.Value);
                TipoAcum = Convert.ToInt32(selTipoAcum.Value);

                blnRespuesta = Ejecuta.EliminarPromocion(CnnPruebas, IdMecanica, TipoAcum, HttpContext.Current.User.Identity.Name);
                if (blnRespuesta)
                {
                    Mensajes("La promoción fue eliminada correctamente.");
                    btnBuscar_Click(null, null);
                }
                else
                {
                    Mensajes("No fue posible eliminar la promoción.");
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.ConsultaPromACDineroEntregaPzas", "btnSi_Click", "Ejecuta.EliminarPromocion(" + CnnPruebas + " ," + IdMecanica + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error inesperado, contacte al administrador.");
            }
        }
        protected void grvDatos_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            DataSet DSResultado = new DataSet();
            GridDataItem item;


            bool result = float.TryParse(e.CommandArgument.ToString(), out IdMecanica);

            if (result)
            {
                IdMecanica = Convert.ToInt64(e.CommandArgument.ToString());


                switch (e.CommandName.ToString())
                {
                    case "VerDetalle":
                        item = (GridDataItem)e.Item;

                        switch (item.Cells[8].Text)
                        {
                            case "3":
                                Session["CodInt"] = txtCodInterno.Text;
                                Response.Redirect("MuestraDatosAutDesAutACDineroEntregaPzas.aspx?Idmec=" + IdMecanica + "&TipoAc=" + item.Cells[8].Text + "&Est=" + item.Cells[7].Text + "&EstPase=" + item.Cells[10].Text);
                                break;

                        }
                        break;
                    case "Eliminar":
                        item = (GridDataItem)e.Item;

                        tblEliminar.Visible = true;
                        rdpFechainicio.SelectedDate = null;
                        tblReasignaFechaInicio.Visible = false;
                        selIdMecanica.Value = IdMecanica.ToString();
                        selTipoAcum.Value = item.Cells[8].Text;
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                        break;
                }
            }
        }

        protected void grvDatos_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            btnBuscar_Click(null, null);
        }
        protected void grvDatos_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Mecánica";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                btnBuscar_Click(null, null);
            }
            else
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Mecánica";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Descending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                btnBuscar_Click(null, null);
            }
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void rdpFechainicio_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {


        }

        protected void btnGuardarFechaini_Click(object sender, EventArgs e)
        {
            bool blnResultado = false;
            string strFechaIni = "";

            if (ValidaFechaIni())
            {
                ModPromocionesDENoIniciadas campos = new ModPromocionesDENoIniciadas();
                AdministraPromocion Ejecuta = new AdministraPromocion();

                strFechaIni = rdpFechainicio.SelectedDate.ToString();
                strFechaIni = strFechaIni.Substring(0, 10) + " 00:00:00";
                campos.FechaInicio = strFechaIni;
                campos.Idmecanica = Convert.ToInt32(selIdMecanica.Value);

                blnResultado = Ejecuta.ModificaFechaInicio(CnnPruebas, campos);
                if (blnResultado)
                {
                    Mensajes("Se modifico la fecha inicio correctamente, ahora puede ver el detalle de la promoción.");
                    btnBuscar_Click(null, null);
                }
                else
                {
                    rdpFechainicio.SelectedDate = null;
                    Mensajes("No fue posible modificar la fecha inicio, contacte al administrador.");
                }
            }
            else
            {
                tblEliminar.Visible = false;
                tblReasignaFechaInicio.Visible = true;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
            }
        }

        private bool ValidaFechaIni()
        {
            bool blnRespuesta = true;

            if (rdpFechainicio.SelectedDate == null)
            {
                Mensajes("Proporcione una fecha.");
                rdpFechainicio.Focus();
                return false;
            }


            DateTime FechaIni;
            bool blnRespFecha = DateTime.TryParse(rdpFechainicio.SelectedDate.ToString(), out FechaIni);
            if (!blnRespFecha)
            {
                Mensajes("La fecha proporcionada es incorrecta.");
                rdpFechainicio.SelectedDate = null;
                rdpFechainicio.Focus();
                return false;
            }



            if (rdpFechainicio.SelectedDate <= DateTime.Now.Date)
            {
                Mensajes("La fecha inicio no puede ser menor ó igual a la fecha actual.");
                rdpFechainicio.SelectedDate = null;
                rdpFechainicio.Focus();
                return false;
            }

            return blnRespuesta;
        }
    }
}