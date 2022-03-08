<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SaldoMovClienteCallCenter.aspx.cs"
    Inherits="Portal_Benavides.SaldoMovClienteCallCenter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title>Registro de Cliente</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
    <center>
        
        <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: auto; background-repeat: no-repeat;">

            <center>
                <br />
                <br />
                   <asp:Panel ID="Panel2" runat="server" Height="600px" CssClass="panelReportes">
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
                                <asp:ImageButton ID="btnSaldoMovRegresar" runat="server" Height="30px" 
                                    ImageUrl="~/Imagenes_Benavides/botones/undo.png" 
                                    OnClick="SaldoMovRegresar_Click" ToolTip="Regresar" Width="30px" Visible="false" />
                                &nbsp
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="* No. de Tarjeta Inválido"
                                    ControlToValidate="txtSaldoTarjeta" MaximumValue="99999999999" MinimumValue="10000000000"
                                    SetFocusOnError="True" Type="Double" ValidationGroup="NoTarjeta"></asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td width="300px" align="left">
                                                        <asp:Label ID="lblNombre" runat="server" Text="Nombre: " Font-Bold="True"
                                                            Font-Names="Arial" ForeColor="#004A99" Font-Size="10pt"></asp:Label><asp:Label ID="lblNombreTarjeta" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                        
                                                        <br />
                                                        <asp:Label ID="lblTelefono" runat="server" Font-Bold="True"
                                                            Font-Names="Arial" ForeColor="#004A99" Font-Size="10pt" Text="Telefono: "></asp:Label>
                                                            <asp:Label ID="lblSaldoMovTelefono" runat="server" Font-Names="Arial" 
                                                            Font-Size="12px"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblCelular" runat="server" Font-Bold="True"
                                                            Font-Names="Arial" ForeColor="#004A99" Font-Size="10pt" Text="Celular: "></asp:Label><asp:Label ID="lblSaldoCelular" runat="server" Font-Names="Arial" 
                                                            Font-Size="12px"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblCorreo" runat="server" Text="Correo electrónico: " Font-Bold="True"
                                                            Font-Names="Arial" ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                                            <asp:Label ID="lblSaldoCorreo" runat="server" Font-Names="Arial" Font-Size="12px"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDireccion" runat="server" Font-Bold="True"
                                                            Font-Names="Arial" ForeColor="#004A99" Font-Size="10pt" Text="Dirección: " 
                                                            Visible="False"></asp:Label><asp:Label ID="lblSaldoDireccion" 
                                                            runat="server" Font-Names="Arial" 
                                                            Font-Size="12px" Visible="False"></asp:Label>
                                                        <%--    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento: " Font-Bold="True" Font-Names="Arial"
                                                ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                            <asp:Label ID="lblFechaNacimientoTarjeta" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>--%>
                                                    </td>
                                                    <td width="400px" align="left">
                                                        &nbsp &nbsp
                                                        <asp:Label ID="lblNivel" runat="server" Text="Nivel: " Font-Bold="True" Font-Names="Arial"
                                                            ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                                        <asp:Label ID="lblNivelTarjeta" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                        <br />
                                                        &nbsp &nbsp
                                                        <asp:Label ID="lblSaldo" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                            Font-Size="10pt" ForeColor="#004A99" Text="Saldo: "></asp:Label>
                                                        <asp:Label ID="lblSaldoMovTarjeta" runat="server" Font-Names="Arial" 
                                                            Font-Size="10pt"></asp:Label>
                                                        <br />
                                                        &nbsp; &nbsp;
                                                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Arial" 
                                                            Font-Size="10pt" ForeColor="#004A99" Text="Boomerangs: "></asp:Label>
                                                        <asp:Label ID="lblBoom" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label>
                                                        <br />
                                                        &nbsp; &nbsp;
                                                         <asp:Label ID="Label10" runat="server" Text="Inscrito a Club Peques: " Font-Bold="True" Font-Names="Arial"
                                                            ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                                        <asp:Label ID="lblPeque" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                        <br />
                                                        &nbsp &nbsp
                                                         <asp:Label ID="Label12" runat="server" Text="Correo electrónico confirmado: " Font-Bold="True" Font-Names="Arial"
                                                            ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                                        <asp:Label ID="lblConfirmoC" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>
                                                        <br />
                                                        &nbsp &nbsp
                                                         <asp:Label ID="Label9" runat="server" Text="Confirmo Celular: " Font-Bold="True" Font-Names="Arial"
                                                            ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                                        <asp:Label ID="lblConfirmoCelular" runat="server" Font-Size="10pt" Font-Names="Arial"></asp:Label>
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
                                <asp:Label ID="Label5" runat="server" Text="Movimientos de la Tarjeta: " Font-Bold="True"
                                    Font-Names="Arial" ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                <br />
                                <asp:Panel ID="Panel1" runat="server" Width="900px" ScrollBars="Auto" Font-Size="12px"
                                    Height="210px">
                                    <asp:GridView ID="grvSaldoClienteCC" runat="server" Font-Names="Arial" AutoGenerateColumns="False"
                                        CellSpacing="3" Width="900px">
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
                                             <asp:BoundField DataField="NoSucursal" HeaderText="Numero Sucursal" />
                                            <asp:TemplateField HeaderText="Sucursal">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("NombreSucursal") %>' Width="65px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("NombreSucursal") %>' Width="65px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Ticket" HeaderText="Ticket" />
                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                            <asp:BoundField DataField="CodigoInterno" HeaderText="Codigo Interno" />
                                            <asp:BoundField DataField="ProductoNombre" HeaderText="Producto" />
                                            <asp:TemplateField HeaderText="Importe">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Importe") %>' Width="65px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Importe","{0:$0.00}") %>' Width="65px"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>                                           
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
                <%--<table width="1010">
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
                            <img src="../Imagenes_Benavides/benavides.png" />
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
                </table>--%>
            </center>
        </div>
    </center>
 </asp:Content> 
