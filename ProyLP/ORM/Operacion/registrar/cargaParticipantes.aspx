<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="cargaParticipantes.aspx.cs" Inherits="ORMOperacion.registrar.cargaParticipantes" %>

<%@ Register Assembly="BotonEnviar" Namespace="BotonEnviar" TagPrefix="cc3" %>
<%@ MasterType VirtualPath="~/contenido.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <script type="text/javascript">
        function mngRequestStarted(ajaxManager, eventArgs) {
            if (eventArgs.get_eventTarget().indexOf("ExportToExcelButton") != -1)
                eventArgs.set_enableAjax(false);
            else if (eventArgs.get_eventTarget().indexOf("btnExportar") != -1) {
                eventArgs.set_enableAjax(false);
            }
            else {
                // the following Javascript code takes care of expanding the RadAjaxLoadingPanel
                // to the full height of the page, if it is more than the browser window viewport

                var loadingPanel = document.getElementById("ContentPlaceHolder1_body_contenido_RadAjaxLoadingPanel1");
                var pageHeight = document.documentElement.scrollHeight;
                var viewportHeight = document.documentElement.clientHeight;

                if (pageHeight > viewportHeight) {
                    loadingPanel.style.height = pageHeight + "px";
                }

                var pageWidth = document.documentElement.scrollWidth;
                var viewportWidth = document.documentElement.clientWidth;

                if (pageWidth > viewportWidth) {
                    loadingPanel.style.width = pageWidth + "px";
                }

                // the following Javascript code takes care of centering the RadAjaxLoadingPanel
                // background image, taking into consideration the scroll offset of the page content

                var scrollTopOffset = document.documentElement.scrollTop;
                var scrollLeftOffset = document.documentElement.scrollLeft;
                var loadingImageWidth = 55;
                var loadingImageHeight = 55;

                loadingPanel.style.backgroundPosition = (parseInt(scrollLeftOffset) + parseInt(viewportWidth / 2) - parseInt(loadingImageWidth / 2)) + "px " + (parseInt(scrollTopOffset) + parseInt(viewportHeight / 2) - parseInt(loadingImageHeight / 2)) + "px";

                // workaround for RadAjaxLoadingPanel for ASP.NET - there are two elements with the same ID
                // this is not needed with RadAjaxLoadingPanel for ASP.NET AJAX

                if (loadingPanel.nextSibling.className == loadingPanel.className) // IE, Opera
                {
                    loadingPanel.nextSibling.style.backgroundPosition = (parseInt(scrollLeftOffset) + parseInt(viewportWidth / 2) - parseInt(loadingImageWidth / 2)) + "px " + (parseInt(scrollTopOffset) + parseInt(viewportHeight / 2) - parseInt(loadingImageHeight / 2)) + "px";
                }
                else if (document.getElementsByClassName) // Firefox
                {
                    var panels = document.getElementsByClassName("MyModalPanel");
                    for (var j = 0; j < panels.length; j++) {
                        panels[j].style.backgroundPosition = (parseInt(scrollLeftOffset) + parseInt(viewportWidth / 2) - parseInt(loadingImageWidth / 2)) + "px " + (parseInt(scrollTopOffset) + parseInt(viewportHeight / 2) - parseInt(loadingImageHeight / 2)) + "px";
                    }
                }
            }
        }
    </script>
    <center>
    <div id="rounded-box4">
        <asp:ValidationSummary ID="vsGenerar" runat="server" ValidationGroup="generar"
            ShowMessageBox="true" ShowSummary="false" />
        <asp:UpdatePanel ID="upCarga" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnExportar" />
            </Triggers>
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td align="center">
                            <h4>Carga Participantes</h4>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="height: 550px; width: 1100px; overflow: scroll">
                                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" IsSticky="true" HorizontalAlign="Center" Skin="Web20" BackgroundPosition="Center" CssClass="MyModalPanel">
                                </telerik:RadAjaxLoadingPanel>
                                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="mngRequestStarted">
                                    <AjaxSettings>                                        
                                        <telerik:AjaxSetting AjaxControlID="rgCargaParticipantes">
                                            <UpdatedControls>
                                                <telerik:AjaxUpdatedControl ControlID="rgCargaParticipantes" />
                                            </UpdatedControls>
                                        </telerik:AjaxSetting>                                        
                                    </AjaxSettings>
                                </telerik:RadAjaxManager>
                                <telerik:RadGrid ID="rgCargaParticipantes" runat="server" AutoGenerateColumns="false" Width="50%" OnItemDataBound="rgCargaParticipantes_ItemDataBound" OnItemCommand="rgCargaParticipantes_ItemCommand">
                                    <MasterTableView CommandItemDisplay="Top" DataKeyNames="N">
                                        <Columns>
                                            <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ImageUrl="/style/images/No.gif" Text="Eliminar" ConfirmTextFormatString="¿Eliminar fila {0}?" ConfirmTextFields="N">
                                            </telerik:GridButtonColumn>
                                            <telerik:GridBoundColumn HeaderText="Nº" DataField="N">
                                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn UniqueName="clave" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblMarca" runat="server">Programa</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlMarca" runat="server" DataTextField="descripcion" DataValueField="clave" AppendDataBoundItems="true" AutoPostBack="true" CssClass="texto11" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvMarca" runat="server" ControlToValidate="ddlMarca" ErrorMessage="Marca requerida" InitialValue="" ValidationGroup="generar">&nbsp;</asp:RequiredFieldValidator></td>
                                                        </tr>
                                                    </table>
                                                    <asp:HiddenField ID="hidCorreo_electronico" runat="server" />
                                                    <asp:HiddenField ID="hidServidor_pop" runat="server" />
                                                    <asp:HiddenField ID="hidServidor_smtp" runat="server" />
                                                    <asp:HiddenField ID="hidUsuario_correo" runat="server" />
                                                    <asp:HiddenField ID="hidPassword_correo" runat="server" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="clave_concesionaria" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblNum_Conc" runat="server">N&uacute;mero Sucursal</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlConcesionaria" runat="server" DataTextField="clave" DataValueField="descripcion" AppendDataBoundItems="true" AutoPostBack="true" CssClass="texto11" Width="80px" OnSelectedIndexChanged="ddlConcesionaria_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvConcesionaria" runat="server" ControlToValidate="ddlConcesionaria" ErrorMessage="Sucursal requerida" InitialValue="" ValidationGroup="generar">&nbsp;</asp:RequiredFieldValidator></td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="num_concesionaria" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblNom_Conc" runat="server">Nombre Sucursal</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="txtNom_Conc" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <%--                    <telerik:GridTemplateColumn UniqueName="clave_usuario" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblClave_Usuario" runat="server">Clave usuario</asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>                                                                                        
                                                <asp:TextBox ID="txtClave_Usuario" runat="server" Width="100px" MaxLength="30" Text='<%# DataBinder.Eval(Container, "DataItem.Clave_Usuario") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>--%>
                                            <telerik:GridTemplateColumn UniqueName="nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblNombre" runat="server">Nombre</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtNombre" runat="server" CssClass="texto11" Text='<%# DataBinder.Eval(Container, "DataItem.Nombre") %>'></asp:TextBox></td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Nombre requerido" ControlToValidate="txtNombre" CssClass="naranja" ValidationGroup="generar">&nbsp;</asp:RequiredFieldValidator></td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="ApellidoPaterno" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblApellidoPaterno" runat="server">Apellido paterno</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="texto11" Text='<%# DataBinder.Eval(Container, "DataItem.ApellidoPaterno") %>'></asp:TextBox></td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvApellidoPaterno" runat="server" ErrorMessage="Apellido paterno requerido" ControlToValidate="txtApellidoPaterno" CssClass="naranja" ValidationGroup="generar">&nbsp;</asp:RequiredFieldValidator></td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="ApellidoMaterno" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblApellidoPaterno" runat="server">Apellido materno</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="texto11" Text='<%# DataBinder.Eval(Container, "DataItem.ApellidoMaterno") %>'></asp:TextBox></td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvApellidoMaterno" runat="server" ErrorMessage="Apellido materno requerido" ControlToValidate="txtApellidoMaterno" CssClass="naranja" ValidationGroup="generar">&nbsp;</asp:RequiredFieldValidator></td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="clave_puesto" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblPuesto" runat="server">Tipo Participante</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPuesto" runat="server" DataTextField="descripcion" DataValueField="clave" CssClass="texto11"></asp:DropDownList></td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvPuesto" runat="server" ControlToValidate="ddlPuesto" ErrorMessage="Puesto requerido" InitialValue="" ValidationGroup="generar">&nbsp;</asp:RequiredFieldValidator></td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="correo_electronico" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblCorreo_electronico" runat="server">Correo electr&oacute;nico</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <table cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtCorreo_electronico" runat="server" CssClass="texto11" Width="200px" Text='<%# DataBinder.Eval(Container, "DataItem.Correo_Electronico") %>'></asp:TextBox></td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ErrorMessage="Correo requerido" ControlToValidate="txtCorreo_electronico" CssClass="naranja" ValidationGroup="generar">&nbsp;</asp:RequiredFieldValidator></td>
                                                            <td>
                                                                <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreo_electronico" CssClass="naranja" ValidationExpression="^[\w-\.]{1,}\@([\da-zA-Z-]{1,}\.){1,}[\da-zA-Z]{2,6}$" ValidationGroup="generar" ErrorMessage="Formato de correo incorrecto.">&nbsp;</asp:RegularExpressionValidator></td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="fecha_nac" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblFecha_Nac" runat="server">Fecha nacimiento</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <telerik:RadDatePicker ID="rdpFecha_nac" runat="server" Skin="Web20" Width="95px" DbSelectedDate='<%# DataBinder.Eval(Container, "DataItem.Fecha_Nacimiento") %>' MinDate="01/01/1910">
                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                                            ViewSelectorText="x" Skin="Web20">
                                                        </Calendar>
                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" DisplayText="" LabelWidth="40%" type="text" value=""></DateInput>
                                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                    </telerik:RadDatePicker>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="fecha_alta" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblFecha_Alta" runat="server">Fecha alta</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <telerik:RadDatePicker ID="rdpFecha_alta" runat="server" Skin="Web20" Width="95px" DbSelectedDate='<%# DataBinder.Eval(Container, "DataItem.Fecha_alta") %>'>
                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                                            ViewSelectorText="x" Skin="Web20">
                                                            <SpecialDays>
                                                                <telerik:RadCalendarDay Repeatable="Today">
                                                                    <ItemStyle CssClass="rcToday" />
                                                                </telerik:RadCalendarDay>
                                                            </SpecialDays>
                                                        </Calendar>
                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" DisplayText="" LabelWidth="40%" type="text" value=""></DateInput>
                                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                    </telerik:RadDatePicker>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="celular" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblCelular" runat="server">Celular</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCelular" runat="server" Width="100px" MaxLength="20" CssClass="texto11" Text='<%# DataBinder.Eval(Container, "DataItem.Celular") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="clave_status" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblStatus" runat="server">Estatus</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlStatus" runat="server" DataTextField="clave" DataValueField="descripcion" CssClass="texto11"></asp:DropDownList>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                                <table cellspacing="0" cellpadding="0" border="0">
                                    <tr>
                                        <td align="left">
                                            <asp:GridView ID="gvExportar" runat="server"></asp:GridView>
                                            <cc3:BotonEnviar ID="btnGenerar" runat="server" Text="Generar" CssClass="boton sin_borde" TextoEnviando="Procesando..." OnClick="btnGenerar_Click" ValidationGroup="generar" />
                                            <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="boton sin_borde" OnClick="btnExportar_Click" />
                                            <asp:Label ID="lblMensaje" runat="server" CssClass="texto13"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </center>
</asp:Content>
