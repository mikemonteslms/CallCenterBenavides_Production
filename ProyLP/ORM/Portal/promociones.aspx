<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.master" AutoEventWireup="true" CodeBehind="promociones.aspx.cs" Inherits="Portal.promociones" %>

<%@ MasterType VirtualPath="~/contenido.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido_head" runat="server">
    <script type="text/javascript">
        function openWinNavigateUrl() {
            $find("<%=RadWindow1.ClientID %>").show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido_body" runat="server">    
    <div id="contenedor" class="main">
        <main id="mecanica">
            <asp:MultiView id="mvNoticias" runat="server">
                <asp:View id="vGSF" runat="server">
                    <h3>Promociones</h3>
                    <img src="images/promociones/ventas-mar-abr-GSF.jpg" style="display:block; margin: 0 auto !important;" />
                    <br />
                    <br />
                    <h3>Noticias</h3>
                    <p class="noticia">¡Llegaron las ventas de <b>enero y febrero!</b></p>
                    <br />
                    <p>Debido a los ajustes por el lanzamiento del programa <b>Loyalty World Volkswagen</b>, les informamos que el periodo de asignación para las ventas de <b>Enero y Febrero</b> quedará abierto.</p>
                    <br />
                    <p class="texto-small">Publicado: 05 / 05 / 2014</p>
                    <br />
                    <p class="noticia">&nbsp;</p>
                    <p>A partir del <b>26 al 30 de mayo</b>, deberás asignar las ventas de tus Gerentes y Asesores de Ventas del periodo de <b>Marzo y Abril</b>.</p>
                    <br />
                    <p>Recuerda que al asignar el 100% de las ventas de tu Concesionaria podrás acumular Kilómetros. </p>
                    <br />
                    <p class="texto-small">Publicado: 14 / 05 / 2014</p>
                    <br />
                    <br />
                    <p class="noticia">¡Llegó el Mundial!</p>
                    <br />
                    <p>Participa llenando la quiniela de cada semana y acumula goles.</p>
                    <br />
                    <p>Los 3 vendedores con mayor número de goles acumulados podrán obtener <b>puntos extras</b>.</p>
                    <br />
                    <p><asp:LinkButton ID="LinkButton1" runat="server" CssClass="Azul bold" ToolTip="Quiniela" OnClientClick="openWinNavigateUrl(); return false;">¿Qué esperas? ¡Participa!</asp:LinkButton></p>
                    <br />
                    <p class="texto-small">Publicado: 10 / 06 / 2014</p>
                    <br />
                    <br />
                    <p>No te pierdas las siguientes noticias...</p>
                </asp:View>
                <asp:View id="vVendedores" runat="server">
                    <h3>Promociones</h3>
                    <img src="images/promociones/ventas-mar-abr-vendedores.jpg" style="display:block; margin: 0 auto !important;" />
                    <br />
                    <br />
                    <h3>Noticias</h3>
                    <p class="noticia">¡Todavía hay tiempo!</p>
                    <br />
                    <p>Debido a los ajustes por el lanzamiento del programa <b>Loyalty World Volkswagen</b>, les informamos que el periodo de asignación para las ventas de <b>Enero y Febrero</b> quedará abierto.</p>
                    <br />
                    <p class="texto-small">Publicado: 05 / 05 / 2014</p>
                    <br />
                    <p class="noticia">&nbsp;</p>
                    <br />
                    <p>A partir del <b>26 al 30 de mayo</b>, revisa los kilómetros del periodo de <b>Marzo y Abril</b> que tu Gerente de Servicios Financieros estará asignando.</p>
                    <br />
                    <p class="texto-small">Publicado: 14 / 05 / 2014</p>
                    <br />
                    <br />
                    <p class="noticia">¡Llegó el Mundial!</p>
                    <br />
                    <p>Participa llenando la quiniela de cada semana y acumula goles.</p>
                    <br />
                    <p>Los 3 vendedores con mayor número de goles acumulados podrán obtener <b>puntos extras</b>.</p>
                    <br />                                        
                    <p><asp:LinkButton ID="LinkButton2" runat="server" CssClass="Azul bold" ToolTip="Quiniela" OnClientClick="openWinNavigateUrl(); return false;">¿Qué esperas? ¡Participa!</asp:LinkButton></p>
                    <br />
                    <p class="texto-small">Publicado: 10 / 06 / 2014</p>
                    <br />                    
                    <br />
                    <p>No te pierdas las siguientes noticias...</p>
                </asp:View>
            </asp:MultiView>
        </main>
    </div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true" Modal="true" VisibleStatusbar="false">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" ShowContentDuringLoad="false" Width="730px"
                Height="610px" Behaviors="Close" NavigateUrl="Quiniela.aspx">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>