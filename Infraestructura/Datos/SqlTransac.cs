using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace Datos
{
    public class SqlTransac
    {
        ConexionBD objConexionBD = new ConexionBD();
        DataSet objDS;

        public DataSet RegresaDataSetNoSP(string strQuery)
        {
            SqlCommand oCmd = new SqlCommand(strQuery);
            try
            {
                oCmd.CommandTimeout = 600;

                SqlConnection oCnn = new SqlConnection(objConexionBD.Conexion());
                oCmd.Connection = oCnn;
                oCnn.Open();
                SqlDataAdapter oDA = new SqlDataAdapter(oCmd);
                DataSet objDS = new DataSet();
                oDA.Fill(objDS);
                oCnn.Close();


                return objDS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataSet RegresaDataSetSP(string spName, SqlParameter[] parameters)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.CommandText = spName;
            oCmd.Parameters.AddRange(parameters);
            oCmd.CommandType = CommandType.StoredProcedure;

            try
            {
                // objDS = SqlHelper.ExecuteDataset(objConexionBD.Conexion(), CommandType.StoredProcedure, spName, parameters);
                //'Y finalmente el Timeout que quieras (0 = a infinito)                
                oCmd.CommandTimeout = 0;

                SqlConnection oCnn = new SqlConnection(objConexionBD.Conexion());

                oCmd.Connection = oCnn;
                oCnn.Open();
                SqlDataAdapter oDA = new SqlDataAdapter(oCmd);
                DataSet objDS = new DataSet();
                oDA.Fill(objDS);
                oCnn.Close();

                return objDS;
            }
            catch(Exception ex)
            {
                throw(ex);
            }
        }

        public int RegresaIntSP(string spName, SqlParameter[] parameters)
        {
            try
            {

                int n = SqlHelper.ExecuteNonQuery(objConexionBD.Conexion(), CommandType.StoredProcedure, spName, parameters);

                return n;
            }

            catch
            {
                throw;
            }
        }

        public DataSet RegresaDataSetSPnoParametros(string spName)
        {
            try
            {
                objDS = SqlHelper.ExecuteDataset(objConexionBD.Conexion(), CommandType.StoredProcedure, spName);

                return objDS;
            }
            catch
            {
                throw;
            }
        }


        public int InsertarNoSp(string strQuery)
        {
            try
            {
                int n = SqlHelper.ExecuteNonQuery(objConexionBD.Conexion(), CommandType.Text, strQuery);

                return n;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertarSp(string spName, SqlParameter[] parameters)
        {
            try
            {
                //parameters = SqlHelperParameterCache.GetSpParameterSet(objConexionBD.Conexion(), spName, false);
                int strRegresa = SqlHelper.ExecuteNonQuery(objConexionBD.Conexion(), CommandType.StoredProcedure, spName, parameters);

                return strRegresa;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public int ActualizaNoSp(string strQuery)
        {
            int n = SqlHelper.ExecuteNonQuery(objConexionBD.Conexion(), CommandType.Text, strQuery);
            return n;
        }
        public int ActualizaSp(string spName, SqlParameter[] parameters)
        {
            try
            {
                int n = SqlHelper.ExecuteNonQuery(objConexionBD.Conexion(), CommandType.StoredProcedure, spName, parameters);
                return n;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public int RegresaNumeroRegistrosEncontrados(string strQuery)
        {
            try
            {
                DataSet objDS = SqlHelper.ExecuteDataset(objConexionBD.Conexion(), CommandType.Text, strQuery);
                int n = objDS.Tables[0].Rows.Count;
                return n;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
