<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AcumulaTicketsXContingencia.aspx.cs" Inherits="CallcenterNUevo.POS.AcumulaTicketsXContingencia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="../AdminPromociones/cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />
    <script src="../AdminPromociones/jsAdminProm/jsAdminPromocion.js"></script>

    

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


     <asp:Label runat="server" ID="lblTitulo" Text="Acumulación por Contingencia."  Font-Size="16px" ForeColor="DarkBlue"/>
        <br /> <br /><br />

        <asp:UpdatePanel ID="upAcumulaTicketsXContingencia" runat="server">
        <ContentTemplate>
            <center>
             <asp:Table runat="server" ID="Table1" Width="500px">
             <%--<asp:TableRow>
                 <asp:TableCell Height="38px">
                     <asp:Label ID="Label6" runat="server" Text="Cotización:"></asp:Label>
                 </asp:TableCell>
                 <asp:TableCell>
                    <asp:TextBox ID="txtCotizacion" runat="server" Text='<%# Eval("Cotizacion")%>'  onKeypress="return ValidarTecla(event);" Width="230px"  Tabindex ="1"></asp:TextBox>
                 </asp:TableCell>
             </asp:TableRow>--%>
             <asp:TableRow>
                 <asp:TableCell Height="38px">
                     <asp:Label ID="Label1" runat="server" Text="No de Ticket:"></asp:Label>
                 </asp:TableCell>
                 <asp:TableCell>
                     <asp:TextBox ID="txtNoTicket" runat="server" width="50px" Text='<%# Eval("Noticket")%>' Tabindex ="1" MaxLength="6"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="fteTicket" runat="server" FilterType="Numbers"
                                                                TargetControlID="txtNoTicket">
                    </cc1:FilteredTextBoxExtender>
                 </asp:TableCell>
             </asp:TableRow>
             <asp:TableRow>
                 <asp:TableCell Height="38px">
                     <asp:Label ID="Label2" runat="server" Text="Importe:"></asp:Label>
                 </asp:TableCell>
                 <asp:TableCell>
                     <asp:TextBox ID="txtImporte" runat="server" width="50px" Text='<%# Eval("Importe")%>' onKeypress="return ValidarTecla(event);" Tabindex ="2" MaxLength="6"></asp:TextBox>
                 </asp:TableCell>
             </asp:TableRow>
             <asp:TableRow>
                 <asp:TableCell Height="38px">
                     <asp:Label ID="Label3" runat="server" Text="Sucursal:"></asp:Label>
                 </asp:TableCell>
                 <asp:TableCell>
                     <asp:TextBox ID="txtSucursal" runat="server" AutoPostBack="true" Text='<%# Eval("Sucursal")%>' MaxLength="6" OnTextChanged="txtSucursal_TextChanged" width="100px" Tabindex ="3" ></asp:TextBox>
		     <cc1:FilteredTextBoxExtender ID="ftbextSucursal" runat="server" FilterType="Numbers"
                                                 TargetControlID="txtSucursal">
                    </cc1:FilteredTextBoxExtender>
                 </asp:TableCell>
             </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell Height="38px">
                    <asp:Label ID="Label4" runat="server" Text="Tarjeta:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtTarjeta" runat="server" AutoPostBack="true" Text='<%# Eval("Tarjeta")%>'  OnTextChanged="txtTarjeta_TextChanged" maxlength="11" Tabindex ="4"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="fteTarjeta" runat="server" FilterType="Numbers"
                                                            TargetControlID="txtTarjeta">
                    </cc1:FilteredTextBoxExtender>
                </asp:TableCell>
             </asp:TableRow>
                 <asp:TableRow>
                <asp:TableCell Height="38px">
                    <asp:Label ID="Label5" runat="server" Text="Caja:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtCaja" runat="server" width="50px" Text='<%# Eval("Caja")%>' Tabindex ="5" MaxLength="2"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="ftbeCaja" runat="server" FilterType="Numbers"
                                                            TargetControlID="txtCaja">
                    </cc1:FilteredTextBoxExtender>
                </asp:TableCell>
             </asp:TableRow>
             </asp:Table>
            <br />
            <asp:Table runat="server" ID="tblAcumTicketsXContingencia" Width="970px">
                <asp:TableRow>
                    <asp:TableCell >
                        <asp:GridView  ID="grvAcumTicketXCont"  runat="server"  CssClass="gridview"   OnRowDeleting="grvAcumTicketXCont_RowDeleting"  OnRowCommand="grvAcumTicketXCont_RowCommand"   CellSpacing ="1" AutoGenerateColumns ="false"   CellPadding="3" GridLines="Horizontal"    Width ="750px"  Height="100%" >
                            <HeaderStyle ForeColor="Black"   />
                            <Columns>
                                       <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" HeaderStyle-Width="190px">
                                       <HeaderTemplate>
                                            Código de Barras
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                                <asp:TextBox ID="txtCodigoBarras" runat="server" Text='<%# Eval("CodigoBarras")%>' maxlength="16" Width="180px"  enabled="false" Tabindex ="99" ></asp:TextBox>   
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" HeaderStyle-Width="250px">
                                            <HeaderTemplate>
                                                Código interno
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                 <asp:TextBox ID="txtCodInterno" runat="server"   Text='<%# Eval("CodInterno")%>' OnTextChanged="txtCodInterno__TextChanged"  ToolTip="Código interno / Nombre de producto" Width="200px" Tabindex ="6"></asp:TextBox>
                                                 <asp:Button ID="btnPopup" runat="server"  CommandArgument='<%# Eval("Index")%>' Text="..." ToolTip="Buscar" OnClick="btnPopup_Click" Width="40px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px">
                                            <HeaderTemplate>
                                                Cantidad
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                  <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Eval("Cantidad")%>'   MaxLength="1" Tabindex ="7" Width="100px"></asp:TextBox>
                                                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                                                                TargetControlID="txtCantidad">
                                                  </cc1:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px">
                                            <HeaderTemplate>
                                                Monto Base para acumular
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                               <asp:TextBox ID="txtMontoBaseAcumular" runat="server" Text='<%# Eval("MontoBaseAcumular")%>' onKeypress="return ValidarTecla(event);" MaxLength="8" Tabindex ="10" Width="100px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px">
                                            <HeaderTemplate>
                                                Precio descuento
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                               <asp:TextBox ID="txtPrecioDescuento" runat="server" Text='<%# Eval("PrecioDescuento")%>' onKeypress="return ValidarTecla(event);" MaxLength="8" Tabindex ="11" Width="100px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" HeaderStyle-Width="100px">
                                            <HeaderTemplate>
                                                Precio final
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                               <asp:TextBox ID="txtPrecioFinal" runat="server" Text='<%# Eval("PrecioFinal")%>' onKeypress="return ValidarTecla(event);"    MaxLength="8" Tabindex ="8" Width="100px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:commandfield ShowDeleteButton="true" DeleteText="Eliminar"  DeleteImageUrl="../Imagenes_Benavides/delete-icon.png" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center"  headertext="Opciones" Visible="true"/>
                                    </Columns>
                        </asp:GridView>
                    </asp:TableCell>
                    <asp:TableCell VerticalAlign="Bottom">
                        <asp:Button ID="btnAgregar" runat="server" Text="Nuevo elemento" OnClick="btnAgregar_Click" Width="150px" Visible="true" TabIndex="9" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                         <br /><br />
                        <asp:Table ID="tblBotones" runat="server" width="220px">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" Tabindex ="10"/>
                                </asp:TableCell>
                                 <asp:TableCell>
                                     <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" Tabindex ="11" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </center>


        <div id="popReg" style="display: none; background-color: rgba(0, 0, 0, 0.5); z-index: 20000; left: 0%; position: absolute; top: 0px; width:100%; height: 100%; text-align: center;">
					<div  style="background-color: #333333; max-width: 510px; padding: 15px; width: 100%; display: inline-block; vertical-align: middle; height: 250px; margin-top:18%; max-height: 250px;">
					    <div class="modal-content"  style="background-color:#E2E1E1; height:225px; background-image:url(; background-repeat: repeat-x"../Images/background2.jpg");>
						    <div class="modal-header">
                                <button id="btnClosePopup" type="submit" alt="Cerrar" style="color:red" class="close" onclick="" data-dismiss="modal" runat="server">&times;</button>
                                <asp:Table ID="tblpop" runat="server">
                                    <asp:TableRow >
                                        <asp:TableCell HorizontalAlign="Center">
                                            <telerik:RadGrid ID="grvProd"  runat="server"  PageSize="3" AutoGenerateColumns="False" AllowPaging="true" AllowSorting="true" OnItemCommand="grvProd_ItemCommand" CellSpacing="2" GridLines="Both"    Culture="es-MX" OnPageIndexChanged="grvProd_PageIndexChanged" Width="450px">
                                                    <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                                    <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                                                    <RowIndicatorColumn Visible="False">
                                                    </RowIndicatorColumn>
                                                    <Columns>        
                                                    <telerik:GridTemplateColumn  HeaderText="" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate> 
                                                        <asp:Button ID="btnSeleccionar" ToolTip="Seleccionar Código interno" runat="server"  Text="Seleccionar" Width="80px" CommandArgument='<%# Eval("IdProd")%>' Font-Size="13px" CommandName="SelCodint" TabIndex="1"/>
                                                    </ItemTemplate>
                                                    </telerik:GridTemplateColumn >
                                                    <telerik:GridBoundColumn DataField="CodigoBarras"  FilterControlAltText="Filter column2 column" HeaderStyle-ForeColor="DarkBlue" HeaderText="Código Barras"  UniqueName="column2">
                                                    </telerik:GridBoundColumn>  
                                                    <telerik:GridBoundColumn DataField="CodigoInterno" ItemStyle-Width="200px" FilterControlAltText="Filter column3 column" HeaderStyle-ForeColor="DarkBlue" HeaderText="Código Interno" UniqueName="column3">
                                                    </telerik:GridBoundColumn>  
                                                    <telerik:GridBoundColumn DataField="NombreProducto" ItemStyle-Width="200px" FilterControlAltText="Filter column3 column" HeaderStyle-ForeColor="DarkBlue" HeaderText="Desc. Producto" UniqueName="column3">
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
                            </div>
	                    </div>
	                </div>
                </div>


        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
