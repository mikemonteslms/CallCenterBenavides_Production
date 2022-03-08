using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Entidades
{
    [System.SerializableAttribute()]
    [XmlRootAttribute(ElementName = "Comprobante", Namespace = "http://www.lms.com.mx/WebServices/Prepago", IsNullable = false)]
    [XmlTypeAttribute(TypeName = "Comprobante", Namespace = "http://www.lms.com.mx/WebServices/Prepago")]
    public class Comprobante
    {
        #region Atributos

        private string _CodigoError;
        private string _DescripcionError;
        private string _Llave;
        private string _Tarjeta;

        #endregion Atributos

        #region Propiedades

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodigoError
        {
            set { _CodigoError = value; }
            get { return _CodigoError; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DescripcionError
        {
            set { _DescripcionError = value; }
            get { return _DescripcionError; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Llave
        {
            set { _Llave = value; }
            get { return _Llave; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Tarjeta
        {
            set { _Tarjeta = value; }
            get { return _Tarjeta; }
        }

        #endregion Propiedades
    }
}
