using System;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Data;
using System.Globalization;

using Entidades;

namespace Negocio
{
    public class Compras
    {
        #region Metodos

        /// <summary>
        /// Método que nos permite realizar el Calculo de las Compras y Beneficios los cuales son depositados en una Cotizacion.
        /// </summary>
        /// <param name="compra">Objeto Compra con todas la informacion relacionada.</param>
        /// <returns>Objeto Ticket con la informacion final de la cotizacion.</returns>
        public static Ticket ProcesarCompra(Compra compra)
        {
            try
            {
                ArrayList listaValidaciones = new ArrayList();
                ArrayList listaErroresClave = new ArrayList();
                ArrayList listaErroresPedidos = new ArrayList();
                ArrayList listaDatosClave = new ArrayList();
                ArrayList listaPedidosOK = new ArrayList();
                Ticket ticket = new Ticket();
                int tipoCorteMensual = int.Parse( ConfigurationManager.AppSettings["tipoCorteMensual"].ToString());

                //bool bContinuar = ValidarDatos.ValidarCotizacion(Int32.Parse(compra.Tarjeta));
                
                //if (!bContinuar)
                //{
                listaValidaciones = ValidarDatos.ValidarInformacion(compra);
                listaErroresClave = ValidarDatos.ObtenerErroresClave(listaValidaciones);
                listaPedidosOK = ValidarDatos.ObtenerPedidosOK(listaValidaciones);

                if (listaErroresClave.Count > 0)
                {
                    ticket = Tickets.ObtenerEncabezadoTicket(listaValidaciones);
                    ticket = Tickets.ObtenerFolios(listaValidaciones, ticket);

                    ticket.CotizacionId = "0";

                    ticket.NumeroCamposEncabezado = 7;
                    ticket.NumeroCorrectosEncabezado = 7 - listaErroresClave.Count;
                    ticket.NumeroErroresEncabezado = listaErroresClave.Count;

                    ticket.NumerodePedidos = compra.Pedidos.Length;
                    ticket.NumeroCorrectoPedidos = listaPedidosOK.Count;
                    ticket.NumeroErronesPedidos = compra.Pedidos.Length - listaPedidosOK.Count;

                    return ticket;
                }
                else
                {
                    listaDatosClave = ValidarDatos.ObtenerDatosClave(listaValidaciones);

                    if (listaPedidosOK.Count > 0)
                    {
                        listaDatosClave.AddRange(listaPedidosOK);

                        Compra compraFinal = GenerarCompraFinal(listaDatosClave);
                        string detalleCompra = ParsearInformacionCompra(compraFinal.Pedidos);

                        DataSet dsCompra = Transaccion.GenerarCotizacion(compraFinal.Tarjeta, compraFinal.Cadena_intId, compraFinal.Programa_intId, compraFinal.Sucursal_intId, compraFinal.Terminal_intId, compraFinal.UsuarioTicket_strId, compraFinal.UsuarioCaptura_strId, tipoCorteMensual, detalleCompra);

                        string numeroCotizacion = dsCompra.Tables[0].Rows[0]["NoCotizacion"].ToString();

                        DataSet dsCotizacion = Transaccion.ObtenerCotizacion(numeroCotizacion);

                        if (dsCotizacion.Tables[0].Rows.Count > 0)
                        {
                            ArrayList listaCotizaciones = new ArrayList();
                            listaCotizaciones = ObtenerCotizaciones(dsCotizacion.Tables[0]);

                            ticket = Tickets.ObtenerEncabezadoTicket(listaValidaciones);
                            ticket = Tickets.ObtenerFolios(listaValidaciones, ticket);

                            ticket = ResetearFoliosTickets(ticket, listaCotizaciones);

                            ticket.CotizacionId = numeroCotizacion;
                        }
                        else
                        {
                            ticket.CotizacionId = "0";
                        }

                        ticket.NumeroCamposEncabezado = 7;
                        ticket.NumeroCorrectosEncabezado = 7 - listaErroresClave.Count;
                        ticket.NumeroErroresEncabezado = listaErroresClave.Count;

                        ticket.NumerodePedidos = compra.Pedidos.Length;
                        ticket.NumeroCorrectoPedidos = listaPedidosOK.Count;
                        ticket.NumeroErronesPedidos = compra.Pedidos.Length - listaPedidosOK.Count;

                        return ticket;
                    }
                    else
                    {
                        ticket = Tickets.ObtenerEncabezadoTicket(listaValidaciones);
                        ticket = Tickets.ObtenerFolios(listaValidaciones, ticket);

                        ticket.CotizacionId = "0";

                        ticket.NumeroCamposEncabezado = 7;
                        ticket.NumeroCorrectosEncabezado = 7 - listaErroresClave.Count;
                        ticket.NumeroErroresEncabezado = listaErroresClave.Count;

                        ticket.NumerodePedidos = compra.Pedidos.Length;
                        ticket.NumeroCorrectoPedidos = listaPedidosOK.Count;
                        ticket.NumeroErronesPedidos = compra.Pedidos.Length - listaPedidosOK.Count;

                        return ticket;
                    }
                }
                //}
                //else
                //{
                //    ticket.Programa_intId = compra.Programa_intId;
                //    ticket.Cadena_intId = compra.Cadena_intId;
                //    ticket.Sucursal_intId = compra.Sucursal_intId;
                //    ticket.Terminal_intId = compra.Terminal_intId;
                //    ticket.Usuario_strId = compra.Usuario_strId;
                //    ticket.Tarjeta = compra.Tarjeta;
                //    ticket.CodigoExcepcion = 5; 
                //    ticket.DescripcionExcepcion = "Existe una cotizacion pendiente por cerrar.";

                //    return ticket;  
                     
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método ProcesarCompra.", ex);
            }
        }
        /// <summary>
        /// Método que nos permite generar el objeto Compra Final, el cual va a ser procesado como una Cotizacion.
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        private static Compra GenerarCompraFinal(ArrayList lista)
        {
            try
            {
                Compra compraFinal = new Compra();
                ArrayList listaPedidos = new ArrayList();

                foreach (Validacion validacion in lista)
                {
                    switch (validacion.Categoria)
                    { 
                        case 1:
                            compraFinal.Programa_intId = (int)validacion.Valor;
                            break;
                        case 2:
                            compraFinal.Cadena_intId = (int)validacion.Valor;
                            break;
                        case 3:
                            compraFinal.Sucursal_intId = (int)validacion.Valor;
                            break;
                        case 4:
                            compraFinal.Terminal_intId = (int)validacion.Valor;
                            break;
                        case 5:
                            compraFinal.UsuarioTicket_strId = validacion.Valor.ToString();
                            break;
                        case 6:
                            compraFinal.UsuarioCaptura_strId = validacion.Valor.ToString();
                            break;
                        case 7:
                            compraFinal.Tarjeta = validacion.Valor.ToString();
                            break;
                        default:
                            Pedido pedido = new Pedido();
                            pedido.SKU = validacion.Valor.ToString();
                            pedido.Cantidad = validacion.Compras;
                            pedido.DescripcionSKU = validacion.DescripcionSKU.ToString();
                            listaPedidos.Add(pedido);
                            break;
                    }
                }

                compraFinal.Pedidos = (Pedido[])listaPedidos.ToArray(typeof(Pedido));

                return compraFinal;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método GenerarCompraFinal", ex);
            }
        }
        /// <summary>
        /// Método que nos permite Generar los Tickets XML.
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        private static string ParsearInformacionCompra(Pedido[] pedidos)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                ArrayList listaCompras = new ArrayList();
                string dobleMec = ConfigurationManager.AppSettings["dobleMec"].ToString();

