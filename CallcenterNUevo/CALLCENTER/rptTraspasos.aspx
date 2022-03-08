<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rptTraspasos.aspx.cs" Inherits="WebPfizer.LMS.eCard.rptTraspasos" %>
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
        .auto-style1 {
            height: 10px;
        }
    </style>
    <script type="text/javascript">
        function callbackfnAlert(arg) {
            if (arg) {
                __doPostBack("activarT", "");
            }
        }
    </script>
<center>
     <br /><br />
        <div id="title" class="titulo">Traspasos</div><br /><br />
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
                    <td style="text-align:left"><span class="fuenteReporte">Tarjeta origen:</span></td>
                    <td></td>
                    <td style="text-align:left">
                        <asp:TextBox ID="txtTOrigen" runat="server" CssClass="cajatexto"></asp:TextBox>
                    </td>
                </tr>
                <tr style="">
                    <td style="text-align:left"><span class="fuenteReporte">Tarjeta destino:</span></td>
                    <td>&nbsp;</td>
                    <td style="text-align:left">
                        <asp:TextBox ID="txtTDestino" runat="server" CssClass="cajatexto"></asp:TextBox>
                    </td>
                </tr>
            </table><br /><br />
            <div id="botonoes"><asp:Button ID="btnGeneraReporte" runat="server" Text="Genera reporte" OnClick="btnGeneraReporte_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnNuevo" runat="server" Text="Nuevo Traspaso" /></div><br /><br />
            <telerik:RadGrid runat="server" ID="rgResultado">
                <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                <MasterTableView NoMasterRecordsText="No hay información para mostrar">
                    <RowIndicatorColumn Visible="False">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True">
                    </ExpandCollapseColumn>
                </MasterTableView>
                <HeaderStyle BackColor="#2B347A" ForeColor="#fff" Font-Size="12pt" />
            </telerik:RadGrid>
            <div style="float:left"><asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" OnClick="btnExportar_Click" Enabled="false" /></div>
        </asp:Panel>
        <asp:Panel ID="pnlNuevoTraspaso" runat="server" Visible="false">
            <table style="width:300px; text-align: left">
                <tr>
                    <td colspan="2"><span class="fuenteReporte" style="font-weight:bold">TARJETAS</span></td>
                </tr>
                <tr style="height:30px">
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td><span class="fuenteReporte">Origen:</span></td>
                    <td><asp:TextBox ID="txtOrigenC" runat="server" CssClass="cajatexto"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOrigenC" Display="Dynamic" ErrorMessage="Ingrese una Tarjeta Origen" ForeColor="Red" ValidationGroup="Consulta">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><span class="fuenteReporte">Destino:</span></td>
                    <td><asp:TextBox ID="txtDestinoC" runat="server" CssClass="cajatexto"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDestinoC" Display="Dynamic" ErrorMessage="Ingrerse una Tarjeta destino" ForeColor="Red" ValidationGroup="Consulta">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:left;">
                        <asp:Button ID="btnConultar" runat="server" Text="Consultar" OnClick="btnConultar_Click" ValidationGroup="Consulta" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Consulta" />
                    </td>
                </tr>
            </table><br /><br />
            <asp:Panel ID="pnlSinInfo" runat="server" Visible="false">
                <div class="titulo">

                </div>
            </asp:Panel>
            <asp:Panel ID="pnlDatos" runat="server" Visible="false">
                <table style="text-align:left; width:700px">
                    <tr>
                        <td></td>
                        <td><span class="fuenteReporte" style="font-weight:bold">ORIGEN</span></td>
                        <td><span class="fuenteReporte" style="font-weight:bold">DESTINO</span></td>
                        <td><span class="fuenteReporte" style="font-weight:bold">TRASPASO</span></td>
                    </tr>
                    <tr style="height:20px">
                        <td><span class="fuenteReporte">Tarjeta</span></td>
                        <td>
                            <asp:Label ID="lblTarjetaO" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblTarjetaD" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr style="height:20px">
                        <td><span class="fuenteReporte">Nombre</span></td>
                        <td>
                            <asp:Label ID="lblNombreO" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblNombreD" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblNombreT" runat="server" CssClass="fuenteReporte" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><span class="fuenteReporte">Vigencia:</span></td>
                        <td>
                            <asp:Label ID="lblVigenciaO" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblVigenciaD" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="lblVigenciaT" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><span class="fuenteReporte">Fecha Activación</span></td>
                        <td>
                            <asp:Label ID="lblFechaO" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFechaD" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFechaT" runat="server" CssClass="fuenteReporte" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><span class="fuenteReporte" CssClass="fuenteReporte">Estatus</span></td>
                        <td>
                            <asp:Label ID="lblEstatusO" runat="server" CssClass="fuenteReporte" ForeColor="red"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEstatusD" runat="server" CssClass="fuenteReporte" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblEstatusT" runat="server" CssClass="fuenteReporte" Visible="False" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><span class="fuenteReporte">Saldo</span></td>
                        <td>
                            <asp:Label ID="lblSaldoO" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSaldoD" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSaldoT" runat="server" CssClass="fuenteReporte" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><span class="fuenteReporte">Boomerangs</span></td>
                        <td>
                            <asp:Label ID="lblBoomerangsO" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblBoomerangsD" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblBoomerangsT" runat="server" CssClass="fuenteReporte" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><span class="fuenteReporte">Nivel</span></td>
                        <td>
                            <asp:Label ID="lblNivelO" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblNivelD" runat="server" CssClass="fuenteReporte"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblNivelT" runat="server" CssClass="fuenteReporte" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><span class="fuenteReporte">Sucursal</span></td>
                        <td colspan="3">
                            <asp:Label ID="lblSucursal" runat="server" Text="Suc. Call Center" CssClass="fuenteReporte"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><span class="fuenteReporte">Motivo</span></td>
                        <td colspan="3">
                            <asp:TextBox ID="txtMotivo" runat="server" Height="51px" TextMode="MultiLine" Width="252px" CssClass="cajatexto" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtMotivo" Display="Dynamic" ErrorMessage="* Campo requerido" ForeColor="Red" ValidationGroup="Confirmar"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table><br />
                <telerik:RadWindow ID="RadWindow1" runat="server" Modal="True" Width="382px" Skin="Bootstrap">
                    <ContentTemplate>
                        <table style="width:100%; text-align: left;">
                            <tr>
                                <td colspan="2" class="fuenteReporte" style="text-align:center">Activar tarjeta</td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align:left;" class="fuenteReporte">Campos obligatorios (<span style="color:red">*</span>)</td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td class="fuenteReporte">Nombre</td>
                                <td>
                                    <asp:TextBox ID="txtNombreA" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1"></td>
                                <td class="auto-style1"></td>
                            </tr>
                            <tr>
                                <td class="fuenteReporte">Ap. Paterno</td>
                                <td>
                                    <asp:TextBox ID="txtApPaternoA" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="fuenteReporte">Ap. Materno</td>
                                <td>
                                    <asp:TextBox ID="txtApMaternoA" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="fuenteReporte">F. Nacimiento</td>
                                <td>
                                    <telerik:RadDatePicker ID="rdpFechaNacA" Runat="server" Height="29px" Width="200px" FocusedDate="1900-01-01" MinDate="1900-01-01">
                                        <calendar culture="es-ES" enableweekends="True" fastnavigationnexttext="&amp;lt;&amp;lt;" usecolumnheadersasselectors="False" userowheadersasselectors="False">
                                        </calendar>
                                        <dateinput  displaydateformat="dd/MM/yyyy" height="29px" labelwidth="40%">
                                            <emptymessagestyle resize="None" />
                                            <readonlystyle resize="None" />
                                            <focusedstyle resize="None" />
                                            <disabledstyle resize="None" />
                                            <invalidstyle resize="None" />
                                            <hoveredstyle resize="None" />
                                            <enabledstyle resize="None" />
                                        </dateinput>
                                        <datepopupbutton hoverimageurl="" imageurl="" />
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="fuenteReporte">Correo e.</td>
                                <td>
                                    <asp:TextBox ID="txtEmailA" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="fuenteReporte">Telefono</td>
                                <td>
                                    <asp:TextBox ID="txtTelefonoA" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="fuenteReporte">Telefono M.</td>
                                <td>
                                    <asp:TextBox ID="txtTelefonoMA" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="fuenteReporte">Sexo</td>
                                <td>
                                    <telerik:RadDropDownList ID="rdpSexoA" runat="server" Skin="Bootstrap" Width="200px" Enabled="False">
                                        <Items>
                                            <telerik:DropDownListItem Value="0" Text="Selecciona"/>
                                            <telerik:DropDownListItem Value="1" Text="Hombre"/>
                                            <telerik:DropDownListItem Value="2" Text="Mujer"/>
                                        </Items>
                                    </telerik:RadDropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="rdpSexoA" Display="Dynamic" ErrorMessage="Seleccione una opción" ForeColor="Red" InitialValue="0" ValidationGroup="Activar">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align:center">
                                    <asp:Button ID="Button1" runat="server" Text="Activar" OnClick="Button1_Click" ValidationGroup="Activar" />
                                    &nbsp; &nbsp; &nbsp;
                                    <asp:Button ID="Button2" runat="server" Text="Cancelar" OnClick="Button2_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </telerik:RadWindow>
                <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                </telerik:RadWindowManager>
                <br />

                <br />
                <div id="botones"><asp:Button ID="btnConfirmar" runat="server" OnClick="btnConfirmar_Click" Text="Confirmar" ValidationGroup="Confirmar"/>&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CausesValidation="False" /></div>
            </asp:Panel>
        </asp:Panel>
</center>
</asp:Content>