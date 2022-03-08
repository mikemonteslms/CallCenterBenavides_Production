using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace CNegocio
{
    public static class csQuiniela
    {
        public static DataView ObtenerPartidosQuniela(string fecha, int participanteID)
        {
            DataSet dsResultado = CallCenterDB.csQuniela.ObtieneQuniela(fecha, participanteID);
            DataView vistaResultado = new DataView();
            if (dsResultado != null)
            {
                if (dsResultado.Tables.Count > 0)
                {
                    foreach (DataRow dr in dsResultado.Tables[0].Rows)
                    {
                        dr["bandera_local"] = "Images/quiniela/paises banderas/local/" + dr["bandera_local"].ToString().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ñ", "n").Replace("ú", "u");
                        dr["bandera_visitante"] = "Images/quiniela/paises banderas/visitantes/" + dr["bandera_visitante"].ToString().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ñ", "n").Replace("ú", "u");
                    }
                    vistaResultado = dsResultado.Tables[0].DefaultView;
                    vistaResultado.Sort = "fecha asc";
                }
            }
            return vistaResultado;
        }

        public static void InsertaQuniela(Telerik.Web.UI.RadListView listaPartidos, int participanteID)
        {
            foreach (Telerik.Web.UI.RadListViewItem item in listaPartidos.Items)
            {
                if ((((TextBox)item.FindControl("txtMarcadorLocal")).Text != string.Empty) && (((TextBox)item.FindControl("txtMarcadorVisitante")).Text != string.Empty))
                {
                    CallCenterDB.csQuniela.InsertaQuniela(participanteID, int.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)item.FindControl("hdnPartidoID")).Value),
                         int.Parse(((TextBox)item.FindControl("txtMarcadorLocal")).Text), int.Parse(((TextBox)item.FindControl("txtMarcadorVisitante")).Text));
                }
            }
        }

        public static void InsertaPartido(string grupo, string fecha, string horario, string local, string visitante, string sede, int marcador_local, int marcador_visitante)
        {
            CallCenterDB.csQuniela.InsertaPartido(grupo, fecha, horario, local, visitante, sede, marcador_local, marcador_visitante);
        }

        public static DataView ObtenerPartidosMarcador(int partidoID)
        {
            DataSet dsResultado = CallCenterDB.csQuniela.ObtienePartido(partidoID);
            DataView vistaResultado = new DataView();
            if (dsResultado != null)
            {
                vistaResultado = dsResultado.Tables[0].DefaultView;
                vistaResultado.Sort = "fecha, horario asc";
            }
            return vistaResultado;
        }

        public static void ActualizaMarcador(Telerik.Web.UI.GridItem marcador)
        {
            CallCenterDB.csQuniela.InsertaMarcador(int.Parse(marcador.OwnerTableView.DataKeyValues[marcador.ItemIndex]["id"].ToString()), int.Parse(((TextBox)marcador.FindControl("txtMarcadorLocal")).Text), int.Parse(((TextBox)marcador.FindControl("txtMarcadorVisitante")).Text));
        }
    }
}