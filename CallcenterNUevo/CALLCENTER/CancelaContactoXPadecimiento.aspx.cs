using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Web.Security;

namespace WebPfizer.LMS.eCard
{
    public partial class CancelaContactoXPadecimiento : System.Web.UI.Page
    {
        #region DECLARATIONS

        Clientes cliente = new Clientes();
        Catalogos catalogos = new Catalogos();
        Tarjetas tarjetas = new Tarjetas();
        string sUsuario = null;

        #endregion DECLARATIONS

        #region EVENTS

        #region btnAplicarSuscripion_Click

        protected void btnAplicarSuscripion_Click(object sender, EventArgs e)
        {
            try
            {
                int iValidacion = 0;

                //Valida que cuente con correo y celular
                //if (lblMailSeleccionado.Text == "&nbsp;" && lblTelCelularSeleccionado.Text == "&nbsp;")
                //{
                //    Mensajes("La tarjeta no tiene correo electrónico ni teléfono celular asociado");
                //    return;
                //}

                if (trPermisos_7.Visible == true)
                {
                    //if (lblMailSeleccionado.Text == "&nbsp;" && rdoCorreoE_7.SelectedValue == "0" || lblMailSeleccionado.Text == "&nbsp;" && rdoCorreoE_7.SelectedValue == "1")
                    //{
                    //    Mensajes("La tarjeta no tiene correo electrónico asociado");
                    //    return;
                    //}
                    //if (lblTelCelularSeleccionado.Text == "&nbsp;" && rdoCelular_7.SelectedValue == "0" || lblTelCelularSeleccionado.Text == "&nbsp;" && rdoCelular_7.SelectedValue == "1")
                    //{
                    //    Mensajes("La tarjeta no tiene teléfono celular asociado ");
                    //    return;
                    //}

                    int iPermisos7 = Convert.ToInt32(rdoCorreoE_7.SelectedValue) * 1 +
                                        Convert.ToInt32(rdoCelular_7.SelectedValue) * 2;
                    //+
                    //Convert.ToInt32(rdoTelPart_7.SelectedValue) * 4 +
                    //Convert.ToInt32(rdoCorreoP_7.SelectedValue) * 8;


                    iValidacion = tarjetas.ActualizaPadecimientosXTarjeta(lblTarjetaSeleccionado.Text, 7, iPermisos7, sUsuario, Convert.ToInt32(rdoCorreoE_7.SelectedValue), Convert.ToInt32(rdoCelular_7.SelectedValue));

                }

                if (trPermisos_1.Visible == true && iValidacion >= 0)
                {

                    //if (lblMailSeleccionado.Text == "&nbsp;" && rdoCorreoE_1.SelectedValue == "0" || lblMailSeleccionado.Text == "&nbsp;" && rdoCorreoE_1.SelectedValue == "1")
                    //{
                    //    Mensajes("La tarjeta no tiene correo electrónico asociado");
                    //    return;
                    //}
                    //if (lblTelCelularSeleccionado.Text == "&nbsp;" && rdoCelular_1.SelectedValue == "0" || lblTelCelularSeleccionado.Text == "&nbsp;" && rdoCelular_1.SelectedValue == "1")
                    //{
                    //    Mensajes("La tarjeta no tiene teléfono celular asociado ");
                    //    return;
                    //}

                    int iPermisos1 = Convert.ToInt32(rdoCorreoE_1.SelectedValue) * 1 +
                                        Convert.ToInt32(rdoCelular_1.SelectedValue) * 2;
                    //+
                    //Convert.ToInt32(rdoTelPart_1.SelectedValue) * 4 +
                    //Convert.ToInt32(rdoCorreoP_1.SelectedValue) * 8;


                    iValidacion = tarjetas.ActualizaPadecimientosXTarjeta(lblTarjetaSeleccionado.Text, 1, iPermisos1, sUsuario, Convert.ToInt32(rdoCorreoE_1.SelectedValue), Convert.ToInt32(rdoCelular_1.SelectedValue));
                }

                if (trPermisos_2.Visible == true && iValidacion >= 0)
                {
                    //if (lblMailSeleccionado.Text == "&nbsp;" && rdoCorreoE_2.SelectedValue == "0" || lblMailSeleccionado.Text == "&nbsp;" && rdoCorreoE_2.SelectedValue == "1")
                    //{
                    //    Mensajes("La tarjeta no tiene correo electrónico asociado");
                    //    return;
                    //}
                    //if (lblTelCelularSeleccionado.Text == "&nbsp;" && rdoCelular_2.SelectedValue == "0" || lblTelCelularSeleccionado.Text == "&nbsp;" && rdoCelular_2.SelectedValue == "1")
                    //{
                    //    Mensajes("La tarjeta no tiene teléfono celular asociado ");
                    //    return;
                    //}

                    int iPermisos2 = Convert.ToInt32(rdoCorreoE_2.SelectedValue) * 1 +
                                        Convert.ToInt32(rdoCelular_2.SelectedValue) * 2;
                    //+
                    //Convert.ToInt32(rdoTelPart_2.SelectedValue) * 4 +
                    //Convert.ToInt32(rdoCorreoP_2.SelectedValue) * 8;


                    iValidacion = tarjetas.ActualizaPadecimientosXTarjeta(lblTarjetaSeleccionado.Text, 2, iPermisos2, sUsuario, Convert.ToInt32(rdoCorreoE_2.SelectedValue), Convert.ToInt32(rdoCelular_2.SelectedValue));
                }

                if (trPermisos_3.Visible == true && iValidacion >= 0)
                {
                    //if (lblMailSeleccionado.Text == "&nbsp;" && rdoCorreoE_3.SelectedValue == "0" || lblMailSeleccionado.Text == "&nbsp;" && rdoCorreoE_3.SelectedValue == "1")
                    //{
                    //    Mensajes("La tarjeta no tiene correo electrónico asociado");
                    //    return;
                    //}
                    //if (lblTelCelularSeleccionado.Text == "&nbsp;" && rdoCelular_3.SelectedValue == "0" || lblTelCelularSeleccionado.Text == "&nbsp;" && rdoCelular_3.SelectedValue == "1")
                    //{
                    //    Mensajes("La tarjeta no tiene teléfono celular asociado ");
                    //    return;
                    //}

                    int iPermisos3 = Convert.ToInt32(rdoCorreoE_3.SelectedValue) * 1 +
                                        Convert.ToInt32(rdoCelular_3.SelectedValue) * 2;
                    //+
                    //                    Convert.ToInt32(rdoTelPart_3.SelectedValue) * 4 +
                    //                    Convert.ToInt32(rdoCorreoP_3.SelectedValue) * 8;

                    iValidacion = tarjetas.ActualizaPadecimientosXTarjeta(lblTarjetaSeleccionado.Text, 3, iPermisos3, sUsuario, Convert.ToInt32(rdoCorreoE_3.SelectedValue), Convert.ToInt32(rdoCelular_3.SelectedValue));
                }

                if (trPermisos_5.Visible == true && iValidacion >= 0)
                {

                    //if (lblMailSeleccionado.Text == "&nbsp;" && rdoCorreoE_5.SelectedValue == "0" || lblMailSeleccionado.Text == "&nbsp;" && rdoCorreoE_5.SelectedValue == "1")
                    //{
                    //    Mensajes("La tarjeta no tiene correo electrónico asociado");
                    //    return;
                    //}
                    //if (lblTelCelularSeleccionado.Text == "&nbsp;" && rdoCelular_5.SelectedValue == "0" || lblTelCelularSeleccionado.Text == "&nbsp;" && rdoCelular_5.SelectedValue == "1")
                    //{
                    //    Mensajes("La tarjeta no tiene teléfono celular asociado ");
                    //    return;
                    //}

                    int iPermisos5 = Convert.ToInt32(rdoCorreoE_5.SelectedValue) * 1 +
                                        Convert.ToInt32(rdoCelular_5.SelectedValue) * 2;
                    //+
                    //                    Convert.ToInt32(rdoTelPart_5.SelectedValue) * 4 +
                    //                    Convert.ToInt32(rdoCorreoP_5.SelectedValue) * 8;


                    iValidacion = tarjetas.ActualizaPadecimientosXTarjeta(lblTarjetaSeleccionado.Text, 5, iPermisos5, sUsuario, Convert.ToInt32(rdoCorreoE_5.SelectedValue), Convert.ToInt32(rdoCelular_5.SelectedValue));

                }

                if (trPermisos_6.Visible == true && iValidacion >= 0)
                {
                    //if (lblMailSeleccionado.Text == "&nbsp;" && rdoCorreoE_6.SelectedValue == "0" || lblMailSeleccionado.Text == "&nbsp;" && rdoCorreoE_6.SelectedValue == "1")
                    //{
                    //    Mensajes("La tarjeta no tiene correo electrónico asociado");
                    //    return;
                    //}
                    //if (lblTelCelularSeleccionado.Text == "&nbsp;" && rdoCelular_6.SelectedValue == "0" || lblTelCelularSeleccionado.Text == "&nbsp;" && rdoCelular_6.SelectedValue == "1")
                    //{
                    //    Mensajes("La tarjeta no tiene teléfono celular asociado ");
                    //    return;
                    //}

                    int iPermisos6 = Convert.ToInt32(rdoCorreoE_6.SelectedValue) * 1 +
                                        Convert.ToInt32(rdoCelular_6.SelectedValue) * 2;
                    //+
                    //                    Convert.ToInt32(rdoTelPart_6.SelectedValue) * 4 +
                    //                    Convert.ToInt32(rdoCorreoP_6.SelectedValue) * 8;

                    iValidacion = tarjetas.ActualizaPadecimientosXTarjeta(lblTarjetaSeleccionado.Text, 6, iPermisos6, sUsuario, Convert.ToInt32(rdoCorreoE_6.SelectedValue), Convert.ToInt32(rdoCelular_6.SelectedValue));

                }

                //switch (iValidacion)
                //{

                //    case  1:
                //        divTarjetaSeleccionada.Visible = false;
                //        divSeleccionTarjeta.Visible = true;

                //        Mensajes("Se actualizaron las suscripciones");
                //        break;

                //    case -2:
                //        Mensajes("La tarjeta no tiene correo electrónico asociado");
                //        break;

                //    case -3:
                //        Mensajes("La tarjeta no tiene teléfono celular asociado");
                //    break;

                //    case -4:
                //        Mensajes("La tarjeta no tiene correo electrónico ni teléfono celular asociado");
                //    break;

                //    case -99:
                //        Mensajes("Error al actualizar las suscripciones");
                //    break; 
                //}


                if (iValidacion > 0)
                {
                    divTarjetaSeleccionada.Visible = false;
                    divSeleccionTarjeta.Visible = true;

                    Mensajes("Se actualizaron las suscripciones");
                }
                else
                    Mensajes("No fue posible actualizar las suscripciones");
            }
            catch
            {
                Mensajes("Error al actualizar las suscripciones");
            }
        }

