using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataSQL;

namespace Datos
{
    
    public class DatActualizarCliente : ConexionBD
    {
        ClassDataSQL1 objClassDataSQL1=null;
        public DataSet ActualizarMisDatos(string telefono, string celular, string calle, string noExterior, string noInterior, string idEstado, string idMunicipio, string idColonia, string cp, int idSexo, string correoElectronico, string idCliente, string fechaNacimiento)
        {
            try
            {
                objClassDataSQL1 = new ClassDataSQL1();
                SqlParameter[] objParametros = new SqlParameter[13];

                objParametros[0] = new SqlParameter("@Telefono", telefono);
                objParametros[1] = new SqlParameter("@TelefonoM", celular);
                objParametros[2] = new SqlParameter("@Calle", calle);
                objParametros[3] = new SqlParameter("@NumExt", noExterior);
                objParametros[4] = new SqlParameter("@NumInt", noInterior);
                objParametros[5] = new SqlParameter("@IdEstado", idEstado);
                objParametros[6] = new SqlParameter("@IdMunicipio", idMunicipio);
                objParametros[7] = new SqlParameter("@IdColonia", idColonia);
                objParametros[8] = new SqlParameter("@CP", cp);
                objParametros[9] = new SqlParameter("@Sexo", idSexo);
                objParametros[10] = new SqlParameter("@CorreoElectronico", correoElectronico);
                objParametros[11] = new SqlParameter("@Tarjeta", idCliente);
                objParametros[12] = new SqlParameter("@FechaNacimiento", fechaNacimiento);

            
                DataSet ds = new DataSet();
                ds= objClassDataSQL1.LlenaDatosDataSet("sp_WEBActualizarMisDatos",objParametros);
                return ds;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public DataSet ActualizarMisDatosEncuesta(string fechaNacimiento, string celular, string calle, string noExterior, string noInterior, string idEstado, string idMunicipio, string idColonia, string cp, int idSexo, string correoElectronico, string idCliente)
        {
            try
            {
                objClassDataSQL1 =new ClassDataSQL1();
                SqlParameter[] objSqlParameter=new SqlParameter[12];
            
                objSqlParameter[0] = new SqlParameter("@FechaNacimiento", fechaNacimiento);
                objSqlParameter[1] = new SqlParameter("@TelefonoM", celular);
                objSqlParameter[2] = new SqlParameter("@Calle", calle);
                objSqlParameter[3] = new SqlParameter("@NumExt", noExterior);
                objSqlParameter[4] = new SqlParameter("@NumInt", noInterior);
                objSqlParameter[5] = new SqlParameter("@IdEstado", idEstado);
                objSqlParameter[6] = new SqlParameter("@IdMunicipio", idMunicipio);
                objSqlParameter[7] = new SqlParameter("@IdColonia", idColonia);
                objSqlParameter[8] = new SqlParameter("@CP", cp);
                objSqlParameter[9] = new SqlParameter("@Sexo", idSexo);
                objSqlParameter[10] = new SqlParameter("@CorreoElectronico", correoElectronico);
                objSqlParameter[11] = new SqlParameter("@Tarjeta", idCliente);

                DataSet ds = new DataSet();
                ds = objClassDataSQL1.LlenaDatosDataSet("sp_WEBActualizaDatosEncuesta",objSqlParameter);
             
                return ds;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public DataSet ObtenerMisDatos(string idCliente)
        {
            try
            {
                objClassDataSQL1 = new ClassDataSQL1();
                SqlParameter[] objSqlParameter = new SqlParameter[1];

                objSqlParameter[0]=new SqlParameter("@Tarjeta",idCliente);

                DataSet ds = new DataSet();
                ds=objClassDataSQL1.LlenaDatosDataSet("sp_ObtenerMisDatos",objSqlParameter);
                
                return ds;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public DataTable ObtenerCatalogoSexo()
        {
            try
            {
                objClassDataSQL1 = new ClassDataSQL1();
                DataTable dt = new DataTable();
                dt = objClassDataSQL1.LlenaDatosDatatable("sp_CargaComboGenero");
                return dt;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public int ValidaRegistro1aVez(string tarjeta)
        {
            try
            {
                objClassDataSQL1 = new ClassDataSQL1();
                SqlParameter[] objSqlParameter = new SqlParameter[1];

                objSqlParameter[0]=new SqlParameter("@tarjeta",tarjeta);

                int noFilas = 0;
                noFilas = objClassDataSQL1.EjecutaStoreNonqueryint("sp_ValidaRegistro1aVez", objSqlParameter);
            
                return noFilas;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public int ValidaRegistro1aVezV2(string tarjeta)
        {
            try
            {
                objClassDataSQL1 = new ClassDataSQL1();
                SqlParameter[] objSqlParameter = new SqlParameter[1];

                objSqlParameter[0]= new SqlParameter("@tarjeta",tarjeta);
                int noFilas = 0;
                noFilas = objClassDataSQL1.EjecutaStoreNonqueryint("sp_ValidaRegistro1aVezV2",objSqlParameter);
                return noFilas;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public DataSet RegistroPrimeraVez(string tarjeta, int tieneHijos, int noHijos, int tienePadecimientoCrónico, string detalle, string usuario)
        {
            try
            {
                objClassDataSQL1 = new ClassDataSQL1();
                SqlParameter[] objSqlParameter = new SqlParameter[6];

                objSqlParameter[0] = new SqlParameter("@strtarjeta",tarjeta);
                objSqlParameter[1] = new SqlParameter("@intHijos",tieneHijos);
                objSqlParameter[2] = new SqlParameter("@intCuantos",noHijos);
                objSqlParameter[3] = new SqlParameter("@intCronico",tienePadecimientoCrónico);
                objSqlParameter[4] = new SqlParameter("@xmlDetalle",detalle);
                objSqlParameter[5] = new SqlParameter("@usuario",usuario);
            
                DataSet ds = new DataSet();
                ds= objClassDataSQL1.LlenaDatosDataSet("sp_InsertaCuestionarioInicial",objSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public DataSet RegistroPrimeraVezV2(string tarjeta, int tieneHijos, int noPersonas, int tienePadecimientoCrónico, string detalle, string usuario)
        {
            try
            {
                objClassDataSQL1 = new ClassDataSQL1();
                SqlParameter[] objSqlParameter = new SqlParameter[6];

                objSqlParameter[0] = new SqlParameter("@strtarjeta", tarjeta);
                objSqlParameter[1] = new SqlParameter("@intHijos", tieneHijos);
                objSqlParameter[2] = new SqlParameter("@intCuantos", noPersonas);
                objSqlParameter[3] = new SqlParameter("@intCronico", tienePadecimientoCrónico);
                objSqlParameter[4] = new SqlParameter("@xmlDetalle", detalle);
                objSqlParameter[5] = new SqlParameter("@usuario", usuario);

                DataSet ds = new DataSet();
                ds = objClassDataSQL1.LlenaDatosDataSet("sp_InsertaCuestionarioInicialv2", objSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        
        public int EnviarCorreoContacto(string nombre, string tarjeta, string correo, string comentario)
        {
            try
            {
                objClassDataSQL1 = new ClassDataSQL1();
                SqlParameter[] objSqlParameter = new SqlParameter[4];

                objSqlParameter[0] = new SqlParameter("@nombre", nombre);
                objSqlParameter[1] = new SqlParameter("@tarjeta", tarjeta);
                objSqlParameter[2] = new SqlParameter("@correo", correo);
                objSqlParameter[3] = new SqlParameter("@comentario", comentario);
                
                int respuesta = 0;
                respuesta = objClassDataSQL1.EjecutaStoreNonqueryint("sp_EnviarCorreoContacto",objSqlParameter);
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public DataSet RecuperaContraseña(string Tipo, string usuario, string tarjeta, string correo)
        {
            try
            {
                objClassDataSQL1 = new ClassDataSQL1();
                SqlParameter[] objSqlParameter = new SqlParameter[4];

                objSqlParameter[0] = new SqlParameter("@Tipo", Tipo);
                objSqlParameter[1] = new SqlParameter("@usuario", usuario);
                objSqlParameter[2] = new SqlParameter("@tarjeta", tarjeta);
                objSqlParameter[3] = new SqlParameter("@correo", correo);

                DataSet ds = new DataSet();
                ds = objClassDataSQL1.LlenaDatosDataSet("sp_EnviarCorreoContraseña", objSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                conectame.Close();
                throw new ApplicationException(ex.Message);
            }
        }

        public DataSet CambiarContraseña(string tarjeta, string contraseñaActual, string nuevaContraseña, string confirmaContraseña)
        {
            try
            {
                objClassDataSQL1 = new ClassDataSQL1();
                SqlParameter[] objSqlParameter = new SqlParameter[4];

                objSqlParameter[0] = new SqlParameter("@Tarjeta", tarjeta);
                objSqlParameter[1] = new SqlParameter("@ContraseñaActual", contraseñaActual);
                objSqlParameter[2] = new SqlParameter("@NuevaContraseña", nuevaContraseña);
                objSqlParameter[3] = new SqlParameter("@ConfirmaContraseña", confirmaContraseña);

                DataSet ds = new DataSet();
                ds = objClassDataSQL1.LlenaDatosDataSet("sp_CambiarContraseña", objSqlParameter);
                return ds;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public DataTable ObtenerDataTable(string nombreSP)
        {
            try
            {
            objClassDataSQL1 =new ClassDataSQL1();
            DataTable dt =new DataTable();
             
            dt=objClassDataSQL1.LlenaDatosDatatable(nombreSP);
                return dt;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

       


    }
}
