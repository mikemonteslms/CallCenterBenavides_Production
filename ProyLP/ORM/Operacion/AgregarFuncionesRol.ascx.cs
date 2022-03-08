using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ORMOperacion
{
    public partial class AgregarFuncionesRol : System.Web.UI.UserControl
    {
        /// <summary>
        /// Vasriable para obtener el nombre del rol que se va a cargar
        /// </summary>
        public string Rol
        {
            get
            {
                return (lblRol.Text);
            }
            set
            {
                lblRol.Text = value;
            }
        }

        /// <summary>
        /// Variable privada para identificar cuando se está ingresando por primera vez y cuando es ejecución del botón
        /// </summary>
        private bool _isPostBack = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!_isPostBack)
            {                
                this.SqlDataSource2.SelectParameters["rol"].DefaultValue = Rol;
                this.DataBind();
            }
        }

        /// <summary>
        /// Metodo para poder identificar si es un primer acceso o no
        /// </summary>
        /// <param name="savedState"></param>
        protected override void LoadViewState(object savedState)
        {
            object[] state = (object[])savedState;

           
                string controlID = (string)state[1];
                //Se compara el nombre del control ascx y por esta razón es que se pide que sea único el ID cuando se asigna en la pagina de administracionPerfiles.aspx
                if (controlID == this.ID)
                {
                    _isPostBack = true;
                }
                else
                {
                    _isPostBack = false;
                }

                base.LoadViewState(state[2]);
            
        }

        /// <summary>
        /// Guarda en un objeto el valor del control que se está cargando
        /// </summary>
        /// <returns></returns>
        protected override object SaveViewState()
        {
            object[] state = new object[] {
                0,
                this.ID,
                base.SaveViewState()
            };
            return state;
        }


        protected void RadTreeView1_NodeDataBound(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
        {
            //De acuerdo al rol que se esté visualizando se debe de poner con palomita todas las funciones que tenga asociadas
            DataView dv = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
            dv.RowFilter = "nombre = '" + e.Node.Text + "'";

            if (dv.Count > 0)
            {
                e.Node.Checked = true;
            }
        }
            
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
            //Leer nodo por nodo y evaluar si se está agregando o se está eliminando
            foreach (RadTreeNode nodo in RadTreeView1.GetAllNodes())
            { 
                //Si está con palomita
                if (nodo.Checked)
                {
                    //Revisar que no esté en el listado para insertar el registro
                    dv.RowFilter = "nombre = '" + nodo.Text + "'";
                    if (dv.Count == 0)
                    {
                        //Insertar el registro
                        CNegocio.csMenuNegocio.ModificaRolMenu("I", int.Parse(nodo.Value) - 1000, Rol);
                    }
                }
                else
                {
                    //Revisar que esté en el listado para eliminar el registro
                    dv.RowFilter = "nombre = '" + nodo.Text + "'";
                    if (dv.Count > 0)
                    {
                        //Eliminar el registro
                        CNegocio.csMenuNegocio.ModificaRolMenu("B", int.Parse(nodo.Value) - 1000, Rol);
                    }
                }               

            }

            //Close the active ToolTip.
            ScriptManager.RegisterClientScriptBlock(
                this.Page,
                this.GetType(),
                "WebUserControlSript",
                "CloseActiveToolTip('" + this.ID + "')",
                true);

        }
    }
}