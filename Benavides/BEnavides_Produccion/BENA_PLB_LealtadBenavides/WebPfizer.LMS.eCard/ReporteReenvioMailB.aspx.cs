using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;

namespace WebPfizer.LMS.eCard
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DataSet tblDatos = Clientes.BuscaCorreoBienvenida(txtTarjeta.Text, txtCorreo.Text);
            if (tblDatos.Tables.Count > 1)
            {

                grvCLiente.DataSource = tblDatos.Tables[0];
                grvResultado.DataSource = tblDatos.Tables[1];

                grvCLiente.DataBind();
                grvResultado.DataBind();
                //bool reenviar = true;
                int contadorConf = 0;
                foreach (GridViewRow fila in grvCLiente.Rows)
                {
                    if (fila.Cells[8].Text.ToString() == "Confirmado")
                    {
                        //reenviar = reenviar && true;
                        contadorConf++;
                    }
                }
                if (grvCLiente.Rows.Count == 0)
                {
                    btnReenviar.Enabled = false;
                    return;
                }
                if (contadorConf == grvCLiente.Rows.Count)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No es posible hacer el reenvio del correo de bienvenida, ya que el correo o correos estan confirmados";
                    btnReenviar.Enabled = false;
                    return;
                }
                else
                {
                    lblMensaje.Visible = false;
                    btnReenviar.Enabled = true;
                }
                //if (reenviar == false)
                //{
                //    lblMensaje.Visible = true;
                //    lblMensaje.Text = "No es posible hacer el reenvio del correo de bienvenida, ya que este correo electrónico ya fue confirmado.";
                //    //btnReenviar.Enabled = false;
                //    return;
                //}
                //if (tblDatos.Tables[0].Rows[0]["Correo"] == DBNull.Value)                                    
                //{
                //    lblMensaje.Visible = true;
                //    lblMensaje.Text = "No es posible hacer el reenvio del correo de bienvenida, ya que no tiene una dirección de correo registrada.";
                //    btnReenviar.Enabled = false;
                //    return;
                //}
                //if (tblDatos.Tables[0].Rows[0]["Fecha Confirmación"] != DBNull.Value)
                //{
                //    lblMensaje.Visible = true;
                //    lblMensaje.Text = "No es posible hacer el reenvio del correo de bienvenida, ya que este correo electrónico ya fue confirmado.";
                //    btnReenviar.Enabled = false;
                //    return;
                //}
                //else
                //{
                //    lblMensaje.Visible = false;                    
                //    btnReenviar.Enabled = true;
                //}
            }
        }

        protected void grvResultado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet tblDatos = Clientes.BuscaCorreoBienvenida(txtTarjeta.Text, txtCorreo.Text);
            if (tblDatos.Tables.Count > 1)
            {
                grvResultado.DataSource = tblDatos.Tables[1];

                grvResultado.DataBind();
            }
        }

        protected void btnReenviar_Click(object sender, EventArgs e)
        {
            int enviados = 0;
            if (grvResultado.Rows.Count > 0 && grvCLiente.Rows.Count > 0)
            {
                //bool renviar = true;
                //foreach (GridViewRow fila in grvCLiente.Rows)
                //{
                //    renviar = (((CheckBox)fila.Cells[0].FindControl("chkEnviar")).Checked && renviar);
                //}
                //if (renviar)
                //{
                int seleccionados = 0;
                foreach (GridViewRow fila in grvCLiente.Rows)
                {
                    if (((CheckBox)fila.Cells[0].FindControl("chkEnviar")).Checked)
                    {
                       seleccionados++;
                    }                
                }
                if (seleccionados == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Debe seleccionar una tarjeta para reenviar el correo de bienvenida')", true);
                }
                else
                {
                    foreach (GridViewRow fila in grvCLiente.Rows)
                    {
                        if (((CheckBox)fila.Cells[0].FindControl("chkEnviar")).Checked)
                        {
                            string correoA = fila.Cells[4].Text;
                            string TarjetaA = fila.Cells[1].Text;
                            if (!string.IsNullOrEmpty(correoA))
                            {
                                DataSet dtsResult = Clientes.ReenviarMailBienvenida(TarjetaA, correoA);
                                enviados++;
                            }

                        }
                        //}
                    }
                    if (enviados > 0)
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Se reenvio el correo de bienvenida a los correos seleccionados')", true);
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No fue posible el reenvio de correo de bienvenida a los correos seleccionados')", true);
                }
                btnBuscar_Click(btnBuscar, new EventArgs());
            }
        }

        protected void grvCLiente_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow fila in ((GridView)sender).Rows)
            {
                if (fila.Cells[8].Text.ToString() == "Confirmado")
                {
                    ((CheckBox)fila.Cells[0].FindControl("chkEnviar")).Enabled = false;
                }
            }
        }
    }
}