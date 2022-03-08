using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

namespace CNegocio
{
    public class csValidaciones
    {
        csDataBase query = new csDataBase();
        public string ErrorId
        { get; set; }

        public string Mensaje
        { get; set; }

        public csValidaciones()
        {
        }

        public Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Boolean ValidaFecha(string inputDate)
        {
            bool isDate = true;
            try
            {
                if (inputDate != "") // Si esta en blanco, no lo valida
                {
                    DateTime dateValue;
                    dateValue = DateTime.ParseExact(inputDate, "yyyy-MM-dd", null);
                }
            }
            catch
            {
                isDate = false;
            }
            return isDate;
        }

        public Boolean ValidaTiendaWS(string Tiendaid)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@clave", Tiendaid));
            DataTable dtTienda = query.dtConsulta("ValidaTiendaWS", parametros, true);
            if (dtTienda.Rows.Count > 0)
            {
                ErrorId = dtTienda.Rows[0]["ErrorId"].ToString();
                Mensaje = dtTienda.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaVendedorWS(string Vendedorid)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@clave", Vendedorid));
            DataTable dtVendedor = query.dtConsulta("ValidaVendedorWS", parametros, true);
            if (dtVendedor.Rows.Count > 0)
            {
                ErrorId = dtVendedor.Rows[0]["ErrorId"].ToString();
                Mensaje = dtVendedor.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaTarjetaWS(string Tarjeta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tarjeta", Tarjeta));
            DataTable dtVendedor = query.dtConsulta("ValidaTarjetaWS", parametros, true);
            if (dtVendedor.Rows.Count > 0)
            {
                ErrorId = dtVendedor.Rows[0]["ErrorId"].ToString();
                Mensaje = dtVendedor.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaEmailWS(string Email)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@email", Email));
            DataTable dtTarjeta = query.dtConsulta("ValidaEmailWS", parametros, true);
            if (dtTarjeta.Rows.Count > 0)
            {
                ErrorId = dtTarjeta.Rows[0]["ErrorId"].ToString();
                Mensaje = dtTarjeta.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaTarjetaEmailWS(string Tarjeta, string Email)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tarjeta", Tarjeta));
            parametros.Add(new SqlParameter("@email", Email));
            DataTable dtTarjeta = query.dtConsulta("ValidaTarjetaEmailWS", parametros, true);
            if (dtTarjeta.Rows.Count > 0)
            {
                ErrorId = dtTarjeta.Rows[0]["ErrorId"].ToString();
                Mensaje = dtTarjeta.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaTransaccionWS(string Transaccionid, string Tarjeta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@transaccion_id", Transaccionid));
            parametros.Add(new SqlParameter("@tarjeta", Tarjeta));
            DataTable dtTransaccionId = query.dtConsulta("ValidaTransaccionWS", parametros, true);
            if (dtTransaccionId.Rows.Count > 0)
            {
                ErrorId = dtTransaccionId.Rows[0]["ErrorId"].ToString();
                Mensaje = dtTransaccionId.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaProductoWS(string UPC)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@clave", UPC.Trim()));
            DataTable dtProducto = query.dtConsulta("ValidaProductoWS_V2", parametros, true);
            if (dtProducto.Rows.Count > 0)
            {
                ErrorId = dtProducto.Rows[0]["ErrorId"].ToString();
                Mensaje = dtProducto.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaFormaPagoWS(string TipoPago)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@clave", TipoPago.Trim()));
            DataTable dtTipoPago = query.dtConsulta("ValidaFormaPagoWS", parametros, true);
            if (dtTipoPago.Rows.Count > 0)
            {
                ErrorId = dtTipoPago.Rows[0]["ErrorId"].ToString();
                Mensaje = dtTipoPago.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaTarjetaNuevaWS(string Tarjeta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tarjetaNueva", Tarjeta));
            DataTable dtTarjeta = query.dtConsulta("ValidaTarjetaNuevaWS", parametros, true);
            if (dtTarjeta.Rows.Count > 0)
            {
                ErrorId = dtTarjeta.Rows[0]["ErrorId"].ToString();
                Mensaje = dtTarjeta.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaTicketTiendaWS(string numeroticket, string tienda)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@NumeroTicket", numeroticket));
            parametros.Add(new SqlParameter("@Tienda", tienda));
            DataTable dtTicketTienda = query.dtConsulta("ValidaTicketTiendaWS", parametros, true);
            if (dtTicketTienda.Rows.Count > 0)
            {
                ErrorId = dtTicketTienda.Rows[0]["ErrorId"].ToString();
                Mensaje = dtTicketTienda.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaTicketVentaWS(string numeroFolio)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@numerofolio", numeroFolio));
            DataTable dtTicketTienda = query.dtConsulta("ValidaTicketVentaWS", parametros, true);
            if (dtTicketTienda.Rows.Count > 0)
            {
                ErrorId = dtTicketTienda.Rows[0]["ErrorId"].ToString();
                Mensaje = dtTicketTienda.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaTicketHistoricoCancelacionWS(string numeroticket, string tiendaid, string posid)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@numeroticket", numeroticket));
            parametros.Add(new SqlParameter("@tiendaid", tiendaid));
            parametros.Add(new SqlParameter("@posid", posid));
            DataTable dtTicketHistorico = query.dtConsulta("ValidaTicketHistoricoCancelacionWS", parametros, true);
            if (dtTicketHistorico.Rows.Count > 0)
            {
                ErrorId = dtTicketHistorico.Rows[0]["ErrorId"].ToString();
                Mensaje = dtTicketHistorico.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaTicketHistoricoDevolucionWS(string numeroticket, string tiendaid, string posid)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@numeroticket", numeroticket));
            parametros.Add(new SqlParameter("@tiendaid", tiendaid));
            parametros.Add(new SqlParameter("@posid", posid));
            DataTable dtTicketHistorico = query.dtConsulta("ValidaTicketHistoricoDevolucionWS_V2", parametros, true);
            if (dtTicketHistorico.Rows.Count > 0)
            {
                ErrorId = dtTicketHistorico.Rows[0]["ErrorId"].ToString();
                Mensaje = dtTicketHistorico.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaProductosHistoricoVentasWS(string numeroticket, string tiendaid, string posid, string upc, int cantidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@numeroticket", numeroticket));
            parametros.Add(new SqlParameter("@tiendaid", tiendaid));
            parametros.Add(new SqlParameter("@posid", posid));
            parametros.Add(new SqlParameter("@upc", upc));
            parametros.Add(new SqlParameter("@cantidad", cantidad));
            DataTable dtProductosHistorico = query.dtConsulta("ValidaProductoHistoricoVentasWS_V3", parametros, true);
            if (dtProductosHistorico.Rows.Count > 0)
            {
                ErrorId = dtProductosHistorico.Rows[0]["ErrorId"].ToString();
                Mensaje = dtProductosHistorico.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaKey(string Key, string KeyId)
        {
            if (Key != null && Key.Trim() != "")
            {
                if (Key.Trim() == KeyId) // Valida que el Key sea el mismo que el "KeyId" del web.config
                {
                    ErrorId = "0";
                    Mensaje = "Transacción Exitosa";
                    return true;
                }
                else
                {
                    ErrorId = "2";
                    Mensaje = "Web Service: Parámetros Incorrectos [002]";
                    return false;
                }
            }
            else
            {
                ErrorId = "1";
                Mensaje = "Web Service: Parámetros Incompletos [001]";
                return false;
            }
        }

        public Boolean ValidaProgramaId(string programa_id, string ProgramaId)
        {
            if (programa_id != null && programa_id.Trim() != "")
            {
                if (programa_id.Trim() == ProgramaId) // Valida que el Key sea el mismo que el "KeyId" del web.config
                {
                    ErrorId = "0";
                    Mensaje = "Transacción Exitosa";
                    return true;
                }
                else
                {
                    ErrorId = "2";
                    Mensaje = "Web Service: Parámetros Incorrectos [002]";
                    return false;
                }
            }
            else
            {
                ErrorId = "1";
                Mensaje = "Web Service: Parámetros Incompletos [001]";
                return false;
            }
        }

        public Boolean ValidaModuloId(string modulo_id, string ModuloId)
        {
            if (modulo_id != null && modulo_id.Trim() != "")
            {
                if (modulo_id.Trim() == ModuloId) // Valida que el Key sea el mismo que el "KeyId" del web.config
                {
                    ErrorId = "0";
                    Mensaje = "Transacción Exitosa";
                    return true;
                }
                else
                {
                    ErrorId = "2";
                    Mensaje = "Web Service: Parámetros Incorrectos [002]";
                    return false;
                }
            }
            else
            {
                ErrorId = "1";
                Mensaje = "Web Service: Parámetros Incompletos [001]";
                return false;
            }
        }

        public Boolean ValidaPosIdWS(string Tiendaid, string PosId)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tienda", Tiendaid));
            parametros.Add(new SqlParameter("@caja", PosId));
            DataTable dtCaja = query.dtConsulta("ValidaCajaWS", parametros, true);
            if (dtCaja.Rows.Count > 0)
            {
                ErrorId = dtCaja.Rows[0]["ErrorId"].ToString();
                Mensaje = dtCaja.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaTiendaOrigenidHistoricoWS(string TiendaOrigenid, string numeroticket)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tiendaid", TiendaOrigenid));
            parametros.Add(new SqlParameter("@numeroticket", numeroticket));
            DataTable dtCaja = query.dtConsulta("ValidaTiendaOrigenidHistoricoWS", parametros, true);
            if (dtCaja.Rows.Count > 0)
            {
                ErrorId = dtCaja.Rows[0]["ErrorId"].ToString();
                Mensaje = dtCaja.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaPosOrigenidHistoricoWS(string PosOrigenid, string TiendaOrigenid, string numeroticket)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@posid", PosOrigenid));
            parametros.Add(new SqlParameter("@tiendaid", TiendaOrigenid));
            parametros.Add(new SqlParameter("@numeroticket", numeroticket));
            DataTable dtCaja = query.dtConsulta("ValidaPosOrigenidHistoricoWS", parametros, true);
            if (dtCaja.Rows.Count > 0)
            {
                ErrorId = dtCaja.Rows[0]["ErrorId"].ToString();
                Mensaje = dtCaja.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public Boolean ValidaCuponWS(string Cupon)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cupon", Cupon));
            DataTable dtCaja = query.dtConsulta("ValidaCuponWS_V2", parametros, true);
            if (dtCaja.Rows.Count > 0)
            {
                ErrorId = dtCaja.Rows[0]["ErrorId"].ToString();
                Mensaje = dtCaja.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public Boolean ValidaTerminarRegistroWS(string participante_id, string tipo_transaccion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@participante_id", participante_id));
            parametros.Add(new SqlParameter("@tipo_transaccion", tipo_transaccion));
            DataTable dtCaja = query.dtConsulta("ValidaTerminarRegistroWS", parametros, true);
            if (dtCaja.Rows.Count > 0)
            {
                ErrorId = dtCaja.Rows[0]["ErrorId"].ToString();
                Mensaje = dtCaja.Rows[0]["Descripcion"].ToString();
                if (ErrorId == "0")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

    }
}
