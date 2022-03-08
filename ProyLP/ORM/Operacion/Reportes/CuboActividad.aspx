<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="CuboActividad.aspx.cs" Inherits="ORMOperacion.Reportes.CuboActividad" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="uc" TagName="Filtros" Src="~/Reportes/Filtros.ascx" %>
<%@ MasterType VirtualPath="~/contenido.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
    <style>
        .RadMenu_Bootstrap .rmVertical .rmRootLink {
            background-color: chocolate;
        }

        .RadMenu_Bootstrap .rmRootLink.rmDisabled {
            background-color: silver !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <script type="text/javascript">
        function mngRequestStarted(ajaxManager, eventArgs) {
            if (eventArgs.get_eventTarget().indexOf("ExportToExcelButton") != -1)
                eventArgs.set_enableAjax(false);
            else if (eventArgs.get_eventTarget().indexOf("ibtnExportar") != -1) {
                eventArgs.set_enableAjax(false);
            }
            else {
                // the following Javascript code takes care of expanding the RadAjaxLoadingPanel
                // to the full height of the page, if it is more than the browser window viewport

                var loadingPanel = document.getElementById("ContentPlaceHolder1_body_contenido_RadAjaxLoadingPanel1");
                var pageHeight = document.documentElement.scrollHeight;
                var viewportHeight = document.documentElement.clientHeight;

                if (pageHeight > viewportHeight) {
                    loadingPanel.style.height = pageHeight + "px";
                }

                var pageWidth = document.documentElement.scrollWidth;
                var viewportWidth = document.documentElement.clientWidth;

                if (pageWidth > viewportWidth) {
                    loadingPanel.style.width = pageWidth + "px";
                }

                // the following Javascript code takes care of centering the RadAjaxLoadingPanel
                // background image, taking into consideration the scroll offset of the page content

                var scrollTopOffset = document.documentElement.scrollTop;
                var scrollLeftOffset = document.documentElement.scrollLeft;
                var loadingImageWidth = 55;
                var loadingImageHeight = 55;

                loadingPanel.style.backgroundPosition = (parseInt(scrollLeftOffset) + parseInt(viewportWidth / 2) - parseInt(loadingImageWidth / 2)) + "px " + (parseInt(scrollTopOffset) + parseInt(viewportHeight / 2) - parseInt(loadingImageHeight / 2)) + "px";

                // workaround for RadAjaxLoadingPanel for ASP.NET - there are two elements with the same ID
                // this is not needed with RadAjaxLoadingPanel for ASP.NET AJAX

                if (loadingPanel.nextSibling.className == loadingPanel.className) // IE, Opera
                {
                    loadingPanel.nextSibling.style.backgroundPosition = (parseInt(scrollLeftOffset) + parseInt(viewportWidth / 2) - parseInt(loadingImageWidth / 2)) + "px " + (parseInt(scrollTopOffset) + parseInt(viewportHeight / 2) - parseInt(loadingImageHeight / 2)) + "px";
                }
                else if (document.getElementsByClassName) // Firefox
                {
                    var panels = document.getElementsByClassName("MyModalPanel");
                    for (var j = 0; j < panels.length; j++) {
                        panels[j].style.backgroundPosition = (parseInt(scrollLeftOffset) + parseInt(viewportWidth / 2) - parseInt(loadingImageWidth / 2)) + "px " + (parseInt(scrollTopOffset) + parseInt(viewportHeight / 2) - parseInt(loadingImageHeight / 2)) + "px";
                    }
                }
            }
        }
    </script>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" IsSticky="true" HorizontalAlign="Center" CssClass="MyModalPanel">
        <img src='<%= "style/images/loading.gif" %>' />
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"
        DefaultLoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="mngRequestStarted">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cubo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="cubo" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <table width="100%">
        <tr>
            <td align="center">
                <table width="100%">
                    <tr>

                        <td align="left">
                            <uc:Filtros ID="ucFiltros" runat="server" OnExportarClicked="ucFiltros_ExportarClicked" />

                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadPivotGrid runat="server" ID="cubo" Culture="es-MX" EnableZoneContextMenu="true"
                                OnNeedDataSource="cubo_NeedDataSource" Width="1100px" AllowSorting="true" AllowFiltering="true"
                                OnCellDataBound="cubo_CellDataBound" EnableViewState="false" AllowPaging="true" PageSize="5"
                                OnPivotGridCellExporting="cubo_PivotGridCellExporting">
                                <Fields>
                                    <telerik:PivotGridRowField DataField="Año" Caption="Año" UniqueName="Total3">
                                    </telerik:PivotGridRowField>
                                    <telerik:PivotGridRowField DataField="Mes" Caption="Mes" UniqueName="Total4">
                                        <CellTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="<%# GetMonthName(Container.DataItem)%>" />
                                        </CellTemplate>
                                    </telerik:PivotGridRowField>
                                    <telerik:PivotGridRowField DataField="Marca" Caption="Marca" UniqueName="TotalM">
                                    </telerik:PivotGridRowField>
                                    <telerik:PivotGridColumnField DataField="Categoria" Caption="Categoria" UniqueName="Total1">
                                    </telerik:PivotGridColumnField>
                                    <telerik:PivotGridRowField DataField="Producto" Caption="Producto" UniqueName="Total2">
                                    </telerik:PivotGridRowField>
                                    <telerik:PivotGridAggregateField DataField="Participante" Caption="Total Participantes" UniqueName="STotal"
                                        Aggregate="Count">
                                    </telerik:PivotGridAggregateField>
                                    <telerik:PivotGridAggregateField DataField="Puntos" Caption="Total Kilómetros" UniqueName="STotal1" DataFormatString="{0:N}"
                                        Aggregate="Sum">
                                    </telerik:PivotGridAggregateField>
                                    <telerik:PivotGridAggregateField DataField="Cantidad" Caption="Total Cantidad" UniqueName="STotal2" DataFormatString="{0:N}"
                                        Aggregate="Sum">
                                    </telerik:PivotGridAggregateField>
                                    <telerik:PivotGridAggregateField DataField="Importe" Caption="Total Importe" UniqueName="STotal3" DataFormatString="{0:C}"
                                        Aggregate="Sum">
                                    </telerik:PivotGridAggregateField>
                                </Fields>
                                <ClientSettings EnableFieldsDragDrop="true" Scrolling-AllowVerticalScroll="true" Scrolling-SaveScrollPosition="true">
                                    <ClientMessages DragToReorder="Mueva el campo para cambiar el orden"></ClientMessages>
                                </ClientSettings>
                            </telerik:RadPivotGrid>
                        </td>

                    </tr>

                </table>
            </td>
        </tr>
    </table>
</asp:Content>
