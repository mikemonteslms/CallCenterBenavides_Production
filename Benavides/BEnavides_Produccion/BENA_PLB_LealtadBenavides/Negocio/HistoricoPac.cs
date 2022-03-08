using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Negocio
{
    public class HistoricoPac
    {
        SqlTransac objSqlTransac = new SqlTransac();
        SqlParameter[] parametrosSP;

        public DataSet ObtenerHistorico(string strTarjeta)
        {
            try
            {
                parametrosSP = Parametros(strTarjeta);
                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_ObtenerMovimientos", parametrosSP);
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
