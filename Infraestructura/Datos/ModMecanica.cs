using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModMecanica
    {
        public int IdSegmento { get; set; }
        public string CodigoInterno { get; set; }
        public string NomProducto { get; set; }
        public string Categoria { get; set; }
        public int Idlaboratorio { get; set; }
        public string Laboratorio { get; set; }  //eliminar es provisional
        public string Promocion { get; set; }
        public string EstatusInicio { get; set; }
        public int Tipoacumulacion { get; set; }
        public int IdtipoPromocion { get; set; }
        public int CantidadCompra { get; set; }
        public int CantidadEntrega { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaConteo { get; set; }
        public int IdPreiodoLimite { get; set; }
        public float Limite { get; set; }
        public DateTime FechaExtencion { get; set; }
        public string CodigoInternoEntrega { get; set; }
        public string NombreMecanica { get; set; }
        public int EstatusPaseProd { get; set; }
        public string FechaPaseProduccion { get; set; }
        public bool VerenReporte { get; set; }
        public string Comentarios { get; set; }
        public int CierreCiclosSugeridos { get; set; }
        public int falgFechaExt { get; set; }
        public string CodigoBarras { get; set; }
    }
}
