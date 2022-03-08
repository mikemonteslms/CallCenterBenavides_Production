<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="envioMensaje.aspx.cs" Inherits="ORMOperacion.envioMensaje" %>

<%@ MasterType VirtualPath="~/contenido.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>
        <table border="0">
            <tr>
                <td>
                    <h4>Env&iacute;o de Mensaje</h4>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="5" width="720px">
                        <tr>
                            <td class="texto11" align="left">
                                <asp:Label ID="lblParticipante" runat="server" Font-Bold="True" Text="Participante:"
                                    CssClass="lblLlamadas"></asp:Label>
                            </td>
                            <td class="texto11" align="left">
                                <asp:Label ID="txtParticipante" runat="server" CssClass="texto11 sin_borde"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="texto11" align="left">
                                <asp:Label ID="lblCorreoElectronico" runat="server" Font-Bold="True" Text="Correo Electrónico:"
                                    CssClass="lblLlamadas"></asp:Label>
                            </td>
                            <td class="texto11" align="left">
                                    <telerik:RadTextBox ID="txtCorreoElectronico" runat="server" Width="300px" Enabled="false" CssClass="texto11 sin_borde"></telerik:RadTextBox>
                                </td>
                        </tr>
                        <tr>
                            <td class="texto11" align="left">
                                <asp:Label ID="lblAsunto" runat="server" Font-Bold="True" Text="Asunto:"
                                    CssClass="lblLlamadas"></asp:Label>
                            </td>
                            <td class="texto11" align="left">
                                    <telerik:RadTextBox ID="txtAsunto" runat="server" Width="300px" CssClass="texto11 sin_borde"></telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="repAsunto" runat="server" ErrorMessage="Introduzca Asunto"
                                    ControlToValidate="txtAsunto" CssClass="naranja" ValidationGroup="aceptar">&nbsp;</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="valAsunto" runat="server" TargetControlID="repAsunto">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="texto11" align="left">
                                <asp:Label ID="lblContenido" runat="server" Font-Bold="True" Text="Mensaje:"
                                    CssClass="lblLlamadas"></asp:Label>
                            </td>
                            <td class="texto11" align="left">
                                <span class="campoComentariosEnvioMensaje">
                                    <telerik:RadTextBox ID="txtMensaje" runat="server" Width="500px" Height="108px" TextMode="MultiLine" ></telerik:RadTextBox>
                                </span>
                                <asp:RequiredFieldValidator ID="reqContenido" runat="server" ErrorMessage="Introduzca Mensaje"
                                    ControlToValidate="txtMensaje" CssClass="naranja" ValidationGroup="aceptar">&nbsp;</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="valContenido" runat="server" TargetControlID="reqContenido">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <telerik:RadButton ID="btnEnviar" runat="server" CssClass="negrita" OnClick="btnEnviar_Click"
                                    Text="Enviar" ValidationGroup="aceptar" />
                            </td>
                            <td align="center">
                                <asp:Button ID="ButtonPrevia" runat="server" CssClass="boton negrita" OnClick="ButtonPrevia_Click"
                                    Text="Vista Previa" ValidationGroup="aceptar" Visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="GeneralFailureText" runat="server"></asp:Label>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
