<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs"
    Inherits="Portal_Benavides.RegistroCliente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="javascript" type="text/javascript">

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-43180890-1', 'beneficiointeligente.com.mx');
        ga('send', 'pageview');
    </script>
    <title>Registro de Cliente</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="fondo" style="background-image: url(Imagenes_Benavides/registro-acceso-fondo.jpg);
            width: 1010px; height: 756px; background-repeat: no-repeat;">
            <center>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <table style="width: 547px">
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="lblRegistro" runat="server" Text="Registro de Datos Personales" Font-Bold="True"
                                Font-Size="16pt" ForeColor="#004A99" Font-Names="Arial"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <asp:Label ID="Label1" runat="server" Text="Son obligatorios los datos marcados con "
                                ForeColor="Red" Font-Names="Arial" CssClass="Etiqueta" Font-Underline="False"></asp:Label><font
                                    color="Red">(</font><font color="#E42313"><b>*</b></font><font color="Red">)</font>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <asp:Label ID="lblTarjeta" runat="server" Text="Tarjeta" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:TextBox ID="txtTarjeta" runat="server" MaxLength="19"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTarjeta" ValidationGroup="Valida">*</asp:RequiredFieldValidator>--%>
                            <asp:Label ID="lblValidaTarjeta" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            <asp:Button ID="btnVerificar" runat="server" OnClick="btnVerificar_Click" Text="Validar Tarjeta"
                                CausesValidation="false" />
                            <asp:Label ID="lblClicValida" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="lblAP" runat="server" Text="Apellido Paterno" Font-Bold="True" ForeColor="#004A99"
                                Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAP" ValidationGroup="Registra">*</asp:RequiredFieldValidator>--%>
                            <asp:Label ID="lblValidaAP" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <asp:TextBox ID="txtAP" runat="server" Width="68px" MaxLength="30" Enabled="False"></asp:TextBox>
                            <asp:Label ID="lblAM" runat="server" Text="Apellido Materno" ForeColor="#004A99"
                                Font-Names="Arial" Font-Size="9pt" Font-Bold="True"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAM" ValidationGroup="Registra">*</asp:RequiredFieldValidator>--%>
                            <asp:Label ID="lblValidaAM" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <asp:TextBox ID="txtAM" runat="server" Width="68px" MaxLength="30" Enabled="False"></asp:TextBox>
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" ForeColor="#004A99" Font-Names="Arial"
                                Font-Size="9pt" Font-Bold="True"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre" ValidationGroup="Registra">*</asp:RequiredFieldValidator>--%>
                            <asp:Label ID="lblValidaNombre" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server" Width="68px" MaxLength="30" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="Label2" runat="server" Text="Fecha de Nacimiento" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaFecha" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#004A99"
                                Text="Año"></asp:Label>
                            <asp:DropDownList ID="ddlAno" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged"
                                Enabled="False">
                            </asp:DropDownList>
                            <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#004A99"
                                Text="Mes"></asp:Label>
                            <asp:DropDownList ID="ddlMes" runat="server" AutoPostBack="True" Enabled="False"
                                OnSelectedIndexChanged="ddlMes_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#004A99"
                                Text="Día"></asp:Label>
                            <asp:DropDownList ID="ddlDia" runat="server" Enabled="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" Width="80px" MaxLength="10" Enabled="False"></asp:TextBox>
                            <asp:Label ID="lblCelular" runat="server" Text="Teléfono Celular" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCelular">*</asp:RequiredFieldValidator>--%>
                            <asp:Label ID="lblValidaCelular" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <asp:TextBox ID="txtCelular" runat="server" MaxLength="10" Width="80px" Enabled="False"></asp:TextBox>
                            <asp:Label ID="lblgenero" runat="server" CssClass="Etiqueta" Font-Bold="True" Text="Genero"
                                Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaGenero" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <asp:DropDownList ID="ddlGenero" runat="server" Enabled="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="lblCorreo" runat="server" Text="Correo Electronico:" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCorreo">*</asp:RequiredFieldValidator>--%>
                            <asp:Label ID="lblValidaCorreo" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            &nbsp;<asp:TextBox ID="txtCorreo" runat="server" MaxLength="80" Enabled="False" ValidationGroup="Registra"
                                OnTextChanged="txtCorreo_TextChanged" AutoPostBack="True"></asp:TextBox>&nbsp;
                            <asp:RegularExpressionValidator ID="ValidatorMail" runat="server" ControlToValidate="txtCorreo"
                                ErrorMessage="Correo electrónico Inválido" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                CssClass="Etiqueta" Enabled="False" ValidationGroup="Registra"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="lblConfirmaCorreo" runat="server" Text="Confirma Correo Electronico:"
                                ForeColor="#004A99" CssClass="Etiqueta" Font-Bold="true" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaConfirmaCorreo" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            &nbsp;<asp:TextBox ID="txtConfirmaCorreo" runat="server" MaxLength="80" Enabled="False"
                                ValidationGroup="Registra"></asp:TextBox>&nbsp;
                            <asp:CompareValidator ID="ValidatorComparaMail" runat="server" ErrorMessage="Confirmación Incorrecta"
                                CssClass="Etiqueta" Enabled="False" ControlToCompare="txtCorreo" ControlToValidate="txtConfirmaCorreo"
                                Display="Dynamic" ValidationGroup="Registra"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblDireccion" runat="server" Text="Direccion:" ForeColor="#777E7F"
                                Font-Names="Arial" Font-Size="10pt"></asp:Label>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="lblCalle" runat="server" Text="Calle" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaCalle" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCalle">*</asp:RequiredFieldValidator>--%>
                            <asp:TextBox ID="txtCalle" runat="server" MaxLength="250" Width="125px" Enabled="False"></asp:TextBox>
                            <asp:Label ID="lblExterior" runat="server" Text="Ext." ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaExterior" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNumExterior">*</asp:RequiredFieldValidator>--%>
                            <asp:TextBox ID="txtNumExterior" runat="server" Width="30px" MaxLength="10" Enabled="False"></asp:TextBox>
                            <asp:Label ID="lblInterior" runat="server" Text="Num. Int" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:TextBox ID="txtNumInterior" runat="server" Width="30px" MaxLength="10" Enabled="False"></asp:TextBox>
                            &nbsp;
                            <asp:Label ID="lblEstado" runat="server" Text="Estado" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaEstado" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
                                Width="110px" Enabled="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="lblMunicipio" runat="server" Text="Municipio" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaMunicipio" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <asp:DropDownList ID="ddlMunicipio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged"
                                Width="130px" Enabled="False">
                            </asp:DropDownList>
                            <asp:Label ID="lblColonia" runat="server" Text="Colonia" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaColonia" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <asp:DropDownList ID="ddlColonia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlColonia_SelectedIndexChanged"
                                Width="170px" Enabled="False">
                            </asp:DropDownList>
                            <asp:Label ID="lblCP" runat="server" Text="C.P." ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtCP">*</asp:RequiredFieldValidator>--%>
                            <asp:TextBox ID="txtCP" runat="server" Width="40px" MaxLength="5" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtContraseña">*</asp:RequiredFieldValidator>--%>
                            <asp:Label ID="lblValidaContraseña" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            <asp:TextBox ID="txtContraseña" runat="server" Width="135px" MaxLength="20" TextMode="Password"
                                Enabled="False"></asp:TextBox>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblConfirmaContra" runat="server" Text="Confirmar Contraseña" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtConfirmaContra">*</asp:RequiredFieldValidator>--%>
                            <asp:Label ID="lblValidaConfirmaContraseña" runat="server" ForeColor="Red" Text="*"
                                Visible="False"></asp:Label>
                            <asp:TextBox ID="txtConfirmaContra" runat="server" Width="135px" MaxLength="20" TextMode="Password"
                                Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <br />
                            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/cancelar-btn.png"
                                OnClick="btnCancelar_Click" CausesValidation="false" />
                            &nbsp; &nbsp;&nbsp;
                            <asp:ImageButton ID="btnRegistrar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/registrar-btn.png"
                                OnClick="btnRegistrar_Click" ValidationGroup="Registra" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <table width="1010">
                    <tr>
                        <td style="width: 20px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20px">
                        </td>
                        <td align="left">
                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Target="_blank" Font-Names="Arial"
                                Font-Size="8pt" ForeColor="#004A99" NavigateUrl="~/Terminos.aspx">Terminos y Condiciones</asp:HyperLink>
                            <asp:Label ID="Label4" runat="server" Text="|" Font-Bold="True" ForeColor="#004A99"></asp:Label>
                            <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Target="_blank" Font-Names="Arial"
                                Font-Size="8pt" ForeColor="#004A99" NavigateUrl="~/AvisoPrivacidad.aspx">Aviso de Privacidad</asp:HyperLink>
                        </td>
                        <td style="width: 106px" align="right">
                            <img src="Imagenes_Benavides/benavides.png" />
                        </td>
                        <td style="width: 60px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="3" align="left">
                            <asp:Label ID="Label6" runat="server" Font-Size="8pt" ForeColor="Silver" Text="Copyright 2013 Farmacias Benavides. Todos los derechos reservados"></asp:Label>
                        </td>
                    </tr>
                </table>
            </center>
        </div>
        </form>
    </center>
</body>
</html>
