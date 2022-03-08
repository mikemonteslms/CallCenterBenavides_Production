using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Entidades
{
    [System.SerializableAttribute()]
    [XmlRootAttribute(ElementName = "consultaTarjeta", Namespace = "http://www.lms.com.mx/WebServices/Prepago", IsNullable = false)]
    [XmlTypeAttribute(TypeName = "consultaTarjeta", Namespace = "http://www.lms.com.mx/WebServices/Prepago")]
    public class consultaTarjeta
    {
        #region Atributos

        private string _ProgramaID;
        private string _Llave;
        private string _Tarjeta;        

        #endregion Atributos

        #region Propiedades

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ProgramaID
        {
            set { _ProgramaID = value; }
            get { return _ProgramaID; }
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
