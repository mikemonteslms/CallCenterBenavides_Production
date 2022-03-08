<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebPfizer.LMS.eCard.Home" %>

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
                                        <td style="width: 50px">
                                        </td>
                                        <td style="width: 300px">
                                            <asp:ImageButton ID="btnRegCliente" runat="server" OnClick="btnRegCliente_Click"
                                                ImageUrl="~/Imagenes_Benavides/botones/keyboard.png" Height="100px" 
                                                Width="100px" />
                                        </td>
                                        <td style="width: 300px">
                                            <asp:ImageButton ID="btnRecContraseña" runat="server" 
                                                ImageUrl="~/Imagenes_Benavides/botones/restart.png" 
                                                onclick="btnRecContraseña_Click" Height="100px" Width="100px" />
                                        </td>
                                        <td style="width: 300px">
                                            <asp:ImageButton ID="btnRegLlamada" runat="server" OnClick="btnRegLlamada_Click"
                                                ImageUrl="~/Imagenes_Benavides/botones/phone.png" Height="100px" 
                                                Width="100px" />
                                        </td>
                                        <td style="width: 50px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Font-Names="Arial" ForeColor="White" Text="Registrar Cliente"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Font-Names="Arial" ForeColor="White" Text="Recuperar Contraseña"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Font-Names="Arial" ForeColor="White" Text="Registrar LLamada"></asp:Label>
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
                                        <td style="width: 50px">
                                        </td>
                                        <td style="width: 300px">
                                            <br />
                                            <br />
                                            <br />
                                            <asp:ImageButton ID="imgSaldoCliente" runat="server" ImageUrl="~/Imagenes_Benavides/botones/info.png"
                                                OnClick="imgSaldoCliente_Click" Height="100px" Width="100px" />
                                        </td>
                                        <td style="width: 300px">
                                            <br />
                                            <br />
                                            <br />
                                            <asp:ImageButton ID="imgCancelaContacto" runat="server" 
                                                ImageUrl="~/Imagenes_Benavides/botones/cd.png" 
                                                onclick="imgCancelaContacto_Click" Height="100px" Width="100px"
                                                />
                                        </td>
                                        
                                        <td style="width: 300px">
                                            <br />
                                            <br />
                                            <br />
                                            <asp:ImageButton ID="ReportesBenavides" runat="server" ImageUrl="~/Imagenes_Benavides/botones/mouse.png"
                                                OnClick="ReportesBenavides_Click" Height="100px" Width="100px" />
                                        </td>
                                        <td style="width: 50px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Font-Names="Arial" ForeColor="White" Text="Saldo Cliente"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Font-Names="Arial" ForeColor="White" Text="Cancela Contacto"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Font-Names="Arial" ForeColor="White" Text="Reportes Benavides"></asp:Label>
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
                                        <td style="width: 50px">
                                        </td>
                                        <td style="width: 300px">
                                            <br />
                                            <br />
                                            <br />
                                        </td>
                                        <td style="width: 300px">
                                            <br />
                                            <br />
                                            <br />
                                            <asp:ImageButton ID="btnEnviaCodigo" runat="server" 
                                                ImageUrl="~/Imagenes_Benavides/botones/chat.png" 
                                                 Height="100px" Width="100px" onclick="btnEnviaCodigo_Click"
                                                />
                                        </td>
                                        
                                        <td style="width: 300px">
                                            <br />
                                            <br />
                                            <br />
                                        </td>
                                        <td style="width: 50px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Font-Names="Arial" ForeColor="White" 
                                                Text="Enviar Código SMS"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
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
