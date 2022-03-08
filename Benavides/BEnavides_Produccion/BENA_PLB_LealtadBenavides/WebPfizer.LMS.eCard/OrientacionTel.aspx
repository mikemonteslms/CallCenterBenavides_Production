<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="OrientacionTel.aspx.cs" Inherits="WebPfizer.LMS.eCard.OrientacionTel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width:555px; height:420px;">
<table class="tablaSinbordes">
<tr>
<td><asp:Image ID="Image8" runat="server" 
        
        ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/img-beneficios-platino.png" /></td>
</tr>    
</table>
<table class="tablaSinbordes"> 
<tr><td style="width:23px; height:35px;"></td><td>
            <asp:Image ID="Image16" runat="server" 
                ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-9.png" />
    </td><td style="width:15px;"></td>
    <td>
       </td></tr>
    <tr><td style="height:15px;"></td><td></td><td></td><td></td></tr>
    <tr><td></td><td>
        <asp:Label ID="Label1" runat="server" Text="Para mayor información consulta " Font-Names="FuturaStd-Book" 
                            Font-Size="14px" ForeColor="#666666"></asp:Label>
         <span style="font-family:FuturaStd-Book; Font-Size:14px; color:#00B8F1;" >
        <a href="http:\\www.acegroup.com/mx-es" target="_blank">www.acegroup.com/mx-es</a></span>
       </td><td></td><td>
       </td></tr>                 
    </table>
    <br /><br /><br /><br /><br /><br />
    <table class="tablaSinbordes"> <tr><td style="width:480px;"></td><td align="right">   
         <a class="linksBenaAcceso" href="MisBeneficiosPlatino.aspx"><b>
                                <asp:Label ID="lblRegistro" runat="server" 
                                    CssClass="linksBenaRecupera"
                                    Text="Volver"></asp:Label>
                                </b></a>
       </td></tr></table> 
    </div>
   </asp:Content>