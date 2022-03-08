using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos
{
    public class ConexionBD
    {
        public string Conexion()
        {
            string strConexion = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            return strConexion;
        }

        public SqlConnection conectame;
        public ConexionBD()
        {
            conectame = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            //conectame = new SqlConnection(ConfigurationManager.ConnectionStrings["pfizer"].ConnectionString);
        }

        


    }


}
