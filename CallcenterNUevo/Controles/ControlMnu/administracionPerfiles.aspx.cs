using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Datos;
using Telerik.Web.UI;

namespace CallcenterNUevo.Controles.ControlMnu
{
    public partial class AdministracionPerfiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaRoles();
            }
        }

        protected void imgbtnAltaRol_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelaBusca_Click(object sender, EventArgs e)
        {

        }

        protected void grvDatosRoles_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridDataItem item;
            selRpleId.Value = e.CommandArgument.ToString();

            switch (e.CommandName.ToString())
            {
                case "EdtarRol":
                    item = (GridDataItem)e.Item;

                    txtNomRol.Text = item.Cells[5].Text;
                    txtDescRol.Text = item.Cells[6].Text;

                    mvRoles.SetActiveView(vModificaRol);
                    break;
                case "VerDetalle":
                    List<ModSubmnusxRol> lstResultados = new List<ModSubmnusxRol>();
                    lstResultados = ObtenSubmnusxRol(selRpleId.Value);

                    if (lstResultados.Count > 0)
                    {
                        grvDetalleSubmnuxRol.DataSource = lstResultados;
                        grvDetalleSubmnuxRol.DataBind();
                    }
                    else
                    {
                        grvDetalleSubmnuxRol.DataSource = null;
                        grvDetalleSubmnuxRol.DataBind();
                    }

                    break;
            }
        }

        protected void grvDatosRoles_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            CargaRoles();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ModificarRol(selRpleId.Value))
                {
                    Mensajes("El rol fue modificado correctamente.");
                }
                else
                {
                    Mensajes("El rol no pudo ser modificado, verifique su información e Intente de nuevo.");
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.Controles.ControlMnu.AdministracionPerfiles", "btnGuaradar_Click()", "ModificarRol(" + selRpleId.Value + ")", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar modificar el rol, contacte al administrador");
            }

        }

        protected void btnCanclear_Click(object sender, EventArgs e)
        {
            CargaRoles();
            mvRoles.SetActiveView(vcatRoles);
        }

        protected void btnRegistraNvoRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validaciones())
                {
                    if (AltaRol())
                    {
                        Mensajes("El nuevo rol fue registrado correctamente.");
                        txtNomRolAlta.Text = "";
                        txtDesRol.Text = "";
                        txtNomRolAlta.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.Controles.ControlMnu.AdministracionPerfiles", "btnRegistraNuevoRol_Click()", "AltaRol()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar registrar un nuevo rol, contacte al administrador");
            }
        }

        protected void btnCancelaAltaRol_Click(object sender, EventArgs e)
        {
            CargaRoles();
            mvRoles.SetActiveView(vcatRoles);
        }

        private void CargaRoles()
        {
            try
            {
                List<ModcatRoles> lstResultado = new List<ModcatRoles>();
                Usuariosapp Ejecuta = new Usuariosapp();

                lstResultado = Ejecuta.ObtenCatRoles();

                grvDatosRoles.DataSource = lstResultado;
                grvDatosRoles.DataBind();
            }
            catch (Exception ex)
            {
                Bitacora.Bitacora.Registrar(Bitacora.Bitacora.TipoRegistro.ERRORES, System.Reflection.Assembly.GetExecutingAssembly(), "BACK", "CallCenterNUevo.Controles.ControlMnu.AdministracionPerfiles", "CargaRoles()", "Ejecuta.ObtenCatRoles()", "Ocurrio un error:", this.User.Identity.Name.ToString(), ex);
                Mensajes("Ocurrio un error al intentar cargar el catálogo de roles, contacte al administrador");
            }

        }
        private bool ModificarRol(string RoleID)
        {
            bool blnResultado = true;
            try
            {
                ModcatRoles campos = new ModcatRoles();
                Usuariosapp Ejecuta = new Usuariosapp();

                campos.RoleId = RoleID;
                //campos.ApplicationId = "8CDB33A5-83CC-4FD1-9EB4-B0375A8BE160"; //CallCenter
                campos.RoleName = txtNomRol.Text;
                campos.Descripcion = txtDescRol.Text;

                blnResultado = Ejecuta.ModificaRolapp(campos);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return blnResultado;
        }
        private bool AltaRol()
        {
            bool blnResultado = true;
            try
            {
                ModcatRoles campos = new ModcatRoles();
                Usuariosapp Ejecuta = new Usuariosapp();

                campos.ApplicationId = "8CDB33A5-83CC-4FD1-9EB4-B0375A8BE160"; //CallCenter
                campos.RoleName = txtNomRolAlta.Text;
                campos.Descripcion = txtDesRol.Text;

                blnResultado = Ejecuta.RegistrarRolapp(campos);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return blnResultado;
        }
        private bool Validaciones()
        {
            bool blnRespuesta = true;

            if (string.IsNullOrWhiteSpace(txtNomRolAlta.Text))
            {
                Mensajes("Es necesario proporcione el nombre del rol.");
                txtNomRolAlta.Focus();
                return blnRespuesta = false;
            }

            if (string.IsNullOrWhiteSpace(txtDesRol.Text))
            {
                Mensajes("Es necesario proporcione una descripción del rol.");
                txtDesRol.Focus();
                return blnRespuesta = false;
            }

            return blnRespuesta;
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void imgbtnAltaRoles_Click(object sender, ImageClickEventArgs e)
        {
            mvRoles.SetActiveView(vAltaRol);
        }

        protected void grvDetalleSubmnuxRol_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            ObtenSubmnusxRol(selRpleId.Value);
        }

        private List<ModSubmnusxRol> ObtenSubmnusxRol(string RoleId)
        {
            List<ModSubmnusxRol> lstResultados = new List<ModSubmnusxRol>();
            Menusapp Ejecuta = new Menusapp();
            lstResultados = Ejecuta.ObtenSubMenusxRoles(selRpleId.Value);

            return lstResultados;
        }

    }
}