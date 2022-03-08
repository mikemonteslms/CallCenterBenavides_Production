using EntitiesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ORMOperacion
{
    public partial class mantenimientoprogramas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            if (!IsPostBack)
            {
                Master.Menu = "Parametros";
                Master.Submenu = "Programas";
            }
        }

        protected void OAPrograma_Inserting(object sender, Telerik.OpenAccess.Web.OpenAccessLinqDataSourceInsertEventArgs e)
        {
            using (EntitiesModel.EntitiesModel context = new EntitiesModel.EntitiesModel())
            {
                MembershipUser u = Membership.GetUser();
                programa programa = e.NewObject as programa;
                if (programa != null)
                {
                    //pregunta.nombre = ((TextBox)DetailsViewPregunta.FindControl("nombrePregunta")).Text.ToString();
                    //pregunta.orden = Convert.ToInt32(((TextBox)DetailsViewPregunta.FindControl("preguntaOrden")).Text.ToString());
                    programa.usuario_alta_id = (Guid)u.ProviderUserKey;
                    //programa.status_id = 1;
                    //programa.fecha_status = DateTime.Now;
                    programa.fecha_alta = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }

        protected void OAPrograma_Updating(object sender, Telerik.OpenAccess.Web.OpenAccessLinqDataSourceUpdateEventArgs e)
        {
            using (EntitiesModel.EntitiesModel context = new EntitiesModel.EntitiesModel())
            {
                MembershipUser u = Membership.GetUser();
                programa programa = e.NewObject as programa;
                programa.fecha_cambio = DateTime.Now;
                programa.usuario_cambio_id = (Guid)u.ProviderUserKey;
                context.SaveChanges();
            }
        }
    }
}