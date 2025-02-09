﻿<%@ Page Language="C#" Title="Registrar un inicio de sesión externo" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterExternalLogin.aspx.cs" Inherits="ORMOperacion.Account.RegisterExternalLogin" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hgroup class="title">
        <h1>Registrar con su cuenta <%: ProviderDisplayName %></h1>
        <h2><%: ProviderUserName %>.</h2>
    </hgroup>

    
    <asp:Label runat="server" ID="providerMessage" CssClass="field-validation-error" />
    

    <asp:PlaceHolder runat="server" ID="userNameForm">
        <fieldset>
            <legend>Formulario de asociación</legend>
            <p>
                Se ha autenticado con <strong><%: ProviderDisplayName %></strong> como
                <strong><%: ProviderUserName %></strong>. Especifique un nombre de usuario a continuación para el sitio actual
                y haga clic en el botón Iniciar sesión.
            </p>
            <ol>
                <li class="email">
                    <asp:Label runat="server" AssociatedControlID="userName">Nombre de usuario</asp:Label>
                    <asp:TextBox runat="server" ID="userName" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="userName"
                        Display="Dynamic" ErrorMessage="El nombre de usuario es obligatorio" ValidationGroup="NewUser" />
                    
                    <asp:Label runat="server" ID="userNameMessage" CssClass="field-validation-error" />
                    
                </li>
            </ol>
            <asp:Button runat="server" Text="Iniciar sesión" ValidationGroup="NewUser" OnClick="logIn_Click" />
            <asp:Button runat="server" Text="Cancelar" CausesValidation="false" OnClick="cancel_Click" />
        </fieldset>
    </asp:PlaceHolder>
</asp:Content>
