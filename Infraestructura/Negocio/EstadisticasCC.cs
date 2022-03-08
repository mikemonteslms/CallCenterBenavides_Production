using System;
using System.Data;
using Datos;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace Negocio
{
    public class EstadisticasCC
    {
        public ModContenedorEstadisticas ObtenerTiemposPromedioPOS(string cnnDbase, string Anio, string Mes)
        {
            DataSet DS = new DataSet();
            ModContenedorEstadisticas contenedor = new ModContenedorEstadisticas();

            if (Anio == "Todos")
            {
                Anio = "";
            }

            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@Anio", DbType.String, Anio));
                lstParameters.Add(new ParameterIn("@Mes", DbType.String, Mes));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, "sp_ObtenerTiemposPromedioPOS", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "TiemposPromedioPOS");
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModMetodos campos = new ModMetodos();

                                campos.Metodo = reg["Metodo"].ToString();

                                contenedor.lstMetodos.Add(campos);
                            }
                        }

                        if (DS.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[1].Rows)
                            {
                                ModDiasX campos = new ModDiasX();

                                campos.Fecha = Convert.ToDateTime(reg["Fecha"].ToString());

                                contenedor.lstDias.Add(campos);
                            }
                        }

                        if (DS.Tables[2].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[2].Rows)
                            {
                                ModTiemposPromedioPOS campos = new ModTiemposPromedioPOS();

                                campos.Metodo = reg["Metodo"].ToString();
                                campos.Fecha = Convert.ToDateTime(reg["Fecha"].ToString());
                                campos.TiempoPromedio = Convert.ToInt32(reg["TiempoPromedio"].ToString());

                                contenedor.lstTiempoPromedio.Add(campos);
                            }
                        }


                        if (DS.Tables[3].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[3].Rows)
                            {
                                contenedor.YAxisMaxValue = Convert.ToInt32(reg["YAxisMaxValue"].ToString());
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return contenedor;
        }
        public List<ModAñosMeses> ObtenerAñosMeses(string cnnDbase, string Anios)
        {
            DataSet DS = new DataSet();
            List<ModAñosMeses> lstResultados = new List<ModAñosMeses>();

            if (Anios == "Todos")
            {
                Anios = "";
            }

            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@Anio", DbType.String, Anios));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings[cnnDbase].ConnectionString, "sp_ObntenAniosMeses", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "TiemposPromedioPOS");
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModAñosMeses campos = new ModAñosMeses();

                                campos.Año = reg["Anios"].ToString();
                                campos.AniosNum = Convert.ToInt32(reg["aniosnum"].ToString());
                                campos.Mes = reg["Meses"].ToString();
                                campos.MesNum = Convert.ToInt32(reg["mesnum"].ToString());

                                lstResultados.Add(campos);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultados;
        }
    }
}
