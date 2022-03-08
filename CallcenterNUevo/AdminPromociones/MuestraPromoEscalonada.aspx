<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MuestraPromoEscalonada.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.MuestraPromoEscalonada" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />
    <script src="jsAdminProm/jsAdminPromocion.js"></script>

     <script type="text/javascript">
         function GetKey(e) {
             var keynum;
             if (window.event) { keynum = e.keyCode; }
             else if (e.which) { keynum = e.which; }
             return keynum;
         }

         function GetChar(ev) {
             var ev = ev || window.event;
             var chr = ev.charCode || ev.keyCode;
             return String.fromCharCode(chr);
         }

         function ValidarTecla(ev) {
             var key = GetKey(ev);
             //if (!(key == 44 || key == 45 || key == 46 || key == 13 || (key >= 48 && key <= 57))) {
             if (!(key == 46 || key == 13 || (key >= 48 && key <= 57))) {
                 var chr = GetChar(ev);
                 if (/^\d[,|\.]\d*/.test(chr)) {
                     return true;
                 } else {
                     return false;
                 }
             } else {
                 return true;
             }
         }
        </script>

     <asp:UpdatePanel ID="upConsultaModPromoEscalonada" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="mvPromEsc" runat="server" ActiveViewIndex="0">
                <asp:View ID="vConsultaModificaPromoEscalonada" runat="server">
                            <h4 style="color:darkblue">Consulta Promociones Escalonadas.</h4> 
                            <br />
                            <center>
                            <asp:Table ID="tblBuquedas" runat="server" Width ="550px">
                                <asp:TableRow >
                                    <asp:TableCell>
                                        <asp:Label runat="server" Text="Cupón / Promoción / MensajePOS:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtNomPromEscalonada" runat="server" Width ="150px" Tabindex="1"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" Tabindex="2" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow >
                                    <asp:TableCell ColumnSpan="2">
                                        <br />
                                        <telerik:RadGrid ID="grvDatos"  runat="server"  AutoGenerateColumns="False" AllowPaging="true"  PageSize="8"  OnPageIndexChanged="grvDatos_PageIndexChanged"   CellSpacing="2" GridLines="Both" OnItemCommand="grvDatos_ItemCommand"   Culture="es-MX"  Width="550px"  >
                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                        <MasterTableView NoMasterRecordsText="No se encontró información" AllowMultiColumnSorting="true">
                                           <RowIndicatorColumn Visible="False">
                                                    </RowIndicatorColumn>
                                            <ExpandCollapseColumn Created="True">
                                                <HeaderStyle Width="1000px" />
                                            </ExpandCollapseColumn>
                                                    <Columns>        
                                                        <telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                                            <ItemTemplate> 
                                                                <asp:Button ID="btnVer" ToolTip="Ver" runat="server"  Text="Ver" Width="50px" Font-Size="14px" CommandArgument='<%# Eval("Identificador")%>' CommandName="VerDetalle" TabIndex="3"/>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn> 
                                                        <telerik:GridTemplateColumn   HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate> 
                                                                    <asp:Button ID="btnEliminar" ToolTip="Eliminar promoción escalonada" runat="server"  Text="Eliminar" Width="80px" Font-Size="14px" CommandArgument='<%# Eval("Identificador")%>' CommandName="Eliminar" TabIndex="4"/>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn> 
                                                        <telerik:GridBoundColumn DataField="Cupon" FilterControlAltText="Filter column1 column" HeaderText="Cupon" UniqueName="column1">
                                                        </telerik:GridBoundColumn>  
                                                         <telerik:GridBoundColumn DataField="IdPromocion" FilterControlAltText="Filter column1 column" HeaderText="Promoción" UniqueName="column1">
                                                        </telerik:GridBoundColumn>  
                                                         <telerik:GridBoundColumn DataField="FechaIni" FilterControlAltText="Filter column1 column" HeaderText="Fecha Inicio" UniqueName="column1">
                                                        </telerik:GridBoundColumn>
                                                         <telerik:GridBoundColumn DataField="FechaFin" FilterControlAltText="Filter column1 column" HeaderText="Fecha Fin" UniqueName="column1">
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
                            </asp:Table>
                         </center>   
                        </asp:View>

                <asp:View ID="vEditaPromocionEscalonada" runat="server">
                <h4 style="color:darkblue">Modificación de Promociones Escalonadas.</h4> 
                <br />
                    <center>
                        <asp:Table ID="tblPromoEsc" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell columspan="2">
                                            <asp:Table ID="tblFechas" runat="server">
                                                <asp:TableRow>
                                        <asp:TableCell  Height="38px" width="230px">
                                            <asp:Label ID="Label1" runat="server" Text="Fecha Inicio:"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell  Height="38px" width="230px">
                                            <telerik:RadDatePicker ID="rdpFechaInicio" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFechaInicio_SelectedDateChanged" Width="140px" Enabled="true" TabIndex="1" ></telerik:RadDatePicker>
                                        </asp:TableCell>
                                        <asp:TableCell Height="38px">
                                        </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                        <asp:TableCell  Height="38px">
                                                <asp:Label ID="Label2" runat="server" Text="Fecha Fin:"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell  Height="38px">
                                            <telerik:RadDatePicker ID="rdpFechaFin" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFechaFin_SelectedDateChanged" Width="140px" Enabled="true" TabIndex="2" ></telerik:RadDatePicker>
                                        </asp:TableCell>
                                       <asp:TableCell Height="38px">
                                        </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow Height="38px" >
                                        <asp:TableCell >
                                            <asp:CheckBox ID="chkDuracion" runat="server" Text=""  AutoPostBack="true" OnCheckedChanged="chkDuracion_CheckedChanged" TextAlign="Right" TabIndex="3"/>&nbsp;&nbsp;
                                            <asp:Label runat="server" Text="Activar Duración cupón (días):"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell >
                                            <asp:TextBox ID="txtDuracionCupon" runat="server" Width="140px" MaxLength="2" Visible="false" TabIndex="4"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="ftbeDuracionCupon" runat="server" FilterType="Numbers" TargetControlID="txtDuracionCupon"></cc1:FilteredTextBoxExtender>
                                        </asp:TableCell>
                                        </asp:TableRow>

                                       

                                <asp:TableRow Height="38px">
                                    <asp:TableCell >
                                        <asp:CheckBox ID="chkEsPromoTrigger" runat="server" Text=""  AutoPostBack="true" OnCheckedChanged="chkEsPromoTrigger_CheckedChanged"  TextAlign="Right" TabIndex="3"/>&nbsp;&nbsp;
                                        <asp:Label runat="server" Text="Es promo trigger"></asp:Label>
                                    </asp:TableCell>
                                   <asp:TableCell ColumnSpan="4">
                                       <asp:Table ID="tblOpciones" runat="server" Width="300px">
                                           <asp:TableRow  Height="38px">
                                                <asp:TableCell >
                                                    <asp:RadioButton ID="rdbMontoTrigger" runat="server" GroupName="rblst" AutoPostBack="true" Checked="false"  OnCheckedChanged="rdbMontoTrigger_CheckedChanged" Visible="false"/>
                                                    &nbsp;&nbsp;&nbsp;<asp:Label id="lblMontoTrigger" runat="server" Text="Monto trigger " visible="false"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell >
                                                    <asp:TextBox ID="txtMontoTrigger" runat="server" Width="140px" onKeypress="return ValidarTecla(event);" Visible="false"  TabIndex="4" ></asp:TextBox>
                                                </asp:TableCell>
                                           </asp:TableRow>
                                           <asp:TableRow  Height="38px">
                                                <asp:TableCell>
                                                    <asp:RadioButton ID="rdbcodInt" runat="server" GroupName="rblst" AutoPostBack="true" Checked="false" OnCheckedChanged="rdbcodInt_CheckedChanged" Visible="false"/>
                                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblCodInt" runat="server" Text="Código Interno" Visible="false"></asp:Label>
                                                </asp:TableCell>
                                                <asp:TableCell >
                                                    <asp:TextBox ID="txtCodigoInterno" runat="server" Width="140px"  Visible="false" MaxLength="13"  TabIndex="4" ></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="ftbeCodint" runat="server" FilterType="Numbers" TargetControlID="txtCodigoInterno">
                                                    </cc1:FilteredTextBoxExtender>
                                                </asp:TableCell>
                                       </asp:TableRow>
                                   </asp:Table>
                               </asp:TableCell>
                            </asp:TableRow>



                                        <asp:TableRow Height="38px">
                                        <asp:TableCell Width="130px">
                                            <asp:Label ID="Label5" runat="server" Text="Retroceder escalón:"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:RadioButton ID="rdbSi" AutoPostBack ="true" OnCheckedChanged="rdbSi_CheckedChanged" runat="server" Text="Sí" Checked="false" GroupName="opc" />&nbsp;&nbsp;&nbsp;
                                            <asp:RadioButton ID="rdbNo" AutoPostBack ="true" OnCheckedChanged="rdbNo_CheckedChanged" runat="server" Text="No" Checked="true" GroupName="opc" />
                                        </asp:TableCell>
                                        </asp:TableRow>

                                       <asp:TableRow Height="38px">
                                            <asp:TableCell Width="130px">
                                                <asp:Label ID="lblRetornoInicial" runat="server" Text="Aplicar retorno:" Visible="false"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:RadioButton ID="rdbRetornoAnterior" runat="server" AutoPostBack ="true" Text="anterior" Checked="true" GroupName="opcRetornoIni" Visible="false" />&nbsp;&nbsp;&nbsp;
                                                <asp:RadioButton ID="rdbRetornoIni" runat="server" AutoPostBack ="true"  Text="inicio" Checked="false" GroupName="opcRetornoIni" Visible="false"/>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow Height="38px">
                                            <asp:TableCell Width="130px">
                                                <asp:Label ID="lblUso" runat="server" Text="Uso:" Visible="false"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                              <telerik:RadDropDownList runat="server" AutoPostBack="true"  ID="rcmbUso" Skin="Bootstrap"   Visible="false">
                                               <Items>
                                                   <telerik:DropDownListItem Text="Selecciona" Value="-1" />
                                                   <telerik:DropDownListItem Text="Un solo uso" Value="1" />
                                                   <telerik:DropDownListItem Text="Ilimitado" Value="99" />
                                               </Items>
                                              </telerik:RadDropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Selecciona un tipo de uso" ControlToValidate="rcmbUso" CssClass="tooltipDemo" ValidationGroup="ValidaDatos" Display="Dynamic" SetFocusOnError="True" InitialValue="Selecciona"></asp:RequiredFieldValidator>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                  </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>


                            
                            <asp:TableRow>
                                <asp:TableCell columnspan="2">
                                    <br />
                                    <div id="divPromEsc" style="max-height:180px;overflow-y:scroll;overflow:scroll;height:180px;width:730px;" >
                                        <asp:GridView  ID="grvCupones"   ShowHeader ="true" runat="server" CssClass="gridview" AllowPaging="false"   CellSpacing ="1" AutoGenerateColumns ="false"  CellPadding="3" GridLines="Horizontal" HorizontalAlign="left" UseAccessibleHeader ="false" Width ="695px"  Height="100px" Enabled="true" >
                                        <HeaderStyle ForeColor="Black" />
                                            <Columns>
                                                  <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="Label13" runat="server" Text="Id" width ="20px"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtId" runat="server" Text='<%# Eval("Id")%>' width ="20px" Enabled="false" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="Label13" runat="server" Text="Cupón" width ="110px" ></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtCupon" runat="server" Text='<%# Eval("Cupon")%>' TabIndex="5" width ="110px" Enabled="true"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="ftbeCupon" runat="server" FilterType="Numbers"
                                                        TargetControlID="txtCupon">
                                                        </cc1:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                            <asp:Label ID="Label13" runat="server" Text="Id Promoción" width ="60px"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtIdPromocion" runat="server" Text='<%# Eval("IdPromocion")%>'  TabIndex="6" width = "60px" Enabled="true"></asp:TextBox>
                                                        <cc1:FilteredTextBoxExtender ID="ftbeIdCupon" runat="server" FilterType="Numbers"
                                                        TargetControlID="txtIdPromocion">
                                                        </cc1:FilteredTextBoxExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                <HeaderTemplate>
                                                <asp:Label ID="Label13" runat="server" Text="Id Promo Dispara" width ="80px"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                <asp:TextBox ID="txtIdPromoDispara" runat="server" Text='<%# Eval("IdPromocionDispara")%>'  TabIndex="7" width = "60px" Enabled="true"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="ftbeIdPromoDisp" runat="server" FilterType="Numbers"
                                                TargetControlID="txtIdPromoDispara">
                                                </cc1:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                            <asp:Label ID="Label13" runat="server" Text="Mensaje POS" Width ="150px"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtMensajePOS" runat="server" Text='<%# Eval("MensajePOS")%>' width = "300px" TabIndex="8"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                    <HeaderTemplate>
                                                            <asp:Label ID="Label14" runat="server" Text="Eliminar" Width ="150px"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkCupon" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "IdStatus").Equals("1")) ? (bool) true : (bool) false %>' TabIndex="9" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                         </Columns>
                                    </asp:GridView>
                                    </div> 
                                    <br />
                                </asp:TableCell>
                                <asp:TableCell  ColumnSpan ="2" verticalalign="top">
                                    <asp:Button id="btnAgregarElementos" runat="server" Text="Agregar nuevo cupón" OnClick ="btnAgregarElementos_Click" width="200px" visible="true" TabIndex="10" ></asp:Button>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="3">
                                    <asp:Table ID="tblBotones" runat="server" Width="200px">
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick ="btnGuardar_Click" TabIndex="11"/>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" TabIndex="12"/>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </center>
                </asp:View>
            </asp:MultiView>


             <%-- Popup Eliminar --%>
            <asp:Panel ID="pnlDelete" runat="server"  HorizontalAlign="Center" >
                <asp:Table ID="tblEliminar" runat="server" CellSpacing="12" CellPadding="8" HorizontalAlign="Center" Width="350px" BackColor="LightGray">
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
                            <asp:HiddenField ID="selIdMecanica" runat="server" />
                            <asp:HiddenField ID="selTipoAcum" runat="server" />
							<asp:Label ID="lblmsg1" runat="server" Font-Size="14px" Font-Bold="true" Text ="Se eliminara la promoción" ></asp:Label><br />
							<asp:Label ID="lblmsg2" runat="server" Font-Size="14px" Font-Bold="true" Text ="¿desea continuar?"></asp:Label><br />
						</h2>
					</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
					<asp:TableCell>
					</asp:TableCell>
                        <asp:TableCell>
                            <asp:Button runat="server" ID="btnSi"  Text="Sí" Width="100px" OnClick="btnSi_Click" CssClass="input" TabIndex="1" />
                        </asp:TableCell>
                            <asp:TableCell>
                            <asp:Button runat="server" ID="btnNo"  Text="No" Width="100px"  CssClass="input" TabIndex="1" />
                        </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                        <asp:TableCell>
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:Panel>


             <cc1:ModalPopupExtender ID="mpeDelete" runat="server" TargetControlID="btnDeleteTargetExt" PopupControlID="pnlDelete" CancelControlID="btnCancelarDeleteExtender" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

            <asp:Button ID="btnDeleteTargetExt" runat="server" Text="" BackColor="Transparent" BorderStyle="None" Width="0px" Enabled="false"/>
            <asp:Button ID="btnCancelarDeleteExtender" runat="server" Text="" BackColor="Transparent" BorderStyle="None" Width="0px" Enabled="false" />


        </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
