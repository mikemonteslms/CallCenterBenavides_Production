using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net; 
using Negocio;

namespace WebPfizer.LMS.eCard
{

    public partial class RegistroTicket : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Catalogos objConsultaDatos = new Catalogos();
        Transaccion objTransaccion = new Transaccion();
        List<SkuMedicamento> canasta = new List<SkuMedicamento>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["canasta"] != null)
            {
                canasta = (List<SkuMedicamento>)Session["canasta"];
            }

            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx", true);
            }

            this.Page.Header.Title = "Registrar Ticket";
            if (!IsPostBack)
            {
                Label tituloPagina = (Label)Master.FindControl("lblTituloPagina");
                tituloPagina.Text = "Registro de Ticket";
                //quitar el default a la fecha, solicitud 20110306
                //txtFechaTicket.Text = (DateTime.Parse(DateTime.Now.ToString())).ToString("dd/MM/yyyy");

                LlenaListaMedicamentos();

                CargarCatalogo("Cadena", cmbCadena, "");
                this.lblTarjeta.Text = Session["Tarjeta"].ToString();

                LoadData();
            }
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("SKU");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Eliminar");

            DataRow dr = dt.NewRow();

            dr["SKU"] = String.Empty;
            dr["Descripcion"] = String.Empty;
            dr["Cantidad"] = String.Empty;
            dr["Eliminar"] = String.Empty;

            dt.Rows.Add(dr);

            this.grdCanasta.DataSource = dt;
            this.grdCanasta.DataBind();
            Panel2.BorderColor = System.Drawing.Color.LightSteelBlue;
            Panel2.BorderStyle = System.Web.UI.WebControls.BorderStyle.Double;
            txtCotizacion.Text = "";
        }

        private void LlenaListaMedicamentos()
        {
            string strTarjeta = Session["Tarjeta"].ToString();
            DataSet listaMedicamentos = Medicamentos.ListaMedicamentosVentaFarmacias(strTarjeta);
            Session["listaMedicamentos"] = listaMedicamentos;
            grdMedicamentos.DataSource = listaMedicamentos.Tables[0];
            grdMedicamentos.DataBind();
            Panel1.BorderColor = System.Drawing.Color.LightSteelBlue;
            Panel1.BorderStyle = System.Web.UI.WebControls.BorderStyle.Double;
        }

        protected void CargarCatalogo(string @Catalogo, DropDownList ControlCombo, string cadena)
        {
            try
            {
                objDataset = objConsultaDatos.DatosCatalogo(@Catalogo, cadena);
                ControlCombo.Items.Clear();
                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    ControlCombo.Items.Add(new ListItem("--Seleccione--", "00"));
                    for (int i = 0; i <= objDataset.Tables[0].Rows.Count - 1; i++)
                    {
                        ListItem Item = new ListItem();
                        Item.Value = objDataset.Tables[0].Rows[i]["intID"].ToString();
                        Item.Text = objDataset.Tables[0].Rows[i]["strDescripcion"].ToString();
                        ControlCombo.Items.Add(Item);
                    }
                }
            }
            catch
            {

            }
        }

        protected void cmbCadena_SelectedIndexChanged(object sender, EventArgs e)
        {
            regexpFundafarmacia.Enabled = false;
            CargarCatalogo("Sucursal", cmbSucursal, cmbCadena.Text);
            if (cmbCadena.SelectedValue == "3")
            {
                regexpFundafarmacia.Enabled = true; 
            }
        }

        protected void grdMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = grdMedicamentos.SelectedRow;
            string sku = ((HiddenField)gvr.FindControl("SKU")).Value;
            string descripcion = HttpUtility.HtmlDecode(gvr.Cells[0].Text);
            string cantidad = "1";

            SkuMedicamento result = canasta.Find
                (
                    delegate(SkuMedicamento SkuM)
                    {
                        return SkuM.Sku == sku;
                    }
                );
            if (result != null)
            {
                for (int i = 0; i < canasta.Count; i++)
                {
                    if (canasta[i].Sku == ((HiddenField)gvr.FindControl("SKU")).Value)
                    {
                        canasta[i].Cantidad = (int.Parse(canasta[i].Cantidad) + 1).ToString();
                    }
                }
            }
            else
            {
                canasta.Add(new SkuMedicamento(sku, descripcion, cantidad));
            }

            grdCanasta.DataSource = canasta;
            grdCanasta.DataBind();
            Session["canasta"] = canasta;
            Panel2.BorderColor = System.Drawing.Color.LightSteelBlue;
            Panel2.BorderStyle = System.Web.UI.WebControls.BorderStyle.Double;

            grdBeneficios.Dispose();
            grdBeneficios.DataBind();
            btnCerrar.Enabled = false;
            btnCerrar.Visible = false;
            btnCancelar.Visible = false;
        }

        protected void grdCanasta_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = grdCanasta.SelectedRow;
            string sku = ((HiddenField)gvr.FindControl("SKU")).Value;

            SkuMedicamento result = canasta.Find
                (
                    delegate(SkuMedicamento SkuM)
                    {
                        return SkuM.Sku == sku;
                    }
                );
            if (result != null)
            {
                for (int i = 0; i < canasta.Count; i++)
                {
                    if (canasta[i].Sku == sku)
                    {
                        int cantidad = int.Parse(canasta[i].Cantidad);
                        if (cantidad > 1)
                        {
                            cantidad = cantidad - 1;
                            canasta[i].Cantidad = cantidad.ToString();
                            btnCompra.Focus();
                        }
                        else
                        {
                            canasta.RemoveAt(i);
                        }
                    }
                }
            }

            grdCanasta.DataSource = canasta;
            grdCanasta.DataBind();
            Session["canasta"] = canasta;

            if (canasta.Count == 0)
            {
                btnCerrar.Enabled = false;
                btnCerrar.Visible = false;
                btnCancelar.Visible = false;

                LoadData();

                DataTable dtCanasta = new DataTable();
                grdBeneficios.DataSource = dtCanasta.DefaultView;
                grdBeneficios.DataBind();
            }
        }

        protected void btnCompra_Click(object sender, EventArgs e)
        {
            int intContadorChampixInicio=0;
            int intContadorChampixSeguimiento=0;
            int intInventarioDisponible=0;
            decimal decInventarioDisponible = 0;
            lblMensaje.Visible = false;
            string strIDSucLocatel = "";
            string strIDSKULocatel = "";

            WsPrepago.Compra compra = new WsPrepago.Compra();
            if (((cmbCadena .SelectedValue == "3") && (!regexpFundafarmacia.IsValid) && regexpFundafarmacia.Enabled== true  ))
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = regexpFundafarmacia.ErrorMessage.ToString();
                return;
            }
            if (cmbCadena.SelectedValue == "3")   //validar que no se registr un ticket de año posterior
            {
                if (int.Parse(txtTicket.Text.Substring(4, 2)) > (System.DateTime.Now.Year - 2000))
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "El año registrado en el ticket es incorrecto";
                    return;
                }
            }
            compra.Tarjeta = Session["Tarjeta"].ToString();
            if (cmbCadena.Text == "00")
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Seleccione la Cadena";
                return;
            }
            else
            {
                compra.Cadena_intId = int.Parse(cmbCadena.SelectedValue);
            }            
            compra.Programa_intId = 1;
            if (cmbSucursal.Text == "00" || cmbSucursal.Text == "")
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Seleccione la Sucursal";
                return;
            }
            else
            {
                compra.Sucursal_intId = int.Parse(cmbSucursal.SelectedValue);
            }            
            compra.Terminal_intId = 1;
            if (txtUsuario.Text == "")
            {
                compra.UsuarioTicket_strId = "0";
            }
            else
            {
                compra.UsuarioTicket_strId = txtUsuario.Text;
            }
            if (txtFechaTicket.Text == "")
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Por favor capture la fecha de compra registrada en el ticket";
                return;
            }

            
            if (System.DateTime.Today < System.DateTime.Parse(txtFechaTicket.Text))
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "La fecha del ticket no puede ser posterior a la fecha actual.";
                return;
            }
            if (System.DateTime.Parse(txtFechaTicket.Text) < System.DateTime.Parse("2011-04-11"))
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "No se permite registrar tickets con fecha anterior a 2011-04-11.";
                return;
            }
            if ((txtTicket.Text == "") || (txtTicket.Text.Length<4))
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Por favor capture el numero de ticket";
                return;
            }
            compra.UsuarioCaptura_strId = Session["Usuario"].ToString();

            //JER Validar que el ticket no este capturado previamente
            //se manda al SP cadena, sucursal, ticket y fecha
            objDataset = objTransaccion.ValidarRegistroPrevio(cmbCadena.SelectedValue, cmbSucursal.SelectedValue, txtTicket.Text, txtFechaTicket.Text.Substring(6, 4) + txtFechaTicket.Text.Substring(3, 2) + txtFechaTicket.Text.Substring(0, 2));
            if (objDataset.Tables[0].Rows [0]["Error"].ToString () != "0")
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = objDataset.Tables[0].Rows[0]["Mensaje"].ToString();
                return;
            }
               

            //JER permitir que se mande la solicitud solo para recoger beneficios
            if (grdCanasta.Rows[0].Cells[1].Text == "&nbsp;")
            {
                return;
            }
            btnCompra.Enabled = false;
            cmbCadena.Enabled = false;
            cmbSucursal.Enabled = false;
            txtUsuario.Enabled = false;
            ImgCalendario.Enabled = false;
            txtTicket.Enabled = false;
            grdCanasta.Enabled = false;
            grdMedicamentos.Enabled = false;  
            chkConfirma.Visible = true; 


            WsPrepago.Pedido[] listaPedidos = new WsPrepago.Pedido[grdCanasta.Rows.Count+1];

            WsPrepago.Pedido pedido;//= new WsEcardPrePago.Pedido();

            for (int i = 0; i < grdCanasta.Rows.Count; i++)
            {
                pedido = new WsPrepago.Pedido();

                GridViewRow gvr = ((GridView)grdCanasta).Rows[i];
                if (grdCanasta.Rows[i].Cells[1].Text == "&nbsp;")
                {
                    return;
                }
                else
                {
                    pedido.SKU = ((HiddenField)gvr.FindControl("SKU")).Value;
                    pedido.DescripcionSKU = grdCanasta.Rows[i].Cells[1].Text;
                    pedido.Cantidad = int.Parse(grdCanasta.Rows[i].Cells[2].Text);
                    listaPedidos[i] = pedido;
                    //contador para Champix Inicio
                    if (pedido.SKU == "7795381411103") intContadorChampixInicio += 1;
                    //contador para Champix Seguimiento
                    if (pedido.SKU == "7795381411110") intContadorChampixSeguimiento += 1;
                }
            }

            //Añadir Champix a la cotizacion solo si compro el de Inicio 
            //permitiria solo recoger el beneficio, si tiene compras previas de Champix Seguimiento
            if ((intContadorChampixInicio > 0) && intContadorChampixSeguimiento == 0)
            {
                int largo = listaPedidos.Length - 1;
                WsPrepago.Pedido pedidoADD;
                pedidoADD = new WsPrepago.Pedido();
                pedidoADD.SKU = "7795381411110";
                pedidoADD.DescripcionSKU = "CHAMPIX  1MGx28";
                pedidoADD.Cantidad = 0;
                listaPedidos[largo] = pedidoADD;
            }
            //Fin Añadir Champix
            
            compra.Pedido = listaPedidos;

            WsPrepago.Ticket ticket = new WsPrepago.Ticket();

            WsPrepago.WsEcardPrePago ejecuta = new WsPrepago.WsEcardPrePago();

            ticket = ejecuta.ProcesarCompra(compra);

            DataTable dtCanasta = new DataTable();
            dtCanasta.Columns.Add("SKU");
            dtCanasta.Columns.Add("Descripcion");
            //dtCanasta.Columns.Add("Compras");
            dtCanasta.Columns.Add("Beneficios");
            dtCanasta.Columns.Add("Cantidad");
            //dtCanasta.Columns.Add("Sugeridos");
            
            dtCanasta.Columns.Add("Disponible");
            if (ticket.CodigoExcepcion != 5)
            {
                foreach (WsPrepago.Folio folio in ticket.Folio)
                {

                    DataRow drCanasta = dtCanasta.NewRow();
                    drCanasta["SKU"] = folio.SKU.ToString();
                    try
                    {
                        drCanasta["Descripcion"] = folio.descripcionSKU.ToString();
                    }
                    catch
                    {
                        drCanasta["Descripcion"] = "";
                    }
                    //if (cmbCadena.SelectedValue == "1") //locatel, se invoca el WS
                    if (Session["IDCadena"].ToString()  == "1") //locatel, se invoca el WS
                    {
                        //Obtener el numero que se enviaria al WS (Sucursal)
                        
                        DataSet DSSucursal;
                        //DSSucursal = objConsultaDatos.DatosCatalogo("SucursalLocatel", cmbSucursal.SelectedValue.ToString());
                        DSSucursal = objConsultaDatos.DatosCatalogo("SucursalLocatel", Session["IDSucursal"].ToString() );
                        if (DSSucursal.Tables[0].Rows.Count > 0)
                        {
                            strIDSucLocatel = DSSucursal.Tables[0].Rows[0]["strDescripcion"].ToString(); 
                        }
                        else
                        {
                            strIDSucLocatel = "A001";
                        }
                        DSSucursal.Dispose();  

                        //Obtener el numero que se enviaria al WS (SKU)
                        DataSet DSSKU;
                        DSSKU = objConsultaDatos.DatosCatalogo("ProductoLocatel", drCanasta["SKU"].ToString());
                        if (DSSKU.Tables[0].Rows.Count > 0)
                        {
                            strIDSKULocatel = DSSKU.Tables[0].Rows[0]["strDescripcion"].ToString(); 
                        }
                        else
                        {
                           strIDSKULocatel = drCanasta["SKU"].ToString();
                        }
                        DSSKU.Dispose();  

                        //strIDSucLocatel = "A001";
                        //strIDSKULocatel = "";

                        decInventarioDisponible = fnListarInventario(strIDSucLocatel, strIDSKULocatel);
                        intInventarioDisponible = (int)decInventarioDisponible;
                        if (intInventarioDisponible < 0)
                        {
                            intInventarioDisponible = 0;
                        }

                    }
                    else   //todas las demas, se iguala el inventario a lo que se manda de beneficio
                    {
                        intInventarioDisponible = int.Parse(folio.Beneficios.ToString());
                    }
                    //drCanasta["Compras"] = folio.Compras.ToString();
                    if (intInventarioDisponible >= decimal.Parse(folio.Beneficios.ToString()))
                    {
                        drCanasta["Beneficios"] = folio.Beneficios.ToString();
                        drCanasta["Disponible"] = intInventarioDisponible;
                    }
                    else
                    {
                        drCanasta["Beneficios"] = intInventarioDisponible;
                        drCanasta["Disponible"] = intInventarioDisponible;
                    }

                    //drCanasta["Sugeridos"] = folio.Sugeridos.ToString();
                    dtCanasta.Rows.Add(drCanasta);
                }

                //btnCerrar.Enabled = true;
                //btnCerrar.Visible = true;
                btnCerrar.Enabled = false;
                btnCerrar.Visible = false;
                chkConfirma.Visible = true;  
                btnCancelar.Visible = true;
                txtCotizacion.Text = ticket.CotizacionId;
                txtTarjetaC.Text = ticket.Tarjeta;
                txtCotizacionCC.Text = ticket.CotizacionId;
                txtTarjetaCC.Text = ticket.Tarjeta;
            }
            else
            {
                btnCerrar.Enabled = false;
                btnCerrar.Visible = false;
                chkConfirma.Visible = false;
                btnCancelar.Visible = false;
                txtCotizacion.Text = "";
                txtTarjetaC.Text = "";
                txtCotizacionCC.Text = "";
                txtTarjetaCC.Text = "";
            }

            grdBeneficios.DataSource = dtCanasta.DefaultView;
            grdBeneficios.DataBind();
            Panel3.BorderColor = System.Drawing.Color.LightSteelBlue;
            Panel3.BorderStyle = System.Web.UI.WebControls.BorderStyle.Double;

            foreach (GridViewRow gvr in grdBeneficios.Rows)
            {
                TextBox txtCantidad = (TextBox)(gvr.Cells[0].FindControl("txtCantidad"));
                txtCantidad.Text = gvr.Cells[2].Text;
            }
            
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            string strIDSucLocatel = "";
            string strIDSKULocatel = "";
            string strSKUSSinInventario = "";

            if (Session["PuedeGuardar"].ToString() == "0")
            {
                Mensajes("El nivel de seguridad no Permite Guardar Información");
                btnCerrar.Enabled = false; 
                return;
            }

            if ((txtTicket.Text.Trim() != "") || (grdCanasta.Rows.Count>0 ))
            {
                if (cmbCadena.Text == "00")
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Seleccione la Cadena";
                    return;
                }
                if (cmbSucursal.Text == "00" || cmbSucursal.Text == "")
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Seleccione la Sucursal";
                    return;
                }
                if (txtUsuario.Text.Trim() == "")
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Ingrese el usuario del Ticket";
                    return;
                }

                if (System.DateTime.Today < System.DateTime.Parse(txtFechaTicket.Text))
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "La fecha del ticket no puede ser posterior a la fecha actual.";
                    return;
                }
                if (System.DateTime.Parse(txtFechaTicket.Text) < System.DateTime.Parse("2011-04-11"))
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No se permite registrar tickets con fecha anterior a 2011-04-11.";
                    return;
                }
                if ((txtTicket.Text == "") || (txtTicket.Text.Length < 4))
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Por favor capture el numero de ticket";
                    return;
                }
            }

            int i;
            int intDisponible = 0;
            int intBeneficios = 0;
            int intEntregar = 0;
            int intEntregarTotal = 0;
            int intBeneficiosTotal = 0;
            bool boolCantidadValida = true;
            MensajeLocatel tmpWSLocatel;
            string tmpMensajeLocatel="";
            string tmpTipoErrorLocatel = "";
            int tmpNoMensajeLocatel = 0;
            string tmpTipoMensajeLocatel = "";
            string[,] arrayTicket;
            arrayTicket = new string[grdBeneficios.Rows.Count +1 , 7];

            //validar que no se tengan entregas negativas
            for ( i=0; i<=grdBeneficios.Rows.Count-1;i++  )
            {
                grdBeneficios.EditIndex = i;
                intDisponible = int.Parse (grdBeneficios.Rows[i].Cells[1].Text);
                intBeneficios = int.Parse (grdBeneficios.Rows[i].Cells[2].Text);
                //String texto = (TextBox)grdBeneficios.Rows[i].FindControl("txtCantidad") ;
                String texto = ((TextBox)grdBeneficios.Rows[i].FindControl("txtCantidad")).Text ; 
                intEntregar = int.Parse(texto);    // int.Parse (grdBeneficios.Rows[i].Cells[3].Text);
                intEntregarTotal += intEntregar;
                intBeneficiosTotal += intBeneficios;
                if (intEntregar > intBeneficios || intEntregar < 0 || intEntregar > intDisponible)
                {
                    string outputstring = "La cantidad a entregar no es válida, Verifique!";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
                    boolCantidadValida = false; 
                }
            }

                if (!boolCantidadValida)
                {
                    string outputstring = "La cantidad a entregar no es válida, Verifique!";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
                }
                else
                {
                    lblMensaje.Visible = false;
                    WsPrepago.Token token = new WsPrepago.Token();
                    WsPrepago.Comprobante comprobante = new WsPrepago.Comprobante();
                    WsPrepago.WsEcardPrePago ejecuta = new WsPrepago.WsEcardPrePago();

                    token.CotizacionId = txtCotizacion.Text;
                    token.Tarjeta = txtTarjetaC.Text;

                    //dar de baja del inventario de LOCATEL
                    string SKU;
                    Session["MensajeLocatel"] = "";
                    //LLenar el Encabezado del Ticket
                    arrayTicket[0, 0] = "";
                    arrayTicket[0, 1] = "SKU";
                    arrayTicket[0, 2] = "Beneficios a Entregar";
                    arrayTicket[0, 3] = "Mensaje";
                    arrayTicket[0, 4] = "Mensaje SAP";
                    if (Session["IDCadena"].ToString()  == "1") //locatel, se invoca el WS
                    {
                        for (i = 0; i <= grdBeneficios.Rows.Count - 1; i++)
                        {
                            
                            grdBeneficios.EditIndex = i;
                            SKU = grdBeneficios.Rows[i].Cells[5].Text;
                            String texto = ((TextBox)grdBeneficios.Rows[i].FindControl("txtCantidad")).Text;
                            intEntregar = int.Parse(texto);
                            //Pasarlo a un array que servira como ticket
                            arrayTicket[i + 1, 1] = grdBeneficios.Rows[i].Cells[0].Text;  //producto
                            arrayTicket[i+1,2] = intEntregar.ToString ();   //Por entregar en este ticket
                            if (intEntregar > 0)
                            {
                                //Obtener el numero que se enviaria al WS (Sucursal)

                                DataSet DSSucursal;
                                //DSSucursal = objConsultaDatos.DatosCatalogo("SucursalLocatel", cmbSucursal.SelectedValue.ToString());
                                DSSucursal = objConsultaDatos.DatosCatalogo("SucursalLocatel", Session["IDSucursal"].ToString());
                                if (DSSucursal.Tables[0].Rows.Count > 0)
                                {
                                    strIDSucLocatel = DSSucursal.Tables[0].Rows[0]["strDescripcion"].ToString();
                                }
                                else
                                {
                                    strIDSucLocatel = "X001";
                                }
                                DSSucursal.Dispose();

                                //Obtener el numero que se enviaria al WS (SKU)
                                DataSet DSSKU;
                                DSSKU = objConsultaDatos.DatosCatalogo("ProductoLocatel", SKU);
                                if (DSSKU.Tables[0].Rows.Count > 0)
                                {
                                    strIDSKULocatel = DSSKU.Tables[0].Rows[0]["strDescripcion"].ToString();
                                }
                                else
                                {
                                    strIDSKULocatel = SKU;
                                }
                                DSSKU.Dispose();

                                //Locatel no sirve
                                //strIDSucLocatel = "A001";
                                //strIDSKULocatel = "0";

                                Session["MensajeLocatel"] += strIDSucLocatel + ":" + strIDSKULocatel + " - ";

                                #region
                                //Parametrizar, si es el ambiente de desarrollo, no modificar el inventario de locatel
                                string strConexion = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
                                if (strConexion.Contains("eCardPfizerVenDESAx"))
                                {
                                    tmpMensajeLocatel = "Sitio de Prueba, Inventario no afectado";
                                    tmpTipoErrorLocatel = "E";
                                    tmpNoMensajeLocatel = 999;
                                    tmpTipoMensajeLocatel = "Local"; 
                                }
                                else
                                {
                                    tmpWSLocatel = fnObtenerInventario(strIDSucLocatel, strIDSKULocatel, intEntregar);
                                    tmpMensajeLocatel = tmpWSLocatel.Mensaje;
                                    tmpTipoErrorLocatel = tmpWSLocatel.Tipoerror;
                                    tmpNoMensajeLocatel = tmpWSLocatel.NoMensaje;
                                    tmpTipoMensajeLocatel = tmpWSLocatel.TipoMensaje; 
                                }
                                Session["MensajeLocatel"] += tmpMensajeLocatel + Environment.NewLine; ;
                                Session["MensajeLocatelTec"] += " (MsgNo." + tmpNoMensajeLocatel + "*" + tmpTipoMensajeLocatel + "*" + tmpTipoErrorLocatel + ")" + Environment.NewLine; ;
                                #endregion
                                arrayTicket[i + 1, 3] = "TipoMsg: " + tmpTipoErrorLocatel;
                                //Validacion por si algun producto no entrego beneficios aun consultado el WS
                                if (!tmpTipoErrorLocatel.Contains("S"))
                                {
                                    arrayTicket[i + 1, 0] = "*";
                                    arrayTicket[i + 1, 2] = "0";
                                    arrayTicket[i + 1, 3] = "La consulta de inventario no está disponible en este momento." + strIDSKULocatel.ToString();
                                    arrayTicket[i + 1, 4] = "(" +tmpNoMensajeLocatel+ "|" + tmpTipoMensajeLocatel + ")" + tmpMensajeLocatel + " Por favor comuníquese al centro de contacto Locatel a través del 0501 – 5622835 ó contacto@locatelve.com";

                                    //Cambiar el total a entregar ya que se reporto sin inventario
                                    TextBox txtSinBen = ((TextBox)grdBeneficios.Rows[i].FindControl("txtCantidad"));
                                    txtSinBen.Text = "0";
                                }
                                else
                                {
                                    arrayTicket[i + 1, 4] = tmpMensajeLocatel + " (MsgNo." + tmpNoMensajeLocatel + "*" + tmpTipoMensajeLocatel + "*" + tmpTipoErrorLocatel + ")";
                                }
                            }
                            else  //cantidad =0
                            {
                                arrayTicket[i+1,3] = "Sin Beneficios";
                                arrayTicket[i+1,4] = "";
                            }
                        }
                    }
                    else  //otras cadenas
                    {
                        for (i = 0; i <= grdBeneficios.Rows.Count - 1; i++)
                        {
                            grdBeneficios.EditIndex = i;
                            SKU = grdBeneficios.Rows[i].Cells[0].Text;
                            String texto = ((TextBox)grdBeneficios.Rows[i].FindControl("txtCantidad")).Text;
                            intEntregar = int.Parse(texto);
                            //Pasarlo a un array que servira como ticket
                            arrayTicket[i + 1, 1] = grdBeneficios.Rows[i].Cells[0].Text;
                            arrayTicket[i + 1, 2] = intEntregar.ToString();
                            arrayTicket[i + 1, 3] = "Beneficio";
                            arrayTicket[i + 1, 4] = "";
                            arrayTicket[i + 1, 5] = "";
                        }
                    }
                    //objDataset = objTransaccion.ActualizarBeneficiosCotizacion(txtCotizacion.Text, txtTarjetaC.Text, xml);
                    //Se Cierra la transaccion, se guardan los datos de validacion de locatel
                    string xml = fnGenerarXMLBeneficios();
                    //Validar que si el mensaje que regresa locatel contiene "No hay stock disponible para xxxxxxxxxx"
                    objDataset = objTransaccion.CerrarCotizacion(txtCotizacion.Text, txtTarjetaC.Text, xml);

                    //inhabilitar por si presiona 2 veces el mismo boton
                    btnCerrar.Enabled = false;
                    Session["Ticket"] = arrayTicket;
                    Session["MensajeCierreCotizacion"] = objDataset.Tables[0].Rows[0][1].ToString();
                    Session["NombrePaciente"] = objDataset.Tables[0].Rows[0][2].ToString();
                    Session["Telefono"] = objDataset.Tables[0].Rows[0][3].ToString();
                    Session["Entregados"] = intEntregarTotal;
                    //Session["Entregados"] = Session["Entregados"].ToString() + ", " + cantidad;
                    Session["Restantes"] = intBeneficiosTotal - intEntregarTotal;
                    Session["TarjetaUltimoTicket"] = txtTarjetaC.Text;
                    Session["UltimoTicket"] = txtTicket.Text;
                    //Session["Descripcion"] = descripcion;
                    txtCotizacion.Text = ""; 
                    Response.Redirect("TerminaCompra.aspx");
                 }
            //}
           
        }

        protected String fnGenerarXMLCompra()
        {
            int i;
            int intEntregar = 0;
            
            try
            {
                string CadenaXML;

                CadenaXML = "<TicketXML>";
                for (i = 0; i <= grdBeneficios.Rows.Count - 1; i++)
                {
                    grdBeneficios.EditIndex = i;
                    CadenaXML += "<id>";
                    CadenaXML += "<SKU>" + grdBeneficios.Rows[i].Cells[5].Text + "</SKU>";
                    String texto = ((TextBox)grdBeneficios.Rows[i].FindControl("txtCantidad")).Text;
                    intEntregar = int.Parse(texto);
                    CadenaXML += "<Cantidad>" + intEntregar.ToString() + "</Cantidad>";
                    CadenaXML += "</id>";
                }
                CadenaXML += "</TicketXML>";

                return CadenaXML;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método ParsearInformacionCrearCompra", ex);
            }
        }

        protected String fnGenerarXMLBeneficios()
        {
            int i;
            int intEntregar = 0;
            try
            {
                string CadenaXML;
                string strFecha;
                CadenaXML = "<ListaBeneficios>";
                for (i = 0; i <= grdBeneficios.Rows.Count - 1; i++)
                {
                    grdBeneficios.EditIndex = i;
                    CadenaXML += "<id>";
                    CadenaXML += "<noTicket>" + txtTicket.Text + "</noTicket>";
                    strFecha = txtFechaTicket.Text.Substring(6,4);
                    strFecha += txtFechaTicket.Text.Substring(3, 2);
                    strFecha += txtFechaTicket.Text.Substring(0, 2);
                    CadenaXML += "<fechaTicket>" + strFecha + "</fechaTicket>";
                    CadenaXML += "<SKU>" + grdBeneficios.Rows[i].Cells[5].Text  + "</SKU>";
                    String texto = ((TextBox)grdBeneficios.Rows[i].FindControl("txtCantidad")).Text;
                    intEntregar = int.Parse(texto);    
                    CadenaXML += "<Cantidad>" + intEntregar.ToString()  + "</Cantidad>";
                    CadenaXML += "<MsgLocatel>" + Session["MensajeLocatel"] + "</MsgLocatel>";
                    CadenaXML += "<MsgLocatelTec>" + Session["MensajeLocatelTec"] + "</MsgLocatelTec>";
                    CadenaXML += "</id>";
                }
                CadenaXML += "</ListaBeneficios>";

                return CadenaXML;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método ParsearInformacionCerrarCompra", ex);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CapturaKit.aspx", true);
        }

        private decimal fnListarInventario(string strCentro, string strEAN)
        {
            try
            {
                //Produccion
                //string strServer = "webservices.locatelve.com:8002";  //Produccion
                //ZWS_COMPLIANCEService.ZWS_COMPLIANCE ws = new ZWS_COMPLIANCEService.ZWS_COMPLIANCE();  //Produccion
                //ws.Url = "http://" + strServer + "/sap/bc/srt/rfc/sap/zws_compliance/400/zws_compliance/zws_compliance";  //Produccion
                //ws.Credentials = new NetworkCredential("VEUSRRFC", "P0S06SAP");  //Produccion

                ////Pruebas
                //string strServer = "webservices.locatelve.com:8000"; //Desarrollo-Pruebas
                //ZWS_COMPLIANCEService.ZWS_COMPLIANCE ws = new ZWS_COMPLIANCEService.ZWS_COMPLIANCE();  //Desarrollo-Pruebas
                //ws.Url = "http://" + strServer + "/sap/bc/srt/rfc/sap/zws_compliance/400/zws_compliance/zws_compliance";  //Desarrollo-Pruebas
                //ws.Credentials = new NetworkCredential("VEUSRRFC", "loc99prd");  //Desarrollo-Pruebas

                //Obtener Parametros desde WEB.Config
                string strUsuario = ConfigurationSettings.AppSettings["UsuarioWSLocatel"].ToString();
                string strPwd = ConfigurationSettings.AppSettings["PasswordWSLocatel"].ToString();
                ZWS_COMPLIANCEService.ZWS_COMPLIANCE ws = new ZWS_COMPLIANCEService.ZWS_COMPLIANCE(); 
                ws.Url = ConfigurationSettings.AppSettings["URLWSLocatel"].ToString();
                ws.Credentials = new NetworkCredential(strUsuario, strPwd); 

                string strDetalle = "X";
                string strFecDesde = System.DateTime.Now.ToString("yyyy-MM-dd"); //"2011-01-17";
                string strFecHasta = System.DateTime.Now.ToString("yyyy-MM-dd");
                ZWS_COMPLIANCEService.ZrfcComplianceStocks parametros = new ZWS_COMPLIANCEService.ZrfcComplianceStocks();
                parametros.Centro = strCentro;
                parametros.Ean = strEAN;
                parametros.Detalle = strDetalle;
                parametros.FecDesde = strFecDesde;
                parametros.FecHasta = strFecHasta;
                parametros.DetalleMovs = new ZWS_COMPLIANCEService.ZrfcComplianceMovs[0];
                parametros.Mensajes = new ZWS_COMPLIANCEService.ZrfcMensajes[0];
                ZWS_COMPLIANCEService.ZrfcComplianceStocksResponse ret = ws.ZrfcComplianceStocks(parametros);
                //Response.Write("Tabla de mensajes:");
                //foreach (ZWS_COMPLIANCEService.ZrfcMensajes mensaje in ret.Mensajes)
                //{
                //    Response.Write(mensaje.Mensaje);
                //}
                //if (strDetalle.Equals("X"))
                //{
                //    Console.WriteLine("Detalle de movimientos:");
                return ret.StockCentro;
                //    foreach (ZWS_COMPLIANCEService.ZrfcComplianceMovs movs in ret.DetalleMovs)
                //    {
                //        Response.Write(movs.FechaRegistro);
                //        //Response.Write(movs.HoraRegistro);
                //        Response.Write(movs.TipoMov);
                //        Response.Write(movs.Cantidad);
                //        Response.Write(movs.Unidad);

                //    }
                //}
                //Console.Read();
            }
            catch (Exception ex)
            {
                //por algo no se pudo obtener resultado del WS
                lblMensaje.Visible = true;
                lblMensaje.Text = "La consulta de inventario no está disponible en este momento.  Por favor comuníquese al centro de contacto Locatel a través del 0501 – 5622835 ó contacto@locatelve.com";
                return 0;
            }

        }

        private MensajeLocatel fnObtenerInventario(string strCentro, string strEAN, int intCantidad)
        {
            MensajeLocatel Resultado= new MensajeLocatel(0,"","",0,"");

            //Produccion
            //string strServer = "webservices.locatelve.com:8002";  //Produccion
            //ZWS_COMPLIANCEService.ZWS_COMPLIANCE ws = new ZWS_COMPLIANCEService.ZWS_COMPLIANCE();  //Produccion
            //ws.Url = "http://" + strServer + "/sap/bc/srt/rfc/sap/zws_compliance/400/zws_compliance/zws_compliance";  //Produccion
            //ws.Credentials = new NetworkCredential("VEUSRRFC", "P0S06SAP");  //Produccion

            //Pruebas
            //string strServer = "webservices.locatelve.com:8000"; //Desarrollo-Pruebas
            //ZWS_COMPLIANCEService.ZWS_COMPLIANCE ws = new ZWS_COMPLIANCEService.ZWS_COMPLIANCE(); //Desarrollo-Pruebas
            //ws.Url = "http://" + strServer + "/sap/bc/srt/rfc/sap/zws_compliance/400/zws_compliance/zws_compliance"; //Desarrollo-Pruebas
            //ws.Credentials = new NetworkCredential("VEUSRRFC", "loc99prd"); //Desarrollo-Pruebas

            //Obtener Parametros desde WEB.Config
            string strUsuario = ConfigurationSettings.AppSettings["UsuarioWSLocatel"].ToString();
            string strPwd = ConfigurationSettings.AppSettings["PasswordWSLocatel"].ToString();
            ZWS_COMPLIANCEService.ZWS_COMPLIANCE ws = new ZWS_COMPLIANCEService.ZWS_COMPLIANCE(); 
            ws.Url = ConfigurationSettings.AppSettings["URLWSLocatel"].ToString();
            ws.Credentials = new NetworkCredential(strUsuario, strPwd); 

            string strmensaje = "";
            string strTipoError = "";
            int intnoMensaje =0;
            string strtipoMensaje ="";
            try
            {
                ZWS_COMPLIANCEService.ZrfcComplianceSalidas parametros = new ZWS_COMPLIANCEService.ZrfcComplianceSalidas();
                parametros.Centro = strCentro;
                parametros.Ean = strEAN;
                parametros.Cantidad = intCantidad;
                parametros.Mensajes = new ZWS_COMPLIANCEService.ZrfcMensajes[0];
                ZWS_COMPLIANCEService.ZrfcComplianceSalidasResponse ret = ws.ZrfcComplianceSalidas(parametros);
                foreach (ZWS_COMPLIANCEService.ZrfcMensajes mensaje in ret.Mensajes)
                {
                    strmensaje += mensaje.Message;
                    strTipoError = mensaje.Type;
                    intnoMensaje = int.Parse (mensaje.MsgNumb);
                    strtipoMensaje = mensaje.MsgClass; 
                }
                Resultado.Mensaje = strmensaje;
                Resultado.Cantidad = 0;
                Resultado.Tipoerror = strTipoError;
                Resultado.NoMensaje = intnoMensaje;
                Resultado.TipoMensaje = strtipoMensaje;
            }
            catch (Exception ex)
            {
                Resultado.Mensaje = ex.Message.ToString()  ;
                Resultado.Cantidad = 0;
                Resultado.Tipoerror = "E";
                Resultado.NoMensaje  = 0;
                Resultado.TipoMensaje = "Local";
            }
            return Resultado;
        }

        protected void chkConfirma_CheckedChanged(object sender, EventArgs e)
        {
            btnCerrar.Enabled = chkConfirma.Checked; 
            btnCerrar.Visible = chkConfirma.Checked; 
        }
    }
}

