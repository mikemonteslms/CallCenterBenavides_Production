using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ORMModel;
using System.Data;
using System.Configuration;
using Entidades;

namespace Datos
{
    public class DLNivel
    {
        static string PROCEDURE_NIVEL_OBTENERCATALOGO = "usp_NivelObtener";


        public static List<Nivel> ObtenerLista()
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            List<Nivel> Resultado = new List<Nivel>();

            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_NIVEL_OBTENERCATALOGO;

                        command.CommandTimeout = 0;


                        var objReader = command.ExecuteReader();

                        while (objReader.Read())
                        {
                            Nivel obj = new Nivel();
                            obj.Descripcion = objReader.ObtenerValor<string>("Descripcion");
                            obj.IdNivel = objReader.ObtenerValor<int>("IdNivel");

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
