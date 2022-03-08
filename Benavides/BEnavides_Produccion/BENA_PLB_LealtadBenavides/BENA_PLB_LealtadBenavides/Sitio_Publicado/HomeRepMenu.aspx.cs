using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;

namespace WebPfizer.LMS.eCard
{
    public partial class HomeRepMenu : System.Web.UI.Page
    {
        DataSet objDataset = new DataSet();
        Catalogos ConsultaDatos = new Catalogos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioCC"].ToString() == null)
            {
                Menu1.Visible = false;
                Response.Redirect("AccesoRep.aspx");
            }
            else
            {

                Menu1.Visible = true;
                CargarMenu(Session["UsuarioCC"].ToString());
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void btnCerrarSesion_Click(object sender, ImageClickEventArgs e)
        {
            Session["UsuarioCC"] = null;
            Response.Redirect("AccesoRep.aspx");
        }

        public void CargarMenu(string Usuario)
        {
            int cntRecord = 0;
            int iMenu = -1;
            int intPadreActual = -1;
            string strImagen = "menu_Inicio.jpg";
            try
            {
                objDataset = ConsultaDatos.RegresaMenu(Usuario);

                if (objDataset.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= objDataset.Tables[0].Rows.Count - 1; i++)
                    {
                        strImagen = "~/Imagenes/MasterPage/" + objDataset.Tables[0].Rows[i]["Pagina_strImagen"].ToString();
                        if (objDataset.Tables[0].Rows[i]["Pagina_intPadre"].ToString() == "0")
                        {
                            intPadreActual = int.Parse(objDataset.Tables[0].Rows[i]["Pagina_intClave"].ToString());
                            iMenu++;
                            Menu1.Items.Add(new MenuItem(objDataset.Tables[0].Rows[i]["Pagina_strNombre"].ToString(), cntRecord.ToString(), strImagen, objDataset.Tables[0].Rows[i]["Pagina_strPagina"].ToString()));
                        }
                        else
                        {
                            if (intPadreActual == int.Parse(objDataset.Tables[0].Rows[i]["Pagina_intPadre"].ToString()))  //si el padre no esta activo, no mostrar los hijos
                                Menu1.Items[iMenu].ChildItems.Add(new MenuItem(objDataset.Tables[0].Rows[i]["Pagina_strNombre"].ToString(), cntRecord.ToString(), strImagen, objDataset.Tables[0].Rows[i]["Pagina_strPagina"].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes(ex.Message);
            }
        }


    }
}