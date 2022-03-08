using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
    [System.SerializableAttribute()]
    [XmlRootAttribute(ElementName = "Token", Namespace = "http://www.lms.com.mx/WebServices/Prepago", IsNullable = false)]
    [XmlTypeAttribute(TypeName = "Token", Namespace = "http://www.lms.com.mx/WebServices/Prepago")]
    public class Token
    {
        #region Atributos

        private string _CotizacionId;
        private string _Tarjeta;
        private string _SKU;
        private string _Cantidad;

        #endregion Atributos

        #region Propiedades

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CotizacionId
        {
            set { _CotizacionId = value; }
            get { return _CotizacionId; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Tarjeta
        {
            set { _Tarjeta = value; }
            get { return _Tarjeta; }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SKU
        {
            set { _SKU = value; }
            get { return _SKU; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Cantidad
        {
            set { _Cantidad = value; }
            get { return _Cantidad; }
        }

        #endregion Propiedades
    }
}
