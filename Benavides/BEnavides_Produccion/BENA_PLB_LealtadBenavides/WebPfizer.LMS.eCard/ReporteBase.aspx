<%@ Page Language="C#" MasterPageFile="~/MasterEcardMenu.Master" AutoEventWireup="true"
    CodeBehind="ReporteBase.aspx.cs" Inherits="WebPfizer.LMS.eCard.ReporteBase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
   <script>
       (function (i, s, o, g, r, a, m) {
           i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
               (i[r].q = i[r].q || []).push(arguments)
           }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
       })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

       ga('create', 'UA-73644905-1', 'auto');
       ga('send', 'pageview');

</script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="general" style="width: 641px;">
                <table style="width: 980px; height: 1000px">
                    <tr>
                        <td style="width: 16px">
                            <br />
                            <asp:Panel ID="pnlContenido" runat="server" Width="999px" ScrollBars="Auto" Font-Size="12px"
                                Height="980px" align="center">
                                <table width="97%">
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="width: 80%; text-align: left">
                                            <asp:Label ID="Label1" runat="server" Text="Descripción:" Font-Bold="True" Font-Names="Arial"
                                                ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Label ID="Label5" runat="server" Text="Este reporte muestra: Top 20 de diferentes segmentos."
                                                Font-Names="Arial" ForeColor="#004A99" Font-Size="10pt"></asp:Label>
                                            <br />
                                        </td>
                                        <td style="width: 20%" align="left">
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ID="btnBuscar" runat="server" Height="40px" ImageUrl="~/Imagenes_Benavides/botones/search.png"
                                                            ToolTip="Mostrar en Pantalla" Width="40px" ImageAlign="AbsBottom" ValidationGroup="Fechas"
                                                            OnClick="btnBuscar_Click" />
                                                        &nbsp&nbsp
                                                    </td>
                                                    <td style="border-left-color: Gray; border-left-width: 1px; border-left-style: solid">
                                                        &nbsp&nbsp
                                                        <asp:ImageButton ID="imgBtnExportar" runat="server" Height="40px" Width="40px" ToolTip="Exportar a Excel"
                                                            ImageUrl="~/Imagenes_Benavides/botones/Excel.png" 
                                                            onclick="imgBtnExportar_Click1"/>
                                                        &nbsp&nbsp
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:Label ID="lblMensajeTOP" runat="server" Text="En pantalla se visualizan solo 1000 líneas equivalentes a los últimos días, para visualizar todo el reporte debes descargarlo."
                                    Font-Names="Arial" ForeColor="#999999" Font-Size="10pt" Visible="false"></asp:Label>
                                <br />
                                <asp:GridView ID="grvDatos" runat="server" Font-Names="Arial" CellSpacing="3" Width="995px"
                                    Visible="false">
                                    <AlternatingRowStyle BackColor="#D2D6D9" />
                                    <HeaderStyle BackColor="#326FA6" ForeColor="White" />
                                </asp:GridView>
                                <asp:DataGrid ID="dgDatos" runat="server" CellPadding="4" HorizontalAlign="Left"
                                    Width="1px" ForeColor="#333333" CssClass="Grid" PageSize="8" CellSpacing="1"
                                    Height="0px" UseAccessibleHeader="True" Visible="False">
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <EditItemStyle BackColor="#999999" HorizontalAlign="Left" Wrap="False" />
                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left"
                                        Wrap="False" />
                                    <PagerStyle BackColor="#284775" CssClass="titulo" ForeColor="White" Height="15px"
                                        HorizontalAlign="Center" NextPageText="Siguiente &amp;gt;" PrevPageText="&amp;lt; Anterior"
                                        Mode="NumericPages" Visible="False" />
                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" HorizontalAlign="Left"
                                        Wrap="False" />
                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" Wrap="False" />
                                    <HeaderStyle BackColor="#326FA6" CssClass="titulo" Font-Bold="True" ForeColor="White"
                                        Height="20px" HorizontalAlign="Left" Wrap="False" />
                                </asp:DataGrid>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
