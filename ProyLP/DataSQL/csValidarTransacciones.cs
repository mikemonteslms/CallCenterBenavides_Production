using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CallCenterDB
{
    public class csValidarTransacciones
    {
        public csValidarTransacciones() { }
        public static DataTable Consulta()
        {
            csDataBase query = new csDataBase();
            query.Query = "select * from historico_transacciones where usuario_baja_id is null and fecha_baja is null";
            query.EsStoreProcedure = false;
            DataTable dt = query.dtConsulta();
            return dt;
        }
        public static bool Modificar(int id, double importe)
        {
            csDataBase query = new csDataBase();
            query.Query = "update historico_transacciones set importe = @importe where id = @id";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@importe", importe));
            param.Add(new SqlParameter("@id", id));
            query.Parametros = param;
            query.EsStoreProcedure = false;
            bool modifica = query.acutualizaDatos() > 0;
            return modifica;
        }
        public static bool Autorizar(int id, Guid usuario_id)
        {
            csDataBase query = new csDataBase();
            query.Query = "update historico_transacciones set usuario_baja_id = @usuario_id, fecha_baja = getdate() where id = @id";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@usuario_id", usuario_id));
            param.Add(new SqlParameter("@id", id));
            query.Parametros = param;
            query.EsStoreProcedure = false;
            bool autoriza = query.acutualizaDatos() > 0;
            return autoriza;
        }
    }
}
