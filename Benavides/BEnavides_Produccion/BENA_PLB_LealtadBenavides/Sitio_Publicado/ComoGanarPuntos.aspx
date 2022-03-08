<%@ Page Title="" Language="C#" MasterPageFile="~/MasterECard.Master" AutoEventWireup="true"
    CodeBehind="ComoGanarPuntos.aspx.cs" Inherits="WebPfizer.LMS.eCard.ComoGanarPuntos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-43180890-1', 'beneficiointeligente.com.mx');
        ga('send', 'pageview');
    </script>
    <asp:Panel ID="pnlComoGanarPuntos" runat="server">
        <image src="Imagenes_Benavides/como-ganas.jpg" style='height: 330px; width: 641px'></image>
        <asp:LinkButton ID="lnkregresar" runat="server" ForeColor="#777E7F" Font-Bold="False"
            CssClass="EtiquetaGris" OnClick="lnkregresar_Click">>>Regresar</asp:LinkButton>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
