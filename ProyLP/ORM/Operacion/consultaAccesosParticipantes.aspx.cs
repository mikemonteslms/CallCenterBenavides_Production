using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace ORMOperacion
{
    public partial class consultaAccesosParticipantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                if (Session["participante_id"] != null && Session["participante"] != null)
                {
                    Master.Menu = "Participantes";
                    Master.Submenu = "Accesos";
                    CargaGridView();
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
        }

        protected void gvHistoricoAccesos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHistoricoAccesos.PageIndex = e.NewPageIndex;
            CargaGridView();
        }

        protected void CargaGridView()
        {
            DataTable dt;
            SqlParameter parametro;
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametro = new SqlParameter("@participante_id", Session["participante_id"].ToString());
            parametros.Add(parametro);
            csDataBase datos = new csDataBase();
            dt = datos.dtConsulta("ObtieneControlAccesosParticipante", parametros, true);
            gvHistoricoAccesos.DataSource = dt.DefaultView;
            gvHistoricoAccesos.DataBind();
        }
    }
}