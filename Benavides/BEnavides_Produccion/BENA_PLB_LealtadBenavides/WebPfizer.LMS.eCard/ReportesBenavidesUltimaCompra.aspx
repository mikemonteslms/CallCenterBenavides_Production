<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportesBenavidesUltimaCompra.aspx.cs"
    Inherits="Portal_Benavides.ReportesBenavidesUltimaCompra" Culture="es-MX" UICulture="es-MX" %>

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
            <asp:Panel ID="Panel2" runat="server" BackImageUrl="~/Imagenes_Benavides/SaldoMov-fondo.png"
                CssClass="panelReportes">
                <table style="width: 900px; text-align: center">
                    <tr>
                        <td align="center" style="height: 50px; vertical-align: text-bottom">
                            <table>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:Label ID="lblTitulo" runat="server" Text="Reporte Última Compra" ForeColor="#004A99"
                                            CssClass="Etiqueta" Font-Bold="True" Font-Size="12pt"></asp:Label>
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
                                        <asp:Label ID="Label1" runat="server" Text="Descripción:" Font-Bold="True" Font-Names="Arial"
                                            ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                        &nbsp
                                        <asp:Label ID="lblDescripcion" runat="server" Text="Este reporte muestra el comportamiento por segmento de las últimas compras realizadas de acuerdo a los periodos enlistados."
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
                                                    <asp:ImageButton ID="btnExportar" runat="server" Height="40px" Width="40px" ToolTip="Exportar a Excel"
                                                        ImageUrl="~/Imagenes_Benavides/botones/Excel.png" OnClick="bntExportar_Click" />
                                                    &nbsp&nbsp
                                                </td>
                                                <td style="border-left-color: Gray; border-left-width: 1px; border-left-style: solid">
                                                    &nbsp&nbsp
                                                    <asp:ImageButton ID="btnRegresar" runat="server" Height="40px" Width="40px" ToolTip="Regresar"
                                                        ImageUrl="~/Imagenes_Benavides/botones/undo.png" OnClick="btnRegresar_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Font-Size="12px" CssClass="panelTablaReportes">
                                <br />
                                <br />
                                <asp:Label ID="lblMensaje" runat="server" Font-Names="Arial" ForeColor="#999999"
                                    Font-Size="10pt" Visible="false"></asp:Label>
                                <asp:GridView ID="grvCasosInusuales" runat="server" Font-Names="Arial" CellSpacing="3"
                                    Visible="false" CssClass="gridReportes">
                                    <AlternatingRowStyle BackColor="#D2D6D9" />
                                    <HeaderStyle BackColor="#326FA6" ForeColor="White" />
                                </asp:GridView>
                                <asp:DataGrid ID="dgCasosInusuales" runat="server" CellPadding="4" HorizontalAlign="Left"
                                    Width="1px" ForeColor="#333333" CssClass="Grid" PageSize="8" CellSpacing="1"
                                    Height="0px" UseAccessibleHeader="True" Visible="False">
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <EditItemStyle BackColor="#999999" HorizontalAlign="Left" Wrap="False" />
                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left"
                                        Wrap="False" />
                                    <PagerStyle BackColor="#284775" CssClass="titulo" ForeColor="White" Height="15px"
                                        HorizontalAlign="Center" NextPageText="Siguiente &amp;gt;" PrevPageText="&amp;lt; Anterior"
                                        Mode="NumericPages" Visible="False" />
                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" HorizontalAlign="Left"
                                        Wrap="False" />
                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" Wrap="False" />
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
