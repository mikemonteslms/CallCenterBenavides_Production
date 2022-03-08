<%@ page title="" language="C#" masterpagefile="~/contenido.master" autoeventwireup="true" codebehind="catalogo.aspx.cs" inherits="Portal.catalogo" EnableEventValidation="false" %>

<%@ mastertype virtualpath="~/contenido.master" %>

<asp:content id="Content1" contentplaceholderid="contenido_head" runat="server">
    <link href="css/estilos.css" rel="stylesheet" type="text/css">
    <link href="src/perfect-scrollbar.css" rel="stylesheet">
    <script src="src/jquery.mousewheel.js"></script>
    <script src="src/perfect-scrollbar.js"></script>
    <style>
        #cuadrilla-productos {
            height: 560px !important;
            overflow: hidden;
            position: absolute;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function ($) {
            $('#cuadrilla-productos').perfectScrollbar({
                wheelSpeed: 15,
                wheelPropagation: false
            });
        });
    </script>
</asp:content>
<asp:content id="Content2" contentplaceholderid="contenido_body" runat="server">
    <div id="contenedor" class="main">
        <main>
<h3>Catálogo de Premios</h3>
<section id="categorias">
            <telerik:RadMenu ID="menu_categorias" runat="server" Flow="Vertical" EnableEmbeddedBaseStylesheet="false" EnableEmbeddedSkins="false" Skin="" DataValueField="id" DataTextField="descripcion" 
                OnItemClick="menu_categorias_ItemClick" CssClass="menu_debajo">
        </telerik:RadMenu>
    </section>
    <!-- CUADRILLA DE PRODUCTOS -->
    <section id="cuadrilla-productos">
        <asp:Repeater ID="rptPremios" runat="server">
            <ItemTemplate>
    <!-- PRODUCTO -->
    	<div class="producto">
       		<a href="#"><img src='<%# Eval("url_imagen_small") %>' alt=<%# Eval("descripcion") %> width="116" height="100"/></a>
           <p class="titulo-producto"><%# Eval("descripcion").ToString().Length <= 30 ? Eval("descripcion") : Eval("descripcion").ToString().Substring(0,20) + "..." %></p>
           <p class="producto-kilometros"><%# Convert.ToInt32(Eval("puntos")).ToString("N0") %> puntos</p>
            <asp:LinkButton ID="lnkCanjear" runat="server" Text="Canjear" CssClass="boton-gris" OnCommand="lnkPremio_Command" CommandName="canjear" CommandArgument='<%# Eval("id") %>' ></asp:LinkButton>
            <asp:LinkButton ID="lnkDetalle" runat="server" Text="Detalle" CssClass="boton-gris-2" OnCommand="lnkPremio_Command" CommandName="detalle" CommandArgument='<%# Eval("id") %>' ></asp:LinkButton>
       </div>
            </ItemTemplate>
        </asp:Repeater>
    </section>
    	
     </main>
    </div>
    <cc1:ModalPopupExtender ID="popDetallePremio" runat="server" TargetControlID="lnkDetallePremio"
        PopupControlID="pnlDetallePremio" BackgroundCssClass="Sombra" CancelControlID="btnCerrarDetalle">
    </cc1:ModalPopupExtender>
    <asp:HyperLink ID="lnkDetallePremio" runat="server"></asp:HyperLink>
    <asp:Panel ID="pnlDetallePremio" runat="server" Style="display: none;">
        <div class="cuadro_detalle_premio">
            <div class="mensaje">
                    <div class="marco_cerrar">
            <asp:LinkButton ID="btnCerrarDetalle" runat="server" CssClass="boton-cerrar"></asp:LinkButton>
                        </div>
                <div class="marco_producto">
                    <asp:Image ID="imgDetallePremio" runat="server" Width="290" Height="250" />
                    <p class="titulo-producto">
                        <asp:Label ID="lblDetallePremio" runat="server"></asp:Label></p>
                    <br />
                    <p class="producto-marca">
                        Marca: <asp:Label ID="lblMarcaPremio" runat="server"></asp:Label></p>
                    <br />
                    <p class="producto-kilometros Azul"><b>
                        <asp:Label ID="lblPuntosDetalle" runat="server"></asp:Label> Puntos</b></p>
                    <p class="producto-marca">
                        <br />
            <asp:LinkButton ID="lnkCanjear1" runat="server" Text="Canjear" CssClass="boton-gris" OnCommand="lnkPremio_Command" CommandName="canjear" CommandArgument='<%# Eval("id") %>' ></asp:LinkButton>
                        </p>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:content>
