using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Datos;
using System.Configuration;

namespace Negocio
{
    public class HerramientasApp
    {
     
        public static DataSet ObtenerLogs(string SP,int IdLog)
        {
            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@IdLog", DbType.Int32, IdLog));

                return DataBase.ExecuteDataSet(null, SP, (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet ObtenerLogsFill(string SP, string Fini, string FFin, string Delas, string Alas, string Tipolog)
        {
            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@Fini", DbType.String, Fini));
                lstParameters.Add(new ParameterIn("@FFin", DbType.String, FFin));
                lstParameters.Add(new ParameterIn("@Delas", DbType.String, Delas));
                lstParameters.Add(new ParameterIn("@Alas", DbType.String, Alas));
                lstParameters.Add(new ParameterIn("@Tipolog", DbType.String, Tipolog));

                return DataBase.ExecuteDataSet(null, SP, (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet ObtenerTiposLogs(string SP)
        {
            try
            {
                return DataBase.ExecuteDataSet(null, SP);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
