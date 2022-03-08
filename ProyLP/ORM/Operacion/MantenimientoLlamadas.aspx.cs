using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

namespace ORMOperacion
{
    public partial class MantenimientoLlamadas : System.Web.UI.Page
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
                if (Session["participante_id"] != null && Session["participante"] != null)
                {
                    Master.Menu = "Llamadas";
                    Master.Submenu = "Captura";

                    MostrarDatosParticipante();
                    catParticipante.Programa = (Session["participante"] as csParticipanteComplemento).Programa;
                    catParticipante.CargaCategorias();
                    pnlLlamada.Visible = true;
                }
                else
                {
                    Response.Redirect("default.aspx", false);
                }
            }
        }

        private void MostrarDatosParticipante()
        {
            csParticipanteComplemento participante = new csParticipanteComplemento();
            participante.ID = Session["participante_id"].ToString();
            participante.DatosParticipante();
            txtParticipante.Text = participante.NombreCompleto;
            DataTable dtTelefono = participante.ConsultaTelefono();
            if (dtTelefono.Rows.Count > 0)
            {
                mvTipoTelefono.SetActiveView(vrblTipoTelefono);
                rblTipoTelefono.DataSource = dtTelefono.DefaultView;
                rblTipoTelefono.DataValueField = "tipo_telefono_id";
                rblTipoTelefono.DataTextField = "tipotelefono";
                rblTipoTelefono.DataBind();
                int indice = 0;
                foreach (DataRow drTelefono in dtTelefono.Rows)
                {
                    rblTipoTelefono.Items[indice].Text = "<span style='width:115px;display:table-cell;'>" + drTelefono["tipotelefono"].ToString().Trim() + "</span><span style='width:50px;display:table-cell;'>" + drTelefono["lada"].ToString().Trim() + "</span><span style='width:100px;display:table-cell;'>" + drTelefono["telefono"].ToString() + "</span>";
                    indice++;
                }
            }
            else
                mvTipoTelefono.SetActiveView(vtblTipoTelefono);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            try
            {
                if (txtPersona.Text.Trim() == "")
                    mensaje += "- Persona que llamo inválido<br/>";
                csLlamada llamada = new csLlamada();
                Panel pnlGrids = catParticipante.FindControl("pnlGrids") as Panel;
                HiddenField hidnumero_categorias = catParticipante.FindControl("hidnumero_categorias") as HiddenField;
                lblNumCategorias.Text = hidnumero_categorias.Value;
                for (int n = 0; n < Convert.ToInt32(lblNumCategorias.Text); n++)
                {
                    Repeater RepeaterCategorias = pnlGrids.FindControl("RepeaterCategorias") as Repeater;
                    Repeater RepeaterLlamadas = RepeaterCategorias.Items[n].FindControl("RepeaterLlamadas") as Repeater;
                    System.Web.UI.HtmlControls.HtmlGenericControl h3Descripcion = RepeaterCategorias.Items[n].FindControl("h3Descripcion") as System.Web.UI.HtmlControls.HtmlGenericControl;
                    for (int m = 0; m < RepeaterLlamadas.Items.Count; m++)
                    {
                        CheckBox chkLlamada = RepeaterLlamadas.Items[m].FindControl("chkLlamada") as CheckBox;
                        CheckBoxList chkLlamadaList = RepeaterLlamadas.Items[m].FindControl("chkLlamadaList") as CheckBoxList;
                        if (chkLlamadaList != null)
                        {
                            if (chkLlamada.Checked == true)
                            {
                                llamada.AgregaTipoLlamada(chkLlamadaList.DataValueField);
                                if (h3Descripcion.InnerText.ToUpper().Contains("SALIDA"))
                                {
                                    // Se incrementa la lista tipo llamada salida
                                    llamada.AgregaTipoLlamadaSalida(chkLlamadaList.DataValueField);
                                }
                            }
                        }
                    }
                }
                if (llamada.ConsultaCantidadTipoLlamada == 0)
                    mensaje += "- Se requiere seleccionar al menos un tipo de llamada(s)<br/>";

                if (llamada.ConsultaCantidadTipoLlamadaSalida > 0 && rblTipoTelefono.SelectedIndex == -1 && rblTipoTelefono.Visible)
                    mensaje += "- Se requiere seleccionar tipo de teléfono<br/>";

                if (llamada.ConsultaCantidadTipoLlamadaSalida > 0 && (txtLada.Text.Trim().Length == 0 || txtTelefono.Text.Trim().Length == 0) && txtLada.Visible && txtTelefono.Visible)
                    mensaje += "- Se requiere lada y teléfono<br/>";

                if (mensaje.Length > 0)
                {
                    Master.MuestraMensaje(mensaje);
                    return;
                }

                llamada.IDParticipante = Session["participante_id"].ToString();
                llamada.NombreLlama = txtPersona.Text.Trim();
                csParticipante participante = new csParticipante();
                participante.ID = Session["participante_id"].ToString();
                DataTable dtParticipante = participante.ConsultaTelefono();
                if (dtParticipante.Rows.Count > 0)
                {
                    if (rblTipoTelefono.SelectedItem != null)
                    {
                        rblTipoTelefono.SelectedItem.Text = rblTipoTelefono.SelectedItem.Text.Replace("<span style='width:115px;display:table-cell;'>", " ").Trim();
                        rblTipoTelefono.SelectedItem.Text = rblTipoTelefono.SelectedItem.Text.Replace("<span style='width:100px;display:table-cell;'>", " ").Trim();
                        rblTipoTelefono.SelectedItem.Text = rblTipoTelefono.SelectedItem.Text.Replace("<span style='width:50px;display:table-cell;'>", " ").Trim();
                        rblTipoTelefono.SelectedItem.Text = rblTipoTelefono.SelectedItem.Text.Replace("</span>", "").Trim();
                        rblTipoTelefono.SelectedItem.Text = rblTipoTelefono.SelectedItem.Text.Replace("CASA", "CA").Trim();
                        rblTipoTelefono.SelectedItem.Text = rblTipoTelefono.SelectedItem.Text.Replace("OFICINA", "OF").Trim();
                        rblTipoTelefono.SelectedItem.Text = rblTipoTelefono.SelectedItem.Text.Replace("CELULAR", "CEL").Trim();
                        llamada.Telefono = rblTipoTelefono.SelectedItem.Text;
                    }
                    else
                        llamada.Telefono = "";
                }
                else
                    llamada.Telefono = "OT " + txtLada.Text.Trim() + " " + txtTelefono.Text.Trim();
                llamada.Descripcion = txtComentarios.Text.Trim();
                llamada.IDUsuario = Membership.GetUser().ProviderUserKey.ToString();
                llamada.Status_seguimiento_id = "1";
                //string country = Session["pais"].ToString();
                //llamada.CountryCode = country;
                //llamada.GuardaLlamada(country);
                llamada.GuardaLlamada();
                mensaje = "Información almacenada satisfactoriamente </br> Número de caso : " + llamada.IDlamada;
                Master.MuestraMensaje(mensaje);
            }
            catch (Exception Ex)
            {
                csError error = new csError(HttpContext.Current, Ex);
                error.EscribirLog();
                error.EnviarMail();
                mensaje = "Ocurrió un error al guardar la llamada";
                Master.MuestraMensaje(mensaje);
            }
        }

        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoLlamadas.aspx");
        }

        protected void grid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)e.Item.Cells[2].FindControl("chkVisible");
                chk.Text = e.Item.Cells[1].Text;
            }
        }
    }
}