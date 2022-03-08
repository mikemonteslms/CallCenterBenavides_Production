<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportarPromociones.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.ImportarPromociones" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style type="text/css">
        .overlay  
        {
            position: fixed;
            z-index: 98;
            top: 0px;
            left: 0px;
            right: 0px;
            bottom: 0px;
            background-color: #aaa; 
            filter: alpha(opacity=80); 
            opacity: 0.8; 
        }

        .overlayContent
        {
            z-index: 99;
            margin: 250px auto;
            width: 32px;
            height: 32px;
        }

        .titulo
        {
            font-family: Arial;
            font-size: 16pt;
            color: #004A99;
        }
       
        .fuenteReporte
        {
            font-family: Arial Narrow;
            font-size: 12pt;
            color:#2B347A;
        }

        .RadGrid_Default .rgHeader, .RadGrid_Default th.rgResizeCol, .RadGrid_Default .rgHeaderWrapper {
            background: #2B347A 0 -2300px repeat-x !important;
            color: #fff !important;
            font-size: 12pt !important;
        }

        .cajatexto {
            border: 1px solid #808080;
        }

        .BackGround {
           background-color:#808080;
           opacity:0.6;
           filter:alpha(opacity=60);
          }

        .RadButton.rbButton.css3Shadows {
        border: 0;
        border-radius: 5px;
        box-shadow: 1px 2px 5px #666;
        }

         input[type=submit] {
            background-color: #f70606;
            color: #fff;
            border: 1px solid #808080;
            font-family: Arial;
            font-size: 12pt;
            border-radius: 10px;
            width: 80px;
         }

        input[type=submit]:hover {
            background-color: #2B347A;            
         }


        inputexp[type=submit] {
            background-color: #f70606;
            color: #fff;
            border: 1px solid #808080;
            font-family: Arial;
            font-size: 12pt;
            border-radius: 10px;
            width: 75px;
         }

        inputexp[type=submit]:hover {
            background-color: #2B347A;            
         }

        .gradient {
          width: 200px;
          height: 200px;

          background: #00ff00; /* Para exploradores sin css3 */

           /* Para el WebKit (Safari, Google Chrome etc) */
          background: -webkit-gradient(linear, left top, left bottom, from(#fff), to(#CCCCCC));
  
          /* Para Mozilla/Gecko (Firefox etc) */
          background: -moz-linear-gradient(top, #00ff00, #000000);
  
          /* Para Internet Explorer 5.5 - 7 */
          filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#00ff00, endColorstr=#000000, GradientType=0);
  
          /* Para Internet Explorer 8 */
          -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#FF0000FF, endColorstr=#FFFFFFFF)";

          border:1px solid #595959; border-right:5px solid #595959; border-bottom:2.5px solid #595959;
     }
    </style>

    <asp:UpdatePanel ID="upCargaMasiva" runat="server">
    <ContentTemplate>
        <center>
            <br /><br />
            <h4 style="color:darkblue">Carga masiva de promociones</h4><br />
                <asp:Table ID="tblImportaExcel" runat="server">
                    <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label1" runat="server" Text="Seleccionar  archivo:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:FileUpload ID="fupPromociones"  cssClass="input"  runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <br />
                        <asp:Button ID="btnCargar" runat="server" cssClass="input" OnClick="btnCargar_Click" Text="Iniciar carga" width="150px" enabled="true" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <br />
                        <asp:Button ID="btnCanclear" runat="server" cssClass="input" OnClick="btnCanclear_Click" Text="Cancelar" width="150px" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </center>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
