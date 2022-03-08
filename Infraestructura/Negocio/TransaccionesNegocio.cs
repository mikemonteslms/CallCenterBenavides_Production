using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using DataSQL;
namespace Negocio
{

     public class TransaccionesNegocio
     {

         ClassDataSQL1 sqlTransacciones = null;
         public List<Entidades.Transacciones> RegresaTransacciones(int tipoExtraccion, string fecha, string strUsuario)
         {
             List<Entidades.Transacciones> tablaTransaccionesNegocio = new List<Transacciones>();
             string error="";
             string mensaje="";
             int totalRegistros=0;
             int registroInsercion=0;
             int transaccionIntID=0;
             int cadenaIntID=0;
             int sucursalIntID=0;
             string sucursal_StrID="";
             string tarjetaStrNumero="";
             string  transaccionDateFecha=DateTime.Now.ToShortDateString();
             string presentacionIntSKU="";
             string PresentacionStrID = "";
             int transaccionIntCantidad=0;
             string transaccionStrTipoMov="";
             string transaccionStrSubTipoMov="";
             
             try
             {
                sqlTransacciones=new ClassDataSQL1(); 
                 SqlParameter[] parametros = new SqlParameter[3];
                 parametros[0] = new SqlParameter("@TipoExtraccion", tipoExtraccion);
                 parametros[1] = new SqlParameter("@Fecha", fecha);
                 parametros[2] = new SqlParameter("@strUsuario", strUsuario);
                 DataSet oDS = sqlTransacciones.LlenaDatosDataSet("sp_ListaTransaccion", parametros);
                 if (oDS.Tables[0].Rows.Count > 0)
                 {

                     for (int i = 0; i < oDS.Tables[0].Rows.Count; i++)
                     {

                         												

                         error = oDS.Tables[0].Rows[i]["Error"].ToString();
                         mensaje = oDS.Tables[0].Rows[i]["Mensaje"].ToString();
                         totalRegistros = int.Parse(oDS.Tables[0].Rows[i]["TotalRegistros"].ToString());
                         registroInsercion = int.Parse(oDS.Tables[0].Rows[i]["RegistroInsercion"].ToString());
                         transaccionIntID = int.Parse(oDS.Tables[0].Rows[i]["Transaccion_intID"].ToString());
                         cadenaIntID = int.Parse(oDS.Tables[0].Rows[i]["Cadena_intID"].ToString());
                         sucursalIntID = int.Parse(oDS.Tables[0].Rows[i]["Sucursal_intID"].ToString());
                         sucursal_StrID = oDS.Tables[0].Rows[i]["Sucursal_uniqueID"].ToString();
                         tarjetaStrNumero = oDS.Tables[0].Rows[i]["Tarjeta_strNumero"].ToString();
                         transaccionDateFecha =oDS.Tables[0].Rows[i]["Transaccion_dateFecha"].ToString();
                         presentacionIntSKU = oDS.Tables[0].Rows[i]["Presentacion_intSKU"].ToString();
                         PresentacionStrID = oDS.Tables[0].Rows[i]["Presentacion_strUniqueIdentifier"].ToString();
                         transaccionIntCantidad =int.Parse( oDS.Tables[0].Rows[i]["Transaccion_intCantidad"].ToString());
                         transaccionStrTipoMov = oDS.Tables[0].Rows[i]["Transaccion_strTipoMov"].ToString();
                         transaccionStrSubTipoMov = oDS.Tables[0].Rows[i]["Transaccion_strSubTipoMov"].ToString();

                         tablaTransaccionesNegocio.Add(new Transacciones(error, mensaje, totalRegistros, registroInsercion, transaccionIntID, cadenaIntID, sucursalIntID, sucursal_StrID, tarjetaStrNumero, transaccionDateFecha, presentacionIntSKU, PresentacionStrID, transaccionIntCantidad, transaccionStrTipoMov, transaccionStrSubTipoMov));

                     }
                 }
                 else
                 {
                     tablaTransaccionesNegocio.Add(new Transacciones("error 3", "se encontraron 0 registros a transaccionar", totalRegistros, registroInsercion, transaccionIntID, cadenaIntID, sucursalIntID, sucursal_StrID, tarjetaStrNumero, transaccionDateFecha, presentacionIntSKU, PresentacionStrID,transaccionIntCantidad, transaccionStrTipoMov, transaccionStrSubTipoMov));
                     //error 3: se encontraron 0 registros a transaccionar.
                 }
                 return tablaTransaccionesNegocio;
             }
             catch(Exception ex)
             {
                 tablaTransaccionesNegocio.Add(new Transacciones("error 4", ex.Message, totalRegistros, 0, transaccionIntID, cadenaIntID, sucursalIntID, sucursal_StrID,tarjetaStrNumero, transaccionDateFecha, presentacionIntSKU,PresentacionStrID, transaccionIntCantidad, transaccionStrTipoMov, transaccionStrSubTipoMov));
                 return tablaTransaccionesNegocio;
                 //Error 4: Error de comunicacion con BD, favor de comunicarlo al administrador del sistema.
             }
         }
         public string  ConfirmaTransaccion(int paqueteEntrega, string listatransacciones, int estatus)
         {
            sqlTransacciones=new ClassDataSQL1(); 
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@PaqueteEntrega", paqueteEntrega);
            parametros[1] = new SqlParameter("@ListaTransacciones", listatransacciones);
            parametros[2] = new SqlParameter("@Estatus",  estatus);

            DataSet oDS = sqlTransacciones.LlenaDatosDataSet("sp_EstatusPaqueteEntrega", parametros);

            string regresa = oDS.Tables[0].Rows[0][0].ToString() + "|" + oDS.Tables[0].Rows[0][1].ToString();
            return regresa;
         }

