<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteActivacionXPeriodo.aspx.cs" Inherits="MnuMain.CALLCENTER.ReporteActivacionXPeriodo" %>
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
             color: #004A99;
        }
        .titulo
        {
            font-family: Arial;
            font-size: 16pt;
            color: #004A99;
        }
    </style>
    <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: 100%; background-repeat: no-repeat;">
            <br /><br /><br />
            <asp:Panel ID="Panel2" runat="server"
                Height="100%">
                <asp:UpdatePanel ID="uppReportes" runat="server">
                    <ContentTemplate>
                        <br /><br />
                        <table width="95%" border="0">
                            <tr align="center">
                                <td><asp:Label ID="lblTutulo" runat="server" CssClass="titulo" Text="Reporte de activación por periodo"></asp:Label></td>
                            </tr>
                        </table>
                        <center>
                        <br />
                        <table width="300px" border="0">
                            <tr align="left">
                                <td>
                                    <asp:Label ID="lblMes" runat="server" CssClass="fuenteReporte" Text="Mes:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAnio" runat="server" CssClass="fuenteReporte" Text="Año:"></asp:Label>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <asp:DropDownList ID="ddlMes" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAnio" runat="server"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" valign="middle" style="height:50px;">
                                    <asp:Button ID="btnGeneraReporte" runat="server" Text="Genera Reporte" 
                                        CssClass="Etiqueta" onclick="btnGeneraReporte_Click" />
                                    <asp:Button ID="btnExportaReporte" runat="server" Text="Exporta Excel" 
                                        CssClass="Etiqueta" onclick="btnExportaReporte_Click" />
                                    <asp:ImageButton ID="btnCancelar" runat="server" Height="30px" 
                                        ImageUrl="~/Imagenes_Benavides/botones/undo.png" Width="30px" 
                                        onclick="btnCancelar_Click" />
                                </td>
                            </tr>
                        </table>
                        <!-- GridView con el resultado del reporte -->
                        <table width="100%" class="fuenteReporte" >
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblRegistrosEncontrados" runat="server" CssClass="Etiqueta" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblActivas" runat="server" CssClass="Etiqueta" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblInactivas" runat="server" CssClass="Etiqueta" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblTotalActivaciones" runat="server" CssClass="Etiqueta" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblAzulActivaciones" runat="server" CssClass="Etiqueta" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPlatinoActivaciones" runat="server" CssClass="Etiqueta" Text=""></asp:Label>
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="left">
                                    <asp:Label ID="lblTime" runat="server" CssClass="Etiqueta" Text=""></asp:Label>
                                </td>
                            </tr>--%>
                        </table>
                        <div style="width:1000px; height: 500px; overflow: scroll; border: 1px solid #c0c0c0;">
                            <div style="float:left;">
                                <asp:GridView ID="GridViewRegistros" runat="server" AllowSorting="true" 
                                    EmptyDataText="No hay datos que mostrar" AllowPaging="true" 
                                    PageSize="100" AutoGenerateColumns="True" Font-Size="11px" 
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="3"
                                    onpageindexchanging="GridViewRegistros_PageIndexChanging"
                                    onsorting="GridViewRegistros_Sorting">
                                    <HeaderStyle BackColor="#0154A0" CssClass="fuenteReporte" Font-Bold="True" ForeColor="White" Font-Size="12px" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000000" CssClass="fuenteReporte" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#8A0000" />
                                    <SortedAscendingHeaderStyle BackColor="#8A0000" />
                                    <SortedDescendingCellStyle BackColor="#8A0000" />
                                    <SortedDescendingHeaderStyle BackColor="#8A0000" />
                                    <PagerSettings Mode="Numeric" FirstPageText="Inicio" NextPageText="Siguiente" PreviousPageText="Anterior" LastPageText="Final" Position="Bottom" PageButtonCount="20" />
                                </asp:GridView>
                            </div>
                        </div>
                        <br /><br /><br /><br />
                        <asp:UpdateProgress ID="uprReportes" runat="server" AssociatedUpdatePanelID="uppReportes">
                            <ProgressTemplate>
                                <div class="overlay" />
                                <div class="overlayContent">
                                    <img src="../Images/aero_light.gif" alt="Procesando" border="1" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </div>
</asp:Content>
