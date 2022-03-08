using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Entidades;
namespace Negocio
{
    public class Tickets
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static Ticket ObtenerEncabezadoTicket(ArrayList lista)
        {
            try
            {
                Ticket ticket = new Ticket();
                ArrayList listaFolios = new ArrayList();

                foreach (Validacion validacion in lista)
                {
                    switch (validacion.Categoria)
                    {
                        case 1:
                            ticket.Programa_intId = (int)validacion.Valor;
                            ticket.TipoDato_ProgramaId = validacion.Tipo;
                            ticket.ValidoProgramaId = validacion.Valido;
                            ticket.ExisteProgramaId = validacion.Existe;
                            ticket.ErrorProgramaId = validacion.CodigoError;
                            ticket.DescripcionErrorProgramaId = validacion.DescripcionError;
                            break;
                        case 2:
                            ticket.Cadena_intId = (int)validacion.Valor;
                            ticket.TipoDato_CadenaId = validacion.Tipo;
                            ticket.ValidaCadenaId = validacion.Valido;
                            ticket.ExisteCadenaId = validacion.Existe;
                            ticket.ErrorCadenaId = validacion.CodigoError;
                            ticket.DescripcionErrorCadenaId = validacion.DescripcionError;
                            break;
                        case 3:
                            ticket.Sucursal_intId = (int)validacion.Valor;
                            ticket.TipoDato_SucursalId = validacion.Tipo;
                            ticket.ValidaSucursalId = validacion.Valido;
                            ticket.ExisteSucursalId = validacion.Existe;
                            ticket.ErrorSucursalId = validacion.CodigoError;
                            ticket.DescripcionErrorSucursalId = validacion.DescripcionError;
                            break;
                        case 4:
                            ticket.Terminal_intId = (int)validacion.Valor;
                            ticket.TipoDato_TerminalId = validacion.Tipo;
                            ticket.ValidaTerminalId = validacion.Valido;
                            ticket.ExisteTerminalId = validacion.Existe;
                            ticket.ErrorTerminalId = validacion.CodigoError;
                            ticket.DescripcionErrorTerminalId = validacion.DescripcionError;
                            break;
                        case 5:
                            ticket.UsuarioTicket_strId = validacion.Valor.ToString();
                            ticket.TipoDato_UsuarioTicketId = validacion.Tipo;
                            ticket.ValidaUsuarioTicketId = validacion.Valido;
                            ticket.ExisteUsuarioTicketId = validacion.Existe;
                            ticket.ErrorUsuarioTicketId = validacion.CodigoError;
                            ticket.DescripcionErrorUsuarioTicketId = validacion.DescripcionError;
                            break;
                        case 6:
                            ticket.UsuarioCaptura_strId = validacion.Valor.ToString();
                            ticket.TipoDato_UsuarioCapturaId = validacion.Tipo;
                            ticket.ValidaUsuarioCapturaId = validacion.Valido;
                            ticket.ExisteUsuarioCapturaId = validacion.Existe;
                            ticket.ErrorUsuarioCapturaId = validacion.CodigoError;
                            ticket.DescripcionErrorUsuarioCapturaId = validacion.DescripcionError;
                            break;
                        case 7: 
                            ticket.Tarjeta = validacion.Valor.ToString();
                            ticket.TipoDato_Tarjeta = validacion.Tipo;
                            ticket.ValidaTarjeta = validacion.Valido;
                            ticket.ExisteTarjeta = validacion.Existe;
                            ticket.ErrorTarjeta = validacion.CodigoError;
                            ticket.DescripcionErrorTarjeta = validacion.DescripcionError;
                            break;
                    }
                }

                return ticket;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public static Ticket ObtenerFolios(ArrayList lista, Ticket ticket)
        {
            try
            {
                ArrayList listaFolios = new ArrayList();

                foreach (Validacion validacion in lista)
                {
                    if (validacion.Categoria.Equals(8))
                    {
                        Folio folio = new Folio();

                        folio.SKU = validacion.Valor.ToString();
                        folio.ValidoSKU = validacion.Valido;
                        folio.ExisteSKU = validacion.Existe;
                        folio.ErrorSKU = validacion.CodigoError;
                        folio.DescripcionErrorSKU = validacion.DescripcionError;
                        folio.descripcionSKU = validacion.DescripcionSKU;
                        folio.Compras = validacion.Compras;

                        listaFolios.Add(folio);
                    }
                }

                ticket.Folios = (Folio[])listaFolios.ToArray(typeof(Folio));

                return ticket;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
