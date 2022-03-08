<%@ Page Title="" Language="C#" MasterPageFile="~/general.master" AutoEventWireup="true" CodeBehind="recupera.aspx.cs" Inherits="Portal.recupera.login" %>

<%@ MasterType VirtualPath="~/general.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="general_head" runat="server">
    <link href="../css/estilos_acceso.css" rel="stylesheet" type="text/css">
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
                    <div class="subtitulo">Recupera tu contraseña</div>
                    <br />
                    <p>Ingresa tu usuario y correo electónico.</p>
                    <br />
                    <asp:Panel ID="pnlBotonEnviar" runat="server" DefaultButton="btnEnviar">
                        <asp:ValidationSummary ID="RecuperaPasswordValidationSummary" runat="server" ValidationGroup="RecuperaPasswordValidationGroup"
                            ShowMessageBox="true" ShowSummary="false" />
                        <div>
                            <p>
                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="UserName" PlaceHolder="usuario"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqUsuario" runat="server" ControlToValidate="txtUsuario"
                                    ValidationGroup="RecuperaPasswordValidationGroup" ErrorMessage="Nombre de usuario obligatorio">&nbsp;</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="valUsuario" runat="server" TargetControlID="reqUsuario">
                                </cc1:ValidatorCalloutExtender>
                            </p>

                            <p>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="Email" PlaceHolder="e-mail"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqEmail" runat="server" ControlToValidate="txtEmail"
                                    ValidationGroup="RecuperaPasswordValidationGroup" ErrorMessage="E-mail obligatorio">&nbsp;</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="valEmail" runat="server" TargetControlID="reqEmail">
                                </cc1:ValidatorCalloutExtender>
                            </p>
                            <div id="cuerpo1">
                                <table border="0" cellspacing="10" cellpadding="0" align="center">
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="btnCancelar" runat="server" CausesValidation="False" PostBackUrl="~/acceso/login.aspx" Text="Regresar">
                                                <p id="boton">
                                                    Regresar&nbsp;&nbsp;&nbsp;<span id="triangulo">&nbsp;</span>
                                                </p>
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="btnEnviar" runat="server" CommandName="Login" OnClick="btnEnviar_Click" ValidationGroup="RecuperaPasswordValidationGroup">
                                                <p id="boton">
                                                    Enviar&nbsp;&nbsp;&nbsp;<span id="triangulo">&nbsp;</span>
                                                </p>
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div id="textoSlide">
                <div id="tituloSlide">
                    <span class="grisTitulo">Rally en el Desierto.</span><br>
                    ¡Bienvenido!
                </div>
            </div>
        </section>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="general_foot" runat="server">
    <div id="pleca"></div>
</asp:Content>
