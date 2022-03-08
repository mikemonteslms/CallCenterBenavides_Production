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
    public partial class terminosEdit : System.Web.UI.Page
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
                Master.Submenu = "Terminos-Condiciones";

                RadEditor1.ContentAreaCssFile = "~/Editor/EditorContentAreaStyles.css";
                RadEditor1.DisableFilter(EditorFilters.ConvertFontToSpan);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            csPrograma programa = new csPrograma();
            programa.ActualizaHTMLPlantilla(Int32.Parse(programas.SelectedValue), "plantilla_terminos", RadEditor1.Content);
            //editorText.Text = RadEditor1.Content;
        }

        protected void programas_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ID = "plantilla_contenido";
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;
            SqlDataSource1.SelectCommand = "SELECT plantilla_terminos from programa where id = @programa_id";
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("programa_id", programas.SelectedValue);

            DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            string value = dvSql.ToTable().Rows[0][0].ToString();
            if (value.Equals(""))
            {
                string plantilla_terminos_default = @"<p>
                                <b>Vigencia y Aplicación del Programa</b><br />
                                El Programa tendrá una vigencia de 12 meses: 1° de Abril del 2014 al 31 de Marzo del 2015 para generación de Kilómetros y hasta el 30 de Abril del 2015 para la redención de Kilómetros.
                        <br />
                                Aplica únicamente para Gerente de Servicios Financieros, Gerente de Ventas y Asesores de Ventas de las concesionarias autorizadas Volkswagen.
                            </p>

                            <p>
                                <b>Inscripción</b><br />
                                Para poder inscribirse al Programa, los Participantes deberán recibir por correo electrónico su usuario y contraseña para ingresar a sistema. Si el correo no llega al mail del Participante después de 1 semana de haberse dado de alta en la concesionaria, deberá acudir con el Gerente de Servicios Financieros o con su Consultor de Negocios para que verifiquen su alta en sistema o bien, deberá comunicarse al Centro de Atención Telefónico, donde podrán reenviar su contraseña. Es obligación de los Participantes conocer y cumplir todas las reglas y políticas del Programa. Es responsabilidad del Participante verificar que los datos que aparecen en el sitio del Programa sean correctos y deberán notificar cualquier cambio de domicilio, teléfono y/o dirección de correo electrónico ingresando a la sección “Mi cuenta”, dentro de la página web.<br />
                                Los Participantes contarán con una clave de usuario individual e intransferible (Número de usuario), así como una contraseña para la realización de transacciones sobre sus cuentas, la cual se les hará llegar a través del correo electrónico registrado. Queda bajo responsabilidad del Participante el uso que se le dé a la clave de acceso y contraseña que se le concede para navegar en el Sitio del Programa.<br />
                            </p>

                            <p>
                                <b>Baja o cambio de Concesionaria de los Participantes</b><br />
                                La baja o cambio de concesionaria del Participante se verá reflejado de manera semanal, siempre y cuando los cambios hayan sido notificados a la marca.
                            </p>

                            <p>
                                <b>Acumulación de Kilómetros</b><br />
                                La acumulación de Kilómetros es individual e intransferible. En caso de que las ventas registradas en la base de datos generen Kilómetros, éstos se verán reflejados en su estado de cuenta. La información sobre los Kilómetros acumulados podrá ser consultada en cualquier momento a través de la página web en la sección “Mi cuenta” o a través del Centro de Atención Telefónico del Programa. Los Kilómetros tendrán una vigencia máxima hasta el 1° de Abril del 2014 al 31 de Marzo del 2015, posterior a esa fecha, los Kilómetros restantes serán eliminados de las cuentas de los Participantes y no tendrán valor alguno.
                        <br />
                                Nota: El Programa NO tomará en consideración la venta de flotillas para la acumulación de Kilómetros de los Asesores de Ventas, por lo cual no se tomarán en cuenta las ventas a partir de 5 unidades a un mismo cliente. El Programa toma en cuenta la venta de autos nuevos, seminuevos y usados.
                            </p>

                            <p>
                                <b>Auditoría</b><br />
                                Es importante que el Gerente de Servicios Financieros, quien es responsable del Programa dentro de su Concesionaria, registre las ventas realizadas al asesor de ventas correspondiente.<br />
                                De manera trimestral, se auditará el reporte de ventas del periodo para asegurar que las ventas se estén asignando a los Asesores de Ventas correspondientes y que no se estén asignando todas las ventas de la Concesionaria a un sólo asesor de ventas para alcanzar una mayor acumulación de Kilómetros. En caso de que se detecte una asignación errónea de ventas a la persona que no corresponde, se sancionará al Gerente de Servicios Financieros y se realizará una averiguación, al Asesor de Ventas implicado, para conocer la responsabilidad del mismo.<br />
                                Como penalización, se bloqueará la cuenta de los implicados y se eliminarán los Kilómetros generados en el Programa.
                            </p>

                            <p>
                                <b>Redención de Kilómetros</b><br />
                            </p>
                            <ul>
                                <li>Los Kilómetros acumulados podrán ser redimidos para obtener cualquiera de los productos que aparecen en el catálogo de premios.</li>
                                <li>Para efectuar la redención, es necesario que el Participante cumpla con las reglas que establece el Programa y con los kilómetros necesarios para adquirir el beneficio. </li>
                                <li>Sólo el titular de la cuenta podrá hacer uso de los kilómetros acumulados para utilizarlos de manera personal.</li>
                                <li>La redención de kilómetros será por medio de la página web del Programa, para dudas puede comunicarse al Centro de Atención Telefónico de Loyalty World.</li>
                                <li>Una vez canjeados los Kilómetros, éstos no podrán ser reembolsados nuevamente a la cuenta del titular. En el canje, el Participante recibirá una clave de confirmación del canje en su correo electrónico y otro mail de confirmación cuando reciba el artículo redimido.</li>
                                <li>Una vez canjeado los Kilómetros por el artículo solicitado no hay cambios ni cancelaciones.</li>
                                <li>Volkswagen Servicios Financieros se reserva el derecho de modificar en cualquier momento, con o sin previo aviso, el catálogo de recompensas, ya sea en el número de Kilómetros por los artículos disponibles. </li>
                                <li>Los artículos serán enviados a la concesionaria en donde el asesor de ventas se encuentre laborando.</li>
                                <li>En caso de no recibir los artículos en los plazos señalados, deberá notificarse a la brevedad al Centro de Atención Telefónico de Loyalty World o en el recuadro que aparecerá en la página web para regularizar la entrega. </li>
                                <li>En caso de que se solicite un artículo determinado y no se encuentre en existencia, se ofrecerá un producto similar o modelo más reciente que el artículo original solicitado anteriormente por el Participante, sin costo adicional. </li>
                                <li>El Participante una vez recibido su artículo, deberá revisar que se encuentre en perfectas condiciones; si no es así, el Participante no deberá firmar de recibido y deberá llamar al Centro de Atención Telefónico para comunicar lo sucedido. </li>
                                <li>El participante, una vez aceptado de conformidad el artículo que solicitó, deberá firmar el formato de la mensajería y al ingresar a la página web, le aparecerá un recuadro con información del artículo recibido, llamado “Acuse de Recibo”, para continuar con la navegación deberá marcar si recibió o no el artículo, y recibirá un correo electrónico notificando la recepción.</li>
                                <li>El Gerente de Servicios Financieros tiene la obligación de solicitar al Participante que notifique al sistema que ya recibió o no el artículo.</li>
                            </ul>";
                RadEditor1.Content = plantilla_terminos_default;
            }
            else
            {
                RadEditor1.Content = dvSql[0][0].ToString();
            }
        }
    }
}