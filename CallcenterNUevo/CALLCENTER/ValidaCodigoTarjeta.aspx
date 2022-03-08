<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ValidaCodigoTarjeta.aspx.cs"
    Inherits="WebPfizer.LMS.eCard.ValidaCodigoTarjeta" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Site.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" language="javascript">
        function diHola(mensaje, pagina) {
            alert(mensaje);
            window.location.href = (pagina);
        }
    </script>
    <script type="text/javascript">
        function ValidaSoloNumeros() {
            if ((event.keyCode < 48) || (event.keyCode > 57))
                event.returnValue = false;
        }

        function txNombres() {
            if ((event.keyCode != 32) && (event.keyCode < 65) || (event.keyCode > 90) && (event.keyCode < 97) || (event.keyCode > 122))
                event.returnValue = false;
        }
    </script>
    <title>Valida Codigo</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
    <center>
        <div id="fondo" style="background-image: url(Imagenes_Benavides/registro-acceso-fondo.jpg);
            width: 1010px; height: auto; background-repeat: no-repeat;">
            <center>
                <br />
                <br />
                <asp:Panel ID="Panel2" runat="server" CssClass="panelReportes" style="height:auto">
                    <div id="divTarjeta" runat="server" style="width: 400px; height: 70px;">
                        <table>
                            <tr>
                                <td colspan="4"><span style="font-size:16pt; font-family:Arial;color:#004A99;">Envio de código SMS</span></td>
                            </tr>
                            <tr style="height:30px">
                                <td colspan="4"></td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 50px">
                                    <asp:Label ID="lblDescripcion" runat="server" Font-Bold="True" ForeColor="#004A99"
                                        Text="Tarjeta" Font-Size="12pt" Font-Names="Arial"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px">
                                    <asp:TextBox ID="txtTarjeta" runat="server" MaxLength="11" Width="140px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnEnviar" runat="server" Text="Validar" OnClick="btnEnviar_Click" />
                                    <br />
                                </td>
                                <td align="left" style="width: 50px">
                                    <asp:ImageButton ID="btnCancelar" runat="server" Height="30px" ImageUrl="~/Imagenes_Benavides/botones/undo.png"
                                        OnClick="btnCancelar_Click" Width="30px" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label2" runat="server" ForeColor="#004A99" Font-Size="9pt" Font-Names="Arial"
                                        Text="* Se enviará SMS al celular registrado en la Base de Datos"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div visible="false" id="divCodigo" runat="server" style="width: 400px; height: 70px;">
                        <br />
                        <table>
                            <tr>
                                <td align="left" style="width: 50px">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Código "
                                        Font-Size="12pt" Font-Names="Arial"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px">
                                    <asp:TextBox ID="txtCodigo" runat="server" MaxLength="10" Width="140px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnCodigo" runat="server" Text="Validar" OnClick="btnCodigo_Click" />
                                </td>
                                <td align="left" style="width: 50px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <div visible="false" id="dvCelular" runat="server" style="width: 400px; height: 70px;">
                        <br />
                        <table>
                            <tr>
                                <td align="left" style="width: 50px">
                                    <asp:Label ID="lblCelular" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Celular"
                                        Font-Size="12pt" Font-Names="Arial"></asp:Label>
                                </td>
                                <td align="left" style="width: 150px">
                                    <asp:TextBox ID="txtCelular" runat="server" MaxLength="10" Width="140px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                                </td>
                                <td align="left" style="width: 50px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div id="dvCuestionarioCC" runat="server" visible="false">
                        <asp:Panel ID="pnlCuestionarioCC" runat="server" CssClass="panelModal">
                            <table style="width: 600px; background-color: #E6E6E6;">
                                <tr>
                                    <td colspan="3" style="height:25px"></td>                                           
                                </tr>
                                <tr>
                                    <td style="width:25px"></td>
                                    <td>
                                        <table style="width: 600px; height: 100px; text-align: center">
                                <tr>
                                    <td>
                                        <br />
                                        <asp:Label ID="Label3" runat="server" Text="El celular es inválido, es necesario actualizarlo para activar la promoción"
                                            Font-Names="Arial" ForeColor="#777E7F" Font-Size="12px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: text-bottom; text-align:center;">
                                        <br />
                                        <asp:Label ID="Label5" runat="server" Text="¿Está de acuerdo en actualizarlo?" Font-Names="Arial"
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
                        <cc1:ModalPopupExtender ID="mpeCuestionarioCC" runat="server" PopupControlID="pnlCuestionarioCC"
                            TargetControlID="btnEnviar" DynamicServicePath="" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>
                    </div>
                    <br />
                    <br />
                </asp:Panel>
            </center>
        </div>
    </center>
</asp:Content> 
