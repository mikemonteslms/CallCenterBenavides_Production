using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CNegocio
{
    public class Transaccion
    {
        public int ID { get; set; }
        public int PacienteID { get; set; }
        public string PacienteNombre { get; set; }
        public string Cuenta { get; set; }
        public string Descripcion { get; set; }
        public int MedicoID { get; set; }
        public string MedicoNombre { get; set; }
        public string Factura { get; set; }
        public string Tarjeta { get; set; }
        public DateTime Fecha { get; set; }
        public double Importe { get; set; }
        public Guid UsuarioBaja { get; set; }
        public DateTime FechaBaja { get; set; }
    }
    public class csValidarTransaccion
    {
        public static List<Transaccion> Consulta()
        {
            DataTable dt = CallCenterDB.csValidarTransacciones.Consulta();
            var transacciones = (from t in dt.AsEnumerable()
                                select new Transaccion
                                {
                                    ID = Convert.ToInt32(t["id"]),
                                    PacienteID = Convert.ToInt32(t["paciente_id"]),
                                    PacienteNombre = t["paciente_nombre"].ToString(),
                                    Cuenta = t["cuenta"].ToString(),
                                    Descripcion = t["descripcion"].ToString(),
                                    MedicoID = Convert.ToInt32(t["medico_id"]),
                                    MedicoNombre = t["medico_nombre"].ToString(),
                                    Factura = t["factura"].ToString(),
                                    Tarjeta = t["tarjeta"].ToString(),
                                    Fecha = Convert.ToDateTime(t["fecha"]),
                                    Importe = Convert.ToDouble(t["importe"])
                                }).ToList();
            return transacciones;
        }
        public static bool Modifica(int id, double importe)
        {
            return CallCenterDB.csValidarTransacciones.Modificar(id, importe);
        }
        public static bool Autoriza(int id, Guid usuario_id)
        {
            return CallCenterDB.csValidarTransacciones.Autorizar(id, usuario_id);
        }
    }
}
