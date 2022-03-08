<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.master" AutoEventWireup="true" CodeBehind="asignacionventas.aspx.cs" Inherits="Portal.asignacionventas" %>

<%@ MasterType VirtualPath="~/contenido.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contenido_head" runat="server">
    <style>
        #cuadrilla-vendedores {
            height: 430px !important;
            width: 802px !important;
            overflow: hidden;
            position: absolute;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function ($) {
            $('#cuadrilla-vendedores').perfectScrollbar({
                wheelSpeed: 15,
                wheelPropagation: false
            });
        });
    </script>
    <style>
        .rgHeader {
            background-color: #2274AC;
            height: 19px !important;
            color: #ffffff !important;
        }

        .rgFilterRow {
            height: 17px !important;
        }

        .RadGrid .rgFilterRow input {
            width: 100px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido_body" runat="server">
    <div id="contenedor" class="main">
        <main>

<h3>Asignación de Ventas</h3>
    <asp:MultiView id="mvVendedores" runat="server">
        <asp:View id="vListaVendedores" runat="server">
	<section id="categorias" style="width:185px!important;">
    	
       <ul>
           <li><p>Ventas por asignar</p></li>
            <li><p>&nbsp;</p></li>
        	<li><p>Mi Fuerza de Ventas</p></li>
        </ul>
        
    </section>
<section id="cuadrilla-productos" style="border:0; max-width:808px!important">
    <asp:Label id="lblVentasPorAsignar" runat="server" Text="-"></asp:Label>
    <br />
    <div style="display: table;">
    <asp:Panel id="pnlVendedor" runat ="server" DefaultButton="lnkBuscar" style="display:table-cell; width:250px;">
	<asp:TextBox id="txtNombreVendedor" runat="server" name="nombre-vendedor" placeholder="Nombre Completo" class="nombre-vendedor"></asp:TextBox><asp:LinkButton id="lnkBuscar" runat="server" Text="Buscar" OnClick="btnBuscarVendedor_Click" class="boton-gris" style="padding: 8px 10px 7px 10px;"></asp:LinkButton>
    </asp:Panel>
        <div style="display:table-cell; padding-left: 100px; width:175px;">
            <asp:LinkButton ID="lnkHistorico" runat="server" Text="Historico de asignaciones" OnClick="lnkHistorico_Click" class="boton-gris" style="padding: 8px 10px 7px 10px;"></asp:LinkButton>
        </div>
        <div style="display:table-cell; padding-left: 225px; width:40px;">
            <a href="#" style="cursor:pointer;" onclick='window.open("listacontratos.aspx","_blank","toolbar=no, scrollbars=no, resizable=yes, width=755, height=650");'><img src="images/checklist-icon.png" style="height:32px; vertical-align:bottom; width:40px;" /></a>
        </div>    
        </div>
    <br />
    <div id="contenedor-movimientos" class="left">
	<div class="barra-titulo">
    	<p class="concepto" style="width:375px;">Asesor de Ventas</p>
        <p class="fecha">Fecha</p>
        <p class="fecha">Kilómetros</p>
        <p class="kilometros" style="width:110px;">&nbsp;</p>
    </div>
            
                            <section id="cuadrilla-vendedores">
        <asp:ListView id="lvAsesoreVentas" runat="server" OnItemCommand="lvAsesoreVentas_ItemCommand" DataKeyNames="participante_id,clave,AsesorNombre,fecha_alta,saldo" >
            <ItemTemplate>
    <div class="barra-contenido">
    	<p class="concepto" style="width:371px;"><%# Eval("AsesorNombre") %></p>
        <p class="fecha"><%# Eval("fecha_alta") %></p>
        <p class="fecha" style="width:122px;"><%# Convert.ToInt32(Eval("saldo")).ToString("N0") %></p>
        <p class="kilometros" style="width:110px;"><asp:LinkButton id="lnkSeleccionar" runat="server" Text="Asignar ventas" CommandName="seleccionar"></asp:LinkButton></p>
        </div>
</ItemTemplate>
                <EmptyDataTemplate>
    <div class="barra-contenido">
                        No se encontraron asesores de venta
        </div>
                </EmptyDataTemplate>
                                            </asp:ListView>
                                </section>
        </div>
    </section>
        </asp:View>
        <asp:View id="vSeleccionado" runat="server">
         <telerik:RadScriptBlock runat="server" ID="scriptBlock">
        <script type="text/javascript">
            //<![CDATA[
            function onRowDropping(sender, args) {
                if (sender.get_id() == "<%=rgVentas.ClientID %>") {
                    var node = args.get_destinationHtmlElement();
                    if (!isChildOf('<%=grdVentasAsignadas.ClientID %>', node) && !isChildOf('<%=rgVentas.ClientID %>', node)) {
                        args.set_cancel(true);
                    }
                }

            }

            function isChildOf(parentId, element) {
                while (element) {
                    if (element.id && element.id.indexOf(parentId) > -1) {
                        return true;
                    }
                    element = element.parentNode;
                }
                return false;
            }
            //]]>
        </script>
    </telerik:RadScriptBlock>
	<section id="categorias" style="width:185px!important;">
    	
       <ul>
            <li><p>Asignación de Ventas</p></li>
           <li>&nbsp;</li>
           <li><a href="asignacionventas.aspx" class="boton-gris" style="width: 100px;">Cambiar asesor</a></li>
        </ul>        
    </section>
<section id="cuadrilla-productos" style="border:0; max-width:808px!important">
<asp:Label id="lblNombreVendedor" runat="server"></asp:Label>
    <br /><br />
                        <asp:Panel id="pnlVentas" runat ="server" DefaultButton="btnBuscarChasis">
    <asp:TextBox id="txtNumeroChasis" runat="server" name="nombre-vendedor" placeholder="Chasis / Contrato" class="nombre-vendedor" style="width:300px;"></asp:TextBox><asp:LinkButton id="btnBuscarChasis" runat="server" Text="Agregar" class="boton-gris" style="padding: 8px 10px 7px 10px;" OnClick="btnAgregarChasis_Click" ValidationGroup="valgChasis"></asp:LinkButton>
                                    <asp:RequiredFieldValidator ID="reqChasis" runat="server" ControlToValidate="txtNumeroChasis"
                                        ErrorMessage="Chasis obligatorio" ValidationGroup="valgChasis">&nbsp;</asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="valChasis" runat="server" TargetControlID="reqChasis">
                                    </cc1:ValidatorCalloutExtender>
                        </asp:Panel>
    <br />
                <div style="float:right;margin:0 20px 10px 0">
    <asp:LinkButton id="lnkCancelar" runat="server" Text="Cancelar" class="boton-gris" OnClick="lnkCancelarVentas_Click"></asp:LinkButton>
    <asp:LinkButton id="lnkbtnAsignaVentas" runat="server" Text="Asignar" class="boton-gris" style="margin-left: 20px" OnClick="lnkAsignarVentas_Click"></asp:LinkButton>
                    </div>
            <table width="100%" border="0">
                <tr>
                    <td>
 <telerik:RadGrid runat="server" ID="rgVentas" AutoGenerateColumns="false"  Font-Size="12px" EnableEmbeddedSkins="true" Skin="Metro"
                AllowPaging="True"  AllowMultiRowSelection="true" OnNeedDataSource="rgVentas_NeedDataSource" OnRowDrop="rgVentas_RowDrop" Width="100%" OnItemCommand="rgVentas_ItemCommand">
                <MasterTableView DataKeyNames="Chasis" AllowFilteringByColumn="true">
                    <Columns>
                        <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="false">
                        </telerik:GridDragDropColumn>
                         <telerik:GridButtonColumn ConfirmText="¿Está seguro que desea dar de baja el registro?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Eliminar" HeaderTooltip="No Aplica"  ButtonType="ImageButton" CommandName="Delete" ImageUrl="images/delete.gif" />
                        <telerik:GridTemplateColumn  DataField="Client" HeaderText="Nombre del Cliente" ItemStyle-Width="130px" AllowFiltering="false">
                            <ItemTemplate>
                                <asp:Label ID="lblCliente" runat="server" Text='<%# Eval("Client").ToString().Length > 15 ? Eval("Client").ToString().Substring(0,15) + "..." : Eval("Client").ToString() %>' ToolTip='<%# Eval("Client") %>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        
                        <telerik:GridBoundColumn DataField="Chasis" HeaderText="Chasis" DataFormatString="{0:N}" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains"></telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="numero_contrato" HeaderText="No. Contrato o Poliza" DataFormatString="{0:N}" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center"  ShowFilterIcon="false"  AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"></telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn DataField="DescripcionProducto" HeaderText="Descripción del Producto" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" AllowFiltering="false">
                            <ItemTemplate>
                                <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("DescripcionProducto").ToString().Length > 15 ? Eval("DescripcionProducto").ToString().Substring(0,15) + "..." : Eval("DescripcionProducto").ToString() %>' ToolTip='<%# Eval("DescripcionProducto") %>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="FechaDeVenta" HeaderText="Fecha de Venta" DataFormatString="{0:d}" ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center" AllowFiltering="false"></telerik:GridBoundColumn>
                    </Columns>
                                        <NoRecordsTemplate>
                                            <div style="height: 30px; cursor: pointer;">
                                                No hay registros que mostrar</div>
                                        </NoRecordsTemplate>
                </MasterTableView>
                <ClientSettings AllowRowsDragDrop="True" AllowColumnsReorder="true" ReorderColumnsOnClient="true">
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="false"></Selecting>
                    <ClientEvents OnRowDropping="onRowDropping"></ClientEvents>
                    <Scrolling AllowScroll="false" UseStaticHeaders="true"></Scrolling>
                </ClientSettings>
                <PagerStyle Mode="NumericPages" PagerTextFormat="{4} Página {0} de {1}, registros {2} al {3} de {5}" />
            </telerik:RadGrid>
                    </td>
                    <td>&nbsp;</td>
                    <td valign ="top">
                        <telerik:RadGrid runat="server" AllowPaging="True" ID="grdVentasAsignadas" AutoGenerateColumns="false" EnableEmbeddedSkins="true" Skin="Metro"
                                    AllowMultiRowSelection="true" OnNeedDataSource="grdVentasAsignadas_NeedDataSource" OnRowDrop="grdVentasAsignadas_RowDrop">
                                    <MasterTableView  Width="100%" DataKeyNames="Chasis">
                                        <Columns>
                                            <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="false">
                                            </telerik:GridDragDropColumn>
                                            <telerik:GridBoundColumn DataField="Chasis" HeaderText="Chasis" DataFormatString="{0:N}" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="numero_contrato" HeaderText="No. Contrato o Póliza" DataFormatString="{0:N}" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Center" ></telerik:GridBoundColumn>
                                        </Columns>
                                        <NoRecordsTemplate>
                                            <div style="height: 30px; cursor: pointer;">
                                                No hay registros que mostrar</div>
                                        </NoRecordsTemplate>
                                    </MasterTableView>
                                    <ClientSettings AllowRowsDragDrop="True">
                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false"></Selecting>
                                        <ClientEvents OnRowDropping="onRowDropping"></ClientEvents>
                                    </ClientSettings>
                <PagerStyle Mode="NumericPages" PagerTextFormat="{4} Página {0} de {1}, registros {2} al {3} de {5}" />
                                </telerik:RadGrid>
                    </td>
                </tr>
            </table>
</section>
            
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" EnableSkinTransparency="true" Skin="Metro">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager runat="server" ID="radAjax" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgVentas">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgVentas"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="grdVentasAsignadas"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdVentasAsignadas">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdVentasAsignadas"></telerik:AjaxUpdatedControl>
                    <telerik:AjaxUpdatedControl ControlID="rgVentas"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
        </asp:View>
        <asp:View ID="vHistorico" runat="server">
            	<section id="categorias" style="width:185px!important;">
       <ul>
           <li><p>Histórico de asignaciones</p></li>
           <li>&nbsp;</li>
           <li>&nbsp;</li>
           <li>
    <asp:LinkButton id="lnkRegresarHistorico" runat="server" Text="Regresar" OnClick="lnkRegresarHistorico_Click" class="boton-gris" style="padding: 8px 10px 7px 10px;"></asp:LinkButton>
               </li>
        </ul>
    </section>
<section id="cuadrilla-productos" style="border:0; max-width:808px!important">
    <div id="contenedor-movimientos" class="left">
	<div class="barra-titulo">
    	<p class="concepto" style="width:65px;">Clave</p>
        <p class="fecha" style="width:300px;">Nombre</p>
        <p class="fecha" style="width:90px;">Fecha</p>
        <p class="fecha" style="width:100px;">No. contrato</p>
        <p class="fecha" style="width:110px;">Chasis</p>
        <p class="kilometros" style="width:80px;">Kilómetros</p>
    </div>
                            <section id="cuadrilla-vendedores" style="width: 814px !important; height: 520px !important;">
        <asp:ListView id="lvHistorico" runat="server">
            <ItemTemplate>
    <div class="barra-contenido">
    	<p class="concepto" style="width:61px;"><%# Eval("clave ") %></p>
        <p class="fecha" style="width:296px;"><%# Eval("nombre") %></p>
        <p class="fecha" style="width:85px;"><%# Convert.ToDateTime(Eval("fecha")).ToString("dd/MM/yyyy") %></p>
        <p class="fecha" style="width:96px;"><%# Eval("numero_contrato") %></p>
        <p class="fecha" style="width:100px;"><%# Eval("chasis") %></p>
        <p class="kilometros" style="width:75px;"><%# Convert.ToInt32(Eval("puntos")).ToString("N0") %></p>
        </div>
</ItemTemplate>
                <EmptyDataTemplate>
                    <div class="barra-contenido" style="background: #666; color: #fff !important; padding-left:10px; width:791px;">
                        No se encontraron registros
        </div>
                </EmptyDataTemplate>
                                            </asp:ListView>
                                </section>
        </div>
    </section>
        </asp:View>
    </asp:MultiView>

</main>



    </div>
</asp:Content>
