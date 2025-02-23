﻿<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MnuMain.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1">
    <center>
        <div style='width: 1010px; height: 756px; background-image: url("../Imagenes/acceso-registro-header.jpg"); background-repeat: no-repeat;'>
            <section id="loginForm">
                <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                <div class="form-horizontal">
                    <h4>Utilice una cuenta local para iniciar sesión.</h4>
                    <hr />
                      <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserName"  CssClass="col-md-2 control-label">Nombre de usuario</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                CssClass="text-danger" ErrorMessage="El campo de nombre de usuario es obligatorio." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Contraseña</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">                                
                            <div class="checkbox">
                                <asp:HyperLink ID="hplRecuperaPass" runat="server" Text="¿No recuerdo mi contraseña?" NavigateUrl="~/Account/PaswordRecovery.aspx"></asp:HyperLink>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Iniciar sesión" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                <p>
                    <%--<asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Registrarse</asp:HyperLink>
                    si no tiene una cuenta local.--%>
                </p>
            </section>
        </div>

        <%--<div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>--%>
    </center>
       
</asp:Content>
