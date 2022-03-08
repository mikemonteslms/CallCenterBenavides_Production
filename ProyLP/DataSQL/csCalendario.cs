using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public class csCalendario
{
    CallCenterDB.Linq.CalendarioDataContext cal;
    protected csDataBase database;
    protected SqlConnection conn;
    private SqlTransaction tran;
    private String fecha;

    public csCalendario()
    {

    }

    public string Fecha
    {
        get
        {
            return fecha;
        }
        set
        {
            fecha = value;
        }
    }

    public List<Calendario> Consulta()
    {
        List<Calendario> lista = new List<Calendario>();
        using (cal = new CallCenterDB.Linq.CalendarioDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var calendario = from c in cal.calendario select new {c.id, c.fecha, c.descripcion, c.descripcion_larga};
            foreach (var _c in calendario.AsEnumerable())
            {
                Calendario c = new Calendario(_c.id, Convert.ToDateTime(_c.fecha), _c.descripcion, _c.descripcion_larga);
                lista.Add(c);
            }
        }
        return lista;
    }

    public List<Calendario_Canje> ConsultaCanje()
    {
        List<Calendario_Canje> lista = new List<Calendario_Canje>();
        using (cal = new CallCenterDB.Linq.CalendarioDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var calendario = from c in cal.calendario_canje select new { c.id, c.fecha_inicial, c.fecha_final, c.descripcion, c.descripcion_larga };
            foreach (var _c in calendario.AsEnumerable())
            {
                Calendario_Canje c = new Calendario_Canje(_c.id, Convert.ToDateTime(_c.fecha_inicial), Convert.ToDateTime(_c.fecha_final), _c.descripcion, _c.descripcion_larga);
                lista.Add(c);
            }
        }
        return lista;
    }

    public void Obtiene_calendario_fecha(String descripcion)
    {
        database = new csDataBase();
        List<SqlParameter> param = new List<SqlParameter>();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "Obtiene_calendario_fecha";
        param.Add(new SqlParameter("@descripcion", descripcion));
        database.Parametros = param;
        database.EsStoreProcedure = true;
        DataTable dtObtiene_calendario = database.dtConsulta();
        if (dtObtiene_calendario.Rows.Count > 0)
        {
            DataRow drdtObtiene_calendario = dtObtiene_calendario.Rows[0];
            fecha = drdtObtiene_calendario["fecha"].ToString();
        }
    }

    public void Obtiene_calendario_canje_fecha(int program_id,String fecha_hoy)
    {
        database = new csDataBase();
        List<SqlParameter> param = new List<SqlParameter>();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "Obtiene_calendario_canje_fecha";
        param.Add(new SqlParameter("@programa_id", program_id));
        param.Add(new SqlParameter("@fecha", fecha_hoy));
        database.Parametros = param;
        database.EsStoreProcedure = true;
        DataTable dtObtiene_calendario_canje = database.dtConsulta();
        if (dtObtiene_calendario_canje.Rows.Count > 0)
        {
            DataRow drdtObtiene_calendario = dtObtiene_calendario_canje.Rows[0];
            fecha = drdtObtiene_calendario["fecha_final"].ToString();
        }
    }
}
