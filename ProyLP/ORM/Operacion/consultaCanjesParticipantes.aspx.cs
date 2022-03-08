using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
namespace ORMOperacion
{
    public partial class consultaCanjesParticipantes : System.Web.UI.Page
    {
        csParticipanteComplemento participante;
        String countryCode;
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
                if (Session["participante_id"] != null && Session["participante"] != null)
                {
                    Master.Menu = "Participantes";
                    Master.Submenu = "Canjes";

                    csCountry country = new csCountry();
                    country.ObtienePrograma_Participante(Session["participante_id"].ToString());
                    countryCode = country.CountryCode2.ToUpper();
                    string participante_id = Session["participante_id"].ToString();
                    participante = new csParticipanteComplemento();
                    participante.ID = participante_id;
                    ObtieneDetalleCanjes(participante);
                    ObtieneDatosParticipante(participante);
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
        }

        protected void ObtieneDetalleCanjes(csParticipante participante)
        {
            csHistoricoCanje h = new csHistoricoCanje();
            List<PremioCanje> premios = new List<PremioCanje>();
            premios = h.ConsultaHistorico(participante.ID);

            lblRegistros.Text = premios.Count.ToString("N0") + " canje(s) encontrados";
            gvDetalleCanje.DataSource = premios;
            gvDetalleCanje.DataBind();
        }

        protected void ObtieneDatosParticipante(csParticipanteComplemento participante)
        {
            participante.DatosParticipante();
            lblNombreParticipante.Text = participante.RazoSocial.ToUpper();
            lblClaveParticipante.Text = participante.Clave.ToLower();
        }
        protected void btnCancela_Click(object sender, EventArgs e)
        {
            CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
            CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();

            string body = "<br />";
            string transaccion_premio_id = hidTransaccionPremio.Value;
            csRMS cancela = new csRMS(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
            Funciones oFunciones = new Funciones();
            Datos oDatos = new Datos();
            cancela.TransaccionPremioID = transaccion_premio_id;
            cancela.Comentario = txtComentarios.Text;
            cancela.ParticipanteID = Session["participante_id"].ToString();
            cancela.UsuarioID = Membership.GetUser().ProviderUserKey.ToString();

            string participante_id = Session["participante_id"].ToString();
            try
            {
                cancela.CancelaPedidoRMS();
                participante = new csParticipanteComplemento();
                participante.ID = participante_id;
                participante.ActualizaSaldo();
                ObtieneDetalleCanjes(participante);
                body += "Folio: " + cancela.Folio + "<br />";
                body += "Premio: " + lblPremio.Text + "<br />";
                body += "Comentarios: " + txtComentarios.Text + "<br />";
                body += "<br/><br/>Se canceló en RMS y se actualizó la BD.";

                mail.ToMail = "vsilvac@lms.com.mx";
                mail.ToName = "Victor Silva";
                List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                cliente.Add(mail);

                string Subject = "Loyalty World Call Center - Cancelación premio RMS";
                string Body = "Transaccion " + transaccion_premio_id + body;
                
                CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, Body);

                Master.MuestraMensaje("El premio se cancel&oacute; correctamente");
                return;
            }
            catch (Exception ex)
            {
                body += "Folio: " + cancela.Folio + "<br />";
                body += "Premio: " + lblPremio.Text + "<br />";
                body += "Comentarios: " + txtComentarios.Text + "<br />";

                string error = "<br/><b>Error:</b><br/>";
                error = ex.Message;
                if (ex.InnerException != null)
                {
                    error += ".<br/>" + ex.InnerException.Message;
                }
                mail.ToMail = "vsilvac@lms.com.mx";
                mail.ToName = "Victor Silva";
                List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                cliente.Add(mail);

                string Subject = "Loyalty World Call Center - Error al generar cancelación RMS";
                string Body = "Transaccion " + transaccion_premio_id + ". " + body + error;
                CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, Body);

                Master.MuestraMensaje("Ocurri&oacute; un error al cancelar el premio. Consulte con el &aacute;rea de Sistemas.");
            }
            participante = new csParticipanteComplemento();
            participante.ID = participante_id;
            ObtieneDetalleCanjes(participante);
        }

