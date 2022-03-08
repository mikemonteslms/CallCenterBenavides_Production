<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="ORMOperacion.usuarios" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <center>
        <div id="rounded-box3">
        <table border="0">
            <tr align="center">
                <td class="texto18 negrita">
                    <table border="0" width="900px" height="400px">
                        <tr valign="top">
                            <td align="center">
                                <div style="width: 880px;">
                                    <asp:MultiView ID="mvUsuarios" runat="server" ActiveViewIndex="0">
                                        <asp:View ID="vBusqueda" runat="server">
                                            <h3>Administraci&oacute;n de usuarios</h3>
                                            <table>
                                                <tr>
                                                    <td align="center">
                                                        <p class="texto16 negrita color_negro">Buscar usuario</p>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr align="left">
                                                    <td>
                                                        <span>
                                                            <asp:TextBox ID="txtBusqueda" runat="server" Width="300px"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnBusquedaUsuarios" runat="server" Text="Buscar" OnClick="btnBusquedaUsuarios_Click" />
                                                    </td>
                                                    <td style="width: 200px; display: table-cell; text-align: center;">
                                                        <asp:LinkButton ID="lnkNuevoUsuario" runat="server" class="texto13 negrita color_azul" OnCommand="lnkNuevo_Command"
                                                            CommandName="usuario">Agregar usuario</asp:LinkButton>
                                                    </td>
                                                    <%--<td style="width: 200px; display: table-cell; text-align: center;">
                                                            <asp:LinkButton ID="lnkNuevoParticipante" runat="server" OnCommand="lnkNuevo_Command"
                                                                CommandName="participante">Agregar participante</asp:LinkButton>
                                                        </td>--%>
                                                    <td style="width: 200px; display: table-cell; text-align: center;">
                                                       
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td colspan="5">
                                                        <telerik:RadGrid ID="gvUsuarios" runat="server" CellPadding="0" GridLines="None" CellSpacing="0"
                        EnableLinqExpressions="False" Culture="es-MX" allowup>
                        <ClientSettings AllowColumnsReorder="true">
                        </ClientSettings>
                        <MasterTableView CommandItemDisplay="None" InsertItemPageIndexAction="ShowItemOnCurrentPage" EditMode="EditForms" AutoGenerateColumns="false">
                            <Columns>
                            <telerik:GridBoundColumn DataField="UserName" HeaderStyle-CssClass="texto16 negrita color_negrita rgHeader" HeaderText="Nombre de usuario">
                                                                    <ItemStyle Width="300" />
                                                                </telerik:GridBoundColumn>
                                                                <telerik:GridTemplateColumn ItemStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkVer" runat="server" CommandArgument='<%# Eval("UserName") %>'
                                                                            CommandName="ver" CssClass="texto13 negrita color_azul" OnCommand="User_Command">Ver datos</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn ItemStyle-Width="200px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkEditar" runat="server" CommandArgument='<%# Eval("UserName") %>'
                                                                            CommandName="editar" CssClass="texto13 negrita color_azul" OnCommand="User_Command">Editar usuario</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn ItemStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("UserName") %>'
                                                                            CommandName="eliminar" CssClass="texto13 negrita color_azul" OnCommand="User_Command">Eliminar</asp:LinkButton>
                                                                        <cc1:ConfirmButtonExtender ID="cbe" runat="server" TargetControlID="lnkEliminar"
                                                                            ConfirmText='<%#"¿Seguro que quiere eliminar al usuario " + Eval("UserName") + "?" %>' />
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn ItemStyle-Width="150px" Visible="true">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkPassword" runat="server" CommandArgument='<%# Eval("UserName") %>'
                                                                            CommandName="password" CssClass="texto13 negrita color_azul" OnCommand="User_Command">Establecer Password</asp:LinkButton>
                                                                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkPassword"
                                                                            ConfirmText='<%#"¿Seguro que quiere establecer el password a " + Eval("UserName") + "?" %>' />
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                                                        <!--Tabla con estilo anterior-->
                                                        <%--<asp:GridView ID="gvUsuarios1" runat="server" AutoGenerateColumns="false">
                                                            <RowStyle Height="20px" />
                                                            <AlternatingRowStyle BackColor="#E2F1FC" />
                                                            <Columns>
                                                                <asp:BoundField DataField="UserName" HeaderStyle-CssClass="texto16 negrita color_negrita rgHeader" HeaderText="Nombre de usuario">
                                                                    <ItemStyle Width="300" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField ItemStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkVer" runat="server" CommandArgument='<%# Eval("UserName") %>'
                                                                            CommandName="ver" CssClass="texto13 negrita color_azul" OnCommand="User_Command">Ver datos</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="200px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkEditar" runat="server" CommandArgument='<%# Eval("UserName") %>'
                                                                            CommandName="editar" CssClass="texto13 negrita color_azul" OnCommand="User_Command">Editar usuario</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="150px">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("UserName") %>'
                                                                            CommandName="eliminar" CssClass="texto13 negrita color_azul" OnCommand="User_Command">Eliminar</asp:LinkButton>
                                                                        <cc1:ConfirmButtonExtender ID="cbe" runat="server" TargetControlID="lnkEliminar"
                                                                            ConfirmText='<%#"¿Seguro que quiere eliminar al usuario " + Eval("UserName") + "?" %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="150px" Visible="true">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkPassword" runat="server" CommandArgument='<%# Eval("UserName") %>'
                                                                            CommandName="password" CssClass="texto13 negrita color_azul" OnCommand="User_Command">Establecer Password</asp:LinkButton>
                                                                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkPassword"
                                                                            ConfirmText='<%#"¿Seguro que quiere establecer el password a " + Eval("UserName") + "?" %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>--%>
                                                        <!--Tabla con estilo anterior-->
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vVer" runat="server">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vsEditarUsuario"
                                                ShowMessageBox="true" ShowSummary="false" />
                                            <h3>Ver usuario</h3>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <p class="texto13 negrita color_negro">Id. de usuario</p>
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="txtvIDUsuario" CssClass="texto13 negrita color_negro" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <p class="texto13 negrita color_negro">Correo electr&oacute;nico</p>
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:TextBox ID="txtvCorreoElectronico" runat="server" Width="300px"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvvCorreoElectronico" runat="server" ErrorMessage="Email requerido"
                                                            ControlToValidate="txtvCorreoElectronico" CssClass="naranja" ValidationGroup="vsEditarUsuario">*</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server" TargetControlID="rfvvCorreoElectronico">
                                                        </cc1:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="revvCorreoElectronico" runat="server" ControlToValidate="txtvCorreoElectronico"
                                                            CssClass="naranja" ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z]{2,6}$"
                                                            ValidationGroup="vsEditarUsuario" ErrorMessage="Formato de e-mail incorrecto.">*</asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="server" TargetControlID="revvCorreoElectronico">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><p class="texto13 negrita color_negro">Fecha de alta &nbsp;</p></td>
                                                    <td>
                                                        <asp:Label ID="lblFechaAlta" runat="server" Text="" CssClass="texto13 color_negro"></asp:Label>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td><p class="texto13 negrita color_negro">Último Acceso&nbsp;</p></td>
                                                    <td> <asp:Label ID="lblUltimoAcceso" runat="server" Text="" CssClass="texto13 color_negro"></asp:Label></td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Button ID="btnResetear" runat="server" Text="Resetear" OnClick="btnResetear_Click"
                                                            ValidationGroup="vsEditarUsuario" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button ID="btnGenerico" runat="server" Text="Generico" OnClick="btnGenerico_Click"
                                                            ValidationGroup="vsEditarUsuario" />
                                                    </td>
                                                    <td align="right">
                                                        <asp:Button ID="btnvRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click"
                                                            CausesValidation="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vEditar" runat="server">
                                            <asp:ValidationSummary ID="vsEditarUsuario" runat="server" ValidationGroup="vsEditarUsuario"
                                                ShowMessageBox="true" ShowSummary="false" />
                                            <h3>Modificar usuario</h3>
                                            <table>
                                                <tr>
                                                    <td align="right">
                                                        <p class="texto13 negrita color_negro">Id. de usuario</p>
                                                    </td>
                                                    <td align="center">
                                                        <span class="texto13 negrita color_negro">
                                                            <asp:Label ID="txtIDUsuario" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <p class="texto13 negrita color_negro">Correo electr&oacute;nico</p>
                                                    </td>
                                                    <td align="center">
                                                        <span>
                                                            <asp:TextBox ID="txtCorreoElectronico" runat="server" Width="300px"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="reqEditarCorreo" runat="server" ErrorMessage="Email requerido"
                                                            ControlToValidate="txtCorreoElectronico" CssClass="naranja" ValidationGroup="vsEditarUsuario">*</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="valEditarCorreo" runat="server" TargetControlID="reqEditarCorreo">
                                                        </cc1:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="regexEditarCorreo" runat="server" ControlToValidate="txtCorreoElectronico"
                                                            CssClass="naranja" ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z]{2,6}$"
                                                            ValidationGroup="vsEditarUsuario" ErrorMessage="Formato de e-mail incorrecto.">*</asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" TargetControlID="regexEditarCorreo">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <p class="texto13 negrita color_negro">Status</p>
                                                    </td>
                                                    <td align="center">
                                                        <table>
                                                            <tr align="left">
                                                                <td>
                                                                    <asp:RadioButtonList ID="rbStatus" runat="server" CssClass="texto13 negrita color_negro">
                                                                        <asp:ListItem Value="A">Activo</asp:ListItem>
                                                                        <asp:ListItem Value="I">Inactivo</asp:ListItem>
                                                                        <asp:ListItem Value="B">Baja</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <p class="texto13 negrita color_negro">Comentarios</p>
                                                    </td>
                                                    <td align="center">
                                                        <span>
                                                            <asp:TextBox ID="txtComentarios" runat="server" Width="339px" Height="54px" TextMode="MultiLine"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <p class="texto13 negrita color_negro">Roles</p>
                                                    </td>
                                                    <td align="center">
                                                        <table>
                                                            <tr align="left">
                                                                <td>
                                                                    <span>
                                                                        <asp:CheckBoxList ID="chkRolesListEditar" runat="server" CssClass="texto13 negrita color_negro" OnSelectedIndexChanged="chkRolesListEditar_SelectedIndexChanged" AutoPostBack="true">
                                                                        </asp:CheckBoxList>
                                                                    </span>
                                                                </td>
                                                                <td>
                                                                    <table id="tbDistribuidorEditar" runat="server" visible="false" border="0" width="300px">
                                                                        <tr>
                                                                            <td>
                                                                                <table width="100%">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <telerik:RadComboBox ID="rcbProgramaEditar" Runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox ="true" width="200" ></telerik:RadComboBox> <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="btnAddDP_Click"></asp:Button>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>

                                                                                <telerik:RadListBox ID="rlbDistribuidorEditarOrigen" runat="server" Height="150px" Width="300px" AllowTransfer="true" TransferToID="rlbDistribuidorEditarDestino"></telerik:RadListBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                    <tr><td>
                                                                                <telerik:RadListBox runat="server" ID="rlbDistribuidorEditarDestino" Height="150px" Width="270px"></telerik:RadListBox>
                                                                                        </td>
                                                                                        </tr>
                                                                                    </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                            <table border="0" width="700px" height="50px">
                                                <tr>
                                                    <td align="center" width="350px">
                                                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click"
                                                            ValidationGroup="vsEditarUsuario" />
                                                    </td>
                                                    <td align="center" width="350px">
                                                        <asp:Button ID="btnActualizarRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click"
                                                            CausesValidation="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vNuevoUsuario" runat="server">
                                            <asp:ValidationSummary ID="valNuevoUsuario" runat="server" ValidationGroup="vsNuevoUsuario"
                                                ShowMessageBox="true" ShowSummary="false" />
                                            <h3>Alta de usuarios</h3>
                                            <table>
                                                <tr>
                                                    <td colspan="3" align="center">
                                                        <p class="texto13 negrita color_negro">La nueva contraseña requiere un m&iacute;nimo de 8 caracteres, incluyendo una letra, un n&uacute;mero y un caracter especial.</p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="283px" align="right">
                                                        <p class="texto13 negrita color_negro">Nombre de usuario</p>
                                                    </td>
                                                    <td width="283px">
                                                        <span>
                                                            <asp:TextBox ID="txtNuevoUsuario" runat="server" Width="300px"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td align="left" width="283px">
                                                        <asp:RequiredFieldValidator ID="reqNuevoUsuario" runat="server" ErrorMessage="Nombre de usuario requerido"
                                                            ControlToValidate="txtNuevoUsuario" ValidationGroup="vsNuevoUsuario">&nbsp;</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="reqNuevoUsuario">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <p class="texto13 negrita color_negro">Contraseña</p>
                                                    </td>
                                                    <td align="left">
                                                        <span>
                                                            <asp:TextBox ID="txtNuevoContrasena" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td align="left">
                                                        <cc1:PasswordStrength ID="PasswordStrength1" runat="server" TargetControlID="txtNuevoContrasena"
                                                            DisplayPosition="RightSide" PrefixText="La contraseña es " StrengthIndicatorType="Text"
                                                            MinimumNumericCharacters="0" MinimumSymbolCharacters="0" PreferredPasswordLength="5"
                                                            RequiresUpperAndLowerCaseCharacters="false" TextStrengthDescriptions="Muy débil; Débil; Regular; Buena; Excelente"
                                                            StrengthStyles="TextStrength MuyDebil; TextStrength Debil; TextStrength Regular;TextStrength Buena;TextStrength Excelente">
                                                        </cc1:PasswordStrength>
                                                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="txtNuevoContrasena"
                                                            ErrorMessage="La contraseña es requerida" ValidationGroup="vsNuevoUsuario">&nbsp;</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="NewPasswordValidator" runat="server" TargetControlID="NewPasswordRequired">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <p class="texto13 negrita color_negro">Confirmar contraseña</p>
                                                    </td>
                                                    <td align="left">
                                                        <span>
                                                            <asp:TextBox ID="txtNuevoConfirmarContrasena" runat="server" TextMode="Password"
                                                                Width="300px"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="txtNuevoConfirmarContrasena"
                                                            Display="Dynamic" ErrorMessage="Confirme la contraseña" ValidationGroup="vsNuevoUsuario">&nbsp;</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ConfirmNewPasswordValidator" runat="server" TargetControlID="ConfirmNewPasswordRequired">
                                                        </cc1:ValidatorCalloutExtender>
                                                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="txtNuevoContrasena"
                                                            ControlToValidate="txtNuevoConfirmarContrasena" Display="Dynamic" ValidationGroup="vsNuevoUsuario"
                                                            ErrorMessage="Las contraseñas no son iguales" CssClass="naranja">&nbsp;</asp:CompareValidator>
                                                        <cc1:ValidatorCalloutExtender ID="NewPasswordCompareValidator" runat="server" TargetControlID="NewPasswordCompare">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <p class="texto13 negrita color_negro">Correo electr&oacute;nico</p>
                                                    </td>
                                                    <td align="left">
                                                        <span>
                                                            <asp:TextBox ID="txtNuevoEmail" runat="server" Width="300px"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td align="left">
                                                        <asp:RequiredFieldValidator ID="reqEmail" runat="server" ErrorMessage="Email requerido"
                                                            ControlToValidate="txtNuevoEmail" ValidationGroup="vsNuevoUsuario">&nbsp;</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="reqEmail">
                                                        </cc1:ValidatorCalloutExtender>
                                                        <asp:RegularExpressionValidator ID="regexEmail" runat="server" ControlToValidate="txtNuevoEmail"
                                                            ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z]{2,6}$"
                                                            ValidationGroup="vsNuevoUsuario" ErrorMessage="Formato de e-mail incorrecto.">&nbsp;</asp:RegularExpressionValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" TargetControlID="regexEmail">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <p class="texto13 negrita color_negro">Status</p>
                                                    </td>
                                                    <td align="left">
                                                        <span>
                                                            <asp:CheckBox ID="chkNuevoActivo" runat="server" CssClass="texto13 negrita color_negro" Text="Activo" />
                                                        </span>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr style="visibility:hidden; display:none">
                                                    <td align="right">
                                                        <p class="texto13 negrita color_negro">Pregunta de seguridad</p>
                                                    </td>
                                                    <td align="left">
                                                        <span>
                                                            <asp:TextBox ID="txtNuevoPregunta" runat="server" Width="300px" Text="Pregunta1"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td align="left">
                                                        <%--<asp:RequiredFieldValidator ID="reqPregunta" runat="server" ErrorMessage="Pregunta requerida"
                                                            ControlToValidate="txtNuevoPregunta" ValidationGroup="vsNuevoUsuario">&nbsp;</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="reqPregunta">
                                                        </cc1:ValidatorCalloutExtender>--%>
                                                    </td>
                                                </tr>
                                                <tr style="visibility:hidden; display:none">
                                                    <td align="right">
                                                        <p class="texto13 negrita color_negro">Respuesta de seguridad</p>
                                                    </td>
                                                    <td align="left">
                                                        <span>
                                                            <asp:TextBox ID="txtNuevoRespuesta" runat="server" Width="300px" Text="Respuesta1"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td align="left">
                                                        <%--<asp:RequiredFieldValidator ID="reqRespuesta" runat="server" ErrorMessage="Respuesta requerida"
                                                            ControlToValidate="txtNuevoRespuesta" ValidationGroup="vsNuevoUsuario">&nbsp;</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="reqRespuesta">
                                                        </cc1:ValidatorCalloutExtender>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <p class="texto13 negrita color_negro">Roles</p>
                                                    </td>
                                                    <td align="center">
                                                        <table border="0" width="100%">
                                                            <tr align="left">
                                                                <td>
                                                                    <table width="460px">
                                                                        <tr align="left">
                                                                            <td>
                                                                                <span>
                                                                                    <asp:CheckBoxList ID="chkRolesListNuevo" runat="server" CssClass="texto13 negrita color_negro" OnSelectedIndexChanged="chkRolesListNuevo_SelectedIndexChanged" AutoPostBack="true">
                                                                                    </asp:CheckBoxList>
                                                                                </span>
                                                                            </td>
                                                                            <td>
                                                                                <table id="tbDistribuidorNuevo" runat="server" visible="false" border="0" width="300px">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <telerik:RadComboBox ID="rcbPrograma" Runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox ="true" width="200" ></telerik:RadComboBox> <asp:Button ID="btnAddDP" runat="server" Text="Buscar" OnClick="btnAddDP_Click"></asp:Button>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <telerik:RadListBox ID="rlbDistribuidorNuevoOrigen" runat="server" Height="150px" Width="300px" AllowTransfer="true" TransferToID="rlbDistribuidorNuevoDestino">
                                                                                                        </telerik:RadListBox>                                                                                                  

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                         <telerik:RadListBox runat="server" ID="rlbDistribuidorNuevoDestino" Height="150px" Width="270px"></telerik:RadListBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                </table>
                                                                                            
                                                                                            
                                                                                           
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>                                                                   
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                            <table border="0" width="500px" height="50px">
                                                <tr>
                                                    <td align="center" width="250px">
                                                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"
                                                            ValidationGroup="vsNuevoUsuario" />
                                                    </td>
                                                    <td align="center" width="250px">
                                                        <asp:Button ID="btnRegresarNuevo" runat="server" Text="Regresar" OnClick="btnRegresar_Click"
                                                            CausesValidation="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vNuevoParticipante" runat="server">
                                            <asp:ValidationSummary ID="valNuevoParticipante" runat="server" ValidationGroup="vsParticipante"
                                                ShowMessageBox="true" ShowSummary="false" />
                                            <h3>Alta de participantes</h3>
                                            <table>
                                                <tr>
                                                    <td>Clave
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:TextBox ID="txtParticipanteClave" runat="server" Width="300px"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="reqParticipanteClave" runat="server" ErrorMessage="Clave del participante requerida"
                                                            ControlToValidate="txtParticipanteClave" ValidationGroup="vsParticipante">*</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="reqParticipanteClave">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Nombre
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:TextBox ID="txtParticipanteNombre" runat="server" Width="300px"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="reqParticipanteNombre" runat="server" ErrorMessage="Nombre del participante requerido"
                                                            ControlToValidate="txtParticipanteNombre" ValidationGroup="vsParticipante">*</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="reqParticipanteNombre">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Apellido paterno
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:TextBox ID="txtParticipanteApellidoPaterno" runat="server" Width="300px"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>Apellido materno
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:TextBox ID="txtParticipanteApellidoMaterno" runat="server" Width="300px"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>Pa&iacute;s
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPais" runat="server" DataValueField="country_code2" DataTextField="Descripcion"
                                                            Width="155px" AutoPostBack="true" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="reqPais" runat="server" ErrorMessage="Pais requerido"
                                                            InitialValue="0" ControlToValidate="ddlPais" ValidationGroup="vsParticipante">*</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" TargetControlID="reqPais">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Puesto
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPuesto" runat="server" DataValueField="ID" DataTextField="Descripcion"
                                                            Width="322px" Enabled="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>Sexo
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="chkGenero" runat="server" DataValueField="ID" DataTextField="Descripcion"
                                                            RepeatDirection="Horizontal" Width="150px">
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="reqGenero" runat="server" ErrorMessage="Genero requerido"
                                                            ControlToValidate="chkGenero" ValidationGroup="vsParticipante">*</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="reqGenero">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Correo electr&oacute;nico
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:TextBox ID="txtParticipanteEmail" runat="server" Width="300px"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>Estado civil
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlEstadoCivil" runat="server" DataValueField="ID" DataTextField="Descripcion"
                                                            CssClass="cuadro_texto2" Width="155px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>Fecha de nacimiento
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:TextBox ID="txtFechaNacimiento" runat="server" Width="135px" CssClass="calendario"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <td>
                                                        <cc1:CalendarExtender ID="calFechaNacimientoCliente" runat="server" Format="dd/MM/yyyy"
                                                            TargetControlID="txtFechaNacimiento" CssClass="cal_Theme1" PopupPosition="Right">
                                                        </cc1:CalendarExtender>
                                                        <cc1:MaskedEditExtender ID="mskFechaNacimiento" runat="server" Mask="99/99/9999"
                                                            MaskType="Date" TargetControlID="txtFechaNacimiento" UserDateFormat="DayMonthYear">
                                                        </cc1:MaskedEditExtender>
                                                        <asp:RequiredFieldValidator ID="reqFechaNacimiento" runat="server" ErrorMessage="Fecha de nacimiento requerida"
                                                            ControlToValidate="txtFechaNacimiento" ValidationGroup="vsParticipante">*</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="cmpFechaNacimiento">
                                                        </cc1:ValidatorCalloutExtender>
                                                        <asp:RangeValidator ID="cmpFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento"
                                                            ErrorMessage="Fecha de nacimiento inválida" Type="Date" ValidationGroup="vsParticipante">*</asp:RangeValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="reqFechaNacimiento">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Distribuidor
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDistribuidor" runat="server" DataValueField="ID" DataTextField="Descripcion"
                                                            Width="322px" AutoPostBack="true" OnSelectedIndexChanged="ddlDistribuidor_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="reqDistribuidor" runat="server" ErrorMessage="Distribuidor requerido"
                                                            InitialValue="0" ControlToValidate="ddlDistribuidor" ValidationGroup="vsParticipante">*</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" TargetControlID="reqDistribuidor">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Gerente
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlGerente" runat="server" DataValueField="ID" DataTextField="Descripcion"
                                                            Width="322px" AutoPostBack="true" OnSelectedIndexChanged="ddlGerente_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="reqGerente" runat="server" ErrorMessage="Gerente requerido"
                                                            InitialValue="0" ControlToValidate="ddlGerente" ValidationGroup="vsParticipante">*</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="reqGerente">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Supervisor
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSupervisor" runat="server" DataValueField="ID" DataTextField="Descripcion"
                                                            Width="322px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="reqSupervisor" runat="server" ErrorMessage="Supervisor requerido"
                                                            InitialValue="0" ControlToValidate="ddlSupervisor" ValidationGroup="vsParticipante">*</asp:RequiredFieldValidator>
                                                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" TargetControlID="reqSupervisor">
                                                        </cc1:ValidatorCalloutExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Button ID="btnAgregarParticipante" runat="server" Text="Agregar" OnClick="btnAgregarParticipante_Click"
                                                            ValidationGroup="vsParticipante" />
                                                    </td>
                                                    <td></td>
                                                    <td align="right">
                                                        <asp:Button ID="btnRegresarParticipante" runat="server" Text="Regresar" OnClick="btnRegresar_Click"
                                                            CausesValidation="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View id="vPassword" runat="server">
                                            <table>
                                                <tr>
                                                    <td>Nuevo password</td><td><asp:TextBox id="txtNuevoPassword" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td>Confirma nuevo password</td><td><asp:TextBox id="txtConfirmaNuevoPassword" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td><asp:Button id="btnCambiarPassword" runat="server" Text="Cambiar" OnClick="btnCambiarPassword_Click"/></td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </center>
</asp:Content>
