<%@ Page ValidateRequest="false" Title ="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaLogsAppBenavides.aspx.cs" Inherits="CallcenterNUevo.Herramientas.ConsultaLogsAppBenavides" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="cntLogsBenavides" ContentPlaceHolderID="MainContent" runat="server">
   
     <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="../style/css/estilos-logs.css" rel="stylesheet" />

    <script type="text/javascript" >
        $(document).ready(function () {

            $('.close').on("click", function () {
                //debugger;
                $('#popReg').fadeOut('slow');
                return false;
            });

            //$('#MainContent_btnCancelar').click(function () {
            //    alert("cancelar");
            //});

            $('#MainContent_btnNo').on("click", function () {
                $('#popReg').fadeOut('slow');
                return false;
            });



        });


        function ShowReg() {
            //debugger;
            var _docHeight = (document.height !== undefined) ? document.height : document.body.scrollHeight;
            var _docWidth = (document.width !== undefined) ? document.width : document.body.offsetWidth;

            $('#popReg').fadeIn('slow');
            $('#popReg').height(_docHeight);

            //$('#popReg div')[0].removeAttr('height');
            //$('#popReg div')[0].attr('height', '180');

            return false;
        }
    </script>

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

        .listview {
    margin-top:15px;
    margin-left:auto;
    margin-right:auto;
    margin-bottom:15px;
    border:none;
    text-align:left;
    width:100%;
    font-size:12px;
    /*border-radius: 22px;*/

 }
.listview th {
    background-color:#F59F20;
    color:white;
    text-align:center;
    border:none;
    text-transform:uppercase;
    height:26px;
    width:15%;

}
.listview td {
    border:none;
    /*padding-left:10px;
    padding-right:10px;*/
    width:250px;
}

.opciones{
    width:24px;
    text-align:center;
}

.normal-row
{
	/*padding: 3px 0px 3px 0px;*/
	font-size: 12px;
}

