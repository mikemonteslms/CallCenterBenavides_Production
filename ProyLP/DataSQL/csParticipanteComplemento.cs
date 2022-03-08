using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de csParticipanteComplemento
/// </summary>
/// 

public class csParticipanteComplemento : csParticipante
{
    private string correo_electronico2;
    private string equipo_futbol;
    private string informacion_email;
    private string informacion_sms;
    private string distribuidor_logo;
    private string documento_identidad;
    private string participante_id;
    private string usuario_id;
    private string tipo_transaccion;
    private string tipo_transaccion_id;
    private int puntos;
    private DateTime fecha;
    private int transaccion_id;

    public string CorreoElectronico2
    {
        get { return correo_electronico2; }
        set { correo_electronico2 = value; }
    }
    public string EquipoFutbol
    {
        get { return equipo_futbol; }
        set { equipo_futbol = value; }
    }
    public string DistribuidorLogo
    {
        get { return distribuidor_logo; }
        set { distribuidor_logo = value; }
    }
    public string UsuarioID
    {
        get { return usuario_id; }
        set { usuario_id = value; }
    }
    public string TipoTransaccionID
    {
        set { tipo_transaccion_id = value; }
    }
    public string TipoTransaccion
    {
        set { tipo_transaccion = value; }
    }
    public int Puntos
    {
        get { return puntos; }
        set { puntos = value; }
    }
    public csParticipanteComplemento()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    public csParticipanteComplemento(String participante_id)
    {
        this.ID = participante_id;
        DatosParticipante();
    }
    public csParticipanteComplemento(SqlConnection conn)
    {
        this.conn = conn;
    }
    public csParticipanteComplemento(SqlConnection conn, SqlTransaction tran)
    {
        this.conn = conn;
        this.tran = tran;
    }
    public override bool BuscaParticipantePorClave()
    {
        string participante = "sp_busca_participante_complemento_clave";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@clave", this.Clave));
        database = new csDataBase();
        DataTable dtDatos = database.dtConsulta(participante, parametros, true);
        if (dtDatos.Rows.Count > 0)
        {
            DataRow drP = dtDatos.Rows[0];
            this.ID = drP["id"].ToString();
            this.Clave = drP["clave_participante"].ToString();
            this.Nombre = drP["nombre"].ToString();
            this.ApellidoPaterno = drP["apellido_paterno"].ToString();
            this.ApellidoMaterno = drP["apellido_materno"].ToString();
            this.NombreCompleto = drP["nombrecompleto"].ToString();
            this.Status_ID = drP["status_participante_id"].ToString();
            this.Status = drP["status_participante"].ToString();
            this.Sexo_ID = drP["sexo_id"].ToString();
            this.Sexo = drP["sexo"].ToString();
            this.TipoParticipante_ID = drP["tipo_participante_id"].ToString();
            this.TipoParticipante = drP["tipo_participante"].ToString();
            this.CorreoElectronico = drP["correo_electronico"].ToString();
            this.EstadoCivil_ID = drP["estado_civil_id"].ToString();
            this.EstadoCivil = drP["estado_civil"].ToString();
            this.FechaNacimiento = drP["fecha_nacimiento"].ToString();
            this.Distribuidora_ID = drP["distributor_id"].ToString();
            this.Distribuidora = drP["distributor"].ToString();
            this.ProgramaID = drP["programa_id"].ToString();
            this.Programa = drP["programa"].ToString();
            this.Escolaridad_ID = drP["escolaridad_id"].ToString();
            this.Escolaridad = drP["escolaridad"].ToString();
            this.Hijos = drP["hijos"].ToString();
            this.NHijos = drP["nhijos"].ToString();
            CorreoElectronico2 = drP["correo_electronico2"].ToString();
            EquipoFutbol = drP["equipo_futbol"].ToString();
            InformacionEmail = drP["informacion_email"].ToString();
            InformacionSMS = drP["informacion_sms"].ToString();
            DistribuidorLogo = drP["distribuidor_logo"].ToString();
            DocumentoIdentidad = drP["documento_identidad"].ToString();
            return true;
        }
        else
        {
            return false;
        }
    }

    public DataTable BuscaParticipantesGeneral(string busqueda, string UserId)
    {
        string participantes = "sp_busca_participantes_general";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@busqueda", busqueda));
        parametros.Add(new SqlParameter("@usuario_id", UserId));
        database = new csDataBase();
        return database.dtConsulta(participantes, parametros, true);
    }

