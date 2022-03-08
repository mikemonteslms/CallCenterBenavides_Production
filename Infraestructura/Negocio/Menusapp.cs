using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;
using System.Collections;
using System.Configuration;

namespace Negocio
{
    public class Menusapp
    {
        public List<ModMenus> ObtenMenus()
        {
            DataSet DS = new DataSet();
            List<ModMenus> lstResultados = new List<ModMenus>();

            try
            {
                ArrayList lstParameters = new ArrayList();
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ListaMenus", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "users");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModMenus campos = new ModMenus();
                                campos.Id = Convert.ToInt32(reg[0].ToString());
                                campos.Nombre = reg[1].ToString();

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
        public List<ModRoles> ObtenRoles()
        {
            DataSet DS = new DataSet();
            List<ModRoles> lstResultados = new List<ModRoles>();

            try
            {
                ArrayList lstParameters = new ArrayList();
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ListaRoles", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "rol");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModRoles campos = new ModRoles();
                                campos.RoleId = reg[0].ToString();
                                campos.RoleName = reg[1].ToString();

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
        public List<ModRoles> ObtenRolesxSubmnu(int SubMenuId)
        {
            DataSet DS = new DataSet();
            List<ModRoles> lstResultados = new List<ModRoles>();

            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@SubmnuId", DbType.Int32, SubMenuId));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_RolesxSubmnus", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "rol");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModRoles campos = new ModRoles();
                                campos.RoleId = reg[0].ToString();
                                campos.RoleName = reg[1].ToString();

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
        public List<ModSubMenu> ObtenSubMenus(int IdMenu)
        {
            DataSet DS = new DataSet();
            List<ModSubMenu> lstResultados = new List<ModSubMenu>();

            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@MenuId", DbType.Int32, IdMenu));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ListaSubmenus", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "mnus");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModSubMenu campos = new ModSubMenu();
                                campos.SubMenuId = Convert.ToInt32(reg[0].ToString());
                                campos.MenuId = Convert.ToInt32(reg[1].ToString());
                                campos.Nombre = reg[2].ToString();
                                campos.Orden = Convert.ToInt32(reg[3].ToString());
                                campos.RoleId = reg[4].ToString();
                                campos.RoleName = reg[5].ToString();

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
        public List<ModSubMenu> ObtenSubMenus2(int IdMenu)
        {
            DataSet DS = new DataSet();
            List<ModSubMenu> lstResultados = new List<ModSubMenu>();

            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@MenuId", DbType.Int32, IdMenu));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ListaSubmenus2", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "mnus");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModSubMenu campos = new ModSubMenu();
                                campos.SubMenuId = Convert.ToInt32(reg[0].ToString());
                                campos.Nombre = reg[2].ToString();

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
        public List<ModSubmnusxRol> ObtenSubMenusxRoles(string RoleId)
        {
            DataSet DS = new DataSet();
            List<ModSubmnusxRol> lstResultados = new List<ModSubmnusxRol>();

            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@RoleId", DbType.String, RoleId));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ConsultaSubMenusxRol", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "mnusxrol");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModSubmnusxRol campos = new ModSubmnusxRol();
                                campos.RoleId = reg[0].ToString();
                                campos.NombreRol = reg[1].ToString();
                                campos.NombreSubmnu = reg[2].ToString();

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
        public List<ModMenu> ValidaMenus(string Menu)
        {
            int intTotexisten = 0;
            DataSet DS = new DataSet();
            List<ModMenu> lstResultados = new List<ModMenu>();

            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@Menu", DbType.String, Menu));
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spValidaMenus", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "mnus");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            intTotexisten = Convert.ToInt32(DS.Tables[0].Rows[0][0]);
                        }
                        if (intTotexisten > 0)
                        {
                            foreach (DataRow reg in DS.Tables[1].Rows)
                            {
                                ModMenu campos = new ModMenu();
                                campos.Nombre = reg[0].ToString();
                                campos.TotExist = intTotexisten;

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
        public bool GuardarAltaMenus(ModMenu Datos)
        {
            bool blnRespuesta = true;
            int intResultado = 0;
            List<ModMenu> lstResultados = new List<ModMenu>();

            try
            {
                ArrayList lstParameters = new ArrayList();

                lstParameters.Add(new ParameterIn("@Nombre", DbType.String, Datos.Nombre));
                lstParameters.Add(new ParameterIn("@Orden", DbType.Int32, Datos.Orden));
                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_AltaMenu", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

                if (intResultado < 0)
                {
                    blnRespuesta = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnRespuesta;
        }
        public bool GuardarAltaSubMenus(ModSubMenu Datos)
        {
            bool blnRespuesta = true;
            int intResultado = 0;

            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@MenuID", DbType.Int32, Datos.MenuId));
                lstParameters.Add(new ParameterIn("@Nombresubmnu", DbType.String, Datos.Nombre));
                lstParameters.Add(new ParameterIn("@URL", DbType.String, Datos.URL));
                lstParameters.Add(new ParameterIn("@Orden", DbType.Int32, Datos.Orden));
                lstParameters.Add(new ParameterIn("@RolID", DbType.String, Datos.RoleId));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_AltaSubMenu", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

                if (intResultado < 0)
                {
                    blnRespuesta = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnRespuesta;
        }
        public bool GuardarCambiosMenus(ModSubMenu Datos) 
        {
            bool blnRespuesta = true;
            int intResultado = 0;
            List<ModSubMenu> lstResultados = new List<ModSubMenu>();

            try
            {
                ArrayList lstParameters = new ArrayList();

                lstParameters.Add(new ParameterIn("@MenuId", DbType.Int32, Datos.MenuId));
                lstParameters.Add(new ParameterIn("@SubMenuId", DbType.Int32, Datos.SubMenuId));
                lstParameters.Add(new ParameterIn("@Nombre", DbType.String, Datos.Nombre));
                lstParameters.Add(new ParameterIn("@Orden", DbType.Int32, Datos.Orden));
                if (!string.IsNullOrWhiteSpace(Datos.RoleId))
                {
                    lstParameters.Add(new ParameterIn("@RoleId", DbType.String, Datos.RoleId));
                }
                else {
                    lstParameters.Add(new ParameterIn("@RoleId", DbType.String, null));
                }
                
                lstParameters.Add(new ParameterIn("@RoleIdnvo", DbType.String, Datos.RoleIdNvo));
                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_ActualizaSubMenu", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

                if (intResultado < 0)
                {
                    blnRespuesta = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnRespuesta;
        }
        public bool GuardarRolesxSubmenus(string RoleID, int SubMenuID)
        {
            bool blnRespuesta = true;
            int intResultado = 0;

            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@SubmnuId", DbType.Int32, SubMenuID));
                lstParameters.Add(new ParameterIn("@RoleId", DbType.String, RoleID));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_RolesxSubmnus", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

                if (intResultado < 0)
                {
                    blnRespuesta = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnRespuesta;
        }
        public bool EliminaRolMenu(string NomSubMenu, string RoleId)
        {
            bool blnRespuesta = true;
            int intResultado = 0;

            try
            {
                ArrayList lstParameters = new ArrayList();

                lstParameters.Add(new ParameterIn("@nombre", DbType.String, NomSubMenu));
                lstParameters.Add(new ParameterIn("@RoleId", DbType.String, RoleId));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spD_EliminaRolSubMenu", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

                if (intResultado < 0)
                {
                    blnRespuesta = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnRespuesta;
        }
        public bool EliminaRolSubMenu(int SubMenuID)
        {
            bool blnRespuesta = true;
            int intResultado = 0;

            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@SubmnuId", DbType.Int32, SubMenuID));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spD_EliminaRolesxSubmnus", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

                if (intResultado < 0)
                {
                    blnRespuesta = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnRespuesta;
        }

        public bool EliminaSubMenu(int SubMenuID)
        {
            bool blnRespuesta = true;
            int intResultado = 0;

            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@SubMenuId", DbType.Int32, SubMenuID));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spD_EliminaSubmenu", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)));

                if (intResultado < 0)
                {
                    blnRespuesta = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blnRespuesta;
        }
    }
}
