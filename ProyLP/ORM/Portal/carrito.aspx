<%@ page title="" language="C#" masterpagefile="~/datos.master" autoeventwireup="true" codebehind="carrito.aspx.cs" inherits="Portal.carrito" %>

<%@ mastertype virtualpath="~/datos.master" %>
<asp:content id="Content1" contentplaceholderid="datos_head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="datos_body" runat="server">
    <section id="cuadrilla-productos" style="border:none;">

         <asp:MultiView id="mvCarrito" runat="server">
             <asp:View id="vCarrito" runat="server">
	 <div id="contenedor-movimientos" class="left">
        <div class="barra-titulo">
            <p class="concepto" style="width:349px;">Premio</p>
           <p class="columna-titulo">Cantidad</p>
           <p class="columna-titulo">Puntos</p>
           <p class="kilometros">Subtotal</p>
        </div>
                        <asp:ListView ID="lvCarrito" runat="server">
            <ItemTemplate>
        <div class="barra-contenido">
            <div class="concepto" style="width:366px;display: inline-block;">
                <img src='<%# Eval("URL") %>' class="premio-foto" /> 
                <p><%# Eval("Descripcion") %> 
                    <br /><%# Eval("Clave") %>
                    <br />
                    <asp:LinkButton id="lnkEliminar" runat="server" text="Eliminar" OnCommand="Carrito_Command" CommandName="eliminar" CommandArgument='<%# Eval("PremioID") %>' class="texto-small btn-eliminar">
                    </asp:LinkButton>
                </p>
            </div>
            <div class="columna-contenido"><asp:TextBox id="cantidad" runat="server" name="cantidad" Text='<%# Eval("Cantidad") %>' db-id='<%# Eval("PremioID") %>' OnTextChanged="txtCantidad_TextChanged" AutoPostBack="true" CssClass="cantidad-input" ></asp:TextBox></div>
            <p class="columna-contenido"><%# Eval("Puntos") %> puntos</p>
            <p class="columna-contenido"><%# (Convert.ToInt32(Eval("Puntos")) * Convert.ToInt32(Eval("Cantidad"))).ToString("N0") %> puntos</p>
        </div>
</ItemTemplate>
                                        <EmptyDataTemplate>
                    <div class="barra-contenido" style="background: #666; color: #fff !important; padding-left:10px; width:806px;">
                        No se encontraron registros
                    </div>
                </EmptyDataTemplate>
                        </asp:ListView>
    </div>
<a href="catalogo.aspx" class="boton-gris btn-otros-premios">Ver otros premios</a>  

<asp:LinkButton id="lnkCanjear" runat="server" Text="Canjear" OnClick="lnkCanjear_Click" class="boton-gris btn-hacer-pedido"></asp:LinkButton>
             </asp:View>
             <asp:View id="vVacio" runat="server">
	 <div id="contenedor-movimientos" class="left">
        <div class="barra-titulo">
            <p class="concepto" style="width:349px;">Premio</p>
           <p class="columna-titulo">Cantidad</p>
           <p class="columna-titulo">Puntos</p>
           <p class="kilometros">Subtotal</p>
        </div>
        <div class="barra-contenido" style="background: #666;">
            <div class="concepto" style="width:480px;display: inline-block; color:#fff !important; padding-left:10px;">El carrito de compras está vacío</div>
        </div>
    </div>
<a href="catalogo.aspx" class="boton-gris btn-otros-premios">Ver otros premios</a>  
             </asp:View>
             <asp:View id="vCompleto" runat="server">
	 <div id="contenedor-movimientos" class="left">
                 	<p><b>¡Pedido realizado con éxito!</b><br />La cantidad de puntos canjeada es de: <b><asp:Label id="lblPuntosCanjeados" runat="server" Text="0"></asp:Label> puntos</b></p>

<a href="micuenta.aspx" class="boton-gris btn-otros-premios">Volver a Mi Cuenta</a>       
</div>	
             </asp:View>
         </asp:MultiView>
        
</section>
</asp:content>
