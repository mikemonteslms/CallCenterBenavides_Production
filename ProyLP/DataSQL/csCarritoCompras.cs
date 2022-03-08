using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using CallCenterDB.lms.enviarmail;
using System.IO;
using System.Configuration;
using CallCenterDB.lms.enviarmail;

/// <summary>
/// Summary description for csCarritoCompras
/// VSC
/// </summary>
/// 
public class csCarritoCompras
{
    private List<csPremio> _carrito;
    private csDataBase database;
    private List<SqlParameter> parametros;
    private SqlConnection conn;
    private SqlTransaction tran;

    private string participante_id;
    private string usuario_id;

    private string puntos_transaccion;
    private int transaccion_id;
    private string tipo_transaccion_id;
    private string tipo_transaccion;
    private string categoria_transaccion_id;

    private List<csPremio> _canje_rms;

    public csCarritoCompras()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public csCarritoCompras(SqlConnection conn)
    {
        this.conn = conn;
    }
    public csCarritoCompras(SqlConnection conn, SqlTransaction tran)
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
    public List<csPremio> Carrito
    {
        get { return _carrito; }
        set { _carrito = value; }
    }
    public List<csPremio> CanjesRMS
    {
        get { return _canje_rms; }
        set { _canje_rms = value; }
    }
    public void Agregar(csPremio premio)
    {
        if (_carrito == null)
        {
            _carrito = new List<csPremio>();
        }
        _carrito.Add(premio);
    }

    public List<csPremio> Buscar(csPremio premio)
    {
        List<csPremio> lista = new List<csPremio>();
        foreach (csPremio pr in _carrito)
        {
            if (premio == pr)
            {
                lista.Add(pr);
            }
        }
        return lista;
    }
    public List<csPremio> Buscar(string busqueda)
    {
        List<csPremio> lista = new List<csPremio>();
        foreach (csPremio pr in _carrito)
        {
            if (pr.Descripcion.ToLower().Contains(busqueda))
            {
                lista.Add(pr);
            }
        }
        return lista;
    }
    public void Actualizar(csPremio premio)
    {
        int i = -1;
        i = _carrito.FindIndex(delegate(csPremio pr)
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
    public void Eliminar(csPremio premio)
    {
        int i = -1;
        i = _carrito.FindIndex(delegate(csPremio pr)
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
                foreach (csPremio pr in _carrito)
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
                foreach (csPremio pr in _carrito)
                {
                    ptos += int.Parse(pr.Puntos) * int.Parse(pr.Cantidad);
                }
                return ptos;
            }
        }
    }
    public int PuntosExcepto(csPremio premio)
    {
        if (_carrito == null)
        {
            return 0;
        }
        else
        {
            int ptos = 0;
            foreach (csPremio pr in _carrito)
            {
                if (premio != pr)
                {
                    ptos += int.Parse(pr.Puntos) * int.Parse(pr.Cantidad);
                }
            }
            return ptos;
        }
    }
    protected bool InsertaTransaccion(string pais)
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
        transaccion_id = Convert.ToInt16(database.consultaDato());
        if (transaccion_id > 0)
        {
            if (_carrito != null)
            {
                _canje_rms = new List<csPremio>();
                foreach (csPremio premio in _carrito)
                {
                    for (int i = 0; i < int.Parse(premio.Cantidad); i++)
                    {
                        string folio = InsertaTransaccion_Premio(transaccion_id.ToString(), premio);
                        csPremio _premio_canje = new csPremio(premio.PremioID, premio.Descripcion, premio.URL, premio.Puntos, "1");
                        _premio_canje.Folio = folio;
                        _premio_canje.Observaciones = premio.Observaciones;
                        _canje_rms.Add(_premio_canje);
                    }
                }
                insertado = true;
            }
            ActualizaSaldoParticipante(pais);
            insertado = true;
        }
        return insertado;
    }

