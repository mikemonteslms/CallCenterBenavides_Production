using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatReportes : ConexionBD
    {

        public DataSet ObtenerReporteCasosInusuales(int Tipo)
        {
            try
            {
                SqlCommand com = new SqlCommand("SP_XLSRepInusuales", conectame);
                com.CommandType = CommandType.StoredProcedure;
                
                SqlParameter p1 = new SqlParameter("@Tipo", SqlDbType.VarChar, 19);
                p1.Value = Tipo;
                com.Parameters.Add(p1);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
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


    }
}
