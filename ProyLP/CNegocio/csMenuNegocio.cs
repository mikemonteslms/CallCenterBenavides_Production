using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CNegocio
{
    public static class csMenuNegocio
    {
        public static DataTable ConsultarMenu(int id, string usuario)
        {
            DataSet dsResultado = new DataSet();

            
            dsResultado = CallCenterDB.csMenu.ABC_Menu("C", id, "", 0, usuario);

            if (dsResultado != null)
                return dsResultado.Tables[0];
            else
                return null;

        }

        public static void InsertaMenu(string nombre, int orden, string usuario)
        {
            CallCenterDB.csMenu.ABC_Menu("A", 0, nombre, orden, usuario);
        }


        public static void ModificaMenu(string accion, int id, string nombre, int orden, string usuario)
        {
            CallCenterDB.csMenu.ABC_Menu(accion, id, nombre, orden, usuario);
        }


        public static DataTable ConsultarFunciones(int id, int menuID, string usuario)
        {
            DataSet dsResultado = new DataSet();


            dsResultado = CallCenterDB.csMenu.ABC_Funciones("C", id, menuID, "", "", "", "", 0, usuario);

            if (dsResultado != null)
                return dsResultado.Tables[0];
            else
                return null;

        }

        public static void InsertaFunciones(int menuID, string nombre, string url, string imagen, string alt, int orden, string usuario)
        {
            CallCenterDB.csMenu.ABC_Funciones("A", 0, menuID, nombre, url, imagen, alt, orden, usuario);
        }

        public static void ModificaFunciones(string accion, int id, int menuID, string nombre, string url, string imagen, string alt, int orden, string usuario)
        {
            CallCenterDB.csMenu.ABC_Funciones(accion, id, menuID, nombre, url, imagen, alt, orden, usuario);
        }

        public static void ModificaRolMenu(string accion, int funcionID, string rol)
        {
            CallCenterDB.csMenu.ABC_RolMenu(accion, funcionID, rol);
        }
    }
}
