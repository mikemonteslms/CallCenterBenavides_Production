using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace CallcenterNUevo.CALLCENTER
{
    public partial class rptBloquearTarjeta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int intEstatus = 0;

            if (string.IsNullOrWhiteSpace(txtTarjeta.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Es necesario proporcione una trajeta.');", true);
                return;
            }

            DataTable tblDatos = Tarjetas.ConsultaBloqueos(txtTarjeta.Text);
            if (tblDatos.Rows.Count > 0)
            {
                txtFecha.Text = Convert.ToDateTime(tblDatos.Rows[0]["FechaActivacion"]).ToShortDateString();
                txtBoomerangs.Text = tblDatos.Rows[0]["Boomerangs"].ToString();
                txtEstatus.Text = tblDatos.Rows[0]["Estatus"].ToString();
                txtNivel.Text = tblDatos.Rows[0]["Nivel"].ToString();
                txtNombre.Text = tblDatos.Rows[0]["Nombre"].ToString();
                txtSaldo.Text = tblDatos.Rows[0]["Saldo"].ToString();
                txtEstatusB.Text = tblDatos.Rows[0]["EstatusB"].ToString();
                HiddenField1.Value = tblDatos.Rows[0]["IDEstatus"].ToString();
                intEstatus = Convert.ToInt32(tblDatos.Rows[0]["IDEstatus"]);
                txtFechaBloque.Text = tblDatos.Rows[0]["FechaBloque"].ToString();
                //txtMotivo.Text = tblDatos.Rows[0]["Tarjeta_strObservaciones"].ToString();
                if (intEstatus == 1)
                {
                    lblmotivo.Visible = true;
                    txtMotivo.Visible = true;
                }
                else 
                {
                    lblmotivo.Visible = false;
                    txtMotivo.Visible = false;
                }
            }
            pnlDatos.Visible = true;
        }
        protected void btnConfirma_Click(object sender, EventArgs e)
        {
            int intEstatus = 0;


            intEstatus = Convert.ToInt32(HiddenField1.Value);
            if (intEstatus  > 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Imposible continuar, la tarjeta se encuentra bloqueada.');", true);
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtMotivo.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Imposible continuar, proporcione un motivo.');", true);
                    txtMotivo.Focus();
                    return;
                }

                string Result = Tarjetas.RealizarBloqueos(txtTarjeta.Text, "5", txtMotivo.Text, HttpContext.Current.User.Identity.Name);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Result + "');", true);
                Response.AddHeader("REFRESH", "2;URL=rptBloquearTarjeta.aspx");
            }

        }
        protected void btnCanelar_Click(object sender, EventArgs e)
        {
            txtMotivo.Text = "";
            pnlDatos.Visible = false;
        }
    }
}