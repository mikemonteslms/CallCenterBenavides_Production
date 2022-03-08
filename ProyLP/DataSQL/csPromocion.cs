using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


public class csPromocion
{


    protected csDataBase database;
    protected List<SqlParameter> parametros;

    private int promocion_id;

    public int Promocion_ID
    {
        get { return promocion_id; }
        set { promocion_id = value; }
    }

    public DataTable ConsultaPromocion_Detalle()
    {
        parametros = new List<SqlParameter>();
        string sp = "sp_consulta_promociones_detalle";
        parametros.Add(new SqlParameter("@promocion_id", promocion_id)); 
        database = new csDataBase();
        return database.dtConsulta(sp,parametros, true);
    }

}
