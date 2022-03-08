<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CancelaContactoXPadecimiento.aspx.cs" Inherits="WebPfizer.LMS.eCard.CancelaContactoXPadecimiento" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %><%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
        .fuenteReporte
        {
            font-family: Arial Narrow;
            font-size: 9pt;
        }
        .titulo
        {
            font-family: Arial;
            font-size: 10pt;
            color: #004A99;
        }
    </style>
<center>
        <div>
                <span class="titulo"><span style="font-size:16pt; font-family:Arial;color:#004A99;">Suscripciones</span></span>
        </div>
       <%-- <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>--%>
        <div id="fondo" style="background-image: url(Imagenes_Benavides/acceso-registro-header.jpg);
            width: 1010px; height: 100%; background-repeat: no-repeat;">
            <br /><br />
            <asp:Panel ID="Panel2" runat="server" Height="100%">
                <br />
                <asp:UpdatePanel ID="uppDesuscripcion" runat="server">
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr style="">
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td align="left" style="width: 100px;">
                                                <asp:Label ID="lblTarjeta" runat="server" CssClass="titulo" Text="Tarjeta: " ></asp:Label>
                                            </td>
                                            <td align="center" style="width: 250px;">
                                                <asp:TextBox ID="txtTarjeta" runat="server" Width="220px" MaxLength="19"></asp:TextBox>
                                            </td>
                                            <td style="text-align: left">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 100px;">
                                                <asp:Label ID="lblMail" runat="server" CssClass="titulo" Text="Correo electr&oacute;nico: " ></asp:Label>
                                            </td>
                                            <td align="center" style="width: 250px;">
                                                <asp:TextBox ID="txtMail" runat="server" Width="220px" MaxLength="80"></asp:TextBox>
                                            </td>
                                            <td align="center" style="text-align: left"></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 100px;">
                                                <asp:Label ID="lblTelefonoCasa" runat="server" CssClass="titulo" Text="Tel&eacute;fono casa: " ></asp:Label>
                                            </td>
                                            <td align="center" style="width: 250px;">
                                                <asp:TextBox ID="txtTelefonoCasa" runat="server" Width="220px" MaxLength="19"></asp:TextBox>
                                            </td>
                                            <td style="text-align: left"></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="width: 100px;">
                                                <asp:Label ID="lblTelefonoCelular" runat="server" CssClass="titulo" Text="Tel&eacute;fono celular: " ></asp:Label>
                                            </td>
                                            <td align="center" style="width: 250px;">
                                                <asp:TextBox ID="txtTelefonoCelular" runat="server" Width="220px" MaxLength="19"></asp:TextBox>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar"
                                                    OnClick="btnBuscar_Click" Width="130px" />&nbsp
                                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar"
                                                    OnClick="btnLimpiar_Click" Width="130px" />&nbsp
                                                <asp:ImageButton ID="btnCancelar" runat="server" Height="30px" Width="30px"
                                                    ImageUrl="~/Imagenes_Benavides/botones/undo.png" OnClick="btnCancelar_Click" Visible="false" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br /><br />
                                    <div id="divSeleccionTarjeta" runat="server" visible="false"
                                        style="width: 950px; height: 290px; overflow: scroll; border: 1px solid #c0c0c0;" >
                                        <asp:GridView ID="gvTarjetas" runat="server" Width="100%" 
                                            EmptyDataText="No hay datos que mostrar" AutoGenerateColumns="False" 
                                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                            CellPadding="3" onrowcommand="gvTarjetas_RowCommand" 
                                            onrowdatabound="gvTarjetas_RowDataBound" >
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="cmdSeleccionar" runat="server" CommandName="seleccionar" ImageUrl="~/images/update_16.gif" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Tarjeta_strNumero" HeaderText="Tarjeta Número" />
                                                <asp:BoundField DataField="Cliente_strUniqueIdentifier" HeaderText="Identificador" />
                                                <asp:BoundField DataField="Cliente_intCuenta" HeaderText="Cuenta" />
                                                <asp:BoundField DataField="TarjetaEstatus_strEstatus" HeaderText="Estatus de tarjeta" />
                                                <asp:BoundField DataField="Cliente_strPrimerNombre" HeaderText="Nombre" />
                                                <asp:BoundField DataField="Cliente_strApellidoPaterno" HeaderText="Apellido Paterno" />
                                                <asp:BoundField DataField="Cliente_strApellidoMaterno" HeaderText="Apellido Materno" />
                                                <asp:BoundField DataField="Cliente_dateFechaNacimiento" HeaderText="Fecha Nacimiento" />
                                                <asp:BoundField DataField="Cliente_dateFechaInicioMembresia" HeaderText="Inicio Membresía" />
                                                <asp:BoundField DataField="Cliente_strTelefonoCasa" HeaderText="Teléfono Casa" />
                                                <asp:BoundField DataField="Cliente_strTelefonoCelular" HeaderText="Teléfono Celular" />
                                                <asp:BoundField DataField="Cliente_strCorreoElectronico" HeaderText="Correo Electrónico" />
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066"  />
                                            <HeaderStyle BackColor="#0154A0" Font-Bold="True" ForeColor="White" CssClass="fuenteReporte" Font-Size="18px" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000000" CssClass="fuenteReporte" Font-Size="12px" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#8A0000" />
                                            <SortedAscendingHeaderStyle BackColor="#8A0000" />
                                            <SortedDescendingCellStyle BackColor="#8A0000" />
                                            <SortedDescendingHeaderStyle BackColor="#8A0000" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--<div id="divTarjetaSeleccionada" runat="server" visible="false"
                                        style="width: 950px; height: 290px; border: 1px solid #c0c0c0;" >--%>
                                    <div id="divTarjetaSeleccionada" runat="server" visible="false"
                                        style="width: 950px; " >
                                        <br />
                                        <center>
                                        <table>
                                            <tr>
                                                <td style="width: 900px;">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 50%;">
                                                                <asp:Label ID="lblTarjetaTituloSeleccion" runat="server" Text="Tarjeta Número: " CssClass="Etiqueta" Font-Size="12pt"></asp:Label>
                                                                <asp:Label ID="lblTarjetaSeleccionado" runat="server" Text="" CssClass="Etiqueta" Font-Size="12pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 50%;">
                                                                <asp:Label ID="lblMailTituloSeleccion" runat="server" Text="Correo Electrónico: " CssClass="Etiqueta" Font-Size="12pt"></asp:Label>
                                                                <asp:Label ID="lblMailSeleccionado" runat="server" Text="" CssClass="Etiqueta" Font-Size="12pt"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 900px;">
                                                    <asp:Label ID="lblNombreTituloSeleccion" runat="server" Text="Nombre:" CssClass="Etiqueta" Font-Size="12pt"></asp:Label>
                                                    <asp:Label ID="lblNombreSeleccionado" runat="server" Text="" CssClass="Etiqueta" Font-Size="12pt"></asp:Label>
                                                    <%--<table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 40%;">
                                                                <asp:Label ID="lblNombreTituloSeleccion" runat="server" Text="Nombre:" CssClass="Etiqueta" Font-Size="12pt"></asp:Label>
                                                                <asp:Label ID="lblNombreSeleccionado" runat="server" Text="" CssClass="Etiqueta" Font-Size="12pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 30%;">
                                                                <asp:Label ID="lblPaternoTituloSeleccion" runat="server" Text="Apellido Paterno: " CssClass="Etiqueta" Font-Size="12pt"></asp:Label>
                                                                <asp:Label ID="lblPaternoSeleccionado" runat="server" Text="" CssClass="Etiqueta" Font-Size="12pt"></asp:Label>
                                                            </td>
                                                            <td style="width: 30%;">
                                                                <asp:Label ID="lblMaternoTituloSeleccion" runat="server" Text="Apellido Materno: " CssClass="Etiqueta" Font-Size="12pt"></asp:Label>
                                                                <asp:Label ID="lblMaternoSeleccionado" runat="server" Text="" CssClass="Etiqueta" Font-Size="12pt"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 900px;">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 50%;">
                                                                <asp:Label ID="lblTelCasaTituloSeleccion" runat="server" CssClass="Etiqueta" 
                                                                    Font-Size="12pt" Text="Teléfono Casa: "></asp:Label>
                                                                <asp:Label ID="lblTelCasaSeleccionado" runat="server" CssClass="Etiqueta" 
                                                                    Font-Size="12pt" Text=""></asp:Label>
                                                            </td>
                                                            <td style="width: 50%;">
                                                                <asp:Label ID="lblTelCelularTituloSeleccion" runat="server" CssClass="Etiqueta" 
                                                                    Font-Size="12pt" Text="Teléfono Celular: "></asp:Label>
                                                                <asp:Label ID="lblTelCelularSeleccionado" runat="server" CssClass="Etiqueta" 
                                                                    Font-Size="12pt" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr><td><br /><br /></td></tr>
                                            <tr>
                                                <td align="center" style="font-family: Arial, Helvetica, sans-serif; font-size: 10pt; color: #004a99; font-weight:normal; text-decoration:none;">
                                                    <%--<asp:Literal ID="ltrPadecimientosPermisos" runat="server"></asp:Literal>--%>
                                                    <%--<table width="100%" >
                                                        <tr>
                                                            <td align="left">&nbsp</td>
                                                            <td id="tdTituloPermisos_7" runat="server" visible="false" align="center">BASE</td>
                                                            <td id="tdTituloPermisos_1" runat="server" visible="false" align="center">DIABETES</td>
                                                            <td id="tdTituloPermisos_2" runat="server" visible="false" align="center">BABY BENAVIDES</td>
                                                            <td id="tdTituloPermisos_3" runat="server" visible="false" align="center">PEQUES</td>
                                                            <td id="tdTituloPermisos_5" runat="server" visible="false" align="center">HIPERTENCION</td>
                                                            <td id="tdTituloPermisos_6" runat="server" visible="false" align="center">OBESIDAD</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                &nbsp <span>Correo Electrónico</span>
                                                                <br />
                                                                &nbsp <span>Celular</span>
                                                                <br />
                                                                &nbsp <span>Teléfono Particular</span>
                                                                <br />
                                                                &nbsp <span>Correo Postal</span>
                                                            </td>
                                                            <td id="tdPermisos_7" runat="server" visible="false" align="center">
                                                                <asp:RadioButtonList ID="rdoCorreoE_7" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoCelular_7" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoTelPart_7" runat="server" CssClass="Etiqueta"
                                                                     RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoCorreoP_7" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                            </td>
                                                            <td id="tdPermisos_1" runat="server" visible="false" align="center">
                                                                <asp:RadioButtonList ID="rdoCorreoE_1" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoCelular_1" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoTelPart_1" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoCorreoP_1" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                            </td>
                                                            <td id="tdPermisos_2" runat="server" visible="false" align="center">
                                                                <asp:RadioButtonList ID="rdoCorreoE_2" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoCelular_2" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoTelPart_2" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoCorreoP_2" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                            </td>
                                                            <td id="tdPermisos_3" runat="server" visible="false" align="center">
                                                                <asp:RadioButtonList ID="rdoCorreoE_3" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoCelular_3" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoTelPart_3" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoCorreoP_3" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                            </td>
                                                            
                                                            <td id="tdPermisos_5" runat="server" visible="false" align="center">
                                                                <asp:RadioButtonList ID="rdoCorreoE_5" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoCelular_5" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoTelPart_5" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoCorreoP_5" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                            </td>
                                                            <td id="tdPermisos_6" runat="server" visible="false" align="center">
                                                                <asp:RadioButtonList ID="rdoCorreoE_6" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoCelular_6" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoTelPart_6" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                                <asp:RadioButtonList ID="rdoCorreoP_6" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>--%>
                                                    <table cellspacing="4">
                                                        <tr>
                                                            <td align="center">&nbsp</td>
                                                            <td align="center">&nbsp<span>Correo Electrónico</span>&nbsp</td>
                                                            <td align="center">&nbsp<span>Celular</span>&nbsp</td>
                                                            <td align="center" runat="server" id="tdTelCasaTitulo" visible="false">&nbsp<span>Teléfono Particular</span>&nbsp</td>
                                                            <td align="center" runat="server" id="tdPostalTitulo" visible="false">&nbsp<span>Correo Postal</span>&nbsp</td>
                                                        </tr>
                                                        <tr id="trPermisos_7" runat="server" visible="false" align="center">
                                                            <td align="left">GENERAL</td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCorreoE_7" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCelular_7" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td runat="server" id="tdTelCasa7" visible="false">
                                                                <asp:RadioButtonList ID="rdoTelPart_7" runat="server" CssClass="Etiqueta"
                                                                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td runat="server" id="tdPostal7" visible="false">
                                                                <asp:RadioButtonList ID="rdoCorreoP_7" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trPermisos_1" runat="server" visible="false" align="center">
                                                            <td align="left">DIABETES</td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCorreoE_1" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCelular_1" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoTelPart_1" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCorreoP_1" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trPermisos_2" runat="server" visible="false" align="center">
                                                            <td align="left">BABY BENAVIDES</td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCorreoE_2" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCelular_2" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoTelPart_2" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCorreoP_2" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trPermisos_3" runat="server" visible="false" align="center">
                                                            <td align="left">PEQUES</td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCorreoE_3" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCelular_3" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td runat="server" id="tdTelCasa3" visible="false">
                                                                <asp:RadioButtonList ID="rdoTelPart_3" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td runat="server" id="tdPostal3" visible="false">
                                                                <asp:RadioButtonList ID="rdoCorreoP_3" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trPermisos_5" runat="server" visible="false" align="center">
                                                            <td align="left">HIPERTENCION</td>                             
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCorreoE_5" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCelular_5" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoTelPart_5" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCorreoP_5" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trPermisos_6" runat="server" visible="false" align="center">
                                                            <td align="left">OBESIDAD</td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCorreoE_6" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCelular_6" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoTelPart_6" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td>
                                                                <asp:RadioButtonList ID="rdoCorreoP_6" runat="server" CssClass="Etiqueta"
                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                    <asp:ListItem Value="1">Sí</asp:ListItem>
                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                               </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <br />
                                                    <asp:Button ID="btnAplicarSuscripion" runat="server" Text="Aceptar" 
                                                        Width="130px" onclick="btnAplicarSuscripion_Click" />
                                                    &nbsp;&nbsp;
                                                    <asp:Button ID="btnCancelarSus" runat="server" Text="Cancelar" 
                                                        Width="130px" onclick="btnCancelarSus_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        </center>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <br /><br /><br /><br /><br />
                        <asp:UpdateProgress ID="uprDesuscripcion" runat="server" AssociatedUpdatePanelID="uppDesuscripcion">
                            <ProgressTemplate>
                                <div class="overlay" />
                                <div class="overlayContent">
                                    <img src="Images/aero_light.gif" alt="Procesando" border="1" />
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br /><br />
            </asp:Panel>
        </div>
</center>
</asp:Content>