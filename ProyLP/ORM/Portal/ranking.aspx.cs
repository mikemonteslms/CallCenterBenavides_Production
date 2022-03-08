using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class ranking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["participante_id"] == null)
            {
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }

            if (!IsPostBack)
            {
                if (Session["participante_id"] != null)
                {
                    cargarRanking(Session["participante_id"].ToString());
                }
            }
        }
        protected void cargarRanking(string participante_id)
        {
            csParticipanteComplemento p = new csParticipanteComplemento();
            p.ID = participante_id;
            p.DatosParticipante();

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LoyaltyWorld"].ConnectionString);
            
            //Ranking Asesores            
            SqlCommand command = new SqlCommand("sp_obtiene_ranking_asesores", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@programa", SqlDbType.VarChar));
            command.Parameters.Add(new SqlParameter("@tipo_participante", SqlDbType.VarChar));
            command.Parameters.Add(new SqlParameter("@participante_id", SqlDbType.Int));
            command.Parameters.Add(new SqlParameter("@distribuidor_id", SqlDbType.Int));
            command.Parameters[0].Value = System.Configuration.ConfigurationManager.AppSettings["programa"].ToString();
            command.Parameters[1].Value = p.ClaveTipoParticipante;
            command.Parameters[2].Value = participante_id;
            command.Parameters[3].Value = int.Parse(p.Distribuidora_ID);

            //Ranking Concesionarias
            SqlCommand command1 = new SqlCommand("sp_obtiene_ranking_concesionarias", con);
            command1.CommandType = CommandType.StoredProcedure;
            command1.Parameters.Add(new SqlParameter("@programa", SqlDbType.VarChar));
            command1.Parameters.Add(new SqlParameter("@tipo_participante", SqlDbType.VarChar));
            command1.Parameters.Add(new SqlParameter("@participante_id", SqlDbType.Int));
            command1.Parameters.Add(new SqlParameter("@distribuidor_id", SqlDbType.Int));
            command1.Parameters[0].Value = System.Configuration.ConfigurationManager.AppSettings["programa"].ToString();
            command1.Parameters[1].Value = p.ClaveTipoParticipante;
            command1.Parameters[2].Value = participante_id;
            command1.Parameters[3].Value = int.Parse(p.Distribuidora_ID);


            SqlDataAdapter ra = new SqlDataAdapter(command);
            SqlDataAdapter rc = new SqlDataAdapter(command1);
            DataSet dsa = new DataSet();
            DataSet dsc = new DataSet();
            try
            {
                con.Open();
                //Lleno grid asesores
                ra.Fill(dsa);
                //Lleno grid concesionarias
                rc.Fill(dsc);

                //asigno grid asesores
                lvRankingVendedor.DataSource = dsa;
                lvRankingVendedor.DataBind();
                //asigno grid concesionarias
                lvRankingConcesionaria.DataSource = dsc;
                lvRankingConcesionaria.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                //write error message
            }
        }
        protected void lvRankingVendedor_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                int index = e.Item.DisplayIndex;
                Panel pnl = e.Item.FindControl("pnlContenido") as Panel;
                switch (index)
                {
                    case 0:
                        pnl.CssClass = "barra-contenido uno";
                        break;
                    case 1:
                        pnl.CssClass = "barra-contenido dos";
                        break;
                    case 2:
                        pnl.CssClass = "barra-contenido tres";
                        break;
                    case 3:
                        pnl.CssClass = "barra-contenido cuatro";
                        break;
                    case 4:
                        pnl.CssClass = "barra-contenido cinco";
                        break;
                }
            }
        }
    }
}