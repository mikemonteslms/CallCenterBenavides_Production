using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;
using DataSQL;
namespace Negocio
{
    public class ActualizaDatos
    {

        ClassDataSQL1 objSqlTransac = null;
        SqlParameter[] parametrosSP;

        public DataSet DatosUsuario(int IntTipoConsulta, int intTipoListado, string strNumero,
                    string strFiltroQry, string strXMLCampos)
        {
            try
            {
                objSqlTransac = new ClassDataSQL1();
                parametrosSP = Parametros(IntTipoConsulta, intTipoListado, strNumero, strFiltroQry, strXMLCampos);
                DataSet objDataset = objSqlTransac.LlenaDatosDataSet("sp_ObtenerUsuario", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DatosPagina(int IntTipoConsulta, int intTipoListado, string strNumero,
                    string strFiltroQry, string strXMLCampos)
        {
            try
            {
                objSqlTransac = new ClassDataSQL1();
                parametrosSP = Parametros(IntTipoConsulta, intTipoListado, strNumero, strFiltroQry, strXMLCampos);
                DataSet objDataset = objSqlTransac.LlenaDatosDataSet("sp_ObtenerPagina", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DatosPerfil(int IntTipoConsulta, int intTipoListado, string strNumero,
                    string strFiltroQry, string strXMLCampos)
        {
            try
            {
                objSqlTransac = new ClassDataSQL1();
                parametrosSP = Parametros(IntTipoConsulta, intTipoListado, strNumero, strFiltroQry, strXMLCampos);
                DataSet objDataset = objSqlTransac.LlenaDatosDataSet("sp_ObtenerPerfil", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DireccionesUsuario(string strUsuario)
        {
            try
            {
                objSqlTransac = new ClassDataSQL1();
                parametrosSP = Parametros(strUsuario);
                DataSet objDataset = objSqlTransac.LlenaDatosDataSet("sp_DirecionesxUsuario", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlParameter[] Parametros(string strUsuario)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ClaveUsuario", strUsuario);

            return parameters;
        }

        public DataSet consultaTableSP(string query, int IntTipoConsulta, int intTipoListado, string strNumero,
                    string strFiltroQry, string strXMLCampos)
        {
            try
            {
                objSqlTransac = new ClassDataSQL1();
                parametrosSP = Parametros(IntTipoConsulta, intTipoListado, strNumero, strFiltroQry, strXMLCampos);
                DataSet objDataset = objSqlTransac.LlenaDatosDataSet(query, parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet consultaDatosCombo(string query, int IntTipoConsulta, int intTipoListado, string strNumero,
                    string strFiltroQry, string strXMLCampos)
        {
            try
            {
                objSqlTransac = new ClassDataSQL1();
                parametrosSP = Parametros(IntTipoConsulta, intTipoListado, strNumero, strFiltroQry, strXMLCampos);
                DataSet objDataset = objSqlTransac.LlenaDatosDataSet(query, parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlParameter[] Parametros(int IntTipoConsulta, int intTipoListado, string strNumero,
            string strFiltroQry, string strXMLCampos)
        {
            SqlParameter[] parameters = new SqlParameter[5];

            parameters[0] = new SqlParameter("@IntTipoConsulta", IntTipoConsulta);
            parameters[1] = new SqlParameter("@intTipoListado", intTipoListado);
            parameters[2] = new SqlParameter("@strNumero", strNumero);
            parameters[3] = new SqlParameter("@strConsulta", strFiltroQry);
            parameters[4] = new SqlParameter("@strXMLCampos", strXMLCampos);

            return parameters;
        }

        
    }
}
