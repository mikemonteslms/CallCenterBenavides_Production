using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

/// <summary>
/// Summary description for csCarritoCompras
/// VSC
/// </summary>
/// 
public class csCarritoComprasMX
{
    private List<csPremioMX> _carrito;
    private csDataBase database;
    private List<SqlParameter> parametros;
    private SqlConnection conn;
    private SqlTransaction tran;

    private string participante_id;
    private string usuario_id;

    private string puntos_transaccion;
    private int transaccion_id;

    public int Transaccion_id
    {
        get { return transaccion_id; }        
    }
    private string tipo_transaccion_id;
    private string tipo_transaccion;
    private string categoria_transaccion_id;

    private List<csPremioMX> _canje_rms;

    public csCarritoComprasMX()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public csCarritoComprasMX(SqlConnection conn)
    {
        this.conn = conn;
    }
    public csCarritoComprasMX(SqlConnection conn, SqlTransaction tran)
    {
        this.conn = conn;
        this.tran = tran;
    }
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
    public string CategoriaTransaccionID
    {
        set { categoria_transaccion_id = value; }
    }
    public List<csPremioMX> Carrito
    {
        get { return _carrito; }
        set { _carrito = value; }
    }
    public List<csPremioMX> CanjesRMS
    {
        get { return _canje_rms; }
        set { _canje_rms = value; }
    }
    public void Agregar(csPremioMX premio)
    {
        if (_carrito == null)
        {
            _carrito = new List<csPremioMX>();
        }
        _carrito.Add(premio);
    }

    public List<csPremioMX> Buscar(csPremioMX premio)
    {
        List<csPremioMX> lista = new List<csPremioMX>();
        foreach (csPremioMX pr in _carrito)
        {
            if (premio == pr)
            {
                lista.Add(pr);
            }
        }
        return lista;
    }
    public List<csPremioMX> Buscar(string busqueda)
    {
        List<csPremioMX> lista = new List<csPremioMX>();
        foreach (csPremioMX pr in _carrito)
        {
            if (pr.Descripcion.ToLower().Contains(busqueda))
            {
                lista.Add(pr);
            }
        }
        return lista;
    }
    public void Actualizar(csPremioMX premio)
    {
        int i = -1;
        i = _carrito.FindIndex(delegate(csPremioMX pr)
        {
            if (pr == premio)
            {
                return true;
            }
            return false;
        }
        );

        _carrito.RemoveAt(i);
        _carrito.Insert(i, premio);
    }
    public void Eliminar(csPremioMX premio)
    {
        int i = -1;
        i = _carrito.FindIndex(delegate(csPremioMX pr)
        {
            if (pr == premio)
            {
                return true;
            }
            return false;
        }
        );
        _carrito.RemoveAt(i);
    }
    public int Items
    {
        get
        {
            if (_carrito == null)
            {
                return 0;
            }
            else
            {
                return _carrito.Count;
            }
        }
    }
    public int Premios
    {
        get
        {
            if (_carrito == null)
            {
                return 0;
            }
            else
            {
                int q = 0;
                foreach (csPremioMX pr in _carrito)
                {
                    q += int.Parse(pr.Cantidad);
                }
                return q;
            }
        }
    }
    public int Puntos
    {
        get
        {
            if (_carrito == null)
            {
                return 0;
            }
            else
            {
                int ptos = 0;
                foreach (csPremioMX pr in _carrito)
                {
                    ptos += int.Parse(pr.Puntos) * int.Parse(pr.Cantidad);
                }
                return ptos;
            }
        }
    }
    public int PuntosExcepto(csPremioMX premio)
    {
        if (_carrito == null)
        {
            return 0;
        }
        else
        {
            int ptos = 0;
            foreach (csPremioMX pr in _carrito)
            {
                if (premio != pr)
                {
                    ptos += int.Parse(pr.Puntos) * int.Parse(pr.Cantidad);
                }
            }
            return ptos;
        }
    }
    protected bool InsertaTransaccion()
    {
        bool insertado = false;

        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", participante_id));
        parametros.Add(new SqlParameter("@tipo_transaccion", tipo_transaccion));
        parametros.Add(new SqlParameter("@puntos", this.Puntos));
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
        transaccion_id = Convert.ToInt32(database.consultaDato());
        if (transaccion_id > 0)
        {
            if (_carrito != null)
            {
                _canje_rms = new List<csPremioMX>();
                foreach (csPremioMX premio in _carrito)
                {
                    for (int i = 0; i < int.Parse(premio.Cantidad); i++)
                    {
                        string folio = InsertaTransaccion_Premio(transaccion_id.ToString(), premio);
                        csPremioMX _premio_canje = new csPremioMX(premio.PremioID, premio.Descripcion, premio.URL, premio.Puntos, "1");
                        _premio_canje.Folio = folio;
                        _premio_canje.Observaciones = premio.Observaciones;
                        _canje_rms.Add(_premio_canje);
                    }
                }
                insertado = true;
            }
        }
        ActualizaSaldoParticipante();
        return insertado;
    }