         public List<Entidades.ActivaTarjetaResult> RegresaActivarTarjeta(string ProgramaID, string Llave, string Sucursal, string Terminal, string Usuario, string Tarjeta, string ApellidoP, string ApellidoM, string Nombre, string FechaNac, string CorreoE, string Telefono, string TelefonoM)
         {
             List<Entidades.ActivaTarjetaResult> tablaActivaTarjeta = new List<ActivaTarjetaResult>();

             string tarjeta_strNumero = "";
             string codigoError_strCodigo = "";
             string codigoRespuesta_StrCodigo = "";
             string codigoRespuesta_strDescripcion = "";             

             try
             {
             sqlTransacciones=new ClassDataSQL1();
                 SqlParameter[] parametros = new SqlParameter[13];
                 parametros[0] = new SqlParameter("@ProgramaID", ProgramaID);
                 parametros[1] = new SqlParameter("@Llave", Llave);                 
                 parametros[2] = new SqlParameter("@Sucursal", Sucursal);
                 parametros[3] = new SqlParameter("@Terminal", Terminal);
                 parametros[4] = new SqlParameter("@Usuario", Usuario);
                 parametros[5] = new SqlParameter("@Tarjeta", Tarjeta);
                 parametros[6] = new SqlParameter("@ApellidoP", ApellidoP);
                 parametros[7] = new SqlParameter("@ApellidoM", ApellidoM);
                 parametros[8] = new SqlParameter("@Nombre", Nombre);
                 parametros[9] = new SqlParameter("@FechaNac", FechaNac);
                 parametros[10] = new SqlParameter("@CorreoE", CorreoE);
                 parametros[11] = new SqlParameter("@Telefono", Telefono);
                 parametros[12] = new SqlParameter("@TelefonoM", TelefonoM);

                 DataSet oDS = sqlTransacciones.LlenaDatosDataSet("sp_WSActivarTarjeta", parametros);
                 if (oDS.Tables[0].Rows.Count > 0)
                 {

                     for (int i = 0; i < oDS.Tables[0].Rows.Count; i++)
                     {
                         tarjeta_strNumero = oDS.Tables[0].Rows[i]["Tarjeta_strNumero"].ToString();
                         codigoError_strCodigo = oDS.Tables[0].Rows[i]["CodigoError_strCodigo"].ToString();
                         codigoRespuesta_StrCodigo = oDS.Tables[0].Rows[i]["CodigoRespuesta_StrCodigo"].ToString();
                         codigoRespuesta_strDescripcion = oDS.Tables[0].Rows[i]["CodigoRespuesta_strDescripcion"].ToString();

                         tablaActivaTarjeta.Add(new ActivaTarjetaResult(tarjeta_strNumero, codigoError_strCodigo, codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion));
                     }
                 }
                 else
                 {
                     tablaActivaTarjeta.Add(new ActivaTarjetaResult(tarjeta_strNumero, "no hay transacciones que regresar", codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion));
                     //error 3: se encontraron 0 registros a transaccionar.
                 }
                 return tablaActivaTarjeta;
             }
             catch (Exception ex)
             {
                 tablaActivaTarjeta.Add(new ActivaTarjetaResult(tarjeta_strNumero, ex.Message, codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion));
                 return tablaActivaTarjeta;
                 //Error 4: Error de comunicacion con BD, favor de comunicarlo al administrador del sistema.
             }
         }

