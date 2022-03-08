using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Bitacora.Modelo;
using System.Diagnostics;
using Negocio;

namespace Bitacora
{
    public class Bitacora
    {
        public enum TipoRegistro : int
        {
            NONE = 0,
            FATAL = 1,
            ERRORES = 2,
            WARN = 3,
            INFO = 4,
            DEBUG = 5
        };

        #region Public Methods
        public static void Registrar(TipoRegistro tipo,
                                    System.Reflection.Assembly origen,
                                    string Ambiente,
                                    string Clase,
                                    string EventoOrMetodo,
                                    string parametros,
                                    string mensaje,
                                    string usuario,
                                    Exception excepcion = null)
        {
                Type attributeType = typeof(System.Reflection.AssemblyTitleAttribute);
                string dllApp = ((System.Reflection.AssemblyTitleAttribute)(origen.GetCustomAttributes(attributeType, false)[0])).Title;

                BitacoraLog datosLog = new BitacoraLog();
                datosLog.Ambiente = Ambiente;
                datosLog.App = dllApp;
                datosLog.Clase = Clase;
                datosLog.EventoOrMetodo = EventoOrMetodo;
                datosLog.Hilo = System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
                datosLog.TipoLog = tipo.ToString();
                datosLog.Usuario = usuario;
                datosLog.Mensaje = mensaje;
                datosLog.Excepcion = (excepcion == null ? "" : parametros + " | " + excepcion.Message + "-" + excepcion.StackTrace + "-" + excepcion.InnerException);

                //Implementar registro en dbase
                int Respuesta = Transaccion.InsertaLog(datosLog.Ambiente, datosLog.App, datosLog.Clase, datosLog.EventoOrMetodo, datosLog.Hilo, datosLog.TipoLog, datosLog.Usuario, datosLog.Mensaje, datosLog.Excepcion, "Sp_RegistraLogs"); 
        }

        public static void Registrar(TipoRegistro tipo,
                                    System.Reflection.Assembly origen,
                                    string Ambiente,
                                    string Clase,
                                    string EventoOrMetodo,
                                    string mensaje,
                                    string usuario,
                                    Exception excepcion = null)
        {
            Type attributeType = typeof(System.Reflection.AssemblyTitleAttribute);
            string dllApp = ((System.Reflection.AssemblyTitleAttribute)(origen.GetCustomAttributes(attributeType, false)[0])).Title;

            BitacoraLog datosLog = new BitacoraLog();
            datosLog.Ambiente = Ambiente;
            datosLog.App = dllApp;
            datosLog.Clase = Clase;
            datosLog.EventoOrMetodo = EventoOrMetodo;
            datosLog.Hilo = System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
            datosLog.TipoLog = tipo.ToString();
            datosLog.Usuario = usuario;
            datosLog.Mensaje = mensaje;
            datosLog.Excepcion = (excepcion == null ? "" : excepcion.Message + "-" + excepcion.StackTrace + "-" + excepcion.InnerException);

            //Implementar registro en dbase
            int Respuesta = Transaccion.InsertaLog(datosLog.Ambiente, datosLog.App, datosLog.Clase, datosLog.EventoOrMetodo, datosLog.Hilo, datosLog.TipoLog, datosLog.Usuario, datosLog.Mensaje, datosLog.Excepcion, "Sp_RegistraLogs");
        }
        #endregion
    }
}