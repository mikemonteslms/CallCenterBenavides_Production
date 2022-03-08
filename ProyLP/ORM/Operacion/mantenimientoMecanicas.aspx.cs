using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ORMOperacion
{
    public partial class mantenimientoMecanicas : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (PreviousPage != null)
                {
                    inicializaControles();
                }
            }
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
                if (PreviousPage != null)
                {
                    if (PreviousPage.Mec != null)
                    {
                        Master.Menu = "Parametros";
                        Master.Submenu = "Mecanicas";
                        lstMarcasSource.DataBind();
                        Session["mecanica_id"] = PreviousPage.Mec;
                        //llenaProductos(Session["mecanica_id"].ToString());
                    }
                    else
                    {
                        Server.Transfer("editarMecanicas.aspx");
                    }
                }
                else
                {
                    Server.Transfer("editarMecanicas.aspx");
                }
            }
        }

        protected void inicializaControles()
        {
            Session["inicializando"] = true;

            DataTable dataTable = new DataTable();
            string query = "select m.clave,m.descripcion,m.descripcion_larga, m.tipo_mecanica_id,programa_id,m.tipo_participante_id, "
            + "m.fecha_inicial_vigencia,m.fecha_final_vigencia,m.factor_acumulacion, m.dias_para_cupon, m.beneficio_id, md.marca_id,md.producto_id,p.marca_id as marca_producto "
            + "from mecanica m inner join mecanica_detalle md on md.mecanica_id = m.id LEFT join producto p on p.id = md.producto_id where m.id = " + PreviousPage.Mec;

            //string query = "select m.clave,m.descripcion,m.descripcion_larga, m.tipo_mecanica_id,programa_id,m.tipo_participante_id, m.fecha_inicial_vigencia,m.fecha_final_vigencia, "
            //+ "m.factor_acumulacion, md.marca_id,md.producto_id,marca_producto = case when p.marca_id is null then md.marca_id else p.marca_id end from mecanica m "
            //+ "inner join mecanica_detalle md on md.mecanica_id = m.id LEFT join producto p on p.id = md.producto_id where m.id = " + PreviousPage.Mec + "order by marca_producto";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;

            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
            conn.Close();
            da.Dispose();

            if (dataTable.Rows.Count > 0)
            {
                rcbTipoMec.DataBind();
                rcbPrograma.SelectedValue = dataTable.Rows[0]["programa_id"].ToString();
                rcbTipoMec.SelectedValue = dataTable.Rows[0]["tipo_mecanica_id"].ToString();
                rcbTipoPar.SelectedValue = dataTable.Rows[0]["tipo_participante_id"].ToString();
                txtClave.Text = dataTable.Rows[0]["clave"].ToString();
                txtNombre.Text = dataTable.Rows[0]["descripcion"].ToString();
                txtDescripcion.Text = dataTable.Rows[0]["descripcion_larga"].ToString();
                factAcum.Text = dataTable.Rows[0]["factor_acumulacion"].ToString();
                fechaInicial.SelectedDate = Convert.ToDateTime(dataTable.Rows[0]["fecha_inicial_vigencia"].ToString());
                fechaFinal.SelectedDate = Convert.ToDateTime(dataTable.Rows[0]["fecha_final_vigencia"].ToString());

                RadComboBoxItem tipoMecanica = rcbTipoMec.Items.FindItemByText("ARTICULO GRATIS EN LA COMPRA DE N ARTICULOS");
                if (tipoMecanica.Selected)
                {
                    rcbTipoMec.SelectedValue = dataTable.Rows[0]["tipo_mecanica_id"].ToString();
                    diasAcum.Visible = true;
                    beneficio.Visible = true;

                    diasAcum.Text = dataTable.Rows[0]["dias_para_cupon"].ToString();
                    beneficio.SelectedValue = dataTable.Rows[0]["beneficio_id"].ToString();
                }

                llenaProductos(PreviousPage.Mec);
                foreach (DataRow row in dataTable.Rows)
                {
                    object marca_id = row["marca_id"];
                    object producto_id = row["producto_id"];
                    if (!Convert.IsDBNull(marca_id))
                    {
                        RadListBoxItem foundItemMarca = lstMarcasSource.FindItemByValue(marca_id.ToString());
                        foundItemMarca.Checked = true;
                        lstMarcasSource.Transfer(foundItemMarca, lstMarcasSource, lstMarcasInsert);
                    }

                    if (!Convert.IsDBNull(producto_id))
                    {
                        RadListBoxItem foundItemMarcaInsert = lstMarcasInsert.FindItemByValue(row["marca_producto"].ToString());

                        if (foundItemMarcaInsert == null)
                        {
                            RadListBoxItem foundItemMarca = lstMarcasSource.FindItemByValue(row["marca_producto"].ToString());
                            foundItemMarca.Checked = false;
                            lstMarcasSource.Transfer(foundItemMarca, lstMarcasSource, lstMarcasInsert);
                        }
                        else
                        {
                            foundItemMarcaInsert.Checked = false;
                        }

                        RadListBoxItem foundItemProducto = lstProductosSource.FindItemByValue(producto_id.ToString());
                        lstProductosSource.Transfer(foundItemProducto, lstProductosSource, lstProductosInsert);
                    }
                }
                lstMarcasSource.ClearSelection();
                EliminaProductosRepetidos(PreviousPage.Mec);
                lstProductosSource.ClearSelection();
            }
            else
            {
                RadWindowManager1.RadAlert("Configuracion Incompleta", 330, 180, "", null);
            }
            Session["inicializando"] = null;
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
                    sql.SelectCommand = "select id,'('+clave+') ' + descripcion_larga as descripcion_larga from producto where marca_id in (" + inMarcas + ") order by marca_id, descripcion";
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

        protected void llenaProductos(string marca_id)
        {
            SqlDataSource sql = new SqlDataSource();
            sql.ID = "dsProductos";
            sql.ConnectionString = ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;
            sql.SelectCommand = "select id,'('+clave+') ' + descripcion_larga as descripcion_larga, marca_id from producto where marca_id in (select p.marca_id  from mecanica m "
            + "inner join mecanica_detalle md on md.mecanica_id = m.id LEFT join producto p on p.id = md.producto_id where m.id = " + marca_id + " ) "
            + "order by marca_id,descripcion ";
            lstProductosSource.DataSource = sql;
            lstProductosSource.DataBind();
        }

        protected void EliminaProductosRepetidos(string marca_id)
        {
            SqlDataSource sql = new SqlDataSource();
            sql.ID = "dsProductos";
            sql.ConnectionString = ConfigurationManager.ConnectionStrings["GaleniaTest"].ConnectionString;
            sql.SelectCommand = "select id,'('+clave+') ' + descripcion_larga as descripcion_larga, marca_id from producto where marca_id in (select p.marca_id  from mecanica m "
            + "inner join mecanica_detalle md on md.mecanica_id = m.id LEFT join producto p on p.id = md.producto_id where m.id = " + marca_id + " ) and id not in "
            + "(select producto_id from mecanica_detalle where mecanica_id = " + marca_id + " and producto_id is not null) order by marca_id,descripcion ";
            lstProductosSource.DataSource = sql;
            lstProductosSource.DataBind();
        }

        protected void lstProductosSource_Transferred(object sender, RadListBoxTransferredEventArgs e)
        {
            if (txtFiltrarProducto.Text.Length > 0)
                txtFiltrarProducto.Text = "";
        }

        protected void lstMarcasInsert_ItemCheck(object sender, RadListBoxItemEventArgs e)
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
                sql.SelectCommand = "select id,'('+clave+') ' + descripcion_larga as descripcion_larga from producto where marca_id in (" + inMarcas + ") order by marca_id, descripcion";
                lstProductosSource.DataSource = sql;
                lstProductosSource.DataBind();
            }
        }

        protected void lstMarcasSource_Transferring(object sender, RadListBoxTransferringEventArgs e)
        {
            foreach (RadListBoxItem item in e.Items)
            {
                if (e.DestinationListBox == lstMarcasSource)
                {
                    item.Checked = false;
                }
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
            if (Session["inicializando"] == null)
            {
                llenaProductos();
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string mecid = Session["mecanica_id"].ToString();

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
                mecanica.ActualizaMecanica(mecid);
                mecanica.Mecanica_id = Convert.ToInt32(mecid);

                //eliminar productos anteriores
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@mecanica_id", mecanica.Mecanica_id));
                csDataBase database = new csDataBase();
                database.Query = "Delete From mecanica_detalle where mecanica_id = @mecanica_id";
                database.Parametros = parametros;
                database.EsStoreProcedure = false;
                database.acutualizaDatos();

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
                RadWindowManager1.RadAlert("Mecanica actualizada con exito!", 330, 180, "", null);
                //Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('Mecanica configurada con exito');", true);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(Type.GetType("System.String"), "ALERT", "alert('Error al actualizar mecanica: " + Server.HtmlEncode(ex.Message) + " ');", true);
            }
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

    }
}