using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.GuardaAcceso("Catálogo");
                CargaCategrias();
                CargaPremios(ConfigurationManager.AppSettings["programa"], "0");
            }
        }
        private void CargaCategrias()
        {
            csPremio pr = new csPremio();
            menu_categorias.DataSource = pr.Categorias(ConfigurationManager.AppSettings["programa"]);
            menu_categorias.DataBind();
            Telerik.Web.UI.RadMenuItem todos = new Telerik.Web.UI.RadMenuItem();
            todos.Value = "0";
            todos.Text = "Todas las categorías";
            todos.CssClass = "active";
            menu_categorias.Items.Insert(0, todos);
            menu_categorias.Attributes.Add("class", "RadMenuCategorias");
        }
        private void CargaPremios(string programa, string categoria_id)
        {
            csPremio pr = new csPremio();
            pr.Programa = programa;
            pr.CategoriaID = categoria_id;
            rptPremios.DataSource = pr.PremiosCategoria();
            rptPremios.DataBind();
        }
        protected void menu_categorias_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
        {
            foreach (Telerik.Web.UI.RadMenuItem mi in menu_categorias.Items)
            {
                mi.CssClass = "";
            }
            e.Item.CssClass = "active";
            CargaPremios(ConfigurationManager.AppSettings["programa"], e.Item.Value);

        }

        protected void lnkPremio_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "detalle":
                    csPremio pr = new csPremio();
                    string premio_id = e.CommandArgument.ToString();
                    DataTable dtDetalle = pr.ConsultaPremio_Detalle(int.Parse(premio_id));
                    var detalle_premio = (from premio in dtDetalle.AsEnumerable()
                                          select new
                                          {
                                              Descripcion = premio.Field<string>("descripcion_larga"),
                                              Imagen = premio.Field<string>("url_imagen_large"),
                                              Puntos = premio.Field<int>("puntos"),
                                              Marca = premio.Field<string>("marca_descripcion")
                                          }).SingleOrDefault();
                    lnkCanjear1.CommandArgument = premio_id;
                    lblDetallePremio.Text = detalle_premio.Descripcion;
                    imgDetallePremio.ImageUrl = detalle_premio.Imagen;
                    lblMarcaPremio.Text = detalle_premio.Marca;
                    lblPuntosDetalle.Text = detalle_premio.Puntos.ToString("N0");
                    popDetallePremio.Show();
                    break;
                case "canjear":
                    int res = AgregarCarrito(e.CommandArgument.ToString());
                    switch (res)
                    {
                        case 0:
                            Master.MuestraMensaje("Premio agregado correctamente.");
                            Master.AgregaEvento("location.href='carrito.aspx'");
                            break;
                        case -1:
                            Master.MuestraMensaje("Saldo insuficiente");
                            break;
                        case -2:
                            Master.MuestraMensaje("Tarjeta Éxito por $200.000. Solo podrá canjear hasta $400.000 durante la vigencia del plan");
                            break;
                        case -3:
                            csPremioMX _p = new csPremioMX(e.CommandArgument.ToString());
                            _p.Consulta();
                            break;
                        case -4:
                            Master.MuestraMensaje("Recargas a celular. Solo podrá canjear hasta $100.000 durante la vigencia del plan");
                            break;
                        default:
                            Master.MuestraMensaje("Ocurrió un error al agregar el premio, por favor intente nuevamente.");
                            break;
                    }
                    break;
            }
        }
        protected int AgregarCarrito(string premio_id)
        {
            try
            {
                bool muestra_carrito = false;
                csParticipanteComplementoMX participante = new csParticipanteComplementoMX();
                participante.ID = Session["participante_id"].ToString();
                csCarritoComprasMX carrito = new csCarritoComprasMX();
                csPremioMX p = new csPremioMX(premio_id);
                p.Consulta();
                if (Session["carrito"] == null)
                {
                    if (int.Parse(p.Puntos) <= int.Parse(participante.Saldo))
                    {
                        muestra_carrito = true;
                        p.Cantidad = "1";
                        carrito.Agregar(p);
                    }
                    else
                    {
                        muestra_carrito = false;
                        return -1;
                    }
                }
                else
                {
                    List<csPremioMX> lista_premios = Session["carrito"] as List<csPremioMX>;
                    carrito.Carrito = lista_premios;
                    if (carrito.Puntos + int.Parse(p.Puntos) <= int.Parse(participante.Saldo))
                    {
                        List<csPremioMX> p_tmp = carrito.Buscar(p);
                        if (p_tmp.Count == 0)
                        {
                            p.Cantidad = "1";
                            carrito.Agregar(p);
                        }
                        else
                        {
                            p.Cantidad = (p_tmp.Sum(___p => int.Parse(___p.Cantidad)) + 1).ToString();
                            carrito.Actualizar(p);
                        }
                    }
                    else
                        return -1;
                    muestra_carrito = true;
                }
                if (muestra_carrito)
                {
                    Session["carrito"] = carrito.Carrito;
                }
                return 0;
            }
            catch
            {
                return -5;
            }
        }
    }
}