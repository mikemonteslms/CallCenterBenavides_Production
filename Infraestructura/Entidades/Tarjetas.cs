using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Tarjetas
    {
        private string tarjeta_StrID;
        private string tarjeta_StrMecanicas;
        private int tarjeta_IntParticipa;
        private string cliente_strUniqueIdentifier;
        private string cliente_strCedula;
        private string cliente_strPrimerNombre;
        private string cliente_strApellido1;
        private string cliente_strApellido2;
        private string cliente_strTelefono;
        
        
        public Tarjetas()
        {

        }
        public Tarjetas(string tarjetaStrID, string tarjetaStrMecanicas, int tarjetaIntParticipa,
                        string ClientestrUniqueIdentifier, string ClientestrCedula, string ClientestrPrimerNombre,
                        string ClientestrApellido1, string ClientestrApellido2, string ClientestrTelefono)
        {
            this.tarjeta_StrID = tarjetaStrID;
            this.tarjeta_StrMecanicas = tarjetaStrMecanicas;
            this.tarjeta_IntParticipa = tarjetaIntParticipa;
            this.Cliente_strUniqueIdentifier = ClientestrUniqueIdentifier;
            this.Cliente_strCedula = ClientestrCedula;
            this.Cliente_strPrimerNombre = ClientestrPrimerNombre;
            this.Cliente_strApellido1 = ClientestrApellido1;
            this.Cliente_strApellido2 = ClientestrApellido2;
            this.Cliente_strTelefono = ClientestrTelefono;
        }
        public String Tarjeta_StrID
        {
            get { return tarjeta_StrID; }
            set { tarjeta_StrID = value; }
        }
        public string Tarjeta_StrMecanicas
        {
            get { return tarjeta_StrMecanicas; }
            set { tarjeta_StrMecanicas = value; }
        }
        public int Tarjeta_IntParticipa
        {
            get { return tarjeta_IntParticipa; }
            set { tarjeta_IntParticipa = value; }
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

    public class TarjetaCliente
    {
        private string error = "";
        private string mensaje = "";
        private int paqueteentrega = 0;
        private int totalRegistros = 0;
        private string clienteID;
        private string tarjetaID;
        private string apellidoP;
        private string apellidoM;
        private string nombre;
        private string fechaAlta; 
        private string cedula;
        private string telefono;
        private string medico;
        private string idsucursal;
        private string mecanicas;

        public TarjetaCliente()
        {

        }
        public TarjetaCliente(string error, string mensaje, int totalRegistros, int paqueteentrega, string clienteID,
                                string tarjetaID, string apellidoP, string apellidoM, string nombre,
                                string fechaAlta, string cedula, string telefono, string medico, string idsucursal, string mecanicas)
        {
            this.error = error;
            this.mensaje = mensaje;
            this.totalRegistros = totalRegistros;
            this.paqueteentrega = paqueteentrega;
            this.ClienteID=clienteID;
            this.TarjetaID= tarjetaID;
            this.apellidoP= apellidoP ;
            this.ApellidoM= apellidoM;
            this.Nombre = nombre;
            this.FechaAlta = fechaAlta; 
            this.Cedula = cedula;
            this.Telefono = telefono ;
            this.medico = medico;
            this.IDSucursal = idsucursal;
            this.Mecanicas =mecanicas;
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
        public int TotalRegistros
        {
            get { return totalRegistros; }
            set { totalRegistros = value; }
        }
        public int PaqueteEntrega
        {
            get { return paqueteentrega; }
            set { paqueteentrega = value; }
        }
        
        public String ClienteID
        {
            get { return clienteID; }
            set { clienteID = value; }
        }
        public String TarjetaID
        {
            get { return tarjetaID; }
            set { tarjetaID = value; }
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
        public String FechaAlta
        {
            get { return fechaAlta; }
            set { fechaAlta = value; }
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
        public String Medico
        {
            get { return medico; }
            set { medico = value; }
        }
        public String IDSucursal
        {
            get { return idsucursal; }
            set { idsucursal = value; }
        }
        public String Mecanicas
        {
            get { return mecanicas; }
            set { mecanicas = value; }
        }
    }

}
