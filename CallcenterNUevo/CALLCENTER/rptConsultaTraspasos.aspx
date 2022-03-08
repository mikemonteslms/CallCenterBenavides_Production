<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rptConsultaTraspasos.aspx.cs" Inherits="CallcenterNUevo.CALLCENTER.rptConsultaTraspasos" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
         .titulo
        {
            font-family: Arial;
            font-size: 16pt;
            color:#2B347A;
            margin-left: -100px;
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
    </style>
    <script type="text/javascript">
        //function obtenerFecha()
        //{
        //    var Mes, Anio;
        //    Mes = document.getElementById("ddlMes").options[document.getElementById("ddlMes").options.selectedIndex].text;
        //    Anio = document.getElementById("ddlAnio").options[document.getElementById("ddlAnio").options.selectedIndex].text;
        //    document.getElementById("HiddenField1").Value = Anio.toString() + Mes.toString();
        //    alert(document.getElementById("HiddenField1").Value);
        //}
        //var posicion=document.getElementById(‘test’).options.selectedIndex; //posicion
        //alert(document.getElementById(‘test’).options[posicion].text); //valor
    </script>
     <br /><br />
    <center>
        <div id="title" class="titulo">Traspasos</div><br /><br />
            <asp:Panel ID="pnlConsulta" runat="server">
            <table style="width:300px">
                <tr>
                    <td style="text-align:left"><span class="fuenteReporte">Tarjeta:</span></td>
                    <td></td>
                    <td style="text-align:left">
                        <span class="fuenteReporte">
                        <asp:TextBox ID="txtTarjeta" runat="server" CssClass="cajatexto"></asp:TextBox>
                        </span></td>
                </tr>
                <tr>
                    <td style="text-align:left">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="text-align:left">&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align:left"><span class="fuenteReporte">Sucursal:</span></td>
                    <td>&nbsp;</td>
                    <td style="text-align:left">
                         <telerik:RadComboBox ID="ddlSucursales" Runat="server" AllowCustomText="True" Skin="Bootstrap" MarkFirstMatch="True" Width="250px" >
                         </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="text-align:left">&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align:left"><span class="fuenteReporte">Mes:</span></td>
                    <td></td>
                    <td style="text-align:left">
                      <span class="fuenteReporte">Año:</span></td>
                </tr>
                <tr>
                    <td style="text-align:left"><asp:DropDownList ID="ddlMes" runat="server" SkinID="Bootstrap" OnClientSelectedIndexChanged="obtenerFecha()">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td style="text-align:left">
                        <asp:DropDownList runat="server" ID="ddlAnio" SkinID="Bootstrap" OnClientSelectedIndexChanged="obtenerFecha()">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="">
                    <td style="text-align:left">
                        <asp:Button ID="btnNuevo" runat="server" Height="20px" Text="Nuevo Traspaso" Visible="False" Width="58px" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="text-align:left">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                </tr>
                <tr style="">
                    <td style="text-align:left">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="text-align:left">
                        <asp:Button ID="btnGeneraReporte" runat="server" OnClick="btnGeneraReporte_Click" Text="Consultar Traspasos" />
                    </td>
                </tr>
            </table><br /><br />
            <telerik:RadGrid runat="server" ID="rgResultado" CellSpacing="-1" Culture="es-MX" GridLines="Both">
                <MasterTableView NoMasterRecordsText="No hay información para mostrar">
                    <RowIndicatorColumn Visible="False">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True">
                    </ExpandCollapseColumn>
                    <PagerStyle PageSizeControlType="None" />
                </MasterTableView>
                <HeaderStyle BackColor="#2B347A" ForeColor="#fff" Font-Size="12pt" />
                <PagerStyle ChangePageSizeButtonToolTip="" FirstPageToolTip="Primera página" GoToPageButtonToolTip="Ir a la página" LastPageToolTip="Última página" NextPagesToolTip="Siguiente página" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; al &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;.}" PageSizeControlType="None" PageSizeLabelText="" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
            </telerik:RadGrid><br /><br />
            <div id="botones2" style="float:right;"><asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" OnClick="btnExportar_Click" Enabled="false" /></div><br /><br />
        </asp:Panel>
    </center>
</asp:Content>
