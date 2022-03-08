using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;

namespace Negocio
{
    public class NegReportes
    {
        DatReportes datDT = new DatReportes();
        DataTable objDT = new DataTable();

        public DataTable CargarDataTable(string nombreSP)
        {
            try
            {
                DatReportes datos = new DatReportes();
                //EntActualizarCliente ent = new EntActualizarCliente();
                DataTable dt = datos.ObtenerDataTable(nombreSP);
                return dt;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public DataTable CargarDataTable(string nombreSP, int parametro)
        {
            try
            {
                DatReportes datos = new DatReportes();
                //EntActualizarCliente ent = new EntActualizarCliente();
                DataTable dt = datos.ObtenerDataTable(nombreSP, parametro);
                return dt;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
        
        public DataTable CargarDataTable(string nombreSP, string var1, string var2)
        {
            try
            {
                DatReportes datos = new DatReportes();
                //EntActualizarCliente ent = new EntActualizarCliente();
                DataTable dt = datos.ObtenerDataTable(nombreSP, var1, var2);
                return dt;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

       

    }
}
