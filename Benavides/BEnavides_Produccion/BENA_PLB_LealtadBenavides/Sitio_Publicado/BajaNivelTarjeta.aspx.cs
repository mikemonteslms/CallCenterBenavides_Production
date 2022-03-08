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
using System.Threading;


namespace WebPfizer.LMS.eCard
{
    public partial class BajaNivelTarjeta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioRep"] == null)
            {
                Response.Redirect("AccesoRep.aspx", true);
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    if (Extension != ".txt")
                    {
                        Mensajes("El archivo seleccionado no es archivo de texto. Seleccione un archivo de texto para continuar");
                    }
                    else
                    {
                        string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                        FileName = FileName.Replace(" ", "");

                        string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                        string FilePath = Server.MapPath(FolderPath + FileName);
                        FileUpload1.SaveAs(FilePath);
                        CargarTexto(FileName, Extension, FolderPath, FilePath);
                        btnInsertar.Visible = true;
                    }
                }
                else
                {
                    Mensajes("Seleccione un archivo para continuar");
                }
            }
            catch
            { }
        }

        public void CargarTexto(string FileName, string Extension, string FolderPath, string FilePath)
        {
            try
            {

                FileInfo archivo = new FileInfo(FilePath);

                string connectionString = string.Empty;

                string SelectSQL = string.Empty;

                string Error = string.Empty;

                //String de conexión al archivo que queremos cargar

                connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='text;HDR={1};FMT={2}'", archivo.DirectoryName, "YES", "Delimited");

                System.Text.StringBuilder Temporal = new System.Text.StringBuilder();

                //Seleccionamos todo el contenido del archivo

                Temporal.Append("SELECT * FROM ").Append(archivo.Name);

                SelectSQL = Temporal.ToString();

                //Instanciamos la conexión

                OleDbConnection conn = new OleDbConnection(connectionString);

                conn.Open(); // Abrimos la conexión al archivo

                OleDbCommand dbCommand = new OleDbCommand(SelectSQL.ToString(), conn);

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(dbCommand);

                //Crear una nueva Tabla

                DataTable dTable = new DataTable();

                //Recuperamos todos los registros en un objeto DataTable

                dataAdapter.Fill(dTable);

                //Asignar la tabla al GridView

                if (dTable.Rows.Count > 0)
                {
                    GVArchivo.Caption = Path.GetFileName(FilePath);

                    GVArchivo.DataSource = dTable;

                    GVArchivo.DataBind();

                    lblNumFilas.Text = dTable.Rows.Count.ToString();

                }

                else
                {

                    Error = "ERROR: El archivo no contiene ningún registros que mostrar.";

                }

                // Eliminar los objetos y cerrar las conexiones.

                dTable.Dispose();

                dataAdapter.Dispose();

                dbCommand.Dispose();

                conn.Close();

                conn.Dispose();
            }
            catch
            { }
        }

        protected void GVArchivo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                string FileName = GVArchivo.Caption;
                FileName = FileName.Replace(" ", "");
                string Extension = Path.GetExtension(FileName);
                string FilePath = Server.MapPath(FolderPath + FileName);

                CargarTexto(FileName, Extension, FolderPath, FilePath);
                GVArchivo.PageIndex = e.NewPageIndex;
                GVArchivo.DataBind();
            }
            catch
            {
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                ///validando archivo de excel///
                if (GVArchivo.HeaderRow.Cells.Count != 1)
                {
                    Mensajes("El formato del archivo es incorrecto, favor de validarlo");
                }
                else
                {
                    DataSet ds = new DataSet();
                    DataSet dsTrunca = new DataSet();
                    DataSet ejecuta = new DataSet();
                    Clientes cs = new Clientes();
                    GVArchivo.AllowPaging = false;

                    if (GVArchivo.Rows.Count > 0)
                    {
                        System.Threading.Thread.Sleep(3000);
                        lblText.Text = "Archivo Guardando Correctamente";
                        GVArchivo.Visible = false;

                        int filas = Convert.ToInt32(lblNumFilas.Text);
                        dsTrunca = cs.TruncaTablaTmpVencimiento();
                        for (int i = 0; i < filas; i++)
                        {
                            ds = cs.InsertaEnTablaVencimientoPlatino(GVArchivo.Rows[i].Cells[0].Text);
                        }
                        ejecuta = cs.EjecutaSPVencimientoPlatino();
                        string mensaje = ejecuta.Tables[0].Rows[0]["strTextoRespuesta"].ToString();

                        if (ejecuta.Tables[0].Rows[0]["strCodigoRespuesta"].ToString() == "VEN000")
                        {                            
                            string inserta = cs.EnviaCorreoVencimientoPuntos(mensaje);

                            ClientScript.RegisterStartupScript(GetType(), "mostrarmensaje", "diHola('" + mensaje + "', '" + "Index.aspx" + "');", true);
                            
                        }
                        else
                        {
                            Mensajes(ejecuta.Tables[0].Rows[0]["strTextoRespuesta"].ToString());
                            string inserta = cs.EnviaCorreoVencimientoPuntos(mensaje);
                        }




                    }
                }


            }
            catch
            { }
        }


    }
}