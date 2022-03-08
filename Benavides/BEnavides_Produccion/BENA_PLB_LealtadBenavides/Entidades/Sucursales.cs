using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Sucursales
    {
        private int cadenaIntID;
        private string sucursal_StrID;
        private string sucursal_StrNombre;
        private int sucursal_IntParticipa;
        
        
        public Sucursales()
        {

        }
        public Sucursales(int cadenaIntID, string sucursalStrID, string sucursalStrNombre, int sucursalIntParticipa)
        {
            this.cadenaIntID = cadenaIntID;
            this.sucursal_StrID = sucursalStrID;
            this.sucursal_StrNombre = sucursalStrNombre;
            this.sucursal_IntParticipa = sucursalIntParticipa;
        }
        public int Cadena_IntID
        {
            get { return cadenaIntID; }
            set { cadenaIntID = value; }
        }
        public string Sucursal_StrID
        {
            get { return sucursal_StrID; }
            set { sucursal_StrID = value; }
        }
        public string Sucursal_StrNombre
        {
            get { return sucursal_StrNombre; }
            set { sucursal_StrNombre = value; }
        }
        public int Sucursal_IntParticipa
        {
            get { return sucursal_IntParticipa; }
            set { sucursal_IntParticipa = value; }
        }
    }
}
