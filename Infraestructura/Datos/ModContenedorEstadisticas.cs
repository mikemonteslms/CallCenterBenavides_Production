using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModContenedorEstadisticas
    {
        public ModContenedorEstadisticas()
        {

            this.lstDias = new List<ModDiasX>();
            this.lstMetodos = new List<ModMetodos>();
            this.lstTiempoPromedio = new List<ModTiemposPromedioPOS>();
        }

        public List<ModDiasX> lstDias { get; set; }
        public List<ModMetodos> lstMetodos { get; set; }
        public List<ModTiemposPromedioPOS> lstTiempoPromedio { get; set; }
        public int YAxisMaxValue { get; set; }
    }
}
