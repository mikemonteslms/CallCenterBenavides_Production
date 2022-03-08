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
    public class Tarjetas
    {
        #region Metodos

        ClassDataSQL1 objSqlTransac = null;
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

                listParameters.Add(new ParameterIn("@Tarjeta_strID", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("@ProgramaID", DbType.String, "1"));
                listParameters.Add(new ParameterIn("@Llave", DbType.String, "998877"));


                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "sp_WebValidaTarjetaV6", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

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
                objSqlTransac = new ClassDataSQL1();
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("@strNoTicket", strTicket);
                parametros[1] = new SqlParameter("@strComentario", strComentario);
                parametros[2] = new SqlParameter("@strUsuario", strUsuario);

                DataSet objDataset = objSqlTransac.LlenaDatosDataSet("sp_CambiarTicket", parametros);
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
                
                objSqlTransac = new ClassDataSQL1();
                parametrosSP = Parametros(strTarjeta);
                DataSet objDataset = objSqlTransac.LlenaDatosDataSet("SP_ObtenerTarjeta", parametrosSP);
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
            objSqlTransac = new ClassDataSQL1();
            try
            {
                string strTarjetas = ParsearInformacionTarjetas(listaTarjetas);
                SqlParameter[] parametrosSP = new SqlParameter[2];
                parametrosSP[0] = new SqlParameter("@strTarjeta", strTarjetas);
                parametrosSP[1] = new SqlParameter("@strUsuario", strUsuario);

                DataSet oDS = objSqlTransac.LlenaDatosDataSet("sp_InsertaTarjeta", parametrosSP);

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
            objSqlTransac = new ClassDataSQL1();
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@PaqueteEntrega", paqueteEntrega);
            parametros[1] = new SqlParameter("@ListaTarjetaCliente", listatarjetacliente);
            parametros[2] = new SqlParameter("@Estatus", estatus);

            DataSet oDS = objSqlTransac.LlenaDatosDataSet("sp_EstatusEstregaTarjetaCliente", parametros);

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
                objSqlTransac =new ClassDataSQL1();
                SqlParameter[] parametros = new SqlParameter[3];
                parametros[0] = new SqlParameter("@TipoExtraccion", tipoExtraccion);
                parametros[1] = new SqlParameter("@Fecha", fecha);
                parametros[2] = new SqlParameter("@strUsuario", strUsuario);
                DataSet oDS = objSqlTransac.LlenaDatosDataSet("sp_ListaClientesInscritos", parametros);
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

        #region ActualizaPadecimientosXTarjeta

        public Int16 ActualizaPadecimientosXTarjeta(string pTarjeta, Int16 pPadecimiento, int pPermisos, string pUsuario,int FlgCorreo, int FlgCelular)
        {
            try
            {
                Int16 iResultado = 0;
                ArrayList listParameters = new ArrayList();
                pUsuario = pUsuario + "|";

                listParameters.Add(new ParameterIn("@Tarjeta_strNumero", DbType.String, pTarjeta));
                listParameters.Add(new ParameterIn("@Padecimiento_intID", DbType.Int16, pPadecimiento));
                listParameters.Add(new ParameterIn("@ClientePadecimiento_SuscripcionPermisos", DbType.Int32, pPermisos));
                listParameters.Add(new ParameterIn("@ClientePadecimiento_strUsuarioModificacion", DbType.String, pUsuario));
                listParameters.Add(new ParameterIn("@FlagCorreoBI", DbType.Int32, FlgCorreo));
                listParameters.Add(new ParameterIn("@FlagSMSBI", DbType.Int32, FlgCelular));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "sp_ActualizaPadecimientosXTarjeta", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                if (dsTarjeta.Tables.Count > 0)
                {
                    foreach (DataRow dr in dsTarjeta.Tables[0].Rows)
                    {
                        //iResultado = Convert.ToInt16(dr[1].ToString());
                        iResultado = Convert.ToInt16(dr[0].ToString());
                    }
                }

                return iResultado;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ActualizaPadecimientosXTarjeta.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 5);
                throw (e);
            }
        }

        #endregion ActualizaPadecimientosXTarjeta

        #region CancelaSuscripcionDeCorreo

        public string CancelaSuscripcionDeCorreo(string pTarjeta, Int16 pPadecimiento, string pUsuario)
        {
            try
            {
                //Int16 iResultado = 0;
                string sResultado = string.Empty;
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@Tarjeta_strNumero", DbType.String, pTarjeta));
                listParameters.Add(new ParameterIn("@Padecimiento_intID", DbType.Int16, pPadecimiento));
                listParameters.Add(new ParameterIn("@ClientePadecimiento_strUsuarioModificacion", DbType.String, pUsuario));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "sp_CancelaSuscripcionDeCorreo", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                if (dsTarjeta.Tables.Count > 0)
                {
                    foreach (DataRow dr in dsTarjeta.Tables[0].Rows)
                    {
                        //iResultado = Convert.ToInt16(dr[1].ToString());
                        //iResultado = Convert.ToInt16(dr[0].ToString());
                        sResultado = dr[0].ToString();
                    }
                }

                return sResultado;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_CancelaSuscripcionDeCorreo.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 5);
                throw (e);
            }
        }

        #endregion CancelaSuscripcionDeCorreo

        #region PadecimientosXTarjeta

        public DataSet PadecimientosXTarjeta(string pTarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@Tarjeta_srtNumero", DbType.String, pTarjeta));

                //DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "sp_ConsutlaPadecimientosXTarjeta", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));
                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "sp_ConsultaCancelacionSuscripcionXTarjeta", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsTarjeta;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ConsultaCancelacionSuscripcionXTarjeta.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 5);
                throw (e);
            }
        }

        #endregion PadecimientosXTarjeta

        #region Bloqueos

        public static DataTable ConsultaBloqueos(DateTime? FechaInicio,DateTime? fechaFin, string Tarjeta)
        {
            DataSet dtsResult = new DataSet();

            ArrayList lstParameters = new ArrayList();
            lstParameters.Add(new ParameterIn("@FechaInicio", DbType.DateTime, FechaInicio));
            lstParameters.Add(new ParameterIn("@FechaFin", DbType.DateTime, fechaFin));
            if(!string.IsNullOrEmpty(Tarjeta))
                lstParameters.Add(new ParameterIn("@Tarjeta", DbType.String, Tarjeta));

            dtsResult = DataBase.ExecuteDataSet(null, "ConsultaBloqueos", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dtsResult.Tables[0];

        }
        public static DataTable ConsultaBloqueos(string Tarjeta)
        {
            DataSet dtsResult = new DataSet();

            ArrayList lstParameters = new ArrayList();
            lstParameters.Add(new ParameterIn("@Tarjeta", DbType.String, Tarjeta));

            dtsResult = DataBase.ExecuteDataSet(null, "ConsultaBloqueosT", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dtsResult.Tables[0];

        }

        public static string RealizarBloqueos(string Tarjeta, string Operacion, string Motivo,string Usuario)
        {
            try
            {
                DataSet dtsResult = new DataSet();

                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@Tarjeta", DbType.String, Tarjeta));
                lstParameters.Add(new ParameterIn("@Operacion", DbType.Int32, Operacion));
                lstParameters.Add(new ParameterIn("@Motivo", DbType.String, Motivo));
                lstParameters.Add(new ParameterIn("@usuario", DbType.String, Usuario));

                dtsResult = DataBase.ExecuteDataSet(null, "SP_RealizaBloqueo", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

                return dtsResult.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return "No se pudo realizar la operación";
            }
        }
        #endregion
        #region Traspasos

        public static DataTable ConsultarTraspasos(string Anio, string Mes, string Tarjeta, string Sucursal)
        {
            DataSet dtsResult = new DataSet();

            ArrayList lstParameters = new ArrayList();

            if (Anio != "0" && Mes != "0")
                lstParameters.Add(new ParameterIn("@Periodo", DbType.String, Anio+Mes));
            if (!string.IsNullOrEmpty(Tarjeta))
                lstParameters.Add(new ParameterIn("@Tarjeta", DbType.String, Tarjeta));
            if(!string.IsNullOrEmpty(Sucursal) && Sucursal != "0" && Sucursal != "-1" )
                lstParameters.Add(new ParameterIn("@Sucursal", DbType.String, Sucursal));

            dtsResult = DataBase.ExecuteDataSet(null, "sp_WEBConsultaTraspasos", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dtsResult.Tables[0];
        }

        public static DataSet ConsultarInfoTraspaso(string TarjetaOrigen, string TarjetaDestino)
        {
            
            DataSet dtsResult = new DataSet();

            ArrayList lstParameters = new ArrayList();
            lstParameters.Add(new ParameterIn("@TarjetaO", DbType.String, TarjetaOrigen));
            lstParameters.Add(new ParameterIn("@TarjetaD", DbType.String, TarjetaDestino));

            dtsResult = DataBase.ExecuteDataSet(null, "SP_WebConsultaInfoTraspaso", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dtsResult;
        }
        public static DataSet RealizarTraspaso(string TDestino, string TOrigen,string Usuario, string Motivo, string Sucursal)
        {
            DataSet dtsResult = new DataSet();

            ArrayList lstParameters = new ArrayList();
            lstParameters.Add(new ParameterIn("@TarjetaOrigen", DbType.String, TOrigen));
            lstParameters.Add(new ParameterIn("@TarjetaDestino", DbType.String, TDestino));
            lstParameters.Add(new ParameterIn("@ProgramaID", DbType.String, "1"));
            lstParameters.Add(new ParameterIn("@Llave", DbType.String, "998877"));
            lstParameters.Add(new ParameterIn("@Sucursal_strId", DbType.String, Sucursal));
            lstParameters.Add(new ParameterIn("@Terminal_strId", DbType.String, "999999"));
            lstParameters.Add(new ParameterIn("@Motivo", DbType.String, Motivo));
            lstParameters.Add(new ParameterIn("@UsuarioTras", DbType.String,Usuario));

            dtsResult = DataBase.ExecuteDataSet(null, "sp_WSTraspasaPuntosV8", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dtsResult;
        }
        #endregion
        #endregion Metodos

        public static DataSet ConsultaTraspasoExitoso(string Tarjeta)
        {
            DataSet dtsResult = new DataSet();

            ArrayList lstParameters = new ArrayList();
            lstParameters.Add(new ParameterIn("@Tarjeta", DbType.String, Tarjeta));
        
            dtsResult = DataBase.ExecuteDataSet(null, "SP_WebConsultaInfoTraspasoExitoso", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dtsResult;
        }

        public static DataSet ConsultarCaptura()
        {
            DataSet dtsResult = new DataSet();

            dtsResult = DataBase.ExecuteDataSet("ConectaReportes", "sp_ObtieneRepCapturaDatosTotales");

            return dtsResult;
        }

        public static DataSet ConsultarCaptacion()
        {
            DataSet dtsResult = new DataSet();

            dtsResult = DataBase.ExecuteDataSet("ConectaReportes", "sp_ObtieneReporteCaptacionDatosV3");

            return dtsResult;
        }

        public static DataSet ActivarTarjeta(string Tarjeta, string ApellidoP, string ApellidoM, string Nombre, DateTime? FechaNac, string Email, string Telefono, string TelefonoM, string Sexo, string Usuario)
        {
            DataSet dtsResult = new DataSet();

            ArrayList lstParameters = new ArrayList();
            lstParameters.Add(new ParameterIn("@Tarjeta", DbType.String, Tarjeta));
            lstParameters.Add(new ParameterIn("@ApellidoP", DbType.String, ApellidoP));
            lstParameters.Add(new ParameterIn("@ApellidoM", DbType.String, ApellidoM));
            lstParameters.Add(new ParameterIn("@Nombre", DbType.String, Nombre));
            lstParameters.Add(new ParameterIn("@FechaNac", DbType.String, FechaNac.Value.Year.ToString() + ((FechaNac.Value.Month.ToString().Length == 1) ? "0" + FechaNac.Value.Month.ToString() : FechaNac.Value.Month.ToString())
                                                + ((FechaNac.Value.Day.ToString().Length == 1) ? "0" + FechaNac.Value.Day.ToString() : FechaNac.Value.Day.ToString())));
            lstParameters.Add(new ParameterIn("@CorreoE", DbType.String, Email));
            lstParameters.Add(new ParameterIn("@Telefono", DbType.String, Telefono));
            lstParameters.Add(new ParameterIn("@TelefonoM", DbType.String, TelefonoM));
            lstParameters.Add(new ParameterIn("@Sexo", DbType.String, Sexo));
            lstParameters.Add(new ParameterIn("@ProgramaID", DbType.String, "1"));
            lstParameters.Add(new ParameterIn("@Llave", DbType.String, "998877"));
            lstParameters.Add(new ParameterIn("@Sucursal", DbType.String, "90"));
            lstParameters.Add(new ParameterIn("@Terminal", DbType.String, "999999"));
            lstParameters.Add(new ParameterIn("@Usuario", DbType.String, Usuario));

            dtsResult = DataBase.ExecuteDataSet(null    , "sp_WEBActivarTarjetaV6", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dtsResult;
        }

        public static DataTable ObtenerClubs(string Tarjeta)
        {
            DataSet dtsResult = new DataSet();

            ArrayList lstParameters = new ArrayList();
            lstParameters.Add(new ParameterIn("tarjeta", DbType.String, Tarjeta));

            dtsResult = DataBase.ExecuteDataSet(null, "sp_obtener_clubsTarjeta", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dtsResult.Tables[0];
        }

        public static DataTable ObtenerNivel(string Tarjeta)
        {
            DataSet dtsResult = new DataSet();

            ArrayList lstParameters = new ArrayList();
            lstParameters.Add(new ParameterIn("tarjeta", DbType.String, Tarjeta));

            dtsResult = DataBase.ExecuteDataSet(null, "sp_obtener_NivelTarjeta", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dtsResult.Tables[0];
        }

        public static DataSet ValidarTarjetaMensaje(string TarjetaO, string tarjetaD)
        {
            DataSet dtsResult = new DataSet();
            ArrayList lstParameters = new ArrayList();
            lstParameters.Add(new ParameterIn("@TarjetaOrigen", DbType.String, TarjetaO));
            lstParameters.Add(new ParameterIn("@TarjetaDestino", DbType.String, tarjetaD));

            dtsResult = DataBase.ExecuteDataSet(null,"SP_ValidarTarjetaSegundoPaso",(ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dtsResult;
        }
    }
}
