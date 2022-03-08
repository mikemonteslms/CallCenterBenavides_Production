using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPfizer.LMS.eCard.UserControls
{
    public partial class DetallePromo : System.Web.UI.UserControl
    {
        public string Contenido { get { return ltlContenido.Text; } set { ltlContenido.Text = value; } }
        public string TipoImage { get { return imgTipo.ImageUrl; } set { imgTipo.ImageUrl = value; } }
        public string Titulo { get { return lblTitulo.Text; } set { lblTitulo.Text = value; } }
        public string IDPromo { get { return hdnIDPromo.Value; } set { hdnIDPromo.Value = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}