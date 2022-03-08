<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDireccion_BR.ascx.cs" Inherits="ORMOperacion.controles.ucDireccion_BR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<tr>
    <td colspan="2">
        Endereço
    </td>
    <td>
        N&uacute;mero
    </td>
    <td>
        Complemento
    </td>
</tr>
<tr valign="top">
    <td colspan="2">
        <span class="cuadro_texto1">
            <asp:TextBox ID="txtCalle" runat="server" Width="300px"></asp:TextBox>
        </span>
        <asp:RequiredFieldValidator ID="reqCalle" runat="server" ErrorMessage="Dirección requerida"
            ControlToValidate="txtCalle" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
        <cc1:ValidatorCalloutExtender ID="valCalle" runat="server" TargetControlID="reqCalle">
        </cc1:ValidatorCalloutExtender>
    </td>
    <td>
        <span class="cuadro_texto2">
            <asp:TextBox ID="txtNumeroExterior" runat="server" Width="140px"></asp:TextBox>
        </span>
        <asp:RequiredFieldValidator ID="reqNumeroExterior" runat="server" ErrorMessage="Piso requerido"
            ControlToValidate="txtNumeroExterior" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
        <cc1:ValidatorCalloutExtender ID="valNumeroExterior" runat="server" TargetControlID="reqNumeroExterior">
        </cc1:ValidatorCalloutExtender>
    </td>
    <td>
        <span class="cuadro_texto2">
            <asp:TextBox ID="txtNumeroInterior" runat="server" Width="140px"></asp:TextBox>
        </span>
    </td>
</tr>
<tr valign="top">
    <td colspan="2">
        <label>
            Estado:</label>
    </td>
    <td colspan="2">
        <label>
            Cidade:</label>
    </td>
</tr>
<tr valign="top">
    <td colspan="2">
        <asp:DropDownList ID="ddlEstado" runat="server" AppendDataBoundItems="true" DataValueField="id"
            DataTextField="descripcion_larga" AutoPostBack="True" Width="319px" Height="25px" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
            CssClass="cuadro_texto1">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="reqEstado" runat="server" InitialValue="0" ErrorMessage="Provincia requerida"
            ControlToValidate="ddlEstado" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
        <cc1:ValidatorCalloutExtender ID="valEstdo" runat="server" TargetControlID="reqEstado">
        </cc1:ValidatorCalloutExtender>
    </td>
    <td colspan="2">
        <asp:DropDownList ID="ddlMunicipio" runat="server" AppendDataBoundItems="true" DataValueField="id"
            DataTextField="descripcion_larga" AutoPostBack="True" Width="319px" Height="25px" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged"
            CssClass="cuadro_texto1">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="reqMunicipio" runat="server" ErrorMessage="Ciudad requerida"
            ControlToValidate="ddlMunicipio" InitialValue="0" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
        <cc1:ValidatorCalloutExtender ID="valMunicipio" runat="server" TargetControlID="reqMunicipio">
        </cc1:ValidatorCalloutExtender>
    </td>
</tr>
<tr>
    <td colspan="2">
        Bairro
    </td>
    <td colspan="2">
        CEP
    </td>
</tr>
<tr valign="top">
    <asp:MultiView ID="mvColonia" runat="server" ActiveViewIndex="0">
        <asp:View ID="vColonia" runat="server">
            <td>
                <asp:DropDownList ID="ddlAsentamiento" runat="server" AppendDataBoundItems="true"
                    DataValueField="id" DataTextField="descripcion_larga" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlAsentamiento_SelectedIndexChanged" CssClass="cuadro_texto2" Width="155px" Height="25px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="reqAsentamiento" runat="server" ErrorMessage="Localidad requerida"
                    ControlToValidate="ddlAsentamiento" InitialValue="0" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                <cc1:ValidatorCalloutExtender ID="valAsentamiento" runat="server" TargetControlID="reqAsentamiento">
                </cc1:ValidatorCalloutExtender>
            </td>
            <td>
                <asp:Button ID="btnOtraColonia" runat="server" Text="Otra" OnClick="btnOtraColonia_Click"
                    CausesValidation="false" CssClass="boton negrita" />
            </td>
        </asp:View>
        <asp:View ID="vOtraColonia" runat="server">
            <td>
                <span class="cuadro_texto2">
                    <asp:TextBox ID="txtOtraColonia" runat="server" Width="140px"></asp:TextBox>
                </span>
                <asp:RequiredFieldValidator ID="reqOtraColonia" runat="server" ErrorMessage="Colonia requerida"
                    ControlToValidate="txtOtraColonia" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                <cc1:ValidatorCalloutExtender ID="valOtraColonia" runat="server" TargetControlID="reqOtraColonia">
                </cc1:ValidatorCalloutExtender>
            </td>
            <td>
                <asp:Button ID="btnRegresarColonia" runat="server" Text="Regresar" OnClick="btnRegresarColonia_Click"
                    CausesValidation="false" CssClass="boton negrita" />
            </td>
        </asp:View>
    </asp:MultiView>
    <td>
        <span class="cuadro_texto2">
            <asp:TextBox ID="txtCodigoPostal" runat="server" MaxLength="10" CssClass="fondo_blanco1"
                Width="140px"></asp:TextBox>
        </span>
        <cc1:FilteredTextBoxExtender ID="filCP" runat="server" TargetControlID="txtCodigoPostal"
            FilterMode="ValidChars" FilterType="Numbers">
        </cc1:FilteredTextBoxExtender>
        <asp:RequiredFieldValidator ID="reqCP" runat="server" ErrorMessage="Código postal requerido"
            ControlToValidate="txtCodigoPostal" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
        <cc1:ValidatorCalloutExtender ID="valCP" runat="server" TargetControlID="reqCP">
        </cc1:ValidatorCalloutExtender>
    </td>
    <td>
        <asp:Button ID="btnBuscaXPC" runat="server" Text="Buscar" OnClick="btnBuscaXPC_Click"
            CausesValidation="false" CssClass="boton negrita" />
    </td>
</tr>

