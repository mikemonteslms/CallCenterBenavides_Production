<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertaPromocionPorPieza.aspx.cs" Inherits="WebPfizer.LMS.eCard.InsertaPromocionPorPieza" %>
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
    <title>Inserta Promoción por Pieza</title>
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
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager></td>
                        <td style="width: 16px">
                        </td>
                        <td colspan="2" align="right">
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
                <table width="550px">
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblSkuProducto" runat="server" Font-Bold="True" 
                                ForeColor="#004A99" Text="SkuProducto"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                            <asp:TextBox ID="txtSkuProducto" runat="server" Width="150px" MaxLength="13" 
                                AutoPostBack="True" ontextchanged="txtSkuProducto_TextChanged"></asp:TextBox>
                            <asp:Label ID="lblProducto" runat="server" Visible="False" Font-Names="Arial" 
                                Font-Size="10pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblSkuObsequio" runat="server" Font-Bold="True" 
                                ForeColor="#004A99" Text="SkuObsequio"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                            <asp:TextBox ID="txtSkuObsequio" runat="server" Width="150px" MaxLength="13" 
                                AutoPostBack="True" ontextchanged="txtSkuObsequio_TextChanged"></asp:TextBox>
                            <asp:Label ID="lblObsequio" runat="server" Visible="False" Font-Names="Arial" 
                                Font-Size="10pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblFInicio" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Fecha Inicio"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                              <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="8" 
                                  Width="150px"></asp:TextBox>                                 
                                        <cc1:CalendarExtender ID="ceFehaInicio" runat="server" TargetControlID="txtFechaInicio" PopupButtonID="ImgCalendario"
                                            Format="yyyyMMdd">
                                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="ImgCalendario" runat="server" ImageUrl="~/images/Calendario.png" CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblFFin" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Fecha Fin"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                             <asp:TextBox ID="txtFechaFin" runat="server" Width="150px" 
                                 MaxLength="8"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaFin" PopupButtonID="imgCalendario2"
                                            Format="yyyyMMdd">
                                        </cc1:CalendarExtender>
                                        <asp:ImageButton ID="imgCalendario2" runat="server" ImageUrl="~/images/Calendario.png" CausesValidation="False"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblIdPromo" runat="server" Font-Bold="True" ForeColor="#004A99" Text="IdPromo"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                            <asp:TextBox ID="txtIdPromo" runat="server" Width="150px" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblCuponDescuento" runat="server" Font-Bold="True" 
                                ForeColor="#004A99" Text="CuponDescuento"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                            <asp:TextBox ID="txtCuponDescuento" runat="server" Width="150px" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblPiezasCompra" runat="server" Font-Bold="True" 
                                ForeColor="#004A99" Text="PiezasCompra"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                            <asp:TextBox ID="txtPiezasCompra" runat="server" Width="150px" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblPiezasObsequio" runat="server" Font-Bold="True" 
                                ForeColor="#004A99" Text="PiezasObsequio"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                            <asp:TextBox ID="txtPiezasObsequio" runat="server" Width="150px" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblUsuario" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Usuario"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                            <asp:TextBox ID="txtUsuario" runat="server" Width="150px" MaxLength="19" 
                                Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td style="width: 50%; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:ImageButton ID="btnCancelar" runat="server" 
                                ImageUrl="~/Imagenes_Benavides/botones/cancelar-btn.png" 
                                onclick="btnCancelar_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="btnEnviar" runat="server" 
                                ImageUrl="~/Imagenes_Benavides/botones/enviar-btn.png" 
                                onclick="btnEnviar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            &nbsp;</td>
                        <td align="center" colspan="2">
                            <br />
                            <br />
                            &nbsp &nbsp &nbsp
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
