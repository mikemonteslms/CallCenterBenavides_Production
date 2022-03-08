<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteReenvioMailB.aspx.cs" Inherits="WebPfizer.LMS.eCard.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
       <script type="text/javascript">
           function ValidarContenido() {
               var tarjeta = document.getElementById("<%=txtTarjeta.ClientID %>");
               var correo = document.getElementById("<%=txtCorreo.ClientID %>");

               if (tarjeta.value.length < 1 && correo.value.length < 1) {
                   alert('Debes escribir algún criterio de busqueda.')
                   return false;
               }
               else
               {
                   if (Page_ClientValidate("busqueda"))
                       return true;
                   else
                       return false;
               }
           }
       </script>
    <style type="text/css">
        .overlay  
        {
            position: fixed;
            z-index: 98;
            top: 0px;
            left: 0px;
            right: 0px;
            bottom: 0px;
            background-color: #aaa; 
            filter: alpha(opacity=80); 
            opacity: 0.8; 
        }
        .overlayContent
        {
            z-index: 99;
            margin: 250px auto;
            width: 32px;
            height: 32px;
        }
        .fuenteReporte
        {
            font-family: Arial Narrow;
            font-size: 15px;
        }
        .titulo
        {
            font-family: Arial;
            font-size: 16pt;
            color: #004A99;
        }
    </style>
    <title>Reenvio de correo Bienvenida</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Calendar.css" rel="stylesheet" type="text/css" media="screen" />
</head>
<body>
<center>
    <form id="form1" runat="server">       
        <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: 100%; background-repeat: no-repeat;">
            <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
            <asp:Panel ID="Panel2" runat="server" BackColor="#EBEBEB" >
                <div>
                    <span class="titulo">Reenvio de correo de bienvenida</span><br /><br />
                </div>
                <table>
                    <tr>
                        <td class="fuenteReporte" style="text-align:left">
                            <span style="color:#2B347A">Tarjeta:</span>
                        </td>
                        <td style="text-align:left">
                            <asp:TextBox ID="txtTarjeta" runat="server"></asp:TextBox>                                                            
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txtTarjeta" Display="Dynamic" 
                                ErrorMessage="El número de tarjeta debe ser de 11 digitos" 
                                ValidationExpression="[0-9]{11}" ValidationGroup="busqueda">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="fuenteReporte" style="text-align:left">
                            <span style="color:#2B347A">Correo electrónico:</span>
                        </td>
                        <td style="text-align:left">
                            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="txtCorreo" Display="Dynamic" 
                                ErrorMessage="El correo electrónico no tiene un formato correcto." 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                ValidationGroup="busqueda">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td></td> 
                        <td style="text-align:right;">
                            <asp:Button Text="Buscar..." runat="server" ID="btnBuscar" ValidationGroup="busqueda"
                                onclick="btnBuscar_Click"  OnClientClick=" return ValidarContenido();"  /><asp:ImageButton ID="btnCancelar" runat="server" Height="30px" Width="30px" ImageUrl="~/Imagenes_Benavides/botones/undo.png" PostBackUrl="~/Home.aspx" />
                        </td>
                    </tr>
                    <tr>                        
                        <td style="text-align:left;" class="fuenteReporte" colspan="2">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                CssClass="fuenteReporte" DisplayMode="List" ValidationGroup="busqueda" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:GridView runat="server" ID="grvCLiente" 
                    EmptyDataText="No hay datos que mostrar" PageSize="20" Font-Size="11px" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" 
                    BorderWidth="1px" CellPadding="3" ondatabound="grvCLiente_DataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Enviar" >
                            <ItemTemplate>
                                <asp:CheckBox ID="chkEnviar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#0154A0" CssClass="fuenteReporte" Font-Bold="True" ForeColor="White" Font-Size="15px" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000000" CssClass="fuenteReporte" Font-Size="13px" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Mode="Numeric" FirstPageText="Inicio" NextPageText="Siguiente" PreviousPageText="Anterior" LastPageText="Final" Position="Bottom" PageButtonCount="20" />
                </asp:GridView>
                <br /><br />
                <span style="color: Red;"><asp:Label ID="lblMensaje" runat="server" CssClass="fuenteReporte" Font-Size="14pt"></asp:Label></span>
                <br /><br />
                <asp:GridView ID="grvResultado" runat="server" EmptyDataText="No hay datos que mostrar" PageSize="100" AutoGenerateColumns="True" Font-Size="11px" BackColor="White" 
                    BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" onpageindexchanging="grvResultado_PageIndexChanging">
                    <HeaderStyle BackColor="#0154A0" CssClass="fuenteReporte" Font-Bold="True" ForeColor="White" Font-Size="15px" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000000" CssClass="fuenteReporte" HorizontalAlign="Left" Font-Size="13px" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Mode="Numeric" FirstPageText="Inicio" NextPageText="Siguiente" PreviousPageText="Anterior" LastPageText="Final" Position="Bottom" PageButtonCount="20" />
                </asp:GridView>
                <br /><br />
                <div style="float: right; margin-right: 70px;"><asp:Button ID="btnReenviar" 
                        runat="server" Text="Reenviar correo Bienvenida" onclick="btnReenviar_Click" Enabled="false"/></div>
                <br /><br />
            </asp:Panel>
        </div>
    </form>
</center>
</body>
</html>

