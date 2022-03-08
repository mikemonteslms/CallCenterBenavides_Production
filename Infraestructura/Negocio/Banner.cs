using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Data;
using System.Collections;

namespace Negocio
{
    public class Banner
    {
        public int Id { get; set; }
        public int Categoria { get; set; }
        public int PromoID { get; set; }
        public string Descripcion { get; set; }
        public string URLImage { get; set; }
        public DateTime FechaVigenciaIni { get; set; }
        public DateTime FechaVigenciaFin { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activo { get; set; }
        public int Seccion { get; set; }

        public Banner()
        {
            
        }

        public static List<Banner> GetListBanners(int IdCategoria = 0, string Tarjeta = "")
        {
            List<Banner> lstBanners = new List<Banner>();     
            ArrayList lstParametros = new ArrayList();
            if(IdCategoria > 0)
                lstParametros.Add(new ParameterIn("CatergoriaID", DbType.Int32, IdCategoria));
            if(!string.IsNullOrEmpty(Tarjeta))
                lstParametros.Add(new ParameterIn("Tarjeta", DbType.String,Tarjeta));
            DataSet dtsDatos = DataBase.ExecuteDataSet(null, "SP_GetBannersInfo", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
            if (dtsDatos.Tables.Count > 0)
            {
                if (dtsDatos.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow fila in dtsDatos.Tables[0].Rows)
                    {
                        Banner objBanner = new Banner();
                        objBanner.CrearInstancia(fila);
                        lstBanners.Add(objBanner);
                    }
                }
            }
            dtsDatos.Dispose();
            return lstBanners;
        }

        private void CrearInstancia(DataRow fila)
        {
            if (fila["BannersPromo_intID"] != DBNull.Value)
                this.Id = Convert.ToInt32(fila["BannersPromo_intID"]);
            if (fila["BannersPromo_intPromoID"] != DBNull.Value)
                this.PromoID = Convert.ToInt32(fila["BannersPromo_intPromoID"]);
            if (fila["BannersPromo_intCategoria"] != DBNull.Value)
                this.Categoria = Convert.ToInt32(fila["BannersPromo_intCategoria"]);
            this.Descripcion = fila["BannersPromo_strDescripcion"].ToString();
            this.URLImage = fila["BannersPromo_strURLimage"].ToString();
            if(fila["BannersPromo_dateFechaInicio"] != DBNull.Value)
                this.FechaVigenciaIni = Convert.ToDateTime(fila["BannersPromo_dateFechaInicio"]);
            if (fila["BannersPromo_dateFechaFinal"] != DBNull.Value)
                this.FechaVigenciaFin = Convert.ToDateTime(fila["BannersPromo_dateFechaFinal"]);
            if (fila["BannersPromo_dateFechaAlta"] != DBNull.Value)
                this.FechaAlta = Convert.ToDateTime(fila["BannersPromo_dateFechaAlta"]);
            if (fila["BannersPromo_bitActivo"] != DBNull.Value)
                this.Activo = Convert.ToBoolean(fila["BannersPromo_bitActivo"]);
            //Pruebas
            //if (fila["Seccion"] != DBNull.Value)
                //this.Seccion = Convert.ToInt32(fila["Seccion"].ToString());
        }
    }
}
