<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AgregarFuncionesRol.ascx.cs" Inherits="ORMOperacion.AgregarFuncionesRol" %>
<table width="100%">
    <tr>
        <td style="display: none">
            <asp:Label ID="lblRol" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="boton negrita sin_borde" />
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadTreeView runat="server" ID="RadTreeView1" DataSourceID="SqlDataSource1"
                DataFieldID="id" DataFieldParentID="menu_ID" CheckBoxes="true" OnNodeDataBound="RadTreeView1_NodeDataBound" DataValueField="id">
                <DataBindings>
                    <telerik:RadTreeNodeBinding TextField="nombre"></telerik:RadTreeNodeBinding>
                    <telerik:RadTreeNodeBinding Depth="0" Checkable="false" TextField="nombre" Expanded="true" CssClass="negrita"></telerik:RadTreeNodeBinding>
                </DataBindings>
            </telerik:RadTreeView>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btnActualizar1" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="boton negrita sin_borde" />
        </td>
    </tr>
</table>



<asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:GaleniaTest %>"
    ProviderName="System.Data.SqlClient" SelectCommand="sp_menu_rol" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:ControlParameter ControlID="hidRol" Name="rol" />
    </SelectParameters>
</asp:SqlDataSource>

<asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:GaleniaTest %>"
    ProviderName="System.Data.SqlClient" SelectCommand="sp_menu_rol" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:ControlParameter ControlID="lblRol" Name="rol" />
    </SelectParameters>
</asp:SqlDataSource>
<asp:HiddenField ID="hidRol" runat="server" Value="Todos" />
