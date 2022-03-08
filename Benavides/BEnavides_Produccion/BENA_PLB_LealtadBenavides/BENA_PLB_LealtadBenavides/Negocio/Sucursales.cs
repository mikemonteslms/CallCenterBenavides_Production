using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;


namespace Negocio
{
    public class Sucursales
    {
        #region Metodos

        /// <summary>
        /// Método que nos permite obtener la informacion de una Sucursal.
        /// </summary>
        /// <param name="cadena_intId">Id de la Cadena.</param>
        /// <param name="sucursal_intId">Id de la Sucursal.</param>
        /// <returns>DataSet con la informacion de la Sucursal.</returns>
        public static DataSet ObtenerSucursal(int cadena_intId, int sucursal_intId)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("cadena_intId", DbType.Int32, cadena_intId));
                listParameters.Add(new ParameterIn("sucursal_intId", DbType.Int32, sucursal_intId));

                DataSet dsSucursal = DataBase.ExecuteDataSet(null, "SP_ObtenerSucursal", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsSucursal;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ObtenerSucursal.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 4);
                throw (e);
            }
        }
        /// <summary>
        /// Método que nos permite validar si una sucursal existe o no.
        /// </summary>
        /// <param name="cadena_intId">Id de la Cadena.</param>
        /// <param name="sucursal_intId">Id de la Sucursal.</param>
        /// <returns>True en caso de que la Sucursal exista, False en caso contrario.</returns>
        public static bool ExisteSucursal(int cadena_intId, int sucursal_intId)
        {
            try
            {
                DataSet dsSucursal = ObtenerSucursal(cadena_intId, sucursal_intId);

                if (dsSucursal.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Método que nos permite Agregar Sucursales a la BD.
        /// </summary>

        public string AltaSucursales(List<Entidades.Sucursales> listaSucursales, string strUsuario)
        {
            Datos.SqlTransac sqlTransacciones = new Datos.SqlTransac();
            try
            {
                string strSucursal = ParsearInformacionSucursal(listaSucursales);
                SqlParameter[] parametrosSP = new SqlParameter[2];
                parametrosSP[0] = new SqlParameter("@strSucursal", strSucursal);
                parametrosSP[1] = new SqlParameter("@strUsuario", strUsuario);

                DataSet oDS = sqlTransacciones.RegresaDataSetSP("sp_InsertaSucursal", parametrosSP);

                string strResultado = "";
                for (int j = 0; j < oDS.Tables[0].Columns.Count; j++)
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
                return "|error 3|Error al Ejecutar el Stored Procedure sp_InsertaSucursal||0|0";
                //throw(e);
            }
        }
        /// <summary>
        /// Método que nos permite Generar las Sucursales XML.
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        private static string ParsearInformacionSucursal(List<Entidades.Sucursales> listaSucursales)
        {
            try
            {
                StringBuilder sb = new StringBuilder();


                sb.Append("<SucursalXML>");

                //foreach (Pedido pedido in listaCompras)
                for (int i = 0; i < listaSucursales.Count; i++)
                {
                    //<Reg><Cadena_intID>1</Cadena_intID><Cadena_strNombre>Locatel</Cadena_strNombre><Cadena_intParticipa>1</Cadena_intParticipa></Reg>
                    sb.Append("<Reg>");
                    sb.Append("<Cadena_intID>");
                    sb.Append(listaSucursales[i].Cadena_IntID);
                    sb.Append("</Cadena_intID>");
                    sb.Append("<Sucursal_strID>");
                    sb.Append(listaSucursales[i].Sucursal_StrID);
                    sb.Append("</Sucursal_strID>");
                    sb.Append("<Sucursal_strNombre>");
                    sb.Append(listaSucursales[i].Sucursal_StrNombre);
                    sb.Append("</Sucursal_strNombre>");
                    sb.Append("<Sucursal_intParticipa>");
                    sb.Append(listaSucursales[i].Sucursal_IntParticipa);
                    sb.Append("</Sucursal_intParticipa>");
                    sb.Append("</Reg>");
                }

                sb.Append("</SucursalXML>");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                //Error 4:Error en el Método ParsearInformacionSucursal
                throw new Exception("Error 4", ex);
            }
        }

        #endregion Metodos
    }
}
