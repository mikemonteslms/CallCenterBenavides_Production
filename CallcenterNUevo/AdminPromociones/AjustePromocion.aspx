<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AjustePromocion.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.AjustePromocion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />
    <%--<script src="jsAdminProm/jsAdminPromocion.js"></script>--%>

    <br /> <br />
    <asp:Label runat="server" ID="lblTitulo" Text="Ajustar Promociones"  Font-Size="16px" ForeColor="DarkBlue"/>
    <asp:UpdatePanel runat="server" ID="upAjustaPromociones"  >
        <ContentTemplate>
            <br /> 
            <center>
                <asp:Table ID="tblBusquedaPromocion" runat="server" CellSpacing="1" CellPadding="0" HorizontalAlign="Center" Height="100%" Width="900px" > 
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label runat="server" text="Código interno:" Font-Size="14px"></asp:Label>
                        </asp:TableCell>
                         <asp:TableCell HorizontalAlign="center">
                            <asp:TextBox ID="txtCodInterno" runat="server" Height="25px" MaxLength="8" TabIndex="0"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="ftbeCodInterno" runat="server" FilterType="Numbers"
                            TargetControlID="txtCodInterno">
                            </cc1:FilteredTextBoxExtender>
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left">
                            <asp:Button runat="server" ID="btnBuscar"  Text="Buscar" Width="100px" OnClick="btnBuscar_Click" CssClass="input" TabIndex="1"/>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="3">
                            <br />
                             <telerik:RadGrid ID="grvDatos"  runat="server"  AutoGenerateColumns="False" AllowPaging="true" AllowSorting="true" OnItemCommand="grvDatos_ItemCommand" CellSpacing="2" GridLines="Both"    lowPaging="True" Culture="es-MX" OnPageIndexChanged="grvDatos_PageIndexChanged" Width="850px">
                            <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                            <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                               <RowIndicatorColumn Visible="False">
                                        </RowIndicatorColumn>
                                        <Columns>        
                                         <telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate> 
                                                            <asp:Button ID="btnVer" ToolTip="Ver" runat="server"  Text="Ver" Width="50px" CommandArgument='<%# Eval("id_mecanica")%>' CommandName="VerDetalle" TabIndex="2"/>
                                                            <asp:Button ID="btnEliminar" ToolTip="Eliminar promoción" runat="server" ItemStyle-Width="70px"  Text="Eliminar" Width="70px"  CommandArgument='<%# Eval("id_mecanica")%>' CommandName="Eliminar" Visible='<%# Eval("PuedeEliminar").Equals("1") ? (bool) true : (bool) false %>' TabIndex="3"/>
                                                </ItemTemplate>
                                         </telerik:GridTemplateColumn> 
                                            <telerik:GridBoundColumn DataField="id_mecanica" FilterControlAltText="Filter column1 column" HeaderText="Mecánica" UniqueName="column1">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="codigointerno" FilterControlAltText="Filter column2 column" HeaderText="Código" UniqueName="column2">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="Promocion" ItemStyle-Width="200px" FilterControlAltText="Filter column3 column" HeaderText="Descripción" UniqueName="column3">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="StatusInicio" ItemStyle-Width="40px" FilterControlAltText="Filter column4 column" HeaderText="Estatus" UniqueName="column4">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="tipoAcumulacion" ItemStyle-Width="110px" FilterControlAltText="Filter column5 column" HeaderText="Tipo acumulación" UniqueName="column5">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="tipoPromocion" FilterControlAltText="Filter column6 column" HeaderText="Tipo promoción" UniqueName="column6">
                                                </telerik:GridBoundColumn>  
                                             <telerik:GridBoundColumn DataField="id_statuspaseproduccion" ItemStyle-Width="220px"  FilterControlAltText="Filter column8 column" HeaderText="IDPaseProd." UniqueName="column8">
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
