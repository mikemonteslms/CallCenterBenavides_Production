<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mantenimientoprogramas.aspx.cs" Inherits="ORMOperacion.mantenimientoprogramas"
    MasterPageFile="~/contenido.Master" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>
<%@ Register Assembly="Telerik.OpenAccess.Web.40, Version=2014.3.1027.1, Culture=neutral, PublicKeyToken=7ce17eeaf1d59342" Namespace="Telerik.OpenAccess.Web" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
    <link id="styCalendario" runat="server" rel="stylesheet" type="text/css" />
    <style>
        .columnaurl {
            word-break: break-all;
        }

        .img_logo img {
            width: 125px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <asp:SqlDataSource runat="server" ID="dsPrograma" SelectCommand="select * from programa" ConnectionString="<%$ ConnectionStrings:GaleniaTest %>"></asp:SqlDataSource>
    <telerik:OpenAccessLinqDataSource ID="OAPrograma" runat="server"
        ContextTypeName="EntitiesModel.EntitiesModel" EntityTypeName="" EnableUpdate="true" EnableDelete="true" EnableInsert="true"
        ResourceSetName="programas" OrderBy="id,clave" OnInserting="OAPrograma_Inserting" OnUpdating="OAPrograma_Updating"/>


    <telerik:RadGrid runat="server" ID="rgPrograma" DataSourceID="OAPrograma" AutoGenerateColumns="false" AllowAutomaticUpdates="true"
        AllowAutomaticDeletes="true"
        MasterTableView-EditFormSettings-EditColumn-InsertText="Insertar"
        MasterTableView-EditFormSettings-EditColumn-EditText="Editar"
        MasterTableView-EditFormSettings-EditColumn-UpdateText="Actualizar"
        MasterTableView-EditFormSettings-EditColumn-CancelText="Cancelar"
        MasterTableView-CommandItemSettings-RefreshText="Refrescar"
        AutoGenerateEditColumn="true">
        <MasterTableView CommandItemDisplay="TopAndBottom" DataKeyNames="id" AllowAutomaticDeletes="true" AllowAutomaticInserts="true" AllowAutomaticUpdates="true"
            CommandItemSettings-AddNewRecordText="Agregar nueva Encuesta" Name="Programas">
            <Columns>
                <telerik:GridBoundColumn UniqueName="clave" DataField="clave" HeaderText="Clave"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="descripcion" DataField="descripcion" HeaderText="Descripcion"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="descripcion_larga" DataField="descripcion_larga" HeaderText="Descripcion Larga"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="correo_electronico" DataField="correo_electronico" HeaderText="Correo Electronico"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="remitente" DataField="remitente" HeaderText="remitente"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="servidor_pop" DataField="servidor_pop" HeaderText="Servidor pop"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="servidor_smtp" DataField="servidor_smtp" HeaderText="Servidor smtp"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="logo" DataField="logo" HeaderText="Logo"></telerik:GridBoundColumn>
                <telerik:GridBinaryImageColumn UniqueName="imagen_logo" DataField="imagen_logo" HeaderText="Imagen Logo"
                    ItemStyle-CssClass="img_logo">
                </telerik:GridBinaryImageColumn>
                <telerik:GridBoundColumn UniqueName="url_facebook" DataField="url_facebook" HeaderText="url Facebook" ItemStyle-CssClass="columnaurl">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="url_twitter" DataField="url_twitter" HeaderText="url Twitter" ItemStyle-CssClass="columnaurl"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="copyright" DataField="copyright" HeaderText="copyright"></telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
