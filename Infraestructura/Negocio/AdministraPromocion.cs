using System;
using System.Data;
using Datos;
using System.Linq;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace Negocio
{
    public class AdministraPromocion
    {
        internal ObjectCache cache0;

        public ObjectCache getCache0()
        {
            this.cache0 = MemoryCache.Default;
            return cache0;
        }
        public DataSet ObtenerPromociones(string cnnDBase, string CodigoIntSKU)
        {
            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@codigointerno", DbType.String, CodigoIntSKU));

                return DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_WSListaPromocionesXcodigointerno", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ObtenerPromocionesxEditar(float CodigoIntSKU)
        {
            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@CodIntSKU", DbType.Int32, CodigoIntSKU));

                return DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "SP", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ObtenerPromxAutDesAut(string cnnDbase, string CodigoIntSKU)
        {
            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@codigointerno", DbType.String, CodigoIntSKU));

                return DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, "sp_WSListaPromocionesXcodigointernoAutorizarPase", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ModificaPromociones(string cnnDBase, ModPromociones Datos)
        {
            bool blnCorrecto = false;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@id_mecanica", DbType.Int32, Datos.IdMecanica));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));
                lstParametros.Add(new ParameterIn("@nombrePromocion", DbType.String, Datos.NombrePromocion));
                lstParametros.Add(new ParameterIn("@Id_Periodo", DbType.Int32, Datos.IdPeriodo));
                lstParametros.Add(new ParameterIn("@Limite", DbType.Int32, Datos.Limite));
                lstParametros.Add(new ParameterIn("@fechaFin", DbType.DateTime, Datos.FechaFin));
                lstParametros.Add(new ParameterIn("@flagExtencion", DbType.Boolean, Datos.flagExtencion));
                lstParametros.Add(new ParameterIn("@fechaExtencion", DbType.Boolean, Datos.FechaExtencion));
                lstParametros.Add(new ParameterIn("@comentarios", DbType.String, Datos.Comentarios));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));
                lstParametros.Add(new ParameterIn("@VerEnReporte", DbType.Int32, Datos.VerEnReporte));
                lstParametros.Add(new ParameterIn("@CierreCiclosSugeridos", DbType.Int32, Datos.CierreCiclosSugeridos));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_Promocion_ProduccionAcumulacion_Update", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado > 0)
                {
                    blnCorrecto = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        public bool ModificaFechaInicio(string cnnDBase, ModPromocionesDENoIniciadas Datos)
        {
            bool blnCorrecto = false;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@id_mecanica ", DbType.Int32, Datos.Idmecanica));
                lstParametros.Add(new ParameterIn("@fechaInicio ", DbType.DateTime, Datos.FechaInicio));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_Promocion_ProduccionAcumulacion_NoIniciada_Update_pruebas_fecha", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado < 0)
                {
                    blnCorrecto = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        public bool ModificaListaPromociones(string cnnDBase, ModGuardaDatosGrid Datos)
        {
            bool blnCorrecto = false;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@codigointerno ", DbType.String, Datos.codigointerno));
                lstParametros.Add(new ParameterIn("@id_mecanica ", DbType.Int64, Datos.id_mecanica));
                lstParametros.Add(new ParameterIn("@id_tipoAcumulacion ", DbType.Int32, Datos.id_tipoAcumulacion));
                lstParametros.Add(new ParameterIn("@id_laboratorio ", DbType.Int32, Datos.id_laboratorio));
                lstParametros.Add(new ParameterIn("@comentarios ", DbType.String, Datos.comentarios));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.usuario));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_promociones_asignaLaboratorio", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == -1)
                {
                    blnCorrecto = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        public bool ModificaPromocionesNoIniciadas(string cnnDBase, ModPromocionesNoIniciadas Datos, string SP)
        {
            bool blnCorrecto = true;
            int intRespuesta = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@id_mecanica", DbType.Int32, Datos.IdMecanica));
                lstParametros.Add(new ParameterIn("@id_tipoAcumulacion", DbType.Int32, Datos.IdTipoAcumulacion));
                lstParametros.Add(new ParameterIn("@id_segmento", DbType.Int32, Datos.IdSegmento));
                lstParametros.Add(new ParameterIn("@idTipoPromocion", DbType.Int32, Datos.IdTipoPromocion));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));
                if (SP != "sp_Promocion_ProduccionAcumulacionListas_NoIniciada_Update")
                {
                    lstParametros.Add(new ParameterIn("@codigointernoEntrega", DbType.String, Datos.CodigoInternoEntrega));
                }
                lstParametros.Add(new ParameterIn("@nombrePromocion", DbType.String, Datos.NombrePromocion));
                lstParametros.Add(new ParameterIn("@Id_Periodo", DbType.Int32, Datos.IdPeriodo));
                lstParametros.Add(new ParameterIn("@Limite", DbType.Int32, Datos.Limite));
                lstParametros.Add(new ParameterIn("@fechaInicio", DbType.DateTime, Datos.FechaInicio));
                lstParametros.Add(new ParameterIn("@fechaFin", DbType.DateTime, Datos.FechaFin));
                lstParametros.Add(new ParameterIn("@fechaConteo", DbType.DateTime, Datos.FechaConteo));
                lstParametros.Add(new ParameterIn("@comentarios", DbType.String, Datos.Comentarios));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));
                lstParametros.Add(new ParameterIn("@cantidadCompra", DbType.Int32, Datos.CantidadCompra));
                lstParametros.Add(new ParameterIn("@cantidadEntrega", DbType.Int32, Datos.CantidadEntrega));
                if (SP == "sp_Promocion_ProduccionAcumulacionListas_NoIniciada_Update")
                {
                    lstParametros.Add(new ParameterIn("@lider", DbType.String, Datos.CodigoInterno));
                }
                lstParametros.Add(new ParameterIn("@VerEnReporte", DbType.Int32, Datos.VerEnReporte));

                if (SP == "sp_Promocion_ProduccionAcumulacion_NoIniciada_Update")//Productivo
                {
                    lstParametros.Add(new ParameterIn("@codigoBarras", DbType.Int32, Datos.CodigoBarras));
                }

                lstParametros.Add(new ParameterIn("@flagExtencion", DbType.Int32, Datos.flagExtension));
                lstParametros.Add(new ParameterIn("@fechaExtencion", DbType.DateTime, Datos.FechaExtension));
                lstParametros.Add(new ParameterIn("@CierreCiclosSugeridos", DbType.Int32, Datos.CierreCiclosSugeridos));

                intRespuesta = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, SP, (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intRespuesta <= 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        public bool ModificaPromocionesDEIniciadas(string cnnDBase, ModPromocionesDEIniciadas Datos)
        {
            bool blnCorrecto = false;
            int intRespuesta = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@id_mecanica", DbType.Int32, Datos.Idmecanica));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));
                lstParametros.Add(new ParameterIn("@fechaFin", DbType.DateTime, Datos.FechaFin));
                lstParametros.Add(new ParameterIn("@comentarios", DbType.String, Datos.Comentarios));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));
                lstParametros.Add(new ParameterIn("@VerEnReporte", DbType.Int32, Datos.VerEnReporte));

                intRespuesta = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_Promocion_ProduccionDinero_Update", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intRespuesta > 0)
                {
                    blnCorrecto = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        public bool ModificaPromocionesDENoIniciadas(string cnnDBase, ModPromocionesDENoIniciadas Datos)
        {
            bool blnCorrecto = false;
            int intRespuesta = 0;

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@id_mecanica", DbType.Int32, Datos.Idmecanica));
                lstParametros.Add(new ParameterIn("@id_TipoPromocion", DbType.Int32, Datos.IdTipoPromocion));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));
                lstParametros.Add(new ParameterIn("@cantidad", DbType.Decimal, Datos.Cantidad));
                lstParametros.Add(new ParameterIn("@nombreMecanica", DbType.String, Datos.NombreMecanica));
                lstParametros.Add(new ParameterIn("@fechaInicio", DbType.DateTime, Datos.FechaInicio));
                lstParametros.Add(new ParameterIn("@fechaFin", DbType.DateTime, Datos.FechaFin));
                lstParametros.Add(new ParameterIn("@comentarios", DbType.String, Datos.Comentarios));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));
                lstParametros.Add(new ParameterIn("@VerEnReporte", DbType.Int32, Datos.VerEnReporte));

                intRespuesta = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_Promocion_ProduccionDinero_NoIniciada_Update", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intRespuesta > 0)
                {
                    blnCorrecto = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        public bool GuardarPromociones(string CnnDabse, ModPromocionesNoIniciadas Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();

                lstParametros.Add(new ParameterIn("@id_tipoAcumulacion", DbType.Int32, Datos.IdTipoAcumulacion));
                lstParametros.Add(new ParameterIn("@id_segmento", DbType.Int32, Datos.IdSegmento));
                lstParametros.Add(new ParameterIn("@idTipoPromocion", DbType.Int32, Datos.IdTipoPromocion));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));
                lstParametros.Add(new ParameterIn("@codigointernoEntrega", DbType.String, Datos.CodigoInternoEntrega));
                lstParametros.Add(new ParameterIn("@nombrePromocion", DbType.String, Datos.NombrePromocion));
                lstParametros.Add(new ParameterIn("@Id_Periodo", DbType.Int32, Datos.IdPeriodo));
                lstParametros.Add(new ParameterIn("@Limite", DbType.Int32, Datos.Limite));
                lstParametros.Add(new ParameterIn("@fechaInicio", DbType.DateTime, Datos.FechaInicio));
                lstParametros.Add(new ParameterIn("@fechaFin", DbType.DateTime, Datos.FechaFin));
                lstParametros.Add(new ParameterIn("@fechaConteo", DbType.DateTime, Datos.FechaConteo));
                lstParametros.Add(new ParameterIn("@comentarios", DbType.String, Datos.Comentarios));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));
                lstParametros.Add(new ParameterIn("@cantidadCompra", DbType.Int32, Datos.CantidadCompra));
                lstParametros.Add(new ParameterIn("@cantidadEntrega", DbType.Int32, Datos.CantidadEntrega));
                lstParametros.Add(new ParameterIn("@lider", DbType.String, Datos.Lider));
                lstParametros.Add(new ParameterIn("@VerEnReporte", DbType.Int32, Datos.VerEnReporte));
                lstParametros.Add(new ParameterIn("@flagExtencion", DbType.Int32, Datos.flagExtension));
                lstParametros.Add(new ParameterIn("@fechaExtencion", DbType.DateTime, Datos.FechaExtension));
                lstParametros.Add(new ParameterIn("@CierreCiclosSugeridos", DbType.Int32, Datos.CierreCiclosSugeridos));


                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[CnnDabse].ConnectionString, "sp_Promocion_ProduccionAcumulacion_insert_pruebas", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool GuardarPromocionesDEPorc(string CnnDabse, ModPromocionesDENoIniciadas Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@id_TipoPromocion", DbType.Int32, Datos.IdTipoPromocion));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));
                lstParametros.Add(new ParameterIn("@cantidad", DbType.Decimal, Datos.Cantidad));
                lstParametros.Add(new ParameterIn("@nombreMecanica", DbType.String, Datos.NombreMecanica));
                lstParametros.Add(new ParameterIn("@fechaInicio", DbType.DateTime, Datos.FechaInicio));
                lstParametros.Add(new ParameterIn("@fechaFin", DbType.DateTime, Datos.FechaFin));
                lstParametros.Add(new ParameterIn("@comentarios", DbType.String, Datos.Comentarios));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));
                lstParametros.Add(new ParameterIn("@VerEnReporte", DbType.Int32, Datos.VerEnReporte));


                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[CnnDabse].ConnectionString, "sp_Promocion_ProduccionDinero_insert", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool GuardarnvoLaboratorio(string CnnDabse, ModsetNvasPromLaboratorio Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));
                lstParametros.Add(new ParameterIn("@id_laboratorio", DbType.Int32, Datos.IdLaboratorio));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[CnnDabse].ConnectionString, "sp_actualizaLaboratorio", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool EliminarPromocion(string cnnDBase, float IdMecanica, int TipoAcumulacion, string Usuario)
        {
            bool blnCorrecto = false;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@id_mecanica", DbType.Int32, IdMecanica));
                lstParametros.Add(new ParameterIn("@id_TipoAcumulacion", DbType.Int32, TipoAcumulacion));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Usuario));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_Promocion_Borrar", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado < 0)
                {
                    blnCorrecto = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        public bool EliminarPromocionAmbienteProd(string cnnDBase, float IdMecanica, string CodigoInterno, int TipoAcumulacion, string Usuario)
        {
            bool blnCorrecto = false;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdMecanica", DbType.Int64, IdMecanica));
                lstParametros.Add(new ParameterIn("@TipoAcumulacion", DbType.Int32, TipoAcumulacion));
                lstParametros.Add(new ParameterIn("@CodigoInterno", DbType.String, CodigoInterno));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Usuario));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_Promocion_AmbienteProd_Borrar", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado > 0)
                {
                    blnCorrecto = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        public bool RegistraBitacoraAdminpromocion(string cnnDBase, ModBitacoraAdminPromocion Datos)
        {
            bool blnCorrecto = false;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdMecanica", DbType.Int32, Datos.IdMecanica));
                lstParametros.Add(new ParameterIn("@Usuario", DbType.String, Datos.Usuario));
                lstParametros.Add(new ParameterIn("@FechaHora", DbType.DateTime, Datos.FechaHora));
                lstParametros.Add(new ParameterIn("@Descripcion", DbType.String, Datos.Descripcion));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "SPI_BitacoraAdminPromociones", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado > 0)
                {
                    blnCorrecto = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        public bool AutorizaPromocion(string cnnDBase, ModAutorizarPromociones Datos)
        {
            bool blnCorrecto = false;
            int Respuesta = 0;
            string strFechaPaseProd = "";

            strFechaPaseProd = Datos.FechaPaseProduccion.Year.ToString() + Datos.FechaPaseProduccion.Month.ToString("00") + Datos.FechaPaseProduccion.Day.ToString("00") + " 00:00:00";


            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@id_mecanica", DbType.String, Datos.IdMecanica.ToString()));
                lstParametros.Add(new ParameterIn("@id_tipoAcumulacion", DbType.Int32, Datos.IdTipoAcumulacion));
                lstParametros.Add(new ParameterIn("@id_statusPaseProduccion", DbType.Int32, Datos.IdStatusPaseProduccion));
                lstParametros.Add(new ParameterIn("@fechaPaseProduccion", DbType.DateTime, strFechaPaseProd));

                Respuesta = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_PromocionesAcumulaDineroAutorizarPase_Update", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (Respuesta > 0)
                {
                    blnCorrecto = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        public ModEquivalencias ObtenEquivalencia(string cnnDBase, int IdMecanica)
        {
            ModEquivalencias respuesta = new ModEquivalencias();
            DataSet DS = new DataSet();
            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@id_mecanicaProduccion", DbType.Int32, IdMecanica));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_ConsultaEquivalencias", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            respuesta.IdMecanica = Convert.ToInt32(DS.Tables[0].Rows[0][1]);
                            respuesta.IdTipoAcumulacion = Convert.ToInt32(DS.Tables[0].Rows[0][0]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return respuesta;
        }
        public List<ModSegmento> ObtenSegmentos(string cnnDBase)
        {
            ArrayList lstParameters = new ArrayList();
            List<ModSegmento> lstResultados = new List<ModSegmento>();
            try
            {
                DataSet DS = new DataSet();
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_catalogo_Segmentos", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModSegmento campos = new ModSegmento();

                    campos.IdSegmento = Convert.ToInt32(itm[0]);
                    campos.Segmento = itm[1].ToString();

                    lstResultados.Add(campos);
                }


            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return lstResultados;
        }
        public List<ModLimitePeriodo> ObtenLimitePeriodo(string cnnDBase)
        {
            ArrayList lstParameters = new ArrayList();
            List<ModLimitePeriodo> lstResultados = new List<ModLimitePeriodo>();
            try
            {
                DataSet DS = new DataSet();
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "usp_PeriodoObtener", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModLimitePeriodo campos = new ModLimitePeriodo();

                    campos.IdPeriodo = Convert.ToInt32(itm[0]);
                    campos.Periodo = itm[1].ToString();

                    lstResultados.Add(campos);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultados;
        }
        public List<ModTipoPromocion> ObtenTipoPromocion(string cnnDBase, int TipoAcumulacion)
        {
            ArrayList lstParameters = new ArrayList();
            List<ModTipoPromocion> lstResultados = new List<ModTipoPromocion>();
            try
            {
                DataSet DS = new DataSet();
                lstParameters.Add(new ParameterIn("@id_tipoAcumulacion", DbType.UInt32, TipoAcumulacion));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_CatalogoPromocionTipoAcumulacion", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModTipoPromocion campos = new ModTipoPromocion();

                    campos.Id = Convert.ToInt32(itm[0]);
                    campos.TipoPromocion = itm[1].ToString();

                    lstResultados.Add(campos);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultados;
        }
        public List<ModLaboratorio> ObtenLaboratorios(string cnnDBase)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            List<ModLaboratorio> Resultado = new List<ModLaboratorio>();
            try
            {
                lstParameters.Add(new ParameterIn("@Laboratorio", DbType.String, ""));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_CatalogoLaboratorios", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");
                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModLaboratorio campos = new ModLaboratorio();

                    campos.IdLaboratorio = Convert.ToInt32(itm[0]);
                    campos.Laboratorio = itm[1].ToString();

                    Resultado.Add(campos);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Resultado;
        }
        public List<ModLaboratorio> ReloadLaboratorios(string cnnDBase, string strlaboratorio)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            List<ModLaboratorio> lstResultados = new List<ModLaboratorio>();
            List<ModLaboratorio> Resultado = new List<ModLaboratorio>();
            try
            {
                lstParameters.Add(new ParameterIn("@Laboratorio", DbType.String, strlaboratorio));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_CatalogoLaboratorios", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");
                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModLaboratorio campos = new ModLaboratorio();

                    campos.IdLaboratorio = Convert.ToInt32(itm[0]);
                    campos.Laboratorio = itm[1].ToString();

                    Resultado.Add(campos);
                    lstResultados = Resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultados;
        }
        public List<ModCategorias> ObtenCategorias(string cnnDBase)
        {
            ArrayList lstParameters = new ArrayList();
            List<ModCategorias> lstResultados = new List<ModCategorias>();
            List<ModCategorias> Resultado = new List<ModCategorias>();
            try
            {
                ObjectCache cache;
                cache = getCache0();
                DataSet DS = new DataSet();
                cache = MemoryCache.Default;
                //Lista que se guardara en cache a fin de no realizar n peticiones de conexion
                //hacia el server de SQL
                lstResultados = cache["ListaCategorias"] as List<ModCategorias>;

                if (lstResultados == null)
                {   //Si no existe es la primera vez, realiza la petición a la dbase carga el listado 
                    //y lo almacena en memoria cache
                    CacheItemPolicy policy = new CacheItemPolicy();
                    DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "SP_Categorias", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                    foreach (DataRow itm in DS.Tables[0].Rows)
                    {
                        ModCategorias campos = new ModCategorias();

                        campos.IdCategoria = itm[0].ToString();
                        campos.Categoria = itm[1].ToString();

                        Resultado.Add(campos);
                    }
                    //Guarda en memoria cahce resultado
                    cache.Set("ListaCategorias", Resultado, policy);
                    lstResultados = Resultado;
                }
                else
                {   //Si ya existe en memoria devolvera el listado existente de laboratorios
                    cache = getCache0();
                    cache = MemoryCache.Default;
                    lstResultados = cache["ListaCategorias"] as List<ModCategorias>;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultados;
        }
        public ModContenedorMecanicas CargaDetalleMecanica(string cnnDbase, int IdMecanica, int TipoAcumulacion)
        {
            ArrayList lstParameters = new ArrayList();
            ModContenedorMecanicas Estructuras = new ModContenedorMecanicas();
            List<ModMecanica> lstResultados = new List<ModMecanica>();
            List<ModLaboratorio> lstLaboratorios = new List<ModLaboratorio>();
            DataTable DTComentarios = new DataTable();

            try
            {
                lstLaboratorios = ObtenLaboratorios(cnnDbase);

                DataSet DS = new DataSet();

                lstParameters.Add(new ParameterIn("@id_mecanica", DbType.UInt32, IdMecanica));
                lstParameters.Add(new ParameterIn("@id_TipoAcumulacion", DbType.UInt32, TipoAcumulacion));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, "sp_Promocion_detalle", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            if (TipoAcumulacion == 1)
                            {
                                foreach (DataRow itm in DS.Tables[0].Rows)
                                {
                                    ModMecanica campos = new ModMecanica();

                                    campos.IdSegmento = Convert.ToInt32(itm[1]);
                                    campos.CodigoInterno = itm[2].ToString();
                                    campos.NomProducto = itm[3].ToString();
                                    if (itm.ItemArray.Length > 23)
                                    {
                                        campos.NombreMecanica = itm[23].ToString();
                                    }


                                    campos.Categoria = itm[4].ToString();
                                    campos.Idlaboratorio = Convert.ToInt32(itm[5]);

                                    //Provisional
                                    foreach (ModLaboratorio itmlab in lstLaboratorios)
                                    {
                                        if (itmlab.IdLaboratorio == campos.Idlaboratorio)
                                        {
                                            campos.Laboratorio = itmlab.Laboratorio;
                                        }
                                    }
                                    campos.Promocion = itm[6].ToString();
                                    campos.EstatusInicio = itm[7].ToString();
                                    campos.Tipoacumulacion = Convert.ToInt32(itm[8]);
                                    campos.IdtipoPromocion = Convert.ToInt32(itm[9]);
                                    campos.CantidadCompra = Convert.ToInt32(itm[10]);
                                    campos.CantidadEntrega = Convert.ToInt32(itm[11]);
                                    if (!string.IsNullOrWhiteSpace(itm[12].ToString()))
                                    {
                                        campos.FechaIni = (DateTime)itm[12];
                                    }

                                    if (!string.IsNullOrWhiteSpace(itm[13].ToString()))
                                    {
                                        campos.FechaFin = (DateTime)itm[13];
                                    }
                                    if (!string.IsNullOrWhiteSpace(itm[14].ToString()))
                                    {
                                        campos.FechaConteo = (DateTime)itm[14];
                                    }
                                    if (itm[19].ToString() == "2")
                                    {
                                        campos.EstatusPaseProd = Convert.ToInt32(itm[19]);
                                        campos.FechaPaseProduccion = itm[20].ToString();
                                    }
                                    campos.IdPreiodoLimite = Convert.ToInt32(itm[15]);
                                    campos.Limite = Convert.ToInt64(itm[16]);

                                    campos.falgFechaExt = Convert.ToInt32(itm[17]);
                                    if (campos.falgFechaExt == 1)
                                    {
                                        if (!string.IsNullOrWhiteSpace(itm[18].ToString()))
                                        {
                                            campos.FechaExtencion = (DateTime)itm[18];
                                        }
                                    }

                                    campos.CodigoBarras = itm["CodigoBarras"].ToString();
                                    campos.CodigoInternoEntrega = itm[21].ToString();
                                    campos.VerenReporte = Convert.ToBoolean(itm[22]);
                                    if (itm[23] != null)
                                    {
                                        if (!string.IsNullOrWhiteSpace(itm[23].ToString()))
                                        {
                                            campos.CierreCiclosSugeridos = Convert.ToInt32(itm[23]);
                                        }
                                    }


                                    lstResultados.Add(campos);
                                }
                            }
                            else if (TipoAcumulacion == 2)
                            {
                                foreach (DataRow itm in DS.Tables[0].Rows)
                                {
                                    ModMecanica campos = new ModMecanica();

                                    campos.CodigoInterno = itm[1].ToString();
                                    campos.NomProducto = itm[2].ToString();
                                    campos.IdtipoPromocion = Convert.ToInt32(itm[3]);
                                    campos.Promocion = itm[4].ToString();
                                    campos.CantidadCompra = Convert.ToInt32(itm[5]);
                                    campos.EstatusInicio = itm[6].ToString();
                                    campos.Tipoacumulacion = Convert.ToInt32(itm[7]);
                                    if (!string.IsNullOrWhiteSpace(itm[9].ToString()))
                                    {
                                        campos.FechaIni = (DateTime)itm[9];
                                    }
                                    if (!string.IsNullOrWhiteSpace(itm[10].ToString()))
                                    {
                                        campos.FechaFin = (DateTime)itm[10];
                                    }
                                    campos.VerenReporte = Convert.ToBoolean(itm[15]);

                                    lstResultados.Add(campos);
                                }
                            }
                        }
                        if (DS.Tables[1].Rows.Count > 0) //Comentarios
                        {
                            DTComentarios = DS.Tables[1];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Estructuras.DTComentarios = DTComentarios;
            Estructuras.lstMecanica = lstResultados;

            return Estructuras;
        }
        public ModContenedorMecanicas CargaDetalleMecanicaDEPorc(string cnnDBase, int IdMecanica, int TipoAcumulacion)
        {
            ModContenedorMecanicas Estructura = new ModContenedorMecanicas();
            ArrayList lstParameters = new ArrayList();
            List<ModMecanicaDEPorc> lstResultados = new List<ModMecanicaDEPorc>();
            DataTable DTComentarios = new DataTable();
            try
            {
                DataSet DS = new DataSet();

                lstParameters.Add(new ParameterIn("@id_mecanica", DbType.UInt32, IdMecanica));
                lstParameters.Add(new ParameterIn("@id_TipoAcumulacion", DbType.UInt32, TipoAcumulacion));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_Promocion_detalle", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");


                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itm in DS.Tables[0].Rows)
                            {
                                ModMecanicaDEPorc campos = new ModMecanicaDEPorc();

                                campos.CodigoInterno = itm[1].ToString();
                                campos.Producto = itm[2].ToString();
                                campos.idTipoPromocion = Convert.ToInt32(itm[3]);
                                campos.Promocion = itm[4].ToString();
                                campos.Cantidad = float.Parse(itm[5].ToString());
                                campos.EstatusInicio = itm[6].ToString();
                                campos.Tipoacumulacion = Convert.ToInt32(itm[7]);
                                campos.TipoPromocion = itm[8].ToString();

                                if (!string.IsNullOrWhiteSpace(itm[9].ToString()))
                                {
                                    campos.FechaIni = (DateTime)itm[9];
                                }
                                if (!string.IsNullOrWhiteSpace(itm[10].ToString()))
                                {
                                    campos.FechaFin = (DateTime)itm[10];
                                }
                                if (!string.IsNullOrWhiteSpace(itm[13].ToString()))
                                {
                                    if (itm[13].ToString() == "2")
                                    {
                                        campos.EstatusPaseProd = Convert.ToInt32(itm[13]);
                                        campos.FechaPaseProd = itm[14].ToString();
                                    }
                                }

                                if (itm.ItemArray.Length == 16)
                                {
                                    if (!string.IsNullOrWhiteSpace(itm[15].ToString()))
                                    {
                                        campos.VerEnReporte = Convert.ToBoolean(itm[15]);
                                    }
                                    else
                                    {
                                        campos.VerEnReporte = false;
                                    }
                                }
                                else if (itm.ItemArray.Length == 17)
                                {
                                    if (itm[16] != null)
                                    {
                                        campos.VerEnReporte = Convert.ToBoolean(itm[16]);
                                    }
                                    else
                                    {
                                        campos.VerEnReporte = false;
                                    }
                                }

                                lstResultados.Add(campos);
                            }
                        }
                        if (DS.Tables[1].Rows.Count > 0)
                        {
                            DTComentarios = DS.Tables[1];
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            Estructura.DTComentarios = DTComentarios;
            Estructura.lstMecanicaDEPorc = lstResultados;

            return Estructura;
        }
        public ModDatosGrid ValidaExistenciaCodInterno(string AmbienteCnnDbase, string CodInterno)
        {
            string cnn = "";
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            ModDatosGrid campos = null;

            try
            {
                lstParameters.Add(new ParameterIn("@codigointerno", DbType.String, CodInterno));
                cnn = ConfigurationManager.ConnectionStrings[AmbienteCnnDbase].ToString();

                DS = DataBase.ExecuteDataSet(cnn, "sp_Promocion_DatosPruduto", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            campos = new ModDatosGrid();
                            campos.codigointerno = DS.Tables[0].Rows[0][0].ToString();
                            campos.nombreProducto = DS.Tables[0].Rows[0][1].ToString();
                            campos.Categoria_strID = DS.Tables[0].Rows[0][2].ToString();
                            campos.id_laboratorio = DS.Tables[0].Rows[0][3].ToString();
                            campos.CodigoBarras = DS.Tables[0].Rows[0][4].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return campos;
        }
        public int ValidaPromocion(string AmbienteCnnDbase, ModValidaPromocion Datos)
        {
            string cnn = "";
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            int intRespuesta = 0;

            try
            {
                lstParameters.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));
                lstParameters.Add(new ParameterIn("@fechainicio", DbType.DateTime, Datos.FechaInicio));
                lstParameters.Add(new ParameterIn("@fechaFin", DbType.DateTime, Datos.FechaFin));
                lstParameters.Add(new ParameterIn("@id_tipoacumulacion", DbType.Int32, Datos.IdTipoacumulacion));
                cnn = ConfigurationManager.ConnectionStrings[AmbienteCnnDbase].ToString();

                DS = DataBase.ExecuteDataSet(cnn, "sp_ValidaMecanicaXCodigointerno", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            //1 ==> puede continuar, 0 no puede continuar
                            intRespuesta = Convert.ToInt32(DS.Tables[0].Rows[0][0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intRespuesta;
        }

        public List<ModLaboratorio> RegistraNvoLaboratorio(string NomLaboratorio, string NomLabValida)
        {
            DataSet DS = new DataSet();
            List<ModLaboratorio> lstLaboratorios = new List<ModLaboratorio>();

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@NombreLaboratorio", DbType.String, NomLaboratorio));
                lstParametros.Add(new ParameterIn("@NombreLaboratorioValida", DbType.String, NomLabValida));

                DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionStringProd"].ConnectionString, "spI_Laboratorios", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionStringTest"].ConnectionString, "spI_Laboratorios", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables.Count == 2)
                        {//Cuando encontro resultados similares a laboratorio a dar de alta.
                            if (DS.Tables[1].Rows.Count > 0)
                            {
                                foreach (DataRow campos in DS.Tables[1].Rows)
                                {
                                    ModLaboratorio reg = new ModLaboratorio();
                                    reg.IdLaboratorio = Convert.ToInt32(campos[1]);
                                    reg.Laboratorio = campos[2].ToString();
                                    reg.mensaje = DS.Tables[0].Rows[0][1].ToString();

                                    lstLaboratorios.Add(reg);
                                }
                            }
                        }
                        else
                        {
                            if (DS.Tables[0].Rows.Count > 0)
                            {//Devuelve resultado de la alta de Laboratorio
                                ModLaboratorio reg = new ModLaboratorio();
                                reg.mensaje = DS.Tables[0].Rows[0][1].ToString();

                                lstLaboratorios.Add(reg);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return lstLaboratorios;
        }
        public string RegistraNvoLaboratorioForzar(string NomLaboratorio)
        {
            string strRespuesta = "";
            DataSet DS = new DataSet();

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@NombreLaboratorio", DbType.String, NomLaboratorio));

                DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionStringProd"].ConnectionString, "spI_LaboratoriosForzar", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionStringTest"].ConnectionString, "spI_LaboratoriosForzar", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strRespuesta = DS.Tables[0].Rows[0][1].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strRespuesta;
        }
        public string EliminarLaboratorio(int IdLaboratorio)
        {
            string strResultado = "";
            DataSet DS = new DataSet();

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdLaboratorio", DbType.Int32, IdLaboratorio));

                DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionStringProd"].ConnectionString, "spD_EliminaLaboratorio", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionStringTest"].ConnectionString, "spD_EliminaLaboratorio", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strResultado = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strResultado;
        }
        public string ModificarLaboratorio(int IdLaboratorio, string Laboratorio)
        {
            string strRespuesta = "";
            DataSet DS = new DataSet();

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdLaboratorio", DbType.Int32, IdLaboratorio));
                lstParametros.Add(new ParameterIn("@NombreLaboratorio", DbType.String, Laboratorio));

                DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionStringProd"].ConnectionString, "spU_ActualizaLaboratorio", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionStringTest"].ConnectionString, "spU_ActualizaLaboratorio", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strRespuesta = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strRespuesta;
        }
        public string RegistraNvoSegmento(string NomSegmento)
        {
            string strRespuesta = "";
            DataSet DS = new DataSet();

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Segmento", DbType.String, NomSegmento));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_AltaSegmentos", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strRespuesta = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strRespuesta;
        }
        public string EliminarSegmento(int IdSegmento)
        {
            string strResultado = "";
            //int intRespuesta = 0;
            DataSet DS = new DataSet();

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdSegmento", DbType.Int32, IdSegmento));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spD_EliminaSegmentos", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strResultado = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strResultado;
        }
        public string ModificarSegmento(int IdSegmento, string Segmento)
        {
            string strRespuesta = "";
            DataSet DS = new DataSet();

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdSegemento", DbType.Int32, IdSegmento));
                lstParametros.Add(new ParameterIn("@Segmento", DbType.String, Segmento));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_ActualizaSegmentos", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strRespuesta = DS.Tables[0].Rows[0][0].ToString();
                            ReloadLaboratorios("ConnectionString", "");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strRespuesta;
        }
        public string RegistraNvoTPromo(string NomPromo, int IdTAcumulacion)
        {
            string strRespuesta = "";
            DataSet DS = new DataSet();

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@id_tipoAcumulacion", DbType.Int32, IdTAcumulacion));
                lstParametros.Add(new ParameterIn("@tipoPromocion", DbType.String, NomPromo));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_AltaTipoPromocion", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strRespuesta = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strRespuesta;
        }
        public string EliminarTPromo(int IdTPromo)
        {
            string strResultado = "";
            //int intRespuesta = 0;
            DataSet DS = new DataSet();

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdTipoPromo", DbType.Int32, IdTPromo));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spD_EliminaTipoPromocion", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strResultado = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strResultado;
        }
        public string EliminarPeriodo(int IdPeriodo)
        {
            string strResultado = "";
            DataSet DS = new DataSet();

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdPeriodo", DbType.Int32, IdPeriodo));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spD_ElimiPeriodo", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strResultado = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strResultado;
        }
        public string ModificarTPromo(int IdtPromo, string Tpromo)
        {
            string strRespuesta = "";
            DataSet DS = new DataSet();

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdtipoPromocion", DbType.Int32, IdtPromo));
                lstParametros.Add(new ParameterIn("@TipoPromocion", DbType.String, Tpromo));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_ActualizaTPromocion", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strRespuesta = DS.Tables[0].Rows[0][0].ToString();
                            ReloadLaboratorios("ConnectionString", "");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strRespuesta;
        }
        public List<ModProductos> ObtenProductos(string Nombreproducto)
        {
            ArrayList lstParameters = new ArrayList();
            List<ModProductos> lstResultados = new List<ModProductos>();
            try
            {
                DataSet DS = new DataSet();
                lstParameters.Add(new ParameterIn("@NombreProducto", DbType.String, Nombreproducto));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_Productos", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModProductos campos = new ModProductos();

                    campos.Id = Convert.ToInt32(itm[0]);
                    campos.Producto = itm[1].ToString();
                    campos.IdCategoria = Convert.ToInt32(itm[2]);
                    campos.Laboratorio = itm[3].ToString();

                    lstResultados.Add(campos);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultados;
        }
        public List<ModLaboratorio> ObtenLaboratoriosPopup(string cnnDBase)
        {
            ArrayList lstParameters = new ArrayList();
            List<ModLaboratorio> lstResultados = new List<ModLaboratorio>();
            try
            {
                DataSet DS = new DataSet();
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_ListaLaboratoriosxCategoria", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");
                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModLaboratorio campos = new ModLaboratorio();

                    campos.IdCategoria = Convert.ToInt32(itm[0]);
                    campos.Laboratorio = itm[1].ToString();

                    lstResultados.Add(campos);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultados;
        }
        public string GuardaAsigancionLaboratorio(int IdCategoria, string IdProducto)
        {
            string strRespuesta = "";
            DataSet DS = new DataSet();
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdProducto", DbType.String, IdProducto));
                lstParametros.Add(new ParameterIn("@IdCategoria", DbType.Int32, IdCategoria));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_ReaisgnaLaboratorioProducto", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strRespuesta = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strRespuesta;
        }
        public string GuardaNvoPeriodo(string Periodo, int Dias)
        {
            string strRespuesta = "";
            DataSet DS = new DataSet();
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Perdiodo", DbType.String, Periodo));
                lstParametros.Add(new ParameterIn("@Dias", DbType.Int32, Dias));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spIAltaPeriodos", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strRespuesta = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strRespuesta;
        }
        public string GuardaEditPeriodo(string Periodo, int IdPeriodo)
        {
            string strRespuesta = "";
            DataSet DS = new DataSet();
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Periodo", DbType.String, Periodo));
                lstParametros.Add(new ParameterIn("@IDPeriodo", DbType.Int32, IdPeriodo));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_ActualizaPeriodos", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strRespuesta = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strRespuesta;
        }
        public int ObtenerEquivalenciamecanica(int Idmecnica)
        {
            int RespuestaIdMecanica = 0;

            ArrayList lstParameters = new ArrayList();
            List<ModProductos> lstResultados = new List<ModProductos>();
            try
            {
                DataSet DS = new DataSet();
                lstParameters.Add(new ParameterIn("@IdMecanicaProd", DbType.Int32, Idmecnica));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionStringProd"].ConnectionString, "sp_ObtenerEquivalenciaMecanica", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            RespuestaIdMecanica = Convert.ToInt32(DS.Tables[0].Rows[0][0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RespuestaIdMecanica;
        }
        public string EliminarPromocionesPreviasxCodigoInterno(string cnnDbase, string codInterno)
        {
            string strResultado = "";
            DataSet DS = new DataSet();

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdCodigoInterno", DbType.String, codInterno));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, "sp_EliminaPromocionesPreviasxCodigoInterno", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strResultado = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strResultado;
        }
        public Int32 ValidarLaboratoriosCargaMasivaPromociones(string CnnDabse, string Laboratorio)
        {
            //bool blnCorrecto = true;
            int intValor = 0;
            DataSet DS;
            try
            {
                ArrayList lstParametros = new ArrayList();

                lstParametros.Add(new ParameterIn("@Laboratorio", DbType.String, Laboratorio.Trim()));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[CnnDabse].ConnectionString, "sp_validaLaboratoriosCargaMasivaPromociones", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            intValor = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return intValor;
        }
        public string ValidarCodigoInterno(string Ambiente, Int32 IdMecanica, string CodigoInterno, DateTime FechaIni, DateTime FechaFin)
        {
            string strError = "";
            ArrayList lstParameters = new ArrayList();
            List<ModPromoMecanicas> lstResultado = new List<ModPromoMecanicas>();
            try
            {
                DataSet DSProd = new DataSet();
                DataSet DSPruebas = new DataSet();

                lstParameters.Add(new ParameterIn("@CodigoInterno", DbType.String, CodigoInterno));

                DSProd = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionStringProd"].ConnectionString, "sp_ObtenerMecanicasVigentes", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                DSPruebas = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionStringTest"].ConnectionString, "sp_ObtenerMecanicasVigentes", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));


                if (Ambiente == "Pruebas")
                {
                    if (DSPruebas != null)
                    {
                        if (DSPruebas.Tables.Count > 0)
                        {
                            foreach (DataRow itm in DSPruebas.Tables[0].Rows)
                            {
                                if (IdMecanica != Convert.ToInt32(itm["id_mecanica"]))
                                {
                                    if (IdMecanica > Convert.ToInt32(itm["id_mecanica"]))
                                    {
                                        if (!(FechaIni > Convert.ToDateTime(itm["FechaFin"])))
                                        {
                                            strError = "Imposible continuar,  porque la vigencia  proporcionada se sobre pone con alguna mecánica en ambiente pruebas.";
                                        }
                                    }
                                    else
                                    {
                                        if (IdMecanica < Convert.ToInt32(itm["id_mecanica"]))
                                        {
                                            if (!(FechaFin < Convert.ToDateTime(itm["FechaIni"])))
                                            {
                                                strError = "Imposible continuar,  porque la vigencia  proporcionada se sobre pone con alguna mecánica en ambiente pruebas.";
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                    if (DSProd != null)
                    {
                        if (DSProd.Tables.Count > 0)
                        {
                            foreach (DataRow itm in DSProd.Tables[0].Rows)
                            {
                                if (FechaIni < Convert.ToDateTime(itm["FechaFin"]))
                                {
                                    strError = "Imposible continuar,  porque la vigencia  proporcionada se sobre pone con alguna mecánica en ambiente productivo.";
                                }
                            }
                        }
                    }
                }


                if (Ambiente == "Productivo")
                {
                    if (DSProd != null)
                    {
                        if (DSProd.Tables.Count > 0)
                        {
                            foreach (DataRow itm in DSProd.Tables[0].Rows)
                            {
                                if (IdMecanica != Convert.ToInt32(itm["id_mecanica"]))
                                {
                                    if (IdMecanica < Convert.ToInt32(itm["id_mecanica"])) //Aqui se evalua que la mecánica evaluada es menor
                                    {
                                        if (!(FechaFin < Convert.ToDateTime(itm["Fechaini"])))
                                        {
                                            strError = "Imposible continuar,  porque la vigencia  proporcionada se sobre pone con alguna mecánica en ambiente productivo.";
                                        }
                                    }
                                    else
                                    {
                                        if (!(FechaFin > Convert.ToDateTime(itm["FechaIni"])))
                                        {
                                            strError = "Imposible continuar,  porque la vigencia  proporcionada se sobre pone con alguna mecánica en ambiente productivo.";
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (DSPruebas != null)
                    {
                        if (DSPruebas.Tables.Count > 0)
                        {
                            foreach (DataRow itm in DSPruebas.Tables[0].Rows)
                            {
                                //if (IdMecanica < Convert.ToInt32(itm["id_mecanica"])  ) //Aqui se evalua que la mecánica evaluada es menor
                                //{
                                if (!(FechaFin < Convert.ToDateTime(itm["FechaIni"])))
                                {
                                    strError = "Imposible continuar,  porque la vigencia  proporcionada se sobre pone con alguna mecánica en ambiente pruebas.";
                                }
                                //}
                                //else  //Aqui se evalua que la mecánica evaluada es mayor
                                //{
                                //    if (!(FechaFin > Convert.ToDateTime(itm["FechaIni"])))
                                //    {
                                //        strError = "Imposible continuar,  porque la vigencia  proporcionada se sobre pone con alguna mecánica en ambiente productivo.";
                                //    }
                                //}
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strError;
        }


        #region "Promociones de doble acumulación"
        public List<ModPromoDobleAcumulacion> ObtenPromoDobleAcumulacionVigentes(string cnnDbase)
        {
            ArrayList lstParameters = new ArrayList();
            List<ModPromoDobleAcumulacion> lstResultados = new List<ModPromoDobleAcumulacion>();
            try
            {
                DataSet DS = new DataSet();
                //lstParameters.Add(new ParameterIn("@NombreProducto", DbType.String, Nombreproducto));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, "sp_ObtenPromosDobleAcumulacionVigentes", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModPromoDobleAcumulacion campos = new ModPromoDobleAcumulacion();

                    campos.Id = Convert.ToInt32(itm[0]);
                    campos.Nombre = itm[1].ToString();
                    //campos.Sucursal = itm[2].ToString();
                    campos.FechaIni = (DateTime)itm[2];
                    campos.FechaFin = (DateTime)itm[3];
                    campos.flgDescuento = (Int32)itm[4];
                    campos.EnabledDescuento = (Int32)itm[5];
                    campos.EnabledAcumulacion = (Int32)itm[6];

                    lstResultados.Add(campos);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultados;
        }
        public List<ModPromoDobleAcumulacion> ObtenPromoDobleAcumulacionSuc(string cnnDbase, Int32 IdPromo, List<ModSucursales> lstAlmacenIdSuc)
        {
            ArrayList lstParameters = new ArrayList();
            List<ModPromoDobleAcumulacion> lstResultados = new List<ModPromoDobleAcumulacion>();
            try
            {
                DataSet DS = new DataSet();
                DataSet DS2 = new DataSet();
                lstParameters.Add(new ParameterIn("@IdPromo", DbType.Int32, IdPromo));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, "sp_ObtenPromosDobleAcumulacionXSucursal", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));


                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModPromoDobleAcumulacion campos = new ModPromoDobleAcumulacion();

                    campos.IdPromo = Convert.ToInt32(itm[0]);
                    campos.Nombre = itm[1].ToString();
                    campos.Sucursal = itm[2].ToString();

                    int IdSucursal = 0;
                    IdSucursal = Convert.ToInt32(campos.Sucursal.Substring(0, campos.Sucursal.IndexOf("-") - 1));
                    if (campos.Sucursal.IndexOf("Todas") == -1)
                    {
                        campos.CveSucursal = lstAlmacenIdSuc.Where(w => w.IdSucursal == IdSucursal).Select(s => s.CveSucursal).FirstOrDefault().ToString();


                        campos.FechaIni = (DateTime)itm[3];
                        campos.FechaFin = (DateTime)itm[4];
                        if (!string.IsNullOrWhiteSpace(itm[6].ToString()))
                        {
                            campos.FechaFinDesctxt = itm[6].ToString();
                            campos.FechaFinDesc = (DateTime)itm[6];
                            campos.Porcentaje = Convert.ToInt32(itm[7]);
                        }
                        else
                        {
                            campos.FechaFinDesctxt = "No asignada";
                            campos.Porcentaje = 0;
                        }
                        campos.Id = Convert.ToInt32(itm[5]);
                        campos.Cantidad = Convert.ToInt32(itm["Cantidad"]);
                        campos.Cupon = itm["Cupon"].ToString();

                        if (itm["soloActivacion"].ToString() == "True")
                        {
                            campos.SoloActivaciones = 1;
                        }
                        else
                        {
                            campos.SoloActivaciones = 0;
                        }


                        lstResultados.Add(campos);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultados;
        }

        public List<ModSucursales> ObtenSucursales(string cnnDBase)
        {
            ArrayList lstParameters = new ArrayList();
            List<ModSucursales> lstResultados = new List<ModSucursales>();
            try
            {
                DataSet DS = new DataSet();
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_ObtenSucursales", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModSucursales campos = new ModSucursales();

                    campos.IdSucursal = Convert.ToInt32(itm[0]);
                    campos.Sucursal = itm[1].ToString();
                    campos.CveSucursal = itm[2].ToString();

                    lstResultados.Add(campos);
                }


            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return lstResultados;
        }
        public List<ModCupones> ObtenCupones(int TipoModulo)
        {
            ArrayList lstParameters = new ArrayList();
            List<ModCupones> lstResultados = new List<ModCupones>();
            try
            {
                DataSet DS = new DataSet();
                lstParameters.Add(new ParameterIn("@TipoModulo", DbType.Int32, TipoModulo));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ListaCupones", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModCupones campos = new ModCupones();

                    campos.IdCupon = Convert.ToInt32(itm["Id"]);
                    campos.Cupones = itm["Cupon"].ToString() + " - " + itm["NomCupon"].ToString();

                    lstResultados.Add(campos);
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return lstResultados;
        }
        public ModCupones ObtenCuponPromoDAC(int IdPromoCat)
        {
            ArrayList lstParameters = new ArrayList();
            ModCupones campos = new ModCupones();
            try
            {
                DataSet DS = new DataSet();
                lstParameters.Add(new ParameterIn("@IdPromoXcategoria", DbType.Int32, IdPromoCat));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenCuponPromoDAC", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            campos.IdCupon = Convert.ToInt32(DS.Tables[0].Rows[0]["id_cupon"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return campos;
        }
        public int GuardarPromoDobleAcumulacionHeader(string CnnDabse, ModPromoDobleAcumulacion Datos)
        {
            int IdPromo = 0;
            string FechaInicio = "";
            string FechaFin = "";
            DataSet DS = new DataSet();

            try
            {
                ArrayList lstParametros = new ArrayList();


                FechaInicio = Datos.FechaIni.Year.ToString() + Datos.FechaIni.Month.ToString("00") + Datos.FechaIni.Day.ToString("00") + " 00:00:00";
                FechaFin = Datos.FechaFin.Year.ToString() + Datos.FechaFin.Month.ToString("00") + Datos.FechaFin.Day.ToString("00") + " 23:59:59";

                lstParametros.Add(new ParameterIn("@Cantidad", DbType.Int32, Datos.Cantidad));
                lstParametros.Add(new ParameterIn("@Descripcion", DbType.Int32, Datos.Nombre));
                lstParametros.Add(new ParameterIn("@FechaIni", DbType.DateTime, FechaInicio));
                lstParametros.Add(new ParameterIn("@FechaFin", DbType.DateTime, FechaFin));
                lstParametros.Add(new ParameterIn("@SoloActivaciones", DbType.Int32, Datos.SoloActivaciones));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[CnnDabse].ConnectionString, "spI_RegistraPromoDobleAcumulacionEncabezado", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            IdPromo = Convert.ToInt32(DS.Tables[0].Rows[0][0]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return IdPromo;
        }
        public bool ModificarPromoDobleAcumulacionHeader(string CnnDabse, ModPromoDobleAcumulacion Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            string FechaInicio = "";
            string FechaFin = "";

            try
            {
                ArrayList lstParametros = new ArrayList();


                FechaInicio = Datos.FechaIni.Year.ToString() + Datos.FechaIni.Month.ToString("00") + Datos.FechaIni.Day.ToString("00") + " 00:00:00";
                FechaFin = Datos.FechaFin.Year.ToString() + Datos.FechaFin.Month.ToString("00") + Datos.FechaFin.Day.ToString("00") + " 23:59:59";

                lstParametros.Add(new ParameterIn("@IdPromo", DbType.Int32, Datos.IdPromo));
                lstParametros.Add(new ParameterIn("@Cantidad", DbType.Int32, Datos.Cantidad));
                lstParametros.Add(new ParameterIn("@Descripcion", DbType.Int32, Datos.Nombre));
                lstParametros.Add(new ParameterIn("@FechaIni", DbType.DateTime, FechaInicio));
                lstParametros.Add(new ParameterIn("@FechaFin", DbType.DateTime, FechaFin));
                lstParametros.Add(new ParameterIn("@Estatus", DbType.Int32, Datos.Estatus));
                lstParametros.Add(new ParameterIn("@SoloActivaciones", DbType.Int32, Datos.SoloActivaciones));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[CnnDabse].ConnectionString, "spU_ModificarPromoDobleAcumulacionEncabezado", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool ModificarPromoDobleAcumulacionSuc(string CnnDabse, ModPromoDobleAcumulacion Datos, bool SeEliminoReg, bool chkCupon, bool chkdescINAPAM)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            string FechaInicio = "";
            string FechaFin = "";
            string FechaFinDesc = "";

            try
            {
                ArrayList lstParametros = new ArrayList();

                FechaInicio = Datos.FechaIni.Year.ToString() + Datos.FechaIni.Month.ToString("00") + Datos.FechaIni.Day.ToString("00") + " 00:00:00";

                if (chkCupon && SeEliminoReg)
                {
                    FechaFin = Datos.FechaFin.Year.ToString() + Datos.FechaFin.Month.ToString("00") + Datos.FechaFin.Day.ToString("00") + " " + Datos.FechaFin.Hour.ToString("00") + ":" + Datos.FechaFin.Minute.ToString("00") + ":" + Datos.FechaFin.Second.ToString("00");
                }
                else if (chkCupon && !SeEliminoReg && Datos.FechaIni.ToShortDateString() != Datos.FechaFin.ToShortDateString())
                {
                    FechaFin = Datos.FechaFin.Year.ToString() + Datos.FechaFin.Month.ToString("00") + Datos.FechaFin.Day.ToString("00") + " 23:59:59";
                }

                if (chkdescINAPAM && SeEliminoReg)
                {
                    FechaFin = FechaInicio;
                    FechaFinDesc = Datos.FechaFinDesc.Year.ToString() + Datos.FechaFinDesc.Month.ToString("00") + Datos.FechaFinDesc.Day.ToString("00") + " " + Datos.FechaFinDesc.Hour.ToString("00") + ":" + Datos.FechaFinDesc.Minute.ToString("00") + ":" + Datos.FechaFinDesc.Second.ToString("00");
                }
                else if (chkdescINAPAM && !SeEliminoReg)
                {
                    FechaFin = FechaInicio;
                    FechaFinDesc = Datos.FechaFinDesc.Year.ToString() + Datos.FechaFinDesc.Month.ToString("00") + Datos.FechaFinDesc.Day.ToString("00") + " 23:59:59";
                }


                lstParametros.Add(new ParameterIn("@Id", DbType.Int32, Datos.Id));
                lstParametros.Add(new ParameterIn("@ID_promoXCategoria", DbType.Int32, Datos.IdPromo));
                lstParametros.Add(new ParameterIn("@FechaIni", DbType.DateTime, FechaInicio));
                lstParametros.Add(new ParameterIn("@FechaFin", DbType.DateTime, FechaFin));
                lstParametros.Add(new ParameterIn("@FechaFinDescuento", DbType.DateTime, FechaFinDesc));
                lstParametros.Add(new ParameterIn("@Sucursal", DbType.String, Datos.Sucursal));
                lstParametros.Add(new ParameterIn("@Porcentaje", DbType.String, Datos.Porcentaje));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[CnnDabse].ConnectionString, "spU_ModificarPromoDobleAcumulacionSucursal", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool ModificarPromoDobleAcumulacionSucFechaFin(string CnnDabse, ModPromoDobleAcumulacion Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Id", DbType.Int32, Datos.Id));
                lstParametros.Add(new ParameterIn("@UsuarioModifico", DbType.String, Datos.UsuarioModifica));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[CnnDabse].ConnectionString, "spU_FinalizarPromoDobleAcumulacionSucursal", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool ModificarPromoDescuento(string CnnDabse, ModPromoDobleAcumulacion Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Id", DbType.Int32, Datos.Id));
                lstParametros.Add(new ParameterIn("@Sucursal", DbType.String, Datos.Sucursal));
                lstParametros.Add(new ParameterIn("@UsuarioModifico", DbType.String, Datos.UsuarioModifica));


                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[CnnDabse].ConnectionString, "spU_FinalizarDescuentoINAPAM", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool RegistrarLog(string CnnDabse, int Id, int IdPromo, string NomPromo, DateTime FIniPromo, DateTime FFinPromo, DateTime FIniPromoSuc, DateTime FFinPromoSuc, DateTime FFinDesc, int Descuento, string Sucursal, int Estatus, string Usuario, string TipoMov)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            string FechaInicioP = "";
            string FechaFinP = "";
            string FechaInicioPS = "";
            string FechaFinPS = "";
            string FechaFinDesc = "";

            try
            {
                ArrayList lstParametros = new ArrayList();


                FechaInicioP = FIniPromo.Year.ToString() + FIniPromo.Month.ToString("00") + FIniPromo.Day.ToString("00") + " 00:00:00";
                FechaFinP = FFinPromo.Year.ToString() + FFinPromo.Month.ToString("00") + FFinPromo.Day.ToString("00") + " 23:59:59";

                FechaInicioPS = FIniPromoSuc.Year.ToString() + FIniPromoSuc.Month.ToString("00") + FIniPromoSuc.Day.ToString("00") + " 00:00:00";

                if (FFinPromoSuc.ToString() != "01/01/0001 11:59:59 p. m.")
                {
                    if (FFinPromoSuc.ToShortDateString() != FIniPromoSuc.ToShortDateString())
                    {
                        FechaFinPS = FFinPromoSuc.Year.ToString() + FFinPromoSuc.Month.ToString("00") + FFinPromoSuc.Day.ToString("00") + " 23:59:59";
                    }
                    else
                    {
                        FechaFinPS = FechaInicioPS;
                    }
                }
                else
                {
                    FechaFinPS = FechaInicioPS;
                }


                if (FFinDesc.ToString() != "01/01/0001 12:00:00 a. m.")
                {
                    FechaFinDesc = FFinDesc.Year.ToString() + FFinDesc.Month.ToString("00") + FFinDesc.Day.ToString("00") + " 23:59:59";
                }
                else
                {
                    FechaFinDesc = "";
                }



                lstParametros.Add(new ParameterIn("@ID", DbType.Int32, Id));
                lstParametros.Add(new ParameterIn("@ID_promoXCategoria", DbType.Int32, IdPromo));
                lstParametros.Add(new ParameterIn("@NombrePromo", DbType.String, NomPromo));
                lstParametros.Add(new ParameterIn("@FechaIniPromo", DbType.DateTime, FechaInicioP));
                lstParametros.Add(new ParameterIn("@FechaFinPromo", DbType.DateTime, FechaFinP));
                lstParametros.Add(new ParameterIn("@FechaIniPromoSuc", DbType.DateTime, FechaInicioPS));
                lstParametros.Add(new ParameterIn("@FechaFinPromoSuc", DbType.DateTime, FechaFinPS));
                lstParametros.Add(new ParameterIn("@FechaFinDescuento", DbType.DateTime, FechaFinDesc));
                lstParametros.Add(new ParameterIn("@Descuento", DbType.Int32, Descuento));
                lstParametros.Add(new ParameterIn("@Sucursal", DbType.String, Sucursal));
                lstParametros.Add(new ParameterIn("@UsuarioModifico", DbType.String, Usuario));
                lstParametros.Add(new ParameterIn("@IdEstatus", DbType.Int32, Estatus));
                lstParametros.Add(new ParameterIn("@TipoMov", DbType.String, TipoMov));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[CnnDabse].ConnectionString, "spI_RegistraLogPromoDobleAcumulacion", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool GuardarPromoDobleAcumulacionDetalle(string CnnDabse, ModPromoDobleAcumulacion Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            string FechaInicio = "";
            string FechaFin = "";
            string FechaFinDesc = "";

            try
            {
                ArrayList lstParametros = new ArrayList();

                FechaInicio = Datos.FechaIni.Year.ToString() + Datos.FechaIni.Month.ToString("00") + Datos.FechaIni.Day.ToString("00") + " 00:00:00";
                FechaFinDesc = Datos.FechaFinDesc.Year.ToString() + Datos.FechaFinDesc.Month.ToString("00") + Datos.FechaFinDesc.Day.ToString("00") + " 23:59:59";

                if (Datos.FechaFin.ToString() != "01/01/0001 11:59:59 p. m.")
                {
                    if (Datos.FechaIni != Datos.FechaFin)
                    {
                        FechaFin = Datos.FechaFin.Year.ToString() + Datos.FechaFin.Month.ToString("00") + Datos.FechaFin.Day.ToString("00") + " 23:59:59";
                    }
                    else
                    {
                        FechaFin = FechaInicio;
                    }
                }
                else
                {
                    FechaFin = FechaFinDesc;
                }




                lstParametros.Add(new ParameterIn("@ID_promoXCategoria", DbType.Int32, Datos.IdPromo));
                lstParametros.Add(new ParameterIn("@Descripcion", DbType.Int32, Datos.Nombre));
                lstParametros.Add(new ParameterIn("@FechaIni", DbType.DateTime, FechaInicio));
                lstParametros.Add(new ParameterIn("@FechaFin", DbType.DateTime, FechaFin));
                lstParametros.Add(new ParameterIn("@FechaFinDescuento", DbType.DateTime, FechaFinDesc));
                lstParametros.Add(new ParameterIn("@Sucursal", DbType.String, Datos.Sucursal));
                lstParametros.Add(new ParameterIn("@Porcentaje", DbType.Int32, Datos.Porcentaje));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[CnnDabse].ConnectionString, "spI_RegistraPromoDobleAcumulacionSuc", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool GuardarPromoCupon(ModPromoCupon Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;

            try
            {
                ArrayList lstParametros = new ArrayList();

                lstParametros.Add(new ParameterIn("@IdPromoXcategoria", DbType.Int32, Datos.IdPromoCategoria));
                lstParametros.Add(new ParameterIn("@IdCupon", DbType.Int32, Datos.IdCupon));
                lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_RegistraPromoCupon", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool ModificarPromoCupon(ModPromoCupon Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;

            try
            {
                ArrayList lstParametros = new ArrayList();

                lstParametros.Add(new ParameterIn("@IdPromoXcategoria", DbType.Int32, Datos.IdPromoCategoria));
                lstParametros.Add(new ParameterIn("@IdCupon", DbType.Int32, Datos.IdCupon));
                lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_ModificaPromoCupon", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public Int32 ValidarExistenciaPromociones(string cnnDbase, Int32 IdPromo, string Cupon, string Sucursal, string Fechainicio, string FechaFin)
        {
            string SP = "";
            DateTime FIni;
            DateTime FFin;
            int intRespuesta = 0;
            ArrayList lstParameters = new ArrayList();
            try
            {
                FIni = Convert.ToDateTime(Fechainicio);
                FFin = Convert.ToDateTime(FechaFin);

                Fechainicio = FIni.Year.ToString() + FIni.Month.ToString("00") + FIni.Day.ToString("00") + " 00:00:00";
                FechaFin = FFin.Year.ToString() + FFin.Month.ToString("00") + FFin.Day.ToString("00") + " 23:59:59";

                DataSet DS = new DataSet();
                SP = "sp_ValidaExistPromocionesDobleAcumXSucSinCupon";
                lstParameters.Add(new ParameterIn("@IdPromo", DbType.Int32, IdPromo));
                if (!string.IsNullOrWhiteSpace(Cupon))
                {//Si el valor de cupon contiene información valida utiliza diferente Sored procedure
                    SP = "sp_ValidaExistPromocionesDobleAcumXSuc";
                    lstParameters.Add(new ParameterIn("@Cupon", DbType.String, Cupon));
                }
                lstParameters.Add(new ParameterIn("@Sucursal", DbType.String, Sucursal));
                lstParameters.Add(new ParameterIn("@FechaIni", DbType.DateTime, Fechainicio));
                lstParameters.Add(new ParameterIn("@FechaFin", DbType.DateTime, FechaFin));


                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, SP, (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    intRespuesta = Convert.ToInt32(itm[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intRespuesta;
        }
        public int ValidaExistenciaSucursalPromo(string cnnDbase, string Sucursal, string Fechainicio, string FechaFin, string FechaFinDesc, int TipoPromo, int IdCupon)
        {
            DateTime FIni;
            DateTime FFin;
            DateTime FFinDesc;
            int intRespuesta = 0;
            ArrayList lstParameters = new ArrayList();
            try
            {
                FIni = Convert.ToDateTime(Fechainicio);
                FFin = Convert.ToDateTime(FechaFin);
                FFinDesc = Convert.ToDateTime(FechaFinDesc);

                Fechainicio = FIni.Year.ToString() + FIni.Month.ToString("00") + FIni.Day.ToString("00") + " 00:00:00";
                if (FIni.ToShortDateString() != FFin.ToShortDateString())
                {
                    FechaFin = FFin.Year.ToString() + FFin.Month.ToString("00") + FFin.Day.ToString("00") + " 23:59:59";
                }
                else
                {
                    FechaFin = Fechainicio;
                }

                FechaFinDesc = FFinDesc.Year.ToString() + FFinDesc.Month.ToString("00") + FFinDesc.Day.ToString("00") + " 23:59:59";

                DataSet DS = new DataSet();
                lstParameters.Add(new ParameterIn("@Sucursal", DbType.String, Sucursal));
                lstParameters.Add(new ParameterIn("@FechaInicio", DbType.DateTime, Fechainicio));
                lstParameters.Add(new ParameterIn("@FechaFin", DbType.DateTime, FechaFin));
                lstParameters.Add(new ParameterIn("@FechaFinDescuento", DbType.DateTime, FechaFinDesc));
                lstParameters.Add(new ParameterIn("@TipoPromo", DbType.Int32, TipoPromo));
                lstParameters.Add(new ParameterIn("@Cupon", DbType.Int32, IdCupon));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, "sp_ValidaExistenciaPromociones", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    intRespuesta = Convert.ToInt32(itm[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intRespuesta;
        }
        public bool EliminarPromocionDobleAcumulacion(string cnnDbase, int IdPromo)
        {
            bool blnCorrecto = false;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Id", DbType.Int32, IdPromo));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, "spD_EliminarPromoDobleAcumulacion", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado > 0)
                {
                    blnCorrecto = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        #endregion

        #region PromocionesACBase
        public int GuardarPromocionesACBase(ModPromocionesACBase Datos)
        {
            bool blnRespuesta = false;
            DataSet DS = new DataSet();
            int intResultado = 0;
            string strFechaIni = Datos.FechaInicio.Year.ToString() + Datos.FechaInicio.Month.ToString("00") + Datos.FechaInicio.Day.ToString("00") + " 00:00:00";
            string strFechaFin = Datos.FechaFin.Year.ToString() + Datos.FechaFin.Month.ToString("00") + Datos.FechaFin.Day.ToString("00") + " 23:59:59";

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@NombrePromocion", DbType.String, Datos.NombrePromocion));
                lstParametros.Add(new ParameterIn("@Cantidad", DbType.Int32, Datos.Cantidad));
                lstParametros.Add(new ParameterIn("@FechaInicio", DbType.String, strFechaIni));
                lstParametros.Add(new ParameterIn("@FechaFin", DbType.String, strFechaFin));
                lstParametros.Add(new ParameterIn("@ServicioDomicilio", DbType.Int32, Datos.ServicioDomicilio));
                lstParametros.Add(new ParameterIn("@SurtirConsultorio", DbType.Int32, Datos.SurtirConsultorio));


                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_GuardarPromocionACBase", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            intResultado = Convert.ToInt32(DS.Tables[0].Rows[0][0]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return intResultado;
        }

        public bool GuardarDiasPromoACBase(List<ModDiasPromoACBAse> lstDias)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {
                foreach (ModDiasPromoACBAse Datos in lstDias)
                {
                    ArrayList lstParametros = new ArrayList();
                    lstParametros.Add(new ParameterIn("@Id_PABase", DbType.Int32, Datos.IdPABase));
                    lstParametros.Add(new ParameterIn("@Dia", DbType.Int32, Datos.Dia));
                    lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                    intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_DiasPromocionesACBase", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                }

                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blnRespuesta;
        }

        public bool GuardarProductosPromoACBase(ModProductosPromoACBase Datos)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {

                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Id_PABase", DbType.Int32, Datos.IdPABase));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.Int32, Datos.CodigoInterno));
                lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_ProductosPromocionesACBase", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));


                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blnRespuesta;
        }

        public bool GuardarSucursalesPromoACBase(ModSucursalesPromoACBase Datos)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {

                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Id_PABase", DbType.Int32, Datos.IdPABase));
                lstParametros.Add(new ParameterIn("@Sucursal", DbType.Int32, Datos.Sucursal));
                lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_SucursalesPromocionesACBase", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));


                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blnRespuesta;
        }

        public bool ModificarPromoACBase(ModPromocionesACBase Datos)
        {
            bool blnRespuesta = false;
            DataSet DS = new DataSet();
            int intResultado = 0;
            string strFechaIni = Datos.FechaInicio.Year.ToString() + Datos.FechaInicio.Month.ToString("00") + Datos.FechaInicio.Day.ToString("00") + " 00:00:00";
            string strFechaFin = Datos.FechaFin.Year.ToString() + Datos.FechaFin.Month.ToString("00") + Datos.FechaFin.Day.ToString("00") + " 23:59:59";

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdPABase", DbType.Int32, Datos.IdPABase));
                lstParametros.Add(new ParameterIn("@NombrePromocion", DbType.String, Datos.NombrePromocion));
                lstParametros.Add(new ParameterIn("@Cantidad", DbType.Int32, Datos.Cantidad));
                lstParametros.Add(new ParameterIn("@FechaInicio", DbType.String, strFechaIni));
                lstParametros.Add(new ParameterIn("@FechaFin", DbType.String, strFechaFin));
                lstParametros.Add(new ParameterIn("@ServicioDomicilio", DbType.Int32, Datos.ServicioDomicilio));
                lstParametros.Add(new ParameterIn("@SurtirConsultorio", DbType.Int32, Datos.SurtirConsultorio));


                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_ModificarPromocionACBase", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));

                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnRespuesta;
        }
        public bool ModificarDiasPromoACBase(List<ModDiasPromoACBAse> lstDias)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {
                foreach (ModDiasPromoACBAse Datos in lstDias)
                {
                    ArrayList lstParametros = new ArrayList();
                    lstParametros.Add(new ParameterIn("@IdPABase", DbType.Int32, Datos.IdPABase));
                    lstParametros.Add(new ParameterIn("@Dia", DbType.Int32, Datos.Dia));
                    lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                    intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_DiasPromocionesACBase", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                }

                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blnRespuesta;
        }
        public bool ModificarProductosPromoACBase(ModProductosPromoACBase Datos)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {

                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Id_PABase", DbType.Int32, Datos.IdPABase));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.Int32, Datos.CodigoInterno));
                lstParametros.Add(new ParameterIn("@codigointernoNvo", DbType.Int32, Datos.CodigoInternoNvo));
                lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_ProductosPromocionesACBase", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));


                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blnRespuesta;
        }

        public bool ModificarSucursalesPromoACBase(ModSucursalesPromoACBase Datos)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {

                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Id_PABase", DbType.Int32, Datos.IdPABase));
                lstParametros.Add(new ParameterIn("@Sucursal", DbType.Int32, Datos.Sucursal));
                lstParametros.Add(new ParameterIn("@SucursalNva", DbType.Int32, Datos.SucursalNva));
                lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_SucursalesPromocionesACBase", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));


                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blnRespuesta;
        }
        public bool ValidaPromocionACBase(ModPromoACBaseValidaciones Datos)
        {
            bool blnRespuesta = false;
            DataSet DS = new DataSet();
            int intResultado = 0;
            string strFechaIni = Datos.FechaIni.Year.ToString() + Datos.FechaIni.Month.ToString("00") + Datos.FechaIni.Day.ToString("00") + " 00:00:00";
            string strFechaFin = Datos.FechaFin.Year.ToString() + Datos.FechaFin.Month.ToString("00") + Datos.FechaFin.Day.ToString("00") + " 23:59:59";

            ArrayList lstParametros = new ArrayList();
            lstParametros.Add(new ParameterIn("@CodigoInterno", DbType.Int32, Datos.CodigoInterno));
            lstParametros.Add(new ParameterIn("@Sucursal", DbType.String, Datos.Sucursal));
            lstParametros.Add(new ParameterIn("@FechaIni", DbType.DateTime, strFechaIni));
            lstParametros.Add(new ParameterIn("@FechaFin", DbType.DateTime, strFechaFin));

            DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ValidaExistenciaPromocionesACBase", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));

            if (DS != null)
            {
                if (DS.Tables.Count > 0)
                {
                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        intResultado = Convert.ToInt32(DS.Tables[0].Rows[0]["Existen"].ToString());
                        if (intResultado > 0)
                        {
                            //Indica que ya existe alguna promoción en dbase
                            blnRespuesta = true;
                        }
                    }
                }
            }

            return blnRespuesta;
        }
        public bool ValidaExistenciaCodInternoACBase(string CodInterno)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            bool blnRespuesta = false;

            try
            {
                lstParameters.Add(new ParameterIn("@codigointerno", DbType.String, CodInterno));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_Promocion_DatosPruduto", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            //Indica que es valido el código interno
                            blnRespuesta = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnRespuesta;
        }
        public int RegresaIdSucursal(string Sucursal)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            int intRespuesta = 0;

            try
            {
                lstParameters.Add(new ParameterIn("@Sucursal", DbType.String, Sucursal.Trim()));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenEquivalenciaSucursalesACBase", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            //Devuelve Equivalencia 
                            intRespuesta = Convert.ToInt32(DS.Tables[0].Rows[0]["Sucursal_intCiaSuc"]);
                        }
                        else
                        {
                            //Devuelve un valor inexistente de sucursal
                            intRespuesta = 99999;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intRespuesta;
        }
        public bool ValidaExistenciaSucursalACBase(int Sucursal)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            bool blnRespuesta = false;

            try
            {
                lstParameters.Add(new ParameterIn("@Sucursal", DbType.Int32, Sucursal));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ValidaExistenciaSucursalesACBase", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToInt32(DS.Tables[0].Rows[0]["Existe"]) == 1)
                            {
                                //Indica que es valida la sucursal
                                blnRespuesta = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnRespuesta;
        }
        public List<ModPromocionesACBase> ObtenPromoACBase(string NomPromo)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            List<ModPromocionesACBase> lstPromoACBase = new List<ModPromocionesACBase>();
            int intRespuesta = 0;

            try
            {
                lstParameters.Add(new ParameterIn("@Nombre", DbType.String, NomPromo.Trim()));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenPromocionesACBase", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModPromocionesACBase campos = new ModPromocionesACBase();

                                campos.IdPABase = Convert.ToInt32(reg[0]);
                                campos.NombrePromocion = reg[1].ToString();
                                campos.Cantidad = Convert.ToInt32(reg[2]);
                                campos.FechaInicio = Convert.ToDateTime(reg[3]);
                                campos.FechaFin = Convert.ToDateTime(reg[4]);
                                campos.ServicioDomicilio = Convert.ToInt32(reg[5]);
                                campos.SurtirConsultorio = Convert.ToInt32(reg[6]);

                                lstPromoACBase.Add(campos);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPromoACBase;
        }
        public List<ModDiasPromoACBAse> ObtenDiasACBase(int IdPABase)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            List<ModDiasPromoACBAse> lstDiasACBase = new List<ModDiasPromoACBAse>();
            int intRespuesta = 0;

            try
            {
                lstParameters.Add(new ParameterIn("@IdPABase", DbType.Int32, IdPABase));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenerDiasACBase", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModDiasPromoACBAse campos = new ModDiasPromoACBAse();

                                campos.IdPABase = Convert.ToInt32(reg[1]);
                                campos.Dia = Convert.ToInt32(reg[2]);
                                campos.IdStatus = Convert.ToInt32(reg[3]);

                                lstDiasACBase.Add(campos);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDiasACBase;
        }
        public List<ModProductosPromoACBase> ObtenProductosACBase(int IdPABase)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            List<ModProductosPromoACBase> lstProdACBase = new List<ModProductosPromoACBase>();

            try
            {
                lstParameters.Add(new ParameterIn("@IdPABase", DbType.Int32, IdPABase));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_obtenerProductosACBAse", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModProductosPromoACBase campos = new ModProductosPromoACBase();

                                campos.IdPABase = Convert.ToInt32(reg[1]);
                                campos.CodigoInterno = reg[2].ToString();
                                campos.CodigoInternoAnt = reg[2].ToString();
                                campos.IdStatus = Convert.ToInt32(reg[3]);

                                lstProdACBase.Add(campos);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProdACBase;
        }
        public List<ModSucursalesPromoACBase> ObtenSucursalACBase(int IdPABase)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            List<ModSucursalesPromoACBase> lstSucACBase = new List<ModSucursalesPromoACBase>();

            try
            {
                lstParameters.Add(new ParameterIn("@IdPABase", DbType.Int32, IdPABase));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_obtenerSucursalesACBAse", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModSucursalesPromoACBase campos = new ModSucursalesPromoACBase();

                                campos.IdPABase = Convert.ToInt32(reg[1]);
                                campos.Sucursal = Convert.ToInt32(reg[2]);
                                campos.SucursalAnt = Convert.ToInt32(reg[2]);
                                campos.IdStatus = Convert.ToInt32(reg[3]);
                                campos.NomSucursal = reg[4].ToString();

                                lstSucACBase.Add(campos);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstSucACBase;
        }
        #endregion

        #region PromocionesAcumulaDineroEntregaPiezas
        public DataSet ObtenerPromACDineroEntregaPzas(string cnnDbase, string CodigoIntSKU)
        {
            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@codigointerno", DbType.String, CodigoIntSKU));

                return DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, "sp_ObtenListaPromocionesACDineroEntregaPzas", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ObtenerPromcumulaDineroxAutDesAut(string cnnDbase, string CodigoIntSKU)
        {
            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@codigointerno", DbType.String, CodigoIntSKU));

                return DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, "sp_ObtenListaPromocionesACDineroEntregaPzas", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ModContenedorMecanicas CargaDetalleMecanicaACDinero(string cnnDbase, int IdMecanica, int TipoAcumulacion)
        {
            ArrayList lstParameters = new ArrayList();
            ModContenedorMecanicas Estructuras = new ModContenedorMecanicas();
            List<ModMecanica> lstResultados = new List<ModMecanica>();
            List<ModMecanica> lstBeneficios = new List<ModMecanica>();
            List<ModLaboratorio> lstLaboratorios = new List<ModLaboratorio>();
            DataTable DTComentarios = new DataTable();

            try
            {
                lstLaboratorios = ObtenLaboratorios(cnnDbase);

                DataSet DS = new DataSet();

                lstParameters.Add(new ParameterIn("@id_mecanica", DbType.UInt32, IdMecanica));
                lstParameters.Add(new ParameterIn("@id_TipoAcumulacion", DbType.UInt32, TipoAcumulacion));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, "sp_PromocionACDinero_detalle", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            if (TipoAcumulacion == 3)
                            {
                                foreach (DataRow itm in DS.Tables[0].Rows)
                                {
                                    ModMecanica campos = new ModMecanica();

                                    campos.IdSegmento = Convert.ToInt32(itm[1]);
                                    campos.CodigoInterno = itm[2].ToString();
                                    campos.NomProducto = itm[3].ToString();
                                    campos.NombreMecanica = itm[6].ToString();


                                    campos.Categoria = itm[4].ToString();
                                    campos.Idlaboratorio = Convert.ToInt32(itm[5]);

                                    //Provisional
                                    foreach (ModLaboratorio itmlab in lstLaboratorios)
                                    {
                                        if (itmlab.IdLaboratorio == campos.Idlaboratorio)
                                        {
                                            campos.Laboratorio = itmlab.Laboratorio;
                                        }
                                    }
                                    campos.Promocion = itm[6].ToString();
                                    campos.EstatusInicio = itm[7].ToString();
                                    campos.Tipoacumulacion = Convert.ToInt32(itm[8]);
                                    campos.IdtipoPromocion = Convert.ToInt32(itm[9]);
                                    campos.CantidadCompra = Convert.ToInt32(itm[10]);
                                    campos.CantidadEntrega = Convert.ToInt32(itm[11]);
                                    if (!string.IsNullOrWhiteSpace(itm[12].ToString()))
                                    {
                                        campos.FechaIni = (DateTime)itm[12];
                                    }

                                    if (!string.IsNullOrWhiteSpace(itm[13].ToString()))
                                    {
                                        campos.FechaFin = (DateTime)itm[13];
                                    }
                                    if (!string.IsNullOrWhiteSpace(itm[14].ToString()))
                                    {
                                        campos.FechaConteo = (DateTime)itm[14];
                                    }
                                    if (itm[19].ToString() == "2")
                                    {
                                        campos.EstatusPaseProd = Convert.ToInt32(itm[19]);
                                        campos.FechaPaseProduccion = itm[20].ToString();
                                    }
                                    campos.IdPreiodoLimite = Convert.ToInt32(itm[15]);
                                    campos.Limite = Convert.ToInt64(itm[16]);

                                    campos.falgFechaExt = Convert.ToInt32(itm[17]);
                                    if (campos.falgFechaExt == 1)
                                    {
                                        if (!string.IsNullOrWhiteSpace(itm[18].ToString()))
                                        {
                                            campos.FechaExtencion = (DateTime)itm[18];
                                        }
                                    }

                                    campos.CodigoBarras = itm["CodigoBarras"].ToString();
                                    campos.CodigoInternoEntrega = itm[21].ToString();
                                    campos.VerenReporte = Convert.ToBoolean(itm[22]);
                                    if (itm[23] != null)
                                    {
                                        if (!string.IsNullOrWhiteSpace(itm[23].ToString()))
                                        {
                                            campos.CierreCiclosSugeridos = Convert.ToInt32(itm[23]);
                                        }
                                    }


                                    lstResultados.Add(campos);
                                }
                            }
                        }


                        //Tabla 1 Beneficios
                        if (DS.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow itm in DS.Tables[1].Rows)
                            {
                                ModMecanica campos = new ModMecanica();

                                campos.IdSegmento = Convert.ToInt32(itm[1]);
                                campos.CodigoInterno = itm[2].ToString();
                                campos.NomProducto = itm[3].ToString();
                                campos.NombreMecanica = itm[6].ToString();


                                campos.Categoria = itm[4].ToString();
                                campos.Idlaboratorio = Convert.ToInt32(itm[5]);

                                //Provisional
                                foreach (ModLaboratorio itmlab in lstLaboratorios)
                                {
                                    if (itmlab.IdLaboratorio == campos.Idlaboratorio)
                                    {
                                        campos.Laboratorio = itmlab.Laboratorio;
                                    }
                                }
                                campos.Promocion = itm[6].ToString();
                                campos.EstatusInicio = itm[7].ToString();
                                campos.Tipoacumulacion = Convert.ToInt32(itm[8]);
                                campos.IdtipoPromocion = Convert.ToInt32(itm[9]);
                                campos.CantidadCompra = Convert.ToInt32(itm[10]);

                                campos.CantidadEntrega = Convert.ToInt32(itm[11]);
                                if (!string.IsNullOrWhiteSpace(itm[12].ToString()))
                                {
                                    campos.FechaIni = (DateTime)itm[12];
                                }

                                if (!string.IsNullOrWhiteSpace(itm[13].ToString()))
                                {
                                    campos.FechaFin = (DateTime)itm[13];
                                }
                                if (!string.IsNullOrWhiteSpace(itm[14].ToString()))
                                {
                                    campos.FechaConteo = (DateTime)itm[14];
                                }
                                if (itm[19].ToString() == "2")
                                {
                                    campos.EstatusPaseProd = Convert.ToInt32(itm[19]);
                                    campos.FechaPaseProduccion = itm[20].ToString();
                                }
                                campos.IdPreiodoLimite = Convert.ToInt32(itm[15]);
                                campos.Limite = Convert.ToInt64(itm[16]);

                                campos.falgFechaExt = Convert.ToInt32(itm[17]);
                                if (campos.falgFechaExt == 1)
                                {
                                    if (!string.IsNullOrWhiteSpace(itm[18].ToString()))
                                    {
                                        campos.FechaExtencion = (DateTime)itm[18];
                                    }
                                }

                                campos.CodigoBarras = itm["CodigoBarras"].ToString();
                                campos.CodigoInternoEntrega = itm[21].ToString();
                                campos.VerenReporte = Convert.ToBoolean(itm[22]);
                                if (itm[23] != null)
                                {
                                    if (!string.IsNullOrWhiteSpace(itm[23].ToString()))
                                    {
                                        campos.CierreCiclosSugeridos = Convert.ToInt32(itm[23]);
                                    }
                                }


                                lstBeneficios.Add(campos);
                            }
                        }


                        //Comentarios
                        if (DS.Tables[2].Rows.Count > 0) //Comentarios
                        {
                            DTComentarios = DS.Tables[2];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Estructuras.DTComentarios = DTComentarios;
            Estructuras.lstMecanica = lstResultados;
            Estructuras.lstBeneficios = lstBeneficios;

            return Estructuras;
        }
        public bool GuardarPromocionesACDinero(string CnnDabse, ModPromocionesNoIniciadas Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();

                lstParametros.Add(new ParameterIn("@id_tipoAcumulacion", DbType.Int32, Datos.IdTipoAcumulacion));
                lstParametros.Add(new ParameterIn("@id_segmento", DbType.Int32, Datos.IdSegmento));
                lstParametros.Add(new ParameterIn("@idTipoPromocion", DbType.Int32, Datos.IdTipoPromocion));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));
                lstParametros.Add(new ParameterIn("@codigointernoEntrega", DbType.String, Datos.CodigoInternoEntrega));
                lstParametros.Add(new ParameterIn("@nombrePromocion", DbType.String, Datos.NombrePromocion));
                lstParametros.Add(new ParameterIn("@Id_Periodo", DbType.Int32, Datos.IdPeriodo));
                lstParametros.Add(new ParameterIn("@Limite", DbType.Int32, Datos.Limite));
                lstParametros.Add(new ParameterIn("@fechaInicio", DbType.DateTime, Datos.FechaInicio));
                lstParametros.Add(new ParameterIn("@fechaFin", DbType.DateTime, Datos.FechaFin));
                lstParametros.Add(new ParameterIn("@fechaConteo", DbType.DateTime, Datos.FechaConteo));
                lstParametros.Add(new ParameterIn("@comentarios", DbType.String, Datos.Comentarios));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));
                lstParametros.Add(new ParameterIn("@cantidadCompra", DbType.Int32, Datos.CantidadCompra));
                lstParametros.Add(new ParameterIn("@cantidadEntrega", DbType.Int32, Datos.CantidadEntrega));
                lstParametros.Add(new ParameterIn("@lider", DbType.String, Datos.Lider));
                lstParametros.Add(new ParameterIn("@VerEnReporte", DbType.Int32, Datos.VerEnReporte));
                lstParametros.Add(new ParameterIn("@flagExtencion", DbType.Int32, Datos.flagExtension));
                lstParametros.Add(new ParameterIn("@fechaExtencion", DbType.DateTime, Datos.FechaExtension));
                lstParametros.Add(new ParameterIn("@CierreCiclosSugeridos", DbType.Int32, Datos.CierreCiclosSugeridos));


                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[CnnDabse].ConnectionString, "spI_Promocion_AcumulacionDineroEntregaPiezas_pruebas", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool ModificaPromocionesAcumulacionDineroNoIniciadas(string cnnDBase, ModPromocionesNoIniciadas Datos, string SP)
        {
            bool blnCorrecto = true;
            int intRespuesta = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@id_mecanica", DbType.Int32, Datos.IdMecanica));
                lstParametros.Add(new ParameterIn("@id_tipoAcumulacion", DbType.Int32, Datos.IdTipoAcumulacion));
                lstParametros.Add(new ParameterIn("@id_segmento", DbType.Int32, Datos.IdSegmento));
                lstParametros.Add(new ParameterIn("@idTipoPromocion", DbType.Int32, Datos.IdTipoPromocion));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));
                lstParametros.Add(new ParameterIn("@codigointernoEntrega", DbType.String, Datos.CodigoInternoEntrega));
                lstParametros.Add(new ParameterIn("@nombrePromocion", DbType.String, Datos.NombrePromocion));
                lstParametros.Add(new ParameterIn("@Id_Periodo", DbType.Int32, Datos.IdPeriodo));
                lstParametros.Add(new ParameterIn("@Limite", DbType.Int32, Datos.Limite));
                lstParametros.Add(new ParameterIn("@fechaInicio", DbType.DateTime, Datos.FechaInicio));
                lstParametros.Add(new ParameterIn("@fechaFin", DbType.DateTime, Datos.FechaFin));
                lstParametros.Add(new ParameterIn("@fechaConteo", DbType.DateTime, Datos.FechaConteo));
                lstParametros.Add(new ParameterIn("@comentarios", DbType.String, Datos.Comentarios));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));
                lstParametros.Add(new ParameterIn("@cantidadCompra", DbType.Int32, Datos.CantidadCompra));
                lstParametros.Add(new ParameterIn("@cantidadEntrega", DbType.Int32, Datos.CantidadEntrega));
                //lstParametros.Add(new ParameterIn("@VerEnReporte", DbType.Int32, Datos.VerEnReporte));

                if (SP == "spU_PromocionAcumulacionDineroListas_NoIniciada_Update")
                {
                    lstParametros.Add(new ParameterIn("@lider", DbType.String, Datos.Lider));
                }


                if (SP == "sp_Promocion_ProduccionAcumulacion_NoIniciada_Update")//Productivo
                {
                    lstParametros.Add(new ParameterIn("@codigoBarras", DbType.Int32, Datos.CodigoBarras));
                }

                lstParametros.Add(new ParameterIn("@flagExtencion", DbType.Int32, Datos.flagExtension));
                lstParametros.Add(new ParameterIn("@fechaExtencion", DbType.DateTime, Datos.FechaExtension));
                lstParametros.Add(new ParameterIn("@CierreCiclosSugeridos", DbType.Int32, Datos.CierreCiclosSugeridos));

                intRespuesta = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, SP, (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intRespuesta <= 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        public bool ModificaPromocionesACDinero(string cnnDBase, ModPromociones Datos)
        {
            bool blnCorrecto = false;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@id_mecanica", DbType.Int32, Datos.IdMecanica));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));
                lstParametros.Add(new ParameterIn("@nombrePromocion", DbType.String, Datos.NombrePromocion));
                lstParametros.Add(new ParameterIn("@Id_Periodo", DbType.Int32, Datos.IdPeriodo));
                lstParametros.Add(new ParameterIn("@Limite", DbType.Int32, Datos.Limite));
                lstParametros.Add(new ParameterIn("@fechaFin", DbType.DateTime, Datos.FechaFin));
                lstParametros.Add(new ParameterIn("@flagExtencion", DbType.Boolean, Datos.flagExtencion));
                lstParametros.Add(new ParameterIn("@fechaExtencion", DbType.Boolean, Datos.FechaExtencion));
                lstParametros.Add(new ParameterIn("@comentarios", DbType.String, Datos.Comentarios));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));
                lstParametros.Add(new ParameterIn("@VerEnReporte", DbType.Int32, Datos.VerEnReporte));
                lstParametros.Add(new ParameterIn("@CierreCiclosSugeridos", DbType.Int32, Datos.CierreCiclosSugeridos));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "spU_Promocion_ProduccionAcumulacionDinero_Update", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado > 0)
                {
                    blnCorrecto = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        public bool ModificaPromocionesACDineroNoIniciadas(string cnnDBase, ModPromocionesNoIniciadas Datos, string SP)
        {
            bool blnCorrecto = true;
            int intRespuesta = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@id_mecanica", DbType.Int32, Datos.IdMecanica));
                lstParametros.Add(new ParameterIn("@id_tipoAcumulacion", DbType.Int32, Datos.IdTipoAcumulacion));
                lstParametros.Add(new ParameterIn("@id_segmento", DbType.Int32, Datos.IdSegmento));
                lstParametros.Add(new ParameterIn("@idTipoPromocion", DbType.Int32, Datos.IdTipoPromocion));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));

                lstParametros.Add(new ParameterIn("@codigointernoEntrega", DbType.String, Datos.CodigoInternoEntrega));

                lstParametros.Add(new ParameterIn("@nombrePromocion", DbType.String, Datos.NombrePromocion));
                lstParametros.Add(new ParameterIn("@Id_Periodo", DbType.Int32, Datos.IdPeriodo));
                lstParametros.Add(new ParameterIn("@Limite", DbType.Int32, Datos.Limite));
                lstParametros.Add(new ParameterIn("@fechaInicio", DbType.DateTime, Datos.FechaInicio));
                lstParametros.Add(new ParameterIn("@fechaFin", DbType.DateTime, Datos.FechaFin));
                lstParametros.Add(new ParameterIn("@fechaConteo", DbType.DateTime, Datos.FechaConteo));
                lstParametros.Add(new ParameterIn("@comentarios", DbType.String, Datos.Comentarios));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));
                lstParametros.Add(new ParameterIn("@cantidadCompra", DbType.Int32, Datos.CantidadCompra));
                lstParametros.Add(new ParameterIn("@cantidadEntrega", DbType.Int32, Datos.CantidadEntrega));


                lstParametros.Add(new ParameterIn("@VerEnReporte", DbType.Int32, Datos.VerEnReporte));

                lstParametros.Add(new ParameterIn("@codigoBarras", DbType.Int32, Datos.CodigoBarras));

                lstParametros.Add(new ParameterIn("@flagExtencion", DbType.Int32, Datos.flagExtension));
                lstParametros.Add(new ParameterIn("@fechaExtencion", DbType.DateTime, Datos.FechaExtension));
                lstParametros.Add(new ParameterIn("@CierreCiclosSugeridos", DbType.Int32, Datos.CierreCiclosSugeridos));

                intRespuesta = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, SP, (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intRespuesta <= 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        #endregion

        #region "PromocionesDescuentos"
        public int GuardarPromocionesDescuento(ModPromocionDescuentos Datos)
        {
            DataSet DS = new DataSet();
            int intResultado = 0;
            string strFechaIni = Datos.FechaInicio.Year.ToString() + Datos.FechaInicio.Month.ToString("00") + Datos.FechaInicio.Day.ToString("00") + " 00:00:00";
            string strFechaFin = Datos.FechaFin.Year.ToString() + Datos.FechaFin.Month.ToString("00") + Datos.FechaFin.Day.ToString("00") + " 23:59:59";

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@NombrePromocion", DbType.String, Datos.NombrePromocion));
                lstParametros.Add(new ParameterIn("@Cantidad", DbType.Decimal, Datos.Cantidad));
                lstParametros.Add(new ParameterIn("@limite", DbType.Int32, Datos.Limite));
                lstParametros.Add(new ParameterIn("@FechaInicio", DbType.String, strFechaIni));
                lstParametros.Add(new ParameterIn("@FechaFin", DbType.String, strFechaFin));
                lstParametros.Add(new ParameterIn("@IdPeriodo", DbType.Int32, Datos.IdPeriodo));
                lstParametros.Add(new ParameterIn("@ServicioDomicilio", DbType.Int32, Datos.ServicioDomicilio));
                lstParametros.Add(new ParameterIn("@Inapam", DbType.Int32, Datos.Inapam));
                lstParametros.Add(new ParameterIn("@ACBase", DbType.Int32, Datos.AcumulacionBase));
                lstParametros.Add(new ParameterIn("@ACPiezas", DbType.Int32, Datos.AcumulacionPiezas));
                lstParametros.Add(new ParameterIn("@Usuario", DbType.Int32, Datos.UsuarioRegistra));


                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_GuardarPromocionDescuento", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            intResultado = Convert.ToInt32(DS.Tables[0].Rows[0][0]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return intResultado;
        }

        public bool GuardarDiasPromoDescuento(List<ModDiasPromoACBAse> lstDias)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {
                foreach (ModDiasPromoACBAse Datos in lstDias)
                {
                    ArrayList lstParametros = new ArrayList();
                    lstParametros.Add(new ParameterIn("@Id_PDescuento", DbType.Int32, Datos.IdPABase));
                    lstParametros.Add(new ParameterIn("@Dia", DbType.Int32, Datos.Dia));
                    lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                    intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_DiasPromocionesDescuento", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                }

                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blnRespuesta;
        }
        public bool GuardarBinsPromoDescuento(ModBin Datos)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdPDescuento", DbType.Int32, Datos.IdPDescuento));
                lstParametros.Add(new ParameterIn("@IdClub", DbType.Int32, Datos.IdClub));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_BinsPromocionesDescuento", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));

                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blnRespuesta;
        }

        public bool GuardarProductosPromoDescuento(ModProductosPromoACBase Datos)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {

                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@id_PDescuento", DbType.Int32, Datos.IdPABase));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.Int32, Datos.CodigoInterno));
                lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_ProductosPromocionesDescuento", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));


                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blnRespuesta;
        }

        public bool GuardarSucursalesPromoDescuento(ModSucursalesPromoACBase Datos)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {

                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Id_PDescuento", DbType.Int32, Datos.IdPABase));
                lstParametros.Add(new ParameterIn("@Sucursal", DbType.String, Datos.strSucursal));
                lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_SucursalesPromocionesDescuento", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));


                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blnRespuesta;
        }

        public bool ModificarPromoDescuento(ModPromocionDescuentos Datos)
        {
            bool blnRespuesta = false;
            DataSet DS = new DataSet();
            int intResultado = 0;
            string strFechaIni = Datos.FechaInicio.Year.ToString() + Datos.FechaInicio.Month.ToString("00") + Datos.FechaInicio.Day.ToString("00") + " 00:00:00";
            string strFechaFin = Datos.FechaFin.Year.ToString() + Datos.FechaFin.Month.ToString("00") + Datos.FechaFin.Day.ToString("00") + " 23:59:59";

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdPDescuento", DbType.Int32, Datos.IdPDescuento));
                lstParametros.Add(new ParameterIn("@NombrePromocion", DbType.String, Datos.NombrePromocion));
                lstParametros.Add(new ParameterIn("@Cantidad", DbType.Decimal, Datos.Cantidad));
                lstParametros.Add(new ParameterIn("@IdPeriodo", DbType.Int32, Datos.IdPeriodo));
                lstParametros.Add(new ParameterIn("@Limite", DbType.Int32, Datos.Limite));
                lstParametros.Add(new ParameterIn("@FechaInicio", DbType.String, strFechaIni));
                lstParametros.Add(new ParameterIn("@FechaFin", DbType.String, strFechaFin));
                lstParametros.Add(new ParameterIn("@ServicioDomicilio", DbType.Int32, Datos.ServicioDomicilio));
                lstParametros.Add(new ParameterIn("@Inapam", DbType.Int32, Datos.Inapam));
                lstParametros.Add(new ParameterIn("@ACBase", DbType.Int32, Datos.AcumulacionBase));
                lstParametros.Add(new ParameterIn("@ACPiezas", DbType.Int32, Datos.AcumulacionPiezas));
                lstParametros.Add(new ParameterIn("@Usuario", DbType.Int32, Datos.UsuarioRegistra));


                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_ModificarPromocionDescuento", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));

                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool ModificarDiasPromoDescuento(List<ModDiasPromoACBAse> lstDias)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {
                foreach (ModDiasPromoACBAse Datos in lstDias)
                {
                    ArrayList lstParametros = new ArrayList();
                    lstParametros.Add(new ParameterIn("@IdPDescuento", DbType.Int32, Datos.IdPABase));
                    lstParametros.Add(new ParameterIn("@Dia", DbType.Int32, Datos.Dia));
                    lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                    intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_DiasPromocionesDescuento", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                }

                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }


                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool ModificarBinsPromoDescuento(ModBin Datos)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdPDescuento", DbType.Int32, Datos.IdPDescuento));
                lstParametros.Add(new ParameterIn("@IdClub", DbType.Int32, Datos.IdClub));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_BinsPromocionesDescuento", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));

                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }


                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool DesactivarBinsPromoDescuento(int IdPDescuento)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdPDescuento", DbType.Int32, IdPDescuento));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_DesActivarBinsPromocionesDescuento", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));

                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blnRespuesta;
        }
        public bool ModificarProductosPromoDescuento(ModProductosPromoACBase Datos)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {

                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@IdPDescuento", DbType.Int32, Datos.IdPABase));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.Int32, Datos.CodigoInterno));
                lstParametros.Add(new ParameterIn("@codigointernoNvo", DbType.Int32, Datos.CodigoInternoNvo));
                lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_ProductosPromocionesDescuento", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));


                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }


                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public bool ModificarSucursalesPromoDescuento(ModSucursalesPromoACBase Datos)
        {
            bool blnRespuesta = false;
            int intResultado = 0;

            try
            {

                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Id_PDescuento", DbType.Int32, Datos.IdPABase));
                lstParametros.Add(new ParameterIn("@Sucursal", DbType.String, Datos.strSucursal));
                lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_SucursalesPromocionesDescuento", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));


                if (intResultado > 0)
                {
                    blnRespuesta = true;
                }


                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public bool ValidaPromocionDescuento(ModPromoACBaseValidaciones Datos)
        {
            bool blnRespuesta = false;
            DataSet DS = new DataSet();
            int intResultado = 0;
            string strFechaIni = Datos.FechaIni.Year.ToString() + Datos.FechaIni.Month.ToString("00") + Datos.FechaIni.Day.ToString("00") + " 00:00:00";
            string strFechaFin = Datos.FechaFin.Year.ToString() + Datos.FechaFin.Month.ToString("00") + Datos.FechaFin.Day.ToString("00") + " 23:59:59";

            ArrayList lstParametros = new ArrayList();
            lstParametros.Add(new ParameterIn("@CodigoInterno", DbType.Int32, Datos.CodigoInterno));
            lstParametros.Add(new ParameterIn("@Sucursal", DbType.String, Datos.Sucursal));
            lstParametros.Add(new ParameterIn("@FechaIni", DbType.DateTime, strFechaIni));
            lstParametros.Add(new ParameterIn("@FechaFin", DbType.DateTime, strFechaFin));

            DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ValidaExistenciaPromocionesDescuento", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));

            if (DS != null)
            {
                if (DS.Tables.Count > 0)
                {
                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        intResultado = Convert.ToInt32(DS.Tables[0].Rows[0]["Existen"].ToString());
                        if (intResultado > 0)
                        {
                            //Indica que ya existe alguna promoción en dbase
                            blnRespuesta = true;
                        }
                    }
                }
            }

            return blnRespuesta;
        }
        public bool ValidaExistenciaCodInternoDescuento(string CodInterno)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            bool blnRespuesta = false;

            try
            {
                lstParameters.Add(new ParameterIn("@codigointerno", DbType.String, CodInterno));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_Promocion_DatosPruduto", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            //Indica que es valido el código interno
                            blnRespuesta = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnRespuesta;
        }
        public int RegresaIdSucursalDescuento(string Sucursal)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            int intRespuesta = 0;

            try
            {
                lstParameters.Add(new ParameterIn("@Sucursal", DbType.String, Sucursal.Trim()));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenEquivalenciaSucursalesACBase", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            //Devuelve Equivalencia 
                            intRespuesta = Convert.ToInt32(DS.Tables[0].Rows[0]["Sucursal_intCiaSuc"]);
                        }
                        else
                        {
                            //Devuelve un valor inexistente de sucursal
                            intRespuesta = 99999;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intRespuesta;
        }
        public bool ValidaExistenciaSucursalDescuento(int Sucursal)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            bool blnRespuesta = false;

            try
            {
                lstParameters.Add(new ParameterIn("@Sucursal", DbType.Int32, Sucursal));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ValidaExistenciaSucursalesACBase", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToInt32(DS.Tables[0].Rows[0]["Existe"]) == 1)
                            {
                                //Indica que es valida la sucursal
                                blnRespuesta = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnRespuesta;
        }
        public List<ModPromocionDescuentos> ObtenPromoDescuento(string NomPromo)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            List<ModPromocionDescuentos> lstPromoACBase = new List<ModPromocionDescuentos>();

            try
            {
                lstParameters.Add(new ParameterIn("@Nombre", DbType.String, NomPromo.Trim()));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenPromocionesDescuento", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModPromocionDescuentos campos = new ModPromocionDescuentos();

                                campos.IdPDescuento = Convert.ToInt32(reg[0]);
                                campos.NombrePromocion = reg[1].ToString();
                                campos.Cantidad = Convert.ToDecimal(reg[2]);
                                campos.Limite = Convert.ToInt32(reg["limite"]);
                                campos.IdPeriodo = Convert.ToInt32(reg["id_periodo"]);
                                campos.FechaInicio = Convert.ToDateTime(reg[4]);
                                campos.FechaFin = Convert.ToDateTime(reg[5]);
                                campos.ServicioDomicilio = Convert.ToInt32(reg[7]);
                                campos.Inapam = Convert.ToInt32(reg["adicionalINAPAM"]);
                                campos.AcumulacionBase = Convert.ToInt32(reg["aplicaAcumulacionBase"]);
                                campos.AcumulacionPiezas = Convert.ToInt32(reg["aplicaAcumulacionPiezas"]);

                                lstPromoACBase.Add(campos);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstPromoACBase;
        }
        public List<ModDiasPromoACBAse> ObtenDiasDescuento(int IdPABase)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            List<ModDiasPromoACBAse> lstDiasACBase = new List<ModDiasPromoACBAse>();
            int intRespuesta = 0;

            try
            {
                lstParameters.Add(new ParameterIn("@IdPDescuento", DbType.Int32, IdPABase));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenerDiasDescuento", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModDiasPromoACBAse campos = new ModDiasPromoACBAse();

                                campos.IdPABase = Convert.ToInt32(reg[1]);
                                campos.Dia = Convert.ToInt32(reg[2]);
                                campos.IdStatus = Convert.ToInt32(reg[3]);

                                lstDiasACBase.Add(campos);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstDiasACBase;
        }
        public List<ModProductosPromoACBase> ObtenProductosDescuento(int IdPABase)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            List<ModProductosPromoACBase> lstProdACBase = new List<ModProductosPromoACBase>();

            try
            {
                lstParameters.Add(new ParameterIn("@IdPDescuento", DbType.Int32, IdPABase));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_obtenerProductosDescuento", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModProductosPromoACBase campos = new ModProductosPromoACBase();

                                campos.IdPABase = Convert.ToInt32(reg[1]);
                                campos.CodigoInterno = reg[2].ToString();
                                campos.CodigoInternoAnt = reg[2].ToString();
                                campos.IdStatus = Convert.ToInt32(reg[3]);

                                lstProdACBase.Add(campos);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstProdACBase;
        }
        public List<ModSucursalesPromoACBase> ObtenSucursalDescuento(int IdPABase)
        {
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            List<ModSucursalesPromoACBase> lstSucACBase = new List<ModSucursalesPromoACBase>();

            try
            {
                lstParameters.Add(new ParameterIn("IdPDescuento", DbType.Int32, IdPABase));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_obtenerSucursalesDescuento", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModSucursalesPromoACBase campos = new ModSucursalesPromoACBase();

                                campos.IdPABase = Convert.ToInt32(reg[1]);
                                campos.Sucursal = Convert.ToInt32(reg[2]);
                                campos.SucursalAnt = Convert.ToInt32(reg[2]);
                                campos.IdStatus = Convert.ToInt32(reg[3]);
                                campos.NomSucursal = reg[4].ToString();

                                lstSucACBase.Add(campos);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstSucACBase;
        }
        public List<ModBin> ObtenBins(string cnnDBase)
        {
            ArrayList lstParameters = new ArrayList();
            List<ModBin> lstResultados = new List<ModBin>();
            try
            {
                DataSet DS = new DataSet();
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_ObtenBIn", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModBin campos = new ModBin();

                    campos.IdClub = Convert.ToInt32(itm["id_club"]);
                    campos.DescClub = itm["descripcion"].ToString();

                    lstResultados.Add(campos);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultados;
        }
        public List<ModSucursales> ObtenerAllSucursales(string cnnDBase)
        {
            ArrayList lstParameters = new ArrayList();
            List<ModSucursales> lstResultados = new List<ModSucursales>();
            try
            {
                DataSet DS = new DataSet();
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_ObtenerAllSucursales", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModSucursales campos = new ModSucursales();

                    campos.Sucursal = itm["Sucursal_intCiaSuc"].ToString();

                    lstResultados.Add(campos);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultados;
        }
        public List<ModBin> ConsultaBins(string cnnDBase, int IDPDescuento)
        {
            ArrayList lstParameters = new ArrayList();
            List<ModBin> lstResultados = new List<ModBin>();
            try
            {
                DataSet DS = new DataSet();
                lstParameters.Add(new ParameterIn("@IdPDescuento", DbType.Int32, IDPDescuento));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDBase].ConnectionString, "sp_RegresaBinXIdPDescuento", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                foreach (DataRow itm in DS.Tables[0].Rows)
                {
                    ModBin campos = new ModBin();

                    campos.IdClub = Convert.ToInt32(itm["id_club"]);

                    lstResultados.Add(campos);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultados;
        }

        #endregion

        #region "PromocionesEscalonadas"
        public List<ModPromoEscalonada> ObtenerPromocionesEscalonadas(string valor)
        {
            try
            {
                DataSet DS = new DataSet();
                List<ModPromoEscalonada> lstPromoEsc = new List<ModPromoEscalonada>();
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@ValorFiltro", DbType.String, valor));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenerPromoEscalonada", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModPromoEscalonada campos = new ModPromoEscalonada();

                                campos.FechaIni = Convert.ToDateTime(reg["FechaInicio"]);
                                campos.FechaFin = Convert.ToDateTime(reg["FechaFin"]);
                                campos.Cupon = reg["cupon"].ToString();
                                campos.IdPromocion = Convert.ToInt32(reg["idPromocion"]);
                                campos.Identificador = reg["Identificador"].ToString();

                                lstPromoEsc.Add(campos);
                            }
                        }
                    }
                }
                return lstPromoEsc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ModPromoEscalonada> ObtenerPromocionesEscalonadasDetalle(string valor)
        {
            try
            {
                DataSet DS = new DataSet();
                List<ModPromoEscalonada> lstPromoEsc = new List<ModPromoEscalonada>();
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@Identificador", DbType.String, valor));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenerPromoEscalonadaDetalle", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModPromoEscalonada campos = new ModPromoEscalonada();

                                campos.FechaIni = Convert.ToDateTime(reg["FechaInicio"]);
                                campos.FechaFin = Convert.ToDateTime(reg["FechaFin"]);
                                campos.Cupon = reg["cupon"].ToString();
                                campos.IdPromocion = Convert.ToInt32(reg["idPromocion"]);
                                campos.IdPromocionDispara = Convert.ToInt32(reg["IdpromocionDispara"]);
                                campos.MensajePOS = reg["MensajePOS"].ToString();
                                campos.IdStatus = reg["id_status"].ToString();
                                campos.Id = Convert.ToInt32(reg["id"]);
                                campos.DuracionCupon = Convert.ToInt32(reg["DiasDeVigencia"]);
                                campos.RetrocederEscalon = Convert.ToInt32(reg["aplicarRetorno"]);
                                campos.RetornoIlimitado = Convert.ToInt32(reg["RetornoIlimitado"]);

                                if (string.IsNullOrWhiteSpace(reg["RetornoInicio"].ToString()))
                                {
                                    campos.RetornoInicio = 0;
                                }
                                else
                                {
                                    campos.RetornoInicio = Convert.ToInt32(reg["RetornoInicio"]);
                                }

                                if ((bool)reg["EsPromoTrigger"])
                                {
                                    campos.EsPromoTrigger = 1;
                                    if (float.Parse(reg["montoTrigger"].ToString()) != 0.00)
                                    {
                                        campos.CodigoInterno = "";
                                        campos.MontoTrigger = float.Parse(reg["montoTrigger"].ToString());
                                    }

                                    if (!string.IsNullOrWhiteSpace(reg["codigointerno"].ToString()))
                                    {
                                        campos.MontoTrigger = float.Parse("0");
                                        campos.CodigoInterno = reg["codigointerno"].ToString();
                                    }
                                }
                                else
                                {
                                    campos.EsPromoTrigger = 0;
                                    campos.MontoTrigger = float.Parse("0");
                                    campos.CodigoInterno = "";
                                }

                                lstPromoEsc.Add(campos);
                            }
                        }
                    }
                }
                return lstPromoEsc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ValidaExistenciaIdPromo(string Cupon, Int32 IdPromo)
        {
            int intExiste = 0;
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            bool blnRespuesta = false;

            try
            {
                lstParameters.Add(new ParameterIn("@Cupon", DbType.String, Cupon));
                lstParameters.Add(new ParameterIn("@IdPromocion", DbType.Int32, IdPromo));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), "sp_ValidaExistenciaCupones", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            intExiste = Convert.ToInt32(DS.Tables[0].Rows[0][0]);
                            if (intExiste > 0)
                            {
                                blnRespuesta = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnRespuesta;
        }
        public bool ValidaExistenciaPromoEscVigencia(string Cupon, Int32 IdPromo, DateTime FechaIni, DateTime FechaFin)
        {
            int intExiste = 0;
            DataSet DS = new DataSet();
            ArrayList lstParameters = new ArrayList();
            bool blnRespuesta = false;
            string strFechaIni = "";
            string strFechaFin = "";

            strFechaIni = FechaIni.Year.ToString() + FechaIni.Month.ToString("00") + FechaIni.Day.ToString("00") + " 00:00:00";
            strFechaFin = FechaFin.Year.ToString() + FechaFin.Month.ToString("00") + FechaFin.Day.ToString("00") + " 23:59:59";

            try
            {
                lstParameters.Add(new ParameterIn("@Cupon", DbType.String, Cupon));
                lstParameters.Add(new ParameterIn("@IdPromocion", DbType.Int32, IdPromo));
                lstParameters.Add(new ParameterIn("@FechaIni", DbType.DateTime, strFechaIni));
                lstParameters.Add(new ParameterIn("@FechaFin", DbType.DateTime, strFechaFin));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), "sp_ValidaVigenciaPromocionEscalonada", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "AdminProm");
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            intExiste = Convert.ToInt32(DS.Tables[0].Rows[0][0]);
                            if (intExiste > 0)
                            {
                                blnRespuesta = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnRespuesta;
        }
        public string GuardarNuevaPromoEscalonada(ModPromoEscalonada Datos)
        {
            DataSet DS = new DataSet();
            bool blnRespuesta = false;
            int intResultado = 0;
            string strFechaIni = "";
            string strFechaFin = "";
            string Identificador = "";

            strFechaIni = Datos.FechaIni.Year.ToString() + Datos.FechaIni.Month.ToString("00") + Datos.FechaIni.Day.ToString("00") + " 00:00:00";
            strFechaFin = Datos.FechaFin.Year.ToString() + Datos.FechaFin.Month.ToString("00") + Datos.FechaFin.Day.ToString("00") + " 23:59:59";

            try
            {
                ArrayList lstParametros = new ArrayList();

                lstParametros.Add(new ParameterIn("@cupon", DbType.String, Datos.Cupon));
                lstParametros.Add(new ParameterIn("@idPromocion", DbType.Int32, Datos.IdPromocion));
                lstParametros.Add(new ParameterIn("@idPromocionDispara", DbType.Int32, Datos.IdPromocionDispara));
                lstParametros.Add(new ParameterIn("@mensajePOS", DbType.String, Datos.MensajePOS));
                lstParametros.Add(new ParameterIn("@fechainicio", DbType.DateTime, strFechaIni));
                lstParametros.Add(new ParameterIn("@fechafin", DbType.DateTime, strFechaFin));
                lstParametros.Add(new ParameterIn("@orden", DbType.Int32, Datos.Orden));
                lstParametros.Add(new ParameterIn("@Identificador", DbType.String, Datos.Identificador));
                lstParametros.Add(new ParameterIn("@DuracionCupon", DbType.Int32, Datos.DuracionCupon));
                lstParametros.Add(new ParameterIn("@RetrocederEscalon", DbType.Int32, Datos.RetrocederEscalon));
                lstParametros.Add(new ParameterIn("@RetornoIlimitado", DbType.Int32, Datos.RetornoIlimitado));
                lstParametros.Add(new ParameterIn("@aplicarRetornoInicio", DbType.Int32, Datos.RetornoInicio));
                lstParametros.Add(new ParameterIn("@EsPromoTrigger", DbType.Int32, Datos.EsPromoTrigger));
                lstParametros.Add(new ParameterIn("@montoTrigger", DbType.Currency, Datos.MontoTrigger));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));



                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_RegistraPromoEscalonada", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            Identificador = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }



            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return Identificador;
        }
        public bool ModificarPromoEscalonada(ModPromoEscalonada Datos)
        {
            DataSet DS = new DataSet();
            string strFechaIni = "";
            string strFechaFin = "";
            int intRespuesta = 0;
            bool blnRespuesta = false;

            strFechaIni = Datos.FechaIni.Year.ToString() + Datos.FechaIni.Month.ToString("00") + Datos.FechaIni.Day.ToString("00") + " 00:00:00";
            strFechaFin = Datos.FechaFin.Year.ToString() + Datos.FechaFin.Month.ToString("00") + Datos.FechaFin.Day.ToString("00") + " 23:59:59";

            try
            {
                ArrayList lstParametros = new ArrayList();

                lstParametros.Add(new ParameterIn("@Identificador", DbType.String, Datos.Identificador));
                lstParametros.Add(new ParameterIn("@Cupon", DbType.String, Datos.Cupon));
                lstParametros.Add(new ParameterIn("@IdPromocion", DbType.String, Datos.IdPromocion));
                lstParametros.Add(new ParameterIn("@IdPromocionDispara", DbType.String, Datos.IdPromocionDispara));
                lstParametros.Add(new ParameterIn("@fechainicio", DbType.DateTime, strFechaIni));
                lstParametros.Add(new ParameterIn("@fechafin", DbType.DateTime, strFechaFin));
                lstParametros.Add(new ParameterIn("@MensajePOS", DbType.String, Datos.MensajePOS));
                lstParametros.Add(new ParameterIn("@Id", DbType.Int32, Datos.Id));
                lstParametros.Add(new ParameterIn("@IdStatus", DbType.Int32, Datos.IdStatus));
                lstParametros.Add(new ParameterIn("@DuracionCupon", DbType.Int32, Datos.DuracionCupon));
                lstParametros.Add(new ParameterIn("@orden", DbType.Int32, Datos.Orden));
                lstParametros.Add(new ParameterIn("@RetrocederEscalon", DbType.Int32, Datos.RetrocederEscalon));
                lstParametros.Add(new ParameterIn("@RetornoIlimitado", DbType.Int32, Datos.RetornoIlimitado));
                lstParametros.Add(new ParameterIn("@aplicarRetornoInicio", DbType.Int32, Datos.RetornoInicio));
                lstParametros.Add(new ParameterIn("@EsPromoTrigger", DbType.Int32, Datos.EsPromoTrigger));
                lstParametros.Add(new ParameterIn("@montoTrigger", DbType.Currency, Datos.MontoTrigger));
                lstParametros.Add(new ParameterIn("@codigointerno", DbType.String, Datos.CodigoInterno));


                intRespuesta = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_ModificaPromoEscalonada", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));

                if (intRespuesta > 0)
                {
                    blnRespuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blnRespuesta;
        }
        public bool EliminarPromocionEscalonada(string Identificador)
        {
            bool blnCorrecto = false;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Identificador", DbType.String, Identificador));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_PromocionEscalonada_Borrar", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado > 0)
                {
                    blnCorrecto = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnCorrecto;
        }
        #endregion
    }
}
