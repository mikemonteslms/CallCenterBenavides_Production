using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModSubmnus
    {
        public int IdMenu { get; set; }
        public int IdSubMenu { get; set; }
        public string NombreSubMnu { get; set; }
        public string URL { get; set; }
        public string Alt { get; set; }
        public int Orden { get; set; }
        public int PadreId { get; set; }
    }
}
