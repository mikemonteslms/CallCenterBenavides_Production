using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

namespace Negocio
{
    public class Cupones
    {
        public static Result InsertaCupon(string Cupon, string IdPromo, string Nombre, string Mensaje, int Sucursal, int Estatus, int UsoUnico, int NumAsignaciones,
                        DateTime fechaSolicitud, DateTime? fechaFin, string Usuario, DateTime FechaAlta, int IdTipoCupon, string Identificador, int CuponesDisponibles, string DescEcommerce, string URL)
        {
            Result objResul = new Result();
            DateTime dtFechaFin;
            dtFechaFin = (DateTime)fechaFin;
            string strFechaFin = "";

            try
            {

                strFechaFin = dtFechaFin.Year.ToString() + dtFechaFin.Month.ToString("00") + dtFechaFin.Day.ToString("00") + " 23:59:59";

                #region Paramtros

                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("Cupon", DbType.String, Cupon));
                listParameters.Add(new ParameterIn("IdPromo", DbType.String, IdPromo));
                listParameters.Add(new ParameterIn("Nombre", DbType.String, Nombre));
                listParameters.Add(new ParameterIn("Mensaje", DbType.String, Mensaje));
                listParameters.Add(new ParameterIn("Sucursal", DbType.Int32, Sucursal));
                listParameters.Add(new ParameterIn("Estatus", DbType.Int32, Estatus));
                listParameters.Add(new ParameterIn("UsoUnico", DbType.Binary, Convert.ToBoolean(UsoUnico)));
                listParameters.Add(new ParameterIn("NumAsignaciones", DbType.Int32, NumAsignaciones));
                listParameters.Add(new ParameterIn("FechaSolicitud", DbType.DateTime, fechaSolicitud));
                listParameters.Add(new ParameterIn("FechaFin", DbType.DateTime, strFechaFin));
                listParameters.Add(new ParameterIn("Usuario", DbType.String, Usuario));
                listParameters.Add(new ParameterIn("FechaAlta", DbType.DateTime, FechaAlta));
                listParameters.Add(new ParameterIn("@IdTipocupon", DbType.Int32, IdTipoCupon));
                listParameters.Add(new ParameterIn("@Identificador", DbType.String, Identificador));
                listParameters.Add(new ParameterIn("@CuponesDisponibles", DbType.Int32, CuponesDisponibles));
                listParameters.Add(new ParameterIn("@DescEcommerce", DbType.String, DescEcommerce));
                listParameters.Add(new ParameterIn("@URL", DbType.String, URL));
                #endregion

                //bool UsoUnico, int NumAsignaciones,
                //           DateTime fechaSolicitud, DateTime fechaFin, string Usuario, DateTime FechaAlta
                using (DataSet dtsDatos = Datos.DataBase.ExecuteDataSet(null, "SP_InsertaCupon", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn))))
                {

                    if (dtsDatos.Tables.Count > 0)
                    {
                        if (dtsDatos.Tables.Count == 2)
                        {
                            if (dtsDatos.Tables[0].Rows.Count > 0)
                            {
                                objResul.Error = dtsDatos.Tables[0].Rows[0]["Error"].ToString();
                                objResul.ErrorCode = dtsDatos.Tables[0].Rows[0]["ErrorCode"].ToString();
                            }

                            if (dtsDatos.Tables[1].Rows.Count > 0)
                            {
                                objResul.Error = objResul.Error + "-" + dtsDatos.Tables[1].Rows[0][0].ToString();
                            }
                        }

                        if (dtsDatos.Tables.Count == 1)
                        {
                            if (dtsDatos.Tables[0].Rows.Count > 0)
                            {
                                objResul.Error = dtsDatos.Tables[0].Rows[0]["Error"].ToString();
                                objResul.ErrorCode = dtsDatos.Tables[0].Rows[0]["ErrorCode"].ToString();
                            }
                        }
                    }


                }

                return objResul;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool InsertaCuponProdDescuento(int IdCupon, int IdCodigoInterno, int Descuento)
        {
            bool blnRespuesta = false;

            #region Paramtros

            ArrayList listParameters = new ArrayList();

            try
            {



                listParameters.Add(new ParameterIn("@id_cupon", DbType.Int32, IdCupon));
                listParameters.Add(new ParameterIn("@id_CodigoInterno", DbType.Int32, IdCodigoInterno));
                listParameters.Add(new ParameterIn("@Descuento", DbType.Int32, Descuento));

                #endregion
                int intResult = 0;
                intResult = Datos.DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_RegistraCuponProdDescuento", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

                if (intResult > 0)
                {
                    blnRespuesta = true;
                }

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object BusquedaCupon(string Valor)
        {
            ArrayList listParameters = new ArrayList();

            if (!string.IsNullOrEmpty(Valor))
                listParameters.Add(new ParameterIn("Cupon", DbType.String, Valor));

            DataTable tblDatos = DataBase.ExecuteDataSet(null, "SP_BusquedaCupon", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn))).Tables[0];

            return tblDatos;
        }

