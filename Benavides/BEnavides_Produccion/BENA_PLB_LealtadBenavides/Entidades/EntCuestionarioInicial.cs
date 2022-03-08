using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EntCuestionarioInicial
    {

        public int cuestionario { get; set; }

        public int pregunta { get; set; }

        public int IdRespuesta { get; set; }

        public string Respuesta { get; set; }

        public string tarjeta { get; set; }

        public int tieneHijos { get; set; }

        public int NoHijos { get; set; }

        public int NoPersonas { get; set; }
        
        public int tienePadecimientoCronico { get; set; }

        public string xmlDetalle { get; set; }

        //public StringBuilder xmlDetalle { get; set; }

        public int Preg { get; set; }

        public int Resp { get; set; }

        public string usuario { get; set; }
                
    }
}
