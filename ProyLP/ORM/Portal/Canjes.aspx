<%@ page title="" language="C#" masterpagefile="~/datos.master" autoeventwireup="true" codebehind="canjes.aspx.cs" inherits="Portal.canjes" %>

<%@ mastertype virtualpath="~/datos.master" %>
<asp:content id="Content1" contentplaceholderid="datos_head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="datos_body" runat="server">
    <section id="cuadrilla-productos" style="border:none;">
	 <div id="contenedor-movimientos" class="left">
        <div class="barra-titulo">
           <p class="columna-titulo" style="width:100px;">Fecha canje</p>
           <p class="columna-titulo" style="width:100px;">Fecha entrega</p>
           <p class="columna-titulo" style="width:360px;">Premio</p>
           <p class="columna-titulo" style="width:100px;">Kilómetros</p>
           <p class="kilometros" style="width:110px;">Status de entrega</p>
        </div>
                        <asp:ListView ID="lvCanjes" runat="server">
            <ItemTemplate>
        <div class="barra-contenido">
            <p class="columna-contenido" style="width:100px;"><%# Eval("FechaCanje") %></p>
            <p class="columna-contenido" style="width:100px;"><%# Eval("FechaEntrega") %></p>
            <p class="columna-contenido" style="width:360px;"><%# Eval("DescripcionPremio") %></p>
            <p class="columna-contenido" style="width:100px;"><%# Convert.ToInt32(Eval("Puntos")).ToString("N0") %></p>
            <p class="columna-contenido" style="width:110px;color:white;"><%# Eval("StatusActual") %></p>
        </div>
</ItemTemplate>
                                        <EmptyDataTemplate>
                    <div class="barra-contenido" style="background: #666; color: #fff !important; padding-left:10px; width:806px;">
                        No se encontraron registros
                    </div>
                </EmptyDataTemplate>
                        </asp:ListView>
         </div>
    </section>
</asp:content>
