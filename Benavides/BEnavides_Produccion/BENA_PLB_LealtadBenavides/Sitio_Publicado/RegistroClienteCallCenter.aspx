<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroClienteCallCenter.aspx.cs"
    Inherits="Portal_Benavides.RegistroClienteCallCenter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="javascript" type="text/javascript">

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/MisEstilos.css" rel="stylesheet" type="text/css" />
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
        <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
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
                <br />
                <table style="width: 533px">
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="lblRegistro" runat="server" Text="Registro de Datos Personales" Font-Bold="True"
                                Font-Size="16pt" ForeColor="#004A99" Font-Names="Arial"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <asp:Label ID="Label1" runat="server" Text="Son obligatorios los datos marcados con "
                                ForeColor="Red" Font-Names="Arial" CssClass="Etiqueta"></asp:Label><font color="Red">(</font><font
                                    color="Red"><b>*</b>)</font>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">
                            <asp:Label ID="lblTarjeta" runat="server" Text="Tarjeta" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:TextBox ID="txtTarjeta" runat="server" MaxLength="19"></asp:TextBox>
                            <asp:Label ID="lblValidaTarjeta" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            <asp:Button ID="btnVerificar" runat="server" OnClick="btnVerificar_Click" Text="Validar Tarjeta"
                                CausesValidation="false" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="lblAP" runat="server" Text="Apellido Paterno" Font-Bold="True" ForeColor="#004A99"
                                Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaAP" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            <asp:TextBox ID="txtAP" runat="server" Width="68px" MaxLength="30" Enabled="False"></asp:TextBox>
                            <asp:Label ID="lblAM" runat="server" Text="Apellido Materno" ForeColor="#004A99"
                                Font-Names="Arial" Font-Size="9pt" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblValidaAM" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            <asp:TextBox ID="txtAM" runat="server" Width="68px" MaxLength="30" Enabled="False"></asp:TextBox>
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" ForeColor="#004A99" Font-Names="Arial"
                                Font-Size="9pt" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblValidaNombre" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
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
                            <asp:DropDownList ID="ddlAno" runat="server" AutoPostBack="True" Font-Size="8pt"
                                OnSelectedIndexChanged="ddlAno_SelectedIndexChanged" Enabled="False">
                            </asp:DropDownList>
                            <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#004A99"
                                Text="Mes"></asp:Label>
                            <asp:DropDownList ID="ddlMes" runat="server" AutoPostBack="True" Enabled="False"
                                Font-Size="8pt" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#004A99"
                                Text="Día"></asp:Label>
                            <asp:DropDownList ID="ddlDia" runat="server" Enabled="False" Font-Size="8pt">
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
                            <asp:Label ID="lblValidaCelular" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
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
                            <asp:Label ID="lblValidaCorreo" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            &nbsp;<asp:TextBox ID="txtCorreo" runat="server" MaxLength="80" Enabled="False" ValidationGroup="ValidaDatos"></asp:TextBox>&nbsp;
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCorreo"
                                ErrorMessage="El correo electrónico no es válido" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="ValidaDatos"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblDireccion" runat="server" Text="Direccion:" ForeColor="#777E7F"
                                Font-Names="Arial" Font-Size="10pt"></asp:Label><span style="color: #777e7f">(</span><font
                                    color="#E42313"><b>*</b></font><font color="#777E7F">)</font>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="lblCalle" runat="server" Text="Calle" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaCalle" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            <asp:TextBox ID="txtCalle" runat="server" MaxLength="250" Width="125px" Enabled="False"></asp:TextBox>
                            <asp:Label ID="lblExterior" runat="server" Text="Ext." ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaExterior" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
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
                            <asp:Label ID="lblValidaCP" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            <asp:TextBox ID="txtCP" runat="server" Width="40px" MaxLength="5" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <br />
                            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/cancelar-btn.png"
                                OnClick="btnCancelar_Click" CausesValidation="false" />
                            &nbsp; &nbsp;&nbsp;
                            <asp:ImageButton ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" ImageUrl="~/Imagenes_Benavides/botones/registrar-btn.png"
                                Enabled="False" ValidationGroup="ValidaDatos" />
                            <div id="dvCuestionarioCC" runat="server" visible="false">
                                <asp:Panel ID="pnlCuestionarioCC" runat="server">
                                    <table style="background-image: url(Imagenes_Benavides/fondoConfirmaContraseña.jpg);
                                        width: 550px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblMsnMP" runat="server" Text="Sr./Sra." Font-Names="Arial" ForeColor="#777E7F"
                                                    Font-Size="12px"></asp:Label>
                                                &nbsp
                                                <asp:Label ID="lblNombreMensaje" runat="server" Font-Names="Arial" ForeColor="#004A99"
                                                    Font-Size="12px"></asp:Label>
                                                &nbsp
                                                <asp:Label ID="Label3" runat="server" Text="a continuación le haré 5 preguntas que nos ayudarán a conocerlo/a mejor para poder ofrecerle más y mejores ofertas."
                                                    Font-Names="Arial" ForeColor="#777E7F" Font-Size="12px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: text-bottom">
                                                <br />
                                                <asp:Label ID="Label5" runat="server" Text="¿Está de acuerdo?" Font-Names="Arial"
                                                    ForeColor="#777E7F" Font-Size="12px"></asp:Label><br />
                                                <asp:LinkButton ID="lnkAceptar" runat="server" Text="Aceptar" ForeColor="#004A99"
                                                    CssClass="Etiqueta" Font-Bold="True" Font-Size="14px" OnClick="lnkAceptar_Click"></asp:LinkButton>
                                                &nbsp &nbsp &nbsp &nbsp &nbsp
                                                <asp:LinkButton ID="lnkCancelar" runat="server" Text="Cancelar" ForeColor="#004A99"
                                                    CssClass="Etiqueta" Font-Bold="True" Font-Size="14px" OnClick="lnkCancelar_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <cc1:ModalPopupExtender ID="mpeCuestionarioCC" runat="server" PopupControlID="pnlCuestionarioCC"
                                    TargetControlID="btnRegistrar" DynamicServicePath="" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                            </div>
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
