using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNegocio
{
    public class Club
    {
        public int id_club { get; set; }
        public string descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Prioridad { get; set; }
    }
}
