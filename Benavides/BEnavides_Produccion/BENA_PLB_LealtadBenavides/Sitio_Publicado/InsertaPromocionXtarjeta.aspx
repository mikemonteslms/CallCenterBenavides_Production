<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertaPromocionXtarjeta.aspx.cs" Inherits="WebPfizer.LMS.eCard.InsertaPromocionXtarjeta" %>
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

        ga('create', 'UA-43180890-1', 'beneficiointeligente.com.mx');
        ga('send', 'pageview');
    </script>
     <script type="text/javascript">
         function ValidaSoloNumeros() {
             if ((event.keyCode < 48) || (event.keyCode > 57))
                 event.returnValue = false;
         }

         function txNombres() {
             if ((event.keyCode != 32) && (event.keyCode < 65) || (event.keyCode > 90) && (event.keyCode < 97) || (event.keyCode > 122))
                 event.returnValue = false;
         }
    </script>
    <title>Inserta promoción por tarjeta</title>
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
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblTarjeta" runat="server" Font-Bold="True" 
                                ForeColor="#004A99" Text="Tarjeta"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td align="left" >                           
                            <asp:RadioButtonList ID="rblTarjeta" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="rblTarjeta_SelectedIndexChanged">
                            <asp:ListItem Value="*">Seleccionar todas</asp:ListItem>
                            <asp:ListItem Value="1">Teclear tarjeta</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                        <td align="left" valign="bottom">
                            <asp:TextBox ID="txtTarjeta" runat="server" Visible="False" MaxLength="13"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblTarjeta0" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Sexo"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td align="left" colspan="2">
                            <asp:RadioButtonList ID="rblSexo" runat="server">
                                <asp:ListItem Value="0">Masculino</asp:ListItem>
                                <asp:ListItem Value="1">Femenino</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                     <tr>
                         <td align="right" style="width: 20%">
                             &nbsp;</td>
                         <td align="left" style="width: 20%">
                             <asp:Label ID="lblTarjeta1" runat="server" Font-Bold="True" Font-Names="Arial" 
                                 Font-Size="12pt" ForeColor="#004A99" Text="Tipo Promoción"></asp:Label>
                         </td>
                         <td align="left" colspan="2">
                             <asp:RadioButtonList ID="rblTipoPromo" runat="server" AutoPostBack="True" 
                                 onselectedindexchanged="rblTipoPromo_SelectedIndexChanged">
                                 <asp:ListItem Value="0">Promoción Normal</asp:ListItem>
                                 <asp:ListItem Value="1">Promoción App</asp:ListItem>
                             </asp:RadioButtonList>
                         </td>
                     </tr>
                     <tr>
                         <td align="right" style="width: 20%">
                             &nbsp;</td>
                         <td align="left" style="width: 20%">
                             <asp:Label ID="lblFInicio0" runat="server" Font-Bold="True" Font-Names="Arial" 
                                 Font-Size="12pt" ForeColor="#004A99" Text="Cupon"></asp:Label>
                         </td>
                         <td align="left" colspan="2">
                             <asp:TextBox ID="txtCupon" runat="server" Width="200px" MaxLength="20"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right" style="width: 20%">
                             &nbsp;</td>
                         <td align="left" style="width: 20%">
                             <asp:Label ID="lblFInicio1" runat="server" Font-Bold="True" Font-Names="Arial" 
                                 Font-Size="12pt" ForeColor="#004A99" Text="NSE"></asp:Label>
                         </td>
                         <td style="width: 50%; text-align: left" colspan="2">
                             <asp:TextBox ID="txtNSE" runat="server" Width="200px" MaxLength="20"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right" style="width: 20%">
                             &nbsp;</td>
                         <td align="left" style="width: 20%">
                             <asp:Label ID="lblFInicio3" runat="server" Font-Bold="True" Font-Names="Arial" 
                                 Font-Size="12pt" ForeColor="#004A99" Text="Edad Inicial"></asp:Label>
                         </td>
                         <td style="width: 50%; text-align: left" colspan="2">
                             <asp:TextBox ID="txtEdadInicial" runat="server" Width="200px" MaxLength="3"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right" style="width: 20%">
                             &nbsp;</td>
                         <td align="left" style="width: 20%">
                             <asp:Label ID="lblFInicio4" runat="server" Font-Bold="True" Font-Names="Arial" 
                                 Font-Size="12pt" ForeColor="#004A99" Text="Edad Final"></asp:Label>
                         </td>
                         <td style="width: 50%; text-align: left" colspan="2">
                             <asp:TextBox ID="txtEdadFinal" runat="server" Width="200px" MaxLength="3"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right" style="width: 20%">
                             &nbsp;</td>
                         <td align="left" style="width: 20%">
                             <asp:Label ID="lblFInicio5" runat="server" Font-Bold="True" Font-Names="Arial" 
                                 Font-Size="12pt" ForeColor="#004A99" Text="Descripcion"></asp:Label>
                         </td>
                         <td style="width: 50%; text-align: left" colspan="2">
                             <asp:TextBox ID="txtDescripcion" runat="server" Width="200px"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right" style="width: 20%">
                             &nbsp;</td>
                         <td align="left" style="width: 20%">
                             <asp:Label ID="lblFInicio" runat="server" Font-Bold="True" Font-Names="Arial" 
                                 Font-Size="12pt" ForeColor="#004A99" Text="Fecha Inicio"></asp:Label>
                         </td>
                         <td style="width: 50%; text-align: left" colspan="2">
                             <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="8" 
                                 ValidationGroup="Fechas" Width="200px"></asp:TextBox>
                             <cc1:CalendarExtender ID="ceFehaInicio" runat="server" Format="yyyyMMdd" 
                                 PopupButtonID="ImgCalendario" TargetControlID="txtFechaInicio">
                             </cc1:CalendarExtender>
                             <asp:ImageButton ID="ImgCalendario" runat="server" CausesValidation="False" 
                                 ImageUrl="~/images/Calendario.png" />
                         </td>
                     </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="left" style="width: 20%">
                            <asp:Label ID="lblFFin" runat="server" Font-Bold="True" ForeColor="#004A99" Text="Fecha Fin"
                                Font-Size="12pt" Font-Names="Arial"></asp:Label>
                        </td>
                        <td style="width: 50%; text-align: left" colspan="2">
                           <asp:TextBox ID="txtFechaFin" runat="server" Width="200px" MaxLength="8"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaFin" PopupButtonID="imgCalendario2"
                                            Format="yyyyMMdd">
                                        </cc1:CalendarExtender>
                                        <asp:ImageButton ID="imgCalendario2" runat="server" ImageUrl="~/images/Calendario.png" CausesValidation="False"/>
                        </td>
                    </tr>
                    <div id="divImagenes" runat="server" visible="false">
                     <tr>
                         <td align="right" style="width: 20%">
                             &nbsp;</td>
                         <td align="left" style="width: 20%">
                             <asp:Label ID="lblFFin0" runat="server" Font-Bold="True" Font-Names="Arial" 
                                 Font-Size="12pt" ForeColor="#004A99" Text="Imagen Preview"></asp:Label>
                         </td>
                         <td style="width: 50%; text-align: left" colspan="2">
                             <asp:FileUpload ID="fileUploader1" runat="server" />
                         </td>
                     </tr>
                     <tr>
                         <td align="right" style="width: 20%">
                             &nbsp;</td>
                         <td align="left" style="width: 20%">
                             <asp:Label ID="lblFFin1" runat="server" Font-Bold="True" Font-Names="Arial" 
                                 Font-Size="12pt" ForeColor="#004A99" Text="Imagen Detalle"></asp:Label>
                         </td>
                         <td style="width: 50%; text-align: left" colspan="2">
                             <asp:FileUpload ID="fileUploader2" runat="server" />
                         </td>
                     </tr>
                     </div>
                    <tr>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td align="right" style="width: 20%">
                            &nbsp;</td>
                        <td style="width: 50%; text-align: left" colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
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
  
