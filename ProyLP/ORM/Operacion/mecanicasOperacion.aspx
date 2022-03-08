<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="mecanicasOperacion.aspx.cs" Inherits="ORMOperacion.mecanicasOperacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">    
    <div style="width:100%">
        <center>
            <table>
            <tr style="background-color:#6788BE">
                <td colspan="3" style="text-align:center">
                    <label style="color:white;font-weight:bold">MECÁNICAS</label>
                </td>
            </tr>
            <tr>
                <td style="height: 380px" colspan="3">
                    <div style="width:570px;height:500px; overflow:scroll">
                        <asp:Repeater ID="rptPremios" runat="server" OnItemDataBound="rptPremios_DataBound">
                        <HeaderTemplate>
                            <table cellspacing="2" width="545px">
                                <tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <td class="imagen_catalogo_cuadro">
                                <table class="frame_mecanicas">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgPremio" runat="server" ImageUrl='<%# Eval("url_imagen_small")%>' Height="70px" Width="110px"
                                                CommandName="detalle" CommandArgument='<%# Eval("id") %>' OnCommand="imgPremios_Command" />
                                            <asp:HiddenField ID="hddUrlImagenGrande" Value='<%# Eval("url_imagen_large")%>' runat="server"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tr></table>
                        </FooterTemplate>
                    </asp:Repeater>
                    </div>
                </td>
            </tr>
        </table>
        </center>
    </div>


    <asp:HyperLink ID="hlkmsj2" runat="server"></asp:HyperLink>
    <cc1:ModalPopupExtender ID="popMecanicas" runat="server" TargetControlID="hlkmsj2"
        PopupControlID="pnlMecanicas" BackgroundCssClass="Sombra">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlMecanicas" runat="server" Width="660px" Height="360px" Style="display: none">
        <table style="background-color:white">
            <tr>
                <td style="width:550px;text-align:center">
                    <asp:Image ID="imgMecanica" runat="server" Width="220px" Height="70px"/>
                </td>
                <td style="width:110px;vertical-align:top;text-align:right; padding-top:5px;padding-right:5px">
                    <asp:Button ID="btnCerrar2" runat="server"  CssClass="boton negrita sin_borde" Text="Cerrar" OnClick="btnCerrar2_Click" />
                </td>
            </tr>
            <tr style="background-color: #FFF; height: 120px">
                <td colspan="2" style="padding-left:10px;padding-right:10px">
                    <div style="height:150px;overflow:scroll;width:635px">
                        <asp:GridView ID="gvDetalleMecanica" runat="server" AutoGenerateColumns="false" Width="600px" BorderStyle="None">
                        <HeaderStyle CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AlternatingRow" />
                        <Columns>
                            <asp:BoundField DataField="clave" HeaderText="SKU" ItemStyle-CssClass="texto_SKU" />
                            <asp:BoundField DataField="descripcion" HeaderText="Descripción del Artículo" ItemStyle-CssClass="texto_descripcion"/>
                            <asp:BoundField DataField="puntos" HeaderText="Kilómetros"  ItemStyle-CssClass="texto_puntos"/>
                            <asp:BoundField DataField="periodo" HeaderText="Vigencia"  ItemStyle-CssClass="texto_periodo"/>
                        </Columns>
                    </asp:GridView>
                        </div>
                    <table style="width:635px">
                        <tr>
                            <td>
                                <asp:Label ID="lblLegales" runat="server"  CssClass="texto_descripcion" Width="600px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:15px">

                                <ul class="texto_descripcion" style="width:600px;font-size:11px">
                                         </ul>
                            </td>
                        </tr>
                    </table>
                    
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
