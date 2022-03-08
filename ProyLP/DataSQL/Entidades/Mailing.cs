using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallCenterDB.Entidades
{
    public class DatosServidor
    {
        public long ProgramaID
        { get; set; }
        public string Programa
        { get; set; }
        public string FromMail
        { get; set; }
        public string FromName
        { get; set; }
        public string ServidorSMTP
        { get; set; }
        public string ServidorPOP
        { get; set; }
        public string UsuarioMail
        { get; set; }
        public string PasswordMail
        { get; set; }
    }
    public class DatosCliente
    {
        public string FromMail
        {
            get;
            set;
        }
        public string FromName
        {
            get;
            set;
        }
        public string ToMail
        {
            get;
            set;
        }
        public string ToName
        {
            get;
            set;
        }
        public string Subject
        {
            get;
            set;
        }
        public string Body
        {
            get;
            set;
        }
    }
    public class RespuestaEnvio
    {
        public RespuestaEnvio()
        { }
        public RespuestaEnvio(string codigo, string mensaje)
        {
            Codigo = codigo;
            Mensaje = mensaje;
        }
        public string Codigo
        {
            get;
            set;
        }
        public string Mensaje
        {
            get;
            set;
        }
    }
}