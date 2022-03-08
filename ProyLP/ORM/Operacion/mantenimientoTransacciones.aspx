<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="mantenimientoTransacciones.aspx.cs" Inherits="ORMOperacion.mantenimientoTransacciones" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
    <link id="styCalendario" runat="server" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>
        <table border="0">
            <tr>
                <td>
                    <h4>Agregar Transacci&oacute;n</h4>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td class="texto11" align="left">
                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Participante:"
                                    CssClass="lblLlamadas"></asp:Label>
                            </td>
                            <td class="texto11" align="left">
                                <asp:Label ID="lblParticipante" runat="server" Text="" CssClass="texto11 sin_borde"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="texto11" align="left">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Distribuidora:"
                                    CssClass="lblLlamadas"></asp:Label>
                            </td>
                            <td class="texto11" align="left">
                                <asp:Label ID="lblDistribuidora" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="texto11" align="left">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Pa&iacute;s:"
                                    CssClass="lblLlamadas"></asp:Label>
                            </td>
                            <td class="texto11" align="left">
                                <asp:HiddenField ID="hidPrograma" runat="server" Value="" />
                                <asp:Label ID="lblPrograma" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="texto11 negrita" align="left">Tipo de Transacci&oacute;n:
                            </td>
                            <td class="texto11" align="left">
                                <asp:UpdatePanel ID="upTransaccion" runat="server">
                                    <ContentTemplate>
                                            <telerik:RadComboBox ID="ddlTipoTransaccion" DataValueField="clave" 
                                                DataTextField="descripcion" runat="server"
                                                AppendDataBoundItems="True" AutoPostBack="true" Width="250px" CssClass="sin_borde">
                                            </telerik:RadComboBox>
                                            <asp:RequiredFieldValidator ID="reqTipoTransaccion" runat="server" ControlToValidate="ddlTipoTransaccion" ErrorMessage="Tipo de Transacción requerido" InitialValue="0" ValidationGroup="guardar">&nbsp;</asp:RequiredFieldValidator>
                                            <cc1:ValidatorCalloutExtender ID="valTipoTransaccion" runat="server" TargetControlID="reqTipoTransaccion"></cc1:ValidatorCalloutExtender>
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td class="texto11 negrita" align="left">Puntos:
                            </td>
                            <td class="texto11" align="left">
                                    <asp:TextBox ID="txtPuntos" runat="server" Width="135px" MaxLength="8" CssClass="texto11 sin_borde telerikCalendarCustom"
                                        ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPuntos" runat="server" ControlToValidate="txtPuntos" ErrorMessage="Kilómetros requerido" ValidationGroup="guardar">&nbsp;</asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="vcePuntos" runat="server" TargetControlID="rfvPuntos"></cc1:ValidatorCalloutExtender>
                                    <cc1:FilteredTextBoxExtender ID="filPuntos" runat="server" TargetControlID="txtPuntos"
                                        FilterMode="ValidChars" FilterType="Numbers">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                        </tr>
                        <tr>
                            <td class="texto11 negrita" align="left">Fecha Transacci&oacute;n:
                            </td>
                            <td class="texto11" align="left">
                                    <asp:TextBox ID="txtFechaTransaccion" runat="server" Width="135px" CssClass="calendario telerikCalendarCustom sin_borde"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqFechaTransaccion" runat="server" ErrorMessage="Ingresa fecha de transacción"
                                        ControlToValidate="txtFechaTransaccion" CssClass="naranja" ValidationGroup="guardar">&nbsp;</asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="cmpFechaTransaccion" runat="server" ControlToValidate="txtFechaTransaccion"
                                        ErrorMessage="Fecha de Transacción Invalida" Type="Date" CssClass="naranja" ValidationGroup="guardar">&nbsp;</asp:RangeValidator>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="cmpFechaTransaccion">
                                    </cc1:ValidatorCalloutExtender>
                                    <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="reqFechaTransaccion">
                                    </cc1:ValidatorCalloutExtender>
                                    <cc1:CalendarExtender ID="calFechaTransaccion" runat="server" Format="dd/MM/yyyy"
                                        TargetControlID="txtFechaTransaccion" CssClass="cal_Theme1" PopupPosition="Right">
                                    </cc1:CalendarExtender>
                                    <cc1:MaskedEditExtender ID="mskFechaTransaccion" runat="server" Mask="99/99/9999"
                                        MaskType="Date" TargetControlID="txtFechaTransaccion" UserDateFormat="DayMonthYear">
                                    </cc1:MaskedEditExtender>
                                </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <telerik:RadButton ID="btnGuardar" runat="server" CssClass="negrita" Text="Guardar" ValidationGroup="guardar" 
                                    OnClick="btnGuardar_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
