using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.IO;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;
using CallCenterDB;

namespace ORMOperacion.editor
{
    public partial class mecanica : System.Web.UI.Page
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
                Master.Submenu = "Mecanica";

                RadEditor1.ContentAreaCssFile = "~/Editor/EditorContentAreaStyles.css";
                RadEditor1.DisableFilter(EditorFilters.ConvertFontToSpan);



            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            csPrograma programa = new csPrograma();
            programa.ActualizaHTMLPlantilla(Int32.Parse(programas.SelectedValue), "plantilla_mecanica", RadEditor1.Content);
            //editorText.Text = RadEditor1.Content;
        }

        protected void programas_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ID = "plantilla_contenido";
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;
            SqlDataSource1.SelectCommand = "SELECT plantilla_mecanica from programa where id = @programa_id";
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("programa_id", programas.SelectedValue);

            DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            string value = dvSql.ToTable().Rows[0][0].ToString();
            if (value.Equals(""))
            {
                string plantilla_mecanica_default = @"<!-- Accordion begin --><div class=""accordion_example3""><!-- Section 1 --><div class=""accordion_in acc_active""><div class=""acc_head"">&iquest;C&oacute;mo acumulo kil&oacute;metros?</div><div class=""acc_content""><p>Los Gerente de Servicios Financieros deber&aacute;n:</p><br /><p><strong>-</strong> Asignar las ventas por colocaci&oacute;n y seguros al Asesor de Ventas correspondiente.<br /><br /><strong>-</strong> Motivar a los Asesores de Ventas con la finalidad de incrementar las ventas de productos Volkswagen Servicios Financieros Participantes para lograr los objetivos de Penetraci&oacute;n y Eficiencia de la Concesionaria.<br /><br /><strong>-</strong> Conocer las bases del Programa para asesorar a los Participantes.<br /><br /><strong>-</strong> Revisar y monitorear los resultados de sus Asesores de Ventas a trav&eacute;s de la p&aacute;gina web del Programa.<br /><br /><strong>-</strong> Informar bajas o cambios de los Participantes al Centro de Atenci&oacute;n Telef&oacute;nico del Programa.<br /><br /></p><p>Los Gerente de Servicios Financieros podr&aacute;n ganar Kil&oacute;metros de la siguiente forma:<br /><br /></p><p class=""destacado-mecanica""><strong>- Asignaci&oacute;n de Ventas por Colocaci&oacute;n</strong></p><p>El Gerente de Servicios Financieros obtiene <strong>500 Kil&oacute;metros</strong> por realizar el 100% de la asignaci&oacute;n de ventas a la fuerza de ventas de su Concesionaria en el mes; en caso de que el Gerente de Servicios Financieros no realice alguna asignaci&oacute;n, su cuenta permanecer&aacute; en cero.</p><br /><p class=""destacado-mecanica""><strong>- Porcentaje de Penetraci&oacute;n</strong></p><p>El Gerente de Servicios Financieros obtiene Kil&oacute;metros de acuerdo al rango de porcentaje de penetraci&oacute;n que obtuvo la Concesionaria en cada mes, estos Kil&oacute;metros est&aacute;n definidos de la siguiente manera:</p><br /><table class=""cuadro-info-gsf"">    <tbody>        <tr>            <td rowspan=""2"" class=""contenido-1-gsf"">&nbsp;</td>            <td colspan=""6"" class=""titulo-cuadro-info-gsf""><span>Cantidad de autos</span></td>        </tr>        <tr>            <td class=""subtitulo-gsf"">0 a 4</td>            <td class=""subtitulo-gsf"">5 a 10</td>            <td class=""subtitulo-gsf"">11 a 20</td>            <td class=""subtitulo-gsf"">21 a 30</td>            <td class=""subtitulo-gsf"">31 a 40</td>            <td class=""subtitulo-gsf"">41 o m&aacute;s</td>        </tr>        <tr>            <td class=""contenido-1-gsf"">0 - 14.99 %</td>            <td class=""numero-contenido-gsf"">0</td>            <td class=""numero-contenido-gsf"">0</td>            <td class=""numero-contenido-gsf"">0</td>            <td class=""numero-contenido-gsf"">300</td>            <td class=""numero-contenido-gsf"">500</td>            <td class=""numero-contenido-gsf"">1,000</td>        </tr>        <tr>            <td class=""contenido-1-gsf"">15 - 24.99 %</td>            <td class=""numero-contenido-gsf"">0</td>            <td class=""numero-contenido-gsf"">100</td>            <td class=""numero-contenido-gsf"">300</td>            <td class=""numero-contenido-gsf"">500</td>            <td class=""numero-contenido-gsf"">1,000</td>            <td class=""numero-contenido-gsf"">1,500</td>        </tr>        <tr>            <td class=""contenido-1-gsf"">25 - 31.99 %</td>            <td class=""numero-contenido-gsf"">0</td>            <td class=""numero-contenido-gsf"">300</td>            <td class=""numero-contenido-gsf"">500</td>            <td class=""numero-contenido-gsf"">1,000</td>            <td class=""numero-contenido-gsf"">1,500</td>            <td class=""numero-contenido-gsf"">1,750</td>        </tr>        <tr>            <td class=""contenido-1-gsf"">32 - 37.99 %</td>            <td class=""numero-contenido-gsf"">0</td>            <td class=""numero-contenido-gsf"">500</td>            <td class=""numero-contenido-gsf"">1,000</td>            <td class=""numero-contenido-gsf"">1,500</td>            <td class=""numero-contenido-gsf"">1,750</td>            <td class=""numero-contenido-gsf"">2,000</td>        </tr>        <tr>            <td class=""contenido-1-gsf"">38 - 44.99 %</td>            <td class=""numero-contenido-gsf"">100</td>            <td class=""numero-contenido-gsf"">1,000</td>            <td class=""numero-contenido-gsf"">2,000</td>            <td class=""numero-contenido-gsf"">2,500</td>            <td class=""numero-contenido-gsf"">3,000</td>            <td class=""numero-contenido-gsf"">3,500</td>        </tr>        <tr>            <td class=""contenido-1-gsf"">45 &oacute; m&aacute;s %</td>            <td class=""numero-contenido-gsf"">500</td>            <td class=""numero-contenido-gsf"">2,000</td>            <td class=""numero-contenido-gsf"">2,500</td>            <td class=""numero-contenido-gsf"">3,000</td>            <td class=""numero-contenido-gsf"">3,500</td>            <td class=""numero-contenido-gsf"">4,500</td>        </tr>    </tbody></table><br /><p class=""texto-small""><strong>Nota:</strong> El porcentaje de penetraci&oacute;n es el n&uacute;mero de contratos de Volkswagen Servicios Financieros generados en el mes respecto al total de ventas generadas dentro de la Concesionaria.</p><br /><p class=""destacado-mecanica""><strong>- Porcentaje de Eficiencia</strong></p><p>El Gerente de Servicios Financieros obtiene Kil&oacute;metros de acuerdo al rango de porcentaje de eficiencia (contratos activados entre todas las solicitudes viables autorizadas y detenidas) que obtuvo la Concesionaria en cada mes, estos Kil&oacute;metros est&aacute;n definidos de la siguiente manera:</p><br /><div class=""cuadro-info""><div class=""contenido-1""><p>0 - 49.99 %</p></div><div class=""numero-contenido""><p>0</p></div><div class=""contenido-1""><p>50 - 64.99 %</p></div><div class=""numero-contenido""><p>500</p></div><div class=""contenido-1""><p>65 - 69.99 %</p></div><div class=""numero-contenido""><p>1,000</p></div><div class=""contenido-1""><p>70 - 79.99 %</p></div><div class=""numero-contenido""><p>2,000</p></div><div class=""contenido-1""><p>80 - 89.99 %</p></div><div class=""numero-contenido""><p>3,000</p></div><div class=""contenido-1""><p>90 - 100 %</p></div><div class=""numero-contenido""><p>4,000</p></div></div><br /><br /><p class=""destacado-mecanica""><strong>- Bonos</strong></p><div class=""cuadro-info-2""><div class=""contenido-2""><p>Bienvenida y aniversario laboral</p></div><div class=""numero-contenido""><p>50</p></div><div class=""contenido-2""><p>Cumplea&ntilde;os</p></div><div class=""numero-contenido""><p>100</p></div><div class=""contenido-2""><p>Encuesta y quinielas</p></div><div class=""numero-contenido""><p>150</p></div></div><p class=""destacado-mecanica""><strong>- University</strong></p><table class=""cuadro-info-gsf"">    <tbody>        <tr>            <td class=""mecanica-university"">Curso Inducci&oacute;n para Nuevos GSF</td>            <td class=""mecanica-university"">Capacitaci&oacute;n para el Gerente de Servicios Financieros (1 vez al a&ntilde;o).</td>            <td class=""mecanica-university"">100</td>        </tr>        <tr>            <td class=""mecanica-university"">Curso PLD</td>            <td class=""mecanica-university"">Curso de certificaci&oacute;n internacional para Asesores de Ventas (1 vez al a&ntilde;o).</td>            <td class=""mecanica-university"">100</td>        </tr>        <tr>            <td class=""mecanica-university"">Curso Leasing</td>            <td class=""mecanica-university"">Capacitaci&oacute;n del producto de Leasing (1 vez al a&ntilde;o).</td>            <td class=""mecanica-university"">200</td>        </tr>        <tr>            <td class=""mecanica-university"">Curso C&aacute;lculo de ingresos</td>            <td class=""mecanica-university"">C&aacute;lculo de ingresos de las diferentes tipos de personas (1 vez al a&ntilde;o).</td>            <td class=""mecanica-university"">150</td>        </tr>        <tr>            <td class=""mecanica-university"">Conexi&oacute;n a la transmisi&oacute;n de la oferta</td>            <td class=""mecanica-university"">Conexi&oacute;n v&iacute;a web para ver la oferta del mes, transmisi&oacute;n on line (mensual).</td>            <td class=""mecanica-university"">100</td>        </tr>    </tbody></table></div></div><!-- Section 2 --><div class=""accordion_in""><div class=""acc_head"">&iquest;Qui&eacute;nes participan?</div><div class=""acc_content""><p><span>A.</span> <strong>Gerente de Servicios Financieros</strong> </p></div></div></div><!-- Accordion end -->";
                RadEditor1.Content = plantilla_mecanica_default;
            }
            else
            {
                RadEditor1.Content = dvSql[0][0].ToString();
            }
        }
    }
}