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
    public class ReportesNeg
    {

        public DataSet DatosReporte(string nombreSP)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                //listParameters.Add(new ParameterIn("FechaIni", DbType.String, FechaIni));
                //listParameters.Add(new ParameterIn("FechaFin", DbType.String, FechaFin));

                DataSet dsReversion = ReportesDatos.ExecuteDataSet(null, nombreSP, (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
                //Exception e = new Exception("Error al Ejecutar el Stored Procedure" + nombreSP + " .", ex);
                //ExceptionManager.HandleException(e, 1, 5000, 6);
                //throw (e);
            }
        }

        public DataSet DatosReporte(string nombreSP, string FechaIni, string FechaFin)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("FechaIni", DbType.String, FechaIni));
                listParameters.Add(new ParameterIn("FechaFin", DbType.String, FechaFin));

                DataSet dsReversion = ReportesDatos.ExecuteDataSet(null, nombreSP, (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
                //Exception e = new Exception("Error al Ejecutar el Stored Procedure" + nombreSP + " .", ex);
                //ExceptionManager.HandleException(e, 1, 5000, 6);
                //throw (e);
            }
        }

        public DataSet DatosReporte(string nombreSP, string tarjeta, string parametro1, string parametro2)
        {
            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("tarjeta", DbType.String, tarjeta));
                listParameters.Add(new ParameterIn("parametro1", DbType.String, parametro1));
                listParameters.Add(new ParameterIn("parametro2", DbType.String, parametro2));

                DataSet dsReversion = ReportesDatos.ExecuteDataSet(null, nombreSP, (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReversion;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
                //Exception e = new Exception("Error al Ejecutar el Stored Procedure" + nombreSP + " .", ex);
                //ExceptionManager.HandleException(e, 1, 5000, 6);
                //throw (e);
            }
        }

        public DataTable CargarDataTable(string nombreSP)
        {
            try
            {
                ReportesDatos datos = new ReportesDatos();
                //EntActualizarCliente ent = new EntActualizarCliente();
                DataTable dt = datos.ObtenerDataTable(nombreSP);
                return dt;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public DataTable CargarDataTable(string nombreSP, int parametro)
        {
            try
            {
                //DatReportes datos = new DatReportes();
                ReportesDatos datos = new ReportesDatos();                
                //EntActualizarCliente ent = new EntActualizarCliente();
                DataTable dt = datos.ObtenerDataTable(nombreSP, parametro);
                return dt;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
               
        public DataTable CargarDataTable(string nombreSP, string var1, string var2)
        {
            try
            {
                ReportesDatos datos = new ReportesDatos();
                //EntActualizarCliente ent = new EntActualizarCliente();
                DataTable dt = datos.ObtenerDataTable(nombreSP, var1, var2);
                return dt;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        

        
    }
}
