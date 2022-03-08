<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rptHistorico.aspx.cs" Inherits="CallcenterNUevo.CALLCENTER.rptHistorico" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register src="../Controles/HeaderCliente.ascx" tagname="HeaderCliente" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
         .titulo
        {
            font-family: Arial;
            font-size: 16pt;
            color:#2B347A;
            margin-left: -100px;
        }
        .fuenteReporte
        {
            font-family: Arial Narrow;
            font-size: 12pt;
            color:#2B347A;
        }
        .RadGrid_Default .rgHeader, .RadGrid_Default th.rgResizeCol, .RadGrid_Default .rgHeaderWrapper {
            background: #2B347A 0 -2300px repeat-x !important;
            color: #fff !important;
            font-size: 12pt !important;
        }
        .cajatexto {
            border: 1px solid #808080;
        }
        .auto-style1 {
            height: 10px;
        }
        .ajax__tab_xp .ajax__tab_tab {
            height: 23px !important;
        }
        .ajax__tab_default .ajax__tab_tab {
            margin-right: 0px !important;
        }
    </style>
    <center>
    <div id="title" class="titulo">Movimientos</div><br /><br />
    <asp:Panel ID="pnlConsulta" runat="server">
           <%-- <table style="width:400px">
                <tr style="">
                    <td style="text-align:left"><span class="fuenteReporte">Tarjeta:</span></td>
                    <td>&nbsp;</td>
                    <td style="text-align:left">
                        <asp:TextBox ID="txtTDestino" runat="server" CssClass="cajatexto"></asp:TextBox>
                    </td>
                </tr>
            </table><br /><br />
            <div id="botonoes"><asp:Button ID="btnCOnsultar" runat="server" Text="Consultar" OnClick="btnCOnsultar_Click" /></div><br />--%>
            <uc1:HeaderCliente ID="HeaderCliente1" runat="server" />
        </asp:Panel><br />
     <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" >
            <cc1:TabPanel runat="server" HeaderText="Dinero Electrónico" ID="TabPanel1">
                <HeaderTemplate>
                    Dinero Electrónico
                </HeaderTemplate>
                <ContentTemplate><asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="750px">
                    <asp:GridView ID="grvTransacciones" runat="server" AutoGenerateColumns="False" Width="750px" CssClass="gridMisMov" CellPadding="0" GridLines="None" BackColor="White">
                        <AlternatingRowStyle BackColor="#E6E6E6" CssClass="gridMisMov"  />
                        <Columns><asp:TemplateField HeaderText="Tarjeta" Visible="False"><EditItemTemplate><asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Tarjeta") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label4" runat="server" Text='<%# Bind("Tarjeta") %>' Width="0px"></asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Fecha" HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_01.jpg"><EditItemTemplate><asp:TextBox ID="TextBox5" runat="server" Font-Names="FuturaStd-Book" ForeColor="#2B347A" Text='<%# Bind("Fecha") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label5" runat="server" Font-Names="FuturaStd-Book" ForeColor="#2B347A" Text='<%# Bind("Fecha") %>'></asp:Label></ItemTemplate><ItemStyle Wrap="False" HorizontalAlign="Center" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Tipo de Movimiento" HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_02.jpg"><EditItemTemplate><asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("TipoMovNombre") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label6" runat="server" Text='<%# Bind("TipoMovNombre") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Sucursal" 
                                                                
                                                                HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_03.jpg"><EditItemTemplate><asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("NombreSucursal") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label2" runat="server" Text='<%# Bind("NombreSucursal") %>'></asp:Label></ItemTemplate><ItemStyle Wrap="False" HorizontalAlign="Left" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Ticket" 
                                                                
                                                                HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_04.jpg"><EditItemTemplate><asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Ticket") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label7" runat="server" Text='<%# Bind("Ticket") %>' CssClass="gridEspecial"></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Importe" 
                                                                
                                                                HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_05.jpg"><EditItemTemplate><asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Importe") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%# Bind("Importe","{0:$0.00}") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Dinero Electrónico Benavides" 
                                                                
                                                                HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_06.jpg"><EditItemTemplate><asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PesosPuntos") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label3" runat="server" Text='<%# Bind("PesosPuntos","{0:$0.00}") %>'
                                                                        ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField></Columns><HeaderStyle BackColor="#436DB5" /><RowStyle CssClass="gridMisMov" /></asp:GridView></asp:Panel></ContentTemplate>            
            </cc1:TabPanel>
            <cc1:TabPanel runat="server" HeaderText="Producto Gratis" ID="TabPanel2">
                <ContentTemplate>
                    <asp:GridView ID="grvPiezasGratis" runat="server" Width="750px" CssClass="gridMisMov" CellPadding="0" GridLines="None" BackColor="White" AutoGenerateColumns="false" EmptyDataText="No se encontro información para mostrar">
                        <Columns>
                            <asp:BoundField DataField="PromoPaq_strPromocion" HeaderText="Producto" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px" ItemStyle-Height="25px" />
                            <asp:BoundField DataField="Acumuladas" HeaderText="Acumuladas" />
                            <asp:BoundField DataField="Regla" HeaderText="Regla" />
                            <asp:BoundField DataField="Entregados" HeaderText="Entregadas" />
                            <asp:BoundField DataField="PromoPaq_dateFinVigencia" HeaderText="Vigencia" DataFormatString="{0:dd/MM/yyyy}" />                                                                                    
                        </Columns>
                        <HeaderStyle BackColor="#436DB5" ForeColor="White" Font-Bold="true" Font-Size="14px" Font-Names="FuturaStd-Book"/>
                        <RowStyle CssClass="gridMisMov" />
                        <AlternatingRowStyle BackColor="#E6E6E6" CssClass="gridMisMov"  />
                    </asp:GridView>
                </ContentTemplate>                                                        
            </cc1:TabPanel>
         <cc1:TabPanel runat="server" HeaderText="Laboratorios" ID="TabPanel3">
                <ContentTemplate>
                    <asp:GridView ID="grvLabs" runat="server" Width="750px" CssClass="gridMisMov" CellPadding="0" GridLines="None" BackColor="White" AutoGenerateColumns="false" EmptyDataText="No se encontro información para mostrar">
                       <Columns>
                           <asp:BoundField DataField="TipoTransaccion" HeaderText="Transacción" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px" ItemStyle-Height="25px" />
                            <asp:BoundField DataField="HoraMov" HeaderText="Hora"  ItemStyle-Width="100px"/>
                            <asp:BoundField DataField="FechaMov" HeaderText="Fecha" ItemStyle-Width="120px"/>
                            <asp:BoundField DataField="SucursalId" HeaderText="Sucursal" ItemStyle-Width="80px"/>
                            <asp:BoundField DataField="Ticket" HeaderText="Ticket" ItemStyle-Width="100px"/>
                           <asp:BoundField DataField="PiezasVenta" HeaderText="Piezas" ItemStyle-Width="70px"/>
                           <asp:BoundField DataField="PiezasGratis" HeaderText="Gratis" ItemStyle-Width="70px" />
                           <asp:BoundField DataField="Pedido_Sku" HeaderText="SKU" ItemStyle-Width="150px"/>
                       </Columns>
                        <HeaderStyle BackColor="#436DB5" ForeColor="White" Font-Bold="true" Font-Size="14px" Font-Names="FuturaStd-Book"/>
                        <RowStyle CssClass="gridMisMov" />
                        <AlternatingRowStyle BackColor="#E6E6E6" CssClass="gridMisMov"  />
                    </asp:GridView>
                </ContentTemplate>                                                        
            </cc1:TabPanel>
        </cc1:TabContainer>
        </center>
    <br /><br />
</asp:Content>
