using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ORMModel;
using System.Data;
using System.Configuration;
using Entidades;
using System.Web.Security;

namespace Datos
{
    public class DLMecanica
    {
        static string PROCEDURE_MECANICA_CONSULTA = "usp_MecanicaObtener";
        static string PROCEDURE_MECANICACATEGORIA_CONSULTA = "usp_MecanicaCategoriaObtener";
        static string PROCEDURE_MECANICACATEGORIA_DETALLE = "usp_MecanicaObtenerDetalle";
        static string PROCEDURE_MECANICA_CONSULTAPRODUCTOS = "usp_MecanicaProductosXCategoria";
        static string PROCEDURE_MECANICA_ALTA = "usp_InsertaMecanicaNM";
        static string PROCEDURE_MECANICA_EDICION = "usp_ActualizaMecanicaNM";
        static string PROCEDURE_MECANICA_CANCELAR = "usp_CancelaMecanicaConfiguracion";
        static string PROCEDURE_MECANICA_COPIA = "usp_CopiaMecanicaNM";

        public static List<MecanicaConfiguracionConsulta> ObtenerLista(MecanicaConfiguracionConsulta objInfo)
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            List<MecanicaConfiguracionConsulta> Resultado = new List<MecanicaConfiguracionConsulta>();

            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_MECANICA_CONSULTA;

                        command.CommandTimeout = 0;

                        command.Parameters.Add(new SqlParameter("@pIdClub", objInfo.Id_Club));
                        command.Parameters.Add(new SqlParameter("@pIdNivel", objInfo.Id_Nivel));
                        command.Parameters.Add(new SqlParameter("@pEdadIni", objInfo.EdadIni));
                        command.Parameters.Add(new SqlParameter("@pEdadFinal", objInfo.EdadFin));
                        command.Parameters.Add(new SqlParameter("@pBeneficioIni", objInfo.BeneficioIni));
                        command.Parameters.Add(new SqlParameter("@pBeneficioFin", objInfo.BeneficioFin));
                        command.Parameters.Add(new SqlParameter("@pIdPeriodo", objInfo.Id_Periodo));
                        command.Parameters.Add(new SqlParameter("@pIdLimite", objInfo.Limite));
                        command.Parameters.Add(new SqlParameter("@pEstatus", objInfo.id_status));
                        command.Parameters.Add(new SqlParameter("@pNombre", objInfo.Nombre));
                        command.Parameters.Add(new SqlParameter("@pDescripcion", objInfo.Descripcion));
                        command.Parameters.Add(new SqlParameter("@pIdCategoriaMecanica", objInfo.id_categoriaMecanica));


                        var objReader = command.ExecuteReader();

                        while (objReader.Read())
                        {
                            MecanicaConfiguracionConsulta obj = new MecanicaConfiguracionConsulta();

                            obj.BeneficioFin = objReader.ObtenerValor<int>("BeneficioFin");
                            obj.BeneficioIni = objReader.ObtenerValor<int>("BeneficioIni");
                            obj.DescClub = objReader.ObtenerValor<string>("DescClub");
                            obj.Descripcion = objReader.ObtenerValor<string>("Descripcion");
                            obj.EdadFin = objReader.ObtenerValor<int>("EdadFin");
                            obj.EdadIni = objReader.ObtenerValor<int>("EdadIni");
                            obj.FechaFin = objReader.ObtenerValor<DateTime>("FechaFin");
                            obj.FechaIni = objReader.ObtenerValor<DateTime>("FechaIni");
                            obj.Id_Club = objReader.ObtenerValor<int>("Id_Club");
                            obj.id_grupoMecanica = objReader.ObtenerValor<string>("id_grupoMecanica");
                            obj.Id_MecanicaConfiguracion = objReader.ObtenerValor<int>("Id_MecanicaConfiguracion");
                            obj.Id_mecanicaNivel = objReader.ObtenerValor<int>("Id_mecanicaNivel");
                            obj.Id_Nivel = objReader.ObtenerValor<int>("Id_Nivel");
                            obj.Id_Periodo = objReader.ObtenerValor<int>("Id_Periodo");
                            obj.idGrupoMecanicaJoin = objReader.ObtenerValor<int>("idGrupoMecanicaJoin");
                            obj.Limite = objReader.ObtenerValor<int>("Limite");
                            obj.LimiteMecanica = objReader.ObtenerValor<int>("LimiteMecanica");
                            obj.Nombre = objReader.ObtenerValor<string>("Nombre");
                            obj.Perido = objReader.ObtenerValor<string>("Perido");
                            obj.Status = objReader.ObtenerValor<string>("Status");
                            obj.CategoriaMecanica = objReader.ObtenerValor<string>("DescCategoriaMecanica");
                            obj.id_categoriaMecanica = objReader.ObtenerValor<int>("id_categoriaMecanica");

                            obj.DescNivel = objReader.ObtenerValor<string>("DescNivel");
                            Resultado.Add(obj);
                        }
                    }

