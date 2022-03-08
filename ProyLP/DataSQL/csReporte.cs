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

    public static class csReporte
    {
        private static csDataBase database;

        public static DataSet ObtieneReporteOperacion(string fechaInicio, string fechaFin, int programa, int tipoParticipante, int estatus, int distribuidor, string procedimiento, string usuario)
        {
            database = new csDataBase();
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@fecha_inicial", fechaInicio));


            parametros.Add(new SqlParameter("@fecha_final", fechaFin));

            if (programa != -1)
            {
                parametros.Add(new SqlParameter("@programa_id", programa));
            }
            if (tipoParticipante != -1)
            {
                parametros.Add(new SqlParameter("@tipo_participante_id", tipoParticipante));
            }
            if (estatus != -1)
            {
                parametros.Add(new SqlParameter("@status_participante_id", estatus));
            }
            if (distribuidor != -1)
            {
                parametros.Add(new SqlParameter("@distribuidor_id", distribuidor));
            }

            parametros.Add(new SqlParameter("@usuario_id", usuario));

            return database.dsConsulta(procedimiento, parametros, true);

        }

        public static DataSet ObtieneReporteAsignacion(string fecha,  int programa, int tipoReporte, string procedimiento, string usuario)
        {
            database = new csDataBase();
            List<SqlParameter> parametros = new List<SqlParameter>();


            parametros.Add(new SqlParameter("@mes", fecha));

          
                parametros.Add(new SqlParameter("@programa_id", programa));

                parametros.Add(new SqlParameter("@tipo_reporte_id", tipoReporte));
            
            return database.dsConsulta(procedimiento, parametros, true);

        }

        public static DataSet ObtieneCubo(string usuario, string procedimiento)
        {
            database = new csDataBase();
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@usuario_id", usuario));



            return database.dsConsulta(procedimiento, parametros, true);

        }
    }
}
