using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModMecanicaDEPorc
    {
        public string CodigoInterno { get; set; }
        public string Producto { get; set; }
        public int idTipoPromocion { get; set; }
        public string Promocion { get; set; }
        public float Cantidad { get; set; }
        public string EstatusInicio { get; set; }
        public int EstatusPaseProd { get; set; }
        public string FechaPaseProd { get; set; }
        public int Tipoacumulacion { get; set; }
        public string TipoPromocion { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public bool VerEnReporte { get; set; }
    }
}
