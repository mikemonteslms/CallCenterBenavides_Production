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
    public class ValidacionCotizacion
    {
        #region Metodos
        
        private OdbcConnection conn = new OdbcConnection();
        private OdbcCommand rs = new OdbcCommand();
        //private OdbcDataReader row;
        //private string Err;
        //private string connStr;

        /// <summary>
        /// Método que nos perimte validar si un programa existe o no.
        /// </summary>
        /// <param name="tarjeta">Numero de la tarjeta.</param>
        /// <returns>True en caso de que exista una cotizacion, false en caso contrario.</returns>
        public static bool ExisteCotizacionPendiente(int tarjeta)
        {
            try
            {
                DataSet dsRevisarCotizacion = RevisarCotizacion(tarjeta);

                if (dsRevisarCotizacion.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Método que nos permite saber si se tiene una cotizacion pendiente por cerrar, con la finalidad de que no se pueda crear otra nueva cotizacion en otro punto.
        /// </summary>
        /// <param name="tarjeta">Numero de la tarjeta.</param>
        /// <returns>DataSet con la informacion del programa.</returns>
        /// 
        public static DataSet RevisarCotizacion(int tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("tarjeta", DbType.Int32, tarjeta));

                //String sConection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

                //ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["ConnectionString"];
                //this.connStr = cs.ConnectionString;
                //this.conectar();

                //miRs = DataBase.ManejaDB("ConnectionString");


                DataSet dsRevisarCotizacion = DataBase.ExecuteDataSet("ConnectionString", "SP_RevisaCotizacion", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsRevisarCotizacion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_RevisaCotizacion.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 3);
                throw (e);
            }
        }

        #endregion

    }
}
