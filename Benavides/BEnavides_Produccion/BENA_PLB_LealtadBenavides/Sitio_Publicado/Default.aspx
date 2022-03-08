<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
    <title>Página sin título</title>
</head>
<body>

<%--
<script type="text/javascript">  
    var RecaptchaOptions = {     
        theme : 'custom',     
        custom_theme_widget: 'recaptcha_widget'  };  
</script> 
--%>   

    <form id="form1" runat="server">
    <div>
    

        <table style="width: 800px; height: 124px">
            <tr>
                <td style="width: 332px">
                    Ingrese la información solicitada:</td>
                <td style="width: 156px"> <asp:Label ID="lblResult" runat="server" />
                    </td>
                <td style="width: 82px">
                </td>
            </tr>
            <tr>
                <td style="width: 332px">
                </td>
                <td style="width: 156px">
                
<%--
                <div id="recaptcha_widget" style="display:none">     
                <div id="recaptcha_image"></div>    
                <div class="recaptcha_only_if_incorrect_sol" style="color:red">Incorrect please try again</div>     
                <span class="recaptcha_only_if_image">Enter the words above:</span>    
                <span class="recaptcha_only_if_audio">Enter the numbers you hear:</span>     
                <input type="text" id="recaptcha_response_field" name="recaptcha_response_field" />     
                <div><a href="javascript:Recaptcha.reload()">Get another CAPTCHA</a></div>    
                <div class="recaptcha_only_if_image">
                <a href="javascript:Recaptcha.switch_type('audio')">Get an audio CAPTCHA</a>
                </div>    
                <div class="recaptcha_only_if_audio"><a href="javascript:Recaptcha.switch_type('image')">Get an image CAPTCHA</a></div>     
                <div><a href="javascript:Recaptcha.showhelp()">Help</a></div>   
                </div>   
                <script type="text/javascript"     src="http://api.recaptcha.net/challenge?k=6Lfqbb4SAAAAAHlBvap1ReqbmV4Bz8TcWVD5Kzir">  </script>  
                <noscript>    
                <iframe src="http://www.google.com/recaptcha/api/noscript?k=6Lfqbb4SAAAAAHlBvap1ReqbmV4Bz8TcWVD5Kzir"         height="300" width="500" frameborder="0"></iframe>
                <br>    <textarea name="recaptcha_challenge_field" rows="3" cols="40">    </textarea>    
                <input type="hidden" name="recaptcha_response_field"         value="manual_challenge">  
                </noscript>
--%>
                <recaptcha:RecaptchaControl  ID="RecaptchaControl1" runat="server" PublicKey="6Lfqbb4SAAAAAHlBvap1ReqbmV4Bz8TcWVD5Kzir" PrivateKey="6Lfqbb4SAAAAAJ1tkjUQfPyzYXauxlRU14i03kF5" Custom_Translation="True" lang="es" Theme="clean" />                                
                    </td>
                <td style="width: 82px">
                </td>
            </tr>
            <tr>
                <td style="width: 332px">
                </td>
                <td style="width: 156px">
                </td>
                <td style="width: 82px">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