         public List<Entidades.CerrarCompraResult> RegresaCerrarCompra(string ProgramaID, string Llave, string Tarjeta, string CotizacionStr, string NoTicket)
         {
             List<Entidades.CerrarCompraResult> tablaCerrarCompra = new List<CerrarCompraResult>();

             string tarjeta_strNumero = "";
             string codigoError_strCodigo = "";
             string codigoRespuesta_StrCodigo = "";
             string codigoRespuesta_strDescripcion = "";
             string confirmacion_strID = "";
             string cliente_intSaldoAnterior = "";
             string cliente_intPuntosGanados = "";
             string cliente_intSaldoActual = "";
             string cliente_intSaldoActualPesos = "";

             try
             {
                 sqlTransacciones = new ClassDataSQL1();
                 SqlParameter[] parametros = new SqlParameter[5];
                 parametros[0] = new SqlParameter("@ProgramaID", ProgramaID);
                 parametros[1] = new SqlParameter("@Llave", Llave);
                 parametros[2] = new SqlParameter("@Tarjeta_strID", Tarjeta);
                 parametros[3] = new SqlParameter("@Cotizacion_strID", CotizacionStr);
                 parametros[4] = new SqlParameter("@NoTicket", NoTicket);

                 DataSet oDS = sqlTransacciones.LlenaDatosDataSet("sp_WSCerrarCompra", parametros);
                 if (oDS.Tables[0].Rows.Count > 0)
                 {

                     for (int i = 0; i < oDS.Tables[0].Rows.Count; i++)
                     {
                         tarjeta_strNumero = oDS.Tables[0].Rows[i]["Tarjeta_strNumero"].ToString();
                         codigoError_strCodigo = oDS.Tables[0].Rows[i]["CodigoError_strCodigo"].ToString();
                         codigoRespuesta_StrCodigo = oDS.Tables[0].Rows[i]["CodigoRespuesta_StrCodigo"].ToString();
                         codigoRespuesta_strDescripcion = oDS.Tables[0].Rows[i]["CodigoRespuesta_strDescripcion"].ToString();
                         confirmacion_strID = oDS.Tables[0].Rows[i]["Confirmacion_strID"].ToString();
                         cliente_intSaldoAnterior = oDS.Tables[0].Rows[i]["Cliente_intSaldoAnterior"].ToString();
                         cliente_intPuntosGanados = oDS.Tables[0].Rows[i]["Cliente_intPuntosGanados"].ToString();
                         cliente_intSaldoActual = oDS.Tables[0].Rows[i]["Cliente_intSaldoActual"].ToString();
                         cliente_intSaldoActualPesos = oDS.Tables[0].Rows[i]["Cliente_intSaldoActualPesos"].ToString();

                         tablaCerrarCompra.Add(new CerrarCompraResult(tarjeta_strNumero, codigoError_strCodigo, codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, confirmacion_strID, cliente_intSaldoAnterior, cliente_intPuntosGanados, cliente_intSaldoActual, cliente_intSaldoActualPesos));
                     }
                 }
                 else
                 {
                     tablaCerrarCompra.Add(new CerrarCompraResult(tarjeta_strNumero, "no hay transacciones que regresar", codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, confirmacion_strID, cliente_intSaldoAnterior, cliente_intPuntosGanados, cliente_intSaldoActual, cliente_intSaldoActualPesos));
                     //error 3: se encontraron 0 registros a transaccionar.
                 }
                 return tablaCerrarCompra;
             }
             catch (Exception ex)
             {
                 tablaCerrarCompra.Add(new CerrarCompraResult(tarjeta_strNumero, ex.Message, codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, confirmacion_strID, cliente_intSaldoAnterior, cliente_intPuntosGanados, cliente_intSaldoActual, cliente_intSaldoActualPesos));
                 return tablaCerrarCompra;
                 //Error 4: Error de comunicacion con BD, favor de comunicarlo al administrador del sistema.
             }
         }

