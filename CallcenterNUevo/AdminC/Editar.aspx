<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="CallcenterNUevo.AdminC.Editar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <%--<script src="../Scripts/jquery-1.7.1.min.js"></script>--%>
    <%--<script src="../Scripts/jquery-ui-1.8.20.min.js"></script>--%>

    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
      <script>
          function OcultaImg() {
              //var img = document.getElementById("imgEcommerce");
              //img.style.display = "none";

              $("#imgEcommerce").hide();
          }
      </script>

    <script type="text/javascript">
        function Mayusculas(input) {
            input.value = input.value.toUpperCase();
        }

        function soloNumeros(e) {

            var key = window.Event ? e.which : e.keyCode

            return (key >= 48 && key <= 57)

        }
        function ValidaCaracter(sender, args) {
            var texto = document.getElementById("MainContent_txtMensaje").value;
            if (texto.indexOf('|') != -1) {
                args.IsValid = false;
                return;
            }
            if (texto.indexOf('<') != -1) {
                args.IsValid = false;
                return;
            }
            if (texto.indexOf('>') != -1) {
                args.IsValid = false;
                return;
            }
            if (texto.indexOf(',') != -1) {
                args.IsValid = false;
                return;
            }
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
        input[type=text] {
            max-width:480px;
            max-height=150px;
            border: 1px;
            border-style: solid;
            border-color: #495ef1;
            border-radius: 5px;
            /*width: 300px;*/
            color: #000000;
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
            font-size: 11px;
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


    <asp:UpdatePanel runat="server" ID="upEditCupones">
        <ContentTemplate>
    <center><br /><br />
        <div id="title" class="titulo">Edición de cupón</div><br /><br />
        <asp:Panel ID="pnlBusqueda" runat="server" GroupingText="Búsqueda" Width="650px">
            <div style="width:750px; height:100%">
                <asp:TextBox ID="txtBuscar" runat="server" MaxLength="13"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="fteBuscar" runat="server" FilterType="Numbers"
                                                                TargetControlID="txtBuscar">
                 </cc1:FilteredTextBoxExtender>
                <asp:Button ID="btnBuscar" runat="server" style="float:right; width:170px" Text="Buscar" OnClick="btnBuscar_Click" ValidationGroup="ValidaBusqueda"/>
                <br /><br />
                <asp:Panel ID="pnlResultados" runat="server" Visible="false">
                    <telerik:RadGrid runat="server" ID="rgResultado" AutoGenerateColumns="False" Skin="Bootstrap" OnItemCommand="rgResultado_ItemCommand" CellSpacing="-1" GridLines="Both" AllowPaging="True" OnPageIndexChanged="rgResultado_PageIndexChanged" Width="720px">
                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                        <MasterTableView NoMasterRecordsText="No hay información para mostrar">
                            <RowIndicatorColumn Visible="False">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Created="True">
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
                                        <asp:Button ID="btnEditar" runat="server" CommandName="Editar" Text="Seleccionar" Width="150px" CommandArgument='<%# Eval("Id") %>'   CssClass ="btnAsigna"/>
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
        <asp:Panel ID="pnlEdicion" runat="server" Visible="false">
            <div style="width:650px; margin-left:-100px"><asp:HiddenField ID="hdnId" runat="server" />
                <h4>Actualiza los datos del cupón: <asp:Label ID="lblCupon" runat="server"></asp:Label><asp:Button ID="btnEdit" runat="server" Text="Editar" style="float:right;" OnClientClick="OcultaImg()" OnClick="btnEdit_Click"/></h4>
            </div>
            <br /><br />
            <table class="Texto" style="padding: 5px 5px 5px 5px; width:750px; text-align:left;">
                <tr>
                    <td><span style="color:red">*</span>Cupón:</td>
                    <td><asp:TextBox ID="txtCupon" runat="server" MaxLength="13" Enabled="false" Width="150px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqfvCupon" runat="server" ControlToValidate="txtCupon" Display="Dynamic" ErrorMessage="Ingresar un número de cupón" CssClass="tooltipDemo" ValidationGroup="ValidaDatos"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCupon" CssClass="tooltipDemo" Display="Dynamic" ErrorMessage="número de cupón no valido" ValidationExpression="[0-9]{13}" ValidationGroup="ValidaDatos"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:180px"><span style="color:red">*</span>Tipo Cupón:</td>
                    <td>
                         <telerik:RadComboBox ID="rcbTipoCupon" AutoPostBack="true" ZIndex="99999"   RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  runat="server" OnSelectedIndexChanged="rcbTipoCupon_SelectedIndexChanged"   Width="150px"  TabIndex="2" Enabled="false" >
                         </telerik:RadComboBox>&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="txtDescuento" runat="server" MaxLength="2" Width="20px" Enabled="false" Visible="false" OnTextChanged="txtDescuento_TextChanged" ></asp:TextBox><asp:Label ID="lblsignoPorc" runat="server" Text=" %" Visible="false"></asp:Label>
                         <asp:FilteredTextBoxExtender ID="ftbDescuento" runat="server" FilterType="Numbers" TargetControlID="txtDescuento"></asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                 <tr>
                    <td><asp:Label ID="lblcodint" runat="server" Text="Código interno:" Visible="false"></asp:Label></td>
                    <td><asp:TextBox ID="txtCodigointerno" runat="server" MaxLength="13" Width="150px" Enabled="false" Visible="false"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftbCodigointerno" runat="server" FilterType="Numbers" TargetControlID="txtCodigointerno"></asp:FilteredTextBoxExtender>
                </tr>

                <tr>
                <td style="width:180px">
                <asp:Label ID="lblTipoPromoTrigger" runat="server"  Text="Promoción de tipo trigger:" Visible="false" ></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="rcbPromoTipoTrigger" AutoPostBack="false" ZIndex="99999"   RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  runat="server"   Width="250px"  TabIndex="2" visible="false" Enabled="false">
                    </telerik:RadComboBox>
                </td>
                </tr>

                <tr>
                    <td><span style="color:red;">*</span>IDPromo:</td>
                    <td><asp:TextBox ID="txtIDPromo" runat="server" MaxLength="7" Width="150px" Enabled="false"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIDPromo" Display="Dynamic" ErrorMessage="Ingresar un IDPromo" CssClass="tooltipDemo" ValidationGroup="ValidaDatos"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtIDPromo" ValidationGroup ="ValidaDatos" ValidationExpression="[0-9]{1,7}" ErrorMessage="Soló se permiten números" CssClass="tooltipDemo" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td><span style="color:red">*</span>Nombre de promoción:</td>
                    <td><asp:TextBox ID="txtNombrePromo" runat="server" Enabled="false" Width="310px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombrePromo" Display="Dynamic" ErrorMessage="Ingresar un nombre de promoción" CssClass="tooltipDemo" ValidationGroup="ValidaDatos"></asp:RequiredFieldValidator></td>
            
                </tr>
                <tr>
                    <td valign="top"><span style="color:red;">*</span>Mensaje(POS):</td>
                    <td><asp:TextBox ID="txtMensaje" runat="server" MaxLength="110" BorderStyle="None" Enabled="false" Width="480px" Height="70px" onkeypress="return isokmaxlength(event,this,110);" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMensaje" Display="Dynamic" ErrorMessage="Ingresar el mensaje que aparecera en el POS" CssClass="tooltipDemo" ValidationGroup="ValidaDatos"></asp:RequiredFieldValidator>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMensaje" Display="Dynamic" ErrorMessage="No se permiten comas(,), menos que(<), mayor que(>) y pipe(|)" ToolTip="No se permiten comas(,), menos que(<), mayor que(>) y pipe(|)" ValidationExpression="([A-Za-z0-9áéíóú%!#$&Ññ/()?¿{}\s]*)" SetFocusOnError="true" CssClass="tooltipDemo" ValidationGroup="ValidaDatos">No se permiten comas(,), menos que(<), mayor que(>) y pipe(|)</asp:RegularExpressionValidator>--%>
                        <asp:CustomValidator ID="customvalidator1" runat="server" ClientValidationFunction="ValidaCaracter" ControlToValidate="txtMensaje" CssClass="tooltipDemo" Display="Dynamic" ErrorMessage="* No se permiten comas(,), menos que(&lt;), mayor que(&gt;) y pipe(|)" ValidationGroup="ValidaDatos"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td><span style="color:red">*</span>Sucursal:</td>
                    <td><telerik:RadDropDownList runat="server" ID="rcmbSucursal" Enabled="false" Skin="Bootstrap" >
                        <Items>
                            <telerik:DropDownListItem  Text="Todas" Value="0"/>
                        </Items>
                        </telerik:RadDropDownList></td>
                </tr>
                <tr>
                    <td><span style="color:red;">*</span>Estatus:</td>
                    <td><telerik:RadDropDownList runat="server" ID="rcmbEstatus" Enabled="false" Skin="Bootstrap">
                            <Items>
                                <telerik:DropDownListItem  Text="" Value="-1"/>                                
                                <telerik:DropDownListItem  Text="Activo sin Asignar" Value="0"/>
                                <telerik:DropDownListItem Text="Asignado" Value="1" />
                            </Items>
                        </telerik:RadDropDownList></td>
                </tr>
                <tr>
                    <td><span style="color:red">*</span>Uso</td>
                    <td><telerik:RadDropDownList runat="server" ID="rcmbUso" Skin="Bootstrap" Enabled="false">
                           <Items>
                               <telerik:DropDownListItem Text="Selecciona" Value="-1" />
                               <telerik:DropDownListItem Text="Un solo uso" Value="1" />
                               <telerik:DropDownListItem Text="Ilimitado" Value="0" />
                           </Items>
                        </telerik:RadDropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Selecciona un tipo de uso" ControlToValidate="rcmbUso" CssClass="tooltipDemo" ValidationGroup="ValidaDatos" Display="Dynamic" SetFocusOnError="True" InitialValue="Selecciona"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><span style="color:red;">*</span>Número asignación:</td>
                    <td><telerik:RadDropDownList ID="rcmbAsignacion" runat="server" Skin="Bootstrap" Enabled="false">
                       <%-- <<%--Items>
                            <telerik:DropDownListItem Text="1" Value="1" />
                            <telerik:DropDownListItem Text="2" Value="2" />
                            <telerik:DropDownListItem Text="3" Value="3" />
                            <telerik:DropDownListItem Text="4" Value="4" />
                            <telerik:DropDownListItem Text="5" Value="5" />
                        </Items>--%>
                        </telerik:RadDropDownList>
                    </td>
                </tr>
                <tr>
                    <td><span style="color:red;">*</span>Cupones disponibles:</td>
                    <td style="text-align:match-parent">
                        <asp:RadioButton ID="rdbSinLimite" runat="server" AutoPostBack="true" Text="Sin límite" Checked="true" GroupName="cuponesdisponibles" OnCheckedChanged="rdbSinLimite_CheckedChanged" />
                        <br />
                        <asp:RadioButton ID="rdbConLimite" runat="server" AutoPostBack="true" Text="Conlímite" Checked="false" GroupName="cuponesdisponibles" OnCheckedChanged="rdbConLimite_CheckedChanged" />
                        &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCuponesDisponibles" runat="server" MaxLength="7" Text="1000000" Enabled="false" Width="70px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="ftxtext" runat="server" FilterType="Numbers" TargetControlID="txtCuponesDisponibles"></asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td><span style="color:red;">*</span>Fecha solicitud:</td>
                    <td><telerik:RadDatePicker ID="rdpFechaS" runat="server" Culture="es-MX" PopupDirection="BottomLeft" Skin="Bootstrap" Enabled="false">
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
                        </telerik:RadDatePicker></td>
                </tr>
                <tr>
                    <td><span style="color:red;">*</span>Fecha fin:</td>
                    <td>
                        <telerik:RadDatePicker ID="rdcFechaFin" runat="server" Culture="es-MX" PopupDirection="BottomLeft" Skin="Bootstrap" Enabled="false">
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rdcFechaFin" CssClass="tooltipDemo" Display="Dynamic" ErrorMessage="Selecciona una fecha de fin" ValidationGroup="ValidaDatos"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
            <td>
                 Ecommerce:
            </td>
            <td>
                 <asp:TextBox ID="txtEcommerce" runat="server" MaxLength="500"  Width="480px" Height="70px" TextMode="MultiLine" onkeypress="return isokmaxlength(event,this,500);" Enabled="false" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Imagen Ecommerce:
            </td>
            <td>
                <asp:Image ID="imgEcommerce" runat="server"  Width="250px" Height="250px"/>
                <asp:FileUpload ID="fupEcommerce"  cssClass="input"  runat="server" EnableViewState="True" Enabled="false" Visible="false" />
            </td>
        </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center">
                         <asp:UpdatePanel ID="upbtns" runat="server">
                            <ContentTemplate>
                        <asp:Button ID="btnCanelar" runat="server" Text="Cancelar" Visible="false" OnClick="btnCanelar_Click" Width="150px" />&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnAutoriza" runat="server" OnClick="btnAutoriza_Click" Text="Confirmar" Visible="false" Width="150px" ValidationGroup="ValidaDatos" />
                          </ContentTemplate>
                               <%-- <Triggers>
                                <asp:PostBackTrigger ControlID="btnAutoriza" />
                                </Triggers>--%>
                        </asp:UpdatePanel>      
                    </td>
                </tr>
            </table>    
        </asp:Panel>
    </center>

    <div id="openModal" class="modalDialog">
         <div>
            <%--<a href="#close"  class="close">X</a>--%>
            <h4>Confirmar operación</h4>
            <table class="Texto">
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
                <td colspan="2"><asp:Button ID="btnCancela" runat="server" Text="Cancelar" style="width:150px" OnClick="btnCancela_Click"/>&nbsp;&nbsp;<asp:Button ID="btnConfirmaContinua" runat="server" Text="Continuar" style="width:150px" OnClick="btnConfirmaContinua_Click" /></td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
        </table>
        </div>
        
    </div>
    </ContentTemplate>
     </asp:UpdatePanel>
  
</asp:Content>

