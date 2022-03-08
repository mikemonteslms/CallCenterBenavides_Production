<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecuperarContraseñaCallCenter.aspx.cs"
    Inherits="Portal_Benavides.RecuperarContraseñaCallCenter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title>Registro de Cliente</title>
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
    <style type="text/css">
        .Etiqueta {
            font-size:10pt !important;
        }
    </style>
    <center>
        <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: auto; background-repeat: no-repeat;">
            <center>
                <br />
                <br />
                <table style="width:650px">
                    <tr>
                        <td colspan="5" style="text-align:left;"><asp:Label ID="lblTitulo" runat="server" Text="Recuperación de Contraseña" Font-Bold="True"
                                Font-Size="16pt" ForeColor="#004A99" Font-Names="Arial"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="height:40px"></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="text-align:left;"><asp:Label ID="lblTarjeta" runat="server" Text="Tarjeta" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label><asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red" Font-Names="Arial"
                                CssClass="Etiqueta"></asp:Label></td>
                        <td style="text-align:left;"><asp:TextBox ID="txtTarjeta" runat="server" MaxLength="19" Width="150px"></asp:TextBox></td>
                        <td>&nbsp;</td>
                        <td colspan="2" style="text-align:left"><asp:Button ID="btnVerificar" runat="server" OnClick="btnVerificar_Click" Text="Validar Tarjeta" /></td>
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
                                Font-Names="Arial" CssClass="Etiqueta"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtAP" runat="server" Width="150px" MaxLength="30" Enabled="False"></asp:TextBox>
                            </td>
                        <td>&nbsp;</td>
                        <td style="text-align:left;">
                            <asp:Label ID="lblAM" runat="server" Text="Apellido Materno" ForeColor="#004A99"
                                Font-Names="Arial" CssClass="Etiqueta" Font-Bold="True"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtAM" runat="server" Width="150px" MaxLength="30" Enabled="False"></asp:TextBox>
                            </t>
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
                                CssClass="Etiqueta" Font-Bold="True"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtNombre" runat="server" Width="150px" MaxLength="30" Enabled="False"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td style="text-align:left;">
                            <asp:Label ID="lblgenero" runat="server" CssClass="Etiqueta" Font-Bold="True" Text="Genero"
                                Font-Size="9pt"></asp:Label>
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
                            </td>
                        <td colspan="4" style="text-align:left;">
                            <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="#004A99"
                                Text="Año" Font-Bold="True"></asp:Label>
                            <asp:DropDownList ID="ddlAno" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlAno_SelectedIndexChanged" Enabled="False">
                            </asp:DropDownList>
                            &nbsp;
                            <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="#004A99"
                                Text="Mes" Font-Bold="True"></asp:Label>
                            <asp:DropDownList ID="ddlMes" runat="server" AutoPostBack="True" Enabled="False" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;
                            <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="9pt" ForeColor="#004A99"
                                Text="Día" Font-Bold="True"></asp:Label>
                            <asp:DropDownList ID="ddlDia" runat="server" Enabled="False" Width="60px">
                            </asp:DropDownList>
                        </td>
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
                            <asp:TextBox ID="txtTelefono" runat="server" Width="150px" MaxLength="10" Enabled="False"></asp:TextBox>
                        </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            <asp:Label ID="lblCelular" runat="server" Text="Teléfono Celular" ForeColor="#004A99"
                                CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
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
                            </td>
                        <td style="text-align:left;" colspan="4">
                            <asp:TextBox ID="txtCorreo" runat="server" MaxLength="80" Enabled="False" Width="240px"></asp:TextBox>
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
                            </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtCalle" runat="server" MaxLength="250" Width="125px" Enabled="False"></asp:TextBox>
                            </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            <asp:Label ID="lblExterior" runat="server" Text="Ext." ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
                            </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtNumExterior" runat="server" Width="30px" MaxLength="10" Enabled="False"></asp:TextBox>
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
                            <asp:TextBox ID="txtNumInterior" runat="server" Width="30px" MaxLength="10" Enabled="False"></asp:TextBox>
                            </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            <asp:Label ID="lblEstado" runat="server" Text="Estado" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
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
                            </td>
                        <td style="text-align:left;">
                            <asp:DropDownList ID="ddlMunicipio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged"
                                Width="130px" Enabled="False">
                            </asp:DropDownList>
                            </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            <asp:Label ID="lblColonia" runat="server" Text="Colonia" ForeColor="#004A99" CssClass="Etiqueta"
                                Font-Bold="True" Font-Size="9pt"></asp:Label>
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
                            </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtCP" runat="server" Width="50px" MaxLength="5" Enabled="False"></asp:TextBox>
                            </td>
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
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="text-align:right;" colspan="2">
                                <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/cancelar-btn.png"
                                    OnClick="btnCancelar_Click" CausesValidation="false" />
                            </td>
                        <td style="text-align:left;">
                            &nbsp;</td>
                        <td style="text-align:left;" colspan="2">
                                <asp:ImageButton ID="btnEnviar" runat="server" ImageUrl="~/Imagenes_Benavides/botones/enviar-btn.png"
                                    OnClick="btnEnviar_Click" Enabled="false" />
                            </td>
                    </tr>
                </table>
                <div id="dvConfirma" runat="server" visible="false">
                                <asp:Panel ID="pnlConfirma" runat="server">
                                    <table style="width: 600px; background-color: #E6E6E6;">
                                        <tr>
                                            <td colspan="3" style="height:25px"></td>                                           
                                        </tr>
                                        <tr>
                                            <td style="width:25px"></td>
                                            <td>
                                                  <table style="width: 550px">
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:Label ID="Label10" runat="server" Text="Se enviará un correo electrónico a"
                                                    Font-Names="Arial" ForeColor="#777E7F" Font-Size="12px"></asp:Label>
                                                &nbsp
                                                <asp:Label ID="lblCorreoEnvio" runat="server" Font-Names="Arial" ForeColor="#004A99"
                                                    Font-Size="12px"></asp:Label>
                                                &nbsp
                                                <asp:Label ID="Label11" runat="server" Text="correspondiente a la tarjeta" Font-Names="Arial"
                                                    ForeColor="#777E7F" Font-Size="12px"></asp:Label>
                                                &nbsp
                                                <asp:Label ID="lblTarjetaEnvio" runat="server" Font-Names="Arial" ForeColor="#004A99"
                                                    Font-Size="12px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: text-bottom; text-align:center">
                                                <br />
                                                <asp:Label ID="Label5" runat="server" Text="¿Estás de acuerdo?" Font-Names="Arial"
                                                    ForeColor="#777E7F" Font-Size="12px"></asp:Label><br />
                                                <asp:LinkButton ID="lnkAceptar" runat="server" Text="Aceptar" ForeColor="#004A99"
                                                    CssClass="Etiqueta" Font-Bold="True" Font-Size="14px" OnClick="lnkAceptar_Click"></asp:LinkButton>
                                                &nbsp &nbsp &nbsp &nbsp &nbsp
                                                <asp:LinkButton ID="lnkCancelar" runat="server" Text="Cancelar" ForeColor="#004A99"
                                                    CssClass="Etiqueta" Font-Bold="True" Font-Size="14px" OnClick="lnkCancelar_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                            </td>
                                            <td style="width:25px"></td>
                                        </tr>
                                     <tr>
                                            <td colspan="3"  style="height:25px"></td>                                           
                                        </tr>
                                    </table>
                                  
                                </asp:Panel>
                                <cc1:ModalPopupExtender ID="mpeConfirma" runat="server" PopupControlID="pnlConfirma"
                                    TargetControlID="btnEnviar" DynamicServicePath="" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                            </div>
            </center>
        </div>
    </center>
   
</asp:Content>