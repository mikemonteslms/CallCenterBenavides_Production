<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetallePromo.ascx.cs" Inherits="WebPfizer.LMS.eCard.UserControls.DetallePromo" %>
<style type="text/css">
    .style1
    {
        width: 550px;
    }
    .Titulo
    {
        font: 12pt FuturaStd-Bold;
        color: #2B347A;
    }
</style>

<table class="style1">
    <tr style="height:15px;">
        <td colspan="2"><asp:HiddenField ID="hdnIDPromo" runat="server" /><hr /></td>
    </tr>
    <tr>
        <td style="vertical-align:top; text-align: left; width:60px">
                <asp:Image ID="imgTipo" runat="server" />            
        </td>
        <td style="vertical-align: middle; text-align: left;">
            <asp:Label ID="lblTitulo" runat="server" CssClass="Titulo"></asp:Label></td>
    </tr>
    <tr style="height:15px;">
        <td style="vertical-align:top;text-align: left;" colspan="2">            
        </td>
    </tr>
    <tr style="height:15px; font-family: FuturaStd-Bold;">
        <td style="vertical-align:top;text-align: left;" colspan="2">            
                <asp:Literal ID="ltlContenido" runat="server"></asp:Literal>            
        </td>
    </tr>    
</table>

