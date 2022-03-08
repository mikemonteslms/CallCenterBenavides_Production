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
    public class DLClub
    {
        static string PROCEDURE_CLUB_OBTENERCATALOGO = "usp_ClubObtener";


        public static List<Club> ObtenerLista()
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            List<Club> Resultado = new List<Club>();

            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_CLUB_OBTENERCATALOGO;

                        command.CommandTimeout = 0;


                        var objReader = command.ExecuteReader();

                        while (objReader.Read())
                        {
                            Club obj = new Club();
                            obj.descripcion = objReader.ObtenerValor<string>("descripcion");
                            obj.FechaRegistro = objReader.ObtenerValor<DateTime>("FechaRegistro");
                            obj.id_club = objReader.ObtenerValor<int>("id_club");
                            obj.Prioridad = objReader.ObtenerValor<int>("Prioridad");
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
