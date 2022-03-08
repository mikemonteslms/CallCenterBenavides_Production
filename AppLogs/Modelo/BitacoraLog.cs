using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logs.Modelo
{
    public class BitacoraLog
    {
        public string Hilo { get; set; } //Thread que detona la instrucción
        public string TipoLog { get; set; }//Si es Alerta, Error y/o Información
        public string Ambiente { get; set; }//Front o Back
        public string App { get; set; }//Aplicativo
        public string Clase { get; set; }//Clase que contiene el evento que detona reg de bitacora
        public string EventoOrMetodo { get; set; }//Evento o Metodo que detona reg de bitacora
        public string Usuario { get; set; }//Usuario que detona el Evento o Metodo
        public string Mensaje { get; set; }//mensaje
        public string Excepcion { get; set; }//Descripción de la excepción
        public int Nivel { get; set; }//Identificador de tipo de log
    }
}
