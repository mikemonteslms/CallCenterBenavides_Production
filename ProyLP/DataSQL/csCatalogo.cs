using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;
using CallCenterDB.Linq;
using System.Linq;

#region Distribuidor
public class Distribuidores
{
    public int id
    {
        get;
        set;
    }
    public string Descripcion
    {
        get;
        set;
    }
    public Distribuidores()
    {
    }
    public Distribuidores(int id, string Descripcion)
    {
        this.id = id;
        this.Descripcion = Descripcion;
    }
}
#endregion
#region Puestos
public class Puestos
{
    public int id
    {
        get;
        set;
    }
    public string Descripcion
    {
        get;
        set;
    }
    public Puestos()
    {
    }
    public Puestos(int id, string Descripcion)
    {
        this.id = id;
        this.Descripcion = Descripcion;
    }
}
#endregion



/// <summary>
/// Descripción breve de csCatalogo
/// </summary>
/// 
public class csCatalogo
{

    protected csDataBase database;
    protected List<SqlParameter> parametros;
    protected SqlConnection conn;
    protected SqlTransaction tran;

    public csCatalogo(SqlConnection conn)
    {
        this.conn = conn;
    }
    public csCatalogo(SqlConnection conn, SqlTransaction tran)
    {
        this.conn = conn;
        this.tran = tran;
    }


    private string catalogo;
    private string country_code;
    public csCatalogo()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public csCatalogo(string nombre_catalogo)
    {
        catalogo = nombre_catalogo;
    }
    public string Catalogo
    {
        get
        {
            return catalogo;
        }
        set
        {
            catalogo = value;
        }
    }
    public string Country_code
    {
        get
        {
            return country_code;
        }
        set
        {
            country_code = value;
        }
    }
    public DataTable Consulta()
    {
        string consulta = "sp_carga_catalogo";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@catalogo", catalogo));
        parametros.Add(new SqlParameter("@programa", country_code));
        database = new csDataBase();
        return database.dtConsulta(consulta, parametros, true);
    }

    public List<Distribuidores> CargaDistribuidor(int countryId)
    {
        List<Distribuidores> dist = new List<Distribuidores>();
        using (CatalogoCallCenterDataContext ccContexto = new CatalogoCallCenterDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var query = from c in ccContexto.distributor
                        where c.country_id == Convert.ToDecimal(countryId)
                        select c;
            foreach (var distribuidor1 in query)
            {
                dist.Add(new Distribuidores(Convert.ToInt32(distribuidor1.id), distribuidor1.descripcion.ToString()));
            }

        }
        return dist;
    }

    public List<Puestos> CargaPuestos()
    {
        List<Puestos> p = new List<Puestos>();
        using (CatalogoCallCenterDataContext ccContexto = new CatalogoCallCenterDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var query = from c in ccContexto.tipo_participante
                        select c;
            foreach (var puestos in query)
            {
                p.Add(new Puestos(Convert.ToInt32(puestos.id), puestos.descripcion.ToString()));
            }
        }
        return p;
    }

    public DataTable ReporteClientes(int country_id, int distributor_id, int inscritos, int puesto_id)
    {
        string Datos = "sp_reporte_clientes";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@inscritos", inscritos));
        parametros.Add(new SqlParameter("@puesto_id", puesto_id));
        database = new csDataBase();
        return database.dtConsulta(Datos, parametros, true);
    }

    public DataTable RptResumenLlamadas(int country_id, int distributor_id, string FecInical, string FecFinal)
    {
        string Datos = "sp_reporte_llamadas";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@fecha_inicial", FecInical));
        parametros.Add(new SqlParameter("@fecha_final", FecFinal));
        database = new csDataBase();
        return database.dtConsulta(Datos, parametros, true);
    }

    public DataTable RptDetallesLlamadas(int country_id, int distributor_id, string FecInical, string FecFinal)
    {
        string Datos = "sp_reporte_llamadas_detalle";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@fecha_inicial", FecInical));
        parametros.Add(new SqlParameter("@fecha_final", FecFinal));
        database = new csDataBase();
        return database.dtConsulta(Datos, parametros, true);
    }

