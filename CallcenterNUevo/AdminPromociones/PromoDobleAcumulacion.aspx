<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PromoDobleAcumulacion.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.PromoDobleAcumulacion" %>
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

        <asp:Label runat="server" ID="lblTitulo" Text="Promociones de apertura..."  Font-Size="16px" ForeColor="DarkBlue"/>

        <asp:UpdatePanel id="upPromDobleAcumulacion"  runat="server">
            <ContentTemplate>
               <center>
                <asp:Table ID="tblLstAcumulacionesVigentes" runat="server" Width="900px">
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
                            <asp:Button ID="btnAgregar" runat="server" Text ="Agregar nueva promoción" OnClick="btnAgregar_Click" Width="200px"/>
                            <br /><br />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                           <telerik:RadGrid ID="grvPromDobleAcumulacion"  runat="server"  AutoGenerateColumns="False" AllowPaging="true" AllowSorting="true"  OnItemCommand="grvPromDobleAcumulacion_ItemCommand" CellSpacing="2" GridLines="Both"   Culture="es-MX" OnPageIndexChanged="grvPromDobleAcumulacion_PageIndexChanged" OnSortCommand="grvPromDobleAcumulacion_SortCommand" Width="850px"  >
                            <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                            <MasterTableView NoMasterRecordsText="No se encontro información" AllowMultiColumnSorting="true">
                               <RowIndicatorColumn Visible="False">
                                        </RowIndicatorColumn>
                                <ExpandCollapseColumn Created="True">
                                    <HeaderStyle Width="1000px" />
                                </ExpandCollapseColumn>
                                        <Columns>        
                                            <telerik:GridBoundColumn DataField="nombre" FilterControlAltText="Filter column1 column" HeaderText="Descripción" UniqueName="column1" ItemStyle-Width="150px">
                                                </telerik:GridBoundColumn>  
                                            <%--<telerik:GridBoundColumn DataField="Sucursal" FilterControlAltText="Filter column2 column" HeaderText="Sucursal" UniqueName="column2">
                                                </telerik:GridBoundColumn>  --%>
                                            <telerik:GridBoundColumn DataField="FechaIni"  FilterControlAltText="Filter column3 column" HeaderText="Fecha Inicio" UniqueName="column3">
                                                </telerik:GridBoundColumn>  
                                            <telerik:GridBoundColumn DataField="FechaFin" FilterControlAltText="Filter column4 column" HeaderText="Fecha Fin" UniqueName="column4">
                                                </telerik:GridBoundColumn>  
                                             <telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate> 
                                                    <asp:Button ID="btnEditar" ToolTip="Editar" runat="server" Text="Editar" Width="60px" Font-Size="14px" CommandArgument='<%# Eval("Id")%>' CommandName="EditarPromDobleAcumula" TabIndex="2"/>
                                              
                                                    <asp:Button ID="btnEliminar" ToolTip="Eliminar" runat="server" Text="Eliminar" Width="65px" Font-Size="14px" CommandArgument='<%# Eval("Id")%>' CommandName="EliminarPromDobleAcumula" TabIndex="2"/>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn> 
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


              <%-- ************************************************************************************************************************************************* --%>   
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
             <%-- ************************************************************************************************************************************************* --%>   
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
