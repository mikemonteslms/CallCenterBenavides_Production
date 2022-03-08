<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampañaTripleAcumulacion.aspx.cs"
    Inherits="Portal_Benavides.CampañaTripleAcumulacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="javascript" type="text/javascript">
</script>
<html>
<head>
    <title>Campaña Triple Acumulación</title>
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
                <table cellpadding="0" cellspacing="0" border="0" style="background-color: White">
                    <img border="0" src="http://beneficiointeligente.com.mx/PLB/imagenes/Promociones/20150625/img1.jpg"
                        alt="" style="display: block" />
                    <tr>
                        <td style="width: 36px">
                            <img border="0" src="http://beneficiointeligente.com.mx/PLB/imagenes/Promociones/20150625/img2.jpg"
                                alt="" style="display: block" />
                        </td>
                        <td style="width: 626px; vertical-align: middle; background-color: #161A61">
                            &nbsp; <span style="font-family: Arial; font-size: 30px; color: White; font-weight: bold">
                                Farmacias Benavides</span>
                        </td>
                        <td style="width: 38px">
                            <img border="0" src="http://beneficiointeligente.com.mx/PLB/imagenes/Promociones/20150625/img3.jpg"
                                alt="" style="display: block" />
                        </td>
                    </tr>
                    <img border="0" src="http://beneficiointeligente.com.mx/PLB/imagenes/Promociones/20150625/img4.jpg"
                        alt="" style="display: block" />
                </table>
                <table cellpadding="0" cellspacing="0" border="0" style="background-color: White">
                    <tr>
                        <td style="width: 40px">
                            <img border="0" src="http://beneficiointeligente.com.mx/PLB/imagenes/Promociones/20150625/img5.jpg"
                                alt="" style="display: block" />
                        </td>
                        <td style="width: 20px">
                        </td>
                        <td style="width: 361px; vertical-align: top">
                            <br />
                            <span style="font-family: Arial; font-size: 16px; color: #004A99; font-style: italic">
                                HOLA,</span>
                            <asp:Label ID="lblNombre" runat="server" Font-Size="16px" Font-Names="Arial" ForeColor="#004A99"
                                Font-Bold="true">
                            Nombre
                            </asp:Label>
                            <br />
                            <br />
                            <span style="font-family: Arial; font-size: 12px; color: #6E6F6F">¡Gracias por confirmar
                                tus datos!</span>
                            <br />
                            <br />
                            <span style="font-family: Arial; font-size: 12px; color: #6E6F6F">Tu promoción se ha
                                dado de alta, acumularás triple en cada compra de &nbsp;</span>
                            <asp:Label runat="server" ID="lblFechaInicio" Style="font-family: Arial; font-size: 12px;
                                color: #004A99; font-weight: bold">
                                FechaInicio
                            </asp:Label>
                            <span style="font-family: Arial; font-size: 12px; color: #6E6F6F">&nbsp;a&nbsp;</span>
                            <asp:Label runat="server" ID="lblFechaFin" Style="font-family: Arial; font-size: 12px;
                                color: #004A99; font-weight: bold">
                                FechaFin
                            </asp:Label>
                        </td>
                        <td align="center" style="width: 241px">
                            <img border="0" src="http://beneficiointeligente.com.mx/PLB/imagenes/Promociones/20150625/ed_tbi.png"
                                alt="" style="display: block" />
                        </td>
                        <td style="width: 38px">
                            <img border="0" src="http://beneficiointeligente.com.mx/PLB/imagenes/Promociones/20150625/img6.jpg"
                                alt="" style="display: block" />
                        </td>
                    </tr>
                </table>
                <img border="0" src="http://beneficiointeligente.com.mx/PLB/imagenes/Promociones/20150625/img7.jpg"
                    alt="" style="display: block">
                <img border="0" src="http://beneficiointeligente.com.mx/PLB/imagenes/Promociones/20150625/img8.jpg"
                    alt="" style="display: block" usemap="#Ruta" />
                <map id="Mapa" name="Ruta">
                    <area shape="rect" coords="254,123,350,153" href="https://itunes.apple.com/mx/app/benavides/id882076046?mt=8"
                        alt="" />
                    <area shape="rect" coords="421,127,548,153" href="https://play.google.com/store/apps/details?id=com.loyalty.benavides&hl=es-419"
                        alt="" />
                    <area shape="rect" coords="461,205,614,231" href="https://twitter.com/FarmaBenavides"
                        alt="" />
                    <area shape="rect" coords="461,233,627,258" href="https://www.facebook.com/FarmaciasBenavides?fref=ts"
                        alt="" />
                    <area shape="rect" coords="461,264,640,280" href="http://www.benavides.com.mx/sitio/index.aspx"
                        alt="" />
                </map>
            </td>
        </tr>
        <tr>
            <td style="font-size: 11px; font-family: Arial; color: Gray; text-align: center;
                width: 700px">
                <span>Si no deseas recibir promociones da </span><a href="http://beneficiointeligente.com.mx/PLB/CancelaContacto.aspx"
                    style="font-size: 11px; font-family: Arial">clic aquí</a>
            </td>
        </tr>
    </table>
</body>
</html>
