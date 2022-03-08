using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallCenterDB.Entidades
{
    public class Direccion
    {
        public string Calle
        { get; set; }
        public string NumeroExterior
        {get;set;}
        public string NumeroInterior
        {get;set;}
        public string EntreCalle
        { get; set; }
        public string YCalle
        { get;set; }
        public string Colonia
        { get; set; }
        public string Municipio
        { get;set; }
        public string Estado
        { get; set; }
        public string CodigoPostal
        { get; set; }
    }
}
