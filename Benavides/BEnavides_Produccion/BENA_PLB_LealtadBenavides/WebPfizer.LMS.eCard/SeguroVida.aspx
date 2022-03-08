<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="SeguroVida.aspx.cs" Inherits="WebPfizer.LMS.eCard.SeguroVida" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
        <div style="width:555px; height:500;">
<table class="tablaSinbordes">
<tr>
<td><asp:Image ID="Image8" runat="server" 
        
        ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/img-beneficios-platino.png" /></td>
</tr>    
</table>
<table class="tablaSinbordes">
<tr><td style="width:23px; height:35px;"></td><td>
            <asp:Image ID="Image16" runat="server" 
                ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-7.png" />
    </td><td style="width:15px;"></td>
    <td>
       </td></tr>
    <tr><td style="height:15px;"></td><td></td><td></td><td></td></tr>
    <tr><td></td><td>   
         <span style="font-family:FuturaStd-Book; Font-Size:14px; color:#666666;" >       
       Seguro de vida por muerte accidental operado y a cargo de ACE Seguros, S.A.
       <ul> 
        <li>Hasta por $ 70,000 pesos de seguro de vida por muerte accidental.</li> 
        <li>Vigencia de 1 año para el seguro.</li> 
        <li>Aplica en caso de muerte accidental, incluso en caso de asaltos.</li>                             
        <li>Activación automática del seguro al comprar la tarjeta y registrarse en sucursal.</li> 
        <li>Podrás designar a tu beneficiario contactando a ACE Seguros. </li> 
        <li>Para la reclamación del seguro, el beneficiario debe presentar la tarjeta y demostrar la relación.</li>                             
        <li>Dudas e información, comunícate a ACE Seguros en el teléfono 01 800 237 6266 o en la página  <span style="font-family:FuturaStd-Book; Font-Size:14px; color:#00B8F1;" >
        <a href="http:\\www.acegroup.com/mx-es" target="_blank">www.acegroup.com/mx-es</a></span> consulta también el aviso de privacidad de la aseguradora en dicha página.</li>                                     
        </ul>
       </span>
       </td><td></td><td>
       </td></tr>
           
    <tr><td>&nbsp;</td><td align="right">   
         <a class="linksBenaAcceso" href="MisBeneficiosPlatino.aspx"><b>
                                <asp:Label ID="lblRegistro" runat="server" 
                                    CssClass="linksBenaRecupera"
                                    Text="Volver"></asp:Label>
                                </b></a>
       </td><td>&nbsp;</td><td>
        &nbsp;</td></tr>
           
    </table>
    </div>
     </asp:Content>