using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModPromoDobleAcumulacion
    {
        public Int32 Id { get; set; }
        public Int32 IdPromo { get; set; }
        public string Nombre { get; set; }
        public string Sucursal { get; set; }
        public string CveSucursal { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaFinDesc { get; set; }
        public string FechaFinDesctxt { get; set; }
        public bool blnMarca { get; set; }
        public int Estatus { get; set; }
        public int Porcentaje { get; set; }
        public int flgDescuento { get; set; }
        public int EnabledDescuento { get; set; }
        public int EnabledAcumulacion { get; set; }
        public string UsuarioModifica { get; set; }
        public string Cupon { get; set; }
        public int Cantidad { get; set; }
        public int SoloActivaciones { get; set; }

    }
}
