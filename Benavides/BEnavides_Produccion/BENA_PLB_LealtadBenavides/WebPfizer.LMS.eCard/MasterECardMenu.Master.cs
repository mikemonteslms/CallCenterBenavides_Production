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
using System.Data.SqlClient;
using Negocio;
using Entidades;
using Datos;

namespace WebPfizer.LMS.eCard
{
    public partial class MasterECardMenu : System.Web.UI.MasterPage
    {
        DataSet objDataset = new DataSet();
        Catalogos ConsultaDatos = new Catalogos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioRep"] == null)
            {
                Menu1.Visible = false;
                Response.Redirect("AccesoRep.aspx");
            }
            else
            {

                Menu1.Visible = true;
                //Session["nombreSP1"] = "sp_TOPtblRepBenFechaActivacion";
                CargarMenu(Session["UsuarioRep"].ToString());
            }
        }

        private void Mensajes(string valorMensaje)
        {
            string outputstring = valorMensaje;
            ScriptManager.RegisterStartupScript(this, GetType(), "redirectMe", "alert('" + outputstring + "');", true);
        }

        protected void btnCerrarSesion_Click1(object sender, ImageClickEventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();

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
                        strImagen = "~/Imagenes_Benavides/botones/" + objDataset.Tables[0].Rows[i]["Pagina_strImagen"].ToString();
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

        //public static string nombreSP(string Usuario)
        //{
        //    //try
        //    //{
        //    DataSet objDataset = new DataSet();
        //    Catalogos ConsultaDatos = new Catalogos();

        //    string nombreSP1 = "";

        //    objDataset = ConsultaDatos.RegresaMenu(Usuario);

        //    if (objDataset.Tables[0].Rows.Count > 0)
        //    {
        //        //nombreSP1 = Menu1.Items.Add(new MenuItem(objDataset.Tables[0].Rows[i]["Pagina_strNombre"].ToString(), cntRecord.ToString(), strImagen, objDataset.Tables[0].Rows[i]["Pagina_strStoreProcedure1"].ToString()));
        //        //nombreSP1 =
        //        nombreSP1 = objDataset.Tables[0].Rows[0]["Pagina_strStoreProcedure1"].ToString();
        //        //string nombreSP2 = objDataset.Tables[0].Rows[0]["Pagina_strStoreProcedure2"].ToString();
        //    }
        //    else
        //    {
        //        nombreSP1 = "Sin informacion";
        //        //string nombreSP2 = "Error";
        //    }
        //    return nombreSP1;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //Mensajes(ex.Message);
        //    //}
        //}



    }


}


