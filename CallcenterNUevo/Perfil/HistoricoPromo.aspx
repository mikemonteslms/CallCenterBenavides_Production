<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoricoPromo.aspx.cs" Inherits="CallcenterNUevo.Perfil.HistoricoPromo" %>
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
        <br />
    <asp:Panel ID="pnlHeader" runat="server">
        <uc1:HeaderCliente ID="HeaderCliente1" runat="server" />
    </asp:Panel><br /><br />
     <asp:Panel ID="pnlTitulo" runat="server" >
            <div>
                <span class="titulo">Histórico de promociones</span><br /><br />
            </div>
     </asp:Panel> 
     <asp:Panel ID="pnlFiltros" runat="server" Visible="false">
         <table>
             <tr>
                 <td>Tarjeta:</td>
                 <td><asp:TextBox ID="txtTarjeta" runat="server"></asp:TextBox> </td>
             </tr>
             <tr>
                 <td colspan="2"><br /></td>
             </tr>
             <tr>
                 <td colspan="2"><asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />&nbsp;&nbsp;<asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                     <br />
                 </td>
             </tr>
         </table>
    </asp:Panel>
        <telerik:RadComboBox ID="rdcPromos" Runat="server" Culture="es-ES" Skin="Bootstrap" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="rdcPromos_SelectedIndexChanged">
        </telerik:RadComboBox>
    <br /><br />
    <asp:Panel ID="pnlDineroE" runat="server">
        <telerik:RadGrid ID="grvPiezasGratis" runat="server" AllowPaging="True" AutoGenerateColumns="False" Culture="es-ES" GroupPanelPosition="Top" OnPageIndexChanged="grvPiezasGratis_PageIndexChanged">
            <GroupingSettings CollapseAllTooltip="Collapse all groups" />
            <MasterTableView NoMasterRecordsText="No se encontro información">
                <RowIndicatorColumn Visible="False">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Created="True">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="PromoPaq_strPromocion" FilterControlAltText="Filter column column" HeaderText="Promoción" UniqueName="column">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Acumuladas" FilterControlAltText="Filter column1 column" HeaderText="Acumuladas" UniqueName="column1">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Regla" FilterControlAltText="Filter column2 column" HeaderText="Regla" UniqueName="column2">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Entregados" FilterControlAltText="Filter column3 column" HeaderText="Entregados" UniqueName="column3">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PromoPaq_dateFinVigencia" DataType="System.DateTime" FilterControlAltText="Filter column4 column" HeaderText="Vigencia" UniqueName="column4">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </asp:Panel>
          <div id="botones2" style="float:right;"><asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" OnClick="btnExportar_Click"/></div><br /><br />
    </center>
</asp:Content>
