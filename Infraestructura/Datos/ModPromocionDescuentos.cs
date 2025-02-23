﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModPromocionDescuentos
    {
        public int IdPDescuento { get; set; }
        public string NombrePromocion { get; set; }
        public decimal Cantidad { get; set; }
        public Int32 IdPeriodo { get; set; }
        public Int32 Limite { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int ServicioDomicilio { get; set; }
        public int SurtirConsultorio { get; set; }
        public int Inapam { get; set; }
        public int AcumulacionBase { get; set; }
        public int AcumulacionPiezas { get; set; }
        public int DuracionCupon { get; set; }
        public string UsuarioRegistra { get; set; }

    }
}
