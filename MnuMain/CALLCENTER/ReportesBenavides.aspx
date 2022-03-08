﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportesBenavides.aspx.cs" Inherits="MnuMain.CALLCENTER.ReportesBenavides" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: auto; background-repeat: no-repeat;">
            <center>
                <br />
                <br />
                <br />
                <asp:Panel ID="Panel2" runat="server" Width="100%" BackImageUrl="~/Imagenes_Benavides/SaldoMov-fondo.png"
                    Height="990px">
                    <table width="850px" align="center">
                        <tr>
                            <td align="center">
                                <table>
                                    <tr>
                                        <td style="vertical-align:middle">
                                            <asp:Label ID="lblTopCompras" runat="server" Text="Top 10 Compras" ForeColor="#004A99"
                                                CssClass="Etiqueta" Font-Bold="True" Font-Size="12pt"></asp:Label>
                                            &nbsp
                                        </td>
                                        <td style="border-right-color: Gray; border-right-width: 1px; border-right-style: solid">
                                            <asp:ImageButton ID="imgTopCompras" runat="server" Height="38px" ImageUrl="~/Imagenes_Benavides/botones/shopping cart.png"
                                                ToolTip="Top 10 Compras" Width="38px" ImageAlign="AbsBottom" 
                                                onclick="imgTopCompras_Click" />
                                            &nbsp&nbsp&nbsp
                                        </td>
                                        <td>
                                            &nbsp&nbsp&nbsp
                                            <asp:Label ID="lblSaldoTarjeta" runat="server" Text="Captura el No. de Tarjeta: "
                                                ForeColor="#004A99" CssClass="Etiqueta" Font-Bold="True" Font-Size="12pt"></asp:Label>
                                            <asp:TextBox ID="txtTarjeta" runat="server" MaxLength="19"></asp:TextBox>
                                            &nbsp &nbsp
                                        </td>
                                        <td style="border-right-color: Gray; border-right-width: 1px; border-right-style: solid">
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
                                                            ToolTip="Regresar" ImageUrl="~/Imagenes_Benavides/botones/undo.png" OnClick="SaldoMovRegresar_Click" Visible="false" />
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
 <%--               <table width="1010">
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
                            <asp:Label ID="Label6" runat="server" Font-Size="8pt" ForeColor="Silver" Text="Copyright 2013 Farmacias Benavides. Todos los derechos reservados" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>--%>
            </center>
        </div>
</asp:Content>
