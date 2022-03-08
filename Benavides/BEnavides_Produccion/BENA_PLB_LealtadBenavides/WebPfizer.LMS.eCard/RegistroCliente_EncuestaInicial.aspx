<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroCliente_EncuestaInicial.aspx.cs" Inherits="WebPfizer.LMS.eCard.RegistroCliente_EncuestaInicial" %>

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

    <script type="text/javascript" language="javascript">
      function diHola(mensaje, pagina) {
          alert(mensaje);
          window.location.href = (pagina);
      }
</script>

    <title>Registro Cliente</title>
    <link href="EstilosBenavides.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Styles/MisEstilos.css" rel="stylesheet" type="text/css" />
    
    </head>
<body>

    <form id="form1" runat="server">
      
     <!--         
     <div id="divPeques" runat="server" visible="false">
                                <asp:Panel ID="pnlPeques" runat="server" BackColor="AliceBlue">
                                    <table >
                                        <tr>
                                            <td>
                                               <div>
   
    </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <cc1:ModalPopupExtender ID="mpePeques" runat="server" PopupControlID="pnlPeques"
                                    TargetControlID="rblPeques" DynamicServicePath="" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                            </div>
    !-->
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
   <table align="center">
   <tr><td>
     <table border="0" style="border-style: none; width:1200px; background-color: #E6E6E6; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;" >
            <tr>
            <td style="width:100px;"></td>
            <td>
            <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">                   
         <tr>
             <td align="left" style="height:40px;">
                 </td>                        
         </tr>
         <tr>
             <td align="left">
                 <asp:Label ID="lblRegistro" runat="server" Text="Registro" Font-Names="FuturaStd-Bold"  Font-Size="22px" ForeColor="#666666"></asp:Label></td>                        
         </tr>
         <tr>
             <td style="height:50px;">
                                <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"
                                    EnableScriptGlobalization="true" EnableScriptLocalization="true">
                                </asp:ScriptManager>
                                </td>             
         </tr>
         <tr><td align="left">
         <asp:Label ID="lblT" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                    <asp:Label ID="lblTarjeta" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" Text="Tarjeta"></asp:Label></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td><table><tr><td><asp:TextBox ID="txtTarjeta" runat="server" 
                 CssClass="CajaTextoRegistroPeque" MaxLength="11" ></asp:TextBox></td><td>
                                <asp:LinkButton ID="lnkValidarT" runat="server" onclick="lnkValidarT_Click" CssClass="linksBenaRecupera">Validar Tarjeta</asp:LinkButton>
                                <asp:ImageButton ID="btnValidar" runat="server" 
                 onclick="btnValidar_Click" 
                 ImageUrl="~/Imagenes_Benavides/MasterNueva/8-registro/img-check-25x25.png" Visible="False" />
                                </td></tr></table>
         </td></tr>
         <tr>
             <td style="height:20px;">
                 </td>             
         </tr>
          <tr><td align="left">
         <asp:Label ID="lblG" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                    <asp:Label ID="lblGenera" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#2B347A" Text="Generar contraseña"></asp:Label></td></tr>
         <tr>
             <td style="height:20px;">
                 </td>             
         </tr>
         <tr><td align="left">
         <asp:Label ID="lblC" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                <asp:Label ID="lblContra" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" Text="Contraseña"></asp:Label></td></tr>
        <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"> 
             <asp:TextBox ID="txtContra" runat="server" 
                 CssClass="CajaTextoRegistroPeque" TextMode="Password" Enabled="False" ></asp:TextBox></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left">
         <asp:Label ID="lblCo" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                <asp:Label ID="lblConfirma" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" Text="Confirmar contraseña"></asp:Label></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left">
             <asp:TextBox ID="txtConfirmaContra" runat="server" 
                 CssClass="CajaTextoRegistroPeque" TextMode="Password" Enabled="False"></asp:TextBox></td></tr>
          <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
          <tr><td align="left">
         <asp:Label ID="lblN" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                <asp:Label ID="lblNombre" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" Text="Nombre(s)"></asp:Label></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"><asp:TextBox ID="txtNombre" runat="server" 
                 CssClass="CajaTextoRegistroPeque" Enabled="False"></asp:TextBox></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left">
         <asp:Label ID="lblA" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                <asp:Label ID="lblAP" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" Text="Apellido paterno"></asp:Label></td></tr>
        <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"><asp:TextBox ID="txtPaterno" runat="server" 
                 CssClass="CajaTextoRegistroPeque" Enabled="False"></asp:TextBox></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
          <tr><td align="left">
         <asp:Label ID="lblM" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                <asp:Label ID="lblAM" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" Text="Apellido materno"></asp:Label></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"> <asp:TextBox ID="txtMaterno" runat="server" 
                 CssClass="CajaTextoRegistroPeque" Enabled="False"></asp:TextBox>
                                </td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
          <tr><td align="left">
         <asp:Label ID="lblCE" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                <asp:Label ID="lblCorreo" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" Text="Correo electrónico"></asp:Label></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"><table><tr><td><asp:TextBox ID="txtMail" runat="server" 
                 Width="147px" Height="25" BorderWidth="0" Font-Names="FuturaStd-Book" 
                 Font-Size="14px" ForeColor="#666666" Enabled="False"></asp:TextBox>
         </td><td><asp:Label ID="Label1" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" Text="@"></asp:Label></td><td>
                                <asp:DropDownList ID="ddlDominios" runat="server" AutoPostBack="True" 
                                    Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#666666"
                                    Width="140px" Height="25px" BorderWidth="0"
                            onselectedindexchanged="ddlDominios_SelectedIndexChanged" Enabled="False">
                               
                                </asp:DropDownList>
                        </td></tr></table></td></tr>
                <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
        <tr><td align="left"><table><tr><td><asp:Label ID="lblEscribaDominio" runat="server" Font-Names="FuturaStd-Book" 
                            Font-Size="14px" ForeColor="#666666" 
                Text="Escriba el dominio de su correo" Visible="False"></asp:Label></td><td>
                        <asp:TextBox ID="txtDominio" runat="server" Width="120px" 
                            Font-Names="FuturaStd-Book" Font-Size="14px" Height="25" BorderWidth="0" 
                             Visible="False" Enabled="False"></asp:TextBox>
                        </td></tr></table></td></tr>
        <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
          <tr><td align="left">     
                <asp:Label ID="lblCel" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" Text="Teléfono celular (10 digitos)"></asp:Label></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"><table><tr><td><asp:TextBox ID="txtCelular" 
                 runat="server" CssClass="CajaTextoRegistroPeque" MaxLength="10" BorderWidth="0"                   
                 Enabled="False"></asp:TextBox>
                        </td></tr></table></td></tr>
        <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
          <tr><td align="left">
         <asp:Label ID="lblFecha" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                <asp:Label ID="lblFechaNac" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" Text="Fecha de nacimiento"></asp:Label></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left">
                        <table><tr><td >
                        <asp:DropDownList ID="ddlAno" runat="server" Width="85px"  BorderWidth="0"
                            Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" OnSelectedIndexChanged="ddlAno_SelectedIndexChanged" 
                                    AutoPostBack="True" Height="25px" Enabled="False">
                        </asp:DropDownList>
                            </td><td>
                        <asp:DropDownList ID="ddlMes" runat="server" Width="125px"  BorderWidth="0"
                            Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" 
                                    AutoPostBack="True" Height="25px" Enabled="False">
                        </asp:DropDownList>
                            </td><td>
                        <asp:DropDownList ID="ddlDia" runat="server" Width="85px" Font-Names="FuturaStd-Book" 
                                    ForeColor="#666666"  Font-Size="14px" BorderWidth="0"
                        Height="25px" Enabled="False">
                        </asp:DropDownList>
                            </td></tr></table>
                        </td>
         </tr>
     </table>
            </td> 
            <td style="width:40px;"></td>           
            <td>
             <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;"> 
      <tr>
             <td align="left">
                 </td>                        
         </tr>
         <tr>
             <td style="height:50px;">               
                 </td>             
         </tr>
         <tr><td align="left"> 
             <asp:Label ID="lblCo1" runat="server" Font-Names="FuturaStd-Bold" 
                 Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
             <asp:Label ID="Label3" runat="server" CssClass="LabelRegistro" Text="Género"></asp:Label></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left">
             <asp:RadioButtonList ID="rdoGenero" runat="server"  
                                          RepeatDirection="Horizontal" Enabled="False">
                                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-2.png'></asp:ListItem>                                       
                                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-1.png'></asp:ListItem>
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList></td></tr>
          <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
          <tr><td align="left"> 
              <asp:Label ID="lblCo0" runat="server" Font-Names="FuturaStd-Bold" 
                  Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
              <asp:Label ID="lblHijos" runat="server" CssClass="LabelRegistro" Text="¿Tienes hijos?"></asp:Label></td></tr>
           <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"><asp:RadioButtonList ID="rdoHijos" runat="server" 
                 Font-Names="FuturaStd-Book" Font-Size="14px"
                                        RepeatDirection="Horizontal" ForeColor="#666666" 
                 AutoPostBack="True" Enabled="False">
                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:RadioButtonList></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"> <asp:Label ID="lblCodigoP" runat="server" CssClass="LabelRegistro" Text="Código postal"></asp:Label></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"><table><tr><td>
             <asp:TextBox ID="txtCPVisible" runat="server" CssClass="CajaTextoRegistroPeque" 
             MaxLength="5" Enabled="False" Width="200px"></asp:TextBox>
                                    </td><td>
                                    <asp:LinkButton ID="LnkVaidaCP" runat="server" CssClass="linksBenaRecupera" 
                                        onclick="LnkVaidaCP_Click">Validar C.P.</asp:LinkButton>
                                    <asp:ImageButton ID="btnValidarCP" runat="server" 
                                        onclick="btnValidarCP_Click" 
                     ImageUrl="~/Imagenes_Benavides/MasterNueva/8-registro/img-check-25x25.png" Enabled="False" 
                                        Visible="False" />
                                </td></tr></table></td></tr>
        <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"> <asp:Label ID="lblEstado" runat="server" CssClass="LabelRegistro" Text="Estado"></asp:Label></td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"><asp:DropDownList ID="ddlEstado" runat="server" Width="315px" 
                 Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#666666"
                 Height="25px" BorderWidth="0"
                    AutoPostBack="True" 
                 OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" Enabled="False">
                            </asp:DropDownList>
                            </td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"> <asp:Label ID="lblCiudad" runat="server" CssClass="LabelRegistro" Text="Ciudad"></asp:Label></td></tr>
          <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"> <asp:DropDownList ID="ddlCiudad" runat="server" Width="315px" Font-Names="FuturaStd-Book" Font-Size="14px" ForeColor="#666666"
                 Height="25px" BorderWidth="0"
                    AutoPostBack="True" Enabled="False">
                            </asp:DropDownList>
                            </td></tr>
        <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
          <tr><td align="left"> <asp:Label ID="lblCatego" runat="server" CssClass="LabelRegistro" Text="¿Cúales son las categorias de tu interés?"></asp:Label></td></tr>
          <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left">
                                                <asp:CheckBoxList ID="chkCategorias" runat="server" Font-Names="FuturaStd-Book" 
                                                    Font-Size="14px" ForeColor="#666666" Enabled="False">
                                                </asp:CheckBoxList>
                                            </td></tr>
         <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
          <tr><td align="left">
         <asp:Label ID="Label9" runat="server" Font-Names="FuturaStd-Bold"              
                            Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                <asp:Label ID="Label10" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" Text="Quieres pertencer al"></asp:Label></td></tr>
          <tr><td align="left">
              <table><tr><td>
                  <img src="Imagenes_Benavides/MasterNueva/8-registro/img-categorias-logo-140x15.png" /></td><td><asp:Label ID="Label11" runat="server" Font-Names="FuturaStd-Bold" 
                            Font-Size="14px" ForeColor="#666666" Text="?"></asp:Label></td><td style="width:20px;"></td><td>
                  <asp:ImageButton ID="btnMasInfo" runat="server" 
                      ImageUrl="~/Imagenes_Benavides/MasterNueva/8-registro/MasInfo.png" 
                      onclick="btnMasInfo_Click" />
                  </td></tr></table></td></tr>
        <tr>
             <td style="height:10px;">
                 </td>             
         </tr>
         <tr><td align="left"><asp:RadioButtonList ID="rblPeques" runat="server" 
                 Font-Names="FuturaStd-Book" Font-Size="14px"
                                        RepeatDirection="Horizontal" ForeColor="#666666"
                                        AutoPostBack="True" 
                 onselectedindexchanged="rblPeques_SelectedIndexChanged" Enabled="False">
                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:RadioButtonList></td></tr>
     </table>
            </td>
            <td>
                <img class="style3" 
                    src="Imagenes_Benavides/MasterNueva/8-registro/img-registro-tarjeta-platino-235x800.png" /></td>
            <td style="width:100px;">
                </td>
            </tr>
            <tr runat="server" id="trEspacio"><td style="height:30px; display:none"></td><td></td><td></td><td></td><td></td><td></td></tr>
            <tr><td></td><td colspan="4"> <asp:Panel runat="server" ID="panelInscripcion" Visible="false">     
   <table style="background-image: url('Imagenes_Benavides/MasterNueva/8-registro/bg-registro-clubpeques/bg-registro-clubpeques_1.png'); background-repeat: no-repeat; border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;" cellpadding="0" cellspacing="0">
   <tr>
   <td style="width:740px; height:30px;">
   
   </td>
   </tr>
   </table>

   <table style="background-image: url('Imagenes_Benavides/MasterNueva/8-registro/bg-registro-clubpeques/bg-registro-clubpeques_2.png'); background-repeat: repeat-y; width:740px;">
   <tr>
   <td> <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">                   
           <tr>
               <td style="width:270px;">
                   </td>
               <td>
                   <img class="style2" 
                       src="Imagenes_Benavides/MasterNueva/8-registro/img-clubpeques-logo-200x140.png" /></td>
           </tr>
          
           <tr>
               <td style="height:40px;">
                   </td>
               <td>
                    <asp:ImageButton ID="btnCerrarPnl" runat="server" 
                        onclick="btnCerrarPnl_Click" Visible="False" />
                </td>
           </tr>
          
       </table>
   
      <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">                   
           <tr>
               <td>
                   <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">                   
                   <tr><td style="width:35px;"></td><td style="width:315px;">
         <asp:Label ID="Label24" runat="server" Font-Names="FuturaStd-Bold"              
                            Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                    <asp:Label ID="lblPeques1" runat="server" 
                        Text="¿Estas Embarazada?" CssClass="LabelPanelPeque"></asp:Label>
                       </td></tr><tr><td style="width:35px;"></td><td style="height:10px;">
                           </td></tr>
                           <tr><td style="width:35px;"></td><td align="left">
                   <asp:RadioButtonList ID="rblEmbarazo" runat="server" Font-Names="FuturaStd-Book" Font-Size="14px"
                                         RepeatDirection="Horizontal" ForeColor="#2B347A" 
                                   onselectedindexchanged="rblEmbarazo_SelectedIndexChanged" 
                                   AutoPostBack="True">
                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
    </asp:RadioButtonList></td></tr>
    <tr><td style="width:35px;"></td><td style="height:10px;">
                           </td></tr>
                       <tr><td style="width:35px;"></td><td align="left">
                           <asp:Label ID="lblNacera" runat="server" Font-Names="FuturaStd-Bold" 
                               Font-Size="14px" ForeColor="#FF0033" Text="*" Visible="False"></asp:Label>
                           <asp:Label ID="lblPeques21" runat="server" CssClass="LabelPanelPeque" 
                               Text="¿Cuándo nacerá tu bebé?"></asp:Label>
                           </td></tr>
    <tr><td style="width:35px;"></td><td style="height:10px;">
                           </td></tr>
                       <tr><td style="width:35px;"></td><td align="left">
                           <table><tr><td>
                        <asp:DropDownList ID="ddlAnoPeque" runat="server" Width="85px" 
                                   Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px"
                                   BorderWidth="0" Height="25px" AutoPostBack="True" 
                                   onselectedindexchanged="ddlAnoPeque_SelectedIndexChanged">
                        </asp:DropDownList>
                               </td><td style="width:10px;"></td><td>
                        <asp:DropDownList ID="ddlMesPeque" runat="server" Width="125px"  BorderWidth="0"
                            Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px"
                                   AutoPostBack="True" Height="25px" 
                                   onselectedindexchanged="ddlMesPeque_SelectedIndexChanged" Enabled="False">
                        </asp:DropDownList>
                               </td><td style="width:10px;"></td><td>
                        <asp:DropDownList ID="ddlDiaPeque" runat="server" Width="85px"  BorderWidth="0"
                           Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Height="25px" 
                                   Visible="False">
                        </asp:DropDownList>
                               </td></tr></table></td></tr>
