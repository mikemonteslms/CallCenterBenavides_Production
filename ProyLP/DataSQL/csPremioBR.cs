using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;


   public  class csPremioBR
    {

        private csDataBase database;
    private List<SqlParameter> parametros;

    private string _premio_id;
    private string _clave;
    private string _descripcion;
    private string _url;
    private string _puntos;
    private string _categoria;
    private string _descripcionlarga;

    private string _titulo;
    private string _descripciondetalle;
    private string _incluye;
    private string _adicional;
    private string _personas;
    private string _ubicacion;
    private string _cantidad;

    private string _pais;

    private string _categoria_id;
    private DataTable _dtPremios;

    public csPremioBR()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public csPremioBR(string premio_id)
    {
        _premio_id = premio_id;
    }
    public csPremioBR(string premio_id, string descrpcion, string url, string puntos, string cantidad)
    {
        this._premio_id = premio_id;
        this._descripcion = descrpcion;
        this._url = url;
        this._puntos = puntos;
        this._cantidad = cantidad;
    }

    public string PremioID
    {
        get
        {
            return _premio_id;
        }
        set
        {
            _premio_id = value;
        }
    }
    public string Clave
    {
        get
        {
            return _clave;
        }
    }
    public string Descripcion
    {
        get
        {
            return _descripcion;
        }
    }
    public string URL
    {
        get
        {
            return _url;
        }
    }
    public string Puntos
    {
        get
        {
            return _puntos;
        }
    }
    public string Categoria
    {
        get
        {
            return _categoria;
        }
    }
    public string DescripcionLarga
    {
        get
        {
            return _descripcionlarga;
        }
    }

    public string DescripcionDetalle
    {
        get
        {
            return _descripciondetalle;
        }
    }
    public string Titulo
    {
        get
        {
            return _titulo;
        }
    }
    public string Incluye
    {
        get
        {
            return _incluye;
        }
    }
    public string Adicional
    {
        get
        {
            return _adicional;
        }
    }
    public string Personas
    {
        get
        {
            return _personas;
        }
    }
    public string Ubicacion
    {
        get
        {
            return _ubicacion;
        }
    }
    public string Cantidad
    {
        get { return _cantidad; }
        set { _cantidad = value; }
    }
    public string CategoriaID
    {
        get { return _categoria_id; }
        set { _categoria_id = value; }
    }
    public string Pais
    {
        get { return _pais; }
        set { _pais = value; }
    }
    public bool Consulta()
    {
        database = new csDataBase();
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@premio_id", _premio_id));
        DataTable dtDetalle = database.dtConsulta("sp_consulta_premio", parametros, true);
        if (dtDetalle.Rows.Count > 0)
        {
            _clave = dtDetalle.Rows[0]["clave"].ToString();
            _descripcion = dtDetalle.Rows[0]["descripcion"].ToString();
            _descripcionlarga = dtDetalle.Rows[0]["Descripcion_Larga"].ToString();
            _categoria = dtDetalle.Rows[0]["categoria"].ToString();
            _url = dtDetalle.Rows[0]["url_imagen"].ToString();
            _puntos = dtDetalle.Rows[0]["puntos"].ToString();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool ObtenDetalle()
    {
        database = new csDataBase();
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@premio_id", _premio_id));
        DataTable dtDetalle = database.dtConsulta("sp_consulta_premio_detalle", parametros, true);
        if (dtDetalle.Rows.Count > 0)
        {
            _titulo = dtDetalle.Rows[0]["titulo"].ToString();
            _clave = dtDetalle.Rows[0]["clave"].ToString();
            _descripciondetalle = dtDetalle.Rows[0]["descripcion"].ToString();
            _incluye = dtDetalle.Rows[0]["incluye"].ToString();
            _adicional = dtDetalle.Rows[0]["adicional"].ToString();
            _personas = dtDetalle.Rows[0]["personas"].ToString();
            _ubicacion = dtDetalle.Rows[0]["ubicacion"].ToString();
            return true;
        }
        else
        {
            return false;
        }
    }
    public DataTable Categorias()
    {
        database = new csDataBase();
        DataTable dtDetalle = database.dtConsulta("sp_consulta_premio_categoria", true);
        return dtDetalle;
    }
    public DataTable Categorias(string pais)
    {
        database = new csDataBase();
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@pais", pais));
        DataTable dtDetalle = database.dtConsulta("sp_consulta_premio_categoria_pais", parametros, true);
        return dtDetalle;
    }
    public DataTable PremiosCategoria()
    {
        database = new csDataBase();
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@categoria_premio_id", _categoria_id));
        DataSet dsDetalle = database.dsConsulta("sp_consulta_premios_x_categoria", parametros, true);
        if (dsDetalle.Tables[1].Rows.Count > 0)
        {
            _categoria = dsDetalle.Tables[1].Rows[0]["descripcion_larga"].ToString();
        }
        return dsDetalle.Tables[0];
    }
    public DataTable PremiosCategoriaCO()
    {
        database = new csDataBase();
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@categoria_premio_id", _categoria_id));
        DataSet dsDetalle = database.dsConsulta("sp_consulta_premios_x_categoria_co", parametros, true);
        if (dsDetalle.Tables[1].Rows.Count > 0)
        {
            _categoria = dsDetalle.Tables[1].Rows[0]["descripcion_larga"].ToString();
        }
        return dsDetalle.Tables[0];
    }
    public DataTable Busqueda(string busqueda,string proveedor)
    {
        database = new csDataBase();
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@cve_proveedor", proveedor));
        parametros.Add(new SqlParameter("@busqueda", busqueda));
        DataTable dtDetalle = database.dtConsulta("sp_buscar_premio_br", parametros, true);
        return dtDetalle;
    }


    #region Oox
    public DataTable CategoriasXDistribuidor(string Distribuidor)
    {
        database = new csDataBase();
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@distribuidor", Distribuidor));
        DataTable dtDetalle = database.dtConsulta("sp_consulta_premio_categoria_distribuidor", parametros, true);
        return dtDetalle;
    }

    public DataTable PremiosDistribuidorCategoria(string clave_proveedor)
    {
        DataTable dt = new DataTable();
        database = new csDataBase();
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@categoria_premio_id", _categoria_id));
        parametros.Add(new SqlParameter("@Proveedor_id", clave_proveedor));
        DataSet dsDetalle = database.dsConsulta("sp_consulta_produtos_x_categoria", parametros, true);
        if (dsDetalle != null && dsDetalle.Tables != null && dsDetalle.Tables.Count > 0 && dsDetalle.Tables[0].Rows.Count > 0)
        {
            _categoria = dsDetalle.Tables[0].Rows[0]["descripcion_larga"].ToString();

            if (dsDetalle.Tables.Count > 1)
            {
                dt = dsDetalle.Tables[1];
            }
        }

        return dt;
    }
    public bool ConsultaProducto(string Distribuidor)
    {
        database = new csDataBase();
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@codigo", _premio_id));
        parametros.Add(new SqlParameter("@Distribuidor", Distribuidor));
        DataTable dtDetalle = database.dtConsulta("sp_consulta_produto_distributor", parametros, true);
        if (dtDetalle.Rows.Count > 0)
        {
            _clave = dtDetalle.Rows[0]["clave"].ToString();
            _descripcion = dtDetalle.Rows[0]["descripcion"].ToString();
            _descripcionlarga = dtDetalle.Rows[0]["Descripcion_Larga"].ToString();
            _categoria = dtDetalle.Rows[0]["categoria"].ToString();
            _url = dtDetalle.Rows[0]["imagen_mediana"].ToString();
            _puntos = dtDetalle.Rows[0]["puntos"].ToString();
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

    }

