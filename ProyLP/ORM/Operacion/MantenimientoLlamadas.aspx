<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="MantenimientoLlamadas.aspx.cs" Inherits="ORMOperacion.MantenimientoLlamadas" %>

<%@ Register TagName="Categoria" TagPrefix="Cat" Src="~/controles/categoria.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxcontroltoolkit" %>
<%@ MasterType VirtualPath="~/contenido.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <asp:ValidationSummary ID="vsLlamadas" runat="server" ValidationGroup="aceptar" ShowMessageBox="true"
        ShowSummary="false" />
    <center>
             <table border="0" Width="986px">
                <tr>
                    <td>
                        <div style="width: 980px;">
                            <div>
                                <h4>Mantenimiento de Llamadas</h4>                        
                                <table>
                                    <tr align="left" class="texto11">
                                        <td>
                                            <asp:Label ID="lblParticipante" runat="server" Font-Bold="True" Text="Partipante:"
                                                CssClass="lblLlamadas"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="txtParticipante" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr align="left" class="texto11">
                                        <td>
                                            <asp:Label ID="lblNumCategorias" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="texto11">
                                            <asp:Label ID="Label1" runat="server" CssClass="lblLlamadas" Font-Bold="True" Text="Persona que llamo:"></asp:Label>
                                        </td>
                                        <td align="left" class="texto11">
                                                <telerik:RadTextBox ID="txtPersona" runat="server" Width="300px" MaxLength="50" CssClass="texto11 sin_borde"></telerik:RadTextBox>
                                                <asp:RequiredFieldValidator ID="reqPersona" runat="server" ErrorMessage="Introduzca Nombre"
                                                    ControlToValidate="txtPersona" CssClass="naranja" ValidationGroup="aceptar">&nbsp;</asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="valPersona" runat="server" TargetControlID="reqPersona">
                                                </cc1:ValidatorCalloutExtender>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="texto11">
                                            <asp:Label ID="Label3" runat="server" CssClass="lblLlamadas" Font-Bold="True" Text="Tel&eacute;fono:"></asp:Label>
                                        </td>
                                        <td align="left" style="height: 60px" class="texto11">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:MultiView ID="mvTipoTelefono" runat="server">
                                                            <asp:View ID="vrblTipoTelefono" runat="server">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <span style="width: 115px; display: table-cell;">Tipo Tel&eacute;fono</span>
                                                                            <span style="width: 50px; display: table-cell;">Lada</span>
                                                                            <span style="width: 100px; display: table-cell;">Teléfono</span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rblTipoTelefono" runat="server" Width="400px"></asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:View>
                                                            <asp:View ID="vtblTipoTelefono" runat="server">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <span style="width: 50px; display: table-cell;">Lada</span>
                                                                        </td>
                                                                        <td>
                                                                            <span style="width: 140px; display: table-cell;">Tel&eacute;fono</span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="50px">
                                                                                <asp:TextBox ID="txtLada" runat="server" Width="50px" MaxLength="5" CssClass="sin_borde telerikCalendarCustom"></asp:TextBox>
                                                                                <ajaxcontroltoolkit:FilteredTextBoxExtender ID="filLada" runat="server" FilterMode="ValidChars"
                                                                                    FilterType="Numbers" TargetControlID="txtLada">
                                                                                </ajaxcontroltoolkit:FilteredTextBoxExtender>
                                                                            </td>
                                                                        <td width="140px">
                                                                                <asp:TextBox ID="txtTelefono" runat="server" Width="140px" MaxLength="15" CssClass="sin_borde telerikCalendarCustom"></asp:TextBox>
                                                                                    <ajaxcontroltoolkit:FilteredTextBoxExtender ID="FilTelefono" runat="server" FilterMode="ValidChars"
                                                                                        FilterType="Numbers" TargetControlID="txtTelefono">
                                                                                    </ajaxcontroltoolkit:FilteredTextBoxExtender>
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
                                        <td align="left" class="texto11">
                                            <asp:Label ID="Label2" runat="server" CssClass="lblLlamadas" Font-Bold="True" Text="Comentarios:"></asp:Label>
                                        </td>
                                        <td align="left" style="height: 15px" class="texto11">
                                                <telerik:RadTextBox ID="txtComentarios" runat="server" Width="339px" Height="50px" TextMode="MultiLine"
                                                    MaxLength="1000" CssClass="texto11 sin_borde"></telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="reqComentario" runat="server" ErrorMessage="Introduzca Comentarios"
                                                ControlToValidate="txtComentarios" CssClass="naranja" ValidationGroup="aceptar">&nbsp;</asp:RequiredFieldValidator>
                                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="reqComentario">
                                            </cc1:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" class="texto11">
                                            <asp:Panel ID="pnlLlamada" runat="server" Visible="false">
                                                <table border="0" Width="970px">
                                                    <tr>                                                
                                                        <td>
                                                            <asp:Panel ID="Panel1" runat="Server" Height="350px" Width="960px" ScrollBars="Auto">
                                                                <Cat:Categoria ID="catParticipante" runat="server"/>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>                                            
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <telerik:RadButton ID="btnGuardar" runat="server" CssClass="negrita" OnClick="btnGuardar_Click"
                                                Text="Guardar" ValidationGroup="aceptar" />
                                        </td>
                                        <td align="center">
                                            <telerik:RadButton ID="btnRestablecer" runat="server" CssClass="negrita" OnClick="btnRestablecer_Click"
                                                Text="Limpiar" CausesValidation="false" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td> 
                </tr>        
             </table>
    </center>
</asp:Content>
