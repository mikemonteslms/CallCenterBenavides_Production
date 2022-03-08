<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="mantenimientoCatalogoPremios.aspx.cs" Inherits="ORMOperacion.mantenimientoCatalogoPremios" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.OpenAccess.Web.40, Version=2014.3.1027.1, Culture=neutral, PublicKeyToken=7ce17eeaf1d59342" Namespace="Telerik.OpenAccess.Web" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.OpenAccess.Web, Version=2014.3.1027.1, Culture=neutral, PublicKeyToken=7ce17eeaf1d59342" Namespace="Telerik.OpenAccess" TagPrefix="telerik" %>


<%@ MasterType VirtualPath="~/contenido.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <script type="text/javascript">
        function calculate(precio, valor_envio, valor_seguro, valor_affa, costo)   //this method throws error )
        {
            var vPrecio = $find(precio);
            var vEnvio = $find(valor_envio);
            var vSeguro = $find(valor_seguro);
            var vAFFA = $find(valor_affa);

            var cTotalCosto = $find(costo);

            var vPrecioDisplay = vPrecio.get_displayValue();
            var vEnvioDisplay = vEnvio.get_displayValue();
            var vSeguroDisplay = vSeguro.get_displayValue();
            var vAFFADisplay = vAFFA.get_displayValue();

            var TotalCosto = vPrecioDisplay + vEnvioDisplay + vSeguroDisplay + vAFFADisplay;
            cTotalCosto.set_displayValue(TotalCosto);
        }
    </script>
    <div id="rounded-box4">
        <table width="100%">
            <tr>
                <td>
                    <input type="file" id="fileExcel" runat="server" />
                    <asp:Button ID="btnImportarPremios" runat="server" Text="Importar" OnClick="btnImportarPremios_Click" />
                </td>
                <td>
                    <a href="plantillas/PlantillaPremios.xlsx">Plantilla Para Carga de Premios</a>
                </td>
            </tr>
        </table>


        <table width="100%">
            <tr>
                <td>
                    <div style="overflow: auto; width: 1100px; height: 100%;">
                        <telerik:OpenAccessLinqDataSource ID="OAFuenteTablas" EnableInsert="True"
                            runat="server"
                            EntityTypeName=""
                            OnUpdating="OAFuenteTablas_Updating"
                            OnInserting="OAFuenteTablas_Inserting" />
                        <telerik:OpenAccessLinqDataSource ID="oaPremios"
                            runat="server"
                            ContextTypeName="EntitiesModel.EntitiesModel"
                            EntityTypeName=""
                            ResourceSetName="premios">
                        </telerik:OpenAccessLinqDataSource>

                        <telerik:RadGrid ID="gridPremios" runat="server"
                            CellPadding="0" GridLines="None" Width="4000px"
                            AllowAutomaticDeletes="True"
                            AllowAutomaticInserts="True"
                            AllowAutomaticUpdates="True"
                            CellSpacing="0" AllowSorting="True"
                            AllowFilteringByColumn="True"
                            EnableLinqExpressions="true" Culture="es-MX" AutoGenerateColumns="false"
                            OnNeedDataSource="gridPremios_NeedDataSource"
                            OnInsertCommand="gridPremios_InsertCommand"
                            OnItemDataBound="gridPremios_ItemDataBound"
                            OnItemCommand="gridPremios_ItemCommand"
                            OnItemCreated="gridPremios_ItemCreated"
                            AllowPaging="true"
                            PageSize="5" PagerStyle-AlwaysVisible="true">
                            <ClientSettings AllowColumnsReorder="true">
                            </ClientSettings>
                            <MasterTableView CommandItemDisplay="Top" AllowAutomaticInserts="true" EditMode="EditForms">
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                </EditFormSettings>
                                <Columns>
                                    <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="ColEditar" ItemStyle-Width="10px" />
                                    <telerik:GridButtonColumn ConfirmText="Esta seguro que desea eliminarlo?" ConfirmDialogType="RadWindow"
                                        ConfirmTitle="Eliminar" ButtonType="ImageButton" CommandName="Delete" ItemStyle-Width="10px" />
                                    <telerik:GridBoundColumn UniqueName="id" DataField="id" HeaderText="id" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="clave" DataField="clave" HeaderText="No." ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="programa" DataField="programa" HeaderText="Programa" ShowFilterIcon="false" FilterControlWidth="130px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="sku" DataField="sku" HeaderText="SKU" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridNumericColumn UniqueName="proveedor_premios_id" DataField="proveedor_premios_id" HeaderText="Proveedor">
                                        <FilterTemplate>
                                            <telerik:RadComboBox ID="rcbProveedor" runat="server" Width="160px" Height="100px" AutoPostBack="true">
                                            </telerik:RadComboBox>
                                        </FilterTemplate>
                                    </telerik:GridNumericColumn>
                                    <telerik:GridBoundColumn UniqueName="descripcion" DataField="descripcion" HeaderText="Nombre del Premio" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" FilterControlWidth="200px">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridNumericColumn UniqueName="marca_premios_id" DataField="marca_premios_id" HeaderText="Marca">
                                        <FilterTemplate>
                                            <telerik:RadComboBox ID="rcbMarcaPremios" runat="server" Width="140px" Height="100px" AutoPostBack="true">
                                            </telerik:RadComboBox>
                                        </FilterTemplate>
                                    </telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="categoria_premio_id" DataField="categoria_premio_id" HeaderText="Categoria">
                                        <FilterTemplate>
                                            <telerik:RadComboBox ID="rcbCategoriaPremios" runat="server" Width="140px" Height="100px" AutoPostBack="true">
                                            </telerik:RadComboBox>
                                        </FilterTemplate>
                                    </telerik:GridNumericColumn>
                                    <telerik:GridBoundColumn UniqueName="descripcion_larga" DataField="descripcion_larga" HeaderText="Descripción" ShowFilterIcon="false" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" FilterControlWidth="400px">
                                        <HeaderStyle Width="400px" />
                                        <ItemStyle Width="400px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridNumericColumn UniqueName="precio" DataField="precio" HeaderText="Precio" DataFormatString="{0:C}" FilterControlWidth="80px"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="valor_envio" DataField="valor_envio" HeaderText="Valor Envio" DataFormatString="{0:C}" FilterControlWidth="80px"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="valor_seguro" DataField="valor_seguro" HeaderText="Valor Seguro" DataFormatString="{0:C}" FilterControlWidth="80px"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="valor_affa" DataField="valor_affa" HeaderText="Valor AFFA" DataFormatString="{0:C}" FilterControlWidth="80px"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="costo" DataField="costo" HeaderText="Total Costo" DataFormatString="{0:C}" FilterControlWidth="80px"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="porcentaje_utilidad" DataField="porcentaje_utilidad" HeaderText="%Utilidad" DataFormatString="{0:P0}" FilterControlWidth="80px">
                                    </telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="valor_utilidad" DataField="valor_utilidad" HeaderText="Utilidad" DataFormatString="{0:C}" FilterControlWidth="80px">
                                    </telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="precio_venta" DataField="precio_venta" HeaderText="Precio Venta" DataFormatString="{0:C}" FilterControlWidth="80px">
                                    </telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="iva" DataField="iva" HeaderText="IVA" DataFormatString="{0:C}" FilterControlWidth="80px">
                                    </telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="precio_total" DataField="precio_total" HeaderText="Total" DataFormatString="{0:C}" FilterControlWidth="80px">
                                    </telerik:GridNumericColumn>
                                    <telerik:GridTemplateColumn UniqueName="url_imagen_small" DataField="url_imagen_small" HeaderText="Image small" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:Image ID="imagenSmall" runat="server" Width="40px" Height="40px" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <input type="file" runat="server" id="uploadFileSmallEdit" />
                                            <div style="display: none">
                                                <asp:Label ID="lblImagenSmall" runat="server" Text='<%# Eval("url_imagen_small") %>'></asp:Label>
                                            </div>
                                        </EditItemTemplate>
                                        <InsertItemTemplate>
                                            <input type="file" runat="server" id="uploadFileSmall" />
                                        </InsertItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Image large" UniqueName="url_imagen_large" DataField="url_imagen_large" SortExpression="Name" AllowFiltering="false">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" ID="hlName" NavigateUrl='<%# Eval("url_imagen_large") %>' Text='<%# Eval("url_imagen_large") %>' Target="_blank">
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <input type="file" id="uploadFileLargeEdit" runat="server" />
                                            <div style="display: none">
                                                <asp:Label ID="lblImagenLarge" runat="server" Text='<%# Eval("url_imagen_large") %>'></asp:Label>
                                            </div>
                                        </EditItemTemplate>
                                        <InsertItemTemplate>
                                            <input type="file" runat="server" id="uploadFileLarge" />
                                        </InsertItemTemplate>
                                        <HeaderStyle Width="300px" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridNumericColumn UniqueName="puntos" DataField="puntos" HeaderText="Puntos" FilterControlWidth="80px">
                                    </telerik:GridNumericColumn>
                                    <telerik:GridBoundColumn UniqueName="comentario" DataField="comentario" HeaderText="Comentario" ShowFilterIcon="false" FilterControlWidth="130px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridNumericColumn UniqueName="dias_de_entrega" DataField="dias_de_entrega" HeaderText="Días de Entrega" FilterControlWidth="50px">
                                    </telerik:GridNumericColumn>
                                    <telerik:GridDateTimeColumn UniqueName="fecha_inicio_vigencia" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" DataField="fecha_inicio_vigencia" HeaderText="Fecha Inicio Vigencia" FilterControlWidth="100px">
                                    </telerik:GridDateTimeColumn>
                                    <telerik:GridDateTimeColumn UniqueName="fecha_fin_vigencia" DataField="fecha_fin_vigencia" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Fin Vigencia" FilterControlWidth="100px">
                                    </telerik:GridDateTimeColumn>
                                    <telerik:GridNumericColumn UniqueName="bodega_id" DataField="bodega_id" HeaderText="Bodega">
                                        <FilterTemplate>
                                            <telerik:RadComboBox ID="rcbBodega" runat="server" Width="140px" Height="100px" AutoPostBack="true">
                                            </telerik:RadComboBox>
                                        </FilterTemplate>
                                    </telerik:GridNumericColumn>
                                    <telerik:GridBoundColumn UniqueName="notificar_canje" DataField="notificar_canje" HeaderText="Notificar Canje" ShowFilterIcon="false" FilterControlWidth="130px" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="usuario_alta_id" DataField="usuario_alta_id" HeaderText="Usuario Alta" AllowFiltering="false" Visible="false">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="usuario_cambio_id" DataField="usuario_cambio_id" HeaderText="Usuario Cambio" AllowFiltering="false" Visible="false">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="usuario_baja_id" DataField="usuario_baja_id" HeaderText="Usuario Baja" AllowFiltering="false" Visible="false">
                                        <HeaderStyle Wrap="false" />
                                        <ItemStyle Wrap="false" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridDateTimeColumn UniqueName="fecha_cambio" DataField="fecha_cambio" HeaderText="Fecha Cambio" AllowFiltering="false" Visible="false">
                                    </telerik:GridDateTimeColumn>
                                    <telerik:GridDateTimeColumn UniqueName="fecha_alta" DataField="fecha_alta" HeaderText="Fecha Alta" AllowFiltering="false" Visible="false">
                                    </telerik:GridDateTimeColumn>
                                    <telerik:GridDateTimeColumn UniqueName="fecha_baja" DataField="fecha_baja" HeaderText="Fecha Baja" AllowFiltering="false" Visible="false">
                                    </telerik:GridDateTimeColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
