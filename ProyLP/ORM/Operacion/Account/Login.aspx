<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ORMOperacion.Account.Login" %>

<%--<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
            OnAuthenticate="LoginUser_LoggedIn" OnLoginError="LoginUser_Error" RememberMeSet="false">
            <LayoutTemplate>
                <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="LoginUserValidationGroup" ShowMessageBox="true" ShowSummary="false" />  
                    <div class="logo_superior"></div>              
                    <div id="rounded-box5">                
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 590px; padding: 20px; margin: 20px; text-align: center;">
                            <tr align="center" >
                                <td colspan="4" class="texto18 negrita">BIENVENIDO AL PROGRAMA <br />
                                <div class="logo" ></div>
                                 OPERACI&Oacute;N
                                </td>
                            </tr>
                            <tr align="center" style="height: 30px;">
                                <td colspan="2" class="tablaLogin">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="texto18 negrita">USUARIO</asp:Label>
                                </td>
                                <td colspan="2" class="tablaLogin">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="texto18 negrita">CONTRASEÑA</asp:Label>
                                </td>
                            </tr>
                            <tr align="center" style="height: 40px;">
                                <td align="center">
                                        <telerik:RadTextBox ID="UserName" runat="server" CssClass="texto18" Width="230px"></telerik:RadTextBox>
                                    </td>
                                <td align="left" width="20px">
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="El nombre de usuario es requerido." ToolTip="El nombre de usuario es requerido."
                                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                                <td align="center">
                                        <telerik:RadTextBox ID="Password" runat="server" CssClass="texto18" TextMode="Password"
                                            Width="230px"></telerik:RadTextBox>
                                    </td>
                                <td align="left" width="20px">
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="La contraseña es requerida." ToolTip="La contraseña es requerida."
                                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 40px;" align="right">
                                <td align="right" colspan="3">
                                    <telerik:RadButton ID="LoginButton" runat="server" CommandName="Login" Text="ENTRAR" CssClass="negrita"
                                        ValidationGroup="LoginUserValidationGroup" />
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr align="center" >
                                <td class="texto14 tablaLogin" colspan="2"><%--¿ES SU PRIMER ACCESO?--%>
                                <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false"
                                    CssClass="naranja" Font-Italic="true" Visible="false">ingrese aquí</asp:HyperLink>.
                                </td>
                                <td class="texto14 tablaLogin" colspan="2">
                                    <asp:LinkButton ID="PasswordRecovery" runat="server" Enabled="false" Visible="false">RECUPERAR CONTRASEÑA</asp:LinkButton>
                                </td>
                            </tr>
                            <tr >
                                <td colspan="4" class="naranja">
                                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </div>
            </LayoutTemplate>
        </asp:Login>
    </center>
</asp:Content>
