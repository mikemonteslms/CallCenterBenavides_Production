using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class BLStatus
    {
        public static List<Status> ObtenerLista()
        {
            List<Status> lstDatos = new List<Status>();
            try
            {
                lstDatos = DLStatus.ObtenerLista();
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }

        public static List<Status> ObtenerLista(bool OpcionTodos)
        {
            List<Status> lstDatos = new List<Status>();
            try
            {
                lstDatos.Add(new Status() { Descripcion = "TODOS", Id_status = -1 });
                lstDatos.AddRange(DLStatus.ObtenerLista());
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }
    }
}
