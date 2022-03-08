<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebPfizer.LMS.eCard.Home" %>

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
        <div id="fondo" style="background-image: url(Imagenes_Benavides/Index.jpg); width: 1010px;
            height: 856px; background-repeat: repeat-y;">
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
                                                ImageUrl="~/Imagenes_Benavides/botones/keyboard.png" Height="50px" 
                                                Width="50px" />
                                        </td>
                                        <td style="width: 300px">
                                            <asp:ImageButton ID="btnRecContraseña" runat="server" 
                                                ImageUrl="~/Imagenes_Benavides/botones/restart.png" 
                                                onclick="btnRecContraseña_Click" Height="50px" Width="50px" />
                                        </td>
                                        <td style="width: 300px">
                                            <asp:ImageButton ID="btnRegLlamada" runat="server" OnClick="btnRegLlamada_Click"
                                                ImageUrl="~/Imagenes_Benavides/botones/phone.png" Height="50px" 
                                                Width="50px" />
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
                                            <asp:ImageButton ID="imgSaldoCliente" runat="server" ImageUrl="~/Imagenes_Benavides/botones/info.png"
                                                OnClick="imgSaldoCliente_Click" Height="50px" Width="50px" />
                                        </td>
                                        <td style="width: 300px">
                                            <br />
                                            <asp:ImageButton ID="imgCancelaContacto" runat="server" 
                                                ImageUrl="~/Imagenes_Benavides/botones/cd.png" 
                                                onclick="imgCancelaContacto_Click" Height="50px" Width="50px"
                                                />
                                        </td>
                                        
                                        <td style="width: 300px">
                                            <br />
                                            <asp:ImageButton ID="ReportesBenavides" runat="server" ImageUrl="~/Imagenes_Benavides/botones/mouse.png"
                                                OnClick="ReportesBenavides_Click" Height="50px" Width="50px" />
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
                        <tr id="trReportes" runat="server" style="display:none">
                            <td>
                                <table>
                                    <tr>
                                        <td style="width: 50px">
                                        </td>
                                        <td style="width: 300px">
                                            <br />
                                            <a href="ReporteAsistencias.aspx"><img src="Imagenes_Benavides/botones/users1.png" height="50px" width="50px" border="0" /></a>
                                        </td>
                                        <td style="width: 300px">
                                            <br />
                                            <a href="ReporteActivacion3MesesTl.aspx"><img src="Imagenes_Benavides/botones/write.png" height="50px" width="50px" border="0" /></a>
                                        </td>                                        
                                        <td style="width: 300px">
                                            <br />
                                            <%--<a href="ReportePromociones.aspx"><img src="Images/Catalogos.png" height="50px" width="50px" border="0"></img></a> --%>
                                            <a href="ReporteActivacionXPeriodo.aspx"><img src="Imagenes_Benavides/botones/right_top.png" height="50px" width="50px" border="0"></img></a>
                                        </td>
                                        <td style="width: 50px">                                          
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Font-Names="Arial" ForeColor="White" Text="Reporte de Visitas"></asp:Label>
                                        </td>
                                        <td>                                            
                                            <asp:Label ID="Label12" runat="server" Font-Names="Arial" ForeColor="White" 
                                                Text="Reporte Activacion 3 Meses"></asp:Label>                                            
                                        </td>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Font-Names="Arial" ForeColor="White" Text="Reporte Acumulados"></asp:Label>
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
                                            <a href="ReporteReenvioMailB.aspx"><img src="Imagenes_Benavides/botones/email.png" height="50px" width="50px" border="0" /></a><br />
                                        </td>
                                        <td style="width: 300px">
                                            <br />
                                            <asp:ImageButton ID="btnEnviaCodigo" runat="server" ImageUrl="~/Imagenes_Benavides/botones/chat.png" Height="50px" Width="50px" onclick="btnEnviaCodigo_Click"/>
                                        </td>                                        
                                        <td style="width: 300px">
                                            <a href="ReporteActivacionXPeriodoTl.aspx" style="display:none" runat="server" id="aRepP"><img src="Imagenes_Benavides/botones/write1.png" height="50px" width="50px" border="0" /></a><br />                                            
                                        </td>
                                        <td style="width: 50px"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Font-Names="Arial" ForeColor="White" Text="Reenvio correo Bienvenida"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Font-Names="Arial" ForeColor="White" Text="Enviar Código SMS"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Font-Names="Arial" ForeColor="White" 
                                                Text="Reporte de Activaciones" Visible="false"></asp:Label>
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
                                        </td>
                                        <td style="width: 300px">
                                            <br />
                                        </td>
                                        
                                        <td style="width: 300px">
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
                                            &nbsp;</td>
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