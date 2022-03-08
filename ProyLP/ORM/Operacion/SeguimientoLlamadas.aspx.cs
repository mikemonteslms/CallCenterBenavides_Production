using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Configuration;
using System.IO;

namespace ORMOperacion
{
    public partial class SeguimientoLlamadas : System.Web.UI.Page
    {
        csParticipante participante;
        bool cerrado = false;
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
                    Master.Menu = "Llamadas";
                    Master.Submenu = "Seguimiento";

                    MostrarDatosLlamadaSeguimientoParticipante(Session["participante_id"].ToString());
                    MuestraSeguimiento(Session["participante_id"].ToString());
                }
                else
                {
                    Response.Redirect("default.aspx", false);
                }
            }
        }

        private void MostrarDatosLlamadaSeguimientoParticipante(string participante_id)
        {
            participante = new csParticipanteComplemento();
            participante.ID = participante_id;
            participante.DatosParticipante();
            if (participante.NombreCompleto.Trim() != "")
            {
                txtParticipante.Text = participante.NombreCompleto.ToUpper();
            }
            else
            {
                txtParticipante.Text = participante.RazoSocial.ToUpper();
            }
            hidNombreCompleto.Value = participante.NombreCompleto.Trim();
            hidRazonSocial.Value = participante.RazoSocial.Trim();
            hidClave.Value = participante.Clave.Trim();
            hidDistribuidora.Value = participante.Distribuidora.Trim();
            hidPrograma.Value = participante.Programa.Trim();
            hidPrograma.Value = participante.Programa;
        }

        protected void MuestraSeguimiento(string participante_id)
        {
            csLlamada llamada = new csLlamada();
            llamada.IDParticipante = participante_id;
            DataTable dtLlamadas = llamada.SeguimientoLlamadas();
            lblRegistros.Text = dtLlamadas.Rows.Count.ToString() + " llamada(s) encontradas";
            lblDescripcion.Visible = false;
            txtDescripcion.Visible = false;
            lblNoCaso.Visible = false;
            txtNoCaso.Visible = false;
            if (dtLlamadas.Rows.Count > 0)
            {
                gvSeguimientoLlamadas.DataSource = dtLlamadas.DefaultView;
                gvSeguimientoLlamadas.DataBind();
                mvSeguimientoLlamada.SetActiveView(vSeguimientoLlamada);
            }
            else
            {
                //Master.MuestraMensaje("No se encontraron llamadas.");
            }
        }

        protected void MuestraLlamadaDetalle(string id)
        {
            csLlamada llamada = new csLlamada();
            llamada.IDlamada = id;
            hidLlamada_id.Value = llamada.IDlamada;
            DataTable dtLlamadasDetalle = llamada.SeguimientoLlamadasDetalle();
            string descripcion_larga = "";
            for (int i = 0; i < dtLlamadasDetalle.Rows.Count; i++)
            {
                DataRow drLlamadaDetalle = dtLlamadasDetalle.Rows[i];
                if (i + 1 < dtLlamadasDetalle.Rows.Count)
                    descripcion_larga = descripcion_larga + drLlamadaDetalle["descripcion_larga"].ToString() + ", ";
                else
                    descripcion_larga = descripcion_larga + drLlamadaDetalle["descripcion_larga"].ToString();
            }
            txtDescripcion.Text = descripcion_larga;
            txtNoCaso.Text = id;
            lblRegistrosDetalle.Text = dtLlamadasDetalle.Rows.Count.ToString() + " llamada(s) encontradas";
            lblDescripcion.Visible = true;
            txtDescripcion.Visible = true;
            lblNoCaso.Visible = true;
            txtNoCaso.Visible = true;
            lblRegistros.Visible = false;
            if (dtLlamadasDetalle.Rows.Count > 0)
            {
                gvSeguimientoDetalle.DataSource = dtLlamadasDetalle.DefaultView;
                gvSeguimientoDetalle.DataBind();
                mvSeguimientoLlamada.SetActiveView(vLlamadaDetalle);
            }
            else
            {
                Master.MuestraMensaje("No se encontraron llamadas.");
            }
        }

        protected void gvSeguimientoLlamadas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                string id = gvSeguimientoLlamadas.DataKeys[e.RowIndex].Values["id"].ToString();
                MuestraLlamadaDetalle(id);
            }
            catch (Exception ex)
            {
                CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
                CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();
                List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                mail.ToMail = "vsilvac@lms.com.mx";
                mail.ToName = "Victor Silva Cabrera";
                string Subject = "Loyalty World - Error en: " + Membership.ApplicationName;
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

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            lblRegistros.Visible = true;
            lblDescripcion.Visible = false;
            txtDescripcion.Visible = false;
            MuestraSeguimiento(Session["participante_id"].ToString());
            mvSeguimientoLlamada.SetActiveView(vSeguimientoLlamada);
        }

        protected void gvSeguimientoDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //cerrado;
                    Label lblStatus = e.Row.FindControl("lblStatus") as Label;
                    if (lblStatus != null)
                    {
                        if (lblStatus.Text.ToUpper() == "CERRADO" || lblStatus.Text.ToUpper() == "CONCLUÍDO")
                            cerrado = true;
                    }
                }

                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    DropDownList ddlEscalamiento = e.Row.FindControl("ddlEscalamiento") as DropDownList;
                    DropDownList ddlStatus = e.Row.FindControl("ddlStatus") as DropDownList;
                    TextBox txtObservacion = e.Row.FindControl("txtObservacion") as TextBox;
                    LinkButton lkbGuardar = e.Row.FindControl("lkbGuardar") as LinkButton;
                    if (ddlEscalamiento != null && ddlStatus != null && txtObservacion != null && lkbGuardar != null)
                    {
                        if (cerrado == false)
                        {
                            csLlamada llamada = new csLlamada();
                            DataTable dtStatus = llamada.LlenarStatusSeguimientoLlamadas();
                            ddlStatus.DataSource = dtStatus;
                            ddlStatus.DataBind();
                            DataTable dtEscalamiento = llamada.LlenarEscalamientoSeguimientoLlamadas();
                            ddlEscalamiento.DataSource = dtEscalamiento;
                            ddlEscalamiento.DataBind();
                            gvSeguimientoDetalle.ShowFooter = true;
                        }
                        else
                        {
                            gvSeguimientoDetalle.ShowFooter = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
                CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();

                List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                mail.ToMail = "vsilvac@lms.com.mx";
                mail.ToName = "Victor Silva Cabrera";
                cliente.Add(mail);

                string errMail = "Error en la aplicacion " + Membership.ApplicationName +
                        "<br/><br/>Fecha: " + DateTime.Now.ToString() +
                        "<br/><br/>Pagina:<br/>" + Request.Url.ToString() +
                        "<br/><br/>Usuario:<br/>" + Membership.GetUser().UserName +
                        "<br/><br/>Mensaje de error:<br/>" + ex.Message +
                        "<br/><br/>Mas detalle del error:<br/>" +
                        (ex.InnerException != null ? ex.InnerException.Message : "") +
                        "<br/><br/>Stack Trace:<br/>" + ex.StackTrace.ToString() +
                        "<br/><br/>Error Completo:<br/>" + ex.ToString();

                string Subject = "Loyalty World - Error en: " + Membership.ApplicationName;
                string Body = errMail;
                CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, errMail);
            }
        }

        protected void gvSeguimientoDetalle_RowCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("Update"))
            {
                try
                {
                    string Observacion = ((TextBox)gvSeguimientoDetalle.FooterRow.FindControl("txtObservacion")).Text;
                    string status_escalamiento_id = ((DropDownList)gvSeguimientoDetalle.FooterRow.FindControl("ddlEscalamiento")).SelectedItem.Value;
                    string escalamiento = ((DropDownList)gvSeguimientoDetalle.FooterRow.FindControl("ddlEscalamiento")).SelectedItem.Text;
                    string status_seguimiento_id = ((DropDownList)gvSeguimientoDetalle.FooterRow.FindControl("ddlStatus")).SelectedItem.Value;
                    string status_seguimiento = ((DropDownList)gvSeguimientoDetalle.FooterRow.FindControl("ddlStatus")).SelectedItem.Text;
                    csLlamada llamada = new csLlamada();
                    llamada.IDlamada = hidLlamada_id.Value;
                    llamada.IDUsuario = Membership.GetUser().ProviderUserKey.ToString();
                    llamada.Descripcion = Observacion;
                    //llamada.CountryCode = hidCountryCode.Value;
                    llamada.Status_seguimiento_id = status_seguimiento_id;
                    llamada.GuardaLlamadaSeguimiento(status_escalamiento_id);

                    /* Obtiene la clave de status_segumiento */
                    DataTable dtClaveStatusSeguimiento = llamada.ObtieneClaveStatusSeguimiento(status_seguimiento_id, null);
                    if (dtClaveStatusSeguimiento.Rows.Count > 0)
                    {
                        DataRow drClaveStatusSeguimiento = dtClaveStatusSeguimiento.Rows[0];
                        string clave_status_seguimiento = drClaveStatusSeguimiento["clave"].ToString().ToUpper();
                        if (clave_status_seguimiento != "C") // si el status es cerrado no manda mail
                        {
                            /* Envio Mail */
                            string plantilla = "";
                            switch ((Session["participante"] as csParticipanteComplemento).Programa.ToUpper())
                            {
                                case "AUDI":
                                    plantilla = Server.MapPath("plantillas/aviso_llamada_audi.html");
                                    break;
                                case "PORSCHE":
                                    plantilla = Server.MapPath("plantillas/aviso_llamada_porsche.html");
                                    break;
                                case "SEAT":
                                    plantilla = Server.MapPath("plantillas/aviso_llamada_seat.html");
                                    break;
                                case "VW":
                                    plantilla = Server.MapPath("plantillas/aviso_llamada_vw.html");
                                    break;
                            }
                            string html = "";

                            using (StreamReader sr = new StreamReader(plantilla))
                            {
                                html = sr.ReadToEnd();
                            }

                            string _datos = "<table>" +
                                "<tr><td width='130px'><b>Participante ID:</b></td><td>" + Session["participante_id"].ToString() + "</td></tr>" +
                                "<tr><td><b>Nombre:</b></td><td>" + hidNombreCompleto.Value + "</td></tr>" +
                                "<tr><td><b>Clave:</b></td><td>" + hidClave.Value + "</td></tr>" +
                                "<tr><td><b>Distribuidora:</b></td><td>" + hidDistribuidora.Value + "</td></tr></table>" +
                                //"<p>&nbsp;</p>" +
                                "<p>Se gener&oacute; la siguiente llamada:</p>" +
                                "<table width='900px'><tr><td colspan='3' align='center'><b>Detalle de llamada</b></td></tr>" +
                                "<tr><td><b>Escalamiento:</b></td><td>" + escalamiento + "</td></tr>" +
                                "<tr><td><b>Comentarios:</b></td><td>" + Observacion + "</td></tr>" +
                                "<tr><td><b>Status:</b></td><td>" + status_seguimiento + "</td></tr>" +
                                "</table>";
                            string body = _datos;
                            html = html.Replace("@MENSAJE", body);

                            /* Obtiene la clave de tipo llamada del escalamiento */
                            DataTable dtClave = llamada.ObtieneClaveTipoLlamada(status_escalamiento_id);
                            if (dtClave.Rows.Count > 0)
                            {
                                DataRow drClave = dtClave.Rows[0];
                                string clave_escalamiento = drClave["clave"].ToString().ToUpper();

                                CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
                                CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();
                                mail.ToMail = envio.CorreoElectronico;
                                mail.ToName = envio.Remitente;
                                List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                                cliente.Add(mail);
                                CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, "Seguimiento de llamada " + (Session["participante"] as csParticipanteComplemento).Programa, html);
                                if (r.Codigo != "OK")
                                {
                                    Master.MuestraMensaje("<p>Ocurrió un error al enviar correo de llamada.</p>");
                                }
                            }
                        }
                    }
                    /****************/
                    MuestraLlamadaDetalle(hidLlamada_id.Value);
                }
                catch (Exception ex)
                {
                    CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
                    CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();

                    List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                    mail.ToMail = "vsilvac@lms.com.mx";
                    mail.ToName = "Victor Silva Cabrera";
                    cliente.Add(mail);

                    string errMail = "Error en la aplicacion " + Membership.ApplicationName +
                            "<br/><br/>Fecha: " + DateTime.Now.ToString() +
                            "<br/><br/>Pagina:<br/>" + Request.Url.ToString() +
                            "<br/><br/>Usuario:<br/>" + Membership.GetUser().UserName +
                            "<br/><br/>Mensaje de error:<br/>" + ex.Message +
                            "<br/><br/>Mas detalle del error:<br/>" +
                            (ex.InnerException != null ? ex.InnerException.Message : "") +
                            "<br/><br/>Stack Trace:<br/>" + ex.StackTrace.ToString() +
                            "<br/><br/>Error Completo:<br/>" + ex.ToString();
                    string Subject = "Loyalty World - Error en: " + Membership.ApplicationName;
                    string Body = errMail;
                    CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, errMail);
                }
            }
        }
    }
}