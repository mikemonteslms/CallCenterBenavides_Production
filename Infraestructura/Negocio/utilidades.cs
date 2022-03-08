using System;
using System.Data;
using Datos;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace Negocio
{
    public class Utilidades
    {
        public DataSet ObtenerDatos(string cnnDbase, string cadena)
        {
            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@cadena", DbType.String, cadena));

                return DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, "sp_datosvarios", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int EjecutaTranSQL(string cnnDBase, string Datos)
        {
            int Noreg = 0;
            SqlCommand cmd = null;
            SqlConnection cnn = null;
            cnn = new SqlConnection(cnnDBase);
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Datos;
                cmd.CommandTimeout = 600000;
                if (cnn.State.Equals(ConnectionState.Closed))
                {
                    cnn.Open();
                }
                Noreg = cmd.ExecuteNonQuery();
                SqlConnection.ClearPool(cnn);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            finally
            {
                if (null != cmd)
                    cmd.Dispose();
                SqlConnection.ClearPool(cnn);
                if (cnn.State.Equals(ConnectionState.Open))
                {
                    cnn.Close();
                }
            }
            return Noreg;
        }
    }
}
