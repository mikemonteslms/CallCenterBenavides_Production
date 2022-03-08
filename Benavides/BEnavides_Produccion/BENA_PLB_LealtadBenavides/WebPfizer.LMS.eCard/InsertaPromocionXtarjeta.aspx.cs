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
using System.IO;
using System.Data.OleDb;

namespace WebPfizer.LMS.eCard
{
    public partial class InsertaPromocionXtarjeta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioRep"] == null)
            {
                Response.Redirect("AccesoRep.aspx", true);
            }

            txtCupon.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
            txtEdadInicial.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
            txtEdadFinal.Attributes.Add("onKeyPress", "ValidaSoloNumeros()");
        }

        public static bool IsDate(string inputDate)
        {
            bool isDate = true;
            try
            {
                DateTime dateValue;
                dateValue = DateTime.ParseExact(inputDate, "yyyyMMdd", null);
            }
            catch
            {
                isDate = false;
            }
            return isDate;
        }

        protected void btnEnviar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (rblTarjeta.SelectedValue == "" || rblSexo.SelectedValue=="" || rblTipoPromo.SelectedValue=="" || txtCupon.Text==string.Empty || txtNSE.Text==string.Empty || txtEdadInicial.Text ==string.Empty || txtEdadFinal.Text == string.Empty || txtDescripcion.Text == string.Empty || txtFechaInicio.Text == string.Empty || txtFechaFin.Text == string.Empty )
                {
                    Mensajes("Capture todos los valores para continuar");
                }
                else
                {
                    if (rblTarjeta.SelectedValue == "1" && txtTarjeta.Text == string.Empty)
                    {
                        Mensajes("Capture el numero de tarjeta para continuar");
                    }
                    else
                    {
                        if (IsDate(txtFechaInicio.Text) && IsDate(txtFechaFin.Text))
                        {
                            int valida_imagen1 = 0;
                            int valida_imagen2 = 0;

                            //promocion con imagen
                            if (rblTipoPromo.SelectedValue == "1")
                            {
                                if (fileUploader1.HasFile && fileUploader2.HasFile)
                                {
                                    MemoryStream str = new MemoryStream(fileUploader1.FileBytes);
                                    System.Drawing.Image bmp = System.Drawing.Image.FromStream(str);

                                    MemoryStream str2 = new MemoryStream(fileUploader2.FileBytes);
                                    System.Drawing.Image bmp2 = System.Drawing.Image.FromStream(str2);

                                    if (bmp.Width == 560 && bmp.Height == 185) //imagen preview
                                    { // No Graba la imagen al servidor }
                                        valida_imagen1 = 1;
                                    }
                                    else
                                    {
                                        valida_imagen1 = 0;
                                    }

                                    if (bmp2.Width == 560 && bmp2.Height == 595) //imagen detalle
                                    { // No Graba la imagen al servidor }
                                        valida_imagen2 = 1;
                                    }
                                    else
                                    {
                                        valida_imagen2 = 0;
                                    }

                                    if (valida_imagen1 == 1 && valida_imagen2 == 1)
                                    {
                                        //paso todas las validaciones, guarda la promocion
                                        DataSet ds = new DataSet();
                                        Clientes cs = new Clientes();
                                        string tarjeta;
                                        string url;
                                        string urldetalle;
                                        string urlpromo;
                                        string nombre_archivo_1 = fileUploader1.FileName;
                                        string nombre_archivo_2 = fileUploader2.FileName;

                                        if (rblTarjeta.SelectedValue == "*")
                                        {
                                            tarjeta = "*";
                                        }
                                        else
                                        {
                                            tarjeta = txtTarjeta.Text;
                                        }

                                        url = "http://beneficiointeligente.com.mx/PLB/Imagenes/wsPromociones/" + nombre_archivo_1;
                                        urldetalle = "http://beneficiointeligente.com.mx/PLB/Imagenes/wsPromociones/" + nombre_archivo_2;
                                        urlpromo = "http://www.teponemos10mil.com/bbi/";

                                        ds = cs.InsertaPromocionXtarjeta("1", "998877", tarjeta, txtCupon.Text, rblSexo.SelectedValue, txtNSE.Text, Convert.ToInt32(txtEdadInicial.Text), txtEdadFinal.Text, txtDescripcion.Text, url, urldetalle, urlpromo, Convert.ToInt32(rblTipoPromo.SelectedValue), txtFechaInicio.Text, txtFechaFin.Text);
                                        //ds = null;
                                        if (ds == null)
                                        {
                                            GuardarImagenPreview();
                                            GuardarImagenDetalle();
                                            string resultado = ds.Tables[0].Rows[0]["strTextoRespuesta"].ToString();
                                            Mensajes(resultado);                                                                                                                                  
                                        }
                                        else
                                        {
                                            Mensajes("Error al insertar la promoción");
                                        }
                                    }
                                    else
                                    {
                                        if (valida_imagen1 == 0)
                                        { Mensajes("El tamaño de la imagen preview es incorrecto"); }
                                        if (valida_imagen2 == 0)
                                        { Mensajes("El tamaño de la imagen detalle es incorrecto"); }
                                    }

                                }
                                else
                                {
                                    Mensajes("Seleccione las imagenes de la promoción para continuar");
                                }

                            }
                            else
                            {
                                //promocion sin imagen
                                DataSet ds = new DataSet();
                                Clientes cs = new Clientes();
                                string tarjeta;

                                if (rblTarjeta.SelectedValue == "*")
                                {
                                    tarjeta = "*";
                                }
                                else
                                {
                                    tarjeta = txtTarjeta.Text;
                                }
                                ds = cs.InsertaPromocionXtarjeta("1", "998877", tarjeta, txtCupon.Text, rblSexo.SelectedValue, txtNSE.Text, Convert.ToInt32(txtEdadInicial.Text), txtEdadFinal.Text, txtDescripcion.Text, " ", " ", " ", Convert.ToInt32(rblTipoPromo.SelectedValue), txtFechaInicio.Text, txtFechaFin.Text);
                             
                                if (ds != null)
                                {
                                    string resultado = ds.Tables[0].Rows[0]["strTextoRespuesta"].ToString();
                                    Mensajes(resultado);
                                }
                                else
                                {
                                    Mensajes("Error al insertar la promoción");
                                }

                            }
                        }
                        else
                        {
                            Mensajes("El formato de fecha es incorrecto, favor de verificar.");
                        }
                    }
                }
            }
            catch
            { 
            }
        }

        private void GuardarImagenPreview()
        {
            try
            {
                if (!fileUploader1.HasFile)
                    throw new Exception("Seleccione un archivo del disco duro.");

                // Se verifica que la extensión sea de un formato válido
                // Hay métodos más seguros para esto, como revisar los bytes iniciales del objeto, pero aquí estamos aplicando lo más sencillos
                string ext = fileUploader1.PostedFile.FileName;
                ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower();
                string[] formatos = new string[] { "jpg", "jpeg", "bmp", "png", "gif" };
                if (Array.IndexOf(formatos, ext) < 0)
                    throw new Exception("Formato de imagen inválido.");                

                // Se guardará en carpeta o en base de datos, según lo indicado en el formulario
                
                GuardarArchivo(fileUploader1.PostedFile, false, 0);                                

            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        private void GuardarImagenDetalle()
        {
            try
            {
                if (!fileUploader2.HasFile)
                    throw new Exception("Seleccione un archivo del disco duro.");

                // Se verifica que la extensión sea de un formato válido
                // Hay métodos más seguros para esto, como revisar los bytes iniciales del objeto, pero aquí estamos aplicando lo más sencillos
                string ext = fileUploader2.PostedFile.FileName;
                ext = ext.Substring(ext.LastIndexOf(".") + 1).ToLower();
                string[] formatos = new string[] { "jpg", "jpeg", "bmp", "png", "gif" };
                if (Array.IndexOf(formatos, ext) < 0)
                    throw new Exception("Formato de imagen inválido.");

                // Se guardará en carpeta o en base de datos, según lo indicado en el formulario

                GuardarArchivo(fileUploader2.PostedFile, false, 0);

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

        public static void GuardarArchivo(HttpPostedFile file, bool redimensionar, int tamano = 0)
        {
            // Se carga la ruta física de la carpeta temp del sitio
            string ruta = HttpContext.Current.Server.MapPath("~/imagenes/wsPromociones");

            // Si el directorio no existe, crearlo
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);

            string archivo = string.Format("{0}\\{1}", ruta, file.FileName);

            // Verificar que el archivo no exista
            // Si queremos eliminar la imagen existente, se debe usar File.Delete
            if (File.Exists(archivo))
                throw new Exception(string.Format("Ya existe una imagen con nombre \"{0}\".", file.FileName));
            else 
            {                
                file.SaveAs(archivo);
            }
        }

        protected void rblTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblTarjeta.SelectedValue == "1")
                {
                    txtTarjeta.Visible = true;
                }
                else
                {
                    txtTarjeta.Visible = false;
                }
            }
            catch
            { }
        }

        protected void rblTipoPromo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblTipoPromo.SelectedValue == "1")
                {
                    divImagenes.Visible = true;
                }
                else
                {
                    divImagenes.Visible = false;
                }
            }
            catch
            { }
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AccesoRep.aspx");
        }
    }
}