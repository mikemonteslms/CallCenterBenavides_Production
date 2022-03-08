using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Datos;
using Entidades;

namespace Negocio
{
    public class Reportes
    {
        #region ConsultaReportes

        public DataSet ConsultaReportes()
        {
            DataSet dsReportes = null;

            try
            {
                ArrayList listParameters = new ArrayList();

                dsReportes = ReportesDatos.ExecuteDataSet(null, "SP_ConsultaReportes", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReportes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ConsultaReportes.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dsReportes.Dispose();
            }
        }

        #endregion ConsultaReportes

        #region ConsultaReportesParametros

        public DataSet ConsultaReportesParametros(int Reporte)
        {
            DataSet dataset = null;

            try
            {
                ArrayList listParameters = new ArrayList();
                listParameters.Add(new ParameterIn("Reporte", DbType.String, Reporte));

                dataset = ReportesDatos.ExecuteDataSet(null, "SP_ConsultaReportesParametros", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dataset;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure SP_ConsultaReportesParametros.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dataset.Dispose();
            }

        }

        #endregion ConsultaReportesParametros

        #region ConsultarReporte

        public DataSet ConsultarReporte(string nombreReporte, ParameterIn[] arrayParametersIn)
        {
            DataSet dataset = null;

            try
            {
                dataset = ReportesDatos.ExecuteDataSet(null, nombreReporte, arrayParametersIn);

                return dataset;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure " + nombreReporte + ".", ex);
                //ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dataset.Dispose();
            }

        }

        #endregion ConsultarReporte

        #region GeneraReportesFTP

        public void GeneraReportesFTP()
        {
            try
            {
                ArrayList listParameters = new ArrayList();
                listParameters.Add(new ParameterIn("Reportes_intID", DbType.Int64, 9));

                ReportesDatos.ExecuteDataSet(null, "Sp_ReporteTextFile", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure Sp_ReporteTextFile.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
        }

        #endregion GeneraReportesFTP

        #region ReporteActivacionXPeriodo

        public DataSet ReporteActivacionXPeriodo(string pPeriodo)
        {
            DataSet dsReportes = null;

            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@strFechaInicio", DbType.String, pPeriodo));

                dsReportes = ReportesDatos.ExecuteDataSetConnectionString(null, "sp_ReporteActivacionPorSucursal", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReportes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ReporteActivacionPorSucursal.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dsReportes.Dispose();
            }
        }

        #endregion ReporteActivacionXPeriodo

        #region ReporteActivacionXPeriodoTl

        public DataSet ReporteActivacionXPeriodoTl(string pPeriodo)
        {
            DataSet dsReportes = null;

            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@strFechaInicio", DbType.String, pPeriodo));

                dsReportes = ReportesDatos.ExecuteDataSet(null, "sp_ReporteActivacionPorSucursal", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReportes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ReporteActivacionPorSucursal.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dsReportes.Dispose();
            }
        }

        #endregion ReporteActivacionXPeriodoTl

        #region ReporteActivacionXSucursal3Meses

        public DataSet ReporteActivacionXSucursal3Meses(string pSucursal, string pPeriodo)
        {
            DataSet dsReportes = null;

            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@Sucursal_strNombre", DbType.String, pSucursal));
                listParameters.Add(new ParameterIn("@strFechaPeriodo", DbType.String, pPeriodo));

                //dsReportes = ReportesDatos.ExecuteDataSetConnectionString(null, "sp_ReporteActivacionPorSucursal3Meses", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));
                dsReportes = ReportesDatos.ExecuteDataSet(null, "sp_ReporteActivacionPorSucursal3Meses", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReportes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ReporteActivacionPorSucursal3Meses.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dsReportes.Dispose();
            }
        }

        #endregion ReporteActivacionXSucursal3Meses

        #region ReporteActivacionXSucursal3MesesTl

        public DataSet ReporteActivacionXSucursal3MesesTl(string pSucursalId, string pPeriodo)
        {
            DataSet dsReportes = null;

            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@ActivacionPorSucursal_strSucursal", DbType.String, pSucursalId));
                listParameters.Add(new ParameterIn("@strFechaPeriodo", DbType.String, pPeriodo));

                dsReportes = ReportesDatos.ExecuteDataSet(null, "sp_ReporteActivacionPorSucursal3Meses", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReportes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ReporteActivacionPorSucursal3Meses.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dsReportes.Dispose();
            }
        }

        #endregion ReporteActivacionXSucursal3MesesTl
    }
}
