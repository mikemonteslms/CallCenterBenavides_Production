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

    ga('create', 'UA-43180890-1', 'beneficiointeligente.com.mx');
    ga('send', 'pageview');
</script>
<body>
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</body>
</html>
