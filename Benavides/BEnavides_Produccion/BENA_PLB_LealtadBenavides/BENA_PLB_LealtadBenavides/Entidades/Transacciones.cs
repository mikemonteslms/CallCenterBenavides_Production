using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Transacciones
    {
        private string error;
        private string mensaje;
        private int totalRegistros;
        private int registroInsercion;
        private int transaccionIntID;
        private int cadenaIntID;
        private int sucursalIntID;
        private string sucursalStrID;
        private string tarjetaStrNumero;
        private string transaccionDateFecha;
        private string presentacionIntSKU;
        private string presentacionStrID;
        private int transaccionIntCantidad;
        private string transaccionStrTipoMov;
        private string transaccionStrSubTipoMov;
        
        public Transacciones()
        {
           
        }
        public Transacciones( string error,string mensaje,int totalRegistros,int registroInsercion, int transaccionIntID, int cadenaIntID,
         int sucursalIntID, string sucursal_StrID, string tarjetaStrNumero,  string transaccionDateFecha,
         string presentacionIntSKU, string PresentacionStrID, int transaccionIntCantidad,
         string transaccionStrTipoMov, string transaccionStrSubTipoMov)
        {
            this.error = error;
            this.mensaje = mensaje;
            this.totalRegistros = totalRegistros;
            this.registroInsercion = registroInsercion;
            this.transaccionIntID = transaccionIntID;
            this.cadenaIntID = cadenaIntID;
            this.sucursalIntID = sucursalIntID;
            this.sucursalStrID = sucursal_StrID;
            this.tarjetaStrNumero = tarjetaStrNumero;
            this.transaccionDateFecha = transaccionDateFecha;
            this.presentacionIntSKU = presentacionIntSKU;
            this.presentacionStrID = PresentacionStrID;
            this.transaccionIntCantidad = transaccionIntCantidad;
            this.transaccionStrTipoMov = transaccionStrTipoMov;
            this.transaccionStrSubTipoMov = transaccionStrSubTipoMov;
           
        }

        
        
        public string Error
        {
            get { return error; }
            set { error = value; }
        }
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }

       public int TotalRegistros
        {
            get { return totalRegistros; }
            set { totalRegistros = value; }
        }
        public int RegistroInsercion
        {
            get { return registroInsercion; }
            set { registroInsercion = value; }
        }
         

        public int TransaccionIntID
        {
            get { return transaccionIntID; }
            set { transaccionIntID = value; }
        }

        
        public int CadenaIntID
        {
            get { return cadenaIntID; }
            set { cadenaIntID = value; }
        }
        
        public int SucursalIntID
        {
            get { return sucursalIntID; }
            set { sucursalIntID = value; }
        }

        public string SucursalStrID
        {
            get { return sucursalStrID; }
            set { sucursalStrID = value; }
        }

        public string  TarjetaStrNumero
        {
            get { return tarjetaStrNumero; }
            set { tarjetaStrNumero = value; }
        } 


        
        public string  TransaccionDateFecha
        {
            get { return transaccionDateFecha; }
            set { transaccionDateFecha = value; }
        }

        public string PresentacionIntSKU
        {
            get { return presentacionIntSKU; }
            set { presentacionIntSKU = value; }
        }

        public string PresentacionStrID
        {
            get { return presentacionStrID; }
            set { presentacionStrID = value; }
        }

        public int TransaccionIntCantidad
        {
            get { return transaccionIntCantidad; }
            set { transaccionIntCantidad = value; }
        }
        public string TransaccionStrTipoMov
        {
            get { return transaccionStrTipoMov; }
            set { transaccionStrTipoMov = value; }
        }
        public string TransaccionStrSubTipoMov
        {
            get { return transaccionStrSubTipoMov; }
            set { transaccionStrSubTipoMov = value; }
        }
        
    }
}
