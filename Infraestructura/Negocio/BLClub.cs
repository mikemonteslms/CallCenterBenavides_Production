using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNegocio
{
    public class BLClub
    {
        public static List<Club> ObtenerLista()
        {
            List<Club> lstDatos = new List<Club>();
            try
            {
                lstDatos = DLClub.ObtenerLista();
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }

        public static List<Club> ObtenerLista(bool OpcionTodos)
        {
            List<Club> lstDatos = new List<Club>();
            try
            {
                lstDatos.Add(new Club() { id_club = -1, descripcion = "TODOS" });
                lstDatos.AddRange(DLClub.ObtenerLista());
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }
    }
}
