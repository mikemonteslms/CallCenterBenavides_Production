<%@ Page Title="" Language="C#" MasterPageFile="~/contenido.Master" AutoEventWireup="true" CodeBehind="CalendarioMundial.aspx.cs" Inherits="ORMOperacion.CalendarioMundial" %>

<%@ MasterType VirtualPath="~/contenido.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head_contenido" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body_contenido" runat="server">
    <script type="text/javascript">
        function validar(valor) {
            if (document.getElementById(valor.id.replace("lnkActualizar1", "txtMarcadorLocal")).value == "")
                alert('Ingresa el marcador local');
            else if (document.getElementById(valor.id.replace("lnkActualizar1", "txtMarcadorVisitante")).value == "")
                alert('Ingresa el marcador visitante');
            else {
                document.getElementById(valor.id.replace("lnkActualizar1", "lnkActualizar")).click();
            }
        }

        function validarAgregar(valor) {
            if (document.getElementById(valor.id.replace("lnkAgregar1", "ddlGrupo")).value == "")
                alert('Ingresa el grupo');
            else if (document.getElementById(valor.id.replace("lnkAgregar1", "rdpFecha")).value == "")
                alert('Ingresa la fecha');
            else if (document.getElementById(valor.id.replace("lnkAgregar1", "ddlHorario")).value == "")
                alert('Ingresa el horario');
            else if (document.getElementById(valor.id.replace("lnkAgregar1", "ddlLocal")).value == "")
                alert('Ingresa local');
            else if (document.getElementById(valor.id.replace("lnkAgregar1", "ddlVisitante")).value == "")
                alert('Ingresa visitante');
            else if (document.getElementById(valor.id.replace("lnkAgregar1", "ddlLocal")).value == document.getElementById(valor.id.replace("lnkAgregar1", "ddlVisitante")).value)
                alert('Local y visitante son iguales');
            else if (document.getElementById(valor.id.replace("lnkAgregar1", "ddlSede")).value == "")
                alert('Ingresa la sede');
            else if (document.getElementById(valor.id.replace("lnkAgregar1", "txtMarcadorLocal")).value == "")
                alert('Ingresa el marcador local');
            else if (document.getElementById(valor.id.replace("lnkAgregar1", "txtMarcadorVisitante")).value == "")
                alert('Ingresa el marcador visitante');
            else {
                document.getElementById(valor.id.replace("lnkAgregar1", "lnkAgregar")).click();
            }
        }
    </script>
    <telerik:RadGrid ID="gridMarcadoresPartidos" runat="server" AutoGenerateColumns="false"
        OnItemDataBound="gridMarcadoresPartidos_ItemDataBound" AllowPaging="true" PageSize="10"
        OnNeedDataSource="gridMarcadoresPartidos_NeedDataSource">
        <MasterTableView DataKeyNames="id">
            <Columns>
                <telerik:GridBoundColumn UniqueName="id" DataField="id" HeaderText="id" Visible="false"></telerik:GridBoundColumn>
                <telerik:GridTemplateColumn DataField="grupo" HeaderText="Grupo" UniqueName="grupo">
                    <ItemTemplate>
                        <asp:Label ID="lblGrupo" runat="server" Text='<%# Bind("grupo") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblGrupo1" runat="server" Text="Grupo" CssClass="texto11 negrita"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlGrupo" runat="server" DataTextField="grupo" DataValueField="grupo" AppendDataBoundItems="true">
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="fecha" DataField="fecha" HeaderText="Fecha">
                    <ItemTemplate>
                        <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("fecha","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblFecha1" runat="server" Text="Fecha" CssClass="texto11 negrita"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadDatePicker ID="rdpFecha" runat="server" Width="120">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                                            ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" DisplayText="" LabelWidth="40%" type="text" value=""></DateInput>
                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="horario" DataField="horario" HeaderText="Horario">
                    <ItemTemplate>
                        <asp:Label ID="lblHorario" runat="server" Text='<%# Bind("horario") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblHorario1" runat="server" Text="Horario" CssClass="texto11 negrita"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlHorario" runat="server" DataTextField="horario" DataValueField="horario" AppendDataBoundItems="true">
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="local" DataField="local" HeaderText="Local">
                    <ItemTemplate>
                        <asp:Label ID="lblLocal" runat="server" Text='<%# Bind("local") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblLocal1" runat="server" Text="Local" CssClass="texto11 negrita"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlLocal" runat="server" DataTextField="local" DataValueField="local" AppendDataBoundItems="true">
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="visitante" DataField="visitante" HeaderText="Visitante">
                    <ItemTemplate>
                        <asp:Label ID="lblVisitante" runat="server" Text='<%# Bind("visitante") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblVisitante1" runat="server" Text="Visitante" CssClass="texto11 negrita"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlVisitante" runat="server" DataTextField="visitante" DataValueField="visitante" AppendDataBoundItems="true">
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="sede" DataField="sede" HeaderText="sede">
                    <ItemTemplate>
                        <asp:Label ID="lblSede" runat="server" Text='<%# Bind("sede") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblSede1" runat="server" Text="Sede" CssClass="texto11 negrita"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlSede" runat="server" DataTextField="sede" DataValueField="sede" AppendDataBoundItems="true">
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="marcadorLocal" HeaderText="Marcador local">
                    <ItemTemplate>
                        <asp:TextBox ID="txtMarcadorLocal" runat="server" Text='<%# Eval("marcador_Local") %>'></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars" FilterType="Numbers"
                            TargetControlID="txtMarcadorLocal" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblMarcadorLocal1" runat="server" Text="Marcador local" CssClass="texto11 negrita"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtMarcadorLocal" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars" FilterType="Numbers"
                                        TargetControlID="txtMarcadorLocal" />
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="marcadorVisitante" HeaderText="Marcador visitante">
                    <ItemTemplate>
                        <asp:TextBox ID="txtMarcadorVisitante" runat="server" Text='<%# Eval("marcador_Visitante") %>'></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars" FilterType="Numbers"
                            TargetControlID="txtMarcadorVisitante" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblMarcadorVisitante1" runat="server" Text="Marcador visitante" CssClass="texto11 negrita"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtMarcadorVisitante" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTexBoxExtender2" runat="server" FilterMode="ValidChars" FilterType="Numbers"
                                        TargetControlID="txtMarcadorVisitante" />
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="Actualizar" HeaderText="" HeaderStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        <asp:LinkButton ID="lnkAgregar1" runat="server" CssClass="texto11 negrita" OnClientClick="validarAgregar(this); return false;">Agregar</asp:LinkButton>
                        <div style="display: none">
                            <asp:LinkButton ID="lnkAgregar" runat="server" OnCommand="lnkAgregar_Command"></asp:LinkButton>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkActualizar1" runat="server" OnClientClick="validar(this); return false;">Actualizar</asp:LinkButton>
                        <div style="display: none">
                            <asp:LinkButton ID="lnkActualizar" runat="server" OnClick="lnkActualizar_Click" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
