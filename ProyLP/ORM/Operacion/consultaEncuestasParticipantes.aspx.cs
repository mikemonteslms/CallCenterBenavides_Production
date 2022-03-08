using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Collections;
using System.Web.Security;

namespace ORMOperacion
{
    public partial class consultaEncuestasParticipantes : System.Web.UI.Page
    {
        csParticipanteComplemento participante;
        String countryCode;
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
                        Master.Submenu = "Encuestas";

                        csCountry country = new csCountry();
                        country.ObtienePrograma_Participante(Session["participante_id"].ToString());
                        countryCode = country.CountryCode2.ToUpper();
                        string participante_id = Session["participante_id"].ToString();
                        participante = new csParticipanteComplemento();
                        participante.ID = participante_id;
                        string participanteID = Session["participante_id"].ToString();
                        string encuestaID = Request.QueryString.Get("encid");
                        int numRespuestas = 0;
                        decimal calificacion;
                        string status = "";
                        bool activado = true; //revisarActivacionEncuesta(); // habilitar siempre
                        int completado;
                        DateTime primerDia = FirstDayOfMonthFromDateTime(DateTime.Today).Date;
                        DateTime ultimoDia = LastDayOfMonthFromDateTime(DateTime.Today).Date;
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString))
                        {
                            conn.Open();
                            SqlCommand cmdFecha = new SqlCommand("SELECT completado =" +
                            "case when count(fecha_aplicacion) >= 1 then 1 " +
                            "else 0 end " +
                            "FROM encuesta_respuestas where participante_id = @ParticipanteID and status_id = 3" +
                            "and fecha_aplicacion between @inicio and @ultimo", conn);
                            cmdFecha.Parameters.Add(new SqlParameter("@ParticipanteID", participanteID));
                            cmdFecha.Parameters.Add(new SqlParameter("@inicio", primerDia));
                            cmdFecha.Parameters.Add(new SqlParameter("@ultimo", ultimoDia));
                            completado = (Int32)cmdFecha.ExecuteScalar();
                            foreach (GridViewRow row in encuestas.Rows)
                            {
                                string encuesta_id = ((Label)row.FindControl("id")).Text;
                                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM encuesta_respuestas where encuesta_id = @encuestaID and participante_id = @ParticipanteID and fecha_aplicacion between @inicio and @ultimo", conn);
                                cmd.Parameters.Add(new SqlParameter("@ParticipanteID", participanteID));
                                cmd.Parameters.Add(new SqlParameter("@encuestaID", encuesta_id));
                                cmd.Parameters.Add(new SqlParameter("@inicio", primerDia));
                                cmd.Parameters.Add(new SqlParameter("@ultimo", ultimoDia));
                                numRespuestas = (Int32)cmd.ExecuteScalar();

                                SqlCommand cmd1 = new SqlCommand("SELECT isnull(max(calificacion),0) as calificacion FROM encuesta_respuestas where encuesta_id = @encuestaID and participante_id = @ParticipanteID", conn);
                                cmd1.Parameters.Add(new SqlParameter("@ParticipanteID", participanteID));
                                cmd1.Parameters.Add(new SqlParameter("@encuestaID", encuesta_id));
                                calificacion = (Decimal)cmd1.ExecuteScalar();

                                SqlCommand cmdStatus = new SqlCommand("select status = case when id in (select id from encuesta where tipo_encuesta_id = 3 and id in" +
                                "(select encuesta_id from encuesta_respuestas where status_id = 3 and participante_id = @ParticipanteID)) then 'C'" +
                                "when id in (select min(id) from encuesta where tipo_encuesta_id = 3 and id not in " +
                                "(select encuesta_id from encuesta_respuestas where status_id = 3 and participante_id = @ParticipanteID)) then 'A'" +
                                "else 'I' end from encuesta where id = @encuestaID and tipo_encuesta_id = 3", conn);
                                cmdStatus.Parameters.Add(new SqlParameter("@ParticipanteID", participanteID));
                                cmdStatus.Parameters.Add(new SqlParameter("@encuestaID", encuesta_id));
                                status = cmdStatus.ExecuteScalar().ToString();

                                if (status.Equals("C"))
                                {
                                    row.FindControl("HyperLink1").Visible = false;
                                    row.FindControl("calificacion").Visible = true;
                                    ((Label)row.FindControl("calificacion")).Text = "Evaluación aprobada - Tu calificacion es:" + calificacion;
                                }
                                else if (status.Equals("A") | Session["participante_id"].ToString() == "3701")
                                {
                                    if (!activado)
                                    {
                                        row.FindControl("HyperLink1").Visible = false;
                                        row.FindControl("calificacion").Visible = true;
                                        ((Label)row.FindControl("calificacion")).Text = "Evaluación desactivada intente el siguiente mes";
                                    }
                                    else
                                    {
                                        if (completado == 1)
                                        {
                                            row.FindControl("HyperLink1").Visible = false;
                                            row.FindControl("calificacion").Visible = true;
                                            ((Label)row.FindControl("calificacion")).Text = "Evaluación sera activada el siguiente mes";
                                        }
                                        else
                                        {
                                            if (numRespuestas >= 2 & calificacion < 6)
                                            {
                                                row.FindControl("HyperLink1").Visible = false;
                                                row.FindControl("calificacion").Visible = true;
                                                ((Label)row.FindControl("calificacion")).Text = "Intentos Agotados - Espere al siguiente mes ";
                                            }
                                            else if ((numRespuestas >= 1) & (numRespuestas < 2) & (calificacion < 6))
                                            {
                                                ((HyperLink)row.FindControl("HyperLink1")).Text = "Contestar evaluación Nuevamente";
                                                row.FindControl("calificacion").Visible = true;
                                                ((Label)row.FindControl("calificacion")).Text = "Evaluación no aprobada - calificacion: " + calificacion;
                                            }
                                        }
                                    }
                                }
                                else if (status.Equals("I"))
                                {
                                    ((HyperLink)row.FindControl("HyperLink1")).Enabled = false;
                                    ((HyperLink)row.FindControl("HyperLink1")).Text = "Evaluación inactiva";
                                    ((HyperLink)row.FindControl("HyperLink1")).ForeColor = Color.Gray;
                                }
                            }
                            conn.Close();
                        }
                    }
                    else
                    {
                        Response.Redirect("default.aspx", false);
                    }
                }
        }

        public bool revisarActivacionEncuesta()
        {

            //DateTime dtNow = DateTime.Today;
            //string mes = dtNow.Month.ToString();
            //string year = dtNow.Year.ToString();
            //string fechaActivacionInicial = "01/" + mes + "/" + year;
            //string fechaActivacionFinal = "12/" + mes + "/" + year;

            csParticipante p = new csParticipante();
            DateTime hoy = p.Fecha(countryCode);

            bool activada;

            //DateTime FAI = Convert.ToDateTime(fechaActivacionInicial);
            //DateTime FAF = Convert.ToDateTime(fechaActivacionFinal);

            if (hoy.Day < 11 || Session["participante_id"].ToString() == "3701")
            {
                activada = true;
            }
            else
            {
                activada = false;
            }
            return activada;
        }

        public DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }

        protected void encuestas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Request.Url.Scheme == "http" && ConfigurationManager.AppSettings["sitio"] == "prod")
                {
                    String hyp1 = ((HyperLink)e.Row.FindControl("HyperLink1") as HyperLink).NavigateUrl;
                    ((HyperLink)e.Row.FindControl("HyperLink1") as HyperLink).NavigateUrl = "https://" + Request.Url.Host + "/call_center/encuesta/" + hyp1;
                    String hyp2 = ((HyperLink)e.Row.FindControl("HyperLink2") as HyperLink).NavigateUrl;
                    ((HyperLink)e.Row.FindControl("HyperLink2") as HyperLink).NavigateUrl = "https://" + Request.Url.Host + "/call_center/encuesta/" + hyp2;
                }
            }
        }
    }
}