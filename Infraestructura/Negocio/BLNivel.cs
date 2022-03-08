using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORMModel;
using Entidades;
using Datos;

namespace Negocio
{
    public class BLNivel
    {
        public static List<Nivel> ObtenerLista()
        {
            List<Nivel> lstDatos = new List<Nivel>();
            try
            {
                lstDatos = DLNivel.ObtenerLista();
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }

        public static List<Nivel> ObtenerLista(bool OpcionTodos)
        {
            List<Nivel> lstDatos = new List<Nivel>();
            try
            {
                lstDatos.Add(new Nivel() { IdNivel = -1, Descripcion = "TODOS" });
                lstDatos.AddRange(DLNivel.ObtenerLista());
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }
    }
}
