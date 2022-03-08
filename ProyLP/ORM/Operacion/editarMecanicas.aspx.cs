using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ORMOperacion
{
    public partial class editarMecanicas : System.Web.UI.Page
    {

        private string mec;

        public string Mec
        {
            get { return mec; }
            set { mec = value; }
        }

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
                //Master.Menu = "Parametros";
                //Master.Submenu = "Mecanicas";
            }
        }

        protected void llenaProductos()
        {
            string inMarcas = "";
            SqlDataSource sql = new SqlDataSource();
            sql.ID = "dsProductos";
            sql.ConnectionString = ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;
            if (lstMarcasInsert.Items.Count > 0)
            {

                foreach (RadListBoxItem item in lstMarcasInsert.Items)
                {
                    if (!item.Checked)
                    {
                        if (item.Index != (lstMarcasInsert.Items.Count - 1))
                        {
                            inMarcas += item.Value + ", ";
                        }
                        else
                        {
                            inMarcas += item.Value;
                        }
                    }
                }

                if (inMarcas.Equals(""))
                {
                    lstProductosInsert.DataSource = "";
                    lstProductosInsert.DataBind();
                    lstProductosSource.DataSource = "";
                    lstProductosSource.DataBind();
                }
                else
                {
                    if (lstProductosInsert.Items.Count > 0)
                    {
                        string inProductosInsert = "";
                        foreach (RadListBoxItem item in lstProductosInsert.Items)
                        {
                            if (item.Index != (lstMarcasInsert.Items.Count - 1))
                            {
                                inProductosInsert += item.Value + ", ";
                            }
                            else
                            {
                                inProductosInsert += item.Value;
                            }
                        }
                        sql.SelectCommand = "select id,descripcion_larga, marca_id from producto where marca_id in (" + inMarcas + ") and id not in (" + inProductosInsert
                            + ") order by marca_id, descripcion";
                    }
                    else
                    {
                        sql.SelectCommand = "select id,descripcion_larga, marca_id from producto where marca_id in (" + inMarcas + ") order by marca_id, descripcion";
                    }
                    lstProductosSource.DataSource = sql;
                    lstProductosSource.DataBind();
                }
            }
            else
            {
                lstProductosInsert.DataSource = "";
                lstProductosInsert.DataBind();
                lstProductosSource.DataSource = "";
                lstProductosSource.DataBind();
            }
            txtFiltrarMarca.Text = "";
        }

        protected void lstProductosSource_Transferred(object sender, RadListBoxTransferredEventArgs e)
        {
            if (txtFiltrarProducto.Text.Length > 0)
                txtFiltrarProducto.Text = "";
        }

        protected void lstProductosInsert_ItemCheck(object sender, RadListBoxItemEventArgs e)
        {
            string inMarcas = "";
            SqlDataSource sql = new SqlDataSource();
            sql.ID = "dsProductos";
            sql.ConnectionString = ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;
            if (lstMarcasInsert.Items.Count > 0)
            {
                foreach (RadListBoxItem item in lstMarcasInsert.Items)
                {

                    if (item.Index != (lstMarcasInsert.Items.Count - 1))
                    {
                        if (item.Checked)
                        {
                            inMarcas += "-1, ";
                        }
                        else
                        {
                            inMarcas += item.Value + ", ";
                        }
                    }
                    else
                    {
                        if (item.Checked)
                        {
                            inMarcas += "-1";
                        }
                        else
                        {
                            inMarcas += item.Value;
                        }
                    }
                }
            }
            if (inMarcas.Equals(""))
            {
                lstProductosInsert.DataSource = "";
                lstProductosInsert.DataBind();
                lstProductosSource.DataSource = "";
                lstProductosSource.DataBind();
            }
            else
            {
                sql.SelectCommand = "select id,descripcion_larga, marca_id from producto where marca_id in (" + inMarcas + ") order by marca_id";
                lstProductosSource.DataSource = sql;
                lstProductosSource.DataBind();
            }
        }


        protected void lstMarcasSource_Transferring(object sender, RadListBoxTransferringEventArgs e)
        {
            foreach (RadListBoxItem item in e.Items)
            {
                item.Checked = false;
            }
        }

        protected void lstMarcasInsert_CheckAllCheck(object sender, RadListBoxCheckAllCheckEventArgs e)
        {
            if (e.CheckAllChecked)
            {
                lstProductosInsert.DataSource = "";
                lstProductosInsert.DataBind();
                lstProductosSource.DataSource = "";
                lstProductosSource.DataBind();
            }
            else
            {
                llenaProductos();
            }
        }

        protected void lstMarcasSource_Transferred(object sender, RadListBoxTransferredEventArgs e)
        {
            llenaProductos();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                csMecanicas mecanica = new csMecanicas();
                mecanica.Clave = txtClave.Text;
                mecanica.Descripcion = txtNombre.Text;
                mecanica.Descripcion_larga = txtDescripcion.Text;
                mecanica.Tipo_mecanica_id = rcbTipoMec.SelectedValue;
                mecanica.Programa_id = rcbPrograma.SelectedValue;
                mecanica.Tipo_participante_id = rcbTipoPar.SelectedValue;
                mecanica.Fecha_inicial = fechaInicial.SelectedDate;
                mecanica.Fecha_final = fechaFinal.SelectedDate;
                mecanica.Factor_acumulacion = double.Parse(factAcum.Text);
                mecanica.Usuario_id = (Guid)Membership.GetUser().ProviderUserKey;
                if (rcbTipoMec.SelectedItem.Text.Contains("ARTICULO GRATIS"))
                {
                    mecanica.Beneficio_id = Int64.Parse(beneficio.SelectedValue);
                    mecanica.Dias_para_cupon = int.Parse(diasAcum.Text);
                }
                mecanica.InsertaMecanica();

                if (lstMarcasInsert.Items.Count > 0)
                {
                    foreach (RadListBoxItem marca in lstMarcasInsert.Items)
                    {
                        if (marca.Checked)
                        {
                            mecanica.Marca_id = Int32.Parse(marca.Value);
                            mecanica.InsertaMecanicaDetalle();
                        }
                    }
                    if (lstProductosInsert.Items.Count > 0)
                    {
                        mecanica.Marca_id = null;
                        foreach (RadListBoxItem producto in lstProductosInsert.Items)
                        {
                            mecanica.Producto_id = Int32.Parse(producto.Value);
                            mecanica.InsertaMecanicaDetalle();
                        }
                    }
                }
                else
                {
                    mecanica.InsertaMecanicaDetalle();
                }
                RadWindowManager1.RadAlert("Mecanica configurada con exito!", 330, 180, "", null);
                //Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('Mecanica configurada con exito');", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('Error al insertar mecanica: " + Server.HtmlEncode(ex.Message) + " ');", true);
            }
        }

        protected void rdbEditar_Click(object sender, EventArgs e)
        {
            mec = ((RadButton)sender).CommandArgument.ToString();
            //RadTabStrip1.SelectedIndex = 2;
            //RadMultiPage1.SelectedIndex = 2;
            Server.Transfer("mantenimientoMecanicas.aspx", true);
        }

        protected void rcbTipoMec_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (e.Text.Contains("ARTICULO GRATIS"))
            {
                beneficio.Visible = true;
                diasAcum.Visible = true;
            }
            else
            {
                beneficio.Visible = false;
                diasAcum.Visible = false;
            }
        }

        protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
        {
            if (e.Tab.Text.Equals("Editar"))
            {
                rgdMecanicas.DataBind();
            }
        }
    }
}