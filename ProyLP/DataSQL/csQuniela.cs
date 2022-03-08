using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Security;
using System.Linq;

namespace CallCenterDB
{
    public static class csQuniela
    {
        private static csDataBase database;
        public static DataSet ObtieneQuniela(string fecha, int participanteID)
        {
            database = new csDataBase();
            List<SqlParameter> parametros = new List<SqlParameter>();
            if (fecha != string.Empty)
                parametros.Add(new SqlParameter("@fecha", fecha));
            if (participanteID != 0)
                parametros.Add(new SqlParameter("@participante_id", participanteID));
            return database.dsConsulta("sp_consulta_quiniela", parametros, true);
        }

        public static void InsertaQuniela(int participanteID, int partidoID, int golesLocal, int golesVisitante)
        {
            database = new csDataBase();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@participante_id", participanteID));
            parametros.Add(new SqlParameter("@partido_id", partidoID));
            parametros.Add(new SqlParameter("@goles_local", golesLocal));
            parametros.Add(new SqlParameter("@goles_visitante", golesVisitante));
            database.acutualizaDatos("sp_guarda_quiniela", parametros, true).ToString();
        }

        public static DataSet ObtienePartido(int partidoID)
        {
            database = new csDataBase();
            List<SqlParameter> parametros = new List<SqlParameter>();
            if (partidoID != 0)
                parametros.Add(new SqlParameter("@partido_id", partidoID));
            return database.dsConsulta("sp_consulta_partido", parametros, true);
        }

        public static void InsertaMarcador(int partidoID, int marcadorLocal, int marcadorVisitante)
        {
            database = new csDataBase();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@partido_id", partidoID));
            parametros.Add(new SqlParameter("@marcador_local", marcadorLocal));
            parametros.Add(new SqlParameter("@marcador_visitante", marcadorVisitante));
            database.acutualizaDatos("sp_actualiza_marcador", parametros, true).ToString();
        }

        public static void InsertaPartido(string grupo, string fecha, string horario, string local, string visitante, string sede, int marcador_local, int marcador_visitante)
        {
            database = new csDataBase();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@grupo", grupo));
            parametros.Add(new SqlParameter("@fecha", fecha));
            parametros.Add(new SqlParameter("@horario", horario));
            parametros.Add(new SqlParameter("@local", local));
            parametros.Add(new SqlParameter("@visitante", visitante));
            parametros.Add(new SqlParameter("@sede", sede));
            parametros.Add(new SqlParameter("@marcador_local", marcador_local));
            parametros.Add(new SqlParameter("@marcador_visitante", marcador_visitante));
            database.acutualizaDatos("sp_inserta_partido", parametros, true).ToString();            
        }
    }
}