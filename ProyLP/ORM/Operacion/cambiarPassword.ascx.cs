using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ORMOperacion
{
    public partial class cambiarPassword : System.Web.UI.UserControl
    {
        public string Usuario
        {
            get
            {
                return (lblUsuario.Text);
            }
            set
            {
                lblUsuario.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            MembershipUser u = Membership.GetUser();

            
            bool respuesta = u.ChangePassword(txtCActual.Text, txtContraseña.Text);

            if (respuesta)
            {
                //Close the active ToolTip.
                ScriptManager.RegisterClientScriptBlock(
                    this.Page,
                    this.GetType(),
                    "WebUserControlSript",
                    "alert('La contraseña ha sido cambiada.'); CloseActiveToolTip('" + this.ID + "')",
                    true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(
                    this.Page,
                    this.GetType(),
                    "WebUserControlSript",
                    "alert('La contraseña actual no es correcta.'); ",
                    true);
            }
        }
    }
}