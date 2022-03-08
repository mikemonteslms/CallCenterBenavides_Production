using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{

    public class EntActualizarCliente
    {
        public string IdCliente { get; set; }

        public string Telefono { get; set; }

        public string TelefonoCelular { get; set; }

        public string Calle { get; set; }

        public string NoExterior { get; set; }

        public string NoInterior { get; set; }

        public string idEstado { get; set; }

        public string idMunicipio { get; set; }

        public string idColonia { get; set; }

        public string CP { get; set; }

        public string CorreoElectronico { get; set; }

        public string Genero { get; set; }

        public int idSexo { get; set; }

        public string Sexo { get; set; }

        public string Tipo { get; set; }

        public string tarjeta { get; set; }

        public string contraseñaActual { get; set; }

        public string nuevaContraseña { get; set; }

        public string confirmaContraseña { get; set; }

        public string fechaNacimiento { get; set; }
 
    }

}
