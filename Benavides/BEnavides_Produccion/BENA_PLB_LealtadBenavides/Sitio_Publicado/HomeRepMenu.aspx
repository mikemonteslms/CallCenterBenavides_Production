<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeRepMenu.aspx.cs" Inherits="WebPfizer.LMS.eCard.HomeRepMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <title>Home</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
    
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <div id="fondo" style="background-image: url(Imagenes_Benavides/Index.png); width: 1010px;
            height: 756px; background-repeat: no-repeat;">
            <center>
                <table width="100%">
                    <tr>
                        <td align="right">
                            <asp:ImageButton ID="btnCerrarSesion" runat="server" ImageUrl="~/Imagenes_Benavides/botones/cerrarsesion-btn.jpg"
                                OnClick="btnCerrarSesion_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <center>
                    <table width="100%">
                        <tr>
                            <td style="background-color:White">
                                <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" BackColor="Transparent"
                                    DynamicHorizontalOffset="2" StaticSubMenuIndent="10px" Font-Overline="False"
                                    Font-Strikeout="False" Font-Underline="False" Font-Names="Arial" DynamicPopOutImageUrl="~/Imagenes_Benavides/botones/Default.png"
                                    StaticPopOutImageUrl="~/Imagenes_Benavides/botones/Default.png">
                                    <StaticMenuItemStyle HorizontalPadding="0px" VerticalPadding="0px" BackColor="Transparent"
                                        Font-Size="13px" Font-Bold="true" ForeColor="#053577" />
                                    <StaticHoverStyle BackColor="Transparent" Font-Size="13px" Font-Bold="true" ForeColor="#FF0000" />
                                    <StaticSelectedStyle />
                                    <DynamicMenuStyle CssClass="submenuEstatico1" />
                                    <DynamicMenuItemStyle HorizontalPadding="0px" VerticalPadding="0px" BackColor="#006699"
                                        ForeColor="White" Font-Size="11px" BorderStyle="Solid" BorderWidth="1px" BorderColor="#003366" />
                                    <DynamicHoverStyle BackColor="#FF0000" ForeColor="White" Font-Size="11px" BorderStyle="Solid"
                                        BorderWidth="1px" BorderColor="#BB1622" />
                                    <DynamicSelectedStyle />
                                </asp:Menu>
                            </td>
                        </tr>
                    </table>
                </center>
            </center>
        </div>
        </form>
    </center>
</body>
</html>
