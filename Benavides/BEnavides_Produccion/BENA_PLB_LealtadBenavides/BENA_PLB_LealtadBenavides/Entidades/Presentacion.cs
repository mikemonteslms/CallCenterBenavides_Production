using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Presentacion
    {
       
        private string presentacionStrSKU;
        private string  productoStrID;
        private string presentacionStrID;
        private string  presentacionStrDescripcion;
        private string presentacionStrSKUBeneficio;
        private int presentacionIntCantidadCompra;
        private int presentacionIntCantidadBeneficio;
        private int presentacionIntLimiteMensual;
        private int presentacionIntStatus;
        private int presentacion_intDiasPeriodo;
        private int presentacion_intTipoProducto;
        private double presentacion_decDescuento;
        private double presentacion_decMontototal;
        private double presentacion_decMontoDescuento;
        private double presentacion_decAPagar;
        
        public Presentacion()
        {

        }


        public Presentacion(string presentacionStrSKU, string productoStrID, string presentacionStrID, 
                string presentacionStrDescripcion, string presentacionStrSKUBeneficio, int presentacionIntCantidadCompra, 
                int presentacionIntCantidadBeneficio, int presentacionIntLimiteMensual, int presentacionIntStatus, 
                int presentacion_intDiasPeriodo, double presentacion_decDescuento,int presentacion_intTipoProducto,
                double presentacion_decMontototal, double presentacion_decMontoDescuento, double presentacion_decAPagar)
        {
            this.presentacionStrSKU = presentacionStrSKU;
            this.productoStrID = productoStrID;
            this.presentacionStrID = presentacionStrID;
            this.presentacionStrDescripcion = presentacionStrDescripcion;
            this.presentacionStrSKUBeneficio=presentacionStrSKUBeneficio;
            this.presentacionIntCantidadCompra=presentacionIntCantidadBeneficio;
            this.presentacionIntCantidadBeneficio=presentacionIntCantidadBeneficio;
            this.presentacionIntLimiteMensual=presentacionIntLimiteMensual;
            this.presentacionIntStatus = presentacionIntStatus;
            this.presentacion_intDiasPeriodo = presentacion_intDiasPeriodo;
            this.presentacion_decDescuento = presentacion_decDescuento;
            this.Presentacion_intTipoProducto=presentacion_intTipoProducto;
            this.presentacion_decMontototal = presentacion_decMontototal;
            this.presentacion_decMontoDescuento = presentacion_decMontoDescuento;
            this.presentacion_decAPagar = presentacion_decAPagar;
            
        }
        public string PresentacionStrSKU
        {
            get { return presentacionStrSKU; }
            set { presentacionStrSKU = value; }
        }
        public string ProductoStrID
        {
            get { return productoStrID; }
            set { productoStrID = value; }
        }
        public string PresentacionStrID
        {
            get { return presentacionStrID; }
            set { presentacionStrID = value; }
        }

        public string  PresentacionStrDescripcion
        {
            get { return presentacionStrDescripcion; }
            set { presentacionStrDescripcion = value; }
        }
        public string PresentacionStrSKUBeneficio
        {
            get { return presentacionStrSKUBeneficio; }
            set { presentacionStrSKUBeneficio = value; }
        }
        public int PresentacionIntCantidadCompra
        {
            get { return presentacionIntCantidadCompra; }
            set { presentacionIntCantidadCompra = value; }
        }
        public int PresentacionIntCantidadBeneficio
        {
            get { return presentacionIntCantidadBeneficio; }
            set { presentacionIntCantidadBeneficio = value; }
        }
        public int PresentacionIntLimiteMensual
        {
            get { return presentacionIntLimiteMensual; }
            set { presentacionIntLimiteMensual = value; }
        }
        public int PresentacionIntStatus
        {
            get { return presentacionIntStatus; }
            set { presentacionIntStatus = value; }
        }
        public int Presentacion_intDiasPeriodo
        {
            get { return presentacion_intDiasPeriodo; }
            set { presentacion_intDiasPeriodo = value; }
        }

        public double Presentacion_decDescuento
        {
            get { return presentacion_decDescuento; }
            set { presentacion_decDescuento = value; }
        }

        public double Presentacion_decMontototal
        {
            get { return presentacion_decMontototal; }
            set { presentacion_decMontototal = value; }
        }
        public double Presentacion_decMontoDescuento
        {
            get { return presentacion_decMontoDescuento; }
            set { presentacion_decMontoDescuento = value; }
        }
        public double Presentacion_decAPagar
        {
            get { return presentacion_decAPagar; }
            set { presentacion_decAPagar = value; }
        }
        public int Presentacion_intTipoProducto
        {
            get { return presentacion_intTipoProducto; }
            set { presentacion_intTipoProducto = value; }
        }
        
  
    }
}
