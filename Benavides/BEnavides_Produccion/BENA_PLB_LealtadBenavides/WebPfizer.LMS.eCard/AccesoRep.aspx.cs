using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Negocio;

namespace Portal_Benavides
{
    public partial class AccesoRep : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        ValidaAcceso valida = new ValidaAcceso();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnEntrar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/botones/entrar-btn-over.png'");
                btnEntrar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/botones/entrar-btn.png'");      

                SetFocus(txtTarjeta);
            }
        }

        protected void btnEntrar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string tarjeta = txtTarjeta.Text.Trim();
                string contraseña = txtContra.Text.Trim();

                if (tarjeta == string.Empty || contraseña == string.Empty)
                {
                    Mensajes("Debes capturar Usuario y Contraseña");
                }
                else
                {
                    objDataset = valida.ValidaUsuarioCallCenter(tarjeta, contraseña);
                    if (objDataset.Tables.Count > 0)
                    {
                        if (objDataset.Tables[0].Rows.Count > 0)
                        {
                            string respuesta = objDataset.Tables[0].Rows[0]["CodigoError_strCodigo"].ToString();

                            if (respuesta == "0")
                            {
                                Session["UsuarioCC"] = txtTarjeta.Text.ToString();
                                Session["UsuarioRep"] = txtTarjeta.Text.ToString();
                                //Response.Redirect("HomeRep.aspx");
                                Response.Redirect("IndexRep.aspx");
                            }
                            else
                            {
                                Mensajes("Usuario o Contraseña incorrectos");
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
        
        
    }
}
