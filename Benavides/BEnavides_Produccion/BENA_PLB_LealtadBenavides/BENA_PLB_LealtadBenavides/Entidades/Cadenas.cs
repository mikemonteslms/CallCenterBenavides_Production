using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Cadenas
    {
        
        private int cadenaIntID;
        private string cadena_strNombre;
        private int cadena_intParticipa;
        private int cadena_intTipoCadena;

        public Cadenas()
        {

        }
        public Cadenas(int cadenaIntID, string cadena_strNombre, int cadena_intParticipa,int cadena_intTipoCadena)
        {
            this.cadenaIntID = cadenaIntID;
            this.cadena_strNombre = cadena_strNombre;
            this.cadena_intParticipa = cadena_intParticipa;
            this.cadena_intTipoCadena= cadena_intTipoCadena;
        }
        public int CadenaIntID
        {
            get { return cadenaIntID; }
            set { cadenaIntID = value; }
        }
        public string Cadena_strNombre
        {
            get { return cadena_strNombre; }
            set { cadena_strNombre = value; }
        }
        public int Cadena_intParticipa
        {
            get { return cadena_intParticipa; }
            set { cadena_intParticipa = value; }
        }
        public int Cadena_intTipoCadena
        {
            get { return cadena_intTipoCadena; }
            set { cadena_intTipoCadena = value; }
        }
        
    }
}
