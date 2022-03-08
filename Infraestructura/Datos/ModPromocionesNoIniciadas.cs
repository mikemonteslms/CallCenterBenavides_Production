using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModPromocionesNoIniciadas
    {
        public int IdMecanica { get; set; }
        public int IdTipoAcumulacion { get; set; }
        public int IdSegmento { get; set; }
        public int IdTipoPromocion { get; set; }
        public string CodigoInterno { get; set; }
        public string CodigoInternoEntrega { get; set; }
        public string NombrePromocion { get; set; }
        public int IdPeriodo { get; set; }
        public int Limite { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string FechaConteo { get; set; }
        public string Comentarios { get; set; }
        public string Usuario { get; set; }
        public int CantidadCompra { get; set; }
        public int CantidadEntrega { get; set; }
        public string Lider { get; set; }
        public int VerEnReporte { get; set; }
        public string CodigoBarras { get; set; }
        public int flagExtension { get; set; }
        public string FechaExtension { get; set; }
        public int CierreCiclosSugeridos { get; set; }
        public string Laboratorio { get; set; }
    }
}
