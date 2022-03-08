using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModPromocionesACBase
    {
        public int IdPABase { get; set; }
        public string NombrePromocion { get; set; }
        public Int32 Cantidad { get; set; }
        public Int32 IdPeriodo { get; set; }
        public Int32 Limite { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int ServicioDomicilio { get; set; }
        public int SurtirConsultorio { get; set; }

    }
}