.even-row
{
	/*padding: 3px 0px 3px 0px;*/
	font-size: 12px;
	background-color:#EEEEEE;
}
    </style>

    <asp:Panel ID="pnlFiltro1" runat="server" HorizontalAlign="Center" GroupingText="Logs (CALLCENTER - Benavides)">
    <div>
        <asp:Table ID="tblLogs" runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Por Fecha"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadDatePicker ID="rdpFIni" runat="server" Culture="es-MX" RenderMode="Lightweight" DateInput-DisplayText="Del" OnSelectedDateChanged="rdpFIni_SelectedDateChanged" Width="140px"></telerik:RadDatePicker>
                </asp:TableCell>
                 <asp:TableCell>
                     <telerik:RadDatePicker ID="rdpFFin" runat="server" Culture="es-MX" RenderMode="Lightweight" DateInput-DisplayText="Al" OnSelectedDateChanged="rdpFFin_SelectedDateChanged" Width="140px"></telerik:RadDatePicker>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Horario de:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadComboBox RenderMode="Lightweight"  AllowCustomText="False" ID="rdcDe" runat="server" OnSelectedIndexChanged="rdcDe_SelectedIndexChanged"   Width="180px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Todos" Value="0" Selected="true"/>
                                        <telerik:RadComboBoxItem Text="01:00" Value="01:00"/>
                                        <telerik:RadComboBoxItem Text="02:00" Value="02:00" />
                                        <telerik:RadComboBoxItem Text="03:00" Value="03:00" />
                                        <telerik:RadComboBoxItem Text="04:00" Value="04:00" />
                                        <telerik:RadComboBoxItem Text="05:00" Value="05:00" />
                                        <telerik:RadComboBoxItem Text="06:00" Value="06:00" />
                                        <telerik:RadComboBoxItem Text="07:00" Value="07:00" />
                                        <telerik:RadComboBoxItem Text="08:00" Value="08:00" />
                                        <telerik:RadComboBoxItem Text="09:00" Value="09:00" />
                                        <telerik:RadComboBoxItem Text="10:00" Value="10:00" />
                                        <telerik:RadComboBoxItem Text="11:00" Value="11:00" />
                                        <telerik:RadComboBoxItem Text="12:00" Value="12:00" />
                                        <telerik:RadComboBoxItem Text="13:00" Value="13:00"/>
                                        <telerik:RadComboBoxItem Text="14:00" Value="14:00" />
                                        <telerik:RadComboBoxItem Text="15:00" Value="15:00" />
                                        <telerik:RadComboBoxItem Text="16:00" Value="16:00" />
                                        <telerik:RadComboBoxItem Text="17:00" Value="17:00" />
                                        <telerik:RadComboBoxItem Text="18:00" Value="18:00" />
                                        <telerik:RadComboBoxItem Text="19:00" Value="19:00" />
                                        <telerik:RadComboBoxItem Text="20:00" Value="20:00" />
                                        <telerik:RadComboBoxItem Text="21:00" Value="21:00" />
                                        <telerik:RadComboBoxItem Text="22:00" Value="22:00" />
                                        <telerik:RadComboBoxItem Text="23:00" Value="23:00" />
                                        <telerik:RadComboBoxItem Text="00:00" Value="00:00" />
                                    </Items>
                                </telerik:RadComboBox>
                </asp:TableCell>
                 <asp:TableCell>
                    <asp:Label ID="Label4" runat="server" Text="A las:"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadComboBox RenderMode="Lightweight"  AllowCustomText="False" ID="rdcAl" runat="server" OnSelectedIndexChanged="rdcAl_SelectedIndexChanged"   Width="180px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Todos" Value="0" Selected="true"/>
                                        <telerik:RadComboBoxItem Text="01:00" Value="01:00"/>
                                        <telerik:RadComboBoxItem Text="02:00" Value="02:00" />
                                        <telerik:RadComboBoxItem Text="03:00" Value="03:00" />
                                        <telerik:RadComboBoxItem Text="04:00" Value="04:00" />
                                        <telerik:RadComboBoxItem Text="05:00" Value="05:00" />
                                        <telerik:RadComboBoxItem Text="06:00" Value="06:00" />
                                        <telerik:RadComboBoxItem Text="07:00" Value="07:00" />
                                        <telerik:RadComboBoxItem Text="08:00" Value="08:00" />
                                        <telerik:RadComboBoxItem Text="09:00" Value="09:00" />
                                        <telerik:RadComboBoxItem Text="10:00" Value="10:00" />
                                        <telerik:RadComboBoxItem Text="11:00" Value="11:00" />
                                        <telerik:RadComboBoxItem Text="12:00" Value="12:00" />
                                        <telerik:RadComboBoxItem Text="13:00" Value="13:00"/>
                                        <telerik:RadComboBoxItem Text="14:00" Value="14:00" />
                                        <telerik:RadComboBoxItem Text="15:00" Value="15:00" />
                                        <telerik:RadComboBoxItem Text="16:00" Value="16:00" />
                                        <telerik:RadComboBoxItem Text="17:00" Value="17:00" />
                                        <telerik:RadComboBoxItem Text="18:00" Value="18:00" />
                                        <telerik:RadComboBoxItem Text="19:00" Value="19:00" />
                                        <telerik:RadComboBoxItem Text="20:00" Value="20:00" />
                                        <telerik:RadComboBoxItem Text="21:00" Value="21:00" />
                                        <telerik:RadComboBoxItem Text="22:00" Value="22:00" />
                                        <telerik:RadComboBoxItem Text="23:00" Value="23:00" />
                                        <telerik:RadComboBoxItem Text="00:00" Value="00:00" />
                                    </Items>
                                </telerik:RadComboBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="Tipo Log"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <telerik:RadComboBox RenderMode="Lightweight"  AllowCustomText="False" ID="rdcTipoLog" runat="server" OnSelectedIndexChanged="rdcTipoLog_SelectedIndexChanged"   Width="180px">
                    </telerik:RadComboBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button runat="server" ID="btnCargaLogs"  CausesValidation="false" Width="80px" Text="Buscar"  OnClick="btnCargaLogs_Click"/>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
     <asp:ListView ID="gvResultadosLogs" runat="server" OnItemCommand="gvResultadosLogs_ItemCommand" OnPagePropertiesChanging="gvResultadosLogs_PagePropertiesChanging">
                <LayoutTemplate>
                    <table id="tblMDC" runat="server" class="listview">
                        <tr>
                              <th style="width:15%">FECHA</th>
                            <th style="width:5%">AMBIENTE</th>
                            <th style="width:25%">CLASE</th>
                            <th style="width:25%">EVENTO-METODO</th>
                            <th style="width:auto">HILO</th>
                            <th style="width:auto">TIPOLOG</th>
                            <th style="width:auto">USUARIO</th>
                            <th style="width:10%">MENSAJE</th>
                            <th style="width:auto">OPCION</th>
                        </tr>
                        <tr id="itemPlaceHolder" runat="server">
                        </tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr id="Tr1" class="normal-row" runat="server">
                        <td class="left" style="text-align :center"><%# Eval("FechaLog")%></td>
                        <td class="left" style="text-align :center"><%# Eval("Ambiente")%></td>
                        <td class="left" style="text-align :center"><%# Eval("Clase")%></td>
                        <td class="left" style="text-align :center"><%# Eval("EventoOrMetodo")%></td>
                        <td class="left" style="text-align :center"><%# Eval("Hilo")%></td>
                        <td class="left" style="text-align :center"><%# Eval("TipoLog")%></td>
                        <td class="left" style="text-align :center"><%# Eval("Usuario")%></td>
                        <td class="left" style="text-align :center"><%# Eval("Mensaje")%></td>
                        <td class="opciones">
                            <asp:ImageButton  ID="imgbtnVerDetalle" runat="server"  ForeColor="Red" AlternateText="Ver detalle"  ToolTip="Ver detalle" CommandName ="Verdetalle" Visible='<%# (DataBinder.Eval(Container.DataItem, "TipoLog").Equals("ERRORES")) ? (bool) true : (bool) false %>' CommandArgument='<%# Eval("IDLOG") %>'/>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr id="Tr2" class="even-row" runat="server">
                        <td class="left" style="text-align :center"><%# Eval("FechaLog")%></td>
                        <td class="left" style="text-align :center"><%# Eval("Ambiente")%></td>
                        <td class="left" style="text-align :center"><%# Eval("Clase")%></td>
                        <td class="left" style="text-align :center"><%# Eval("EventoOrMetodo")%></td>
                        <td class="left" style="text-align :center"><%# Eval("Hilo")%></td>
                        <td class="left" style="text-align :center"><%# Eval("TipoLog")%></td>
                        <td class="left" style="text-align :center"><%# Eval("Usuario")%></td>
                        <td class="left" style="text-align :center"><%# Eval("Mensaje")%></td>
                        <td class="opciones">
                            <asp:ImageButton  ID="imgbtnVerDetalle2" runat="server" ForeColor="Red" AlternateText="Ver detalle" ToolTip="Ver detalle" CommandName ="Verdetalle" Visible='<%# (DataBinder.Eval(Container.DataItem, "TipoLog").Equals("ERRORES")) ? (bool) true : (bool) false %>' CommandArgument='<%# Eval("IDLOG") %>'/>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EmptyDataTemplate>
                    <table class="listview">
                        <tr>
                            <th style="width:15%">FECHA</th>
                            <th style="width:5%">AMBIENTE</th>
                            <th style="width:25%">CLASE</th>
                            <th style="width:25%">EVENTO-METODO</th>
                            <th style="width:auto">HILO</th>
                            <th style="width:auto">TIPOLOG</th>
                            <th style="width:auto">USUARIO</th>
                            <th style="width:10%">MENSAJE</th>
                            <th style="width:auto">OPCION</th>
                        </tr>
                        <tr>
                            <td align="center" colspan="5" class="no-results">No se encontraron resultados</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:ListView>
            <div id="paginado">
                <div>
                    <asp:DataPager ID="Datapager1" runat="server"  PagedControlID="gvResultadosLogs" PageSize="1000">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Image" ShowFirstPageButton="true" ShowNextPageButton="false"
                                    FirstPageText="Primera" ShowPreviousPageButton="true" PreviousPageText="Anterior"
                                    FirstPageImageUrl="~/images/ic_iniciopag.gif" PreviousPageImageUrl="~/images/ic_atras.gif" />
                            <asp:NumericPagerField PreviousPageText="..." NextPageText="..." ButtonCount="3" />
                            <asp:NextPreviousPagerField ButtonType="Image" ShowLastPageButton="true" ShowNextPageButton="true"
                                    LastPageText="Última" ShowPreviousPageButton="false" NextPageText="Siguiente"
                                    LastPageImageUrl="~/images/ic_finpag.gif" NextPageImageUrl="~/images/ic_adelante.gif" />
                            <asp:TemplatePagerField>
                                <PagerTemplate>
                                    <b>Página
                                    <asp:Label runat="server" ID="CurrentPageLabel" 
                                  Text="<%# (Container.TotalRowCount > 0 ?  (Container.StartRowIndex / Container.PageSize) + 1 : 0) %>" />
                                de
                                    <asp:Label runat="server" ID="TotalPagesLabel" 
                                  Text="<%# Math.Ceiling (System.Convert.ToDouble(Container.TotalRowCount) / Container.PageSize) %>" />
                                (
                                    <asp:Label runat="server" ID="TotalItemsLabel" 
                                  Text="<%# Container.TotalRowCount%>" />
                                registros)
                                    <br />
                                    </b>
                                </PagerTemplate>
                            </asp:TemplatePagerField>
                        </Fields>
                    </asp:DataPager>
                </div>
            </div>
        </div>

        <div id="divDetalle" style="text-align:center;position:absolute;top:32%;left:200px;width:475px;height:250px;display:block;" >
           
        </div>


         <div id="popReg" style="display: none; background-color: rgba(0, 0, 0, 0.5); z-index: 20000; left: 0%; position: absolute; top: 0px; width: 100%; height: 100%; text-align: center;">
        <div  style="background-color: #333333; max-width: 700px; padding: 15px; width: 100%; display: inline-block; vertical-align: middle; height: 425px; margin-top: 170px; max-height: 580px;">
            <div class="modal-content"  style="background-color:#E2E1E1; height:400px; background-image:url(; background-repeat: repeat-x"../Images/background2.jpg");
            

                <div class="modal-header">
                    <button id="btnCloseReg" type="button" class="close" data-dismiss="modal" runat="server">&times;</button>
                    
                    <asp:Table ID="tblDtealle" runat="server" HorizontalAlign="Center" CellSpacing="5" CellPadding="3" Width="100%">
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Center"  VerticalAlign="Middle">
                                <asp:TextBox ID="txtDetalle" runat="server" ReadOnly ="true" TextMode="MultiLine" Width="650px" Height="355px"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </div>
    </div>
    </asp:Panel>
</asp:Content>
