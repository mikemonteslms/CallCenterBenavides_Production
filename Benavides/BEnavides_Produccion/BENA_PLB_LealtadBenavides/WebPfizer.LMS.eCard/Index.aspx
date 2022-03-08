<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="WebPfizer.LMS.eCard.Index" %>

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
            <div visible="false" runat="server" id="general" style="width: 641px;"  >
                <ul id="mycarousel" class="jcarousel-skin-tango">
                    <asp:Repeater ID="rptImages" runat="server">
                        <ItemTemplate>
                            <li>
                                <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes_Benavides/banners/banner-promociones.jpg" />--%>
                                <a href = '<%# Eval("LinkUrl") %>'>
                                <img style='height: 330px; width: 661px; border:0;' src='<%# Eval("ImageUrl") %>' />
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <table>
                    <tr>
                        <td style="width: 16px">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 332px">
                           
                        </td>
                    </tr>
                </table>
            </div>
            <div id="imgTemp" runat="server" visible="false" style="background-image: url('Imagenes_Benavides/MasterNueva/9-niveles/bg-niveles-555x420.jpg'); width:555px; height:420px;">
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
            <div id="divAzul" runat="server" visible="false" style="width:555px; height:420px; background-color:#2B347A;">
<table class="tablaSinbordes">
<tr>
<td><asp:Image ID="Image1" runat="server" 
        ImageUrl="~/Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/img-beneficios-blue.png" /></td>
</tr>    
</table>
<table class="tablaSinbordes"><tr><td style="width:23px; height:35px;"></td><td>
    <asp:Image ID="Image2" runat="server" 
        ImageUrl="~/Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/img-beneficios-blue-235x60-1.png" />
    </td><td style="width:15px;"></td>
    <td>
        <asp:Image ID="Image3" runat="server" 
            ImageUrl="~/Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/img-beneficios-blue-235x60-4.png" />
    </td></tr>
    <tr><td style="height:10px;"></td><td></td><td></td><td></td></tr>
    <tr><td></td><td>
        <asp:Image ID="Image4" runat="server" 
            ImageUrl="~/Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/img-beneficios-blue-235x60-2.png" />
        </td><td></td><td>
        <asp:ImageButton ID="btnMedicGratis" runat="server" 
            ImageUrl="~/Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-5.png" 
            onclick="btnMedicGratis_Click" />
        </td></tr>
    <tr><td></td><td></td><td></td><td></td></tr>
    <tr><td></td><td>
        <asp:Image ID="Image6" runat="server" 
            ImageUrl="~/Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/img-beneficios-blue-235x60-3.png" />
        </td><td></td><td>
        <a href="ClubPeques.aspx">
            <image src="Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6.png" alt="" onmouseover="javascript:this.src='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6-hover.png'" onmouseout="javascript:this.src ='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6.png'" border="0"></image>
        </a>
        <asp:ImageButton ID="btnClubAzul" runat="server" 
            ImageUrl="~/Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6.png" 
            onclick="btnClubAzul_Click" Visible="false" />
        </td></tr>
    </table>
</div>
            <div id="divPlatino" runat="server" visible="false" style="width:555px; height:520px; background-color:#D7D7D7;">
<table class="tablaSinbordes">
<tr>
<td><asp:Image ID="Image8" runat="server" 
        
        ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/img-beneficios-platino.png" /></td>
</tr>    
</table>
<table class="tablaSinbordes"><tr><td style="width:23px; height:35px;"></td><td>
    <asp:Image ID="Image9" runat="server" 
        
        ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/img-beneficios-platino-235x60-1.png" />
    </td><td style="width:15px;"></td>
    <td>
        <asp:ImageButton ID="btnMedicGPlatino" runat="server" 
            ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-6.png" 
            onclick="btnMedicGPlatino_Click" />
    </td></tr>
    <tr><td style="height:10px;"></td><td></td><td></td><td></td></tr>
    <tr><td></td><td>
        <asp:Image ID="Image11" runat="server" 
            
            ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/img-beneficios-platino-235x60-2.png" />
        </td><td></td><td>
        <asp:ImageButton ID="btnSeguro" runat="server" 
            ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-7.png" 
            onclick="btnSeguro_Click" />
        </td></tr>
    <tr><td></td><td></td><td></td><td></td></tr>
    <tr><td></td><td>
        <asp:Image ID="Image13" runat="server" 
            
            ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/img-beneficios-platino-235x60-3.png" />
        </td><td></td><td>
            <asp:ImageButton ID="btnServicio" runat="server" 
                
                
                ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-8.png" 
                onclick="btnServicio_Click" />
        </td></tr>
        <tr><td style="height:10px;"></td><td></td><td></td><td></td></tr>
        <tr><td></td><td>
            <asp:Image ID="Image15" runat="server" 
                ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/img-beneficios-platino-235x60-4.png" />
            </td><td></td><td>
            <asp:ImageButton ID="btnOrientacion" runat="server" 
                ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-9.png" 
                onclick="btnOrientacion_Click" />
            </td></tr>
        <tr><td style="height:10px;"></td><td></td><td></td><td></td></tr>
        <tr><td></td><td>
            <asp:ImageButton ID="btnClub" runat="server" 
                ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-5.png" 
                onclick="btnClub_Click" />
            </td><td></td><td>
            <asp:ImageButton ID="btnDescuentos" runat="server" 
                ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-10.png" 
                onclick="btnDescuentos_Click" />
            </td></tr>           
    </table>
</div>
        </ContentTemplate>        
    </asp:UpdatePanel>
</asp:Content>
