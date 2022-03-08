<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="ServicioAmbulancia.aspx.cs" Inherits="WebPfizer.LMS.eCard.ServicioAmbulancia" %>

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
                ImageUrl="~/Imagenes_Benavides/MasterNueva/5-mis_beneficios_platino/btn-beneficios-platino-235x60-8.png" />
    </td><td style="width:15px;"></td>
    <td>
       </td></tr>
    <tr><td style="height:15px;"></td><td></td><td></td><td></td></tr>
    <tr><td></td><td>   
         <span style="font-family:FuturaStd-Book; Font-Size:14px; color:#666666;" >
       2 ambulancias al año otorgado / operado y a cargo de ACE Seguros, S.A. 
       <br /><br />
       Se otorga el servicio 2 veces al año gratis.  
       <ul> 
        <li>Para uso exclusivo del titular de la tarjeta.</li> 
        <li>Únicamente en caso de emergencia, aplican restricciones.</li> 
        <li>Programa a nivel nacional las 24 horas y 365 días del año.</li>                             
        <li>Traslado al hospital más cercano.</li> 
        <li>Equipada con todos los servicios básicos de primeros auxilios y operada por paramédicos certificados.</li> 
        <li>Envío de ambulancia por emergencia.- Si el beneficiario o consecuencia de accidente o enfermedad repentina que le provoque lesiones o traumatismos que pongan en peligro su vida, se gestionará su traslado al centro hospitalario más cercano y/o adecuado. Si fuera necesario por razones médicas, se realizará el traslado bajo supervisión médica, mediante ambulancia terrestre, de terapia intensiva, intermedia o estándar, dependiendo de la gravedad y circunstancias de cada caso.</li>                             
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