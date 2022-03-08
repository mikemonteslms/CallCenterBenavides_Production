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
    public class DLStatus
    {
        static string PROCEDURE_STATUS_OBTENERCATALOGO = "usp_StatusObtener";


        public static List<Status> ObtenerLista()
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            List<Status> Resultado = new List<Status>();

            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_STATUS_OBTENERCATALOGO;

                        command.CommandTimeout = 0;


                        var objReader = command.ExecuteReader();

                        while (objReader.Read())
                        {
                            Status obj = new Status();
                            obj.Descripcion = objReader.ObtenerValor<string>("Status");
                            obj.Id_status = objReader.ObtenerValor<int>("Id_status");
                            obj.Activo = objReader.ObtenerValor<bool>("Activo");

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
