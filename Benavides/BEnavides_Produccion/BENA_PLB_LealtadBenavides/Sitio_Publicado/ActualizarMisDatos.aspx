<%@ Page Title="" Language="C#" MasterPageFile="~/MasterECard.Master" AutoEventWireup="true"
    CodeBehind="ActualizarMisDatos.aspx.cs" Inherits="WebPfizer.LMS.eCard.ActualizarMisDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-43180890-1', 'beneficiointeligente.com.mx');
        ga('send', 'pageview');
    </script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="641px" style="background-image: url(Imagenes_Benavides/misdatos-fondo.jpg);
                background-repeat: no-repeat;" cellspacing="5px">
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <br />
                                    <asp:Label ID="lblActTarjeta" runat="server" Text="No. de Tarjeta:" ForeColor="#777E7F"
                                        Font-Names="Arial" Font-Size="11pt"></asp:Label>
                                    <asp:Label ID="lblAntNoTarjeta" runat="server" ForeColor="#777E7F" Font-Names="Arial"
                                        Font-Size="11pt"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" DisplayMode="List"
                                        ErrorMessage="Capture los datos marcados con *" ValidationGroup="ActualizaMisDatos"
                                        Width="419px" ShowSummary="True" HeaderText="Captura los datos marcados con *" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:" ForeColor="#004A99"
                            CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:Label ID="lblAño" runat="server" Font-Size="8pt" Font-Names="Arial" ForeColor="#004A99"
                            Text="Año"></asp:Label>
                        <asp:DropDownList ID="ddlActAno" runat="server" Width="85px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A" OnSelectedIndexChanged="ddlActAno_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:Label ID="lblMes" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#004A99"
                            Text="Mes"></asp:Label>
                        <asp:DropDownList ID="ddlActMes" runat="server" Width="125px" Font-Names="Arial"
                            Font-Size="8pt" ForeColor="#857F7A" OnSelectedIndexChanged="ddlActMes_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:Label ID="lblDia" runat="server" Font-Names="Arial" Font-Size="8pt" ForeColor="#004A99"
                            Text="Día"></asp:Label>
                        <asp:DropDownList ID="ddlActDia" runat="server" Width="65px" Font-Names="Arial" Font-Size="8pt"
                            ForeColor="#857F7A">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lblActSexo" runat="server" Text="Género:" ForeColor="#004A99" CssClass="Etiqueta"
                            Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:DropDownList ID="ddlActSexo" runat="server" Width="100px" AppendDataBoundItems="True">
                        </asp:DropDownList>
                        &nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="-1"
                            ValidationGroup="ActualizaMisDatos" ControlToValidate="ddlActSexo" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        &nbsp&nbsp;&nbsp &nbsp
                        <asp:Label ID="lblActCorreoElectronico" runat="server" Text="Correo Electrónico"
                            ForeColor="#004A99" CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:TextBox ID="txtActCorreoElectronico" runat="server" Width="200px"></asp:TextBox>
                        &nbsp
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtActCorreoElectronico"
                            Display="Dynamic" ValidationGroup="ActualizaMisDatos" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        <br />
                        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                        &nbsp &nbsp
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtActCorreoElectronico"
                            Display="Dynamic" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="ActualizaMisDatos">*La estructura del correo electrónico es incorrecta</asp:RegularExpressionValidator>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblActTelefonos" runat="server" Text="Teléfonos:" ForeColor="#777E7F"
                            Font-Names="Arial" Font-Size="11pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblActTelefono" runat="server" Text="Teléfono:" ForeColor="#004A99"
                            CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:TextBox ID="txtActTelefono" runat="server" Width="80px" MaxLength="10"></asp:TextBox>
                        &nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtActTelefono"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="ActualizaMisDatos">*</asp:RequiredFieldValidator>
                        &nbsp;&nbsp &nbsp &nbsp &nbsp &nbsp
                        <asp:Label ID="lblActCelular" runat="server" Text="Teléfono Celular" ForeColor="#004A99"
                            CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:TextBox ID="txtActCelular" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtActCelular"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="ActualizaMisDatos">*</asp:RequiredFieldValidator>
                        <br />
                        &nbsp
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtActTelefono"
                            CultureInvariantValues="True" Display="Dynamic" MaximumValue="9999999999" MinimumValue="1000000000"
                            SetFocusOnError="True" Type="Double" ValidationGroup="ActualizaMisDatos">*Captura los 10 dígitos del teléfono incluyendo la lada</asp:RangeValidator>
                        &nbsp &nbsp &nbsp
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtActCelular"
                            CultureInvariantValues="True" Display="Dynamic" MaximumValue="9999999999" MinimumValue="1000000000"
                            SetFocusOnError="True" Type="Double" ValidationGroup="ActualizaMisDatos">*Captura los 10 dígitos del celular incluyendo la lada</asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <br />
                        <asp:Label ID="lblActDireccion" runat="server" Text="Dirección:" ForeColor="#777E7F"
                            Font-Names="Arial" Font-Size="11pt"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblActCalle" runat="server" Text="Calle" ForeColor="#004A99" CssClass="Etiqueta"
                            Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:TextBox ID="txtActCalle" runat="server" MaxLength="250" Width="135px"></asp:TextBox>
                        &nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtActCalle"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="ActualizaMisDatos">*</asp:RequiredFieldValidator>
                        &nbsp
                        <asp:Label ID="lblActExterior" runat="server" Text="Ext." ForeColor="#004A99" CssClass="Etiqueta"
                            Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:TextBox ID="txtActNumExterior" runat="server" Width="35px" MaxLength="10"></asp:TextBox>
                        &nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtActNumExterior"
                            Display="Dynamic" SetFocusOnError="True" ValidationGroup="ActualizaMisDatos">*</asp:RequiredFieldValidator>
                        &nbsp<asp:Label ID="lblActInterior" runat="server" Text="Num. Int" ForeColor="#004A99"
                            CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:TextBox ID="txtActNumInterior" runat="server" Width="35px" MaxLength="10"></asp:TextBox>
                        &nbsp;
                        <asp:Label ID="lblActEstado" runat="server" Text="Estado" ForeColor="#004A99" CssClass="Etiqueta"
                            Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:DropDownList ID="ddlActEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
                            Width="110px">
                        </asp:DropDownList>
                        &nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlActEstado"
                            Display="Dynamic" InitialValue="00" SetFocusOnError="True" ValidationGroup="ActualizaMisDatos">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblActMunicipio" runat="server" Text="Municipio" ForeColor="#004A99"
                            CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:DropDownList ID="ddlActMunicipio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMunicipio_SelectedIndexChanged"
                            Width="130px">
                        </asp:DropDownList>
                        &nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlActMunicipio"
                            Display="Dynamic" InitialValue="00" SetFocusOnError="True" ValidationGroup="ActualizaMisDatos">*</asp:RequiredFieldValidator>
                        &nbsp<asp:Label ID="lblACtColonia" runat="server" Text="Colonia" ForeColor="#004A99"
                            CssClass="Etiqueta" Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:DropDownList ID="ddlActColonia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlColonia_SelectedIndexChanged"
                            Width="170px">
                        </asp:DropDownList>
                        &nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlActColonia"
                            Display="Dynamic" InitialValue="00" SetFocusOnError="True" ValidationGroup="ActualizaMisDatos">*</asp:RequiredFieldValidator>
                        &nbsp<asp:Label ID="lblActCP" runat="server" Text="C.P." ForeColor="#004A99" CssClass="Etiqueta"
                            Font-Bold="True" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                        <asp:TextBox ID="txtActCP" runat="server" Width="40px" MaxLength="5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtActCP"
                            Display="Dynamic" ValidationGroup="ActualizaMisDatos">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <br />
                        <br />
                        <br />
                        <asp:LinkButton ID="lnkActualizarMisDatos" runat="server" ForeColor="#004A99" CssClass="Etiqueta"
                            Font-Bold="True" Font-Size="10pt" OnClick="lnkActualizarMisDatos_Click" ValidationGroup="ActualizaMisDatos">Actualizar</asp:LinkButton>
                        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
                        <asp:LinkButton ID="lnkCancelarMisDatos" runat="server" ForeColor="#004A99" CssClass="Etiqueta"
                            Font-Bold="True" Font-Size="10pt" OnClick="lnkCancelarMisDatos_Click">Cancelar</asp:LinkButton>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" CssClass="Etiqueta" Font-Bold="True"
                            Font-Size="10pt"></asp:Label>
                        &nbsp<asp:Label ID="lblMsn1" runat="server" Text=", da clic en" ForeColor="Gray"
                            CssClass="Etiqueta" Font-Bold="True" Font-Size="10pt" Visible="False"></asp:Label>
                        &nbsp<asp:LinkButton ID="lnkurl" runat="server" ForeColor="#004A99" CssClass="Etiqueta"
                            Font-Bold="True" Font-Size="10pt" OnClick="lnkurl_Click" Visible="false">Aceptar</asp:LinkButton>
                        &nbsp<asp:Label ID="lblMsn2" runat="server" Text="para continuar..." ForeColor="Gray"
                            CssClass="Etiqueta" Font-Bold="True" Font-Size="10pt" Visible="False"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
