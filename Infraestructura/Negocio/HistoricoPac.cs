using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;
using DataSQL;

namespace Negocio
{
    public class HistoricoPac
    {

        ClassDataSQL1 objSqlTransac = null;
        SqlParameter[] parametrosSP;

        public DataSet ObtenerHistorico(string strTarjeta)
        {
            try
            {
                objSqlTransac=new ClassDataSQL1(); 
                parametrosSP = Parametros(strTarjeta);
                DataSet objDataset = objSqlTransac.LlenaDatosDataSet("sp_ObtenerMovimientos", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlParameter[] Parametros(string strTarjeta)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@strTarjeta", strTarjeta);

            return parameters;
        }
    }
}
