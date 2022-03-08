using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WebPfizer.LMS.eCard
{
    public partial class MisSuscripciones : System.Web.UI.Page
    {
        #region DECLARATIONS

        Tarjetas tarjetas = new Tarjetas();
        string sUsuario = null;

        #endregion DECLARATIONS

        #region EVENTS

        #region btnRegistrarSuscripion_Click

        protected void btnRegistrarSuscripion_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int iValidacion = 0;
                if (trPermisos_7.Visible == true)
                {
                    int iPermisos7 = Convert.ToInt32(rdoCorreoE_7.SelectedValue) * 1 +
                                        Convert.ToInt32(rdoCelular_7.SelectedValue) * 2 +
                                        Convert.ToInt32(rdoTelPart_7.SelectedValue) * 4 +
                                        Convert.ToInt32(rdoCorreoP_7.SelectedValue) * 8;

                    if (tarjetas.ActualizaPadecimientosXTarjeta(sUsuario, 7, iPermisos7, sUsuario) > 0)
                        iValidacion = 1;
                    else
                        iValidacion = -1;

                }

                if (trPermisos_1.Visible == true && iValidacion >= 0)
                {
                    int iPermisos1 = Convert.ToInt32(rdoCorreoE_1.SelectedValue) * 1 +
                                        Convert.ToInt32(rdoCelular_1.SelectedValue) * 2 +
                                        Convert.ToInt32(rdoTelPart_1.SelectedValue) * 4 +
                                        Convert.ToInt32(rdoCorreoP_1.SelectedValue) * 8;

                    if (tarjetas.ActualizaPadecimientosXTarjeta(sUsuario, 1, iPermisos1, sUsuario) > 0)
                        iValidacion = 1;
                    else
                        iValidacion = -1;
                }

                if (trPermisos_2.Visible == true && iValidacion >= 0)
                {
                    int iPermisos2 = Convert.ToInt32(rdoCorreoE_2.SelectedValue) * 1 +
                                        Convert.ToInt32(rdoCelular_2.SelectedValue) * 2 +
                                        Convert.ToInt32(rdoTelPart_2.SelectedValue) * 4 +
                                        Convert.ToInt32(rdoCorreoP_2.SelectedValue) * 8;

                    if (tarjetas.ActualizaPadecimientosXTarjeta(sUsuario, 2, iPermisos2, sUsuario) > 0)
                        iValidacion = 1;
                    else
                        iValidacion = -1;
                }

                if (trPermisos_3.Visible == true && iValidacion >= 0)
                {
                    int iPermisos3 = Convert.ToInt32(rdoCorreoE_3.SelectedValue) * 1 +
                                        Convert.ToInt32(rdoCelular_3.SelectedValue) * 2 +
                                        Convert.ToInt32(rdoTelPart_3.SelectedValue) * 4 +
                                        Convert.ToInt32(rdoCorreoP_3.SelectedValue) * 8;

                    if (tarjetas.ActualizaPadecimientosXTarjeta(sUsuario, 3, iPermisos3, sUsuario) > 0)
                        iValidacion = 1;
                    else
                        iValidacion = -1;
                }

                if (trPermisos_5.Visible == true && iValidacion >= 0)
                {
                    int iPermisos5 = Convert.ToInt32(rdoCorreoE_5.SelectedValue) * 1 +
                                        Convert.ToInt32(rdoCelular_5.SelectedValue) * 2 +
                                        Convert.ToInt32(rdoTelPart_5.SelectedValue) * 4 +
                                        Convert.ToInt32(rdoCorreoP_5.SelectedValue) * 8;

                    if (tarjetas.ActualizaPadecimientosXTarjeta(sUsuario, 5, iPermisos5, sUsuario) > 0)
                        iValidacion = 1;
                    else
                        iValidacion = -1;
                }

                if (trPermisos_6.Visible == true && iValidacion >= 0)
                {
                    int iPermisos6 = Convert.ToInt32(rdoCorreoE_6.SelectedValue) * 1 +
                                        Convert.ToInt32(rdoCelular_6.SelectedValue) * 2 +
                                        Convert.ToInt32(rdoTelPart_6.SelectedValue) * 4 +
                                        Convert.ToInt32(rdoCorreoP_6.SelectedValue) * 8;

                    if (tarjetas.ActualizaPadecimientosXTarjeta(sUsuario, 6, iPermisos6, sUsuario) > 0)
                        iValidacion = 1;
                    else
                        iValidacion = -1;
                }

                if (iValidacion > 0)
                {
                    Mensajes("¡Hola!\\nHemos actualizado tus medios de contacto.\\nAnte cualquier duda comunícate a nuestro Centro de Atención o bien escríbenos.");
                }
                else
                    Mensajes("Error al actualizar tus medios de contacto.");
            }
            catch
            {
                Mensajes("Error al actualizar tus medios de contacto.");
            }
        }

        #endregion btnRegistrarSuscripion_Click

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Acceso.aspx", true);
                }
                else
                {
                    sUsuario = Session["Usuario"].ToString();
                }

                if (!IsPostBack)
                {
                    DataSet datasetPadecimientosXTarjeta = tarjetas.PadecimientosXTarjeta(sUsuario);

                    if (datasetPadecimientosXTarjeta.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in datasetPadecimientosXTarjeta.Tables[0].Rows)
                        {
                            switch (dr[1].ToString())
                            {
                                case "7":
                                    trPermisos_7.Visible = true;
                                    rdoCorreoE_7.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 1) > 0 ? "1" : "0");
                                    rdoCelular_7.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 2) > 0 ? "1" : "0");
                                    rdoTelPart_7.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 4) > 0 ? "1" : "0");
                                    rdoCorreoP_7.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 8) > 0 ? "1" : "0");
                                    break;
                                case "1":
                                    trPermisos_1.Visible = true;
                                    rdoCorreoE_1.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 1) > 0 ? "1" : "0");
                                    rdoCelular_1.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 2) > 0 ? "1" : "0");
                                    rdoTelPart_1.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 4) > 0 ? "1" : "0");
                                    rdoCorreoP_1.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 8) > 0 ? "1" : "0");
                                    break;
                                case "2":
                                    trPermisos_2.Visible = true;
                                    rdoCorreoE_2.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 1) > 0 ? "1" : "0");
                                    rdoCelular_2.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 2) > 0 ? "1" : "0");
                                    rdoTelPart_2.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 4) > 0 ? "1" : "0");
                                    rdoCorreoP_2.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 8) > 0 ? "1" : "0");
                                    break;
                                case "3":
                                    trPermisos_3.Visible = true;
                                    rdoCorreoE_3.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 1) > 0 ? "1" : "0");
                                    rdoCelular_3.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 2) > 0 ? "1" : "0");
                                    rdoTelPart_3.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 4) > 0 ? "1" : "0");
                                    rdoCorreoP_3.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 8) > 0 ? "1" : "0");
                                    break;
                                case "5":
                                    trPermisos_5.Visible = true;
                                    rdoCorreoE_5.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 1) > 0 ? "1" : "0");
                                    rdoCelular_5.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 2) > 0 ? "1" : "0");
                                    rdoTelPart_5.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 4) > 0 ? "1" : "0");
                                    rdoCorreoP_5.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 8) > 0 ? "1" : "0");
                                    break;
                                case "6":
                                    trPermisos_6.Visible = true;
                                    rdoCorreoE_6.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 1) > 0 ? "1" : "0");
                                    rdoCelular_6.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 2) > 0 ? "1" : "0");
                                    rdoTelPart_6.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 4) > 0 ? "1" : "0");
                                    rdoCorreoP_6.SelectedValue = ((Convert.ToInt32(dr[3].ToString()) & 8) > 0 ? "1" : "0");
                                    break;
                            }
                        }
                    }
                }
            }
            catch
            {
                Mensajes("Error al cargar sus suscripciones");
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

        #endregion METHODS
    }
}