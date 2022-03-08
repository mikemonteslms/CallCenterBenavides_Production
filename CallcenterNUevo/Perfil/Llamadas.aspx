<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Llamadas.aspx.cs" Inherits="CallcenterNUevo.Perfil.Llamadas" %>
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
    <asp:Panel ID="pnlFiltros" runat="server" Visible="false">
        <table>
            <tr>
                <td class="fuenteReporte">Tarjeta:</td>
                <td><asp:TextBox ID="txtTarjeta" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2"><br /></td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="2"><asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click"></asp:Button>&nbsp;&nbsp;&nbsp;<asp:Button ID="Limpiar" Text="Limpiar" runat="server" OnClick="Limpiar_Click"></asp:Button></td>
            </tr>
    </table>
    </asp:Panel><br /><br />
         <asp:Panel ID="pnlTitulo" runat="server" >
            <div>
                <span class="titulo">Llamadas</span><br /><br />
            </div>
     </asp:Panel><br />
    <asp:Panel ID="pnlHeader" runat="server">
        <uc1:HeaderCliente ID="HeaderCliente1" runat="server" />
    </asp:Panel>
    <br /><br /><br />
    <asp:GridView ID="grvListaLlamadasCC" runat="server" Font-Names="Arial" CellSpacing="3" EmptyDataText="No se encontro información." Width="100%">
        <AlternatingRowStyle BackColor="#D2D6D9" />
        <HeaderStyle BackColor="#2a3479" ForeColor="White" />
    </asp:GridView>
    <div id="botones2" style="float:right;"><asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" OnClick="btnExportar_Click"/></div><br /><br />
</asp:Content>
