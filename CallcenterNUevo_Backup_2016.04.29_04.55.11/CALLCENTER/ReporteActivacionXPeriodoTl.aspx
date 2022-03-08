<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteActivacionXPeriodoTl.aspx.cs" Inherits="WebPfizer.LMS.eCard.ReporteActivacionXPeriodoTl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
            color: #004A99;
        }
        .titulo
        {
            font-family: Arial;
            font-size: 16pt;
            color: #004A99;
        }
    </style>
    <title>Reporte de Activación</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
<center>
       <%-- <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>--%>
        <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: 100%; background-repeat: no-repeat;">
            <table width="100%">
                <tr>
                    <td align="right">
                        <asp:ImageButton ID="btnCerrarSesion" runat="server" ImageUrl="~/Imagenes_Benavides/botones/cerrarsesion-btn.jpg" onclick="btnCerrarSesion_Click" Visible="false"/>
                    </td>
                </tr>
            </table>
            <br /><br /><br />
            <asp:Panel ID="Panel2" runat="server"  Height="100%">
                <asp:UpdatePanel ID="uppReportes" runat="server">
                    <ContentTemplate>
                        <asp:HiddenField ID="hdfMes" runat="server" />
                        <asp:HiddenField ID="hdfAnio" runat="server" />
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
                                    <asp:Label ID="lblMes" runat="server" CssClass="titulo" Text="Mes:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAnio" runat="server" CssClass="titulo" Text="Año:"></asp:Label>
                                </td>
                            </tr>
                            <tr align="center">
                                <td>
                                    <asp:DropDownList ID="ddlMes" runat="server" AutoPostBack="true" 
                                        onselectedindexchanged="ddlMes_SelectedIndexChanged" ></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAnio" runat="server" AutoPostBack="true" 
                                        onselectedindexchanged="ddlAnio_SelectedIndexChanged"></asp:DropDownList>
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
                                        onclick="btnCancelar_Click" Visible="false" />
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
                        </table>
                        <telerik:RadGrid RenderMode="Lightweight" ID="rGrdActivaciones" runat="server" 
                            Width="1000px" Height="500px"
                            AllowPaging="True" AllowSorting="True"
                            AllowFilteringByColumn="false" CellSpacing="0" GridLines="None" 
                            PageSize="100" onsortcommand="rGrdActivaciones_SortCommand"
                            onpageindexchanged="rGrdActivaciones_PageIndexChanged" 
                                onpagesizechanged="rGrdActivaciones_PageSizeChanged">
                            <ClientSettings>
                                <Scrolling  AllowScroll="True" ScrollHeight="450px" UseStaticHeaders="true"/>
                                <%--<Scrolling  AllowScroll="True" ScrollHeight="400px" UseStaticHeaders="true" FrozenColumnsCount="3"/>--%>
                            </ClientSettings>
                            <MasterTableView ShowFooter="True" AutoGenerateColumns="False" >
                                <ColumnGroups>
                                    <telerik:GridColumnGroup Name="Sucursal" HeaderText="SUCURSAL"
                                        HeaderStyle-HorizontalAlign="Center" />
                                    <telerik:GridColumnGroup Name="Total" HeaderText="TOTAL ACTIVACIONES POR DÍA"
                                        HeaderStyle-HorizontalAlign="Center" />
                                    <telerik:GridColumnGroup Name="Azul" HeaderText="ACTIVACIONES BI AZUL"
                                        HeaderStyle-HorizontalAlign="Center" />
                                    <telerik:GridColumnGroup Name="Platino" HeaderText="ACTIVACIONES BI PLATINO"
                                        HeaderStyle-HorizontalAlign="Center" />
                                </ColumnGroups>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="SAP" HeaderText="SAP" ReadOnly="true"
                                        HeaderStyle-Font-Underline="true" ColumnGroupName="Sucursal">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Clave sucursal" HeaderText="Clave" ReadOnly="true"
                                        HeaderStyle-Font-Underline="true" ColumnGroupName="Sucursal">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Estatus sucursal" HeaderText="Estatus" ReadOnly="true"
                                        HeaderStyle-Font-Underline="true" ColumnGroupName="Sucursal">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Nombre sucursal" HeaderText="Nombre" ReadOnly="true"
                                        HeaderStyle-Font-Underline="true" ColumnGroupName="Sucursal">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 1" HeaderText="1" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 2" HeaderText="2" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 3" HeaderText="3" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 4" HeaderText="4" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 5" HeaderText="5" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 6" HeaderText="6" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 7" HeaderText="7" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 8" HeaderText="8" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 9" HeaderText="9" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 10" HeaderText="10" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 11" HeaderText="11" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 12" HeaderText="12" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 13" HeaderText="13" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 14" HeaderText="14" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 15" HeaderText="15" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 16" HeaderText="16" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 17" HeaderText="17" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 18" HeaderText="18" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 19" HeaderText="19" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 20" HeaderText="20" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 21" HeaderText="21" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 22" HeaderText="22" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 23" HeaderText="23" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 24" HeaderText="24" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 25" HeaderText="25" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 26" HeaderText="26" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 27" HeaderText="27" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 28" HeaderText="28" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 29" HeaderText="29" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 30" HeaderText="30" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Día 31" HeaderText="31" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Total" ItemStyle-ForeColor="Green"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 1" HeaderText="1" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 2" HeaderText="2" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 3" HeaderText="3" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 4" HeaderText="4" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 5" HeaderText="5" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 6" HeaderText="6" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 7" HeaderText="7" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 8" HeaderText="8" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 9" HeaderText="9" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 10" HeaderText="10" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 11" HeaderText="11" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 12" HeaderText="12" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 13" HeaderText="13" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 14" HeaderText="14" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 15" HeaderText="15" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 16" HeaderText="16" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 17" HeaderText="17" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 18" HeaderText="18" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 19" HeaderText="19" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 20" HeaderText="20" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 21" HeaderText="21" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 22" HeaderText="22" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 23" HeaderText="23" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 24" HeaderText="24" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 25" HeaderText="25" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 26" HeaderText="26" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 27" HeaderText="27" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 28" HeaderText="28" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 29" HeaderText="29" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 30" HeaderText="30" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI azul día 31" HeaderText="31" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Azul" ItemStyle-ForeColor="Blue"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 1" HeaderText="1" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 2" HeaderText="2" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 3" HeaderText="3" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 4" HeaderText="4" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 5" HeaderText="5" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 6" HeaderText="6" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 7" HeaderText="7" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 8" HeaderText="8" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 9" HeaderText="9" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 10" HeaderText="10" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 11" HeaderText="11" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 12" HeaderText="12" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 13" HeaderText="13" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 14" HeaderText="14" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 15" HeaderText="15" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 16" HeaderText="16" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 17" HeaderText="17" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 18" HeaderText="18" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 19" HeaderText="19" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 20" HeaderText="20" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 21" HeaderText="21" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 22" HeaderText="22" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 23" HeaderText="23" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 24" HeaderText="24" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 25" HeaderText="25" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 26" HeaderText="26" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 27" HeaderText="27" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 28" HeaderText="28" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 29" HeaderText="29" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 30" HeaderText="30" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BI platino día 31" HeaderText="31" HeaderStyle-Font-Underline="true"
                                        ReadOnly="true" ColumnGroupName="Platino" ItemStyle-ForeColor="#FF8040"
                                        Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <br /><br /><br /><br />
                        <asp:UpdateProgress ID="uprReportes" runat="server" AssociatedUpdatePanelID="uppReportes">
                            <ProgressTemplate>
                                <div class="overlay" />
                                <div class="overlayContent">
                                    <img src="Images/aero_light.gif" alt="Procesando" border="1" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </div>
</center>
</asp:Content>