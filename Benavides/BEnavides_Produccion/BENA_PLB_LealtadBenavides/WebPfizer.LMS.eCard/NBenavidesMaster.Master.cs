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

namespace WebPfizer.LMS.eCard
{
    public partial class NBenavidesMaster : System.Web.UI.MasterPage
    {
        DataSet objDataset = new DataSet();
        ValidaAcceso validaAcceso = new ValidaAcceso();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["Usuario"] == null)
                    {
                        Response.Redirect("Acceso.aspx");
                    }
                    btnCerrarSesion.Attributes.Add("onmouseover", "this.src='ImagenesVerBoom/Master/btn-cerrar-sesion-hover.jpg'");
                    btnCerrarSesion.Attributes.Add("onmouseout", "this.src='ImagenesVerBoom/Master/btn-cerrar-sesion.jpg'");

                    string tarjeta = Session["Usuario"].ToString();
                    string prefijo = tarjeta.Substring(0, 2);
                    string prefijo2 = tarjeta.Substring(0, 3);
                    string peques = Session["Peques"].ToString();
                    objDataset = validaAcceso.ObtenerInformacionTarjeta(tarjeta);

                    //MenuItem menu= new MenuItem();
                    //menu.Text="prueba";
                    //Menu1.Items.Add(menu);

