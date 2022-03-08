using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CallCenterDB.Linq.CallCenter;

public class csCountry
{
    private string id;
    private string country_code2;
    private string descripcion;
    private SqlTransaction tran;
    protected csDataBase database;
    protected SqlConnection conn;

    public csCountry() { 
    
    }
    public csCountry(string _id,string _country_code2,string _descripcion)
    {
        id = _id;
        country_code2 = _country_code2;
        descripcion = _descripcion;
    }

    public csCountry(SqlConnection conn)
    {
        this.conn = conn;
    }

    public csCountry(SqlConnection conn, SqlTransaction tran)
    {
        this.conn = conn;
        this.tran = tran;
    }

    public string ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public string CountryCode2
    {
        get { return country_code2; }
        set { country_code2 = value; }
    }
    public string Descripcion
    {
        get
        {
            return descripcion;
        }
        set
        {
            descripcion = value;
        }
    }

    public DataTable CargaCountry()
    {
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        List<SqlParameter> param = new List<SqlParameter>();
        if (!String.IsNullOrEmpty(id))
        {
            param.Add(new SqlParameter("@country_id", id));
        }
        if (!String.IsNullOrEmpty(country_code2))
        {
            param.Add(new SqlParameter("@country_code2", country_code2));
        }
        if (!String.IsNullOrEmpty(descripcion))
        {
            param.Add(new SqlParameter("@descripcion", descripcion));
        }
        if (param.Count > 0)
        {
            database.Parametros = param;
        }
        database.Query = "CountryInfo";
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }

    public void ObtienePrograma_Participante(String participante_id)
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
        database.Query = "ObtienePrograma_Participante";
        param.Add(new SqlParameter("@participante_id", participante_id));
        database.Parametros = param;
        database.EsStoreProcedure = true;
        DataTable dtCountry_Participante = database.dtConsulta();
        if (dtCountry_Participante.Rows.Count > 0)
        {
            DataRow drCountry_Participante = dtCountry_Participante.Rows[0];
            CountryCode2 = drCountry_Participante["clave"].ToString();            
        }
    }

    public List<csCountry> ConsultaCountryParticipante(string userId)
    {
        List<csCountry> listaCountry = new List<csCountry>();
        string id_;
        string country_code;
        string descrip;
        using (TablasGeneralesDataContext datacontext = new TablasGeneralesDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var dist = from p_asp in datacontext.participante_aspnet_User
                       from asp_u in datacontext.aspnet_Users.Where(_asp_u => _asp_u.UserId == p_asp.aspnet_UserId)
                       from p in datacontext.participante.Where(_p => _p.id == p_asp.participante_id)
                       from d in datacontext.distribuidors.Where(_d => _d.id == p.distributor_id)
                       from c in datacontext.programas.Where(_c => _c.id == d.programa_id)
                       where p_asp.aspnet_UserId == new Guid(userId)                      
                       select new { c.id ,c.clave, c.descripcion };
            if (dist.ToList().Count > 0)
            {
                foreach (var _c in dist.ToList())
                {
                   
                    listaCountry.Add(new csCountry(_c.id.ToString(), _c.clave, _c.descripcion));
                }
            }
            else {
                id_ = "28";
                country_code ="co";
                descrip = "COLOMBIA";
                listaCountry.Add(new csCountry(id_, country_code, descrip));
            }
        }
        return listaCountry;
    }
}