        #endregion btnAplicarSuscripion_Click

        #region btnBuscar_Click

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMail.Text.Trim() != String.Empty || txtTarjeta.Text.Trim() != String.Empty ||
                    txtTelefonoCasa.Text.Trim() != String.Empty || txtTelefonoCelular.Text.Trim() != String.Empty)
                {
                    divTarjetaSeleccionada.Visible = false;
                    divSeleccionTarjeta.Visible = true;
                    trPermisos_7.Visible = false;
                    trPermisos_1.Visible = false;
                    trPermisos_2.Visible = false;
                    trPermisos_3.Visible = false;
                    trPermisos_5.Visible = false;
                    trPermisos_6.Visible = false;
                    gvTarjetas.DataSource = cliente.BusquedaCliente(txtTarjeta.Text.Trim(), txtMail.Text.Trim(), txtTelefonoCasa.Text.Trim(), txtTelefonoCelular.Text.Trim());
                    gvTarjetas.DataBind();
                    rdoCorreoE_7.Items[0].Enabled = true;
                    rdoCelular_7.Items[0].Enabled = true;
                    btnAplicarSuscripion.Enabled = true;
                }
                else
                {
                    Mensajes("Capture al menos un parámetro de búsqueda");
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }

        #endregion btnBuscar_Click

