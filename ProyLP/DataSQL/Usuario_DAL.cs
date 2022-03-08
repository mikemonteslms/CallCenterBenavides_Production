using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using CallCenterDB.Linq;
using System.Linq;

public class Usuario_DAL
{
    public string strError = string.Empty;
    /// <strConnection>
    /// Cadena de Conexion
    /// </summary>
    /// <returns></returns>
    public string strConnection()
    {
        string strCadConection = string.Empty;
        strCadConection = ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString;
        return strCadConection;

    }


    private int _idUsuario;

	public Usuario_DAL()
	{
        
	}

    public DataSet leerOpciones(int codigo_distribuidor)
    {
       
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            conn.ConnectionString = strConnection();
            conn.Open();
            da.SelectCommand = new SqlCommand("spget_DatosT_ree", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@distributor_id", codigo_distribuidor);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        catch (SqlException ex)
        {
            string sqlException;
            sqlException = ex.ToString();

        }
        return null;


               
    }

	 public DataSet leerOpcionesParticipante(int participante_id)
    {

        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            conn.ConnectionString = strConnection();
            conn.Open();
            da.SelectCommand = new SqlCommand("spget_DatosT_ree_Participante", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@participante_id", participante_id);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        catch (SqlException ex)
        {
            string sqlException;
            sqlException = ex.ToString();
        }
        return null;
    }


    public List<csDistributor> LlenaComboDistribuidor(string pais)
    {
        List<csDistributor> dlista = new List<csDistributor>();
        try
        {
            csDistributor d = new csDistributor(pais);
            dlista = d.Consulta();
            return dlista;
        }
        catch (SqlException ex)
        {
            string sqlException;
            sqlException = ex.ToString();

        }
        return null;
    }

    public DataSet InactivarElementos(string nombre,string codigo,int nivel)
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            conn.ConnectionString = strConnection();
            conn.Open();
            da.SelectCommand = new SqlCommand("spSet_Inactivar_Elem_PG", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@nombre", nombre);
            da.SelectCommand.Parameters.Add("@codigo", codigo);
            da.SelectCommand.Parameters.Add("@nivel", nivel);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        catch (SqlException ex)
        {
            string sqlException;
            sqlException = ex.ToString();

        }
        return null;
    }


    public DataSet OBtieneSupervisores(int codigo_distribuidor)
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            conn.ConnectionString = strConnection();
            conn.Open();
            da.SelectCommand = new SqlCommand("spget_Supervisores", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@CodigoDistribuidor", codigo_distribuidor);           
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        catch (SqlException ex)
        {
            string sqlException;
            sqlException = ex.ToString();

        }
        return null;
    }
    public DataSet OBtieneSupervisores(int codigo_distribuidor, int codigo_gerente)
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            conn.ConnectionString = strConnection();
            conn.Open();
            da.SelectCommand = new SqlCommand("spget_Supervisores", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@CodigoDistribuidor", codigo_distribuidor);
            da.SelectCommand.Parameters.Add("@codigo_gerente", codigo_gerente);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        catch (SqlException ex)
        {
            string sqlException;
            sqlException = ex.ToString();

        }
        return null;
    }

    public DataSet ActualizaSupervisorVendedor(string listaVendedor,int codigo_supervisor,string id_distribuidor)
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            conn.ConnectionString = strConnection();
            conn.Open();
            da.SelectCommand = new SqlCommand("spset_Actualiza_Supervisor_Vendedor", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@ListVendedores", listaVendedor);
            da.SelectCommand.Parameters.Add("@CodigoSupervisor", codigo_supervisor);
            da.SelectCommand.Parameters.Add("@id_Distribuidor", id_distribuidor);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        catch (SqlException ex)
        {
            string sqlException;
            sqlException = ex.ToString();

        }
        return null;
    }


    public DataSet OBtieneGerentes(int codigo_distribuidor)
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            conn.ConnectionString = strConnection();
            conn.Open();
            da.SelectCommand = new SqlCommand("spget_Gerentes", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@CodigoDistribuidor", codigo_distribuidor);
           // da.SelectCommand.Parameters.Add("@id_gerente",id_gerente);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        catch (SqlException ex)
        {
            string sqlException;
            sqlException = ex.ToString();

        }
        return null;
    }

    public DataSet ActualizaGerenteSupervisor(string listaSupervisor, int codigo_gerente,string id_distribuidor)
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            conn.ConnectionString = strConnection();
            conn.Open();
            da.SelectCommand = new SqlCommand("spset_Actualiza_gerente_supervisor", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@ListSupervisores", listaSupervisor);
            da.SelectCommand.Parameters.Add("@CodigoGerente", codigo_gerente);
            da.SelectCommand.Parameters.Add("@id_Distribuidor", id_distribuidor);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        catch (SqlException ex)
        {
            string sqlException;
            sqlException = ex.ToString();

        }
        return null;
    }

    /// <ActualizaGerenteSupervisorInactivo>
    /// Actualiza con un nuevo gerente los subelementos del gerente que se va a dejar inactivo
    /// </summary>
    /// <param name="listaSupervisor"></param>
    /// <param name="codigo_gerente"></param>
    /// <param name="id_distribuidor"></param>
    /// <returns></returns>
    public DataSet ActualizaGerenteSupervisorInactivo(string id_gerente_nuevo, string codigo_gerente, string id_distribuidor)
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            conn.ConnectionString = strConnection();
            conn.Open();
            da.SelectCommand = new SqlCommand("spset_Actualiza_Supervisor_Gerente_Inactivo", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id_Gerente_nuevo", id_gerente_nuevo);
            da.SelectCommand.Parameters.Add("@CodigoGerente", codigo_gerente);
            da.SelectCommand.Parameters.Add("@id_Distribuidor", id_distribuidor);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        catch (SqlException ex)
        {
            string sqlException;
            sqlException = ex.ToString();

        }
        return null;
    }

    public DataSet GetEStatusNodo(string id_codigo, string tipo_nodo, string id_distribuidor)
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            conn.ConnectionString = strConnection();
            conn.Open();
            da.SelectCommand = new SqlCommand("spget_EstatusNodo", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id_Codigo", id_codigo);
            da.SelectCommand.Parameters.Add("@tipo_nodo", tipo_nodo);
            da.SelectCommand.Parameters.Add("@id_Distribuidor", id_distribuidor);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        catch (SqlException ex)
        {
            string sqlException;
            sqlException = ex.ToString();

        }
        return null;
    }


    public DataSet ActivarElementos(string nombre, string codigo, int nivel)
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            conn.ConnectionString = strConnection();
            conn.Open();
            da.SelectCommand = new SqlCommand("spSet_Activar_Elem_PG", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@nombre", nombre);
            da.SelectCommand.Parameters.Add("@codigo", codigo);
            da.SelectCommand.Parameters.Add("@nivel", nivel);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        catch (SqlException ex)
        {
            string sqlException;
            sqlException = ex.ToString();

        }
        return null;
    }
    public int ActualizaJerarquiaParticipantes(string participante_id, string gerente_id, string supervisor_id, string puesto_id, string distribuidor_id, string usuario_id)
    {
        csDataBase database;
        int error = 0;
        string[] p_id = participante_id.Split(',');

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {
            conn.Open();
            
            using (SqlTransaction tran = conn.BeginTransaction("jerarquia"))
            {
                try
                {
                    database = new csDataBase(conn, tran);
                    database.Query = "sp_actualiza_jerarquia2";
                    database.EsStoreProcedure = true;
                    foreach (string _p in p_id)
                    {
                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@participante_id", _p));
                        if (gerente_id != "0")
                        {
                            param.Add(new SqlParameter("@gerente_id", gerente_id));
                        }
                        if (supervisor_id != "0")
                        {
                            param.Add(new SqlParameter("@supervisor_id", supervisor_id));
                        }
                        param.Add(new SqlParameter("@tipo_participante_id", puesto_id));
                        param.Add(new SqlParameter("@distribuidor_id", distribuidor_id));
                        param.Add(new SqlParameter("@usuario_id", usuario_id));
                        database.Parametros = param;
                        error += Convert.ToInt32(database.consultaDato());
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback("jerarquia");
                    throw ex;
                }
            }
        }
        return error;
    }

    public DataSet Obtiene_Gerente_Especifico(int codigo_distribuidor,int Supervisor_id)
    {
        SqlConnection conn = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            conn.ConnectionString = strConnection();
            conn.Open();
            da.SelectCommand = new SqlCommand("sp_Consulta_Gerente", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@CodigoDistribuidor", codigo_distribuidor);
            da.SelectCommand.Parameters.Add("@id_supervisor", Supervisor_id);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        catch (SqlException ex)
        {
            string sqlException;
            sqlException = ex.ToString();

        }
        return null;
    }

    public int ConsultaIdNenhum(string gerente)
    {
        int IdNenhum = 0;
        using (PremiosBRDataContext context = new PremiosBRDataContext(ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString))
        {

            try
            {
                var query = (from p in context.participante
                             from c in context.tmp_fuerza_ventas.Where(_c => _c.gerente_id == p.id)                             
                             where p.nombre.Contains(gerente)
                             select new
                             {
                                 IdNehum = p.id != null ? p.id : 0,
                                 

                             }).ToList().FirstOrDefault();

                IdNenhum =Convert.ToInt32(query.IdNehum);
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                IdNenhum= 0;
            }
        }
        return IdNenhum;
    }

}