    public DataTable BuscaParticipantes(string busqueda, int programa_id)
    {
        string participantes = "sp_busca_participantes";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@busqueda", busqueda));
        parametros.Add(new SqlParameter("@programa_id", programa_id));
        database = new csDataBase();
        return database.dtConsulta(participantes, parametros, true);
    }


    public DataTable consultaDatosPrograma(string programa)
    {
        string participantes = "sp_datos_programa";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@programa", programa));
        database = new csDataBase();
        return database.dtConsulta(participantes, parametros, true);
    }

    public DataTable BuscaParticipantesCC(string busqueda, int distribuidor_id, int programa_id)
    {
        string participantes = "sp_busca_participantes_CC";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@busqueda", busqueda));
        parametros.Add(new SqlParameter("@distribuidor_id", distribuidor_id));
        parametros.Add(new SqlParameter("@programa_id", programa_id));
        database = new csDataBase();
        return database.dtConsulta(participantes, parametros, true);
    }

    public override void DatosParticipante()
    {
        string participante = "sp_datos_participante_complemento";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", this.ID));
        database = new csDataBase();
        DataTable dtParticipante = database.dtConsulta(participante, parametros, true);
        if (dtParticipante.Rows.Count > 0)
        {
            DataRow drP = dtParticipante.Rows[0];
            this.Clave = drP["clave"].ToString();
            this.Nombre = drP["nombre"].ToString();
            this.ApellidoPaterno = drP["apellido_paterno"].ToString();
            this.ApellidoMaterno = drP["apellido_materno"].ToString();
            this.NombreCompleto = drP["nombrecompleto"].ToString();
            this.RazoSocial = drP["razon_social"].ToString();
            this.Status_ID = drP["status_participante_id"].ToString();
            this.Clave_Status_Participante = drP["clave_status_participante"].ToString();
            this.Status = drP["status_participante"].ToString();
            this.Sexo_ID = drP["sexo_id"].ToString();
            this.Sexo = drP["sexo"].ToString();
            this.TipoParticipante_ID = drP["tipo_participante_id"].ToString();
            this.ClaveTipoParticipante = drP["clave_tipo_participante"].ToString();
            this.TipoParticipante = drP["tipo_participante"].ToString();
            this.CorreoElectronico = drP["correo_electronico"].ToString();
            this.EstadoCivil_ID = drP["estado_civil_id"].ToString();
            this.EstadoCivil = drP["estado_civil"].ToString();
            this.FechaNacimiento = drP["fecha_nacimiento"].ToString();
            this.ClaveDistribuidor = drP["clave_distribuidor"].ToString();
            this.Distribuidora_ID = drP["distribuidor_id"].ToString();
            this.Distribuidora = drP["distribuidor"].ToString();
            this.Escolaridad_ID = drP["escolaridad_id"].ToString();
            this.Escolaridad = drP["escolaridad"].ToString();
            this.Hijos = drP["hijos"].ToString();
            this.NHijos = drP["nhijos"].ToString();
            this.ProgramaID = drP["programa_id"].ToString();
            this.Programa = drP["programa"].ToString();
            this.ProgramaNombre = drP["programa_nombre"].ToString();
            CorreoElectronico2 = drP["correo_electronico2"].ToString();
            EquipoFutbol = drP["equipo_futbol"].ToString();
            InformacionEmail = drP["informacion_email"].ToString();
            InformacionSMS = drP["informacion_sms"].ToString();
            DistribuidorLogo = drP["distribuidor_logo"].ToString();
            DocumentoIdentidad = drP["documento_identidad"].ToString();
        }
    }

