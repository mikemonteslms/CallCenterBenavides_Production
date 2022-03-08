<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="mantenimientoFunciones.aspx.cs" Inherits="ORMOperacion.mantenimientoFunciones" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <table width="100%">
        <tr>
            <td>
                <div style="overflow: auto; width: 100%; height: 100%;">
                    <telerik:RadComboBox ID="rcbMenu" runat="server" Width="160px" Height="100px" AutoPostBack="true" OnSelectedIndexChanged="FilterCombo_SelectedIndexChanged" DataValueField="Nombre" DataTextField="Nombre">
                    </telerik:RadComboBox>

                    <telerik:RadGrid ID="gridFunciones" runat="server"
                        CellPadding="0" GridLines="None"
                        CellSpacing="0" AllowSorting="True" AllowPaging="true" PageSize="10"
                        AllowFilteringByColumn="True"
                        EnableLinqExpressions="False" Culture="es-MX"
                        OnNeedDataSource="gridFunciones_NeedDataSource" AutoGenerateColumns="False" OnInsertCommand="gridFunciones_InsertCommand"
                        OnItemDataBound="gridFunciones_ItemDataBound" OnItemCommand="gridFunciones_ItemCommand" OnUpdateCommand="gridFunciones_UpdateCommand"
                        OnItemCreated="gridFunciones_ItemCreated">
                        <ClientSettings AllowColumnsReorder="true">
                        </ClientSettings>
                        <MasterTableView DataKeyNames="id" CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnCurrentPage" EditMode="EditForms">
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"
                                Visible="True">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"
                                Visible="True">
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="ColEditar" />
                                <telerik:GridButtonColumn ConfirmText="Esta seguro que desea inactivar el registro?" ConfirmDialogType="RadWindow"
                                    ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" />
                                <telerik:GridBoundColumn UniqueName="id" DataField="id" HeaderText="id" Visible="false"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="menu_id" DataField="menu_id" HeaderText="menu_id" Visible="false"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="menu" DataField="menu" HeaderText="Menu">
                                    <ItemStyle Wrap="false" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="nombre" DataField="nombre" HeaderText="Nombre" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="url" DataField="url" HeaderText="URL" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                    <ItemStyle Wrap="false" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="imagen" DataField="imagen" HeaderText="Ruta imagen" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                    <ItemStyle Wrap="false" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="alt" DataField="alt" HeaderText="Texto Alterno" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                    <ItemStyle Wrap="false" />
                                </telerik:GridBoundColumn>
                                <telerik:GridNumericColumn UniqueName="orden" DataField="orden" HeaderText="Orden" FilterControlWidth="50px" Visible="false">
                                </telerik:GridNumericColumn>
                                <telerik:GridBoundColumn UniqueName="usuario_alta_id" DataField="usuario_alta_id" HeaderText="Usuario Alta" ShowFilterIcon="false" FilterControlWidth="130px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridDateTimeColumn UniqueName="fecha_alta" DataField="fecha_alta" HeaderText="Fecha Alta" Visible="false">
                                </telerik:GridDateTimeColumn>
                                <telerik:GridBoundColumn UniqueName="usuario_cambio_id" DataField="usuario_cambio_id" HeaderText="Usuario Cambio" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridDateTimeColumn UniqueName="fecha_cambio" DataField="fecha_cambio" HeaderText="Fecha Cambio" Visible="false">
                                </telerik:GridDateTimeColumn>
                                <telerik:GridBoundColumn UniqueName="usuario_baja_id" DataField="usuario_baja_id" HeaderText="Usuario Baja" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridDateTimeColumn UniqueName="fecha_baja" DataField="fecha_baja" HeaderText="Fecha Baja" Visible="false">
                                </telerik:GridDateTimeColumn>

                            </Columns>
                        </MasterTableView>

                    </telerik:RadGrid>
                </div>

            </td>
        </tr>
    </table>
</asp:Content>
