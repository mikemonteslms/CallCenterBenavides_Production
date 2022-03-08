<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MuestraDatos.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.MuestraDatos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />
    <%--<script src="jsAdminProm/jsAdminPromocion.js"></script>--%>
    <script type="text/javascript">
        function isokmaxlength(e, val, maxlengt) {
            var charCode = (typeof e.which == "number") ? e.which : e.keyCode

            if (!(charCode == 44 || charCode == 46 || charCode == 0 || charCode == 8 || (val.value.length < maxlengt))) {
                return false;
            }
        }

        function cambiaFoco(cajadestino) {
            //Se obtiene el valor ascii de la tecla presionada 
            var key = window.event.keyCode;

            //Si es enter(13) 
            if (key == 13)
                //Se pasa el foco a la caja destino 
                document.getElementById(cajadestino).focus();
        }
    </script>
    <br /><br />
    <asp:Label runat="server" ID="lblTitulo" Text="Información de la promoción"  Font-Size="16px" ForeColor="DarkBlue"/>
    <asp:UpdatePanel ID="upDatos" runat="server">
        <ContentTemplate>
            
             <br />
            <asp:Panel runat="server" ID="pnlMuestraDatos" ScrollBars="Auto">
                <asp:Table ID="tblDtealle" runat="server" HorizontalAlign="Center" CellSpacing="12" CellPadding="8"  Width="1100px" Height="100%">
                        <asp:TableRow>
                            <asp:TableCell >
                                <asp:HiddenField ID="strCodigoBarras" runat="server" />
                                <asp:Label runat="server" text="Segmento:"></asp:Label>
                            </asp:TableCell>
                             <asp:TableCell>
                                 <telerik:RadComboBox ID="rcbSegmento"  RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  runat="server"   OnSelectedIndexChanged="rcbSegmento_SelectedIndexChanged"  Width="260px"  TabIndex="0" Enabled="false"  >
                                 </telerik:RadComboBox>
                            </asp:TableCell>
                            </asp:TableRow>
                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Tipo promoción:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                 <telerik:RadComboBox ID="rcbTipoPromocion" AutoPostBack="true" RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  runat="server"   OnSelectedIndexChanged="rcbTipoPromocion_SelectedIndexChanged"  Width="260px"  TabIndex="1" Enabled="false" >
                                 </telerik:RadComboBox>
                            </asp:TableCell>
                            <asp:TableCell  Height="38px">
                                 <asp:Label ID="lblNomProdMM" runat="server" Text="Descripción del producto M&M: " ForeColor="DarkBlue" Width="150px" Visible="false"></asp:Label><asp:TextBox ID="txtNomProdMM" runat="server" Text="" Width="220px" Visible="false"></asp:TextBox>
                             </asp:TableCell >
                        </asp:TableRow>

                       

                         <asp:TableRow>
                             <asp:TableCell ColumnSpan="3"  Height="38px">
                                 <asp:GridView  ID="grvProd"  ShowHeader ="true" runat="server" CssClass="gridview" AllowPaging="true" OnPageIndexChanging="grvProd_PageIndexChanging" OnRowDataBound="grvProd_RowDataBound"  OnRowDeleting="grvProd_RowDeleting"  CellSpacing ="1" AutoGenerateColumns ="false"  CellPadding="3" GridLines="Horizontal" HorizontalAlign="left" UseAccessibleHeader ="false" Width ="500px"  Height="100%" Enabled="false" Caption="Productos:">
                            <HeaderStyle ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                        <HeaderTemplate>
                                            Código
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtcod" runat="server" AutoPostBack="true" Text='<%# Eval("CodigoInterno")%>' OnTextChanged="txtcod_TextChanged" MaxLength="8" TabIndex="2"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                        <HeaderTemplate>
                                            Nombre producto
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNomProd" runat="server" Text='<%# Eval("NomProducto")%>' TabIndex="3" Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                        <HeaderTemplate>
                                            Categoría
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblIdCat" runat="server" Text='<%# Eval("Categoria")%>' Width="100px"></asp:TextBox>
                                            <%--<telerik:RadComboBox ID="cmbCategoria" RenderMode="Lightweight" AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  DataValueField='<%# Eval("Categoria")%>'  DataTextField='<%# Eval("Categoria")%>'   runat="server"  Width="220px" TabIndex="4">
                                            </telerik:RadComboBox>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                        <HeaderTemplate>
                                            Laboratorio
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdLab" runat= "server" Text='<%# Eval("IdLaboratorio")%>' Visible="false"></asp:Label>
                                            <telerik:RadComboBox ID="cmbLab" RenderMode="Lightweight" AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  DataValueField='<%# Eval("IdLaboratorio")%>'  DataTextField='<%# Eval("Laboratorio")%>'  runat="server"  Width="260px" TabIndex="5">
                                            </telerik:RadComboBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                        <HeaderTemplate>
                                            Código entrega
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtcodEntrega" runat="server" Text='<%# Eval("CodigoInternoEntrega")%>' MaxLength="8" TabIndex="6"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:commandfield ShowDeleteButton="true" DeleteText="Eliminar"   DeleteImageUrl="../Imagenes_Benavides/delete-icon.png" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" headertext="Opciones" Visible="false"/>
                                </Columns>
                            </asp:GridView>
                                 <br />
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
                                <asp:TextBox ID="txtcantcompra" runat="server" Height="25px" Enabled="false" TabIndex="7"></asp:TextBox>
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
                                 <asp:TextBox ID="txtCantentrega" runat="server" AutoPostBack="true" OnTextChanged="txtCantentrega_TextChanged" Height="25px" Enabled="false" TabIndex="8"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="ftbeCantidadentrega" runat="server" FilterType="Numbers"
                                                             TargetControlID="txtCantentrega">
                                </cc1:FilteredTextBoxExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Fecha inicio:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                <telerik:RadDatePicker ID="rdpFIni" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFIni_SelectedDateChanged" Width="140px" Enabled="false" TabIndex="9" ></telerik:RadDatePicker>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Fecha fin:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                <telerik:RadDatePicker ID="rdpFFin" AutoPostBack="true" runat="server" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFFin_SelectedDateChanged" Width="140px" Enabled="false" TabIndex="10"></telerik:RadDatePicker>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow >
                             <asp:TableCell ColumnSpan="2">
                                  <asp:Label ID="lblMensajeCancelacion" runat="server" ForeColor="DarkRed" Font-Size ="12px" Font-Bold ="true" Text=""/>
                             </asp:TableCell>
                         </asp:TableRow>
                         <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Fecha conteo:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                <telerik:RadDatePicker ID="rdpFConteo" runat="server" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFConteo_SelectedDateChanged" Width="140px" Enabled="false" TabIndex="11"></telerik:RadDatePicker>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Límite período:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                  <telerik:RadComboBox ID="rcbLimPeriodo" AutoPostBack="true" RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"    runat="server"   OnSelectedIndexChanged="rcbLimPeriodo_SelectedIndexChanged"  Width="260px"  TabIndex="12"  Enabled="false" >
                                 </telerik:RadComboBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Límite cantidad:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                  <asp:TextBox ID="txtlimcantidad" runat="server" Height="25px" Enabled="false" TabIndex="13"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="ftbelimCantidad" runat="server" FilterType="Numbers"
                            TargetControlID="txtlimcantidad">
                            </cc1:FilteredTextBoxExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" HorizontalAlign="Left">
                                <asp:Table ID="tblComentarios" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <div id="divgrid" runat="server" style="overflow:auto;height:80px;width:600px;" >
                                                <asp:GridView  ID="grvComentarios"  runat="server" CssClass="gridview"    CellSpacing ="1" AutoGenerateColumns ="false"   CellPadding="3" GridLines="Horizontal" HorizontalAlign="left"  Width ="580px"   >
                                                <Columns>
                                                    <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtid" runat="server" Text='<%# Eval("id")%>'  Visible="false" ></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtidmec" runat="server" Text='<%# Eval("id_mecanica")%>'  Visible="false" ></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                        <HeaderTemplate>
                                                           Comentarios
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtcoment" runat="server" Text='<%# Eval("comentarios")%>' TextMode="MultiLine" Height="30px" Width ="580px" Enabled="false" ></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                    </asp:GridView>
                                            </div>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
                                <br />
                                <asp:CheckBox ID="chkVerWS" runat="server" Checked="true" Text="Visible desde WS:" TextAlign="Left" Enabled="false" />
                            </asp:TableCell>
                        </asp:TableRow>
                        
                    <%-- Nueva funcionalidad Fecha Extensión --%>
                        <asp:TableRow>
                            <asp:TableCell  Height="38px">
                                <asp:Panel ID="pnlExtencion" runat="server" Visible="false">
                                    <asp:Table ID="tblExt" runat="server">
                                        <asp:TableRow>
                                            <asp:TableCell ColumnSpan="2">
                                                <asp:CheckBox ID="chkAplicaExt" runat="server" AutoPostBack="true"  Text="Aplicar extensión" OnCheckedChanged="chkAplicaExt_CheckedChanged" TextAlign="Right" Enabled ="false" />
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblFext" runat="server" text="Fecha extensión:" Visible="false"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <telerik:RadDatePicker ID="rdpFExt" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFExt_SelectedDateChanged" Width="140px" ></telerik:RadDatePicker>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:Panel>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                                <asp:TableCell Height="28px" HorizontalAlign="Center" BackColor="LightGray"   Width="20%">
                                    <asp:RadioButton ID="rdbEntregaSugeridosCierre" runat="server" GroupName ="sugeridos" Checked="true" Enabled="false"  />
                                </asp:TableCell>
                                <asp:TableCell Height="28px" ColumnSpan="2"  HorizontalAlign="left" BackColor="LightGray" Width="20%" >
                                    <asp:Label runat="server" Text ="Entregar sugeridos y permitir cerrar los ciclos que se encuentren abiertos." Font-Bold ="true"></asp:Label>
                                </asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                        </asp:TableRow> 
                        <asp:TableRow>
                                <asp:TableCell Height="28px" HorizontalAlign="Center" BackColor="LightGray"  Width="20%">
                                    <asp:RadioButton ID="rdbEntregaSugeridos" runat="server" GroupName ="sugeridos" Enabled="false" />
                                </asp:TableCell>
                                <asp:TableCell Height="28px" ColumnSpan="2"  BackColor="LightGray" Width="20%">
                                    <asp:Label runat="server" Text = "Entregar sólo sugeridos." Font-Bold ="true" ></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                         </asp:TableRow> 

                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Comentario general:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                  <asp:TextBox ID="txtComentario" runat="server" MaxLength="150"  Width="400px" Height="70px"  onkeypress="return isokmaxlength(event,this,150);" TextMode="MultiLine" TabIndex="14" Enabled="false" ></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        
                 <asp:TableRow>
                     <asp:TableCell>
                         <br />
                         <asp:Button runat="server" ID="btnModificar"  Text="Modificar" Width="100px" OnClick="btnModificar_Click" CssClass="input" TabIndex="15"/>
                     </asp:TableCell>
                      <asp:TableCell>
                          <br />
                         <asp:Button runat="server" ID="btnCancelar"  Text="Cancelar" Width="100px" OnClick="btnCancelar_Click" CssClass="input" TabIndex="16"/>
                     </asp:TableCell>
                 </asp:TableRow>
                    </asp:Table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
