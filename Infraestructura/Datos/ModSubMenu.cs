using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModSubMenu
    {
        public int MenuId { get; set; }
        public int SubMenuId { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public string URL { get; set; }
        public string RoleId { get; set;}
        public string RoleIdNvo { get; set; }
        public string RoleName {get; set;}
     }
}
