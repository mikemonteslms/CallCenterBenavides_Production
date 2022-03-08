using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ORMOperacion.registrar
{
    public partial class registrar_gsf : System.Web.UI.Page
    {
        csDataBase query = new csDataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtGSF = query.dtConsulta("select *, '' as participante_id, '' as usuario, '' as password from [gsf 07 abril] where conc = '1340'", false);
                gvGSF.DataSource = dtGSF.DefaultView;
                gvGSF.DataBind();
            }
        }
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvr in gvGSF.Rows)
            {
                string usuario = "", participante_id = "", password = "";

                MembershipUserCollection busca_usuario = Membership.FindUsersByEmail(gvr.Cells[9].Text);
                if (busca_usuario.Count == 0)
                {
                    try
                    {
                        CryptoUtil cr = new CryptoUtil();

                        string conc = cr.htmlDecode(gvr.Cells[0].Text);
                        string marca = cr.htmlDecode(gvr.Cells[1].Text);
                        string nombre_conc = cr.htmlDecode(gvr.Cells[2].Text);
                        string ciudad = cr.htmlDecode(gvr.Cells[3].Text);
                        string estado = cr.htmlDecode(gvr.Cells[4].Text);
                        string lada = cr.htmlDecode(gvr.Cells[6].Text);
                        string telefono = cr.htmlDecode(gvr.Cells[7].Text);
                        string nombre_gsf = cr.htmlDecode(gvr.Cells[8].Text);
                        string correo_gsf = cr.htmlDecode(gvr.Cells[9].Text);
                        string alterno_gsf = cr.htmlDecode(gvr.Cells[10].Text);
                        string celular_gsf = cr.htmlDecode(gvr.Cells[11].Text);
                        string nombre_gv = cr.htmlDecode(gvr.Cells[12].Text);
                        string correo_gv = cr.htmlDecode(gvr.Cells[13].Text);
                        string celular_gv = cr.htmlDecode(gvr.Cells[14].Text);
                        string nombre_ga = cr.htmlDecode(gvr.Cells[15].Text);
                        string correo_ga = cr.htmlDecode(gvr.Cells[16].Text);
                        string alterno_ga = cr.htmlDecode(gvr.Cells[17].Text);
                        string consultor = cr.htmlDecode(gvr.Cells[18].Text);
                        string cc = cr.htmlDecode(gvr.Cells[19].Text);
                        string regional = cr.htmlDecode(gvr.Cells[20].Text);

                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@conc", conc));
                        param.Add(new SqlParameter("@marca", marca));
                        param.Add(new SqlParameter("@nombre_conc", nombre_conc));
                        param.Add(new SqlParameter("@ciudad", ciudad));
                        param.Add(new SqlParameter("@estado", estado));
                        param.Add(new SqlParameter("@lada", lada));
                        param.Add(new SqlParameter("@telefono", telefono));
                        param.Add(new SqlParameter("@nombre_gsf", nombre_gsf));
                        param.Add(new SqlParameter("@correo_gsf", correo_gsf));
                        param.Add(new SqlParameter("@alterno_gsf", alterno_gsf));
                        param.Add(new SqlParameter("@celular_gsf", celular_gsf));
                        param.Add(new SqlParameter("@nombre_gv", nombre_gv));
                        param.Add(new SqlParameter("@correo_gv", correo_gv));
                        param.Add(new SqlParameter("@celular_gv", celular_gv));
                        param.Add(new SqlParameter("@nombre_ga", nombre_ga));
                        param.Add(new SqlParameter("@correo_ga", correo_ga));
                        param.Add(new SqlParameter("@alterno_ga", alterno_ga));
                        param.Add(new SqlParameter("@consultor", consultor));
                        param.Add(new SqlParameter("@cc", cc));
                        param.Add(new SqlParameter("@regional", regional));

                        DataTable dtUsuario = query.dtConsulta("sp_inserta_participante_gsf", param, true);
                        if (dtUsuario.Rows.Count > 0)
                        {
                            participante_id = dtUsuario.Rows[0]["participante_id"].ToString();
                            usuario = dtUsuario.Rows[0]["usuario"].ToString();
                        }
                        Funciones f = new Funciones();
                        password = f.generaPassword(6);
                        MembershipCreateStatus status;
                        MembershipUser user = Inserta_Usuario(usuario, participante_id, gvr.Cells[8].Text, gvr.Cells[9].Text, password, out status);
                        if (status.Equals(MembershipCreateStatus.Success))
                        {
                            actualiza_participante_con_membershipUser(participante_id, user.ProviderUserKey.ToString());
                        }
                        else
                        {
                            password = status.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        participante_id = "ERROR";
                        usuario = ex.Message;
                        password = ex.InnerException != null ? ex.InnerException.Message : "";
                    }
                }
                else
                {
                    participante_id = "0";
                    usuario = "Email duplicado";

                }
                gvr.Cells[21].Text = participante_id;
                gvr.Cells[22].Text = usuario;
                gvr.Cells[23].Text = password;
            }
        }
        protected void btnExportar_Click(object sender, EventArgs e)
        {
            GridViewExportUtil.Export("gsf.xls", gvGSF);
        }
        protected MembershipUser Inserta_Usuario(string clave_participante, string participante_id, string nombre, string email, string password, out MembershipCreateStatus status)
        {
            MembershipUser objUser = null;
            MembershipUserCollection usuario = Membership.FindUsersByName(clave_participante);
            if (usuario.Count == 0)
            {
                objUser = Membership.CreateUser(clave_participante, password, email, "pregunta", "respuesta", true, out status);
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }
            return objUser;
        }
        public void actualiza_participante_con_membershipUser(string participante_id, string MemberShip_userID)
        {
            try
            {
                csParticipante participante = new csParticipante();
                // inserta en la tabla participante_aspnet_users
                participante.participante_aspnet_User(participante_id, MemberShip_userID);
            }
            catch
            {

            }
        }
    }
}