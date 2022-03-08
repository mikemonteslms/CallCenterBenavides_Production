<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportesBenavidesRep.aspx.cs"
    Inherits="Portal_Benavides.ReportesBenavidesRep" Culture="es-MX" UICulture="es-MX" %>

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

        ga('create', 'UA-73644905-1', 'auto');
        ga('send', 'pageview');

</script>
    <title>Reportes Benavides en Línea</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes_Benavides/registro-acceso-fondo-reportes.jpg"
            CssClass="imgReportes" />
        <center>
            <asp:Panel ID="Panel2" runat="server" BackImageUrl="~/Imagenes_Benavides/SaldoMov-fondo.png"
                CssClass="panelReportes">
                <table style="width: 900px; text-align: center">
                    <tr>
                        <td align="center" style="height: 50px; vertical-align: text-bottom">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSaldoTarjeta" runat="server" Text="Captura fechas: " ForeColor="#004A99"
                                            CssClass="Etiqueta" Font-Bold="True" Font-Size="12pt"></asp:Label>
                                        &nbsp&nbsp
                                        <asp:Label ID="Label3" runat="server" Text=" De " Font-Bold="True" Font-Names="Arial"
                                            ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                        <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="99999999" ValidationGroup="Fechas"></asp:TextBox>
                                        <cc1:CalendarExtender ID="ceFehaInicio" runat="server" TargetControlID="txtFechaInicio"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                        &nbsp
                                        <asp:Label ID="Label1" runat="server" Text=" a " Font-Bold="True" Font-Names="Arial"
                                            ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                        &nbsp
                                        <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaFin"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                        &nbsp &nbsp
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnReporteTransacciones" runat="server" Height="40px" ImageUrl="~/Imagenes_Benavides/botones/search.png"
                                            ToolTip="Buscar" Width="40px" ImageAlign="AbsBottom" ValidationGroup="Fechas"
                                            OnClick="btnReporteTransacciones_Click" />
                                        &nbsp &nbsp
                                    </td>
                                    <td style="border-left-color: Gray; border-left-width: 1px; border-left-style: solid"
                                        align="center">
                                        &nbsp &nbsp
                                        <asp:ImageButton ID="Exportar" runat="server" Height="40px" Width="40px" ToolTip="Exportar búsqueda a Excel"
                                            ImageUrl="~/Imagenes_Benavides/botones/Excel.png" OnClick="Exportar_Click" />
                                        &nbsp &nbsp
                                    </td>
                                    <td style="border-left-color: Gray; border-left-width: 1px; border-left-style: solid">
                                        &nbsp &nbsp
                                        <asp:ImageButton ID="btnSaldoMovRegresar" runat="server" Height="40px" Width="40px"
                                            ToolTip="Regresar" ImageUrl="~/Imagenes_Benavides/botones/undo.png" OnClick="SaldoMovRegresar_Click" />
                                    </td>
                                    <td>
                                        &nbsp
                                        <%-- <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="* Fecha de Inicio inválida"
                                                ControlToValidate="txtFechaInicio"
                                                SetFocusOnError="True" ValidationGroup="Fechas"></asp:RangeValidator>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td width="450px" align="left">
                                    </td>
                                    <td width="450px" align="left">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="97%">
                                <tr>
                                    <td style="width: 70%; text-align: center">
                                        <asp:Label ID="Label5" runat="server" Text="Activaciones, Ventas y Rendenciones por sucursal: "
                                            Font-Bold="True" Font-Names="Arial" ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                    </td>
                                    <td style="width: 20%" align="left">
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Font-Size="12px" CssClass="panelTablaReportes">
                                <br />
                                <asp:GridView ID="grvDatos" runat="server" Font-Names="Arial" CellSpacing="3"
                                    AllowPaging="True" PageSize="8000" PagerSettings-Position="Top" OnPageIndexChanging="grvActivacionesxSucursal_PageIndexChanging"
                                    EnableSortingAndPagingCallbacks="false" CssClass="gridReportes">
                                    <AlternatingRowStyle BackColor="#D2D6D9" />
                                    <HeaderStyle BackColor="#326FA6" ForeColor="White" />
                                    <PagerSettings Position="Top" />
                                </asp:GridView>
                                <asp:DataGrid ID="dgExporta" runat="server" ForeColor="#333333" CssClass="Grid" PageSize="8"
                                    UseAccessibleHeader="True" Visible="False">
                                    <HeaderStyle BackColor="#326FA6" CssClass="titulo" Font-Bold="True" ForeColor="White"
                                        Height="20px" HorizontalAlign="Left" Wrap="False" />
                                </asp:DataGrid>
                            </asp:Panel>
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
                        <img src="Imagenes_Benavides/benavides.png" />
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
