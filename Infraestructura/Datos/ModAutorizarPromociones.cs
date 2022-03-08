using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModAutorizarPromociones
    {
        public int IdMecanica {get; set;}
        public int IdTipoAcumulacion {get; set;}
        public int IdStatusPaseProduccion {get; set;}
        public DateTime FechaPaseProduccion { get; set; }
    }
}
