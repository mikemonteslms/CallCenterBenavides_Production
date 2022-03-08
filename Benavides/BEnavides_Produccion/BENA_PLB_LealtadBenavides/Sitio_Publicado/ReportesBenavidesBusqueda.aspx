<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportesBenavidesBusqueda.aspx.cs"
    Inherits="Portal_Benavides.ReportesBenavidesBusqueda" Culture="es-MX" UICulture="es-MX" %>

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
        <asp:Panel ID="Panel2" runat="server" Width="980px" BackImageUrl="~/Imagenes_Benavides/SaldoMov-fondo.png"
                    Height="990px">
                    <table width="850px" align="center">
                        <tr>
                            <td align="center">
                                <table>
                                    <tr>
                                        <td style="vertical-align:middle; margin-left: 40px;">
                                        </td>
                                        <td>
                                            &nbsp&nbsp&nbsp
                                            <asp:Label ID="lblSaldoTarjeta" runat="server" Text="Captura el No. de Tarjeta: "
                                                ForeColor="#004A99" CssClass="Etiqueta" Font-Bold="True" Font-Size="12pt"></asp:Label>
                                            <asp:TextBox ID="txtTarjeta" runat="server" MaxLength="19"></asp:TextBox>
                                            &nbsp &nbsp
                                        </td>
                                        <td align="center" style="border-right-color: Gray; border-right-width: 1px; border-right-style: solid">
                                            <asp:ImageButton ID="btnReporteTransacciones" runat="server" Height="24px" ImageUrl="~/Imagenes_Benavides/botones/search.png"
                                                ToolTip="Transacciones" Width="29px" ImageAlign="AbsBottom" ValidationGroup="NoTarjeta"
                                                OnClick="btnReporteTransacciones_Click" />
                                            &nbsp &nbsp&nbsp&nbsp&nbsp
                                            <br />
                                            <span style="font-family: Arial; font-size: 12px; color: Gray">Transacciones</span>
                                            &nbsp &nbsp&nbsp&nbsp&nbsp
                                        </td>
                                        <td>
                                            &nbsp&nbsp&nbsp&nbsp&nbsp
                                            <asp:ImageButton ID="btnReporteClientes" runat="server" Height="24px" ImageUrl="~/Imagenes_Benavides/botones/search.png"
                                                ToolTip="Clientes" Width="29px" ImageAlign="AbsBottom" ValidationGroup="NoTarjeta"
                                                OnClick="btnReporteClientes_Click" />
                                            <br />
                                            &nbsp&nbsp&nbsp&nbsp&nbsp <span style="font-family: Arial; font-size: 12px; color: Gray">
                                                Clientes</span>
                                        </td>
                                        <td>
                                            &nbsp
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="* No. de Tarjeta Inválido"
                                                ControlToValidate="txtTarjeta" MaximumValue="99999999999" MinimumValue="10000000000"
                                                SetFocusOnError="True" Type="Double" ValidationGroup="NoTarjeta"></asp:RangeValidator>
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
                                            <asp:Label ID="lblNombre" runat="server" Text="Nombre Completo: " Font-Bold="True"
                                                Font-Names="Arial" ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                            <asp:Label ID="lblNombreTarjeta" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                            <br />
                                            <%--    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento: " Font-Bold="True" Font-Names="Arial"
                                                ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                            <asp:Label ID="lblFechaNacimientoTarjeta" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>--%>
                                        </td>
                                        <td width="450px" align="left">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="220px" align="left">
                                                        &nbsp &nbsp
                                                        <asp:Label ID="lblNivel" runat="server" Text="Nivel: " Font-Bold="True" Font-Names="Arial"
                                                            ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                                        <asp:Label ID="lblNivelTarjeta" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                        <br />
                                                        &nbsp &nbsp
                                                        <asp:Label ID="lblSaldo" runat="server" Text="Saldo: " Font-Bold="True" Font-Names="Arial"
                                                            ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                                        <asp:Label ID="lblSaldoMovTarjeta" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                    </td>
                                                    <td width="220px" align="left">
                                                        &nbsp &nbsp
                                                        <asp:Label ID="lblEstatus" runat="server" Text="Estatus: " Font-Bold="True" Font-Names="Arial"
                                                            ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                                        <asp:Label ID="lblEstatusTarjeta" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                        <br />
                                                        &nbsp &nbsp
                                                        <asp:Label ID="lblWEB" runat="server" Text="Activación WEB: " Font-Bold="True" Font-Names="Arial"
                                                            ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                                        <asp:Label ID="lblFechaWEB" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table width="900px">
                                    <tr>
                                        <td>
                                            <table width="700px">
                                                <tr>
                                                    <td width="250px" align="left">
                                                        <asp:Label ID="lblTelefono" runat="server" Text="Telefono: " ForeColor="#777E7F"
                                                            Font-Names="Arial"></asp:Label>
                                                        <asp:Label ID="lblSaldoMovTelefono" runat="server" Font-Names="Arial" Font-Size="12px"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="lblCelular" runat="server" Text="Celular: " ForeColor="#777E7F" Font-Names="Arial"></asp:Label>
                                                        <asp:Label ID="lblSaldoCelular" runat="server" Font-Names="Arial" Font-Size="12px"></asp:Label>
                                                    </td>
                                                    <td width="450px" align="left">
                                                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección" ForeColor="#777E7F"
                                                            Font-Names="Arial"></asp:Label>
                                                        <asp:Label ID="lblSaldoDireccion" runat="server" Font-Names="Arial" Font-Size="12px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblCorreo" runat="server" Text="Correo electrónico" ForeColor="#777E7F"
                                                            Font-Names="Arial"></asp:Label>&nbsp;
                                                        <asp:Label ID="lblSaldoCorreo" runat="server" Font-Names="Arial" Font-Size="12px"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:ImageButton ID="Exportar" runat="server" Height="30px" Width="30px" ToolTip="ExportarExcel"
                                                            ImageUrl="~/Imagenes_Benavides/botones/Excel.png" OnClick="Exportar_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="btnSaldoMovRegresar" runat="server" Height="30px" Width="30px"
                                                            ToolTip="Regresar" ImageUrl="~/Imagenes_Benavides/botones/undo.png" OnClick="SaldoMovRegresar_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <asp:Label ID="lblTituloGrid" runat="server" Text="" Font-Bold="True" Font-Names="Arial"
                                    ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                <br />
                                <asp:Panel ID="Panel1" runat="server" Width="950px" ScrollBars="Auto" Font-Size="12px"
                                    Height="750px">
                                    <asp:GridView ID="grvDatos" runat="server" Font-Names="Arial" CellSpacing="3" Width="950px">
                                        <AlternatingRowStyle BackColor="#D2D6D9" />
                                        <HeaderStyle BackColor="#326FA6" ForeColor="White" />
                                    </asp:GridView>
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
