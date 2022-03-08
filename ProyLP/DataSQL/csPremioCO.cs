using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
//using System.Collections.Generic;

/// <summary>
/// Descripción breve de csPremio
/// </summary>
/// 
public class csPremioCO
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

    private string _observaciones;
    private string _folio;

    private string _pais;

    private string _categoria_id;
    private DataTable _dtPremios;

    public csPremioCO()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public csPremioCO(string premio_id)
    {
        _premio_id = premio_id;
    }
    public csPremioCO(string premio_id, string descrpcion, string url, string puntos, string cantidad)
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
    public string Observaciones
    {
        get { return _observaciones; }
        set { _observaciones = value; }
    }
    public string Folio
    { 
        get { return _folio; } 
        set { _folio = value; } 
    }

    public override bool Equals(System.Object obj)
    {
        // If parameter is null return false.
        if (obj == null)
        {
            return false;
        }

        // If parameter cannot be cast to Point return false.
        csPremioCO p = obj as csPremioCO;
        if ((System.Object)p == null)
        {
            return false;
        }

        // Return true if the fields match:
        if (p.Observaciones == null)
        {
            return (_premio_id == p.PremioID);
        }
        else
        {
            return (_premio_id == p.PremioID) && (_observaciones == p.Observaciones);
        }
    }

    public bool Equals(csPremioCO p)
    {
        // If parameter is null return false:
        if ((object)p == null)
        {
            return false;
        }

        // Return true if the fields match:
        if (p.Observaciones == null)
        {
            return (_premio_id == p.PremioID);
        }
        else
        {
            return (_premio_id == p.PremioID) && (_observaciones == p.Observaciones);
        }
    }

    public override int GetHashCode()
    {
        return 1;
    }
    public static bool operator ==(csPremioCO a, csPremioCO b)
    {
        // If both are null, or both are same instance, return true.
        if (System.Object.ReferenceEquals(a, b))
        {
            return true;
        }

        // If one is null, but not both, return false.
        if (((object)a == null) || ((object)b == null))
        {
            return false;
        }

        // Return true if the fields match:
        if (a.Observaciones == null || b.Observaciones == null)
        {
            return a.PremioID == b.PremioID;
        }
        else
        {
            return a.PremioID == b.PremioID && a.Observaciones == b.Observaciones;
        }
    }

    public static bool operator !=(csPremioCO a, csPremioCO b)
    {
        return !(a == b);
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
            _observaciones = "";
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
        DataTable dtDetalle = database.dtConsulta("sp_consulta_premio_detalle_co", parametros, true);
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
    public DataTable Busqueda(string busqueda)
    {
        database = new csDataBase();
        parametros = new List<SqlParameter>();        
        parametros.Add(new SqlParameter("@busqueda", busqueda));
        DataTable dtDetalle = database.dtConsulta("sp_buscar_premio", parametros, true);
        return dtDetalle;
    }
}
