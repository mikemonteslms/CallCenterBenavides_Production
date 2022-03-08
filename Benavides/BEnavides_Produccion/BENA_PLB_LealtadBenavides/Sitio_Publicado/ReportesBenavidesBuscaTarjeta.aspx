<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportesBenavidesBuscaTarjeta.aspx.cs"
    Inherits="Portal_Benavides.ReportesBenavidesBuscaTarjeta" Culture="es-MX" UICulture="es-MX" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="javascript" type="text/javascript">

</script>
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
    <title>Reportes Benavides en Línea</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Styles/MisEstilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes_Benavides/registro-acceso-fondo-reportes.jpg"
            CssClass="imgReportes" />
        <center>
            <asp:Panel ID="Panel2" runat="server" Width="1010px" BackImageUrl="~/Imagenes_Benavides/SaldoMov-fondo.png"
                Height="500px">
                <table width="990px" align="left">
                    <tr>
                        <td align="left" valign="middle">
                            &nbsp &nbsp
                            <asp:Label ID="Label1" runat="server" Text="Captura: " ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="12pt"></asp:Label>
                        </td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="700px">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblTarjeta" runat="server" Text="Tarjeta: " ForeColor="#004A99" CssClass="Etiqueta"
                                            Font-Bold="False" Font-Size="10pt"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label8" runat="server" Text="Sucursal: " ForeColor="#004A99" CssClass="Etiqueta"
                                            Font-Bold="False" Font-Size="10pt"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label9" runat="server" Text="Fecha de compra: " ForeColor="#004A99" CssClass="Etiqueta"
                                            Font-Bold="False" Font-Size="10pt"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        &nbsp&nbsp&nbsp&nbsp
                                        <asp:TextBox ID="txtTarjeta" runat="server" MaxLength="4" Font-Size="10pt" ToolTip="Captura los ultimos 4 digitos de la tarjeta">Ultimos 4 dígitos</asp:TextBox>
                                        &nbsp&nbsp
                                    </td>
                                    <td align="center">
                                        &nbsp&nbsp
                                        <asp:TextBox ID="txtSucursal" runat="server" MaxLength="4" Font-Size="10pt"></asp:TextBox>
                                        &nbsp&nbsp
                                    </td>
                                    <td align="center">
                                        &nbsp&nbsp
                                        <asp:DropDownList ID="ddlMes" runat="server" Font-Size="10pt">
                                        </asp:DropDownList>
                                        &nbsp
                                        <asp:DropDownList ID="ddlAño" runat="server" Font-Size="10pt">
                                        </asp:DropDownList>
                                        &nbsp&nbsp&nbsp&nbsp
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="center" style="border-right-color: Gray; border-right-width: 1px; border-right-style: solid">
                            <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/search.png"
                                ToolTip="Transacciones" Width="43px" Height="43px" OnClick="btnBuscar_Click" />
                            &nbsp &nbsp &nbsp
                        </td>
                        <td>
                            &nbsp &nbsp &nbsp
                            <asp:ImageButton ID="btnSaldoMovRegresar" runat="server" Height="43px" Width="43px"
                                ToolTip="Regresar" ImageUrl="~/Imagenes_Benavides/botones/undo.png" OnClick="SaldoMovRegresar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="center">
                            <br />
                            <asp:Label ID="lblTituloGrid" runat="server" Text="" Font-Bold="True" Font-Names="Arial"
                                ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                            <br /> <br />
                           
                            <asp:Panel ID="Panel1" runat="server" Width="400px" ScrollBars="Auto" Font-Size="12px"
                                Height="250px">
                                <asp:GridView ID="grvDatos" runat="server" Font-Names="Arial" CellSpacing="3" Width="250px">
                                    <AlternatingRowStyle BackColor="#D2D6D9" />
                                    <HeaderStyle BackColor="#326FA6" ForeColor="White" />
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <table width="1010px">
                <tr>
                    <td style="width: 20px">
                    </td>
                    <td align="left">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Target="_blank" Font-Names="Arial"
                            Font-Size="8pt" ForeColor="#004A99" NavigateUrl="~/Terminos.aspx">Terminos y Condiciones</asp:HyperLink>
                        <asp:Label ID="Label4" runat="server" Text="|" Font-Bold="True" ForeColor="#004A99"></asp:Label>
                        <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Target="_blank" Font-Names="Arial"
                            Font-Size="8pt" ForeColor="#004A99" NavigateUrl="~/AvisoPrivacidad.aspx">Aviso de Privacidad</asp:HyperLink>
                    </td>
                    <td style="width: 106px" align="right">
                        <img src="Imagenes_Benavides/benavides.png" alt="" />
                    </td>
                    <td style="width: 60px">
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
        </center>
        </form>
    </center>
</body>
</html>
