<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContraseña.aspx.cs"
    Inherits="Portal_Benavides.RecuperarContraseña" %>

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
    <title>Acceso</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <div id="fondo" style="background-image: url(Imagenes_Benavides/registro-acceso-fondo.jpg);
            width: 1010px; height: 756px; background-repeat: no-repeat;">
            <center>
                <table style="width: 1020px">
                    <tr>
                        <td style="width: 60px; height: 50px">
                        </td>
                        <td style="width: 20px">
                        </td>
                        <td style="width: 100px">
                            &nbsp;
                        </td>
                        <td style="width: 16px">
                            &nbsp;
                        </td>
                        <td colspan="2" align="right">
                            <img src="Imagenes_Benavides/logo-benavides.png" alt="" />
                        </td>
                        <td style="width: 60px">
                        </td>
                    </tr>
                </table>
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
                <br />
                <table>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Recuperación de Contraseña"
                                Font-Size="16pt" Font-Names="Arial"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Tarjeta"
                                Font-Size="13pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTarjeta" runat="server" Width="290px" MaxLength="19"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td height="25px">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblCorreoElectronico" runat="server" Font-Bold="True" ForeColor="#004A99"
                                Text="Correo electrónico" Font-Size="13pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCorreoElectronico" runat="server" Width="290px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td height="25px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <span style="font-family: Arial; font-size: 12px; color: #004A99">Nota: La información
                                registrada se validara con los datos de tarjeta registrados previamente</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="right">
                            <br />
                            <br />
                            <br />
                            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/cancelar-btn.png"
                                ToolTip="Cancelar" OnClick="btnCancelar_Click" />
                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                            <asp:ImageButton ID="btnEnviar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/enviar-btn.png"
                                ToolTip="Da clic para enviar Contraseña" OnClick="btnEnviar_Click" />
                        </td>
                    </tr>
                </table>
            </center>
            <br />
            <br />
            <br />
            <br />
            <br />
            <table width="1010">
                <tr>
                    <td style="width: 20px">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px">
                    </td>
                    <td align="center">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Target="_blank" Font-Names="Arial"
                            Font-Size="8pt" ForeColor="#004A99" NavigateUrl="~/Terminos.aspx">Terminos y Condiciones</asp:HyperLink>
                        <asp:Label ID="Label4" runat="server" Text="|" Font-Bold="True" ForeColor="#004A99"></asp:Label>
                        <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Target="_blank" Font-Names="Arial"
                            Font-Size="8pt" ForeColor="#004A99" NavigateUrl="~/AvisoPrivacidad.aspx">Aviso de Privacidad</asp:HyperLink>
                    </td>
                    <td style="width: 20px">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="3" align="center">
                        <asp:Label ID="Label6" runat="server" Font-Size="8pt" ForeColor="Silver" Text="Copyright 2013 Farmacias Benavides. Todos los derechos reservados"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </center>
</body>
</html>