    public DataTable RptRedenciones(int country_id, int distributor_id, string FecInical, string FecFinal)
    {
        string Datos = "sp_reporte_redenciones";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@fecha_inicial", FecInical));
        parametros.Add(new SqlParameter("@fecha_final", FecFinal));
        database = new csDataBase();
        return database.dtConsulta(Datos, parametros, true);
    }

    public DataTable RptClientesInscritos(int country_id, int distributor_id, string FecInical, string FecFinal)
    {
        string Datos = "sp_reporte_clientes_inscritos_v1";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@fecha_inicial", FecInical));
        parametros.Add(new SqlParameter("@fecha_final", FecFinal));
        database = new csDataBase();
        return database.dtConsulta(Datos, parametros, true);
    }

    public DataTable RptIngresoWeb(int country_id, int distributor_id, string FecInical, string FecFinal)
    {
        string Datos = "sp_reporte_ingreso_web";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@fecha_inicial", FecInical));
        parametros.Add(new SqlParameter("@fecha_final", FecFinal));
        database = new csDataBase();
        return database.dtConsulta(Datos, parametros, true);
    }

    public DataTable RptSeguimientoLlamadas(int country_id, int distributor_id, string FecInical, string FecFinal)
    {
        string Datos = "sp_reporte_seguimiento_llamadas";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@fecha_inicial", FecInical));
        parametros.Add(new SqlParameter("@fecha_final", FecFinal));
        database = new csDataBase();
        return database.dtConsulta(Datos, parametros, true);
    }

    public DataSet ReporteClientesv1(int country_id, int distributor_id, string fechaInicial, string FechaFinal )
    {
        string Datos = "sp_reporte_clientes_inscritos_v1";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@fecha_inicial", fechaInicial));
        parametros.Add(new SqlParameter("@fecha_final", FechaFinal));
        database = new csDataBase();
        return database.dsConsulta(Datos, parametros, true);
    }

    public DataSet ReporteEstadisticoLlamadas(int country_id, int distributor_id, string fechaInicial, string FechaFinal)
    {
        string Datos = "sp_reporte_estadistico_llamadas";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@fecha_inicial", fechaInicial));
        parametros.Add(new SqlParameter("@fecha_final", FechaFinal));
        database = new csDataBase();
        return database.dsConsulta(Datos, parametros, true);
    }

    public DataSet ReporteEstadisticoWeb(int country_id, int distributor_id, string fechaInicial, string FechaFinal)
    {
        string Datos = "sp_reporte_estadistico_web";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@fecha_inicial", fechaInicial));
        parametros.Add(new SqlParameter("@fecha_final", FechaFinal));
        database = new csDataBase();
        return database.dsConsulta(Datos, parametros, true);
    }
    public DataSet ReporteIngresoWeb_v1(int country_id, int distributor_id, string fechaInicial, string FechaFinal)
    {
        string Datos = "sp_reporte_ingreso_web_v1";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@fecha_inicial", fechaInicial));
        parametros.Add(new SqlParameter("@fecha_final", FechaFinal));
        database = new csDataBase();
        return database.dsConsulta(Datos, parametros, true);
    }

    public DataSet ReportesegLlamadas_v1(int country_id, int distributor_id, string fechaInicial, string FechaFinal)
    {
        string Datos = "sp_reporte_seguimiento_llamadas_v1";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@fecha_inicial", fechaInicial));
        parametros.Add(new SqlParameter("@fecha_final", FechaFinal));
        database = new csDataBase();
        return database.dsConsulta(Datos, parametros, true);
    }

    public DataSet ReporteStatusPartic(int country_id, int distributor_id, string fechaInicial, string FechaFinal)
    {
        string Datos = "sp_reporte_status_participantes";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@fecha_inicial", fechaInicial));
        parametros.Add(new SqlParameter("@fecha_final", FechaFinal));
        database = new csDataBase();
        return database.dsConsulta(Datos, parametros, true);
    }

    public DataSet RptRedenciones_v1(int country_id, int distributor_id, string FecInical, string FecFinal)
    {
        string Datos = "sp_reporte_redenciones";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_id", country_id));
        parametros.Add(new SqlParameter("@distributor_id", distributor_id));
        parametros.Add(new SqlParameter("@fecha_inicial", FecInical));
        parametros.Add(new SqlParameter("@fecha_final", FecFinal));
        database = new csDataBase();
        return database.dsConsulta(Datos, parametros, true);
    }
}