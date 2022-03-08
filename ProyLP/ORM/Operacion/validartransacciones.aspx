<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="validartransacciones.aspx.cs" Inherits="ORMOperacion.validartransacciones" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
    <script>
        function ConfirmaAutorizacion() {
            return confirm("¿Seguro que desea autorizar este registro?");
        }
    </script>
    <style>
        .RadGrid_Bootstrap .rgMasterTable, .RadGrid_Bootstrap .rgDetailTable, .RadGrid_Bootstrap .rgGroupPanel table, .RadGrid_Bootstrap .rgCommandRow table, .RadGrid_Bootstrap .rgEditForm table, .RadGrid_Bootstrap .rgPager {
            font-size: 11px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radTransacciones">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radTransacciones"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        <div style="width: 100%; height: 100%; margin: auto;">
            <img src="images/pill.png" />
        </div>
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadGrid ID="radTransacciones" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="3"
        OnNeedDataSource="radTransacciones_NeedDataSource" OnUpdateCommand="radTransacciones_UpdateCommand" OnItemCreated="radTransacciones_ItemCreated">
        <GroupingSettings CaseSensitive="false" />
        <MasterTableView DataKeyNames="ID" AllowFilteringByColumn="true" Width="800px">
            <Columns>
                <telerik:GridEditCommandColumn ButtonType="ImageButton" EditImageUrl="images/guias/guias.png" UpdateText="Actualizar" CancelText="Cancelar" EditText="Modificar"></telerik:GridEditCommandColumn>
                <telerik:GridTemplateColumn AllowFiltering="false">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnAutorizar" runat="server" ImageUrl="~/images/guias/tips.png" AlternateText="Autorizar" ToolTip="Autorizar" OnCommand="btnAutorizar_Command" CommandName="autorizar" CommandArgument='<%# Eval("ID") %>' OnClientClick="if ( ! ConfirmaAutorizacion()) return false;" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridNumericColumn AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" DataField="PacienteID" HeaderText="# Paciente" ShowFilterIcon="true" UniqueName="paciente_id" ReadOnly="true" FilterControlWidth="50px">
                    <ItemStyle Width="40px" />
                </telerik:GridNumericColumn>
                <telerik:GridBoundColumn AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="PacienteNombre" HeaderText="Paciente" ShowFilterIcon="true" UniqueName="paciente" ReadOnly="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="Cuenta" HeaderText="# Cuenta" ShowFilterIcon="true" UniqueName="cuenta" ReadOnly="true"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="Descripcion" HeaderText="Descripción" ShowFilterIcon="true" UniqueName="descripcion" ReadOnly="true"></telerik:GridBoundColumn>
                <telerik:GridNumericColumn AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" DataField="MedicoID" HeaderText="# Medico" ShowFilterIcon="true" UniqueName="medico_id" ReadOnly="true" FilterControlWidth="50px">
                    <ItemStyle Width="40px" />
                </telerik:GridNumericColumn>
                <telerik:GridBoundColumn AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="MedicoNombre" HeaderText="Medico" ShowFilterIcon="true" UniqueName="medico" ReadOnly="true" FilterControlWidth="50px">
                    <ItemStyle Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="Factura" HeaderText="# Factura" ShowFilterIcon="true" UniqueName="factura" ReadOnly="true" FilterControlWidth="50px">
                    <ItemStyle Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="Tarjeta" HeaderText="Tarjeta" ShowFilterIcon="true" UniqueName="tarjeta" ReadOnly="true" FilterControlWidth="50px">
                    <ItemStyle Width="40px" />
                </telerik:GridBoundColumn>
                <telerik:GridDateTimeColumn AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" DataField="Fecha" HeaderText="Fecha" ShowFilterIcon="true" UniqueName="fecha" ReadOnly="true" DataFormatString="{0:dd/MM/yyy}"></telerik:GridDateTimeColumn>
                <telerik:GridNumericColumn AllowFiltering="false" DataField="Importe" HeaderText="Importe" UniqueName="importe" DataFormatString="{0:C2}">
                    <ItemStyle HorizontalAlign="Right" />
                </telerik:GridNumericColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
