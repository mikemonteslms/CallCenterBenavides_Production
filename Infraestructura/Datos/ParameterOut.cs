using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
namespace Datos
{
    /// <summary>
    /// Clase que nos Permite Generar Parametros de Salida.
    /// </summary>
    public class ParameterOut
    {
        #region Fields

        private string _name;
        private DbType _dbType;
        private int _size;

        #endregion Fields

        #region Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public DbType DBType
        {
            get { return _dbType; }
            set { _dbType = value; }
        }
        public ParameterDirection ParameterDirection
        {
            get { return ParameterDirection.Output; }
        }
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        #endregion Properties
    }
}
