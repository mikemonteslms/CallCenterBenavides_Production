using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "" || Session["participante_id"] == null)
            {
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                MuestraCarrito();
                Master.GuardaAcceso("Carrito");
                Master.MenuActivo("carrito");
            }
        }
        protected void Carrito_Command(object sender, CommandEventArgs e)
        {
            csPremioMX pr = new csPremioMX(e.CommandArgument.ToString());
            pr.Consulta();
            switch (e.CommandName)
            {
                case "eliminar":
                    if (Session["carrito"] != null)
                    {
                        csCarritoComprasMX carrito = new csCarritoComprasMX();
                        carrito.Carrito = Session["carrito"] as List<csPremioMX>;
                        carrito.Eliminar(pr);
                        if (carrito.Items == 0)
                        {
                            Session["carrito"] = null;
                        }
                        MuestraCarrito();
                    }
                    break;
            }

        }
        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (Session["participante_id"] != null)
            {
                csParticipanteComplemento participante = new csParticipanteComplemento();
                participante.ID = Session["participante_id"].ToString();
                participante.DatosParticipante();

                TextBox txt = sender as TextBox;
                string premio_id = txt.Attributes["db-id"];
                csPremioMX pr = new csPremioMX(premio_id);
                pr.Consulta();
                if (Session["carrito"] != null)
                {
                    csCarritoComprasMX carrito = new csCarritoComprasMX();
                    carrito.Carrito = Session["carrito"] as List<csPremioMX>;
                    if (carrito.Puntos + (int.Parse(pr.Puntos) * int.Parse(txt.Text)) <= int.Parse(participante.Saldo))
                    {
                        pr.Cantidad = txt.Text;
                        carrito.Actualizar(pr);
                        Session["carrito"] = carrito.Carrito;
                    }
                    else
                    {
                        Master.MuestraMensaje("Saldo insuficiente");
                    }
                    MuestraCarrito();
                }
            }

        }
        protected void lnkCanjear_Click(object sender, EventArgs e)
        {
            csParticipanteComplemento p = new csParticipanteComplemento();
            p.ID = Session["participante_id"].ToString();

            CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(ConfigurationManager.AppSettings["programa"]);

            csCalendario calendario = new csCalendario();
            String fechaHoy = DateTime.Now.ToString("yyyyMMdd");
            calendario.Obtiene_calendario_canje_fecha(envio.ProgramaID, fechaHoy);
            if (calendario.Fecha == null)
            {
                Session.Remove("carrito");
                lvCarrito.DataBind();
                mvCarrito.SetActiveView(vVacio);
                Master.MuestraMensaje("El periodo de canje ha terminado.");
                return;
            }
            if (Session["carrito"] == null)
            {
                p.ActualizaSaldo();
                mvCarrito.SetActiveView(vVacio);
                Master.MuestraMensaje("El carrito está vacío");
                return;
            }
            List<CallCenterDB.Entidades.DatosCliente> destinatario;
            CallCenterDB.Entidades.DatosCliente datos;
            try
            {
                csCarritoComprasMX carrito = new csCarritoComprasMX();

                carrito.ParticipanteID = Session["participante_id"].ToString();
                carrito.UsuarioID = Membership.GetUser().ProviderUserKey.ToString();
                carrito.TipoTransaccion = "CJE";
                carrito.CategoriaTransaccionID = "3";
                carrito.Carrito = Session["carrito"] as List<csPremioMX>;

                CallCenterDB.Entidades.RMS rms = carrito.Canjear(ConfigurationManager.AppSettings["programa"], envio.ProgramaID);
                if (rms.PedidoRMS != null)
                {
                    p.ActualizaSaldo();
                    p.DatosParticipante();
                    guardaLlamada();

                    string plantilla = Server.MapPath("mailing/aviso_canje_vw.html");
                    string html = "";
                    using (StreamReader sr = new StreamReader(plantilla))
                    {
                        html = sr.ReadToEnd();
                    }

                    string _datos = "<table>" +
                        "<tr><td width='80px'><b>Participante ID:</b></td><td>" + Session["participante_id"].ToString() + "</td></tr>" +
                        "<tr><td><b>Nombre:</b></td><td>" + p.NombreCompleto + "</td></tr>" +
                        "<tr><td><b>Clave:</b></td><td>" + p.Clave + "</td></tr>" +
                        "<tr><td><b>Distribuidora:</b></td><td>" + p.Distribuidora + "</td></tr></table>" +
                        "<p>Se generaron los siguientes canjes:</p>" +
                        "<table><tr><td><b>Folio</b></td><td><b>Premio</b></td><td><b>Kilómetros</b></td></tr>";
                    string _canjes = "";
                    foreach (csPremioMX premio in carrito.CanjesRMS)
                    {
                        _canjes += "<tr><td align='left'>" + rms.Sucursal + "-" + premio.Folio +
                            "</td><td align='left'>" + premio.Descripcion + "<br/>" + premio.Observaciones +
                            "</td><td align='right'>" + int.Parse(premio.Puntos).ToString("N0");
                    }
                    _canjes += "</table>";

                    string _rms = "<p>Datos RMS:</p>";
                    _rms += "<b>Aplicación:</b> " + "Loyalty World Volkswagen <br />";
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

                    /*
                     * Se envía un mail al participante con los datos del canje
                     */
                    string html_participante = html;
                    string body_participante = _datos + _canjes;
                    html_participante = html_participante.Replace("@MENSAJE", body_participante);

                    destinatario = new List<CallCenterDB.Entidades.DatosCliente>();
                    datos = new CallCenterDB.Entidades.DatosCliente();
                    datos.ToMail = p.CorreoElectronico;
                    //datos.ToMail = "vsilvac@gmail.com";
                    datos.ToName = p.NombreCompleto;
                    destinatario.Add(datos);
                    envio.Enviar(destinatario, envio.NombrePrograma + " Canje de premios", html_participante);

                    /*
                     * Se envía un mail al programa con los datos del canje y la respuesta de RMS
                     */
                    string html_programa = html;
                    string body_programa = _datos + _canjes + _rms;
                    html_programa = html_programa.Replace("@MENSAJE", body_programa);

                    destinatario = new List<CallCenterDB.Entidades.DatosCliente>();
                    datos = new CallCenterDB.Entidades.DatosCliente();
                    datos.ToMail = envio.CorreoElectronico;
                    //datos.ToMail = "vsilvac@lms.com.mx";
                    datos.ToName = envio.Remitente;
                    destinatario.Add(datos);
                    envio.Enviar(destinatario, envio.NombrePrograma + " Canje de premios", html_programa);

                    lblPuntosCanjeados.Text = carrito.Puntos.ToString("N0");

                    Session.Remove("carrito");
                    lvCarrito.DataSource = null;
                    lvCarrito.DataBind();
                    mvCarrito.SetActiveView(vCompleto);
                }
                else
                {
                    Master.MuestraMensaje("Ocurrió un error al completar el canje. Intente nuevamente.");
                }
            }
            catch (Exception ex)
            {
                destinatario = new List<CallCenterDB.Entidades.DatosCliente>();
                datos = new CallCenterDB.Entidades.DatosCliente();

                datos.ToMail = "vsilvac@lms.com.mx";
                datos.ToName = "Victor Silva Cabrera";
                string Subject = "Loyalty World - Error en: " + Membership.ApplicationName;
                destinatario.Add(datos);

                string errMail = "Error en la aplicacion " + Membership.ApplicationName +
                        "<br/><br/>Fecha: " + DateTime.Now.ToString() +
                        "<br/><br/>Pagina:<br/>" + Request.Url.ToString() +
                        "<br/><br/>Usuario:<br/>" + Membership.GetUser().UserName +
                        "<br/><br/>Mensaje de error:<br/>" + ex.Message +
                        "<br/><br/>Mas detalle del error:<br/>" +
                        (ex.InnerException != null ? ex.InnerException.Message : "") +
                        "<br/><br/>Stack Trace:<br/>" + ex.StackTrace.ToString() +
                        "<br/><br/>Error Completo:<br/>" + ex.ToString();
                CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(destinatario, Subject, errMail);

                Master.MuestraMensaje("<p>Ocurrió un error al completar el canje. Intente nuevamente.</p>");
            }

        }
        public void MuestraCarrito()
        {
            if (Session["carrito"] != null)
            {
                csCarritoComprasMX carrito = new csCarritoComprasMX();
                carrito.Carrito = Session["carrito"] as List<csPremioMX>;
                lvCarrito.DataSource = carrito.Carrito;
                lvCarrito.DataBind();
                mvCarrito.SetActiveView(vCarrito);
            }
            else
            {
                mvCarrito.SetActiveView(vVacio);
            }
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
            {
                llamada.Telefono = "";
            }
            //string country = participante.CountryCode2;
            //llamada.CountryCode = participante.CountryCode2;
            llamada.GuardaLlamada();
        }


        public string FechaHoy()
        {

            string dia = Convert.ToString(DateTime.Now.Day);
            string mes = Convert.ToString(DateTime.Now.Month);
            string anio = Convert.ToString(DateTime.Now.Year);

            if (dia.Length == 1)
            {
                dia = "0" + dia;
            }
            if (mes.Length == 1)
            {
                mes = "0" + mes;
            }
            return anio + mes + dia;
        }
    }
}