<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/aclaraciones.aspx.cs" Inherits="ORMOperacion.aclaraciones"
    MasterPageFile="~/contenido.Master" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
    <script type="text/javascript">
        function OnClientFolderChange(explorer, args) {
            explorer.clearFolderCache();
        }
    </script>
    <script>
        (function (global, undefined) {
            function OnClientFileOpen(oExplorer, args) {
                var item = args.get_item();
                var fileExtension = item.get_extension();
                // File is a image document, do not open a new window
                args.set_cancel(true);

                // Tell browser to open file directly
                var requestImage = "Handler.ashx?path=" + item.get_url();
                document.location = requestImage;
            }

            global.OnClientFileOpen = OnClientFileOpen;
        })(window);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <telerik:RadWindow runat="server" ID="window1" Modal="true" ReloadOnShow="true" EnableViewState="false"
                AutoSize="true" DestroyOnClose="true">
            </telerik:RadWindow>
        </ContentTemplate>
    </asp:UpdatePanel>
    <telerik:RadGrid runat="server" ID="aclaracionesGrid" DataSourceID="aclaracionesDS" AutoGenerateColumns="false">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="llamada_id" HeaderText="LlamadaId" UniqueName="LlamadaId">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="participante" HeaderText="Participante"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="nombre_llama" HeaderText="Nombre Llama"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="telefono" HeaderText="Telefono"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="fecha" HeaderText="Fecha"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="descripcion" HeaderText="Descripcion"></telerik:GridBoundColumn>
                <telerik:GridTemplateColumn>
                    <ItemTemplate>
                        <telerik:RadButton runat="server" ID="showFiles" OnClick="showFiles_Click" Text="Ver archivos" CommandArgument='<%# Bind("llamada_id") %>'
                            AutoPostBack="true">
                        </telerik:RadButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>


    <asp:SqlDataSource runat="server" ID="aclaracionesDS" ConnectionString="<%$ ConnectionStrings:GaleniaTest %>"
        ProviderName="System.Data.SqlClient" SelectCommand="select ll.id as llamada_id,
isnull(p.nombre + ' ' ,'') + isnull(p.apellido_paterno + ' ' ,'') + isnull(p.apellido_materno + ' ' ,'') as participante,
ll.nombre_llama, telefono, convert(varchar(20), ll.fecha, 113) as fecha, ll.descripcion,
u.UserName as usuario from llamada ll
inner join participante p on p.id = ll.participante_id
inner join aspnet_Users u on u.UserId = ll.usuario_id
inner join llamada_seguimiento ls on  ls.llamada_id = ll.id
inner join tipo_llamada tl on tl.id = ls.tipo_llamada_id
where tl.clave = 'ACLAPROG'" />
</asp:Content>
