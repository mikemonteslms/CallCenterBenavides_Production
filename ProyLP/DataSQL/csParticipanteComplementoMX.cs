using System;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;
using CallCenterDB;
using System.Web.Security;
using System.Data.Linq;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenterDB;


/// <summary>
/// Descripción breve de csParticipanteComplemento
/// </summary>
/// 

public class csParticipanteComplementoMX : csParticipante
{
    private string correo_electronico2;
    private string equipo_futbol;
    private string informacion_email;
    private string informacion_sms;
    private string distribuidor_logo;
    private string documento_identidad;

    private string canal_id;
    private string canal;
    private string sucursal_id;
    private string sucursal;
    private string escolaridad_estatus_id;
    private string escolaridad_estatus;
    private string beneficios;
    private string premios;
    private string password;
    private int transaccion_premio_id;
    private string participante_id;
    private string usuario_id;
    private string tipo_transaccion;
    private string tipo_transaccion_id;
    private int puntos;
    private DateTime fecha;
    private int transaccion_id;

    public int Transaccion_id
    {
        get { return transaccion_id; }
    }

    public override string Saldo
    {
        get
        {
            return ObtenSaldo();
        }
    }

    private string ObtenSaldo()
    {
        string saldoparticipante = "sp_obtiene_saldo_participante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", this.ID));
        database = new csDataBase();
        return database.consultaDato(saldoparticipante, parametros, true).ToString();
    }
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
    public string InformacionEmail
    {
        get { return informacion_email; }
        set { informacion_email = value; }
    }
    public string InformacionSMS
    {
        get { return informacion_sms; }
        set { informacion_sms = value; }
    }
    public string DistribuidorLogo
    {
        get { return distribuidor_logo; }
        set { distribuidor_logo = value; }
    }
    public string DocumentoIdentidad
    {
        get { return documento_identidad; }
        set { documento_identidad = value; }
    }

    public string CanalID
    {
        get { return canal_id; }
        set { canal_id = value; }
    }
    public string Canal
    {
        get { return canal; }
        set { canal = value; }
    }
    public string SucursalID
    {
        get { return sucursal_id; }
        set { sucursal_id = value; }
    }
    public string Sucursal
    {
        get { return sucursal; }
        set { sucursal = value; }
    }
    public string StatusEscolaridadID
    {
        get { return escolaridad_estatus_id; }
        set { escolaridad_estatus_id = value; }
    }
    public string StatusEscolaridad
    {
        get { return escolaridad_estatus; }
        set { escolaridad_estatus = value; }
    }
    public string Beneficios
    {
        get { return beneficios; }
        set { beneficios = value; }
    }
    public string Premios
    {
        get { return premios; }
        set { premios = value; }
    }
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    //
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
    public DateTime Fecha
    {
        set { fecha = value; }
    }
    //
    public csParticipanteComplementoMX()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public csParticipanteComplementoMX(SqlConnection conn)
    {
        this.conn = conn;
    }
    public csParticipanteComplementoMX(SqlConnection conn, SqlTransaction tran)
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

    public DataTable BuscaParticipantes(string busqueda, int countryid)
    {
        string participantes = "sp_busca_participantes";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@busqueda", busqueda));
        parametros.Add(new SqlParameter("@countryid", countryid));
        database = new csDataBase();
        return database.dtConsulta(participantes, parametros, true);
    }

    public override void DatosParticipante()
    {
        using (ParticipanteDataContext pcdt = new ParticipanteDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var query = from p in pcdt.participante
                        from pc in pcdt.participante_complemento.Where(_pc => p.id == _pc.participante_id).DefaultIfEmpty()
                        from sp in pcdt.status_participante.Where(_sp => _sp.id == p.status_participante_id).DefaultIfEmpty()
                        from sex in pcdt.sexo.Where(_sex => _sex.id == p.sexo_id).DefaultIfEmpty()
                        from tp in pcdt.tipo_participante.Where(_tp => _tp.id == p.tipo_participante_id).DefaultIfEmpty()
                        from ec in pcdt.estado_civil.Where(_ec => _ec.id == p.estado_civil_id).DefaultIfEmpty()
                        from d1 in pcdt.distribuidor.Where(_d1 => _d1.id == p.distribuidor_id).DefaultIfEmpty()
                        from prog in pcdt.programas.Where(_cou => _cou.id == d1.programa_id).DefaultIfEmpty()
                        from esc in pcdt.escolaridad.Where(_esc => _esc.id == pc.escolaridad_id).DefaultIfEmpty()
                        where p.id == Convert.ToDecimal(this.ID)
                        select new
                        {
                            Participante = p,
                            ParticipanteComplemento = pc,
                            Sexo = sex,
                            StatusParticipante = sp,
                            TipoParticipante = tp,
                            EstadoCivil = ec,
                            Distributor = d1,
                            Programa = prog,
                            Escolaridad = esc
                        };
            if (query != null)
            {
                var results = (from r in query.AsEnumerable()
                               select new
                               {
                                   Clave = r.Participante.clave != null ? r.Participante.clave : "",
                                   Nombre = r.Participante.nombre != null ? r.Participante.nombre : "",

                                   ApellidoPaterno = r.Participante.apellido_paterno != null ? r.Participante.apellido_paterno : "",
                                   ApellidoMaterno = r.Participante.apellido_materno != null ? r.Participante.apellido_materno : "",
                                   NombreCompleto = r.Participante.nombre + " " + r.Participante.apellido_paterno + " " + r.Participante.apellido_materno,
                                   RazoSocial = r.Participante.razon_social != null ? r.Participante.razon_social : "",
                                   StatusParticipanteID = r.Participante.status_participante_id,
                                   StatusParticipante = r.StatusParticipante != null ? r.StatusParticipante.descripcion : "",
                                   SexoID = r.Participante.sexo_id != null ? r.Participante.sexo_id : 0,
                                   Sexo = r.Sexo != null ? r.Sexo.descripcion : "",
                                   TipoParticipanteID = r.Participante.tipo_participante_id != null ? r.Participante.tipo_participante_id : 0,
                                   TipoParticipante = r.TipoParticipante != null ? r.TipoParticipante.descripcion : "",
                                   CorreoElectronico = r.Participante.correo_electronico != null ? r.Participante.correo_electronico : "",
                                   EstadoCivilID = r.Participante.estado_civil_id != null ? r.Participante.estado_civil_id : 0,
                                   EstadoCivil = r.EstadoCivil != null ? r.EstadoCivil.descripcion : "",
                                   FechaNacimiento = r.Participante.fecha_nacimiento != null ? r.Participante.fecha_nacimiento : new DateTime(2012, 11, 1),
                                   DistribuidorID = r.Participante.distribuidor_id != null ? r.Participante.distribuidor_id : 0,
                                   Distribuidor = r.Distributor != null ? r.Distributor.descripcion : "",
                                   DistribuidorLogo = r.Distributor != null ? r.Distributor.url_imagen : ConfigurationManager.AppSettings["estilos"] + "/imgages/logo_pasion-ganar.png",
                                   EscolaridadID = (r.ParticipanteComplemento != null && r.ParticipanteComplemento.escolaridad_id != null) ? r.ParticipanteComplemento.escolaridad_id : 0,
                                   Escolaridad = r.Escolaridad != null ? r.Escolaridad.descripcion : "",
                                   TieneHijos = (r.ParticipanteComplemento != null && r.ParticipanteComplemento.hijos != null) ? r.ParticipanteComplemento.hijos : 0,
                                   NumeroHijos = (r.ParticipanteComplemento != null && r.ParticipanteComplemento.nhijos != null) ? r.ParticipanteComplemento.nhijos : 0,
                                   ProgramaID = r.Distributor.programa_id,
                                   ProgramaClave = (r.Programa != null) ? r.Programa.clave : "",
                                   Programa = (r.Programa != null) ? r.Programa.descripcion_larga : "",
                                   DocumentoIdentidad = (r.Participante != null && r.Participante.documento_identidad != null) ? r.Participante.documento_identidad : "",
                                   InformacionEmail = (r.Participante != null && r.Participante.informacion_email != null) ? r.Participante.informacion_email : 0,
                                   InformacionSMS = (r.Participante != null && r.Participante.informacion_sms != null) ? r.Participante.informacion_sms : 0
                               }).ToList().Single();

                this.Clave = results.Clave;
                this.Nombre = results.Nombre;
                this.ApellidoPaterno = results.ApellidoPaterno;
                this.ApellidoMaterno = results.ApellidoMaterno;
                this.NombreCompleto = results.NombreCompleto;
                this.Status_ID = results.StatusParticipanteID.ToString();
                this.Status = results.StatusParticipante;
                this.Sexo_ID = results.SexoID.ToString();
                this.Sexo = results.Sexo;
                this.TipoParticipante_ID = results.TipoParticipanteID.ToString();
                this.TipoParticipante = results.TipoParticipante;
                this.CorreoElectronico = results.CorreoElectronico;
                this.EstadoCivil_ID = results.EstadoCivilID.ToString();
                this.EstadoCivil = results.EstadoCivil;
                this.RazoSocial = results.RazoSocial;
                this.FechaNacimiento = results.FechaNacimiento.ToString();
                this.Distribuidora_ID = results.DistribuidorID.ToString();
                this.Distribuidora = results.Distribuidor;
                this.DistribuidorLogo = results.DistribuidorLogo;
                this.Escolaridad_ID = results.EscolaridadID.ToString();
                this.Escolaridad = results.Escolaridad;
                this.Hijos = results.TieneHijos.ToString();
                this.NHijos = results.NumeroHijos.ToString();
                this.ProgramaID = results.ProgramaID.ToString();
                this.ProgramaClave = results.ProgramaClave;
                this.Programa = results.Programa;
                this.informacion_email = results.InformacionEmail.ToString();
                this.informacion_sms = results.InformacionSMS.ToString();
                DocumentoIdentidad = results.DocumentoIdentidad;
            }
        }
    }
    public override void ActualizaSaldo()
    {
        parametros = new List<SqlParameter>();
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
        database.Query = "sp_actualiza_saldo_participante_todo";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
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
        using (ParticipanteDataContext pcdt = new ParticipanteDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            // Actualiza Participante
            var p = pcdt.participante.Single(_p => _p.id == Convert.ToDecimal(this.ID));
            p.nombre = this.Nombre;
            p.apellido_paterno = this.ApellidoPaterno;
            p.apellido_materno = this.ApellidoMaterno;
            if (this.Status_ID != null)
            {
                p.status_participante_id = Convert.ToDecimal(this.Status_ID);
                p.fecha_status = DateTime.Now;
            }
            p.sexo_id = Convert.ToDecimal(this.Sexo_ID);
            if (this.TipoParticipante_ID != null)
            {
                p.tipo_participante_id = Convert.ToDecimal(this.TipoParticipante_ID);
            }
            p.correo_electronico = this.CorreoElectronico;
            p.estado_civil_id = Convert.ToDecimal(this.EstadoCivil_ID);
            p.fecha_nacimiento = Convert.ToDateTime(this.FechaNacimiento);
            if (this.Distribuidora_ID != null)
            {
                p.distribuidor_id = Convert.ToDecimal(this.Distribuidora_ID);
            }
            // Actualiza ParticipanteComplemento

            var pc = pcdt.participante_complemento.Single(_pc => _pc.participante_id == Convert.ToDecimal(this.ID));
            if (this.DocumentoIdentidad != null)
            {
                p.documento_identidad = this.DocumentoIdentidad;
            }
            if (this.Escolaridad_ID != null)
            {
                pc.escolaridad_id = Convert.ToDecimal(this.Escolaridad_ID);
            }
            //if (this.Hijos != null)
            //{
            //    pc.hijos = Convert.ToDecimal(this.Hijos);
            //}
            if (this.NHijos != null)
            {
                pc.nhijos = Convert.ToDecimal(this.NHijos);
            }
            //if (this.CanalID != null)
            //{
            //    pc.canal_id = Convert.ToDecimal(this.CanalID);
            //}
            //if (this.SucursalID != null)
            //{
            //    pc.branch_id = Convert.ToDecimal(this.SucursalID);
            //}
            //if (this.StatusEscolaridadID != null)
            //{
            //    pc.escolaridad_status_id = Convert.ToDecimal(this.StatusEscolaridadID);
            //}
            //pc.beneficios = this.Beneficios;
            //pc.premios = this.Premios;
            p.informacion_email = Convert.ToByte(this.informacion_email);
            p.informacion_sms = Convert.ToByte(this.informacion_sms);

            // Actualizar la BD
            pcdt.SubmitChanges();

            // Actualiza Membership
            try
            {
                var u = (from pu in pcdt.participante_aspnet_User where pu.participante_id == Convert.ToDecimal(this.ID) select pu).Single();
                if (u != null)
                {
                    MembershipUser mu = Membership.GetUser(new Guid(u.aspnet_UserId.ToString()));
                    mu.Email = this.CorreoElectronico;
                    Membership.UpdateUser(mu);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    //public DataTable ConsultaPreferencia()
    //{
    //    string consulta = "ObtieneParticipantePreferencia_co";
    //    parametros = new List<SqlParameter>();
    //    parametros.Add(new SqlParameter("@participante_id", this.ID));
    //    database = new csDataBase();
    //    return database.dtConsulta(consulta, parametros, true);
    //}

    //public void InsertaPreferencia(string categoria_id, string pasatiempo_id, string orden, string aspnet_UserId, string prioridad)
    //{
    //    parametros = new List<SqlParameter>();
    //    parametros.Add(new SqlParameter("@participante_id", this.ID));
    //    parametros.Add(new SqlParameter("@categoria_id", categoria_id));
    //    parametros.Add(new SqlParameter("@pasatiempo_id", pasatiempo_id));
    //    parametros.Add(new SqlParameter("@orden", orden));
    //    parametros.Add(new SqlParameter("@aspnet_UserId", aspnet_UserId));
    //    parametros.Add(new SqlParameter("@prioridad", prioridad));
    //    database = new csDataBase();
    //    if (this.conn != null)
    //    {
    //        database.Conexion = conn;
    //    }
    //    if (this.tran != null)
    //    {
    //        database.Transaccion = tran;
    //    }
    //    database.Query = "pasatiempo_participante_Insert_co";
    //    database.Parametros = parametros;
    //    database.EsStoreProcedure = true;
    //    database.acutualizaDatos();
    //}

    //public bool EliminaPasatiempo()
    //{
    //    string acepta = "pasatiempo_participante_Delete";
    //    parametros = new List<SqlParameter>();
    //    parametros.Add(new SqlParameter("@participante_id", this.ID));
    //    database = new csDataBase();
    //    if (database.acutualizaDatos(acepta, parametros, true) > 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    private decimal InsertaMX(csParticipanteComplementoMX part)
    {
        using (ParticipanteDataContext pcdt = new ParticipanteDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            // Inserta participante
            var tp_id = pcdt.tipo_participante.SingleOrDefault(_tp => _tp.descripcion_larga.ToUpper() == part.TipoParticipante.ToUpper());
            var sp_id = pcdt.status_participante.SingleOrDefault(_sp_id => _sp_id.descripcion == part.Status && _sp_id.clave.ToLower() == "mx");
            var ec_id = pcdt.estado_civil.SingleOrDefault(_ec_id => _ec_id.descripcion == part.EstadoCivil && _ec_id.clave.ToLower() == "mx");
            var d_id = pcdt.distribuidor.SingleOrDefault(_d_id => _d_id.descripcion == part.Distribuidora);

            participante Participante = new participante();
            Participante.clave = part.Clave;
            Participante.nombre = part.Nombre;
            try
            {
                Participante.tipo_participante_id = tp_id.id;
            }
            catch
            {
                Participante.tipo_participante_id = 2;
            }
            try
            {
                Participante.status_participante_id = sp_id.id;
            }
            catch
            {
                Participante.status_participante_id = 7;
            }
            Participante.correo_electronico = part.CorreoElectronico;
            try
            {
                Participante.estado_civil_id = ec_id.id;
            }
            catch
            {
            }
            try
            {
                Participante.fecha_nacimiento = Convert.ToDateTime(part.FechaNacimiento);
            }
            catch
            {
                Participante.fecha_nacimiento = new DateTime(2000, 1, 1);
            }

            Participante.distribuidor_id = d_id.id;
            Participante.fecha_status = DateTime.Now;
            Participante.fecha_alta = new DateTime(2012, 12, 1);

            pcdt.participante.InsertOnSubmit(Participante);
            pcdt.SubmitChanges();

            // Inserta Membership
            MembershipCreateStatus st = new MembershipCreateStatus();
            MembershipUser usr = Membership.CreateUser(part.Clave, part.Password, part.CorreoElectronico, "Pregunta secreta", "Respuesta secreta", part.Status.ToUpper() == "ACTIVO" ? true : false, out st);
            if (usr != null)
            {
                Roles.AddUserToRole(usr.UserName, "vendedor");
                // Inserta participante usuario
                participante_aspnet_User pu = new participante_aspnet_User();
                pu.participante_id = Participante.id;
                pu.aspnet_UserId = new Guid(usr.ProviderUserKey.ToString());
                pu.fecha = DateTime.Now;
                pcdt.participante_aspnet_User.InsertOnSubmit(pu);
            }

            // Inserta participante complemento
            //var c_id = pcdt.canal.SingleOrDefault(_c_id => _c_id.descripcion == part.Canal);

            participante_complemento ParticipanteComplemento = new participante_complemento();
            ParticipanteComplemento.participante_id = Participante.id;
            Participante.informacion_email = 0;
            Participante.informacion_sms = 0;
            Participante.documento_identidad = part.Clave;
            //try
            //{
            //    ParticipanteComplemento.canal_id = c_id.id;
            //}
            //catch
            //{
            //    ParticipanteComplemento.canal_id = 1;
            //}

            if (part.Hijos != null || Convert.ToInt32(part.Hijos) > 0)
            {
                ParticipanteComplemento.hijos = 1;
                try
                {
                    ParticipanteComplemento.nhijos = Convert.ToDecimal(part.Hijos);
                }
                catch
                {
                    ParticipanteComplemento.nhijos = 0;
                }

            }
            pcdt.participante_complemento.InsertOnSubmit(ParticipanteComplemento);
            pcdt.SubmitChanges();

            return Participante.id;
        }
    }

    /** Carga Inicial Baja de Participante ****/
    public List<csParticipanteComplementoMX>[] CargaInicialBaja(MembershipUser usuario_id)
    {
        List<csParticipanteComplementoMX> lista_insertados = new List<csParticipanteComplementoMX>();
        List<csParticipanteComplementoMX> lista_error = new List<csParticipanteComplementoMX>();
        csDataBase query = new csDataBase();
        query.Query = "Obtiene_Tmp_Usuarios_Baja";
        query.EsStoreProcedure = true;
        DataTable dt = query.dtConsulta();
        foreach (DataRow dr in dt.Rows)
        {
            csParticipanteComplementoMX p = new csParticipanteComplementoMX();
            p.Clave = dr["clave_participante"].ToString();
            p.Nombre = dr["nombre"].ToString();
            p.CorreoElectronico = dr["correo_electronico"].ToString();
            p.Distribuidora = dr["distribuidor"].ToString();
            p.FechaStatus = dr["fecha_salida"].ToString();

            try
            {
                /* Busca y valida si esta ese participante **/
                DataTable dtValidaParticipante = ValidaParticipanteDistribuidor(p.Clave, p.Distribuidora);
                if (dtValidaParticipante.Rows.Count > 0)
                {
                    DataRow drValidaParticipante = dtValidaParticipante.Rows[0];
                    string participante_id = drValidaParticipante["id"].ToString();
                    // Obtiene el Id del estatus del participante para inactivo                                
                    DataTable dtObtieneIdStatusParticipante = ObtieneIdStatusParticipante("mx", "I_mx");
                    if (dtObtieneIdStatusParticipante.Rows.Count > 0)
                    {
                        DataRow drObtieneIdStatusParticipante = dtObtieneIdStatusParticipante.Rows[0];
                        string statusParticipanteId = drObtieneIdStatusParticipante["id"].ToString();
                        // actualiza el estatus de participante //
                        // se da de baja 60 dias después, por tarea programada
                        if (ActualizaStatusParticipante(p.Clave, statusParticipanteId, p.FechaStatus) == true)
                        {
                            p.ID = participante_id.ToString();
                            lista_insertados.Add(p);
                        }
                        else
                        {
                            p.Status = "Ocurrio un error al actualizar status del participante";
                            lista_error.Add(p);
                        }
                    }
                    else
                    {
                        p.Status = "No se encontro el status del participante";
                        lista_error.Add(p);
                    }
                }
                else
                {
                    p.Status = "No se encontro el participante";
                    lista_error.Add(p);
                }
            }
            catch (Exception ex)
            {
                p.Status = ex.Message;
                if (ex.InnerException != null)
                {
                    p.Status += "<br/>" + ex.InnerException.Message;
                }
                lista_error.Add(p);
            }
        }
        List<csParticipanteComplementoMX>[] listas = new List<csParticipanteComplementoMX>[2];
        listas[0] = lista_insertados;
        listas[1] = lista_error;
        return listas;
    }

    public DataTable ValidaParticipanteDistribuidor(string clave_participante, string distribuidor)
    {
        string consulta = "sp_valida_participante_distribuidor";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@clave_participante", clave_participante));
        parametros.Add(new SqlParameter("@distribuidor", distribuidor));
        database = new csDataBase();
        return database.dtConsulta(consulta, parametros, true);
    }

    public DataTable ObtieneIdStatusParticipante(string country_code, string status_participante)
    {
        string consulta = "ObtieneIdStatus_Participante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@country_code", country_code));
        parametros.Add(new SqlParameter("@clave", status_participante));
        database = new csDataBase();
        return database.dtConsulta(consulta, parametros, true);
    }

    public bool ActualizaStatusParticipante(string clave_participante, string status_participante_id, string fecha_status)
    {
        string acepta = "ActualizaStatusParticipante";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@clave_participante", clave_participante));
        parametros.Add(new SqlParameter("@status_participante_id", status_participante_id));
        parametros.Add(new SqlParameter("@fecha_status", fecha_status));
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

    private decimal ConsultaTipoTelefono(string clave)
    {
        using (ParticipanteDataContext pcdt = new ParticipanteDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            string q = "select id from tipo_telefono where clave = '" + clave + "'";
            decimal tipo_telefono_id = pcdt.ExecuteQuery<decimal>(q).Single();
            return tipo_telefono_id;
        }
    }

    public DataTable ConsultaSucursal(int Distribuidor_id)
    {
        string consulta = "sp_catalogo_Branch";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@Distribuidor_id", Distribuidor_id));
        database = new csDataBase();
        return database.dtConsulta(consulta, parametros, true);
    }

    public DataTable ConsultaHijos(string Participante_id)
    {
        string consulta = "sp_tiene_hijos";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@Participante_id", Participante_id));
        database = new csDataBase();
        return database.dtConsulta(consulta, parametros, true);
    }

    public void InserUpdateHijos(int Participante_id, string Nombre, string app, string apm, string FechaNacimeinto)
    {
        using (ParticipanteDataContext pcdt = new ParticipanteDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            //var Matched = (from c in pcdt.GetTable<participante_hijos>()
            //               where c.participante_id == Participante_id && c.nombre == Nombre
            //               select c).SingleOrDefault();

            //if (Matched != null)
            //{
            //    // Hijos Existentes para Actualizar los datos.
            //    try
            //    {
            //        //pcdt.participante_hijos.DeleteOnSubmit(Matched);
            //        //pcdt.SubmitChanges();
            //        Matched.nombre = Nombre;
            //        Matched.apellido_paterno = app;
            //        Matched.apellido_materno = apm;
            //        Matched.fecha_nacimiento = Convert.ToDateTime(FechaNacimeinto);
            //        pcdt.SubmitChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        string Error = ex.ToString();
            //    }
            //}
            //else
            //{
            //    //  Inserta el Registro
            //    //participante_hijos hijos = new participante_hijos();
            //    //hijos.participante_id = Participante_id;
            //    //hijos.nombre = Nombre;
            //    //hijos.apellido_paterno = app;
            //    //hijos.apellido_materno = apm;
            //    //hijos.fecha_nacimiento = Convert.ToDateTime(FechaNacimeinto);

            //    //pcdt.participante_hijos.InsertOnSubmit(hijos);
            //    //pcdt.SubmitChanges();
            //}
        }
    }

    public bool EliminaPasatiempo2(int Participante_id, int Categoria_id)
    {
        string acepta = "sp_elimina_pasatiempos";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@Participante_id", Participante_id));
        parametros.Add(new SqlParameter("@categoria_id", Categoria_id));
        database = new csDataBase();
        if (database.acutualizaDatos(acepta, parametros, true) >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public DataSet EstadoCuenta()
    {
        string transacciones = "sp_consulta_transacciones";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", this.ID));
        database = new csDataBase();
        return database.dsConsulta(transacciones, parametros, true);
    }

    /* Inserta Transacción y Actualiza Saldo del Participante de MX */
    public bool InsertaTransaccion()
    {
        bool insertado = false;
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
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

    public void InsertaBitacoraEnvios(string participante_id, string correo_electronico, string asunto, string mensaje, string fecha)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        parametros.Add(new SqlParameter("@correo_electronico", correo_electronico));
        parametros.Add(new SqlParameter("@asunto", asunto));
        parametros.Add(new SqlParameter("@mensaje", mensaje));
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
        string query = "sp_inserta_bitacora_envios";
        database.Query = query;
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.consultaDato();
    }

    private void ActualizaSaldoParticipante()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
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
        string query = "sp_actualiza_saldo_participante_todo";
        database.Query = query;
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public void ConsultaDitribuidorId()
    {
        using (ParticipanteDataContext contex = new ParticipanteDataContext(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            try
            {
                var Matched = (from p in contex.participante
                               where p.id == Convert.ToDecimal(this.ID)
                               select p).SingleOrDefault();
                this.Distribuidora_ID = Matched.distribuidor_id.ToString();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
    }

    public DataSet LlenaSimuladorDistribucion(int Participante_id, int distribuidor_id, string Fecha)
    {
        string consulta = "sp_simulador";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", Participante_id));
        parametros.Add(new SqlParameter("@Distribuidor_id", distribuidor_id));
        parametros.Add(new SqlParameter("@fecha", Fecha));
        database = new csDataBase();
        return database.dsConsulta(consulta, parametros, true);
    }
}