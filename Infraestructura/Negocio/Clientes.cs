using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;
using Entidades;
using DataSQL;

namespace Negocio
{
    public class Clientes
    {
        #region Metodos

        ClassDataSQL1 objSqlTransac = null;
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
            objSqlTransac = new ClassDataSQL1();
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
                DataSet oDS = objSqlTransac.LlenaDatosDataSet("sp_InsertaCliente", parametrosSP);

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

        public DataSet RegistraCliente(string usuarioAlta, string nombre, string apellidoP, string apellidoM, string fecha, string correo, string telefono, string telefonoM, int genero, string calle, string numExt, string numInt, int colonia, int municipio, int estado, string cp, string tarjeta, string contra, string farmacia, string snacks, string cuidado, string bebes, string belleza, string hijos)
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
                listParameters.Add(new ParameterIn("Hijos", DbType.String, hijos));
                listParameters.Add(new ParameterIn("Farmacia", DbType.String, farmacia));
                listParameters.Add(new ParameterIn("SnacksBebidas", DbType.String, snacks));
                listParameters.Add(new ParameterIn("CuidadoPersonal", DbType.String, cuidado));
                listParameters.Add(new ParameterIn("Bebes", DbType.String, bebes));
                listParameters.Add(new ParameterIn("Belleza", DbType.String, belleza));

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


