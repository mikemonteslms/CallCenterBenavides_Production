using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

/// <summary>
/// Descripción breve de csParticipante
/// </summary>
/// 

public class csParticipante
{
    private string participante_id;
    private string razonsocial;
    private string clave;
    private string nombre;
    private string apellido_paterno;
    private string apellido_materno;
    private string nombre_completo;
    private string documento_identidad;
    private string status_id;
    private string clave_status_participante;
    private string status;
    private string fecha_status;
    private string sexo_id;
    private string sexo;
    private string tipo_participante_id;
    private string tipo_participante;
    private string clave_tipo_participante;
    private string correo_electronico;
    private string distribuidora_id;
    private string clave_distribuidor;
    private string distribuidora;
    private string programa_id;
    private string programa_clave;
    private string programa_nombre;
    private string programa;
    private string estado_civil_id;
    private string estado_civil;
    private string escolaridad_id;
    private string escolaridad;
    private string hijos;
    private string nhijos;
    private string fecha_nacimiento;
    private string saldo_actual;
    private string aspnet_UserId;
    private string saldo_actualCO;
    private string saldo_actualMX;
    private string ndias_cancelaCO;
    private string ndias_garantiaCO;
    private string origen_id;
    private string aceptaterminos;
    private string informacion_email;
    private string informacion_sms;
    protected csDataBase database;
    protected List<SqlParameter> parametros;
    protected SqlConnection conn;
    protected SqlTransaction tran;

