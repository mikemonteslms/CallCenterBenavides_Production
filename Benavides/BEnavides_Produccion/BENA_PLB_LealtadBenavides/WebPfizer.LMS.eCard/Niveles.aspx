<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="Niveles.aspx.cs" Inherits="WebPfizer.LMS.eCard.Niveles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>        
            <div id="imgTemp" runat="server" style="background-image: url('Imagenes_Benavides/MasterNueva/9-niveles/bg-niveles-555x420.jpg'); width:555px; height:420px;">
            <br /><br /><br /><br />
            <table><tr>
            <td >
                &nbsp;</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Con tu tarjeta Beneficio Inteligente obtienes <b>grandes beneficios, dinero electrónico y boomerangs</b> que te harán crecer de nivel." Font-Names="FuturaStd-Bold" 
                                Font-Size="14px" ForeColor="#FFFFFF"></asp:Label>
                </td>
             <td>
                 &nbsp;</td>
             </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Font-Names="FuturaStd-Bold" 
                                Font-Size="14px" ForeColor="#FFFFFF"
                            Text="Preséntala en cada compra que realices en todas nuestras sucursales"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    <br /><br />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width:55px; height:80px;">
                    </td>
                    <td>
                        <asp:Image ID="imgTemporal" runat="server" 
                            ImageUrl="~/Imagenes_Benavides/MasterNueva/9-niveles/img-niveles-445x182.png" />
                    </td>
                    <td>
                    </td>
                </tr>
             </table>
            
            </div>
        </ContentTemplate>        
    </asp:UpdatePanel>
    
</asp:Content>
