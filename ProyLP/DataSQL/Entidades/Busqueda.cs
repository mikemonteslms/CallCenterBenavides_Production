using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallCenterDB.Entidades
{
    public class Busqueda
    {
        public Busqueda()
        { }
        public Busqueda(string programa_id, string programa_clave, string programa_descripcion, 
                        string distribuidor_id, string distribuidor_clave, string distribuidor_descripcion,
                        string participante_id, string nombre, string apellido_paterno, string apellido_materno, string nombre_completo,
                        string puesto, string correo_electronico)
        {
            ProgramaID = programa_id;
            ProgramaClave = programa_clave;
            ProgramaDescripcion = programa_descripcion;
            DistribuidorID = distribuidor_id;
            DistribuidorClave = distribuidor_clave;
            DistribuidorDescripcion = distribuidor_descripcion;
            ParticipanteID = participante_id;
            Nombre = nombre;
            ApellidoPaterno = apellido_paterno;
            ApellidoMaterno = apellido_materno;
            NombreCompleto = nombre_completo;
            Puesto = puesto;
            CorreoElectronico = correo_electronico;
        }
        public string ProgramaID { get; set; }
        public string ProgramaClave { get; set; }
        public string ProgramaDescripcion { get; set; }
        public string DistribuidorID { get; set; }
        public string DistribuidorClave { get; set; }
        public string DistribuidorDescripcion { get; set; }
        public string ParticipanteID { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreCompleto { get; set; }
        public string Puesto { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