                listaCompras.AddRange(pedidos);

                sb.Append("<TicketXML>");

                foreach (Pedido pedido in listaCompras)
                {
                    sb.Append("<id>");
                    sb.Append("<SKU>");
                    sb.Append(pedido.SKU);
                    sb.Append("</SKU>");
                    sb.Append("<Cantidad>");
                    sb.Append(pedido.Cantidad);
                    sb.Append("</Cantidad>");
                    sb.Append("<DobleMec>");
                    sb.Append(dobleMec);
                    sb.Append("</DobleMec>");
                    sb.Append("</id>");
                }

                sb.Append("</TicketXML>");

                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método ParsearInformacionCompra", ex);
            }
        }
        /// <summary>
        /// Método que nos permite obtener el resultado de todas las Cotizaciones efectuadas.
        /// </summary>
        /// <param name="tablaCotizaciones"></param>
        /// <returns></returns>
        private static ArrayList ObtenerCotizaciones(DataTable tablaCotizaciones)
        {
            try
            {
                ArrayList listaCotizaciones = new ArrayList();

                foreach (DataRow row in tablaCotizaciones.Rows)
                {
                    Cotizacion cotizacion = new Cotizacion();
                    cotizacion = ConvertirCotizacion(row);

                    listaCotizaciones.Add(cotizacion);
                }

                return listaCotizaciones;

            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método ObtenerCotizaciones PRUEBA " + ex, ex);
            }
        }
        /// <summary>
        /// Método que nos permite obtener un objeto Cotizacion en base a un DataRow.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static Cotizacion ConvertirCotizacion(DataRow row)
        {
            try
            {
                Cotizacion cotizacion = new Cotizacion();

                cotizacion.ID = int.Parse(row["Cotizacion_intID"].ToString());
                cotizacion.CotizacionId = row["Cotizacion_strCotizacion"].ToString();
                cotizacion.TarjetaC_strNumero = row["Tarjeta_strNumero"].ToString();
                cotizacion.Presentacion_intSKU = row["Presentacion_intSKU"].ToString();
                cotizacion.Mecanica_strEAN13Obsequio = row["Presentacion_intSKUBeneficio"].ToString();
                //cotizacion.DobleMec = bool.Parse(row["DobleMec"].ToString());
                cotizacion.CompraAcumulada = int.Parse(row["Cotizacion_intCompraAcumulada"].ToString());
                cotizacion.BeneficioAcumulado = int.Parse(row["Cotizacion_intBeneficioAcumulado"].ToString());
                cotizacion.BeneficioMesActual = int.Parse(row["Cotizacion_intBeneficioMesActual"].ToString());
                cotizacion.EstaCompra = int.Parse(row["Cotizacion_intEstaCompra"].ToString());
                cotizacion.MecanicaCompra = int.Parse(row["Presentacion_intCantidadCompra"].ToString());
                cotizacion.MecanicaRegalo = int.Parse(row["Presentacion_intCantidadBeneficio"].ToString());
                cotizacion.TotalAnalizar = int.Parse(row["Cotizacion_intTotalAnalizar"].ToString());
                cotizacion.BeneficiosGanados = int.Parse(row["Cotizacion_intBeneficiosGanados"].ToString());
                cotizacion.BeneficiosDeberiaTener = int.Parse(row["Cotizacion_intBeneficiosDeberiaTener"].ToString());
                cotizacion.LimiteMensual = int.Parse(row["Presentacion_intLimiteMensual"].ToString());
                cotizacion.BeneficiosOtorgar = int.Parse(row["Cotizacion_intBeneficiosOtorgar"].ToString());
                cotizacion.Compras = int.Parse(row["Cotizacion_intCompras"].ToString());
                cotizacion.Sugerido = int.Parse(row["Cotizacion_intSugerido"].ToString());
                //IFormatProvider culture = new CultureInfo("es-MX", true);
                //cotizacion.Fecha = DateTime.Parse(row["Fecha"].ToString());//, culture, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
                cotizacion.Fecha = Convert.ToDateTime(row["Cotizacion_dateFechaCotizacion"]);
                cotizacion.Estatus = int.Parse(row["Estatus_intClave"].ToString());

                return cotizacion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método ConvertirCotizacion", ex);
            }
        }
        /// <summary>
        /// Método que nos permite actualizar los valores de cada Folio generado mediante la Cotizacion.
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="listadoCotizaciones"></param>
        /// <returns></returns>
        private static Ticket ResetearFoliosTickets(Ticket ticket, ArrayList listadoCotizaciones)
        {
            try
            {
                foreach (Folio folio in ticket.Folios)
                {
                    foreach (Cotizacion cotizacion in listadoCotizaciones)
                    {
                        if (folio.SKU.Equals(cotizacion.Presentacion_intSKU))
                        {
                            folio.Compras = cotizacion.Compras;
                            folio.Beneficios = cotizacion.BeneficiosOtorgar;
                            folio.Sugeridos = cotizacion.Sugerido;
                        }
                    }
                }

                return ticket;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método ResetearFoliosTickets", ex);
            }
        }
        /// <summary>
        /// Método que nos permite cerrar una Compra en base al numero de cotizacion y numero de tarjeta que se encuentran en el objeto Token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Comprobante CerrarCompra(Token token)
        {
            //try
            //{
                Comprobante comprobante = new Comprobante();
            //    int status = 0;

            //    DataSet dsCotizacion = Transaccion.ObtenerCotizacion(token.CotizacionId);

            //    if (dsCotizacion.Tables[0].Rows.Count > 0)
            //    {
            //        status = int.Parse(dsCotizacion.Tables[0].Rows[0]["Estatus_intClave"].ToString());

            //        if (status.Equals(0))
            //        {
            //            string sku = dsCotizacion.Tables[0].Rows[0]["Presentacion_intSKU"].ToString();
            //            int cantidad = int.Parse(dsCotizacion.Tables[0].Rows[0]["Cotizacion_intBeneficiosOtorgar"].ToString());
            //            string detalleCerrarCompra = ParsearInformacionCerrarCompra(sku, cantidad);

            //            DataSet dsCerrarCompra = Transaccion.CerrarCotizacion(token.CotizacionId, token.Tarjeta, detalleCerrarCompra);

            //            //string llave = dsCerrarCompra.Tables[0].Rows[0]["llave"].ToString();

            //            //if (llave.Equals(String.Empty) && llave.Equals("0"))
            //            //{
            //            //    comprobante.CodigoError = "1";
            //            //    comprobante.DescripcionError = "El cierre de la Compra no puedo realizarse.";
            //            //    comprobante.Tarjeta = token.Tarjeta;
            //            //    comprobante.Llave = llave;
            //            //}
            //            //else
            //            //{
            //            comprobante.CodigoError = "0";
            //            comprobante.DescripcionError = "Transacción Registrada Correctamente"; //String.Empty;
            //            comprobante.Tarjeta = token.Tarjeta;
            //            //comprobante.Llave = llave;
            //            //}
            //        }
            //        else if (status.Equals(1))
            //        {
            //            comprobante.CodigoError = "1";
            //            comprobante.DescripcionError = "Error al Cerrar Compra. La Cotizacion enviada se encuentra Cerrada...";
            //            comprobante.Tarjeta = token.Tarjeta;
            //            comprobante.Llave = "0";
            //        }
            //        else if (status.Equals(2))
            //        {
            //            comprobante.CodigoError = "1";
            //            comprobante.DescripcionError = "Error al Cerrar Compra. La Cotizacion enviada se encuentra Cancelada...";
            //            comprobante.Tarjeta = token.Tarjeta;
            //            comprobante.Llave = "0";
            //        }
            //    }
            //    else
            //    {
            //        comprobante.CodigoError = "1";
            //        comprobante.DescripcionError = "Error al Cerrar Compra. La Cotizacion enviada no existe...";
            //        comprobante.Tarjeta = token.Tarjeta;
            //        comprobante.Llave = "0";
            //    }

            //    return comprobante;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error en el Método CerrarCompra.", ex);
            //}
                return comprobante; 
        }

        /// <summary>
        /// Método que nos permite Generar los Tickets XML.
        /// </summary>
        /// <param name="pedidos"></param>
        /// <returns></returns>
        private static string ParsearInformacionCerrarCompra(string sku, int cantidad)
        {
            try
            {
                string CadenaXML;

                CadenaXML = "<ListaBeneficios>";
                //CadenaXML += "<Pagina_intClave>" + txtPagina_intClave.Text + "</Pagina_intClave>";
                CadenaXML += "<SKU>" + sku + "</SKU>";
                CadenaXML += "<Cantidad>" + cantidad + "</Cantidad>";
                CadenaXML += "</ListaBeneficios>";

                return CadenaXML;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método ParsearInformacionCerrarCompra", ex);
            }
        }

        /// <summary>
        /// Método que nos permite realizar la Cancelacion de una Compra en base a su numero de Cotizacion.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Comprobante CancelarCompra(Token token)
        {
            try
            {
                Comprobante comprobante = new Comprobante();
                int status = 0;

                DataSet dsCotizacion = Transaccion.ObtenerCotizacion(token.CotizacionId);

                if (dsCotizacion.Tables[0].Rows.Count > 0)
                {
                    status = int.Parse(dsCotizacion.Tables[0].Rows[0]["Estatus"].ToString());

                    if (status.Equals(0))
                    {
                        DataSet dsCancelarCompra = Transaccion.CancelarCotizacion(token.CotizacionId, token.Tarjeta);

                        string llave = dsCancelarCompra.Tables[0].Rows[0]["llave"].ToString();

                        if (llave.Equals(String.Empty) && llave.Equals("0"))
                        {
                            comprobante.CodigoError = "1";
                            comprobante.DescripcionError = "La Cancelacion de la Compra no puedo realizarse.";
                            comprobante.Tarjeta = token.Tarjeta;
                            comprobante.Llave = "0";
                        }
                        else
                        {
                            comprobante.CodigoError = "0";
                            comprobante.DescripcionError = String.Empty;
                            comprobante.Tarjeta = token.Tarjeta;
                            comprobante.Llave = llave;
                        }
                    }
                    else if (status.Equals(1))
                    {
                        comprobante.CodigoError = "1";
                        comprobante.DescripcionError = "Error al Cancelar Compra. La Cotizacion enviada se encuentra Cerrada...";
                        comprobante.Tarjeta = token.Tarjeta;
                        comprobante.Llave = "0";
                    }
                    else if (status.Equals(2))
                    {
                        comprobante.CodigoError = "1";
                        comprobante.DescripcionError = "Error al Cancelar Compra. La Cotizacion enviada se encuentra Cancelada...";
                        comprobante.Tarjeta = token.Tarjeta;
                        comprobante.Llave = "0";
                    }
                }
                else
                {
                    comprobante.CodigoError = "1";
                    comprobante.DescripcionError = "Error al Cancelar Compra. La Cotizacion enviada no existe...";
                    comprobante.Tarjeta = token.Tarjeta;
                    comprobante.Llave = "0";
                }

                return comprobante;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método CancelarCompra.", ex);
            }
        }
        public static DataSet MetodoProcesarCompra(CompraNew compra)
        {
            try
            {
                CompraNew compraNew = new CompraNew();
                Transaccion tran = new Transaccion();
                DataSet dsCompra = tran.ProcesarCompraReglasDNegocio(compraNew.ProgramaID, compraNew.Llave, compraNew.Programa_intId, compraNew.Cadena_intId, compraNew.Sucursal_intId, compraNew.Terminal_intId, compraNew.UsuarioTicket_strId, compraNew.UsuarioCaptura_strId, compraNew.Tarjeta);                
                return dsCompra;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método ProcesarCompra.", ex);
            }
        }

        public static DataSet MetodoCerrarCompra(CompraNew compra, TokenNew token)
        {
            try
            {
                CompraNew compraNew = new CompraNew();
                Transaccion tran = new Transaccion();               
                //int Cantidad=0;
                DataSet dsCompra = tran.CerrarCompraReglasDNegocio(compra.ProgramaID, compra.Llave, token.CotizacionId, compra.Tarjeta,token.NoTicket, token.FechaTicket, token.SKU, token.Cantidad);                
                return dsCompra;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método CerrarCompra.", ex);
            }
        }

        public static DataSet MetodoCancelarCompra(CompraNew compra, TokenNew token)
        {
            try
            {
                CompraNew compraNew = new CompraNew();
                Transaccion tran = new Transaccion();
                //int Cantidad = 0;
                DataSet dsCompra = tran.CancelarCompraReglasDNegocio(compra.ProgramaID, compra.Llave, token.CotizacionId, token.Tarjeta);
                return dsCompra;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método CancelarCompra.", ex);
            }
        }

        public static DataSet MetodoConsultaTarjeta(consultaTarjeta tarjeta)
        {
            try
            {
                CompraNew compraNew = new CompraNew();
                Transaccion tran = new Transaccion();
                //int Cantidad = 0;
                DataSet dsCompra = tran.ConsultaTarjetaReglasDNegocio(tarjeta.ProgramaID, tarjeta.Llave, tarjeta.Tarjeta);
                return dsCompra;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método CancelarCompra.", ex);
            }
        }

        public static DataSet MetodoActivarTarjeta(consultaTarjeta tarjeta,Cliente cliente)
        {
            try
            {
                CompraNew compraNew = new CompraNew();
                Transaccion tran = new Transaccion();
                //int Cantidad = 0;
                DataSet dsCompra = tran.ActivarTarjetaReglasDNegocio(tarjeta.ProgramaID, tarjeta.Llave, tarjeta.Tarjeta, cliente.ApellidoP, cliente.ApellidoM, cliente.Nombre, "nacionalidad", cliente.Cedula, "loctelefono", cliente.Telefono, "sku", "presentacion", "producto", "notas");
                return dsCompra;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método CancelarCompra.", ex);
            }
        }

        public static DataSet MetodoMaestroSucursales(string ProgramaID, string Llave)
        {
            try
            {
                CompraNew compraNew = new CompraNew();
                Transaccion tran = new Transaccion();
                //int Cantidad = 0;
                DataSet dsCompra = tran.MaestroSucursalesReglasDNegocio(ProgramaID, Llave);
                return dsCompra;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método CancelarCompra.", ex);
            }
        }

        public static DataSet MetodoMaestroProductos(string ProgramaID, string Llave)
        {
            try
            {
                CompraNew compraNew = new CompraNew();
                Transaccion tran = new Transaccion();
                //int Cantidad = 0;
                DataSet dsCompra = tran.MaestroSucursalesReglasDNegocio(ProgramaID, Llave);
                return dsCompra;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Método CancelarCompra.", ex);
            }
        }


        #endregion Metodos
    }
}
