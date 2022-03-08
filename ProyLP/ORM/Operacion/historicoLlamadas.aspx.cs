using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Configuration;

namespace ORMOperacion
{
    public partial class historicoLlamadas : System.Web.UI.Page
    {
        csParticipante participante;
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
                if (Session["participante_id"] != null && Session["participante"] != null)
                {
                    Master.Menu = "Llamadas";
                    Master.Submenu = "Historico";

                    MostrarDatosParticipante(Session["participante_id"].ToString());
                    MuestraHistorial(Session["participante_id"].ToString());
                }
                else
                {
                    Response.Redirect("default.aspx", false);
                }
            }
        }

        private void MostrarDatosParticipante(string participante_id)
        {
            participante = new csParticipanteComplemento();
            participante.ID = participante_id;
            participante.DatosParticipante();
            txtParticipante.Text = participante.NombreCompleto.ToUpper();
        }
        protected void MuestraHistorial(string participante_id)
        {
            csLlamada llamada = new csLlamada();
            llamada.IDParticipante = participante_id;
            DataTable dtLlamadas = llamada.HistorialLlamadas();
            lblRegistros.Text = dtLlamadas.Rows.Count.ToString() + " llamada(s) encontradas";
            if (dtLlamadas.Rows.Count > 0)
            {
                gvHistorialLlamadas.DataSource = dtLlamadas.DefaultView;
                gvHistorialLlamadas.DataBind();
            }
            else
            {
                Master.MuestraMensaje("No se encontraron llamadas.");
            }
        }
        protected void gvHistorialLlamadas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                tblDetalleLlamada.Dispose();
                string llamada_id = gvHistorialLlamadas.DataKeys[e.RowIndex].Values["id"].ToString();
                csLlamada llamada = new csLlamada();
                llamada.IDlamada = llamada_id;
                DataTable dtHistorial = llamada.DetalleHistorialLlamadas();
                if (dtHistorial.Rows.Count > 0)
                {
                    lblNombreParticipante.Text = llamada.NombreParticipante.ToUpper();
                    lblPersonaLlama.Text = llamada.NombreLlama.ToUpper();
                    lblTelefono.Text = llamada.Telefono;
                    lblFechaLlamada.Text = llamada.FechaLlamada;
                    txtDescripcionLlamadaDetalle.Text = llamada.Descripcion;
                    lblUsuarioLlamada.Text = llamada.NombreUsuario.ToUpper();
                    TableRow tblRow = new TableRow();
                    tblRow.VerticalAlign = VerticalAlign.Top;
                    for (int i = 0; i < dtHistorial.Rows.Count; i++)
                    {
                        DataRow drLlamada = dtHistorial.Rows[i];
                        string categoria = drLlamada["categoria_id"].ToString();

                        Label lblTituloCategoria = new Label();
                        lblTituloCategoria.ForeColor = System.Drawing.Color.Black;
                        lblTituloCategoria.Text = drLlamada["categoria"].ToString();

                        CheckBoxList chkLlamada = new CheckBoxList();

                        int j = i;
                        int z = 0;
                        do
                        {
                            chkLlamada.Items.Add(new ListItem(drLlamada["tipo_llamada"].ToString(), drLlamada["tipo_llamada_id"].ToString()));
                            chkLlamada.Items[z].Enabled = false;
                            chkLlamada.Items[z].Selected = true;

                            z++;
                            j++;
                            if (j < dtHistorial.Rows.Count)
                            {
                                drLlamada = dtHistorial.Rows[j];
                            }
                        } while ((drLlamada["categoria_id"].ToString() == categoria) && (j < dtHistorial.Rows.Count));
                        chkLlamada.Enabled = false;
                        chkLlamada.SelectedItem.Selected = true;
                        TableCell tblCell = new TableCell();
                        tblCell.Controls.Add(lblTituloCategoria);
                        tblCell.Controls.Add(chkLlamada);
                        tblRow.Cells.Add(tblCell);
                        i = j - 1;
                    }
                    tblDetalleLlamada.Rows.Add(tblRow);
                }
                else
                {
                    Label lblMensaje = new Label();
                    lblMensaje.Text = "No se encontraron registros";
                    TableRow tblRow = new TableRow();
                    TableCell tblCell = new TableCell();
                    tblCell.Controls.Add(lblMensaje);
                    tblRow.Cells.Add(tblCell);
                    tblDetalleLlamada.Rows.Add(tblRow);
                }
            }
            catch (Exception ex)
            {
                Label lblTituloCategoria = new Label();
                lblTituloCategoria.Text = ex.Message;
                TableRow tblRow = new TableRow();
                TableCell tblCell = new TableCell();
                tblCell.Controls.Add(lblTituloCategoria);
                tblRow.Cells.Add(tblCell);
                tblDetalleLlamada.Rows.Add(tblRow);
            }
            popDetalleLlamada.Show();
        }
    }
}