using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModPromocionesDENoIniciadas
    {
        public int  Idmecanica {get; set;}
        public int IdTipoPromocion {get; set;}
        public string CodigoInterno {get; set;}
        public float Cantidad  {get; set;}
        public string NombreMecanica {get; set;}
        public string FechaInicio {get; set;}
        public string FechaFin {get; set;}
        public string Comentarios  {get; set;}
        public string Usuario  {get; set;}
        public int VerEnReporte { get; set; }
    }
}
