using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ORMModel;
using System.Configuration;


namespace CallCenterDB
{
    public class DLConfiguracion
    {

        public static string RecuperarParametroConfiguracion(string nombreParametro)
        {

            if (String.IsNullOrEmpty(nombreParametro))
            {
                throw new Exception("Debe especificar un parámetro");
            }

            return ConfigurationManager.AppSettings[nombreParametro];
        }

    }
}