        public DataSet RegistraEncuestaPeque(string strtarjeta, string intComprasProdCidado, string intHijos, string dateCuandoNaceraBb, string intCuantosHijos, string strNombreH1, string dateFNacimientoH1, string intGeneroH1, string strNombreH2, string dateFNacimientoH2, string intGeneroH2, string strNombreH3, string dateFNacimientoH3, string intGeneroH3, string strNombreH4, string dateFNacimientoH4, string intGeneroH4)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("strtarjeta ", DbType.String, strtarjeta));
                listParameters.Add(new ParameterIn("intComprasProdCidado ", DbType.String, intComprasProdCidado));
                listParameters.Add(new ParameterIn("intHijos ", DbType.String, intHijos));
                listParameters.Add(new ParameterIn("dateCuandoNaceraBb  ", DbType.String, dateCuandoNaceraBb));
                listParameters.Add(new ParameterIn("intCuantosHijos  ", DbType.String, intCuantosHijos));
                listParameters.Add(new ParameterIn("strNombreH1  ", DbType.String, strNombreH1));
                listParameters.Add(new ParameterIn("dateFNacimientoH1 ", DbType.String, dateFNacimientoH1));
                listParameters.Add(new ParameterIn("intGeneroH1 ", DbType.String, intGeneroH1));
                listParameters.Add(new ParameterIn("strNombreH2 ", DbType.String, strNombreH2));
                listParameters.Add(new ParameterIn("dateFNacimientoH2 ", DbType.String, dateFNacimientoH2));
                listParameters.Add(new ParameterIn("intGeneroH2 ", DbType.String, intGeneroH2));
                listParameters.Add(new ParameterIn("strNombreH3 ", DbType.String, strNombreH3));
                listParameters.Add(new ParameterIn("dateFNacimientoH3 ", DbType.String, dateFNacimientoH3));
                listParameters.Add(new ParameterIn("intGeneroH3 ", DbType.String, intGeneroH3));
                listParameters.Add(new ParameterIn("strNombreH4 ", DbType.String, strNombreH4));
                listParameters.Add(new ParameterIn("dateFNacimientoH4 ", DbType.String, dateFNacimientoH4));
                listParameters.Add(new ParameterIn("intGeneroH4 ", DbType.String, intGeneroH4));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_EncuestaPequesBenavides", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_EncuestaPequesBenavides.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }
        public DataSet RegistraEncuestaPeque(string strtarjeta, string intComprasProdCidado, string intHijos, string dateCuandoNaceraBb, string intCuantosHijos, string strNombreH1, string dateFNacimientoH1, string intGeneroH1, string strNombreH2, string dateFNacimientoH2, string intGeneroH2, string strNombreH3, string dateFNacimientoH3, string intGeneroH3, string strNombreH4, string dateFNacimientoH4, string intGeneroH4, int idHijo1, int idHijo2, int idHijo3, int idHijo4)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("strtarjeta ", DbType.String, strtarjeta));
                listParameters.Add(new ParameterIn("intComprasProdCidado ", DbType.String, intComprasProdCidado));
                listParameters.Add(new ParameterIn("intHijos ", DbType.String, intHijos));
                listParameters.Add(new ParameterIn("dateCuandoNaceraBb  ", DbType.String, dateCuandoNaceraBb));
                listParameters.Add(new ParameterIn("intCuantosHijos  ", DbType.String, intCuantosHijos));
                listParameters.Add(new ParameterIn("strNombreH1  ", DbType.String, strNombreH1));
                listParameters.Add(new ParameterIn("dateFNacimientoH1 ", DbType.String, dateFNacimientoH1));
                listParameters.Add(new ParameterIn("intGeneroH1 ", DbType.String, intGeneroH1));
                listParameters.Add(new ParameterIn("strNombreH2 ", DbType.String, strNombreH2));
                listParameters.Add(new ParameterIn("dateFNacimientoH2 ", DbType.String, dateFNacimientoH2));
                listParameters.Add(new ParameterIn("intGeneroH2 ", DbType.String, intGeneroH2));
                listParameters.Add(new ParameterIn("strNombreH3 ", DbType.String, strNombreH3));
                listParameters.Add(new ParameterIn("dateFNacimientoH3 ", DbType.String, dateFNacimientoH3));
                listParameters.Add(new ParameterIn("intGeneroH3 ", DbType.String, intGeneroH3));
                listParameters.Add(new ParameterIn("strNombreH4 ", DbType.String, strNombreH4));
                listParameters.Add(new ParameterIn("dateFNacimientoH4 ", DbType.String, dateFNacimientoH4));
                listParameters.Add(new ParameterIn("intGeneroH4 ", DbType.String, intGeneroH4));
                if (idHijo1 > 0)
                    listParameters.Add(new ParameterIn("idhijo1", DbType.Int32, idHijo1));
                if (idHijo2 > 0)
                    listParameters.Add(new ParameterIn("idhijo2", DbType.Int32, idHijo2));
                if (idHijo3 > 0)
                    listParameters.Add(new ParameterIn("idhijo3", DbType.Int32, idHijo3));
                if (idHijo4 > 0)
                    listParameters.Add(new ParameterIn("idhijo4", DbType.Int32, idHijo4));


                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_EncuestaPequesBenavides", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_EncuestaPequesBenavides.", ex);
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

        public Parametros ObtenerParametros(string NombrePrm)
        {
            Parametros prmResultado = new Parametros();

            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("NombreParametro", DbType.String, NombrePrm));

                DataSet DS = DataBase.ExecuteDataSet(null, "sp_ObtenValoresPrm", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                foreach (DataRow campo in DS.Tables[0].Rows)
                {
                    prmResultado.TipoDato = campo[0].ToString();
                    prmResultado.ValorPrm = campo[1].ToString();
                }

                return prmResultado;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ObtenValoresPrm.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }
        public void ValidarReglaNegocio(string NombrePrm) 
        { 
            //implementar
        }

        public DataSet RegistraClienteCallCenter(string usuarioAlta, string nombre, string apellidoP, string apellidoM, string fecha, string correo, string telefono, string telefonoM, int genero, string calle, string numExt, string numInt, int colonia, int municipio, int estado, string cp, string tarjeta, bool AceptaRecibirInfo)
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
                listParameters.Add(new ParameterIn("AceptaInfo", DbType.Boolean, AceptaRecibirInfo));

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
                listParameters.Add(new ParameterIn("Parametro", DbType.Int32, 1));
                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_ReportesTransaccionesCC", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

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

        public DataSet ActualizarDatosCliente(string nombre, string AP, string AM, string correo, string celular, string fecha, string genero, string hijos, string cp, string estado, string delegacion, string farmacia, string snacks, string cuidado, string bebes, string belleza, string tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("nombre", DbType.String, nombre));
                listParameters.Add(new ParameterIn("ap", DbType.String, AP));
                listParameters.Add(new ParameterIn("am", DbType.String, AM));
                listParameters.Add(new ParameterIn("CorreoElectronico", DbType.String, correo));
                listParameters.Add(new ParameterIn("TelefonoM", DbType.String, celular));
                listParameters.Add(new ParameterIn("FechaNacimiento", DbType.String, fecha));
                listParameters.Add(new ParameterIn("Sexo", DbType.String, genero));
                listParameters.Add(new ParameterIn("hijos", DbType.String, hijos));
                listParameters.Add(new ParameterIn("CP", DbType.String, cp));
                listParameters.Add(new ParameterIn("IdEstado", DbType.String, estado));
                listParameters.Add(new ParameterIn("IdMunicipio", DbType.String, delegacion));
                listParameters.Add(new ParameterIn("farmacia", DbType.String, farmacia));
                listParameters.Add(new ParameterIn("snacks", DbType.String, snacks));
                listParameters.Add(new ParameterIn("cuidado", DbType.String, cuidado));
                listParameters.Add(new ParameterIn("bebes", DbType.String, bebes));
                listParameters.Add(new ParameterIn("belleza", DbType.String, belleza));
                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, tarjeta));


                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_ActualizaDatosClienteWeb", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ActualizaDatosClienteWeb.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ImagenesPromociones(string idcat, string PromoID = "", string Tarjeta = "")
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                if (idcat != "00")
                    listParameters.Add(new ParameterIn("idcat", DbType.String, idcat));
                if (!string.IsNullOrEmpty(PromoID))
                    listParameters.Add(new ParameterIn("promoid", DbType.String, PromoID));
                if (!string.IsNullOrEmpty(Tarjeta))
                    listParameters.Add(new ParameterIn("tarjeta", DbType.String, Tarjeta));


                DataSet dsReversion = DataBase.ExecuteDataSet(null, "SP_MWSPromosEspecialistasWEB", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_MWSPromosEspecialistas.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }
        public DataSet ImagenesPromociones(string idcat, string Peques, string PromoID, string Tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                if (idcat != "00")
                    listParameters.Add(new ParameterIn("idcat", DbType.String, idcat));
                if (!string.IsNullOrEmpty(PromoID))
                    listParameters.Add(new ParameterIn("promoid", DbType.String, PromoID));
                listParameters.Add(new ParameterIn("@EsPeques", DbType.Int32, Peques));
                if (!string.IsNullOrEmpty(Tarjeta))
                    listParameters.Add(new ParameterIn("@Tarjeta", DbType.String, Tarjeta));


                DataSet dsReversion = DataBase.ExecuteDataSet(null, "SP_MWSPromosEspecialistasWEB", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_MWSPromosEspecialistas.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet RegresaDatosCliente(string tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, tarjeta));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_WEBRecuperaDatosInscripcion", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_WEBRecuperaDatosInscripcion.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet RegresaDominios()
        {
            try
            {
                DataSet dsReversion = DataBase.ExecuteQuery("ConnectionString", "sp_WEBDominioCorreo");

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_WEBDominioCorreo.", ex);
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

        public DataSet CambiarContraseñaNuevo(string tarjeta, string actual, string nueva, string confirma)
        {
            try
            {
                DatActualizarCliente datos = new DatActualizarCliente();
                DataSet dsRegresa = datos.CambiarContraseña(tarjeta, actual, nueva, confirma);
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
            catch (Exception ex)
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


        public DataSet ObtenerInfoLab(int Lab)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@CvoLab", DbType.String, Lab));

                DataSet dsReversion = DataBase.ExecuteDataSet(null, "sp_ObtenerInfoLaboratorio", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ObtenerInfoLaboratorio.", ex);
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
        public void RegistrarHistoricoCatInteres(string farmacia, string SnacksBebidas, string CuidadoPersonal, string Bebes, string Belleza, string tarjeta)
        {
            ArrayList lstParametros = new ArrayList();
            lstParametros.Add(new ParameterIn("farmacian", DbType.String, farmacia));
            lstParametros.Add(new ParameterIn("Snacks", DbType.String, SnacksBebidas));
            lstParametros.Add(new ParameterIn("CuidadoPer", DbType.String, CuidadoPersonal));
            lstParametros.Add(new ParameterIn("Bebes", DbType.String, Bebes));
            lstParametros.Add(new ParameterIn("Belleza", DbType.String, Belleza));
            lstParametros.Add(new ParameterIn("Tarjeta", DbType.String, tarjeta));
            lstParametros.Add(new ParameterIn("Fecha", DbType.DateTime, DateTime.Now));

            DataBase.ExecuteNonQuery(null, "sp_InsertaHistoricoCatInteres", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
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
        public DataSet ListadoVisitaPortal(string usuario, DateTime FechaI, DateTime FechaF)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Usuario", DbType.String, usuario));
                listParameters.Add(new ParameterIn("FechaI", DbType.DateTime, FechaI));
                listParameters.Add(new ParameterIn("FechaF", DbType.DateTime, FechaF));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "SP_ReporteVisitas", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsTarjeta;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ReporteVisitas.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }
        public DataSet GetPromoRepAcumulado(string Tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "SP_ConultaReportePromos", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsTarjeta;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ConultaReportePromos.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet GetDatosEncuestaPeques(string Tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "SP_GetEncuestaPeques", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsTarjeta;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_GetEncuestaPeques.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }
        public void ActualizaRecibirInfo(string tarjeta, bool estatus)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("tarjeta", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("estatus", DbType.Boolean, estatus));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "SP_ActualizaDatosRecibeInfo", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_GetEncuestaPeques.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }
        public bool GetRecibeInfo(string Tarjeta)
        {

            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("tarjeta", DbType.String, Tarjeta));

                DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "SP_GetRecibeInfo", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));
                if (dsTarjeta.Tables.Count > 0)
                    return Convert.ToBoolean(dsTarjeta.Tables[0].Rows[0][0]);

                return false;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_GetEncuestaPeques.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        #region BusquedaCliente

        public DataSet BusquedaCliente(string pNumeroTarjeta, string pCorreoElectronico, string pTelefonoCasa, string pTelefonoCelular)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Tarjeta_strNumero", DbType.String, pNumeroTarjeta));
                listParameters.Add(new ParameterIn("Cliente_strCorreoElectronico", DbType.String, pCorreoElectronico));
                listParameters.Add(new ParameterIn("Cliente_strTelefonoCasa", DbType.String, pTelefonoCasa));
                listParameters.Add(new ParameterIn("Cliente_strTelefonoCelular", DbType.String, pTelefonoCelular));

                DataSet dsClientes = DataBase.ExecuteDataSet(null, "sp_BusquedaCliente", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsClientes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_BusquedaCliente.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }
        public DataSet BusquedaCliente(string pNumeroTarjeta, string pCorreoElectronico, string pTelefonoCelular, string Nombre, string ApPaterno, string ApMaterno)
        {
            try
            {
                ArrayList listParameters = new ArrayList();
                if (!string.IsNullOrEmpty(pNumeroTarjeta))
                    listParameters.Add(new ParameterIn("Tarjeta_strNumero", DbType.String, pNumeroTarjeta));
                if (!string.IsNullOrEmpty(pCorreoElectronico))
                    listParameters.Add(new ParameterIn("Cliente_strCorreoElectronico", DbType.String, pCorreoElectronico));
                if (!string.IsNullOrEmpty(pTelefonoCelular))
                    listParameters.Add(new ParameterIn("Cliente_strTelefonoCelular", DbType.String, pTelefonoCelular));
                if (!string.IsNullOrEmpty(Nombre))
                    listParameters.Add(new ParameterIn("Cliente_Nombre", DbType.String, Nombre));
                if (!string.IsNullOrEmpty(ApPaterno))
                    listParameters.Add(new ParameterIn("Cliente_APaterno", DbType.String, ApPaterno));
                if (!string.IsNullOrEmpty(ApMaterno))
                    listParameters.Add(new ParameterIn("Cliente_AMaterno", DbType.String, ApMaterno));

                DataSet dsClientes = DataBase.ExecuteDataSet(null, "sp_WebBusquedaClientes", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsClientes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_WebBusquedaClientes.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        #endregion BusquedaCliente
        #region ValidaClienteXCorreo

        public DataSet ValidaClienteXCorreo(string pNumeroTarjeta, string pCorreoElectronico)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Tarjeta_strNumero", DbType.String, pNumeroTarjeta));
                listParameters.Add(new ParameterIn("Cliente_strCorreoElectronico", DbType.String, pCorreoElectronico));

                DataSet dsClientes = DataBase.ExecuteDataSet(null, "sp_ValidaClienteXCorreo", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsClientes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ValidaClienteXCorreo.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        #endregion ValidaClienteXCorreo
        #endregion Metodos

        public static DataTable GetCumpleaños(string tarjeta)
        {
            ArrayList listParameters = new ArrayList();

            listParameters.Add(new ParameterIn("Tarjeta", DbType.String, tarjeta));
            listParameters.Add(new ParameterIn("TipoPromo", DbType.Int32, 1));

            DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "SP_GetBonosCumple", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));
            if (dsTarjeta.Tables.Count > 0)
                return dsTarjeta.Tables[0];

            return null;
        }

        public static DataTable GetPromociones(int PromoId = 0, string Tarjeta = "")
        {
            ArrayList listParameters = new ArrayList();

            listParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
            listParameters.Add(new ParameterIn("IDPromocion", DbType.Int32, PromoId));

            DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "sp_WEBObtenerPromocionesPortal", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));
            if (dsTarjeta.Tables.Count > 0)
                return dsTarjeta.Tables[0];

            return null;
        }

        #region Piezas Gratis
        public DataSet ObtenerHistoricoPiezasGratis(string idcliente, string IDPromo = "")
        {
            ArrayList listParameters = new ArrayList();

            listParameters.Add(new ParameterIn("Tarjeta", DbType.String, idcliente));
            if (!string.IsNullOrEmpty(IDPromo))
                listParameters.Add(new ParameterIn("IdPromocion", DbType.String, IDPromo));
            DataSet dsTarjeta = DataBase.ExecuteDataSet(null, "sp_WEBHistoricoPiezasGratis", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));
            if (dsTarjeta.Tables.Count > 0)
                return dsTarjeta;

            return null;
        }
        #endregion
        #region   Activa promocion

        public static DataTable ActivaCuponPromo(string cel_num, string text, string time_stamp, string ide, string mensajeEnvio, string idMensaje, string uid)
        {
            ArrayList lstParameters = new ArrayList();
            if (!string.IsNullOrEmpty(cel_num))
                lstParameters.Add(new ParameterIn("cel_num", DbType.String, cel_num));
            if (!string.IsNullOrEmpty(text))
                lstParameters.Add(new ParameterIn("text", DbType.String, text));
            if (!string.IsNullOrEmpty(time_stamp))
                lstParameters.Add(new ParameterIn("time_stamp", DbType.String, time_stamp));
            if (!string.IsNullOrEmpty(ide))
                lstParameters.Add(new ParameterIn("ide", DbType.String, ide));
            if (!string.IsNullOrEmpty(mensajeEnvio))
                lstParameters.Add(new ParameterIn("mensajeEnvio", DbType.String, mensajeEnvio));
            if (!string.IsNullOrEmpty(idMensaje))
                lstParameters.Add(new ParameterIn("idMensaje", DbType.String, idMensaje));
            if (!string.IsNullOrEmpty(uid))
                lstParameters.Add(new ParameterIn("strCuponID", DbType.String, uid));

            DataSet dsResult = DataBase.ExecuteDataSet(null, "sp_WEBRegistraCuponValidaCorreoPromo", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dsResult.Tables[0];
        }

        #endregion
        #region Reenvio de Mail Bienvenida

        public static DataSet BuscaCorreoBienvenida(string ClienteID, string Corrreo)
        {
            ArrayList lstParameters = new ArrayList();
            if (!string.IsNullOrEmpty(ClienteID))
                lstParameters.Add(new ParameterIn("Tarjeta", DbType.String, ClienteID));
            if (!string.IsNullOrEmpty(Corrreo))
                lstParameters.Add(new ParameterIn("Correo", DbType.String, Corrreo));
            DataSet dsResult = DataBase.ExecuteDataSet(null, "SP_BuscarCorreoBienvenida", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
            return dsResult;

        }

        public static DataSet ReenviarMailBienvenida(string Tarjeta, string correoA)
        {
            ArrayList lstParameters = new ArrayList();
            if (!string.IsNullOrEmpty(Tarjeta))
                lstParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
            if (!string.IsNullOrEmpty(correoA))
                lstParameters.Add(new ParameterIn("Correo", DbType.String, correoA));
            DataSet dsResult = DataBase.ExecuteDataSet(null, "SP_ReenviarCorreoBienvenida", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
            return dsResult;
        }

        public static DataSet ActualizaMailNotificacion(string Tarjeta, string NewMail)
        {
            ArrayList lstParameters = new ArrayList();
            if (!string.IsNullOrEmpty(Tarjeta))
                lstParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
            if (!string.IsNullOrEmpty(NewMail))
                lstParameters.Add(new ParameterIn("NewCorreo", DbType.String, NewMail));
            return DataBase.ExecuteDataSet(null, "SP_ActualizaMailNotificacion", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
        }

        public static DataSet ReenviarMailBUsuario(string Tarjeta, string correoA)
        {
            ArrayList lstParameters = new ArrayList();
            if (!string.IsNullOrEmpty(Tarjeta))
                lstParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
            if (!string.IsNullOrEmpty(correoA))
                lstParameters.Add(new ParameterIn("Correo", DbType.String, correoA));
            DataSet dsResult = DataBase.ExecuteDataSet(null, "SP_ReenviarCorreoBUsuario", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
            return dsResult;
        }

        public static string ValidaConfirmaCorreo(string Tarjeta)
        {
            string ConfirmoMail = "";
            ArrayList lstParameters = new ArrayList();
            if (!string.IsNullOrEmpty(Tarjeta))
                lstParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));

            DataSet dsResult = DataBase.ExecuteDataSet(null, "SP_ValidaConfirmaCorreo", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
            if (dsResult.Tables.Count > 0)
            {
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    ConfirmoMail = dsResult.Tables[0].Rows[0][0].ToString();
                }
                else
                    ConfirmoMail = "0";
            }
            else
                ConfirmoMail = "0";

            return ConfirmoMail;
        }

        #endregion

        public static DataTable DatosComplementarios(string Tarjeta)
        {
            ArrayList lstParameters = new ArrayList();
            if (!string.IsNullOrEmpty(Tarjeta))
                lstParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
            DataSet dsResult = DataBase.ExecuteDataSet(null, "SP_datosclienteAdicional", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dsResult.Tables[0];
        }

        public static DataSet getPerfilInfo(string Tarjeta)
        {
            ArrayList lstParameters = new ArrayList();
            if (!string.IsNullOrEmpty(Tarjeta))
                lstParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
            DataSet dsResult = DataBase.ExecuteDataSet(null, "SP_WEBdatosPerfil", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dsResult;
        }

        public static DataSet HistoricoDescuentoTarjet(string Tarjeta)
        {
            ArrayList lstParameters = new ArrayList();
            if (!string.IsNullOrEmpty(Tarjeta))
                lstParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
            DataSet dsResult = DataBase.ExecuteDataSet(null, "SP_WEBHistoricoDescuentoTarjeta", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dsResult;
        }

        public DataSet ObtenerComunicacionEnviada(string Tarjeta)
        {
            ArrayList lstParameters = new ArrayList();
            if (!string.IsNullOrEmpty(Tarjeta))
                lstParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
            DataSet dsResult = DataBase.ExecuteDataSet(null, "ConsultarComunicacionEnviada", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dsResult;
        }

        public DataSet ObtenerbenficiosEsp(string Tarjeta)
        {
            ArrayList lstParameters = new ArrayList();
            if (!string.IsNullOrEmpty(Tarjeta))
                lstParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
            DataSet dsResult = DataBase.ExecuteDataSet(null, "SP_WEBConsultaBeneficiosEsp", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dsResult;
        }

        public static DataSet ConsultaAcumulacion(string Tarjeta, string SKU)
        {
            ArrayList lstParameters = new ArrayList();

            lstParameters.Add(new ParameterIn("Tarjeta_strID", DbType.String, Tarjeta));
            lstParameters.Add(new ParameterIn("ProgramaID", DbType.String, "1"));
            lstParameters.Add(new ParameterIn("Producto_intCvo", DbType.String, SKU));


            DataSet dsResult = DataBase.ExecuteDataSet(null, "sp_WSConsulta_PG", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dsResult;
        }

        public static DataSet ObtenerMovimientosDetalle(string Tarjeta, string CodigoInterno)
        {
            ArrayList lstParameters = new ArrayList();

            lstParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
            lstParameters.Add(new ParameterIn("CodigoInterno", DbType.String, CodigoInterno));
            lstParameters.Add(new ParameterIn("codigoBarras", DbType.String, ""));
            lstParameters.Add(new ParameterIn("NoRegistros", DbType.String, "20"));


            DataSet dsResult = DataBase.ExecuteDataSet(null, "sp_WeBObtenerHistorialTransacciones", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dsResult;

        }

        public static string ObtenerEdad(string Tarjeta)
        {
            ArrayList lstParameters = new ArrayList();

            lstParameters.Add(new ParameterIn("tarjeta", DbType.String, Tarjeta));

            DataSet dsResult = DataBase.ExecuteDataSet(null, "sp_obtener_EdadTarjeta", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dsResult.Tables[0].Rows[0][0].ToString();
        }

        public static DataTable CambiarVigencia(string Tarjeta, string fecha, string Usuario)
        {
            ArrayList lstParameters = new ArrayList();
            lstParameters.Add(new ParameterIn("NuevaVig", DbType.DateTime, fecha));
            lstParameters.Add(new ParameterIn("Usuario", DbType.String, Usuario));
            lstParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
            //lstParameters.Add(new ParameterIn("NoRegistros", DbType.String, "20"));


            DataSet dsResult = DataBase.ExecuteDataSet(null, "SP_WeBCambiarVigencia", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

            return dsResult.Tables[0];
        }
    }
}
