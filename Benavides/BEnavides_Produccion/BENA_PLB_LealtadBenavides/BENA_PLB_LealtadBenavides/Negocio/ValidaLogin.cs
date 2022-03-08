using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Negocio
{
    public class ValidaLogin
    {
        Datos.SqlTransac objSqlTransac = new SqlTransac();
        SqlParameter[] parametrosSP;

        public DataSet ValidaUsuario(string strUsuario, string strPassword, string strNombreEquipo, string strDireccionIP)
        {
            try
            {
                parametrosSP = Parametros(strUsuario, strPassword, strNombreEquipo, strDireccionIP);
                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_ValidaPassword", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlParameter[] Parametros(string strUsuario, string strPassword, string strNombreEquipo, string strDireccionIP)
        {
            SqlParameter[] parameters = new SqlParameter[4];

            parameters[0] = new SqlParameter("@Usuario", strUsuario);
            parameters[1] = new SqlParameter("@Password", strPassword);
            parameters[2] = new SqlParameter("@IDEquipo", strNombreEquipo);
            parameters[3] = new SqlParameter("@IPAddress", strDireccionIP);

            return parameters;
        }

        public DataSet ValidaPerfil(string strPerfil)
        {
            try
            {
                parametrosSP = Parametros(strPerfil);
                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_PaginasxPerfil", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlParameter[] Parametros(string strPerfil)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@perfil_id", strPerfil);

            return parameters;
        }
    }
}
