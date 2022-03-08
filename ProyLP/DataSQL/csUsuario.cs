using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Security;
using System.Linq;
using CallCenterDB;

/// <summary>
/// Descripción breve de csUsuario
/// </summary>
/// 
public class csUsuario
{
    private string usuario_id;
    private string login;
    private string nombre;
    private string apellido_paterno;
    private string apellido_materno;
    private string nombrecompleto;
    private string password;
    private string salt;
    private string correo_electronico;
    private string fecha_ultimo_acceso;
    private string status_usuario_id;
    private string perfil_id;
    private string fecha_nacimiento;
    private string usuario_alta_id;
    private string participante_id;
    private string clave_status_participante;
    private string userid;
    private string tipo_actividad;

    private DateTime fecha_recovery;
    private string hash;
    private string country_code;
    private string cpf;

    private csDataBase database;
    SqlConnection conn;
    SqlTransaction tran;
    private List<SqlParameter> parametros;

    public csUsuario()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public csUsuario(SqlConnection conn)
    {
        this.conn = conn;
    }
    public csUsuario(SqlConnection conn, SqlTransaction tran)
    {
        this.conn = conn;
        this.tran = tran;
    }
    public csUsuario(string login_usuario, string nombre_usuario, string apellido_paterno_usuario, string apellido_materno_usuario,
        string password_usuario, string salt_usuario, string correo_electronico_usuario, string fecha_ultimo_acceso_usuario,
        string status_usuario, string perfil_usuario, string fecha_nacimiento_usuario)
    {
        login = login_usuario;
        nombre = nombre_usuario;
        apellido_materno = apellido_paterno_usuario;
        apellido_materno = apellido_materno_usuario;
        password = password_usuario;
        salt = salt_usuario;
        correo_electronico = correo_electronico_usuario;
        fecha_ultimo_acceso = fecha_ultimo_acceso_usuario;
        status_usuario_id = status_usuario;
        perfil_id = perfil_usuario;
        fecha_nacimiento = fecha_nacimiento_usuario;
    }
    public string ID
    {
        get
        {
            return usuario_id;
        }
        set
        {
            usuario_id = value;
        }
    }
    public string Login
    {
        get
        {
            return login;
        }
        set
        {
            login = value;
        }
    }
    public string Nombre
    {
        get
        {
            return nombre;
        }
        set
        {
            nombre = value;
        }
    }
    public string ApellidoPaterno
    {
        get
        {
            return apellido_paterno;
        }
        set
        {
            apellido_paterno = value;
        }
    }
    public string ApellidoMaterno
    {
        get
        {
            return apellido_materno;
        }
        set
        {
            apellido_materno = value;
        }
    }
    public string NombreCompleto
    { get { return nombrecompleto; } }
    public string Password
    {
        set
        {
            password = value;
        }
    }
    public string Salt
    {
        set
        {
            salt = value;
        }
    }
    public string CorreoElectronico
    {
        get
        {
            return correo_electronico;
        }
        set
        {
            correo_electronico = value;
        }
    }
    public string FechaUltimoAcceso
    {
        get
        {
            return fecha_ultimo_acceso;
        }
        set
        {
            fecha_ultimo_acceso = value;
        }
    }
    public string Status
    {
        get
        {
            return status_usuario_id;
        }
        set
        {
            status_usuario_id = value;
        }
    }
    public string Perfil
    {
        get
        {
            return perfil_id;
        }
        set
        {
            perfil_id = value;
        }
    }
    public string FechaNacimiento
    {
        get
        {
            return fecha_nacimiento;
        }
        set
        {
            fecha_nacimiento = value;
        }
    }
    public string UsuarioAlta
    {
        get
        {
            return usuario_alta_id;
        }
        set
        {
            usuario_alta_id = value;
        }
    }
    public string Participante_ID
    {
        get { return participante_id; }
        set { participante_id = value; }
    }
    public string UserID
    {
        get { return userid; }
        set { userid = value; }
    }
    public string TipoActividad
    {
        get { return tipo_actividad; }
        set { tipo_actividad = value; }
    }

    public DateTime Fecha_Recovery
    {
        get { return fecha_recovery; }
        set { fecha_recovery = value; }
    }
    public string Hash
    {
        get { return hash; }
        set { hash = value; }
    }

    public string Country_Code
    {
        get { return country_code; }
        set { country_code = value; }
    }

    public string CPF
    {
        get { return cpf; }
        set { cpf = value; }
    }


    public string ClaveStatusParticipante
    {
        get { return clave_status_participante; }
        set { clave_status_participante = value; }
    }

