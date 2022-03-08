<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="ReportePerfiles.aspx.cs" Inherits="ORMOperacion.Reportes.ReportePerfiles" %>

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
                                <telerik:AjaxUpdatedControl ControlID="tblResultados" />
                                <telerik:AjaxUpdatedControl ControlID="gridPoblacion" />
                                <telerik:AjaxUpdatedControl ControlID="rgGenero" />
                                <telerik:AjaxUpdatedControl ControlID="rhcGenero" />
                                <telerik:AjaxUpdatedControl ControlID="rgEdad" />
                                <telerik:AjaxUpdatedControl ControlID="rhcEdad" />
                                <telerik:AjaxUpdatedControl ControlID="rgNSE" />
                                <telerik:AjaxUpdatedControl ControlID="rhcNSE" />
                                <telerik:AjaxUpdatedControl ControlID="rhDiasTransacciones" />
                                <telerik:AjaxUpdatedControl ControlID="rhcDiasTransacciones" />
                                <telerik:AjaxUpdatedControl ControlID="rgDiasPrograma" />
                                <telerik:AjaxUpdatedControl ControlID="rhcDiasPrograma" />
                                <telerik:AjaxUpdatedControl ControlID="rgConEmail" />
                                <telerik:AjaxUpdatedControl ControlID="rhcConEmail" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="pnlFiltros">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="tblResultados" />
                                <telerik:AjaxUpdatedControl ControlID="gridPoblacion" />
                                <telerik:AjaxUpdatedControl ControlID="rgGenero" />
                                <telerik:AjaxUpdatedControl ControlID="rhcGenero" />
                                <telerik:AjaxUpdatedControl ControlID="rgEdad" />
                                <telerik:AjaxUpdatedControl ControlID="rhcEdad" />
                                <telerik:AjaxUpdatedControl ControlID="rgNSE" />
                                <telerik:AjaxUpdatedControl ControlID="rhcNSE" />
                                <telerik:AjaxUpdatedControl ControlID="rhDiasTransacciones" />
                                <telerik:AjaxUpdatedControl ControlID="rhcDiasTransacciones" />
                                <telerik:AjaxUpdatedControl ControlID="rgDiasPrograma" />
                                <telerik:AjaxUpdatedControl ControlID="rhcDiasPrograma" />
                                <telerik:AjaxUpdatedControl ControlID="rgConEmail" />
                                <telerik:AjaxUpdatedControl ControlID="rhcConEmail" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="pnlFiltros" runat="server">
                                <uc:Filtros ID="ucFiltros" runat="server" OnBuscarClicked="ucFiltros_BuscarClicked" />
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
                                <table width="80%" id="tblResultados" runat="server" style="display: none">
                                    <tr>
                                        <td class="texto14">País seleccionado: <b>
                                            <asp:Label ID="lblPais" runat="server" Text=""></asp:Label>
                                        </b>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <telerik:RadGrid ID="gridPoblacion" runat="server" Width="20%" CssClass="AddBorders"
                                                AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="Poblacion"
                                                            FilterControlAltText="Filter column column" HeaderText="Población"
                                                            UniqueName="column">
                                                            <ItemStyle BackColor="LightBlue" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="participantes"
                                                            FilterControlAltText="Filter column1 column" HeaderText="Participantes"
                                                            UniqueName="column1">
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table width="100%">
                                                <tr style="display: none">
                                                    <td colspan="2" align="center" class="texto14">Género
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" valign="middle">
                                                        <telerik:RadGrid ID="rgGenero" runat="server" Width="30%"
                                                            AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" CssClass="AddBorders"
                                                            GridLines="None" OnItemDataBound="rgGenero_ItemDataBound">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                            <MasterTableView>
                                                                <Columns>
                                                                    <telerik:GridBoundColumn DataField="Genero" HeaderText="genero"
                                                                        UniqueName="Genero">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="Hombres" HeaderText="Hombres"
                                                                        UniqueName="Hombres">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="Mujeres" HeaderText="Mujeres"
                                                                        UniqueName="Mujeres">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="NP" HeaderText="NP"
                                                                        UniqueName="NP">
                                                                    </telerik:GridBoundColumn>
                                                                </Columns>
                                                            </MasterTableView>
                                                        </telerik:RadGrid>
                                                    </td>
                                                    <td width="50%">
                                                        <telerik:RadHtmlChart runat="server" ID="rhcGenero"
                                                            Width="320" Height="350" Transitions="true">
                                                            <Legend>
                                                                <Appearance Position="Bottom" />
                                                            </Legend>
                                                        </telerik:RadHtmlChart>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="2" align="center" class="texto14">Edad
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td witdh="50%" valign="middle">
                                                        <telerik:RadGrid ID="rgEdad" runat="server" Width="40%" CssClass="AddBorders"
                                                            AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                            <MasterTableView>
                                                                <Columns>
                                                                    <telerik:GridBoundColumn DataField="edad"
                                                                        FilterControlAltText="Filter column column" HeaderText="Edad"
                                                                        UniqueName="column">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField=" <=35"
                                                                        FilterControlAltText="Filter column1 column" HeaderText="<=35"
                                                                        UniqueName="column1">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="36-55"
                                                                        FilterControlAltText="Filter column2 column" HeaderText="36-55"
                                                                        UniqueName="column2">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="56-70"
                                                                        FilterControlAltText="Filter column3 column" HeaderText="56-70"
                                                                        UniqueName="column3">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField=" > 70"
                                                                        FilterControlAltText="Filter column4 column" HeaderText=">70"
                                                                        UniqueName="column4">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="NP"
                                                                        FilterControlAltText="Filter column8 column" HeaderText="NP"
                                                                        UniqueName="column8">
                                                                    </telerik:GridBoundColumn>
                                                                </Columns>
                                                            </MasterTableView>
                                                        </telerik:RadGrid>
                                                    </td>
                                                    <td width="50%">
                                                        <telerik:RadHtmlChart runat="server" ID="rhcEdad" Width="320" Height="350" Transitions="true">
                                                            <Legend>
                                                                <Appearance Position="Bottom" />
                                                            </Legend>
                                                        </telerik:RadHtmlChart>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="2" align="center" class="texto14">Nivel SocioEconómico
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" valign="middle">
                                                        <telerik:RadGrid ID="rgNSE" runat="server" Width="50%" CssClass="AddBorders"
                                                            AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                            <MasterTableView>
                                                                <Columns>
                                                                    <telerik:GridBoundColumn DataField="nse1"
                                                                        FilterControlAltText="Filter column column" HeaderText="nse1"
                                                                        UniqueName="column">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="AB"
                                                                        FilterControlAltText="Filter column1 column" HeaderText="AB"
                                                                        UniqueName="column1">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="C"
                                                                        FilterControlAltText="Filter column2 column" HeaderText="C"
                                                                        UniqueName="column2">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="C+"
                                                                        FilterControlAltText="Filter column3 column" HeaderText="C+"
                                                                        UniqueName="column3">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="D"
                                                                        FilterControlAltText="Filter column4 column" HeaderText="D"
                                                                        UniqueName="column4">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="D+"
                                                                        FilterControlAltText="Filter column5 column" HeaderText="D+"
                                                                        UniqueName="column5">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="E"
                                                                        FilterControlAltText="Filter column6 column" HeaderText="E"
                                                                        UniqueName="column6">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="RURAL"
                                                                        FilterControlAltText="Filter column7 column" HeaderText="RURAL"
                                                                        UniqueName="column7">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="NP"
                                                                        FilterControlAltText="Filter column8 column" HeaderText="NP"
                                                                        UniqueName="column8">
                                                                    </telerik:GridBoundColumn>
                                                                </Columns>
                                                            </MasterTableView>
                                                        </telerik:RadGrid>
                                                    </td>
                                                    <td width="50%">
                                                        <telerik:RadHtmlChart runat="server" ID="rhcNSE" Width="320" Height="350" Transitions="true">
                                                            <Legend>
                                                                <Appearance Position="Bottom" />
                                                            </Legend>
                                                        </telerik:RadHtmlChart>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="2" align="center" class="texto14">Días con transacciones
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" valign="middle">
                                                        <telerik:RadGrid ID="rhDiasTransacciones" runat="server" Width="60%" CssClass="AddBorders"
                                                            AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                            <MasterTableView>
                                                                <Columns>
                                                                    <telerik:GridBoundColumn DataField="dias_con_transaci"
                                                                        FilterControlAltText="Filter column column" HeaderText="Dias con transacciones"
                                                                        UniqueName="column">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField=" < 29"
                                                                        FilterControlAltText="Filter column1 column" HeaderText="<29"
                                                                        UniqueName="column1">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="29-56"
                                                                        FilterControlAltText="Filter column2 column" HeaderText="29-56"
                                                                        UniqueName="column2">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="57-84"
                                                                        FilterControlAltText="Filter column3 column" HeaderText="57-84"
                                                                        UniqueName="column3">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="85-112"
                                                                        FilterControlAltText="Filter column4 column" HeaderText="85-112"
                                                                        UniqueName="column4">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="113-140"
                                                                        FilterControlAltText="Filter column5 column" HeaderText="113-140"
                                                                        UniqueName="column5">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField=" > 140"
                                                                        FilterControlAltText="Filter column6 column" HeaderText=">140"
                                                                        UniqueName="column6">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="NP"
                                                                        FilterControlAltText="Filter column7 column" HeaderText="NP"
                                                                        UniqueName="column7">
                                                                    </telerik:GridBoundColumn>
                                                                </Columns>
                                                            </MasterTableView>
                                                        </telerik:RadGrid>
                                                    </td>
                                                    <td width="50%">
                                                        <telerik:RadHtmlChart runat="server" ID="rhcDiasTransacciones" Width="320" Height="350" Transitions="true">
                                                            <Legend>
                                                                <Appearance Position="Bottom" />
                                                            </Legend>
                                                        </telerik:RadHtmlChart>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="2" align="center" class="texto14">Días en el programa
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" valign="middle">
                                                        <telerik:RadGrid ID="rgDiasPrograma" runat="server" Width="60%" CssClass="AddBorders"
                                                            AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                            <MasterTableView>
                                                                <Columns>
                                                                    <telerik:GridBoundColumn DataField="dias_en_el_programa"
                                                                        FilterControlAltText="Filter column column" HeaderText="Dias en el programa"
                                                                        UniqueName="column">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="menor-29"
                                                                        FilterControlAltText="Filter column1 column" HeaderText="<29"
                                                                        UniqueName="column1">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="29-56"
                                                                        FilterControlAltText="Filter column2 column" HeaderText="29-56"
                                                                        UniqueName="column2">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="57-84"
                                                                        FilterControlAltText="Filter column3 column" HeaderText="57-84"
                                                                        UniqueName="column3">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="85-112"
                                                                        FilterControlAltText="Filter column4 column" HeaderText="85-112"
                                                                        UniqueName="column4">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="113-140"
                                                                        FilterControlAltText="Filter column5 column" HeaderText="113-140"
                                                                        UniqueName="column5">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="mayor-140"
                                                                        FilterControlAltText="Filter column6 column" HeaderText="> 140"
                                                                        UniqueName="column6">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="NP"
                                                                        FilterControlAltText="Filter column7 column" HeaderText="NP"
                                                                        UniqueName="column7">
                                                                    </telerik:GridBoundColumn>
                                                                </Columns>
                                                            </MasterTableView>
                                                        </telerik:RadGrid>
                                                    </td>
                                                    <td width="50%">
                                                        <telerik:RadHtmlChart runat="server" ID="rhcDiasPrograma" Width="320" Height="350" Transitions="true">
                                                            <Legend>
                                                                <Appearance Position="Bottom" />
                                                            </Legend>
                                                        </telerik:RadHtmlChart>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <table width="100%">
                                                <tr>
                                                    <td colspan="2" align="center">Email
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" valign="middle">
                                                        <telerik:RadGrid ID="rgConEmail" runat="server" Width="30%" CssClass="AddBorders"
                                                            AutoGenerateColumns="False" CellSpacing="0" Culture="es-ES" GridLines="None">
                                                            <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                            <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                                            <MasterTableView>
                                                                <Columns>
                                                                    <telerik:GridBoundColumn DataField="con_email"
                                                                        FilterControlAltText="Filter column column" HeaderText="Con Email"
                                                                        UniqueName="column">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="si"
                                                                        FilterControlAltText="Filter column1 column" HeaderText="Si"
                                                                        UniqueName="column1">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="no"
                                                                        FilterControlAltText="Filter column2 column" HeaderText="No"
                                                                        UniqueName="column2">
                                                                    </telerik:GridBoundColumn>
                                                                </Columns>
                                                            </MasterTableView>
                                                        </telerik:RadGrid>
                                                    </td>
                                                    <td width="50%">
                                                        <telerik:RadHtmlChart runat="server" ID="rhcConEmail" Width="320" Height="350" Transitions="true">
                                                            <Legend>
                                                                <Appearance Position="Bottom" />
                                                            </Legend>
                                                        </telerik:RadHtmlChart>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" style="display: none" id="tblNoRegistros" runat="server" class="texto13">
                                    <tr>
                                        <td>No se encontraron registros para la busqueda seleccionada.
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>

