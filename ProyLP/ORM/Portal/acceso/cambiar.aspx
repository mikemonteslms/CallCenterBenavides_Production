<%@ Page Title="" Language="C#" MasterPageFile="~/general.master" AutoEventWireup="true" CodeBehind="cambiar.aspx.cs" Inherits="Portal.cambiar.login" %>

<%@ MasterType VirtualPath="~/general.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="general_head" runat="server">
    <link href="../css/estilos_acceso.css" rel="stylesheet" type="text/css">
    <link href="../css/passwordstrenght.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="general_body" runat="server">
    <header>
        <div id="vw-header">
            <h1 id="logoLoyalty"><span>Loyalty World</span></h1>

        </div>
    </header>
    <div id="contenedor">
        <section id="slider">
            <div id="cuadro">
                <div id="cuerpo2">
                    <div class="subtitulo">Cambio de contraseña</div>
                    <br />
                    <p>Ingresa y confirma tu nueva contraseña.</p>
                    <br />
                    <asp:Panel ID="pnlBotonEnviar" runat="server">
                        <asp:ChangePassword ID="ChangeUserPassword" runat="server"
                            CancelDestinationPageUrl="~/acceso/login.aspx"
                            EnableViewState="false"
                            RenderOuterTable="false"
                            SuccessText="Su cuentraseña fue actualizada correctamente."
                            OnChangingPassword="ChangeUserPassword_ChangingPassword">
                            <ChangePasswordTemplate>
                                <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" ValidationGroup="ChangeUserPasswordValidationGroup"
                                    ShowMessageBox="true" ShowSummary="false" />
                                <asp:TextBox ID="CurrentPassword" runat="server" Visible="false"></asp:TextBox>
                                <div>
                                    <p>
                                        <asp:TextBox ID="NewPassword" runat="server" CssClass="cuadro_texto Password" TextMode="Password"
                                            Width="230px" PlaceHolder="Nueva cotraseña"></asp:TextBox>
                                        <cc1:PasswordStrength ID="PasswordStrength1" runat="server" TargetControlID="NewPassword"
                                            DisplayPosition="RightSide" PrefixText="La contraseña es " StrengthIndicatorType="Text"
                                            MinimumNumericCharacters="1" MinimumSymbolCharacters="1" PreferredPasswordLength="8"
                                            RequiresUpperAndLowerCaseCharacters="true" TextStrengthDescriptions="Muy débil; Débil; Regular; Buena; Excelente"
                                            StrengthStyles="TextStrength MuyDebil; TextStrength Debil; TextStrength Regular;TextStrength Buena;TextStrength Excelente">
                                        </cc1:PasswordStrength>
                                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                            ValidationGroup="ChangeUserPasswordValidationGroup" ErrorMessage="Debe escribir una nueva contraseña">&nbsp;</asp:RequiredFieldValidator>
                                        <cc1:ValidatorCalloutExtender ID="NewPasswordValidator" runat="server" TargetControlID="NewPasswordRequired">
                                        </cc1:ValidatorCalloutExtender>
                                    </p>
                                    <p>
                                        <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="cuadro_texto Password" TextMode="Password"
                                            Width="230px" PlaceHolder="Confirma nueva cotraseña"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                            Display="Dynamic" ValidationGroup="ChangeUserPasswordValidationGroup" ErrorMessage="Debe confirmar su nueva contraseña">&nbsp;</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                            ControlToValidate="ConfirmNewPassword" Display="Dynamic" ValidationGroup="ChangeUserPasswordValidationGroup" ErrorMessage="Las contraseñas no coinciden">&nbsp;</asp:CompareValidator>
                                        <cc1:ValidatorCalloutExtender ID="ConfirmNewPasswordValidator" runat="server" TargetControlID="ConfirmNewPasswordRequired">
                                        </cc1:ValidatorCalloutExtender>
                                        <cc1:ValidatorCalloutExtender ID="NewPasswordCompareValidator" runat="server" TargetControlID="NewPasswordCompare">
                                        </cc1:ValidatorCalloutExtender>
                                    </p>
                                    <div id="cuerpo1">
                                        <table border="0" cellspacing="10" cellpadding="0" align="center">
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Regresar"
                                                        PostBackUrl="~/acceso/login.aspx">
                                                    <p id="boton">
                                                        Regresar&nbsp;&nbsp;&nbsp;<span id="triangulo">&nbsp;</span>
                                                    </p>
                                                    </asp:LinkButton>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                                        ValidationGroup="ChangeUserPasswordValidationGroup">
                                                    <p id="boton">
                                                        Enviar&nbsp;&nbsp;&nbsp;<span id="triangulo">&nbsp;</span>
                                                    </p>
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                        <p>
                                            <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                        </p>
                                    </div>
                                </div>
                            </ChangePasswordTemplate>
                            <MailDefinition>
                            </MailDefinition>
                        </asp:ChangePassword>
                    </asp:Panel>
                </div>
            </div>
            <div id="textoSlide">
                <div id="tituloSlide">
                    <%--<span class="grisTitulo">Rally en el Desierto.</span><br>
                    ¡Bienvenido!--%>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="general_foot" runat="server">
    <div id="pleca"></div>
</asp:Content>
