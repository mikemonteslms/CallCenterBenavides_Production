<%@ Page Language="C#" MasterPageFile="~/MasterEcardMenu.Master" AutoEventWireup="true"
    CodeBehind="IndexRep.aspx.cs" Inherits="WebPfizer.LMS.eCard.IndexRep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="general" style="width: 641px;">
                <table style="width: 980px; height: 1000px">
                    <tr>
                        <td style="width: 16px">
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
