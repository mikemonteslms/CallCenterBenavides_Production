<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="SeguimientoLlamadas.aspx.cs" Inherits="ORMOperacion.SeguimientoLlamadas" %>

<%@ MasterType VirtualPath="~/contenido.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <asp:ValidationSummary ID="vsSeguimientoLlamadas" runat="server" ValidationGroup="actualizar"
        ShowMessageBox="true" ShowSummary="false" />
    <center>
        <table border="0" width="100%">
            <tr>
                <td>
                    <h4>Llamadas >> Seguimiento de llamadas</h4>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td align="left" width="10%">&nbsp;   
                                <asp:Label ID="lblParticipante" runat="server" Text="Partipante:"
                                    CssClass="texto11 negrita"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="txtParticipante" runat="server" CssClass="texto11"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">&nbsp; 
                                <asp:Label ID="lblDescripcion" runat="server" Text="Descripci&oacute;n:"
                                    CssClass="texto11 negrita"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="txtDescripcion" runat="server" CssClass="texto11"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">&nbsp;   
                                <asp:Label ID="lblNoCaso" runat="server" Text="No. Caso:"
                                    CssClass="texto11 negrita" Visible="false"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="txtNoCaso" runat="server" Visible="false" CssClass="texto11"> </asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" class="PaginaTitulo">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRegistros" runat="server" CssClass="texto11"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:MultiView ID="mvSeguimientoLlamada" runat="server" ActiveViewIndex="0">
                                                <asp:View ID="vSeguimientoLlamada" runat="server">
                                                    <table width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvSeguimientoLlamadas" runat="server" AutoGenerateColumns="False"
                                                                    GridLines="None" CssClass="texto11" DataKeyNames="id" OnRowUpdating="gvSeguimientoLlamadas_RowUpdating" Width="100%">
                                                                    <RowStyle Height="20px" />
                                                                    <AlternatingRowStyle BackColor="#E2F1FC" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="id" HeaderText="Caso">
                                                                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="fecha_llamada" HeaderText="Fecha">
                                                                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="nombre_llama" HeaderText="Nombre del que llama">
                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="descripcion" HeaderText="Descripci&oacute;n">
                                                                            <ItemStyle Width="40%" HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="status_seguimiento" HeaderText="Status">
                                                                            <ItemStyle Width="10%" HorizontalAlign="center" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField ItemStyle-Width="10%">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Update"
                                                                                    Text="Ver detalle"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td width="20%">Fecha
                                                                                </td>
                                                                                <td width="60%">Descripci&oacute;n
                                                                                </td>
                                                                                <td width="20%">Comentarios
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">No se encontraron registros
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:View>
                                                <asp:View ID="vLlamadaDetalle" runat="server">
                                                    <table width="100%" class="texto11">
                                                        <tr>
                                                            <td class="negrita">Detalle de Llamadas
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div align="right">
                                                                    <p>
                                                                        <asp:Label ID="lblRegistrosDetalle" runat="server"></asp:Label>
                                                                    </p>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:HiddenField ID="hidLlamada_id" runat="server" />
                                                                <asp:HiddenField ID="hidNombreCompleto" runat="server" />
                                                                <asp:HiddenField ID="hidRazonSocial" runat="server" />
                                                                <asp:HiddenField ID="hidClave" runat="server" />
                                                                <asp:HiddenField ID="hidDistribuidora" runat="server" />
                                                                <asp:HiddenField ID="hidPrograma" runat="server" />
                                                                <asp:HiddenField ID="hidCountryCode" runat="server" />
                                                                <asp:GridView ID="gvSeguimientoDetalle" runat="server" AutoGenerateColumns="False"
                                                                    ShowFooter="true" GridLines="None" CssClass="texto11" DataKeyNames="id"
                                                                    OnRowDataBound="gvSeguimientoDetalle_RowDataBound">
                                                                    <RowStyle Height="20px" />
                                                                    <AlternatingRowStyle BackColor="#E2F1FC" />
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:HiddenField ID="hidID" runat="server" Value='<%#Bind("id") %>' />
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="Fecha" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFecha" CssClass="texto11" runat="server" Text='<%#Bind("fecha") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="40%" HeaderText="Comentarios" ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblObservacion" CssClass="texto11" runat="server" Height="54px"
                                                                                    Text='<%#Bind("observacion") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <span class="campoTexto1">
                                                                                                <asp:TextBox ID="txtObservacion" runat="server" Width="330px" Height="54px" TextMode="MultiLine" CssClass="texto11 sin_borde">
                                                                                                </asp:TextBox>
                                                                                            </span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="reqObservacion" runat="server" ErrorMessage="Introduzca Comentarios"
                                                                                                ControlToValidate="txtObservacion" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                                                                                            <cc1:ValidatorCalloutExtender ID="valObservacion" runat="server" TargetControlID="reqObservacion">
                                                                                            </cc1:ValidatorCalloutExtender>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="Escalamiento" ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEscalamiento" CssClass="texto11" runat="server" Height="54px"
                                                                                    Text='<%#Bind("escalamiento") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <span class="campoTexto1">
                                                                                                <asp:DropDownList ID="ddlEscalamiento" runat="server" CssClass="texto11 sin_borde" AppendDataBoundItems="True"
                                                                                                    DataValueField="id" DataTextField="descripcion" Width="100%">
                                                                                                </asp:DropDownList>
                                                                                            </span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="reqEscalamiento" runat="server" ErrorMessage="Introduzca Escalamiento"
                                                                                                ControlToValidate="ddlEscalamiento" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                                                                                            <cc1:ValidatorCalloutExtender ID="valEscalamiento" runat="server" TargetControlID="reqEscalamiento">
                                                                                            </cc1:ValidatorCalloutExtender>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="10%" HeaderText="Status" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblStatus" CssClass="texto11" runat="server"
                                                                                    Text='<%#Bind("descripcion_status") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center">
                                                                                            <span class="campoTexto1">
                                                                                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="texto11 sin_borde campoTexto1" AppendDataBoundItems="True"
                                                                                                    DataValueField="status_seguimiento_id" DataTextField="descripcion" Width="100px" Height="18px">
                                                                                                </asp:DropDownList>
                                                                                            </span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
                                                                            <ItemTemplate>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="center">
                                                                                            <asp:LinkButton ID="lkbGuardar" runat="server" CausesValidation="true" OnCommand="gvSeguimientoDetalle_RowCommand"
                                                                                                CommandName="Update" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                                                                ValidationGroup="actualizar" Text="Guardar" CssClass=""></asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td width="20%">Fecha
                                                                                </td>
                                                                                <td width="40%">Descripci&oacute;n
                                                                                </td>
                                                                                <td width="40%">Comentarios
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">No se encontraron registros
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnRegresar" runat="server" CssClass="boton negrita sin_borde" Text="Regresar"
                                                                    OnClick="btnRegresar_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:View>
                                            </asp:MultiView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
