<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="busqueda.aspx.cs" Inherits="ORMOperacion.busqueda" %>

<%@ MasterType VirtualPath="~/contenido.master" %>
<%@ Register Assembly="BotonEnviar" Namespace="BotonEnviar" TagPrefix="cc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>
        <table border="0" width="100%">
            <tr>
                <td align="center">
                    <h4>Busqueda</h4>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid runat="server" ID="radBusqueda" AllowPaging="True" AllowSorting="true"
                        OnNeedDataSource="radBusqueda_NeedDataSource" AllowFilteringByColumn="true" EnableEmbeddedSkins="true" 
                        GroupingSettings-CaseSensitive="false" OnItemDataBound="radBusqueda_ItemDataBound" >
                        <MasterTableView AutoGenerateColumns="false" DataKeyNames="status_participante, islockedout">
                            <Columns>
                                <telerik:GridTemplateColumn AllowFiltering="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkSeleccionar" runat="server" CommandName="seleccionar" CommandArgument='<%# Eval("id") %>' OnCommand="lnkSeleccionar_Command" Text="Seleccionar"></asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn AllowFiltering="true" AllowSorting="true" DataField="programa" HeaderText="Programa" ShowFilterIcon="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn AllowFiltering="true" AllowSorting="true" DataField="clave_distribuidor" HeaderText="Clave distribuidor" ShowFilterIcon="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn AllowFiltering="true" AllowSorting="true" DataField="distribuidor" HeaderText="Distribuidor" ShowFilterIcon="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn AllowFiltering="true" AllowSorting="true" DataField="clave" HeaderText="Clave" ShowFilterIcon="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn AllowFiltering="true" AllowSorting="true" DataField="nombrecompleto" HeaderText="Nombre" ShowFilterIcon="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn AllowFiltering="true" AllowSorting="true" DataField="status_participante" HeaderText="Status" ShowFilterIcon="true"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn AllowFiltering="true" AllowSorting="true" DataField="telefono" HeaderText="Teléfono" ShowFilterIcon="true"></telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn AllowFiltering="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkRegistrar" runat="server" Text="Registrar" Visible="false" CommandName="registro" CommandArgument='<%# Eval("id") %>' OnCommand="lnkSeleccionar_Command"></asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
        </center>
</asp:Content>
