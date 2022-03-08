<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertaPromocion.aspx.cs" Inherits="WebPfizer.LMS.eCard.InsertaPromocion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
    <title>Inserta Promoción</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
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
                                <asp:Panel ID ="ScrollablePanel" runat ="server" ScrollBars ="Auto"  
                                Width ="800" BackColor ="Transparent"><br />
                                <asp:GridView ID="GridView1" runat="server"
                                OnPageIndexChanging = "PageIndexChanging" AllowPaging = "true" 
                                    BackColor="#F7F6F3" Width="800px">
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
                            <asp:Button ID="btnInsertar" runat="server" onclick="btnInsertar_Click" 
                                Text="Guardar en Base de Datos" Visible="False" />
                        </td>
                    </tr>
                   
                    </table>
                    </div>
                    <br />
                    <div id="divPromocion" runat="server" visible="false">
                <table width="550px">
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblDescripcion" runat="server" Font-Bold="True" 
                                ForeColor="#004A99" Text="Descripcion"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                            <asp:TextBox ID="txtDescripcion" runat="server" Width="200px" MaxLength="200"></asp:TextBox>
                            &nbsp
                            </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblFInicio" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Fecha Inicio"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                           <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="8" 
                                  ValidationGroup="Fechas" Width="200px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="ceFehaInicio" runat="server" TargetControlID="txtFechaInicio" PopupButtonID="ImgCalendario"
                                            Format="yyyyMMdd">
                                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="ImgCalendario" runat="server" ImageUrl="~/images/Calendario.png" CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblFFin" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Fecha Fin"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                           <asp:TextBox ID="txtFechaFin" runat="server" Width="200px" MaxLength="8"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaFin" PopupButtonID="imgCalendario2"
                                            Format="yyyyMMdd">
                                        </cc1:CalendarExtender>
                                        <asp:ImageButton ID="imgCalendario2" runat="server" ImageUrl="~/images/Calendario.png" CausesValidation="False"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblEstatus" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Estatus"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                          
                            <asp:DropDownList ID="ddlEstatus" runat="server" Width="200px">
                            <asp:ListItem Text="Seleccione" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Porcentaje" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Dinero Electrónico" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                          
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblUsuario" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Usuario"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left">
                            <asp:TextBox ID="txtUsuario" runat="server" Width="200px" MaxLength="19" 
                                Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td style="width: 50%; text-align: left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            <asp:ImageButton ID="btnCancelar" runat="server" 
                                ImageUrl="~/Imagenes_Benavides/botones/cancelar-btn.png" 
                                onclick="btnCancelar_Click" />
                            &nbsp;&nbsp;
                            <asp:ImageButton ID="btnEnviar" runat="server" 
                                ImageUrl="~/Imagenes_Benavides/botones/enviar-btn.png" 
                                onclick="btnEnviar_Click" />
                        </td>
                    </tr>
                    </table>
                    </div>
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
    <
</body>
</html>
