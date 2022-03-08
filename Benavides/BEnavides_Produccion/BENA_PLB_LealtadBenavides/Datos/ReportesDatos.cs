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
    public class ReportesDatos
    {

        public static DataSet ExecuteDataSet(string connectionString, string nameStoredProcedure, ParameterIn[] arrayParametersIn)
        {
            try
            {
                connectionString = "ConectaReportes";
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
                throw new ApplicationException(ex.Message);
            }
        }

        public DataTable ObtenerDataTable(string nombreSP)
        {
            try
            {
                SqlConnection conectame = new SqlConnection();

                conectame = new SqlConnection(ConfigurationManager.ConnectionStrings["ConectaReportes"].ConnectionString);
            
                SqlCommand com = new SqlCommand(nombreSP, conectame);
                com.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public DataTable ObtenerDataTable(string nombreSP, int parametro)
        {
            try
            {
                SqlConnection conectame = new SqlConnection();

                conectame = new SqlConnection(ConfigurationManager.ConnectionStrings["ConectaReportes"].ConnectionString);

                SqlCommand com = new SqlCommand(nombreSP, conectame);
                com.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@parametro", SqlDbType.VarChar, 19);
                p1.Value = parametro;
                com.Parameters.Add(p1);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }        
                
        public DataTable ObtenerDataTable(string nombreSP, string var1, string var2)
        {
            try
            {
                SqlConnection conectame = new SqlConnection();

                conectame = new SqlConnection(ConfigurationManager.ConnectionStrings["ConectaReportes"].ConnectionString);
            
                SqlCommand com = new SqlCommand(nombreSP, conectame);
                com.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@FechaIni", SqlDbType.VarChar, 19);
                SqlParameter p2 = new SqlParameter("@FechaFin", SqlDbType.VarChar, 19);
                p1.Value = var1;
                p2.Value = var2;
                com.Parameters.Add(p1);
                com.Parameters.Add(p2);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }




        #region ExecuteDataSetConnectionString

        public static DataSet ExecuteDataSetConnectionString(string connectionString, string nameStoredProcedure, ParameterIn[] arrayParametersIn)
        {
            try
            {
                connectionString = "ConnectionString";
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
                throw new ApplicationException(ex.Message);
            }
        }

        #endregion ExecuteDataSetConnectionString
    }
}
