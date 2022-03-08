using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace WebPfizer.LMS.eCard
{
    public partial class ConfirmarCorreo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    Clientes obj = new Clientes();

                    DataSet dtsResultados = obj.ValidaTarjeta(Session["Usuario"].ToString());
                    if (dtsResultados.Tables.Count > 0)
                    {
                        if (dtsResultados.Tables[0].Rows.Count > 0)
                        {
                            txtCorreo.Text = dtsResultados.Tables[0].Rows[0]["Cliente_strCorreoElectronico"].ToString();
                        }
                    }
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                DataSet dtsActualizaMail;
                dtsActualizaMail = Clientes.ActualizaMailNotificacion(Session["Usuario"].ToString(),txtNewMail.Text);
                txtCorreo.Text = dtsActualizaMail.Tables[0].Rows[0]["NewM"].ToString();
                trActualiza.Attributes.Clear();
                trActualiza.Attributes.Add("display", "none");
                trActualiza2.Attributes.Clear();
                trActualiza2.Attributes.Add("display", "none");
            }
            //sp_insertahistoricocliente
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            DataSet dtsResult = Clientes.ReenviarMailBienvenida(Session["Usuario"].ToString(), txtCorreo.Text);
            if (dtsResult.Tables.Count > 0)
            { 
                if(dtsResult.Tables[0].Rows.Count > 0)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El correo de bienvenida fue reenviado a " + txtCorreo.Text + "');", true);
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El correo de bienvenida no pudo ser reenviado');", true);
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El correo de bienvenida no pudo ser reenviado');", true);
        }
    }
}
                                            