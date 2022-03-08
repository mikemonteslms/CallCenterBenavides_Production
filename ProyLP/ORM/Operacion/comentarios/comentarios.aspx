<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="comentarios.aspx.cs" Inherits="ORMOperacion.comentarios" %>

<%@ MasterType VirtualPath="~/contenido.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>
    <div id="rounded-box3">
        <table border="0" width="100%">
            <tr>
                <td align="center">
                    <h4>Comentarios</h4>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vsComentario" ShowMessageBox="false" ShowSummary="false" />
                    <table>
                        <tr>
                            <td class="texto11 negrita" valign="middle" align="right">Programa</td>
                            <td valign="middle" align="left">
                                <asp:DropDownList ID="ddlPrograma" runat="server" DataValueField="clave" DataTextField="Descripcion" AutoPostBack="true" CssClass="texto11" OnSelectedIndexChanged="ddlPrograma_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvPrograma" runat="server" ErrorMessage="Programa requerido"
                                    ControlToValidate="ddlPrograma" CssClass="naranja" InitialValue="0" ValidationGroup="vsComentario">*</asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="vcePrograma" runat="server" TargetControlID="rfvPrograma">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="texto11 negrita" valign="middle" align="right">Status</td>
                            <td valign="middle" align="left">
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="texto11" DataValueField="id" DataTextField="Descripcion" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged"></asp:DropDownList></td>
                        </tr>                        
                    </table>
                </td>
            </tr>
            <tr>
                <td>                    
                    <telerik:RadGrid ID="gvComentarios" runat="server" AutoGenerateColumns="false" 
                        AllowPaging="true" PageSize="10" 
                        OnRowDataBound="gvComentarios_RowDataBound" 
                        OnItemDataBound="gvComentarios_ItemDataBound"                         
                        OnItemCommand="gvComentarios_ItemCommand"
                        OnNeedDataSource="gvComentarios_NeedDataSource"
                        Visible="false">
                        <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="ID" ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblID1" runat="server" Text="ID" CssClass="texto11 negrita"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Nombre" ItemStyle-Width="300">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("nombre_completo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblNombre1" runat="server" Text="Nombre" CssClass="texto11 negrita"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:HiddenField ID="hidParticipante_id" runat="server" />
                                                <asp:Label ID="lblNombre2" runat="server" CssClass="texto11"></asp:Label>                                                
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Mensaje" ItemStyle-Width="600">
                                <ItemTemplate>
                                    <asp:Label ID="lblMensaje" runat="server" Text='<%# Bind("mensaje") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMensaje" runat="server" Text='<%# Bind("mensaje") %>'
                                        MaxLength="600" Width="600" CssClass="texto11"></asp:TextBox>                                    
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblMensaje" runat="server" Text="Mensaje" CssClass="texto11 negrita"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtMensajeNuevo" runat="server" MaxLength="600" Width="600" CssClass="texto11"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvMensajeNuevo" runat="server" ErrorMessage="Mensaje requerido"
                                                    ControlToValidate="txtMensajeNuevo" CssClass="naranja" ValidationGroup="agregar">&nbsp;</asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="vceMensajeNuevo" runat="server" CssClass="cuadro_texto_vceMensajeNuevo color_negro" TargetControlID="rfvMensajeNuevo">
                                                </cc1:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Fecha" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaAlta" runat="server" Text='<%# Bind("fecha_alta") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblFechaAlta1" runat="server" Text="Fecha" CssClass="texto11 negrita"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblFechaAlta2" runat="server" CssClass="texto11" Text='<%# DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Status" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblStatus" runat="server" Text="Status" CssClass="texto11 negrita"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr valign="middle">
                                            <td>
                                                <asp:Label ID="lblStatus2" runat="server" Text="Activo" CssClass="texto11"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="lnkAgregar" runat="server" 
                                        CommandName="Agregar" CssClass="texto11 negrita color_azul" CausesValidation="true" 
                                        ValidationGroup="agregar">Agregar</asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkActualiza" runat="server" CommandArgument='<%# Eval("id") %>'
                                        CommandName="Actualiza Status" CssClass="texto11 negrita color_azul" OnCommand="lnkActualiza_Command">Activar / desactivar</asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>                            
                        </Columns>       
                            </MasterTableView>                 
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
    </center>
</asp:Content>
