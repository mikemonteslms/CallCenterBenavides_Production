<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mantenimientoBeneficios.aspx.cs" Inherits="ORMOperacion.mantenimientoBeneficios"
    MasterPageFile="~/contenido.Master" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>
<%@ Register Assembly="Telerik.OpenAccess.Web.40, Version=2014.3.1027.1, Culture=neutral, PublicKeyToken=7ce17eeaf1d59342" Namespace="Telerik.OpenAccess.Web" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <telerik:OpenAccessLinqDataSource ID="OABeneficios" runat="server"
        ContextTypeName="EntitiesModel.EntitiesModel" EntityTypeName="" EnableUpdate="true" EnableDelete="true" EnableInsert="true"
        ResourceSetName="beneficios" OrderBy="id,clave" OnInserting="OABeneficios_Inserting" />

    <telerik:OpenAccessLinqDataSource ID="OAProgramas" runat="server"
        ContextTypeName="EntitiesModel.EntitiesModel" EntityTypeName=""
        ResourceSetName="programas" OrderBy="id,clave" />
    <telerik:OpenAccessLinqDataSource ID="OAProductos" runat="server"
        ContextTypeName="EntitiesModel.EntitiesModel" EntityTypeName=""
        ResourceSetName="productos" OrderBy="id,clave" />
    <telerik:OpenAccessLinqDataSource ID="OAPremios" runat="server"
        ContextTypeName="EntitiesModel.EntitiesModel" EntityTypeName=""
        ResourceSetName="premios" OrderBy="id,clave" />

    <telerik:RadGrid ID="rgBeneficios" runat="server" DataSourceID="OABeneficios" MasterTableView-CommandItemDisplay="TopAndBottom"
        AutoGenerateEditColumn="true" OnInsertCommand="rgBeneficios_InsertCommand" >
        <MasterTableView DataKeyNames="id" AutoGenerateColumns="false" AllowAutomaticInserts="true" AllowAutomaticDeletes="true" AllowAutomaticUpdates="true">
            <Columns>
                <telerik:GridBoundColumn DataField="clave" HeaderText="Clave" UniqueName="clave"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="descripcion" HeaderText="Descripcion" UniqueName="descripcion"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="descripcion_larga" HeaderText="Descripcion Larga" UniqueName="descripcion_larga"></telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Programa">
                    <ItemTemplate>
                        <asp:Label ID="programa" runat="server" Text='<%# Bind("programa.descripcion") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <telerik:RadDropDownList ID="programaList" runat="server"
                            DataSourceID="OAProgramas" DataValueField="id" DataTextField="descripcion"
                            UniqueName="programas">
                        </telerik:RadDropDownList>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Seleccione el tipo de beneficio" Display="false">
                    <EditItemTemplate>
                        <telerik:RadDropDownList runat="server" ID="rdTipo" OnItemSelected="rdTipo_ItemSelected" AutoPostBack="true"
                            DefaultMessage="Seleccione tipo">
                            <Items>
                                <telerik:DropDownListItem Value="prod" Text="Producto" />
                                <telerik:DropDownListItem Value="prem" Text="Premio" />
                            </Items>
                        </telerik:RadDropDownList>
                        <telerik:RadDropDownList ID="productoList" runat="server"
                            DataSourceID="OAProductos" DataValueField="id" DataTextField="descripcion"
                            Visible="false" DefaultMessage="Seleccione producto" UniqueName="productos">
                        </telerik:RadDropDownList>
                        <telerik:RadDropDownList ID="premioList" runat="server"
                            DataSourceID="OAPremios" DataValueField="id" DataTextField="descripcion"
                            Visible="false" DefaultMessage="Seleccione premio" UniqueName="premios">
                        </telerik:RadDropDownList>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Premio">
                    <ItemTemplate>
                        <asp:Label ID="premio" runat="server" Text='<%# Bind("premio.descripcion") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Producto">
                    <ItemTemplate>
                        <asp:Label ID="producto" runat="server" Text='<%# Bind("producto.descripcion") %>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>

    </telerik:RadGrid>

</asp:Content>
