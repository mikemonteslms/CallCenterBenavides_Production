<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true"
    CodeBehind="~/editor/mecanica.aspx.cs" Inherits="ORMOperacion.editor.mecanica" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
    <link href="css/EditorContentStylesMecanica.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <telerik:RadComboBox runat="server" ID="programas"
        DataSourceID="programaDS" DataValueField="id" DataTextField="descripcion"
        OnSelectedIndexChanged="programas_SelectedIndexChanged" AutoPostBack="true">
        <DefaultItem Value="0" Text="Seleccionar Programa"/>
    </telerik:RadComboBox>
    <div>
        <telerik:RadEditor Height="500px" ID="RadEditor1" runat="server"
            EditModes="All" Width="95%" AllowScripts="true" ContentAreaMode="Div"
            ContentAreaCssFile="EditorContentAreaStyles.css" RenderMode="Auto" EnableEmbeddedScripts="true">
            <ImageManager ViewPaths="~/images" UploadPaths="~/images" MaxUploadFileSize="10240000" />
            <DocumentManager ViewPaths="~/docs" UploadPaths="~/docs" MaxUploadFileSize="10240000" />
            <CssFiles>
                <telerik:EditorCssFile Value="../style/css/extras.css" />
                <telerik:EditorCssFile Value="../src/perfect-scrollbar.css" />
                <telerik:EditorCssFile Value="../style/css/smk-accordion.css" />
            </CssFiles>
            <Modules>
                <telerik:EditorModule Name="RadEditorStatistics" Enabled="false"></telerik:EditorModule>
            </Modules>
        </telerik:RadEditor>
        <telerik:RadButton runat="server" ID="btnGuardar" Text="Guardar Html" OnClick="btnGuardar_Click"></telerik:RadButton>

        <telerik:RadTextBox runat="server" ID="editorText"></telerik:RadTextBox>
    </div>
    <asp:SqlDataSource runat="server" ID="programaDS" ConnectionString="<%$ ConnectionStrings:GaleniaTest %>"
        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [descripcion] FROM [Programa] ORDER By descripcion" />


    <telerik:RadAjaxManager runat="server" ID="AjaxManager1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadioButtonListContentAreaMode">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadEditor1" />
                    <telerik:AjaxUpdatedControl ControlID="RadioButtonListContentAreaMode" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
