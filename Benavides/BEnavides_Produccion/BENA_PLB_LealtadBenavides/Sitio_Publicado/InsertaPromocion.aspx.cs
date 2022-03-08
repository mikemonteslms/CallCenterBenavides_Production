using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Negocio;
using System.IO;
using System.Data.OleDb;

namespace WebPfizer.LMS.eCard
{
    public partial class InsertaPromocion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioRep"] == null)
            {
                Response.Redirect("AccesoRep.aspx", true);
            }
            string usuario = Session["UsuarioRep"].ToString();
            txtUsuario.Text = usuario;           
        }

        protected void btnEnviar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (txtDescripcion.Text == string.Empty || txtFechaInicio.Text == string.Empty || txtFechaFin.Text == string.Empty || ddlEstatus.SelectedValue.ToString() == "-1" || txtUsuario.Text == string.Empty)
                {
                    Mensajes("Capture todos los valores para continuar");
                }

                else
                {
                    if (IsDate(txtFechaInicio.Text) && IsDate(txtFechaFin.Text))
                    {

                        DataSet ds = new DataSet();
                        Clientes cs = new Clientes();                        
                       
                        ds = cs.InsertaPromocion("1", "998877", txtDescripcion.Text, txtFechaInicio.Text, txtFechaFin.Text, txtUsuario.Text, ddlEstatus.SelectedValue.ToString());

                        if (ds != null)
                        {                            
                            string resultado = ds.Tables[0].Rows[0]["CodigoRespuesta_strDescripcion"].ToString();
                            string codigo = ds.Tables[0].Rows[0]["CodigoRespuesta_StrCodigo"].ToString();
                            if (codigo == "PR3003")
                            {
                                Mensajes("Se inserto correctamente la promoción. " + resultado);
                            }
                            else
                            {
                                Mensajes("No se inserto la Promoción, valide los datos. " + resultado);
                            }
                        }
                        else
                        {
                            Mensajes("Error al insertar la promoción");
                        }
                    }
                    else
                    {
                        Mensajes("El formato de fecha es incorrecto, favor de verificar.");
                    }
                }
            }

            catch
            { }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        public static bool IsDate(string inputDate)
        {
            bool isDate = true;
            try
            {
                DateTime dateValue;
                dateValue = DateTime.ParseExact(inputDate, "yyyyMMdd", null);
            }
            catch
            {
                isDate = false;
            }
            return isDate;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                    string FilePath = Server.MapPath(FolderPath + FileName);
                    FileUpload1.SaveAs(FilePath);
                    Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text);
                    btnInsertar.Visible = true;
                }
                else
                {
                    Mensajes("Seleccione un archivo para continuar");
                }
            }
            catch
            { }
        }

        private void Import_To_Grid(string FilePath, string Extension, string isHDR)
        {
            try
            {
                string conStr = "";
                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                                 .ConnectionString;
                        break;
                    case ".xlsx": //Excel 07
                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                                  .ConnectionString;
                        break;
                }
                conStr = String.Format(conStr, FilePath, isHDR);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();

                //Bind Data to GridView
                GridView1.Caption = Path.GetFileName(FilePath);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch
            { }
        }

        protected void PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                string FileName = GridView1.Caption;
                string Extension = Path.GetExtension(FileName);
                string FilePath = Server.MapPath(FolderPath + FileName);

                Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text);
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
            }
            catch
            { }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                ///validando archivo de excel///
                if (GridView1.HeaderRow.Cells.Count != 8)
                {
                    Mensajes("El formato del archivo es incorrecto, favor de validarlo");
                }
                else
                {
                    int validacion = 0;
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        string col1 = GridView1.Rows[i].Cells[0].Text;
                        string col2 = GridView1.Rows[i].Cells[1].Text;
                        string col3 = GridView1.Rows[i].Cells[2].Text;
                        string col4 = GridView1.Rows[i].Cells[3].Text;
                        string col5 = GridView1.Rows[i].Cells[4].Text;
                        string col6 = GridView1.Rows[i].Cells[5].Text;
                        string col7 = GridView1.Rows[i].Cells[6].Text;
                        string col8 = GridView1.Rows[i].Cells[7].Text;

                        if(validaGrid(col1, col2, col3, col4, col5, col6, col7, col8))
                        {
                            validacion=1;
                        }
                        else
                        {
                            validacion=0;
                        }
                    }
                    if(validacion==1)
                    {                        
                        DataSet ds = new DataSet();
                        Clientes cs = new Clientes();

                        if (GridView1.Rows.Count > 0)
                        {
                            for (int i = 0; i < GridView1.Rows.Count; i++)
                            {
                                ds = cs.LlenaTablaPromocion(GridView1.Rows[i].Cells[0].Text, GridView1.Rows[i].Cells[1].Text, Convert.ToInt32(GridView1.Rows[i].Cells[2].Text), Convert.ToInt32(GridView1.Rows[i].Cells[3].Text), Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text), Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text), Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text), Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));
                            }
                            Mensajes("Se han insertado los datos correctamente. Ahora puede continuar con el proceso");
                            divCarga.Visible = false;
                            divPromocion.Visible = true;
                        } 
                    }
                    else
                    {
                        Mensajes("El formato del archivo es incorrecto, favor de validarlo");
                    }
                }

                               
            }
            catch
            { }
        }

        public static bool validaGrid(string col1, string col2, string col3, string col4, string col5, string col6, string col7, string col8)
        {
            bool validacion = true;
            try
            {
                string columna1;
                string columna2;
                int columna3;
                int columna4;
                decimal columna5;
                decimal columna6;
                decimal columna7;
                decimal columna8;

                columna1 = Convert.ToString(col1);
                columna2 = Convert.ToString(col2);
                columna3 = Convert.ToInt32(col3);
                columna4 = Convert.ToInt32(col4);
                columna5 = Convert.ToDecimal(col5);
                columna6 = Convert.ToDecimal(col6);
                columna7 = Convert.ToDecimal(col7);
                columna8 = Convert.ToDecimal(col8);
                
            }
            catch
            {
                validacion = false;
            }
            return validacion;
        }

        protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AccesoRep.aspx");
        }
    }
}