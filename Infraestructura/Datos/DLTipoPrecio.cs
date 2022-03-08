using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORMModel;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Datos
{
    public class DLTipoPrecio
    {
        static string PROCEDURE_TIPOPRECIO_OBTENERCATALOGO = "usp_TipoPrecioObtener";



        public static List<TipoPrecio> ObtenerLista()
        {
            var cnnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            List<TipoPrecio> Resultado = new List<TipoPrecio>();

            using (var cnn = new SqlConnection(cnnString))
            {
                cnn.Open();

                try
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = PROCEDURE_TIPOPRECIO_OBTENERCATALOGO;

                        command.CommandTimeout = 0;

                        var objReader = command.ExecuteReader();

                        while (objReader.Read())
                        {
                            TipoPrecio obj = new TipoPrecio();
                            obj.Descripcion = objReader.ObtenerValor<string>("Descripcion");
                            obj.id_Tipoprecio = objReader.ObtenerValor<int>("id_Tipoprecio");

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
