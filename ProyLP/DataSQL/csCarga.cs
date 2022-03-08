using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Configuration;
using CallCenterDB;
using System.Data.Linq;
using System.Data.SqlClient;

public class csCarga
{
    cargaDataContext dataContext;

    char separador = ',';
    int campos = 20;
    int errores;
    private int _id;
    private string _archivo;
    private string _ext;
    private string _mimetype;
    private DateTime _fecha;
    private string _status;

    private string _archivo_parte;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Archivo
    {
        get { return _archivo; }
        set { _archivo = value; }
    }
    public string Ext
    {
        get { return _ext; }
        set { _ext = value; }
    }
    public string MimeType
    {
        get { return _mimetype; }
        set { _mimetype = value; }
    }
    public DateTime Fecha
    {
        get { return _fecha; }
        set { _fecha = value; }
    }
    public string Status
    {
        get { return _status; }
        set { _status = value; }
    }
    public string ArchivoParte
    {
        get { return _archivo_parte; }
        set { _archivo_parte = value; }
    }
    public List<TmpVentasError> RegistrosError
    {
        get;
        set;
    }
    public csCarga()
    {
        errores = int.Parse(ConfigurationManager.AppSettings["errores_carga"].ToString());
    }
    public csCarga(int id, string archivo, string ext, string mimetype, DateTime fecha, string status)
    {
        this.Id = id;
        this.Archivo = archivo;
        this.Ext = ext;
        this.MimeType = mimetype;
        this.Fecha = fecha;
        this.Status = status;
    }
    protected int consulta_status(string status)
    {
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {
            var _status = (from s in dataContext.StatusCargas
                           where s.clave == status
                           select s.id).Single();
            return Convert.ToInt32(_status);
        }
    }
    public int GuardaHistorico()
    {
        int status = consulta_status("PENDIENTE");
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {

            var h = new HistoricoCargas()
            {
                nombre = this._archivo,
                ext = this._ext,
                mimetype = this._mimetype,
                fecha = DateTime.Now,
                status_carga_id = status,
            };
            dataContext.HistoricoCargas.InsertOnSubmit(h);
            dataContext.SubmitChanges();
            return h.id;
        }
    }
    public int GuardaHistoricoParte()
    {
        int status = consulta_status("PENDIENTE");
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {

            var h = new HistoricoCargaPartes()
            {
                nombre = this._archivo_parte,
                historico_carga_id = this.Id,
                fecha = DateTime.Now,
                status_carga_id = status,
            };
            dataContext.HistoricoCargaPartes.InsertOnSubmit(h);
            dataContext.SubmitChanges();
            return h.id;
        }
    }
    public void ActualizaHistorico(int id, string status)
    {
        int _status = consulta_status(status);
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {

            HistoricoCargas carga = dataContext.HistoricoCargas.Single(h => h.id == id) as HistoricoCargas;
            carga.status_carga_id = _status;
            dataContext.SubmitChanges();
        }
    }
    public int ActualizaHistoricoPartes(int id, string status)
    {
        int historico_carga_id = 0;
        int _status = consulta_status(status);
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {
            HistoricoCargaPartes carga = dataContext.HistoricoCargaPartes.Single(h => h.id == id) as HistoricoCargaPartes;
            carga.status_carga_id = _status;
            dataContext.SubmitChanges();
            historico_carga_id = carga.historico_carga_id;
        }
        return historico_carga_id;
    }
    public List<csCarga> ConsultaTodo()
    {
        List<csCarga> listCarga = new List<csCarga>();
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {
            var carga = (from h in dataContext.HistoricoCargas
                         join s in dataContext.StatusCargas on h.status_carga_id equals s.id
                         select new { h.id, h.nombre, h.ext, h.mimetype, h.fecha, s.status });
            foreach (var ca in carga.ToList())
            {
                listCarga.Add(new csCarga(ca.id, ca.nombre, ca.ext, ca.mimetype, ca.fecha, ca.status));
            }
        }
        return listCarga;
    }
    public List<csCarga> ConsultaPartes()
    {
        List<csCarga> listCarga = new List<csCarga>();
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {
            var carga = (from h in dataContext.HistoricoCargaPartes
                         join s in dataContext.StatusCargas on h.status_carga_id equals s.id
                         where h.historico_carga_id == this.Id
                         select new { h.id, h.nombre, h.fecha, s.status });
            foreach (var ca in carga.ToList())
            {
                listCarga.Add(new csCarga(ca.id, ca.nombre, null, null, ca.fecha, ca.status));
            }
        }
        return listCarga;
    }
    public int DivideArchivo(string period)
    {
        int parte = 0;
        using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("carga/" + this.Archivo)))
        {
            sr.ReadLine(); // Línea de encabezado
            while (!sr.EndOfStream)
            {
                parte ++;
                int num_linea = 0;
                this._archivo_parte =  this.Archivo + parte.ToString("D2");
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("carga/" + this._archivo_parte)))
                {
                    while (!sr.EndOfStream && num_linea < 15000)
                    {
                        string linea_leida = sr.ReadLine();
                        if (linea_leida.Contains(period))
                        {
                            sw.WriteLine(linea_leida);
                            num_linea++;
                        }
                    }
                    GuardaHistoricoParte();
                }
            }
        }
        return parte;
    }
    public csCarga Consulta()
    {
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {
            var carga = (from h in dataContext.HistoricoCargas
                         join s in dataContext.StatusCargas on h.status_carga_id equals s.id
                         where h.id == this.Id
                         select new { h.id, h.nombre, h.ext, h.mimetype, h.fecha, s.status }).Single();
            csCarga cc = new csCarga(carga.id, carga.nombre, carga.ext, carga.mimetype, carga.fecha, carga.status);
            return cc;
        }
    }
    public csCarga ConsultaParte()
    {
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {
            var carga = (from h in dataContext.HistoricoCargaPartes
                         join s in dataContext.StatusCargas on h.status_carga_id equals s.id
                         where h.id == this.Id
                         select new { h.id, h.nombre, h.fecha, s.status }).Single();
            csCarga cc = new csCarga(carga.id, carga.nombre, null, null, carga.fecha, carga.status);
            return cc;
        }
    }
    public int Cargar(string period)
    {
        if (String.IsNullOrEmpty(this._archivo))
        {
            throw new Exception("Archivo requerido");
        }

        List<TmpVentas> lt = new List<TmpVentas>();
        List<TmpVentasError> lte = new List<TmpVentasError>();
        int errores = 0;
        using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("carga/" + this._archivo)))
        {
            while (!sr.EndOfStream)
            {
                string linea = sr.ReadLine();
                linea = linea.Trim();
                if (linea.Contains(period))
                {
                    if (linea.EndsWith(","))
                    {
                        linea = linea.Remove(linea.LastIndexOf(","));
                    }
                    string[] registro = LeeLinea(linea);
                    if (registro.Length == campos)
                    {
                        try
                        {
                            TmpVentas t = GuardaCampoOK(registro);
                            lt.Add(t);
                        }
                        catch (Exception ex)
                        {
                            TmpVentasError tmpve = new TmpVentasError();
                            tmpve.datos = linea;
                            lte.Add(tmpve);
                        }
                    }
                    else
                    {
                        errores++;
                        if (errores >= this.errores)
                        {
                            throw new Exception(string.Format("El archivo contiene más de {0} errores.", errores));
                        }
                        TmpVentasError tmpve = new TmpVentasError();
                        tmpve.datos = linea;
                        lte.Add(tmpve);
                    }
                }
            }
        }
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString;
        SqlTransaction tran = null;
        try
        {

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            tran = conn.BeginTransaction("tmp_ventas");
            csDataBase database1 = new csDataBase(conn, tran);
            foreach (TmpVentas t in lt)
            {
                if (!GuardaCampoOK(t, database1))
                {
                    errores++;
                }
            }
            tran.Commit();
        }
        catch (Exception ex)
        {
            tran.Rollback("tmp_ventas");
            throw ex;
        }
        finally
        {
            conn.Close();
        }
        RegistrosError = lte;
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {
            dataContext.Connection.Open();
            dataContext.CommandTimeout = 360000;
            dataContext.Transaction = dataContext.Connection.BeginTransaction();
            dataContext.TmpVentasErrors.InsertAllOnSubmit(lte);
            dataContext.SubmitChanges();
            dataContext.Transaction.Commit();
        }
        return errores;
    }
    public int Continuar()
    {
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {
            Table<TmpVentasError> tblError = dataContext.GetTable<TmpVentasError>();
            dataContext.TmpVentasErrors.DeleteAllOnSubmit(tblError);
            dataContext.SubmitChanges();
        }
        List<TmpVentas> lt = new List<TmpVentas>();
        List<TmpVentasError> lte = new List<TmpVentasError>();
        int errores = 0;
        foreach (TmpVentasError _te in RegistrosError)
        {
            string linea = _te.datos;
            
            string[] registro = LeeLinea(linea);
            if (registro.Length == campos)
            {
                TmpVentas t = GuardaCampoOK(registro);
                lt.Add(t);
            }
            else
            {
                errores++;
                if (errores >= this.errores)
                {
                    throw new Exception(string.Format("El archivo contiene más de {0} errores.", errores));
                }
                TmpVentasError tmpve = new TmpVentasError();
                tmpve.datos = linea;
                lte.Add(tmpve);
            }
        }
        RegistrosError.Clear();
        RegistrosError = lte;
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {
            dataContext.TmpVentas.InsertAllOnSubmit(lt);
            dataContext.SubmitChanges();
        }
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {
            dataContext.TmpVentasErrors.InsertAllOnSubmit(lte);
            dataContext.SubmitChanges();
        }
        return errores;
    }
    public bool Procesar()
    {
        return true;
    }
    public bool Cancelar()
    {
        try
        {
            using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
            {
                Table<TmpVentas> tblVentas = dataContext.GetTable<TmpVentas>();
                dataContext.TmpVentas.DeleteAllOnSubmit(tblVentas);
                Table<TmpVentasError> tblError = dataContext.GetTable<TmpVentasError>();
                dataContext.TmpVentasErrors.DeleteAllOnSubmit(tblError);
                dataContext.SubmitChanges();
            }
            File.Move(HttpContext.Current.Server.MapPath("carga/" + this._archivo), HttpContext.Current.Server.MapPath("carga/" + this._archivo + "_cancelado"));
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void CargaTmpVentasError()
    {
        RegistrosError = new List<TmpVentasError>();
        using (dataContext = new cargaDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {
            var tmperror = (from err in dataContext.TmpVentasErrors
                            select new { err.id, err.datos });
            foreach (var ca in tmperror.ToList())
            {
                TmpVentasError te = new TmpVentasError();
                te.id = ca.id;
                te.datos = ca.datos;
                RegistrosError.Add(te);
            }
        }
    }
    private string[] LeeLinea(string linea)
    {
        string[] registro = linea.Split(separador);
        return registro;
    }
    private TmpVentas GuardaCampoOK(string[] registro)
    {
        TmpVentas t = new TmpVentas();
        t.REGION_NAME = registro[0].Trim().Replace("'","").Replace("\"", "");
        t.MARKET_NAME = registro[1].Trim().Replace("'", "").Replace("\"", "");
        t.COUNTRY_NAME = registro[2].Trim().Replace("'", "").Replace("\"", "");
        t.DISTRIBUTOR_NAME = registro[3].Trim().Replace("'", "").Replace("\"", "");
        t.BRANCH_NAME = registro[4].Trim().Replace("'", "").Replace("\"", "");
        t.STORE_CODE = registro[5].Trim().Replace("'", "").Replace("\"", "");
        t.STORE_NAME = registro[6].Trim().Replace("'", "").Replace("\"", "");
        t.STORE_SUP_CODE = registro[7].Trim().Replace("'", "").Replace("\"", "");
        t.STORE_SUP_NAME = registro[8].Trim().Replace("'", "").Replace("\"", "");
        t.STORE_SALES_REP_CODE = registro[9].Trim().Replace("'", "").Replace("\"", "");
        t.STORE_SALES_REP_NAME = registro[10].Trim().Replace("'", "").Replace("\"", "");
        t.STORE_TRADE_CHANNEL = registro[11].Trim().Replace("'", "").Replace("\"", "");
        t.PRODUCT_DUN_CODE = registro[12].Trim().Replace("'", "").Replace("\"", "");
        t.PRODUCT_EAN_CODE = registro[13].Trim().Replace("'", "").Replace("\"", "");
        t.PRODUCT_DESCRIPTION = registro[14].Trim().Replace("'", "").Replace("\"", "");
        t.CATEGORY_DESCRIPTION = registro[15].Trim().Replace("'", "").Replace("\"", "");
        t.BRAND_DESCRIPTION = registro[16].Trim().Replace("'", "").Replace("\"", "");
        try
        {
            t.SALES_AMOUNT = double.Parse(registro[17].Trim().Replace("'", "").Replace("\"", "").Replace(".",","));
        }
        catch
        {
            t.SALES_AMOUNT = 0;
        }
        try
        {
            t.SALES_QUANTITY = double.Parse(registro[18].Trim().Replace("'", "").Replace("\"", "").Replace(".", ","));
        }
        catch
        {
            t.SALES_QUANTITY = 0;
        }
        t.PERIOD = registro[19].Trim().Replace("'", "").Replace("\"", "");
        return t;
    }
    private bool GuardaCampoOK(TmpVentas registro, csDataBase database)
    {
        database.Query = "sp_inserta_tmp_venta";
        database.EsStoreProcedure = true;
        List<SqlParameter> param = new List<SqlParameter>();
        param.Add(new SqlParameter("@REGION_NAME", registro.REGION_NAME));
        param.Add(new SqlParameter("@MARKET_NAME", registro.MARKET_NAME));
        param.Add(new SqlParameter("@COUNTRY_NAME", registro.COUNTRY_NAME));
        param.Add(new SqlParameter("@DISTRIBUTOR_NAME", registro.DISTRIBUTOR_NAME));
        param.Add(new SqlParameter("@BRANCH_NAME", registro.BRANCH_NAME));
        param.Add(new SqlParameter("@STORE_CODE", registro.STORE_CODE));
        param.Add(new SqlParameter("@STORE_NAME", registro.STORE_NAME));
        param.Add(new SqlParameter("@STORE_SUP_CODE", registro.STORE_SUP_CODE));
        param.Add(new SqlParameter("@STORE_SUP_NAME", registro.STORE_SUP_NAME));
        param.Add(new SqlParameter("@STORE_SALES_REP_CODE", registro.STORE_SALES_REP_CODE));
        param.Add(new SqlParameter("@STORE_SALES_REP_NAME", registro.STORE_SALES_REP_NAME));
        param.Add(new SqlParameter("@STORE_TRADE_CHANNEL", registro.STORE_TRADE_CHANNEL));
        param.Add(new SqlParameter("@PRODUCT_DUN_CODE", registro.PRODUCT_DUN_CODE));
        param.Add(new SqlParameter("@PRODUCT_EAN_CODE", registro.PRODUCT_EAN_CODE));
        param.Add(new SqlParameter("@PRODUCT_DESCRIPTION", registro.PRODUCT_DESCRIPTION));
        param.Add(new SqlParameter("@CATEGORY_DESCRIPTION", registro.CATEGORY_DESCRIPTION));
        param.Add(new SqlParameter("@BRAND_DESCRIPTION", registro.BRAND_DESCRIPTION));
        try
        {
            param.Add(new SqlParameter("@SALES_AMOUNT", registro.SALES_AMOUNT));
        }
        catch
        {
            param.Add(new SqlParameter("@SALES_AMOUNT", 0));
        }
        try
        {
            param.Add(new SqlParameter("@SALES_QUANTITY", registro.SALES_QUANTITY));
        }
        catch
        {
            param.Add(new SqlParameter("@SALES_QUANTITY", 0));
        }
        param.Add(new SqlParameter("@PERIOD", registro.PERIOD));

        database.Parametros = param;
        try
        {
            database.acutualizaDatos();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
