<%@ Page Title="" Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true" CodeBehind="MisSuscripciones.aspx.cs" Inherits="WebPfizer.LMS.eCard.MisSuscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="vertical-align: top;" >
        <%--<table><tr><td valign="top"> --%>   
        <table width="100%">
            <tr valign="top">
            <td valign="top">
            <div style="margin-top:-68px; position: absolute">
                <asp:Label ID="Label8" runat="server" Text="Suscripciones" Font-Names="FuturaStd-Bold"  Font-Size="14px" ForeColor="#666666"></asp:Label>
            </div>
            </td>
            </tr>
            <tr>        
            <td>
            <div style="margin-top:-40px; position: absolute; width:500px">
            <hr />
            </div>
            </td>
            </tr>
         </table>
        <br /><br />
        <table width="100%">
            <tr>
                <td align="left">
                    <div style="margin-top:-40px; position: absolute; width:500px">
                    <asp:Label ID="lblDescripcion" runat="server" CssClass="letras" Text="Selecciona por cuál de los siguientes medios de comunicación, te gustaría ser contactado." ></asp:Label>
                    </div>
                    <br /><br />
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" >
                        <tr>
                            <td align="left">&nbsp</td>
                            <td align="center">&nbsp<span class="letras">Correo Electrónico</span>&nbsp</td>
                            <td align="center">&nbsp<span class="letras">Celular</span>&nbsp</td>
                            <td align="center" runat="server" id="tdTelCasaTitulo" visible="false">&nbsp<span class="letras">Teléfono Particular</span>&nbsp</td>
                            <td align="center" runat="server" id="tdPostalTitulo" visible="false">&nbsp<span class="letras">Correo Postal</span>&nbsp</td>
                        </tr>
                        <tr id="trPermisos_7" runat="server" visible="false" align="center">
                            <td align="left"><span class="letras">Beneficio Inteligente</span></td>
                            <td>
                                <asp:RadioButtonList ID="rdoCorreoE_7" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoCelular_7" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td runat="server" id="tdTelCasa7" visible="false">
                                <asp:RadioButtonList ID="rdoTelPart_7" runat="server" CssClass="letras"
                                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td runat="server" id="tdPostal7" visible="false">
                                <asp:RadioButtonList ID="rdoCorreoP_7" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr id="trPermisos_1" runat="server" visible="false" align="center">
                            <td align="left"><span class="letras">Diabetes</span></td>
                            <td>
                                <asp:RadioButtonList ID="rdoCorreoE_1" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoCelular_1" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoTelPart_1" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoCorreoP_1" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr id="trPermisos_2" runat="server" visible="false" align="center">
                            <td align="left"><span class="letras">Baby Benavides</span></td>
                            <td>
                                <asp:RadioButtonList ID="rdoCorreoE_2" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoCelular_2" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoTelPart_2" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoCorreoP_2" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr id="trPermisos_3" runat="server" visible="false" align="center">
                            <td align="left"><span class="letras">Club Peques</span></td>
                            <td>
                                <asp:RadioButtonList ID="rdoCorreoE_3" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoCelular_3" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td runat="server" id="tdTelCasa3" visible="false">
                                <asp:RadioButtonList ID="rdoTelPart_3" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td runat="server" id="tdPostal3" visible="false">
                                <asp:RadioButtonList ID="rdoCorreoP_3" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr id="trPermisos_5" runat="server" visible="false" align="center">
                            <td align="left"><span CssClass="letras">Hipertencion</span></td>
                            <td>
                                <asp:RadioButtonList ID="rdoCorreoE_5" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoCelular_5" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoTelPart_5" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoCorreoP_5" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr id="trPermisos_6" runat="server" visible="false" align="center">
                            <td align="left"><span class="letras">Obesidad</span></td>
                            <td>
                                <asp:RadioButtonList ID="rdoCorreoE_6" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoCelular_6" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoTelPart_6" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoCorreoP_6" runat="server" CssClass="letras"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <br />
                    <asp:ImageButton ID="btnRegistrarSuscripion" runat="server" 
                        ImageUrl="~/Imagenes_Benavides/MasterNueva/8-registro/btn-aceptar.jpg" 
                        onclick="btnRegistrarSuscripion_Click"  />
                </td>
            </tr>
        </table>
        <br /><br /><br />
    </div>
    <style type="text/css">
        .titulo
        {
            font-family: Arial;
            font-size: 20pt;
            color: #004A99;
        }
        .fuenteReporte
        {
            font-family: Arial;
            color: #004A99;
            font-size: 15px;
        }
        .letras
        {
            font-family: Arial;
            color: #666666;
            font-size: 14px;
        }
    </style>
</asp:Content>