         public List<Entidades.ValidaTarjetaResult> RegresaValidaTarjeta(string ProgramaID, string Llave, string Tarjeta)
         {
             List<Entidades.ValidaTarjetaResult> tablaValidaTarjeta = new List<ValidaTarjetaResult>();

             string tarjeta_strNumero = "";
             string codigoError_strCodigo = "";
             string codigoRespuesta_StrCodigo = "";
             string codigoRespuesta_strDescripcion = "";
             string cliente_strNombre = "";
             string tarjeta_strEstatus = "";
             string tarjeta_intMontoAcumulados = "";
             string tarjeta_intPuntosAcumulados = "";
             string mensajePublicar = "";
             string fechaVencimientoPuntos = "";
             string tarjeta_intNivel = "";
             string tarjeta_strNivel = "";

             try
             {
                 sqlTransacciones = new ClassDataSQL1();
                 SqlParameter[] parametros = new SqlParameter[3];
                 parametros[0] = new SqlParameter("@ProgramaID", ProgramaID);
                 parametros[1] = new SqlParameter("@Llave", Llave);
                 parametros[2] = new SqlParameter("@Tarjeta_strID", Tarjeta);

                 DataSet oDS = sqlTransacciones.LlenaDatosDataSet("sp_WSValidaTarjeta", parametros);
                 if (oDS.Tables[0].Rows.Count > 0)
                 {

                     for (int i = 0; i < oDS.Tables[0].Rows.Count; i++)
                     {
                         tarjeta_strNumero = oDS.Tables[0].Rows[i]["Tarjeta_strNumero"].ToString();
                         codigoError_strCodigo = oDS.Tables[0].Rows[i]["CodigoError_strCodigo"].ToString();
                         codigoRespuesta_StrCodigo = oDS.Tables[0].Rows[i]["CodigoRespuesta_StrCodigo"].ToString();
                         codigoRespuesta_strDescripcion = oDS.Tables[0].Rows[i]["CodigoRespuesta_strDescripcion"].ToString();
                         cliente_strNombre = oDS.Tables[0].Rows[i]["Cliente_strNombre"].ToString();
                         tarjeta_strEstatus = oDS.Tables[0].Rows[i]["Tarjeta_strEstatus"].ToString();
                         tarjeta_intMontoAcumulados = oDS.Tables[0].Rows[i]["Tarjeta_intMontoAcumulados"].ToString();
                         tarjeta_intPuntosAcumulados = oDS.Tables[0].Rows[i]["Tarjeta_intPuntosAcumulados"].ToString();
                         mensajePublicar = oDS.Tables[0].Rows[i]["MensajePublicar"].ToString();
                         fechaVencimientoPuntos = oDS.Tables[0].Rows[i]["FechaVencimientoPuntos"].ToString();
                         tarjeta_intNivel = oDS.Tables[0].Rows[i]["Tarjeta_intNivel"].ToString();
                         tarjeta_strNivel = oDS.Tables[0].Rows[i]["Tarjeta_strNivel"].ToString();

                         tablaValidaTarjeta.Add(new ValidaTarjetaResult(tarjeta_strNumero, codigoError_strCodigo, codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, cliente_strNombre, tarjeta_strEstatus, tarjeta_intMontoAcumulados, tarjeta_intPuntosAcumulados, mensajePublicar, fechaVencimientoPuntos, tarjeta_intNivel, tarjeta_strNivel));
                     }
                 }
                 else
                 {
                     tablaValidaTarjeta.Add(new ValidaTarjetaResult(tarjeta_strNumero, "no hay transacciones que regresar", codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, cliente_strNombre, tarjeta_strEstatus, tarjeta_intMontoAcumulados, tarjeta_intPuntosAcumulados, mensajePublicar, fechaVencimientoPuntos, tarjeta_intNivel, tarjeta_strNivel));
                     //error 3: se encontraron 0 registros a transaccionar.
                 }
                 return tablaValidaTarjeta;
             }
             catch (Exception ex)
             {
                 tablaValidaTarjeta.Add(new ValidaTarjetaResult(tarjeta_strNumero, ex.Message, codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, cliente_strNombre, tarjeta_strEstatus, tarjeta_intMontoAcumulados, tarjeta_intPuntosAcumulados, mensajePublicar, fechaVencimientoPuntos, tarjeta_intNivel, tarjeta_strNivel));
                 return tablaValidaTarjeta;
                 //Error 4: Error de comunicacion con BD, favor de comunicarlo al administrador del sistema.
             }
         }

