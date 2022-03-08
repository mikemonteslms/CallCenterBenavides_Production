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
    public class Medicamentos
    {
        ClassDataSQL1 objClassDataSQL1=null;
        #region Metodos

        /// <summary>
        /// Método que nos permite obtener la informacion de un Medicamento.
        /// </summary>
        /// <param name="sku">SKU del Medicamento.</param>
        /// <returns>DataSet con la información del Medicamento.</returns>
        public static DataSet ObtenerMedicamento(string sku)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("sku", DbType.String, sku));

                DataSet dsMedicamento = DataBase.ExecuteDataSet(null, "SP_ObtenerMedicamento", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsMedicamento;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ObtenerMedicamento", ex);
                ExceptionManager.HandleException(e, 1, 5000, 2);
                throw (e);
            }
        }
        /// <summary>
        /// Método que nos permite validar si existe un Medicamento o no.
        /// </summary>
        /// <param name="sku">SKU del Medicamento.</param>
        /// <returns>True en el caso de que exista, False en caso contrario.</returns>
        public static bool ExisteMedicamento(string sku)
        {
            try
            {
                DataSet dsMedicamento = ObtenerMedicamento(sku);

                if (dsMedicamento.Tables[0].Rows.Count > 0)
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
        /// Método que nos permite Obtener todos los medicamentos registrados en Pfizer.
        /// </summary>
        /// <returns></returns>
        public static DataSet ObtenerTodosMedicamentos()
        {
            try
            {
                DataSet dsSKUs = DataBase.ExecuteDataSet(null, "SP_ObtenerSKUSMedicamentos");

                return dsSKUs;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ObtenerSKUSMedicamentos", ex);
                ExceptionManager.HandleException(e, 1, 5000, 2);
                throw (e);
            }
        }

/// <summary>
        /// Método que nos permite Obtener todos los medicamentos registrados en Pfizer para su venta en farmacias.
        /// </summary>
        /// <returns></returns>
        public static DataSet ListaMedicamentosVentaFarmacias(string strTarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("strTarjeta", DbType.String, strTarjeta));

                DataSet dsSKUs = DataBase.ExecuteDataSet(null, "sp_ObtenerProductosxTarjeta", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsSKUs;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ObtenerProductosxTarjeta", ex);
                ExceptionManager.HandleException(e, 1, 5000, 2);
                throw (e);
            }
        }

        public static DataSet ListExamenesLaboratorio(string strTarjeta, decimal strCadena, decimal strSucursal, string strUsuario)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("strTarjeta", DbType.String, strTarjeta));
                listParameters.Add(new ParameterIn("strCadena", DbType.String, strCadena));
                listParameters.Add(new ParameterIn("strSucursal", DbType.String, strSucursal));
                listParameters.Add(new ParameterIn("strUsuario", DbType.String, strUsuario));

                DataSet dsSKUs = DataBase.ExecuteDataSet(null, "sp_ObtenerExamenesLaboratorio", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsSKUs;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ObtenerExamenesLaboratorio", ex);
                ExceptionManager.HandleException(e, 1, 5000, 2);
                throw (e);
            }
        }
        
        /// <summary>
        /// Método que nos permite obtener un ArrayList con los SKU's de todos los medicamentos Pfizer.
        /// </summary>
        /// <returns></returns>
        public static ArrayList ObtenerListaSKUSMedicamentos()
        {
            try
            {
                DataSet dsSKUSMedicamentos = ObtenerTodosMedicamentos();
                ArrayList listaSKUSMedicamentos = new ArrayList();

                if (dsSKUSMedicamentos.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dsSKUSMedicamentos.Tables[0].Rows)
                    {
                        string sku = row["intSKU"].ToString();
                        listaSKUSMedicamentos.Add(sku);
                    }
                }

                return listaSKUSMedicamentos;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Método que nos permite Agregar Productos a la BD.
        /// </summary>

        public string AltaProductos(List<Entidades.Producto> listaProductos, string strUsuario)
        {
            
            try
            {
                objClassDataSQL1=new ClassDataSQL1();

                string strProducto = ParsearInformacionProductos(listaProductos);
                SqlParameter[] parametrosSP = new SqlParameter[2];
                parametrosSP[0] = new SqlParameter("@strProducto", strProducto);
                parametrosSP[1] = new SqlParameter("@strUsuario", strUsuario);

                DataSet oDS = objClassDataSQL1.LlenaDatosDataSet("sp_InsertaProducto", parametrosSP);

                string strResultado = "";
                for (int j = 0; j < oDS.Tables[0].Columns.Count; j++)
                {
                    strResultado = strResultado + "|" + oDS.Tables[0].Rows[0][j].ToString();
                }
                return strResultado;
            }
            catch (Exception ex)
            {
                //Error 3:Error al Ejecutar el Stored Procedure sp_InsertaProducto.
                Exception e = new Exception("Error 3", ex);
                //|0|Inserción en Catalogo de Cadenas Se efectuo Adecuadamente||1|0
                return "|error 3|Error al Ejecutar el Stored Procedure sp_InsertaProducto||0|0";
                //throw(e);
            }
        }
        /// <summary>
        /// Método que nos permite Generar los Productos XML.
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        private static string ParsearInformacionProductos(List<Entidades.Producto> listaProductos)
        {
            try
            {
                StringBuilder sb = new StringBuilder();


                sb.Append("<ProductoXML>");

                
                for (int i = 0; i < listaProductos.Count; i++)
                {
                    //<Producto_intStatus>1</Producto_intStatus></Reg>
                    sb.Append("<Reg>");
                    sb.Append("<Producto_strID>");
                    sb.Append(listaProductos[i].ProductoStrID);
                    sb.Append("</Producto_strID>");
                    sb.Append("<Producto_strDescripcion>");
                    sb.Append(listaProductos[i].ProductoStrDescripcion);
                    sb.Append("</Producto_strDescripcion>");
                    sb.Append("<Producto_intStatus>");
                    sb.Append(listaProductos[i].ProductoIntStatus);
                    sb.Append("</Producto_intStatus>");
                    sb.Append("</Reg>");
                }

                sb.Append("</ProductoXML>");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                //Error 4:Error en el Método ParsearInformacionProductos
                throw new Exception("Error 4", ex);
            }
        }

        /// <summary>
        /// Método que nos permite Agregar la Presentacion de Productos a la BD.
        /// </summary>

        public string AltaProductosPresentacion(List<Entidades.Presentacion> listaProductosPresenatacion, string strUsuario)
        {
            objClassDataSQL1=new ClassDataSQL1();
            try
            {
                string strProductoPresentacion = ParsearInformacionProductosPresentacion(listaProductosPresenatacion);
                SqlParameter[] parametrosSP = new SqlParameter[2];
                parametrosSP[0] = new SqlParameter("@strPresentacion", strProductoPresentacion);
                parametrosSP[1] = new SqlParameter("@strUsuario", strUsuario);

                DataSet oDS = objClassDataSQL1.LlenaDatosDataSet("sp_InsertaPresentacion", parametrosSP);

                string strResultado = "";
                for (int j = 0; j < oDS.Tables[0].Columns.Count; j++)
                {
                    strResultado = strResultado + "|" + oDS.Tables[0].Rows[0][j].ToString();
                }
                return strResultado;
            }
            catch (Exception ex)
            {
                //Error 3:Error al Ejecutar el Stored Procedure sp_InsertaProducto.
                Exception e = new Exception("Error 3", ex);
                //|0|Inserción en Catalogo de Cadenas Se efectuo Adecuadamente||1|0
                return "|error 3|Error al Ejecutar el Stored Procedure sp_InsertaPresentacion||0|0";
                //throw(e);
            }
        }
        /// <summary>
        /// Método que nos permite Generar la Presentacion de Productos XML.
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        private static string ParsearInformacionProductosPresentacion(List<Entidades.Presentacion> listaProductosPresentacion)
        {
            try
            {
                StringBuilder sb = new StringBuilder();


                sb.Append("<PresentacionXML>");


                for (int i = 0; i < listaProductosPresentacion.Count; i++)
                {
                 
                    sb.Append("<Reg>");
                    sb.Append("<Presentacion_strSKU>");
                    sb.Append(listaProductosPresentacion[i].PresentacionStrSKU);
                    sb.Append("</Presentacion_strSKU>");
                    
                    sb.Append("<Producto_strID>");
                    sb.Append(listaProductosPresentacion[i].ProductoStrID);
                    sb.Append("</Producto_strID>");

                    sb.Append("<Presentacion_strID>");
                    sb.Append(listaProductosPresentacion[i].PresentacionStrID);
                    sb.Append("</Presentacion_strID>");

                    sb.Append("<Presentacion_strDescripcion>");
                    sb.Append(listaProductosPresentacion[i].PresentacionStrDescripcion);
                    sb.Append("</Presentacion_strDescripcion>");
                    sb.Append("<Presentacion_strSKUBeneficio>");
                    sb.Append(listaProductosPresentacion[i].PresentacionStrSKUBeneficio);
                    sb.Append("</Presentacion_strSKUBeneficio>");
                    sb.Append("<Presentacion_intCantidadCompra>");
                    sb.Append(listaProductosPresentacion[i].PresentacionIntCantidadCompra);
                    sb.Append("</Presentacion_intCantidadCompra>");
                    sb.Append("<Presentacion_intCantidadBeneficio>");
                    sb.Append(listaProductosPresentacion[i].PresentacionIntCantidadBeneficio);
                    sb.Append("</Presentacion_intCantidadBeneficio>");
                    sb.Append("<Presentacion_intLimiteMensual>");
                    sb.Append(listaProductosPresentacion[i].PresentacionIntLimiteMensual);
                    sb.Append("</Presentacion_intLimiteMensual>");
                    sb.Append("<Presentacion_intStatus>");
                    sb.Append(listaProductosPresentacion[i].PresentacionIntStatus);
                    sb.Append("</Presentacion_intStatus>");
                    sb.Append("<Presentacion_intDiasPeriodo>");
                    sb.Append(listaProductosPresentacion[i].Presentacion_intDiasPeriodo);
                    sb.Append("</Presentacion_intDiasPeriodo>");

                    sb.Append("<Presentacion_decDescuento>");
                    sb.Append(listaProductosPresentacion[i].Presentacion_decDescuento);
                    sb.Append("</Presentacion_decDescuento>");
                    sb.Append("<Presentacion_decMontototal>");
                    sb.Append(listaProductosPresentacion[i].Presentacion_decMontototal);
                    sb.Append("</Presentacion_decMontototal>");
                    sb.Append("<Presentacion_decMontoDescuento>");
                    sb.Append(listaProductosPresentacion[i].Presentacion_decMontoDescuento);
                    sb.Append("</Presentacion_decMontoDescuento>");
                    sb.Append("<Presentacion_decAPagar>");
                    sb.Append(listaProductosPresentacion[i].Presentacion_decAPagar);
                    sb.Append("</Presentacion_decAPagar>");
                    sb.Append("<Presentacion_intTipoProducto>");
                    sb.Append(listaProductosPresentacion[i].Presentacion_intTipoProducto);
                    sb.Append("</Presentacion_intTipoProducto>");
                    
                    
                    sb.Append("</Reg>");
                }

                sb.Append("</PresentacionXML>");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                //Error 4:Error en el Método ParsearInformacionProductosPresentacion
                throw new Exception("Error 4", ex);
            }
        }

        #endregion Metodos
    }
}
