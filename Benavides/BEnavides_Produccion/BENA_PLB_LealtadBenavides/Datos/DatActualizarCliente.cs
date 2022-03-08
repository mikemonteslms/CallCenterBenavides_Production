using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DatActualizarCliente : ConexionBD
    {
        public DataSet ActualizarMisDatos(string telefono, string celular, string calle, string noExterior, string noInterior, string idEstado, string idMunicipio, string idColonia, string cp, int idSexo, string correoElectronico, string idCliente, string fechaNacimiento)
        {
            SqlCommand com = new SqlCommand("sp_WEBActualizarMisDatos", conectame);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@Telefono", SqlDbType.VarChar, 15);
            SqlParameter p2 = new SqlParameter("@TelefonoM", SqlDbType.VarChar, 15);
            SqlParameter p3 = new SqlParameter("@Calle", SqlDbType.VarChar, 100);
            SqlParameter p4 = new SqlParameter("@NumExt", SqlDbType.VarChar, 30);
            SqlParameter p5 = new SqlParameter("@NumInt", SqlDbType.VarChar, 30);
            SqlParameter p6 = new SqlParameter("@IdEstado", SqlDbType.Int);
            SqlParameter p7 = new SqlParameter("@IdMunicipio", SqlDbType.Int);
            SqlParameter p8 = new SqlParameter("@IdColonia", SqlDbType.Int);
            SqlParameter p9 = new SqlParameter("@CP", SqlDbType.VarChar, 5);
            SqlParameter p10 = new SqlParameter("@Sexo", SqlDbType.VarChar, 1);
            SqlParameter p11 = new SqlParameter("@CorreoElectronico", SqlDbType.VarChar, 80);
            SqlParameter p12 = new SqlParameter("@Tarjeta", SqlDbType.VarChar, 19);
            SqlParameter p13 = new SqlParameter("@FechaNacimiento", SqlDbType.VarChar, 8);
            p1.Value = telefono;
            p2.Value = celular;
            p3.Value = calle;
            p4.Value = noExterior;
            p5.Value = noInterior;
            p6.Value = idEstado;
            p7.Value = idMunicipio;
            p8.Value = idColonia;
            p9.Value = cp;
            p10.Value = idSexo;
            p11.Value = correoElectronico;
            p12.Value = idCliente;
            p13.Value = fechaNacimiento;
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            com.Parameters.Add(p5);
            com.Parameters.Add(p6);
            com.Parameters.Add(p7);
            com.Parameters.Add(p8);
            com.Parameters.Add(p9);
            com.Parameters.Add(p10);
            com.Parameters.Add(p11);
            com.Parameters.Add(p12);
            com.Parameters.Add(p13);
            try
            {
                conectame.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conectame.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conectame.Close();
                throw new ApplicationException(ex.Message);
            }
        }

        public DataSet ActualizarMisDatosEncuesta(string fechaNacimiento, string celular, string calle, string noExterior, string noInterior, string idEstado, string idMunicipio, string idColonia, string cp, int idSexo, string correoElectronico, string idCliente)
        {
            SqlCommand com = new SqlCommand("sp_WEBActualizaDatosEncuesta", conectame);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@FechaNacimiento", SqlDbType.VarChar, 8);
            SqlParameter p2 = new SqlParameter("@TelefonoM", SqlDbType.VarChar, 15);
            SqlParameter p3 = new SqlParameter("@Calle", SqlDbType.VarChar, 100);
            SqlParameter p4 = new SqlParameter("@NumExt", SqlDbType.VarChar, 30);
            SqlParameter p5 = new SqlParameter("@NumInt", SqlDbType.VarChar, 30);
            SqlParameter p6 = new SqlParameter("@IdEstado", SqlDbType.Int);
            SqlParameter p7 = new SqlParameter("@IdMunicipio", SqlDbType.Int);
            SqlParameter p8 = new SqlParameter("@IdColonia", SqlDbType.Int);
            SqlParameter p9 = new SqlParameter("@CP", SqlDbType.VarChar, 5);
            SqlParameter p10 = new SqlParameter("@Sexo", SqlDbType.VarChar, 1);
            SqlParameter p11 = new SqlParameter("@CorreoElectronico", SqlDbType.VarChar, 80);
            SqlParameter p12 = new SqlParameter("@Tarjeta", SqlDbType.VarChar, 19);
            p1.Value = fechaNacimiento;
            p2.Value = celular;
            p3.Value = calle;
            p4.Value = noExterior;
            p5.Value = noInterior;
            p6.Value = idEstado;
            p7.Value = idMunicipio;
            p8.Value = idColonia;
            p9.Value = cp;
            p10.Value = idSexo;
            p11.Value = correoElectronico;
            p12.Value = idCliente;
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            com.Parameters.Add(p5);
            com.Parameters.Add(p6);
            com.Parameters.Add(p7);
            com.Parameters.Add(p8);
            com.Parameters.Add(p9);
            com.Parameters.Add(p10);
            com.Parameters.Add(p11);
            com.Parameters.Add(p12);
            try
            {
                conectame.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conectame.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conectame.Close();
                throw new ApplicationException(ex.Message);
            }
        }

        public DataSet ObtenerMisDatos(string idCliente)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_ObtenerMisDatos", conectame);
                com.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@Tarjeta", SqlDbType.VarChar, 19);
                p1.Value = idCliente;
                com.Parameters.Add(p1);

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
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
                SqlCommand com = new SqlCommand("sp_CargaComboGenero", conectame);
                com.CommandType = CommandType.StoredProcedure;

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

        public int ValidaRegistro1aVez(string tarjeta)
        {
            SqlCommand com = new SqlCommand("sp_ValidaRegistro1aVez", conectame);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@tarjeta", SqlDbType.VarChar, 19);
            p1.Value = tarjeta;
            com.Parameters.Add(p1);

            int noFilas = 0;
            conectame.Open();
            try
            {
                noFilas = Convert.ToInt32(com.ExecuteScalar());
                conectame.Close();
                return noFilas;
            }
            catch (Exception ex)
            {
                conectame.Close();
                throw new ApplicationException(ex.Message);
            }
        }

        public int ValidaRegistro1aVezV2(string tarjeta)
        {
            SqlCommand com = new SqlCommand("sp_ValidaRegistro1aVezV2", conectame);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@tarjeta", SqlDbType.VarChar, 19);
            p1.Value = tarjeta;
            com.Parameters.Add(p1);

            int noFilas = 0;
            conectame.Open();
            try
            {
                noFilas = Convert.ToInt32(com.ExecuteScalar());
                conectame.Close();
                return noFilas;
            }
            catch (Exception ex)
            {
                conectame.Close();
                throw new ApplicationException(ex.Message);
            }
        }

        public DataSet RegistroPrimeraVez(string tarjeta, int tieneHijos, int noHijos, int tienePadecimientoCrónico, string detalle, string usuario)
        {
            SqlCommand com = new SqlCommand("sp_InsertaCuestionarioInicial", conectame);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@strtarjeta", SqlDbType.VarChar, 19);
            SqlParameter p2 = new SqlParameter("@intHijos", SqlDbType.Int);
            SqlParameter p3 = new SqlParameter("@intCuantos", SqlDbType.Int);
            SqlParameter p4 = new SqlParameter("@intCronico", SqlDbType.Int);
            SqlParameter p5 = new SqlParameter("@xmlDetalle", SqlDbType.Xml);
            SqlParameter p6 = new SqlParameter("@usuario", SqlDbType.VarChar, 19);
            p1.Value = tarjeta;
            p2.Value = tieneHijos;
            p3.Value = noHijos;
            p4.Value = tienePadecimientoCrónico;
            p5.Value = detalle;
            p6.Value = usuario;
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            com.Parameters.Add(p5);
            com.Parameters.Add(p6);
            try
            {
                conectame.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conectame.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conectame.Close();
                throw new ApplicationException(ex.Message);
            }
        }

        public DataSet RegistroPrimeraVezV2(string tarjeta, int tieneHijos, int noPersonas, int tienePadecimientoCrónico, string detalle, string usuario)
        {
            SqlCommand com = new SqlCommand("sp_InsertaCuestionarioInicialv2", conectame);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@strtarjeta", SqlDbType.VarChar, 19);
            SqlParameter p2 = new SqlParameter("@intHijos", SqlDbType.Int);
            SqlParameter p3 = new SqlParameter("@intCuantos", SqlDbType.Int);
            SqlParameter p4 = new SqlParameter("@intCronico", SqlDbType.Int);
            SqlParameter p5 = new SqlParameter("@xmlDetalle", SqlDbType.Xml);
            SqlParameter p6 = new SqlParameter("@usuario", SqlDbType.VarChar, 19);
            p1.Value = tarjeta;
            p2.Value = tieneHijos;
            p3.Value = noPersonas;
            p4.Value = tienePadecimientoCrónico;
            p5.Value = detalle;
            p6.Value = usuario;
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            com.Parameters.Add(p5);
            com.Parameters.Add(p6);
            try
            {
                conectame.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conectame.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conectame.Close();
                throw new ApplicationException(ex.Message);
            }
        }
        
        public int EnviarCorreoContacto(string nombre, string tarjeta, string correo, string comentario)
        {
            SqlCommand com = new SqlCommand("sp_EnviarCorreoContacto", conectame);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@nombre", SqlDbType.NVarChar, 200);
            SqlParameter p2 = new SqlParameter("@tarjeta", SqlDbType.NVarChar, 20);
            SqlParameter p3 = new SqlParameter("@correo", SqlDbType.NVarChar, 200);
            SqlParameter p4 = new SqlParameter("@comentario", SqlDbType.NVarChar, 4000);
            p1.Value = nombre;
            p2.Value = tarjeta;
            p3.Value = correo;
            p4.Value = comentario;
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);

            try
            {
                conectame.Open();
                //DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(com);
                int respuesta = Convert.ToInt32(com.ExecuteScalar());
                //da.Fill(ds);
                conectame.Close();
                return respuesta;
            }
            catch (Exception ex)
            {
                conectame.Close();
                throw new ApplicationException(ex.Message);
            }
        }

        public DataSet RecuperaContraseña(string Tipo, string usuario, string tarjeta, string correo)
        {
            SqlCommand com = new SqlCommand("sp_EnviarCorreoContraseña", conectame);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@Tipo", SqlDbType.VarChar, 1);
            SqlParameter p2 = new SqlParameter("@usuario", SqlDbType.VarChar, 20);
            SqlParameter p3 = new SqlParameter("@tarjeta", SqlDbType.VarChar, 20);
            SqlParameter p4 = new SqlParameter("@correo", SqlDbType.VarChar, 200);
            p1.Value = Tipo;
            p2.Value = usuario;
            p3.Value = tarjeta;
            p4.Value = correo;
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            try
            {
                conectame.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conectame.Close();
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
            SqlCommand com = new SqlCommand("sp_CambiarContraseña", conectame);
            com.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@Tarjeta", SqlDbType.VarChar, 20);
            SqlParameter p2 = new SqlParameter("@ContraseñaActual", SqlDbType.VarChar, 20);
            SqlParameter p3 = new SqlParameter("@NuevaContraseña", SqlDbType.VarChar, 20);
            SqlParameter p4 = new SqlParameter("@ConfirmaContraseña", SqlDbType.VarChar, 20);
            p1.Value = tarjeta;
            p2.Value = contraseñaActual;
            p3.Value = nuevaContraseña;
            p4.Value = confirmaContraseña;
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            try
            {
                conectame.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conectame.Close();
                return ds;
            }
            catch (Exception ex)
            {
                conectame.Close();
                throw new ApplicationException(ex.Message);
            }
        }

        public DataTable ObtenerDataTable(string nombreSP)
        {
            try
            {
                SqlCommand com = new SqlCommand(nombreSP, conectame);
                com.CommandType = CommandType.StoredProcedure;

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

       


    }
}
