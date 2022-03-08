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

       ga('create', 'UA-73644905-1', 'auto');
       ga('send', 'pageview');

</script>
    <title>Acceso</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Styles/MisEstilos.css" rel="stylesheet" type="text/css" />    
    </head>
<body>
    <center>
        <form id="form1" runat="server">      

        <table cellpadding="0" cellspacing="0" border="0" style="border-style: none; width:1200px; height:650px; background-color: #E6E6E6; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;" >
            <tr>
            <td style="border-style: none; background-image: url('Imagenes_Benavides/MasterNueva/6-login/fondo.jpg'); background-repeat: repeat-x; height:700px;">
            <table>
            <tr>
            <td style="width:200px;"></td>
            <td>
             <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">              
                        <tr>
                            <td align="left" style="height:130px;">
                                </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <img src="Imagenes_Benavides/MasterNueva/6-login/img-login-bienvenida-420x100.png" />
                            </td>
                        </tr>
                         <tr>
                            <td style="height:40px;">
                                </td>
                        </tr>
                        <tr><td align="left">
                            <asp:Label ID="Label7" runat="server" ForeColor="#666666" Text="Recuperación de Contraseña"
                                Font-Size="22px" Font-Names="FuturaStd-Bold" ></asp:Label>
                            </td></tr>
                        <tr>
                            <td style="height:35px;">
                                </td>
                        </tr>
                        <tr>
                        <td align="left"><asp:Label ID="Label1" runat="server" ForeColor="#666666" Text="Tarjeta"
                                Font-Size="16px" Font-Names="FuturaStd-Bold"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="height:10px;">
                                </td>
                        </tr>
                        <tr><td align="left">
                            <asp:TextBox ID="txtTarjeta" runat="server" Width="300px" MaxLength="19" Height="25" Font-Names="FuturaStd-Book"></asp:TextBox>
                            </td></tr>
                        <tr>
                            <td style="height:20px;">
                                </td>
                        </tr>
                        <tr>
                        <td align="left">
                            <asp:Label ID="lblCorreoElectronico" runat="server" Font-Bold="True" ForeColor="#666666"
                                Text="Correo electrónico" Font-Size="16px" Font-Names="FuturaStd-Bold"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:10px;">
                                </td>
                        </tr>
                        <tr>
                        <td align="left"><asp:TextBox ID="txtCorreoElectronico" runat="server" Width="300px" Height="25" Font-Names="FuturaStd-Book"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                            <td style="height:40px;">
                                </td>
                        </tr>
                        <tr><td align="left"><table><tr><td>
                            <asp:ImageButton ID="btnCancelar" runat="server" 
                                ImageUrl="~/Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-regresar.jpg" 
                                OnClick="btnCancelar_Click" />
                            </td><td style="width:30px;"></td><td><asp:ImageButton ID="btnEnviar" 
                                runat="server" 
                                ImageUrl="~/Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-enviar.jpg" 
                                OnClick="btnEnviar_Click" />
                        </td></tr></table></td></tr>
                         <tr>
                            <td style="height:50px;">
                                </td>
                        </tr>
                        <tr><td align="left">                            
                        <asp:HyperLink CssClass="linksBenaRecupera" ID="HyperLink1" runat="server" Target="_blank"  NavigateUrl="~/Terminos.aspx">Términos y Condiciones</asp:HyperLink>
                            <asp:Label ID="Label2" runat="server" ForeColor="#2B347A" Font-Names="FuturaStd-Book" 
                                    Text="|"></asp:Label>
                        <asp:HyperLink CssClass="linksBenaRecupera" ID="HyperLink2" runat="server" Target="_blank" Font-Names="FuturaStd-Book"
                            Font-Size="14px" ForeColor="#2B347A" NavigateUrl="~/AvisoPrivacidad.aspx">Aviso de Privacidad</asp:HyperLink>

                            </td></tr>
                        <tr>
                            <td style="height:10px;">
                                </td>
                        </tr>
                        <tr><td align="left">
                        <asp:Label ID="Label6" runat="server" Font-Size="10px" Font-Names="FuturaStd-Book" ForeColor="#000000" Text="Copyright 2013 Farmacias Benavides. Todos los derechos reservados"></asp:Label>
                            </td></tr>
                         <tr>
                            <td style="height:20px;">
                                </td>
                        </tr>

            </table>
            </td>
            <td valign="top"><img class="style3" 
                        src="Imagenes_Benavides/MasterNueva/6-login/img-login-tarjeta-blue-400x650.png" /></td>
            <td style="width:200px;"></td>
            </tr>
            </table>
            </td>
            </tr>
        </table>


        </form>
    </center>
</body>
</html>
