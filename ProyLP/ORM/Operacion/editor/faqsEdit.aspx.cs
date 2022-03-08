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
    public partial class faqsEdit : System.Web.UI.Page
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
                Master.Submenu = "FAQs";

                RadEditor1.ContentAreaCssFile = "~/Editor/EditorContentAreaStyles.css";
                RadEditor1.DisableFilter(EditorFilters.ConvertFontToSpan);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            csPrograma programa = new csPrograma();
            programa.ActualizaHTMLPlantilla(Int32.Parse(programas.SelectedValue), "plantilla_faqs", RadEditor1.Content);
            //editorText.Text = RadEditor1.Content;
        }

        protected void programas_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ID = "plantilla_contenido";
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;
            SqlDataSource1.SelectCommand = "SELECT plantilla_faqs from programa where id = @programa_id";
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("programa_id", programas.SelectedValue);

            DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            string value = dvSql.ToTable().Rows[0][0].ToString();
            if (value.Equals(""))
            {
                string plantilla_faqs_default = @"<main><h3>Preguntas Frecuentes </h3>
 <!-- Accordion begin -->
		<div class=""accordion_example3"">
			<!-- Pregunta 1 -->
			<div class=""accordion_in"">
				<div class=""acc_head"">¿Qué es el Programa Loyalty World?</div>
				<div class=""acc_content"">
					<p>
                  	Es un Programa creado por Volkswagen Servicios Financieros para premiar mediante kilómetros las ventas de productos participantes de Volkswagen Bank y Volkswagen Leasing. Y así, lograr objetivos de penetración mensuales. Estas ventas te generarán beneficios especiales a través de un catálogo de premios diseñado exclusivamente para ti.
                  </p>
				</div>
			</div>

			<!-- Pregunta 2 -->
			<div class=""accordion_in"">
				<div class=""acc_head"">¿Cómo me inscribo?</div>
				<div class=""acc_content"">
					 <p>
                     Necesitas verificar con el Consultor de Negocios (RAD) que estés dado de alta en la concesionaria, si no lo estás, él deberá hacer el proceso de alta. Una semana después recibirás un correo del Programa Loyalty World de Volkswagen Servicios Financieros.
                   </p>
				</div>
			</div>
			<!-- Pregunta 3 -->
			<div class=""accordion_in"">
				<div class=""acc_head"">¿Expiran mis Kilómetros?</div>
				<div class=""acc_content"">
					 <p>
                     Sí, los Kilómetros sólo son válidos hasta el 30 de Abril del 2015, después de esta fecha, se perderán.
                   </p>
				</div>
			</div>
			<!-- Pregunta 4 -->
			<div class=""accordion_in"">
				<div class=""acc_head"">¿Puedo pagar una parte con Kilómetros y otra en efectivo?</div>
				<div class=""acc_content"">
					 <p>
                     No, tienes que acumular la cantidad de Kilómetros indicada en cada artículo del catálogo de premios que está publicado en el sitio web de Loyalty World de Volkswagen Servicios Financieros que está diseñado para ti.
                   </p>
				</div>
			</div>
			<!-- Pregunta 5 -->
			<div class=""accordion_in"">
				<div class=""acc_head"">¿Puedo transferir mis Kilómetros a otra cuenta?</div>
				<div class=""acc_content"">
					 <p>
                     No, los Kilómetros y las cuentas son personales e intransferibles.
                   </p>
				</div>
			</div>
			<!-- Pregunta 6 -->
			<div class=""accordion_in"">
				<div class=""acc_head"">¿Cómo verifico cuántos Kilómetros tengo?</div>
				<div class=""acc_content"">
					 <p>
                     Puedes revisarlo en línea accediendo a la página <a href=""www.volkswagen.loyaltyworldvwfs.com"">www.volkswagen.loyaltyworldvwfs.com</a>, y en la sección de Estado de Cuenta podrás revisar los Kilómetros asignados de acuerdo a tus ventas o bien, puedes llamar al Centro de Atención Telefónica de Loyalty World al 1085 9813 en D.F. y Área Metropolitana o Lada sin costo al 01 800 272 2582.
                   </p>
				</div>
			</div>
			<!-- Pregunta 7 -->
			<div class=""accordion_in"">
				<div class=""acc_head"">¿Cuándo puedo canjear mis Kilómetros por regalos?</div>
				<div class=""acc_content"">
					 <p>
                     Los canjes de premios serán mensuales, no habrá fechas específicas para canjes.
                         </p>
                    <p>
                     <b>NOTA:</b> Los Kilómetros se podrán acumular mes a mes hasta el 31 de marzo del 2015, con un mes extra de canje del 1 al 30 de abril del 2015.
                   </p>
				</div>
			</div>
			<!-- Pregunta 8 -->
			<div class=""accordion_in"">
				<div class=""acc_head"">¿Cuándo y dónde recibo mis premios?</div>
				<div class=""acc_content"">
					 <p>
                     Los premios se entregarán en las instalaciones de la concesionaria a la que perteneces, por eso es importante siempre que existan actualizaciones de tus datos.
                   </p>
				</div>
			</div>
		</div>
		<!-- Accordion end -->";
                RadEditor1.Content = plantilla_faqs_default;
            }
            else
            {
                RadEditor1.Content = dvSql[0][0].ToString();
            }
        }
    }
}