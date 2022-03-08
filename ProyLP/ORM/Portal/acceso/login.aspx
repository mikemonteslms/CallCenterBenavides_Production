<%@ page title="" language="C#" masterpagefile="~/general.master" autoeventwireup="true" codebehind="login.aspx.cs" inherits="Portal.acceso.login" %>

<%@ mastertype virtualpath="~/general.master" %>

<asp:content id="Content1" contentplaceholderid="general_head" runat="server">
    <link href="../css/estilos_acceso.css" rel="stylesheet" type="text/css">
</asp:content>
<asp:content id="Content2" contentplaceholderid="general_body" runat="server">
    <header>
        <div id="vw-header">
            <h1 id="logoLoyalty"><span>Loyalty World</span></h1>

        </div>
    </header>
    <div id="contenedor">
        <section id="slider">
            <div id="cuadro">
                <div id="cuerpo2">
                    <div class="subtitulo">Inicio de Sesión</div>
                    <br />
                    <p>Ingresa a tu cuenta y comienza a disfrutar los beneficios del programa.</p>
                    <br />
                    <asp:Panel ID="pnlBotonEnviar" runat="server" DefaultButton="LoginUser$LoginButton">
                        <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false"
                            OnAuthenticate="LoginUser_LoggedIn" OnLoginError="LoginUser_Error" RememberMeSet="false">
                            <LayoutTemplate>
                                <asp:ValidationSummary ID="LoginValidationSummary" runat="server" ValidationGroup="LoginValidationGroup"
                                    ShowMessageBox="true" ShowSummary="false" />
                                <p>
                                    <asp:TextBox ID="UserName" runat="server" CssClass="UserName" PlaceHolder="Usuario"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqUsuario" runat="server" ControlToValidate="UserName"
                                        ValidationGroup="LoginValidationGroup" ErrorMessage="Nombre de usuario obligatorio">&nbsp;</asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="valUsuario" runat="server" TargetControlID="reqUsuario">
                                    </cc1:ValidatorCalloutExtender>
                                </p>

                                <p>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="Password" PlaceHolder="Contraseña"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="Password"
                                        ValidationGroup="LoginValidationGroup" ErrorMessage="Password obligatorio">&nbsp;</asp:RequiredFieldValidator>
                                    <cc1:ValidatorCalloutExtender ID="valPassword" runat="server" TargetControlID="reqPassword">
                                    </cc1:ValidatorCalloutExtender>
                                </p>
                                <div id="cuerpo1">
                                    <div id="olvido"><a href="recupera.aspx">¿Olvidaste tu usuario o contraseña?</a></div>
                                    <asp:LinkButton ID="LoginButton" runat="server" CommandName="Login" ValidationGroup="LoginValidationGroup">
                                        <p id="boton">
                                            Enviar&nbsp;&nbsp;&nbsp;<span id="triangulo">&nbsp;</span>
                                        </p>
                                    </asp:LinkButton>
                                </div>
                            </LayoutTemplate>
                        </asp:Login>
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
</asp:content>
<asp:content id="Content3" contentplaceholderid="general_foot" runat="server">
    <div id="pleca"></div>
</asp:content>
