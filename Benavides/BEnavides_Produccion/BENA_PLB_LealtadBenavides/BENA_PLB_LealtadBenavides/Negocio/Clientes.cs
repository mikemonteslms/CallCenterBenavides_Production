using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;
using Entidades;

namespace Negocio
{
    public class Clientes
    {
        #region Metodos
        Datos.SqlTransac sqlClientes = new Datos.SqlTransac();
        SqlTransac objSqlTransac = new SqlTransac();
        DatActualizarCliente datos = new DatActualizarCliente();

        /// <summary>
        /// Método que nos permite Guardar la información de la cliente sin Tarjeta
        /// </summary>
        /// <returns>DataSet con la informacion Resultado</returns>

        public SqlParameter[] Parametros(string strTarjeta)
        {
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@strTarjeta", strTarjeta);

            return parameters;
        }

        public string AltaClientes(string Cliente_strUniqueIdentifier, string Cliente_strApellidoPaterno,
                        string Cliente_strApellidoMaterno, string Cliente_strPrimerNombre,
                        string Cliente_strCedula, string Cliente_strTelefonoCasa, string strUsuario)
        {
            Datos.SqlTransac sqlTransacciones = new Datos.SqlTransac();
            try
            {
                //string strTarjetas = ParsearInformacionTarjetas(listaTarjetas);
                SqlParameter[] parametrosSP = new SqlParameter[7];
                parametrosSP[0] = new SqlParameter("@Cliente_strUniqueIdentifier", Cliente_strUniqueIdentifier);
                parametrosSP[1] = new SqlParameter("@Cliente_strApellidoPaterno", Cliente_strApellidoPaterno);
                parametrosSP[2] = new SqlParameter("@Cliente_strApellidoMaterno", Cliente_strApellidoMaterno);
                parametrosSP[3] = new SqlParameter("@Cliente_strPrimerNombre", Cliente_strPrimerNombre);
                parametrosSP[4] = new SqlParameter("@Cliente_strCedula", Cliente_strCedula);
                parametrosSP[5] = new SqlParameter("@Cliente_strTelefonoCasa", Cliente_strTelefonoCasa);
                parametrosSP[6] = new SqlParameter("@strUsuario", strUsuario);
                DataSet oDS = sqlTransacciones.RegresaDataSetSP("sp_InsertaCliente", parametrosSP);

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
                return "|error 3|Error al Ejecutar el Stored Procedure sp_InsertaCliente||0|0";
                //throw(e);
            }
        }

