using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class csDistribuidor
{
    private string participante_id;
    private string usuario_id;
    private string status_participante;
    protected csDataBase database;
    protected SqlConnection conn;
    private SqlTransaction tran;
    private CallCenterDB.Entidades.Direccion direccion;
    private string programa;
    private string programa_clave;

    public int ID
    { get; set; }
    public string Clave
    { get; set; }
    public string Descripcion
    { get; set; }

    public csDistribuidor()
    {
        programa = ConfigurationManager.AppSettings["programa"];
    }

    public csDistribuidor(string programa)
    {
        this.programa = programa;
    }

    public csDistribuidor(int id, string clave, string descripcion)
    {
        this.ID = id;
        this.Clave = clave;
        this.Descripcion = descripcion;
    }

    public string ParticipanteID
    {
        get { return participante_id; }
        set { participante_id = value; }
    }

    public string UsuarioID
    {
        get { return usuario_id; }
        set { usuario_id = value; }
    }

    public string StatusParticipante
    {
        get { return status_participante; }
        set { status_participante = value; }
    }
    public string Programa
    {
        get { return programa; }
        set { programa = value; }
    }
    public string ClavePrograma
    {
        get { return programa_clave; }
        set { programa_clave = value; }
    }
    public CallCenterDB.Entidades.Direccion Direccion
    {
        get { return direccion; }
        set { direccion = value; }
    }
    public List<csDistribuidor> Consulta()
    {
        List<csDistribuidor> dist = new List<csDistribuidor>();
        csDataBase database = new csDataBase();
        List<SqlParameter> p = new List<SqlParameter>();
        p.Add(new SqlParameter("@country_code2", programa));
        database.Query = "sp_consulta_distribuidor";
        database.Parametros = p;
        database.EsStoreProcedure = true;
        DataTable dt = database.dtConsulta();
        foreach (DataRow dr in dt.Rows)
        {
            dist.Add(new csDistribuidor(int.Parse(dr["id"].ToString()), dr["clave"].ToString(), dr["descripcion"].ToString()));
        }
        return dist;
    }

    public bool ValidaParticipante(string participante_clave)
    {
        bool valida = false; ;
        csDataBase database = new csDataBase();
        List<SqlParameter> p = new List<SqlParameter>();
        p.Add(new SqlParameter("@distributor", this.Clave));
        p.Add(new SqlParameter("@clave_participante", participante_clave));
        database.Query = "sp_valida_participante_distribuidor";
        database.Parametros = p;
        database.EsStoreProcedure = true;
        DataTable dt = database.dtConsulta();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            participante_id = dr["participante_id"].ToString();
            usuario_id = dr["usuario_id"].ToString();
            status_participante = dr["status_usuario"].ToString();
            valida = true;
        }
        return valida;
    }

    public List<csDistribuidor> ConsultaGerentes(decimal distributor_id)
    {
        List<csDistribuidor> g = new List<csDistribuidor>();
        using (CallCenterDB.FuerzaVentasDataContext fza = new CallCenterDB.FuerzaVentasDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var carga = (from f in fza.FuerzaVentas
                         where f.distributor_id == distributor_id
                         select new { f.gerente_id, f.STORE_MANAGER_CODE, f.STORE_MANAGER_NAME }).Distinct();
            foreach (var ca in carga.ToList())
            {
                csDistribuidor _d = new csDistribuidor();
                _d.ID = Convert.ToInt32(ca.gerente_id);
                _d.Descripcion = ca.STORE_MANAGER_CODE + " - " + ca.STORE_MANAGER_NAME;
                g.Add(_d);
            }
        }
        return g;
    }

    public List<csDistribuidor> ConsultaSupervisores(decimal gerente_id)
    {
        List<csDistribuidor> g = new List<csDistribuidor>();
        using (CallCenterDB.FuerzaVentasDataContext fza = new CallCenterDB.FuerzaVentasDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var carga = (from f in fza.FuerzaVentas
                         where f.gerente_id == gerente_id
                         select new { f.supervisor_id, f.STORE_SUP_CODE, f.STORE_SUP_NAME }).Distinct();
            foreach (var ca in carga.ToList())
            {
                csDistribuidor _d = new csDistribuidor();
                _d.ID = Convert.ToInt32(ca.supervisor_id);
                _d.Descripcion = ca.STORE_SUP_CODE + " - " + ca.STORE_SUP_NAME;
                g.Add(_d);
            }
        }
        return g;
    }

    public decimal InsertaFuerzaVentas(decimal distributor_id, string distributor_name,
                                    int store_sales_rep_code, string store_sales_rep_name,
                                    int store_sup_code, string store_sup_name,
                                    int store_manager_code, string store_manager_name,
                                    decimal empleado_id, decimal supervisor_id, decimal gerente_id)
    {
        using (CallCenterDB.FuerzaVentasDataContext fza = new CallCenterDB.FuerzaVentasDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var f = new CallCenterDB.FuerzaVentas()
            {
                distributor_id = distributor_id,
                distributor_name = distributor_name,
                STORE_SALES_REP_CODE = store_sales_rep_code,
                STORE_SALES_REP_NAME = store_sales_rep_name,
                STORE_SUP_CODE = store_sup_code,
                STORE_SUP_NAME = store_sup_name,
                STORE_MANAGER_CODE = store_manager_code,
                STORE_MANAGER_NAME = store_manager_name,
                empleado_id = empleado_id,
                supervisor_id = supervisor_id,
                gerente_id = gerente_id
            };
            fza.FuerzaVentas.InsertOnSubmit(f);
            fza.SubmitChanges();
            return f.id;
        }
    }

    public bool ExisteFuerzaVentas(int clave)
    {
        using (CallCenterDB.FuerzaVentasDataContext fza = new CallCenterDB.FuerzaVentasDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var carga = (from f in fza.FuerzaVentas
                         where f.distributor_id == this.ID
                         && f.STORE_SALES_REP_CODE == clave
                         select f).Count();
            if (carga > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public DataTable CargaDistributor(int country_id)
    {
        database = new csDataBase();
        if (this.conn != null)
            database.Conexion = conn;
        if (this.tran != null)
            database.Transaccion = tran;
        List<SqlParameter> param = new List<SqlParameter>();
        param.Add(new SqlParameter("@country_id", country_id));
        database.Parametros = param;
        database.Query = "ObtieneDistribuidora_Pais";
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }
    public void ConsultaDireccion()
    {
        direccion = new CallCenterDB.Entidades.Direccion();
        try
        {
            using (EntitiesModel.EntitiesModel model = new EntitiesModel.EntitiesModel(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
            {
                var dir = (from d in model.distribuidor_direccions
                           where d.distribuidor_id == this.ID
                           select new
                           {
                               Calle = d.calle,
                               NumExterior = d.numero,
                               EntreCalle = d.entre_calle,
                               YCalle = d.y_calle,
                               Colonia = d.colonia,
                               Municipio = d.municipio,
                               Estado = d.estado,
                               CP = d.codigo_postal
                           }).SingleOrDefault();
                direccion.Calle = dir.Calle;
                direccion.NumeroExterior = dir.NumExterior;
                direccion.EntreCalle = dir.EntreCalle;
                direccion.YCalle = dir.YCalle;
                direccion.Colonia = dir.Colonia;
                direccion.Municipio = dir.Municipio;
                direccion.Estado = dir.Estado;
                direccion.CodigoPostal = dir.CP;
            }
        }
        catch
        {
            direccion.Calle = "";
            direccion.NumeroExterior = "";
            direccion.EntreCalle = "";
            direccion.YCalle = "";
            direccion.Colonia = "";
            direccion.Municipio = "";
            direccion.Estado = "";
            direccion.CodigoPostal = "";
        }
    }


    public int ConsultaVentasPendientesPorAsignar(int distribuidor_id)
    {
        database = new csDataBase();
        DataTable dt = new DataTable(); 
        if (this.conn != null)
            database.Conexion = conn;
        if (this.tran != null)
            database.Transaccion = tran;
        List<SqlParameter> param = new List<SqlParameter>();
        param.Add(new SqlParameter("@distribuidor_id", distribuidor_id));
        database.Parametros = param;
        database.Query = "sp_consulta_pendiente_por_asignar";
        database.EsStoreProcedure = true;
        return  Convert.ToInt32(database.consultaDato());

    }
    public DataTable ConsultaChasisesPendientesPorAsignar(int distribuidor_id)
    {
        database = new csDataBase();
        DataTable dt = new DataTable();
        if (this.conn != null)
            database.Conexion = conn;
        if (this.tran != null)
            database.Transaccion = tran;
        List<SqlParameter> param = new List<SqlParameter>();
        param.Add(new SqlParameter("@distribuidor_id", distribuidor_id));
        database.Parametros = param;
        database.Query = "sp_consulta_chasises_pendientes";
        database.EsStoreProcedure = true;
        return database.dtConsulta();

    }

    public void InactivaChasis(string chasis)
    {
        csDataBase database = new csDataBase();
        List<SqlParameter> p = new List<SqlParameter>();
        p.Add(new SqlParameter("@chasis ", chasis));
        database.Query = "sp_inactiva_chasis";
        database.Parametros = p;
        database.EsStoreProcedure = true;
        database.acutualizaDatos("sp_inactiva_chasis", p, true);
        
    }
    public DataTable ConsultaHistoricoAsignaciones(int distribuidor_id)
    {
        database = new csDataBase();
        DataTable dt = new DataTable();
        if (this.conn != null)
            database.Conexion = conn;
        if (this.tran != null)
            database.Transaccion = tran;
        List<SqlParameter> param = new List<SqlParameter>();
        param.Add(new SqlParameter("@distribuidor_id", distribuidor_id));
        database.Parametros = param;
        database.Query = "sp_consulta_historico_asignaciones";
        database.EsStoreProcedure = true;
        return database.dtConsulta();

    }
}
