using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Entidades
{
    [System.SerializableAttribute()]
    [XmlRootAttribute(ElementName = "Ticket", Namespace = "http://www.lms.com.mx/WebServices/Prepago", IsNullable = false)]
    [XmlTypeAttribute(TypeName = "Ticket", Namespace = "http://www.lms.com.mx/WebServices/Prepago")]
    public class Ticket
    {
        #region Atributos

        private int _Programa_intId;
        private string _TipoDato_ProgramaId;
        private bool _ValidoProgramaId;
        private bool _ExisteProgramaId;
        private string _ErrorProgramaId;
        private string _DescripcionErrorProgramaId;

        private int _Cadena_intId;
        private string _TipoDato_CadenaId;
        private bool _ValidaCadenaId;
        private bool _ExisteCadenaId;
        private string _ErrorCadenaId;
        private string _DescripcionErrorCadenaId;

        private int _Sucursal_intId;
        private string _TipoDato_SucursalId;
        private bool _ValidaSucursalId;
        private bool _ExisteSucursalId;
        private string _ErrorSucursalId;
        private string _DescripcionErrorSucursalId;

        private int _Terminal_intId;
        private string _TipoDato_TerminalId;
        private bool _ValidaTerminalId;
        private bool _ExisteTerminalId;
        private string _ErrorTerminalId;
        private string _DescripcionErrorTerminalId;

        private string _UsuarioTicket_strId;
        private string _TipoDato_UsuarioTicketId;
        private bool _ValidaUsuarioTicketId;
        private bool _ExisteUsuarioTicketId;
        private string _ErrorUsuarioTicketId;
        private string _DescripcionErrorUsuarioTicketId;

        private string _UsuarioCaptura_strId;
        private string _TipoDato_UsuarioCapturaId;
        private bool _ValidaUsuarioCapturaId;
        private bool _ExisteUsuarioCapturaId;
        private string _ErrorUsuarioCapturaId;
        private string _DescripcionErrorUsuarioCapturaId;

        private string _Tarjeta;
        private string _TipoDato_Tarjeta;
        private bool _ValidaTarjeta;
        private bool _ExisteTarjeta;
        private string _ErrorTarjeta;
        private string _DescripcionErrorTarjeta;

        private Folio[] _folios;

        private string _CotizacionId;

        private string _descripcionSKU;

        private int _NumeroCamposEncabezado;
        private int _NumeroCorrectosEncabezado;
        private int _NumeroErroresEncabezado;

        private int _NumerodePedidos;
        private int _NumeroCorrectoPedidos;
        private int _NumeroErroresPedidos;

        private int _CodigoExcepcion;
        private string _DescripcionExcepcion;

        #endregion Atributos

        #region Propiedades

        [XmlAttributeAttribute()]
        public int Programa_intId
        {
            set { _Programa_intId = value; }
            get { return _Programa_intId; }
        }
        [XmlAttributeAttribute()]
        public string TipoDato_ProgramaId
        {
            set { _TipoDato_ProgramaId = value; }
            get { return _TipoDato_ProgramaId; }
        }
        [XmlAttributeAttribute()]
        public bool ValidoProgramaId
        {
            set { _ValidoProgramaId = value; }
            get { return _ValidoProgramaId; }
        }
        [XmlAttributeAttribute()]
        public bool ExisteProgramaId
        {
            set { _ExisteProgramaId = value; }
            get { return _ExisteProgramaId; }
        }
        [XmlAttributeAttribute()]
        public string ErrorProgramaId
        {
            set { _ErrorProgramaId = value; }
            get { return _ErrorProgramaId; }
        }
        [XmlAttributeAttribute()]
        public string DescripcionErrorProgramaId
        {
            set { _DescripcionErrorProgramaId = value; }
            get { return _DescripcionErrorProgramaId; }
        }

        [XmlAttributeAttribute()]
        public int Cadena_intId
        {
            set { _Cadena_intId = value; }
            get { return _Cadena_intId; }
        }
        [XmlAttributeAttribute()]
        public string TipoDato_CadenaId
        {
            set { _TipoDato_CadenaId = value; }
            get { return _TipoDato_CadenaId; }
        }
        [XmlAttributeAttribute()]
        public bool ValidaCadenaId
        {
            set { _ValidaCadenaId = value; }
            get { return _ValidaCadenaId; }
        }
        [XmlAttributeAttribute()]
        public bool ExisteCadenaId
        {
            set { _ExisteCadenaId = value; }
            get { return _ExisteCadenaId; }
        }
        [XmlAttributeAttribute()]
        public string ErrorCadenaId
        {
            set { _ErrorCadenaId = value; }
            get { return _ErrorCadenaId; }
        }
        [XmlAttributeAttribute()]
        public string DescripcionErrorCadenaId
        {
            set { _DescripcionErrorCadenaId = value; }
            get { return _DescripcionErrorCadenaId; }
        }

        [XmlAttributeAttribute()]
        public int Sucursal_intId
        {
            set { _Sucursal_intId = value; }
            get { return _Sucursal_intId; }
        }
        [XmlAttributeAttribute()]
        public string TipoDato_SucursalId
        {
            set { _TipoDato_SucursalId = value; }
            get { return _TipoDato_SucursalId; }
        }
        [XmlAttributeAttribute()]
        public bool ValidaSucursalId
        {
            set { _ValidaSucursalId = value; }
            get { return _ValidaSucursalId; }
        }
        [XmlAttributeAttribute()]
        public bool ExisteSucursalId
        {
            set { _ExisteSucursalId = value; }
            get { return _ExisteSucursalId; }
        }
        [XmlAttributeAttribute()]
        public string ErrorSucursalId
        {
            set { _ErrorSucursalId = value; }
            get { return _ErrorSucursalId; }
        }
        [XmlAttributeAttribute()]
        public string DescripcionErrorSucursalId
        {
            set { _DescripcionErrorSucursalId = value; }
            get { return _DescripcionErrorSucursalId; }
        }

        [XmlAttributeAttribute()]
        public int Terminal_intId
        {
            set { _Terminal_intId = value; }
            get { return _Terminal_intId; }
        }
        [XmlAttributeAttribute()]
        public string TipoDato_TerminalId
        {
            set { _TipoDato_TerminalId = value; }
            get { return _TipoDato_TerminalId; }
        }
        [XmlAttributeAttribute()]
        public bool ValidaTerminalId
        {
            set { _ValidaTerminalId = value; }
            get { return _ValidaTerminalId; }
        }
        [XmlAttributeAttribute()]
        public bool ExisteTerminalId
        {
            set { _ExisteTerminalId = value; }
            get { return _ExisteTerminalId; }
        }
        [XmlAttributeAttribute()]
        public string ErrorTerminalId
        {
            set { _ErrorTerminalId = value; }
            get { return _ErrorTerminalId; }
        }
        [XmlAttributeAttribute()]
        public string DescripcionErrorTerminalId
        {
            set { _DescripcionErrorTerminalId = value; }
            get { return _DescripcionErrorTerminalId; }
        }

        [XmlAttributeAttribute()]
        public string UsuarioTicket_strId
        {
            set { _UsuarioTicket_strId = value; }
            get { return _UsuarioTicket_strId; }
        }
        [XmlAttributeAttribute()]
        public string TipoDato_UsuarioTicketId
        {
            set { _TipoDato_UsuarioTicketId = value; }
            get { return _TipoDato_UsuarioTicketId; }
        }
        [XmlAttributeAttribute()]
        public bool ValidaUsuarioTicketId
        {
            set { _ValidaUsuarioTicketId = value; }
            get { return _ValidaUsuarioTicketId; }
        }
        [XmlAttributeAttribute()]
        public bool ExisteUsuarioTicketId
        {
            set { _ExisteUsuarioTicketId = value; }
            get { return _ExisteUsuarioTicketId; }
        }
        [XmlAttributeAttribute()]
        public string ErrorUsuarioTicketId
        {
            set { _ErrorUsuarioTicketId = value; }
            get { return _ErrorUsuarioTicketId; }
        }
        [XmlAttributeAttribute()]
        public string DescripcionErrorUsuarioTicketId
        {
            set { _DescripcionErrorUsuarioTicketId = value; }
            get { return _DescripcionErrorUsuarioTicketId; }
        }

        [XmlAttributeAttribute()]
        public string UsuarioCaptura_strId
        {
            set { _UsuarioCaptura_strId = value; }
            get { return _UsuarioCaptura_strId; }
        }
        [XmlAttributeAttribute()]
        public string TipoDato_UsuarioCapturaId
        {
            set { _TipoDato_UsuarioCapturaId = value; }
            get { return _TipoDato_UsuarioCapturaId; }
        }
        [XmlAttributeAttribute()]
        public bool ValidaUsuarioCapturaId
        {
            set { _ValidaUsuarioCapturaId = value; }
            get { return _ValidaUsuarioCapturaId; }
        }
        [XmlAttributeAttribute()]
        public bool ExisteUsuarioCapturaId
        {
            set { _ExisteUsuarioCapturaId = value; }
            get { return _ExisteUsuarioCapturaId; }
        }
        [XmlAttributeAttribute()]
        public string ErrorUsuarioCapturaId
        {
            set { _ErrorUsuarioCapturaId = value; }
            get { return _ErrorUsuarioCapturaId; }
        }
        [XmlAttributeAttribute()]
        public string DescripcionErrorUsuarioCapturaId
        {
            set { _DescripcionErrorUsuarioCapturaId = value; }
            get { return _DescripcionErrorUsuarioCapturaId; }
        }

        [XmlAttributeAttribute()]
        public string Tarjeta
        {
            set { _Tarjeta = value; }
            get { return _Tarjeta; }
        }
        [XmlAttributeAttribute()]
        public string TipoDato_Tarjeta
        {
            set { _TipoDato_Tarjeta = value; }
            get { return _TipoDato_Tarjeta; }
        }
        [XmlAttributeAttribute()]
        public bool ValidaTarjeta
        {
            set { _ValidaTarjeta = value; }
            get { return _ValidaTarjeta; }
        }
        [XmlAttributeAttribute()]
        public bool ExisteTarjeta
        {
            set { _ExisteTarjeta = value; }
            get { return _ExisteTarjeta; }
        }
        [XmlAttributeAttribute()]
        public string ErrorTarjeta
        {
            set { _ErrorTarjeta = value; }
            get { return _ErrorTarjeta; }
        }
        [XmlAttributeAttribute()]
        public string DescripcionErrorTarjeta
        {
            set { _DescripcionErrorTarjeta = value; }
            get { return _DescripcionErrorTarjeta; }
        }

        [XmlElementAttribute("Folio", typeof(Folio))]
        public Folio[] Folios
        {
            set { _folios = value; }
            get { return _folios; }
        }

        [XmlAttributeAttribute()]
        public string CotizacionId
        {
            set { _CotizacionId = value; }
            get { return _CotizacionId; }
        }

        [XmlAttributeAttribute()]
        public string descripcionSKU
        {
            set { _descripcionSKU = value; }
            get { return _descripcionSKU; }
        }

        [XmlAttributeAttribute()]
        public int NumeroCamposEncabezado
        {
            set { _NumeroCamposEncabezado = value; }
            get { return _NumeroCamposEncabezado; }
        }
        [XmlAttributeAttribute()]
        public int NumeroCorrectosEncabezado
        {
            set { _NumeroCorrectosEncabezado = value; }
            get { return _NumeroCorrectosEncabezado; }
        }
        [XmlAttributeAttribute()]
        public int NumeroErroresEncabezado
        {
            set { _NumeroErroresEncabezado = value; }
            get { return _NumeroErroresEncabezado; }
        }
        [XmlAttributeAttribute()]
        public int NumerodePedidos
        {
            set { _NumerodePedidos = value; }
            get { return _NumerodePedidos; }
        }
        [XmlAttributeAttribute()]
        public int NumeroCorrectoPedidos
        {
            set { _NumeroCorrectoPedidos = value; }
            get { return _NumeroCorrectoPedidos; }
        }
        [XmlAttributeAttribute()]
        public int NumeroErronesPedidos
        {
            set { _NumeroErroresPedidos = value; }
            get { return _NumeroErroresPedidos; }
        }

        [XmlAttributeAttribute()]
        public int CodigoExcepcion
        {
            set { _CodigoExcepcion = value; }
            get { return _CodigoExcepcion; }
        }
        [XmlAttributeAttribute()]
        public string DescripcionExcepcion
        {
            set { _DescripcionExcepcion = value; }
            get { return _DescripcionExcepcion; }
        }

        #endregion Propiedades
    }
}
