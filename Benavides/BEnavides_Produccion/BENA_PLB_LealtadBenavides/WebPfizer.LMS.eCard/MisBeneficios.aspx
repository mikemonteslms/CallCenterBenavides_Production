﻿<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="MisBeneficios.aspx.cs" Inherits="WebPfizer.LMS.eCard.MisBeneficios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
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
            <image src="Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6.png" alt="" onmouseover="javascript:this.src='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6-hover.png'" onmouseout="javascript:this.src ='Imagenes_Benavides/MasterNueva/4-mis_beneficios_blue/btn-beneficios-blue-235x60-6.png'" ></image>
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
         <a href="ClubPeques.aspx">
            <image src="Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-5.png" alt="" onmouseover="javascript:this.src='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-5-hover.png'" onmouseout="javascript:this.src ='Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-5.png'" border="0" ></image>
        </a>
            <asp:ImageButton ID="btnClub" runat="server" 
                ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-5.png" 
                onclick="btnClub_Click" Visible="false" />
            </td><td></td><td>
            <asp:ImageButton ID="btnDescuentos" runat="server" 
                ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-10.png" 
                onclick="btnDescuentos_Click" />
            </td></tr>           
    </table>
</div>
 </asp:Content>
