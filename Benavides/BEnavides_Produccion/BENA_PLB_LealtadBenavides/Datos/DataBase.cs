using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Globalization;
using System.Data.Odbc;
using System.Configuration;
using System.Data.SqlClient;


namespace Datos
{
    /// <summary>
    /// Clase que nos permite el Manejo de Base de Datos.
    /// </summary>
    public class DataBase
    {
        #region Methds

//        public OdbcConnection conn = new OdbcConnection();
        public OdbcCommand rs = new OdbcCommand();
        public string Err;
        public string connStr;

        public static void ManejaDB(string connectionName)
        {
//            ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings[connectionName];
            //Datos.DataBase.connStr = cs.ConnectionString;
            conectar(connectionName);
        }

        private static void conectar(string connectionName)
        {
            string Err;
            OdbcConnection conn = new OdbcConnection();
            OdbcCommand rs = new OdbcCommand(); 
            ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings[connectionName];
            

            conn.ConnectionString = cs.ConnectionString;  

            
             //ConnectionString = cs.ConnectionString;
            try
            {
                 conn.Open();
                 rs.Connection = conn;
            }
            catch (Exception ThisErr)
            {
                //Error = ThisErr.ToString();
                throw new Exception("The method or operation is not implemented.");
            }
            
            
        }
        
        //public void conectar()
        //{
        //    this.conn.ConnectionString = this.connStr;
        //    try
        //    {
        //        this.conn.Open();
        //        this.rs.Connection = this.conn;
        //    }
        //    catch (Exception ThisErr)
        //    {
        //        this.Error = ThisErr.ToString();
        //    }
        //}

        /*public void close()
        {
            if (row != null && !row.IsClosed)
            {
                row.Close();
            }
            try
            {
                rs.Dispose();
                conn.Dispose();
                conn.Close();
            }
            catch (Exception ThisErr)
            {
                this.Error = ThisErr.ToString();
            }
        }*/

        public string Error
        {
            get
            {
                return Err;
            }
            set
            {
                Err = value;
            }
        }
        
