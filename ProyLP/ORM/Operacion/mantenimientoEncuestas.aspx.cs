using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Web;
using Telerik.Web.UI;
using EntitiesModel;

namespace ORMOperacion
{
    public partial class mantenimientoEncuestas : System.Web.UI.Page
    {
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
                Master.Menu = "Parametros";
                Master.Submenu = "Encuestas";
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            mvEncuestas.SetActiveView(vBusqueda);
        }

        protected void getEncuestaID(object sender, OpenAccessLinqDataSourceSelectEventArgs e)
        {
            e.SelectParameters.Add("encuesta_id", ViewState["encuestaIdView"].ToString());
        }

        protected void OAEncuestas_Inserting(object sender, OpenAccessLinqDataSourceInsertEventArgs e)
        {
            using (EntitiesModel.EntitiesModel context = new EntitiesModel.EntitiesModel())
            {
                MembershipUser u = Membership.GetUser();
                encuesta encuesta = e.NewObject as encuesta;
                if (encuesta != null)
                {
                    //pregunta.nombre = ((TextBox)DetailsViewPregunta.FindControl("nombrePregunta")).Text.ToString();
                    //pregunta.orden = Convert.ToInt32(((TextBox)DetailsViewPregunta.FindControl("preguntaOrden")).Text.ToString());
                    encuesta.usuario_alta_id = (Guid)u.ProviderUserKey;
                    encuesta.status_id = 1;
                    encuesta.fecha_status = DateTime.Now;
                    encuesta.fecha_alta = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }

        protected void OAEncuesta_Updating(object sender, OpenAccessLinqDataSourceUpdateEventArgs e)
        {
            using (EntitiesModel.EntitiesModel context = new EntitiesModel.EntitiesModel())
            {
                MembershipUser u = Membership.GetUser();
                encuesta encuesta = e.NewObject as encuesta;
                encuesta.fecha_cambio = DateTime.Now;
                encuesta.usuario_cambio_id = (Guid)u.ProviderUserKey;
                context.SaveChanges();
            }
        }

        protected void OAPreguntas_Inserting(object sender, OpenAccessLinqDataSourceInsertEventArgs e)
        {
            using (EntitiesModel.EntitiesModel context = new EntitiesModel.EntitiesModel())
            {
                MembershipUser u = Membership.GetUser();
                pregunta pregunta = e.NewObject as pregunta;
                ParameterCollection collecntion = OAPreguntas.InsertParameters;
                if (pregunta != null)
                {
                    pregunta.usuario_alta_id = (Guid)u.ProviderUserKey;
                    pregunta.fecha_alta = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }
        protected void OAPreguntas_Updating(object sender, OpenAccessLinqDataSourceUpdateEventArgs e)
        {
            using (EntitiesModel.EntitiesModel context = new EntitiesModel.EntitiesModel())
            {
                MembershipUser u = Membership.GetUser();
                pregunta pregunta = e.NewObject as pregunta;
                pregunta.fecha_cambio = DateTime.Now;
                pregunta.usuario_cambio_id = (Guid)u.ProviderUserKey;
                context.SaveChanges();
            }
        }


        protected void OARespuestas_Inserting(object sender, OpenAccessLinqDataSourceInsertEventArgs e)
        {
            using (EntitiesModel.EntitiesModel context = new EntitiesModel.EntitiesModel())
            {
                MembershipUser u = Membership.GetUser();
                respuesta respuesta = e.NewObject as respuesta;
                if (respuesta != null)
                {
                    respuesta.fecha_alta = DateTime.Now;
                    respuesta.usuario_alta_id = (Guid)u.ProviderUserKey;
                    respuesta.programa_id = 1;
                    context.SaveChanges();
                }
            }
        }

        protected void OARespuestas_Updating(object sender, OpenAccessLinqDataSourceUpdateEventArgs e)
        {
            using (EntitiesModel.EntitiesModel context = new EntitiesModel.EntitiesModel())
            {
                MembershipUser u = Membership.GetUser();
                respuesta respuesta = e.NewObject as respuesta;
                respuesta.fecha_cambio = DateTime.Now;
                respuesta.usuario_cambio_id = (Guid)u.ProviderUserKey;
                context.SaveChanges();
            }
        }

        protected void RadGrid1_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
            switch (e.DetailTableView.Name)
            {
                case "Preguntas":
                    {
                        string EncuestaID = dataItem.GetDataKeyValue("id").ToString();
                        //Parameter param = new Parameter("encuesta_id",DbType.Int32,EncuestaID);
                        //param.Name = "encuestaID";
                        OAPreguntas.Where = "encuesta_id = " + EncuestaID;
                        OAPreguntas.InsertParameters.Add("encuesta_id", EncuestaID);
                        //e.DetailTableView.DataSource = OAPreguntas;
                        break;
                    }

                case "Respuestas":
                    {
                        string preguntaID = dataItem.GetDataKeyValue("id").ToString();
                        //Parameter param = new Parameter("encuesta_id",DbType.Int32,EncuestaID);
                        //param.Name = "encuestaID";
                        OARespuestas.Where = "pregunta_id = " + preguntaID;
                        //e.DetailTableView.DataSource = OARespuestas;
                        break;
                    }
            }
        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                if (item.OwnerTableView.Name == "Encuestas")
                {
                    ((LinkButton)item["AutoGeneratedEditColumn"].Controls[0]).Text = "Editar";
                    ((LinkButton)item["AutoGeneratedDeleteColumn"].Controls[0]).Text = "Desactivar";
                }
                else
                {
                    ((LinkButton)item["AutoGeneratedEditColumn"].Controls[0]).Text = "Editar";
                    ((LinkButton)item["AutoGeneratedDeleteColumn"].Controls[0]).Text = "Eliminar";
                }
            }

            if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (e.Item is GridEditFormInsertItem || e.Item is GridDataInsertItem)
                {
                    //Item A insertar
                    if (e.Item.OwnerTableView.Name == "Encuestas")
                    {
                        GridEditableItem eitem = (GridEditableItem)e.Item;
                        //Se deshabilita Ajax para RadUpload
                        RadUpload upload = eitem["logo"].Controls[0] as RadUpload;
                        ajaxPanel.ResponseScripts.Add(string.Format("window['UploadId'] = '{0}';", upload.ClientID));
                        //Ocultan campos innecesarios al insertar
                        eitem["id"].Parent.Visible = false;    // for making the cell invisible during editing                        
                        eitem["status_id"].Parent.Visible = false;    // for making the cell invisible during editing
                        eitem["fecha_status"].Parent.Visible = false; // for making its label also invisible
                        eitem["fecha_status"].Parent.Visible = false; // for making its label also invisible
                        eitem["guion"].Parent.Visible = false; // for making its label also invisible
                        eitem["cierre"].Parent.Visible = false; // for making its label also invisible
                        eitem["fecha_alta"].Parent.Visible = false; // for making its label also invisible
                        eitem["fecha_cambio"].Parent.Visible = false; // for making its label also invisible
                        eitem["fecha_baja"].Parent.Visible = false; // for making its label also invisible
                        eitem["usuario_alta_id"].Parent.Visible = false; // for making its label also invisible
                        eitem["usuario_cambio_id"].Parent.Visible = false; // for making its label also invisible
                        eitem["usuario_baja_id"].Parent.Visible = false; // for making its label also invisible                        
                    }
                    else if (e.Item.OwnerTableView.Name == "Preguntas")
                    {
                        GridEditableItem eitem = (GridEditableItem)e.Item;
                        eitem["id"].Parent.Visible = false;
                    }
                    else if (e.Item.OwnerTableView.Name == "Respuestas")
                    {
                        GridEditableItem eitem = (GridEditableItem)e.Item;
                        eitem["id"].Parent.Visible = false;    // for making the cell invisible during editing                                                
                    }

                }
                else
                {
                    //Item A editar
                    if (e.Item.DataItem is EntitiesModel.encuesta)
                    {
                        GridEditableItem eitem = (GridEditableItem)e.Item;
                        //Se deshabilita Ajax para RadUpload
                        RadUpload upload = eitem["logo"].Controls[0] as RadUpload;
                        ajaxPanel.ResponseScripts.Add(string.Format("window['UploadId'] = '{0}';", upload.ClientID));
                        //Ocultan campos innecesarios al editar
                        eitem["status_id"].Parent.Visible = false;    // for making the cell invisible during editing
                        eitem["fecha_status"].Parent.Visible = false; // for making its label also invisible
                        eitem["fecha_status"].Parent.Visible = false; // for making its label also invisible
                        eitem["guion"].Parent.Visible = false; // for making its label also invisible
                        eitem["cierre"].Parent.Visible = false; // for making its label also invisible
                        eitem["fecha_alta"].Parent.Visible = false; // for making its label also invisible
                        eitem["fecha_cambio"].Parent.Visible = false; // for making its label also invisible
                        eitem["fecha_baja"].Parent.Visible = false; // for making its label also invisible
                        eitem["usuario_alta_id"].Parent.Visible = false; // for making its label also invisible
                        eitem["usuario_cambio_id"].Parent.Visible = false; // for making its label also invisible
                        eitem["usuario_baja_id"].Parent.Visible = false; // for making its label also invisible
                    }
                    else if (e.Item.DataItem is EntitiesModel.pregunta)
                    {
                        GridEditableItem eitem = (GridEditableItem)e.Item;
                        eitem["id"].Parent.Visible = false;
                    }
                    else if (e.Item.DataItem is EntitiesModel.respuesta)
                    {
                        GridEditableItem eitem = (GridEditableItem)e.Item;
                        eitem["id"].Parent.Visible = false;
                    }
                }
            }
        }

        protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
        {
            // Detect the Detail Table name
            if ("Preguntas".Equals(e.Item.OwnerTableView.Name))
            {
                // Get the Parent Item in which the Detail Table is placed
                GridDataItem parentItem = (GridDataItem)e.Item.OwnerTableView.ParentItem;
                // Set the DataKeyValue of the parent item as a parameter of the DataSource control
                OAPreguntas.InsertParameters["encuesta_id"].DefaultValue = parentItem.OwnerTableView.DataKeyValues[parentItem.ItemIndex]["id"].ToString();
            }
            if ("Respuestas".Equals(e.Item.OwnerTableView.Name))
            {
                // Get the Parent Item in which the Detail Table is placed
                GridDataItem parentItem = (GridDataItem)e.Item.OwnerTableView.ParentItem;
                // Set the DataKeyValue of the parent item as a parameter of the DataSource control
                OARespuestas.InsertParameters["pregunta_id"].DefaultValue = parentItem.OwnerTableView.DataKeyValues[parentItem.ItemIndex]["id"].ToString();
            }
        }

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.ExpandCollapseCommandName)
            {
                foreach (GridItem item in e.Item.OwnerTableView.Items)
                {
                    if (item.Expanded && item != e.Item)
                    {
                        item.Expanded = false;
                    }
                }
            }
        }

        protected void RadMenu1_ItemDataBound(object sender, RadMenuEventArgs e)
        {
            DataRowView dataRow = e.Item.DataItem as DataRowView;
            if (dataRow != null)
            {
                e.Item.ToolTip = dataRow["alt"].ToString(); // TooTip                
                e.Item.NavigateUrl = dataRow["url"].ToString(); // Agrega la url
            }
        }
    }
}