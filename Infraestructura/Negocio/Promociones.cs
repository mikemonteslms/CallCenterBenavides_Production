using System;
using System.Data;
using Datos;
using System.Collections;
using System.Configuration;

namespace Negocio
{
    public class Promociones
    {
        public static DataSet ObtenerPromos(int Tipo, string Nombre, string SKU, string Producto, DateTime? fechainicio, DateTime? fechafin)
        {
            ArrayList lstParameters = new ArrayList();
            lstParameters.Add(new ParameterIn("Tipo", DbType.Int32, Tipo));
            if (!string.IsNullOrEmpty(Nombre))
                lstParameters.Add(new ParameterIn("Nombre", DbType.String, Nombre));
            if (!string.IsNullOrEmpty(SKU))
                lstParameters.Add(new ParameterIn("SKU", DbType.String, SKU));
            if (string.IsNullOrEmpty(Producto))
                lstParameters.Add(new ParameterIn("Producto", DbType.String, Producto));
            if (fechainicio > DateTime.MinValue)
                lstParameters.Add(new ParameterIn("FechaI", DbType.DateTime, fechainicio));
            if(fechafin > DateTime.MinValue)
                lstParameters.Add(new ParameterIn("FechaF", DbType.DateTime, fechafin));
            return DataBase.ExecuteDataSet(null, "SP_ObtenerPromocionesCC", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
        }

        public static DataSet ObtenerPromos(int tipoPromocion, int? estatus, int? vencimiento, DateTime? fechaInicio, DateTime? fechaFin, int dias, string descripcion, string producto, string laboratorio)
        {
            ArrayList LstParameters = new ArrayList();
            LstParameters.Add(new ParameterIn("Tipo", DbType.Int32, tipoPromocion));
            if (estatus != null)
                LstParameters.Add(new ParameterIn("Estatus", DbType.Boolean, estatus));
            if (vencimiento != null)
                LstParameters.Add(new ParameterIn("Vencimiento", DbType.Int32, vencimiento));
            if (fechaInicio != null)
                LstParameters.Add(new ParameterIn("FechaI", DbType.DateTime, fechaInicio));
            if (fechaFin != null)
                LstParameters.Add(new ParameterIn("FechaF", DbType.DateTime, fechaFin));
            if (dias > 0)
                LstParameters.Add(new ParameterIn("Dias", DbType.Int16, dias));
            if (!string.IsNullOrEmpty(descripcion))
                LstParameters.Add(new ParameterIn("Descripcion", DbType.String, descripcion));
            if (!string.IsNullOrEmpty(producto))
                LstParameters.Add(new ParameterIn("Producto", DbType.String, producto));
            if (!string.IsNullOrEmpty(laboratorio))
                LstParameters.Add(new ParameterIn("Laboratorio", DbType.Int32, laboratorio));

            return DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionPromos"].ConnectionString, "SP_ConsultaPromocionesCC", (ParameterIn[])LstParameters.ToArray(typeof(ParameterIn)));
        }

        public static DataSet ObtenerPromos(int Tipo, int Segmento, int Estatus, string NumCupon, string SP, DateTime? FechaIni, DateTime? FechaFin,string CodigoInterno)
        {
            try {

                if (NumCupon == "")
                {
                    NumCupon = null;
                }
                if (CodigoInterno == "")
                {
                    CodigoInterno = null;
                }
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@Tipo", DbType.Int32, Tipo));
                lstParameters.Add(new ParameterIn("@Estatus", DbType.Int32, Estatus));
                lstParameters.Add(new ParameterIn("@Segmento", DbType.Int32, Segmento));
                lstParameters.Add(new ParameterIn("@NumCupon", DbType.String, NumCupon));
                lstParameters.Add(new ParameterIn("@FechaIni", DbType.DateTime, FechaIni));
                lstParameters.Add(new ParameterIn("@FechaFin", DbType.DateTime, FechaFin));
                lstParameters.Add(new ParameterIn("@codigoInterno", DbType.String, CodigoInterno));


                return DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionPromos"].ConnectionString, SP, (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        public static DataSet ObtenerPromos(int Tipo, string CodigoIntSKU, string SP)
        {
            try { 
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@Tipo", DbType.Int32, Tipo));
                lstParameters.Add(new ParameterIn("@CodIntSKU", DbType.Int32, CodigoIntSKU));

                return DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionPromos"].ConnectionString, SP, (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet ObtenerPromos(int Tipo, string FecIni, string FecFin, int DiasxVencer, string SP)
        {
            try { 
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@Tipo", DbType.Int32, Tipo));
                lstParameters.Add(new ParameterIn("@FechaIni", DbType.String, FecIni));
                lstParameters.Add(new ParameterIn("@FechaFin", DbType.String, FecFin));
                lstParameters.Add(new ParameterIn("@PorVencerDias", DbType.Int32, DiasxVencer));


                return DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionPromos"].ConnectionString, SP, (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet ObtenerPromos(int TipoMecanica, int Status, string SP)
        {
            try { 
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@TipoMecanica", DbType.Int32, TipoMecanica));
                lstParameters.Add(new ParameterIn("@Status", DbType.Int32, Status));

                return DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionPromos"].ConnectionString, SP, (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet ObtenerPromos(int TipoPromocion,int IdLaboratorio, string NomProveedor, string SP)
        {
            try { 
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@Tipo", DbType.Int32, TipoPromocion));
                lstParameters.Add(new ParameterIn("@IdLaboratorio", DbType.Int32, IdLaboratorio));
                lstParameters.Add(new ParameterIn("@NomProveedor", DbType.String, NomProveedor));

                return DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionPromos"].ConnectionString, SP, (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}