<%@ Page Language="C#" MasterPageFile="~/MasterECard.Master" AutoEventWireup="true" CodeBehind="RegistroLlamada.aspx.cs" Inherits="WebPfizer.LMS.eCard.RegistroLlamada" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-73644905-1', 'auto');
    ga('send', 'pageview');

</script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            &nbsp;<asp:Panel ID="panelCaptura" runat="server" Height="100%" Style="position: static"
                Width="700px" BorderColor="Transparent" BorderStyle="None">
                                <table style="width: 654px" class="Tabla3d">
                                    <tr>
                                        <td class="Etiqueta" colspan="4" style="height: 30px; text-align: left; background-image: url(Images/Header2.jpg); background-color: lightgrey;">
                                            <asp:Label ID="lblResultado" runat="server" CssClass="EtiquetaInversa" Width="100%">Captura Información</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="Etiqueta" style="width: 112px; text-align: left">
                                            No. de Tarjeta:
                                        </td>
                                        <td style="vertical-align: top; width: 120px; text-align: left">
                                            <asp:TextBox ID="txtTarjeta" runat="server" CssClass="Texto" MaxLength="19" ToolTip="Ingrese el número de Tarjeta"
                                                Width="152px"></asp:TextBox><asp:RegularExpressionValidator ID="regtxtTarjeta" runat="server" ControlToValidate="txtTarjeta"
                                                ErrorMessage="Valor incorrecto: Tarjeta" ValidationExpression="^[0-9]{19}">*</asp:RegularExpressionValidator></td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 129px; text-align: left">
                                            Tipo Llamada:</td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 121px; text-align: left">
                                            <asp:DropDownList ID="cmbTipoLlamada" runat="server" Width="156px" AutoPostBack="True" OnSelectedIndexChanged="cmbTipoLlamada_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 112px; text-align: left;" class="Etiqueta">
                                            Quien Llama:</td>
                                        <td style="width: 120px; vertical-align: top; text-align: left;">
                                            <asp:DropDownList ID="cmbQuienLlama" runat="server" Width="160px">
                                            </asp:DropDownList></td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 129px; text-align: left">
                                            SubTipo de Llamada:</td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 121px; text-align: left">
                                            <asp:DropDownList ID="cmbSubTipoLlamada" runat="server" Width="156px">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="Etiqueta" style="width: 112px; text-align: left">
                                            Cadena:</td>
                                        <td style="vertical-align: top; width: 120px; text-align: left">
                                            <asp:DropDownList ID="cmbCadena" runat="server" AutoPostBack="True" CssClass="Combo"
                                                OnSelectedIndexChanged="cmbCadena_SelectedIndexChanged" ToolTip="Seleccione la Cadena"
                                                Width="160px">
                                            </asp:DropDownList></td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 129px; text-align: left">
                                        </td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 121px; text-align: left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Etiqueta" style="width: 112px; text-align: left">
                                            Sucursal:</td>
                                        <td style="vertical-align: top; width: 120px; text-align: left">
                                            <asp:DropDownList ID="cmbSucursal" runat="server" CssClass="Combo" ToolTip="Seleccione la Sucursal"
                                                Width="160px">
                                            </asp:DropDownList></td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 129px; text-align: left">
                                        </td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 121px; text-align: left">
                                            Referencia:</td>
                                    </tr>
                                    <tr>
                                        <td class="Etiqueta" style="width: 112px; text-align: left">
                                            Nombre:</td>
                                        <td style="vertical-align: top; width: 120px; text-align: left">
                                            <asp:TextBox ID="txtNombre" runat="server" CssClass="Texto" MaxLength="50" Width="190px"></asp:TextBox><asp:RequiredFieldValidator
                                                ID="reqtxtNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Falta: Nombre de quien Llama">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                    ID="regtxtNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Valor incorrecto: Nombre"
                                                    ValidationExpression="^[a-zA-Z\s]{1,50}">*</asp:RegularExpressionValidator></td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 129px; text-align: left">
                                        </td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 121px; text-align: left">
                                            <asp:TextBox ID="txtReferencia" runat="server" CssClass="Texto" MaxLength="40" Width="100px" Enabled="False"></asp:TextBox><asp:RegularExpressionValidator
                                                ID="regtxtReferencia" runat="server" ControlToValidate="txtReferencia" ErrorMessage="Valor incorrecto: Referencia"
                                                ValidationExpression="^[0-9]{1,4}">*</asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td class="Etiqueta" style="width: 112px; text-align: left">
                                            Teléfono de Contacto:</td>
                                        <td style="vertical-align: top; width: 120px; text-align: left">
                                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="Texto" MaxLength="30" Width="190px"></asp:TextBox><asp:RequiredFieldValidator
                                                ID="reqtxtTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Falta: No. Teléfono">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                    ID="regtxtTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Valor incorrecto: Teléfono"
                                                    ValidationExpression="^[a-zA-Z0-9\s]{1,30}">*</asp:RegularExpressionValidator></td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 129px; text-align: left">
                                        </td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 121px; text-align: left">
                                            <asp:CheckBox ID="chkStatusSolución" runat="server" Text="Caso Cerrado?" Width="155px" Enabled="False" /></td>
                                    </tr>
                                    <tr>
                                        <td class="Etiqueta" style="width: 112px; text-align: left">
                                            TIpo Nota/Comentario:</td>
                                        <td class="Etiqueta" style="width: 112px; text-align: left"><asp:DropDownList ID="cmbTipoComentario" runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="cmbTipoComentario_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 129px; text-align: left">
                                        </td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 121px; text-align: left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Etiqueta" style="width: 112px; text-align: left; vertical-align: top;">
                                            Notas/Comentario:</td>
                                        <td style="vertical-align: top; text-align: left" colspan="3">
                                            <asp:TextBox ID="txtComentario" runat="server" CssClass="Texto" Height="68px" MaxLength="200"
                                                TextMode="MultiLine" Width="472px"></asp:TextBox><asp:RequiredFieldValidator ID="reqtxtComentario"
                                                    runat="server" ControlToValidate="txtComentario" ErrorMessage="Falta: Comentario">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                        ID="regtxtComentario" runat="server" ControlToValidate="txtComentario" ErrorMessage="Valor incorrecto: Comentario"
                                                        ValidationExpression="^[a-zA-Z0-9áéíóúÁÉÍÓÚ\s]{1,200}">*</asp:RegularExpressionValidator></td>
                                    </tr>
                                    <tr>
                                        <td class="Etiqueta" style="text-align: right" colspan="4">
                                                        <asp:Button ID="btnRegistrar" runat="server" CssClass="Boton" OnClick="btnRegistrar_Click"
                                                Text="Registrar" Width="127px" /></td>
                                    </tr>
                                    <tr>
                                        <td class="Etiqueta" style="text-align: left" colspan="2">
                                            Historial de Llamada</td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 129px; text-align: left">
                                            <asp:TextBox ID="txtComentarioHistorico" runat="server" CssClass="TextoComentario" Height="68px"
                                                MaxLength="200" ReadOnly="True" TextMode="MultiLine" Width="72px" Visible="False"></asp:TextBox></td>
                                        <td class="Etiqueta" style="vertical-align: top; width: 121px; text-align: left">
                                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Etiqueta" colspan="4" style="text-align: left">
                                            <asp:GridView ID="dgLLamada" runat="server" AutoGenerateColumns="False"
                                                BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CellSpacing="1"
                                                ForeColor="#333333" GridLines="None" Width="637px">
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:BoundField DataField="LlamadaComentario_strUsuarioAlta" HeaderText="Usuario" />
                                                    <asp:BoundField DataField="TipoCierreLlamada_strDescripcion" HeaderText="Tipo" />
                                                    <asp:BoundField DataField="LlamadaComentario_dateFechaAlta" HeaderText="Fecha" />
                                                    <asp:BoundField DataField="strDescripcion" HeaderText="Descripci&#243;n" />
                                                </Columns>
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#999999" />
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="Etiqueta" style="text-align: center; vertical-align: top;" colspan="4">
                                            &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="146px" />
                                            &nbsp;</td>
                                    </tr>
                                </table>
            </asp:Panel>
            &nbsp; &nbsp;<br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
