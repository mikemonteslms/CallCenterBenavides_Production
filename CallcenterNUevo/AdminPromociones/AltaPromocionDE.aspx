<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaPromocionDE.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.AltaPromocionDE" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />
    <%--<script src="jsAdminProm/jsAdminPromocion.js"></script>--%>

   <script type="text/javascript">
       function isokmaxlength(e, val, maxlengt) {
           var charCode = (typeof e.which == "number") ? e.which : e.keyCode

           if (!(charCode == 44 || charCode == 46 || charCode == 0 || charCode == 8 || (val.value.length < maxlengt))) {
               return false;
           }
       }
   </script>

    <br /><br />
        <asp:Label runat="server" ID="lblTitulo" Text="Alta de Promociones ($ % de Dinero Electrónico)"  Font-Size="16px" ForeColor="DarkBlue"/>
        <asp:UpdatePanel ID="upAltaPromocion" runat="server">
        <ContentTemplate>
        <br />
        <asp:Table ID="tblDtealle" runat="server" HorizontalAlign="Center" CellSpacing="8" CellPadding="5"  Width="950px" Height="100%">
                <asp:TableRow>
                    <asp:TableCell  ColumnSpan="3" HorizontalAlign="Right">
                        <asp:Label ID="lblNomProdMM" runat="server" Text="Descripción del producto: " ForeColor="DarkBlue" Width="150px" Visible="false"></asp:Label><asp:TextBox ID="txtNomProdMM" runat="server" Text="" Width="220px" Visible="false"></asp:TextBox>
                    </asp:TableCell >
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label runat="server" text="Tipo promoción:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                            <telerik:RadComboBox ID="rcbTipoPromocion" AutoPostBack="true" RenderMode="Lightweight"  AllowCustomText="true" Filter="Contains" MarkFirstMatch="true"  runat="server"   OnSelectedIndexChanged="rcbTipoPromocion_SelectedIndexChanged"  Width="260px"  TabIndex="0" Enabled="true" >
                            </telerik:RadComboBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Left" ColumnSpan="2" Height="38px">
                        <asp:GridView  ID="grvProd"  runat="server" CssClass="gridview"  OnRowDeleting="grvProd_RowDeleting"  OnRowDataBound="grvProd_RowDataBound"  CellSpacing ="1" AutoGenerateColumns ="false"   CellPadding="3" GridLines="Horizontal" HorizontalAlign="left"  Width ="450px"  Height="100%" Caption="Productos"  >
                                <HeaderStyle ForeColor="Black"   />
                                    <Columns>
                                        <asp:TemplateField  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                            <HeaderTemplate>
                                                Código acumula
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtcod" runat="server" Text='<%# Eval("CodigoInterno")%>' AutoPostBack="true" MaxLength="8" OnTextChanged="txtcod_TextChanged"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="ftbeCodInterno" runat="server" FilterType="Numbers" TargetControlID="txtcod">
                                                </cc1:FilteredTextBoxExtender>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White">
                                            <HeaderTemplate>
                                                Nombre producto
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtNomProd" runat="server" Text='<%# Eval("NomProducto")%>' Enabled="false" Width="250px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:commandfield ShowDeleteButton="true" DeleteText="Eliminar"  DeleteImageUrl="../Imagenes_Benavides/delete-icon.png" HeaderStyle-BackColor="DarkBlue" HeaderStyle-ForeColor="White" ItemStyle-HorizontalAlign="Center" headertext="Opciones" Visible="false"/>
                                    </Columns>
                                </asp:GridView>
                        </asp:TableCell>
                    <asp:TableCell VerticalAlign="Bottom">
                        <asp:Button ID="btnAgregar" runat="server" Text="Nuevo elemento" OnClick="btnAgregar_Click" Width="150px" Visible="false" />
                    </asp:TableCell>
                </asp:TableRow>
                    
            <asp:TableRow>
                             <asp:TableCell Height="38px">
                                <asp:Label runat="server" text="Cantidad:"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="38px">
                                 <asp:TextBox ID="txtCantidad" runat="server" Height="25px"  TabIndex="3"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="ftbeCantidad" runat="server" FilterType="Numbers, Custom"  ValidChars="." 
                                                             TargetControlID="txtCantidad">
                                </cc1:FilteredTextBoxExtender>
                            </asp:TableCell>
                        </asp:TableRow>
                <asp:TableRow>
                        <asp:TableCell Height="38px">
                        <asp:Label runat="server" text="Fecha solicitud:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Height="38px">
                        <telerik:RadDatePicker ID="rdpFSolicitud" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFSolicitud_SelectedDateChanged" Width="140px" Enabled="true" ></telerik:RadDatePicker>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                        <asp:TableCell Height="38px">
                        <asp:Label runat="server" text="Fecha inicio:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Height="38px">
                        <telerik:RadDatePicker ID="rdpFIni" runat="server" AutoPostBack="true" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFIni_SelectedDateChanged" Width="140px" Enabled="true" ></telerik:RadDatePicker>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                        <asp:TableCell Height="38px">
                        <asp:Label runat="server" text="Fecha fin:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Height="38px">
                        <telerik:RadDatePicker ID="rdpFFin" AutoPostBack="true" runat="server" Culture="es-MX" RenderMode="Lightweight"  OnSelectedDateChanged="rdpFFin_SelectedDateChanged" Width="140px" Enabled="true" ></telerik:RadDatePicker>
                    </asp:TableCell>
                </asp:TableRow>
                <%--<asp:TableRow>
                        <asp:TableCell>
                        <asp:Label runat="server" text="Mensaje POS:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                            <asp:Label ID="lblMensajePOS" runat="server" Font-Size ="12px" ForeColor="DarkBlue" Font-Bold="true" ></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>--%>
                <asp:TableRow>
                            <asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
                                <asp:CheckBox ID="chkVerWS" runat="server" Checked="true" Text="Visible desde WS:" TextAlign="Left" />
                            </asp:TableCell>
                        </asp:TableRow>
                <asp:TableRow>
                        <asp:TableCell Height="38px">
                        <asp:Label runat="server" text="Comentario general:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell Height="38px">
                            <asp:TextBox ID="txtComentario" runat="server" MaxLength="150"  Width="400px" Height="70px"  onkeypress="return isokmaxlength(event,this,150);" TextMode="MultiLine" TabIndex="9" Enabled="true" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <br />
                   <asp:Table ID="tblbotones" runat="server">
                       <asp:TableRow>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="btnGuardar"  Text="Guardar" Width="100px" OnClick="btnGuardar_Click" CssClass="input" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="btnCancelar"  Text="Cancelar" Width="100px" OnClick="btnCancelar_Click" CssClass="input" />
                            </asp:TableCell>
                       </asp:TableRow>
                   </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
            </asp:Table>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
