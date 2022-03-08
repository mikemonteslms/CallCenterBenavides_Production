<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaPromACDineroEntregaPzas.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.ConsultaPromACDineroEntregaPzas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />
    <script src="jsAdminProm/jsAdminPromocion.js"></script>
    
    <br /> <br />
    <asp:Label runat="server" ID="lblTitulo" Text="Consulta promociones de dinero que entregan piezas"  Font-Size="16px" ForeColor="DarkBlue"/>
    <asp:UpdatePanel runat="server" ID="upAjustaPromociones"  >
        <ContentTemplate>
            <br /> 
                <asp:Table ID="tblBusquedaPromocionxAutDesAut" runat="server" HorizontalAlign="Center" Height="100%" Width="800px" > 
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server" text="Código interno:" Font-Size="14px"></asp:Label>
                        </asp:TableCell>
                         <asp:TableCell HorizontalAlign="center">
                            <asp:TextBox ID="txtCodInterno" runat="server" Height="25px" MaxLength="8" TabIndex="0"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="ftbeCodInterno" runat="server" FilterType="Numbers"
                            TargetControlID="txtCodInterno">
                            </cc1:FilteredTextBoxExtender>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Button runat="server" ID="btnBuscar"  Text="Buscar" Width="100px" OnClick="btnBuscar_Click" CssClass="input" TabIndex="1"/>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="3">
                            <br />
                             <telerik:RadGrid ID="grvDatos"  runat="server"  AutoGenerateColumns="False" AllowPaging="true" AllowSorting="true"  OnItemCommand="grvDatos_ItemCommand" CellSpacing="2" GridLines="Both"   Culture="es-MX" OnPageIndexChanged="grvDatos_PageIndexChanged" OnSortCommand="grvDatos_SortCommand" Width="750px"  >
                            <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                            <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                               <RowIndicatorColumn Visible="False">
                                        </RowIndicatorColumn>
                                <ExpandCollapseColumn Created="True">
                                    <HeaderStyle Width="1000px" />
                                </ExpandCollapseColumn>
                                        <Columns>        
                                            <telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate> 
                                                    <asp:Button ID="btnVer" ToolTip="Ver" runat="server"  Text="Ver" Width="50px" Font-Size="14px" CommandArgument='<%# Eval("id_mecanica")%>' CommandName="VerDetalle" TabIndex="2"/>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn> 
                                            <telerik:GridTemplateColumn   HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate> 
                                                        <asp:Button ID="btnEliminar" ToolTip="Eliminar promoción" runat="server"  Text="Eliminar" Width="80px" Font-Size="14px" CommandArgument='<%# Eval("id_mecanica")%>' CommandName="Eliminar" TabIndex="3"/>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn> 
                                            <telerik:GridBoundColumn DataField="id_mecanica" FilterControlAltText="Filter column1 column" HeaderText="Mecánica" UniqueName="column1">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="codigointerno" FilterControlAltText="Filter column2 column" HeaderText="Código" UniqueName="column2">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="Promocion" ItemStyle-Width="550px" FilterControlAltText="Filter column3 column" HeaderText="Nombre promoción" UniqueName="column3">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="StatusInicio" FilterControlAltText="Filter column4 column" HeaderText="Estatus" UniqueName="column4">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="tipoAcumulacion" FilterControlAltText="Filter column5 column" HeaderText="Tipo acumulación" UniqueName="column5">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="tipoPromocion" FilterControlAltText="Filter column6 column" HeaderText="Tipo promoción" UniqueName="column6">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="id_statusPaseProduccion" FilterControlAltText="Filter column7 column" HeaderText="IDPase Prod." UniqueName="column7">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="statusPaseProduccion" ItemStyle-Width="220px"  FilterControlAltText="Filter column8 column" HeaderText="Estatus pase" UniqueName="column8">
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


             <div id="popReg" style="display: none; background-color: rgba(0, 0, 0, 0.5); z-index: 20000; left: 0%; position: absolute; top: 0px; width:100%; height: 100%; text-align: center;">
					<div  style="background-color: #333333; max-width: 400px; padding: 15px; width: 100%; display: inline-block; vertical-align: middle; height: 160px; margin-top:18%; max-height: 445px;">
					    <div class="modal-content"  style="background-color:#E2E1E1; height:135px; background-image:url(background-repeat: repeat-x"../Images/background2.jpg");>
						    <div >
                                  <asp:Table ID="tblEliminar" runat="server" CellSpacing="12" CellPadding="8" HorizontalAlign="Center" Width="350px">
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
                                </asp:Table>
                                <asp:Table ID="tblReasignaFechaInicio" runat="server"  CellSpacing="12" CellPadding="8" HorizontalAlign="Center" Width="350px" Visible="false">
                                    <asp:TableRow>
									    <asp:TableCell  HorizontalAlign="Center"  VerticalAlign="Middle" Width="45px">
                                            <img src="../../Imagenes_Benavides/botones/info.png" width="45" height="45"/>
									    </asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Center" Width="200px">
                                               <asp:Label ID="Label1" runat="server" Font-Size="13px" Font-Bold="true" Text ="La fecha inicio ya no es valida" ></asp:Label><br />
											    <asp:Label ID="Label2" runat="server" Font-Size="13px" Font-Bold="true" Text ="deberá cambiarla a una posterior."></asp:Label><br />
                                                <telerik:RadDatePicker ID="rdpFechainicio" ZIndex="99999" Font-Size="14px" runat="server"  Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFechainicio_SelectedDateChanged" Width="150px" Height="27px"  TabIndex="0"></telerik:RadDatePicker>
                                      </asp:TableCell>
								    </asp:TableRow>
								
								    <asp:TableRow>
                                        <asp:TableCell ColumnSpan="2">
                                            <br />
                                            <asp:Table ID="tblbotonesFIni" runat="server" Width="350px">
                                                <asp:TableRow>
                                                    <asp:TableCell HorizontalAlign="Center">
                                                    <asp:Button runat="server" ID="btnGuardarFechaini"  Text="Modificar" Width="100px" OnClick="btnGuardarFechaini_Click" CssClass="input" TabIndex="1" />
                                                    </asp:TableCell>
                                                    <asp:TableCell HorizontalAlign="Center">
                                                    <asp:Button runat="server" ID="btnCancelarFechaini"  Text="Cancelar" Width="100px"  CssClass="input" TabIndex="1" />
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
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


