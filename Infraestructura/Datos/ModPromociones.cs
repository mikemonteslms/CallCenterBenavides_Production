using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModPromociones
    {
        public int IdMecanica { get; set; }
        public string CodigoInterno { get; set; }
        public string NombrePromocion { get; set; }
        public int IdPeriodo { get; set; }
        public int Limite { get; set; }
        public string FechaFin { get; set; }
        public int flagExtencion { get; set; }
        public string FechaExtencion { get; set; }
        public string Comentarios { get; set; }
        public string Usuario { get; set; }
        public int VerEnReporte { get; set; }
        public int CierreCiclosSugeridos { get; set; }
    }
}
