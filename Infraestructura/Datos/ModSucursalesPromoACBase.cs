using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModSucursalesPromoACBase
    {
        public int IdPABase { get; set; }
        public int Sucursal { get; set; }
        public string strSucursal { get; set; }
        public int SucursalAnt { get; set; }
        public string NomSucursal { get; set; }
        public int SucursalNva { get; set; }
        public int IdStatus { get; set; }
    }
}
