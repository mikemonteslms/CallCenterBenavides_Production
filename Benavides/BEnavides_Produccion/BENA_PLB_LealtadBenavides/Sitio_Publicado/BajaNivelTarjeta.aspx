<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BajaNivelTarjeta.aspx.cs" Inherits="WebPfizer.LMS.eCard.BajaNivelTarjeta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="EstilosBenavides.css" rel="stylesheet" type="text/css" />
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-43180890-1', 'beneficiointeligente.com.mx');
        ga('send', 'pageview');
    </script>
     <script type="text/javascript" language="javascript">
         function diHola(mensaje, pagina) {
             alert(mensaje);
             window.location.href = (pagina);
         }
    </script>    
    <title>Baja Nivel Tarjeta</title>  
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <div id="fondo" style="background-image: url(Imagenes_Benavides/registro-acceso-fondo.jpg);
            width: 1010px; height: 756px; background-repeat: no-repeat;">
             
            <center>
           
                <table style="width: 1020px">
                    <tr>
                        <td style="width: 60px; height: 50px">
                        </td>
                        <td style="width: 20px">
                        </td>
                        <td style="width: 100px">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
                        </td>
                        <td style="width: 16px">
                        </td>
                        <td colspan="2" align="right">
                            <img src="Imagenes_Benavides/logo-benavides.png" />
                        </td>
                        <td style="width: 60px">
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                 <asp:Panel ID="Panel2" runat="server" BackImageUrl="~/Imagenes_Benavides/SaldoMov-fondo.png" Height="600px"
                CssClass="panelReportes">
              <div id="divCarga" runat="server">
              <br />
                <table width="550px">
                    <tr>
                        <td >
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <asp:Button ID="btnUpload" runat="server" Text="Cargar"
                                OnClick="btnUpload_Click" />
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="Has Header ?" Visible="False" />
                                <asp:RadioButtonList ID="rbHDR" runat="server" Visible="False">
                                <asp:ListItem Text = "Yes" Value = "Yes" Selected = "True" >
                                </asp:ListItem>
                                <asp:ListItem Text = "No" Value = "No"></asp:ListItem>
                                </asp:RadioButtonList>
                                <br />
                                <asp:Panel ID ="ScrollablePanel" runat ="server" ScrollBars ="Auto" Height="350"  
                                Width ="800" BackColor ="Transparent">
                                <asp:GridView ID="GVArchivo" runat="server" ShowHeader="false" 
                                    BackColor="#F7F6F3" Width="800px" 
                                        onpageindexchanging="GVArchivo_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <HeaderStyle BackColor="#174287" Font-Names="Arial" Font-Size="10pt" 
                                        ForeColor="White" />
                                    <RowStyle Font-Names="Arial" Font-Size="10pt" />
                                </asp:GridView>
                                </asp:Panel>                                
                         </td>
                    </tr>
                    <tr>
                    <td>&nbsp;</td>
                        
                    </tr>
                   
                    <tr>
                        <td>
                            
                            <asp:Label ID="lblNumFilas" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                   
                    </table>
                    </div>
                     <div>
        
         <script type="text/javascript">
             // Get the instance of PageRequestManager.
             var prm = Sys.WebForms.PageRequestManager.getInstance();
             // Add initializeRequest and endRequest
             prm.add_initializeRequest(prm_InitializeRequest);
             prm.add_endRequest(prm_EndRequest);

             // Called when async postback begins
             function prm_InitializeRequest(sender, args) {
                 // get the divImage and set it to visible
                 var panelProg = $get('divImage');
                 panelProg.style.display = '';
                 // reset label text
                 var lbl = $get('<%= this.lblText.ClientID %>');
                 lbl.innerHTML = '';

                 // Disable button that caused a postback
                 $get(args._postBackElement.id).disabled = true;
             }

             // Called when async postback ends
             function prm_EndRequest(sender, args) {
                 // get the divImage and hide it again
                 var panelProg = $get('divImage');
                 panelProg.style.display = 'none';

                 // Enable button that caused a postback
                 $get(sender._postBackSettings.sourceElement.id).disabled = false;
             }
         </script>
 
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
                <div id="divImage" style="display:none">                
                     <asp:Image ID="img1" runat="server" ImageUrl="~/Images/loader.gif" />
                     Guardando....
                </div>                
                <br />
               <asp:Button ID="btnInsertar" runat="server" 
                                Text="Guardar en Base de Datos" Visible="False" 
                                onclick="btnInsertar_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>                 
                    <br />                    
                    </asp:Panel>
                
            </center>
           
            <br />
            <br />           

            <table width="1010">
                <tr>
                    <td style="width: 20px">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20px">
                    </td>
                    <td align="center">
                        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Target="_blank" Font-Names="Arial"
                            Font-Size="8pt" ForeColor="#004A99" NavigateUrl="~/Terminos.aspx">Terminos y Condiciones</asp:HyperLink>
                        <asp:Label ID="Label4" runat="server" Text="|" Font-Bold="True" ForeColor="#004A99"></asp:Label>
                        <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Target="_blank" Font-Names="Arial"
                            Font-Size="8pt" ForeColor="#004A99" NavigateUrl="~/AvisoPrivacidad.aspx">Aviso de Privacidad</asp:HyperLink>
                    </td>
                    <td style="width: 20px">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="3" align="center">
                        <asp:Label ID="Label6" runat="server" Font-Size="8pt" ForeColor="Silver" Text="Copyright 2013 Farmacias Benavides. Todos los derechos reservados"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        </form>
    </center>
    
</body>
</html>
