<%@ page title="" language="C#" masterpagefile="~/datos.master" autoeventwireup="true" codebehind="micuenta.aspx.cs" inherits="Portal.micuenta" %>

<%@ mastertype virtualpath="~/datos.master" %>
<asp:content id="Content1" contentplaceholderid="datos_head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="datos_body" runat="server">
    <section id="cuadrilla-productos">

        <!-- BARRA DE AVANCE -->
        <%--<div id="barra-avance">
            <p>INICIO</p>
            <div class="nivel" id="nivel-1" style="border-left: 1px solid #cccccc;">
                <img src="images/puntero.png" class="puntero" style="display: none;" />
                <div class="avance" style="width: 100%"></div>
                <div class="avance-completo"></div>
                <p class="nivel-numero">Nivel 1</p>
            </div>

            <div class="nivel" id="nivel-2">
                <div class="avance" style="width: 100%"></div>
                <div class="avance-completo"></div>
                <p class="nivel-numero">Nivel 2</p>
            </div>

            <div class="nivel" id="nivel-3">
                <div class="avance" style="width: 100%"></div>
                <div class="avance-completo"></div>
                <p class="nivel-numero">Nivel 3</p>
            </div>

            <div class="nivel" id="nivel-4">
                <div class="avance" style="width: 100%"></div>
                <div class="avance-completo"></div>
                <p class="nivel-numero">Nivel 4</p>
            </div>

            <div class="nivel" id="nivel-5">
                <img src="images/puntero.png" class="puntero" />
                <div class="avance"></div>
                <div class="avance-completo"></div>
                <p class="nivel-numero">Nivel 5</p>
            </div>
            <p style="float: right;">META</p>
        </div>--%>
        <!-- FIN BARRA DE AVANCE -->

        <!-- mapa -->
        <div class="mapa">
            <div id="datos-mapa">
                <p style="margin: 0;">Nivel 1</p>
                <p><span class="kilometros-box">
                    <asp:Label ID="lblSaldo" runat="server" Text="0"></asp:Label></span> Km</p>
                <p>
                    Recuerda que entre más ventas<br />
                    acumules, la meta estará más cerca.
                </p>

            </div>
        </div>

        <h3>Movimientos Recientes</h3>

        <div id="contenedor-movimientos">
                    <div class="barra-titulo">
                        <p class="fecha">Fecha</p>
                        <p class="concepto">Concepto</p>
                        <p class="ticket">Cantidad</p>
                        <p class="kilometros">Kilómetros</p>
                    </div>
                    <asp:ListView id="lvTransacciones" runat="server">
                                    <ItemTemplate>
    <div class="barra-contenido">
    	<p class="fecha"><%# Eval("fecha") %></p>
    	<p class="concepto"><%# Eval("concepto") %></p>
    	<p class="ticket"><%# Eval("cantidad") %></p>
    	<p class="kilometros"><%# Convert.ToInt32(Eval("puntos")).ToString("N0") %></p>
</div>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                    <div class="barra-contenido" style="background: #666; color: #fff !important; padding-left:10px; width:806px;">
                        No se encontraron movimientos
                    </div>
                </EmptyDataTemplate>
                        </asp:ListView>
        </div>


    </section>
</asp:content>
