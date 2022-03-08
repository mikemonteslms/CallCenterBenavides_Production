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

        public void GeneraReportesFTP(int IDReporte,string Email)
        {
            try
            {
                ArrayList listParameters = new ArrayList();
                listParameters.Add(new ParameterIn("Reportes_intID", DbType.Int64, IDReporte));
                listParameters.Add(new ParameterIn("CorreoDestino", DbType.String, Email));

                ReportesDatos.ExecuteDataSet("ConectaReportes", "Sp_ReporteTextFile", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

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

                dsReportes = ReportesDatos.ExecuteDataSetConnectionString("ConectaReportes", "sp_ReporteActivacionPorSucursal", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

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

                dsReportes = ReportesDatos.ExecuteDataSet("ConectaReportes", "sp_ReporteActivacionPorSucursal", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

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
                dsReportes = ReportesDatos.ExecuteDataSet("ConectaReportes", "sp_ReporteActivacionPorSucursal3Meses", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

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

                dsReportes = ReportesDatos.ExecuteDataSet("ConectaReportes", "sp_ReporteActivacionPorSucursal3Meses", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

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
        #region ReporteActivacion3MesesTl

        public DataSet ReporteActivacion3MesesTl(string pPeriodo, string pRegion, string pZona, string pSucursalId)
        {
            DataSet dsReportes = null;

            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@strFechaPeriodo", DbType.String, pPeriodo));
                listParameters.Add(new ParameterIn("@ActivacionPorSucursal_strRegionId", DbType.String, pRegion));
                listParameters.Add(new ParameterIn("@ActivacionPorSucursal_strZonaId", DbType.String, pZona));
                listParameters.Add(new ParameterIn("@ActivacionPorSucursal_strSucursal", DbType.String, pSucursalId));

                dsReportes = ReportesDatos.ExecuteDataSet(null, "sp_ReporteActivacion3Meses", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReportes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ReporteActivacion3Meses.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dsReportes.Dispose();
            }
        }

        #endregion ReporteActivacion3MesesTl        


        #region ReporteTicketsxPeriodoTl
        public DataSet ReporteTicketsXPeriodoTl(string pPeriodo)
        {
            DataSet dsReportes = null;

            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@Fecha", DbType.String, pPeriodo));

                dsReportes = ReportesDatos.ExecuteDataSet("ConectaReportes", "sp_ReporteTicketsPorSucursal", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReportes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ReporteTicketsPorSucursal.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dsReportes.Dispose();
            }
        }

        #endregion

        #region ReporteTicketsXSucursal3MesesTl

        public DataSet ReporteTicketsXSucursal3MesesTl(string pSucursalId, string pPeriodo)
        {
            DataSet dsReportes = null;

            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@ActivacionPorSucursal_strSucursal", DbType.String, pSucursalId));
                listParameters.Add(new ParameterIn("@strFechaPeriodo", DbType.String, pPeriodo));

                dsReportes = ReportesDatos.ExecuteDataSet("ConectaReportes", "sp_ReporteTicketsPorSucursal3Meses", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReportes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ReporteTicketsPorSucursal3Meses.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dsReportes.Dispose();
            }
        }

        #endregion ReporteActivacionXSucursal3MesesTl

        #region ReporteTickets3MesesTl

        public DataSet ReporteTickets3MesesTl(string pPeriodo, string pRegion, string pZona, string pSucursalId)
        {
            DataSet dsReportes = null;

            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@strFechaPeriodo", DbType.String, pPeriodo));
                listParameters.Add(new ParameterIn("@TicketsPorSucursal_strRegionId", DbType.String, pRegion));
                listParameters.Add(new ParameterIn("@TicketsPorSucursal_strZonaId", DbType.String, pZona));
                listParameters.Add(new ParameterIn("@TicketsPorSucursal_strSucursal", DbType.String, pSucursalId));

                dsReportes = ReportesDatos.ExecuteDataSet(null, "sp_ReporteTickets3Meses", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReportes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ReporteTickets3Meses.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dsReportes.Dispose();
            }
        }

        #endregion ReporteActivacion3MesesTl        



        #region ReporteImportesxPeriodoTl
        public DataSet ReporteImportesXPeriodoTl(string pPeriodo)
        {
            DataSet dsReportes = null;

            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@Fecha", DbType.String, pPeriodo));

                dsReportes = ReportesDatos.ExecuteDataSet("ConectaReportes", "sp_ReporteImportePorSucursal", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReportes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ReporteImportePorSucursal.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dsReportes.Dispose();
            }
        }

        #endregion

        #region ReporteImportesXSucursal3MesesTl

        public DataSet ReporteImportesXSucursal3MesesTl(string pSucursalId, string pPeriodo)
        {
            DataSet dsReportes = null;

            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@ActivacionPorSucursal_strSucursal", DbType.String, pSucursalId));
                listParameters.Add(new ParameterIn("@strFechaPeriodo", DbType.String, pPeriodo));

                dsReportes = ReportesDatos.ExecuteDataSet("ConectaReportes", "sp_ReporteImportesPorSucursal3Meses", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReportes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ReporteImportesPorSucursal3Meses.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dsReportes.Dispose();
            }
        }

        #endregion 

        #region ReporteImportes3MesesTl

        public DataSet ReporteImportes3MesesTl(string pPeriodo, string pRegion, string pZona, string pSucursalId)
        {
            DataSet dsReportes = null;

            try
            {
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@strFechaPeriodo", DbType.String, pPeriodo));
                listParameters.Add(new ParameterIn("@TicketsPorSucursal_strRegionId", DbType.String, pRegion));
                listParameters.Add(new ParameterIn("@TicketsPorSucursal_strZonaId", DbType.String, pZona));
                listParameters.Add(new ParameterIn("@TicketsPorSucursal_strSucursal", DbType.String, pSucursalId));

                dsReportes = ReportesDatos.ExecuteDataSet(null, "sp_ReporteImporte3Meses", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                return dsReportes;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("Error al Ejecutar el Stored Procedure sp_ReporteImporte3Meses.", ex);
                ExceptionManager.HandleException(e, 1, 5000, 6);
                throw (e);
            }
            finally
            {
                dsReportes.Dispose();
            }
        }

        #endregion        
    }
}
