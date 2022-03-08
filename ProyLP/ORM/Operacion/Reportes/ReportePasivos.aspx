<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="ReportePasivos.aspx.cs" Inherits="ORMOperacion.Reportes.ReportePasivos" %>

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
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" IsSticky="true" HorizontalAlign="Center" CssClass="MyModalPanel">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="mngRequestStarted">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ucFiltros">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridResultado" />
                    <telerik:AjaxUpdatedControl ControlID="PlaceHolder1" />
                    <telerik:AjaxUpdatedControl ControlID="ucFiltros" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlFiltros">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridResultado" />
                    <telerik:AjaxUpdatedControl ControlID="PlaceHolder1" />
                    <telerik:AjaxUpdatedControl ControlID="ucFiltros" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <table width="100%">
        <tr>
            <td align="center">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="pnlFiltros" runat="server">
                                <uc:Filtros ID="ucFiltros" runat="server" OnBuscarClicked="ucFiltros_BuscarClicked" OnSelectedIndexChanged="ucFiltros_SelectedIndexChanged" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td width="50%" valign="top">
                                        <telerik:RadGrid ID="gridResultado" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                                            CellPadding="0" GridLines="None" ShowFooter="True" PageSize="20"
                                            CellSpacing="0" EnableViewState="false"
                                            ShowGroupPanel="True" EnableLinqExpressions="False"
                                            Culture="es-MX"
                                            OnNeedDataSource="gridResultado_NeedDataSource"
                                            GroupingSettings-RetainGroupFootersVisibility="true"
                                            OnPreRender="gridResultado_PreRender"
                                            OnItemDataBound="gridResultado_ItemDataBound">
                                            <GroupingSettings RetainGroupFootersVisibility="True"></GroupingSettings>

                                            <MasterTableView ShowFooter="true" ShowGroupFooter="false">
                                                <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                                <GroupHeaderItemStyle HorizontalAlign="Right" />
                                                <GroupHeaderTemplate>
                                                    <table width="100%" cellpadding="0" cellspacing="0" class="texto13">
                                                        <tr>
                                                            <td>&nbsp;
                                                            </td>
                                                            <td align="center">
                                                                <b>
                                                                    <asp:Label runat="server" ID="lblTipoSaldo" Text='<%#  (((GridGroupHeaderItem)Container).AggregatesValues["tipo_saldo"]) %>'
                                                                        Visible='<%# ((((GridGroupHeaderItem)Container).AggregatesValues["tipo_saldo"]) != null)%>'>
                                                                    </asp:Label>
                                                                </b>
                                                            </td>
                                                            <td align="right" width="88px">
                                                                <b>
                                                                    <asp:Label runat="server" ID="lblPuntos" Text='<%# string.Format("{0:N}", (((GridGroupHeaderItem)Container).AggregatesValues["puntos"])) %>'
                                                                        Visible='<%# ((((GridGroupHeaderItem)Container).AggregatesValues["puntos"]) != null)%>'>
                                                                    </asp:Label>&nbsp;
                                                                </b>
                                                            </td>
                                                            <td align="right" width="84px">
                                                                <b>
                                                                    <asp:Label runat="server" ID="lblImporte" Text='<%# string.Format("{0:C}", (((GridGroupHeaderItem)Container).AggregatesValues["importe"]))  %>'
                                                                        Visible='<%# ((((GridGroupHeaderItem)Container).AggregatesValues["importe"]) != null)%>'> 
                                                                    </asp:Label>
                                                                </b>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </GroupHeaderTemplate>
                                                <GroupByExpressions>
                                                    <telerik:GridGroupByExpression>
                                                        <SelectFields>
                                                            <telerik:GridGroupByField FieldAlias="tipo_saldo" FieldName="tipo_saldo"></telerik:GridGroupByField>
                                                            <telerik:GridGroupByField FieldAlias="puntos" FieldName="puntos" Aggregate="Sum"></telerik:GridGroupByField>
                                                            <telerik:GridGroupByField FieldAlias="importe" FieldName="importe" Aggregate="Sum"></telerik:GridGroupByField>
                                                        </SelectFields>
                                                        <GroupByFields>
                                                            <telerik:GridGroupByField FieldName="tipo_saldo" SortOrder="Ascending"></telerik:GridGroupByField>
                                                        </GroupByFields>
                                                    </telerik:GridGroupByExpression>
                                                </GroupByExpressions>
                                                <Columns>
                                                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" Visible="false"
                                                        UniqueName="TemplateColumn">
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblTSaldo" Text='<%# Eval("tipo_saldo")%>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="tipo_saldo" Visible="false"
                                                        FilterControlAltText="Filter tipo_saldo column" HeaderText="Tipo de saldo"
                                                        UniqueName="tipo_saldo">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="categoria_transaccion"
                                                        FilterControlAltText="Filter categoria_transaccion column"
                                                        HeaderText="Concepto" UniqueName="categoria_transaccion" FooterText="Saldo">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn HeaderText="Porcentaje"
                                                        UniqueName="porcentaje">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridNumericColumn DataField="puntos" DataFormatString="{0:N}"
                                                        FilterControlAltText="Filter puntos column" HeaderText="Kilómetros" Aggregate="Sum"
                                                        UniqueName="puntos">
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </telerik:GridNumericColumn>
                                                    <telerik:GridBoundColumn DataField="importe"
                                                        FilterControlAltText="Filter importe column" HeaderText="Importe" Aggregate="Sum" DataFormatString="{0:C}"
                                                        UniqueName="importe">
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </telerik:GridBoundColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </td>
                                    <td width="50%" valign="top">
                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
