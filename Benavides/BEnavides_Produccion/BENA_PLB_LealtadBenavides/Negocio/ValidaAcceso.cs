using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Datos;
using System.Collections;

namespace Negocio
{
    public class ValidaAcceso
    {
        public DataSet ValidaUsuario(string tarjeta, string contra)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Tarjeta_strID ", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("Contrasena", DbType.String, contra));

                DataSet dsValida = DataBase.ExecuteDataSet(null, "sp_ValidaPassword", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsValida;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ValidaPassword.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ValidaUsuarioCallCenter(string tarjeta, string contra)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Tarjeta_strID ", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("Contrasena", DbType.String, contra));

                DataSet dsValida = DataBase.ExecuteDataSet(null, "sp_ValidaPasswordCC", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsValida;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ValidaPasswordCC.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        //Método utilizado por el aspx que confirma correo electronico para cambio de Nvel
        public DataSet AgregaUIDValidaCorreo(string tarjeta, string contra)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("UID ", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("HREF", DbType.String, contra));

                DataSet dsValida = DataBase.ExecuteDataSet(null, "sp_RegistraBitacoraCupon", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsValida;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_RegistraBitacoraCupon.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }
        public DataSet ObtenerInformacionTarjeta(string tarjeta)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Tarjeta ", DbType.String, tarjeta));

                DataSet dsValida = DataBase.ExecuteDataSet(null, "sp_BoomerangsTermometro", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsValida;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_BoomerangsTermometro.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }


        //Método utilizado por el aspx que confirma correo electronico para cambio de Nvel
        public DataSet ActivaCuponIDValidaCorreo(string cuponID)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("strCuponID", DbType.String, cuponID));
                
                DataSet dsValida = DataBase.ExecuteDataSet(null, "sp_WEBRegistraCuponValidaCorreo", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsValida;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_WEBRegistraCuponValidaCorreo.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet AgregaUID(string tarjeta, string contra)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("UID ", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("HREF", DbType.String, contra));

                DataSet dsValida = DataBase.ExecuteDataSet(null, "sp_pruebaUID", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsValida;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_pruebaUID.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        public DataSet ActivaCuponID(string cuponID, string celular, string mensaje)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("strCuponID", DbType.String, cuponID));
                listParameters.Add(new ParameterIn("Celular", DbType.String, celular));
                listParameters.Add(new ParameterIn("mensaje", DbType.String, mensaje));

                DataSet dsValida = DataBase.ExecuteDataSet(null, "sp_WEBRegistraCuponAcumulacion", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsValida;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_WEBRegistraCuponAcumulacion.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

    }
}
