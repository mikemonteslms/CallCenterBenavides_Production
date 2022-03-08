using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using xi = Telerik.Web.UI.ExportInfrastructure;
using Telerik.Web.UI.GridExcelBuilder;
using System.Data;
using Negocio;
using Datos;

namespace CallcenterNUevo.Controles.ControlMnu
{
    public partial class mantenimientomenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaMnus();
                CargaRoles();
            }
        }
        protected void rdcMenus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SeleccionMenu();
        }
        protected void grvSubMnus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                RadComboBoxItem elemento;

                RadComboBox cmb = (e.Row.FindControl("cmbNomRol") as RadComboBox);
                HiddenField hf = (e.Row.FindControl("RoleId") as HiddenField);

                //Evita que realice la consulta si no encontro los objetos
                //embebidos en el gridview
                if (cmb != null && hf != null)
                {
                    Menusapp Ejecuta = new Menusapp();
                    List<ModRoles> lstResultadosLab = new List<ModRoles>();
                    lstResultadosLab = Ejecuta.ObtenRoles();

                    if (lstResultadosLab != null)
                    {
                        if (lstResultadosLab.Count > 0)
                        {
                            foreach (ModRoles itmlab in lstResultadosLab)
                            {
                                //carga dropdownlist por cada registro
                                elemento = new RadComboBoxItem(itmlab.RoleName, itmlab.RoleId.ToString());

                                cmb.Items.Add(elemento);
                                cmb.SelectedValue = hf.Value; //se posiciona en el elemento registrado en db
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.AdminPromociones.MuestraDatos", "grvProd_RowDataBound", "Ejecuta.ObtenLaboratorios()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                //Mensajes("Ocurrio un error al intentar cargar Laboratorios, contacte al administrador");
            }
        }
        private void CargaMnus()
        {
            List<ModMenus> lstResultados = new List<ModMenus>();
            Menusapp Ejecuta = new Menusapp();

            lstResultados = Ejecuta.ObtenMenus();

            if (lstResultados != null)
            {
                if (lstResultados.Count > 0)
                {
                    rdcMenus.Items.Clear();
                    rdcMenus.DataSource = lstResultados;
                    rdcMenus.DataTextField = "Nombre";
                    rdcMenus.DataValueField = "Id";
                    rdcMenus.DataBind();

                    rdcMenus2.Items.Clear();
                    rdcMenus2.DataSource = lstResultados;
                    rdcMenus2.DataTextField = "Nombre";
                    rdcMenus2.DataValueField = "Id";
                    rdcMenus2.DataBind();

                    rdcbmnu.Items.Clear();
                    rdcbmnu.DataSource = lstResultados;
                    rdcbmnu.DataTextField = "Nombre";
                    rdcbmnu.DataValueField = "Id";
                    rdcbmnu.DataBind();
                }
            }
        }
        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool blnRepsuesta = false;

            Menusapp Ejecuta = new Menusapp();

            foreach (GridViewRow reg in grvSubMnus.Rows)
            {
                HiddenField hf = (reg.FindControl("RoleId") as HiddenField);
                HiddenField hsm = (reg.FindControl("SubmnuId") as HiddenField);
                RadComboBox cmb = (reg.FindControl("cmbNomRol") as RadComboBox);
                TextBox txtNom = (reg.FindControl("txtNomSubmnu") as TextBox);
                TextBox txtorden = (reg.FindControl("txtOrden") as TextBox);

                ModSubMenu Datos = new ModSubMenu();
                Datos.MenuId = Convert.ToInt32(rdcMenus.SelectedValue);
                Datos.SubMenuId = Convert.ToInt32(hsm.Value);
                Datos.Orden = Convert.ToInt32(txtorden.Text);
                Datos.RoleId = hf.Value.ToString();
                Datos.RoleIdNvo = cmb.SelectedValue.ToString();
                Datos.Nombre = txtNom.Text;

                if (!string.IsNullOrWhiteSpace(hf.Value))
                {
                    blnRepsuesta = Ejecuta.GuardarCambiosMenus(Datos);
                }

            }
            if (blnRepsuesta)
            {
                SeleccionMenu();
                Mensajes("Se actualizao la información del SubMenu correctamente...");
            }
            else
            {
                Mensajes("No fue posible guardar sus cambios...");
            }

        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            grvSubMnus.DataSource = null;
            grvSubMnus.DataBind();
            CargaMnus();
            Response.Redirect("../../Default.aspx");
        }
        protected void btnGuardarMnu_Click(object sender, EventArgs e)
        {
            bool blnRespuesta = false;
            List<ModMenu> lstResultadovalidacion = new List<ModMenu>();
            ModMenu campos = new ModMenu();
            Menusapp Ejecuta = new Menusapp();
            grvMenusExistentes.Visible = false;
            grvMenusExistentes.DataSource = null;
            grvMenusExistentes.DataBind();

            if (string.IsNullOrWhiteSpace(txtNombre.Text) && string.IsNullOrWhiteSpace(txtOrden.Text))
            {
                Mensajes("Imposible continuar, es necesario proporcione un nombre y el número de orden que este ocupara.");
                txtNombre.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtOrden.Text))
            {
                Mensajes("Imposible continuar, es necesario proporcione un nombre.");
                txtNombre.Focus();
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && string.IsNullOrWhiteSpace(txtOrden.Text))
            {
                Mensajes("Imposible continuar, es necesario proporcione  el número de orden que este ocupara.");
                txtOrden.Focus();
                return;
            }


            campos.Nombre = txtNombre.Text;
            campos.Orden = Convert.ToInt32(txtOrden.Text);

            lstResultadovalidacion = Ejecuta.ValidaMenus(campos.Nombre);
            if (lstResultadovalidacion.Count == 0)
            {
                blnRespuesta = Ejecuta.GuardarAltaMenus(campos);
                if (blnRespuesta)
                {
                    Mensajes("El nuevo menú fue registrado correctamente.");
                }
                else
                {
                    Mensajes("No fue posible registrar el nuevo menú.");
                }
            }
            else
            {
                Mensajes("Imposible continuar, ya existen menus referentes a ese nombre.");
                grvMenusExistentes.DataSource = lstResultadovalidacion;
                grvMenusExistentes.DataBind();
                grvMenusExistentes.Visible = true;
            }
        }
        protected void btnCancelarMnu_Click(object sender, EventArgs e)
        {
            grvSubMnus.DataSource = null;
            grvSubMnus.DataBind();
            CargaMnus();
            mvUsuarios.SetActiveView(vReasignaciones);
        }
        protected void imgbtnAltaMenu_Click(object sender, ImageClickEventArgs e)
        {
            mvUsuarios.SetActiveView(vAltaMenus);
        }

        protected void rdcMenus2_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {



        }
        private void CargaRoles()
        {
            RadComboBoxItem elemento;
            Menusapp Ejecuta = new Menusapp();
            List<ModRoles> lstResultadosRol = new List<ModRoles>();
            lstResultadosRol = Ejecuta.ObtenRoles();

            if (lstResultadosRol != null)
            {
                if (lstResultadosRol.Count > 0)
                {
                    foreach (ModRoles itmRol in lstResultadosRol)
                    {
                        //carga dropdownlist por cada registro
                        elemento = new RadComboBoxItem(itmRol.RoleName, itmRol.RoleId.ToString());

                        rcbRoles.Items.Add(elemento);
                    }
                    chklstRoles.Items.Clear();
                    chklstRoles.DataSource = lstResultadosRol;
                    chklstRoles.DataTextField = "RoleName";
                    chklstRoles.DataValueField = "RoleId";
                    chklstRoles.DataBind();
                }
            }
        }

        protected void btnGuardarSubmnu_Click(object sender, EventArgs e)
        {
            bool blnRepuesta = false;
            ModSubMenu campos = new ModSubMenu();
            try
            {
                if (rdcMenus2.SelectedValue == null)
                {
                    Mensajes("Es necesario seleccione un menú...");
                    rdcMenus2.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNomSubmenu.Text))
                {
                    Mensajes("Es necesario proporcione un nombre...");
                    txtNomSubmenu.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtOrdenSubMnu.Text))
                {
                    Mensajes("Es necesario proporcione un número de orden...");
                    txtOrdenSubMnu.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtURL.Text))
                {
                    Mensajes("Es necesario proporcione la url de ubicación para el submenu...");
                    txtURL.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(rcbRoles.SelectedValue))
                {
                    Mensajes("Es necesario seleccione un rol para asignarlo al subnmenu...");
                    rcbRoles.Focus();
                    return;
                }

                int IdMenu = 0;
                List<ModSubMenu> lstResultados = new List<ModSubMenu>();
                Menusapp Ejecuta = new Menusapp();

                IdMenu = Convert.ToInt32(rdcMenus2.SelectedValue);
                campos = new ModSubMenu();

                campos.MenuId = IdMenu;
                campos.Nombre = txtNomSubmenu.Text;
                campos.Orden = Convert.ToInt32(txtOrdenSubMnu.Text);
                campos.URL = txtURL.Text;
                campos.RoleId = rcbRoles.SelectedValue;

                blnRepuesta = Ejecuta.GuardarAltaSubMenus(campos);
                if (blnRepuesta)
                {
                    Mensajes("El submenu fue registrado y asignado a un rol correctamente.");
                }
                else
                {
                    Mensajes("No fue posible registraar el submenu.");
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.Controles.ControlMnu.Menus", "btnGuardarSubMenu_click", "Ejecuta.GuardarAltaSubMenus(" + campos + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("ocurrio un error inesperado, contacte al administrador.");
            }

        }

        protected void imgbtnAltaSubMenu_Click(object sender, ImageClickEventArgs e)
        {
            mvUsuarios.SetActiveView(vAltaSubmenu);
        }

        protected void btnCancelarSubmnu_Click(object sender, EventArgs e)
        {
            grvSubMnus.DataSource = null;
            grvSubMnus.DataBind();
            CargaMnus();
            mvUsuarios.SetActiveView(vReasignaciones);
        }

        protected void grvSubMnus_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bool blnResultado = false;
            Menusapp Ejecutar = new Menusapp();
            TextBox txtNom = (grvSubMnus.Rows[e.RowIndex].Cells[0].FindControl("txtNomSubmnu") as TextBox);
            RadComboBox cmb = (grvSubMnus.Rows[e.RowIndex].Cells[0].FindControl("cmbNomRol") as RadComboBox);

            if (string.IsNullOrWhiteSpace(cmb.SelectedValue))
            {
                Mensajes("Este submenú no cuenta con un rol asociado.");
                return;
            }

            blnResultado = Ejecutar.EliminaRolMenu(txtNom.Text, cmb.SelectedValue);
            if (blnResultado)
            {
                SeleccionMenu();
                Mensajes("El submenu se a desasociado del rol asignado correctamente.");
            }
            else
            {
                Mensajes("No fue posible desaasociar el rol del submenu.");
            }

        }

        private void SeleccionMenu()
        {
            List<ModSubMenu> lstResultados = new List<ModSubMenu>();
            Menusapp Ejecuta = new Menusapp();
            int IdMenu = 0;

            if (rdcMenus.SelectedValue == null)
            {
                Mensajes("Debé seleecionar un menú...");
                return;
            }

            IdMenu = Convert.ToInt32(rdcMenus.SelectedValue);
            lstResultados = Ejecuta.ObtenSubMenus(IdMenu);

            if (lstResultados != null)
            {
                if (lstResultados.Count > 0)
                {
                    grvSubMnus.DataSource = null;
                    grvSubMnus.DataBind();
                    grvSubMnus.DataSource = lstResultados;
                    grvSubMnus.DataBind();
                }
                else
                {
                    grvSubMnus.DataSource = null;
                    grvSubMnus.DataBind();
                    Mensajes("No existen resultados");
                }
            }
            else
            {
                grvSubMnus.DataSource = null;
                grvSubMnus.DataBind();
                Mensajes("No existen resultados");
            }
        }

        protected void rdcbSubmnu_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void rdcbSubmnu_SelectedIndexChanged1(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void imgbtnAgregaRolesSubmenu_Click(object sender, ImageClickEventArgs e)
        {
            mvUsuarios.SetActiveView(VAsignaRolesSubMnus);
        }

        protected void btnGuardarRolessubmnu_Click(object sender, EventArgs e)
        {
            string RoleId = "";
            int SubMenuID = 0;
            bool blnRolesCheckeados = false;
            bool blnResultado = false;
            Menusapp Ejecuta = new Menusapp();

            if (string.IsNullOrWhiteSpace(rdcbSubmnuroles.SelectedValue))
            {
                Mensajes("Imposible continuar, debe seleccionar un submenu.");
                return;
            }
            SubMenuID = Convert.ToInt32(rdcbSubmnuroles.SelectedValue);
            foreach (ListItem elemento in chklstRoles.Items)
            {
                if (elemento.Selected)
                {
                    blnRolesCheckeados = true;
                    break;
                }
            }


            if (blnRolesCheckeados)
            {
                Ejecuta.EliminaRolSubMenu(SubMenuID);
                foreach (ListItem elemento in chklstRoles.Items)
                {
                    if (elemento.Selected)
                    {
                        RoleId = elemento.Value;
                        blnResultado = Ejecuta.GuardarRolesxSubmenus(RoleId, SubMenuID);
                    }
                }
                if (blnResultado)
                {
                    Mensajes("El submenu fue asociado a los roles seleccionados correctamente.");
                }
                else
                {
                    Mensajes("No fue posible asociar los roles seleccionados.");
                }
            }
            else
            {
                Mensajes("No existen roles seleccionados, almenos seleccione uno para poder continuar.");
            }
        }

        protected void btnCanclearRolessubmenu_Click(object sender, EventArgs e)
        {
            mvUsuarios.SetActiveView(vReasignaciones);
        }

        protected void rdcbSubmnu_SelectedIndexChanged2(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void rdcbmnu_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            List<ModSubMenu> lstResultados = new List<ModSubMenu>();
            Menusapp Ejecuta = new Menusapp();
            int IdMenu = 0;

            if (rdcbmnu.SelectedValue == null)
            {
                Mensajes("Debé seleecionar un menú...");
                return;
            }

            LimpiaChksRoles();
            IdMenu = Convert.ToInt32(rdcbmnu.SelectedValue);
            lstResultados = Ejecuta.ObtenSubMenus2(IdMenu);

            if (lstResultados != null)
            {
                if (lstResultados.Count > 0)
                {
                    rdcbSubmnuroles.Items.Clear();
                    rdcbSubmnuroles.DataSource = lstResultados;
                    rdcbSubmnuroles.DataTextField = "Nombre";
                    rdcbSubmnuroles.DataValueField = "SubMenuId";
                    rdcbSubmnuroles.DataBind();
                }
                else
                {
                    rdcbSubmnuroles.DataSource = null;
                    rdcbSubmnuroles.DataBind();
                    Mensajes("No existen resultados");
                }
            }
            else
            {
                rdcbSubmnuroles.DataSource = null;
                rdcbSubmnuroles.DataBind();
                Mensajes("No existen resultados");
            }
        }

        protected void rdcbSubmnuroles_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            List<ModRoles> lstResultados = new List<ModRoles>();
            Menusapp Ejecuta = new Menusapp();
            int SubMenuId = 0;

            SubMenuId = Convert.ToInt32(rdcbSubmnuroles.SelectedValue);
            lstResultados = Ejecuta.ObtenRolesxSubmnu(SubMenuId);

            if (lstResultados.Count > 0)
            {
                lblmsg.Text = "";
                lblmsg.Visible = false;
                LimpiaChksRoles();
                foreach (ModRoles reg in lstResultados.ToList())
                {
                    foreach (ListItem elemento in chklstRoles.Items)
                    {
                        if (elemento.Value == reg.RoleId)
                        {
                            elemento.Selected = true;
                        }
                    }
                }
            }
            else
            {
                lblmsg.Text = "El submenu seleccionado no cuenta con un rol asociado.";
                lblmsg.Visible = true;
                foreach (ListItem elemento in chklstRoles.Items)
                {
                    elemento.Selected = false;
                }
            }

        }

        private void LimpiaChksRoles()
        {
            foreach (ListItem elemento in chklstRoles.Items)
            {
                elemento.Selected = false;
            }
        }

        protected void grvSubMnus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            bool blnResultado = false;
            int SubMnuId = 0;
            bool blnEsValido = int.TryParse(e.CommandArgument.ToString(), out SubMnuId);

            if (blnEsValido)
            {
                switch (e.CommandName.ToString())
                {
                    case "Eliminasubmnu":
                        Menusapp Ejecuta = new Menusapp();
                        blnResultado = Ejecuta.EliminaSubMenu(SubMnuId);

                        if (blnResultado)
                        {
                            Mensajes("El submenu ha sido eliminado correctamente...");
                            SeleccionMenu();
                        }

                        break;
                }
            }


        }
    }
}