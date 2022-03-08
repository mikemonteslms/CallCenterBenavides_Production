using CallCenterDB;
using Datos;
using ORMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CNegocio
{
    public class BLCategoriaMecanica
    {
        public static List<CategoriaMecanica> ObtenerLista()
        {
            List<CategoriaMecanica> lstDatos = new List<CategoriaMecanica>();
            try
            {
                lstDatos = DLCategoriaMecanica.ObtenerLista();
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }
    }
}
