<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="historicoLlamadas.aspx.cs" Inherits="ORMOperacion.historicoLlamadas" %>

<%@ MasterType VirtualPath="~/contenido.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>
            <table border="0"  width="100%">        
        <tr>            
            <td>
                    <h4>Llamadas >> Hist&oacute;rico de Llamadas</h4>
            </td>            
        </tr>    
        <tr>
        <td>
        <table width="100%">
                        <tr>
                            <td align="left" width="10%">
                                 &nbsp;   <asp:Label ID="lblParticipante" runat="server"  CssClass="texto11 negrita" Text="Partipante:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="txtParticipante" runat="server"  CssClass="texto11"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" class="PaginaTitulo">
                        <tr>
                            <td align="right">
                             <asp:Label ID="lblRegistros" runat="server"  CssClass="texto11"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gvHistorialLlamadas" runat="server" AutoGenerateColumns="False"
                                    GridLines="None" CssClass="texto11" DataKeyNames="id" OnRowUpdating="gvHistorialLlamadas_RowUpdating" Width="100%">
                                    <RowStyle Height="20px" />
                                    <AlternatingRowStyle BackColor="#E2F1FC" />
                                    <Columns>
                                        <asp:BoundField DataField="fecha" HeaderText="Fecha">
                                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="descripcion" HeaderText="Descripci&oacute;n">
                                            <ItemStyle Width="50%" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="usuario" HeaderText="Usuario">
                                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField >
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Update"
                                                    Text="Ver detalle"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td width="20%">
                                                    Fecha
                                                </td>
                                                <td width="60%">
                                                    Descripci&oacute;n
                                                </td>
                                                <td width="20%">
                                                    Usuario
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    No se encontraron registros
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
        </td>
        </tr>    
    </table>
    <asp:LinkButton ID="lnkPopup" runat="server"></asp:LinkButton>
    <cc1:ModalPopupExtender ID="popDetalleLlamada" runat="server" BackgroundCssClass="Sombra"
        PopupControlID="pnlOperacion" TargetControlID="lnkPopup" CancelControlID="imgCancelar">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlOperacion" runat="server" Style="display: none">
        <table border="0" Width="440px">            
            <tr>                
                <td>
                    <table border="0" Width="100%" bgcolor="#ffffff">
                        <tr height="5px">
                            <td align="right">
                                <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="style/images/cancel.png" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" width="100%" >
                                    <tr>
                                        <td class="texto14 negrita">
                                          
                                                Detalle de llamada
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table border="0" class="texto11">
                                                <tr>
                                                    <td width="30%" class="negrita">
                                                        Nombre participante:
                                                    </td>
                                                    <td width="70%">
                                                        <asp:Label ID="lblNombreParticipante" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="negrita">
                                                        Persona que llam&oacute;:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPersonaLlama" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="negrita">
                                                        Tel&eacute;fono:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="negrita">
                                                        Fecha de la llamada:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblFechaLlamada" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top"  class="negrita">
                                                        Descripci&oacute;n:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDescripcionLlamadaDetalle" runat="server" Enabled="false" TextMode="MultiLine"
                                                            Height="70" Width="300"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td  class="negrita">
                                                        Persona que tom&oacute; la llamada:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblUsuarioLlamada" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <hr />
                                            <asp:Table ID="tblDetalleLlamada" runat="server" CssClass="texto11" Width="100%">
                                            </asp:Table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr height="10">
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>                
            </tr>            
        </table>
    </asp:Panel>
    </center>
</asp:Content>