    public csParticipante()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public csParticipante(SqlConnection conn)
    {
        this.conn = conn;
    }
    public csParticipante(SqlConnection conn, SqlTransaction tran)
    {
        this.conn = conn;
        this.tran = tran;
    }
    public string DocumentoIdentidad
    {
        get { return documento_identidad; }
        set { documento_identidad = value; }
    }
    public string ID
    {
        get
        {
            return participante_id;
        }
        set
        {
            participante_id = value;
        }
    }
    public string RazoSocial
    {
        get
        {
            return razonsocial;
        }
        set
        {
            razonsocial = value;
        }
    }
    public string Clave
    {
        get
        {
            return clave;
        }
        set
        {
            clave = value;
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
    {
        get
        {
            return nombre_completo;
        }
        set
        {
            nombre_completo = value;
        }
    }
    public string Status_ID
    {
        get
        {
            return status_id;
        }
        set
        {
            status_id = value;
        }
    }

    public string Clave_Status_Participante
    {
        get
        {
            return clave_status_participante;
        }
        set
        {
            clave_status_participante = value;
        }
    }

    public string Status
    {
        get
        {
            return status;
        }
        set { status = value; }
    }
    public string FechaStatus
    {
        get
        {
            return fecha_status;
        }
        set
        {
            fecha_status = value;
        }
    }
    public string Sexo_ID
    {
        get
        {
            return sexo_id;
        }
        set
        {
            sexo_id = value;
        }
    }
    public string Sexo
    {
        get
        {
            return sexo;
        }
        set
        {
            sexo = value;
        }
    }
    public string TipoParticipante_ID
    {
        get
        {
            return tipo_participante_id;
        }
        set
        {
            tipo_participante_id = value;
        }
    }
    public string ClaveTipoParticipante
    {
        get
        {
            return clave_tipo_participante;
        }
        set
        {
            clave_tipo_participante = value;
        }
    }
    public string TipoParticipante
    {
        get
        {
            return tipo_participante;
        }
        set
        {
            tipo_participante = value;
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
    public string Distribuidora_ID
    {
        get
        {
            return distribuidora_id;
        }
        set
        {
            distribuidora_id = value;
        }
    }

    public string ClaveDistribuidor
    {
        get
        {
            return clave_distribuidor;
        }
        set
        {
            clave_distribuidor = value;
        }
    }

    public string Distribuidora
    {
        get
        {
            return distribuidora;
        }
        set
        {
            distribuidora = value;
        }
    }
    public string Escolaridad_ID
    {
        get
        {
            return escolaridad_id;
        }
        set
        {
            escolaridad_id = value;
        }
    }
    public string Escolaridad
    {
        get
        {
            return escolaridad;
        }
        set
        {
            escolaridad = value;
        }
    }
    public string Hijos
    {
        get
        {
            return hijos;
        }
        set
        {
            hijos = value;
        }
    }
    public string NHijos
    {
        get
        {
            return nhijos;
        }
        set
        {
            nhijos = value;
        }
    }
    public string AceptaTerminos
    {
        get
        {
            return aceptaterminos;
        }
        set
        {
            aceptaterminos = value;
        }
    }
    public string InformacionEmail
    {
        get
        {
            return informacion_email;
        }
        set
        {
            informacion_email = value;
        }
    }
    public string InformacionSMS
    {
        get
        {
            return informacion_sms;
        }
        set
        {
            informacion_sms = value;
        }
    }
    public string ProgramaID
    {
        get { return programa_id; }
        set { programa_id = value; }
    }
    public string ProgramaClave
    {
        get { return programa_clave; }
        set { programa_clave = value; }
    }
    public string ProgramaNombre
    {
        get { return programa_nombre; }
        set { programa_nombre = value; }
    }
    public string Programa
    {
        get { return programa; }
        set { programa = value; }
    }
    public string EstadoCivil_ID
    {
        get
        {
            return estado_civil_id;
        }
        set
        {
            estado_civil_id = value;
        }
    }
    public string EstadoCivil
    {
        get
        {
            return estado_civil;
        }
        set
        {
            estado_civil = value;
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
    public string Aspnet_UserId
    {
        get
        {
            return aspnet_UserId;
        }
        set
        {
            aspnet_UserId = value;
        }
    }
    public virtual string Saldo
    {
        get
        {
            ObtenSaldo();
            return saldo_actual;
        }
    }

    public virtual string SaldoCO
    {
        get
        {
            ObtenSaldoCO();
            return saldo_actualCO;
        }
    }

    public virtual string SaldoMX
    {
        get
        {
            ObtenSaldoMX();
            return saldo_actualMX;
        }
    }

    public string DiasCancelaCO
    {
        get
        {
            return ndias_cancelaCO;
        }
        set
        {
            ndias_cancelaCO = value;
        }
    }

    public string DiasGarantiaCO
    {
        get
        {
            return ndias_garantiaCO;
        }
        set
        {
            ndias_garantiaCO = value;
        }
    }
    public string OrigenID
    {
        get
        {
            return origen_id;
        }
        set
        {
            origen_id = value;
        }
    }
    public DateTime Fecha(string country_code2)
    {
        country_code2 = country_code2.Trim().Length > 0 ? "'" + country_code2 + "'" : "null";
        csDataBase query = new csDataBase();
        query.Query = "select dbo.GetDateTimeByTimeZone(" + country_code2 + ")";
        query.EsStoreProcedure = false;
        return Convert.ToDateTime(query.consultaDato());
    }
    public DataTable BuscaParticipantes(string busqueda)
    {
        string participantes = "sp_busca_participantes";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@busqueda", busqueda));
        database = new csDataBase();
        return database.dtConsulta(participantes, parametros, true);
    }
    public virtual bool BuscaParticipantePorClave()
    {
        string participante = "sp_busca_participante_clave";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@clave", clave));
        database = new csDataBase();
        DataTable dtDatos = database.dtConsulta(participante, parametros, true);
        if (dtDatos.Rows.Count > 0)
        {
            DataRow drP = dtDatos.Rows[0];
            participante_id = drP["id"].ToString();
            clave = drP["clave_participante"].ToString();
            nombre = drP["nombre"].ToString();
            apellido_paterno = drP["apellido_paterno"].ToString();
            apellido_materno = drP["apellido_materno"].ToString();
            nombre_completo = drP["nombrecompleto"].ToString();
            status_id = drP["status_participante_id"].ToString();
            status = drP["status_participante"].ToString();
            sexo_id = drP["sexo_id"].ToString();
            sexo = drP["sexo"].ToString();
            tipo_participante_id = drP["tipo_participante_id"].ToString();
            tipo_participante = drP["tipo_participante"].ToString();
            correo_electronico = drP["correo_electronico"].ToString();
            estado_civil_id = drP["estado_civil_id"].ToString();
            estado_civil = drP["estado_civil"].ToString();
            fecha_nacimiento = drP["fecha_nacimiento"].ToString();
            distribuidora_id = drP["distributor_id"].ToString();
            distribuidora = drP["distributor"].ToString();
            escolaridad_id = drP["escolaridad_id"].ToString();
            escolaridad = drP["escolaridad"].ToString();
            hijos = drP["hijos"].ToString();
            nhijos = drP["nhijos"].ToString();
            return true;
        }
        else
        {
            return false;
        }
    }
    public virtual void DatosParticipante()
    {
        string participante = "sp_datos_participante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        DataTable dtParticipante = database.dtConsulta(participante, parametros, true);
        if (dtParticipante.Rows.Count > 0)
        {
            DataRow drP = dtParticipante.Rows[0];
            clave = drP["clave_participante"].ToString();
            nombre = drP["nombre"].ToString();
            apellido_paterno = drP["apellido_paterno"].ToString();
            apellido_materno = drP["apellido_materno"].ToString();
            nombre_completo = drP["nombrecompleto"].ToString();
            status_id = drP["status_participante_id"].ToString();
            status = drP["status_participante"].ToString();
            sexo_id = drP["sexo_id"].ToString();
            sexo = drP["sexo"].ToString();
            tipo_participante_id = drP["tipo_participante_id"].ToString();
            tipo_participante = drP["tipo_participante"].ToString();
            correo_electronico = drP["correo_electronico"].ToString();
            estado_civil_id = drP["estado_civil_id"].ToString();
            estado_civil = drP["estado_civil"].ToString();
            fecha_nacimiento = drP["fecha_nacimiento"].ToString();
            distribuidora_id = drP["distributor_id"].ToString();
            distribuidora = drP["distributor"].ToString();
            escolaridad_id = drP["escolaridad_id"].ToString();
            escolaridad = drP["escolaridad"].ToString();
            hijos = drP["hijos"].ToString();
            nhijos = drP["nhijos"].ToString();
            programa_id = drP["programa_id"].ToString();
            programa_clave = drP["programa_clave"].ToString();
            programa = drP["programa"].ToString();
        }
    }
    public virtual void Inserta()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@razonsocial", razonsocial));
        parametros.Add(new SqlParameter("@clave", clave));
        parametros.Add(new SqlParameter("@nombre", nombre));
        parametros.Add(new SqlParameter("@apellido_paterno", apellido_paterno));
        parametros.Add(new SqlParameter("@apellido_materno", apellido_materno));
        parametros.Add(new SqlParameter("@sexo_id", sexo_id));
        parametros.Add(new SqlParameter("@tipo_participante_id", tipo_participante_id));
        parametros.Add(new SqlParameter("@correo_electronico", correo_electronico));
        parametros.Add(new SqlParameter("@estado_civil_id", estado_civil_id));
        parametros.Add(new SqlParameter("@fecha_nacimiento", String.IsNullOrEmpty(this.FechaNacimiento) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(fecha_nacimiento)));
        parametros.Add(new SqlParameter("@distribuidor_id", distribuidora_id));
        parametros.Add(new SqlParameter("@aceptaterminos", aceptaterminos));
        parametros.Add(new SqlParameter("@status_participante", status));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_inserta_participante";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        participante_id = database.consultaDato().ToString();
    }
    public virtual void ActualizaSaldo()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_actualiza_saldo_participante_todo";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public virtual void ActualizaSaldoCO()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_actualiza_saldo_participante_todo";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public virtual void ActualizaSaldoMX()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_actualiza_saldo_participante_todo";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public virtual void Actualiza()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        parametros.Add(new SqlParameter("@clave", clave));
        parametros.Add(new SqlParameter("@nombre", nombre));
        parametros.Add(new SqlParameter("@apellido_paterno", apellido_paterno));
        parametros.Add(new SqlParameter("@apellido_materno", apellido_materno));
        parametros.Add(new SqlParameter("@razon_social", razonsocial));
        parametros.Add(new SqlParameter("@documento_identidad", documento_identidad));
        parametros.Add(new SqlParameter("@correo_electronico", correo_electronico));
        parametros.Add(new SqlParameter("@sexo_id", sexo_id));
        parametros.Add(new SqlParameter("@estado_civil_id", estado_civil_id));
        parametros.Add(new SqlParameter("@fecha_nacimiento", String.IsNullOrEmpty(this.FechaNacimiento) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(fecha_nacimiento)));//String.IsNullOrEmpty(this.FechaNacimiento) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(fecha_nacimiento)));
        parametros.Add(new SqlParameter("@distribuidor_id", distribuidora_id));
        parametros.Add(new SqlParameter("@tipo_participante_id", tipo_participante_id));
        parametros.Add(new SqlParameter("@status_participante_id", Status_ID));
        parametros.Add(new SqlParameter("@fecha_status", null));
        parametros.Add(new SqlParameter("@acepta_terminos", aceptaterminos));
        parametros.Add(new SqlParameter("@informacion_email", informacion_email));
        parametros.Add(new SqlParameter("@informacion_sms", null));
        parametros.Add(new SqlParameter("@escolaridad_id", null));
        parametros.Add(new SqlParameter("@hijos", null));
        parametros.Add(new SqlParameter("@nhijos", null));
        parametros.Add(new SqlParameter("@ocupacion_id", null));
        parametros.Add(new SqlParameter("@usuario_id", aspnet_UserId));
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

    private void ObtenSaldo()
    {
        string saldoparticipante = "sp_obtiene_saldo_participante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        saldo_actual = database.consultaDato(saldoparticipante, parametros, true).ToString();
    }
    private void ObtenSaldoCO()
    {
        string saldoparticipante = "sp_obtiene_saldo_participante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        saldo_actualCO = database.consultaDato(saldoparticipante, parametros, true).ToString();
    }

    private void ObtenSaldoMX()
    {
        string saldoparticipante = "sp_obtiene_saldo_participante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        saldo_actualMX = database.consultaDato(saldoparticipante, parametros, true).ToString();
    }

    public bool ExisteBonoBienvenida()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_existe_bono_bienvenida";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        int b = Convert.ToInt32(database.consultaDato().ToString());
        if (b > 0)
            return true;
        else
            return false;
    }
    public void GeneraBonoBienvenida()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_genera_bono_bienvenida";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public void InsertaTelefono(string tipo_telefono_id, string lada, string telefono, string extension, string operadora_id)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        parametros.Add(new SqlParameter("@tipo_telefono_id", tipo_telefono_id));
        parametros.Add(new SqlParameter("@lada", lada));
        parametros.Add(new SqlParameter("@telefono", telefono));
        parametros.Add(new SqlParameter("@extension", extension));
        parametros.Add(new SqlParameter("@operadora_id", operadora_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_inserta_telefono_participante";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }



    public void ActualizaTelefono(string telefono_id, string lada, string telefono, string extension, string tipo_telefono_id, string operadora_id)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@telefono_id", telefono_id));
        parametros.Add(new SqlParameter("@tipo_telefono_id", tipo_telefono_id));
        parametros.Add(new SqlParameter("@lada", lada));
        parametros.Add(new SqlParameter("@telefono", telefono));
        parametros.Add(new SqlParameter("@extension", extension));
        parametros.Add(new SqlParameter("@operadora_id", operadora_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_actualiza_telefono_participante";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }



    public void EliminaTelefono(int telefono_id)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@telefono_id", telefono_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_elimina_telefono_participante";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public DataTable ConsultaTelefono()
    {
        string consulta = "sp_consulta_telefono_participante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        return database.dtConsulta(consulta, parametros, true);
    }


    public DataTable Transacciones()
    {
        string transacciones = "sp_consulta_transacciones";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        return database.dtConsulta(transacciones, parametros, true);
    }
    public DataTable Participan(string tipo_participante)
    {
        string participa = "sp_consulta_participantes";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@tipo_participante", tipo_participante));
        database = new csDataBase();
        return database.dtConsulta(participa, parametros, true);
    }

    public DataTable DireccionesExistentes()
    {
        string direcciones = "sp_direcciones_participante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        return database.dtConsulta(direcciones, parametros, true);
    }

    public DataTable DetalleCanjes()
    {
        string detallecanjes = "sp_detalle_canje_participante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        return database.dtConsulta(detallecanjes, parametros, true);
    }
    public DataTable DetallePremio(string transaccion_premio_id)
    {
        string detallepremio = "sp_detalle_premio";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_premio_id", transaccion_premio_id));
        database = new csDataBase();
        return database.dtConsulta(detallepremio, parametros, true);
    }

    public DataTable DetallePremioCO(string transaccion_premio_id)
    {
        string detallepremio = "sp_detalle_premio_co";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_premio_id", transaccion_premio_id));
        database = new csDataBase();
        return database.dtConsulta(detallepremio, parametros, true);
    }

    public void ObtieneDiasPlazoCancelar(string transaccion_premio_id)
    {
        string dias = "Obtiene_Dias_Plazo_Cancelar";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_premio_id", transaccion_premio_id));
        database = new csDataBase();
        ndias_cancelaCO = database.consultaDato(dias, parametros, true).ToString();
    }

    public void ObtieneDiasPlazoGarantia(DateTime fecha_entrega)
    {
        string dias = "Obtiene_Dias_Plazo_Garantia";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@fecha_entrega", fecha_entrega));
        database = new csDataBase();
        ndias_garantiaCO = database.consultaDato(dias, parametros, true).ToString();
    }

    public DataTable DetallePremioMX(string transaccion_premio_id)
    {
        string detallepremio = "sp_detalle_premio";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_premio_id", transaccion_premio_id));
        database = new csDataBase();
        return database.dtConsulta(detallepremio, parametros, true);
    }

    public bool AceptraTerminos()
    {
        string acepta = "sp_participante_acepta_terminos";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
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
    public bool TerminosAceptados()
    {
        string acepta = "sp_consulta_participante_acepta_terminos";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        if (Convert.ToInt32(database.consultaDato(acepta, parametros, true)) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void participante_aspnet_User(string participante_id, string aspnet_UserId)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        parametros.Add(new SqlParameter("@aspnet_UserId", aspnet_UserId));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "participante_aspnet_User_Insert";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public DataTable ConsultaObjetivos_co()
    {
        string transacciones = "sp_consulta_objetivos";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        return database.dtConsulta(transacciones, parametros, true);
    }

    /// <summary>
    /// Obtiene todos los estados de cuenta del participante. La información la trae del mas reciente al mas antiguo
    /// </summary>
    /// <returns></returns>
    public DataTable ConsultaEstadoCuenta()
    {
        string transacciones = "sp_consulta_estado_cuenta";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        return database.dtConsulta(transacciones, parametros, true);
    }

    public DataTable ConsultaDetalleEstadoCuenta(int estado_cuenta_id)
    {
        string transacciones = "sp_consulta_estado_cuenta_detalle";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@estado_cuenta_id", estado_cuenta_id));
        database = new csDataBase();
        return database.dtConsulta(transacciones, parametros, true);
    }

    public string ObtenSaldoPublico()
    {
        string saldoparticipante = "sp_obtiene_saldo_participante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        return saldo_actual = database.consultaDato(saldoparticipante, parametros, true).ToString();
    }

    public DataTable ValidaParticipantePublico(string razon_social, string numero_cliente)
    {
        DataTable valida = new DataTable();
        string query = "sp_valida_participante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@razon_social", razon_social));
        parametros.Add(new SqlParameter("@numero_cliente", numero_cliente));
        database = new csDataBase();
        return valida = database.dtConsulta(query, parametros, true);
    }

    public DataTable ConsultaDatosParticipante()
    {
        string participante = "sp_consulta_participante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        DataTable dtParticipante = database.dtConsulta(participante, parametros, true);
        return dtParticipante;
    }

    public DataTable HistoricoVentas()
    {

        string transacciones = "sp_consulta_historico_ventas";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        database = new csDataBase();
        return database.dtConsulta(transacciones, parametros, true);
    }

    public bool ActualizaEmail(int participante_id, string Email)
    {
        try
        {
            string transacciones = "sp_Actualiza_Email";
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@participante_id", participante_id));
            parametros.Add(new SqlParameter("@email", Email));
            database = new csDataBase();
            database.dtConsulta(transacciones, parametros, true);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public List<csDistribuidor> ConsultaDistribuidores()
    {
        List<csDistribuidor> listadistris = new List<csDistribuidor>();

        using (EntitiesModel.EntitiesModel modelo = new EntitiesModel.EntitiesModel(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var distris = from _pd in modelo.participante_distribuidors
                          where _pd.participante_id == long.Parse(this.ID)
                          select new
                          {
                              id = _pd.distribuidor.id,
                              clave = _pd.distribuidor.clave,
                              descripcion = _pd.distribuidor.descripcion,
                              url_programa = _pd.distribuidor.programa.url_programa,
                              programa_clave = _pd.distribuidor.programa.clave
                          };
            if (distris != null & distris.Count() > 0)
            {
                foreach (var mid in distris)
                {
                    csDistribuidor _d = new csDistribuidor();
                    _d.ID = Convert.ToInt32(mid.id);
                    _d.Clave = mid.clave;
                    _d.Descripcion = mid.descripcion;
                    _d.Programa = mid.url_programa;
                    _d.ClavePrograma = mid.programa_clave;
                    listadistris.Add(_d);
                }
            }
            else
            {
                distris = from _p in modelo.participantes
                          where _p.id == long.Parse(this.ID)
                          select new
                          {
                              id = _p.distribuidor.id,
                              clave = _p.distribuidor.clave,
                              descripcion = _p.distribuidor.descripcion,
                              url_programa = _p.distribuidor.programa.url_programa,
                              programa_clave = _p.distribuidor.programa.clave
                          };
                foreach (var mid in distris)
                {
                    csDistribuidor _d = new csDistribuidor();
                    _d.ID = Convert.ToInt32(mid.id);
                    _d.Clave = mid.clave;
                    _d.Descripcion = mid.descripcion;
                    _d.Programa = mid.url_programa;
                    _d.ClavePrograma = mid.programa_clave;

                    listadistris.Add(_d);
                }
            }
        }
        return listadistris;
    }
}
