<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="ClubPequesPromos.aspx.cs" Inherits="WebPfizer.LMS.eCard.ClubPequesPromos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <table class="tablaSinbordes" 
         style="background-image: url('Imagenes_Benavides/MasterNueva/22-club_peques_promo/img-clubpeques-promo-555x420.jpg'); width:555px; height:420px;"><tr><td>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <table class="tablaSinbordes">
            <tr>
                <td style="width:430px;">
                   </td>
                <td >
                   </td>
                     <td style="width:30px;">
                        </td>
            </tr>
            <tr>
                <td>
                   </td>
                <td>
                    <asp:ImageButton ID="btnInscribir" runat="server" 
                        
                        ImageUrl="~/Imagenes_Benavides/MasterNueva/14-club_peques_que_es/btn-registrate-aqui.png" 
                        onclick="btnInscribir_Click" />
                </td>
                     <td>
                        </td>
            </tr>
        </table>
        </td></tr></table>
        <br />
    <div style="float: right; margin-right: 25px" class="linksBenaRecupera"><a class="linksBenaRecupera" style="font-weight:bold" href="javascript:window.history.back();">Volver</a></div>
   </asp:Content>