<%@ Page Language="C#" MasterPageFile="~/NBenavidesMaster.Master" AutoEventWireup="true"
    CodeBehind="CambiarContra.aspx.cs" Inherits="WebPfizer.LMS.eCard.CambiarContra" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div style="width:555px; height:450px; background-color:#D7D7D7;">
<table class="tablaSinbordes"><tr><td style="width:30px;"></td><td>
<table class="tablaSinbordes" style="background-image: url('Imagenes_Benavides/MasterNueva/13-cambiar_contrasena/bg-cambiar_contrasena-495x425.png'); background-repeat:no-repeat; width:495px; height:425px;">
<tr><td>
<table class="tablaSinbordes"><tr><td style="height:140px; width:30px;"></td><td></td><td></td><td></td><td></td></tr>
<tr><td ></td><td>
    <asp:Label ID="Label1" runat="server" Text="Cambiar contraseña" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666"></asp:Label>
    </td><td></td><td></td><td></td></tr>
    <tr><td style="height:15px"></td><td>    
    </td><td></td><td></td><td></td></tr>
    <tr><td></td><td>    
        <asp:Label ID="Label2" runat="server" Text="Elige una nueva contraseña segura." Font-Names="FuturaStd-Book" 
                            Font-Size="14px" ForeColor="#666666"></asp:Label>
    </td><td></td><td></td><td></td></tr>
    <tr><td style="height:10px;"></td><td>            
                            <asp:Label ID="Label28" runat="server" Font-Names="FuturaStd-Book" 
                                Font-Size="14px" ForeColor="#FF0033" 
            Text="(*)Campos obligatorios"></asp:Label>
    </td><td></td><td></td><td></td></tr>
    <tr><td style="height:10px;"></td><td>            
    </td><td></td><td></td><td></td></tr>
    <tr><td></td><td colspan="3"> 
    <table class="tablaSinbordes"><tr><td><asp:Label ID="lblCE" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                <asp:Label ID="lblFechaNac" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" 
             Text="Contraseña actual" Width="150px"></asp:Label></td><td></td><td>
        <asp:TextBox ID="txtContraseñaActual" runat="server" Width="250px" Height="25" 
            BorderWidth="0" Font-Names="FuturaStd-Book" 
                 Font-Size="14px" ForeColor="#666666" TextMode="Password"></asp:TextBox></td></tr></table>                    
    </td><td></td></tr>
     <tr><td style="height:10px;"></td><td>            
    </td><td></td><td></td><td></td></tr>
     <tr><td></td><td colspan="3">            
         <table class="tablaSinbordes">
             <tr>
                 <td>
                     <asp:Label ID="lblCE2" runat="server" Font-Names="FuturaStd-Bold" 
                         Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                     <asp:Label ID="lblFechaNac2" runat="server" Font-Names="FuturaStd-Bold" 
                         Font-Size="14px" ForeColor="#666666" Text="Contraseña nueva" Width="150px"></asp:Label>
                 </td>
                 <td>
                 </td>
                 <td>
                     <asp:TextBox ID="txtNuevaContraseña" runat="server" BorderWidth="0" 
                         Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#666666" Height="25" 
                         TextMode="Password" Width="250px"></asp:TextBox>
                 </td>
             </tr>
         </table>
    </td><td></td></tr>
     <tr><td style="height:10px;"></td><td>            
    </td><td></td><td></td><td></td></tr>
     <tr><td></td><td colspan="3">            
         <table class="tablaSinbordes">
             <tr>
                 <td>
                     <asp:Label ID="lblCE3" runat="server" Font-Names="FuturaStd-Bold" 
                         Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                     <asp:Label ID="lblFechaNac3" runat="server" Font-Names="FuturaStd-Bold" 
                         Font-Size="14px" ForeColor="#666666" Text="Coonfirmar contraseña nueva" 
                         Width="150px"></asp:Label>
                 </td>
                 <td>
                 </td>
                 <td>
                     <asp:TextBox ID="txtConfirmaContraseña" runat="server" BorderWidth="0" 
                         Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#666666" Height="25" 
                         TextMode="Password" Width="250px"></asp:TextBox>
                 </td>
             </tr>
         </table>
    </td><td></td></tr>
     <tr><td style="height:10px;"></td><td>            
    </td><td></td><td></td><td></td></tr>
     <tr><td style="height:10px;"></td><td colspan="3">            
        <table class="tablaSinbordes"><tr><td> <asp:ImageButton ID="btnRegresar" runat="server" 
             
                ImageUrl="~/Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-regresar.jpg" 
                onclick="btnRegresar_Click" /></td><td style="width:20px;"></td><td>
            <asp:ImageButton ID="btnGuardar" runat="server" 
             
                ImageUrl="~/Imagenes_Benavides/MasterNueva/13-cambiar_contrasena/btn-guardar.jpg" 
                onclick="btnGuardar_Click" /></td></tr></table>
    </td><td></td></tr>
     <tr><td style="height:30px;"></td><td>            
    </td><td></td><td></td><td></td></tr>
</table>
</td></tr>
</table>
</td></tr></table>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>