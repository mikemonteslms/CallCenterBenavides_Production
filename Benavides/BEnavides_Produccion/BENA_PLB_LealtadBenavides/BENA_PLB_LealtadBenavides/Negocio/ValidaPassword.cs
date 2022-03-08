using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Negocio
{
    public class ValidaPassword
    {
        SqlTransac objSqlTransac = new SqlTransac();
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

        public DataSet ObtienePassword(string strUsuario, string strFechaNac, string strCorreoElectronico)
        {
            try
            {
                parametrosSP = Parametros(strUsuario, strFechaNac, strCorreoElectronico);
                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_RecuperaPassword", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlParameter[] Parametros(string strUsuario, string strFechaNac, string strCorreoElectronico)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@FechaNacimiento", strFechaNac);
            parameters[1] = new SqlParameter("@CorreoElectronico", strCorreoElectronico);
            parameters[2] = new SqlParameter("@Usuario", strUsuario);

            return parameters;
        }

        public DataSet CambiaPassword(string strUsuario, string strPassword, string strIdentificador, int intTipoCambio)
        {
            try
            {
                parametrosSP = Parametros(strUsuario, strPassword, strIdentificador, intTipoCambio);
                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_ActualizaPassword", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlParameter[] Parametros(string strUsuario, string strPassword, string strIdentificador, int intTipoCambio)
        {
            SqlParameter[] parameters = new SqlParameter[4];

            parameters[0] = new SqlParameter("@Usuario", strUsuario);
            parameters[1] = new SqlParameter("@Password", strPassword);
            parameters[2] = new SqlParameter("@Identificador", strIdentificador);
            parameters[3] = new SqlParameter("@TipoCambio", intTipoCambio);

            return parameters;
        }
    }
}