        #region btnCancelar_Click

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        #endregion btnCancelar_Click

        #region btnCancelarSus_Click

        protected void btnCancelarSus_Click(object sender, EventArgs e)
        {
            divSeleccionTarjeta.Visible = true;
            divTarjetaSeleccionada.Visible = false;
            trPermisos_7.Visible = false;
            trPermisos_1.Visible = false;
            trPermisos_2.Visible = false;
            trPermisos_3.Visible = false;
            trPermisos_5.Visible = false;
            trPermisos_6.Visible = false;
        }

        #endregion btnCancelarSus_Click

        #region gvTarjetas_RowCommand

        protected void gvTarjetas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "seleccionar":
                    divSeleccionTarjeta.Visible = false;
                    divTarjetaSeleccionada.Visible = true;
                    lblTarjetaSeleccionado.Text = e.CommandArgument.ToString().Split('|')[0];
                    lblNombreSeleccionado.Text = e.CommandArgument.ToString().Split('|')[1] +
                                                    " " + e.CommandArgument.ToString().Split('|')[2] +
                                                    " " + e.CommandArgument.ToString().Split('|')[3];

                    ////lblPaternoSeleccionado.Text = e.CommandArgument.ToString().Split('|')[2];
                    ////lblMaternoSeleccionado.Text = e.CommandArgument.ToString().Split('|')[3];
                    lblTelCasaSeleccionado.Text = e.CommandArgument.ToString().Split('|')[6];
                    lblTelCelularSeleccionado.Text = e.CommandArgument.ToString().Split('|')[7];
                    lblMailSeleccionado.Text = e.CommandArgument.ToString().Split('|')[8];

