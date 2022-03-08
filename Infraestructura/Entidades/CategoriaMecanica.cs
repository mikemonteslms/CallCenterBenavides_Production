using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORMModel
{
    public class CategoriaMecanica
    {
        public int id_categoriaMecanica { get; set; }
        public string Descripcion { get; set; }
        public int Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
