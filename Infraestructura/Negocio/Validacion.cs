using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class Validacion : ICloneable
    {
        private string _nombre;
        private string _tipo;
        private object _valor;
        private bool _valido;
        private bool _existe;
        private int _categoria;
        private string _codigoError;
        private string _descripcionError;
        private string _descripcionSKU;
        private int _compras;
        private int _beneficios;

        public string Nombre
        {
            set { _nombre = value; }
            get { return _nombre; }
        }
        public string Tipo
        {
            set { _tipo = value; }
            get { return _tipo; }
        }
        public object Valor
        {
            set { _valor = value; }
            get { return _valor; }
        }
        public bool Valido
        {
            set { _valido = value; }
            get { return _valido; }
        }
        public bool Existe
        {
            set { _existe = value; }
            get { return _existe; }
        }
        public int Categoria
        {
            set { _categoria = value; }
            get { return _categoria; }
        }
        public string CodigoError
        {
            set { _codigoError = value; }
            get { return _codigoError; }
        }
        public string DescripcionError
        {
            set { _descripcionError = value; }
            get { return _descripcionError; }
        }
        public string DescripcionSKU
        {
            set { _descripcionSKU = value; }
            get { return _descripcionSKU; }
        }
        public int Compras
        {
            set { _compras = value; }
            get { return _compras; }
        }
        public int Beneficios
        {
            set { _beneficios = value; }
            get { return _beneficios; }
        }
        public Object Clone()
        {
            Validacion validacion = new Validacion();

            validacion.Nombre = Nombre;
            validacion.Tipo = Tipo;
            validacion.Valido = Valido;
            validacion.Existe = Existe;
            validacion.Categoria = Categoria;
            validacion.CodigoError = CodigoError;
            validacion.DescripcionError = DescripcionError;
            validacion.DescripcionSKU = DescripcionSKU;
            validacion.Valor = Valor;
            validacion.Compras = Compras;
            validacion.Beneficios = Beneficios;

            return validacion;
        }
    }
}
