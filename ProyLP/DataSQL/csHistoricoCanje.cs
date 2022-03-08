using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public class PremioCanje
{
    public PremioCanje()
    {
    }

    public PremioCanje(string id, string folio, string premio, int puntos, string fecha_solicitud, string fecha_status, string fecha_entrega, string status, string observaciones, string direccion_entrega, string origen_canje)
    {
        this.ID = id;
        this.Folio = folio;
        this.Premio = premio;
        this.Puntos = puntos;
        this.FechaSolicitud = fecha_solicitud;
        this.FechaStatus = fecha_status;
        this.FechaEntrega = fecha_entrega;
        this.Status = status;
        this.Observaciones = observaciones;
        this.DireccionEntrega = direccion_entrega;
        this.OrigenCanje = origen_canje;
    }

    public PremioCanje(string id, string folio, string premio, string transaccion_observaciones, int puntos, string fecha_solicitud, string fecha_status, string fecha_entrega, string status, string observaciones, string direccion_entrega, string origen_canje)
    {
        this.ID = id;
        this.Folio = folio;
        this.Premio = premio;
        this.TransaccionObservaciones = transaccion_observaciones;
        this.Puntos = puntos;
        this.FechaSolicitud = fecha_solicitud;
        this.FechaStatus = fecha_status;
        this.FechaEntrega = fecha_entrega;
        this.Status = status;
        this.Observaciones = observaciones;
        this.DireccionEntrega = direccion_entrega;
        this.OrigenCanje = origen_canje;
    }

    public string ID
    {
        get;
        set;
    }

    public string Folio
    {
        get;
        set;
    }

    public string Premio
    {
        get;
        set;
    }

    public string TransaccionObservaciones
    {
        get;
        set;
    }

    public int Puntos
    {
        get;
        set;
    }

    public string FechaSolicitud
    {
        get;
        set;
    }

    public string FechaStatus
    {
        get;
        set;
    }

    public string FechaEntrega
    {
        get;
        set;
    }

    public string Status
    {
        get;
        set;
    }

    public string Observaciones
    {
        get;
        set;
    }

    public string DireccionEntrega
    {
        get;
        set;
    }

    public string OrigenCanje
    {
        get;
        set;
    }
}

public class csHistoricoCanje
{
    public csHistoricoCanje()
    {
    }

    public List<PremioCanje> ConsultaHistorico(string participante_id)
    {
        List<PremioCanje> historico = new List<PremioCanje>();          
        csDataBase database = new csDataBase();
        database.Query = "sp_detalle_canje_participante1";
        database.EsStoreProcedure = true;
        List<SqlParameter> param = new List<SqlParameter>();
        param.Add(new SqlParameter("@participante_id", participante_id));
        database.Parametros = param;
        DataTable dt = database.dtConsulta();
        foreach (DataRow dr in dt.Rows)        
        {
            historico.Add(new PremioCanje(dr["transaccion_premio_id"].ToString(), dr["folio"].ToString(), dr["premio"].ToString(), dr["transaccion_observaciones"].ToString(), Convert.ToInt32(dr["puntos"]), dr["fechasol"].ToString(), dr["fechastatus"].ToString(), dr["fechaentrega"].ToString(), dr["status"].ToString(), dr["observaciones"].ToString(), dr["direccion_entrega"].ToString(), dr["origen_canje"].ToString()));
        }
        return historico;
    }

    public List<PremioCanje> ConsultaHistoricoCO(string participante_id)
    {
        List<PremioCanje> historico = new List<PremioCanje>();
        csDataBase database = new csDataBase();
        database.Query = "sp_detalle_canje_participante1";
        database.EsStoreProcedure = true;
        List<SqlParameter> param = new List<SqlParameter>();
        param.Add(new SqlParameter("@participante_id", participante_id));
        database.Parametros = param;
        DataTable dt = database.dtConsulta();
        foreach (DataRow dr in dt.Rows)        
        {
            historico.Add(new PremioCanje(dr["transaccion_premio_id"].ToString(), dr["folio"].ToString(), dr["premio"].ToString(), dr["transaccion_observaciones"].ToString(), Convert.ToInt32(dr["puntos"]), dr["fechasol"].ToString(), dr["fechastatus"].ToString(), dr["fechaentrega"].ToString(), dr["status"].ToString(), dr["observaciones"].ToString(), dr["direccion_entrega"].ToString(), dr["origen_canje"].ToString()));
        }
        return historico;
    }

