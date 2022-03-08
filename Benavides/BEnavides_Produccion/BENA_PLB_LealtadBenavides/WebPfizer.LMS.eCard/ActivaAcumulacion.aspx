<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivaAcumulacion.aspx.cs"
    Inherits="Portal_Benavides.ActivaAcumulacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="javascript" type="text/javascript">
</script>
<html>
<head>
    <title>Activa Acumulación</title>
</head>
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
<body>
    <asp:Panel ID="pnl150"  Visible="false" runat="server">
        <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:Label ID="lblMensajeAzul" runat="server" Visible="false"></asp:Label>
                <img border="0" src="http://beneficiointeligente.com.mx/PLB/imagenes/Bienvenida/htm Bienvenida BI-2.jpg" alt="" style="" usemap="#activa1"  />
                 <map id="Map1" name="activa1">
                    <area shape="rect" coords="237, 382, 608, 414" href="http://beneficiointeligente.com.mx/PLB/Acceso.aspx" alt="" />
                    <area shape="rect" coords="219, 867, 351, 891" href="https://twitter.com/FarmaBenavides" alt="" />
                    <area shape="rect" coords="360, 866, 503, 890" href="https://www.facebook.com/FarmaciasBenavides?fref=ts" alt="" />
                    <area shape="rect" coords="511, 864, 670, 888" href="http://www.benavides.com.mx/" alt="" />                    
                 </map>
            </td>
        </tr>        
    </table>
    </asp:Panel>
    <asp:Panel ID="pnl160"  Visible="false" runat="server">
        <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:Label ID="lblMensajePlatino" runat="server" Visible="false"></asp:Label>
                <img border="0" src="http://beneficiointeligente.com.mx/PLB/imagenes/Bienvenida/HTML Bienvenida Platino-2.jpg" alt="" style="" usemap="#activa2"  />
                 <map id="Map2" name="activa2">
                    <area shape="rect" coords="232, 399, 608, 428" href="http://beneficiointeligente.com.mx/PLB/Acceso.aspx" alt="" />
                    <area shape="rect" coords="215, 1077, 347, 1101" href="https://twitter.com/FarmaBenavides" alt="" />
                    <area shape="rect" coords="357, 1076, 500, 1100" href="https://www.facebook.com/FarmaciasBenavides?fref=ts" alt="" />
                    <area shape="rect" coords="509, 1077, 668, 1101" href="http://www.benavides.com.mx/" alt="" />                    
                </map>
            </td>
        </tr>        
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlGenerico" runat="server" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:Label ID="lblMensaje" runat="server" Visible="false"></asp:Label>
                <img border="0" src="http://beneficiointeligente.com.mx/PLB/imagenes/Bienvenida/IMAGEN_DESPUES_DE_CLICK.png" alt="" usemap="#activa"  />
                 <map id="Mapa" name="activa"><area shape="rect" coords="55, 455, 270, 498" href="http://beneficiointeligente.com.mx/PLB/Acceso.aspx" alt="" /></map>
            </td>
        </tr>        
    </table>
    </asp:Panel>     
</body>
</html>
