<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroCliente_PrimeraVez.aspx.cs"
    Inherits="Portal_Benavides.RegistroCliente_PrimeraVez" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="javascript" type="text/javascript">

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
   <script>
       (function (i, s, o, g, r, a, m) {
           i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
               (i[r].q = i[r].q || []).push(arguments)
           }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
       })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

       ga('create', 'UA-73644905-1', 'auto');
       ga('send', 'pageview');

</script>
    <title>Registro de Cliente</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
    <center>
        <form id="form2" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <div id="Div1" style="background-image: url(Imagenes_Benavides/registro-acceso-fondo.jpg);
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
                <table style="margin: auto; width: 530px; height: 360px; vertical-align: top">
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="Label3" runat="server" Text="Bienvenido al Programa Beneficio Inteligente Benavides"
                                Font-Bold="True" Font-Size="12pt" ForeColor="#004A99" Font-Names="Arial"></asp:Label>
                                <br /> 
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Label ID="lblEstadoCivil" runat="server" Text="Estado Civil" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Size="9pt" Font-Names="Arial"></asp:Label>
                            &nbsp
                            <asp:DropDownList ID="ddlEstadoCivil" runat="server" Width="110px" AppendDataBoundItems="True"
                                Font-Names="Arial" Font-Size="9pt">
                                <asp:ListItem Value="-1">--Selecciona--</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlEstadoCivil"
                                InitialValue="-1" SetFocusOnError="True" ValidationGroup="PrimeraVez" 
                                CssClass="Etiqueta">* Selecciona Estado Civil</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td align="left" valign="top" width="50%">
                                        <table width="100%">
                                            <tr>
                                                <td align="left" width="50%">
                                                    <asp:Label ID="lblHijos" runat="server" Text="Tiene hijos" Font-Bold="True" ForeColor="#004A99"
                                                        Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                                    &nbsp
                                                    <asp:DropDownList ID="ddlHijos" runat="server" Font-Names="Arial" Font-Size="9pt"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlHijos_SelectedIndexChanged">
                                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" width="50%">
                                                    <asp:Label ID="lblCuantos" runat="server" Text="Cuantos " Font-Bold="True" ForeColor="#004A99"
                                                        Font-Names="Arial" Font-Size="9pt" Visible="False"></asp:Label>
                                                    &nbsp
                                                    <asp:TextBox ID="txtNoHijos" runat="server" Width="30px" Font-Names="Arial" Font-Size="9pt"
                                                        MaxLength="2" Visible="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="20%">
                                                                <asp:Label ID="lblQueEdad" runat="server" Text="Edad " ForeColor="#004A99" CssClass="Etiqueta"
                                                                    Font-Bold="True" Font-Names="Arial" Font-Size="9pt" Visible="False"></asp:Label>
                                                                &nbsp
                                                            </td>
                                                            <td width="70%">
                                                                <asp:Panel ID="pnlchkEdad" runat="server" Height="52px" ScrollBars="Vertical" Font-Names="Arial"
                                                                    Font-Size="9pt" Visible="false" width="65%">
                                                                    <asp:CheckBoxList ID="chkQueEdad" runat="server" Font-Names="Arial" Font-Size="9pt"
                                                                        Visible="False" RepeatColumns="1" Width="80%">
                                                                    </asp:CheckBoxList>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left" width="50%" valign="top">
                                        <table width="100%">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblPadecimiento" runat="server" Text="Padecimiento crónico" ForeColor="#004A99"
                                                        CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                                    &nbsp
                                                    <asp:DropDownList ID="ddlPadecimiento" runat="server" Font-Names="Arial" Font-Size="9pt"
                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlPadecimiento_SelectedIndexChanged">
                                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                                        <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblTipoPadecimiento" runat="server" Text="Tipo" ForeColor="#004A99"
                                                        CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" Visible="False"></asp:Label>
                                                    &nbsp
                                                </td>
                                                <td>
                                                    <asp:Panel ID="pnlPadecimiento" runat="server" Height="52px" ScrollBars="Vertical"
                                                        Font-Names="Arial" Font-Size="9pt" Visible="false" Width="100%">
                                                        <asp:CheckBoxList ID="lstTipoPadecimiento" runat="server" Font-Names="Arial" Font-Size="9pt"
                                                            Visible="False" RepeatColumns="1" 
                                                            onselectedindexchanged="lstTipoPadecimiento_SelectedIndexChanged" 
                                                            AutoPostBack="True">
                                                        </asp:CheckBoxList>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblCualPadecimiento" runat="server" Text="Cual" ForeColor="#004A99"
                                                        CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt" Visible="False"></asp:Label>
                                                    &nbsp
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPadecimiento" runat="server" Width="178px" Font-Names="Arial"
                                                        Font-Size="9pt" Visible="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="50%" valign="top">
                            <asp:Label ID="lblCategorias" runat="server" Text="Categorías por las que visitas Benavides"
                                ForeColor="#004A99" CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:CheckBoxList ID="chkCategorias" runat="server" Font-Names="Arial" Font-Size="9pt">
                            </asp:CheckBoxList>
                        </td>
                        <td align="left" width="50%" valign="top">
                            <asp:Label ID="lblPromociones" runat="server" Text="Promociones que te gustaría recibir"
                                ForeColor="#004A99" CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:CheckBoxList ID="chkPromociones" runat="server" Font-Names="Arial" Font-Size="9pt">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/cancelar-btn.png"
                                OnClick="btnCancelar_Click" CausesValidation="false" />
                            &nbsp; &nbsp;&nbsp;
                            <asp:ImageButton ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" ImageUrl="~/Imagenes_Benavides/botones/registrar-btn.png"
                                ValidationGroup="PrimeraVez" />
                        </td>
                    </tr>
                </table>
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
                            <asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="True" Target="_blank" Font-Names="Arial"
                                Font-Size="8pt" ForeColor="#004A99" NavigateUrl="~/Terminos.aspx">Terminos y Condiciones</asp:HyperLink>
                            <asp:Label ID="Label10" runat="server" Text="|" Font-Bold="True" ForeColor="#004A99"></asp:Label>
                            <asp:HyperLink ID="HyperLink4" runat="server" Font-Bold="True" Target="_blank" Font-Names="Arial"
                                Font-Size="8pt" ForeColor="#004A99" NavigateUrl="~/AvisoPrivacidad.aspx">Aviso de Privacidad</asp:HyperLink>
                        </td>
                        <td style="width: 106px" align="right">
                            <img src="Imagenes_Benavides/benavides.png"/>
                        </td>
                        <td style="width: 60px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="3" align="left">
                            <asp:Label ID="Label11" runat="server" Font-Size="8pt" ForeColor="Silver" Text="Copyright 2013 Farmacias Benavides. Todos los derechos reservados"></asp:Label>
                        </td>
                    </tr>
                </table>
            </center>
        </div>
        </form>
    </center>
</body>
</html>
