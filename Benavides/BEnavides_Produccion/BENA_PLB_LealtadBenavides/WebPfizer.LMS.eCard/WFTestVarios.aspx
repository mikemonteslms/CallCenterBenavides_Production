<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFTestVarios.aspx.cs" Inherits="WebPfizer.LMS.eCard.WFTestVarios" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnShowIPs" runat="server" OnClick="btnShowIPs_Click" Text="Show IPs"
            Width="161px" /><br />
        <asp:TextBox ID="txtResultado" runat="server" Height="320px" TextMode="MultiLine"
            Width="505px"></asp:TextBox>&nbsp;</div>
    </form>
</body>
</html>
