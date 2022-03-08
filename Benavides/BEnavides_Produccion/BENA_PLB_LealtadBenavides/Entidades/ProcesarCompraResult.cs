using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ProcesarCompraResult
    {
        private string tarjeta_strNumero;
        private string sucursal_strId;
        private string terminal_strId;
        private string usuario_strId;
        private string codigoError_strCodigo;
        private string codigoRespuesta_StrCodigo;
        private string codigoRespuesta_strDescripcion;
        private string strCotizacion;
        private string cliente_intSaldoAnterior;
        private string cliente_intPuntosAcumulados;
        private string cliente_intSaldoActual;
        private string cliente_intSaldoActualPesos;
        private string fechaVencimientoPuntos;
        private string ticketBeneficio;

        public ProcesarCompraResult()
        {

        }
        public ProcesarCompraResult(string tarjeta_strNumero, string sucursal_strId, string terminal_strId, string usuario_strId, string codigoError_strCodigo, string codigoRespuesta_StrCodigo, string codigoRespuesta_strDescripcion, string strCotizacion, string cliente_intSaldoAnterior, string cliente_intPuntosAcumulados, string cliente_intSaldoActual, string cliente_intSaldoActualPesos, string fechaVencimientoPuntos, string ticketBeneficio)
        {
            this.tarjeta_strNumero = tarjeta_strNumero;
            this.sucursal_strId = sucursal_strId;
            this.terminal_strId = terminal_strId;
            this.usuario_strId = usuario_strId;
            this.codigoError_strCodigo = codigoError_strCodigo;
            this.codigoRespuesta_StrCodigo = codigoRespuesta_StrCodigo;
            this.codigoRespuesta_strDescripcion = codigoRespuesta_strDescripcion;
            this.strCotizacion = strCotizacion;
            this.cliente_intSaldoAnterior = cliente_intSaldoAnterior;
            this.cliente_intPuntosAcumulados = cliente_intPuntosAcumulados;
            this.cliente_intSaldoActual = cliente_intSaldoActual;
            this.cliente_intSaldoActualPesos = cliente_intSaldoActualPesos;
            this.fechaVencimientoPuntos = fechaVencimientoPuntos;
            this.ticketBeneficio = ticketBeneficio;
        }

        public string Tarjeta_strNumero
        {
            get { return tarjeta_strNumero; }
            set { tarjeta_strNumero = value; }
        }
        public string Sucursal_strId
        {
            get { return sucursal_strId; }
            set { sucursal_strId = value; }
        }
        public string Terminal_strId
        {
            get { return terminal_strId; }
            set { terminal_strId = value; }
        }
        public string Usuario_strId
        {
            get { return usuario_strId; }
            set { usuario_strId = value; }
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
        public string StrCotizacion
        {
            get { return strCotizacion; }
            set { strCotizacion = value; }
        }
        public string Cliente_intSaldoAnterior
        {
            get { return cliente_intSaldoAnterior; }
            set { cliente_intSaldoAnterior = value; }
        }
        public string Cliente_intPuntosAcumulados
        {
            get { return cliente_intPuntosAcumulados; }
            set { cliente_intPuntosAcumulados = value; }
        }
        public string Cliente_intSaldoActual
        {
            get { return cliente_intSaldoActual; }
            set { cliente_intSaldoActual = value; }
        }
        public string Cliente_intSaldoActualPesos
        {
            get { return cliente_intSaldoActualPesos; }
            set { cliente_intSaldoActualPesos = value; }
        }
        public string FechaVencimientoPuntos
        {
            get { return fechaVencimientoPuntos; }
            set { fechaVencimientoPuntos = value; }
        }
        public string TicketBeneficio
        {
            get { return ticketBeneficio; }
            set { ticketBeneficio = value; }
        }

    }
}

