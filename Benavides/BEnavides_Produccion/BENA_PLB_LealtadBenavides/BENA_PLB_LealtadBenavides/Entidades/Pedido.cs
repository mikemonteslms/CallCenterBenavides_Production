using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
    [System.SerializableAttribute()]
    [XmlRootAttribute(ElementName = "Pedido", Namespace = "http://www.lms.com.mx/WebServices/Prepago", IsNullable = false)]
    [XmlTypeAttribute(TypeName = "Pedido", Namespace = "http://www.lms.com.mx/WebServices/Prepago")]
    public class Pedido
    {
        #region Atributos

        private string _SKU;
        private int _cantidad;
        private string _descripcionSKU;

        #endregion Atributos

        #region Propiedades

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SKU
        {
            set { _SKU = value; }
            get { return _SKU; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Cantidad
        {
            set { _cantidad = value; }
            get { return _cantidad; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DescripcionSKU
        {
            set { _descripcionSKU = value; }
            get { return _descripcionSKU; }
        }

        #endregion Propiedades
    }
}
