<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaPromo.aspx.cs" Inherits="CallcenterNUevo.Cat.NuevaPromo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
     <script type="text/javascript" src="../Scripts/jquery-2.1.0.js"> </script>
     <script type="text/javascript" src="../Scripts/jquery-ui-1.10.4.js"></script>
        <link rel="stylesheet" href="../Content/Site.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.datepicker.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.theme.css"/>
 <link rel="stylesheet" href="../Content/themes/base/jquery.ui.core.css"/>
 <style type="text/css">
       .fuenteReporte
        {
            font-family: Arial Narrow;
            font-size: 12pt;
            color:#2B347A;
        }
 </style>
     <br />
    <table style="width:300px">
        <tr>
            <td>    
               <span class="fuenteReporte">Seleccionar tipo de operación:</span> <br /><br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButtonList runat="server" ID="rdCategoriaMecanica">                      
                </asp:RadioButtonList><br /><br />
            </td>
        </tr>
        <tr>
            <td style="text-align:right;">
                <asp:Button Text="Continuar" runat="server" ID="btnContinuar" OnClick="btnContinuar_Click"/>
            </td>
        </tr>
    </table>
</center>
</asp:Content>