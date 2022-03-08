<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="mantenimientoMenu.aspx.cs" Inherits="ORMOperacion.mantenimientoMenu" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <table width="100%">
        <tr>
            <td>
                <div style="overflow: auto; width: 1100px; height: 100%;">

                    <telerik:RadGrid ID="gridMenu" runat="server" CellPadding="0" GridLines="None" CellSpacing="0"
                        AllowSorting="True" AllowFilteringByColumn="True" EnableLinqExpressions="False" Culture="es-MX"
                        OnNeedDataSource="gridMenu_NeedDataSource" AutoGenerateColumns="False" OnInsertCommand="gridMenu_InsertCommand"
                        OnItemDataBound="gridMenu_ItemDataBound" OnItemCommand="gridMenu_ItemCommand" OnUpdateCommand="gridMenu_UpdateCommand">
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
                                <telerik:GridButtonColumn ConfirmText="Esta seguro que desea eliminarlo?" ConfirmDialogType="RadWindow"
                                    ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" />
                                <telerik:GridBoundColumn UniqueName="id" DataField="id" HeaderText="id" Visible="false"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="nombre" DataField="nombre" HeaderText="Nombre" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                    <HeaderStyle Wrap="false" />
                                    <ItemStyle Wrap="false" />
                                </telerik:GridBoundColumn>
                                <telerik:GridNumericColumn UniqueName="orden" DataField="orden" HeaderText="Orden">
                                </telerik:GridNumericColumn>
                                <%--                                    <telerik:GridBoundColumn UniqueName="usuario_alta_id" DataField="usuario_alta_id" HeaderText="Usuario Alta" ShowFilterIcon="false" FilterControlWidth="130px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="usuario_cambio_id" DataField="usuario_cambio_id" HeaderText="Usuario Cambio" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridDateTimeColumn UniqueName="fecha_cambio" DataField="fecha_cambio" HeaderText="Fecha Cambio">
                                    </telerik:GridDateTimeColumn>
                                    <telerik:GridBoundColumn UniqueName="usuario_baja_id" DataField="usuario_baja_id" HeaderText="Usuario Baja" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridDateTimeColumn UniqueName="fecha_baja" DataField="fecha_baja" HeaderText="Fecha Baja">
                                    </telerik:GridDateTimeColumn>--%>
                            </Columns>
                        </MasterTableView>

                    </telerik:RadGrid>
                </div>

            </td>
        </tr>
    </table>
</asp:Content>
