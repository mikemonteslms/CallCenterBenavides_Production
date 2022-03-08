<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaPromoDobleAcumulacion.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.AltaPromoDobleAcumulacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />

    <script type="text/javascript">
        function cambiaFoco(cajadestino) {
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


    <asp:Label runat="server" ID="lblTitulo" Text="Agrega promociones de apertura..."  Font-Size="16px" ForeColor="DarkBlue"/>
    <br /><br />
     <asp:UpdatePanel id="upaltaPromDobleAcumulacion"  runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="ID_promoXCategoria" runat="server" />

         <center>
          <asp:Table ID="tblDobleAcumulacion" runat="server" CellSpacing="2" CellPadding="5" Width="600px" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell Height="38px" VerticalAlign="Top" Width="150px">
                    <asp:Label runat="server" Text="Descripción:" ></asp:Label>
                </asp:TableCell>
                <asp:TableCell  Height="60px">
                    <asp:TextBox ID="txtDescripcion" runat="server" Height="55px" TextMode="MultiLine" MaxLength="400" onkeypress="return isokmaxlength(event,this,400);"  Width="450px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell  Height="38px">
                    <asp:Label runat="server" Text="Fecha Inicio:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Height="38px">
                    <telerik:RadDatePicker ID="rdpFIni" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFIni_SelectedDateChanged" Width="140px" Enabled="true" ></telerik:RadDatePicker>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Height="38px">
                    <asp:Label runat="server" Text="Fecha Fin:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell Height="38px">
                    <telerik:RadDatePicker ID="rdpFFin" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFFin_SelectedDateChanged" Width="140px" Enabled="true" ></telerik:RadDatePicker>
                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblalertaFechaFin" runat="server" ForeColor="DarkRed" Font-Size="13px"  ></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <br /><br />
                            <asp:Table ID="tblPromoAplica" runat ="server" Width="850px" >
                                <asp:TableRow >
                                    <asp:TableCell ColumnSpan ="2">
                                        <asp:Label ID="Label4" runat="server" Text="Promociones a aplicar" ForeColor="DarkBlue" Font-Size="12" ></asp:Label>
                                        <br /><br />
                                    </asp:TableCell>
                                    <asp:TableCell></asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableCell Width="130px">
                                        <asp:Label ID="Label5" runat="server" Text="Solo activación"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:RadioButton ID="rdbSoloAct" runat="server" GroupName="opc" />
                                    </asp:TableCell>
                                    <asp:TableCell ColumnSpan="2" HorizontalAlign="left" Width="200px">
                                        <asp:Label ID="Label6" runat="server" Text="Todas"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdbTodas" runat="server" Checked="true" GroupName="opc"/>
                                    </asp:TableCell>
                                </asp:TableRow>
                                
                                <asp:TableRow>
                                <asp:TableCell Height="38px" Width="100px" >
                                <asp:Label ID="Label1" runat="server" Text="Cupón:" ></asp:Label>
                                </asp:TableCell> 
                                <asp:TableCell Height="38px" VerticalAlign="Middle" >
                                <asp:CheckBox ID="chkCupon" runat="server"  AutoPostBack="true"  OnCheckedChanged="chkCupon_CheckedChanged" />
                                </asp:TableCell>
                                <asp:TableCell ColumnSpan="2" Height="38px">
                                <telerik:RadComboBox ID="rcbCupones"   RenderMode="Lightweight" AutoPostBack="true"  AllowCustomText="false" Filter="None"  MarkFirstMatch="false"  runat="server"   OnSelectedIndexChanged="rcbCupones_SelectedIndexChanged"  Width="550px"  TabIndex="0" Enabled="true" Visible ="false" >
                                </telerik:RadComboBox>
                                </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                <asp:TableCell Height="38px" Width="100px" >
                                <asp:Label ID="Label2" runat="server" Text="2X Apertura:" ></asp:Label>
                                </asp:TableCell> 
                                <asp:TableCell>
                                <asp:CheckBox ID="chkApertura" runat="server" Enabled="false"   AutoPostBack="true" OnCheckedChanged="chkApertura_CheckedChanged"    Font-Size ="13px"  />
                                </asp:TableCell>
                                <asp:TableCell >
                                <asp:Label ID="lblApertura" runat="server" ForeColor="DarkRed" Font-Size="13px"  ></asp:Label>
                                </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                <asp:TableCell Height="38px" Width="150px" >
                                <asp:Label ID="Label3" runat="server" Text="Dcto. Inapam:" ></asp:Label>
                                </asp:TableCell> 
                                <asp:TableCell>
                                <asp:CheckBox ID="chkDescINAPAM" runat="server"  AutoPostBack="true" OnCheckedChanged="chkDescINAPAM_CheckedChanged"  Font-Size ="13px" />
                                &nbsp;&nbsp;
                                <asp:TextBox ID="txtDescInampam" runat="server" Width="35px" Text ="15" MaxLength="2" Enabled="false"></asp:TextBox>
                                <asp:Label ID="lblporcentaje" runat="server" Text ="%"></asp:Label>
                                <asp:Label ID="lblDesc" runat="server" ForeColor="DarkRed" Font-Size="13px"  ></asp:Label>
                                </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>


                    
            <asp:TableRow>
                <asp:TableCell  ColumnSpan="2" HorizontalAlign="Right" Height="32px">
                    <asp:Button ID="btnAgregarSucursal" runat="server" Text ="Asignar Sucursales" OnClick="btnAgregarSucursal_Click" Width="220px" Enabled="false" />
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell  ColumnSpan="2" >
                    <asp:Label ID="lblregistros" runat="server" Font-Bold="true" Font-Size="14px" Text=""></asp:Label>
                     <telerik:RadGrid ID="grvPromDobleAcumulacion"  runat="server"  AutoGenerateColumns="False" AllowPaging="true" AllowSorting="true"  OnItemCommand="grvPromDobleAcumulacion_ItemCommand" CellSpacing="2" GridLines="Both"   Culture="es-MX" OnPageIndexChanged="grvPromDobleAcumulacion_PageIndexChanged" OnItemDataBound="grvPromDobleAcumulacion_ItemDataBound" OnSortCommand="grvPromDobleAcumulacion_SortCommand" Width="1150px"  >
                            <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                            <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                               <RowIndicatorColumn Visible="False">
                                        </RowIndicatorColumn>
                                <ExpandCollapseColumn Created="True">
                                    <HeaderStyle Width="1150px" />
                                </ExpandCollapseColumn>
                                        <Columns>       
                                            <telerik:GridBoundColumn DataField="IdPromo" FilterControlAltText="Filter column1 column" HeaderText="Id" UniqueName="column1" ItemStyle-Width="25px" Visible="false">
                                                </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter column2 column" HeaderText="Id" UniqueName="column2" HeaderStyle-Width="10px" >
                                                </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="nombre" FilterControlAltText="Filter column3 column" HeaderText="Descripción" UniqueName="column3" HeaderStyle-Width="100px">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="Sucursal" FilterControlAltText="Filter column4 column" HeaderText="Sucursal" UniqueName="column4">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="FechaIni"  FilterControlAltText="Filter column5 column" HeaderText="Fecha Inicio" UniqueName="column5">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="FechaFin" FilterControlAltText="Filter column6 column" HeaderText="Fecha Fin" UniqueName="column6">
                                                </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="FechaFinDesctxt" FilterControlAltText="Filter column7 column" HeaderText="Fecha Fin descuento" UniqueName="column7">
                                                </telerik:GridBoundColumn> 
                                             <telerik:GridBoundColumn DataField="CveSucursal" FilterControlAltText="Filter column8 column"  HeaderText="AlmacenId" UniqueName="column8" HeaderStyle-Width="15px">
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate> 
                                                    <asp:Button ID="btnEditar" ToolTip="Editar" runat="server" Text="Editar" Width="60px" Font-Size="14px" CommandArgument='<%# Eval("Id")%>' CommandName="EditarPromDobleAcumulaSuc" TabIndex="2" Visible="false"/>
                                                    <asp:Button ID="btnEliminar" ToolTip="Eliminar" runat="server" Text="Eliminar" Width="65px" Font-Size="14px" CommandArgument='<%# Eval("Id")%>' CommandName="EliminarPromDobleAcumulaSuc" TabIndex="3" Visible="false"/>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>  
                                        </Columns>
                                        <PagerStyle PageSizeControlType="None"/>
                                        </MasterTableView>
                                        <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                        <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                        </telerik:RadGrid>
                    <br />
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell  Height="32px">
                    <asp:Button ID="btnGuardar" runat="server" Text ="Guardar" OnClick="btnGuardar_Click" Width="150px" Visible="true" />
                </asp:TableCell>
                 <asp:TableCell Height="32px" HorizontalAlign="Left">
                     <asp:Button ID="btnCancelar" runat="server" Text ="Cancelar" OnClick="btnCancelar_Click1" Width ="150px" />
                 </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
     </center>


        <%-- ************************************************************************************************************************************************* --%>   
            <%-- Popup Sucursales --%>
             <asp:Panel ID="pnlPromoAperturas" runat="server"  HorizontalAlign="Center"  >
                 <asp:Table ID="tblAutDesAut" runat="server"  CellSpacing="12" CellPadding="8" HorizontalAlign="Left" Width="400px" BackColor="LightGray"  >
                         <asp:TableRow >
                             <asp:TableCell ColumnSpan ="2">
                                 <br />
                             </asp:TableCell>
                         </asp:TableRow >
                                    <asp:TableRow >
                                        <asp:TableCell Width="200px">
                                            <asp:RadioButton ID="rdbCargaMasiva" runat="server" AutoPostBack="true" Text="Carga masiva" OnCheckedChanged="rdbCargaMasiva_CheckedChanged" Checked="false" GroupName="sucursales"/>
                                        </asp:TableCell>
                                        <asp:TableCell Width="200px">
                                            <asp:RadioButton ID="rdbCargaEspecifica" runat="server" AutoPostBack="true" Text="Carga especifica" OnCheckedChanged="rdbCargaEspecifica_CheckedChanged" Checked="false" GroupName="sucursales"/>
                                        </asp:TableCell>
                                    </asp:TableRow >
                                    <asp:TableRow >
                                        <asp:TableCell>
                                            <asp:Label ID="lblCargaMasiva" runat="server" Text="Carga masiva de sucursales:" Visible="false"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <telerik:RadAsyncUpload ID="FileUplSuc" runat="server" AllowedFileExtensions=".xls,.xlsx" Culture="es-MX" Skin="Bootstrap" EnableEmbeddedSkins="False" MultipleFileSelection="Disabled" AutoAddFileInputs="false" Width="150px" Visible="false">
                                            <Localization Cancel="Cancelar" Remove="Quitar archivo" Select="Adjuntar" />
                                            </telerik:RadAsyncUpload>
                                        </asp:TableCell>
                                    </asp:TableRow >
                                    <asp:TableRow >
                                        <asp:TableCell HorizontalAlign="Right" Height="32px" >
                                            <asp:Label ID="lblCargaEspecifica" runat="server" text="Sucursal:" Visible="false"></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Left" Height="32px">
                                            <telerik:RadComboBox ID="rcbSucursales"   RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  runat="server"   OnSelectedIndexChanged="rcbSucursales_SelectedIndexChanged"  Width="180px"  TabIndex="0" Enabled="true" ZIndex="99999999" Visible="false"></telerik:RadComboBox>
                                        </asp:TableCell>
                                     </asp:TableRow>
                                      <asp:TableRow >
                                          <asp:TableCell HorizontalAlign="Right" Height="32px">
                                            <asp:Label runat="server" text="Fecha Inicio:"></asp:Label>
                                        </asp:TableCell>
                                             <asp:TableCell HorizontalAlign="Left" Height="32px">
                                            <telerik:RadDatePicker ID="rdpFechaInicio"  ZIndex="99999999" runat="server"  Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFechaInicio_SelectedDateChanged" Width="120px"  TabIndex="0"></telerik:RadDatePicker>
                                        </asp:TableCell>
                                      </asp:TableRow>
                                      <asp:TableRow >
                                          <asp:TableCell HorizontalAlign="Right" Height="32px">
                                            <asp:Label id="lblFFin" runat="server" text="Fecha Fin:"></asp:Label>
                                        </asp:TableCell>
                                             <asp:TableCell HorizontalAlign="Left" Height="32px">
                                            <telerik:RadDatePicker ID="rdpFechaFin"  ZIndex="99999999" runat="server"  Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFechaFin_SelectedDateChanged" Width="120px"  TabIndex="0"></telerik:RadDatePicker>
                                        </asp:TableCell>
                                      </asp:TableRow>
                                      <asp:TableRow >
                                          <asp:TableCell HorizontalAlign="Right" Height="32px">
                                            <asp:Label id="lblFechaFinDesc" runat="server" text="Fecha Fin descuento:"></asp:Label>
                                        </asp:TableCell>
                                             <asp:TableCell HorizontalAlign="Left" Height="32px">
                                            <telerik:RadDatePicker ID="rdpFechaFinDesc"  ZIndex="99999999" runat="server"  Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFechaFinDesc_SelectedDateChanged" Width="120px"  TabIndex="0"></telerik:RadDatePicker>
                                        </asp:TableCell>
                                      </asp:TableRow>
                                     <asp:TableRow >
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button runat="server" ID="btnGuardarconfSuc"  Text="Asignar" Width="100px" OnClick="btnGuardarconfSuc_Click" CssClass="input" TabIndex="1" />
                                            <asp:Button ID="btnModificarPop" runat="server" Text ="Asignar" OnClick="btnModificarPop_Click" Width="100px" Visible="false" />
                                        </asp:TableCell>
                                         <asp:TableCell>
                                             <br />
                                            <asp:Button runat="server" ID="btnCancelarconfSuc"  Text="Cancelar" Width="100px" OnClick="btnCancelarconfSuc_Click" CssClass="input" TabIndex="1" />
                                        </asp:TableCell>
                                     </asp:TableRow>
                                     <asp:TableRow >
                                        <asp:TableCell ColumnSpan ="2">
                                             <br />
                                        </asp:TableCell>
                                     </asp:TableRow >
                                </asp:Table>
            </asp:Panel>

            <cc1:ModalPopupExtender ID="mpe" runat="server" TargetControlID="btnTargetExt" PopupControlID="pnlPromoAperturas" CancelControlID="btnCancelarpopupExtender" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

            <asp:Button ID="btnCancelarpopupExtender" runat="server" Text="" BackColor="Transparent" BorderStyle="None" Width="0px" Enabled="false"/>
            <asp:Button ID="btnTargetExt" runat="server" Text="" BackColor="Transparent" BorderStyle="None" Width="0px" Enabled="false" />
            <%-- ************************************************************************************************************************************************* --%>   
             <%-- Popup Eliminar --%>
            <asp:Panel ID="pnlDelete" runat="server"  HorizontalAlign="Center" >
                <asp:Table ID="tblEliminar" runat="server" CellSpacing="12" CellPadding="8" HorizontalAlign="Center" Width="360px" BackColor="LightGray">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="3">
                            <br />
                        </asp:TableCell>
                    </asp:TableRow>
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
											<asp:Label ID="lblmsg1" runat="server" Font-Size="14px" Font-Bold="true" Text ="Se vencera la vigencia de la sucursal" ></asp:Label><br />
											<asp:Label ID="lblmsg2" runat="server" Font-Size="14px" Font-Bold="true" Text ="¿deseá continuar?"></asp:Label><br />
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
                                        <asp:TableCell ColumnSpan="3">
                                            <br />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
            </asp:Panel>

            <cc1:ModalPopupExtender ID="mpeDelete" runat="server" TargetControlID="btnDeleteTargetExt" PopupControlID="pnlDelete" CancelControlID="btnCancelarDeleteExtender" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

            <asp:Button ID="btnDeleteTargetExt" runat="server" Text="" BackColor="Transparent" BorderStyle="None" Width="0px" Enabled="false"/>
            <asp:Button ID="btnCancelarDeleteExtender" runat="server" Text="" BackColor="Transparent" BorderStyle="None" Width="0px" Enabled="false" />
        <%-- ************************************************************************************************************************************************* --%>   

        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
