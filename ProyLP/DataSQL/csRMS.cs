using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using CallCenterDB.mx.com.rewards;
//using CallCenterDB.mx.com.rewards;
/// <summary>
/// Descripción breve de csRMS
/// </summary>
/// 
public class csRMS
{
    wsRewards_Service_2 wsRMS;
    csDataBase database;
    private SqlConnection conn;
    private SqlTransaction tran;
    private string _usuario;
    private string _password;
    private string _prefijo_rms;
    private string _email;
    private string _remitente;

    private string _tipo_direccion_id;
    private string _transaccion_id;
    private string _pedido_rms;
    private DataTable _dtPedido;
    private object _dato;
    private string _pedidolms;
    private string _pedidorms;
    private string _foliostotales;
    private string _folioscorrectos;
    private string _folioserroneos;
    private string _duplicados;
    private string _fuerarango;
    private string _sinfolio;
    private string _proveedores;
    private string _sucursal;
    private string _transaccion_premio_id;
    private string _folio;
    private string _comentario;
    private string _prioridad;
    private string _status;
    private string _participante_id;
    private string _usuario_id;
    private string _programa;
    private string _programa_clave;

    public string Programa
    {
        get { return _programa; }
        set { _programa = value; }
    }

    public struct detalleactualizacion
    {
        public string folio;
        public int status;
        public string error;
    }

    private List<detalleactualizacion> _detalleact;
    public struct Pedido
    {
        public string PedidoRMS;
        public string PedidoLMS;
        public string Folio;
        public string Distribuidora;
        public string Ruta;
        public string Socio;
        public string Propietario;
        public string RazonSocial;
        public string Calle;
        public string EntreCalle;
        public string YCalle;
        public string Colonia;
        public string Municipio;
        public string Ciudad;
        public string Estado;
        public string CP;
        public string Telefono;
        public string Clave;
        public string Premio;
        public string Cantidad;
        public string FechaSolicitud;
        public string FechaPromesa;
        public string FechaStatus;
        public string Mensajeria;
        public string Guia;
        public string FechaEmbarque;
        public string Origen;
        public string Destino;
        public string RecibidoPor;
        public string Status;
        public string FechaEntrega;
        public string Observaciones;
        public string Proveedor;
        public string TipoEnvio;
        public string Prioridad;
        public string Comentario;
        public string ClaveExtra;
        public string TipoDireccion;
        public string Referencias;
    }

    /* Nuevo */
    public partial class foliosRMS
    {
        public string Folio
        {
            get;
            set;
        }
        public foliosRMS(string folio)
        {
            this.Folio = folio;
        }
    }
    /* Nuevo */

    /*Nuvo Detalle de Canje*/
    List<DetalleCanjesParticipante> foliosResul = new List<DetalleCanjesParticipante>();
    public csRMS()
    {
    }
    /*Nuevo*/

