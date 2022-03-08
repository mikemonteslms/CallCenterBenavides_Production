using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using Entidades;
using Negocio;
using Datos;
using System.Configuration;
using System.Data.Odbc;

namespace Negocio
{
    public class Programas
    {
        #region Metodos

        private OdbcConnection conn = new OdbcConnection();
        private OdbcCommand rs = new OdbcCommand();
        //private OdbcDataReader row;
        //private string Err;
        //private string connStr;
        /// <summary>
        /// Método que nos permite obtener los datos de un programa.
        /// </summary>
        /// <param name="programa_intId">Id del Programa.</param>
        /// <returns>DataSet con la informacion del programa.</returns>
        public static DataSet ObtenerPrograma(int programa_intId)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("programa_intId", DbType.Int32, programa_intId));

                //String sConection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

                //ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["ConnectionString"];
                //this.connStr = cs.ConnectionString;
                //this.conectar();

                //miRs = DataBase.ManejaDB("ConnectionString");


                DataSet dsPrograma = DataBase.ExecuteDataSet("ConnectionString", "SP_ObtenerPrograma", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsPrograma;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ObtenerPrograma.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 3);
                throw (e);
            }
        }

        /// <summary>
        /// Método que nos perimte validar si un programa existe o no.
        /// </summary>
        /// <param name="programa_intId">Id del programa.</param>
        /// <returns>True en caso de que el programa exista, False en caso contrario.</returns>
        public static bool ExistePrograma(int programa_intId)
        {
            try
            {
                DataSet dsPrograma = ObtenerPrograma(programa_intId);

                if (dsPrograma.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion Metodos
    }
}
