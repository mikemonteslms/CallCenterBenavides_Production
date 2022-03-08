<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acceso.aspx.cs" Inherits="Portal_Benavides.Acceso" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <link href="Styles/MisEstilos.css" rel="stylesheet" type="text/css" />
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
                <br />
                <br />
                <table>
                    <tr>
                        <td align="right">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Tarjeta"
                                Font-Size="16pt" Font-Names="Arial"></asp:Label>
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
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Contraseña"
                                Font-Size="16pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtContra" runat="server" TextMode="Password" Width="290px" MaxLength="12"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td height="45px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <a href="RecuperarContraseña.aspx"><b>
                                <asp:Label ID="Label7" runat="server" Text="¿Olvidaste tu número de Tarjeta o Contraseña?"
                                    Font-Names="Arial" ForeColor="#777E7F" Font-Size="11pt" CssClass="EtiquetaGris"></asp:Label></b></a>
                            &nbsp; &nbsp; &nbsp; <a href="RegistroCliente.aspx"><b>
                                <asp:Label ID="lblRegistro" runat="server" Text="¿Aún no estas registrado?" Font-Size="11pt"
                                    ForeColor="#777E7F" Font-Bold="False" CssClass="EtiquetaGris"></asp:Label></b></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td height="25px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="right">
                            <asp:ImageButton ID="btnEntrar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/entrar-btn.png"
                                OnClick="btnEntrar_Click" />
                            <div id="dvActivaPromo" runat="server" visible="false">
                                <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"
                                    EnableScriptGlobalization="true" EnableScriptLocalization="true">
                                </asp:ScriptManager>
                                <asp:Panel ID="pnlActivaPromo" runat="server" BackImageUrl="Imagenes_Benavides/contacto-fondo.png"
                                    CssClass="panelActivaPromo">
                                    <table class="tablaActivaPromo">
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgAcivaPromo" runat="server" ImageUrl="~/Imagenes_Benavides/botones/ppActivaPromo.png"
                                                    OnClick="imgAcivaPromo_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <cc1:ModalPopupExtender ID="mpeActivaPromo" runat="server" PopupControlID="pnlActivaPromo"
                                    TargetControlID="btnEntrar" DynamicServicePath="" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                            </div>
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
