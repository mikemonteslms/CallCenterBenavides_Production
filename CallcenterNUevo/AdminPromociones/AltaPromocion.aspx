<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaPromocion.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.AltaPromocion" maintainScrollPositionOnPostBack="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <script src="../../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />
    
   

    <script type="text/javascript">
        function cambiaFoco(cajadestino)
        {
            //Se obtiene el valor ascii de la tecla presionada 
            var key = window.event.keyCode;

            //Si es enter(13) 
            if (key == 13)
                //Se pasa el foco a la caja destino 
                document.getElementById(cajadestino).focus();
        }

        function isokmaxlength(e, val, maxlengt) {
            var charCode = (typeof e.which == "number") ? e.which : e.keyCode

            if (!(charCode == 44 || charCode == 46 || charCode == 0 || charCode == 8 || (val.value.length < maxlengt))) {
                return false;
            }
        }

        function ShowReg() {
            //debugger;
            var _docHeight = (document.height !== undefined) ? document.height : document.body.scrollHeight;
            var _docWidth = (document.width !== undefined) ? document.width : document.body.offsetWidth;

            $('#popReg').fadeIn('slow');
            $('#popReg').height(_docHeight);
            return false;
        }


        function ShowRegDelete() {
            //debugger;
            var _docHeight = (document.height !== undefined) ? document.height : document.body.scrollHeight;
            var _docWidth = (document.width !== undefined) ? document.width : document.body.offsetWidth;

            $('#popRegDelete').fadeIn('slow');
            $('#popRegDelete').height(_docHeight);
            return false;
        }
        
    </script>

    
    <asp:Label runat="server" ID="lblTitulo" Text="Alta de Promociones (A+A, A+B, etc...)"  Font-Size="16px" ForeColor="DarkBlue"/>
    <asp:UpdatePanel ID="upAltaPromocion" runat="server">
        <ContentTemplate>
            <br />
            <asp:Panel runat="server" ID="pnlAltaProm" ScrollBars="Auto" Width="100%" Height="100%"> 
             <asp:Table ID="tblDtealle" runat="server" HorizontalAlign="Center"   Width="950px" Height="100%">
                        <asp:TableRow>
                            <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Segmento:"></asp:Label>
                            </asp:TableCell>
                             <asp:TableCell Height="38px">
                                 <telerik:RadComboBox ID="rcbSegmento"  RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  runat="server"   OnSelectedIndexChanged="rcbSegmento_SelectedIndexChanged"  Width="260px"  TabIndex="0" Enabled="true" >
                                 </telerik:RadComboBox>
                            </asp:TableCell>
                              <asp:TableCell >
                                 <asp:Label ID="lblNomProdADE" runat="server" Text="Descripción del producto A+$: " ForeColor="DarkBlue" Width="150px" Visible="false"></asp:Label><asp:TextBox ID="txtNomProdADE" runat="server" Text="" Width="220px" Visible="false"></asp:TextBox>
                                 <asp:Label ID="lblNomProdMM" runat="server" Text="Descripción del producto M&M: " ForeColor="DarkBlue" Width="150px" Visible="false"></asp:Label><asp:TextBox ID="txtNomProdMM" runat="server" Text="" Width="220px" Visible="false"></asp:TextBox>
                             </asp:TableCell >
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Height="38px">
                                    <asp:Label runat="server" text="Tipo promoción:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell Height="38px">
                                     <telerik:RadComboBox ID="rcbTipoPromocion" AutoPostBack="true"  RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  runat="server"   OnSelectedIndexChanged="rcbTipoPromocion_SelectedIndexChanged"  Width="260px"  TabIndex="0" Enabled="true" >
                                     </telerik:RadComboBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                </asp:TableCell>
                            </asp:TableRow>
                           
                         <asp:TableRow>
                             <asp:TableCell ColumnSpan="3">
                                
                                <asp:GridView  ID="grvProd"  runat="server" CssClass="gridview"  OnRowDeleting="grvProd_RowDeleting"  OnRowDataBound="grvProd_RowDataBound"  CellSpacing ="1" AutoGenerateColumns ="false"   CellPadding="3" GridLines="Horizontal" HorizontalAlign="left"  Width ="600px"  Height="100%" Caption="Productos"  >
                                        <HeaderStyle ForeColor="Black"   />
                                            <Columns>
                                                <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                        Código acumula
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtcod" runat="server" Text='<%# Eval("CodigoInterno")%>' AutoPostBack="true" MaxLength="8" OnTextChanged="txtcod_TextChanged"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="ftbeCodInterno" runat="server" FilterType="Numbers" TargetControlID="txtcod">
                                                        </cc1:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                        Categoría
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                         <asp:TextBox ID="txtCat" runat= "server" Text='<%# Eval("IdCat")%>'  Width="100px" Enabled="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                        Nombre producto
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtNomProd" runat="server" Text='<%# Eval("NomProducto")%>' Enabled="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                        Laboratorio
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Table ID="tbllab" runat="server">
                                                            <asp:TableRow>
                                                                <asp:TableCell>
                                                                    <asp:Label ID="lblIdLab" runat= "server" Text='<%# Eval("IdLaboratorio")%>' Visible="false"></asp:Label>
                                                                    <telerik:RadComboBox ID="cmbLab" RenderMode="Lightweight" AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  DataValueField='<%# Eval("IdLaboratorio")%>'  DataTextField='<%# Eval("Laboratorio")%>'  runat="server"  Width="260px">
                                                                    </telerik:RadComboBox>
                                                                </asp:TableCell>
                                                                <asp:TableCell>
                                                                    <asp:Button ID="btnAddLab" runat="server" Text="..." OnClick="btnAddLab_Click" Width="32px" ToolTip="Agregar nuevo laboratorio" Visible="true"/>
                                                                </asp:TableCell>
                                                            </asp:TableRow>
                                                        </asp:Table>
                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                    <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                        Código entrega
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtcodEntrega" runat="server" Text='<%# Eval("CodigoInternoEntrega")%>' MaxLength="8" ></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="ftbeCodEnt" runat="server" FilterType="Numbers" TargetControlID="txtcodEntrega">
                                                        </cc1:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:commandfield ShowDeleteButton="true" DeleteText="Eliminar"   DeleteImageUrl="../Imagenes_Benavides/delete-icon.png" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" headertext="Opciones" Visible="false"/>
                                            </Columns>
                                        </asp:GridView>
                             </asp:TableCell>
                            <asp:TableCell VerticalAlign="Bottom">
                                <asp:Button ID="btnAgregar" runat="server" Text="Nuevo elemento" OnClick="btnAgregar_Click" Width="150px" Visible="false"  />
                            </asp:TableCell>
                        </asp:TableRow>
                         <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Cantidad compra:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                <asp:TextBox ID="txtCantcompra" runat="server" Height="25px"  TabIndex="7"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="ftbeCantidadcompra" runat="server" FilterType="Numbers"
                            TargetControlID="txtcantcompra">
                            </cc1:FilteredTextBoxExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Cantidad entrega:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                 <asp:TextBox ID="txtCantentrega" runat="server" AutoPostBack="true" Height="25px" OnTextChanged="txtCantentrega_TextChanged" TabIndex="8"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="ftbeCantidadentrega" runat="server" FilterType="Numbers"
                                                             TargetControlID="txtCantentrega">
                                </cc1:FilteredTextBoxExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Límite período:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                  <telerik:RadComboBox ID="rcbLimPeriodo" AutoPostBack="true" RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"    runat="server"   OnSelectedIndexChanged="rcbLimPeriodo_SelectedIndexChanged"  Width="260px"  TabIndex="0"  Enabled="true" >
                                 </telerik:RadComboBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Límite:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                  <asp:TextBox ID="txtlimcantidad" runat="server" AutoPostBack="true" Height="25px"  Enabled="true" OnTextChanged="txtlimcantidad_TextChanged"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="ftbelimCantidad" runat="server" FilterType="Numbers"
                            TargetControlID="txtlimcantidad">
                            </cc1:FilteredTextBoxExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Fecha solicitud:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                <telerik:RadDatePicker ID="rdpFSolicitud" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFSolicitud_SelectedDateChanged" Width="140px"  Enabled="true" ></telerik:RadDatePicker>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Fecha inicio:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                <telerik:RadDatePicker ID="rdpFIni" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFIni_SelectedDateChanged" Width="140px" Enabled="true" ></telerik:RadDatePicker>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Fecha fin:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                <telerik:RadDatePicker ID="rdpFFin" AutoPostBack="true" runat="server" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFFin_SelectedDateChanged" Width="140px" Enabled="true" ></telerik:RadDatePicker>
                            </asp:TableCell>
                           
                        </asp:TableRow>
                         <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Fecha conteo:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                <telerik:RadDatePicker ID="rdpFConteo" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFConteo_SelectedDateChanged" Width="140px"  ></telerik:RadDatePicker>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
                                <asp:CheckBox ID="chkVerWS" runat="server" Checked="true" Text="Visible desde WS:" TextAlign="Left" />
                            </asp:TableCell>
                        </asp:TableRow>

                        <%-- Nuevo requerimiento Fecha Extención y Sugeridos --%>
                

                        <asp:TableRow >
                                <asp:TableCell  Height="38px" HorizontalAlign="left" >
                                <asp:Panel ID="pnlExtencion" runat="server" Visible="true"  HorizontalAlign="Left" Width="350px">
                                    <asp:Table ID="tblExt" runat="server" >
                                        <asp:TableRow>
                                            <asp:TableCell ColumnSpan="2">
                                                <asp:CheckBox ID="chkAplicaExt" runat="server" AutoPostBack ="true" Text="Aplicar extensión" TextAlign="Right" OnCheckedChanged="chkAplicaExt_CheckedChanged" Visible="true"/>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label id="lblFext" runat="server" text="Fecha extensión:" Visible="false"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <telerik:RadDatePicker ID="rdpFExt" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFExt_SelectedDateChanged" Width="140px" Visible="false"></telerik:RadDatePicker>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:Panel>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                                <asp:TableCell Height="28px" HorizontalAlign="Center" BackColor="LightGray"  >
                                    <asp:RadioButton ID="rdbEntregaSugeridosCierre" runat="server" GroupName ="sugeridos" Checked="true"  Enabled="false"  />
                                </asp:TableCell>
                                <asp:TableCell Height="28px" ColumnSpan="2" BackColor="LightGray">
                                    <asp:Label ID="lblEntregaSugeridosCierre" runat="server" Text ="Entregar sugeridos y permitir cerrar los ciclos que se encuentren abiertos." Font-Bold ="true"></asp:Label>
                                </asp:TableCell>
                        </asp:TableRow> 
                        <asp:TableRow>
                                <asp:TableCell Height="28px" HorizontalAlign="Center" BackColor="LightGray">
                                    <asp:RadioButton ID="rdbEntregaSugeridos" runat="server" GroupName ="sugeridos" Enabled="false" />
                                </asp:TableCell>
                                <asp:TableCell Height="28px" ColumnSpan="2" BackColor="LightGray">
                                    <asp:Label ID="lblEntregaSugeridos" runat="server" Text = "Entregar sólo sugeridos." Font-Bold ="true" Enabled="false" ></asp:Label>
                                </asp:TableCell>
                        </asp:TableRow> 



                        <asp:TableRow>
                             <asp:TableCell>
                                <asp:Label runat="server" text="Comentario general:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                  <asp:TextBox ID="txtComentario" runat="server" MaxLength="150"  Width="400px" Height="70px"  onkeypress="return isokmaxlength(event,this,150);" TextMode="MultiLine" TabIndex="9" Enabled="true" ></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                 <asp:TableRow>
                     <asp:TableCell>
                         <br />
                         <asp:Table ID="tblbotones" runat="server">
                             <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Button runat="server" ID="btnGuardar"  Text="Guardar" Width="100px" OnClick="btnGuardar_Click" CssClass="input" />
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Button runat="server" ID="btnCancelar"  Text="Cancelar" Width="100px" OnClick="btnCancelar_Click" CssClass="input" />
                                </asp:TableCell>
                             </asp:TableRow>
                         </asp:Table>
                     </asp:TableCell>
                 </asp:TableRow>
                    </asp:Table>

            <%-- Pantalla Modal (Alta de laboratorio) --%>
            <div id="popReg" style="display: none; background-color: rgba(0, 0, 0, 0.5); z-index: 20000; left: 0%; position: absolute; top: 0px; width:100%; height: 100%; text-align: left;">
					<div  style="background-color: #333333; max-width: 500px; padding: 15px; width: 100%; display: inline-block; vertical-align: middle; height: 450px; margin-top:5%; margin-left :34%; max-height: 450px;">
					    <div class="modal-content"  style="background-color:#E2E1E1; height:430px; background-image:url(; background-repeat: repeat-x"../Images/background2.jpg");>
						    <div style=" margin-top:0%;margin-left:3%">
                                 <div style="text-align: left; top: 0px;margin-left :93%;">
                                     <asp:Button ID="btnCerrar" runat="server" Text="X" ToolTip="Cerrar" Width="32px"  OnClick="btnCerrar_Click"/>
                                 </div>
                                
                                <br /><br />
                                <asp:Panel ID="pnlBusquedaAvanzada" runat="server" GroupingText="">
                                    <div class="demo-container no-bg">
                                        <asp:HiddenField ID="IdLab" runat="server" />
                                        <telerik:RadTabStrip RenderMode="Lightweight" ID="tabCatalogosPromociones" runat="server"  EnableDragToReorder="true" Skin="Silk" MultiPageID="rmpCatalogos" SelectedIndex="0">
                                        <Tabs>
                                        <telerik:RadTab Text="Laboratorios" Selected="true"></telerik:RadTab>
                                        </Tabs>
                                        </telerik:RadTabStrip>
                                        <telerik:RadMultiPage ID="rmpCatalogos" runat="server"  CssClass="RadMultiPage" SelectedIndex="0" Height="350px">
                                        <telerik:RadPageView ID="rpvLaboratorio" runat="server" CssClass="RadMultiPage"  Height="350" Style="overflow: hidden">
                                        <asp:MultiView ID="mvCatLab" runat="server" ActiveViewIndex="0">
                                            <asp:View ID="vAltaLab" runat="server">
                                                <br />
                                                <h5 style="color:darkblue">Alta de laboratorios</h5> 
                                                <br />
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
                                                <asp:Button ID="btnGuardarnvoLab" runat="server" Text="Guardar" OnClick="btnGuardarnvoLab_Click" />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                <br />
                                                <asp:Button ID="btnCancelarnvoLab" runat="server" Text="Cancelar" OnClick="btnCancelarnvoLab_Click" />
                                                </asp:TableCell>
                                                </asp:TableRow>
                                                </asp:Table>
                                            </asp:View>
                                            <asp:View ID="vBusquedaLab" runat="server">
                                                <h5 id="htitle" runat="server" style="color:darkblue" title ="Muestra Laboratorios"></h5> 
                                                <asp:HiddenField ID="txtLabForzar" runat="server"/>
                                                <asp:table ID="tblCatLaboratorios" runat="server" CellSpacing="15" CellPadding="15">
                                                <asp:TableRow>
                                                <asp:TableCell Width="520px">
                                                <telerik:RadGrid ID="grvLaboratorios"  runat="server"  PageSize="3" AutoGenerateColumns="False" AllowPaging="true" AllowSorting="true" OnItemCommand="grvLaboratorios_ItemCommand" CellSpacing="2" GridLines="Both"    Culture="es-MX" OnPageIndexChanged="grvLaboratorios_PageIndexChanged" Width="450px">
                                                <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                                <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                                                <RowIndicatorColumn Visible="False">
                                                </RowIndicatorColumn>
                                                <Columns>        
                                                <%--<telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate> 
                                                    <asp:Button ID="btnEliminar" ToolTip="Elimina laboratorio" runat="server"  Text="Eliminar" Width="80px" CommandArgument='<%# Eval("IdLaboratorio")%>' Font-Size="13px" CommandName="EliminaLab" TabIndex="0"/>
                                                </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                                <telerik:GridTemplateColumn  HeaderText="" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate> 
                                                    <asp:Button ID="btnSeleccionar" ToolTip="Seleccionar laboratorio" runat="server"  Text="Seleccionar" Width="80px" CommandArgument='<%# Eval("IdLaboratorio")%>' Font-Size="13px" CommandName="SelLab" TabIndex="1"/>
                                                </ItemTemplate>
                                                </telerik:GridTemplateColumn >
                                                <telerik:GridBoundColumn DataField="IdLaboratorio"  FilterControlAltText="Filter column2 column" HeaderStyle-ForeColor="DarkBlue" HeaderText="IdLaboratorio" UniqueName="column2">
                                                    </telerik:GridBoundColumn>  
                                                <telerik:GridBoundColumn DataField="Laboratorio" ItemStyle-Width="200px" FilterControlAltText="Filter column3 column" HeaderStyle-ForeColor="DarkBlue" HeaderText="Laboratorio" UniqueName="column3">
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
                                                                <asp:TableRow>
                                                                    <asp:TableCell ColumnSpan="2">
                                                                        <br />
                                                                         <asp:Label id="lblmsgForzar" runat ="server" ForeColor="Red" Text ="Si esta seguro de registrar el laboratorio  presione botón Forzar Alta, en caso contrario presione el botón Cancelar." Visible="false"></asp:Label>
                                                                    </asp:TableCell>
                                                                </asp:TableRow>
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
                                                <br />
                                                <h5 style="color:darkblue">Editar Laboratorios</h5> 
                                                <br />
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
                                                <asp:Button ID="btnModificarLab" runat="server" Text="Guardar" OnClick="btnModificarLab_Click" />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                <br />
                                                <asp:Button ID="btnEditCancelar" runat="server" Text="Cancelar" OnClick="btnEditCancelar_Click" />
                                                </asp:TableCell>
                                                </asp:TableRow>
                                                </asp:Table>
                                            </asp:View>>
                                        </asp:MultiView>
                                        </telerik:RadPageView>
                                        </telerik:RadMultiPage>
                                     </div>
                                </asp:Panel>
                            </div>
	                    </div>
	                </div>
                </div>

            <div id="popRegDelete" style="display: none; background-color: rgba(0, 0, 0, 0.5); z-index: 20000; left: 0%; position: absolute; top: 0px; width:100%; height: 100%; text-align: center;">
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
										<asp:Label ID="lblmsg1" runat="server" Font-Size="14px" Font-Bold="true" Text ="El laboratorio se eliminara" ></asp:Label><br />
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
									<asp:Button ID="btnNo" runat="server" CssClass="input"  OnClick="btnNo_Click" Width="100"  Text="No" />
								</asp:TableCell>
							</asp:TableRow>
						</asp:Table>
                        </div>
	                </div>
	            </div>
            </div>
          </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
