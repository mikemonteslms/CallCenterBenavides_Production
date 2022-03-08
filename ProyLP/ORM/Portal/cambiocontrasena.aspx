<%@ Page Title="" Language="C#" MasterPageFile="~/datos.master" AutoEventWireup="true" CodeBehind="cambiocontrasena.aspx.cs" Inherits="Portal.cambiocontrasena" %>

<%@ MasterType VirtualPath="~/datos.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="datos_head" runat="server">
    <link href="css/passwordstrenght.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="datos_body" runat="server">
    <section id="cuadrilla-productos">
        <h3>Cambio de contraseña</h3>
        <!-- Accordion begin -->
        <div class="accordion_example3">

            <!-- Section 1 -->
            <div class="accordion_in acc_active">
                <div class="acc_head">Cambiar contraseña</div>
                <div class="acc_content">
                    <div>
                        <table>
                            <tr>
                                <td>
                                    <p>
                                        <span class="datos_participante">Llena los datos siguientes para cambiar tu contraseña
                                        </span>
                                    </p>
                                    <p>
                                        <span class="datos_participante">La nueva contraseña requiere un mínimo de
                                                    <%= Membership.MinRequiredPasswordLength %>
                                                    caracteres, incluyendo una letra, un número y un caracter especial.
                                        </span>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ChangePassword ID="ChangeUserPassword" runat="server" EnableViewState="false" RenderOuterTable="false"
                                        OnSendingMail="ChangeUserPassword_SendingMail"
                                        SuccessText="Su contraseña fue actualizada correctamente"
                                        ContinueButtonStyle-CssClass="boton-gris"
                                        NewPasswordRegularExpressionErrorMessage=""
                                        ContinueButtonStyle-Width="80"
                                        ContinueButtonText="Continuar"
                                        ContinueDestinationPageUrl="~/micuenta.aspx" SuccessTitleText=""
                                        ChangePasswordFailureText="Ocurrió un error al cambiar su contraseña. Por favor intente nuevamente.">
                                        <ChangePasswordTemplate>
                                            <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" ShowMessageBox="true"
                                                ShowSummary="false" ValidationGroup="ChangeUserPasswordValidationGroup" />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword" CssClass="datos_participante">Contraseña actual:</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" Width="220px" CssClass="cuadro_texto"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                                            CssClass="naranja" ErrorMessage="La contraseña actual es requerida." ToolTip="La contraseña actual es requerida."
                                                            ValidationGroup="ChangeUserPasswordValidationGroup">&nbsp;</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="CurrentPasswordValidator" runat="server" TargetControlID="CurrentPasswordRequired">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword" CssClass="datos_participante">Nueva contraseña:</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" Width="220px" CssClass="cuadro_texto"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <cc1:PasswordStrength ID="PasswordStrength1" runat="server" TargetControlID="NewPassword"
                                                            DisplayPosition="RightSide" PrefixText="La contraseña es " StrengthIndicatorType="Text"
                                                            MinimumNumericCharacters="1" MinimumSymbolCharacters="1" PreferredPasswordLength="8"
                                                            RequiresUpperAndLowerCaseCharacters="true" TextStrengthDescriptions="Muy débil; Débil; Regular; Buena; Excelente"
                                                            StrengthStyles="TextStrength MuyDebil; TextStrength Debil; TextStrength Regular;TextStrength Buena;TextStrength Excelente">
                                                        </cc1:PasswordStrength>
                                                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                            CssClass="naranja" ErrorMessage="La nueva contraseña es requerida." ToolTip="La nueva contraseña es requerida."
                                                            ValidationGroup="ChangeUserPasswordValidationGroup">&nbsp;</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="NewPasswordValidator" runat="server" TargetControlID="NewPasswordRequired">
                                                        </cc1:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="regLongMin" runat="server"
                                                            ControlToValidate="NewPassword"
                                                            ErrorMessage="La longitud mínima debe ser 5"
                                                            ValidationExpression=".{5}.*" ValidationGroup="ChangeUserPasswordValidationGroup" ToolTip="La longitud mínima debe ser 5" >&nbsp;</asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender ID="valLongMin" runat="server" TargetControlID="regLongMin">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword" CssClass="datos_participante">Confirmar nueva contraseña:</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" Width="220px" CssClass="cuadro_texto"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                                            CssClass="naranja" Display="Dynamic" ErrorMessage="Se requiere que confirme la nueva contraseña."
                                                            ToolTip="Se requiere que confirme la nueva contraseña." ValidationGroup="ChangeUserPasswordValidationGroup">&nbsp;</asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                                            ControlToValidate="ConfirmNewPassword" Display="Dynamic"
                                                            CssClass="naranja" ErrorMessage="La nueva contraseña y la confimación deben coincidir."
                                                            ValidationGroup="ChangeUserPasswordValidationGroup">&nbsp;</asp:CompareValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ConfirmNewPasswordValidator" runat="server" TargetControlID="ConfirmNewPasswordRequired">
                                                        </cc1:ValidatorCalloutExtender>
                                                        <cc1:ValidatorCalloutExtender ID="NewPasswordCompareValidator" runat="server" TargetControlID="NewPasswordCompare">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td colspan="2">
                                                        <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                                            Text="Aceptar" CssClass="boton-gris" Width="80px" ValidationGroup="ChangeUserPasswordValidationGroup" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <span class="datos_participante">
                                                            <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ChangePasswordTemplate>
                                        <MailDefinition>
                                        </MailDefinition>
                                    </asp:ChangePassword>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <!-- Section 2 -->
        </div>
    </section>
</asp:Content>
