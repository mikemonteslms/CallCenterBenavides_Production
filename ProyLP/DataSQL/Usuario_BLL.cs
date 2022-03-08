using System;
using System.Data;
using System.Web.UI.WebControls;
//using System.Windows.Forms;


public class Usuario_BLL
{
    public Usuario_BLL() { }


    /// <cargarOpcionesUsuario>
    /// Se encarga de hacer el llenado del Arbol con los elementos disponibles
    /// </summary>
    /// <param name="idUsuario"></param>
    /// <param name="tvw"></param>
    public void cargarOpcionesUsuario(int idUsuario, TreeView tvw)
    {
        string Distribuidor = "", Gerente = "", Supervisor = "", Vendedor = "";
        //tvw.DataBind();
        TreeNode nodoD = new TreeNode();
        TreeNode nodoG = new TreeNode();
        TreeNode nodoS = new TreeNode();
        TreeNode nodoV = new TreeNode();
        Usuario_DAL user = new Usuario_DAL();
        DataSet ds = user.leerOpciones(idUsuario);

        if (ds != null)
        {

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow fila in ds.Tables[0].Rows)
                    {
                        Distribuidor = fila["descripcion"].ToString();
                        nodoD = new TreeNode(Distribuidor, fila["id"].ToString());
                        nodoD.ImageUrl = "img/home.png";
                        //nodoD.ShowCheckBox = true;

                        tvw.Nodes.Add(nodoD);



                        //GERENTE
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow fila2 in ds.Tables[1].Rows)
                            {
                                //VERIFICA SI EL NODO PADRE  NO ES INACTIVO
                                //if (fila["estatus"].ToString() != "0")
                                //{

                                if ((fila2["distributor_id"].ToString() == fila["id"].ToString()))
                                {
                                    Gerente = fila2["nombre"].ToString() + " (" + fila2["estatus_descripcion"].ToString() + ")";
                                    nodoG = new TreeNode(Gerente, fila2["id"].ToString());
                                    nodoG.ShowCheckBox = true;
                                    if (Gerente.Contains("NENHUM") == true)
                                    {
                                        nodoG.ShowCheckBox = false;
                                        nodoG.NavigateUrl = null;
                                    }
                                    nodoG.ImageUrl = "img/GERENTE.png";
                                    nodoD.ChildNodes.Add(nodoG);
                                    string ImgSuper = string.Empty;
                                    
                                    //Supervisor

                                    if (ds.Tables[2].Rows.Count > 0)
                                    {
                                        foreach (DataRow fila3 in ds.Tables[2].Rows)
                                        {
                                            //Valida nodo Padre Gerente no sea inactivo
                                            //if (fila2["estatus"].ToString() != "0")
                                            //{
                                            //Valida si tiene nodos hijos
                                            if ((fila3["gerente_id"].ToString() == fila2["id"].ToString()) )
                                            {
                                                Supervisor = fila3["nombre"].ToString() + " (" + fila3["estatus_descripcion"].ToString() + ")";
                                                //Supervisor = fila3["Supervisor"].ToString();
                                                nodoS = new TreeNode(Supervisor, fila3["id"].ToString());
                                                nodoS.ShowCheckBox = true;
                                                if (Supervisor.Contains("NENHUM") == true)
                                                {
                                                    nodoS.ShowCheckBox = false;
                                                    nodoS.NavigateUrl = null;
                                                }
                                                nodoS.ImageUrl = "img/SUPERVISOR.png";
                                                nodoG.ChildNodes.Add(nodoS);

                                                //Vendedor
                                                if (ds.Tables[3].Rows.Count > 0)
                                                {
                                                    foreach (DataRow fila4 in ds.Tables[3].Rows)
                                                    {
                                                        //Valida que el nodo padre Supervisor no sea inactivo
                                                        //if (fila3["estatus"].ToString() != "0")
                                                        //{
                                                        //Verifica si tienes nodos hijos
                                                        if ((fila4["supervisor_id"].ToString() == fila3["id"].ToString()) && (fila4["gerente_id"].ToString() == fila2["id"].ToString()))
                                                        {
                                                            if (fila4["nombre"].ToString().Trim() == "NENHUM")
                                                            {

                                                                ImgSuper = "img/sin_superior.png";
                                                            }
                                                            else
                                                            {
                                                                ImgSuper = "img/VENDEDOR.png";
                                                            }
                                                            Vendedor = fila4["nombre"].ToString() + " (" + fila4["estatus_descripcion"].ToString() + ")";
                                                            nodoV = new TreeNode(Vendedor, fila4["id"].ToString());
                                                            nodoV.ShowCheckBox = true;
                                                            if (Vendedor.Contains("NENHUM") == true)
                                                            {
                                                                nodoV.ShowCheckBox = false;
                                                                nodoV.NavigateUrl = null;
                                                            }
                                                            nodoV.ImageUrl = ImgSuper;
                                                            nodoS.ChildNodes.Add(nodoV);

                                                        }
                                                        else if (String.IsNullOrEmpty(fila4["supervisor_id"].ToString()) && (fila4["tipo_participante_id"].ToString() == "2"))
                                                        {
                                                            Vendedor = fila4["nombre"].ToString() + " (" + fila4["estatus_descripcion"].ToString() + ")";
                                                            nodoV = new TreeNode(Vendedor, fila4["id"].ToString());
                                                            nodoV.ShowCheckBox = true;
                                                            if (Vendedor.Contains("NENHUM") == true)
                                                            {
                                                                nodoV.ShowCheckBox = false;
                                                                nodoV.NavigateUrl = null;
                                                            }
                                                            nodoV.ImageUrl = "img/sin_superior.png";

                                                            bool existe_nodo = false;
                                                            foreach (TreeNode t in nodoD.ChildNodes)
                                                            {
                                                                if (t.Value == nodoV.Value)
                                                                {
                                                                    existe_nodo = true;
                                                                    break;
                                                                }
                                                            }
                                                            if (!existe_nodo)
                                                            {
                                                                nodoD.ChildNodes.AddAt(0, nodoV);
                                                            }
                                                        }
                                                        //else if (fila4["supervisor_id"].ToString() == "2847")
                                                        //{
                                                        //    Vendedor = fila4["nombre"].ToString() + " (" + fila4["estatus_descripcion"].ToString() + ")";
                                                        //    nodoV = new TreeNode(Vendedor, fila4["id"].ToString());
                                                        //    nodoV.ShowCheckBox = true;
                                                        //    nodoV.ImageUrl = "img/sin_superior.png";

                                                        //    bool existe_nodo = false;
                                                        //    foreach (TreeNode t in nodoD.ChildNodes)
                                                        //    {
                                                        //        if (t.Value == nodoV.Value)
                                                        //        {
                                                        //            existe_nodo = true;
                                                        //            break;
                                                        //        }
                                                        //    }
                                                        //    if (!existe_nodo)
                                                        //    {
                                                        //        nodoD.ChildNodes.AddAt(0, nodoV);
                                                        //    }
                                                        //}
                                                        // }//FIN IF NODO SUPERVISOR NO ES INACTIVO
                                                    }//FIN FOREACH VENDEDOR FILA4 TABLA3
                                                }


                                            }
                                            //  }//FIN IF VERIFICA QUE NODO GERENTE NO SEA INACTIVO
                                        }//Fin FOREACH SUPERVISOR FILA3 TABLA 2
                                    }

                                }
                                // }//FIN IF Verifica nodo DISTRIBUIDOR no sea inactivo
                            }//FIN FOREACH GERENTE FILA2 TABLA1
                        }

                    }
                }
            }
        }

    }


    public void cargarOpcionesParticipante(int participante_id, TreeView tvw)
    {
        string distribuidor_id = "", Distribuidor = "", Gerente = "", Supervisor = "", Vendedor = "";

        TreeNode nodoD = new TreeNode();
        TreeNode nodoG = new TreeNode();
        TreeNode nodoS = new TreeNode();
        TreeNode nodoV = new TreeNode();
        Usuario_DAL user = new Usuario_DAL();
        DataSet ds = user.leerOpcionesParticipante(participante_id);

        if (ds != null)
        {

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow fila in ds.Tables[0].Rows)
                    {
                        Distribuidor = fila["descripcion"].ToString();
                        distribuidor_id = fila["id"].ToString();
                        nodoD = new TreeNode(Distribuidor, fila["id"].ToString());
                        nodoD.ImageUrl = "img/home.png";
                        //nodoD.ShowCheckBox = true;

                        tvw.Nodes.Add(nodoD);



                        //GERENTE
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow fila2 in ds.Tables[1].Rows)
                            {
                                //VERIFICA SI EL NODO PADRE  NO ES INACTIVO
                                //if (fila["estatus"].ToString() != "0")
                                //{
                                if (distribuidor_id == fila["id"].ToString())
                                {
                                    try
                                    {
                                        Gerente = fila2["nombre"].ToString() + " (" + fila2["estatus_descripcion"].ToString() + ")";
                                        nodoG = new TreeNode(Gerente, fila2["id"].ToString());
                                        nodoG.ShowCheckBox = false;
                                        nodoG.ImageUrl = "img/GERENTE.png";
                                        nodoD.ChildNodes.Add(nodoG);

                                        //Supervisor

                                        if (ds.Tables[2].Rows.Count > 0)
                                        {
                                            foreach (DataRow fila3 in ds.Tables[2].Rows)
                                            {
                                                //Valida nodo Padre Gerente no sea inactivo
                                                //if (fila2["estatus"].ToString() != "0")
                                                //{
                                                //Valida si tiene nodos hijos
                                                if (fila3["gerente_id"].ToString() == fila2["id"].ToString())
                                                {
                                                    Supervisor = fila3["nombre"].ToString() + " (" + fila3["estatus_descripcion"].ToString() + ")";
                                                    //Supervisor = fila3["Supervisor"].ToString();
                                                    nodoS = new TreeNode(Supervisor, fila3["id"].ToString());
                                                    nodoS.ShowCheckBox = false;
                                                    nodoS.ImageUrl = "img/SUPERVISOR.png";
                                                    nodoG.ChildNodes.Add(nodoS);

                                                    //Vendedor
                                                    if (ds.Tables[3].Rows.Count > 0)
                                                    {
                                                        foreach (DataRow fila4 in ds.Tables[3].Rows)
                                                        {
                                                            //Valida que el nodo padre Supervisor no sea inactivo
                                                            //if (fila3["estatus"].ToString() != "0")
                                                            //{
                                                            //Verifica si tienes nodos hijos
                                                            if (fila4["supervisor_id"].ToString() == fila3["id"].ToString())
                                                            {
                                                                Vendedor = fila4["nombre"].ToString() + " (" + fila4["estatus_descripcion"].ToString() + ")";
                                                                nodoV = new TreeNode(Vendedor, fila4["id"].ToString());
                                                                nodoV.ShowCheckBox = false;
                                                                nodoV.ImageUrl = "img/VENDEDOR.png";
                                                                nodoS.ChildNodes.Add(nodoV);

                                                            }
                                                            // }//FIN IF NODO SUPERVISOR NO ES INACTIVO
                                                        }//FIN FOREACH VENDEDOR FILA4 TABLA3
                                                    }
                                                }
                                                //  }//FIN IF VERIFICA QUE NODO GERENTE NO SEA INACTIVO
                                            }//Fin FOREACH SUPERVISOR FILA3 TABLA 2
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                // }//FIN IF Verifica nodo DISTRIBUIDOR no sea inactivo
                            }//FIN FOREACH GERENTE FILA2 TABLA1
                        }
                    }
                }
            }
        }
    }
}