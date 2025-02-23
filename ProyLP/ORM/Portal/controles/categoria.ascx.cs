﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CallCenterDB;


namespace Portal.controles
{
    public partial class categoria : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                csLlamada llamada = new csLlamada();
                DataTable dtLlamada = llamada.ConsultaCategoriaLlamada();
                hidnumero_categorias.Value = dtLlamada.Rows.Count.ToString();
                RepeaterCategorias.DataSource = dtLlamada;
                RepeaterCategorias.DataBind();
            }

        }

        protected void RepeaterCategorias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Recuperamos el id del genero actual  
                string id = ((System.Data.DataRowView)(e.Item.DataItem)).Row["id"].ToString();
                csLlamada llamada = new csLlamada();
                llamada.CategoriaLlamada = id;

                // Ahora tenemos que encontrar el Repeater que tenemos dentro del ItemTemplate  
                System.Web.UI.WebControls.Repeater rp = (e.Item.FindControl("RepeaterLlamadas") as
                  System.Web.UI.WebControls.Repeater);

                rp.DataSource = llamada.ConsultaTipoLlamada();
                rp.DataBind();
            }
        }
    }
}