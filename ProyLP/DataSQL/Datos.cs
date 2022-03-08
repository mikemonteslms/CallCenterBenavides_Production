using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Collections;
using System.IO;

/// <summary>
/// Summary description for csDatos
/// </summary>
public class Datos
{
    public Datos()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string numerosIniciales(string numInicial)
    {
        string numIniciales = "";
        XmlDocument bd = new XmlDocument();
        try
        {
            bd.Load(HttpContext.Current.Server.MapPath("./App_Data/datosContacto.xml"));
            XmlNodeList nodo = bd.GetElementsByTagName("cadContacto");
            foreach (XmlElement nodo1 in nodo)
            {
                numIniciales = nodo1.GetAttribute(numInicial);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return numIniciales;
    }
    public string numerosIniciales(string archivo, string tag, string atributo)
    {
        string numIniciales = "";
        XmlDocument bd = new XmlDocument();
        try
        {
            bd.Load(HttpContext.Current.Server.MapPath("~/App_Data/" + archivo));
            XmlNodeList nodo = bd.GetElementsByTagName(tag);
            foreach (XmlElement nodo1 in nodo)
            {
                numIniciales = nodo1.GetAttribute(atributo);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return numIniciales;
    }

}


