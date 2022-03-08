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

namespace CallcenterNUevo.POS
{
    public partial class AcumulaTicketsXContingencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                NuevoregistroAcumulaTicketsXContingencia("A");
                txtNoTicket.Focus();
            }

            //int Indice = grvAcumTicketXCont.Rows.Count - 1;
            //TextBox  txtCantidad = (TextBox)grvAcumTicketXCont.Rows[Indice].FindControl("txtCantidad") as TextBox;
            //txtCantidad.Attributes.Add("onkeypress", "cambiaFoco('txtPrecioFinal')");
        }
        protected void txtSucursal_TextChanged(object sender, EventArgs e)
        {

            ModSucursales Respuesta = new ModSucursales();
            int intSucursal = 0;
            AdministraPOS Ejecutar = new AdministraPOS();
            Respuesta = Ejecutar.ValidaandObtenSucursal(txtSucursal.Text);

            if (string.IsNullOrWhiteSpace(Respuesta.CveSucursal))
            {
                Mensajes("La sucursal proporcionada no existe. ¡Intente de nuevo!");
                txtSucursal.Text = "";
                txtSucursal.Focus();
            }
        }
        protected void txtTarjeta_TextChanged(object sender, EventArgs e)
        {
            bool Respuesta = false;

            AdministraPOS Ejecutar = new AdministraPOS();
            Respuesta = Ejecutar.ValidaTarjeta(txtTarjeta.Text);

            if (!Respuesta)
            {
                Mensajes("La tarjeta proporcionada no existe. ¡Intente de nuevo!");
                txtTarjeta.Text = "";
                txtTarjeta.Focus();
            }
        }
        protected void txtCodInterno__TextChanged(object sender, EventArgs e)
        {
            //Para obtener el Indice del control TexBox dentro del gridview
            TextBox txt = sender as TextBox;
            GridViewRow row = txt.NamingContainer as GridViewRow;
            int rowIndex = row.RowIndex;

            Session.Add("Indice_CodInterno", rowIndex);

            //Valida el código interno que se encuentre vigente en alguna mécanica
            if (!ValidaSKU(grvAcumTicketXCont))
            {
                Mensajes("El código interno proporcionado no existe en ninguna mecanica vigente.");
                TextBox txtCodInterno = grvAcumTicketXCont.Rows[rowIndex].FindControl("txtCodInterno") as TextBox;
                txtCodInterno.Text = "";
                txtCodInterno.Focus();
                return;
            }
        }

        protected void grvAcumTicketXCont_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() != "Delete")
            {
                Session.Add("Sender", sender);
                Session.Add("E", e);
                RealizaConsulta(sender, e);
            }
        }
        protected void grvAcumTicketXCont_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (grvAcumTicketXCont.Rows.Count > 1)
            {
                int Indice = 0;
                DataTable dt = new DataTable();
                dt = EstructuraPromos();
                DataRow dr;
                int Index = 0;
                //Recorre el contenido del grid y lo guarda en datatable
                foreach (GridViewRow row in this.grvAcumTicketXCont.Rows)
                {
                    TextBox txtCodigoBarras = (TextBox)row.FindControl("txtCodigoBarras");
                    TextBox txtCodInterno = (TextBox)row.FindControl("txtCodInterno");
                    TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");
                    //TextBox txtMontoBaseAcumular = (TextBox)row.FindControl("txtMontoBaseAcumular");
                    //TextBox txtPrecioDescuento = (TextBox)row.FindControl("txtPrecioDescuento");
                    TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinal");
                    Button btnPopup = (Button)row.FindControl("btnPopup");

                    dr = dt.NewRow();
                    dr[0] = Index;
                    dr[1] = txtCodigoBarras.Text;
                    dr[2] = txtCodInterno.Text;
                    dr[3] = txtCantidad.Text;
                    //dr[4] = txtMontoBaseAcumular.Text;
                    //dr[5] = txtPrecioDescuento.Text;
                    dr[4] = txtPrecioFinal.Text;

                    dt.Rows.Add(dr);
                    Index += 1;
                }

                //Elimina registro de datatable
                dt.Rows.RemoveAt(e.RowIndex);

                //Asigna valor de datatable al viewState
                ViewState["DataTemp"] = dt;
                //Session.Add("DTElementosMemoria", dt);

                grvAcumTicketXCont.DataSource = ViewState["DataTemp"];
                grvAcumTicketXCont.DataBind();

                Indice = Convert.ToInt32(Session["Indice_CodInterno"].ToString());
                if (Indice > 1)
                {
                    //Resta una fila la cual fue eliminada
                    Indice = (Indice - 1);
                    Session.Add("Indice_CodInterno", Indice);
                }
            }
            else
            {
                Mensajes("imposible eliminar esta fila.");
            }
        }
        protected void grvProd_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            object serderParse = (object)Session["Sender"];
            GridViewCommandEventArgs GridViewCommandParse = (GridViewCommandEventArgs)Session["E"];

            RealizaConsulta(serderParse, GridViewCommandParse);
        }
        protected void grvProd_ItemCommand(object sender, GridCommandEventArgs e)
        {
            int Indice = 0;
            RadComboBox cmblab = new RadComboBox();
            GridDataItem item;
            int contar = 0;

            switch (e.CommandName)
            {
                case "SelCodint":
                    item = (GridDataItem)e.Item;

                    Indice = (Int32)Session["Indice_CodInterno"];

                    foreach (GridViewRow row in this.grvAcumTicketXCont.Rows)
                    {
                        if (Indice == contar)
                        {
                            TextBox txtCodigoBarras = (TextBox)row.FindControl("txtCodigoBarras");
                            TextBox txtCodInterno = (TextBox)row.FindControl("txtCodInterno");
                            TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");

                            txtCodigoBarras.Text = item.Cells[3].Text;
                            txtCodInterno.Text = item.Cells[4].Text;
                            txtCantidad.Focus();
                        }
                        contar += 1;
                    }
                    break;
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidaPedidos())
            {
                int Indice = 0;
                NuevoregistroAcumulaTicketsXContingencia("A");
                Indice = int.Parse(Session["Indice_CodInterno"].ToString());
                TextBox txtCodInterno = (TextBox)grvAcumTicketXCont.Rows[Indice].FindControl("txtCodInterno");
                txtCodInterno.Focus();
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Valores fijos
            string CveClienteABF = "0";
            string ConfirmacionRedencion = "0";
            int ProgramaID = 1;
            string Llave = "998877";
            string FormaPago = "";
            float MontoTotalRedimido = 0;
            string Promociones = "0";
            int Beneficio = 0;
            string TipoAcumulacion = "CONTINGENCIA";
            string Usuario = this.User.Identity.Name.ToString();
            float PrecioDescuento = 0;
            float PrecioFinal = 0;
            int cantidad = 0;
            string PromocionesDp = "";
            string RefProducto = "";
            string strcotizacion = "";

            try
            {
                if (Validaciones()) //Valida campos generales
                {
                    if (ValidaPedidos())//Valida campos del grid
                    {
                        //Obtener Beneficos
                        CallcenterNUevo.WsReglasNegocio.wsTicket resultOB = new WsReglasNegocio.wsTicket();
                        resultOB = ObtenerBeneficios();

                        if (resultOB.CodigoRespuesta_StrCodigo != "0")
                        {
                            Mensajes(resultOB.CodigoRespuesta_strDescripcion);
                            return;
                        }
                        else
                        {
                            strcotizacion = resultOB.CotizacionId;
                            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.POSAcumulaTicketsXContingencia", "No de cotización: " + strcotizacion, "ObtenerBeneficio", this.User.Identity.Name.ToString(), null);
                        }

                        //Cerrar Compra
                        CallcenterNUevo.WsReglasNegocio.WsReglasNegocioSoapClient objWS_EjecutarMet = new CallcenterNUevo.WsReglasNegocio.WsReglasNegocioSoapClient();
                        CallcenterNUevo.WsReglasNegocio.CerrarCotizacionEntrada objWSCC_Resp = new CallcenterNUevo.WsReglasNegocio.CerrarCotizacionEntrada();
                        CallcenterNUevo.WsReglasNegocio.CerrarCotizacionSalida result = new WsReglasNegocio.CerrarCotizacionSalida();
                        CallcenterNUevo.WsReglasNegocio.PedidosCerrarCotizacion[] objPedidos = new WsReglasNegocio.PedidosCerrarCotizacion[0];

                        //Setear valores
                        objWSCC_Resp.Llave = Llave;
                        objWSCC_Resp.ClienteABF = CveClienteABF;
                        objWSCC_Resp.Cotizacion = strcotizacion;
                        objWSCC_Resp.MontoTotalRedimido = MontoTotalRedimido;
                        objWSCC_Resp.ProgramaId = ProgramaID;
                        objWSCC_Resp.TipoAcumulacion = TipoAcumulacion;
                        objWSCC_Resp.Usuario = Usuario;
                        objWSCC_Resp.SucursalId = Convert.ToInt32(txtSucursal.Text);
                        objWSCC_Resp.Terminal = Convert.ToInt32(txtCaja.Text);
                        objWSCC_Resp.NoTicket = txtNoTicket.Text;
                        objWSCC_Resp.Importe = float.Parse(txtImporte.Text);
                        objWSCC_Resp.Tarjeta = txtTarjeta.Text;
                        objWSCC_Resp.ConfirmacionRedencion = ConfirmacionRedencion;
                        objWSCC_Resp.Promociones = Promociones;

                        foreach (GridViewRow row in this.grvAcumTicketXCont.Rows)
                        {
                            CallcenterNUevo.WsReglasNegocio.PedidosCerrarCotizacion itemPedido;

                            TextBox txtCodigoBarras = (TextBox)row.FindControl("txtCodigoBarras");
                            TextBox txtCodInterno = (TextBox)row.FindControl("txtCodInterno");
                            TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");
                            TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinal");

                            itemPedido = new CallcenterNUevo.WsReglasNegocio.PedidosCerrarCotizacion();
                            Array.Resize(ref objPedidos, objPedidos.Length + 1);

                            itemPedido.Beneficios = Beneficio;
                            itemPedido.CodigoBarras = txtCodigoBarras.Text;
                            itemPedido.CodigoInterno = txtCodInterno.Text;

                            PrecioFinal = float.Parse(txtPrecioFinal.Text);
                            PrecioDescuento = float.Parse(txtPrecioFinal.Text);

                            itemPedido.Compras = Convert.ToInt32(txtCantidad.Text);
                            itemPedido.MontoBaseParaAcumular = (Convert.ToInt32(txtCantidad.Text) * float.Parse(txtPrecioFinal.Text));
                            itemPedido.MontoRedimido = 0;
                            itemPedido.PrecioDescuento = PrecioDescuento;
                            itemPedido.PrecioFinal = PrecioFinal;
                            itemPedido.PromocionesDp = PromocionesDp;
                            itemPedido.RefProducto = RefProducto;

                            objPedidos[objPedidos.Length - 1] = itemPedido;
                        }

                        FormaPago = "1," + txtImporte.Text.Trim() + ", 0";
                        objWSCC_Resp.FormaPago = FormaPago;

                        objWSCC_Resp.Pedidos = objPedidos;

                        Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.POSAcumulaTicketsXContingencia", "CerrarCompra", "Inicio CerrarCompra", this.User.Identity.Name.ToString(), null);
                        result = objWS_EjecutarMet.CerrarCompra(objWSCC_Resp);
                        Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.POSAcumulaTicketsXContingencia", "CerrarCompra", "Fin CerrarCompra", this.User.Identity.Name.ToString(), null);

                        if (result.CodigoError == "PC001")
                        {
                            Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.POSAcumulaTicketsXContingencia", "btnGuardar_Click", "Metodos de guardado", "Ocurrio un error: " + result.CodigoError + " - " + result.DescripcionCodigoRespuesta, this.User.Identity.Name.ToString(), null);
                            Mensajes("No fue posible realizar el cierre de compra, contacte al administrador");
                        }
                        else
                        {
                            Mensajes(result.DescripcionCodigoRespuesta);
                            EliminarVariablesSession();
                            LimpiarCampos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.POSAcumulaTicketsXContingencia", "btnGuardar_Click", "Metodos de guardado", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar guardar tickets por contingencia., contacte al administrador");
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            EliminarVariablesSession();
            Response.Redirect("../Default.aspx");
        }
        protected void btnPopup_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
        }

        private bool Validaciones()
        {
            bool blnRespuesta = true;


            if (string.IsNullOrWhiteSpace(txtNoTicket.Text))
            {
                Mensajes("Debe proporcionar número de ticket necesariamente.");
                txtNoTicket.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtImporte.Text))
            {
                Mensajes("Debe proporcionar el importe necesariamente.");
                txtImporte.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSucursal.Text))
            {
                Mensajes("Debe proporcionar la sucursal necesariamente.");
                txtSucursal.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTarjeta.Text))
            {
                Mensajes("Debe proporcionar la tarjeta necesariamente.");
                txtTarjeta.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCaja.Text))
            {
                Mensajes("Debe proporcionar el número de caja necesariamente.");
                txtCaja.Focus();
                return false;
            }

            return blnRespuesta;
        }
        private bool ValidaPedidos()
        {
            bool blnagregarNvoreg = true;
            foreach (GridViewRow row in this.grvAcumTicketXCont.Rows)
            {
                TextBox txtCodigoBarras = (TextBox)row.FindControl("txtCodigoBarras");
                TextBox txtCodInterno = (TextBox)row.FindControl("txtCodInterno");
                TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");
                //TextBox txtMontoBaseAcumular = (TextBox)row.FindControl("txtMontoBaseAcumular");
                //TextBox txtPrecioDescuento = (TextBox)row.FindControl("txtPrecioDescuento");
                TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinal");


                if (string.IsNullOrWhiteSpace(txtCodigoBarras.Text))
                {
                    Mensajes("Es necesario indique el código de barras.");
                    txtCodigoBarras.Focus();
                    blnagregarNvoreg = false;
                    break;
                }
                if (string.IsNullOrWhiteSpace(txtCodInterno.Text))
                {
                    Mensajes("Es necesario indique el código interno.");
                    txtCodInterno.Focus();
                    blnagregarNvoreg = false;
                    break;
                }
                if (txtCantidad.Text == "0")
                {
                    Mensajes("Es necesario indique la cantidad.");
                    txtCantidad.Focus();
                    blnagregarNvoreg = false;
                    break;
                }
                //if (txtMontoBaseAcumular.Text == "0")
                //{
                //    Mensajes("Es necesario indique el monto base.");
                //    txtMontoBaseAcumular.Focus();
                //    blnagregarNvoreg = false;
                //    break;
                //}
                //if (txtPrecioDescuento.Text == "0")
                //{
                //    Mensajes("Es necesario indique el Precio descuento.");
                //    txtPrecioDescuento.Focus();
                //    blnagregarNvoreg = false;
                //    break;
                //}
                if (txtPrecioFinal.Text == "0")
                {
                    Mensajes("Es necesario indique el Precio final.");
                    txtPrecioFinal.Focus();
                    blnagregarNvoreg = false;
                    break;
                }
            }
            return blnagregarNvoreg;
        }
        private bool ValidaSKU(GridView grv)
        {
            bool blnRespuesta = false;
            AdministraPOS ejecutar = new AdministraPOS();

            foreach (GridViewRow row in this.grvAcumTicketXCont.Rows)
            {
                TextBox txtCodInterno = (TextBox)row.FindControl("txtCodInterno");

                blnRespuesta = ejecutar.ValidaSKUMecanicaVigente(txtCodInterno.Text);
            }

            return blnRespuesta;
        }
        private DataTable EstructuraPromos()
        {
            DataTable medidaTabla = new DataTable();

            medidaTabla.Columns.Add("Index", typeof(Int32));
            medidaTabla.Columns.Add("CodigoBarras", typeof(string));
            medidaTabla.Columns.Add("CodInterno", typeof(string));
            medidaTabla.Columns.Add("Cantidad", typeof(Int32));
            //medidaTabla.Columns.Add("MontoBaseAcumular", typeof(Int64));
            //medidaTabla.Columns.Add("PrecioDescuento", typeof(Int64));
            medidaTabla.Columns.Add("PrecioFinal", typeof(decimal));

            return medidaTabla;
        }
        private void NuevoregistroAcumulaTicketsXContingencia(string tipo)
        {
            int CuentaRegVacios = 0;
            TextBox txtCodigoBarras;
            TextBox txtCodInterno;
            TextBox txtCantidad;
            TextBox txtMontoBaseAcumular;
            TextBox txtPrecioDescuento;
            TextBox txtPrecioFinal;
            Button btnPopup;

            DataTable dt = null;
            dt = EstructuraPromos();
            DataRow dr;
            int Index = 0;

            foreach (GridViewRow row in this.grvAcumTicketXCont.Rows)
            {
                txtCodigoBarras = (TextBox)row.FindControl("txtCodigoBarras");
                txtCodInterno = (TextBox)row.FindControl("txtCodInterno");
                txtCantidad = (TextBox)row.FindControl("txtCantidad");
                //txtMontoBaseAcumular = (TextBox)row.FindControl("txtMontoBaseAcumular");
                //txtPrecioDescuento = (TextBox)row.FindControl("txtPrecioDescuento");
                txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinal");
                btnPopup = (Button)row.FindControl("btnPopup");

                //Index = Convert.ToInt32(btnPopup.CommandArgument.ToString()); 
                Session.Add("Indice_CodInterno", Index);

                dr = dt.NewRow();
                dr[0] = Index;
                dr[1] = txtCodigoBarras.Text;
                dr[2] = txtCodInterno.Text;
                dr[3] = txtCantidad.Text;
                //dr[4] = txtMontoBaseAcumular.Text;
                //dr[5] = txtPrecioDescuento.Text;
                dr[4] = txtPrecioFinal.Text;

                //Agrega a la tabla datos capturados
                dt.Rows.Add(dr);
                //Agrega el datatable al viewstate
                ViewState["DataTemp"] = dt;


                if (
                string.IsNullOrWhiteSpace(txtCodigoBarras.Text) ||
                string.IsNullOrWhiteSpace(txtCodInterno.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                Convert.ToInt32(txtCantidad.Text) == 0 ||
                string.IsNullOrWhiteSpace(txtPrecioFinal.Text) ||
                Convert.ToDecimal(txtPrecioFinal.Text) == 0)
                {
                    CuentaRegVacios += 1;
                }
                else
                {
                    CuentaRegVacios += 0;
                }
                Index += 1;
            }

            //Nuevo registros
            if (tipo == "A" && CuentaRegVacios == 0)
            {
                Session.Add("Indice_CodInterno", Index);

                dr = dt.NewRow();
                dr[0] = Index;
                dr[1] = "";
                dr[2] = "";
                dr[3] = 1;
                //dr[4] = 0;
                //dr[5] = 0;
                dr[4] = 0;

                dt.Rows.Add(dr);
                ViewState["DataTemp"] = dt;
                this.grvAcumTicketXCont.DataSource = ViewState["DataTemp"];
                this.grvAcumTicketXCont.DataBind();
            }
            else
            {   //En caso de detectar campos vacios dentro de una fila
                Mensajes("No debe dejar filas y/o celdas vacias.");
            }
        }
        private void LimpiarCampos()
        {
            txtNoTicket.Text = "";
            txtImporte.Text = "";
            txtSucursal.Text = "";
            txtTarjeta.Text = "";
            txtCaja.Text = "";

            grvAcumTicketXCont.DataSource = null;
            grvAcumTicketXCont.DataBind();
            NuevoregistroAcumulaTicketsXContingencia("A");
            txtNoTicket.Focus();
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
        private CallcenterNUevo.WsReglasNegocio.wsTicket ObtenerBeneficios()
        {
            //Valores fijos
            int CadenaIntID = 1;
            string CedulaProfesional = "0";
            string ClaveClienteABF = "0";
            int FolioRecetaSAC = 0;
            string IntABF = "0";
            string ProgramaID = "1";
            string Llave = "998877";
            int NumPedidoDomicio = 0;
            string TipoAcumulacion = "CONTINGENCIA";
            string UsuarioCaja = this.User.Identity.Name.ToString();
            string VersionPOS = "1";
            float PrecioFinal = 0;

            int cantidad = 0;

            CallcenterNUevo.WsReglasNegocio.wsTicket result = new WsReglasNegocio.wsTicket();

            try
            {
                if (Validaciones()) //Valida campos generales
                {
                    if (ValidaPedidos())//Valida campos del grid
                    {
                        //Obtener Beneficios
                        CallcenterNUevo.WsReglasNegocio.WsReglasNegocioSoapClient objWS_EjecutarMet = new WsReglasNegocio.WsReglasNegocioSoapClient();
                        CallcenterNUevo.WsReglasNegocio.wsCompra objWSOB_Resp = new WsReglasNegocio.wsCompra();

                        CallcenterNUevo.WsReglasNegocio.wsPedido[] objPedidos = new CallcenterNUevo.WsReglasNegocio.wsPedido[0];

                        //Setear valores
                        //Setear valores
                        objWSOB_Resp.Llave = Llave;
                        objWSOB_Resp.Cadena_intId = CadenaIntID;
                        objWSOB_Resp.CveClienteABF = ClaveClienteABF;
                        objWSOB_Resp.Cedulaprofesional = CedulaProfesional;

                        objWSOB_Resp.FolioRecetaSAC = FolioRecetaSAC;
                        objWSOB_Resp.IntABF = IntABF;
                        objWSOB_Resp.Llave = Llave;
                        objWSOB_Resp.NumPedidoDomicilio = NumPedidoDomicio;
                        objWSOB_Resp.ProgramaID = ProgramaID;
                        objWSOB_Resp.Sucursal_intId = Convert.ToInt32(txtSucursal.Text);
                        objWSOB_Resp.Tarjeta = txtTarjeta.Text;
                        objWSOB_Resp.Terminal_intId = Convert.ToInt32(txtCaja.Text);
                        objWSOB_Resp.Ticket_strId = txtNoTicket.Text;
                        objWSOB_Resp.TipoAcumulacion = TipoAcumulacion;
                        objWSOB_Resp.UsuarioCaja = UsuarioCaja;
                        objWSOB_Resp.VersionPOS = VersionPOS;


                        foreach (GridViewRow row in this.grvAcumTicketXCont.Rows)
                        {
                            CallcenterNUevo.WsReglasNegocio.wsPedido itemPedido;

                            TextBox txtCodigoBarras = (TextBox)row.FindControl("txtCodigoBarras");
                            TextBox txtCodInterno = (TextBox)row.FindControl("txtCodInterno");
                            TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");
                            TextBox txtPrecioFinal = (TextBox)row.FindControl("txtPrecioFinal");


                            itemPedido = new CallcenterNUevo.WsReglasNegocio.wsPedido();
                            Array.Resize(ref objPedidos, objPedidos.Length + 1);

                            PrecioFinal = float.Parse(txtPrecioFinal.Text);
                            itemPedido.CantidadPiezas = Convert.ToInt32(txtCantidad.Text);
                            itemPedido.CodigoBarras = txtCodigoBarras.Text;
                            itemPedido.CodigoInterno = txtCodInterno.Text;
                            itemPedido.PedidoIVA = 0;
                            itemPedido.PrecioLista = PrecioFinal;
                            itemPedido.PrecioMaximoPublico = PrecioFinal;
                            itemPedido.PrecioOferta = PrecioFinal;
                            itemPedido.RefProducto = "";

                            objPedidos[objPedidos.Length - 1] = itemPedido;
                        }

                        objWSOB_Resp.wsPedido = objPedidos;

                        Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.POSAcumulaTicketsXContingencia", "ObtenerBeneficios", "Inicio compra", this.User.Identity.Name.ToString(), null);
                        result = objWS_EjecutarMet.ObtenerBeneficios(objWSOB_Resp);
                        Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.INFO, System.Reflection.Assembly.GetExecutingAssembly(), "FRONT", "CallCenterNUevo.POSAcumulaTicketsXContingencia", "ObtenerBeneficios", "Fin compra", this.User.Identity.Name.ToString(), null);
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.POSAcumulaTicketsXContingencia", "ObtenerBeneficios()", "Metodos que devuelve cotización", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar obtener beneficios., contacte al administrador");
            }

            return result;
        }
        private void RealizaConsulta(object sender, GridViewCommandEventArgs e)
        {
            Int64 temp = 0;
            int contar = 0;
            //int Indice = Convert.ToInt32(e.CommandArgument.ToString());
            int Indice = Convert.ToInt32(Session["Indice_CodInterno"].ToString());


            List<ModProductosPOS> lstRespuesta = new List<ModProductosPOS>();
            AdministraPOS Ejecutar = new AdministraPOS();

            foreach (GridViewRow row in this.grvAcumTicketXCont.Rows)
            {
                if (Indice == contar)
                {
                    TextBox txtCodigoBarras = (TextBox)row.FindControl("txtCodigoBarras");
                    TextBox txtCodInterno = (TextBox)row.FindControl("txtCodInterno");
                    TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");

                    if (string.IsNullOrWhiteSpace(txtCodInterno.Text))
                    {
                        Mensajes("Proporcione un código interno o nombre de poroducto para realizar su consulta.");
                        txtCodigoBarras.Text = "";
                        txtCodInterno.Focus();
                        return;
                    }

                    lstRespuesta = Ejecutar.ValidaCodInterno(txtCodInterno.Text);

                    if (lstRespuesta.Count > 0)
                    {
                        //Valida si es numerico
                        if (Int64.TryParse(txtCodInterno.Text, out temp) && lstRespuesta.Count > 0)
                        {
                            if (lstRespuesta.Count == 1)//Si el resultado es un registro, setea de inmediato los valores
                            {
                                txtCodigoBarras.Text = lstRespuesta[0].CodigoBarras;
                                txtCodInterno.Text = lstRespuesta[0].CodigoInterno;
                                txtCantidad.Focus();
                            }
                            else
                            {
                                Session.Add("Indice_CodInterno", Indice);
                                grvProd.DataSource = null;
                                grvProd.DataBind();

                                grvProd.DataSource = lstRespuesta;
                                grvProd.DataBind();
                                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                            }
                        }
                        else
                        {
                            Session.Add("Indice_CodInterno", Indice);
                            grvProd.DataSource = null;
                            grvProd.DataBind();

                            grvProd.DataSource = lstRespuesta;
                            grvProd.DataBind();
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>ShowReg();</script>", false);
                        }
                    }
                    else
                    {
                        if (Int64.TryParse(txtCodInterno.Text, out temp))
                        {
                            txtCodigoBarras.Text = "";
                            txtCodInterno.Focus();
                            Mensajes("El código interno proporcionado no existe. ¡Intente de nuevo!");
                        }
                        else
                        {
                            txtCodigoBarras.Text = "";
                            txtCodInterno.Focus();
                            Mensajes("El nombre de producto proporcionado no existe. ¡Intente de nuevo!");
                        }

                        txtCodInterno.Text = "";
                        txtCodInterno.Focus();
                    }
                }
                contar += 1;
            }
        }
        private void EliminarVariablesSession()
        {
            Session.Contents.Remove("Indice_CodInterno");
            Session.Remove("Indice_CodInterno");
            Session.Contents.Remove("Sender");
            Session.Remove("Sender");
            Session.Contents.Remove("E");
            Session.Remove("E");
        }
    }
}