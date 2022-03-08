using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace CallCenterDB
{
    public class csPrograma : csParticipante
    {


        public void ActualizaHTMLPlantilla(int programa_id, string campo, string HTML)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@programa_id", programa_id));
            parametros.Add(new SqlParameter("@campo", campo));
            parametros.Add(new SqlParameter("@HTML", HTML));
            database = new csDataBase();
            if (this.conn != null)
            {
                database.Conexion = conn;
            }
            if (this.tran != null)
            {
                database.Transaccion = tran;
            }
            database.Query = "sp_actualiza_html_plantilla_programa";
            database.Parametros = parametros;
            database.EsStoreProcedure = true;
            database.acutualizaDatos();
        }
    }
}
