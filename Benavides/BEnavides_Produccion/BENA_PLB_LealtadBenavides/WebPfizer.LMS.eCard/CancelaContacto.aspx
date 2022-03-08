<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelaContacto.aspx.cs"
    Inherits="Portal_Benavides.CancelaContacto" %>

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
                        </td>
                        <td style="width: 16px">
                        </td>
                        <td colspan="2" align="right">
                            <img src="Imagenes_Benavides/logo-benavides.png" />
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
                <table width="550px">
                    <tr>
                        <td align="right" style="width: 20%">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Tarjeta"
                                Font-Size="16pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                            <asp:TextBox ID="txtTarjeta" runat="server" Width="200px" MaxLength="19"></asp:TextBox>
                            &nbsp
                            <asp:Button ID="btnValidar" runat="server" Text="Validar Tarjeta" Visible="false"
                                OnClick="btnValidar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <br />
                            <table width="100%">
                                <tr>
                                    <td colspan="2" align="left" style="width: 60%">
                                        &nbsp;</td>
                                    <td align="left">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left" style="width: 60%">
                                        &nbsp
                                        <asp:Label ID="Label2" runat="server" ForeColor="#004A99" Text="Selecciona donde deseas recibir información:"
                                            Font-Size="11pt" Font-Names="Arial"></asp:Label>
                                    </td>
                                    <td align="left">
                                        &nbsp &nbsp
                                        <asp:Label ID="Label3" runat="server" ForeColor="#004A99" Text="Motivo:" Font-Size="11pt"
                                            Font-Names="Arial"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 30%">
                                        &nbsp <span style="color: Black; font-size: 11pt; font-family: Arial">Correo Electrónico</span>
                                        <br />
                                        &nbsp <span style="color: Black; font-size: 11pt; font-family: Arial">Celular</span>
                                        <br />
                                        &nbsp <span style="color: Black; font-size: 11pt; font-family: Arial">Teléfono Particular</span>
                                        <br />
                                        &nbsp <span style="color: Black; font-size: 11pt; font-family: Arial">Correo Postal</span>
                                        <br />
</td>
                                    <td align="left">
                                        <asp:RadioButtonList ID="rdoCorreoE" runat="server" ForeColor="Black" Font-Size="11pt"
                                            Font-Names="Arial" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Value="1">Sí</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                        <asp:RadioButtonList ID="rdoCelular" runat="server" ForeColor="Black" Font-Size="11pt"
                                            Font-Names="Arial" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Value="1">Sí</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                        <asp:RadioButtonList ID="rdoTelPart" runat="server" ForeColor="Black" Font-Size="11pt"
                                            Font-Names="Arial" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Value="1">Sí</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                        <asp:RadioButtonList ID="rdoCorreoP" runat="server" ForeColor="Black" Font-Size="11pt"
                                            Font-Names="Arial" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Value="1">Sí</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtMotivo" runat="server" Width="200px" MaxLength="500" Rows="5"
                                            TextMode="MultiLine" ForeColor="Black" Font-Size="11pt" Font-Names="Arial"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <br />
                            <br />
                            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/cancelar-btn.png"
                                OnClick="btnCancelar_Click" />
                            &nbsp &nbsp &nbsp
                            <asp:ImageButton ID="btnEnviar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/enviar-btn.png"
                                OnClick="btnEnviar_Click" Enabled="false" />
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
