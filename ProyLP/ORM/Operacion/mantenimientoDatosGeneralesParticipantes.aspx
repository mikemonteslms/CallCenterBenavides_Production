<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="mantenimientoDatosGeneralesParticipantes.aspx.cs" Inherits="ORMOperacion.mantenimientoDatosGeneralesParticipantes" %>

<%@ MasterType VirtualPath="~/contenido.master" %>
<%@ Reference Control="~/controles/ucDireccion_AR.ascx" %>
<%@ Reference Control="~/controles/ucDireccion_MX.ascx" %>
<%@ Reference Control="~/controles/ucDireccion_BR.ascx" %>
<%@ Reference Control="~/controles/ucDireccion_CO.ascx" %>
<%@ Register Src="~/controles/ucDireccionDistribuidor_MX.ascx" TagPrefix="uc1" TagName="ucDireccionDistribuidor_MX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
    <link rel="stylesheet" type="text/css" href="style/css/calendario.css" />
    <link rel="stylesheet" type="text/css" href="style/css/estilo-operacion.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <center>
            <table border="0" width="100%">
                <tr>
                    <td align="center">
                        <h3>Mantenimiento de Datos Generales</h3>
                    </td>
                </tr>
                <tr>
                    <asp:ValidationSummary ID="vsRegistro" runat="server" ValidationGroup="actualizar"
                        ShowMessageBox="true" ShowSummary="false" />
                    <table border="0" width="710px">
                        <tr>
                            <td class="tabla_sup_izq"></td>
                            <td class="tabla_sup"></td>
                            <td class="tabla_sup_der"></td>
                        </tr>
                        <tr>
                            <td class="tabla_cen_izq"></td>
                            <td class="tabla_cen">
                                <div>
                                    <table border="0" width="700px">
                                        <tr class="texto11">
                                            <td>Programa
                                            </td>
                                            <td>Distribuidor
                                            </td>
                                        </tr>
                                        <tr valign="top" class="texto11">
                                            <td style="width: 340px;">
                                                    <telerik:RadTextBox ID="lblPrograma" runat="server" ReadOnly="true" Width="300"></telerik:RadTextBox>
                                            </td>
                                            <td style="width: 340px;">
                                                    <telerik:RadTextBox ID="lblDistribuidor" runat="server"  ReadOnly="true" Width="300"></telerik:RadTextBox>
                                                </td>
                                            <td>
                                                <telerik:RadButton ID="btnGenerico" runat="server" OnClick="btnGenerico_Click" Text="Enviar datos acceso" CssClass="negrita" style="background-color:#D7B35D;" width="150px" />
                                            </td>
                                        </tr>
                                         <tr class="texto11">
                                            <td>Razón Social
                                            </td>
                                            <td>Clave 
                                            </td>
                                        </tr>
                                        <tr valign="top" class="texto11">
                                            <td style="width: 340px;">
                                                    <telerik:RadTextBox ID="lblRazonSocial" runat="server"  ReadOnly="true" Width="300"></telerik:RadTextBox>
                                                </td>
                                            <td style="width: 340px;">
                                                    <telerik:RadTextBox ID="lblClave" runat="server" ReadOnly="true" Width="300"></telerik:RadTextBox>
                                                </td>
                                        </tr>
                                        <tr class="texto11">
                                            <td>Nombre
                                            </td>
                                            <td>Apellido Paterno
                                            </td>
                                        </tr>
                                        <tr valign="top" class="texto11">
                                            <td>
                                                    <telerik:RadTextBox ID="txtNombre" runat="server" Width="300px"></telerik:RadTextBox>
                                                <asp:RequiredFieldValidator ID="reqNombre" runat="server" ErrorMessage="Nombre requerido"
                                                    ControlToValidate="txtNombre" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="valNombre" runat="server" TargetControlID="reqNombre">
                                                </cc1:ValidatorCalloutExtender>
                                            </td>
                                            <td>
                                                <telerik:RadTextBox ID="txtApellidoPaterno" runat="server" Width="300px" CssClass="texto11 sin_borde"></telerik:RadTextBox>
                                            </td>
                                        </tr>
                                          <tr class="texto11">
                                            <td>Apellido Materno
                                            </td>
                                            <td>Fecha Cumpleaños
                                            </td>
                                        </tr>
                                        <tr valign="top" class="texto11">
                                            <td>
                                                <telerik:RadTextBox ID="txtApellidoMaterno" runat="server" Width="300px" CssClass="texto11 sin_borde"></telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <%--<telerik:RadDatePicker runat="server" ID="txtFechaNacimiento" Width="300">
                                                    <Calendar ID="Calendar1" runat="server" EnableKeyboardNavigation="true" CellDayFormat="dd/MM/yyyy">
                                                    </Calendar>
                                                </telerik:RadDatePicker>--%>

                                                    <asp:TextBox ID="txtFechaNacimiento" runat="server" Width="135px" CssClass="calendario telerikCalendarCustom sin_borde texto11"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqFechaNacimiento" runat="server" ErrorMessage="Fecha de nacimiento requerida"
                                                    ControlToValidate="txtFechaNacimiento" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="cmpFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento"
                                                    ErrorMessage="Fecha de nacimiento inválida" Type="Date" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RangeValidator>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="cmpFechaNacimiento">
                                                </cc1:ValidatorCalloutExtender>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="reqFechaNacimiento">
                                                </cc1:ValidatorCalloutExtender>
                                                <cc1:CalendarExtender ID="calFechaNacimientoCliente" runat="server" Format="dd/MM/yyyy"
                                                    TargetControlID="txtFechaNacimiento" CssClass="cal_Theme1" PopupPosition="Right">
                                                </cc1:CalendarExtender>
                                                <cc1:MaskedEditExtender ID="mskFechaNacimiento" runat="server" Mask="99/99/9999"
                                                    MaskType="Date" TargetControlID="txtFechaNacimiento" UserDateFormat="DayMonthYear">
                                                </cc1:MaskedEditExtender>
                                            </td>
                                        </tr>
                                        <tr class="texto11">
                                            <td>Tipo de cliente
                                            </td>
                                            <td>Fecha de alta
                                            </td>
                                        </tr>
                                        <tr valign="top" class="texto11">
                                            <td align="left">
                                                    <telerik:RadTextBox ID="txtPuesto" runat="server" Width="300px" ReadOnly="true"></telerik:RadTextBox>
                                                    <asp:HiddenField ID="hidPuestoID" runat="server" />
                                            </td>
                                            <td>
                                                    <asp:TextBox ID="txtFechaAlta" runat="server" Width="135px" CssClass="calendario telerikCalendarCustom sin_borde texto11"></asp:TextBox>
                                                <asp:RangeValidator ID="rngFechaAlta" runat="server" ControlToValidate="txtFechaAlta"
                                                    ErrorMessage="Fecha de alta inválida" Type="Date" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RangeValidator>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="rngFechaAlta">
                                                </cc1:ValidatorCalloutExtender>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                    TargetControlID="txtFechaAlta" CssClass="cal_Theme1" PopupPosition="Right">
                                                </cc1:CalendarExtender>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                                    MaskType="Date" TargetControlID="txtFechaAlta" UserDateFormat="DayMonthYear">
                                                </cc1:MaskedEditExtender>
                                            </td>                                            
                                        </tr>       
                                        
                                        <tr class="texto11">
                                            <td>Tel&eacute;fono de casa
                                            </td>
                                            <td>Tel&eacute;fono trabajo
                                            </td>
                                        </tr>
                                        <tr valign="top" class="texto11">
                                            <td>
                                                    <telerik:RadTextBox ID="txtTelCasa" runat="server" Width="300px" MaxLength="15" CssClass="texto11 sin_borde"></telerik:RadTextBox>
                                                <asp:HiddenField ID="hidTelCasaID" runat="server" />
                                            </td>
                                            <td>
                                                    <telerik:RadTextBox ID="txtTelTrabajo" runat="server" Width="300px" MaxLength="15" CssClass="texto11 sin_borde"></telerik:RadTextBox>
                                                <asp:HiddenField ID="hidTelTrabajoID" runat="server" />
                                            </td>
                                        </tr>
                                        <tr class="texto11">
                                            <td>Tel&eacute;fono celular
                                            </td>
                                            <td>Email 1 
                                            </td>
                                        </tr>
                                        <tr valign="top" class="texto11">
                                            <td>
                                                    <telerik:RadTextBox ID="txtTelCelular" runat="server" Width="300px" MaxLength="15" CssClass="texto11 sin_borde"></telerik:RadTextBox>
                                                
                                                <asp:HiddenField ID="hidTelCelularID" runat="server" />
                                            </td>
                                            <td>
                                                    <telerik:RadTextBox ID="txtEmail1" runat="server" Width="300px" CssClass="texto11 sin_borde"></telerik:RadTextBox>
                                                <asp:RequiredFieldValidator ID="reqEmail1" runat="server" ErrorMessage="Email 1 requerido"
                                                    ControlToValidate="txtEmail1" CssClass="naranja" ValidationGroup="actualizar">&nbsp;</asp:RequiredFieldValidator>
                                                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="reqEmail1">
                                                </cc1:ValidatorCalloutExtender>
                                                <asp:RegularExpressionValidator ID="revEmail1" runat="server" ControlToValidate="txtEmail1"
                                                    CssClass="naranja" ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z]{2,6}$"
                                                    ValidationGroup="actualizar" ErrorMessage="Formato de e-mail incorrecto.">&nbsp;</asp:RegularExpressionValidator>
                                                <cc1:ValidatorCalloutExtender ID="vceEmail1" runat="server" TargetControlID="revEmail1">
                                                </cc1:ValidatorCalloutExtender>
                                            </td>
                                        </tr>                                       
                                        <tr class="texto11">
                                            <td>Cédula Profesional</td>
                                        </tr>
                                        <tr valign="top" class="texto11">
                                            <td>
                                                    <telerik:RadTextBox ID="txtDNI" runat="server" Width="300px" CssClass="texto11 sin_borde" Enabled="false"></telerik:RadTextBox>
                                                </td>
                                        </tr>
                                        <tr class="texto11">
                                            <td>Deseo recibir informaciones por e-mail
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr valign="top"  class="texto11">
                                            <td>
                                                 <telerik:RadButton ID="chkEmail" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="false">
                                                     <ToggleStates>
                                                         <telerik:RadButtonToggleState Text="Recibir"></telerik:RadButtonToggleState>
                                                         <telerik:RadButtonToggleState Text="No Recibir"></telerik:RadButtonToggleState>
                                                     </ToggleStates>
                                                 </telerik:RadButton>
                                                <%--<asp:CheckBox ID="chkEmail" runat="server" CssClass="checkbox" Width="25px" />--%>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td colspan="3" align="center">
                                                <telerik:RadButton ID="btnActualizar" runat="server" Text="Actualizar Generales" CssClass="negrita"
                                                    OnClick="btnActualizar_Click" ValidationGroup="actualizar" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><br /></td>
                                        </tr>
                                        <tr class="texto11">
                                            <td>
                                                Calle
                                            </td>
                                            <td>Número exterior</td>
                                            <td>Número interior</td>
                                        </tr>
                                        <tr class="texto11">
                                            <td><telerik:RadTextBox ID="lblCalle" runat="server" Width="300"></telerik:RadTextBox></td>
                                            <td><telerik:RadTextBox ID ="lblNumExterior" runat="server" Width="300"></telerik:RadTextBox></td>
                                            <td><telerik:RadTextBox ID="lblNumInterior" runat="server" Width="200"></telerik:RadTextBox></td>
                                        </tr>
                                        <tr class="texto11">
                                               <td>Codigo Postal</td>                                                                                    
                                        </tr>
                                        <tr>
                                            <td><telerik:RadTextBox ID="lblCodigoPostal" runat="server" Width="300"></telerik:RadTextBox></td>
                                            <td><telerik:RadButton ID="btnCP" runat="server" Text="Buscar por Codigo" OnClick="btnCP_Click"></telerik:RadButton></td>
                                        </tr>
                                        <tr class="texto11">
                                            <td>Colonia</td>
                                            <td>Delegación/Municipio</td>
                                            <td>Estado</td>
                                        </tr>
                                        <tr class="texto11">
                                            
                                <td><telerik:RadComboBox ID="rcbColonia" runat="server" DataTextField="descripcion_larga" DataValueField="id" CssClass="datos_participante" Width="140px"></telerik:RadComboBox></td>
                                <td><telerik:RadComboBox ID="rcbDelegacion" runat="server" DataTextField="descripcion_larga" DataValueField="id" CssClass="datos_participante" Width="140px"></telerik:RadComboBox></td>
                                            <td><telerik:RadComboBox ID="rcbEstado" runat="server" DataTextField="descripcion_larga" DataValueField="id" CssClass="datos_participante" Width="140px"></telerik:RadComboBox></td>
                                        </tr>                                       
                                        <tr valign="top">
                                            <td colspan="3" align="center">
                                                <br />
                                                <telerik:RadButton ID="btnDireccion" runat="server" Text="Actualizar Dirección" 
                                                    CssClass="negrita" OnClick="btnDireccion_Click" ValidationGroup="actualizarDireccion" />
                                            </td>
                                        </tr>                                                                                                                        
                                        <tr>
                                            <td colspan="3">
                                                <asp:Literal ID="litMensaje" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td class="tabla_cen_der"></td>
                        </tr>
                        <tr>
                            <td class="tabla_inf_izq"></td>
                            <td class="tabla_inf"></td>
                            <td class="tabla_inf_der"></td>
                        </tr>
                    </table>
                </tr>
            </table>
    </center>
</asp:Content>
