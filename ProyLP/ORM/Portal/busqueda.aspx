<%@ page title="" language="C#" masterpagefile="~/contenido.master" autoeventwireup="true" codebehind="busqueda.aspx.cs" inherits="Portal.busqueda" %>

<%@ mastertype virtualpath="~/contenido.master" %>

<asp:content id="Content1" contentplaceholderid="contenido_head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="contenido_body" runat="server">
    <div id="contenedor" class="main">
        <main id="mi-perfil">
<h3>Busqueda</h3>
            	<section id="categorias" style="width:185px!important;">
    	
       <ul>
           <li><p>Buscar por</p></li>
</ul>
                    </section>
            <section id="cuadrilla-productos" style="border:0; max-width:808px!important">
                <asp:Panel id="pnlBusqueda" runat="server" DefaultButton="lnkBuscar">
                <asp:TextBox id="txtBusqueda" runat="server" class="nombre-vendedor"></asp:TextBox><asp:LinkButton id="lnkBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="boton-gris" style="padding: 8px 10px 7px 10px;"></asp:LinkButton>
</asp:Panel>
                                <telerik:RadGrid runat="server" ID="radBusqueda" AllowPaging="True" AllowSorting="true" Skin="Metro"
                        AllowFilteringByColumn="true" EnableEmbeddedSkins="true" GroupingSettings-CaseSensitive="false" OnNeedDataSource="radBusqueda_NeedDataSource">
                        <MasterTableView AutoGenerateColumns="false">
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
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </section>
            </main>
        </div>
</asp:content>
