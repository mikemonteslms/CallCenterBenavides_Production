using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Configuration;

namespace CallCenterDB
{
    public class csHistoricoVentas
    {
        protected csDataBase database;
        protected List<SqlParameter> parametros;
        protected SqlConnection conn;
        protected SqlTransaction tran;


        private string numero_tarjeta;
        private string clave_sucursal;
        private string tipo_transaccion;
        private string area_departamento;
        private string factura;
        private DateTime fecha_factura;
        private string producto_clave;
        private string producto_descripcion;
        private double cantidad;
        private double precio_unitario;
        private double importe;
        private double impuesto;
        private double total;
        private DateTime fecha_captura;
        private string tipo_pago;
        private DateTime? fecha_pago;
        private string status;
        private DateTime fecha_status;
        private string clave_persona;
        private string nombre_persona;


        public string Numero_tarjeta
        {
            get { return numero_tarjeta; }
            set { numero_tarjeta = value; }
        }
        public string Clave_sucursal
        {
            get { return clave_sucursal; }
            set { clave_sucursal = value; }
        }
        public string Tipo_transaccion
        {
            get { return tipo_transaccion; }
            set { tipo_transaccion = value; }
        }
        public string Area_departamento
        {
            get { return area_departamento; }
            set { area_departamento = value; }
        }
        public string Factura
        {
            get { return factura; }
            set { factura = value; }
        }
        public DateTime Fecha_factura
        {
            get { return fecha_factura; }
            set { fecha_factura = value; }
        }
        public string Producto_clave
        {
            get { return producto_clave; }
            set { producto_clave = value; }
        }
        public string Producto_descripcion
        {
            get { return producto_descripcion; }
            set { producto_descripcion = value; }
        }
        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        public double Precio_unitario
        {
            get { return precio_unitario; }
            set { precio_unitario = value; }
        }
        public double Importe
        {
            get { return importe; }
            set { importe = value; }
        }
        public double Impuesto
        {
            get { return impuesto; }
            set { impuesto = value; }
        }
        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        public DateTime Fecha_captura
        {
            get { return fecha_captura; }
            set { fecha_captura = value; }
        }
        public string Tipo_pago
        {
            get { return tipo_pago; }
            set { tipo_pago = value; }
        }
        public DateTime? Fecha_pago
        {
            get { return fecha_pago; }
            set { fecha_pago = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public DateTime Fecha_status
        {
            get { return fecha_status; }
            set { fecha_status = value; }
        }
        public string Clave_persona
        {
            get { return clave_persona; }
            set { clave_persona = value; }
        }
        public string Nombre_persona
        {
            get { return nombre_persona; }
            set { nombre_persona = value; }
        }

        public void Inserta()
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@numero_tarjeta", numero_tarjeta));
            parametros.Add(new SqlParameter("@clave_sucursal", Clave_sucursal));
            parametros.Add(new SqlParameter("@tipo_transaccion", tipo_transaccion));
            parametros.Add(new SqlParameter("@area_departamento", area_departamento));
            parametros.Add(new SqlParameter("@factura", factura));
            parametros.Add(new SqlParameter("@fecha_factura", fecha_factura));
            parametros.Add(new SqlParameter("@producto_clave", producto_clave));
            parametros.Add(new SqlParameter("@producto_descripcion", producto_descripcion));
            parametros.Add(new SqlParameter("@cantidad", cantidad));
            parametros.Add(new SqlParameter("@precio_unitario", precio_unitario));
            parametros.Add(new SqlParameter("@importe", importe));
            parametros.Add(new SqlParameter("@impuesto", impuesto));
            parametros.Add(new SqlParameter("@total", total));
            parametros.Add(new SqlParameter("@fecha_captura", DateTime.Now));
            parametros.Add(new SqlParameter("@tipo_pago", tipo_pago));
            parametros.Add(new SqlParameter("@fecha_pago", fecha_pago));
            parametros.Add(new SqlParameter("@status", status));
            parametros.Add(new SqlParameter("@fecha_status", fecha_status));
            parametros.Add(new SqlParameter("@clave_persona", clave_persona));
            parametros.Add(new SqlParameter("@nombre_persona", nombre_persona));
            database = new csDataBase();
            if (this.conn != null)
            {
                database.Conexion = conn;
            }
            if (this.tran != null)
            {
                database.Transaccion = tran;
            }
            database.Query = "sp_inserta_historico_ventas_galenia";
            database.Parametros = parametros;
            database.EsStoreProcedure = true;
            database.acutualizaDatos();
        }
        public void CalculaPuntosMecanicas()
        {
            csParticipanteComplemento part = new csParticipanteComplemento();
            DataTable programa = part.consultaDatosPrograma(WebConfigurationManager.AppSettings["programa"]);

            string fecha_calculo = DateTime.Now.ToShortDateString();
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@programa_id", programa.Rows[0]["id"]));
            parametros.Add(new SqlParameter("@fecha_calculo", fecha_calculo));
            parametros.Add(new SqlParameter("@referencia", factura));
            database = new csDataBase();
            if (this.conn != null)
            {
                database.Conexion = conn;
            }
            if (this.tran != null)
            {
                database.Transaccion = tran;
            }
            database.Query = "sp_calculo_puntos_mecanicas";
            database.Parametros = parametros;
            database.EsStoreProcedure = true;
            database.acutualizaDatos();
        }
    }
}
