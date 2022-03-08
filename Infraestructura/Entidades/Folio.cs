using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Entidades
{
    [System.SerializableAttribute()]
    [XmlRootAttribute(ElementName = "Folio", Namespace = "http://www.lms.com.mx/WebServices/Prepago", IsNullable = false)]
    [XmlTypeAttribute(TypeName = "Folio", Namespace = "http://www.lms.com.mx/WebServices/Prepago")]
    public class Folio
    {
        #region Atributos

        private string _SKU;
        private bool _ValidoSKU;
        private bool _ExisteSKU;
        private string _ErrorSKU;
        private string _DescripcionErrorSKU;
        private string _descripcionSKU;
        private int _Compras;
        private int _Beneficios;
        private int _Sugeridos;

        #endregion Atributos

        #region Propiedades

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SKU
        {
            set { _SKU = value; }
            get { return _SKU; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ValidoSKU
        {
            set { _ValidoSKU = value; }
            get { return _ValidoSKU; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ExisteSKU
        {
            set { _ExisteSKU = value; }
            get { return _ExisteSKU; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ErrorSKU
        {
            set { _ErrorSKU = value; }
            get { return _ErrorSKU; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DescripcionErrorSKU
        {
            set { _DescripcionErrorSKU = value; }
            get { return _DescripcionErrorSKU; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string descripcionSKU
        {
            set { _descripcionSKU = value; }
            get { return _descripcionSKU; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Compras
        {
            set { _Compras = value; }
            get { return _Compras; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Beneficios
        {
            set { _Beneficios = value; }
            get { return _Beneficios; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Sugeridos
        {
            set { _Sugeridos = value; }
            get { return _Sugeridos; }
        }

        #endregion Propiedades

    }
}
