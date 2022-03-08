using System;
using System.Collections.Generic;
using System.Text;


namespace Entidades
{
    public class Cotizacion
    {
        #region Atributos

        private int _ID;
        private string _CotizacionId;
        private string _TarjetaC_strNumero;
        private string _Presentacion_intSKU;
        private string _Mecanica_strEAN13Obsequio;
        private bool _DobleMec;
        private int _CompraAcumulada;
        private int _BeneficioAcumulado;
        private int _BeneficioMesActual;
        private int _EstaCompra;
        private int _MecanicaCompra;
        private int _MecanicaRegalo;
        private int _TotalAnalizar;
        private int _BeneficiosGanados;
        private int _BeneficiosDeberiaTener;
        private int _LimiteMensual;
        private int _BeneficiosOtorgar;
        private int _Compras;
        private int _Sugerido;
        private DateTime? _Fecha;
        private int _Estatus;

        #endregion Atributos

        #region Propiedades

        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public string CotizacionId
        {
            set { _CotizacionId = value; }
            get { return _CotizacionId; }
        }
        public string TarjetaC_strNumero
        {
            set { _TarjetaC_strNumero = value; }
            get { return _TarjetaC_strNumero; }
        }
        public string Presentacion_intSKU
        {
            set { _Presentacion_intSKU = value; }
            get { return _Presentacion_intSKU; }
        }
        public string Mecanica_strEAN13Obsequio
        {
            set { _Mecanica_strEAN13Obsequio = value; }
            get { return _Mecanica_strEAN13Obsequio; }
        }
        public bool DobleMec
        {
            set { _DobleMec = value; }
            get { return _DobleMec; }
        }
        public int CompraAcumulada
        {
            set { _CompraAcumulada = value; }
            get { return _CompraAcumulada; }
        }
        public int BeneficioAcumulado
        {
            set { _BeneficioAcumulado = value; }
            get { return _BeneficioAcumulado; }
        }
        public int BeneficioMesActual
        {
            set { _BeneficioMesActual = value; }
            get { return _BeneficioMesActual; }
        }
        public int EstaCompra
        {
            set { _EstaCompra = value; }
            get { return _EstaCompra; }
        }
        public int MecanicaCompra
        {
            set { _MecanicaCompra = value; }
            get { return _MecanicaCompra; }
        }
        public int MecanicaRegalo
        {
            set { _MecanicaRegalo = value; }
            get { return _MecanicaRegalo; }
        }
        public int TotalAnalizar
        {
            set { _TotalAnalizar = value; }
            get { return _TotalAnalizar; }
        }
        public int BeneficiosGanados
        {
            set { _BeneficiosGanados = value; }
            get { return _BeneficiosGanados; ; }
        }
        public int BeneficiosDeberiaTener
        {
            set { _BeneficiosDeberiaTener = value; }
            get { return _BeneficiosDeberiaTener; }
        }
        public int LimiteMensual
        {
            set { _LimiteMensual = value; }
            get { return _LimiteMensual; }
        }
        public int BeneficiosOtorgar
        {
            set { _BeneficiosOtorgar = value; }
            get { return _BeneficiosOtorgar; }
        }
        public int Compras
        {
            set { _Compras = value; }
            get { return _Compras; }
        }
        public int Sugerido
        {
            set { _Sugerido = value; }
            get { return _Sugerido; }
        }
        public DateTime? Fecha
        {
            set { _Fecha = value; }
            get { return _Fecha; }
        }
        public int Estatus
        {
            set { _Estatus = value; }
            get { return _Estatus; }
        }

        #endregion Propiedades
    }
}
