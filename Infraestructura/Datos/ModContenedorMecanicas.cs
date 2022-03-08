using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Datos
{
    public class ModContenedorMecanicas
    {
        public ModContenedorMecanicas()
        {
            this.DTComentarios = new DataTable();
            this.lstMecanica = new List<ModMecanica>();
            this.lstBeneficios = new List<ModMecanica>();
            this.lstMecanicaDEPorc = new List<ModMecanicaDEPorc>();
        }
        public DataTable DTComentarios { get; set; }
        public List<ModMecanica> lstMecanica { get; set; }
        public List<ModMecanica> lstBeneficios { get; set; }
        public List<ModMecanicaDEPorc> lstMecanicaDEPorc { get; set; }
    }
}
