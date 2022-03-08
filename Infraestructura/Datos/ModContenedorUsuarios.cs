using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos
{
    public class ModContenedorUsuarios
    {
        public ModContenedorUsuarios() 
        {
            this.Usuarios = new ModUsuarioapp();
            this.lstRoles = new List<ModRoles>();
        }
        public ModUsuarioapp Usuarios { get; set; }
        public List<ModRoles> lstRoles { get; set; }
    }
}
