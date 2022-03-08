using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI;

public class csDataBase
{
    private string query;
    private SqlConnection sqlConnection;
    private SqlTransaction sqlTran;
    private SqlCommand sqlCommand = null;
    private string connectionString;
    private List<SqlParameter> param;
    private bool esProc;

    public csDataBase()
    {
        connectionString = ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;
    }

    public csDataBase(SqlConnection conn, SqlTransaction tran)
    {
        this.sqlConnection = conn;
        this.sqlTran = tran;
    }

    public string Query
    {
        set { query = value; }
    }

    public SqlConnection Conexion
    {
        set { sqlConnection = value; }
    }

    public SqlTransaction Transaccion
    {
        set { sqlTran = value; }
    }

    public List<SqlParameter> Parametros
    {
        set { param = value; }
    }

    public bool EsStoreProcedure
    {
        set { esProc = value; }
    }

    //public SqlDataReader drConsulta()
    //{
    //    SqlDataReader sqlDataReader = null;
    //    try
    //    {
    //        if (sqlConnection == null)
    //        {
    //            sqlConnection = new SqlConnection(connectionString);
    //        }
    //        sqlCommand = new SqlCommand(query, sqlConnection);
    //        if (param != null)
    //        {
    //            foreach (SqlParameter p in param)
    //            {
    //                sqlCommand.Parameters.Add(p);
    //            }
    //        }
    //        sqlCommand.CommandTimeout = 600000;
    //        if (esProc != null && esProc == true)
    //        {
    //            sqlCommand.CommandType = CommandType.StoredProcedure;
    //        }
    //        if (sqlTran != null)
    //        {
    //            sqlCommand.Transaction = sqlTran;
    //        }
    //        if (this.sqlConnection.State.Equals(ConnectionState.Closed))
    //        {
    //            sqlConnection.Open();
    //        }
    //        sqlDataReader = sqlCommand.ExecuteReader();
    //        sqlCommand.Parameters.Clear();
    //    }
    //    catch { }
    //    finally
    //    {
    //        if (null != sqlCommand)
    //            sqlCommand.Dispose();
    //        if (this.sqlConnection.State.Equals(ConnectionState.Open))
    //        {
    //            sqlConnection.Close();
    //        }
    //    }
    //    return sqlDataReader;
    //}

    //public SqlDataReader drConsulta(string query, bool esSP)
    //{
    //    SqlDataReader sqlDataReader = null;
    //    try
    //    {
    //        sqlConnection = new SqlConnection(connectionString);
    //        sqlCommand = new SqlCommand(query, sqlConnection);
    //        sqlCommand.CommandTimeout = 600000;
    //        if (esSP)
    //        {
    //            sqlCommand.CommandType = CommandType.StoredProcedure;
    //        }
    //        if (this.sqlConnection.State.Equals(ConnectionState.Closed))
    //        {
    //            sqlConnection.Open();
    //        }
    //        sqlDataReader = sqlCommand.ExecuteReader();
    //    }
    //    catch { }
    //    finally
    //    {
    //        if (null != sqlCommand)
    //            sqlCommand.Dispose();
    //        if (this.sqlConnection.State.Equals(ConnectionState.Open))
    //        {
    //            sqlConnection.Close();
    //        }
    //    }
    //    return sqlDataReader;
    //}

    //public SqlDataReader drConsulta(string query, List<SqlParameter> parametros, bool esSP)
    //{
    //    SqlDataReader sqlDataReader = null;
    //    try
    //    {
    //        sqlConnection = new SqlConnection(connectionString);
    //        sqlCommand = new SqlCommand(query, sqlConnection);
    //        foreach (SqlParameter p in parametros)
    //        {
    //            sqlCommand.Parameters.Add(p);
    //        }
    //        sqlCommand.CommandTimeout = 600000;
    //        if (esSP)
    //        {
    //            sqlCommand.CommandType = CommandType.StoredProcedure;
    //        }
    //        if (this.sqlConnection.State.Equals(ConnectionState.Closed))
    //        {
    //            sqlConnection.Open();
    //        }
    //        sqlDataReader = sqlCommand.ExecuteReader();
    //        sqlCommand.Parameters.Clear();
    //    }
    //    catch { }
    //    finally
    //    {
    //        if (null != sqlCommand)
    //            sqlCommand.Dispose();
    //        if (this.sqlConnection.State.Equals(ConnectionState.Open))
    //        {
    //            sqlConnection.Close();
    //        }
    //    }
    //    return sqlDataReader;
    //}