    public override void Inserta()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@clave", this.Clave));
        parametros.Add(new SqlParameter("@nombre", this.Nombre));
        parametros.Add(new SqlParameter("@apellido_paterno", this.ApellidoPaterno));
        parametros.Add(new SqlParameter("@apellido_materno", this.ApellidoMaterno));
        if (this.Sexo_ID != null)
            parametros.Add(new SqlParameter("@sexo_id", this.Sexo_ID));
        parametros.Add(new SqlParameter("@tipo_participante_id", this.TipoParticipante_ID));
        parametros.Add(new SqlParameter("@correo_electronico", this.CorreoElectronico));
        parametros.Add(new SqlParameter("@estado_civil_id", this.EstadoCivil_ID));
        if (this.FechaNacimiento != null && this.FechaNacimiento != "")
            parametros.Add(new SqlParameter("@fecha_nacimiento", Convert.ToDateTime(this.FechaNacimiento)));
        parametros.Add(new SqlParameter("@distributor_id", this.Distribuidora_ID));
        parametros.Add(new SqlParameter("@escolaridad_id", this.Escolaridad_ID));
        parametros.Add(new SqlParameter("@hijos", this.Hijos));
        parametros.Add(new SqlParameter("@nhijos", this.NHijos));
        parametros.Add(new SqlParameter("@status_participante", this.Status));
        parametros.Add(new SqlParameter("@correo_electronico2", CorreoElectronico2));
        if (this.equipo_futbol != null)
            parametros.Add(new SqlParameter("@equipo_futbol", EquipoFutbol));
        parametros.Add(new SqlParameter("@informacion_email", InformacionEmail));
        parametros.Add(new SqlParameter("@informacion_sms", InformacionSMS));
        parametros.Add(new SqlParameter("@documento_identidad", DocumentoIdentidad));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_inserta_participante_complemento";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        this.ID = database.consultaDato().ToString();
    }

    public override void Actualiza()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", this.ID));
        parametros.Add(new SqlParameter("@participante_id", this.ID));
        parametros.Add(new SqlParameter("@nombre", this.Nombre));
        parametros.Add(new SqlParameter("@apellido_paterno", this.ApellidoPaterno));
        parametros.Add(new SqlParameter("@apellido_materno", this.ApellidoMaterno));
        if (this.Sexo_ID != null)
        {
            parametros.Add(new SqlParameter("@sexo_id", this.Sexo_ID));
        }
        parametros.Add(new SqlParameter("@correo_electronico", this.CorreoElectronico));
        parametros.Add(new SqlParameter("@estado_civil_id", this.EstadoCivil_ID));
        if (this.Escolaridad_ID != null)
        {
            parametros.Add(new SqlParameter("@escolaridad_id", this.Escolaridad_ID));
        }
        if (this.Hijos != null)
        {
            parametros.Add(new SqlParameter("@hijos", this.Hijos));
        }
        if (this.NHijos != null)
        {
            parametros.Add(new SqlParameter("@nhijos", this.NHijos));
        }
        if (this.FechaNacimiento != null && this.FechaNacimiento != "")
        {
            parametros.Add(new SqlParameter("@fecha_nacimiento", Convert.ToDateTime(this.FechaNacimiento)));
        }
        parametros.Add(new SqlParameter("@correo_electronico2", CorreoElectronico2));
        parametros.Add(new SqlParameter("@tipo_participante_id", TipoParticipante_ID));
        if (this.equipo_futbol != null)
        {
            parametros.Add(new SqlParameter("@equipo_futbol", EquipoFutbol));
        }
        parametros.Add(new SqlParameter("@informacion_email", InformacionEmail));
        parametros.Add(new SqlParameter("@informacion_sms", null));
        parametros.Add(new SqlParameter("@documento_identidad", DocumentoIdentidad));

        SqlParameter param = new SqlParameter();
        param.ParameterName = "@status_participante";
        if (this.Status == null)
        {
            param.Value = DBNull.Value;
        }
        else
        {
            param.Value = this.Status;
        }
        parametros.Add(param);

        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_actualiza_participante";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public DataTable ConsultaPreferencia()
    {
        string consulta = "ObtieneParticipantePreferencia";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", this.ID));
        database = new csDataBase();
        return database.dtConsulta(consulta, parametros, true);
    }

    public DataTable ObtieneParticipanteTipoParticipanteDistribuidor()
    {
        string consulta = "obtiene_participante_tipo_participante_distribuidor";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@clave_tipo_participante", "GERENTE"));
        parametros.Add(new SqlParameter("@clave_distribuidor", this.ClaveDistribuidor));
        parametros.Add(new SqlParameter("@status_participante", this.Clave_Status_Participante));
        database = new csDataBase();
        return database.dtConsulta(consulta, parametros, true);
    }

    public void InsertaPreferencia(string categoria_id, string pasatiempo_id, string orden, string aspnet_UserId, string prioridad)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", this.ID));
        parametros.Add(new SqlParameter("@categoria_id", categoria_id));
        parametros.Add(new SqlParameter("@pasatiempo_id", pasatiempo_id));
        parametros.Add(new SqlParameter("@orden", orden));
        parametros.Add(new SqlParameter("@aspnet_UserId", aspnet_UserId));
        parametros.Add(new SqlParameter("@prioridad", prioridad));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "pasatiempo_participante_Insert";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public bool EliminaPasatiempo()
    {
        string acepta = "pasatiempo_participante_Delete";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", this.ID));
        database = new csDataBase();
        if (database.acutualizaDatos(acepta, parametros, true) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ActualizaClaveParticipante(string userId)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", this.ID));
        parametros.Add(new SqlParameter("@nuevaCLave", this.Clave));
        parametros.Add(new SqlParameter("@UserId", userId));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_actualiza_clave_participante";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    /* Inserta Transacción y Actualiza Saldo del Participante de AR */
    public bool InsertaTransaccion()
    {
        bool insertado = false;
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", this.ID));
        parametros.Add(new SqlParameter("@tipo_transaccion", tipo_transaccion));
        parametros.Add(new SqlParameter("@puntos", puntos));
        parametros.Add(new SqlParameter("@fecha", fecha));
        parametros.Add(new SqlParameter("@usuario_id", usuario_id));
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
        transaccion_id = Convert.ToInt16(database.consultaDato());
        if (transaccion_id > 0)
        {
            ActualizaSaldoParticipante();
            insertado = true;
        }
        return insertado;
    }

    private void ActualizaSaldoParticipante()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", this.ID));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        string query = "sp_actualiza_saldo_participante_todo";
        database.Query = query;
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }


    /// <summary>
    /// Obtiene todos los estados de cuenta del participante. La información la trae del mas reciente al mas antiguo
    /// </summary>
    /// <returns></returns>
    public DataSet ConsultaEstadoCuenta()
    {
        string transacciones = "sp_consulta_estado_cuenta";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", this.ID));
        database = new csDataBase();
        return database.dsConsulta(transacciones, parametros, true);
    }

    public void InsertaCometarioBlog(int Participante_id, string Mensaje)
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", Participante_id));
        parametros.Add(new SqlParameter("@mensaje", Mensaje));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        string query = "sp_agrega_blog";
        database.Query = query;
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    /// <summary>
    /// metodo para obtener vededores por area asignador al gerente de servicios financieros
    /// </summary>
    /// <param name="participante_id"></param>
    /// <param name="busqueda"></param>
    /// <returns></returns>
    public DataTable BuscarVendedores(string distribuidor_id, string busqueda)
    {
        string transacciones = "sp_busca_participantes_por_distribuidor";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@busqueda", busqueda));
        parametros.Add(new SqlParameter("@distribuidor_id", distribuidor_id));
        database = new csDataBase();
        return database.dtConsulta(transacciones, parametros, true);
    }

    public DataTable BuscarDatosChasis(string distribuidor_id, string chasis)
    {
        string transacciones = "sp_consultar_datos_chasis";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@distribuidor_id", distribuidor_id));
        parametros.Add(new SqlParameter("@chasis", chasis));
        database = new csDataBase();
        return database.dtConsulta(transacciones, parametros, true);
    }


    public int insertar_ventas_participante(string participante_id, string chasis, string userID)
    {
        string transacciones = "sp_insertar_ventas_participante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        parametros.Add(new SqlParameter("@chasis", chasis));
        parametros.Add(new SqlParameter("@userID", userID));

        database = new csDataBase();
        return database.acutualizaDatos(transacciones, parametros, true);
    }

    public DataTable ConsultaBlog(string programa, string estatus)
    {
        string transacciones = "sp_consulta_blog";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@programa", programa));
        parametros.Add(new SqlParameter("@statusblog", estatus));
        database = new csDataBase();
        return database.dtConsulta(transacciones, parametros, true);
    }

    public DataTable ConsultaBlogRespuestas(string programa, string estatus, int blog_id)
    {
        string transacciones = "sp_consulta_blog";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@programa", programa));
        parametros.Add(new SqlParameter("@statusblog", estatus));
        parametros.Add(new SqlParameter("@blog_id", blog_id));
        database = new csDataBase();
        return database.dtConsulta(transacciones, parametros, true);
    }
    public void InsertaCometarioBlog(int Participante_id, string Mensaje, string programa, int blog_id)
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", Participante_id));
        parametros.Add(new SqlParameter("@mensaje", Mensaje));
        parametros.Add(new SqlParameter("@programa", programa));
        if (blog_id != 0)
        {
            parametros.Add(new SqlParameter("@blog_id", blog_id));
        }
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        string query = "sp_agrega_blog";
        database.Query = query;
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public void InsertaHistoricoGalenia(int Participante_id, string Mensaje)
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", Participante_id));
        parametros.Add(new SqlParameter("@mensaje", Mensaje));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        string query = "sp_agrega_blog";
        database.Query = query;
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }
}
