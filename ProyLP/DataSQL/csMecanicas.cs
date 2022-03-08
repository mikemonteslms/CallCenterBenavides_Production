using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class csMecanicas
{
    protected csDataBase database;
    protected List<SqlParameter> parametros;
    protected SqlConnection conn;
    protected SqlTransaction tran;

    private int mecanica_id;
    private string clave;
    private string descripcion;
    private string descripcion_larga;
    private string tipo_mecanica_id;
    private string programa_id;
    private string tipo_participante_id;
    private DateTime? fecha_inicial;
    private DateTime? fecha_final;
    private double factor_acumulacion;
    private Guid usuario_id;

    private int? marca_id;
    private int? producto_id;
    private long? beneficio_id;
    private int? dias_para_cupon;

    public int Mecanica_id
    {
        get { return mecanica_id; }
        set { mecanica_id = value; }
    }
    public string Clave
    {
        get { return clave; }
        set { clave = value; }
    }
    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }
    public string Descripcion_larga
    {
        get { return descripcion_larga; }
        set { descripcion_larga = value; }
    }
    public string Tipo_mecanica_id
    {
        get { return tipo_mecanica_id; }
        set { tipo_mecanica_id = value; }
    }
    public string Programa_id
    {
        get { return programa_id; }
        set { programa_id = value; }
    }
    public string Tipo_participante_id
    {
        get { return tipo_participante_id; }
        set { tipo_participante_id = value; }
    }
    public DateTime? Fecha_inicial
    {
        get { return fecha_inicial; }
        set { fecha_inicial = value; }
    }
    public DateTime? Fecha_final
    {
        get { return fecha_final; }
        set { fecha_final = value; }
    }
    public double Factor_acumulacion
    {
        get { return factor_acumulacion; }
        set { factor_acumulacion = value; }
    }
    public Guid Usuario_id
    {
        get { return usuario_id; }
        set { usuario_id = value; }
    }
    public int? Marca_id
    {
        get { return marca_id; }
        set { marca_id = value; }
    }
    public int? Producto_id
    {
        get { return producto_id; }
        set { producto_id = value; }
    }
    public long? Beneficio_id
    {
        get { return beneficio_id; }
        set { beneficio_id = value; }
    }
    public int? Dias_para_cupon
    {
        get { return dias_para_cupon; }
        set { dias_para_cupon = value; }
    }

    public csMecanicas()
    {

    }
    public csMecanicas(SqlConnection conn)
    {
        this.conn = conn;
    }
    public csMecanicas(SqlConnection conn, SqlTransaction tran)
    {
        this.conn = conn;
        this.tran = tran;
    }

    public void InsertaMecanica()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@clave", clave));
        parametros.Add(new SqlParameter("@descripcion", descripcion));
        parametros.Add(new SqlParameter("@descripcion_larga", descripcion_larga));
        parametros.Add(new SqlParameter("@tipo_mecanica_id", tipo_mecanica_id));
        parametros.Add(new SqlParameter("@programa_id", programa_id));
        parametros.Add(new SqlParameter("@tipo_participante_id", tipo_participante_id));
        parametros.Add(new SqlParameter("@fecha_inicial", fecha_inicial));
        parametros.Add(new SqlParameter("@fecha_final", fecha_final));
        parametros.Add(new SqlParameter("@factor_acumulacion", factor_acumulacion));
        parametros.Add(new SqlParameter("@beneficio_id", beneficio_id));
        parametros.Add(new SqlParameter("@dias_para_cupon", dias_para_cupon));
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
        database.Query = "sp_inserta_mecanica";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        this.mecanica_id = Int32.Parse(database.consultaDato().ToString());
    }

    public void ActualizaMecanica(string mecanica_id)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@mecanica_id", mecanica_id));
        parametros.Add(new SqlParameter("@clave", clave));
        parametros.Add(new SqlParameter("@descripcion", descripcion));
        parametros.Add(new SqlParameter("@descripcion_larga", descripcion_larga));
        parametros.Add(new SqlParameter("@tipo_mecanica_id", tipo_mecanica_id));
        parametros.Add(new SqlParameter("@programa_id", programa_id));
        parametros.Add(new SqlParameter("@tipo_participante_id", tipo_participante_id));
        parametros.Add(new SqlParameter("@fecha_inicial", fecha_inicial));
        parametros.Add(new SqlParameter("@fecha_final", fecha_final));
        parametros.Add(new SqlParameter("@factor_acumulacion", factor_acumulacion));
        parametros.Add(new SqlParameter("@beneficio_id", beneficio_id));
        parametros.Add(new SqlParameter("@dias_para_cupon", dias_para_cupon));
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
        database.Query = "sp_actualiza_mecanica";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }
    public void InsertaMecanicaDetalle()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@mecanica_id", mecanica_id));
        parametros.Add(new SqlParameter("@marca_id", marca_id.HasValue ? (object)marca_id.Value : DBNull.Value));
        parametros.Add(new SqlParameter("@producto_id", producto_id.HasValue ? (object)producto_id.Value : DBNull.Value));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_inserta_mecanica_detalle";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        database.acutualizaDatos();
    }

    public DataTable ConsultaMecanicas()
    {
        string sp = "sp_consulta_mecanicas";
        database = new csDataBase();
        return database.dtConsulta(sp, true);
    }


    public DataTable ConsultaMecanicas_Detalle()
    {
        parametros = new List<SqlParameter>();
        string sp = "sp_consulta_mecanicas_detalle";
        parametros.Add(new SqlParameter("@mecanica_id", mecanica_id));
        database = new csDataBase();
        return database.dtConsulta(sp, parametros, true);
    }

}