        /// <summary>
        /// Método que nos permite Ejecutar un Stored Procedure que recibe un array de Parametros de Entrada y que Regresa
        /// un DataSet.
        /// </summary>
        /// <param name="connectionString">Nombre de la Conexion a la Base de Datos establecida.</param>
        /// <param name="nameStoredProcedure">Nombre del Stored Procedure a Ejecutar.</param>
        /// <param name="arrayParametersIn">Array de Parametros de Entrada.</param>
        /// <returns>DataSet con la información encontrada en caso contrario regresa una Excepcion.</returns>
        public static DataSet ExecuteDataSet(string connectionString, string nameStoredProcedure, ParameterIn[] arrayParametersIn)
        {
            try
            {
                connectionString = "ConnectionString";
                //ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings[connectionName];
                //this.connStr = cs.ConnectionString;
                //this.conectar();


                //int tipoCorteMensual = int.Parse(ConfigurationManager.AppSettings["tipoCorteMensual"].ToString());

                //connectionString = ConfigurationManager. System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"].ToString(); 
                
                Database db;

                if (string.IsNullOrEmpty(connectionString))
                    db = DatabaseFactory.CreateDatabase();
                else
                    db = DatabaseFactory.CreateDatabase(connectionString);

                DbCommand dbCommand = db.GetStoredProcCommand(nameStoredProcedure);

                dbCommand.CommandTimeout = 3600;

                foreach (ParameterIn parameter in arrayParametersIn)
                    db.AddInParameter(dbCommand, parameter.Name, parameter.DBType, parameter.Value);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        
        public static DataSet pfizer(string connectionString, string nameStoredProcedure, ParameterIn[] arrayParametersIn)
        {
            try
            {
                connectionString = "pfizer";
                Database db;

                if (string.IsNullOrEmpty(connectionString))
                    db = DatabaseFactory.CreateDatabase();
                else
                    db = DatabaseFactory.CreateDatabase(connectionString);

                DbCommand dbCommand = db.GetStoredProcCommand(nameStoredProcedure);

                dbCommand.CommandTimeout = 3600;

                foreach (ParameterIn parameter in arrayParametersIn)
                    db.AddInParameter(dbCommand, parameter.Name, parameter.DBType, parameter.Value);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Método que nos permite Ejecutar un SP sin parametros.
        /// </summary>
        /// <param name="connectionString">Nombre de la Conexion a la Base de Datos establecida.</param>
        /// <param name="nameStoredProcedure">Nombre del Stored Procedure a Ejecutar.</param>
        /// <returns>DataSet con la información encontrada en caso contrario regresa una Excepcion.</returns>
        public static DataSet ExecuteDataSet(string connectionString, string nameStoredProcedure)
        {
            try
            {
                Database db;

                connectionString = "ConnectionString";

                if (string.IsNullOrEmpty(connectionString))
                    db = DatabaseFactory.CreateDatabase();
                else
                    db = DatabaseFactory.CreateDatabase(connectionString);

                DbCommand dbCommand = db.GetStoredProcCommand(nameStoredProcedure);

                dbCommand.CommandTimeout = 3600;

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Método que nos permite Ejecutar un Stored Procedure que recibe un array de Parametros de Salida y que Regresa
        /// un ArrayList con los Valores Obtenidos de cada Parametro de Salida.
        /// </summary>
        /// <param name="connectionString">Nombre de la Conexion a la Base de Datos establecida.</param>
        /// <param name="nameStoredProcedure">Nombre del Stored Procedure a Ejecutar.</param>
        /// <param name="arrayParametersOut">Array de Parametros de Salida.</param>
        /// <returns></returns>
        public static ArrayList ExecuteNonQuery(string connectionString, string nameStoredProcedure, ParameterOut[] arrayParametersOut)
        {
            try
            {
                Database db;

                connectionString = "ConnectionString";

                if (string.IsNullOrEmpty(connectionString))
                    db = DatabaseFactory.CreateDatabase();
                else
                    db = DatabaseFactory.CreateDatabase(connectionString);

                DbCommand dbCommand = db.GetStoredProcCommand(nameStoredProcedure);

                dbCommand.CommandTimeout = 3600;

                foreach (ParameterOut parameterOut in arrayParametersOut)
                    db.AddOutParameter(dbCommand, parameterOut.Name, parameterOut.DBType, parameterOut.Size);

                db.ExecuteNonQuery(dbCommand);

                ArrayList arrayListParametersOut = new ArrayList();

                foreach (ParameterOut parameterOut in arrayParametersOut)
                    arrayListParametersOut.Add(db.GetParameterValue(dbCommand, parameterOut.Name));

                return arrayListParametersOut;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Método que nos permite ejecutar Stored Procedure que realizan Insert, Update y Delete en la BD.
        /// </summary>
        /// <param name="connectionString">Nombre de la Conexion a la Base de Datos establecida.</param>
        /// <param name="nameStoredProcedure">Nombre del Stored Procedure a Ejecutar.</param>
        /// <param name="arrayParametersIn">Array de Parametros de Entrada.</param>
        public static int ExecuteNonQuery(string connectionString, string nameStoredProcedure, ParameterIn[] arrayParametersIn)
        {
            try
            {
                Database db;

                connectionString = "ConnectionString";

                if (string.IsNullOrEmpty(connectionString))
                    db = DatabaseFactory.CreateDatabase();
                else
                    db = DatabaseFactory.CreateDatabase(connectionString);

                DbCommand dbCommand = db.GetStoredProcCommand(nameStoredProcedure);

                dbCommand.CommandTimeout = 3600;

                foreach (ParameterIn parameterIn in arrayParametersIn)
                    db.AddInParameter(dbCommand, parameterIn.Name, parameterIn.DBType, parameterIn.Value);

                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Método que nos permite ejecutar Query en la BD.
        /// </summary>
        /// <param name="connectionString">Nombre de la Conexion a la Base de Datos establecida.</param>
        /// <param name="query">Cadena a Ejecutar.</param>
        public static DataSet ExecuteQuery(string connectionString, string query)
        {
            try
            {
                Database db;

                connectionString = "ConnectionString";

                if (string.IsNullOrEmpty(connectionString))
                    db = DatabaseFactory.CreateDatabase();
                else
                    db = DatabaseFactory.CreateDatabase(connectionString);

                DbCommand dbCommand = db.GetSqlStringCommand(query);

                dbCommand.CommandTimeout = 3600;
                return db.ExecuteDataSet(dbCommand);

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Método que permite ejecutar SP que inserta datos en DB.
        /// </summary>
        /// <param name="connectionString">Nombre de la Conexion a la Base de Datos establecida.</param>
        /// <param name="nameStoredProcedure">Nombre del SP.</param>
        /// /// <param name="arrayParametersIn">Parametros de entrada.</param>
        public static int InsertaSp(string connectionString, string nameStoredProcedure, ParameterIn[] arrayParametersIn)
        {
            try
            {
                Database db;

                connectionString = "ConnectionString";

                if (string.IsNullOrEmpty(connectionString))
                    db = DatabaseFactory.CreateDatabase();
                else
                    db = DatabaseFactory.CreateDatabase(connectionString);

                DbCommand dbCommand = db.GetStoredProcCommand(nameStoredProcedure);

                dbCommand.CommandTimeout = 3600;

                foreach (ParameterIn parameterIn in arrayParametersIn)
                    db.AddInParameter(dbCommand, parameterIn.Name, parameterIn.DBType, parameterIn.Value);

                int registros = db.ExecuteNonQuery(dbCommand);
                return registros;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }                

        #endregion Methds
    }
}
