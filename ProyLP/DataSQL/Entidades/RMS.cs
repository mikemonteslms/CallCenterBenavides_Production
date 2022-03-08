using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallCenterDB.Entidades
{
    public class RMS
    {
        public string PedidoLMS
        { get; set; }

        public string PedidoRMS
        { get; set; }

        public string FoliosTotales
        { get; set; }

        public string FoliosCorrectos
        { get; set; }

        public string FoliosErroneos
        { get; set; }

        public string Duplicados
        { get; set; }

        public string FueraRango
        { get; set; }

        public string SinFolio
        { get; set; }

        public string Proveedores
        { get; set; }

        public string Sucursal
        { get; set; }
    }
}