    public DataTable dtConsulta()
    {
        DataTable dt = new DataTable();
        try
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection(connectionString);
            }
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.CommandTimeout = 600000;
            if (esProc != null && esProc == true)
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            if (param != null)
            {
                foreach (SqlParameter p in param)
                {
                    sqlCommand.Parameters.Add(p);
                }
            }
            if (sqlTran != null)
            {
                sqlCommand.Transaction = sqlTran;
            }
            sqlCommand.CommandTimeout = 600000;
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);
            sqlCommand.Parameters.Clear();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return dt;
    }

    public DataTable dtConsulta(string query, bool esSP)
    {
        DataTable dt = new DataTable();
        try
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.CommandTimeout = 600000;
            if (esSP)
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            dt = new DataTable();
            da.Fill(dt);
        }
        catch (Exception ex)
        { 
            throw new Exception(ex.Message); 
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return dt;
    }

    public DataTable dtConsulta(string query, List<SqlParameter> parametros, bool esSP)
    {
        DataTable dt = new DataTable();
        try
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.CommandTimeout = 600000;
            if (esSP)
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            foreach (SqlParameter p in parametros)
            {
                sqlCommand.Parameters.Add(p);
            }
            sqlCommand.CommandTimeout = 600000;
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);
            sqlCommand.Parameters.Clear();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return dt;
    }

    public DataSet dsConsulta()
    {
        DataSet ds = new DataSet();
        try
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection(connectionString);
            }
            sqlCommand = new SqlCommand(query, sqlConnection);
            if (esProc != null && esProc == true)
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            if (param != null)
            {
                foreach (SqlParameter p in param)
                {
                    sqlCommand.Parameters.Add(p);
                }
            }
            sqlCommand.CommandTimeout = 600000;
            if (sqlTran != null)
            {
                sqlCommand.Transaction = sqlTran;
            }
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(ds);
            sqlCommand.Parameters.Clear();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return ds;
    }

    public DataSet dsConsulta(string query, bool esSP)
    {
        DataSet ds = new DataSet();
        try
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.CommandTimeout = 600000;
            if (esSP)
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return ds;
    }

    public DataSet dsConsulta(string query, List<SqlParameter> parametros, bool esSP)
    {
        DataSet ds = new DataSet();
        try
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand(query, sqlConnection);
            if (esSP)
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            foreach (SqlParameter p in parametros)
            {
                sqlCommand.Parameters.Add(p);
            }
            sqlCommand.CommandTimeout = 600000;
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(ds);
            sqlCommand.Parameters.Clear();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return ds;
    }

    public void closeSqlConnection()
    {
        if (this.sqlConnection != null)
        {
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
                SqlConnection.ClearPool(sqlConnection);
            }
        }
        sqlConnection = null;
    }

    public object consultaDato()
    {
        object obj = new object();
        try
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection(connectionString);
            }
            sqlCommand = new SqlCommand(query, sqlConnection);
            if (esProc != null && esProc == true)
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            if (param != null)
            {
                foreach (SqlParameter p in param)
                {
                    sqlCommand.Parameters.Add(p);
                }
            }
            if (sqlTran != null)
            {
                sqlCommand.Transaction = sqlTran;
            }
            sqlCommand.CommandTimeout = 600000;
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            obj = sqlCommand.ExecuteScalar();
            sqlCommand.Parameters.Clear();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return obj;
    }

    public object consultaDato(string query, bool esSP)
    {
        object obj = new object();
        try
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand(query, sqlConnection);
            if (esSP)
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            sqlCommand.CommandTimeout = 600000;
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            obj = sqlCommand.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return obj;
    }

    public object consultaDato(string query, List<SqlParameter> parametros, bool esSP)
    {
        object obj = new object();
        try
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand(query, sqlConnection);
            if (esSP)
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            foreach (SqlParameter p in parametros)
            {
                sqlCommand.Parameters.Add(p);
            }
            sqlCommand.CommandTimeout = 600000;
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            obj = sqlCommand.ExecuteScalar();
            sqlCommand.Parameters.Clear();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return obj;
    }

    public int acutualizaDatos(string query, bool esSP)
    {
        int registrosActualizados = 0;
        try
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.CommandTimeout = 600000;
            if (esSP)
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            registrosActualizados = sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return registrosActualizados;
    }

    public int acutualizaDatos()
    {
        int registrosActualizados = 0;
        try
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection(connectionString);
            }
            sqlCommand = new SqlCommand(query, sqlConnection);
            if (param != null)
            {
                foreach (SqlParameter p in param)
                {
                    sqlCommand.Parameters.Add(p);
                }
            }
            sqlCommand.CommandTimeout = 600000;
            if (esProc != null && esProc == true)
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            if (sqlTran != null)
            {
                sqlCommand.Transaction = sqlTran;
            }
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            registrosActualizados = sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return registrosActualizados;
    }

    public int acutualizaDatos(string query, List<SqlParameter> parametros, bool esSP)
    {
        int registrosActualizados = 0;
        try
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand(query, sqlConnection);
            foreach (SqlParameter p in parametros)
            {
                sqlCommand.Parameters.Add(p);
            }
            sqlCommand.CommandTimeout = 600000;
            if (esSP)
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
            }
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            registrosActualizados = sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return registrosActualizados;
    }

    public object execSPUpdate(string output)
    {
        object salida=null;
        try
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection(connectionString);
            }
            sqlCommand = new SqlCommand(query, sqlConnection);
            foreach (SqlParameter p in param)
            {
                if (p.ToString() == output)
                {
                    p.Direction = ParameterDirection.Output;
                }
                sqlCommand.Parameters.Add(p);
            }
            sqlCommand.CommandTimeout = 600000;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            if (sqlTran != null)
            {
                sqlCommand.Transaction = sqlTran;
            }
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            sqlCommand.ExecuteNonQuery();
            salida = sqlCommand.Parameters[output].Value;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return salida;
    }

    public object execSPUpdate(string query, List<SqlParameter> parametros, string output)
    {
        object salida=null;
        try
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand(query, sqlConnection);
            foreach (SqlParameter p in parametros)
            {
                if (p.ToString() == output)
                {
                    p.Direction = ParameterDirection.Output;
                }
                sqlCommand.Parameters.Add(p);
            }
            sqlCommand.CommandTimeout = 600000;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            if (this.sqlConnection.State.Equals(ConnectionState.Closed))
            {
                sqlConnection.Open();
            }
            sqlCommand.ExecuteNonQuery();
            salida = sqlCommand.Parameters[output].Value;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            if (null != sqlCommand)
                sqlCommand.Dispose();
            if (this.sqlConnection.State.Equals(ConnectionState.Open))
            {
                sqlConnection.Close();
            }
        }
        return salida;
    }
}
