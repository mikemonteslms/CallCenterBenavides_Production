using System;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ORMOperacion.registrar
{
    public partial class cargaParticipantes : System.Web.UI.Page
    {
        // Global Variables.        
        private DataTable dt = new DataTable();
        csDataBase query = new csDataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }
            try
            {
                if (!Page.IsPostBack)
                {
                    /* Deshabilita validador de busqueda */
                    Master.CriterioBuqueda(false); // de la master
                    FilaVacia("A");
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("Error.aspx"); 
            }
        }

        protected void CargaMarca(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            csDataBase query = new csDataBase();
            query.Query = "SELECT id, clave, descripcion FROM programa WHERE fecha_baja IS NULL ORDER BY id";
            query.EsStoreProcedure = false;
            DropDownList ddlMarca = e.Item.FindControl("ddlMarca") as DropDownList;
            ddlMarca.DataSource = query.dtConsulta();
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("", ""));
        }

        protected void CargaConcesionaria(string clave_marca, DropDownList ddlConcesionaria)
        {
            csDataBase query = new csDataBase();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@clave", clave_marca));
            query.EsStoreProcedure = false;
            DataTable dtConcesionaria = query.dtConsulta("SELECT id, clave, descripcion FROM distribuidor WHERE fecha_baja IS NULL AND clave <> @clave AND clave <> 'HEAVY' AND programa_id IN(SELECT TOP 1 ID FROM programa WHERE clave = @clave) ORDER BY clave", param, false);
            ddlConcesionaria.Items.Clear();
            ddlConcesionaria.DataSource = dtConcesionaria;
            ddlConcesionaria.DataBind();
            ddlConcesionaria.Items.Insert(0, new ListItem("", ""));
        }

        protected void CargaPuesto(string clave_marca, DropDownList ddlPuesto)
        {
            csDataBase query = new csDataBase();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@clave", clave_marca));
            query.EsStoreProcedure = false;
            DataTable dtPuesto = query.dtConsulta("SELECT id, clave, descripcion_larga as descripcion FROM tipo_participante WHERE fecha_baja IS NULL AND programa_id IN(SELECT TOP 1 ID FROM programa WHERE clave = @clave) ORDER BY descripcion", param, false);
            ddlPuesto.Items.Clear();
            ddlPuesto.DataSource = dtPuesto;
            ddlPuesto.DataBind();
            ddlPuesto.Items.Insert(0, new ListItem("", ""));
        }

        protected void CargaStatus(string clave_marca, DropDownList ddlStatus)
        {
            csDataBase query = new csDataBase();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@clave", clave_marca));
            query.EsStoreProcedure = false;
            DataTable dtStatus = query.dtConsulta("SELECT id, clave, descripcion FROM status_participante WHERE fecha_baja IS NULL AND programa_id IN(SELECT TOP 1 ID FROM programa WHERE clave = @clave) ORDER BY descripcion", param, false);
            ddlStatus.Items.Clear();
            ddlStatus.DataSource = dtStatus;
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("", ""));
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            DataTable dtExportar = new DataTable();
            DataRow drExportar = null;
            dtExportar.Columns.Add(new DataColumn("N", typeof(string)));
            dtExportar.Columns.Add(new DataColumn("Marca", typeof(string)));
            dtExportar.Columns.Add(new DataColumn("Numero_concesionaria", typeof(string)));
            dtExportar.Columns.Add(new DataColumn("Nombre_concesionaria", typeof(string)));
            dtExportar.Columns.Add(new DataColumn("Participante_id", typeof(string)));
            dtExportar.Columns.Add(new DataColumn("Usuario", typeof(string)));
            dtExportar.Columns.Add(new DataColumn("Puesto", typeof(string)));
            //dtExportar.Columns.Add(new DataColumn("Password", typeof(string)));
            dtExportar.Columns.Add(new DataColumn("Correo_electronico", typeof(string)));
            int i = 0; int Total = 0; int Correctos = 0; int Incorrectos = 0; int Duplicados = 0;
            foreach (GridDataItem di in rgCargaParticipantes.Items)
            {
                string marca = "", conc = "", nombre_conc = "", usuario = "", puesto = "", participante_id = "", password = "";
                TextBox txtCorreo_electronico = (TextBox)(di.FindControl("txtCorreo_electronico"));
                MembershipUserCollection busca_usuario = Membership.FindUsersByEmail(txtCorreo_electronico.Text);
                if (busca_usuario.Count == 0)
                {
                    try
                    {
                        DropDownList ddlMarca = (DropDownList)(di.FindControl("ddlMarca"));
                        DropDownList ddlConcesionaria = (DropDownList)(di.FindControl("ddlConcesionaria"));
                        Label txtNom_Conc = (Label)(di.FindControl("txtNom_Conc"));
                        //TextBox txtClave_Usuario = (TextBox)(di.FindControl("txtClave_Usuario"));
                        TextBox txtNombre = (TextBox)(di.FindControl("txtNombre"));
                        TextBox txtApellidoPaterno = (TextBox)(di.FindControl("txtApellidoPaterno"));
                        TextBox txtApellidoMaterno = (TextBox)(di.FindControl("txtApellidoMaterno"));
                        DropDownList ddlPuesto = (DropDownList)(di.FindControl("ddlPuesto"));
                        RadDatePicker rdpFecha_nac = (RadDatePicker)(di.FindControl("rdpFecha_nac"));
                        RadDatePicker rdpFecha_alta = (RadDatePicker)(di.FindControl("rdpFecha_alta"));
                        TextBox txtCelular = (TextBox)(di.FindControl("txtCelular"));
                        DropDownList ddlStatus = (DropDownList)(di.FindControl("ddlStatus"));
                        marca = ddlMarca.SelectedItem.Value;
                        string descripcion_programa = ddlMarca.SelectedItem.Text;
                        conc = ddlConcesionaria.SelectedItem.Text;
                        nombre_conc = txtNom_Conc.Text;
                        puesto = ddlPuesto.SelectedItem.Text;
                        //string clave = txtClave_Usuario.Text;
                        string nombre = txtNombre.Text;
                        string apellido_paterno = txtApellidoPaterno.Text;
                        string apellido_materno = txtApellidoMaterno.Text;
                        string correo_electronico = txtCorreo_electronico.Text;
                        string fecha_nacimiento = rdpFecha_nac.DbSelectedDate != null ? rdpFecha_nac.DbSelectedDate.ToString() : null;
                        string fecha_alta = rdpFecha_alta.DbSelectedDate != null ? rdpFecha_alta.DbSelectedDate.ToString() : null;
                        string celular = txtCelular.Text != "" ? txtCelular.Text : null;
                        string estatus = ddlStatus.SelectedItem.Text != "" ? ddlStatus.SelectedItem.Text : null;
                        string participante = "";
                        //try
                        //{
                        //    // Inserta en la tabla vw_tmp_carga_participante                          
                        //    List<SqlParameter> paramInsertTmp = new List<SqlParameter>();
                        //    paramInsertTmp.Add(new SqlParameter("@marca", marca));
                        //    paramInsertTmp.Add(new SqlParameter("@num_concesionaria", conc));
                        //    paramInsertTmp.Add(new SqlParameter("@nom_concesionaria", nombre_conc));
                        //    //paramInsertTmp.Add(new SqlParameter("@clave_usuario", clave));
                        //    paramInsertTmp.Add(new SqlParameter("@nombre", nombre));
                        //    paramInsertTmp.Add(new SqlParameter("@apellido_paterno", apellido_paterno));
                        //    paramInsertTmp.Add(new SqlParameter("@apellido_materno", apellido_materno));
                        //    paramInsertTmp.Add(new SqlParameter("@puesto", puesto));
                        //    paramInsertTmp.Add(new SqlParameter("@correo_electronico", correo_electronico));
                        //    paramInsertTmp.Add(new SqlParameter("@fecha_nacimiento", String.IsNullOrEmpty(fecha_nacimiento) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(fecha_nacimiento)));
                        //    paramInsertTmp.Add(new SqlParameter("@fecha_alta", String.IsNullOrEmpty(fecha_alta) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(fecha_alta)));
                        //    paramInsertTmp.Add(new SqlParameter("@celular", celular));
                        //    paramInsertTmp.Add(new SqlParameter("@status", estatus));
                        //    query.acutualizaDatos("VW_tmp_carga_participante_insert", paramInsertTmp, true);
                        //}
                        //catch (Exception ey)
                        //{
                        //    participante_id = "ERROR";
                        //    Incorrectos++;
                        //    usuario = ey.Message;
                        //    password = ey.InnerException != null ? ey.InnerException.Message : "";
                        //}
                        List<SqlParameter> param = new List<SqlParameter>();
                        param.Add(new SqlParameter("@programa", marca));
                        //param.Add(new SqlParameter("@conc", conc));
                        //param.Add(new SqlParameter("@nombre_conc", nombre_conc));
                        //param.Add(new SqlParameter("@clave", ""));
                        param.Add(new SqlParameter("@nombre", nombre));
                        param.Add(new SqlParameter("@apellido_paterno", apellido_paterno));
                        param.Add(new SqlParameter("@apellido_materno", apellido_materno));
                        param.Add(new SqlParameter("@puesto", puesto));
                        param.Add(new SqlParameter("@correo_electronico", correo_electronico));
                        param.Add(new SqlParameter("@fecha_nacimiento", String.IsNullOrEmpty(fecha_nacimiento) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(fecha_nacimiento)));
                        param.Add(new SqlParameter("@fecha_alta", String.IsNullOrEmpty(fecha_alta) ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(fecha_alta)));
                        param.Add(new SqlParameter("@celular", celular));
                        param.Add(new SqlParameter("@estatus", estatus));
                        DataTable dtUsuario = query.dtConsulta("sp_inserta_participante_general", param, true);
                        if (dtUsuario.Rows.Count > 0)
                        {
                            participante_id = dtUsuario.Rows[0]["participante_id"].ToString();
                            usuario = correo_electronico;
                            //usuario = dtUsuario.Rows[0]["usuario"].ToString();
                        }
                        else
                            Incorrectos++;
                        Funciones f = new Funciones();
                        password = f.generaPassword(6);
                        MembershipCreateStatus status;
                        MembershipUser user = Inserta_Usuario(usuario, correo_electronico, password, out status);
                        if (status.Equals(MembershipCreateStatus.Success))
                        {
                            actualiza_participante_con_membershipUser(participante_id, user.ProviderUserKey.ToString());
                            //// Actualiza el password en la tabla VW_tmp_carga_participante
                            //List<SqlParameter> paramActualizaTmp = new List<SqlParameter>();
                            //paramActualizaTmp.Add(new SqlParameter("@participante_id", participante_id));
                            //paramActualizaTmp.Add(new SqlParameter("@contrasena", password));
                            //query.acutualizaDatos("UPDATE working_tables..vw_tmp_carga_participante SET contrasena = @contrasena WHERE participante_id = @participante_id", paramActualizaTmp, false);

                            // Agrega Bono Bienvenida de 50 puntos en transacción
                            //csTransaccion transaccion = new csTransaccion();
                            //transaccion.ParticipanteID = participante_id;
                            //transaccion.UsuarioID = Membership.GetUser().ProviderUserKey.ToString();
                            //transaccion.TipoTransaccion = "BONOB";
                            //transaccion.Puntos = 50;
                            //transaccion.Fecha = DateTime.Now;
                            //transaccion.InsertaTransaccion();

                            // Envio de mail con sus datos de acceso
                            HiddenField hidCorreo_electronico = (HiddenField)(di.FindControl("hidCorreo_electronico"));
                            HiddenField hidServidor_pop = (HiddenField)(di.FindControl("hidServidor_pop"));
                            HiddenField hidServidor_smtp = (HiddenField)(di.FindControl("hidServidor_smtp"));
                            HiddenField hidUsuario_correo = (HiddenField)(di.FindControl("hidUsuario_correo"));
                            HiddenField hidPassword_correo = (HiddenField)(di.FindControl("hidPassword_correo"));
                            //mail anterior con datos de login
                            //envia_mail(descripcion_programa, hidCorreo_electronico.Value, hidServidor_pop.Value, hidServidor_smtp.Value, hidUsuario_correo.Value, hidPassword_correo.Value, marca, correo_electronico, usuario, password);
                            envia_mail_conoces(hidCorreo_electronico.Value, hidServidor_pop.Value, hidServidor_smtp.Value, hidUsuario_correo.Value, hidPassword_correo.Value, correo_electronico, usuario, password);
                        }
                        else
                        {
                            password = status.ToString();
                            Incorrectos++;
                        }
                    }
                    catch (Exception ex)
                    {
                        participante_id = "ERROR";
                        Incorrectos++;
                        usuario = ex.Message;
                        password = ex.InnerException != null ? ex.InnerException.Message : "";
                    }
                }
                else
                {
                    participante_id = "0";
                    usuario = "Email duplicado";
                    Duplicados++;
                }
                drExportar = dtExportar.NewRow();
                drExportar["N"] = i + 1;
                drExportar["Marca"] = marca;
                drExportar["Numero_concesionaria"] = conc;
                drExportar["Nombre_concesionaria"] = nombre_conc;
                drExportar["Participante_id"] = participante_id;
                drExportar["Usuario"] = usuario;
                drExportar["Puesto"] = puesto;
                //drExportar["Password"] = password;
                drExportar["Correo_electronico"] = txtCorreo_electronico.Text;
                dtExportar.Rows.Add(drExportar);
                i++;
                Total++;
            }
            // Guardar los datos y después exportarlos a Excel
            Correctos = Total - Duplicados - Incorrectos;
            lblMensaje.Text = "Correctos " + Correctos.ToString() + ", Incorrectos " + Incorrectos.ToString() + ", Duplicados " + Duplicados.ToString();
            gvExportar.DataSource = dtExportar;
            gvExportar.DataBind();
            gvExportar.Visible = false;
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            GridViewExportUtil.Export("cargaParticipantes.xls", gvExportar);
        }

        protected MembershipUser Inserta_Usuario(string clave_participante, string email, string password, out MembershipCreateStatus status)
        {
            MembershipUser objUser = null;
            MembershipUserCollection usuario = Membership.FindUsersByName(clave_participante);
            if (usuario.Count == 0)
                objUser = Membership.CreateUser(clave_participante, password, email, "pregunta", "respuesta", true, out status);
            else
                status = MembershipCreateStatus.DuplicateUserName;
            return objUser;
        }

        public void actualiza_participante_con_membershipUser(string participante_id, string MemberShip_userID)
        {
            try
            {
                csParticipante participante = new csParticipante();
                // inserta en la tabla participante_aspnet_users
                participante.participante_aspnet_User(participante_id, MemberShip_userID);
            }
            catch
            {

            }
        }

        protected void rgCargaParticipantes_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridCommandItem)
            {
                GridCommandItem item = (GridCommandItem)e.Item;
                //hide refresh linkbutton   
                ((LinkButton)item.FindControl("RebindGridButton")).Visible = false;
                //hide refresh icon   
                ((Button)item.FindControl("RefreshButton")).Visible = false;
            }

            if (e.Item is GridDataItem)
            {
                // Carga la marca en DropDownList
                CargaMarca(sender, e);
                DataRowView rowView = (DataRowView)e.Item.DataItem;
                // Retrieve the state value for the current row. 
                String marca = rowView["Marca"].ToString();
                String num_concesionaria = rowView["Numero_Concesionaria"].ToString();
                String nom_concesionaria = rowView["Nombre_Concesionaria"].ToString();
                String puesto = rowView["Puesto"].ToString();
                String status = rowView["estatus"].ToString();
                String fec_nac = rowView["Fecha_Nacimiento"].ToString();
                String fec_alta = rowView["Fecha_alta"].ToString();
                // Retrieve the DropDownList control from the current row. 
                DropDownList ddlMarca = (DropDownList)e.Item.FindControl("ddlMarca");
                DropDownList ddlConcesionaria = (DropDownList)e.Item.FindControl("ddlConcesionaria");
                DropDownList ddlPuesto = (DropDownList)e.Item.FindControl("ddlPuesto");
                DropDownList ddlStatus = (DropDownList)e.Item.FindControl("ddlStatus");
                CargaConcesionaria(marca, ddlConcesionaria);
                CargaPuesto(marca, ddlPuesto);
                CargaStatus(marca, ddlStatus);
                // Find the ListItem object in the DropDownList control with the 
                // state value and select the item.            
                ListItem itemMarca = ddlMarca.Items.FindByValue(marca);
                ddlMarca.SelectedIndex = ddlMarca.Items.IndexOf(itemMarca);
                ListItem itemConcesionaria = ddlConcesionaria.Items.FindByText(num_concesionaria);
                ddlConcesionaria.SelectedIndex = ddlConcesionaria.Items.IndexOf(itemConcesionaria);
                ListItem itemPuesto = ddlPuesto.Items.FindByValue(puesto);
                ddlPuesto.SelectedIndex = ddlPuesto.Items.IndexOf(itemPuesto);
                ListItem itemStatus = ddlStatus.Items.FindByText(status);
                ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(itemStatus);
                // Para el Label num_concesionaria
                Label txtNom_Conc = (Label)e.Item.FindControl("txtNom_Conc");
                txtNom_Conc.Text = ddlConcesionaria.SelectedItem.Value;
            }
        }

        protected void rgCargaParticipantes_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                FilaVacia("A");
                rgCargaParticipantes.MasterTableView.IsItemInserted = false;
                e.Canceled = true;
            }
            else if (e.CommandName.Equals("Delete"))
            {
                if (ViewState["DataTemp"] != null)
                {
                    //// antes de eliminar guardar el ViewState en un DataTable
                    GridDataItem item = (GridDataItem)e.Item;
                    int intSecuencial = Convert.ToInt32(item["N"].Text);
                    dt = EstructuraMedidas();
                    DataRow dr;
                    foreach (GridDataItem row in this.rgCargaParticipantes.Items)
                    {
                        DropDownList ddlMarca = (DropDownList)row.FindControl("ddlMarca");
                        DropDownList ddlConcesionaria = (DropDownList)row.FindControl("ddlConcesionaria");
                        Label txtNom_Conc = (Label)row.FindControl("txtNom_Conc");
                        //TextBox txtClave_Usuario = (TextBox)row.FindControl("txtClave_Usuario");
                        TextBox txtNombre = (TextBox)row.FindControl("txtNombre");
                        TextBox txtApellidoPaterno = (TextBox)row.FindControl("txtApellidoPaterno");
                        TextBox txtApellidoMaterno = (TextBox)row.FindControl("txtApellidoMaterno");
                        DropDownList ddlPuesto = (DropDownList)row.FindControl("ddlPuesto");
                        TextBox txtCorreo_electronico = (TextBox)row.FindControl("txtCorreo_electronico");
                        RadDatePicker rdpFecha_nac = (RadDatePicker)row.FindControl("rdpFecha_nac");
                        RadDatePicker rdpFecha_alta = (RadDatePicker)row.FindControl("rdpFecha_alta");
                        TextBox txtCelular = (TextBox)row.FindControl("txtCelular");
                        DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
                        dr = dt.NewRow();
                        dr[0] = row["N"].Text;
                        dr[1] = ddlMarca.SelectedItem.Value.ToString();
                        dr[2] = ddlConcesionaria.SelectedItem.Text.ToString();
                        dr[3] = txtNom_Conc.Text.ToString();
                        //dr[4] = txtClave_Usuario.Text.ToString();
                        dr[4] = txtNombre.Text.ToString();
                        dr[5] = txtApellidoPaterno.Text.ToString();
                        dr[6] = txtApellidoMaterno.Text.ToString();
                        dr[7] = ddlPuesto.SelectedItem.Value.ToString();
                        dr[8] = txtCorreo_electronico.Text.ToString();
                        dr[9] = rdpFecha_nac.DbSelectedDate != null ? rdpFecha_nac.DbSelectedDate.ToString() : null;
                        dr[10] = rdpFecha_alta.DbSelectedDate != null ? rdpFecha_alta.DbSelectedDate.ToString() : null;
                        dr[11] = txtCelular.Text.ToString();
                        dr[12] = ddlStatus.SelectedItem != null ? ddlStatus.SelectedItem.Text.ToString() : null;
                        dt.Rows.Add(dr);
                    }
                    ViewState["DataTemp"] = dt;
                    ////                    
                    DataTable dtTemp = new DataTable();
                    dtTemp = (DataTable)ViewState["DataTemp"];
                    int intPosicion = -1;
                    bool booExiste = false;
                    foreach (DataRow row in dtTemp.Rows)
                    {
                        intPosicion += 1;
                        if (Convert.ToInt32(row["N"].ToString()) == intSecuencial)
                        {
                            booExiste = true;
                            break;
                        }
                    }
                    if (booExiste)
                        dtTemp.Rows.RemoveAt(intPosicion);
                    ////
                    this.rgCargaParticipantes.DataSource = ViewState["DataTemp"];
                    this.rgCargaParticipantes.DataBind();
                }
            }
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlMarca = (DropDownList)sender;
            GridDataItem row = (GridDataItem)ddlMarca.NamingContainer;
            if (row != null)
            {
                string clave_marca = ((DropDownList)(row.FindControl("ddlMarca"))).SelectedItem.Value;
                DropDownList ddlConcesionaria = ((DropDownList)(row.FindControl("ddlConcesionaria")));
                CargaConcesionaria(clave_marca, ddlConcesionaria);
                DropDownList ddlPuesto = ((DropDownList)(row.FindControl("ddlPuesto")));
                CargaPuesto(clave_marca, ddlPuesto);
                DropDownList ddlStatus = ((DropDownList)(row.FindControl("ddlStatus")));
                CargaStatus(clave_marca, ddlStatus);
                // Obtiene los parametros para el envio de mail, dependiendo del programa
                csDataBase query = new csDataBase();
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@clave", clave_marca));
                query.EsStoreProcedure = false;
                DataTable dtEmail = query.dtConsulta("SELECT correo_electronico, servidor_pop, servidor_smtp, usuario_correo, password_correo FROM programa WHERE clave=@clave AND fecha_baja IS NULL", param, false);
                foreach (DataRow drEmail in dtEmail.Rows)
                {
                    HiddenField hidCorreo_electronico = ((HiddenField)(row.FindControl("hidCorreo_electronico")));
                    hidCorreo_electronico.Value = drEmail["correo_electronico"].ToString().Trim();
                    HiddenField hidServidor_pop = ((HiddenField)(row.FindControl("hidServidor_pop")));
                    hidServidor_pop.Value = drEmail["servidor_pop"].ToString().Trim();
                    HiddenField hidServidor_smtp = ((HiddenField)(row.FindControl("hidServidor_smtp")));
                    hidServidor_smtp.Value = drEmail["servidor_smtp"].ToString().Trim();
                    HiddenField hidUsuario_correo = ((HiddenField)(row.FindControl("hidUsuario_correo")));
                    hidUsuario_correo.Value = drEmail["usuario_correo"].ToString().Trim();
                    HiddenField hidPassword_correo = ((HiddenField)(row.FindControl("hidPassword_correo")));
                    hidPassword_correo.Value = drEmail["password_correo"].ToString().Trim();
                }
            }
        }

        protected void ddlConcesionaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlConcesionaria = (DropDownList)sender;
            GridDataItem row = (GridDataItem)ddlConcesionaria.NamingContainer;
            if (row != null)
            {
                Label txtNom_Conc = ((Label)(row.FindControl("txtNom_Conc")));
                txtNom_Conc.Text = ddlConcesionaria.SelectedItem.Value;
            }
        }

        private DataTable EstructuraMedidas()
        {
            DataTable medidaTabla = new DataTable();
            medidaTabla.Columns.Add("N", typeof(Int32));
            medidaTabla.Columns.Add("Marca", typeof(string));
            medidaTabla.Columns.Add("Numero_Concesionaria", typeof(string));
            medidaTabla.Columns.Add("Nombre_Concesionaria", typeof(string));
            //medidaTabla.Columns.Add("Clave_Usuario", typeof(string));
            medidaTabla.Columns.Add("Nombre", typeof(string));
            medidaTabla.Columns.Add("ApellidoPaterno", typeof(string));
            medidaTabla.Columns.Add("ApellidoMaterno", typeof(string));
            medidaTabla.Columns.Add("Puesto", typeof(string));
            medidaTabla.Columns.Add("Correo_Electronico", typeof(string));
            medidaTabla.Columns.Add("Fecha_Nacimiento", typeof(string));
            medidaTabla.Columns.Add("Fecha_alta", typeof(string));
            medidaTabla.Columns.Add("Celular", typeof(string));
            medidaTabla.Columns.Add("estatus", typeof(string));
            return medidaTabla;
        }

        void FilaVacia(string tipo)
        {
            DataTable dt = null;
            dt = EstructuraMedidas();
            DataRow dr;
            if (ViewState["DataTemp"] == null)
            {
                dr = dt.NewRow();
                dr[0] = 1;
                dr[1] = "";
                dr[2] = "";
                dr[3] = "";
                dr[4] = "";
                dr[5] = "";
                dr[6] = "";
                dr[7] = "";
                dr[8] = "";
                dr[9] = "";
                dr[10] = "";
                dr[11] = "";
                dr[12] = "";
                dt.Rows.Add(dr);
                ViewState["DataTemp"] = dt;
            }
            else
            {
                int n = 1;
                foreach (GridDataItem row in this.rgCargaParticipantes.Items)
                {
                    DropDownList ddlMarca = (DropDownList)row.FindControl("ddlMarca");
                    DropDownList ddlConcesionaria = (DropDownList)row.FindControl("ddlConcesionaria");
                    Label txtNom_Conc = (Label)row.FindControl("txtNom_Conc");
                    //TextBox txtClave_Usuario = (TextBox)row.FindControl("txtClave_Usuario");
                    TextBox txtNombre = (TextBox)row.FindControl("txtNombre");
                    TextBox txtApellidoPaterno = (TextBox)row.FindControl("txtApellidoPaterno");
                    TextBox txtApellidoMaterno = (TextBox)row.FindControl("txtApellidoMaterno");
                    DropDownList ddlPuesto = (DropDownList)row.FindControl("ddlPuesto");
                    TextBox txtCorreo_electronico = (TextBox)row.FindControl("txtCorreo_electronico");
                    RadDatePicker rdpFecha_nac = (RadDatePicker)row.FindControl("rdpFecha_nac");
                    RadDatePicker rdpFecha_alta = (RadDatePicker)row.FindControl("rdpFecha_alta");
                    TextBox txtCelular = (TextBox)row.FindControl("txtCelular");
                    DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
                    dr = dt.NewRow();
                    dr[0] = n;
                    dr[1] = ddlMarca.SelectedItem.Value.ToString();
                    dr[2] = ddlConcesionaria.SelectedItem.Text.ToString();
                    dr[3] = txtNom_Conc.Text.ToString();
                    //dr[4] = txtClave_Usuario.Text.ToString();
                    dr[4] = txtNombre.Text.ToString();
                    dr[5] = txtApellidoPaterno.Text.ToString();
                    dr[6] = txtApellidoMaterno.Text.ToString();
                    dr[7] = ddlPuesto.SelectedItem.Value.ToString();
                    dr[8] = txtCorreo_electronico.Text.ToString();
                    dr[9] = rdpFecha_nac.DbSelectedDate != null ? rdpFecha_nac.DbSelectedDate.ToString() : null;
                    dr[10] = rdpFecha_alta.DbSelectedDate != null ? rdpFecha_alta.DbSelectedDate.ToString() : null;
                    dr[11] = txtCelular.Text.ToString();
                    dr[12] = ddlStatus.SelectedItem != null ? ddlStatus.SelectedItem.Text.ToString() : null;
                    dt.Rows.Add(dr);
                    n += 1;
                }
                if (tipo == "A")
                {
                    ViewState["DataTemp"] = dt;
                    dr = dt.NewRow();
                    dr[0] = n;
                    dr[1] = "";
                    dr[2] = "";
                    dr[3] = "";
                    dr[4] = "";
                    dr[5] = "";
                    dr[6] = "";
                    dr[7] = "";
                    dr[8] = "";
                    dr[9] = "";
                    dr[10] = "";
                    dr[11] = "";
                    dr[12] = "";
                    dt.Rows.Add(dr);
                }
                ViewState["DataTemp"] = dt;
            }
            this.rgCargaParticipantes.DataSource = ViewState["DataTemp"];
            this.rgCargaParticipantes.DataBind();
        }

        protected void envia_mail(string descripcion_programa, string correo_electronico, string servidor_pop, string servidor_smtp, string usuario_correo, string password_correo, string marca, string correo, string usuario, string contrasena)
        {
            try
            {
                string correoFijo = correo_electronico;
                SmtpClient smtp = new SmtpClient(servidor_smtp);
                System.Net.NetworkCredential credencial = new System.Net.NetworkCredential(usuario_correo, password_correo);
                smtp.Credentials = credencial;
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress(correoFijo);
                mensaje.Subject = "Datos de Acceso al Programa " + GetNameCasing(descripcion_programa.ToLower());
                mensaje.To.Add(new MailAddress(correo));
                mensaje.Bcc.Add("gustavo.sanchez@lms.com.mx");
                string body = ""; string plantilla = "";
                switch (marca)
                {
                    case "GLP":
                        plantilla = "../plantillas/teaser_3_vw.html";
                        break;
                    case "SEAT":
                        plantilla = "../plantillas/teaser_3_seat.html";
                        break;
                    case "PORSCHE":
                        plantilla = "../plantillas/teaser_3_porsche.html";
                        break;
                    case "AUDI":
                        plantilla = "../plantillas/teaser_3_audi.html";
                        break;
                    case "TB":
                        plantilla = "../plantillas/teaser_3_tb.html";
                        break;
                }
                using (StreamReader sr = new StreamReader(Server.MapPath(plantilla)))
                {
                    body = sr.ReadToEnd();
                }
                body = body.Replace("[usuario]", usuario.ToString());
                body = body.Replace("[contrasena]", contrasena.ToString());
                mensaje.Body = body;
                mensaje.IsBodyHtml = true;
                mensaje.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                try
                {
                    smtp.Send(mensaje);
                }
                catch (Exception ez)
                {
                    lblMensaje.Text = "ocurrio un error en mail: " + ez.Message;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "ocurrio un error: " + ex.Message;
            }
        }

        protected void envia_mail_conoces(string correo_electronico, string servidor_pop, string servidor_smtp, string usuario_correo, string password_correo, string correo, string usuario, string contrasena)
        {
            try
            {
                string correoFijo = correo_electronico;
                SmtpClient smtp = new SmtpClient(servidor_smtp);
                System.Net.NetworkCredential credencial = new System.Net.NetworkCredential(usuario_correo, password_correo);
                smtp.Credentials = credencial;
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress(correoFijo);
                mensaje.Subject = "Conoces Galenia Loyalty Program";
                mensaje.To.Add(new MailAddress(correo));
                mensaje.Bcc.Add("gcorgan360@hotmail.com");
                mensaje.Bcc.Add("gustavo.sanchez@lms.com.mx");
                string body = "";
                string plantilla = "";

                plantilla = "/mailing/tables/conoces_galenia.html";

                using (StreamReader sr = new StreamReader(Server.MapPath(plantilla)))
                {
                    body = sr.ReadToEnd();
                }
                body = body.Replace("@usuario", usuario.ToString());
                body = body.Replace("@contrasena", contrasena.ToString());
                mensaje.Body = body;
                mensaje.IsBodyHtml = true;
                mensaje.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                try
                {
                    smtp.Send(mensaje);
                }
                catch (Exception ez)
                {
                    lblMensaje.Text = "ocurrio un error en mail: " + ez.Message;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "ocurrio un error: " + ex.Message;
            }
        }


        public static string GetNameCasing(string input)
        {
            string[] words = input.Split(new char[] { ' ' });

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > 0)
                {
                    words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);
                    if (words[i].StartsWith("Mc") && words[i].Length > 2)
                        words[i] = words[i].Substring(0, 2) + words[i].Substring(2, 1).ToUpper() + words[i].Substring(3);
                    else if (words[i].StartsWith("Mac") && words[i].Length > 3)
                        words[i] = words[i].Substring(0, 3) + words[i].Substring(3, 1).ToUpper() + words[i].Substring(4);
                    else if (words[i].StartsWith("Vw") && words[i].Length > 1)
                        words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1, 1).ToUpper();
                }
            }
            return string.Join(" ", words);
        }
    }
}