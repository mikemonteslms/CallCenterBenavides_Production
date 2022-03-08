<%@ Page Language="C#" MasterPageFile="~/MasterEcard.Master" AutoEventWireup="true"
    CodeBehind="MisDatos.aspx.cs" Inherits="WebPfizer.LMS.eCard.MisDatos" Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link href="Styles/style.css" rel="stylesheet" type="text/css" />
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
            <div id="general" style="width: 641px;">
                <table style="background-image: url(Imagenes_Benavides/misdatos-fondo2.png); background-repeat: no-repeat;">
                    <tr>
                        <td>
                            <table style="width: 631px; margin: 5px" cellspacing="4px">
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        <asp:Label ID="lblDatos" runat="server" Text="Mis Datos" Font-Bold="True" ForeColor="#004A99"
                                            Font-Names="Arial" Font-Size="12pt"></asp:Label>
                                    </td>
                                    <caption>
                                        <caption>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                        </caption>
                                    </caption>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label1" runat="server" Text="Si deseas revisar, cambiar o añadir información a tu perfil, llama sin costo al"
                                            ForeColor="#777E7F" Font-Names="Arial"></asp:Label>
                                        &nbsp
                                        <asp:Label ID="Label2" runat="server" Text="01 800 444 2525." ForeColor="#004A99"
                                            Font-Names="Arial" Font-Size="12pt" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label3" runat="server" Text="Recuerda mantener tus datos actualizados para que puedas disfrutar de todos los beneficios del programa."
                                            ForeColor="#777E7F" Font-Names="Arial"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 300px">
                                        <br />
                                        <asp:Label ID="lblFN" runat="server" Text="Fecha de Nacimiento:" ForeColor="#777E7F"
                                            Font-Names="Arial"></asp:Label>
                                        &nbsp
                                        <asp:Label ID="lblFechaNacimiento" runat="server" Font-Names="Arial" ForeColor="#777E7F"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 323px">
                                        <br />
                                        <asp:Label ID="lblG" runat="server" Text="Género:" ForeColor="#777E7F"
                                            Font-Names="Arial"></asp:Label>
                                        &nbsp
                                        <asp:Label ID="lblGenero" runat="server" Font-Names="Arial" ForeColor="#777E7F"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 300px">
                                        <asp:Label ID="Label4" runat="server" Text="Teléfono:" ForeColor="#777E7F" Font-Names="Arial"></asp:Label>
                                        &nbsp
                                        <asp:Label ID="lblTelefono" runat="server" Font-Names="Arial" ForeColor="#777E7F"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="width: 323px">
                                        <table width="323px">
                                            <tr>
                                                <td style="width: 6px">
                                                    <asp:Label ID="Label7" runat="server" Text="Dirección:" ForeColor="#777E7F" Font-Names="Arial"></asp:Label>
                                                </td>
                                                <td style="width: 263px">
                                                    &nbsp
                                                    <asp:Label ID="lblDireccion" runat="server" Font-Names="Arial" ForeColor="#777E7F"
                                                        Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Celular:" ForeColor="#777E7F" Font-Names="Arial"></asp:Label>
                                        &nbsp
                                        <asp:Label ID="lblCelular" runat="server" Font-Names="Arial" ForeColor="#777E7F"
                                            Font-Bold="true"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Correo electrónico:" ForeColor="#777E7F"
                                            Font-Names="Arial"></asp:Label>&nbsp; &nbsp
                                        <asp:Label ID="lblCorreo" runat="server" Font-Names="Arial" ForeColor="#777E7F" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="lnkActualizarMiInformacion" runat="server" ForeColor="#004A99"
                                                    CssClass="Etiqueta" Font-Bold="True" Font-Size="10pt" OnClick="lnkActualizarMiInformacion_Click">Actualizar Mis Datos</asp:LinkButton>
                                                &nbsp
                                                <asp:Label ID="Label9" runat="server" Font-Names="Arial" ForeColor="#777E7F" Font-Bold="true">|</asp:Label>
                                                &nbsp
                                                <asp:LinkButton ID="lnkAceptaDatoContacto" runat="server" ForeColor="#004A99" CssClass="Etiqueta"
                                                    Font-Bold="True" Font-Size="10pt" OnClick="lnkAceptaDatoContacto_Click">Modificar Datos de Contacto</asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="vertical-align: top">
                                        <br />
                                        <div>
                                            <asp:ImageButton ID="imgBtnCambiarContraseña" runat="server" ImageUrl="~/Imagenes_Benavides/botones/cambiarcontrasena-btn.png"
                                                OnClick="imgBtnCambiarContraseña_Click" />
                                        </div>
                                        <div id="DivCambiarContraseña" runat="server" visible="false">
                                            <asp:Panel ID="PnlCambiarContraseña" runat="server" Width="385px" Height="350px"
                                                BackImageUrl="Imagenes_Benavides/cambiar-contraseña-fondo.png">
                                                <table class="tablaModal">
                                                    <tr>
                                                        <td colspan="2" style="width: 300px">
                                                            <br />
                                                            <br />
                                                            <asp:Label ID="lblContraseñaMP" runat="server" Text="Cambiar Contraseña" ForeColor="#004A99"
                                                                Font-Bold="True" Font-Names="Arial" Font-Size="16pt"></asp:Label>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblMsnCC" runat="server" Text="Captura todos los datos marcados abajo para realizar el cambio de contraseña."
                                                                Font-Names="Arial" ForeColor="#777E7F"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <br />
                                                            <asp:Label ID="lblMsn2CC" runat="server" Text="Son obligatorios los datos marcados con "
                                                                Font-Names="Arial" ForeColor="#777E7F"></asp:Label>
                                                            <span style="color: #777e7f">(</span><font color="#e42313"><b>*</b></font><font color="#777e7f">)</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px">
                                                            <br />
                                                            <asp:Label ID="lblContraseñaActual" runat="server" Text="Contraseña Actual: " Font-Names="Arial"
                                                                ForeColor="#004A99" Font-Bold="True"></asp:Label>
                                                            <span style="color: #004a99">(</span><font color="#e42313"><b>*</b></font><font color="#004a99">)</font>
                                                        </td>
                                                        <td style="width: 150px">
                                                            <br />
                                                            <asp:TextBox ID="txtContraseñaActual" runat="server" Width="150px" MaxLength="20"
                                                                TextMode="Password"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 10px; vertical-align: middle">
                                                        <td style="width: 150px">
                                                            <asp:Label ID="lblNuevaContraseña" runat="server" Text="Nueva Contraseña: " Font-Names="Arial"
                                                                ForeColor="#004A99" Font-Bold="True"></asp:Label>
                                                            <span style="color: #004a99">(</span><font color="#e42313"><b>*</b></font><font color="#004a99">)</font>
                                                        </td>
                                                        <td style="width: 150px">
                                                            <asp:TextBox ID="txtNuevaContraseña" runat="server" Width="150px" MaxLength="20"
                                                                TextMode="Password"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px">
                                                            <asp:Label ID="lblConfirmaContraseña" runat="server" Text="Confirma Contraseña" Font-Names="Arial"
                                                                ForeColor="#004A99" Font-Bold="True"></asp:Label>
                                                            <span style="color: #004a99">(</span><font color="#e42313"><b>*</b></font><font color="#004a99">)</font>
                                                        </td>
                                                        <td style="width: 150px">
                                                            <asp:TextBox ID="txtConfirmaContraseña" runat="server" Width="150px" MaxLength="20"
                                                                TextMode="Password"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <br />
                                                            <br />
                                                            <asp:ImageButton ID="imgBtnEnviarContraseña" runat="server" ImageUrl="~/Imagenes_Benavides/botones/enviar-btn.png"
                                                                OnClick="imgBtnEnviarContraseña_Click" />
                                                            &nbsp &nbsp &nbsp
                                                            <asp:ImageButton ID="imgBtnCancelarContraseña" runat="server" ImageUrl="~/Imagenes_Benavides/botones/cancelar-btn.png"
                                                                OnClick="imgBtnCancelarContraseña_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Label ID="lblMensajeCambiarContraseña" runat="server" Font-Names="Arial" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <cc1:ModalPopupExtender ID="mpeCambiarContraseña" runat="server" PopupControlID="PnlCambiarContraseña"
                                                TargetControlID="imgBtnCambiarContraseña" DynamicServicePath="" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>
                                        </div>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:Label ID="Label8" runat="server" Text="Mis Movimientos" ForeColor="#004A99"
                                            Font-Bold="True" Font-Names="Arial" Font-Size="12pt"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <div>
                                                <br />
                                                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="614px">
                                                    <asp:Image ID="imgHeaderTransacciones" runat="server" ImageUrl="~/Imagenes_Benavides/header-tabla.png" />
                                                    <asp:GridView ID="grvTransacciones" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                                                        Width="614px" CssClass="gridTransacciones" CellPadding="0" CellSpacing="0" GridLines="None"
                                                        BackColor="White">
                                                        <AlternatingRowStyle CssClass="gridTransacciones" />
                                                        <RowStyle CssClass="gridTransacciones" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Tarjeta" Visible="False">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Tarjeta") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Tarjeta") %>' Width="0px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Fecha" ItemStyle-HorizontalAlign="Center">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox5" runat="server" Font-Names="Arial" ForeColor="#1588D9"
                                                                        Text='<%# Bind("Fecha") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label5" runat="server" Font-Names="Arial" ForeColor="#004A99" Text='<%# Bind("Fecha") %>'
                                                                        Width="70px"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tipo de Movimiento">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("TipoMovNombre") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("TipoMovNombre") %>' Width="120px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Sucursal">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("NombreSucursal") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("NombreSucursal") %>' Width="125px"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="False" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Ticket">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Ticket") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Ticket") %>' Width="90px" CssClass="gridEspecial"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Importe">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Importe") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Importe","{0:$0.00}") %>' Width="60px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Puntos" HeaderText="Puntos" Visible="False"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Dinero Electrónico Benavides">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PesosPuntos") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("PesosPuntos","{0:$0.00}") %>'
                                                                        Width="70px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </asp:Panel>
                                            </div>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
