using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Entidades;
namespace Negocio
{
    public class ValidarDatos
    {
        #region Metodos

        public static bool ValidarCotizacion(int Tarjeta)
        {
            try
            {
                bool existeCotizacion = ValidacionCotizacion.ExisteCotizacionPendiente(Tarjeta);
                return existeCotizacion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método ValidarCotizacion.", ex);
            }
        
        }

        /// <summary>
        /// Método que nos permite validar la informacion recibida de las Compras.
        /// </summary>
        /// <param name="compra">Objeto Compra con la informacion proveniente de la Cadena.</param>
        /// <returns></returns>
        public static ArrayList ValidarInformacion(Compra compra)
        {
            try
            {
                ArrayList listaValidaciones = new ArrayList();

                Validacion validacionPrograma = new Validacion();
                validacionPrograma.Nombre = "Programa";
                validacionPrograma.Tipo = "int";
                validacionPrograma.Valor = compra.Programa_intId;

                if (compra.Programa_intId > 0)
                    validacionPrograma.Valido = true;
                else
                    validacionPrograma.Valido = false;

                try
                {
                    if (validacionPrograma.Valido)
                    {
                        bool existePrograma = Programas.ExistePrograma(compra.Programa_intId);

                        if (existePrograma)
                        {
                            validacionPrograma.Existe = true;
                            validacionPrograma.Categoria = 1;
                            validacionPrograma.CodigoError = "0";
                            validacionPrograma.DescripcionError = String.Empty;
                        }
                        else
                        {
                            validacionPrograma.Existe = false;
                            validacionPrograma.Categoria = 1;
                            validacionPrograma.CodigoError = "1000";
                            validacionPrograma.DescripcionError = "Error en Programa: El Id del programa no existe o no esta registrado.";
                        }
                    }
                    else
                    {
                        validacionPrograma.Valido = false;
                        validacionPrograma.Categoria = 1;
                        validacionPrograma.CodigoError = "1001";
                        validacionPrograma.DescripcionError = "Error en Programa: El valor del programa debe ser diferente de cero.";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la validacion del campo ProgramaId.", ex);
                }

                listaValidaciones.Add(validacionPrograma);

                Validacion validacionCadena = new Validacion();
                validacionCadena.Nombre = "Cadena";
                validacionCadena.Tipo = "int";
                validacionCadena.Valor = compra.Cadena_intId;

                if (compra.Cadena_intId >= 0)
                    validacionCadena.Valido = true;
                else
                    validacionCadena.Valido = false;

                try
                {
                    if (validacionCadena.Valido)
                    {
                        bool existeCadena = true; //Cadenas.ExisteCadena(compra.Cadena_intId);

                        if (existeCadena)
                        {
                            validacionCadena.Existe = true;
                            validacionCadena.Categoria = 2;
                            validacionCadena.CodigoError = "0";
                            validacionCadena.DescripcionError = String.Empty;
                        }
                        else
                        {
                            validacionCadena.Existe = false;
                            validacionCadena.Categoria = 2;
                            validacionCadena.CodigoError = "2000";
                            validacionCadena.DescripcionError = "Error en Cadena: El Id de la Cadena no existe o no esta registrada.";
                        }
                    }
                    else
                    {
                        validacionCadena.Existe = false;
                        validacionCadena.Categoria = 2;
                        validacionCadena.CodigoError = "2001";
                        validacionCadena.DescripcionError = "Error en Cadena: El valor de la Cadena debe ser diferente de cero.";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la validacion del campo CadenaId.", ex);
                }

                listaValidaciones.Add(validacionCadena);

                Validacion validacionSucursal = new Validacion();
                validacionSucursal.Nombre = "Sucursal";
                validacionSucursal.Tipo = "int";
                validacionSucursal.Valor = compra.Sucursal_intId;

                if (compra.Sucursal_intId >= 0)
                    validacionSucursal.Valido = true;
                else
                    validacionSucursal.Valido = false;

                try
                {
                    if (validacionSucursal.Valido)
                    {
                        bool existeSucursal = true; //Sucursales.ExisteSucursal(compra.Cadena_intId, compra.Sucursal_intId);

                        if (existeSucursal)
                        {
                            validacionSucursal.Existe = true;
                            validacionSucursal.Categoria = 3;
                            validacionSucursal.CodigoError = "0";
                            validacionSucursal.DescripcionError = String.Empty;
                        }
                        else
                        {
                            validacionSucursal.Existe = false;
                            validacionSucursal.Categoria = 3;
                            validacionSucursal.CodigoError = "3000";
                            validacionSucursal.DescripcionError = "Error en Sucursal: El Id de la Sucursal no existe o no esta registrada.";
                        }
                    }
                    else
                    {
                        validacionSucursal.Existe = false;
                        validacionSucursal.Categoria = 3;
                        validacionSucursal.CodigoError = "3001";
                        validacionSucursal.DescripcionError = "Error en Sucursal: El valor de la Sucursal debe ser diferente de cero.";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la validacion del campo SucursalId.", ex);
                }

                listaValidaciones.Add(validacionSucursal);

                Validacion validacionTerminal = new Validacion();
                validacionTerminal.Nombre = "Terminal";
                validacionTerminal.Tipo = "int";
                validacionTerminal.Valor = compra.Terminal_intId;

                if (compra.Terminal_intId > 0)
                    validacionTerminal.Valido = true;
                else
                    validacionTerminal.Valido = false;

                try
                {
                    if (validacionTerminal.Valido)
                    {
                        bool existeTerminal = true;

                        if (existeTerminal)
                        {
                            validacionTerminal.Existe = true;
                            validacionTerminal.Categoria = 4;
                            validacionTerminal.CodigoError = "0";
                            validacionTerminal.DescripcionError = String.Empty;
                        }
                        else
                        {
                            validacionTerminal.Existe = false;
                            validacionTerminal.Categoria = 4;
                            validacionTerminal.CodigoError = "4000";
                            validacionTerminal.DescripcionError = "Error en Terminal: El Id de la Terminal no existe o no esta registrada.";
                        }
                    }
                    else
                    {
                        validacionTerminal.Existe = false;
                        validacionTerminal.Categoria = 4;
                        validacionTerminal.CodigoError = "4001";
                        validacionTerminal.DescripcionError = "Error en Terminal: El valor de la Terminal debe ser diferente de cero.";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la validacion del campo TerminalId.", ex);
                }

                listaValidaciones.Add(validacionTerminal);


                Validacion validacionUsuarioTicket = new Validacion();
                validacionUsuarioTicket.Nombre = "UsuarioTicket";
                validacionUsuarioTicket.Tipo = "string";
                validacionUsuarioTicket.Valor = compra.UsuarioTicket_strId;

                if (!compra.UsuarioTicket_strId.Equals(String.Empty))
                    validacionUsuarioTicket.Valido = true;
                else
                    validacionUsuarioTicket.Valido = false;

                try
                {
                    if (validacionUsuarioTicket.Valido)
                    {
                        bool existeUsuario = true;

                        if (existeUsuario)
                        {
                            validacionUsuarioTicket.Existe = true;
                            validacionUsuarioTicket.Categoria = 5;
                            validacionUsuarioTicket.CodigoError = "0";
                            validacionUsuarioTicket.DescripcionError = String.Empty;
                        }
                        else
                        {
                            validacionUsuarioTicket.Existe = false;
                            validacionUsuarioTicket.Categoria = 5;
                            validacionUsuarioTicket.CodigoError = "5000";
                            validacionUsuarioTicket.DescripcionError = "Error en Usuario: El Id del Usuario del ticket no existe o no esta registrado.";
                        }
                    }
                    else
                    {
                        validacionUsuarioTicket.Existe = false;
                        validacionUsuarioTicket.Categoria = 5;
                        validacionUsuarioTicket.CodigoError = "5001";
                        validacionUsuarioTicket.DescripcionError = "Error en Usuario: El valor del Usuario del ticket debe contener algun valor.";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la validacion del campo UsuarioIdTicket.", ex);
                }

                listaValidaciones.Add(validacionUsuarioTicket);


                Validacion validacionUsuarioCaptura = new Validacion();
                validacionUsuarioCaptura.Nombre = "UsuarioCaptura";
                validacionUsuarioCaptura.Tipo = "string";
                validacionUsuarioCaptura.Valor = compra.UsuarioCaptura_strId;

                if (!compra.UsuarioCaptura_strId.Equals(String.Empty))
                    validacionUsuarioCaptura.Valido = true;
                else
                    validacionUsuarioCaptura.Valido = false;

                try
                {
                    if (validacionUsuarioCaptura.Valido)
                    {
                        bool existeUsuario = true;

                        if (existeUsuario)
                        {
                            validacionUsuarioCaptura.Existe = true;
                            validacionUsuarioCaptura.Categoria = 6;
                            validacionUsuarioCaptura.CodigoError = "0";
                            validacionUsuarioCaptura.DescripcionError = String.Empty;
                        }
                        else
                        {
                            validacionUsuarioCaptura.Existe = false;
                            validacionUsuarioCaptura.Categoria = 6;
                            validacionUsuarioCaptura.CodigoError = "5000";
                            validacionUsuarioCaptura.DescripcionError = "Error en Usuario: El Id del Usuario de captura no existe o no esta registrado.";
                        }
                    }
                    else
                    {
                        validacionUsuarioCaptura.Existe = false;
                        validacionUsuarioCaptura.Categoria = 6;
                        validacionUsuarioCaptura.CodigoError = "5001";
                        validacionUsuarioCaptura.DescripcionError = "Error en Usuario: El valor del Usuario de captura debe contener algun valor.";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la validacion del campo UsuarioIdCaptura.", ex);
                }

                listaValidaciones.Add(validacionUsuarioCaptura);


                Validacion validacionTarjeta = new Validacion();
                validacionTarjeta.Nombre = "Tarjeta";
                validacionTarjeta.Tipo = "string";
                validacionTarjeta.Valor = compra.Tarjeta;

                if (!compra.Tarjeta.Equals(String.Empty)) //&& compra.Tarjeta.Trim().Length == 10)
                    validacionTarjeta.Valido = true;
                else
                    validacionTarjeta.Valido = false;

                try
                {
                    if (validacionTarjeta.Valido)
                    {
                        bool existeTarjeta = Tarjetas.ExisteTarjeta(compra.Tarjeta);

                        if (existeTarjeta)
                        {
                            validacionTarjeta.Existe = true;
                            validacionTarjeta.Categoria = 7;
                            validacionTarjeta.CodigoError = "0";
                            validacionTarjeta.DescripcionError = String.Empty;
                        }
                        else
                        {
                            validacionTarjeta.Existe = false;
                            validacionTarjeta.Categoria = 7;
                            validacionTarjeta.CodigoError = "6000";
                            validacionTarjeta.DescripcionError = "Error en Tarjeta: El numero de tarjeta no existe o no esta registrada.";
                        }
                    }
                    else
                    {
                        validacionTarjeta.Existe = false;
                        validacionTarjeta.Categoria = 7;
                        validacionTarjeta.CodigoError = "6001";
                        validacionTarjeta.DescripcionError = "Error en Tarjeta: El numero de tarjeta no es valido o no consta de 10 digitos.";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la validacion del campo Tarjeta.", ex);
                }

                listaValidaciones.Add(validacionTarjeta);

                ArrayList listaSKUSMedicamentos = new ArrayList();

                listaSKUSMedicamentos = Medicamentos.ObtenerListaSKUSMedicamentos();

                foreach (Pedido pedido in compra.Pedidos)
                {
                    Validacion validaPedido = new Validacion();
                    validaPedido.Nombre = "SKUMedicamento";
                    validaPedido.Tipo = "string";
                    validaPedido.Valor = pedido.SKU;
                    validaPedido.Compras = pedido.Cantidad;
                    validaPedido.DescripcionSKU = pedido.DescripcionSKU;
                    validaPedido.Beneficios = 0;

                    if (!pedido.SKU.Equals(String.Empty))
                        validaPedido.Valido = true;
                    else
                        validaPedido.Valido = false;

                    try
                    {
                        if (validaPedido.Valido)
                        {
                            //bool existeSKU = Medicamentos.ExisteMedicamento(pedido.SKU);
                            bool existeSKU = false;

                            listaSKUSMedicamentos.Sort();

                            int indice = listaSKUSMedicamentos.BinarySearch(pedido.SKU);

                            if (indice < 0)
                                existeSKU = false;
                            else
                                existeSKU = true;

                            if (existeSKU)
                            {
                                validaPedido.Existe = true;
                                validaPedido.Categoria = 8;
                                validaPedido.CodigoError = "0";
                                validaPedido.DescripcionError = String.Empty;
                            }
                            else
                            {
                                validaPedido.Existe = false;
                                validaPedido.Categoria = 8;
                                validaPedido.CodigoError = "7000";
                                validaPedido.DescripcionError = "Error en SKU Medicamento: El SKU no existe o no esta registrado.";
                            }
                        }
                        else
                        {
                            validaPedido.Existe = false;
                            validaPedido.Categoria = 8;
                            validaPedido.CodigoError = "7001";
                            validaPedido.DescripcionError = "Error en SKU: El SKU del Medicamento deber ser diferente a vacio.";
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error en la validacion del SKU: " + pedido.SKU + " .", ex);
                    }

                    listaValidaciones.Add(validaPedido);
                }

                return listaValidaciones;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Método que nos permite Obtener el listado de Errores Clave como Tarjeta, Cadena, etc.
        /// </summary>
        /// <param name="listaValidaciones"></param>
        /// <returns></returns>
        public static ArrayList ObtenerErroresClave(ArrayList listaValidaciones)
        {
            try
            {
                ArrayList listaErrores = new ArrayList();

                foreach (Validacion validacion in listaValidaciones)
                {
                    if (validacion.Categoria != 8 && !validacion.CodigoError.Equals("0"))
                    {
                        Validacion error = new Validacion();
                        error = (Validacion)validacion.Clone();
                        listaErrores.Add(error);
                    }
                }

                return listaErrores;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método ObtenerErroresClave.", ex);
            }
        }
        /// <summary>
        /// Método que nos permite Obtener los errores en el listado de pedidos.
        /// </summary>
        /// <param name="listaValidaciones"></param>
        /// <returns></returns>
        public static ArrayList ObtenerPedidosOK(ArrayList listaValidaciones)
        {
            try
            {
                ArrayList listaPedidosOK = new ArrayList();

                foreach (Validacion validacion in listaValidaciones)
                {
                    if (validacion.Categoria.Equals(8) && validacion.CodigoError.Equals("0"))
                    {
                        Validacion pedido = new Validacion();
                        pedido = (Validacion)validacion.Clone();
                        listaPedidosOK.Add(pedido);
                    }
                }

                return listaPedidosOK;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método ObtenerPedidosOK.", ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaValidaciones"></param>
        /// <returns></returns>
        public static ArrayList ObtenerDatosClave(ArrayList listaValidaciones)
        {
            try
            {
                ArrayList listaDatosClave = new ArrayList();

                foreach (Validacion validacion in listaValidaciones)
                {
                    if (validacion.Categoria != 8 && validacion.CodigoError.Equals("0"))
                    {
                        Validacion validacionDatosClave = new Validacion();
                        validacionDatosClave = (Validacion)validacion.Clone();
                        listaDatosClave.Add(validacionDatosClave);
                    }
                }

                return listaDatosClave;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método ObtenerDatosClave.", ex);
            }
        }

        #endregion Metodos
    }
}
