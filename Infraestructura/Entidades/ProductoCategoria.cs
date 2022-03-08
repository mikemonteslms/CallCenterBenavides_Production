using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORMModel
{
    public class ProductoCategoria
    {
        public int id_producto_categoria { get; set; }
        public string Descripcion { get; set; }
        public int id_status { get; set; }
        public DateTime Producto_dateFechaAlta { get; set; }
        public DateTime Producto_dateFechaModificacion { get; set; }
        public int id_laboratorio { get; set; }
    }
}
