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
    public partial class comentariosEdit : System.Web.UI.Page
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
                Master.Submenu = "Comentarios";

                RadEditor1.ContentAreaCssFile = "~/Editor/EditorContentAreaStyles.css";
                RadEditor1.DisableFilter(EditorFilters.ConvertFontToSpan);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            csPrograma programa = new csPrograma();
            programa.ActualizaHTMLPlantilla(Int32.Parse(programas.SelectedValue), "plantilla_comentario", RadEditor1.Content);
            editorText.Text = RadEditor1.Content;
        }

        protected void programas_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ID = "plantilla_contenido";
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;
            SqlDataSource1.SelectCommand = "SELECT plantilla_comentario from programa where id = @programa_id";
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("programa_id", programas.SelectedValue);

            DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            string value = dvSql.ToTable().Rows[0][0].ToString();
            if (value.Equals(""))
            {
                string plantilla_comentarios_default = @"<style>
        body {
            font-family: Arial;
            color: #1F497D;
            font-size: 14px;
        }
    </style>
    <table>
        <tr>
            <td>
                <img src=""http://galenialp.lms-la.com/img/logo.jpg"" width=""172"" height=""110"" />
            </td>            
        </tr>
        <tr>
            <td colspan=""2"">
                <h3>
                Comentarios Galenia Loyalty Program</h3>
                <p></p>
                <table>
                    <tr>
                        <td width=""140px"">Nombre;</td>
                        <td width=""300px"">@NOMBRE</td>
                    </tr>
                    <tr>
                        <td>Clave:</td>
                        <td>@CLAVE</td>
                    </tr>
                    <tr>
                        <td>Correo electrónico:</td>
                        <td>@EMAIL</td>
                    </tr>
                    <tr>
                        <td>Teléfono:</td>
                        <td>@TELEFONO</td>
                    </tr>
                    <tr>
                        <td>Tipo comentario:</td>
                        <td>@TIPOMENSAJE</td>
                    </tr>
                    <tr>
                        <td>Comentarios:</td>
                        <td>@COMENTARIOS</td>
                    </tr>
                </table><br />
            </td>
        </tr>
        <tr>
            <td colspan=""2"">
                <a href=""mailto:galenialp@mx.lms-la.com"">
                    <img src=""http://galenialp.lms-la.com/images/pleca_contacto.jpg"" width=""800"" height=""50"" alt="""" />
                </a>

            </td>
        </tr>
        <tr>
            <td colspan=""2"">
                <a href=""http://galenialp.lms-la.com"" target=""_blank"">http://galenialp.lms-la.com                    
                </a>
            </td>
        </tr>
    </table>";
                RadEditor1.Content = plantilla_comentarios_default;
            }
            else
            {
                RadEditor1.Content = dvSql[0][0].ToString();
            }
        }
    }
}