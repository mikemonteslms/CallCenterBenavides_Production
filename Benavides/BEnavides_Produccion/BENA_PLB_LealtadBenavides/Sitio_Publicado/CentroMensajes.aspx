<%@ Page Language="C#" MasterPageFile="~/MasterECard.Master" AutoEventWireup="true" CodeBehind="CentroMensajes.aspx.cs" Inherits="WebPfizer.LMS.eCard.CentroMensajes" Title="" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="general">
                <table border="1">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="height: 30px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 30px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 110px; text-align: center;" class="Etiqueta">
                                        <asp:Label ID="Label1" runat="server" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 110px; text-align: center;" class="Etiqueta">
                                        <asp:Label ID="Label2" runat="server" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                                                    <td style="height: 10px;">
                                    </td>
                                <tr>
                                    <td style="width: 110px; text-align: center;" class="Etiqueta">
                                        <asp:Label ID="Label3" runat="server" Width="400px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="Boton" OnClick="btnAceptar_Click" Width="70px">
                                        </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 30px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 30px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="height: 30px;">
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

