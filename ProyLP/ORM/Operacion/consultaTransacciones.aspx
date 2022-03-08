<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="consultaTransacciones.aspx.cs" Inherits="ORMOperacion.consultaTransacciones" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>
        <table border="0" width="900px">
            <tr>
                <td>
                    <div>
                        <h4>Consulta de Transacciones</h4>
                        <table width="860px">
                            <tr height="20" class="texto11" align="left">
                                <td width="80px">Participante
                                </td>
                                <td width="780px">
                                    <asp:Label ID="lblNombreParticipante" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr height="20" class="texto11" align="left">
                                <td>Clave
                                </td>
                                <td>
                                    <asp:Label ID="lblClaveParticipante" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr height="20" class="texto11" align="left">
                                <td>Saldo
                                </td>
                                <td>
                                    <asp:Label ID="lblSaldo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="display:none;">
                                <td colspan="2">
                                    <br />
                                    <div>
                                        <table width="860px">
                                            <tr>
                                                <td align="center">
                                                    <asp:MultiView ID="mvObjetivos" runat="server" ActiveViewIndex="0">
                                                        <asp:View ID="vObjetivos" runat="server">
                                                            <table border="0">
                                                                <tr>
                                                                    <td>
                                                                        <h2>
                                                                            <asp:Label ID="lblTitulo" runat="server" Text=" Objetivos " Visible="false" CssClass="texto11"></asp:Label>
                                                                            <br />
                                                                            <br />
                                                                        </h2>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="gvObjetivos" runat="server" AutoGenerateColumns="false" AllowPaging="True"
                                                                            PageSize="10" GridLines="None" CssClass="ParrafoTexto" CellPadding="3" CellSpacing="3"
                                                                            Width="80px" OnRowDataBound="gvObjetivos_RowDataBound">
                                                                            <HeaderStyle CssClass="HeaderStyle texto11" />
                                                                            <AlternatingRowStyle BackColor="#e2f1fc" />
                                                                            <FooterStyle CssClass="FooterStyle texto11" />
                                                                            <RowStyle CssClass="RowStyle texto11" />
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                    </asp:MultiView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="PaginaTitulo" colspan="2">
                                    <br /><br />
                                                <table width="100%" border="0" class="PaginaTitulo">
                                                    <tr>
                                                        <td>
                                                            <h4>RESUMEN DE TRANSACCIONES
                                                            </h4>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <div align="right" class="ParrafoTexto">
                                                                <p>
                                                                    <asp:Label ID="lblRegistros" runat="server" CssClass="texto11 color_negro"></asp:Label>
                                                                </p>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <telerik:RadGrid ID="gvTransacciones" runat="server" AutoGenerateColumns="False" 
                                                                OnNeedDataSource="gvTransacciones_NeedDataSource"
                                                                OnRowDataBound="gvTransacciones_RowDataBound"
                                                                
                                                                OnPageIndexChanging="gvTransacciones_PageIndexChanging" 
                                                                AllowPaging="True" PageSize="10" DataKeyNames="id" 
                                                                GridLines="None" CssClass="ParrafoTexto" CellPadding="3" CellSpacing="3">
                                                                <MasterTableView>
                                                                <Columns>
                                                                    <telerik:GridBoundColumn DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}">
                                                                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="concepto" HeaderText="Tipo de transacci&oacute;n">
                                                                        <ItemStyle Width="250px" HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridBoundColumn DataField="puntos" DataFormatString="{0:#,#}" HeaderText="Kilómetros">
                                                                        <ItemStyle Width="150px" HorizontalAlign="Center" />
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridTemplateColumn ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbVerDetalle" runat="server" CommandName="Update"
                                                                                Text="Ver detalle" CommandArgument='<%# Bind("transaccion_id") %>' OnClick="lnkbVerDetalle_Click">
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                </Columns>
                                                                    </MasterTableView>
                                                                </telerik:RadGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </center>
    <asp:LinkButton ID="lnkPopup" runat="server"></asp:LinkButton>
    <cc1:ModalPopupExtender ID="popDetalleTransaccion" runat="server" BackgroundCssClass="Sombra"
        PopupControlID="pnlDetalleTransaccion" TargetControlID="lnkPopup" CancelControlID="imgCancelar">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlDetalleTransaccion" runat="server" Width="438px" Style="display: none">
        <table border="0" width="440px">
            <tr>
                <td>
                    <table border="0" width="420px" bgcolor="#ffffff">
                        <tr height="5px">
                            <td align="right">
                                <asp:ImageButton ID="imgCancelar" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0">
                                    <tr>
                                        <td align="center">
                                            <h4>Detalle de transacci&oacute;n
                                            </h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <telerik:RadGrid runat="server" ID="gvDetalleTransaccion" AutoGenerateColumns="False" AllowPaging="True"
                                                PageSize="10" GridLines="None" CssClass="ParrafoTexto">
                                                <MasterTableView>
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="clave" HeaderText="Clave">
                                                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="descripcion" HeaderText="Descripci&oacute;n">
                                                            <ItemStyle Width="300px" HorizontalAlign="left" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="cantidad" HeaderText="Cantidad">
                                                            <ItemStyle Width="50px" HorizontalAlign="center" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="importe" HeaderText="Importe">
                                                            <ItemStyle Width="50px" HorizontalAlign="right" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridTemplateColumn DataField="puntos" HeaderText="Kilómetros">
                                                            <ItemStyle Width="50px" HorizontalAlign="right" />
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" Text='<%# Eval("puntos","{0:#,#}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
