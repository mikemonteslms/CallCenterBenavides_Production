using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Producto
    {
        private string  productoStrID;
        private string  productoStrDescripcion;
        private int productoIntStatus;
        
        public Producto()
        {

        }
        public Producto(string productoStrID, string productoStrDescripcion, int productoIntStatus)
        {
            this.productoStrID = productoStrID;
            this.productoStrDescripcion = productoStrDescripcion;
            this.productoIntStatus = productoIntStatus;
            
        }
        public string ProductoStrID
        {
            get { return productoStrID; }
            set { productoStrID = value; }
        }
        public string  ProductoStrDescripcion
        {
            get { return productoStrDescripcion; }
            set { productoStrDescripcion = value; }
        }
        public int ProductoIntStatus
        {
            get { return productoIntStatus; }
            set { productoIntStatus = value; }
        }
      
        
    }
}
