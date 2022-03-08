using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Text;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// Summary description for Funciones
/// </summary>
/// 
public class Funciones
{
    public Funciones()
    {
    }

    public void muestraMensaje(Page pagina, string mensaje)
    {
        StringBuilder str = new StringBuilder();
        str.Append("alert('" + mensaje + "');");
        pagina.ClientScript.RegisterStartupScript(typeof(Page), "msg", str.ToString(), true);
    }

    public void creaJavascript(Page pagina, string nombre, string argumentos, string contenido)
    {
        StringBuilder str = new StringBuilder();
        str.Append("function " + nombre + "(" + argumentos + "){" +
                    contenido +
                   "}" +
                      nombre + "(" + argumentos + ");");
        pagina.ClientScript.RegisterStartupScript(typeof(Page), "fn", str.ToString(), true);
    }
    public void ejecutaJavascript(Page pagina, string nombre, string argumentos)
    {
        StringBuilder str = new StringBuilder();
        str.Append(nombre + " (" + argumentos + ");");
        pagina.ClientScript.RegisterStartupScript(typeof(Page), "fn", str.ToString(), true);
    }
    public string generaCadenaAleatoria(int maxSize)
    {
        char[] chars = new char[62];
        chars =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        byte[] data = new byte[1];
        RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        crypto.GetNonZeroBytes(data);
        data = new byte[maxSize];
        crypto.GetNonZeroBytes(data);
        StringBuilder result = new StringBuilder(maxSize);
        foreach (byte b in data)
        {
            result.Append(chars[b % (chars.Length - 1)]);
        }
        return result.ToString();
    }
    public string generaCadenaAleatoria()
    {
        byte[] bytSalt = new byte[8];
        RNGCryptoServiceProvider rng;
        rng = new RNGCryptoServiceProvider();
        rng.GetBytes(bytSalt);
        return Convert.ToBase64String(bytSalt);
    }
    public string generaPassword(int maxSize)
    {
        char[] chars = new char[76];
        chars =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        byte[] data = new byte[1];
        RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        crypto.GetNonZeroBytes(data);
        data = new byte[maxSize];
        crypto.GetNonZeroBytes(data);
        StringBuilder result = new StringBuilder(maxSize);
        foreach (byte b in data)
        {
            result.Append(chars[b % (chars.Length - 1)]);
        }
        return result.ToString();
    }
    #region EnviarCorreo
    /*
    public bool enviaCorreo(string paraMail, string paraNombre, string subject, string body)
    {
        bool msgEnviado = false;
        Datos oDatos = new Datos();
        System.Net.NetworkCredential credencial = new System.Net.NetworkCredential(
            oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "smtpCredentials"),
            oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "smptCredentialsPwd"));
        SmtpClient servidor = new SmtpClient();
        servidor.Host = oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "smtpServer");
        servidor.Credentials = credencial;
        servidor.Timeout = 180000;
        MailAddress from = new MailAddress(
            oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "fromMail"),
            oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "fromName"));
        MailAddress to = new MailAddress(paraMail, paraNombre);
        MailMessage mensaje = new MailMessage(from, to);
        mensaje.Subject = subject;
        mensaje.Body = body;
        mensaje.IsBodyHtml = true;
        try
        {
            servidor.Send(mensaje);
            msgEnviado = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return msgEnviado;
    }
    public bool enviaCorreo(List<MailAddress> to, List<MailAddress> cc, string subject, string body)
    {
        bool msgEnviado = false;
        Datos oDatos = new Datos();
        System.Net.NetworkCredential credencial = new System.Net.NetworkCredential(
            oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "smtpCredentials"),
            oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "smptCredentialsPwd"));
        SmtpClient servidor = new SmtpClient();
        servidor.Host = oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "smtpServer");
        servidor.Credentials = credencial;
        servidor.Timeout = 180000;
        MailAddress from = new MailAddress(
            oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "fromMail"),
            oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "fromName"));
        MailMessage mensaje = new MailMessage();
        mensaje.From = from;
        foreach (MailAddress t in to)
        {
            mensaje.To.Add(t);
        }
        foreach (MailAddress c in cc)
        {
            mensaje.CC.Add(c);
        }
        mensaje.Subject = subject;
        mensaje.Body = body;
        mensaje.IsBodyHtml = true;
        try
        {
            servidor.Send(mensaje);
            msgEnviado = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return msgEnviado;
    }
    public bool enviaCorreoPassword(string paraMail, string paraNombre, string subject, string body)
    {
        bool msgEnviado = false;
        Datos oDatos = new Datos();
        System.Net.NetworkCredential credencial = new System.Net.NetworkCredential(
            oDatos.numerosIniciales("smtpCredentials"),
            oDatos.numerosIniciales("smptCredentialsPwd"));
        SmtpClient servidor = new SmtpClient();
        servidor.Host = oDatos.numerosIniciales("smtpServer");
        servidor.Credentials = credencial;
        servidor.Timeout = 180000;
        MailAddress from = new MailAddress(
            oDatos.numerosIniciales("fromMail"),
            oDatos.numerosIniciales("fromName"));
        MailAddress to = new MailAddress(paraMail, paraNombre);
        MailMessage mensaje = new MailMessage(from, to);
        mensaje.Subject = subject;
        mensaje.Body = body;
        mensaje.IsBodyHtml = true;
        try
        {
            servidor.Send(mensaje);
            msgEnviado = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return msgEnviado;
    }
    // DHV
    public bool enviaCorreoPassword(string correo_electronico, string nombre, string login, string password, string nip, bool esNuevo)
    {
        bool msgEnviado = false;
        Datos oDatos = new Datos();
        System.Net.NetworkCredential credencial = new System.Net.NetworkCredential(
           oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "smtpCredentials"),
           oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "smptCredentialsPwd"));
        SmtpClient servidor = new SmtpClient();
        servidor.Host = oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "smtpServer");
        servidor.Credentials = credencial;
        MailAddress from = new MailAddress(oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "fromMail"),
                                           oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "fromName"));
        MailAddress to = new MailAddress(correo_electronico, nombre);
        MailMessage mensaje = new MailMessage(from, to);
        if (esNuevo) // Es usuario nuevo
        {
            mensaje.Subject = oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "subjectNuevo");
            mensaje.Body = string.Format(oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "bodyNuevo"), login, password, nip);
        }
        else   // Es para reestablecer password
        {
            mensaje.Subject = oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "subjectActualizado");
            mensaje.Body = string.Format(oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "bodyActualizado"), password);
        }
        mensaje.IsBodyHtml = true;
        try
        {
            servidor.Send(mensaje);
            msgEnviado = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return msgEnviado;
    }
    */
    #endregion

