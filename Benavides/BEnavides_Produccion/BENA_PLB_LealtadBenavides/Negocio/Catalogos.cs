using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Negocio
{
    public class Catalogos : ConexionBD
    {        
        SqlTransac objSqlTransac = new SqlTransac();
        SqlParameter[] parametrosSP;

        public DataSet RegresaMenu(string parametro1)
        {
            try
            {
                //SqlParameter[] parametrosSP = new SqlParameter[1];
                //parametrosSP[0] = new SqlParameter("@perfil_id", strPerfil);
                //DataSet ds = sqlTransacciones.RegresaDataSetSP("sp_PaginasxPerfil", parametrosSP);

                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@usuario", parametro1);                
                DataSet ds = objSqlTransac.RegresaDataSetSP("sp_PaginasxPerfil", parametros);               

                return ds;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public DataTable ObtenerCatalogosCuestionarioInicial(int cuestionario, int pregunta)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_ObtenerCatalogoRespuestas", conectame);
                com.CommandType = CommandType.StoredProcedure;
                
                SqlParameter p1 = new SqlParameter("@Cuestionario", cuestionario);
                SqlParameter p2 = new SqlParameter("@Pregunta", pregunta);
                p1.Value = cuestionario;
                p2.Value = pregunta;
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
        
        public DataSet DatosCatalogo(string query, string cadena)
        {
            try
            {
                parametrosSP = Parametros(query, cadena);
                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_ObtenerListadoSepomex", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DatosCatalogoPreguntas(string query, string cadena)
        {
            try
            {
                parametrosSP = Parametros(query, cadena);
                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_ObtenerListado", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DatosCatalogoSepoMex(string query, string filtro1, string filtro2)
        {
            try
            {
                parametrosSP = ParametrosSepoMex(query, filtro1, filtro2);
                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_ObtenerListadoSepomex", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DatosCatalogoPromociones(string Tarjeta = "")
        {
            try
            {
                parametrosSP = new SqlParameter[1];
                parametrosSP[0] = new SqlParameter("@tarjeta", Tarjeta);
                
                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_ObtenerCatalogoPromociones_WEB",parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DatosCatalogoPromociones(string Tarjeta, string Peques, int Seccion,int IdCategoria)
        {
            try
            {
                parametrosSP = new SqlParameter[4];
                parametrosSP[0] = new SqlParameter("@tarjeta", Tarjeta);
                parametrosSP[1] = new SqlParameter("@EsPeques", Peques);                
                parametrosSP[2] = new SqlParameter("@Seccion", Seccion);
                parametrosSP[3] = new SqlParameter("@Categoria", IdCategoria);

                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_ObtenerCatalogoPromociones_WEB", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet DatosCatalogoPromociones(string Tarjeta, string Peques, int IdCategoria)
        {
            try
            {
                parametrosSP = new SqlParameter[3];
                parametrosSP[0] = new SqlParameter("@tarjeta", Tarjeta);
                parametrosSP[1] = new SqlParameter("@EsPeques", Peques);                
                parametrosSP[2] = new SqlParameter("@Categoria", IdCategoria);

                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_ObtenerCatalogoPromociones_WEB", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet DatosCatalogoDescuentoLab(string query, string filtro1, string filtro2, string filtro3 = "")
        {
            try
            {
                //parametrosSP = ParametrosSepoMex(query, filtro1, filtro2);
                parametrosSP = new SqlParameter[4];

                parametrosSP[0] = new SqlParameter("@Catalogo", query);
                parametrosSP[1] = new SqlParameter("@Filtro1", filtro1);
                parametrosSP[2] = new SqlParameter("@Filtro2", filtro2);                
                parametrosSP[3] = new SqlParameter("@Filtro3", filtro3);

                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_ObtenerListadoLaboratios", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CargaComboFecha(string query)
        {
            try
            {
                parametrosSP = ParametrosComboFecha(query);
                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_CargaCombosFecha", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CargaComboGenero()
        {
            try
            {
                DataSet objDataset = objSqlTransac.RegresaDataSetSPnoParametros("sp_CargaComboGenero");
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DatosLlamada(string IDLlamada)
        {
            try
            {
                SqlParameter[] paramLlamada = new SqlParameter[1];

                paramLlamada[0] = new SqlParameter("@IDLlamada", IDLlamada);
                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_ObtenerDatosLlamada", paramLlamada);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlParameter[] Parametros(string query, string cadena)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@Catalogo", query);
            parameters[1] = new SqlParameter("@Cadena", cadena);

            return parameters;
        }

        public SqlParameter[] ParametrosSepoMex(string query, string filtro1, string filtro2)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter("@Catalogo", query);
            parameters[1] = new SqlParameter("@Filtro1", filtro1);
            parameters[2] = new SqlParameter("@Filtro2", filtro2);

            return parameters;
        }

        public SqlParameter[] ParametrosComboFecha(string query)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@catalogo", query);            

            return parameters;
        }

        //public DataSet DatosPaginasxPerfil(string strPerfil)
        //{
        //    try
        //    {
        //        parametrosSP = Parametros2(strPerfil);
        //        DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_PaginasxPerfil", parametrosSP);
        //        return objDataset;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DataSet DatosPaginasxPerfilMenu(string strPerfil)
        //{
        //    try
        //    {
        //        parametrosSP = Parametros2(strPerfil);
        //        DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_Menu_Perfil", parametrosSP);
        //        return objDataset;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public SqlParameter[] Parametros2(string strPerfil)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@perfil_id", strPerfil);

            return parameters;
        }

        #region ConsutlaMediosDeContacto

        public DataSet ConsutlaMediosDeContacto()
        {
            try
            {
                DataSet objDataset = objSqlTransac.RegresaDataSetSPnoParametros("sp_ConsutlaMediosDeContacto");
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion ConsutlaMediosDeContacto

    }
}
