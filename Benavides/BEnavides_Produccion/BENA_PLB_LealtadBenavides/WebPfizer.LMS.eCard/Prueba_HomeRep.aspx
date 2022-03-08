<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba_HomeRep.aspx.cs"
    Inherits="WebPfizer.LMS.eCard.Prueba_HomeRep" %>

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

        ga('create', 'UA-73644905-1', 'auto');
        ga('send', 'pageview');

</script>
    <title>Home</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <div id="fondo" style="background-image: url(Imagenes_Benavides/Index.png); width: 1010px;
            height: 756px; background-repeat: no-repeat;">
            <center>
                <table class="style1">
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
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td colspan="6">
                                            <asp:Label ID="Label1" runat="server" Font-Names="Arial" ForeColor="White" Font-Size="Larger"
                                                Font-Bold="true" Text="Reportes Benavides"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 250px">
                                            &nbsp;
                                        </td>
                                        <td style="width: 300px">
                                            <asp:ImageButton ID="ReportesBenavides" runat="server" ImageUrl="~/Imagenes_Benavides/botones/network.png"
                                                OnClick="ReportesBenavides_Click" />
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 300px">
                                            <asp:ImageButton ID="RepFechaActivacion" runat="server" ImageUrl="~/Imagenes_Benavides/botones/right_top.png"
                                                OnClick="RepFechaActivacion_Click" />
                                        </td>
                                        <td style="width: 250px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Font-Names="Arial" ForeColor="White" Text="Activaciones, Ventas y Redenciones por Sucursal"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Font-Names="Arial" ForeColor="White" Text="Historial de tarjetas por Fecha de Activación"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td style="width: 350px">
                                            <asp:Menu ID="Menu1" runat="server">
                                                <Items>
                                                    <asp:MenuItem ImageUrl="~/Imagenes_Benavides/Libreta.png" 
                                                        NavigateUrl="~/ReportesBenavidesActivacion.aspx" 
                                                        PopOutImageUrl="~/Imagenes_Benavides/botones/network.png" 
                                                        Text="Activaciones, Ventas y Redenciones por Sucursal" Value="1">
                                                    </asp:MenuItem>
                                                </Items>
                                            </asp:Menu>
                                        </td>
                                        <td style="width: 300px">
                                            <asp:ImageButton ID="ImageButton1" runat="server" 
                                                ImageUrl="~/Imagenes_Benavides/botones/del.ico.us.png" onclick="ImageButton1_Click"
                                                 />
                                        </td>
                                        <td style="width: 150px">
                                        </td>
                                        <td style="width: 200px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Font-Names="Arial" ForeColor="White" Text="Reporte Cubos"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
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
