using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORMModel
{
    [Serializable]
    public class ProductoSeleccionado
    {
        public string IdCategoria { get; set; }

        public string Cantidad { get; set; }

        public string CantidadBeneficio { get; set; }

        public List<Presentacion> Productos { get; set; }
    }

    public class Presentacion
    {
        public string IdProd { get; set; }
    }


    [Serializable]
    public class ProductoSeleccionadoLista
    {
        public string IdCategoria { get; set; }

        public string Cantidad { get; set; }

        public string IdProducto { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string DescripcionProducto { get; set; }

        public string CodigoBarras { get; set; }

        public string IdCodigoInterno { get; set; }

        public int Id { get; set; }
    }
}
