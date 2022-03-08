using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace ORMOperacion
{
    public partial class aclaraciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.Menu = "Llamadas";
                Master.Submenu = "Aclaraciones";
            }
        }

        protected void cargarCarpetaAclaraciones(string llamadaID)
        {
            //window1.ContentContainer.Controls.Clear();
            RadFileExplorer fileExplorer = new RadFileExplorer();
            fileExplorer.OnClientLoad = "OnClientFolderChange";
            fileExplorer.OnClientFileOpen = "OnClientFileOpen";

            //fileExplorer.Controls.Clear();
            string programa = WebConfigurationManager.AppSettings["programa"];
            string[] viewPaths = new string[] { @"C:\aclaraciones\" + programa + @"\" + llamadaID };

            fileExplorer.Configuration.ViewPaths = viewPaths;
            fileExplorer.Configuration.SearchPatterns = new[] { "*.*" };

            fileExplorer.Configuration.ContentProviderTypeName = typeof(CustomFileSystemProvider).AssemblyQualifiedName;
            //fileExplorer.DataBind();
            window1.ContentContainer.Controls.Add(fileExplorer);
        }

        protected void showFiles_Click(object sender, EventArgs e)
        {
            cargarCarpetaAclaraciones(((RadButton)sender).CommandArgument);
            string script = "function f(){$find(\"" + window1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
    }
}