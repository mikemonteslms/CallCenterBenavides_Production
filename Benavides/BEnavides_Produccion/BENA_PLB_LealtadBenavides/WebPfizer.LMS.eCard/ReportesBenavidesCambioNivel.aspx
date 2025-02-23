<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportesBenavidesCambioNivel.aspx.cs"
    Inherits="Portal_Benavides.ReportesBenavidesCambioNivel" Culture="es-MX" UICulture="es-MX" %>

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
    <title>Reportes Benavides en L�nea</title>
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
                                    <td valign="middle">
                                        <br />
                                        <asp:Label ID="lblSaldoTarjeta" runat="server" Text="Cambio de Nivel por Periodo: "
                                            ForeColor="#004A99" CssClass="Etiqueta" Font-Bold="True" Font-Size="12pt"></asp:Label>
                                        &nbsp
                                        <asp:DropDownList ID="ddlReporte" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReporte_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Selected="True">--Selecciona--</asp:ListItem>
                                            <asp:ListItem Value="1">201501</asp:ListItem>
                                            <asp:ListItem Value="2">201502</asp:ListItem>
                                            <asp:ListItem Value="3">201503</asp:ListItem>
                                            <asp:ListItem Value="4">201504</asp:ListItem>
                                            <asp:ListItem Value="5">201505</asp:ListItem>
                                            <asp:ListItem Value="6">201506</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
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
                                    <td>
                                    </td>
                                    <td style="width: 70%; text-align: left">
                                        <asp:Label ID="Label1" runat="server" Text="Descripci�n:" Font-Bold="True" Font-Names="Arial"
                                            ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                        <br />
                                        <br />
                                        <asp:Label ID="Label5" runat="server" Text="Este reporte muestra: Detalle de las tarjetas que han cambiado de nivel."
                                            Font-Names="Arial" ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                        <br />
                                    </td>
                                    <td style="width: 20%" align="left">
                                        <table>
                                            <tr>
                                                <td align="center">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="btnBuscar" runat="server" Height="40px" ImageUrl="~/Imagenes_Benavides/botones/search.png"
                                                        ToolTip="Mostrar en Pantalla" Width="40px" ImageAlign="AbsBottom" ValidationGroup="Fechas"
                                                        OnClick="btnBuscar_Click" />
                                                    &nbsp&nbsp
                                                </td>
                                                <td style="border-left-color: Gray; border-left-width: 1px; border-left-style: solid">
                                                    &nbsp&nbsp
                                                    <asp:ImageButton ID="Exportar" runat="server" Height="40px" Width="40px" ToolTip="Exportar a Excel"
                                                        ImageUrl="~/Imagenes_Benavides/botones/Excel.png" OnClick="Exportar_Click" />
                                                    &nbsp&nbsp
                                                </td>
                                                <td style="border-left-color: Gray; border-left-width: 1px; border-left-style: solid">
                                                    &nbsp&nbsp
                                                    <asp:ImageButton ID="btnSaldoMovRegresar" runat="server" Height="40px" Width="40px"
                                                        ToolTip="Regresar" ImageUrl="~/Imagenes_Benavides/botones/undo.png" OnClick="SaldoMovRegresar_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Font-Size="12px" CssClass="panelTablaReportes">
                                <br />
                                <br />
                                <%--<asp:Label ID="lblMensajeTOP" runat="server" Text="En pantalla se visualizan solo 1000 l�neas equivalentes a los �ltimos d�as, para visualizar todo el reporte debes descargarlo."
                                    Font-Names="Arial" ForeColor="#999999" Font-Size="10pt" Visible="false"></asp:Label>--%>
                                <asp:GridView ID="grvDatos" runat="server" Font-Names="Arial" CellSpacing="3" AllowPaging="True"
                                    PageSize="500" PagerSettings-Position="Top" EnableSortingAndPagingCallbacks="false"
                                    CssClass="gridReportes" OnPageIndexChanging="grvDatos_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="#D2D6D9" />
                                    <HeaderStyle BackColor="#326FA6" ForeColor="White" />
                                    <PagerSettings Position="Top" />
                                </asp:GridView>
                                <br />
                                <br />
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
