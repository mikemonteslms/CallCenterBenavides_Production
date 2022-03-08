using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Entidades;
namespace Negocio
{
    public class Excepciones
    {
        #region Metodos

        /// <summary>
        /// Método que nos permite generar un Ticket especial cuando ocurre un error.
        /// </summary>
        /// <param name="compra"></param>
        /// <returns></returns>
        public static Ticket GenerarTicketExcepcion(Compra compra, Exception e)
        {
            try
            {
                Ticket ticket = new Ticket();
                ArrayList listaFolios = new ArrayList();

                ticket.Programa_intId = compra.Programa_intId;
                ticket.Cadena_intId = compra.Cadena_intId;
                ticket.Sucursal_intId = compra.Sucursal_intId;
                ticket.Terminal_intId = compra.Terminal_intId;
                ticket.UsuarioTicket_strId = compra.UsuarioTicket_strId;
                ticket.UsuarioCaptura_strId = compra.UsuarioCaptura_strId;
                ticket.Tarjeta = compra.Tarjeta;

                foreach (Pedido pedido in compra.Pedidos)
                {
                    Folio folio = new Folio();
                    folio.SKU = pedido.SKU;
                    folio.Compras = pedido.Cantidad;
                    folio.Beneficios = 0;
                    folio.Sugeridos = 0;

                    listaFolios.Add(folio);
                }

                ticket.Folios = (Folio[])listaFolios.ToArray(typeof(Folio));

                ticket.CotizacionId = "0";

                ticket.NumeroCamposEncabezado = 6;
                ticket.NumeroCorrectosEncabezado = 0;
                ticket.NumeroErroresEncabezado = 6;

                ticket.NumerodePedidos = compra.Pedidos.Length;
                ticket.NumeroCorrectoPedidos = 0;
                ticket.NumeroErronesPedidos = compra.Pedidos.Length;

                ticket.CodigoExcepcion = 1;
                ticket.DescripcionExcepcion = e.InnerException.Message;

                return ticket;
            }
            catch (Exception ex)
            {
                Ticket ticket = new Ticket();
                ticket.CodigoExcepcion = 1;
                ticket.DescripcionExcepcion = ex.Message;
                return ticket;
            }
        }
        /// <summary>
        /// Método que nos permite generar un Comprobante especial cuando ocurre un error.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static Comprobante GenerarComprobanteExcepcion(Token token, Exception e)
        {
            try
            {
                Comprobante comprobante = new Comprobante();

                comprobante.CodigoError = "1";
                comprobante.DescripcionError = e.Message;
                comprobante.Llave = "0";
                comprobante.Tarjeta = token.Tarjeta;

                return comprobante;
            }
            catch (Exception ex)
            {
                Comprobante comprobante = new Comprobante();

                comprobante.CodigoError = "1";
                comprobante.DescripcionError = ex.Message;
                comprobante.Llave = "0";
                comprobante.Tarjeta = token.Tarjeta;

                return comprobante;
            }
        }

        #endregion Metodos
    }
}
