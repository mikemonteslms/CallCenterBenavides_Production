using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
  public  class DetalleCanjesParticipante
    {
        public DetalleCanjesParticipante()
        { 
        }

        public string TransaccionPremioID { get; set; }
        public string FechaCanje { get; set; }
        public string DescripcionPremio { get; set; }
        public string Puntos { get; set; }
        public string StatusActual { get; set; }
        public string ClaveStatusRMS { get; set; }
        public string Mensajeria { get; set; }
        public string NumeroGuia { get; set; }
        public string Folio {get;set;}
        public string EstatusAnterior{get;set;}
        public string Observaciones {get;set;}
        public string FechaEntrega { get; set; }

      
    }

    public class ListDetalleCanjesParticipante{
     public List<DetalleCanjesParticipante> ListDetalle { get; set; }
        public string error { get; set; }
        }

