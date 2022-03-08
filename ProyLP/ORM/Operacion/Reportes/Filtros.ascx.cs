using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;
using System.Data;

namespace ORMOperacion.Reportes
{

    public partial class Filtros : System.Web.UI.UserControl
    {

        /// <summary>
        /// Obtiene o establece el valor de fecha inicial 
        /// </summary>
        public DateTime FechaInicial
        {
            get
            {
                return (Convert.ToDateTime(rdpFechaInicial.SelectedDate));
            }
            set
            {
                rdpFechaInicial.SelectedDate = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de fecha final
        /// </summary>
        public DateTime FechaFinal
        {
            get
            {
                return (Convert.ToDateTime(rdpFechaFinal.SelectedDate));
            }
            set
            {
                rdpFechaFinal.SelectedDate = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el combo1
        /// </summary>
        public RadComboBox Combo1
        {
            get
            {
                return (rcbListado1);
            }
            set
            {
                rcbListado1 = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el combo 2
        /// </summary>
        public RadComboBox Combo2
        {
            get
            {
                return (rcbListado2);
            }
            set
            {
                rcbListado2 = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el combo 3
        /// </summary>
        public RadComboBox Combo3
        {
            get
            {
                return (rcbListado3);
            }
            set
            {
                rcbListado3 = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el combo 2
        /// </summary>
        public RadComboBox Combo4
        {
            get
            {
                return (rcbListado4);
            }
            set
            {
                rcbListado4 = value;
            }
        }

        /// <summary>
        /// Campo para pintar la ruta de acuerdo a la posición del Menú
        /// </summary>
        public string RutaMenu
        {
            get
            {
                return (lblRuta.Text);
            }
            set
            {
                lblRuta.Text = value;
            }
        }

        /// <summary>
        /// Evento para ejecutar la búsqueda de acuerdo a los filtros seleccionados
        /// </summary>
        public event EventHandler BuscarClicked;

        public event EventHandler SelectedIndexChanged;

        /// <summary>
        /// Evento para exportar a excel
        /// </summary>
        public event EventHandler ExportarClicked;

        /// <summary>
        /// El botón de exportar es publico para que se puedan tomar las propiedades del mismo y deshabilitarle el ajax
        /// </summary>
        public RadButton BotonExportar
        {
            get
            {
                return (ibtnExportar);
            }
            set
            {
                ibtnExportar = value;
            }
        }


        /// <summary>
        /// Muestra u oculta el boton
        /// </summary>
        public bool BotonBuscar
        {
            get
            {
                return (ibtnBuscar.Visible);
            }
            set
            {
                ibtnBuscar.Visible = value;
            }
        }


        public string TablaFechas
        {
            set
            {
                trFechas.Style["Display"] = value;
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {

        }

     

        /// <summary>
        /// Personalización del filtro de búsqueda cuando es combo
        /// </summary>
        /// <param name="combo">Combobox que se va a usar de la plantilla</param>
        /// <param name="texto">Texto que va a mostrar el listado del combobox</param>
        /// <param name="valor">Valor que tomará el combobox</param>
        /// <param name="tablaBD">Nombre de la tabla mapeada a la base de datos</param>
        /// <param name="nombreEtiqueta">Nombre de la etiqueta que se va a personalizar</param>
        /// <param name="valorEtiqueta">Texto que contendrá la etqieuta del filtro</param>
        /// <param name="nombreTabla">Nombre de la tabla HTML que se va a personalizar</param>
        /// <param name="valorTabla">Indica si se muestra u oculta la tabla</param>
        public void ConfigurarCombo(RadComboBox combo, string texto, string valor, string tablaBD, string nombreEtiqueta, string valorEtiqueta, string nombreTabla, string valorTabla, string condicion, string usuario)
        {
            combo = CrearCombo(combo, texto, valor, tablaBD, condicion, usuario);

            Label etiqueta = (Label)this.FindControl(nombreEtiqueta);
            etiqueta.Text = valorEtiqueta;

            HtmlTable tabla = (HtmlTable)this.FindControl(nombreTabla);
            tabla.Style.Add("Display", valorTabla);
        }

        /// <summary>
        /// Personalización del filtro de búsqueda cuando es fecha
        /// </summary>
        /// <param name="nombreEtiqueta">Nombre de la etiqueta que se va a personalizar</param>
        /// <param name="valorEtiqueta">Texto que contendrá la etqieuta del filtro</param>
        /// <param name="nombreTabla">Nombre de la tabla HTML que se va a personalizar</param>
        /// <param name="valorTabla">Indica si se muestra u oculta la tabla</param>
        public void ConfigurarFecha(string nombreEtiqueta, string valorEtiqueta, string nombreTabla, string valorTabla)
        {

            Label etiqueta = (Label)this.FindControl(nombreEtiqueta);
            etiqueta.Text = valorEtiqueta;

            HtmlTable tabla = (HtmlTable)this.FindControl(nombreTabla);
            tabla.Style.Add("Display", valorTabla);
        }

        /// <summary>
        /// Ejecución del evento de Buscar o Exportar a excel
        /// </summary>
        /// <param name="sender"></param>
        protected virtual void OnClick(object sender)
        {
            if (((RadButton)sender).CommandName == "Buscar")
            {
                if (this.BuscarClicked != null)
                {
                    this.BuscarClicked(sender, new EventArgs());
                }

            }
            if (((RadButton)sender).CommandName == "Exportar")
            {
                if (this.ExportarClicked != null)
                {
                    this.ExportarClicked(sender, new EventArgs());
                }
            }
        }


        /// <summary>
        /// Ejecución del evento 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtn_Click(object sender, EventArgs e)
        {
            OnClick(sender);
        }

      
        /// <summary>
        /// Crea un radcombobox de manera dinámica y le asocia los datos
        /// </summary>
        /// <param name="combo">Control que se va a generar</param>
        /// <param name="texto">Texto que va a mostrar el listado del combobox</param>
        /// <param name="valor">Valor que tomará el combobox</param>
        /// <param name="tablaBD">Nombre de la tabla mapeada a la base de datos</param>
        /// <returns></returns>
        public RadComboBox CrearCombo(RadComboBox combo, string texto, string valor, string tablaBD, string condicion, string usuario)
        {
            if (tablaBD == "programas")
            {
                csDataBase Distribuidora = new csDataBase();
                Distribuidora.Query = "SELECT p.id, p.descripcion FROM programa_aspnet_User pau, programa p WHERE pau.programa_id = p.id and UserId = '" + usuario + "'";
                Distribuidora.EsStoreProcedure = false;

                combo.DataSource = Distribuidora.dtConsulta().DefaultView;
                combo.DataTextField = "descripcion";
                combo.DataValueField = "id";
                combo.DataBind();
                combo.AutoPostBack = true;

            }
            else
            {

                //  RadComboBox combo = (RadComboBox)this.FindControl(nombreCombo);
                // combo = new RadComboBox();
                combo.DataTextField = texto;
                combo.DataValueField = valor;

                Telerik.OpenAccess.Web.OpenAccessLinqDataSource ds = new Telerik.OpenAccess.Web.OpenAccessLinqDataSource();
                ds.ContextTypeName = "EntitiesModel.EntitiesModel";
                ds.ResourceSetName = tablaBD;
                if (tablaBD != "mecanicas")
                {
                    ds.Where = "usuario_baja_id == null";
                }

                if (condicion != string.Empty)
                {
                    if (tablaBD != "mecanicas")
                    {
                        ds.Where += " and ";
                    }

                    ds.Where += condicion;

                }

                ds.OrderBy = "Descripcion";

                ds.EntityTypeName = "";
                ds.ID = "OA" + tablaBD;

                ds.DataBind();

                combo.DataSource = ds;
                combo.DataBind();
                if (tablaBD != "programas")
                {
                    combo.Items.Insert(0, new RadComboBoxItem("TODOS", "0"));

                }
                else
                {
                    combo.AutoPostBack = true;
                }
            }
        //    combo.SelectedIndex = 0;
            return combo;
        }

        protected void rcbListado1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (this.SelectedIndexChanged != null)
            {
                this.SelectedIndexChanged(sender, new EventArgs());
            }
        }




    }
}