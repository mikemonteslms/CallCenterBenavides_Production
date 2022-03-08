<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cambiarPassword.ascx.cs" Inherits="ORMOperacion.cambiarPassword" %>
<table width="100%">
    <tr>
        <td colspan="2">
            <p style="display: none">
                <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label></p>
        </td>
    </tr>
    <tr>
        <td style="width: 40%; text-align: right">Contraseña Actual:&nbsp;</td>
        <td style="width: 60%; text-align: left">
            <telerik:RadTextBox ID="txtCActual" TextMode="Password" runat="server"></telerik:RadTextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">Nueva Contraseña:&nbsp;</td>
        <td style="text-align: left">
            <telerik:RadTextBox ID="txtContraseña" TextMode="Password" runat="server"></telerik:RadTextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">Confirmar Contraseña:&nbsp;</td>
        <td style="text-align: left">
            <telerik:RadTextBox ID="txtConfirmacion" TextMode="Password" runat="server"></telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <telerik:RadButton ID="btnActualizar" runat="server" Text="Cambiar" CssClass="negrita" OnClick="btnActualizar_Click" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">&nbsp;</td>
        <td style="text-align: left">
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtContraseña" ControlToValidate="txtConfirmacion" ErrorMessage="La Confirmación de contraseña no es igual a la nueva contraseña." ForeColor="Red"></asp:CompareValidator>
        </td>
    </tr>
</table>
