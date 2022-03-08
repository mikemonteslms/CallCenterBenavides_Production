<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="MantenimientoCanjes.aspx.cs" Inherits="ORMOperacion.MantenimientoCanjes" %>

<%@ Register Assembly="BotonEnviar" Namespace="BotonEnviar" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/contenido.master" %>
<%@ Register Src="~/controles/ucDireccion_AR.ascx" TagName="ucDireccion" TagPrefix="ucDireccion" %>
<%@ Register Src="~/controles/ucDireccion_CO.ascx" TagName="ucDireccionCO" TagPrefix="ucDireccionCO" %>
<%@ Register Src="~/controles/ucDireccion_MX.ascx" TagName="ucDireccionMX" TagPrefix="ucDireccionMX" %>
<%@ Register Src="~/controles/ucDireccionDistribuidor_MX.ascx" TagName="ucDireccionDistribuidorMX" TagPrefix="ucDireccionDistribuidorMX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
    <link rel="stylesheet" type="text/css" href="style/css/canje-operacion.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>
        <table border="0" width="100%">
            <tr>
                <td>
                            <div style="width: 100%;" id="MEXICO">
                                <%--<h4>Canjes >> Canje de premios</h4>--%>
                                <span></span>
                                <table width="100%" >
                                    <tr>
                                        <td colspan="2">
                                            <div class="texto13 negrita">
                                                Cat&aacute;logo de premios
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div id="Div3">
                                                <asp:Panel ID="Panel2" runat="server" DefaultButton="btnBuscarMX">
                                                    <table border="0" width="100%">
                                                        <tr>
                                                            <td colspan="2" align="center">
                                                                <span class="negrita texto13">BUSCAR PREMIOS</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                    <telerik:RadTextBox ID="txtBusquedaMX" runat="server" Width="90%" CssClass="texto11 sin_borde"></telerik:RadTextBox>
                                                                </td>
                                                            <td align="left">
                                                                <telerik:RadButton ID="btnBuscarMX" runat="server" Text="Buscar" CssClass="negrita" OnCommand="btnBuscar_Command" CommandArgument="MX" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="55%" class="texto11">
                                                <tr>
                                                    <td width="10%">Categor&iacute;a:
                                                    </td>
                                                    <td width="90%" align="left">
                                                            <telerik:RadDropDownList ID="ddlCategoriaMX" runat="server" DataTextField="descripcion" DataValueField="id"
                                                                AppendDataBoundItems="True" CssClass="texto11 sin_borde" Width="100%" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlCategoriaMX_SelectedIndexChanged">
                                                            </telerik:RadDropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadGrid ID="dgPremiosMX" runat="server" AutoGenerateColumns="false" AllowPaging="True" 
                                                CssClass="texto13"
                                                GridLines="None" OnRowDataBound="dgPremiosMX_DataBound" 
                                                PagerSettings-LastPageText=">>"
                                                PageSize="6" 
                                                DataKeyNames="id" Width="100%"
                                                OnNeedDataSource="dgPremiosMX_NeedDataSource">
                                                <MasterTableView>
                                                <Columns>
                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Image ID="imgPremioMX" runat="server" Height="40px" ImageUrl='<%# Eval("url_imagen_small") %>'/>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderText="Descripci&oacute;n">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkVerMas" runat="server" Text='<%# Eval("descripcion") %>'
                                                                CommandName="detalle" CommandArgument='<%# Eval("id") %>' OnCommand="imgPremios_Command"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridBoundColumn DataField="puntos" HeaderText="Kilómetros" DataFormatString="{0:N0}">
                                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" >
                                                        <ItemTemplate>
                                                            <asp:LinkButton runat="server" ID="lnkAgregar" Text="Agregar" CommandName="Select" CommandArgument='<%# Eval("id") %>' 
                                                                OnClick="lnkAgregar_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <%--<telerik:GridButtonColumn ButtonType="LinkButton" CommandName="Select" Text="Agregar" CommandArgument='<%# Eval("id") %>'></telerik:GridButtonColumn>--%>
                                                </Columns>
                                                    </MasterTableView>
                                            </telerik:RadGrid>
                                        </td>
                                        <td valign="top">
                                            <table width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <asp:MultiView ID="mvCarritoMX" runat="server" ActiveViewIndex="0">
                                                            <asp:View ID="vCarritoMX" runat="server">
                                                                <asp:Repeater ID="rptCarritoMX" runat="server" OnItemCommand="rptCarritoMX_ItemCommand"
                                                                    OnItemDataBound="rptCarritoMX_ItemDataBound">
                                                                    <HeaderTemplate>
                                                                        <div id="Layer1" style="width: 100%; height: 400px; overflow: scroll;">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td width="10%"></td>
                                                                                <td width="30%"></td>
                                                                                <td width="10%"></td>
                                                                                <td width="5%"></td>
                                                                                <td width="10%"></td>
                                                                                <td width="5%"></td>
                                                                                <td width="10%"></td>
                                                                                <td width="10%"></td>
                                                                                <td width="10%"></td>
                                                                            </tr>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr class="texto11">
                                                                            <td align="center">
                                                                                <asp:Image ID="imgPremioMX" runat="server" ImageUrl='<%# Eval("URL") %>' Height="40px" />
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblDescripcionMX" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label><br />
                                                                                <asp:Label ID="lblObservacionesMX" runat="server" Text='<%# Eval("Observaciones") %>'></asp:Label>
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:TextBox ID="txtCantidadMX" runat="server" Text='<%# Eval("Cantidad") %>' Width="30px"
                                                                                    MaxLength="2" CssClass="campoTexto1 texto11"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars"
                                                                                    FilterType="Numbers" TargetControlID="txtCantidadMX">
                                                                                </cc1:FilteredTextBoxExtender>
                                                                            </td>
                                                                            <td align="right">x
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblPuntosMX" runat="server" Text='<%# Eval("Puntos") %>'></asp:Label>
                                                                            </td>
                                                                            <td align="right">=
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblPuntosTotalMX" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:LinkButton ID="lnkActualizarMX" runat="server" Text="Actualizar" CommandName="actualizar"
                                                                                    CommandArgument='<%# Eval("PremioID") %>'></asp:LinkButton>
                                                                            </td>
                                                                            <td align="center">
                                                                                <asp:LinkButton ID="lnkEliminarMX" runat="server" Text="Eliminar" CommandName="eliminar"
                                                                                    CommandArgument='<%# Eval("PremioID") %>'></asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <tr>
                                                                            <td colspan="9">
                                                                                <hr />
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="texto11">
                                                                            <td></td>
                                                                            <td align="right">
                                                                                <b>Premios:</b>
                                                                            </td>
                                                                            <td align="center">
                                                                                <b>
                                                                                    <asp:Label ID="lblPremiosTotalesMX" runat="server" CssClass="campoTexto1" Width="30px"></asp:Label></b>
                                                                            </td>
                                                                            <td colspan="2" align="right">
                                                                                <b>Kilómetros:</b>
                                                                            </td>
                                                                            <td colspan="2" align="center">
                                                                                <b>
                                                                                    <asp:Label ID="lblPuntosTotalesMX" runat="server" CssClass="campoTexto1"></asp:Label></b>
                                                                            </td>
                                                                            <td align="right">
                                                                                <b>Saldo:</b>
                                                                            </td>
                                                                            <td align="center">
                                                                                <b>
                                                                                    <asp:Label ID="lblSaldoMX" runat="server" CssClass="campoTexto1"></asp:Label></b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="9">
                                                                                <table border="0" align="right" class="texto11" width="50%">
                                                                                    <tr>
                                                                                        <td align="center" colspan="4">                                                                
                                                                                            <span class="negrita">Direcci&oacute;n de env&iacute;o
                                                                                            </span>
                                                                                            <br />                                                               
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <%--<ucDireccionMX:ucDireccionMX ID="dirParticipanteMX" EnableViewState="true" runat="server" />--%>
                                                                                            <ucDireccionDistribuidorMX:ucDireccionDistribuidorMX ID="dirDistribuidorMX" EnableViewState="true" runat="server" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        </table>
                                                                        </div>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                                <table>
                                                                    <tr>
                                                                        <td colspan="8" align="center">
                                                                            <cc3:BotonEnviar ID="btnCanjearMX" runat="server" Text="Canjear" TextoEnviando="Procesando..."
                                                                                 OnClick="btnCanjearGalenia_Click" ViewStateMode="Disabled" CausesValidation="false" CssClass="telerikButtonBootStrap" />
                                                                        </td>                                                                        
                                                                    </tr>
                                                                </table>
                                                            </asp:View>
                                                            <asp:View ID="vVacioMX" runat="server">
                                                                <table bgcolor="#E2F1FC" class="texto13">
                                                                    <tr>
                                                                        <td colspan="9">
                                                                            <hr />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td></td>
                                                                        <td align="right" width="50px">Premios:
                                                                        </td>
                                                                        <td align="right" width="50px">0
                                                                        </td>
                                                                        <td colspan="2" align="right" width="50px">Kilómetros:
                                                                        </td>
                                                                        <td colspan="2" align="right" width="50px">0
                                                                        </td>
                                                                        <td align="right" width="50px">
                                                                            <b>Saldo:</b>
                                                                        </td>
                                                                        <td align="right" width="50px">
                                                                            <b>
                                                                                <asp:Label ID="lblSaldoInicioMX" runat="server" Text="0"></asp:Label></b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="9">
                                                                            <hr />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="9"></td>
                                                                    </tr>
                                                                </table>
                                                            </asp:View>
                                                        </asp:MultiView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                    <asp:HyperLink ID="lnkRecarga" runat="server"></asp:HyperLink>
                    <cc1:ModalPopupExtender ID="popRecarga" runat="server" TargetControlID="lnkRecarga"
                        PopupControlID="pnlRecarga" BackgroundCssClass="Sombra" CancelControlID="imgCerrarMensaje">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="pnlRecarga" runat="server" Width="400px" Style="display: none;">
                        <table border="0" width="400px">
                            <tr>
                                <td class="mensaje_cen">
                                    <h4>
                                        <asp:Label ID="lblPremioRecarga" runat="server"></asp:Label></h4>
                                    <p>
                                        Por favor indique el número celular con clave y la operadora para la recarga
                                    </p>
                                    <table>
                                        <tr valign="top">
                                            <td>
                                                <span class="cuadro_texto2">
                                                    <asp:TextBox ID="txtCelular" runat="server" Width="135px" CssClass="transparente" MaxLength="15"></asp:TextBox>
                                                </span>
                                                <cc1:FilteredTextBoxExtender ID="filCelular" runat="server" TargetControlID="txtCelular" FilterMode="ValidChars" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="reqCelular" runat="server" ControlToValidate="txtCelular" ErrorMessage="Número celular requerido" ValidationGroup="recarga">&nbsp;</asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="valCelular" runat="server" TargetControlID="reqCelular"></cc1:ValidatorCalloutExtender>
                                            </td>
                                            <td>
                                                <span class="cuadro_texto2">
                                                    <asp:DropDownList ID="ddlOperadora" runat="server" DataValueField="ID" DataTextField="Descripcion" Width="135px" CssClass="transparente"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="reqOperadora" runat="server" ControlToValidate="ddlOperadora" ErrorMessage="Operadora requerido" InitialValue="0" ValidationGroup="recarga">&nbsp;</asp:RequiredFieldValidator>
                                                    <cc1:ValidatorCalloutExtender ID="valOperadora" runat="server" TargetControlID="reqOperadora"></cc1:ValidatorCalloutExtender>
                                                </span>
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hidPremioID" runat="server" />
                                                <asp:MultiView ID="mvRecarga" runat="server">
                                                    <asp:View ID="vMX" runat="server">
                                                        <asp:Button ID="btnRecargaMX" runat="server" Text="Aceptar" CssClass="boton negrita sin_borde" OnClick="btnRecargaMX_Click" ValidationGroup="recarga" />
                                                    </asp:View>
                                                </asp:MultiView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="mensaje_inf">
                                    <asp:Button ID="imgCerrarMensaje" runat="server" CssClass="boton negrita sin_borde" Text="Cancelar"
                                        CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:HyperLink ID="lnkDetallePremio" runat="server"></asp:HyperLink>
                    <cc1:ModalPopupExtender ID="popDetallePremio" runat="server" TargetControlID="lnkDetallePremio"
                        PopupControlID="pnlDetallePremio" CancelControlID="imgCerrarPremio" BackgroundCssClass="Sombra">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="pnlDetallePremio" runat="server" Width="446px" Style="display: none">
                        <table border="0" width="446px">
                            <tr>
                                <td class="canje_sup">
                                    <asp:Label ID="lblDetalle" runat="server" CssClass="texto13 negrita"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="canje_cen">
                                    <table border="0" width="426px">
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Image ID="imgDetalle" runat="server" ImageUrl="" Width="160px" Height="160px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left" class="texto13">
                                                <p>
                                                    <asp:Label ID="lblDetalleLargo" runat="server" CssClass="color_azul"></asp:Label>
                                                </p>
                                                <p>
                                                    <asp:Label ID="lblIncluye" runat="server" CssClass="color_azul"></asp:Label>
                                                </p>
                                                <p>
                                                    <asp:Label ID="lblAdicional" runat="server" CssClass="color_azul"></asp:Label>
                                                </p>
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblDetallePuntos" runat="server" CssClass="texto14 negrita"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr align="center">
                                <td class="canje_inf">
                                    <asp:Button ID="imgCerrarPremio" runat="server" CssClass="boton negrita sin_borde" Text="Cerrar" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
</center>
</asp:Content>
