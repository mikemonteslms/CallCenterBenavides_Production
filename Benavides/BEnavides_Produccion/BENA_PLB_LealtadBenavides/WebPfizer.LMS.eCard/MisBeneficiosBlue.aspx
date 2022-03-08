<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="MisBeneficiosBlue.aspx.cs" Inherits="WebPfizer.LMS.eCard.MisBeneficiosBlue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="divAzul" runat="server" style="width:555px; height:420px; background-color:#2B347A;">
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
            <image src="Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6.png" alt="" onmouseover="javascript:this.src='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6-hover.png'" onmouseout="javascript:this.src ='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6.png'" ></image>
        </a>
        <asp:ImageButton ID="btnClubAzul" runat="server" 
            ImageUrl="~/Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6.png" 
            onclick="btnClubAzul_Click" Visible="false" />
        </td></tr>
    </table>   
</div>

 </asp:Content>
