using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CallCenterDB;

namespace ORMOperacion.mailing
{
    public partial class envioDatosAcceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                CNegocio.csEnvioMail envio = new CNegocio.csEnvioMail(int.Parse((Session["participante"] as csParticipanteComplemento).ProgramaID));
                List<CallCenterDB.Entidades.DatosCliente> cliente = new List<CallCenterDB.Entidades.DatosCliente>();

                csDataBase query = new csDataBase();
                csDataBase queryInsert = new csDataBase();
                query.Query = "select correo, contacto, usuario, password from tmp_accesos_1";
                query.EsStoreProcedure = false;
                List<SqlParameter> param = new List<SqlParameter>();
                DataTable dtEmail = query.dtConsulta();
                foreach (DataRow drEmail in dtEmail.Rows)
                {
                    CallCenterDB.Entidades.DatosCliente mail = new CallCenterDB.Entidades.DatosCliente();

                    string body = "";
                    using (StreamReader sr = new StreamReader(Server.MapPath("../plantillas/envioDatosAcceso.html")))
                    {
                        body = sr.ReadToEnd();
                    }
                    mail.ToMail = drEmail["correo"].ToString().Trim();
                    mail.ToName = drEmail["contacto"].ToString().Trim();

                    string Subject = "Datos de acceso " + (Session["participante"] as csParticipanteComplemento).Programa;

                    body = body.Replace("@CORREO", drEmail["correo"].ToString());
                    body = body.Replace("@NOMBRE", drEmail["contacto"].ToString());
                    body = body.Replace("@USUARIO", drEmail["usuario"].ToString());
                    body = body.Replace("@CONTRASENA", drEmail["password"].ToString());
                    cliente.Add(mail);
                    CallCenterDB.Entidades.RespuestaEnvio r = envio.Enviar(cliente, Subject, body);
                    if (r.Codigo == "OK")
                    {
                        lblMensaje.Text = "Mail enviado";
                    }
                    else
                    {
                        lblMensaje.Text = "Ocurrio un error al hacer envio";

                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "ocurrio un error: " + ex.Message;
            }
        }
    }
}