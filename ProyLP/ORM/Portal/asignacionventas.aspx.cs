using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class asignacionventas : System.Web.UI.Page
    {
        csParticipanteComplemento p = null;
        List<csParticipanteVentas> ListacsParticipanteVentas = null;
        csParticipanteVentas objCsParticipanteVentas = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["participante_id"] == null)
            {
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (Session["distribuidor_id"] == null)
            {
                Master.CargaDistribuidor();
                return;
            }
            if (!IsPostBack)
            {
                ViewState["vendedor_id"] = null;
                Master.GuardaAcceso("Asignacion");

                Metodo_Busqueda_Vendedores(Session["distribuidor_id"].ToString(), "");
                ConsultaVentasPorAsignar(int.Parse(Session["distribuidor_id"].ToString()));
                mvVendedores.SetActiveView(vListaVendedores);
            }
        }
        protected object ConsultaChasisesPendientes(int distribuidor_id)
        {
            csDistribuidor d = new csDistribuidor();
            DataTable dt = d.ConsultaChasisesPendientesPorAsignar(distribuidor_id);
            List<csParticipanteVentas> resultado = new List<csParticipanteVentas>();

            foreach (DataRow fila in dt.Rows)
            {
                csParticipanteVentas ventaPendiente = new csParticipanteVentas();
                ventaPendiente.Chasis = fila["Chasis"].ToString();
                ventaPendiente.Client = fila["Client"].ToString();
                ventaPendiente.DescripcionProducto = fila["tipo_auto"].ToString();
                ventaPendiente.FechaDeVenta = fila["Fecha_Venta"].ToString();
                ventaPendiente.numero_contrato = fila["numero_contrato"].ToString();

                resultado.Add(ventaPendiente);
            }

            return resultado;

        }
        protected void ConsultaVentasPorAsignar(int distribuidor_id)
        {
            csDistribuidor d = new csDistribuidor();
            lblVentasPorAsignar.Text = d.ConsultaVentasPendientesPorAsignar(distribuidor_id).ToString("N0");
        }
        protected void btnAgregarChasis_Click(object sender, EventArgs e)
        {
            try
            {
                p = new csParticipanteComplemento();
                DataTable objDatosChasis = new DataTable();
                objDatosChasis = p.BuscarDatosChasis(Session["distribuidor_id"].ToString(), txtNumeroChasis.Text);

                if (objDatosChasis != null)
                {
                    if (objDatosChasis.Rows.Count == 1)
                    {
                        if (objDatosChasis.Rows[0]["asignado"].ToString().Trim().Length == 0)
                        {
                            objCsParticipanteVentas = new csParticipanteVentas();
                            objCsParticipanteVentas.Participante_id = ViewState["vendedor_id"].ToString();
                            objCsParticipanteVentas.Chasis = objDatosChasis.Rows[0]["chasis"].ToString();
                            objCsParticipanteVentas.Client = objDatosChasis.Rows[0]["Client"].ToString();
                            objCsParticipanteVentas.DescripcionProducto = objDatosChasis.Rows[0]["tipo_auto"].ToString();
                            objCsParticipanteVentas.FechaDeVenta = objDatosChasis.Rows[0]["fecha_venta"].ToString();
                            objCsParticipanteVentas.numero_contrato = objDatosChasis.Rows[0]["numero_contrato"].ToString();


                            VentasAsignadas.Add(objCsParticipanteVentas);
                            VentasPendientesAsignar.Remove(GetVenta(VentasPendientesAsignar, objDatosChasis.Rows[0]["chasis"].ToString()));


                            grdVentasAsignadas.DataSource = VentasAsignadas;
                            grdVentasAsignadas.DataBind();
                            rgVentas.DataSource = VentasPendientesAsignar;
                            rgVentas.DataBind();
                            txtNumeroChasis.Text = "";
                        }
                        else
                        {
                            Master.MuestraMensaje("El número de Chasis ya fué asignado a: ." + objDatosChasis.Rows[0]["participante_asignado"].ToString().ToUpper());
                        }
                    }
                    else
                    {
                        VentasPendientesAsignar.Clear();
                        txtNumeroChasis.Text = "";
                        foreach(DataRow dr in objDatosChasis.Rows)
                        {
                            objCsParticipanteVentas = new csParticipanteVentas();
                            objCsParticipanteVentas.Participante_id = ViewState["vendedor_id"].ToString();
                            objCsParticipanteVentas.Chasis = dr["chasis"].ToString();
                            objCsParticipanteVentas.Client = dr["Client"].ToString();
                            objCsParticipanteVentas.DescripcionProducto = dr["tipo_auto"].ToString();
                            objCsParticipanteVentas.FechaDeVenta = dr["fecha_venta"].ToString();
                            objCsParticipanteVentas.numero_contrato = dr["numero_contrato"].ToString();
                            VentasPendientesAsignar.Add(objCsParticipanteVentas);
                        }
                        rgVentas.DataSource = VentasPendientesAsignar;
                        rgVentas.DataBind();
                    }
                }
                else
                {
                    Master.MuestraMensaje("No se encontraron datos relacionados al Numero de Chasis que ingresó. Favor de verificar.");
                }


            }
            catch { }
        }
        protected void btnBuscarVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["participante_id"] == null)
                {
                    Session.Abandon();
                    Session.Clear();
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                    return;
                }

                Metodo_Busqueda_Vendedores(Session["distribuidor_id"].ToString(), txtNombreVendedor.Text.Trim());
                txtNombreVendedor.Text = "";
                //gvVentas.DataSource = null;
                //gvVentas.DataBind();
            }
            catch { }
        }
        public void Metodo_Busqueda_Vendedores(string distribuidor_id, string strbusqueda)
        {
            try
            {
                p = new csParticipanteComplemento();
                lvAsesoreVentas.DataSource = p.BuscarVendedores(distribuidor_id, strbusqueda);
                lvAsesoreVentas.DataBind();

                mvVendedores.SetActiveView(vListaVendedores);
            }
            catch { }
        }
        protected void lvAsesoreVentas_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (Session["participante_id"] == null)
            {
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (e.CommandName == "seleccionar")
            {
                ListViewItem row = (ListViewItem)((Control)e.CommandSource).NamingContainer;
                int index = row.DisplayIndex;
                int participante_id = int.Parse(lvAsesoreVentas.DataKeys[index]["participante_id"].ToString());
                string cveVendedor = lvAsesoreVentas.DataKeys[index]["clave"].ToString();
                ViewState["vendedor_id"] = participante_id.ToString();
                lblNombreVendedor.Text = lvAsesoreVentas.DataKeys[index]["AsesorNombre"].ToString();
                //lblFecha.Text = gvAsesoreVentas.DataKeys[index]["fecha_alta"].ToString();
                //lblPuntos.Text = Convert.ToInt32(gvAsesoreVentas.DataKeys[index]["saldo"]).ToString("N0");
                lvAsesoreVentas.DataSource = null;

                /*Mostrar el grid con las ventas pendientes por asignar */
                VentasPendientesAsignar = (List<csParticipanteVentas>)ConsultaChasisesPendientes(Convert.ToInt32(Session["distribuidor_id"]));
                rgVentas.DataSource = VentasPendientesAsignar;
                rgVentas.DataBind();

                VentasAsignadas.Clear();
                grdVentasAsignadas.DataSource = VentasAsignadas;
                grdVentasAsignadas.DataBind();

                mvVendedores.SetActiveView(vSeleccionado);
            }

        }
        protected void lnkCancelarVentas_Click(object sender, EventArgs e)
        {
            /*Mostrar el grid con las ventas pendientes por asignar */
            VentasPendientesAsignar = (List<csParticipanteVentas>)ConsultaChasisesPendientes(Convert.ToInt32(Session["distribuidor_id"]));
            rgVentas.DataSource = VentasPendientesAsignar;
            rgVentas.DataBind();

            VentasAsignadas.Clear();
            grdVentasAsignadas.DataSource = VentasAsignadas;
            grdVentasAsignadas.DataBind();
        }
        protected void lnkAsignarVentas_Click(object sender, EventArgs e)
        {
            if (VentasAsignadas.Count == 0)
            {
                Master.MuestraMensaje("Debe agregar al menos un registro para asignar.");
                return;
            }
            try
            {
                p = new csParticipanteComplemento();

                int contador = 0;
                foreach (csParticipanteVentas fila in VentasAsignadas)
                {

                    p.insertar_ventas_participante(ViewState["vendedor_id"].ToString(),
                                                    fila.Chasis,
                                                    Membership.GetUser().ProviderUserKey.ToString());
                    contador++;
                }

                ViewState["vendedor_id"] = null;

                rgVentas.DataSource = null;
                rgVentas.DataBind();
                grdVentasAsignadas.DataSource = null;
                grdVentasAsignadas.DataBind();

                txtNumeroChasis.Text = "";
                mvVendedores.SetActiveView(vListaVendedores);

                Metodo_Busqueda_Vendedores(Session["distribuidor_id"].ToString(), "");
                ConsultaVentasPorAsignar(int.Parse(Session["distribuidor_id"].ToString()));

                Master.MuestraMensaje("Las ventas se han asignado correctamente.");
            }
            catch
            {
                Master.MuestraMensaje("Ocurrió un error al asignar las ventas. Por favor intente nuevamente.");
            }
        }
        protected void rgVentas_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            rgVentas.DataSource = VentasPendientesAsignar;
        }
        protected IList<csParticipanteVentas> VentasPendientesAsignar
        {
            get
            {
                try
                {
                    object obj = Session["VentasPendientesAsignar"];
                    if (obj == null)
                    {
                        obj = ConsultaChasisesPendientes(Convert.ToInt32(Session["distribuidor_id"].ToString()));
                        if (obj != null)
                        {
                            Session["VentasPendientesAsignar"] = obj;
                        }
                        else
                        {
                            obj = new List<csParticipanteVentas>();
                        }
                    }
                    return (IList<csParticipanteVentas>)obj;
                }
                catch
                {
                    Session["VentasPendientesAsignar"] = null;
                }
                return new List<csParticipanteVentas>();
            }
            set
            {
                Session["VentasPendientesAsignar"] = value;
            }
        }
        protected IList<csParticipanteVentas> VentasAsignadas
        {
            get
            {
                try
                {
                    object obj = Session["VentasAsignadas"];
                    if (obj == null)
                    {
                        Session["VentasAsignadas"] = obj = new List<csParticipanteVentas>();
                    }
                    return (IList<csParticipanteVentas>)obj;
                }
                catch
                {
                    Session["VentasAsignadas"] = null;
                }
                return new List<csParticipanteVentas>();
            }
            set
            {
                Session["VentasAsignadas"] = value;
            }
        }
        protected void rgVentas_RowDrop(object sender, Telerik.Web.UI.GridDragDropEventArgs e)
        {
            MoverVenta(rgVentas, grdVentasAsignadas, e, VentasAsignadas, VentasPendientesAsignar);
        }
        private static csParticipanteVentas GetVenta(IEnumerable<csParticipanteVentas> ordersToSearchIn, string chasis)
        {
            foreach (csParticipanteVentas venta in ordersToSearchIn)
            {
                if (venta.Chasis == chasis)
                {
                    return venta;
                }
            }
            return null;
        }
        protected void grdVentasAsignadas_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            grdVentasAsignadas.DataSource = VentasAsignadas;
        }
        protected void grdVentasAsignadas_RowDrop(object sender, GridDragDropEventArgs e)
        {
            MoverVenta(grdVentasAsignadas, rgVentas, e, VentasPendientesAsignar, VentasAsignadas);
        }
        /// <summary>
        /// Método para mover las ventas entre los grids
        /// </summary>
        /// <param name="gridOrigen">Grid del cual se está moviendo</param>
        /// <param name="gridDestino">Grid al cual se va a mover el item</param>
        /// <param name="e">Evento del RowDrop</param>
        /// <param name="VentasDestino">Lista de las ventas asociadas al grid destino</param>
        /// <param name="VentasOrigen">Lista de las ventas asociadas al grid origen</param>
        private void MoverVenta(RadGrid gridOrigen, RadGrid gridDestino, GridDragDropEventArgs e, IList<csParticipanteVentas> VentasDestino, IList<csParticipanteVentas> VentasOrigen)
        {
            if (string.IsNullOrEmpty(e.HtmlElement))
            {
                if (e.DraggedItems[0].OwnerGridID == gridOrigen.ClientID)
                {
                    if ((e.DestDataItem == null && VentasDestino.Count == 0) || e.DestDataItem != null && e.DestDataItem.OwnerGridID == gridDestino.ClientID)
                    {
                        IList<csParticipanteVentas> ventasDestino = VentasDestino;
                        IList<csParticipanteVentas> ventasOrigen = VentasOrigen;

                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            csParticipanteVentas tmpOrder = GetVenta(ventasOrigen, draggedItem.GetDataKeyValue("Chasis").ToString());
                            if (tmpOrder != null)
                            {
                                ventasDestino.Add(tmpOrder);
                                ventasOrigen.Remove(tmpOrder);
                            }
                        }
                        VentasDestino = ventasDestino;
                        VentasOrigen = ventasOrigen;
                        gridOrigen.Rebind();
                        gridDestino.Rebind();
                    }
                    else if (e.DestDataItem != null && e.DestDataItem.OwnerGridID == gridOrigen.ClientID)
                    {
                        IList<csParticipanteVentas> ventasOrigen = VentasOrigen;
                        csParticipanteVentas order = GetVenta(ventasOrigen, e.DestDataItem.GetDataKeyValue("Chasis").ToString());
                        int destinationIndex = ventasOrigen.IndexOf(order);
                        List<csParticipanteVentas> ordersToMove = new List<csParticipanteVentas>();
                        foreach (GridDataItem draggedItem in e.DraggedItems)
                        {
                            csParticipanteVentas tmpOrder = GetVenta(ventasOrigen, draggedItem.GetDataKeyValue("Chasis").ToString());
                            if (tmpOrder != null)
                                ordersToMove.Add(tmpOrder);
                        }
                        foreach (csParticipanteVentas orderToMove in ordersToMove)
                        {
                            ventasOrigen.Remove(orderToMove);
                            ventasOrigen.Insert(destinationIndex, orderToMove);
                        }
                        VentasOrigen = ventasOrigen;
                        gridOrigen.Rebind();
                        e.DestDataItem.Selected = true;
                    }
                }
            }
        }
        protected void rgVentas_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "delete")
            {
                csDistribuidor d = new csDistribuidor();
                d.InactivaChasis((e.Item as GridDataItem).GetDataKeyValue("Chasis").ToString());


                csParticipanteVentas tmpOrder = GetVenta(VentasPendientesAsignar, (e.Item as GridDataItem).GetDataKeyValue("Chasis").ToString());
                VentasPendientesAsignar.Remove(tmpOrder);

                rgVentas.Rebind();
            }
        }

        protected void lnkHistorico_Click(object sender, EventArgs e)
        {
            csDistribuidor d = new csDistribuidor();
            lvHistorico.DataSource = d.ConsultaHistoricoAsignaciones(int.Parse(Session["distribuidor_id"].ToString()));
            lvHistorico.DataBind();

            mvVendedores.SetActiveView(vHistorico);
        }

        protected void lnkRegresarHistorico_Click(object sender, EventArgs e)
        {
            mvVendedores.SetActiveView(vListaVendedores);
        }
    }
}