                    if (objDataset.Tables.Count > 0)
                    {
                        if (objDataset.Tables[0].Rows.Count > 0)
                        {
                            string nivel = objDataset.Tables[0].Rows[0]["ProgramaNuevo"].ToString();
                            string nivel_base = objDataset.Tables[0].Rows[0]["NivelActual"].ToString();
                            if (nivel == "0" || nivel_base == "BASE")
                            {
                                lblNiv.Visible = false;
                                lblNivelActual.Visible = false;
                                lbltefaltan.Visible = false;
                                lblBoomerangsFaltantes.Visible = false;
                                lblboom.Visible = false;
                                lblllegar.Visible = false;
                                lblSiguienteNivel.Visible = false;
                                //imgTermometro.Visible = false;
                            }
                            imgTarjeta.ImageUrl = "~/ImagenesVerBoom/Master/tarjeta15.png";

                            if (prefijo == "13")
                            {
                                imgTarjeta.ImageUrl = "~/ImagenesVerBoom/Master/tarjeta15.png";
                            }
                            if (prefijo2 == "133")
                            {
                                imgTarjeta.ImageUrl = "~/ImagenesVerBoom/Master/tarjeta16.png";
                            }
                            if (prefijo2 == "131")
                            {
                                Menu1.Items[0].ChildItems.RemoveAt(2);
                            }
                            if (peques == "1")
                            {
                                Menu1.Items[0].ChildItems[2].Text = "&nbsp;&nbsp;&nbsp;Actualiza tus datos&nbsp;&nbsp;&nbsp;";
                            }
                            if (prefijo == "15")
                            {
                                imgTarjeta.ImageUrl = "~/ImagenesVerBoom/Master/tarjeta15.png";
                            }
                            if (prefijo == "16")
                            {
                                imgTarjeta.ImageUrl = "~/ImagenesVerBoom/Master/tarjeta16.png";
                            }
                            string url = "~/ImagenesVerBoom/Master/img-termometro/" + objDataset.Tables[0].Rows[0]["Sufijo"].ToString();

                            //lblNombre.Text = objDataset.Tables[0].Rows[0]["NivelActual"].ToString();
                            //imgTermometro.ImageUrl = objDataset.Tables[0].Rows[0]["Sufijo"].ToString();                        
                            imgTerm.ImageUrl = "~/ImagenesVerBoom/Master/img-termometro/" + objDataset.Tables[0].Rows[0]["Sufijo"].ToString();
                            lblNB.Text = objDataset.Tables[0].Rows[0]["BoomerangsAcumulados"].ToString();
                            lblNivelActual.Text = objDataset.Tables[0].Rows[0]["NivelActual"].ToString();
                            lblSiguienteNivel.Text = objDataset.Tables[0].Rows[0]["SiguienteNivel"].ToString();
                            lblBoomerangsFaltantes.Text = objDataset.Tables[0].Rows[0]["BoomerangsFaltantes"].ToString();
                            lblNombre.Text = objDataset.Tables[0].Rows[0]["Nombre"].ToString();
                            lblSaldo.Text = objDataset.Tables[0].Rows[0]["SaldoActual"].ToString();
                            lblNumeroTarjeta.Text = tarjeta;
                            lblMensajeNivel.Text = objDataset.Tables[0].Rows[0]["MensajeUnico"].ToString();
                            lblEsPeques.Text = "Inscrito a Club Peques: " + objDataset.Tables[0].Rows[0]["Peques"].ToString();
                            lblBoomerangActuales.Text = "Boomerangs acumulados: <strong>" + objDataset.Tables[0].Rows[0]["BoomerangsAcumulados"].ToString() + "</strong>";
                            Session["ConfirmoMail"] = objDataset.Tables[0].Rows[0]["NivelActual"].ToString();

                            DataTable tblDatos = Clientes.GetCumpleaños(tarjeta);
                            DataRow[] tblDatosTemp = tblDatos.Select("WEBPromoPortalTarjeta_intContadorVistas < 2");
                            lblCantNot.Text = tblDatos.Rows.Count.ToString();
                            Session["Cat"] = null;
                            if (tblDatosTemp.Length > 0)
                            {
                                ibtnNotificaciones.ImageUrl = "~/ImagenesVerBoom/Master/Notificaciones/bi_notificaciónweb_260116.png";
                                //Produccion --> Se quita para pruebas
                                //Menu2.Items[0].ChildItems[3].NavigateUrl = "~/Promociones.aspx?ID=6";
                                //Menu1.Items[0].ChildItems[1].NavigateUrl = "~/Promociones.aspx?ID=6";
                                //if (Session["Peques"] != null)
                                //{
                                //    if (Convert.ToInt32(Session["Peques"].ToString()) < 1)
                                //    {
                                //        Menu1.Items[0].ChildItems[1].NavigateUrl = "~/Promociones.aspx?ID=100";
                                //    }
                                //}
                                //else
                                //{
                                //    Menu1.Items[0].ChildItems[1].NavigateUrl = "~/Promociones.aspx?ID=6";

                                //}
                            }
                            else
                            {
                                ibtnNotificaciones.ImageUrl = "~/ImagenesVerBoom/Master/Notificaciones/bi_notificaciónweb_260116-hover.png";
                                //Produccion --> Se quita para pruebas por correcion de bugs
                                //if (Session["Peques"] != null)
                                //    if (Convert.ToInt32(Session["Peques"].ToString()) > 0)
                                //    {
                                //        Session["Cat"] = 100;
                                //        Menu2.Items[0].ChildItems[3].NavigateUrl = "~/Promociones.aspx?ID=0";
                                //        Menu1.Items[0].ChildItems[1].NavigateUrl = "~/Promociones.aspx?ID=100";
                                //    }
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        protected void btnInicio_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btnInicio_Click1(object sender, ImageClickEventArgs e)
        {
            try
            {
                Response.Redirect("Index.aspx");
            }
            catch
            { }
        }

        //protected void btnContacto_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        Response.Redirect("Contacto.aspx");
        //    }
        //    catch
        //    { }
        //}

        protected void btnCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Session["Usuario"] = null;
                Response.Redirect("Acceso.aspx");
            }
            catch
            { }
        }

        protected void btnMisDatos_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MisDatos.aspx");
        }

        protected void btnMisCompras_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MisCompras.aspx");
        }

        protected void btnMisBeneficios_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MisBeneficios.aspx");
        }
    }
}