                    DataSet datasetPadecimientosXTarjeta = tarjetas.PadecimientosXTarjeta(lblTarjetaSeleccionado.Text);

                    if (datasetPadecimientosXTarjeta != null)
                    {
                        if (datasetPadecimientosXTarjeta.Tables.Count > 0)
                        {
                            if (datasetPadecimientosXTarjeta.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in datasetPadecimientosXTarjeta.Tables[0].Rows)
                                {
                                    trPermisos_7.Visible = true;
                                    rdoCorreoE_7.SelectedValue = (dr[0].ToString() == "False" ? "0" : "1");
                                    rdoCelular_7.SelectedValue = (dr[1].ToString() == "False" ? "0" : "1");

                                    //if (dr[0].ToString() == "False")
                                    //{
                                    //    rdoCorreoE_7.Items[0].Enabled = false;
                                    //}

                                    //if (dr[1].ToString() == "False")
                                    //{
                                    //    rdoCelular_7.Items[0].Enabled = false;
                                    //}

                                    //if (dr[0].ToString() == "False" && dr[1].ToString() == "False")
                                    //{
                                    //    btnAplicarSuscripion.Enabled = false;
                                    //}
                                }
                            }
                            else
                            {
                                Mensajes("La tarjeta proporcionada no existe...");
                            }
                        }
                    }
                    else 
                    {
                        Mensajes("No existen Resultados...");  
                    }
                    break;
            }

        }

        #endregion gvTarjetas_RowCommand

        #region gvTarjetas_RowDataBound

        protected void gvTarjetas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (!(e.Row.RowType == DataControlRowType.EmptyDataRow))
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        ((ImageButton)e.Row.FindControl("cmdSeleccionar")).CommandArgument = e.Row.Cells[1].Text + "|" + e.Row.Cells[5].Text + "|" + e.Row.Cells[6].Text + "|" +
                                                                                                 e.Row.Cells[7].Text + "|" + e.Row.Cells[8].Text + "|" + e.Row.Cells[9].Text + "|" +
                                                                                                 e.Row.Cells[10].Text + "|" + e.Row.Cells[11].Text + "|" + e.Row.Cells[12].Text;
                    }
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                }
            }
            catch (Exception)
            {
                Mensajes("Error al cargar los clientes. Intenta refrescar la página");
            }
        }

        #endregion gvTarjetas_RowDataBound

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Session["UsuarioCC"] == null)
                //{
                //    FormsAuthentication.SignOut();
                //    FormsAuthentication.RedirectToLoginPage();
                //    return;
                //}
                //else
                //{
                //    sUsuario = Session["UsuarioCC"].ToString();
                //}
                Master.MenuMain = "Clientes";
                Master.Submenu = "Suscripciones";
                sUsuario = HttpContext.Current.User.Identity.Name;
                if (!Page.IsPostBack)
                {
                    if (Session["strTarjeta"] != null)
                    {
                        txtTarjeta.Text = Session["strTarjeta"].ToString();
                        btnBuscar_Click(btnBuscar, new EventArgs());
                    }
                }
            }
            catch
            {
            }
        }

        #endregion Page_Load

        #endregion EVENTS

        #region METHODS

        #region Mensajes

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        #endregion Mensajes

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMail.Text = "";
            txtTarjeta.Text = "";
            txtTelefonoCasa.Text = "";
            txtTelefonoCelular.Text = "";

            Session["strTarjeta"] = null;
        }

        #endregion METHODS


         //Se  resguarda código a fin de tener referencia de como se encontraba antes del ajuste
         //if (datasetPadecimientosXTarjeta.Tables[0].Rows.Count > 0)
         //           {
         //               foreach (DataRow dr in datasetPadecimientosXTarjeta.Tables[0].Rows)
         //               {
         //                   switch (dr[1].ToString())
         //                   {
         //                       case "7":
         //                           trPermisos_7.Visible = true;
         //                           rdoCorreoE_7.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 1) > 0 ? "1" : "0");
         //                           rdoCelular_7.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 2) > 0 ? "1" : "0");
         //                           rdoTelPart_7.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 4) > 0 ? "1" : "0");
         //                           rdoCorreoP_7.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 8) > 0 ? "1" : "0");
         //                           break;
         //                       case "1":
         //                           trPermisos_1.Visible = true;
         //                           rdoCorreoE_1.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 1) > 0 ? "1" : "0");
         //                           rdoCelular_1.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 2) > 0 ? "1" : "0");
         //                           rdoTelPart_1.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 4) > 0 ? "1" : "0");
         //                           rdoCorreoP_1.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 8) > 0 ? "1" : "0");
         //                           break;
         //                       case "2":
         //                           trPermisos_2.Visible = true;
         //                           rdoCorreoE_2.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 1) > 0 ? "1" : "0");
         //                           rdoCelular_2.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 2) > 0 ? "1" : "0");
         //                           rdoTelPart_2.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 4) > 0 ? "1" : "0");
         //                           rdoCorreoP_2.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 8) > 0 ? "1" : "0");
         //                           break;
         //                       case "3":
         //                           trPermisos_3.Visible = true;
         //                           rdoCorreoE_3.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 1) > 0 ? "1" : "0");
         //                           rdoCelular_3.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 2) > 0 ? "1" : "0");
         //                           rdoTelPart_3.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 4) > 0 ? "1" : "0");
         //                           rdoCorreoP_3.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 8) > 0 ? "1" : "0");
         //                           break;
         //                       case "5":
         //                           trPermisos_5.Visible = true;
         //                           rdoCorreoE_5.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 1) > 0 ? "1" : "0");
         //                           rdoCelular_5.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 2) > 0 ? "1" : "0");
         //                           rdoTelPart_5.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 4) > 0 ? "1" : "0");
         //                           rdoCorreoP_5.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 8) > 0 ? "1" : "0");
         //                           break;
         //                       case "6":
         //                           trPermisos_6.Visible = true;
         //                           rdoCorreoE_6.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 1) > 0 ? "1" : "0");
         //                           rdoCelular_6.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 2) > 0 ? "1" : "0");
         //                           rdoTelPart_6.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 4) > 0 ? "1" : "0");
         //                           rdoCorreoP_6.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 8) > 0 ? "1" : "0");
         //                           break;
         //                   }
         //               }
         //           }
         //           else
         //           {
         //               Mensajes("No padecimientos asociados a la tarjeta");
         //           }

         //           break;


    }
}