using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
//using System.Collections.Generic;

/// <summary>
/// Descripción breve de csPremio
/// </summary>
/// 
public class csPremio
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

    private string _programa;

    private string _categoria_id;
    private DataTable _dtPremios;

    public csPremio()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public csPremio(string premio_id)
    {
        _premio_id = premio_id;
    }
    public csPremio(string premio_id, string descrpcion, string url, string puntos, string cantidad)
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
    public string Programa
    {
        get { return _programa; }
        set { _programa = value; }
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
        csPremio p = obj as csPremio;
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

    public bool Equals(csPremio p)
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
    public static bool operator ==(csPremio a, csPremio b)
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

    public static bool operator !=(csPremio a, csPremio b)
    {
        return !(a == b);
    }
    public bool Consulta()
    {
        database = new csDataBase();
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@premio_id", _premio_id));
        if (_premio_id != null && _premio_id != "")
        {
            DataTable dtDetalle = database.dtConsulta("sp_consulta_premio", parametros, true);
            if (dtDetalle.Rows.Count > 0)
            {
                _clave = dtDetalle.Rows[0]["clave"].ToString();
                _descripcion = dtDetalle.Rows[0]["descripcion"].ToString();
                _descripcionlarga = dtDetalle.Rows[0]["Descripcion_Larga"].ToString();
                _categoria = dtDetalle.Rows[0]["categoria"].ToString();
                _url = dtDetalle.Rows[0]["url_imagen_large"].ToString();
                _puntos = dtDetalle.Rows[0]["puntos"].ToString();
                _observaciones = "";
                return true;
            }
            else
            {
                return false;
            }
        }
        else
            return false;
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
    public DataTable Categorias(string programa)
    {
        database = new csDataBase();
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@programa", programa));
        DataTable dtDetalle = database.dtConsulta("sp_consulta_premio_categoria_programa", parametros, true);
        return dtDetalle;
    }
    public DataTable PremiosCategoria()
    {
        database = new csDataBase();
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@programa", _programa));
        parametros.Add(new SqlParameter("@categoria_premio_id", _categoria_id));
        DataSet dsDetalle = database.dsConsulta("sp_consulta_premios_x_categoria", parametros, true);
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
        parametros.Add(new SqlParameter("@programa", this.Programa));
        parametros.Add(new SqlParameter("@busqueda", busqueda));
        DataTable dtDetalle = database.dtConsulta("sp_buscar_premio", parametros, true);
        return dtDetalle;
    }



    public DataTable ConsultaCatalogoPremios()
    {
        string sp = "sp_consulta_catalogo_premios";
        database = new csDataBase();
        return database.dtConsulta(sp, true);
    }


    public DataTable ConsultaPremio_Detalle(int premio_id)
    {
        parametros = new List<SqlParameter>();
        string sp = "sp_consulta_catalogo_premios_detalle";
        parametros.Add(new SqlParameter("@premio_id", premio_id));
        database = new csDataBase();
        return database.dtConsulta(sp, parametros, true);
    }
    public string ConsultaURL()
    {
        string url = "";
        using (EntitiesModel.EntitiesModel model = new EntitiesModel.EntitiesModel(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            var prog = (from pr in model.programas
                        where pr.clave == this.Programa
                        select new
                        {
                            _url = pr.url_programa
                        }).SingleOrDefault();
            url = prog._url;
        }
        return url;
    }
}