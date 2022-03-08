<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallePromo.aspx.cs" Inherits="CallcenterNUevo.Perfil.DetallePromo" %>
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
                <span class="titulo">Detalle Promociones</span><br /><br />
            </div>
     </asp:Panel>
        <asp:Panel ID="pnlDetalle" runat="server">
            <telerik:RadGrid ID="rgvDetalle" runat="server" Culture="es-ES" GroupPanelPosition="Top" AutoGenerateColumns="false" AllowPaging="True" CellSpacing="-1" GridLines="Both" OnPageIndexChanged="rgvDetalle_PageIndexChanged">
                <MasterTableView>
                    <Columns>
                        <telerik:GridBoundColumn DataField="id_tipotransaccion" HeaderText="Movimiento" ></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fecha" HeaderText="Fecha" ></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="hora" HeaderText="Hora" ></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Sucursal_strNombre" HeaderText="Sucursal" ></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PrecioFinal" HeaderText="Precio" ></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Cantidad" HeaderText="Cantidad" ></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Ticket" HeaderText="Ticket" ></telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </asp:Panel>
        <div id="botones"><asp:Button ID="btnCancelar" runat="server"  Text="Regresar" CausesValidation="False" PostBackUrl="~/Perfil/Promociones.aspx" />&nbsp;&nbsp;<asp:Button ID="btnExportar" runat="server"  Text="Exportar" OnClick="btnExportar_Click" /></div>
    </center>
</asp:Content>
