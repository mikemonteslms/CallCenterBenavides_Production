<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDireccion_MX.ascx.cs" Inherits="ORMOperacion.controles.ucDireccion_MX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table border="0" cellpadding="0" cellspacing="0" width="900px">
    <tr align="left" class="texto11">
        <td colspan="3">
            <table border="0" cellpadding="0" cellspacing="0" width="616px">
                <tr>
                    <td width="233px">Calle
                    </td>
                    <td width="150px">N&uacute;mero Exterior
                    </td>
                    <td width="233px">N&uacute;mero Interior
                    </td>
                </tr>
                <tr>
                    <tr align="left" class="texto11">
                        <td valign="top">
                            <span class="cuadro_texto1">
                                <asp:TextBox ID="txtCalle" runat="server" CssClass="texto11 sin_borde" Width="300px"></asp:TextBox>
                            </span>
                            <asp:RequiredFieldValidator ID="reqCalle" runat="server" ErrorMessage="Dirección requerida"
                                ControlToValidate="txtCalle" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="valCalle" runat="server" TargetControlID="reqCalle">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                        <td valign="top">
                            <span class="cuadro_texto2">
                                <asp:TextBox ID="txtNumeroExterior" runat="server" CssClass="texto11 sin_borde" Width="140px"></asp:TextBox>
                            </span>
                            <asp:RequiredFieldValidator ID="reqNumeroExterior" runat="server" ErrorMessage="Piso requerido"
                                ControlToValidate="txtNumeroExterior" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                            <cc1:ValidatorCalloutExtender ID="valNumeroExterior" runat="server" TargetControlID="reqNumeroExterior">
                            </cc1:ValidatorCalloutExtender>
                        </td>
                        <td valign="top">
                            <span class="cuadro_texto2">
                                <asp:TextBox ID="txtNumeroInterior" runat="server" CssClass="texto11 sin_borde" Width="140px"></asp:TextBox>
                            </span>
                        </td>
                    </tr>
                </tr>
            </table>
        </td>
    </tr>
    <tr align="left" class="texto11">
        <td colspan="2">
            <table border="0" cellpadding="0" cellspacing="0" width="640px">
                <tr>
                    <td width="320px">Estado
                    </td>
                    <td width="320px">Delegaci&oacute;n/Municipio
                    </td>
                </tr>
                <tr align="left" class="texto11">
                    <td>
                        <span class="cuadro_texto1">
                            <asp:DropDownList ID="ddlEstado" runat="server" AppendDataBoundItems="true" DataValueField="id"
                                DataTextField="descripcion_larga" AutoPostBack="True" Width="305px" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
                                CssClass="texto11 sin_borde">
                            </asp:DropDownList>
                        </span>
                        <asp:RequiredFieldValidator ID="reqEstado" runat="server" InitialValue="0" ErrorMessage="Provincia requerida"
                            ControlToValidate="ddlEstado" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="valEstdo" runat="server" TargetControlID="reqEstado">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                    <td>
                        <span class="cuadro_texto1">
                            <asp:DropDownList ID="ddlMunicipio" runat="server" AppendDataBoundItems="true" DataValueField="id"
                                DataTextField="descripcion_larga" AutoPostBack="True" Width="305px" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged"
                                CssClass="texto11 sin_borde">
                            </asp:DropDownList>
                        </span>
                        <asp:RequiredFieldValidator ID="reqMunicipio" runat="server" ErrorMessage="Ciudad requerida"
                            ControlToValidate="ddlMunicipio" InitialValue="0" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="valMunicipio" runat="server" TargetControlID="reqMunicipio">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table border="0" cellpadding="0" cellspacing="0" width="650px">
                <tr align="left" class="texto11">
                    <td width="300px">Colonia
                    </td>
                    <td width="120px"></td>
                    <td width="100px">C&oacute;digo postal</td>
                </tr>
                <tr align="left" class="texto11">
                    <asp:MultiView ID="mvColonia" runat="server" ActiveViewIndex="0">
                        <asp:View ID="vColonia" runat="server">
                            <td>
                                <span class="cuadro_texto1">
                                    <asp:DropDownList ID="ddlAsentamiento" runat="server" AppendDataBoundItems="true"
                                        DataValueField="id" DataTextField="descripcion_larga" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlAsentamiento_SelectedIndexChanged" CssClass="texto11 sin_borde" Width="305px">
                                    </asp:DropDownList>
                                </span>
                                <asp:RequiredFieldValidator ID="reqAsentamiento" runat="server" ErrorMessage="Localidad requerida"
                                    ControlToValidate="ddlAsentamiento" InitialValue="0" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="valAsentamiento" runat="server" TargetControlID="reqAsentamiento">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                            <td valign="top">
                                <asp:Button ID="btnOtraColonia" runat="server" Text="Otra" OnClick="btnOtraColonia_Click"
                                    CausesValidation="false" CssClass="boton negrita texto11" />
                            </td>
                        </asp:View>
                        <asp:View ID="vOtraColonia" runat="server">
                            <td>
                                <span class="cuadro_texto1">
                                    <asp:TextBox ID="txtOtraColonia" runat="server" Width="130px" CssClass="texto11 sin_borde"></asp:TextBox>
                                </span>
                                <asp:RequiredFieldValidator ID="reqOtraColonia" runat="server" ErrorMessage="Colonia requerida"
                                    ControlToValidate="txtOtraColonia" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="valOtraColonia" runat="server" TargetControlID="reqOtraColonia">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                            <td valign="top">
                                <asp:Button ID="btnRegresarColonia" runat="server" Text="Regresar" OnClick="btnRegresarColonia_Click"
                                    CausesValidation="false" CssClass="boton negrita texto11" />
                            </td>
                        </asp:View>
                    </asp:MultiView>
                    <td>
                        <span class="cuadro_texto3_1">
                            <asp:TextBox ID="txtCodigoPostal" runat="server" MaxLength="8" CssClass="texto11 sin_borde"
                                Width="70px"></asp:TextBox>
                        </span>
                        <cc1:FilteredTextBoxExtender ID="filCP" runat="server" TargetControlID="txtCodigoPostal"
                            FilterMode="ValidChars" FilterType="Numbers">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="reqCP" runat="server" ErrorMessage="Código postal requerido"
                            ControlToValidate="txtCodigoPostal" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="valCP" runat="server" TargetControlID="reqCP">
                        </cc1:ValidatorCalloutExtender>
                    </td>
                    <td valign="top">
                        <asp:Button ID="btnBuscaXPC" runat="server" Text="Buscar" OnClick="btnBuscaXPC_Click"
                            CausesValidation="false" CssClass="boton negrita texto11" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>

</table>