         public List<Entidades.CancelarCompraResult> RegresaCancelarCompra(string ProgramaID, string Llave, string Tarjeta, string CotizacionStr)
         {
             List<Entidades.CancelarCompraResult> tablaCancelarCompra = new List<CancelarCompraResult>();

             string tarjeta_strNumero = "";
             string codigoError_strCodigo = "";
             string codigoRespuesta_StrCodigo = "";
             string codigoRespuesta_strDescripcion = "";
             string strConfirmacion = "";
             string cliente_intSaldoAnterior = "";
             string cliente_intPuntosCancelados = "";
             string cliente_intSaldoActual = "";
             string cliente_intSaldoActualPesos = "";            

             try
             {
                 sqlTransacciones = new ClassDataSQL1();
                 SqlParameter[] parametros = new SqlParameter[4];
                 parametros[0] = new SqlParameter("@ProgramaID", ProgramaID);
                 parametros[1] = new SqlParameter("@Llave", Llave);
                 parametros[2] = new SqlParameter("@Tarjeta_strID", Tarjeta);
                 parametros[3] = new SqlParameter("@Cotizacion_strID", CotizacionStr);

                 DataSet oDS = sqlTransacciones.LlenaDatosDataSet("sp_WSCancelarCompra", parametros);
                 if (oDS.Tables[0].Rows.Count > 0)
                 {

                     for (int i = 0; i < oDS.Tables[0].Rows.Count; i++)
                     {
                         tarjeta_strNumero = oDS.Tables[0].Rows[i]["Tarjeta_strNumero"].ToString();
                         codigoError_strCodigo = oDS.Tables[0].Rows[i]["CodigoError_strCodigo"].ToString();
                         codigoRespuesta_StrCodigo = oDS.Tables[0].Rows[i]["CodigoRespuesta_StrCodigo"].ToString();
                         codigoRespuesta_strDescripcion = oDS.Tables[0].Rows[i]["CodigoRespuesta_strDescripcion"].ToString();
                         strConfirmacion = oDS.Tables[0].Rows[i]["strConfirmacion"].ToString();
                         cliente_intSaldoAnterior = oDS.Tables[0].Rows[i]["Cliente_intSaldoAnterior"].ToString();
                         cliente_intPuntosCancelados = oDS.Tables[0].Rows[i]["Cliente_intPuntosCancelados"].ToString();
                         cliente_intSaldoActual = oDS.Tables[0].Rows[i]["Cliente_intSaldoActual"].ToString();
                         cliente_intSaldoActualPesos = oDS.Tables[0].Rows[i]["Cliente_intSaldoActualPesos"].ToString();

                         tablaCancelarCompra.Add(new CancelarCompraResult(tarjeta_strNumero, codigoError_strCodigo, codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, strConfirmacion, cliente_intSaldoAnterior, cliente_intPuntosCancelados, cliente_intSaldoActual, cliente_intSaldoActualPesos));
                     }
                 }
                 else
                 {
                     tablaCancelarCompra.Add(new CancelarCompraResult(tarjeta_strNumero, "no hay transacciones que regresar", codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, strConfirmacion, cliente_intSaldoAnterior, cliente_intPuntosCancelados, cliente_intSaldoActual, cliente_intSaldoActualPesos));
                     //error 3: se encontraron 0 registros a transaccionar.
                 }
                 return tablaCancelarCompra;
             }
             catch (Exception ex)
             {
                 tablaCancelarCompra.Add(new CancelarCompraResult(tarjeta_strNumero, ex.Message, codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, strConfirmacion, cliente_intSaldoAnterior, cliente_intPuntosCancelados, cliente_intSaldoActual, cliente_intSaldoActualPesos));
                 return tablaCancelarCompra;
                 //Error 4: Error de comunicacion con BD, favor de comunicarlo al administrador del sistema.
             }
         }

