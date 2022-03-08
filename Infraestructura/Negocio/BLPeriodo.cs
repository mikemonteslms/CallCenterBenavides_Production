using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORMModel;
using Entidades;
using Datos;

namespace Negocio
{
    public class BLPeriodo
    {
        public static List<PeriodoM> ObtenerLista()
        {
            List<PeriodoM> lstDatos = new List<PeriodoM>();
            try
            {
                lstDatos = DLPeriodo.ObtenerLista();
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }

        public static List<PeriodoM> ObtenerLista(bool OpcionTodos)
        {
            List<PeriodoM> lstDatos = new List<PeriodoM>();
            try
            {
                lstDatos.Add(new PeriodoM() { Id_Periodo = -1, Perido = "TODOS" });
                lstDatos.AddRange(DLPeriodo.ObtenerLista());
            }
            catch (Exception)
            {
                throw;
            }

            return lstDatos;
        }
    }
}
