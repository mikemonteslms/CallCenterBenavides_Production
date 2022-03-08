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
    public partial class Contacto : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        ValidaAcceso validaAcceso = new ValidaAcceso();
        Clientes cliente = new Clientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Acceso.aspx", true);
                }

                this.txtComentarioMP.Attributes.Add("onfocus", "if(this.value=='Escribe aqui tu comentario..'){this.value=''};");
                this.txtComentarioMP.Attributes.Add("onblur", "if(this.value==''){this.value='Escribe aqui tu comentario..'};");

                if (!IsPostBack)
                {                    
                    ImageButton btnInicio = (ImageButton)Master.FindControl("btnInicio");
                    ImageButton btnMisDatos = (ImageButton)Master.FindControl("btnMisDatos");
                    ImageButton btnMisBeneficios = (ImageButton)Master.FindControl("btnMisBeneficios");
                    ImageButton btnMisCompras = (ImageButton)Master.FindControl("btnMisCompras");
                    ImageButton btnContacto = (ImageButton)Master.FindControl("btnContacto");

                    btnContacto.ImageUrl = "ImagenesVerBoom/Master/menu/menu_06-hover.png";

                    btnInicio.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_01-hover.png'");
                    btnMisDatos.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_02-hover.png'");
                    //btnMisBeneficios.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_04-hover.png'");
                    btnMisCompras.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_03-hover.png'");
                    //btnContacto.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/menu/menu_06-hover.png'");

                    btnInicio.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_01.png'");
                    btnMisDatos.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_02.png'");
                    //btnMisBeneficios.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_04.png'");
                    btnMisCompras.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_03.png'");
                    //btnContacto.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/menu/menu_06.png'");

                    imgbtnEnviarMP.Attributes.Add("onmouseover", "this.src='Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-enviar-hover.jpg'");
                    imgbtnEnviarMP.Attributes.Add("onmouseout", "this.src='Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-enviar.jpg'");

                    string tarjeta = Session["Usuario"].ToString();
                    objDataset = cliente.DatosCLiente(tarjeta);
                    if (objDataset != null)
                    {
                        if (objDataset.Tables[0].Rows[0]["Nombre"].ToString().Trim() == string.Empty)
                        {
                            txtNombreMP.Enabled = true;
                        }
                        if (objDataset.Tables[0].Rows[0]["Correo"].ToString().Trim() == string.Empty)
                        {
                            txtCorreoMP.Enabled = true;
                        }
                        
                        txtNombreMP.Text = objDataset.Tables[0].Rows[0]["Nombre"].ToString();
                        txtCorreoMP.Text = objDataset.Tables[0].Rows[0]["Correo"].ToString();
                        txtTarjetaMP.Text = tarjeta;
                                               
                    }                  
                }
            }
            catch
            {
 
            }

        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
        protected void imgbtnEnviarMP_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtNombreMP.Text.Trim() == string.Empty || txtTarjetaMP.Text.Trim() == string.Empty || txtCorreoMP.Text.Trim() == string.Empty)
                {
                    Mensajes("Captura todos los campos marcados como obligatorios para continuar");
                }
                else
                {
                    string buscar = "Escribe aqui tu comentario..";
                    if (buscar.Contains(txtComentarioMP.Text) || txtComentarioMP.Text == string.Empty || txtComentarioMP.Text.Length < 9)
                    {
                        lblError.Text = "Tu comentario debe contener al menos 10 caracteres.";
                    }
                    else
                    {
                        EntContacto ent = new EntContacto();
                        DatActualizarCliente datos = new DatActualizarCliente();

                        ent.Nombre = txtNombreMP.Text;
                        ent.Tarjeta = txtTarjetaMP.Text;
                        ent.Correo = txtCorreoMP.Text;
                        ent.Comentario = txtComentarioMP.Text;

                        int respuesta = datos.EnviarCorreoContacto(ent.Nombre, ent.Tarjeta, ent.Correo, ent.Comentario);
                        if (respuesta == 1)
                        {
                            string mensaje = "Se ha enviado el correo de forma correcta";
                            ClientScript.RegisterStartupScript(GetType(), "mostrarmensaje", "diHola('" + mensaje + "', '" + "Index.aspx" + "');", true);

                            txtComentarioMP.Text = "Escribe aquí tu comentario..";
                        }
                        else
                        {
                            string mensaje = "Hubo un problema al enviar el correo";
                            ClientScript.RegisterStartupScript(GetType(), "mostrarmensaje", "diHola('" + mensaje + "', '" + "Index.aspx" + "');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
            
        }
    }
}