                    return Resultado;
                }
                catch (SqlException sqlEx)
                {
                    throw new InvalidOperationException("No fue posible obtener la info del catalogo.", sqlEx);
                }
                finally
                {
                    cnn.Close();
                }
            }


        }


        public static MecanicaConfiguracionConsulta ObtenerDetalle(long IdMecanicaConfiguracion, int idNivel)
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            MecanicaConfiguracionConsulta obj = new MecanicaConfiguracionConsulta();

            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_MECANICACATEGORIA_DETALLE;

                        command.CommandTimeout = 0;

                        command.Parameters.Add(new SqlParameter("@pIdMecanicaConfiguracion", IdMecanicaConfiguracion));
                        command.Parameters.Add(new SqlParameter("@pIdNivel", idNivel));

                        var objReader = command.ExecuteReader();


                        while (objReader.Read())
                        {


                            obj.BeneficioFin = objReader.ObtenerValor<int>("BeneficioFin");
                            obj.BeneficioIni = objReader.ObtenerValor<int>("BeneficioIni");
                            obj.DescClub = objReader.ObtenerValor<string>("DescClub");
                            obj.Descripcion = objReader.ObtenerValor<string>("Descripcion");
                            obj.EdadFin = objReader.ObtenerValor<int>("EdadFin");
                            obj.EdadIni = objReader.ObtenerValor<int>("EdadIni");
                            obj.FechaFin = objReader.ObtenerValor<DateTime>("FechaFin");
                            obj.FechaIni = objReader.ObtenerValor<DateTime>("FechaIni");
                            obj.Id_Club = objReader.ObtenerValor<int>("Id_Club");
                            obj.id_grupoMecanica = objReader.ObtenerValor<string>("id_grupoMecanica");
                            obj.Id_MecanicaConfiguracion = objReader.ObtenerValor<int>("Id_MecanicaConfiguracion");
                            obj.Id_mecanicaNivel = objReader.ObtenerValor<int>("Id_mecanicaNivel");
                            obj.Id_Nivel = objReader.ObtenerValor<int>("Id_Nivel");
                            obj.Id_Periodo = objReader.ObtenerValor<int>("Id_Periodo");
                            obj.idGrupoMecanicaJoin = objReader.ObtenerValor<int>("idGrupoMecanicaJoin");
                            obj.Limite = objReader.ObtenerValor<int>("Limite");
                            obj.LimiteMecanica = objReader.ObtenerValor<int>("LimiteMecanica");
                            obj.Nombre = objReader.ObtenerValor<string>("Nombre");
                            obj.Perido = objReader.ObtenerValor<string>("Perido");
                            obj.Status = objReader.ObtenerValor<string>("Status");
                            obj.CategoriaMecanica = objReader.ObtenerValor<string>("DescCategoriaMecanica");
                            obj.id_categoriaMecanica = objReader.ObtenerValor<int>("id_categoriaMecanica");

                            obj.IdTipoPrecio = objReader.ObtenerValor<int>("id_Tipoprecio");
                            obj.DescTipoPrecio = objReader.ObtenerValor<string>("DescTipoPrecio");

                            obj.DescNivel = objReader.ObtenerValor<string>("DescNivel");

                        }

                        obj.PiezasLista = new List<ProductoSeleccionadoLista>();
                        /*Obtiene las piezas*/
                        if (objReader.NextResult())
                        {
                            while (objReader.Read())
                            {
                                ProductoSeleccionadoLista prod = new ProductoSeleccionadoLista();
                                prod.Cantidad = objReader.ObtenerValor<int>("cantidad").ToString();
                                prod.CodigoBarras = objReader.ObtenerValor<string>("codigoBarras");
                                prod.Nombre = objReader.ObtenerValor<string>("nombre");
                                prod.Descripcion = objReader.ObtenerValor<string>("Descripcion");
                                prod.DescripcionProducto = objReader.ObtenerValor<string>("Producto_strDescripcion");
                                prod.IdCategoria = objReader.ObtenerValor<int>("id_producto_cetegoria").ToString();
                                prod.IdCodigoInterno = objReader.ObtenerValor<string>("id_codigoInterno");
                                prod.Id = objReader.ObtenerValor<int>("id_mecanicaDetalles");
                                obj.PiezasLista.Add(prod);
                            }
                        }
                        obj.BeneficioLista = new List<ProductoSeleccionadoLista>();

                        /*Obtiene los beneficios*/
                        if (objReader.NextResult())
                        {
                            while (objReader.Read())
                            {
                                ProductoSeleccionadoLista prod = new ProductoSeleccionadoLista();
                                prod.Cantidad = objReader.ObtenerValor<string>("cantidad");
                                prod.CodigoBarras = objReader.ObtenerValor<string>("codigoBarras");
                                prod.Nombre = objReader.ObtenerValor<string>("nombre");
                                prod.Descripcion = objReader.ObtenerValor<string>("Descripcion");
                                prod.DescripcionProducto = objReader.ObtenerValor<string>("Producto_strDescripcion");
                                prod.IdCategoria = objReader.ObtenerValor<string>("id_producto_cetegoria");
                                prod.IdCodigoInterno = objReader.ObtenerValor<string>("id_codigoInterno");
                                prod.Id = objReader.ObtenerValor<int>("id_mecanicaBeneficio");
                                obj.BeneficioLista.Add(prod);
                            }
                        }
                    }



                    return obj;
                }
                catch (SqlException sqlEx)
                {
                    throw new InvalidOperationException("No fue posible obtener la info del catalogo.", sqlEx);
                }
                finally
                {
                    cnn.Close();
                }
            }


        }

        public static List<ProductoCategoria> ObtenerListaCategorias(string Descripcion)
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            List<ProductoCategoria> Resultado = new List<ProductoCategoria>();

            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_MECANICACATEGORIA_CONSULTA;

                        command.CommandTimeout = 0;

                        command.Parameters.Add(new SqlParameter("@pDescripcion", Descripcion));

                        var objReader = command.ExecuteReader();

                        while (objReader.Read())
                        {
                            ProductoCategoria obj = new ProductoCategoria();

                            obj.Descripcion = objReader.ObtenerValor<string>("Descripcion");
                            obj.id_laboratorio = objReader.ObtenerValor<int>("id_laboratorio");
                            obj.id_producto_categoria = objReader.ObtenerValor<int>("id_producto_categoria");
                            obj.id_status = objReader.ObtenerValor<int>("id_status");
                            obj.Producto_dateFechaAlta = objReader.ObtenerValor<DateTime>("Producto_dateFechaAlta");
                            obj.Producto_dateFechaModificacion = objReader.ObtenerValor<DateTime>("Producto_dateFechaModificacion");

                            Resultado.Add(obj);
                        }
                    }

                    return Resultado;
                }
                catch (SqlException sqlEx)
                {
                    throw new InvalidOperationException("No fue posible obtener la info del catalogo.", sqlEx);
                }
                finally
                {
                    cnn.Close();
                }
            }


        }

        public static List<ProductoM> ObtenerListaProductos(int idCategoria, long IdProducto)
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            List<ProductoM> Resultado = new List<ProductoM>();

            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_MECANICA_CONSULTAPRODUCTOS;

                        command.CommandTimeout = 0;

                        command.Parameters.Add(new SqlParameter("@pIdProductoCategoria", idCategoria));
                        command.Parameters.Add(new SqlParameter("@pIdProducto", IdProducto));

                        var objReader = command.ExecuteReader();

                        while (objReader.Read())
                        {
                            ProductoM obj = new ProductoM();

                            obj.Producto_intCvo = objReader.ObtenerValor<int>("Producto_intCvo");
                            obj.Producto_strDescripcion = objReader.ObtenerValor<string>("Producto_strDescripcion");
                            obj.SKU = objReader.ObtenerValor<string>("Producto_strSKU");
                            obj.SKU_Benavides = objReader.ObtenerValor<string>("Producto_strSKUBenavides");

                            Resultado.Add(obj);
                        }
                    }

                    return Resultado;
                }
                catch (SqlException sqlEx)
                {
                    throw new InvalidOperationException("No fue posible obtener la info del catalogo.", sqlEx);
                }
                finally
                {
                    cnn.Close();
                }
            }


        }


        public static bool AltaMecanica(MecanicaConfiguracionConsulta objInfo)
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            bool Resultado = false;

            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_MECANICA_ALTA;

                        command.CommandTimeout = 0;

                        command.Parameters.Add(new SqlParameter("@pNombre", objInfo.Nombre));
                        command.Parameters.Add(new SqlParameter("@pDescripcion", objInfo.Descripcion));
                        command.Parameters.Add(new SqlParameter("@pPiezasProductostr_SKU", objInfo.PiezasProductostr_SKU));
                        command.Parameters.Add(new SqlParameter("@pPiezasProductostr_SKU_Benavides", objInfo.PiezasProductostr_SKU_Benavides));
                        command.Parameters.Add(new SqlParameter("@pPiezasCantidad", objInfo.PiezasCantidad));
                        command.Parameters.Add(new SqlParameter("@pBeneProductostr_SKU", objInfo.BeneficioProductostr_SKU));
                        command.Parameters.Add(new SqlParameter("@pBeneProductostr_SKU_Benavides", objInfo.BeneficioProductostr_SKU_Benavides));
                        command.Parameters.Add(new SqlParameter("@pBeneCantidad", objInfo.BeneficioCantidad));
                        command.Parameters.Add(new SqlParameter("@pUserId", Membership.GetUser().ProviderUserKey.ToString()));
                        command.Parameters.Add(new SqlParameter("@pIdClub", objInfo.Id_Club));
                        command.Parameters.Add(new SqlParameter("@pEdadIni", objInfo.EdadIni));
                        command.Parameters.Add(new SqlParameter("@pEdadFin", objInfo.EdadFin));
                        command.Parameters.Add(new SqlParameter("@pBeneficioIni", objInfo.BeneficioIni));
                        command.Parameters.Add(new SqlParameter("@pBeneficioFin", objInfo.BeneficioFin));
                        command.Parameters.Add(new SqlParameter("@pFechaIni", ((DateTime)objInfo.FechaIni).ToString("dd/MM/yyyy")));
                        command.Parameters.Add(new SqlParameter("@pFechaFin", ((DateTime)objInfo.FechaFin).ToString("dd/MM/yyyy")));
                        command.Parameters.Add(new SqlParameter("@pIdPeriodo", objInfo.Id_Periodo));
                        command.Parameters.Add(new SqlParameter("@pLimte", objInfo.Limite));
                        command.Parameters.Add(new SqlParameter("@pCompraIni", objInfo.CompraIni));
                        command.Parameters.Add(new SqlParameter("@pCompraFin", objInfo.CompraFin));
                        command.Parameters.Add(new SqlParameter("@pNivel", objInfo.NivelesStr));
                        command.Parameters.Add(new SqlParameter("@pCategoriaMecanica", objInfo.id_categoriaMecanica));
                        command.Parameters.Add(new SqlParameter("@pIdTipoPrecio", objInfo.IdTipoPrecio));

                        var objReader = command.ExecuteReader();

                        while (objReader.Read())
                        {
                            Resultado = true;
                        }
                    }

                    return Resultado;
                }
                catch (SqlException sqlEx)
                {
                    throw new InvalidOperationException("No fue posible obtener la info del catalogo.", sqlEx);
                }
                finally
                {
                    cnn.Close();
                }
            }


        }


        public static bool EdicionMecanica(MecanicaConfiguracionConsulta objInfo)
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            bool Resultado = false;

            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_MECANICA_EDICION;

                        command.CommandTimeout = 0;

                        command.Parameters.Add(new SqlParameter("@pNombre", objInfo.Nombre));
                        command.Parameters.Add(new SqlParameter("@pDescripcion", objInfo.Descripcion));
                        command.Parameters.Add(new SqlParameter("@pPiezasProductostr_SKU", objInfo.PiezasProductostr_SKU));
                        command.Parameters.Add(new SqlParameter("@pPiezasProductostr_SKU_Benavides", objInfo.PiezasProductostr_SKU_Benavides));
                        command.Parameters.Add(new SqlParameter("@pPiezasCantidad", objInfo.PiezasCantidad));
                        command.Parameters.Add(new SqlParameter("@pBeneProductostr_SKU", objInfo.BeneficioProductostr_SKU));
                        command.Parameters.Add(new SqlParameter("@pBeneProductostr_SKU_Benavides", objInfo.BeneficioProductostr_SKU_Benavides));
                        command.Parameters.Add(new SqlParameter("@pBeneCantidad", objInfo.BeneficioCantidad));
                        command.Parameters.Add(new SqlParameter("@pUserId", Membership.GetUser().ProviderUserKey.ToString()));
                        command.Parameters.Add(new SqlParameter("@pFechaIni", ((DateTime)objInfo.FechaIni).ToString("dd/MM/yyyy")));
                        command.Parameters.Add(new SqlParameter("@pFechaFin", ((DateTime)objInfo.FechaFin).ToString("dd/MM/yyyy")));
                        command.Parameters.Add(new SqlParameter("@pIdMecanicaConfiguracion", objInfo.Id_MecanicaConfiguracion));
                        command.Parameters.Add(new SqlParameter("@pIdGrupoMecanica", objInfo.idGrupoMecanicaJoin));


                        var objReader = command.ExecuteReader();

                        while (objReader.Read())
                        {
                            Resultado = true;
                        }
                    }

                    return Resultado;
                }
                catch (SqlException sqlEx)
                {
                    throw new InvalidOperationException("No fue posible obtener la info del catalogo.", sqlEx);
                }
                finally
                {
                    cnn.Close();
                }
            }


        }

        /*JAS*/

        public static bool CancelaMecanicaConfiguracion(long IdMecanicaConfiguracion)
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_MECANICA_CANCELAR;

                        command.CommandTimeout = 0;

                        command.Parameters.Add(new SqlParameter("@pMecanicaConfiguracion", IdMecanicaConfiguracion));


                        var objReader = command.ExecuteReader();
                        return true;

                    }

                }
                catch (SqlException sqlEx)
                {
                    throw new InvalidOperationException("No fue posible cancelar la promocion.", sqlEx);
                }
                finally
                {
                    cnn.Close();
                }
            }


        }

        public static bool CopiaMecanica(MecanicaConfiguracionConsulta objInfo)
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            bool Resultado = false;

            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_MECANICA_COPIA;

                        command.CommandTimeout = 0;

                        command.Parameters.Add(new SqlParameter("@pNombre", objInfo.Nombre));
                        command.Parameters.Add(new SqlParameter("@pDescripcion", objInfo.Descripcion));
                        command.Parameters.Add(new SqlParameter("@pUserId", Membership.GetUser().ProviderUserKey.ToString()));
                        command.Parameters.Add(new SqlParameter("@pIdClub", objInfo.Id_Club));
                        command.Parameters.Add(new SqlParameter("@pEdadIni", objInfo.EdadIni));
                        command.Parameters.Add(new SqlParameter("@pEdadFin", objInfo.EdadFin));
                        command.Parameters.Add(new SqlParameter("@pBeneficioIni", objInfo.BeneficioIni));
                        command.Parameters.Add(new SqlParameter("@pBeneficioFin", objInfo.BeneficioFin));
                        command.Parameters.Add(new SqlParameter("@pFechaIni", ((DateTime)objInfo.FechaIni).ToString("dd/MM/yyyy")));
                        command.Parameters.Add(new SqlParameter("@pFechaFin", ((DateTime)objInfo.FechaFin).ToString("dd/MM/yyyy")));
                        command.Parameters.Add(new SqlParameter("@pIdPeriodo", objInfo.Id_Periodo));
                        command.Parameters.Add(new SqlParameter("@pLimte", objInfo.Limite));
                        command.Parameters.Add(new SqlParameter("@pCompraIni", objInfo.CompraIni));
                        command.Parameters.Add(new SqlParameter("@pCompraFin", objInfo.CompraFin));
                        command.Parameters.Add(new SqlParameter("@pNivel", objInfo.NivelesStr));
                        command.Parameters.Add(new SqlParameter("@pCategoriaMecanica", objInfo.id_categoriaMecanica));
                        command.Parameters.Add(new SqlParameter("@pIdMecanicaConfiguracion", objInfo.Id_MecanicaConfiguracion));

                        var objReader = command.ExecuteReader();

                        while (objReader.Read())
                        {
                            Resultado = true;
                        }
                    }

                    return Resultado;
                }
                catch (SqlException sqlEx)
                {
                    throw new InvalidOperationException("No fue posible obtener la info del catalogo.", sqlEx);
                }
                finally
                {
                    cnn.Close();
                }
            }


        }
    }
}
