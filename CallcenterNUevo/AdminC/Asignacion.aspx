<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"   CodeBehind="Asignacion.aspx.cs" Inherits="CallcenterNUevo.AdminC.Asignacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
 
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.20.min.js"></script>

    <script type="text/javascript">

        function Mayusculas(input) {
            input.value = input.value.toUpperCase();
        }

        function soloNumeros(e) {

            var key = window.Event ? e.which : e.keyCode

            return (key >= 48 && key <= 57)

        }
        function validateUpload(sender, args) {
            var upload = $find("RadAsyncUpload1");
            args.IsValid = upload.getUploadedFiles().length != 0;
        }
        function CheckDateIni(sender, args) {
            var fecha = Date.now();
            var fechaselec = $find("<%= rdcFInicioCanje.ClientID %>");

            if (fechaselec.get_dateInput < fecha) {
                args.IsValid = false;
                return;
            }
            //args.IsValid = true;
        }
        function CheckDateFin(sender, args) {
            var fecha = Date.now();
            var fechaselec = $find("<%= rdcFFinCanje.ClientID %>");

            if (fechaselec.get_dateInput < fecha) {
                args.IsValid = false;
                return;
            }
            //args.IsValid = true;
        }

        function isokmaxlength(e, val, maxlengt) {
            var charCode = (typeof e.which == "number") ? e.which : e.keyCode

            if (!(charCode == 44 || charCode == 46 || charCode == 0 || charCode == 8 || (val.value.length < maxlengt))) {
                return false;
            }
        }
    </script>
     <style>
        .RadGrid_Default .rgHeader, .RadGrid_Default th.rgResizeCol, .RadGrid_Default .rgHeaderWrapper {
            background: #2B347A 0 -2300px repeat-x !important;
            color: #fff !important;
            font-size: 12pt !important;
        }
        .RadGrid_Bootstrap .rgHeader, .RadGrid_Bootstrap .rgHeader a {
             background: #2B347A 0 -2300px repeat-x !important;
            color: #fff !important;            
        }
        .RadUpload .ruBrowse {
             width: 125px !important;
        }
        .RadUpload .ruButton{
             width: 125px !important;
        }

        input[type=text] {
            border: 1px;
            border-style: solid;
            border-color: #495ef1;
            border-radius: 5px;
            width: 300px;
            height: 26px;
            color: #000000;
        }

        /*input[type=text] {
            border: 1px;
            border-style: solid;
            border-color: #495ef1;
            border-radius: 5px;
            width: 300px;
            color: #000000;
        }*/

        .Texto {
            width: 550px;
            font-family: Arial;
            font-size: 12pt;
            color: #2b347a;
        }

        h3 {
            font-family: Arial;
            color: #2b347a;
        }
        .titulo {
            font-family: Arial;
            font-size: 16pt;
            color: #2B347A;
            margin-left: -100px;
        }

        table {
            border-collapse: collapse;
            border-spacing: 10px 5px;
            height:auto !important;
        }

        .tooltipDemo {
            background: #f70606;
            border-radius: 5px;
            color: #fff !important;
            width: 150px;
            left: 0px;
            top: 0px;
            font-size: 12pt;
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
        input[type=text]::-webkit-input-placeholder { /* WebKit browsers */
        color: #808080;
        }
        input[type=text]:-moz-placeholder { /* Mozilla Firefox 4 to 18 */
        color: #808080;
        }
        input[type=text]::-moz-placeholder { /* Mozilla Firefox 19+ */
        color: #808080;
        }
        input[type=text]:-ms-input-placeholder { /* Internet Explorer 10+ */
        color: #808080;
        }
        .modalDialog {
            position: fixed;
            font-family: Arial, Helvetica, sans-serif;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            background: rgba(0,0,0,0.8);
            z-index: 99999;
            -webkit-transition: opacity 400ms ease-in;
            -moz-transition: opacity 400ms ease-in;
            transition: opacity 400ms ease-in;
            display: none;
            /*pointer-events: none;*/

        }

        /*.modalDialog:target {
            display: block;
            pointer-events: auto;
        }*/

        .modalDialog > div {
            width: 400px;
            position: relative;
            margin: 10% auto;
            padding: 5px 20px 13px 20px;
            border-radius: 10px;
            background: #fff;
            background: -moz-linear-gradient(#fff, #999);
            background: -webkit-linear-gradient(#fff, #999);
            background: -o-linear-gradient(#fff, #999);
            z-index: 999999;
        }
    </style>    
     
    <center><br /><br />
        <div id="title" class="titulo">Asignación de cupón</div><br /><br />
        <asp:Panel ID="pnlBusqueda" runat="server" GroupingText="Búsqueda" Width="650px">
            <div style="width:600px; height:100%">
                <asp:TextBox ID="txtBuscar" runat="server" MaxLength="13"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="fteBuscar" runat="server" FilterType="Numbers"
                                                                TargetControlID="txtBuscar">
                 </cc1:FilteredTextBoxExtender>
                <asp:Button ID="btnBuscar" runat="server" style="float:right; width:170px" Text="Buscar" OnClick="btnBuscar_Click"/><br /><br />
                <asp:Panel ID="pnlResultados" runat="server" Visible="false">
                    <telerik:RadGrid runat="server" ID="rgResultado" AutoGenerateColumns="False" Skin="Bootstrap" OnItemCommand="rgResultado_ItemCommand" CellSpacing="-1" GridLines="Both" AllowPaging="True" Culture="es-MX" OnPageIndexChanged="rgResultado_PageIndexChanged">
                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                        <MasterTableView NoMasterRecordsText="No hay información para mostrar">
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="41px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Created="True">
                                <HeaderStyle Width="41px" />
                            </ExpandCollapseColumn>                            
                            <Columns>                                
                                <telerik:GridBoundColumn DataField="Cupon" FilterControlAltText="Filter column1 column" HeaderText="Cupón" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn DataField="TipoCupon" FilterControlAltText="Filter column2 column" HeaderText="TipoCupon" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="IdPromo" FilterControlAltText="Filter column2 column" HeaderText="IDPromo" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Mensaje" FilterControlAltText="Filter column3 column" HeaderText="Mensaje (POS)" UniqueName="column3">
                                </telerik:GridBoundColumn>   
                                <telerik:GridTemplateColumn DataField="Id">
                                    <ItemTemplate>                                        
                                        <asp:Button ID="btnEditar" runat="server" CommandName="Asignar" Text="Ver" CommandArgument='<%# Eval("Id") %>' CssClass="btnAsigna" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>                     
                            </Columns>
                        </MasterTableView>
                        <HeaderStyle BackColor="#2B347A" ForeColor="#fff" Font-Size="12pt" />
                        <PagerStyle ChangePageSizeButtonToolTip="Cambiar tamaño de página" FirstPageToolTip="Primera página" GoToPageButtonToolTip="Ir a la página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, fila &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Tamaño de página:" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                    </telerik:RadGrid>
                </asp:Panel>
                <asp:Panel ID="pnlSinInfo" runat="server">
                    <h3>No se encontró información</h3>
                </asp:Panel>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlDatos" runat="server">
            <div style="width:650px; margin-left:-100px"><asp:HiddenField ID="hdnId" runat="server" />
                <h4 style="margin-left: -100px">Datos del cupón a asignar: <asp:Label ID="lblCupon" runat="server"></asp:Label></h4>
            </div>
            <br /><br />
            <table class="Texto" style="padding: 5px 5px 5px 5px; width:550px; text-align:left;">
                <tr>
                    <td style="width:180px">Cupón:</td>
                    <td><asp:Label ID="lblDCupon" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width:180px">Tipo Cupón:</td>
                    <td><asp:Label ID="lblTipoCupon" runat="server"></asp:Label></td>
                </tr>
                 <tr>
                    <td style="width:180px"><asp:Label ID="lblEtiquetaDescuento" runat="server" Text="Descuento:" Visible="false"></asp:Label></td>
                    <td><asp:Label ID="lblDescuento" runat="server" Visible="false"></asp:Label><asp:Label ID="lblsignoPorc" runat="server" Text=" %" Visible="false"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:180px"><asp:Label ID="lbletiquetacodint" runat="server" Text="Código interno:" Visible="false"></asp:Label></td>
                    <td><asp:Label ID="lblcodigointerno" runat="server" Visible="false"></asp:Label></td>
                </tr>


                <tr>
                <td style="width:180px">
                <asp:Label ID="lblTipoPromoTrigger" runat="server"  Text="Promoción de tipo trigger:" Visible="false" ></asp:Label>
                </td>
                <td>
                    <asp:Label id="lblPromoTipoTrigger" runat="server" Visible="false" Enabled="false" ></asp:Label>
                    <asp:HiddenField ID="hFldIdentificador" runat="server" />
                </td>
                </tr>


                <tr>
                    <td>IDPromo:</td>
                    <td><asp:Label ID="lblDIdPromo" runat="server"></asp:Label></td>
            
                </tr>
                <tr>
                    <td>Nombre de promoción:</td>
                    <td><asp:Label ID="lblDNombrePromo" runat="server"></asp:Label></td>
            
                </tr>
                <tr>
                    <td valign="top">Mensaje(POS):</td>
                    <td>
                        <%--<asp:Label id="lblDMensaje" runat="server"></asp:Label>--%>
                        <asp:TextBox ID="txtDMensaje" runat="server" TextMode="MultiLine" Width="480px" Height="80px" BorderStyle="None" ReadOnly="true" onkeypress="return isokmaxlength(event,this,110);"></asp:TextBox>
                    </td>
            
                </tr>
                <tr>
                    <td>Sucursal:</td>
                    <td><asp:Label ID="lblDSucursal" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Estatus:</td>
                    <td><asp:Label ID="lblDEstatus" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Uso:</td>
                    <td><asp:Label ID="lblDUso" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Número asignación:</td>
                    <td><asp:Label ID="lblDNumAsignacion" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>Fecha solicitud:</td>
                    <td>
                        <asp:Label ID="lblFechaSolicitud" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Fecha fin:</td>
                    <td>
                        <asp:Label ID="lblDFechaFin" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align:right;"><asp:Button ID="btnCanelar" runat="server" Text="Cancelar" Visible="false" OnClick="btnCanelar_Click" style="width:150px"/></td>
                    <td>&nbsp;&nbsp;<asp:Button ID="btnAutoriza" runat="server" Text="Continuar" Visible="false" OnClick="btnAutoriza_Click" style="width:150px"/></td>
                </tr>
            </table>    
        </asp:Panel>
        <asp:Panel ID="pnlAsignacion" runat="server">
            <div style="width:650px; margin-left:-100px"><asp:HiddenField ID="HiddenField1" runat="server" />
                <h4 style="margin-left: -170px">Asignar el cupón: <asp:Label ID="lblCupon2" runat="server"></asp:Label></h4>
            </div>
            <table class="Texto" style="padding: 5px 5px 5px 5px; width:650px; text-align:left;">
                <tr>
                    <td style="width:250px"><span style="color:red">*</span>Tipo de asignación</td>
                    <td><asp:RadioButtonList ID="rblTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblTipo_SelectedIndexChanged" RepeatLayout="Flow">
                            <asp:ListItem Text="Tarjeta" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Archivo Excel" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rqfvTipo" runat="server" CssClass="tooltipDemo" ControlToValidate="rblTipo" ErrorMessage="Selecciona un tipo de asignación" InitialValue="-1" Display="Dynamic" ValidationGroup="Asignacion"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" id="trTarjeta">
                    <td><span style="color:red;">*</span>Tarjeta:</td>
                    <td><asp:TextBox ID="txtTarjeta" runat="server" MaxLength="11" Width="160px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqfvTarjeta" runat="server" Text="Debe escribir el número de Tarjeta." Display="Dynamic" ControlToValidate="txtTarjeta" ValidationGroup="Asignacion" CssClass="tooltipDemo"></asp:RequiredFieldValidator>
                        <asp:FilteredTextBoxExtender ID="ftbTarjeta" runat="server" FilterType="Numbers"
                                                 TargetControlID="txtTarjeta"></asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr runat="server" id="trArchivo">
                    <td><span style="color:red;">*</span>Adjuntar archivo:</td>
                    <td>
                        <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" AllowedFileExtensions=".xls,.xlsx" Culture="es-MX" Skin="Bootstrap" EnableEmbeddedSkins="False" MultipleFileSelection="Disabled" AutoAddFileInputs="false" Width="150px">
                            <Localization Cancel="Cancelar" Remove="Quitar archivo" Select="Adjuntar archivo" />
                        </telerik:RadAsyncUpload>
                       <%-- <asp:CustomValidator ID="rqfvArchivo" runat="server" Text="Debe seleccionar un archivo de excel" Display="Dynamic" ValidationGroup="Asignacion" CssClass="tooltipDemo" ClientValidationFunction="validateUpload"></asp:CustomValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>Fecha inicio(disponible para canje):</td>
                    <td>
                        <telerik:RadDatePicker ID="rdcFInicioCanje" runat="server" Culture="es-MX" PopupDirection="BottomLeft" Skin="Bootstrap" >
                        <Calendar Culture="es-MX" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"  CellVAlign="Top" Skin="Bootstrap">
                            <CalendarTableStyle VerticalAlign="Top" />
                        </Calendar>
                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%" >
                            <EmptyMessageStyle Resize="None" />
                            <ReadOnlyStyle Resize="None" />
                            <FocusedStyle Resize="None" />
                            <DisabledStyle Resize="None" />
                            <InvalidStyle Resize="None" />
                            <HoveredStyle Resize="None" />
                            <EnabledStyle Resize="None" />
                        </DateInput>                
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker><asp:Label ID="lblErrorFecha" CssClass="tooltipDemo" runat="server" Visible="false"></asp:Label>                              
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdcFInicioCanje" CssClass="tooltipDemo" Display="Dynamic" ErrorMessage="Selecciona una fecha" ValidationGroup="Asignacion"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="CheckDateIni" ControlToValidate="rdcFInicioCanje" CssClass="tooltipDemo" Display="Dynamic" ErrorMessage="La fecha de inicio no puede ser menor a hoy" ValidationGroup="Asignacion"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>Fecha fin(fin de canje):</td>
                    <td>
                        <telerik:RadDatePicker ID="rdcFFinCanje" runat="server" Culture="es-MX" PopupDirection="BottomLeft" Skin="Bootstrap">
                        <Calendar Culture="es-MX" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" EnableKeyboardNavigation="True" Skin="Bootstrap" CellVAlign="Top">
                            <CalendarTableStyle VerticalAlign="Top" />
                        </Calendar>
                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                            <EmptyMessageStyle Resize="None" />
                            <ReadOnlyStyle Resize="None" />
                            <FocusedStyle Resize="None" />
                            <DisabledStyle Resize="None" />
                            <InvalidStyle Resize="None" />
                            <HoveredStyle Resize="None" />
                            <EnabledStyle Resize="None" />
                        </DateInput>                
                            <DatePopupButton HoverImageUrl="" ImageUrl="" />
                        </telerik:RadDatePicker>      
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdcFFinCanje" CssClass="tooltipDemo" Display="Dynamic" ErrorMessage="Selecciona una fecha fin" ValidationGroup="Asignacion"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="rdcFInicioCanje" ControlToValidate="rdcFFinCanje" CssClass="tooltipDemo" Display="Dynamic" ErrorMessage="No puedes seleccionar una fecha inicio mayor a la fecha fin" Operator="GreaterThan" Type="Date" ValidationGroup="Asignacion"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>                    
                    <td colspan="2" style="text-align:center;"><asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CausesValidation="false" Width="150px" OnClick="btnCancelar_Click"/> &nbsp;&nbsp;<asp:Button ID="btnContinuaAsignacion" runat="server" Text="Continuar" style="width:150px" ValidationGroup="Asignacion" OnClick="btnContinuaAsignacion_Click1" Width="150px"/></td>
                </tr>
            </table>
        </asp:Panel>
    </center>

     <div id="openModal" class="modalDialog"> 
         <div>
            <a href="#close"  class="close">X</a>
            <h4>Confirmar operación</h4>
            <table style="width: 318px !important;">
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    ¿Desea guardar los cambios realizados?
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:right;" colspan="2"><asp:Button ID="btnCancela" runat="server" Text="Cancelar" style="width:150px" OnClick="btnCancela_Click"/>
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnConfirmaContinua" runat="server" Text="Continuar" style="width:150px" OnClick="btnConfirmaContinua_Click" /></td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
        </table>
        </div>
        
    </div>


      <%-- Popup Mensaje --%>
            <asp:Panel ID="pnlMsgRespuesta" runat="server"  HorizontalAlign="Center" >
                <asp:Table ID="tblMsgRespuesta" runat="server" CellSpacing="12" CellPadding="8"  Width="350px" BackColor="LightGray" Visible="false">
                    <asp:TableRow>
					    <asp:TableCell>
                            <br />
                            Total tarjetas:
					    </asp:TableCell>
                        <asp:TableCell>
                             <br />
                           <asp:Label ID="lblTot" runat="server" ></asp:Label>
					    </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
					    <asp:TableCell>
                           Total tarjetas asignadas:
					    </asp:TableCell>
                        <asp:TableCell>
                           <asp:Label ID="lblTotAsig" runat="server" ></asp:Label>
					    </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
					    <asp:TableCell>
                           Total tarjetas ya contaban con cupón:
					    </asp:TableCell>
                        <asp:TableCell>
                           <asp:Label ID="lblTotconCupon" runat="server" ></asp:Label>
					    </asp:TableCell>
                    </asp:TableRow>

					<asp:TableRow>
                        <asp:TableCell ColumnSpan ="2">
                            <br /><br />
                        <asp:Button runat="server" ID="btnAceptar"  Text="Aceptar" Width="100px" OnClick="btnAceptar_Click"  CssClass="input" TabIndex="1" />
                                <br /> <br />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:Panel>


             <cc1:ModalPopupExtender ID="mpeMsgRespuesta" runat="server" TargetControlID="btnMsgExt" PopupControlID="pnlMsgRespuesta" CancelControlID="btnCancelarExtender" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

            <asp:Button ID="btnMsgExt" runat="server" Text="" BackColor="Transparent" BorderStyle="None" Width="0px" Enabled="false"/>
            <asp:Button ID="btnCancelarExtender" runat="server" Text="" BackColor="Transparent" BorderStyle="None" Width="0px" Enabled="false" />

</asp:Content>
