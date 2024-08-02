<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MuestraPromoDesc.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.MuestraPromoDesc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />

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
        if (key > 63) {
            var chr = GetChar(ev);
            if (/[\d|\.|,]/.test(chr)) {
                return true;
            } else {
                return false;
            }
        } else {
            return true;
        }
    }

    function ValidarTexto(ele) {
        var valor = ele.value;
        if (/^\d[,|\.]\d*/.test(valor) == false) {
            alert("El valor no es válido.");
        } else {
            if ((parseFloat(valor) < 0) || (parseFloat(valor) > 5)) {
                alert("Debe estar entre cero y cinco.");
            }
        }
    }
</script>

    <%--<asp:Label runat="server" ID="lblTitulo" Text="Modificación de Promociones de descuentos"  Font-Size="16px" ForeColor="DarkBlue"/>--%>
        <asp:UpdatePanel ID="upModificaPromocionDescuentos" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pnlModificaPromDescuento" ScrollBars="Auto" Width="100%" Height="100%"> 
                <asp:MultiView ID="mvProductrosSuc" runat="server" ActiveViewIndex="0">
                        <asp:View ID="vConsultaPromocionesDescuento" runat="server">
                            <h4 style="color:darkblue">Consulta Promociones de Descuento.</h4> 
                            <br />
                            <center>
                            <asp:Table ID="tblBuquedas" runat="server" >
                                <asp:TableRow >
                                    <asp:TableCell>
                                        <asp:Label runat="server" Text="Promoción / Código Interno:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtNomPromACBase" runat="server" Width ="150px"></asp:TextBox>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow >
                                    <asp:TableCell ColumnSpan="2">
                                        <br />
                                        <telerik:RadGrid ID="grvDatos"  runat="server"  AutoGenerateColumns="False" AllowPaging="false"  CellSpacing="2" GridLines="Both" OnItemCommand="grvDatos_ItemCommand"   Culture="es-MX"  Width="350px"  >
                                        <GroupingSettings CollapseAllTooltip="Collapse all groups" />
                                        <MasterTableView NoMasterRecordsText="No se encontró información" AllowMultiColumnSorting="true">
                                           <RowIndicatorColumn Visible="False">
                                                    </RowIndicatorColumn>
                                            <ExpandCollapseColumn Created="True">
                                                <HeaderStyle Width="1000px" />
                                            </ExpandCollapseColumn>
                                                    <Columns>        
                                                        <telerik:GridTemplateColumn  HeaderText="Opciones" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="70px">
                                                            <ItemTemplate> 
                                                                <asp:Button ID="btnVer" ToolTip="Ver" runat="server"  Text="Ver" Width="50px" Font-Size="14px" CommandArgument='<%# Eval("IdPDescuento")%>' CommandName="VerDetalle" TabIndex="2"/>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn> 
                                                   <%--     <telerik:GridTemplateColumn   HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate> 
                                                                    <asp:Button ID="btnEliminar" ToolTip="Eliminar promoción ACBase" runat="server"  Text="Eliminar" Width="80px" Font-Size="14px" CommandArgument='<%# Eval("IdPABase")%>' CommandName="Eliminar" TabIndex="3"/>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn> --%>
                                                        <telerik:GridBoundColumn DataField="NombrePromocion" FilterControlAltText="Filter column1 column" HeaderText="Promoción" UniqueName="column1">
                                                        </telerik:GridBoundColumn>  
                                                    </Columns>
                                                    <PagerStyle PageSizeControlType="None"/>
                                                    </MasterTableView>
                                                    <SortingSettings SortedBackColor="#FFF6D6" EnableSkinSortStyles="false"></SortingSettings>
                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                    <PagerStyle FirstPageToolTip="Primera Página" GoToPageButtonToolTip="Ir a página" LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PagerTextFormat="Cambiar página: {4} &amp;nbsp;página &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;, registro &lt;strong&gt;{2}&lt;/strong&gt; a &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeControlType="None" PrevPagesToolTip="Páginas anteriores" PrevPageToolTip="Página anterior" />
                                    </telerik:RadGrid>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                         </center>   
                            

                        </asp:View>
                        <asp:View ID="vEditaPromocionDescuento" runat="server">
                            <h4 style="color:darkblue">Modificación de Promociones de descuentos.</h4> 
                            <br />
                            <asp:Table ID="tblPromocionesSuc" runat="server" HorizontalAlign="Center"   Width="700px" Height="100%">
                            <asp:TableRow>
                            <asp:TableCell Height="38px" Width="250px">
                            <asp:Label ID="Label1" runat="server" Text="Nombre de Promoción:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                            <asp:TextBox ID="txtNombrePromocion" runat="server" Width ="350px"></asp:TextBox>
                            <br />
                            </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                            <asp:TableCell Height="38px">
                            <asp:Label ID="Label2" runat="server" Text="Productos:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell >
                                <div id="divProd" style="max-height:140px;overflow-y:scroll;overflow:scroll;height:140px;width:268px;" >
                                    <asp:GridView  ID="grvProductos"   ShowHeader ="true" runat="server" CssClass="gridview" AllowPaging="false"   CellSpacing ="1" AutoGenerateColumns ="false"  CellPadding="3" GridLines="Horizontal" HorizontalAlign="left" UseAccessibleHeader ="false" Width ="250px"  Height="100px" Enabled="true" >
                                    <HeaderStyle ForeColor="Black" />
                                        <Columns>
                                            <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                <HeaderTemplate>
                                                    Código Interno
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="IdPABase" runat="server" Value='<%# Eval("IdPABase")%>' />
                                                    <asp:TextBox ID="txtNomProd" runat="server" Text='<%# Eval("CodigoInterno")%>' AutoPostBack="true" OnTextChanged="txtNomProd_TextChanged" TabIndex="3" Enabled="true"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                <HeaderTemplate>
                                                     <asp:Label ID="Label13" runat="server" Text="Eliminar" Width ="65px"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkProducto" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem, "IdStatus").Equals(1)) ? (bool) true : (bool) false %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div> 
                                <br />
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <asp:Button ID="btnAgregarProd" runat="server" Text="Agregar" OnClick="btnAgregarProd_Click" Width="100px" Visible="true"  />
                            </asp:TableCell>
                            </asp:TableRow>
                            
                            
                           
                            <asp:TableRow>
                            <asp:TableCell Height="38px">
                            <asp:Label ID="Label3" runat="server" Text="Sucursales:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell >
                                <div id="divSuc" style="max-height:130px;overflow-y:scroll;overflow:scroll;height:130px;width:435px;" >
                                    <asp:GridView  ID="grvSucursales"  ShowHeader ="true" runat="server" CssClass="gridview" AllowPaging="false"    CellSpacing ="1" AutoGenerateColumns ="false"  CellPadding="3" GridLines="Horizontal" HorizontalAlign="left" UseAccessibleHeader ="false" Width ="205px"  Height="100px" Enabled="true">
                                    <HeaderStyle ForeColor="Black" />
                                        <Columns>
                                            <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                <HeaderTemplate>
                                                    Sucursal
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="IdPABaseSuc" runat="server" Value='<%# Eval("IdPABase")%>' />
                                                    <asp:TextBox ID="txtSucursal" runat="server" OnTextChanged="txtSucursal_TextChanged"  AutoPostBack="true" Text='<%# Eval("NomSucursal")%>' TabIndex="3" Enabled="true"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                <HeaderTemplate>
                                                    SucursalCia
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCiaSuc" runat="server" Text='<%# Eval("Sucursal")%>' TabIndex="3" Enabled="false"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"  ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label13" runat="server" Text="Eliminar" Width ="65px"></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSucursal" runat="server"  Checked='<%# (DataBinder.Eval(Container.DataItem, "IdStatus").Equals(1)) ? (bool) true : (bool) false %>' Enabled="true"  />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </asp:TableCell>
                            <asp:TableCell VerticalAlign="Top">
                                <asp:Button ID="btnAgregarSuc" runat="server" Text="Agregar" OnClick="btnAgregarSuc_Click" Width="100px" Visible="true"  />
                            </asp:TableCell>
                            <asp:TableCell Width="150px" >
                                <asp:CheckBox ID="chkNivNac" runat="server" Text="Nivel Nacional" AutoPostBack="true"  OnCheckedChanged="chkNivNac_CheckedChanged" />
                            </asp:TableCell>
                            </asp:TableRow>

                            <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label6" runat="server" Text="Cantidad de descuento:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                            <asp:TextBox ID="txtCantidadAC" runat="server"  Width ="140px" onKeypress="return ValidarTecla(event);"  MaxLength="6"  ></asp:TextBox>
                            <asp:Label ID="Label9" runat="server" Text=" %    (valor esperado de 1 - 100)"></asp:Label>
                             <%--<cc1:FilteredTextBoxExtender ID="ftbeCantidadAC" runat="server" FilterType="Numbers"
                                TargetControlID="txtCantidadAC">
                                </cc1:FilteredTextBoxExtender>--%>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label4" runat="server" Text="Fecha Inicio:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                            <telerik:RadDatePicker ID="rdpFechaIni" runat="server"  Culture="es-MX" RenderMode="Lightweight"  Width="140px" ></telerik:RadDatePicker>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label5" runat="server" Text="Fecha Fin:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                            <telerik:RadDatePicker ID="rdpFechaFin" runat="server"  Culture="es-MX" RenderMode="Lightweight"  Width="140px" ></telerik:RadDatePicker>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                            <asp:TableCell Height="38px">
                            <asp:Label runat="server" text="Límite período:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                                <telerik:RadComboBox ID="rcbLimPeriodo" AutoPostBack="true" RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"    runat="server"   OnSelectedIndexChanged="rcbLimPeriodo_SelectedIndexChanged"  Width="145px"  TabIndex="0"  Enabled="true" >
                                </telerik:RadComboBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow >
                        <asp:TableCell >
                            <asp:Label runat="server" text="Límite:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell >
                            <asp:TextBox ID="txtLimite" runat="server" Width="140px" AutoPostBack ="true" OnTextChanged="txtLimite_TextChanged"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="ftbeLimite" runat="server" FilterType="Numbers" TargetControlID="txtLimite"></cc1:FilteredTextBoxExtender>
                        </asp:TableCell>
                    </asp:TableRow>
                  
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan ="2">
                            <asp:Table runat="server" Width="650px">
                                <asp:TableRow >
                                    <asp:TableCell Height="38px" Width="100px">
                                        <asp:Label ID="lbñDias" runat="server" Text="Días:"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                         <asp:CheckBox ID="chkLunes" runat="server" Text ="Lunes" TextAlign="Left"/>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                        <asp:CheckBox ID="chkMartes" runat="server" Text ="Martes" TextAlign="Left"/>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                        <asp:CheckBox ID="chkMiercoles" runat="server" Text ="Miércoles" TextAlign="Left"/>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                        <asp:CheckBox ID="chkJueves" runat="server" Text ="Jueves" TextAlign="Left"/>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                        <asp:CheckBox ID="chkViernes" runat="server" Text ="Viernes" TextAlign="Left"/>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                        <asp:CheckBox ID="chkSabado" runat="server" Text ="Sábado" TextAlign="Left"/>
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                        <asp:CheckBox ID="chkDomingo" runat="server" Text ="Domingo" TextAlign="Left"/>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label7" runat="server" Text="Servicio Domicilio:"></asp:Label>
                            <br/><br/>
                        </asp:TableCell>
                         <asp:TableCell Height="38px" HorizontalAlign="Left">
                             <asp:CheckBox ID="chkServicioDom" runat="server" Text =""/>
                             <br/><br/>
                        </asp:TableCell>
                    </asp:TableRow>
                     
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label10" runat="server" Text="Adicional Inapam:"></asp:Label>
                            <br/><br/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:CheckBox ID="chkINAPAM" runat="server"  TextAlign="Left"  />
                            <br/><br/>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow >
                        <asp:TableCell>
                            <asp:Label ID="Label11" runat="server" Text="Aplica acumulación base:"></asp:Label>
                            <br/><br/>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:CheckBox ID="chkACBase" runat="server"  TextAlign="Left"  />
                        <br/><br/>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="Label12" runat="server" Text="Aplica con acumulación de piezas:"></asp:Label>
                            <br/><br/>
                        </asp:TableCell>
                        <asp:TableCell ColumnSpan="2">
                            <asp:CheckBox ID="chkACPiezas" runat="server"  TextAlign="Left"  />
                            <br/><br/>
                        </asp:TableCell>
                       
                    </asp:TableRow>
                    <asp:TableRow >
                        <asp:TableCell VerticalAlign="Top" >
                            <asp:Label ID="Label8" runat="server" Text="Bin:" hidden="true"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell >
                            <asp:CheckBoxList ID="chkBIN" runat="server" hidden="true"/>
                        </asp:TableCell>
                    </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell ColumnSpan="2" HorizontalAlign="Left" >
                                    <br />
                                    <asp:Table ID="tblBotones" runat="server" Width ="200px">
                                        <asp:TableRow >
                                            <asp:TableCell >
                                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                                            </asp:TableCell>
                                            <asp:TableCell >
                                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"/>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:TableCell>
                            </asp:TableRow>
                            </asp:Table>

                        </asp:View>
                </asp:MultiView>
            </asp:Panel>
         </ContentTemplate>
            </asp:UpdatePanel> 
</asp:Content>
