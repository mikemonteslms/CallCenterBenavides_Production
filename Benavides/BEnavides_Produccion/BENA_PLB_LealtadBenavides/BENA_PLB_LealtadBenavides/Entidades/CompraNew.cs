using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Entidades
{
    [System.SerializableAttribute()]
    [XmlRootAttribute(ElementName = "Compra", Namespace = "http://www.lms.com.mx/WebServices/Prepago", IsNullable = false)]
    [XmlTypeAttribute(TypeName = "Compra", Namespace = "http://www.lms.com.mx/WebServices/Prepago")]
    public class CompraNew
    {
        #region Atributos

        private string _ProgramaID;
        private string _Llave;
        private int _Programa_intId;        
        private int _Cadena_intId;
        private int _Sucursal_intId;
        private int _Terminal_intId;
        private string _UsuarioTicket_strId;
        private string _UsuarioCaptura_strId;
        private string _Tarjeta;
        private Pedido[] _pedidos;

        #endregion Atributos

        #region Propiedades

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Llave
        {
            set { _Llave = value; }
            get { return _Llave; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ProgramaID
        {
            set { _ProgramaID = value; }
            get { return _ProgramaID; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Programa_intId
        {
            set { _Programa_intId = value; }
            get { return _Programa_intId; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Cadena_intId
        {
            set { _Cadena_intId = value; }
            get { return _Cadena_intId; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Sucursal_intId
        {
            set { _Sucursal_intId = value; }
            get { return _Sucursal_intId; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Terminal_intId
        {
            set { _Terminal_intId = value; }
            get { return _Terminal_intId; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UsuarioTicket_strId
        {
            set { _UsuarioTicket_strId = value; }
            get { return _UsuarioTicket_strId; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UsuarioCaptura_strId
        {
            set { _UsuarioCaptura_strId = value; }
            get { return _UsuarioCaptura_strId; }
        }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Tarjeta
        {
            set { _Tarjeta = value; }
            get { return _Tarjeta; }
        }

        [System.Xml.Serialization.XmlElementAttribute("Pedido", typeof(Pedido))]
        public Pedido[] Pedidos
        {
            set { _pedidos = value; }
            get { return _pedidos; }
        }

        #endregion Propiedades
    }
}