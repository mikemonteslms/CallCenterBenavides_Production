using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;
using CNegocio;
using CallCenterDB.Entidades;

namespace Portal
{
    public partial class contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.GuardaAcceso("Contacto");
                if (Session["participante_id"] != null)
                {
                    CargaDatosParticipante(Session["participante_id"].ToString());
                    Carga_catalogo_tipo_mensaje(ConfigurationManager.AppSettings["programa"].ToString());
                }
                else
                {
                    Session.Abandon();
                    Session.Clear();
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                    return;
                }

            }
        }

        protected void CargaDatosParticipante(string participante_id)
        {
            csParticipanteComplemento p = new csParticipanteComplemento();
            p.ID = Session["participante_id"].ToString();
            p.DatosParticipante();
            txtNombre.Text = p.NombreCompleto;
            txtClave.Text = p.Clave;
            txtEmail.Text = p.CorreoElectronico;

            DataTable dtTel = p.ConsultaTelefono();

            var celular = (from tel in dtTel.AsEnumerable()
                           where tel.Field<string>("tipotelefono").ToLower().Equals("celular")
                           select new { Numero = tel.Field<string>("telefono") }).SingleOrDefault();
            txtTelefono.Text = celular != null ? celular.Numero : "-";

        }



        protected void Carga_catalogo_tipo_mensaje(string programa)
        {
            csLlamada objcsLlamada = new csLlamada();
            ddlTipoMensaje.DataSource = objcsLlamada.Consulta_categoria_tipo_contacto(programa);
            ddlTipoMensaje.DataBind();
            ddlTipoMensaje.Items.Insert(0, new ListItem("Seleccione", "0"));
        }


        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (GuardaLlamada())
                {
                    if (EnviaComentario())
                    {
                        txtComentarios.Text = "";
                        Master.MuestraMensaje("El comentario se ha enviado correctamente.");
                    }
                    else
                    {
                        Master.MuestraMensaje("Ocurrió un error al intentar enviar el comentario, intente nuevamente.");
                    }
                }
                else
                {
                    Master.MuestraMensaje("Ocurrió un error al intentar enviar el comentario, intente nuevamente.");
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected bool EnviaComentario()
        {
            try
            {
                Funciones oFunciones = new Funciones();
                string plantilla = Server.MapPath("mailing/comentarios.html");
                string html = "";
                using (StreamReader sr = new StreamReader(plantilla))
                {
                    html = sr.ReadToEnd();
                }
                html = html.Replace("@NOMBRE", txtNombre.Text);
                html = html.Replace("@CLAVE", txtClave.Text);
                html = html.Replace("@EMAIL", txtEmail.Text);
                html = html.Replace("@TELEFONO", txtTelefono.Text);
                html = html.Replace("@TIPOMENSAJE", ddlTipoMensaje.SelectedItem.ToString());
                html = html.Replace("@COMENTARIOS", txtComentarios.Text);

                csEnvioMail envio = new csEnvioMail(ConfigurationManager.AppSettings["programa"]);
                DatosCliente mail = new DatosCliente();
                List<DatosCliente> enviar = new List<DatosCliente>();
                mail.ToMail = envio.CorreoElectronico;
                mail.ToName = envio.Remitente;
                enviar.Add(mail);

                RespuestaEnvio r = envio.Enviar(enviar, "Comentarios " + envio.NombrePrograma, html);
                if(r.Codigo == "OK")
                {
                    return true;
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected bool GuardaLlamada()
        {
            try
            {
                csParticipanteComplemento participante = new csParticipanteComplemento();
                participante.ID = Session["participante_id"].ToString();
                participante.DatosParticipante();
                csLlamada llamada = new csLlamada();
                llamada.IDParticipante = participante.ID;
                llamada.IDUsuario = Membership.GetUser().ProviderUserKey.ToString();
                llamada.NombreLlama = txtNombre.Text.Trim();
                llamada.Correo_Electronico = txtEmail.Text.Trim();
                llamada.Descripcion = txtComentarios.Text.Trim();
                llamada.Telefono = "";
                llamada.AgregaTipoLlamada(ddlTipoMensaje.SelectedValue.ToString()); //combo--
                llamada.Status_seguimiento_id = "1"; // Abierto
                llamada.GuardaLlamadaComentario();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}