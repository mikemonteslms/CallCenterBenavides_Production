using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CallCenterDB
{
    public static class csMenu
    {
        private static csDataBase database;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accion"></param>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="orden"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static DataSet ABC_Menu(string accion, int id, string nombre, int orden, string usuario)
        {
            database = new csDataBase();
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@accion", accion));
            parametros.Add(new SqlParameter("@id", id));
            parametros.Add(new SqlParameter("@nombre", nombre));
            parametros.Add(new SqlParameter("@orden", orden));
            parametros.Add(new SqlParameter("@usuario", usuario));

            return database.dsConsulta("sp_abc_menu", parametros, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accion"></param>
        /// <param name="id"></param>
        /// <param name="menuId"></param>
        /// <param name="nombre"></param>
        /// <param name="url"></param>
        /// <param name="imagen"></param>
        /// <param name="alt"></param>
        /// <param name="orden"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static DataSet ABC_Funciones(string accion, int id, int menuId, string nombre, string url, string imagen, string alt, int orden, string usuario)
        {
            database = new csDataBase();
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@accion", accion));
            parametros.Add(new SqlParameter("@id", id));
            parametros.Add(new SqlParameter("@menu_id", menuId));
            parametros.Add(new SqlParameter("@nombre", nombre));
            parametros.Add(new SqlParameter("@url", url));
            parametros.Add(new SqlParameter("@imagen", imagen));
            parametros.Add(new SqlParameter("@alt", alt));
            parametros.Add(new SqlParameter("@orden", orden));
            parametros.Add(new SqlParameter("@usuario", usuario));

            return database.dsConsulta("sp_abc_funciones", parametros, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accion"></param>
        /// <param name="funcionId"></param>
        /// <param name="rol"></param>
        /// <returns></returns>
        public static DataSet ABC_RolMenu(string accion, int funcionId, string rol)
        {
            database = new csDataBase();
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@accion", accion));
            parametros.Add(new SqlParameter("@id_submenu", funcionId));
            parametros.Add(new SqlParameter("@rol", rol));

            return database.dsConsulta("sp_submenu_aspnet_Roles", parametros, true);
        }
    }
}