    public List<PremioCanje> ConsultaHistoricoMX(string participante_id)
    {
        List<PremioCanje> historico = new List<PremioCanje>();
        csDataBase database = new csDataBase();
        database.Query = "sp_detalle_canje_participante";
        database.EsStoreProcedure = true;
        List<SqlParameter> param = new List<SqlParameter>();
        param.Add(new SqlParameter("@participante_id", participante_id));
        database.Parametros = param;
        DataTable dt = database.dtConsulta();
        foreach (DataRow dr in dt.Rows)        
        {
            historico.Add(new PremioCanje(dr["transaccion_premio_id"].ToString(), dr["folio"].ToString(), dr["premio"].ToString(), dr["transaccion_observaciones"].ToString(), Convert.ToInt32(dr["puntos"]), dr["fechasol"].ToString(), dr["fechastatus"].ToString(), dr["fechaentrega"].ToString(), dr["status"].ToString(), dr["observaciones"].ToString(), dr["direccion_entrega"].ToString(), dr["origen_canje"].ToString()));
        }
        return historico;
    }

    public List<PremioCanje> DetallePremioHistorial(string transaccion_premio_id)
    {
        List<PremioCanje> premios = new List<PremioCanje>();
        csDataBase database = new csDataBase();
        string detallepremio = "sp_detalle_premio_historico";
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_premio_id", transaccion_premio_id));
        database = new csDataBase();
        DataTable dt = database.dtConsulta(detallepremio, parametros, true);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            PremioCanje _p = new PremioCanje();
            _p.ID = dr["id"].ToString();
            _p.Premio = dr["premio"].ToString();
            _p.Puntos = Convert.ToInt32(dr["puntos"]);
            _p.Observaciones = dr["observaciones"].ToString();
            _p.FechaStatus = Convert.ToDateTime(dr["fecha"]).ToString("dd/MM/yyyy");
            _p.Status = dr["status"].ToString();
            premios.Add(_p);
        }        
        return premios;
    }

    public List<PremioCanje> DetallePremioHistorialCO(string transaccion_premio_id)
    {
        List<PremioCanje> premios = new List<PremioCanje>();
        csDataBase database = new csDataBase();
        string detallepremio = "sp_detalle_premio_historico";
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_premio_id", transaccion_premio_id));
        database = new csDataBase();
        DataTable dt = database.dtConsulta(detallepremio, parametros, true);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            PremioCanje _p = new PremioCanje();
            _p.ID = dr["id"].ToString();
            _p.Premio = dr["premio"].ToString();
            _p.Puntos = Convert.ToInt32(dr["puntos"]);
            _p.Observaciones = dr["observaciones"].ToString();
            _p.Observaciones = dr["observaciones"].ToString();
            _p.FechaStatus = Convert.ToDateTime(dr["fecha"]).ToString("dd/MM/yyyy");
            _p.Status = dr["status"].ToString();
            premios.Add(_p);
        }        
        return premios;
    }

    public List<PremioCanje> DetallePremioHistorialMX(string transaccion_premio_id)
    {
        List<PremioCanje> premios = new List<PremioCanje>();
        csDataBase database = new csDataBase();
        string detallepremio = "sp_detalle_premio_historico";
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_premio_id", transaccion_premio_id));
        database = new csDataBase();
        DataTable dt = database.dtConsulta(detallepremio, parametros, true);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            PremioCanje _p = new PremioCanje();
            _p.ID = dr["id"].ToString();
            _p.Premio = dr["premio"].ToString();
            _p.Puntos = Convert.ToInt32(dr["puntos"]);
            _p.Observaciones = dr["observaciones"].ToString();
            _p.Observaciones = dr["observaciones"].ToString();
            _p.FechaStatus = Convert.ToDateTime(dr["fecha"]).ToString("dd/MM/yyyy");
            _p.Status = dr["status"].ToString();
            premios.Add(_p);
        }        
        return premios;
    }

    public void ActualizaObservaciones(string transaccion_premio_id, string observaciones)
    {
        csDataBase database = new csDataBase();
        string detallepremio = "sp_actualiza_observaciones_premio_historico";
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_premio_id", transaccion_premio_id));
        parametros.Add(new SqlParameter("@observaciones", observaciones));
        database = new csDataBase();
        database.acutualizaDatos(detallepremio, parametros, true);
    }

    public void ActualizaObservacionesCO(string transaccion_premio_id, string observaciones)
    {
        csDataBase database = new csDataBase();
        string detallepremio = "sp_actualiza_observaciones_premio_historico";
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_premio_id", transaccion_premio_id));
        parametros.Add(new SqlParameter("@observaciones", observaciones));
        database = new csDataBase();
        database.acutualizaDatos(detallepremio, parametros, true);
    }

    public void ActualizaObservacionesMX(string transaccion_premio_id, string observaciones)
    {
        csDataBase database = new csDataBase();
        string detallepremio = "sp_actualiza_observaciones_premio_historico";
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_premio_id", transaccion_premio_id));
        parametros.Add(new SqlParameter("@observaciones", observaciones));
        database = new csDataBase();
        database.acutualizaDatos(detallepremio, parametros, true);
    }
}