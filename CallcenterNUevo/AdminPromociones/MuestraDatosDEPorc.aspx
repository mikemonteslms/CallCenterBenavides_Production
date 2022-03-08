<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MuestraDatosDEPorc.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.MuestraDatosDEPorc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />
    <script src="jsAdminProm/jsAdminPromocion.js"></script>

    <script type="text/javascript">
        function isokmaxlength(e, val, maxlengt) {
            var charCode = (typeof e.which == "number") ? e.which : e.keyCode

            if (!(charCode == 44 || charCode == 46 || charCode == 0 || charCode == 8 || (val.value.length < maxlengt))) {
                return false;
            }
        }
    </script>

    <asp:Label runat="server" ID="lblTitulo" Text="Información de la promoción ($, %)"  Font-Size="16px" ForeColor="DarkBlue"/>
    <asp:UpdatePanel ID="upDatos" runat="server">
        <ContentTemplate>
             <br />
             <asp:Table ID="tblDtealle" runat="server" HorizontalAlign="Center" CellSpacing="12" CellPadding="8"  Width="650px" Height="100%">
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
                                <asp:Label ID="lblPase" runat="server" ForeColor="DarkBlue" Font-Size="14px" Font-Bold="true"  Text="Fecha pase a producción: " Visible="false" ></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblFechaPase" runat="server" ForeColor="Red" Font-Size="14px" Font-Bold="true"  Text="" Visible="false"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
                                <asp:Label ID="Label1" runat="server" ForeColor="DarkBlue" Font-Size="14px" Font-Bold="true"  Text="Estatus: " ></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblEstatus" runat="server" ForeColor="Red" Font-Size="14px" Font-Bold="true"  Text="" ></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                             <asp:TableCell>
                                <asp:Label runat="server" text="Tipo promoción:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                 <telerik:RadComboBox ID="rcbTipoPromocion"  RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  runat="server"   OnSelectedIndexChanged="rcbTipoPromocion_SelectedIndexChanged"  Width="100px"  TabIndex="0" Enabled="false" >
                                 </telerik:RadComboBox>
                            </asp:TableCell>
                        </asp:TableRow>
                         
                        <asp:TableRow>
                             <asp:TableCell>
                                <asp:Label runat="server" text="Código:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtCodigo" runat="server" Height="25px" MaxLength="8" Enabled="false" TabIndex="1"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="ftbeCodigo" runat="server" FilterType="Numbers"
                                                             TargetControlID="txtCodigo">
                                </cc1:FilteredTextBoxExtender>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label runat="server" text="Nombre de promoción:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtNomProducto" runat="server" Height="55px" Width="320px" Enabled="false" TabIndex="2"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Cantidad:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                 <asp:TextBox ID="txtCantidad" runat="server" Height="25px" Enabled="false" TabIndex="3"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="ftbeCantidad" runat="server" FilterType="Numbers, Custom"  ValidChars="." 
                                                             TargetControlID="txtCantidad">
                                </cc1:FilteredTextBoxExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                    <asp:TableRow>
                            <asp:TableCell Height="38px">
                            <asp:Label runat="server" text="Fecha inicio:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                                <telerik:RadDatePicker ID="rdpFIni" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFIni_SelectedDateChanged" Width="140px" Enabled="false" TabIndex="4"></telerik:RadDatePicker>
                        </asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow>
                                <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Fecha fin:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                    <telerik:RadDatePicker ID="rdpFFin" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFFin_SelectedDateChanged" Width="140px" Enabled="false" TabIndex="5"></telerik:RadDatePicker>
                            </asp:TableCell>
                     </asp:TableRow>
                     <asp:TableRow >
                             <asp:TableCell ColumnSpan="2">
                                  <asp:Label ID="lblMensajeCancelacion" runat="server" ForeColor="DarkRed" Font-Size ="12px" Font-Bold ="true" Text=""/>
                             </asp:TableCell>
                         </asp:TableRow>
                     <asp:TableRow>
                            <asp:TableCell ColumnSpan="3" HorizontalAlign="Left">
                                <asp:Table ID="tblComentarios" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <div id="divgrid" runat="server" style="overflow:auto;height:80px;width:600px;" >
                                                <asp:GridView  ID="grvComentarios"  runat="server" CssClass="gridview"    CellSpacing ="1" AutoGenerateColumns ="false"   CellPadding="3" GridLines="Horizontal" HorizontalAlign="left"  Width ="580px"   >
                                                <Columns>
                                                    <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtid" runat="server" Text='<%# Eval("id")%>'  Visible="false" ></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtidmec" runat="server" Text='<%# Eval("id_mecanica")%>'  Visible="false" ></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                                        <HeaderTemplate>
                                                           Comentarios
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtcoment" runat="server" Text='<%# Eval("comentarios")%>' TextMode="MultiLine" Height="22px" Width ="580px" Enabled="false" ></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                    </asp:GridView>
                                            </div>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                      <asp:TableRow>
                            <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
                                <br /><br />
                                <asp:CheckBox ID="chkVerWS" runat="server" Checked="true" Text="Visible desde WS:" TextAlign="Left" Enabled="false" />
                            </asp:TableCell>
                        </asp:TableRow>
                    <asp:TableRow>
                            <asp:TableCell Height="38px">
                            <asp:Label runat="server" text="Comentarios:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                                <asp:TextBox ID="txtComentarios" runat="server" MaxLength="150"  Width="200px" Height="70px"  onkeypress="return isokmaxlength(event,this,150);" TextMode="MultiLine" TabIndex="6" Enabled="false" ></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                  <asp:TableRow>
                     <asp:TableCell>
                         <br />
                            <asp:Table ID="tblbotones" runat="server" Width="320px">
                                <asp:TableRow>
                                     <asp:TableCell>
                                         <asp:Button runat="server" ID="btnModificar"  Text="Modificar" Width="100px" OnClick="btnModificar_Click" CssClass="input" TabIndex="15"/>
                                     </asp:TableCell>
                                      <asp:TableCell>
                                          <asp:Button runat="server" ID="btnAutDesAut"  Text="Autorizar" Width="100px" OnClick="btnAutDesAut_Click" CssClass="input" TabIndex="1" />
                                     </asp:TableCell>
                                     <asp:TableCell>
                                          <asp:Button runat="server" ID="btnCanela"  Text="Cancelar" Width="100px" OnClick="btnCanela_Click" CssClass="input" TabIndex="1" />
                                     </asp:TableCell>
                                 </asp:TableRow>
                            </asp:Table>
                     </asp:TableCell>
                 </asp:TableRow>
                    </asp:Table>

            <div id="popReg" style="display: none; background-color: rgba(0, 0, 0, 0.5); z-index: 20000; left: 0%; position: absolute; top: 0px; width:100%; height: 100%; text-align: center;">
					<div  style="background-color: #333333; max-width: 400px; padding: 15px; width: 100%; display: inline-block; vertical-align: middle; height: 160px; margin-top:18%; max-height: 445px;">
					    <div class="modal-content"  style="background-color:#E2E1E1; height:135px; background-image:url(background-repeat: repeat-x"../Images/background2.jpg");>
						    <div class="modal-header">
                                <%--<button id="btnCloseReg" type="button" class="close" data-dismiss="modal" runat="server">&times;</button>--%>
                                  <asp:Table ID="tblAutDesAut" runat="server" CellSpacing="12" CellPadding="8" HorizontalAlign="Center" Width="350px">
                                    <asp:TableRow >
                                        <asp:TableCell HorizontalAlign="Center">
                                            <asp:Label runat="server" text="Fecha de pase a producción:"></asp:Label>
                                        </asp:TableCell>
                                        </asp:TableRow >
                                      <asp:TableRow >
                                        <asp:TableCell HorizontalAlign="Center">
                                            <telerik:RadDatePicker ID="rdpFechaPaseProd" ZIndex="99999" runat="server"  Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFechaPaseProd_SelectedDateChanged" Width="120px" Enabled="false" TabIndex="0"></telerik:RadDatePicker>
                                            
                                        </asp:TableCell>
                                     </asp:TableRow>
                                     <asp:TableRow >
                                        <asp:TableCell>
                                            <br />
                                            <asp:Button runat="server" ID="btnAutorizar"  Text="Autorizar" Width="100px" OnClick="btnAutorizar_Click" CssClass="input" TabIndex="1" />
                                        </asp:TableCell>
                                         <asp:TableCell>
                                             <br />
                                            <asp:Button runat="server" ID="btnCancelar"  Text="Cancelar" Width="100px" OnClick="btnCancelar_Click1" CssClass="input" TabIndex="1" />
                                        </asp:TableCell>
                                     </asp:TableRow>
                                </asp:Table>
                            </div>
	                    </div>
	                </div>
                </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>