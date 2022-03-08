using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public class csTransaccion
{
    protected csDataBase database;
    protected List<SqlParameter> parametros;
    protected SqlConnection conn;
    protected SqlTransaction tran;

    public string ParticipanteID
    {
        get;
        set;
    }
    public string UsuarioID
    {
        get;
        set;
    }
    public string TipoTransaccionID
    {
        get;
        set;
    }
    public string TipoTransaccion
    {
        get;
        set;
    }
    public int Puntos
    {
        get;
        set;
    }
    public DateTime Fecha
    {
        get;
        set;
    }

    public csTransaccion()
    {
    }

    public bool InsertaTransaccion()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", ParticipanteID));
        parametros.Add(new SqlParameter("@tipo_transaccion", TipoTransaccion));
        parametros.Add(new SqlParameter("@puntos", Puntos));
        parametros.Add(new SqlParameter("@fecha", Fecha));
        parametros.Add(new SqlParameter("@usuario_id", UsuarioID));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        string query = "sp_inserta_transaccion";
        database.Query = query;
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return (Convert.ToInt32(database.consultaDato()) > 0);
    }

    public void penalizaPuntosEncuesta(int participanteID)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@ParticipanteID", participanteID));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_penaliza_puntos_encuestaCol";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }
    public void AgregaPuntosEncuesta(int participanteID, Guid userID, decimal calificacion)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@ParticipanteID", participanteID));
        parametros.Add(new SqlParameter("@UserID", userID));
        parametros.Add(new SqlParameter("@Calificacion", calificacion));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_agrega_puntos_encuesta";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public void AgregaPuntosEncuesta(int participanteID, Guid userID, decimal calificacion, string bandera, int encuestaID)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@ParticipanteID", participanteID));
        parametros.Add(new SqlParameter("@UserID", userID));
        parametros.Add(new SqlParameter("@Calificacion", calificacion));
        parametros.Add(new SqlParameter("@Bandera", bandera));
        parametros.Add(new SqlParameter("@encuestaID", encuestaID));
        database = new csDataBase();

        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_agrega_puntos_encuestaCol";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public void AgregaPuntosQuiz_CO(string participante_id, string tipo_transaccion_id, decimal puntos, Guid aspnet_UserId, string encuesta_id)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        parametros.Add(new SqlParameter("@tipo_transaccion_id", tipo_transaccion_id));
        parametros.Add(new SqlParameter("@puntos", puntos));
        parametros.Add(new SqlParameter("@aspnet_UserId", aspnet_UserId));
        parametros.Add(new SqlParameter("@encuesta_id", encuesta_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "agrega_puntos_quiz_co";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public List<string> Fechas()
    {
        List<string> fechas = new List<string>();
        csDataBase query = new csDataBase();
        query.Query = "sp_consulta_fechas_transaccion_todas";
        query.EsStoreProcedure = true;
        DataTable dt = query.dtConsulta();
        foreach (DataRow dr in dt.Rows)
        {
            fechas.Add(dr["fecha"].ToString());
        }
        return fechas;
    }

    public void Fechas(ref DateTime min_fecha, ref DateTime max_fecha)
    {
        csDataBase query = new csDataBase();
        query.Query = "sp_consulta_fechas_transaccion";
        query.EsStoreProcedure = true;
        DataTable dt = query.dtConsulta();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            min_fecha = Convert.ToDateTime(dr["min_fecha"]);
            max_fecha = Convert.ToDateTime(dr["max_fecha"]);
        }
    }

    public void Fechas_mx(ref DateTime min_fecha, ref DateTime max_fecha)
    {
        csDataBase query = new csDataBase();
        query.Query = "sp_consulta_fechas_transaccion_mx";
        query.EsStoreProcedure = true;
        DataTable dt = query.dtConsulta();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            min_fecha = Convert.ToDateTime(dr["min_fecha"]);
            max_fecha = Convert.ToDateTime(dr["max_fecha"]);
        }
    }
}
