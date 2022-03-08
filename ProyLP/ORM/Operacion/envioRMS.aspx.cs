using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ORMOperacion
{
    public partial class envioRMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = null;
                String transaccion_id = Request["transaccion_id"].ToString();
                //String tipo_direccion_id = Request["tipo_direccion_id"].ToString();
                String programa_id = Request["programa_id"].ToString();
                csRMS envio = new csRMS(int.Parse(programa_id));
                if (transaccion_id != null)
                {
                    envio.TransaccionID = transaccion_id;
                    //envio.TipoDireccionID = tipo_direccion_id;
                    //envio.Programa = programa;
                    if (envio.envioRMS() == true)
                        lblMensaje.Text = "Proceso terminado";
                    else
                        lblMensaje.Text = "Error en el envio";
                }
                else
                    lblMensaje.Text = "Datos inválidos";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrio un error al hacer el envio " + ex.Message;
            }
        }
    }
}