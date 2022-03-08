<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Portal.error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido_body" runat="server">
    <div id="contenedor_proximamente" class="main">
        <p id="titulo"><span class="Azul"><b>LOYALTY WORLD</b></span><br><br />
            <strong>VOLKSWAGEN SERVICIOS FINANCIEROS</strong></p>
        <hr />
        <div style="padding:70px 0px 20px 0px;">
            <p>Ocurrió un error al procesar la solicitud.</p>
            <p>Por favor intenta nuevamente</p>
        </div>
        <div style="padding:60px 0px 20px 0px;">
            <asp:LinkButton ID="lnkSesion" runat="server" onclick="lnkSesion_Click">Iniciar nueva sesión.</asp:LinkButton>
        </div>
        <div>
            <img src="images/logosVW.png" alt="" width="296" height="28" />
        </div>
    </div>
</asp:Content>
