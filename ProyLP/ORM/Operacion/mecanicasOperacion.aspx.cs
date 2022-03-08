using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.IO;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;

namespace ORMOperacion
{
    public partial class mecanicasOperacion : System.Web.UI.Page
    {
        csMecanicas objMecanicas = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.Name == "")
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
                return;
            }

            CargaMecanicas();

        }



        protected void CargaMecanicas()
        {
            objMecanicas = new csMecanicas();
            DataTable dtMecanicas = new DataTable();

            dtMecanicas = objMecanicas.ConsultaMecanicas();

            if (dtMecanicas != null)
            {
                if (dtMecanicas.Rows.Count > 0)
                {
                    rptPremios.DataSource = dtMecanicas;
                    rptPremios.DataBind();
                    //hidPremioID.Value = dtPremiosXCategoria.Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    rptPremios.DataSource = dtMecanicas;
                    rptPremios.DataBind();
                }
            }
            else
            {
                rptPremios.DataSource = dtMecanicas;
                rptPremios.DataBind();
            }
        }


        protected void rptPremios_DataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView row = e.Item.DataItem as DataRowView;
                if (row != null)
                {
                    //Cargamos imagen
                    ImageButton img = e.Item.FindControl("imgPremio") as ImageButton;
                    if (row.Row.ItemArray[3].ToString() != "")
                    {
                        if (img != null)
                        {
                            img.ImageUrl = "style" + row.Row.ItemArray[3].ToString();
                        }
                    }
                    else
                    {
                        if (img != null)
                        {
                            img.ImageUrl = "style/img/premios/imagen-no-disponible.PNG";
                        }
                    }
                }
                // Se agrega para hacer el salto de fila
                if ((e.Item.ItemIndex + 1) % 4 == 0)
                {
                    e.Item.Controls.Add(new LiteralControl("</tr><tr>"));
                }
            }
        }


        protected void imgPremios_Command(object sender, CommandEventArgs e)
        {

            if (e.CommandName == "detalle")
            {
                int mecanica_id = 0;

                mecanica_id = int.Parse(e.CommandArgument.ToString());
                objMecanicas = new csMecanicas();
                DataTable objMecanicaDetalle = new DataTable();
                objMecanicas.Mecanica_id = mecanica_id;

                objMecanicaDetalle = objMecanicas.ConsultaMecanicas_Detalle();

                if (objMecanicaDetalle != null)
                {
                    if (objMecanicaDetalle.Rows.Count > 0)
                    {
                        imgMecanica.ImageUrl = "style" + objMecanicaDetalle.Rows[0][4].ToString();
                        gvDetalleMecanica.DataSource = objMecanicaDetalle;
                        gvDetalleMecanica.DataBind();
                        lblLegales.Text = objMecanicaDetalle.Rows[0].ItemArray[6].ToString();
                    }
                    else
                    {
                        gvDetalleMecanica.DataSource = null;
                        gvDetalleMecanica.DataBind();
                    }
                }
                else
                {
                    gvDetalleMecanica.DataSource = null;
                    gvDetalleMecanica.DataBind();
                }

                popMecanicas.Show();
            }
        }


        protected void btnCerrar2_Click(object sender, EventArgs e)
        {
            popMecanicas.Hide();
        }

        protected void imgbtnMecanicas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/mecanicas.aspx");
        }

        protected void imgbtnPromociones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/promociones.aspx");
        }

        protected void imgbtnCatalogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/catalogo.aspx");
        }
    }
}