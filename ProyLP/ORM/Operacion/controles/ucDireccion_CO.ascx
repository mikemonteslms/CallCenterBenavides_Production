<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDireccion_CO.ascx.cs" Inherits="ORMOperacion.controles.ucDireccion_CO" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<tr>
    <td colspan="2">
        Direcci&oacute;n
    </td>
    <td>
        Barrio
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
        <span class="cuadro_texto1">
            <asp:TextBox ID="txtBarrio" runat="server" Width="300px"></asp:TextBox>
        </span>
        <asp:RequiredFieldValidator ID="reqBarrio" runat="server" ErrorMessage="Barrio requerido"
            ControlToValidate="txtBarrio" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
        <cc1:ValidatorCalloutExtender ID="valBarrio" runat="server" TargetControlID="reqBarrio">
        </cc1:ValidatorCalloutExtender>
    </td>
</tr>
<tr valign="top">
    <td colspan="2">
        <label>
            Departamento:</label>
    </td>
    <td>
        <label>
            Ciudad / Municipio:
        </label>
    </td>
</tr>
<tr valign="top">
    <td colspan="2">
        <asp:DropDownList ID="ddlEstado" runat="server" AppendDataBoundItems="true" DataValueField="id"
            DataTextField="descripcion_larga" AutoPostBack="True" Width="319px" Height="25px"
            OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" CssClass="cuadro_texto1">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="reqEstado" runat="server" InitialValue="0" ErrorMessage="Departamento requerido"
            ControlToValidate="ddlEstado" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
        <cc1:ValidatorCalloutExtender ID="valEstdo" runat="server" TargetControlID="reqEstado">
        </cc1:ValidatorCalloutExtender>
    </td>
    <td>
        <asp:DropDownList ID="ddlMunicipio" runat="server" AppendDataBoundItems="true" DataValueField="id"
            DataTextField="descripcion_larga" AutoPostBack="True" Width="319px" Height="25px"
            OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged" CssClass="cuadro_texto1">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="reqMunicipio" runat="server" ErrorMessage="Ciudad / Municipio requerido"
            ControlToValidate="ddlMunicipio" InitialValue="0" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
        <cc1:ValidatorCalloutExtender ID="valMunicipio" runat="server" TargetControlID="reqMunicipio">
        </cc1:ValidatorCalloutExtender>
    </td>
</tr>