    private string InsertaTransaccion_Premio(string transaccion_id, csPremio premio)
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
    private void ActualizaSaldoParticipante(string pais)
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
    public int Canjear(string AUTH_USER, string REMOTE_HOST, string SERVER_PORT, string TipoDireccion_ID, string PAIS)
    {
        Datos oDatos = new Datos();
        Funciones oFunciones = new Funciones();

        int canje = 0;
        try
        {
            bool inserta_transaccion = InsertaTransaccion(PAIS);
            if (inserta_transaccion == true)
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
                rms = new csRMS(conn, tran);
            }
            else if (this.conn != null && this.tran == null)
            {
                rms = new csRMS(conn);
            }
            else
            {
                rms = new csRMS();
            }
            rms.TransaccionID = transaccion_id.ToString();
            rms.TipoDireccionID = TipoDireccion_ID;
            rms.Pais = PAIS;
            if (rms.GeneraPedidoRMS())
            {
                try
                {
                    string plantilla = HttpContext.Current.Server.MapPath("plantillas/aviso_canje.html");
                    string html = "";
                    using (StreamReader sr = new StreamReader(plantilla))
                    {
                        html = sr.ReadToEnd();
                    }
                    html = html.Replace("@ESTILO", ConfigurationManager.AppSettings["estilos"]);
                    html = html.Replace("@PAIS", PAIS);

                    string body = "";
                    body += "Transaccion " + transaccion_id + "<br />";
                    body += "<br />" + oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "nombreAplicacion") + " - " + PAIS + "<br />";
                    body += "<b>Pedido LMS:</b> " + rms.PedidoLMS + "<br />";
                    body += "<b>Pedido RMS:</b> " + rms.PedidoRMS + "<br />";
                    body += "<b>Folios totales:</b> " + rms.FoliosTotales + "<br />";
                    body += "<b>Folios Correctos:</b> " + rms.FoliosCorrectos + "<br />";
                    body += "<b>Folios Erroneos:</b> " + rms.FoliosErroneos + "<br />";
                    body += "<b>Duplicados:</b> " + rms.Duplicados + "<br />";
                    body += "<b>Fuera de rango:</b> " + rms.FueraRango + "<br />";
                    body += "<b>Sin folio:</b> " + rms.SinFolio + "<br />";
                    body += "<b>Proveedores:</b> " + rms.Proveedores + "<br />";
                    body += "<b>Sucursal:</b> " + rms.Sucursal + "<br />";
                    body += "<b>Participante ID:</b> " + participante_id + "<br />";
                    body += "<b>Usuario ID:</b> " + usuario_id + "<br />";
                    body += "<b>AUTH_USER:</b> " + AUTH_USER + "<br />";
                    body += "<b>REMOTE_HOST:</b> " + REMOTE_HOST + "<br />";
                    body += "<b>SERVER_PORT:</b> " + SERVER_PORT + "<br />";

                    html = html.Replace("@MENSAJE", body);

                    EnvioMail enviar = new EnvioMail();
                    CallCenterDB.lms.enviarmail.Datos d = new CallCenterDB.lms.enviarmail.Datos();
                    d.FromMail = "contacto@triangulopremia.com.mx";
                    d.FromName = "Contacto Triangulo Premia";
                    d.ToMail = "alina.sanchez@lms-la.com";
                    d.ToName = "Alina Sánchez";
                    d.Subject = "Triangulo Premia - Se generó pedido RMS - " + PAIS;
                    d.Body = html;
                    CallCenterDB.lms.enviarmail.Datos[] arrDatos = new CallCenterDB.lms.enviarmail.Datos[1];
                    arrDatos[0] = d;
                    Respuesta r = enviar.Enviar(arrDatos);

                }
                catch (Exception ez)
                {
                    csError error = new csError(HttpContext.Current, ez);
                    error.EscribirLog();
                }
            }

            #endregion
        }
        catch (Exception ex)
        {
            try
            {
                string plantilla = HttpContext.Current.Server.MapPath("plantillas/aviso_canje.html");
                string html = "";
                using (StreamReader sr = new StreamReader(plantilla))
                {
                    html = sr.ReadToEnd();
                }
                html = html.Replace("@ESTILO", ConfigurationManager.AppSettings["estilos"]);
                html = html.Replace("@PAIS", PAIS);
                string error = "";
                error += "Transaccion " + transaccion_id + "<br />";
                error += "<br />" + oDatos.numerosIniciales("datosContacto.xml", "cadContacto", "nombreAplicacion") + " - " + PAIS + "<br />";
                error += "<b>Participante ID:</b> " + participante_id + "<br />";
                error += "<b>Usuario ID:</b> " + usuario_id + "<br />";
                error += "<b>AUTH_USER:</b> " + AUTH_USER + "<br />";
                error += "<b>REMOTE_HOST:</b> " + REMOTE_HOST + "<br />";
                error += "<b>SERVER_PORT:</b> " + SERVER_PORT + "<br />";
                error += "<b>ERROR:</b> " + ex.Message;
                html = html.Replace("@MENSAJE", error);

                EnvioMail enviar = new EnvioMail();
                CallCenterDB.lms.enviarmail.Datos d = new CallCenterDB.lms.enviarmail.Datos();
                d.FromMail = "contacto@triangulopremia.com.mx";
                d.FromName = "Contacto Triangulo Premia";
                d.ToMail = "alina.sanchez@lms-la.com";
                d.ToName = "Alina Sánchez";
                d.Subject = "Triangulo Premia - Error al generar pedido RMS";
                d.Body = html;
                CallCenterDB.lms.enviarmail.Datos[] arrDatos = new CallCenterDB.lms.enviarmail.Datos[1];
                arrDatos[0] = d;
                Respuesta r = enviar.Enviar(arrDatos);
            }
            catch (Exception ey)
            {
                csError error = new csError(HttpContext.Current, ey);
                error.EscribirLog();
            }
            canje = -2;
        }
        return canje;
    }

    public CallCenterDB.Entidades.RMS Canjear(string TipoDireccion_ID, string PAIS)
    {
        int canje = 0;
        bool inserta_transaccion = InsertaTransaccion(PAIS);
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
            rms = new csRMS(conn, tran);
        }
        else if (this.conn != null && this.tran == null)
        {
            rms = new csRMS(conn);
        }
        else
        {
            rms = new csRMS();
        }
        rms.TransaccionID = transaccion_id.ToString();
        rms.TipoDireccionID = TipoDireccion_ID;
        rms.Pais = PAIS;
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
                csRMS errorInsert = new csRMS();
                errorInsert.TransaccionID = transaccion_id.ToString();
                errorInsert.TipoDireccionID = TipoDireccion_ID;
                errorInsert.Pais = PAIS;
                errorInsert.VerificaTransaccionRMS(); // Valida que se haya hecho el insert en RMS
            }
        }
        catch (Exception ex)
        {
            /* Inserta el error */
            csRMS errorInsert = new csRMS();
            errorInsert.TransaccionID = transaccion_id.ToString();
            errorInsert.TipoDireccionID = TipoDireccion_ID;
            errorInsert.Pais = PAIS;
            errorInsert.VerificaTransaccionRMS(); // Valida que se haya hecho el insert en RMS
        }
        #endregion
        return _rms;
    }
}
