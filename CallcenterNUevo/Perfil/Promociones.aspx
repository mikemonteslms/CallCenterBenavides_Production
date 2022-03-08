<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Promociones.aspx.cs" Inherits="CallcenterNUevo.Perfil.Promociones" %>
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
                <span class="titulo">Promociones y Descuentos</span><br /><br />
            </div>
     </asp:Panel>
    <asp:Panel ID="pnlPromos" runat="server">
        <table>
            <tr>
                <td><span class="fuenteReporte">Selecciona la promoción que deseas consultar:</span><br /> </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadComboBox ID="rdcPromos" Runat="server" Culture="es-ES" DataTextField="PromoPaq_strPromocion" DataValueField="PromoPaq_IDPromocion" Skin="Bootstrap" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="rdcPromos_SelectedIndexChanged">
                    </telerik:RadComboBox>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="Select PromoPaq_IDPromocion, 
	PromoPaq_strPromocion 
from 
	tblPromocionPaquetes 
where 
	convert(varchar(8),getdate(),112) between convert(varchar(8),PromoPaq_dateIniVigencia,112) and	convert(varchar(8),PromoPaq_dateFinVigencia,112)
	and PromoPaq_intEstatus = 1 
"></asp:SqlDataSource>
                </td>
            </tr>
        </table><br />
         <h4><span class="titulo">Promociones</span></h4>
         <telerik:RadGrid ID="RadGrid1" runat="server" Culture="es-ES" GroupPanelPosition="Top" AutoGenerateColumns="false" AllowPaging="True" CellSpacing="-1" GridLines="Both" OnPageIndexChanged="RadGrid1_PageIndexChanged">
                                    <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                    <MasterTableView NoMasterRecordsText="No se encontro información">
                                        <RowIndicatorColumn Visible="False">
                                        </RowIndicatorColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="DescripcionMecanica" HeaderText="Mecánica"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreProducto" HeaderText="Producto"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Laboratorio" HeaderText="Laboratorio"></telerik:GridBoundColumn>    
                                            <telerik:GridBoundColumn DataField="Cupon" HeaderText="Cupón"></telerik:GridBoundColumn>    
                                            <telerik:GridBoundColumn DataField="VigenciaFin" HeaderText="Vigencia"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PiezasFaltaCompra" HeaderText="Falta Compra"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Acumulado" HeaderText="Acumulado"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Sku" HeaderText="SKU"></telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn>
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hplDetalle" Text="Detalle" NavigateUrl='<%# "DetallePromo.aspx?PromoID=" + Eval("Sku") %>' ForeColor="Red" runat="server"></asp:HyperLink>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
        </telerik:RadGrid>
        <div id="botones2" style="float:right;"><asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" OnClick="btnExportar_Click"/></div><br /><br />
    </asp:Panel><br /><br />
    <asp:Panel ID="pnlDescuentos" runat="server">
        <h4><span class="titulo">Descuentos</span></h4>
         <telerik:RadGrid ID="RadGrid2" runat="server" Culture="es-ES" GroupPanelPosition="Top" AllowPaging="True" CellSpacing="-1" GridLines="Both" OnPageIndexChanged="RadGrid2_PageIndexChanged">
                                    <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                    <MasterTableView NoMasterRecordsText="No se encontro información">
                                        <RowIndicatorColumn Visible="False">
                                        </RowIndicatorColumn>
                                </MasterTableView>
                            </telerik:RadGrid>
        <div id="Div1" style="float:right;"><asp:Button ID="Button1" runat="server" Text="Exportar a Excel" OnClick="Button1_Click"/></div><br /><br />
    </asp:Panel>
    </center>
</asp:Content>