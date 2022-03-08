<%@ Page Title="" Language="C#" MasterPageFile="~/MasterECard.Master" AutoEventWireup="true"
    CodeBehind="Beneficios.aspx.cs" Inherits="WebPfizer.LMS.eCard.Beneficios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">    
    <asp:Panel ID="pnlBeneficios" runat="server" BorderColor="#999999" BorderStyle="Solid"
        BorderWidth="1px" BorderRadius="15px">
        <table cellspacing="20px" style='height: 330px; width: 641px; vertical-align: top'>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="¿Qué es?" ForeColor="Red" Font-Names="Arial"
                        Font-Size="12pt" Font-Italic="true" Font-Bold="true"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"
                        ForeColor="#004A99" Text="Beneficio Inteligente Benavides "></asp:Label>
                    <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#777E7F"
                        Text="es el programa creado para reconocerte y premiarte por elegir Farmacias Benavides."></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#777E7F"
                        Text="De ahora en adelante, cada vez que realices una compra con nosotros, acumularás un porcentaje de tu compra en tu tarjeta, que podrás utilizar como dinero en tus próximas visitas."></asp:Label>
                    <br />
                    <asp:Label ID="Label10" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#777E7F"
                        Text="Entre más compras y visitas acumules, podrás subir de nivel y aumentar el porcentaje de acumulación que tendrás en tus compras, además de obtener más y mejores beneficios."></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Font-Bold="true" Font-Italic="true" Font-Names="Arial"
                        Font-Size="12pt" ForeColor="Red" Text="¿Cómo me registro?"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label17" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"
                        ForeColor="#004A99" Text="• "></asp:Label>
                    <asp:Label ID="Label16" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#777E7F"
                        Text="Al obtener tu tarjeta Beneficio Inteligente Benavides deberás proporcionar tus datos en caja."></asp:Label>
                    <br />
                    <asp:Label ID="Label6" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"
                        ForeColor="#004A99" Text="• "></asp:Label>
                    <asp:Label ID="Label11" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#777E7F"
                        Text="Para completar tu información podrás comunicarte sin costo al"></asp:Label>
                    &nbsp
                    <asp:Label ID="Label7" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"
                        ForeColor="#004A99" Text="01 800 444 2525"></asp:Label>
                    &nbsp
                    <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#777E7F"
                        Text="o ingresar a"></asp:Label>
                    &nbsp
                    <asp:Label ID="Label9" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"
                        ForeColor="#004A99" Text="www.benavides.com.mx"><a href="http://www.benavides.com.mx/Sitio/Default.asp?strPageName=HomeInicial">www.benavides.com.mx</a></asp:Label>
                    &nbsp
                    <asp:Label ID="Label12" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#777E7F"
                        Text="en la sección del programa Beneficio Inteligente Benavides."></asp:Label>
                    <br />
                    <asp:Label ID="Label18" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="10pt"
                        ForeColor="#004A99" Text="• "></asp:Label>
                    <asp:Label ID="Label13" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="#777E7F"
                        Text="Además para darte la bienvenida recibe triple acumulación en tu siguiente compra después de realizar el registro de tu tarjeta Beneficio Inteligente."></asp:Label>
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:LinkButton ID="lnkregresar" runat="server" ForeColor="#777E7F" Font-Bold="False"
        CssClass="EtiquetaGris" OnClick="lnkregresar_Click">>>Regresar</asp:LinkButton>
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
</asp:Content>
