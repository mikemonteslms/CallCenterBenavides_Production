<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="administracionPerfiles.aspx.cs" Inherits="ORMOperacion.administracionPerfiles" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <script type="text/javascript">
        var combo = null;
        function CloseActiveToolTip() {
            var tooltip = Telerik.Web.UI.RadToolTip.getCurrent();
            if (tooltip) tooltip.hide();
        }

    </script>
    <div id="rounded-box3">
        <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" OnAjaxUpdate="RadToolTipManager1_AjaxUpdate"
            RelativeTo="Element" Width="235px" Height="235px" Style="z-index: 31000" Position="BottomLeft" ContentScrolling="Auto"
            HideEvent="ManualClose" Title="Menú" ShowEvent="OnClick" >
        </telerik:RadToolTipManager>
        <table border="0">
            <tr align="center">
                <td class="texto18 negrita">
                    <table border="0" width="900px" height="400px">
                        <tr valign="top">
                            <td align="center">
                                <div style="width: 880px;">

                                    <h3>Administraci&oacute;n de roles</h3>


                                    <telerik:RadGrid ID="gridRoles" runat="server" 
                                        CellPadding="0" GridLines="None"
                                        CellSpacing="0" AllowSorting="True"
                                        AllowFilteringByColumn="True"
                                        EnableLinqExpressions="False" Culture="es-MX"
                                        OnNeedDataSource="gridRoles_NeedDataSource" AutoGenerateColumns="False" OnInsertCommand="gridRoles_InsertCommand" OnItemCommand="gridRoles_ItemCommand" OnUpdateCommand="gridRoles_UpdateCommand" OnItemDataBound="gridRoles_ItemDataBound" OnDataBound="gridRoles_DataBound">
                                        <ClientSettings AllowColumnsReorder="true">
                                        </ClientSettings>
                                        <MasterTableView CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnCurrentPage" EditMode="EditForms">
                                            <Columns>
                                                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="ColEditar" />
                                                <telerik:GridButtonColumn ConfirmText="¿Seguro que quiere eliminar el rol?" ConfirmDialogType="RadWindow"
                                                    ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" />
                                                <telerik:GridBoundColumn UniqueName="rol" DataField="rol" HeaderText="Nombre Rol" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                                    <HeaderStyle Wrap="false" />
                                                    <ItemStyle Wrap="false" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="AddMenu" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" NavigateUrl="#" onclick="return false;" Text="Administrar Menú"
                                                            ID="hlAddMenu">
                                                        </asp:HyperLink>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>

                                    </telerik:RadGrid>


                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
