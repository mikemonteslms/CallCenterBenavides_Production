<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="consultaCanjesParticipantes.aspx.cs" Inherits="ORMOperacion.consultaCanjesParticipantes" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
    <style type="text/css">
        .operacion {
            color: #800000;
        }
    </style>
    <script type="text/javascript" src="style/js/jquery-1.2.2.pack.js"></script>
    <script type="text/javascript" src="style/js/htmltooltip.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>
            <table border="0" Width="900px">        
                <tr>       
                    <td>
                        <div>
                            <h4>Consulta de Canjes</h4>
                            <table width="860px">
                                <tr height="20" class="texto11" align="left">
                                    <td width="80px">Participante
                                    </td>
                                    <td width="780px">
                                        <asp:Label ID="lblNombreParticipante" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="texto11" align="left">
                                    <td>Clave
                                    </td>
                                    <td>
                                        <asp:Label ID="lblClaveParticipante" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="texto11">
                                    <td class="PaginaTitulo" colspan="2">                                        
                                        <br /><br>
                                            <table width="100%" border="0" class="PaginaTitulo">
                                                <tr>
                                                    <td>
                                                        <h4>DETALLE DE CANJES
                                                        </h4>                                                       
                                                    </td>
                                                </tr>                                                
                                                <tr>
                                                    <td>
                                                        <div align="right" class="ParrafoTexto">
                                                            <p>
                                                                <asp:Label ID="lblRegistros" runat="server" CssClass="texto11 color_negro"></asp:Label>
                                                            </p>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="texto11">
                                                        <telerik:RadGrid ID="gvDetalleCanje" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                                            PageSize="15" GridLines="None" CssClass="ParrafoTexto" OnRowDataBound="gvDetalleCanje_RowDataBound"
                                                            OnPageIndexChanging="gvDetalleCanje_PageIndexChanging">
                                                            <MasterTableView>
                                                            <Columns>
                                                                <telerik:GridBoundColumn DataField="Folio" HeaderText="Folio">
                                                                    <ItemStyle Width="150px" HorizontalAlign="Left" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridTemplateColumn HeaderText="Premio" ItemStyle-Width="300px" ItemStyle-CssClass="texto">
                                                                    <ItemTemplate>
                                                                        <%# Eval("Premio") %><br />
                                                                        <%# Eval("TransaccionObservaciones") %>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridBoundColumn DataField="Puntos" HeaderText="Kilómetros" DataFormatString="{0:#,#}">
                                                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="FechaSolicitud" HeaderText="Fecha solicitud">
                                                                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="DireccionEntrega" HeaderText="Direcci&oacute;n entrega">
                                                                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridBoundColumn DataField="Status" HeaderText="Status">
                                                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridTemplateColumn ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkCancelar" runat="server" CausesValidation="false" Text="Cancelar"
                                                                            CommandName="cancelar" CommandArgument='<%# Eval("ID") %>' OnCommand="gvDetalleCanje_Command"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkGarantia" runat="server" CausesValidation="false" Text="Garantia"
                                                                            CommandName="garantia" CommandArgument='<%# Eval("ID") %>' OnCommand="gvDetalleCanje_Command"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn ItemStyle-Width="100">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkRMS" runat="server" CausesValidation="false" Text="RMS" CommandName="rms"
                                                                            CommandArgument='<%# Eval("ID") %>' OnCommand="gvDetalleCanje_Command"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkNotas" runat="server" CausesValidation="false" Text="Actualizar nota"
                                                                            CommandName="notas" CommandArgument='<%# Eval("ID") %>' OnCommand="gvDetalleCanje_Command"></asp:LinkButton>
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
    <asp:LinkButton ID="lnkPopup" runat="server"></asp:LinkButton>
    <cc1:ModalPopupExtender ID="popOperacion" runat="server" BackgroundCssClass="Sombra"
        PopupControlID="pnlOperacion" TargetControlID="lnkPopup" CancelControlID="imgCancelar">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlOperacion" runat="server" Width="442px" Style="display: none" BorderWidth="2px"
        BorderColor="#797979" CssClass="modalPopup" BorderStyle="Solid" BackColor="#FFFFFF">
        <asp:HiddenField ID="hidTransaccionPremio" runat="server" />
        <table width="100%">
            <tr height="5">
                <td align="right">
                    <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/img/cancel.png" />
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td colspan="2">
                                <h3>
                                    <asp:Label ID="lblTituloOperacion" runat="server"></asp:Label>
                                </h3>
                            </td>
                        </tr>
                        <tr>
                            <td>Premio
                            </td>
                            <td>
                                <asp:Label ID="lblPremio" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Kilómetros
                            </td>
                            <td>
                                <asp:Label ID="lblPuntos" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td>Comentarios
                            </td>
                            <td>
                                <span class="campoComentarios">
                                    <asp:TextBox ID="txtComentarios" runat="server" TextMode="MultiLine" Width="340px" Height="50px" CssClass="transparente"></asp:TextBox>
                                </span>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Es necesario escribir un comentario para terminar la operación"
                                    ControlToValidate="txtComentarios" ValidationGroup="operacion">&nbsp;</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="val1" runat="server" TargetControlID="RequiredFieldValidator1"></cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:MultiView ID="mvOperacion" runat="server">
                                    <asp:View ID="vCancela" runat="server">
                                        <asp:Button ID="btnCancela" runat="server" Text="Cancelar premio" OnClick="btnCancela_Click"
                                            CssClass="boton" ValidationGroup="operacion" />
                                    </asp:View>
                                    <asp:View ID="vGarantia" runat="server">
                                        <asp:Button ID="btnGarantia" runat="server" Text="Generar garant&iacute;a" OnClick="btnGarantia_Click"
                                            CssClass="boton" ValidationGroup="operacion" />
                                    </asp:View>
                                    <asp:View ID="vNotas" runat="server">
                                        <asp:Button ID="btnNotas" runat="server" Text="Agregar notas de entrega" OnClick="btnNotas_Click"
                                            CssClass="boton" ValidationGroup="operacion" />
                                    </asp:View>
                                </asp:MultiView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr height="10">
                <td>&nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:LinkButton ID="lnkDetalle" runat="server"></asp:LinkButton>
    <cc1:ModalPopupExtender ID="popDetalle" runat="server" BackgroundCssClass="Sombra"
        PopupControlID="pnlDetalle" TargetControlID="lnkDetalle" CancelControlID="imgCancelarDetalle">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlDetalle" runat="server" Width="750px" Style="display: none" BorderWidth="2px"
        BorderColor="#797979" CssClass="modalPopup" BorderStyle="Solid" BackColor="#FFFFFF">
        <table width="100%">
            <tr height="5">
                <td align="right">
                    <asp:ImageButton ID="imgCancelarDetalle" runat="server" ImageUrl="~/img/cancel.png" />
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td colspan="2">
                                <h3>Estos son los datos del premio en RMS
                                </h3>
                            </td>
                        </tr>
                        <tr>
                            <td>Pedido RMS:
                            </td>
                            <td>
                                <asp:Label ID="lblPedidoRMS" runat="server"></asp:Label>
                            </td>
                            <td>Pedido LMS:
                            </td>
                            <td>
                                <asp:Label ID="lblPedidoLMS" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Folio:
                            </td>
                            <td>
                                <asp:Label ID="lblFolio" runat="server"></asp:Label>
                            </td>
                            <td>Distribuidora:
                            </td>
                            <td>
                                <asp:Label ID="lblDistribuidora" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Ruta
                            </td>
                            <td>
                                <asp:Label ID="lblRuta" runat="server"></asp:Label>
                            </td>
                            <td>Socio:
                            </td>
                            <td>
                                <asp:Label ID="lblSocio" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Propietario:
                            </td>
                            <td>
                                <asp:Label ID="lblPropietario" runat="server"></asp:Label>
                            </td>
                            <td>Razón social:
                            </td>
                            <td>
                                <asp:Label ID="lblRazonSocial" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Calle:
                            </td>
                            <td>
                                <asp:Label ID="lblCalle" runat="server"></asp:Label>
                            </td>
                            <td>Entre calle:
                            </td>
                            <td>
                                <asp:Label ID="lblEntreCalle" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Y calle:
                            </td>
                            <td>
                                <asp:Label ID="lblYCalle" runat="server"></asp:Label>
                            </td>
                            <td>Colonia:
                            </td>
                            <td>
                                <asp:Label ID="lblColonia" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Municipio:
                            </td>
                            <td>
                                <asp:Label ID="lblMunicipio" runat="server"></asp:Label>
                            </td>
                            <td>Ciudad:
                            </td>
                            <td>
                                <asp:Label ID="lblCiudad" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Estado:
                            </td>
                            <td>
                                <asp:Label ID="lblEstado" runat="server"></asp:Label>
                            </td>
                            <td>C.P.:
                            </td>
                            <td>
                                <asp:Label ID="lblCP" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Teléfono:
                            </td>
                            <td>
                                <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                            </td>
                            <td>Clave:
                            </td>
                            <td>
                                <asp:Label ID="lblClave" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Premio:
                            </td>
                            <td>
                                <asp:Label ID="lblPremioDetalle" runat="server"></asp:Label>
                            </td>
                            <td>Cantidad:
                            </td>
                            <td>
                                <asp:Label ID="lblCantidad" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Fecha solicitud:
                            </td>
                            <td>
                                <asp:Label ID="lblFechaSol" runat="server"></asp:Label>
                            </td>
                            <td>Fecha Promesa:
                            </td>
                            <td>
                                <asp:Label ID="lblFechaProm" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Fecha status:
                            </td>
                            <td>
                                <asp:Label ID="lblFechaStatus" runat="server"></asp:Label>
                            </td>
                            <td>Mensajería:
                            </td>
                            <td>
                                <asp:Label ID="lblMensajeria" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Guia:
                            </td>
                            <td>
                                <asp:Label ID="lblGuia" runat="server"></asp:Label>
                            </td>
                            <td>Fecha embarque:
                            </td>
                            <td>
                                <asp:Label ID="lblFechaEmb" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Origen:
                            </td>
                            <td>
                                <asp:Label ID="lblOrigen" runat="server"></asp:Label>
                            </td>
                            <td>Destino:
                            </td>
                            <td>
                                <asp:Label ID="lblDestino" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Recibido por:
                            </td>
                            <td>
                                <asp:Label ID="lblRecibidoPor" runat="server"></asp:Label>
                            </td>
                            <td>Status:
                            </td>
                            <td>
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Fecha entrega:
                            </td>
                            <td>
                                <asp:Label ID="lblFechaEntrega" runat="server"></asp:Label>
                            </td>
                            <td>Observaciones:
                            </td>
                            <td>
                                <asp:Label ID="lblObservaciones" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Proveedor:
                            </td>
                            <td>
                                <asp:Label ID="lblProveedor" runat="server"></asp:Label>
                            </td>
                            <td>Tipo envío:
                            </td>
                            <td>
                                <asp:Label ID="lblTipoEnvio" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Prioridad:
                            </td>
                            <td>
                                <asp:Label ID="lblPrioridad" runat="server"></asp:Label>
                            </td>
                            <td>Comentario:
                            </td>
                            <td>
                                <asp:Label ID="lblComentario" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Clave extra:
                            </td>
                            <td>
                                <asp:Label ID="lblClaveExtra" runat="server"></asp:Label>
                            </td>
                            <td>Tipo dirección:
                            </td>
                            <td>
                                <asp:Label ID="lblTipoDireccion" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Referencias:
                            </td>
                            <td>
                                <asp:Label ID="lblReferencias" runat="server"></asp:Label>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </center>
</asp:Content>
