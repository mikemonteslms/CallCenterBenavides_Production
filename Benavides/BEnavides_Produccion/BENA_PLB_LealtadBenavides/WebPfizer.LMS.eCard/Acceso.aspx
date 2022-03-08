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

       ga('create', 'UA-73644905-1', 'auto');
       ga('send', 'pageview');

</script>
    <script type="text/javascript">
        function ValidaSoloNumeros() {
            if ((event.keyCode < 48) || (event.keyCode > 57))
                event.returnValue = false;
        }

        function txNombres() {
            if ((event.keyCode != 32) && (event.keyCode < 65) || (event.keyCode > 90) && (event.keyCode < 97) || (event.keyCode > 122))
                event.returnValue = false;
        }
</script>
    <title>Acceso</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Styles/MisEstilos.css" rel="stylesheet" type="text/css" />     
                
    
</head>
<body>
    <center>
        <form id="form1" runat="server">       
        
            <table border="0" style="border-style: none; width:1200px; height:650px; background-color: #E6E6E6; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;" >
            <tr>
            <td style="border-style: none; background-image: url('Imagenes_Benavides/MasterNueva/6-login/fondo.jpg'); background-repeat: repeat-x; height:700px;">
            <table>
            <tr>
            <td style="width:200px;"></td>
            <td> <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">                   
                        <tr>
                            <td align="left" style="height:130px;" >
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
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="FuturaStd-Bold" 
                                    Font-Size="16px" ForeColor="#666666" Text="Tarjeta"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:10px;">
                                </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:TextBox ID="txtTarjeta" runat="server" MaxLength="11" Width="300px" 
                                    BorderWidth="0" Font-Names="FuturaStd-Book" 
                                    Height="25px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="FuturaStd-Bold" 
                                    Font-Size="16px" ForeColor="#666666" Text="Contraseña"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:10px;">
                                </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:TextBox ID="txtContra" runat="server" MaxLength="12" TextMode="Password" BorderWidth="0" Font-Names="FuturaStd-Book"
                                    Width="300px" Height="25px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:40px;">
                                </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:ImageButton ID="btnEntrar" runat="server" 
                                    ImageUrl="~/Imagenes_Benavides/MasterNueva/6-login/btn-entrar.jpg" 
                                    OnClick="btnEntrar_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height:40px;">
                                <asp:ScriptManager ID="ScriptManager1" runat="server" 
                                    EnablePartialRendering="true" EnableScriptGlobalization="true" 
                                    EnableScriptLocalization="true">
                                </asp:ScriptManager>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <table>
                                    <tr>
                                        <td>
                                <a class="linksBenaAcceso" href="RecuperarContraseña.aspx"><b>
                                <asp:Label ID="Label7" runat="server" 
                                    CssClass="linksBenaAcceso"
                                    Text="¿Olvidaste tu Contraseña?"></asp:Label>
                                </b></a>
                                        </td>
                                        <td style="width:30px;">
                                            </td>
                                        <td>
                                <a class="linksBenaAcceso" href="RegistroCliente_EncuestaInicial.aspx"><b>
                                <asp:Label ID="lblRegistro" runat="server" 
                                    CssClass="linksBenaAcceso"
                                    Text="¿Aún no estas registrado?"></asp:Label>
                                </b></a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:50px;">
                                </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:HyperLink CssClass="linksBenaRecupera" ID="HyperLink1" runat="server" 
                                    Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#2B347A" 
                                    NavigateUrl="~/Terminos.aspx" Target="_blank">Terminos y Condiciones</asp:HyperLink>
                                <asp:Label ID="Label4" runat="server" ForeColor="#2B347A" Font-Names="FuturaStd-Book" 
                                    Text="|"></asp:Label>
                                <asp:HyperLink CssClass="linksBenaRecupera" ID="HyperLink2" runat="server"  
                                    Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#2B347A" 
                                    NavigateUrl="~/AvisoPrivacidad.aspx" Target="_blank">Aviso de Privacidad</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:10px;">
                                </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label6" runat="server" Font-Size="10px" ForeColor="#000000" Font-Names="FuturaStd-Book"
                                    Text="Copyright 2013 Farmacias Benavides. Todos los derechos reservados"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px;">
                                </td>
                        </tr>
                    </table></td>
            <td valign="top"><img 
                        src="Imagenes_Benavides/MasterNueva/6-login/img-login-tarjeta-blue-400x650.png" /></td>
            <td style="width:200px;"></td>
            </tr>
            </table>
            </td>
            </tr>
            </table>   
            <div id="divPop" runat="server" visible="false">
                <asp:Panel ID="panelPop" runat="server">
    <table class="tablaSinbordes" style="width:500px;">
    <tr>
    <td align="right">
    <asp:ImageButton ID="btnCerrarPop" runat="server" 
            ImageUrl="~/Imagenes_Benavides/MasterNueva/btn-cerrar.jpg" 
            onclick="btnCerrarPop_Click" />
    </td>        
    </tr>
    </table>
    <table class="tablaSinbordes" style="background-image: url('Imagenes_Benavides/MasterNueva/23-popup_atencion/bg-contacto-500x500.png'); width:500px; height:500px;">
    <tr>
    <td valign="top">
        <table>
            <tr>
                <td style="width:30px; height:180px;">
                    </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                   </td>
                <td align="left">
                    <asp:Label ID="Label3" runat="server" Text="Atención" Font-Names="FuturaStd-Bold" 
                            Font-Size="30px" ForeColor="#FFFFFF"></asp:Label>
                   </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td style="height:20px;">
                   </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td align="left">
                    <asp:Label ID="Label5" runat="server" Font-Names="FuturaStd-Book" 
                        Font-Size="18px" ForeColor="#FFFFFF" Text="Visita tu sucursal más cercana y cambia tu tarjeta Beneficio Inteligente para disfrutar de <b>mejores beneficios</b>"></asp:Label>
                    </td>
            </tr>
        </table>
        </td>
    </tr>
    </table>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="mpePop" runat="server" PopupControlID="panelPop"
    TargetControlID="btnEntrar" DynamicServicePath="" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>            
    </div>
    <div id="divBienve" runat="server" visible="false">
     <asp:Panel ID="panelBienve" runat="server">
    <table class="tablaSinbordes" style="width:500px;">
    <tr>
    <td align="right">
    <asp:ImageButton ID="btnCerrarBienve" runat="server" 
            ImageUrl="~/Imagenes_Benavides/MasterNueva/btn-cerrar.jpg" 
            onclick="btnCerrarBienve_Click" />
    </td>        
    </tr>
    </table>
    <table class="tablaSinbordes" style="background-image: url('Imagenes_Benavides/MasterNueva/23-popup_atencion/bg-contacto-500x500.png'); width:500px; height:500px;">
    <tr>
    <td valign="top">
        <table>
            <tr>
                <td style="width:30px; height:180px;">
                    </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                   </td>
                <td align="left">
                    <asp:Label ID="Label8" runat="server" Text="Bienvenida" Font-Names="FuturaStd-Bold" 
                            Font-Size="30px" ForeColor="White"></asp:Label>
                   </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td style="height:20px;">
                   </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td align="left">
                    <asp:Label ID="Label9" runat="server" Font-Names="FuturaStd-Book" 
                        Font-Size="18px" ForeColor="White" 
                        Text="Visita tu sucursal más cercana y cambia tu tarjeta Beneficio Inteligente para disfrutar de <b>mejores beneficios</b>" 
                        Visible="False"></asp:Label>
                    </td>
            </tr>
        </table>
        </td>
    </tr>
    </table>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="mdpBienve" runat="server" PopupControlID="panelBienve"
    TargetControlID="btnEntrar" DynamicServicePath="" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>    
    </div>
        </form>
        
    </center>
</body>
</html>
