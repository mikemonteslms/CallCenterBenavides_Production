<%@ page title="" language="C#" masterpagefile="~/contenido.master" autoeventwireup="true" codebehind="guias.aspx.cs" inherits="Portal.guias" %>

<%@ mastertype virtualpath="~/contenido.master" %>
<asp:content id="Content1" contentplaceholderid="contenido_head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="contenido_body" runat="server">
    <div id="contenedor" class="main">
<main id="mecanica">

<h3>Guías y Tips</h3>

<p>Descarga las Guías y Tips que tenemos para ti.</p><br />

<div class="bloque-ranking" >
<h3 style="font-size:1.1em;background:url(images/icon-guias.jpg) 0px -2px no-repeat;padding: 0 0 7px 29px;">Descarga de Guías</h3>
<div class="link-pdf-descarga" ><img src="images/pdf-icon.png" /><a href="docs/Manual_Canje.pdf" target="_blank">Manual de Canje</a></div>
<div class="link-pdf-descarga" ><img src="images/pdf-icon.png" /><a href="docs/Manual_Acuse_recibo.pdf" target="_blank">Manual de Acuse de recibo</a></div>
<div class="link-pdf-descarga" ><img src="images/pdf-icon.png" /><a href="docs/Manual_Mecanica.pdf" target="_blank">Manual de Mecánica</a></div>

    <asp:Panel id="pnlGSF" runat="server" visible="false">
<div class="link-pdf-descarga" ><img src="images/pdf-icon.png" /><a href="docs/Proceso_Asignacion_Ventas.pdf" target="_blank">Manual de Asignación de Venta</a></div>
</asp:Panel>
</div>

<div class="bloque-ranking">
<h3 style="font-size:1.1em;background:url(images/icon-tips.jpg) 0px -2px no-repeat;padding: 0 0 7px 29px;">Descarga de Tips</h3>
</div>
</main>   
    </div>
</asp:content>
