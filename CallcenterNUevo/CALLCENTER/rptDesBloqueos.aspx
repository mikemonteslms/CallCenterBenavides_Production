<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rptDesBloqueos.aspx.cs" Inherits="CallcenterNUevo.CALLCENTER.rptDesBloqueos" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
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
        <asp:UpdatePanel ID="upDesbloqueo" runat="server">
            <ContentTemplate>

            
        <br /><br />
        <div id="title" class="titulo">Desbloqueo de Tarjetas</div><br /><br />
        <asp:Panel ID="pnlConsulta" runat="server">
            <table style="width:400px">
                <tr>
                    <td style="text-align:left"><span class="fuenteReporte">Fecha Inicial</span></td>
                    <td></td>
                    <td style="text-align:left">
                        <telerik:RadDatePicker ID="RadDatePicker1" Runat="server">
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left"><span class="fuenteReporte">Fecha Final</span></td>
                    <td></td>
                    <td style="text-align:left">
                         <telerik:RadDatePicker ID="RadDatePicker2" Runat="server">
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr style="">
                    <td style="text-align:left"><span class="fuenteReporte">Tarjeta:</span></td>
                    <td></td>
                    <td style="text-align:left">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="cajatexto"></asp:TextBox>
                    </td>
                </tr>
            </table><br /><br />
            <div id="botonoes"><asp:Button ID="btnGeneraReporte" runat="server" Text="Genera reporte" OnClick="btnGeneraReporte_Click" Width="130px" />&nbsp;&nbsp;<asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" OnClick="btnExportar_Click" Width="130px" />&nbsp;&nbsp;&nbsp;<asp:Button ID="btnNuevo" runat="server" Text="Nuevo Bloqueo" OnClick="btnNuevo_Click" Width="130px" /></div><br /><br />
            <telerik:RadGrid runat="server" ID="rgResultado">
                <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                <MasterTableView NoMasterRecordsText="No hay información para mostrar">
                    <RowIndicatorColumn Visible="False">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True">
                    </ExpandCollapseColumn>
                </MasterTableView>
            </telerik:RadGrid>
        </asp:Panel>
        <asp:Panel ID="pnlNuevoBloqueo" runat="server" Visible="false">
            <table style="width:300px; text-align:left;">
                
                <tr style="height:30px">
                    <td colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Consulta" />
                    </td>
                </tr>
                <tr>
                    <td>Tarjeta:</td>
                    <td>
                        <asp:TextBox ID="txtTarjeta" runat="server" MaxLength="13"></asp:TextBox>
                         <cc1:FilteredTextBoxExtender ID="ftbeTarjeta" runat="server" FilterType="Numbers"
                                                             TargetControlID="txtTarjeta">
                                </cc1:FilteredTextBoxExtender>
<%--                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTarjeta" Display="Dynamic" ErrorMessage="Ingrese un número de tarjeta." ForeColor="Red" ValidationGroup="Consulta">*</asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr style="display:none">
                    <td>Opción:</td>
                    <td>
                        <telerik:RadDropDownList ID="RadDropDownList1" runat="server" Skin="Bootstrap" Enabled="false">
                            <Items>
                                <telerik:DropDownListItem Text="Desbloquear" Value="1"/>
                            </Items>
                        </telerik:RadDropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnConsultar" runat="server" CssClass="input" Width="100px" Text="Consultar" OnClick="btnConsultar_Click" ValidationGroup="Consulta" /></td>
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
                <tr style="display:none;">
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtEstatusB" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Motivo:</td>
                    <td>
                        <asp:TextBox ID="txtMotivo" runat="server" Height="92px" TextMode="MultiLine" Width="177px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnConfirma" runat="server" CssClass="input" Width="175px" Text="Confirmar Desbloqueo" OnClick="btnConfirma_Click" /></td>
                    <td><asp:Button ID="btnCanelar" runat="server" CssClass="input" Width="100px" Text="Cancelar" OnClick="btnCanelar_Click"/></td>
                </tr>
            </table>
            </asp:Panel>
        </asp:Panel>
                </ContentTemplate>
        </asp:UpdatePanel>
    </center>
</asp:Content>
