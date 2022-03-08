<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/contenido.Master" CodeBehind="consultaHistoricoVentas.aspx.cs" Inherits="ORMOperacion.consultaHistoricoVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>
        <div id="rounded-box4">
            <table border="0" width="900px">
                <tr>
                    <td>
                        <div>
                            <h4>Historico de Ventas</h4>
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
                                <%-- <tr>
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
                            </tr>--%>
                                <tr>
                                    <td class="PaginaTitulo" colspan="2">
                                        <cc1:TabContainer ID="tabResumenTransacciones" runat="server" ActiveTabIndex="0" ScrollBars="Horizontal"
                                            Width="950px">
                                            <cc1:TabPanel ID="tpResumenTransacciones" runat="server" CssClass="texto11">
                                                <HeaderTemplate>
                                                    Historico de Ventas
                                                </HeaderTemplate>
                                                <ContentTemplate>
                                                    <table width="100%" border="0" class="PaginaTitulo">
                                                        <tr>
                                                            <td>
                                                                <h4>Historico de Ventas
                                                                </h4>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Button ID="ibtnExportar" runat="server" Text="Exportar" OnClick="btnExcelr_Click" CssClass="boton negrita sin_borde" />
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
                                                            <td>
                                                                <div style="overflow: auto; width: 1100px; height: 100%;">
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="center">
                                                                <asp:Panel ID="pnlHistoricoVentas" runat="server" Width="100%">
                                                                    <asp:GridView ID="gvTransacciones" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvTransacciones_RowDataBound"
                                                                        OnPageIndexChanging="gvTransacciones_PageIndexChanging" AllowPaging="True" DataKeyNames="NoCliente" OnRowUpdating="gvTransacciones_RowUpdating"
                                                                        GridLines="None" CssClass="ParrafoTexto" CellPadding="3" CellSpacing="3">
                                                                        <HeaderStyle CssClass="HeaderStyle" />
                                                                        <AlternatingRowStyle BackColor="#E2F1FC" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="mecanica" HeaderText="Marca">
                                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="NoCliente" HeaderText="No Cliente">
                                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Razónsocial" HeaderText="Razón Social">
                                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="NoBranch" HeaderText="No Branch ">
                                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Sku" HeaderText="Sku ">
                                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Descripción" HeaderText="Descripción">
                                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Puntos_acumulados_producto" DataFormatString="{0:#,#}" HeaderText="Kilómetros">
                                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="FechaFactura" HeaderText="Fecha Factura" DataFormatString="{0:dd/MM/yyyy}">
                                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="NoFactura" HeaderText="No Factura">
                                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                            </asp:BoundField>

                                                                        </Columns>
                                                                        <FooterStyle CssClass="FooterStyle texto11" />
                                                                        <RowStyle CssClass="RowStyle texto11" />
                                                                    </asp:GridView>
                                                                </asp:Panel>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Panel ID="pnlExcel" runat="server" Visible="False">
                                                                    <asp:GridView ID="gvExcel" runat="server">
                                                                    </asp:GridView>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </cc1:TabPanel>
                                        </cc1:TabContainer>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </center>
    <%--<asp:LinkButton ID="lnkPopup" runat="server"></asp:LinkButton>
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
                                            <asp:GridView runat="server" ID="gvDetalleTransaccion" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" GridLines="None" CssClass="ParrafoTexto" OnPageIndexChanging="gvDetalleTransaccion_PageIndexChanging">
                                                <HeaderStyle CssClass="HeaderStyle" />
                                                <AlternatingRowStyle BackColor="#e2f1fc" />
                                                <Columns>
                                                    <asp:BoundField DataField="clave" HeaderText="Clave">
                                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="descripcion" HeaderText="Descripci&oacute;n">
                                                        <ItemStyle Width="300px" HorizontalAlign="left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad">
                                                        <ItemStyle Width="50px" HorizontalAlign="center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="importe" HeaderText="Importe">
                                                        <ItemStyle Width="50px" HorizontalAlign="right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="puntos" HeaderText="Puntos" DataFormatString="{0:#,#}">
                                                        <ItemStyle Width="50px" HorizontalAlign="right" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <FooterStyle CssClass="FooterStyle texto11" />
                                                <RowStyle CssClass="RowStyle texto11" />
                                                <PagerStyle CssClass="texto11" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>--%>
</asp:Content>

