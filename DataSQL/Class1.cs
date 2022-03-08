using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.UI.WebControls;

namespace DataSQL
{
    public abstract class ClassPrincipal
    {
        public virtual void Open() { }
        public virtual void Close() { }
    }

    public class ClassDataSQL1 : ClassPrincipal
    {
        public String Stringconexion = ""; //ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public SqlConnection SqlConnection1 = null;

        public ClassDataSQL1()
        {
            //Open();
            if (Stringconexion == null || Stringconexion == "")
            {
                Stringconexion = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            }
        }
        public override void Open()
        {
            try
            {
                using (SqlConnection1 = new SqlConnection(Stringconexion))
                {
                    if (this.SqlConnection1.State.Equals(ConnectionState.Closed))
                    {
                        SqlConnection1.Open();
                    }
                }
            }
            catch (Exception ex)
            {
                //System.Console.WriteLine(ex.ToString());                
            }
        }
        public override void Close()
        {
            try
            {
                SqlConnection.ClearPool(SqlConnection1);
                SqlConnection1.Close();
                SqlConnection1.Dispose();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());

            }
        }
        public DataTable LlenaDatosDatatable(string NameStoreProcedure)
        {
            SqlCommand SqlCommand1 = null;
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection1 = new SqlConnection(Stringconexion))
                {
                    // SqlConnection1 = new SqlConnection(Stringconexion);
                    SqlCommand1 = new SqlCommand();
                    SqlCommand1.Connection = SqlConnection1;
                    SqlCommand1.CommandType = CommandType.StoredProcedure;
                    SqlCommand1.CommandText = NameStoreProcedure;
                    SqlCommand1.CommandTimeout = 600000;
                    if (this.SqlConnection1.State.Equals(ConnectionState.Closed))
                    {
                        SqlConnection1.Open();
                    }

                    table.Load(SqlCommand1.ExecuteReader());
                    Close();

                    return table;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public class DataAccess : DataAccessBase
        {

            protected string connection_string = "";
            protected SqlConnection connection = null;
            private static DataAccess instance = null;

            protected DataAccess(string connection_string)
                : base()
            {
                this.connection_string = connection_string;
            }

            public override void Open()
            {
                try
                {
                    connection = new SqlConnection(connection_string);
                    connection.Open();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                    Error = true;
                }
            }

            public override void Close()
            {
                try
                {
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                    Error = true;
                }
            }

            public override string Quote(string value)
            {
                if (null == value)
                    return "''";
                return "'" + value.Replace("'", "''") + "'";
            }

            public override string Quote(DateTime date)
            {
                string s = date.Year.ToString() + "-" + date.Month.ToString().PadLeft(2, '0') + "-" + date.Day.ToString().PadLeft(2, '0');

                return "'" + s + "'";
            }

            public override string Quote(bool value)
            {
                return (value ? "1" : "0");
            }

            public static bool IsNull(SqlDataReader dr, int ordinal)
            {
                return dr.IsDBNull(ordinal);
            }

            public static bool IsNull(SqlDataReader dr, string campo)
            {
                return IsNull(dr, dr.GetOrdinal(campo));
            }

            public static string GetString(SqlDataReader dr, int ordinal)
            {
                if (dr.IsDBNull(ordinal))
                    return "";

                return dr[ordinal].ToString();
                //return dr.GetString( ordinal ).ToString();
            }

            public static string GetString(SqlDataReader dr, string campo)
            {
                return GetString(dr, dr.GetOrdinal(campo));
            }

            public static int GetInteger(SqlDataReader dr, int ordinal)
            {
                if (dr.IsDBNull(ordinal))
                    return 0;
                return dr.GetInt32(ordinal);
            }

            public static int GetInteger(SqlDataReader dr, string campo)
            {
                return GetInteger(dr, dr.GetOrdinal(campo));
            }

            public static long GetLong(SqlDataReader dr, int ordinal)
            {
                if (dr.IsDBNull(ordinal))
                    return 0;
                return dr.GetInt64(ordinal);
            }

            public static long GetLong(SqlDataReader dr, string campo)
            {
                return GetLong(dr, dr.GetOrdinal(campo));
            }

            public static bool GetBoolean(SqlDataReader dr, int ordinal)
            {
                if (dr.IsDBNull(ordinal))
                    return false;
                return dr.GetBoolean(ordinal);
            }

            public static bool GetBoolean(SqlDataReader dr, string campo)
            {
                return GetBoolean(dr, dr.GetOrdinal(campo));
            }

            public static float GetFloat(SqlDataReader dr, int ordinal)
            {
                if (dr.IsDBNull(ordinal))
                    return 0.0f;
                return dr.GetFloat(ordinal);
            }

            public static float GetFloat(SqlDataReader dr, string campo)
            {
                return GetFloat(dr, dr.GetOrdinal(campo));
            }

            public static double GetDouble(SqlDataReader dr, int ordinal)
            {
                if (dr.IsDBNull(ordinal))
                    return 0.0;
                return dr.GetDouble(ordinal);
            }

            public static double GetDouble(SqlDataReader dr, string campo)
            {
                return GetDouble(dr, dr.GetOrdinal(campo));
            }

            public static decimal GetDecimal(SqlDataReader dr, int ordinal)
            {
                if (dr.IsDBNull(ordinal))
                    return 0.0m;
                return dr.GetDecimal(ordinal);
            }

            public static decimal GetDecimal(SqlDataReader dr, string campo)
            {
                return GetDecimal(dr, dr.GetOrdinal(campo));
            }

            public static DateTime GetDateTime(SqlDataReader dr, int ordinal)
            {
                if (dr.IsDBNull(ordinal))
                    return DateTime.Now;
                return dr.GetDateTime(ordinal);
            }

            public static DateTime GetDateTime(SqlDataReader dr, string campo)
            {
                return GetDateTime(dr, dr.GetOrdinal(campo));
            }

            private SqlDataAdapter ExecuteQueryAdapter(string sql)
            {
                try
                {
                    return new SqlDataAdapter(sql, connection);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                    Error = true;
                    return null;
                }
            }

            public DataSet ExecuteQuery(string sql, string tabla)
            {
                try
                {
                    SqlDataAdapter sa = ExecuteQueryAdapter(sql);
                    DataSet ds = new DataSet();

                    sa.Fill(ds, tabla);
                    return ds;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                    Error = true;
                    return null;
                }
            }

            public SqlDataReader ExecuteQuery(string sql)
            {
                SqlCommand command = null;

                try
                {
                    command = connection.CreateCommand();
                    command.CommandText = sql;
                    return command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    //System.Console.WriteLine(ex.ToString());
                    Error = true;
                    return null;
                }
                finally
                {
                    if (null != command)
                        command.Dispose();
                }
            }

            public SqlDataReader ExecuteQueryWithParameters(string sql, SqlParameter[] pars)
            {
                SqlCommand command = null;

                try
                {
                    command = connection.CreateCommand();
                    command.CommandText = sql;
                    foreach (SqlParameter par in pars)
                        command.Parameters.Add(par);
                    return command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    //System.Console.WriteLine(ex.ToString());
                    Error = true;
                    return null;
                }
                finally
                {
                    if (null != command)
                        command.Dispose();
                }
            }

            public DataTable ExecuteQueryTable(string sql)
            {
                try
                {
                    DataTable table = new DataTable();
                    SqlDataReader reader = ExecuteQuery(sql);

                    table.Load(reader);
                    CloseQuery(reader);
                    return table;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                    Error = true;
                    return null;
                }
            }


            public DataTable ExecuteQueryTable(string sql, string NameTable)
            {
                try
                {
                    DataTable table = new DataTable(NameTable);
                    SqlDataReader reader = ExecuteQuery(sql);

                    table.Load(reader);
                    CloseQuery(reader);
                    return table;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                    Error = true;
                    return null;
                }
            }

            public void ExecuteNonQuery(string sql)
            {
                SqlCommand command = null;

                try
                {
                    command = connection.CreateCommand();
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //System.Console.WriteLine(ex.ToString());
                    Error = true;
                }
                finally
                {
                    if (null != command)
                        command.Dispose();
                }
            }

            public void ExecuteNonQueryWithParameters(string sql, SqlParameter[] pars)
            {
                SqlCommand command = null;

                try
                {
                    command = connection.CreateCommand();
                    command.CommandText = sql;
                    foreach (SqlParameter par in pars)
                        command.Parameters.Add(par);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // System.Console.WriteLine(ex.ToString());
                    Error = true;
                }
                finally
                {
                    if (null != command)
                        command.Dispose();
                }
            }

            public object ExecuteScalar(string sql)
            {
                SqlCommand command = null;

                try
                {
                    command = connection.CreateCommand();
                    command.CommandText = sql;
                    return command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    //System.Console.WriteLine(ex.ToString());
                    Error = true;
                    return null;
                }
                finally
                {
                    if (null != command)
                        command.Dispose();
                }
            }

            public bool ExecuteNonQueryBool(string sql)
            {
                SqlCommand command = null;

                try
                {
                    command = connection.CreateCommand();
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    //System.Console.WriteLine(ex.ToString());
                    Error = true;
                    return false;
                }
                finally
                {
                    if (null != command)
                        command.Dispose();
                }
            }

            public string ExecuteQueryString(string sql, int ordinal)
            {
                try
                {
                    string valor = "";

                    SqlDataReader dr = ExecuteQuery(sql);
                    if (dr.Read())
                        valor = DataAccess.GetString(dr, ordinal);
                    CloseQuery(dr);
                    return valor;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                    Error = true;
                    return null;
                }
            }


            public bool ExecuteQueryBoolean(string sql, int ordinal)
            {
                try
                {
                    bool valor = false;

                    SqlDataReader dr = ExecuteQuery(sql);
                    if (dr.Read())
                        valor = DataAccess.GetBoolean(dr, ordinal);
                    CloseQuery(dr);
                    return valor;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                    Error = true;
                    return false;
                }
            }

            public int ExecuteQueryInteger(string sql, int ordinal)
            {
                try
                {
                    int valor = 0;

                    SqlDataReader dr = ExecuteQuery(sql);
                    if (dr.Read())
                        valor = DataAccess.GetInteger(dr, ordinal);
                    CloseQuery(dr);
                    return valor;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                    Error = true;
                    return -1;
                }
            }


            public string ExecuteQueryString(string sql, string campo)
            {
                try
                {
                    string valor = "";

                    SqlDataReader dr = ExecuteQuery(sql);
                    if (dr.Read())
                        valor = DataAccess.GetString(dr, campo);
                    CloseQuery(dr);
                    return valor;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                    Error = true;
                    return null;
                }
            }







            public int LastId(string t)
            {
                SqlDataReader dr = ExecuteQuery("SELECT IDENT_CURRENT( '" + t + "' )");

                //if ( !Error )
                if (dr.Read())
                {
                    int value = Convert.ToInt32(dr.GetDecimal(0));

                    CloseQuery(dr);
                    return value;
                }
                return 0;
            }

            public int NumRows(SqlDataReader dr)
            {
                return 0;
            }

            public void CloseQuery(SqlDataReader dr)
            {
                if (null != dr)
                {
                    dr.Close();
                    dr.Dispose();
                }
            }




            new public static DataAccess Instance
            {
                get
                {
                    if (null == instance)
                        instance = GetInstance();
                    return instance;
                }
            }





            new public static DataAccess GetInstance()
            {
                return GetConfigInstance("Rules");
            }



            new public static DataAccess GetConfigInstance(string connection)
            {
                return GetInstance(ConfigurationManager.ConnectionStrings[connection].ToString());
            }



            new public static DataAccess GetInstance(string connection_string)
            {
                DataAccess da = new DataAccess(connection_string);

                da.Open();
                return da;
            }

        }
        public abstract class DataAccessBase
        {

            private bool error = false;

            protected DataAccessBase()
            {
            }

            public virtual void Open()
            {
            }

            public virtual void Close()
            {
            }

            public virtual string Quote(string value)
            {
                return "";
            }

            public virtual string Quote(DateTime date)
            {
                return "";
            }

            public virtual string Quote(bool value)
            {
                return "";
            }

            protected bool Error
            {
                get { return error; }
                set { error = value; }
            }

            public bool GetError()
            {
                bool tmp = error;

                error = false;
                return tmp;
            }

            public static DataAccess Instance { get { return null; } }

            public static DataAccess GetInstance() { return null; }

            public static DataAccess GetConfigInstance(string connection) { return null; }

            public static DataAccess GetInstance(string connection_string) { return null; }

        }
        public DataSet LlenaDatosDataSet(string NameStoreProcedure, SqlParameter[] parmetros)
        {
            SqlCommand SqlCommand1 = null;
            DataSet table = new DataSet();
            try
            {
                using (SqlConnection1 = new SqlConnection(Stringconexion))
                {
                    SqlCommand1 = new SqlCommand();
                    SqlCommand1.Connection = SqlConnection1;
                    SqlCommand1.CommandType = CommandType.StoredProcedure;
                    SqlCommand1.CommandText = NameStoreProcedure;
                    SqlCommand1.CommandTimeout = 600000;
                    if (parmetros != null)
                    {
                        foreach (SqlParameter par in parmetros)
                            SqlCommand1.Parameters.Add(par);
                    }
                    if (this.SqlConnection1.State.Equals(ConnectionState.Closed))
                    {

                        SqlConnection1.Open();
                    }
                    SqlDataAdapter da = new SqlDataAdapter(SqlCommand1);
                    da.Fill(table);
                    SqlCommand1.Parameters.Clear();
                    Close();

                    return table;
                }
            }
            catch (Exception ex)
            {
                //Console.Write(ex.ToString());
                throw ex;
            }
            //finally
            //{
            //    if (null != SqlCommand1)
            //        SqlCommand1.Dispose();
            //    if (this.SqlConnection1.State.Equals(ConnectionState.Open))
            //    {
            //        Close();
            //    }
            //}
        }
        public DataSet LlenaDatosDataSet(string CnnDbase, string NameStoreProcedure, SqlParameter[] parmetros)
        {
            SqlCommand SqlCommand1 = null;
            DataSet table = new DataSet();
            try
            {
                using (SqlConnection1 = new SqlConnection(CnnDbase))
                {
                    SqlCommand1 = new SqlCommand();
                    SqlCommand1.Connection = SqlConnection1;
                    SqlCommand1.CommandType = CommandType.StoredProcedure;
                    SqlCommand1.CommandText = NameStoreProcedure;
                    SqlCommand1.CommandTimeout = 600000;
                    if (parmetros != null)
                    {
                        foreach (SqlParameter par in parmetros)
                            SqlCommand1.Parameters.Add(par);
                    }
                    if (this.SqlConnection1.State.Equals(ConnectionState.Closed))
                    {

                        SqlConnection1.Open();
                    }
                    SqlDataAdapter da = new SqlDataAdapter(SqlCommand1);
                    da.Fill(table);
                    SqlCommand1.Parameters.Clear();
                    Close();

                    return table;
                }
            }
            catch (Exception ex)
            {
                //Console.Write(ex.ToString());
                throw ex;
            }
            //finally
            //{
            //    if (null != SqlCommand1)
            //        SqlCommand1.Dispose();
            //    if (this.SqlConnection1.State.Equals(ConnectionState.Open))
            //    {
            //        Close();
            //    }
            //}

        }
        public DataSet LlenaDatosDataSet(string NameStoreProcedure)
        {
            SqlCommand SqlCommand1 = null;
            DataSet table = new DataSet();
            try
            {
                using (SqlConnection1 = new SqlConnection(Stringconexion))
                {
                    SqlCommand1 = new SqlCommand();
                    SqlCommand1.Connection = SqlConnection1;
                    SqlCommand1.CommandType = CommandType.StoredProcedure;
                    SqlCommand1.CommandText = NameStoreProcedure;
                    SqlCommand1.CommandTimeout = 600000;
                    //foreach (SqlParameter par in parmetros)
                    //    SqlCommand1.Parameters.Add(par);

                    if (this.SqlConnection1.State.Equals(ConnectionState.Closed))
                    {

                        SqlConnection1.Open();
                    }
                    SqlDataAdapter da = new SqlDataAdapter(SqlCommand1);
                    da.Fill(table);
                    SqlCommand1.Parameters.Clear();
                    Close();

                    return table;
                }
            }
            catch (Exception ex)
            {
                //Console.Write(ex.ToString());
                return null;
            }
            //finally
            //{
            //    if (null != SqlCommand1)
            //        SqlCommand1.Dispose();
            //    if (this.SqlConnection1.State.Equals(ConnectionState.Open))
            //    {
            //        Close();
            //    }
            //}
        }
        public int EjecutaStoreNonqueryint(string NameStoreProcedure, SqlParameter[] parmetros)
        {
            SqlCommand SqlCommand1 = null;
            try
            {
                using (SqlConnection1 = new SqlConnection(Stringconexion))
                {
                    SqlCommand1 = new SqlCommand();
                    SqlCommand1.Connection = SqlConnection1;
                    SqlCommand1.CommandType = CommandType.StoredProcedure;
                    SqlCommand1.CommandText = NameStoreProcedure;
                    SqlCommand1.CommandTimeout = 600000;
                    foreach (SqlParameter par in parmetros)
                        SqlCommand1.Parameters.Add(par);

                    if (this.SqlConnection1.State.Equals(ConnectionState.Closed))
                    {

                        SqlConnection1.Open();
                    }
                    int NoFiles = SqlCommand1.ExecuteNonQuery();
                    Close();

                    return NoFiles;
                }
            }
            catch (Exception ex)
            {
                //Console.Write(ex.ToString());
                return 0;
            }
            //finally
            //{
            //    if (null != SqlCommand1)
            //        SqlCommand1.Dispose();
            //    if (this.SqlConnection1.State.Equals(ConnectionState.Open))
            //    {
            //        Close();
            //    }
            //}
        }
        public int EjecutaStoreNonqueryint(string CnnDbase, string NameStoreProcedure, SqlParameter[] parmetros)
        {
            SqlCommand SqlCommand1 = null;
            try
            {
                using (SqlConnection1 = new SqlConnection(CnnDbase))
                {
                    SqlCommand1 = new SqlCommand();
                    SqlCommand1.Connection = SqlConnection1;
                    SqlCommand1.CommandType = CommandType.StoredProcedure;
                    SqlCommand1.CommandText = NameStoreProcedure;
                    SqlCommand1.CommandTimeout = 600000;
                    foreach (SqlParameter par in parmetros)
                        SqlCommand1.Parameters.Add(par);

                    if (this.SqlConnection1.State.Equals(ConnectionState.Closed))
                    {

                        SqlConnection1.Open();
                    }
                    int NoFiles = SqlCommand1.ExecuteNonQuery();
                    SqlConnection.ClearPool(SqlConnection1);
                    Close();

                    return NoFiles;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            //finally
            //{
            //    if (null != SqlCommand1)
            //        SqlCommand1.Dispose();
            //        SqlConnection.ClearPool(SqlConnection1);
            //    if (this.SqlConnection1.State.Equals(ConnectionState.Open))
            //    {
            //        Close();
            //    }
            //}
        }
    }
}