        public DataSet RegistraCliente(string usuarioAlta, string nombre, string apellidoP, string apellidoM, string fecha, string correo, string telefono, string telefonoM, int genero, string calle, string numExt, string numInt, int colonia, int municipio, int estado, string cp, string tarjeta, string contra)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("UsuarioALTA", DbType.String, usuarioAlta));
                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("Contraseña", DbType.String, contra));
                listParameters.Add(new ParameterIn("Nombre ", DbType.String, nombre));
                listParameters.Add(new ParameterIn("ApellidoP ", DbType.String, apellidoP));
                listParameters.Add(new ParameterIn("ApellidoM ", DbType.String, apellidoM));
                listParameters.Add(new ParameterIn("FechaNac", DbType.String, fecha));
                listParameters.Add(new ParameterIn("CorreoE", DbType.String, correo));
                listParameters.Add(new ParameterIn("Telefono", DbType.String, telefono));
                listParameters.Add(new ParameterIn("TelefonoM", DbType.String, telefonoM));
                listParameters.Add(new ParameterIn("Genero", DbType.Int32, genero));
                listParameters.Add(new ParameterIn("Calle", DbType.String, calle));
                listParameters.Add(new ParameterIn("NumExt", DbType.String, numExt));
                listParameters.Add(new ParameterIn("NumInt", DbType.String, numInt));
                listParameters.Add(new ParameterIn("IdColonia", DbType.Int32, colonia));
                listParameters.Add(new ParameterIn("IdMunicipio", DbType.Int32, municipio));
                listParameters.Add(new ParameterIn("IdEstado", DbType.Int32, estado));
                listParameters.Add(new ParameterIn("CP", DbType.String, cp));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_WEBActivarTarjeta", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_WEBActivarTarjeta.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        //public ArrayList[] Parametros(ParameterIn[] Parametros)
        //{
        //    ArrayList listParameters = new ArrayList();

        //    for (int i = 0; i < Parametros.Length -1; i++)
        //    {
        //        listParameters.Add(Parametros);                
        //    }
        //    return listParameters;
        //}

        //public DataSet PruebaDatosActivacionesxSucursal()
        //{
        //    try
        //    {
        //        //ArrayList listParameters = new ArrayList();
        //        //listParameters.Add(new ParameterIn("FechaIni", DbType.String, FechaIni));
        //        //listParameters.Add(new ParameterIn("FechaFin", DbType.String, FechaFin));

        //        DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_ReporteActivacionesxSucursal", ParameterIn[]Parametros());

        //        return dsReversion;
        //    }
        //    catch (Exception ex)
        //    {
        //        Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ReporteActivacionesxSucursal.", ex);
        //        ExceptionManager.HandleException(e, 1, 5000, 6);
        //        throw (e);
        //    }
        //}

        public DataSet ValidaTarjeta(string tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("tarjeta", DbType.String, tarjeta));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_ValidaTarjeta", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ValidaTarjeta.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ValidaTarjetaCC(string tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("tarjeta", DbType.String, tarjeta));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_ValidaTarjetaCC", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ValidaTarjetaCC.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ValidaTarjetaDC(string tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("tarjeta", DbType.String, tarjeta));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_ValidaTarjetaDC", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ValidaTarjetaDC.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet RegistraClienteCallCenter(string usuarioAlta, string nombre, string apellidoP, string apellidoM, string fecha, string correo, string telefono, string telefonoM, int genero, string calle, string numExt, string numInt, int colonia, int municipio, int estado, string cp, string tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("UsuarioALTA", DbType.String, usuarioAlta));
                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("Nombre ", DbType.String, nombre));
                listParameters.Add(new ParameterIn("ApellidoP ", DbType.String, apellidoP));
                listParameters.Add(new ParameterIn("ApellidoM ", DbType.String, apellidoM));
                listParameters.Add(new ParameterIn("FechaNac", DbType.String, fecha));
                listParameters.Add(new ParameterIn("CorreoE", DbType.String, correo));
                listParameters.Add(new ParameterIn("Telefono", DbType.String, telefono));
                listParameters.Add(new ParameterIn("TelefonoM", DbType.String, telefonoM));
                listParameters.Add(new ParameterIn("Genero", DbType.Int32, genero));
                listParameters.Add(new ParameterIn("Calle", DbType.String, calle));
                listParameters.Add(new ParameterIn("NumExt", DbType.String, numExt));
                listParameters.Add(new ParameterIn("NumInt", DbType.String, numInt));
                listParameters.Add(new ParameterIn("IdColonia", DbType.Int32, colonia));
                listParameters.Add(new ParameterIn("IdMunicipio", DbType.Int32, municipio));
                listParameters.Add(new ParameterIn("IdEstado", DbType.Int32, estado));
                listParameters.Add(new ParameterIn("CP", DbType.String, cp));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_WEBActivarTarjetaCC", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_WEBActivarTarjetaCC.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet DatosCLiente(string idcliente)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("IDCliente", DbType.String, idcliente));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_ObtenerDatosCliente", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ObtenerDatosCliente.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet DatosTransaccionesCliente(string idcliente)
        {
            try
            {
                ArrayList listParameters = new ArrayList();


                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, idcliente));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_WEBTransaccionescTarjeta", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_WEBTransaccionescTarjeta.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet DatosListaLlamadas(string tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();


                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, tarjeta));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_WEBListaLlamadasTarjeta", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_WEBListaLlamadasTarjeta.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet DatosTransaccionesReportes(string tarjeta, int parametro)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("Parametro", DbType.String, parametro));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_ReportesExcelBenavides", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ReportesExcelBenavides", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet DatosTransaccionesReportes(string tarjeta, int parametro1, string parametro2)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("Parametro1", DbType.String, parametro1));
                listParameters.Add(new ParameterIn("Parametro2", DbType.String, parametro2));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_ObtieneTarjeta", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ObtieneTarjeta", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet DatosActivacionesxSucursal(string FechaIni, string FechaFin)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("FechaIni", DbType.String, FechaIni));
                listParameters.Add(new ParameterIn("FechaFin", DbType.String, FechaFin));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "SP_ReportesActivacionesTransacciones", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ReportesActivacionesTransacciones.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet DatosFechaActivacion(string nombreSP)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                //listParameters.Add(new ParameterIn("FechaIni", DbType.String, FechaIni));
                //listParameters.Add(new ParameterIn("FechaFin", DbType.String, FechaFin));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, nombreSP, (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure" + nombreSP + " .", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet DatosLlenaConsultaSP(string nombreSP)
        {
            try
            {
                ArrayList listParameters = new ArrayList();
                //listParameters.Add(new ParameterIn("FechaIni", DbType.String, Fecha));                
                DataSet dsReversion = DataBase.ExecuteDataSet(null, nombreSP, (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));
                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure nombreSP.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet EnviaCorreoContacto(string nombre, string tarjeta, string correo, string comentario)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("nombre", DbType.String, nombre));
                listParameters.Add(new ParameterIn("tarjeta", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("correo", DbType.String, correo));
                listParameters.Add(new ParameterIn("comentario", DbType.String, comentario));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_EnviarCorreoContacto", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_EnviarCorreoContacto.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ActualizandoCliente(EntActualizarCliente ent)
        {
            try
            {
                DatActualizarCliente datos = new DatActualizarCliente();
                DataSet dsRegresa = datos.ActualizarMisDatos(ent.Telefono, ent.TelefonoCelular, ent.Calle, ent.NoExterior, ent.NoInterior, ent.idEstado, ent.idMunicipio, ent.idColonia, ent.CP, ent.idSexo, ent.CorreoElectronico, ent.IdCliente, ent.fechaNacimiento);
                return dsRegresa;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_WEBActualizarMisDatos", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ActualizandoClienteEncuesta(EntActualizarCliente ent)
        {
            try
            {
                DatActualizarCliente datos = new DatActualizarCliente();
                DataSet dsRegresa = datos.ActualizarMisDatosEncuesta(ent.fechaNacimiento, ent.TelefonoCelular, ent.Calle, ent.NoExterior, ent.NoInterior, ent.idEstado, ent.idMunicipio, ent.idColonia, ent.CP, ent.idSexo, ent.CorreoElectronico, ent.IdCliente);
                return dsRegresa;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_WEBActualizaDatosEncuesta", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet RegistroPrimeraVez(EntCuestionarioInicial ent)
        {
            try
            {
                DataSet dsRegresa = datos.RegistroPrimeraVez(ent.tarjeta, ent.tieneHijos, ent.NoHijos, ent.tienePadecimientoCronico, ent.xmlDetalle, ent.usuario);
                return dsRegresa;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_InsertaCuestionarioInicial", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet RegistroPrimeraVezV2(EntCuestionarioInicial ent)
        {
            try
            {
                DataSet dsRegresa = datos.RegistroPrimeraVezV2(ent.tarjeta, ent.tieneHijos, ent.NoPersonas, ent.tienePadecimientoCronico, ent.xmlDetalle, ent.usuario);
                return dsRegresa;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_InsertaCuestionarioInicialv2", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet MisDatosCliente(EntActualizarCliente ent)
        {
            try
            {
                DatActualizarCliente datos = new DatActualizarCliente();
                DataSet ds = datos.ObtenerMisDatos(ent.IdCliente);
                return ds;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public List<EntActualizarCliente> ListaCatalogoSexo(EntActualizarCliente ent)
        {
            try
            {
                DatActualizarCliente datos = new DatActualizarCliente();
                DataTable dt = datos.ObtenerCatalogoSexo();
                List<EntActualizarCliente> lista = new List<EntActualizarCliente>();
                foreach (DataRow dr in dt.Rows)
                {
                    EntActualizarCliente eac = new EntActualizarCliente();
                    eac.idSexo = (int)dr["Clave"];
                    eac.Sexo = (string)dr["Genero"];
                    lista.Add(eac);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public List<EntCuestionarioInicial> ListaCatalogosCuestionarioInicial(EntCuestionarioInicial ent)
        {
            try
            {
                Catalogos catCI = new Catalogos();
                DataTable dt = catCI.ObtenerCatalogosCuestionarioInicial(ent.cuestionario, ent.pregunta);
                List<EntCuestionarioInicial> lista = new List<EntCuestionarioInicial>();
                foreach (DataRow dr in dt.Rows)
                {
                    EntCuestionarioInicial entCI = new EntCuestionarioInicial();
                    entCI.IdRespuesta = (int)dr["IdRespuesta"];
                    entCI.Respuesta = (string)dr["Respuesta"];
                    lista.Add(entCI);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public DataSet DatosCasosInusuales(int Tipo)
        {
            try
            {
                DatReportes datos = new DatReportes();
                EntActualizarCliente ent = new EntActualizarCliente();
                DataSet ds = datos.ObtenerReporteCasosInusuales(Tipo);
                return ds;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public DataSet RecuperaContraseña(EntActualizarCliente ent)
        {
            try
            {
                DatActualizarCliente datos = new DatActualizarCliente();
                DataSet dsRegresa = datos.RecuperaContraseña(ent.Tipo, ent.IdCliente, ent.tarjeta, ent.CorreoElectronico);
                return dsRegresa;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_EnviarCorreoContraseña", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet CambiarContraseña(EntActualizarCliente ent)
        {
            try
            {
                DatActualizarCliente datos = new DatActualizarCliente();
                DataSet dsRegresa = datos.CambiarContraseña(ent.tarjeta, ent.contraseñaActual, ent.nuevaContraseña, ent.confirmaContraseña);
                return dsRegresa;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_CambiarContraseña", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet DatosAcualizaDatoContacto(string tarjeta, string AceptaCorreoE, string AceptaCelular, string AceptaTelefono, string AceptaCorreoP, string motivo, string usuario)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("AceptaContactoCorreoElectronico", DbType.String, AceptaCorreoE));
                listParameters.Add(new ParameterIn("AceptaContactoCelular", DbType.String, AceptaCelular));
                listParameters.Add(new ParameterIn("AceptaContactoTelefonoParticular", DbType.String, AceptaTelefono));
                listParameters.Add(new ParameterIn("AceptaContactoCorreoPostal", DbType.String, AceptaCorreoP));
                listParameters.Add(new ParameterIn("Motivo", DbType.String, motivo));
                listParameters.Add(new ParameterIn("Usuario", DbType.String, usuario));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_WEBActualizarDatosContacto", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_WEBActualizarDatosContacto.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataTable DatosDataDable(string nombreSP)
        {
            try
            {
                DataTable dsReversion = datos.ObtenerDataTable(nombreSP);

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure nombreSP.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataTable ImagenesCarrusel()
        {
            try 
            {
                DataTable dsImagenes = datos.ObtenerDataTable("SP_Imagenes_Carrusel");
                return dsImagenes;
            }
            catch(Exception ex)
            {
                Exception e = new Exception("Error al ejecutar el store procedure SP_Imagenes_Carrusel.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataTable ImagenesLaboratorios()
        {
            try
            {
                DataTable dsImagenes = datos.ObtenerDataTable("SP_Imagenes_Laboratorios");
                return dsImagenes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al ejecutar el store procedure SP_Imagenes_Laboratorios.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet InsertaPromocion(string ProgramaID, string Llave, string Descripcion, string FIni, string FFin, string Usuario, string tipoP)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("ProgramaID", DbType.String, ProgramaID));
                listParameters.Add(new ParameterIn("Llave", DbType.String, Llave));
                listParameters.Add(new ParameterIn("NombrePromocion", DbType.String, Descripcion));
                listParameters.Add(new ParameterIn("FInicio", DbType.String, FIni));
                listParameters.Add(new ParameterIn("FTermino", DbType.String, FFin));
                listParameters.Add(new ParameterIn("UsuarioAltaPromo", DbType.String, Usuario));
                listParameters.Add(new ParameterIn("TipoPromocion", DbType.String, tipoP));


                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_InsertarPromocion", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_InsertarPromocion.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet LlenaTablaPromocion(string skuBenavides, string sku, int CantidadCompra, int CantidadMaxCompra, decimal decPuntosDirectos, decimal decPesosDirectos, decimal decPorcentajeExcel, decimal decPorcentaje)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("skuBenavides", DbType.String, skuBenavides));
                listParameters.Add(new ParameterIn("sku", DbType.String, sku));
                listParameters.Add(new ParameterIn("CantidadCompra", DbType.Int32, CantidadCompra));
                listParameters.Add(new ParameterIn("CantidadMaxCompra", DbType.Int32, CantidadMaxCompra));
                listParameters.Add(new ParameterIn("decPuntosDirectos", DbType.Decimal, decPuntosDirectos));
                listParameters.Add(new ParameterIn("decPesosDirectos", DbType.Decimal, decPesosDirectos));
                listParameters.Add(new ParameterIn("decPorcentajeExcel", DbType.Decimal, decPorcentajeExcel));
                listParameters.Add(new ParameterIn("decPorcentaje", DbType.Decimal, decPorcentaje));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_LlenarTblTmpInsertaPromocion", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_LlenarTblTmpInsertaPromocion.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet InsertaPromocionPorPieza(string programaID, string llave, string skuProducto, string skuObsequio, string fInicio, string fFin, string idPromo, string idCuponDescuento, string piezasCompra, string piezasObsequio, string usuario)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("ProgramaID", DbType.String, programaID));
                listParameters.Add(new ParameterIn("Llave", DbType.String, llave));
                listParameters.Add(new ParameterIn("SkuProducto", DbType.String, skuProducto));
                listParameters.Add(new ParameterIn("SkuObsequio", DbType.String, skuObsequio));
                listParameters.Add(new ParameterIn("FInicio", DbType.String, fInicio));
                listParameters.Add(new ParameterIn("FFin", DbType.String, fFin));
                listParameters.Add(new ParameterIn("IdPromo", DbType.String, idPromo));
                listParameters.Add(new ParameterIn("CuponDescuento", DbType.String, idCuponDescuento));
                listParameters.Add(new ParameterIn("PiezasCompra", DbType.String, piezasCompra));
                listParameters.Add(new ParameterIn("PiezasObsequio", DbType.String, piezasObsequio));
                listParameters.Add(new ParameterIn("Usuario", DbType.String, usuario));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_InsertaPromocionPorPieza", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_InsertaPromocionPorPieza.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet Valida_SkuProducto(string sku)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("sku", DbType.String, sku));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_Valida_SkuProducto", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_Valida_SkuProducto.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet InsertaPromocionXtarjeta(string ProgramaID, string Llave, string Tarjeta_strID, string Cupon, string Sexo, string NSE, int EdadInicial, string EdadFinal, string descripcion, string Url, string URLDetalle, string URLPromo, int EstatusApp, string IniVigencia, string FinVigencia)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("ProgramaID", DbType.String, ProgramaID));
                listParameters.Add(new ParameterIn("Llave", DbType.String, Llave));
                listParameters.Add(new ParameterIn("Tarjeta_strID", DbType.String, Tarjeta_strID));
                listParameters.Add(new ParameterIn("Cupon", DbType.String, Cupon));
                listParameters.Add(new ParameterIn("Sexo", DbType.String, Sexo));
                listParameters.Add(new ParameterIn("NSE", DbType.String, NSE));
                listParameters.Add(new ParameterIn("EdadInicial", DbType.Int16, EdadInicial));
                listParameters.Add(new ParameterIn("EdadFinal", DbType.Int16, EdadFinal));
                listParameters.Add(new ParameterIn("descripcion", DbType.String, descripcion));
                listParameters.Add(new ParameterIn("Url", DbType.String, Url));
                listParameters.Add(new ParameterIn("URLDetalle", DbType.String, URLDetalle));
                listParameters.Add(new ParameterIn("URLPromo", DbType.String, URLPromo));
                listParameters.Add(new ParameterIn("EstatusApp", DbType.Int32, EstatusApp));
                listParameters.Add(new ParameterIn("IniVigencia", DbType.String, IniVigencia));
                listParameters.Add(new ParameterIn("FinVigencia", DbType.String, FinVigencia));



                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_InsertaPromocionesxTarjeta", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_InsertaPromocionesxTarjeta.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet TruncaTablaTmpVencimiento()
        {
            try
            {
                DataSet dsReversion = DataBase.ExecuteQuery("ConnectionString", "truncate table tblTMPVencimientoPlatino");

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar la instruccion sql", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet InsertaEnTablaVencimientoPlatino(string tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("tarjeta", DbType.String, tarjeta));

                DataSet dsReversion = DataBase.ExecuteQuery("ConnectionString", "INSERT INTO tblTMPVencimientoPlatino (Tarjeta_strNumero) VALUES (" + tarjeta + ")");

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_LlenartblTMPVencimientoPlatino.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet EjecutaSPVencimientoPlatino()
        {
            try
            {
                DataSet dsReversion = DataBase.ExecuteQuery("ConnectionString", "sp_InsertaTarjetasVencimientoPlatino");

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el sp_InsertaTarjetasVencimientoPlatino", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public string EnviaCorreoVencimientoPuntos(string mensaje)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("mensaje", DbType.String, mensaje));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_EnviarCorreoCargaVencimientoPlatino", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return "Correcto";
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_EnviarCorreoCargaVencimientoPlatino.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ValidaTarjetaCodigoSMS(string tarjeta, string usuario)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("tarjeta", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("usuario", DbType.String, usuario));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "sp_GeneraSMSID", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsTarjeta;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_GeneraSMSID.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ValidaCodigoSMS(string tarjeta, string codigo)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("tarjeta", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("UidCupUrl", DbType.String, codigo));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "sp_ValidaCodigoSMS", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsTarjeta;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ValidaCodigoSMS.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ValidaCelular(string tarjeta, string celular, string usuario)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("TelefonoM", DbType.String, celular));
                listParameters.Add(new ParameterIn("Usuario", DbType.String, usuario));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "sp_ActualizaCelularCC", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsTarjeta;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ActualizaCelularCC.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }




        #endregion Metodos
    }
}