public class MensajeLocatel
{
    public int cantidad; 
    public String tipoerror;
    public String mensaje;
    public int nomensaje;
    public string tipomensaje;

    public MensajeLocatel(int cantidad, String tipoerror, String mensaje, int nomensaje, string tipomensaje)
    {
        this.cantidad = cantidad;
        this.tipoerror = tipoerror;
        this.mensaje = mensaje;
        this.nomensaje = nomensaje;
        this.tipomensaje = tipomensaje;
    }

    public int Cantidad
    {
        set { cantidad = value; }
        get { return cantidad; }
    }
    public string Tipoerror
    {
        set { tipoerror = value; }
        get { return tipoerror; }
    }
    public string Mensaje
    {
        set { mensaje = value; }
        get { return mensaje; }
    }
    public int NoMensaje
    {
        set { nomensaje = value; }
        get { return nomensaje; }
    }
    public string TipoMensaje
    {
        set { tipomensaje = value; }
        get { return tipomensaje; }
    }
} 

public class SkuMedicamento
{
    private string sku;
    private string descripcion;
    private string cantidad;

    public SkuMedicamento(string sku, string descripcion, string cantidad)
    {
        this.sku = sku;
        this.descripcion = descripcion;
        this.cantidad = cantidad;
    }

    public string Sku
    {
        set { sku = value; }
        get { return sku; }
    }

    public string Descripcion
    {
        set { descripcion = value; }
        get { return descripcion; }
    }

    public string Cantidad
    {
        set { cantidad = value; }
        get { return cantidad; }
    }
}
