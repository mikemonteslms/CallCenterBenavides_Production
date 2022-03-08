using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public class csPais
{
    private string _ip;
    public csPais(string ip)
    {
        _ip = ip;
    }

    public string Pais(string direccion_ip)
    {
        string pais = "";
        string[] strBytes = direccion_ip.Split('.');
        try
        {
            uint numeroIP;
            try
            {
                numeroIP =
                            (uint.Parse(strBytes[0]) * 16777216) +
                            (uint.Parse(strBytes[1]) * 65536) +
                            (uint.Parse(strBytes[2]) * 256) +
                             uint.Parse(strBytes[3]);
            }
            catch
            {
                numeroIP = 0;
            }
            csDataBase database = new csDataBase();
            database.Query = "sp_consulta_pais_ip";
            List<SqlParameter> p = new List<SqlParameter>();
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@numero_ip";
            par.DbType = System.Data.DbType.Int64;
            par.Value = numeroIP;
            p.Add(par);
            database.Parametros = p;
            database.EsStoreProcedure = true;
            DataTable dt = database.dtConsulta();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                pais = dr["country_code2"].ToString().ToLower();
            }
            else
            {
                pais = "us";
            }            
        }
        catch
        {
            pais = "us";
        }
        return pais;
    }

    public string Pais()
    {
        return Pais(_ip);
    }
}