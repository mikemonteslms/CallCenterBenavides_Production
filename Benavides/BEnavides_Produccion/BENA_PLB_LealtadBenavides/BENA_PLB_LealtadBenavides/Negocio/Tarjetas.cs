using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;


namespace Negocio
{
    public class Tarjetas
    {
        #region Metodos
        Datos.SqlTransac sqlTarjetas = new Datos.SqlTransac();
        SqlTransac objSqlTransac = new SqlTransac();
        SqlParameter[] parametrosSP;

        /// <summary>
        /// Método que nos permite Obtener la informacion de una tarjeta.
        /// </summary>
        /// <param name="tarjeta">Numero de la tarjeta.</param>
        /// <returns>DataSet con la informacion de la tarjeta.</returns>
        public static DataSet ObtenerTarjeta(string tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("strTarjeta", DbType.String, tarjeta));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "SP_ObtenerTarjeta", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsTarjeta;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ObtenerTarjeta.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 5);
                throw (e);
            }
        }

        /// <summary>
        /// Método que nos permite Obtener la informacion de una tarjeta previamente activada o en su defecto, del un cliente CRM.
        /// </summary>
        /// <param name="tarjeta">Numero de la tarjeta.</param>
        /// <returns>DataSet con la informacion de la tarjeta.</returns>
        public  DataSet ObtenerTarjetaClienteDatos(string strTarjeta, string strCedula)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("strTarjeta", DbType.String, strTarjeta));
                listParameters.Add(new ParameterIn("strCedula", DbType.String, strCedula));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "SP_ObtenerTarjetaClienteDatos", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsTarjeta;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ObtenerTarjetaClienteDatos.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 5);
                throw (e);
            }
        }

        /// <summary>
        /// Método que nos permite Guardar la información de la tarjeta/cliente durante la activacion.
        /// </summary>
        /// <param name="tarjeta">Numero de la tarjeta.</param>
        /// <returns>DataSet con la informacion de la tarjeta.</returns>
        public DataSet GuardarTarjetaCliente(string strTarjeta, string strUsuario)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@strTarjeta", DbType.String, strTarjeta));
                listParameters.Add(new ParameterIn("@strUsuario", DbType.String, strUsuario));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "sp_InsertaTarjetaClienteMecanicas", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsTarjeta;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_GuardarTarjetaCliente.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 5);
                throw (e);
            }
        }

        public DataSet GuardarLlamada(string strParametroXML, string strUsuario)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@strParametroXML", DbType.String, @strParametroXML));
                listParameters.Add(new ParameterIn("@strUsuario", DbType.String, strUsuario));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "sp_RegistraLlamada", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsTarjeta;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_RegistraLlamada.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 5);
                throw (e);
            }
        }

        /// <summary>
        /// Método que nos permite validar si una tarjeta existe o no.
        /// </summary>
        /// <param name="tarjeta">Numero de Tarjeta.</param>
        /// <returns>True en el caso de que la Tarjeta exista. False en caso contrario.</returns>
        public static bool ExisteTarjeta(string tarjeta)
        {
            try
            {
                DataSet dsTarjeta = ObtenerTarjeta(tarjeta);

                if (dsTarjeta.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public DataSet CambiarNumeroTicket(string strTicket, string strComentario, string strUsuario)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("@strNoTicket", strTicket);
                parametros[1] = new SqlParameter("@strComentario", strComentario);
                parametros[2] = new SqlParameter("@strUsuario", strUsuario);

                DataSet objDataset = objSqlTransac.RegresaDataSetSP("sp_CambiarTicket", parametros);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ValidarTarjeta(string strTarjeta)
        {
            try
            {
                parametrosSP = Parametros(strTarjeta);
                DataSet objDataset = objSqlTransac.RegresaDataSetSP("SP_ObtenerTarjeta", parametrosSP);
                return objDataset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlParameter[] Parametros(string strTarjeta)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@strTarjeta", strTarjeta);

            return parameters;
        }

        public string AltaTarjetas(List<Entidades.Tarjetas> listaTarjetas, string strUsuario)
        {
            Datos.SqlTransac sqlTransacciones = new Datos.SqlTransac();
            try
            {
                string strTarjetas = ParsearInformacionTarjetas(listaTarjetas);
                SqlParameter[] parametrosSP = new SqlParameter[2];
                parametrosSP[0] = new SqlParameter("@strTarjeta", strTarjetas);
                parametrosSP[1] = new SqlParameter("@strUsuario", strUsuario);

                DataSet oDS = sqlTransacciones.RegresaDataSetSP("sp_InsertaTarjeta", parametrosSP);

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
                return "|error 3|Error al Ejecutar el Stored Procedure sp_InsertaTarjeta||0|0";
                //throw(e);
            }
        }

        private static string ParsearInformacionTarjetas(List<Entidades.Tarjetas > listaTarjetas)
        {
            try
            {
                StringBuilder sb = new StringBuilder();


                sb.Append("<TarjetaXML>");

                //foreach (Pedido pedido in listaCompras)
                for (int i = 0; i < listaTarjetas.Count; i++)
                {
                    //<Reg><Cadena_intID>1</Cadena_intID><Cadena_strNombre>Locatel</Cadena_strNombre><Cadena_intParticipa>1</Cadena_intParticipa></Reg>
                    sb.Append("<Reg>");
                    sb.Append("<Tarjeta_strNumero>");
                    sb.Append(listaTarjetas[i].Tarjeta_StrID);
                    sb.Append("</Tarjeta_strNumero>");
                    sb.Append("<Tarjeta_StrMecanicas>");
                    sb.Append(listaTarjetas[i].Tarjeta_StrMecanicas );
                    sb.Append("</Tarjeta_StrMecanicas>");
                    sb.Append("<Tarjeta_IntParticipa>");
                    sb.Append(listaTarjetas[i].Tarjeta_IntParticipa);
                    sb.Append("</Tarjeta_IntParticipa>");

                    sb.Append("<Cliente_strUniqueIdentifier>");
                    sb.Append(listaTarjetas[i].Cliente_strUniqueIdentifier);
                    sb.Append("</Cliente_strUniqueIdentifier>");
                    sb.Append("<Cliente_strCedula>");
                    sb.Append(listaTarjetas[i].Cliente_strCedula);
                    sb.Append("</Cliente_strCedula>");
                    sb.Append("<Cliente_strPrimerNombre>");
                    sb.Append(listaTarjetas[i].Cliente_strPrimerNombre);
                    sb.Append("</Cliente_strPrimerNombre>");
                    sb.Append("<Cliente_strApellido1>");
                    sb.Append(listaTarjetas[i].Cliente_strApellido1);
                    sb.Append("</Cliente_strApellido1>");
                    sb.Append("<Cliente_strApellido2>");
                    sb.Append(listaTarjetas[i].Cliente_strApellido2);
                    sb.Append("</Cliente_strApellido2>");
                    sb.Append("<Cliente_strTelefono>");
                    sb.Append(listaTarjetas[i].Cliente_strTelefono);
                    sb.Append("</Cliente_strTelefono>");
                    sb.Append("</Reg>");
                }

                sb.Append("</TarjetaXML>");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                //Error 4:Error en el Método ParsearInformacionSucursal
                throw new Exception("Error 4", ex);
            }
        }

        public string ConfirmaTarjetaCliente(int paqueteEntrega, string listatarjetacliente, int estatus)
        {

            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@PaqueteEntrega", paqueteEntrega);
            parametros[1] = new SqlParameter("@ListaTarjetaCliente", listatarjetacliente);
            parametros[2] = new SqlParameter("@Estatus", estatus);

            DataSet oDS = sqlTarjetas.RegresaDataSetSP("sp_EstatusEstregaTarjetaCliente", parametros);

            string regresa = oDS.Tables[0].Rows[0][0].ToString() + "|" + oDS.Tables[0].Rows[0][1].ToString()
                            + oDS.Tables[0].Rows[0][2].ToString() + "|" + oDS.Tables[0].Rows[0][3].ToString();
            return regresa;
        }

        public List<Entidades.TarjetaCliente> RegresaTarjetas(int tipoExtraccion, string fecha, string strUsuario)
        {
            List<Entidades.TarjetaCliente> tablaTarjetas = new List<Entidades.TarjetaCliente>();
            string Error = "";
            string Mensaje = "";
            int TotalRegistros = 0;
            int PaqueteEntrega = 0;
            string ClienteID = "";
            string TarjetaID = "";
            string ApellidoP = "";
            string ApellidoM = "";
            string Nombre="";
            string DateFechaAlta = DateTime.Now.ToShortDateString();
            string Cedula ="";
            string Telefono = "";
            string Medico = "";
            string IdSucursal = "";
            string Mecanicas = "";
            try
            {
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("@TipoExtraccion", tipoExtraccion);
                parametros[1] = new SqlParameter("@Fecha", fecha);
                parametros[2] = new SqlParameter("@strUsuario", strUsuario);
                DataSet oDS = sqlTarjetas.RegresaDataSetSP("sp_ListaClientesInscritos", parametros);
                if (oDS.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < oDS.Tables[0].Rows.Count; i++)
                    {
                        Error = oDS.Tables[0].Rows[i]["Error"].ToString();
                        Mensaje = oDS.Tables[0].Rows[i]["Mensaje"].ToString();
                        TotalRegistros = int.Parse(oDS.Tables[0].Rows[i]["TotalRegistros"].ToString());
                        PaqueteEntrega = int.Parse(oDS.Tables[0].Rows[i]["PaqueteEntrega"].ToString());
                        
                        ClienteID = oDS.Tables[0].Rows[i]["Cliente_strUniqueIdentifier"].ToString();
                        TarjetaID = oDS.Tables[0].Rows[i]["Tarjeta_strNumero"].ToString();
                        ApellidoP = oDS.Tables[0].Rows[i]["Cliente_strApellidoPaterno"].ToString();
                        ApellidoM = oDS.Tables[0].Rows[i]["Cliente_strApellidoMaterno"].ToString();
                        Nombre = oDS.Tables[0].Rows[i]["Cliente_strPrimerNombre"].ToString();
                        DateFechaAlta = oDS.Tables[0].Rows[i]["Cliente_dateFechaAlta"].ToString();
                        Cedula = oDS.Tables[0].Rows[i]["Cliente_strCedula"].ToString();
                        Telefono = oDS.Tables[0].Rows[i]["Cliente_strTelefonoCasa"].ToString();
                        Medico = oDS.Tables[0].Rows[i]["Cliente_strNombreMedico"].ToString();
                        IdSucursal = oDS.Tables[0].Rows[i]["sucursal_uniqueID"].ToString();
                        Mecanicas = oDS.Tables[0].Rows[i]["Cliente_strMecanicas"].ToString();

                        tablaTarjetas.Add(new Entidades.TarjetaCliente(Error, Mensaje, TotalRegistros, PaqueteEntrega,ClienteID,
                                TarjetaID, ApellidoP, ApellidoM, Nombre,
                                DateFechaAlta, Cedula, Telefono, Medico, IdSucursal, Mecanicas));

                    }
                }
                else
                {
                    tablaTarjetas.Add(new Entidades.TarjetaCliente("error 3", "se encontraron 0 registros a transaccionar", TotalRegistros, PaqueteEntrega,ClienteID,
                                TarjetaID, ApellidoP, ApellidoM, Nombre,
                                DateFechaAlta, Cedula, Telefono, Medico, IdSucursal, Mecanicas));
                    //error 3: se encontraron 0 registros a transaccionar.
                }
                return tablaTarjetas;
            }
            catch (Exception ex)
            {
                tablaTarjetas.Add(new Entidades.TarjetaCliente("error 4", ex.Message, TotalRegistros, 0,  "0",
                                TarjetaID, ApellidoP, ApellidoM, Nombre,
                                DateFechaAlta, Cedula, Telefono, Medico, IdSucursal, Mecanicas));
                return tablaTarjetas;
                //Error 4: Error de comunicacion con BD, favor de comunicarlo al administrador del sistema.
            }
        }

        #endregion Metodos
    }
}
