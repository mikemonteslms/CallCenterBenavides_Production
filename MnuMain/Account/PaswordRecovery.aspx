<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PaswordRecovery.aspx.cs" Inherits="MnuMain.Account.PaswordRecovery" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1">
   
    <center>
        <div style='width: 1010px; height: 756px; background-image: url("../Imagenes/acceso-registro-header.jpg"); background-repeat: no-repeat;'>
            <div style='width: 1010px; height: 756px; background-image: url("../Imagenes/acceso-registro-header.jpg"); background-repeat: no-repeat;'>
                <section id="loginForm">
                 <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                    <div class="form-horizontal">
                       <h4>Recuperar contraseña.</h4>
                       <hr />
                         <div>   
                             <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">                
                                 <TitleTextStyle />
                                 <SuccessTemplate>
                                     <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                                         <tr>
                                             <td>
                                                 <table cellpadding="0">
                                                     <tr>
                                                         <td>Se le ha enviado la contraseña.<br />Para iniciar sesión da click <a href="Login.aspx">aquí.</a></td>
                                                     </tr>
                                                 </table>
                                             </td>
                                         </tr>
                                     </table>
                                 </SuccessTemplate>
                                 <UserNameTemplate>
                                     <table cellpadding="4" cellspacing="0" style="border-collapse:collapse;">
                                         <tr>
                                             <td>
                                                 <table cellpadding="0">
                                                     <tr>
                                                         <td align="center" colspan="2">¿Olvidó su contraseña?</td>
                                                     </tr>
                                                     <tr>
                                                         <td align="center" colspan="2">&nbsp;</td>
                                                     </tr>
                                                     <tr>
                                                         <td align="center" colspan="2" style="">Escriba su Nombre de usuario para recibir su contraseña.</td>
                                                     </tr>
                                                     <tr>
                                                         <td align="right">
                                                             <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                                                         </td>
                                                         <td>
                                                             <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                             <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td align="center" colspan="2" style="color:Red;">
                                                             <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                         </td>
                                                     </tr>
                                                     <tr>
                                                         <td align="right" colspan="2">
                                                             <asp:Button ID="SubmitButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CommandName="Submit" Font-Names="Verdana" ForeColor="#284775" Text="Enviar" ValidationGroup="PasswordRecovery1" />
                                                         </td>
                                                     </tr>
                                                 </table>
                                             </td>
                                         </tr>
                                     </table>
                                 </UserNameTemplate>
                             </asp:PasswordRecovery>
                         </div>
                  </div>
                </section>         
            </div>
        </div>
    </center>
       
</asp:Content>