<tr><td style="width:35px;"></td><td style="height:10px;">
                           </td></tr>
    
    </table></td>
               <td style="width:35px;">
                   </td>
               <td>
                  <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">                   
                   <tr><td style="height:25px;" valign="top">
         <asp:Label ID="Label26" runat="server" Font-Names="FuturaStd-Bold"              
                            Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                    <asp:Label ID="lblPeques22" runat="server" 
                        Text="¿Tienes hijos menores a 3 años?" CssClass="LabelPanelPeque"></asp:Label>
                       </td></tr>
                       <tr><td style="height:14px;">
                           </td></tr>
                       <tr><td align="left">
                   <asp:RadioButtonList ID="rblTienesHijos" runat="server" Font-Names="FuturaStd-Book" Font-Size="14px"
                                         RepeatDirection="Horizontal" ForeColor="#2B347A" 
                               onselectedindexchanged="rblTienesHijos_SelectedIndexChanged" 
                               AutoPostBack="True">
                                        <asp:ListItem Value="1">Si</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
    </asp:RadioButtonList></td></tr>
    <tr><td style="height:10px;">
                           </td></tr>
                       <tr><td align="left">
                           <asp:Label ID="Label27" runat="server" Font-Names="FuturaStd-Bold" 
                               Font-Size="14px" ForeColor="#FF0033" Text="*"></asp:Label>
                           <asp:Label ID="lblPeques23" runat="server" CssClass="LabelPanelPeque" 
                               Text="¿Cuántos hijos menores a 3 años tienes?"></asp:Label>
                           </td></tr>
    <tr><td style="height:17px;">
                           </td></tr>
                       <tr><td align="left">
                        <asp:DropDownList ID="ddlCuantosHijos" runat="server" Width="130px" BorderWidth="0"
                              Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" 
                                   AutoPostBack="True" Height="25px" 
                               onselectedindexchanged="ddlCuantosHijos_SelectedIndexChanged" 
                               Enabled="False">
                                   <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                                   <asp:ListItem Value="1">1</asp:ListItem>
                                   <asp:ListItem Value="2">2</asp:ListItem>
                                   <asp:ListItem Value="3">3</asp:ListItem>
                                   <asp:ListItem Value="4">4</asp:ListItem>
                        </asp:DropDownList>
                          </td></tr>
    <tr><td style="height:10px;">
                           </td></tr>
    </table></td>
           </tr>
           </table>
           
    
       <table id="tablaH" visible="false" runat="server" cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">                   
           <tr>
               <td style="width:35px;">
                   </td>
               <td>
                           <asp:Label ID="lblPeques24" runat="server" CssClass="LabelPanelPeque" 
                               Text="Nombre(s)"></asp:Label>
                           </td>
               <td style="width:20px;">
                           </td>
               <td>
                           <asp:Label ID="lblPeques25" runat="server" CssClass="LabelPanelPeque" 
                               Text="Fecha de nacimiento"></asp:Label>
                           </td>
               <td style="width:20px;">
                           </td>
               <td>
                           <asp:Label ID="lblPeques26" runat="server" CssClass="LabelPanelPeque" 
                               Text="Genero"></asp:Label>
                           </td>
           </tr>
           <tr>
               <td style="width:35px; height:10px;">
                   </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
           </tr>
           <tr>
               <td>
                   </td>
               <td>
                    <asp:TextBox ID="txtNomH1" runat="server" Height="25px" Width="245px" Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px"
                        BorderWidth="0"></asp:TextBox>
                </td>
               <td>
                    </td>
               <td>
                   <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;"><tr><td>
                        <asp:DropDownList ID="ddlAnoFNP1" runat="server" Width="60px" BorderWidth="0" 
                          Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" 
                            Height="25px" AutoPostBack="True" 
                            onselectedindexchanged="ddlAnoFNP1_SelectedIndexChanged">
                        </asp:DropDownList></td><td style="width:10px;"></td><td>
                        <asp:DropDownList ID="ddlMesFNP1" runat="server" Width="100px" BorderWidth="0" 
                           Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" 
                           AutoPostBack="True" Height="25px" 
                            onselectedindexchanged="ddlMesFNP1_SelectedIndexChanged">
                        </asp:DropDownList>
                        </td><td style="width:10px;"></td><td>
                        <asp:DropDownList ID="ddlDiaFNP1" runat="server" Width="50px" BorderWidth="0" 
                          Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" 
                            Height="25px">
                        </asp:DropDownList>
                        </td></tr></table></td>
               <td>
                   </td>
               <td>
                   <asp:RadioButtonList ID="rdoGeneroP1" runat="server"  
                                          RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-3.png'></asp:ListItem>                                       
                                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-4.png'></asp:ListItem>
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList></td>
           </tr>
           <tr>
               <td style="width:35px; height:10px;">
                   </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
           </tr>
           <tr>
               <td>
                   </td>
               <td>
                    <asp:TextBox ID="txtNomH2" runat="server" Height="25px" Width="245px" Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px"
                        BorderWidth="0" Visible="False"></asp:TextBox>
                </td>
               <td>
                    </td>
               <td>
                   <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">
                       <tr>
                           <td>
                        <asp:DropDownList ID="ddlAnoFNP2" runat="server" Width="60px" BorderWidth="0" 
                         Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Height="25px" 
                                   Visible="False" AutoPostBack="True" 
                                   onselectedindexchanged="ddlAnoFNP2_SelectedIndexChanged">
                        </asp:DropDownList>
                           </td>
                           <td style="width:10px;">
                           </td>
                           <td>
                               <asp:DropDownList ID="ddlMesFNP2" runat="server" AutoPostBack="True"  BorderWidth="0"
                                   Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px"
                                   Width="100px" 
                                   Height="25px" Visible="False" 
                                   onselectedindexchanged="ddlMesFNP2_SelectedIndexChanged">
                               </asp:DropDownList>
                           </td>
                           <td style="width:10px;">
                           </td>
                           <td>
                               <asp:DropDownList ID="ddlDiaFNP2" runat="server"  BorderWidth="0"
                                   Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Width="50px" 
                                   Height="25px" Visible="False">
                               </asp:DropDownList>
                           </td>
                       </tr>
                   </table>
               </td>
               <td>
                   </td>
               <td>
                   <asp:RadioButtonList ID="rdoGeneroP2" runat="server"  
                                          RepeatDirection="Horizontal" Visible="False">
                                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-3.png'></asp:ListItem>                                       
                                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-4.png'></asp:ListItem>
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList></td>
           </tr>
           <tr>
               <td style="width:35px; height:10px;">
                   </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
           </tr>
           <tr>
               <td>
                   </td>
               <td>
                    <asp:TextBox ID="txtNomH3" runat="server" Height="25px" Width="245px" Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px"
                        BorderWidth="0" Visible="False"></asp:TextBox>
                </td>
               <td>
                    </td>
               <td>
                   <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">
                       <tr>
                           <td>
                        <asp:DropDownList ID="ddlAnoFNP3" runat="server" Width="60px"  BorderWidth="0"
                           Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Height="25px" 
                                   Visible="False" AutoPostBack="True" 
                                   onselectedindexchanged="ddlAnoFNP3_SelectedIndexChanged">
                        </asp:DropDownList>
                           </td>
                           <td style="width:10px;">
                           </td>
                           <td>
                               <asp:DropDownList ID="ddlMesFNP3" runat="server" AutoPostBack="True"  BorderWidth="0"
                                   Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Width="100px" 
                                   Height="25px" Visible="False" 
                                   onselectedindexchanged="ddlMesFNP3_SelectedIndexChanged">
                               </asp:DropDownList>
                           </td>
                           <td style="width:10px;">
                           </td>
                           <td>
                               <asp:DropDownList ID="ddlDiaFNP3" runat="server"  BorderWidth="0"
                                   Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Width="50px" 
                                   Height="25px" Visible="False">
                               </asp:DropDownList>
                           </td>
                       </tr>
                   </table>
               </td>
               <td>
                   </td>
               <td>
                   <asp:RadioButtonList ID="rdoGeneroP3" runat="server"  
                                          RepeatDirection="Horizontal" Visible="False">
                                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-3.png'></asp:ListItem>                                       
                                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-4.png'></asp:ListItem>
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList></td>
           </tr>
           <tr>
               <td style="width:35px; height:10px;">
                   </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
               <td>
                           </td>
           </tr>
           <tr>
               <td>
                   </td>
               <td>
                    <asp:TextBox ID="txtNomH4" runat="server" Height="25px" Width="245px" Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px"
                        BorderWidth="0" Visible="False"></asp:TextBox>
                </td>
               <td>
                    </td>
               <td>
                  <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;">
                       <tr>
                           <td>
                        <asp:DropDownList ID="ddlAnoFNP4" runat="server" Width="60px"  BorderWidth="0"
                           Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Height="25px" 
                                   Visible="False" AutoPostBack="True" 
                                   onselectedindexchanged="ddlAnoFNP4_SelectedIndexChanged">
                        </asp:DropDownList>
                           </td>
                           <td style="width:10px;">
                           </td>
                           <td>
                               <asp:DropDownList ID="ddlMesFNP4" runat="server" AutoPostBack="True"  BorderWidth="0"
                                   Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Width="100px" 
                                   Height="25px" Visible="False" 
                                   onselectedindexchanged="ddlMesFNP4_SelectedIndexChanged">
                               </asp:DropDownList>
                           </td>
                           <td style="width:10px;">
                           </td>
                           <td>
                               <asp:DropDownList ID="ddlDiaFNP4" runat="server"  BorderWidth="0"
                                   Font-Names="FuturaStd-Book" ForeColor="#666666"  Font-Size="14px" Width="50px" 
                                   Height="25px" Visible="False">
                               </asp:DropDownList>
                           </td>
                       </tr>
                   </table>
               </td>
               <td>
                   </td>
               <td>
                   <asp:RadioButtonList ID="rdoGeneroP4" runat="server"  
                                          RepeatDirection="Horizontal" Visible="False">
                                        <asp:ListItem Value="1"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-3.png'></asp:ListItem>                                       
                                        <asp:ListItem Value="2"><img alt='' src='Imagenes_Benavides/MasterNueva/8-registro/img-genero-25x25-4.png'></asp:ListItem>
                                        <%--<asp:ListItem Value="3" Enabled="false">Indefinido</asp:ListItem>--%>
                                    </asp:RadioButtonList></td>
           </tr>
       </table></td>
   </tr>
   </table>
   
   <table style="background-image: url('Imagenes_Benavides/MasterNueva/8-registro/bg-registro-clubpeques/bg-registro-clubpeques_3.png'); background-repeat: no-repeat; border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;" cellpadding="0" cellspacing="0">
   <tr>
   <td style="width:740px; height:30px;">
   
   </td>
   </tr>
   </table>
   
    </asp:Panel>             
   </td><td></td></tr>
            <tr><td style="height:30px;display:none" id="trPeques" runat="server"></td><td></td><td></td><td></td><td></td><td></td></tr>
            <tr><td></td><td>
                <table cellpadding="0" cellspacing="0" style="border-style: none; border-collapse:collapse; padding:0; margin:0; border-bottom-width:0;"> 
                    <tr>
                        <td align="left">
                            <asp:CheckBox ID="chkTerminos" runat="server" Checked="true" 
                                Font-Names="FuturaStd-Bold" Font-Size="14px" ForeColor="#666666" 
                                Text="Acepto Términos y Condiciones" Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height:10px;">
                            </td>
                    </tr>
                    <tr>
                        <td  align="left">

                            <asp:CheckBox ID="chkRecibirInfo" runat="server" Checked="true" 
                                Font-Names="FuturaStd-Bold" Font-Size="14px" ForeColor="#666666" 
                                Text="Acepto recibir información y promociones de Farmacias Benavides." 
                                Enabled="False" />

                            </td>
                    </tr>
                    <tr>
                        <td style="height:30px;">
                            </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label28" runat="server" Font-Names="FuturaStd-Book" 
                                Font-Size="14px" ForeColor="#FF0033" Text="(*)Campos obligatorios"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:30px;">
                            </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="btnCancelar" runat="server" 
                                            ImageUrl="~/Imagenes_Benavides/MasterNueva/7-olvidaste_contrasena/btn-regresar.jpg" 
                                            OnClick="btnCancelar_Click" />
                                    </td>
                                    <td style="width:40px;">
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnRegistrar" runat="server" 
                                            ImageUrl="~/Imagenes_Benavides/MasterNueva/8-registro/btn-aceptar.jpg" 
                                            OnClick="btnRegistrar_Click" Enabled="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:65px;">
                            </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:HyperLink CssClass="linksBenaRecupera" ID="HyperLink1" runat="server" Font-Names="FuturaStd-Book" 
                                Font-Size="14px" ForeColor="#2B347A" NavigateUrl="~/Terminos.aspx" 
                                Target="_blank">Términos y Condiciones</asp:HyperLink>
                            <asp:Label ID="Label4" runat="server" Font-Names="FuturaStd-Book" 
                                ForeColor="#2B347A" Text="|"></asp:Label>
                            <asp:HyperLink CssClass="linksBenaRecupera" ID="HyperLink2" runat="server" Font-Names="FuturaStd-Book" 
                                Font-Size="14px" ForeColor="#2B347A" NavigateUrl="~/AvisoPrivacidad.aspx" 
                                Target="_blank">Aviso de Privacidad</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:10px;">
                            </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server" Font-Names="FuturaStd-Book" 
                                Font-Size="10px" ForeColor="#000000" 
                                Text="Copyright 2013 Farmacias Benavides. Todos los derechos reservados"></asp:Label>
                        </td>
                    </tr>
                </table>
                </td><td></td><td></td><td></td><td></td></tr>
     </table>
     </td></tr></table>

     <div id="divInfo" runat="server" visible="false">
     <asp:Panel ID="panelMasInfo" runat="server">
     <table>
     <tr>
     <td align="right">
     <asp:ImageButton ID="btnCerrarMasInfo" runat="server" 
             ImageUrl="~/Imagenes_Benavides/MasterNueva/btn-cerrar.jpg" 
             onclick="btnCerrarMasInfo_Click" />
     </td>         
     </tr>

     <tr>
     <td>
         <img src="Imagenes_Benavides/MasterNueva/14-club_peques_que_es/img-clubpeques-que-es-555x420.jpg" />
     </td>
     </tr>
     </table>
     </asp:Panel>
     <cc1:ModalPopupExtender ID="mpeInfo" runat="server" PopupControlID="panelMasInfo"
                                    TargetControlID="btnMasInfo" DynamicServicePath="" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
     </div>

     <div id="divPop" runat="server" visible="false">
                <asp:Panel ID="panelPop" runat="server">
    <table class="tablaSinbordes" style="width:500px;">
    <tr>
    <td align="right">
    <asp:ImageButton ID="btnCerrarPop" runat="server" 
            ImageUrl="~/Imagenes_Benavides/MasterNueva/btn-cerrar.jpg" 
            onclick="btnCerrarPop_Click" />
    </td>        
    </tr>
    </table>
    <table class="tablaSinbordes" style="background-image: url('Imagenes_Benavides/MasterNueva/23-popup_atencion/bg-contacto-500x500.png'); width:500px; height:500px;">
    <tr>
    <td valign="top">
        <table>
            <tr>
                <td style="width:30px; height:180px;">
                    </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                   </td>
                <td align="left">
                    <asp:Label ID="Label5" runat="server" Text="Atención" Font-Names="FuturaStd-Bold" 
                            Font-Size="30px" ForeColor="#FFFFFF"></asp:Label>
                   </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td style="height:20px;">
                   </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td align="left">
                    <asp:Label ID="lblMensaje" runat="server" Font-Names="FuturaStd-Book" 
                        Font-Size="18px" ForeColor="White" 
                        Text="Visita tu sucursal más cercana y cambia tu tarjeta Beneficio Inteligente para disfrutar de <b>mejores beneficios</b>"></asp:Label>
                    </td>
            </tr>
        </table>
        </td>
    </tr>
    </table>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="mpePop" runat="server" PopupControlID="panelPop"
    TargetControlID="btnRegistrar" DynamicServicePath="" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>            
    </div>

     <div id="divExitoso" runat="server" visible="false">
                <asp:Panel ID="panelExitoso" runat="server">
    <table class="tablaSinbordes" style="width:500px;">
    <tr>
    <td align="right">
    <asp:ImageButton ID="btnCerrarExitoso" runat="server" 
            ImageUrl="~/Imagenes_Benavides/MasterNueva/btn-cerrar.jpg" 
            onclick="btnCerrarExitoso_Click" />
    </td>        
    </tr>
    </table>
    <table class="tablaSinbordes" style="background-image: url('Imagenes_Benavides/MasterNueva/23-popup_atencion/bg-contacto-500x500.png'); width:500px; height:500px;">
    <tr>
    <td valign="top">
        <table>
            <tr>
                <td style="width:30px; height:180px;">
                    </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>
                   </td>
                <td align="left">
                    <asp:Label ID="Label7" runat="server" Text="¡Registro Exitoso!" Font-Names="FuturaStd-Bold" 
                            Font-Size="30px" ForeColor="White"></asp:Label>
                   </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td style="height:20px;">
                   </td>
            </tr>
            <tr>
                <td>
                    </td>
                <td align="left">
                    <asp:Label ID="Label8" runat="server" Font-Names="FuturaStd-Book" 
                        Font-Size="18px" ForeColor="White"></asp:Label>
                    </td>
            </tr>
        </table>
        </td>
    </tr>
    </table>
    </asp:Panel>
    <cc1:ModalPopupExtender ID="mdpExitoso" runat="server" PopupControlID="panelExitoso"
    TargetControlID="btnRegistrar" DynamicServicePath="" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>            
    </div>

     </ContentTemplate>
     </asp:UpdatePanel>
    </form>
    
</body>
</html>