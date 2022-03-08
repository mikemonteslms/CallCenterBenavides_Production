using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ORMModel;

namespace Datos
{
    public class DLCategoriaMecanica
    {
        static string PROCEDURE_CATEGORIAMECANICA_OBTENERCATALOGO = "usp_CategoriaMecanicaObtener";


        public static List<CategoriaMecanica> ObtenerLista()
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            List<CategoriaMecanica> Resultado = new List<CategoriaMecanica>();

            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_CATEGORIAMECANICA_OBTENERCATALOGO;

                        command.CommandTimeout = 0;


                        var objReader = command.ExecuteReader();

                        while (objReader.Read())
                        {
                            CategoriaMecanica obj = new CategoriaMecanica();
                            obj.Descripcion = objReader.ObtenerValor<string>("Descripcion");
                            obj.Estatus = objReader.ObtenerValor<int>("Estatus");
                            obj.FechaRegistro = objReader.ObtenerValor<DateTime>("FechaRegistro");
                            obj.id_categoriaMecanica = objReader.ObtenerValor<int>("id_categoriaMecanica");
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
