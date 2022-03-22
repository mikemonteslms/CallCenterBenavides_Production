using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModContenedorMnusSubmnus
    {
        public ModContenedorMnusSubmnus()
        {
            this.Submnus = new List<ModSubmnus>();
        }
        public List<ModMenus> Menus { get; set; }
        public List<ModSubmnus> Submnus { get; set; }
    }
}
