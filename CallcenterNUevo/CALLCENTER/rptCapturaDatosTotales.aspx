<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rptCapturaDatosTotales.aspx.cs" Inherits="CallcenterNUevo.CALLCENTER.rptCapturaDatosTotales" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
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
       .fuenteReporte
        {
            font-family: Arial Narrow;
            font-size: 12pt;
            color:#2B347A;
        }
        .titulo
        {
            font-family: Arial;
            font-size: 16pt;
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
        <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: 100%; background-repeat: no-repeat;">
            <br /><br /><br />
            <asp:Panel ID="Panel2" runat="server" >
                <div>
                    <span class="titulo">Captura datos totales</span><br /><br />
                </div>
                <div>
                    <span class="fuenteReporte">Reporte actualizado el día <asp:Label ID="lblFecha" runat="server" Text=""></asp:Label></span>
                </div><br /><br />
                <div style="float: right;"><asp:Button ID="btnConsultar" Text="Consultar Reporte" runat="server" OnClick="btnConsultar_Click"/></div>
                <br /><br />
                <telerik:RadGrid ID="RadGrid1" runat="server"  EmptyDataText="No hay datos que mostrar" PageSize="20" Font-Size="11px" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" 
                    BorderWidth="1px" CellPadding="3">
                    <HeaderStyle BackColor="#2B347A" ForeColor="#fff" Font-Size="12pt" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                </telerik:RadGrid>
                <br /><br />
                <div style="float: right;"><asp:Button ID="btnExportar" Text="Exportar a excel" runat="server" Enabled="false" OnClick="btnExportar_Click"/></div>
                <br /><br />
            </asp:Panel>
        </div>
    </center>
</asp:Content>
