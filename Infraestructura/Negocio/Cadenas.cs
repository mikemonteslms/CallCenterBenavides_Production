using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;
using DataSQL;
namespace Negocio
{
    public class Cadenas
    {
        ClassDataSQL1 objClassDataSQL1=null;
        #region Atributos

        private int _Cadena_intId;
        private string _Cadena_strNombre;
        private string _Cadena_strContacto;
        private string _Cadena_srTelefonoContacto;
        private int _Cadena_intParticipa;
        private DateTime? _Cadena_dateFechaAlta;
        private string _Cadena_strUsuarioAlta;

        #endregion Atributos

        #region Propiedades

        public int Cadena_intId
        {
            set { _Cadena_intId = value; }
            get { return _Cadena_intId; }
        }
        public string Cadena_strNombre
        {
            set { _Cadena_strNombre = value; }
            get { return _Cadena_strNombre; }
        }
        public string Cadena_strContacto
        {
            set { _Cadena_strContacto = value; }
            get { return _Cadena_strContacto; }
        }
        public string Cadena_strTelefonoContacto
        {
            set { _Cadena_srTelefonoContacto = value; }
            get { return _Cadena_srTelefonoContacto; }
        }
        public int Cadena_intParticipa
        {
            set { _Cadena_intParticipa = value; }
            get { return _Cadena_intParticipa; }
        }
        public DateTime? Cadena_dateFechaAlta
        {
            set { _Cadena_dateFechaAlta = value; }
            get { return _Cadena_dateFechaAlta; }
        }
        public string Cadena_strUsuarioAlta
        {
            set { _Cadena_strUsuarioAlta = value; }
            get { return _Cadena_strUsuarioAlta; }
        }

        #endregion Propiedades

        #region Metodos

        /// <summary>
        /// Método que nos permite obtener el listado de Cadenas.
        /// </summary>
        /// <returns>DataSet con las Cadenas Obtenidas.</returns>
        public static DataSet ObtenerCadenas()
        {
            try
            {
                DataSet dsCadenas = DataBase.ExecuteDataSet(null, "SP_ObtenerCadenas");

                return dsCadenas;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ObtenerCadenas.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 1);
                throw (e);
            }
        }
        /// <summary>
        /// Método que nos permite obtener la informacion de una Cadena.
        /// </summary>
        /// <param name="cadena_intId">Id de la Cadena.</param>
        /// <returns>DataSet con la informacion de la Cadena.</returns>
        public static DataSet ObtenerCadena(int cadena_intId)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("cadena_intId", DbType.Int32, cadena_intId));

                DataSet dsCadena = DataBase.ExecuteDataSet(null, "SP_ObtenerCadena", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCadena;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ObtenerCadena.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 1);
                throw (e);
            }
        }
        /// <summary>
        /// Método que nos permite validar si existe una cadena o no.
        /// </summary>
        /// <param name="cadena_intId">Id de la Cadena.</param>
        /// <returns>True en el caso de que la Cadena exista, False en caso contrario.</returns>
        public static bool ExisteCadena(int cadena_intId)
        {
            try
            {
                DataSet dsCadena = ObtenerCadena(cadena_intId);

                if (dsCadena.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Método que nos permite Agregar Cadenas a la BD.
        /// </summary>

        public string  AltaCadenas(List<Entidades.Cadenas> listaCadenas, string strUsuario)
        {
            objClassDataSQL1 = new ClassDataSQL1();
             try
             {
                 string strCadena = ParsearInformacionCadena(listaCadenas);
                 SqlParameter[] parametrosSP = new SqlParameter[2];
                 parametrosSP[0] = new SqlParameter("@strCadena", strCadena);
                 parametrosSP[1] = new SqlParameter("@strUsuario", strUsuario);

                 DataSet oDS = objClassDataSQL1.LlenaDatosDataSet("sp_InsertaCadena", parametrosSP);
                 
                 string strResultado="";
                 for (int j = 0; j<oDS.Tables[0].Columns.Count; j++)
                 {
                     strResultado = strResultado + "|" + oDS.Tables[0].Rows[0][j].ToString();
                 }
                 return strResultado;
            }
            catch (Exception ex)
            {
                //Error 3:Error al Ejecutar el Stored Procedure sp_InsertaCadena.
                Exception e = new Exception("Error 3", ex);
                //|0|Inserción en Catalogo de Cadenas Se efectuo Adecuadamente||1|0
                return "|error 3|Error al Ejecutar el Stored Procedure sp_InsertaCadena||0|0";
                //throw(e);
            }
        }
            /// <summary>
        /// Método que nos permite Generar los Tickets XML.
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        private static string ParsearInformacionCadena(List<Entidades.Cadenas> listaCadenas)
        {
            try
            {
                StringBuilder sb = new StringBuilder();


                sb.Append("<CadenaXML>");

                
                for (int i = 0; i < listaCadenas.Count; i++)
                {
                    //<Reg><Cadena_intID>1</Cadena_intID><Cadena_strNombre>Locatel</Cadena_strNombre><Cadena_intParticipa>1</Cadena_intParticipa></Reg>
                    sb.Append("<Reg>");
                    sb.Append("<Cadena_intID>");
                    sb.Append(listaCadenas[i].CadenaIntID);
                    sb.Append("</Cadena_intID>");
                    sb.Append("<Cadena_strNombre>");
                    sb.Append(listaCadenas[i].Cadena_strNombre);
                    sb.Append("</Cadena_strNombre>");
                    sb.Append("<Cadena_intParticipa>");
                    sb.Append(listaCadenas[i].Cadena_intParticipa);
                    sb.Append("</Cadena_intParticipa>");
                    sb.Append("<Cadena_intTipoCadena>");
                    sb.Append(listaCadenas[i].Cadena_intTipoCadena);
                    sb.Append("</Cadena_intTipoCadena>");

                    
                    sb.Append("</Reg>");
                }

                sb.Append("</CadenaXML>");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                //Error 4:Error en el Método ParsearInformacionCadena
                throw new Exception("Error 4", ex);
            }
        }

        #endregion Metodos
    }
}
