using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de csDireccion
/// </summary>
public class csDireccion
{
    private csDataBase database;
    private SqlConnection conn;
    private SqlTransaction tran;
    private List<SqlParameter> parametros;

    private string participante_id;
    private string tipo_direccion_id;
    private string calle;
    private string numero_interior;
    private string numero_exterior;
    private string entre_calle_1;
    private string entre_calle_2;
    private string colonia;
    private string ciudad;
    private string asentamiento_id;
    private string asentamiento;
    private string delegacion_municipio_id;
    private string delegacion_municipio;
    private string estado_id;
    private string estado;
    private string codigo_postal;
    private string referencias;
    private string status_id;
    private string fecha_status;
    private string usuario_id;

    public csDireccion()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public csDireccion(SqlConnection conn)
    {
        this.conn = conn;
    }
    public csDireccion(SqlConnection conn, SqlTransaction tran)
    {
        this.conn = conn;
        this.tran = tran;
    }
    public string TipoDireccion
    {
        get
        {
            return tipo_direccion_id;
        }
        set
        {
            tipo_direccion_id = value;
        }
    }
    public string Participante
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
    public string Calle
    {
        get
        {
            return calle;
        }
        set
        {
            calle = value;
        }
    }
    public string NumeroInterior
    {
        get
        {
            return numero_interior;
        }
        set
        {
            numero_interior = value;
        }
    }
    public string NumeroExterior
    {
        get
        {
            return numero_exterior;
        }
        set
        {
            numero_exterior = value;
        }
    }
    public string EntreCalle
    {
        get
        {
            return entre_calle_1;
        }
        set
        {
            entre_calle_1 = value;
        }
    }
    public string YCalle
    {
        get
        {
            return entre_calle_2;
        }
        set
        {
            entre_calle_2 = value;
        }
    }
    public string Colonia
    {
        get
        {
            return colonia;
        }
        set
        {
            colonia = value;
        }
    }
    public string AsentamientoID
    {
        get
        {
            return asentamiento_id;
        }
        set
        {
            asentamiento_id = value;
        }
    }
    public string Asentamiento
    {
        get { return asentamiento; }
        set { asentamiento = value; }
    }
    public string Ciudad
    {
        get
        {
            return ciudad;
        }
    }
    public string CodigoPostal
    {
        get
        {
            return codigo_postal;
        }
        set
        {
            codigo_postal = value;
        }
    }
    public string DelegacionMunicipioID
    {
        get
        {
            return delegacion_municipio_id;
        }
        set
        {
            delegacion_municipio_id = value;
        }
    }
    public string DelegacionMunicipio
    {
        get { return delegacion_municipio; }
        set { delegacion_municipio = value; }
    }
    public string EstadoID
    {
        get
        {
            return estado_id;
        }
        set
        {
            estado_id = value;
        }
    }
    public string Estado
    {
        get { return estado; }
        set { estado = value; }
    }
    public string Referencias
    {
        get
        {
            return referencias;
        }
        set
        {
            referencias = value;
        }
    }
    public string Status
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
    public string Usuario
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
    public void Inserta()
    {

        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@tipo_direccion_id", tipo_direccion_id));
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        if (calle != null)
        {
            parametros.Add(new SqlParameter("@calle", calle));
        }
        else
        {
            parametros.Add(new SqlParameter("@calle", DBNull.Value));
        }
        if (numero_interior != null)
        {
            parametros.Add(new SqlParameter("@numero_interior", numero_interior));
        }
        else
        {
            parametros.Add(new SqlParameter("@numero_interior", DBNull.Value));
        }
        if (numero_exterior != null)
        {
            parametros.Add(new SqlParameter("@numero_exterior", numero_exterior));
        }
        else
        {
            parametros.Add(new SqlParameter("@numero_exterior", DBNull.Value));
        }
        if (entre_calle_1 != null)
        {
            parametros.Add(new SqlParameter("@entrecalle_1", entre_calle_1));
        }
        else
        {
            parametros.Add(new SqlParameter("@entrecalle_1", DBNull.Value));
        }
        if (entre_calle_2 != null)
        {
            parametros.Add(new SqlParameter("@entrecalle_2", entre_calle_2));
        }
        else
        {
            parametros.Add(new SqlParameter("@entrecalle_2", DBNull.Value));
        }
        if (colonia != null)
        {
            parametros.Add(new SqlParameter("@colonia", colonia));
        }
        else
        {
            parametros.Add(new SqlParameter("@colonia", DBNull.Value));
        }
        if (asentamiento_id != null)
        {
            parametros.Add(new SqlParameter("@asentamiento_id", asentamiento_id));
        }
        else
        {
            parametros.Add(new SqlParameter("@asentamiento_id", DBNull.Value));
        }
        if (codigo_postal != null)
        {
            parametros.Add(new SqlParameter("@codigo_postal", codigo_postal));
        }
        else
        {
            parametros.Add(new SqlParameter("@codigo_postal", DBNull.Value));
        }
        if (referencias != null)
        {
            parametros.Add(new SqlParameter("@referencias", referencias));
        }
        else
        {
            parametros.Add(new SqlParameter("@referencias", DBNull.Value));
        }
        parametros.Add(new SqlParameter("@usuario_id", usuario_id));
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database = new csDataBase();
        database.Query = "sp_inserta_direccion";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        string direccion_id = database.consultaDato().ToString();
    }
    public void Actualiza()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@tipo_direccion_id", tipo_direccion_id));
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        if (calle != null)
        {
            parametros.Add(new SqlParameter("@calle", calle));
        }
        else
        {
            parametros.Add(new SqlParameter("@calle", DBNull.Value));
        }
        if (numero_interior != null)
        {
            parametros.Add(new SqlParameter("@numero_interior", numero_interior));
        }
        else
        {
            parametros.Add(new SqlParameter("@numero_interior", DBNull.Value));
        }
        if (numero_exterior != null)
        {
            parametros.Add(new SqlParameter("@numero_exterior", numero_exterior));
        }
        else
        {
            parametros.Add(new SqlParameter("@numero_exterior", DBNull.Value));
        }
        if (entre_calle_1 != null)
        {
            parametros.Add(new SqlParameter("@entrecalle_1", entre_calle_1));
        }
        else
        {
            parametros.Add(new SqlParameter("@entrecalle_1", DBNull.Value));
        }
        if (entre_calle_2 != null)
        {
            parametros.Add(new SqlParameter("@entrecalle_2", entre_calle_2));
        }
        else
        {
            parametros.Add(new SqlParameter("@entrecalle_2", DBNull.Value));
        }
        if (colonia != null)
        {
            parametros.Add(new SqlParameter("@colonia", colonia));
        }
        else
        {
            parametros.Add(new SqlParameter("@colonia", DBNull.Value));
        }
        if (asentamiento_id != null)
        {
            parametros.Add(new SqlParameter("@asentamiento_id", asentamiento_id));
        }
        else
        {
            parametros.Add(new SqlParameter("@asentamiento_id", DBNull.Value));
        }
        if (codigo_postal != null)
        {
            parametros.Add(new SqlParameter("@codigo_postal", codigo_postal));
        }
        else
        {
            parametros.Add(new SqlParameter("@codigo_postal", DBNull.Value));
        }
        if (referencias != null)
        {
            parametros.Add(new SqlParameter("@referencias", referencias));
        }
        else
        {
            parametros.Add(new SqlParameter("@referencias", DBNull.Value));
        }
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
        database = new csDataBase();
        database.Query = "sp_actualiza_direccion";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        int direccion_id = database.acutualizaDatos();
    }
    public void Consulta()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@tipo_direccion_id", tipo_direccion_id));
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
        database = new csDataBase();
        database.Query = "sp_direccion_participante";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        DataTable dtDireccion = database.dtConsulta();
        foreach (DataRow drDireccion in dtDireccion.Rows)
        {
            calle = drDireccion["calle"].ToString();
            numero_interior = drDireccion["numero_interior"].ToString();
            numero_exterior = drDireccion["numero_exterior"].ToString();
            entre_calle_1 = drDireccion["entrecalle_1"].ToString();
            entre_calle_2 = drDireccion["entrecalle_2"].ToString();
            colonia = drDireccion["colonia"].ToString();
            referencias = drDireccion["referencias"].ToString();
            if (!drDireccion["estado_id"].Equals(DBNull.Value))
            {
                ciudad = drDireccion["ciudad"].ToString();
                asentamiento_id = drDireccion["asentamiento_id"].ToString();
                codigo_postal = drDireccion["codigo_postal"].ToString();
                delegacion_municipio_id = drDireccion["delegacion_municipio_id"].ToString();
                estado_id = drDireccion["estado_id"].ToString();
            }
            else if (!drDireccion["estado_id1"].Equals(DBNull.Value))
            {
                ciudad = drDireccion["ciudad1"].ToString();
                if (!drDireccion["asentamiento_id"].Equals(DBNull.Value))
                {
                    asentamiento_id = drDireccion["asentamiento_id"].ToString();
                }
                else
                {
                    asentamiento_id = null;
                }
                codigo_postal = drDireccion["codigo_postal1"].ToString();
                delegacion_municipio_id = drDireccion["delegacion_municipio_id1"].ToString();
                estado_id = drDireccion["estado_id1"].ToString();
            }
            else
            {
                ciudad = null;
                asentamiento_id = null;
                codigo_postal = null;
                delegacion_municipio_id = null;
                estado_id = null;
            }
        }
    }

    public void Consulta(String countrycode)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@tipo_direccion_id", tipo_direccion_id));
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
        database = new csDataBase();
        switch (countrycode)
        {
            case "MX":
                database.Query = "sp_direccion_participante";
                break;
            case "AR":
                database.Query = "sp_direccion_participante";
                break;
            case "BR":
                database.Query = "sp_direccion_participante";
                break;
            case "CO":
                database.Query = "sp_direccion_participante";
                break;
        }
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        DataTable dtDireccion = database.dtConsulta();
        foreach (DataRow drDireccion in dtDireccion.Rows)
        {
            calle = drDireccion["calle"].ToString();
            numero_interior = drDireccion["numero_interior"].ToString();
            numero_exterior = drDireccion["numero_exterior"].ToString();
            entre_calle_1 = drDireccion["entrecalle_1"].ToString();
            entre_calle_2 = drDireccion["entrecalle_2"].ToString();
            colonia = drDireccion["colonia"].ToString();
            referencias = drDireccion["referencias"].ToString();
            switch (countrycode)
            {
                case ("BR"):
                    if (!drDireccion["estado_id"].Equals(DBNull.Value))
                    {
                        ciudad = drDireccion["ciudad"].ToString();
                        asentamiento_id = drDireccion["asentamiento_id"].ToString();
                        codigo_postal = drDireccion["codigo_postal"].ToString();
                        delegacion_municipio_id = drDireccion["delegacion_municipio_id"].ToString();
                        estado_id = drDireccion["estado_id"].ToString();
                    }
                    else if (!drDireccion["estado_id1"].Equals(DBNull.Value))
                    {
                        ciudad = drDireccion["ciudad1"].ToString();
                        if (!drDireccion["asentamiento_id"].Equals(DBNull.Value))
                        {
                            asentamiento_id = drDireccion["asentamiento_id"].ToString();
                        }
                        else
                        {
                            asentamiento_id = null;
                        }
                        codigo_postal = drDireccion["codigo_postal1"].ToString();
                        delegacion_municipio_id = drDireccion["delegacion_municipio_id1"].ToString();
                        estado_id = drDireccion["estado_id1"].ToString();
                    }
                    else
                    {
                        ciudad = null;
                        asentamiento_id = drDireccion["asentamiento_id"].ToString();
                        codigo_postal = drDireccion["codigo_postal"].ToString();
                        delegacion_municipio_id = null;
                        estado_id = null;
                    }

                    break;
                default:
                    if (!drDireccion["estado_id"].Equals(DBNull.Value))
                    {
                        ciudad = drDireccion["ciudad"].ToString();
                        asentamiento_id = drDireccion["asentamiento_id"].ToString();
                        codigo_postal = drDireccion["codigo_postal"].ToString();
                        delegacion_municipio_id = drDireccion["delegacion_municipio_id"].ToString();
                        estado_id = drDireccion["estado_id"].ToString();
                    }
                    else if (!drDireccion["estado_id1"].Equals(DBNull.Value))
                    {
                        ciudad = drDireccion["ciudad1"].ToString();
                        if (!drDireccion["asentamiento_id"].Equals(DBNull.Value))
                        {
                            asentamiento_id = drDireccion["asentamiento_id"].ToString();
                        }
                        else
                        {
                            asentamiento_id = null;
                        }
                        codigo_postal = drDireccion["codigo_postal1"].ToString();
                        delegacion_municipio_id = drDireccion["delegacion_municipio_id1"].ToString();
                        estado_id = drDireccion["estado_id1"].ToString();
                    }
                    else
                    {
                        ciudad = null;
                        asentamiento_id = null;
                        codigo_postal = null;
                        delegacion_municipio_id = null;
                        estado_id = null;
                    }
                    break;
            }
        }
    }

    public DataTable ConsultaDireccion()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@tipo_direccion_id", tipo_direccion_id));
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
        database = new csDataBase();
        database.Query = "sp_direccion_participante";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }

    public DataTable CargaEstados()
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
        database.Query = "sp_estados";
        //database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }

    public DataTable CargaEstados(String countrycode)
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
        switch (countrycode)
        {
            case "AR":
                database.Query = "sp_estado";
                break;
            case "MX":
                database.Query = "sp_estado";
                break;
            case "BR":
                database.Query = "sp_estado";
                break;
            case "CO":
                database.Query = "sp_estado";
                break;
        }
        //database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }
    public DataTable CargaEstadosXID()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@estado_id", estado_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_estado_por_id";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }

    public DataTable CargaDelegacionMunicipio()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@estado_id", estado_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_delegacion_municipio";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }

    public DataTable CargaDelegacionMunicipio(String countrycode)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@estado_id", estado_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        switch (countrycode)
        {
            case "MX":
                database.Query = "sp_delegacion_municipio";
                break;
            case "AR":
                database.Query = "sp_delegacion_municipio";
                break;
            case "BR":
                database.Query = "sp_delegacion_municipio";
                break;
            case "CO":
                database.Query = "sp_delegacion_municipio";
                break;
        }
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }

    public DataTable CargaDelegacionMunicipioXCP()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@codigo_postal", codigo_postal));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_delegacion_municipio_por_cp";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }

    public DataTable CargaAsentamientos()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@delegacion_municipio_id", delegacion_municipio_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_asentamiento";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }

    public DataTable CargaAsentamientos(String countrycode)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@delegacion_municipio_id", delegacion_municipio_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        switch (countrycode)
        {
            case "MX":
                database.Query = "sp_asentamiento";
                break;
            case "AR":
                database.Query = "sp_asentamiento";
                break;
            case "BR":
                database.Query = "sp_asentamiento";
                break;
        }
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }

    public DataTable CargaAsentamientosXID()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@id", asentamiento_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_asentamiento_por_id";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }


    public void CargaCodigoPostalCiudad()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@asentamiento_id", asentamiento_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_codigo_postal_ciudad";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        DataTable dtCodigoPostal = database.dtConsulta();
        if (dtCodigoPostal.Rows.Count > 0)
        {
            DataRow drCP = dtCodigoPostal.Rows[0];
            codigo_postal = drCP["codigo_postal"].ToString();
            ciudad = drCP["ciudad"].ToString();
        }
    }

    public void CargaCodigoPostalCiudad(String countrycode)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@asentamiento_id", asentamiento_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        switch (countrycode)
        {
            case "MX":
                database.Query = "sp_codigo_postal_ciudad";
                break;
            case "AR":
                database.Query = "sp_codigo_postal_ciudad";
                break;
            case "BR":
                database.Query = "sp_codigo_postal_ciudad";
                break;
        }
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        DataTable dtCodigoPostal = database.dtConsulta();
        if (dtCodigoPostal.Rows.Count > 0)
        {
            DataRow drCP = dtCodigoPostal.Rows[0];
            codigo_postal = drCP["codigo_postal"].ToString();
            ciudad = drCP["ciudad"].ToString();
        }
    }

    public void BuscaDireccionXCP()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@codigo_postal", codigo_postal));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_busca_por_cp";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        DataTable dtDirCP = database.dtConsulta();
        if (dtDirCP.Rows.Count > 0)
        {
            DataRow drDirCP = dtDirCP.Rows[0];
            estado_id = drDirCP["estado_id"].ToString();
            delegacion_municipio_id = drDirCP["delegacion_municipio_id"].ToString();
            ciudad = drDirCP["ciudad"].ToString();
        }
    }

    public void BuscaDireccionXCP(String countrycode)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@codigo_postal", codigo_postal));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        switch (countrycode)
        {
            case "MX":
                database.Query = "sp_busca_por_cp";
                break;
            case "AR":
                database.Query = "sp_busca_por_cp";
                break;
            case "BR":
                database.Query = "sp_busca_por_cp";
                break;
        }
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        DataTable dtDirCP = database.dtConsulta();
        if (dtDirCP.Rows.Count > 0)
        {
            DataRow drDirCP = dtDirCP.Rows[0];
            estado_id = drDirCP["estado_id"].ToString();
            estado = drDirCP["estado"].ToString();
            delegacion_municipio_id = drDirCP["delegacion_municipio_id"].ToString();
            delegacion_municipio = drDirCP["delegacion_municipio"].ToString();
            ciudad = drDirCP["ciudad"].ToString();
            asentamiento_id = drDirCP["asentamiento_id"].ToString();
            asentamiento = drDirCP["asentamiento"].ToString();
            try
            {
                calle = drDirCP["calle"].ToString();
            }
            catch
            {
                calle = "";
            }
        }
    }

    public DataTable CargaAsentamientosCP()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@codigo_postal", codigo_postal));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_asentamiento_por_cp";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }

    public DataTable CargaAsentamientosCP(String countrycode)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@codigo_postal", codigo_postal));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        switch (countrycode)
        {
            case "MX":
                database.Query = "sp_asentamiento_por_cp";
                break;
            case "AR":
                database.Query = "sp_asentamiento_por_cp";
                break;
            case "BR":
                database.Query = "sp_asentamiento_por_cp";
                break;
        }
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return database.dtConsulta();
    }

    public bool ExisteDireccion()
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        parametros.Add(new SqlParameter("@tipo_direccion_id", tipo_direccion_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_existe_direccion";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        int existe = Convert.ToInt32(database.consultaDato());
        if (existe > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ExisteDireccion(String countrycode)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        parametros.Add(new SqlParameter("@tipo_direccion_id", tipo_direccion_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        switch (countrycode)
        {
            case "MX":
                database.Query = "sp_existe_direccion";
                break;
            case "AR":
                database.Query = "sp_existe_direccion";
                break;
            case "BR":
                database.Query = "sp_existe_direccion";
                break;
        }
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        int existe = Convert.ToInt32(database.consultaDato());
        if (existe > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string ConsultaClaveEstado(String countrycode, int idEstado)
    {
        string clave = "";
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@idEstado", idEstado));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        switch (countrycode)
        {
            case "BR":
                database.Query = "sp_busca_estado_clave_br";
                break;
        }
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        clave = database.consultaDato().ToString();
        return clave;
    }
}
