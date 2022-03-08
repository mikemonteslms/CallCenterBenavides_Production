<%@ Page Title="" Language="C#" MasterPageFile="~/datos.master" AutoEventWireup="true" CodeBehind="premios.aspx.cs" Inherits="Portal.premios" %>
<%@ MasterType VirtualPath="~/datos.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="datos_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="datos_body" runat="server">
    <section id="cuadrilla-productos" style="border:none;">

	 <div id="contenedor-movimientos" class="left">
        <div class="barra-titulo">
           <p class="columna-titulo" style="width:110px;">Fecha canje</p>
           <p class="columna-titulo" style="width:110px;">Mensajería</p>
           <p class="columna-titulo" style="width:110px;">Número de guía</p>
           <p class="columna-titulo" style="width:320px;">Premio</p>
           <p class="kilometros" style="width:120px;">Status de entrega</p>
        </div>
                        <asp:ListView ID="lvDetalleEntregaPremios" runat="server">
            <ItemTemplate>
        <div class="barra-contenido">
            <p class="columna-contenido" style="width:100px;"><%# Eval("FechaCanje") %></p>
            <p class="columna-contenido" style="width:100px;"><%# Eval("Mensajeria") %></p>
            <p class="columna-contenido" style="width:100px;"><%# Eval("NumeroGuia") %></p>
            <p class="columna-contenido" style="width:360px;"><%# Eval("DescripcionPremio") %></p>
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
</asp:Content>
