<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="ReporteDetalleCanjes.aspx.cs" Inherits="ORMOperacion.Reportes.ReporteDetalleCanjes" %>

<%@ Register TagPrefix="uc" TagName="Filtros" Src="~/Reportes/Filtros.ascx" %>
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
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" IsSticky="true" HorizontalAlign="Center" CssClass="MyModalPanel">
                </telerik:RadAjaxLoadingPanel>
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="mngRequestStarted">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="ucFiltros">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="trFiltros" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="gridResultado" />
                                <telerik:AjaxUpdatedControl ControlID="ucFiltros" />
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
                                <telerik:AjaxUpdatedControl ControlID="ucFiltros" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="pnlFiltros" runat="server">
                                <uc:Filtros ID="ucFiltros" runat="server" OnBuscarClicked="ucFiltros_BuscarClicked" OnExportarClicked="ucFiltros_ExportarClicked" OnSelectedIndexChanged="ucFiltros_SelectedIndexChanged" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr id="trFiltros" runat="server">
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="overflow: auto; width: 1100px; height: 100%;">
                                <telerik:RadGrid ID="gridResultado" runat="server" EnableViewState="false"
                                    CellPadding="0" GridLines="None" ShowFooter="True"
                                    CellSpacing="0" AllowSorting="True"
                                    AllowFilteringByColumn="True" EnableLinqExpressions="False"
                                    Culture="es-MX" OnExcelExportCellFormatting="gridResultado_ExcelExportCellFormatting"
                                    OnNeedDataSource="gridResultado_NeedDataSource" AutoGenerateColumns="False"
                                    OnItemCommand="gridResultado_ItemCommand"
                                    OnItemDataBound="gridResultado_ItemDataBound">
                                    <GroupHeaderItemStyle HorizontalAlign="Left" />
                                    <ClientSettings AllowDragToGroup="True" AllowColumnsReorder="true">
                                    </ClientSettings>
                                    <MasterTableView CommandItemDisplay="Top" ShowGroupFooter="true">
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                                            Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                                            Visible="True">
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn UniqueName="id" DataField="id" HeaderText="id" Visible="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="distribuidor" DataField="distribuidor" HeaderText="Zona" AllowFiltering="false">
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="Clave_Participante" DataField="Clave_Participante" HeaderText="Clave Participante" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="Solicita" DataField="Solicita" HeaderText="Solicita" ShowFilterIcon="false" FilterControlWidth="200px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="Premio" DataField="Premio" HeaderText="Premio">
                                                <ItemStyle Wrap="false" />
                                                <FilterTemplate>
                                                    <telerik:RadComboBox ID="rcbPremio" runat="server" Width="160px" Height="100px" AutoPostBack="true" OnSelectedIndexChanged="FilterCombo_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                </FilterTemplate>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="Puntos" DataField="Puntos" HeaderText="Kilómetros"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="Comentario_(numero_y_operador)" DataField="Comentario (numero y operador)" HeaderText="Comentario (numero y operador)" AllowFiltering="false">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="Folio_RMS" DataField="Folio RMS" HeaderText="Folio RMS" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"></telerik:GridBoundColumn>
                                            <telerik:GridDateTimeColumn UniqueName="Fecha_solicitud" DataField="Fecha solicitud" HeaderText="Fecha solicitud" DataFormatString="{0:dd/MM/yyyy}" FilterControlWidth="100px">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridDateTimeColumn>
                                            <telerik:GridBoundColumn UniqueName="Hora_solicitud" DataField="Hora solicitud" HeaderText="Hora solicitud" ShowFilterIcon="false" AllowFiltering="false"></telerik:GridBoundColumn>
                                            <telerik:GridDateTimeColumn UniqueName="Fecha_promesa" DataField="Fecha promesa" HeaderText="Fecha promesa" DataFormatString="{0:dd/MM/yyyy}" FilterControlWidth="100px">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridDateTimeColumn>
                                            <telerik:GridBoundColumn UniqueName="Status" DataField="Status" HeaderText="Estatus" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="Usuario" DataField="Usuario" HeaderText="Usuario" ShowFilterIcon="false" FilterControlWidth="200px" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <FooterStyle Font-Bold="true" />
                                        <CommandItemSettings ShowExportToExcelButton="true" ShowAddNewRecordButton="false" ShowRefreshButton="false"></CommandItemSettings>
                                    </MasterTableView>
                                    <ExportSettings IgnorePaging="true" FileName="ReporteDetalleCanjes" ExportOnlyData="true">

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

