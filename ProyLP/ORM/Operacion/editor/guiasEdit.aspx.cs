using CallCenterDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ORMOperacion.editor
{
    public partial class guiasEdit : System.Web.UI.Page
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
                Master.Menu = "Plantillas";
                Master.Submenu = "Guias";

                RadEditor1.ContentAreaCssFile = "~/Editor/EditorContentAreaStyles.css";
                RadEditor1.DisableFilter(EditorFilters.ConvertFontToSpan);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            csPrograma programa = new csPrograma();
            programa.ActualizaHTMLPlantilla(Int32.Parse(programas.SelectedValue), "plantilla_guia", RadEditor1.Content);
            editorText.Text = RadEditor1.Content;
        }

        protected void programas_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ID = "plantilla_contenido";
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;
            SqlDataSource1.SelectCommand = "SELECT plantilla_guia from programa where id = @programa_id";
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("programa_id", programas.SelectedValue);

            DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            string value = dvSql.ToTable().Rows[0][0].ToString();
            if (value.Equals(""))
            {
                string plantilla_guias_default = @"<main><h3>Guías y Tips</h3>

<p>Descarga las Guías y Tips que tenemos para ti.</p><br />

<div class=""bloque-ranking"" >
<h3 style=""font-size:1.1em;background:url(/images/icon-guias.jpg) 0px -2px no-repeat;padding: 0 0 7px 29px;"">Descarga de Guías</h3>
<div class=""link-pdf-descarga"" ><img src=""/images/pdf-icon.png"" /><a href=""/docs/Manual_Canje.pdf"" target=""_blank"">Manual de Canje</a></div>
<div class=""link-pdf-descarga"" ><img src=""/images/pdf-icon.png"" /><a href=""/docs/Manual_Acuse_recibo.pdf"" target=""_blank"">Manual de Acuse de recibo</a></div>
<div class=""link-pdf-descarga"" ><img src=""/images/pdf-icon.png"" /><a href=""/docs/Manual_Mecanica.pdf"" target=""_blank"">Manual de Mecánica</a></div>

    <asp:Panel id=""pnlGSF"" runat=""server"" visible=""false"">
<div class=""link-pdf-descarga"" ><img src=""/images/pdf-icon.png"" /><a href=""/docs/Proceso_Asignacion_Ventas.pdf"" target=""_blank"">Manual de Asignación de Venta</a></div>
</asp:Panel>
</div>

<div class=""bloque-ranking"">
<h3 style=""font-size:1.1em;background:url(/images/icon-tips.jpg) 0px -2px no-repeat;padding: 0 0 7px 29px;"">Descarga de Tips</h3>
</div>";
                RadEditor1.Content = plantilla_guias_default;
            }
            else
            {
                RadEditor1.Content = dvSql[0][0].ToString();
            }
        }
    }
}