    private string InsertaTransaccion_Premio(string transaccion_id, csPremioMX premio)
    {
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_id", transaccion_id));
        parametros.Add(new SqlParameter("@premio_id", premio.PremioID));
        parametros.Add(new SqlParameter("@puntos", premio.Puntos));
        if (premio.Observaciones != null && premio.Observaciones.Length > 0)
        {
            parametros.Add(new SqlParameter("@observaciones", premio.Observaciones));
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
        string query = "sp_inserta_transaccion_premio";
        database.Query = query;
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        return database.consultaDato().ToString();
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

    public CallCenterDB.Entidades.RMS Canjear(string programa, int programa_id)
    {
        int canje = 0;
        bool inserta_transaccion = InsertaTransaccion();
        if (inserta_transaccion)
        {
            canje = 1;
        }
        else
        {
            throw new Exception("ERROR_TRANSACCION");
        }
        #region RMS

        csRMS rms;
        if (this.conn != null && this.tran != null)
        {
            rms = new csRMS(programa_id, conn, tran);
        }
        else if (this.conn != null && this.tran == null)
        {
            rms = new csRMS(programa_id, conn);
        }
        else
        {
            rms = new csRMS(programa_id);
        }
        rms.TransaccionID = transaccion_id.ToString();
        rms.TipoDireccionID = "4";
        CallCenterDB.Entidades.RMS _rms = new CallCenterDB.Entidades.RMS();
        try
        {
            if (rms.GeneraPedidoRMS())
            {
                _rms.PedidoLMS = rms.PedidoLMS;
                _rms.PedidoRMS = rms.PedidoRMS;
                _rms.FoliosTotales = rms.FoliosTotales;
                _rms.FoliosCorrectos = rms.FoliosCorrectos;
                _rms.FoliosErroneos = rms.FoliosErroneos;
                _rms.Duplicados = rms.Duplicados;
                _rms.FueraRango = rms.FueraRango;
                _rms.SinFolio = rms.SinFolio;
                _rms.Proveedores = rms.Proveedores;
                _rms.Sucursal = rms.Sucursal;

            }
            else
            {
                /* Inserta el error */
                csRMS errorInsert = new csRMS(programa_id);
                errorInsert.TransaccionID = transaccion_id.ToString();
                errorInsert.Programa = programa;
                errorInsert.VerificaTransaccionRMS(); // Valida que se haya hecho el insert en RMS
            }
        }
        catch (Exception ex)
        {
            /* Inserta el error */
            csRMS errorInsert = new csRMS(programa_id);
            errorInsert.TransaccionID = transaccion_id.ToString();
            errorInsert.Programa = programa;
            errorInsert.VerificaTransaccionRMS(); // Valida que se haya hecho el insert en RMS
        }
        #endregion
        return _rms;
    }
}
