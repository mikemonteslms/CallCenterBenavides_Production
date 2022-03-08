<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="MisCompras.aspx.cs" Inherits="WebPfizer.LMS.eCard.MisCompras" %>
 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
   
    <table><tr><td valign="top">    <table>   
      
    <tr>
    <td>
    <asp:Label ID="Label8" runat="server" Text="Mis compras" Font-Names="FuturaStd-Bold"  Font-Size="14px" ForeColor="#666666"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style="height:15px;">    
    </td>
    </tr>
    <tr>        
    <td>
    <hr />
    </td>
    </tr>
     <tr>
    <td style="height:15px;">    
    </td>
     </tr>
     <tr>
    <td> 
         <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" >
            <cc1:TabPanel runat="server" HeaderText="Dinero Electrónico" ID="TabPanel1">
                <ContentTemplate><asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="614px">
                    <asp:GridView ID="grvTransacciones" runat="server" AutoGenerateColumns="False" Width="614px" CssClass="gridMisMov" CellPadding="0" GridLines="None" BackColor="White">
                        <AlternatingRowStyle BackColor="#E6E6E6" CssClass="gridMisMov"  />
                        <Columns><asp:TemplateField HeaderText="Tarjeta" Visible="False"><EditItemTemplate><asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Tarjeta") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label4" runat="server" Text='<%# Bind("Tarjeta") %>' Width="0px"></asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Fecha" HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_01.jpg"><EditItemTemplate><asp:TextBox ID="TextBox5" runat="server" Font-Names="FuturaStd-Book" ForeColor="#2B347A" Text='<%# Bind("Fecha") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label5" runat="server" Font-Names="FuturaStd-Book" ForeColor="#2B347A" Text='<%# Bind("Fecha") %>'></asp:Label></ItemTemplate><ItemStyle Wrap="False" HorizontalAlign="Center" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Tipo de Movimiento" HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_02.jpg"><EditItemTemplate><asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("TipoMovNombre") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label6" runat="server" Text='<%# Bind("TipoMovNombre") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Sucursal" 
                                                                
                                                                HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_03.jpg"><EditItemTemplate><asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("NombreSucursal") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label2" runat="server" Text='<%# Bind("NombreSucursal") %>'></asp:Label></ItemTemplate><ItemStyle Wrap="False" HorizontalAlign="Left" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Ticket" 
                                                                
                                                                HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_04.jpg"><EditItemTemplate><asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Ticket") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label7" runat="server" Text='<%# Bind("Ticket") %>' CssClass="gridEspecial"></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Importe" 
                                                                
                                                                HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_05.jpg"><EditItemTemplate><asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Importe") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%# Bind("Importe","{0:$0.00}") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Dinero Electrónico Benavides" 
                                                                
                                                                HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_06.jpg"><EditItemTemplate><asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PesosPuntos") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label3" runat="server" Text='<%# Bind("PesosPuntos","{0:$0.00}") %>'
                                                                        ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField></Columns><HeaderStyle BackColor="#436DB5" /><RowStyle CssClass="gridMisMov" /></asp:GridView></asp:Panel></ContentTemplate>            
            </cc1:TabPanel>
            <cc1:TabPanel runat="server" HeaderText="Piezas Gratis" ID="TabPanel2">
                <ContentTemplate>
                    <asp:GridView ID="grvPiezasGratis" runat="server" Width="614px" CssClass="gridMisMov" CellPadding="0" GridLines="None" BackColor="White" AutoGenerateColumns="false" EmptyDataText="No se encontraron acumulaciones para mostrar" EmptyDataRowStyle-Font-Names="FuturaStd-Book" EmptyDataRowStyle-Font-Size="14px">
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
        </cc1:TabContainer>
    </td>
    </tr>
     <tr>
    <td style="height:250px;"> 
        </td>
    </tr>
    </table></td></tr></table>
    
                                           
                                 
 </asp:Content>
