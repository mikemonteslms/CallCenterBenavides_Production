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
    public partial class SaldoMovClienteCallCenter : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        Catalogos objConsultaDatos = new Catalogos();        

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UsuarioCC"] == null)
            //{
            //    FormsAuthentication.SignOut();
            //    FormsAuthentication.RedirectToLoginPage();
            //    return;
            //}
            Master.MenuMain = "Clientes";
            Master.Submenu = "Saldo";
            if (Session["strTarjeta"] != null)
            {
                CargaListaLlamadas(Session["strTarjeta"].ToString());
                CargaTransaccionesCliente(Session["strTarjeta"].ToString());
            }
            else
                Response.Redirect("~/Perfil/Perfil.aspx", true);
        }

                
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void CargaTransaccionesCliente(string idcliente)
        {
            try
            {
                objDataset = cliente.DatosTransaccionesCliente(idcliente);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    grvSaldoClienteCC.DataSource = objDataset;
                    grvSaldoClienteCC.DataBind();
                }
                else
                {
                    grvSaldoClienteCC.DataSource = null;
                    grvSaldoClienteCC.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }

        protected void CargaListaLlamadas(string tarjeta)
        {
            try
            {
                objDataset = cliente.DatosListaLlamadas(tarjeta);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    grvListaLlamadasCC.DataSource = objDataset;
                    grvListaLlamadasCC.DataBind();
                }
                else
                {
                    grvListaLlamadasCC.DataSource = null;
                    grvListaLlamadasCC.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }

        protected void CargaDatosCliente(string idcliente)
        {
            try
            {
                objDataset = cliente.DatosCLiente(idcliente);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    lblNombreTarjeta.Text = objDataset.Tables[0].Rows[0]["Nombre"].ToString();
                    //lblFechaNacimientoTarjeta.Text = objDataset.Tables[0].Rows[0]["FechaNacimiento"].ToString();

                    lblNivelTarjeta.Text = objDataset.Tables[0].Rows[0]["Nivel"].ToString();
                    lblSaldoMovTarjeta.Text = objDataset.Tables[0].Rows[0]["SaldoPesos"].ToString();
                
                    lblSaldoMovTelefono.Text = objDataset.Tables[0].Rows[0]["Telefono"].ToString();
                    lblSaldoCelular.Text = objDataset.Tables[0].Rows[0]["Celular"].ToString();
                    lblSaldoCorreo.Text = objDataset.Tables[0].Rows[0]["Correo"].ToString();
                    lblSaldoDireccion.Text = objDataset.Tables[0].Rows[0]["Direccion"].ToString();
                    lblBoom.Text = objDataset.Tables[0].Rows[0]["Boomerangs"].ToString();
                    lblPeque.Text = objDataset.Tables[0].Rows[0]["ClubPeques"].ToString();
                    lblConfirmoC.Text = objDataset.Tables[0].Rows[0]["ConfirmoCorreo"].ToString();
                    lblConfirmoCelular.Text = objDataset.Tables[0].Rows[0]["ConfirmoCelular"].ToString();
                }
                else
                {
                    lblNivelTarjeta.Text = "Sin informacion";
                    lblSaldoMovTarjeta.Text = "Sin informacion";

                    lblSaldoMovTelefono.Text = "Sin informacion";
                    lblSaldoCelular.Text = "Sin informacion";
                    lblSaldoCorreo.Text = "Sin informacion";
                    lblSaldoDireccion.Text = "Sin informacion";

                    lblBoom.Text = "Sin informacion";
                    lblPeque.Text = "Sin informacion";
                    lblConfirmoC.Text = "Sin informacion";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + ex.Message + "');", true);
            }
        }        
              
        protected void SaldoMovBuscar_Click(object sender, ImageClickEventArgs e)
        {
            string idcliente = txtSaldoTarjeta.Text;
            string tarjeta = txtSaldoTarjeta.Text;
            //CargaTransaccionesCliente(idcliente);

            CargaTransaccionesCliente(idcliente);
            CargaDatosCliente(idcliente);

            CargaListaLlamadas(tarjeta);
        }

        protected void SaldoMovRegresar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
            //Response.Redirect("HomeRep.aspx");
        }

             
        
    }

}
