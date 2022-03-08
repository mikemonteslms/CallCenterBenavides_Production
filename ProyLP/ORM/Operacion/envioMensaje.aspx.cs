using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net.Mime;

namespace ORMOperacion
{
    public partial class envioMensaje : System.Web.UI.Page
    {
        csParticipante participante;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                        Master.Submenu = "Envío Correo";

                        MostrarDatosLlamadaSeguimientoParticipante(Session["participante_id"].ToString());
                    }
                    else
                        Response.Redirect("Default.aspx", false);
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
            txtCorreoElectronico.Text = participante.CorreoElectronico;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {            
            try
            {
                participante = new csParticipanteComplemento();
                participante.ID = Session["participante_id"].ToString();
                participante.DatosParticipante();
                // Guarda en la tabla bitacora_envios
                csDataBase query = new csDataBase();
                query.Query = "bitacora_envios_insert";
                query.EsStoreProcedure = true;
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@participante_id", participante.ID));
                param.Add(new SqlParameter("@correo_electronico", participante.CorreoElectronico.Trim()));
                param.Add(new SqlParameter("@asunto", txtAsunto.Text.Trim()));
                param.Add(new SqlParameter("@mensaje", txtMensaje.Text.Trim()));
                param.Add(new SqlParameter("@usuario_id", Membership.GetUser().ProviderUserKey.ToString()));
                query.Parametros = param;
                query.acutualizaDatos();
                //
                string participante_id = Session["participante_id"].ToString();

                /* Envio Mail */
                string plantilla = "";
                switch ((Session["participante"] as csParticipanteComplemento).Programa.ToUpper())
                {
                    case "AUDI":
                        plantilla = Server.MapPath("plantillas/comentarios_audi.html");
                        break;
                    case "PORSCHE":
                        plantilla = Server.MapPath("plantillas/comentarios_porsche.html");
                        break;
                    case "SEAT":
                        plantilla = Server.MapPath("plantillas/comentarios_seat.html");
                        break;
                    case "VW":
                        plantilla = Server.MapPath("plantillas/comentarios_vw.html");
                        break;
                }
                string html = "";

                using (StreamReader sr = new StreamReader(plantilla))
                {
                    html = sr.ReadToEnd();
                }
                html = html.Replace("@NOMBRE", txtParticipante.Text.Trim().ToUpper());
                html = html.Replace("@COMENTARIOS", txtMensaje.Text);

                CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
                CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();
                mail.ToMail = txtCorreoElectronico.Text;
                mail.ToName = txtParticipante.Text.Trim().ToUpper();
                List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();
                cliente.Add(mail);
                CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, txtAsunto.Text, html);
                if (r.Codigo != "OK")
                {
                    Master.MuestraMensaje("Mensaje enviado.");
                }
                else
                {
                    Master.MuestraMensaje("Ocurrió un error al enviar el correo. Intente nuevamente ");
                }
            }
            catch (Exception ex)
            {
                Master.MuestraMensaje("Ocurrió un error al enviar el correo. Intente nuevamente "+ ex.Message);
            }
        }

        protected void ButtonPrevia_Click(object sender, EventArgs e)
        {
            csParticipanteComplemento participante = Session["participante"] as csParticipanteComplemento;
            string plantilla = "";
            switch (participante.Programa.ToUpper())
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
            try
            {
                Response.Redirect(plantilla + "?&NOMBRE=" +
                participante.NombreCompleto.ToUpper() + "&COMENTARIOS=" +
                txtMensaje.Text);
                //contentDiv.InnerHtml += "<>";
                //contentDiv.InnerHtml = "<b>Estimado " + participante.NombreCompleto.ToUpper() + "</b>";
                //contentDiv.InnerHtml += "<br/>"+ txtMensaje.Text;
                //contentDiv.InnerHtml += "</>" + txtMensaje.Text;
            }
            catch (Exception ex)
            {

            }
        }
    }
}