        public static DataTable ConsultarInfo(int IdCupon)
        {
            ArrayList listParameters = new ArrayList();

            listParameters.Add(new ParameterIn("IdCupon", DbType.Int32, IdCupon));

            DataTable tblDatos = DataBase.ExecuteDataSet(null, "SP_BuscarInfoCupon", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn))).Tables[0];

            return tblDatos;
        }

        public static Result ActualizaCupon(string ID, string Mensaje, string NombrePromo, string Sucursal, DateTime? FechaFin, int UnicoUso, string Asginacion, string UsuarioM, int IdTipocupon, string Identificador, int CuponesDisponibles, string strEcommerce, string URL)
        {
            Result objResul = new Result();
            DateTime dtFechaFin;
            dtFechaFin = (DateTime)FechaFin;
            string strFechaFin = "";

            strFechaFin = dtFechaFin.Year.ToString() + dtFechaFin.Month.ToString("00") + dtFechaFin.Day.ToString("00") + " 23:59:59";

            #region Paramtros

            ArrayList listParameters = new ArrayList();

            listParameters.Add(new ParameterIn("Id", DbType.Int32, ID));
            listParameters.Add(new ParameterIn("Nombre", DbType.String, NombrePromo));
            listParameters.Add(new ParameterIn("Mensaje", DbType.String, Mensaje));
            listParameters.Add(new ParameterIn("Sucursal", DbType.Int32, Sucursal));
            listParameters.Add(new ParameterIn("UsoUnico", DbType.Binary, Convert.ToBoolean(UnicoUso)));
            listParameters.Add(new ParameterIn("NumAsignaciones", DbType.Int32, Asginacion));
            listParameters.Add(new ParameterIn("FechaFin", DbType.DateTime, strFechaFin));
            listParameters.Add(new ParameterIn("UsuarioM", DbType.String, UsuarioM));
            listParameters.Add(new ParameterIn("FechaM", DbType.DateTime, DateTime.Now));
            listParameters.Add(new ParameterIn("@IdTipoCupon", DbType.Int32, IdTipocupon));
            listParameters.Add(new ParameterIn("@Identificador", DbType.String, Identificador));
            listParameters.Add(new ParameterIn("@CuponesDisponibles", DbType.Int32, CuponesDisponibles));
            listParameters.Add(new ParameterIn("@DescEcommerce", DbType.String, strEcommerce));
            listParameters.Add(new ParameterIn("@URL", DbType.String, URL));

            #endregion

            using (DataSet dtsDatos = Datos.DataBase.ExecuteDataSet(null, "SP_ActualizaCupon", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn))))
            {

                if (dtsDatos.Tables.Count > 0)
                {
                    objResul.Error = dtsDatos.Tables[0].Rows[0]["Error"].ToString();
                    objResul.ErrorCode = dtsDatos.Tables[0].Rows[0]["ErrorCode"].ToString();
                }
            }

            return objResul;
        }
        public static bool ActualizaCuponProdDescuento(int IdCupon, int codigointerno, int Descuento)
        {
            bool blnRespuesta = false;

            #region Paramtros

            ArrayList listParameters = new ArrayList();

            listParameters.Add(new ParameterIn("@Idcupon", DbType.Int32, IdCupon));
            listParameters.Add(new ParameterIn("@Idcodigointerno", DbType.Int32, codigointerno));
            listParameters.Add(new ParameterIn("@Descuento", DbType.Int32, Descuento));

            #endregion

            int intRespuesta = Datos.DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_ActualizaCuponProdDescuento", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));


            if (intRespuesta > 0)
            {
                blnRespuesta = true;
            }


            return blnRespuesta;
        }


        public static DataTable BuscarCupon(string Valor)
        {
            ArrayList listParameters = new ArrayList();

            listParameters.Add(new ParameterIn("@Valor", DbType.String, Valor));

            DataTable tblDatos = DataBase.ExecuteDataSet(null, "SP_BuscarCupon", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn))).Tables[0];

            return tblDatos;

        }

        public static List<ModSucursales> BuscarSucursales(string Sucursal)
        {
            List<ModSucursales> lstResultados = new List<ModSucursales>();
            ArrayList listParameters = new ArrayList();

            listParameters.Add(new ParameterIn("@filtro", DbType.String, Sucursal));
            DataSet DS = DataBase.ExecuteDataSet(null, "sp_catalogoSucursales", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn)));

            if (DS != null)
            {
                if (DS.Tables.Count > 0)
                {
                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow reg in DS.Tables[0].Rows)
                        {
                            ModSucursales campos = new ModSucursales();
                            campos.IdSucursal = Convert.ToInt32(reg[1]);
                            campos.Sucursal = reg[0].ToString();

                            lstResultados.Add(campos);
                        }
                    }
                }
            }
            return lstResultados;
        }

        public static Result AsignarCupon(string Tarjeta, string IdCupon, DateTime? FechaInicioCanje, DateTime? fechaFinCanje, string Sucursal, string UsoUnico, int NumeroAsignaciones, string Identificador, string UsuarioAlta)
        {
            Result objResul = new Result();
            string strFechaIni = "";
            string strFechaFin = "";

            strFechaIni = FechaInicioCanje.Value.Year.ToString() + FechaInicioCanje.Value.Month.ToString("00") + FechaInicioCanje.Value.Day.ToString("00") + " 00:00:00";
            strFechaFin = fechaFinCanje.Value.Year.ToString() + fechaFinCanje.Value.Month.ToString("00") + fechaFinCanje.Value.Day.ToString("00") + " 23:59:59";



            #region Paramtros
            //DateTime fechaFInal = new DateTime(fechaFinCanje.Value.Year, fechaFinCanje.Value.Month, fechaFinCanje.Value.Day, 23, 59, 59);

            ArrayList listParameters = new ArrayList();

            listParameters.Add(new ParameterIn("Tarjeta", DbType.String, Tarjeta));
            listParameters.Add(new ParameterIn("Id", DbType.Int32, IdCupon));
            listParameters.Add(new ParameterIn("FechaInicio", DbType.String, strFechaIni));
            listParameters.Add(new ParameterIn("FechaFin", DbType.String, strFechaFin));
            listParameters.Add(new ParameterIn("Sucursal", DbType.Int32, 0));
            listParameters.Add(new ParameterIn("NumeroAsignaciones", DbType.Int32, NumeroAsignaciones));

            if (UsoUnico.ToLower().Contains("un"))
                listParameters.Add(new ParameterIn("UsoUnico", DbType.Binary, 1));
            else
                listParameters.Add(new ParameterIn("UsoUnico", DbType.Binary, 0));

            listParameters.Add(new ParameterIn("Identificador", DbType.Int32, Identificador));
            listParameters.Add(new ParameterIn("UsuarioAlta", DbType.String, UsuarioAlta));

            #endregion

            using (DataSet dtsDatos = Datos.DataBase.ExecuteDataSet(null, "SP_AsignaCupon", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn))))
            {

                if (dtsDatos.Tables.Count > 0)
                {
                    objResul.Error = dtsDatos.Tables[0].Rows[0][1].ToString();
                    objResul.ErrorCode = dtsDatos.Tables[0].Rows[0][0].ToString();
                }
            }

            return objResul;
        }

        public static List<ModCuponCargaTarjetasMasivasResult> CargaCuponesM(string ID, DateTime? FechaInicio, DateTime? FechaFin, string Sucursal, string Uso, string Identificador, string Usuario)
        {
            List<ModCuponCargaTarjetasMasivasResult> lstResultado = new List<ModCuponCargaTarjetasMasivasResult>();
            ModCuponCargaTarjetasMasivasResult objResul = new ModCuponCargaTarjetasMasivasResult();

            #region Paramtros
            DateTime fechaFInal = new DateTime(FechaFin.Value.Year, FechaFin.Value.Month, FechaFin.Value.Day, 23, 59, 59);

            ArrayList listParameters = new ArrayList();

            listParameters.Add(new ParameterIn("Id", DbType.Int32, ID));
            listParameters.Add(new ParameterIn("FechaInicio", DbType.DateTime, FechaInicio));
            listParameters.Add(new ParameterIn("FechaFin", DbType.DateTime, fechaFInal));
            listParameters.Add(new ParameterIn("Sucursal", DbType.Int32, 0));


            if (Uso.ToLower().Contains("un"))
                listParameters.Add(new ParameterIn("UsoUnico", DbType.Binary, 1));
            else
                listParameters.Add(new ParameterIn("UsoUnico", DbType.Binary, 0));
            listParameters.Add(new ParameterIn("Identificador", DbType.String, Identificador));
            listParameters.Add(new ParameterIn("UsuarioAlta", DbType.String, Usuario));

            #endregion

            using (DataSet dtsDatos = Datos.DataBase.ExecuteDataSet(null, "SP_AsignaCuponMasivo", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn))))
            {

                if (dtsDatos.Tables.Count > 0)
                {
                    foreach (DataRow campos in dtsDatos.Tables[0].Rows)
                    {
                        objResul = new ModCuponCargaTarjetasMasivasResult();
                        objResul.TotalTarjetas = Convert.ToInt32(campos["Totaltarjetas"].ToString());
                        objResul.TotalTarjetasAsignadas = Convert.ToInt32(campos["TotalTarjetasAsignadas"].ToString());
                        objResul.TotalTarjetasYaCuentanconCupon = Convert.ToInt32(campos["YaContabanconCupon"].ToString());

                        lstResultado.Add(objResul);
                    }
                }
            }

            return lstResultado;
        }

        public static List<ModNumeroAsignacionesCupon> ObtenNumAsignaciones()
        {
            List<ModNumeroAsignacionesCupon> lstResultado = new List<ModNumeroAsignacionesCupon>();
            ArrayList listParameters = new ArrayList();

            DataTable tblDatos = DataBase.ExecuteDataSet(null, "sp_lstnumAsignacionesCupones", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn))).Tables[0];

            if (tblDatos != null)
            {
                if (tblDatos.Rows.Count > 0)
                {
                    foreach (DataRow reg in tblDatos.Rows)
                    {
                        ModNumeroAsignacionesCupon campos = new ModNumeroAsignacionesCupon();
                        campos.IdNumAsignacion = Convert.ToInt32(reg[0]);
                        campos.NumAsignacion = Convert.ToInt32(reg[1]);

                        lstResultado.Add(campos);
                    }
                }
            }

            return lstResultado;
        }
        public static List<ModTipoCupon> ObtenTipoCupon()
        {
            List<ModTipoCupon> lstResultado = new List<ModTipoCupon>();
            ArrayList listParameters = new ArrayList();

            DataTable tblDatos = DataBase.ExecuteDataSet(null, "sp_ObtenTipoCupon", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn))).Tables[0];

            if (tblDatos != null)
            {
                if (tblDatos.Rows.Count > 0)
                {
                    foreach (DataRow reg in tblDatos.Rows)
                    {
                        ModTipoCupon campos = new ModTipoCupon();
                        campos.IdTipoCupon = Convert.ToInt32(reg["Id_tipocupon"]);
                        campos.descripcion = reg["descripcion"].ToString();

                        lstResultado.Add(campos);
                    }
                }
            }

            return lstResultado;
        }
        public static List<ModPromosTipoTrigger> ObtenPromoTipoTrigger()
        {
            List<ModPromosTipoTrigger> lstResultado = new List<ModPromosTipoTrigger>();
            ArrayList listParameters = new ArrayList();

            DataTable tblDatos = DataBase.ExecuteDataSet(null, "sp_ObtenerPromocionesTipoTrigger", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn))).Tables[0];

            if (tblDatos != null)
            {
                if (tblDatos.Rows.Count > 0)
                {
                    foreach (DataRow reg in tblDatos.Rows)
                    {
                        ModPromosTipoTrigger campos = new ModPromosTipoTrigger();
                        campos.Id = Convert.ToInt32(reg["Id"]);
                        campos.Identificador = reg["identificador"].ToString();
                        campos.MensajePos = reg["mensajePOS"].ToString();

                        lstResultado.Add(campos);
                    }
                }
            }

            return lstResultado;
        }

        #region "Quitar Cupón"
        public static Result QuitarCupon(string Cupon, string Tarjeta, string Usuario)
        {
            Result objResul = new Result();

            try
            {
                #region Paramtros
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@Cupon", DbType.String, Cupon));
                listParameters.Add(new ParameterIn("@Tarjeta", DbType.String, Tarjeta));
                listParameters.Add(new ParameterIn("@UsuarioBaja", DbType.String, Usuario));
                #endregion

                using (DataSet dtsDatos = Datos.DataBase.ExecuteDataSet(null, "sp_QuitarCupon", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn))))
                {

                    if (dtsDatos.Tables.Count > 0)
                    {
                        objResul.Error = dtsDatos.Tables[0].Rows[0]["Error"].ToString();
                        objResul.ErrorCode = dtsDatos.Tables[0].Rows[0]["ErrorCode"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objResul;
        }

        public static Result QuitarCuponMasivamente(string Cupon, string Usuario)
        {
            Result objResul = new Result();
            try
            {
                #region Paramtros
                ArrayList listParameters = new ArrayList();

                listParameters.Add(new ParameterIn("@Cupon", DbType.String, Cupon));
                listParameters.Add(new ParameterIn("@UsuarioBaja", DbType.String, Usuario));
                #endregion

                using (DataSet dtsDatos = Datos.DataBase.ExecuteDataSet(null, "sp_QuitarCuponMasivamente", (ParameterIn[])listParameters.ToArray(typeof(ParameterIn))))
                {

                    if (dtsDatos.Tables.Count > 0)
                    {
                        objResul.Error = dtsDatos.Tables[0].Rows[0]["Error"].ToString();
                        objResul.ErrorCode = dtsDatos.Tables[0].Rows[0]["ErrorCode"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objResul;
        }
        #endregion
    }
}
