using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace ORMOperacion.registrar
{
    public partial class registrarParticipantes : System.Web.UI.Page
    {
        string clave_participante = "";
        string participante_id = "";
        string nombre = "";
        string email = "";
        string password = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            csDataBase query = new csDataBase();
            switch (ddlMarca.SelectedItem.Value)
            {
                case "1": // VW
                    query.Query = "obtiene_participante_vw_registrar";
                    break;
                case "2": // Audi
                    query.Query = "obtiene_participante_audi_registrar";
                    break;
                case "3": // Seat
                    query.Query = "obtiene_participante_seat_registrar";
                    break;
                case "4": // Porsche
                    query.Query = "obtiene_participante_porsche_registrar";
                    break;
                case "5": // Porsche
                    query.Query = "obtiene_participante_consultor_registrar";
                    break;
            }
            query.EsStoreProcedure = true;
            DataTable dtDatos = query.dtConsulta();
            gvDatos.DataSource = dtDatos;
            gvDatos.DataBind();
            lblNoRegistros.Text = gvDatos.Rows.Count.ToString();
        }
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if (gvDatos.Rows.Count > 0)
            {
                foreach (GridViewRow fila in gvDatos.Rows)
                {
                    clave_participante = gvDatos.DataKeys[fila.RowIndex]["clave"].ToString().Trim();
                    participante_id = gvDatos.DataKeys[fila.RowIndex]["id"].ToString().Trim();
                    nombre = gvDatos.DataKeys[fila.RowIndex]["nombre"].ToString().Trim();
                    email = gvDatos.DataKeys[fila.RowIndex]["correo_electronico"].ToString().Trim();
                    password = gvDatos.DataKeys[fila.RowIndex]["contraseña"].ToString().Trim();
                    try
                    {
                        Inserta_ActualizaParticipantes(clave_participante, participante_id, nombre, email, password);
                        MembershipUser U = Membership.GetUser(clave_participante);
                        actualiza_participante_con_membershipUser(int.Parse(participante_id), U.ProviderUserKey.ToString());
                    }
                    catch
                    {

                    }
                }
            }
        }

        /// <summary>
        /// metodos para cargar y actualizar datos en membership
        /// </summary>
        #region membershipMethods
        protected void Inserta_ActualizaParticipantes(string clave_participante, string participante_id, string nombre, string email, string password)
        {
            MembershipCreateStatus status;
            MembershipUserCollection usuario = Membership.FindUsersByName(clave_participante);
            if (usuario.Count == 0)
            {
                string user = clave_participante;
                string pass = password;
                MembershipUser objUser = Membership.CreateUser(user, pass, email, "pregunta", "respuesta", true, out status);
            }
            //else
            //{
            //    MembershipUser U = Membership.GetUser(GeneraUsuarioMemberShip(clave_participante));
            //    MembershipUser Miusuario = new MembershipUser(U.ProviderName, U.UserName, U.ProviderUserKey, U.Email, U.PasswordQuestion, U.Comment, U.IsApproved, false, U.CreationDate, U.LastLoginDate, U.LastActivityDate, U.LastPasswordChangedDate, U.LastLockoutDate);
            //    Membership.UpdateUser(Miusuario);
            //ActualizaRolIdParticipante(clave_participante,participante_id);
            //}
        }

        protected string buscaRolParticipante(string participante_id)
        {
            string resultado = string.Empty;
            //objData = new ClassDataSQL1();
            DataTable dt = new DataTable();
            SqlParameter[] objArr = new SqlParameter[1];
            SqlParameter objP = new SqlParameter("@participante_id", int.Parse(participante_id));
            objArr[objArr.Length - 1] = objP;
            //dt = objData.LlenaDatosDatatable("sp_busca_rol_por_participante", objArr);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    resultado = dt.Rows[0].ItemArray[0].ToString();
                }
            }
            return resultado;
        }

        //protected string buscaUserIDParticipante(string clave_participane)
        //{
        //    string resultado = string.Empty;
        //    DataTable dt = new DataTable();
        //    SqlParameter[] objArr = new SqlParameter[1];
        //    SqlParameter objP = new SqlParameter("@username", GeneraUsuarioMemberShip(clave_participane));
        //    objArr[objArr.Length - 1] = objP;
        //    //dt = objData.LlenaDatosDatatable("sp_busca_UsuarioID", objArr);
        //    if (dt != null)
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            resultado = dt.Rows[0].ItemArray[0].ToString();
        //        }
        //    }
        //    return resultado;
        //}

        //protected void InsertaRolParticipante(string clave_stars, string participante_id)
        //{
        //    string resultado = string.Empty;
        //    //objData = new ClassDataSQL1();
        //    DataTable dt = new DataTable();
        //    SqlParameter[] objArr = new SqlParameter[1];
        //    SqlParameter objP = new SqlParameter("@usuarioID", buscaUserIDParticipante(clave_stars));
        //    objArr[objArr.Length - 1] = objP;
        //    Array.Resize(ref objArr, objArr.Length + 1);
        //    objP = new SqlParameter("@rolID", buscaRolParticipante(participante_id));
        //    objArr[objArr.Length - 1] = objP;
        //    //objData.LlenaDatosDatatable("sp_inserta_UsuarioInRol_MemberShip", objArr);
        //}

        //protected void ActualizaRolIdParticipante(string clave_participante, string participante_id)
        //{
        //    string resultado = string.Empty;
        //    //objData = new ClassDataSQL1();
        //    DataTable dt = new DataTable();
        //    SqlParameter[] objArr = new SqlParameter[1];
        //    SqlParameter objP = new SqlParameter("@usuarioID", buscaUserIDParticipante(clave_participante));
        //    objArr[objArr.Length - 1] = objP;
        //    Array.Resize(ref objArr, objArr.Length + 1);
        //    objP = new SqlParameter("@rolID", buscaRolParticipante(participante_id));
        //    objArr[objArr.Length - 1] = objP;
        //    //objData.LlenaDatosDatatable("sp_actualiza_UsuarioInRol_MemberShip", objArr);
        //}

        //protected void Bloquea_usuarios(string clave_participante, string participante_id, string nombre)
        //{
        //    MembershipCreateStatus status;
        //    MembershipUserCollection usuario = Membership.FindUsersByName(GeneraUsuarioMemberShip(clave_participante));
        //    //MembershipUserCollection usuario = Membership.FindUsersByName();
        //    if (usuario.Count > 0)
        //    {
        //        Membership.DeleteUser(GeneraUsuarioMemberShip(clave_participante));
        //        //MembershipUser U = Membership.GetUser(GeneraUsuarioMemberShip());
        //        //if (!U.IsLockedOut)
        //        //{
        //        //    //MembershipUser Miusuario=Membership.GetUser(GeneraUsuarioMemberShip());
        //        //    MembershipUser Miusuario = new MembershipUser(U.ProviderName, U.UserName, U.ProviderUserKey, U.Email, U.PasswordQuestion, U.Comment, U.IsApproved, true, U.CreationDate, U.LastLoginDate, U.LastActivityDate, U.LastPasswordChangedDate, U.LastLockoutDate);
        //        //    Membership.UpdateUser(Miusuario);
        //        //}
        //    }
        //}

        protected void registrarUsuarioMembership(string usuario, string password, string email, string pregunta, string respuesta)
        {
            MembershipCreateStatus status;
            // Tratamos de crear el usuario
            Membership.CreateUser(usuario, password, email, pregunta, respuesta, true, out status);
            // Comprobamos el estado de la creación del usuario
            if (status == MembershipCreateStatus.Success)
            {
                MembershipUser objUser = Membership.GetUser(usuario);
                Roles.AddUserToRole(usuario, "Usuario");
                // Podemos realizar otras acciones como sumar una visita, etc.
                // Ingresamos el usuario: nuestra próxima función
                //Membership.l
                //ingresar(usuario, password, true);
            }
            else
            {
                // Si no se ha podido crear el usuario, 
                // Manejemos cuál ha sido el motivo
                switch (status)
                {
                    case MembershipCreateStatus.DuplicateUserName:
                        //lb_Error.Text = "Hay otro usuarios con el mismo nombre";
                        break;
                    default:
                        //lb_Error.Text = "Ha habido un error de registro: " + status.ToString();
                        break;
                }
                //lb_Error.Visible = true;
            }
        }

        //protected string GeneraUsuarioMemberShip(string clave_stars)
        //{
        //    string strUsuario = string.Empty;
        //    //if (ddlMarca.SelectedValue == "1")
        //    //    strUsuario = "PM" + clave_stars.ToUpper();
        //    //else
        //    strUsuario = clave_stars.ToUpper();
        //    //txtNombre.Text.Trim().Substring(0, 1).ToLower() + txtApellidoPaterno.Text.Trim().ToLower() +Session["participante_id"].ToString().Trim().ToLower();
        //    return strUsuario;
        //}

        protected string GeneraPassMemberShip(string participante_id, string nombre)
        {
            string strPass = string.Empty;
            strPass = participante_id.Trim().ToLower() + "#" + nombre.Trim().Substring(0, 1).ToLower();
            if (strPass.Length <= 7)
            {
                strPass = "0000" + strPass;
            }
            return strPass;
        }

        public void actualiza_participante_con_membershipUser(int participante_id, string MemberShip_userID)
        {
            try
            {
                csParticipante participante = new csParticipante();
                // inserta en la tabla participante_aspnet_users
                participante.participante_aspnet_User(participante_id.ToString(), MemberShip_userID);
            }
            catch
            {

            }
        }

        public void actualiza_usuario_con_membershipUser(int usuario_id, string MemberShip_userID)
        {
            //objData = new ClassDataSQL1();
            SqlParameter[] objArr = new SqlParameter[1];
            SqlParameter objP = new SqlParameter("@usuarioID", MemberShip_userID);
            objArr[objArr.Length - 1] = objP;
            Array.Resize(ref objArr, objArr.Length + 1);
            objArr[objArr.Length - 1] = new SqlParameter("@usuario_id", usuario_id);
            try
            {
                //objData.EjecutaStoreNonquery("sp_Actualiza_usuario_Set_MemberShip_User", objArr);
            }
            catch
            {

            }
        }

        #endregion

        protected void btnConsultarUsuarios_Click(object sender, EventArgs e)
        {
            lblNoRegistros.Text = gvDatos.Rows.Count.ToString();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //if (gvDatos.Rows.Count > 0)
            //{
            //    foreach (GridViewRow fila in gvDatos.Rows)
            //    {
            //        clave_participante = gvDatos.DataKeys[fila.RowIndex]["clave_participante"].ToString();
            //        participante_id = gvDatos.DataKeys[fila.RowIndex]["id"].ToString();
            //        nombre = gvDatos.DataKeys[fila.RowIndex]["nombre"].ToString();
            //        email = gvDatos.DataKeys[fila.RowIndex]["email"].ToString();
            //        password = gvDatos.DataKeys[fila.RowIndex]["contraseña"].ToString();
            //        try
            //        {
            //            Inserta_Actualizausuarios(clave_participante, participante_id, nombre, email, password);
            //            MembershipUser U = Membership.GetUser(GeneraUsuarioMemberShip(clave_participante));
            //            actualiza_usuario_con_membershipUser(int.Parse(participante_id), U.ProviderUserKey.ToString());
            //        }
            //        catch
            //        {

            //        }
            //    }
            //}
        }
    }
}