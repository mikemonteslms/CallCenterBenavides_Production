using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CallCenterDB;
using ORMModel;
using Entidades;
using Datos;

namespace CNegocio
{
    public class BLMecanica
    {
        #region Alta Mecanicas

        public static bool AltaMecanica_LM(MecanicaConfiguracionConsulta infoMecanica)
        {
            bool Resultado = false;
            try
            {
                string strNiveles = string.Empty;
                foreach (Nivel Niv in infoMecanica.Niveles)
                {
                    if (strNiveles != string.Empty)
                    {
                        strNiveles = strNiveles + ",";
                    }
                    strNiveles = strNiveles + Niv.IdNivel.ToString();
                }

                infoMecanica.NivelesStr = strNiveles;

                infoMecanica.UserId = "1";
                foreach (ProductoSeleccionado ProdSel in infoMecanica.PiezasLM)
                {
                    int CantidadPiezas = 0;
                    if (int.TryParse(ProdSel.Cantidad, out CantidadPiezas))
                    {
                        foreach (ORMModel.Presentacion PresSel in ProdSel.Productos)
                        {
                            long IdPresentacion = 0;
                            if (long.TryParse(PresSel.IdProd, out IdPresentacion))
                            {
                                ProductoM obj = BLMecanica.ObtenerListaProductoXId(IdPresentacion)[0];
                                infoMecanica.PiezasProductostr_SKU = obj.SKU;
                                infoMecanica.PiezasProductostr_SKU_Benavides = obj.SKU_Benavides;
                                infoMecanica.PiezasCantidad = ProdSel.Cantidad;

                                infoMecanica.BeneficioProductostr_SKU = obj.SKU;
                                infoMecanica.BeneficioProductostr_SKU_Benavides = obj.SKU_Benavides;
                                infoMecanica.BeneficioCantidad = ProdSel.CantidadBeneficio;

                                DLMecanica.AltaMecanica(infoMecanica);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Resultado;
        }

        public static bool AltaMecanica_Lista(MecanicaConfiguracionConsulta infoMecanica)
        {
            bool Resultado = false;
            try
            {
                string strNiveles = string.Empty;
                foreach (Nivel Niv in infoMecanica.Niveles)
                {
                    if (strNiveles != string.Empty)
                    {
                        strNiveles = strNiveles + ",";
                    }
                    strNiveles = strNiveles + Niv.IdNivel.ToString();
                }

                infoMecanica.NivelesStr = strNiveles;

                infoMecanica.UserId = "1";
                bool PRIMERO = true;
                /*Piezas*/
                foreach (ProductoSeleccionadoLista ProdSel in infoMecanica.PiezasLista)
                {
                    int CantidadPiezas = 0;
                    if (int.TryParse(ProdSel.Cantidad, out CantidadPiezas))
                    {
                        long IdPresentacion = 0;
                        if (long.TryParse(ProdSel.IdProducto, out IdPresentacion))
                        {
                            ProductoM obj = BLMecanica.ObtenerListaProductoXId(IdPresentacion)[0];
                            infoMecanica.PiezasProductostr_SKU += (PRIMERO ? "" : ",") + obj.SKU;
                            infoMecanica.PiezasProductostr_SKU_Benavides += (PRIMERO ? "" : ",") + obj.SKU_Benavides;
                            infoMecanica.PiezasCantidad += (PRIMERO ? "" : ",") + ProdSel.Cantidad;
                            PRIMERO = false;
                        }
                    }
                }
                PRIMERO = true;
                /*Beneficio*/
                foreach (ProductoSeleccionadoLista ProdSel in infoMecanica.BeneficioLista)
                {
                    int CantidadPiezas = 0;
                    if (int.TryParse(ProdSel.Cantidad, out CantidadPiezas))
                    {
                        long IdPresentacion = 0;
                        if (long.TryParse(ProdSel.IdProducto, out IdPresentacion))
                        {
                            ProductoM obj = BLMecanica.ObtenerListaProductoXId(IdPresentacion)[0];
                            infoMecanica.BeneficioProductostr_SKU += (PRIMERO ? "" : ",") + obj.SKU;
                            infoMecanica.BeneficioProductostr_SKU_Benavides += (PRIMERO ? "" : ",") + obj.SKU_Benavides;
                            infoMecanica.BeneficioCantidad += (PRIMERO ? "" : ",") + ProdSel.Cantidad;
                            PRIMERO = false;
                        }
                    }
                }

                DLMecanica.AltaMecanica(infoMecanica);
            }
            catch (Exception)
            {

                throw;
            }

            return Resultado;
        }

        public static bool AltaMecanica_Combo(MecanicaConfiguracionConsulta infoMecanica)
        {
            bool Resultado = false;
            try
            {
                string strNiveles = string.Empty;
                foreach (Nivel Niv in infoMecanica.Niveles)
                {
                    if (strNiveles != string.Empty)
                    {
                        strNiveles = strNiveles + ",";
                    }
                    strNiveles = strNiveles + Niv.IdNivel.ToString();
                }

                infoMecanica.NivelesStr = strNiveles;

                infoMecanica.UserId = "1";
                bool PRIMERO = true;
                /*Piezas*/
                foreach (ProductoSeleccionadoLista ProdSel in infoMecanica.PiezasLista)
                {
                    int CantidadPiezas = 0;
                    if (int.TryParse(ProdSel.Cantidad, out CantidadPiezas))
                    {
                        long IdPresentacion = 0;
                        if (long.TryParse(ProdSel.IdProducto, out IdPresentacion))
                        {
                            ProductoM obj = BLMecanica.ObtenerListaProductoXId(IdPresentacion)[0];
                            infoMecanica.PiezasProductostr_SKU += (PRIMERO ? "" : ",") + obj.SKU;
                            infoMecanica.PiezasProductostr_SKU_Benavides += (PRIMERO ? "" : ",") + obj.SKU_Benavides;
                            infoMecanica.PiezasCantidad += (PRIMERO ? ProdSel.Cantidad : ",0");
                            PRIMERO = false;
                        }
                    }
                }
                PRIMERO = true;
                /*Beneficio*/
                foreach (ProductoSeleccionadoLista ProdSel in infoMecanica.BeneficioLista)
                {
                    int CantidadPiezas = 0;
                    if (int.TryParse(ProdSel.Cantidad, out CantidadPiezas))
                    {
                        long IdPresentacion = 0;
                        if (long.TryParse(ProdSel.IdProducto, out IdPresentacion))
                        {
                            ProductoM obj = BLMecanica.ObtenerListaProductoXId(IdPresentacion)[0];
                            infoMecanica.BeneficioProductostr_SKU += (PRIMERO ? "" : ",") + obj.SKU;
                            infoMecanica.BeneficioProductostr_SKU_Benavides += (PRIMERO ? "" : ",") + obj.SKU_Benavides;
                            infoMecanica.BeneficioCantidad += (PRIMERO ? "" : ",") + ProdSel.Cantidad;
                            PRIMERO = false;
                        }
                    }
                }

                DLMecanica.AltaMecanica(infoMecanica);
            }
            catch (Exception)
            {

                throw;
            }

            return Resultado;
        }

        public static bool AltaMecanica_ComboLN_LM(MecanicaConfiguracionConsulta infoMecanica)
        {
            bool Resultado = false;
            try
            {
                string strNiveles = string.Empty;
                foreach (Nivel Niv in infoMecanica.Niveles)
                {
                    if (strNiveles != string.Empty)
                    {
                        strNiveles = strNiveles + ",";
                    }
                    strNiveles = strNiveles + Niv.IdNivel.ToString();
                }

                infoMecanica.NivelesStr = strNiveles;

                infoMecanica.UserId = "1";
                bool PRIMERO = true;
                /*Piezas*/
                foreach (ProductoSeleccionadoLista ProdSel in infoMecanica.PiezasLista)
                {
                    int CantidadPiezas = 0;
                    if (int.TryParse(ProdSel.Cantidad, out CantidadPiezas))
                    {
                        long IdPresentacion = 0;
                        if (long.TryParse(ProdSel.IdProducto, out IdPresentacion))
                        {
                            ProductoM obj = BLMecanica.ObtenerListaProductoXId(IdPresentacion)[0];
                            infoMecanica.PiezasProductostr_SKU += (PRIMERO ? "" : ",") + obj.SKU;
                            infoMecanica.PiezasProductostr_SKU_Benavides += (PRIMERO ? "" : ",") + obj.SKU_Benavides;
                            infoMecanica.PiezasCantidad += (PRIMERO ? ProdSel.Cantidad : ",0");
                            PRIMERO = false;
                        }
                    }
                }
                PRIMERO = true;
                /*Beneficio*/
                foreach (ProductoSeleccionadoLista ProdSel in infoMecanica.BeneficioLista)
                {
                    int CantidadPiezas = 0;
                    if (int.TryParse(ProdSel.Cantidad, out CantidadPiezas))
                    {
                        long IdPresentacion = 0;
                        if (long.TryParse(ProdSel.IdProducto, out IdPresentacion))
                        {
                            ProductoM obj = BLMecanica.ObtenerListaProductoXId(IdPresentacion)[0];
                            infoMecanica.BeneficioProductostr_SKU += (PRIMERO ? "" : ",") + obj.SKU;
                            infoMecanica.BeneficioProductostr_SKU_Benavides += (PRIMERO ? "" : ",") + obj.SKU_Benavides;
                            infoMecanica.BeneficioCantidad += (PRIMERO ? ProdSel.Cantidad : ",0");
                            PRIMERO = false;
                        }
                    }
                }

                DLMecanica.AltaMecanica(infoMecanica);
            }
            catch (Exception)
            {

                throw;
            }

            return Resultado;
        }

        #endregion

        #region Edicion Mecanica

        public static bool EdicionMecanica_LM(MecanicaConfiguracionConsulta infoMecanica)
        {
            bool Resultado = false;
            try
            {

                infoMecanica.UserId = "1";
                bool PRIMERO = true;
                /*Piezas*/
                foreach (ProductoSeleccionadoLista ProdSel in infoMecanica.PiezasLista)
                {
                    int CantidadPiezas = 0;
                    if (int.TryParse(ProdSel.Cantidad, out CantidadPiezas))
                    {

                        infoMecanica.PiezasProductostr_SKU += (PRIMERO ? "" : ",") + ProdSel.CodigoBarras;
                        infoMecanica.PiezasProductostr_SKU_Benavides += (PRIMERO ? "" : ",") + ProdSel.IdCodigoInterno;
                        infoMecanica.PiezasCantidad += (PRIMERO ? "" : ",") + ProdSel.Cantidad;
                        PRIMERO = false;

                    }
                }
                PRIMERO = true;
                /*Beneficio*/
                foreach (ProductoSeleccionadoLista ProdSel in infoMecanica.BeneficioLista)
                {
                    int CantidadPiezas = 0;
                    if (int.TryParse(ProdSel.Cantidad, out CantidadPiezas))
                    {
                        infoMecanica.BeneficioProductostr_SKU += (PRIMERO ? "" : ",") + ProdSel.CodigoBarras;
                        infoMecanica.BeneficioProductostr_SKU_Benavides += (PRIMERO ? "" : ",") + ProdSel.IdCodigoInterno;
                        infoMecanica.BeneficioCantidad += (PRIMERO ? "" : ",") + ProdSel.Cantidad;
                        PRIMERO = false;
                    }
                }

                DLMecanica.EdicionMecanica(infoMecanica);
            }
            catch (Exception)
            {

                throw;
            }

            return Resultado;
        }

        #endregion

        public static List<MecanicaConfiguracionConsulta> ObtenerLista(MecanicaConfiguracionConsulta obj)
        {
            List<MecanicaConfiguracionConsulta> lstDatos = new List<MecanicaConfiguracionConsulta>();
            try
            {

                if (obj.Limite == 0)
                {
                    obj.Limite = -1;
                }
                if (obj.Niveles.Count == 0)
                {
                    obj.Niveles.Add(new Nivel() { IdNivel = -1, Descripcion = "" });
                }
                if (obj.FechaFin <= DateTime.MinValue)
                {
                    obj.FechaFin = null;
                }

                foreach (Nivel nivel in obj.Niveles)
                {
                    obj.Id_Nivel = nivel.IdNivel;
                    lstDatos.AddRange(DLMecanica.ObtenerLista(obj));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }

        public static MecanicaConfiguracionConsulta ObtenerDetalle(long IdMecanicaConfiguracion, int IdNivel)
        {
            MecanicaConfiguracionConsulta Datos = new MecanicaConfiguracionConsulta();
            try
            {

                Datos = DLMecanica.ObtenerDetalle(IdMecanicaConfiguracion, IdNivel);

            }
            catch (Exception)
            {
                throw;
            }

            return Datos;
        }


        public static List<ProductoCategoria> ObtenerListaProductoCategoria(string Descripcion)
        {
            List<ProductoCategoria> lstDatos = new List<ProductoCategoria>();
            try
            {
                lstDatos = DLMecanica.ObtenerListaCategorias(Descripcion);
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }


        public static List<ProductoM> ObtenerListaProducto(int idCategoria)
        {
            List<ProductoM> lstDatos = new List<ProductoM>();
            try
            {
                lstDatos = DLMecanica.ObtenerListaProductos(idCategoria, -1);
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }

        public static List<ProductoM> ObtenerListaProductoXId(long idProducto)
        {
            List<ProductoM> lstDatos = new List<ProductoM>();
            try
            {
                lstDatos = DLMecanica.ObtenerListaProductos(-1, idProducto);
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }

        /* Jasb */
        public static bool CancelarMecanica(long IdMecanicaConfiguracion)
        {
            try
            {

                return DLMecanica.CancelaMecanicaConfiguracion(IdMecanicaConfiguracion);

            }
            catch (Exception)
            {
                throw;
            }

        }


        public static bool CopiarMecanica(MecanicaConfiguracionConsulta infoMecanica)
        {
            //bool Resultado = false;
            try
            {
                string strNiveles = string.Empty;
                foreach (Nivel Niv in infoMecanica.Niveles)
                {
                    if (strNiveles != string.Empty)
                    {
                        strNiveles = strNiveles + ",";
                    }
                    strNiveles = strNiveles + Niv.IdNivel.ToString();
                }

                infoMecanica.NivelesStr = strNiveles;

                infoMecanica.UserId = "1";

                return DLMecanica.CopiaMecanica(infoMecanica);

            }
            catch (Exception)
            {

                throw;
            }

            //return Resultado;
        }

    }
}
