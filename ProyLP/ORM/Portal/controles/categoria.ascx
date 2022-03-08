<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="categoria.ascx.cs" Inherits="Portal.controles.categoria" %>
<asp:Panel ID="pnlGrids" runat="server">
    <asp:HiddenField ID="hidnumero_categorias" runat="server" />
    <asp:Repeater ID="RepeaterCategorias" runat="server" OnItemDataBound="RepeaterCategorias_ItemDataBound">
        <HeaderTemplate>
            <table width="700px">
        </HeaderTemplate>
        <ItemTemplate>
            <td valign="top">
                <h3 id="h3Descripcion" runat="server">
                    <%# DataBinder.Eval(Container.DataItem, "descripcion") %>
                </h3>
                <asp:Repeater ID="RepeaterLlamadas" runat="server">
                    <HeaderTemplate>
                        <table width="300px">
                            <ul style="list-style-type: none;">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:CheckBox ID="chkLlamada" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "descripcion")%>'
                                DataTextField='<%# DataBinder.Eval(Container.DataItem, "descripcion")%>' DataValueField='<%# DataBinder.Eval(Container.DataItem, "id")%>' />
                            <asp:CheckBoxList ID="chkLlamadaList" runat="server" DataTextField='<%# DataBinder.Eval(Container.DataItem, "descripcion")%>'
                                DataValueField='<%# DataBinder.Eval(Container.DataItem, "id")%>'>
                            </asp:CheckBoxList>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul> </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Panel>

