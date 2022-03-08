<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroClienteCallCenter.aspx.cs"
    Inherits="Portal_Benavides.RegistroClienteCallCenter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/MisEstilos.css" rel="stylesheet" type="text/css" />
    <title>Registro de Cliente</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
    <center>
        <%--<div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: 756px; background-repeat: no-repeat;">--%>
            <center>
                <br />
                <br /><br /><br />
                <table style="width:650px">
                    <tr>
                        <td colspan="5" style="text-align:left;"><asp:Label ID="lblRegistro" runat="server" Text="Registro de Datos Personales" Font-Bold="True"
                                Font-Size="16pt" ForeColor="#004A99" Font-Names="Arial"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                    <tr>
                        <td colspan="5" style="text-align:left">
                            <asp:Label ID="Label1" runat="server" Text="Son obligatorios los datos marcados con "
                                ForeColor="Red" Font-Names="Arial" CssClass="Etiqueta"></asp:Label><font color="Red">(</font><font
                                    color="Red"><b>*</b>)</font>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:40px"></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            <asp:Label ID="lblTarjeta" runat="server" Text="Tarjeta" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaTarjeta" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            </td>
                        <td style="text-align:left;">&nbsp;</td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtTarjeta" runat="server" MaxLength="19" Width="150px"></asp:TextBox>
                            </td>
                        <td colspan="2" style="text-align:left">
                            <asp:Button ID="btnVerificar" runat="server" OnClick="btnVerificar_Click" Text="Validar Tarjeta"
                                CausesValidation="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            <asp:Label ID="lblAP" runat="server" Text="Apellido Paterno" Font-Bold="True" ForeColor="#004A99"
                                Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaAP" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtAP" runat="server" Width="150px" MaxLength="30" Enabled="False"></asp:TextBox>
                            </td>
                        <td style="text-align:left;">
                            <asp:Label ID="lblAM" runat="server" Text="Apellido Materno" ForeColor="#004A99"
                                Font-Names="Arial" Font-Size="9pt" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblValidaAM" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtAM" runat="server" Width="150px" MaxLength="30" Enabled="False"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td>&nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</tr>
                    <tr>
                        <td style="text-align:left;">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" ForeColor="#004A99" Font-Names="Arial"
                                Font-Size="9pt" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblValidaNombre" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtNombre" runat="server" Width="150px" MaxLength="30" Enabled="False"></asp:TextBox>
                        </td>
                        <td style="text-align:left;">
                            <asp:Label ID="lblgenero" runat="server" CssClass="Etiqueta" Font-Bold="True" Text="Genero"
                                Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaGenero" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            <asp:DropDownList ID="ddlGenero" runat="server" Enabled="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            <asp:Label ID="Label2" runat="server" Text="Fecha de Nacimiento" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaFecha" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                        </td>
                        <td></td>
                        <td colspan="3" style="text-align:left;">
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
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td colspan="4" style="text-align:left;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtTelefono" runat="server" Width="150px" MaxLength="10" Enabled="False"></asp:TextBox>
                            </td>
                        <td style="text-align:left;">
                            <asp:Label ID="lblCelular" runat="server" Text="Teléfono Celular" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaCelular" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtCelular" runat="server" MaxLength="10" Width="150px" Enabled="False"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            <asp:Label ID="lblCorreo" runat="server" Text="Correo Electronico:" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaCorreo" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            </td>
                        <td></td>
                        <td style="text-align:left;" colspan="3">
                            <asp:TextBox ID="txtCorreo" runat="server" MaxLength="80" Enabled="False" ValidationGroup="ValidaDatos" Width="150px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCorreo"
                                ErrorMessage="El correo electrónico no es válido" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="ValidaDatos"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;" colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;" colspan="5">
                            <asp:Label ID="lblDireccion" runat="server" Text="Direccion:" ForeColor="#777E7F"
                                Font-Names="Arial" Font-Size="10pt"></asp:Label>
                            <span style="color: #777e7f">(</span><font color="#E42313"><b>*</b></font><font color="#777E7F">)</font>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left;" colspan="5">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            <asp:Label ID="lblCalle" runat="server" Text="Calle" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaCalle" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtCalle" runat="server" MaxLength="250" Width="150px" Enabled="False"></asp:TextBox>
                            </td>
                        <td style="text-align:left;">
                            <asp:Label ID="lblExterior" runat="server" Text="Ext." ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaExterior" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtNumExterior" runat="server" Width="50px" MaxLength="10" Enabled="False"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            <asp:Label ID="lblInterior" runat="server" Text="Num. Int" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtNumInterior" runat="server" Width="50px" MaxLength="10" Enabled="False"></asp:TextBox>
                            </td>
                        <td style="text-align:left;">
                            <asp:Label ID="lblEstado" runat="server" Text="Estado" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaEstado" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
                                Width="110px" Enabled="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            <asp:Label ID="lblMunicipio" runat="server" Text="Municipio" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaMunicipio" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            <asp:DropDownList ID="ddlMunicipio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged"
                                Width="130px" Enabled="False">
                            </asp:DropDownList>
                            </td>
                        <td style="text-align:left;">
                            <asp:Label ID="lblColonia" runat="server" Text="Colonia" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaColonia" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            <asp:DropDownList ID="ddlColonia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlColonia_SelectedIndexChanged"
                                Width="170px" Enabled="False">
                            </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            <asp:Label ID="lblCP" runat="server" Text="C.P." ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            <asp:Label ID="lblValidaCP" runat="server" ForeColor="Red" Text="*" Visible="true"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtCP" runat="server" Width="50px" MaxLength="5" Enabled="False"></asp:TextBox>
                        </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                    </tr>
                    <tr style="30px">
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/cancelar-btn.png"
                                OnClick="btnCancelar_Click" CausesValidation="false" Visible="true" />
                            </td>
                        <td style="text-align:left;">
                            <asp:ImageButton ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" ImageUrl="~/Imagenes_Benavides/botones/registrar-btn.png"
                                Enabled="False" ValidationGroup="ValidaDatos" />
                            </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:right;" colspan="2">
                                &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;" colspan="2">
                                &nbsp;</td>
                    </tr>
                </table>
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
            </center>
    </center>
</asp:Content>