    public string passwordConHash(string password, string salt)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, "SHA1");
    }

    public string unifica(string palabra)
    {
        palabra = palabra.Replace("\\", "_");
        palabra = palabra.Replace(" ", "");
        palabra = palabra.Replace("á", "a");
        palabra = palabra.Replace("é", "e");
        palabra = palabra.Replace("í", "i");
        palabra = palabra.Replace("ó", "o");
        palabra = palabra.Replace("ú", "u");
        palabra = palabra.Replace("ã", "a");
        return palabra;

    }
    public string celda(int numero)
    {
        string letra = "";
        if (numero >= 26)
            letra = Convert.ToChar(64 + numero / 26).ToString() + Convert.ToChar(65 + numero % 26).ToString();
        else
            letra = Convert.ToChar(65 + numero).ToString();
        return letra;
    }

    public void descargaArchivo(string archivo, string nombre_archivo, string tipo)
    {
        System.Web.HttpContext.Current.Response.ContentType = tipo;
        System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombre_archivo);
        System.Web.HttpContext.Current.Response.TransmitFile(archivo);
        System.Web.HttpContext.Current.Response.End();
    }
    public string[] separaDatos(string txtConsulta)
    {
        char[] delimitador = { '\r', ' ', '\n' };
        string[] polizas = txtConsulta.Split(delimitador, StringSplitOptions.RemoveEmptyEntries);
        return polizas;
    }
    public string uneCadenas(string[] cadena, string separador, int tam)
    {
        string cad = "";
        for (int ind = 0; ind < cadena.GetLength(0); ind++)
        {
            if (ind < (cadena.GetLength(0) - 1))
            {
                if (cadena[ind].Length != tam)
                    cad += cadena[ind].Substring(1) + separador;
                else
                    cad += cadena[ind] + separador;
            }
            else
            {
                if (cadena[ind].Length != tam)
                    cad += cadena[ind].Substring(1);
                else
                    cad += cadena[ind];
            }
        }
        return cad;
    }

    public string getFecha()
    {
        return DateTime.Now.ToString("dd-MM-yyyy");
    }

    public string cadSinComilla(string cadena)
    {
        return cadena.Replace('\'', '"');
    }

    public string reemplazaCadenaCaracter(string cadena, char viejo, char nuevo)
    {
        return cadena.Replace(viejo, nuevo);
    }

    public string reemplazaAcentos(string texto)
    {
        if (string.IsNullOrEmpty(texto))
            return texto;
        byte[] tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(texto);
        return System.Text.Encoding.UTF8.GetString(tempBytes);
    }

    public string quitaENTER(string cadena)
    {
        string cadEnter = cadena;
        cadEnter = reemplazaCadenaCaracter(cadEnter, (char)10, ' ');
        cadEnter = reemplazaCadenaCaracter(cadEnter, (char)13, ' ');
        return cadEnter;
    }

    public bool guardarArchivo(string detalleEdoCta, string nombreArchivo)
    {
        string sFileName = System.Web.HttpContext.Current.Server.MapPath("./App_Data/" + nombreArchivo + ".html");
        bool guardado = false;
        try
        {
            //Si existe el archivo lo elimino para reemplazarlo
            if (File.Exists(sFileName))
                File.Delete(sFileName);

            //Indico el modo del archivo para crearlo y escribir
            FileStream fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.Write("{0}", detalleEdoCta);
            sw.Flush();
            sw.Close();
            fs.Close();
            guardado = true;
        }
        catch
        {
            sFileName = "";
        }
        return guardado;
    }
    public void creaPDF(string archivo)
    {
        System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
        pProcess.StartInfo.FileName = ConfigurationManager.AppSettings["rutaHTMLDOC"];
        pProcess.StartInfo.Arguments = "--webpage --bodyfont Helvetica -t pdf14 --permissions print,no-copy,no-modify,no-annotate -f " +
            System.Web.HttpContext.Current.Server.MapPath("./App_Data/" + archivo + ".pdf") + " " +
            System.Web.HttpContext.Current.Server.MapPath("./App_Data/" + archivo + ".html");
        pProcess.StartInfo.WorkingDirectory = System.Web.HttpContext.Current.Server.MapPath("./Bin");
        pProcess.Start();
        pProcess.WaitForExit();
    }

    public bool validaCPF(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;
        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "").Replace(" ", "");

        if ((cpf.Length != 11) || (String.Compare(cpf, "11111111111") == 0)
            || (String.Compare(cpf, "22222222222") == 0) || (String.Compare(cpf, "33333333333") == 0)
            || (String.Compare(cpf, "44444444444") == 0) || (String.Compare(cpf, "55555555555") == 0)
            || (String.Compare(cpf, "66666666666") == 0) || (String.Compare(cpf, "77777777777") == 0)
            || (String.Compare(cpf, "88888888888") == 0) || (String.Compare(cpf, "99999999999") == 0)
            || (String.Compare(cpf, "00000000000") == 0))
            return false;
        tempCpf = cpf.Substring(0, 9);
        soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = digito + resto.ToString();
        return cpf.EndsWith(digito);
    }

    public void guardalog(string Cadena)
    {
        StreamWriter writer;
        DateTime Fecha = DateTime.Now;
        String NombreLog = "Log" + Fecha.ToString("ddMMyyyy") + ".txt";

        string ruta = ConfigurationManager.AppSettings.Get("RutaLog").ToString() + NombreLog;

        writer = File.AppendText(ruta);

        writer.WriteLine(Fecha.ToString("dd/MM/yyyy hh:mm:ss tt ") + Cadena);
        writer.Close();
    }

    public string generaNumeroAleatorio(int maxSize)
    {
        char[] chars = new char[10];
        chars =
        "1234567890".ToCharArray();
        byte[] data = new byte[1];
        RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        crypto.GetNonZeroBytes(data);
        data = new byte[maxSize];
        crypto.GetNonZeroBytes(data);
        StringBuilder result = new StringBuilder(maxSize);
        foreach (byte b in data)
        {
            result.Append(chars[b % (chars.Length - 1)]);
        }
        return result.ToString();
    }
}
