using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class CancelarCompraResult
    {
        private string tarjeta_strNumero;
        private string codigoError_strCodigo;
        private string codigoRespuesta_StrCodigo;
        private string codigoRespuesta_strDescripcion;
        private string strConfirmacion;
        private string cliente_intSaldoAnterior;
        private string cliente_intPuntosCancelados;
        private string cliente_intSaldoActual;
        private string cliente_intSaldoActualPesos;     

        public CancelarCompraResult()
        {

        }
        public CancelarCompraResult(string tarjeta_strNumero, string codigoError_strCodigo, string codigoRespuesta_StrCodigo, string codigoRespuesta_strDescripcion, string strConfirmacion, string cliente_intSaldoAnterior, string cliente_intPuntosCancelados, string cliente_intSaldoActual, string cliente_intSaldoActualPesos)
        {
            this.tarjeta_strNumero = tarjeta_strNumero;
            this.codigoError_strCodigo = codigoError_strCodigo;
            this.codigoRespuesta_StrCodigo = codigoRespuesta_StrCodigo;
            this.codigoRespuesta_strDescripcion = codigoRespuesta_strDescripcion;
            this.strConfirmacion = strConfirmacion;
            this.cliente_intSaldoAnterior = cliente_intSaldoAnterior;
            this.cliente_intPuntosCancelados = cliente_intPuntosCancelados;
            this.cliente_intSaldoActual = cliente_intSaldoActual;
            this.cliente_intSaldoActualPesos = cliente_intSaldoActualPesos;           
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
        public string StrConfirmacion
        {
            get { return strConfirmacion; }
            set { strConfirmacion = value; }
        }
        public string Cliente_intSaldoAnterior
        {
            get { return cliente_intSaldoAnterior; }
            set { cliente_intSaldoAnterior = value; }
        }
        public string Cliente_intPuntosCancelados
        {
            get { return cliente_intPuntosCancelados; }
            set { cliente_intPuntosCancelados = value; }
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

    }
}
