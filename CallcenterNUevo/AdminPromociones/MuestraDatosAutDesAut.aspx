<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MuestraDatosAutDesAut.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.MuestraDatosAutDesAut" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
     <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />
    <script src="jsAdminProm/jsAdminPromocion.js"></script>

    <script type="text/javascript">
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
    <asp:Label runat="server" ID="lblTitulo" Text="Promociones por autorizar o desautorizar"  Font-Size="16px" ForeColor="DarkBlue"/>
    <br />
    <asp:UpdatePanel ID="upAutoDesAut" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pnlMuestraDatosAutDesAut" ScrollBars="Auto" Width="100%" Height="100%">
            <asp:Table ID="tblDtealle" runat="server" HorizontalAlign="Center"  Width="950px" Height="100%">
                <asp:TableRow>
                    <asp:TableCell  HorizontalAlign="Right">
                        <asp:Label ID="lblPase" runat="server" ForeColor="DarkBlue" Font-Size="14px" Font-Bold="true"  Text="Fecha pase a producción: " Visible="false" ></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblFechaPase" runat="server" ForeColor="Red" Font-Size="14px" Font-Bold="true"  Text="" Visible="false"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
                        <asp:Label ID="Label1" runat="server" ForeColor="DarkBlue" Font-Size="14px" Font-Bold="true"  Text="Estatus: " ></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblEstatus" runat="server" ForeColor="Red" Font-Size="14px" Font-Bold="true"  Text="" ></asp:Label>
                    </asp:TableCell>
                    </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Width="250px">
                                <asp:Label runat="server" text="Segmento:"></asp:Label>
                            </asp:TableCell>
                             <asp:TableCell Width="250px">
                                 <telerik:RadComboBox ID="rcbSegmento"  RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  runat="server"   OnSelectedIndexChanged="rcbSegmento_SelectedIndexChanged"  Width="260px"  TabIndex="0" Enabled="false"  >
                                 </telerik:RadComboBox>
                            </asp:TableCell>
                             <asp:TableCell >
                             </asp:TableCell >
                            </asp:TableRow>
                            <asp:TableRow>
                             <asp:TableCell  Height="38px">
                                <asp:Label runat="server" text="Tipo promoción:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                 <telerik:RadComboBox ID="rcbTipoPromocion" AutoPostBack="true" RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  runat="server"   OnSelectedIndexChanged="rcbTipoPromocion_SelectedIndexChanged"  Width="260px"  TabIndex="1" Enabled="false" >
                                 </telerik:RadComboBox>
                            </asp:TableCell>
                             <asp:TableCell  Height="38px">
                                 <asp:Label ID="lblNomProdMM" runat="server" Text="Descripción del producto: " ForeColor="DarkBlue" Width="150px" Visible="false"></asp:Label><asp:TextBox ID="txtNomProdMM" runat="server" Text="" Width="220px" Visible="false"></asp:TextBox>
                             </asp:TableCell >
                        </asp:TableRow>
                       
                         <asp:TableRow>
                             <asp:TableCell ColumnSpan="3" Height="38px">
                                 <asp:GridView  ID="grvProd"  ShowHeader ="true" runat="server" CssClass="gridview" AllowPaging="true" OnRowDataBound="grvProd_RowDataBound" OnRowDeleting="grvProd_RowDeleting" OnPageIndexChanging="grvProd_PageIndexChanging"  CellSpacing ="1" AutoGenerateColumns ="false"  CellPadding="3" GridLines="Horizontal" HorizontalAlign="left" UseAccessibleHeader ="false" Width ="500px"  Height="100%" Enabled="false" Caption="Productos:">
                            <HeaderStyle ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                        <HeaderTemplate>
                                            Código
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtcod" runat="server" AutoPostBack="true"  Text='<%# Eval("CodigoInterno")%>' OnTextChanged="txtcod_TextChanged" MaxLength="8" TabIndex="2"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftbeCodInt" runat="server" FilterType="Numbers"
                                            TargetControlID="txtcod"></asp:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                        <HeaderTemplate>
                                            Nombre producto
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNomProd" runat="server" Text='<%# Eval("NomProducto")%>' TabIndex="3"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                        <HeaderTemplate>
                                            Categoría
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblIdCat" runat= "server" Text='<%# Eval("Categoria")%>' Width="100px"></asp:TextBox>
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
                                            <asp:FilteredTextBoxExtender ID="ftbeCodIntEnt" runat="server" FilterType="Numbers"
                                            TargetControlID="txtcodEntrega"></asp:FilteredTextBoxExtender>
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
                                 <asp:TextBox ID="txtCantentrega" runat="server" AutoPostBack="true" Height="25px" OnTextChanged="txtCantentrega_TextChanged" Enabled="false" TabIndex="8"></asp:TextBox>
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
                         <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Fecha conteo:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                <telerik:RadDatePicker ID="rdpFConteo" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFConteo_SelectedDateChanged" Width="140px" Enabled="false" TabIndex="11"></telerik:RadDatePicker>
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
                                <cc1:FilteredTextBoxExtender ID="ftbelimCantidad" runat="server" FilterType="Numbers"  TargetControlID="txtlimcantidad">
                                </cc1:FilteredTextBoxExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
                                <asp:CheckBox ID="chkVerWS" runat="server" Checked="false" Text="Visible desde WS:" TextAlign="Left" Enabled="false" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" HorizontalAlign="Left">
                                <asp:Table ID="tblComentarios" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <div id="divgrid" style="overflow:auto;height:80px;width:600px;" >
                                                <asp:GridView  ID="grvComentarios" runat="server" CssClass="gridview"   CellSpacing ="1" AutoGenerateColumns ="false"   CellPadding="3" GridLines="Horizontal" HorizontalAlign="left"  Width ="580px"  >
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

                <%-- Nueva funcionalidad fecha de extensión --%>
                        <asp:TableRow>
                            <asp:TableCell Height="38px">
                                <asp:Panel ID="pnlExtencion" runat="server" Visible="false">
                                    <asp:Table ID="tblExt" runat="server">
                                        <asp:TableRow>
                                            <asp:TableCell ColumnSpan="2">
                                                <asp:CheckBox ID="chkAplicaExt" runat="server" AutoPostBack ="true" Text="Aplicar extensión" TextAlign="Right" OnCheckedChanged="chkAplicaExt_CheckedChanged" Visible="false"/>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblFext" runat="server" text="Fecha extensión:"  ></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <telerik:RadDatePicker ID="rdpFExt" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFExt_SelectedDateChanged" Width="140px" Enabled="false"></telerik:RadDatePicker>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:Panel>
                            </asp:TableCell>
                        </asp:TableRow>
                        
                        <asp:TableRow>
                                <asp:TableCell Height="28px" HorizontalAlign="Center" BackColor="LightGray" >
                                    <asp:RadioButton ID="rdbEntregaSugeridosCierre" runat="server" GroupName ="sugeridos" Checked="true" Enabled="false"  />
                                </asp:TableCell>
                                <asp:TableCell Height="28px" ColumnSpan="2" HorizontalAlign="left" BackColor="LightGray">
                                    <asp:Label runat="server" Text ="Entregar sugeridos y permitir cerrar los ciclos que se encuentren abiertos." Font-Bold ="true"></asp:Label>
                                </asp:TableCell>
                            <asp:TableCell></asp:TableCell>
                            </asp:TableRow> 
                        <asp:TableRow>
                                <asp:TableCell Height="28px" HorizontalAlign="Center" BackColor="LightGray">
                                    <asp:RadioButton ID="rdbEntregaSugeridos" runat="server" GroupName ="sugeridos" Enabled="false" />
                                </asp:TableCell>
                                <asp:TableCell Height="28px" ColumnSpan="2" BackColor="LightGray">
                                    <asp:Label runat="server" Text = "Entregar sólo sugeridos." Font-Bold ="true" ></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell></asp:TableCell>
                         </asp:TableRow> 


                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <br />
                                <asp:Label runat="server" text="Comentario general:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                <br />
                                  <asp:TextBox ID="txtComentario" runat="server" MaxLength="150"  Width="400px" Height="70px"  onkeypress="return isokmaxlength(event,this,150);" TextMode="MultiLine" TabIndex="14" Enabled="false" ></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                       
                 <asp:TableRow>
                     <asp:TableCell>
                         <br />
                            <asp:Table ID="tblbotones" runat="server" Width="320px">
                                <asp:TableRow>
                                     <asp:TableCell>
                                         <asp:Button runat="server" ID="btnModificar"  Text="Modificar" Width="100px" OnClick="btnModificar_Click" CssClass="input" TabIndex="15"/>
                                     </asp:TableCell>
                                      <asp:TableCell>
                                          <asp:Button runat="server" ID="btnAutDesAut"  Text="Autorizar" Width="100px" OnClick="btnAutDesAut_Click" CssClass="input" TabIndex="1" />
                                     </asp:TableCell>
                                     <asp:TableCell>
                                          <asp:Button runat="server" ID="btnCanela"  Text="Cancelar" Width="100px" OnClick="btnCanela_Click" CssClass="input" TabIndex="1" />
                                     </asp:TableCell>
                                 </asp:TableRow>
                            </asp:Table>
                     </asp:TableCell>
                 </asp:TableRow>
               </asp:Table>


                <div id="popReg" style="display: none; background-color: rgba(0, 0, 0, 0.5); z-index: 20000; left: 0%; position: absolute; top: 0px; width:100%; height: 100%; text-align: center;">
					<div  style="background-color: #333333; max-width: 400px; padding: 15px; width: 100%; display: inline-block; vertical-align: middle; height: 160px; margin-top:18%; max-height: 445px;">
					    <div class="modal-content"  style="background-color:#E2E1E1; height:135px; background-image:url(; background-repeat: repeat-x"../Images/background2.jpg");>
						    <div class="modal-header">
                                <%--<button id="btnCloseReg" type="button" class="close" data-dismiss="modal" runat="server">&times;</button>--%>
                                  <asp:Table ID="tblAutDesAut" runat="server" CellSpacing="12" CellPadding="8" HorizontalAlign="Center" Width="350px">
                                    <asp:TableRow >
                                        <asp:TableCell HorizontalAlign="Center">
                                            <asp:Label runat="server" text="Fecha de pase a producción:"></asp:Label>
                                        </asp:TableCell>
                                        </asp:TableRow >
                                      <asp:TableRow >
                                        <asp:TableCell HorizontalAlign="Center">
                                            <telerik:RadDatePicker ID="rdpFechaPaseProd" ZIndex="99999" runat="server"  Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFechaPaseProd_SelectedDateChanged" Width="120px" Enabled="false" TabIndex="0"></telerik:RadDatePicker>
                                            
                                        </asp:TableCell>
                                     </asp:TableRow>
                                     <asp:TableRow >
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button runat="server" ID="btnAutorizar"  Text="Autorizar" Width="100px" OnClick="btnAutorizar_Click" CssClass="input" TabIndex="1" />
                                        </asp:TableCell>
                                         <asp:TableCell>
                                             <br />
                                            <asp:Button runat="server" ID="btnCancelar"  Text="Cancelar" Width="100px" OnClick="btnCancelar_Click" CssClass="input" TabIndex="1" />
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