    private void iniciaRMS(int programa_id)
    {
        wsRMS = new wsRewards_Service_2();
        wsRMS.Timeout = 600000;
        using (EntitiesModel.EntitiesModel entities = new EntitiesModel.EntitiesModel(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
        {
            EntitiesModel.programa prog = entities.programas.FirstOrDefault(_pr => _pr.id == programa_id) as EntitiesModel.programa;
            _usuario = prog.usuario_rms;
            _password = prog.password_rms;
            _prefijo_rms = prog.prefijo_rms;
            _email = prog.correo_electronico;
            _remitente = prog.remitente;
            _programa = prog.descripcion;
            _programa_clave = prog.clave;
        }
        database = new csDataBase();
    }
    public csRMS(int programa_id)
    {
        iniciaRMS(programa_id);
    }
    public csRMS(int programa_id, SqlConnection conn)
    {
        iniciaRMS(programa_id);
        this.conn = conn;
    }
    public csRMS(int programa_id, SqlConnection conn, SqlTransaction tran)
    {
        iniciaRMS(programa_id);
        this.conn = conn;
        this.tran = tran;
    }
    public string TipoDireccionID
    {
        set
        {
            _tipo_direccion_id = value;
        }
    }
    public string TransaccionID
    {
        set
        {
            _transaccion_id = value;
        }
    }
    public string PedidoLMS
    {
        get
        {
            return _pedidolms;
        }
    }

    public string PedidoRMS
    {
        get
        {
            return _pedidorms;
        }
    }
    public string FoliosTotales
    {
        get
        {
            return _foliostotales;

        }
    }
    public string FoliosCorrectos
    {
        get
        {
            return _folioscorrectos;
        }
    }
    public string FoliosErroneos
    {
        get
        {
            return _folioserroneos;
        }
    }
    public string Duplicados
    {
        get
        {
            return _duplicados;
        }
    }
    public string FueraRango
    {
        get
        {
            return _fuerarango;
        }
    }
    public string SinFolio
    {
        get
        {
            return _sinfolio;
        }
    }
    public string Proveedores
    {
        get
        {
            return _proveedores;
        }
    }
    public string Sucursal
    {
        get
        {
            return _sucursal;
        }
    }
    public string TransaccionPremioID
    {
        set
        {
            _transaccion_premio_id = value;
        }
    }
    public string Folio
    {
        get
        {
            return _folio;
        }
    }
    public string Comentario
    {
        get
        {
            return _comentario;
        }
        set
        {
            _comentario = value;
        }
    }
    public string Status
    {
        set
        {
            _status = value;
        }
    }
    public string ParticipanteID
    {
        set
        {
            _participante_id = value;
        }
    }
    public string UsuarioID
    {
        set
        {
            _usuario_id = value;
        }
    }

    //public folios BuscaFolio(folios folio)
    //{
    //    return foliosResul.Find(delegate(folios fol)
    //    {
    //        if (fol.folio == folio.folio)
    //        {
    //            return true;
    //        }
    //        return false;
    //    }
    //    );
    //}

    public List<detalleactualizacion> DetalleActualizacion
    {
        get { return _detalleact; }
    }
    private void consultapedido()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_id", _transaccion_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_datos_rms";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        _dtPedido = database.dtConsulta();
        if (_dtPedido.Rows.Count == 0)
        {
            throw new Exception("-1", new Exception("No se encontraron registros"));
        }
    }
    private void consultapedidoactualizar()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_id", _transaccion_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_datos_actualizar_rms";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        _dtPedido = database.dtConsulta();
        if (_dtPedido.Rows.Count == 0)
        {
            throw new Exception("-1", new Exception("No se encontraron registros a actualizar"));
        }
    }
    private void consultaclaverms()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_premio_id", _transaccion_premio_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_consulta_folio_rms";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        _dato = database.consultaDato();
        if (_dato.Equals(DBNull.Value))
        {
            throw new Exception("-1", new Exception("No se encontraron registros"));
        }
        else
        {
            _dato = _dato.ToString();
            _folio = _dato.ToString();
        }
    }

    private void acutalizapedido()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_id", _transaccion_id));
        parametros.Add(new SqlParameter("@pedido_rms", _pedidorms));
        parametros.Add(new SqlParameter("@direccion_entrega", _tipo_direccion_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_actualiza_datos_rms";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        if (database.acutualizaDatos() <= 0)
        {
            throw new Exception("-1", new Exception("No se actualizo el pedido RMS en transacciones"));
        }
    }
    private void eliminapedido()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_id", _transaccion_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_elimina_transaccion";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        if (database.acutualizaDatos() <= 0)
        {
            throw new Exception("-1", new Exception("No se actualizo el pedido RMS en transacciones"));
        }
    }
    private void acutalizastatuspedido()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_premio_id", _transaccion_premio_id));
        parametros.Add(new SqlParameter("@comentario", _comentario));
        parametros.Add(new SqlParameter("@status", _status));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_actualiza_status_rms";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        if (database.acutualizaDatos() <= 0)
        {
            throw new Exception("-1", new Exception("No se actualizo el pedido RMS en transacciones premio"));
        }
    }
    private void insertastatuscanje()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_id", _transaccion_id));
        parametros.Add(new SqlParameter("@comentario", _comentario));
        parametros.Add(new SqlParameter("@status", _status));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_inserta_status_rms";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        if (database.acutualizaDatos() <= 0)
        {
            throw new Exception("-1", new Exception("No se actualizo el pedido RMS en transacciones premio"));
        }
    }
    private void cancela_canje()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@participante_id", _participante_id));
        parametros.Add(new SqlParameter("@transaccion_premio_id", _transaccion_premio_id));
        parametros.Add(new SqlParameter("@usuario_id", _usuario_id));
        database = new csDataBase();
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_cancela_canje";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        if (database.acutualizaDatos() <= 0)
        {
            throw new Exception("-1", new Exception("No se canceló pedido"));
        }
    }
    public bool GeneraPedidoRMS()
    {
        try
        {
            consultapedido();
            string prefijo = _prefijo_rms;
            Logon loginRMS = new Logon();
            loginRMS.usuario = _usuario;
            loginRMS.password = _password;
            CallCenterDB.mx.com.rewards.Pedido[] pedidoRMS = new CallCenterDB.mx.com.rewards.Pedido[_dtPedido.Rows.Count];
            for (int i = 0; i < _dtPedido.Rows.Count; i++)
            {
                DataRow drInsertaPedido = _dtPedido.Rows[i];
                pedidoRMS[i] = new CallCenterDB.mx.com.rewards.Pedido();
                pedidoRMS[i].pedido = drInsertaPedido["pedido"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].folio = drInsertaPedido["folio"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].distribuidora = drInsertaPedido["distribuidora"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].ruta = drInsertaPedido["ruta"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].socio = drInsertaPedido["socio"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].propietario = drInsertaPedido["propietario"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].razonsocial = drInsertaPedido["razonsocial"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].calle = drInsertaPedido["calle"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].entrecalle = drInsertaPedido["entrecalle"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].ycalles = drInsertaPedido["ycalles"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].colonia = drInsertaPedido["colonia"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].municipio = drInsertaPedido["municipio"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].ciudad = drInsertaPedido["ciudad"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].estado = drInsertaPedido["estado"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].cp = drInsertaPedido["cp"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].telefono = drInsertaPedido["telefono"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].clave = drInsertaPedido["clave"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].premio = drInsertaPedido["premio"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].cantidad = drInsertaPedido["cantidad"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].fechasol = drInsertaPedido["fechasol"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].fechaprom = drInsertaPedido["fechaprom"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].fechastatus = drInsertaPedido["fechastatus"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].guia = drInsertaPedido["guia"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].recibidopor = drInsertaPedido["recibidopor"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].status = drInsertaPedido["status"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].observaciones = drInsertaPedido["observaciones"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].factura = drInsertaPedido["factura"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].proveedor = drInsertaPedido["proveedor"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].tipoenvio = drInsertaPedido["tipoenvio"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].prioridad = drInsertaPedido["prioridad"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].claveextra = drInsertaPedido["claveextra"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].asentamiento = drInsertaPedido["asentamiento"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].tipodireccion = drInsertaPedido["tipodireccion"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].referencias = drInsertaPedido["referencias"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
            }
            responsePedido respuestaRMS = wsRMS.wsInsertaPedido(pedidoRMS, loginRMS, prefijo);
            // No regresa ningun registro RMS
            if (respuestaRMS == null)
            {
                //throw new Exception("-1", new Exception("No regreso ningún registro en RMS"));
                error_envio_RMS("No regreso ningún registro en RMS");
                error_enviar_mail("No regreso ningún registro en RMS");
                return false;
            }
            // Usuario o password incorrectos en RMS
            else if (respuestaRMS.pedidolms.Length == 0)
            {
                //throw new Exception("-1", new Exception("Usuario o password incorrectos en RMS"));
                error_envio_RMS("Usuario o password incorrectos en RMS");
                error_enviar_mail("Usuario o password incorrectos en RMS");
                return false;
            }
            else
            {
                _pedidolms = respuestaRMS.pedidolms;
                _pedidorms = respuestaRMS.pedidorms;
                _foliostotales = respuestaRMS.foliostotales;
                _folioscorrectos = respuestaRMS.folioscorrectos;
                _folioserroneos = respuestaRMS.folioserroneos;
                _duplicados = respuestaRMS.duplicados;
                _fuerarango = respuestaRMS.fuerarango;
                _sinfolio = respuestaRMS.sinfolio;
                _proveedores = respuestaRMS.proveedores;
                _sucursal = respuestaRMS.sucursal;


                acutalizapedido();
                _status = "SO";
                _comentario = "Canje";
                insertastatuscanje();
                return true;
            }
        }
        catch (Exception ex)
        {
            // No se inserto en RMS, se elimina la transacción y se manda mensaje.
            eliminapedido();
            // Inserta en la Tabla de Error de Transacción
            error_envio_RMS(ex.InnerException.ToString());
            error_enviar_mail(ex.InnerException.ToString());
            return false;
        }
        // Fin de generacion de pedido RMS
    }

    public bool envioRMS() // Se ocupa para hacer el envio nuevamente a RMS, en caso de error
    {
        try
        {
            consultapedido();
            string prefijo = _prefijo_rms;

            Logon loginRMS = new Logon();
            loginRMS.usuario = _usuario;
            loginRMS.password = _password;
            CallCenterDB.mx.com.rewards.Pedido[] pedidoRMS = new CallCenterDB.mx.com.rewards.Pedido[_dtPedido.Rows.Count];
            for (int i = 0; i < _dtPedido.Rows.Count; i++)
            {
                DataRow drInsertaPedido = _dtPedido.Rows[i];
                pedidoRMS[i] = new CallCenterDB.mx.com.rewards.Pedido();
                pedidoRMS[i].pedido = drInsertaPedido["pedido"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].folio = drInsertaPedido["folio"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].distribuidora = drInsertaPedido["distribuidora"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].ruta = drInsertaPedido["ruta"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].socio = drInsertaPedido["socio"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].propietario = drInsertaPedido["propietario"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].razonsocial = drInsertaPedido["razonsocial"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].calle = drInsertaPedido["calle"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].entrecalle = drInsertaPedido["entrecalle"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].ycalles = drInsertaPedido["ycalles"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].colonia = drInsertaPedido["colonia"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].municipio = drInsertaPedido["municipio"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].ciudad = drInsertaPedido["ciudad"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].estado = drInsertaPedido["estado"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].cp = drInsertaPedido["cp"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].telefono = drInsertaPedido["telefono"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].clave = drInsertaPedido["clave"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].premio = drInsertaPedido["premio"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].cantidad = drInsertaPedido["cantidad"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].fechasol = drInsertaPedido["fechasol"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].fechaprom = drInsertaPedido["fechaprom"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].fechastatus = drInsertaPedido["fechastatus"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].guia = drInsertaPedido["guia"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].recibidopor = drInsertaPedido["recibidopor"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].status = drInsertaPedido["status"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].observaciones = drInsertaPedido["observaciones"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].factura = drInsertaPedido["factura"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].proveedor = drInsertaPedido["proveedor"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].tipoenvio = drInsertaPedido["tipoenvio"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].prioridad = drInsertaPedido["prioridad"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].claveextra = drInsertaPedido["claveextra"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].asentamiento = drInsertaPedido["asentamiento"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].tipodireccion = drInsertaPedido["tipodireccion"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
                pedidoRMS[i].referencias = drInsertaPedido["referencias"].ToString().Replace('\"', ' ').Replace('\'', ' ').Replace('\n', ' ');
            }
            responsePedido respuestaRMS = wsRMS.wsInsertaPedido(pedidoRMS, loginRMS, prefijo);
            // No regresa ningun registro RMS
            if (respuestaRMS == null)
            {
                throw new Exception("-1", new Exception("No regresó ningun registro en RMS"));
            }
            // Usuario o password incorrectos en RMS
            else if (respuestaRMS.pedidolms.Length == 0)
            {
                throw new Exception("-1", new Exception("Usuario o password incorrectos en RMS"));
            }
            else
            {
                _pedidolms = respuestaRMS.pedidolms;
                _pedidorms = respuestaRMS.pedidorms;
                _foliostotales = respuestaRMS.foliostotales;
                _folioscorrectos = respuestaRMS.folioscorrectos;
                _folioserroneos = respuestaRMS.folioserroneos;
                _duplicados = respuestaRMS.duplicados;
                _fuerarango = respuestaRMS.fuerarango;
                _sinfolio = respuestaRMS.sinfolio;
                _proveedores = respuestaRMS.proveedores;
                _sucursal = respuestaRMS.sucursal;
                _status = "SO";
                _comentario = "Canje";
                /* cambia el status del error a enviado*/
                _pedido_rms = _pedidorms;
                if (_dtPedido.Rows.Count != Convert.ToInt32(_duplicados)) // Significa que hubo un error en el envio anterior
                    actualiza_error_envio_RMS();
            }
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al enviar pedido RMS<br/>:" + ex.Message);
        }
        // Fin de envio RMS
    }

    public void GarantiaPedidoRMS()
    {
        consultaclaverms();

        Garantia[] garantia = new Garantia[1];
        garantia[0] = new Garantia();
        garantia[0].folio = _folio;
        garantia[0].comentario = _comentario;
        garantia[0].fecha = DateTime.Now.ToString("yyyy-MM-dd");
        garantia[0].prioridad = "N";
        Logon loginRMS = new Logon();
        loginRMS.usuario = _usuario;
        loginRMS.password = _password;
        resga[] respGarantia = wsRMS.wsRegGarantia(garantia, loginRMS);
        if (respGarantia[0].status == 2)
        {
            throw new Exception("-1", new Exception("Usuario o password incorrectos en RMS"));
        }
        else if (respGarantia[0].status == 0)
        {
            _comentario = respGarantia[0].error;
            throw new Exception("-1", new Exception(respGarantia[0].error));
        }
        else
        {
            _status = "GA";
            acutalizastatuspedido();
        }
    }
    public void CancelaPedidoRMS()
    {
        consultaclaverms();

        Cancelacion[] cancela = new Cancelacion[1];
        cancela[0] = new Cancelacion();
        cancela[0].folio = _folio;
        cancela[0].comentario = _comentario;
        cancela[0].fecha = DateTime.Now.ToString("yyyy-MM-dd");
        Logon loginRMS = new Logon();
        loginRMS.usuario = _usuario;
        loginRMS.password = _password;
        rescan[] respCancela = wsRMS.wsRegCancelacion(cancela, loginRMS);
        if (respCancela[0].status == 2)
        {
            throw new Exception("-1", new Exception("Usuario o password incorrectos en RMS"));
        }
        else if (respCancela[0].status == 0)
        {
            //_comentario = respCancela[0].error;
            throw new Exception("-1", new Exception(respCancela[0].error));
        }
        else
        {
            cancela_canje();
            _status = "CA";
            acutalizastatuspedido();
        }
    }
    public void ActualizaPedidoRMS()
    {
        consultapedidoactualizar();

        Logon loginRMS = new Logon();
        loginRMS.usuario = _usuario;
        loginRMS.password = _password;
        Actualiza[] actualiza = new Actualiza[_dtPedido.Rows.Count];
        for (int i = 0; i < _dtPedido.Rows.Count; i++)
        {
            DataRow drActualiza = _dtPedido.Rows[i];
            actualiza[i].folio = drActualiza["folio"].ToString();
            actualiza[i].socio = drActualiza["socio"].ToString();
            actualiza[i].propietario = drActualiza["propietario"].ToString();
            actualiza[i].razonsocial = drActualiza["razonsocial"].ToString();
            actualiza[i].calle = drActualiza["calle"].ToString();
            actualiza[i].entrecalle = drActualiza["entrecalle"].ToString();
            actualiza[i].ycalles = drActualiza["ycalles"].ToString();
            actualiza[i].colonia = drActualiza["colonia"].ToString();
            actualiza[i].municipio = drActualiza["municipio"].ToString();
            actualiza[i].ciudad = drActualiza["ciudad"].ToString();
            actualiza[i].estado = drActualiza["estado"].ToString();
            actualiza[i].cp = drActualiza["cp"].ToString();
            actualiza[i].telefono = drActualiza["telefono"].ToString();
            actualiza[i].asentamiento = drActualiza["asentamiento"].ToString();
            actualiza[i].referencias = drActualiza["referencias"].ToString();
        }
        rud[] respuestaRMS = wsRMS.wsUpdateData(actualiza, loginRMS);

        if (respuestaRMS == null)
        {
            throw new Exception("-1", new Exception("No regreso ningún registro en RMS"));
        }
        // Usuario o password incorrectos en RMS
        else if (respuestaRMS.Length != _dtPedido.Rows.Count)
        {
            throw new Exception("-1", new Exception("No se actualizaron todos los registros en RMS"));
        }
        else
        {
            _detalleact = new List<detalleactualizacion>();
            for (int i = 0; i < respuestaRMS.Length; i++)
            {
                detalleactualizacion _d = new detalleactualizacion();
                _d.folio = respuestaRMS[i].folio;
                _d.status = respuestaRMS[i].status;
                _d.error = respuestaRMS[i].error;
                _detalleact.Add(_d);
            }
        }
    }
    public Pedido ConsultaPedidoRMS()
    {
        Pedido p = new Pedido();
        consultaclaverms();

        Logon loginRMS = new Logon();
        loginRMS.usuario = _usuario;
        loginRMS.password = _password;

        Filtros filtro = new Filtros();
        filtro.folio = this.Folio;
        Consulta[] consulta = wsRMS.wsConsultaDeFolios(filtro, loginRMS);
        // No regresa ningun registro RMS
        if (consulta == null)
        {
            throw new Exception("-1", new Exception("No regreso ningún registro en RMS"));
        }
        // Usuario o password incorrectos en RMS
        else if (consulta.Length == 0)
        {
            throw new Exception("-1", new Exception("Usuario o password incorrectos en RMS"));
        }
        else
        {
            for (int i = 0; i < consulta.Length; i++)
            {
                Consulta c = consulta[i];
                p.PedidoRMS = c.pedidorms;
                p.PedidoLMS = c.pedidolms;
                p.Folio = c.folio;
                p.Distribuidora = c.distribuidora;
                p.Ruta = c.ruta;
                p.Socio = c.socio;
                p.Propietario = c.propietario;
                p.RazonSocial = c.razonsocial;
                p.Calle = c.calle;
                p.EntreCalle = c.entrecalle;
                p.YCalle = c.ycalles;
                p.Colonia = c.colonia;
                p.Municipio = c.municipio;
                p.Ciudad = c.ciudad;
                p.Estado = c.estado;
                p.CP = c.cp;
                p.Telefono = c.telefono;
                p.Clave = c.clave;
                p.Premio = c.premio;
                p.Cantidad = c.cantidad;
                p.FechaSolicitud = c.fechasol;
                p.FechaPromesa = c.fechaprom;
                p.FechaStatus = c.fechastatus;
                p.Mensajeria = c.mensajeria;
                p.Guia = c.guia;
                p.FechaEmbarque = c.fechaemb;
                p.Origen = c.origen;
                p.Destino = c.destino;
                p.RecibidoPor = c.recibidopor;
                p.Status = c.status;
                p.FechaEntrega = c.fechaentrega;
                p.Observaciones = c.observaciones;
                p.Proveedor = c.proveedor;
                p.TipoEnvio = c.tipoenvio;
                p.Prioridad = c.prioridad;
                p.Comentario = c.comentario;
                p.ClaveExtra = c.claveextra;
                p.TipoDireccion = c.tipodireccion;
                p.Referencias = c.referencias;
            }
        }
        return p;
    }

    public Pedido ConsultaPedidoRMS(string PedidoLMS, string PedidoRMS)
    {
        Pedido p = new Pedido();
        consultaclaverms();

        Logon loginRMS = new Logon();
        loginRMS.usuario = _usuario;
        loginRMS.password = _password;

        Filtros filtro = new Filtros();
        //filtro.folio = this.Folio;
        filtro.pedidolms = PedidoLMS;
        filtro.pedidorms = PedidoRMS;
        Consulta[] consulta = wsRMS.wsConsultaDeFolios(filtro, loginRMS);
        // No regresa ningun registro RMS
        if (consulta == null)
        {
            throw new Exception("-1", new Exception("No regreso ningún registro en RMS"));
        }
        // Usuario o password incorrectos en RMS
        else if (consulta.Length == 0)
        {
            throw new Exception("-1", new Exception("Usuario o password incorrectos en RMS"));
        }
        else
        {
            for (int i = 0; i < consulta.Length; i++)
            {
                Consulta c = consulta[i];
                p.PedidoRMS = c.pedidorms;
                p.PedidoLMS = c.pedidolms;
                p.Folio = c.folio;
                p.Distribuidora = c.distribuidora;
                p.Ruta = c.ruta;
                p.Socio = c.socio;
                p.Propietario = c.propietario;
                p.RazonSocial = c.razonsocial;
                p.Calle = c.calle;
                p.EntreCalle = c.entrecalle;
                p.YCalle = c.ycalles;
                p.Colonia = c.colonia;
                p.Municipio = c.municipio;
                p.Ciudad = c.ciudad;
                p.Estado = c.estado;
                p.CP = c.cp;
                p.Telefono = c.telefono;
                p.Clave = c.clave;
                p.Premio = c.premio;
                p.Cantidad = c.cantidad;
                p.FechaSolicitud = c.fechasol;
                p.FechaPromesa = c.fechaprom;
                p.FechaStatus = c.fechastatus;
                p.Mensajeria = c.mensajeria;
                p.Guia = c.guia;
                p.FechaEmbarque = c.fechaemb;
                p.Origen = c.origen;
                p.Destino = c.destino;
                p.RecibidoPor = c.recibidopor;
                p.Status = c.status;
                p.FechaEntrega = c.fechaentrega;
                p.Observaciones = c.observaciones;
                p.Proveedor = c.proveedor;
                p.TipoEnvio = c.tipoenvio;
                p.Prioridad = c.prioridad;
                p.Comentario = c.comentario;
                p.ClaveExtra = c.claveextra;
                p.TipoDireccion = c.tipodireccion;
                p.Referencias = c.referencias;
            }
        }
        return p;
    }

    public Boolean VerificaTransaccionRMS()
    {
        int cont = 0;
        int cantFolios = 0;
        int contSinDuplicados = 0;
        String sFolio = "";
        consultapedido();
        string prefijo = _prefijo_rms;

        if (_dtPedido.Rows.Count > 0)
        {
            LogonM logon = new LogonM();
            logon.usuario = _usuario;
            logon.password = _password;
            ConsultaMultiple[] consultaM = new ConsultaMultiple[_dtPedido.Rows.Count];
            FiltrosM[] filtros = new FiltrosM[_dtPedido.Rows.Count];

            List<foliosRMS> folios_VipClub = new List<foliosRMS>();
            List<String> folios_VipClubSinDuplicados = new List<String>();
            List<String> folios_RMS = new List<String>();
            foliosRMS foliosSinDuplicados;
            foreach (DataRow Row in _dtPedido.Rows)
            {
                filtros[cont] = new FiltrosM();
                filtros[cont].folio = Row["folio"].ToString();
                cont += 1;
                foliosSinDuplicados = new foliosRMS(Row["folio"].ToString());
                if (folios_VipClub.Find(p => p.Equals(foliosSinDuplicados)) == null)
                {
                    folios_VipClubSinDuplicados.Add(foliosSinDuplicados.Folio);
                }
            }
            // Quita Folios Duplicados porque la consulta así lo puede arrojar, pero eso no significa que haya como tal.
            folios_VipClubSinDuplicados = folios_VipClubSinDuplicados.Distinct().ToList();
            contSinDuplicados = folios_VipClubSinDuplicados.Count;
            foliosRMS folios;
            for (int i = 0; i < contSinDuplicados; i++)
            {
                folios = new foliosRMS(folios_VipClubSinDuplicados[i]);
                if (folios_VipClub.Find(p => p.Equals(folios)) == null)
                {
                    folios_VipClub.Add(folios); // Guarda los folios no duplicados en este arreglo
                }
            }
            // Llama el metodo de consulta multiple de RMS, para saber si estan esos folios
            consultaM = wsRMS.wsConsultaDeFoliosMultiple(filtros, logon);
            foreach (ConsultaMultiple pedido in consultaM)
            {
                folios_RMS.Add(pedido.folio); // Es posible que no haya, los guarda en este arreglo
            }
            /* Obtiene los folios que no se insertaron en RMS */
            for (int i = 0; i < contSinDuplicados; i++)
            {
                String folioToBeSearched = folios_VipClubSinDuplicados[i];
                String encontrar = folios_RMS.Find(delegate(String p)
                {
                    return p == folioToBeSearched;
                }
                );
                if (encontrar != null)
                    cantFolios++;
                else
                    sFolio = sFolio + folioToBeSearched + " ";
            }
            consultaM = null;
            filtros = null;
            sFolio = sFolio.Trim().Replace(" ", ",");
            if (contSinDuplicados == cantFolios && contSinDuplicados != 0 && cantFolios != 0)
                return true; // Si se realizo el insert en RMS correctamente.
            else
                if (cantFolios == 0)
                {
                    // No se inserto en RMS, se elimina la transacción y se manda mensaje.
                    eliminapedido();
                    error_envio_RMS("Transacción eliminada: " + _transaccion_id + ". Los folios que no se insertaron en RMS son: " + sFolio);
                    return false;
                }
                else
                {
                    // manda mail de aviso que no se insertaron todos los folios en RMS, se inserta en la tabla de errores y se manda mail de aviso.
                    error_envio_RMS("Transacción incompleta: " + _transaccion_id + ". Los folios que no se insertaron en RMS son: " + sFolio);
                    error_enviar_mail("Transacción incompleta: " + _transaccion_id + ". Los folios que no se insertaron en RMS son: " + sFolio);
                    return false;
                }
        }
        else
            return false;
    }

    public bool GeneraPedidoRMS(long FolioPedido)
    {
        consultapedido();
        //string prefijo = _dtPedido.Rows[0]["folio"].ToString().Substring(0, _dtPedido.Rows[0]["folio"].ToString().IndexOf('-'));
        _pedidorms = FolioPedido.ToString();
        acutalizapedidobr();

        return true;
        // Fin de generacion de pedido RMS
    }

    private void acutalizapedidobr()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_id", _transaccion_id));
        parametros.Add(new SqlParameter("@pedido_rms", _pedidorms));
        parametros.Add(new SqlParameter("@direccion_entrega", _tipo_direccion_id));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_actualiza_datos_rms_br";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        if (database.acutualizaDatos() <= 0)
        {
            throw new Exception("-1", new Exception("No se actualizo el pedido RMS en transacciones"));
        }
    }

    public void error_envio_RMS(String mensaje)
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_id", _transaccion_id));
        parametros.Add(new SqlParameter("@tipo_direccion_id", _tipo_direccion_id));
        parametros.Add(new SqlParameter("@country_code", _programa_clave));
        parametros.Add(new SqlParameter("@mensaje", mensaje));
        parametros.Add(new SqlParameter("@status", "0"));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "error_envio_RMS_Insert";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        if (database.acutualizaDatos() <= 0)
        {
            throw new Exception("-1", new Exception("No se inserto el error de envio de RMS"));
        }
    }

    public void actualiza_error_envio_RMS()
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@transaccion_id", _transaccion_id));
        parametros.Add(new SqlParameter("@tipo_direccion_id", _tipo_direccion_id));
        parametros.Add(new SqlParameter("@country_code", _programa_clave));
        parametros.Add(new SqlParameter("@pedido_rms", _pedido_rms));
        parametros.Add(new SqlParameter("@status", "1"));
        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "error_envio_RMS_Update";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        if (database.acutualizaDatos() <= 0)
        {
            throw new Exception("-1", new Exception("No se actualizó el status de error del envio RMS"));
        }
    }

    public void error_enviar_mail(String mensaje)
    {
    }

    public DataTable ConsultaFoliosCanje(string programa, string participante_id)
    {
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@programa", programa));
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
        database.Query = "sp_consulta_folios_canje";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        DataTable dt = database.dtConsulta();
        return dt;

    }


    public List<DetalleCanjesParticipante> ConsultaFoliosParticipanteRMS(string programa, string ParticipanteID)
    {
        //List<DetalleCanjesParticipante> ListaCanjes = new List<DetalleCanjesParticipante>();
        wsRMS = new wsRewards_Service_2();
        try
        {

            DataTable dtFolios = ConsultaFoliosCanje(programa, ParticipanteID);
            csParticipanteComplemento p = new csParticipanteComplemento();


            DataTable dtPrograma = new DataTable();
            dtPrograma = p.consultaDatosPrograma(programa);

            CallCenterDB.mx.com.rewards.LogonM logon = new CallCenterDB.mx.com.rewards.LogonM();
            logon.usuario = dtPrograma.Rows[0]["usuario_rms"].ToString();
            logon.password = dtPrograma.Rows[0]["password_rms"].ToString();

            CallCenterDB.mx.com.rewards.ConsultaMultiple[] consultaM = new CallCenterDB.mx.com.rewards.ConsultaMultiple[dtFolios.Rows.Count];
            CallCenterDB.mx.com.rewards.FiltrosM[] filtros = new CallCenterDB.mx.com.rewards.FiltrosM[dtFolios.Rows.Count];

            long cont = 0;


            foreach (DataRow Row in dtFolios.Rows)
            {
                DetalleCanjesParticipante detCanje = new DetalleCanjesParticipante();
                filtros[cont] = new CallCenterDB.mx.com.rewards.FiltrosM();
                filtros[cont].folio = Row["folio"].ToString();
                //Lena lista a retornar
                detCanje.Folio = Row["folio"].ToString();
                detCanje.EstatusAnterior = Row["clave_rms"].ToString();
                detCanje.TransaccionPremioID = Row["transaccionPremio_id"].ToString();
                detCanje.DescripcionPremio = Row["premio"].ToString();
                detCanje.Puntos = Row["puntos"].ToString();
                detCanje.FechaCanje = Row["fecha"].ToString();
                foliosResul.Add(detCanje);
                cont += 1;
            }

            consultaM = wsRMS.wsConsultaDeFoliosMultiple(filtros, logon);
            List<SqlParameter> parametrosFol = new List<SqlParameter>();
            foreach (CallCenterDB.mx.com.rewards.ConsultaMultiple pedido in consultaM)
            {

                string folioresul = pedido.folio;
                if (folioresul.Length > 0 & pedido.status.Length > 0)
                {
                    DetalleCanjesParticipante folRBus = new DetalleCanjesParticipante();
                    folRBus.Folio = pedido.folio;
                    folRBus = BuscaFolio(folRBus);
                    folRBus.ClaveStatusRMS = pedido.status;
                    string statusDescripcion = ConsultaCatalogRMS("Estatus", pedido.status);
                    folRBus.StatusActual = statusDescripcion;
                    string observDescripcion = ConsultaCatalogRMS("Observaciones", pedido.observaciones);
                    folRBus.Observaciones = observDescripcion;
                    string MensajerioDesc = ConsultaCatalogRMS("Mensajeria", pedido.mensajeria);
                    folRBus.Mensajeria = MensajerioDesc;
                    folRBus.NumeroGuia = pedido.guia;
                    folRBus.FechaEntrega = pedido.fechaentrega;

                    //   string transaccin_premio = folRBus.TransaccionPremioID;

                    // ActualizaFolio(folRBus);

                    if (folRBus.ClaveStatusRMS != folRBus.EstatusAnterior)
                    {
                        parametrosFol.Clear();
                        parametrosFol.Add(new SqlParameter("@transaccion_id", folRBus.TransaccionPremioID));
                        parametrosFol.Add(new SqlParameter("@comentario", folRBus.Observaciones));
                        parametrosFol.Add(new SqlParameter("@status", folRBus.ClaveStatusRMS));
                        parametrosFol.Add(new SqlParameter("@fecha", folRBus.FechaCanje));
                        int resul = database.acutualizaDatos("sp_actualiza_premio_status_rms", parametrosFol, true);

                    }
                }


            }
            consultaM = null;
            filtros = null;


        }
        catch (Exception ex)
        {
            //foliosResul = null;
        }
        return foliosResul;


    }

    public DetalleCanjesParticipante BuscaFolio(DetalleCanjesParticipante folio)
    {

        return foliosResul.Find(delegate(DetalleCanjesParticipante fol)
        {
            if (fol.Folio == folio.Folio)
            {
                return true;
            }
            return false;
        }
        );

    }

    public void ActualizaFolio(DetalleCanjesParticipante folio)
    {
        int i = foliosResul.FindIndex(delegate(DetalleCanjesParticipante fol)
        {
            if (fol.Folio == folio.Folio)
            {
                return true;
            }
            return false;
        }
        );
        foliosResul.RemoveAt(i);
        foliosResul.Insert(i, folio);
    }

    public string ConsultaCatalogRMS(string catalogo, string clave)
    {
        string Descripcion = "No Definido";
        List<SqlParameter> parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@catalogo", catalogo));
        parametros.Add(new SqlParameter("@clave", clave));

        database = new csDataBase();
        if (this.conn != null)
        {
            database.Conexion = conn;
        }
        if (this.tran != null)
        {
            database.Transaccion = tran;
        }
        database.Query = "sp_consulta_descripcion_catalogo_rms";
        database.Parametros = parametros;
        database.EsStoreProcedure = true;
        DataTable dt = database.dtConsulta();
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                Descripcion = dt.Rows[0]["descripcion"].ToString();
            }
        }
        return Descripcion;

    }


}
