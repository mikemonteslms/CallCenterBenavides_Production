<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmarCorreo.aspx.cs" Inherits="WebPfizer.LMS.eCard.ConfirmarCorreo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 139px;
            background-color: #FFF;
            border: 1px solid transparent;            
            width: 300px;
            font: 12pt 'Futura-std Bold';
        }
        .boton
        {
            Border: 0;
            background-color:transparent;
            color: #48C7F3;
            font: 12pt Arial, Helvetica;
            font-weight: bold;            
            letter-spacing: 3;            
        }        
    </style>
    <script type="text/javascript" language="javascript">
        function habilitar() {
            var fila = document.getElementById("trActualiza");
            var fila2 = document.getElementById("trActualiza2");
            fila.style.display = '';
            fila2.style.display = '';
        }
    </script>
</head>
<body style="background:#2C347D">
    <form id="form1" runat="server">    
    <table style="width: 550px; background-image:url('ImagenesVerBoom/Master/Confirmacion.jpg'); height: 410px; background-repeat:no-repeat;">
        <tr style="">
            <td style="width:15px"></td>
            <td colspan="4">                               
                    <div style="margin-top:-165px; position:absolute"><span style="font: 25pt Arial,Helvetica; font-weight: bold; word-spacing:2px; color: #fff;">para disfrutar <br />de más beneficios <br />confirma tus datos</span></div>
                    <div style="margin-top:-0px; position:absolute">
                    <span style="font: 12pt Arial,Helvetica; font-weight: bold;  word-spacing:2px; color: #fff;">Si la dirección de tu correo electrónico es<br />correcta, da clic en enviar</span><br />
                    <asp:TextBox ID="txtCorreo" runat="server" Enabled="false" CssClass="style1"></asp:TextBox><br />
                    <asp:Button ID="btnEnviar" runat="server" Text="enviar" CssClass="boton" style="cursor:pointer; text-align:left" onclick="btnEnviar_Click"/><br /></div>
                    <div style="margin-top:100px; position:absolute"><span style="font: 11pt Arial,Helvetica; color: #fff;">Si la dirección de tu correo electrónico no<br />es correcta, actualízalo <a onclick="javascript:return habilitar();" style="color:#48C7F3;font: 12pt Arial, Helvetica;font-weight: bold;letter-spacing: 3;">aquí</a>.</span>
                    <br /><br />
                    <table>
                        <tr id="trActualiza" style="display:none" runat="server">                        
                            <td ><asp:TextBox ID="txtNewMail" runat="server" Enabled="true" CssClass="style1"></asp:TextBox>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNewMail" Display="Dynamic" 
                                        ErrorMessage="El correo electrónico no tiene el formato correcto." ToolTip="El correo electrónico no tiene el formato correcto." 
                                        ValidationGroup="newMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                            </td>                        
                        </tr>             
                        <tr id="trActualiza2" style="display:none;background:#2C347D" runat="server">                                                           
                            <td style="background:#2C347D">
                                <asp:Button ID="Button1" runat="server" Text="actualizar" CssClass="boton" style="cursor:pointer; text-align:left" ValidationGroup="newMail" onclick="Button1_Click"/>
                            </td>
                        </tr>
                    </table>
                    </div>                
             </td>
        </tr>               
    </table>
    </form>
</body>
</html>
