using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Entidades;
using Negocio;

namespace WebServiceReglasNegocio
{
    /// <summary>
    /// Summary description for WsReglasNegocio
    /// </summary>
    [WebService(Namespace = "http://lms.com.mx/WebServices/LealtadBenavides")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class WsReglasNegocio : System.Web.Services.WebService
    {
        List<Entidades.ActivaTarjetaResult> tablaActivaTarjeta = new List<ActivaTarjetaResult>();
        List<Entidades.CerrarCompraResult> tablaCerrarCompra = new List<CerrarCompraResult>();
        List<Entidades.ValidaTarjetaResult> tablaValidaTarjeta = new List<ValidaTarjetaResult>();
        List<Entidades.CancelarCompraResult> tablaCancelarCompra = new List<CancelarCompraResult>();
        List<Entidades.ProcesarPagoResult> tablaProcesarPago = new List<ProcesarPagoResult>();
        List<Entidades.ProcesarCompraResult> tablaProcesarCompra = new List<ProcesarCompraResult>();

        Negocio.TransaccionesNegocio oNegocio = new TransaccionesNegocio();

        [WebMethod(Description = "Metodo que nos permite activar una tarjeta.")]
        public List<ActivaTarjetaResult> ActivaTarjeta(string ProgramaID, string Llave, string Sucursal, string Terminal, string Usuario, string Tarjeta, string ApellidoP, string ApellidoM, string Nombre, string FechaNac, string CorreoE, string Telefono, string TelefonoM)
        {            
            try
            {
                tablaActivaTarjeta = oNegocio.RegresaActivarTarjeta(ProgramaID, Llave, Sucursal, Terminal, Usuario, Tarjeta, ApellidoP, ApellidoM, Nombre, FechaNac, CorreoE, Telefono, TelefonoM);

                return tablaActivaTarjeta;
            }
            catch
            {
                return null;// Excepciones.GenerarTicketExcepcion(consultaTarjeta, ex);
            }
        }

        [WebMethod(Description = "Metodo que nos permite cerrar una compra.")]
        public List<CerrarCompraResult> CerrarCompra(string ProgramaID, string Llave, string Tarjeta, string Cotizacion, string NoTicket)
        {
            try
            {
                tablaCerrarCompra = oNegocio.RegresaCerrarCompra(ProgramaID, Llave, Tarjeta, Cotizacion,NoTicket);

                return tablaCerrarCompra;
            }
            catch
            {
                return null;// Excepciones.GenerarTicketExcepcion(consultaTarjeta, ex);
            }
        }

        [WebMethod(Description = "Metodo que nos permite validar una tarjeta.")]
        public List<ValidaTarjetaResult> ValidaTarjeta(string ProgramaID, string Llave, string Tarjeta)
        {
            try
            {
                tablaValidaTarjeta = oNegocio.RegresaValidaTarjeta(ProgramaID, Llave, Tarjeta);

                return tablaValidaTarjeta;
            }
            catch
            {
                return null;// Excepciones.GenerarTicketExcepcion(consultaTarjeta, ex);
            }
        }

        [WebMethod(Description = "Metodo que nos permite cancelar una compra.")]
        public List<CancelarCompraResult> CancelarCompra(string ProgramaID, string Llave, string Tarjeta, string Cotizacion)
        {
            try
            {
                tablaCancelarCompra = oNegocio.RegresaCancelarCompra(ProgramaID, Llave, Tarjeta,Cotizacion);

                return tablaCancelarCompra;
            }
            catch
            {
                return null;// Excepciones.GenerarTicketExcepcion(consultaTarjeta, ex);
            }
        }

        [WebMethod(Description = "Metodo que nos permite procesar pago.")]
        public List<ProcesarPagoResult> ProcesarPago(string ProgramaID, string Llave, string Tarjeta, string Sucursal, string Terminal, string Usuario, double Importe)
        {
            try
            {
                tablaProcesarPago = oNegocio.RegresaProcesarPago(ProgramaID, Llave, Tarjeta, Sucursal, Terminal, Usuario, Importe);

                return tablaProcesarPago;
            }
            catch
            {
                return null;// Excepciones.GenerarTicketExcepcion(consultaTarjeta, ex);
            }
        }

        [WebMethod(Description = "Metodo que nos permite procesar una compra.")]
        public List<ProcesarCompraResult> ProcesarCompra(string ProgramaID, string Llave, string Tarjeta, string Sucursal, string Terminal, string Usuario, string PedidoTicket)
        {
            try
            {
                tablaProcesarCompra = oNegocio.RegresaProcesarCompra(ProgramaID, Llave, Tarjeta, Sucursal, Terminal, Usuario, PedidoTicket);

                return tablaProcesarCompra;
            }
            catch
            {
                return null;// Excepciones.GenerarTicketExcepcion(consultaTarjeta, ex);
            }
        }
        
    }
}
