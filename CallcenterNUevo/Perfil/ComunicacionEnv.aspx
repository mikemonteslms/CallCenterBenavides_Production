<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComunicacionEnv.aspx.cs" Inherits="CallcenterNUevo.Perfil.comuenviada" %>
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
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlTitulo" runat="server" >
            <div>
                <span class="titulo">Comunicación enviadas</span><br /><br />
            </div>
     </asp:Panel>
    <br />
    <asp:Panel ID="pnlInfo" runat="server">
        <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" Culture="es-ES" GroupPanelPosition="Top" OnPageIndexChanged="RadGrid1_PageIndexChanged" AutoGenerateColumns="true">
            <GroupingSettings CollapseAllTooltip="Collapse all groups" />
            <MasterTableView NoMasterRecordsText="No se encontro información">
                <RowIndicatorColumn Visible="False">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Created="True">
                </ExpandCollapseColumn>
                <PagerStyle PageSizeControlType="None" />
            </MasterTableView>
            <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
        </telerik:RadGrid>
    </asp:Panel>
    <div id="botones2" style="float:right;"><asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" OnClick="btnExportar_Click"/></div><br /><br />
</center>
</asp:Content>
