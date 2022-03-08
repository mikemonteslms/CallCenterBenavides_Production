<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaldoMovClienteCallCenter.aspx.cs"
    Inherits="Portal_Benavides.SaldoMovClienteCallCenter" %>

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
    <title>Registro de Cliente</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: 756px; background-repeat: no-repeat;">
            <center>
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
                <asp:Panel ID="Panel2" runat="server" Width="650px" BackImageUrl="~/Imagenes_Benavides/SaldoMov-fondo.png"
                    Height="650px">
                    <table width="600px" align="center">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblSaldoTarjeta" runat="server" Text="Captura el No. de Tarjeta: "
                                    ForeColor="#004A99" CssClass="Etiqueta" Font-Bold="True" Font-Size="12pt"></asp:Label>
                                <asp:TextBox ID="txtSaldoTarjeta" runat="server" MaxLength="19"></asp:TextBox>
                                &nbsp &nbsp
                                <asp:ImageButton ID="btnSaldoMovBuscar" runat="server" Height="35px" ImageUrl="~/Imagenes_Benavides/botones/search.png"
                                    ToolTip="Validar Tarjeta" Width="35px" OnClick="SaldoMovBuscar_Click" ImageAlign="AbsBottom"
                                    ValidationGroup="NoTarjeta" />
                                &nbsp
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="* No. de Tarjeta Inv�lido"
                                    ControlToValidate="txtSaldoTarjeta" MaximumValue="99999999999" MinimumValue="10000000000"
                                    SetFocusOnError="True" Type="Double" ValidationGroup="NoTarjeta"></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <table>
                                                <tr>
                                                    <td width="400px" align="left">
                                                        <asp:Label ID="lblNombre" runat="server" Text="Nombre Completo: " Font-Bold="True"
                                                            Font-Names="Arial" ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                                        <asp:Label ID="lblNombreTarjeta" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                        <br />
                                                        <%--    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento: " Font-Bold="True" Font-Names="Arial"
                                                ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                            <asp:Label ID="lblFechaNacimientoTarjeta" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>--%>
                                                    </td>
                                                    <td width="250px" align="left">
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
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="500px">
                                                <tr>
                                                    <td width="200px" align="left">
                                                        <asp:Label ID="lblTelefono" runat="server" Text="Telefono: " ForeColor="#777E7F"
                                                            Font-Names="Arial"></asp:Label>
                                                        <asp:Label ID="lblSaldoMovTelefono" runat="server" Font-Names="Arial" Font-Size="12px"></asp:Label>
                                                        <br />
                                                        <asp:Label ID="lblCelular" runat="server" Text="Celular: " ForeColor="#777E7F" Font-Names="Arial"></asp:Label>
                                                        <asp:Label ID="lblSaldoCelular" runat="server" Font-Names="Arial" Font-Size="12px"></asp:Label>
                                                    </td>
                                                    <td width="300px" align="left">
                                                        <asp:Label ID="lblDireccion" runat="server" Text="Direcci�n" ForeColor="#777E7F"
                                                            Font-Names="Arial"></asp:Label>
                                                        <asp:Label ID="lblSaldoDireccion" runat="server" Font-Names="Arial" Font-Size="12px"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblCorreo" runat="server" Text="Correo electr�nico" ForeColor="#777E7F"
                                                            Font-Names="Arial"></asp:Label>&nbsp;
                                                        <asp:Label ID="lblSaldoCorreo" runat="server" Font-Names="Arial" Font-Size="12px"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="center">
                                            <asp:ImageButton ID="btnSaldoMovRegresar" runat="server" Height="30px" Width="30px"
                                                ToolTip="Regresar" ImageUrl="~/Imagenes_Benavides/botones/undo.png" OnClick="SaldoMovRegresar_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <asp:Label ID="Label5" runat="server" Text="Movimientos de la Tarjeta: " Font-Bold="True"
                                    Font-Names="Arial" ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                <br />
                                <asp:Panel ID="Panel1" runat="server" Width="640px" ScrollBars="Auto" Font-Size="12px"
                                    Height="210px">
                                    <asp:GridView ID="grvSaldoClienteCC" runat="server" Font-Names="Arial" AutoGenerateColumns="False"
                                        CellSpacing="3" Width="640px">
                                        <AlternatingRowStyle BackColor="#D2D6D9" />
                                        <Columns>
                                            <asp:BoundField DataField="Tarjeta" HeaderText="Tarjeta" />
                                            <asp:TemplateField HeaderText="Fecha">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Fecha") %>' Width="65px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Fecha") %>' Width="65px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipo de Movimiento">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("TipoMovNombre") %>' Width="100px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("TipoMovNombre") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sucursal">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("NombreSucursal") %>' Width="65px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("NombreSucursal") %>' Width="65px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Ticket" HeaderText="Ticket" />
                                            <asp:TemplateField HeaderText="Importe">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Importe") %>' Width="65px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Importe","{0:$0.00}") %>' Width="65px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Puntos" HeaderText="Puntos" />
                                            <asp:TemplateField HeaderText="Puntos en Pesos">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PesosPuntos") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("PesosPuntos","{0:$0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#326FA6" ForeColor="White" />
                                    </asp:GridView>
                                </asp:Panel>
                                <br />
                                <br />
                                <br />
                                <asp:Label ID="Label7" runat="server" Text="Lista de Llamadas: " Font-Bold="True"
                                    Font-Names="Arial" ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                <asp:Panel ID="Panel3" runat="server" Width="640px" ScrollBars="Auto" Font-Size="12px"
                                    Height="210px">
                                    <asp:GridView ID="grvListaLlamadasCC" runat="server" Font-Names="Arial" CellSpacing="3"
                                        Width="640px">
                                        <AlternatingRowStyle BackColor="#D2D6D9" />
                                        <HeaderStyle BackColor="#326FA6" ForeColor="White" />
                                    </asp:GridView>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    <table width="600px">
                        <tr>
                            <td align="right">
                                &nbsp &nbsp
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <table width="1010">
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
        </div>
        </form>
    </center>
</body>
</html>
