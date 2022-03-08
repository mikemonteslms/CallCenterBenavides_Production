<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rptBloqueos.aspx.cs" Inherits="Portal_Benavides.rptBloqueos" %>
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
    <center>
        <br /><br />
        <div id="title" class="titulo">Bloqueos de Tarjetas</div><br /><br />
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
            <div id="botonoes"><asp:Button ID="btnGeneraReporte" runat="server" Text="Genera reporte" OnClick="btnGeneraReporte_Click" />&nbsp;&nbsp;<asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" OnClick="btnExportar_Click" />&nbsp;&nbsp;&nbsp;<asp:Button ID="btnNuevo" runat="server" Text="Nuevo Bloqueo" OnClick="btnNuevo_Click"/></div><br /><br />
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
                <tr>
                    <td colspan="2">Nuevo Bloqueo</td>
                </tr>
                <tr style="height:30px">
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>Tarjeta:</td>
                    <td>
                        <asp:TextBox ID="txtTarjeta" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Opción:</td>
                    <td>
                        <telerik:RadDropDownList ID="RadDropDownList1" runat="server" Skin="Bootstrap">
                            <Items>                          
                                <telerik:DropDownListItem Text="Bloquear" Value="5" />
                            </Items>
                        </telerik:RadDropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" /></td>
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
                    <td>Motivo:</td>
                    <td>
                        <asp:TextBox ID="txtMotivo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnConfirma" runat="server" Text="Confirmar" OnClick="btnConfirma_Click" /></td>
                    <td><asp:Button ID="btnCanelar" runat="server" Text="Cancelar" OnClick="btnCanelar_Click"/></td>
                </tr>
            </table>
            </asp:Panel>
        </asp:Panel>
    </center>
</asp:Content>
