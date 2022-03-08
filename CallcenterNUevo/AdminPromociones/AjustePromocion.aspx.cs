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
    public partial class AjustePromocion : System.Web.UI.Page
    {
        public static string CnnPruebas = "ConnectionStringTest";
        public static string CnnProductivo = "ConnectionStringProd";

        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    ModBitacoraAdminPromocion campos = new ModBitacoraAdminPromocion();
            //    AdministraPromocion Ejecuta = new AdministraPromocion();

            //    campos.IdMecanica = 0;
            //    campos.Usuario = HttpContext.Current.User.Identity.Name;
            //    campos.FechaHora = DateTime.Now;
            //    campos.Descripcion = "Acceso a Módulo: " + lblTitulo.Text;

            //    Ejecuta.RegistraBitacoraAdminpromocion(CnnProductivo, campos);
            //}

            txtCodInterno.Focus();
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DataSet DSResultados = new DataSet();
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCodInterno.Text))
                {
                    AdministraPromocion Ejecuta = new AdministraPromocion();
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.AjustePromocion", "btnBuscar_Click", "Inicio de Consulta", this.User.Identity.Name.ToString(), null);
                    DSResultados = Ejecuta.ObtenerPromociones(CnnProductivo, txtCodInterno.Text);
                    Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.AdminPromociones.AjustePromocion", "btnBuscar_Click", "Fin de Consulta", this.User.Identity.Name.ToString(), null);

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
                            }
                        }
                        else
                        {
                            Mensajes("No se encontrarón resultados.");
                        }
                    }
                    else
                    {
                        Mensajes("No se encontrarón resultados.");
                    }
                }
                else
                {
                    Mensajes("Proporcione un código interno es necesario.");
                    txtCodInterno.Focus();
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones", "btnBuscar_Click", "Ejecuta.ObtenerPromociones(" + txtCodInterno.Text + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error inesperasdo, contacte al administrador.");
            }
        }
        protected void grvDatos_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {

        }
        protected void grvDatos_SortCommand(object source, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            if (!e.Item.OwnerTableView.SortExpressions.ContainsExpression(e.SortExpression))
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Ascending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                //rbtnBuscarDI_Click(null, null);
            }
            else
            {
                GridSortExpression sortExpr = new GridSortExpression();
                sortExpr.FieldName = "Segmento";
                sortExpr.FieldName = e.SortExpression;
                sortExpr.SortOrder = GridSortOrder.Descending;
                e.Item.OwnerTableView.SortExpressions.AddSortExpression(sortExpr);
                //rbtnBuscarDI_Click(null, null);
            }
        }
        public void grvDatos_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            DataSet DSResultado = new DataSet();
            GridDataItem item;
            float IdMecanica = 0;
            IdMecanica = Convert.ToInt64(e.CommandArgument.ToString());

            switch (e.CommandName.ToString())
            {
                case "VerDetalle":

                    item = (GridDataItem)e.Item;

                    switch (item.Cells[7].Text)
                    {
                        case "1":
                            Response.Redirect("MuestraDatos.aspx?Idmec=" + IdMecanica + "&TipoAc=" + item.Cells[7].Text + "&Est=" + item.Cells[6].Text + "&amb=Prod");
                            break;

                        case "2":
                            Response.Redirect("MuestraDatosDEPorc.aspx?Idmec=" + IdMecanica + "&TipoAc=" + item.Cells[7].Text + "&Est=" + item.Cells[6].Text + "&EstPase=" + item.Cells[9].Text + "&amb=Prod");
                            break;
                        case "3":
                            Response.Redirect("MuestraDatosAcumulacionDinero.aspx?Idmec=" + IdMecanica + "&TipoAc=" + item.Cells[7].Text + "&Est=" + item.Cells[6].Text + "&EstPase=" + item.Cells[9].Text + "&amb=Prod");
                            break;
                    }
                    break;
                    case "Eliminar":
                    item = (GridDataItem)e.Item;

                    Session.Add("IdMecanica", IdMecanica);
                    Session.Add("TipoAcumulacion", item.Cells[7].Text);
                    Session.Add("CodigoInterno", item.Cells[4].Text);

                    mpeDelete.Show();
                    break;
            }
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            AdministraPromocion Ejecuta = new AdministraPromocion();
            bool blnRespuesta = false;

            try
            {

                int TipoAcumulacion = 0;
                TipoAcumulacion = Convert.ToInt32(Session["TipoAcumulacion"]);


                blnRespuesta = Ejecuta.EliminarPromocionAmbienteProd(CnnProductivo, Convert.ToInt64(Session["IdMecanica"].ToString()), Session["CodigoInterno"].ToString(), TipoAcumulacion, this.User.Identity.Name.ToString());
                if (blnRespuesta)
                {
                    Session.Contents.Remove("IdMecanica");
                    Session.Remove("IdMecanica");
                    Session.Contents.Remove("TipoAcumulacion");
                    Session.Remove("TipoAcumulacion");
                    Session.Contents.Remove("CodigoInterno");
                    Session.Remove("CodigoInterno");

                    Mensajes("La promoción fue eliminada correctamente.");
                    btnBuscar_Click(null, null);
                }
                else
                {
                    Session.Contents.Remove("IdMecanica");
                    Session.Remove("IdMecanica");
                    Session.Contents.Remove("TipoAcumulacion");
                    Session.Remove("TipoAcumulacion");
                    Session.Contents.Remove("CodigoInterno");
                    Session.Remove("CodigoInterno");

                    Mensajes("No fue posible eliminar la promoción.");
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.AjustePromocion", "btnSi_Click", "Ejecuta.EliminarPromocionAmbienteProd(" + Session["IdMecanica"].ToString() + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);

                Session.Contents.Remove("IdMecanica");
                Session.Remove("IdMecanica");
                Session.Contents.Remove("TipoAcumulacion");
                Session.Remove("TipoAcumulacion");
                Session.Contents.Remove("CodigoInterno");
                Session.Remove("CodigoInterno");

                Mensajes("Ocurrio un error al intentar eliminar la promoción, contacte al administrador.");
            }
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
    }
}