        protected void btnGarantia_Click(object sender, EventArgs e)
        {
            CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
            CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();

            string body = "<br />";
            string transaccion_premio_id = hidTransaccionPremio.Value;
            csRMS cancela = new csRMS(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
            Funciones oFunciones = new Funciones();
            Datos oDatos = new Datos();
            cancela.TransaccionPremioID = transaccion_premio_id;
            cancela.Comentario = txtComentarios.Text;
            string participante_id = Session["participante_id"].ToString();
            try
            {
                cancela.GarantiaPedidoRMS();
                participante = new csParticipanteComplemento();
                participante.ID = participante_id;
                participante.ActualizaSaldo();
                ObtieneDetalleCanjes(participante);
                body += "Folio: " + cancela.Folio + "<br />";
                body += "Premio: " + lblPremio.Text + "<br />";
                body += "Comentarios: " + txtComentarios.Text + "<br />";
                
                mail.ToMail = "vsilvac@lms.com.mx";
                mail.ToName = "Victor Silva";
                List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                cliente.Add(mail);

                string Subject = "Loyalty World Call Center - Garantía premio RMS";
                string Body = "Transaccion " + transaccion_premio_id + body;
                CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, Body);

                Master.MuestraMensaje("Se gener&oacute; la garant&iacute;a correctamente");
                return;
            }
            catch (Exception ex)
            {
                body += "Folio: " + cancela.Folio + "<br />";
                body += "Premio: " + lblPremio.Text + "<br />";
                body += "Comentarios: " + txtComentarios.Text + "<br />";

                string error = "<br/><b>Error:</b><br/>";
                error = ex.Message;
                if (ex.InnerException != null)
                {
                    error += ".<br/>" + ex.InnerException.Message;
                }
                mail.ToMail = "vsilvac@lms.com.mx";
                mail.ToName = "Victor Silva";
                List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                cliente.Add(mail);

                string Subject = "Loyalty World Call Center - Error al generar Garantía premio RMS";
                string Body = "Transaccion " + transaccion_premio_id + body + error;
                CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, Body);

                Master.MuestraMensaje("Ocurri&oacute; un error al generar la garant&iacute;a. Consulte con el &aacute;rea de Sistemas");
            }
            participante = new csParticipanteComplemento();
            participante.ID = participante_id;
            ObtieneDetalleCanjes(participante);
        }

        protected void btnNotas_Click(object sender, EventArgs e)
        {
            string transaccion_premio_id = hidTransaccionPremio.Value;
            csHistoricoCanje historico = new csHistoricoCanje();
            switch (countryCode)
            {
                case "AR":
                    historico.ActualizaObservaciones(transaccion_premio_id, txtComentarios.Text);
                    break;
                case "CO":
                    historico.ActualizaObservaciones(transaccion_premio_id, txtComentarios.Text);
                    break;
                case "BR":
                    Master.MuestraMensaje("En proceso de contruccion");
                    historico.ActualizaObservaciones(transaccion_premio_id, txtComentarios.Text);
                    break;
                case "MX":
                    historico.ActualizaObservaciones(transaccion_premio_id, txtComentarios.Text);
                    break;
            }

            string participante_id = Session["participante_id"].ToString();
            participante = new csParticipanteComplemento();
            participante.ID = participante_id;
            ObtieneDetalleCanjes(participante);
            Master.MuestraMensaje("Se gener&oacute; la actualización de nota correctamente");
            //return;
        }

        protected void gvDetalleCanje_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            PremioCanje drv = e.Row.DataItem as PremioCanje;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (drv != null)
                {
                    string status = drv.Status.ToLower();
                    if (status == "entregado") // Entregado
                        e.Row.Cells[6].Text = ""; // Cancelado

                    if (status == "cancelado") // Cancelado
                    {
                        e.Row.Cells[6].Text = ""; // Cancelado
                        e.Row.Cells[7].Text = ""; // Garantia
                    }

                    if (status == "garantia") // Si está en garantía, la deshabilita
                        e.Row.Cells[7].Text = ""; // Garantia

                    if (!String.IsNullOrEmpty(drv.Observaciones) && drv.Observaciones.ToLower() != "canje")
                    {
                        LinkButton lnkNotas = e.Row.FindControl("lnkNotas") as LinkButton;
                        lnkNotas.Attributes.Add("rel", "htmltooltip");

                        TableCell tbc = new TableCell();
                        Literal lit = new Literal();
                        lit.Text = "<div class='htmltooltip'>" + drv.Observaciones + "</div>";
                        tbc.Controls.Add(lit);
                        e.Row.Controls.Add(tbc);
                    }
                }
            }
        }

        //protected void gvDetalleCanje_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvDetalleCanje.PageIndex = e.NewPageIndex;
        //    string participante_id = Session["participante_id"].ToString();
        //    participante = new csParticipanteComplemento();
        //    participante.ID = participante_id;
        //    ObtieneDetalleCanjes(participante);
        //}

        protected void gvDetalleCanje_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "cancelar":
                    {
                        try
                        {
                            Boolean bCancela = true;
                            string transaccion_premio_id = e.CommandArgument.ToString();
                            hidTransaccionPremio.Value = transaccion_premio_id;
                            participante = new csParticipanteComplemento();
                            DataTable dtPremio = new DataTable();
                            // Valida el periodo de Cancelación de CO                       
                            // si no es administrador no permite cancelar después de 24 horas
                            if (!Roles.IsUserInRole("administrador"))
                            {
                                participante.ObtieneDiasPlazoCancelar(transaccion_premio_id);
                                if (Convert.ToInt16(participante.DiasCancelaCO) > 1) // no más de 24 horas
                                    bCancela = false;
                            }
                            //
                            if (bCancela)
                                dtPremio = participante.DetallePremioCO(transaccion_premio_id);
                            else
                                Master.MuestraMensaje("El periodo para realizar una cancelación ha terminado.");
                            if (dtPremio.Rows.Count > 0)
                            {
                                DataRow drPremio = dtPremio.Rows[0];
                                lblPremio.Text = drPremio["descripcion"].ToString();
                                lblPuntos.Text = drPremio["puntos"].ToString();
                                lblTituloOperacion.Text = "Cancelaci&oacute;n de premio";
                                txtComentarios.Text = "";
                            }
                            if (bCancela)
                            {
                                mvOperacion.SetActiveView(vCancela);
                                popOperacion.Show();
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                        break;
                    }
                case "garantia":
                    {
                        try
                        {
                            Boolean bGarantia = true;
                            string transaccion_premio_id = e.CommandArgument.ToString();
                            hidTransaccionPremio.Value = transaccion_premio_id;
                            participante = new csParticipanteComplemento();
                            DataTable dtPremio = new DataTable();
                            // Valida el periodo de Garantia de CO     
                            // la fecha de entrega no debe ser más de 72 horas
                            csRMS rms = new csRMS(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
                            rms.TransaccionPremioID = transaccion_premio_id;
                            csRMS.Pedido pedido = rms.ConsultaPedidoRMS();
                            if (pedido.FechaEntrega != null)
                            {
                                participante.ObtieneDiasPlazoGarantia(Convert.ToDateTime(pedido.FechaEntrega));
                                if (Convert.ToInt16(participante.DiasGarantiaCO) > 3) // no más de 72 horas
                                    bGarantia = false;
                                if (bGarantia)
                                    dtPremio = participante.DetallePremio(transaccion_premio_id);
                                else
                                    Master.MuestraMensaje("El periodo para realizar una garantía ha terminado.");
                            }
                            else
                            {
                                bGarantia = false;
                                Master.MuestraMensaje("Fecha de entrega nula en RMS.");
                            }

                            if (dtPremio.Rows.Count > 0)
                            {
                                DataRow drPremio = dtPremio.Rows[0];
                                lblPremio.Text = drPremio["premio"].ToString();
                                lblPuntos.Text = drPremio["puntos"].ToString();
                                lblTituloOperacion.Text = "Garant&iacute;a de premio";
                                txtComentarios.Text = "";
                            }
                            if (bGarantia)
                            {
                                mvOperacion.SetActiveView(vGarantia);
                                popOperacion.Show();
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                        break;
                    }
                case "rms":
                    {
                        try
                        {
                            borraDetalle();
                            csRMS rms = new csRMS(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
                            rms.TransaccionPremioID = e.CommandArgument.ToString();
                            csRMS.Pedido pedido = rms.ConsultaPedidoRMS();
                            lblPedidoRMS.Text = pedido.PedidoRMS;
                            lblPedidoLMS.Text = pedido.PedidoLMS;
                            lblFolio.Text = pedido.Folio;
                            lblDistribuidora.Text = pedido.Distribuidora;
                            lblRuta.Text = pedido.Ruta;
                            lblSocio.Text = pedido.Socio;
                            lblPropietario.Text = pedido.Propietario;
                            lblRazonSocial.Text = pedido.RazonSocial;
                            lblCalle.Text = pedido.Calle;
                            lblEntreCalle.Text = pedido.EntreCalle;
                            lblYCalle.Text = pedido.YCalle;
                            lblColonia.Text = pedido.Colonia;
                            lblMunicipio.Text = pedido.Municipio;
                            lblCiudad.Text = pedido.Ciudad;
                            lblEstado.Text = pedido.Estado;
                            lblCP.Text = pedido.CP;
                            lblTelefono.Text = pedido.Telefono;
                            lblClave.Text = pedido.Clave;
                            lblPremioDetalle.Text = pedido.Premio;
                            lblCantidad.Text = pedido.Cantidad;
                            lblFechaSol.Text = pedido.FechaSolicitud;
                            lblFechaProm.Text = pedido.FechaPromesa;
                            lblFechaStatus.Text = pedido.FechaStatus;
                            lblMensajeria.Text = pedido.Mensajeria;
                            lblGuia.Text = pedido.Guia;
                            lblFechaEmb.Text = pedido.FechaEmbarque;
                            lblOrigen.Text = pedido.Origen;
                            lblDestino.Text = pedido.Destino;
                            lblRecibidoPor.Text = pedido.RecibidoPor;
                            lblStatus.Text = pedido.Status;
                            lblFechaEntrega.Text = pedido.FechaEntrega;
                            lblObservaciones.Text = pedido.Observaciones;
                            lblProveedor.Text = pedido.Proveedor;
                            lblTipoEnvio.Text = pedido.TipoEnvio;
                            lblPrioridad.Text = pedido.Prioridad;
                            lblComentario.Text = pedido.Comentario;
                            lblClaveExtra.Text = pedido.ClaveExtra;
                            lblTipoDireccion.Text = pedido.TipoDireccion;
                            lblReferencias.Text = pedido.Referencias;
                            popDetalle.Show();
                        }
                        catch (Exception er)
                        {
                            Master.MuestraMensaje("Ocurrió un error al consultar la información en RMS.<br/>Intente nuevamente");
                        }
                        break;
                    }
                case "notas":
                    try
                    {
                        string transaccion_premio_id = e.CommandArgument.ToString();
                        hidTransaccionPremio.Value = transaccion_premio_id;
                        csHistoricoCanje historial = new csHistoricoCanje();
                        List<PremioCanje> canjes = new List<PremioCanje>();
                        canjes = historial.DetallePremioHistorial(transaccion_premio_id);
                        if (canjes.Count > 0)
                        {
                            PremioCanje _p = canjes[0];
                            lblPremio.Text = _p.Premio;
                            lblPuntos.Text = _p.Puntos.ToString("N0");
                            lblTituloOperacion.Text = "Notas de la entrega";
                            txtComentarios.Text = _p.Observaciones;
                        }
                        mvOperacion.SetActiveView(vNotas);
                        popOperacion.Show();
                    }
                    catch (Exception ex)
                    {
                    }
                    break;
            }
            string participante_id = Session["participante_id"].ToString();
            participante = new csParticipanteComplemento();
            participante.ID = participante_id;
            ObtieneDetalleCanjes(participante);
        }

        protected void borraDetalle()
        {
            lblPedidoRMS.Text = "";
            lblPedidoLMS.Text = "";
            lblFolio.Text = "";
            lblDistribuidora.Text = "";
            lblRuta.Text = "";
            lblSocio.Text = "";
            lblPropietario.Text = "";
            lblRazonSocial.Text = "";
            lblCalle.Text = "";
            lblEntreCalle.Text = "";
            lblYCalle.Text = "";
            lblColonia.Text = "";
            lblMunicipio.Text = "";
            lblCiudad.Text = "";
            lblEstado.Text = "";
            lblCP.Text = "";
            lblTelefono.Text = "";
            lblClave.Text = "";
            lblPremioDetalle.Text = "";
            lblCantidad.Text = "";
            lblFechaSol.Text = "";
            lblFechaProm.Text = "";
            lblFechaStatus.Text = "";
            lblMensajeria.Text = "";
            lblGuia.Text = "";
            lblFechaEmb.Text = "";
            lblOrigen.Text = "";
            lblDestino.Text = "";
            lblRecibidoPor.Text = "";
            lblStatus.Text = "";
            lblFechaEntrega.Text = "";
            lblObservaciones.Text = "";
            lblProveedor.Text = "";
            lblTipoEnvio.Text = "";
            lblPrioridad.Text = "";
            lblComentario.Text = "";
            lblClaveExtra.Text = "";
            lblTipoDireccion.Text = "";
            lblReferencias.Text = "";
        }
    }
}