         public List<Entidades.ProcesarPagoResult> RegresaProcesarPago(string ProgramaID, string Llave, string Tarjeta, string Sucursal, string Terminal, string Usuario, double Importe_intValor)
         {
             List<Entidades.ProcesarPagoResult> tablaProcesarPago = new List<ProcesarPagoResult>();

             string tarjeta_strNumero = "";
             string codigoError_strCodigo = "";
             string codigoRespuesta_StrCodigo = "";
             string codigoRespuesta_strDescripcion = "";
             string strConfirmacion = "";
             string cliente_intSaldoAnterior = "";
             string cliente_intPuntosRedimidos = "";
             string cliente_intSaldoActual = "";
             string cliente_intSaldoActualPesos = "";

             try
             {
                 sqlTransacciones = new ClassDataSQL1();
                 SqlParameter[] parametros = new SqlParameter[7];
                 parametros[0] = new SqlParameter("@ProgramaID", ProgramaID);
                 parametros[1] = new SqlParameter("@Llave", Llave);
                 parametros[2] = new SqlParameter("@Tarjeta_strID", Tarjeta);
                 parametros[3] = new SqlParameter("@Sucursal_strId", Sucursal);
                 parametros[4] = new SqlParameter("@Terminal_strId", Terminal);
                 parametros[5] = new SqlParameter("@Usuario_strId", Usuario);
                 parametros[6] = new SqlParameter("@Importe_intValor", Importe_intValor);

                 DataSet oDS = sqlTransacciones.LlenaDatosDataSet("sp_WSProcesarPago", parametros);
                 if (oDS.Tables[0].Rows.Count > 0)
                 {

                     for (int i = 0; i < oDS.Tables[0].Rows.Count; i++)
                     {
                         tarjeta_strNumero = oDS.Tables[0].Rows[i]["Tarjeta_strNumero"].ToString();
                         codigoError_strCodigo = oDS.Tables[0].Rows[i]["CodigoError_strCodigo"].ToString();
                         codigoRespuesta_StrCodigo = oDS.Tables[0].Rows[i]["CodigoRespuesta_StrCodigo"].ToString();
                         codigoRespuesta_strDescripcion = oDS.Tables[0].Rows[i]["CodigoRespuesta_strDescripcion"].ToString();
                         strConfirmacion = oDS.Tables[0].Rows[i]["strConfirmacion"].ToString();
                         cliente_intSaldoAnterior = oDS.Tables[0].Rows[i]["Cliente_intSaldoAnterior"].ToString();
                         cliente_intPuntosRedimidos = oDS.Tables[0].Rows[i]["Cliente_intPuntosRedimidos"].ToString();
                         cliente_intSaldoActual = oDS.Tables[0].Rows[i]["Cliente_intSaldoActual"].ToString();
                         cliente_intSaldoActualPesos = oDS.Tables[0].Rows[i]["Cliente_intSaldoActualPesos"].ToString();

                         tablaProcesarPago.Add(new ProcesarPagoResult(tarjeta_strNumero, codigoError_strCodigo, codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, strConfirmacion, cliente_intSaldoAnterior, cliente_intPuntosRedimidos, cliente_intSaldoActual, cliente_intSaldoActualPesos));
                     }
                 }
                 else
                 {
                     tablaProcesarPago.Add(new ProcesarPagoResult(tarjeta_strNumero, "no hay transacciones que regresar", codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, strConfirmacion, cliente_intSaldoAnterior, cliente_intPuntosRedimidos, cliente_intSaldoActual, cliente_intSaldoActualPesos));
                     //error 3: se encontraron 0 registros a transaccionar.
                 }
                 return tablaProcesarPago;
             }
             catch (Exception ex)
             {
                 tablaProcesarPago.Add(new ProcesarPagoResult(tarjeta_strNumero, ex.Message, codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, strConfirmacion, cliente_intSaldoAnterior, cliente_intPuntosRedimidos, cliente_intSaldoActual, cliente_intSaldoActualPesos));
                 return tablaProcesarPago;
                 //Error 4: Error de comunicacion con BD, favor de comunicarlo al administrador del sistema.
             }
         }

