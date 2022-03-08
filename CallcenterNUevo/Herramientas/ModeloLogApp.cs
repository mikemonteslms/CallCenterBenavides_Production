using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallcenterNUevo.Herramientas
{
    public class ModeloLogApp
    {
        public DateTime Fecha { get; set; }
        public string Hilo { get; set; }
        public string TipoLog { get; set; }
        public string App { get; set; }
        public string Ambiente { get; set; }
        public string Clase { get; set; }
        public string Evento_Metodo { get; set; }
        public string Usuario { get; set; }
        public string MensajeLog { get; set; }
    }
}