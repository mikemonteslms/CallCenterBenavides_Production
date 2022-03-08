using System;
using System.Data;
using Datos;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace Negocio
{
    public class AdministraPOS
    {
        public ModSucursales ValidaandObtenSucursal(string Sucursal)
        {
            DataSet DS = new DataSet();
            ModSucursales Respuesta = new ModSucursales();


            try
            {
                ArrayList lstParametros = new ArrayList();

                lstParametros.Add(new ParameterIn("@Sucursal", DbType.String, Sucursal.Trim()));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spObtenValidaSucursal", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            Respuesta.IdSucursal = Convert.ToInt32(DS.Tables[0].Rows[0][1].ToString());
                            Respuesta.CveSucursal = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return Respuesta;
        }
        public bool ValidaTarjeta(string strTarjeta)
        {
            DataSet DS = new DataSet();
            bool Respuesta = false;


            try
            {
                ArrayList lstParametros = new ArrayList();

                lstParametros.Add(new ParameterIn("@Tarjeta", DbType.String, strTarjeta.Trim()));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ValidaExistenciaTarjeta", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToInt32(DS.Tables[0].Rows[0]["Existe"].ToString()) > 0)
                            {
                                Respuesta = true;//Si Existe
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return Respuesta;
        }
        public List<ModProductosPOS> ValidaCodInterno(string CodInt)
        {
            DataSet DS = new DataSet();
            List<ModProductosPOS> lstRespuesta = new List<ModProductosPOS>();

            try
            {
                ArrayList lstParametros = new ArrayList();

                lstParametros.Add(new ParameterIn("@CodInt", DbType.String, CodInt.Trim()));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ValidaCodInterno", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rows in DS.Tables[0].Rows)
                            {
                                ModProductosPOS campos = new ModProductosPOS();

                                campos.IdProd = Convert.ToInt32(rows["IdProd"].ToString());
                                campos.CodigoBarras = rows["CodigoBarras"].ToString();
                                campos.CodigoInterno = rows["CodigoInterno"].ToString();
                                campos.NombreProducto = rows["NombreProducto"].ToString();

                                lstRespuesta.Add(campos);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return lstRespuesta;
        }

        public string ObtenerCotizacion(string Tarjeta, string NoTicket)
        {
            DataSet DS = new DataSet();
            string strRespuesta = "";


            try
            {
                ArrayList lstParametros = new ArrayList();

                lstParametros.Add(new ParameterIn("@Tarjeta", DbType.String, Tarjeta.Trim()));
                lstParametros.Add(new ParameterIn("@Noticket", DbType.String, NoTicket.Trim()));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenCotizacion", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strRespuesta = DS.Tables[0].Rows[0]["Cotizacion"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return strRespuesta;
        }

        public bool ValidaSKUMecanicaVigente(string CodInt)
        {
            DataSet DS = new DataSet();
            bool blnRespuesta = false;

            try
            {
                ArrayList lstParametros = new ArrayList();

                lstParametros.Add(new ParameterIn("@CodigoInterno", DbType.String, CodInt.Trim()));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_TieneMecanciaVigente", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow rows in DS.Tables[0].Rows)
                            {
                                if (rows[0].ToString() == "True")
                                {
                                    blnRespuesta = true;
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return blnRespuesta;
        }

    }
}