         public List<Entidades.ProcesarCompraResult> RegresaProcesarCompra(string ProgramaID, string Llave, string Tarjeta, string Sucursal, string Terminal, string Usuario, string PedidoTicket)
         {
             List<Entidades.ProcesarCompraResult> tablaProcesarCompra = new List<ProcesarCompraResult>();

             string tarjeta_strNumero = "";
             string sucursal_strId = "";
             string terminal_strId = "";
             string usuario_strId = "";
             string codigoError_strCodigo = "";
             string codigoRespuesta_StrCodigo = "";
             string codigoRespuesta_strDescripcion = "";
             string strCotizacion = "";
             string cliente_intSaldoAnterior = "";
             string cliente_intPuntosAcumulados = "";
             string cliente_intSaldoActual = "";
             string cliente_intSaldoActualPesos = "";
             string fechaVencimientoPuntos = "";
             string ticketBeneficio = "";

             try
             {
                 sqlTransacciones = new ClassDataSQL1();
                 SqlParameter[] parametros = new SqlParameter[7];
                 parametros[0] = new SqlParameter("@ProgramaID", ProgramaID);
                 parametros[1] = new SqlParameter("@Llave", Llave);
                 parametros[2] = new SqlParameter("@Tarjeta_strID", Tarjeta);
                 parametros[3] = new SqlParameter("@Sucursal_strId", Sucursal);
                 parametros[4] = new SqlParameter("@Terminal_strId", Terminal);
                 parametros[5] = new SqlParameter("@Usuario_strId", Usuario);
                 parametros[6] = new SqlParameter("@PedidoTicket", PedidoTicket);

                 DataSet oDS = sqlTransacciones.LlenaDatosDataSet("sp_WSProcesarCompra", parametros);
                 if (oDS.Tables[0].Rows.Count > 0)
                 {

                     for (int i = 0; i < oDS.Tables[0].Rows.Count; i++)
                     {
                         tarjeta_strNumero = oDS.Tables[0].Rows[i]["Tarjeta_strNumero"].ToString();
                         sucursal_strId = oDS.Tables[0].Rows[i]["Sucursal_strId"].ToString();
                         terminal_strId = oDS.Tables[0].Rows[i]["Terminal_strId"].ToString();
                         usuario_strId = oDS.Tables[0].Rows[i]["Usuario_strId"].ToString();
                         codigoError_strCodigo = oDS.Tables[0].Rows[i]["CodigoError_strCodigo"].ToString();
                         codigoRespuesta_StrCodigo = oDS.Tables[0].Rows[i]["CodigoRespuesta_StrCodigo"].ToString();
                         codigoRespuesta_strDescripcion = oDS.Tables[0].Rows[i]["CodigoRespuesta_strDescripcion"].ToString();
                         strCotizacion = oDS.Tables[0].Rows[i]["strCotizacion"].ToString();
                         cliente_intSaldoAnterior = oDS.Tables[0].Rows[i]["Cliente_intSaldoAnterior"].ToString();
                         cliente_intPuntosAcumulados = oDS.Tables[0].Rows[i]["Cliente_intPuntosAcumulados"].ToString();
                         cliente_intSaldoActual = oDS.Tables[0].Rows[i]["Cliente_intSaldoActual"].ToString();
                         cliente_intSaldoActualPesos = oDS.Tables[0].Rows[i]["Cliente_intSaldoActualPesos"].ToString();
                         fechaVencimientoPuntos = oDS.Tables[0].Rows[i]["FechaVencimientoPuntos"].ToString();
                         ticketBeneficio = oDS.Tables[0].Rows[i]["TicketBeneficio"].ToString();

                         tablaProcesarCompra.Add(new ProcesarCompraResult(tarjeta_strNumero, sucursal_strId, terminal_strId, usuario_strId, codigoError_strCodigo, codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, strCotizacion, cliente_intSaldoAnterior, cliente_intPuntosAcumulados, cliente_intSaldoActual, cliente_intSaldoActualPesos, fechaVencimientoPuntos, ticketBeneficio));
                     }
                 }
                 else
                 {
                     tablaProcesarCompra.Add(new ProcesarCompraResult(tarjeta_strNumero, sucursal_strId, terminal_strId, usuario_strId, "no hay transacciones que regresar", codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, strCotizacion, cliente_intSaldoAnterior, cliente_intPuntosAcumulados, cliente_intSaldoActual, cliente_intSaldoActualPesos, fechaVencimientoPuntos, ticketBeneficio));
                     //error 3: se encontraron 0 registros a transaccionar.
                 }
                 return tablaProcesarCompra;
             }
             catch (Exception ex)
             {
                 tablaProcesarCompra.Add(new ProcesarCompraResult(tarjeta_strNumero, sucursal_strId, terminal_strId, usuario_strId, ex.Message, codigoRespuesta_StrCodigo, codigoRespuesta_strDescripcion, strCotizacion, cliente_intSaldoAnterior, cliente_intPuntosAcumulados, cliente_intSaldoActual, cliente_intSaldoActualPesos, fechaVencimientoPuntos, ticketBeneficio));
                 return tablaProcesarCompra;
                 //Error 4: Error de comunicacion con BD, favor de comunicarlo al administrador del sistema.
             }
         }
    }
}
