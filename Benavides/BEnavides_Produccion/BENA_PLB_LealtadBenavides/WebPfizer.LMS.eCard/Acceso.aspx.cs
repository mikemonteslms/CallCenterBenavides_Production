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
using Entidades;
using Datos;

namespace Portal_Benavides
{
    public partial class Acceso : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        ValidaAcceso valida = new ValidaAcceso();
        DatActualizarCliente datos = new DatActualizarCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtTarjeta.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");

            if (!IsPostBack)
            {
                btnEntrar.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/6-login/btn-entrar-hover.jpg'");
                btnEntrar.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/6-login/btn-entrar.jpg'");

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
                    Mensajes("Debes capturar Tarjeta y Contraseña");
                }
                else
                {
                    objDataset = valida.ValidaUsuario(tarjeta, contraseña);


                    if (objDataset.Tables.Count > 0)
                    {
                        if (objDataset.Tables[0].Rows.Count > 0)
                        {
                            string respuesta = objDataset.Tables[0].Rows[0]["CodigoError_strCodigo"].ToString();

                            if (respuesta == "0")
                            {
                                string prefijo = txtTarjeta.Text.Substring(0, 2);

                                if (prefijo == "13")
                                {
                                    divPop.Visible = true;
                                    mpePop.Show();
                                    Session["Usuario"] = txtTarjeta.Text.ToString();
                                    Session["Peques"] = objDataset.Tables[0].Rows[0]["Clubpeques"].ToString();                                   
                                }
                                else
                                {
                                    if (objDataset.Tables[0].Rows[0]["Activado"].ToString() == "0")
                                    {
                                        //divBienve.Visible = true;
                                        //mdpBienve.Show();
                                        Session["Usuario"] = txtTarjeta.Text.ToString();
                                        Session["Peques"] = objDataset.Tables[0].Rows[0]["Clubpeques"].ToString();
                                        Response.Redirect("Index.aspx");
                                    }
                                    else
                                    {
                                        divPop.Visible = false;
                                        mpePop.Hide();
                                        Session["Usuario"] = txtTarjeta.Text.ToString();
                                        Session["Peques"] = objDataset.Tables[0].Rows[0]["Clubpeques"].ToString();                                      
                                        Response.Redirect("Index.aspx");
                                    }
                                }                                
                            }
                            else
                            {
                                Mensajes("Datos incorrectos, por favor verifícalos");
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

        protected void imgAcivaPromo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RegistroCliente_EncuestaInicial.aspx");
        }

        protected void btnCerrarPop_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnCerrarBienve_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Index.aspx");
        }


    }


}
