using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Configuration;
using System.IO;
using Telerik.Web.UI;

namespace ORMOperacion
{
    public partial class MantenimientoCanjes : System.Web.UI.Page
    {
        csDataBase DataBase = new csDataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }

            if (!IsPostBack)
            {
                if (Session["participante_id"] != null)
                {
                    Master.Menu = "Canjes";
                    Master.Submenu = "Centro de canjes";

                    /* Deshabilita todos los validadores */
                    Master.CriterioBuqueda(false); // de la master
                    reqCelular.Enabled = false;
                    reqOperadora.Enabled = false;

                    csParticipanteComplemento p = Session["participante"] as csParticipanteComplemento;
                    csPremio pr = new csPremio();
                    pr.Programa = p.Programa;
                    ViewState["url_programa"] = pr.ConsultaURL();
                    CargaCategrias(p.Programa);
                }
                else
                {
                    Response.Redirect("busqueda.aspx", false);
                }
            }
        }

        #region Genericos
        protected void inicializaDDL(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("Seleccione", "0"));
            //agregar opcion a categorias de premio
            ddlCategoriaMX.Items.Add(new DropDownListItem("Seleccione", "0"));
        }

        protected void cargaOperadoras(string pais)
        {
            csCatalogo cat = new csCatalogo();
            cat.Country_code = pais;
            cat.Catalogo = "operadora";
            ddlOperadora.DataSource = cat.Consulta().DefaultView;
            ddlOperadora.DataBind();
            ddlOperadora.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        protected void guardaLlamada()
        {
            csLlamada llamada = new csLlamada();
            csParticipanteComplemento participante = new csParticipanteComplemento();
            llamada.IDParticipante = Session["participante_id"].ToString();
            llamada.IDUsuario = Membership.GetUser().ProviderUserKey.ToString();
            llamada.Descripcion = "Canje de premios";
            participante.ID = Session["participante_id"].ToString();
            participante.DatosParticipante();
            DataTable dtLlamada = llamada.ObtieneIdTipoLlamada("CANJE");
            if (dtLlamada.Rows.Count > 0)
            {
                DataRow drLlamada = dtLlamada.Rows[0];
                llamada.AgregaTipoLlamada(drLlamada["id"].ToString()); // Canje
            }
            if (participante.NombreCompleto.Trim().Length >= 50)
            {
                llamada.NombreLlama = participante.NombreCompleto.Trim().Substring(0, 50); // guarda hasta 50 caracteres
            }
            else
            {
                llamada.NombreLlama = participante.NombreCompleto.Trim();
            }
            DataTable dtParticipante = participante.ConsultaTelefono();
            if (dtParticipante.Rows.Count > 0)
            {
                DataRow drP = dtParticipante.Rows[0];
                string lada = drP["lada"].ToString();
                string telefono = drP["telefono"].ToString();
                llamada.Telefono = lada + " " + telefono;
            }
            else
                llamada.Telefono = "";
            //string country = participante.CountryCode2;
            //llamada.CountryCode = participante.CountryCode2;
            llamada.GuardaLlamada();
        }

        protected List<PremioCanje> ObtieneDetalleCanjes(csParticipante participante, string countryCode)
        {
            csHistoricoCanje h = new csHistoricoCanje();
            List<PremioCanje> premios = new List<PremioCanje>();
            switch (countryCode)
            {
                case "MX":
                    premios = h.ConsultaHistorico(participante.ID);
                    break;
                case "AR":
                    premios = h.ConsultaHistorico(participante.ID);
                    break;
                case "CO":
                    premios = h.ConsultaHistorico(participante.ID);
                    break;
                case "BR":
                    Master.MuestraMensaje("En construcción");
                    premios = h.ConsultaHistorico(participante.ID);
                    break;
            }
            return premios;
        }

        protected void BuscaPremios(string busqueda, string programa)
        {
            dgPremiosMX.DataSource = null;
            dgPremiosMX.DataBind();
            csPremio premios = new csPremio();
            premios.Programa = programa;
            DataTable dtPremios = premios.Busqueda(busqueda);
            if (dtPremios.Rows.Count > 0)
            {
                dgPremiosMX.DataSource = dtPremios;
                dgPremiosMX.DataBind();
            }
            else
            {
                Master.MuestraMensaje("No se encontraron premios con el criterio de búsqueda especificado.");
            }
        }

        protected void btnBuscar_Command(object sender, CommandEventArgs e)
        {
            BuscaPremios(txtBusquedaMX.Text.Trim(), (Session["participante"] as csParticipanteComplemento).Programa);
        }

        protected void imgPremios_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "detalle")
            {
                muestraDetalle(e.CommandArgument.ToString());
            }
        }

        protected void muestraDetalle(string premio_id)
        {
            csPremio premio = new csPremio(premio_id);
            premio.Consulta();
            //premio.ObtenDetalle();
            this.hidPremioID.Value = premio_id;
            this.lblDetalle.Text = premio.Descripcion.Length == 0 ? premio.Titulo : premio.Descripcion;
            this.lblDetalleLargo.Text = premio.DescripcionLarga.Length == 0 ? premio.DescripcionDetalle : premio.DescripcionLarga;
            this.lblIncluye.Text = premio.Incluye != null ? "<b>Incluye:</b> " + premio.Incluye : "";
            this.lblAdicional.Text = premio.Adicional != null ? "<b>Adicional:</b> " + premio.Adicional : "";
            this.imgDetalle.ImageUrl = (premio.URL == "")
                ? ViewState["url_programa"] + "images/premios/imagen-no-disponible.PNG"
                : ViewState["url_programa"] + premio.URL.Replace("images_premios_", "images/premios/");
            this.lblDetallePuntos.Text = premio.Puntos != "" ? int.Parse(premio.Puntos).ToString("N0") + " Km." : "Sin Km.";
            popDetallePremio.Show();
        }
        #endregion

        #region Mexico
        private void CargaCategrias(string programa)
        {
            csPremio pr = new csPremio();
            ddlCategoriaMX.DataSource = pr.Categorias(programa);
            ddlCategoriaMX.DataBind();
            DropDownListItem todos = new DropDownListItem();
            todos.Value = "0";
            todos.Text = "Todas las categorias";
            ddlCategoriaMX.Items.Insert(0, todos);
        }

        public void MuestraCarritoMX(string participante_id)
        {
            if (Session["carrito"] != null)
            {
                csCarritoComprasMX carrito = new csCarritoComprasMX();
                carrito.Carrito = Session["carrito"] as List<csPremioMX>;
                rptCarritoMX.DataSource = carrito.Carrito;
                rptCarritoMX.DataBind();
                //cargadireccionMX(participante_id);
                csParticipanteComplementoMX p = new csParticipanteComplementoMX(); // reemplaza lo anterior
                p.ID = participante_id;                                            // reemplaza lo anterior 
                p.DatosParticipante();                                             // reemplaza lo anterior
                cargadireccionParticipante(participante_id);                   // reemplaza lo anterior
                mvCarritoMX.SetActiveView(vCarritoMX);
            }
            else
            {
                csParticipanteComplementoMX p = new csParticipanteComplementoMX();
                p.ID = participante_id;
                lblSaldoInicioMX.Text = int.Parse(p.Saldo) == 0 ? "0" : int.Parse(p.Saldo).ToString("N0");
                mvCarritoMX.SetActiveView(vVacioMX);
            }
        }

        protected void cargadireccionMX(string participante_id)
        {
            controles.ucDireccion_MX dirParticipante = rptCarritoMX.Controls[rptCarritoMX.Controls.Count - 1].Controls[0].FindControl("dirParticipanteMX") as controles.ucDireccion_MX;
            dirParticipante.Participante_ID = participante_id;
            dirParticipante.TipoDireccion_ID = "4";// direccion de entrega = 4;
            dirParticipante.CargaDireccion();
        }

        protected void cargadireccionDistribuidora(string distribuidora_id)
        {
            if (rptCarritoMX.Controls.Count > 0)
            {
                controles.ucDireccionDistribuidor_MX dirDistribuidorMX = rptCarritoMX.Controls[rptCarritoMX.Controls.Count - 1].Controls[0].FindControl("dirDistribuidorMX") as controles.ucDireccionDistribuidor_MX;
                dirDistribuidorMX.Distribuidora_ID = distribuidora_id;
                dirDistribuidorMX.Participante_ID = Session["participante_id"].ToString();
                dirDistribuidorMX.CargaDireccion();
            }
        }

        protected void cargadireccionParticipante(string participante_id)
        {
            if (rptCarritoMX.Controls.Count > 0)
            {
                controles.ucDireccionDistribuidor_MX dirDistribuidorMX = rptCarritoMX.Controls[rptCarritoMX.Controls.Count - 1].Controls[0].FindControl("dirDistribuidorMX") as controles.ucDireccionDistribuidor_MX;
                dirDistribuidorMX.Participante_ID = participante_id;
                dirDistribuidorMX.CargaDireccion();
            }
        }

        protected void ddlCategoriaMX_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgPremiosMX.CurrentPageIndex = 0;
            llenaGridPremioMX(ddlCategoriaMX.SelectedItem.Value);
        }

        protected void llenaGridPremioMX(string categoria_id)
        {
            csPremio premio = new csPremio();
            premio.CategoriaID = categoria_id;
            premio.Programa = (Session["participante"] as csParticipanteComplemento).Programa;
            dgPremiosMX.DataSource = premio.PremiosCategoria().DefaultView;
            dgPremiosMX.DataBind();
            if (dgPremiosMX.Items.Count == 0 && ddlCategoriaMX.SelectedIndex > 0)
            {
                Master.MuestraMensaje("No se encontraron premios para esta categoría");
            }
        }

        protected void dgPremiosMX_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = e.Row.DataItem as DataRowView;
                if (row != null)
                {
                    // Si no se encontro la imagen
                    if (row.Row.ItemArray[5].ToString() == "")
                    {
                        Image img = e.Row.FindControl("imgPremioMX") as Image;
                        if (img != null)
                        {
                            img.ImageUrl = "/images/premios/imagen-no-disponible.PNG";
                        }
                    }
                    else
                    {
                        Image img = e.Row.FindControl("imgPremioMX") as Image;
                        if (img != null)
                        {
                            img.ImageUrl = ViewState["url_programa"].ToString() + row.Row.ItemArray[5].ToString().Replace("images_premios_", "images/premios/");
                        }
                    }
                }
            }
        }

        //protected void dgPremiosMX_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    dgPremiosMX.PageIndex = e.NewPageIndex;
        //    if (txtBusquedaMX.Text.Trim().Length > 0)
        //    {
        //        BuscaPremios(txtBusquedaMX.Text.Trim(), (Session["participante"] as csParticipanteComplemento).Programa);
        //    }
        //    else
        //    {
        //        llenaGridPremioMX(ddlCategoriaMX.SelectedItem.Value);
        //    }
        //}

        //protected void dgPremiosMX_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (Session["participante_id"] != null)
        //    {
        //        string premio_id = Convert.ToString(((LinkButton)sender).CommandArgument);
        //        switch (AgregarCarritoMX(premio_id))
        //        {
        //            case 0: Master.MuestraMensaje("Premio agregado correctamente.");
        //                break;
        //            case -1: Master.MuestraMensaje("Saldo insuficiente");
        //                break;
        //            case -2: Master.MuestraMensaje("Tarjeta Éxito por $200.000. Solo podrá canjear hasta $400.000 durante la vigencia del plan");
        //                break;
        //            case -3: csPremioMX _p = new csPremioMX(premio_id);
        //                reqCelular.Enabled = true;
        //                reqOperadora.Enabled = true;
        //                hidPremioID.Value = premio_id;
        //                _p.Consulta();
        //                lblPremioRecarga.Text = _p.Descripcion;
        //                txtCelular.Text = "";
        //                ddlOperadora.SelectedIndex = 0;
        //                popRecarga.Show();
        //                break;
        //            case -4: Master.MuestraMensaje("Recargas a celular. Solo podrá canjear hasta $100.000 durante la vigencia del plan");
        //                break;
        //            default: Master.MuestraMensaje("Ocurrió un error al agregar el premio, por favor intente nuevamente.");
        //                break;
        //        }
        //        MuestraCarritoMX(Session["participante_id"].ToString());
        //    }
        //    else
        //    {
        //        Session.Abandon();
        //        Session.Clear();
        //        Response.Redirect("Default.aspx", false);
        //    }
        //}

        protected int AgregarCarritoMX(string premio_id)
        {
            bool muestra_carrito = false;
            csParticipanteComplementoMX participante = new csParticipanteComplementoMX();
            participante.ID = Session["participante_id"].ToString();
            csCarritoComprasMX carrito = new csCarritoComprasMX();
            csPremioMX p = new csPremioMX(premio_id);
            p.Consulta();
            if (Session["carrito"] == null)
            {
                if (int.Parse(p.Puntos) <= int.Parse(participante.Saldo))
                {
                    muestra_carrito = true;
                    carrito.Agregar(new csPremioMX(premio_id, p.Descripcion, p.URL, p.Puntos, "1"));
                }
                else
                {
                    muestra_carrito = false;
                    return -1;
                }
            }
            else
            {
                List<csPremioMX> lista_premios = Session["carrito"] as List<csPremioMX>;
                carrito.Carrito = lista_premios;
                if (carrito.Puntos + int.Parse(p.Puntos) <= int.Parse(participante.Saldo))
                {
                    List<csPremioMX> p_tmp = carrito.Buscar(p);
                    if (p_tmp.Count == 0)
                    {
                        p.Cantidad = "1";
                        carrito.Agregar(p);
                    }
                    else
                    {
                        p.Cantidad = (p_tmp.Sum(___p => int.Parse(___p.Cantidad)) + 1).ToString();
                        carrito.Actualizar(p);
                    }
                }
                else
                    return -1;
                muestra_carrito = true;
            }
            if (muestra_carrito)
                Session["carrito"] = carrito.Carrito;
            rptCarritoMX.DataSource = carrito.Carrito;
            rptCarritoMX.DataBind();
            return 0;
        }

        protected void btnCanjearMX_Click(object sender, EventArgs e)
        {
            csParticipante p = new csParticipante();
            p.ID = Session["participante_id"].ToString();
            if (Session["carrito"] == null)
            {
                p.ActualizaSaldo();
                lblSaldoInicioMX.Text = int.Parse(p.SaldoMX).ToString("#,#");
                mvCarritoMX.SetActiveView(vVacioMX);
                Master.MuestraMensaje("El carrito está vacío");
                return;
            }
            CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
            CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();
            try
            {
                csCarritoComprasMX carrito = new csCarritoComprasMX();
                //controles_ucDireccion_MX dirParticipante = rptCarritoMX.Controls[rptCarritoMX.Controls.Count - 1].Controls[0].FindControl("dirParticipanteMX") as controles_ucDireccion_MX;
                //dirParticipante.Participante_ID = Session["participante_id"].ToString();
                //dirParticipante.TipoDireccion_ID = "4"; // direccion de entrega = 4;
                //dirParticipante.Usuario_ID = Membership.GetUser().ProviderUserKey.ToString();
                //dirParticipante.Modifica();
                carrito.ParticipanteID = Session["participante_id"].ToString();
                carrito.UsuarioID = Membership.GetUser().ProviderUserKey.ToString();
                carrito.TipoTransaccion = "CJE";
                carrito.CategoriaTransaccionID = "3";
                carrito.Carrito = Session["carrito"] as List<csPremioMX>;
                CallCenterDB.Entidades.RMS rms = carrito.Canjear((Session["participante"] as csParticipanteComplemento).Programa, int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
                if (rms.PedidoRMS != null)
                {
                    p.ActualizaSaldo();
                    p.DatosParticipante();
                    guardaLlamada();

                    mail.ToMail = envio.CorreoElectronico;
                    mail.ToName = envio.Remitente;
                    List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                    cliente.Add(mail);

                    string plantilla = Server.MapPath("plantillas/aviso_canje.html");
                    string html = "";
                    using (StreamReader sr = new StreamReader(plantilla))
                    {
                        html = sr.ReadToEnd();
                    }
                    html = html.Replace("@ESTILO", ConfigurationManager.AppSettings["estilos"]);
                    html = html.Replace("@PAIS", (Session["participante"] as csParticipanteComplemento).Programa);
                    string _datos = "<table>" +
                        "<tr><td width='80px'><b>Participante ID:</b></td><td>" + Session["participante_id"].ToString() + "</td></tr>" +
                        "<tr><td><b>Nombre:</b></td><td>" + p.NombreCompleto + "</td></tr>" +
                        "<tr><td><b>Clave:</b></td><td>" + p.Clave + "</td></tr>" +
                        "<tr><td><b>Distribuidora:</b></td><td>" + p.Distribuidora + "</td></tr></table>" +
                        "<p>Se generaron los siguientes canjes:</p>" +
                        "<table><tr><td><b>Folio</b></td><td><b>Premio</b></td><td><b>Km.</b></td></tr>";
                    string _canjes = "";
                    foreach (csPremioMX premio in carrito.CanjesRMS)
                    {
                        _canjes += "<tr><td align='left'>" + rms.Sucursal + "-" + premio.Folio +
                            "</td><td align='left'>" + premio.Descripcion + "<br/>" + premio.Observaciones +
                            "</td><td align='right'>" + int.Parse(premio.Puntos).ToString("N0");
                    }
                    _canjes += "</table>";
                    Datos oDatos = new Datos();
                    string _rms = "<p>Datos RMS:</p>";
                    _rms += "<b>Aplicación:</b> " + oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "nombreAplicacion") + "<br />";
                    _rms += "<b>Pedido LMS:</b> " + rms.PedidoLMS + "<br />";
                    _rms += "<b>Pedido RMS:</b> " + rms.PedidoRMS + "<br />";
                    _rms += "<b>Folios totales:</b> " + rms.FoliosTotales + "<br />";
                    _rms += "<b>Folios Correctos:</b> " + rms.FoliosCorrectos + "<br />";
                    _rms += "<b>Folios Erroneos:</b> " + rms.FoliosErroneos + "<br />";
                    _rms += "<b>Duplicados:</b> " + rms.Duplicados + "<br />";
                    _rms += "<b>Fuera de rango:</b> " + rms.FueraRango + "<br />";
                    _rms += "<b>Sin folio:</b> " + rms.SinFolio + "<br />";
                    _rms += "<b>Proveedores:</b> " + rms.Proveedores + "<br />";
                    _rms += "<b>Sucursal:</b> " + rms.Sucursal + "<br />";
                    _rms += "<b>Usuario ID:</b> " + Membership.GetUser().ProviderUserKey.ToString().ToUpper() + "<br />";
                    _rms += "<b>AUTH_USER:</b> " + Request.ServerVariables["AUTH_USER"].ToString() + "<br />";
                    _rms += "<b>REMOTE_HOST:</b> " + Request.ServerVariables["REMOTE_HOST"].ToString() + "<br />";
                    _rms += "<b>SERVER_PORT:</b> " + Request.ServerVariables["SERVER_PORT"].ToString() + "<br />";
                    string body = _datos + _canjes + _rms;
                    html = html.Replace("@MENSAJE", body);

                    CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, "Canje de premios " + (Session["participante"] as csParticipanteComplemento).Programa, html);

                    Session.Remove("carrito");
                    rptCarritoMX.DataSource = null;
                    rptCarritoMX.DataBind();
                    mvCarritoMX.SetActiveView(vVacioMX);
                    Master.MuestraMensaje("Se realizó el canje correctamente");
                    lblSaldoInicioMX.Text = int.Parse(p.SaldoMX).ToString("N0");
                }
                else
                {
                    Master.MuestraMensaje("Ocurrió un error al completar el canje. Intente nuevamente.");
                }
            }
            catch (Exception ex)
            {
                List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                mail.ToMail = "gustavo.sanchez@lms.com.mx";
                mail.ToName = "Gustavo Alberto Sanchez";
                string Subject = "Galenia Loyalty Program - Error en: " + Membership.ApplicationName;
                cliente.Add(mail);

                Datos oDatos = new Datos();
                Funciones oFunciones = new Funciones();
                string errMail = "Error en la aplicacion " + Membership.ApplicationName +
                        "<br/><br/>Fecha: " + DateTime.Now.ToString() +
                        "<br/><br/>Pagina:<br/>" + Request.Url.ToString() +
                        "<br/><br/>Usuario:<br/>" + Membership.GetUser().UserName +
                        "<br/><br/>Mensaje de error:<br/>" + ex.Message +
                        "<br/><br/>Mas detalle del error:<br/>" +
                        (ex.InnerException != null ? ex.InnerException.Message : "") +
                        "<br/><br/>Stack Trace:<br/>" + ex.StackTrace.ToString() +
                        "<br/><br/>Error Completo:<br/>" + ex.ToString();
                CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, errMail);
                Master.MuestraMensaje("<p>Ocurrió un error al completar el canje. Intente nuevamente.</p>");
            }
        }

        protected void btnCanjearGalenia_Click(object sender, EventArgs e)
        {
            csParticipante p = new csParticipante();
            p.ID = Session["participante_id"].ToString();
            if (Session["carrito"] == null)
            {
                p.ActualizaSaldo();
                lblSaldoInicioMX.Text = int.Parse(p.SaldoMX).ToString("#,#");
                mvCarritoMX.SetActiveView(vVacioMX);
                Master.MuestraMensaje("El carrito está vacío");
                return;
            }
            CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
            CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();
            try
            {
                csCarritoComprasMX carrito = new csCarritoComprasMX();
                //controles_ucDireccion_MX dirParticipante = rptCarritoMX.Controls[rptCarritoMX.Controls.Count - 1].Controls[0].FindControl("dirParticipanteMX") as controles_ucDireccion_MX;
                //dirParticipante.Participante_ID = Session["participante_id"].ToString();
                //dirParticipante.TipoDireccion_ID = "4"; // direccion de entrega = 4;
                //dirParticipante.Usuario_ID = Membership.GetUser().ProviderUserKey.ToString();
                //dirParticipante.Modifica();
                carrito.ParticipanteID = Session["participante_id"].ToString();
                carrito.UsuarioID = Membership.GetUser().ProviderUserKey.ToString();
                carrito.TipoTransaccion = "CJE";
                carrito.CategoriaTransaccionID = "3";
                carrito.Carrito = Session["carrito"] as List<csPremioMX>;
                CallCenterDB.Entidades.RMS rms = carrito.Canjear((Session["participante"] as csParticipanteComplemento).Programa, int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
                DateTime fechaSol = DateTime.Now;
                if (rms.PedidoRMS != null)
                {
                    p.ActualizaSaldo();
                    p.DatosParticipante();
                    guardaLlamada();

                    //mail.ToMail = envio.CorreoElectronico;
                    mail.ToMail = "gustavo.sanchez@lms.com.mx";
                    mail.ToName = envio.Remitente;
                    List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                    cliente.Add(mail);

                    string plantilla = Server.MapPath("/mailing/tables/notificacion_redencion.html");
                    string html = "";
                    using (StreamReader sr = new StreamReader(plantilla))
                    {
                        html = sr.ReadToEnd();
                    }

                    html = html.Replace("@Nombre", ((csParticipante)Session["participante"]).NombreCompleto);
                    html = html.Replace("@NumeroAutorizacion", carrito.Transaccion_id.ToString());

                    string _canjes = "";
                    foreach (csPremioMX premio in carrito.CanjesRMS)
                    {

                        _canjes += "<tr>" +
                            "<td><b>" + rms.Sucursal + "-" + premio.Folio.Replace(".00", "") + "</b></td>" +
                            "<td style="+"line-height:1"+"><b>" + premio.Descripcion + "</b></td>" +
                            "<td><b>" + int.Parse(premio.Puntos).ToString("N0") + "</b></td>" +
                            "<td style=" + "line-height:1" + "><b>" + fechaSol + "</b></td>" +
                            "</tr>";
                    }
                    html = html.Replace("@Canjes", _canjes);

                    CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, "Canje de premios " + (Session["participante"] as csParticipanteComplemento).Programa, html);

                    Session.Remove("carrito");
                    rptCarritoMX.DataSource = null;
                    rptCarritoMX.DataBind();
                    mvCarritoMX.SetActiveView(vVacioMX);
                    Master.MuestraMensaje("Se realizó el canje correctamente");
                    lblSaldoInicioMX.Text = int.Parse(p.SaldoMX).ToString("N0");
                }
                else
                {
                    Master.MuestraMensaje("Ocurrió un error al completar el canje. Intente nuevamente.");
                }
            }
            catch (Exception ex)
            {
                List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                mail.ToMail = "gustavo.sanchez@lms.com.mx";
                mail.ToName = "Gustavo Alberto Sanchez";
                string Subject = "Galenia Loyalty Program - Error en: " + Membership.ApplicationName;
                cliente.Add(mail);

                Datos oDatos = new Datos();
                Funciones oFunciones = new Funciones();
                string errMail = "Error en la aplicacion " + Membership.ApplicationName +
                        "<br/><br/>Fecha: " + DateTime.Now.ToString() +
                        "<br/><br/>Pagina:<br/>" + Request.Url.ToString() +
                        "<br/><br/>Usuario:<br/>" + Membership.GetUser().UserName +
                        "<br/><br/>Mensaje de error:<br/>" + ex.Message +
                        "<br/><br/>Mas detalle del error:<br/>" +
                        (ex.InnerException != null ? ex.InnerException.Message : "") +
                        "<br/><br/>Stack Trace:<br/>" + ex.StackTrace.ToString() +
                        "<br/><br/>Error Completo:<br/>" + ex.ToString();
                CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, errMail);
                Master.MuestraMensaje("<p>Ocurrió un error al completar el canje. Intente nuevamente.</p>");
            }
        }

        protected void rptCarritoMX_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (Session["carrito"] != null)
            {
                csParticipanteComplementoMX participante = new csParticipanteComplementoMX();
                participante.ID = Session["participante_id"].ToString();
                csCarritoComprasMX carrito = new csCarritoComprasMX();
                carrito.Carrito = Session["carrito"] as List<csPremioMX>;
                if (e.CommandArgument.ToString() != "") // Se puso para evitar una excepción sino se hizo correctamente el envio en RMS
                {
                    csPremioMX p = new csPremioMX(e.CommandArgument.ToString());
                    p.Consulta();
                    p.Observaciones = (e.Item.FindControl("lblObservacionesMX") as Label).Text;
                    switch (e.CommandName)
                    {
                        case "actualizar":
                            {
                                string cantidad = (e.Item.FindControl("txtCantidadMX") as TextBox).Text;
                                if (cantidad.Length == 0)
                                {
                                    rptCarritoMX.DataSource = carrito.Carrito;
                                    rptCarritoMX.DataBind();
                                    //cargadireccionMX(participante.ID);
                                    participante.DatosParticipante();                                     // reemplaza lo anterior                                     
                                    cargadireccionDistribuidora(participante.Distribuidora_ID);           // reemplaza lo anterior
                                    Master.MuestraMensaje("La cantidad es requerida.");
                                    break;
                                }
                                if (int.Parse(cantidad) <= 0)
                                {
                                    rptCarritoMX.DataSource = carrito.Carrito;
                                    rptCarritoMX.DataBind();
                                    //cargadireccionMX(participante.ID);
                                    participante.DatosParticipante();                                     // reemplaza lo anterior                                     
                                    cargadireccionDistribuidora(participante.Distribuidora_ID);           // reemplaza lo anterior
                                    Master.MuestraMensaje("La cantidad debe ser mayor a cero.");
                                    break;
                                }
                                if (carrito.PuntosExcepto(p) + (float.Parse(p.Puntos) * float.Parse(cantidad)) > float.Parse(participante.Saldo))
                                {
                                    rptCarritoMX.DataSource = carrito.Carrito;
                                    rptCarritoMX.DataBind();
                                    //cargadireccionMX(participante.ID);
                                    participante.DatosParticipante();                                     // reemplaza lo anterior                                     
                                    cargadireccionDistribuidora(participante.Distribuidora_ID);           // reemplaza lo anterior
                                    Master.MuestraMensaje("Saldo insuficiente.");
                                    break;
                                }
                                p.Cantidad = cantidad;
                                carrito.Actualizar(p);
                                Session["carrito"] = carrito.Carrito;
                                rptCarritoMX.DataSource = carrito.Carrito;
                                rptCarritoMX.DataBind();
                                //cargadireccionMX(participante.ID);
                                participante.DatosParticipante();                                     // reemplaza lo anterior                                     
                                cargadireccionDistribuidora(participante.Distribuidora_ID);           // reemplaza lo anterior
                                mvCarritoMX.SetActiveView(vCarritoMX);
                                break;
                            }
                        case "eliminar":
                            {
                                carrito.Eliminar(p);
                                if (carrito.Items > 0)
                                {
                                    Session["carrito"] = carrito.Carrito;
                                    rptCarritoMX.DataSource = carrito.Carrito;
                                    rptCarritoMX.DataBind();
                                    //cargadireccionMX(Session["participante_id"].ToString());
                                    participante.DatosParticipante();                                 // reemplaza lo anterior                                     
                                    cargadireccionDistribuidora(participante.Distribuidora_ID);       // reemplaza lo anterior
                                    mvCarritoMX.SetActiveView(vCarritoMX);
                                }
                                else
                                {
                                    Session["carrito"] = null;
                                    carrito.Carrito = null;
                                    rptCarritoMX.DataSource = carrito.Carrito;
                                    rptCarritoMX.DataBind();
                                    lblSaldoInicioMX.Text = int.Parse(participante.SaldoMX).ToString("#,#");
                                    mvCarritoMX.SetActiveView(vVacioMX);
                                    Master.MuestraMensaje("El carrito está vacío.");
                                }
                                break;
                            }
                    }
                }
            }
        }

        protected void rptCarritoMX_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                csPremioMX row = e.Item.DataItem as csPremioMX;
                if (row != null)
                {
                    // Calcula total de puntos por premio
                    int cantidad = int.Parse((e.Item.FindControl("txtCantidadMX") as TextBox).Text);
                    int puntos_uni = int.Parse(row.Puntos);
                    Label lblPuntosTotal = e.Item.FindControl("lblPuntosTotalMX") as Label;
                    lblPuntosTotal.Text = (cantidad * puntos_uni).ToString("#,#");
                    // Formato con separador de miles a los puntos
                    Label lblPuntos = e.Item.FindControl("lblPuntosMX") as Label;
                    lblPuntos.Text = int.Parse(row.Puntos).ToString("#,#");
                    // Si no se encontro la imagen
                    if (row.URL == "")
                    {
                        Image img = e.Item.FindControl("imgPremioMX") as Image;
                        if (img != null)
                            img.ImageUrl = ViewState["url_programa"].ToString() + "/images/premios/imagen-no-disponible.PNG";
                    }
                    else
                    {
                        Image img = e.Item.FindControl("imgPremioMX") as Image;
                        if (img != null)
                        {
                            img.ImageUrl = ViewState["url_programa"].ToString() + "/" + row.URL.Replace("images_premios_", "images/premios/");
                        }
                    }
                }
            }
            else if (e.Item.ItemType == ListItemType.Footer)
            {
                if (Session["carrito"] != null)
                {
                    csCarritoComprasMX carrito = new csCarritoComprasMX();
                    carrito.Carrito = Session["carrito"] as List<csPremioMX>;
                    Label lblPuntosTotal = e.Item.FindControl("lblPuntosTotalesMX") as Label;
                    if (lblPuntosTotal != null)
                        lblPuntosTotal.Text = carrito.Puntos.ToString("#,#");
                    Label lblPremiosTotal = e.Item.FindControl("lblPremiosTotalesMX") as Label;
                    if (lblPremiosTotal != null)
                        lblPremiosTotal.Text = carrito.Premios.ToString("#,#");
                    csParticipante participante = new csParticipante();
                    participante.ID = Session["participante_id"].ToString();
                    Label lblSaldo = e.Item.FindControl("lblSaldoMX") as Label;
                    if (lblSaldo != null)
                        lblSaldo.Text = (int.Parse(participante.SaldoMX) - carrito.Puntos).ToString("#,#");
                }
            }
        }

        protected void btnRecargaMX_Click(object sender, EventArgs e)
        {
            csParticipanteComplementoMX participante = new csParticipanteComplementoMX();
            participante.ID = Session["participante_id"].ToString();
            csPremioMX p = new csPremioMX(hidPremioID.Value);
            p.Consulta();
            p.Observaciones = "Celular: " + txtCelular.Text.Trim() + ". Operadora: " + ddlOperadora.SelectedItem.Text;
            csCarritoComprasMX carrito = new csCarritoComprasMX();
            if (Session["carrito"] == null)
            {
                if (int.Parse(p.Puntos) <= int.Parse(participante.Saldo))
                {
                    p.Cantidad = "1";
                    carrito.Agregar(p);
                    Session["carrito"] = carrito.Carrito;
                    Master.MuestraMensaje("Premio agregado correctamente");
                }
                else
                    Master.MuestraMensaje("Saldo insuficiente");
            }
            else
            {
                List<csPremioMX> lista_premios = Session["carrito"] as List<csPremioMX>;
                carrito.Carrito = lista_premios;
                if (carrito.Puntos + int.Parse(p.Puntos) <= int.Parse(participante.Saldo))
                {
                    List<csPremioMX> p_tmp = carrito.Buscar(p);
                    if (p_tmp.Count == 0)
                    {
                        p.Cantidad = "1";
                        carrito.Agregar(p);
                    }
                    else
                    {
                        p.Cantidad = (p_tmp.Sum(item => int.Parse(item.Cantidad)) + 1).ToString();
                        carrito.Actualizar(p);
                    }
                    Session["carrito"] = carrito.Carrito;
                    Master.MuestraMensaje("Premio agregado correctamente");
                }
                else
                    Master.MuestraMensaje("Saldo insuficiente");
            }
            MuestraCarritoMX(participante.ID);
        }
        #endregion

        protected void lnkAgregar_Click(object sender, EventArgs e)
        {
            if (Session["participante_id"] != null)
            {
                //string premio_id = Convert.ToString(((LinkButton)sender).CommandArgument);
                string premio_id = ((LinkButton)sender).CommandArgument;

                switch (AgregarCarritoMX(premio_id))
                {
                    case 0: Master.MuestraMensaje("Premio agregado correctamente.");
                        break;
                    case -1: Master.MuestraMensaje("Saldo insuficiente");
                        break;
                    case -2: Master.MuestraMensaje("Tarjeta Éxito por $200.000. Solo podrá canjear hasta $400.000 durante la vigencia del plan");
                        break;
                    case -3: csPremioMX _p = new csPremioMX(premio_id);
                        reqCelular.Enabled = true;
                        reqOperadora.Enabled = true;
                        hidPremioID.Value = premio_id;
                        _p.Consulta();
                        lblPremioRecarga.Text = _p.Descripcion;
                        txtCelular.Text = "";
                        ddlOperadora.SelectedIndex = 0;
                        popRecarga.Show();
                        break;
                    case -4: Master.MuestraMensaje("Recargas a celular. Solo podrá canjear hasta $100.000 durante la vigencia del plan");
                        break;
                    default: Master.MuestraMensaje("Ocurrió un error al agregar el premio, por favor intente nuevamente.");
                        break;
                }
                MuestraCarritoMX(Session["participante_id"].ToString());
            }
            else
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void dgPremiosMX_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            //dgPremiosMX.PageIndex = e.NewPageIndex;
            if (txtBusquedaMX.Text.Trim().Length > 0)
            {
                //BuscaPremios(txtBusquedaMX.Text.Trim(), (Session["participante"] as csParticipanteComplemento).Programa);
                dgPremiosMX.DataSource = null;
                //dgPremiosMX.DataBind();
                csPremio premios = new csPremio();
                premios.Programa = (Session["participante"] as csParticipanteComplemento).Programa;
                DataTable dtPremios = premios.Busqueda(txtBusquedaMX.Text.Trim());
                if (dtPremios.Rows.Count > 0)
                {
                    dgPremiosMX.DataSource = dtPremios;
                    //dgPremiosMX.DataBind();
                }
                else
                {
                    Master.MuestraMensaje("No se encontraron premios con el criterio de búsqueda especificado.");
                }
            }
            else
            {
                if (ddlCategoriaMX.SelectedItem != null)
                {
                    //llenaGridPremioMX(ddlCategoriaMX.SelectedItem.Value);
                    //limpia el grid y label de busqueda
                    //dgPremiosMX.DataSource = null;
                    //txtBusquedaMX.Text = "";

                    csPremio premio = new csPremio();
                    premio.CategoriaID = ddlCategoriaMX.SelectedItem.Value;
                    premio.Programa = (Session["participante"] as csParticipanteComplemento).Programa;
                    dgPremiosMX.DataSource = premio.PremiosCategoria().DefaultView;
                    //dgPremiosMX.DataBind();
                    if (dgPremiosMX.Items.Count == 0 && ddlCategoriaMX.SelectedIndex > 0)
                    {
                        Master.MuestraMensaje("No se encontraron premios para esta categoría");
                    }
                }
            }
        }

    }
}