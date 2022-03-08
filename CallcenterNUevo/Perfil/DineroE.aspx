<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DineroE.aspx.cs" Inherits="CallcenterNUevo.Perfil.DineroE" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<%@ Register src="../Controles/HeaderCliente.ascx" tagname="HeaderCliente" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <style type="text/css">
        .overlay  
        {
            position: fixed;
            z-index: 98;
            top: 0px;
            left: 0px;
            right: 0px;
            bottom: 0px;
            background-color: #aaa; 
            filter: alpha(opacity=80); 
            opacity: 0.8; 
        }
        .overlayContent
        {
            z-index: 99;
            margin: 250px auto;
            width: 32px;
            height: 32px;
        }
        .titulo
        {
            font-family: Arial;
            font-size: 16pt;
            color: #004A99;
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
    </style>
    <center>
    <asp:Panel ID="pnlHeader" runat="server">
        <uc1:HeaderCliente ID="HeaderCliente1" runat="server" />
    </asp:Panel><br />
    <asp:Panel ID="pnlTitulo" runat="server" >
            <div>
                <span class="titulo">Dinero Electrónico</span>
            </div>
     </asp:Panel>
    <br />
    <asp:UpdatePanel runat="server" ID="UpTransacciones">
    <ContentTemplate>
         <asp:Panel ID="pnlDineroE" runat="server">
                    <telerik:RadGrid ID="grvTransacciones"  runat="server" PageSize="50" ClientSettings-Scrolling-AllowScroll="true" AllowPaging="True" Culture="es-ES"  GroupPanelPosition="Top" AutoGenerateColumns="true" OnPageIndexChanged="grvTransacciones_PageIndexChanged" >
                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                        <MasterTableView NoMasterRecordsText="No se encontro información.">
                            <RowIndicatorColumn Visible="False">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Created="True">
                            </ExpandCollapseColumn>
                        </MasterTableView>
                         <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                        <HeaderStyle Width="100px"></HeaderStyle>
                            <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                    </telerik:RadGrid>
                    <br />
                    <div id="botones2" style="float:right;"><asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" OnClick="btnExportar_Click"/></div><br /><br />
                     <%--<asp:GridView ID="grvTransacciones" runat="server" AutoGenerateColumns="False" Width="750px" CssClass="gridMisMov" CellPadding="0" GridLines="None" BackColor="White">
                        <AlternatingRowStyle BackColor="#E6E6E6" CssClass="gridMisMov"  />
                        <Columns>
                               <asp:TemplateField HeaderText="Tarjeta" Visible="False">
                               <EditItemTemplate><asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Tarjeta") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label4" runat="server" Text='<%# Bind("Tarjeta") %>' Width="0px"></asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Fecha" HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_01.jpg"><EditItemTemplate><asp:TextBox ID="TextBox5" runat="server" Font-Names="FuturaStd-Book" ForeColor="#2B347A" Text='<%# Bind("Fecha") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label5" runat="server" Font-Names="FuturaStd-Book" ForeColor="#2B347A" Text='<%# Bind("Fecha") %>'></asp:Label></ItemTemplate><ItemStyle Wrap="False" HorizontalAlign="Center" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Tipo de Movimiento" HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_02.jpg"><EditItemTemplate><asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("TipoMovNombre") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label6" runat="server" Text='<%# Bind("TipoMovNombre") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Sucursal" 
                               HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_03.jpg"><EditItemTemplate><asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("NombreSucursal") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label2" runat="server" Text='<%# Bind("NombreSucursal") %>'></asp:Label></ItemTemplate><ItemStyle Wrap="False" HorizontalAlign="Left" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Ticket" 
                                                                
                                                                            HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_04.jpg"><EditItemTemplate><asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Ticket") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label7" runat="server" Text='<%# Bind("Ticket") %>' CssClass="gridEspecial"></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Importe" 
                                                                
                                                                            HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_05.jpg"><EditItemTemplate><asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Importe") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%# Bind("Importe","{0:$0.00}") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:BoundField HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/Separador.jpg" /><asp:TemplateField HeaderText="Dinero Electrónico Benavides" 
                                                                
                                                                            HeaderImageUrl="~/Imagenes_Benavides/MasterNueva/3-mis_compras/img-tabla-compras/img-tabla-compras_06.jpg"><EditItemTemplate><asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PesosPuntos") %>'></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="Label3" runat="server" Text='<%# Bind("PesosPuntos","{0:$0.00}") %>'
                                                                                    ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField></Columns><HeaderStyle BackColor="#436DB5" /><RowStyle CssClass="gridMisMov" /></asp:GridView>--%>
                </asp:Panel>
    </ContentTemplate>
    </asp:UpdatePanel>
</center>
</asp:Content>
