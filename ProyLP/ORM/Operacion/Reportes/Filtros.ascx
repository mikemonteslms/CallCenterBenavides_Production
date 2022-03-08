<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Filtros.ascx.cs" Inherits="ORMOperacion.Reportes.Filtros" %>







<%@ Register Assembly="Telerik.OpenAccess.Web.40, Version=2014.3.1027.1, Culture=neutral, PublicKeyToken=7ce17eeaf1d59342" Namespace="Telerik.OpenAccess.Web" TagPrefix="telerik" %>
<table width="100%">
    <tr>
        <td>
            <h4>
                <asp:Label ID="lblRuta" runat="server" Text=""></asp:Label></h4>
        </td>
    </tr>
</table>
<table width="100%">
    <tr id="trFechas" runat="server">
        <td>
            <table width="100%" id="tblFechaInicio" runat="server">
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="lblFechaInicio" runat="server" Text="Fecha Inicio:" CssClass="texto13"></asp:Label>
                    </td>

                    <td width="50%">
                        <telerik:RadDatePicker ID="rdpFechaInicial" runat="server">
                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                ViewSelectorText="x">
                            </Calendar>

                            <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" DisplayText="" LabelWidth="40%" type="text" value=""></DateInput>

                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                </tr>
            </table>
        </td>
        <td>
            <table width="100%" id="tblFechaFin" runat="server">
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="lblFechaFin" runat="server" Text="Fecha Final:" CssClass="texto13"></asp:Label>
                    </td>
                    <td width="50%">
                        <telerik:RadDatePicker ID="rdpFechaFinal" runat="server">
                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                ViewSelectorText="x">
                            </Calendar>

                            <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" DisplayText="" LabelWidth="40%" type="text" value=""></DateInput>

                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" id="table1" runat="server" style="display: none">
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="Listado1" runat="server" Text="" CssClass="texto13"></asp:Label>
                    </td>
                    <td width="50%">
                        <telerik:RadComboBox ID="rcbListado1" runat="server" OnSelectedIndexChanged="rcbListado1_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </td>
                </tr>
            </table>
        </td>
        <td>
            <table width="100%" id="table2" runat="server" style="display: none">
                <tr id="tr1" runat="server">
                    <td align="right" width="50%">
                        <asp:Label ID="Listado2" runat="server" Text="" CssClass="texto13"></asp:Label>
                    </td>
                    <td width="50%">
                        <telerik:RadComboBox ID="rcbListado2" runat="server">
                        </telerik:RadComboBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" id="table3" runat="server" style="display: none">
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="Listado3" runat="server" Text="" CssClass="texto13"></asp:Label>
                    </td>
                    <td width="50%">
                        <telerik:RadComboBox ID="rcbListado3" runat="server">
                        </telerik:RadComboBox>
                    </td>
                </tr>
            </table>
        </td>
        <td>
            <table width="100%" id="table4" runat="server" style="display: none">
                <tr id="tr2" runat="server">
                    <td align="right" width="50%">
                        <asp:Label ID="Listado4" runat="server" Text="" CssClass="texto13"></asp:Label>
                    </td>
                    <td width="50%">
                        <telerik:RadComboBox ID="rcbListado4" runat="server">
                        </telerik:RadComboBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="4" align="center">
            <telerik:RadButton ID="ibtnBuscar" runat="server" Text="Buscar" OnClick="ibtn_Click" CommandName="Buscar" CssClass="negrita" ToolTip="Buscar" />
            <telerik:RadButton ID="ibtnExportar" runat="server" Text="Exportar" OnClick="ibtn_Click" CommandName="Exportar" CssClass="negrita" ToolTip="Exportar" />
        </td>

    </tr>
</table>
<table width="100%">
    <tr>
        <td>&nbsp;</td>
    </tr>
</table>


<telerik:OpenAccessLinqDataSource ID="OpenAccessLinqDataSource1"
    runat="server" />



