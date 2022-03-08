<%@ Page Language="C#" MasterPageFile="~/MasterEcard.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="WebPfizer.LMS.eCard.Index" %>

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
            <div runat="server" id="general" style="width: 641px;">
                <ul id="mycarousel" class="jcarousel-skin-tango">
                    <asp:Repeater ID="rptImages" runat="server">
                        <ItemTemplate>
                            <li>
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes_Benavides/banners/banner-promociones.jpg" />--%>
                                <img style='height: 330px; width: 661px' src='<%# Eval("ImageUrl") %>' />
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <table>
                    <tr>
                        <td style="width: 16px">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 332px">
                            <div style="width: 641px; height: 143px; background-image: url('Imagenes_Benavides/beneficios-fondo-BI.jpg')">
                                <center>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <!--<asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes_Benavides/botones/masinf-btn.png"  />-->
                                    <asp:ImageButton ID="btnBeneficios" runat="server" 
                                        ImageUrl="~/Imagenes_Benavides/botones/beneficios-btn-BI.png" 
                                        onclick="btnBeneficios_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
