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
using System.Data.SqlClient;
using Negocio;
using Entidades;
using Datos;

namespace WebPfizer.LMS.eCard
{
    public partial class MasterECard : System.Web.UI.MasterPage
    {
        Catalogos objValidaPerfil = new Catalogos();
        DataSet objDataset = new DataSet();
        Clientes cliente = new Clientes();
        DatActualizarCliente datos = new DatActualizarCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Acceso.aspx");
            }

            if (!IsPostBack)
            {
                btnCerrarSesion.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/botones/cerrar-btn.png'");
                btnCerrarSesion.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/botones/cerrar-btn-over.png'");

                string idcliente = Session["Usuario"].ToString();
                CargaDatosCliente(idcliente);
                LlenarContacto();
                DivMP.Visible = false;
            }
            else
            {
                //DivMP.Visible = true;
                //mpeContacto.Show();

                imgbtnEnviarMP.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/botones/enviar-btn.png'");
                imgbtnEnviarMP.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/botones/enviar-btn-over.png'");

                imgBtnCancelarMP.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/botones/cancelar-btn.png'");
                imgBtnCancelarMP.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/botones/cancelar-btn-over.png'");
            }
        }

        protected void LlenarContacto()
        {
            EntActualizarCliente ent = new EntActualizarCliente();
            DataSet datos = new DataSet();

            ent.IdCliente = Session["Usuario"].ToString();
            datos = cliente.MisDatosCliente(ent);

            txtCorreoMP.Text = datos.Tables[0].Rows[0]["Cliente_strCorreoElectronico"].ToString();
        }

        protected void btnCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();

            DivMP.Visible = false;
            Response.Redirect("Acceso.aspx");
        }

        protected void btnInicio_Click(object sender, ImageClickEventArgs e)
        {
            DivMP.Visible = false;
            Response.Redirect("Index.aspx");
        }

        protected void btnMisDatos_Click(object sender, ImageClickEventArgs e)
        {
            DivMP.Visible = false;
            Response.Redirect("MisDatos.aspx");
        }

        protected void CargaDatosCliente(string idcliente)
        {
            try
            {
                objDataset = cliente.DatosCLiente(idcliente);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    txtNombreMP.Text = objDataset.Tables[0].Rows[0]["Nombre"].ToString();
                    txtTarjetaMP.Text = objDataset.Tables[0].Rows[0]["Tarjeta"].ToString();

                    lblSaludo.Text = objDataset.Tables[0].Rows[0]["Nombre"].ToString();
                    lblTarjeta.Text = objDataset.Tables[0].Rows[0]["Tarjeta"].ToString();
                    lblNivel.Text = objDataset.Tables[0].Rows[0]["Nivel"].ToString();
                    lblSaldo.Text = objDataset.Tables[0].Rows[0]["SaldoPesos"].ToString();

                    //string saldo = "";
                    //string subsSaldo = "";                    
                    //saldo = objDataset.Tables[0].Rows[0]["Saldo"].ToString();

                    //int num = saldo.Length;
                    //subsSaldo = subsSaldo.Substring(5, num);

                    //lblSaldo.Text = subsSaldo;
                }
                else
                {
                    lblSaludo.Text = "Sin informacion";
                    lblTarjeta.Text = "Sin informacion";
                    lblNivel.Text = "Sin informacion";
                    lblSaldo.Text = "Sin informacion";
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        protected void imgbtnEnviarMP_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string buscar = "Escribe aqui tu comentario..";
                if (buscar.Contains(txtComentarioMP.Text) || txtComentarioMP.Text == string.Empty || txtComentarioMP.Text.Length < 9)
                {
                    lblError.Text = "Debes capturar un comentario válido";
                    mpeContacto.Show();
                }
                else
                {
                    EntContacto ent = new EntContacto();

                    ent.Nombre = txtNombreMP.Text;
                    ent.Tarjeta = txtTarjetaMP.Text;
                    ent.Correo = txtCorreoMP.Text;
                    ent.Comentario = txtComentarioMP.Text;

                    int respuesta = datos.EnviarCorreoContacto(ent.Nombre, ent.Tarjeta, ent.Correo, ent.Comentario);
                    if (respuesta == 1)
                    {
                        string Mensaje = "Se ha enviado el correo de forma correcta";
                        ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "')", true);

                        txtComentarioMP.Text = "Escribe aquí tu comentario..";

                        DivMP.Visible = false;
                    }
                    else
                    {
                        string Mensaje = "Hubo un problema al enviar el correo";
                        ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alert('" + Mensaje + "')", true);

                        DivMP.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
                DivMP.Visible = false;
            }
        }

        private void Mensajes(string valorMensaje)
        {
            DivMP.Visible = false;
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void imgBtnCancelarMP_Click(object sender, ImageClickEventArgs e)
        {
            DivMP.Visible = false;
            Response.Redirect("Index.aspx");
        }

        protected void imgBtnContacto1_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("Index.aspx");
            mpeContacto.Show();
        }

        

    }

}
