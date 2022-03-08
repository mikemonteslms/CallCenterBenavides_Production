using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;

namespace CallcenterNUevo.Herramientas
{
    public partial class utils : System.Web.UI.Page
    {
        public static string CnnProductivo = "ConnectionStringProd";
        public static string CnnPruebas = "ConnectionStringTest";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnEjecutar_Click(object sender, EventArgs e)
        {
            int intRespuesta = 0;
            Utilidades ejecutar = new Utilidades();
            DataSet DSpru = new DataSet();
            DataSet DSprod = new DataSet();

            if (!rdbexe.Checked && !rdbcons.Checked)
            {
                Mensajes("Selecciona una opción...");
                return;
            }

            if (rdbexe.Checked)
            {
                intRespuesta = ejecutar.EjecutaTranSQL(CnnPruebas, txtcadena.Text);
                intRespuesta = ejecutar.EjecutaTranSQL(CnnProductivo, txtcadena.Text);

                lblmsg.Text = "Command(s) completed successfully.";
            }

            if (rdbcons.Checked)
            {
                DSpru = ejecutar.ObtenerDatos(CnnPruebas, txtcadena.Text);
                DSprod = ejecutar.ObtenerDatos(CnnProductivo, txtcadena.Text);

                if (DSpru != null)
                {
                    if (DSpru.Tables.Count > 0)
                    {
                        if (DSpru.Tables[0].Rows.Count > 0)
                        {
                            grvDatosTest.DataSource = DSpru.Tables[0];
                            grvDatosTest.DataBind();
                        }
                    }
                }


                if (DSprod != null)
                {
                    if (DSprod.Tables.Count > 0)
                    {
                        if (DSprod.Tables[0].Rows.Count > 0)
                        {
                            grvDatosProd.DataSource = DSprod.Tables[0];
                            grvDatosProd.DataBind();
                        }
                    }
                }
            }
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "Mensajes", "alert('" + outputstring + "');", true);
        }
    }
}