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
    public class Usuariosapp
    {
        public ModUsuarioapp ObtenUsuariosCCAValidar(string Usuario)
        {
            DataSet DS = new DataSet();
            ModUsuarioapp campos = new ModUsuarioapp();

            try
            {

                ArrayList lstParameters = new ArrayList();
                if (!string.IsNullOrWhiteSpace(Usuario))
                {
                    lstParameters.Add(new ParameterIn("@usuario", DbType.String, Usuario));
                }
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenUsuarioValida", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "users");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                campos = new ModUsuarioapp();
                                campos.Usuario = reg[0].ToString();
                                campos.eMail = reg[1].ToString();
                                campos.Password = reg[2].ToString();
                                campos.NombreUsuario = reg[3].ToString();
                                campos.PasswordFormat = Convert.ToInt32(reg[4].ToString());


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return campos;
        }
        public List<ModRoles> ObtenRoles()
        {
            DataSet DS = new DataSet();
            List<ModRoles> lstResultados = new List<ModRoles>();

            try
            {
                ArrayList lstParameters = new ArrayList();
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_catRoles", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "users");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModRoles campos = new ModRoles();
                                campos.RoleId = reg[1].ToString();
                                campos.RoleName = reg[2].ToString();

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
        public List<ModUsuarioapp> ObtenUsuariosapp(string Usuario)
        {
            DataSet DS = new DataSet();
            List<ModUsuarioapp> lstResultados = new List<ModUsuarioapp>();

            try
            {

                ArrayList lstParameters = new ArrayList();
                if (!string.IsNullOrWhiteSpace(Usuario))
                {
                    lstParameters.Add(new ParameterIn("@usuario", DbType.String, Usuario));
                }
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenUsuarios", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "users");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModUsuarioapp campos = new ModUsuarioapp();
                                campos.Usuario = reg[0].ToString();
                                campos.eMail = reg[1].ToString();
                                campos.Password = reg[2].ToString();
                                campos.NombreUsuario = reg[3].ToString();

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
        public ModContenedorUsuarios ObtenUsuarioModifica(string Usuario)
        {

            ModContenedorUsuarios Respuesta = new ModContenedorUsuarios();
            DataSet DS = new DataSet();
            List<ModUsuarioapp> lstResultados = new List<ModUsuarioapp>();

            try
            {
                ArrayList lstParameters = new ArrayList();
                if (!string.IsNullOrWhiteSpace(Usuario))
                {
                    lstParameters.Add(new ParameterIn("@usuario", DbType.String, Usuario));
                }
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenUsuariosModifica", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "users");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            ModContenedorUsuarios campos = new ModContenedorUsuarios();
                            campos.Usuarios.Usuario = DS.Tables[0].Rows[0][0].ToString();
                            campos.Usuarios.eMail = DS.Tables[0].Rows[0][1].ToString();
                            campos.Usuarios.Password = DS.Tables[0].Rows[0][2].ToString();
                            campos.Usuarios.NombreUsuario = DS.Tables[0].Rows[0][5].ToString();
                            campos.Usuarios.PasswordFormat = Convert.ToInt32(DS.Tables[0].Rows[0][6].ToString());
                            if (Convert.ToBoolean(DS.Tables[0].Rows[0][7]))
                            {
                                //Bloqueado
                                campos.Usuarios.Activa = 1;
                            }
                            else
                            {
                                //Activo
                                campos.Usuarios.Activa = 0;
                            }


                            Respuesta.Usuarios = campos.Usuarios;

                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModRoles campo = new ModRoles();
                                campo.RoleId = reg[3].ToString();
                                campo.RoleName = reg[4].ToString();

                                Respuesta.lstRoles.Add(campo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Respuesta;
        }
        public string SecurityAccess(string Usuario)
        {
            DataSet DS = new DataSet();
            string strResultado = "";

            try
            {
                ArrayList lstParameters = new ArrayList();
                if (!string.IsNullOrWhiteSpace(Usuario))
                {
                    lstParameters.Add(new ParameterIn("@output", DbType.String, Usuario));
                }
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spGeneraPwd", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "users");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strResultado = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strResultado;
        }
        public bool RegistrarUsuarioapp(ModUsuarioapp Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));
                lstParametros.Add(new ParameterIn("@Nombre", DbType.String, Datos.NombreUsuario));
                lstParametros.Add(new ParameterIn("@passwword", DbType.String, Datos.Password));
                lstParametros.Add(new ParameterIn("@email", DbType.String, Datos.eMail));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_UsuarioCallcenter", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool RegistrarRolesUser(string Usuario, string IdRol)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Usuario));
                lstParametros.Add(new ParameterIn("@RolID", DbType.String, IdRol));


                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_AsignaRol", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool ModificarUsuarioapp(ModUsuarioapp Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));
                //lstParametros.Add(new ParameterIn("@nombre", DbType.String, Datos.NombreUsuario));
                //lstParametros.Add(new ParameterIn("@password", DbType.String, Datos.Password));
                lstParametros.Add(new ParameterIn("@email", DbType.String, Datos.eMail));
                lstParametros.Add(new ParameterIn("@pwd", DbType.String, Datos.Password));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_UsuarioCallcenter", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado < 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool EliminarRolesUser(ModUsuarioapp Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));


                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spD_EliminaRolesUsuario", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool BloqueoUsuarioaCC(string Usuario)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Usuario));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_BloquearUsuarioCC", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool EnvioMailUsuarioaCC(string Usuario, string Correo, string Newpwd)
        {
            bool blnCorrecto = false;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@CorreoE", DbType.String, Correo));
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Usuario));
                lstParametros.Add(new ParameterIn("@pwd", DbType.String, Newpwd));

                intResultado = DataBase.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_EnviaMailUsersCC", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado < 0)
                {
                    blnCorrecto = true;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }

        public bool ModificarRolesapp(ModUsuarioapp Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Datos.Usuario));
                lstParametros.Add(new ParameterIn("@RolID", DbType.String, Datos.IdRol));


                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_AsignaRol", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool EliminarUsuarioapp(string Usuario)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@usuario", DbType.String, Usuario));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spD_UsuariosCallCenter", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public List<ModcatRoles> ObtenCatRoles()
        {
            DataSet DS = new DataSet();
            List<ModcatRoles> lstResultados = new List<ModcatRoles>();

            try
            {
                ArrayList lstParameters = new ArrayList();
                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_catRoles", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "users");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow reg in DS.Tables[0].Rows)
                            {
                                ModcatRoles campos = new ModcatRoles();
                                campos.ApplicationId = reg[0].ToString();
                                campos.RoleId = reg[1].ToString();
                                campos.RoleName = reg[2].ToString();
                                campos.Descripcion = reg[4].ToString();

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
        public string ObtenNomUser(string User)
        {
            DataSet DS = new DataSet();
            string strResultados = "";

            try
            {
                ArrayList lstParameters = new ArrayList();
                lstParameters.Add(new ParameterIn("@Usuario", DbType.String, User));

                DS = DataBase.ExecuteDataSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "sp_ObtenNombreUsuarioSession", (ParameterIn[])lstParameters.ToArray(typeof(ParameterIn)), "users");

                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        if (DS.Tables[0].Rows.Count > 0)
                        {
                            strResultados = DS.Tables[0].Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strResultados;
        }

        public bool ModificaRolapp(ModcatRoles Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@RoleId", DbType.String, Datos.RoleId));
                lstParametros.Add(new ParameterIn("@NombreRol", DbType.String, Datos.RoleName));
                lstParametros.Add(new ParameterIn("@Descripcion", DbType.String, Datos.Descripcion));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spU_ModificaRol", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
        public bool RegistrarRolapp(ModcatRoles Datos)
        {
            bool blnCorrecto = true;
            int intResultado = 0;
            try
            {
                ArrayList lstParametros = new ArrayList();
                lstParametros.Add(new ParameterIn("@Aplicacion", DbType.String, Datos.ApplicationId));
                lstParametros.Add(new ParameterIn("@NombreRol", DbType.String, Datos.RoleName));
                lstParametros.Add(new ParameterIn("@Descripcion", DbType.String, Datos.Descripcion));

                intResultado = DataBase.ExecuteNonQueryAdminProm(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "spI_AltaRol", (ParameterIn[])lstParametros.ToArray(typeof(ParameterIn)));
                if (intResultado == 0)
                {
                    blnCorrecto = false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return blnCorrecto;
        }
    }
}
