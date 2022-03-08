<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="ReporteParticipantes.aspx.cs" Inherits="ORMOperacion.Reportes.ReporteParticipantes" %>

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
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" IsSticky="true" HorizontalAlign="Center" BackgroundPosition="Center" CssClass="MyModalPanel">
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
                                <uc:Filtros ID="ucFiltros" runat="server" OnBuscarClicked="ucFiltros_BuscarClicked"
                                    OnExportarClicked="ucFiltros_ExportarClicked" OnSelectedIndexChanged="ucFiltros_SelectedIndexChanged" />
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
                                <telerik:RadGrid ID="gridResultado" runat="server" AllowPaging="true" PageSize="20"
                                    CellPadding="0" GridLines="None" ShowFooter="True"
                                    CellSpacing="0" AllowSorting="True"
                                    AllowFilteringByColumn="True" EnableViewState="false"
                                    EnableLinqExpressions="False" OnExcelExportCellFormatting="gridResultado_ExcelExportCellFormatting"
                                    Culture="es-MX"
                                    OnNeedDataSource="gridResultado_NeedDataSource" AutoGenerateColumns="False"
                                    OnItemCommand="gridResultado_ItemCommand"
                                    OnItemDataBound="gridResultado_ItemDataBound">
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
                                        <Columns>
                                            <telerik:GridBoundColumn UniqueName="id" DataField="id" HeaderText="id" Visible="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="programa" DataField="programa" HeaderText="Programa" AllowFiltering="false">

                                                <HeaderStyle Width="170px" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="status_participante" DataField="status_participante" HeaderText="Estatus de participante" AllowFiltering="false">
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="distribuidor" DataField="distribuidor" HeaderText="Zona" AllowFiltering="false">
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="tipo_participante" DataField="tipo_participante" HeaderText="Tipo de participante" AllowFiltering="false">
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="clave" DataField="clave" HeaderText="Clave" ShowFilterIcon="false" DataFormatString="{0:D6}" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="razon_social" DataField="razon_social" HeaderText="Razón Social" ShowFilterIcon="false" FilterControlWidth="150px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="nombre_completo" DataField="nombre_completo" HeaderText="Nombre" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="correo_electronico" DataField="correo_electronico" HeaderText="Correo Electrónico" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="genero" DataField="genero" HeaderText="Genero" Visible="false">
                                                <ItemStyle Wrap="false" />
                                                <FilterTemplate>
                                                    <telerik:RadComboBox ID="rcbGenero" runat="server" Width="160px" Height="100px" AutoPostBack="true" OnSelectedIndexChanged="FilterCombo_SelectedIndexChanged" Visible="false">
                                                    </telerik:RadComboBox>
                                                </FilterTemplate>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="estado_civil" DataField="estado_civil" HeaderText="Estado Civil" Visible="false">
                                                <ItemStyle Wrap="false" />
                                                <FilterTemplate>
                                                    <telerik:RadComboBox ID="rcbEstadoCivil" runat="server" Width="160px" Height="100px" AutoPostBack="true" OnSelectedIndexChanged="FilterCombo_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                </FilterTemplate>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridDateTimeColumn UniqueName="fecha_nacimiento" DataField="fecha_nacimiento" HeaderText="Fecha Aniversario" DataFormatString="{0:dd/MM/yyyy}" FilterControlWidth="100px">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridDateTimeColumn>
                                            <telerik:GridBoundColumn UniqueName="documento_identidad" DataField="documento_identidad" HeaderText="Documento Identidad" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"></telerik:GridBoundColumn>
                                            <telerik:GridDateTimeColumn UniqueName="fecha_alta" DataField="fecha_alta" HeaderText="Fecha Alta" DataFormatString="{0:dd/MM/yyyy}" FilterControlWidth="100px">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridDateTimeColumn>
                                            <telerik:GridDateTimeColumn UniqueName="fecha_status" DataField="fecha_status" HeaderText="Fecha Estatus" DataFormatString="{0:dd/MM/yyyy}" FilterControlWidth="100px">
                                                <HeaderStyle Wrap="false" />
                                                <ItemStyle Wrap="false" />
                                            </telerik:GridDateTimeColumn>
                                            <telerik:GridTemplateColumn FilterControlAltText="Acepta Términos" HeaderText="Acepta Términos" UniqueName="acepta_terminos" DataField="acepta_terminos" AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTerminos" runat="server" Text='<%# Eval("acepta_terminos")%>' Visible="false"></asp:Label>
                                                    <asp:Image ID="imgTerminos" runat="server" ImageUrl='<%# Eval("acepta_terminos").ToString() == "0" ? "style/images/no.gif" : "style/images/si.gif"%>' AlternateText='<%# Eval("acepta_terminos").ToString() == "0" ? "No" : "Si"%>' />

                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn DataField="informacion_email" FilterControlAltText="Acepta Email" HeaderText="Acepta Email" UniqueName="informacion_email" AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("informacion_email")%>' Visible="false"></asp:Label>
                                                    <asp:Image ID="imgEmail" runat="server" ImageUrl='<%# Eval("informacion_email").ToString() == "0" ? "style/images/no.gif" : "style/images/si.gif"%>' AlternateText='<%# Eval("informacion_email").ToString() == "0" ? "No" : "Si"%>' />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn DataField="informacion_sms" FilterControlAltText="Acepta SMS" HeaderText="Acepta SMS" UniqueName="informacion_sms" AllowFiltering="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSMS" runat="server" Text='<%# Eval("informacion_sms")%>' Visible="false"></asp:Label>
                                                    <asp:Image ID="imgSMS" runat="server" ImageUrl='<%# Eval("informacion_sms").ToString() == "0" ? "style/images/no.gif" : "style/images/si.gif"%>' AlternateText='<%# Eval("informacion_sms").ToString() == "0" ? "No" : "Si"%>' />

                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn UniqueName="escolaridad" DataField="escolaridad" HeaderText="Escolaridad" Visible="false">
                                                <ItemStyle Wrap="false" />
                                                <FilterTemplate>
                                                    <telerik:RadComboBox ID="rcbEscolaridad" runat="server" Width="160px" Height="100px" AutoPostBack="true" OnSelectedIndexChanged="FilterCombo_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                </FilterTemplate>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="ocupacion" DataField="ocupacion" HeaderText="Ocupación" Visible="false">
                                                <ItemStyle Wrap="false" />
                                                <FilterTemplate>
                                                    <telerik:RadComboBox ID="rcbOcupacion" runat="server" Width="160px" Height="100px" AutoPostBack="true" OnSelectedIndexChanged="FilterCombo_SelectedIndexChanged">
                                                    </telerik:RadComboBox>
                                                </FilterTemplate>
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn DataField="hijos" Visible="false"
                                                FilterControlAltText="Tiene hijos" HeaderText="Tiene hijos"
                                                UniqueName="hijos">
                                                <ItemStyle Wrap="false" />
                                                <ItemTemplate>
                                                    <%# Eval("hijos") == DBNull.Value ? "NO PROPORCIONADO" : Eval("hijos").ToString() == "0" ? "No" : "Si"%>
                                                </ItemTemplate>
                                                <FilterTemplate>
                                                    <telerik:RadComboBox ID="rcbTipodePX" runat="server" Width="60px" OnClientSelectedIndexChanged="SelectedIndexChanged"
                                                        SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("hijos").CurrentFilterValue %>'>
                                                        <Items>
                                                            <telerik:RadComboBoxItem Value="T" Text="Todo" />
                                                            <telerik:RadComboBoxItem Value=" " Text="NP" />
                                                            <telerik:RadComboBoxItem Value="0" Text="NO" />
                                                            <telerik:RadComboBoxItem Value="1" Text="SI" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                                    <telerik:RadScriptBlock ID="RadScriptBlock3" runat="server">
                                                        <script type="text/javascript">
                                                            function SelectedIndexChanged(sender, args) {
                                                                var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
                                                                if (args.get_item().get_value() == 'T') {
                                                                    tableView.get_filterExpressions().clear();
                                                                    tableView.rebind();
                                                                }
                                                                else
                                                                    tableView.filter("hijos", args.get_item().get_value(), "EqualTo");
                                                            }
                                                        </script>
                                                    </telerik:RadScriptBlock>
                                                </FilterTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridNumericColumn DecimalDigits="0" DataField="nhijos" HeaderText="No Hijos" FilterControlWidth="30px" Visible="false"
                                                UniqueName="nhijos">
                                            </telerik:GridNumericColumn>

                                        </Columns>
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

