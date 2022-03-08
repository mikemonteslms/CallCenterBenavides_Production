<%@ Page Title="" Language="C#" EnableEventValidation="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdmonCatalogos.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.AdmonCatalogos.AdmonCatalogos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="../cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />

    <script type="text/javascript" >
        function ShowReg() {
            //debugger;
            var _docHeight = (document.height !== undefined) ? document.height : document.body.scrollHeight;
            var _docWidth = (document.width !== undefined) ? document.width : document.body.offsetWidth;

            $('#popReg').fadeIn('slow');
            $('#popReg').height(_docHeight);
            return false;
        }

        function ShowRegAsigLab() {
            //debugger;
            var _docHeight = (document.height !== undefined) ? document.height : document.body.scrollHeight;
            var _docWidth = (document.width !== undefined) ? document.width : document.body.offsetWidth;

            $('#popRegAsiglab').fadeIn('slow');
            $('#popRegAsiglab').height(_docHeight);
            return false;
        }
    </script>

    <br /><br />
    <asp:Label runat="server" ID="lblTitulo" Text="Administrador de catálogos..."  Font-Size="16px" ForeColor="DarkBlue"/>
    <br /><br />

    <asp:UpdatePanel ID="upAdmonCatalogos" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlBusquedaAvanzada" runat="server" GroupingText="">
                <div class="demo-container no-bg">
                    <asp:HiddenField ID="IdLab" runat="server" />
                    <asp:HiddenField ID="IdSeg" runat="server" />
                    <asp:HiddenField ID="IdTPromo" runat="server" />
                    <asp:HiddenField ID="IdPeriodohide" runat="server" />
                    <telerik:RadTabStrip RenderMode="Lightweight" ID="tabCatalogosPromociones" runat="server"  EnableDragToReorder="true" Skin="Silk" MultiPageID="rmpCatalogos" SelectedIndex="0">
                        <Tabs>
                            <telerik:RadTab Text="Laboratorios" Selected="true"></telerik:RadTab>
                            <telerik:RadTab Text="Productos" Visible="true"></telerik:RadTab>
                            <telerik:RadTab Text="Segmentos" Visible="true"></telerik:RadTab>
                            <telerik:RadTab Text="Tipo de Promoción" Visible="true"></telerik:RadTab>
                            <telerik:RadTab Text="Límites de Periodo" Visible="true"></telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage ID="rmpCatalogos" runat="server"  CssClass="RadMultiPage" SelectedIndex="0" Height="350px">
                        <telerik:RadPageView ID="rpvLaboratorio" runat="server" CssClass="RadMultiPage"  Height="350" Style="overflow: hidden">
                            <asp:MultiView ID="mvCatLab" runat="server" ActiveViewIndex="0">
                                <asp:View ID="vAltaLab" runat="server">
                                <br />
                                <h5 style="color:darkblue">Alta de laboratorios</h5> 
                                <br /> <br />
                                <asp:Table runat="server" ID="tblLab" >
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label runat="server" ID="label1" Text="Nombre de Laboratorio:" ></asp:Label>
                                        </asp:TableCell>
                                            <asp:TableCell>
                                                &nbsp;&nbsp;<asp:TextBox ID="txtNomLaboratorio" runat="server" Width="350px"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:View>
                                <asp:View ID="vBusquedaLab" runat="server">
                                    <h5 style="color:darkblue">Muestra Laboratorios</h5> 
                                    <asp:HiddenField ID="txtLabForzar" runat="server"/>
                                    <asp:table ID="tblCatLaboratorios" runat="server" CellSpacing="15" CellPadding="15">
                                        <asp:TableRow>
                                            <asp:TableCell VerticalAlign="Top">
                                                <asp:Button ID="btnAddNuevolab" runat="server" Text="Nuevo laboratorio" OnClick="btnAddNuevolab_Click" Width="150px"/>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell Width="520px">
                                                <telerik:RadGrid ID="grvLaboratorios"  runat="server" PageSize="5" AutoGenerateColumns="False" AllowPaging="true"  AllowSorting="true" OnItemCommand="grvLaboratorios_ItemCommand" CellSpacing="2" GridLines="Both"    Culture="es-MX" OnPageIndexChanged="grvLaboratorios_PageIndexChanged" Width="500px">
                                                <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                                    <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                                                    <RowIndicatorColumn Visible="False">
                                                            </RowIndicatorColumn>
                                                            <Columns>        
                                                                <%--<telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate> 
                                                                    <asp:Button ID="btnEliminar" ToolTip="Elimina laboratorio" runat="server"  Text="Eliminar" Width="80px" CommandArgument='<%# Eval("IdLaboratorio")%>' Font-Size="13px" CommandName="EliminaLab" TabIndex="0"/>
                                                                </ItemTemplate>
                                                                </telerik:GridTemplateColumn> --%>
                                                                <telerik:GridTemplateColumn  HeaderText="" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate> 
                                                                    <asp:Button ID="btnEditar" ToolTip="Editar laboratorio" runat="server"  Text="Editar" Width="80px" CommandArgument='<%# Eval("IdLaboratorio")%>' Font-Size="13px" CommandName="EditaLab" TabIndex="1"/>
                                                                </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridBoundColumn DataField="IdLaboratorio" FilterControlAltText="Filter column2 column" HeaderStyle-ForeColor="Black" HeaderText="IdLaboratorio" UniqueName="column2">
                                                                    </telerik:GridBoundColumn>  
                                                                <telerik:GridBoundColumn DataField="Laboratorio" ItemStyle-Width="200px" FilterControlAltText="Filter column3 column" HeaderStyle-ForeColor="Black" HeaderText="Laboratorio" UniqueName="column3">
                                                                    </telerik:GridBoundColumn>  
                                                            </Columns>
                                                        <PagerStyle PageSizeControlType="None"/>
                                                </MasterTableView>
                                                <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                                </telerik:RadGrid>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Table ID="tblbtnForzar" runat="server">
                                                    <asp:TableRow >
                                                        <asp:TableCell>
                                                            <br />
                                                            <asp:Button ID="btnForzarAlta" runat="server" Text="Forzar Alta" OnClick="btnForzarAlta_Click" Width="150px" Visible ="false"  />
                                                        </asp:TableCell>
                                                        <asp:TableCell>
                                                            <br />
                                                            <asp:Button ID="btnCancelarForzado" runat="server" Text="Cancelar" OnClick="btnCancelarForzado_Click" Visible="false"/>
                                                        </asp:TableCell>
                                                    </asp:TableRow>
                                                </asp:Table>
                                            </asp:TableCell>
                                    </asp:TableRow>
                                    </asp:table>
                                </asp:View>
                                <asp:View ID="vEditaLab" runat="server">
                                    <h5 style="color:darkblue">Editar Laboratorios</h5> 

                                        <asp:Table runat="server" ID="Table1" >
                                            <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label runat="server" ID="label2" Text="Nombre de Laboratorio:" ></asp:Label>
                                            </asp:TableCell>
                                                <asp:TableCell>
                                                    &nbsp;&nbsp;<asp:TextBox ID="txtEditLab" runat="server" Width="350px"></asp:TextBox>
                                            </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnModificar" runat="server" Text="Guardar" OnClick="btnModificar_Click" />
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnEditCancelar" runat="server" Text="Cancelar" OnClick="btnEditCancelar_Click" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                        </asp:Table>
                                </asp:View>
                            </asp:MultiView>
                        </telerik:RadPageView>
                         <telerik:RadPageView ID="rpvAsignaLabProd" runat="server" Height="350" Style="overflow: hidden">
                            <asp:MultiView ID="mvCatAsignaLabProd" runat="server" ActiveViewIndex="0">
                                 <asp:View ID="vBusquedaProductos" runat="server">
                                     <h5 style="color:darkblue">Muestra Productos</h5> 
                                    <asp:HiddenField ID="selIdProd" runat="server" />
                                    <asp:table ID="tblProductos" runat="server" CellSpacing="15" CellPadding="15">
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Table ID="tblBotones" runat="server">
                                                 <asp:TableRow>
                                                     <asp:TableCell>
                                                         <asp:Label ID="Label8" runat="server" Text="Producto:"></asp:Label>
                                                     </asp:TableCell>
                                                     <asp:TableCell>
                                                         <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
                                                     </asp:TableCell>
                                                     <asp:TableCell>
                                                         <asp:Button ID="btnBuscarProd" runat="server" Text="Buscar" OnClick="btnBuscarProd_Click" />
                                                     </asp:TableCell>
                                                </asp:TableRow>
                                                </asp:Table>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell Width="520px" HorizontalAlign="center">
                                                
                                                <telerik:RadGrid ID="grvProductos"  runat="server" PageSize="5" AutoGenerateColumns="False" AllowPaging="true"  AllowSorting="true" OnItemCommand="grvProductos_ItemCommand" CellSpacing="2" GridLines="Both"    Culture="es-MX" OnPageIndexChanged="grvProductos_PageIndexChanged" Width="850px">
                                                <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                                    <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                                                    <RowIndicatorColumn Visible="False">
                                                            </RowIndicatorColumn>
                                                            <Columns>        
                                                                <telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate> 
                                                                    <asp:Button ID="btnAsignarlab" ToolTip="Asignar laboratorio" runat="server"  Text="Asignar laboratorio" Width="130px" CommandArgument='<%# Eval("Id")%>' Font-Size="13px" CommandName="AsignaLab" TabIndex="0"/>
                                                                </ItemTemplate>
                                                                </telerik:GridTemplateColumn> 
                                                                <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter column2 column" HeaderStyle-ForeColor="Black" HeaderText="Id" UniqueName="column2">
                                                                    </telerik:GridBoundColumn> 
                                                                <telerik:GridBoundColumn DataField="Producto" ItemStyle-Width="330px" FilterControlAltText="Filter column2 column" HeaderStyle-ForeColor="Black" HeaderText="Producto" UniqueName="column2">
                                                                    </telerik:GridBoundColumn>  
                                                                <telerik:GridBoundColumn DataField="IdCategoria" FilterControlAltText="Filter column2 column" HeaderStyle-ForeColor="Black" HeaderText="IdCategoria" UniqueName="column2">
                                                                    </telerik:GridBoundColumn> 
                                                                <telerik:GridBoundColumn DataField="Laboratorio" ItemStyle-Width="330px" FilterControlAltText="Filter column2 column" HeaderStyle-ForeColor="Black" HeaderText="Laboratorio" UniqueName="column2">
                                                                    </telerik:GridBoundColumn>  
                                                            </Columns>
                                                        <PagerStyle PageSizeControlType="None"/>
                                                </MasterTableView>
                                                <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                                </telerik:RadGrid>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:table>
                                 </asp:View>
                            </asp:MultiView>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="rpvSegmentos" runat="server" Height="350" Style="overflow: hidden">
                            <asp:MultiView ID="mvCatSegmento" runat="server" ActiveViewIndex="0">
                                <asp:View ID="vAltaSegmentos" runat="server">
                                <br />
                                <h5 style="color:darkblue">Alta de Segmentos</h5> 
                                <br /> <br />
                                <asp:Table runat="server" ID="tblSegmentos" >
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label runat="server" ID="label3" Text="Nombre de Segmento:" ></asp:Label>
                                        </asp:TableCell>
                                            <asp:TableCell>
                                                &nbsp;&nbsp;<asp:TextBox ID="txtSegmento" runat="server" Width="350px"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnGuardaSegmento" runat="server" Text="Guardar" OnClick="btnGuardaSegmento_Click" />
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnCancelarSegmento" runat="server" Text="Cancelar" OnClick="btnCancelarSegmento_Click" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:View>
                                <asp:View ID="vBusquedaSegmentos" runat="server">
                                    <h5 style="color:darkblue">Muestra Segmentos</h5> 

                                    <asp:table ID="Table3" runat="server" CellSpacing="15" CellPadding="15">
                                        <asp:TableRow>
                                            <asp:TableCell VerticalAlign="Top">
                                                <asp:Button ID="btnNuevoSegmento" runat="server" Text="Nuevo Segmento" OnClick="btnNuevoSegmento_Click" Width="150px"/>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell Width="520px">
                                                <telerik:RadGrid ID="grvSegmentos"  runat="server" PageSize="5" AutoGenerateColumns="False" AllowPaging="true"  AllowSorting="true" OnItemCommand="grvSegmentos_ItemCommand" CellSpacing="2" GridLines="Both"    Culture="es-MX" OnPageIndexChanged="grvSegmentos_PageIndexChanged" Width="500px">
                                                <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                                    <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                                                    <RowIndicatorColumn Visible="False">
                                                            </RowIndicatorColumn>
                                                            <Columns>        
                                                                <telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate> 
                                                                    <asp:Button ID="btnEliminarSegmento" ToolTip="Elimina laboratorio" runat="server"  Text="Eliminar" Width="80px" CommandArgument='<%# Eval("IdSegmento")%>' Font-Size="13px" CommandName="EliminaSegmento" TabIndex="0"/>
                                                                </ItemTemplate>
                                                                </telerik:GridTemplateColumn> 
                                                                <telerik:GridTemplateColumn  HeaderText="" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate> 
                                                                    <asp:Button ID="btnEditarSegmento" ToolTip="Editar laboratorio" runat="server"  Text="Editar" Width="80px" CommandArgument='<%# Eval("IdSegmento")%>' Font-Size="13px" CommandName="EditaSegmento" TabIndex="1"/>
                                                                </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridBoundColumn DataField="IdSegmento" FilterControlAltText="Filter column2 column" HeaderStyle-ForeColor="Black" HeaderText="IdSegmento" UniqueName="column2">
                                                                    </telerik:GridBoundColumn>  
                                                                <telerik:GridBoundColumn DataField="Segmento" ItemStyle-Width="200px" FilterControlAltText="Filter column3 column" HeaderStyle-ForeColor="Black" HeaderText="Segmento" UniqueName="column3">
                                                                    </telerik:GridBoundColumn>  
                                                            </Columns>
                                                        <PagerStyle PageSizeControlType="None"/>
                                                </MasterTableView>
                                                <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                                </telerik:RadGrid>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:table>
                                </asp:View>
                                <asp:View ID="vEditaSegmentos" runat="server">
                                    <h5 style="color:darkblue">Editar Segmento</h5> 

                                        <asp:Table runat="server" ID="Table4" >
                                            <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label runat="server" ID="label4" Text="Nombre de Segmento:" ></asp:Label>
                                            </asp:TableCell>
                                                <asp:TableCell>
                                                    &nbsp;&nbsp;<asp:TextBox ID="txtEditaSegmento" runat="server" Width="350px"></asp:TextBox>
                                            </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnEditSegmento" runat="server" Text="Guardar" OnClick="btnEditSegmento_Click" />
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnCancelarEditSegmento" runat="server" Text="Cancelar" OnClick="btnCancelarEditSegmento_Click" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                        </asp:Table>
                                </asp:View>
                            </asp:MultiView>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="rpvTipoPromocion" runat="server"  Height="350" Style="overflow: hidden">
                            <asp:MultiView ID="mvCatTipoProm" runat="server" ActiveViewIndex="0">
                                <asp:View ID="vAltaTipoPromo" runat="server">
                                <br />
                                <h5 style="color:darkblue">Alta Tipo de Promociones</h5> 
                                <br /> <br />
                                <asp:Table runat="server" ID="Table2" >
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label runat="server" ID="label5" Text="Nombre Tipo de Promoción:" ></asp:Label>
                                        </asp:TableCell>
                                            <asp:TableCell>
                                                &nbsp;&nbsp;<asp:TextBox ID="txtTipoPromo" runat="server" Width="350px"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label runat="server" ID="label7" Text="Tipo Acumulación:" ></asp:Label>
                                        </asp:TableCell>
                                            <asp:TableCell>
                                                &nbsp;&nbsp;<asp:TextBox ID="txtIdTipoAcum" runat="server" Width="30px" MaxLength="1"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="ftbeIdTipoAcum" runat="server" FilterType="Numbers" TargetControlID="txtIdTipoAcum">
                                                </cc1:FilteredTextBoxExtender>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnGuardarTPromo" runat="server" Text="Guardar" OnClick="btnGuardarTPromo_Click" />
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnCancelarTPromo" runat="server" Text="Cancelar" OnClick="btnCancelarTPromo_Click" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:View>
                                <asp:View ID="vBusquedaTipoPromo" runat="server">
                                    <h5 style="color:darkblue">Muestra Tipo de Promociones</h5> 

                                    <asp:table ID="Table5" runat="server" CellSpacing="15" CellPadding="15">
                                        <asp:TableRow>
                                            <asp:TableCell VerticalAlign="Top">
                                                <asp:Button ID="btnNvoTipoPromo" runat="server" Text="Nuevo Tipo Promoción" OnClick="btnNvoTipoPromo_Click" Width="200px"/>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell Width="520px">
                                                <telerik:RadGrid ID="grvTipoPromo"  runat="server" PageSize="5" AutoGenerateColumns="False" AllowPaging="true"  AllowSorting="true" OnItemCommand="grvTipoPromo_ItemCommand" CellSpacing="2" GridLines="Both"    Culture="es-MX" OnPageIndexChanged="grvTipoPromo_PageIndexChanged" Width="500px">
                                                <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                                    <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                                                    <RowIndicatorColumn Visible="False">
                                                            </RowIndicatorColumn>
                                                            <Columns>        
                                                                <telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate> 
                                                                    <asp:Button ID="btnEliminarPromo" ToolTip="Elimina Promoción" runat="server"  Text="Eliminar" Width="80px" CommandArgument='<%# Eval("Id")%>' Font-Size="13px" CommandName="EliminaPromocion" TabIndex="0"/>
                                                                </ItemTemplate>
                                                                </telerik:GridTemplateColumn> 
                                                                <telerik:GridTemplateColumn  HeaderText="" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate> 
                                                                    <asp:Button ID="btnEditarPromo" ToolTip="Editar Promoción" runat="server"  Text="Editar" Width="80px" CommandArgument='<%# Eval("Id")%>' Font-Size="13px" CommandName="EditaPromocion" TabIndex="1"/>
                                                                </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter column2 column" HeaderStyle-ForeColor="Black" HeaderText="IdPromocion" UniqueName="column2">
                                                                    </telerik:GridBoundColumn>  
                                                                <telerik:GridBoundColumn DataField="TipoPromocion" ItemStyle-Width="200px" FilterControlAltText="Filter column3 column" HeaderStyle-ForeColor="Black" HeaderText="Promocion" UniqueName="column3">
                                                                    </telerik:GridBoundColumn>  
                                                            </Columns>
                                                        <PagerStyle PageSizeControlType="None"/>
                                                </MasterTableView>
                                                <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                                </telerik:RadGrid>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:table>
                                </asp:View>
                                <asp:View ID="vEditaTipoPromo" runat="server">
                                    <h5 style="color:darkblue">Editar Tipos de Promoción</h5> 

                                        <asp:Table runat="server" ID="Table6" >
                                            <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label runat="server" ID="label6" Text="Nombre Tipo de Promoción:" ></asp:Label>
                                            </asp:TableCell>
                                                <asp:TableCell>
                                                    &nbsp;&nbsp;<asp:TextBox ID="txtEditTPromo" runat="server" Width="350px"></asp:TextBox>
                                            </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnEditaTpromo" runat="server" Text="Guardar" OnClick="btnEditaTpromo_Click" />
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnCancelaTPromo" runat="server" Text="Cancelar" OnClick="btnCancelaTPromo_Click" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                        </asp:Table>
                                </asp:View>
                            </asp:MultiView>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="rpvLimites" runat="server" Height="350" Style="overflow: hidden">
                            <asp:MultiView ID="mvCatLimites" runat="server" ActiveViewIndex="0">
                                <asp:View ID="vAltaLimites" runat="server">
                                <br />
                                <h5 style="color:darkblue">Alta de Límites</h5> 
                                <br /> <br />
                                <asp:Table runat="server" ID="tblLimites" >
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label runat="server" ID="label11" Text="Nombre Límite:" ></asp:Label>
                                        </asp:TableCell>
                                            <asp:TableCell>
                                                &nbsp;&nbsp;<asp:TextBox ID="txtLimite" runat="server" Width="350px"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label runat="server" ID="label12" Text="Cantidad dias:" ></asp:Label>
                                        </asp:TableCell>
                                            <asp:TableCell>
                                                &nbsp;&nbsp;<asp:TextBox ID="txtDias" runat="server" Width="30px" MaxLength="2"></asp:TextBox>
                                                 <cc1:FilteredTextBoxExtender ID="ftxtExDias" runat="server" FilterType="Numbers" TargetControlID="txtDias">
                                                </cc1:FilteredTextBoxExtender>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnGuardarLimites" runat="server" Text="Guardar" OnClick="btnGuardarLimites_Click" />
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnCancelarLimtes" runat="server" Text="Cancelar" OnClick="btnCancelarLimtes_Click" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:View>
                                <asp:View ID="vBusquedaLimites" runat="server">
                                <h5 style="color:darkblue">Mustra Límites</h5> 
                                    <asp:table ID="tblLimitesBusqueda" runat="server" CellSpacing="15" CellPadding="15">
                                        <asp:TableRow>
                                            <asp:TableCell VerticalAlign="Top">
                                                <asp:Button ID="btnNuevoLimite" runat="server" Text="Nuevo Límite" OnClick="btnNuevoLimite_Click" Width="200px"/>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell Width="520px">
                                                <telerik:RadGrid ID="grvLimites"  runat="server" PageSize="5" AutoGenerateColumns="False" AllowPaging="true"  AllowSorting="true" OnItemCommand="grvLimites_ItemCommand" CellSpacing="2" GridLines="Both"    Culture="es-MX" OnPageIndexChanged="grvLimites_PageIndexChanged" Width="500px">
                                                <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                                    <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                                                    <RowIndicatorColumn Visible="False">
                                                            </RowIndicatorColumn>
                                                            <Columns>        
                                                                <telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate> 
                                                                    <asp:Button ID="btnEliminarLimite" ToolTip="Elimina límite" runat="server"  Text="Eliminar" Width="80px" CommandArgument='<%# Eval("IdPeriodo")%>' Font-Size="13px" CommandName="EliminaLimite" TabIndex="0"/>
                                                                </ItemTemplate>
                                                                </telerik:GridTemplateColumn> 
                                                                <telerik:GridTemplateColumn  HeaderText="" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate> 
                                                                    <asp:Button ID="btnEditarLimite" ToolTip="Editar Límite" runat="server"  Text="Editar" Width="80px" CommandArgument='<%# Eval("IdPeriodo")%>' Font-Size="13px" CommandName="EditaLimite" TabIndex="1"/>
                                                                </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridBoundColumn DataField="IdPeriodo" FilterControlAltText="Filter column2 column" HeaderStyle-ForeColor="Black" HeaderText="IdPeriodo" UniqueName="column2">
                                                                    </telerik:GridBoundColumn>  
                                                                <telerik:GridBoundColumn DataField="Periodo" ItemStyle-Width="200px" FilterControlAltText="Filter column3 column" HeaderStyle-ForeColor="Black" HeaderText="Periodo" UniqueName="column3">
                                                                    </telerik:GridBoundColumn>  
                                                            </Columns>
                                                        <PagerStyle PageSizeControlType="None"/>
                                                </MasterTableView>
                                                <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                                </telerik:RadGrid>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:table>
                                </asp:View>
                                <asp:View ID="vEditaLimite" runat="server">
                                <br />
                                <h5 style="color:darkblue">Editar Límites</h5> 
                                <br /> <br />
                                <asp:Table runat="server" ID="tblEditaLimites" >
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label runat="server" ID="label13" Text="Nombre Límite:" ></asp:Label>
                                        </asp:TableCell>
                                            <asp:TableCell>
                                                &nbsp;&nbsp;<asp:TextBox ID="txtModLimite" runat="server" Width="350px"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <%--<asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label runat="server" ID="label14" Text="Cantidad dias:" ></asp:Label>
                                        </asp:TableCell>
                                            <asp:TableCell>
                                                &nbsp;&nbsp;<asp:TextBox ID="txtModDias" runat="server" Width="30px" MaxLength="2"></asp:TextBox>
                                                 <cc1:FilteredTextBoxExtender ID="ftxtEDias" runat="server" FilterType="Numbers" TargetControlID="txtModDias">
                                                </cc1:FilteredTextBoxExtender>
                                        </asp:TableCell>
                                    </asp:TableRow>--%>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnModLimiteGuarda" runat="server" Text="Guardar" OnClick="btnModLimiteGuarda_Click" />
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button ID="btnModLimiteCancela" runat="server" Text="Cancelar" OnClick="btnModLimiteCancela_Click" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:View>
                            </asp:MultiView>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                </div>
    </asp:Panel>



            <%--Popup dinamico para eliminar elementos de la dbase--%>
            <div id="popReg" style="display: none; background-color: rgba(0, 0, 0, 0.5); z-index: 20000; left: 0%; position: absolute; top: 0px; width:100%; height: 100%; text-align: center;">
				<div  style="background-color: #333333; max-width: 400px; padding: 15px; width: 100%; display: inline-block; vertical-align: middle; height: 160px; margin-top:18%; max-height: 440px;">
					<div class="modal-content"  style="background-color:#E2E1E1; height:135px; background-image:url(; background-repeat: repeat-x"../Images/background2.jpg");>
						<div style=" margin-top:0%;">
                                <asp:Table ID="tblBotones3" runat="server" HorizontalAlign="Center" CellSpacing="5" CellPadding="3" Width="320">
							<asp:TableRow>
								<asp:TableCell RowSpan="3" HorizontalAlign="Center"  VerticalAlign="Middle">
                                    <img src="../../Imagenes_Benavides/botones/question.png" width="45" height="45"/>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell>
								</asp:TableCell>
								<asp:TableCell ColumnSpan="3" HorizontalAlign="Center"  >
									<h2>
										<asp:Label ID="lblmsgdelete" runat="server" Font-Size="14px" Font-Bold="true" Text ="El laboratorio se eliminara" ></asp:Label><br />
										<asp:Label ID="lblmsg2" runat="server" Font-Size="14px" Font-Bold="true" Text ="¿desea continuar?"></asp:Label><br />
									</h2>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell>
								</asp:TableCell>
								<asp:TableCell>
									<asp:Button ID="btnSi" runat="server" CssClass="input" OnClick="btnSi_Click" Width="100" Text="Sí" />
								</asp:TableCell>
									<asp:TableCell Width="20px">
								</asp:TableCell>
								<asp:TableCell>
									<asp:Button ID="btnNo" runat="server" CssClass="input"  Width="100"  Text="No" />
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
                        </div>
	                </div>
	            </div>
            </div>

            <%-- Popup asignación de laboratorio x categorias--%>
            <div id="popRegAsiglab" style="display: none; background-color: rgba(0, 0, 0, 0.5); z-index: 20000; left: 0%; position: absolute; top: 0px; width:100%; height: 100%; text-align: center;">
				<div  style="background-color: #333333; max-width: 400px; padding: 15px; width: 100%; display: inline-block; vertical-align: middle; height: 240px; margin-top:18%; max-height: 440px;">
					<div class="modal-content"  style="background-color:#E2E1E1; height:215px; background-image:url(; background-repeat: repeat-x"../Images/background2.jpg");>
						<div style=" margin-top:0%;top:0%;">
                            <asp:Table ID="Table7" runat="server" HorizontalAlign="Center" CellSpacing="5" CellPadding="3" Width="320">
							<asp:TableRow>
								<asp:TableCell RowSpan="4" HorizontalAlign="Center"  VerticalAlign="Middle">
                                    <img src="../../Imagenes_Benavides/botones/question.png" width="45" height="45"/>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell>
								</asp:TableCell>
								<asp:TableCell ColumnSpan="3" HorizontalAlign="Center"  >
									<h2>
										<asp:Label ID="Label9" runat="server" Font-Size="14px" Font-Bold="true" Text ="Se dispone a reasignar laboratorio" ></asp:Label><br />
										<asp:Label ID="Label10" runat="server" Font-Size="14px" Font-Bold="true" Text ="¿que desea hacer?"></asp:Label><br />
									</h2>
								</asp:TableCell>
							</asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                    </asp:TableCell>
                                    <asp:TableCell ColumnSpan="3">
                                         <telerik:RadComboBox ID="rcbLaboratorios" AutoPostBack="false" ZIndex="99999"  Text="---seleccione un laboratorio---" RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  runat="server"   Width="240px"  TabIndex="0" Enabled="true" >
                                         </telerik:RadComboBox>
                                    </asp:TableCell>
                                </asp:TableRow>
							<asp:TableRow>
								<asp:TableCell>
								</asp:TableCell>
								<asp:TableCell>
                                    <br />
								<asp:Button ID="btnAsignarSolouno" runat="server" CssClass="input" Font-Size="12px" OnClick="btnAsignarSolouno_Click" Width="100" Text="Un elemento" />
								</asp:TableCell>
								<asp:TableCell>
                                    <br />
									<asp:Button ID="btnAsignarTodos" runat="server" CssClass="input"  Font-Size="12px" Width="130" OnClick="btnAsignarTodos_Click" Text="Todos los elementos" />
								</asp:TableCell>
                                <asp:TableCell>
                                    <br />
									<asp:Button ID="btnCancelarAsigLab" runat="server" CssClass="input" Font-Size="12px"  Width="80" Text="Cancelar" />
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
                        </div>
	                </div>
	            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content> 
