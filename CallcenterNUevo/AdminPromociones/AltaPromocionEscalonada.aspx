<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaPromocionEscalonada.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.AltaPromocionEscalonada" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.20.min.js"></script>

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

    <script type="text/javascript">
        function GetKey(e) {
            var keynum;
            if (window.event) { keynum = e.keyCode; }
            else if (e.which) { keynum = e.which; }
            return keynum;
        }

        function GetChar(ev) {
            var ev = ev || window.event;
            var chr = ev.charCode || ev.keyCode;
            return String.fromCharCode(chr);
        }

        function ValidarTecla(ev) {
            var key = GetKey(ev);
            //if (!(key == 44 || key == 45 || key == 46 || key == 13 || (key >= 48 && key <= 57))) {
            if (!(key == 46 || key == 13 || (key >= 48 && key <= 57))) {
                var chr = GetChar(ev);
                if (/^\d[,|\.]\d*/.test(chr)) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return true;
            }
        }
        </script>

    
    <asp:Label runat="server" ID="lblTitulo" Text="Alta de promoción escalonada"  Font-Size="16px" ForeColor="DarkBlue"/>
    <asp:UpdatePanel ID="upModificaPromocionDescuentos" runat="server">
        <ContentTemplate>
         <center>  
                    <asp:Table ID="tblPromoEsc" runat="server" >
                    <asp:TableRow>
                        <asp:Tablecell columspan="2" >
                            <asp:Table ID="tblFechas" runat="server">
                                <asp:TableRow>
                                <asp:TableCell  Height="38px" width="220px">
                                    <asp:Label ID="Label1" runat="server" Text="Fecha Inicio:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell  Height="38px" width="220px">
                                    <telerik:RadDatePicker ID="rdpFechaInicio" runat="server" Calendar-ViewSelectorText="false"  AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFechaInicio_SelectedDateChanged" Width="140px" Enabled="true" TabIndex="1" ></telerik:RadDatePicker>
                                </asp:TableCell>
                                <asp:TableCell Height="38px">
                                </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                <asp:TableCell  Height="38px">
                                        <asp:Label ID="Label2" runat="server" Text="Fecha Fin:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell  Height="38px">
                                    <telerik:RadDatePicker ID="rdpFechaFin" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFechaFin_SelectedDateChanged" Width="140px" Enabled="true" TabIndex="2" ></telerik:RadDatePicker>
                                </asp:TableCell>
                                <asp:TableCell Height="38px">
                                </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow Height="38px">
                                <asp:TableCell >
                                    <asp:CheckBox ID="chkDuracion" runat="server" Text=""  AutoPostBack="true" OnCheckedChanged="chkDuracion_CheckedChanged" TextAlign="Right" TabIndex="3"/>&nbsp;&nbsp;
                                    <asp:Label runat="server" Text="Activar Duración cupón (días):"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell >
                                    <asp:TextBox ID="txtDuracionCupon" runat="server" Width="140px" MaxLength="2" Visible="false" OnTextChanged="txtDuracionCupon_TextChanged" TabIndex="4" ></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="ftbeDuracionCupon" runat="server" FilterType="Numbers" TargetControlID="txtDuracionCupon"></cc1:FilteredTextBoxExtender>
                                </asp:TableCell>
                            </asp:TableRow>

                               
                            



                           <asp:TableRow Height="38px">
                                <asp:TableCell >
                                    <asp:CheckBox ID="chkEsPromoTrigger" runat="server" Text=""  AutoPostBack="true" OnCheckedChanged="chkEsPromoTrigger_CheckedChanged"  TextAlign="Right" TabIndex="3"/>&nbsp;&nbsp;
                                    <asp:Label runat="server" Text="Es promo trigger"></asp:Label>
                                </asp:TableCell>
                               <asp:TableCell ColumnSpan="4">
                                   <asp:Table ID="tblOpciones" runat="server" Width="300px">
                                       <asp:TableRow  Height="38px">
                                            <asp:TableCell >
                                                <asp:RadioButton ID="rdbMontoTrigger" runat="server" GroupName="rblst" AutoPostBack="true" Checked="false"  OnCheckedChanged="rdbMontoTrigger_CheckedChanged" Visible="false"/>
                                                &nbsp;&nbsp;&nbsp;<asp:Label id="lblMontoTrigger" runat="server" Text="Monto trigger " visible="false"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell >
                                                <asp:TextBox ID="txtMontoTrigger" runat="server" Width="140px" onKeypress="return ValidarTecla(event);" Visible="false"  TabIndex="4" ></asp:TextBox>
                                            </asp:TableCell>
                                       </asp:TableRow>
                                       <asp:TableRow  Height="38px">
                                            <asp:TableCell>
                                                <asp:RadioButton ID="rdbcodInt" runat="server" GroupName="rblst" AutoPostBack="true" Checked="false" OnCheckedChanged="rdbcodInt_CheckedChanged" Visible="false"/>
                                                &nbsp;&nbsp;&nbsp;<asp:Label ID="lblCodInt" runat="server" Text="Código Interno" Visible="false"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell >
                                                <asp:TextBox ID="txtCodigoInterno" runat="server" Width="140px"  Visible="false" MaxLength="13"  TabIndex="4" ></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="ftbeCodint" runat="server" FilterType="Numbers" TargetControlID="txtCodigoInterno">
                                                </cc1:FilteredTextBoxExtender>
                                            </asp:TableCell>
                                       </asp:TableRow>
                                   </asp:Table>
                               </asp:TableCell>
                            </asp:TableRow>


                                <asp:TableRow Height="38px">
                                    <asp:TableCell Width="130px">
                                        <asp:Label ID="Label5" runat="server" Text="Retroceder escalón:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:RadioButton ID="rdbSi" runat="server" AutoPostBack ="true" OnCheckedChanged="rdbSi_CheckedChanged" Text="Sí" Checked="false" GroupName="opc" />&nbsp;&nbsp;&nbsp;
                                        <asp:RadioButton ID="rdbNo" runat="server" AutoPostBack ="true" OnCheckedChanged="rdbNo_CheckedChanged" Text="No" Checked="true" GroupName="opc" />
                                    </asp:TableCell>
                                </asp:TableRow>

                                 <asp:TableRow Height="38px">
                                    <asp:TableCell Width="130px">
                                        <asp:Label ID="lblRetornoInicial" runat="server" Text="Aplicar retorno:" Visible="false"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:RadioButton ID="rdbRetornoAnterior" runat="server" AutoPostBack ="true" Text="anterior" Checked="true" GroupName="opcRetornoIni" Visible="false" />&nbsp;&nbsp;&nbsp;
                                        <asp:RadioButton ID="rdbRetornoIni" runat="server" AutoPostBack ="true"  Text="inicio" Checked="false" GroupName="opcRetornoIni" Visible="false"/>
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow Height="38px">
                                    <asp:TableCell Width="130px">
                                        <asp:Label ID="lblUso" runat="server" Text="Uso:" Visible="false"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                      <telerik:RadDropDownList runat="server" AutoPostBack="true"  ID="rcmbUso" Skin="Bootstrap" Visible="false"  >
                                       <Items>
                                           <telerik:DropDownListItem Text="Selecciona" Value="-1" />
                                           <telerik:DropDownListItem Text="Un solo uso" Value="1" />
                                           <telerik:DropDownListItem Text="Ilimitado" Value="99" />
                                       </Items>
                                      </telerik:RadDropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Selecciona un tipo de uso" ControlToValidate="rcmbUso" CssClass="tooltipDemo" ValidationGroup="ValidaDatos" Display="Dynamic" SetFocusOnError="True" InitialValue="Selecciona"></asp:RequiredFieldValidator>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:Tablecell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell columnspan="2">
                            <br />
                            <div id="divPromEsc" style="max-height:180px;overflow-y:scroll;overflow:scroll;height:180px;width:550px;" >
                                <asp:GridView  ID="grvCupones"   ShowHeader ="true" runat="server" CssClass="gridview" AllowPaging="false"   CellSpacing ="1" AutoGenerateColumns ="false"  CellPadding="3" GridLines="Horizontal" HorizontalAlign="left" UseAccessibleHeader ="false" Width ="525px"  Height="100px" Enabled="true" >
                                <HeaderStyle ForeColor="Black" />
                                    <Columns>
                                        <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                            <HeaderTemplate>
                                                <asp:Label ID="Label13" runat="server" Text="Cupón" width ="110px"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCupon" runat="server" MaxLength="13" Text='<%# Eval("Cupon")%>'  TabIndex="5" width ="110px" Enabled="true"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="ftbeCupon" runat="server" FilterType="Numbers"
                                                TargetControlID="txtCupon">
                                                </cc1:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                            <HeaderTemplate>
                                                    <asp:Label ID="Label13" runat="server" Text="Id Promoción" width ="60px"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtIdPromocion" runat="server" Text='<%# Eval("IdPromocion")%>'  TabIndex="6" width = "60px" Enabled="true"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="ftbeIdCupon" runat="server" FilterType="Numbers"
                                                TargetControlID="txtIdPromocion">
                                                </cc1:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                            <HeaderTemplate>
                                                    <asp:Label ID="Label13" runat="server" Text="Id Promo Dispara" width ="80px"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtIdPromoDispara" runat="server" Text='<%# Eval("IdPromocionDispara")%>' TabIndex="7" width = "60px" Enabled="true"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="ftbeIdPromoDisp" runat="server" FilterType="Numbers"
                                                TargetControlID="txtIdPromoDispara">
                                                </cc1:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                            <HeaderTemplate>
                                                    <asp:Label ID="Label13" runat="server" Text="Mensaje POS" Width ="150px"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMensajePOS" runat="server" Text='<%# Eval("MensajePOS")%>' width = "300px" TabIndex="8"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                 </Columns>
                            </asp:GridView>
                            </div> 
                            <br />
                        </asp:TableCell>
                        <asp:TableCell  ColumnSpan ="2" verticalalign="top">
                            <asp:Button id="btnAgregarElementos" runat="server" Text="Agregar nuevo cupón" OnClick ="btnAgregarElementos_Click" width="200px" TabIndex="9" ></asp:Button>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="3">
                            <asp:Table ID="tblBotones" runat="server" Width="200px">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick ="btnGuardar_Click" TabIndex="10" />
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" TabIndex="11" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
         </center>  
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
