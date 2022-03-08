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
    public partial class avisoEdit : System.Web.UI.Page
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
                Master.Submenu = "Aviso Privacidad";

                RadEditor1.ContentAreaCssFile = "~/Editor/EditorContentAreaStyles.css";
                RadEditor1.DisableFilter(EditorFilters.ConvertFontToSpan);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            csPrograma programa = new csPrograma();
            programa.ActualizaHTMLPlantilla(Int32.Parse(programas.SelectedValue), "plantilla_aviso", RadEditor1.Content);
            //editorText.Text = RadEditor1.Content;
        }

        protected void programas_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SqlDataSource SqlDataSource1 = new SqlDataSource();
            SqlDataSource1.ID = "plantilla_contenido";
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;
            SqlDataSource1.SelectCommand = "SELECT plantilla_aviso from programa where id = @programa_id";
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("programa_id", programas.SelectedValue);

            DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            string value = dvSql.ToTable().Rows[0][0].ToString();
            if (value.Equals(""))
            {
                string plantilla_aviso_default = @"<p>“El tratamiento que <b>VOLKSWAGEN BANK, S.A., INSTITUCIÓN DE BANCA MÚLTIPLE Y VOLKSWAGEN LEASING, S.A. DE C.V.</b> (en lo sucesivo <b>VOLKSWAGEN</b>), da a los Datos Personales es estrictamente confidencial, apegado a la legalidad y está sujeto a las más altas normas de seguridad, cumpliendo con estándares internacionales en materia de protección de datos personales en posesión de particulares.</p>

                            <p>De conformidad con la Ley Federal de Protección de Datos Personales en Posesión de Particulares, <b>VOLKSWAGEN</b> le informa lo siguiente:</p>

                            <p>
                                <b>Responsable y Domicilio</b><br />
                                El responsable de la protección de datos personales es <b>VOLKSWAGEN</b>, con domicilio en Autopista México Puebla Km. 116 más 900 San Lorenzo Almecatla, Cuautlancingo, Puebla
                            </p>

                            <p>
                                <b>Información Recopilada</b><br />
                                La información recopilada del cliente frecuente: es la contenida en los formularios que se requisitan con motivo de inscribirse al programa; los datos que son proporcionados de tiempo en tiempo por el cliente  frecuente, para la localización y contacto.
                            </p>

                            <p>
                                <b>Para que fines se recaban y utilizan sus datos personales</b><br />
                                Para la ejecución de todo lo relacionado con el programa, realizar actividades de promoción en general, mantener actualizados nuestros registros para poder responder a sus consultas, invitarle a eventos, hacer de su conocimiento nuestras promociones y lanzamientos así como mantener comunicación en general.
                            </p>

                            <p>
                                <b>Derechos Arco</b><br />
                                Para ejercer los derechos de Acceso, Rectificación, Cancelación u Oposición, se deberá contactar a <b>VOLKSWAGEN</b>, en el domicilio indicado en el presente aviso, debiendo acreditar su identidad y en su caso, la representación y carácter con el que se comparece.
                            </p>

                            <p>
                                <b>Transferencia de datos</b><br />
                                Los datos proporcionados únicamente podrán ser transferidos dentro y fuera del país a empresas subsidiarias, filiales y/o licenciatarias; o a las empresas que por motivo u objeto del programa este obligado a compartir <b>VOLKSWAGEN</b>.
                            </p>

                            <p>
                                <b>Modificación del aviso</b><br />
                                <b>VOLKSWAGEN</b> se reserva el derecho de realizar cambios en el Aviso de Privacidad, en cuyo caso se comunicará esta situación, mediante las siguiente dirección de internet <a href=""www.volkswagen.loyaltyworldvwfs.com"">www.volkswagen.loyaltyworldvwfs.com</a>, o cualquier otro medio de comunicación oral, impreso o electrónico que <b>VOLKSWAGEN</b> determine para tal efecto.
                            </p>

                            <p>El presente aviso se encuentra actualizado al día 1 de abril del 2014.”</p>
                            <br />";
                RadEditor1.Content = plantilla_aviso_default;
            }
            else
            {
                RadEditor1.Content = dvSql[0][0].ToString();
            }
        }
    }
}