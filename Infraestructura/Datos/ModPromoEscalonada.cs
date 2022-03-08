using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModPromoEscalonada
    {
        public string Cupon { get; set; }
        public int IdPromocion { get; set; }
        public int IdPromocionDispara { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public string MensajePOS { get; set; }
        public int Orden { get; set; }
        public string Identificador { get; set; }
        public string IdStatus { get; set; }
        public int Id { get; set; }
        public int DuracionCupon { get; set; }
        public int RetrocederEscalon { get; set; }
        public int RetornoIlimitado { get; set; }
        public int RetornoInicio { get; set; }
        public int EsPromoTrigger { get; set; }
        public float MontoTrigger { get; set; }
        public string CodigoInterno { get; set; }
    }
}
