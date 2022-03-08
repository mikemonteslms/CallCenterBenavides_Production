using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CallCenterDB;
using ORMModel;
using Datos;

namespace CNegocio
{
    public class BLTipoPrecio
    {
        /*Obtiene la  lista  de  tipos de operaciones disponibles*/
        public static List<TipoPrecio> ObtenerLista()
        {
            List<TipoPrecio> lstDatos = new List<TipoPrecio>();
            try
            {
                lstDatos = DLTipoPrecio.ObtenerLista();
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }
    }
}
