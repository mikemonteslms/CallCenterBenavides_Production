using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ActivaTarjetaResult
    {
        private string tarjeta_strNumero;
        private string codigoError_strCodigo;
        private string codigoRespuesta_StrCodigo;
        private string codigoRespuesta_strDescripcion;       

        public ActivaTarjetaResult()
        {

        }
        public ActivaTarjetaResult(string tarjeta_strNumero, string codigoError_strCodigo, string codigoRespuesta_StrCodigo, string codigoRespuesta_strDescripcion)
        {
            this.tarjeta_strNumero = tarjeta_strNumero;
            this.codigoError_strCodigo = codigoError_strCodigo;
            this.codigoRespuesta_StrCodigo = codigoRespuesta_StrCodigo;
            this.codigoRespuesta_strDescripcion = codigoRespuesta_strDescripcion;           
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

    }
}
