using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ValidaTarjetaResult
    {
        private string tarjeta_strNumero;
        private string codigoError_strCodigo;
        private string codigoRespuesta_StrCodigo;
        private string codigoRespuesta_strDescripcion;
        private string cliente_strNombre;
        private string tarjeta_strEstatus;
        private string tarjeta_intMontoAcumulados;
        private string tarjeta_intPuntosAcumulados;
        private string mensajePublicar;
        private string fechaVencimientoPuntos;
        private string tarjeta_intNivel;
        private string tarjeta_strNivel;

        public ValidaTarjetaResult()
        {

        }
        public ValidaTarjetaResult(string tarjeta_strNumero, string codigoError_strCodigo, string codigoRespuesta_StrCodigo, string codigoRespuesta_strDescripcion, string cliente_strNombre, string tarjeta_strEstatus, string tarjeta_intMontoAcumulados, string tarjeta_intPuntosAcumulados, string mensajePublicar, string fechaVencimientoPuntos, string tarjeta_intNivel, string tarjeta_strNivel)
        {
            this.tarjeta_strNumero = tarjeta_strNumero;
            this.codigoError_strCodigo = codigoError_strCodigo;
            this.codigoRespuesta_StrCodigo = codigoRespuesta_StrCodigo;
            this.codigoRespuesta_strDescripcion = codigoRespuesta_strDescripcion;
            this.cliente_strNombre = cliente_strNombre;
            this.tarjeta_strEstatus = tarjeta_strEstatus;
            this.tarjeta_intMontoAcumulados = tarjeta_intMontoAcumulados;
            this.tarjeta_intPuntosAcumulados = tarjeta_intPuntosAcumulados;
            this.mensajePublicar = mensajePublicar;
            this.fechaVencimientoPuntos = fechaVencimientoPuntos;
            this.tarjeta_intNivel = tarjeta_intNivel;
            this.tarjeta_strNivel = tarjeta_strNivel;
        }

        public string Tarjeta_strNumero
        {
            get { return tarjeta_strNumero; }
            set { tarjeta_strNumero = value; }
        }
        public string CodigoError_strCodigo
        {
            get { return codigoError_strCodigo; }
            set { codigoError_strCodigo = value; }
        }
        public string CodigoRespuesta_StrCodigo
        {
            get { return codigoRespuesta_StrCodigo; }
            set { codigoRespuesta_StrCodigo = value; }
        }
        public string CodigoRespuesta_strDescripcion
        {
            get { return codigoRespuesta_strDescripcion; }
            set { codigoRespuesta_strDescripcion = value; }
        }
        public string Cliente_strNombre
        {
            get { return cliente_strNombre; }
            set { cliente_strNombre = value; }
        }
        public string Tarjeta_strEstatus
        {
            get { return tarjeta_strEstatus; }
            set { tarjeta_strEstatus = value; }
        }
        public string Tarjeta_intMontoAcumulados
        {
            get { return tarjeta_intMontoAcumulados; }
            set { tarjeta_intMontoAcumulados = value; }
        }
        public string Tarjeta_intPuntosAcumulados
        {
            get { return tarjeta_intPuntosAcumulados; }
            set { tarjeta_intPuntosAcumulados = value; }
        }
        public string MensajePublicar
        {
            get { return mensajePublicar; }
            set { mensajePublicar = value; }
        }
        public string FechaVencimientoPuntos
        {
            get { return fechaVencimientoPuntos; }
            set { fechaVencimientoPuntos = value; }
        }
        public string Tarjeta_intNivel
        {
            get { return tarjeta_intNivel; }
            set { tarjeta_intNivel = value; }
        }
        public string Tarjeta_strNivel
        {
            get { return tarjeta_strNivel; }
            set { tarjeta_strNivel = value; }
        }

    }
}
