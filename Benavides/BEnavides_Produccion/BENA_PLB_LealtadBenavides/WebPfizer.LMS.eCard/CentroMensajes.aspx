<%@ Page Language="C#" MasterPageFile="~/MasterECard.Master" AutoEventWireup="true" CodeBehind="CentroMensajes.aspx.cs" Inherits="WebPfizer.LMS.eCard.CentroMensajes" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="general">
                <table border="1">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="height: 30px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 30px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 110px; text-align: center;" class="Etiqueta">
                                        <asp:Label ID="Label1" runat="server" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 110px; text-align: center;" class="Etiqueta">
                                        <asp:Label ID="Label2" runat="server" Width="400px"></asp:Label>
                                    </td>
                                </tr>
                                                                    <td style="height: 10px;">
                                    </td>
                                <tr>
                                    <td style="width: 110px; text-align: center;" class="Etiqueta">
                                        <asp:Label ID="Label3" runat="server" Width="400px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="Boton" OnClick="btnAceptar_Click" Width="70px">
                                        </asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 30px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 30px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="height: 30px;">
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

