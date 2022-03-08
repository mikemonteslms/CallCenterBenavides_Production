<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rptBloquearTarjeta.aspx.cs" Inherits="CallcenterNUevo.CALLCENTER.rptBloquearTarjeta" %>
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

   
   <center>
     <br /><br />
        <div id="title" class="titulo">Bloqueo de Tarjetas</div><br /><br />
         <asp:UpdatePanel ID="upBloqueaTarjeta" runat="server">
             <ContentTemplate>
                <table style="width:300px; text-align:left;">
                    <tr style="height:30px">
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>Tarjeta:</td>
                        <td>
                            <asp:TextBox ID="txtTarjeta" runat="server"  MaxLength="13"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="ftbeTarjeta" runat="server" FilterType="Numbers"
                                                             TargetControlID="txtTarjeta">
                                </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><br /><asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="input" Width="100px" OnClick="btnConsultar_Click" /></td>
                    </tr>
                </table>
                <br />
                <asp:Panel ID="pnlDatos" runat="server" Visible="false">
                    <table style="width:400px; text-align:left">
                    <tr>
                        <td>Nombre:</td>
                        <td><asp:TextBox ID="txtNombre" runat="server" Enabled="false"></asp:TextBox></td>                        
                    </tr>
                    <tr>
                        <td>Fecha de Activación:</td>
                        <td>
                            <asp:TextBox ID="txtFecha" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                        <tr>
                            <td>Fecha de Última Modificacion:</td>
                            <td><asp:TextBox ID="txtFechaBloque" runat="server" Enabled="false"></asp:TextBox></td>
                        </tr>
                    <tr>
                        <td>Estatus:</td>
                        <td>
                            <asp:TextBox ID="txtEstatus" runat="server" Enabled="false"></asp:TextBox>
                        </td>                        
                    </tr>
                    <tr>
                        <td>Saldo:</td>
                        <td>
                            <asp:TextBox ID="txtSaldo" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Boomerangs:</td>
                        <td>
                            <asp:TextBox ID="txtBoomerangs" runat="server" Enabled="false"></asp:TextBox>
                        </td>                        
                    </tr>
                    <tr>
                        <td>Nivel</td>
                        <td>
                            <asp:TextBox ID="txtNivel" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:TextBox ID="txtEstatusB" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="lblmotivo" runat="server" Text="Motivo:" Visible="false"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtMotivo" runat="server" Visible="false" TextMode ="MultiLine" Height="32px" Width="160px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnConfirma" runat="server" CssClass="input" Text="Confirmar" Width="100px" OnClick="btnConfirma_Click" /></td>
                        <td><asp:Button ID="btnCanelar" runat="server" CssClass="input" Text="Cancelar" Width="100px" OnClick="btnCanelar_Click"/></td>
                    </tr>
                </table>
              </asp:Panel>
                 </center>
            </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>
