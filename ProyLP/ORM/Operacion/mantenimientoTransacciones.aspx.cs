using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using Telerik.Web.UI;

namespace ORMOperacion
{
    public partial class mantenimientoTransacciones : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            cmpFechaTransaccion.MinimumValue = DateTime.Now.AddYears(-1).ToString("dd/MM/yyyy");
            cmpFechaTransaccion.MaximumValue = DateTime.Now.AddYears(2).ToString("dd/MM/yyyy");
        }

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
                    Master.Menu = "Participantes";
                    Master.Submenu = "Agregar Transacción";

                    cargaTipoTransaccion();
                    cargaDatosParticipante();
                }
                else
                    Response.Redirect("Default.aspx", false);
                styCalendario.Attributes.Add("href", "style/css/calendario.css");
            }
        }

        protected void cargaTipoTransaccion()
        {
            csDataBase Database = new csDataBase();
            ddlTipoTransaccion.DataSource = Database.dtConsulta("Obtiene_Tipo_Transaccion", true).DefaultView;
            ddlTipoTransaccion.DataBind();
            //RadComboBoxItem item = new RadComboBoxItem()
            ddlTipoTransaccion.Items.Insert(0, new RadComboBoxItem("Seleccione", "0"));
            //ddlTipoTransaccion.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        protected void cargaDatosParticipante()
        {
            csParticipanteComplemento p = new csParticipanteComplemento();
            p.ID = Session["participante_id"].ToString();
            p.DatosParticipante();
            if (p.NombreCompleto.Trim() != "")
                lblParticipante.Text = p.NombreCompleto.ToUpper();
            else
                lblParticipante.Text = p.RazoSocial.ToUpper();
            lblDistribuidora.Text = p.Distribuidora;
            lblPrograma.Text = p.Programa;
            hidPrograma.Value = p.Programa;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (hidPrograma.Value)
                {
                    case "GLP":
                        csParticipanteComplementoMX transaccion_MX = new csParticipanteComplementoMX();
                        transaccion_MX.ParticipanteID = Session["participante_id"].ToString();
                        transaccion_MX.UsuarioID = Membership.GetUser().ProviderUserKey.ToString();
                        transaccion_MX.TipoTransaccion = ddlTipoTransaccion.SelectedItem.Value;
                        transaccion_MX.Puntos = Convert.ToInt32(txtPuntos.Text);
                        transaccion_MX.Fecha = Convert.ToDateTime(txtFechaTransaccion.Text);
                        transaccion_MX.InsertaTransaccion();

                        //Enviar mail de transaccion
                        string plantilla = Server.MapPath("/mailing/tables/acumulacion_puntos_final.html");
                        string html = "";
                        using (StreamReader sr = new StreamReader(plantilla))
                        {
                            html = sr.ReadToEnd();
                        }
                        html = html.Replace("@Nombre", ((csParticipante)Session["participante"]).NombreCompleto);
                        html = html.Replace("@Usuario", Session["participante_id"].ToString());
                        html = html.Replace("@TipoPago", ddlTipoTransaccion.SelectedItem.Text);
                        html = html.Replace("@Puntos", transaccion_MX.Puntos.ToString());
                        html = html.Replace("@FechaPago", txtFechaTransaccion.Text);
                        html = html.Replace("@NumeroAutorizacion", transaccion_MX.Transaccion_id.ToString());

                        //html = html.Replace("@DATOS", cr);
                        //e.Message.Body = html;

                        CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(ConfigurationManager.AppSettings["programa"]);
                        CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();

                        mail.ToMail = ((csParticipante) Session["participante"]).CorreoElectronico;
                        //mail.ToMail = "gustavo.sanchez@lms.com.mx";
                        mail.ToName = Membership.GetUser().Email;

                        List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                        cliente.Add(mail);

                        string Subject = "Acumulación en Puntos";
                        CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, html);
                        if (r.Codigo == "OK")
                        {
                            transaccion_MX.InsertaBitacoraEnvios(Session["participante_id"].ToString(), ((csParticipante)Session["participante"]).CorreoElectronico, Subject, html, Membership.GetUser().ProviderUserKey.ToString());
                            //Master.MuestraMensaje("Se ha enviado un correo a su cuenta registrada.");
                        }
                        else
                        {
                            //Master.MuestraMensaje("Ocurrió un error al recuperar el password. Intente nuevamente");
                        }
                        break;
                }
                if (hidPrograma.Value != "")
                    Master.MuestraMensaje("Se realizó la transacción correctamente");
            }
            catch (Exception ex)
            {
                Datos oDatos = new Datos();
                Funciones oFunciones = new Funciones();
                string errMail = "Error en la aplicacion " + oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "nombreAplicacion") +
                        "<br/><br/>Fecha: " + DateTime.Now.ToString() +
                        "<br/><br/>Pagina:<br/>" + Request.Url.ToString() +
                        "<br/><br/>Usuario:<br/>" + Membership.GetUser().UserName +
                        "<br/><br/>Mensaje de error:<br/>" + ex.Message +
                        "<br/><br/>Mas detalle del error:<br/>" +
                        (ex.InnerException != null ? ex.InnerException.Message : "") +
                        "<br/><br/>Stack Trace:<br/>" + ex.StackTrace.ToString() +
                        "<br/><br/>Error Completo:<br/>" + ex.ToString();

                string correoFijo = "contacto@triangulopremia.com.mx";
                SmtpClient smtp = new SmtpClient("mailing.lms-la.com");
                System.Net.NetworkCredential credencial = new System.Net.NetworkCredential("contacto@triangulopremia.com.mx", "25b37T3y6v");
                smtp.Credentials = credencial;
                string body_t = errMail;
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress(correoFijo);
                mensaje.Subject = "Galenia Loyalty Program - Error en: " + Membership.ApplicationName;
                mensaje.To.Add(new MailAddress("gustavo.sanchez@lms.com.mx"));
                mensaje.Body = body_t;
                mensaje.IsBodyHtml = true;
                mensaje.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                smtp.Send(mensaje);
                Master.MuestraMensaje("Ocurrio un error al realizar la transacción");

                //EnvioMail enviar = new EnvioMail();
                //CallCenterDB.lms.enviarmail.Datos d = new CallCenterDB.lms.enviarmail.Datos();
                //d.FromMail = "contacto@pasionporganar.com.mx";
                //d.FromName = "Contacto Ingram PasGan";
                //d.ToMail = "daniel.hernandez@lms.com.mx";
                //d.ToName = "Daniel H Villa";
                //d.Subject = "Ingram PasGan - Error en: " + Membership.ApplicationName;
                //d.Body = errMail;
                //CallCenterDB.lms.enviarmail.Datos[] arrDatos = new CallCenterDB.lms.enviarmail.Datos[1];
                //arrDatos[0] = d;
                //Respuesta r = enviar.Enviar(arrDatos);
                //Master.MuestraMensaje("Ocurrio un error al realizar la transacción");
            }
        }
    }
}