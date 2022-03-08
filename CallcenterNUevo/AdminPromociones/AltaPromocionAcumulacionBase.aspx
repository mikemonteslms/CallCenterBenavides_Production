<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaPromocionAcumulacionBase.aspx.cs" Inherits="CallcenterNUevo.AdminPromociones.AltaPromocionAcumulacionBase" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.min.js"></script>
    <link href="cssAdminProm/cssAdminPromocion.css" rel="stylesheet" />

    <asp:Label runat="server" ID="lblTitulo" Text="Alta Promoción de Acumulación Base."  Font-Size="16px" ForeColor="DarkBlue"/>
    <asp:UpdatePanel ID="upPromocionesBase" runat="server"  >
        <ContentTemplate>
            <br />
            <asp:Panel runat="server" ID="pnlAltaPromACBase" ScrollBars="Auto" Width="100%" Height="100%"> 
                    <asp:Table ID="tblDtealle" runat="server" HorizontalAlign="Center"   Width="700px" Height="100%">
                    <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label1" runat="server" Text="Nombre de Promoción:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                            <asp:TextBox ID="txtNombrePromocion" runat="server" Width ="350px"></asp:TextBox>
                        </asp:TableCell>
                        </asp:TableRow>
                       
                    <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label6" runat="server" Text="Cantidad de acumulación:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                            <asp:TextBox ID="txtCantidadAC" runat="server"  Width ="140px" MaxLength="3" ></asp:TextBox>
                            <asp:Label ID="Label9" runat="server" Text=" % (Valores permitidos 1 - 100)"></asp:Label>&nbsp;
                            <cc1:FilteredTextBoxExtender ID="ftbeCantidadAC" runat="server" FilterType="Numbers"
                                TargetControlID="txtCantidadAC">
                                </cc1:FilteredTextBoxExtender>
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
                            <asp:Label ID="Label7" runat="server" Text="Solo servicio a domicilio:"></asp:Label>
                        </asp:TableCell>
                         <asp:TableCell Height="38px">
                             <asp:CheckBox ID="chkServicioDom" runat="server" Text =""/>
                        </asp:TableCell>
                    </asp:TableRow>
                     <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label8" runat="server" Text="Surtir en Consultorio:"></asp:Label>
                        </asp:TableCell>
                         <asp:TableCell Height="38px">
                             <asp:CheckBox ID="chkSurtir" runat="server" Text =""/>
                        </asp:TableCell>
                    </asp:TableRow>
                         <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label2" runat="server" Text="Productos:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                            <asp:FileUpload ID="fldUpProductos" runat="server" cssClass="input" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell Height="38px">
                            <asp:Label ID="Label3" runat="server" Text="Sucursales:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell Height="38px">
                            <asp:FileUpload ID="fldUpSucursales" runat="server" cssClass="input" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell ColumnSpan="2">
                            <br />
                            <asp:Table ID="tblBotones" runat="server" HorizontalAlign ="left" Width="200px">
                                <asp:TableRow >
                                    <asp:TableCell Height="38px">
                                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar"  OnClick="btnGuardar_Click" />
                                    </asp:TableCell>
                                    <asp:TableCell Height="38px">
                                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:TableCell>
                     </asp:TableRow> 
            </asp:Table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
