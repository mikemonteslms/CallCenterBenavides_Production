using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Entidades;

namespace Datos
{
    public class DLPeriodo
    {
        static string PROCEDURE_PERIODO_OBTENERCATALOGO = "usp_PeriodoObtener";


        public static List<PeriodoM> ObtenerLista()
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            List<PeriodoM> Resultado = new List<PeriodoM>();

            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_PERIODO_OBTENERCATALOGO;

                        command.CommandTimeout = 0;


                        var objReader = command.ExecuteReader();

                        while (objReader.Read())
                        {
                            PeriodoM obj = new PeriodoM();
                            obj.Perido = objReader.ObtenerValor<string>("Perido");
                            obj.FechaRegistro = objReader.ObtenerValor<DateTime>("FechaRegistro");
                            obj.Id_Periodo = objReader.ObtenerValor<int>("Id_Periodo");
                            obj.Id_Status = objReader.ObtenerValor<int>("Id_Status");
                            Resultado.Add(obj);
                        }
                    }

                    return Resultado;
                }
                catch (SqlException sqlEx)
                {
                    throw new InvalidOperationException("No fue posible obtener la info del catalogo.", sqlEx);
                }
                finally
                {
                    cnn.Close();
                }
            }


        }
    }
}