    public void ValidaAcceso()
    {
        string usuario = "sp_valida_acceso";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@login", login));
        database = new csDataBase();
        DataTable dtUsuario = database.dtConsulta(usuario, parametros, true);
        if (dtUsuario.Rows.Count > 0)
        {
            foreach (DataRow drUsuario in dtUsuario.Rows)
            {
                salt = drUsuario["salt"].ToString();
                if (drUsuario["password"].ToString() == FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, "SHA1"))
                {
                    usuario_id = drUsuario["usuario_id"].ToString();
                    login = drUsuario["login"].ToString();
                    correo_electronico = drUsuario["correo_electronico"].ToString();
                    fecha_ultimo_acceso = drUsuario["fecha_ultimo_acceso"].ToString();
                    status_usuario_id = drUsuario["status_usuario_id"].ToString();
                    perfil_id = drUsuario["perfil_id"].ToString();
                    fecha_nacimiento = drUsuario["fecha_nacimiento"].ToString();
                    break;
                }
            }
        }
    }
    public void DatosUsuario()
    {
        string datosusuario = "sp_datos_usuario";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@usuario_id", usuario_id));
        database = new csDataBase();
        DataTable dtUsuario = database.dtConsulta(datosusuario, parametros, true);
        if (dtUsuario.Rows.Count > 0)
        {
            DataRow drUsuario = dtUsuario.Rows[0];
            usuario_id = drUsuario["usuario_id"].ToString();
            login = drUsuario["login"].ToString();
            nombre = drUsuario["nombre"].ToString();
            apellido_paterno = drUsuario["apellido_paterno"].ToString();
            apellido_materno = drUsuario["apellido_materno"].ToString();
            correo_electronico = drUsuario["correo_electronico"].ToString();
            fecha_ultimo_acceso = drUsuario["fecha_ultimo_acceso"].ToString();
            status_usuario_id = drUsuario["status_usuario_id"].ToString();
            perfil_id = drUsuario["perfil_id"].ToString();
            fecha_nacimiento = drUsuario["fecha_nacimiento"].ToString();
            participante_id = drUsuario["participante_id"].ToString();
        }
    }
    public void ParticipanteUsuario()
    {
        string datosusuario = "sp_participante_usuario";
        parametros = new List<SqlParameter>();
        SqlParameter p;
        p = new SqlParameter();
        p.ParameterName = "@usuario_id";
        if (userid == null)
        {
            p.Value = DBNull.Value;
        }
        else
        {
            p.Value = userid;
        }
        parametros.Add(p);
        p = new SqlParameter();
        p.ParameterName = "@participante_id";
        if (participante_id == null)
        {
            p.Value = DBNull.Value;
        }
        else
        {
            p.Value = participante_id;
        }
        parametros.Add(p);
        database = new csDataBase();
        DataTable dtUsuario = database.dtConsulta(datosusuario, parametros, true);
        if (dtUsuario.Rows.Count > 0)
        {
            DataRow drUsuario = dtUsuario.Rows[0];
            userid = drUsuario["aspnet_UserId"].ToString();
            participante_id = drUsuario["participante_id"].ToString();
            login = drUsuario["username"].ToString();
            country_code = drUsuario["country_code2"].ToString();
            cpf = drUsuario["clave"].ToString();
            nombrecompleto = drUsuario["nombrecompleto"].ToString();
        }
    }

    public void ObtieneUsuario_Participante(string username)
    {
        string datosusuario = "Obtiene_aspnet_user_Participante";
        parametros = new List<SqlParameter>();
        SqlParameter p;
        p = new SqlParameter();
        p.ParameterName = "@username";
        p.Value = username;
        parametros.Add(p);
        database = new csDataBase();
        DataTable dtUsuario = database.dtConsulta(datosusuario, parametros, true);
        if (dtUsuario.Rows.Count > 0)
        {
            DataRow drUsuario = dtUsuario.Rows[0];
            clave_status_participante = drUsuario["clave"].ToString();
            participante_id = drUsuario["participante_id"].ToString();
            country_code = drUsuario["country_code"].ToString();
        }        
    }

    public bool ActualizaStatus(string status)
    {
        try
        {
            string actualiza = "sp_actualiza_status_participante";
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@participante_id", this.Participante_ID));
            parametros.Add(new SqlParameter("@status", status));
            database = new csDataBase();
            database.acutualizaDatos(actualiza, parametros, true);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public DataTable Menu()
    {
        string menu = "sp_menu_perfil";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@perfil_id", perfil_id));
        database = new csDataBase();
        return database.dtConsulta(menu, parametros, true);
    }
    public void Inserta()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@login", login));
        parametros.Add(new SqlParameter("@nombre", nombre));
        parametros.Add(new SqlParameter("@apellido_paterno", apellido_paterno));
        parametros.Add(new SqlParameter("@apellido_materno", apellido_materno));
        parametros.Add(new SqlParameter("@password", password));
        parametros.Add(new SqlParameter("@salt", salt));
        parametros.Add(new SqlParameter("@correo_electronico", correo_electronico));
        parametros.Add(new SqlParameter("@status_usuario_id", status_usuario_id));
        parametros.Add(new SqlParameter("@perfil_id", perfil_id));
        parametros.Add(new SqlParameter("@fecha_nacimiento", fecha_nacimiento));
        parametros.Add(new SqlParameter("@usuario_alta_id", usuario_alta_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_inserta_usuario";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        usuario_id = database.consultaDato().ToString();
    }
    public bool Existe()
    {
        string usuario = "sp_valida_acceso";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@login", login));
        database = new csDataBase();
        DataTable dtUsuario = database.dtConsulta(usuario, parametros, true);
        if (dtUsuario.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool EsPrimerAcceso
    {
        get
        {
            string datosusuario = "sp_cuenta_actividad";
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@UserId", userid));
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@tipo_actividad";
            if (tipo_actividad == null)
            {
                par.Value = DBNull.Value;
            }
            else
            {
                par.Value = tipo_actividad;
            }
            parametros.Add(par);
            database = new csDataBase();
            int num_accesos = int.Parse(database.consultaDato(datosusuario, parametros, true).ToString());
            return (num_accesos == 0);
        }
    }
    public void InsertaActividad()
    {
        string datosusuario = "sp_inserta_user_actividad";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@UserId", userid));
        parametros.Add(new SqlParameter("@tipo_actividad", tipo_actividad));
        database = new csDataBase();
        database.consultaDato(datosusuario, parametros, true);
    }
    public string UltimaActividad
    {
        get
        {
            string datosusuario = "sp_consulta_user_ultima_actividad";
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@UserId", userid));
            database = new csDataBase();
            return database.consultaDato(datosusuario, parametros, true).ToString();
        }
    }
    public bool InsertaRecovery()
    {
        string datosusuario = "sp_inserta_user_recovery";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@UserId", userid));
        parametros.Add(new SqlParameter("@fecha_recovery", fecha_recovery));
        parametros.Add(new SqlParameter("@hash", hash));

        database = new csDataBase();
        int insertado = database.acutualizaDatos(datosusuario, parametros, true);
        return (insertado > 0);
    }
    public void RecuperaRecovery()
    {
        string datosrecovery = "sp_recupera_user_recovery";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@UserId", userid));
        parametros.Add(new SqlParameter("@hash", hash));

        database = new csDataBase();
        DataTable dt = database.dtConsulta(datosrecovery, parametros, true);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            userid = dr["aspnet_UserID"].ToString();
            fecha_recovery = Convert.ToDateTime(dr["fecha"]);
            hash = dr["cadena_hash"].ToString();
        }
        else
        {
            userid = "";
            fecha_recovery = DateTime.MinValue;
            hash = "";
        }        
    }

    public bool ActualizaRecovery()
    {
        string datosusuario = "sp_actualiza_user_recovery";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@UserId", userid));
        parametros.Add(new SqlParameter("@hash", hash));
        database = new csDataBase();
        int insertado = database.acutualizaDatos(datosusuario, parametros, true);
        return (insertado > 0);
    }

    public bool ActualizaPassword()
    {
        string datosusuario = "sp_actualiza_password_aspnet_membership";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@UserId", userid));
        database = new csDataBase();
        int insertado = database.acutualizaDatos(datosusuario, parametros, true);
        return (insertado > 0);
    }

    public bool ActualizaPasswordGenerico()
    {
        string datosusuario = "sp_actualiza_password_generico_aspnet_membership";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@UserId", userid));
        database = new csDataBase();
        int insertado = database.acutualizaDatos(datosusuario, parametros, true);
        return (insertado > 0);
    }

    public void ObtieneCountry_UserID()
    {
        string datosusuario = "ObtieneCountry_UserID";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@UserId", userid));
        database = new csDataBase();
        DataTable dtUsuario = database.dtConsulta(datosusuario, parametros, true);
        if (dtUsuario.Rows.Count > 0)
        {
            DataRow drUsuario = dtUsuario.Rows[0];
            country_code = drUsuario["country_code"].ToString();
            nombre = drUsuario["nombrecompleto"].ToString();
            cpf = drUsuario["cpf"].ToString();
        }        
    }

    public void InsertaDistribuidor(List<int> distribuidor)
    {
        using (Membership_DistributorDataContext md_datacontext = new Membership_DistributorDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var dd = from md in md_datacontext.aspnet_Membership_Distributor
                     where md.UserID == new Guid(this.UserID)
                     select md;
            md_datacontext.aspnet_Membership_Distributor.DeleteAllOnSubmit(dd);
            md_datacontext.SubmitChanges();

            foreach (int d in distribuidor)
            {
                aspnet_Membership_Distributor md = new aspnet_Membership_Distributor();
                md.UserID = new Guid(this.UserID);
                md.distributor_id = d;
                md_datacontext.aspnet_Membership_Distributor.InsertOnSubmit(md);
            }
            md_datacontext.SubmitChanges();
        }
    }
}