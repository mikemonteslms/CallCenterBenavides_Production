using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WebPfizer.LMS.eCard
{
    public partial class CancelarMisSuscripciones : System.Web.UI.Page
    {
        #region DECLARATIONS

        Tarjetas tarjetas = new Tarjetas();

        #endregion DECLARATIONS

        #region EVENTS

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sUsuario = null;
                string sCorreo = null;
                string sPadecimiento = null;
                StringBuilder sbMensaje = new StringBuilder();

                sUsuario = Request.QueryString["tarjeta"];
                sCorreo = Request.QueryString["correo"];
                sPadecimiento = Request.QueryString["padecimiento"];

                sbMensaje.AppendLine("¡Hola!<br />");

                if (sUsuario.Trim() != string.Empty && sCorreo.Trim() != string.Empty && sPadecimiento.Trim() != string.Empty)
                {
                    //if (tarjetas.CancelaSuscripcionDeCorreo(sUsuario, Convert.ToInt16(sPadecimiento), sUsuario) > 0)
                    //{
                    //    sbMensaje.AppendLine("Te informamos que dimos de baja el correo " + sCorreo + " de nuestra lista de envíos.<br />");
                    //    sbMensaje.AppendLine("Si deseas inscribirte nuevamente comunícate a nuestro Centro de Atención o bien escríbenos.<br />");
                    //    sbMensaje.AppendLine("Gracias<br />");
                    //}
                    //else
                    //{
                    //    sbMensaje.AppendLine("El correo " + sCorreo + " ya ha sido dado de baja de nuestra lista de envíos.<br />");
                    //    sbMensaje.AppendLine("Ante cualquier duda o aclaración comunícate con nosotros o bien escríbenos.<br />");
                    //}
                    sbMensaje.AppendLine(tarjetas.CancelaSuscripcionDeCorreo(sUsuario, Convert.ToInt16(sPadecimiento), sUsuario).ToString());
                }
                else
                {
                    sbMensaje.AppendLine("Sus datos están incompletos o son erróneos<br />");
                }

                ltrMensaje.Text = sbMensaje.ToString();
            }
            catch
            {
                Mensajes("Error al cancelar su suscripción");
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