using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    class Clientes
    {
        private string cliente_strUniqueIdentifier;
        private string cliente_strApellido1;
        private string cliente_strApellido2;
        private string cliente_strPrimerNombre;
        private string cliente_strCedula;
        private string cliente_strTelefono;
                
        public Clientes()
        {

        }
        public Clientes(string ClientestrUniqueIdentifier, string ClientestrCedula, string ClientestrPrimerNombre,
                        string ClientestrApellido1, string ClientestrApellido2, string ClientestrTelefono)
        {
            this.Cliente_strUniqueIdentifier = ClientestrUniqueIdentifier;
            this.Cliente_strCedula = ClientestrCedula;
            this.Cliente_strPrimerNombre = ClientestrPrimerNombre;
            this.Cliente_strApellido1 = ClientestrApellido1;
            this.Cliente_strApellido2 = ClientestrApellido2;
            this.Cliente_strTelefono = ClientestrTelefono;
        }

        public string Cliente_strUniqueIdentifier
        {
            get { return cliente_strUniqueIdentifier; }
            set { cliente_strUniqueIdentifier = value; }
        }
        public string Cliente_strCedula
        {
            get { return cliente_strCedula; }
            set { cliente_strCedula = value; }
        }
        public string Cliente_strPrimerNombre
        {
            get { return cliente_strPrimerNombre; }
            set { cliente_strPrimerNombre = value; }
        }
        public string Cliente_strApellido1
        {
            get { return cliente_strApellido1; }
            set { cliente_strApellido1 = value; }
        }
        public string Cliente_strApellido2
        {
            get { return cliente_strApellido2; }
            set { cliente_strApellido2 = value; }
        }
        public string Cliente_strTelefono
        {
            get { return cliente_strTelefono; }
            set { cliente_strTelefono = value; }
        }
    }

    public class Cliente
    {
        private string error = "";
        private string mensaje = "";
        private string clienteID;
        private string apellidoP;
        private string apellidoM;
        private string nombre;
        private string cedula;
        private string telefono;

        public Cliente()
        {

        }
        public Cliente(string error, string mensaje, string clienteID,
                                string apellidoP, string apellidoM, string nombre,
                                string cedula, string telefono)
        {
            this.error = error;
            this.mensaje = mensaje;
            this.ClienteID=clienteID;
            this.apellidoP= apellidoP ;
            this.ApellidoM= apellidoM;
            this.Nombre = nombre;
            this.Cedula = cedula;
            this.Telefono = telefono ;
        }
        public String Error
        {
            get { return error; }
            set { error = value; }
        }
        public String Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
     
        public String ClienteID
        {
            get { return clienteID; }
            set { clienteID = value; }
        }
        public String ApellidoP
        {
            get { return apellidoP; }
            set { apellidoP = value; }
        }
        public String ApellidoM
        {
            get { return apellidoM ; }
            set { apellidoM = value; }
        }
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public String Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }
        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
    }

}
