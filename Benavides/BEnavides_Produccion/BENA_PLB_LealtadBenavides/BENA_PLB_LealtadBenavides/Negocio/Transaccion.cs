using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Data;
using System.Globalization;

using Datos;
namespace Negocio
{
    public class Transaccion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tarjeta"></param>
        /// <param name="cadena"></param>
        /// <param name="tipoCorteMensual"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        /// 

        public static DataSet GenerarCotizacion(string tarjeta, int cadena, int programa, int sucursal, int terminal, string usuarioTicket, string usuarioCaptura, int tipoCorteMensual, string xml)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, tarjeta.Trim()));
                listParameters.Add(new ParameterIn("Cadena", DbType.Int32, cadena));
                listParameters.Add(new ParameterIn("Programa", DbType.Int32, programa));
                listParameters.Add(new ParameterIn("Sucursal", DbType.Int32, sucursal));
                listParameters.Add(new ParameterIn("Terminal", DbType.Int32, terminal));
                listParameters.Add(new ParameterIn("UsuarioTicket", DbType.String, usuarioTicket));
                listParameters.Add(new ParameterIn("UsuarioCaptura", DbType.String, usuarioCaptura));
                listParameters.Add(new ParameterIn("TipoCorteMensual", DbType.Int32, tipoCorteMensual));
                listParameters.Add(new ParameterIn("TicketXML", DbType.String, xml));

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "Sp_ReglasDeNegocio", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure Sp_ReglasDeNegocio.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }
        /// <summary>
        /// Método que nos permite obtener la informacion relacionada con una Cotizacion.
        /// </summary>
        /// <param name="numeroCotizacion"></param>
        /// <returns></returns>
        public static DataSet ObtenerCotizacion(string numeroCotizacion)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Cotizacion", DbType.String, numeroCotizacion));

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "SP_ObtenerCotizacion", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ObtenerCotizacion.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }
        /// <summary>
        /// Método que nos permite Cerrar la cotizacion de una Compra Realizada anterirmente.
        /// </summary>
        /// <param name="cotizacionId"></param>
        /// <param name="tarjeta"></param>
        /// <returns></returns>
        public  DataSet CerrarCotizacion(string cotizacionId, string tarjeta, string xml)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("cotizacion", DbType.String, cotizacionId));
                listParameters.Add(new ParameterIn("tarjeta", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("strXMLBeneficios", DbType.String, xml));

                DataSet dsCierre = DataBase.ExecuteDataSet(null, "SP_CerrarCotizacion", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCierre;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_CerrarCotizacion.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }
        /// <summary>
        /// Método que nos permite realizar la Cancelacion de una Cotizacion especifica.
        /// </summary>
        /// <param name="cotizacionId"></param>
        /// <param name="tarjeta"></param>
        /// <returns></returns>
        public static DataSet CancelarCotizacion(string cotizacionId, string tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("cotizacion", DbType.String, cotizacionId));
                listParameters.Add(new ParameterIn("tarjeta", DbType.String, tarjeta));

                DataSet dsCancelacion = DataBase.ExecuteDataSet(null, "SP_CancelarCotizacion", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCancelacion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_CancelarCotizacion.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ValidarRegistroPrevio(string strCadena, string strSucursal, string strTicket, string strFecha)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@strCadena", DbType.Int16 , strCadena));
                listParameters.Add(new ParameterIn("@strSucursal", DbType.Int16, strSucursal));
                listParameters.Add(new ParameterIn("@strTicket", DbType.String, strTicket));
                listParameters.Add(new ParameterIn("@strFecha", DbType.String, strFecha));

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "SP_ValidarRegistroPrevio", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure ValidarRegistroPrevio.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ValidarTicketValidoCadena(string strCadena, string strSucursal, string strTicket, string strFecha)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@strCadena", DbType.Int16, strCadena));
                listParameters.Add(new ParameterIn("@strSucursal", DbType.Int16, strSucursal));
                listParameters.Add(new ParameterIn("@strTicket", DbType.String, strTicket));
                listParameters.Add(new ParameterIn("@strFecha", DbType.String, strFecha));

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "SP_TicketValidoCadena", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure ValidarRegistroPrevio.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet MensajeCotizacion(string strCotizacion)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@strCotizacion", DbType.String, strCotizacion));

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "SP_MensajeCotizacion", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure MensajeCotizacion.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet InsertaBitacora(int intEvento, string strOrigen, string strComentario, string strUsuario)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@Evento", DbType.Int16 , intEvento));
                listParameters.Add(new ParameterIn("@Origen", DbType.String, strOrigen));
                listParameters.Add(new ParameterIn("@Comentario", DbType.String, strComentario));
                listParameters.Add(new ParameterIn("@Usuario", DbType.String, strUsuario));

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "sp_InsertaEnBitacoraApp", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_InsertaEnBitacoraApp", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ActualizarBeneficiosCotizacion(string cotizacionId, string tarjeta, string xml)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("cotizacion", DbType.String, cotizacionId));
                listParameters.Add(new ParameterIn("tarjeta", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("Beneficios", DbType.String, xml));

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "SP_ActualizaBeneficios", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ActualizaBeneficios.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ObtenerCotizacion(string p, string p_2, object xml)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DataSet ProcesarCompraReglasDNegocio(string ProgramaID, string Llave, int Programa_intId, int Cadena_intId, int Sucursal_intId, int Termina_intId, string UsuarioTicket, string UsuarioCaptura, string Tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("ProgramaID", DbType.String, ProgramaID.Trim()));
                listParameters.Add(new ParameterIn("Llave", DbType.String, Llave.Trim()));
                listParameters.Add(new ParameterIn("Programa_intId", DbType.Int32, Programa_intId));
                listParameters.Add(new ParameterIn("Cadena_intId", DbType.Int32, Cadena_intId));
                listParameters.Add(new ParameterIn("Sucursal_intId", DbType.Int32, Sucursal_intId));
                listParameters.Add(new ParameterIn("Terminal_intId", DbType.String, Termina_intId));
                listParameters.Add(new ParameterIn("usuarioticket", DbType.String, UsuarioTicket));
                listParameters.Add(new ParameterIn("UsuarioCaptura", DbType.String, UsuarioCaptura));
                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));                

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "Sp_ProcesarCompraReglasdNegocio", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure Sp_ReglasDeNegocio.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet CerrarCompraReglasDNegocio(string ProgramaID, string Llave, string CotizacionId, string Tarjeta, string NoTicket, string FechaTicket, string SKU, int Cantidad)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("ProgramaID", DbType.String, ProgramaID.Trim()));
                listParameters.Add(new ParameterIn("Llave", DbType.String, Llave.Trim()));
                listParameters.Add(new ParameterIn("Cotizacion", DbType.String, CotizacionId));
                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
                listParameters.Add(new ParameterIn("Noticket", DbType.String, NoTicket));
                listParameters.Add(new ParameterIn("FechaTicket", DbType.String, FechaTicket));
                listParameters.Add(new ParameterIn("sku", DbType.String, SKU));
                listParameters.Add(new ParameterIn("Cantidad", DbType.Int32, Cantidad));                

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "Sp_CerrarCompraReglasdeNegocio", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure Sp_ReglasDeNegocio.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet CancelarCompraReglasDNegocio(string ProgramaID, string Llave, string CotizacionId, string Tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("ProgramaID", DbType.String, ProgramaID.Trim()));
                listParameters.Add(new ParameterIn("Llave", DbType.String, Llave.Trim()));
                listParameters.Add(new ParameterIn("Cotizacion", DbType.String, CotizacionId));
                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));                

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "Sp_CancelarCompraReglasdeNegocio", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure Sp_ReglasDeNegocio.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ConsultaTarjetaReglasDNegocio(string ProgramaID, string Llave, string Tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("ProgramaID", DbType.String, ProgramaID.Trim()));
                listParameters.Add(new ParameterIn("Llave", DbType.String, Llave.Trim()));                
                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "Sp_ConsultaTarjetaReglasdeNegocio", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure Sp_ReglasDeNegocio.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ActivarTarjetaReglasDNegocio(string ProgramaID, string Llave, string Tarjeta, string Apellido1, string Apellido2, string Nombre, string Nacionalidad, string Cedula, string LocTelefono, string Telefono, string SKU, string DescPresentacion, string DescProducto, string Notas)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("ProgramaID", DbType.String, ProgramaID.Trim()));
                listParameters.Add(new ParameterIn("Llave", DbType.String, Llave.Trim()));
                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
                listParameters.Add(new ParameterIn("Apellido1", DbType.String, Apellido1));
                listParameters.Add(new ParameterIn("Apellido2", DbType.String, Apellido2));
                listParameters.Add(new ParameterIn("Nombre", DbType.String, Nombre));
                listParameters.Add(new ParameterIn("Nacionalidad", DbType.String, Nacionalidad));
                listParameters.Add(new ParameterIn("Cedula", DbType.String, Cedula));
                listParameters.Add(new ParameterIn("LocTelefono", DbType.String, LocTelefono));
                listParameters.Add(new ParameterIn("Telefono", DbType.String,Telefono));
                listParameters.Add(new ParameterIn("SKU", DbType.String, SKU));
                listParameters.Add(new ParameterIn("DescPresentacion", DbType.String, DescPresentacion));
                listParameters.Add(new ParameterIn("DescProducto", DbType.String, DescProducto));
                listParameters.Add(new ParameterIn("Notas", DbType.String, Notas));

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "Sp_ActivaTarjetaReglasdeNegocio", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure Sp_ReglasDeNegocio.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet MaestroSucursalesReglasDNegocio(string ProgramaID, string Llave)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("ProgramaID", DbType.String, ProgramaID.Trim()));
                listParameters.Add(new ParameterIn("Llave", DbType.String, Llave.Trim()));                

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "Sp_MaestroSucursalesReglasdeNegocio", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure Sp_ReglasDeNegocio.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet MaestroProductosReglasDNegocio(string ProgramaID, string Llave)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("ProgramaID", DbType.String, ProgramaID.Trim()));
                listParameters.Add(new ParameterIn("Llave", DbType.String, Llave.Trim()));

                DataSet dsCompra = DataBase.ExecuteDataSet(null, "Sp_MaestroProductosReglasdeNegocio", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsCompra;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure Sp_ReglasDeNegocio.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }
    }
}
