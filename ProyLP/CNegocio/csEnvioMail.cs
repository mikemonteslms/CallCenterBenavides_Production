using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using CallCenterDB.Entidades;

namespace CNegocio
{
    
    public class csEnvioMail
    {
        csMailing mailing;
        private DatosServidor mail;
        public int ProgramaID
        { get; set; }
        public string NombrePrograma
        { get; set; }
        public string Remitente
        { get; set; }
        public string CorreoElectronico
        { get; set; }

        public csEnvioMail(int programa_id)
        {
            mailing = new csMailing();
            mail = mailing.Datos(programa_id);
            ProgramaID = Convert.ToInt32(mail.ProgramaID);
            NombrePrograma = mail.Programa;
            Remitente = mail.FromName;
            CorreoElectronico = mail.FromMail;
        }
        public csEnvioMail(string clave)
        {
            mailing = new csMailing();
            mail = mailing.Datos(clave);
            ProgramaID = Convert.ToInt32(mail.ProgramaID);
            NombrePrograma = mail.Programa;
            Remitente = mail.FromName;
            CorreoElectronico = mail.FromMail;
        }
        public RespuestaEnvio Enviar(List<DatosCliente> envio, string subject, string body)
        {
            try
            {
                _enviar(envio, subject, body);
                return new RespuestaEnvio("OK", "");
            }
            catch (Exception ex)
            {
                return new RespuestaEnvio("ERROR", ex.Message);
            }
        }
        private void _enviar(List<DatosCliente> _d, string subject, string body)
        {
            System.Net.NetworkCredential credencial = new System.Net.NetworkCredential();
            credencial.UserName = mail.UsuarioMail;
            credencial.Password = mail.PasswordMail;
            SmtpClient servidor = new SmtpClient();
            servidor.Host = mail.ServidorSMTP;
            servidor.Credentials = credencial;
            MailAddress from = new MailAddress(mail.FromMail, mail.FromName);
            MailMessage mensaje = new MailMessage();
            mensaje.From = from;
            foreach (DatosCliente d in _d)
            {
                mensaje.To.Add(new MailAddress(d.ToMail, d.ToName));
            }
            mensaje.Subject = subject;
            mensaje.Body = body;
            mensaje.IsBodyHtml = true;
            try
            {
                servidor.Send(mensaje);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
