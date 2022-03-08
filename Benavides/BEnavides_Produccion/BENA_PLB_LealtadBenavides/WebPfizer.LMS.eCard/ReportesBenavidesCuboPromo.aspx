<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportesBenavidesCuboPromo.aspx.cs"
    Inherits="Portal_Benavides.ReportesBenavidesCuboPromo" Culture="es-MX" UICulture="es-MX" %>

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
                            <table width="95%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMensaje" runat="server" Text="Selecciona las opciones deseadas para visualizar la información en pantalla"
                                            ForeColor="#004A99" CssClass="Etiqueta" Font-Bold="True" Font-Size="12pt"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnRegresar" runat="server" Height="40px" Width="40px" ToolTip="Regresar"
                                            ImageUrl="~/Imagenes_Benavides/botones/undo.png" OnClick="Regresar_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server" Width="95%" ScrollBars="Auto" Font-Size="12px"
                                Height="400px" align="left">
                            <object classid="clsid:0002E552-0000-0000-C000-000000000046" id="PivotTableDeprecated1">
  <param name="XMLData" value="&lt;xml xmlns:x=&quot;urn:schemas-microsoft-com:office:excel&quot;&gt;
 &lt;x:PivotTable&gt;
  &lt;x:OWCVersion&gt;10.0.0.6854         &lt;/x:OWCVersion&gt;
  &lt;x:DisplayScreenTips/&gt;
  &lt;x:CubeProvider&gt;msolap.2&lt;/x:CubeProvider&gt;
  &lt;x:CacheDetails/&gt;
  &lt;x:ConnectionString&gt;Provider=MSOLAP.4;Persist Security Info=True;User ID=cibanez;Initial Catalog=CuboPromociones;Data Source=http://67.192.9.19/OLAP/msmdpump.dll&lt;/x:ConnectionString&gt;
  &lt;x:DataMember&gt;DSWCuboPromociones&lt;/x:DataMember&gt;
  &lt;x:PivotView&gt;
   &lt;x:IsNotFiltered/&gt;
  &lt;/x:PivotView&gt;
 &lt;/x:PivotTable&gt;
&lt;/xml&gt;">
  <table width='100%' cellpadding='0' cellspacing='0' border='0' height='8'><tr><td bgColor='#336699' height='25' width='10%'>&nbsp;</td><td bgColor='#666666'width='85%'><font face='Tahoma' color='white' size='4'><b>&nbsp; Faltan: Microsoft Office Web Components</b></font></td></tr><tr><td bgColor='#cccccc' width='15'>&nbsp;</td><td bgColor='#cccccc' width='500px'><br> <font face='Tahoma' size='2'>Esta página requiere Microsoft Office Web Components.<p align='center'> <a href='files/owc/setup.exe'>Haga clic aquí para instalar Microsoft Office Web Components.</a>.</p></font><p><font face='Tahoma' size='2'>Esta página también requiere Microsoft Internet Explorer versión 4.01 (SP-1) o posterior.</p><p align='center'><a href='http://www.microsoft.com/windows/ie/default.htm'> Haga clic aquí para instalar la última versión de Internet Explorer</a>.</font><br>&nbsp;</td></tr></table></object>
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
