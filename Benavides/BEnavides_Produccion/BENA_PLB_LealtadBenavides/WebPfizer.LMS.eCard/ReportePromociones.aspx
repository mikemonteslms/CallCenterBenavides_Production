<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportePromociones.aspx.cs" Inherits="WebPfizer.LMS.eCard.ReportePromociones" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <title>Registro de Promociones</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
<center>
    <form id="form1" runat="server">    
        <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: 756px; background-repeat: no-repeat;">
            <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            <asp:Panel ID="Panel2" runat="server" BackImageUrl="~/Imagenes_Benavides/SaldoMov-fondo.png"
                    Height="600px" CssClass="panelReportes">
                <table>
                    <tr>
                        <td></td>
                        <td>Número de Tarjeta:</td>
                        <td><asp:TextBox ID="txtTarjeta" runat="server"></asp:TextBox></td>
                        <td><asp:ImageButton ID="btnSaldoMovBuscar" runat="server" Height="35px" ImageUrl="~/Imagenes_Benavides/botones/search.png"
                                    ToolTip="Validar Tarjeta" Width="35px" ImageAlign="AbsBottom" 
                                onclick="btnSaldoMovBuscar_Click" />&nbsp;&nbsp;<a href="Home.aspx"><img src="Imagenes_Benavides/botones/undo.png" Height="30px" Width="30px" border="0"/></a>
                                </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="gvwResultado" runat="server"></asp:GridView>    
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</center>
</body>
</html>
