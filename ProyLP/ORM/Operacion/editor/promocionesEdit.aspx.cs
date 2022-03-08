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
    public partial class promocionesEdit : System.Web.UI.Page
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
                Master.Submenu = "Promociones";

                RadEditor1.ContentAreaCssFile = "~/Editor/EditorContentAreaStyles.css";
                RadEditor1.DisableFilter(EditorFilters.ConvertFontToSpan);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            csPrograma programa = new csPrograma();
            programa.ActualizaHTMLPlantilla(Int32.Parse(programas.SelectedValue), "plantilla_promociones", RadEditor1.Content);
            editorText.Text = RadEditor1.Content;
        }

        protected void programas_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ID = "plantilla_contenido";
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;
            SqlDataSource1.SelectCommand = "SELECT plantilla_promociones from programa where id = @programa_id";
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("programa_id", programas.SelectedValue);

            DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            string value = dvSql.ToTable().Rows[0][0].ToString();
            if (value.Equals(""))
            {
                string plantilla_promociones_default = @"<main><h3>Promociones</h3>
                    <img src=""/images/promociones/ventas-mar-abr-GSF.jpg"" style=""display:block; margin: 0 auto !important;"" class=""img-responsive""/>
                    <br />
                    <br />
                    <h3>Noticias</h3>
                    <p class=""noticia"">¡Llegaron las ventas de <b>enero y febrero!</b></p>
                    <br />
                    <p>Debido a los ajustes por el lanzamiento del programa <b>Loyalty World Volkswagen</b>, les informamos que el periodo de asignación para las ventas de <b>Enero y Febrero</b> quedará abierto.</p>
                    <br />
                    <p class=""texto-small"">Publicado: 05 / 05 / 2014</p>
                    <br />
                    <p class=""noticia"">&nbsp;</p>
                    <p>A partir del <b>26 al 30 de mayo</b>, deberás asignar las ventas de tus Gerentes y Asesores de Ventas del periodo de <b>Marzo y Abril</b>.</p>
                    <br />
                    <p>Recuerda que al asignar el 100% de las ventas de tu Concesionaria podrás acumular Kilómetros. </p>
                    <br />
                    <p class=""texto-small"">Publicado: 14 / 05 / 2014</p>
                    <br />
                    <br />
                    <p class=""noticia"">¡Llegó el Mundial!</p>
                    <br />
                    <p>Participa llenando la quiniela de cada semana y acumula goles.</p>
                    <br />
                    <p>Los 3 vendedores con mayor número de goles acumulados podrán obtener <b>puntos extras</b>.</p>
                    <br />
                    <p><asp:LinkButton ID=""LinkButton1"" runat=""server"" CssClass=""Azul bold"" ToolTip=""Quiniela"" OnClientClick=""openWinNavigateUrl(); return false;"">¿Qué esperas? ¡Participa!</asp:LinkButton></p>
                    <br />
                    <p class=""texto-small"">Publicado: 10 / 06 / 2014</p>
                    <br />
                    <br />
                    <p>No te pierdas las siguientes noticias...</p>";
                RadEditor1.Content = plantilla_promociones_default;
            }
            else
            {
                RadEditor1.Content = dvSql[0][0].ToString();
            }
        }
    }
}