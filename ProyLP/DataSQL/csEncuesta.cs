using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CallCenterDB.Linq;
public class csEncuesta
{
    protected csDataBase database;
    protected List<SqlParameter> parametros;
    protected SqlConnection conn;
    protected SqlTransaction tran;
    private string id;
    private string usuario_id;
    private string agenda_id;
    private string encuesta_id;
    private string tipo_telefono_id;
    private string status_id;
    private string participante_id;
    public string ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public string UsuarioID
    {
        set
        {
            usuario_id = value;
        }
    }
    public string AgendaID
    {
        set
        {
            agenda_id = value;
        }
    }
    public string EncuestaID
    {
        get
        {
            return encuesta_id;
        }
        set
        {
            encuesta_id = value;
        }
    }
    public string TipoTelefonoID
    {
        set
        {
            tipo_telefono_id = value;
        }
    }
    public string StatusID
    {
        set
        {
            status_id = value;
        }
    }
    public string ParticipanteID
    {
        get
        {
            return participante_id;
        }
        set
        {
            participante_id = value;
        }
    }
    public DataTable Obtiene_Participante_Encuesta()
    {
        string Datos = "Obtiene_Participante_Encuesta";
        database = new csDataBase();
        parametros = new List<SqlParameter>();
        parametros.Add(new SqlParameter("@encuesta_id", id));
        return database.dtConsulta(Datos, parametros, true);
    }

    public void InsertaHistorico()
    {
        csDataBase query = new csDataBase();
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("@agenda_encuestas_id", encuesta_id));
        parameters.Add(new SqlParameter("@participante_id", participante_id));        
        parameters.Add(new SqlParameter("@status_llamada_id", status_id));
        parameters.Add(new SqlParameter("@tipo_telefono_id", tipo_telefono_id));
        query.acutualizaDatos("sp_inserta_historico_encuesta", parameters, true);
    }
}

