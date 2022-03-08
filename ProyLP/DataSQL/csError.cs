using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Configuration;
using System.Web.Security;

/// <summary>
/// Descripción breve de csError
/// </summary>
/// 
public class csError
{
    Datos oDatos = new Datos();
    Funciones oFunciones = new Funciones();
    Exception objErr;
    HttpContext curr;

    public csError(HttpContext httpcontext, Exception ex)
    {
        curr = httpcontext;
        objErr = new Exception();
        objErr = ex;
    }
    public void EscribirLog()
    {
        string usuario_id = "SIN_SESION";
        if (curr.Session != null && Membership.GetUser() != null)
        {
            usuario_id = Membership.GetUser().ProviderUserKey.ToString();
        }
        string err = "Error en la aplicacion " + oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "nombreAplicacion");
        err += "\n\nPagina:\n" + curr.Request.Url.ToString();
        err += "\n\nMensaje de error:\n" + objErr.Message.ToString();
        err += "\n\nMas detalle del error:\n" +
        (objErr.InnerException != null ? objErr.InnerException.Message : "");
        err += "\n\nStack Trace:\n" + objErr.StackTrace.ToString();
        err += "\n\nError Completo:\n" + objErr.ToString();
        err += "\n\nUsuario:\n" + curr.User.Identity.Name;
        err += "\n\nUsuario ID:\n" + usuario_id;
        err += "\n\nAUTH_USER:\n" + curr.Request.ServerVariables["AUTH_USER"].ToString();
        err += "\n\nREMOTE_HOST:\n" + curr.Request.ServerVariables["REMOTE_HOST"].ToString();
        err += "\n\nSERVER_PORT:\n" + curr.Request.ServerVariables["SERVER_PORT"].ToString();
        EventLog.WriteEntry(Membership.ApplicationName, err, EventLogEntryType.Error, Convert.ToInt16(objErr.Data["id"]), Convert.ToInt16(objErr.Data["category"]));
    }
    public void EnviarMail()
    {
        string usuario_id = "SIN_SESION";
        if (curr.Session != null && Membership.GetUser() != null)
        {
            usuario_id = Membership.GetUser().ProviderUserKey.ToString();
        }
        string errMail = "Error en la aplicacion " + oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "nombreAplicacion");
        errMail += "<br/><br/>Fecha: " + DateTime.Now.ToString();
        errMail += "<br/><br/>Pagina:<br/>" + curr.Request.Url.ToString();
        errMail += "<br/><br/>Mensaje de error:<br/>" + objErr.Message.ToString();
        errMail += "<br/><br/>Mas detalle del error:<br/>" +
        (objErr.InnerException != null ? objErr.InnerException.Message : "");
        errMail += "<br/><br/>Stack Trace:<br/>" + objErr.StackTrace.ToString();
        errMail += "<br/><br/>Error Completo:<br/>" + objErr.ToString();
        errMail += "<br/><br/>Usuario:<br/>" + curr.User.Identity.Name;
        errMail += "<br /><b>Usuario ID:</b><br /> " + usuario_id;
        errMail += "<br /><b>AUTH_USER:</b><br /> " + curr.Request.ServerVariables["AUTH_USER"].ToString();
        errMail += "<br /><b>REMOTE_HOST:</b><br /> " + curr.Request.ServerVariables["REMOTE_HOST"].ToString();
        errMail += "<br /><b>SERVER_PORT:</b><br /> " + curr.Request.ServerVariables["SERVER_PORT"].ToString();

        /*oFunciones.enviaCorreo(oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "mailVSC"),
                               oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "NameVSC"),
                               "Error en: " + Membership.ApplicationName,
                               errMail);
         * 
        EnvioMail enviar = new EnvioMail();
        CallCenterDB.lms.enviarmail.Datos d = new CallCenterDB.lms.enviarmail.Datos();
        d.FromMail = "contacto@triangulopremia.com.mx";
        d.FromName = "Contacto Triangulo Premia";
        d.ToMail = "alina.sanchez@lms-la.com";
        d.ToName = "Alina Sánchez";
        d.Subject = "Triangulo Premia - Error en: " + Membership.ApplicationName;
        d.Body = errMail;
        CallCenterDB.lms.enviarmail.Datos[] arrDatos = new CallCenterDB.lms.enviarmail.Datos[1];
        arrDatos[0] = d;
        Respuesta r = enviar.Enviar(arrDatos);
         * */
    }
}
