<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="ReporteAsignaciones.aspx.cs" Inherits="ORMOperacion.Reportes.ReporteAsignaciones" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
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

    <table width="100%">
        <tr>
            <td align="center">
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" IsSticky="true" HorizontalAlign="Center" BackgroundPosition="Center" CssClass="MyModalPanel">
                </telerik:RadAjaxLoadingPanel>
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="mngRequestStarted">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="ucFiltros">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="trFiltros" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="gridResultado" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="gridResultado">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="gridResultado" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="pnlFiltros">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="gridResultado" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="pnlFiltros" runat="server">
                                <table width="100%" id="tblFechaInicio" runat="server">
                                    <tr>
                                        <td align="right" width="30%">
                                            <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha: " CssClass="texto13"></asp:Label>
                                        </td>

                                        <td width="70%">
                                            <telerik:RadMonthYearPicker ID="rdpFecha" runat="server">
                                            </telerik:RadMonthYearPicker>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%">
                                            <asp:Label ID="Label1" runat="server" Text="Programa: " CssClass="texto13"></asp:Label>
                                        </td>
                                        <td>
                                            <telerik:RadComboBox ID="rcbPrograma" runat="server">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%">
                                            <asp:Label ID="Label2" runat="server" Text="Tipo Reporte: " CssClass="texto13"></asp:Label>
                                        </td>
                                        <td>

                                            <asp:RadioButtonList ID="rblTipoReporte" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1" Selected="True">Resumen</asp:ListItem>
                                                <asp:ListItem Value="2">Detalle</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <telerik:RadButton ID="ibtnBuscar" runat="server" Text="Buscar" CommandName="Buscar" CssClass="negrita" ToolTip="Buscar" OnClick="ibtnBuscar_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <telerik:RadButton ID="ibtnExportar" runat="server" Text="Exportar" CommandName="Exportar" CssClass="negrita" ToolTip="Exportar" OnClick="ibtnExportar_Click" />
                                        </td>
                                    </tr>
                                </table>


                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="overflow: auto; width: 1100px; height: 100%;">
                                <telerik:RadGrid ID="gridResultado" runat="server" AllowPaging="true" PageSize="20"
                                    CellPadding="0" GridLines="None" ShowFooter="True"
                                    CellSpacing="0" AllowSorting="True"
                                    AllowFilteringByColumn="False" EnableViewState="false"
                                    EnableLinqExpressions="False" OnExcelExportCellFormatting="gridResultado_ExcelExportCellFormatting"
                                    Culture="es-MX"
                                    OnNeedDataSource="gridResultado_NeedDataSource" AutoGenerateColumns="True">
                                    <GroupHeaderItemStyle HorizontalAlign="Left" />
                                    <ClientSettings AllowDragToGroup="True" AllowColumnsReorder="true">
                                        <Scrolling AllowScroll="True" UseStaticHeaders="false" />
                                    </ClientSettings>
                                    <MasterTableView CommandItemDisplay="Top" ShowGroupFooter="true">
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                                            Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                                            Visible="True">
                                        </ExpandCollapseColumn>

                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <FooterStyle Font-Bold="true" />
                                        <CommandItemSettings ShowExportToExcelButton="true" ShowAddNewRecordButton="false" ShowRefreshButton="false"></CommandItemSettings>
                                    </MasterTableView>
                                    <ExportSettings IgnorePaging="true" FileName="ReporteParticipantes" ExportOnlyData="true">

                                        <Excel Format="Html"></Excel>
                                    </ExportSettings>
                                    <GroupingSettings ShowUnGroupButton="true"></GroupingSettings>
                                    <FilterMenu EnableImageSprites="False">
                                    </FilterMenu>
                                </telerik:RadGrid>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

