<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="ReportePuntosParticipantes.aspx.cs" Inherits="ORMOperacion.Reportes.ReportePuntosParticipantes" %>

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
                <script type="text/javascript">

         
                </script>
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
                                <telerik:RadGrid ID="gridResultado" runat="server" EnableViewState="false" AllowPaging="true"
                                    CellPadding="0" GridLines="None" ShowFooter="True"
                                    CellSpacing="0" AllowSorting="True" PageSize="20"
                                    AllowFilteringByColumn="True"
                                    EnableLinqExpressions="False" OnExcelExportCellFormatting="gridResultado_ExcelExportCellFormatting"
                                    Culture="es-MX"
                                    OnNeedDataSource="gridResultado_NeedDataSource" AutoGenerateColumns="False"
                                    OnItemCommand="gridResultado_ItemCommand">
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
                                            <telerik:GridBoundColumn UniqueName="pais" DataField="pais" HeaderText="País" AllowFiltering="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="status_participante" DataField="status_participante" HeaderText="Estatus de participante" AllowFiltering="false">
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="distribuidor" DataField="distribuidor" HeaderText="Zona" AllowFiltering="false">
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="tipo_participante" DataField="tipo_participante" HeaderText="Tipo de participante" AllowFiltering="false">
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="clave" DataField="clave" HeaderText="Clave" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="razon_social" DataField="razon_social" HeaderText="Razón Social" ShowFilterIcon="false" FilterControlWidth="200px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="nombre_completo" DataField="nombre_completo" HeaderText="Nombre" ShowFilterIcon="false" FilterControlWidth="200px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridDateTimeColumn UniqueName="fecha_alta" DataField="fecha_alta" HeaderText="Fecha Alta" DataFormatString="{0:dd/MM/yyyy}" FilterControlWidth="100px">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridDateTimeColumn>
                                            <telerik:GridNumericColumn Aggregate="Sum" DecimalDigits="0" DataField="puntos_ganados" HeaderText="Kilómetros Ganados" FilterControlWidth="30px"
                                                UniqueName="puntos_ganados" FooterText=" ">
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn Aggregate="Sum" DecimalDigits="0" DataField="bonos" HeaderText="Bonos" FilterControlWidth="50px"
                                                UniqueName="bonos" FooterText=" ">
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn Aggregate="Sum" DecimalDigits="0" DataField="canjes" HeaderText="Canjes" FilterControlWidth="50px"
                                                UniqueName="canjes" FooterText=" ">
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn Aggregate="Sum" DecimalDigits="0" DataField="ajustes_positivos" HeaderText="Ajustes Positivos" FilterControlWidth="50px"
                                                UniqueName="ajustes_positivos" FooterText=" ">
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn Aggregate="Sum" DecimalDigits="0" DataField="ajuste_negativos" HeaderText="Ajustes Negativos" FilterControlWidth="50px"
                                                UniqueName="ajuste_negativos" FooterText=" ">
                                            </telerik:GridNumericColumn>
                                            <telerik:GridNumericColumn Aggregate="Sum" DecimalDigits="0" DataField="puntos_otros_programas" HeaderText="Kilómetros Otros Programas" FilterControlWidth="50px"
                                                UniqueName="puntos_otros_programas" FooterText=" ">
                                            </telerik:GridNumericColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <FooterStyle Font-Bold="true" />
                                        <CommandItemSettings ShowExportToExcelButton="true" ShowAddNewRecordButton="false" ShowRefreshButton="false"></CommandItemSettings>
                                    </MasterTableView>
                                    <ExportSettings IgnorePaging="true" FileName="ReportePuntosParticipantes">

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

