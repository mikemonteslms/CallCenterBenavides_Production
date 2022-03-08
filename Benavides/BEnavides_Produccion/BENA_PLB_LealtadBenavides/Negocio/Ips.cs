using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class Ips
    {
        private int id;
        private string ip;
        private Boolean flag;
        private List<Ips> lista; 
        public Ips()
        {

        }
        public Ips(int consecutivo, string ip, Boolean bandera)
        {
            this.id = consecutivo;
            this.ip = ip;
            this.flag = bandera;
        }
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public Boolean Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
            }
        }

        public List<Ips> ListaIps
        {
            get
            {
                return lista;
            }
            set
            {
                lista = value;
            }
        }

        public string IP
        {
            get
            {
                return this.ip;
            }
            set
            {
                this.ip = value;
            }
        }

        public Boolean Contiene(string ip)
        {
            Ips ipbuscar = lista.Find(delegate(Ips pr)
            {
                if (pr.IP == ip)
                {
                    return true;
                }
                return false;
            }
            );
            if (ipbuscar != null)
                return true;
            else
                return false;
        }
        public Ips Busca(string ip)
        {
            return lista.Find(delegate(Ips pr)
            {
                if (pr.IP == ip)
                {
                    return true;
                }
                return false;
            }
            );
        }
    }

}
